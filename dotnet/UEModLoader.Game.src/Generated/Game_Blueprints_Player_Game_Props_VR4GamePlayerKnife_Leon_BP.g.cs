// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/VR4GamePlayerKnife_Leon_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayerKnife_Leon_BP_C : VR4GamePlayerKnife_BP_C
    {
        public const string UeClassName = "VR4GamePlayerKnife_Leon_BP_C";
        public VR4GamePlayerKnife_Leon_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayerKnife_Leon_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4GamePlayerKnife_Leon_BP_C(p);
        public static VR4GamePlayerKnife_Leon_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayerKnife_Leon_BP_C(o.Pointer); }
        public static VR4GamePlayerKnife_Leon_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayerKnife_Leon_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayerKnife_Leon_BP_C(a[i].Pointer); return r; }
    }

}
