// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Screens/UI_MerchantScreen_InventoryFrame_BP
using System;

namespace UEModLoader.Game
{
    public class UI_MerchantScreen_InventoryFrame_BP_C : UI_MerchantSubScreen_BP_C
    {
        public const string UeClassName = "UI_MerchantScreen_InventoryFrame_BP_C";
        public UI_MerchantScreen_InventoryFrame_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_MerchantScreen_InventoryFrame_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_MerchantScreen_InventoryFrame_BP_C(p);
        public static UI_MerchantScreen_InventoryFrame_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MerchantScreen_InventoryFrame_BP_C(o.Pointer); }
        public static UI_MerchantScreen_InventoryFrame_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MerchantScreen_InventoryFrame_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MerchantScreen_InventoryFrame_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2B8));
        public ChildActorComponent ChildActor_TuneUp { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Panel_TuneUp { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Hinge_Parent { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent Hinge { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Button_Back { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Button_Confirm { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Price { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent InfoBar { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent InventoryGrid { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Tab_Treasures { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Tab_Inventory { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent HeaderButtons { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent TreasuresUI { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent AttachePoint { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent InventoryUI { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent Frame { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Panel_Inventory { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Cover { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent container { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Content_Back_Slide_AFF4A07A4F49E73DCEAD1CB0ED259CC0 { get => GetAt<float>(0x358); set => SetAt(0x358, value); }
        public byte Timeline_Content_Back__Direction_AFF4A07A4F49E73DCEAD1CB0ED259CC0 { get => GetAt<byte>(0x35C); set => SetAt(0x35C, value); }
        public TimelineComponent Timeline_Content_Back { get { var __p = GetAt<System.IntPtr>(0x360); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x360, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Content_Forward_Slide_303526AF415A1B6F045EEDBC09165109 { get => GetAt<float>(0x368); set => SetAt(0x368, value); }
        public byte Timeline_Content_Forward__Direction_303526AF415A1B6F045EEDBC09165109 { get => GetAt<byte>(0x36C); set => SetAt(0x36C, value); }
        public TimelineComponent Timeline_Content_Forward { get { var __p = GetAt<System.IntPtr>(0x370); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x370, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_SlideUp_rotation_A54E62F445302684F9C83DB306889220 { get => GetAt<float>(0x378); set => SetAt(0x378, value); }
        public float Timeline_SlideUp_Position_A54E62F445302684F9C83DB306889220 { get => GetAt<float>(0x37C); set => SetAt(0x37C, value); }
        public byte Timeline_SlideUp__Direction_A54E62F445302684F9C83DB306889220 { get => GetAt<byte>(0x380); set => SetAt(0x380, value); }
        public TimelineComponent Timeline_SlideUp { get { var __p = GetAt<System.IntPtr>(0x388); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x388, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_BounceDown_rotation_9959586B47F243EDCD2953941BFA408C { get => GetAt<float>(0x390); set => SetAt(0x390, value); }
        public float Timeline_BounceDown_position_9959586B47F243EDCD2953941BFA408C { get => GetAt<float>(0x394); set => SetAt(0x394, value); }
        public byte Timeline_BounceDown__Direction_9959586B47F243EDCD2953941BFA408C { get => GetAt<byte>(0x398); set => SetAt(0x398, value); }
        public TimelineComponent Timeline_BounceDown { get { var __p = GetAt<System.IntPtr>(0x3A0); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3A0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_PauseMenu_Header_Button_C Ref_TreasuresButton { get { var __p = GetAt<System.IntPtr>(0x3A8); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Header_Button_C(__p); } set => SetAt(0x3A8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_PauseMenu_Header_Button_C Ref_InventoryButton { get { var __p = GetAt<System.IntPtr>(0x3B0); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Header_Button_C(__p); } set => SetAt(0x3B0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_Button_ContentFrame_BP_C Ref_ConfirmButton { get { var __p = GetAt<System.IntPtr>(0x3B8); return __p==System.IntPtr.Zero?null:new UI_Merchant_Button_ContentFrame_BP_C(__p); } set => SetAt(0x3B8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_Price_Widget_C Ref_Price_Widget { get { var __p = GetAt<System.IntPtr>(0x3C0); return __p==System.IntPtr.Zero?null:new UI_Merchant_Price_Widget_C(__p); } set => SetAt(0x3C0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MerchantScreen_Cover_BP_C Ref_Cover { get { var __p = GetAt<System.IntPtr>(0x3C8); return __p==System.IntPtr.Zero?null:new UI_MerchantScreen_Cover_BP_C(__p); } set => SetAt(0x3C8, value?.Pointer ?? System.IntPtr.Zero); }
        public InventoryUIScreen_BP_C Ref_InventoryUI { get { var __p = GetAt<System.IntPtr>(0x3D0); return __p==System.IntPtr.Zero?null:new InventoryUIScreen_BP_C(__p); } set => SetAt(0x3D0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool IsMenuVisible { get => Native.GetPropBool(Pointer, "IsMenuVisible"); set => Native.SetPropBool(Pointer, "IsMenuVisible", value); }
        public bool IsTuneUpState { get => Native.GetPropBool(Pointer, "IsTuneUpState"); set => Native.SetPropBool(Pointer, "IsTuneUpState", value); }
        public bool OpenCoverWhenDone { get => Native.GetPropBool(Pointer, "OpenCoverWhenDone"); set => Native.SetPropBool(Pointer, "OpenCoverWhenDone", value); }
        public System.IntPtr OnInventoryActive => AddrOf(0x3E0); // 
        public bool OnInventoryScreen { get => Native.GetPropBool(Pointer, "OnInventoryScreen"); set => Native.SetPropBool(Pointer, "OnInventoryScreen", value); }
        public UI_PauseMenu_Content_KeysTreasures_BP_C Ref_Treasures { get { var __p = GetAt<System.IntPtr>(0x3F8); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Content_KeysTreasures_BP_C(__p); } set => SetAt(0x3F8, value?.Pointer ?? System.IntPtr.Zero); }
        public bool GoingToInventoryScreen { get => Native.GetPropBool(Pointer, "GoingToInventoryScreen"); set => Native.SetPropBool(Pointer, "GoingToInventoryScreen", value); }
        public bool TransitioningScreen { get => Native.GetPropBool(Pointer, "TransitioningScreen"); set => Native.SetPropBool(Pointer, "TransitioningScreen", value); }
        public void RefreshAttacheWidgets()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RefreshAttacheWidgets", __pb.Bytes);
        }
        public void ItemCantBePlaced(bool Result)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Result?1:0));
            CallRaw("ItemCantBePlaced", __pb.Bytes);
        }
        public void ResetState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetState", __pb.Bytes);
        }
        public void ShowHeaderButtons(bool Show)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            CallRaw("ShowHeaderButtons", __pb.Bytes);
        }
        public void HandleTreasuresOutroDone()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandleTreasuresOutroDone", __pb.Bytes);
        }
        public void HandleHeaderButtonClicked(UI_PauseMenu_Header_Button_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleHeaderButtonClicked", __pb.Bytes);
        }
        public void SetScreen(bool IsInventory)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsInventory?1:0));
            CallRaw("SetScreen", __pb.Bytes);
        }
        public void IsScreenAnimating(bool Animating)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Animating?1:0));
            CallRaw("IsScreenAnimating", __pb.Bytes);
        }
        public void CloseCover(bool OpenWhenDone)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(OpenWhenDone?1:0));
            CallRaw("CloseCover", __pb.Bytes);
        }
        public void OpenCover()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenCover", __pb.Bytes);
        }
        public void HandleCoverAnimationDone(bool Open)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Open?1:0));
            CallRaw("HandleCoverAnimationDone", __pb.Bytes);
        }
        public void Initialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void HandleConfirmEnabledChanged(bool Enabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            CallRaw("HandleConfirmEnabledChanged", __pb.Bytes);
        }
        public void UpdateInventoryGrid()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateInventoryGrid", __pb.Bytes);
        }
        public void HandleOnEnterState(EVR4MerchantScreenStates previousState, EVR4MerchantScreenStates State)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)previousState);
            __pb.Set<byte>(0x1, (byte)State);
            CallRaw("HandleOnEnterState", __pb.Bytes);
        }
        public void HandleOperationMoneyChanged(int Money)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Money);
            CallRaw("HandleOperationMoneyChanged", __pb.Bytes);
        }
        public void CreateReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateReferences", __pb.Bytes);
        }
        public void HandleOnHide()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandleOnHide", __pb.Bytes);
        }
        public void HandleOnShow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandleOnShow", __pb.Bytes);
        }
        public void ShouldDisplay(EVR4MerchantScreenStates State, bool ShouldDisplay)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)State);
            __pb.Set<byte>(0x1, (byte)(ShouldDisplay?1:0));
            CallRaw("ShouldDisplay", __pb.Bytes);
        }
        public void Timeline_BounceDown__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_BounceDown__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_BounceDown__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_BounceDown__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_SlideUp__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_SlideUp__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_SlideUp__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_SlideUp__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Content_Forward__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Content_Forward__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Content_Forward__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Content_Forward__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Content_Back__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Content_Back__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Content_Back__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Content_Back__UpdateFunc", __pb.Bytes);
        }
        public void HideMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideMenu", __pb.Bytes);
        }
        public void OnClick_Back(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("OnClick_Back", __pb.Bytes);
        }
        public void ShowMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowMenu", __pb.Bytes);
        }
        public void Clicked_Confirm(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Clicked_Confirm", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void SlideContentBack()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlideContentBack", __pb.Bytes);
        }
        public void SlideContentForward()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlideContentForward", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MerchantScreen_InventoryFrame_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MerchantScreen_InventoryFrame_BP", __pb.Bytes);
        }
        public void OnInventoryActive__DelegateSignature(bool Active)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Active?1:0));
            CallRaw("OnInventoryActive__DelegateSignature", __pb.Bytes);
        }
    }

}
