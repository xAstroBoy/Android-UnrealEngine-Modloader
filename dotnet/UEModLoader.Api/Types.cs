// UEModLoader.Api / Types.cs
// Small UE value types + the parameter-buffer marshaller the generated function
// proxies use to pack args at the real UFunction parameter offsets and read the
// return value back — so a generated call is byte-faithful to ProcessEvent.

using System;

namespace UEModLoader
{
    /// <summary>UE FName — a comparison index + number. 8 bytes, layout-matched.</summary>
    public struct FName
    {
        public int ComparisonIndex;
        public int Number;
        public FName(int idx, int num = 0) { ComparisonIndex = idx; Number = num; }
        public override string ToString() => $"FName({ComparisonIndex}:{Number})";
    }

    /// <summary>
    /// Base for generated struct proxies (UEModLoader.Game.F*). A UE struct is
    /// inline value data, so this wraps the struct's ADDRESS and its generated
    /// fields read/write at their real offsets — same accessors as UObject but
    /// with no UObject identity.
    /// </summary>
    public abstract class StructProxy
    {
        public IntPtr Pointer { get; protected set; }
        protected StructProxy(IntPtr ptr) { Pointer = ptr; }
        public bool IsValid => Pointer != IntPtr.Zero;
        public IntPtr AddrOf(int offset) => IsValid ? Pointer + offset : IntPtr.Zero;
        // A struct proxy passed as a function argument marshals as its address.
        public static implicit operator IntPtr(StructProxy s) => s?.Pointer ?? IntPtr.Zero;

        public unsafe T GetAt<T>(int offset) where T : unmanaged
        {
            if (!IsValid) return default;
            int sz = sizeof(T);
            byte[] buf = new byte[sz];
            if (!Native.MemRead(Pointer + offset, buf, sz)) return default;
            fixed (byte* p = buf) { return *(T*)p; }
        }
        public unsafe void SetAt<T>(int offset, T value) where T : unmanaged
        {
            if (!IsValid) return;
            int sz = sizeof(T);
            byte[] buf = new byte[sz];
            fixed (byte* p = buf) { *(T*)p = value; }
            Native.MemWrite(Pointer + offset, buf, sz);
        }
        // Struct FName/FString fields are read via the address-based native
        // readers (Native.FNameToString / Native.ReadFStringAt) baked by the
        // generator — no stubs, no by-name resolver needed.
    }

    /// <summary>
    /// Reader over a UE TArray&lt;T&gt; header {T* Data; int Num; int Max} for
    /// unmanaged element types (primitives, or IntPtr for object/struct arrays —
    /// wrap a returned pointer with `new Proxy(ptr)`).
    /// </summary>
    public struct TArray<T> where T : unmanaged
    {
        private readonly IntPtr _addr; // address of the TArray header
        public TArray(IntPtr headerAddr) { _addr = headerAddr; }

        public IntPtr Data => Memory.Read<IntPtr>(_addr);
        public int Count => _addr == IntPtr.Zero ? 0 : Memory.Read<int>(_addr + IntPtr.Size);

        public unsafe T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) return default;
                return Memory.Read<T>(Data + index * sizeof(T));
            }
            set
            {
                if (index < 0 || index >= Count) return;
                Memory.Write(Data + index * sizeof(T), value);
            }
        }

        public T[] ToArray()
        {
            int n = Count;
            var r = new T[n];
            for (int i = 0; i < n; i++) r[i] = this[i];
            return r;
        }
    }

    /// <summary>
    /// Builds and reads the packed parameter struct for a UFunction call at the
    /// exact parameter offsets. Generated method proxies do:
    ///   var pb = new ParamBuffer(ParmsSize);
    ///   pb.Set(off_a, a); pb.Set(off_b, b);
    ///   self.CallRaw("Func", pb.Bytes);
    ///   return pb.Get&lt;TRet&gt;(off_ret);
    /// </summary>
    public sealed class ParamBuffer
    {
        public byte[] Bytes { get; }
        public ParamBuffer(int size) { Bytes = new byte[size < 0 ? 0 : size]; }

        public unsafe void Set<T>(int offset, T value) where T : unmanaged
        {
            if (offset < 0 || offset + sizeof(T) > Bytes.Length) return;
            fixed (byte* p = &Bytes[offset]) { *(T*)p = value; }
        }

        public unsafe T Get<T>(int offset) where T : unmanaged
        {
            if (offset < 0 || offset + sizeof(T) > Bytes.Length) return default;
            fixed (byte* p = &Bytes[offset]) { return *(T*)p; }
        }

        /// <summary>Write a UObject argument (its native pointer) at offset.</summary>
        public void SetObject(int offset, UObject obj) => Set(offset, obj?.Pointer ?? IntPtr.Zero);

        /// <summary>Read a UObject return/out param at offset.</summary>
        public UObject GetObject(int offset)
        {
            IntPtr p = Get<IntPtr>(offset);
            return p == IntPtr.Zero ? null : new UObject(p);
        }
    }
}
