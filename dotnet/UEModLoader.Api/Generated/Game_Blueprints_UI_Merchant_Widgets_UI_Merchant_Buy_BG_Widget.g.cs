// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_Buy_BG_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_Buy_BG_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Merchant_Buy_BG_Widget_C";
        public UI_Merchant_Buy_BG_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_Buy_BG_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Merchant_Buy_BG_Widget_C(p);
        public static UI_Merchant_Buy_BG_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_Buy_BG_Widget_C(o.Pointer); }
        public static UI_Merchant_Buy_BG_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_Buy_BG_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_Buy_BG_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG_Heading { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG_Sort { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BGBox { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BGBox_2 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public CanvasPanel Canvas_Sort { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Sort { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image MenuCover { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_2 { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_3 { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_4 { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_5 { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_6 { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_7 { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_8 { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_Sort { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_Sort_2 { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_Sort_3 { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline_Sort_4 { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_ScrollArrow_C ScrollArrow_Down { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new UI_Merchant_ScrollArrow_C(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_ScrollArrow_C ScrollArrow_Up { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new UI_Merchant_ScrollArrow_C(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x2E8); // struct UI_WidgetColors_Struct
        public System.IntPtr MerchantColors => AddrOf(0x4F0); // struct UI_MerchantColors_Struct
        public void ShowUpArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowUpArrow", __pb.Bytes);
        }
        public void HideUpArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideUpArrow", __pb.Bytes);
        }
        public void HoverDownArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverDownArrow", __pb.Bytes);
        }
        public void UnhoverDownArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverDownArrow", __pb.Bytes);
        }
        public void ShowDownArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowDownArrow", __pb.Bytes);
        }
        public void HideDownArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideDownArrow", __pb.Bytes);
        }
        public void HoverSort()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverSort", __pb.Bytes);
        }
        public void UnHoverSort()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnHoverSort", __pb.Bytes);
        }
        public void ClickSort()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClickSort", __pb.Bytes);
        }
        public void SortSelected()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SortSelected", __pb.Bytes);
        }
        public void SortUnselected()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SortUnselected", __pb.Bytes);
        }
        public void UnhoverUpArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverUpArrow", __pb.Bytes);
        }
        public void HoverUpArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverUpArrow", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_Buy_BG_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_Buy_BG_Widget", __pb.Bytes);
        }
    }

}
