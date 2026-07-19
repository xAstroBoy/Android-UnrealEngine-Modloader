#!/usr/bin/env bash
# Copy the freshly built libmodloader.so (BOTH ABIs) into the LSPosed module's
# jniLibs. arm64-v8a for 64-bit titles, armeabi-v7a for 32-bit titles.
set -e
HERE="$(cd "$(dirname "$0")" && pwd)"
SRC64="$HERE/../modloader/build/libmodloader.so"
DST64="$HERE/app/src/main/jniLibs/arm64-v8a/libmodloader.so"
SRC32="$HERE/../modloader/build32/libmodloader.so"
DST32="$HERE/app/src/main/jniLibs/armeabi-v7a/libmodloader.so"

if [ ! -f "$SRC64" ]; then
    echo "[sync-payload] ERROR: $SRC64 not found. Build the modloader first (modloader/build.sh)."
    exit 1
fi
if [ ! -f "$SRC32" ]; then
    echo "[sync-payload] ERROR: $SRC32 not found. Build the modloader first (modloader/build.sh builds BOTH ABIs)."
    exit 1
fi

mkdir -p "$(dirname "$DST64")" "$(dirname "$DST32")"
cp -f "$SRC64" "$DST64"
cp -f "$SRC32" "$DST32"
echo "[sync-payload] Copied libmodloader.so -> jniLibs/arm64-v8a/ and jniLibs/armeabi-v7a/"
