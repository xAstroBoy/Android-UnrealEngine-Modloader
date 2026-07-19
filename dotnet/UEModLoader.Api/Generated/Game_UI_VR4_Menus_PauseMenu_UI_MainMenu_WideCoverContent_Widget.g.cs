// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_MainMenu_WideCoverContent_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_MainMenu_WideCoverContent_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_MainMenu_WideCoverContent_Widget_C";
        public UI_MainMenu_WideCoverContent_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_MainMenu_WideCoverContent_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_MainMenu_WideCoverContent_Widget_C(p);
        public static UI_MainMenu_WideCoverContent_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MainMenu_WideCoverContent_Widget_C(o.Pointer); }
        public static UI_MainMenu_WideCoverContent_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MainMenu_WideCoverContent_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MainMenu_WideCoverContent_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public RichTextBlock RichText_WideCoverContent { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public RichTextBlock RichText_WideCoverContent_Lower { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public RichTextBlock RichText_WideCoverContent_Lower_Merc { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public RichTextBlock RichText_WideCoverContent_Merc { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Button_Arrow_Widget_C UI_Button_Arrow_Widget { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new UI_Button_Arrow_Widget_C(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Heading_Centered_Widget_C UI_Heading_Centered_Widget { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new UI_Heading_Centered_Widget_C(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_text { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x278); // struct UI_WidgetColors_Struct
        public System.IntPtr MercColors => AddrOf(0x480); // struct UI_WidgetColorsMercenaries_Struct
        public void SetMercColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercColors", __pb.Bytes);
        }
        public void SetText_Lower(System.IntPtr DescriptionText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, DescriptionText);
            CallRaw("SetText_Lower", __pb.Bytes);
        }
        public void SetText(System.IntPtr DescriptionText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, DescriptionText);
            CallRaw("SetText", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void SetHeadingText(System.IntPtr newText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, newText);
            CallRaw("SetHeadingText", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MainMenu_WideCoverContent_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MainMenu_WideCoverContent_Widget", __pb.Bytes);
        }
    }

}
