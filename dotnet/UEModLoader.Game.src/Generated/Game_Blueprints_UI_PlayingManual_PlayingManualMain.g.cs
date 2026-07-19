// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualMain
using System;

namespace UEModLoader.Game
{
    public class PlayingManualMain_C : VR4UIScreen
    {
        public const string UeClassName = "PlayingManualMain_C";
        public PlayingManualMain_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualMain_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlayingManualMain_C(p);
        public static PlayingManualMain_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualMain_C(o.Pointer); }
        public static PlayingManualMain_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualMain_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualMain_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent Widget_Main { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_TransitionFinish_EndFade_DE0AB5B641A08585A0BC738305C253FD { get => GetAt<float>(0x268); set => SetAt(0x268, value); }
        public float Timeline_TransitionFinish_Move_DE0AB5B641A08585A0BC738305C253FD { get => GetAt<float>(0x26C); set => SetAt(0x26C, value); }
        public byte Timeline_TransitionFinish__Direction_DE0AB5B641A08585A0BC738305C253FD { get => GetAt<byte>(0x270); set => SetAt(0x270, value); }
        public TimelineComponent Timeline_TransitionFinish { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_NormalTransitionStart_alpha_0EB1EBF34DB63C5711904DB2DFC5C859 { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public byte Timeline_NormalTransitionStart__Direction_0EB1EBF34DB63C5711904DB2DFC5C859 { get => GetAt<byte>(0x284); set => SetAt(0x284, value); }
        public TimelineComponent Timeline_NormalTransitionStart { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_FirstSelection_alpha_4F7D38E2432109BCFD3AE081A4C5E74F { get => GetAt<float>(0x290); set => SetAt(0x290, value); }
        public byte Timeline_FirstSelection__Direction_4F7D38E2432109BCFD3AE081A4C5E74F { get => GetAt<byte>(0x294); set => SetAt(0x294, value); }
        public TimelineComponent Timeline_FirstSelection { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_MovieFade_Alpha_F175931D4C3119326D6EEBA09A20BF80 { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public byte Timeline_MovieFade__Direction_F175931D4C3119326D6EEBA09A20BF80 { get => GetAt<byte>(0x2A4); set => SetAt(0x2A4, value); }
        public TimelineComponent Timeline_MovieFade { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr ActiveDisplay => AddrOf(0x2B0); // struct PlayingManualEntry
        public PlayingManualMainWidget_C Widget { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new PlayingManualMainWidget_C(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TimerHandle FadeDelayTimer => new TimerHandle(AddrOf(0x330));
        public global::System.IntPtr SkipText => AddrOf(0x338); // 
        public bool NoSelection { get => Native.GetPropBool(Pointer, "NoSelection"); set => Native.SetPropBool(Pointer, "NoSelection", value); }
        public global::System.IntPtr TransitionComplete => AddrOf(0x358); // 
        public global::System.IntPtr FadeInStarted => AddrOf(0x368); // 
        public EHandedness Handedness { get => (EHandedness)GetAt<byte>(0x378); set => SetAt(0x378, (byte)value); }
        public EWeaponSelectMode WeaponSelectMode { get => (EWeaponSelectMode)GetAt<byte>(0x379); set => SetAt(0x379, (byte)value); }
        public EPlayerMovementMode MovementMode { get => (EPlayerMovementMode)GetAt<byte>(0x37A); set => SetAt(0x37A, (byte)value); }
        public TArray<global::System.IntPtr> ControllerCallouts => new TArray<global::System.IntPtr>(AddrOf(0x380)); // TArray<FText>
        public global::System.IntPtr BlankString => AddrOf(0x390); // 
        public BinkMediaPlayer BinkMediaPlayer { get { var __p = GetAt<global::System.IntPtr>(0x3A8); return __p==global::System.IntPtr.Zero?null:new BinkMediaPlayer(__p); } set => SetAt(0x3A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void ParseManualText(global::System.IntPtr Text, global::System.IntPtr ParsedText)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            __pb.Set<global::System.IntPtr>(0x18, ParsedText);
            CallRaw("ParseManualText", __pb.Bytes);
        }
        public void NewCategory(global::System.IntPtr Category)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Category);
            CallRaw("NewCategory", __pb.Bytes);
        }
        public void Clear_Info()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Clear Info", __pb.Bytes);
        }
        public void UpdateMain(FName Name)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Name);
            CallRaw("UpdateMain", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void Timeline_MovieFade__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MovieFade__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_MovieFade__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MovieFade__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_FirstSelection__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FirstSelection__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_FirstSelection__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FirstSelection__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_TransitionFinish__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_TransitionFinish__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_TransitionFinish__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_TransitionFinish__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_NormalTransitionStart__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_NormalTransitionStart__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_NormalTransitionStart__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_NormalTransitionStart__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void PlayVideo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayVideo", __pb.Bytes);
        }
        public void FadeInMovie()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeInMovie", __pb.Bytes);
        }
        public void SetupWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupWidget", __pb.Bytes);
        }
        public void SetupVideo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupVideo", __pb.Bytes);
        }
        public void SetupController()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupController", __pb.Bytes);
        }
        public void SetupImagesL()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupImagesL", __pb.Bytes);
        }
        public void SetupImagesR()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupImagesR", __pb.Bytes);
        }
        public void FadeDelayTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeDelayTimerExpired", __pb.Bytes);
        }
        public void FirstSelectionTransition()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FirstSelectionTransition", __pb.Bytes);
        }
        public void ShowNewSelection()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowNewSelection", __pb.Bytes);
        }
        public void NormalTransition()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("NormalTransition", __pb.Bytes);
        }
        public void SetupImages4L()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupImages4L", __pb.Bytes);
        }
        public void SetupVideo_Alt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupVideo_Alt", __pb.Bytes);
        }
        public void SetupQuickSelect()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupQuickSelect", __pb.Bytes);
        }
        public void SetupVideo1Image()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupVideo1Image", __pb.Bytes);
        }
        public void SetupSpecialTuneUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupSpecialTuneUp", __pb.Bytes);
        }
        public void SetupSpecialCombine()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupSpecialCombine", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void SetupMercHud()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupMercHud", __pb.Bytes);
        }
        public void SetupImageOnly()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupImageOnly", __pb.Bytes);
        }
        public void SetupLeaderboards()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupLeaderboards", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualMain(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualMain", __pb.Bytes);
        }
        public void FadeInStarted__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeInStarted__DelegateSignature", __pb.Bytes);
        }
        public void TransitionComplete__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TransitionComplete__DelegateSignature", __pb.Bytes);
        }
    }

}
