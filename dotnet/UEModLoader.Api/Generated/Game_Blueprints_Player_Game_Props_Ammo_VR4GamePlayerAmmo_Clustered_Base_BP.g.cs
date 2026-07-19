// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Ammo/VR4GamePlayerAmmo_Clustered_Base_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayerAmmo_Clustered_Base_BP_C : VR4GamePlayerAmmo_Base_BP_C
    {
        public const string UeClassName = "VR4GamePlayerAmmo_Clustered_Base_BP_C";
        public VR4GamePlayerAmmo_Clustered_Base_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayerAmmo_Clustered_Base_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4GamePlayerAmmo_Clustered_Base_BP_C(p);
        public static VR4GamePlayerAmmo_Clustered_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayerAmmo_Clustered_Base_BP_C(o.Pointer); }
        public static VR4GamePlayerAmmo_Clustered_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayerAmmo_Clustered_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayerAmmo_Clustered_Base_BP_C(a[i].Pointer); return r; }
        public void GetClusterCount(bool Visible, bool holstered, bool pouchOpen, bool AmmoAvailable, bool loadingAidSpent, int reserves, int gunCapacity, int loadedAmmo, int totalAmmo, int Count)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            __pb.Set<byte>(0x1, (byte)(holstered?1:0));
            __pb.Set<byte>(0x2, (byte)(pouchOpen?1:0));
            __pb.Set<byte>(0x3, (byte)(AmmoAvailable?1:0));
            __pb.Set<byte>(0x4, (byte)(loadingAidSpent?1:0));
            __pb.Set(0x8, reserves);
            __pb.Set(0xC, gunCapacity);
            __pb.Set(0x10, loadedAmmo);
            __pb.Set(0x14, totalAmmo);
            __pb.Set(0x18, Count);
            CallRaw("GetClusterCount", __pb.Bytes);
        }
    }

}
