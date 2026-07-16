#pragma once
// modloader/include/modloader/native_hooks.h
// Dobby-based native function hooks (for non-UFunction C++ functions)
// Resolved by symbol name with dlsym → phdr → pattern fallback

#include <string>
#include <functional>
#include <cstdint>
#include <vector>

namespace native_hooks {

using HookId = uint64_t;

// Pre-hook: called with the original arguments as raw registers
// ARM64 ABI: args in X0-X7 (integer/pointer), D0-D7 (float)
// Return true to BLOCK the original function call
struct NativeCallContext {
    uint64_t x[8];      // X0-X7
    double   d[8];      // D0-D7
    void*    original;  // pointer to original function
    bool     blocked;   // set to true to block original call
    uint64_t ret_x0;    // return value override (integer/pointer)
    double   ret_d0;    // return value override (float)
    bool     ret_override; // if true, use ret_x0/ret_d0 instead of calling original
};

using NativePreCallback  = std::function<void(NativeCallContext& ctx)>;
using NativePostCallback = std::function<void(NativeCallContext& ctx)>;

// Initialize the native hook subsystem
void init();

// Install a hook on a symbol by name (resolved dynamically)
// pre fires before original, post fires after
// Either can be nullptr
//
// `key` identifies the registrant so multiple mods can COEXIST on the same
// address (a callback CHAIN): re-registering with the SAME key REPLACES that
// registrant's callbacks (hot-reload safe); a NEW key APPENDS a callback that
// runs alongside the others. If `key` is empty it defaults to `symbol`/`name`.
// Chain order = registration order; pres run in order (any may set
// ctx.blocked), then the original (unless blocked), then posts in order.
HookId install(const std::string& symbol,
               NativePreCallback pre,
               NativePostCallback post,
               const std::string& key = "");

// Install a hook on a raw address (see install() for `key` semantics).
HookId install_at(void* addr, const std::string& name,
                  NativePreCallback pre,
                  NativePostCallback post,
                  const std::string& key = "");

// Remove a previously installed hook entirely (all chained callbacks).
void remove(HookId id);

// Remove just ONE registrant's callbacks from the chain at `addr` (by key),
// leaving other mods' hooks intact. Returns true if an entry was removed.
// The underlying Dobby hook stays installed as long as any entry remains.
bool remove_key(void* addr, const std::string& key);

// Remove EVERY chain entry whose key starts with `prefix` across ALL hooked
// addresses ("ModName:" removes all of one mod's native hooks). Trampolines
// stay installed (empty chain = pass-through to the original — safe while
// the game thread may be inside one). Returns the number of entries removed.
int remove_keys_with_prefix(const std::string& prefix);

// Check if a symbol has a hook installed
bool is_hooked(const std::string& symbol);

// Install built-in crash guards on known-crashy game functions.
// These are C++ hooks with no Lua callbacks — they exist solely
// to route the function through dispatch_full()'s sigsetjmp guard.
// If the original crashes (SIGSEGV on dangling pointer, null vtable),
// the safe-call guard recovers and the game continues.
void install_builtin_crash_guards();

// Install the RE4 cloth-bone sanitizer on PenClothSet(cModel*,CLOTH_INFO*,float).
// Pure-C++ pre-hook (safe on the game thread — no Lua callback to race the
// shared lua_State): before each call it rewrites cloth bone indices the model
// can't resolve to the 0xFF "skip" sentinel, so cut enemies (em3f/Saddler-Ada)
// ported with a shorter skeleton don't crash in getPartsPtr. No-op when the rig
// is complete. Returns the hook id (0 on failure).
HookId install_cloth_bone_sanitizer(void* addr);

// Install the cut-enemy model-load restore on a cEmXX::move (e.g. cEm3f::move
// @0x5EA2580). Pure-C++: on the tick after native modelInit built the model
// (cModel+384!=0) and while no UE model exists (cModel+988==0), it injects the
// missing VR4ModelInit(this, EmModelClassLookUp(this)) so cut enemies spawn a
// visible AVR4Model. Native register-passed pointers (keeps MTE tags intact).
// Self-guards on +988 → no-op for enemies that build their own UE model.
HookId install_model_restore(void* move_addr);

// em3f_meshTable ships WRONG MeshRef soft-paths for every plaga-sourced row
// (em3f_008 / em3f_009 / em3f_094 point at .../EM/em25_plaga/Geometry/<mesh>,
// but those assets are packed at .../BOSS/em30_Saddler/Geometry/<mesh>), so
// TryLoad returns null and they render nothing. Register the OffsetKey plus the
// FName comparison index of the CORRECT path (from Lua:
// FName(path):GetComparisonIndex()); model_restore repoints each cached MeshRef
// after TryCacheMap rebuilds it. Up to 8 fixes; re-registering a key updates it.
void add_em3f_mesh_path_fix(uint32_t key, int32_t comparison_index);

// Route ONE known-crashy game function through the sigsetjmp safe-call guard
// (hook with no callbacks). A SIGSEGV inside it recovers → returns 0 instead of
// killing the game. Needed because install_builtin_crash_guards() is skipped on
// this title (guarding the render path black-screens VR). Main user:
// cModel::initJoint, which faults when the cut police NPC (em07/PL07) spawns.
HookId install_safe_call_guard(void* addr, const char* name);
// Cut villager ganados (em ids 6/7/8/0xA/0xB/0xD/0x33/0x37): they share em10.das
// with id 9 but have no ArmEmCallProlog case, so EmInitFunc was left STALE and
// cEmMgr::construct ran the previous enemy's init over ganado data => crash.
// Patches the switch's jump table to give each the id-9 case (_prologEm09), so
// they spawn with the real ganado init + AI. Pure data patch, no hook.
bool install_cut_villager_fix();
// em32's init (sub_5E49AA0) null-checks SetObj00's result and then dereferences
// it anyway 4 instructions later — SIGSEGV, fault addr 0x180 — whenever a
// sub-object model is missing from the archive, i.e. for cut content. The callee
// (VR4CreateEmSubObject) null-checks both pointers and returns, so the crash is
// purely in COMPUTING AN ARGUMENT IT DISCARDS. Feeds the two loads a self-pointing
// scratch buffer and zeroes the cEm arg so the callee opts out at its first `if`.
// No-op whenever the pointer isn't null. The other 105 call sites take X0 from the
// cEm's archive and never deref the model, so they were never at risk.
bool install_em32_subobject_guard();
// Dual-fire: arm the gun inside its OWN AVR4GamePlayerGun::TryFire so both guns
// pass the "am I the armed weapon?" check and fire the same frame. MUST be pure
// C++: TryFire is HOT (every trigger pull, per gun, continuously under
// rapid-fire), and a Lua callback there races the shared lua_State against the
// mod loop + bridge thread => heap/stack corruption surfacing later as
// FMallocBinned2 dying in GC, or a RET into a smashed return address (pc=lr=1).
// Addresses are passed in from Lua (Resolve() handles symbol+fallback there);
// only the hot path lives in C++. Idempotent — a mod reload won't stack hooks.
bool install_dualfire_arm(uintptr_t tryfire, uintptr_t itemmgr,
                          uintptr_t armsearch, uintptr_t armfn, uint32_t wno_off);
void set_dualfire_enabled(bool on);
bool is_dualfire_enabled();
// True if em `id` has a real init. cEmMgr::construct calls the EmInitFunc global
// WITHOUT a null check, so an id with no ArmEmCallProlog case runs the previous
// enemy's init over the wrong archive — or jumps to NULL (pc=0). Ask the jump
// table so the list can't rot. Ids 75/78 (em4b/em4e = vehicles, Houdai) are
// genuinely unimplemented and must not be spawned.
bool is_em_id_supported(uint32_t id);
// Lift the per-level live-enemy cap. EmSetEvent returns errEm ("pool full") once
// the fixed cEm pool is exhausted; cEmMgr::arrayAlloc(n) sizes that pool as
// stride*n AND sets count=n, so scaling its argument scales both together.
// Takes effect on the next level load. mult is clamped to 1..16.
bool set_enemy_pool_multiplier(uint32_t mult);

// Get info about all installed hooks
struct HookInfo {
    HookId      id;
    std::string name;
    void*       address;
    uint64_t    call_count;
    bool        has_pre;
    bool        has_post;
};
std::vector<HookInfo> get_all_hooks();

} // namespace native_hooks
