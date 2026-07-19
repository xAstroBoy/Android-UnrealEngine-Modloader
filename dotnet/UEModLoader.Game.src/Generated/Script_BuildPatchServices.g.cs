// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/BuildPatchServices
using System;

namespace UEModLoader.Game
{
    public class FileManifestData : StructProxy
    {
        public FileManifestData(global::System.IntPtr ptr) : base(ptr) {}
        public string Filename => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public SHAHashData FileHash => new SHAHashData(AddrOf(0x10));
        public TArray<global::System.IntPtr> FileChunkParts => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public TArray<global::System.IntPtr> InstallTags => new TArray<global::System.IntPtr>(AddrOf(0x38)); // TArray<FString>
        public bool bIsUnixExecutable { get => (GetAt<byte>(0x48) & 0xFF) != 0; set { var __b = GetAt<byte>(0x48); SetAt(0x48, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public string SymlinkTarget => Native.ReadFStringAt(AddrOf(0x50)); // FString
        public bool bIsReadOnly { get => (GetAt<byte>(0x60) & 0xFF) != 0; set { var __b = GetAt<byte>(0x60); SetAt(0x60, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIsCompressed { get => (GetAt<byte>(0x61) & 0xFF) != 0; set { var __b = GetAt<byte>(0x61); SetAt(0x61, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class ChunkPartData : StructProxy
    {
        public ChunkPartData(global::System.IntPtr ptr) : base(ptr) {}
        public Guid Guid => new Guid(AddrOf(0x0));
        public uint Offset { get => GetAt<uint>(0x10); set => SetAt(0x10, value); }
        public uint Size { get => GetAt<uint>(0x14); set => SetAt(0x14, value); }
    }

    public class SHAHashData : StructProxy
    {
        public SHAHashData(global::System.IntPtr ptr) : base(ptr) {}
        public global::System.IntPtr Hash => AddrOf(0x0); // [20] static array
    }

    public class ChunkInfoData : StructProxy
    {
        public ChunkInfoData(global::System.IntPtr ptr) : base(ptr) {}
        public Guid Guid => new Guid(AddrOf(0x0));
        public ulong Hash { get => GetAt<ulong>(0x10); set => SetAt(0x10, value); }
        public SHAHashData ShaHash => new SHAHashData(AddrOf(0x18));
        public long FileSize { get => GetAt<long>(0x30); set => SetAt(0x30, value); }
        public byte GroupNumber { get => GetAt<byte>(0x38); set => SetAt(0x38, value); }
    }

    public class CustomFieldData : StructProxy
    {
        public CustomFieldData(global::System.IntPtr ptr) : base(ptr) {}
        public string Key => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string Value => Native.ReadFStringAt(AddrOf(0x10)); // FString
    }

    public class BuildPatchManifest : Object
    {
        public const string UeClassName = "BuildPatchManifest";
        public BuildPatchManifest(global::System.IntPtr ptr) : base(ptr) {}
        public static new BuildPatchManifest FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BuildPatchManifest(p);
        public static BuildPatchManifest FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BuildPatchManifest(o.Pointer); }
        public static BuildPatchManifest[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BuildPatchManifest[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BuildPatchManifest(a[i].Pointer); return r; }
        public byte ManifestFileVersion { get => GetAt<byte>(0x28); set => SetAt(0x28, value); }
        public bool bIsFileData { get => Native.GetPropBool(Pointer, "bIsFileData"); set => Native.SetPropBool(Pointer, "bIsFileData", value); }
        public uint AppID { get => GetAt<uint>(0x2C); set => SetAt(0x2C, value); }
        public string AppName => Native.GetPropString(Pointer, "AppName"); // FString
        public string BuildVersion => Native.GetPropString(Pointer, "BuildVersion"); // FString
        public string LaunchExe => Native.GetPropString(Pointer, "LaunchExe"); // FString
        public string LaunchCommand => Native.GetPropString(Pointer, "LaunchCommand"); // FString
        public global::System.IntPtr PrereqIds => AddrOf(0x70); // 
        public string PrereqName => Native.GetPropString(Pointer, "PrereqName"); // FString
        public string PrereqPath => Native.GetPropString(Pointer, "PrereqPath"); // FString
        public string PrereqArgs => Native.GetPropString(Pointer, "PrereqArgs"); // FString
        public TArray<global::System.IntPtr> FileManifestList => new TArray<global::System.IntPtr>(AddrOf(0xF0)); // TArray<struct>
        public TArray<global::System.IntPtr> ChunkList => new TArray<global::System.IntPtr>(AddrOf(0x100)); // TArray<struct>
        public TArray<global::System.IntPtr> CustomFields => new TArray<global::System.IntPtr>(AddrOf(0x110)); // TArray<struct>
    }

}
