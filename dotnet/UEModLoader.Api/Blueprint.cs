// UEModLoader.Api / Blueprint.cs
using System;

namespace UEModLoader
{
    /// <summary>
    /// Blueprint / Kismet bytecode takeover. A UFunction carries its Blueprint VM
    /// program in a <c>Script</c> byte array plus (for native/thunked functions)
    /// a <c>Func</c> thunk pointer. Rewriting these overhauls what cooked
    /// Blueprint logic DOES at runtime — e.g. gut the built-in debug menu's event
    /// graph and replace it with your own — without editing the .pak on disk.
    ///
    /// Script bytes are heap data (not executable code), so replacement is a
    /// plain memory write; the change is reversible through <see cref="Restore"/>.
    /// The safest overhaul patterns:
    ///   • redirect: make the function a thunk that calls your native/hook code
    ///     (SetNativeFunc to a trampoline, or hook it with <see cref="Hooks"/>);
    ///   • neuter: replace the Script with a single EX_Return (0x04) so the graph
    ///     becomes a no-op you then drive yourself;
    ///   • rewrite: splice new Kismet bytecode you assembled.
    /// </summary>
    public sealed class Blueprint
    {
        /// <summary>The wrapped UFunction*.</summary>
        public IntPtr Function { get; }
        private byte[] _original;

        public Blueprint(IntPtr ufunction) { Function = ufunction; }

        public static Blueprint Find(string classColonFunction)
        {
            IntPtr fn = Native.FindFunction(classColonFunction);
            return fn == IntPtr.Zero ? null : new Blueprint(fn);
        }

        public bool IsValid => Function != IntPtr.Zero;

        /// <summary>Current Kismet bytecode (a copy).</summary>
        public byte[] GetBytecode() => Native.GetScript(Function);

        /// <summary>Replace the Kismet bytecode. First call snapshots the original
        /// so <see cref="Restore"/> can undo it.</summary>
        public bool SetBytecode(byte[] bytecode)
        {
            if (_original == null) _original = Native.GetScript(Function);
            return Native.SetScript(Function, bytecode, bytecode?.Length ?? 0);
        }

        /// <summary>Turn the whole event graph into a no-op (single EX_Return) so
        /// you can drive the behaviour yourself via a hook. Reversible.</summary>
        public bool Neuter() => SetBytecode(new byte[] { 0x04 /* EX_Return */ });

        /// <summary>Restore the original bytecode captured on the first Set.</summary>
        public bool Restore() => _original != null && Native.SetScript(Function, _original, _original.Length);

        /// <summary>The native Func thunk pointer (Blueprint VM entry / native impl).</summary>
        public IntPtr NativeFunc
        {
            get => Native.GetNativeFunc(Function);
            set => Native.SetNativeFunc(Function, value);
        }

        public uint Flags
        {
            get => Native.GetFunctionFlags(Function);
            set => Native.SetFunctionFlags(Function, value);
        }
    }
}
