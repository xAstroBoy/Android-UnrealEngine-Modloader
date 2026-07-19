// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_ScrollArrow
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_ScrollArrow_C : UserWidget
    {
        public const string UeClassName = "UI_Merchant_ScrollArrow_C";
        public UI_Merchant_ScrollArrow_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_ScrollArrow_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_ScrollArrow_C(p);
        public static UI_Merchant_ScrollArrow_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_ScrollArrow_C(o.Pointer); }
        public static UI_Merchant_ScrollArrow_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_ScrollArrow_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_ScrollArrow_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation PulseArrow { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Arrow { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Arrow_Inner { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CanvasPanel Canvas_Line { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Frame { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x260); // struct UI_WidgetColors_Struct
        public bool isPulsing { get => Native.GetPropBool(Pointer, "isPulsing"); set => Native.SetPropBool(Pointer, "isPulsing", value); }
        public bool IsShowing { get => Native.GetPropBool(Pointer, "IsShowing"); set => Native.SetPropBool(Pointer, "IsShowing", value); }
        public global::System.IntPtr MerchantColors => AddrOf(0x470); // struct UI_MerchantColors_Struct
        public void StartPulse()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartPulse", __pb.Bytes);
        }
        public void StopPulse()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopPulse", __pb.Bytes);
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
        public void Press()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Press", __pb.Bytes);
        }
        public void UnPress()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnPress", __pb.Bytes);
        }
        public void ShowArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowArrow", __pb.Bytes);
        }
        public void HideArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideArrow", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_ScrollArrow(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_ScrollArrow", __pb.Bytes);
        }
    }

}
