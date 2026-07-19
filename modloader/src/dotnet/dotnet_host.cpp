// modloader/src/dotnet/dotnet_host.cpp
// Hosts .NET (CoreCLR) inside the game so C# mods run — LemonLoader-style, but
// via the modern runtime the device actually ships (.NET 8 CoreCLR), not Mono.
//
// Boot: dlopen libhostfxr.so from an EXEC-allowed .NET runtime root
// (/data/data/<pkg>/dotnet — /sdcard is mounted noexec so the runtime's native
// libs cannot live there), initialize it with our runtimeconfig.json, get the
// load_assembly_and_get_function_pointer delegate, load UEModLoader.dll, and
// call its [UnmanagedCallersOnly] Bootstrap/Tick/Shutdown entry points.
//
// Bridge: managed → native is P/Invoke into the ueml_* functions THIS file
// exports (extern "C", default visibility); native → managed is the delegate
// pointers above. All soft: if the runtime root isn't present the loader boots
// exactly as before.

#include "modloader/dotnet_host.h"
#include "modloader/logger.h"
#include "modloader/paths.h"
#include "modloader/config.h"
#include "modloader/reflection_walker.h"
#include "modloader/native_hooks.h"
#include "modloader/codepatch.h"
#include "modloader/arm64_asm.h"
#include "modloader/process_event_hook.h"
#include "modloader/symbols.h"
#include "modloader/types.h"
#include "modloader/lua_engine.h"
#include "modloader/adb_bridge.h"
#include "modloader/csharp_proxy_generator.h"

#include <dlfcn.h>
#include <dirent.h>
#include <sys/stat.h>
#include <cstdio>
#include <cstring>
#include <cstdlib>
#include <fcntl.h>
#include <unistd.h>
#include <string>
#include <vector>
#include <mutex>

// ═══════════════════════════════════════════════════════════════════════════
// hostfxr / coreclr hosting ABI (char_t = char on Unix; UTF-8 paths)
// ═══════════════════════════════════════════════════════════════════════════
extern "C"
{
    typedef int32_t (*hostfxr_initialize_for_runtime_config_fn)(
        const char *runtime_config_path, const void *parameters, void **host_context_handle);
    typedef int32_t (*hostfxr_get_runtime_delegate_fn)(
        void *host_context_handle, int delegate_type, void **delegate);
    typedef int32_t (*hostfxr_close_fn)(void *host_context_handle);

    // load_assembly_and_get_function_pointer
    typedef int (*load_assembly_and_get_function_pointer_fn)(
        const char *assembly_path, const char *type_name, const char *method_name,
        const char *delegate_type_name, void *reserved, void **delegate);
}
// hostfxr_delegate_type::hdt_load_assembly_and_get_function_pointer
static const int HDT_LOAD_ASSEMBLY_AND_GET_FUNCTION_POINTER = 5;
// Sentinel meaning "the target managed method is [UnmanagedCallersOnly]".
#define UNMANAGEDCALLERSONLY_METHOD ((const char *)-1)

namespace dotnet_host
{
    static void *s_hostfxr = nullptr;
    static hostfxr_close_fn s_close = nullptr;
    static void *s_ctx = nullptr;
    static load_assembly_and_get_function_pointer_fn s_load_asm = nullptr;
    static bool s_available = false;
    static std::mutex s_mutex;

    // Managed entry points ([UnmanagedCallersOnly]).
    typedef void (*ManagedVoid)();
    typedef void (*ManagedBootstrap)(const char *libmodloader_path);
    static ManagedBootstrap s_mBootstrap = nullptr;
    static ManagedVoid s_mTick = nullptr;
    static ManagedVoid s_mShutdown = nullptr;
    static ManagedVoid s_mLevelLoaded = nullptr;
    static int s_mod_count = 0;

    // This library's own on-disk path (for the managed DllImport resolver).
    static std::string self_so_path()
    {
        Dl_info info;
        if (dladdr(reinterpret_cast<void *>(&self_so_path), &info) && info.dli_fname)
            return info.dli_fname;
        return "libmodloader.so";
    }

    // ── path helpers ─────────────────────────────────────────────────────────
    static std::string package_name()
    {
        char buf[256] = {0};
        FILE *f = fopen("/proc/self/cmdline", "r");
        if (f) { size_t n = fread(buf, 1, sizeof(buf) - 1, f); (void)n; fclose(f); }
        return buf[0] ? std::string(buf) : std::string("com.Armature.VR4");
    }
    // The app-readable data dir (paths::data_dir()) — the LSPosed mirror maps
    // the public /sdcard store here, so files dropped in the public store are
    // readable by the game at this scoped path. UEModLoader.dll, the runtime
    // PACK, and mods_dotnet live under this; the runtime's native libs get
    // staged from here into the internal exec dir (below) at boot.
    static std::string public_base() { return paths::data_dir() + "/dotnet"; }
    // INTERNAL app storage — the ONLY exec-allowed writable dir (Android mounts
    // /sdcard noexec, so a native .so cannot be dlopen'd from there). The host
    // stages the runtime's native libs here at boot; the user never touches it.
    static std::string runtime_root() { return "/data/data/" + package_name() + "/dotnet"; }
    static bool exists(const std::string &p) { struct stat st; return stat(p.c_str(), &st) == 0; }

    // Recursively copy `src` dir → `dst` (used to stage the runtime from the
    // public sdcard pack into the exec-allowed internal dir, once).
    static void copy_tree(const std::string &src, const std::string &dst)
    {
        mkdir(dst.c_str(), 0755);
        DIR *d = opendir(src.c_str());
        if (!d) return;
        struct dirent *e;
        while ((e = readdir(d)) != nullptr)
        {
            if (e->d_name[0] == '.' && (e->d_name[1] == 0 || (e->d_name[1] == '.' && e->d_name[2] == 0)))
                continue;
            std::string s = src + "/" + e->d_name, t = dst + "/" + e->d_name;
            struct stat st;
            if (stat(s.c_str(), &st) != 0) continue;
            if (S_ISDIR(st.st_mode)) { copy_tree(s, t); continue; }
            // Skip if already present with same size.
            struct stat dt;
            if (stat(t.c_str(), &dt) == 0 && dt.st_size == st.st_size) continue;
            FILE *in = fopen(s.c_str(), "rb"), *out = fopen(t.c_str(), "wb");
            if (in && out) { char b[1 << 16]; size_t n; while ((n = fread(b, 1, sizeof(b), in)) > 0) fwrite(b, 1, n, out); }
            if (in) fclose(in);
            if (out) { fclose(out); chmod(t.c_str(), 0755); }
        }
        closedir(d);
    }

    // Find <root>/host/fxr/<ver>/libhostfxr.so (first version dir).
    static std::string find_hostfxr(const std::string &root)
    {
        std::string fxr = root + "/host/fxr";
        DIR *d = opendir(fxr.c_str());
        if (!d) return "";
        std::string found;
        struct dirent *e;
        while ((e = readdir(d)) != nullptr)
        {
            if (e->d_name[0] == '.') continue;
            std::string cand = fxr + "/" + e->d_name + "/libhostfxr.so";
            if (exists(cand)) { found = cand; break; }
        }
        closedir(d);
        return found;
    }

    // Detect the installed Microsoft.NETCore.App version dir for runtimeconfig.
    static std::string netcore_version(const std::string &root)
    {
        std::string shared = root + "/shared/Microsoft.NETCore.App";
        DIR *d = opendir(shared.c_str());
        if (!d) return "";
        std::string ver;
        struct dirent *e;
        while ((e = readdir(d)) != nullptr)
        {
            if (e->d_name[0] == '.') continue;
            ver = e->d_name; // first (typically only) version
            break;
        }
        closedir(d);
        return ver;
    }

    // Write the runtimeconfig.json UEModLoader.dll needs (framework ref).
    static bool write_runtimeconfig(const std::string &path, const std::string &ver)
    {
        FILE *f = fopen(path.c_str(), "w");
        if (!f) return false;
        fprintf(f,
                "{\n"
                "  \"runtimeOptions\": {\n"
                "    \"tfm\": \"net8.0\",\n"
                "    \"framework\": { \"name\": \"Microsoft.NETCore.App\", \"version\": \"%s\" },\n"
                "    \"configProperties\": {\n"
                "      \"System.Runtime.TieredCompilation\": true,\n"
                "      \"System.Globalization.Invariant\": true,\n"
                // NON-concurrent GC. Concurrent/background GC spins up a dedicated
                // GC thread that must SUSPEND the game thread (a foreign thread
                // CoreCLR does not own) via a semaphore to scan its stack — and on
                // this embed the game thread ends up blocked in that sem_wait
                // FOREVER (the recurring "OVRA Update #0 stuck in libcoreclr" GC
                // deadlock). Blocking workstation GC instead runs the whole
                // collection synchronously on whatever thread triggered it — no
                // background GC thread, no foreign-thread suspension handshake, no
                // deadlock. Our managed allocations are tiny/throttled so the
                // stop-the-world gen0 pauses are sub-millisecond.
                "      \"System.GC.Concurrent\": false,\n"
                "      \"System.GC.Server\": false,\n"
                "      \"System.GC.RetainVM\": false\n"
                "    }\n"
                "  }\n"
                "}\n",
                ver.c_str());
        fclose(f);
        return true;
    }

    template <typename T>
    static T sym(void *lib, const char *name) { return reinterpret_cast<T>(dlsym(lib, name)); }

    // Resolve one managed [UnmanagedCallersOnly] entry point.
    static void *get_managed(const std::string &asm_path, const char *method)
    {
        void *fn = nullptr;
        int rc = s_load_asm(asm_path.c_str(),
                            "UEModLoader.CoreCLRHost, UEModLoader",
                            method, UNMANAGEDCALLERSONLY_METHOD, nullptr, &fn);
        if (rc != 0 || !fn)
        {
            logger::log_error("DOTNET", "load %s failed (rc=0x%x)", method, rc);
            return nullptr;
        }
        return fn;
    }

    bool init()
    {
        std::lock_guard<std::mutex> lk(s_mutex);
        if (s_available) return true;
        if (!config::dotnet_enabled())
        {
            logger::log_info("DOTNET", "C# mods disabled in config");
            return false;
        }

        // Native runtime libs must be exec (rules out /sdcard, incl. the scoped
        // mirror). So we stage the runtime pack from the app-readable scoped dir
        // (public_base()/runtime) into the internal exec dir (runtime_root),
        // once. The app can read the scoped mirror and write its own internal
        // dir, so this copy works (unlike reading the raw public store).
        std::string root = runtime_root();
        std::string hostfxr_path = find_hostfxr(root);
        if (hostfxr_path.empty())
        {
            std::string pack = public_base() + "/runtime";
            if (exists(pack))
            {
                logger::log_info("DOTNET", "staging .NET runtime %s -> %s (exec dir)",
                                 pack.c_str(), root.c_str());
                copy_tree(pack, root);
                hostfxr_path = find_hostfxr(root);
            }
        }
        if (hostfxr_path.empty())
        {
            logger::log_info("DOTNET",
                             "no .NET runtime — C# mods disabled (deploy a .NET 8 runtime pack to "
                             "%s/runtime)", public_base().c_str());
            return false;
        }

        // hostfxr resolves the shared framework relative to DOTNET_ROOT.
        setenv("DOTNET_ROOT", root.c_str(), 1);

        // NOTE: this "libcoreclr.so" is actually MonoVM (the Android .NET 8
        // runtime pack ships Mono under that name — the frozen game thread
        // symbolicates to pure mono_*/SGen frames, GC thread named "SGen
        // worker"), so every CoreCLR GC knob (System.GC.*, DOTNET_GCgen0size)
        // is silently ignored. The GC-freeze fix is NOT an env var here — it is
        // detaching the deferred-init thread from Mono after Bootstrap (below),
        // so the GC stop-the-world only has to suspend the game thread. Default
        // (hybrid) suspend is correct once that's the only attached app thread;
        // forcing coop is wrong (it would hang the game thread on its own
        // un-wrapped native blocking calls).

        s_hostfxr = dlopen(hostfxr_path.c_str(), RTLD_NOW | RTLD_GLOBAL);
        if (!s_hostfxr)
        {
            logger::log_error("DOTNET", "dlopen(libhostfxr) failed: %s", dlerror());
            return false;
        }
        auto init_fn = sym<hostfxr_initialize_for_runtime_config_fn>(s_hostfxr, "hostfxr_initialize_for_runtime_config");
        auto get_del = sym<hostfxr_get_runtime_delegate_fn>(s_hostfxr, "hostfxr_get_runtime_delegate");
        s_close = sym<hostfxr_close_fn>(s_hostfxr, "hostfxr_close");
        if (!init_fn || !get_del || !s_close)
        {
            logger::log_error("DOTNET", "libhostfxr missing required exports");
            return false;
        }

        // UEModLoader.dll lives in the app-readable scoped dir (managed assembly,
        // read as data — noexec is fine). runtimeconfig is written to the exec
        // dir next to the framework.
        std::string dotnet_dir = public_base();
        std::string cfg = root + "/UEModLoader.runtimeconfig.json";
        std::string ver = netcore_version(root);
        if (ver.empty()) ver = "8.0.6";
        if (!write_runtimeconfig(cfg, ver))
        {
            logger::log_error("DOTNET", "cannot write %s", cfg.c_str());
            return false;
        }

        void *handle = nullptr;
        int rc = init_fn(cfg.c_str(), nullptr, &handle);
        // 0 = Success, 1 = Success_HostAlreadyInitialized, 2 = Success_DifferentRuntimeProperties
        if ((rc != 0 && rc != 1 && rc != 2) || !handle)
        {
            logger::log_error("DOTNET", "hostfxr_initialize failed (rc=0x%x)", rc);
            return false;
        }
        s_ctx = handle;

        void *load_del = nullptr;
        rc = get_del(handle, HDT_LOAD_ASSEMBLY_AND_GET_FUNCTION_POINTER, &load_del);
        if (rc != 0 || !load_del)
        {
            logger::log_error("DOTNET", "get_runtime_delegate failed (rc=0x%x)", rc);
            return false;
        }
        s_load_asm = reinterpret_cast<load_assembly_and_get_function_pointer_fn>(load_del);

        std::string api = dotnet_dir + "/UEModLoader.dll";
        if (!exists(api))
        {
            logger::log_warn("DOTNET", "%s missing — build it (dotnet build the "
                                       "UEModLoader.Api project + generated proxies). C# disabled.",
                             api.c_str());
            return false;
        }

        s_mBootstrap = reinterpret_cast<ManagedBootstrap>(get_managed(api, "Bootstrap"));
        s_mTick = reinterpret_cast<ManagedVoid>(get_managed(api, "Tick"));
        s_mShutdown = reinterpret_cast<ManagedVoid>(get_managed(api, "Shutdown"));
        s_mLevelLoaded = reinterpret_cast<ManagedVoid>(get_managed(api, "LevelLoaded"));
        if (!s_mBootstrap)
            return false;

        logger::log_info("DOTNET", "CoreCLR %s hosted — calling managed Bootstrap", ver.c_str());
        std::string self = self_so_path();
        s_mBootstrap(self.c_str()); // registers DllImport resolver, scans mods, inits
        s_available = true;
        logger::log_info("DOTNET", "C# runtime ready (%d mod(s))", s_mod_count);

        // ── Detach THIS (deferred-init) thread from Mono — THE freeze fix ─────
        // Bootstrap just ran every mod's OnInitializeMelon ON THIS THREAD, which
        // ATTACHED it to the Mono runtime (the Android .NET 8 pack is MonoVM, not
        // CoreCLR). But this thread does NOT drive the managed tick — that's the
        // game thread. After we return, this thread sits FOREVER in the native
        // watchdog nanosleep loop (init.cpp deferred_init_thread). A Mono-attached
        // thread parked in an un-wrapped native syscall is precisely what hangs
        // the GC stop-the-world: when the game thread triggers a collection Mono
        // must suspend EVERY attached thread, and this one never reaches a
        // safepoint / never acks the (masked) suspend signal → the game thread
        // waits in sem_wait forever (the recurring "OVRA Update #0 stuck in
        // libcoreclr" freeze). Detaching removes it from the GC's thread set, so
        // STW only has to handle the game thread, which cooperates via
        // reverse-pinvoke. Resolved dynamically from the (already-loaded) runtime.
        {
            void *clr = dlopen("libcoreclr.so", RTLD_NOLOAD | RTLD_NOW);
            auto find_sym = [&](const char *n) -> void *
            {
                void *p = dlsym(RTLD_DEFAULT, n);
                if (!p && clr) p = dlsym(clr, n);
                return p;
            };
            typedef void *(*mono_cur_fn)();
            typedef void (*mono_det_fn)(void *);
            auto cur = reinterpret_cast<mono_cur_fn>(find_sym("mono_thread_current"));
            auto det = reinterpret_cast<mono_det_fn>(find_sym("mono_thread_detach"));
            if (cur && det)
            {
                void *t = cur();
                if (t) det(t);
                logger::log_info("DOTNET", "deferred-init thread detached from Mono — GC stop-the-world safe");
            }
            else
            {
                logger::log_warn("DOTNET", "mono detach syms not found (cur=%p det=%p) — init thread stays attached",
                                 (void *)cur, (void *)det);
            }
        }
        return true;
    }

    bool available() { return s_available; }
    int mod_count() { return s_mod_count; }

    void tick()
    {
        if (!s_available || !s_mTick) return;
        // Drive managed OnUpdate at most ~once per frame. ProcessEvent fires
        // thousands of times per second; calling into CoreCLR that often
        // deadlocks the game thread against the runtime's GC thread-suspend.
        // A time throttle keeps it to frame rate (~120fps cap) and cheap.
        static struct timespec s_last = {0, 0};
        struct timespec now;
        clock_gettime(CLOCK_MONOTONIC, &now);
        long dt_ms = (now.tv_sec - s_last.tv_sec) * 1000 + (now.tv_nsec - s_last.tv_nsec) / 1000000;
        if (s_last.tv_sec != 0 && dt_ms < 8)
            return;
        s_last = now;
        s_mTick();
    }
    void on_level_loaded()
    {
        if (s_available && s_mLevelLoaded) s_mLevelLoaded();
    }
    std::string status()
    {
        if (!s_available) return "C# runtime: unavailable (no .NET runtime pack / disabled)";
        return "C# runtime: ready (.NET CoreCLR), " + std::to_string(s_mod_count) + " mod(s)";
    }
    void shutdown()
    {
        std::lock_guard<std::mutex> lk(s_mutex);
        if (!s_available) return;
        if (s_mShutdown) s_mShutdown();
        s_available = false;
        logger::log_info("DOTNET", "C# runtime shut down");
    }

} // namespace dotnet_host

// ═══════════════════════════════════════════════════════════════════════════
// NATIVE BRIDGE — exported C functions the managed side P/Invokes (DllImport
// "libmodloader.so"). Signatures are P/Invoke-friendly: const char* in,
// malloc'd char* out (managed frees LPUTF8Str returns with free()), IntPtr +
// length for buffers. These wrap the existing modloader subsystems.
// ═══════════════════════════════════════════════════════════════════════════
#define UEML_EXPORT extern "C" __attribute__((visibility("default")))

namespace
{
    // strdup for LPUTF8Str returns (managed marshaller frees with free()).
    static char *ret_str(const std::string &s)
    {
        char *p = (char *)malloc(s.size() + 1);
        if (p) memcpy(p, s.c_str(), s.size() + 1);
        return p;
    }
    static int s_mem_fd_rw = -1;
    static int mem_fd()
    {
        if (s_mem_fd_rw < 0) s_mem_fd_rw = open("/proc/self/mem", O_RDWR);
        return s_mem_fd_rw;
    }
    static bool find_prop(void *obj, const char *name, reflection::PropertyInfo &out)
    {
        if (!obj || !name) return false;
        ue::UClass *c = ue::uobj_get_class(static_cast<ue::UObject *>(obj));
        if (!c) return false;
        auto props = reflection::walk_properties(reinterpret_cast<ue::UStruct *>(c), true);
        for (auto &p : props) if (p.name == name) { out = p; return true; }
        return false;
    }
    static uint8_t *field_addr(void *obj, const reflection::PropertyInfo &p)
    {
        return static_cast<uint8_t *>(obj) + p.offset;
    }
    static std::string read_fstring_at(void *addr)
    {
        if (!addr) return "";
        uint8_t *a = static_cast<uint8_t *>(addr);
        uint16_t *data = *reinterpret_cast<uint16_t **>(a);
        int32_t num = *reinterpret_cast<int32_t *>(a + 8);
        if (!data || num <= 0) return "";
        std::string out; out.reserve(num);
        for (int i = 0; i < num && data[i]; i++)
        {
            uint16_t c = data[i];
            if (c < 0x80) out += (char)c;
            else if (c < 0x800) { out += (char)(0xC0 | (c >> 6)); out += (char)(0x80 | (c & 0x3F)); }
            else { out += (char)(0xE0 | (c >> 12)); out += (char)(0x80 | ((c >> 6) & 0x3F)); out += (char)(0x80 | (c & 0x3F)); }
        }
        return out;
    }
}

// ── Logging + paths ─────────────────────────────────────────────────────────
UEML_EXPORT void ueml_log(int level, const char *tag, const char *msg)
{
    const char *t = tag ? tag : "C#";
    const char *m = msg ? msg : "";
    switch (level)
    {
    case 0: logger::log_debug(t, "%s", m); break;
    case 2: logger::log_warn(t, "%s", m); break;
    case 3: logger::log_error(t, "%s", m); break;
    default: logger::log_info(t, "%s", m); break;
    }
}
// App-readable scoped paths (mirror of the public store).
UEML_EXPORT char *ueml_data_dir() { return ret_str(paths::data_dir()); }
UEML_EXPORT char *ueml_mods_dir() { return ret_str(paths::data_dir() + "/mods_dotnet"); }
UEML_EXPORT char *ueml_userlibs_dir() { return ret_str(paths::data_dir() + "/dotnet/userlibs"); }

// ── Object discovery / introspection ────────────────────────────────────────
UEML_EXPORT void *ueml_find_object(const char *name) { return reflection::find_object_by_name(name ? name : ""); }
UEML_EXPORT void *ueml_find_first_of(const char *cls) { return reflection::find_first_instance(cls ? cls : ""); }
UEML_EXPORT void *ueml_find_class(const char *cls) { return reflection::find_class_ptr(cls ? cls : ""); }

// FindAllOf: caller passes a buffer; returns count written (and total if bigger).
UEML_EXPORT int ueml_find_all_of(const char *cls, void **out, int cap)
{
    auto v = reflection::find_all_instances(cls ? cls : "");
    int n = (int)v.size();
    for (int i = 0; i < n && i < cap; i++) out[i] = v[i];
    return n;
}
UEML_EXPORT char *ueml_object_name(void *obj)
{
    return ret_str(obj ? reflection::get_short_name(static_cast<ue::UObject *>(obj)) : "None");
}
UEML_EXPORT char *ueml_class_name(void *obj)
{
    if (!obj) return ret_str("None");
    ue::UClass *c = ue::uobj_get_class(static_cast<ue::UObject *>(obj));
    return ret_str(c ? reflection::get_short_name(reinterpret_cast<ue::UObject *>(c)) : "None");
}
UEML_EXPORT int ueml_is_a(void *obj, const char *cls)
{
    if (!obj || !cls) return 0;
    ue::UClass *c = ue::uobj_get_class(static_cast<ue::UObject *>(obj));
    std::string want = cls;
    while (c)
    {
        if (reflection::get_short_name(reinterpret_cast<ue::UObject *>(c)) == want) return 1;
        reflection::ClassInfo *ci = reflection::find_class(reflection::get_short_name(reinterpret_cast<ue::UObject *>(c)));
        if (!ci || ci->parent_name.empty()) break;
        c = reflection::find_class_ptr(ci->parent_name);
    }
    return 0;
}
UEML_EXPORT int ueml_prop_offset(void *obj, const char *prop)
{ reflection::PropertyInfo p; return find_prop(obj, prop, p) ? p.offset : -1; }
UEML_EXPORT int ueml_prop_size(void *obj, const char *prop)
{ reflection::PropertyInfo p; return find_prop(obj, prop, p) ? p.element_size : -1; }
UEML_EXPORT int ueml_prop_type(void *obj, const char *prop)
{ reflection::PropertyInfo p; return find_prop(obj, prop, p) ? (int)p.type : 0; }

// Typed property get/set by name (host owns offset + bitfield mask).
UEML_EXPORT int ueml_get_bool(void *obj, const char *prop)
{
    reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return 0;
    uint8_t *b = field_addr(obj, p) + p.bool_byte_offset;
    uint8_t mask = p.bool_field_mask ? p.bool_field_mask : 0xFF;
    return (*b & mask) ? 1 : 0;
}
UEML_EXPORT void ueml_set_bool(void *obj, const char *prop, int value)
{
    reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return;
    uint8_t *b = field_addr(obj, p) + p.bool_byte_offset;
    uint8_t mask = p.bool_field_mask ? p.bool_field_mask : 0xFF;
    *b = value ? (*b | mask) : (*b & ~mask);
}
UEML_EXPORT long long ueml_get_int(void *obj, const char *prop)
{
    reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return 0;
    uint8_t *a = field_addr(obj, p);
    switch (p.element_size) { case 1: return *(int8_t *)a; case 2: return *(int16_t *)a;
        case 4: return *(int32_t *)a; case 8: return *(int64_t *)a; default: return 0; }
}
UEML_EXPORT void ueml_set_int(void *obj, const char *prop, long long v)
{
    reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return;
    uint8_t *a = field_addr(obj, p);
    switch (p.element_size) { case 1: *(int8_t *)a = (int8_t)v; break; case 2: *(int16_t *)a = (int16_t)v; break;
        case 4: *(int32_t *)a = (int32_t)v; break; case 8: *(int64_t *)a = v; break; }
}
UEML_EXPORT double ueml_get_float(void *obj, const char *prop)
{
    reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return 0.0;
    uint8_t *a = field_addr(obj, p);
    return p.element_size == 8 ? *(double *)a : *(float *)a;
}
UEML_EXPORT void ueml_set_float(void *obj, const char *prop, double v)
{
    reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return;
    uint8_t *a = field_addr(obj, p);
    if (p.element_size == 8) *(double *)a = v; else *(float *)a = (float)v;
}
UEML_EXPORT void *ueml_get_object(void *obj, const char *prop)
{ reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return nullptr; return *(void **)field_addr(obj, p); }
UEML_EXPORT void ueml_set_object(void *obj, const char *prop, void *value)
{ reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return; *(void **)field_addr(obj, p) = value; }
UEML_EXPORT char *ueml_get_string(void *obj, const char *prop)
{ reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return ret_str(""); return ret_str(read_fstring_at(field_addr(obj, p))); }
UEML_EXPORT char *ueml_get_name(void *obj, const char *prop)
{
    reflection::PropertyInfo p; if (!find_prop(obj, prop, p)) return ret_str("None");
    int32_t idx = *(int32_t *)field_addr(obj, p);
    return ret_str(reflection::fname_to_string(idx));
}
UEML_EXPORT char *ueml_read_fstring_at(void *addr) { return ret_str(read_fstring_at(addr)); }
UEML_EXPORT char *ueml_fname_to_string(int idx) { return ret_str(reflection::fname_to_string(idx)); }

// UFunction resolve + ProcessEvent.
UEML_EXPORT void *ueml_resolve_function(void *obj, const char *func)
{
    if (!obj || !func) return nullptr;
    ue::UClass *c = ue::uobj_get_class(static_cast<ue::UObject *>(obj));
    if (!c) return nullptr;
    auto fns = reflection::walk_functions(reinterpret_cast<ue::UStruct *>(c), true);
    for (auto &f : fns) if (f.name == func) return f.raw;
    return nullptr;
}
UEML_EXPORT void *ueml_find_function(const char *path) { return pe_hook::resolve_func_path(path ? path : ""); }
UEML_EXPORT void ueml_process_event(void *obj, void *func, void *params)
{
    if (!obj || !func) return;
    ue::ProcessEventFn pe = pe_hook::get_original();
    if (!pe) pe = symbols::ProcessEvent;
    if (pe) pe(static_cast<ue::UObject *>(obj), static_cast<ue::UFunction *>(func), params);
}

// Raw memory.
UEML_EXPORT int ueml_mem_read(void *addr, void *dst, int len)
{ if (!addr || !dst || len <= 0) return 0; return pread64(mem_fd(), dst, len, (off64_t)(uintptr_t)addr) == len ? 1 : 0; }
UEML_EXPORT int ueml_mem_write(void *addr, void *src, int len)
{ if (!addr || !src || len <= 0) return 0; return pwrite64(mem_fd(), src, len, (off64_t)(uintptr_t)addr) == len ? 1 : 0; }
UEML_EXPORT void *ueml_alloc(int size) { return size > 0 ? malloc(size) : nullptr; }
UEML_EXPORT void ueml_free(void *p) { if (p) free(p); }
UEML_EXPORT void *ueml_module_base(const char *) { return (void *)symbols::get_lib_base(); }
UEML_EXPORT void *ueml_resolve_symbol(const char *s) { return s ? symbols::resolve(s) : nullptr; }

// Static patching.
UEML_EXPORT int ueml_patch_bytes(void *addr, void *bytes, int len, const char *owner)
{ if (!addr || !bytes || len <= 0) return 0; return codepatch::write_code(addr, bytes, (size_t)len, owner ? owner : "") ? 1 : 0; }
UEML_EXPORT int ueml_patch_nop(void *addr, int count, const char *owner)
{ return codepatch::nop_code(addr, count, owner ? owner : "") ? 1 : 0; }
UEML_EXPORT char *ueml_patch_asm(void *addr, const char *text, const char *owner)
{ std::string err; bool ok = codepatch::assemble_at(addr, text ? text : "", owner ? owner : "", err); return ret_str(ok ? std::string() : err); }
UEML_EXPORT int ueml_assemble(const char *text, void *pc, void *out, int cap, char **err_out)
{
    std::vector<uint8_t> bytes; std::string err;
    bool ok = arm64::assemble_bytes(text ? text : "", (uintptr_t)pc, bytes, err);
    if (err_out) *err_out = ret_str(ok ? std::string() : err);
    if (!ok) return 0;
    int n = (int)bytes.size();
    if (out && n <= cap) memcpy(out, bytes.data(), n);
    return n;
}
UEML_EXPORT int ueml_patch_branch(void *addr, void *target, const char *owner)
{ uint32_t w = 0; if (!arm64::b((uintptr_t)addr, (uintptr_t)target, w)) return 0; return codepatch::write_code(addr, &w, 4, owner ? owner : "") ? 1 : 0; }
UEML_EXPORT int ueml_restore_patch(void *addr) { return codepatch::restore_addr(addr) ? 1 : 0; }

// Blueprint / Kismet bytecode (UStruct::Script TArray<uint8> @ SCRIPT_OFF).
// get: returns a malloc'd copy of the current bytecode (caller frees via ueml_free),
// *out_len = byte count. set: overwrites in place when it fits the existing
// allocation (safe, reversible), else points Script at a fresh buffer.
UEML_EXPORT void *ueml_get_script(void *ufunc, int *out_len)
{
    if (out_len) *out_len = 0;
    if (!ufunc) return nullptr;
    uint8_t *base = static_cast<uint8_t *>(ufunc) + ue::ustruct::SCRIPT_OFF();
    void *data = *reinterpret_cast<void **>(base + 0);
    int32_t num = *reinterpret_cast<int32_t *>(base + 8);
    if (!data || num <= 0 || num > (1 << 24)) return nullptr; // sanity-bound
    void *copy = malloc((size_t)num);
    if (!copy) return nullptr;
    memcpy(copy, data, (size_t)num);
    if (out_len) *out_len = num;
    return copy;
}
UEML_EXPORT int ueml_set_script(void *ufunc, const void *data, int len)
{
    if (!ufunc || !data || len < 0) return 0;
    uint8_t *base = static_cast<uint8_t *>(ufunc) + ue::ustruct::SCRIPT_OFF();
    void **pdata = reinterpret_cast<void **>(base + 0);
    int32_t *pnum = reinterpret_cast<int32_t *>(base + 8);
    int32_t *pmax = reinterpret_cast<int32_t *>(base + 12);
    if (*pdata && len <= *pmax)
    {
        // Fits the existing UE heap allocation → overwrite in place (Num shrinks/grows
        // within Max). This is what Neuter and equal/shorter splices use.
        memcpy(*pdata, data, (size_t)len);
        *pnum = len;
        return 1;
    }
    // Larger than the current buffer → hand Script a fresh buffer (old one leaks; a
    // persistent BP patch never frees, and shipping never destructs these UFunctions).
    void *buf = malloc((size_t)len);
    if (!buf) return 0;
    memcpy(buf, data, (size_t)len);
    *pdata = buf;
    *pnum = len;
    *pmax = len;
    return 1;
}

UEML_EXPORT void *ueml_get_native_func(void *ufunc) { return ufunc ? ue::ufunc_get_func_ptr(static_cast<ue::UFunction *>(ufunc)) : nullptr; }
UEML_EXPORT int ueml_set_native_func(void *ufunc, void *fn)
{ if (!ufunc) return 0; *(void **)((uint8_t *)ufunc + ue::ufunc::FUNC_PTR_OFF()) = fn; return 1; }
UEML_EXPORT unsigned ueml_get_func_flags(void *ufunc) { return ufunc ? ue::ufunc_get_flags(static_cast<ue::UFunction *>(ufunc)) : 0; }
UEML_EXPORT int ueml_set_func_flags(void *ufunc, unsigned flags)
{ if (!ufunc) return 0; *(uint32_t *)((uint8_t *)ufunc + ue::ufunc::FUNCTION_FLAGS_OFF()) = flags; return 1; }

// Native hooks (managed callback fnptr: void cb(void* ctx)).
UEML_EXPORT unsigned long long ueml_hook_native(const char *symOrPath, void *addr, void *preCb, void *postCb, const char *owner)
{
    typedef void (*RawCb)(void *);
    RawCb pre = (RawCb)preCb, post = (RawCb)postCb;
    std::string sym = symOrPath ? symOrPath : "", own = owner ? owner : "";
    native_hooks::NativePreCallback pcb = pre ? [pre](native_hooks::NativeCallContext &c) { pre(&c); } : native_hooks::NativePreCallback(nullptr);
    native_hooks::NativePostCallback qcb = post ? [post](native_hooks::NativeCallContext &c) { post(&c); } : native_hooks::NativePostCallback(nullptr);
    std::string key = own.empty() ? sym : (own + ":" + sym);
    if (addr) return native_hooks::install_at(addr, sym.empty() ? std::string("cs_hook") : sym, pcb, qcb, key);
    void *a = symbols::resolve(sym.c_str());
    if (!a) { logger::log_warn("DOTNET", "hook: cannot resolve '%s'", sym.c_str()); return 0; }
    return native_hooks::install_at(a, sym, pcb, qcb, key);
}
UEML_EXPORT void ueml_unhook(unsigned long long id) { native_hooks::remove((native_hooks::HookId)id); }

// UFunction (ProcessEvent) hooks — the C# analog of Lua's RegisterHook. Unlike
// ueml_hook_native (which hooks a resolved NATIVE symbol address), this routes
// through the ProcessEvent dispatcher so a Blueprint "Class:Function" path gets
// a flat params buffer and a real BLOCK. Callback ABI:
//   pre:  int  cb(void* self, void* parms)   // return nonzero = BLOCK original
//   post: void cb(void* self, void* parms)
UEML_EXPORT unsigned long long ueml_pe_hook_pre(const char *path, void *preCb, const char *)
{
    typedef int (*PreRaw)(void *, void *);
    PreRaw pre = (PreRaw)preCb;
    if (!pre || !path) return 0;
    return pe_hook::register_pre(path, [pre](ue::UObject *self, ue::UFunction *, void *parms) -> bool {
        return pre((void *)self, parms) != 0;
    });
}
UEML_EXPORT unsigned long long ueml_pe_hook_post(const char *path, void *postCb, const char *)
{
    typedef void (*PostRaw)(void *, void *);
    PostRaw post = (PostRaw)postCb;
    if (!post || !path) return 0;
    return pe_hook::register_post(path, [post](ue::UObject *self, ue::UFunction *, void *parms) {
        post((void *)self, parms);
    });
}
UEML_EXPORT void ueml_pe_unhook(unsigned long long id) { pe_hook::unregister((pe_hook::HookId)id); }
UEML_EXPORT unsigned long long ueml_ctx_get_x(void *ctx, int i)
{ auto *c = (native_hooks::NativeCallContext *)ctx; return (c && i >= 0 && i < 8) ? c->x[i] : 0; }
UEML_EXPORT void ueml_ctx_set_x(void *ctx, int i, unsigned long long v)
{ auto *c = (native_hooks::NativeCallContext *)ctx; if (c && i >= 0 && i < 8) c->x[i] = v; }
UEML_EXPORT double ueml_ctx_get_d(void *ctx, int i)
{ auto *c = (native_hooks::NativeCallContext *)ctx; return (c && i >= 0 && i < 8) ? c->d[i] : 0.0; }
UEML_EXPORT void ueml_ctx_set_d(void *ctx, int i, double v)
{ auto *c = (native_hooks::NativeCallContext *)ctx; if (c && i >= 0 && i < 8) c->d[i] = v; }
UEML_EXPORT void ueml_ctx_block(void *ctx) { auto *c = (native_hooks::NativeCallContext *)ctx; if (c) c->blocked = true; }
UEML_EXPORT void ueml_ctx_set_ret_x(void *ctx, unsigned long long v)
{ auto *c = (native_hooks::NativeCallContext *)ctx; if (c) { c->ret_x0 = v; c->ret_override = true; } }
UEML_EXPORT void ueml_ctx_set_ret_d(void *ctx, double v)
{ auto *c = (native_hooks::NativeCallContext *)ctx; if (c) { c->ret_d0 = v; c->ret_override = true; } }

// Lua interop + command bridge.
UEML_EXPORT char *ueml_lua_eval(const char *code)
{
    lua_engine::ExecResult r = lua_engine::exec_string(code ? code : "", "=cs", 0);
    return ret_str(r.success ? r.output : (std::string("error: ") + r.error));
}
// Generate the C# proxies directly (native, no Lua) — safe to call from a
// BACKGROUND thread (reads the cached reflection graph, writes .cs files). Lets
// the managed build command generate + compile off the game thread.
UEML_EXPORT char *ueml_generate_proxies(const char *out_dir)
{
    return ret_str(csharp_gen::generate(out_dir ? out_dir : ""));
}

// C# command handler: void cb(const char* args). Result reported via ueml_cmd_return.
namespace
{
    typedef void (*CmdCb)(const char *);
    thread_local std::string t_cmd_result;
    thread_local const std::function<std::string()> *t_call_original = nullptr;
}
UEML_EXPORT void ueml_cmd_return(const char *s) { t_cmd_result = s ? s : ""; }
UEML_EXPORT char *ueml_cmd_call_original() { return ret_str(t_call_original ? (*t_call_original)() : std::string()); }
UEML_EXPORT int ueml_register_command(const char *name, void *handler, const char *)
{
    if (!handler || !name) return 0;
    CmdCb cb = (CmdCb)handler; std::string n = name;
    adb_bridge::register_command(n, [cb](const std::string &args) -> std::string {
        t_cmd_result.clear(); cb(args.c_str()); return t_cmd_result; });
    return 1;
}
UEML_EXPORT int ueml_wrap_command(const char *name, void *handler, const char *)
{
    if (!handler || !name) return 0;
    CmdCb cb = (CmdCb)handler; std::string n = name;
    adb_bridge::register_command_wrapper(n, [cb](const std::string &args, const std::function<std::string()> &call_original) -> std::string {
        t_cmd_result.clear(); t_call_original = &call_original; cb(args.c_str()); t_call_original = nullptr; return t_cmd_result; });
    return 1;
}
UEML_EXPORT void ueml_unregister_command(const char *name)
{ if (name) { adb_bridge::unregister_command(name); adb_bridge::unregister_command_wrapper(name); } }

// Let the managed Bootstrap report how many mods it loaded.
namespace dotnet_host { void set_mod_count(int n); }
UEML_EXPORT void ueml_set_loaded_mod_count(int n) { dotnet_host::set_mod_count(n); }
namespace dotnet_host { void set_mod_count(int n) { s_mod_count = n; } }
