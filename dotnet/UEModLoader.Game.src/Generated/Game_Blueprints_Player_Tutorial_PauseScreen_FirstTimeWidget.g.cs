// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/PauseScreen_FirstTimeWidget
using System;

namespace UEModLoader.Game
{
    public class PauseScreen_FirstTimeWidget_C : UserWidget
    {
        public const string UeClassName = "PauseScreen_FirstTimeWidget_C";
        public PauseScreen_FirstTimeWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PauseScreen_FirstTimeWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PauseScreen_FirstTimeWidget_C(p);
        public static PauseScreen_FirstTimeWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PauseScreen_FirstTimeWidget_C(o.Pointer); }
        public static PauseScreen_FirstTimeWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PauseScreen_FirstTimeWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PauseScreen_FirstTimeWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock DescText { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_Divider { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock RichText { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock RichTextDesc { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock RichTextDescMerc { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock RichTextIcons { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock RichTextIconsMerc { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock RichTextMerc { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Spacer Spacer_MinWidth { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new Spacer(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TitleText { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_Desc { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcherMerc { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x2B0); // struct UI_WidgetColors_Struct
        public global::System.IntPtr MercColors => AddrOf(0x4B8); // struct UI_WidgetColorsMercenaries_Struct
        public bool MercActive { get => Native.GetPropBool(Pointer, "MercActive"); set => Native.SetPropBool(Pointer, "MercActive", value); }
        public void SetMercColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercColors", __pb.Bytes);
        }
        public void SetRichTextVisibility(ESlateVisibility Visibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Visibility);
            CallRaw("SetRichTextVisibility", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_PauseScreen_FirstTimeWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PauseScreen_FirstTimeWidget", __pb.Bytes);
        }
    }

}
