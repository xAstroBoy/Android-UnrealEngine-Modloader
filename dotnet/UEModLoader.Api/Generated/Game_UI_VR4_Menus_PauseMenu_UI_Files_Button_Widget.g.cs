// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Files_Button_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Files_Button_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Files_Button_Widget_C";
        public UI_Files_Button_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Files_Button_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Files_Button_Widget_C(p);
        public static UI_Files_Button_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Files_Button_Widget_C(o.Pointer); }
        public static UI_Files_Button_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Files_Button_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Files_Button_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image Image_BG { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Highlight { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Line { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Button { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x258); // struct UI_WidgetColors_Struct
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
        public void SetButtonText(System.IntPtr newText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, newText);
            CallRaw("SetButtonText", __pb.Bytes);
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
        public void ExecuteUbergraph_UI_Files_Button_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Files_Button_Widget", __pb.Bytes);
        }
    }

}
