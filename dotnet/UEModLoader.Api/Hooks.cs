// UEModLoader.Api / Hooks.cs
using System;
using System.Runtime.InteropServices;

namespace UEModLoader
{
    /// <summary>
    /// A native call frame handed to a hook callback. Wraps the underlying
    /// NativeCallContext (X0-X7 / D0-D7 + return/block controls). Read args,
    /// rewrite them, block the original, or override the return value.
    /// </summary>
    public sealed class NativeContext
    {
        internal IntPtr Ctx;
        internal NativeContext(IntPtr ctx) { Ctx = ctx; }

        public ulong GetArg(int index) => Native.CtxGetX(Ctx, index);
        public void SetArg(int index, ulong value) => Native.CtxSetX(Ctx, index, value);
        public IntPtr GetArgPtr(int index) => (IntPtr)Native.CtxGetX(Ctx, index);
        public double GetFloatArg(int index) => Native.CtxGetD(Ctx, index);
        public void SetFloatArg(int index, double value) => Native.CtxSetD(Ctx, index, value);

        /// <summary>Wrap arg[index] as a UObject proxy (it must be a UObject*).</summary>
        public UObject GetObjectArg(int index)
        {
            IntPtr p = GetArgPtr(index);
            return p == IntPtr.Zero ? null : new UObject(p);
        }

        /// <summary>Skip the original function entirely.</summary>
        public void Block() => Native.CtxBlock(Ctx);
        public void SetReturn(ulong value) => Native.CtxSetReturnX(Ctx, value);
        public void SetReturn(IntPtr value) => Native.CtxSetReturnX(Ctx, (ulong)value);
        public void SetReturnFloat(double value) => Native.CtxSetReturnD(Ctx, value);
    }

    /// <summary>A hook callback: inspect/modify the call frame.</summary>
    public delegate void HookCallback(NativeContext ctx);

    /// <summary>
    /// Native + UFunction hooking with managed callbacks. A pre-callback can
    /// rewrite args or block; a post-callback can rewrite the return. Hooks are
    /// tagged with the mod's name so they detach on unload/quarantine.
    /// </summary>
    public static class Hooks
    {
        // Reverse-pinvoke thunk: Mono calls this native-callable delegate with the
        // raw context pointer; we look up the managed callback and invoke it.
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void RawCb(IntPtr ctx);

        // Keep delegates alive (GC would otherwise collect the thunk).
        private static readonly System.Collections.Generic.List<object> s_keepAlive
            = new System.Collections.Generic.List<object>();

        internal static string CurrentOwner = "";

        private static IntPtr Thunk(HookCallback cb)
        {
            if (cb == null) return IntPtr.Zero;
            RawCb raw = (ctx) =>
            {
                try { cb(new NativeContext(ctx)); }
                catch (Exception e) { Log.Error("Hook", e.ToString()); }
            };
            s_keepAlive.Add(raw);
            return Marshal.GetFunctionPointerForDelegate(raw);
        }

        /// <summary>Hook a native symbol ("cModel::getPartsPtr") or a
        /// "Class:Function" UFunction path. Either callback may be null.</summary>
        public static ulong Install(string symbolOrPath, HookCallback pre, HookCallback post = null,
                                    string owner = null)
        {
            return Native.HookNative(symbolOrPath, IntPtr.Zero, Thunk(pre), Thunk(post),
                                     owner ?? CurrentOwner);
        }

        /// <summary>Hook a raw address.</summary>
        public static ulong InstallAt(IntPtr addr, HookCallback pre, HookCallback post = null,
                                      string owner = null)
        {
            return Native.HookNative(null, addr, Thunk(pre), Thunk(post), owner ?? CurrentOwner);
        }

        public static void Remove(ulong hookId) => Native.Unhook(hookId);

        // ── UFunction (ProcessEvent) hooks — the C# analog of Lua RegisterHook ──
        // Hook a Blueprint/native "Class:Function" path through the ProcessEvent
        // dispatcher. Unlike Install (which hooks a native symbol address), the
        // callback receives the calling object (X0=self) and a FLAT params buffer,
        // and a pre-hook returning true BLOCKS the original — exactly what a
        // Blueprint overhaul (e.g. the debug menu) needs.
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int RawPre(IntPtr self, IntPtr parms);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void RawPost(IntPtr self, IntPtr parms);

        /// <summary>Pre-hook a UFunction. Return true to BLOCK the original call.</summary>
        public static ulong OnUFunctionPre(string path, Func<UObject, IntPtr, bool> cb, string owner = null)
        {
            if (cb == null) return 0;
            RawPre raw = (self, parms) =>
            {
                try { return cb(self == IntPtr.Zero ? null : new UObject(self), parms) ? 1 : 0; }
                catch (Exception e) { Log.Error("Hook", e.ToString()); return 0; }
            };
            s_keepAlive.Add(raw);
            return Native.PeHookPre(path, Marshal.GetFunctionPointerForDelegate(raw), owner ?? CurrentOwner);
        }

        /// <summary>Post-hook a UFunction (runs after the original).</summary>
        public static ulong OnUFunctionPost(string path, Action<UObject, IntPtr> cb, string owner = null)
        {
            if (cb == null) return 0;
            RawPost raw = (self, parms) =>
            {
                try { cb(self == IntPtr.Zero ? null : new UObject(self), parms); }
                catch (Exception e) { Log.Error("Hook", e.ToString()); }
            };
            s_keepAlive.Add(raw);
            return Native.PeHookPost(path, Marshal.GetFunctionPointerForDelegate(raw), owner ?? CurrentOwner);
        }

        /// <summary>Remove a UFunction hook by the id returned from OnUFunctionPre/Post.</summary>
        public static void RemoveUFunction(ulong id) => Native.PeUnhook(id);
    }

    /// <summary>
    /// Harmony/AstroPatch-style declarative patch. Put it on a static method in
    /// your mod; the host discovers it and installs a hook on the target. A
    /// method named <c>Prefix</c> runs before (return false to block), one named
    /// <c>Postfix</c> runs after. Both take a <see cref="NativeContext"/>.
    /// Target is a native symbol or a "Class:Function" UFunction path.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class PatchAttribute : Attribute
    {
        public string Target { get; }
        public PatchAttribute(string target) { Target = target; }
    }
}
