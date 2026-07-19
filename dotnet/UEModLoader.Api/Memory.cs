// UEModLoader.Api / Memory.cs
using System;

namespace UEModLoader
{
    /// <summary>Raw process memory access (kernel-mediated via /proc/self/mem,
    /// so it works on protected/execute-only pages), plus module + AOB helpers.
    /// Interops freely with <see cref="UObject.Pointer"/>.</summary>
    public static class Memory
    {
        public static bool Read(IntPtr addr, byte[] dst) => Native.MemRead(addr, dst, dst.Length);
        public static bool Write(IntPtr addr, byte[] src) => Native.MemWrite(addr, src, src.Length);

        public static byte[] ReadBytes(IntPtr addr, int len)
        {
            var buf = new byte[len];
            return Native.MemRead(addr, buf, len) ? buf : null;
        }

        public static unsafe T Read<T>(IntPtr addr) where T : unmanaged
        {
            int sz = sizeof(T);
            var buf = new byte[sz];
            if (!Native.MemRead(addr, buf, sz)) return default;
            fixed (byte* p = buf) { return *(T*)p; }
        }

        public static unsafe void Write<T>(IntPtr addr, T value) where T : unmanaged
        {
            int sz = sizeof(T);
            var buf = new byte[sz];
            fixed (byte* p = buf) { *(T*)p = value; }
            Native.MemWrite(addr, buf, sz);
        }

        public static IntPtr Alloc(int size) => Native.Alloc(size);
        public static void Free(IntPtr ptr) => Native.Free(ptr);

        /// <summary>Lowest mapping base of a loaded module (default libUE4.so).</summary>
        public static IntPtr ModuleBase(string module = "libUE4.so") => Native.ModuleBase(module);

        /// <summary>Resolve an exported symbol to its address (dlsym + fallback).</summary>
        public static IntPtr ResolveSymbol(string symbol) => Native.ResolveSymbol(symbol);

        /// <summary>AOB scan; pattern like "48 8B ?? E8 ? ? ?". Zero on miss.</summary>
        public static IntPtr AobScan(string pattern, string module = "libUE4.so")
            => Native.AobScan(module, pattern);
    }
}
