// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Heading_Centered_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Heading_Centered_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Heading_Centered_Widget_C";
        public UI_Heading_Centered_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Heading_Centered_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Heading_Centered_Widget_C(p);
        public static UI_Heading_Centered_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Heading_Centered_Widget_C(o.Pointer); }
        public static UI_Heading_Centered_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Heading_Centered_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Heading_Centered_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image Image_BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_Heading { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x248); // struct UI_WidgetColors_Struct
        public global::System.IntPtr MercColors => AddrOf(0x450); // struct UI_WidgetColorsMercenaries_Struct
        public bool UseMercColors { get => Native.GetPropBool(Pointer, "UseMercColors"); set => Native.SetPropBool(Pointer, "UseMercColors", value); }
        public void Set_LabelText(global::System.IntPtr NewLabel)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, NewLabel);
            CallRaw("Set_LabelText", __pb.Bytes);
        }
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
        public void SetColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetColors", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Heading_Centered_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Heading_Centered_Widget", __pb.Bytes);
        }
    }

}
