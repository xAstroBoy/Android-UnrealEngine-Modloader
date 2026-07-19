// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AssetRegistry
using System;

namespace UEModLoader.Game
{
    public class ARFilter : StructProxy
    {
        public ARFilter(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> PackageNames => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<FName>
        public TArray<System.IntPtr> PackagePaths => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<FName>
        public TArray<System.IntPtr> ObjectPaths => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<FName>
        public TArray<System.IntPtr> ClassNames => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<FName>
        public System.IntPtr RecursiveClassesExclusionSet => AddrOf(0x90); // 
        public bool bRecursivePaths { get => (GetAt<byte>(0xE0) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE0); SetAt(0xE0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bRecursiveClasses { get => (GetAt<byte>(0xE1) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE1); SetAt(0xE1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIncludeOnlyOnDiskAssets { get => (GetAt<byte>(0xE2) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE2); SetAt(0xE2, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AssetBundleData : StructProxy
    {
        public AssetBundleData(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Bundles => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class AssetBundleEntry : StructProxy
    {
        public AssetBundleEntry(System.IntPtr ptr) : base(ptr) {}
        public PrimaryAssetId BundleScope => new PrimaryAssetId(AddrOf(0x0));
        public string BundleName => Native.FNameToString(GetAt<int>(0x10)); // FName
        public FName BundleName_Raw { get => GetAt<FName>(0x10); set => SetAt(0x10, value); }
        public TArray<System.IntPtr> BundleAssets => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<struct>
    }

    public class AssetData : StructProxy
    {
        public AssetData(System.IntPtr ptr) : base(ptr) {}
        public string ObjectPath => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ObjectPath_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string PackageName => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName PackageName_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
        public string PackagePath => Native.FNameToString(GetAt<int>(0x10)); // FName
        public FName PackagePath_Raw { get => GetAt<FName>(0x10); set => SetAt(0x10, value); }
        public string AssetName => Native.FNameToString(GetAt<int>(0x18)); // FName
        public FName AssetName_Raw { get => GetAt<FName>(0x18); set => SetAt(0x18, value); }
        public string AssetClass => Native.FNameToString(GetAt<int>(0x20)); // FName
        public FName AssetClass_Raw { get => GetAt<FName>(0x20); set => SetAt(0x20, value); }
    }

    public class TagAndValue : StructProxy
    {
        public TagAndValue(System.IntPtr ptr) : base(ptr) {}
        public string Tag => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Tag_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string Value => Native.ReadFStringAt(AddrOf(0x8)); // FString
    }

    public class AssetRegistryDependencyOptions : StructProxy
    {
        public AssetRegistryDependencyOptions(System.IntPtr ptr) : base(ptr) {}
        public bool bIncludeSoftPackageReferences { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIncludeHardPackageReferences { get => (GetAt<byte>(0x1) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIncludeSearchableNames { get => (GetAt<byte>(0x2) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIncludeSoftManagementReferences { get => (GetAt<byte>(0x3) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3); SetAt(0x3, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIncludeHardManagementReferences { get => (GetAt<byte>(0x4) & 0xFF) != 0; set { var __b = GetAt<byte>(0x4); SetAt(0x4, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AssetRegistryImpl : Object
    {
        public const string UeClassName = "AssetRegistryImpl";
        public AssetRegistryImpl(System.IntPtr ptr) : base(ptr) {}
        public static new AssetRegistryImpl FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AssetRegistryImpl(p);
        public static AssetRegistryImpl FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AssetRegistryImpl(o.Pointer); }
        public static AssetRegistryImpl[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AssetRegistryImpl[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AssetRegistryImpl(a[i].Pointer); return r; }
    }

    public class AssetRegistryHelpers : Object
    {
        public const string UeClassName = "AssetRegistryHelpers";
        public AssetRegistryHelpers(System.IntPtr ptr) : base(ptr) {}
        public static new AssetRegistryHelpers FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AssetRegistryHelpers(p);
        public static AssetRegistryHelpers FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AssetRegistryHelpers(o.Pointer); }
        public static AssetRegistryHelpers[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AssetRegistryHelpers[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AssetRegistryHelpers(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7FC6EF4 — hookable via Hooks.InstallAt(NativeFunc_ToSoftObjectPath).</summary>
        public static System.IntPtr NativeFunc_ToSoftObjectPath => Memory.ModuleBase() + 0x7FC6EF4;
        public SoftObjectPath ToSoftObjectPath(AssetData InAssetData)
        {
            var __pb = new ParamBuffer(104);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            CallRaw("ToSoftObjectPath", __pb.Bytes);
            return __pb.Get<SoftObjectPath>(0x50);
        }
        /// <summary>[Native] thunk RVA 0x7FC64C0 — hookable via Hooks.InstallAt(NativeFunc_SetFilterTagsAndValues).</summary>
        public static System.IntPtr NativeFunc_SetFilterTagsAndValues => Memory.ModuleBase() + 0x7FC64C0;
        public ARFilter SetFilterTagsAndValues(ARFilter InFilter, System.IntPtr InTagsAndValues)
        {
            var __pb = new ParamBuffer(480);
            __pb.Set<System.IntPtr>(0x0, InFilter);
            __pb.Set<System.IntPtr>(0xE8, InTagsAndValues);
            CallRaw("SetFilterTagsAndValues", __pb.Bytes);
            return __pb.Get<ARFilter>(0xF8);
        }
        /// <summary>[Native] thunk RVA 0x7FC743C — hookable via Hooks.InstallAt(NativeFunc_IsValid).</summary>
        public static System.IntPtr NativeFunc_IsValid => Memory.ModuleBase() + 0x7FC743C;
        public bool IsValid(AssetData InAssetData)
        {
            var __pb = new ParamBuffer(81);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            CallRaw("IsValid", __pb.Bytes);
            return __pb.Get<byte>(0x50) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC730C — hookable via Hooks.InstallAt(NativeFunc_IsUAsset).</summary>
        public static System.IntPtr NativeFunc_IsUAsset => Memory.ModuleBase() + 0x7FC730C;
        public bool IsUAsset(AssetData InAssetData)
        {
            var __pb = new ParamBuffer(81);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            CallRaw("IsUAsset", __pb.Bytes);
            return __pb.Get<byte>(0x50) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC71DC — hookable via Hooks.InstallAt(NativeFunc_IsRedirector).</summary>
        public static System.IntPtr NativeFunc_IsRedirector => Memory.ModuleBase() + 0x7FC71DC;
        public bool IsRedirector(AssetData InAssetData)
        {
            var __pb = new ParamBuffer(81);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            CallRaw("IsRedirector", __pb.Bytes);
            return __pb.Get<byte>(0x50) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC6B6C — hookable via Hooks.InstallAt(NativeFunc_IsAssetLoaded).</summary>
        public static System.IntPtr NativeFunc_IsAssetLoaded => Memory.ModuleBase() + 0x7FC6B6C;
        public bool IsAssetLoaded(AssetData InAssetData)
        {
            var __pb = new ParamBuffer(81);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            CallRaw("IsAssetLoaded", __pb.Bytes);
            return __pb.Get<byte>(0x50) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC6818 — hookable via Hooks.InstallAt(NativeFunc_GetTagValue).</summary>
        public static System.IntPtr NativeFunc_GetTagValue => Memory.ModuleBase() + 0x7FC6818;
        public bool GetTagValue(AssetData InAssetData, FName InTagName, System.IntPtr OutTagValue)
        {
            var __pb = new ParamBuffer(105);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            __pb.Set(0x50, InTagName);
            __pb.Set<System.IntPtr>(0x58, OutTagValue);
            CallRaw("GetTagValue", __pb.Bytes);
            return __pb.Get<byte>(0x68) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC706C — hookable via Hooks.InstallAt(NativeFunc_GetFullName).</summary>
        public static System.IntPtr NativeFunc_GetFullName => Memory.ModuleBase() + 0x7FC706C;
        public System.IntPtr GetFullName(AssetData InAssetData)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            CallRaw("GetFullName", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x50);
        }
        /// <summary>[Native] thunk RVA 0x7FC69FC — hookable via Hooks.InstallAt(NativeFunc_GetExportTextName).</summary>
        public static System.IntPtr NativeFunc_GetExportTextName => Memory.ModuleBase() + 0x7FC69FC;
        public System.IntPtr GetExportTextName(AssetData InAssetData)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            CallRaw("GetExportTextName", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x50);
        }
        /// <summary>[Native] thunk RVA 0x7FC6DC8 — hookable via Hooks.InstallAt(NativeFunc_GetClass).</summary>
        public static System.IntPtr NativeFunc_GetClass => Memory.ModuleBase() + 0x7FC6DC8;
        public Object GetClass(AssetData InAssetData)
        {
            var __pb = new ParamBuffer(88);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            CallRaw("GetClass", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x50); return __p==System.IntPtr.Zero?null:new Object(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7FC779C — hookable via Hooks.InstallAt(NativeFunc_GetAssetRegistry).</summary>
        public static System.IntPtr NativeFunc_GetAssetRegistry => Memory.ModuleBase() + 0x7FC779C;
        public UObject GetAssetRegistry()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAssetRegistry", __pb.Bytes);
            return __pb.GetObject(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7FC6C9C — hookable via Hooks.InstallAt(NativeFunc_GetAsset).</summary>
        public static System.IntPtr NativeFunc_GetAsset => Memory.ModuleBase() + 0x7FC6C9C;
        public Object GetAsset(AssetData InAssetData)
        {
            var __pb = new ParamBuffer(88);
            __pb.Set<System.IntPtr>(0x0, InAssetData);
            CallRaw("GetAsset", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x50); return __p==System.IntPtr.Zero?null:new Object(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7FC756C — hookable via Hooks.InstallAt(NativeFunc_CreateAssetData).</summary>
        public static System.IntPtr NativeFunc_CreateAssetData => Memory.ModuleBase() + 0x7FC756C;
        public AssetData CreateAssetData(Object InAsset, bool bAllowBlueprintClass)
        {
            var __pb = new ParamBuffer(96);
            __pb.SetObject(0x0, InAsset);
            __pb.Set<byte>(0x8, (byte)(bAllowBlueprintClass?1:0));
            CallRaw("CreateAssetData", __pb.Bytes);
            return __pb.Get<AssetData>(0x10);
        }
    }

    public class AssetRegistry : Interface
    {
        public const string UeClassName = "AssetRegistry";
        public AssetRegistry(System.IntPtr ptr) : base(ptr) {}
        public static new AssetRegistry FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AssetRegistry(p);
        public static AssetRegistry FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AssetRegistry(o.Pointer); }
        public static AssetRegistry[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AssetRegistry[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AssetRegistry(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7FC8F8C — hookable via Hooks.InstallAt(NativeFunc_UseFilterToExcludeAssets).</summary>
        public static System.IntPtr NativeFunc_UseFilterToExcludeAssets => Memory.ModuleBase() + 0x7FC8F8C;
        public void UseFilterToExcludeAssets(System.IntPtr AssetDataList, ARFilter Filter)
        {
            var __pb = new ParamBuffer(248);
            __pb.Set<System.IntPtr>(0x0, AssetDataList);
            __pb.Set<System.IntPtr>(0x10, Filter);
            CallRaw("UseFilterToExcludeAssets", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FC8C50 — hookable via Hooks.InstallAt(NativeFunc_SearchAllAssets).</summary>
        public static System.IntPtr NativeFunc_SearchAllAssets => Memory.ModuleBase() + 0x7FC8C50;
        public void SearchAllAssets(bool bSynchronousSearch)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bSynchronousSearch?1:0));
            CallRaw("SearchAllAssets", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FC8E48 — hookable via Hooks.InstallAt(NativeFunc_ScanPathsSynchronous).</summary>
        public static System.IntPtr NativeFunc_ScanPathsSynchronous => Memory.ModuleBase() + 0x7FC8E48;
        public void ScanPathsSynchronous(System.IntPtr InPaths, bool bForceRescan)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, InPaths);
            __pb.Set<byte>(0x10, (byte)(bForceRescan?1:0));
            CallRaw("ScanPathsSynchronous", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FC8A9C — hookable via Hooks.InstallAt(NativeFunc_ScanModifiedAssetFiles).</summary>
        public static System.IntPtr NativeFunc_ScanModifiedAssetFiles => Memory.ModuleBase() + 0x7FC8A9C;
        public void ScanModifiedAssetFiles(System.IntPtr InFilePaths)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InFilePaths);
            CallRaw("ScanModifiedAssetFiles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FC8D04 — hookable via Hooks.InstallAt(NativeFunc_ScanFilesSynchronous).</summary>
        public static System.IntPtr NativeFunc_ScanFilesSynchronous => Memory.ModuleBase() + 0x7FC8D04;
        public void ScanFilesSynchronous(System.IntPtr InFilePaths, bool bForceRescan)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, InFilePaths);
            __pb.Set<byte>(0x10, (byte)(bForceRescan?1:0));
            CallRaw("ScanFilesSynchronous", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FC9198 — hookable via Hooks.InstallAt(NativeFunc_RunAssetsThroughFilter).</summary>
        public static System.IntPtr NativeFunc_RunAssetsThroughFilter => Memory.ModuleBase() + 0x7FC9198;
        public void RunAssetsThroughFilter(System.IntPtr AssetDataList, ARFilter Filter)
        {
            var __pb = new ParamBuffer(248);
            __pb.Set<System.IntPtr>(0x0, AssetDataList);
            __pb.Set<System.IntPtr>(0x10, Filter);
            CallRaw("RunAssetsThroughFilter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FC8B98 — hookable via Hooks.InstallAt(NativeFunc_PrioritizeSearchPath).</summary>
        public static System.IntPtr NativeFunc_PrioritizeSearchPath => Memory.ModuleBase() + 0x7FC8B98;
        public void PrioritizeSearchPath(System.IntPtr PathToPrioritize)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, PathToPrioritize);
            CallRaw("PrioritizeSearchPath", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FC9638 — hookable via Hooks.InstallAt(NativeFunc_K2_GetReferencers).</summary>
        public static System.IntPtr NativeFunc_K2_GetReferencers => Memory.ModuleBase() + 0x7FC9638;
        public bool K2_GetReferencers(FName PackageName, AssetRegistryDependencyOptions ReferenceOptions, System.IntPtr OutReferencers)
        {
            var __pb = new ParamBuffer(33);
            __pb.Set(0x0, PackageName);
            __pb.Set<System.IntPtr>(0x8, ReferenceOptions);
            __pb.Set<System.IntPtr>(0x10, OutReferencers);
            CallRaw("K2_GetReferencers", __pb.Bytes);
            return __pb.Get<byte>(0x20) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC97A8 — hookable via Hooks.InstallAt(NativeFunc_K2_GetDependencies).</summary>
        public static System.IntPtr NativeFunc_K2_GetDependencies => Memory.ModuleBase() + 0x7FC97A8;
        public bool K2_GetDependencies(FName PackageName, AssetRegistryDependencyOptions DependencyOptions, System.IntPtr OutDependencies)
        {
            var __pb = new ParamBuffer(33);
            __pb.Set(0x0, PackageName);
            __pb.Set<System.IntPtr>(0x8, DependencyOptions);
            __pb.Set<System.IntPtr>(0x10, OutDependencies);
            CallRaw("K2_GetDependencies", __pb.Bytes);
            return __pb.Get<byte>(0x20) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC8A5C — hookable via Hooks.InstallAt(NativeFunc_IsLoadingAssets).</summary>
        public static System.IntPtr NativeFunc_IsLoadingAssets => Memory.ModuleBase() + 0x7FC8A5C;
        public bool IsLoadingAssets()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsLoadingAssets", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FCA578 — hookable via Hooks.InstallAt(NativeFunc_HasAssets).</summary>
        public static System.IntPtr NativeFunc_HasAssets => Memory.ModuleBase() + 0x7FCA578;
        public bool HasAssets(FName PackagePath, bool bRecursive)
        {
            var __pb = new ParamBuffer(10);
            __pb.Set(0x0, PackagePath);
            __pb.Set<byte>(0x8, (byte)(bRecursive?1:0));
            CallRaw("HasAssets", __pb.Bytes);
            return __pb.Get<byte>(0x9) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC93A4 — hookable via Hooks.InstallAt(NativeFunc_GetSubPaths).</summary>
        public static System.IntPtr NativeFunc_GetSubPaths => Memory.ModuleBase() + 0x7FC93A4;
        public void GetSubPaths(System.IntPtr InBasePath, System.IntPtr OutPathList, bool bInRecurse)
        {
            var __pb = new ParamBuffer(33);
            __pb.Set<System.IntPtr>(0x0, InBasePath);
            __pb.Set<System.IntPtr>(0x10, OutPathList);
            __pb.Set<byte>(0x20, (byte)(bInRecurse?1:0));
            CallRaw("GetSubPaths", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FCA128 — hookable via Hooks.InstallAt(NativeFunc_GetAssetsByPath).</summary>
        public static System.IntPtr NativeFunc_GetAssetsByPath => Memory.ModuleBase() + 0x7FCA128;
        public bool GetAssetsByPath(FName PackagePath, System.IntPtr OutAssetData, bool bRecursive, bool bIncludeOnlyOnDiskAssets)
        {
            var __pb = new ParamBuffer(27);
            __pb.Set(0x0, PackagePath);
            __pb.Set<System.IntPtr>(0x8, OutAssetData);
            __pb.Set<byte>(0x18, (byte)(bRecursive?1:0));
            __pb.Set<byte>(0x19, (byte)(bIncludeOnlyOnDiskAssets?1:0));
            CallRaw("GetAssetsByPath", __pb.Bytes);
            return __pb.Get<byte>(0x1A) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FCA378 — hookable via Hooks.InstallAt(NativeFunc_GetAssetsByPackageName).</summary>
        public static System.IntPtr NativeFunc_GetAssetsByPackageName => Memory.ModuleBase() + 0x7FCA378;
        public bool GetAssetsByPackageName(FName PackageName, System.IntPtr OutAssetData, bool bIncludeOnlyOnDiskAssets)
        {
            var __pb = new ParamBuffer(26);
            __pb.Set(0x0, PackageName);
            __pb.Set<System.IntPtr>(0x8, OutAssetData);
            __pb.Set<byte>(0x18, (byte)(bIncludeOnlyOnDiskAssets?1:0));
            CallRaw("GetAssetsByPackageName", __pb.Bytes);
            return __pb.Get<byte>(0x19) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC9F28 — hookable via Hooks.InstallAt(NativeFunc_GetAssetsByClass).</summary>
        public static System.IntPtr NativeFunc_GetAssetsByClass => Memory.ModuleBase() + 0x7FC9F28;
        public bool GetAssetsByClass(FName ClassName, System.IntPtr OutAssetData, bool bSearchSubClasses)
        {
            var __pb = new ParamBuffer(26);
            __pb.Set(0x0, ClassName);
            __pb.Set<System.IntPtr>(0x8, OutAssetData);
            __pb.Set<byte>(0x18, (byte)(bSearchSubClasses?1:0));
            CallRaw("GetAssetsByClass", __pb.Bytes);
            return __pb.Get<byte>(0x19) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC9D10 — hookable via Hooks.InstallAt(NativeFunc_GetAssets).</summary>
        public static System.IntPtr NativeFunc_GetAssets => Memory.ModuleBase() + 0x7FC9D10;
        public bool GetAssets(ARFilter Filter, System.IntPtr OutAssetData)
        {
            var __pb = new ParamBuffer(249);
            __pb.Set<System.IntPtr>(0x0, Filter);
            __pb.Set<System.IntPtr>(0xE8, OutAssetData);
            CallRaw("GetAssets", __pb.Bytes);
            return __pb.Get<byte>(0xF8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FC9AD0 — hookable via Hooks.InstallAt(NativeFunc_GetAssetByObjectPath).</summary>
        public static System.IntPtr NativeFunc_GetAssetByObjectPath => Memory.ModuleBase() + 0x7FC9AD0;
        public AssetData GetAssetByObjectPath(FName ObjectPath, bool bIncludeOnlyOnDiskAssets)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set(0x0, ObjectPath);
            __pb.Set<byte>(0x8, (byte)(bIncludeOnlyOnDiskAssets?1:0));
            CallRaw("GetAssetByObjectPath", __pb.Bytes);
            return __pb.Get<AssetData>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x7FC953C — hookable via Hooks.InstallAt(NativeFunc_GetAllCachedPaths).</summary>
        public static System.IntPtr NativeFunc_GetAllCachedPaths => Memory.ModuleBase() + 0x7FC953C;
        public void GetAllCachedPaths(System.IntPtr OutPathList)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, OutPathList);
            CallRaw("GetAllCachedPaths", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FC9918 — hookable via Hooks.InstallAt(NativeFunc_GetAllAssets).</summary>
        public static System.IntPtr NativeFunc_GetAllAssets => Memory.ModuleBase() + 0x7FC9918;
        public bool GetAllAssets(System.IntPtr OutAssetData, bool bIncludeOnlyOnDiskAssets)
        {
            var __pb = new ParamBuffer(18);
            __pb.Set<System.IntPtr>(0x0, OutAssetData);
            __pb.Set<byte>(0x10, (byte)(bIncludeOnlyOnDiskAssets?1:0));
            CallRaw("GetAllAssets", __pb.Bytes);
            return __pb.Get<byte>(0x11) != 0;
        }
    }

}
