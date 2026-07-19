// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Button_Discard_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Button_Discard_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Button_Discard_Widget_C";
        public UI_Button_Discard_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Button_Discard_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Button_Discard_Widget_C(p);
        public static UI_Button_Discard_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Button_Discard_Widget_C(o.Pointer); }
        public static UI_Button_Discard_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Button_Discard_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Button_Discard_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public ProgressBar Fill { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new ProgressBar(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Icon { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Icon_Flash { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_BG { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_BGFlash { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_BGHighlight { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SlateColor Tint_Selected_Hover => new SlateColor(AddrOf(0x268));
        public SlateColor Tint_Unselected_Unhover_BG => new SlateColor(AddrOf(0x290));
        public SlateColor Tint_Selected_Unhover => new SlateColor(AddrOf(0x2B8));
        public SlateColor Tint_Unselected_Hover_BG => new SlateColor(AddrOf(0x2E0));
        public SlateColor Tint_Selected_Unhover_BG => new SlateColor(AddrOf(0x308));
        public SlateColor Tint_Unselected_Hover => new SlateColor(AddrOf(0x330));
        public SlateColor Tint_Unselected_Unhover => new SlateColor(AddrOf(0x358));
        public bool IsSelected { get => Native.GetPropBool(Pointer, "IsSelected"); set => Native.SetPropBool(Pointer, "IsSelected", value); }
        public SlateColor Tint_Selected_Hover_BG => new SlateColor(AddrOf(0x388));
        public SlateColor Tint_Selected_Flash => new SlateColor(AddrOf(0x3B0));
        public SlateColor Tint_BrightFlash => new SlateColor(AddrOf(0x3D8));
        public SlateColor Tint_PulseSelected => new SlateColor(AddrOf(0x400));
        public SlateColor Tint_PulseUnselected => new SlateColor(AddrOf(0x428));
        public SlateColor Tint_PulseSelectedOff => new SlateColor(AddrOf(0x450));
        public SlateColor Tint_PulseUnselectedOff => new SlateColor(AddrOf(0x478));
        public global::System.IntPtr Colors => AddrOf(0x4A0); // struct UI_WidgetColors_Struct
        public void SetWidgetSelectedState(bool _IsSelected)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(_IsSelected?1:0));
            CallRaw("SetWidgetSelectedState", __pb.Bytes);
        }
        public void GetWidgetSelectedState(bool IsSelected)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsSelected?1:0));
            CallRaw("GetWidgetSelectedState", __pb.Bytes);
        }
        public void FlashSelection()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlashSelection", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void SetBGFlashOpacity(float Opacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Opacity);
            CallRaw("SetBGFlashOpacity", __pb.Bytes);
        }
        public void Hover_Tab()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hover_Tab", __pb.Bytes);
        }
        public void SetFill(float FillPercent)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, FillPercent);
            CallRaw("SetFill", __pb.Bytes);
        }
        public void SetBGGlowOpacity(float Opacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Opacity);
            CallRaw("SetBGGlowOpacity", __pb.Bytes);
        }
        public void Unhover_Tab()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhover_Tab", __pb.Bytes);
        }
        public void ShowIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowIcon", __pb.Bytes);
        }
        public void HideIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideIcon", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Button_Discard_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Button_Discard_Widget", __pb.Bytes);
        }
    }

}
