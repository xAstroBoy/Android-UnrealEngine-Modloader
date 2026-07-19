// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Cutscene/CutsceneTheatreBox
using System;

namespace UEModLoader.Game
{
    public class CutsceneTheatreBox_C : Actor
    {
        public const string UeClassName = "CutsceneTheatreBox_C";
        public CutsceneTheatreBox_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new CutsceneTheatreBox_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new CutsceneTheatreBox_C(p);
        public static CutsceneTheatreBox_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CutsceneTheatreBox_C(o.Pointer); }
        public static CutsceneTheatreBox_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CutsceneTheatreBox_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CutsceneTheatreBox_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent WidgetTopRing { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent VignetteQte1 { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent FlatScreen { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent BinocularCapture { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent VignetteAnchor { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Plane7_WidgetBG { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GenericLocator EndGameWidgetsLoc { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DebugFloor { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent ScreenDebug { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ScreenDebugAnchor { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent ChildActorControllers { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent floor { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent PlayerLoc { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent WidgetInfoRing { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent LogoLoc { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent WidgetPause { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent WidgetInfo { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent WidgetSubtitles { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneCaptureComponent2D SceneCaptureComponent2D { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new SceneCaptureComponent2D(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Walls { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Plane6 { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Plane5 { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Plane4 { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Plane3 { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Plane2 { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Plane1 { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Screen { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ShowSpikes_Alpha_E195C57F472D3A84FC18CC98579E7EBE { get => GetAt<float>(0x308); set => SetAt(0x308, value); }
        public byte Timeline_ShowSpikes__Direction_E195C57F472D3A84FC18CC98579E7EBE { get => GetAt<byte>(0x30C); set => SetAt(0x30C, value); }
        public TimelineComponent Timeline_ShowSpikes { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_InfoRing_NewTrack_2_20DD7E414C7A44B3353B4AAD54B00294 { get => GetAt<float>(0x318); set => SetAt(0x318, value); }
        public byte Timeline_InfoRing__Direction_20DD7E414C7A44B3353B4AAD54B00294 { get => GetAt<byte>(0x31C); set => SetAt(0x31C, value); }
        public TimelineComponent Timeline_InfoRing { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_FadeScreen_Alpha_CAD1953540BC4C777B5225AD3DC387AD { get => GetAt<float>(0x328); set => SetAt(0x328, value); }
        public byte Timeline_FadeScreen__Direction_CAD1953540BC4C777B5225AD3DC387AD { get => GetAt<byte>(0x32C); set => SetAt(0x32C, value); }
        public TimelineComponent Timeline_FadeScreen { get { var __p = GetAt<global::System.IntPtr>(0x330); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x330, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Subtitles_C SubtitleWidget { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new Subtitles_C(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TimerHandle SubtitleTimer => new TimerHandle(AddrOf(0x340));
        public string CinematicsStringTable => Native.GetPropName(Pointer, "CinematicsStringTable"); // FName
        public FName CinematicsStringTable_Raw { get => GetAt<FName>(0x348); set => SetAt(0x348, value); }
        public bool Debug { get => Native.GetPropBool(Pointer, "Debug"); set => Native.SetPropBool(Pointer, "Debug", value); }
        public TArray<global::System.IntPtr> SubtitleOverrides => new TArray<global::System.IntPtr>(AddrOf(0x358)); // TArray<struct>
        public int OverrideIndex { get => GetAt<int>(0x368); set => SetAt(0x368, value); }
        public string NewKey => Native.GetPropString(Pointer, "NewKey"); // FString
        public float NewDuration { get => GetAt<float>(0x380); set => SetAt(0x380, value); }
        public TArray<global::System.IntPtr> OverrideKeys => new TArray<global::System.IntPtr>(AddrOf(0x388)); // TArray<FString>
        public TimerHandle CutsceneTimer => new TimerHandle(AddrOf(0x398));
        public string ActiveCutscene => Native.GetPropString(Pointer, "ActiveCutscene"); // FString
        public TimerHandle LogoTimer => new TimerHandle(AddrOf(0x3B0));
        public Bio4_BP_C Bio4BP { get { var __p = GetAt<global::System.IntPtr>(0x3B8); return __p==global::System.IntPtr.Zero?null:new Bio4_BP_C(__p); } set => SetAt(0x3B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor LogoClass { get { var __p = GetAt<global::System.IntPtr>(0x3C0); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x3C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor LogoActor { get { var __p = GetAt<global::System.IntPtr>(0x3C8); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x3C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MediaPlayer Media { get { var __p = GetAt<global::System.IntPtr>(0x3D0); return __p==global::System.IntPtr.Zero?null:new MediaPlayer(__p); } set => SetAt(0x3D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AudioComponent MovieAudio { get { var __p = GetAt<global::System.IntPtr>(0x3D8); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x3D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VideoManager_BP_C VideoManager { get { var __p = GetAt<global::System.IntPtr>(0x3E0); return __p==global::System.IntPtr.Zero?null:new VideoManager_BP_C(__p); } set => SetAt(0x3E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TimerHandle OverrideTimer => new TimerHandle(AddrOf(0x3E8));
        public InfoRing_C InfoRingWidget { get { var __p = GetAt<global::System.IntPtr>(0x3F0); return __p==global::System.IntPtr.Zero?null:new InfoRing_C(__p); } set => SetAt(0x3F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ControllerIcon3d_C _3DIcon { get { var __p = GetAt<global::System.IntPtr>(0x3F8); return __p==global::System.IntPtr.Zero?null:new ControllerIcon3d_C(__p); } set => SetAt(0x3F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vignette_QTE_C Slomo { get { var __p = GetAt<global::System.IntPtr>(0x400); return __p==global::System.IntPtr.Zero?null:new Vignette_QTE_C(__p); } set => SetAt(0x400, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EVR4CommandButton ActiveCommand { get => (EVR4CommandButton)GetAt<byte>(0x408); set => SetAt(0x408, (byte)value); }
        public EActionButtonType ActiveAction { get => (EActionButtonType)GetAt<byte>(0x409); set => SetAt(0x409, (byte)value); }
        public float SpikeScale { get => GetAt<float>(0x40C); set => SetAt(0x40C, value); }
        public float CurrentFov { get => GetAt<float>(0x410); set => SetAt(0x410, value); }
        public CurveFloat SpikeAnchorPosition { get { var __p = GetAt<global::System.IntPtr>(0x418); return __p==global::System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x418, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CurveFloat SpikeTravelDistance { get { var __p = GetAt<global::System.IntPtr>(0x420); return __p==global::System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x420, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TimerHandle IconDelay => new TimerHandle(AddrOf(0x428));
        public TimerHandle NewVar => new TimerHandle(AddrOf(0x430));
        public VR4DummyPlayerController_BP_C ParticleLodController { get { var __p = GetAt<global::System.IntPtr>(0x438); return __p==global::System.IntPtr.Zero?null:new VR4DummyPlayerController_BP_C(__p); } set => SetAt(0x438, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TimerHandle _120Timer => new TimerHandle(AddrOf(0x440));
        public EQTEId ActiveQte { get => (EQTEId)GetAt<byte>(0x448); set => SetAt(0x448, (byte)value); }
        public bool Skipping { get => Native.GetPropBool(Pointer, "Skipping"); set => Native.SetPropBool(Pointer, "Skipping", value); }
        public Actor EndGameClass { get { var __p = GetAt<global::System.IntPtr>(0x450); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x450, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor EndGameActor { get { var __p = GetAt<global::System.IntPtr>(0x458); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x458, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr EndGameActorReady => AddrOf(0x460); // 
        public bool InEndGameBehavior { get => Native.GetPropBool(Pointer, "InEndGameBehavior"); set => Native.SetPropBool(Pointer, "InEndGameBehavior", value); }
        public FileMediaSource VideoToPlay { get { var __p = GetAt<global::System.IntPtr>(0x478); return __p==global::System.IntPtr.Zero?null:new FileMediaSource(__p); } set => SetAt(0x478, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoundBase AudioToPlayWithVideo { get { var __p = GetAt<global::System.IntPtr>(0x480); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x480, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool QteResult { get => Native.GetPropBool(Pointer, "QteResult"); set => Native.SetPropBool(Pointer, "QteResult", value); }
        public bool PlayerIsDead { get => Native.GetPropBool(Pointer, "PlayerIsDead"); set => Native.SetPropBool(Pointer, "PlayerIsDead", value); }
        public bool ForceQteResult { get => Native.GetPropBool(Pointer, "ForceQteResult"); set => Native.SetPropBool(Pointer, "ForceQteResult", value); }
        public bool MediaPaused { get => Native.GetPropBool(Pointer, "MediaPaused"); set => Native.SetPropBool(Pointer, "MediaPaused", value); }
        public bool MediaPausedDueToFocus { get => Native.GetPropBool(Pointer, "MediaPausedDueToFocus"); set => Native.SetPropBool(Pointer, "MediaPausedDueToFocus", value); }
        public VR4CutsceneManager_BP_C Manager { get { var __p = GetAt<global::System.IntPtr>(0x490); return __p==global::System.IntPtr.Zero?null:new VR4CutsceneManager_BP_C(__p); } set => SetAt(0x490, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool QTEActive { get => Native.GetPropBool(Pointer, "QTEActive"); set => Native.SetPropBool(Pointer, "QTEActive", value); }
        public bool DebugQTE_ { get => Native.GetPropBool(Pointer, "DebugQTE?"); set => Native.SetPropBool(Pointer, "DebugQTE?", value); }
        public TimerHandle DebugTimer => new TimerHandle(AddrOf(0x4A0));
        public bool ValidAnswer { get => Native.GetPropBool(Pointer, "ValidAnswer"); set => Native.SetPropBool(Pointer, "ValidAnswer", value); }
        public string AnswerKey => Native.GetPropString(Pointer, "AnswerKey"); // FString
        public float AnswerDuration { get => GetAt<float>(0x4C0); set => SetAt(0x4C0, value); }
        public bool TickSyncMedia { get => Native.GetPropBool(Pointer, "TickSyncMedia"); set => Native.SetPropBool(Pointer, "TickSyncMedia", value); }
        public bool VideoCompleted { get => Native.GetPropBool(Pointer, "VideoCompleted"); set => Native.SetPropBool(Pointer, "VideoCompleted", value); }
        public float AudioTime { get => GetAt<float>(0x4C8); set => SetAt(0x4C8, value); }
        public bool SyncingMediaSeek { get => Native.GetPropBool(Pointer, "SyncingMediaSeek"); set => Native.SetPropBool(Pointer, "SyncingMediaSeek", value); }
        public MaterialInterface SceneCaptureMaterial { get { var __p = GetAt<global::System.IntPtr>(0x4D0); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x4D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInterface VideoMaterial { get { var __p = GetAt<global::System.IntPtr>(0x4D8); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x4D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MediaTexture MediaTexture { get { var __p = GetAt<global::System.IntPtr>(0x4E0); return __p==global::System.IntPtr.Zero?null:new MediaTexture(__p); } set => SetAt(0x4E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float AudioStartTime { get => GetAt<float>(0x4E8); set => SetAt(0x4E8, value); }
        public TimerHandle SyncingMediaSeekTimer => new TimerHandle(AddrOf(0x4F0));
        public TimerHandle VideoBackupCompleteTimer => new TimerHandle(AddrOf(0x4F8));
        public float VideoBackupWaitTime { get => GetAt<float>(0x500); set => SetAt(0x500, value); }
        public int TicksSinceInvalidOrStopped { get => GetAt<int>(0x504); set => SetAt(0x504, value); }
        public int RequiredTicksToResolvePlay { get => GetAt<int>(0x508); set => SetAt(0x508, value); }
        public float OverrideTotalTime { get => GetAt<float>(0x50C); set => SetAt(0x50C, value); }
        public TArray<global::System.IntPtr> SkippingKeys => new TArray<global::System.IntPtr>(AddrOf(0x510)); // TArray<FString>
        public TopRing_C TopRing { get { var __p = GetAt<global::System.IntPtr>(0x520); return __p==global::System.IntPtr.Zero?null:new TopRing_C(__p); } set => SetAt(0x520, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void Int_ExternalSubtitle(global::System.IntPtr Text, float Duration, bool Callback)
        {
            var __pb = new ParamBuffer(29);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            __pb.Set(0x18, Duration);
            __pb.Set<byte>(0x1C, (byte)(Callback?1:0));
            CallRaw("Int_ExternalSubtitle", __pb.Bytes);
        }
        public void Int_PrepForEnd(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("Int_PrepForEnd", __pb.Bytes);
        }
        public void IsShowingMessage(bool Is_Displaying)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Is_Displaying?1:0));
            CallRaw("IsShowingMessage", __pb.Bytes);
        }
        public void ValidKey_(global::System.IntPtr ItemToFind, bool Valid_)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, ItemToFind);
            __pb.Set<byte>(0x10, (byte)(Valid_?1:0));
            CallRaw("ValidKey?", __pb.Bytes);
        }
        public void GetSkipOverrides()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GetSkipOverrides", __pb.Bytes);
        }
        public bool CanPauseMedia()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("CanPauseMedia", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void IsMediaInvalidOrStopped(bool Return_Value)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Return_Value?1:0));
            CallRaw("IsMediaInvalidOrStopped", __pb.Bytes);
        }
        public void OnHasInputFocusChanged(bool HasFocus)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(HasFocus?1:0));
            CallRaw("OnHasInputFocusChanged", __pb.Bytes);
        }
        public void ExistingQteCheck()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ExistingQteCheck", __pb.Bytes);
        }
        public void PrepForEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PrepForEnd", __pb.Bytes);
        }
        public void SetVideo(FileMediaSource PC, FileMediaSource Android, SoundBase Audio)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, PC);
            __pb.SetObject(0x8, Android);
            __pb.SetObject(0x10, Audio);
            CallRaw("SetVideo", __pb.Bytes);
        }
        public void CutsceneSkipped()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CutsceneSkipped", __pb.Bytes);
        }
        public void SetHeadlockedScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetHeadlockedScreen", __pb.Bytes);
        }
        public void DisplayMessage(global::System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            CallRaw("DisplayMessage", __pb.Bytes);
        }
        public void DemoEnding()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DemoEnding", __pb.Bytes);
        }
        public void StartSloMo(EVR4CommandButton Button, EActionButtonType Action, EQTEId QTEId, float SpikeDuration, float SpikeScale, float IconDelay)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<byte>(0x0, (byte)Button);
            __pb.Set<byte>(0x1, (byte)Action);
            __pb.Set<byte>(0x2, (byte)QTEId);
            __pb.Set(0x4, SpikeDuration);
            __pb.Set(0x8, SpikeScale);
            __pb.Set(0xC, IconDelay);
            CallRaw("StartSloMo", __pb.Bytes);
        }
        public void CheckKeyOverride(global::System.IntPtr Key, bool ValidKey)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            __pb.Set<byte>(0x10, (byte)(ValidKey?1:0));
            CallRaw("CheckKeyOverride", __pb.Bytes);
        }
        public void GetSubtitleOverrides(global::System.IntPtr Cutscene)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, Cutscene);
            CallRaw("GetSubtitleOverrides", __pb.Bytes);
        }
        public void UserConstructionScript()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UserConstructionScript", __pb.Bytes);
        }
        public void Timeline_FadeScreen__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FadeScreen__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_FadeScreen__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FadeScreen__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_InfoRing__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_InfoRing__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_InfoRing__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_InfoRing__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_ShowSpikes__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ShowSpikes__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ShowSpikes__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ShowSpikes__UpdateFunc", __pb.Bytes);
        }
        public void OnLoaded_3F2AE4044CFE97957F91C39585DAB9A4(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_3F2AE4044CFE97957F91C39585DAB9A4", __pb.Bytes);
        }
        public void OnLoaded_2413608243CCDA44B58F3C854C761BD6(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_2413608243CCDA44B58F3C854C761BD6", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void UpdateCameraRendering(bool screenOn)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(screenOn?1:0));
            CallRaw("UpdateCameraRendering", __pb.Bytes);
        }
        public void DisplaySubtitle(global::System.IntPtr Key, float Duration)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            __pb.Set(0x10, Duration);
            CallRaw("DisplaySubtitle", __pb.Bytes);
        }
        public void HideSubtitle()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideSubtitle", __pb.Bytes);
        }
        public void OverrideLoop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OverrideLoop", __pb.Bytes);
        }
        public void DisplaySubtitleOverride(global::System.IntPtr Key, float Duration)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            __pb.Set(0x10, Duration);
            CallRaw("DisplaySubtitleOverride", __pb.Bytes);
        }
        public void EmptyEvent()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EmptyEvent", __pb.Bytes);
        }
        public void NewName(global::System.IntPtr ActiveCutscene)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, ActiveCutscene);
            CallRaw("NewName", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void FadeOutScreen(float Duration)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Duration);
            CallRaw("FadeOutScreen", __pb.Bytes);
        }
        public void FadeInScreen(float Duration)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Duration);
            CallRaw("FadeInScreen", __pb.Bytes);
        }
        public void StartLogoTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartLogoTimer", __pb.Bytes);
        }
        public void BeginLogoSequence()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BeginLogoSequence", __pb.Bytes);
        }
        public void StartR120Timer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartR120Timer", __pb.Bytes);
        }
        public void StartR120Fade()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartR120Fade", __pb.Bytes);
        }
        public void VideoComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("VideoComplete", __pb.Bytes);
        }
        public void UpdateSubtitleOption(bool Enabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            CallRaw("UpdateSubtitleOption", __pb.Bytes);
        }
        public void OverrideTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OverrideTimerExpired", __pb.Bytes);
        }
        public void PauseMedia()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PauseMedia", __pb.Bytes);
        }
        public void ResumeMedia()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResumeMedia", __pb.Bytes);
        }
        public void Show_Command()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Show Command", __pb.Bytes);
        }
        public void Hide_Command()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hide Command", __pb.Bytes);
        }
        public void ShowSpikes(float Duration)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Duration);
            CallRaw("ShowSpikes", __pb.Bytes);
        }
        public void HideSpikes()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideSpikes", __pb.Bytes);
        }
        public void DisplayCommand(bool Show, global::System.IntPtr Message, EVR4CommandButton Command, EActionButtonType actionType, EQTEId QTEId)
        {
            var __pb = new ParamBuffer(35);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            __pb.Set<global::System.IntPtr>(0x8, Message);
            __pb.Set<byte>(0x20, (byte)Command);
            __pb.Set<byte>(0x21, (byte)actionType);
            __pb.Set<byte>(0x22, (byte)QTEId);
            CallRaw("DisplayCommand", __pb.Bytes);
        }
        public void IconDelayExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IconDelayExpired", __pb.Bytes);
        }
        public void BeginEndGameSequence()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BeginEndGameSequence", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void PlayerDied(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("PlayerDied", __pb.Bytes);
        }
        public void QteSucceeded(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("QteSucceeded", __pb.Bytes);
        }
        public void QteFailed(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("QteFailed", __pb.Bytes);
        }
        public void QteMotionFailed(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("QteMotionFailed", __pb.Bytes);
        }
        public void DelayedResultCheck()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DelayedResultCheck", __pb.Bytes);
        }
        public void OnGainedInputFocus(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("OnGainedInputFocus", __pb.Bytes);
        }
        public void OnLostInputFocus(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("OnLostInputFocus", __pb.Bytes);
        }
        public void DebugTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DebugTimerExpired", __pb.Bytes);
        }
        public void AnswerCheck()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AnswerCheck", __pb.Bytes);
        }
        public void SyncMediaState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SyncMediaState", __pb.Bytes);
        }
        public void OnAudioPlaybackPercent(SoundWave PlayingSoundWave, float PlaybackPercent)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, PlayingSoundWave);
            __pb.Set(0x8, PlaybackPercent);
            CallRaw("OnAudioPlaybackPercent", __pb.Bytes);
        }
        public void ResetMedia()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetMedia", __pb.Bytes);
        }
        public void ResetFadeOnDelay(float Duration)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Duration);
            CallRaw("ResetFadeOnDelay", __pb.Bytes);
        }
        public void SyncingMediaSeekComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SyncingMediaSeekComplete", __pb.Bytes);
        }
        public void VideoBackupComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("VideoBackupComplete", __pb.Bytes);
        }
        public void ResetSkippingBool()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetSkippingBool", __pb.Bytes);
        }
        public void UpdateTopRing(bool Visible, bool UseManualRedraw)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            __pb.Set<byte>(0x1, (byte)(UseManualRedraw?1:0));
            CallRaw("UpdateTopRing", __pb.Bytes);
        }
        public void ResetQTE()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetQTE", __pb.Bytes);
        }
        public void ExternalSubtitle(global::System.IntPtr Text, float Duration)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            __pb.Set(0x18, Duration);
            CallRaw("ExternalSubtitle", __pb.Bytes);
        }
        public void ExecuteUbergraph_CutsceneTheatreBox(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_CutsceneTheatreBox", __pb.Bytes);
        }
        public void EndGameActorReady__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndGameActorReady__DelegateSignature", __pb.Bytes);
        }
    }

}
