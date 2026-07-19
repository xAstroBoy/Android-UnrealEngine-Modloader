// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Buttons/UI_Merchant_Button_SelectionMenu_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_Button_SelectionMenu_BP_C : UI_MerchantScreen_Button_BP_C
    {
        public const string UeClassName = "UI_Merchant_Button_SelectionMenu_BP_C";
        public UI_Merchant_Button_SelectionMenu_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_Button_SelectionMenu_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Merchant_Button_SelectionMenu_BP_C(p);
        public static UI_Merchant_Button_SelectionMenu_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_Button_SelectionMenu_BP_C(o.Pointer); }
        public static UI_Merchant_Button_SelectionMenu_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_Button_SelectionMenu_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_Button_SelectionMenu_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x310));
        public UI_Merchant_ButtonLabel_Left_Widget_C Ref_ButtonWidget { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new UI_Merchant_ButtonLabel_Left_Widget_C(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public void SetNewItemPip(bool IsNew)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsNew?1:0));
            CallRaw("SetNewItemPip", __pb.Bytes);
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
        public void ExecuteUbergraph_UI_Merchant_Button_SelectionMenu_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_Button_SelectionMenu_BP", __pb.Bytes);
        }
    }

}
