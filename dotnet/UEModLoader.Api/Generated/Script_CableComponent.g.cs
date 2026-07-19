// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/CableComponent
using System;

namespace UEModLoader.Game
{
    public class CableActor : Actor
    {
        public const string UeClassName = "CableActor";
        public CableActor(System.IntPtr ptr) : base(ptr) {}
        public static new CableActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CableActor(p);
        public static CableActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CableActor(o.Pointer); }
        public static CableActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CableActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CableActor(a[i].Pointer); return r; }
        public CableComponent CableComponent { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new CableComponent(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class CableComponent : MeshComponent
    {
        public const string UeClassName = "CableComponent";
        public CableComponent(System.IntPtr ptr) : base(ptr) {}
        public static new CableComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CableComponent(p);
        public static CableComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CableComponent(o.Pointer); }
        public static CableComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CableComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CableComponent(a[i].Pointer); return r; }
        public bool bAttachStart { get => Native.GetPropBool(Pointer, "bAttachStart"); set => Native.SetPropBool(Pointer, "bAttachStart", value); }
        public bool bAttachEnd { get => Native.GetPropBool(Pointer, "bAttachEnd"); set => Native.SetPropBool(Pointer, "bAttachEnd", value); }
        public ComponentReference AttachEndTo => new ComponentReference(AddrOf(0x430));
        public string AttachEndToSocketName => Native.GetPropName(Pointer, "AttachEndToSocketName"); // FName
        public FName AttachEndToSocketName_Raw { get => GetAt<FName>(0x458); set => SetAt(0x458, value); }
        public Vector EndLocation => new Vector(AddrOf(0x460));
        public float CableLength { get => GetAt<float>(0x46C); set => SetAt(0x46C, value); }
        public int NumSegments { get => GetAt<int>(0x470); set => SetAt(0x470, value); }
        public float SubstepTime { get => GetAt<float>(0x474); set => SetAt(0x474, value); }
        public int SolverIterations { get => GetAt<int>(0x478); set => SetAt(0x478, value); }
        public bool bEnableStiffness { get => Native.GetPropBool(Pointer, "bEnableStiffness"); set => Native.SetPropBool(Pointer, "bEnableStiffness", value); }
        public bool bEnableCollision { get => Native.GetPropBool(Pointer, "bEnableCollision"); set => Native.SetPropBool(Pointer, "bEnableCollision", value); }
        public float CollisionFriction { get => GetAt<float>(0x480); set => SetAt(0x480, value); }
        public Vector CableForce => new Vector(AddrOf(0x484));
        public float CableGravityScale { get => GetAt<float>(0x490); set => SetAt(0x490, value); }
        public float CableWidth { get => GetAt<float>(0x494); set => SetAt(0x494, value); }
        public int NumSides { get => GetAt<int>(0x498); set => SetAt(0x498, value); }
        public float TileMaterial { get => GetAt<float>(0x49C); set => SetAt(0x49C, value); }
        /// <summary>[Native] thunk RVA 0x92FB074 — hookable via Hooks.InstallAt(NativeFunc_SetAttachEndToComponent).</summary>
        public static System.IntPtr NativeFunc_SetAttachEndToComponent => Memory.ModuleBase() + 0x92FB074;
        public void SetAttachEndToComponent(SceneComponent component, FName SocketName)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.Set(0x8, SocketName);
            CallRaw("SetAttachEndToComponent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92FAF4C — hookable via Hooks.InstallAt(NativeFunc_SetAttachEndTo).</summary>
        public static System.IntPtr NativeFunc_SetAttachEndTo => Memory.ModuleBase() + 0x92FAF4C;
        public void SetAttachEndTo(Actor Actor, FName ComponentProperty, FName SocketName)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Actor);
            __pb.Set(0x8, ComponentProperty);
            __pb.Set(0x10, SocketName);
            CallRaw("SetAttachEndTo", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92FAE24 — hookable via Hooks.InstallAt(NativeFunc_GetCableParticleLocations).</summary>
        public static System.IntPtr NativeFunc_GetCableParticleLocations => Memory.ModuleBase() + 0x92FAE24;
        public void GetCableParticleLocations(System.IntPtr Locations)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Locations);
            CallRaw("GetCableParticleLocations", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92FAEE4 — hookable via Hooks.InstallAt(NativeFunc_GetAttachedComponent).</summary>
        public static System.IntPtr NativeFunc_GetAttachedComponent => Memory.ModuleBase() + 0x92FAEE4;
        public SceneComponent GetAttachedComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetAttachedComponent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x92FAF18 — hookable via Hooks.InstallAt(NativeFunc_GetAttachedActor).</summary>
        public static System.IntPtr NativeFunc_GetAttachedActor => Memory.ModuleBase() + 0x92FAF18;
        public Actor GetAttachedActor()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetAttachedActor", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Actor(__p); }
        }
    }

}
