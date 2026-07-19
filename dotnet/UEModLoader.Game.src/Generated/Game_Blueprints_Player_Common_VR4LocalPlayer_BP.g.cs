// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Common/VR4LocalPlayer_BP
using System;

namespace UEModLoader.Game
{
    public class VR4LocalPlayer_BP_C : VR4LocalPlayer
    {
        public const string UeClassName = "VR4LocalPlayer_BP_C";
        public VR4LocalPlayer_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4LocalPlayer_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4LocalPlayer_BP_C(p);
        public static VR4LocalPlayer_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4LocalPlayer_BP_C(o.Pointer); }
        public static VR4LocalPlayer_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4LocalPlayer_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4LocalPlayer_BP_C(a[i].Pointer); return r; }
    }

}
