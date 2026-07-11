package com.xastroboy.uemodloader.lsposed;

import java.io.OutputStream;
import java.util.concurrent.TimeUnit;

import de.robv.android.xposed.XposedBridge;

/**
 * Minimal Magisk `su` helper. The module runs as the game's UID and cannot grant
 * itself privileged app-ops, so we shell out to root to grant the target game the
 * storage access the modloader needs for its /sdcard/UnrealModloader data dir.
 *
 * Magisk must allow su for the game's UID. If su is denied/absent, the call is a
 * no-op (logged) and the modloader falls back to scoped/internal storage.
 */
final class RootShell {

    private RootShell() {
    }

    /**
     * Run shell lines through `su`, bounded by a timeout so a Magisk prompt that
     * never gets answered (e.g. in VR) can't hang the caller forever.
     * MUST NOT be called on the app's main/launch thread.
     */
    static boolean run(String... cmds) {
        Process p = null;
        try {
            // -M = run in the GLOBAL mount namespace, so bind-mounts we create are
            // visible to file managers / MTP (not just this app's private namespace).
            p = Runtime.getRuntime().exec(new String[]{"su", "-M"});
            OutputStream os = p.getOutputStream();
            for (String c : cmds) {
                os.write((c + "\n").getBytes());
            }
            os.write("exit\n".getBytes());
            os.flush();
            os.close();
            if (!p.waitFor(8, TimeUnit.SECONDS)) {
                p.destroyForcibly();
                XposedBridge.log("[UEModLoaderLSP] su timed out (no root grant?) — skipping");
                return false;
            }
            return p.exitValue() == 0;
        } catch (Throwable t) {
            XposedBridge.log("[UEModLoaderLSP] su unavailable (" + t + ")");
            return false;
        } finally {
            if (p != null) {
                try {
                    p.destroy();
                } catch (Throwable ignored) {
                }
            }
        }
    }

    /**
     * Grant the game MANAGE_EXTERNAL_STORAGE — but ONLY if it isn't already
     * allowed. Android kills+restarts a running app every time that app-op is
     * *set* (even to the same value: it fires "MANAGE_EXTERNAL_STORAGE changed"),
     * so an unconditional set on each launch causes a restart loop. Checking
     * first means at most ONE restart, ever (the first cold grant); afterwards
     * it's a no-op. Best pre-grant it from adb while the game is closed to avoid
     * even that one restart.
     */
    /**
     * Make /sdcard/UnrealModloader/&lt;pkg&gt; the SOURCE OF TRUTH for the modloader's
     * data, and expose it to the injected game with no app permission.
     *
     * The game can't be granted MANAGE_EXTERNAL_STORAGE (not declared; setting the
     * app-op fails to stick AND kills the app), so it can only touch its own scoped
     * dir (/sdcard/Android/data/&lt;pkg&gt;/files/modloader). Rather than let that scoped
     * dir be the real store — which an app UNINSTALL would wipe — we keep the real
     * data in the public /sdcard/UnrealModloader/&lt;pkg&gt; and bind-mount THAT onto the
     * scoped path (global namespace via `su -M`, so file managers/MTP see it too).
     * The modloader then reads/writes the public store transparently, and an uninstall
     * only clears the empty scoped mountpoint — the mods survive.
     *
     * MUST run BEFORE the modloader enumerates mods (the bind has to be in place when
     * it reads the scoped path). One-time migration copies any pre-existing scoped data
     * into the public store so upgrading users don't lose their current mods. Idempotent
     * (skips if already bound); re-run each launch — bind-mounts don't survive reboot.
     */
    static void bindPublicToScoped(String pkg) {
        if (pkg == null || pkg.isEmpty()) {
            return;
        }
        String scoped = "/data/media/0/Android/data/" + pkg + "/files/modloader";
        String pub = "/data/media/0/UnrealModloader/" + pkg;
        boolean ok = run(
                "mkdir -p '" + pub + "' '" + scoped + "'; "
                        + "if ! mountpoint -q '" + scoped + "'; then "
                        // one-time migration: real scoped data -> public store (only if public is empty)
                        + "  if [ -z \"$(ls -A '" + pub + "' 2>/dev/null)\" ] && [ -n \"$(ls -A '" + scoped + "' 2>/dev/null)\" ]; then "
                        + "    cp -a '" + scoped + "/.' '" + pub + "/' 2>/dev/null; "
                        + "  fi; "
                        // public is the source of truth; bind it onto the app's scoped path
                        + "  mount --bind '" + pub + "' '" + scoped + "'; "
                        + "fi; "
                        + "chmod -R 0777 '" + pub + "' 2>/dev/null; "
                        + "echo bind-ready");
        XposedBridge.log("[UEModLoaderLSP] " + pub + (ok
                ? " is the source of truth (bound onto scoped; survives uninstall)"
                : " bind skipped (no root) — falling back to scoped storage (lost on uninstall)"));
    }
}
