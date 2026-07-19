// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/PlayerSkeletonCorrectionData_DataAssetClass
using System;

namespace UEModLoader.Game
{
    public class PlayerSkeletonCorrectionData_DataAssetClass_C : PrimaryDataAsset
    {
        public const string UeClassName = "PlayerSkeletonCorrectionData_DataAssetClass_C";
        public PlayerSkeletonCorrectionData_DataAssetClass_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlayerSkeletonCorrectionData_DataAssetClass_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlayerSkeletonCorrectionData_DataAssetClass_C(p);
        public static PlayerSkeletonCorrectionData_DataAssetClass_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayerSkeletonCorrectionData_DataAssetClass_C(o.Pointer); }
        public static PlayerSkeletonCorrectionData_DataAssetClass_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayerSkeletonCorrectionData_DataAssetClass_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayerSkeletonCorrectionData_DataAssetClass_C(a[i].Pointer); return r; }
        public global::System.IntPtr CorrectionData => AddrOf(0x30); // struct PlayerSkeletonCorrectionData
    }

}
