// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AssetTags
using System;

namespace UEModLoader.Game
{
    public enum ECollectionScriptingShareType
    {
        Local = 0,
        Private = 1,
        Shared = 2,
    }

    public class AssetTagsSubsystem : EngineSubsystem
    {
        public const string UeClassName = "AssetTagsSubsystem";
        public AssetTagsSubsystem(global::System.IntPtr ptr) : base(ptr) {}
        public static new AssetTagsSubsystem FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AssetTagsSubsystem(p);
        public static AssetTagsSubsystem FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AssetTagsSubsystem(o.Pointer); }
        public static AssetTagsSubsystem[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AssetTagsSubsystem[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AssetTagsSubsystem(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5C29AEC — hookable via Hooks.InstallAt(NativeFunc_GetCollectionsContainingAssetPtr).</summary>
        public static global::System.IntPtr NativeFunc_GetCollectionsContainingAssetPtr => Memory.ModuleBase() + 0x5C29AEC;
        public global::System.IntPtr GetCollectionsContainingAssetPtr(Object AssetPtr)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, AssetPtr);
            CallRaw("GetCollectionsContainingAssetPtr", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5C29BE4 — hookable via Hooks.InstallAt(NativeFunc_GetCollectionsContainingAssetData).</summary>
        public static global::System.IntPtr NativeFunc_GetCollectionsContainingAssetData => Memory.ModuleBase() + 0x5C29BE4;
        public global::System.IntPtr GetCollectionsContainingAssetData(global::System.IntPtr AssetData)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<global::System.IntPtr>(0x0, AssetData);
            CallRaw("GetCollectionsContainingAssetData", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x50);
        }
        /// <summary>[Native] thunk RVA 0x5C29D5C — hookable via Hooks.InstallAt(NativeFunc_GetCollectionsContainingAsset).</summary>
        public static global::System.IntPtr NativeFunc_GetCollectionsContainingAsset => Memory.ModuleBase() + 0x5C29D5C;
        public global::System.IntPtr GetCollectionsContainingAsset(FName AssetPathName)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, AssetPathName);
            CallRaw("GetCollectionsContainingAsset", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5C2A07C — hookable via Hooks.InstallAt(NativeFunc_GetCollections).</summary>
        public static global::System.IntPtr NativeFunc_GetCollections => Memory.ModuleBase() + 0x5C2A07C;
        public global::System.IntPtr GetCollections()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetCollections", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C29E54 — hookable via Hooks.InstallAt(NativeFunc_GetAssetsInCollection).</summary>
        public static global::System.IntPtr NativeFunc_GetAssetsInCollection => Memory.ModuleBase() + 0x5C29E54;
        public global::System.IntPtr GetAssetsInCollection(FName Name)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Name);
            CallRaw("GetAssetsInCollection", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5C2A12C — hookable via Hooks.InstallAt(NativeFunc_CollectionExists).</summary>
        public static global::System.IntPtr NativeFunc_CollectionExists => Memory.ModuleBase() + 0x5C2A12C;
        public bool CollectionExists(FName Name)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, Name);
            CallRaw("CollectionExists", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
    }

}
