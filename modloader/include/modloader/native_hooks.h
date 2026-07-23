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
// ACTIVE as of crash guard v2 (crash_guard.cpp): the callback-less hook runs the
// original under dispatch_full's sigsetjmp, and crash_guard::try_recover files
// the fault to modloader_recovered.log then siglongjmps back — the game keeps
// running and this returns 0. (The v1 recovery was removed for hiding crashes;
// v2 restores it but every suppressed fault is logged and toggleable.) For the
// whole-process unguarded-null family, SetCrashGuardGlobalMode covers it without
// a per-function hook, and a per-frame source fix (byte patch / DobbyInstrument,
// as install_laser_sight_fix does) still beats recovering the same fault 60x/sec.
HookId install_safe_call_guard(void* addr, const char* name);
// Cut villager ganados (em ids 6/7/8/0xA/0xB/0xD/0x33/0x37): they share em10.das
// with id 9 but have no ArmEmCallProlog case, so EmInitFunc was left STALE and
// cEmMgr::construct ran the previous enemy's init over ganado data => crash.
// Patches the switch's jump table to give each the id-9 case (_prologEm09), so
// they spawn with the real ganado init + AI. Pure data patch, no hook.
bool install_cut_villager_fix();
// em32 = U3. Its init (sub_5E49AA0) null-checks SetObj00's result and then
// dereferences it anyway — fault addr 0x180 — whenever a sub-object model is
// missing, which is normal outside U3's own level.
//
// Fixed WITHOUT a crash guard, on purpose: every line after the faulting call is
// YarareInit/YarareAdd — U3's damage regions — so a guard that siglongjmps out is
// exactly what left U3 unkillable. Both sites let the init CONTINUE instead:
//   site 1 (cEm+0xA80): the NULL path's `MOV X2,XZR` (0x5E4A354) is byte-patched
//                       to `B 0x5E4A36C`, branching over its call. One
//                       instruction, no hook, nothing to overlap.
//   site 2 (cEm+0xA88): ONE DobbyInstrument at 0x5E4A374 — no CBZ exists to
//                       hijack and a byte patch needs 4 ops in 3 slots. It points
//                       a NULL X2 at a self-referencing scratch buffer and zeroes
//                       X1, so VR4CreateEmSubObject returns at its first `if (a2)`.
//
// A SINGLE instrument is safe — Dobby relocates what it overwrites. The earlier
// disaster was FOUR instruments with two 4 BYTES APART, shredding each other and
// turning a clean `fault 0x180` into `pc = 0x512c662204`. Never place two inline
// hooks within 16 bytes, and never hook this function twice (install_u3_killable_fix
// already owns its entry — a second DobbyHook there fails with status=-1).
bool install_em32_subobject_guard();
// Add the null-`this` check the game forgot. A whole family of RE4 crashes is one
// bug per enemy: a NULL sub-object/model (routine for cut/unsupported content the
// room never loaded) dereferenced with no check, dying as NULL+fieldOffset —
// cObjChain::setChain 0x438, em32 init 0x180, cEm2d::setReset 0x0d, all reached
// via EmSetFromList2 -> cEmXX::move. Hooks `addr` at its ENTRY and returns 0 when
// x0 is NULL, so the enemy loses that feature instead of the game dying.
// ENTRY hooks only — two inline hooks <16 bytes apart shred each other (see the
// em32 note above). Max 8 guards; forwards x0-x7, leaves v0-v7 alone.
// field_off: -1 = test `this` (x0) itself; >=0 = test the pointer FIELD at
// x0+field_off, for functions where `this` is valid but an inner pointer is
// NULL (cModel::setParent: LDR X8,[X0,#0x108] / STR X1,[X8,#0x78] -> 0x78).
bool install_null_this_guard(uintptr_t addr, const char* name, int64_t field_off = -1);
// Mine Thrower fast reload. MUST be pure C++: cObjMine::moveReload is a VTABLE
// slot (next to moveFire/moveDown), dispatched from cObjWep::move on the game
// thread — and with the reload cut to ~2 frames you fire constantly, so it runs
// constantly. A Lua callback there raced the shared lua_State and surfaced as
// pc=0x24cc / FMallocBinned2 / atan2f. Same class as the DualFire hot hook.
// State machine on this+inprog: 1st call (==0) falls through so the original
// re-chambers; 2nd (==1) calls cItemMgr::reload, clears the flags and blocks the
// animation. Addresses come from Lua; only the hot path lives in C++.
bool install_minethrower_fast_reload(uintptr_t movereload, uintptr_t itemmgr,
                                     uintptr_t reload_fn, uint32_t inprog_off,
                                     uint32_t subflag_off);
void set_minethrower_enabled(bool on);
// Laser sight: GetWepTargetPos derefs cModel::getPartsPtr's NULL result
//     5eef834  BL  cModel::getPartsPtr   ; NULL when the rig has no part 0
//     5eef8c4  ADD X1, X0, #0x80         ; NULL + 0x80
//     5eef8d0  BL  MTXMultVec            ; -> fault 0x80
// so aiming at a crossover enemy kills the game, every frame. Pass the address of
// the `ADD X1, X0, #0x80` (0x5EEF8C4); a NULL X0 is pointed at a zeroed buffer, so
// the laser gets no lock-on instead of a SIGSEGV. Encoding is verified before
// patching. NOT a crash guard — install_safe_call_guard is INERT (see below).
bool install_laser_sight_fix(uintptr_t add_x1_site);

// Engine-wide null audit (RE4 code 0x5D00000-0x6250000): 3456 functions can return
// NULL; 38 have callers that deref it unchecked; 3999 unguarded sites, of which
// FOUR functions are 98% — cRoomData::getRoomSavePtr (2975), SmdGetObjPtr (651),
// cEmWrap::getPtr (158), SceAtPtr (125). Guards them with an inert dummy that
// carries a STUB VTABLE (they get vtable-dispatched: 8/29/30 real sites), and is
// RETURN-ADDRESS AWARE so the few loop-exit-on-NULL callers (3/3/8) still see NULL.
bool install_null_return_guards();
uint64_t null_guard_substitutions();

// cModel::getPartsPtr (0x5F81AFC) is the root of the crossover crash family: a
// scan of libUE4 found 2420 call sites, 1101 of which deref the result with NO
// null check (IKInit -> fault 0x1d8, GetWepTargetPos -> 0x80), and its own LIST
// walk derefs *(NULL+264) -> fault 0x108. Replaces it with a safe version: NULL
// becomes a zeroed self-chaining dummy, and the walk null-checks. Verified no
// caller loop terminates on NULL (0 sites), so the dummy cannot hang anything.
// Does NOT bound ARRAY mode's `+= 496*idx` — that needs the part count.
bool install_getpartsptr_guard(uintptr_t getparts);
// EspCommonTrans (effect-sprite transform) reads the effect's parent at
// *(cEsp+64) and concats its world matrix at +24. When the parent is freed (actor
// churn / cutscene teardown / Randomizer pool leak) that pointer dangles and
// MTXConcat SIGSEGVs (tombstone_02/03). This DobbyHooks EspCommonTrans and skips
// any effect whose parent-matrix page is unmapped (live msync probe). Pass the
// EspCommonTrans address (0x5F14E7C). Toggleable via the native-patch registry.
bool install_esp_parent_guard(uintptr_t espcommontrans);
uint64_t esp_parent_skip_count();
// Block the cutscene pawn takeover: hook AVR4PlayerController::PossessPlayerPawn
// (static, type in X0) @0x6390948; when the toggle is ON and type==3 (cutscene
// pawn), redirect to the current pawn so the controller keeps YOUR pawn instead of
// the theatre pawn. Registered as re4.keep_pawn_in_cutscene (default OFF).
bool install_keep_pawn_in_cutscene(uintptr_t possess);
// Hook KeyStop @0x5FC249C for the cutscene input unfreeze.
// SceEventStart calls KeyStop(0xF12000EFCF1000), which ANDs the pad globals with
// that mask AND sets pG+0x198 |= 0x80000000. KeyClear is byte-identical except it
// does NOT set that bit — so the bit is scene state, and the MASK is what takes
// your stick. When the toggle is ON and a Bio4 event is playing we substitute an
// all-ones mask (nothing gets masked out) and still call through, so pG+0x198 is
// left exactly as the engine wants it and the scene cannot stall. Scripted scenes
// are safe: if the cutscene is animating Leon his state function ignores the pad.
// re4.cutscene_unfreeze_input (default OFF).
bool install_cutscene_input_unfreeze(uintptr_t keystop);
uint32_t cutscene_input_unfreeze_count();   // KeyStop calls we neutralized
// Hook cModel::UpdateVR4ModelVisibility @0x5F825A0. SceEventStart's
// UpdateSuspendedVisibility runs this per model; during the suspend its
// vtable+80 predicate returns HIDDEN, so with the theatre screen off there is
// nothing left to draw (that is why forceScreenOff went black). When the toggle
// is ON and a Bio4 event is playing we re-assert SetModelVisibility(model,true)
// AFTER the original runs. Prerequisite for in-world 3D cutscenes.
// re4.cutscene_force_models_visible (default OFF).
bool install_cutscene_force_models_visible(uintptr_t updvis);
uint32_t cutscene_forced_visible_count();
// Hook AVR4CutscenePlayerPawn::PostBio4Tick @0x628F550 (runs every cutscene
// frame). The cutscene lock is that cPlayer::move never runs — gated by
// pG+0x50AC bit 0x10000000, which must NOT be cleared globally (that un-suspends
// the world and the SCE script loses its scripted beats). Instead, when the
// toggle is ON and a Bio4 event is playing, call cPlayer::move(pPL) ourselves
// from the tick's post edge: world stays suspended, only Leon updates. Pair with
// re4.cutscene_unfreeze_input or the pad stays masked.
// re4.drive_player_in_cutscene (default OFF).
bool install_drive_player_in_cutscene(uintptr_t postbio4tick);
uint32_t cutscene_driven_frame_count();
// Entity move() calls driven so the scene's NPCs animate instead of standing
// idle (re4.drive_entities_in_cutscene, registered by the installer above).
uint32_t cutscene_driven_entity_count();
// Hook cPlayer::ArmVrHasControl @0x5FDF88C — THE cutscene movement gate.
// ArmVrAllowFirstPersonMovement is gated entirely on it, and it requires Leon's
// state (this+276) to be 0; scripted scenes use state 5, so the game revokes VR
// control by design. Forced true during a Bio4 event when the toggle is ON.
// re4.force_vr_control (default OFF).
bool install_force_vr_control(uintptr_t hasctl);
uint32_t cutscene_forced_control_count();
// Hook AVR4Bio4PlayerPawn::UpdateMovement @0x6264140 — the GAMEPLAY pawn's own
// movement update, so it runs while keep_pawn_in_cutscene keeps you in your pawn
// (unlike the cutscene pawn's PostBio4Tick, which goes silent then). Runs the
// original (sets movement INTENT via UpdateFirstPersonMovement) then calls
// cPlayer::move to APPLY it — proven live: intent alone moved Leon zero.
// Shares the re4.drive_player_in_cutscene toggle.
bool install_drive_player_on_movement(uintptr_t updmove);
// THE cutscene blocker. ABio4::Tick @0x6206A98 runs the engine main loop as
//   while (!spInstance[594] || spInstance[595]) { gameMainLoop(); }
// and a cutscene sets [594]=1, so the body NEVER runs — no cPlayer::move, no pad
// refill, no state machine, hence no walking and no firing. Clears that byte per
// frame while a Bio4 event plays. re4.cutscene_unlock_gameloop (default OFF).
bool install_cutscene_unlock_gameloop(uintptr_t bio4tick);
uint32_t cutscene_unlock_gameloop_count();
// cObjMgr::move null-vtable guard @0x5F89C8C. unlock_gameloop makes gameMainLoop
// run mid-scene; cObjMgr::move then calls vtable[0] on objects the scene tore
// down (PC=0, tombstone_09). Zeroes the flags of pending-destroy slots whose
// vtable is not a sane pointer so the original skips them. Hook the FUNCTION
// ENTRY, never the faulting BLR at +52 (that smashes the frame -> SIGABRT).
// re4.objmgr_move_guard (default ON — required by unlock_gameloop).
bool install_objmgr_move_guard(uintptr_t move_fn);
uint32_t objmgr_guard_skip_count();
// Fades BRACKET a scene (fade-in before SceEventStart, fade-out after the event
// ends), so gating suppression on "event playing" never catches either one.
// These open a grace window around the boundary. re4.cutscene_no_fade gates them.
void cutscene_open_fade_window();
bool install_scene_start_fade_window(uintptr_t sceeventstart);
// Missing subtitles / unusable button prompts: GetTextPromptUi caches the
// AVR4FloaterUI in this[78] and returns NULL forever once that actor is GC'd
// (the stale pointer is never cleared, so the lazy spawn cannot re-run). Both
// OnShowSceneMessage and DisplayCommandPrompt are `else if (ui)`, so a NULL ui
// silently draws nothing. re4.cutscene_prompt_respawn (default ON).
bool install_prompt_ui_respawn(uintptr_t gettextpromptui);
uint32_t cutscene_prompt_respawn_count();
// THE VR FADE. Hooking the legacy FadeSet does NOT remove the black fade — that
// is the flat-screen path. The VR build fades via AVR4FadeManager, so drop the
// calls that CREATE a fade (SetFade / SetTimedFade) inside the cutscene window.
bool install_vr_fade_suppress(uintptr_t setfade, uintptr_t timedfade);
uint32_t cutscene_vr_fades_killed_count();
// Rapidfire that does NOT kill the gun's laser dot. The old byte patches turn the
// fire signal from an EDGE into a LEVEL, so the 0->1 transition never recurs and
// the laser (re-armed on that transition) stays off after the first shot. This
// synthesises a fresh edge every N frames while the trigger is held instead.
// re4.rapidfire.pulse (default OFF; turn the byte patches off when using it).
// Cutscene collision via a RIG TETHER (re4.cutscene_rig_tether, default OFF).
// The rig locomotes independently of Leon during a scene and nothing collides it,
// so bound it to a radius around its start-of-scene anchor. Needs the pawn
// pointer, captured into a slot by the caller (RegisterNativeCapture on a
// function that takes the pawn in x0, e.g. AVR4GamePlayerPawn::UpdateVisibility).
void cutscene_set_tether_pawn_slot(uintptr_t slot);
void cutscene_set_tether_radius(uint32_t r);
uint32_t cutscene_tether_pull_count();
bool install_rapidfire_pulse(uintptr_t joyfiretrg, uintptr_t joyfireon, uintptr_t wastrigjust);
uint32_t rapidfire_pulse_count();
void rapidfire_set_interval(uint32_t frames);
// Kill the black fade into/out of cutscenes. Hooks FadeSet @0x5F39930 and drops
// the call while a Bio4 event is playing (the fade covered the hand-off to the
// 2D theatre screen, which we no longer use). Fades outside scenes are stock.
// re4.cutscene_no_fade (default OFF).
bool install_cutscene_no_fade(uintptr_t fadeset);
uint32_t cutscene_fades_killed_count();
// Un-glue the VR camera from Leon during a cutscene. Hooks
// cPlayer::ArmUpdateRideTransform @0x5FE0134 (first thing cPlayer::move calls)
// and anchors the pawn to where the player stood when the scene STARTED, so an
// overview cutscene neither teleports the view across the level nor renders from
// inside Leon's model. Hides nothing. re4.cutscene_camera_offset (default OFF).
bool install_cutscene_camera_offset(uintptr_t ride);
uint32_t cutscene_camera_offset_count();
void set_cutscene_camera_offset(int back, int up);
// True if the engine can actually load this enemy id's archive. Mirrors the
// test cEmMgr::construct makes (EmReadSearch != 0); false means construct would
// bail and leave a model-less shell that crashes downstream. Returns true if
// EmReadSearch cannot be resolved, so it never blocks a pick by accident.
bool em_id_has_data(uint32_t id);
// Skips MotionMove entirely for a model with no parts (*(model+264)==0), which
// is what feeds the getPartsPtr dummy into MTXInverse (fault 0x30). Pass 0 to
// resolve the address automatically. Installed by install_getpartsptr_guard.
bool install_motionmove_guard(uintptr_t addr);
uint64_t motionmove_skip_count();
// Maps page 0 RWX with `mov x0,#0; ret` at offset 0, so NULL derefs read 0 and
// calls through NULL return 0 instead of SIGSEGV / PC=0. Needs
// vm.mmap_min_addr=0 on the device. Idempotent.
bool install_null_page_guard();
uint64_t getpartsptr_dummy_count();
// Pointers the guard refused as impossible (non-canonical / unaligned / tiny) or
// ARRAY indices past kMaxPartIdx. Distinct from the dummy count, which counts
// legitimate NULLs the engine never checked: a nonzero value here means garbage
// was actively in flight (see the IKInit/moveWepDown tombstone).
uint64_t getpartsptr_reject_count();
// The last `this` the plausibility heuristic rejected, and the caller that passed
// it (return address). Used to learn WHY a legit pointer (e.g. a shootable cart's
// model) trips the heuristic, so it can be tightened instead of guessed at.
uint64_t getpartsptr_last_reject_self();
uint64_t getpartsptr_last_reject_ra();

// ── Native-patch registry ───────────────────────────────────────────────────
// Every toggleable native code patch/hook registers itself here so PCBridge can
// flip it live (enable = apply patch/logic, disable = restore ORIGINAL game
// behaviour) without a rebuild. This is the culprit-bisection tool: when a native
// change breaks gameplay, the user turns each patch off one at a time and finds it.
//
// Two flavours:
//   * bytes   — a fixed 32-bit code word (orig <-> patched via patch_code). Simple
//               byte patches (Lua-side included) register through this.
//   * toggle  — a setter(enable)->ok callback, for patches that cannot be a single
//               word (e.g. a Dobby hook whose teardown would race a hot function;
//               those flip an internal atomic bypass flag instead).
void register_native_patch_bytes(const std::string& id, const std::string& desc,
                                 void* addr, uint32_t orig_word, uint32_t patched_word,
                                 bool enabled_now);
void register_native_patch_toggle(const std::string& id, const std::string& desc,
                                  std::function<bool(bool)> setter, bool enabled_now);
// Read a registered patch's current enabled state. Returns false if id unknown.
bool native_patch_get(const std::string& id, bool& out_enabled);
// JSON array: [{"id","desc","enabled","kind","addr"}]. Safe to call any thread.
std::string native_patch_list_json();
// Enable/disable a registered patch by id. Returns false + err_out if unknown or
// the setter failed. Idempotent (setting to the current state is a no-op success).
bool native_patch_set(const std::string& id, bool enabled, std::string& err_out);

// CArmSoundBlock::ExtractTrackIndex (0x61AF06C) calls strtol on its cursor BEFORE
// applying the end-of-name-table bound it then checks four instructions later. An
// enemy whose room .xsb has fewer tracks than its .das expects walks the cursor off
// the buffer => SEGV_ACCERR in StrToI. This applies the game's own bound first.
bool install_xsb_track_bounds_guard(uintptr_t extract_track_index);

// cEmMark (shooting-gallery target) spawned outside the gallery: its move() reads
// the minigame manager global, which only R22cInit ever sets, then derefs the NULL
// at +0x181. Pass the address of `LDRB W8,[X8,#0x181]` in armIsShootingGamePaused
// (0x60D1B18); a NULL is redirected to a zeroed buffer => "not paused".
bool install_shootgame_paused_guard(uintptr_t ldrb_site);

// U3 "It" (emId 50 = 0x32 = cEm32) is INVULNERABLE outside its scripted level —
// same root as the fault-0x180 crash. sub_5E49AA0 builds U3's parts model with
// SetObj00 using the GLOBAL/stage archive at pG+0x68 for the skeleton param; away
// from U3's level that archive doesn't hold it, modelInit fails, SetObj00 returns
// 0, and the game derefs the NULL it just checked (*(v50+384) = NULL+0x180).
// Everything AFTER that line is YarareInit/YarareAdd — U3's ~28 DAMAGE REGIONS —
// so a crash guard that siglongjmps out is precisely what leaves U3 unkillable.
// Fix: when SetObj00 fails inside U3's init, retry with U3's OWN archive for that
// param (what modelInit uses for U3's main model). The model builds, the NULL
// never happens, the init reaches YarareAdd, and U3 is killable anywhere.
// Two ENTRY hooks (em32 init + SetObj00); the retry is scoped to U3's init only.
bool install_u3_killable_fix(uintptr_t em32_init, uintptr_t setobj00);
uint32_t u3_rescued_count();
// Dual-fire: arm the gun inside its OWN AVR4GamePlayerGun::TryFire so both guns
// pass the "am I the armed weapon?" check and fire the same frame. MUST be pure
// C++: TryFire is HOT (every trigger pull, per gun, continuously under
// rapid-fire), and a Lua callback there races the shared lua_State against the
// mod loop + bridge thread => heap/stack corruption surfacing later as
// FMallocBinned2 dying in GC, or a RET into a smashed return address (pc=lr=1).
// Addresses are passed in from Lua (Resolve() handles symbol+fallback there);
// only the hot path lives in C++. Idempotent — a mod reload won't stack hooks.
bool install_dualfire_arm(uintptr_t tryfire, uintptr_t itemmgr,
                          uintptr_t armsearch, uintptr_t armfn, uint32_t wno_off,
                          uintptr_t pg_addr, uint32_t armed_off);
void set_dualfire_enabled(bool on);
bool is_dualfire_enabled();

// Primary-hand fallback: lets a two-handed weapon fire while held by ONE grip.
// GetPrimaryHand only inspects the primary grip, so a forestock-only hold returns
// NULL and every PreBio4Tick routes the trigger to DryFire. This returns the hand
// from whichever grip IS held instead. Do NOT "fix" this by NOPing the NULL check
// in PreBio4Tick — cObjLauncher::launch() needs a real hand and faults on NULL.
bool install_primary_hand_fallback(uintptr_t getprimaryhand, uintptr_t anygrip,
                                   uintptr_t getcurrenthand, uint32_t group_off,
                                   uintptr_t getforestockhand, uintptr_t group_vtbl);
bool install_firing_hand_vtable_fallback(uintptr_t vtable_slot);
void set_primary_hand_fallback_enabled(bool on);

// Replace bionic's fmodf with a 3-instruction hardware-FP version. The enemy AI
// (cEmMgr::move -> per-enemy move) calls it constantly for angle wrapping and it
// dominates the game thread. Out-of-range/NaN/zero-divisor inputs still use the
// original, so results are unchanged.
bool install_fast_fmodf();
void set_fast_fmodf_enabled(bool on);
extern std::atomic<uint64_t> g_fmodf_fast;
extern std::atomic<uint64_t> g_fmodf_slow;
extern std::atomic<uint64_t> g_ph_fallbacks;

// TryFire instrumentation — see df_tryfire in native_hooks.cpp. Diagnostic only:
// distinguishes "TryFire never runs" (input/grip layer blocks it) from
// "TryFire runs and returns 0" (a weapon-side gate rejects the shot).
extern std::atomic<uint64_t> g_df_calls;
extern std::atomic<uint64_t> g_df_ok;
extern std::atomic<uint64_t> g_df_last_self;
extern std::atomic<uint64_t> g_df_last_ret;
// True if em `id` has a real init. cEmMgr::construct calls the EmInitFunc global
// WITHOUT a null check, so an id with no ArmEmCallProlog case runs the previous
// enemy's init over the wrong archive — or jumps to NULL (pc=0). Ask the jump
// table so the list can't rot. Ids 75/78 (em4b/em4e = vehicles, Houdai) are
// genuinely unimplemented and must not be spawned.
bool is_em_id_supported(uint32_t id);
// Remap crossover enemy ids 0x60-0x6F (the Randomizer's above-base pool) at
// cEmMgr::construct entry to a supported base enemy. These ids are OUTSIDE
// ArmEmCallProlog's switch (id-3 > 0x4C), so the villager jump-table fix can't
// reach them; they leave the global EmInitFunc stale -> construct runs the
// previous enemy's init on the wrong data -> stack smash (PC==LR==0xA54AB68).
// Rewriting the id arg (W2) at entry makes the WHOLE construct build a real
// enemy. Ids whose .das already points at a base archive map to it (0x68->em18,
// 0x66->em46, 0x6C/6D/6F->em4c/4d/4f); the ema-series maps to em09 (ganado).
// Unsupported targets fall back to em09. Pass cEmMgr::construct's entry address.
bool install_crossover_enemy_remap(uintptr_t construct_entry);

// gameRoomInit BLRs vtable[0x90] with no null check; the BASE cEm vtable has no
// entry there, so any enemy left as a bare cEm jumps to 0 during room init
// (tombstone: SEGV_MAPERR fault 0x0, #01 gameRoomInit()+2260). Instrument the
// load so a NULL is redirected to a no-op stub. Site = 0x5F43B38.
bool install_gameroominit_vcall_guard(uintptr_t site);
// Absorbs the NULL virtual slot-4 call in cSubChar::moveFace (PC=0 on the game
// thread) and logs this/vptr so the corrupted class can be identified. Installed
// automatically with the getPartsPtr guard; idempotent.
bool install_subchar_vcall_guard();

// EmSetFromList2(id, flags) @0x5EE9A6C runs BEFORE cEmMgr::construct, so the
// construct remap is too late — an id the room cannot build faults inside the
// spawn-list read itself. Applies the same crossover LUT to X0 at entry.
bool install_emsetfromlist_id_remap(uintptr_t entry);

// EmSetFromList() takes NO arguments — it reads every enemy id from the global
// spawn list (pG + 32*i + 21661, 256 slots). Sanitises that list in place before
// the pass runs, so an unbuildable id never reaches construct.
bool install_emsetfromlist_sanitize(uintptr_t entry, uintptr_t pg_addr);

// THE "unkillable boss" fix. LifeDownSet2 floors HP at 1 when its 4th arg has
// bit0 set ("keep this enemy alive") — found with a hardware watchpoint on a live
// U3's HP: one writer, libUE4+0x5EEF1F8. Damage always landed; the clamp is what
// made it immortal. Clears that bit for opt-in em ids so HP can reach 0 and the
// normal death (with animation) runs. install_at only — LifeDownSet2 opens with
// `str d8,[sp,#-0x50]!` and instrumenting that smashes the stack.
bool install_lifedown_keepalive_fix(uintptr_t lifedownset2);
void set_em_killable(uint32_t em_id, bool on);
uint64_t keepalive_cleared_count();
// Guard FAsyncLoadingThread::Run's `LDAR W8,[X8]` (X8 = GGCSingleton+8): when the
// GC singleton isn't up yet (startup / level transition) GGCSingleton is NULL and
// this faults at 0x8 (level never finishes loading, black screen). Redirect the
// null read to a zeroed word = "GC idle". Pass the LDAR site (0x68957DC RVA).
bool install_async_gc_singleton_guard(uintptr_t ldar_site);
// Lift the per-level live-enemy cap. EmSetEvent returns errEm ("pool full") once
// the fixed cEm pool is exhausted; cEmMgr::arrayAlloc(n) sizes that pool as
// stride*n AND sets count=n, so scaling its argument scales both together.
// Takes effect on the next level load. mult is clamped to 1..16.
bool set_enemy_pool_multiplier(uint32_t mult);
// Persistent pool: allocate the enemy pool once and reuse it across room
// loads (no free -> no dangling pointers, no realloc -> no per-room leak).
// Pass false for the stock allocate-and-abandon behaviour.
bool set_enemy_pool_persist(bool on);

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
