# RE4 VR crossover enemy crash — data/paths report (ids 0x60–0x6F)

Generated from the live `libUE4.so` tables (`EmFileTbl` @ `0xA4672CC`, `FileTbl` @ `0xA44C298`)
via `ArmGetEmDasPath`. This is the pool the Randomizer reaches into above the base enemy set.

## The crash (root cause)

`cEmMgr::construct` (`0x5D902D4`) calls a **single global function pointer `EmInitFunc`**
(`@0xA54AB58`) at `0x5D902F0` (`BLR X8`, `X8 = *EmInitFunc`). `EmReadSearch` only refreshes
that global for enemies found in the base table (fast path). A crossover id takes the
**file-load path**, where `ArmEmCallProlog(id)` has **no `case`**, so it returns 0 and leaves
`EmInitFunc` holding the **previous enemy's** init function. `construct` then runs that wrong
init over incompatible data → the init smashes its own stack frame → `RET` into `0xA54AB68`
(a data address). Signature: `PC == LR == X30 == 0xA54AB68`, `X29` garbage — identical every
time regardless of which enemy, because the corrupted target is a fixed global address.

**A `.pak` alone cannot fix this** — the missing piece is the `ArmEmCallProlog` init *case*
(code). The `.das` archives themselves **exist** (proven: `construct` only runs `EmInitFunc`
when `EmReadSearch` returned non-null, i.e. the file opened and read). The fix is a modloader
**init remap** per id (route each to a compatible base enemy's init, like the existing
`InstallCutVillagerFix` does for ids 6/7/8/0xA/0xB/0xD/0x33/0x37).

## Per-id `.das` mapping

| em id | .das path        | notes |
|-------|------------------|-------|
| 0x60  | `em/ema0.das`    | ema-series (unique) |
| 0x61  | `em/ema1.das`    | ema-series (unique) |
| 0x62  | `em/ema2.das`    | ema-series (unique) |
| 0x63  | `em/ema3.das`    | ema-series (unique) |
| 0x64  | `em/ema4.das`    | ema-series (unique) |
| 0x65  | `em/ema5.das`    | ema-series (unique) |
| 0x66  | `em/em46.das`    | references base em46 archive |
| 0x67  | `em/ema7.das`    | ema-series (unique) |
| 0x68  | `em/em18.das`    | **ALIAS of em18** — remap init → em18 (real base enemy, real data) |
| 0x69  | `em/ema9.das`    | ema-series (unique) |
| 0x6A  | `em/emaa.das`    | ema-series (unique) |
| 0x6B  | `em/emab.das`    | ema-series (unique) |
| 0x6C  | `em/em4c.das`    | references base em4c archive |
| 0x6D  | `em/em4d.das`    | references base em4d archive |
| 0x6E  | `em/emae.das`    | ema-series (unique) |
| 0x6F  | `em/em4f.das`    | references base em4f archive |

Full content path at runtime = `<ProjectContentDir>/BIO4/<das path>` (e.g.
`BIO4/em/ema9.das`). The `.das` references the enemy model archive and its sound bank.

## What a `.pak` CAN improve (sound)

`ArmLoadSoundBlockEnemy` → `TryLoadGenericFromDas` → `LoadXSBFile` loads
`BIO4/snd/<name>.xsb`. For the ema-series the loaded `.xsb` is **short/malformed** — that's the
separate SEGV_ACCERR over-run in `ExtractTrackIndex` (now guarded in native code by a
readable-cursor check; skipped tracks fall back to generic `em`/`pl` sounds). A `.pak`
supplying correct `BIO4/snd/*.xsb` banks for the ema-series would give these enemies proper
audio once the init remap makes them spawn.

## Fix plan

1. **Code (required):** modloader init remap — for each id above, point its construct init at a
   compatible base enemy's init. Trivial/known: `0x68 → em18`. `0x66/0x6C/0x6D/0x6F` reference
   real base archives (em46/em4c/em4d/em4f) → remap to those. The pure ema-series
   (`0x60-65,67,69,6A,6B,6E`) need a per-id choice of which base enemy behaviour to borrow.
2. **Data (optional, `.pak`):** corrected `BIO4/snd/ema*.xsb` for proper audio.
