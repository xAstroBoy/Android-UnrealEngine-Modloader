// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/TutorialHand_Base_BP
using System;

namespace UEModLoader.Game
{
    public class TutorialHand_Base_BP_C : VR4TutorialHand
    {
        public const string UeClassName = "TutorialHand_Base_BP_C";
        public TutorialHand_Base_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new TutorialHand_Base_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TutorialHand_Base_BP_C(p);
        public static TutorialHand_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TutorialHand_Base_BP_C(o.Pointer); }
        public static TutorialHand_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TutorialHand_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TutorialHand_Base_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x278));
        public SceneComponent VfxTargetTrigger { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent ControllerMeshStick { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent StickActive { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent StickPivot { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent StickAnchor { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent SystemButtonActive { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent GripActive { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent TriggerActive { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent AXActive { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent BYActive { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent VfxTargetStick { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent VfxTargetGrip { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent LineTarget5 { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent LineTarget4 { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent LineTarget3 { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent LineTarget2 { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent LineTarget1 { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent LineTarget { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4TutorialButtonLabelComponent Thumbstick { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new VR4TutorialButtonLabelComponent(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4TutorialButtonLabelComponent SystemButton { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new VR4TutorialButtonLabelComponent(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4TutorialButtonLabelComponent Grip { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new VR4TutorialButtonLabelComponent(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4TutorialButtonLabelComponent Trigger { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new VR4TutorialButtonLabelComponent(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4TutorialButtonLabelComponent AX { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new VR4TutorialButtonLabelComponent(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4TutorialButtonLabelComponent _BY { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new VR4TutorialButtonLabelComponent(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent ControllerMesh { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_ButtonPulse_Alpha_C356604146F6B166F51F9E8DB530EACD { get => GetAt<float>(0x350); set => SetAt(0x350, value); }
        public byte Timeline_ButtonPulse__Direction_C356604146F6B166F51F9E8DB530EACD { get => GetAt<byte>(0x354); set => SetAt(0x354, value); }
        public TimelineComponent Timeline_ButtonPulse { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_0_NewTrack_0_DAAB33454703E34CA6867BB04AD3AF91 { get => GetAt<float>(0x360); set => SetAt(0x360, value); }
        public byte Timeline_0__Direction_DAAB33454703E34CA6867BB04AD3AF91 { get => GetAt<byte>(0x364); set => SetAt(0x364, value); }
        public TimelineComponent Timeline { get { var __p = GetAt<System.IntPtr>(0x368); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x368, value?.Pointer ?? System.IntPtr.Zero); }
        public bool ButtonLabel { get => Native.GetPropBool(Pointer, "ButtonLabel"); set => Native.SetPropBool(Pointer, "ButtonLabel", value); }
        public TArray<System.IntPtr> ButtonLabels => new TArray<System.IntPtr>(AddrOf(0x378)); // TArray<UObject*>
        public int Count { get => GetAt<int>(0x388); set => SetAt(0x388, value); }
        public TArray<System.IntPtr> LabelsToSpawn => new TArray<System.IntPtr>(AddrOf(0x390)); // TArray<UObject*>
        public TArray<System.IntPtr> TextLabels => new TArray<System.IntPtr>(AddrOf(0x3A0)); // TArray<FText>
        public TArray<System.IntPtr> Type => new TArray<System.IntPtr>(AddrOf(0x3B0)); // TArray<uint8>
        public float OpenTime { get => GetAt<float>(0x3C0); set => SetAt(0x3C0, value); }
        public float CloseTime { get => GetAt<float>(0x3C4); set => SetAt(0x3C4, value); }
        public Actor HeldProp { get { var __p = GetAt<System.IntPtr>(0x3C8); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x3C8, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4Bio4PlayerHand playerHand { get { var __p = GetAt<System.IntPtr>(0x3D0); return __p==System.IntPtr.Zero?null:new VR4Bio4PlayerHand(__p); } set => SetAt(0x3D0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool TranslucentActive { get => Native.GetPropBool(Pointer, "TranslucentActive"); set => Native.SetPropBool(Pointer, "TranslucentActive", value); }
        public LabelLineSettings TutorialLineSettings => new LabelLineSettings(AddrOf(0x3DC));
        public TimerHandle CloseTimer => new TimerHandle(AddrOf(0x3F8));
        public bool isCompleted { get => Native.GetPropBool(Pointer, "isCompleted"); set => Native.SetPropBool(Pointer, "isCompleted", value); }
        public MaterialInterface RedMaterial { get { var __p = GetAt<System.IntPtr>(0x408); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x408, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface YellowMaterial { get { var __p = GetAt<System.IntPtr>(0x410); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x410, value?.Pointer ?? System.IntPtr.Zero); }
        public bool StickInUse { get => Native.GetPropBool(Pointer, "StickInUse"); set => Native.SetPropBool(Pointer, "StickInUse", value); }
        public VR4Bio4PlayerPawn_BP_C Bio4Pawn { get { var __p = GetAt<System.IntPtr>(0x420); return __p==System.IntPtr.Zero?null:new VR4Bio4PlayerPawn_BP_C(__p); } set => SetAt(0x420, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector StickLineOffset => new Vector(AddrOf(0x428));
        public void PlatformChanged(byte NewActivePlatform, bool Callback)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set(0x0, NewActivePlatform);
            __pb.Set<byte>(0x1, (byte)(Callback?1:0));
            CallRaw("PlatformChanged", __pb.Bytes);
        }
        public void WorldDilationChanged(float WorldTimeDilation, float PlayerTimeDilation, float CustomTimeDilation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, WorldTimeDilation);
            __pb.Set(0x4, PlayerTimeDilation);
            __pb.Set(0x8, CustomTimeDilation);
            CallRaw("WorldDilationChanged", __pb.Bytes);
        }
        public void Button_Pre_Check()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Button Pre Check", __pb.Bytes);
        }
        public void UpdateMeshes(byte ActivePlatform)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, ActivePlatform);
            CallRaw("UpdateMeshes", __pb.Bytes);
        }
        public void ShowButtonHighlight(VR4TutorialButtonLabelComponent ButtonComponent, TutorialLabel TutorialLabel)
        {
            var __pb = new ParamBuffer(104);
            __pb.SetObject(0x0, ButtonComponent);
            __pb.Set<System.IntPtr>(0x8, TutorialLabel);
            CallRaw("ShowButtonHighlight", __pb.Bytes);
        }
        public void CloseInstantly()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CloseInstantly", __pb.Bytes);
        }
        public void ClearButtonLabels(bool isCompleted)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(isCompleted?1:0));
            CallRaw("ClearButtonLabels", __pb.Bytes);
        }
        public void SpawnLabel2(System.IntPtr LabelText, VR4TutorialButtonLabelComponent ButtonTarget, LabelLineSettings LineSettings, Vector OffsetFromTarget)
        {
            var __pb = new ParamBuffer(68);
            __pb.Set<System.IntPtr>(0x0, LabelText);
            __pb.SetObject(0x18, ButtonTarget);
            __pb.Set<System.IntPtr>(0x20, LineSettings);
            __pb.Set<System.IntPtr>(0x38, OffsetFromTarget);
            CallRaw("SpawnLabel2", __pb.Bytes);
        }
        public void ShowInfoWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowInfoWidget", __pb.Bytes);
        }
        public void HideInfoWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideInfoWidget", __pb.Bytes);
        }
        public void Timeline_0__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_0__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_0__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_0__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_ButtonPulse__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ButtonPulse__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ButtonPulse__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ButtonPulse__UpdateFunc", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_17(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_17", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_16(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_16", __pb.Bytes);
        }
        public void InpActEvt_Button_B_K2Node_InputActionEvent_15(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button B_K2Node_InputActionEvent_15", __pb.Bytes);
        }
        public void InpActEvt_Button_B_K2Node_InputActionEvent_14(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button B_K2Node_InputActionEvent_14", __pb.Bytes);
        }
        public void InpActEvt_Button_Y_K2Node_InputActionEvent_13(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button Y_K2Node_InputActionEvent_13", __pb.Bytes);
        }
        public void InpActEvt_Button_Y_K2Node_InputActionEvent_12(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button Y_K2Node_InputActionEvent_12", __pb.Bytes);
        }
        public void InpActEvt_Button_X_K2Node_InputActionEvent_11(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button X_K2Node_InputActionEvent_11", __pb.Bytes);
        }
        public void InpActEvt_Button_X_K2Node_InputActionEvent_10(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button X_K2Node_InputActionEvent_10", __pb.Bytes);
        }
        public void InpActEvt_Pause_K2Node_InputActionEvent_9(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Pause_K2Node_InputActionEvent_9", __pb.Bytes);
        }
        public void InpActEvt_Pause_K2Node_InputActionEvent_8(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Pause_K2Node_InputActionEvent_8", __pb.Bytes);
        }
        public void InpActEvt__L__Grip_K2Node_InputActionEvent_7(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Grip_K2Node_InputActionEvent_7", __pb.Bytes);
        }
        public void InpActEvt__L__Grip_K2Node_InputActionEvent_6(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Grip_K2Node_InputActionEvent_6", __pb.Bytes);
        }
        public void InpActEvt__R__Grip_K2Node_InputActionEvent_5(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Grip_K2Node_InputActionEvent_5", __pb.Bytes);
        }
        public void InpActEvt__R__Grip_K2Node_InputActionEvent_4(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Grip_K2Node_InputActionEvent_4", __pb.Bytes);
        }
        public void InpActEvt__L__Trigger_K2Node_InputActionEvent_3(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Trigger_K2Node_InputActionEvent_3", __pb.Bytes);
        }
        public void InpActEvt__L__Trigger_K2Node_InputActionEvent_2(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Trigger_K2Node_InputActionEvent_2", __pb.Bytes);
        }
        public void InpActEvt__R__Trigger_K2Node_InputActionEvent_1(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Trigger_K2Node_InputActionEvent_1", __pb.Bytes);
        }
        public void InpActEvt__R__Trigger_K2Node_InputActionEvent_0(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Trigger_K2Node_InputActionEvent_0", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnShow(VR4TutorialButtonLabelComponent buttonComp, TutorialLabel Label)
        {
            var __pb = new ParamBuffer(104);
            __pb.SetObject(0x0, buttonComp);
            __pb.Set<System.IntPtr>(0x8, Label);
            CallRaw("OnShow", __pb.Bytes);
        }
        public void OnClose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnClose", __pb.Bytes);
        }
        public void Grow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Grow", __pb.Bytes);
        }
        public void Shrink()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Shrink", __pb.Bytes);
        }
        public void SetControllerMeshVisible(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("SetControllerMeshVisible", __pb.Bytes);
        }
        public void OnCloseImmediate()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnCloseImmediate", __pb.Bytes);
        }
        public void SetTranslucentHands()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetTranslucentHands", __pb.Bytes);
        }
        public void SetOpaqueHands()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetOpaqueHands", __pb.Bytes);
        }
        public void TryGetHeldProp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TryGetHeldProp", __pb.Bytes);
        }
        public void CloseTutorialButton(VR4TutorialButtonLabelComponent buttonComp)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, buttonComp);
            CallRaw("CloseTutorialButton", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void SpawnTutorialLabel(TutorialLabel tutorialInstructions)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<System.IntPtr>(0x0, tutorialInstructions);
            CallRaw("SpawnTutorialLabel", __pb.Bytes);
        }
        public void Close()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Close", __pb.Bytes);
        }
        public void CloseComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CloseComplete", __pb.Bytes);
        }
        public void FrameDelayDestroy()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FrameDelayDestroy", __pb.Bytes);
        }
        public void StartHaptics()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartHaptics", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ButtonPressedAX()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ButtonPressedAX", __pb.Bytes);
        }
        public void ButtonPressedBY()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ButtonPressedBY", __pb.Bytes);
        }
        public void ButtonPressedPause()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ButtonPressedPause", __pb.Bytes);
        }
        public void ButtonPressedTrigger()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ButtonPressedTrigger", __pb.Bytes);
        }
        public void ButtonPressedGrip()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ButtonPressedGrip", __pb.Bytes);
        }
        public void ManualReleasePause()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ManualReleasePause", __pb.Bytes);
        }
        public void ManualReleaseAX()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ManualReleaseAX", __pb.Bytes);
        }
        public void ExecuteUbergraph_TutorialHand_Base_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_TutorialHand_Base_BP", __pb.Bytes);
        }
    }

}
