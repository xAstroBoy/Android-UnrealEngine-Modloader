// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Bio4/VR4Bio4PlayerAnimInstance_AnimBP
using System;

namespace UEModLoader.Game
{
    public class VR4Bio4PlayerAnimInstance_AnimBP_C : VR4Player_FirstPerson_Game_AnimBP_C
    {
        public const string UeClassName = "VR4Bio4PlayerAnimInstance_AnimBP_C";
        public VR4Bio4PlayerAnimInstance_AnimBP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4Bio4PlayerAnimInstance_AnimBP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4Bio4PlayerAnimInstance_AnimBP_C(p);
        public static VR4Bio4PlayerAnimInstance_AnimBP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4Bio4PlayerAnimInstance_AnimBP_C(o.Pointer); }
        public static VR4Bio4PlayerAnimInstance_AnimBP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4Bio4PlayerAnimInstance_AnimBP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4Bio4PlayerAnimInstance_AnimBP_C(a[i].Pointer); return r; }
    }

}
