// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Inventory_Panel_10x6
using System;

namespace UEModLoader.Game
{
    public class UI_Inventory_Panel_10x6_C : Actor
    {
        public const string UeClassName = "UI_Inventory_Panel_10x6_C";
        public UI_Inventory_Panel_10x6_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Inventory_Panel_10x6_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Inventory_Panel_10x6_C(p);
        public static UI_Inventory_Panel_10x6_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Inventory_Panel_10x6_C(o.Pointer); }
        public static UI_Inventory_Panel_10x6_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Inventory_Panel_10x6_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Inventory_Panel_10x6_C(a[i].Pointer); return r; }
        public StaticMeshComponent GUI_Grid10x6 { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ContentParent { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
    }

}
