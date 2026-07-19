// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualEntrySelection
using System;

namespace UEModLoader.Game
{
    public class PlayingManualEntrySelection_C : VR4UIScreen
    {
        public const string UeClassName = "PlayingManualEntrySelection_C";
        public PlayingManualEntrySelection_C(System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualEntrySelection_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PlayingManualEntrySelection_C(p);
        public static PlayingManualEntrySelection_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualEntrySelection_C(o.Pointer); }
        public static PlayingManualEntrySelection_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualEntrySelection_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualEntrySelection_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public VR4UIButtonComponent DownButton { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent UpButton { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Heading { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent BackButton { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIScrollComponent Scroll { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new VR4UIScrollComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualEntrySelectionWidget_C BackgroundWidget { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new PlayingManualEntrySelectionWidget_C(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_PauseMenu_Content_PlayingManual_BP_C ContentParent { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Content_PlayingManual_BP_C(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public string Category => Native.GetPropName(Pointer, "Category"); // FName
        public FName Category_Raw { get => GetAt<FName>(0x298); set => SetAt(0x298, value); }
        public TArray<System.IntPtr> Buttons => new TArray<System.IntPtr>(AddrOf(0x2A0)); // TArray<UObject*>
        public string ActiveEntry => Native.GetPropName(Pointer, "ActiveEntry"); // FName
        public FName ActiveEntry_Raw { get => GetAt<FName>(0x2B0); set => SetAt(0x2B0, value); }
        public PlayingManualInfoText_C InfoText { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new PlayingManualInfoText_C(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualMain_C main { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new PlayingManualMain_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public int LinkIndex { get => GetAt<int>(0x2C8); set => SetAt(0x2C8, value); }
        public float targetScrollAmount { get => GetAt<float>(0x2CC); set => SetAt(0x2CC, value); }
        public float currentScrollAmount { get => GetAt<float>(0x2D0); set => SetAt(0x2D0, value); }
        public float scrollAmount { get => GetAt<float>(0x2D4); set => SetAt(0x2D4, value); }
        public float scrollDelay { get => GetAt<float>(0x2D8); set => SetAt(0x2D8, value); }
        public float scrollSpeed { get => GetAt<float>(0x2DC); set => SetAt(0x2DC, value); }
        public float currentScrollDelay { get => GetAt<float>(0x2E0); set => SetAt(0x2E0, value); }
        public bool isScrolling { get => Native.GetPropBool(Pointer, "isScrolling"); set => Native.SetPropBool(Pointer, "isScrolling", value); }
        public byte scrollDirection { get => GetAt<byte>(0x2E5); set => SetAt(0x2E5, value); }
        public bool UseMercColors { get => Native.GetPropBool(Pointer, "UseMercColors"); set => Native.SetPropBool(Pointer, "UseMercColors", value); }
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
        public void DestroyButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyButtons", __pb.Bytes);
        }
        public void NewEntry(FName Entry)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Entry);
            CallRaw("NewEntry", __pb.Bytes);
        }
        public void NewCategory(FName Category)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Category);
            CallRaw("NewCategory", __pb.Bytes);
        }
        public void SpawnButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnButtons", __pb.Bytes);
        }
        public void GetRelativeEntryTransofrm(int Index, Transform Transform)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set(0x0, Index);
            __pb.Set<System.IntPtr>(0x10, Transform);
            CallRaw("GetRelativeEntryTransofrm", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void Update_Scrolling(VR4UIScrollComponent ScrollComponent)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ScrollComponent);
            CallRaw("Update Scrolling", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__BackButton_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__BackButton_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__BackButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__BackButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__BackButton_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__BackButton_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__Scroll_K2Node_ComponentBoundEvent_3_ScrollComponentUpdated__DelegateSignature(VR4UIScrollComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__Scroll_K2Node_ComponentBoundEvent_3_ScrollComponentUpdated__DelegateSignature", __pb.Bytes);
        }
        public void EntryButtonClicked(FName EntryName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, EntryName);
            CallRaw("EntryButtonClicked", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void FadeInStarted()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeInStarted", __pb.Bytes);
        }
        public void TransitionComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TransitionComplete", __pb.Bytes);
        }
        public void BndEvt__UpButton_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__UpButton_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpButton_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__UpButton_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpButton_K2Node_ComponentBoundEvent_6_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__UpButton_K2Node_ComponentBoundEvent_6_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownButton_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__DownButton_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownButton_K2Node_ComponentBoundEvent_8_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__DownButton_K2Node_ComponentBoundEvent_8_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownButton_K2Node_ComponentBoundEvent_9_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__DownButton_K2Node_ComponentBoundEvent_9_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void FinishArrowScrolling()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FinishArrowScrolling", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void BndEvt__UpButton_K2Node_ComponentBoundEvent_10_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__UpButton_K2Node_ComponentBoundEvent_10_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpButton_K2Node_ComponentBoundEvent_11_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__UpButton_K2Node_ComponentBoundEvent_11_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownButton_K2Node_ComponentBoundEvent_12_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__DownButton_K2Node_ComponentBoundEvent_12_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownButton_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__DownButton_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualEntrySelection(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualEntrySelection", __pb.Bytes);
        }
    }

}
