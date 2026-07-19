// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/HUD/UI_HealthVignette_BP
using System;

namespace UEModLoader.Game
{
    public class UI_HealthVignette_BP_C : Actor
    {
        public const string UeClassName = "UI_HealthVignette_BP_C";
        public UI_HealthVignette_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_HealthVignette_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_HealthVignette_BP_C(p);
        public static UI_HealthVignette_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_HealthVignette_BP_C(o.Pointer); }
        public static UI_HealthVignette_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_HealthVignette_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_HealthVignette_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public StaticMeshComponent VignetteQte { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent QteAnchor { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent MessageTextWidget { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ForwardGuide { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Heartbeat_Parent { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DamageMessage_Parent { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent HeartbeatWaveform { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent HeartbeatBG { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ShowSpikesMerc_Alpha_2CA46F354D18154634E00397F7DD1234 { get => GetAt<float>(0x270); set => SetAt(0x270, value); }
        public byte Timeline_ShowSpikesMerc__Direction_2CA46F354D18154634E00397F7DD1234 { get => GetAt<byte>(0x274); set => SetAt(0x274, value); }
        public TimelineComponent Timeline_ShowSpikesMerc { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ShowSpikes_Alpha_604EEBE04CF4344EF22C99B5510421FF { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public byte Timeline_ShowSpikes__Direction_604EEBE04CF4344EF22C99B5510421FF { get => GetAt<byte>(0x284); set => SetAt(0x284, value); }
        public TimelineComponent Timeline_ShowSpikes { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Pulse_FadeOut_FadeOut_7D5037D44C6320441A6F34B780B42184 { get => GetAt<float>(0x290); set => SetAt(0x290, value); }
        public float Timeline_Pulse_FadeOut_TextAlpha_7D5037D44C6320441A6F34B780B42184 { get => GetAt<float>(0x294); set => SetAt(0x294, value); }
        public float Timeline_Pulse_FadeOut_UV_7D5037D44C6320441A6F34B780B42184 { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public byte Timeline_Pulse_FadeOut__Direction_7D5037D44C6320441A6F34B780B42184 { get => GetAt<byte>(0x29C); set => SetAt(0x29C, value); }
        public TimelineComponent Timeline_Pulse_FadeOut { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Pulse_Loop_Alpha_144A71084F5CDE38ACA2F5B3133D964C { get => GetAt<float>(0x2A8); set => SetAt(0x2A8, value); }
        public float Timeline_Pulse_Loop_UV_144A71084F5CDE38ACA2F5B3133D964C { get => GetAt<float>(0x2AC); set => SetAt(0x2AC, value); }
        public byte Timeline_Pulse_Loop__Direction_144A71084F5CDE38ACA2F5B3133D964C { get => GetAt<byte>(0x2B0); set => SetAt(0x2B0, value); }
        public TimelineComponent Timeline_Pulse_Loop { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_HealthVignette_Widget_C MessageWidget { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new UI_HealthVignette_Widget_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int PulseLoops_Target { get => GetAt<int>(0x2C8); set => SetAt(0x2C8, value); }
        public int PulseLoops_Current { get => GetAt<int>(0x2CC); set => SetAt(0x2CC, value); }
        public MaterialInstanceDynamic DynamicBGMaterial { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic DynamicWaveformMaterial { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic DynamicVignetteMaterial { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsShowingDamage { get => Native.GetPropBool(Pointer, "IsShowingDamage"); set => Native.SetPropBool(Pointer, "IsShowingDamage", value); }
        public global::System.IntPtr Name_Fine => AddrOf(0x2F0); // 
        public global::System.IntPtr Name_Caution => AddrOf(0x308); // 
        public global::System.IntPtr Name_Danger => AddrOf(0x320); // 
        public Color Color_Fine => new Color(AddrOf(0x338));
        public Color Color_Caution => new Color(AddrOf(0x33C));
        public Color Color_Danger => new Color(AddrOf(0x340));
        public SoundBase Sound_Breath_File { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoundBase Sound_Breath_Caution { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoundBase Sound_Breath_Danger { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoundBase Sound_HeartBeat { get { var __p = GetAt<global::System.IntPtr>(0x360); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x360, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ECameraMode ActiveCameraMode { get => (ECameraMode)GetAt<byte>(0x368); set => SetAt(0x368, (byte)value); }
        public byte CurrentStatus { get => GetAt<byte>(0x369); set => SetAt(0x369, value); }
        public bool Healed { get => Native.GetPropBool(Pointer, "Healed"); set => Native.SetPropBool(Pointer, "Healed", value); }
        public int OldHP { get => GetAt<int>(0x36C); set => SetAt(0x36C, value); }
        public bool ShowVignette { get => Native.GetPropBool(Pointer, "ShowVignette"); set => Native.SetPropBool(Pointer, "ShowVignette", value); }
        public float SpikeScale { get => GetAt<float>(0x374); set => SetAt(0x374, value); }
        public bool CutsceneDamageQueued { get => Native.GetPropBool(Pointer, "CutsceneDamageQueued"); set => Native.SetPropBool(Pointer, "CutsceneDamageQueued", value); }
        public float DamageVignetteScale_None { get => GetAt<float>(0x37C); set => SetAt(0x37C, value); }
        public float DamageVignetteScale_Fine { get => GetAt<float>(0x380); set => SetAt(0x380, value); }
        public float DamageVignetteScale_Caution { get => GetAt<float>(0x384); set => SetAt(0x384, value); }
        public float DamageVignetteScale_Danger { get => GetAt<float>(0x388); set => SetAt(0x388, value); }
        public bool DisablePollingLoop { get => Native.GetPropBool(Pointer, "DisablePollingLoop"); set => Native.SetPropBool(Pointer, "DisablePollingLoop", value); }
        public void QteStarted(float Duration, float Scale, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, Duration);
            __pb.Set(0x4, Scale);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("QteStarted", __pb.Bytes);
        }
        public void QteCancelled(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("QteCancelled", __pb.Bytes);
        }
        public void GetDangerSound(SoundBase Sound)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Sound);
            CallRaw("GetDangerSound", __pb.Bytes);
        }
        public void GetCautionSound(SoundBase Sound)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Sound);
            CallRaw("GetCautionSound", __pb.Bytes);
        }
        public void GetFineSound(SoundBase Sound)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Sound);
            CallRaw("GetFineSound", __pb.Bytes);
        }
        public void UpdateDamageVignette(byte Index)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, Index);
            CallRaw("UpdateDamageVignette", __pb.Bytes);
        }
        public void UpdateColors(byte Status)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, Status);
            CallRaw("UpdateColors", __pb.Bytes);
        }
        public void UpdateStatus(int CurrentHealth, int MaxHealth, byte Status)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, CurrentHealth);
            __pb.Set(0x4, MaxHealth);
            __pb.Set(0x8, Status);
            CallRaw("UpdateStatus", __pb.Bytes);
        }
        public void SetInvisible()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetInvisible", __pb.Bytes);
        }
        public void SetVisible()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetVisible", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void CameraModeChanged(ECameraMode cameraMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)cameraMode);
            CallRaw("CameraModeChanged", __pb.Bytes);
        }
        public void Timeline_Pulse_Loop__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Pulse_Loop__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Pulse_Loop__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Pulse_Loop__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Pulse_FadeOut__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Pulse_FadeOut__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Pulse_FadeOut__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Pulse_FadeOut__UpdateFunc", __pb.Bytes);
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
        public void Timeline_ShowSpikesMerc__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ShowSpikesMerc__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ShowSpikesMerc__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ShowSpikesMerc__UpdateFunc", __pb.Bytes);
        }
        public void PulseFadeOut(SoundBase HeartbeatSound, float HeartbeatMultiplier)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, HeartbeatSound);
            __pb.Set(0x8, HeartbeatMultiplier);
            CallRaw("PulseFadeOut", __pb.Bytes);
        }
        public void FlashMessage(byte Status)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, Status);
            CallRaw("FlashMessage", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void SetHealthStatus(byte Status)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, Status);
            CallRaw("SetHealthStatus", __pb.Bytes);
        }
        public void PulseIntro(float SpeedMultiplier, SoundBase BreathingSound, float BreathingVolume, SoundBase HeartbeatSound, float HeartbeatVolume)
        {
            var __pb = new ParamBuffer(36);
            __pb.Set(0x0, SpeedMultiplier);
            __pb.SetObject(0x8, BreathingSound);
            __pb.Set(0x10, BreathingVolume);
            __pb.SetObject(0x18, HeartbeatSound);
            __pb.Set(0x20, HeartbeatVolume);
            CallRaw("PulseIntro", __pb.Bytes);
        }
        public void PulseLoop(SoundBase HeartbeatSound, float HeartbeatMultiplier)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, HeartbeatSound);
            __pb.Set(0x8, HeartbeatMultiplier);
            CallRaw("PulseLoop", __pb.Bytes);
        }
        public void PollingLoop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PollingLoop", __pb.Bytes);
        }
        public void ShowSpikes(float Duration)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Duration);
            CallRaw("ShowSpikes", __pb.Bytes);
        }
        public void AttachToHud()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AttachToHud", __pb.Bytes);
        }
        public void ShowSpikesMerc(float Scale)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Scale);
            CallRaw("ShowSpikesMerc", __pb.Bytes);
        }
        public void HideSpikes_Merc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideSpikes Merc", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_HealthVignette_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_HealthVignette_BP", __pb.Bytes);
        }
    }

}
