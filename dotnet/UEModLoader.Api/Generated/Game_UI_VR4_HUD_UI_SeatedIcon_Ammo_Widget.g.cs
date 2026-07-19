// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/HUD/UI_SeatedIcon_Ammo_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_SeatedIcon_Ammo_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_SeatedIcon_Ammo_Widget_C";
        public UI_SeatedIcon_Ammo_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_SeatedIcon_Ammo_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_SeatedIcon_Ammo_Widget_C(p);
        public static UI_SeatedIcon_Ammo_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_SeatedIcon_Ammo_Widget_C(o.Pointer); }
        public static UI_SeatedIcon_Ammo_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_SeatedIcon_Ammo_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_SeatedIcon_Ammo_Widget_C(a[i].Pointer); return r; }
        public Image IconImage { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public Image IconImageArrow { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image IconImageHarpoon { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_Icon { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
    }

}
