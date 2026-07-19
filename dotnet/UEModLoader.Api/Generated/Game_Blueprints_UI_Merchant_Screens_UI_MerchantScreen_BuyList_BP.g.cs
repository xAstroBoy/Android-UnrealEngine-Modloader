// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Screens/UI_MerchantScreen_BuyList_BP
using System;

namespace UEModLoader.Game
{
    public class UI_MerchantScreen_BuyList_BP_C : UI_MerchantSubScreen_BP_C
    {
        public const string UeClassName = "UI_MerchantScreen_BuyList_BP_C";
        public UI_MerchantScreen_BuyList_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_MerchantScreen_BuyList_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_MerchantScreen_BuyList_BP_C(p);
        public static UI_MerchantScreen_BuyList_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MerchantScreen_BuyList_BP_C(o.Pointer); }
        public static UI_MerchantScreen_BuyList_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MerchantScreen_BuyList_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MerchantScreen_BuyList_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2B8));
        public SceneComponent DoorButtons { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent StatWidgetParent { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Door { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DoorExtension_Rotator { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ButtonAsBlocker { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Child_SortButton { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Child_SortButton_2 { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Child_SortButton_3 { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Child_SortButton_4 { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Sort_BG { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent SortMenu { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Sort_Button { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Arrow_Up { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Arrow_Down { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIScrollComponent BuyItemScrollList { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new VR4UIScrollComponent(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_ContentCover { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Selection_Exit { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Selection_TuneUp { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Selection_Sell { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Selection_Buy { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Firepower { get { var __p = GetAt<System.IntPtr>(0x360); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x360, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_ReloadSpeed { get { var __p = GetAt<System.IntPtr>(0x368); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x368, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Capacity { get { var __p = GetAt<System.IntPtr>(0x370); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x370, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_FiringSpeed { get { var __p = GetAt<System.IntPtr>(0x378); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x378, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent DoorExtension { get { var __p = GetAt<System.IntPtr>(0x380); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x380, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent door { get { var __p = GetAt<System.IntPtr>(0x388); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x388, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Door_Rotator { get { var __p = GetAt<System.IntPtr>(0x390); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x390, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Description { get { var __p = GetAt<System.IntPtr>(0x398); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x398, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor_Back { get { var __p = GetAt<System.IntPtr>(0x3A0); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x3A0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_BG { get { var __p = GetAt<System.IntPtr>(0x3A8); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x3A8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<System.IntPtr>(0x3B0); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3B0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent container { get { var __p = GetAt<System.IntPtr>(0x3B8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x3B8, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_RotateClosed_Extension_77FC9DA042B1ACF73827819EF1F361E8 { get => GetAt<float>(0x3C0); set => SetAt(0x3C0, value); }
        public float Timeline_RotateClosed_MainDoor_77FC9DA042B1ACF73827819EF1F361E8 { get => GetAt<float>(0x3C4); set => SetAt(0x3C4, value); }
        public byte Timeline_RotateClosed__Direction_77FC9DA042B1ACF73827819EF1F361E8 { get => GetAt<byte>(0x3C8); set => SetAt(0x3C8, value); }
        public TimelineComponent Timeline_RotateClosed { get { var __p = GetAt<System.IntPtr>(0x3D0); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3D0, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_RotateOpen_Extension_FAFA6D694BDF479474B5A0B033C35B85 { get => GetAt<float>(0x3D8); set => SetAt(0x3D8, value); }
        public float Timeline_RotateOpen_MainDoor_FAFA6D694BDF479474B5A0B033C35B85 { get => GetAt<float>(0x3DC); set => SetAt(0x3DC, value); }
        public byte Timeline_RotateOpen__Direction_FAFA6D694BDF479474B5A0B033C35B85 { get => GetAt<byte>(0x3E0); set => SetAt(0x3E0, value); }
        public TimelineComponent Timeline_RotateOpen { get { var __p = GetAt<System.IntPtr>(0x3E8); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3E8, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Bounce_position_2EDEDDD54F5A66F2FF707680479FA7D5 { get => GetAt<float>(0x3F0); set => SetAt(0x3F0, value); }
        public byte Timeline_Bounce__Direction_2EDEDDD54F5A66F2FF707680479FA7D5 { get => GetAt<byte>(0x3F4); set => SetAt(0x3F4, value); }
        public TimelineComponent Timeline_Bounce { get { var __p = GetAt<System.IntPtr>(0x3F8); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3F8, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Slide_Position_7C5F4309420DC145096B9FAAB0055198 { get => GetAt<float>(0x400); set => SetAt(0x400, value); }
        public byte Timeline_Slide__Direction_7C5F4309420DC145096B9FAAB0055198 { get => GetAt<byte>(0x404); set => SetAt(0x404, value); }
        public TimelineComponent Timeline_Slide { get { var __p = GetAt<System.IntPtr>(0x408); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x408, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_Description_Widget_C Ref_Description_Widget { get { var __p = GetAt<System.IntPtr>(0x410); return __p==System.IntPtr.Zero?null:new UI_Merchant_Description_Widget_C(__p); } set => SetAt(0x410, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> ListButtons => new TArray<System.IntPtr>(AddrOf(0x418)); // TArray<UObject*>
        public System.IntPtr OnSetPreviewAndStats => AddrOf(0x428); // 
        public System.IntPtr OnClearPreviewAndStats => AddrOf(0x438); // 
        public int TopItemIndex { get => GetAt<int>(0x448); set => SetAt(0x448, value); }
        public TArray<System.IntPtr> BuyItems => new TArray<System.IntPtr>(AddrOf(0x450)); // TArray<struct>
        public UI_Merchant_WeaponStat_Widget_C Ref_Stat_Firepower { get { var __p = GetAt<System.IntPtr>(0x460); return __p==System.IntPtr.Zero?null:new UI_Merchant_WeaponStat_Widget_C(__p); } set => SetAt(0x460, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_WeaponStat_Widget_C Ref_Stat_FiringSpeed { get { var __p = GetAt<System.IntPtr>(0x468); return __p==System.IntPtr.Zero?null:new UI_Merchant_WeaponStat_Widget_C(__p); } set => SetAt(0x468, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_WeaponStat_Widget_C Ref_Stat_Capacity { get { var __p = GetAt<System.IntPtr>(0x470); return __p==System.IntPtr.Zero?null:new UI_Merchant_WeaponStat_Widget_C(__p); } set => SetAt(0x470, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_WeaponStat_Widget_C Ref_Stat_ReloadSpeed { get { var __p = GetAt<System.IntPtr>(0x478); return __p==System.IntPtr.Zero?null:new UI_Merchant_WeaponStat_Widget_C(__p); } set => SetAt(0x478, value?.Pointer ?? System.IntPtr.Zero); }
        public Object LoadingAsset { get { var __p = GetAt<System.IntPtr>(0x480); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x480, value?.Pointer ?? System.IntPtr.Zero); }
        public Texture2D EmptyTexture { get { var __p = GetAt<System.IntPtr>(0x4A8); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x4A8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_Buy_Door_widget_C Ref_Door_widget { get { var __p = GetAt<System.IntPtr>(0x4B0); return __p==System.IntPtr.Zero?null:new UI_Merchant_Buy_Door_widget_C(__p); } set => SetAt(0x4B0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_Button_SelectionMenu_BP_C Ref_Selection_Buy { get { var __p = GetAt<System.IntPtr>(0x4B8); return __p==System.IntPtr.Zero?null:new UI_Merchant_Button_SelectionMenu_BP_C(__p); } set => SetAt(0x4B8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_Button_SelectionMenu_BP_C Ref_Selection_Sell { get { var __p = GetAt<System.IntPtr>(0x4C0); return __p==System.IntPtr.Zero?null:new UI_Merchant_Button_SelectionMenu_BP_C(__p); } set => SetAt(0x4C0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_Button_SelectionMenu_BP_C Ref_Selection_TuneUp { get { var __p = GetAt<System.IntPtr>(0x4C8); return __p==System.IntPtr.Zero?null:new UI_Merchant_Button_SelectionMenu_BP_C(__p); } set => SetAt(0x4C8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_Button_SelectionMenu_BP_C Ref_Selection_Exit { get { var __p = GetAt<System.IntPtr>(0x4D0); return __p==System.IntPtr.Zero?null:new UI_Merchant_Button_SelectionMenu_BP_C(__p); } set => SetAt(0x4D0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool IsDoorOpen { get => Native.GetPropBool(Pointer, "IsDoorOpen"); set => Native.SetPropBool(Pointer, "IsDoorOpen", value); }
        public bool IsMenuHidden { get => Native.GetPropBool(Pointer, "IsMenuHidden"); set => Native.SetPropBool(Pointer, "IsMenuHidden", value); }
        public TArray<System.IntPtr> ScrollListButtons => new TArray<System.IntPtr>(AddrOf(0x4E0)); // TArray<UObject*>
        public bool IsFirstIntro { get => Native.GetPropBool(Pointer, "IsFirstIntro"); set => Native.SetPropBool(Pointer, "IsFirstIntro", value); }
        public UI_Merchant_ScrollArrow_BP_C Ref_DownArrow { get { var __p = GetAt<System.IntPtr>(0x4F8); return __p==System.IntPtr.Zero?null:new UI_Merchant_ScrollArrow_BP_C(__p); } set => SetAt(0x4F8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_ScrollArrow_BP_C Ref_UpArrow { get { var __p = GetAt<System.IntPtr>(0x500); return __p==System.IntPtr.Zero?null:new UI_Merchant_ScrollArrow_BP_C(__p); } set => SetAt(0x500, value?.Pointer ?? System.IntPtr.Zero); }
        public bool isScrolling { get => Native.GetPropBool(Pointer, "isScrolling"); set => Native.SetPropBool(Pointer, "isScrolling", value); }
        public byte scrollDirection { get => GetAt<byte>(0x509); set => SetAt(0x509, value); }
        public float scrollSpeed { get => GetAt<float>(0x50C); set => SetAt(0x50C, value); }
        public float scrollDelay { get => GetAt<float>(0x510); set => SetAt(0x510, value); }
        public float scrollAmount { get => GetAt<float>(0x514); set => SetAt(0x514, value); }
        public float currentScrollAmount { get => GetAt<float>(0x518); set => SetAt(0x518, value); }
        public float currentScrollDelay { get => GetAt<float>(0x51C); set => SetAt(0x51C, value); }
        public float targetScrollAmount { get => GetAt<float>(0x520); set => SetAt(0x520, value); }
        public UI_Merchant_Buy_BG_Widget_C Ref_BG_Widget { get { var __p = GetAt<System.IntPtr>(0x528); return __p==System.IntPtr.Zero?null:new UI_Merchant_Buy_BG_Widget_C(__p); } set => SetAt(0x528, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_SortButton_BP_C Ref_SortButton { get { var __p = GetAt<System.IntPtr>(0x530); return __p==System.IntPtr.Zero?null:new UI_Merchant_SortButton_BP_C(__p); } set => SetAt(0x530, value?.Pointer ?? System.IntPtr.Zero); }
        public bool ShowingSortMenu { get => Native.GetPropBool(Pointer, "ShowingSortMenu"); set => Native.SetPropBool(Pointer, "ShowingSortMenu", value); }
        public UI_Merchant_SortEntryButton_BP_C Ref_SortEntry { get { var __p = GetAt<System.IntPtr>(0x540); return __p==System.IntPtr.Zero?null:new UI_Merchant_SortEntryButton_BP_C(__p); } set => SetAt(0x540, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_SortEntryButton_BP_C Ref_SortEntry_2 { get { var __p = GetAt<System.IntPtr>(0x548); return __p==System.IntPtr.Zero?null:new UI_Merchant_SortEntryButton_BP_C(__p); } set => SetAt(0x548, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_SortEntryButton_BP_C Ref_SortEntry_3 { get { var __p = GetAt<System.IntPtr>(0x550); return __p==System.IntPtr.Zero?null:new UI_Merchant_SortEntryButton_BP_C(__p); } set => SetAt(0x550, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Merchant_SortEntryButton_BP_C Ref_SortEntry_4 { get { var __p = GetAt<System.IntPtr>(0x558); return __p==System.IntPtr.Zero?null:new UI_Merchant_SortEntryButton_BP_C(__p); } set => SetAt(0x558, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> FreeListButtons => new TArray<System.IntPtr>(AddrOf(0x560)); // TArray<UObject*>
        public void FreeButton(UI_Merchant_ListButton_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("FreeButton", __pb.Bytes);
        }
        public void GetFreeListButton(Transform Transform, UI_Merchant_ListButton_BP_C Button)
        {
            var __pb = new ParamBuffer(56);
            __pb.Set<System.IntPtr>(0x0, Transform);
            __pb.SetObject(0x30, Button);
            CallRaw("GetFreeListButton", __pb.Bytes);
        }
        public void CreateListButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateListButton", __pb.Bytes);
        }
        public void CalculateArrowScroll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CalculateArrowScroll", __pb.Bytes);
        }
        public void ProcessArrowScroll(float DeltaTime)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaTime);
            CallRaw("ProcessArrowScroll", __pb.Bytes);
        }
        public void UI_MerchantScreen_BuyList_BP_AutoGenFunc(EVR4MerchantScreenStates previousState, EVR4MerchantScreenStates State)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)previousState);
            __pb.Set<byte>(0x1, (byte)State);
            CallRaw("UI_MerchantScreen_BuyList_BP_AutoGenFunc", __pb.Bytes);
        }
        public void AddButtonScroll(VR4MerchantBuyItem Item, int Index)
        {
            var __pb = new ParamBuffer(1028);
            __pb.Set<System.IntPtr>(0x0, Item);
            __pb.Set(0x400, Index);
            CallRaw("AddButtonScroll", __pb.Bytes);
        }
        public void HandleOnEnterState(EVR4MerchantScreenStates previousState, EVR4MerchantScreenStates State)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)previousState);
            __pb.Set<byte>(0x1, (byte)State);
            CallRaw("HandleOnEnterState", __pb.Bytes);
        }
        public void ShowBuyListMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowBuyListMenu", __pb.Bytes);
        }
        public void ShowSelectionMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowSelectionMenu", __pb.Bytes);
        }
        public void Button_Selection_ExitClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Button_Selection_ExitClicked", __pb.Bytes);
        }
        public void Button_Selection_TuneUpClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Button_Selection_TuneUpClicked", __pb.Bytes);
        }
        public void Button_Selection_SellClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Button_Selection_SellClicked", __pb.Bytes);
        }
        public void Button_Selection_BuyClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Button_Selection_BuyClicked", __pb.Bytes);
        }
        public void UpdateNewPips()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateNewPips", __pb.Bytes);
        }
        public void SetStatVisibility(bool IsVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsVisible?1:0));
            CallRaw("SetStatVisibility", __pb.Bytes);
        }
        public void UpdateStats(VR4MerchantBuyItem Item)
        {
            var __pb = new ParamBuffer(1024);
            __pb.Set<System.IntPtr>(0x0, Item);
            CallRaw("UpdateStats", __pb.Bytes);
        }
        public void ClearPreviewAndStats()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearPreviewAndStats", __pb.Bytes);
        }
        public void SetPreviewAndStats(VR4MerchantBuyItem Item)
        {
            var __pb = new ParamBuffer(1024);
            __pb.Set<System.IntPtr>(0x0, Item);
            CallRaw("SetPreviewAndStats", __pb.Bytes);
        }
        public void HandleBuyItemsChanged(System.IntPtr BuyItems)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, BuyItems);
            CallRaw("HandleBuyItemsChanged", __pb.Bytes);
        }
        public void HandleScrollDownClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleScrollDownClicked", __pb.Bytes);
        }
        public void HandleScrollUpClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleScrollUpClicked", __pb.Bytes);
        }
        public void UpdateBuyItemButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateBuyItemButtons", __pb.Bytes);
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
        public void AddButton(ChildActorComponent ChildActorComponent)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ChildActorComponent);
            CallRaw("AddButton", __pb.Bytes);
        }
        public void HandleItemHovered(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleItemHovered", __pb.Bytes);
        }
        public void HandleItemClicked(UI_Button_BP_C Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("HandleItemClicked", __pb.Bytes);
        }
        public void HandleBackClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleBackClicked", __pb.Bytes);
        }
        public void SetDescription(VR4MerchantBuyItem ItemIndex)
        {
            var __pb = new ParamBuffer(1024);
            __pb.Set<System.IntPtr>(0x0, ItemIndex);
            CallRaw("SetDescription", __pb.Bytes);
        }
        public void UnhighlightAll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhighlightAll", __pb.Bytes);
        }
        public void CreateReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateReferences", __pb.Bytes);
        }
        public void Timeline_Bounce__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Bounce__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Bounce__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Bounce__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Slide__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Slide__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Slide__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Slide__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_RotateOpen__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_RotateOpen__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_RotateOpen__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_RotateOpen__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_RotateClosed__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_RotateClosed__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_RotateClosed__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_RotateClosed__UpdateFunc", __pb.Bytes);
        }
        public void OnLoaded_36E2F6FD4F97E48A451871A48DF08711(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_36E2F6FD4F97E48A451871A48DF08711", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ShowMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowMenu", __pb.Bytes);
        }
        public void HideMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideMenu", __pb.Bytes);
        }
        public void UpdatePreview(System.IntPtr Asset)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, Asset);
            CallRaw("UpdatePreview", __pb.Bytes);
        }
        public void OpenDoor()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenDoor", __pb.Bytes);
        }
        public void SetDoorClosed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetDoorClosed", __pb.Bytes);
        }
        public void closedoor()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("closedoor", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void Press_DownArrow(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Press_DownArrow", __pb.Bytes);
        }
        public void Press_UpArrow(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Press_UpArrow", __pb.Bytes);
        }
        public void BndEvt__BuyItemScrollList_K2Node_ComponentBoundEvent_0_ScrollComponentUpdated__DelegateSignature(VR4UIScrollComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__BuyItemScrollList_K2Node_ComponentBoundEvent_0_ScrollComponentUpdated__DelegateSignature", __pb.Bytes);
        }
        public void Unhover_DownArrow(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Unhover_DownArrow", __pb.Bytes);
        }
        public void Unhover_UpArrow(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Unhover_UpArrow", __pb.Bytes);
        }
        public void Hover_DownArrow(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Hover_DownArrow", __pb.Bytes);
        }
        public void Hover_UpArrow(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Hover_UpArrow", __pb.Bytes);
        }
        public void OnClick_Down(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("OnClick_Down", __pb.Bytes);
        }
        public void OnClick_UpArrow(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("OnClick_UpArrow", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void FinishArrowScroll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FinishArrowScroll", __pb.Bytes);
        }
        public void Hover_Sort(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Hover_Sort", __pb.Bytes);
        }
        public void Unhover_Sort(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Unhover_Sort", __pb.Bytes);
        }
        public void Click_Sort(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Click_Sort", __pb.Bytes);
        }
        public void RegisterSortButton(UI_Merchant_SortEntryButton_BP_C SortButton)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, SortButton);
            CallRaw("RegisterSortButton", __pb.Bytes);
        }
        public void Hover_Sort1(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Hover_Sort1", __pb.Bytes);
        }
        public void Unhover_Sort1(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Unhover_Sort1", __pb.Bytes);
        }
        public void Click_Sort1(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Click_Sort1", __pb.Bytes);
        }
        public void ShowSortMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowSortMenu", __pb.Bytes);
        }
        public void HideSortMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideSortMenu", __pb.Bytes);
        }
        public void Hover_Sort2(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Hover_Sort2", __pb.Bytes);
        }
        public void Unhover_Sort2(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Unhover_Sort2", __pb.Bytes);
        }
        public void Click_Sort2(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Click_Sort2", __pb.Bytes);
        }
        public void Hover_Sort3(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Hover_Sort3", __pb.Bytes);
        }
        public void Unhover_Sort3(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Unhover_Sort3", __pb.Bytes);
        }
        public void Click_Sort3(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Click_Sort3", __pb.Bytes);
        }
        public void Hover_Sort4(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Hover_Sort4", __pb.Bytes);
        }
        public void Unhover_Sort4(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Unhover_Sort4", __pb.Bytes);
        }
        public void Click_Sort4(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Click_Sort4", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MerchantScreen_BuyList_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MerchantScreen_BuyList_BP", __pb.Bytes);
        }
        public void OnClearPreviewAndStats__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnClearPreviewAndStats__DelegateSignature", __pb.Bytes);
        }
        public void OnSetPreviewAndStats__DelegateSignature(VR4MerchantBuyItem Item)
        {
            var __pb = new ParamBuffer(1024);
            __pb.Set<System.IntPtr>(0x0, Item);
            CallRaw("OnSetPreviewAndStats__DelegateSignature", __pb.Bytes);
        }
    }

}
