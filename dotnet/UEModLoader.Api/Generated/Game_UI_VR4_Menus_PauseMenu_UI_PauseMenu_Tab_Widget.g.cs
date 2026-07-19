// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Tab_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Tab_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_PauseMenu_Tab_Widget_C";
        public UI_PauseMenu_Tab_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Tab_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_PauseMenu_Tab_Widget_C(p);
        public static UI_PauseMenu_Tab_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Tab_Widget_C(o.Pointer); }
        public static UI_PauseMenu_Tab_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Tab_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Tab_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image Image_BG_Narrow { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BG_Wide { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BGFlash_Narrow { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BGFlash_Wide { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BGHighlight_Narrow { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BGHighlight_Wide { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Icon { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_IconHighlight { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Overlay_NewIndicator { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_NewNotification_C UI_NewNotification { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new UI_NewNotification_C(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateColor Tint_Selected_Hover => new SlateColor(AddrOf(0x288));
        public SlateColor Tint_Unselected_Unhover_BG => new SlateColor(AddrOf(0x2B0));
        public SlateColor Tint_Selected_Unhover => new SlateColor(AddrOf(0x2D8));
        public SlateColor Tint_Unselected_Hover_BG => new SlateColor(AddrOf(0x300));
        public SlateColor Tint_Selected_Unhover_BG => new SlateColor(AddrOf(0x328));
        public SlateColor Tint_Unselected_Hover => new SlateColor(AddrOf(0x350));
        public SlateColor Tint_Unselected_Unhover => new SlateColor(AddrOf(0x378));
        public bool IsSelected { get => Native.GetPropBool(Pointer, "IsSelected"); set => Native.SetPropBool(Pointer, "IsSelected", value); }
        public SlateColor Tint_Selected_Hover_BG => new SlateColor(AddrOf(0x3A8));
        public SlateColor Tint_Selected_Flash => new SlateColor(AddrOf(0x3D0));
        public SlateColor Tint_BrightFlash => new SlateColor(AddrOf(0x3F8));
        public SlateColor Tint_PulseSelected => new SlateColor(AddrOf(0x420));
        public SlateColor Tint_PulseUnselected => new SlateColor(AddrOf(0x448));
        public SlateColor Tint_PulseSelectedOff => new SlateColor(AddrOf(0x470));
        public SlateColor Tint_PulseUnselectedOff => new SlateColor(AddrOf(0x498));
        public System.IntPtr MercenariesColors => AddrOf(0x4C0); // struct UI_WidgetColorsMercenaries_Struct
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
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
        public void SetIcon(Texture2D NewIcon, Texture2D NewIconHighlight)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, NewIcon);
            __pb.SetObject(0x8, NewIconHighlight);
            CallRaw("SetIcon", __pb.Bytes);
        }
        public void Hover_Tab()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hover_Tab", __pb.Bytes);
        }
        public void Unhover_Tab()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhover_Tab", __pb.Bytes);
        }
        public void SetIconOpacity(float Opacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Opacity);
            CallRaw("SetIconOpacity", __pb.Bytes);
        }
        public void SetBGGlowOpacity(float Opacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Opacity);
            CallRaw("SetBGGlowOpacity", __pb.Bytes);
        }
        public void SetIconHighlightOpacity(float Opacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Opacity);
            CallRaw("SetIconHighlightOpacity", __pb.Bytes);
        }
        public void ChangeColors(SlateColor IconColor, SlateColor HighlightColor, SlateColor BackgroundColor)
        {
            var __pb = new ParamBuffer(120);
            __pb.Set<System.IntPtr>(0x0, IconColor);
            __pb.Set<System.IntPtr>(0x28, HighlightColor);
            __pb.Set<System.IntPtr>(0x50, BackgroundColor);
            CallRaw("ChangeColors", __pb.Bytes);
        }
        public void SetWidth(bool IsNarrow)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsNarrow?1:0));
            CallRaw("SetWidth", __pb.Bytes);
        }
        public void SetBGFlashOpacity(float Opacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Opacity);
            CallRaw("SetBGFlashOpacity", __pb.Bytes);
        }
        public void FlashSelection()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlashSelection", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Tab_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Tab_Widget", __pb.Bytes);
        }
    }

}
