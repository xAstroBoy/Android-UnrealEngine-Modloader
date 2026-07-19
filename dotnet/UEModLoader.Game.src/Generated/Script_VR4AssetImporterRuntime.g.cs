// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/VR4AssetImporterRuntime
using System;

namespace UEModLoader.Game
{
    public class ImagePackRow : StructProxy
    {
        public ImagePackRow(global::System.IntPtr ptr) : base(ptr) {}
        public ImagePackData ImagePackData { get { var __p = GetAt<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new ImagePackData(__p); } set => SetAt(0x8, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class ImagePack : StructProxy
    {
        public ImagePack(global::System.IntPtr ptr) : base(ptr) {}
        public uint ImagePackId { get => GetAt<uint>(0x0); set => SetAt(0x0, value); }
        public TArray<global::System.IntPtr> Entries => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<struct>
    }

    public class ImagePackEntry : StructProxy
    {
        public ImagePackEntry(global::System.IntPtr ptr) : base(ptr) {}
        public ulong FileOffset { get => GetAt<ulong>(0x0); set => SetAt(0x0, value); }
        public Texture2D Texture { get { var __p = GetAt<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x8, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class ImagePackData : DataAsset
    {
        public const string UeClassName = "ImagePackData";
        public ImagePackData(global::System.IntPtr ptr) : base(ptr) {}
        public static new ImagePackData FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ImagePackData(p);
        public static ImagePackData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ImagePackData(o.Pointer); }
        public static ImagePackData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ImagePackData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ImagePackData(a[i].Pointer); return r; }
        public ImagePack ImagePack => new ImagePack(AddrOf(0x30));
    }

}
