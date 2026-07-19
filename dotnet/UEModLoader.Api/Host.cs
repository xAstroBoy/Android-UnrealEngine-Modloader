// UEModLoader.Api / Host.cs
// The CoreCLR entry points the native host (dotnet_host.cpp) calls via
// load_assembly_and_get_function_pointer. All are [UnmanagedCallersOnly] so the
// runtime exposes them as raw C function pointers. Bootstrap wires the P/Invoke
// resolver (mapping "libmodloader" to the already-loaded .so), discovers and
// initializes every UnrealMod, and the per-frame Tick drives them.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace UEModLoader
{
    public static class CoreCLRHost
    {
        private static readonly List<UnrealMod> s_mods = new List<UnrealMod>();
        private static string s_libPath = "libmodloader.so";
        private static bool s_ready;
        // True while an on-device compile runs — Tick skips so the game thread
        // isn't also churning managed code / adding GC pressure during the build.
        private static volatile bool s_compiling;
        // Mods load into THIS assembly's load context so their reference to
        // UEModLoader.dll (loaded by hostfxr into an isolated context) resolves.
        private static AssemblyLoadContext Alc =>
            AssemblyLoadContext.GetLoadContext(typeof(CoreCLRHost).Assembly) ?? AssemblyLoadContext.Default;

        [UnmanagedCallersOnly]
        public static void Bootstrap(IntPtr libPathUtf8)
        {
            try
            {
                s_libPath = Marshal.PtrToStringUTF8(libPathUtf8) ?? "libmodloader.so";

                // Resolve "libmodloader" P/Invokes to the already-loaded module.
                NativeLibrary.SetDllImportResolver(typeof(CoreCLRHost).Assembly, ResolveLib);

                // Resolve managed mod DEPENDENCIES (e.g. UEModLoader.Game.dll, the
                // typed proxy assembly) by probing the mod/userlib/dotnet dirs, so
                // a mod that references proxies loads regardless of scan order.
                Alc.Resolving += ResolveDependency;

                Log.Info("C#", $"CoreCLR bootstrap (host {s_libPath})");

                // Shared dependency libraries first (loaded, not scanned for mods).
                LoadDir(Native.UserlibsDir(), asMods: false);
                // Then user mods.
                LoadDir(Native.ModsDir(), asMods: true);

                // Late-init pass (MelonMod OnLateInitializeMelon + OnApplicationStart).
                foreach (var m in s_mods) ModRuntime.SafeLateInit(m);

                // Bridge command: the MODLOADER generates the proxies (native
                // generator) AND compiles them into UEModLoader.Game.dll on-device
                // via Roslyn — no PC build step. Run `build_csharp_dll` from the
                // bridge; the dll lands next to UEModLoader.dll for modders to pull.
                Commands.Register("build_csharp_dll", _ =>
                {
                    // Runs OFF the game thread (generation reads the cached
                    // reflection graph; Roslyn compile of 2645 classes takes
                    // seconds) so it neither freezes the game nor hits the 8s
                    // bridge timeout. Result is logged when done.
                    var t = new System.Threading.Thread(() =>
                    {
                        s_compiling = true;
                        try
                        {
                            string data = Native.DataDir();
                            string src = Path.Combine(data, "dotnet", "Generated");
                            string outDll = Path.Combine(data, "dotnet", "UEModLoader.Game.dll");
                            string shared = Path.GetDirectoryName(typeof(object).Assembly.Location);
                            Log.Info("C#", "build_csharp_dll: generating proxies...");
                            string gen = Native.GenerateProxies(src);
                            Log.Info("C#", "build_csharp_dll: " + gen + " — compiling (low priority)...");
                            string res = ProxyCompiler.Compile(src, shared, outDll);
                            Log.Info("C#", "build_csharp_dll DONE: " + res);
                        }
                        catch (Exception e) { Log.Error("C#", "build_csharp_dll: " + e); }
                        finally { s_compiling = false; }
                    });
                    // Lowest priority + background so the game thread always preempts
                    // it — the compile runs in spare CPU without freezing the game.
                    t.Priority = System.Threading.ThreadPriority.Lowest;
                    t.IsBackground = true;
                    t.Start();
                    return "started (generate + compile on a background thread) — watch UEModLoader.log "
                         + "for 'build_csharp_dll DONE', then pull dotnet/UEModLoader.Game.dll";
                });

                Native.SetLoadedModCount(s_mods.Count);
                s_ready = true;
                Log.Info("C#", $"C# runtime ready — {s_mods.Count} mod(s). Run bridge cmd "
                             + "'build_csharp_dll' to generate+compile UEModLoader.Game.dll on-device.");
            }
            catch (Exception e)
            {
                Log.Error("C#", "Bootstrap failed: " + e);
            }
        }

        private static IntPtr ResolveLib(string name, Assembly asm, DllImportSearchPath? path)
        {
            if (name == Native.LIB || name == "libmodloader" || name == "libmodloader.so")
            {
                if (NativeLibrary.TryLoad(s_libPath, out var h)) return h;      // exact path
                if (NativeLibrary.TryLoad("libmodloader.so", out h)) return h;  // by soname
            }
            return IntPtr.Zero;
        }

        // Resolve a managed mod dependency (e.g. UEModLoader.Game.dll) by probing the
        // userlib / mod / dotnet directories, so a mod that references the typed
        // proxies loads regardless of which dir the dependency was deployed to.
        private static Assembly ResolveDependency(AssemblyLoadContext ctx, AssemblyName name)
        {
            string file = name.Name + ".dll";
            foreach (var dir in new[] { Native.UserlibsDir(), Native.ModsDir(),
                                        Path.Combine(Native.DataDir(), "dotnet") })
            {
                try
                {
                    if (string.IsNullOrEmpty(dir)) continue;
                    string p = Path.Combine(dir, file);
                    if (File.Exists(p)) return ctx.LoadFromAssemblyPath(Path.GetFullPath(p));
                }
                catch { }
            }
            return null;
        }

        private static void LoadDir(string dir, bool asMods)
        {
            if (string.IsNullOrEmpty(dir) || !Directory.Exists(dir)) return;
            foreach (var file in Directory.GetFiles(dir, "*.dll"))
            {
                Assembly a;
                try { a = Alc.LoadFromAssemblyPath(Path.GetFullPath(file)); }
                catch (Exception e) { Log.Warn("C#", $"load {Path.GetFileName(file)}: {e.Message}"); continue; }
                if (!asMods) { Log.Info("C#", $"userlib {Path.GetFileName(file)}"); continue; }
                DiscoverMods(a, Path.GetFileName(file));
            }
        }

        private static void DiscoverMods(Assembly a, string label)
        {
            Type[] types;
            try { types = a.GetTypes(); }
            catch (ReflectionTypeLoadException e) { types = Array.FindAll(e.Types, t => t != null); }
            int found = 0;
            foreach (var t in types)
            {
                if (t == null || t.IsAbstract || !typeof(UnrealMod).IsAssignableFrom(t)) continue;
                UnrealMod mod;
                try { mod = (UnrealMod)Activator.CreateInstance(t); }
                catch (Exception e) { Log.Error("C#", $"{t.Name}: ctor {e.Message}"); continue; }
                ModRuntime.Bootstrap(mod);
                ModRuntime.SafeInit(mod);
                s_mods.Add(mod);
                found++;
                Log.Info("C#", $"loaded mod '{mod.Name}' ({label})");
            }
            if (found == 0) Log.Info("C#", $"{label}: no UnrealMod subclasses");
        }

        [UnmanagedCallersOnly]
        public static void Tick()
        {
            if (!s_ready || s_compiling) return;
            for (int i = 0; i < s_mods.Count; i++) ModRuntime.SafeUpdate(s_mods[i]);
            for (int i = 0; i < s_mods.Count; i++) ModRuntime.SafeLateUpdate(s_mods[i]);
        }

        [UnmanagedCallersOnly]
        public static void LevelLoaded()
        {
            if (!s_ready) return;
            foreach (var m in s_mods) ModRuntime.SafeLevelLoaded(m, "");
        }

        [UnmanagedCallersOnly]
        public static void Shutdown()
        {
            foreach (var m in s_mods) ModRuntime.SafeUnload(m);
            s_mods.Clear();
            s_ready = false;
        }
    }
}
