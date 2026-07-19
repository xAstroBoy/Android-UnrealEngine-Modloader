// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/ImageWriteQueue
using System;

namespace UEModLoader.Game
{
    public enum EDesiredImageFormat
    {
        PNG = 0,
        JPG = 1,
        BMP = 2,
        EXR = 3,
    }

    public class ImageWriteOptions : StructProxy
    {
        public ImageWriteOptions(System.IntPtr ptr) : base(ptr) {}
        public EDesiredImageFormat Format { get => (EDesiredImageFormat)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public System.IntPtr OnComplete => AddrOf(0x4); // 
        public int CompressionQuality { get => GetAt<int>(0x14); set => SetAt(0x14, value); }
        public bool bOverwriteFile { get => (GetAt<byte>(0x18) & 0xFF) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bAsync { get => (GetAt<byte>(0x19) & 0xFF) != 0; set { var __b = GetAt<byte>(0x19); SetAt(0x19, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class ImageWriteBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "ImageWriteBlueprintLibrary";
        public ImageWriteBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new ImageWriteBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ImageWriteBlueprintLibrary(p);
        public static ImageWriteBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ImageWriteBlueprintLibrary(o.Pointer); }
        public static ImageWriteBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ImageWriteBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ImageWriteBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x702EC74 — hookable via Hooks.InstallAt(NativeFunc_ExportToDisk).</summary>
        public static System.IntPtr NativeFunc_ExportToDisk => Memory.ModuleBase() + 0x702EC74;
        public void ExportToDisk(Texture Texture, System.IntPtr Filename, ImageWriteOptions Options)
        {
            var __pb = new ParamBuffer(128);
            __pb.SetObject(0x0, Texture);
            __pb.Set<System.IntPtr>(0x8, Filename);
            __pb.Set<System.IntPtr>(0x20, Options);
            CallRaw("ExportToDisk", __pb.Bytes);
        }
    }

}
