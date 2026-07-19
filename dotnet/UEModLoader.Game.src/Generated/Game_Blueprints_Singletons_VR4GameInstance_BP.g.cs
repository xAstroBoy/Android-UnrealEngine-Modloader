// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Singletons/VR4GameInstance_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GameInstance_BP_C : VR4GameInstance
    {
        public const string UeClassName = "VR4GameInstance_BP_C";
        public VR4GameInstance_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4GameInstance_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4GameInstance_BP_C(p);
        public static VR4GameInstance_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GameInstance_BP_C(o.Pointer); }
        public static VR4GameInstance_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GameInstance_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GameInstance_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x1D0));
        public int DebugMode { get => GetAt<int>(0x1D8); set => SetAt(0x1D8, value); }
        public int DemoMode { get => GetAt<int>(0x1DC); set => SetAt(0x1DC, value); }
        public int QuickStart { get => GetAt<int>(0x1E0); set => SetAt(0x1E0, value); }
        public string StartLevelOverride => Native.GetPropName(Pointer, "StartLevelOverride"); // FName
        public FName StartLevelOverride_Raw { get => GetAt<FName>(0x1E4); set => SetAt(0x1E4, value); }
        public bool HasOpenedPauseMenu { get => Native.GetPropBool(Pointer, "HasOpenedPauseMenu"); set => Native.SetPropBool(Pointer, "HasOpenedPauseMenu", value); }
        public bool IntroActive { get => Native.GetPropBool(Pointer, "IntroActive"); set => Native.SetPropBool(Pointer, "IntroActive", value); }
        public bool HeadLockedCutscenes { get => Native.GetPropBool(Pointer, "HeadLockedCutscenes"); set => Native.SetPropBool(Pointer, "HeadLockedCutscenes", value); }
        public bool UseNewWeaponWheel { get => Native.GetPropBool(Pointer, "UseNewWeaponWheel"); set => Native.SetPropBool(Pointer, "UseNewWeaponWheel", value); }
        public bool FrontendPreviouslyLoaded { get => Native.GetPropBool(Pointer, "FrontendPreviouslyLoaded"); set => Native.SetPropBool(Pointer, "FrontendPreviouslyLoaded", value); }
        public byte PlatformOverride { get => GetAt<byte>(0x1F1); set => SetAt(0x1F1, value); }
        public bool UseFlatCutsceneScreen { get => Native.GetPropBool(Pointer, "UseFlatCutsceneScreen"); set => Native.SetPropBool(Pointer, "UseFlatCutsceneScreen", value); }
        public bool PlayingManualTutorialActive { get => Native.GetPropBool(Pointer, "PlayingManualTutorialActive"); set => Native.SetPropBool(Pointer, "PlayingManualTutorialActive", value); }
        public bool AshleyTransitionActive { get => Native.GetPropBool(Pointer, "AshleyTransitionActive"); set => Native.SetPropBool(Pointer, "AshleyTransitionActive", value); }
        public bool ShowQteInfo { get => Native.GetPropBool(Pointer, "ShowQteInfo"); set => Native.SetPropBool(Pointer, "ShowQteInfo", value); }
        public EPauseMenuScreen LastPauseMenuScreen { get => (EPauseMenuScreen)GetAt<byte>(0x1F6); set => SetAt(0x1F6, (byte)value); }
        public string LastPauseMenuSubScreen => Native.GetPropName(Pointer, "LastPauseMenuSubScreen"); // FName
        public FName LastPauseMenuSubScreen_Raw { get => GetAt<FName>(0x1F8); set => SetAt(0x1F8, value); }
        public float LastPauseMenuPosition { get => GetAt<float>(0x200); set => SetAt(0x200, value); }
        public string LastPauseMenuSubSubScreen => Native.GetPropName(Pointer, "LastPauseMenuSubSubScreen"); // FName
        public FName LastPauseMenuSubSubScreen_Raw { get => GetAt<FName>(0x204); set => SetAt(0x204, value); }
        public byte FirstMercMenuOverride { get => GetAt<byte>(0x20C); set => SetAt(0x20C, value); }
        public EBio4PlayerType LastMercCharacter { get => (EBio4PlayerType)GetAt<byte>(0x20D); set => SetAt(0x20D, (byte)value); }
        public EMercenariesStage LastMercStage { get => (EMercenariesStage)GetAt<byte>(0x20E); set => SetAt(0x20E, (byte)value); }
        public TArray<global::System.IntPtr> SessionNotifications => new TArray<global::System.IntPtr>(AddrOf(0x210)); // TArray<FName>
        public int PrematchChallengeStars { get => GetAt<int>(0x220); set => SetAt(0x220, value); }
        public int PrematchTopScore { get => GetAt<int>(0x224); set => SetAt(0x224, value); }
        public int LastSelectedChallenge { get => GetAt<int>(0x228); set => SetAt(0x228, value); }
        public int PrematchTotalScore { get => GetAt<int>(0x22C); set => SetAt(0x22C, value); }
        public bool CallLoadGame()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("CallLoadGame", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public bool CallSaveGame()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("CallSaveGame", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void Initialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void ReceiveInit()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveInit", __pb.Bytes);
        }
        public void OnWorldTimeScaleUpdated(float worldTimeScale)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, worldTimeScale);
            CallRaw("OnWorldTimeScaleUpdated", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4GameInstance_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4GameInstance_BP", __pb.Bytes);
        }
    }

}
