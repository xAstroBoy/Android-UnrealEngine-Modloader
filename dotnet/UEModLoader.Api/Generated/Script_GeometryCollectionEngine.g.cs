// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/GeometryCollectionEngine
using System;

namespace UEModLoader.Game
{
    public enum EChaosBreakingSortMethod
    {
        SortNone = 0,
        SortByHighestMass = 1,
        SortByHighestSpeed = 2,
        SortByNearestFirst = 3,
        Count = 4,
    }

    public enum EChaosCollisionSortMethod
    {
        SortNone = 0,
        SortByHighestMass = 1,
        SortByHighestSpeed = 2,
        SortByHighestImpulse = 3,
        SortByNearestFirst = 4,
        Count = 5,
    }

    public enum EChaosTrailingSortMethod
    {
        SortNone = 0,
        SortByHighestMass = 1,
        SortByHighestSpeed = 2,
        SortByNearestFirst = 3,
        Count = 4,
    }

    public enum EGeometryCollectionDebugDrawActorHideGeometry
    {
        HideNone = 0,
        HideWithCollision = 1,
        HideSelected = 2,
        HideWholeCollection = 3,
        HideAll = 4,
    }

    public enum ECollectionGroupEnum
    {
        Chaos_Traansform = 0,
        Chaos_Max = 1,
    }

    public enum ECollectionAttributeEnum
    {
        Chaos_Active = 0,
        Chaos_DynamicState = 1,
        Chaos_CollisionGroup = 2,
        Chaos_Max = 3,
    }

    public class GeomComponentCacheParameters : StructProxy
    {
        public GeomComponentCacheParameters(System.IntPtr ptr) : base(ptr) {}
        public EGeometryCollectionCacheType CacheMode { get => (EGeometryCollectionCacheType)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public GeometryCollectionCache TargetCache { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new GeometryCollectionCache(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
        public float ReverseCacheBeginTime { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public bool SaveCollisionData { get => (GetAt<byte>(0x14) & 0xFF) != 0; set { var __b = GetAt<byte>(0x14); SetAt(0x14, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool DoGenerateCollisionData { get => (GetAt<byte>(0x15) & 0xFF) != 0; set { var __b = GetAt<byte>(0x15); SetAt(0x15, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int CollisionDataSizeMax { get => GetAt<int>(0x18); set => SetAt(0x18, value); }
        public bool DoCollisionDataSpatialHash { get => (GetAt<byte>(0x1C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1C); SetAt(0x1C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float CollisionDataSpatialHashRadius { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public int MaxCollisionPerCell { get => GetAt<int>(0x24); set => SetAt(0x24, value); }
        public bool SaveBreakingData { get => (GetAt<byte>(0x28) & 0xFF) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool DoGenerateBreakingData { get => (GetAt<byte>(0x29) & 0xFF) != 0; set { var __b = GetAt<byte>(0x29); SetAt(0x29, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int BreakingDataSizeMax { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public bool DoBreakingDataSpatialHash { get => (GetAt<byte>(0x30) & 0xFF) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float BreakingDataSpatialHashRadius { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public int MaxBreakingPerCell { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
        public bool SaveTrailingData { get => (GetAt<byte>(0x3C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool DoGenerateTrailingData { get => (GetAt<byte>(0x3D) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3D); SetAt(0x3D, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int TrailingDataSizeMax { get => GetAt<int>(0x40); set => SetAt(0x40, value); }
        public float TrailingMinSpeedThreshold { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public float TrailingMinVolumeThreshold { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
    }

    public class ChaosCollisionEventData : StructProxy
    {
        public ChaosCollisionEventData(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x0));
        public Vector Normal => new Vector(AddrOf(0xC));
        public Vector Velocity1 => new Vector(AddrOf(0x18));
        public Vector Velocity2 => new Vector(AddrOf(0x24));
        public float Mass1 { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float Mass2 { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public Vector Impulse => new Vector(AddrOf(0x38));
    }

    public class ChaosBreakingEventData : StructProxy
    {
        public ChaosBreakingEventData(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x0));
        public Vector Velocity => new Vector(AddrOf(0xC));
        public float Mass { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
    }

    public class ChaosTrailingEventData : StructProxy
    {
        public ChaosTrailingEventData(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x0));
        public Vector Velocity => new Vector(AddrOf(0xC));
        public Vector AngularVelocity => new Vector(AddrOf(0x18));
        public float Mass { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public int ParticleIndex { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
    }

    public class ChaosBreakingEventRequestSettings : StructProxy
    {
        public ChaosBreakingEventRequestSettings(System.IntPtr ptr) : base(ptr) {}
        public int MaxNumberOfResults { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public float MinRadius { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float MinSpeed { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float MinMass { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float MaxDistance { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public EChaosBreakingSortMethod SortMethod { get => (EChaosBreakingSortMethod)GetAt<byte>(0x14); set => SetAt(0x14, (byte)value); }
    }

    public class ChaosCollisionEventRequestSettings : StructProxy
    {
        public ChaosCollisionEventRequestSettings(System.IntPtr ptr) : base(ptr) {}
        public int MaxNumberResults { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public float MinMass { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float MinSpeed { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float MinImpulse { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float MaxDistance { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public EChaosCollisionSortMethod SortMethod { get => (EChaosCollisionSortMethod)GetAt<byte>(0x14); set => SetAt(0x14, (byte)value); }
    }

    public class ChaosTrailingEventRequestSettings : StructProxy
    {
        public ChaosTrailingEventRequestSettings(System.IntPtr ptr) : base(ptr) {}
        public int MaxNumberOfResults { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public float MinMass { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float MinSpeed { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float MinAngularSpeed { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float MaxDistance { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public EChaosTrailingSortMethod SortMethod { get => (EChaosTrailingSortMethod)GetAt<byte>(0x14); set => SetAt(0x14, (byte)value); }
    }

    public class GeometryCollectionDebugDrawActorSelectedRigidBody : StructProxy
    {
        public GeometryCollectionDebugDrawActorSelectedRigidBody(System.IntPtr ptr) : base(ptr) {}
        public int ID { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public ChaosSolverActor Solver { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new ChaosSolverActor(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
        public GeometryCollectionActor GeometryCollection { get { var __p = GetAt<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new GeometryCollectionActor(__p); } set => SetAt(0x10, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class GeometryCollectionDebugDrawWarningMessage : StructProxy
    {
        public GeometryCollectionDebugDrawWarningMessage(System.IntPtr ptr) : base(ptr) {}
    }

    public class GeometryCollectionSizeSpecificData : StructProxy
    {
        public GeometryCollectionSizeSpecificData(System.IntPtr ptr) : base(ptr) {}
        public float MaxSize { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public ECollisionTypeEnum CollisionType { get => (ECollisionTypeEnum)GetAt<byte>(0x4); set => SetAt(0x4, (byte)value); }
        public EImplicitTypeEnum ImplicitType { get => (EImplicitTypeEnum)GetAt<byte>(0x5); set => SetAt(0x5, (byte)value); }
        public int MinLevelSetResolution { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public int MaxLevelSetResolution { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
        public int MinClusterLevelSetResolution { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
        public int MaxClusterLevelSetResolution { get => GetAt<int>(0x14); set => SetAt(0x14, value); }
        public int CollisionObjectReductionPercentage { get => GetAt<int>(0x18); set => SetAt(0x18, value); }
        public float CollisionParticlesFraction { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public int MaximumCollisionParticles { get => GetAt<int>(0x20); set => SetAt(0x20, value); }
    }

    public class ChaosDestructionListener : SceneComponent
    {
        public const string UeClassName = "ChaosDestructionListener";
        public ChaosDestructionListener(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosDestructionListener FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosDestructionListener(p);
        public static ChaosDestructionListener FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosDestructionListener(o.Pointer); }
        public static ChaosDestructionListener[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosDestructionListener[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosDestructionListener(a[i].Pointer); return r; }
        public bool bIsCollisionEventListeningEnabled { get => Native.GetPropBool(Pointer, "bIsCollisionEventListeningEnabled"); set => Native.SetPropBool(Pointer, "bIsCollisionEventListeningEnabled", value); }
        public bool bIsBreakingEventListeningEnabled { get => Native.GetPropBool(Pointer, "bIsBreakingEventListeningEnabled"); set => Native.SetPropBool(Pointer, "bIsBreakingEventListeningEnabled", value); }
        public bool bIsTrailingEventListeningEnabled { get => Native.GetPropBool(Pointer, "bIsTrailingEventListeningEnabled"); set => Native.SetPropBool(Pointer, "bIsTrailingEventListeningEnabled", value); }
        public ChaosCollisionEventRequestSettings CollisionEventRequestSettings => new ChaosCollisionEventRequestSettings(AddrOf(0x1F4));
        public ChaosBreakingEventRequestSettings BreakingEventRequestSettings => new ChaosBreakingEventRequestSettings(AddrOf(0x20C));
        public ChaosTrailingEventRequestSettings TrailingEventRequestSettings => new ChaosTrailingEventRequestSettings(AddrOf(0x224));
        public System.IntPtr ChaosSolverActors => AddrOf(0x240); // 
        public System.IntPtr GeometryCollectionActors => AddrOf(0x290); // 
        public System.IntPtr OnCollisionEvents => AddrOf(0x2E0); // 
        public System.IntPtr OnBreakingEvents => AddrOf(0x2F0); // 
        public System.IntPtr OnTrailingEvents => AddrOf(0x300); // 
        /// <summary>[Native] thunk RVA 0x9276760 — hookable via Hooks.InstallAt(NativeFunc_SortTrailingEvents).</summary>
        public static System.IntPtr NativeFunc_SortTrailingEvents => Memory.ModuleBase() + 0x9276760;
        public void SortTrailingEvents(System.IntPtr TrailingEvents, EChaosTrailingSortMethod SortMethod)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, TrailingEvents);
            __pb.Set<byte>(0x10, (byte)SortMethod);
            CallRaw("SortTrailingEvents", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276960 — hookable via Hooks.InstallAt(NativeFunc_SortCollisionEvents).</summary>
        public static System.IntPtr NativeFunc_SortCollisionEvents => Memory.ModuleBase() + 0x9276960;
        public void SortCollisionEvents(System.IntPtr CollisionEvents, EChaosCollisionSortMethod SortMethod)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, CollisionEvents);
            __pb.Set<byte>(0x10, (byte)SortMethod);
            CallRaw("SortCollisionEvents", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276860 — hookable via Hooks.InstallAt(NativeFunc_SortBreakingEvents).</summary>
        public static System.IntPtr NativeFunc_SortBreakingEvents => Memory.ModuleBase() + 0x9276860;
        public void SortBreakingEvents(System.IntPtr BreakingEvents, EChaosBreakingSortMethod SortMethod)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, BreakingEvents);
            __pb.Set<byte>(0x10, (byte)SortMethod);
            CallRaw("SortBreakingEvents", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276C9C — hookable via Hooks.InstallAt(NativeFunc_SetTrailingEventRequestSettings).</summary>
        public static System.IntPtr NativeFunc_SetTrailingEventRequestSettings => Memory.ModuleBase() + 0x9276C9C;
        public void SetTrailingEventRequestSettings(ChaosTrailingEventRequestSettings InSettings)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InSettings);
            CallRaw("SetTrailingEventRequestSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276A98 — hookable via Hooks.InstallAt(NativeFunc_SetTrailingEventEnabled).</summary>
        public static System.IntPtr NativeFunc_SetTrailingEventEnabled => Memory.ModuleBase() + 0x9276A98;
        public void SetTrailingEventEnabled(bool bIsEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bIsEnabled?1:0));
            CallRaw("SetTrailingEventEnabled", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276E1C — hookable via Hooks.InstallAt(NativeFunc_SetCollisionEventRequestSettings).</summary>
        public static System.IntPtr NativeFunc_SetCollisionEventRequestSettings => Memory.ModuleBase() + 0x9276E1C;
        public void SetCollisionEventRequestSettings(ChaosCollisionEventRequestSettings InSettings)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InSettings);
            CallRaw("SetCollisionEventRequestSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276BF0 — hookable via Hooks.InstallAt(NativeFunc_SetCollisionEventEnabled).</summary>
        public static System.IntPtr NativeFunc_SetCollisionEventEnabled => Memory.ModuleBase() + 0x9276BF0;
        public void SetCollisionEventEnabled(bool bIsEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bIsEnabled?1:0));
            CallRaw("SetCollisionEventEnabled", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276D5C — hookable via Hooks.InstallAt(NativeFunc_SetBreakingEventRequestSettings).</summary>
        public static System.IntPtr NativeFunc_SetBreakingEventRequestSettings => Memory.ModuleBase() + 0x9276D5C;
        public void SetBreakingEventRequestSettings(ChaosBreakingEventRequestSettings InSettings)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InSettings);
            CallRaw("SetBreakingEventRequestSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276B44 — hookable via Hooks.InstallAt(NativeFunc_SetBreakingEventEnabled).</summary>
        public static System.IntPtr NativeFunc_SetBreakingEventEnabled => Memory.ModuleBase() + 0x9276B44;
        public void SetBreakingEventEnabled(bool bIsEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bIsEnabled?1:0));
            CallRaw("SetBreakingEventEnabled", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276EDC — hookable via Hooks.InstallAt(NativeFunc_RemoveGeometryCollectionActor).</summary>
        public static System.IntPtr NativeFunc_RemoveGeometryCollectionActor => Memory.ModuleBase() + 0x9276EDC;
        public void RemoveGeometryCollectionActor(GeometryCollectionActor GeometryCollectionActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, GeometryCollectionActor);
            CallRaw("RemoveGeometryCollectionActor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9277024 — hookable via Hooks.InstallAt(NativeFunc_RemoveChaosSolverActor).</summary>
        public static System.IntPtr NativeFunc_RemoveChaosSolverActor => Memory.ModuleBase() + 0x9277024;
        public void RemoveChaosSolverActor(ChaosSolverActor ChaosSolverActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ChaosSolverActor);
            CallRaw("RemoveChaosSolverActor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9276A60 — hookable via Hooks.InstallAt(NativeFunc_IsEventListening).</summary>
        public static System.IntPtr NativeFunc_IsEventListening => Memory.ModuleBase() + 0x9276A60;
        public bool IsEventListening()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsEventListening", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x9276F80 — hookable via Hooks.InstallAt(NativeFunc_AddGeometryCollectionActor).</summary>
        public static System.IntPtr NativeFunc_AddGeometryCollectionActor => Memory.ModuleBase() + 0x9276F80;
        public void AddGeometryCollectionActor(GeometryCollectionActor GeometryCollectionActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, GeometryCollectionActor);
            CallRaw("AddGeometryCollectionActor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92770C8 — hookable via Hooks.InstallAt(NativeFunc_AddChaosSolverActor).</summary>
        public static System.IntPtr NativeFunc_AddChaosSolverActor => Memory.ModuleBase() + 0x92770C8;
        public void AddChaosSolverActor(ChaosSolverActor ChaosSolverActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ChaosSolverActor);
            CallRaw("AddChaosSolverActor", __pb.Bytes);
        }
    }

    public class GeometryCollectionActor : Actor
    {
        public const string UeClassName = "GeometryCollectionActor";
        public GeometryCollectionActor(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCollectionActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCollectionActor(p);
        public static GeometryCollectionActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCollectionActor(o.Pointer); }
        public static GeometryCollectionActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCollectionActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCollectionActor(a[i].Pointer); return r; }
        public GeometryCollectionComponent GeometryCollectionComponent { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new GeometryCollectionComponent(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
        public GeometryCollectionDebugDrawComponent GeometryCollectionDebugDrawComponent { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new GeometryCollectionDebugDrawComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x9279DA4 — hookable via Hooks.InstallAt(NativeFunc_RaycastSingle).</summary>
        public static System.IntPtr NativeFunc_RaycastSingle => Memory.ModuleBase() + 0x9279DA4;
        public bool RaycastSingle(Vector Start, Vector End, HitResult OutHit)
        {
            var __pb = new ParamBuffer(161);
            __pb.Set<System.IntPtr>(0x0, Start);
            __pb.Set<System.IntPtr>(0xC, End);
            __pb.Set<System.IntPtr>(0x18, OutHit);
            CallRaw("RaycastSingle", __pb.Bytes);
            return __pb.Get<byte>(0xA0) != 0;
        }
    }

    public class GeometryCollectionCache : Object
    {
        public const string UeClassName = "GeometryCollectionCache";
        public GeometryCollectionCache(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCollectionCache FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCollectionCache(p);
        public static GeometryCollectionCache FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCollectionCache(o.Pointer); }
        public static GeometryCollectionCache[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCollectionCache[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCollectionCache(a[i].Pointer); return r; }
        public RecordedTransformTrack RecordedData => new RecordedTransformTrack(AddrOf(0x28));
        public GeometryCollection SupportedCollection { get { var __p = GetAt<System.IntPtr>(0x38); return __p==System.IntPtr.Zero?null:new GeometryCollection(__p); } set => SetAt(0x38, value?.Pointer ?? System.IntPtr.Zero); }
        public Guid CompatibleCollectionState => new Guid(AddrOf(0x40));
    }

    public class GeometryCollectionComponent : MeshComponent
    {
        public const string UeClassName = "GeometryCollectionComponent";
        public GeometryCollectionComponent(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCollectionComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCollectionComponent(p);
        public static GeometryCollectionComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCollectionComponent(o.Pointer); }
        public static GeometryCollectionComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCollectionComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCollectionComponent(a[i].Pointer); return r; }
        public ChaosSolverActor ChaosSolverActor { get { var __p = GetAt<System.IntPtr>(0x438); return __p==System.IntPtr.Zero?null:new ChaosSolverActor(__p); } set => SetAt(0x438, value?.Pointer ?? System.IntPtr.Zero); }
        public GeometryCollection RestCollection { get { var __p = GetAt<System.IntPtr>(0x520); return __p==System.IntPtr.Zero?null:new GeometryCollection(__p); } set => SetAt(0x520, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> InitializationFields => new TArray<System.IntPtr>(AddrOf(0x528)); // TArray<UObject*>
        public bool Simulating { get => Native.GetPropBool(Pointer, "Simulating"); set => Native.SetPropBool(Pointer, "Simulating", value); }
        public EObjectStateTypeEnum ObjectType { get => (EObjectStateTypeEnum)GetAt<byte>(0x540); set => SetAt(0x540, (byte)value); }
        public bool EnableClustering { get => Native.GetPropBool(Pointer, "EnableClustering"); set => Native.SetPropBool(Pointer, "EnableClustering", value); }
        public int ClusterGroupIndex { get => GetAt<int>(0x544); set => SetAt(0x544, value); }
        public int MaxClusterLevel { get => GetAt<int>(0x548); set => SetAt(0x548, value); }
        public TArray<System.IntPtr> DamageThreshold => new TArray<System.IntPtr>(AddrOf(0x550)); // TArray<float>
        public EClusterConnectionTypeEnum ClusterConnectionType { get => (EClusterConnectionTypeEnum)GetAt<byte>(0x560); set => SetAt(0x560, (byte)value); }
        public int CollisionGroup { get => GetAt<int>(0x564); set => SetAt(0x564, value); }
        public float CollisionSampleFraction { get => GetAt<float>(0x568); set => SetAt(0x568, value); }
        public float LinearEtherDrag { get => GetAt<float>(0x56C); set => SetAt(0x56C, value); }
        public float AngularEtherDrag { get => GetAt<float>(0x570); set => SetAt(0x570, value); }
        public ChaosPhysicalMaterial PhysicalMaterial { get { var __p = GetAt<System.IntPtr>(0x578); return __p==System.IntPtr.Zero?null:new ChaosPhysicalMaterial(__p); } set => SetAt(0x578, value?.Pointer ?? System.IntPtr.Zero); }
        public EInitialVelocityTypeEnum InitialVelocityType { get => (EInitialVelocityTypeEnum)GetAt<byte>(0x580); set => SetAt(0x580, (byte)value); }
        public Vector InitialLinearVelocity => new Vector(AddrOf(0x584));
        public Vector InitialAngularVelocity => new Vector(AddrOf(0x590));
        public GeomComponentCacheParameters CacheParameters => new GeomComponentCacheParameters(AddrOf(0x5A0));
        public System.IntPtr NotifyGeometryCollectionPhysicsStateChange => AddrOf(0x5F0); // 
        public System.IntPtr NotifyGeometryCollectionPhysicsLoadingStateChange => AddrOf(0x600); // 
        public System.IntPtr OnChaosBreakEvent => AddrOf(0x628); // 
        public float DesiredCacheTime { get => GetAt<float>(0x638); set => SetAt(0x638, value); }
        public bool CachePlayback { get => Native.GetPropBool(Pointer, "CachePlayback"); set => Native.SetPropBool(Pointer, "CachePlayback", value); }
        public System.IntPtr OnChaosPhysicsCollision => AddrOf(0x640); // 
        public bool bNotifyBreaks { get => Native.GetPropBool(Pointer, "bNotifyBreaks"); set => Native.SetPropBool(Pointer, "bNotifyBreaks", value); }
        public bool bNotifyCollisions { get => Native.GetPropBool(Pointer, "bNotifyCollisions"); set => Native.SetPropBool(Pointer, "bNotifyCollisions", value); }
        public BodySetup DummyBodySetup { get { var __p = GetAt<System.IntPtr>(0x850); return __p==System.IntPtr.Zero?null:new BodySetup(__p); } set => SetAt(0x850, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x927B238 — hookable via Hooks.InstallAt(NativeFunc_SetNotifyBreaks).</summary>
        public static System.IntPtr NativeFunc_SetNotifyBreaks => Memory.ModuleBase() + 0x927B238;
        public void SetNotifyBreaks(bool bNewNotifyBreaks)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bNewNotifyBreaks?1:0));
            CallRaw("SetNotifyBreaks", __pb.Bytes);
        }
        public void ReceivePhysicsCollision(ChaosPhysicsCollisionInfo CollisionInfo)
        {
            var __pb = new ParamBuffer(112);
            __pb.Set<System.IntPtr>(0x0, CollisionInfo);
            CallRaw("ReceivePhysicsCollision", __pb.Bytes);
        }
        public void NotifyGeometryCollectionPhysicsStateChange__DelegateSignature(GeometryCollectionComponent FracturedComponent)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, FracturedComponent);
            CallRaw("NotifyGeometryCollectionPhysicsStateChange__DelegateSignature", __pb.Bytes);
        }
        public void NotifyGeometryCollectionPhysicsLoadingStateChange__DelegateSignature(GeometryCollectionComponent FracturedComponent)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, FracturedComponent);
            CallRaw("NotifyGeometryCollectionPhysicsLoadingStateChange__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x927B2E4 — hookable via Hooks.InstallAt(NativeFunc_ApplyPhysicsField).</summary>
        public static System.IntPtr NativeFunc_ApplyPhysicsField => Memory.ModuleBase() + 0x927B2E4;
        public void ApplyPhysicsField(bool Enabled, EGeometryCollectionPhysicsTypeEnum Target, FieldSystemMetaData MetaData, FieldNodeBase Field)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            __pb.Set<byte>(0x1, (byte)Target);
            __pb.SetObject(0x8, MetaData);
            __pb.SetObject(0x10, Field);
            CallRaw("ApplyPhysicsField", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x927B45C — hookable via Hooks.InstallAt(NativeFunc_ApplyKinematicField).</summary>
        public static System.IntPtr NativeFunc_ApplyKinematicField => Memory.ModuleBase() + 0x927B45C;
        public void ApplyKinematicField(float Radius, Vector Position)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Radius);
            __pb.Set<System.IntPtr>(0x4, Position);
            CallRaw("ApplyKinematicField", __pb.Bytes);
        }
    }

    public class GeometryCollectionDebugDrawActor : Actor
    {
        public const string UeClassName = "GeometryCollectionDebugDrawActor";
        public GeometryCollectionDebugDrawActor(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCollectionDebugDrawActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCollectionDebugDrawActor(p);
        public static GeometryCollectionDebugDrawActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCollectionDebugDrawActor(o.Pointer); }
        public static GeometryCollectionDebugDrawActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCollectionDebugDrawActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCollectionDebugDrawActor(a[i].Pointer); return r; }
        public GeometryCollectionDebugDrawWarningMessage WarningMessage => new GeometryCollectionDebugDrawWarningMessage(AddrOf(0x220));
        public GeometryCollectionDebugDrawActorSelectedRigidBody SelectedRigidBody => new GeometryCollectionDebugDrawActorSelectedRigidBody(AddrOf(0x228));
        public bool bDebugDrawWholeCollection { get => Native.GetPropBool(Pointer, "bDebugDrawWholeCollection"); set => Native.SetPropBool(Pointer, "bDebugDrawWholeCollection", value); }
        public bool bDebugDrawHierarchy { get => Native.GetPropBool(Pointer, "bDebugDrawHierarchy"); set => Native.SetPropBool(Pointer, "bDebugDrawHierarchy", value); }
        public bool bDebugDrawClustering { get => Native.GetPropBool(Pointer, "bDebugDrawClustering"); set => Native.SetPropBool(Pointer, "bDebugDrawClustering", value); }
        public EGeometryCollectionDebugDrawActorHideGeometry HideGeometry { get => (EGeometryCollectionDebugDrawActorHideGeometry)GetAt<byte>(0x243); set => SetAt(0x243, (byte)value); }
        public bool bShowRigidBodyId { get => Native.GetPropBool(Pointer, "bShowRigidBodyId"); set => Native.SetPropBool(Pointer, "bShowRigidBodyId", value); }
        public bool bShowRigidBodyCollision { get => Native.GetPropBool(Pointer, "bShowRigidBodyCollision"); set => Native.SetPropBool(Pointer, "bShowRigidBodyCollision", value); }
        public bool bCollisionAtOrigin { get => Native.GetPropBool(Pointer, "bCollisionAtOrigin"); set => Native.SetPropBool(Pointer, "bCollisionAtOrigin", value); }
        public bool bShowRigidBodyTransform { get => Native.GetPropBool(Pointer, "bShowRigidBodyTransform"); set => Native.SetPropBool(Pointer, "bShowRigidBodyTransform", value); }
        public bool bShowRigidBodyInertia { get => Native.GetPropBool(Pointer, "bShowRigidBodyInertia"); set => Native.SetPropBool(Pointer, "bShowRigidBodyInertia", value); }
        public bool bShowRigidBodyVelocity { get => Native.GetPropBool(Pointer, "bShowRigidBodyVelocity"); set => Native.SetPropBool(Pointer, "bShowRigidBodyVelocity", value); }
        public bool bShowRigidBodyForce { get => Native.GetPropBool(Pointer, "bShowRigidBodyForce"); set => Native.SetPropBool(Pointer, "bShowRigidBodyForce", value); }
        public bool bShowRigidBodyInfos { get => Native.GetPropBool(Pointer, "bShowRigidBodyInfos"); set => Native.SetPropBool(Pointer, "bShowRigidBodyInfos", value); }
        public bool bShowTransformIndex { get => Native.GetPropBool(Pointer, "bShowTransformIndex"); set => Native.SetPropBool(Pointer, "bShowTransformIndex", value); }
        public bool bShowTransform { get => Native.GetPropBool(Pointer, "bShowTransform"); set => Native.SetPropBool(Pointer, "bShowTransform", value); }
        public bool bShowParent { get => Native.GetPropBool(Pointer, "bShowParent"); set => Native.SetPropBool(Pointer, "bShowParent", value); }
        public bool bShowLevel { get => Native.GetPropBool(Pointer, "bShowLevel"); set => Native.SetPropBool(Pointer, "bShowLevel", value); }
        public bool bShowConnectivityEdges { get => Native.GetPropBool(Pointer, "bShowConnectivityEdges"); set => Native.SetPropBool(Pointer, "bShowConnectivityEdges", value); }
        public bool bShowGeometryIndex { get => Native.GetPropBool(Pointer, "bShowGeometryIndex"); set => Native.SetPropBool(Pointer, "bShowGeometryIndex", value); }
        public bool bShowGeometryTransform { get => Native.GetPropBool(Pointer, "bShowGeometryTransform"); set => Native.SetPropBool(Pointer, "bShowGeometryTransform", value); }
        public bool bShowBoundingBox { get => Native.GetPropBool(Pointer, "bShowBoundingBox"); set => Native.SetPropBool(Pointer, "bShowBoundingBox", value); }
        public bool bShowFaces { get => Native.GetPropBool(Pointer, "bShowFaces"); set => Native.SetPropBool(Pointer, "bShowFaces", value); }
        public bool bShowFaceIndices { get => Native.GetPropBool(Pointer, "bShowFaceIndices"); set => Native.SetPropBool(Pointer, "bShowFaceIndices", value); }
        public bool bShowFaceNormals { get => Native.GetPropBool(Pointer, "bShowFaceNormals"); set => Native.SetPropBool(Pointer, "bShowFaceNormals", value); }
        public bool bShowSingleFace { get => Native.GetPropBool(Pointer, "bShowSingleFace"); set => Native.SetPropBool(Pointer, "bShowSingleFace", value); }
        public int SingleFaceIndex { get => GetAt<int>(0x258); set => SetAt(0x258, value); }
        public bool bShowVertices { get => Native.GetPropBool(Pointer, "bShowVertices"); set => Native.SetPropBool(Pointer, "bShowVertices", value); }
        public bool bShowVertexIndices { get => Native.GetPropBool(Pointer, "bShowVertexIndices"); set => Native.SetPropBool(Pointer, "bShowVertexIndices", value); }
        public bool bShowVertexNormals { get => Native.GetPropBool(Pointer, "bShowVertexNormals"); set => Native.SetPropBool(Pointer, "bShowVertexNormals", value); }
        public bool bUseActiveVisualization { get => Native.GetPropBool(Pointer, "bUseActiveVisualization"); set => Native.SetPropBool(Pointer, "bUseActiveVisualization", value); }
        public float PointThickness { get => GetAt<float>(0x260); set => SetAt(0x260, value); }
        public float LineThickness { get => GetAt<float>(0x264); set => SetAt(0x264, value); }
        public bool bTextShadow { get => Native.GetPropBool(Pointer, "bTextShadow"); set => Native.SetPropBool(Pointer, "bTextShadow", value); }
        public float TextScale { get => GetAt<float>(0x26C); set => SetAt(0x26C, value); }
        public float NormalScale { get => GetAt<float>(0x270); set => SetAt(0x270, value); }
        public float AxisScale { get => GetAt<float>(0x274); set => SetAt(0x274, value); }
        public float ArrowScale { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public Color RigidBodyIdColor => new Color(AddrOf(0x27C));
        public float RigidBodyTransformScale { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public Color RigidBodyCollisionColor => new Color(AddrOf(0x284));
        public Color RigidBodyInertiaColor => new Color(AddrOf(0x288));
        public Color RigidBodyVelocityColor => new Color(AddrOf(0x28C));
        public Color RigidBodyForceColor => new Color(AddrOf(0x290));
        public Color RigidBodyInfoColor => new Color(AddrOf(0x294));
        public Color TransformIndexColor => new Color(AddrOf(0x298));
        public float TransformScale { get => GetAt<float>(0x29C); set => SetAt(0x29C, value); }
        public Color LevelColor => new Color(AddrOf(0x2A0));
        public Color ParentColor => new Color(AddrOf(0x2A4));
        public float ConnectivityEdgeThickness { get => GetAt<float>(0x2A8); set => SetAt(0x2A8, value); }
        public Color GeometryIndexColor => new Color(AddrOf(0x2AC));
        public float GeometryTransformScale { get => GetAt<float>(0x2B0); set => SetAt(0x2B0, value); }
        public Color BoundingBoxColor => new Color(AddrOf(0x2B4));
        public Color FaceColor => new Color(AddrOf(0x2B8));
        public Color FaceIndexColor => new Color(AddrOf(0x2BC));
        public Color FaceNormalColor => new Color(AddrOf(0x2C0));
        public Color SingleFaceColor => new Color(AddrOf(0x2C4));
        public Color VertexColor => new Color(AddrOf(0x2C8));
        public Color VertexIndexColor => new Color(AddrOf(0x2CC));
        public Color VertexNormalColor => new Color(AddrOf(0x2D0));
        public BillboardComponent SpriteComponent { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new BillboardComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class GeometryCollectionDebugDrawComponent : ActorComponent
    {
        public const string UeClassName = "GeometryCollectionDebugDrawComponent";
        public GeometryCollectionDebugDrawComponent(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCollectionDebugDrawComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCollectionDebugDrawComponent(p);
        public static GeometryCollectionDebugDrawComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCollectionDebugDrawComponent(o.Pointer); }
        public static GeometryCollectionDebugDrawComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCollectionDebugDrawComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCollectionDebugDrawComponent(a[i].Pointer); return r; }
        public GeometryCollectionDebugDrawActor GeometryCollectionDebugDrawActor { get { var __p = GetAt<System.IntPtr>(0xB0); return __p==System.IntPtr.Zero?null:new GeometryCollectionDebugDrawActor(__p); } set => SetAt(0xB0, value?.Pointer ?? System.IntPtr.Zero); }
        public GeometryCollectionRenderLevelSetActor GeometryCollectionRenderLevelSetActor { get { var __p = GetAt<System.IntPtr>(0xB8); return __p==System.IntPtr.Zero?null:new GeometryCollectionRenderLevelSetActor(__p); } set => SetAt(0xB8, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class GeometryCollection : Object
    {
        public const string UeClassName = "GeometryCollection";
        public GeometryCollection(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCollection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCollection(p);
        public static GeometryCollection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCollection(o.Pointer); }
        public static GeometryCollection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCollection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCollection(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Materials => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<UObject*>
        public ECollisionTypeEnum CollisionType { get => (ECollisionTypeEnum)GetAt<byte>(0x40); set => SetAt(0x40, (byte)value); }
        public EImplicitTypeEnum ImplicitType { get => (EImplicitTypeEnum)GetAt<byte>(0x41); set => SetAt(0x41, (byte)value); }
        public int MinLevelSetResolution { get => GetAt<int>(0x44); set => SetAt(0x44, value); }
        public int MaxLevelSetResolution { get => GetAt<int>(0x48); set => SetAt(0x48, value); }
        public int MinClusterLevelSetResolution { get => GetAt<int>(0x4C); set => SetAt(0x4C, value); }
        public int MaxClusterLevelSetResolution { get => GetAt<int>(0x50); set => SetAt(0x50, value); }
        public float CollisionObjectReductionPercentage { get => GetAt<float>(0x54); set => SetAt(0x54, value); }
        public bool bMassAsDensity { get => Native.GetPropBool(Pointer, "bMassAsDensity"); set => Native.SetPropBool(Pointer, "bMassAsDensity", value); }
        public float Mass { get => GetAt<float>(0x5C); set => SetAt(0x5C, value); }
        public float MinimumMassClamp { get => GetAt<float>(0x60); set => SetAt(0x60, value); }
        public float CollisionParticlesFraction { get => GetAt<float>(0x64); set => SetAt(0x64, value); }
        public int MaximumCollisionParticles { get => GetAt<int>(0x68); set => SetAt(0x68, value); }
        public TArray<System.IntPtr> SizeSpecificData => new TArray<System.IntPtr>(AddrOf(0x70)); // TArray<struct>
        public bool EnableRemovePiecesOnFracture { get => Native.GetPropBool(Pointer, "EnableRemovePiecesOnFracture"); set => Native.SetPropBool(Pointer, "EnableRemovePiecesOnFracture", value); }
        public TArray<System.IntPtr> RemoveOnFractureMaterials => new TArray<System.IntPtr>(AddrOf(0x88)); // TArray<UObject*>
        public Guid PersistentGuid => new Guid(AddrOf(0x98));
        public Guid StateGuid => new Guid(AddrOf(0xA8));
        public int BoneSelectedMaterialIndex { get => GetAt<int>(0xB8); set => SetAt(0xB8, value); }
    }

    public class GeometryCollectionRenderLevelSetActor : Actor
    {
        public const string UeClassName = "GeometryCollectionRenderLevelSetActor";
        public GeometryCollectionRenderLevelSetActor(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCollectionRenderLevelSetActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCollectionRenderLevelSetActor(p);
        public static GeometryCollectionRenderLevelSetActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCollectionRenderLevelSetActor(o.Pointer); }
        public static GeometryCollectionRenderLevelSetActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCollectionRenderLevelSetActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCollectionRenderLevelSetActor(a[i].Pointer); return r; }
        public VolumeTexture TargetVolumeTexture { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new VolumeTexture(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
        public Material RayMarchMaterial { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new Material(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public float SurfaceTolerance { get => GetAt<float>(0x230); set => SetAt(0x230, value); }
        public float Isovalue { get => GetAt<float>(0x234); set => SetAt(0x234, value); }
        public bool Enabled { get => Native.GetPropBool(Pointer, "Enabled"); set => Native.SetPropBool(Pointer, "Enabled", value); }
        public bool RenderVolumeBoundingBox { get => Native.GetPropBool(Pointer, "RenderVolumeBoundingBox"); set => Native.SetPropBool(Pointer, "RenderVolumeBoundingBox", value); }
    }

    public class SkeletalMeshSimulationComponent : ActorComponent
    {
        public const string UeClassName = "SkeletalMeshSimulationComponent";
        public SkeletalMeshSimulationComponent(System.IntPtr ptr) : base(ptr) {}
        public static new SkeletalMeshSimulationComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SkeletalMeshSimulationComponent(p);
        public static SkeletalMeshSimulationComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SkeletalMeshSimulationComponent(o.Pointer); }
        public static SkeletalMeshSimulationComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SkeletalMeshSimulationComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SkeletalMeshSimulationComponent(a[i].Pointer); return r; }
        public ChaosPhysicalMaterial PhysicalMaterial { get { var __p = GetAt<System.IntPtr>(0xB8); return __p==System.IntPtr.Zero?null:new ChaosPhysicalMaterial(__p); } set => SetAt(0xB8, value?.Pointer ?? System.IntPtr.Zero); }
        public ChaosSolverActor ChaosSolverActor { get { var __p = GetAt<System.IntPtr>(0xC0); return __p==System.IntPtr.Zero?null:new ChaosSolverActor(__p); } set => SetAt(0xC0, value?.Pointer ?? System.IntPtr.Zero); }
        public PhysicsAsset OverridePhysicsAsset { get { var __p = GetAt<System.IntPtr>(0xC8); return __p==System.IntPtr.Zero?null:new PhysicsAsset(__p); } set => SetAt(0xC8, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bSimulating { get => Native.GetPropBool(Pointer, "bSimulating"); set => Native.SetPropBool(Pointer, "bSimulating", value); }
        public bool bNotifyCollisions { get => Native.GetPropBool(Pointer, "bNotifyCollisions"); set => Native.SetPropBool(Pointer, "bNotifyCollisions", value); }
        public EObjectStateTypeEnum ObjectType { get => (EObjectStateTypeEnum)GetAt<byte>(0xD2); set => SetAt(0xD2, (byte)value); }
        public float Density { get => GetAt<float>(0xD4); set => SetAt(0xD4, value); }
        public float MinMass { get => GetAt<float>(0xD8); set => SetAt(0xD8, value); }
        public float MaxMass { get => GetAt<float>(0xDC); set => SetAt(0xDC, value); }
        public ECollisionTypeEnum CollisionType { get => (ECollisionTypeEnum)GetAt<byte>(0xE0); set => SetAt(0xE0, (byte)value); }
        public float ImplicitShapeParticlesPerUnitArea { get => GetAt<float>(0xE4); set => SetAt(0xE4, value); }
        public int ImplicitShapeMinNumParticles { get => GetAt<int>(0xE8); set => SetAt(0xE8, value); }
        public int ImplicitShapeMaxNumParticles { get => GetAt<int>(0xEC); set => SetAt(0xEC, value); }
        public int MinLevelSetResolution { get => GetAt<int>(0xF0); set => SetAt(0xF0, value); }
        public int MaxLevelSetResolution { get => GetAt<int>(0xF4); set => SetAt(0xF4, value); }
        public int CollisionGroup { get => GetAt<int>(0xF8); set => SetAt(0xF8, value); }
        public EInitialVelocityTypeEnum InitialVelocityType { get => (EInitialVelocityTypeEnum)GetAt<byte>(0xFC); set => SetAt(0xFC, (byte)value); }
        public Vector InitialLinearVelocity => new Vector(AddrOf(0x100));
        public Vector InitialAngularVelocity => new Vector(AddrOf(0x10C));
        public System.IntPtr OnChaosPhysicsCollision => AddrOf(0x118); // 
        public void ReceivePhysicsCollision(ChaosPhysicsCollisionInfo CollisionInfo)
        {
            var __pb = new ParamBuffer(112);
            __pb.Set<System.IntPtr>(0x0, CollisionInfo);
            CallRaw("ReceivePhysicsCollision", __pb.Bytes);
        }
    }

    public class StaticMeshSimulationComponent : ActorComponent
    {
        public const string UeClassName = "StaticMeshSimulationComponent";
        public StaticMeshSimulationComponent(System.IntPtr ptr) : base(ptr) {}
        public static new StaticMeshSimulationComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new StaticMeshSimulationComponent(p);
        public static StaticMeshSimulationComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new StaticMeshSimulationComponent(o.Pointer); }
        public static StaticMeshSimulationComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new StaticMeshSimulationComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new StaticMeshSimulationComponent(a[i].Pointer); return r; }
        public bool Simulating { get => Native.GetPropBool(Pointer, "Simulating"); set => Native.SetPropBool(Pointer, "Simulating", value); }
        public bool bNotifyCollisions { get => Native.GetPropBool(Pointer, "bNotifyCollisions"); set => Native.SetPropBool(Pointer, "bNotifyCollisions", value); }
        public EObjectStateTypeEnum ObjectType { get => (EObjectStateTypeEnum)GetAt<byte>(0xBA); set => SetAt(0xBA, (byte)value); }
        public float Mass { get => GetAt<float>(0xBC); set => SetAt(0xBC, value); }
        public ECollisionTypeEnum CollisionType { get => (ECollisionTypeEnum)GetAt<byte>(0xC0); set => SetAt(0xC0, (byte)value); }
        public EImplicitTypeEnum ImplicitType { get => (EImplicitTypeEnum)GetAt<byte>(0xC1); set => SetAt(0xC1, (byte)value); }
        public int MinLevelSetResolution { get => GetAt<int>(0xC4); set => SetAt(0xC4, value); }
        public int MaxLevelSetResolution { get => GetAt<int>(0xC8); set => SetAt(0xC8, value); }
        public EInitialVelocityTypeEnum InitialVelocityType { get => (EInitialVelocityTypeEnum)GetAt<byte>(0xCC); set => SetAt(0xCC, (byte)value); }
        public Vector InitialLinearVelocity => new Vector(AddrOf(0xD0));
        public Vector InitialAngularVelocity => new Vector(AddrOf(0xDC));
        public float DamageThreshold { get => GetAt<float>(0xE8); set => SetAt(0xE8, value); }
        public ChaosPhysicalMaterial PhysicalMaterial { get { var __p = GetAt<System.IntPtr>(0xF0); return __p==System.IntPtr.Zero?null:new ChaosPhysicalMaterial(__p); } set => SetAt(0xF0, value?.Pointer ?? System.IntPtr.Zero); }
        public ChaosSolverActor ChaosSolverActor { get { var __p = GetAt<System.IntPtr>(0xF8); return __p==System.IntPtr.Zero?null:new ChaosSolverActor(__p); } set => SetAt(0xF8, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr OnChaosPhysicsCollision => AddrOf(0x100); // 
        public TArray<System.IntPtr> SimulatedComponents => new TArray<System.IntPtr>(AddrOf(0x120)); // TArray<UObject*>
        public void ReceivePhysicsCollision(ChaosPhysicsCollisionInfo CollisionInfo)
        {
            var __pb = new ParamBuffer(112);
            __pb.Set<System.IntPtr>(0x0, CollisionInfo);
            CallRaw("ReceivePhysicsCollision", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x927FD94 — hookable via Hooks.InstallAt(NativeFunc_ForceRecreatePhysicsState).</summary>
        public static System.IntPtr NativeFunc_ForceRecreatePhysicsState => Memory.ModuleBase() + 0x927FD94;
        public void ForceRecreatePhysicsState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ForceRecreatePhysicsState", __pb.Bytes);
        }
    }

}
