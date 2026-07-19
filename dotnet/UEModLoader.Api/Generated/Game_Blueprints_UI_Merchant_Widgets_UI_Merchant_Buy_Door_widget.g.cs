// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_Buy_Door_widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_Buy_Door_widget_C : UserWidget
    {
        public const string UeClassName = "UI_Merchant_Buy_Door_widget_C";
        public UI_Merchant_Buy_Door_widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_Buy_Door_widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Merchant_Buy_Door_widget_C(p);
        public static UI_Merchant_Buy_Door_widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_Buy_Door_widget_C(o.Pointer); }
        public static UI_Merchant_Buy_Door_widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_Buy_Door_widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_Buy_Door_widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG_Image { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox Box_Available { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox Box_Unavailable { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_2 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_3 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_4 { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Preview { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Amount { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x288); // struct UI_WidgetColors_Struct
        public System.IntPtr MerchantColors => AddrOf(0x490); // struct UI_MerchantColors_Struct
        public void SetAvailability(bool IsAvailable, int Quantity, bool Hidden)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<byte>(0x0, (byte)(IsAvailable?1:0));
            __pb.Set(0x4, Quantity);
            __pb.Set<byte>(0x8, (byte)(Hidden?1:0));
            CallRaw("SetAvailability", __pb.Bytes);
        }
        public void SetPreviewImage(Texture Image)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Image);
            CallRaw("SetPreviewImage", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_Buy_Door_widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_Buy_Door_widget", __pb.Bytes);
        }
    }

}
