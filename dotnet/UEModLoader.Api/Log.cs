// UEModLoader.Api / Log.cs
using System;

namespace UEModLoader
{
    /// <summary>
    /// The C# log system. Routes to the modloader log (UEModLoader.log) + logcat.
    /// DEBUG is suppressed by default (the native logger gates it) — turn it on
    /// with the `log_level` bridge command (level=debug) or the config
    /// <c>log_level</c> key. MelonLogger-style aliases (Msg/Warning) are provided
    /// so MelonLoader muscle memory works.
    /// </summary>
    public static class Log
    {
        // Levels mirror logger.h: 0=debug 1=info 2=warn 3=error.
        public static void Debug(string msg) => Native.Log(0, "C#", msg);
        public static void Info(string msg) => Native.Log(1, "C#", msg);
        public static void Warn(string msg) => Native.Log(2, "C#", msg);
        public static void Error(string msg) => Native.Log(3, "C#", msg);

        public static void Debug(string tag, string msg) => Native.Log(0, tag, msg);
        public static void Info(string tag, string msg) => Native.Log(1, tag, msg);
        public static void Warn(string tag, string msg) => Native.Log(2, tag, msg);
        public static void Error(string tag, string msg) => Native.Log(3, tag, msg);

        // MelonLogger-style aliases.
        public static void Msg(string msg) => Info(msg);
        public static void Warning(string msg) => Warn(msg);
        public static void Error(string msg, Exception e) => Error(msg + " :: " + e);
    }

    /// <summary>MelonLogger alias for MelonLoader familiarity.</summary>
    public static class MelonLogger
    {
        public static void Msg(string msg) => Log.Info(msg);
        public static void Warning(string msg) => Log.Warn(msg);
        public static void Error(string msg) => Log.Error(msg);
    }

    /// <summary>
    /// Per-mod logger — every line is tagged with the MOD'S NAME so the origin
    /// is clear (the native logger already prepends the timestamp). Each
    /// UnrealMod gets one as <see cref="UnrealMod.Logger"/> /
    /// <see cref="UnrealMod.LoggerInstance"/>, set at registration. Same shape as
    /// MelonLoader's LoggerInstance.
    /// </summary>
    public sealed class ModLogger
    {
        private readonly string _tag;
        public ModLogger(string modName) { _tag = string.IsNullOrEmpty(modName) ? "C#" : modName; }

        public void Debug(string msg) => Native.Log(0, _tag, msg);
        public void Msg(string msg) => Native.Log(1, _tag, msg);
        public void Info(string msg) => Native.Log(1, _tag, msg);
        public void Warning(string msg) => Native.Log(2, _tag, msg);
        public void Warn(string msg) => Native.Log(2, _tag, msg);
        public void Error(string msg) => Native.Log(3, _tag, msg);
        public void Error(string msg, Exception e) => Native.Log(3, _tag, msg + " :: " + e);
    }
}
