// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Cinematics/EndGameFlow/EndGameFlow_CreditsUnlocks_BP
using System;

namespace UEModLoader.Game
{
    public class EndGameFlow_CreditsUnlocks_BP_C : VR4UIScreen
    {
        public const string UeClassName = "EndGameFlow_CreditsUnlocks_BP_C";
        public EndGameFlow_CreditsUnlocks_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new EndGameFlow_CreditsUnlocks_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EndGameFlow_CreditsUnlocks_BP_C(p);
        public static EndGameFlow_CreditsUnlocks_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EndGameFlow_CreditsUnlocks_BP_C(o.Pointer); }
        public static EndGameFlow_CreditsUnlocks_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EndGameFlow_CreditsUnlocks_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EndGameFlow_CreditsUnlocks_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent Widget_Results { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent CreditsUIScreen_BP { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent PointLight1 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent PointLight { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Scene { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Unlocks { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIComponent VR4UI { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new VR4UIComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent NextButton { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Outro_Alpha_D8474E5C420077E627478F869A4BAF63 { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public byte Timeline_Outro__Direction_D8474E5C420077E627478F869A4BAF63 { get => GetAt<byte>(0x2A4); set => SetAt(0x2A4, value); }
        public TimelineComponent Timeline_Outro { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Intro_BlackCover_4C1D914643098EF421A6CEA881C4175A { get => GetAt<float>(0x2B0); set => SetAt(0x2B0, value); }
        public float Timeline_Intro_Alpha_Group_5_4C1D914643098EF421A6CEA881C4175A { get => GetAt<float>(0x2B4); set => SetAt(0x2B4, value); }
        public float Timeline_Intro_Alpha_Group_4_4C1D914643098EF421A6CEA881C4175A { get => GetAt<float>(0x2B8); set => SetAt(0x2B8, value); }
        public float Timeline_Intro_Alpha_Group_3_4C1D914643098EF421A6CEA881C4175A { get => GetAt<float>(0x2BC); set => SetAt(0x2BC, value); }
        public float Timeline_Intro_Alpha_Group_2_4C1D914643098EF421A6CEA881C4175A { get => GetAt<float>(0x2C0); set => SetAt(0x2C0, value); }
        public float Timeline_Intro_Alpha_Group_1_4C1D914643098EF421A6CEA881C4175A { get => GetAt<float>(0x2C4); set => SetAt(0x2C4, value); }
        public float Timeline_Intro_Alpha_Box_4C1D914643098EF421A6CEA881C4175A { get => GetAt<float>(0x2C8); set => SetAt(0x2C8, value); }
        public float Timeline_Intro_Alpha_Blur_1_4C1D914643098EF421A6CEA881C4175A { get => GetAt<float>(0x2CC); set => SetAt(0x2CC, value); }
        public byte Timeline_Intro__Direction_4C1D914643098EF421A6CEA881C4175A { get => GetAt<byte>(0x2D0); set => SetAt(0x2D0, value); }
        public TimelineComponent Timeline_Intro { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_NextPrompt_Alpha_15F890914247C8D12C17E984BCFAB05F { get => GetAt<float>(0x2E0); set => SetAt(0x2E0, value); }
        public byte Timeline_NextPrompt__Direction_15F890914247C8D12C17E984BCFAB05F { get => GetAt<byte>(0x2E4); set => SetAt(0x2E4, value); }
        public TimelineComponent Timeline_NextPrompt { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Fade_Alpha_DFBB070742FE188F2B51829D5C0B1736 { get => GetAt<float>(0x2F0); set => SetAt(0x2F0, value); }
        public byte Timeline_Fade__Direction_DFBB070742FE188F2B51829D5C0B1736 { get => GetAt<byte>(0x2F4); set => SetAt(0x2F4, value); }
        public TimelineComponent Timeline_Fade { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr EndGameLoopBPComplete => AddrOf(0x300); // 
        public bool areCreditsPlaying_ { get => Native.GetPropBool(Pointer, "areCreditsPlaying?"); set => Native.SetPropBool(Pointer, "areCreditsPlaying?", value); }
        public UI_Unlocks_Widget_C UnlocksWidget { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new UI_Unlocks_Widget_C(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public CutsceneTheatreBox_C CutsceneTheatreBox { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new CutsceneTheatreBox_C(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public float FadeLength { get => GetAt<float>(0x328); set => SetAt(0x328, value); }
        public VR4CutscenePlayerPawn_BP_C CutscenePawn { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new VR4CutscenePlayerPawn_BP_C(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public bool Debug { get => Native.GetPropBool(Pointer, "Debug"); set => Native.SetPropBool(Pointer, "Debug", value); }
        public UI_ChapterSummary_NextButton_BP_C RefNextButton { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new UI_ChapterSummary_NextButton_BP_C(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4PlayerPawn OldPawn { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new VR4PlayerPawn(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public Transform anchor => new Transform(AddrOf(0x350));
        public VR4MenuPawn_BP_C MenuPawn { get { var __p = GetAt<System.IntPtr>(0x380); return __p==System.IntPtr.Zero?null:new VR4MenuPawn_BP_C(__p); } set => SetAt(0x380, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Credits_Header_Widget_C CreditsWidget { get { var __p = GetAt<System.IntPtr>(0x388); return __p==System.IntPtr.Zero?null:new UI_Credits_Header_Widget_C(__p); } set => SetAt(0x388, value?.Pointer ?? System.IntPtr.Zero); }
        public float CreditsScrollSpeed { get => GetAt<float>(0x390); set => SetAt(0x390, value); }
        public CreditsUIScreen_BP_C CreditsActor { get { var __p = GetAt<System.IntPtr>(0x398); return __p==System.IntPtr.Zero?null:new CreditsUIScreen_BP_C(__p); } set => SetAt(0x398, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_ChapterSummary_EndGameResults_Widget_C ResultsWidget { get { var __p = GetAt<System.IntPtr>(0x3A0); return __p==System.IntPtr.Zero?null:new UI_ChapterSummary_EndGameResults_Widget_C(__p); } set => SetAt(0x3A0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool showingResults { get => Native.GetPropBool(Pointer, "showingResults"); set => Native.SetPropBool(Pointer, "showingResults", value); }
        public ChapterSummaryStats FinalResults => new ChapterSummaryStats(AddrOf(0x3B0));
        public AudioComponent SummaryMusic { get { var __p = GetAt<System.IntPtr>(0x3F0); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x3F0, value?.Pointer ?? System.IntPtr.Zero); }
        public AudioComponent MusicPostCredits { get { var __p = GetAt<System.IntPtr>(0x3F8); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x3F8, value?.Pointer ?? System.IntPtr.Zero); }
        public AudioComponent CreditsMusic { get { var __p = GetAt<System.IntPtr>(0x400); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x400, value?.Pointer ?? System.IntPtr.Zero); }
        public SoundBase CurrentSound { get { var __p = GetAt<System.IntPtr>(0x408); return __p==System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x408, value?.Pointer ?? System.IntPtr.Zero); }
        public SoundBase NewVar { get { var __p = GetAt<System.IntPtr>(0x410); return __p==System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x410, value?.Pointer ?? System.IntPtr.Zero); }
        public float FloorZ { get => GetAt<float>(0x418); set => SetAt(0x418, value); }
        public Transform ExpectedBodyTransform => new Transform(AddrOf(0x420));
        public void HideButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideButton", __pb.Bytes);
        }
        public void ShowButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowButton", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
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
        public void Timeline_NextPrompt__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_NextPrompt__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_NextPrompt__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_NextPrompt__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Intro__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Intro__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Intro__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Intro__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Outro__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Outro__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Outro__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Outro__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void CreditsComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreditsComplete", __pb.Bytes);
        }
        public void AllUnlocksShown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AllUnlocksShown", __pb.Bytes);
        }
        public void FadeIn(float PlayRate)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, PlayRate);
            CallRaw("FadeIn", __pb.Bytes);
        }
        public void FadeOut(float PlayRate)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, PlayRate);
            CallRaw("FadeOut", __pb.Bytes);
        }
        public void StartCredits()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartCredits", __pb.Bytes);
        }
        public void NextButtonPressed(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("NextButtonPressed", __pb.Bytes);
        }
        public void NewUnlockShown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("NewUnlockShown", __pb.Bytes);
        }
        public void SwapPawns(EPlayerPawn pawnType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)pawnType);
            CallRaw("SwapPawns", __pb.Bytes);
        }
        public void RevealButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RevealButton", __pb.Bytes);
        }
        public void RemoveButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RemoveButton", __pb.Bytes);
        }
        public void CheckUnlocks()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckUnlocks", __pb.Bytes);
        }
        public void ShowEndResults()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowEndResults", __pb.Bytes);
        }
        public void HideEndResults()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideEndResults", __pb.Bytes);
        }
        public void PlayCreditMusic()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayCreditMusic", __pb.Bytes);
        }
        public void StopCreditsMusic()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopCreditsMusic", __pb.Bytes);
        }
        public void PlayTypewriterMusic()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayTypewriterMusic", __pb.Bytes);
        }
        public void StopTypewriterMusic()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopTypewriterMusic", __pb.Bytes);
        }
        public void ExecuteUbergraph_EndGameFlow_CreditsUnlocks_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_EndGameFlow_CreditsUnlocks_BP", __pb.Bytes);
        }
        public void EndGameLoopBPComplete__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndGameLoopBPComplete__DelegateSignature", __pb.Bytes);
        }
    }

}
