// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/FX/BIO4/Blueprints/Weather/BPA_MercenariesRainVolume
using System;

namespace UEModLoader.Game
{
    public class BPA_MercenariesRainVolume_C : Actor
    {
        public const string UeClassName = "BPA_MercenariesRainVolume_C";
        public BPA_MercenariesRainVolume_C(System.IntPtr ptr) : base(ptr) {}
        public static new BPA_MercenariesRainVolume_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BPA_MercenariesRainVolume_C(p);
        public static BPA_MercenariesRainVolume_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BPA_MercenariesRainVolume_C(o.Pointer); }
        public static BPA_MercenariesRainVolume_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BPA_MercenariesRainVolume_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BPA_MercenariesRainVolume_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public AudioComponent LightningAudio { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public AudioComponent RainAudio { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public ParticleSystemComponent ParticleSystem { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new ParticleSystemComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public BPC_RainLogic_C BPC_RainLogic { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new BPC_RainLogic_C(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public BPFX_MercenariesLightning_C Lightning_FX { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new BPFX_MercenariesLightning_C(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public MinMaxFloat LightningTimerRange => new MinMaxFloat(AddrOf(0x250));
        public TArray<System.IntPtr> LightningSound => new TArray<System.IntPtr>(AddrOf(0x258)); // TArray<UObject*>
        public TimerHandle LightningTimer => new TimerHandle(AddrOf(0x268));
        public MinMaxFloat LightningSoundDelayRange => new MinMaxFloat(AddrOf(0x270));
        public float LightningLifeMultiplier { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public void DisableOnMatchEnd(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("DisableOnMatchEnd", __pb.Bytes);
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
        public void Create_Lightning()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Create Lightning", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void enable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("enable", __pb.Bytes);
        }
        public void Disable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Disable", __pb.Bytes);
        }
        public void ToggleOn_Off()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleOn/Off", __pb.Bytes);
        }
        public void ExecuteUbergraph_BPA_MercenariesRainVolume(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_BPA_MercenariesRainVolume", __pb.Bytes);
        }
    }

}
