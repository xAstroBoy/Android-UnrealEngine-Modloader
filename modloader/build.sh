#!/bin/bash
# One build command, BOTH ABIs (CI and local development).
#   arm64-v8a   -> build/     (64-bit titles: RE4, Pinball FX, ...)
#   armeabi-v7a -> build32/   (32-bit titles: Face Your Fears 1/2, ...)
# One source tree; an ELF is single-arch, so we emit one libmodloader.so per ABI
# and the installer drops the matching one into the APK's lib/<abi>/.
# Requires: Android NDK r23c, CMake 3.22+, Ninja
set -e

# ── NDK Detection ─────────────────────────────────────────────────────
if [ -z "$NDK" ]; then
    if [ -n "$ANDROID_HOME" ] && [ -d "$ANDROID_HOME/ndk/23.1.7779620" ]; then
        NDK="$ANDROID_HOME/ndk/23.1.7779620"
    elif [ -d "$HOME/Android/Sdk/ndk/23.1.7779620" ]; then
        NDK="$HOME/Android/Sdk/ndk/23.1.7779620"
    elif [ -d "/usr/local/lib/android/sdk/ndk/23.1.7779620" ]; then
        NDK="/usr/local/lib/android/sdk/ndk/23.1.7779620"
    else
        echo "ERROR: Android NDK not found. Set NDK or ANDROID_HOME."
        exit 1
    fi
fi
echo "Using NDK: $NDK"

API=24
TOOLCHAIN="$NDK/build/cmake/android.toolchain.cmake"
if [ ! -f "$TOOLCHAIN" ]; then
    echo "ERROR: Toolchain not found at $TOOLCHAIN"
    exit 1
fi

build_abi() {
    local ABI="$1" OUT="$2"
    echo ""
    echo "=== Configuring $ABI -> $OUT ==="
    mkdir -p "$OUT"
    ( cd "$OUT"
      cmake -G Ninja \
          -DCMAKE_TOOLCHAIN_FILE="$TOOLCHAIN" \
          -DANDROID_ABI="$ABI" \
          -DANDROID_PLATFORM="android-$API" \
          -DANDROID_STL=c++_static \
          -DCMAKE_BUILD_TYPE=Release \
          ..
      ninja -j"$(nproc 2>/dev/null || sysctl -n hw.ncpu 2>/dev/null || echo 4)"
    )
    echo "=== Built $ABI ==="
}

build_abi arm64-v8a   build
build_abi armeabi-v7a build32

echo ""
echo "=== BUILD SUCCEEDED (both ABIs) ==="
echo "  arm64-v8a   : $(pwd)/build/libmodloader.so"
echo "  armeabi-v7a : $(pwd)/build32/libmodloader.so"
