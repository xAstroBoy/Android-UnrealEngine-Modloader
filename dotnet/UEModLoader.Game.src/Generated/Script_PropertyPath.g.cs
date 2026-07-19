// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/PropertyPath
using System;

namespace UEModLoader.Game
{
    public class CachedPropertyPath : StructProxy
    {
        public CachedPropertyPath(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Segments => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public Function CachedFunction { get { var __p = GetAt<global::System.IntPtr>(0x18); return __p==global::System.IntPtr.Zero?null:new Function(__p); } set => SetAt(0x18, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class PropertyPathSegment : StructProxy
    {
        public PropertyPathSegment(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public int ArrayIndex { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public Struct Struct { get { var __p = GetAt<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new Struct(__p); } set => SetAt(0x10, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
