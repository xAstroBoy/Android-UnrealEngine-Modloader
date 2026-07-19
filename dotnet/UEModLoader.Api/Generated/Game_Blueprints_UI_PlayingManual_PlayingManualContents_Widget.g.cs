// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualContents_Widget
using System;

namespace UEModLoader.Game
{
    public class PlayingManualContents_Widget_C : UserWidget
    {
        public const string UeClassName = "PlayingManualContents_Widget_C";
        public PlayingManualContents_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualContents_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PlayingManualContents_Widget_C(p);
        public static PlayingManualContents_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualContents_Widget_C(o.Pointer); }
        public static PlayingManualContents_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualContents_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualContents_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget_2 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget_3 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget_4 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget_5 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget_6 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget_7 { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget_8 { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget_9 { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContentsButtonWidget_C PlayingManualContentsButtonWidget_10 { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new PlayingManualContentsButtonWidget_C(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Heading_Centered_Widget_C UI_Heading_Centered_Widget { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new UI_Heading_Centered_Widget_C(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x298); // struct UI_WidgetColors_Struct
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
        public void SetLowerAreaVisibility(ESlateVisibility Visibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Visibility);
            CallRaw("SetLowerAreaVisibility", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void SetHeadingText(System.IntPtr newText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, newText);
            CallRaw("SetHeadingText", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualContents_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualContents_Widget", __pb.Bytes);
        }
    }

}
