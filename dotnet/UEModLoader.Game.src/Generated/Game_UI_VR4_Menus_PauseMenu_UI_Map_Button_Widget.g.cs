// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Map_Button_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Map_Button_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Map_Button_Widget_C";
        public UI_Map_Button_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Map_Button_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Map_Button_Widget_C(p);
        public static UI_Map_Button_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Map_Button_Widget_C(o.Pointer); }
        public static UI_Map_Button_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Map_Button_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Map_Button_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation Flash { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Highlight { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image InnerHighlight { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextBlock_Label { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Toggle_BG { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Toggle_Fill { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr LabelText => AddrOf(0x278); // 
        public bool IsSelected { get => Native.GetPropBool(Pointer, "IsSelected"); set => Native.SetPropBool(Pointer, "IsSelected", value); }
        public bool IsDisabled { get => Native.GetPropBool(Pointer, "IsDisabled"); set => Native.SetPropBool(Pointer, "IsDisabled", value); }
        public global::System.IntPtr Colors => AddrOf(0x298); // struct UI_WidgetColors_Struct
        public global::System.IntPtr MercColors => AddrOf(0x4A0); // struct UI_WidgetColorsMercenaries_Struct
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
        public global::System.IntPtr GetText_0()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetText_0", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        public void SetSelected(bool IsSelected)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsSelected?1:0));
            CallRaw("SetSelected", __pb.Bytes);
        }
        public void HoverButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverButton", __pb.Bytes);
        }
        public void UnhoverButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverButton", __pb.Bytes);
        }
        public void SetButtonColors(global::System.IntPtr ForegroundColor, global::System.IntPtr BackgroundColor)
        {
            var __pb = new ParamBuffer(80);
            __pb.Set<global::System.IntPtr>(0x0, ForegroundColor);
            __pb.Set<global::System.IntPtr>(0x28, BackgroundColor);
            CallRaw("SetButtonColors", __pb.Bytes);
        }
        public void OnInitialized()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnInitialized", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Map_Button_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Map_Button_Widget", __pb.Bytes);
        }
    }

}
