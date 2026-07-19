// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/PlayingManual_IntroWidget
using System;

namespace UEModLoader.Game
{
    public class PlayingManual_IntroWidget_C : UserWidget
    {
        public const string UeClassName = "PlayingManual_IntroWidget_C";
        public PlayingManual_IntroWidget_C(System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManual_IntroWidget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PlayingManual_IntroWidget_C(p);
        public static PlayingManual_IntroWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManual_IntroWidget_C(o.Pointer); }
        public static PlayingManual_IntroWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManual_IntroWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManual_IntroWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public RichTextBlock RichText { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x250); // struct UI_WidgetColors_Struct
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManual_IntroWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManual_IntroWidget", __pb.Bytes);
        }
    }

}
