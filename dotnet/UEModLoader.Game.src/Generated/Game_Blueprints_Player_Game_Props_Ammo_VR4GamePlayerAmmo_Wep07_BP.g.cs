// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Ammo/VR4GamePlayerAmmo_Wep07_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayerAmmo_Wep07_BP_C : VR4GamePlayerAmmo_ShotgunShell_Base_BP_C
    {
        public const string UeClassName = "VR4GamePlayerAmmo_Wep07_BP_C";
        public VR4GamePlayerAmmo_Wep07_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayerAmmo_Wep07_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4GamePlayerAmmo_Wep07_BP_C(p);
        public static VR4GamePlayerAmmo_Wep07_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayerAmmo_Wep07_BP_C(o.Pointer); }
        public static VR4GamePlayerAmmo_Wep07_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayerAmmo_Wep07_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayerAmmo_Wep07_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x770));
        public void GetCurrentAnimMontage(bool held, int reloadAnimIndex, EHandedness Handedness, AnimMontage Montage)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)(held?1:0));
            __pb.Set(0x4, reloadAnimIndex);
            __pb.Set<byte>(0x8, (byte)Handedness);
            __pb.SetObject(0x10, Montage);
            CallRaw("GetCurrentAnimMontage", __pb.Bytes);
        }
        public void OnActiveReloadAnimationIndexChanged(int reloadAnimIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, reloadAnimIndex);
            CallRaw("OnActiveReloadAnimationIndexChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4GamePlayerAmmo_Wep07_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4GamePlayerAmmo_Wep07_BP", __pb.Bytes);
        }
    }

}
