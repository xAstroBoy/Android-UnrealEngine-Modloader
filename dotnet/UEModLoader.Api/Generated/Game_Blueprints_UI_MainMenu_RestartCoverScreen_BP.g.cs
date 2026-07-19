// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/RestartCoverScreen_BP
using System;

namespace UEModLoader.Game
{
    public class RestartCoverScreen_BP_C : VR4UIScreen
    {
        public const string UeClassName = "RestartCoverScreen_BP_C";
        public RestartCoverScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new RestartCoverScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RestartCoverScreen_BP_C(p);
        public static RestartCoverScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RestartCoverScreen_BP_C(o.Pointer); }
        public static RestartCoverScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RestartCoverScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RestartCoverScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent Widget_Heading { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_Exit { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_Restart { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Buttons { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Exit_Button_Widget { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent GeneralOptions_Button_Widget { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C RestartButton { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C LoadGameButton { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ExitGameButton { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public OptionsUIScreen_BP_C OptionsUIScreenBP { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new OptionsUIScreen_BP_C(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public bool PollGameManager { get => Native.GetPropBool(Pointer, "PollGameManager"); set => Native.SetPropBool(Pointer, "PollGameManager", value); }
        public bool MercColors { get => Native.GetPropBool(Pointer, "MercColors"); set => Native.SetPropBool(Pointer, "MercColors", value); }
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
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
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
        public void BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
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
        public void BndEvt__VR4UIButton_Exit_K2Node_ComponentBoundEvent_14_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_Exit_K2Node_ComponentBoundEvent_14_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_RestartCoverScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_RestartCoverScreen_BP", __pb.Bytes);
        }
    }

}
