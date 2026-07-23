// modloader/src/hook/re4_cutscene.cpp
// ═══════════════════════════════════════════════════════════════════════
// RE4 VR — THE CUTSCENE SUBSYSTEM (installer + RVA table)
// ═══════════════════════════════════════════════════════════════════════
// See modloader/re4_cutscene.h for what a cutscene actually does to the game
// and why each patch exists.
//
// This file owns the ADDRESSES. They used to be five magic constants inline in
// init.cpp, which meant the cutscene feature had no single place to look at, and
// a bad RVA looked like an init bug rather than a cutscene bug. Now init.cpp
// says `re4_cutscene::install_all(base)` and nothing else.
//
// The hook bodies still live in re4_native_hooks.cpp next to the shared patch
// registry and the Dobby plumbing they depend on; this is the seam that gives
// the feature its own identity and its own entry point.
// ═══════════════════════════════════════════════════════════════════════
#include "modloader/re4_cutscene.h"
#include "modloader/native_hooks.h"
#include "modloader/logger.h"

namespace re4_cutscene
{
    namespace
    {
        // ── RVA table (libUE4.so). One place, verified against IDA. ──────
        //
        // AVR4PlayerController::PossessPlayerPawn(EPlayerPawn) — static, type in X0.
        // type==3 is the cutscene/theatre pawn.
        constexpr uintptr_t kPossessPlayerPawn = 0x6390948;

        // KeyStop(mask) — masks the pad AND sets pG+0x198 bit31. We only ever
        // neutralize the MASK; bit31 is scene state (ScenarioMove save/restores it).
        constexpr uintptr_t kKeyStop = 0x5FC249C;

        // cModel::UpdateVR4ModelVisibility — the per-model visibility decision the
        // suspend drives through UpdateSuspendedVisibility.
        constexpr uintptr_t kUpdateVR4ModelVisibility = 0x5F825A0;

        // AVR4CutscenePlayerPawn::PostBio4Tick — runs every cutscene frame; it is
        // what computes screenOn and calls UpdateCamera.
        //
        // ⚠ DO NOT retarget this at the base AVR4PlayerPawn::PostBio4Tick
        // (0x639A504). Tried 2026-07-21: the game never finishes launching — no
        // tombstone, the process simply dies — because that base tick runs for every
        // pawn from very early init, long before our globals are sane.
        constexpr uintptr_t kCutscenePawnPostBio4Tick = 0x628F550;

        // cPlayer::ArmVrHasControl — THE movement gate. Requires state==0, so the
        // game revokes VR control whenever the scene owns Leon (scripted = state 5).
        constexpr uintptr_t kArmVrHasControl = 0x5FDF88C;

        // AVR4Bio4PlayerPawn::UpdateMovement — the gameplay pawn's movement update.
        // Runs while keep_pawn keeps you in your own pawn. Its original sets movement
        // INTENT (UpdateFirstPersonMovement); cPlayer::move APPLIES it.
        constexpr uintptr_t kBio4UpdateMovement = 0x6264140;

        // ABio4::Tick — owns the engine main loop, gated on spInstance[594].
        // THE cutscene blocker: [594]=1 skips gameMainLoop entirely.
        constexpr uintptr_t kBio4Tick = 0x6206A98;

        // FadeSet — the black fade into/out of a scene (0xFF000000 = opaque black).
        constexpr uintptr_t kFadeSet = 0x5F39930;

        // SceEventStart — suspends the world and raises evtDepth. Hooked only to
        // arm the fade grace window at the scene boundary (the fades themselves
        // fire OUTSIDE the event, so no_fade cannot see them on its own).
        constexpr uintptr_t kSceEventStart = 0x6190A30;

        // AVR4InteractionManager::GetTextPromptUi — lazily spawns the floater UI
        // that draws subtitles and button prompts, but returns NULL forever once
        // the cached actor is GC'd. Both callers are `else if (ui)`, so a NULL ui
        // silently draws nothing.
        constexpr uintptr_t kGetTextPromptUi = 0x632CAC8;

        // AVR4FadeManager — THE VR fade. The legacy FadeSet above is the
        // flat-screen path and hooking it alone leaves the fade fully visible in
        // the headset. These two create the fade entries the manager blends.
        constexpr uintptr_t kVrSetFade      = 0x62B3A10;
        constexpr uintptr_t kVrSetTimedFade = 0x62B4998;

        // Fire gates. joyFireTrg is the native EDGE, joyFireOn the native HELD
        // (called, never hooked — it is how we ask "is the trigger down?" without
        // knowing the key-mask layout). WasTriggerJustPressed is the UE-side edge.
        constexpr uintptr_t kJoyFireTrg            = 0x600A978;
        constexpr uintptr_t kJoyFireOn             = 0x600A890;
        constexpr uintptr_t kWasTriggerJustPressed = 0x62DAAD8;

        // cObjMgr::move — the pool tick gameMainLoop runs. Unguarded, it calls
        // vtable[0] on scene-torn-down objects (PC=0). This is the FUNCTION ENTRY;
        // the crash site is +52 and must NOT be hooked directly.
        constexpr uintptr_t kObjMgrMove = 0x5F89C8C;

        // cPlayer::ArmUpdateRideTransform — first call inside cPlayer::move, where
        // the VR rig is reconciled with Leon each frame. Our seam for detaching the
        // camera without fighting the Blueprint mid-frame.
        constexpr uintptr_t kArmUpdateRideTransform = 0x5FE0134;
    }

    int install_all(uintptr_t b)
    {
        if (!b)
        {
            logger::log_error("RE4CUT", "install_all skipped — lib_base unavailable");
            return 0;
        }

        int ok = 0;

        // Keep YOUR pawn: block the hand-off to the theatre pawn (type 3).
        // ⚠ Blocking possession also stops AVR4CutscenePlayerPawn from ticking, so
        // anything hooked on its PostBio4Tick goes silent while this is ON.
        if (native_hooks::install_keep_pawn_in_cutscene(b + kPossessPlayerPawn)) ++ok;

        // Give the pad back: KeyStop masks nothing while a Bio4 event is playing.
        if (native_hooks::install_cutscene_input_unfreeze(b + kKeyStop)) ++ok;

        // Make the suspended actors render — the half missing from every earlier
        // black screen (the theatre box is an unlit room; killing its screen with
        // every model hidden leaves nothing to draw).
        if (native_hooks::install_cutscene_force_models_visible(b + kUpdateVR4ModelVisibility)) ++ok;

        // Sample the pad ourselves (KPadRead) and tick Leon (cPlayer::move) without
        // un-suspending the world, plus optionally drive every other entity so the
        // scene's NPCs animate instead of standing idle.
        if (native_hooks::install_drive_player_in_cutscene(b + kCutscenePawnPostBio4Tick)) ++ok;

        // Camera: freeze the VR rig where the player stood when the scene began,
        // so overview cutscenes neither teleport the view nor put it inside Leon.
        if (native_hooks::install_cutscene_camera_offset(b + kArmUpdateRideTransform)) ++ok;

        // Suppress the black fade that covered the old theatre hand-off.
        if (native_hooks::install_cutscene_no_fade(b + kFadeSet)) ++ok;

        // The fades sit OUTSIDE the event window (in before SceEventStart, out
        // after it ends), so no_fade alone never sees them. Arm the grace window
        // from SceEventStart itself.
        if (native_hooks::install_scene_start_fade_window(b + kSceEventStart)) ++ok;

        // Subtitles + button prompts: revive the floater UI once it has been GC'd.
        if (native_hooks::install_prompt_ui_respawn(b + kGetTextPromptUi)) ++ok;

        // THE VR fade — the one you actually see in the headset.
        if (native_hooks::install_vr_fade_suppress(b + kVrSetFade, b + kVrSetTimedFade)) ++ok;

        // Rapidfire that keeps the gun's laser dot (pulsed edge, not stuck level).
        if (native_hooks::install_rapidfire_pulse(b + kJoyFireTrg, b + kJoyFireOn,
                                                  b + kWasTriggerJustPressed)) ++ok;

        // MUST come before unlock_gameloop: running gameMainLoop mid-scene drives
        // cObjMgr::move over objects the scene tore down, and it calls vtable[0]
        // with no null check (tombstone_09: PC=0 four frames under our hook).
        if (native_hooks::install_objmgr_move_guard(b + kObjMgrMove)) ++ok;

        // THE blocker: let the engine main loop run during a cutscene at all.
        // Without this NOTHING else in this subsystem can matter — every other
        // gate lives inside gameMainLoop, which is never called.
        if (native_hooks::install_cutscene_unlock_gameloop(b + kBio4Tick)) ++ok;

        // Apply movement while keep_pawn keeps your pawn: the cutscene pawn's tick
        // is silent then, so drive cPlayer::move from the gameplay pawn's own update.
        if (native_hooks::install_drive_player_on_movement(b + kBio4UpdateMovement)) ++ok;

        // THE movement gate — without this, nothing else can give you control in a
        // scene that scripts Leon.
        if (native_hooks::install_force_vr_control(b + kArmVrHasControl)) ++ok;

        logger::log_info("RE4CUT", "cutscene subsystem installed — %d/10 patches "
                                   "(working set ON by default; toggle via native_patch_set)", ok);
        return ok;
    }

    uint32_t input_unfreeze_count() { return native_hooks::cutscene_input_unfreeze_count(); }
    uint32_t forced_visible_count() { return native_hooks::cutscene_forced_visible_count(); }
    uint32_t driven_frame_count()   { return native_hooks::cutscene_driven_frame_count(); }
    uint32_t driven_entity_count()  { return native_hooks::cutscene_driven_entity_count(); }
}
