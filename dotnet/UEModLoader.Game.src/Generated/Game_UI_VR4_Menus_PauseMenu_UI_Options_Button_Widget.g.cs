// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Options_Button_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Options_Button_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Options_Button_Widget_C";
        public UI_Options_Button_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Options_Button_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Options_Button_Widget_C(p);
        public static UI_Options_Button_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Options_Button_Widget_C(o.Pointer); }
        public static UI_Options_Button_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Options_Button_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Options_Button_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Highlight { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_Button { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool Flag_Hovered { get => Native.GetPropBool(Pointer, "Flag_Hovered"); set => Native.SetPropBool(Pointer, "Flag_Hovered", value); }
        public global::System.IntPtr Colors => AddrOf(0x260); // struct UI_WidgetColors_Struct
        public global::System.IntPtr MercColors => AddrOf(0x468); // struct UI_WidgetColorsMercenaries_Struct
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
        public void EnableButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EnableButton", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void DisableButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableButton", __pb.Bytes);
        }
        public void UnhoverButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverButton", __pb.Bytes);
        }
        public void HoverButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverButton", __pb.Bytes);
        }
        public void SetButtonText(global::System.IntPtr newText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, newText);
            CallRaw("SetButtonText", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Options_Button_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Options_Button_Widget", __pb.Bytes);
        }
    }

}
