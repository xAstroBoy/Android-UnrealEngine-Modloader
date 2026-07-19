// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_Cash_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_Cash_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Merchant_Cash_Widget_C";
        public UI_Merchant_Cash_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_Cash_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Merchant_Cash_Widget_C(p);
        public static UI_Merchant_Cash_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_Cash_Widget_C(o.Pointer); }
        public static UI_Merchant_Cash_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_Cash_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_Cash_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public TextBlock Text_Value { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Value_2 { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public int CurrentValue { get => GetAt<int>(0x248); set => SetAt(0x248, value); }
        public System.IntPtr Get_Text_Value_Text_0()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("Get_Text_Value_Text_0", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        public void SetDisplayValue(int NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetDisplayValue", __pb.Bytes);
        }
        public void AddValue(int NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("AddValue", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_Cash_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_Cash_Widget", __pb.Bytes);
        }
    }

}
