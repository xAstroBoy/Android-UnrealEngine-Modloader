#!/usr/bin/env bash
# Copy the freshly built libmodloader.so into the LSPosed module's jniLibs.
set -e
HERE="$(cd "$(dirname "$0")" && pwd)"
SRC="$HERE/../modloader/build/libmodloader.so"
DST="$HERE/app/src/main/jniLibs/arm64-v8a/libmodloader.so"
if [ ! -f "$SRC" ]; then
    echo "[sync-payload] ERROR: $SRC not found. Build the modloader first (modloader/build.sh)."
    exit 1
fi
mkdir -p "$(dirname "$DST")"
cp -f "$SRC" "$DST"
echo "[sync-payload] Copied libmodloader.so -> jniLibs/arm64-v8a/"
