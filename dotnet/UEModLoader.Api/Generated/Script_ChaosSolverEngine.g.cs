// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/ChaosSolverEngine
using System;

namespace UEModLoader.Game
{
    public enum EClusterConnectionTypeEnum
    {
        Chaos_PointImplicit = 0,
        Chaos_DelaunayTriangulation = 1,
        Chaos_MinimalSpanningSubsetDelaunayTriangulation = 2,
        Chaos_PointImplicitAugmentedWithMinimalDelaunay = 3,
        Chaos_None = 4,
        Chaos_EClsuterCreationParameters_Max = 5,
    }

    public class ChaosPhysicsCollisionInfo : StructProxy
    {
        public ChaosPhysicsCollisionInfo(System.IntPtr ptr) : base(ptr) {}
        public PrimitiveComponent component { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public PrimitiveComponent OtherComponent { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector Location => new Vector(AddrOf(0x10));
        public Vector Normal => new Vector(AddrOf(0x1C));
        public Vector AccumulatedImpulse => new Vector(AddrOf(0x28));
        public Vector Velocity => new Vector(AddrOf(0x34));
        public Vector OtherVelocity => new Vector(AddrOf(0x40));
        public Vector AngularVelocity => new Vector(AddrOf(0x4C));
        public Vector OtherAngularVelocity => new Vector(AddrOf(0x58));
        public float Mass { get => GetAt<float>(0x64); set => SetAt(0x64, value); }
        public float OtherMass { get => GetAt<float>(0x68); set => SetAt(0x68, value); }
    }

    public class ChaosBreakEvent : StructProxy
    {
        public ChaosBreakEvent(System.IntPtr ptr) : base(ptr) {}
        public PrimitiveComponent component { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector Location => new Vector(AddrOf(0x8));
        public Vector Velocity => new Vector(AddrOf(0x14));
        public Vector AngularVelocity => new Vector(AddrOf(0x20));
        public float Mass { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
    }

    public class ChaosHandlerSet : StructProxy
    {
        public ChaosHandlerSet(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr ChaosHandlers => AddrOf(0x8); // 
    }

    public class BreakEventCallbackWrapper : StructProxy
    {
        public BreakEventCallbackWrapper(System.IntPtr ptr) : base(ptr) {}
    }

    public class ChaosDebugSubstepControl : StructProxy
    {
        public ChaosDebugSubstepControl(System.IntPtr ptr) : base(ptr) {}
        public bool bPause { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bSubstep { get => (GetAt<byte>(0x1) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bStep { get => (GetAt<byte>(0x2) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class ChaosDebugDrawComponent : ActorComponent
    {
        public const string UeClassName = "ChaosDebugDrawComponent";
        public ChaosDebugDrawComponent(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosDebugDrawComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosDebugDrawComponent(p);
        public static ChaosDebugDrawComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosDebugDrawComponent(o.Pointer); }
        public static ChaosDebugDrawComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosDebugDrawComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosDebugDrawComponent(a[i].Pointer); return r; }
    }

    public class ChaosEventListenerComponent : ActorComponent
    {
        public const string UeClassName = "ChaosEventListenerComponent";
        public ChaosEventListenerComponent(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosEventListenerComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosEventListenerComponent(p);
        public static ChaosEventListenerComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosEventListenerComponent(o.Pointer); }
        public static ChaosEventListenerComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosEventListenerComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosEventListenerComponent(a[i].Pointer); return r; }
    }

    public class ChaosGameplayEventDispatcher : ChaosEventListenerComponent
    {
        public const string UeClassName = "ChaosGameplayEventDispatcher";
        public ChaosGameplayEventDispatcher(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosGameplayEventDispatcher FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosGameplayEventDispatcher(p);
        public static ChaosGameplayEventDispatcher FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosGameplayEventDispatcher(o.Pointer); }
        public static ChaosGameplayEventDispatcher[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosGameplayEventDispatcher[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosGameplayEventDispatcher(a[i].Pointer); return r; }
        public System.IntPtr CollisionEventRegistrations => AddrOf(0x1C8); // 
        public System.IntPtr BreakEventRegistrations => AddrOf(0x218); // 
    }

    public class ChaosNotifyHandlerInterface : Interface
    {
        public const string UeClassName = "ChaosNotifyHandlerInterface";
        public ChaosNotifyHandlerInterface(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosNotifyHandlerInterface FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosNotifyHandlerInterface(p);
        public static ChaosNotifyHandlerInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosNotifyHandlerInterface(o.Pointer); }
        public static ChaosNotifyHandlerInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosNotifyHandlerInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosNotifyHandlerInterface(a[i].Pointer); return r; }
    }

    public class ChaosSolverEngineBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "ChaosSolverEngineBlueprintLibrary";
        public ChaosSolverEngineBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosSolverEngineBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosSolverEngineBlueprintLibrary(p);
        public static ChaosSolverEngineBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosSolverEngineBlueprintLibrary(o.Pointer); }
        public static ChaosSolverEngineBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosSolverEngineBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosSolverEngineBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x9237918 — hookable via Hooks.InstallAt(NativeFunc_ConvertPhysicsCollisionToHitResult).</summary>
        public static System.IntPtr NativeFunc_ConvertPhysicsCollisionToHitResult => Memory.ModuleBase() + 0x9237918;
        public HitResult ConvertPhysicsCollisionToHitResult(ChaosPhysicsCollisionInfo PhysicsCollision)
        {
            var __pb = new ParamBuffer(248);
            __pb.Set<System.IntPtr>(0x0, PhysicsCollision);
            CallRaw("ConvertPhysicsCollisionToHitResult", __pb.Bytes);
            return __pb.Get<HitResult>(0x70);
        }
    }

    public class ChaosSolver : Object
    {
        public const string UeClassName = "ChaosSolver";
        public ChaosSolver(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosSolver FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosSolver(p);
        public static ChaosSolver FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosSolver(o.Pointer); }
        public static ChaosSolver[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosSolver[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosSolver(a[i].Pointer); return r; }
    }

    public class ChaosSolverActor : Actor
    {
        public const string UeClassName = "ChaosSolverActor";
        public ChaosSolverActor(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosSolverActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosSolverActor(p);
        public static ChaosSolverActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosSolverActor(o.Pointer); }
        public static ChaosSolverActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosSolverActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosSolverActor(a[i].Pointer); return r; }
        public float TimeStepMultiplier { get => GetAt<float>(0x220); set => SetAt(0x220, value); }
        public int CollisionIterations { get => GetAt<int>(0x224); set => SetAt(0x224, value); }
        public int PushOutIterations { get => GetAt<int>(0x228); set => SetAt(0x228, value); }
        public int PushOutPairIterations { get => GetAt<int>(0x22C); set => SetAt(0x22C, value); }
        public float ClusterConnectionFactor { get => GetAt<float>(0x230); set => SetAt(0x230, value); }
        public EClusterConnectionTypeEnum ClusterUnionConnectionType { get => (EClusterConnectionTypeEnum)GetAt<byte>(0x234); set => SetAt(0x234, (byte)value); }
        public bool DoGenerateCollisionData { get => Native.GetPropBool(Pointer, "DoGenerateCollisionData"); set => Native.SetPropBool(Pointer, "DoGenerateCollisionData", value); }
        public SolverCollisionFilterSettings CollisionFilterSettings => new SolverCollisionFilterSettings(AddrOf(0x238));
        public bool DoGenerateBreakingData { get => Native.GetPropBool(Pointer, "DoGenerateBreakingData"); set => Native.SetPropBool(Pointer, "DoGenerateBreakingData", value); }
        public SolverBreakingFilterSettings BreakingFilterSettings => new SolverBreakingFilterSettings(AddrOf(0x24C));
        public bool DoGenerateTrailingData { get => Native.GetPropBool(Pointer, "DoGenerateTrailingData"); set => Native.SetPropBool(Pointer, "DoGenerateTrailingData", value); }
        public SolverTrailingFilterSettings TrailingFilterSettings => new SolverTrailingFilterSettings(AddrOf(0x260));
        public bool bHasFloor { get => Native.GetPropBool(Pointer, "bHasFloor"); set => Native.SetPropBool(Pointer, "bHasFloor", value); }
        public float FloorHeight { get => GetAt<float>(0x274); set => SetAt(0x274, value); }
        public float MassScale { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public bool bGenerateContactGraph { get => Native.GetPropBool(Pointer, "bGenerateContactGraph"); set => Native.SetPropBool(Pointer, "bGenerateContactGraph", value); }
        public ChaosDebugSubstepControl ChaosDebugSubstepControl => new ChaosDebugSubstepControl(AddrOf(0x27D));
        public BillboardComponent SpriteComponent { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new BillboardComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public ChaosGameplayEventDispatcher GameplayEventDispatcherComponent { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new ChaosGameplayEventDispatcher(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x9238F64 — hookable via Hooks.InstallAt(NativeFunc_SetSolverActive).</summary>
        public static System.IntPtr NativeFunc_SetSolverActive => Memory.ModuleBase() + 0x9238F64;
        public void SetSolverActive(bool bActive)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bActive?1:0));
            CallRaw("SetSolverActive", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9239018 — hookable via Hooks.InstallAt(NativeFunc_SetAsCurrentWorldSolver).</summary>
        public static System.IntPtr NativeFunc_SetAsCurrentWorldSolver => Memory.ModuleBase() + 0x9239018;
        public void SetAsCurrentWorldSolver()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetAsCurrentWorldSolver", __pb.Bytes);
        }
    }

    public class ChaosSolverSettings : DeveloperSettings
    {
        public const string UeClassName = "ChaosSolverSettings";
        public ChaosSolverSettings(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosSolverSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosSolverSettings(p);
        public static ChaosSolverSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosSolverSettings(o.Pointer); }
        public static ChaosSolverSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosSolverSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosSolverSettings(a[i].Pointer); return r; }
        public SoftClassPath DefaultChaosSolverActorClass => new SoftClassPath(AddrOf(0x40));
    }

}
