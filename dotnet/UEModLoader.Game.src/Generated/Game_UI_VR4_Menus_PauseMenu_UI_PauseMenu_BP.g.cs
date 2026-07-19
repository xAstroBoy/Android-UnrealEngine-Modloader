// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_BP_C : VR4PauseUIScreen
    {
        public const string UeClassName = "UI_PauseMenu_BP_C";
        public UI_PauseMenu_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_BP_C(p);
        public static UI_PauseMenu_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_BP_C(o.Pointer); }
        public static UI_PauseMenu_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public ChildActorComponent KeysAndTreasuresSubscreen { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent InventorySubscreen { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent blocker_left { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent blocker_front { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent blocker_right { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent blocker_top { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent blocker_back { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PointLightComponent hands_bottom { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PointLightComponent hands_top { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_PauseRoom_WallLeft { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_PauseRoom_BackingBlocker { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent Child_Discard { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent CashDisplay { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent UI_PauseMenu_SolidBlockers { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent PauseMenuIntroLoc { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent Header_FrontEnd_Actor { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent Header_InGame_Actor { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PointLightComponent InventoryItems { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_PauseRoom_WallRight { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_PauseRoom_Wall { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Inventory_Drawer_Base { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent TutorialsLoc { get { var __p = GetAt<global::System.IntPtr>(0x308); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x308, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Supports { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Lights { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent floor { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent BG { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Panel_Bottom { get { var __p = GetAt<global::System.IntPtr>(0x330); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x330, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Panel_Top { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Panel_Center { get { var __p = GetAt<global::System.IntPtr>(0x340); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x340, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Ornaments { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent CapsuleParent { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent Content_Actor { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Contents_Parent { get { var __p = GetAt<global::System.IntPtr>(0x360); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x360, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent Gears_Actor { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Frame { get { var __p = GetAt<global::System.IntPtr>(0x370); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x370, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsMenuOpen { get => Native.GetPropBool(Pointer, "IsMenuOpen"); set => Native.SetPropBool(Pointer, "IsMenuOpen", value); }
        public int NextMenu { get => GetAt<int>(0x384); set => SetAt(0x384, value); }
        public bool IsMenuSwapping { get => Native.GetPropBool(Pointer, "IsMenuSwapping"); set => Native.SetPropBool(Pointer, "IsMenuSwapping", value); }
        public int CurrentMenu { get => GetAt<int>(0x38C); set => SetAt(0x38C, value); }
        public EPauseMenuScreen CurrentMenu_Enum { get => (EPauseMenuScreen)GetAt<byte>(0x390); set => SetAt(0x390, (byte)value); }
        public EPauseMenuScreen NextMenu_Enum { get => (EPauseMenuScreen)GetAt<byte>(0x391); set => SetAt(0x391, (byte)value); }
        public UI_PauseMenu_Content_BP_C Ref_ContentActor { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Content_BP_C(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_PauseMenu_Ornaments_Gears_C Ref_GearsActor { get { var __p = GetAt<global::System.IntPtr>(0x3A0); return __p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Ornaments_Gears_C(__p); } set => SetAt(0x3A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsInMainMenu { get => Native.GetPropBool(Pointer, "IsInMainMenu"); set => Native.SetPropBool(Pointer, "IsInMainMenu", value); }
        public Actor ActiveTutorial { get { var __p = GetAt<global::System.IntPtr>(0x3B0); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x3B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_PauseMenu_Header_BP_C Ref_Header_InGame { get { var __p = GetAt<global::System.IntPtr>(0x3B8); return __p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Header_BP_C(__p); } set => SetAt(0x3B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_PauseMenu_Header_FrontEnd_BP_C Ref_Header_FrontEnd { get { var __p = GetAt<global::System.IntPtr>(0x3C0); return __p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Header_FrontEnd_BP_C(__p); } set => SetAt(0x3C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EPauseMenuScreen StartingMenu_Enum { get => (EPauseMenuScreen)GetAt<byte>(0x3C8); set => SetAt(0x3C8, (byte)value); }
        public bool doesSaveDataExist_ { get => Native.GetPropBool(Pointer, "doesSaveDataExist?"); set => Native.SetPropBool(Pointer, "doesSaveDataExist?", value); }
        public TypewriterManager_Load_BP_C LoadGameManager { get { var __p = GetAt<global::System.IntPtr>(0x3D0); return __p==global::System.IntPtr.Zero?null:new TypewriterManager_Load_BP_C(__p); } set => SetAt(0x3D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int SaveSlottoLoad { get => GetAt<int>(0x3D8); set => SetAt(0x3D8, value); }
        public bool initiatedLoadGame { get => Native.GetPropBool(Pointer, "initiatedLoadGame"); set => Native.SetPropBool(Pointer, "initiatedLoadGame", value); }
        public bool loadInProgress_ { get => Native.GetPropBool(Pointer, "loadInProgress?"); set => Native.SetPropBool(Pointer, "loadInProgress?", value); }
        public UI_Button_Discard_BP_C Ref_DiscardButton { get { var __p = GetAt<global::System.IntPtr>(0x3E0); return __p==global::System.IntPtr.Zero?null:new UI_Button_Discard_BP_C(__p); } set => SetAt(0x3E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool FirstTimeTutorial { get => Native.GetPropBool(Pointer, "FirstTimeTutorial"); set => Native.SetPropBool(Pointer, "FirstTimeTutorial", value); }
        public VR4GameInstance_BP_C GameInstance { get { var __p = GetAt<global::System.IntPtr>(0x3F0); return __p==global::System.IntPtr.Zero?null:new VR4GameInstance_BP_C(__p); } set => SetAt(0x3F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool WaitForSaveMenuReady { get => Native.GetPropBool(Pointer, "WaitForSaveMenuReady"); set => Native.SetPropBool(Pointer, "WaitForSaveMenuReady", value); }
        public bool InitialOpenComplete { get => Native.GetPropBool(Pointer, "InitialOpenComplete"); set => Native.SetPropBool(Pointer, "InitialOpenComplete", value); }
        public string LinkTransition => Native.GetPropName(Pointer, "LinkTransition"); // FName
        public FName LinkTransition_Raw { get => GetAt<FName>(0x3FC); set => SetAt(0x3FC, value); }
        public bool PlayingManualTutorial { get => Native.GetPropBool(Pointer, "PlayingManualTutorial"); set => Native.SetPropBool(Pointer, "PlayingManualTutorial", value); }
        public Actor FrontendActor { get { var __p = GetAt<global::System.IntPtr>(0x408); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x408, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool LoadButtonPressed { get => Native.GetPropBool(Pointer, "LoadButtonPressed"); set => Native.SetPropBool(Pointer, "LoadButtonPressed", value); }
        public bool FirstScreen { get => Native.GetPropBool(Pointer, "FirstScreen"); set => Native.SetPropBool(Pointer, "FirstScreen", value); }
        public bool ExitingGame { get => Native.GetPropBool(Pointer, "ExitingGame"); set => Native.SetPropBool(Pointer, "ExitingGame", value); }
        public EPauseMenuScreen Requested { get => (EPauseMenuScreen)GetAt<byte>(0x413); set => SetAt(0x413, (byte)value); }
        public bool ShowNotification { get => Native.GetPropBool(Pointer, "ShowNotification"); set => Native.SetPropBool(Pointer, "ShowNotification", value); }
        public bool NewChallengeCleared { get => Native.GetPropBool(Pointer, "NewChallengeCleared"); set => Native.SetPropBool(Pointer, "NewChallengeCleared", value); }
        public global::System.IntPtr PauseMenuScreens => AddrOf(0x418); // 
        public void PM_NotifyClosing(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_NotifyClosing", __pb.Bytes);
        }
        public void PM_SetTitleText(global::System.IntPtr TitleText, bool ShowButton, bool Callback)
        {
            var __pb = new ParamBuffer(26);
            __pb.Set<global::System.IntPtr>(0x0, TitleText);
            __pb.Set<byte>(0x18, (byte)(ShowButton?1:0));
            __pb.Set<byte>(0x19, (byte)(Callback?1:0));
            CallRaw("PM_SetTitleText", __pb.Bytes);
        }
        public void PM_GetLinkTransition(FName LinkTransition)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, LinkTransition);
            CallRaw("PM_GetLinkTransition", __pb.Bytes);
        }
        public void PM_SetLinkTransition(FName LinkTransition, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, LinkTransition);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("PM_SetLinkTransition", __pb.Bytes);
        }
        public void PM_LoadGame(int saveSlot, bool Callback)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, saveSlot);
            __pb.Set<byte>(0x4, (byte)(Callback?1:0));
            CallRaw("PM_LoadGame", __pb.Bytes);
        }
        public void PM_GetLoadGameManager(TypewriterManager_Load_BP_C LoadGameManager)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, LoadGameManager);
            CallRaw("PM_GetLoadGameManager", __pb.Bytes);
        }
        public void PM_GetMenuType(bool InGame, bool Mercenaries)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(InGame?1:0));
            __pb.Set<byte>(0x1, (byte)(Mercenaries?1:0));
            CallRaw("PM_GetMenuType", __pb.Bytes);
        }
        public void PM_PopToUIScreen(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_PopToUIScreen", __pb.Bytes);
        }
        public void PM_SetMenuSwapping(bool MenuSwapping, bool Callback)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(MenuSwapping?1:0));
            __pb.Set<byte>(0x1, (byte)(Callback?1:0));
            CallRaw("PM_SetMenuSwapping", __pb.Bytes);
        }
        public void PM_SubActionEventStart(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_SubActionEventStart", __pb.Bytes);
        }
        public void PM_ContentExitDone(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_ContentExitDone", __pb.Bytes);
        }
        public void PM_ContentEnterDone(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_ContentEnterDone", __pb.Bytes);
        }
        public void CheckForNewChallenge()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckForNewChallenge", __pb.Bytes);
        }
        public void PrepareForLoad()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PrepareForLoad", __pb.Bytes);
        }
        public void GetCurrentSubscreenComponent(ChildActorComponent SubscreenComponent)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, SubscreenComponent);
            CallRaw("GetCurrentSubscreenComponent", __pb.Bytes);
        }
        public void SpawnUncombineTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnUncombineTutorial", __pb.Bytes);
        }
        public void HandleOnEnterScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandleOnEnterScreen", __pb.Bytes);
        }
        public void StartFirstTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartFirstTutorial", __pb.Bytes);
        }
        public void CheckForFirstTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckForFirstTutorial", __pb.Bytes);
        }
        public void DiscardItems()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DiscardItems", __pb.Bytes);
        }
        public void HideDiscardButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideDiscardButton", __pb.Bytes);
        }
        public void ShowDiscardButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowDiscardButton", __pb.Bytes);
        }
        public void CheckSaves()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckSaves", __pb.Bytes);
        }
        public void SwapMenuFn(EPauseMenuScreen Selected_Menu, bool success)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Selected_Menu);
            __pb.Set<byte>(0x1, (byte)(success?1:0));
            CallRaw("SwapMenuFn", __pb.Bytes);
        }
        public void HideHelp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideHelp", __pb.Bytes);
        }
        public void ShowHelp(bool HelpActivated)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(HelpActivated?1:0));
            CallRaw("ShowHelp", __pb.Bytes);
        }
        public void SetMenu(EPauseMenuScreen SelectedMenu)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)SelectedMenu);
            CallRaw("SetMenu", __pb.Bytes);
        }
        public void CreateReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateReferences", __pb.Bytes);
        }
        public void CanSwapMenu(bool Result)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Result?1:0));
            CallRaw("CanSwapMenu", __pb.Bytes);
        }
        public bool TryStartUnpause()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("TryStartUnpause", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void CheckForTutorial(bool FromSkip, bool HelpMenu, bool WaitForTutorial)
        {
            var __pb = new ParamBuffer(3);
            __pb.Set<byte>(0x0, (byte)(FromSkip?1:0));
            __pb.Set<byte>(0x1, (byte)(HelpMenu?1:0));
            __pb.Set<byte>(0x2, (byte)(WaitForTutorial?1:0));
            CallRaw("CheckForTutorial", __pb.Bytes);
        }
        public void ConvertOldToNew(byte NewEnum, EPauseMenuScreen NewParam1)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set(0x0, NewEnum);
            __pb.Set<byte>(0x1, (byte)NewParam1);
            CallRaw("ConvertOldToNew", __pb.Bytes);
        }
        public void ConvertNewEnumToOld(EPauseMenuScreen PauseStateInfo, byte PauseEnum)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)PauseStateInfo);
            __pb.Set(0x1, PauseEnum);
            CallRaw("ConvertNewEnumToOld", __pb.Bytes);
        }
        public void ResetStartInfo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetStartInfo", __pb.Bytes);
        }
        public void SetButtonsEnabled(bool Enabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            CallRaw("SetButtonsEnabled", __pb.Bytes);
        }
        public void InpActEvt_One_K2Node_InputKeyEvent_8(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_One_K2Node_InputKeyEvent_8", __pb.Bytes);
        }
        public void InpActEvt_Two_K2Node_InputKeyEvent_7(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Two_K2Node_InputKeyEvent_7", __pb.Bytes);
        }
        public void InpActEvt_Three_K2Node_InputKeyEvent_6(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Three_K2Node_InputKeyEvent_6", __pb.Bytes);
        }
        public void InpActEvt_Four_K2Node_InputKeyEvent_5(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Four_K2Node_InputKeyEvent_5", __pb.Bytes);
        }
        public void InpActEvt_Five_K2Node_InputKeyEvent_4(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Five_K2Node_InputKeyEvent_4", __pb.Bytes);
        }
        public void InpActEvt_Six_K2Node_InputKeyEvent_3(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Six_K2Node_InputKeyEvent_3", __pb.Bytes);
        }
        public void InpActEvt_Seven_K2Node_InputKeyEvent_2(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Seven_K2Node_InputKeyEvent_2", __pb.Bytes);
        }
        public void InpActEvt_Eight_K2Node_InputKeyEvent_1(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Eight_K2Node_InputKeyEvent_1", __pb.Bytes);
        }
        public void InpActEvt_Nine_K2Node_InputKeyEvent_0(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Nine_K2Node_InputKeyEvent_0", __pb.Bytes);
        }
        public void CloseMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CloseMenu", __pb.Bytes);
        }
        public void Content_Enter()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Content_Enter", __pb.Bytes);
        }
        public void Content_Exit()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Content_Exit", __pb.Bytes);
        }
        public void Content_Hide()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Content_Hide", __pb.Bytes);
        }
        public void OpenMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenMenu", __pb.Bytes);
        }
        public void Content_Enter_Done()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Content_Enter_Done", __pb.Bytes);
        }
        public void Content_Exit_Done()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Content_Exit_Done", __pb.Bytes);
        }
        public void StopGears()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopGears", __pb.Bytes);
        }
        public void StartGears()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartGears", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEnterScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveEnterScreen", __pb.Bytes);
        }
        public void ReceiveExitScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveExitScreen", __pb.Bytes);
        }
        public void TutorialCompletePauseMenu(bool HelpScreen)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(HelpScreen?1:0));
            CallRaw("TutorialCompletePauseMenu", __pb.Bytes);
        }
        public void SubActionEventStart()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SubActionEventStart", __pb.Bytes);
        }
        public void SubActionEventEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SubActionEventEnd", __pb.Bytes);
        }
        public void LoadGame(int saveSlot)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, saveSlot);
            CallRaw("LoadGame", __pb.Bytes);
        }
        public void ReadyLoading()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReadyLoading", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void SpawnLoadGame()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnLoadGame", __pb.Bytes);
        }
        public void LoadingReady()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("LoadingReady", __pb.Bytes);
        }
        public void DevQuickLoad()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DevQuickLoad", __pb.Bytes);
        }
        public void DelayedUnpauseComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DelayedUnpauseComplete", __pb.Bytes);
        }
        public void RestartOpening(Actor DestroyedActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, DestroyedActor);
            CallRaw("RestartOpening", __pb.Bytes);
        }
        public void SaveMenuReady(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("SaveMenuReady", __pb.Bytes);
        }
        public void LoadCheckpoint()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("LoadCheckpoint", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_BP", __pb.Bytes);
        }
    }

}
