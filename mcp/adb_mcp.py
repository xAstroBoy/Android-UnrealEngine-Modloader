#!/usr/bin/env python3
r"""
ADB — a global MCP server exposing Android Debug Bridge as first-class tools.

Every device operation runs `adb` via subprocess with **argument lists** (shell=False),
so Windows/MSYS/Git-Bash path mangling never happens: `/data/...`, `/sdcard/...`,
`/data/local/tmp/...` reach the device intact. (Running adb through Git-Bash rewrites
`/data/local/tmp` into `C:/Program Files/Git/data/...` — this server exists partly to
make that class of bug impossible.)

Highlights
----------
* devices / connect / disconnect / reboot / wait
* shell (optionally as root via Magisk `su -c`)
* push / pull, plus root-aware push_root / pull_root for root-only paths
* forward / reverse / forward_list
* install / uninstall / list_packages / pidof
* logcat (bounded), getprop, dumpsys
* **run_script** — push a whole sh script and run it (root / `su -M` global-namespace /
  `nsenter -t <pid>` game-namespace). This is the clean way to do complex root work
  without fighting nested shell quoting.
* raw — arbitrary adb args escape hatch

Serial resolution: explicit `serial` arg > ANDROID_SERIAL / ADB_SERIAL env > the single
online device > (let adb decide). Set the adb binary via ADB env var if not on PATH.

Registered globally in ~/.claude.json so it's available in every project.
"""
import json
import os
import posixpath
import subprocess
import sys
import tempfile

try:
    from mcp.server.fastmcp import FastMCP
except ImportError:
    sys.stderr.write("adb-mcp: mcp missing -> pip install mcp\n")
    raise


def adb_bin():
    return os.environ.get("ADB") or "adb"


# ─── serial resolution ────────────────────────────────────────────────────────
def _devices_raw():
    p = subprocess.run([adb_bin(), "devices"], capture_output=True, text=True, timeout=15)
    rows = []
    for line in p.stdout.splitlines()[1:]:
        line = line.strip()
        if not line or "\t" not in line:
            continue
        s, st = line.split("\t", 1)
        rows.append((s.strip(), st.strip()))
    return rows


def resolve_serial(serial=""):
    if serial:
        return serial
    env = os.environ.get("ANDROID_SERIAL") or os.environ.get("ADB_SERIAL")
    if env:
        return env
    try:
        online = [s for s, st in _devices_raw() if st == "device"]
    except Exception:
        online = []
    if len(online) == 1:
        return online[0]
    return ""  # ambiguous / none — let adb error clearly


class AdbError(RuntimeError):
    pass


def _run(args, serial="", timeout=120, text=True):
    cmd = [adb_bin()]
    s = resolve_serial(serial)
    if s:
        cmd += ["-s", s]
    cmd += args
    try:
        p = subprocess.run(cmd, capture_output=True, text=text, timeout=timeout)
    except FileNotFoundError:
        raise AdbError("adb not found (%r). Set the ADB env var or add adb to PATH." % adb_bin())
    except subprocess.TimeoutExpired:
        raise AdbError("adb timed out after %ss running: adb %s" % (timeout, " ".join(args[:4])))
    return p


def _fmt(p, ok_msg=None):
    out = (p.stdout or "").rstrip()
    err = (p.stderr or "").rstrip()
    if p.returncode == 0 and ok_msg and not err:
        return ok_msg if not out else "%s\n%s" % (ok_msg, out)
    parts = ["exit=%s" % p.returncode]
    if out:
        parts.append("--- stdout ---\n" + out)
    if err:
        parts.append("--- stderr ---\n" + err)
    return "\n".join(parts)


def _su_wrap(devcmd):
    return "su -c '%s'" % devcmd.replace("'", "'\\''")


mcp = FastMCP("adb")


# ═══ Devices / connection ═════════════════════════════════════════════════════
@mcp.tool()
def devices() -> str:
    """List all attached devices/emulators and their state (device/offline/unauthorized)."""
    try:
        rows = _devices_raw()
    except Exception as e:
        return "ERROR: %s" % e
    if not rows:
        return "(no devices — `connect <ip>:5555` or plug in USB)"
    active = resolve_serial()
    return "\n".join(
        "%-26s %s%s" % (s, st, "  <- default" if s == active else "") for s, st in rows
    )


@mcp.tool()
def connect(address: str) -> str:
    """Connect to a device over TCP/IP, e.g. connect('192.168.1.35:5555')."""
    p = _run(["connect", address], timeout=20)
    return _fmt(p)


@mcp.tool()
def disconnect(address: str = "") -> str:
    """Disconnect a TCP/IP device (blank = disconnect all)."""
    p = _run(["disconnect"] + ([address] if address else []), timeout=20)
    return _fmt(p, ok_msg="disconnected %s" % (address or "all"))


@mcp.tool()
def reboot(mode: str = "", serial: str = "") -> str:
    """Reboot the device. mode: '' (normal), 'recovery', 'bootloader', 'sideload'."""
    p = _run(["reboot"] + ([mode] if mode else []), serial=serial, timeout=30)
    return _fmt(p, ok_msg="reboot %s requested" % (mode or "normal"))


@mcp.tool()
def wait_for_device(serial: str = "", timeout: int = 120) -> str:
    """Block until the device is online (after a reboot/connect)."""
    p = _run(["wait-for-device"], serial=serial, timeout=timeout)
    return _fmt(p, ok_msg="device online")


@mcp.tool()
def get_state(serial: str = "") -> str:
    """Print the connection state of the device (device/offline/bootloader)."""
    p = _run(["get-state"], serial=serial, timeout=15)
    return _fmt(p)


# ═══ Shell ════════════════════════════════════════════════════════════════════
@mcp.tool()
def shell(command: str, root: bool = False, serial: str = "", timeout: int = 120) -> str:
    """Run a command in the device shell. root=True wraps it in Magisk `su -c`.
    The command string is sent verbatim to the device shell (no local mangling)."""
    dev = _su_wrap(command) if root else command
    p = _run(["shell", dev], serial=serial, timeout=timeout)
    return _fmt(p)


@mcp.tool()
def run_script(script: str, root: bool = False, magic_mount: bool = False,
               nsenter_pid: int = 0, serial: str = "", timeout: int = 180) -> str:
    """Push a full shell script to the device and run it — the clean way to do
    multi-step / root work without nested-quoting hell.

    root:        run the script via `su -c` (Magisk root).
    magic_mount: run via `su -M -c` (root in the GLOBAL mount namespace — needed for
                 bind-mounts that must propagate into already-running app namespaces).
    nsenter_pid: if >0, run the script INSIDE that pid's mount namespace
                 (`nsenter -t <pid> -m`), i.e. inside a specific running app. Implies root.

    Returns the script's combined output. The script is written with unix line
    endings to /data/local/tmp and removed afterwards."""
    # Write locally with LF endings, push, run, clean up.
    tmp_local = tempfile.NamedTemporaryFile("w", suffix=".sh", delete=False, newline="\n")
    try:
        body = script if script.startswith("#!") else "#!/system/bin/sh\n" + script
        tmp_local.write(body.replace("\r\n", "\n"))
        tmp_local.close()
        remote = "/data/local/tmp/_adbmcp_%d.sh" % (abs(hash(script)) % 10_000_000)
        pp = _run(["push", tmp_local.name, remote], serial=serial, timeout=60)
        if pp.returncode != 0:
            return "ERROR pushing script: %s" % _fmt(pp)
        _run(["shell", "chmod 755 %s" % remote], serial=serial, timeout=15)

        if nsenter_pid and nsenter_pid > 0:
            inner = "nsenter -t %d -m -- sh %s" % (int(nsenter_pid), remote)
            dev = _su_wrap(inner)
        elif magic_mount:
            dev = "su -M -c 'sh %s'" % remote
        elif root:
            dev = "su -c 'sh %s'" % remote
        else:
            dev = "sh %s" % remote
        p = _run(["shell", dev], serial=serial, timeout=timeout)
        _run(["shell", "rm -f %s" % remote], serial=serial, timeout=15)
        return _fmt(p)
    finally:
        try:
            os.unlink(tmp_local.name)
        except OSError:
            pass


# ═══ File transfer ════════════════════════════════════════════════════════════
@mcp.tool()
def push(local: str, remote: str, serial: str = "", timeout: int = 300) -> str:
    """Copy a local file/dir to the device."""
    local = os.path.abspath(os.path.expanduser(local))
    if not os.path.exists(local):
        return "ERROR: local path not found: %s" % local
    p = _run(["push", local, remote], serial=serial, timeout=timeout)
    return _fmt(p)


@mcp.tool()
def pull(remote: str, local: str, serial: str = "", timeout: int = 300) -> str:
    """Copy a file/dir from the device to the local machine."""
    local = os.path.abspath(os.path.expanduser(local))
    os.makedirs(os.path.dirname(local) or ".", exist_ok=True)
    p = _run(["pull", remote, local], serial=serial, timeout=timeout)
    return _fmt(p)


@mcp.tool()
def push_root(local: str, remote: str, mode: str = "0644", serial: str = "", timeout: int = 300) -> str:
    """Push a local file to a ROOT-only destination: push to /sdcard temp, then
    `su cp` into place with the given chmod. Use for paths adb can't write directly
    (e.g. /data/adb/service.d, /system, an app's private dir)."""
    local = os.path.abspath(os.path.expanduser(local))
    if not os.path.exists(local):
        return "ERROR: local path not found: %s" % local
    tmp = "/data/local/tmp/_adbmcp_push_%s" % posixpath.basename(remote)
    pp = _run(["push", local, tmp], serial=serial, timeout=timeout)
    if pp.returncode != 0:
        return "ERROR pushing to tmp: %s" % _fmt(pp)
    dev = _su_wrap('cp "%s" "%s" && chmod %s "%s"' % (tmp, remote, mode, remote))
    p = _run(["shell", dev], serial=serial, timeout=60)
    _run(["shell", "rm -f %s" % tmp], serial=serial, timeout=15)
    ok = p.returncode == 0 and not (p.stderr or "").strip()
    return "%s -> %s (mode %s)\n%s" % (local, remote, mode, "OK" if ok else _fmt(p))


@mcp.tool()
def pull_root(remote: str, local: str, serial: str = "", timeout: int = 300) -> str:
    """Pull a ROOT-only file: `su cp` it to /sdcard temp (world-readable), then adb
    pull. Use for /data/tombstones, an app's private files, etc."""
    local = os.path.abspath(os.path.expanduser(local))
    os.makedirs(os.path.dirname(local) or ".", exist_ok=True)
    tmp = "/data/local/tmp/_adbmcp_pull_%s" % posixpath.basename(remote)
    dev = _su_wrap('cp "%s" "%s" && chmod 666 "%s"' % (remote, tmp, tmp))
    cp = _run(["shell", dev], serial=serial, timeout=60)
    if cp.returncode != 0:
        return "ERROR su-cp: %s" % _fmt(cp)
    p = _run(["pull", tmp, local], serial=serial, timeout=timeout)
    _run(["shell", "rm -f %s" % tmp], serial=serial, timeout=15)
    return _fmt(p)


# ═══ Networking / forwarding ══════════════════════════════════════════════════
@mcp.tool()
def forward(local_port: int, remote_port: int, serial: str = "") -> str:
    """Forward a host TCP port to a device TCP port (host:local -> device:remote)."""
    p = _run(["forward", "tcp:%d" % int(local_port), "tcp:%d" % int(remote_port)], serial=serial, timeout=15)
    return _fmt(p, ok_msg="forward tcp:%d -> device tcp:%d" % (local_port, remote_port))


@mcp.tool()
def forward_list(serial: str = "") -> str:
    """List active port forwards."""
    p = _run(["forward", "--list"], serial=serial, timeout=15)
    return _fmt(p) if (p.stdout or p.stderr).strip() else "(no forwards)"


@mcp.tool()
def forward_remove(local_port: int, serial: str = "") -> str:
    """Remove a host port forward."""
    p = _run(["forward", "--remove", "tcp:%d" % int(local_port)], serial=serial, timeout=15)
    return _fmt(p, ok_msg="removed forward tcp:%d" % local_port)


@mcp.tool()
def reverse(remote_port: int, local_port: int, serial: str = "") -> str:
    """Reverse-forward a device TCP port to a host TCP port (device:remote -> host:local)."""
    p = _run(["reverse", "tcp:%d" % int(remote_port), "tcp:%d" % int(local_port)], serial=serial, timeout=15)
    return _fmt(p, ok_msg="reverse device tcp:%d -> host tcp:%d" % (remote_port, local_port))


# ═══ Packages / processes ═════════════════════════════════════════════════════
@mcp.tool()
def install(apk: str, replace: bool = True, grant: bool = False, downgrade: bool = False,
            serial: str = "", timeout: int = 300) -> str:
    """Install an APK. replace=reinstall keeping data (-r), grant=grant all runtime
    perms (-g), downgrade=allow version downgrade (-d)."""
    apk = os.path.abspath(os.path.expanduser(apk))
    if not os.path.exists(apk):
        return "ERROR: apk not found: %s" % apk
    args = ["install"]
    if replace:
        args.append("-r")
    if grant:
        args.append("-g")
    if downgrade:
        args.append("-d")
    args.append(apk)
    p = _run(args, serial=serial, timeout=timeout)
    return _fmt(p)


@mcp.tool()
def uninstall(package: str, keep_data: bool = False, serial: str = "") -> str:
    """Uninstall a package. keep_data=True keeps app data/cache (-k)."""
    args = ["uninstall"] + (["-k"] if keep_data else []) + [package]
    p = _run(args, serial=serial, timeout=120)
    return _fmt(p)


@mcp.tool()
def list_packages(filter: str = "", serial: str = "") -> str:
    """List installed package names, optionally filtered by a substring."""
    p = _run(["shell", "pm list packages"], serial=serial, timeout=30)
    lines = [ln.replace("package:", "").strip() for ln in (p.stdout or "").splitlines() if ln.strip()]
    if filter:
        lines = [ln for ln in lines if filter.lower() in ln.lower()]
    return "\n".join(sorted(lines)) if lines else "(no matches)"


@mcp.tool()
def pidof(package: str, serial: str = "") -> str:
    """Return the PID(s) of a running package (blank if not running)."""
    p = _run(["shell", "pidof %s" % package], serial=serial, timeout=15)
    pid = (p.stdout or "").strip()
    return pid if pid else "(not running)"


@mcp.tool()
def force_stop(package: str, serial: str = "") -> str:
    """Force-stop a package."""
    p = _run(["shell", "am force-stop %s" % package], serial=serial, timeout=20)
    return _fmt(p, ok_msg="force-stopped %s" % package)


@mcp.tool()
def start_app(package: str, serial: str = "") -> str:
    """Launch a package's default LAUNCHER activity via monkey (no activity name needed)."""
    p = _run(["shell", "monkey -p %s -c android.intent.category.LAUNCHER 1" % package],
             serial=serial, timeout=25)
    return _fmt(p)


# ═══ App package extraction (APK / OBB / native .so) ══════════════════════════
def _apk_paths(package, serial=""):
    """Return the list of APK paths (base + splits) for a package via `pm path`."""
    p = _run(["shell", "pm path %s" % package], serial=serial, timeout=30)
    return [ln.replace("package:", "").strip()
            for ln in (p.stdout or "").splitlines() if ln.startswith("package:")]


def _pull_any(remote, local, serial=""):
    """Pull a remote file, trying a plain adb pull first then a root cp+pull.
    Returns (ok, method, size_or_err)."""
    local = os.path.abspath(os.path.expanduser(local))
    os.makedirs(os.path.dirname(local) or ".", exist_ok=True)
    p = _run(["pull", remote, local], serial=serial, timeout=600)
    if p.returncode == 0 and os.path.exists(local):
        return True, "adb pull", os.path.getsize(local)
    tmp = "/data/local/tmp/_adbmcp_x_%s" % posixpath.basename(remote)
    cp = _run(["shell", _su_wrap('cp "%s" "%s" && chmod 666 "%s"' % (remote, tmp, tmp))],
              serial=serial, timeout=120)
    if cp.returncode != 0:
        return False, "root cp", (cp.stderr or cp.stdout or "cp failed").strip()
    p2 = _run(["pull", tmp, local], serial=serial, timeout=600)
    _run(["shell", "rm -f %s" % tmp], serial=serial, timeout=15)
    if p2.returncode == 0 and os.path.exists(local):
        return True, "root cp+pull", os.path.getsize(local)
    return False, "root pull", (p2.stderr or p2.stdout or "pull failed").strip()


@mcp.tool()
def package_info(package: str, serial: str = "") -> str:
    """Resolve where a package's files live on device: base + split APK paths, the
    APK/native-lib directory, the OBB directory, the private data dir, and version.
    Use this to plan pull_apk / pull_obb / pull_lib."""
    apks = _apk_paths(package, serial)
    apkdir = posixpath.dirname(apks[0]) if apks else ""
    ver = _run(["shell", "dumpsys package %s" % package], serial=serial, timeout=40).stdout or ""
    def _grab(key):
        for ln in ver.splitlines():
            ln = ln.strip()
            if ln.startswith(key + "="):
                return ln.split("=", 1)[1].split()[0]
        return "?"
    libdir = apkdir + "/lib/arm64" if apkdir else ""
    lib_ls = ""
    if libdir:
        lib_ls = (_run(["shell", _su_wrap('ls -1 "%s" 2>/dev/null' % libdir)], serial=serial, timeout=20).stdout or "").strip()
    obbdir = "/sdcard/Android/obb/%s" % package
    obb_ls = (_run(["shell", 'ls -1 "%s" 2>/dev/null' % obbdir], serial=serial, timeout=20).stdout or "").strip()
    out = {
        "package": package,
        "versionName": _grab("versionName"),
        "versionCode": _grab("versionCode"),
        "apk_paths": apks,
        "apk_dir": apkdir,
        "data_dir": _grab("dataDir"),
        "native_lib_dir": libdir,
        "native_libs": lib_ls.splitlines() if lib_ls else "(none extracted — libs are inside the APK; use pull_apk then unzip lib/arm64-v8a)",
        "obb_dir": obbdir,
        "obb_files": obb_ls.splitlines() if obb_ls else "(none)",
    }
    return json.dumps(out, indent=2)


@mcp.tool()
def pull_apk(package: str, local_dir: str = "", serial: str = "") -> str:
    """Pull a package's APK(s) — base plus any split APKs — to a local directory
    (default ./<package>/). Native .so libs are inside these under lib/arm64-v8a/."""
    apks = _apk_paths(package, serial)
    if not apks:
        return "ERROR: no APK paths for %s (installed? try list_packages)" % package
    local_dir = os.path.abspath(os.path.expanduser(local_dir or package))
    os.makedirs(local_dir, exist_ok=True)
    lines = ["package %s -> %s" % (package, local_dir)]
    for ap in apks:
        dest = os.path.join(local_dir, posixpath.basename(ap))
        ok, method, info = _pull_any(ap, dest, serial)
        lines.append("  %s %s (%s%s)" % ("OK  " if ok else "FAIL",
                                         posixpath.basename(ap), method,
                                         ", %d bytes" % info if ok else ": %s" % info))
    return "\n".join(lines)


@mcp.tool()
def pull_obb(package: str, local_dir: str = "", serial: str = "") -> str:
    """Pull a package's OBB expansion files from /sdcard/Android/obb/<package>/ to a
    local directory (default ./<package>_obb/). Falls back to root if scoped storage
    blocks the shell user."""
    obbdir = "/sdcard/Android/obb/%s" % package
    listing = _run(["shell", _su_wrap('ls -1 "%s" 2>/dev/null' % obbdir)], serial=serial, timeout=20)
    files = [f.strip() for f in (listing.stdout or "").splitlines() if f.strip()]
    if not files:
        return "no OBB files at %s (this game may ship data inside the APK/paks instead)" % obbdir
    local_dir = os.path.abspath(os.path.expanduser(local_dir or (package + "_obb")))
    os.makedirs(local_dir, exist_ok=True)
    lines = ["OBB %s -> %s" % (package, local_dir)]
    for f in files:
        ok, method, info = _pull_any("%s/%s" % (obbdir, f), os.path.join(local_dir, f), serial)
        lines.append("  %s %s (%s%s)" % ("OK  " if ok else "FAIL", f, method,
                                         ", %d bytes" % info if ok else ": %s" % info))
    return "\n".join(lines)


@mcp.tool()
def pull_lib(package: str, local_dir: str = "", lib: str = "", serial: str = "") -> str:
    """Pull a package's extracted native .so libraries (from <apkdir>/lib/arm64/) to a
    local directory (default ./<package>_lib/). `lib` filters by substring (e.g.
    'Unreal' for libUnreal.so). If the app doesn't extract libs, they're packed in
    the APK — use pull_apk and unzip lib/arm64-v8a/ instead."""
    apks = _apk_paths(package, serial)
    if not apks:
        return "ERROR: no APK paths for %s" % package
    libdir = posixpath.dirname(apks[0]) + "/lib/arm64"
    listing = _run(["shell", _su_wrap('ls -1 "%s" 2>/dev/null' % libdir)], serial=serial, timeout=20)
    files = [f.strip() for f in (listing.stdout or "").splitlines() if f.strip().endswith(".so")]
    if lib:
        files = [f for f in files if lib.lower() in f.lower()]
    if not files:
        return ("no matching extracted .so in %s.\nThe app likely ships libs inside the APK "
                "(extractNativeLibs=false). Run:\n  pull_apk('%s')  then unzip lib/arm64-v8a/*.so"
                % (libdir, package))
    local_dir = os.path.abspath(os.path.expanduser(local_dir or (package + "_lib")))
    os.makedirs(local_dir, exist_ok=True)
    lines = ["native libs %s -> %s" % (package, local_dir)]
    for f in files:
        ok, method, info = _pull_any("%s/%s" % (libdir, f), os.path.join(local_dir, f), serial)
        lines.append("  %s %s (%s%s)" % ("OK  " if ok else "FAIL", f, method,
                                         ", %d bytes" % info if ok else ": %s" % info))
    return "\n".join(lines)


# ═══ Diagnostics ══════════════════════════════════════════════════════════════
@mcp.tool()
def logcat(tag: str = "", lines: int = 200, clear_first: bool = False, serial: str = "") -> str:
    """Dump the last N lines of logcat then exit (-d). `tag` filters to a single
    logcat tag (TAG:* *:S). clear_first clears the buffer before reading."""
    if clear_first:
        _run(["logcat", "-c"], serial=serial, timeout=15)
    args = ["logcat", "-d", "-t", str(int(lines))]
    if tag:
        args += ["-s", tag]
    p = _run(args, serial=serial, timeout=40)
    return (p.stdout or p.stderr or "(empty)").rstrip()


@mcp.tool()
def getprop(prop: str = "", serial: str = "") -> str:
    """Read a system property (blank = dump all)."""
    p = _run(["shell", "getprop %s" % prop if prop else "getprop"], serial=serial, timeout=20)
    return _fmt(p)


@mcp.tool()
def dumpsys(service: str, grep: str = "", serial: str = "", timeout: int = 40) -> str:
    """Run `dumpsys <service>`, optionally keeping only lines containing `grep`."""
    p = _run(["shell", "dumpsys %s" % service], serial=serial, timeout=timeout)
    out = p.stdout or ""
    if grep:
        out = "\n".join(ln for ln in out.splitlines() if grep.lower() in ln.lower())
    return out.rstrip()[:12000] or "(empty)"


@mcp.tool()
def raw(args_json: str, serial: str = "", timeout: int = 120) -> str:
    """Escape hatch: run adb with an arbitrary argument list given as a JSON array.
    Example: raw('["shell","ls","-la","/sdcard"]'). The device serial is inserted
    automatically; do not include -s."""
    try:
        args = json.loads(args_json)
        if not isinstance(args, list) or not all(isinstance(a, str) for a in args):
            return "ERROR: args_json must be a JSON array of strings"
    except Exception as e:
        return "ERROR: bad args_json: %s" % e
    p = _run(args, serial=serial, timeout=timeout)
    return _fmt(p)


if __name__ == "__main__":
    mcp.run()
