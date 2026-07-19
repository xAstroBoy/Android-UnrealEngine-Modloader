// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/NewGameConfirmScreen_BP
using System;

namespace UEModLoader.Game
{
    public class NewGameConfirmScreen_BP_C : VR4UIScreen
    {
        public const string UeClassName = "NewGameConfirmScreen_BP_C";
        public NewGameConfirmScreen_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new NewGameConfirmScreen_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NewGameConfirmScreen_BP_C(p);
        public static NewGameConfirmScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NewGameConfirmScreen_BP_C(o.Pointer); }
        public static NewGameConfirmScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NewGameConfirmScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NewGameConfirmScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public VR4UIButtonComponent VR4UIButton_Reject { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_Confirm { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_Back { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Buttons { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent HeaderWidget { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent BackButton_Widget { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent RejectButton_Widget { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent ConfirmButton_Widget { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ConfimButton { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C RejectButton { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool initialChoiceMade_ { get => Native.GetPropBool(Pointer, "initialChoiceMade?"); set => Native.SetPropBool(Pointer, "initialChoiceMade?", value); }
        public UI_MainMenu_NewGame_Button_Widget_C BackButton { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int NewGamePlusSaveSlot { get => GetAt<int>(0x2C0); set => SetAt(0x2C0, value); }
        public void StartNewGame(bool IsNewGamePlus)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsNewGamePlus?1:0));
            CallRaw("StartNewGame", __pb.Bytes);
        }
        public void SetButtonWidgetReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetButtonWidgetReferences", __pb.Bytes);
        }
        public void SetInitialButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetInitialButtons", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Reject_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Reject_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Reject_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Reject_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Reject_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_Reject_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Confirm_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Confirm_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Confirm_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Confirm_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Confirm_K2Node_ComponentBoundEvent_5_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_Confirm_K2Node_ComponentBoundEvent_5_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Back_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Back_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Back_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Back_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Back_K2Node_ComponentBoundEvent_8_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_Back_K2Node_ComponentBoundEvent_8_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_NewGameConfirmScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_NewGameConfirmScreen_BP", __pb.Bytes);
        }
    }

}
