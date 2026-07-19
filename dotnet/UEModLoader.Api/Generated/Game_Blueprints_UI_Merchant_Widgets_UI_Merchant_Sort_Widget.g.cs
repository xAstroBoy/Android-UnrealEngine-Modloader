// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_Sort_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_Sort_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Merchant_Sort_Widget_C";
        public UI_Merchant_Sort_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_Sort_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Merchant_Sort_Widget_C(p);
        public static UI_Merchant_Sort_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_Sort_Widget_C(o.Pointer); }
        public static UI_Merchant_Sort_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_Sort_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_Sort_Widget_C(a[i].Pointer); return r; }
        public Image BGBox { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_2 { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_3 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_4 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_5 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_6 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_7 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
    }

}
