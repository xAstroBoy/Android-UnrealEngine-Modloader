// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Buttons/UI_Merchant_SortButton_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_SortButton_BP_C : UI_MerchantScreen_Button_BP_C
    {
        public const string UeClassName = "UI_Merchant_SortButton_BP_C";
        public UI_Merchant_SortButton_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_SortButton_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_SortButton_BP_C(p);
        public static UI_Merchant_SortButton_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_SortButton_BP_C(o.Pointer); }
        public static UI_Merchant_SortButton_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_SortButton_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_SortButton_BP_C(a[i].Pointer); return r; }
    }

}
