// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/NiagaraAnimNotifies
using System;

namespace UEModLoader.Game
{
    public class AnimNotifyState_TimedNiagaraEffect : AnimNotifyState
    {
        public const string UeClassName = "AnimNotifyState_TimedNiagaraEffect";
        public AnimNotifyState_TimedNiagaraEffect(System.IntPtr ptr) : base(ptr) {}
        public static new AnimNotifyState_TimedNiagaraEffect FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AnimNotifyState_TimedNiagaraEffect(p);
        public static AnimNotifyState_TimedNiagaraEffect FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimNotifyState_TimedNiagaraEffect(o.Pointer); }
        public static AnimNotifyState_TimedNiagaraEffect[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimNotifyState_TimedNiagaraEffect[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimNotifyState_TimedNiagaraEffect(a[i].Pointer); return r; }
        public NiagaraSystem Template { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new NiagaraSystem(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public string SocketName => Native.GetPropName(Pointer, "SocketName"); // FName
        public FName SocketName_Raw { get => GetAt<FName>(0x38); set => SetAt(0x38, value); }
        public Vector LocationOffset => new Vector(AddrOf(0x40));
        public Rotator RotationOffset => new Rotator(AddrOf(0x4C));
        public bool bDestroyAtEnd { get => Native.GetPropBool(Pointer, "bDestroyAtEnd"); set => Native.SetPropBool(Pointer, "bDestroyAtEnd", value); }
    }

    public class AnimNotify_PlayNiagaraEffect : AnimNotify
    {
        public const string UeClassName = "AnimNotify_PlayNiagaraEffect";
        public AnimNotify_PlayNiagaraEffect(System.IntPtr ptr) : base(ptr) {}
        public static new AnimNotify_PlayNiagaraEffect FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AnimNotify_PlayNiagaraEffect(p);
        public static AnimNotify_PlayNiagaraEffect FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimNotify_PlayNiagaraEffect(o.Pointer); }
        public static AnimNotify_PlayNiagaraEffect[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimNotify_PlayNiagaraEffect[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimNotify_PlayNiagaraEffect(a[i].Pointer); return r; }
        public NiagaraSystem Template { get { var __p = GetAt<System.IntPtr>(0x38); return __p==System.IntPtr.Zero?null:new NiagaraSystem(__p); } set => SetAt(0x38, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector LocationOffset => new Vector(AddrOf(0x40));
        public Rotator RotationOffset => new Rotator(AddrOf(0x4C));
        public Vector Scale => new Vector(AddrOf(0x58));
        public bool Attached { get => Native.GetPropBool(Pointer, "Attached"); set => Native.SetPropBool(Pointer, "Attached", value); }
        public string SocketName => Native.GetPropName(Pointer, "SocketName"); // FName
        public FName SocketName_Raw { get => GetAt<FName>(0x84); set => SetAt(0x84, value); }
        /// <summary>[Native] thunk RVA 0x5BCD6A4 — hookable via Hooks.InstallAt(NativeFunc_GetSpawnedEffect).</summary>
        public static System.IntPtr NativeFunc_GetSpawnedEffect => Memory.ModuleBase() + 0x5BCD6A4;
        public FXSystemComponent GetSpawnedEffect()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSpawnedEffect", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new FXSystemComponent(__p); }
        }
    }

}
