// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/UI_MerchantScreen_BP
using System;

namespace UEModLoader.Game
{
    public class UI_MerchantScreen_BP_C : VR4MerchantUIScreen
    {
        public const string UeClassName = "UI_MerchantScreen_BP_C";
        public UI_MerchantScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_MerchantScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_MerchantScreen_BP_C(p);
        public static UI_MerchantScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MerchantScreen_BP_C(o.Pointer); }
        public static UI_MerchantScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MerchantScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MerchantScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x1DB8));
        public ChildActorComponent ChildActor_Message { get { var __p = GetAt<System.IntPtr>(0x1DC0); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x1DC0, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_InventoryFrame { get { var __p = GetAt<System.IntPtr>(0x1DC8); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x1DC8, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Merchant { get { var __p = GetAt<System.IntPtr>(0x1DD0); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x1DD0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Container_SelectionMenu { get { var __p = GetAt<System.IntPtr>(0x1DD8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1DD8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Container_ListMenu { get { var __p = GetAt<System.IntPtr>(0x1DE0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1DE0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Layout_Merchant { get { var __p = GetAt<System.IntPtr>(0x1DE8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1DE8, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Table { get { var __p = GetAt<System.IntPtr>(0x1DF0); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x1DF0, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_ListMenu { get { var __p = GetAt<System.IntPtr>(0x1DF8); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x1DF8, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_CashBox { get { var __p = GetAt<System.IntPtr>(0x1E00); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x1E00, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ChildActors { get { var __p = GetAt<System.IntPtr>(0x1E08); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1E08, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent BackgroundElements { get { var __p = GetAt<System.IntPtr>(0x1E10); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1E10, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Lights { get { var __p = GetAt<System.IntPtr>(0x1E18); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1E18, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x1E20); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1E20, value?.Pointer ?? System.IntPtr.Zero); }
        public int LayoutIteration { get => GetAt<int>(0x1E28); set => SetAt(0x1E28, value); }
        public System.IntPtr LayoutVersion => AddrOf(0x1E30); // 
        public UI_Merchant_CashBox_BP_C Ref_CashBox { get { var __p = GetAt<System.IntPtr>(0x1E48); return __p==System.IntPtr.Zero?null:new UI_Merchant_CashBox_BP_C(__p); } set => SetAt(0x1E48, value?.Pointer ?? System.IntPtr.Zero); }
        public bool IsBackButtonVisible { get => Native.GetPropBool(Pointer, "IsBackButtonVisible"); set => Native.SetPropBool(Pointer, "IsBackButtonVisible", value); }
        public bool IsBackButtonCentered { get => Native.GetPropBool(Pointer, "IsBackButtonCentered"); set => Native.SetPropBool(Pointer, "IsBackButtonCentered", value); }
        public UI_Merchant_Character_BP_C Ref_Merchant { get { var __p = GetAt<System.IntPtr>(0x1E58); return __p==System.IntPtr.Zero?null:new UI_Merchant_Character_BP_C(__p); } set => SetAt(0x1E58, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_Message_BP_C Ref_Message { get { var __p = GetAt<System.IntPtr>(0x1E60); return __p==System.IntPtr.Zero?null:new UI_Merchant_Message_BP_C(__p); } set => SetAt(0x1E60, value?.Pointer ?? System.IntPtr.Zero); }
        public bool InventoryPanelActive { get => Native.GetPropBool(Pointer, "InventoryPanelActive"); set => Native.SetPropBool(Pointer, "InventoryPanelActive", value); }
        public bool GridTablePanelActive { get => Native.GetPropBool(Pointer, "GridTablePanelActive"); set => Native.SetPropBool(Pointer, "GridTablePanelActive", value); }
        public TArray<System.IntPtr> SubScreens => new TArray<System.IntPtr>(AddrOf(0x1E70)); // TArray<UObject*>
        public UI_MerchantScreen_BuyList_BP_C Ref_BuyList { get { var __p = GetAt<System.IntPtr>(0x1E80); return __p==System.IntPtr.Zero?null:new UI_MerchantScreen_BuyList_BP_C(__p); } set => SetAt(0x1E80, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Button_BP_C Ref_MessageButtonYes { get { var __p = GetAt<System.IntPtr>(0x1E88); return __p==System.IntPtr.Zero?null:new UI_Button_BP_C(__p); } set => SetAt(0x1E88, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Button_BP_C Ref_MessageButtonNo { get { var __p = GetAt<System.IntPtr>(0x1E90); return __p==System.IntPtr.Zero?null:new UI_Button_BP_C(__p); } set => SetAt(0x1E90, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Button_BP_C Ref_MessageButtonAcknowledge { get { var __p = GetAt<System.IntPtr>(0x1E98); return __p==System.IntPtr.Zero?null:new UI_Button_BP_C(__p); } set => SetAt(0x1E98, value?.Pointer ?? System.IntPtr.Zero); }
        public bool ReadQuestDialog { get => Native.GetPropBool(Pointer, "ReadQuestDialog"); set => Native.SetPropBool(Pointer, "ReadQuestDialog", value); }
        public bool QuestDialogOn { get => Native.GetPropBool(Pointer, "QuestDialogOn"); set => Native.SetPropBool(Pointer, "QuestDialogOn", value); }
        public bool TryStartUnpause()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("TryStartUnpause", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void ToggleQuestDialog(bool On)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(On?1:0));
            CallRaw("ToggleQuestDialog", __pb.Bytes);
        }
        public void HandleOnEnteredState(EVR4MerchantScreenStates previousState, EVR4MerchantScreenStates State)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)previousState);
            __pb.Set<byte>(0x1, (byte)State);
            CallRaw("HandleOnEnteredState", __pb.Bytes);
        }
        public void HandleQuestDialogRead(VR4MerchantQuestDialog QuestDialog)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, QuestDialog);
            CallRaw("HandleQuestDialogRead", __pb.Bytes);
        }
        public void InitializeQuestDialog()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeQuestDialog", __pb.Bytes);
        }
        public void HidePreviewAndStats()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HidePreviewAndStats", __pb.Bytes);
        }
        public void ShowPreviewAndStats()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowPreviewAndStats", __pb.Bytes);
        }
        public void InitializeSubScreens()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeSubScreens", __pb.Bytes);
        }
        public void HandleOnScreenAnimationDone()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandleOnScreenAnimationDone", __pb.Bytes);
        }
        public void HandleGridTableActiveChanged(bool Active)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Active?1:0));
            CallRaw("HandleGridTableActiveChanged", __pb.Bytes);
        }
        public void HandleInventoryEnabledChanged(bool Enabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            CallRaw("HandleInventoryEnabledChanged", __pb.Bytes);
        }
        public void UpdateInventoryUIScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateInventoryUIScreen", __pb.Bytes);
        }
        public void InitializeInventoryFrame()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeInventoryFrame", __pb.Bytes);
        }
        public void HandleClearPreviewAndStats()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandleClearPreviewAndStats", __pb.Bytes);
        }
        public void HandleSetPreviewAndStats(VR4MerchantBuyItem Item)
        {
            var __pb = new ParamBuffer(1024);
            __pb.Set<System.IntPtr>(0x0, Item);
            CallRaw("HandleSetPreviewAndStats", __pb.Bytes);
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
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MerchantScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MerchantScreen_BP", __pb.Bytes);
        }
    }

}
