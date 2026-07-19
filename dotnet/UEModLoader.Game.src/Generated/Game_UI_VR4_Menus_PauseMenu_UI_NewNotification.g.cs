// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_NewNotification
using System;

namespace UEModLoader.Game
{
    public class UI_NewNotification_C : UserWidget
    {
        public const string UeClassName = "UI_NewNotification_C";
        public UI_NewNotification_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_NewNotification_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_NewNotification_C(p);
        public static UI_NewNotification_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_NewNotification_C(o.Pointer); }
        public static UI_NewNotification_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_NewNotification_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_NewNotification_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation Pulse { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient01 { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient02 { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient03 { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient04 { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient05 { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient06 { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient07 { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient08 { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient09 { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient10 { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient11 { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient12 { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock newText { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock NewTextBacking { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_NewIndicator { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VerticalBox VerticalBox_Stripes { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void ChangeColors(global::System.IntPtr IconColor, global::System.IntPtr IconPulseColor, global::System.IntPtr BackgroundColor)
        {
            var __pb = new ParamBuffer(120);
            __pb.Set<global::System.IntPtr>(0x0, IconColor);
            __pb.Set<global::System.IntPtr>(0x28, IconPulseColor);
            __pb.Set<global::System.IntPtr>(0x50, BackgroundColor);
            CallRaw("ChangeColors", __pb.Bytes);
        }
        public void HideStripes()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideStripes", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_NewNotification(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_NewNotification", __pb.Bytes);
        }
    }

}
