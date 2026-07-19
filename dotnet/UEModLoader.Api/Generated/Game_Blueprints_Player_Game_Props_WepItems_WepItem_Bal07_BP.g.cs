// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/WepItems/WepItem_Bal07_BP
using System;

namespace UEModLoader.Game
{
    public class WepItem_Bal07_BP_C : WepItem_Base_BP_C
    {
        public const string UeClassName = "WepItem_Bal07_BP_C";
        public WepItem_Bal07_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new WepItem_Bal07_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WepItem_Bal07_BP_C(p);
        public static WepItem_Bal07_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WepItem_Bal07_BP_C(o.Pointer); }
        public static WepItem_Bal07_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WepItem_Bal07_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WepItem_Bal07_BP_C(a[i].Pointer); return r; }
    }

}
