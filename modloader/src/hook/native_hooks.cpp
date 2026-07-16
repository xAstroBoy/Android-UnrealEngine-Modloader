// modloader/src/hook/native_hooks.cpp
// Dobby-based native function hooks for non-UFunction C++ functions
// Each hook gets a trampoline that fires pre/post callbacks with
// full ARM64 register state access — both X0-X7 AND D0-D7.
//
// ARM64 AAPCS64 calling convention:
//   X0-X7:  integer/pointer arguments
//   D0-D7:  float/double arguments (independent register file)
//   X0:     integer/pointer return value
//   D0:     float/double return value
//
// The thunks use __attribute__((naked)) inline assembly to capture
// both register banks into a NativeCallContext before dispatching
// to C++ callbacks. This is essential for hooking functions like
// UpdateRecoil(self*, float dt) where dt lives in D0, not X1.

#include "modloader/native_hooks.h"
#include "modloader/symbols.h"
#include "modloader/logger.h"
#include "modloader/lua_ue4ss_globals.h"
#include "modloader/reflection_walker.h"
#include <dobby.h>
#include <unordered_map>
#include <mutex>
#include <atomic>
#include <cstring>
#include <setjmp.h>
#include <exception>
#include <sys/mman.h>
#include <unistd.h>

// ═══════════════════════════════════════════════════════════════════════
// SAFE-CALL CRASH RECOVERY
// ═══════════════════════════════════════════════════════════════════════
// When a hooked original function crashes (SIGSEGV/SIGBUS), the crash
// handler detects this thread-local flag and uses siglongjmp to recover
// back to dispatch_full() instead of killing the process.
// dispatch_full() then returns safe defaults (0 / 0.0) to the caller.
//
// This protects the game from crashes in native functions called through
// modloader hooks — e.g. UpdateViewTargetInternal dereferencing a
// dangling FTViewTarget::Target pointer at boot (tombstone_04/05/08/11).
thread_local volatile int g_in_hook_original_call = 0;
thread_local sigjmp_buf g_hook_recovery_jmp;

// ═══════════════════════════════════════════════════════════════════════
// HOOK INSTALLATION CRASH RECOVERY
// ═══════════════════════════════════════════════════════════════════════
// When DobbyHook() tries to install a trampoline at a bad address
// (unmapped memory, stripped function too small, etc.), it can SIGSEGV.
// This flag tells the crash handler to siglongjmp back to install_at()
// instead of killing the process. install_at() then returns 0 (failure)
// and the mod continues loading — no crash, no mods killed.
thread_local volatile int g_in_hook_install = 0;
thread_local sigjmp_buf g_hook_install_jmp;

namespace native_hooks {

static std::atomic<HookId> s_next_id{1};

// One registrant's callbacks on an address. Multiple mods can hook the same
// address; each gets its own entry keyed by its identity (mod name).
struct HookEntry {
    std::string        key;   // registrant identity — same key replaces, new key appends
    NativePreCallback  pre;
    NativePostCallback post;
};
using HookChain = std::vector<HookEntry>;

struct HookRecord {
    HookId          id;
    std::string     name;
    void*           address;
    void*           original;      // trampoline to original function
    // The callback CHAIN is published as an IMMUTABLE snapshot behind an
    // atomic pointer, so the game-thread thunk iterates it lock-free while
    // registration (rare) swaps in a freshly-built snapshot. The previous
    // snapshot is intentionally leaked on swap — a reader may still be
    // iterating it and reloads are rare, so leaking a small vector beats a
    // use-after-free. (RCU-style: publish-new, never-free-old.)
    std::atomic<HookChain*> chain{nullptr};
    std::mutex      chain_edit_mutex;   // serializes snapshot rebuilds
    std::atomic<uint64_t> call_count;
    ~HookRecord() { delete chain.load(); }
};

static std::unordered_map<HookId, HookRecord*> s_hooks;
static std::unordered_map<void*, HookRecord*> s_addr_to_hook;
static std::mutex s_mutex;

// Add-or-replace one registrant's entry by key, publishing a fresh immutable
// snapshot. Same key => replace (hot-reload); new key => append (coexist).
static void chain_upsert(HookRecord* rec, const std::string& key,
                         NativePreCallback pre, NativePostCallback post) {
    std::lock_guard<std::mutex> lk(rec->chain_edit_mutex);
    HookChain* cur = rec->chain.load();
    HookChain* next = new HookChain(cur ? *cur : HookChain{});
    bool replaced = false;
    for (auto& e : *next) {
        if (e.key == key) { e.pre = std::move(pre); e.post = std::move(post); replaced = true; break; }
    }
    if (!replaced) next->push_back(HookEntry{ key, std::move(pre), std::move(post) });
    rec->chain.store(next);   // publish; old snapshot leaked on purpose
}

// Remove one registrant's entry by key. Returns true if found+removed.
static bool chain_remove(HookRecord* rec, const std::string& key) {
    std::lock_guard<std::mutex> lk(rec->chain_edit_mutex);
    HookChain* cur = rec->chain.load();
    if (!cur) return false;
    HookChain* next = new HookChain();
    next->reserve(cur->size());
    bool removed = false;
    for (auto& e : *cur) {
        if (e.key == key) { removed = true; continue; }
        next->push_back(e);
    }
    rec->chain.store(next);   // publish; old snapshot leaked on purpose
    return removed;
}

// ═══════════════════════════════════════════════════════════════════════
// ARM64 FULL-REGISTER CAPTURE THUNK SYSTEM
// ═══════════════════════════════════════════════════════════════════════
//
// Problem: C function pointers can only capture X0-X7 (integer regs).
//          Float args in D0-D7 are invisible to C-typed thunks.
//
// Solution: Each thunk is a naked assembly function that:
//   1. Saves D0-D7 to a per-slot save area (thread-local)
//   2. Passes the slot index in X9 (caller-saved scratch reg)
//   3. Falls through to a single shared assembly dispatcher that
//      calls the C++ dispatch_full() with a pointer to the save area
//   4. On return, restores D0 from the save area (float return value)
//
// The save area layout per slot:
//   [0..63]   = d[0..7]   (8 doubles = 64 bytes)
//
// We use thread-local storage so hooks are safe across threads.

constexpr int MAX_HOOKS = 256;
constexpr int MAX_THUNK_SLOTS = 64;
static HookRecord* s_thunk_table[MAX_HOOKS] = {};
static int s_thunk_count = 0;

// Per-thread float register save area — one set of 8 doubles per slot
// We only need one active at a time per thread since hooks don't recurse
// into the same slot. We use a single flat area and the slot index.
struct FloatSaveArea {
    double d[8]; // D0-D7 at entry
};
static thread_local FloatSaveArea s_float_save[MAX_THUNK_SLOTS];

// ── C++ dispatch function called from assembly thunks ───────────────────
// This receives the slot index and ALL 8 X-registers.
// D0-D7 have already been saved to s_float_save[slot] by the asm thunk.
// Returns: X0 return value in the uint64_t return.
//          D0 return value is written to s_float_save[slot].d[0].
extern "C" uint64_t dispatch_full(int slot,
                                   uint64_t x0, uint64_t x1, uint64_t x2, uint64_t x3,
                                   uint64_t x4, uint64_t x5, uint64_t x6, uint64_t x7) {
    HookRecord* rec = s_thunk_table[slot];
    if (!rec) return 0;

    rec->call_count.fetch_add(1, std::memory_order_relaxed);

    // ── THREAD SAFETY GUARD ─────────────────────────────────────────
    // Lua VM is single-threaded. If this hook is called from a non-game
    // thread (rendering thread, task graph worker, etc.), we MUST NOT
    // invoke Lua pre/post callbacks — doing so corrupts the Lua state
    // and causes SIGSEGV in lua_rawseti/luaL_unref.
    // Crash guards (nullptr callbacks) are unaffected — they only use
    // the sigsetjmp safe-call guard on the original function.
    bool on_game_thread = lua_ue4ss_globals::is_game_thread();
    HookChain* cb_chain = rec->chain.load();
  bool has_lua_callbacks = (cb_chain && !cb_chain->empty());

    if (!on_game_thread && has_lua_callbacks) {
        // Off-thread call with Lua callbacks — skip callbacks, call original
        // with sigsetjmp guard only (still protects against crashes).
        FloatSaveArea& fsa = s_float_save[slot];
        for (int i = 0; i < 8; i++) fsa.d[i] = fsa.d[i]; // preserve floats

        // Nesting-safe guard (see the on-game-thread path below for rationale).
        const int saved_in_call = g_in_hook_original_call;
        sigjmp_buf saved_jmp;
        __builtin_memcpy(&saved_jmp, &g_hook_recovery_jmp, sizeof(sigjmp_buf));

        g_in_hook_original_call = 1;
        int crash_sig = sigsetjmp(g_hook_recovery_jmp, 1);

        if (crash_sig != 0) {
            __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
            g_in_hook_original_call = saved_in_call;
            // Silent recovery — don't log every frame (rendering thread is high-frequency)
            return 0;
        }

        void* orig = rec->original;
        uint64_t ret_x0 = 0;
        double ret_d0 = 0.0;
        uint64_t x_args[8] = {x0, x1, x2, x3, x4, x5, x6, x7};

        __asm__ volatile (
            "ldp d0, d1, [%[fsa], #0]   \n"
            "ldp d2, d3, [%[fsa], #16]  \n"
            "ldp d4, d5, [%[fsa], #32]  \n"
            "ldp d6, d7, [%[fsa], #48]  \n"
            "ldp x0, x1, [%[xa], #0]    \n"
            "ldp x2, x3, [%[xa], #16]   \n"
            "ldp x4, x5, [%[xa], #32]   \n"
            "ldp x6, x7, [%[xa], #48]   \n"
            "blr %[fn]                  \n"
            "mov %[rx], x0              \n"
            "str d0, [%[rd_addr]]        \n"
            : [rx] "=r" (ret_x0)
            : [fsa]     "r" (&fsa),
              [xa]      "r" (x_args),
              [fn]      "r" (orig),
              [rd_addr] "r" (&ret_d0)
            : "x0", "x1", "x2", "x3", "x4", "x5", "x6", "x7",
              "x8", "x9", "x10", "x11", "x12", "x13", "x14", "x15",
              "x16", "x17", "x30",
              "d0", "d1", "d2", "d3", "d4", "d5", "d6", "d7",
              "d16", "d17", "d18", "d19", "d20", "d21", "d22", "d23",
              "d24", "d25", "d26", "d27", "d28", "d29", "d30", "d31",
              "cc", "memory"
        );

        __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
        g_in_hook_original_call = saved_in_call;
        fsa.d[0] = ret_d0;
        return ret_x0;
    }

    NativeCallContext ctx;
    memset(&ctx, 0, sizeof(ctx));
    ctx.x[0] = x0; ctx.x[1] = x1; ctx.x[2] = x2; ctx.x[3] = x3;
    ctx.x[4] = x4; ctx.x[5] = x5; ctx.x[6] = x6; ctx.x[7] = x7;

    // Read float registers from the save area (written by asm thunk)
    FloatSaveArea& fsa = s_float_save[slot];
    for (int i = 0; i < 8; i++) ctx.d[i] = fsa.d[i];

    ctx.original = rec->original;
    ctx.blocked = false;
    ctx.ret_override = false;
    ctx.ret_x0 = 0;
    ctx.ret_d0 = 0.0;

    // Pre callback — may modify ctx.x[], ctx.d[], or set ctx.blocked.
    // Guarded: a Lua error inside the callback throws sol::error (a C++
    // exception). If it escaped here it would unwind through the C
    // trampoline and std::terminate the whole game. Swallow + log instead.
    if (HookChain* chain = rec->chain.load()) {
        for (const HookEntry& he : *chain) {
            if (!he.pre) continue;
            try {
                he.pre(ctx);
            } catch (const std::exception& e) {
                logger::log_error("NHOOK",
                    "Hook '%s' pre-callback (key '%s') threw: %s — ignored, game continues.",
                    rec->name.c_str(), he.key.c_str(), e.what());
            } catch (...) {
                logger::log_error("NHOOK",
                    "Hook '%s' pre-callback (key '%s') threw a non-std exception — ignored.",
                    rec->name.c_str(), he.key.c_str());
            }
        }
    }

    // Call original (unless blocked or return overridden)
    // Wrapped in safe-call guard: if original crashes, recover with defaults.
    if (!ctx.blocked && !ctx.ret_override) {
        // Write potentially-modified float args back to save area
        for (int i = 0; i < 8; i++) fsa.d[i] = ctx.d[i];

        void* orig = rec->original;

        // ── SAFE-CALL GUARD (NESTING-SAFE) ───────────────────────────
        // sigsetjmp saves full register state. If the original function
        // crashes (SIGSEGV/SIGBUS on dangling pointer, null vtable, etc.),
        // the crash_handler detects g_in_hook_original_call and calls
        // siglongjmp to return here with the signal number.
        //
        // NESTING: a hooked original may itself call ANOTHER hooked function
        // (e.g. a hot per-switch setter reached from inside a bigger hooked
        // fn). Without saving state, that inner dispatch overwrites our
        // g_hook_recovery_jmp and resets g_in_hook_original_call to 0 on
        // return — so a later crash in OUR original either isn't recovered,
        // or siglongjmps into the inner's already-returned frame and corrupts
        // memory (surfacing as an unrelated luaV_execute SIGSEGV later). We
        // snapshot the outer guard state and restore it after the original
        // returns / on recovery, making the guard fully re-entrant.
        const int saved_in_call = g_in_hook_original_call;
        sigjmp_buf saved_jmp;
        __builtin_memcpy(&saved_jmp, &g_hook_recovery_jmp, sizeof(sigjmp_buf));

        g_in_hook_original_call = 1;
        int crash_sig = sigsetjmp(g_hook_recovery_jmp, 1);

        if (crash_sig != 0) {
            // ── CRASH RECOVERED ──────────────────────────────────────
            __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
            g_in_hook_original_call = saved_in_call;
            logger::log_error("NHOOK",
                "SAFE-CALL RECOVERY: Hook '%s' original function crashed "
                "(signal %d) — returning safe defaults (0/0.0). "
                "Game continues running.",
                rec->name.c_str(), crash_sig);
            ctx.ret_x0 = 0;
            ctx.ret_d0 = 0.0;
        } else {
            // ── NORMAL PATH — call original with full register restore ──
            uint64_t ret_x0 = 0;
            double ret_d0 = 0.0;
            uint64_t* x_args = ctx.x;

            __asm__ volatile (
                // Load D0-D7 from float save area
                "ldp d0, d1, [%[fsa], #0]   \n"
                "ldp d2, d3, [%[fsa], #16]  \n"
                "ldp d4, d5, [%[fsa], #32]  \n"
                "ldp d6, d7, [%[fsa], #48]  \n"
                // Load X0-X7 from integer args array
                "ldp x0, x1, [%[xa], #0]    \n"
                "ldp x2, x3, [%[xa], #16]   \n"
                "ldp x4, x5, [%[xa], #32]   \n"
                "ldp x6, x7, [%[xa], #48]   \n"
                // Call original through the function pointer
                "blr %[fn]                  \n"
                // Capture return values — X0 and D0
                "mov %[rx], x0              \n"
                "str d0, [%[rd_addr]]        \n"
                : [rx] "=r" (ret_x0)
                : [fsa]     "r" (&fsa),
                  [xa]      "r" (x_args),
                  [fn]      "r" (orig),
                  [rd_addr] "r" (&ret_d0)
                : "x0", "x1", "x2", "x3", "x4", "x5", "x6", "x7",
                  "x8", "x9", "x10", "x11", "x12", "x13", "x14", "x15",
                  "x16", "x17", "x30",
                  "d0", "d1", "d2", "d3", "d4", "d5", "d6", "d7",
                  "d16", "d17", "d18", "d19", "d20", "d21", "d22", "d23",
                  "d24", "d25", "d26", "d27", "d28", "d29", "d30", "d31",
                  "cc", "memory"
            );

            __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
            g_in_hook_original_call = saved_in_call;
            ctx.ret_x0 = ret_x0;
            ctx.ret_d0 = ret_d0;
        }
    }

    // Post callback — may modify ctx.ret_x0 / ctx.ret_d0. Guarded the same
    // way as the pre callback so a Lua error can never terminate the game.
    if (HookChain* chain = rec->chain.load()) {
        for (const HookEntry& he : *chain) {
            if (!he.post) continue;
            try {
                he.post(ctx);
            } catch (const std::exception& e) {
                logger::log_error("NHOOK",
                    "Hook '%s' post-callback (key '%s') threw: %s — ignored, game continues.",
                    rec->name.c_str(), he.key.c_str(), e.what());
            } catch (...) {
                logger::log_error("NHOOK",
                    "Hook '%s' post-callback (key '%s') threw a non-std exception — ignored.",
                    rec->name.c_str(), he.key.c_str());
            }
        }
    }

    // Write D0 return value back to save area — asm thunk will restore D0 from here
    fsa.d[0] = ctx.ret_d0;

    // Return the X0 value — asm thunk passes this through in X0
    return ctx.ret_x0;
}

// ── Assembly thunks ─────────────────────────────────────────────────────
// Each thunk is a naked function that:
//   1. Saves D0-D7 to the thread-local save area for its slot
//   2. Saves X0-X7 to stack (preserved across the setup code)
//   3. Calls dispatch_full(slot, x0, x1, ..., x7)
//   4. Restores D0 from save area (float return value)
//   5. Returns with both X0 and D0 set correctly
//
// We use a macro to generate 64 thunks. Each thunk loads its slot index
// into a register and branches to a shared body.
//
// However, __attribute__((naked)) on AArch64 with Clang/GCC is limited.
// Instead we use a simpler approach: save D0-D7 to thread-local BEFORE
// the C++ dispatch, using a small wrapper that's NOT naked.
//
// Strategy: Each thunk is a regular C++ function that:
//   - Uses inline asm to read D0-D7 into local variables
//   - Stores them into the thread-local save area
//   - Calls dispatch_full
//   - Uses inline asm to write D0 return from save area
//   - Returns X0 value
//
// The key insight: at thunk entry, the compiler hasn't clobbered D0-D7 yet
// because they're callee-saved if we read them FIRST thing. Actually D0-D7
// are caller-saved (volatile) in AAPCS64, but at function entry they hold
// the caller's arguments. If we read them before any function call or
// complex expression, they're still valid.
//
// We use __attribute__((noinline)) to prevent the compiler from
// reordering the inline asm that reads D registers.

#define DEFINE_THUNK(N) \
    __attribute__((noinline)) \
    static uint64_t thunk_##N(uint64_t a0, uint64_t a1, uint64_t a2, uint64_t a3, \
                              uint64_t a4, uint64_t a5, uint64_t a6, uint64_t a7) { \
        /* Capture D0-D7 IMMEDIATELY — before any other code executes.       */ \
        /* At function entry, D0-D7 still hold the caller's float arguments. */ \
        /* The compiler won't have clobbered them yet because this is the    */ \
        /* very first statement and we use noinline + volatile asm.          */ \
        FloatSaveArea& fsa = s_float_save[N]; \
        __asm__ volatile ( \
            "stp d0, d1, [%0, #0]  \n" \
            "stp d2, d3, [%0, #16] \n" \
            "stp d4, d5, [%0, #32] \n" \
            "stp d6, d7, [%0, #48] \n" \
            : : "r" (&fsa) \
            : "memory" \
        ); \
        /* Dispatch — handles pre/post callbacks and original call */ \
        uint64_t ret = dispatch_full(N, a0, a1, a2, a3, a4, a5, a6, a7); \
        /* Restore D0 from save area (float return value) */ \
        __asm__ volatile ( \
            "ldr d0, [%0, #0] \n" \
            : : "r" (&fsa) \
            : "d0" \
        ); \
        return ret; \
    }

// Generate 64 thunks
DEFINE_THUNK(0)   DEFINE_THUNK(1)   DEFINE_THUNK(2)   DEFINE_THUNK(3)
DEFINE_THUNK(4)   DEFINE_THUNK(5)   DEFINE_THUNK(6)   DEFINE_THUNK(7)
DEFINE_THUNK(8)   DEFINE_THUNK(9)   DEFINE_THUNK(10)  DEFINE_THUNK(11)
DEFINE_THUNK(12)  DEFINE_THUNK(13)  DEFINE_THUNK(14)  DEFINE_THUNK(15)
DEFINE_THUNK(16)  DEFINE_THUNK(17)  DEFINE_THUNK(18)  DEFINE_THUNK(19)
DEFINE_THUNK(20)  DEFINE_THUNK(21)  DEFINE_THUNK(22)  DEFINE_THUNK(23)
DEFINE_THUNK(24)  DEFINE_THUNK(25)  DEFINE_THUNK(26)  DEFINE_THUNK(27)
DEFINE_THUNK(28)  DEFINE_THUNK(29)  DEFINE_THUNK(30)  DEFINE_THUNK(31)
DEFINE_THUNK(32)  DEFINE_THUNK(33)  DEFINE_THUNK(34)  DEFINE_THUNK(35)
DEFINE_THUNK(36)  DEFINE_THUNK(37)  DEFINE_THUNK(38)  DEFINE_THUNK(39)
DEFINE_THUNK(40)  DEFINE_THUNK(41)  DEFINE_THUNK(42)  DEFINE_THUNK(43)
DEFINE_THUNK(44)  DEFINE_THUNK(45)  DEFINE_THUNK(46)  DEFINE_THUNK(47)
DEFINE_THUNK(48)  DEFINE_THUNK(49)  DEFINE_THUNK(50)  DEFINE_THUNK(51)
DEFINE_THUNK(52)  DEFINE_THUNK(53)  DEFINE_THUNK(54)  DEFINE_THUNK(55)
DEFINE_THUNK(56)  DEFINE_THUNK(57)  DEFINE_THUNK(58)  DEFINE_THUNK(59)
DEFINE_THUNK(60)  DEFINE_THUNK(61)  DEFINE_THUNK(62)  DEFINE_THUNK(63)

using ThunkFn = uint64_t(*)(uint64_t, uint64_t, uint64_t, uint64_t,
                           uint64_t, uint64_t, uint64_t, uint64_t);

static ThunkFn s_thunk_fns[64] = {
    thunk_0,  thunk_1,  thunk_2,  thunk_3,  thunk_4,  thunk_5,  thunk_6,  thunk_7,
    thunk_8,  thunk_9,  thunk_10, thunk_11, thunk_12, thunk_13, thunk_14, thunk_15,
    thunk_16, thunk_17, thunk_18, thunk_19, thunk_20, thunk_21, thunk_22, thunk_23,
    thunk_24, thunk_25, thunk_26, thunk_27, thunk_28, thunk_29, thunk_30, thunk_31,
    thunk_32, thunk_33, thunk_34, thunk_35, thunk_36, thunk_37, thunk_38, thunk_39,
    thunk_40, thunk_41, thunk_42, thunk_43, thunk_44, thunk_45, thunk_46, thunk_47,
    thunk_48, thunk_49, thunk_50, thunk_51, thunk_52, thunk_53, thunk_54, thunk_55,
    thunk_56, thunk_57, thunk_58, thunk_59, thunk_60, thunk_61, thunk_62, thunk_63,
};

void init() {
    logger::log_info("NHOOK", "Native hook subsystem initialized (max %d hooks)", MAX_HOOKS);
}

HookId install(const std::string& symbol, NativePreCallback pre, NativePostCallback post,
               const std::string& key) {
    void* addr = symbols::resolve(symbol);
    if (!addr) {
        logger::log_error("NHOOK", "Cannot hook '%s' — symbol not found", symbol.c_str());
        return 0;
    }
    return install_at(addr, symbol, pre, post, key);
}

HookId install_at(void* addr, const std::string& name,
                  NativePreCallback pre, NativePostCallback post,
                  const std::string& key_in) {
    std::lock_guard<std::mutex> lock(s_mutex);

    // Registrant identity: distinguishes mods sharing an address. Defaults to
    // the hook name so single-registrant callers keep working unchanged.
    const std::string key = key_in.empty() ? name : key_in;

    // Already hooked? Dobby can't re-hook the address, but the installed thunk
    // dispatches through this record's atomic callback CHAIN, so we upsert this
    // registrant's entry: SAME key replaces (hot-reload), NEW key appends
    // (a second mod coexists on the same address).
    auto existing = s_addr_to_hook.find(addr);
    if (existing != s_addr_to_hook.end()) {
        HookRecord* rec = existing->second;
        chain_upsert(rec, key, std::move(pre), std::move(post));
        size_t n = 0; if (HookChain* c = rec->chain.load()) n = c->size();
        logger::log_info("NHOOK", "Address 0x%lX re-hook — chain upsert key='%s' (hook '%s', %zu entrie(s))",
                         reinterpret_cast<uintptr_t>(addr), key.c_str(), rec->name.c_str(), n);
        return rec->id;
    }

    if (s_thunk_count >= 64) {
        logger::log_error("NHOOK", "Hook limit reached (64) — cannot hook '%s'", name.c_str());
        return 0;
    }

    int slot = s_thunk_count++;
    auto* rec = new HookRecord();
    rec->id = s_next_id.fetch_add(1);
    rec->name = name;
    rec->address = addr;
    rec->original = nullptr;
    rec->call_count.store(0);
    chain_upsert(rec, key, std::move(pre), std::move(post));   // initial chain entry

    s_thunk_table[slot] = rec;

    // ── HOOK INSTALL CRASH GUARD ─────────────────────────────────────
    // DobbyHook() reads instructions at 'addr' to build a trampoline,
    // then writes a branch to our thunk. If 'addr' is unmapped, the
    // function is too small for a trampoline, or the memory page can't
    // be made writable, Dobby will SIGSEGV/SIGBUS.
    // We use sigsetjmp to catch those crashes and recover gracefully —
    // install_at() returns 0 (failure) and the mod keeps loading.
    g_in_hook_install = 1;
    int install_crash_sig = sigsetjmp(g_hook_install_jmp, 1);

    if (install_crash_sig != 0) {
        // ── CRASH RECOVERED DURING HOOK INSTALLATION ─────────────────
        g_in_hook_install = 0;
        logger::log_error("NHOOK",
            "CRASH DURING HOOK INSTALL: '%s' at 0x%lX — "
            "DobbyHook() crashed with signal %d. "
            "Address is likely unmapped, function too small for trampoline, "
            "or memory protection fault. Hook skipped — mod continues loading.",
            name.c_str(), reinterpret_cast<uintptr_t>(addr), install_crash_sig);
        delete rec;
        s_thunk_table[slot] = nullptr;
        s_thunk_count--;
        return 0;
    }

    int status = DobbyHook(addr,
                           reinterpret_cast<dobby_dummy_func_t>(s_thunk_fns[slot]),
                           reinterpret_cast<dobby_dummy_func_t*>(&rec->original));

    g_in_hook_install = 0;

    if (status == 0) {
        logger::log_info("NHOOK", "Hook '%s' installed at 0x%lX (slot %d, id %lu)",
                         name.c_str(), reinterpret_cast<uintptr_t>(addr),
                         slot, (unsigned long)rec->id);
        s_hooks[rec->id] = rec;
        s_addr_to_hook[addr] = rec;
        return rec->id;
    } else {
        logger::log_error("NHOOK", "Dobby failed to hook '%s' at 0x%lX (status=%d)",
                          name.c_str(), reinterpret_cast<uintptr_t>(addr), status);
        delete rec;
        s_thunk_table[slot] = nullptr;
        s_thunk_count--;
        return 0;
    }
}

void remove(HookId id) {
    std::lock_guard<std::mutex> lock(s_mutex);
    auto it = s_hooks.find(id);
    if (it == s_hooks.end()) return;

    HookRecord* rec = it->second;
    DobbyDestroy(rec->address);
    s_addr_to_hook.erase(rec->address);
    s_hooks.erase(it);

    // Find and clear thunk slot
    for (int i = 0; i < MAX_HOOKS; i++) {
        if (s_thunk_table[i] == rec) {
            s_thunk_table[i] = nullptr;
            break;
        }
    }

    logger::log_info("NHOOK", "Hook '%s' removed (id %lu)", rec->name.c_str(), (unsigned long)id);
    delete rec;
}

bool remove_key(void* addr, const std::string& key) {
    std::lock_guard<std::mutex> lock(s_mutex);
    auto it = s_addr_to_hook.find(addr);
    if (it == s_addr_to_hook.end()) return false;
    bool removed = chain_remove(it->second, key);
    if (removed) {
        logger::log_info("NHOOK", "Chain entry key='%s' removed from hook '%s' at 0x%lX",
                         key.c_str(), it->second->name.c_str(), reinterpret_cast<uintptr_t>(addr));
    }
    // NOTE: the Dobby hook stays installed even if the chain is now empty — an
    // empty chain simply routes through the sigsetjmp guard with no callbacks
    // (harmless), and DobbyDestroy while the game thread executes the trampoline
    // would be unsafe. Full teardown is done via remove(HookId).
    return removed;
}

int remove_keys_with_prefix(const std::string& prefix) {
    if (prefix.empty()) return 0;
    std::lock_guard<std::mutex> lock(s_mutex);
    int removed = 0;
    for (auto& pair : s_addr_to_hook) {
        HookRecord* rec = pair.second;
        // Collect matching keys first — chain_remove republishes the snapshot.
        std::vector<std::string> keys;
        if (HookChain* c = rec->chain.load()) {
            for (const auto& e : *c) {
                if (e.key.compare(0, prefix.size(), prefix) == 0)
                    keys.push_back(e.key);
            }
        }
        for (const auto& k : keys) {
            if (chain_remove(rec, k)) {
                logger::log_info("NHOOK", "Chain entry key='%s' removed from hook '%s' (mod unload)",
                                 k.c_str(), rec->name.c_str());
                removed++;
            }
        }
    }
    return removed;
}

bool is_hooked(const std::string& symbol) {
    std::lock_guard<std::mutex> lock(s_mutex);
    for (const auto& pair : s_hooks) {
        if (pair.second->name == symbol) return true;
    }
    return false;
}

std::vector<HookInfo> get_all_hooks() {
    std::lock_guard<std::mutex> lock(s_mutex);
    std::vector<HookInfo> result;
    for (const auto& pair : s_hooks) {
        HookInfo hi;
        hi.id = pair.second->id;
        hi.name = pair.second->name;
        hi.address = pair.second->address;
        hi.call_count = pair.second->call_count.load(std::memory_order_relaxed);
        hi.has_pre = false;
        hi.has_post = false;
        if (HookChain* ch = pair.second->chain.load()) {
            for (const auto& e : *ch) { if (e.pre) hi.has_pre = true; if (e.post) hi.has_post = true; }
        }
        result.push_back(hi);
    }
    return result;
}

// ═══════════════════════════════════════════════════════════════════════
// BUILT-IN CRASH GUARDS
// ═══════════════════════════════════════════════════════════════════════
// These hooks have NO Lua callbacks. They exist solely to route
// known-crashy game functions through dispatch_full()'s sigsetjmp
// safe-call guard. If the original function crashes (SIGSEGV on
// dangling pointer, null vtable deref, etc.), the guard recovers
// and returns safe defaults (0/0.0) instead of killing the game.
//
// This is a C++ modloader built-in — no Lua patches required.
// ═══════════════════════════════════════════════════════════════════════

// Table of known-crashy functions to guard.
// Each entry: { mangled_symbol, fallback_offset, friendly_name }
struct CrashGuardEntry {
    const char* symbol;
    uintptr_t   fallback_offset;  // offset from libUE4 base
    const char* name;
};

static const CrashGuardEntry s_crash_guards[] = {
    // UGameEngine::RedrawViewports(bool)
    // Top-level render entry point called once per tick.
    // Hooking HERE catches ALL downstream viewport crashes:
    //   RedrawViewports → FViewport::Draw → UGameViewportClient::Draw
    //     → CalcSceneView → CalcSceneViewInitOptions → GetProjectionData
    //     → UpdateViewTargetInternal → CalcCamera
    // All of these crash at boot (9s) with dangling pointers.
    // If it crashes, safe-call guard skips this frame. Next tick retries.
    // Tombstones: 04, 05, 08, 11, 12, 13, 14
    {
        "_ZN12UGameEngine16RedrawViewportsEb",
        0x088DA0AC,
        "UGameEngine::RedrawViewports"
    },

    // APlayerCameraManager::UpdateViewTargetInternal(FTViewTarget&, float)
    // Crashes at boot (9s) when FTViewTarget::Target is null/dangling.
    // The engine calls CalcCamera on Target before it's valid.
    // Tombstones: 04, 05, 08, 11, 12, 13
    {
        "_ZN20APlayerCameraManager24UpdateViewTargetInternalER12FTViewTargetf",
        0x08A98A9C,
        "UpdateViewTargetInternal"
    },

    // ULocalPlayer::GetProjectionData(FViewport*, EStereoscopicPass,
    //                                  FSceneViewProjectionData&) const
    // Crashes at boot (9s) — vtable call on dangling view target pointer.
    // Tombstone: 14 — fault addr 0x00c1b68800000074 (corrupted vtable)
    {
        "_ZNK12ULocalPlayer17GetProjectionDataEP9FViewport17EStereoscopicPassR24FSceneViewProjectionData",
        0x08A1195C,
        "ULocalPlayer::GetProjectionData"
    },

    // APlayerController::UpdateRotation(float)
    // Crashes at boot (9s) via tick system on OVRA Update thread:
    //   UWorld::Tick → TickTaskManager → APlayerController::TickActor
    //     → UpdateRotation → vtable call on dangling pointer
    // This is a SEPARATE call chain from RedrawViewports — tick system
    // dispatches actor ticks in parallel via task graph workers.
    // Tombstone: 16 — fault addr 0x0044b68800000074 (corrupted vtable)
    {
        "_ZN18APlayerController14UpdateRotationEf",
        0x08A9F8B8,
        "APlayerController::UpdateRotation"
    },

    // APlayerController::TickActor(float, ELevelTick, FActorTickFunction&)
    // Parent of UpdateRotation in the tick pipeline.
    // Guards ALL APlayerController tick operations at once.
    // Tombstone: 16 — APlayerController::TickActor at offset +824
    {
        "_ZN18APlayerController9TickActorEf10ELevelTickR18FActorTickFunction",
        0x08AAA6C0,
        "APlayerController::TickActor"
    },
};

// ═══════════════════════════════════════════════════════════════════════
// CLOTH BONE SANITIZER  (RE4 cut-content skeleton-mismatch guard)
// ═══════════════════════════════════════════════════════════════════════
// Cut enemies (Saddler-Ada / em3f, spider, etc.) were ported from RE4 UHD
// with a DIFFERENT skeleton than the classic rig the VR engine's cloth code
// expects. PenClothSet(cModel*, CLOTH_INFO*, float) walks the cloth's bone-
// index arrays and calls cModel::getPartsPtr(model, boneIdx). When the ported
// model's bone chain is SHORTER than the cloth expects, getPartsPtr walks off
// the end and returns null → PenClothSet writes null+0x1d8 → crash
// (tombstone_20: PenClothSet+172 ← cEm3f::move ← EmSetEvent).
//
// FIX: before the original runs, rewrite any bone index the model can't
// resolve to 0xFF — the engine's universal "skip this point" sentinel, handled
// gracefully in BOTH PenClothSet and PenClothMove3. Every cloth point that maps
// to a REAL bone stays live; only the missing (cut) bones skip. No-op when the
// rig is complete (all bones resolve). PenClothSet is SHARED across enemies, so
// one hook covers every cut enemy's cloth.
//
// CLOTH_INFO layout (Em3fClothSet1/2 + PenClothSet/PenClothMove3):
//   +0   u32  count            (cloth1=6, cloth2=10)
//   +8   ptr  bone-idx array a2[1]  (primary — the cloth vertices themselves)
//   +16  ptr  bone-idx array a2[2]
//   +24  ptr  bone-idx array a2[3]
//   +32  ptr  bone-idx array a2[4]  (null for em3f)
//   +40  ptr  bone-idx array a2[5]  (null for em3f)
//   +48  ptr  bone-idx array a2[6]  (connections — heavily used)
//   +56  ptr  bone-idx array a2[7]
//   (a2[8]+ = float/data arrays — NOT bone indices)
// Each array holds `count` bytes; 0xFF already means "no bone".
static inline bool cloth_addr_ok(const void* p) {
    return p && reflection::is_readable_ptr(p);
}

// Replicate cModel::getPartsPtr(model, idx) with full null/mapped guards so it
// NEVER faults — this runs in the pre-callback, OUTSIDE the sigsetjmp guard
// that only wraps the ORIGINAL call. Returns the part ptr, or null if the index
// does not resolve to a real, mapped part.
static void* cloth_resolve_part(void* model, int idx) {
    if (idx < 0 || idx >= 255) return nullptr;
    if (!cloth_addr_ok(model)) return nullptr;
    uint8_t f9 = *((const uint8_t*)model + 9);
    void* head = *reinterpret_cast<void* const*>((const char*)model + 264);
    if (!cloth_addr_ok(head)) return nullptr;
    if (f9 & 0x20) {                                  // contiguous parts array
        void* p = (char*)head + (int64_t)496 * idx;
        return cloth_addr_ok(p) ? p : nullptr;
    }
    void* p = head;                                  // linked list: hop idx times
    for (int a = idx; a > 0; --a) {
        if (!cloth_addr_ok(p)) return nullptr;
        p = *reinterpret_cast<void* const*>((const char*)p + 264);
    }
    return cloth_addr_ok(p) ? p : nullptr;
}

// Make a single byte writable (bone-index globals may live in .data.rel.ro /
// .rodata) and store `val`. Leaves the page RW — harmless for a mod.
static void cloth_write_byte(uint8_t* addr, uint8_t val) {
    if (!addr || *addr == val) return;
    long ps = sysconf(_SC_PAGESIZE);
    if (ps <= 0) ps = 4096;
    uintptr_t page = reinterpret_cast<uintptr_t>(addr) & ~(uintptr_t)(ps - 1);
    mprotect(reinterpret_cast<void*>(page), (size_t)ps, PROT_READ | PROT_WRITE);
    *addr = val;
}

static void cloth_sanitize(void* model, uint32_t* ci) {
    if (!cloth_addr_ok(model) || !cloth_addr_ok(ci)) return;
    uint32_t count = ci[0];
    if (count == 0 || count > 128) return;           // sanity — real cloth is 6/10
    static const int kBoneArrOffsets[] = { 8, 16, 24, 32, 40, 48, 56 };
    int fixed = 0, total = 0;
    for (int off : kBoneArrOffsets) {
        uint8_t* arr = *reinterpret_cast<uint8_t* const*>((const char*)ci + off);
        if (!cloth_addr_ok(arr)) continue;           // null / unmapped array ptr
        for (uint32_t k = 0; k < count; ++k) {
            uint8_t idx = arr[k];
            if (idx == 0xFF) continue;
            ++total;
            if (!cloth_resolve_part(model, idx)) {
                cloth_write_byte(arr + k, 0xFF);
                ++fixed;
            }
        }
    }
    if (fixed > 0) {
        logger::log_info("CLOTH",
            "Sanitized model=%p ci=%p count=%u : %d/%d bone(s) -> skip (missing in ported rig)",
            model, ci, count, fixed, total);
    }
}

static void cloth_sanitize_pre(NativeCallContext& ctx) {
    // Refresh the /proc/self/maps snapshot ONCE per spawn so freshly-allocated
    // part pages read as mapped (avoids a false "missing bone").
    reflection::refresh_memory_map();
    cloth_sanitize(reinterpret_cast<void*>(ctx.x[0]),
                   reinterpret_cast<uint32_t*>(ctx.x[1]));
    // never block — let the (now-safe) original run
}

HookId install_cloth_bone_sanitizer(void* addr) {
    if (!addr) {
        logger::log_error("NHOOK", "cloth_bone_sanitizer: null addr");
        return 0;
    }
    HookId id = install_at(addr, "__cloth_bone_sanitizer",
                           cloth_sanitize_pre, nullptr, "ClothBoneSanitizer");
    logger::log_info("NHOOK", "Cloth bone sanitizer @0x%lX : %s",
                     (unsigned long)reinterpret_cast<uintptr_t>(addr),
                     id ? "installed" : "FAILED");
    return id;
}

// ═══════════════════════════════════════════════════════════════════════
// CUT-ENEMY MODEL-LOAD RESTORE  (em3f / Saddler-Ada renders)
// ═══════════════════════════════════════════════════════════════════════
// Cut enemies (em3f) have a cEmXX::move whose init state runs the native
// archive modelInit but NEVER the VR4ModelInit that spawns the visible UE
// AVR4Model — working enemies (cEm21::init) do BOTH. So em3f gets a native
// skeleton (cModel+384 = cModelInfo list) but no drawn actor (cModel+980=null,
// +988=0) → invisible. This hook injects the missing
//   VR4ModelInit(this, EmModelClassLookUp(this))
// on the tick AFTER modelInit built the model (cModel+384 != 0) and only while
// no UE model exists yet (cModel+988 == 0). Runs in the actor-tick context
// (SpawnActor-safe) with NATIVE register-passed pointers — the MTE-tagged class
// ptr from EmModelClassLookUp goes straight into VR4ModelInit, no Lua round-trip
// to mangle the tag (that mangle is why the exec_lua test faulted in SpawnActor).
// Self-guards on +988, so it is a no-op for enemies that already build their own
// UE model — safe to install on any cEmXX::move.
typedef void* (*cEm_EmModelClassLookUp_t)(void* cEm, const void* a2);
// The POSEABLE model init (0x5F83A68): spawns the poseable actor from `uclass`,
// then vtable[1584](actor, a3, cEm) loads the mesh (from the actor's MeshDataClass
// / meshTable — the pak assets) and SetBaseSkeleton builds it. a3 = the archive
// bin file (archive + *(uint32*)(archive + binOff)), matching em3d's sub_5EA06B0.
typedef void* (*cModel_VR4PoseableModelInit_t)(void* cModel, void* uclass, void* a3);
typedef void* (*FWeakObjectPtr_Get_t)(void* weakptr);
// AVR4PoseableModel::AddOrSwapSkeletalMesh(this, FName bone(by value=u64), uint key,
//                                          const cModelInfo*, UVR4MeshData*)
typedef void  (*AddOrSwapSkeletalMesh_t)(void* poseableModel, uint64_t bone, uint32_t key,
                                         const void* cModelInfo, void* meshData);
typedef uint32_t (*poseable_meshload_t)(void* actor, void* a3, void* cEm);  // actor vtable[+1584]
static cEm_EmModelClassLookUp_t       s_EmModelClassLookUp   = nullptr;
static cModel_VR4PoseableModelInit_t  s_VR4PoseableModelInit = nullptr;
static FWeakObjectPtr_Get_t           s_FWeakGet             = nullptr;
static AddOrSwapSkeletalMesh_t        s_AddOrSwapSkeletalMesh = nullptr;
// UVR4MeshData::TryCacheMap(this, char forceReload) — builds the cached key map
// (meshData+80 TSet) from the meshTable DataTable rows, keyed by FMeshDataSet+8
// (OffsetKey). At cEm3f::move hook time this map is EMPTY until this runs.
typedef void (*UVR4MeshData_TryCacheMap_t)(void* meshData, char forceReload);
// cModInfoMgr::create(&ModInfoMgr, archive+partOffset, archive+commonOffset) → cModelInfo*
// Pool-allocates a node, relocates the archive part data in place (guarded by flag
// 0x100000 so it is idempotent), stores partData @node+24 / commonData @node+32, and
// returns null if the pool is exhausted. cModel::addModel appends it to the cEm+384
// chain (linked via +40). This is verbatim what em3f's init (sub_5EA3678) does for
// its four hand-coded parts.
typedef void* (*cModInfoMgr_create_t)(void* mgr, void* partData, void* commonData);
typedef void* (*cModel_addModel_t)(void* cModel, void* modelInfo);
static cModInfoMgr_create_t s_ModInfoMgrCreate = nullptr;
static cModel_addModel_t    s_addModel         = nullptr;
static void*                s_ModInfoMgr       = nullptr;   // &ModInfoMgr, RVA 0xA578670
// VR4CreateEmSubObject(bin, parentEm, subObj) [0x5D9136C] — the port's entry point for
// giving a cObj SUB-OBJECT a renderer: runs the meshload on the PARENT's actor to get a
// mesh key, then cModel::VR4ModelInit(subObj, key, parentActor->meshData), which spawns
// the sub-object's actor from the PLAIN AVR4PoseableModel class (never a BP class).
typedef void* (*VR4CreateEmSubObject_t)(void* bin, void* parentEm, void* subObj);
static VR4CreateEmSubObject_t s_VR4CreateEmSubObject = nullptr;
static UVR4MeshData_TryCacheMap_t     s_TryCacheMap = nullptr;
// em3f_meshTable OffsetKeys decoded on PC from EnemyFixes_P.pak (7 poseable parts:
// EM3F04..EM3F94 → em3f_004..094; 2190400 = em3f_094 tentacle). Fallback keys in
// case the runtime cached-map enumeration comes up empty.
static const uint32_t s_em3fMeshKeys[7] = { 311872, 452736, 638432, 661504, 684544, 745920, 2190400 };
// ── em3f BROKEN SOFT-PATH FIXES ───────────────────────────────────────────────
// em3f_meshTable ships WRONG MeshRefs for every part sourced from the plaga set:
// rows em3f_008 / em3f_009 / em3f_094 all point at
//   /Game/Characters/BIO4/EM/em25_plaga/Geometry/<mesh>
// but those assets are actually packed (verified by decoding EnemyFixes_P.pak on
// PC, and live: LoadAsset on the em25_plaga path fails, em30_Saddler loads) at
//   /Game/Characters/BIO4/BOSS/em30_Saddler/Geometry/<mesh>
// so FSoftObjectPath::TryLoad returns null → SetMesh assigns NO mesh → those
// components render nothing (you only see the plaga attack's particles).
// Per-spawn logging confirmed keys 684544/745920 dead and 2190400 fixed once
// repointed. We rewrite each cached entry's AssetPathName FName to the correct
// path right after TryCacheMap rebuilds it, so the game's own loader resolves the
// mesh. Comparison indices come from Lua (FName(path):GetComparisonIndex()).
struct Em3fPathFix { uint32_t key; int32_t fname_idx; };
static Em3fPathFix s_em3fPathFixes[8] = {};
static int         s_em3fPathFixCount = 0;
// em3f's ETS_DATA header holds 4 model-part bin offsets: +32 (robe=base, done by
// SetBaseSkeleton) then +36/+40/+44 (body/head/hands). sub_5EA3678 builds all 4 as
// native cModelInfos (chained at cModel+384 via +40); we attach parts 1..3 to the UE
// poseable actor with AddOrSwapSkeletalMesh so the whole Saddler-Ada renders.
static const uint32_t s_partBinFields[4] = { 32, 36, 40, 44 };

static void model_restore_pre(NativeCallContext& ctx) {
    void* cEm = reinterpret_cast<void*>(ctx.x[0]);
    if (!cEm) return;
    // Read fields through the (MTE-tagged) this ptr exactly as the game does.
    uint8_t initDone = *reinterpret_cast<volatile uint8_t*>((char*)cEm + 988);
    if (initDone) return;                       // already has a UE model (or we ran)
    void* modelInfo = *reinterpret_cast<void* const volatile*>((char*)cEm + 384);
    if (!modelInfo) return;                     // native modelInit not done yet — wait a tick
    if (!s_EmModelClassLookUp || !s_VR4PoseableModelInit) return;
    void* archive = *reinterpret_cast<void* const volatile*>((char*)cEm + 1120);
    if (!archive) return;                       // ETS_DATA archive not attached

    // ── ONE-SHOT ARCHIVE PROBE ─────────────────────────────────────────────
    // em3f.das uncompresses to 2,481,120 bytes in the base pak, and the largest
    // meshTable key is 2,190,400 — so every key falls INSIDE the archive and the
    // plaga/tentacle/knife data ships with the VR game. We only ever read 4 bin
    // offsets (+32/36/40/44); dump the whole header so we can see how many the
    // archive really declares, and which offsets they point at.
    {
        static bool probed = false;
        if (!probed) {
            probed = true;
            const volatile uint32_t* h = reinterpret_cast<const volatile uint32_t*>(archive);
            // h[0] = entry count (109); the offset table starts at h[4] (byte +16).
            uint32_t count = h[0];
            logger::log_info("EM3F", "archive: %u entries, table at +16", count);
            if (count > 0 && count < 512) {
                for (uint32_t i = 0; i < count; i += 8) {
                    char line[256]; int p = 0;
                    for (uint32_t j = i; j < i + 8 && j < count; ++j)
                        p += snprintf(line + p, sizeof(line) - p, "%10u ", h[4 + j]);
                    logger::log_info("EM3F", "  ent[%3u..]: %s", i, line);
                }
                // Which table index does each meshTable key correspond to?
                static const uint32_t want[7] = { 311872, 452736, 638432, 661504,
                                                  684544, 745920, 2190400 };
                for (int k = 0; k < 7; ++k) {
                    int found = -1;
                    for (uint32_t j = 0; j < count; ++j)
                        if (h[4 + j] == want[k]) { found = (int)j; break; }
                    logger::log_info("EM3F", "  key %8u -> table idx %d (hdr byte +%d)%s",
                                     want[k], found, found >= 0 ? 16 + found * 4 : -1,
                                     found < 0 ? "   *** NOT AN ARCHIVE ENTRY ***" : "");
                }
            }
            int n = 0;
            for (void* ci = *reinterpret_cast<void* const volatile*>((char*)cEm + 384);
                 ci && n < 24;
                 ci = *reinterpret_cast<void* const volatile*>((char*)ci + 40), ++n) {
                void* dp = *reinterpret_cast<void* const volatile*>((char*)ci + 24);
                long long d = dp ? (long long)((uintptr_t)dp - (uintptr_t)archive) : -1;
                logger::log_info("EM3F", "  cModelInfo[%d] = %p  data=%p  key(delta)=%lld", n, ci, dp, d);
            }
            logger::log_info("EM3F", "  chain length = %d node(s)", n);
        }
    }

    // NOTE: em3f_008 (entry 8) and em3f_009 (entry 9) are NOT parts of this cModel.
    // SetObj41(cEm, 0/1) builds each as its own cObj with its own cModel::modelInit
    // (hence its own initJoint / 15- and 12-bone rig, and its own texture at entries
    // 2/3), parents it at obj+1024, and drives it with its own motion stream. The
    // game already creates both in em3f's init — they are invisible only because no
    // UE actor was ever made for them, exactly like the body was. They are handled
    // after the body below; do NOT add them to this chain as parts (that skins them
    // onto the body's 54-bone hierarchy = the deformed heap).
    void* cls = s_EmModelClassLookUp(cEm, nullptr);   // → GetEmModelClass(emId @cEm+0x118)
    if (!cls) return;                           // class not in EmModelData / not loaded yet
    // Base part (robe) = archive bin at header +32.
    uint32_t binOff0 = *reinterpret_cast<const uint32_t volatile*>((char*)archive + s_partBinFields[0]);
    void* a3 = (char*)archive + binOff0;
    s_VR4PoseableModelInit(cEm, cls, a3);       // spawn poseable actor + build BASE mesh, sets +988=1

    // Attach ALL the OTHER meshTable parts (body/head/hands/tentacle) so the full
    // model renders. The head/hands are pak-only meshes with no native archive bin,
    // so their keys can't come from the archive — instead we ENUMERATE the meshData's
    // cached key map (TryCacheMap built a TSet<TTuple<uint key, FVR4RawMeshData>> at
    // meshData+80: Data ptr @+80, ArrayNum @+88, element stride 120, int key @elem+0)
    // and AddOrSwapSkeletalMesh(actor, NAME_None, key, cModelInfo, meshData) each key.
    // SetBaseSkeleton already placed the base key; AddOrSwap on it just swaps (no harm).
    int attached = 0;
    if (s_FWeakGet && s_AddOrSwapSkeletalMesh) {
        void* actor = s_FWeakGet((char*)cEm + 980);
        if (actor) {
            void* meshData = *reinterpret_cast<void* const volatile*>((char*)actor + 560);
            void* baseCi   = *reinterpret_cast<void* const volatile*>((char*)cEm + 384);  // base cModelInfo
            if (meshData) {
                // CRITICAL: build the cached key map from the DataTable FIRST. At hook
                // time it is empty (TryCacheMap hasn't run) → enumeration found 0 parts,
                // which is why only the base robe rendered. Force-rebuild it now.
                if (s_TryCacheMap) s_TryCacheMap(meshData, 1);
                void* elems  = *reinterpret_cast<void* const volatile*>((char*)meshData + 80);   // TSparseArray Data
                int32_t num  = *reinterpret_cast<const int32_t volatile*>((char*)meshData + 88);  // ArrayNum
                // Repoint every broken MeshRef (em25_plaga -> em30_Saddler) in the
                // freshly-rebuilt cache, BEFORE the attach loop asks SetMesh to load them.
                // Element: {uint key @+0, FSoftObjectPath @+8}; AssetPathName FName =
                // {ComparisonIndex @+8, Number @+12}. Stride 120.
                if (s_em3fPathFixCount && elems && num > 0 && num < 64) {
                    for (int i = 0; i < num; ++i) {
                        char* e = (char*)elems + 120 * i;
                        uint32_t k = *reinterpret_cast<const uint32_t volatile*>(e);
                        for (int fx = 0; fx < s_em3fPathFixCount; ++fx) {
                            if (s_em3fPathFixes[fx].key != k) continue;
                            int32_t want = s_em3fPathFixes[fx].fname_idx;
                            if (*reinterpret_cast<const int32_t volatile*>(e + 8) != want) {
                                *reinterpret_cast<int32_t volatile*>(e + 8)  = want;
                                *reinterpret_cast<int32_t volatile*>(e + 12) = 0;
                                logger::log_info("EM3F", "MeshRef repointed key=%u em25_plaga -> em30_Saddler (FName idx %d)",
                                                 k, want);
                            }
                            break;
                        }
                    }
                }
                // Each part MUST get a distinct component-slot FName: FindOrCreateComponent
                // keys its TSet<TTuple<FName,FMeshPartData>> by the bone FName (a2), so a
                // shared NAME_None collapsed all 7 onto ONE component (each swapped the last,
                // leaving only the tentacle). Parts attach to the master via
                // SetMasterPoseComponent at identity, so the FName is purely a unique key —
                // {ComparisonIndex=None, Number=i+1} gives 7 distinct slots.
                // Map OffsetKey -> its OWN cModelInfo. Each chain node's data pointer
                // (node+24) lives at archiveBase + OffsetKey, so the key is just the
                // delta — verified from a live dump: the node deltas (140864, 185696,
                // 23072) exactly match the meshTable key deltas (311872 -> 452736 ->
                // 638432 -> 661504). Handing every part the BASE node made SetMesh's
                // TSet<cModelInfo*,component> (this+848) treat all 7 as ONE part, so
                // they inherited the base transform and piled up unanimated.
                // The chain now has 7 nodes: em3f's init builds 4 and we build the
                // three entries it skips (8/9/94) just above, so every meshTable key
                // resolves to its OWN node here. A key with no node would still be
                // skipped below rather than wrongly bound to the base part.
                struct CiEntry { uint32_t key; void* ci; };
                CiEntry cimap[16];
                int cimapN = 0;
                {
                    void* ci = *reinterpret_cast<void* const volatile*>((char*)cEm + 384);
                    for (int n = 0; ci && n < 16; ++n) {
                        void* dp = *reinterpret_cast<void* const volatile*>((char*)ci + 24);
                        if (dp && archive) {
                            uintptr_t d = (uintptr_t)dp - (uintptr_t)archive;
                            if (d < 0x8000000u) cimap[cimapN++] = { (uint32_t)d, ci };
                        }
                        ci = *reinterpret_cast<void* const volatile*>((char*)ci + 40);
                    }
                }
                // Attach every part that has a cModelInfo — now all 7, since we build
                // the three nodes em3f's init skips. Each part carries its OWN node, so
                // SetMesh's TSet<cModelInfo*,component> (this+848) keeps them distinct
                // and the native rig drives each one from its own archive joint data.
                //
                // This is what the earlier master-pose attempt got wrong: em3f_008/009/094
                // are separate armatures (15/12/own bones) that reuse the same `bone_N`
                // names as em3f_skeleton in a different order, so SetMasterPoseComponent
                // matched by name and wrenched the tentacle onto the torso joints = the
                // heap at the model centre. With their own nodes they no longer need the
                // master's rig at all.
                if (elems && num > 0 && num < 64) {
                    for (int i = 0; i < num; ++i) {
                        uint32_t key = *reinterpret_cast<const uint32_t volatile*>((char*)elems + 120 * i);
                        void* partCi = nullptr;
                        for (int m = 0; m < cimapN; ++m)
                            if (cimap[m].key == key) { partCi = cimap[m].ci; break; }
                        if (!partCi) {
                            // Expected for 684544/745920 (obj41 sub-objects, own cModel
                            // + own rig — see below) and 2190400 (em3f_094, the knife:
                            // no em3f code references archive entry 94 at all).
                            logger::log_info("EM3F", "  skip key=%u (not a part of this cModel)", key);
                            continue;
                        }
                        uint64_t slotName = (uint64_t)(i + 1) << 32;   // FName{None, i+1}
                        s_AddOrSwapSkeletalMesh(actor, slotName, key, partCi, meshData);
                        logger::log_info("EM3F", "  attach key=%u ci=%p (own node)", key, partCi);
                        ++attached;
                    }
                }
                // Fallback: if the cached map was still empty/unreadable, attach the 7
                // OffsetKeys decoded from the pak so the parts render regardless.
                if (attached == 0) {
                    for (int i = 0; i < 7; ++i) {
                        void* partCi = nullptr;
                        for (int m = 0; m < cimapN; ++m)
                            if (cimap[m].key == s_em3fMeshKeys[i]) { partCi = cimap[m].ci; break; }
                        if (!partCi) continue;          // separate rig — leave it to the game
                        uint64_t slotName = (uint64_t)(i + 1) << 32;
                        s_AddOrSwapSkeletalMesh(actor, slotName, s_em3fMeshKeys[i], partCi, meshData);
                        ++attached;
                    }
                }
            }
        }
    }
    logger::log_info("EM3F", "restored POSEABLE model: cEm=%p cls=%p +988=%d meshTableParts=%d",
                     cEm, cls, *reinterpret_cast<volatile uint8_t*>((char*)cEm + 988), attached);

    // (The per-node head-word dump that used to live here has served its purpose:
    // the part offset is node+24's delta from the archive base = the meshTable
    // OffsetKey. That mapping is now built into `cimap` above.)

    // Report what ACTUALLY landed per part, so one spawn tells us which links
    // resolved a mesh and which came back empty — no live poking needed.
    // Component map @ actor+688 (Data) / +696 (Num); 32B elems {FName@0, comp@8,
    // key@16}. USkeletalMeshComponent::SkeletalMesh lives at comp+0x430
    // (confirmed via USkeletalMeshComponent::SetSkeletalMesh's `LDR X8,[X0,#0x430]`).
    if (s_FWeakGet) {
        void* actor2 = s_FWeakGet((char*)cEm + 980);
        if (actor2) {
            void* mapData = *reinterpret_cast<void* const volatile*>((char*)actor2 + 688);
            int32_t mapNum = *reinterpret_cast<const int32_t volatile*>((char*)actor2 + 696);
            if (mapData && mapNum > 0 && mapNum < 32) {
                for (int i = 0; i < mapNum; ++i) {
                    char* e = (char*)mapData + 32 * i;
                    void* comp = *reinterpret_cast<void* const volatile*>(e + 8);
                    if (!comp) continue;
                    uint32_t k    = *reinterpret_cast<const uint32_t volatile*>(e + 16);
                    void*    mesh = *reinterpret_cast<void* const volatile*>((char*)comp + 0x430);
                    logger::log_info("EM3F", "  part key=%u comp=%p mesh=%p %s",
                                     k, comp, mesh, mesh ? "OK" : "<-- NO MESH (link dead)");
                }
            }
        }
    }

    // ── obj41 SUB-OBJECTS: em3f_008 + em3f_009 (THE TENTACLE) ──────────────
    // These are NOT parts of Saddler's cModel — they are separate cObj objects that
    // em3f's init already creates and the native code already animates every frame:
    //
    //   init:  *(cEm+1373) = SetObj41(cEm, 0);   // em3f_008, archive entry 8
    //          *(cEm+1381) = SetObj41(cEm, 1);   // em3f_009, archive entry 9
    //
    // SetObj41 runs a full cModel::modelInit on each (bin = archive + hdr[+48/+52],
    // tex = archive + hdr[+24/+28] = entries 2/3), so each gets its OWN initJoint and
    // therefore its own rig — which is exactly why they have 15/12 bones and could
    // never be master-posed onto the body's 54-bone hierarchy without deforming.
    // Placement is a hardcoded tie in sub_5FA35BC via obj+1032:
    //   obj41 #0 -> 36  : MTXConcat onto parent bone 36's matrix
    //   obj41 #1 -> -1  : follows the parent's root transform
    // and MotSetObj41 feeds each its own motion (archive +320 / +384 = entries 76/92).
    //
    // So the whole system works natively already, and they are invisible for the SAME
    // reason the body was: no UE actor.
    //
    // Use the port's PURPOSE-BUILT sub-object entry point — do NOT hand a cObj its own
    // BP actor. em38 (sub_5E74AF0) shows the sanctioned pattern for exactly this case:
    //     SetObj00(...); OyaSetObj00(obj, this, 0x3A);
    //     VR4CreateEmSubObject(archive + hdr[+324], this, obj);
    // VR4CreateEmSubObject(bin, parentEm, subObj) [0x5D9136C]:
    //     actor = FWeakGet(parentEm + 980);              // the PARENT's actor
    //     key   = actor->vtable[1584](actor, bin, parentEm);   // meshload on the PARENT
    //     cModel::VR4ModelInit(subObj, key, actor->meshData@+560);
    // and that VR4ModelInit overload [0x5F83668] spawns the sub-object's actor from
    // AVR4PoseableModel::GetPrivateStaticClass() — the PLAIN ENGINE CLASS.
    //
    // That distinction is the whole bug in the previous attempt: passing
    // EmModelClassLookUp(cEm) (= the EM3F_Poseable_BP Blueprint, whose tick logic
    // expects a real cEm) to VR4PoseableModelInit and SetBio4Model'ing it onto a cObj
    // corrupted state far away — the pPL player global went NULL (killing SndWatcher,
    // which derefs it unguarded) plus a RenderThread FMeshBatch::Add crash.
    // Sub-objects get the plain AVR4PoseableModel; only cEm gets the BP class.
    if (s_VR4CreateEmSubObject) {
        struct Obj41 { uint32_t emOff; uint32_t entry; const char* what; };
        static const Obj41 kObj41[2] = {
            { 1373, 8, "em3f_008 (plaga, tied to bone 36)" },
            { 1381, 9, "em3f_009 (TENTACLE, follows root)" },
        };
        const volatile uint32_t* h = reinterpret_cast<const volatile uint32_t*>(archive);
        uint32_t count = h[0];
        for (int i = 0; i < 2 && count > 0 && count < 512; ++i) {
            if (kObj41[i].entry >= count) continue;
            // cEm+1373 / +1381 are UNALIGNED qwords — copy, don't deref.
            void* obj = nullptr;
            __builtin_memcpy(&obj, (char*)cEm + kObj41[i].emOff, sizeof(obj));
            if (!obj) continue;                                   // SetObj41 failed/not run
            if (*reinterpret_cast<volatile uint8_t*>((char*)obj + 988)) continue;  // has one
            uint32_t binOff = h[4 + kObj41[i].entry];
            if (!binOff || binOff >= 0x4000000u) continue;
            // Needs the PARENT's actor to already exist — VR4PoseableModelInit above.
            s_VR4CreateEmSubObject((char*)archive + binOff, cEm, obj);
            void* oactor = s_FWeakGet ? s_FWeakGet((char*)obj + 980) : nullptr;
            logger::log_info("EM3F", "obj41 sub-object: %s  obj=%p bin=+%u actor=%p %s",
                             kObj41[i].what, obj, binOff, oactor,
                             oactor ? "OK" : "<-- no actor (mesh key unresolved?)");
        }
    }
}

// ═══════════════════════════════════════════════════════════════════════
// CUT VILLAGER GANADOS (em ids 6/7/8/0xA/0xB/0xD/0x33/0x37) — REAL SPAWN FIX
// ═══════════════════════════════════════════════════════════════════════
// Engine defect, fully traced. `ArmEmCallProlog(id)` [0x617E62C] is
// `v1 = id-3; switch (v1)` and every prolog is ONE line, e.g.
//     void _prologEm09() { EmInitFunc = Em09Init; }     // EmInitFunc is a GLOBAL
// An id with no case hits `default:`, returns 0, and NEVER touches the global.
// `EmReadSearch` [0x617E904] then nulls only its CACHED copy
// (`if ((v39 & 1) == 0) v41 = nullptr;`) but leaves the global STALE and still
// returns the loaded archive; `cEmMgr::construct` only guards `if (!result)`.
// => it calls the PREVIOUS enemy's init. When that was a Pl11-family sub-char
// (Ashley/Luis, ids 3/5/12), Pl11Init -> cSubAshley::modelSet ran over ganado
// data -> cModInfoMgr::create's `*a2 = (int64)a2 + *a2` fixup -> ~0xaf..15ec ->
// cModel::initJoint+144 -> SIGSEGV (tombstones 27/30). Guarding modelInit does
// NOT help (tombstone_30 has the guard in the stack and the game still died):
// by then the wrong function is already running on the wrong data.
//
// THESE IDS ARE VILLAGER GANADOS AND THEIR ARCHIVE MAPPING WAS ALWAYS CORRECT.
// EmFileTbl (RVA 0xA4672CC, 8B stride {u16 dasIdx, u16 relIdx, u16, u16}) maps
// ids 0x06-0x0B/0x0D/0x10/0x33/0x37 -> idx 24 = "em/em10.das". That is NOT a
// placeholder: they are variants that SHARE the ganado archive. Proof from
// EnemyFixes_P.pak — em07/em08/em09/em10_meshTable are all 132 rows and
// IDENTICAL (same keys 1900896/3921440/4007616..., same em1000/em1001/em10rh00
// meshes), and the pak ships Em07_Poseable/Em08_Poseable under Ganado/Villager.
// (Do NOT repoint EmFileTbl[7] at pl07.das: pl07 is a SEPARATE cutscene cop with
// its own Player/pl07_Police_MeshTable and an 11-entry archive. Forcing id 7
// there needs Ashley's layout and dies in EspDataLoad/setHand.)
//
// So the ONLY missing piece is the prolog. Ids 9 (_prologEm09) and 0x10
// (_prologEm10set) use the SAME em10.das and work — same archive == same layout,
// so a cut id can take the same init and gets REAL ganado AI for free.
// Pure DATA patch, no hook:
//   jpt_617E658 (RVA 0x4326B50, .rodata byte table): BR = loc_617E65C + jpt[id-3]*4
//   jpt[id-3] = jpt[6]   (id 9 -> _prologEm09, byte 0x04)
//
// NEVER HOOK ArmEmCallProlog: its body is `ADRL X9, jpt / ADR X10, case0 /
// LDRB W11,[X9,X8] / BR X10`; the trampoline relocates those PC-relative ops ->
// X9 wrong -> BR jumps into the stack (tombstone_02: SEGV_ACCERR, pc==lr==fault,
// single [anon:stack_and_tls] frame) — and it fires on EVERY enemy load.
static const uint32_t kEmFileTblRva = 0xA4672CC;
static const uint32_t kJptRva       = 0x4326B50;  // jpt_617E658
static const int      kJptIdx_id9   = 6;          // id 9 -> _prologEm09 (byte 0x04)
// Cut ids that map to em10.das but have no prolog. (id 9 = _prologEm09 and
// id 0x10 = _prologEm10set already work — deliberately not touched.)
static const uint8_t  kCutVillagerIds[] = { 0x06, 0x07, 0x08, 0x0A, 0x0B, 0x0D, 0x33, 0x37 };

// Write through a possibly read-only page (.rodata / .data.rel.ro). Leaves it RW.
static void patch_ro(void* addr, const void* src, size_t n) {
    if (!addr || !n) return;
    long ps = sysconf(_SC_PAGESIZE);
    if (ps <= 0) ps = 4096;
    uintptr_t a     = reinterpret_cast<uintptr_t>(addr);
    uintptr_t first = a & ~(uintptr_t)(ps - 1);
    uintptr_t last  = (a + n - 1) & ~(uintptr_t)(ps - 1);
    mprotect(reinterpret_cast<void*>(first), (size_t)(last - first + ps),
             PROT_READ | PROT_WRITE);
    __builtin_memcpy(addr, src, n);
}

// Is `id` an em the engine can actually construct?
//
// cEmMgr::construct [0x5D90288] guards the ARCHIVE but not the INIT POINTER:
//     BL   EmReadSearch ; STR X0,[X19,#0x460] ; CBZ X0, ret   <- archive checked
//     LDR  X8,[X8]      ; BLR X8                              <- EmInitFunc, UNCHECKED
// EmInitFunc is a global that only ArmEmCallProlog's per-id case sets. An id with
// no case leaves it at whatever the last enemy stored — or NULL if nothing has
// spawned yet, which is a straight `BLR 0` (tombstone: pc=0, "null pointer
// dereference"). So spawning an unimplemented id either runs the WRONG init over
// the wrong archive or jumps to zero. Neither is survivable and no guard helps,
// because by then the wrong function is already running.
//
// The jump table IS the ground truth for "does this id have an init", so ask it
// instead of maintaining a hand-written list that will rot:
//     supported  <=>  0 <= id-3 <= 0x4C  &&  jpt[id-3] != <the default case byte>
// Per IDA the default cases are ids 6-8,10,11,13,51,55,75,78 — we wire the first
// eight to _prologEm09 (they share em10.das with id 9), which leaves 75/78
// (em4b.das / em4e.das = the vehicles + Houdai cannon) genuinely unimplemented.
bool is_em_id_supported(uint32_t id) {
    uintptr_t base = symbols::lib_base();
    if (!base) return true;                 // can't tell — don't block the caller
    int idx = static_cast<int>(id) - 3;
    if (idx < 0 || idx > 0x4C) return false;   // outside the switch => default
    const uint8_t* jpt = reinterpret_cast<const uint8_t*>(base + kJptRva);
    // The default's byte = (def_617E658 - loc_617E65C)/4 = (0x617E864-0x617E65C)/4.
    // Derive it rather than trusting a constant, so a game update can't silently
    // turn this into "everything is supported".
    static const uint8_t kDefaultByte = (uint8_t)((0x617E864u - 0x617E65Cu) / 4u);  // 0x82
    return jpt[idx] != kDefaultByte;
}

bool install_cut_villager_fix() {
    uintptr_t base = symbols::lib_base();
    if (!base) {
        logger::log_error("CUTEM", "lib_base unavailable — cut-villager fix skipped");
        return false;
    }
    const volatile uint16_t* emft = reinterpret_cast<const volatile uint16_t*>(base + kEmFileTblRva);
    uint8_t* jpt  = reinterpret_cast<uint8_t*>(base + kJptRva);
    uint8_t  want = jpt[kJptIdx_id9];     // id 9's case byte -> _prologEm09
    uint16_t das9 = emft[(9 * 8) / 2];    // id 9's file idx (24 = em10.das) = the family marker
    int done = 0, total = (int)sizeof(kCutVillagerIds);
    for (int i = 0; i < total; ++i) {
        uint8_t id = kCutVillagerIds[i];
        // Only touch ids that genuinely share id 9's archive — never guess.
        uint16_t das = emft[(id * 8) / 2];
        if (das != das9) {
            logger::log_warn("CUTEM", "em id 0x%02X -> file idx %u, not id 9's %u — skipped (different archive)",
                             id, das, das9);
            continue;
        }
        int idx = (int)id - 3;            // jump-table index
        if (idx < 0 || idx > 0x4C) continue;
        if (jpt[idx] == want) { ++done; continue; }
        uint8_t old = jpt[idx];
        patch_ro(&jpt[idx], &want, 1);
        logger::log_info("CUTEM", "em id 0x%02X: prolog 0x%02X (none) -> 0x%02X (_prologEm09) — shares em10.das with id 9",
                         id, old, jpt[idx]);
        ++done;
    }
    logger::log_info("CUTEM", "cut villager ganados wired to the id-9 ganado init: %d/%d (real AI; no stale EmInitFunc)",
                     done, total);
    return done > 0;
}

// ═══════════════════════════════════════════════════════════════════════
// DUAL-FIRE ARM — pure C++, because TryFire is a HOT function
// ═══════════════════════════════════════════════════════════════════════
// RE4 has ONE global "armed weapon". AVR4GamePlayerGun::TryFire only fires the
// gun if it IS the armed one at that instant, so with two guns held only one
// ever fires. The fix is to arm THIS gun inside its OWN TryFire, right before
// the fire-check — TryFire(A) arms A then fires A, TryFire(B) arms B then fires
// B, both in the same frame.
//
// That logic used to live in a LUA CALLBACK on TryFire. That is the one thing we
// know we must never do: TryFire runs on the game thread on every trigger pull
// (continuously with rapid-fire, and once per gun with dual-wield), so the
// callback raced the shared lua_State against the mod loop and the bridge
// thread. The result was heap and stack corruption that surfaced far away and
// looked like innocent engine code -- observed as FMallocBinned2 dying in
// IncrementalPurgeGarbage while freeing an FString, and as a RET into a smashed
// return address (pc=lr=1). Same class of bug as the ScoreControl hot-hook.
//
// The work is trivially expressible in C, so it belongs in C: read the gun's
// weapon-no, look up its cItem, arm it, call the original. No Lua, no lock, no
// allocation, nothing that can race. This mirrors the game's OWN code at the tail
// of TryFire (cItemMgr::ArmSearchWeaponNo(&ItemMgr, gun[3360]) -> cItemMgr::arm),
// which is why it is safe to do from here.
//
// Addresses come from Lua (Resolve() already handles symbol + fallback there);
// only the hot path lives here.
static std::atomic<bool> s_dualfire_on{true};
static uintptr_t         s_df_itemmgr = 0;
static uint32_t          s_df_wno_off = 3360;

using DfArmSearchFn = void*    (*)(void*, uint8_t);   // cItemMgr::ArmSearchWeaponNo
using DfArmFn       = uint64_t (*)(void*, void*);     // cItemMgr::arm
using DfTryFireFn   = uint64_t (*)(uint64_t);         // AVR4GamePlayerGun::TryFire

static DfArmSearchFn s_df_search = nullptr;
static DfArmFn       s_df_arm    = nullptr;
static DfTryFireFn   s_df_orig   = nullptr;

static uint64_t df_tryfire(uint64_t self) {
    if (s_dualfire_on.load(std::memory_order_relaxed) && self &&
        s_df_search && s_df_arm && s_df_itemmgr)
    {
        // Fresh lookup every call — a dropped/re-picked weapon must never leave a
        // stale cItem to arm.
        uint8_t wno = *reinterpret_cast<volatile uint8_t*>(self + s_df_wno_off);
        if (wno) {
            void* item = s_df_search(reinterpret_cast<void*>(s_df_itemmgr), wno);
            if (item) s_df_arm(reinterpret_cast<void*>(s_df_itemmgr), item);
        }
    }
    return s_df_orig(self);
}

bool install_dualfire_arm(uintptr_t tryfire, uintptr_t itemmgr,
                          uintptr_t armsearch, uintptr_t armfn, uint32_t wno_off) {
    if (!tryfire || !itemmgr || !armsearch || !armfn) {
        logger::log_error("DUALFIRE", "install: null address (tryfire=0x%lX itemmgr=0x%lX "
                                      "search=0x%lX arm=0x%lX) — not installed",
                          (unsigned long)tryfire, (unsigned long)itemmgr,
                          (unsigned long)armsearch, (unsigned long)armfn);
        return false;
    }
    if (s_df_orig) {          // idempotent: a mod reload must not stack hooks
        s_df_itemmgr = itemmgr;
        s_df_wno_off = wno_off ? wno_off : 3360;
        s_df_search  = reinterpret_cast<DfArmSearchFn>(armsearch);
        s_df_arm     = reinterpret_cast<DfArmFn>(armfn);
        logger::log_info("DUALFIRE", "already installed — refreshed addresses only");
        return true;
    }
    s_df_itemmgr = itemmgr;
    s_df_wno_off = wno_off ? wno_off : 3360;
    s_df_search  = reinterpret_cast<DfArmSearchFn>(armsearch);
    s_df_arm     = reinterpret_cast<DfArmFn>(armfn);

    if (DobbyHook(reinterpret_cast<void*>(tryfire),
                  reinterpret_cast<dobby_dummy_func_t>(df_tryfire),
                  reinterpret_cast<dobby_dummy_func_t*>(&s_df_orig)) != RT_SUCCESS) {
        s_df_orig = nullptr;
        logger::log_error("DUALFIRE", "DobbyHook failed at 0x%lX", (unsigned long)tryfire);
        return false;
    }
    logger::log_info("DUALFIRE", "pure-C++ TryFire arm installed @0x%lX (itemMgr=0x%lX wnoOff=%u) "
                                 "— no Lua on the trigger path",
                     (unsigned long)tryfire, (unsigned long)itemmgr, s_df_wno_off);
    return true;
}

void set_dualfire_enabled(bool on) {
    s_dualfire_on.store(on, std::memory_order_relaxed);
    logger::log_info("DUALFIRE", "%s", on ? "enabled" : "disabled");
}

bool is_dualfire_enabled() { return s_dualfire_on.load(std::memory_order_relaxed); }

// ═══════════════════════════════════════════════════════════════════════
// em32 SUB-OBJECT NULL GUARD — the "cut enemy explodes on spawn" crash
// ═══════════════════════════════════════════════════════════════════════
// sub_5E49AA0 (em32's init, reached from cEm32::move) builds two sub-object
// models with SetObj00 and hands each to VR4CreateEmSubObject. SetObj00 returns
// NULL whenever cModel::modelInit can't find the model in the archive — which is
// exactly what happens for cut content, whose sub-object data was never shipped.
//
// The game checks for that NULL and then dereferences it anyway, four
// instructions later:
//     5e4a31c  BL   SetObj00
//     5e4a320  STR  X0, [X25,#0xA88]     ; may be NULL
//     5e4a324  CBZ  X0, loc_5E4A33C      ; ...checked here...
//     5e4a36c  LDR  X2, [X25,#0xA88]     ; ...reloaded...
//     5e4a374  LDR  X8, [X2,#0x180]      ; ...and derefed. SIGSEGV, fault 0x180.
// The first site (0x5e4a358) is worse: one path literally does MOV X2, XZR and
// falls straight into the same load. Retail never spawns em32, so it never fired.
//
// The joke is that the callee never wanted the value:
//     VR4CreateEmSubObject(archive, cEm *a2, cModel *a3) { if (a2) if (a3) {...} }
// It null-checks both pointers and returns. The crash happens purely while
// COMPUTING AN ARGUMENT THAT WOULD HAVE BEEN THROWN AWAY. So we don't need to
// skip the call — we need the two loads not to fault, and the callee will opt out
// on its own.
//
// Both loads are fed a scratch buffer that points at itself (+0x180 -> self), so
// LDR X8,[X2,#0x180] yields the buffer and LDR X0,[X8,#0x18] yields 0. X8 then
// doubles as the "we substituted" flag for the second instrument, which zeroes X1
// (the cEm) — that is what makes VR4CreateEmSubObject bail at its very first `if`.
// Nothing is written, no actor is spawned, and X0's return is discarded by the
// caller anyway. When the pointer is NOT null, every handler is a no-op, so the
// normal path keeps its exact original behaviour.
//
// Checked all 107 VR4CreateEmSubObject call sites: the other 105 take X0 from the
// cEm's own archive (LDR X8,[X19,#0x460] / ADD X0,X9,X8) and never dereference the
// cModel, so a NULL model is already harmless there. sub_5E49AA0 is the only
// function that sources X0 from the model itself — hence the only one that can
// fault. Two sites, four instruments, whole class of cut-content AI covered.
static const uintptr_t kEm32Guard[][2] = {   // { LDR Xd,[Xn,#0x180] , LDR X0,[Xd,#0x18] }
    { 0x5E4A358, 0x5E4A364 },                // sub-object 1 (cEm+0xA80) — MOV X1,X19 sits between
    { 0x5E4A374, 0x5E4A378 },                // sub-object 2 (cEm+0xA88) — the observed crash
};

// +0x180 must land inside the buffer and point back at it; +0x18 must read 0.
alignas(16) static uint8_t g_em32_null_model[0x400];

static bool em32_guard_is_ldr_x_imm(uint32_t w, int* rt, int* rn, uint32_t* off) {
    if ((w & 0xFFC00000u) != 0xF9400000u) return false;   // LDR Xt,[Xn,#imm] unsigned
    *rt  = (int)(w & 0x1F);
    *rn  = (int)((w >> 5) & 0x1F);
    *off = ((w >> 10) & 0xFFF) * 8u;
    return true;
}

static void em32_sub_null_to_dummy(void* addr, DobbyRegisterContext* ctx) {
    (void)addr;
    // Only fires on a pointer that is already guaranteed to SIGSEGV one insn later.
    if (ctx->general.x[2] == 0)
        ctx->general.x[2] = reinterpret_cast<uint64_t>(g_em32_null_model);
}

static void em32_sub_disarm_call(void* addr, DobbyRegisterContext* ctx) {
    (void)addr;
    // X8 == our buffer <=> the load above was substituted. Zero the cEm so
    // VR4CreateEmSubObject returns at `if (a2)` without touching anything.
    if (ctx->general.x[8] == reinterpret_cast<uint64_t>(g_em32_null_model))
        ctx->general.x[1] = 0;
}

bool install_em32_subobject_guard() {
    uintptr_t base = symbols::lib_base();
    if (!base) {
        logger::log_error("EM32", "lib_base unavailable — sub-object null guard skipped");
        return false;
    }
    *reinterpret_cast<void**>(g_em32_null_model + 0x180) = g_em32_null_model;

    int done = 0;
    for (size_t i = 0; i < sizeof(kEm32Guard) / sizeof(kEm32Guard[0]); ++i) {
        uintptr_t ld180 = base + kEm32Guard[i][0];
        uintptr_t ld18  = base + kEm32Guard[i][1];

        // Verify the exact encodings before instrumenting. If a game update moves
        // this code, we must do nothing rather than corrupt an unrelated function.
        int rt1, rn1, rt2, rn2; uint32_t off1, off2;
        uint32_t w1 = *reinterpret_cast<const uint32_t*>(ld180);
        uint32_t w2 = *reinterpret_cast<const uint32_t*>(ld18);
        if (!em32_guard_is_ldr_x_imm(w1, &rt1, &rn1, &off1) || off1 != 0x180 || rn1 != 2) {
            logger::log_warn("EM32", "0x%lX is not `LDR Xd,[X2,#0x180]` (insn 0x%08X) — guard skipped",
                             (unsigned long)kEm32Guard[i][0], w1);
            continue;
        }
        if (!em32_guard_is_ldr_x_imm(w2, &rt2, &rn2, &off2) || off2 != 0x18 || rt2 != 0 || rn2 != rt1) {
            logger::log_warn("EM32", "0x%lX is not `LDR X0,[X%d,#0x18]` (insn 0x%08X) — guard skipped",
                             (unsigned long)kEm32Guard[i][1], rt1, w2);
            continue;
        }
        if (DobbyInstrument(reinterpret_cast<void*>(ld180), em32_sub_null_to_dummy) != RT_SUCCESS) {
            logger::log_warn("EM32", "DobbyInstrument failed at 0x%lX", (unsigned long)kEm32Guard[i][0]);
            continue;
        }
        if (DobbyInstrument(reinterpret_cast<void*>(ld18), em32_sub_disarm_call) != RT_SUCCESS) {
            logger::log_warn("EM32", "DobbyInstrument failed at 0x%lX — rolling back the pair",
                             (unsigned long)kEm32Guard[i][1]);
            DobbyDestroy(reinterpret_cast<void*>(ld180));
            continue;
        }
        logger::log_info("EM32", "sub-object %d guarded: 0x%lX (LDR X%d,[X2,#0x180]) + 0x%lX (LDR X0,[X%d,#0x18])",
                         (int)i + 1, (unsigned long)kEm32Guard[i][0], rt1,
                         (unsigned long)kEm32Guard[i][1], rt1);
        ++done;
    }
    logger::log_info("EM32", "em32 sub-object null guard: %d/2 sites — missing sub-object models "
                             "now skip instead of SIGSEGV", done);
    return done > 0;
}

// ═══════════════════════════════════════════════════════════════════════
// ENEMY POOL SIZE — lift the per-level cap on live enemies
// ═══════════════════════════════════════════════════════════════════════
// EmSetEvent [0x5EE9E8C] hands out cEm slots from a fixed pool and returns the
// `errEm` sentinel when every slot is busy — that IS the "hard limit of enemies
// allowed for each level" (EnemySpawner surfaces it as "Pool full or invalid
// emId"). The pool is the usual manager shape:
//     EmMgr @ 0xA54AB68 : +0 vtable, +8 pool base, +16 slot count, +20 stride
// so bumping the COUNT alone would walk the free-slot scan straight off the end
// of the allocation — corruption, not more enemies.
//
// cEmMgr::arrayAlloc(this, n) [0x5D90680] is the one place that sizes it, and it
// is perfectly self-consistent:
//     free(pool); pool = memAlloc(stride * n); count = n; memClear(pool, stride * n);
// so scaling its `n` argument scales the ALLOCATION and the COUNT together.
// A pre-hook rewriting x1 is therefore the whole fix — no reallocation dance, no
// stale pointers (it runs before any cEm exists), nothing to keep in sync.
// Its prologue is STP/STP/ADD/LDR — position-independent, so the trampoline is
// safe here (unlike ArmEmCallProlog, whose ADRL/ADR jump-table setup it broke).
//
// Cost is stride * (mult-1) extra bytes once per level load. The engine still
// enforces its own per-type AI/anim budgets, so this raises the ceiling; it does
// not promise 100 ganados will path or render well.
static uint32_t s_em_pool_mult = 1;

bool set_enemy_pool_multiplier(uint32_t mult) {
    if (mult < 1) mult = 1;
    if (mult > 16) mult = 16;          // sanity: stride*count must stay sane
    s_em_pool_mult = mult;
    void* fn = symbols::resolve("_ZN6cEmMgr10arrayAllocEj");
    if (!fn) {
        uintptr_t b = symbols::lib_base();
        if (!b) { logger::log_error("EMPOOL", "lib_base unavailable"); return false; }
        fn = reinterpret_cast<void*>(b + 0x5D90680);
    }
    // install_at dedupes by name, so re-calling this just updates the multiplier.
    HookId h = install_at(fn, "__em_pool_mult", [](NativeCallContext& ctx) {
        uint32_t n = static_cast<uint32_t>(ctx.x[1]);
        if (!n || s_em_pool_mult <= 1) return;
        uint64_t want = static_cast<uint64_t>(n) * s_em_pool_mult;
        if (want > 4096) want = 4096;  // absurd sizes are a bug, not a feature
        ctx.x[1] = want;
        logger::log_info("EMPOOL", "cEmMgr::arrayAlloc: %u -> %llu slots (x%u)",
                         n, (unsigned long long)want, s_em_pool_mult);
    }, nullptr);
    logger::log_info("EMPOOL", "enemy pool multiplier x%u : %s (takes effect on the next level load)",
                     s_em_pool_mult, h ? "armed" : "FAILED");
    return h != 0;
}

// ── Targeted safe-call guard ───────────────────────────────────────────────
// install_builtin_crash_guards() is SKIPPED on this title (guarding the render
// path black-screens VR), so guarding a single known-crashy function needs its
// own opt-in entry point. Installs a hook with NO callbacks: dispatch_full()
// then runs the original inside the sigsetjmp safe-call guard, so a SIGSEGV in
// it recovers and returns 0 instead of killing the game.
//
// Primary user: cModel::initJoint. Spawning the CUT police NPC (em07/PL07) goes
//   EmSetEvent → cEmMgr::construct → Pl11Init → cSubAshley::modelSet
//     → cModel::modelInit → cModel::initJoint   ← SIGSEGV
// initJoint+144 derefs joint/parts data that was never populated for the cut NPC:
//     v10 = **(_QWORD**)(*(this+0x180) + 0x18);
//     v11 = *(uint8*)(v10 + 1);        // ← fault (tombstone_27, 0x6fe1444c10)
// That chain is built by makePartsList INSIDE initJoint, so a pre-hook can't
// validate it up-front — routing the whole call through the guard is the fix.
HookId install_safe_call_guard(void* addr, const char* name) {
    if (!addr) {
        logger::log_error("NHOOK", "safe-call guard '%s': null addr", name ? name : "?");
        return 0;
    }
    const char* n = (name && *name) ? name : "unnamed";
    HookId id = install_at(addr, std::string("__guard_") + n, nullptr, nullptr);
    logger::log_info("NHOOK", "safe-call guard '%s' @0x%lX : %s",
                     n, (unsigned long)reinterpret_cast<uintptr_t>(addr),
                     id ? "installed (sigsetjmp active)" : "FAILED");
    return id;
}

void add_em3f_mesh_path_fix(uint32_t key, int32_t comparison_index) {
    const int cap = (int)(sizeof(s_em3fPathFixes) / sizeof(s_em3fPathFixes[0]));
    for (int i = 0; i < s_em3fPathFixCount; ++i) {          // update in place
        if (s_em3fPathFixes[i].key == key) {
            s_em3fPathFixes[i].fname_idx = comparison_index;
            logger::log_info("EM3F", "mesh path-fix updated: key=%u -> FName idx %d", key, comparison_index);
            return;
        }
    }
    if (s_em3fPathFixCount >= cap) {
        logger::log_warn("EM3F", "mesh path-fix table full (%d) — key=%u dropped", cap, key);
        return;
    }
    s_em3fPathFixes[s_em3fPathFixCount++] = { key, comparison_index };
    logger::log_info("EM3F", "mesh path-fix armed: key=%u -> FName idx %d (%d total)",
                     key, comparison_index, s_em3fPathFixCount);
}

HookId install_model_restore(void* move_addr) {
    if (!move_addr) {
        logger::log_error("EM3F", "model_restore: null move addr");
        return 0;
    }
    if (!s_EmModelClassLookUp)
        s_EmModelClassLookUp = reinterpret_cast<cEm_EmModelClassLookUp_t>(
            symbols::resolve("_ZN3cEm18EmModelClassLookUpEPKS_"));
    if (!s_VR4PoseableModelInit)
        s_VR4PoseableModelInit = reinterpret_cast<cModel_VR4PoseableModelInit_t>(
            symbols::resolve("_ZN6cModel20VR4PoseableModelInitEP6UClassPv"));
    if (!s_FWeakGet)
        s_FWeakGet = reinterpret_cast<FWeakObjectPtr_Get_t>(
            symbols::resolve("_ZNK14FWeakObjectPtr3GetEv"));
    if (!s_AddOrSwapSkeletalMesh)
        s_AddOrSwapSkeletalMesh = reinterpret_cast<AddOrSwapSkeletalMesh_t>(
            symbols::resolve("_ZN17AVR4PoseableModel21AddOrSwapSkeletalMeshE5FNamejPK10cModelInfoP12UVR4MeshData"));
    if (!s_TryCacheMap)
        s_TryCacheMap = reinterpret_cast<UVR4MeshData_TryCacheMap_t>(
            symbols::resolve("_ZN12UVR4MeshData11TryCacheMapEb"));
    if (!s_VR4CreateEmSubObject)
        s_VR4CreateEmSubObject = reinterpret_cast<VR4CreateEmSubObject_t>(
            symbols::resolve("_Z20VR4CreateEmSubObjectPvP3cEmP6cModel"));
    if (!s_ModInfoMgrCreate)
        s_ModInfoMgrCreate = reinterpret_cast<cModInfoMgr_create_t>(
            symbols::resolve("_ZN11cModInfoMgr6createEmm"));
    if (!s_addModel)
        s_addModel = reinterpret_cast<cModel_addModel_t>(
            symbols::resolve("_ZN6cModel8addModelEP10cModelInfo"));
    if (!s_ModInfoMgr) {
        // `ModInfoMgr` is a static object; the em3f init takes its address
        // (adrp 0xa3c2000 + ldr #0x8a8 -> GOT slot holding &ModInfoMgr @ 0xA578670).
        s_ModInfoMgr = symbols::resolve("ModInfoMgr");
        if (!s_ModInfoMgr) {
            uintptr_t b = symbols::lib_base();
            if (b) s_ModInfoMgr = reinterpret_cast<void*>(b + 0xA578670);
        }
    }
    if (!s_EmModelClassLookUp || !s_VR4PoseableModelInit) {
        logger::log_error("EM3F", "model_restore: unresolved EmModelClassLookUp=%p VR4PoseableModelInit=%p",
                          (void*)s_EmModelClassLookUp, (void*)s_VR4PoseableModelInit);
        return 0;
    }
    if (!s_FWeakGet || !s_AddOrSwapSkeletalMesh)
        logger::log_warn("EM3F", "model_restore: multi-part attach unavailable (FWeakGet=%p AddOrSwap=%p) — base only",
                         (void*)s_FWeakGet, (void*)s_AddOrSwapSkeletalMesh);
    HookId id = install_at(move_addr, "__model_restore",
                           model_restore_pre, nullptr, "ModelRestore");
    logger::log_info("EM3F", "model-restore hook @0x%lX : %s",
                     (unsigned long)reinterpret_cast<uintptr_t>(move_addr),
                     id ? "installed" : "FAILED");
    return id;
}

void install_builtin_crash_guards() {
    logger::log_info("NHOOK",
        "Installing %zu built-in crash guard(s)...",
        sizeof(s_crash_guards) / sizeof(s_crash_guards[0]));

    uintptr_t lib_base = symbols::lib_base();

    for (const auto& entry : s_crash_guards) {
        // Try dlsym first
        void* addr = symbols::resolve(entry.symbol);

        // Fallback to base + offset
        if (!addr && lib_base != 0 && entry.fallback_offset != 0) {
            addr = reinterpret_cast<void*>(lib_base + entry.fallback_offset);
            logger::log_warn("NHOOK",
                "Crash guard '%s': dlsym failed, using fallback offset 0x%lX → 0x%lX",
                entry.name, (unsigned long)entry.fallback_offset,
                (unsigned long)reinterpret_cast<uintptr_t>(addr));
        }

        if (!addr) {
            logger::log_error("NHOOK",
                "Crash guard '%s': FAILED — could not resolve address", entry.name);
            continue;
        }

        // Install hook with NO callbacks — purely for safe-call protection.
        // dispatch_full() will call the original inside the sigsetjmp guard.
        // If it crashes, siglongjmp recovers and returns 0/0.0.
        HookId id = install_at(addr, std::string("__guard_") + entry.name,
                               nullptr, nullptr);

        if (id != 0) {
            logger::log_info("NHOOK",
                "Crash guard '%s' installed at 0x%lX (hook id %lu) "
                "— sigsetjmp safe-call active",
                entry.name, (unsigned long)reinterpret_cast<uintptr_t>(addr),
                (unsigned long)id);
        } else {
            logger::log_error("NHOOK",
                "Crash guard '%s': Dobby hook FAILED at 0x%lX",
                entry.name, (unsigned long)reinterpret_cast<uintptr_t>(addr));
        }
    }

    logger::log_info("NHOOK", "Built-in crash guards installation complete");
}

} // namespace native_hooks
