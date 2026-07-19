// UEModLoader.Api / UObject.cs
using System;
using System.Runtime.InteropServices;

namespace UEModLoader
{
    /// <summary>
    /// Faithful managed proxy over a native UE <c>UObject*</c>. It IS the raw
    /// pointer (<see cref="Pointer"/>) plus typed accessors that read/write at
    /// the object's REAL property offsets and invoke UFunctions through
    /// ProcessEvent under the crash guard. The generated <c>UEModLoader.Game</c>
    /// proxies derive from this, so a typed <c>BP_Enemy_C</c> and a raw
    /// <see cref="IntPtr"/> / the reflection walk / <see cref="Memory"/> all
    /// describe the same object — match data, spawn data, edit data, or go raw.
    /// </summary>
    public class UObject
    {
        /// <summary>The native UObject* this proxy wraps.</summary>
        public IntPtr Pointer { get; protected set; }

        public UObject(IntPtr pointer) { Pointer = pointer; }

        public bool IsValid => Pointer != IntPtr.Zero;
        public string Name => IsValid ? Native.GetObjectName(Pointer) : "None";
        public string ClassName => IsValid ? Native.GetClassName(Pointer) : "None";
        public bool IsA(string className) => IsValid && Native.IsA(Pointer, className);

        // ── Field access at the real offset ─────────────────────────────────
        // Reads/writes the property `name` at its Offset_Internal. The generated
        // proxies call the fast overloads with a baked const offset; the string
        // overloads resolve the offset at runtime (cached native side).

        public int OffsetOf(string prop) => IsValid ? Native.GetPropOffset(Pointer, prop) : -1;

        public T Get<T>(string prop) where T : unmanaged
        {
            int off = OffsetOf(prop);
            if (off < 0) return default;
            return GetAt<T>(off);
        }

        public void Set<T>(string prop, T value) where T : unmanaged
        {
            int off = OffsetOf(prop);
            if (off < 0) return;
            SetAt(off, value);
        }

        // Offset-typed fast path (what generated proxies use).
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

        // Bool / string / name property access is JUST NATIVE — the generated
        // proxies call Native.GetPropBool/SetPropBool (and the readers below)
        // directly; the C++ side owns the offset + bitfield mask, so there is no
        // bitmask math in managed code and no SetBool helper.

        // FString / FName as readable strings (host converts natively).
        public string GetString(string prop) => IsValid ? Native.GetPropString(Pointer, prop) : "";
        public string GetName(string prop) => IsValid ? Native.GetPropName(Pointer, prop) : "None";

        // Address of a field (for struct fields, or dropping to Memory/raw).
        public IntPtr AddrOf(int offset) => IsValid ? Pointer + offset : IntPtr.Zero;

        // Object-typed field: reads the pointer and wraps it.
        public UObject GetObject(string prop)
        {
            int off = OffsetOf(prop);
            if (off < 0) return null;
            IntPtr p = GetAt<IntPtr>(off);
            return p == IntPtr.Zero ? null : new UObject(p);
        }

        public UObject GetObjectAt(int offset)
        {
            IntPtr p = GetAt<IntPtr>(offset);
            return p == IntPtr.Zero ? null : new UObject(p);
        }

        // ── UFunction call ──────────────────────────────────────────────────
        // Resolve `func` on this object's class and ProcessEvent it with a
        // params buffer the caller has packed at the real parameter offsets.
        // The generated proxies build the buffer for you; this is the raw form.
        public unsafe void CallRaw(string func, byte[] paramsBuffer)
        {
            if (!IsValid) return;
            IntPtr fn = Native.ResolveFunction(Pointer, func);
            if (fn == IntPtr.Zero) { Log.Warn("Call", $"UFunction '{func}' not found on {ClassName}"); return; }
            if (paramsBuffer == null || paramsBuffer.Length == 0)
            {
                Native.ProcessEvent(Pointer, fn, IntPtr.Zero);
                return;
            }
            fixed (byte* p = paramsBuffer)
            {
                Native.ProcessEvent(Pointer, fn, (IntPtr)p);
            }
        }

        /// <summary>Call a void, no-arg UFunction.</summary>
        public void Call(string func) => CallRaw(func, null);

        // ── Discovery (static, over the reflection walk) ────────────────────
        public static UObject Find(string name)
        {
            IntPtr p = Native.FindObject(name);
            return p == IntPtr.Zero ? null : new UObject(p);
        }

        public static UObject FindFirstOf(string className)
        {
            IntPtr p = Native.FindFirstOf(className);
            return p == IntPtr.Zero ? null : new UObject(p);
        }

        public static UObject[] FindAllOf(string className)
        {
            IntPtr[] ptrs = Native.FindAllOf(className) ?? Array.Empty<IntPtr>();
            var arr = new UObject[ptrs.Length];
            for (int i = 0; i < ptrs.Length; i++) arr[i] = new UObject(ptrs[i]);
            return arr;
        }

        public static UObject Spawn(string className, UObject world = null)
        {
            IntPtr p = Native.SpawnActor(className, world?.Pointer ?? IntPtr.Zero);
            return p == IntPtr.Zero ? null : new UObject(p);
        }

        /// <summary>Base factory; generated proxies shadow this with `new`.</summary>
        public static UObject FromPointer(IntPtr p) => p == IntPtr.Zero ? null : new UObject(p);

        /// <summary>Write a UObject pointer into an object-typed field at offset.</summary>
        public void SetObjectAt(int offset, UObject value) => SetAt(offset, value?.Pointer ?? IntPtr.Zero);

        /// <summary>Reinterpret this proxy as a generated typed proxy T.</summary>
        public T As<T>() where T : UObject
            => (T)Activator.CreateInstance(typeof(T), Pointer);

        public override string ToString() => $"{ClassName} '{Name}' @0x{Pointer.ToInt64():x}";
        public override bool Equals(object obj) => obj is UObject o && o.Pointer == Pointer;
        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
