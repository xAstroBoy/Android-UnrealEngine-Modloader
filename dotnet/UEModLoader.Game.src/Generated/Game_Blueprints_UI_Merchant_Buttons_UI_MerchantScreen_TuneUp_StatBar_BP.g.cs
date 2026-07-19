// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Buttons/UI_MerchantScreen_TuneUp_StatBar_BP
using System;

namespace UEModLoader.Game
{
    public class UI_MerchantScreen_TuneUp_StatBar_BP_C : UI_MerchantScreen_Button_BP_C
    {
        public const string UeClassName = "UI_MerchantScreen_TuneUp_StatBar_BP_C";
        public UI_MerchantScreen_TuneUp_StatBar_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_MerchantScreen_TuneUp_StatBar_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_MerchantScreen_TuneUp_StatBar_BP_C(p);
        public static UI_MerchantScreen_TuneUp_StatBar_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MerchantScreen_TuneUp_StatBar_BP_C(o.Pointer); }
        public static UI_MerchantScreen_TuneUp_StatBar_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MerchantScreen_TuneUp_StatBar_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MerchantScreen_TuneUp_StatBar_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x310));
        public ChildActorComponent RemoveUpgrade { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent AddUpgrade { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Merchant_TuneUp_StatBar2_Widget_C Ref_Stat_Widget { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new UI_Merchant_TuneUp_StatBar2_Widget_C(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4MerchantBuyItemStat stat => new VR4MerchantBuyItemStat(AddrOf(0x330));
        public global::System.IntPtr OnAddUpgrade => AddrOf(0x378); // 
        public global::System.IntPtr OnRemoveUpgrade => AddrOf(0x388); // 
        public UI_Button_BP_C RemoveUpgrade_Ref { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new UI_Button_BP_C(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsClickable { get => Native.GetPropBool(Pointer, "IsClickable"); set => Native.SetPropBool(Pointer, "IsClickable", value); }
        public void HandleRemoveUpgradeOnUnhover(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleRemoveUpgradeOnUnhover", __pb.Bytes);
        }
        public void HandleRemoveUpgradeOnHover(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleRemoveUpgradeOnHover", __pb.Bytes);
        }
        public void HandleAddUpgradeOnUnhover(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleAddUpgradeOnUnhover", __pb.Bytes);
        }
        public void HandleAddUpgradeOnHover(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleAddUpgradeOnHover", __pb.Bytes);
        }
        public void HandleRemoveUpgradeClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleRemoveUpgradeClicked", __pb.Bytes);
        }
        public void HandleAddUpgradeClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleAddUpgradeClicked", __pb.Bytes);
        }
        public void Clear()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Clear", __pb.Bytes);
        }
        public void Toggle()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Toggle", __pb.Bytes);
        }
        public void SetStat(global::System.IntPtr stat, bool CanRemove, global::System.IntPtr DowngradeState)
        {
            var __pb = new ParamBuffer(152);
            __pb.Set<global::System.IntPtr>(0x0, stat);
            __pb.Set<byte>(0x48, (byte)(CanRemove?1:0));
            __pb.Set<global::System.IntPtr>(0x50, DowngradeState);
            CallRaw("SetStat", __pb.Bytes);
        }
        public void ToggleOff()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleOff", __pb.Bytes);
        }
        public void ToggleOn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleOn", __pb.Bytes);
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
        public void CreateReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateReferences", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ClickedMainButton(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("ClickedMainButton", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MerchantScreen_TuneUp_StatBar_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MerchantScreen_TuneUp_StatBar_BP", __pb.Bytes);
        }
        public void OnRemoveUpgrade__DelegateSignature(global::System.IntPtr stat)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<global::System.IntPtr>(0x0, stat);
            CallRaw("OnRemoveUpgrade__DelegateSignature", __pb.Bytes);
        }
        public void OnAddUpgrade__DelegateSignature(global::System.IntPtr stat)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<global::System.IntPtr>(0x0, stat);
            CallRaw("OnAddUpgrade__DelegateSignature", __pb.Bytes);
        }
    }

}
