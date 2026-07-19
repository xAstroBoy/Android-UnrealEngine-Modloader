// UEModLoader.Api / Mod.cs
// UnrealMod mirrors MelonLoader's MelonMod (see LemonLoader/MelonLoader/Melons/
// MelonBase.cs + MelonMod.cs) so the workflow is identical for anyone who has
// written a Melon — same lifecycle names, a MelonInfo-style attribute, and a
// per-mod HarmonyInstance that PatchAll's on init and auto-unpatches on deinit.
//
// The difference from MelonLoader is the TARGET: MelonLoader patches managed
// Unity/Il2Cpp game code; there is none here — RE4 is native Unreal. So the
// Harmony surface patches NATIVE functions, UFunctions (ProcessEvent), and
// Kismet/ARM bytecode instead of managed IL. Everything else (lifecycle,
// discovery, auto-unpatch) matches.

using System;

namespace UEModLoader
{
    /// <summary>
    /// Base class for a C# mod — the UnrealMod analog of MelonLoader's MelonMod.
    /// Inherit it, override the lifecycle you need, drop the built DLL in
    /// <c>mods_dotnet/</c>. The host discovers every non-abstract subclass,
    /// instantiates it, PatchAll's its <see cref="HarmonyInstance"/>, and drives
    /// the events from the game thread.
    /// </summary>
    public abstract class UnrealMod
    {
        /// <summary>Per-mod Harmony instance (auto-PatchAll on init, auto-unpatch
        /// on deinit — same contract as MelonMod).</summary>
        public Harmony HarmonyInstance { get; internal set; }

        /// <summary>Info resolved from <see cref="MelonInfoAttribute"/> or defaults.</summary>
        public string Name { get; internal set; }
        public string Version { get; internal set; }
        public string Author { get; internal set; }

        /// <summary>Per-mod logger — lines are tagged with this mod's name so the
        /// origin is clear (timestamp is added by the native logger). Same as
        /// MelonLoader's LoggerInstance.</summary>
        public ModLogger LoggerInstance { get; internal set; }
        /// <summary>Alias for <see cref="LoggerInstance"/>.</summary>
        public ModLogger Logger => LoggerInstance;

        // Instance convenience — tagged with this mod's name.
        protected void LogMsg(string msg) => LoggerInstance?.Msg(msg);
        protected void LogDebug(string msg) => LoggerInstance?.Debug(msg);
        protected void LogWarning(string msg) => LoggerInstance?.Warning(msg);
        protected void LogError(string msg) => LoggerInstance?.Error(msg);

        // ── Initialization (MelonMod-named) ──────────────────────────────────
        /// <summary>Runs before Harmony PatchAll. Earliest hook point.</summary>
        public virtual void OnEarlyInitializeMelon() { }
        /// <summary>Main init — patch here. Reflection graph is available.</summary>
        public virtual void OnInitializeMelon() { }
        /// <summary>Runs after all mods have initialized.</summary>
        public virtual void OnLateInitializeMelon() { }
        /// <summary>Runs on unload/reload/quarantine. Harmony is auto-unpatched
        /// for you; free your own resources here.</summary>
        public virtual void OnDeinitializeMelon() { }

        // ── Per-frame (driven from the ProcessEvent game-thread drain) ───────
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnLateUpdate() { }
        public virtual void OnGUI() { }

        // ── App / level ──────────────────────────────────────────────────────
        public virtual void OnApplicationStart() { }
        public virtual void OnApplicationQuit() { }
        /// <summary>Unreal analog of OnSceneWasLoaded — fired on world/level swap.</summary>
        public virtual void OnLevelLoaded(string levelName) { }
    }

    /// <summary>
    /// Declares mod metadata — the UnrealMod analog of [MelonInfo]. Put it on the
    /// mod class (MelonLoader uses an assembly attribute; a class attribute is
    /// simpler for a single-class mod and the host reads either).
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class MelonInfoAttribute : Attribute
    {
        public Type SystemType { get; }
        public string Name { get; }
        public string Version { get; }
        public string Author { get; }
        public MelonInfoAttribute(Type type, string name, string version = "1.0.0", string author = "")
        {
            SystemType = type; Name = name; Version = version; Author = author;
        }
    }
}
