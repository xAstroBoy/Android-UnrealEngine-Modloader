// UEModLoader.Api / Native.cs
// The bridge into libmodloader. Under CoreCLR this is P/Invoke into the ueml_*
// functions the native host exports (extern "C"). A DllImportResolver (set in
// CoreCLRHost.Bootstrap) maps "libmodloader" to the already-loaded .so, so these
// resolve to the in-process module. String returns are native malloc'd char*
// (returned as IntPtr) that we convert with PtrToStringUTF8 and then ueml_free —
// unambiguous ownership. The public method names/signatures match what the rest
// of the API calls, so nothing else changed.

using System;
using System.Runtime.InteropServices;

namespace UEModLoader
{
    internal static class Native
    {
        internal const string LIB = "libmodloader";

        // Convert + free a native malloc'd UTF-8 string return.
        private static string Str(IntPtr p)
        {
            if (p == IntPtr.Zero) return "";
            string s = Marshal.PtrToStringUTF8(p) ?? "";
            ueml_free(p);
            return s;
        }

        // ── raw imports ──────────────────────────────────────────────────────
        [DllImport(LIB)] private static extern void ueml_log(int level,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string tag, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
        [DllImport(LIB)] private static extern IntPtr ueml_find_object([MarshalAs(UnmanagedType.LPUTF8Str)] string n);
        [DllImport(LIB)] private static extern IntPtr ueml_find_first_of([MarshalAs(UnmanagedType.LPUTF8Str)] string c);
        [DllImport(LIB)] private static extern IntPtr ueml_find_class([MarshalAs(UnmanagedType.LPUTF8Str)] string c);
        [DllImport(LIB)] private static extern int ueml_find_all_of([MarshalAs(UnmanagedType.LPUTF8Str)] string c, [Out] IntPtr[] outp, int cap);
        [DllImport(LIB)] private static extern IntPtr ueml_object_name(IntPtr o);
        [DllImport(LIB)] private static extern IntPtr ueml_class_name(IntPtr o);
        [DllImport(LIB)] private static extern int ueml_is_a(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string c);
        [DllImport(LIB)] private static extern int ueml_prop_offset(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern int ueml_prop_size(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern int ueml_prop_type(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern int ueml_get_bool(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern void ueml_set_bool(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p, int v);
        [DllImport(LIB)] private static extern long ueml_get_int(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern void ueml_set_int(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p, long v);
        [DllImport(LIB)] private static extern double ueml_get_float(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern void ueml_set_float(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p, double v);
        [DllImport(LIB)] private static extern IntPtr ueml_get_object(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern void ueml_set_object(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p, IntPtr v);
        [DllImport(LIB)] private static extern IntPtr ueml_get_string(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern IntPtr ueml_get_name(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern IntPtr ueml_read_fstring_at(IntPtr a);
        [DllImport(LIB)] private static extern IntPtr ueml_fname_to_string(int idx);
        [DllImport(LIB)] private static extern IntPtr ueml_resolve_function(IntPtr o, [MarshalAs(UnmanagedType.LPUTF8Str)] string f);
        [DllImport(LIB)] private static extern IntPtr ueml_find_function([MarshalAs(UnmanagedType.LPUTF8Str)] string p);
        [DllImport(LIB)] private static extern void ueml_process_event(IntPtr o, IntPtr f, IntPtr parms);
        [DllImport(LIB)] private static extern int ueml_mem_read(IntPtr a, [Out] byte[] dst, int len);
        [DllImport(LIB)] private static extern int ueml_mem_write(IntPtr a, [In] byte[] src, int len);
        [DllImport(LIB)] private static extern IntPtr ueml_alloc(int size);
        [DllImport(LIB)] internal static extern void ueml_free(IntPtr p);
        [DllImport(LIB)] private static extern IntPtr ueml_module_base([MarshalAs(UnmanagedType.LPUTF8Str)] string m);
        [DllImport(LIB)] private static extern IntPtr ueml_resolve_symbol([MarshalAs(UnmanagedType.LPUTF8Str)] string s);
        [DllImport(LIB)] private static extern int ueml_patch_bytes(IntPtr a, [In] byte[] b, int len, [MarshalAs(UnmanagedType.LPUTF8Str)] string owner);
        [DllImport(LIB)] private static extern int ueml_patch_nop(IntPtr a, int count, [MarshalAs(UnmanagedType.LPUTF8Str)] string owner);
        [DllImport(LIB)] private static extern IntPtr ueml_patch_asm(IntPtr a, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, [MarshalAs(UnmanagedType.LPUTF8Str)] string owner);
        [DllImport(LIB)] private static extern int ueml_assemble([MarshalAs(UnmanagedType.LPUTF8Str)] string text, IntPtr pc, [Out] byte[] outp, int cap, out IntPtr err);
        [DllImport(LIB)] private static extern int ueml_patch_branch(IntPtr a, IntPtr target, [MarshalAs(UnmanagedType.LPUTF8Str)] string owner);
        [DllImport(LIB)] private static extern int ueml_restore_patch(IntPtr a);
        [DllImport(LIB)] private static extern IntPtr ueml_get_script(IntPtr uf, out int len);
        [DllImport(LIB)] private static extern int ueml_set_script(IntPtr uf, [In] byte[] data, int len);
        [DllImport(LIB)] private static extern IntPtr ueml_get_native_func(IntPtr uf);
        [DllImport(LIB)] private static extern int ueml_set_native_func(IntPtr uf, IntPtr fn);
        [DllImport(LIB)] private static extern uint ueml_get_func_flags(IntPtr uf);
        [DllImport(LIB)] private static extern int ueml_set_func_flags(IntPtr uf, uint flags);
        [DllImport(LIB)] private static extern ulong ueml_hook_native([MarshalAs(UnmanagedType.LPUTF8Str)] string s, IntPtr addr, IntPtr pre, IntPtr post, [MarshalAs(UnmanagedType.LPUTF8Str)] string owner);
        [DllImport(LIB)] private static extern void ueml_unhook(ulong id);
        [DllImport(LIB)] private static extern ulong ueml_pe_hook_pre([MarshalAs(UnmanagedType.LPUTF8Str)] string path, IntPtr cb, [MarshalAs(UnmanagedType.LPUTF8Str)] string owner);
        [DllImport(LIB)] private static extern ulong ueml_pe_hook_post([MarshalAs(UnmanagedType.LPUTF8Str)] string path, IntPtr cb, [MarshalAs(UnmanagedType.LPUTF8Str)] string owner);
        [DllImport(LIB)] private static extern void ueml_pe_unhook(ulong id);
        [DllImport(LIB)] private static extern ulong ueml_ctx_get_x(IntPtr ctx, int i);
        [DllImport(LIB)] private static extern void ueml_ctx_set_x(IntPtr ctx, int i, ulong v);
        [DllImport(LIB)] private static extern double ueml_ctx_get_d(IntPtr ctx, int i);
        [DllImport(LIB)] private static extern void ueml_ctx_set_d(IntPtr ctx, int i, double v);
        [DllImport(LIB)] private static extern void ueml_ctx_block(IntPtr ctx);
        [DllImport(LIB)] private static extern void ueml_ctx_set_ret_x(IntPtr ctx, ulong v);
        [DllImport(LIB)] private static extern void ueml_ctx_set_ret_d(IntPtr ctx, double v);
        [DllImport(LIB)] private static extern IntPtr ueml_lua_eval([MarshalAs(UnmanagedType.LPUTF8Str)] string code);
        [DllImport(LIB)] private static extern IntPtr ueml_generate_proxies([MarshalAs(UnmanagedType.LPUTF8Str)] string outDir);
        [DllImport(LIB)] private static extern int ueml_register_command([MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr handler, [MarshalAs(UnmanagedType.LPUTF8Str)] string owner);
        [DllImport(LIB)] private static extern int ueml_wrap_command([MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr handler, [MarshalAs(UnmanagedType.LPUTF8Str)] string owner);
        [DllImport(LIB)] private static extern void ueml_unregister_command([MarshalAs(UnmanagedType.LPUTF8Str)] string name);
        [DllImport(LIB)] private static extern void ueml_cmd_return([MarshalAs(UnmanagedType.LPUTF8Str)] string s);
        [DllImport(LIB)] private static extern IntPtr ueml_cmd_call_original();
        [DllImport(LIB, EntryPoint = "ueml_data_dir")] private static extern IntPtr _data_dir();
        [DllImport(LIB, EntryPoint = "ueml_mods_dir")] private static extern IntPtr _mods_dir();
        [DllImport(LIB, EntryPoint = "ueml_userlibs_dir")] private static extern IntPtr _userlibs_dir();
        [DllImport(LIB, EntryPoint = "ueml_set_loaded_mod_count")] internal static extern void SetLoadedModCount(int n);

        // ── public API (stable signatures used by the rest of the assembly) ────
        public static void Log(int level, string tag, string message) => ueml_log(level, tag, message);
        public static IntPtr FindObject(string name) => ueml_find_object(name);
        public static IntPtr FindFirstOf(string cls) => ueml_find_first_of(cls);
        public static IntPtr FindClass(string cls) => ueml_find_class(cls);
        public static IntPtr[] FindAllOf(string cls)
        {
            int cap = 8192;
            var buf = new IntPtr[cap];
            int n = ueml_find_all_of(cls, buf, cap);
            if (n > cap) { cap = n; buf = new IntPtr[cap]; n = ueml_find_all_of(cls, buf, cap); }
            int m = n < cap ? n : cap;
            var r = new IntPtr[m];
            Array.Copy(buf, r, m);
            return r;
        }
        public static IntPtr SpawnActor(string cls, IntPtr world) => IntPtr.Zero; // not yet in host
        public static string GetObjectName(IntPtr o) => Str(ueml_object_name(o));
        public static string GetClassName(IntPtr o) => Str(ueml_class_name(o));
        public static bool IsA(IntPtr o, string c) => ueml_is_a(o, c) != 0;
        public static int GetPropOffset(IntPtr o, string p) => ueml_prop_offset(o, p);
        public static int GetPropSize(IntPtr o, string p) => ueml_prop_size(o, p);
        public static int GetPropType(IntPtr o, string p) => ueml_prop_type(o, p);
        public static bool GetPropBool(IntPtr o, string p) => ueml_get_bool(o, p) != 0;
        public static void SetPropBool(IntPtr o, string p, bool v) => ueml_set_bool(o, p, v ? 1 : 0);
        public static long GetPropInt(IntPtr o, string p) => ueml_get_int(o, p);
        public static void SetPropInt(IntPtr o, string p, long v) => ueml_set_int(o, p, v);
        public static double GetPropFloat(IntPtr o, string p) => ueml_get_float(o, p);
        public static void SetPropFloat(IntPtr o, string p, double v) => ueml_set_float(o, p, v);
        public static IntPtr GetPropObject(IntPtr o, string p) => ueml_get_object(o, p);
        public static void SetPropObject(IntPtr o, string p, IntPtr v) => ueml_set_object(o, p, v);
        public static string GetPropString(IntPtr o, string p) => Str(ueml_get_string(o, p));
        public static string GetPropName(IntPtr o, string p) => Str(ueml_get_name(o, p));
        public static string ReadFStringAt(IntPtr a) => Str(ueml_read_fstring_at(a));
        public static string FNameToString(int idx) => Str(ueml_fname_to_string(idx));
        public static IntPtr ResolveFunction(IntPtr o, string f) => ueml_resolve_function(o, f);
        public static IntPtr FindFunction(string p) => ueml_find_function(p);
        public static void ProcessEvent(IntPtr o, IntPtr f, IntPtr parms) => ueml_process_event(o, f, parms);
        public static bool MemRead(IntPtr a, byte[] dst, int len) => ueml_mem_read(a, dst, len) != 0;
        public static bool MemWrite(IntPtr a, byte[] src, int len) => ueml_mem_write(a, src, len) != 0;
        public static IntPtr Alloc(int size) => ueml_alloc(size);
        public static void Free(IntPtr p) => ueml_free(p);
        public static IntPtr ModuleBase(string m) => ueml_module_base(m ?? "");
        public static IntPtr ResolveSymbol(string s) => ueml_resolve_symbol(s);
        public static IntPtr AobScan(string module, string pattern) => IntPtr.Zero; // not yet in host
        public static bool PatchBytes(IntPtr a, byte[] b, int len, string owner) => ueml_patch_bytes(a, b, len, owner ?? "") != 0;
        public static bool PatchNop(IntPtr a, int count, string owner) => ueml_patch_nop(a, count, owner ?? "") != 0;
        public static string PatchAsm(IntPtr a, string text, string owner) => Str(ueml_patch_asm(a, text, owner ?? ""));
        public static byte[] Assemble(string text, IntPtr pc, out string error)
        {
            var buf = new byte[256];
            int n = ueml_assemble(text, pc, buf, buf.Length, out IntPtr errp);
            error = Str(errp);
            if (n <= 0) return Array.Empty<byte>();
            var r = new byte[n]; Array.Copy(buf, r, Math.Min(n, buf.Length)); return r;
        }
        public static bool PatchBranch(IntPtr a, IntPtr target, string owner) => ueml_patch_branch(a, target, owner ?? "") != 0;
        public static bool RestorePatch(IntPtr a) => ueml_restore_patch(a) != 0;
        public static IntPtr GetNativeFunc(IntPtr uf) => ueml_get_native_func(uf);
        public static bool SetNativeFunc(IntPtr uf, IntPtr fn) => ueml_set_native_func(uf, fn) != 0;
        public static uint GetFunctionFlags(IntPtr uf) => ueml_get_func_flags(uf);
        public static bool SetFunctionFlags(IntPtr uf, uint flags) => ueml_set_func_flags(uf, flags) != 0;
        // Blueprint/Kismet Script bytecode (UStruct::Script @ SCRIPT_OFF, resolved).
        public static byte[] GetScript(IntPtr uf)
        {
            IntPtr p = ueml_get_script(uf, out int len);
            if (p == IntPtr.Zero || len <= 0) return Array.Empty<byte>();
            var b = new byte[len];
            Marshal.Copy(p, b, 0, len);
            ueml_free(p);
            return b;
        }
        public static bool SetScript(IntPtr uf, byte[] bc, int len)
            => bc != null && ueml_set_script(uf, bc, len) != 0;
        public static ulong HookNative(string s, IntPtr addr, IntPtr pre, IntPtr post, string owner)
            => ueml_hook_native(s ?? "", addr, pre, post, owner ?? "");
        public static void Unhook(ulong id) => ueml_unhook(id);
        public static ulong PeHookPre(string path, IntPtr cb, string owner) => ueml_pe_hook_pre(path ?? "", cb, owner ?? "");
        public static ulong PeHookPost(string path, IntPtr cb, string owner) => ueml_pe_hook_post(path ?? "", cb, owner ?? "");
        public static void PeUnhook(ulong id) => ueml_pe_unhook(id);
        public static ulong CtxGetX(IntPtr ctx, int i) => ueml_ctx_get_x(ctx, i);
        public static void CtxSetX(IntPtr ctx, int i, ulong v) => ueml_ctx_set_x(ctx, i, v);
        public static double CtxGetD(IntPtr ctx, int i) => ueml_ctx_get_d(ctx, i);
        public static void CtxSetD(IntPtr ctx, int i, double v) => ueml_ctx_set_d(ctx, i, v);
        public static void CtxBlock(IntPtr ctx) => ueml_ctx_block(ctx);
        public static void CtxSetReturnX(IntPtr ctx, ulong v) => ueml_ctx_set_ret_x(ctx, v);
        public static void CtxSetReturnD(IntPtr ctx, double v) => ueml_ctx_set_ret_d(ctx, v);
        public static string LuaEval(string code) => Str(ueml_lua_eval(code ?? ""));
        public static string GenerateProxies(string outDir) => Str(ueml_generate_proxies(outDir ?? ""));
        public static bool RegisterCommand(string name, IntPtr handler, string owner) => ueml_register_command(name, handler, owner ?? "") != 0;
        public static bool WrapCommand(string name, IntPtr handler, string owner) => ueml_wrap_command(name, handler, owner ?? "") != 0;
        public static void UnregisterCommand(string name) => ueml_unregister_command(name);
        public static void CmdReturn(string result) => ueml_cmd_return(result ?? "");
        public static string CmdCallOriginal() => Str(ueml_cmd_call_original());
        public static string DataDir() => Str(_data_dir());
        public static string ModsDir() => Str(_mods_dir());
        public static string UserlibsDir() => Str(_userlibs_dir());
    }
}
