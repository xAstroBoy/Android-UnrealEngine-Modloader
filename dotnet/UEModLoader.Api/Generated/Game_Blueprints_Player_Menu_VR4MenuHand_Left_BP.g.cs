// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Menu/VR4MenuHand_Left_BP
using System;

namespace UEModLoader.Game
{
    public class VR4MenuHand_Left_BP_C : VR4MenuHand_Base_BP_C
    {
        public const string UeClassName = "VR4MenuHand_Left_BP_C";
        public VR4MenuHand_Left_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4MenuHand_Left_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4MenuHand_Left_BP_C(p);
        public static VR4MenuHand_Left_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4MenuHand_Left_BP_C(o.Pointer); }
        public static VR4MenuHand_Left_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4MenuHand_Left_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4MenuHand_Left_BP_C(a[i].Pointer); return r; }
    }

}
