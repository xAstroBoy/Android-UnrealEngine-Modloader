// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/LoadGameUIScreen_BP
using System;

namespace UEModLoader.Game
{
    public class LoadGameUIScreen_BP_C : VR4UIScreen
    {
        public const string UeClassName = "LoadGameUIScreen_BP_C";
        public LoadGameUIScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new LoadGameUIScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LoadGameUIScreen_BP_C(p);
        public static LoadGameUIScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LoadGameUIScreen_BP_C(o.Pointer); }
        public static LoadGameUIScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LoadGameUIScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LoadGameUIScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public VR4UIButtonComponent DownArrowButton { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent UpArrowButton { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent HeadingWidget { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIScrollComponent VR4UIScroll { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new VR4UIScrollComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public TypewriterWiget_C LoadGameListWidget { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new TypewriterWiget_C(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public int Count { get => GetAt<int>(0x290); set => SetAt(0x290, value); }
        public TypewriterEntry_C ActiveSlotEntry { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new TypewriterEntry_C(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public int CurrentSlotIndex { get => GetAt<int>(0x2A0); set => SetAt(0x2A0, value); }
        public bool NewSave { get => Native.GetPropBool(Pointer, "NewSave"); set => Native.SetPropBool(Pointer, "NewSave", value); }
        public TArray<System.IntPtr> ListOfEntryBPs => new TArray<System.IntPtr>(AddrOf(0x2A8)); // TArray<UObject*>
        public int EntryHeight { get => GetAt<int>(0x2B8); set => SetAt(0x2B8, value); }
        public TypewriterManager_Load_BP_C LoadGameManager { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new TypewriterManager_Load_BP_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> SaveSlotInfo => new TArray<System.IntPtr>(AddrOf(0x2C8)); // TArray<struct>
        public bool hasActiveSaveData_ { get => Native.GetPropBool(Pointer, "hasActiveSaveData?"); set => Native.SetPropBool(Pointer, "hasActiveSaveData?", value); }
        public UI_PauseMenu_Content_Trifold_Base_BP_C UIContentParent { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Content_Trifold_Base_BP_C(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> Chapter1Screens => new TArray<System.IntPtr>(AddrOf(0x2E8)); // TArray<UObject*>
        public TArray<System.IntPtr> Chapter2Screens => new TArray<System.IntPtr>(AddrOf(0x2F8)); // TArray<UObject*>
        public TArray<System.IntPtr> Chapter3Screens => new TArray<System.IntPtr>(AddrOf(0x308)); // TArray<UObject*>
        public TArray<System.IntPtr> Chapter4Screens => new TArray<System.IntPtr>(AddrOf(0x318)); // TArray<UObject*>
        public TArray<System.IntPtr> Chapter5Screens => new TArray<System.IntPtr>(AddrOf(0x328)); // TArray<UObject*>
        public int MostRecentSlotInfosSlot { get => GetAt<int>(0x338); set => SetAt(0x338, value); }
        public UI_Options_BG_Widget_C Ref_BG_Widget { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new UI_Options_BG_Widget_C(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr HeadingText => AddrOf(0x348); // 
        public bool isScrolling { get => Native.GetPropBool(Pointer, "isScrolling"); set => Native.SetPropBool(Pointer, "isScrolling", value); }
        public byte scrollDirection { get => GetAt<byte>(0x361); set => SetAt(0x361, value); }
        public float scrollSpeed { get => GetAt<float>(0x364); set => SetAt(0x364, value); }
        public float scrollDelay { get => GetAt<float>(0x368); set => SetAt(0x368, value); }
        public float scrollAmount { get => GetAt<float>(0x36C); set => SetAt(0x36C, value); }
        public float currentScrollAmount { get => GetAt<float>(0x370); set => SetAt(0x370, value); }
        public float currentScrollDelay { get => GetAt<float>(0x374); set => SetAt(0x374, value); }
        public float targetScrollAmount { get => GetAt<float>(0x378); set => SetAt(0x378, value); }
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
        public void GetSaveSlotInfos(System.IntPtr SaveSlotInfos)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, SaveSlotInfos);
            CallRaw("GetSaveSlotInfos", __pb.Bytes);
        }
        public void IsValidSaveGame(SaveSlotInfo SaveSlotInfo, bool Valid)
        {
            var __pb = new ParamBuffer(65);
            __pb.Set<System.IntPtr>(0x0, SaveSlotInfo);
            __pb.Set<byte>(0x40, (byte)(Valid?1:0));
            CallRaw("IsValidSaveGame", __pb.Bytes);
        }
        public void RefreshAllEntries()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RefreshAllEntries", __pb.Bytes);
        }
        public void updateInitialSlot()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("updateInitialSlot", __pb.Bytes);
        }
        public void updateScreenshot(int Chapter, int Section)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Chapter);
            __pb.Set(0x4, Section);
            CallRaw("updateScreenshot", __pb.Bytes);
        }
        public void SendSaveToLoad()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SendSaveToLoad", __pb.Bytes);
        }
        public void SlotHasBeenUpdated()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlotHasBeenUpdated", __pb.Bytes);
        }
        public void FindMostRecentSave(int MostRecentSave)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, MostRecentSave);
            CallRaw("FindMostRecentSave", __pb.Bytes);
        }
        public void InitializeSaveData()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeSaveData", __pb.Bytes);
        }
        public void DestroyButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyButtons", __pb.Bytes);
        }
        public void UpdateButtonStates()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateButtonStates", __pb.Bytes);
        }
        public void SetWidgetRefs()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetWidgetRefs", __pb.Bytes);
        }
        public void PopulateWidget(System.IntPtr SaveSlotsInfo)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, SaveSlotsInfo);
            CallRaw("PopulateWidget", __pb.Bytes);
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
        public void BndEvt__VR4UIScroll_K2Node_ComponentBoundEvent_0_ScrollComponentUpdated__DelegateSignature(VR4UIScrollComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIScroll_K2Node_ComponentBoundEvent_0_ScrollComponentUpdated__DelegateSignature", __pb.Bytes);
        }
        public void UpdateCoverScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateCoverScreen", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_3_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_3_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_6_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_6_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_8_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_8_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_9_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_9_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_10_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_10_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_11_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_11_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_12_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_12_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void FinishArrowScrolling()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FinishArrowScrolling", __pb.Bytes);
        }
        public void ExecuteUbergraph_LoadGameUIScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_LoadGameUIScreen_BP", __pb.Bytes);
        }
    }

}
