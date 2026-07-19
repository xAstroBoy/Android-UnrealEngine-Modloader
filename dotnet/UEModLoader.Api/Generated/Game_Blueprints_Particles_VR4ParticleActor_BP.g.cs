// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Particles/VR4ParticleActor_BP
using System;

namespace UEModLoader.Game
{
    public class VR4ParticleActor_BP_C : VR4ParticleActor
    {
        public const string UeClassName = "VR4ParticleActor_BP_C";
        public VR4ParticleActor_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4ParticleActor_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4ParticleActor_BP_C(p);
        public static VR4ParticleActor_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4ParticleActor_BP_C(o.Pointer); }
        public static VR4ParticleActor_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4ParticleActor_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4ParticleActor_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2A0));
        public ParticleSystem Template { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new ParticleSystem(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void SetColorParameter(FName Name, LinearColor Color)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Name);
            __pb.Set<System.IntPtr>(0x8, Color);
            CallRaw("SetColorParameter", __pb.Bytes);
        }
        public void OnParticleShutdown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnParticleShutdown", __pb.Bytes);
        }
        public void OnParticleStartup()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnParticleStartup", __pb.Bytes);
        }
        public void StopParticles()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopParticles", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4ParticleActor_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4ParticleActor_BP", __pb.Bytes);
        }
    }

}
