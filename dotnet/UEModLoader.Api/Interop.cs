// UEModLoader.Api / Interop.cs
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace UEModLoader
{
    /// <summary>Run Lua on the game thread from C# (the other direction — Lua
    /// calling registered commands — goes through <see cref="Commands"/>).</summary>
    public static class Lua
    {
        /// <summary>Execute a Lua snippet on the game thread; returns its string
        /// result (empty on failure). This is how a C# mod reuses the huge Lua
        /// surface (FindAllOf, hooks, the bespoke fixes) or hands work to a Lua mod.</summary>
        public static string Eval(string code) => Native.LuaEval(code) ?? "";
    }

    /// <summary>
    /// Register named commands callable from the ADB bridge / in-game console /
    /// Lua — and WRAP existing stock commands to append/enhance/override them.
    /// Lets a C# mod expose functionality to tools + Lua mods, and augment the
    /// built-ins. The handler reports its reply via return value (host-side
    /// CmdReturn); a wrapper receives a <c>callOriginal</c> that runs the stock
    /// command so it can add to or post-process the original output.
    /// </summary>
    public static class Commands
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void RawHandler(IntPtr argsUtf8);

        private static readonly List<object> s_keepAlive = new List<object>();
        internal static string CurrentOwner = "";

        private static IntPtr Thunk(Func<string, string> handler)
        {
            RawHandler raw = (argsUtf8) =>
            {
                string args = argsUtf8 == IntPtr.Zero ? "" : Marshal.PtrToStringAnsi(argsUtf8);
                string res;
                try { res = handler(args) ?? ""; }
                catch (Exception e) { res = "error: " + e.Message; Log.Error("Cmd", e.ToString()); }
                Native.CmdReturn(res);
            };
            s_keepAlive.Add(raw);
            return Marshal.GetFunctionPointerForDelegate(raw);
        }

        /// <summary>Register a new command. `handler(args)` returns the reply.</summary>
        public static bool Register(string name, Func<string, string> handler, string owner = null)
            => Native.RegisterCommand(name, Thunk(handler), owner ?? CurrentOwner);

        /// <summary>Enhance an existing command (built-in or custom). `handler`
        /// gets the args and a <paramref name="handler"/> that receives
        /// (args, callOriginal); call <c>callOriginal()</c> to run the stock
        /// command and augment/replace its output.</summary>
        public static bool Wrap(string name, Func<string, Func<string>, string> handler, string owner = null)
        {
            IntPtr fp = Thunk(args =>
            {
                Func<string> callOriginal = () => Native.CmdCallOriginal() ?? "";
                return handler(args, callOriginal);
            });
            return Native.WrapCommand(name, fp, owner ?? CurrentOwner);
        }

        public static void Unregister(string name) => Native.UnregisterCommand(name);
    }

    /// <summary>
    /// Cross-mod dependency registry. A C# mod publishes a shared object (an API
    /// surface, a service) under a key; other mods import it — so one mod can be
    /// a dependency of another. Pure-managed (no native round-trip); resolution
    /// is by string key so mods need not share compile-time references.
    /// </summary>
    public static class ModRegistry
    {
        private static readonly Dictionary<string, object> s_exports =
            new Dictionary<string, object>(StringComparer.Ordinal);

        /// <summary>Publish `service` under `key` for other mods to import.</summary>
        public static void Export(string key, object service)
        {
            s_exports[key] = service;
            Log.Info("ModDep", $"exported '{key}' ({service?.GetType().Name})");
        }

        /// <summary>Import a service another mod exported, or null if absent.</summary>
        public static object Import(string key)
            => s_exports.TryGetValue(key, out var v) ? v : null;

        /// <summary>Typed import.</summary>
        public static T Import<T>(string key) where T : class => Import(key) as T;

        public static bool Has(string key) => s_exports.ContainsKey(key);
    }
}
