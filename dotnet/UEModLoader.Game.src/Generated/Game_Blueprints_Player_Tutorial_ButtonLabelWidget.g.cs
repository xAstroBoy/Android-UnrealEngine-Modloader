// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/ButtonLabelWidget
using System;

namespace UEModLoader.Game
{
    public class ButtonLabelWidget_C : UserWidget
    {
        public const string UeClassName = "ButtonLabelWidget_C";
        public ButtonLabelWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new ButtonLabelWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ButtonLabelWidget_C(p);
        public static ButtonLabelWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ButtonLabelWidget_C(o.Pointer); }
        public static ButtonLabelWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ButtonLabelWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ButtonLabelWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Border Border_Brush { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Border(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ButtonLabel { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ButtonLabelAlt { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock HeaderText { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_BG { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_MidLine { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_OutlineBottom { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_OutlineBox { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_OutlineLeft { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_OutlineRight { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_OutlineTop { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay RootOverlay { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay SelectionParent { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher TextSwitcher { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextX { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x2B0); // struct UI_WidgetColors_Struct
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void SetButtonLabel(global::System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            CallRaw("SetButtonLabel", __pb.Bytes);
        }
        public void Hovered()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hovered", __pb.Bytes);
        }
        public void Unhovered()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhovered", __pb.Bytes);
        }
        public void Clicked()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Clicked", __pb.Bytes);
        }
        public void ExecuteUbergraph_ButtonLabelWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ButtonLabelWidget", __pb.Bytes);
        }
    }

}
