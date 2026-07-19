// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/ComfortCustomizeCoverScreen_BP
using System;

namespace UEModLoader.Game
{
    public class ComfortCustomizeCoverScreen_BP_C : VR4UIScreen
    {
        public const string UeClassName = "ComfortCustomizeCoverScreen_BP_C";
        public ComfortCustomizeCoverScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new ComfortCustomizeCoverScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ComfortCustomizeCoverScreen_BP_C(p);
        public static ComfortCustomizeCoverScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ComfortCustomizeCoverScreen_BP_C(o.Pointer); }
        public static ComfortCustomizeCoverScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ComfortCustomizeCoverScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ComfortCustomizeCoverScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent OffsetEntryWidget { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent OffsetSliderWidget { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UISliderComponent VR4UISliderOffset { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UISliderComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent ToggleEntryWidget { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent HeightEntryWidget { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent HeightSliderWidget { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UISliderComponent VR4UISlider { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new VR4UISliderComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_ToggleEntry { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent BackButton { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Buttons { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_Next { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_currentSettings { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_comfortMode { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_fullMotion { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent btn_next_Widget { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Heading { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent btn_fullMotion_Widget { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent btn_comfortMode_Widget { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent btn_currentSettings_Widget { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ButtonComfortMode { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ButtonCurrentSettings { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ButtonFullMotion { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ButtonNext { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public int currentScreen { get => GetAt<int>(0x318); set => SetAt(0x318, value); }
        public EQuickComfortSetting QuickComfortChoice { get => (EQuickComfortSetting)GetAt<byte>(0x31C); set => SetAt(0x31C, (byte)value); }
        public bool startingSeatedMode { get => Native.GetPropBool(Pointer, "startingSeatedMode"); set => Native.SetPropBool(Pointer, "startingSeatedMode", value); }
        public float startingSeatedHeight { get => GetAt<float>(0x320); set => SetAt(0x320, value); }
        public EHandedness startingHandedness { get => (EHandedness)GetAt<byte>(0x324); set => SetAt(0x324, (byte)value); }
        public bool confirmedChoices_ { get => Native.GetPropBool(Pointer, "confirmedChoices?"); set => Native.SetPropBool(Pointer, "confirmedChoices?", value); }
        public UI_MainMenu_WideCoverContent_Widget_C WidgetHeading { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new UI_MainMenu_WideCoverContent_Widget_C(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_WideCoverEntry_Widget_C WidgetEntry { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new UI_MainMenu_WideCoverEntry_Widget_C(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public bool enableSeated_ { get => Native.GetPropBool(Pointer, "enableSeated?"); set => Native.SetPropBool(Pointer, "enableSeated?", value); }
        public EHandedness ToggleHandValue { get => (EHandedness)GetAt<byte>(0x339); set => SetAt(0x339, (byte)value); }
        public float seatedHeight { get => GetAt<float>(0x33C); set => SetAt(0x33C, value); }
        public UI_Options_Slider_Widget_C SliderWidget { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new UI_Options_Slider_Widget_C(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public bool isChanging { get => Native.GetPropBool(Pointer, "isChanging"); set => Native.SetPropBool(Pointer, "isChanging", value); }
        public int NewValue { get => GetAt<int>(0x34C); set => SetAt(0x34C, value); }
        public bool shownConfirmScreen_ { get => Native.GetPropBool(Pointer, "shownConfirmScreen?"); set => Native.SetPropBool(Pointer, "shownConfirmScreen?", value); }
        public UI_MainMenu_WideCoverEntry_Widget_C WidgetPlayerHeight { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new UI_MainMenu_WideCoverEntry_Widget_C(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Options_Slider_Widget_C SliderOffsetWidget { get { var __p = GetAt<System.IntPtr>(0x360); return __p==System.IntPtr.Zero?null:new UI_Options_Slider_Widget_C(__p); } set => SetAt(0x360, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_WideCoverEntry_Widget_C WidgetPlayerOffset { get { var __p = GetAt<System.IntPtr>(0x368); return __p==System.IntPtr.Zero?null:new UI_MainMenu_WideCoverEntry_Widget_C(__p); } set => SetAt(0x368, value?.Pointer ?? System.IntPtr.Zero); }
        public int NewValueOffset { get => GetAt<int>(0x370); set => SetAt(0x370, value); }
        public float StandingHeightOffset { get => GetAt<float>(0x374); set => SetAt(0x374, value); }
        public bool IsChangingOffet { get => Native.GetPropBool(Pointer, "IsChangingOffet"); set => Native.SetPropBool(Pointer, "IsChangingOffet", value); }
        public float StartingHeightOffset { get => GetAt<float>(0x37C); set => SetAt(0x37C, value); }
        public void SaveComfortCompleted()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SaveComfortCompleted", __pb.Bytes);
        }
        public void HeightOffsetToSliderRatio(float HeightOffset, float Ratio, int Position)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, HeightOffset);
            __pb.Set(0x4, Ratio);
            __pb.Set(0x8, Position);
            CallRaw("HeightOffsetToSliderRatio", __pb.Bytes);
        }
        public void UpdateSliderOffsetValues(int Value)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Value);
            CallRaw("UpdateSliderOffsetValues", __pb.Bytes);
        }
        public void HeadHeightToSliderRatio(float HeadHeight, float Ratio)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, HeadHeight);
            __pb.Set(0x4, Ratio);
            CallRaw("HeadHeightToSliderRatio", __pb.Bytes);
        }
        public void ShowConfirmScreen(bool ComfortConfirm)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(ComfortConfirm?1:0));
            CallRaw("ShowConfirmScreen", __pb.Bytes);
        }
        public void UpdateSliderValues(float SliderValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, SliderValue);
            CallRaw("UpdateSliderValues", __pb.Bytes);
        }
        public void Enable_Sliders()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Enable Sliders", __pb.Bytes);
        }
        public void UpdateToggleText()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateToggleText", __pb.Bytes);
        }
        public void Set_Toggle_Button_Visibility(bool Enabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            CallRaw("Set Toggle Button Visibility", __pb.Bytes);
        }
        public void RefreshOptionScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RefreshOptionScreen", __pb.Bytes);
        }
        public void AdvanceScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AdvanceScreen", __pb.Bytes);
        }
        public void GetUIScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GetUIScreen", __pb.Bytes);
        }
        public void SetButtonVisibility(bool isComfortOptionsScreen_)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(isComfortOptionsScreen_?1:0));
            CallRaw("SetButtonVisibility", __pb.Bytes);
        }
        public void SetWidgetReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetWidgetReferences", __pb.Bytes);
        }
        public void SetButtonNames()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetButtonNames", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_normal_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_normal_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_normal_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_normal_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_easy_K2Node_ComponentBoundEvent_8_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_easy_K2Node_ComponentBoundEvent_8_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_easy_K2Node_ComponentBoundEvent_9_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_easy_K2Node_ComponentBoundEvent_9_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_normal_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_normal_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_easy_K2Node_ComponentBoundEvent_1_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_easy_K2Node_ComponentBoundEvent_1_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_hard_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_hard_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_NewGamePlus_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_NewGamePlus_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_NewGamePlus_K2Node_ComponentBoundEvent_10_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_NewGamePlus_K2Node_ComponentBoundEvent_10_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_NewGamePlus_K2Node_ComponentBoundEvent_11_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_NewGamePlus_K2Node_ComponentBoundEvent_11_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_hard_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_hard_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_hard_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_hard_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_ToggleEntry_K2Node_ComponentBoundEvent_12_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_ToggleEntry_K2Node_ComponentBoundEvent_12_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_ToggleEntry_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_ToggleEntry_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_ToggleEntry_K2Node_ComponentBoundEvent_14_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_ToggleEntry_K2Node_ComponentBoundEvent_14_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void DelayedPawnUpdate()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DelayedPawnUpdate", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__BackButton_K2Node_ComponentBoundEvent_15_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__BackButton_K2Node_ComponentBoundEvent_15_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__BackButton_K2Node_ComponentBoundEvent_16_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__BackButton_K2Node_ComponentBoundEvent_16_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__BackButton_K2Node_ComponentBoundEvent_17_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__BackButton_K2Node_ComponentBoundEvent_17_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_18_SliderComponentValueChanged__DelegateSignature(VR4UISliderComponent component, int Value)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, component);
            __pb.Set(0x8, Value);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_18_SliderComponentValueChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_19_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_19_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_20_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_20_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_21_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_21_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_22_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_22_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_23_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_23_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ComfortModeConfirmed(bool ComfortConfirmed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(ComfortConfirmed?1:0));
            CallRaw("ComfortModeConfirmed", __pb.Bytes);
        }
        public void BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_24_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_24_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_25_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_25_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_26_SliderComponentValueChanged__DelegateSignature(VR4UISliderComponent component, int Value)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, component);
            __pb.Set(0x8, Value);
            CallRaw("BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_26_SliderComponentValueChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_27_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_27_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_28_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_28_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_29_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UISliderOffset_K2Node_ComponentBoundEvent_29_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_ComfortCustomizeCoverScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ComfortCustomizeCoverScreen_BP", __pb.Bytes);
        }
    }

}
