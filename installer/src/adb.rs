// ═══════════════════════════════════════════════════════════════════════
//  ADB — Quest detection, pull/install APKs, backup/restore game data
// ═══════════════════════════════════════════════════════════════════════

use anyhow::{bail, Context, Result};
use std::path::{Path, PathBuf};
use std::process::Command;

use crate::tools_setup;

// ── Find ADB ────────────────────────────────────────────────────────────

pub fn find_adb() -> Result<PathBuf> {
    // Use tools_setup which has auto-download capability
    if let Some(p) = tools_setup::find_adb() {
        return Ok(p);
    }
    bail!("ADB not found. The installer can download it automatically — use the GUI or run with --setup-tools")
}

fn adb_s(serial: &str, args: &[&str]) -> Result<std::process::Output> {
    let bin = find_adb()?;
    Command::new(&bin)
        .arg("-s").arg(serial)
        .args(args)
        .output()
        .with_context(|| format!("adb -s {} {}", serial, args.join(" ")))
}

pub fn shell(serial: &str, cmd: &str) -> Result<String> {
    let o = adb_s(serial, &["shell", cmd])?;
    Ok(String::from_utf8_lossy(&o.stdout).trim().to_string())
}

pub fn path_exists(serial: &str, remote: &str) -> Result<bool> {
    let out = shell(serial, &format!("[ -e '{}' ] && echo Y || echo N", remote))?;
    Ok(out.contains('Y'))
}

// ── Device Discovery ────────────────────────────────────────────────────

#[derive(Debug, Clone)]
pub struct Device {
    pub serial: String,
    pub model: String,
    pub is_quest: bool,
}

pub fn list_devices() -> Result<Vec<Device>> {
    let bin = find_adb()?;
    let o = Command::new(&bin).args(["devices", "-l"]).output()?;
    let stdout = String::from_utf8_lossy(&o.stdout);
    let mut devs = Vec::new();
    for line in stdout.lines().skip(1) {
        let parts: Vec<&str> = line.split_whitespace().collect();
        if parts.len() < 2 || parts[1] != "device" { continue; }
        let serial = parts[0].to_string();
        let model = parts.iter()
            .find_map(|p| p.strip_prefix("model:"))
            .unwrap_or("Unknown").to_string();
        let is_quest = model.contains("Quest")
            || model.contains("Hollywood")
            || model.contains("Eureka")
            || model.contains("Seacliff")
            || shell(&serial, "getprop ro.product.brand 2>/dev/null")
                .map(|b| b.to_lowercase().contains("oculus") || b.to_lowercase().contains("meta"))
                .unwrap_or(false);
        devs.push(Device { serial, model, is_quest });
    }
    Ok(devs)
}

// ── Package Info ────────────────────────────────────────────────────────

#[derive(Debug, Clone)]
pub struct InstalledApp {
    pub package: String,
    pub apk_path: String,
    pub version: String,
}

/// List all installed APK packages (user + system) that have a resolvable APK path.
///
/// Uses `pm list packages -f` to get package + base APK path in one call.
/// Version is left as "?" for speed; call `get_installed_app` for a specific
/// package if exact version is needed.
pub fn list_installed_apps(serial: &str) -> Result<Vec<InstalledApp>> {
    let out = shell(serial, "pm list packages -f 2>/dev/null")?;
    let mut apps = Vec::new();

    for raw_line in out.lines() {
        let line = raw_line.trim();
        if !line.starts_with("package:") {
            continue;
        }

        // Expected format:
        // package:/data/app/~~.../com.foo.bar/base.apk=com.foo.bar
        let body = line.trim_start_matches("package:");
        let mut parts = body.rsplitn(2, '=');
        let package = parts.next().unwrap_or("").trim();
        let apk_path = parts.next().unwrap_or("").trim();

        if package.is_empty() || apk_path.is_empty() {
            continue;
        }

        apps.push(InstalledApp {
            package: package.to_string(),
            apk_path: apk_path.to_string(),
            version: "?".to_string(),
        });
    }

    apps.sort_by(|a, b| a.package.cmp(&b.package));
    Ok(apps)
}

pub fn get_installed_app(serial: &str, package: &str) -> Result<Option<InstalledApp>> {
    let out = shell(serial, &format!("pm path {} 2>/dev/null", package))?;
    if !out.starts_with("package:") { return Ok(None); }
    let apk = out.strip_prefix("package:").unwrap_or(&out).trim().to_string();
    let ver_out = shell(serial, &format!(
        "dumpsys package {} 2>/dev/null | grep versionName | head -1", package
    )).unwrap_or_default();
    let version = ver_out.split("versionName=").nth(1)
        .and_then(|v| v.split_whitespace().next())
        .unwrap_or("?").to_string();
    Ok(Some(InstalledApp { package: package.to_string(), apk_path: apk, version }))
}

/// Check which known games are installed
pub fn find_installed_games(serial: &str, packages: &[&str]) -> Result<Vec<InstalledApp>> {
    let mut found = Vec::new();
    for pkg in packages {
        if let Some(app) = get_installed_app(serial, pkg)? {
            found.push(app);
        }
    }
    Ok(found)
}

// ── Pull APK ────────────────────────────────────────────────────────────

pub fn pull_apk(serial: &str, app: &InstalledApp, dest_dir: &Path) -> Result<PathBuf> {
    let local = dest_dir.join(format!("{}.apk", app.package));
    log::info!("Pulling APK from device...");
    let o = adb_s(serial, &["pull", &app.apk_path, &local.to_string_lossy()])?;
    if !o.status.success() {
        bail!("Failed to pull APK: {}", String::from_utf8_lossy(&o.stderr));
    }
    let size = std::fs::metadata(&local).map(|m| m.len() / 1_000_000).unwrap_or(0);
    log::info!("Pulled {} ({} MB)", local.display(), size);
    Ok(local)
}

pub fn pull_path(serial: &str, remote: &str, local: &Path) -> Result<()> {
    if let Some(parent) = local.parent() {
        std::fs::create_dir_all(parent)?;
    }
    let o = adb_s(serial, &["pull", remote, &local.to_string_lossy()])?;
    if !o.status.success() {
        bail!(
            "Pull failed ({}): {}{}",
            remote,
            String::from_utf8_lossy(&o.stdout),
            String::from_utf8_lossy(&o.stderr)
        );
    }
    Ok(())
}

pub fn push_path(serial: &str, local: &Path, remote: &str) -> Result<()> {
    let o = adb_s(serial, &["push", &local.to_string_lossy(), remote])?;
    if !o.status.success() {
        bail!(
            "Push failed ({} -> {}): {}{}",
            local.display(),
            remote,
            String::from_utf8_lossy(&o.stdout),
            String::from_utf8_lossy(&o.stderr)
        );
    }
    Ok(())
}

// ── Install APK ─────────────────────────────────────────────────────────

pub fn install_apk(serial: &str, apk: &Path) -> Result<()> {
    log::info!("Installing {}...", apk.file_name().unwrap_or_default().to_string_lossy());
    let o = adb_s(serial, &["install", "-r", "-d", "-g", &apk.to_string_lossy()])?;
    let out = String::from_utf8_lossy(&o.stdout);
    if out.contains("Success") { return Ok(()); }
    let err = String::from_utf8_lossy(&o.stderr);
    bail!("Install failed: {}{}", out.trim(), err.trim())
}

pub fn uninstall(serial: &str, package: &str) -> Result<()> {
    log::info!("Uninstalling {}...", package);
    let o = adb_s(serial, &["shell", "pm", "uninstall", package])?;
    let out = String::from_utf8_lossy(&o.stdout);
    if !out.contains("Success") && !out.contains("Unknown package") {
        log::warn!("Uninstall result: {}", out.trim());
    }
    Ok(())
}

pub fn force_stop(serial: &str, package: &str) -> Result<()> {
    shell(serial, &format!("am force-stop {}", package))?;
    Ok(())
}

pub fn launch(serial: &str, package: &str) -> Result<()> {
    shell(serial, &format!(
        "monkey -p {} -c android.intent.category.LAUNCHER 1 2>/dev/null", package
    ))?;
    Ok(())
}

// ── Push file to device ─────────────────────────────────────────────────

pub fn push(serial: &str, local: &Path, remote: &str) -> Result<()> {
    let o = adb_s(serial, &["push", &local.to_string_lossy(), remote])?;
    if !o.status.success() {
        bail!("Push failed: {}", String::from_utf8_lossy(&o.stderr));
    }
    Ok(())
}

// ── OBB / Data Backup & Restore ─────────────────────────────────────────
// Rename dirs BEFORE uninstall so Android doesn't wipe them,
// rename back AFTER install so the game finds them.

/// Move the game's data aside so `uninstall` cannot delete it, and hand back the
/// (original, backup) pairs for restore_game_dirs().
///
/// Uninstall wipes the OBB, the app's external data AND its internal data. On RE4
/// that is 7.9 GB of OBB plus the actual progress save — re-downloading 8 GB per
/// re-patch is what makes people avoid updating. `mv` on the same filesystem is
/// instant regardless of size, so this costs nothing.
///
/// What lives where (verified on com.Armature.VR4):
///   /sdcard/Android/obb/<pkg>/              main+patch .obb   ~7.9 GB
///   /sdcard/Android/data/<pkg>/files/savegame00.sav           ~2 MB  ← REAL PROGRESS SAVE
///   /data/data/<pkg>/.../Saved/SaveGames/System.sav           ~3 KB  ← settings only
///
/// The internal dir needs root (the stock APK is not debuggable, so `run-as` is
/// refused and its manifest has allowBackup=false, so `adb backup` is refused too
/// — which is exactly why saves seem impossible to extract from a stock install).
/// It is therefore BEST-EFFORT: if root is unavailable we log and continue, since
/// only settings are at stake. Note the patched APK sets debuggable + allowBackup,
/// so afterwards `run-as <pkg>` and `adb backup` both work with no root.
pub fn backup_game_dirs(serial: &str, package: &str) -> Result<Vec<(String, String)>> {
    let mut backed = Vec::new();
    let dirs = [
        format!("/sdcard/Android/obb/{}", package),
        format!("/sdcard/Android/data/{}", package),
    ];
    for dir in &dirs {
        let bak = format!("{}.modloader_bak", dir);
        let exists = shell(serial, &format!("[ -d '{}' ] && echo Y || echo N", dir))?;
        if exists.contains('Y') {
            shell(serial, &format!("rm -rf '{}'", bak))?;
            shell(serial, &format!("mv '{}' '{}'", dir, bak))?;
            log::info!("Backed up {} → {}", dir, bak);
            backed.push((dir.clone(), bak));
        }
    }

    // ── INTERNAL DATA — this is where the SAVE actually lives ──────────────
    // It is NOT in /sdcard/Android/data. Verified on-device:
    //     /data/data/<pkg>/files/UE4Game/VR4/VR4/Saved/SaveGames/System.sav
    // and a search of /sdcard/Android/data/<pkg> finds no save at all. This code
    // used to log "the progress save lives in /sdcard/Android/data and IS
    // preserved" and skip internal entirely without root — so the uninstall wiped
    // the save and the installer reported success. That is what ate people's
    // progress (and the shader cache in /data/data/<pkg>/cache, which is why the
    // "one time optimization" screen came back).
    //
    // Two ways in, in order:
    //   1. root (su)     — works on any install.
    //   2. run-as        — NO ROOT NEEDED, but only if the installed APK is
    //                      DEBUGGABLE. Stock RE4 is not; OUR PATCHED APK IS
    //                      (fix_manifest sets debuggable="true"), so every
    //                      re-install after the first one can preserve the save.
    // If neither works (stock APK, no root) the save genuinely cannot be read —
    // that is an Android guarantee, not something we can code around. Say so
    // LOUDLY instead of lying.
    let internal = format!("/data/data/{}", package);
    let bak = format!("/data/local/tmp/{}.internal_bak", package);

    let has_root = shell(serial, &format!(
        "su -c \"[ -d '{}' ] && echo Y || echo N\" 2>/dev/null", internal
    )).unwrap_or_default().contains('Y');

    if has_root {
        let _ = shell(serial, &format!("su -c \"rm -rf '{}'\" 2>/dev/null", bak));
        let r = shell(serial, &format!(
            "su -c \"cp -a '{}' '{}' && echo OK\" 2>/dev/null", internal, bak
        )).unwrap_or_default();
        if r.contains("OK") {
            log::info!("Backed up the SAVE + settings (root) → {}", bak);
            backed.push((internal, bak));
            return Ok(backed);
        }
        log::warn!("root backup of {} failed — trying run-as", internal);
    }

    // run-as: no root required, needs a debuggable (= already patched) APK.
    if can_run_as(serial, package) {
        match backup_internal_via_runas(serial, package) {
            Ok(true) => {
                log::info!("Backed up the SAVE + settings via run-as (no root needed)");
                backed.push((internal, RUNAS_BAK.to_string()));
                return Ok(backed);
            }
            Ok(false) | Err(_) => log::warn!("run-as backup produced nothing"),
        }
    }

    log::warn!("╔══════════════════════════════════════════════════════════════════╗");
    log::warn!("║  SAVE GAME CANNOT BE BACKED UP ON THIS DEVICE                     ║");
    log::warn!("╚══════════════════════════════════════════════════════════════════╝");
    log::warn!("The save lives in INTERNAL storage:");
    log::warn!("    /data/data/{}/files/UE4Game/VR4/VR4/Saved/SaveGames/", package);
    log::warn!("Reading that needs EITHER root OR a debuggable app. This device has");
    log::warn!("no root and the CURRENTLY INSTALLED apk is not debuggable (= it is");
    log::warn!("the stock store build), so Android will not let us read it.");
    log::warn!("");
    log::warn!("=> Installing WILL ERASE your save and re-show the one-time");
    log::warn!("   optimization screen. Back it up in-game / via Meta cloud first.");
    log::warn!("=> This is a ONE-TIME cost: the patched apk IS debuggable, so every");
    log::warn!("   FUTURE re-install preserves the save automatically via run-as.");
    Ok(backed)
}

/// Where a run-as backup is stashed on the PC side of the install.
pub const RUNAS_BAK: &str = "<runas-tar>";

/// Can we read the app's private data with no root? Only if the installed APK is
/// debuggable — our patched one is, the stock store build is not.
pub fn can_run_as(serial: &str, package: &str) -> bool {
    shell(serial, &format!("run-as {} echo RUNAS_OK 2>&1", package))
        .map(|s| s.contains("RUNAS_OK") && !s.contains("not debuggable"))
        .unwrap_or(false)
}

fn runas_tar_path() -> std::path::PathBuf {
    std::env::temp_dir().join("uml_internal_bak.tar")
}

/// tar the app's private data straight to the PC. `exec-out` (not `shell`) so the
/// binary stream isn't mangled by the shell's line-ending translation.
fn backup_internal_via_runas(serial: &str, package: &str) -> Result<bool> {
    let bin = crate::tools_setup::find_adb()
        .ok_or_else(|| anyhow::anyhow!("adb not found"))?;
    let out = Command::new(&bin)
        .args([
            "-s", serial, "exec-out",
            &format!("run-as {} tar -cf - files shared_prefs databases 2>/dev/null", package),
        ])
        .output()?;
    // A failed run-as still "succeeds" with an empty/whining stream — require real bytes.
    if !out.status.success() || out.stdout.len() < 1024 {
        return Ok(false);
    }
    std::fs::write(runas_tar_path(), &out.stdout)?;
    log::info!("Save backup: {} KB → {}", out.stdout.len() / 1024, runas_tar_path().display());
    Ok(true)
}

/// Push the tar back and unpack it as the app uid. /data/local/tmp is 0771
/// shell:shell — "others" get --x, so the app can TRAVERSE it and open a file
/// inside as long as the file itself is world-readable. Hence the chmod 644.
fn restore_internal_via_runas(serial: &str, package: &str) -> Result<bool> {
    let tar = runas_tar_path();
    if !tar.exists() { return Ok(false); }
    if !can_run_as(serial, package) {
        log::warn!("Save restore: the new APK is not debuggable — cannot run-as. \
                    Backup kept at {}", tar.display());
        return Ok(false);
    }
    let remote = "/data/local/tmp/uml_internal_bak.tar";
    push(serial, &tar, remote)?;
    let _ = shell(serial, &format!("chmod 644 {}", remote));
    let r = shell(serial, &format!(
        "run-as {} tar -xf {} -C /data/data/{} && echo RESTORE_OK 2>&1",
        package, remote, package
    )).unwrap_or_default();
    let _ = shell(serial, &format!("rm -f {}", remote));
    if r.contains("RESTORE_OK") {
        // Verify the save is actually back — never report a restore we didn't check.
        let chk = shell(serial, &format!(
            "run-as {} ls files/UE4Game/VR4/VR4/Saved/SaveGames 2>/dev/null", package
        )).unwrap_or_default();
        if chk.contains(".sav") {
            log::info!("✓ Save restored and VERIFIED (SaveGames/*.sav present)");
        } else {
            log::warn!("tar unpacked but no *.sav found — the app may not have had a save yet");
        }
        let _ = std::fs::remove_file(&tar);
        return Ok(true);
    }
    log::warn!("Save restore via run-as failed: {} (backup kept at {})", r.trim(), tar.display());
    Ok(false)
}

pub fn restore_game_dirs(serial: &str, backups: &[(String, String)]) -> Result<()> {
    for (orig, bak) in backups {
        // A run-as backup lives in a tar on the PC, not in a device dir.
        if bak == RUNAS_BAK {
            let pkg = orig.trim_start_matches("/data/data/");
            match restore_internal_via_runas(serial, pkg) {
                Ok(true) => {}
                _ => log::warn!(
                    "SAVE NOT RESTORED — the tar is kept at {}. Re-run the installer \
                     once the patched (debuggable) app is installed and it will go back.",
                    std::env::temp_dir().join("uml_internal_bak.tar").display()
                ),
            }
            continue;
        }
        // Internal data lives under /data — needs root and must keep the NEW
        // install's uid ownership, so it is merged via su + restorecon instead.
        if orig.starts_with("/data/data/") {
            let ok = shell(serial, &format!(
                "su -c \"cp -a '{}/.' '{}/' && restorecon -R '{}' 2>/dev/null; echo OK\" 2>/dev/null",
                bak, orig, orig
            )).unwrap_or_default();
            if ok.contains("OK") {
                // The new install owns the dir; re-apply its uid to the merged files.
                let uid = shell(serial, &format!(
                    "su -c \"stat -c %u '{}'\" 2>/dev/null", orig
                )).unwrap_or_default();
                let uid = uid.trim();
                if !uid.is_empty() {
                    let _ = shell(serial, &format!(
                        "su -c \"chown -R {}:{} '{}'\" 2>/dev/null", uid, uid, orig
                    ));
                }
                let _ = shell(serial, &format!("su -c \"rm -rf '{}'\" 2>/dev/null", bak));
                log::info!("Restored internal data (settings) → {}", orig);
            } else {
                log::warn!("Could not restore {} (left at {})", orig, bak);
            }
            continue;
        }
        let exists = shell(serial, &format!("[ -d '{}' ] && echo Y || echo N", bak))?;
        if exists.contains('Y') {
            // If the new install already recreated the dir, merge into it.
            // NOTE: `cp -a src/.` not `cp -a src/*` — the glob silently skips
            // DOTFILES, and the game keeps state in them (.sdk_dumped etc).
            let new_exists = shell(serial, &format!("[ -d '{}' ] && echo Y || echo N", orig))?;
            if new_exists.contains('Y') {
                shell(serial, &format!("cp -a '{}/.' '{}/' 2>/dev/null", bak, orig))?;
            } else {
                shell(serial, &format!("mv '{}' '{}'", bak, orig))?;
            }
            // Only drop the backup once the data is verifiably back.
            let restored = shell(serial, &format!("[ -d '{}' ] && echo Y || echo N", orig))?;
            if restored.contains('Y') {
                shell(serial, &format!("rm -rf '{}'", bak))?;
                log::info!("Restored {} → {}", bak, orig);
            } else {
                log::error!(
                    "Restore of {} FAILED — your data is still at {}. Not deleting it.",
                    orig, bak
                );
            }
        }
    }
    Ok(())
}

/// Check if libmodloader.so is already in the APK's native lib dir
pub fn is_modloader_installed(serial: &str, package: &str) -> Result<bool> {
    let out = shell(serial, &format!(
        "pm dump {} 2>/dev/null | grep nativeLibraryDir | head -1", package
    ))?;
    let dir = out.split('=').nth(1).unwrap_or("").trim();
    if dir.is_empty() { return Ok(false); }
    let check = shell(serial, &format!("ls {}/libmodloader.so 2>/dev/null", dir))?;
    Ok(check.contains("libmodloader"))
}
