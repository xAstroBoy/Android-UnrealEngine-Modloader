// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Particles/ParticleGeneric
using System;

namespace UEModLoader.Game
{
    public class ParticleGeneric_C : Actor
    {
        public const string UeClassName = "ParticleGeneric_C";
        public ParticleGeneric_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new ParticleGeneric_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ParticleGeneric_C(p);
        public static ParticleGeneric_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ParticleGeneric_C(o.Pointer); }
        public static ParticleGeneric_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ParticleGeneric_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ParticleGeneric_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public ParticleSystemComponent ParticleSystem { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new ParticleSystemComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ParticleSystem Template { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new ParticleSystem(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool AutoActivate { get => Native.GetPropBool(Pointer, "AutoActivate"); set => Native.SetPropBool(Pointer, "AutoActivate", value); }
        public bool DestroyOnFinish { get => Native.GetPropBool(Pointer, "DestroyOnFinish"); set => Native.SetPropBool(Pointer, "DestroyOnFinish", value); }
        public Actor AttachParent { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string Socket => Native.GetPropName(Pointer, "Socket"); // FName
        public FName Socket_Raw { get => GetAt<FName>(0x248); set => SetAt(0x248, value); }
        public SceneComponent AttachComponent { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EAttachmentRule AttachRule { get => (EAttachmentRule)GetAt<byte>(0x258); set => SetAt(0x258, (byte)value); }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnSystemFinished(ParticleSystemComponent PSystem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, PSystem);
            CallRaw("OnSystemFinished", __pb.Bytes);
        }
        public void ActivateEmitter(bool Reset)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Reset?1:0));
            CallRaw("ActivateEmitter", __pb.Bytes);
        }
        public void DeactivateEmitter()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DeactivateEmitter", __pb.Bytes);
        }
        public void SetColorParameter(FName Name, global::System.IntPtr Color)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Name);
            __pb.Set<global::System.IntPtr>(0x8, Color);
            CallRaw("SetColorParameter", __pb.Bytes);
        }
        public void SetVectorParameter(FName ParameterName, global::System.IntPtr Vector)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set(0x0, ParameterName);
            __pb.Set<global::System.IntPtr>(0x8, Vector);
            CallRaw("SetVectorParameter", __pb.Bytes);
        }
        public void ParentDestroyed(Actor DestroyedActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, DestroyedActor);
            CallRaw("ParentDestroyed", __pb.Bytes);
        }
        public void ExecuteUbergraph_ParticleGeneric(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ParticleGeneric", __pb.Bytes);
        }
    }

}
