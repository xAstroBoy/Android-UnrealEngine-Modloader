// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/Foliage
using System;

namespace UEModLoader.Game
{
    public enum EFoliageScaling
    {
        Uniform = 0,
        Free = 1,
        LockXY = 2,
        LockXZ = 3,
        LockYZ = 4,
    }

    public enum EVertexColorMaskChannel
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Alpha = 3,
        MAX_None = 4,
    }

    public enum FoliageVertexColorMask
    {
        FOLIAGEVERTEXCOLORMASK_Disabled = 0,
        FOLIAGEVERTEXCOLORMASK_Red = 1,
        FOLIAGEVERTEXCOLORMASK_Green = 2,
        FOLIAGEVERTEXCOLORMASK_Blue = 3,
        FOLIAGEVERTEXCOLORMASK_Alpha = 4,
    }

    public enum ESimulationQuery
    {
        None = 0,
        CollisionOverlap = 1,
        ShadeOverlap = 2,
        AnyOverlap = 3,
    }

    public enum ESimulationOverlap
    {
        CollisionOverlap = 0,
        ShadeOverlap = 1,
        None = 2,
    }

    public class FoliageVertexColorChannelMask : StructProxy
    {
        public FoliageVertexColorChannelMask(System.IntPtr ptr) : base(ptr) {}
        public bool UseMask { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public float MaskThreshold { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public bool InvertMask { get => (GetAt<byte>(0x8) & 0x1) != 0; set { var __b = GetAt<byte>(0x8); SetAt(0x8, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class FoliageTypeObject : StructProxy
    {
        public FoliageTypeObject(System.IntPtr ptr) : base(ptr) {}
        public Object FoliageTypeObject_2 { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public FoliageType TypeInstance { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new FoliageType(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bIsAsset { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public FoliageType_InstancedStaticMesh Type { get { var __p = GetAt<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new FoliageType_InstancedStaticMesh(__p); } set => SetAt(0x18, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class ProceduralFoliageInstance : StructProxy
    {
        public ProceduralFoliageInstance(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x0));
        public Quat Rotation => new Quat(AddrOf(0x10));
        public Vector Normal => new Vector(AddrOf(0x20));
        public float Age { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float Scale { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public FoliageType Type { get { var __p = GetAt<System.IntPtr>(0x38); return __p==System.IntPtr.Zero?null:new FoliageType(__p); } set => SetAt(0x38, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class FoliageInstancedStaticMeshComponent : HierarchicalInstancedStaticMeshComponent
    {
        public const string UeClassName = "FoliageInstancedStaticMeshComponent";
        public FoliageInstancedStaticMeshComponent(System.IntPtr ptr) : base(ptr) {}
        public static new FoliageInstancedStaticMeshComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FoliageInstancedStaticMeshComponent(p);
        public static FoliageInstancedStaticMeshComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FoliageInstancedStaticMeshComponent(o.Pointer); }
        public static FoliageInstancedStaticMeshComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FoliageInstancedStaticMeshComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FoliageInstancedStaticMeshComponent(a[i].Pointer); return r; }
        public System.IntPtr OnInstanceTakePointDamage => AddrOf(0x638); // 
        public System.IntPtr OnInstanceTakeRadialDamage => AddrOf(0x648); // 
        public Guid GenerationGuid => new Guid(AddrOf(0x658));
    }

    public class FoliageStatistics : BlueprintFunctionLibrary
    {
        public const string UeClassName = "FoliageStatistics";
        public FoliageStatistics(System.IntPtr ptr) : base(ptr) {}
        public static new FoliageStatistics FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FoliageStatistics(p);
        public static FoliageStatistics FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FoliageStatistics(o.Pointer); }
        public static FoliageStatistics[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FoliageStatistics[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FoliageStatistics(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7A61EF4 — hookable via Hooks.InstallAt(NativeFunc_FoliageOverlappingSphereCount).</summary>
        public static System.IntPtr NativeFunc_FoliageOverlappingSphereCount => Memory.ModuleBase() + 0x7A61EF4;
        public int FoliageOverlappingSphereCount(Object WorldContextObject, StaticMesh StaticMesh, Vector CenterPosition, float Radius)
        {
            var __pb = new ParamBuffer(36);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, StaticMesh);
            __pb.Set<System.IntPtr>(0x10, CenterPosition);
            __pb.Set(0x1C, Radius);
            CallRaw("FoliageOverlappingSphereCount", __pb.Bytes);
            return __pb.Get<int>(0x20);
        }
        /// <summary>[Native] thunk RVA 0x7A61DC4 — hookable via Hooks.InstallAt(NativeFunc_FoliageOverlappingBoxCount).</summary>
        public static System.IntPtr NativeFunc_FoliageOverlappingBoxCount => Memory.ModuleBase() + 0x7A61DC4;
        public int FoliageOverlappingBoxCount(Object WorldContextObject, StaticMesh StaticMesh, Box Box)
        {
            var __pb = new ParamBuffer(48);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, StaticMesh);
            __pb.Set<System.IntPtr>(0x10, Box);
            CallRaw("FoliageOverlappingBoxCount", __pb.Bytes);
            return __pb.Get<int>(0x2C);
        }
    }

    public class FoliageType : Object
    {
        public const string UeClassName = "FoliageType";
        public FoliageType(System.IntPtr ptr) : base(ptr) {}
        public static new FoliageType FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FoliageType(p);
        public static FoliageType FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FoliageType(o.Pointer); }
        public static FoliageType[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FoliageType[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FoliageType(a[i].Pointer); return r; }
        public Guid UpdateGuid => new Guid(AddrOf(0x28));
        public float Density { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public float DensityAdjustmentFactor { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public float Radius { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public bool bSingleInstanceModeOverrideRadius { get => Native.GetPropBool(Pointer, "bSingleInstanceModeOverrideRadius"); set => Native.SetPropBool(Pointer, "bSingleInstanceModeOverrideRadius", value); }
        public float SingleInstanceModeRadius { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public EFoliageScaling Scaling { get => (EFoliageScaling)GetAt<byte>(0x4C); set => SetAt(0x4C, (byte)value); }
        public FloatInterval ScaleX => new FloatInterval(AddrOf(0x50));
        public FloatInterval ScaleY => new FloatInterval(AddrOf(0x58));
        public FloatInterval ScaleZ => new FloatInterval(AddrOf(0x60));
        public System.IntPtr VertexColorMaskByChannel => AddrOf(0x68); // [4] static array
        public byte VertexColorMask { get => GetAt<byte>(0x98); set => SetAt(0x98, value); }
        public float VertexColorMaskThreshold { get => GetAt<float>(0x9C); set => SetAt(0x9C, value); }
        public bool VertexColorMaskInvert { get => Native.GetPropBool(Pointer, "VertexColorMaskInvert"); set => Native.SetPropBool(Pointer, "VertexColorMaskInvert", value); }
        public FloatInterval ZOffset => new FloatInterval(AddrOf(0xA4));
        public bool AlignToNormal { get => Native.GetPropBool(Pointer, "AlignToNormal"); set => Native.SetPropBool(Pointer, "AlignToNormal", value); }
        public float AlignMaxAngle { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public bool RandomYaw { get => Native.GetPropBool(Pointer, "RandomYaw"); set => Native.SetPropBool(Pointer, "RandomYaw", value); }
        public float RandomPitchAngle { get => GetAt<float>(0xB8); set => SetAt(0xB8, value); }
        public FloatInterval GroundSlopeAngle => new FloatInterval(AddrOf(0xBC));
        public FloatInterval Height => new FloatInterval(AddrOf(0xC4));
        public TArray<System.IntPtr> LandscapeLayers => new TArray<System.IntPtr>(AddrOf(0xD0)); // TArray<FName>
        public float MinimumLayerWeight { get => GetAt<float>(0xE0); set => SetAt(0xE0, value); }
        public TArray<System.IntPtr> ExclusionLandscapeLayers => new TArray<System.IntPtr>(AddrOf(0xE8)); // TArray<FName>
        public float MinimumExclusionLayerWeight { get => GetAt<float>(0xF8); set => SetAt(0xF8, value); }
        public string LandscapeLayer => Native.GetPropName(Pointer, "LandscapeLayer"); // FName
        public FName LandscapeLayer_Raw { get => GetAt<FName>(0xFC); set => SetAt(0xFC, value); }
        public bool CollisionWithWorld { get => Native.GetPropBool(Pointer, "CollisionWithWorld"); set => Native.SetPropBool(Pointer, "CollisionWithWorld", value); }
        public Vector CollisionScale => new Vector(AddrOf(0x108));
        public BoxSphereBounds MeshBounds => new BoxSphereBounds(AddrOf(0x114));
        public Vector LowBoundOriginRadius => new Vector(AddrOf(0x130));
        public byte Mobility { get => GetAt<byte>(0x13C); set => SetAt(0x13C, value); }
        public Int32Interval CullDistance => new Int32Interval(AddrOf(0x140));
        public bool bEnableStaticLighting { get => Native.GetPropBool(Pointer, "bEnableStaticLighting"); set => Native.SetPropBool(Pointer, "bEnableStaticLighting", value); }
        public bool CastShadow { get => Native.GetPropBool(Pointer, "CastShadow"); set => Native.SetPropBool(Pointer, "CastShadow", value); }
        public bool bAffectDynamicIndirectLighting { get => Native.GetPropBool(Pointer, "bAffectDynamicIndirectLighting"); set => Native.SetPropBool(Pointer, "bAffectDynamicIndirectLighting", value); }
        public bool bAffectDistanceFieldLighting { get => Native.GetPropBool(Pointer, "bAffectDistanceFieldLighting"); set => Native.SetPropBool(Pointer, "bAffectDistanceFieldLighting", value); }
        public bool bCastDynamicShadow { get => Native.GetPropBool(Pointer, "bCastDynamicShadow"); set => Native.SetPropBool(Pointer, "bCastDynamicShadow", value); }
        public bool bCastStaticShadow { get => Native.GetPropBool(Pointer, "bCastStaticShadow"); set => Native.SetPropBool(Pointer, "bCastStaticShadow", value); }
        public bool bCastShadowAsTwoSided { get => Native.GetPropBool(Pointer, "bCastShadowAsTwoSided"); set => Native.SetPropBool(Pointer, "bCastShadowAsTwoSided", value); }
        public bool bReceivesDecals { get => Native.GetPropBool(Pointer, "bReceivesDecals"); set => Native.SetPropBool(Pointer, "bReceivesDecals", value); }
        public bool bOverrideLightMapRes { get => Native.GetPropBool(Pointer, "bOverrideLightMapRes"); set => Native.SetPropBool(Pointer, "bOverrideLightMapRes", value); }
        public int OverriddenLightMapRes { get => GetAt<int>(0x14C); set => SetAt(0x14C, value); }
        public ELightmapType LightmapType { get => (ELightmapType)GetAt<byte>(0x150); set => SetAt(0x150, (byte)value); }
        public bool bUseAsOccluder { get => Native.GetPropBool(Pointer, "bUseAsOccluder"); set => Native.SetPropBool(Pointer, "bUseAsOccluder", value); }
        public BodyInstance BodyInstance => new BodyInstance(AddrOf(0x158));
        public byte CustomNavigableGeometry { get => GetAt<byte>(0x288); set => SetAt(0x288, value); }
        public LightingChannels LightingChannels => new LightingChannels(AddrOf(0x289));
        public bool bRenderCustomDepth { get => Native.GetPropBool(Pointer, "bRenderCustomDepth"); set => Native.SetPropBool(Pointer, "bRenderCustomDepth", value); }
        public int CustomDepthStencilValue { get => GetAt<int>(0x28C); set => SetAt(0x28C, value); }
        public int TranslucencySortPriority { get => GetAt<int>(0x290); set => SetAt(0x290, value); }
        public float CollisionRadius { get => GetAt<float>(0x294); set => SetAt(0x294, value); }
        public float ShadeRadius { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public int NumSteps { get => GetAt<int>(0x29C); set => SetAt(0x29C, value); }
        public float InitialSeedDensity { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public float AverageSpreadDistance { get => GetAt<float>(0x2A4); set => SetAt(0x2A4, value); }
        public float SpreadVariance { get => GetAt<float>(0x2A8); set => SetAt(0x2A8, value); }
        public int SeedsPerStep { get => GetAt<int>(0x2AC); set => SetAt(0x2AC, value); }
        public int DistributionSeed { get => GetAt<int>(0x2B0); set => SetAt(0x2B0, value); }
        public float MaxInitialSeedOffset { get => GetAt<float>(0x2B4); set => SetAt(0x2B4, value); }
        public bool bCanGrowInShade { get => Native.GetPropBool(Pointer, "bCanGrowInShade"); set => Native.SetPropBool(Pointer, "bCanGrowInShade", value); }
        public bool bSpawnsInShade { get => Native.GetPropBool(Pointer, "bSpawnsInShade"); set => Native.SetPropBool(Pointer, "bSpawnsInShade", value); }
        public float MaxInitialAge { get => GetAt<float>(0x2BC); set => SetAt(0x2BC, value); }
        public float maxAge { get => GetAt<float>(0x2C0); set => SetAt(0x2C0, value); }
        public float OverlapPriority { get => GetAt<float>(0x2C4); set => SetAt(0x2C4, value); }
        public FloatInterval ProceduralScale => new FloatInterval(AddrOf(0x2C8));
        public RuntimeFloatCurve ScaleCurve => new RuntimeFloatCurve(AddrOf(0x2D0));
        public int ChangeCount { get => GetAt<int>(0x358); set => SetAt(0x358, value); }
        public bool ReapplyDensity { get => Native.GetPropBool(Pointer, "ReapplyDensity"); set => Native.SetPropBool(Pointer, "ReapplyDensity", value); }
        public bool ReapplyRadius { get => Native.GetPropBool(Pointer, "ReapplyRadius"); set => Native.SetPropBool(Pointer, "ReapplyRadius", value); }
        public bool ReapplyAlignToNormal { get => Native.GetPropBool(Pointer, "ReapplyAlignToNormal"); set => Native.SetPropBool(Pointer, "ReapplyAlignToNormal", value); }
        public bool ReapplyRandomYaw { get => Native.GetPropBool(Pointer, "ReapplyRandomYaw"); set => Native.SetPropBool(Pointer, "ReapplyRandomYaw", value); }
        public bool ReapplyScaling { get => Native.GetPropBool(Pointer, "ReapplyScaling"); set => Native.SetPropBool(Pointer, "ReapplyScaling", value); }
        public bool ReapplyScaleX { get => Native.GetPropBool(Pointer, "ReapplyScaleX"); set => Native.SetPropBool(Pointer, "ReapplyScaleX", value); }
        public bool ReapplyScaleY { get => Native.GetPropBool(Pointer, "ReapplyScaleY"); set => Native.SetPropBool(Pointer, "ReapplyScaleY", value); }
        public bool ReapplyScaleZ { get => Native.GetPropBool(Pointer, "ReapplyScaleZ"); set => Native.SetPropBool(Pointer, "ReapplyScaleZ", value); }
        public bool ReapplyRandomPitchAngle { get => Native.GetPropBool(Pointer, "ReapplyRandomPitchAngle"); set => Native.SetPropBool(Pointer, "ReapplyRandomPitchAngle", value); }
        public bool ReapplyGroundSlope { get => Native.GetPropBool(Pointer, "ReapplyGroundSlope"); set => Native.SetPropBool(Pointer, "ReapplyGroundSlope", value); }
        public bool ReapplyHeight { get => Native.GetPropBool(Pointer, "ReapplyHeight"); set => Native.SetPropBool(Pointer, "ReapplyHeight", value); }
        public bool ReapplyLandscapeLayers { get => Native.GetPropBool(Pointer, "ReapplyLandscapeLayers"); set => Native.SetPropBool(Pointer, "ReapplyLandscapeLayers", value); }
        public bool ReapplyZOffset { get => Native.GetPropBool(Pointer, "ReapplyZOffset"); set => Native.SetPropBool(Pointer, "ReapplyZOffset", value); }
        public bool ReapplyCollisionWithWorld { get => Native.GetPropBool(Pointer, "ReapplyCollisionWithWorld"); set => Native.SetPropBool(Pointer, "ReapplyCollisionWithWorld", value); }
        public bool ReapplyVertexColorMask { get => Native.GetPropBool(Pointer, "ReapplyVertexColorMask"); set => Native.SetPropBool(Pointer, "ReapplyVertexColorMask", value); }
        public bool bEnableDensityScaling { get => Native.GetPropBool(Pointer, "bEnableDensityScaling"); set => Native.SetPropBool(Pointer, "bEnableDensityScaling", value); }
        public TArray<System.IntPtr> RuntimeVirtualTextures => new TArray<System.IntPtr>(AddrOf(0x360)); // TArray<UObject*>
        public int VirtualTextureCullMips { get => GetAt<int>(0x370); set => SetAt(0x370, value); }
        public ERuntimeVirtualTextureMainPassType VirtualTextureRenderPassType { get => (ERuntimeVirtualTextureMainPassType)GetAt<byte>(0x374); set => SetAt(0x374, (byte)value); }
    }

    public class FoliageType_Actor : FoliageType
    {
        public const string UeClassName = "FoliageType_Actor";
        public FoliageType_Actor(System.IntPtr ptr) : base(ptr) {}
        public static new FoliageType_Actor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FoliageType_Actor(p);
        public static FoliageType_Actor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FoliageType_Actor(o.Pointer); }
        public static FoliageType_Actor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FoliageType_Actor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FoliageType_Actor(a[i].Pointer); return r; }
        public Actor ActorClass { get { var __p = GetAt<System.IntPtr>(0x378); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x378, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bShouldAttachToBaseComponent { get => Native.GetPropBool(Pointer, "bShouldAttachToBaseComponent"); set => Native.SetPropBool(Pointer, "bShouldAttachToBaseComponent", value); }
    }

    public class FoliageType_InstancedStaticMesh : FoliageType
    {
        public const string UeClassName = "FoliageType_InstancedStaticMesh";
        public FoliageType_InstancedStaticMesh(System.IntPtr ptr) : base(ptr) {}
        public static new FoliageType_InstancedStaticMesh FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FoliageType_InstancedStaticMesh(p);
        public static FoliageType_InstancedStaticMesh FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FoliageType_InstancedStaticMesh(o.Pointer); }
        public static FoliageType_InstancedStaticMesh[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FoliageType_InstancedStaticMesh[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FoliageType_InstancedStaticMesh(a[i].Pointer); return r; }
        public StaticMesh Mesh { get { var __p = GetAt<System.IntPtr>(0x378); return __p==System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x378, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> OverrideMaterials => new TArray<System.IntPtr>(AddrOf(0x380)); // TArray<UObject*>
        public FoliageInstancedStaticMeshComponent ComponentClass { get { var __p = GetAt<System.IntPtr>(0x390); return __p==System.IntPtr.Zero?null:new FoliageInstancedStaticMeshComponent(__p); } set => SetAt(0x390, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class InstancedFoliageActor : Actor
    {
        public const string UeClassName = "InstancedFoliageActor";
        public InstancedFoliageActor(System.IntPtr ptr) : base(ptr) {}
        public static new InstancedFoliageActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InstancedFoliageActor(p);
        public static InstancedFoliageActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InstancedFoliageActor(o.Pointer); }
        public static InstancedFoliageActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InstancedFoliageActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InstancedFoliageActor(a[i].Pointer); return r; }
    }

    public class InteractiveFoliageActor : StaticMeshActor
    {
        public const string UeClassName = "InteractiveFoliageActor";
        public InteractiveFoliageActor(System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveFoliageActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InteractiveFoliageActor(p);
        public static InteractiveFoliageActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveFoliageActor(o.Pointer); }
        public static InteractiveFoliageActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveFoliageActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveFoliageActor(a[i].Pointer); return r; }
        public CapsuleComponent CapsuleComponent { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new CapsuleComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector TouchingActorEntryPosition => new Vector(AddrOf(0x238));
        public Vector FoliageVelocity => new Vector(AddrOf(0x244));
        public Vector FoliageForce => new Vector(AddrOf(0x250));
        public Vector FoliagePosition => new Vector(AddrOf(0x25C));
        public float FoliageDamageImpulseScale { get => GetAt<float>(0x268); set => SetAt(0x268, value); }
        public float FoliageTouchImpulseScale { get => GetAt<float>(0x26C); set => SetAt(0x26C, value); }
        public float FoliageStiffness { get => GetAt<float>(0x270); set => SetAt(0x270, value); }
        public float FoliageStiffnessQuadratic { get => GetAt<float>(0x274); set => SetAt(0x274, value); }
        public float FoliageDamping { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public float MaxDamageImpulse { get => GetAt<float>(0x27C); set => SetAt(0x27C, value); }
        public float MaxTouchImpulse { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public float MaxForce { get => GetAt<float>(0x284); set => SetAt(0x284, value); }
        public float Mass { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        /// <summary>[Native] thunk RVA 0x7A656F8 — hookable via Hooks.InstallAt(NativeFunc_CapsuleTouched).</summary>
        public static System.IntPtr NativeFunc_CapsuleTouched => Memory.ModuleBase() + 0x7A656F8;
        public void CapsuleTouched(PrimitiveComponent OverlappedComp, Actor Other, PrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, HitResult OverlapInfo)
        {
            var __pb = new ParamBuffer(168);
            __pb.SetObject(0x0, OverlappedComp);
            __pb.SetObject(0x8, Other);
            __pb.SetObject(0x10, OtherComp);
            __pb.Set(0x18, OtherBodyIndex);
            __pb.Set<byte>(0x1C, (byte)(bFromSweep?1:0));
            __pb.Set<System.IntPtr>(0x20, OverlapInfo);
            CallRaw("CapsuleTouched", __pb.Bytes);
        }
    }

    public class InteractiveFoliageComponent : StaticMeshComponent
    {
        public const string UeClassName = "InteractiveFoliageComponent";
        public InteractiveFoliageComponent(System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveFoliageComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InteractiveFoliageComponent(p);
        public static InteractiveFoliageComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveFoliageComponent(o.Pointer); }
        public static InteractiveFoliageComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveFoliageComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveFoliageComponent(a[i].Pointer); return r; }
    }

    public class ProceduralFoliageBlockingVolume : Volume
    {
        public const string UeClassName = "ProceduralFoliageBlockingVolume";
        public ProceduralFoliageBlockingVolume(System.IntPtr ptr) : base(ptr) {}
        public static new ProceduralFoliageBlockingVolume FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ProceduralFoliageBlockingVolume(p);
        public static ProceduralFoliageBlockingVolume FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ProceduralFoliageBlockingVolume(o.Pointer); }
        public static ProceduralFoliageBlockingVolume[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ProceduralFoliageBlockingVolume[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ProceduralFoliageBlockingVolume(a[i].Pointer); return r; }
        public ProceduralFoliageVolume ProceduralFoliageVolume { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new ProceduralFoliageVolume(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class ProceduralFoliageComponent : ActorComponent
    {
        public const string UeClassName = "ProceduralFoliageComponent";
        public ProceduralFoliageComponent(System.IntPtr ptr) : base(ptr) {}
        public static new ProceduralFoliageComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ProceduralFoliageComponent(p);
        public static ProceduralFoliageComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ProceduralFoliageComponent(o.Pointer); }
        public static ProceduralFoliageComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ProceduralFoliageComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ProceduralFoliageComponent(a[i].Pointer); return r; }
        public ProceduralFoliageSpawner FoliageSpawner { get { var __p = GetAt<System.IntPtr>(0xB0); return __p==System.IntPtr.Zero?null:new ProceduralFoliageSpawner(__p); } set => SetAt(0xB0, value?.Pointer ?? System.IntPtr.Zero); }
        public float TileOverlap { get => GetAt<float>(0xB8); set => SetAt(0xB8, value); }
        public Volume SpawningVolume { get { var __p = GetAt<System.IntPtr>(0xC0); return __p==System.IntPtr.Zero?null:new Volume(__p); } set => SetAt(0xC0, value?.Pointer ?? System.IntPtr.Zero); }
        public Guid ProceduralGuid => new Guid(AddrOf(0xC8));
    }

    public class ProceduralFoliageSpawner : Object
    {
        public const string UeClassName = "ProceduralFoliageSpawner";
        public ProceduralFoliageSpawner(System.IntPtr ptr) : base(ptr) {}
        public static new ProceduralFoliageSpawner FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ProceduralFoliageSpawner(p);
        public static ProceduralFoliageSpawner FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ProceduralFoliageSpawner(o.Pointer); }
        public static ProceduralFoliageSpawner[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ProceduralFoliageSpawner[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ProceduralFoliageSpawner(a[i].Pointer); return r; }
        public int RandomSeed { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public float TileSize { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public int NumUniqueTiles { get => GetAt<int>(0x30); set => SetAt(0x30, value); }
        public float MinimumQuadTreeSize { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public TArray<System.IntPtr> FoliageTypes => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<struct>
        /// <summary>[Native] thunk RVA 0x7A67F7C — hookable via Hooks.InstallAt(NativeFunc_Simulate).</summary>
        public static System.IntPtr NativeFunc_Simulate => Memory.ModuleBase() + 0x7A67F7C;
        public void Simulate(int NumSteps)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumSteps);
            CallRaw("Simulate", __pb.Bytes);
        }
    }

    public class ProceduralFoliageTile : Object
    {
        public const string UeClassName = "ProceduralFoliageTile";
        public ProceduralFoliageTile(System.IntPtr ptr) : base(ptr) {}
        public static new ProceduralFoliageTile FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ProceduralFoliageTile(p);
        public static ProceduralFoliageTile FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ProceduralFoliageTile(o.Pointer); }
        public static ProceduralFoliageTile[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ProceduralFoliageTile[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ProceduralFoliageTile(a[i].Pointer); return r; }
        public ProceduralFoliageSpawner FoliageSpawner { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new ProceduralFoliageSpawner(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> InstancesArray => new TArray<System.IntPtr>(AddrOf(0xD0)); // TArray<struct>
    }

    public class ProceduralFoliageVolume : Volume
    {
        public const string UeClassName = "ProceduralFoliageVolume";
        public ProceduralFoliageVolume(System.IntPtr ptr) : base(ptr) {}
        public static new ProceduralFoliageVolume FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ProceduralFoliageVolume(p);
        public static ProceduralFoliageVolume FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ProceduralFoliageVolume(o.Pointer); }
        public static ProceduralFoliageVolume[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ProceduralFoliageVolume[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ProceduralFoliageVolume(a[i].Pointer); return r; }
        public ProceduralFoliageComponent ProceduralComponent { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new ProceduralFoliageComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
    }

}
