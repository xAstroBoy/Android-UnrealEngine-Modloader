// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/HUD/UI_SeatedIcon_Handgun_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_SeatedIcon_Handgun_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_SeatedIcon_Handgun_Widget_C";
        public UI_SeatedIcon_Handgun_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_SeatedIcon_Handgun_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_SeatedIcon_Handgun_Widget_C(p);
        public static UI_SeatedIcon_Handgun_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_SeatedIcon_Handgun_Widget_C(o.Pointer); }
        public static UI_SeatedIcon_Handgun_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_SeatedIcon_Handgun_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_SeatedIcon_Handgun_Widget_C(a[i].Pointer); return r; }
        public Image IconImage { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
