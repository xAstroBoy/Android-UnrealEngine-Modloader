// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualInfoTextWidget
using System;

namespace UEModLoader.Game
{
    public class PlayingManualInfoTextWidget_C : UserWidget
    {
        public const string UeClassName = "PlayingManualInfoTextWidget_C";
        public PlayingManualInfoTextWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualInfoTextWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlayingManualInfoTextWidget_C(p);
        public static PlayingManualInfoTextWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualInfoTextWidget_C(o.Pointer); }
        public static PlayingManualInfoTextWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualInfoTextWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualInfoTextWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Box_BG { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock InfoText { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock InfoTextMerc { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_text { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x268); // struct UI_WidgetColors_Struct
        public bool UseMercColors { get => Native.GetPropBool(Pointer, "UseMercColors"); set => Native.SetPropBool(Pointer, "UseMercColors", value); }
        public global::System.IntPtr MercColors => AddrOf(0x478); // struct UI_WidgetColorsMercenaries_Struct
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualInfoTextWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualInfoTextWidget", __pb.Bytes);
        }
    }

}
