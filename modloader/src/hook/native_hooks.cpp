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
#include "modloader/arch.h"
#include "modloader/symbols.h"
#include "modloader/logger.h"
#include "modloader/lua_ue4ss_globals.h"
#include "modloader/reflection_walker.h"
#include <dobby.h>
#include <dlfcn.h>
#include <cmath>
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
// Culprit attribution for crash_guard: which hook's original/install is
// executing on this thread. Points into a HookRecord's name (never freed) or
// a caller-owned string that outlives the guarded call. Read by the signal
// handler when filing a recovered crash.
thread_local const char* g_hook_ctx_name = nullptr;

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

// Circuit-breaker thresholds for the safe-call guard (see HookRecord::tripped).
// A handful of recoveries is a transient; dozens per second is a permanently
// broken function, and recovering it forever costs more than it saves.
static const uint32_t kGuardTripLimit = 8;   // faults before we stop calling it
static const uint32_t kGuardLogLimit  = 3;   // never log a fault per frame

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
    // ── Crash-guard circuit breaker ──────────────────────────────────────
    // A safe-call guard recovers a faulting original via siglongjmp. That is
    // fine for a one-shot fault — but several of these functions are called
    // from cEmXX::move EVERY FRAME, and a permanently broken enemy (its room
    // never loaded its model) faults every single frame. The guard then does
    // signal -> handler -> siglongjmp 60+ times a second and the game crawls:
    // we trade a crash for unplayable lag, which is not a fix.
    // So once an original has faulted `kGuardTripLimit` times we stop calling
    // it at all and return 0 immediately. The feature that function provided
    // stays off (a cut enemy loses its cloth/sub-object), the game keeps its
    // frame rate, and nothing faults again.
    std::atomic<uint32_t> fault_count{0};
    std::atomic<bool>     tripped{false};
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

// A hook callback runs UNTRUSTED code (Lua VM, mod C++, mislinked trampolines).
// If a callback violates the AArch64 ABI and fails to preserve a callee-saved
// register (x19-x28), the compiler — which assumes ABI compliance — would keep
// dispatch_full's own state (fsa pointer, rec, loop iterator) in those registers
// across the call and then use a corrupted value → crash (observed: a hook left
// the enemy index 0x6e in x25 → the return-value writeback stored to 0x6e).
// This barrier tells the compiler the callee-saved GP registers are clobbered
// by the preceding call, forcing it to spill/reload dispatch_full's state via
// the STACK instead of trusting a register a rogue callback may have smashed.
// Bulletproofs ALL hooks. NHOOK_CALLEE_SAVED_BARRIER() is defined per-arch in
// modloader/arch.h (x19-x28 on AArch64, r4-r11 on ARM32).

// ── Call the hooked original with the captured argument registers ───────
// AArch64 restores X0-X7 AND D0-D7 via asm — float args live in a separate
// register file (D0-D7) invisible to a C-typed call, so the register banks
// must be reloaded by hand. ARM32 on Android is *softfp*: every argument,
// float or integer, arrives in the core registers r0-r3, so a plain typed
// call restores them and the 64-bit return already carries an int/float/double
// result (in r0:r1). Factored into one place so the two call sites (off-thread
// and on-thread) share a single architecture switch.
static inline void call_original_with_regs(void *orig, const uint64_t *x_args,
                                           FloatSaveArea &fsa,
                                           uint64_t &ret_x0, double &ret_d0) {
#if defined(__arm__)
    // Android armeabi-v7a is softfp: args (incl. floats) are already in r0-r3,
    // so a plain typed call restores them; a double/float return comes back in
    // r0:r1 and is already carried by ret_x0.
    (void)fsa;
    using orig4_t = uint64_t (*)(uint32_t, uint32_t, uint32_t, uint32_t);
    ret_x0 = reinterpret_cast<orig4_t>(orig)(
        (uint32_t)x_args[0], (uint32_t)x_args[1],
        (uint32_t)x_args[2], (uint32_t)x_args[3]);
    ret_d0 = 0.0;
#else
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
#endif
}

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
        const char* saved_ctx = g_hook_ctx_name;
        sigjmp_buf saved_jmp;
        __builtin_memcpy(&saved_jmp, &g_hook_recovery_jmp, sizeof(sigjmp_buf));

        g_in_hook_original_call = 1;
        g_hook_ctx_name = rec->name.c_str();
        int crash_sig = sigsetjmp(g_hook_recovery_jmp, 1);

        if (crash_sig != 0) {
            __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
            g_in_hook_original_call = saved_in_call;
            g_hook_ctx_name = saved_ctx;
            // Silent recovery — don't log every frame (this path is high-frequency).
            // Still count it: an original that faults forever must trip the breaker
            // here too, or we pay a signal per call for the rest of the session.
            uint32_t n = rec->fault_count.fetch_add(1, std::memory_order_relaxed) + 1;
            if (n >= kGuardTripLimit && !rec->tripped.exchange(true, std::memory_order_relaxed)) {
                logger::log_warn("NHOOK",
                    "'%s' faulted %u times off-thread — CIRCUIT BREAKER TRIPPED "
                    "(no longer called; returns 0)", rec->name.c_str(), n);
            }
            return 0;
        }

        // Known-bad: don't call it, don't fault, don't signal.
        if (rec->tripped.load(std::memory_order_relaxed)) {
            __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
            g_in_hook_original_call = saved_in_call;
            g_hook_ctx_name = saved_ctx;
            return 0;
        }

        void* orig = rec->original;
        uint64_t ret_x0 = 0;
        double ret_d0 = 0.0;
        uint64_t x_args[8] = {x0, x1, x2, x3, x4, x5, x6, x7};

        call_original_with_regs(orig, x_args, fsa, ret_x0, ret_d0);

        __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
        g_in_hook_original_call = saved_in_call;
        g_hook_ctx_name = saved_ctx;
        fsa.d[0] = ret_d0;
        return ret_x0;
    }

    NativeCallContext ctx;
    memset(&ctx, 0, sizeof(ctx));
    ctx.x[0] = x0; ctx.x[1] = x1; ctx.x[2] = x2; ctx.x[3] = x3;
    ctx.x[4] = x4; ctx.x[5] = x5; ctx.x[6] = x6; ctx.x[7] = x7;

    // Keep the slot on the STACK across the callbacks. A hook callback that
    // violates the AArch64 ABI (doesn't preserve a callee-saved register — seen
    // with a mislinked Lua/native trampoline that left the enemy index 0x6e in
    // x25) would otherwise smash the register holding &fsa, and the return-value
    // writeback below (`str d0,[x25]`) would store to that garbage address →
    // SIGSEGV. Reloading `safe_slot` (volatile → from the stack) forces the
    // writeback to recompute the save-area address instead of trusting a register.
    volatile int safe_slot = slot;

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
            NHOOK_CALLEE_SAVED_BARRIER();   // a rogue callback can't corrupt our regs
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
        const char* saved_ctx = g_hook_ctx_name;
        sigjmp_buf saved_jmp;
        __builtin_memcpy(&saved_jmp, &g_hook_recovery_jmp, sizeof(sigjmp_buf));

        g_in_hook_original_call = 1;
        g_hook_ctx_name = rec->name.c_str();
        int crash_sig = sigsetjmp(g_hook_recovery_jmp, 1);

        if (crash_sig != 0) {
            // ── CRASH RECOVERED ──────────────────────────────────────
            __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
            g_in_hook_original_call = saved_in_call;
            g_hook_ctx_name = saved_ctx;

            // Count it, and TRIP after a few. Several guarded functions are
            // called from cEmXX::move every frame; a permanently broken enemy
            // faults every frame, so recovering forever means signal + handler
            // + siglongjmp 60x/sec — the crash becomes unplayable lag instead.
            // Trip and the function is simply never called again.
            uint32_t n = rec->fault_count.fetch_add(1, std::memory_order_relaxed) + 1;

            // Log only the first few. This used to log_error EVERY recovery —
            // a file write per frame, which was itself a large part of the lag.
            if (n <= kGuardLogLimit) {
                logger::log_error("NHOOK",
                    "SAFE-CALL RECOVERY: Hook '%s' original crashed (signal %d) — "
                    "returning safe defaults (0/0.0). Game continues. [fault %u/%u]",
                    rec->name.c_str(), crash_sig, n, kGuardTripLimit);
            }
            if (n >= kGuardTripLimit && !rec->tripped.exchange(true, std::memory_order_relaxed)) {
                logger::log_warn("NHOOK",
                    "'%s' faulted %u times — CIRCUIT BREAKER TRIPPED: it will no longer be "
                    "called (returns 0). Whatever it provided stays off, but the frame rate "
                    "is back. Usually means an enemy whose model this room never loaded.",
                    rec->name.c_str(), n);
            }
            ctx.ret_x0 = 0;
            ctx.ret_d0 = 0.0;
        } else if (rec->tripped.load(std::memory_order_relaxed)) {
            // Already known-bad: skip the call entirely — no fault, no signal.
            __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
            g_in_hook_original_call = saved_in_call;
            g_hook_ctx_name = saved_ctx;
            ctx.ret_x0 = 0;
            ctx.ret_d0 = 0.0;
        } else {
            // ── NORMAL PATH — call original with full register restore ──
            uint64_t ret_x0 = 0;
            double ret_d0 = 0.0;
            uint64_t* x_args = ctx.x;

            call_original_with_regs(orig, x_args, fsa, ret_x0, ret_d0);

            __builtin_memcpy(&g_hook_recovery_jmp, &saved_jmp, sizeof(sigjmp_buf));
            g_in_hook_original_call = saved_in_call;
            g_hook_ctx_name = saved_ctx;
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
            NHOOK_CALLEE_SAVED_BARRIER();   // a rogue callback can't corrupt our regs
        }
    }

    // Write D0 return value back to save area — asm thunk will restore D0 from
    // here. Recompute the address from the stack-held slot (NOT the cached &fsa
    // register a rogue callback may have clobbered — see safe_slot above).
    s_float_save[safe_slot].d[0] = ctx.ret_d0;

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

#if defined(__arm__)
// Android armeabi-v7a is softfp: all call arguments — integer AND float —
// arrive in the four core registers r0-r3 (spilling to the stack beyond that),
// so there is no separate float register bank to capture. The thunk is a plain
// passthrough to dispatch; a 64-bit / float / double return propagates back
// through r0:r1 as the uint64_t return value.
#define DEFINE_THUNK(N) \
    __attribute__((noinline)) \
    static uint64_t thunk_##N(uint32_t a0, uint32_t a1, uint32_t a2, uint32_t a3) { \
        return dispatch_full(N, a0, a1, a2, a3, 0, 0, 0, 0); \
    }
#else
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
#endif

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

#if defined(__arm__) // softfp: four core-register args
using ThunkFn = uint64_t(*)(uint32_t, uint32_t, uint32_t, uint32_t);
#else
using ThunkFn = uint64_t(*)(uint64_t, uint64_t, uint64_t, uint64_t,
                           uint64_t, uint64_t, uint64_t, uint64_t);
#endif

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
    g_hook_ctx_name = rec->name.c_str();
    int install_crash_sig = sigsetjmp(g_hook_install_jmp, 1);

    if (install_crash_sig != 0) {
        // ── CRASH RECOVERED DURING HOOK INSTALLATION ─────────────────
        g_in_hook_install = 0;
        g_hook_ctx_name = nullptr;
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
    g_hook_ctx_name = nullptr;

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

// ── Crash-guard attribution helpers ────────────────────────────────────────
// Called from crash_guard::drain() (normal context) to answer "is this crash
// PC at/near something WE modified?" and "which mod owns that modification?"

// Extract the owning mod from a hook's chain keys ("ModName:hookname" form;
// infrastructure keys like "__guard_x" have no owner).
static bool owner_mod_from_chain(HookRecord* rec, char* mod_out, size_t mod_sz) {
    HookChain* chain = rec->chain.load();
    if (!chain) return false;
    for (const HookEntry& he : *chain) {
        size_t colon = he.key.find(':');
        if (colon != std::string::npos && colon > 0 && he.key[0] != '_') {
            snprintf(mod_out, mod_sz, "%.*s", (int)colon, he.key.c_str());
            return true;
        }
    }
    return false;
}

// Find the hook whose entry patch or trampoline the PC belongs to (or the
// nearest entry shortly below it). Returns the record, or null.
static HookRecord* site_hook_for_pc(uintptr_t pc, const char** how, uintptr_t* dist) {
    HookRecord* best = nullptr;
    uintptr_t best_dist = UINTPTR_MAX;
    const char* best_how = "";
    for (auto& pr : s_addr_to_hook) {
        uintptr_t entry = reinterpret_cast<uintptr_t>(pr.first);
        HookRecord* rec = pr.second;
        if (pc >= entry && pc < entry + 16) {              // inside Dobby's entry patch
            *how = "inside Dobby entry patch of"; *dist = pc - entry; return rec;
        }
        uintptr_t tramp = reinterpret_cast<uintptr_t>(rec->original);
        if (tramp && pc >= tramp && pc < tramp + 64) {     // inside relocated-prologue trampoline
            *how = "inside trampoline of"; *dist = pc - tramp; return rec;
        }
        if (pc >= entry && pc - entry < 0x2000 && pc - entry < best_dist) {
            best = rec; best_dist = pc - entry; best_how = "within the function hooked by";
        }
    }
    if (best) { *how = best_how; *dist = best_dist; }
    return best;
}

bool describe_site(uintptr_t pc, char* out, size_t out_sz) {
    std::lock_guard<std::mutex> lock(s_mutex);
    const char* how = ""; uintptr_t dist = 0;
    HookRecord* rec = site_hook_for_pc(pc, &how, &dist);
    if (!rec) return false;
    char mod[64];
    if (owner_mod_from_chain(rec, mod, sizeof(mod)))
        snprintf(out, out_sz, "pc %s hook '%s' (+0x%lx, mod '%s')",
                 how, rec->name.c_str(), (unsigned long)dist, mod);
    else
        snprintf(out, out_sz, "pc %s hook '%s' (+0x%lx)",
                 how, rec->name.c_str(), (unsigned long)dist);
    return true;
}

bool site_owner_mod(uintptr_t pc, char* mod_out, size_t mod_sz) {
    std::lock_guard<std::mutex> lock(s_mutex);
    const char* how = ""; uintptr_t dist = 0;
    HookRecord* rec = site_hook_for_pc(pc, &how, &dist);
    return rec && owner_mod_from_chain(rec, mod_out, mod_sz);
}

bool hook_owner_mod_by_name(const char* hook_name, char* mod_out, size_t mod_sz) {
    if (!hook_name || !hook_name[0]) return false;
    std::lock_guard<std::mutex> lock(s_mutex);
    for (auto& pr : s_hooks) {
        if (pr.second->name == hook_name)
            return owner_mod_from_chain(pr.second, mod_out, mod_sz);
    }
    return false;
}

} // namespace native_hooks
