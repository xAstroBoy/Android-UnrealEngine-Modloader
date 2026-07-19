// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_SortEntryButton_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_SortEntryButton_Widget_C : UI_Merchant_Button_Widget_BP_C
    {
        public const string UeClassName = "UI_Merchant_SortEntryButton_Widget_C";
        public UI_Merchant_SortEntryButton_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_SortEntryButton_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Merchant_SortEntryButton_Widget_C(p);
        public static UI_Merchant_SortEntryButton_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_SortEntryButton_Widget_C(o.Pointer); }
        public static UI_Merchant_SortEntryButton_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_SortEntryButton_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_SortEntryButton_Widget_C(a[i].Pointer); return r; }
        public WidgetAnimation Blink { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image background { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG_Highlight { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image NewItemPip { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Name { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Underline { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Price => AddrOf(0x280); // 
        public System.IntPtr Name => AddrOf(0x298); // 
        public VR4MerchantBuyItem Item => new VR4MerchantBuyItem(AddrOf(0x2B0));
        public System.IntPtr MerchantColors => AddrOf(0x6B0); // struct UI_MerchantColors_Struct
        public bool IsAvailable { get => Native.GetPropBool(Pointer, "IsAvailable"); set => Native.SetPropBool(Pointer, "IsAvailable", value); }
        public bool IsAffordable { get => Native.GetPropBool(Pointer, "IsAffordable"); set => Native.SetPropBool(Pointer, "IsAffordable", value); }
        public void Disable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Disable", __pb.Bytes);
        }
        public void enable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("enable", __pb.Bytes);
        }
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
        public void test()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("test", __pb.Bytes);
        }
    }

}
