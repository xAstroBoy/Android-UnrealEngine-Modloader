// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Typewriter/WarningConfirmWidget
using System;

namespace UEModLoader.Game
{
    public class WarningConfirmWidget_C : UserWidget
    {
        public const string UeClassName = "WarningConfirmWidget_C";
        public WarningConfirmWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new WarningConfirmWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new WarningConfirmWidget_C(p);
        public static WarningConfirmWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WarningConfirmWidget_C(o.Pointer); }
        public static WarningConfirmWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WarningConfirmWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WarningConfirmWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock DescText { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_Divider { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TitleText { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x260); // struct UI_WidgetColors_Struct
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_WarningConfirmWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_WarningConfirmWidget", __pb.Bytes);
        }
    }

}
