// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Ammo_WildWest
using System;

namespace UEModLoader.Game
{
    public class PropHolster_Ammo_WildWest_C : Base_PropHolster_C
    {
        public const string UeClassName = "PropHolster_Ammo_WildWest_C";
        public PropHolster_Ammo_WildWest_C(System.IntPtr ptr) : base(ptr) {}
        public static new PropHolster_Ammo_WildWest_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PropHolster_Ammo_WildWest_C(p);
        public static PropHolster_Ammo_WildWest_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropHolster_Ammo_WildWest_C(o.Pointer); }
        public static PropHolster_Ammo_WildWest_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropHolster_Ammo_WildWest_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropHolster_Ammo_WildWest_C(a[i].Pointer); return r; }
    }

}
