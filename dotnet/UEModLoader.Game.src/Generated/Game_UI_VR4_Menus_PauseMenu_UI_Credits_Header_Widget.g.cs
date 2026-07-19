// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Credits_Header_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Credits_Header_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Credits_Header_Widget_C";
        public UI_Credits_Header_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Credits_Header_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Credits_Header_Widget_C(p);
        public static UI_Credits_Header_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Credits_Header_Widget_C(o.Pointer); }
        public static UI_Credits_Header_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Credits_Header_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Credits_Header_Widget_C(a[i].Pointer); return r; }
        public Image Black_Fade { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ScreenImage0 { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ScreenImage1 { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ScreenImageFade { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ScrollBox ScrollBox { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new ScrollBox(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_Background { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
