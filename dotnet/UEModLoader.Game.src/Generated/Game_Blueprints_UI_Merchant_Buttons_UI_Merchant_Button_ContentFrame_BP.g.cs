// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Buttons/UI_Merchant_Button_ContentFrame_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_Button_ContentFrame_BP_C : UI_MerchantScreen_Button_BP_C
    {
        public const string UeClassName = "UI_Merchant_Button_ContentFrame_BP_C";
        public UI_Merchant_Button_ContentFrame_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_Button_ContentFrame_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_Button_ContentFrame_BP_C(p);
        public static UI_Merchant_Button_ContentFrame_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_Button_ContentFrame_BP_C(o.Pointer); }
        public static UI_Merchant_Button_ContentFrame_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_Button_ContentFrame_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_Button_ContentFrame_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x310));
        public void enable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("enable", __pb.Bytes);
        }
        public void Disable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Disable", __pb.Bytes);
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
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_Button_ContentFrame_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_Button_ContentFrame_BP", __pb.Bytes);
        }
    }

}
