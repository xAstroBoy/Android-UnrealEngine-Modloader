// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/InventoryScreen_AshleyDisplay_BP
using System;

namespace UEModLoader.Game
{
    public class InventoryScreen_AshleyDisplay_BP_C : InventoryScreen_LeonDisplay_BP_C
    {
        public const string UeClassName = "InventoryScreen_AshleyDisplay_BP_C";
        public InventoryScreen_AshleyDisplay_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new InventoryScreen_AshleyDisplay_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InventoryScreen_AshleyDisplay_BP_C(p);
        public static InventoryScreen_AshleyDisplay_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InventoryScreen_AshleyDisplay_BP_C(o.Pointer); }
        public static InventoryScreen_AshleyDisplay_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InventoryScreen_AshleyDisplay_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InventoryScreen_AshleyDisplay_BP_C(a[i].Pointer); return r; }
        public PointLightComponent PointLight1 { get { var __p = GetAt<global::System.IntPtr>(0xA08); return __p==global::System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0xA08, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
