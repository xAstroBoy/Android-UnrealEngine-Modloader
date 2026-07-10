# Quest UE4 ModLoader — LSPosed Module

Load `libmodloader.so` into a UE4 Quest game **via root (LSPosed/Zygisk)** instead
of patching the game's APK. Enable the module, pick the game, launch — the
modloader boots exactly as if the APK had been patched.

## Why

The classic install path patches the APK to add `System.loadLibrary("modloader")`.
That means re-signing, re-installing, losing save data / entitlements, and redoing
it on every game update. Since you have **root + Magisk + Zygisk + LSPosed**, this
module instead injects the loader at process start — nothing about the game on disk
changes.

## How it works

1. `libmodloader.so` is bundled as this module's **own** jniLib, so Android extracts
   it to the module's `nativeLibraryDir` on disk with a world-readable + executable
   SELinux label (`apk_data_file`).
2. When LSPosed injects the module into a scoped game, we hook `Application.onCreate`
   and `System.load()` that on-disk path from inside the game process.
3. `libmodloader.so`'s `JNI_OnLoad` runs and boots the modloader — early PAK hooks,
   reflection walk, Lua, ADB bridge, everything — identical to the patched-APK path.

The payload has a unique soname (`libmodloader.so`), so there's no collision with
any game library and `System.load()` "just works".

## Build

Prereq: Android Studio (or the Android SDK + Gradle 8.5) with an installed SDK
platform 34. Java 17.

```bash
# 1. Build the modloader itself (produces modloader/build/libmodloader.so)
cd ../modloader
./build.bat            # or ./build.sh

# 2. Copy the payload into the module
cd ../lsposed-module
./sync-payload.sh      # or sync-payload.bat  (copies libmodloader.so into jniLibs)

# 3. Build the module APK
./gradlew :app:assembleRelease
# output: app/build/outputs/apk/release/app-release.apk  (sign it if needed)
```

> The Gradle wrapper JAR is not checked in. Open the folder in Android Studio once
> (it generates the wrapper), or run with a locally installed `gradle`, or copy a
> `gradle/wrapper/` from any other project.

## Install & use

1. Install the module APK (`adb install app-release.apk`).
2. In **LSPosed Manager**: enable the module, then set its **scope** to your game.
   Three Quest UE4 games are pre-listed as recommended scope
   (`com.Armature.VR4`, `com.zenstudios.PFXVRQuest`, `com.Capricia.HandBoi`) — for
   any other UE4 game just tick it in the scope list.
3. Force-stop and relaunch the game. The modloader boots.

Check it worked:

```bash
adb logcat -s UEModLoaderLSP UEModLoader     # LSP = injector, UEModLoader = the loader
```

### Restricting targets (optional)

By default the module trusts the LSPosed scope you picked. To hard-restrict which
packages get injected, create `/sdcard/UnrealModloader/lsposed_targets.txt` with one
package name per line (a line `*` means "any scoped app"). Lines starting with `#`
are comments.

## Notes

- 32-bit games are not supported (Quest is arm64; the payload is arm64-v8a only).
- If `System.load` fails with an SELinux/exec denial on an unusual ROM, the module
  falls back to extracting the payload into the game's `codeCacheDir`. Check the
  `UEModLoaderLSP` logcat tag for the resolved path.
- This does not replace the deploy tooling — `tools/deploy.py` still pushes mods,
  pulls logs, opens the bridge console, and triggers SDK/IDA dumps.
