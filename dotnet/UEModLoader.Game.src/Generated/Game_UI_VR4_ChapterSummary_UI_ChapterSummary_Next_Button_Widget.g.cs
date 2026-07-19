// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/ChapterSummary/UI_ChapterSummary_Next_Button_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_ChapterSummary_Next_Button_Widget_C : UI_Button_Widget_BP_C
    {
        public const string UeClassName = "UI_ChapterSummary_Next_Button_Widget_C";
        public UI_ChapterSummary_Next_Button_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_ChapterSummary_Next_Button_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_ChapterSummary_Next_Button_Widget_C(p);
        public static UI_ChapterSummary_Next_Button_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_ChapterSummary_Next_Button_Widget_C(o.Pointer); }
        public static UI_ChapterSummary_Next_Button_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_ChapterSummary_Next_Button_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_ChapterSummary_Next_Button_Widget_C(a[i].Pointer); return r; }
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock CommandText { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay InnerBox { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay OuterBox { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_Highlight { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Swatch { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SlateColor UnhighlightTextColor => new SlateColor(AddrOf(0x288));
        public SlateColor HighlightTextColor => new SlateColor(AddrOf(0x2B0));
        public global::System.IntPtr Colors => AddrOf(0x2D8); // struct UI_WidgetColors_Struct
        public global::System.IntPtr MercColors => AddrOf(0x4E0); // struct UI_WidgetColorsMercenaries_Struct
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
        public void Disable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Disable", __pb.Bytes);
        }
        public void enable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("enable", __pb.Bytes);
        }
        public void Unhighlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhighlight", __pb.Bytes);
        }
        public void Highlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Highlight", __pb.Bytes);
        }
        public void SetAlpha(float alpha)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, alpha);
            CallRaw("SetAlpha", __pb.Bytes);
        }
        public global::System.IntPtr Get_CommandText_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(40);
            CallRaw("Get_CommandText_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
    }

}
