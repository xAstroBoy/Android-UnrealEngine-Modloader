// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Frontend/Buttons/Button_MainWidget
using System;

namespace UEModLoader.Game
{
    public class Button_MainWidget_C : UserWidget
    {
        public const string UeClassName = "Button_MainWidget_C";
        public Button_MainWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Button_MainWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Button_MainWidget_C(p);
        public static Button_MainWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Button_MainWidget_C(o.Pointer); }
        public static Button_MainWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Button_MainWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Button_MainWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image background { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock DisplayText { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Highlight { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_arrow_01 { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_arrow_02 { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_arrow_03 { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_arrow_04 { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image InnerGlow { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Main { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_text { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x290); // struct UI_WidgetColors_Struct
        public void SetMercColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercColors", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void Hover()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hover", __pb.Bytes);
        }
        public void Unhover()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhover", __pb.Bytes);
        }
        public void Disable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Disable", __pb.Bytes);
        }
        public void Clicked()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Clicked", __pb.Bytes);
        }
        public void ExecuteUbergraph_Button_MainWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Button_MainWidget", __pb.Bytes);
        }
    }

}
