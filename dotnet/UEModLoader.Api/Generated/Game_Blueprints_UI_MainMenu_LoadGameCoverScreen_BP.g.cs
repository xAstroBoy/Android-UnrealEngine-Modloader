// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/LoadGameCoverScreen_BP
using System;

namespace UEModLoader.Game
{
    public class LoadGameCoverScreen_BP_C : LoadGameCoverScreen_Base_BP_C
    {
        public const string UeClassName = "LoadGameCoverScreen_BP_C";
        public LoadGameCoverScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new LoadGameCoverScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LoadGameCoverScreen_BP_C(p);
        public static LoadGameCoverScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LoadGameCoverScreen_BP_C(o.Pointer); }
        public static LoadGameCoverScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LoadGameCoverScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LoadGameCoverScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public WidgetComponent Widget_Heading { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_loadSave { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_continue { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Button { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent LoadSave_Button_Widget { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Continue_Button_Widget { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C ContinueButton { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C LoadSaveButton { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public int MostCurrentSave { get => GetAt<int>(0x2A0); set => SetAt(0x2A0, value); }
        public void SetHasActiveSaveData(bool HasActiveSaveData, int MostCurrentSave)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)(HasActiveSaveData?1:0));
            __pb.Set(0x4, MostCurrentSave);
            CallRaw("SetHasActiveSaveData", __pb.Bytes);
        }
        public void EnableButtons(bool SaveDataExists)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SaveDataExists?1:0));
            CallRaw("EnableButtons", __pb.Bytes);
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
        public void BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_5_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_5_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_6_ActorComponentDeactivateSignature__DelegateSignature(ActorComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_6_ActorComponentDeactivateSignature__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_7_ActorComponentActivatedSignature__DelegateSignature(ActorComponent component, bool bReset)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, component);
            __pb.Set<byte>(0x8, (byte)(bReset?1:0));
            CallRaw("BndEvt__VR4UIButton_continue_K2Node_ComponentBoundEvent_7_ActorComponentActivatedSignature__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_8_ActorComponentDeactivateSignature__DelegateSignature(ActorComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_8_ActorComponentDeactivateSignature__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_9_ActorComponentActivatedSignature__DelegateSignature(ActorComponent component, bool bReset)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, component);
            __pb.Set<byte>(0x8, (byte)(bReset?1:0));
            CallRaw("BndEvt__VR4UIButton_loadSave_K2Node_ComponentBoundEvent_9_ActorComponentActivatedSignature__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_LoadGameCoverScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_LoadGameCoverScreen_BP", __pb.Bytes);
        }
    }

}
