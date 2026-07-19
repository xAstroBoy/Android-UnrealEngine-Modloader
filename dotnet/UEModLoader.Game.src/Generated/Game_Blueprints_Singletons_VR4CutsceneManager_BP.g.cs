// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Singletons/VR4CutsceneManager_BP
using System;

namespace UEModLoader.Game
{
    public class VR4CutsceneManager_BP_C : VR4CutsceneManager
    {
        public const string UeClassName = "VR4CutsceneManager_BP_C";
        public VR4CutsceneManager_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4CutsceneManager_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4CutsceneManager_BP_C(p);
        public static VR4CutsceneManager_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4CutsceneManager_BP_C(o.Pointer); }
        public static VR4CutsceneManager_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4CutsceneManager_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4CutsceneManager_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x3D0));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x3D8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x3D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_EndFade_Alpha_6A8190EC428826E2BB0AE0B969047C8B { get => GetAt<float>(0x3E0); set => SetAt(0x3E0, value); }
        public byte Timeline_EndFade__Direction_6A8190EC428826E2BB0AE0B969047C8B { get => GetAt<byte>(0x3E4); set => SetAt(0x3E4, value); }
        public TimelineComponent Timeline_EndFade { get { var __p = GetAt<global::System.IntPtr>(0x3E8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EPlayerPawn StoredPawnType { get => (EPlayerPawn)GetAt<byte>(0x3F0); set => SetAt(0x3F0, (byte)value); }
        public float FadeInTime { get => GetAt<float>(0x3F4); set => SetAt(0x3F4, value); }
        public global::System.IntPtr UpdateSubtitle => AddrOf(0x3F8); // 
        public global::System.IntPtr CutsceneNameUpdated => AddrOf(0x408); // 
        public global::System.IntPtr UpdateCommand => AddrOf(0x418); // 
        public bool HoldForDemoEnd { get => Native.GetPropBool(Pointer, "HoldForDemoEnd"); set => Native.SetPropBool(Pointer, "HoldForDemoEnd", value); }
        public global::System.IntPtr UpdateMessage => AddrOf(0x430); // 
        public bool SkipOnBegin { get => Native.GetPropBool(Pointer, "SkipOnBegin"); set => Native.SetPropBool(Pointer, "SkipOnBegin", value); }
        public bool HoldForEndGameFlow { get => Native.GetPropBool(Pointer, "HoldForEndGameFlow"); set => Native.SetPropBool(Pointer, "HoldForEndGameFlow", value); }
        public CutsceneTheatreBox_C CutsceneTheaterBox { get { var __p = GetAt<global::System.IntPtr>(0x448); return __p==global::System.IntPtr.Zero?null:new CutsceneTheatreBox_C(__p); } set => SetAt(0x448, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EndGameFlow_CreditsUnlocks_BP_C EndGame_BP { get { var __p = GetAt<global::System.IntPtr>(0x450); return __p==global::System.IntPtr.Zero?null:new EndGameFlow_CreditsUnlocks_BP_C(__p); } set => SetAt(0x450, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4CutscenePlayerPawn_BP_C PlayerBP { get { var __p = GetAt<global::System.IntPtr>(0x458); return __p==global::System.IntPtr.Zero?null:new VR4CutscenePlayerPawn_BP_C(__p); } set => SetAt(0x458, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> ActiveEffects => new TArray<global::System.IntPtr>(AddrOf(0x460)); // TArray<enum>
        public float MaterialLifetime { get => GetAt<float>(0x470); set => SetAt(0x470, value); }
        public MaterialInterface CurrentMat { get { var __p = GetAt<global::System.IntPtr>(0x478); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x478, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool BinocularOverlayActive { get => Native.GetPropBool(Pointer, "BinocularOverlayActive"); set => Native.SetPropBool(Pointer, "BinocularOverlayActive", value); }
        public bool r330UIActive { get => Native.GetPropBool(Pointer, "r330UIActive"); set => Native.SetPropBool(Pointer, "r330UIActive", value); }
        public global::System.IntPtr OnUpdateTimerDisplay => AddrOf(0x488); // 
        public bool IsShowingMessage()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsShowingMessage", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void TickEffectMaterial(float DeltaTime)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaTime);
            CallRaw("TickEffectMaterial", __pb.Bytes);
        }
        public void GetCutsceneTheaterBox(CutsceneTheatreBox_C CutsceneTheaterBox, bool Valid)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, CutsceneTheaterBox);
            __pb.Set<byte>(0x8, (byte)(Valid?1:0));
            CallRaw("GetCutsceneTheaterBox", __pb.Bytes);
        }
        public void UpdateEffectMaterial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateEffectMaterial", __pb.Bytes);
        }
        public void CheckLevelOverride()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckLevelOverride", __pb.Bytes);
        }
        public void Timeline_EndFade__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_EndFade__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_EndFade__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_EndFade__UpdateFunc", __pb.Bytes);
        }
        public void OnSceEventBegin(global::System.IntPtr Name)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, Name);
            CallRaw("OnSceEventBegin", __pb.Bytes);
        }
        public void OnSceEventEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnSceEventEnd", __pb.Bytes);
        }
        public void SetSubtitle(global::System.IntPtr subtitleKey, float Duration)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, subtitleKey);
            __pb.Set(0x10, Duration);
            CallRaw("SetSubtitle", __pb.Bytes);
        }
        public void OnSceEventTriggered()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnSceEventTriggered", __pb.Bytes);
        }
        public void ShowCommand(global::System.IntPtr Message, EVR4CommandButton Command, EActionButtonType actionType, EQTEId QTEId)
        {
            var __pb = new ParamBuffer(27);
            __pb.Set<global::System.IntPtr>(0x0, Message);
            __pb.Set<byte>(0x18, (byte)Command);
            __pb.Set<byte>(0x19, (byte)actionType);
            __pb.Set<byte>(0x1A, (byte)QTEId);
            CallRaw("ShowCommand", __pb.Bytes);
        }
        public void HideCommand()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideCommand", __pb.Bytes);
        }
        public void ShowDemoEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowDemoEnd", __pb.Bytes);
        }
        public void SetMessage(global::System.IntPtr Message)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Message);
            CallRaw("SetMessage", __pb.Bytes);
        }
        public void HideMessage()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideMessage", __pb.Bytes);
        }
        public void EndGameLoopComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndGameLoopComplete", __pb.Bytes);
        }
        public void InitializeEndGameScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeEndGameScreen", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void OnHideActorComponents(Actor Actor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Actor);
            CallRaw("OnHideActorComponents", __pb.Bytes);
        }
        public void OnClearHiddenComponents()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnClearHiddenComponents", __pb.Bytes);
        }
        public void OnEnableCutsceneEffect(ECutsceneEffect Effect)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Effect);
            CallRaw("OnEnableCutsceneEffect", __pb.Bytes);
        }
        public void OnDisableCutsceneEffect(ECutsceneEffect Effect)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Effect);
            CallRaw("OnDisableCutsceneEffect", __pb.Bytes);
        }
        public void OnSetCutsceneEffectScalarValue(FName Name, float Value)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, Name);
            __pb.Set(0x8, Value);
            CallRaw("OnSetCutsceneEffectScalarValue", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ShowTimer(int Minutes, int Seconds, int centiseconds, bool IsPaused, bool isWarning)
        {
            var __pb = new ParamBuffer(14);
            __pb.Set(0x0, Minutes);
            __pb.Set(0x4, Seconds);
            __pb.Set(0x8, centiseconds);
            __pb.Set<byte>(0xC, (byte)(IsPaused?1:0));
            __pb.Set<byte>(0xD, (byte)(isWarning?1:0));
            CallRaw("ShowTimer", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4CutsceneManager_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4CutsceneManager_BP", __pb.Bytes);
        }
        public void OnUpdateTimerDisplay__DelegateSignature(int Min, int Sec, int Csec, bool isWarning)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set(0x0, Min);
            __pb.Set(0x4, Sec);
            __pb.Set(0x8, Csec);
            __pb.Set<byte>(0xC, (byte)(isWarning?1:0));
            CallRaw("OnUpdateTimerDisplay__DelegateSignature", __pb.Bytes);
        }
        public void UpdateMessage__DelegateSignature(global::System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            CallRaw("UpdateMessage__DelegateSignature", __pb.Bytes);
        }
        public void UpdateCommand__DelegateSignature(bool Show, global::System.IntPtr Message, EVR4CommandButton Command, EActionButtonType actionType, EQTEId QTEId)
        {
            var __pb = new ParamBuffer(35);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            __pb.Set<global::System.IntPtr>(0x8, Message);
            __pb.Set<byte>(0x20, (byte)Command);
            __pb.Set<byte>(0x21, (byte)actionType);
            __pb.Set<byte>(0x22, (byte)QTEId);
            CallRaw("UpdateCommand__DelegateSignature", __pb.Bytes);
        }
        public void CutsceneNameUpdated__DelegateSignature(global::System.IntPtr ActiveCutscene)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, ActiveCutscene);
            CallRaw("CutsceneNameUpdated__DelegateSignature", __pb.Bytes);
        }
        public void UpdateSubtitle__DelegateSignature(global::System.IntPtr Key, float Duration)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            __pb.Set(0x10, Duration);
            CallRaw("UpdateSubtitle__DelegateSignature", __pb.Bytes);
        }
    }

}
