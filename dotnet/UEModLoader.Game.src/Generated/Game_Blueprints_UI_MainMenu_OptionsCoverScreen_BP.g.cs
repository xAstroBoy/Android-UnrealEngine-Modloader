// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/OptionsCoverScreen_BP
using System;

namespace UEModLoader.Game
{
    public class OptionsCoverScreen_BP_C : VR4UIScreen
    {
        public const string UeClassName = "OptionsCoverScreen_BP_C";
        public OptionsCoverScreen_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new OptionsCoverScreen_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OptionsCoverScreen_BP_C(p);
        public static OptionsCoverScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OptionsCoverScreen_BP_C(o.Pointer); }
        public static OptionsCoverScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OptionsCoverScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OptionsCoverScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent Widget_Heading { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_Exit { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_GeneralOptions { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_ComfortOptions { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_AudioOptions { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_LoadGame { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Buttons { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Exit_Button_Widget { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent LoadGame_Button_Widget { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent AudioOptions_Button_Widget { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent ComfortOptions_Button_Widget { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent GeneralOptions_Button_Widget { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C GeneralOptionsButton { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ComfortOptionsButton { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C AudioOptionsButton { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C LoadGameButton { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ExitGameButton { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public OptionsUIScreen_BP_C OptionsUIScreenBP { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new OptionsUIScreen_BP_C(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool PollGameManager { get => Native.GetPropBool(Pointer, "PollGameManager"); set => Native.SetPropBool(Pointer, "PollGameManager", value); }
        public bool MercColors { get => Native.GetPropBool(Pointer, "MercColors"); set => Native.SetPropBool(Pointer, "MercColors", value); }
        public void Valid_Saves_(VR4SaveMenu Manager, bool ValidSaves)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Manager);
            __pb.Set<byte>(0x8, (byte)(ValidSaves?1:0));
            CallRaw("Valid Saves?", __pb.Bytes);
        }
        public void SetButtonSpacing()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetButtonSpacing", __pb.Bytes);
        }
        public void SetButtonsEnabled()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetButtonsEnabled", __pb.Bytes);
        }
        public void GetUIScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GetUIScreen", __pb.Bytes);
        }
        public void RegisterComponents()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RegisterComponents", __pb.Bytes);
        }
        public void SetButtonWidgetReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetButtonWidgetReferences", __pb.Bytes);
        }
        public void SetButtonText()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetButtonText", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_5_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_5_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_AudioOptions_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_AudioOptions_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_AudioOptions_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_AudioOptions_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_AudioOptions_K2Node_ComponentBoundEvent_8_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_AudioOptions_K2Node_ComponentBoundEvent_8_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_LoadGame_K2Node_ComponentBoundEvent_9_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_LoadGame_K2Node_ComponentBoundEvent_9_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_LoadGame_K2Node_ComponentBoundEvent_10_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_LoadGame_K2Node_ComponentBoundEvent_10_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_LoadGame_K2Node_ComponentBoundEvent_11_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_LoadGame_K2Node_ComponentBoundEvent_11_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Exit_K2Node_ComponentBoundEvent_12_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Exit_K2Node_ComponentBoundEvent_12_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Exit_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Exit_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Exit_K2Node_ComponentBoundEvent_14_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_Exit_K2Node_ComponentBoundEvent_14_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ResetOriginalScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetOriginalScreen", __pb.Bytes);
        }
        public void ExecuteUbergraph_OptionsCoverScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_OptionsCoverScreen_BP", __pb.Bytes);
        }
    }

}
