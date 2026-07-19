# RE4 VR Cutscene Pipeline — Full Reverse-Engineering (libUE4.so)

> Reversed from `RE4_Dump/libUE4.so` in IDA. Every address is an RVA (imagebase 0).
> Goal: render cutscenes as **full 3D** in the world instead of a flat "theatre" screen.

## The two classes

| Class | Role |
|---|---|
| `AVR4CutsceneManager` (singleton `spInstance` @ `0xA5C1490`) | Orchestrator: caches SCE event data, activates cut data, fog/light, **actor visibility**, audio-sync, QTEs. |
| `AVR4CutscenePlayerPawn` | The pawn the game swaps to **while a cutscene plays**. Owns the camera + the theatre box. |

`AVR4CutsceneManager::IsBio4EventPlaying` (`0x628B3F4`) = the "cutscene active" test (`EventMgr::IsAliveEvt`).

## Per-frame camera path (the heart of it)

`AVR4CutscenePlayerPawn::PostBio4Tick` (`0x628F550`) each frame:
```c
screenOn = ((pG[0x71] & 4) == 0) && ((pG[0x50A5] & 4) == 0);   // the 2D-screen flag
cam      = GetCameraTransform();                                // WORLD-space cine camera
fov      = *(float*)(pG + 0x154);
UpdateCamera(cam, fov, screenOn);
```
- **`pG`** = the game global block (`0xA456E48` → &Global). The **cinematic camera is a 3×4 matrix at `pG + 148`** — `GetCameraTransform` (`0x628ED04`) runs `FArmMath::MtxToMatrix(pG+148)` → normalizes → `FTransform::SetFromMatrix`. FOV at `pG+0x154`.
- **`screenOn`** is derived from two flag bytes in `pG` (`+0x71`, `+0x50A5`, bit `4`). When set, the cutscene is presented on the **flat theatre screen**; when clear, the game renders the scene **in 3D**. *The game already renders some cutscenes fully 3D — exactly the ones where `screenOn` is false.*

`AVR4CutscenePlayerPawn::UpdateCamera` (`0x6443E64`) packs `{FTransform cam, float fov, bool screenOn}` into a param buffer and calls a **Blueprint event** (`FindFunctionChecked`) — the BP does the actual camera work and, **when `screenOn`, draws the flat `CutsceneBoxScreen`** that overlays/replaces the 3D view. `screenOn` is the param bit at buffer +0x34.

## The theatre box

`AVR4CutscenePlayerPawn::StreamLoadTheatreBox` (`0x628FDF0`) streams a **separate level instance** via `ULevelStreamingDynamic::LoadLevelInstance` at a transform from `UVR4DataSingleton::GetRoomDataEntry` (`RoomDataEntry[151..156]` = loc+rot). Key: it's an **ADDITIVE** streaming level — the real world **stays loaded and rendered underneath**. So the cutscene models perform inside this streamed room; the flat screen is what the game normally shows the player.

## Actor visibility (why 3D actors may not show)

`AVR4CutsceneManager::UpdateSuspendedVisibility` (`0x6289180`) iterates **all `AVR4Model`** (character models) and **`AVR4ParticleActor`** actors, calling:
- `cModel::UpdateVR4ModelVisibility` (`0x5F825A0`) → `AVR4Model::SetModelVisibility` + `SetModelOpacity`.
- `AVR4ParticleActor::UpdateVisibility`.

gated by a suspend flag (actor flag bit `0x20`). This is what decides whether cutscene characters/particles render.

## Moving the VR view into the scene

`AVR4PlayerPawn::SetAnchorInternal` (`0x639A598`) writes the pawn transform and calls `AActor::SetActorLocationAndRotation` (`0x8770518`), **yaw-flattening** the rotation (`FArmMath::FlattenTransformRotation` — drops pitch/roll). Because the **HMD camera is relative to the pawn**, this places you at the camera's position + yaw while **head-look stays free**. `AActor::SetActorLocation` (`0x877036C`) sets position only (keep your own orientation — max comfort).

FTransform layout used: `FQuat Rotation @0x00`, `FVector Translation @0x10`, `FVector Scale3D @0x20`. So the cine-camera **position = camPtr + 0x10** (3 floats).

## THE FULL-3D RECIPE (what makes every cutscene 3D)

1. **`screenOn = 0`** on every `UpdateCamera` — the BP never draws the flat theatre screen (pre-hook rewrites arg `screenOn`→0). *Alone this is black — there's no screen and you're still outside the box.*
2. **Anchor the view into the scene** — post-hook `SetAnchorInternal(pawn, cam)` (rides the cine camera, head-free) **or** `SetActorLocation(pawn, cam+0x10)` (position-only, keep your orientation — comfort). Do it POST (after the BP's own camera write) so ours wins → no flicker.
3. **Keep the theatre box** (do NOT block `StreamLoadTheatreBox`) — it's additive, so the 3D scene stays rendered. Blocking it = black.
4. **Auto-QTE**: `AVR4InteractionManager::SetCurrentCommandQTEId` (`0x632CFA8`) fires on QTE start → call `SucceedQTE` (`0x632F874`) (+ short retries) so prompts you can't see auto-pass.

⇒ `screenOff` **+** `anchor` **+** keep-box = **pure 3D, no flat screen, head-free**. (1)+(2) must go together; either alone is black. This is the config the mod now ships by default.

## Symbols (RVA)
```
AVR4CutscenePlayerPawn::PostBio4Tick        0x628F550
AVR4CutscenePlayerPawn::GetCameraTransform  0x628ED04
AVR4CutscenePlayerPawn::UpdateCamera        0x6443E64   (this, const FTransform* cam, float fov, bool screenOn)
AVR4CutscenePlayerPawn::StreamLoadTheatreBox 0x628FDF0
AVR4CutsceneManager::UpdateSuspendedVisibility 0x6289180
AVR4PlayerPawn::SetAnchorInternal           0x639A598   (this, const FTransform* xform)
AActor::SetActorLocation                    0x877036C   (this, const FVector* loc, bool sweep, FHitResult*, ETeleport)
AVR4InteractionManager::SetCurrentCommandQTEId 0x632CFA8
AVR4InteractionManager::SucceedQTE          0x632F874
pG (game globals)                           0xA456E48   (cam matrix @ +148, fov @ +0x154, screen flags @ +0x71 / +0x50A5)
```
No modloader tweak is required: `Resolve`/`CallNative`/`RegisterNativeHookAt`/`ReadU32`/`WriteU32` cover every step.
