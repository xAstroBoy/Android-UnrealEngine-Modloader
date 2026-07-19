// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/PlayerSkeletonCorrectionData_AssetUserData
using System;

namespace UEModLoader.Game
{
    public class PlayerSkeletonCorrectionData_AssetUserData_C : BlueprintAssetUserData
    {
        public const string UeClassName = "PlayerSkeletonCorrectionData_AssetUserData_C";
        public PlayerSkeletonCorrectionData_AssetUserData_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlayerSkeletonCorrectionData_AssetUserData_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlayerSkeletonCorrectionData_AssetUserData_C(p);
        public static PlayerSkeletonCorrectionData_AssetUserData_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayerSkeletonCorrectionData_AssetUserData_C(o.Pointer); }
        public static PlayerSkeletonCorrectionData_AssetUserData_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayerSkeletonCorrectionData_AssetUserData_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayerSkeletonCorrectionData_AssetUserData_C(a[i].Pointer); return r; }
        public PlayerSkeletonCorrectionData_DataAssetClass_C CorrectionDataAsset { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new PlayerSkeletonCorrectionData_DataAssetClass_C(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PlayerSkeletonCorrectionData_DataAssetClass_C CorrectionDataAssetSoftObj { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new PlayerSkeletonCorrectionData_DataAssetClass_C(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
