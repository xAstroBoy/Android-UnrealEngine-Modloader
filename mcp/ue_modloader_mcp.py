#!/usr/bin/env python3
r"""
UE Modloader — a global MCP server that gives Claude the *full power* of the
arm64 UE4/UE5 Quest modloader from any project.

It wraps three things:

  1. The live ADB **bridge** (TCP 127.0.0.1:19420) — exec_lua on the game thread,
     UE console commands, SDK/IDA dumps, PE tracing, AES key extraction, hot mod
     reload, object/class lookup, stats … every command the modloader exposes.
  2. **Deploy + lifecycle** over ADB — push Lua mods with hot-reload (no restart),
     launch/restart/status the game, pull the SDK dump.
  3. **Crash forensics** — pull/print modloader + crash logs, and the headline
     feature: grab the latest native **tombstone** and **wipe them all**.

Design notes
------------
* All device I/O goes through `adb` invoked directly (arg lists, shell=False), so
  MSYS/Git-Bash path mangling never happens — `/data/...` reaches the device intact.
* Root actions use Magisk `su -c '...'` (same trick the quest-ssh module uses).
* The bridge auto-forwards tcp:19420 before every call, so bridge tools just work.
* Games, device serial, and repo root are auto-resolved but overridable via env
  (UE_GAME / UE_ADB_SERIAL / UE_MODLOADER_ROOT / UE_BRIDGE_PORT / UE_ADB) or
  ~/.ue_modloader_mcp.json.

Registered globally in ~/.claude.json so it's available in every project.
"""
import json
import os
import re
import socket
import subprocess
import sys
import time

try:
    from mcp.server.fastmcp import FastMCP
except ImportError:
    sys.stderr.write("ue-modloader-mcp: mcp missing -> pip install mcp\n")
    raise

# ─── Static game table ────────────────────────────────────────────────────────
GAMES = {
    "pfx": {
        "pkg": "com.zenstudios.PFXVRQuest",
        "src": "pfx",
        "label": "Pinball FX VR",
        "aliases": ["pfxvr", "pinball", "pinballfx", "zen"],
        # VR apps have no LAUNCHER category, so `monkey -c LAUNCHER` fails
        # ("No activities found to run") — launch this explicit component.
        "activity": "com.epicgames.unreal.GameActivity",
    },
    "re4": {
        "pkg": "com.Armature.VR4",
        "src": "re4",
        "label": "Resident Evil 4 VR",
        "aliases": ["re4vr", "residentevil", "armature"],
    },
    "handboi": {
        "pkg": "com.Capricia.HandBoi",
        "src": "handboi",
        "label": "Hand Boi",
        "aliases": ["hb", "hand", "capricia"],
    },
}

# Storage model (see memory: lsposed-storage-appop-gotcha).
# The PUBLIC store is the single source of truth — all mods/logs/SDK live here and
# it's MTP/SFTP-visible. A root bind-mount mirrors it ONTO the game's scoped dir so
# the injected modloader (which resolves its data dir to the scoped path because
# MANAGE_EXTERNAL_STORAGE is never granted) reads/writes the public store
# transparently. Nothing should live in the scoped path directly.
PUBLIC_DIR_TMPL = "/sdcard/UnrealModloader/{pkg}"          # == /data/media/0/UnrealModloader/<pkg>
PUBLIC_DIR_ABS_TMPL = "/data/media/0/UnrealModloader/{pkg}"
SCOPED_DIR_TMPL = "/sdcard/Android/data/{pkg}/files/modloader"
SCOPED_DIR_ABS_TMPL = "/data/media/0/Android/data/{pkg}/files/modloader"

TOMBSTONE_DIR = "/data/tombstones"
BRIDGE_PORT_DEFAULT = 19420

# ─── Config resolution ────────────────────────────────────────────────────────
def _load_cfg():
    cfg = {}
    path = os.path.expanduser("~/.ue_modloader_mcp.json")
    if os.path.exists(path):
        try:
            with open(path) as f:
                cfg = json.load(f)
        except Exception:
            pass
    return cfg


_CFG = _load_cfg()


def _here():
    return os.path.dirname(os.path.abspath(__file__))


def repo_root():
    env = os.environ.get("UE_MODLOADER_ROOT") or _CFG.get("root")
    if env:
        return os.path.abspath(os.path.expanduser(env))
    # script lives at <root>/mcp/ue_modloader_mcp.py
    return os.path.dirname(_here())


def adb_bin():
    return os.environ.get("UE_ADB") or _CFG.get("adb") or "adb"


def bridge_port():
    try:
        return int(os.environ.get("UE_BRIDGE_PORT") or _CFG.get("bridge_port") or BRIDGE_PORT_DEFAULT)
    except (TypeError, ValueError):
        return BRIDGE_PORT_DEFAULT


def default_game():
    return (os.environ.get("UE_GAME") or _CFG.get("game") or "pfx").lower()


def resolve_game(game=None):
    """Return (key, info) for a game name / alias / package. Defaults to config."""
    g = (game or default_game()).lower().strip()
    if g in GAMES:
        return g, GAMES[g]
    for key, info in GAMES.items():
        if g == info["pkg"].lower() or g in info["aliases"]:
            return key, info
    raise ValueError(
        "unknown game %r — known: %s" % (game, ", ".join(GAMES.keys()))
    )


# ─── ADB serial resolution ────────────────────────────────────────────────────
def _list_devices():
    """Return list of (serial, state) from `adb devices`."""
    try:
        p = subprocess.run([adb_bin(), "devices"], capture_output=True, text=True, timeout=15)
    except Exception as e:
        return [], "adb error: %s" % e
    rows = []
    for line in p.stdout.splitlines()[1:]:
        line = line.strip()
        if not line or "\t" not in line:
            continue
        serial, state = line.split("\t", 1)
        rows.append((serial.strip(), state.strip()))
    return rows, None


_SERIAL_CACHE = {"val": None}


def current_serial():
    """Explicit override, else the single online device, else None (adb picks)."""
    env = os.environ.get("UE_ADB_SERIAL") or _CFG.get("serial")
    if env:
        return env
    if _SERIAL_CACHE["val"]:
        return _SERIAL_CACHE["val"]
    rows, _ = _list_devices()
    online = [s for s, st in rows if st == "device"]
    if len(online) == 1:
        _SERIAL_CACHE["val"] = online[0]
        return online[0]
    return None  # 0 or >1 → let adb decide / error out with a clear message


# ─── ADB primitives (no shell, no MSYS mangling) ──────────────────────────────
class AdbError(RuntimeError):
    pass


def _adb(args, timeout=120, text=True, want=("stdout", "stderr", "rc")):
    serial = current_serial()
    cmd = [adb_bin()]
    if serial:
        cmd += ["-s", serial]
    cmd += args
    try:
        p = subprocess.run(cmd, capture_output=True, text=text, timeout=timeout)
    except FileNotFoundError:
        raise AdbError("adb not found (%r). Set UE_ADB or add adb to PATH." % adb_bin())
    except subprocess.TimeoutExpired:
        raise AdbError("adb timed out after %ss: %s" % (timeout, " ".join(args[:3])))
    out = p.stdout if text else p.stdout
    err = p.stderr if text else p.stderr
    return {"stdout": out, "stderr": err, "rc": p.returncode}


def adb_shell(devcmd, timeout=120):
    """Run a command in the device shell. `devcmd` is one string sent verbatim."""
    r = _adb(["shell", devcmd], timeout=timeout)
    return r


def _su_wrap(devcmd):
    esc = devcmd.replace("'", "'\\''")
    return "su -c '%s'" % esc


def adb_shell_root(devcmd, timeout=120):
    """Run a command as root via Magisk `su -c`."""
    return adb_shell(_su_wrap(devcmd), timeout=timeout)


def adb_push(local, remote, timeout=300):
    return _adb(["push", local, remote], timeout=timeout)


def adb_pull(remote, local, timeout=300):
    return _adb(["pull", remote, local], timeout=timeout)


def _dir_exists(path, root=False):
    cmd = '[ -d "%s" ] && echo YES || echo NO' % path
    r = adb_shell_root(cmd) if root else adb_shell(cmd)
    return "YES" in (r["stdout"] or "")


def public_data_dir(game=None):
    """The truth store — always the public path, never scoped."""
    _, info = resolve_game(game)
    return PUBLIC_DIR_TMPL.format(pkg=info["pkg"])


def scoped_data_dir(game=None):
    """The game's scoped data dir (bind-mount target). Used for the mirror and for
    cleaning up any stale files that leaked into scoped."""
    _, info = resolve_game(game)
    return SCOPED_DIR_TMPL.format(pkg=info["pkg"])


# All file-facing tools operate on the public store.
def device_data_dir(game=None):
    """Back-compat alias: the modloader data dir we read/write = the public store."""
    return public_data_dir(game)


def _resolve_existing_file(game, rel):
    """Return a (path, root) tuple for a data-dir file, preferring the public store
    but falling back to the scoped path (root) if the mirror isn't active and the
    file only exists there. `rel` is like 'UEModLoader.log'."""
    pub = "%s/%s" % (public_data_dir(game), rel)
    if _file_exists(pub):
        return pub, False
    scoped = "%s/%s" % (scoped_data_dir(game), rel)
    if _file_exists(scoped, root=True):
        return scoped, True
    return pub, False  # default to public (may not exist yet)


def _file_exists(path, root=False):
    cmd = '[ -f "%s" ] && echo YES || echo NO' % path
    r = adb_shell_root(cmd) if root else adb_shell(cmd)
    return "YES" in (r["stdout"] or "")


# ─── device script runner (avoids nested-quoting hell) ────────────────────────
import tempfile as _tempfile


def run_device_script(script, magic_mount=False, root=True, timeout=180):
    """Push a shell script to the device and run it — under `su -M` (global mount
    namespace, needed for bind-mounts that must reach running apps) when
    magic_mount=True, else `su -c`, else plain sh. Returns the adb result dict."""
    body = script if script.startswith("#!") else "#!/system/bin/sh\n" + script
    tf = _tempfile.NamedTemporaryFile("w", suffix=".sh", delete=False, newline="\n")
    try:
        tf.write(body.replace("\r\n", "\n"))
        tf.close()
        remote = "/data/local/tmp/_uml_%d.sh" % (abs(hash(script)) % 10_000_000)
        pp = adb_push(tf.name, remote, timeout=60)
        if pp["rc"] != 0:
            return {"rc": pp["rc"], "stdout": "", "stderr": "push failed: %s" % pp.get("stderr")}
        adb_shell("chmod 755 %s" % remote, timeout=15)
        if magic_mount:
            dev = "su -M -c 'sh %s'" % remote
        elif root:
            dev = "su -c 'sh %s'" % remote
        else:
            dev = "sh %s" % remote
        r = adb_shell(dev, timeout=timeout)
        adb_shell("rm -f %s" % remote, timeout=15)
        return r
    finally:
        try:
            os.unlink(tf.name)
        except OSError:
            pass


# ─── public→scoped bind mirror (keeps everything out of the scoped path) ──────
def _mirror_script(pkg):
    """The exact bindPublicToScoped method: public store is truth, no-clobber
    migrate anything the game wrote while unbound, world-readable, bind over scoped."""
    pub = PUBLIC_DIR_ABS_TMPL.format(pkg=pkg)
    scoped = SCOPED_DIR_ABS_TMPL.format(pkg=pkg)
    return (
        'PKG="%s"\n'
        'PUB="%s"\n'
        'SCOPED="%s"\n'
        'mkdir -p "$PUB/mods"\n'
        'if [ -d "$SCOPED" ]; then cp -an "$SCOPED/." "$PUB/" 2>/dev/null; fi\n'
        'chmod -R 0777 "$PUB" 2>/dev/null\n'
        'if mountpoint -q "$SCOPED"; then echo ALREADY-BOUND; '
        'else mkdir -p "$SCOPED" 2>/dev/null; '
        'mount --bind "$PUB" "$SCOPED" && echo BOUND-NOW || echo BIND-FAILED; fi\n'
    ) % (pkg, pub, scoped)


def ensure_mirror(game=None):
    """Idempotently (re)establish the public→scoped bind in the global mount
    namespace (su -M) so a running game sees the public store. Returns a short
    status string ('ALREADY-BOUND' / 'BOUND-NOW' / 'BIND-FAILED: ...')."""
    _, info = resolve_game(game)
    r = run_device_script(_mirror_script(info["pkg"]), magic_mount=True, timeout=60)
    out = (r["stdout"] or "").strip()
    if "ALREADY-BOUND" in out:
        return "ALREADY-BOUND"
    if "BOUND-NOW" in out:
        return "BOUND-NOW"
    return "BIND-FAILED: %s" % (out or (r["stderr"] or "").strip() or "unknown")


def _sync_script(pkg):
    """Mirror the public store's mods dir INTO the scoped path the injected
    modloader actually reads. This replaces the `su -M` bind mirror, which lives
    in the global mount namespace and is invisible to an already-running game
    (and hangs). A plain root COPY always reaches the modloader. Reflects the
    full public mods folder — additions AND deletions — then makes every file
    world-readable so the game process can load it."""
    pub = PUBLIC_DIR_ABS_TMPL.format(pkg=pkg)
    scoped = SCOPED_DIR_ABS_TMPL.format(pkg=pkg)
    return (
        'PUB="%s"\n'
        'SCOPED="%s"\n'
        'if [ ! -d "$PUB/mods" ]; then echo "NO-PUBLIC"; exit 0; fi\n'
        'mkdir -p "$SCOPED/mods"\n'
        'OWN=$(stat -c "%%u:%%g" "$SCOPED" 2>/dev/null)\n'
        'rm -rf "$SCOPED/mods"/* 2>/dev/null\n'
        'cp -a "$PUB/mods/." "$SCOPED/mods/" 2>/dev/null\n'
        '[ -n "$OWN" ] && chown -R "$OWN" "$SCOPED/mods" 2>/dev/null\n'
        'chmod -R 0777 "$SCOPED/mods" 2>/dev/null\n'
        'restorecon -R "$SCOPED" 2>/dev/null\n'
        'echo "SYNCED:$(ls -1 "$SCOPED/mods" 2>/dev/null | wc -l)"\n'
    ) % (pub, scoped)


def sync_scoped(game=None):
    """Copy the public store's mods into the scoped path the modloader reads.
    Fast (`su -c`, no bind, no hang). Returns e.g. 'SYNCED:13' or an error."""
    _, info = resolve_game(game)
    try:
        r = run_device_script(_sync_script(info["pkg"]), root=True, timeout=60)
    except AdbError as e:
        return "SYNC-FAILED: %s" % e
    out = (r["stdout"] or "").strip().splitlines()
    for line in reversed(out):
        if line.startswith("SYNCED:") or line == "NO-PUBLIC":
            return line
    return "SYNC-FAILED: %s" % (out or (r["stderr"] or "").strip() or "unknown")


# ─── Bridge (TCP 127.0.0.1:19420) ─────────────────────────────────────────────
_FWD_DONE = {"val": False}


def ensure_forward():
    if _FWD_DONE["val"]:
        return
    port = bridge_port()
    _adb(["forward", "tcp:%d" % port, "tcp:%d" % port], timeout=15)
    _FWD_DONE["val"] = True


def bridge_send(payload, timeout=15):
    """Send one JSON command to the bridge, return the parsed reply dict.

    Reply shape from the modloader: {"ok": true, "result": ...} or
    {"ok": false, "error": "..."}.  Raises AdbError on connectivity problems.
    """
    ensure_forward()
    port = bridge_port()
    s = socket.socket()
    s.settimeout(timeout)
    try:
        s.connect(("127.0.0.1", port))
    except Exception as e:
        raise AdbError(
            "bridge connect failed on 127.0.0.1:%d (%s). Is the game running with the "
            "modloader injected? Try game_status / game_launch." % (port, e)
        )
    try:
        s.sendall(json.dumps(payload).encode() + b"\n")
        data = b""
        while True:
            try:
                chunk = s.recv(65536)
            except socket.timeout:
                break
            if not chunk:
                break
            data += chunk
            if b"\n" in data:
                break
    finally:
        s.close()
    line = data.split(b"\n")[0].strip()
    if not line:
        return {"ok": False, "error": "empty reply (game thread busy or timed out)"}
    try:
        return json.loads(line.decode("utf-8", "replace"))
    except Exception:
        return {"ok": False, "error": "unparseable reply", "raw": data.decode("utf-8", "replace")}


def _fmt_bridge(reply):
    """Format a bridge reply for return to the model."""
    if isinstance(reply, dict) and reply.get("ok"):
        res = reply.get("result")
        if isinstance(res, (dict, list)):
            return json.dumps(res, indent=2)
        return str(res)
    if isinstance(reply, dict):
        err = reply.get("error", "unknown error")
        extra = ("\n--- raw ---\n" + reply["raw"]) if reply.get("raw") else ""
        return "ERROR: %s%s" % (err, extra)
    return str(reply)


# ─── MCP server ───────────────────────────────────────────────────────────────
mcp = FastMCP("ue-modloader")


# ═══ Config / device ══════════════════════════════════════════════════════════
@mcp.tool()
def ue_config() -> str:
    """Show the resolved configuration: active game, package, ADB serial, bridge
    port, repo root, local mod source dir, and the live on-device data/log paths.
    Call this first if anything behaves unexpectedly."""
    key, info = resolve_game()
    serial = current_serial()
    try:
        ddir = device_data_dir(key)
    except Exception as e:
        ddir = "unresolved (%s)" % e
    out = {
        "default_game": key,
        "game_label": info["label"],
        "package": info["pkg"],
        "adb": adb_bin(),
        "adb_serial": serial or "(auto — set UE_ADB_SERIAL if ambiguous)",
        "bridge_port": bridge_port(),
        "repo_root": repo_root(),
        "local_mods_dir": os.path.join(repo_root(), "mods", info["src"]),
        "device_data_dir": ddir,
        "device_log": ddir + "/UEModLoader.log",
        "device_crashlog": ddir + "/modloader_crash.log",
        "device_pe_trace": ddir + "/pe_trace.log",
        "device_sdk": ddir + "/SDK/",
        "tombstone_dir": TOMBSTONE_DIR,
        "known_games": {k: v["pkg"] for k, v in GAMES.items()},
    }
    return json.dumps(out, indent=2)


@mcp.tool()
def adb_devices() -> str:
    """List all ADB devices and their connection state."""
    rows, err = _list_devices()
    if err:
        return err
    if not rows:
        return "(no devices — connect the Quest or `adb connect <ip>:5555`)"
    active = current_serial()
    lines = []
    for serial, state in rows:
        mark = "  <- active" if serial == active else ""
        lines.append("%-24s %s%s" % (serial, state, mark))
    return "\n".join(lines)


@mcp.tool()
def adb_shell_cmd(command: str, root: bool = False, timeout: int = 120) -> str:
    """Run an arbitrary command in the device shell. Set root=True to run it via
    Magisk `su -c`. Returns exit code, stdout and stderr. Paths like /data/... are
    passed through intact (no Git-Bash mangling)."""
    r = adb_shell_root(command, timeout=timeout) if root else adb_shell(command, timeout=timeout)
    return "exit=%s\n--- stdout ---\n%s\n--- stderr ---\n%s" % (
        r["rc"], (r["stdout"] or "").rstrip(), (r["stderr"] or "").rstrip()
    )


@mcp.tool()
def adb_forward() -> str:
    """(Re)establish the ADB port-forward for the bridge (tcp:19420 → device)."""
    _FWD_DONE["val"] = False
    ensure_forward()
    return "forwarded tcp:%d -> device tcp:%d" % (bridge_port(), bridge_port())


# ═══ Bridge — the modloader's full power ══════════════════════════════════════
@mcp.tool()
def bridge_ping() -> str:
    """Ping the modloader bridge. Returns 'pong' if the game is running with the
    modloader injected and reachable."""
    try:
        return _fmt_bridge(bridge_send({"cmd": "ping"}, timeout=6))
    except AdbError as e:
        return "ERROR: %s" % e


@mcp.tool()
def bridge_help() -> str:
    """List every command the live bridge accepts — built-ins plus any custom
    commands Lua mods registered at runtime."""
    return _fmt_bridge(bridge_send({"cmd": "help"}))


@mcp.tool()
def bridge_exec_lua(code: str, timeout: int = 15) -> str:
    """Execute a Lua snippet on the game thread via the modloader and return its
    result. This is the single most powerful tool: full UE4/UE5 reflection —
    FindFirstOf / FindAllOf, obj:Get/Set/Call, hooks, structs, memory R/W, etc.

    Always `return` a value (string/number/table-as-string) to see output. The
    game-thread execution is capped at ~8s and 10M instructions server-side.

    Example: bridge_exec_lua('local pc=FindFirstOf("PlayerController"); return pc:GetName()')
    """
    try:
        return _fmt_bridge(bridge_send({"cmd": "exec_lua", "code": code}, timeout=max(timeout, 10)))
    except AdbError as e:
        return "ERROR: %s" % e


@mcp.tool()
def bridge_exec_console(command: str) -> str:
    """Run a UE console command via PlayerController::ConsoleCommand (works in
    shipping builds). Example: 'stat fps', 'stat unit', 'r.SetRes 1280x720'."""
    try:
        return _fmt_bridge(bridge_send({"cmd": "exec_console", "command": command}, timeout=12))
    except AdbError as e:
        return "ERROR: %s" % e


@mcp.tool()
def bridge_stats() -> str:
    """Live modloader stats: uptime, mods loaded/failed, known classes/structs/
    enums, live object count, hook call totals, AES key count."""
    return _fmt_bridge(bridge_send({"cmd": "get_stats"}))


@mcp.tool()
def bridge_object_count() -> str:
    """Live UObject count, growth since last reflection walk, and known type
    counts. Good for spotting object leaks / spikes."""
    return _fmt_bridge(bridge_send({"cmd": "object_count"}))


# ═══════════════════════════════════════════════════════════════════════════
# MEMORY TOOLS — Cheat-Engine-style scanner / inspector / hardware watchpoint /
# AOB. Backed by native functions in the modloader (src/lua/lua_memtools.cpp),
# driven over the bridge so they persist across sessions/restarts.
# ═══════════════════════════════════════════════════════════════════════════

def _addr(x):
    """Parse an address given as int, hex ('0x..') or decimal string → int."""
    if isinstance(x, int):
        return x
    s = str(x).strip()
    return int(s, 16) if s.lower().startswith("0x") else int(s, 0)


def _luaval(v):
    """Render a scan value for Lua: nil when None, else numeric literal."""
    return "nil" if v is None else repr(float(v)) if isinstance(v, float) else str(v)


@mcp.tool()
def mem_read(addr: str, type: str = "u64") -> str:
    """Read a typed value from memory (via /proc/self/mem — works on protected/
    PROT_NONE pages). type: u8/u16/u32/u64/i32/f32."""
    a = _addr(addr)
    lua = ("local a=" + str(a) + "; local t='" + type + "'; local v;"
           "if t=='u64' or t=='i64' then v=MemReadU64(a)"
           " elseif t=='u32' then v=MemReadU32(a)"
           " elseif t=='i32' then local x=MemReadU32(a); v=(x>=2147483648) and (x-4294967296) or x"
           " elseif t=='u16' then v=MemReadU16(a)"
           " elseif t=='u8' then v=MemReadU8(a)"
           " elseif t=='f32' then v=MemReadFloat(a)"
           " else v=MemReadU64(a) end;"
           "return string.format('0x%X = %s (%s)', a, tostring(v), t)")
    return bridge_exec_lua(lua)


@mcp.tool()
def mem_write(addr: str, value: float, type: str = "u64") -> str:
    """Write a typed value to memory. type: u8/u16/u32/u64/f32. Returns ok/fail."""
    a = _addr(addr)
    lua = ("local a=" + str(a) + "; local t='" + type + "'; local v=" + str(value) + "; local ok;"
           "if t=='u32' or t=='i32' then ok=MemWriteU32(a,v)"
           " elseif t=='u16' then ok=MemWriteU16(a,v)"
           " elseif t=='u8' then ok=MemWriteU8(a,v)"
           " elseif t=='f32' then ok=MemWriteFloat(a,v)"
           " else ok=MemWriteU64(a,v) end;"
           "return string.format('write 0x%X = %s (%s) -> %s', a, tostring(v), t, tostring(ok))")
    return bridge_exec_lua(lua)


@mcp.tool()
def mem_read_bytes(addr: str, length: int = 32) -> str:
    """Read `length` bytes (max 4096) at addr → lowercase hex string."""
    a = _addr(addr)
    return bridge_exec_lua("return MemReadBytes(" + str(a) + ", " + str(int(length)) + ")")


@mcp.tool()
def mem_regions(filter: str = "") -> str:
    """List process memory regions (/proc/self/maps): start/end/size/perms/path.
    Optional substring filter (e.g. 'libUnreal.so', 'heap')."""
    lua = ("local r=MemRegions(" + ("'" + filter + "'" if filter else "nil") + "); local o={};"
           "for i,x in ipairs(r) do o[#o+1]=string.format('0x%X-0x%X %s %-9d %s', x.start, x['end'], x.perms, x.size, x.path) end;"
           "return tostring(#r)..' regions\\n'..table.concat(o,'\\n')")
    return bridge_exec_lua(lua)


@mcp.tool()
def sym_addr(addr: str) -> str:
    """Symbolize an absolute address → module + 0xOFFSET (offset == IDA RVA for
    imagebase-0 libs like libUnreal.so). Use to turn a scan/watch hit into an RVA."""
    a = _addr(addr)
    lua = ("local r=SymAddr(" + str(a) + ");"
           "return string.format('0x%X = %s+0x%X (base 0x%X)', " + str(a) + ", r.module, r.off, r.base or 0)")
    return bridge_exec_lua(lua)


@mcp.tool()
def module_base(name: str = "libUnreal.so") -> str:
    """Get a module's load base (lowest mapping). runtime_addr = base + IDA_RVA."""
    return bridge_exec_lua("return string.format('0x%X', ModuleBase('" + name + "'))")


@mcp.tool()
def mem_scan_first(type: str, cmp: str, value: float = None, heap_only: bool = True) -> str:
    """First value scan (Cheat-Engine style). type: i8/u8/i16/u16/i32/u32/i64/u64/
    f32/f64. cmp: 'eq','ne','gt','lt','ge','le' (need value) or 'unknown' (snapshot
    all for later next-scans). heap_only limits to anon/heap regions (default true).
    Returns match count — then use mem_scan_next / mem_scan_list."""
    lua = ("return MemScanFirst('" + type + "','" + cmp + "'," + _luaval(value) + "," +
           ("true" if heap_only else "false") + ")")
    return bridge_exec_lua(lua, timeout=30)


@mcp.tool()
def mem_scan_next(cmp: str, value: float = None) -> str:
    """Refine the current scan. cmp: 'changed','unchanged','increased','decreased'
    (vs previous snapshot) or 'eq','ne','gt','lt','ge','le' (vs value). Returns count."""
    return bridge_exec_lua("return MemScanNext('" + cmp + "'," + _luaval(value) + ")", timeout=30)


@mcp.tool()
def mem_scan_list(offset: int = 0, limit: int = 100) -> str:
    """List current scan results as addr = value (paged)."""
    lua = ("local r=MemScanList(" + str(int(offset)) + "," + str(int(limit)) + "); local o={};"
           "for i,e in ipairs(r) do o[#o+1]=string.format('0x%X = %s', e.addr, tostring(e.value)) end;"
           "return string.format('total=%d showing %d:\\n%s', MemScanCount(), #r, table.concat(o,'\\n'))")
    return bridge_exec_lua(lua)


@mcp.tool()
def mem_scan_reset() -> str:
    """Clear the current scan result set."""
    return bridge_exec_lua("MemScanReset(); return 'scan cleared'")


@mcp.tool()
def watch_access(addr: str, length: int = 8, mode: str = "w") -> str:
    """Arm an ARM64 HARDWARE watchpoint on addr (len 1/2/4/8). mode: 'w' write,
    'r' read, 'rw' both. Returns a watch fd. Let the game run, then watch_read(fd).
    Prefer find_what_writes() for a one-shot arm→wait→read→stop."""
    a = _addr(addr)
    return bridge_exec_lua("return WatchAccess(" + str(a) + ", " + str(int(length)) + ", '" + mode + "')")


@mcp.tool()
def watch_read(fd: int, stop: bool = False) -> str:
    """Drain a watchpoint's samples → writer/reader instructions as module+RVA with
    hit counts (sorted). Pass stop=true to also disarm it."""
    lua = ("local r=WatchRead(" + str(int(fd)) + ");" +
           ("WatchStop(" + str(int(fd)) + ");" if stop else "") +
           "if type(r)~='table' then return 'no data' end;"
           "if r.error then return 'err '..tostring(r.error) end;"
           "local o={string.format('hits=%d distinct=%d', r.hits or 0, r.distinct or 0)};"
           "for i,s in ipairs(r.samples or {}) do o[#o+1]=string.format('  %s +0x%X  x%d  (abs 0x%X)', s.module, s.off, s.count, s.abs) end;"
           "return table.concat(o,'\\n')")
    return bridge_exec_lua(lua)


@mcp.tool()
def watch_stop(fd: int) -> str:
    """Disarm and free a watchpoint fd."""
    return bridge_exec_lua("return tostring(WatchStop(" + str(int(fd)) + "))")


@mcp.tool()
def find_what_writes(addr: str, length: int = 8, mode: str = "w", settle_seconds: float = 3.0) -> str:
    """Cheat-Engine 'find out what writes/accesses this address'. Arms a hardware
    watchpoint on addr, lets the game run `settle_seconds` while accesses accumulate,
    then returns the writing/reading instructions (module + 0xRVA + hit count) and
    disarms. mode: 'w' write, 'r' read, 'rw' both. TRIGGER the behaviour (e.g. let
    the score tick) during the settle window."""
    a = _addr(addr)
    arm = bridge_exec_lua("return WatchAccess(" + str(a) + ", " + str(int(length)) + ", '" + mode + "')")
    try:
        fd = int(str(arm).strip().split()[0])
    except Exception:
        return "arm failed: " + str(arm)
    if fd < 0:
        return ("WatchAccess failed (errno " + str(-fd) + "). Needs root + "
                "'echo -1 > /proc/sys/kernel/perf_event_paranoid'.")
    time.sleep(max(0.2, float(settle_seconds)))
    lua = ("local r=WatchRead(" + str(fd) + "); WatchStop(" + str(fd) + ");"
           "if type(r)~='table' then return 'no data' end;"
           "if r.error then return 'err '..tostring(r.error) end;"
           "local o={string.format('watch 0x%X (%s) hits=%d distinct=%d', " + str(a) + ", '" + mode + "', r.hits or 0, r.distinct or 0)};"
           "for i,s in ipairs(r.samples or {}) do o[#o+1]=string.format('  %s +0x%X  x%d  (abs 0x%X)', s.module, s.off, s.count, s.abs) end;"
           "return table.concat(o,'\\n')")
    return bridge_exec_lua(lua, timeout=15)


@mcp.tool()
def aob_scan(pattern: str, module: str = "", limit: int = 50) -> str:
    """Scan executable memory for a byte pattern (wildcards: ?? or ?). Returns
    matches as module + 0xRVA (+ abs). module = substring filter of the mapping
    path (default: any named .so). Use to resolve an authored signature at runtime."""
    modarg = "'" + module + "'" if module else "nil"
    lua = ("local r=AOBScan([[" + pattern + "]], " + modarg + ", " + str(int(limit)) + "); local o={};"
           "for i,m in ipairs(r) do o[#o+1]=string.format('  %s +0x%X  (abs 0x%X)', m.module, m.off, m.abs) end;"
           "return string.format('%d match(es):\\n%s', #r, table.concat(o,'\\n'))")
    return bridge_exec_lua(lua, timeout=20)


@mcp.tool()
def aob_make(addr: str, length: int = 16) -> str:
    """Grab a raw byte signature (uppercase, space-separated) of `length` bytes at
    addr — quick pattern to paste/inspect."""
    a = _addr(addr)
    return bridge_exec_lua("return AOBMake(" + str(a) + ", " + str(int(length)) + ")")


@mcp.tool()
def aob_make_unique(addr: str, maxlen: int = 48, module: str = "") -> str:
    """Generate a signature that matches `addr` UNIQUELY within its module — ready
    to paste into a mod to FUTURE-PROOF it against game updates (resolve via
    aob_scan at load instead of a hardcoded RVA). Grows the pattern until unique.
    (Raw bytes; for max cross-build resilience also wildcard volatile immediates
    with IDA make_signature.)"""
    a = _addr(addr)
    modarg = "'" + module + "'" if module else "nil"
    lua = ("local r=AOBUnique(" + str(a) + ", " + str(int(maxlen)) + ", " + modarg + ");"
           "if r.error then return string.format('%s (module=%s off=0x%X)', r.error, tostring(r.module), r.off or 0) end;"
           "return string.format('UNIQUE sig for %s+0x%X (len %d):\\n%s', r.module, r.off, r.len, r.pattern)")
    return bridge_exec_lua(lua, timeout=20)


@mcp.tool()
def bridge_list_mods() -> str:
    """List all discovered mods with load status and error counts."""
    return _fmt_bridge(bridge_send({"cmd": "list_mods"}))


@mcp.tool()
def bridge_reload_mod(name: str) -> str:
    """Hot-reload a single already-loaded mod by name (no game restart)."""
    return _fmt_bridge(bridge_send({"cmd": "reload_mod", "name": name}, timeout=12))


@mcp.tool()
def bridge_load_mod(name: str) -> str:
    """Load a mod by name that isn't loaded yet (no game restart)."""
    return _fmt_bridge(bridge_send({"cmd": "load_mod", "name": name}, timeout=12))


@mcp.tool()
def bridge_list_hooks() -> str:
    """List active ProcessEvent hooks with per-function call counts."""
    return _fmt_bridge(bridge_send({"cmd": "list_hooks"}))


@mcp.tool()
def bridge_find_object(name: str) -> str:
    """Find a live UObject by (short or full) name — returns its address, class,
    and full name."""
    return _fmt_bridge(bridge_send({"cmd": "find_object", "name": name}))


@mcp.tool()
def bridge_find_class(name: str) -> str:
    """Find a UClass by name and rebuild it — returns address, property/function/
    instance counts and parent class."""
    return _fmt_bridge(bridge_send({"cmd": "find_class", "name": name}))


@mcp.tool()
def bridge_dump_sdk() -> str:
    """Re-walk GUObjectArray and regenerate the full SDK on the device (CXX header
    dump + Lua types + legacy SDK). Returns class/struct/enum counts and paths.
    Use pull_sdk afterwards to copy it to the PC."""
    return _fmt_bridge(bridge_send({"cmd": "dump_sdk"}, timeout=60))


@mcp.tool()
def bridge_dump_ida() -> str:
    """Regenerate IDA/Ghidra function-rename mappings (Dumper-7 style) on the
    device — UnrealFunctions.py, UnrealGlobals.py, UnrealSymbols.map, JSON."""
    return _fmt_bridge(bridge_send({"cmd": "dump_ida"}, timeout=60))


@mcp.tool()
def bridge_dump_symbols() -> str:
    """Dump all ELF symbols from the engine .so to a file on the device."""
    return _fmt_bridge(bridge_send({"cmd": "dump_symbols"}, timeout=60))


@mcp.tool()
def bridge_dump_console_commands() -> str:
    """Dump every known UE console command / CVar (FUNC_Exec functions) from
    reflection."""
    return _fmt_bridge(bridge_send({"cmd": "dump_console_commands"}, timeout=30))


@mcp.tool()
def bridge_list_paks() -> str:
    """List custom PAKs the modloader knows about, with mount state and size."""
    return _fmt_bridge(bridge_send({"cmd": "list_paks"}))


@mcp.tool()
def bridge_mount_pak(path: str) -> str:
    """Mount a custom .pak by path (or bare name resolved in the paks dir)."""
    return _fmt_bridge(bridge_send({"cmd": "mount_pak", "path": path}, timeout=20))


@mcp.tool()
def bridge_log_tail(lines: int = 50) -> str:
    """Return the last N lines of the in-memory modloader log via the bridge
    (does NOT touch the on-device log file)."""
    return _fmt_bridge(bridge_send({"cmd": "log_tail", "lines": lines}))


@mcp.tool()
def bridge_aes(action: str = "latest") -> str:
    """AES key extraction. action: 'scan' (rescan memory for keys),
    'latest' (newest captured key, hex+base64), or 'keys' (all captured keys)."""
    a = action.lower().strip()
    cmd = {"scan": "aes_scan", "latest": "aes_latest", "keys": "aes_keys"}.get(a)
    if not cmd:
        return "ERROR: action must be one of scan|latest|keys"
    return _fmt_bridge(bridge_send({"cmd": cmd}, timeout=20))


@mcp.tool()
def bridge_pe_trace(action: str = "status", filter: str = "", n: int = 50) -> str:
    """Control ProcessEvent tracing. action: 'start' (optionally with `filter`
    substring), 'stop', 'status', 'clear', 'top' (top N called functions), or
    'dump' (write full trace to a file on device)."""
    a = action.lower().strip()
    if a == "start":
        payload = {"cmd": "pe_trace_start"}
        if filter:
            payload["filter"] = filter
        return _fmt_bridge(bridge_send(payload))
    if a == "stop":
        return _fmt_bridge(bridge_send({"cmd": "pe_trace_stop"}))
    if a == "status":
        return _fmt_bridge(bridge_send({"cmd": "pe_trace_status"}))
    if a == "clear":
        return _fmt_bridge(bridge_send({"cmd": "pe_trace_clear"}))
    if a == "top":
        return _fmt_bridge(bridge_send({"cmd": "pe_trace_top", "n": n}, timeout=20))
    if a == "dump":
        return _fmt_bridge(bridge_send({"cmd": "pe_trace_dump"}, timeout=30))
    return "ERROR: action must be one of start|stop|status|clear|top|dump"


@mcp.tool()
def bridge_raw(command: str, params_json: str = "{}") -> str:
    """Escape hatch: send an arbitrary bridge command with arbitrary JSON params.
    Use for custom commands that Lua mods registered at runtime (see bridge_help),
    or any command not wrapped above. `params_json` is merged into {"cmd": command}.

    Example: bridge_raw("my_custom_cmd", '{"args": "hello"}')"""
    try:
        extra = json.loads(params_json) if params_json.strip() else {}
        if not isinstance(extra, dict):
            return "ERROR: params_json must be a JSON object"
    except Exception as e:
        return "ERROR: bad params_json: %s" % e
    payload = {"cmd": command}
    payload.update(extra)
    try:
        return _fmt_bridge(bridge_send(payload, timeout=20))
    except AdbError as e:
        return "ERROR: %s" % e


# ═══ Storage mirror ═══════════════════════════════════════════════════════════
@mcp.tool()
def mirror(game: str = "", action: str = "status") -> str:
    """Manage the public->scoped bind mirror that keeps ALL mods/logs/SDK in the
    public store (/sdcard/UnrealModloader/<pkg>) and out of the game's scoped dir.

    action:
      status  — is the scoped dir currently a bind mount? (checked in the running
                game's namespace when the game is up)
      on/repair — (re)establish the bind in the global namespace via `su -M`,
                migrate+chmod the public store. Reaches a running game immediately.
      off     — unmount the scoped bind (public store is untouched).

    The bind does not survive reboot; your boot script 98-uml-mirror.sh re-creates
    it, and the LSPosed module re-binds at each launch. Use this to force it now."""
    key, info = resolve_game(game)
    pkg = info["pkg"]
    a = action.lower().strip()
    scoped = SCOPED_DIR_ABS_TMPL.format(pkg=pkg)
    if a in ("on", "repair"):
        st = ensure_mirror(key)
        return "mirror %s -> %s\n  public: %s\n  scoped: %s" % (
            pkg, st, public_data_dir(key), scoped)
    if a == "off":
        r = run_device_script('umount "%s" 2>&1 && echo UNMOUNTED || echo "not mounted / %s"' % (scoped, "busy"),
                              magic_mount=True, timeout=30)
        return "mirror off %s: %s" % (pkg, (r["stdout"] or r["stderr"] or "").strip())
    # status — check both global shell and (if running) the game's namespace
    pid = _pid_of(pkg)
    script = (
        'SCOPED="%s"\n'
        'mountpoint -q "$SCOPED" && echo "global: BOUND" || echo "global: NOT-BOUND"\n'
    ) % scoped
    if pid:
        script += 'nsenter -t %s -m -- sh -c \'mountpoint -q "%s" && echo "game(%s): BOUND" || echo "game(%s): NOT-BOUND"\' 2>/dev/null\n' % (
            pid, scoped, pid, pid)
    r = run_device_script(script, root=True, timeout=30)
    return "mirror status %s:\n  public: %s\n  scoped: %s\n  %s" % (
        pkg, public_data_dir(key), scoped,
        "\n  ".join((r["stdout"] or "").strip().splitlines()) or "(unknown)")


# ═══ Deploy / lifecycle ═══════════════════════════════════════════════════════
def _iter_local_mods(game):
    key, info = resolve_game(game)
    src = os.path.join(repo_root(), "mods", info["src"])
    if not os.path.isdir(src):
        return src, []
    mods = sorted(
        d for d in os.listdir(src)
        if os.path.isdir(os.path.join(src, d)) and not d.startswith(".")
    )
    return src, mods


@mcp.tool()
def deploy_mods(game: str = "", mod: str = "", hot: bool = True) -> str:
    """Push Lua mods to the device and (by default) hot-reload them via the bridge
    — NO game restart. This is the standard mod-iteration workflow.

    game: which game (pfx/re4/handboi; blank = configured default).
    mod:  a single mod folder name to push; blank = push ALL mods for the game.
    hot:  reload each pushed mod live via the bridge (falls back to load_mod if it
          wasn't loaded yet). Set False to only push (you'd then restart the game).
    """
    key, info = resolve_game(game)
    src, all_mods = _iter_local_mods(key)
    if not os.path.isdir(src):
        return "ERROR: local mods dir not found: %s" % src
    if mod:
        if mod not in all_mods:
            return "ERROR: mod %r not found in %s\navailable: %s" % (mod, src, ", ".join(all_mods))
        targets = [mod]
    else:
        targets = all_mods
    if not targets:
        return "ERROR: no mods found under %s" % src

    remote_mods = public_data_dir(key) + "/mods/"   # public store is truth
    adb_shell('mkdir -p "%s"' % remote_mods)

    pushed, failed = [], []
    for name in targets:
        local = os.path.join(src, name)
        r = adb_push(local, remote_mods, timeout=180)
        if r["rc"] == 0:
            pushed.append(name)
        else:
            failed.append((name, (r["stderr"] or r["stdout"] or "").strip()))

    lines = ["game=%s (%s)" % (key, info["pkg"]), "remote=%s" % remote_mods,
             "pushed %d/%d: %s" % (len(pushed), len(targets), ", ".join(pushed) or "-")]
    for name, err in failed:
        lines.append("  FAIL %s: %s" % (name, err))

    # Copy the pushed mods from the public store INTO the scoped path the
    # modloader actually reads (world-readable). Replaces the old `su -M` bind
    # mirror, which is invisible to a running game and hangs.
    if pushed:
        mstat = sync_scoped(key)
        lines.append("scoped-sync: %s" % mstat)

    if hot and pushed:
        lines.append("--- hot-reload ---")
        try:
            ensure_forward()
            bridge_send({"cmd": "ping"}, timeout=5)  # fail fast if the game is down
        except AdbError as e:
            lines.append("  (bridge unreachable — files pushed but not reloaded: %s)" % e)
            lines.append("  -> run game_launch, or restart the game to pick up the changes")
            return "\n".join(lines)
        for name in pushed:
            reply = bridge_send({"cmd": "reload_mod", "name": name}, timeout=12)
            if isinstance(reply, dict) and reply.get("ok"):
                lines.append("  reloaded %s: %s" % (name, reply.get("result")))
            else:
                # not loaded yet? try a fresh load
                reply2 = bridge_send({"cmd": "load_mod", "name": name}, timeout=12)
                if isinstance(reply2, dict) and reply2.get("ok"):
                    lines.append("  loaded   %s: %s" % (name, reply2.get("result")))
                else:
                    err = reply.get("error") if isinstance(reply, dict) else reply
                    lines.append("  FAIL     %s: reload/load failed (%s)" % (name, err))
    elif hot and not pushed:
        lines.append("(nothing pushed — skipped hot-reload)")
    return "\n".join(lines)


@mcp.tool()
def deploy_file(local: str, remote: str, root: bool = False) -> str:
    """Push an arbitrary local file to the device. If root=True, the file is first
    pushed to a temp on /sdcard then `su`-copied to `remote` (for root-only
    destinations like an LSPosed module dir). Otherwise a plain `adb push`."""
    local = os.path.abspath(os.path.expanduser(local))
    if not os.path.exists(local):
        return "ERROR: local file not found: %s" % local
    if not root:
        r = adb_push(local, remote, timeout=300)
        return "exit=%s\n%s" % (r["rc"], (r["stderr"] or r["stdout"] or "ok").strip())
    tmp = "/sdcard/_ue_push_tmp"
    r1 = adb_push(local, tmp, timeout=300)
    if r1["rc"] != 0:
        return "ERROR: push to tmp failed: %s" % (r1["stderr"] or r1["stdout"])
    r2 = adb_shell_root('cp "%s" "%s" && chmod 644 "%s"' % (tmp, remote, remote))
    adb_shell('rm -f "%s"' % tmp)
    ok = r2["rc"] == 0 and not (r2["stderr"] or "").strip()
    return "%s %s -> %s\n%s" % ("OK" if ok else "FAILED", local, remote,
                                (r2["stderr"] or r2["stdout"] or "").strip())


@mcp.tool()
def install_mod(game: str = "", source: str = "", name: str = "", enable: bool = True) -> str:
    """Install a mod into the game — placed in the PUBLIC store so it's the real,
    persistent mod file (never the scoped path), made readable, mirrored to the
    running game, and (by default) loaded live.

    source: a local path to a mod folder (containing main.lua), OR a bare mod name
            that exists under the repo's mods/<game>/ directory.
    name:   override the on-device folder name (default = source folder's basename).
    enable: load/reload the mod live via the bridge after installing.

    The installed file lives at /sdcard/UnrealModloader/<pkg>/mods/<name>/ — editable
    over SFTP/MTP and picked up on every launch."""
    key, info = resolve_game(game)
    # Resolve the source folder.
    if source and os.path.isdir(os.path.expanduser(source)):
        src = os.path.abspath(os.path.expanduser(source))
    else:
        cand = os.path.join(repo_root(), "mods", info["src"], source or name)
        if os.path.isdir(cand):
            src = cand
        else:
            return ("ERROR: source not found. Give a local mod-folder path, or a mod "
                    "name under %s\n  tried: %s" % (os.path.join(repo_root(), 'mods', info['src']), cand))
    mod_name = name or os.path.basename(src.rstrip("/\\"))
    if not os.path.exists(os.path.join(src, "main.lua")):
        # Not fatal — some mods use a different entry — but warn.
        warn = "  WARN: no main.lua in %s (modloader expects mods/<name>/main.lua)\n" % src
    else:
        warn = ""

    remote_mods = public_data_dir(key) + "/mods/"
    adb_shell('mkdir -p "%s"' % remote_mods)
    # Replace any existing copy cleanly, then push.
    adb_shell_root('rm -rf "%s%s"' % (remote_mods, mod_name))
    r = adb_push(src, remote_mods + mod_name, timeout=180)
    if r["rc"] != 0:
        return "%sERROR pushing mod: %s" % (warn, (r["stderr"] or r["stdout"] or "").strip())

    mstat = sync_scoped(key)
    lines = ["%sinstalled %s -> %s%s/" % (warn, mod_name, remote_mods, mod_name),
             "scoped-sync: %s" % mstat]
    if enable:
        try:
            ensure_forward()
            bridge_send({"cmd": "ping"}, timeout=5)
        except AdbError:
            lines.append("(game not running — installed on disk; loads on next launch)")
            return "\n".join(lines)
        rep = bridge_send({"cmd": "load_mod", "name": mod_name}, timeout=12)
        if isinstance(rep, dict) and rep.get("ok"):
            lines.append("loaded: %s" % rep.get("result"))
        else:
            rep2 = bridge_send({"cmd": "reload_mod", "name": mod_name}, timeout=12)
            if isinstance(rep2, dict) and rep2.get("ok"):
                lines.append("reloaded: %s" % rep2.get("result"))
            else:
                err = rep.get("error") if isinstance(rep, dict) else rep
                lines.append("load failed live (installed on disk though): %s" % err)
    return "\n".join(lines)


@mcp.tool()
def uninstall_mod(game: str = "", name: str = "", purge_scoped: bool = True) -> str:
    """Uninstall a mod: delete its folder from the PUBLIC store (the real mod file),
    and by default also purge any stale copy from the scoped path. The modloader has
    no live-unload, so a currently-loaded mod stays active until the next launch —
    this removes it from disk so it will NOT load again.

    name:         the mod folder name to remove.
    purge_scoped: also root-delete <scoped>/mods/<name> (stale leftovers)."""
    key, info = resolve_game(game)
    if not name:
        return "ERROR: give the mod folder name to uninstall (see bridge_list_mods)"
    pub_path = "%s/mods/%s" % (public_data_dir(key), name)
    existed = _dir_exists(pub_path)
    r = adb_shell_root('rm -rf "%s"' % pub_path)
    lines = ["removed public: %s%s" % (pub_path, "" if existed else "  (was not present)")]
    if purge_scoped:
        scoped_path = "%s/mods/%s" % (scoped_data_dir(key), name)
        adb_shell_root('rm -rf "%s"' % scoped_path)
        lines.append("purged scoped: %s" % scoped_path)
    # Refresh scoped so the game's on-disk view matches the public store.
    lines.append("scoped-sync: %s" % sync_scoped(key))
    # Is it still loaded in memory?
    try:
        ensure_forward()
        rep = bridge_send({"cmd": "list_mods"}, timeout=6)
        if isinstance(rep, dict) and rep.get("ok"):
            still = any(m.get("name") == name for m in rep.get("result", []))
            if still:
                lines.append("NOTE: '%s' is still loaded in memory (no live-unload); "
                             "it will not load after the next game restart." % name)
            else:
                lines.append("'%s' is not loaded." % name)
    except AdbError:
        pass
    return "\n".join(lines)


def _pid_of(pkg):
    r = adb_shell("pidof %s" % pkg, timeout=15)
    return (r["stdout"] or "").strip()


@mcp.tool()
def game_status(game: str = "") -> str:
    """Report whether the game is running (with PID), plus a live bridge ping."""
    key, info = resolve_game(game)
    pid = _pid_of(info["pkg"])
    running = bool(pid)
    ping = "unreachable"
    try:
        reply = bridge_send({"cmd": "ping"}, timeout=5)
        if isinstance(reply, dict) and reply.get("ok"):
            ping = "pong"
    except AdbError:
        ping = "unreachable (no forward / game down)"
    return "%s (%s)\n  running: %s%s\n  bridge : %s" % (
        info["label"], info["pkg"],
        "YES" if running else "NO",
        (" pid=%s" % pid) if pid else "",
        ping,
    )


@mcp.tool()
def game_launch(game: str = "") -> str:
    """Force-stop then relaunch the game and set up the bridge port-forward.

    On EVERY launch it first refreshes the scoped mods path from the public store
    (sync_scoped) so the injected modloader loads the current mod set — the old
    public->scoped bind mirror doesn't reach a freshly-started game. Launches via
    the game's configured `activity` (VR apps have no LAUNCHER category, so
    `monkey -c LAUNCHER` fails); falls back to monkey when no activity is set."""
    key, info = resolve_game(game)
    pkg = info["pkg"]
    adb_shell("am force-stop %s" % pkg, timeout=20)
    time.sleep(0.5)
    # Refresh scoped <- public BEFORE the app starts so the modloader sees the
    # latest mods (the bind mirror is unreliable for a running app / after boot).
    sync_status = sync_scoped(key)
    act = info.get("activity")
    if act:
        r = adb_shell("am start -n %s/%s" % (pkg, act), timeout=25)
        ok = "Starting: Intent" in (r["stdout"] or "") and "Error" not in (r["stdout"] or "")
        how = "am start -n %s/%s" % (pkg, act)
    else:
        r = adb_shell("monkey -p %s -c android.intent.category.LAUNCHER 1" % pkg, timeout=25)
        ok = "Events injected: 1" in (r["stdout"] or "")
        how = "monkey LAUNCHER"
    _FWD_DONE["val"] = False
    ensure_forward()
    time.sleep(1.0)
    pid = _pid_of(pkg)
    return "launched %s\n  scoped-sync: %s\n  via: %s\n  result: %s\n  pid: %s\n  bridge forward: tcp:%d" % (
        pkg, sync_status, how,
        "ok" if ok else (r["stdout"] or r["stderr"] or "").strip(),
        pid or "(not up yet)", bridge_port(),
    )


@mcp.tool()
def game_restart(game: str = "") -> str:
    """Force-stop the game without relaunching."""
    key, info = resolve_game(game)
    r = adb_shell("am force-stop %s" % info["pkg"], timeout=20)
    return "force-stopped %s (exit=%s)" % (info["pkg"], r["rc"])


@mcp.tool()
def game_ensure(game: str = "") -> str:
    """Launch the game only if it isn't already running; otherwise just ensure the
    bridge forward is up."""
    key, info = resolve_game(game)
    if _pid_of(info["pkg"]):
        _FWD_DONE["val"] = False
        ensure_forward()
        return "%s already running (pid=%s); bridge forward ensured" % (info["pkg"], _pid_of(info["pkg"]))
    return game_launch(key)


# ═══ Logs ═════════════════════════════════════════════════════════════════════
def _sessions_dir():
    d = os.path.join(repo_root(), "logs", "sessions")
    os.makedirs(d, exist_ok=True)
    return d


def _ts():
    return time.strftime("%Y%m%d-%H%M%S")


def _pull_device_file(remote, local, root=False):
    """Pull a device file to `local`, using a root cp-to-sdcard hop if needed.
    Returns (ok, bytes_or_err)."""
    if root:
        tmp = "/sdcard/_ue_pull_tmp"
        c = adb_shell_root('cp "%s" "%s" 2>/dev/null && chmod 666 "%s"' % (remote, tmp, tmp))
        r = adb_pull(tmp, local, timeout=180)
        adb_shell('rm -f "%s"' % tmp)
    else:
        r = adb_pull(remote, local, timeout=180)
    if r["rc"] == 0 and os.path.exists(local):
        return True, os.path.getsize(local)
    return False, (r["stderr"] or r["stdout"] or "pull failed").strip()


def _read_local(path, max_bytes=200000):
    try:
        with open(path, "r", encoding="utf-8", errors="replace") as f:
            data = f.read(max_bytes + 1)
    except Exception as e:
        return "(could not read %s: %s)" % (path, e)
    if len(data) > max_bytes:
        return data[:max_bytes] + "\n... [truncated]"
    return data


def _log_common(game, remote_name, delete):
    key, info = resolve_game(game)
    ddir = device_data_dir(key)
    remote = "%s/%s" % (ddir, remote_name)
    exists = adb_shell('[ -f "%s" ] && stat -c "%%Y %%s" "%s" || echo MISSING' % (remote, remote))
    meta = (exists["stdout"] or "").strip()
    if "MISSING" in meta or not meta:
        return "%s: not present on device (%s)" % (remote_name, remote)
    local = os.path.join(_sessions_dir(), "%s_%s" % (_ts(), remote_name))
    ok, info2 = _pull_device_file(remote, local)
    if not ok:
        return "ERROR pulling %s: %s" % (remote_name, info2)
    body = _read_local(local)
    footer = ""
    if delete:
        adb_shell('rm -f "%s"' % remote)
        footer = "\n\n[deleted from device; archived at %s]" % local
    else:
        footer = "\n\n[archived at %s — device copy left intact]" % local
    return "=== %s (%s bytes) ===\n%s%s" % (remote_name, info2, body, footer)


@mcp.tool()
def pull_log(game: str = "", delete: bool = False) -> str:
    """Pull and print the modloader log (UEModLoader.log). Archives a timestamped
    copy under logs/sessions/. Set delete=True to also remove it from the device."""
    return _log_common(game, "UEModLoader.log", delete)


@mcp.tool()
def pull_crashlog(game: str = "", delete: bool = False) -> str:
    """Pull and print the modloader crash log (modloader_crash.log). Archives a
    copy under logs/sessions/. delete=True also removes it from the device."""
    return _log_common(game, "modloader_crash.log", delete)


@mcp.tool()
def pull_pe_trace(game: str = "", delete: bool = False) -> str:
    """Pull and print the ProcessEvent trace log (pe_trace.log). Archives a copy
    under logs/sessions/. delete=True also removes it from the device."""
    return _log_common(game, "pe_trace.log", delete)


@mcp.tool()
def livelog(game: str = "", lines: int = 200) -> str:
    """Return the last N lines of the on-device modloader log WITHOUT deleting it.
    Good for repeated checks during a session."""
    key, info = resolve_game(game)
    ddir = device_data_dir(key)
    remote = "%s/UEModLoader.log" % ddir
    r = adb_shell('tail -n %d "%s" 2>/dev/null || echo "(no log)"' % (int(lines), remote), timeout=30)
    return (r["stdout"] or "(no output)").rstrip()


@mcp.tool()
def pull_sdk(game: str = "") -> str:
    """Pull the on-device SDK dump (Classes/Structs/Enums) to the local repo under
    'Current Modloader SDK/'. Run bridge_dump_sdk first to regenerate it fresh."""
    key, info = resolve_game(game)
    ddir = device_data_dir(key)
    remote = "%s/SDK" % ddir
    exists = adb_shell('[ -d "%s" ] && echo YES || echo NO' % remote)
    if "YES" not in (exists["stdout"] or ""):
        return "ERROR: no SDK dir on device (%s). Run bridge_dump_sdk first." % remote
    local_root = os.path.join(repo_root(), "Current Modloader SDK")
    os.makedirs(local_root, exist_ok=True)
    r = adb_pull(remote, local_root, timeout=300)
    if r["rc"] != 0:
        return "ERROR pulling SDK: %s" % (r["stderr"] or r["stdout"])
    return "pulled SDK -> %s\n%s" % (os.path.join(local_root, "SDK"), (r["stdout"] or "").strip()[-500:])


# ═══ Tombstones — grab latest & wipe all ══════════════════════════════════════
def _tombstones_dir_local():
    d = os.path.join(repo_root(), "logs", "tombstones")
    os.makedirs(d, exist_ok=True)
    return d


def _list_tombstones():
    """Return a list of dicts {name, mtime, size} for real tombstone_NN files
    (excludes .lock and .pb sidecars), newest first. Requires root."""
    cmd = 'ls -1 %s 2>/dev/null' % TOMBSTONE_DIR
    r = adb_shell_root(cmd, timeout=20)
    names = [n.strip() for n in (r["stdout"] or "").splitlines() if n.strip()]
    tombs = [
        n for n in names
        if re.match(r"^tombstone_\d+$", n)  # exclude .lock / .pb sidecars
    ]
    out = []
    for n in tombs:
        path = "%s/%s" % (TOMBSTONE_DIR, n)
        st = adb_shell_root('stat -c "%%Y %%s" "%s" 2>/dev/null' % path, timeout=15)
        meta = (st["stdout"] or "").strip().split()
        mtime = int(meta[0]) if len(meta) >= 1 and meta[0].isdigit() else 0
        size = int(meta[1]) if len(meta) >= 2 and meta[1].isdigit() else 0
        out.append({"name": n, "mtime": mtime, "size": size})
    out.sort(key=lambda x: x["mtime"], reverse=True)
    return out


def _tomb_summary_lines(path):
    """Grab the crash-signature lines from a device tombstone (root): timestamp,
    which process crashed (Cmdline/pid), the signal, any abort message, and the
    top of the native backtrace."""
    grep = (
        'grep -m1 "^Timestamp: " "%s" 2>/dev/null; '
        'grep -m1 "^Cmdline: " "%s" 2>/dev/null; '
        'grep -m1 "^pid: " "%s" 2>/dev/null; '
        'grep -m1 "^signal " "%s" 2>/dev/null; '
        'grep -m1 "^Abort message" "%s" 2>/dev/null; '
        'grep -m6 -E "^ *#[0-9]+ pc " "%s" 2>/dev/null'
    ) % (path, path, path, path, path, path)
    r = adb_shell_root(grep, timeout=20)
    return (r["stdout"] or "").rstrip()


@mcp.tool()
def tombstone_list() -> str:
    """List all native crash tombstones on the device (newest first) with age,
    size, and a one-line crash signature (signal + top frame) for each. Root."""
    tombs = _list_tombstones()
    if not tombs:
        return "no tombstones in %s (clean — no native crashes captured)" % TOMBSTONE_DIR
    now = int(time.time())
    lines = ["%d tombstone(s) in %s:" % (len(tombs), TOMBSTONE_DIR)]
    for t in tombs:
        age = now - t["mtime"] if t["mtime"] else 0
        when = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime(t["mtime"])) if t["mtime"] else "?"
        lines.append("-" * 60)
        lines.append("  %s   %s  (%s ago, %d bytes)" % (t["name"], when, _human_age(age), t["size"]))
        sig = _tomb_summary_lines("%s/%s" % (TOMBSTONE_DIR, t["name"]))
        for s in sig.splitlines():
            lines.append("      %s" % s.strip())
    return "\n".join(lines)


def _human_age(secs):
    secs = int(secs)
    if secs < 60:
        return "%ds" % secs
    if secs < 3600:
        return "%dm %ds" % (secs // 60, secs % 60)
    if secs < 86400:
        return "%dh %dm" % (secs // 3600, (secs % 3600) // 60)
    return "%dd %dh" % (secs // 86400, (secs % 86400) // 3600)


@mcp.tool()
def tombstone_latest(max_lines: int = 400, save: bool = True) -> str:
    """Grab the NEWEST native crash tombstone, save the full file locally (under
    logs/tombstones/), and return its head (signal, abort message, registers, the
    top of the backtrace — the parts that identify the crash). Requires root.

    max_lines: how many lines of the tombstone to return (full file is saved).
    save:      write the full tombstone to logs/tombstones/ (recommended)."""
    tombs = _list_tombstones()
    if not tombs:
        return "no tombstones in %s (no recent native crash)" % TOMBSTONE_DIR
    newest = tombs[0]
    remote = "%s/%s" % (TOMBSTONE_DIR, newest["name"])
    when = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime(newest["mtime"])) if newest["mtime"] else "?"
    header = "=== latest tombstone: %s (%s, %s ago, %d bytes) ===" % (
        newest["name"], when, _human_age(int(time.time()) - newest["mtime"]) if newest["mtime"] else "?",
        newest["size"],
    )
    local_path = None
    if save:
        local_path = os.path.join(_tombstones_dir_local(), "%s_%s.txt" % (_ts(), newest["name"]))
        ok, info = _pull_device_file(remote, local_path, root=True)
        if not ok:
            return "%s\nERROR saving: %s" % (header, info)
        body = _read_local(local_path, max_bytes=1_000_000)
    else:
        r = adb_shell_root('cat "%s"' % remote, timeout=30)
        body = r["stdout"] or ""

    trimmed = "\n".join(body.splitlines()[: int(max_lines)])
    footer = ""
    if len(body.splitlines()) > int(max_lines):
        footer += "\n... [%d more lines]" % (len(body.splitlines()) - int(max_lines))
    if local_path:
        footer += "\n[full tombstone saved -> %s]" % local_path
    return "%s\n%s%s" % (header, trimmed, footer)


@mcp.tool()
def tombstone_wipe(save_first: bool = True) -> str:
    """Wipe ALL native crash tombstones from the device (root `rm` of everything
    in /data/tombstones). By default it first archives every tombstone locally
    under logs/tombstones/ so nothing is lost. Set save_first=False to just delete.

    Destructive but reversible only via the archive — that's why save_first
    defaults to True."""
    tombs = _list_tombstones()
    archived = []
    if save_first and tombs:
        for t in tombs:
            remote = "%s/%s" % (TOMBSTONE_DIR, t["name"])
            local = os.path.join(_tombstones_dir_local(), "%s_%s.txt" % (_ts(), t["name"]))
            ok, _ = _pull_device_file(remote, local, root=True)
            if ok:
                archived.append(os.path.basename(local))
    # Wipe everything in the tombstone dir (tombstone_NN + .lock + .pb sidecars).
    r = adb_shell_root('rm -f %s/* 2>&1' % TOMBSTONE_DIR, timeout=30)
    # Verify.
    after = _list_tombstones()
    lines = []
    if save_first:
        lines.append("archived %d file(s) -> logs/tombstones/" % len(archived))
    lines.append("wiped %s/*  (exit=%s)" % (TOMBSTONE_DIR, r["rc"]))
    if (r["stderr"] or "").strip() or (r["stdout"] or "").strip():
        lines.append("rm output: %s" % ((r["stdout"] or "") + (r["stderr"] or "")).strip())
    lines.append("remaining tombstones: %d" % len(after))
    return "\n".join(lines)


# ═══ Diagnose — the all-in-one crash check ════════════════════════════════════
@mcp.tool()
def diagnose(game: str = "", wipe_tombstones: bool = False) -> str:
    """One-shot crash investigation: game PID/bridge status + newest tombstone
    signature + crash log + tail of the modloader log, each with device paths.
    Read ALL of it before drawing conclusions. Set wipe_tombstones=True to purge
    tombstones after capturing them (archived locally first)."""
    key, info = resolve_game(game)
    parts = []

    # 1. status
    pid = _pid_of(info["pkg"])
    bridge_ok = "unreachable"
    try:
        rep = bridge_send({"cmd": "ping"}, timeout=5)
        if isinstance(rep, dict) and rep.get("ok"):
            bridge_ok = "pong"
    except AdbError:
        pass
    parts.append("### STATUS — %s (%s)\n  running: %s%s\n  bridge : %s\n  data   : %s" % (
        info["label"], info["pkg"], "YES" if pid else "NO",
        (" pid=%s" % pid) if pid else "", bridge_ok, device_data_dir(key),
    ))

    # 2. tombstones
    tombs = _list_tombstones()
    if not tombs:
        parts.append("### TOMBSTONES\n  none (no native crash captured)")
    else:
        newest = tombs[0]
        when = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime(newest["mtime"])) if newest["mtime"] else "?"
        sig = _tomb_summary_lines("%s/%s" % (TOMBSTONE_DIR, newest["name"]))
        parts.append("### TOMBSTONES — %d present, newest %s (%s)\n%s" % (
            len(tombs), newest["name"], when,
            "\n".join("  " + s for s in sig.splitlines()) or "  (no signature parsed)",
        ))

    # 3. crash log
    ddir = device_data_dir(key)
    crash_remote = "%s/modloader_crash.log" % ddir
    ce = adb_shell('[ -f "%s" ] && stat -c "%%s" "%s" || echo MISSING' % (crash_remote, crash_remote))
    if "MISSING" in (ce["stdout"] or ""):
        parts.append("### CRASH LOG\n  none (%s)" % crash_remote)
    else:
        rc = adb_shell('cat "%s"' % crash_remote, timeout=30)
        parts.append("### CRASH LOG (%s)\n%s" % (crash_remote, (rc["stdout"] or "").strip()[:8000]))

    # 4. modloader log tail
    log_remote = "%s/UEModLoader.log" % ddir
    lt = adb_shell('tail -n 60 "%s" 2>/dev/null || echo "(no log)"' % log_remote, timeout=30)
    parts.append("### MODLOADER LOG (tail 60 — %s)\n%s" % (log_remote, (lt["stdout"] or "").rstrip()))

    if wipe_tombstones and tombs:
        parts.append("### WIPE\n" + tombstone_wipe(save_first=True))

    return "\n\n".join(parts)


if __name__ == "__main__":
    mcp.run()
