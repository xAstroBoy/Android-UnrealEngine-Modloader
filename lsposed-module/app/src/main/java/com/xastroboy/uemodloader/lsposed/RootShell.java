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
     * Expose the modloader's data at /sdcard/UnrealModloader/&lt;pkg&gt; without any
     * app permission.
     *
     * An unpatched game can't be granted MANAGE_EXTERNAL_STORAGE (it isn't declared,
     * and setting the app-op both fails to stick AND kills the app). Instead we use
     * full root: the modloader writes to its own app-writable scoped dir
     * (/sdcard/Android/data/&lt;pkg&gt;/files/modloader — no permission needed), and we
     * bind-mount that, in the GLOBAL namespace, onto /sdcard/UnrealModloader/&lt;pkg&gt;.
     * The same files then show up at the clean /sdcard path for MTP / file managers,
     * and anything dropped there flows back to the app. Idempotent; re-run each launch
     * (bind-mounts don't survive reboot). Never touches app-ops, so it can't kill the app.
     */
    static void mirrorToSdcard(String pkg) {
        if (pkg == null || pkg.isEmpty()) {
            return;
        }
        String scoped = "/data/media/0/Android/data/" + pkg + "/files/modloader";
        String mirror = "/data/media/0/UnrealModloader/" + pkg;
        boolean ok = run(
                "mkdir -p '" + scoped + "' '" + mirror + "'; "
                        + "mountpoint -q '" + mirror + "' || mount --bind '" + scoped + "' '" + mirror + "'; "
                        + "chmod -R 0777 /data/media/0/UnrealModloader 2>/dev/null; "
                        + "echo mirror-ready");
        XposedBridge.log("[UEModLoaderLSP] /sdcard/UnrealModloader/" + pkg
                + (ok ? " mirrored (root)" : " mirror skipped (no root) — using scoped storage"));
    }
}
