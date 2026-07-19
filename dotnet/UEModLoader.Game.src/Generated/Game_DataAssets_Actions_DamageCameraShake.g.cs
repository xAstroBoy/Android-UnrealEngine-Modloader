// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/DataAssets/Actions/DamageCameraShake
using System;

namespace UEModLoader.Game
{
    public class DamageCameraShake_C : CameraShake
    {
        public const string UeClassName = "DamageCameraShake_C";
        public DamageCameraShake_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new DamageCameraShake_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DamageCameraShake_C(p);
        public static DamageCameraShake_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DamageCameraShake_C(o.Pointer); }
        public static DamageCameraShake_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DamageCameraShake_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DamageCameraShake_C(a[i].Pointer); return r; }
    }

}
