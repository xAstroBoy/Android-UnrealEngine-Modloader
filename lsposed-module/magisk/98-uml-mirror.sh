#!/system/bin/sh
# UnrealModloader storage mirror — runs at every boot (bind mounts never survive
# a reboot). The PUBLIC store /data/media/0/UnrealModloader/<pkg> (= the
# /storage/emulated/0/UnrealModloader/<pkg> you actually put files in) is THE
# source of truth, and gets bind-mounted over the game's scoped dir so the loader
# reads it transparently with no MANAGE_EXTERNAL_STORAGE and no app changes.
# Scoped is never a real store — it is only ever a doorway to the public one.
#
# AUTO-DISCOVERS every package that has a public store. It used to be a hardcoded
# `for PKG in com.zenstudios.PFXVRQuest`, which meant RE4 (and every game added
# after PFX) NEVER got a mount after a reboot: the loader silently fell back to
# scoped and mods dropped in the public store simply did not load. Never hardcode
# the list again — a new game must work by creating its folder, nothing else.

UML=/data/media/0/UnrealModloader

for PUB in "$UML"/*; do
  [ -d "$PUB" ] || continue
  PKG=${PUB##*/}
  # Package names always contain a dot; skips stray files like lsposed_targets.txt
  case "$PKG" in
    *.*) ;;
    *) continue ;;
  esac

  # ANY package name works — no install check, no allow-list. Drop a folder named
  # after the package into UnrealModloader/ and it gets mounted, whether the app
  # is installed yet or not. (Creating the scoped tree for a not-yet-installed app
  # is harmless; Android reuses it when the app appears.)
  SCOPED=/data/media/0/Android/data/$PKG/files/modloader
  mkdir -p "$SCOPED" "$PUB"

  # Already bound? `mountpoint -q` CANNOT answer this: public and scoped live on
  # the SAME filesystem (/data), so it reports "not a mountpoint" even when the
  # bind is live and the contents are demonstrably shared — verified on-device.
  # A bind makes both paths resolve to the SAME inode, so compare device:inode.
  PI=$(stat -c '%d:%i' "$PUB" 2>/dev/null)
  SI=$(stat -c '%d:%i' "$SCOPED" 2>/dev/null)
  if [ -n "$PI" ] && [ "$PI" = "$SI" ]; then
    continue                      # already bound — don't stack another mount
  fi

  # Migrate anything the game wrote while unbound into the public store.
  # -n = no-clobber: whatever is already public wins.
  cp -an "$SCOPED/." "$PUB/" 2>/dev/null

  mount --bind "$PUB" "$SCOPED" || continue

  # The game's uid must be able to read/write everything through the bind.
  chmod -R 0777 "$PUB" 2>/dev/null
  restorecon -R "$PUB" 2>/dev/null
  log -t UMLMirror "bound $PUB -> $SCOPED"
done
