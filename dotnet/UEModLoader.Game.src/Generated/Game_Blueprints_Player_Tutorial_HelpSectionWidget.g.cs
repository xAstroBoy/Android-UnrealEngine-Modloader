// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/HelpSectionWidget
using System;

namespace UEModLoader.Game
{
    public class HelpSectionWidget_C : UserWidget
    {
        public const string UeClassName = "HelpSectionWidget_C";
        public HelpSectionWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new HelpSectionWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new HelpSectionWidget_C(p);
        public static HelpSectionWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new HelpSectionWidget_C(o.Pointer); }
        public static HelpSectionWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new HelpSectionWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new HelpSectionWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock DescText { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TitleText { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x258); // struct UI_WidgetColors_Struct
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void Hover()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hover", __pb.Bytes);
        }
        public void Unhover()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhover", __pb.Bytes);
        }
        public void ExecuteUbergraph_HelpSectionWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_HelpSectionWidget", __pb.Bytes);
        }
    }

}
