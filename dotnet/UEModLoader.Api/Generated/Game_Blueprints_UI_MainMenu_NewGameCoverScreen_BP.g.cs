// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/NewGameCoverScreen_BP
using System;

namespace UEModLoader.Game
{
    public class NewGameCoverScreen_BP_C : VR4UIScreen
    {
        public const string UeClassName = "NewGameCoverScreen_BP_C";
        public NewGameCoverScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new NewGameCoverScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new NewGameCoverScreen_BP_C(p);
        public static NewGameCoverScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NewGameCoverScreen_BP_C(o.Pointer); }
        public static NewGameCoverScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NewGameCoverScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NewGameCoverScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent NewGamePlus_Widget { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_NewGamePlus { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_hard { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_easy { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_normal { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Buttons { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Heading { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Difficulty_Easy_Widget { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Difficulty_Normal_Widget { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Difficulty_Hard_Widget { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ButtonNormal { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ButtonHard { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ButtonEasy { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ButtonNewGamePlus { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public void GetUIScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GetUIScreen", __pb.Bytes);
        }
        public void SetAvailableModes()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetAvailableModes", __pb.Bytes);
        }
        public void SendDifficultyToOptions(int DifficultyChosen)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DifficultyChosen);
            CallRaw("SendDifficultyToOptions", __pb.Bytes);
        }
        public void SetButtonWidgetReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetButtonWidgetReferences", __pb.Bytes);
        }
        public void SetButtonNames()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetButtonNames", __pb.Bytes);
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
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
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
        public void ResetOriginalScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetOriginalScreen", __pb.Bytes);
        }
        public void ExecuteUbergraph_NewGameCoverScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_NewGameCoverScreen_BP", __pb.Bytes);
        }
    }

}
