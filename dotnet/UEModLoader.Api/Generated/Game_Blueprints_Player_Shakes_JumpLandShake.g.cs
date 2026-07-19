// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Shakes/JumpLandShake
using System;

namespace UEModLoader.Game
{
    public class JumpLandShake_C : CameraShake
    {
        public const string UeClassName = "JumpLandShake_C";
        public JumpLandShake_C(System.IntPtr ptr) : base(ptr) {}
        public static new JumpLandShake_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new JumpLandShake_C(p);
        public static JumpLandShake_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new JumpLandShake_C(o.Pointer); }
        public static JumpLandShake_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new JumpLandShake_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new JumpLandShake_C(a[i].Pointer); return r; }
    }

}
