// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Screens/UI_Merchant_CashBox_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_CashBox_BP_C : UI_MerchantSubScreen_BP_C
    {
        public const string UeClassName = "UI_Merchant_CashBox_BP_C";
        public UI_Merchant_CashBox_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_CashBox_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_CashBox_BP_C(p);
        public static UI_Merchant_CashBox_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_CashBox_BP_C(o.Pointer); }
        public static UI_Merchant_CashBox_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_CashBox_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_CashBox_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2B8));
        public SceneComponent Coins { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin45 { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin44 { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin43 { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin42 { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Coins_2 { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin40 { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin39 { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin38 { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin36 { get { var __p = GetAt<global::System.IntPtr>(0x308); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x308, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin35 { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin34 { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin33 { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Coins_3 { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin32 { get { var __p = GetAt<global::System.IntPtr>(0x330); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x330, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin31 { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin30 { get { var __p = GetAt<global::System.IntPtr>(0x340); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x340, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin29 { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin27 { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin26 { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin25 { get { var __p = GetAt<global::System.IntPtr>(0x360); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x360, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin22 { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Coins_4 { get { var __p = GetAt<global::System.IntPtr>(0x370); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x370, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin24 { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin23 { get { var __p = GetAt<global::System.IntPtr>(0x380); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x380, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin21 { get { var __p = GetAt<global::System.IntPtr>(0x388); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x388, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin20 { get { var __p = GetAt<global::System.IntPtr>(0x390); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x390, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin19 { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin18 { get { var __p = GetAt<global::System.IntPtr>(0x3A0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin8 { get { var __p = GetAt<global::System.IntPtr>(0x3A8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin7 { get { var __p = GetAt<global::System.IntPtr>(0x3B0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin6 { get { var __p = GetAt<global::System.IntPtr>(0x3B8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin5 { get { var __p = GetAt<global::System.IntPtr>(0x3C0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin4 { get { var __p = GetAt<global::System.IntPtr>(0x3C8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin3 { get { var __p = GetAt<global::System.IntPtr>(0x3D0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin2 { get { var __p = GetAt<global::System.IntPtr>(0x3D8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin1 { get { var __p = GetAt<global::System.IntPtr>(0x3E0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Merchant_Coin { get { var __p = GetAt<global::System.IntPtr>(0x3E8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Coins_5 { get { var __p = GetAt<global::System.IntPtr>(0x3F0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x3F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Price { get { var __p = GetAt<global::System.IntPtr>(0x3F8); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x3F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CashBox { get { var __p = GetAt<global::System.IntPtr>(0x400); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x400, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Merchant_Cash_Widget_C Ref_CashWidget { get { var __p = GetAt<global::System.IntPtr>(0x408); return __p==global::System.IntPtr.Zero?null:new UI_Merchant_Cash_Widget_C(__p); } set => SetAt(0x408, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void HandlePlayerMoneyChanged(int Money)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Money);
            CallRaw("HandlePlayerMoneyChanged", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_CashBox_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_CashBox_BP", __pb.Bytes);
        }
    }

}
