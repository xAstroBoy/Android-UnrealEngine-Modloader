// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Grenade_Seated
using System;

namespace UEModLoader.Game
{
    public class PropHolster_Grenade_Seated_C : PropHolster_Grenade_C
    {
        public const string UeClassName = "PropHolster_Grenade_Seated_C";
        public PropHolster_Grenade_Seated_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropHolster_Grenade_Seated_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropHolster_Grenade_Seated_C(p);
        public static PropHolster_Grenade_Seated_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropHolster_Grenade_Seated_C(o.Pointer); }
        public static PropHolster_Grenade_Seated_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropHolster_Grenade_Seated_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropHolster_Grenade_Seated_C(a[i].Pointer); return r; }
    }

}
