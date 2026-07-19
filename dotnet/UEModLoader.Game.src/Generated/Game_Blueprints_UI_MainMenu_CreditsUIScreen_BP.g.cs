// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/CreditsUIScreen_BP
using System;

namespace UEModLoader.Game
{
    public class CreditsUIScreen_BP_C : VR4UIScreen
    {
        public const string UeClassName = "CreditsUIScreen_BP_C";
        public CreditsUIScreen_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new CreditsUIScreen_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new CreditsUIScreen_BP_C(p);
        public static CreditsUIScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CreditsUIScreen_BP_C(o.Pointer); }
        public static CreditsUIScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CreditsUIScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CreditsUIScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent CreditWidget { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ImageSwap_Alpha_63AD8F3647CE7AAF5EFF9D820F10B48A { get => GetAt<float>(0x268); set => SetAt(0x268, value); }
        public byte Timeline_ImageSwap__Direction_63AD8F3647CE7AAF5EFF9D820F10B48A { get => GetAt<byte>(0x26C); set => SetAt(0x26C, value); }
        public TimelineComponent Timeline_ImageSwap { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ImageFade_Alpha_E2C0D32C4311878E7E29A7A2C5F25DE1 { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public byte Timeline_ImageFade__Direction_E2C0D32C4311878E7E29A7A2C5F25DE1 { get => GetAt<byte>(0x27C); set => SetAt(0x27C, value); }
        public TimelineComponent Timeline_ImageFade { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Fade_Alpha_9E8AB98349CE01BBC2F9A2858FC4B9E7 { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public byte Timeline_Fade__Direction_9E8AB98349CE01BBC2F9A2858FC4B9E7 { get => GetAt<byte>(0x28C); set => SetAt(0x28C, value); }
        public TimelineComponent Timeline_Fade { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_CreditsRoll_Alpha_BE0D985743AEAABEA079F18CF30A4E9D { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public byte Timeline_CreditsRoll__Direction_BE0D985743AEAABEA079F18CF30A4E9D { get => GetAt<byte>(0x29C); set => SetAt(0x29C, value); }
        public TimelineComponent Timeline_CreditsRoll { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr CreditsComplete => AddrOf(0x2A8); // 
        public UI_Credits_Header_Widget_C CreditsWidget { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new UI_Credits_Header_Widget_C(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float CreditsScrollSpeed { get => GetAt<float>(0x2C0); set => SetAt(0x2C0, value); }
        public TArray<global::System.IntPtr> CreditEntries => new TArray<global::System.IntPtr>(AddrOf(0x2C8)); // TArray<UObject*>
        public byte CurrentOrganization { get => GetAt<byte>(0x2D8); set => SetAt(0x2D8, value); }
        public string CurrentRowTitle => Native.GetPropString(Pointer, "CurrentRowTitle"); // FString
        public string EntryText => Native.GetPropString(Pointer, "EntryText"); // FString
        public byte EntryStyle { get => GetAt<byte>(0x300); set => SetAt(0x300, value); }
        public string EntryImage => Native.GetPropString(Pointer, "EntryImage"); // FString
        public bool FrontEndCredits_ { get => Native.GetPropBool(Pointer, "FrontEndCredits?"); set => Native.SetPropBool(Pointer, "FrontEndCredits?", value); }
        public global::System.IntPtr ThanksForPlaying_ => AddrOf(0x320); // 
        public AudioComponent CreditsMusicSound2D { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public byte ResidentEvilTitle { get => GetAt<byte>(0x340); set => SetAt(0x340, value); }
        public float ImageCycleTime { get => GetAt<float>(0x344); set => SetAt(0x344, value); }
        public TArray<global::System.IntPtr> ImageNames => new TArray<global::System.IntPtr>(AddrOf(0x348)); // TArray<FName>
        public int ImageIndex { get => GetAt<int>(0x358); set => SetAt(0x358, value); }
        public TimerHandle ShowImageTimer => new TimerHandle(AddrOf(0x360));
        public bool FirstImage { get => Native.GetPropBool(Pointer, "FirstImage"); set => Native.SetPropBool(Pointer, "FirstImage", value); }
        public global::System.IntPtr EndCreditsStarted => AddrOf(0x370); // 
        public float CreditsSize { get => GetAt<float>(0x380); set => SetAt(0x380, value); }
        public bool CreditsShouldBePlaying { get => Native.GetPropBool(Pointer, "CreditsShouldBePlaying"); set => Native.SetPropBool(Pointer, "CreditsShouldBePlaying", value); }
        public void SetDisplayMode(bool FrontEndCredits_)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(FrontEndCredits_?1:0));
            CallRaw("SetDisplayMode", __pb.Bytes);
        }
        public void CreateEntry()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateEntry", __pb.Bytes);
        }
        public void SetCredits()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetCredits", __pb.Bytes);
        }
        public void Timeline_CreditsRoll__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_CreditsRoll__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_CreditsRoll__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_CreditsRoll__UpdateFunc", __pb.Bytes);
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
        public void Timeline_ImageFade__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ImageFade__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ImageFade__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ImageFade__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_ImageSwap__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ImageSwap__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ImageSwap__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ImageSwap__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void RollCredits()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RollCredits", __pb.Bytes);
        }
        public void FadeIn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeIn", __pb.Bytes);
        }
        public void FadeOut()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeOut", __pb.Bytes);
        }
        public void ImagesStart()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ImagesStart", __pb.Bytes);
        }
        public void ImagesLoop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ImagesLoop", __pb.Bytes);
        }
        public void ShowImageTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowImageTimerExpired", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ContinueRoll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContinueRoll", __pb.Bytes);
        }
        public void ExecuteUbergraph_CreditsUIScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_CreditsUIScreen_BP", __pb.Bytes);
        }
        public void EndCreditsStarted__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndCreditsStarted__DelegateSignature", __pb.Bytes);
        }
        public void CreditsComplete__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreditsComplete__DelegateSignature", __pb.Bytes);
        }
    }

}
