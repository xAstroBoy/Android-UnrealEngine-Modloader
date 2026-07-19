// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Frontend/FrontendManager
using System;

namespace UEModLoader.Game
{
    public class FrontendManager_C : VR4UIScreen
    {
        public const string UeClassName = "FrontendManager_C";
        public FrontendManager_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new FrontendManager_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FrontendManager_C(p);
        public static FrontendManager_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FrontendManager_C(o.Pointer); }
        public static FrontendManager_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FrontendManager_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FrontendManager_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public SynthLoopWithIntroComponent SynthLoopWithIntroMERCTab { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new SynthLoopWithIntroComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SynthLoopWithIntroComponent SynthLoopWithIntroMERC { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SynthLoopWithIntroComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent floor { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent FloorParent { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AudioComponent MenuMusic { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent MenuRoot { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Fade_Alpha_C9E68D2E4711CA0A29CF1691AC3B0B45 { get => GetAt<float>(0x290); set => SetAt(0x290, value); }
        public byte Timeline_Fade__Direction_C9E68D2E4711CA0A29CF1691AC3B0B45 { get => GetAt<byte>(0x294); set => SetAt(0x294, value); }
        public TimelineComponent Timeline_Fade { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LevelStreamingDynamic background { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new LevelStreamingDynamic(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4MenuPawn_BP_C MenuPawnBp { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new VR4MenuPawn_BP_C(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool SkipIntro { get => Native.GetPropBool(Pointer, "SkipIntro"); set => Native.SetPropBool(Pointer, "SkipIntro", value); }
        public bool LogoIntroComplete { get => Native.GetPropBool(Pointer, "LogoIntroComplete"); set => Native.SetPropBool(Pointer, "LogoIntroComplete", value); }
        public bool ReadyForStart { get => Native.GetPropBool(Pointer, "ReadyForStart"); set => Native.SetPropBool(Pointer, "ReadyForStart", value); }
        public bool SkipLogo { get => Native.GetPropBool(Pointer, "SkipLogo"); set => Native.SetPropBool(Pointer, "SkipLogo", value); }
        public Bio4_BP_C Bio4BP { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new Bio4_BP_C(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vector SpawnLocation => new Vector(AddrOf(0x2C0));
        public Rotator SpawnRotation => new Rotator(AddrOf(0x2CC));
        public EFixedFoveatedRenderingLevel OldFoveatedSetting { get => (EFixedFoveatedRenderingLevel)GetAt<byte>(0x2D8); set => SetAt(0x2D8, (byte)value); }
        public bool doSavesExist_ { get => Native.GetPropBool(Pointer, "doSavesExist?"); set => Native.SetPropBool(Pointer, "doSavesExist?", value); }
        public bool skipped { get => Native.GetPropBool(Pointer, "skipped"); set => Native.SetPropBool(Pointer, "skipped", value); }
        public bool allowButtonInput_ { get => Native.GetPropBool(Pointer, "allowButtonInput?"); set => Native.SetPropBool(Pointer, "allowButtonInput?", value); }
        public float InputHoldTime { get => GetAt<float>(0x2DC); set => SetAt(0x2DC, value); }
        public TimerHandle LTriggerTimer => new TimerHandle(AddrOf(0x2E0));
        public TimerHandle RTriggerTimer => new TimerHandle(AddrOf(0x2E8));
        public TimerHandle LGripTimer => new TimerHandle(AddrOf(0x2F0));
        public TimerHandle RGripTimer => new TimerHandle(AddrOf(0x2F8));
        public int NewGamePlusSlot { get => GetAt<int>(0x300); set => SetAt(0x300, value); }
        public VR4PlayerPawn OldPawn { get { var __p = GetAt<global::System.IntPtr>(0x308); return __p==global::System.IntPtr.Zero?null:new VR4PlayerPawn(__p); } set => SetAt(0x308, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float FloorZ { get => GetAt<float>(0x310); set => SetAt(0x310, value); }
        public Actor LogoActor { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr LogoSkip => AddrOf(0x320); // 
        public global::System.IntPtr FrontendStart => AddrOf(0x330); // 
        public Actor PauseMenuActor { get { var __p = GetAt<global::System.IntPtr>(0x340); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x340, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor LoadManagerActor { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LevelStreamingDynamic PauseMenuLevel { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new LevelStreamingDynamic(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Rotator ViewRotation => new Rotator(AddrOf(0x358));
        public LevelStreamingDynamic MercMenuLevel { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new LevelStreamingDynamic(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EMercenariesStage MercLevel { get => (EMercenariesStage)GetAt<byte>(0x370); set => SetAt(0x370, (byte)value); }
        public EBio4PlayerType MercCharacter { get => (EBio4PlayerType)GetAt<byte>(0x371); set => SetAt(0x371, (byte)value); }
        public bool returnedFromMerc { get => Native.GetPropBool(Pointer, "returnedFromMerc"); set => Native.SetPropBool(Pointer, "returnedFromMerc", value); }
        public void FE_SwapFromMercTabMusic(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_SwapFromMercTabMusic", __pb.Bytes);
        }
        public void FE_SwapToMercTabMusic(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_SwapToMercTabMusic", __pb.Bytes);
        }
        public void FE_UnloadMerc(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_UnloadMerc", __pb.Bytes);
        }
        public void FE_MercSelectionMade(EBio4PlayerType Character, EMercenariesStage Level, int Mode, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<byte>(0x0, (byte)Character);
            __pb.Set<byte>(0x1, (byte)Level);
            __pb.Set(0x4, Mode);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("FE_MercSelectionMade", __pb.Bytes);
        }
        public void FE_LoadMerc(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_LoadMerc", __pb.Bytes);
        }
        public void FE_DataReady(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_DataReady", __pb.Bytes);
        }
        public void FE_IntroSelectionMade(bool IntroSelection, int CurrentNewGamePlusSlot, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<byte>(0x0, (byte)(IntroSelection?1:0));
            __pb.Set(0x4, CurrentNewGamePlusSlot);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("FE_IntroSelectionMade", __pb.Bytes);
        }
        public void FE_GameLoaded(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_GameLoaded", __pb.Bytes);
        }
        public void FE_SavesExist_(bool SavesExist)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SavesExist?1:0));
            CallRaw("FE_SavesExist?", __pb.Bytes);
        }
        public void SetPrematchVars()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetPrematchVars", __pb.Bytes);
        }
        public void ReturnedFromMercenaries_(bool TRUE)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(TRUE?1:0));
            CallRaw("ReturnedFromMercenaries?", __pb.Bytes);
        }
        public void StreamUnloadMercLevel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StreamUnloadMercLevel", __pb.Bytes);
        }
        public void StreamLoadMercLevel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StreamLoadMercLevel", __pb.Bytes);
        }
        public void StreamUnloadLevel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StreamUnloadLevel", __pb.Bytes);
        }
        public void StreamLoadLevel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StreamLoadLevel", __pb.Bytes);
        }
        public void CheckForExistingSaves()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckForExistingSaves", __pb.Bytes);
        }
        public void UpdateDebugInputHandedness()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateDebugInputHandedness", __pb.Bytes);
        }
        public void LevelOverrideSet(bool DebugLevelSet)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(DebugLevelSet?1:0));
            CallRaw("LevelOverrideSet", __pb.Bytes);
        }
        public void GetCurrentSeatedMode()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GetCurrentSeatedMode", __pb.Bytes);
        }
        public void Try_Reset_Anchor()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Try Reset Anchor", __pb.Bytes);
        }
        public void Timeline_Fade__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Fade__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Fade__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Fade__UpdateFunc", __pb.Bytes);
        }
        public void InpActEvt_SpaceBar_K2Node_InputKeyEvent_12(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_SpaceBar_K2Node_InputKeyEvent_12", __pb.Bytes);
        }
        public void InpActEvt_L_K2Node_InputKeyEvent_11(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_L_K2Node_InputKeyEvent_11", __pb.Bytes);
        }
        public void InpActEvt_Button_X_K2Node_InputActionEvent_12(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button X_K2Node_InputActionEvent_12", __pb.Bytes);
        }
        public void InpActEvt_Button_Y_K2Node_InputActionEvent_11(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button Y_K2Node_InputActionEvent_11", __pb.Bytes);
        }
        public void InpActEvt_Button_B_K2Node_InputActionEvent_10(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button B_K2Node_InputActionEvent_10", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_9(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_9", __pb.Bytes);
        }
        public void InpActEvt__L__Trigger_K2Node_InputActionEvent_8(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Trigger_K2Node_InputActionEvent_8", __pb.Bytes);
        }
        public void InpActEvt__L__Trigger_K2Node_InputActionEvent_7(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Trigger_K2Node_InputActionEvent_7", __pb.Bytes);
        }
        public void InpActEvt__R__Trigger_K2Node_InputActionEvent_6(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Trigger_K2Node_InputActionEvent_6", __pb.Bytes);
        }
        public void InpActEvt__R__Trigger_K2Node_InputActionEvent_5(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Trigger_K2Node_InputActionEvent_5", __pb.Bytes);
        }
        public void InpActEvt__L__Grip_K2Node_InputActionEvent_4(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Grip_K2Node_InputActionEvent_4", __pb.Bytes);
        }
        public void InpActEvt__L__Grip_K2Node_InputActionEvent_3(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Grip_K2Node_InputActionEvent_3", __pb.Bytes);
        }
        public void InpActEvt__R__Grip_K2Node_InputActionEvent_2(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Grip_K2Node_InputActionEvent_2", __pb.Bytes);
        }
        public void InpActEvt__R__Grip_K2Node_InputActionEvent_1(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Grip_K2Node_InputActionEvent_1", __pb.Bytes);
        }
        public void InpActEvt_Pause_K2Node_InputActionEvent_0(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Pause_K2Node_InputActionEvent_0", __pb.Bytes);
        }
        public void OnLoaded_0C79F06A46D06776E1DB53870E0B3AF7(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_0C79F06A46D06776E1DB53870E0B3AF7", __pb.Bytes);
        }
        public void OnLoaded_894B37A24BF040FC737D4590B87CAB9E(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_894B37A24BF040FC737D4590B87CAB9E", __pb.Bytes);
        }
        public void InpActEvt_N_K2Node_InputKeyEvent_10(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_N_K2Node_InputKeyEvent_10", __pb.Bytes);
        }
        public void InpActEvt_M_K2Node_InputKeyEvent_9(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_M_K2Node_InputKeyEvent_9", __pb.Bytes);
        }
        public void InpActEvt_NumPadZero_K2Node_InputKeyEvent_8(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_NumPadZero_K2Node_InputKeyEvent_8", __pb.Bytes);
        }
        public void InpActEvt_NumPadOne_K2Node_InputKeyEvent_7(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_NumPadOne_K2Node_InputKeyEvent_7", __pb.Bytes);
        }
        public void InpActEvt_NumPadTwo_K2Node_InputKeyEvent_6(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_NumPadTwo_K2Node_InputKeyEvent_6", __pb.Bytes);
        }
        public void InpActEvt_NumPadThree_K2Node_InputKeyEvent_5(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_NumPadThree_K2Node_InputKeyEvent_5", __pb.Bytes);
        }
        public void InpActEvt_NumPadFour_K2Node_InputKeyEvent_4(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_NumPadFour_K2Node_InputKeyEvent_4", __pb.Bytes);
        }
        public void InpActEvt_NumPadSeven_K2Node_InputKeyEvent_3(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_NumPadSeven_K2Node_InputKeyEvent_3", __pb.Bytes);
        }
        public void InpActEvt_NumPadEight_K2Node_InputKeyEvent_2(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_NumPadEight_K2Node_InputKeyEvent_2", __pb.Bytes);
        }
        public void InpActEvt_NumPadNine_K2Node_InputKeyEvent_1(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_NumPadNine_K2Node_InputKeyEvent_1", __pb.Bytes);
        }
        public void InpActEvt_NumPadSix_K2Node_InputKeyEvent_0(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_NumPadSix_K2Node_InputKeyEvent_0", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void FadeIn(float Time)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Time);
            CallRaw("FadeIn", __pb.Bytes);
        }
        public void FadeOut(float Time)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Time);
            CallRaw("FadeOut", __pb.Bytes);
        }
        public void SpawnMainMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnMainMenu", __pb.Bytes);
        }
        public void BackgroundLoaded()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BackgroundLoaded", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void IntroSelectionMaasdfasdfde(bool IntroSelection, int CurrentNewGamePlusSlot)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)(IntroSelection?1:0));
            __pb.Set(0x4, CurrentNewGamePlusSlot);
            CallRaw("IntroSelectionMaasdfasdfde", __pb.Bytes);
        }
        public void PlayVideo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayVideo", __pb.Bytes);
        }
        public void VideoComplete(Actor DestroyedActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, DestroyedActor);
            CallRaw("VideoComplete", __pb.Bytes);
        }
        public void LogoReady()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("LogoReady", __pb.Bytes);
        }
        public void AllLogoSkipped()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AllLogoSkipped", __pb.Bytes);
        }
        public void SpawnLoadGameManager()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnLoadGameManager", __pb.Bytes);
        }
        public void TriggerGripPressed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TriggerGripPressed", __pb.Bytes);
        }
        public void IntroSelectionMade(bool IntroSelection, int CurrentNewGameSlot)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)(IntroSelection?1:0));
            __pb.Set(0x4, CurrentNewGameSlot);
            CallRaw("IntroSelectionMade", __pb.Bytes);
        }
        public void GameLoaded()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GameLoaded", __pb.Bytes);
        }
        public void SaveMenuReady(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("SaveMenuReady", __pb.Bytes);
        }
        public void SwapToMercMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SwapToMercMenu", __pb.Bytes);
        }
        public void SwapBackToMainMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SwapBackToMainMenu", __pb.Bytes);
        }
        public void StartMerc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartMerc", __pb.Bytes);
        }
        public void ExecuteUbergraph_FrontendManager(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_FrontendManager", __pb.Bytes);
        }
        public void FrontendStart__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FrontendStart__DelegateSignature", __pb.Bytes);
        }
        public void LogoSkip__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("LogoSkip__DelegateSignature", __pb.Bytes);
        }
    }

}
