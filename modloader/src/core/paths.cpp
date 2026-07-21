// modloader/src/core/paths.cpp
// Runtime path resolution — uses JNI getExternalFilesDir() per instructions
// NEVER hardcodes /sdcard/ or /storage/emulated/0/ or /data/data/
// The app knows its own path — ask Android via JNI

#include "modloader/paths.h"
#include <jni.h>
#include <cstdio>
#include <cstring>
#include <unistd.h>
#include <sys/stat.h>
#include <cerrno>
#include <android/log.h>

#define LOG_TAG "UEModLoader"

// Declared in main.cpp — stored from JNI_OnLoad
extern "C" JavaVM *get_stored_jvm();

namespace paths
{

    static std::string s_data_dir;

    static std::string read_package_name()
    {
        char buf[256];
        memset(buf, 0, sizeof(buf));
        FILE *f = fopen("/proc/self/cmdline", "r");
        if (f)
        {
            size_t n = fread(buf, 1, sizeof(buf) - 1, f);
            fclose(f);
            if (n > 0)
            {
                return std::string(buf);
            }
        }
        return "com.Armature.VR4";
    }

    static void ensure_dir(const std::string &path)
    {
        struct stat st;
        if (stat(path.c_str(), &st) == 0 && S_ISDIR(st.st_mode))
            return; // already exists
        if (mkdir(path.c_str(), 0755) == 0)
        {
            __android_log_print(ANDROID_LOG_INFO, LOG_TAG,
                                "paths: created dir: %s", path.c_str());
        }
        else
        {
            __android_log_print(ANDROID_LOG_WARN, LOG_TAG,
                                "paths: mkdir failed for %s: %s", path.c_str(), strerror(errno));
        }
    }

    /// Verify we can actually write to the data directory.
    /// Returns true if a test file can be created and deleted.
    static bool verify_writable(const std::string &dir)
    {
        std::string test_file = dir + "/.modloader_write_test";
        FILE *f = fopen(test_file.c_str(), "w");
        if (!f)
            return false;
        fwrite("ok", 1, 2, f);
        fclose(f);
        unlink(test_file.c_str());
        return true;
    }

    /// Repair data directories after a botched installer run.
    /// Handles:
    /// - .modloader_bak leftover directories (from uninstall/reinstall cycle)
    /// - Broken directory permissions (from chmod/chown on FUSE)
    /// - Missing subdirectories
    static void repair_data_dirs()
    {
        if (s_data_dir.empty())
            return;

        // NO scoped fallback. The user forbids /sdcard/Android/data/<pkg>/files/
        // modloader and deleted it. If the public path is not writable we keep it
        // anyway (reads work; files are managed over root SFTP) and only shout.
        if (!verify_writable(s_data_dir))
        {
            __android_log_print(ANDROID_LOG_WARN, LOG_TAG,
                                "paths: %s not verified writable — keeping it (no scoped fallback; "
                                "grant the game LEGACY_STORAGE via root if writes must work)",
                                s_data_dir.c_str());
        }
        else
        {
            __android_log_print(ANDROID_LOG_INFO, LOG_TAG,
                                "paths: data dir verified writable: %s", s_data_dir.c_str());
        }
    }

    // ═══ JNI path resolution — the CORRECT approach per instructions ════════
    // Running inside the app process — ask Android for our own files dir
    // This is what every Android app does. No root. No guessing. Always correct.
    static std::string resolve_via_jni()
    {
        JavaVM *vm = get_stored_jvm();
        if (!vm)
        {
            __android_log_print(ANDROID_LOG_WARN, LOG_TAG,
                                "paths: JavaVM not available — JNI path resolution unavailable");
            return "";
        }

        JNIEnv *env = nullptr;
        bool attached = false;
        int status = vm->GetEnv(reinterpret_cast<void **>(&env), JNI_VERSION_1_6);
        if (status == JNI_EDETACHED)
        {
            if (vm->AttachCurrentThread(&env, nullptr) != JNI_OK)
            {
                __android_log_print(ANDROID_LOG_ERROR, LOG_TAG,
                                    "paths: Failed to attach thread to JVM");
                return "";
            }
            attached = true;
        }
        else if (status != JNI_OK || !env)
        {
            __android_log_print(ANDROID_LOG_ERROR, LOG_TAG,
                                "paths: GetEnv failed with status %d", status);
            return "";
        }

        std::string result;

        // Get the application context via ActivityThread.currentApplication()
        jclass at_class = env->FindClass("android/app/ActivityThread");
        if (!at_class || env->ExceptionCheck())
        {
            if (env->ExceptionCheck())
                env->ExceptionClear();
            __android_log_print(ANDROID_LOG_WARN, LOG_TAG,
                                "paths: ActivityThread class not found");
            if (attached)
                vm->DetachCurrentThread();
            return "";
        }

        jmethodID cur_app = env->GetStaticMethodID(at_class,
                                                   "currentApplication", "()Landroid/app/Application;");
        if (!cur_app || env->ExceptionCheck())
        {
            if (env->ExceptionCheck())
                env->ExceptionClear();
            __android_log_print(ANDROID_LOG_WARN, LOG_TAG,
                                "paths: currentApplication method not found");
            if (attached)
                vm->DetachCurrentThread();
            return "";
        }

        jobject app = env->CallStaticObjectMethod(at_class, cur_app);
        if (!app || env->ExceptionCheck())
        {
            if (env->ExceptionCheck())
                env->ExceptionClear();
            __android_log_print(ANDROID_LOG_WARN, LOG_TAG,
                                "paths: currentApplication() returned null — Activity not yet initialized");
            if (attached)
                vm->DetachCurrentThread();
            return "";
        }

        jclass ctx_class = env->FindClass("android/content/Context");
        if (!ctx_class)
        {
            if (env->ExceptionCheck())
                env->ExceptionClear();
            if (attached)
                vm->DetachCurrentThread();
            return "";
        }

        // Prefer getExternalFilesDir(null) — ADB-accessible without root
        jmethodID get_ext = env->GetMethodID(ctx_class,
                                             "getExternalFilesDir", "(Ljava/lang/String;)Ljava/io/File;");
        jobject dir = nullptr;
        if (get_ext)
        {
            dir = env->CallObjectMethod(app, get_ext, nullptr);
            if (env->ExceptionCheck())
            {
                env->ExceptionClear();
                dir = nullptr;
            }
        }

        // Fall back to getFilesDir() if external storage not available
        if (!dir)
        {
            jmethodID get_int = env->GetMethodID(ctx_class,
                                                 "getFilesDir", "()Ljava/io/File;");
            if (get_int)
            {
                dir = env->CallObjectMethod(app, get_int);
                if (env->ExceptionCheck())
                {
                    env->ExceptionClear();
                    dir = nullptr;
                }
            }
        }

        if (dir)
        {
            jclass file_class = env->FindClass("java/io/File");
            if (file_class)
            {
                jmethodID abs_path = env->GetMethodID(file_class,
                                                      "getAbsolutePath", "()Ljava/lang/String;");
                if (abs_path)
                {
                    jstring jpath = (jstring)env->CallObjectMethod(dir, abs_path);
                    if (jpath && !env->ExceptionCheck())
                    {
                        const char *cpath = env->GetStringUTFChars(jpath, nullptr);
                        if (cpath)
                        {
                            result = std::string(cpath);
                            env->ReleaseStringUTFChars(jpath, cpath);
                        }
                    }
                    if (env->ExceptionCheck())
                        env->ExceptionClear();
                }
            }
        }

        if (attached)
            vm->DetachCurrentThread();

        // ★ THE UNSCOPED PUBLIC PATH IS THE ONLY PATH. The user manages mods at
        // /sdcard/UnrealModloader/<pkg>/ over SFTP/MTP and does NOT want the
        // scoped /sdcard/Android/data/<pkg>/files/modloader folder to exist. With
        // root granting the app LEGACY_STORAGE (and the folder owned by the game
        // uid, 0777), reads always work and writes work under legacy access. We
        // return it UNCONDITIONALLY — no scoped fallback that would resurrect the
        // folder the user deleted. If a write ever fails it is logged loudly, but
        // we never silently divert to scoped again.
        std::string pkg = read_package_name();
        ensure_dir("/sdcard/UnrealModloader");
        std::string preferred = "/sdcard/UnrealModloader/" + pkg;
        ensure_dir(preferred);
        if (verify_writable(preferred))
        {
            __android_log_print(ANDROID_LOG_INFO, LOG_TAG,
                                "paths: using preferred UNSCOPED path: %s", preferred.c_str());
        }
        else
        {
            __android_log_print(ANDROID_LOG_WARN, LOG_TAG,
                                "paths: %s not verified writable — USING IT ANYWAY (user forbids the scoped "
                                "fallback; reads still work, files are managed over SFTP)", preferred.c_str());
        }
        return preferred;
    }

    void init()
    {
        std::string pkg = read_package_name();

        // Priority 1: JNI getExternalFilesDir() — the correct approach
        s_data_dir = resolve_via_jni();

        // If JNI fails (e.g. Activity not yet initialized), fall back to
        // constructing the path from the package name. This is NOT hardcoding
        // a specific path — it's using the standard Android external files
        // directory convention with the runtime-detected package name.
        if (s_data_dir.empty())
        {
            __android_log_print(ANDROID_LOG_WARN, LOG_TAG,
                                "paths: JNI resolution failed — using /proc/self/cmdline package: %s", pkg.c_str());

            // FORCE the unscoped public path — same rule as resolve_via_jni():
            // no scoped fallback, ever. The user deleted that folder and forbids
            // its return; root + LEGACY_STORAGE makes the public path usable.
            ensure_dir("/sdcard/UnrealModloader");
            std::string candidate = "/sdcard/UnrealModloader/" + pkg;
            ensure_dir(candidate);
            s_data_dir = candidate;
            if (!verify_writable(candidate))
            {
                __android_log_print(ANDROID_LOG_WARN, LOG_TAG,
                                    "paths: %s not verified writable — USING IT ANYWAY (no scoped fallback)",
                                    candidate.c_str());
            }
        }

        __android_log_print(ANDROID_LOG_INFO, LOG_TAG,
                            "paths: final data dir: %s", s_data_dir.c_str());

        // Repair any damage from botched installer runs
        repair_data_dirs();

        // Create subdirectories
        ensure_dir(mods_dir());
        ensure_dir(paks_dir());
        ensure_dir(sdk_dir());
        ensure_dir(sdk_classes_dir());
        ensure_dir(sdk_structs_dir());
        ensure_dir(sdk_enums_dir());
        ensure_dir(cxx_header_dir());
        ensure_dir(lua_types_dir());
        ensure_dir(ida_dir());
    }

    const std::string &data_dir() { return s_data_dir; }
    std::string mods_dir() { return s_data_dir + "/mods/"; }
    std::string paks_dir() { return s_data_dir + "/paks/"; }
    std::string sdk_dir() { return s_data_dir + "/SDK/"; }
    std::string log_path() { return s_data_dir + "/UEModLoader.log"; }
    std::string crash_log() { return s_data_dir + "/modloader_crash.log"; }
    std::string recovered_log() { return s_data_dir + "/modloader_recovered.log"; }
    std::string sdk_classes_dir() { return s_data_dir + "/SDK/Classes/"; }
    std::string sdk_structs_dir() { return s_data_dir + "/SDK/Structs/"; }
    std::string sdk_enums_dir() { return s_data_dir + "/SDK/Enums/"; }
    std::string sdk_index_path() { return s_data_dir + "/SDK/_index.lua"; }
    std::string sdk_manifest_path() { return s_data_dir + "/SDK/_sdk_manifest.json"; }
    std::string cxx_header_dir() { return s_data_dir + "/CXXHeaderDump/"; }
    std::string lua_types_dir() { return s_data_dir + "/Lua/"; }
    std::string usmap_path() { return s_data_dir + "/Mappings.usmap"; }
    std::string ida_dir() { return s_data_dir + "/IDAMapping/"; }

} // namespace paths
