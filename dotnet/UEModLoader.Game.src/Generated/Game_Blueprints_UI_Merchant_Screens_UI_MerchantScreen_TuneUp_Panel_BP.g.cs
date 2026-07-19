// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Screens/UI_MerchantScreen_TuneUp_Panel_BP
using System;

namespace UEModLoader.Game
{
    public class UI_MerchantScreen_TuneUp_Panel_BP_C : UI_MerchantSubScreen_BP_C
    {
        public const string UeClassName = "UI_MerchantScreen_TuneUp_Panel_BP_C";
        public UI_MerchantScreen_TuneUp_Panel_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_MerchantScreen_TuneUp_Panel_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_MerchantScreen_TuneUp_Panel_BP_C(p);
        public static UI_MerchantScreen_TuneUp_Panel_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MerchantScreen_TuneUp_Panel_BP_C(o.Pointer); }
        public static UI_MerchantScreen_TuneUp_Panel_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MerchantScreen_TuneUp_Panel_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MerchantScreen_TuneUp_Panel_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2B8));
        public WidgetComponent Widget_Description { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Mesh_DescriptionBox { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Exclusive { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Capacity { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_FiringSpeed { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Firepower { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Panel_TuneUp { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Merchant_TuneUp_Description_Widget_C Ref_Description_Widget { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new UI_Merchant_TuneUp_Description_Widget_C(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4MerchantBuyItem Item => new VR4MerchantBuyItem(AddrOf(0x300));
        public void HandleRemoveUpgrade(global::System.IntPtr stat)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<global::System.IntPtr>(0x0, stat);
            CallRaw("HandleRemoveUpgrade", __pb.Bytes);
        }
        public void HandleAddUpgrade(global::System.IntPtr stat)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<global::System.IntPtr>(0x0, stat);
            CallRaw("HandleAddUpgrade", __pb.Bytes);
        }
        public void Clear(ChildActorComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("Clear", __pb.Bytes);
        }
        public void SetStat(ChildActorComponent component, global::System.IntPtr stat)
        {
            var __pb = new ParamBuffer(80);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, stat);
            CallRaw("SetStat", __pb.Bytes);
        }
        public void HandleTuneUpItemChanged(global::System.IntPtr BuyItem)
        {
            var __pb = new ParamBuffer(1024);
            __pb.Set<global::System.IntPtr>(0x0, BuyItem);
            CallRaw("HandleTuneUpItemChanged", __pb.Bytes);
        }
        public void HandleStatToggled(UI_Button_BP_C Button, bool ToggleState)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Button);
            __pb.Set<byte>(0x8, (byte)(ToggleState?1:0));
            CallRaw("HandleStatToggled", __pb.Bytes);
        }
        public void HandleStatUnhovered(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleStatUnhovered", __pb.Bytes);
        }
        public void HandleStatHovered(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleStatHovered", __pb.Bytes);
        }
        public void SetItem(global::System.IntPtr Item)
        {
            var __pb = new ParamBuffer(1024);
            __pb.Set<global::System.IntPtr>(0x0, Item);
            CallRaw("SetItem", __pb.Bytes);
        }
        public void AddButton(ChildActorComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("AddButton", __pb.Bytes);
        }
        public void ShouldDisplay(EVR4MerchantScreenStates State, bool ShouldDisplay)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)State);
            __pb.Set<byte>(0x1, (byte)(ShouldDisplay?1:0));
            CallRaw("ShouldDisplay", __pb.Bytes);
        }
        public void ClearDescription()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearDescription", __pb.Bytes);
        }
        public void SetDescription(UI_MerchantScreen_TuneUp_StatBar_BP_C stat)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, stat);
            CallRaw("SetDescription", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MerchantScreen_TuneUp_Panel_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MerchantScreen_TuneUp_Panel_BP", __pb.Bytes);
        }
    }

}
