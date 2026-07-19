// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualEntryButtonWidget
using System;

namespace UEModLoader.Game
{
    public class PlayingManualEntryButtonWidget_C : UserWidget
    {
        public const string UeClassName = "PlayingManualEntryButtonWidget_C";
        public PlayingManualEntryButtonWidget_C(System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualEntryButtonWidget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PlayingManualEntryButtonWidget_C(p);
        public static PlayingManualEntryButtonWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualEntryButtonWidget_C(o.Pointer); }
        public static PlayingManualEntryButtonWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualEntryButtonWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualEntryButtonWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Highlight { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Button { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public bool Flag_Hovered { get => Native.GetPropBool(Pointer, "Flag_Hovered"); set => Native.SetPropBool(Pointer, "Flag_Hovered", value); }
        public System.IntPtr Colors => AddrOf(0x260); // struct UI_WidgetColors_Struct
        public bool Selected { get => Native.GetPropBool(Pointer, "Selected"); set => Native.SetPropBool(Pointer, "Selected", value); }
        public System.IntPtr MercColors => AddrOf(0x470); // struct UI_WidgetColorsMercenaries_Struct
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
        public void SetButtonText(System.IntPtr newText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, newText);
            CallRaw("SetButtonText", __pb.Bytes);
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
        public void DisableButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableButton", __pb.Bytes);
        }
        public void EnableButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EnableButton", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualEntryButtonWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualEntryButtonWidget", __pb.Bytes);
        }
    }

}
