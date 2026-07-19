// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/ControllerIcon3d
using System;

namespace UEModLoader.Game
{
    public class ControllerIcon3d_C : Actor
    {
        public const string UeClassName = "ControllerIcon3d_C";
        public ControllerIcon3d_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new ControllerIcon3d_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ControllerIcon3d_C(p);
        public static ControllerIcon3d_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ControllerIcon3d_C(o.Pointer); }
        public static ControllerIcon3d_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ControllerIcon3d_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ControllerIcon3d_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent WidgetArrows { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BoxComponent BoxArrows { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestStickL1 { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestStickR1 { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestStickL { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestStickR { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BoxComponent box1 { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ScaleRootWidget { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PointLightComponent PointLight { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget1 { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ControllerOffsetQteL { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ControllerOffsetQteR { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent MoveQteL { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent MoveQteR { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestLT { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestRT { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestCntlR1 { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestCntlL1 { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestY { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestX { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestB { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestA { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ControllerOffsetL { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ControllerOffsetR { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ScaleRoot { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestCntlL { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent QuestCntlR { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_WaggleVolume_Alpha_4C2BBB57400D7DAAEC5D08BF9D1DA21F { get => GetAt<float>(0x308); set => SetAt(0x308, value); }
        public byte Timeline_WaggleVolume__Direction_4C2BBB57400D7DAAEC5D08BF9D1DA21F { get => GetAt<byte>(0x30C); set => SetAt(0x30C, value); }
        public TimelineComponent Timeline_WaggleVolume { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_WaggleFill_EasedAlpha_335782CC4689D15D4C209898C06C4589 { get => GetAt<float>(0x318); set => SetAt(0x318, value); }
        public float Timeline_WaggleFill_Alpha_335782CC4689D15D4C209898C06C4589 { get => GetAt<float>(0x31C); set => SetAt(0x31C, value); }
        public byte Timeline_WaggleFill__Direction_335782CC4689D15D4C209898C06C4589 { get => GetAt<byte>(0x320); set => SetAt(0x320, value); }
        public TimelineComponent Timeline_WaggleFill { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_WaggleAmp_Alpha_6B5366A746B6C7A631EFF5920B614C42 { get => GetAt<float>(0x330); set => SetAt(0x330, value); }
        public byte Timeline_WaggleAmp__Direction_6B5366A746B6C7A631EFF5920B614C42 { get => GetAt<byte>(0x334); set => SetAt(0x334, value); }
        public TimelineComponent Timeline_WaggleAmp { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ScaleWidget_Alpha_604B846C40404BE26EB2F78E91D1D97F { get => GetAt<float>(0x340); set => SetAt(0x340, value); }
        public byte Timeline_ScaleWidget__Direction_604B846C40404BE26EB2F78E91D1D97F { get => GetAt<byte>(0x344); set => SetAt(0x344, value); }
        public TimelineComponent Timeline_ScaleWidget { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Waggle_Alpha_1C2B6EFA44599A9FEB40739CBB38F521 { get => GetAt<float>(0x350); set => SetAt(0x350, value); }
        public byte Timeline_Waggle__Direction_1C2B6EFA44599A9FEB40739CBB38F521 { get => GetAt<byte>(0x354); set => SetAt(0x354, value); }
        public TimelineComponent Timeline_Waggle { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Scale_Alpha_695DBD01495BCD3296B9DDB7940C3DBD { get => GetAt<float>(0x360); set => SetAt(0x360, value); }
        public byte Timeline_Scale__Direction_695DBD01495BCD3296B9DDB7940C3DBD { get => GetAt<byte>(0x364); set => SetAt(0x364, value); }
        public TimelineComponent Timeline_Scale { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Pulse_Alpha_D1EFEBBD4A7A63FB327D25B825B76B51 { get => GetAt<float>(0x370); set => SetAt(0x370, value); }
        public byte Timeline_Pulse__Direction_D1EFEBBD4A7A63FB327D25B825B76B51 { get => GetAt<byte>(0x374); set => SetAt(0x374, value); }
        public TimelineComponent Timeline_Pulse { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr ScaleUpFinished => AddrOf(0x380); // 
        public EVR4CommandButton Command { get => (EVR4CommandButton)GetAt<byte>(0x390); set => SetAt(0x390, (byte)value); }
        public bool Cutscene { get => Native.GetPropBool(Pointer, "Cutscene"); set => Native.SetPropBool(Pointer, "Cutscene", value); }
        public InfoRing_C InfoRing { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new InfoRing_C(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EQTEId QTE { get => (EQTEId)GetAt<byte>(0x3A0); set => SetAt(0x3A0, (byte)value); }
        public EActionButtonType Action { get => (EActionButtonType)GetAt<byte>(0x3A1); set => SetAt(0x3A1, (byte)value); }
        public TimerHandle QteResultTimer => new TimerHandle(AddrOf(0x3A8));
        public QteArrows_C QteArrows { get { var __p = GetAt<global::System.IntPtr>(0x3B0); return __p==global::System.IntPtr.Zero?null:new QteArrows_C(__p); } set => SetAt(0x3B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TimerHandle MotionAnimTimer => new TimerHandle(AddrOf(0x3B8));
        public bool WaggleActive { get => Native.GetPropBool(Pointer, "WaggleActive"); set => Native.SetPropBool(Pointer, "WaggleActive", value); }
        public float WaggleAmp { get => GetAt<float>(0x3C4); set => SetAt(0x3C4, value); }
        public VR4GamePlayerPawn WagglePlayer { get { var __p = GetAt<global::System.IntPtr>(0x3C8); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerPawn(__p); } set => SetAt(0x3C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool UseWaggleFill { get => Native.GetPropBool(Pointer, "UseWaggleFill"); set => Native.SetPropBool(Pointer, "UseWaggleFill", value); }
        public TimerHandle IsWaggleTimer => new TimerHandle(AddrOf(0x3D8));
        public AudioComponent WaggleFillSFX { get { var __p = GetAt<global::System.IntPtr>(0x3E0); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x3E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool DebugQTE_ { get => Native.GetPropBool(Pointer, "DebugQTE?"); set => Native.SetPropBool(Pointer, "DebugQTE?", value); }
        public TimerHandle DebugTimer => new TimerHandle(AddrOf(0x3F0));
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
        public void Get_Waggle_Player()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Get Waggle Player", __pb.Bytes);
        }
        public void UpdateMeshes(byte ActivePlatform)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, ActivePlatform);
            CallRaw("UpdateMeshes", __pb.Bytes);
        }
        public void SetupMeshes(EVR4CommandButton Button)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Button);
            CallRaw("SetupMeshes", __pb.Bytes);
        }
        public void Timeline_Pulse__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Pulse__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Pulse__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Pulse__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Scale__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Scale__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Scale__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Scale__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Waggle__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Waggle__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Waggle__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Waggle__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_ScaleWidget__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleWidget__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ScaleWidget__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleWidget__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_WaggleAmp__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_WaggleAmp__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_WaggleAmp__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_WaggleAmp__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_WaggleFill__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_WaggleFill__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_WaggleFill__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_WaggleFill__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_WaggleVolume__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_WaggleVolume__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_WaggleVolume__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_WaggleVolume__UpdateFunc", __pb.Bytes);
        }
        public void ShowIcon(EVR4CommandButton Button, bool instant, EActionButtonType Action, EQTEId QTE)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<byte>(0x0, (byte)Button);
            __pb.Set<byte>(0x1, (byte)(instant?1:0));
            __pb.Set<byte>(0x2, (byte)Action);
            __pb.Set<byte>(0x3, (byte)QTE);
            CallRaw("ShowIcon", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void HideIcon(bool instant)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(instant?1:0));
            CallRaw("HideIcon", __pb.Bytes);
        }
        public void StartWaggle()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartWaggle", __pb.Bytes);
        }
        public void StopWaggle()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopWaggle", __pb.Bytes);
        }
        public void QteResultCutscene(bool success)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(success?1:0));
            CallRaw("QteResultCutscene", __pb.Bytes);
        }
        public void GrowWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GrowWidget", __pb.Bytes);
        }
        public void ShrinkWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShrinkWidget", __pb.Bytes);
        }
        public void QteResultTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("QteResultTimerExpired", __pb.Bytes);
        }
        public void QteResultTransfer(float Time, global::System.IntPtr CompleteText, bool success, bool NoDelay)
        {
            var __pb = new ParamBuffer(34);
            __pb.Set(0x0, Time);
            __pb.Set<global::System.IntPtr>(0x8, CompleteText);
            __pb.Set<byte>(0x20, (byte)(success?1:0));
            __pb.Set<byte>(0x21, (byte)(NoDelay?1:0));
            CallRaw("QteResultTransfer", __pb.Bytes);
        }
        public void MotionAnimation()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("MotionAnimation", __pb.Bytes);
        }
        public void FirstFlashStart()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FirstFlashStart", __pb.Bytes);
        }
        public void FirstFlashOff()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FirstFlashOff", __pb.Bytes);
        }
        public void SeconFlash()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SeconFlash", __pb.Bytes);
        }
        public void SloMoIntroCompleted(VR4Vignette Vignette)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Vignette);
            CallRaw("SloMoIntroCompleted", __pb.Bytes);
        }
        public void SecondFlashOff()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SecondFlashOff", __pb.Bytes);
        }
        public void WaggleLoop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WaggleLoop", __pb.Bytes);
        }
        public void IncreaseWaggleAmp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IncreaseWaggleAmp", __pb.Bytes);
        }
        public void DecreaseWaggleAmp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DecreaseWaggleAmp", __pb.Bytes);
        }
        public void WaggleDisplayTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WaggleDisplayTimerExpired", __pb.Bytes);
        }
        public void WaggleShrinkComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WaggleShrinkComplete", __pb.Bytes);
        }
        public void DecreaseWaggle()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DecreaseWaggle", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void DebugTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DebugTimerExpired", __pb.Bytes);
        }
        public void ExecuteUbergraph_ControllerIcon3d(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ControllerIcon3d", __pb.Bytes);
        }
        public void ScaleUpFinished__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ScaleUpFinished__DelegateSignature", __pb.Bytes);
        }
    }

}
