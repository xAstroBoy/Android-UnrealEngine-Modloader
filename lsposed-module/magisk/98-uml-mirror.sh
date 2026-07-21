#!/system/bin/sh
# UnrealModloader storage bind — runs at every boot (bind mounts never survive a
# reboot). Makes the UNSCOPED public store visible to the game:
#
#     /storage/emulated/0/UnrealModloader/<pkg>   (= /data/media/0/UnrealModloader/<pkg>)
#
# THE SCOPED PATH /storage/emulated/0/Android/data/<pkg>/files/modloader IS NEVER
# CREATED OR TOUCHED. (The old version of this script bind-mounted public OVER the
# scoped dir and had to mkdir it first — that folder is exactly what we no longer
# want. Do not bring it back.)
#
# WHY A NAMESPACE BIND: on Android 11+ the game is scoped-storage isolated and can
# only see its own /sdcard/Android/data/<pkg> sandbox — it cannot read
# /sdcard/UnrealModloader at all, and NO appop (NO_ISOLATED_STORAGE / LEGACY_STORAGE
# / MANAGE_EXTERNAL_STORAGE) moves that mount; the mount view is fixed at process
# fork. The fix is mount propagation: init (PID 1) has /storage/emulated as a
# `shared` mount and every app's copy is a SLAVE of it, so a bind created UNDER
# init's mount namespace propagates to every app process, present and future. We
# bind the raw /data/media view onto the FUSE path there; the isolated game then
# reads /sdcard/UnrealModloader/<pkg> directly. The modloader is configured to use
# that public path (paths.cpp), so there is no scoped fallback to recreate.
#
# AUTO-DISCOVERS every package with a public store — never hardcode a package.

UML=/data/media/0/UnrealModloader
INIT_NS=/proc/1/ns/mnt

# Wait for real storage to be up (FUSE/passthrough appear a bit after boot).
i=0
until [ -d "$UML" ] || [ $i -ge 60 ]; do sleep 2; i=$((i+1)); done
[ -d "$UML" ] || exit 0

for PUB in "$UML"/*; do
  [ -d "$PUB" ] || continue
  PKG=${PUB##*/}
  # Package names always contain a dot; skip stray files (lsposed_targets.txt etc.)
  case "$PKG" in
    *.*) ;;
    *) continue ;;
  esac

  # The game's uid reaches the content through the bind, so it must be world-rwx.
  chmod -R 0777 "$PUB" 2>/dev/null
  restorecon -R "$PUB" 2>/dev/null

  DST=/storage/emulated/0/UnrealModloader/$PKG

  # Do the bind INSIDE init's namespace so it propagates to all app slaves.
  # Idempotent: skip if a mount already exists at exactly this mount point
  # (field 5 of mountinfo). `mountpoint -q` cannot answer — public and scoped are
  # the same fs, so it reports "not a mountpoint" even when a bind is live.
  nsenter --mount="$INIT_NS" -- sh -c '
    PUB="'"$PUB"'"; DST="'"$DST"'"
    awk -v d="$DST" '"'"'$5==d{f=1} END{exit !f}'"'"' /proc/1/mountinfo && exit 0
    mkdir -p "$DST" 2>/dev/null
    mount --bind "$PUB" "$DST"
  ' && log -t UMLMirror "bound $PUB -> $DST (init ns, propagates to apps)"
done
