// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Consumable
using System;

namespace UEModLoader.Game
{
    public class PropHolster_Consumable_C : Base_PropHolster_C
    {
        public const string UeClassName = "PropHolster_Consumable_C";
        public PropHolster_Consumable_C(System.IntPtr ptr) : base(ptr) {}
        public static new PropHolster_Consumable_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PropHolster_Consumable_C(p);
        public static PropHolster_Consumable_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropHolster_Consumable_C(o.Pointer); }
        public static PropHolster_Consumable_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropHolster_Consumable_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropHolster_Consumable_C(a[i].Pointer); return r; }
    }

}
