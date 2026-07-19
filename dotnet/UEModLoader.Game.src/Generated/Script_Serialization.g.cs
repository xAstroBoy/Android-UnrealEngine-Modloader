// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/Serialization
using System;

namespace UEModLoader.Game
{
    public class StructSerializerTestStruct : StructProxy
    {
        public StructSerializerTestStruct(global::System.IntPtr ptr) : base(ptr) {}
        public StructSerializerNumericTestStruct Numerics => new StructSerializerNumericTestStruct(AddrOf(0x0));
        public StructSerializerBooleanTestStruct Booleans => new StructSerializerBooleanTestStruct(AddrOf(0x30));
        public StructSerializerObjectTestStruct Objects => new StructSerializerObjectTestStruct(AddrOf(0x38));
        public StructSerializerBuiltinTestStruct Builtins => new StructSerializerBuiltinTestStruct(AddrOf(0xE0));
        public StructSerializerArrayTestStruct Arrays => new StructSerializerArrayTestStruct(AddrOf(0x170));
        public StructSerializerMapTestStruct Maps => new StructSerializerMapTestStruct(AddrOf(0x1D0));
        public StructSerializerSetTestStruct Sets => new StructSerializerSetTestStruct(AddrOf(0x310));
    }

    public class StructSerializerSetTestStruct : StructProxy
    {
        public StructSerializerSetTestStruct(global::System.IntPtr ptr) : base(ptr) {}
        public global::System.IntPtr StrSet => AddrOf(0x0); // 
        public global::System.IntPtr IntSet => AddrOf(0x50); // 
        public global::System.IntPtr NameSet => AddrOf(0xA0); // 
        public global::System.IntPtr StructSet => AddrOf(0xF0); // 
    }

    public class StructSerializerBuiltinTestStruct : StructProxy
    {
        public StructSerializerBuiltinTestStruct(global::System.IntPtr ptr) : base(ptr) {}
        public Guid Guid => new Guid(AddrOf(0x0));
        public string Name => Native.FNameToString(GetAt<int>(0x10)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x10); set => SetAt(0x10, value); }
        public string String => Native.ReadFStringAt(AddrOf(0x18)); // FString
        public global::System.IntPtr Text => AddrOf(0x28); // 
        public Vector Vector => new Vector(AddrOf(0x40));
        public Vector4 Vector4 => new Vector4(AddrOf(0x50));
        public Rotator Rotator => new Rotator(AddrOf(0x60));
        public Quat Quat => new Quat(AddrOf(0x70));
        public Color Color => new Color(AddrOf(0x80));
    }

    public class StructSerializerMapTestStruct : StructProxy
    {
        public StructSerializerMapTestStruct(global::System.IntPtr ptr) : base(ptr) {}
        public global::System.IntPtr IntToStr => AddrOf(0x0); // 
        public global::System.IntPtr StrToStr => AddrOf(0x50); // 
        public global::System.IntPtr StrToVec => AddrOf(0xA0); // 
        public global::System.IntPtr StrToStruct => AddrOf(0xF0); // 
    }

    public class StructSerializerArrayTestStruct : StructProxy
    {
        public StructSerializerArrayTestStruct(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Int32Array => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<int32>
        public TArray<global::System.IntPtr> ByteArray => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<uint8>
        public int StaticSingleElement { get => GetAt<int>(0x20); set => SetAt(0x20, value); }
        public global::System.IntPtr StaticInt32Array => AddrOf(0x24); // [3] static array
        public global::System.IntPtr StaticFloatArray => AddrOf(0x30); // [3] static array
        public TArray<global::System.IntPtr> VectorArray => new TArray<global::System.IntPtr>(AddrOf(0x40)); // TArray<struct>
        public TArray<global::System.IntPtr> StructArray => new TArray<global::System.IntPtr>(AddrOf(0x50)); // TArray<struct>
    }

    public class StructSerializerObjectTestStruct : StructProxy
    {
        public StructSerializerObjectTestStruct(global::System.IntPtr ptr) : base(ptr) {}
        public Object Class { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MetaData SubClass { get { var __p = GetAt<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new MetaData(__p); } set => SetAt(0x8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject SoftClass { get { var __p = GetAt<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x10, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Object Object { get { var __p = GetAt<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x38, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MetaData WeakObject { get { var __p = GetAt<global::System.IntPtr>(0x40); return __p==global::System.IntPtr.Zero?null:new MetaData(__p); } set => SetAt(0x40, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MetaData SoftObject { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new MetaData(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoftClassPath ClassPath => new SoftClassPath(AddrOf(0x70));
        public SoftObjectPath ObjectPath => new SoftObjectPath(AddrOf(0x88));
    }

    public class StructSerializerBooleanTestStruct : StructProxy
    {
        public StructSerializerBooleanTestStruct(global::System.IntPtr ptr) : base(ptr) {}
        public bool BoolFalse { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool BoolTrue { get => (GetAt<byte>(0x1) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool Bitfield0 { get => (GetAt<byte>(0x2) & 0x1) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool Bitfield1 { get => (GetAt<byte>(0x2) & 0x2) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool Bitfield2Set { get => (GetAt<byte>(0x2) & 0x4) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool Bitfield3 { get => (GetAt<byte>(0x2) & 0x8) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool Bitfield4Set { get => (GetAt<byte>(0x2) & 0x10) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool Bitfield5Set { get => (GetAt<byte>(0x2) & 0x20) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool Bitfield6 { get => (GetAt<byte>(0x2) & 0x40) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
        public bool Bitfield7Set { get => (GetAt<byte>(0x2) & 0x80) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0x80) : (__b & ~0x80))); } }
    }

    public class StructSerializerNumericTestStruct : StructProxy
    {
        public StructSerializerNumericTestStruct(global::System.IntPtr ptr) : base(ptr) {}
        public sbyte Int8 { get => GetAt<sbyte>(0x0); set => SetAt(0x0, value); }
        public short Int16 { get => GetAt<short>(0x2); set => SetAt(0x2, value); }
        public int Int32 { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public long Int64 { get => GetAt<long>(0x8); set => SetAt(0x8, value); }
        public byte UInt8 { get => GetAt<byte>(0x10); set => SetAt(0x10, value); }
        public ushort UInt16 { get => GetAt<ushort>(0x12); set => SetAt(0x12, value); }
        public uint UInt32 { get => GetAt<uint>(0x14); set => SetAt(0x14, value); }
        public ulong UInt64 { get => GetAt<ulong>(0x18); set => SetAt(0x18, value); }
        public float Float { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public double Double { get => GetAt<double>(0x28); set => SetAt(0x28, value); }
    }

    public class StructSerializerByteArray : StructProxy
    {
        public StructSerializerByteArray(global::System.IntPtr ptr) : base(ptr) {}
        public int Dummy1 { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public TArray<global::System.IntPtr> ByteArray => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<uint8>
        public int Dummy2 { get => GetAt<int>(0x18); set => SetAt(0x18, value); }
        public TArray<global::System.IntPtr> Int8Array => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<int8>
        public int Dummy3 { get => GetAt<int>(0x30); set => SetAt(0x30, value); }
    }

}
