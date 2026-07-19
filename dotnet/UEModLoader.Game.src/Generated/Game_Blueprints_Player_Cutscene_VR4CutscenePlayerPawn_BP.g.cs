// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Cutscene/VR4CutscenePlayerPawn_BP
using System;

namespace UEModLoader.Game
{
    public class VR4CutscenePlayerPawn_BP_C : VR4CutscenePlayerPawn
    {
        public const string UeClassName = "VR4CutscenePlayerPawn_BP_C";
        public VR4CutscenePlayerPawn_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4CutscenePlayerPawn_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4CutscenePlayerPawn_BP_C(p);
        public static VR4CutscenePlayerPawn_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4CutscenePlayerPawn_BP_C(o.Pointer); }
        public static VR4CutscenePlayerPawn_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4CutscenePlayerPawn_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4CutscenePlayerPawn_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x1170));
        public float Timeline_RevealInfo_Alpha_D4D74E2A415B4AA4EE4660A25C9EFACB { get => GetAt<float>(0x1178); set => SetAt(0x1178, value); }
        public byte Timeline_RevealInfo__Direction_D4D74E2A415B4AA4EE4660A25C9EFACB { get => GetAt<byte>(0x117C); set => SetAt(0x117C, value); }
        public TimelineComponent Timeline_RevealInfo { get { var __p = GetAt<global::System.IntPtr>(0x1180); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x1180, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_RevealPause_Alpha_982A4F6E4232B0BBBFB0268C3C5F1698 { get => GetAt<float>(0x1188); set => SetAt(0x1188, value); }
        public byte Timeline_RevealPause__Direction_982A4F6E4232B0BBBFB0268C3C5F1698 { get => GetAt<byte>(0x118C); set => SetAt(0x118C, value); }
        public TimelineComponent Timeline_RevealPause { get { var __p = GetAt<global::System.IntPtr>(0x1190); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x1190, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CutsceneTheatreBox_C TheatreBox { get { var __p = GetAt<global::System.IntPtr>(0x1198); return __p==global::System.IntPtr.Zero?null:new CutsceneTheatreBox_C(__p); } set => SetAt(0x1198, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor watchActor { get { var __p = GetAt<global::System.IntPtr>(0x11A0); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x11A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool AllowSkip { get => Native.GetPropBool(Pointer, "AllowSkip"); set => Native.SetPropBool(Pointer, "AllowSkip", value); }
        public CutsceneInfo_C InfoWidget { get { var __p = GetAt<global::System.IntPtr>(0x11B0); return __p==global::System.IntPtr.Zero?null:new CutsceneInfo_C(__p); } set => SetAt(0x11B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool paused { get => Native.GetPropBool(Pointer, "paused"); set => Native.SetPropBool(Pointer, "paused", value); }
        public TimerHandle DisplayTimer => new TimerHandle(AddrOf(0x11C0));
        public TimerHandle SkipTimer => new TimerHandle(AddrOf(0x11C8));
        public bool AllowButtonPress { get => Native.GetPropBool(Pointer, "AllowButtonPress"); set => Native.SetPropBool(Pointer, "AllowButtonPress", value); }
        public bool FadeActive { get => Native.GetPropBool(Pointer, "FadeActive"); set => Native.SetPropBool(Pointer, "FadeActive", value); }
        public bool SubtitleTimerActive { get => Native.GetPropBool(Pointer, "SubtitleTimerActive"); set => Native.SetPropBool(Pointer, "SubtitleTimerActive", value); }
        public VideoManager_BP_C VideoManager { get { var __p = GetAt<global::System.IntPtr>(0x11D8); return __p==global::System.IntPtr.Zero?null:new VideoManager_BP_C(__p); } set => SetAt(0x11D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TimerHandle HidePauseTimer => new TimerHandle(AddrOf(0x11E0));
        public CutscenePaused_C PausedWidget { get { var __p = GetAt<global::System.IntPtr>(0x11E8); return __p==global::System.IntPtr.Zero?null:new CutscenePaused_C(__p); } set => SetAt(0x11E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject Watch { get { var __p = GetAt<global::System.IntPtr>(0x11F0); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x11F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool CreditsActive { get => Native.GetPropBool(Pointer, "CreditsActive"); set => Native.SetPropBool(Pointer, "CreditsActive", value); }
        public global::System.IntPtr SkipCredits => AddrOf(0x1208); // 
        public bool JetSkiActive { get => Native.GetPropBool(Pointer, "JetSkiActive"); set => Native.SetPropBool(Pointer, "JetSkiActive", value); }
        public global::System.IntPtr Materials => AddrOf(0x1220); // 
        public TArray<global::System.IntPtr> MaterialNames => new TArray<global::System.IntPtr>(AddrOf(0x1270)); // TArray<FName>
        public bool LongDelayActive { get => Native.GetPropBool(Pointer, "LongDelayActive"); set => Native.SetPropBool(Pointer, "LongDelayActive", value); }
        public Actor JetSki { get { var __p = GetAt<global::System.IntPtr>(0x1288); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x1288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void ApplyMaterials(PrimitiveComponent TargetMesh, global::System.IntPtr Materials)
        {
            var __pb = new ParamBuffer(88);
            __pb.SetObject(0x0, TargetMesh);
            __pb.Set<global::System.IntPtr>(0x8, Materials);
            CallRaw("ApplyMaterials", __pb.Bytes);
        }
        public void GetMaterials(MeshComponent SourceMesh, global::System.IntPtr MaterialSlotList, global::System.IntPtr Map)
        {
            var __pb = new ParamBuffer(104);
            __pb.SetObject(0x0, SourceMesh);
            __pb.Set<global::System.IntPtr>(0x8, MaterialSlotList);
            __pb.Set<global::System.IntPtr>(0x18, Map);
            CallRaw("GetMaterials", __pb.Bytes);
        }
        public void OpenMap(EHandedness Hand)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Hand);
            CallRaw("OpenMap", __pb.Bytes);
        }
        public void ShowDriveInfo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowDriveInfo", __pb.Bytes);
        }
        public void DestroyUI()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyUI", __pb.Bytes);
        }
        public void SpawnWatch(VR4PlayerPawn Pawn, SkeletalMeshComponent Mesh, Actor Actor, UObject Interface)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, Pawn);
            __pb.SetObject(0x8, Mesh);
            __pb.SetObject(0x10, Actor);
            __pb.SetObject(0x18, Interface);
            CallRaw("SpawnWatch", __pb.Bytes);
        }
        public void CheckSkipDisableList(bool SkipDisabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipDisabled?1:0));
            CallRaw("CheckSkipDisableList", __pb.Bytes);
        }
        public void SetupHandedness()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupHandedness", __pb.Bytes);
        }
        public void Timeline_RevealPause__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_RevealPause__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_RevealPause__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_RevealPause__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_RevealInfo__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_RevealInfo__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_RevealInfo__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_RevealInfo__UpdateFunc", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_10(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_10", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_9(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_9", __pb.Bytes);
        }
        public void InpActEvt_Pause_K2Node_InputActionEvent_8(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Pause_K2Node_InputActionEvent_8", __pb.Bytes);
        }
        public void InpActEvt_Button_B_K2Node_InputActionEvent_7(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button B_K2Node_InputActionEvent_7", __pb.Bytes);
        }
        public void InpActEvt_Button_X_K2Node_InputActionEvent_6(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button X_K2Node_InputActionEvent_6", __pb.Bytes);
        }
        public void InpActEvt_Button_Y_K2Node_InputActionEvent_5(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button Y_K2Node_InputActionEvent_5", __pb.Bytes);
        }
        public void InpActEvt_SpaceBar_K2Node_InputKeyEvent_1(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_SpaceBar_K2Node_InputKeyEvent_1", __pb.Bytes);
        }
        public void InpActEvt_SpaceBar_K2Node_InputKeyEvent_0(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_SpaceBar_K2Node_InputKeyEvent_0", __pb.Bytes);
        }
        public void InpActEvt_Button_X_K2Node_InputActionEvent_4(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button X_K2Node_InputActionEvent_4", __pb.Bytes);
        }
        public void InpActEvt_Button_X_K2Node_InputActionEvent_3(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button X_K2Node_InputActionEvent_3", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_2(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_2", __pb.Bytes);
        }
        public void InpActEvt_Button_X_K2Node_InputActionEvent_1(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button X_K2Node_InputActionEvent_1", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_0(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_0", __pb.Bytes);
        }
        public void UpdateCamera(global::System.IntPtr Transform, float fovY, bool screenOn)
        {
            var __pb = new ParamBuffer(53);
            __pb.Set<global::System.IntPtr>(0x0, Transform);
            __pb.Set(0x30, fovY);
            __pb.Set<byte>(0x34, (byte)(screenOn?1:0));
            CallRaw("UpdateCamera", __pb.Bytes);
        }
        public void OnBeginActivePlayerPawn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnBeginActivePlayerPawn", __pb.Bytes);
        }
        public void OnEndActivePlayerPawn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnEndActivePlayerPawn", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void SkipCompleted()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipCompleted", __pb.Bytes);
        }
        public void DisplayInfo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisplayInfo", __pb.Bytes);
        }
        public void HideInfo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideInfo", __pb.Bytes);
        }
        public void ShowPause()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowPause", __pb.Bytes);
        }
        public void HidePause()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HidePause", __pb.Bytes);
        }
        public void ShowInfo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowInfo", __pb.Bytes);
        }
        public void OnHandednessChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnHandednessChanged", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ShowDrive()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowDrive", __pb.Bytes);
        }
        public void OnPlayerDamaged(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("OnPlayerDamaged", __pb.Bytes);
        }
        public void ShowJetSki()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowJetSki", __pb.Bytes);
        }
        public void CameraChanged(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("CameraChanged", __pb.Bytes);
        }
        public void HideJetskiInfo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideJetskiInfo", __pb.Bytes);
        }
        public void PlayerDied(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("PlayerDied", __pb.Bytes);
        }
        public void OnReceivedHandsPropsAndHolsters()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnReceivedHandsPropsAndHolsters", __pb.Bytes);
        }
        public void OnVisibilityChanged(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("OnVisibilityChanged", __pb.Bytes);
        }
        public void OnMeshVisibilityChanged(EHandedness Hand, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Hand);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("OnMeshVisibilityChanged", __pb.Bytes);
        }
        public void NewCutsceneInChain()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("NewCutsceneInChain", __pb.Bytes);
        }
        public void JetskiCheck()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("JetskiCheck", __pb.Bytes);
        }
        public void CommandHideInfo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CommandHideInfo", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4CutscenePlayerPawn_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4CutscenePlayerPawn_BP", __pb.Bytes);
        }
        public void SkipCredits__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipCredits__DelegateSignature", __pb.Bytes);
        }
    }

}
