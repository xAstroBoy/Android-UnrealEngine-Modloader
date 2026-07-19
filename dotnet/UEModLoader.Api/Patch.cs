// UEModLoader.Api / Patch.cs
using System;

namespace UEModLoader
{
    /// <summary>
    /// Static code patching — the SAME reversible, i-cache-correct engine
    /// (codepatch + arm64_asm) the Lua <c>PatchBytes/PatchAsm/...</c> use. Every
    /// patch is tagged with the calling mod's name (resolved by the host) so it
    /// reverts automatically on unload/quarantine, and the crash guard can
    /// attribute a fault to it. This is why the modloader needs no per-bug native
    /// patcher: a C# (or Lua) mod does its own byte patches / ARM replacement.
    /// </summary>
    public static class Patch
    {
        // owner is threaded through so reversal is automatic. UnrealMod sets its
        // own name as the ambient owner around lifecycle calls; passing null uses
        // that ambient owner.
        internal static string CurrentOwner = "";

        static string Owner(string owner) => owner ?? CurrentOwner;

        /// <summary>Overwrite code with raw bytes (reversible).</summary>
        public static bool Bytes(IntPtr addr, byte[] bytes, string owner = null)
            => Native.PatchBytes(addr, bytes, bytes.Length, Owner(owner));

        /// <summary>NOP out `count` instructions (default 1).</summary>
        public static bool Nop(IntPtr addr, int count = 1, string owner = null)
            => Native.PatchNop(addr, count, Owner(owner));

        /// <summary>Assemble AArch64 text AT addr (branches resolve) and write it.
        /// Returns null on success, or the assembler error string.</summary>
        public static string AsmPatch(IntPtr addr, string asmText, string owner = null)
        {
            string err = Native.PatchAsm(addr, asmText, Owner(owner));
            return string.IsNullOrEmpty(err) ? null : err;
        }

        /// <summary>Redirect flow: write `B target` at addr (±128MB).</summary>
        public static bool Branch(IntPtr addr, IntPtr target, string owner = null)
            => Native.PatchBranch(addr, target, Owner(owner));

        /// <summary>Revert one patched address immediately.</summary>
        public static bool Restore(IntPtr addr) => Native.RestorePatch(addr);
    }

    /// <summary>AArch64 mini-assembler (no write) — compose or inspect bytes.</summary>
    public static class Asm
    {
        /// <summary>Assemble one-instruction-per-line text to bytes. `pc` is the
        /// address the code would live at (needed for PC-relative branches).
        /// Returns null and sets <paramref name="error"/> on failure.</summary>
        public static byte[] Assemble(string text, IntPtr pc, out string error)
        {
            byte[] b = Native.Assemble(text, pc, out error);
            return string.IsNullOrEmpty(error) ? b : null;
        }
    }
}
