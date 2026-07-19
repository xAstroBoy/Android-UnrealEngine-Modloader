// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Button_Arrow_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Button_Arrow_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Button_Arrow_Widget_C";
        public UI_Button_Arrow_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Button_Arrow_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Button_Arrow_Widget_C(p);
        public static UI_Button_Arrow_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Button_Arrow_Widget_C(o.Pointer); }
        public static UI_Button_Arrow_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Button_Arrow_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Button_Arrow_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation Flash { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow_InnerGlow { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Highlight { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x260); // struct UI_WidgetColors_Struct
        public System.IntPtr MercColors => AddrOf(0x468); // struct UI_WidgetColorsMercenaries_Struct
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
        public void Hover_Button()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hover_Button", __pb.Bytes);
        }
        public void Unhover_Button()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhover_Button", __pb.Bytes);
        }
        public void Click_Button()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Click_Button", __pb.Bytes);
        }
        public void Disable_Button()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Disable_Button", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Button_Arrow_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Button_Arrow_Widget", __pb.Bytes);
        }
    }

}
