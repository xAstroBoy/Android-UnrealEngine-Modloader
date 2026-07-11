package com.xastroboy.uemodloader.lsposed;

import android.app.Application;
import android.content.Context;
import android.content.pm.ApplicationInfo;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;

import de.robv.android.xposed.IXposedHookLoadPackage;
import de.robv.android.xposed.IXposedHookZygoteInit;
import de.robv.android.xposed.XC_MethodHook;
import de.robv.android.xposed.XposedBridge;
import de.robv.android.xposed.XposedHelpers;
import de.robv.android.xposed.callbacks.XC_LoadPackage.LoadPackageParam;

/**
 * LSPosed module that loads the native Quest UE4 ModLoader (libmodloader.so)
 * into a target UE4 game process — replacing the old "patch the APK to add
 * System.loadLibrary" install path.
 *
 * How it works
 * ------------
 *  - The payload libmodloader.so is bundled as this module's OWN jniLib, so
 *    Android extracts it to the module's nativeLibraryDir on disk with a
 *    world-readable+executable SELinux label (apk_data_file).
 *  - When LSPosed injects us into a scoped game, we resolve that on-disk path
 *    and System.load() it from inside the game process. libmodloader.so's
 *    JNI_OnLoad then spins up the modloader exactly as if it had been loaded
 *    by a patched APK.
 *
 * Selection: LSPosed's per-app scope (chosen in LSPosed Manager) is the primary
 * gate. Optionally restrict further with /sdcard/UnrealModloader/lsposed_targets.txt
 * (one package name per line; a line "*" means "any scoped app").
 */
public class UeModLoaderModule implements IXposedHookLoadPackage, IXposedHookZygoteInit {

    private static final String TAG = "UEModLoaderLSP";
    private static final String MODULE_PKG = "com.xastroboy.uemodloader.lsposed";
    /** System.load target — libmodloader.so → soname "modloader". */
    private static final String PAYLOAD_SO = "libmodloader.so";
    private static final String PAYLOAD_ENTRY = "lib/arm64-v8a/" + PAYLOAD_SO;
    private static final String TARGETS_FILE = "/sdcard/UnrealModloader/lsposed_targets.txt";

    private static final List<String> KNOWN_TARGETS = Arrays.asList(
            "com.Armature.VR4",         // Resident Evil 4 VR
            "com.zenstudios.PFXVRQuest", // Pinball FX VR
            "com.Capricia.HandBoi"      // Hand Boi
    );

    /** Absolute path to this module's APK — captured at zygote init. */
    private static volatile String sModulePath = null;
    /** The game's classloader — used to load the modloader in the GAME's linker
     *  namespace (so it can see libUnreal.so). */
    private static volatile ClassLoader sGameCl = null;
    /** Per-process guard so we never double-load into one game process. */
    private static boolean sInjected = false;

    @Override
    public void initZygote(StartupParam startupParam) {
        sModulePath = startupParam.modulePath;
    }

    @Override
    public void handleLoadPackage(final LoadPackageParam lpparam) {
        final String pkg = lpparam.packageName;
        if (!shouldInject(pkg)) {
            return;
        }
        // Only inject into the MAIN game process — the one that hosts the UE
        // engine (libUnreal/libUE4). Helper/sub-processes (name "pkg:something")
        // don't run the engine; loading the full modloader there is wasteful and
        // can destabilise the app. Main process name == package name.
        String proc = lpparam.processName;
        if (proc != null && !proc.equals(pkg)) {
            return;
        }
        sGameCl = lpparam.classLoader;
        log("scoped game detected: " + pkg + " (proc=" + proc + ") — arming injector");

        // PRIMARY trigger: poll /proc/self/maps for the engine lib and inject the
        // instant it's mapped. This has NO timing race — it catches the engine
        // whether it loads before or after our module finishes loading (the
        // GameActivity.onCreate hook can be installed ~100ms too late and miss it).
        startEngineWatch(pkg);

        // SECONDARY trigger: GameActivity.onCreate (correct PAK timing when the hook
        // wins the race). We do NOT hook System.loadLibrary/loadLibrary0 — that
        // breaks the caller's classloader context and crashes framework lib loads.
        hookEngineLoad(pkg, lpparam.classLoader);
    }

    /** UE Android activity class(es) whose <clinit> loads the engine library. */
    private static final List<String> GAME_ACTIVITIES = Arrays.asList(
            "com.epicgames.unreal.GameActivity", // UE4.25+ / UE5
            "com.epicgames.ue4.GameActivity");   // older UE4

    private void hookEngineLoad(final String pkg, ClassLoader cl) {
        final XC_MethodHook hook = new XC_MethodHook() {
            @Override
            protected void beforeHookedMethod(MethodHookParam param) {
                Context ctx = (param.thisObject instanceof Context)
                        ? (Context) param.thisObject : currentContext();
                log("GameActivity.onCreate — engine loaded; injecting modloader now");
                injectOnce(ctx, pkg);
            }
        };
        boolean hooked = false;
        for (String act : GAME_ACTIVITIES) {
            try {
                Class<?> c = XposedHelpers.findClass(act, cl);
                XposedHelpers.findAndHookMethod(c, "onCreate", Bundle.class, hook);
                log("hooked " + act + ".onCreate");
                hooked = true;
                break;
            } catch (Throwable ignored) {
            }
        }
        if (!hooked) {
            // Non-UE-standard game: fall back to Application.onCreate. The modloader
            // polls for the engine lib itself, so this still works (just earlier).
            log("no UE GameActivity found — falling back to Application.onCreate");
            XposedHelpers.findAndHookMethod(Application.class, "onCreate", new XC_MethodHook() {
                @Override
                protected void afterHookedMethod(MethodHookParam param) {
                    injectOnce(currentContext(), pkg);
                }
            });
        }
    }

    private static Context currentContext() {
        try {
            return (Context) XposedHelpers.callStaticMethod(
                    XposedHelpers.findClass("android.app.ActivityThread", null),
                    "currentApplication");
        } catch (Throwable t) {
            return null;
        }
    }

    /** Engine lib substrings to watch for in /proc/self/maps. */
    private static final String[] ENGINE_SO = {"libUnreal.so", "libUE4.so", "libUnreal4.so"};

    // ── Frida-gadget (VRSRC patcher / libfrda.so) coexistence ────────────────
    // Some games ship a Frida gadget (e.g. the VRSRC patcher) that aggressively
    // rewrites process memory during the first ~1.5s of boot — its gadget
    // abort()s ~1.4s in. Polling /proc/self/maps via Java String ops during that
    // window races with Frida's ART instrumentation and can corrupt the
    // interpreter's string state, producing a wild-pointer SIGSEGV inside
    // String.indexOf on this watch thread. So we hold off until the gadget has
    // settled before polling. The GameActivity.onCreate hook is the primary,
    // race-free trigger and normally injects before we even wake up, which leaves
    // this watch as a quiet fallback.
    private static final long FRIDA_SETTLE_MS = 2500;

    private void startEngineWatch(final String pkg) {
        Thread t = new Thread(new Runnable() {
            @Override
            public void run() {
                // Let the Frida gadget finish its disruptive boot patching before
                // we touch /proc/self/maps (see FRIDA_SETTLE_MS above).
                try {
                    Thread.sleep(FRIDA_SETTLE_MS);
                } catch (InterruptedException e) {
                    return;
                }
                if (sInjected) {
                    return; // onCreate hook already injected — nothing to do
                }
                // Poll ~250ms for up to ~180s. The engine lib normally maps within
                // a few seconds of process start.
                for (int i = 0; i < 720 && !sInjected; i++) {
                    if (isEngineMapped()) {
                        // Give the engine a moment to finish mapping/relocating.
                        try {
                            Thread.sleep(500);
                        } catch (InterruptedException e) {
                            return;
                        }
                        // CRITICAL: run the actual load on the MAIN thread. The
                        // modloader (built for APK-patching) loads on the game's
                        // main thread and captures JNI refs there; loading it on
                        // this background thread causes cross-thread jobject misuse
                        // ("invalid JNI transition frame reference" → abort/SIGSEGV).
                        log("engine lib mapped — posting modloader load to main thread");
                        new Handler(Looper.getMainLooper()).post(new Runnable() {
                            @Override
                            public void run() {
                                injectOnce(currentContext(), pkg);
                            }
                        });
                        return;
                    }
                    try {
                        Thread.sleep(250);
                    } catch (InterruptedException e) {
                        return;
                    }
                }
            }
        }, "uemodloader-enginewatch");
        t.setDaemon(true);
        t.start();
    }

    private static boolean isEngineMapped() {
        BufferedReader r = null;
        try {
            r = new BufferedReader(new FileReader("/proc/self/maps"));
            String line;
            while ((line = r.readLine()) != null) {
                // maps lines end with the mapped file path, so endsWith is enough.
                // (Avoid contains("/"+so) — it allocates a String per line per poll,
                // churning the heap and widening the Frida instrumentation race.)
                for (String so : ENGINE_SO) {
                    if (line.endsWith(so)) {
                        return true;
                    }
                }
            }
        } catch (Throwable ignored) {
        } finally {
            if (r != null) {
                try {
                    r.close();
                } catch (Throwable ignored) {
                }
            }
        }
        return false;
    }

    // ── Injection ───────────────────────────────────────────────────────────

    private synchronized void injectOnce(Context ctx, String pkg) {
        if (sInjected) {
            return;
        }
        // Loading the modloader is the ONLY thing on the launch path. The storage
        // grant is best-effort and runs fully detached (below) so it can never
        // block or break the game's launch.
        String path = resolvePayloadPath(ctx);
        if (path == null) {
            log("ERROR: could not locate " + PAYLOAD_SO + " — is it bundled in the module's jniLibs? "
                    + "(module path: " + sModulePath + ")");
            return;
        }

        // Copy the payload into the GAME's own data dir. The game's linker namespace
        // only permits loading .so files from paths it controls (its lib/data dirs),
        // NOT the LSPosed module's dir. Loading from the game dir + via the game's
        // classloader puts libmodloader.so in the SAME linker namespace as
        // libUnreal.so — otherwise the modloader can't dlopen/see the engine
        // (namespace isolation → "Timeout waiting for libUnreal.so").
        String loadPath = path;
        if (ctx != null) {
            try {
                File dst = new File(ctx.getCodeCacheDir(), PAYLOAD_SO);
                copyFile(new File(path), dst);
                //noinspection ResultOfMethodCallIgnored
                dst.setReadable(true, false);
                //noinspection ResultOfMethodCallIgnored
                dst.setExecutable(true, false);
                loadPath = dst.getAbsolutePath();
            } catch (Throwable t) {
                log("copy to game codeCacheDir failed (" + t + ") — loading from module dir");
            }
        }

        // Make /sdcard/UnrealModloader/<pkg> the source of truth and bind it onto the
        // game's scoped modloader dir — BEFORE loading the modloader, so the mods are
        // visible at the scoped path when it enumerates them. Runs on a worker thread
        // joined with a bounded wait so a hung `su` grant can't freeze the game launch;
        // never touches app-ops, so it can't kill/restart the game.
        final String bindPkg = pkg;
        Thread bindThread = new Thread(new Runnable() {
            @Override
            public void run() {
                RootShell.bindPublicToScoped(bindPkg);
            }
        }, "uemodloader-bind");
        bindThread.setDaemon(true);
        bindThread.start();
        try {
            bindThread.join(9000);  // covers su's 8s timeout + margin; proceed regardless
        } catch (InterruptedException ignored) {
        }

        if (loadInGameNamespace(loadPath)) {
            sInjected = true;
            log("loaded " + PAYLOAD_SO + " into " + pkg + " (game namespace) from " + loadPath);
        } else {
            // Fallback: plain System.load (module namespace). The modloader may then
            // fail to see libUnreal.so, but at least it's loaded.
            try {
                System.load(loadPath);
                sInjected = true;
                log("loaded " + PAYLOAD_SO + " via System.load fallback (module namespace) from " + loadPath);
            } catch (Throwable t) {
                log("ERROR: System.load(" + loadPath + ") failed: " + t);
                return;
            }
        }

        // (Storage bind is set up above, before the .so load, so the public store is
        // already the source of truth by the time the modloader reads its mods.)
    }

    /**
     * Load the .so in the GAME's linker namespace via Runtime.load0(fromClass,path).
     * The namespace is decided by fromClass.getClassLoader() — a class from the
     * game's classloader → the game's namespace, where libUnreal.so lives.
     */
    private boolean loadInGameNamespace(String path) {
        ClassLoader cl = sGameCl;
        if (cl == null) {
            return false;
        }
        Class<?> fromClass = null;
        for (String c : GAME_ACTIVITIES) {
            try {
                fromClass = cl.loadClass(c);
                break;
            } catch (Throwable ignored) {
            }
        }
        if (fromClass == null) {
            log("game-namespace load: no game class found");
            return false;
        }
        try {
            java.lang.reflect.Method load0 = Runtime.class.getDeclaredMethod(
                    "load0", Class.class, String.class);
            load0.setAccessible(true);
            load0.invoke(Runtime.getRuntime(), fromClass, path);
            return true;
        } catch (Throwable t) {
            log("game-namespace load0 failed: " + t);
            return false;
        }
    }

    private static void copyFile(File src, File dst) throws Exception {
        try (InputStream in = new FileInputStream(src);
             OutputStream os = new FileOutputStream(dst)) {
            byte[] buf = new byte[65536];
            int n;
            while ((n = in.read(buf)) > 0) {
                os.write(buf, 0, n);
            }
        }
    }

    /**
     * Find an on-disk, loadable copy of libmodloader.so. Tries, in order:
     *   1. Module's extracted nativeLibraryDir derived from the APK path.
     *   2. Module's nativeLibraryDir via PackageManager.
     *   3. Extract the lib from the module APK into the game's codeCacheDir.
     */
    private String resolvePayloadPath(Context ctx) {
        // 1. Derive from the module APK path: <apkdir>/lib/arm64/libmodloader.so
        if (sModulePath != null) {
            try {
                File apkDir = new File(sModulePath).getParentFile();
                if (apkDir != null) {
                    File cand = new File(apkDir, "lib/arm64/" + PAYLOAD_SO);
                    if (cand.exists()) {
                        return cand.getAbsolutePath();
                    }
                }
            } catch (Throwable ignored) {
            }
        }

        // 2. Ask PackageManager for the module's nativeLibraryDir.
        if (ctx != null) {
            try {
                ApplicationInfo ai = ctx.getPackageManager().getApplicationInfo(MODULE_PKG, 0);
                if (ai.nativeLibraryDir != null) {
                    File cand = new File(ai.nativeLibraryDir, PAYLOAD_SO);
                    if (cand.exists()) {
                        return cand.getAbsolutePath();
                    }
                }
            } catch (Throwable ignored) {
            }
        }

        // 3. Last resort: extract from the module APK zip into the game's own
        //    code cache (app_data_file for the game UID — usually exec-allowed).
        if (sModulePath != null && ctx != null) {
            try {
                File out = new File(ctx.getCodeCacheDir(), PAYLOAD_SO);
                if (extractFromApk(sModulePath, PAYLOAD_ENTRY, out)) {
                    // Loadable only if it landed executable; try it regardless.
                    return out.getAbsolutePath();
                }
            } catch (Throwable t) {
                log("apk-extract fallback failed: " + t);
            }
        }
        return null;
    }

    private static boolean extractFromApk(String apkPath, String entryName, File out) {
        ZipFile zf = null;
        InputStream in = null;
        OutputStream os = null;
        try {
            zf = new ZipFile(apkPath);
            ZipEntry entry = zf.getEntry(entryName);
            if (entry == null) {
                return false;
            }
            in = zf.getInputStream(entry);
            os = new FileOutputStream(out);
            byte[] buf = new byte[65536];
            int n;
            while ((n = in.read(buf)) > 0) {
                os.write(buf, 0, n);
            }
            os.flush();
            try {
                os.close();
            } catch (Throwable ignored) {
            }
            os = null;
            //noinspection ResultOfMethodCallIgnored
            out.setReadable(true, false);
            //noinspection ResultOfMethodCallIgnored
            out.setExecutable(true, false);
            return true;
        } catch (Throwable t) {
            return false;
        } finally {
            closeQuietly(in);
            closeQuietly(os);
            closeQuietly(zf);
        }
    }

    // ── Target selection ──────────────────────────────────────────────────────

    private boolean shouldInject(String pkg) {
        if (pkg == null) {
            return false;
        }
        if (pkg.equals(MODULE_PKG)) {
            return false;
        }
        // Never inject into core system processes even if mistakenly scoped.
        if (pkg.equals("android")
                || pkg.startsWith("com.android.")
                || pkg.startsWith("com.google.android.")
                || pkg.equals("org.lsposed.manager")
                || pkg.equals("de.robv.android.xposed.installer")) {
            return false;
        }

        List<String> fileTargets = readTargetsFile();
        if (fileTargets != null && !fileTargets.isEmpty()) {
            if (fileTargets.contains("*")) {
                return true; // explicit "inject into any scoped app"
            }
            return fileTargets.contains(pkg);
        }
        // Default: trust the LSPosed scope selection. (KNOWN_TARGETS is only
        // used to pre-populate the recommended scope in the manifest.)
        return true;
    }

    private static List<String> readTargetsFile() {
        File f = new File(TARGETS_FILE);
        if (!f.exists() || !f.canRead()) {
            return null;
        }
        List<String> out = new ArrayList<>();
        FileInputStream in = null;
        try {
            in = new FileInputStream(f);
            byte[] data = new byte[(int) Math.min(f.length(), 1 << 20)];
            int total = 0, n;
            while (total < data.length && (n = in.read(data, total, data.length - total)) > 0) {
                total += n;
            }
            String text = new String(data, 0, total);
            for (String line : text.split("\\r?\\n")) {
                String t = line.trim();
                if (!t.isEmpty() && !t.startsWith("#")) {
                    out.add(t);
                }
            }
        } catch (Throwable ignored) {
        } finally {
            closeQuietly(in);
        }
        return out;
    }

    // ── Utils ─────────────────────────────────────────────────────────────────

    private static void closeQuietly(java.io.Closeable c) {
        if (c != null) {
            try {
                c.close();
            } catch (Throwable ignored) {
            }
        }
    }

    private static void closeQuietly(ZipFile z) {
        if (z != null) {
            try {
                z.close();
            } catch (Throwable ignored) {
            }
        }
    }

    private static void log(String msg) {
        XposedBridge.log("[" + TAG + "] " + msg);
    }
}
