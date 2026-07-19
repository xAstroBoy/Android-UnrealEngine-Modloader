// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/FX/BIO4/Blueprints/Weather/BPFX_MercenariesLightning
using System;

namespace UEModLoader.Game
{
    public class BPFX_MercenariesLightning_C : Actor
    {
        public const string UeClassName = "BPFX_MercenariesLightning_C";
        public BPFX_MercenariesLightning_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new BPFX_MercenariesLightning_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BPFX_MercenariesLightning_C(p);
        public static BPFX_MercenariesLightning_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BPFX_MercenariesLightning_C(o.Pointer); }
        public static BPFX_MercenariesLightning_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BPFX_MercenariesLightning_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BPFX_MercenariesLightning_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Skybox_lightning_BP_C SkyBox { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new Skybox_lightning_BP_C(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float MaxLifeSec { get => GetAt<float>(0x238); set => SetAt(0x238, value); }
        public TimerHandle LifeTimer => new TimerHandle(AddrOf(0x240));
        public void UpdateIntensity()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateIntensity", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void DestroyLightning()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyLightning", __pb.Bytes);
        }
        public void ExecuteUbergraph_BPFX_MercenariesLightning(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_BPFX_MercenariesLightning", __pb.Bytes);
        }
    }

}
