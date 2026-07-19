// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/ShootingRangeCoverScreen_BP
using System;

namespace UEModLoader.Game
{
    public class ShootingRangeCoverScreen_BP_C : LoadGameCoverScreen_Base_BP_C
    {
        public const string UeClassName = "ShootingRangeCoverScreen_BP_C";
        public ShootingRangeCoverScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new ShootingRangeCoverScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ShootingRangeCoverScreen_BP_C(p);
        public static ShootingRangeCoverScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ShootingRangeCoverScreen_BP_C(o.Pointer); }
        public static ShootingRangeCoverScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ShootingRangeCoverScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ShootingRangeCoverScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public WidgetComponent Widget_Heading { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_loadSave { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton_practiceMode { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Button { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent LoadSave_Button_Widget { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent PracticeMode_Button_Widget { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C Ref_PracticeModeButton { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_NewGame_Button_Widget_C Ref_LoadSaveButton { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new UI_MainMenu_NewGame_Button_Widget_C(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_CoverScreen_Widget_C Ref_HeadingWidget { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new UI_CoverScreen_Widget_C(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr StartPracticeMode => AddrOf(0x2A8); // 
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
        public void CreateReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateReferences", __pb.Bytes);
        }
        public void Initialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Initialize", __pb.Bytes);
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
        public void ExecuteUbergraph_ShootingRangeCoverScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ShootingRangeCoverScreen_BP", __pb.Bytes);
        }
        public void StartPracticeMode__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartPracticeMode__DelegateSignature", __pb.Bytes);
        }
    }

}
