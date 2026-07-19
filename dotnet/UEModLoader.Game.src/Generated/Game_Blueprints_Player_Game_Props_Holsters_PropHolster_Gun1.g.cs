// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Gun1
using System;

namespace UEModLoader.Game
{
    public class PropHolster_Gun1_C : Base_PropHolster_C
    {
        public const string UeClassName = "PropHolster_Gun1_C";
        public PropHolster_Gun1_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropHolster_Gun1_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropHolster_Gun1_C(p);
        public static PropHolster_Gun1_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropHolster_Gun1_C(o.Pointer); }
        public static PropHolster_Gun1_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropHolster_Gun1_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropHolster_Gun1_C(a[i].Pointer); return r; }
    }

}
