// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_BackButton_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_BackButton_Widget_C : UI_Merchant_Button_Widget_BP_C
    {
        public const string UeClassName = "UI_Merchant_BackButton_Widget_C";
        public UI_Merchant_BackButton_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_BackButton_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_BackButton_Widget_C(p);
        public static UI_Merchant_BackButton_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_BackButton_Widget_C(o.Pointer); }
        public static UI_Merchant_BackButton_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_BackButton_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_BackButton_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_ArrowPoint { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_ArrowShaft { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_Highlight { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_Back { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SlateColor Tint_Highlight => new SlateColor(AddrOf(0x288));
        public SlateColor Text_Highlight => new SlateColor(AddrOf(0x2B0));
        public SlateColor Tint_Unhighlight => new SlateColor(AddrOf(0x2D8));
        public SlateColor Text_Unhighlight => new SlateColor(AddrOf(0x300));
        public global::System.IntPtr Colors => AddrOf(0x328); // struct UI_WidgetColors_Struct
        public global::System.IntPtr MerchantColors => AddrOf(0x530); // struct UI_MerchantColors_Struct
        public void Unhighlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhighlight", __pb.Bytes);
        }
        public void Highlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Highlight", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_BackButton_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_BackButton_Widget", __pb.Bytes);
        }
    }

}
