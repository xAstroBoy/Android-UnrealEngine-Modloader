# Quest Modloader MCP servers

Two global MCP servers that let Claude drive the Quest UE4/UE5 modloader and the
device it runs on — registered in `~/.claude.json`, so they're available in every
project.

| Server | File | What it's for |
|---|---|---|
| **ue-modloader** | `ue_modloader_mcp.py` | The modloader's full power: live Lua bridge, deploy/hot-reload, install/uninstall mods, storage mirror, logs, tombstones |
| **adb** | `adb_mcp.py` | General Android Debug Bridge: shell, push/pull (root-aware), forward, install, APK/OBB/.so extraction, run-script |

Both invoke `adb` via **subprocess argument lists** (never a shell), so Windows /
Git-Bash / MSYS **path mangling never happens** — `/data/...`, `/sdcard/...`,
`/data/local/tmp/...` reach the device intact. (Running adb through Git-Bash rewrites
`/data/local/tmp` into `C:/Program Files/Git/data/...`; that class of bug is why the
adb server exists.)

> **Rule of thumb:** do device work through these MCP tools, never `adb` in the Bash
> tool.

---

## Setup

Requirements: Python 3.8+ with `mcp` installed (`pip install mcp`), and `adb` on PATH
(or set the `ADB` env var). A Quest with Magisk root + the modloader injected
(LSPosed). Both are already registered in `~/.claude.json`; reload MCP servers (new
Claude Code session, or `/mcp`) to pick them up.

### Config (all optional)

`ue-modloader` resolves game, device, and paths automatically. Override via env or
`~/.ue_modloader_mcp.json`:

| Env | `~/.ue_modloader_mcp.json` key | Default |
|---|---|---|
| `UE_GAME` | `game` | `pfx` |
| `UE_ADB_SERIAL` | `serial` | the single online device |
| `UE_MODLOADER_ROOT` | `root` | the repo containing `mcp/` |
| `UE_BRIDGE_PORT` | `bridge_port` | `19420` |
| `UE_ADB` | `adb` | `adb` |

`adb` resolves the serial from `serial` arg → `ANDROID_SERIAL`/`ADB_SERIAL` → the
single online device. Set the binary via `ADB`.

Games: `pfx` (com.zenstudios.PFXVRQuest), `re4` (com.Armature.VR4),
`handboi` (com.Capricia.HandBoi). Every `ue-modloader` tool takes an optional `game`.

---

## Storage model — everything lives in the PUBLIC store

The **public store `/sdcard/UnrealModloader/<pkg>/`** is the single source of truth for
all mods, logs, and the SDK dump. It's MTP/SFTP-visible and editable. `MANAGE_EXTERNAL_STORAGE`
is **never** granted (it SIGKILLs the game), so the injected modloader resolves its
data dir to the game's *scoped* path — and a **root bind-mount mirrors public → scoped**
(`su -M mount --bind` in the global namespace + `chmod -R 0777`) so the game reads the
public store transparently. Nothing should live in the scoped path directly.

The `mirror` tool (re)establishes that bind on demand; `deploy_mods` / `install_mod`
call it automatically after pushing, which is what makes a freshly-pushed mod readable
by the running game (otherwise it's `0644`/shell-owned in scoped → "Permission denied").

---

## ue-modloader tools (44)

**Config / device:** `ue_config`, `adb_devices`, `adb_shell_cmd`, `adb_forward`

**Bridge (live modloader power, TCP 19420, auto-forwarded):**
`bridge_ping`, `bridge_help`, `bridge_exec_lua`, `bridge_exec_console`, `bridge_stats`,
`bridge_object_count`, `bridge_list_mods`, `bridge_reload_mod`, `bridge_load_mod`,
`bridge_list_hooks`, `bridge_find_object`, `bridge_find_class`, `bridge_dump_sdk`,
`bridge_dump_ida`, `bridge_dump_symbols`, `bridge_dump_console_commands`,
`bridge_list_paks`, `bridge_mount_pak`, `bridge_log_tail`, `bridge_aes`,
`bridge_pe_trace`, `bridge_raw`

**Deploy / mods / lifecycle:**
`deploy_mods` (push + hot-reload), `deploy_file`, `install_mod`, `uninstall_mod`,
`mirror`, `game_status`, `game_launch`, `game_restart`, `game_ensure`

**Logs:** `pull_log`, `pull_crashlog`, `pull_pe_trace`, `livelog`, `pull_sdk`

**Crash forensics / tombstones:** `tombstone_list`, `tombstone_latest`, `tombstone_wipe`,
`diagnose`

### Common flows

```
# Iterate a Lua mod (no restart) — the standard loop:
deploy_mods(game="pfx", mod="PFX_Movement", hot=True)

# Test a snippet live before writing mod code:
bridge_exec_lua('local pc=FindFirstOf("PlayerController"); return pc:GetName()')

# Install a brand-new mod from anywhere, into the public store, loaded live:
install_mod(game="pfx", source=r"C:\path\to\MyMod")     # or a name under mods/pfx/
uninstall_mod(game="pfx", name="MyMod")

# Force the storage mirror (e.g. after adding mods while the game runs):
mirror(game="pfx", action="on")     # status | on | off

# Crash investigation — grab newest tombstone, read it, then wipe all:
tombstone_latest()
tombstone_wipe()                    # archives locally first, then rm /data/tombstones/*
diagnose(game="pfx")                # PID + tombstone + crashlog + log tail, one shot
```

---

## adb tools (30)

**Devices/connection:** `devices`, `connect`, `disconnect`, `reboot`,
`wait_for_device`, `get_state`

**Shell / scripting:** `shell` (root optional), `run_script` (push+run a whole sh
script — `su -M` global-namespace or `nsenter -t <pid>` per-app; the clean way to do
bind-mounts and other multi-step root work without quoting hell)

**Files:** `push`, `pull`, `push_root`, `pull_root`

**Networking:** `forward`, `forward_list`, `forward_remove`, `reverse`

**Packages/processes:** `install`, `uninstall`, `list_packages`, `pidof`,
`force_stop`, `start_app`

**App extraction:** `package_info` (APK/OBB/lib dirs + version), `pull_apk`,
`pull_obb`, `pull_lib` (native `.so`)

**Diagnostics:** `logcat`, `getprop`, `dumpsys`, `raw` (arbitrary adb args)

### Examples

```
package_info("com.zenstudios.PFXVRQuest")     # where APK/OBB/libs live
pull_lib("com.zenstudios.PFXVRQuest", lib="Unreal")   # libUnreal.so for RE
pull_obb("com.zenstudios.PFXVRQuest")          # main.obb + pakchunk*.pak
pull_apk("com.zenstudios.PFXVRQuest")          # base + splits
raw('["shell","ls","-la","/sdcard"]')          # anything not wrapped above
```
