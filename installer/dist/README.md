# Prebuilt installer

`ue-modloader-installer.exe` — Windows, GUI + CLI. Committed so you can grab the
toolkit straight from the repo without a Rust toolchain or a release download.

```
ue-modloader-installer.exe                          # GUI
ue-modloader-installer.exe --cli --package com.Armature.VR4
ue-modloader-installer.exe --apk path\to\game.apk   # patch a local APK, no device
```

It fetches the latest `libmodloader.so` from the newest GitHub release on every
run, so this .exe does not go stale as the modloader changes. Pass
`--modloader-so <path>` to force your own build instead.

**Rebuilt from `installer/` — do not edit this binary.** To refresh it:

```
cd installer && cargo build --release
copy target\release\ue-modloader-installer.exe dist\
```

## About your save

Patching a **store-bought** copy for the first time **erases your save** (and the
one-time optimization screen comes back). The save is in internal storage —
`/data/data/<pkg>/files/UE4Game/VR4/VR4/Saved/SaveGames/` — which Android only
opens to root or a *debuggable* app, and the store build is neither. Back it up
in-game / via Meta cloud first.

It is a one-time cost: the patched APK **is** debuggable, so every later
re-install preserves the save automatically (`run-as`, no root).
