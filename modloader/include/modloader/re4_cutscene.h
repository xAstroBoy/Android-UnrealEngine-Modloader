// modloader/include/modloader/re4_cutscene.h
// ═══════════════════════════════════════════════════════════════════════
// RE4 VR — THE CUTSCENE SUBSYSTEM
// ═══════════════════════════════════════════════════════════════════════
// One cohesive feature, one home. These patches exist to answer a single
// question: "why does a cutscene take the game away from you, and what do we
// have to defeat to get it back?" They were reverse-engineered together and
// they only make sense together, so they live here instead of being scattered
// through the generic native_hooks namespace with the crash guards and the
// weapon patches.
//
// WHAT A CUTSCENE ACTUALLY DOES (measured, 2026-07-21 — see the .cpp for the
// evidence behind each one):
//
//   SceEventStart (0x6190A30)
//     ├─ suspends the world      -> STA_CK(35), pG+0x50AC bit 0x10000000.
//     │                             cPlayer::move never runs. NOT input-blocking:
//     │                             a sentinel in pPL+2528 survived 300+ frames.
//     ├─ hides every model       -> UpdateSuspendedVisibility -> the vtable+80
//     │                             predicate in cModel::UpdateVR4ModelVisibility
//     ├─ stops pad SAMPLING      -> the whole pad block 0xA562B40..0xA562BB8 reads
//     │                             0x00000000 for the entire scene. Unmasking is
//     │                             meaningless; there is no data to unmask.
//     └─ KeyStop (0x5FC249C)     -> masks the pad AND sets pG+0x198 bit31. Only the
//                                   MASK matters; bit31 is load-bearing scene state
//                                   (ScenarioMove save/restores it) — never write it.
//
//   Presentation is separate: the "2D theatre box" is an ADDITIVE LEVEL streamed by
//   StreamLoadTheatreBox at RoomDataEntry[151..156], and the scene is composited onto
//   a screen inside it. Killing the screen alone = black (an unlit room). Captions,
//   command prompts and QTE buttons do NOT need it — AVR4InteractionManager already
//   routes them to AVR4FloaterUI whenever the active pawn type is not 3.
//
// Each installer registers a PCBridge toggle (all default OFF) so any of them can be
// flipped live without a rebuild — see native_patch_list / native_patch_set.
// ═══════════════════════════════════════════════════════════════════════
#pragma once

#include <cstdint>

namespace re4_cutscene
{
    // Install the whole subsystem. `lib_base` is libUE4.so's load base; every RVA
    // is encapsulated here rather than smeared across init.cpp. Safe to call once
    // per process; each installer is individually idempotent. Returns the number
    // of patches that installed successfully.
    int install_all(uintptr_t lib_base);

    // ── Live counters (diagnostics; safe to call any time) ──────────────
    uint32_t input_unfreeze_count();   // KeyStop calls we neutralized
    uint32_t forced_visible_count();   // models we re-asserted visible
    uint32_t driven_frame_count();     // frames we drove cPlayer::move
    uint32_t driven_entity_count();    // entity move() calls we drove
}
