// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/LoadGameDoorRightScreen_BP
using System;

namespace UEModLoader.Game
{
    public class LoadGameDoorRightScreen_BP_C : VR4UIScreen
    {
        public const string UeClassName = "LoadGameDoorRightScreen_BP_C";
        public LoadGameDoorRightScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new LoadGameDoorRightScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LoadGameDoorRightScreen_BP_C(p);
        public static LoadGameDoorRightScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LoadGameDoorRightScreen_BP_C(o.Pointer); }
        public static LoadGameDoorRightScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LoadGameDoorRightScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LoadGameDoorRightScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent CheckpointWidget { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_Checkpoint { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent CancelWidget { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_Cancel { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent LoadWidget { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_Load { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C LoadButton { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C CancelButton { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C CheckpointButton { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public void DoLoad()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DoLoad", __pb.Bytes);
        }
        public void GetWidgetReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GetWidgetReferences", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Load_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Load_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Load_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Load_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Load_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_Load_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Load_K2Node_ComponentBoundEvent_4_ActorComponentActivatedSignature__DelegateSignature(ActorComponent component, bool bReset)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, component);
            __pb.Set<byte>(0x8, (byte)(bReset?1:0));
            CallRaw("BndEvt__VR4UIButton_Load_K2Node_ComponentBoundEvent_4_ActorComponentActivatedSignature__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Cancel_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Cancel_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Cancel_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Cancel_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Cancel_K2Node_ComponentBoundEvent_6_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_Cancel_K2Node_ComponentBoundEvent_6_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void DisableLoadButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableLoadButton", __pb.Bytes);
        }
        public void EnableLoadButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EnableLoadButton", __pb.Bytes);
        }
        public void OnLoadEvent()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnLoadEvent", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Checkpoint_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Checkpoint_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Checkpoint_K2Node_ComponentBoundEvent_8_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_Checkpoint_K2Node_ComponentBoundEvent_8_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_Checkpoint_K2Node_ComponentBoundEvent_9_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_Checkpoint_K2Node_ComponentBoundEvent_9_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_LoadGameDoorRightScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_LoadGameDoorRightScreen_BP", __pb.Bytes);
        }
    }

}
