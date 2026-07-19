// UEModLoader.Api / ModRuntime.cs
// Host entry points. The native host (dotnet_host.cpp) instantiates each
// UnrealMod subclass, then calls these by name. Registration mirrors
// MelonLoader's MelonMod.RegisterInternal: resolve [MelonInfo], create the
// per-mod Harmony instance, PatchAll it, run OnEarly/On/OnLate init; per frame
// run OnUpdate/OnFixedUpdate/OnLateUpdate; on unload UnpatchAll + OnDeinit.

using System;
using System.Reflection;

namespace UEModLoader
{
    public static class ModRuntime
    {
        /// <summary>MelonMod-style registration: info + Harmony + PatchAll + init.</summary>
        public static void Bootstrap(UnrealMod mod)
        {
            if (mod == null) return;
            var type = mod.GetType();

            // Resolve [MelonInfo] from the class or the mod's assembly.
            var info = (MelonInfoAttribute)Attribute.GetCustomAttribute(type, typeof(MelonInfoAttribute))
                    ?? (MelonInfoAttribute)Attribute.GetCustomAttribute(type.Assembly, typeof(MelonInfoAttribute));
            mod.Name = info?.Name ?? type.Name;
            mod.Version = info?.Version ?? "1.0.0";
            mod.Author = info?.Author ?? "";
            mod.LoggerInstance = new ModLogger(mod.Name);
            mod.LoggerInstance.Msg($"v{mod.Version}{(string.IsNullOrEmpty(mod.Author) ? "" : " by " + mod.Author)} loaded");

            // Ambient patch owner = mod name, so every patch/hook reverts on unload.
            Patch.CurrentOwner = mod.Name;
            Hooks.CurrentOwner = mod.Name;
            Commands.CurrentOwner = mod.Name;

            // Per-mod Harmony instance (auto-unpatched on deinit).
            mod.HarmonyInstance = new Harmony(mod.Name);

            Safe(mod, () => mod.OnEarlyInitializeMelon(), "OnEarlyInitializeMelon");

            // PatchAll — [HarmonyPatch] classes in this mod's assembly.
            try { mod.HarmonyInstance.PatchAll(type.Assembly); }
            catch (Exception e) { Log.Error("Harmony", $"{mod.Name}: PatchAll: {e.Message}"); }

            // Also honour the simpler [Patch] method attribute (see Hooks.cs).
            WireSimplePatches(mod);
        }

        private static void WireSimplePatches(UnrealMod mod)
        {
            const BindingFlags F = BindingFlags.Static | BindingFlags.Instance |
                                   BindingFlags.Public | BindingFlags.NonPublic;
            foreach (var m in mod.GetType().GetMethods(F))
            {
                var attr = (PatchAttribute)Attribute.GetCustomAttribute(m, typeof(PatchAttribute));
                if (attr == null) continue;
                try
                {
                    HookCallback cb = m.IsStatic
                        ? (HookCallback)Delegate.CreateDelegate(typeof(HookCallback), m, false)
                        : (HookCallback)Delegate.CreateDelegate(typeof(HookCallback), mod, m, false);
                    if (cb == null) { Log.Warn("Patch", $"{m.Name}: signature must be (NativeContext)"); continue; }
                    bool post = m.Name.IndexOf("Postfix", StringComparison.OrdinalIgnoreCase) >= 0;
                    if (post) Hooks.Install(attr.Target, null, cb, mod.Name);
                    else Hooks.Install(attr.Target, cb, null, mod.Name);
                }
                catch (Exception e) { Log.Error("Patch", $"{m.Name}: {e.Message}"); }
            }
        }

        // Host-invoked lifecycle wrappers (exceptions logged, never thrown into native).
        public static void SafeInit(UnrealMod mod)
        {
            Safe(mod, () => mod.OnInitializeMelon(), "OnInitializeMelon");
        }
        public static void SafeLateInit(UnrealMod mod)
        {
            Safe(mod, () => mod.OnLateInitializeMelon(), "OnLateInitializeMelon");
            Safe(mod, () => mod.OnApplicationStart(), "OnApplicationStart");
        }
        public static void SafeUpdate(UnrealMod mod)
        {
            Safe(mod, () => mod.OnUpdate(), "OnUpdate");
            Safe(mod, () => mod.OnFixedUpdate(), "OnFixedUpdate");
        }
        public static void SafeLateUpdate(UnrealMod mod)
        {
            Safe(mod, () => mod.OnLateUpdate(), "OnLateUpdate");
        }
        public static void SafeLevelLoaded(UnrealMod mod, string level)
        {
            Safe(mod, () => mod.OnLevelLoaded(level), "OnLevelLoaded");
        }
        public static void SafeUnload(UnrealMod mod)
        {
            try { mod.HarmonyInstance?.UnpatchAll(); } catch { }
            Safe(mod, () => mod.OnApplicationQuit(), "OnApplicationQuit");
            Safe(mod, () => mod.OnDeinitializeMelon(), "OnDeinitializeMelon");
        }

        private static void Safe(UnrealMod mod, Action a, string what)
        {
            try { a(); }
            catch (Exception e) { Log.Error("Mod", $"{mod.Name ?? mod.GetType().Name}.{what}: {e}"); }
        }
    }
}
