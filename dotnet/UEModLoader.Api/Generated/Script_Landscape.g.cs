// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/Landscape
using System;

namespace UEModLoader.Game
{
    public enum ELandscapeBlendMode
    {
        LSBM_AdditiveBlend = 0,
        LSBM_AlphaBlend = 1,
    }

    public enum ELandscapeSetupErrors
    {
        LSE_None = 0,
        LSE_NoLandscapeInfo = 1,
        LSE_CollsionXY = 2,
        LSE_NoLayerInfo = 3,
    }

    public enum ELandscapeClearMode
    {
        Clear_Weightmap = 1,
        Clear_Heightmap = 2,
        Clear_All = 3,
    }

    public enum ELandscapeGizmoType
    {
        LGT_None = 0,
        LGT_Height = 1,
        LGT_Weight = 2,
    }

    public enum EGrassScaling
    {
        Uniform = 0,
        Free = 1,
        LockXY = 2,
    }

    public enum ESplineModulationColorMask
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Alpha = 3,
    }

    public enum ELandscapeLODFalloff
    {
        Linear = 0,
        SquareRoot = 1,
    }

    public enum ELandscapeLayerDisplayMode
    {
        Default = 0,
        Alphabetical = 1,
        UserSpecific = 2,
    }

    public enum ELandscapeLayerPaintingRestriction
    {
        None = 0,
        UseMaxLayers = 1,
        ExistingOnly = 2,
        UseComponentWhitelist = 3,
    }

    public enum ELandscapeImportAlphamapType
    {
        Additive = 0,
        Layered = 1,
    }

    public enum LandscapeSplineMeshOrientation
    {
        LSMO_XUp = 0,
        LSMO_YUp = 1,
    }

    public enum ELandscapeLayerBlendType
    {
        LB_WeightBlend = 0,
        LB_AlphaBlend = 1,
        LB_HeightBlend = 2,
    }

    public enum ELandscapeCustomizedCoordType
    {
        LCCT_None = 0,
        LCCT_CustomUV0 = 1,
        LCCT_CustomUV1 = 2,
        LCCT_CustomUV2 = 3,
        LCCT_WeightMapUV = 4,
    }

    public enum ETerrainCoordMappingType
    {
        TCMT_Auto = 0,
        TCMT_XY = 1,
        TCMT_XZ = 2,
        TCMT_YZ = 3,
    }

    public class LandscapeLayer : StructProxy
    {
        public LandscapeLayer(System.IntPtr ptr) : base(ptr) {}
        public Guid Guid => new Guid(AddrOf(0x0));
        public string Name => Native.FNameToString(GetAt<int>(0x10)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x10); set => SetAt(0x10, value); }
        public bool bVisible { get => (GetAt<byte>(0x18) & 0xFF) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bLocked { get => (GetAt<byte>(0x19) & 0xFF) != 0; set { var __b = GetAt<byte>(0x19); SetAt(0x19, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float HeightmapAlpha { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public float WeightmapAlpha { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public byte BlendMode { get => GetAt<byte>(0x24); set => SetAt(0x24, value); }
        public TArray<System.IntPtr> Brushes => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public System.IntPtr WeightmapLayerAllocationBlend => AddrOf(0x38); // 
    }

    public class LandscapeLayerBrush : StructProxy
    {
        public LandscapeLayerBrush(System.IntPtr ptr) : base(ptr) {}
    }

    public class LandscapeLayerComponentData : StructProxy
    {
        public LandscapeLayerComponentData(System.IntPtr ptr) : base(ptr) {}
        public HeightmapData HeightmapData => new HeightmapData(AddrOf(0x0));
        public WeightmapData WeightmapData => new WeightmapData(AddrOf(0x8));
    }

    public class WeightmapData : StructProxy
    {
        public WeightmapData(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Textures => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<UObject*>
        public TArray<System.IntPtr> LayerAllocations => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<System.IntPtr> TextureUsages => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<UObject*>
    }

    public class WeightmapLayerAllocationInfo : StructProxy
    {
        public WeightmapLayerAllocationInfo(System.IntPtr ptr) : base(ptr) {}
        public LandscapeLayerInfoObject LayerInfo { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new LandscapeLayerInfoObject(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public byte WeightmapTextureIndex { get => GetAt<byte>(0x8); set => SetAt(0x8, value); }
        public byte WeightmapTextureChannel { get => GetAt<byte>(0x9); set => SetAt(0x9, value); }
    }

    public class HeightmapData : StructProxy
    {
        public HeightmapData(System.IntPtr ptr) : base(ptr) {}
        public Texture2D Texture { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class LandscapeComponentMaterialOverride : StructProxy
    {
        public LandscapeComponentMaterialOverride(System.IntPtr ptr) : base(ptr) {}
        public PerPlatformInt LODIndex => new PerPlatformInt(AddrOf(0x0));
        public MaterialInterface Material { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class LandscapeEditToolRenderData : StructProxy
    {
        public LandscapeEditToolRenderData(System.IntPtr ptr) : base(ptr) {}
        public MaterialInterface ToolMaterial { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface GizmoMaterial { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
        public int SelectedType { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
        public int DebugChannelR { get => GetAt<int>(0x14); set => SetAt(0x14, value); }
        public int DebugChannelG { get => GetAt<int>(0x18); set => SetAt(0x18, value); }
        public int DebugChannelB { get => GetAt<int>(0x1C); set => SetAt(0x1C, value); }
        public Texture2D DataTexture { get { var __p = GetAt<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x20, value?.Pointer ?? System.IntPtr.Zero); }
        public Texture2D LayerContributionTexture { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public Texture2D DirtyTexture { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class GizmoSelectData : StructProxy
    {
        public GizmoSelectData(System.IntPtr ptr) : base(ptr) {}
    }

    public class GrassVariety : StructProxy
    {
        public GrassVariety(System.IntPtr ptr) : base(ptr) {}
        public StaticMesh GrassMesh { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public PerPlatformFloat GrassDensity => new PerPlatformFloat(AddrOf(0x8));
        public bool bUseGrid { get => (GetAt<byte>(0xC) & 0xFF) != 0; set { var __b = GetAt<byte>(0xC); SetAt(0xC, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float PlacementJitter { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public PerPlatformInt StartCullDistance => new PerPlatformInt(AddrOf(0x14));
        public PerPlatformInt EndCullDistance => new PerPlatformInt(AddrOf(0x18));
        public int MinLOD { get => GetAt<int>(0x1C); set => SetAt(0x1C, value); }
        public EGrassScaling Scaling { get => (EGrassScaling)GetAt<byte>(0x20); set => SetAt(0x20, (byte)value); }
        public FloatInterval ScaleX => new FloatInterval(AddrOf(0x24));
        public FloatInterval ScaleY => new FloatInterval(AddrOf(0x2C));
        public FloatInterval ScaleZ => new FloatInterval(AddrOf(0x34));
        public bool RandomRotation { get => (GetAt<byte>(0x3C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool AlignToSurface { get => (GetAt<byte>(0x3D) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3D); SetAt(0x3D, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bUseLandscapeLightmap { get => (GetAt<byte>(0x3E) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3E); SetAt(0x3E, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public LightingChannels LightingChannels => new LightingChannels(AddrOf(0x3F));
        public bool bReceivesDecals { get => (GetAt<byte>(0x40) & 0xFF) != 0; set { var __b = GetAt<byte>(0x40); SetAt(0x40, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bCastDynamicShadow { get => (GetAt<byte>(0x41) & 0xFF) != 0; set { var __b = GetAt<byte>(0x41); SetAt(0x41, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bKeepInstanceBufferCPUCopy { get => (GetAt<byte>(0x42) & 0xFF) != 0; set { var __b = GetAt<byte>(0x42); SetAt(0x42, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class LandscapeInfoLayerSettings : StructProxy
    {
        public LandscapeInfoLayerSettings(System.IntPtr ptr) : base(ptr) {}
        public LandscapeLayerInfoObject LayerInfoObj { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new LandscapeLayerInfoObject(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public string LayerName => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName LayerName_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
    }

    public class LandscapeMaterialTextureStreamingInfo : StructProxy
    {
        public LandscapeMaterialTextureStreamingInfo(System.IntPtr ptr) : base(ptr) {}
        public string TextureName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName TextureName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public float TexelFactor { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class LandscapeProxyMaterialOverride : StructProxy
    {
        public LandscapeProxyMaterialOverride(System.IntPtr ptr) : base(ptr) {}
        public PerPlatformInt LODIndex => new PerPlatformInt(AddrOf(0x0));
        public MaterialInterface Material { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class LandscapeImportLayerInfo : StructProxy
    {
        public LandscapeImportLayerInfo(System.IntPtr ptr) : base(ptr) {}
    }

    public class LandscapeLayerStruct : StructProxy
    {
        public LandscapeLayerStruct(System.IntPtr ptr) : base(ptr) {}
        public LandscapeLayerInfoObject LayerInfoObj { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new LandscapeLayerInfoObject(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class LandscapeEditorLayerSettings : StructProxy
    {
        public LandscapeEditorLayerSettings(System.IntPtr ptr) : base(ptr) {}
    }

    public class LandscapeSplineConnection : StructProxy
    {
        public LandscapeSplineConnection(System.IntPtr ptr) : base(ptr) {}
        public LandscapeSplineSegment Segment { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new LandscapeSplineSegment(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool End { get => (GetAt<byte>(0x8) & 0x1) != 0; set { var __b = GetAt<byte>(0x8); SetAt(0x8, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class ForeignWorldSplineData : StructProxy
    {
        public ForeignWorldSplineData(System.IntPtr ptr) : base(ptr) {}
    }

    public class ForeignSplineSegmentData : StructProxy
    {
        public ForeignSplineSegmentData(System.IntPtr ptr) : base(ptr) {}
    }

    public class ForeignControlPointData : StructProxy
    {
        public ForeignControlPointData(System.IntPtr ptr) : base(ptr) {}
    }

    public class LandscapeSplineMeshEntry : StructProxy
    {
        public LandscapeSplineMeshEntry(System.IntPtr ptr) : base(ptr) {}
        public StaticMesh Mesh { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> MaterialOverrides => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<UObject*>
        public bool bCenterH { get => (GetAt<byte>(0x18) & 0x1) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public Vector2D CenterAdjust => new Vector2D(AddrOf(0x1C));
        public bool bScaleToWidth { get => (GetAt<byte>(0x24) & 0x1) != 0; set { var __b = GetAt<byte>(0x24); SetAt(0x24, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public Vector Scale => new Vector(AddrOf(0x28));
        public byte Orientation { get => GetAt<byte>(0x34); set => SetAt(0x34, value); }
        public byte ForwardAxis { get => GetAt<byte>(0x35); set => SetAt(0x35, value); }
        public byte UpAxis { get => GetAt<byte>(0x36); set => SetAt(0x36, value); }
    }

    public class LandscapeSplineSegmentConnection : StructProxy
    {
        public LandscapeSplineSegmentConnection(System.IntPtr ptr) : base(ptr) {}
        public LandscapeSplineControlPoint ControlPoint { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new LandscapeSplineControlPoint(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public float TangentLen { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public string SocketName => Native.FNameToString(GetAt<int>(0xC)); // FName
        public FName SocketName_Raw { get => GetAt<FName>(0xC); set => SetAt(0xC, value); }
    }

    public class LandscapeSplineInterpPoint : StructProxy
    {
        public LandscapeSplineInterpPoint(System.IntPtr ptr) : base(ptr) {}
        public Vector Center => new Vector(AddrOf(0x0));
        public Vector Left => new Vector(AddrOf(0xC));
        public Vector Right => new Vector(AddrOf(0x18));
        public Vector FalloffLeft => new Vector(AddrOf(0x24));
        public Vector FalloffRight => new Vector(AddrOf(0x30));
        public Vector LayerLeft => new Vector(AddrOf(0x3C));
        public Vector LayerRight => new Vector(AddrOf(0x48));
        public Vector LayerFalloffLeft => new Vector(AddrOf(0x54));
        public Vector LayerFalloffRight => new Vector(AddrOf(0x60));
        public float StartEndFalloff { get => GetAt<float>(0x6C); set => SetAt(0x6C, value); }
    }

    public class GrassInput : StructProxy
    {
        public GrassInput(System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public LandscapeGrassType GrassType { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new LandscapeGrassType(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
        public ExpressionInput Input => new ExpressionInput(AddrOf(0x10));
    }

    public class LayerBlendInput : StructProxy
    {
        public LayerBlendInput(System.IntPtr ptr) : base(ptr) {}
        public string LayerName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName LayerName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public byte BlendType { get => GetAt<byte>(0x8); set => SetAt(0x8, value); }
        public ExpressionInput LayerInput => new ExpressionInput(AddrOf(0xC));
        public ExpressionInput HeightInput => new ExpressionInput(AddrOf(0x20));
        public float PreviewWeight { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public Vector ConstLayerInput => new Vector(AddrOf(0x38));
        public float ConstHeightInput { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
    }

    public class ControlPointMeshActor : Actor
    {
        public const string UeClassName = "ControlPointMeshActor";
        public ControlPointMeshActor(System.IntPtr ptr) : base(ptr) {}
        public static new ControlPointMeshActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ControlPointMeshActor(p);
        public static ControlPointMeshActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ControlPointMeshActor(o.Pointer); }
        public static ControlPointMeshActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ControlPointMeshActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ControlPointMeshActor(a[i].Pointer); return r; }
        public ControlPointMeshComponent ControlPointMeshComponent { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new ControlPointMeshComponent(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class ControlPointMeshComponent : StaticMeshComponent
    {
        public const string UeClassName = "ControlPointMeshComponent";
        public ControlPointMeshComponent(System.IntPtr ptr) : base(ptr) {}
        public static new ControlPointMeshComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ControlPointMeshComponent(p);
        public static ControlPointMeshComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ControlPointMeshComponent(o.Pointer); }
        public static ControlPointMeshComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ControlPointMeshComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ControlPointMeshComponent(a[i].Pointer); return r; }
        public float VirtualTextureMainPassMaxDrawDistance { get => GetAt<float>(0x49C); set => SetAt(0x49C, value); }
    }

    public class LandscapeProxy : Actor
    {
        public const string UeClassName = "LandscapeProxy";
        public LandscapeProxy(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeProxy(p);
        public static LandscapeProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeProxy(o.Pointer); }
        public static LandscapeProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeProxy(a[i].Pointer); return r; }
        public LandscapeSplinesComponent SplineComponent { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new LandscapeSplinesComponent(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
        public Guid LandscapeGuid => new Guid(AddrOf(0x228));
        public IntPoint LandscapeSectionOffset => new IntPoint(AddrOf(0x238));
        public int MaxLODLevel { get => GetAt<int>(0x240); set => SetAt(0x240, value); }
        public float LODDistanceFactor { get => GetAt<float>(0x244); set => SetAt(0x244, value); }
        public byte LODFalloff { get => GetAt<byte>(0x248); set => SetAt(0x248, value); }
        public float ComponentScreenSizeToUseSubSections { get => GetAt<float>(0x24C); set => SetAt(0x24C, value); }
        public float LOD0ScreenSize { get => GetAt<float>(0x250); set => SetAt(0x250, value); }
        public float LOD0DistributionSetting { get => GetAt<float>(0x254); set => SetAt(0x254, value); }
        public float LODDistributionSetting { get => GetAt<float>(0x258); set => SetAt(0x258, value); }
        public float TessellationComponentScreenSize { get => GetAt<float>(0x25C); set => SetAt(0x25C, value); }
        public bool UseTessellationComponentScreenSizeFalloff { get => Native.GetPropBool(Pointer, "UseTessellationComponentScreenSizeFalloff"); set => Native.SetPropBool(Pointer, "UseTessellationComponentScreenSizeFalloff", value); }
        public float TessellationComponentScreenSizeFalloff { get => GetAt<float>(0x264); set => SetAt(0x264, value); }
        public int OccluderGeometryLOD { get => GetAt<int>(0x268); set => SetAt(0x268, value); }
        public int StaticLightingLOD { get => GetAt<int>(0x26C); set => SetAt(0x26C, value); }
        public PhysicalMaterial DefaultPhysMaterial { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new PhysicalMaterial(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public float StreamingDistanceMultiplier { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public MaterialInterface LandscapeMaterial { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface LandscapeHoleMaterial { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> LandscapeMaterialsOverride => new TArray<System.IntPtr>(AddrOf(0x2B0)); // TArray<struct>
        public bool bMeshHoles { get => Native.GetPropBool(Pointer, "bMeshHoles"); set => Native.SetPropBool(Pointer, "bMeshHoles", value); }
        public byte MeshHolesMaxLod { get => GetAt<byte>(0x2C1); set => SetAt(0x2C1, value); }
        public TArray<System.IntPtr> RuntimeVirtualTextures => new TArray<System.IntPtr>(AddrOf(0x2C8)); // TArray<UObject*>
        public int VirtualTextureNumLods { get => GetAt<int>(0x2D8); set => SetAt(0x2D8, value); }
        public int VirtualTextureLodBias { get => GetAt<int>(0x2DC); set => SetAt(0x2DC, value); }
        public ERuntimeVirtualTextureMainPassType VirtualTextureRenderPassType { get => (ERuntimeVirtualTextureMainPassType)GetAt<byte>(0x2E0); set => SetAt(0x2E0, (byte)value); }
        public float NegativeZBoundsExtension { get => GetAt<float>(0x2E4); set => SetAt(0x2E4, value); }
        public float PositiveZBoundsExtension { get => GetAt<float>(0x2E8); set => SetAt(0x2E8, value); }
        public TArray<System.IntPtr> LandscapeComponents => new TArray<System.IntPtr>(AddrOf(0x2F0)); // TArray<UObject*>
        public TArray<System.IntPtr> CollisionComponents => new TArray<System.IntPtr>(AddrOf(0x300)); // TArray<UObject*>
        public TArray<System.IntPtr> FoliageComponents => new TArray<System.IntPtr>(AddrOf(0x310)); // TArray<UObject*>
        public bool bHasLandscapeGrass { get => Native.GetPropBool(Pointer, "bHasLandscapeGrass"); set => Native.SetPropBool(Pointer, "bHasLandscapeGrass", value); }
        public float StaticLightingResolution { get => GetAt<float>(0x388); set => SetAt(0x388, value); }
        public bool bCastStaticShadow { get => Native.GetPropBool(Pointer, "bCastStaticShadow"); set => Native.SetPropBool(Pointer, "bCastStaticShadow", value); }
        public bool bCastShadowAsTwoSided { get => Native.GetPropBool(Pointer, "bCastShadowAsTwoSided"); set => Native.SetPropBool(Pointer, "bCastShadowAsTwoSided", value); }
        public bool bCastFarShadow { get => Native.GetPropBool(Pointer, "bCastFarShadow"); set => Native.SetPropBool(Pointer, "bCastFarShadow", value); }
        public bool bAffectDistanceFieldLighting { get => Native.GetPropBool(Pointer, "bAffectDistanceFieldLighting"); set => Native.SetPropBool(Pointer, "bAffectDistanceFieldLighting", value); }
        public LightingChannels LightingChannels => new LightingChannels(AddrOf(0x38D));
        public bool bUseMaterialPositionOffsetInStaticLighting { get => Native.GetPropBool(Pointer, "bUseMaterialPositionOffsetInStaticLighting"); set => Native.SetPropBool(Pointer, "bUseMaterialPositionOffsetInStaticLighting", value); }
        public bool bRenderCustomDepth { get => Native.GetPropBool(Pointer, "bRenderCustomDepth"); set => Native.SetPropBool(Pointer, "bRenderCustomDepth", value); }
        public int CustomDepthStencilValue { get => GetAt<int>(0x390); set => SetAt(0x390, value); }
        public float LDMaxDrawDistance { get => GetAt<float>(0x394); set => SetAt(0x394, value); }
        public LightmassPrimitiveSettings LightmassSettings => new LightmassPrimitiveSettings(AddrOf(0x398));
        public int CollisionMipLevel { get => GetAt<int>(0x3B0); set => SetAt(0x3B0, value); }
        public int SimpleCollisionMipLevel { get => GetAt<int>(0x3B4); set => SetAt(0x3B4, value); }
        public float CollisionThickness { get => GetAt<float>(0x3B8); set => SetAt(0x3B8, value); }
        public BodyInstance BodyInstance => new BodyInstance(AddrOf(0x3C0));
        public bool bGenerateOverlapEvents { get => Native.GetPropBool(Pointer, "bGenerateOverlapEvents"); set => Native.SetPropBool(Pointer, "bGenerateOverlapEvents", value); }
        public bool bBakeMaterialPositionOffsetIntoCollision { get => Native.GetPropBool(Pointer, "bBakeMaterialPositionOffsetIntoCollision"); set => Native.SetPropBool(Pointer, "bBakeMaterialPositionOffsetIntoCollision", value); }
        public int ComponentSizeQuads { get => GetAt<int>(0x4F4); set => SetAt(0x4F4, value); }
        public int SubsectionSizeQuads { get => GetAt<int>(0x4F8); set => SetAt(0x4F8, value); }
        public int NumSubsections { get => GetAt<int>(0x4FC); set => SetAt(0x4FC, value); }
        public bool bUsedForNavigation { get => Native.GetPropBool(Pointer, "bUsedForNavigation"); set => Native.SetPropBool(Pointer, "bUsedForNavigation", value); }
        public bool bFillCollisionUnderLandscapeForNavmesh { get => Native.GetPropBool(Pointer, "bFillCollisionUnderLandscapeForNavmesh"); set => Native.SetPropBool(Pointer, "bFillCollisionUnderLandscapeForNavmesh", value); }
        public bool bUseDynamicMaterialInstance { get => Native.GetPropBool(Pointer, "bUseDynamicMaterialInstance"); set => Native.SetPropBool(Pointer, "bUseDynamicMaterialInstance", value); }
        public ENavDataGatheringMode NavigationGeometryGatheringMode { get => (ENavDataGatheringMode)GetAt<byte>(0x502); set => SetAt(0x502, (byte)value); }
        public bool bUseLandscapeForCullingInvisibleHLODVertices { get => Native.GetPropBool(Pointer, "bUseLandscapeForCullingInvisibleHLODVertices"); set => Native.SetPropBool(Pointer, "bUseLandscapeForCullingInvisibleHLODVertices", value); }
        public bool bHasLayersContent { get => Native.GetPropBool(Pointer, "bHasLayersContent"); set => Native.SetPropBool(Pointer, "bHasLayersContent", value); }
        public System.IntPtr WeightmapUsageMap => AddrOf(0x508); // 
        /// <summary>[Native] thunk RVA 0x7AC3D14 — hookable via Hooks.InstallAt(NativeFunc_SetLandscapeMaterialVectorParameterValue).</summary>
        public static System.IntPtr NativeFunc_SetLandscapeMaterialVectorParameterValue => Memory.ModuleBase() + 0x7AC3D14;
        public void SetLandscapeMaterialVectorParameterValue(FName ParameterName, LinearColor Value)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, ParameterName);
            __pb.Set<System.IntPtr>(0x8, Value);
            CallRaw("SetLandscapeMaterialVectorParameterValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7AC3DF8 — hookable via Hooks.InstallAt(NativeFunc_SetLandscapeMaterialTextureParameterValue).</summary>
        public static System.IntPtr NativeFunc_SetLandscapeMaterialTextureParameterValue => Memory.ModuleBase() + 0x7AC3DF8;
        public void SetLandscapeMaterialTextureParameterValue(FName ParameterName, Texture Value)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, ParameterName);
            __pb.SetObject(0x8, Value);
            CallRaw("SetLandscapeMaterialTextureParameterValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7AC3C2C — hookable via Hooks.InstallAt(NativeFunc_SetLandscapeMaterialScalarParameterValue).</summary>
        public static System.IntPtr NativeFunc_SetLandscapeMaterialScalarParameterValue => Memory.ModuleBase() + 0x7AC3C2C;
        public void SetLandscapeMaterialScalarParameterValue(FName ParameterName, float Value)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, ParameterName);
            __pb.Set(0x8, Value);
            CallRaw("SetLandscapeMaterialScalarParameterValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7AC423C — hookable via Hooks.InstallAt(NativeFunc_EditorSetLandscapeMaterial).</summary>
        public static System.IntPtr NativeFunc_EditorSetLandscapeMaterial => Memory.ModuleBase() + 0x7AC423C;
        public void EditorSetLandscapeMaterial(MaterialInterface NewLandscapeMaterial)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewLandscapeMaterial);
            CallRaw("EditorSetLandscapeMaterial", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7AC3EDC — hookable via Hooks.InstallAt(NativeFunc_EditorApplySpline).</summary>
        public static System.IntPtr NativeFunc_EditorApplySpline => Memory.ModuleBase() + 0x7AC3EDC;
        public void EditorApplySpline(SplineComponent InSplineComponent, float StartWidth, float EndWidth, float StartSideFalloff, float EndSideFalloff, float StartRoll, float EndRoll, int NumSubdivisions, bool bRaiseHeights, bool bLowerHeights, LandscapeLayerInfoObject PaintLayer)
        {
            var __pb = new ParamBuffer(48);
            __pb.SetObject(0x0, InSplineComponent);
            __pb.Set(0x8, StartWidth);
            __pb.Set(0xC, EndWidth);
            __pb.Set(0x10, StartSideFalloff);
            __pb.Set(0x14, EndSideFalloff);
            __pb.Set(0x18, StartRoll);
            __pb.Set(0x1C, EndRoll);
            __pb.Set(0x20, NumSubdivisions);
            __pb.Set<byte>(0x24, (byte)(bRaiseHeights?1:0));
            __pb.Set<byte>(0x25, (byte)(bLowerHeights?1:0));
            __pb.SetObject(0x28, PaintLayer);
            CallRaw("EditorApplySpline", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7AC438C — hookable via Hooks.InstallAt(NativeFunc_ChangeUseTessellationComponentScreenSizeFalloff).</summary>
        public static System.IntPtr NativeFunc_ChangeUseTessellationComponentScreenSizeFalloff => Memory.ModuleBase() + 0x7AC438C;
        public void ChangeUseTessellationComponentScreenSizeFalloff(bool InComponentScreenSizeToUseSubSections)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InComponentScreenSizeToUseSubSections?1:0));
            CallRaw("ChangeUseTessellationComponentScreenSizeFalloff", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7AC42E0 — hookable via Hooks.InstallAt(NativeFunc_ChangeTessellationComponentScreenSizeFalloff).</summary>
        public static System.IntPtr NativeFunc_ChangeTessellationComponentScreenSizeFalloff => Memory.ModuleBase() + 0x7AC42E0;
        public void ChangeTessellationComponentScreenSizeFalloff(float InUseTessellationComponentScreenSizeFalloff)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InUseTessellationComponentScreenSizeFalloff);
            CallRaw("ChangeTessellationComponentScreenSizeFalloff", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7AC44EC — hookable via Hooks.InstallAt(NativeFunc_ChangeTessellationComponentScreenSize).</summary>
        public static System.IntPtr NativeFunc_ChangeTessellationComponentScreenSize => Memory.ModuleBase() + 0x7AC44EC;
        public void ChangeTessellationComponentScreenSize(float InTessellationComponentScreenSize)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InTessellationComponentScreenSize);
            CallRaw("ChangeTessellationComponentScreenSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7AC4598 — hookable via Hooks.InstallAt(NativeFunc_ChangeLODDistanceFactor).</summary>
        public static System.IntPtr NativeFunc_ChangeLODDistanceFactor => Memory.ModuleBase() + 0x7AC4598;
        public void ChangeLODDistanceFactor(float InLODDistanceFactor)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InLODDistanceFactor);
            CallRaw("ChangeLODDistanceFactor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7AC4440 — hookable via Hooks.InstallAt(NativeFunc_ChangeComponentScreenSizeToUseSubSections).</summary>
        public static System.IntPtr NativeFunc_ChangeComponentScreenSizeToUseSubSections => Memory.ModuleBase() + 0x7AC4440;
        public void ChangeComponentScreenSizeToUseSubSections(float InComponentScreenSizeToUseSubSections)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InComponentScreenSizeToUseSubSections);
            CallRaw("ChangeComponentScreenSizeToUseSubSections", __pb.Bytes);
        }
    }

    public class Landscape : LandscapeProxy
    {
        public const string UeClassName = "Landscape";
        public Landscape(System.IntPtr ptr) : base(ptr) {}
        public static new Landscape FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Landscape(p);
        public static Landscape FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Landscape(o.Pointer); }
        public static Landscape[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Landscape[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Landscape(a[i].Pointer); return r; }
    }

    public class LandscapeBlueprintBrushBase : Actor
    {
        public const string UeClassName = "LandscapeBlueprintBrushBase";
        public LandscapeBlueprintBrushBase(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeBlueprintBrushBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeBlueprintBrushBase(p);
        public static LandscapeBlueprintBrushBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeBlueprintBrushBase(o.Pointer); }
        public static LandscapeBlueprintBrushBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeBlueprintBrushBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeBlueprintBrushBase(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7AB8A88 — hookable via Hooks.InstallAt(NativeFunc_RequestLandscapeUpdate).</summary>
        public static System.IntPtr NativeFunc_RequestLandscapeUpdate => Memory.ModuleBase() + 0x7AB8A88;
        public void RequestLandscapeUpdate()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RequestLandscapeUpdate", __pb.Bytes);
        }
        public TextureRenderTarget2D Render(bool InIsHeightmap, TextureRenderTarget2D InCombinedResult, FName InWeightmapLayerName)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<byte>(0x0, (byte)(InIsHeightmap?1:0));
            __pb.SetObject(0x8, InCombinedResult);
            __pb.Set(0x10, InWeightmapLayerName);
            CallRaw("Render", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new TextureRenderTarget2D(__p); }
        }
        public void Initialize(Transform InLandscapeTransform, IntPoint InLandscapeSize, IntPoint InLandscapeRenderTargetSize)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, InLandscapeTransform);
            __pb.Set<System.IntPtr>(0x30, InLandscapeSize);
            __pb.Set<System.IntPtr>(0x38, InLandscapeRenderTargetSize);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void GetBlueprintRenderDependencies(System.IntPtr OutStreamableAssets)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, OutStreamableAssets);
            CallRaw("GetBlueprintRenderDependencies", __pb.Bytes);
        }
    }

    public class LandscapeComponent : PrimitiveComponent
    {
        public const string UeClassName = "LandscapeComponent";
        public LandscapeComponent(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeComponent(p);
        public static LandscapeComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeComponent(o.Pointer); }
        public static LandscapeComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeComponent(a[i].Pointer); return r; }
        public int SectionBaseX { get => GetAt<int>(0x408); set => SetAt(0x408, value); }
        public int SectionBaseY { get => GetAt<int>(0x40C); set => SetAt(0x40C, value); }
        public int ComponentSizeQuads { get => GetAt<int>(0x410); set => SetAt(0x410, value); }
        public int SubsectionSizeQuads { get => GetAt<int>(0x414); set => SetAt(0x414, value); }
        public int NumSubsections { get => GetAt<int>(0x418); set => SetAt(0x418, value); }
        public MaterialInterface OverrideMaterial { get { var __p = GetAt<System.IntPtr>(0x420); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x420, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface OverrideHoleMaterial { get { var __p = GetAt<System.IntPtr>(0x428); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x428, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> OverrideMaterials => new TArray<System.IntPtr>(AddrOf(0x430)); // TArray<struct>
        public TArray<System.IntPtr> MaterialInstances => new TArray<System.IntPtr>(AddrOf(0x440)); // TArray<UObject*>
        public TArray<System.IntPtr> MaterialInstancesDynamic => new TArray<System.IntPtr>(AddrOf(0x450)); // TArray<UObject*>
        public TArray<System.IntPtr> LODIndexToMaterialIndex => new TArray<System.IntPtr>(AddrOf(0x460)); // TArray<int8>
        public TArray<System.IntPtr> MaterialIndexToDisabledTessellationMaterial => new TArray<System.IntPtr>(AddrOf(0x470)); // TArray<int8>
        public Texture2D XYOffsetmapTexture { get { var __p = GetAt<System.IntPtr>(0x480); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x480, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector4 WeightmapScaleBias => new Vector4(AddrOf(0x490));
        public float WeightmapSubsectionOffset { get => GetAt<float>(0x4A0); set => SetAt(0x4A0, value); }
        public Vector4 HeightmapScaleBias => new Vector4(AddrOf(0x4B0));
        public Box CachedLocalBox => new Box(AddrOf(0x4C0));
        public LandscapeHeightfieldCollisionComponent CollisionComponent { get { var __p = GetAt<System.IntPtr>(0x4DC); return __p==System.IntPtr.Zero?null:new LandscapeHeightfieldCollisionComponent(__p); } set => SetAt(0x4DC, value?.Pointer ?? System.IntPtr.Zero); }
        public Texture2D HeightmapTexture { get { var __p = GetAt<System.IntPtr>(0x4F8); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x4F8, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> WeightmapLayerAllocations => new TArray<System.IntPtr>(AddrOf(0x500)); // TArray<struct>
        public TArray<System.IntPtr> WeightmapTextures => new TArray<System.IntPtr>(AddrOf(0x510)); // TArray<UObject*>
        public Guid MapBuildDataId => new Guid(AddrOf(0x520));
        public TArray<System.IntPtr> IrrelevantLights => new TArray<System.IntPtr>(AddrOf(0x530)); // TArray<struct>
        public int CollisionMipLevel { get => GetAt<int>(0x540); set => SetAt(0x540, value); }
        public int SimpleCollisionMipLevel { get => GetAt<int>(0x544); set => SetAt(0x544, value); }
        public float NegativeZBoundsExtension { get => GetAt<float>(0x548); set => SetAt(0x548, value); }
        public float PositiveZBoundsExtension { get => GetAt<float>(0x54C); set => SetAt(0x54C, value); }
        public float StaticLightingResolution { get => GetAt<float>(0x550); set => SetAt(0x550, value); }
        public int ForcedLOD { get => GetAt<int>(0x554); set => SetAt(0x554, value); }
        public int LODBias { get => GetAt<int>(0x558); set => SetAt(0x558, value); }
        public Guid StateId => new Guid(AddrOf(0x55C));
        public Guid BakedTextureMaterialGuid => new Guid(AddrOf(0x56C));
        public Texture2D GIBakedBaseColorTexture { get { var __p = GetAt<System.IntPtr>(0x580); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x580, value?.Pointer ?? System.IntPtr.Zero); }
        public byte MobileBlendableLayerMask { get => GetAt<byte>(0x588); set => SetAt(0x588, value); }
        public MaterialInterface MobileMaterialInterface { get { var __p = GetAt<System.IntPtr>(0x590); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x590, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> MobileMaterialInterfaces => new TArray<System.IntPtr>(AddrOf(0x598)); // TArray<UObject*>
        public TArray<System.IntPtr> MobileWeightmapTextures => new TArray<System.IntPtr>(AddrOf(0x5A8)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x7ABA1EC — hookable via Hooks.InstallAt(NativeFunc_GetMaterialInstanceDynamic).</summary>
        public static System.IntPtr NativeFunc_GetMaterialInstanceDynamic => Memory.ModuleBase() + 0x7ABA1EC;
        public MaterialInstanceDynamic GetMaterialInstanceDynamic(int InIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, InIndex);
            CallRaw("GetMaterialInstanceDynamic", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7AB9FEC — hookable via Hooks.InstallAt(NativeFunc_EditorGetPaintLayerWeightByNameAtLocation).</summary>
        public static System.IntPtr NativeFunc_EditorGetPaintLayerWeightByNameAtLocation => Memory.ModuleBase() + 0x7AB9FEC;
        public float EditorGetPaintLayerWeightByNameAtLocation(Vector InLocation, FName InPaintLayerName)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InLocation);
            __pb.Set(0xC, InPaintLayerName);
            CallRaw("EditorGetPaintLayerWeightByNameAtLocation", __pb.Bytes);
            return __pb.Get<float>(0x14);
        }
        /// <summary>[Native] thunk RVA 0x7ABA0EC — hookable via Hooks.InstallAt(NativeFunc_EditorGetPaintLayerWeightAtLocation).</summary>
        public static System.IntPtr NativeFunc_EditorGetPaintLayerWeightAtLocation => Memory.ModuleBase() + 0x7ABA0EC;
        public float EditorGetPaintLayerWeightAtLocation(Vector InLocation, LandscapeLayerInfoObject PaintLayer)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<System.IntPtr>(0x0, InLocation);
            __pb.SetObject(0x10, PaintLayer);
            CallRaw("EditorGetPaintLayerWeightAtLocation", __pb.Bytes);
            return __pb.Get<float>(0x18);
        }
    }

    public class LandscapeGizmoActor : Actor
    {
        public const string UeClassName = "LandscapeGizmoActor";
        public LandscapeGizmoActor(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeGizmoActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeGizmoActor(p);
        public static LandscapeGizmoActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeGizmoActor(o.Pointer); }
        public static LandscapeGizmoActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeGizmoActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeGizmoActor(a[i].Pointer); return r; }
    }

    public class LandscapeGizmoActiveActor : LandscapeGizmoActor
    {
        public const string UeClassName = "LandscapeGizmoActiveActor";
        public LandscapeGizmoActiveActor(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeGizmoActiveActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeGizmoActiveActor(p);
        public static LandscapeGizmoActiveActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeGizmoActiveActor(o.Pointer); }
        public static LandscapeGizmoActiveActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeGizmoActiveActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeGizmoActiveActor(a[i].Pointer); return r; }
    }

    public class LandscapeGizmoRenderComponent : PrimitiveComponent
    {
        public const string UeClassName = "LandscapeGizmoRenderComponent";
        public LandscapeGizmoRenderComponent(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeGizmoRenderComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeGizmoRenderComponent(p);
        public static LandscapeGizmoRenderComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeGizmoRenderComponent(o.Pointer); }
        public static LandscapeGizmoRenderComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeGizmoRenderComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeGizmoRenderComponent(a[i].Pointer); return r; }
    }

    public class LandscapeGrassType : Object
    {
        public const string UeClassName = "LandscapeGrassType";
        public LandscapeGrassType(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeGrassType FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeGrassType(p);
        public static LandscapeGrassType FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeGrassType(o.Pointer); }
        public static LandscapeGrassType[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeGrassType[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeGrassType(a[i].Pointer); return r; }
        public TArray<System.IntPtr> GrassVarieties => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public bool bEnableDensityScaling { get => Native.GetPropBool(Pointer, "bEnableDensityScaling"); set => Native.SetPropBool(Pointer, "bEnableDensityScaling", value); }
        public StaticMesh GrassMesh { get { var __p = GetAt<System.IntPtr>(0x40); return __p==System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x40, value?.Pointer ?? System.IntPtr.Zero); }
        public float GrassDensity { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float PlacementJitter { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public int StartCullDistance { get => GetAt<int>(0x50); set => SetAt(0x50, value); }
        public int EndCullDistance { get => GetAt<int>(0x54); set => SetAt(0x54, value); }
        public bool RandomRotation { get => Native.GetPropBool(Pointer, "RandomRotation"); set => Native.SetPropBool(Pointer, "RandomRotation", value); }
        public bool AlignToSurface { get => Native.GetPropBool(Pointer, "AlignToSurface"); set => Native.SetPropBool(Pointer, "AlignToSurface", value); }
    }

    public class LandscapeHeightfieldCollisionComponent : PrimitiveComponent
    {
        public const string UeClassName = "LandscapeHeightfieldCollisionComponent";
        public LandscapeHeightfieldCollisionComponent(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeHeightfieldCollisionComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeHeightfieldCollisionComponent(p);
        public static LandscapeHeightfieldCollisionComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeHeightfieldCollisionComponent(o.Pointer); }
        public static LandscapeHeightfieldCollisionComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeHeightfieldCollisionComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeHeightfieldCollisionComponent(a[i].Pointer); return r; }
        public TArray<System.IntPtr> ComponentLayerInfos => new TArray<System.IntPtr>(AddrOf(0x408)); // TArray<UObject*>
        public int SectionBaseX { get => GetAt<int>(0x418); set => SetAt(0x418, value); }
        public int SectionBaseY { get => GetAt<int>(0x41C); set => SetAt(0x41C, value); }
        public int CollisionSizeQuads { get => GetAt<int>(0x420); set => SetAt(0x420, value); }
        public float CollisionScale { get => GetAt<float>(0x424); set => SetAt(0x424, value); }
        public int SimpleCollisionSizeQuads { get => GetAt<int>(0x428); set => SetAt(0x428, value); }
        public TArray<System.IntPtr> CollisionQuadFlags => new TArray<System.IntPtr>(AddrOf(0x430)); // TArray<uint8>
        public Guid HeightfieldGuid => new Guid(AddrOf(0x440));
        public Box CachedLocalBox => new Box(AddrOf(0x450));
        public LandscapeComponent RenderComponent { get { var __p = GetAt<System.IntPtr>(0x46C); return __p==System.IntPtr.Zero?null:new LandscapeComponent(__p); } set => SetAt(0x46C, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> CookedPhysicalMaterials => new TArray<System.IntPtr>(AddrOf(0x498)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x7ABE548 — hookable via Hooks.InstallAt(NativeFunc_GetRenderComponent).</summary>
        public static System.IntPtr NativeFunc_GetRenderComponent => Memory.ModuleBase() + 0x7ABE548;
        public LandscapeComponent GetRenderComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetRenderComponent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new LandscapeComponent(__p); }
        }
    }

    public class LandscapeInfo : Object
    {
        public const string UeClassName = "LandscapeInfo";
        public LandscapeInfo(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeInfo FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeInfo(p);
        public static LandscapeInfo FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeInfo(o.Pointer); }
        public static LandscapeInfo[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeInfo[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeInfo(a[i].Pointer); return r; }
        public Landscape LandscapeActor { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new Landscape(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public Guid LandscapeGuid => new Guid(AddrOf(0x44));
        public int ComponentSizeQuads { get => GetAt<int>(0x54); set => SetAt(0x54, value); }
        public int SubsectionSizeQuads { get => GetAt<int>(0x58); set => SetAt(0x58, value); }
        public int ComponentNumSubsections { get => GetAt<int>(0x5C); set => SetAt(0x5C, value); }
        public Vector DrawScale => new Vector(AddrOf(0x60));
        public TArray<System.IntPtr> Proxies => new TArray<System.IntPtr>(AddrOf(0x110)); // TArray<UObject*>
    }

    public class LandscapeInfoMap : Object
    {
        public const string UeClassName = "LandscapeInfoMap";
        public LandscapeInfoMap(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeInfoMap FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeInfoMap(p);
        public static LandscapeInfoMap FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeInfoMap(o.Pointer); }
        public static LandscapeInfoMap[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeInfoMap[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeInfoMap(a[i].Pointer); return r; }
    }

    public class LandscapeLayerInfoObject : Object
    {
        public const string UeClassName = "LandscapeLayerInfoObject";
        public LandscapeLayerInfoObject(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeLayerInfoObject FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeLayerInfoObject(p);
        public static LandscapeLayerInfoObject FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeLayerInfoObject(o.Pointer); }
        public static LandscapeLayerInfoObject[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeLayerInfoObject[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeLayerInfoObject(a[i].Pointer); return r; }
        public string LayerName => Native.GetPropName(Pointer, "LayerName"); // FName
        public FName LayerName_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
        public PhysicalMaterial PhysMaterial { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new PhysicalMaterial(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public float Hardness { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public LinearColor LayerUsageDebugColor => new LinearColor(AddrOf(0x3C));
    }

    public class LandscapeMaterialInstanceConstant : MaterialInstanceConstant
    {
        public const string UeClassName = "LandscapeMaterialInstanceConstant";
        public LandscapeMaterialInstanceConstant(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeMaterialInstanceConstant FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeMaterialInstanceConstant(p);
        public static LandscapeMaterialInstanceConstant FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeMaterialInstanceConstant(o.Pointer); }
        public static LandscapeMaterialInstanceConstant[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeMaterialInstanceConstant[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeMaterialInstanceConstant(a[i].Pointer); return r; }
        public TArray<System.IntPtr> TextureStreamingInfo => new TArray<System.IntPtr>(AddrOf(0x410)); // TArray<struct>
        public bool bIsLayerThumbnail { get => Native.GetPropBool(Pointer, "bIsLayerThumbnail"); set => Native.SetPropBool(Pointer, "bIsLayerThumbnail", value); }
        public bool bDisableTessellation { get => Native.GetPropBool(Pointer, "bDisableTessellation"); set => Native.SetPropBool(Pointer, "bDisableTessellation", value); }
        public bool bMobile { get => Native.GetPropBool(Pointer, "bMobile"); set => Native.SetPropBool(Pointer, "bMobile", value); }
        public bool bEditorToolUsage { get => Native.GetPropBool(Pointer, "bEditorToolUsage"); set => Native.SetPropBool(Pointer, "bEditorToolUsage", value); }
    }

    public class LandscapeMeshCollisionComponent : LandscapeHeightfieldCollisionComponent
    {
        public const string UeClassName = "LandscapeMeshCollisionComponent";
        public LandscapeMeshCollisionComponent(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeMeshCollisionComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeMeshCollisionComponent(p);
        public static LandscapeMeshCollisionComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeMeshCollisionComponent(o.Pointer); }
        public static LandscapeMeshCollisionComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeMeshCollisionComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeMeshCollisionComponent(a[i].Pointer); return r; }
        public Guid MeshGuid => new Guid(AddrOf(0x4E8));
    }

    public class LandscapeMeshProxyActor : Actor
    {
        public const string UeClassName = "LandscapeMeshProxyActor";
        public LandscapeMeshProxyActor(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeMeshProxyActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeMeshProxyActor(p);
        public static LandscapeMeshProxyActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeMeshProxyActor(o.Pointer); }
        public static LandscapeMeshProxyActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeMeshProxyActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeMeshProxyActor(a[i].Pointer); return r; }
        public LandscapeMeshProxyComponent LandscapeMeshProxyComponent { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new LandscapeMeshProxyComponent(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class LandscapeMeshProxyComponent : StaticMeshComponent
    {
        public const string UeClassName = "LandscapeMeshProxyComponent";
        public LandscapeMeshProxyComponent(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeMeshProxyComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeMeshProxyComponent(p);
        public static LandscapeMeshProxyComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeMeshProxyComponent(o.Pointer); }
        public static LandscapeMeshProxyComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeMeshProxyComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeMeshProxyComponent(a[i].Pointer); return r; }
        public Guid LandscapeGuid => new Guid(AddrOf(0x49C));
        public TArray<System.IntPtr> ProxyComponentBases => new TArray<System.IntPtr>(AddrOf(0x4B0)); // TArray<struct>
        public sbyte ProxyLOD { get => GetAt<sbyte>(0x4C0); set => SetAt(0x4C0, value); }
    }

    public class LandscapeSettings : DeveloperSettings
    {
        public const string UeClassName = "LandscapeSettings";
        public LandscapeSettings(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeSettings(p);
        public static LandscapeSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeSettings(o.Pointer); }
        public static LandscapeSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeSettings(a[i].Pointer); return r; }
        public int MaxNumberOfLayers { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
    }

    public class LandscapeSplinesComponent : PrimitiveComponent
    {
        public const string UeClassName = "LandscapeSplinesComponent";
        public LandscapeSplinesComponent(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeSplinesComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeSplinesComponent(p);
        public static LandscapeSplinesComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeSplinesComponent(o.Pointer); }
        public static LandscapeSplinesComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeSplinesComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeSplinesComponent(a[i].Pointer); return r; }
        public TArray<System.IntPtr> ControlPoints => new TArray<System.IntPtr>(AddrOf(0x408)); // TArray<UObject*>
        public TArray<System.IntPtr> Segments => new TArray<System.IntPtr>(AddrOf(0x418)); // TArray<UObject*>
        public TArray<System.IntPtr> CookedForeignMeshComponents => new TArray<System.IntPtr>(AddrOf(0x428)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x7AC71B0 — hookable via Hooks.InstallAt(NativeFunc_GetSplineMeshComponents).</summary>
        public static System.IntPtr NativeFunc_GetSplineMeshComponents => Memory.ModuleBase() + 0x7AC71B0;
        public System.IntPtr GetSplineMeshComponents()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetSplineMeshComponents", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class LandscapeSplineControlPoint : Object
    {
        public const string UeClassName = "LandscapeSplineControlPoint";
        public LandscapeSplineControlPoint(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeSplineControlPoint FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeSplineControlPoint(p);
        public static LandscapeSplineControlPoint FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeSplineControlPoint(o.Pointer); }
        public static LandscapeSplineControlPoint[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeSplineControlPoint[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeSplineControlPoint(a[i].Pointer); return r; }
        public Vector Location => new Vector(AddrOf(0x28));
        public Rotator Rotation => new Rotator(AddrOf(0x34));
        public float Width { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public float LayerWidthRatio { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public float SideFalloff { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float LeftSideFalloffFactor { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public float RightSideFalloffFactor { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
        public float LeftSideLayerFalloffFactor { get => GetAt<float>(0x54); set => SetAt(0x54, value); }
        public float RightSideLayerFalloffFactor { get => GetAt<float>(0x58); set => SetAt(0x58, value); }
        public float EndFalloff { get => GetAt<float>(0x5C); set => SetAt(0x5C, value); }
        public TArray<System.IntPtr> ConnectedSegments => new TArray<System.IntPtr>(AddrOf(0x60)); // TArray<struct>
        public TArray<System.IntPtr> Points => new TArray<System.IntPtr>(AddrOf(0x70)); // TArray<struct>
        public Box Bounds => new Box(AddrOf(0x80));
        public ControlPointMeshComponent LocalMeshComponent { get { var __p = GetAt<System.IntPtr>(0xA0); return __p==System.IntPtr.Zero?null:new ControlPointMeshComponent(__p); } set => SetAt(0xA0, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class LandscapeSplineSegment : Object
    {
        public const string UeClassName = "LandscapeSplineSegment";
        public LandscapeSplineSegment(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeSplineSegment FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeSplineSegment(p);
        public static LandscapeSplineSegment FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeSplineSegment(o.Pointer); }
        public static LandscapeSplineSegment[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeSplineSegment[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeSplineSegment(a[i].Pointer); return r; }
        public System.IntPtr Connections => AddrOf(0x28); // [2] static array
        public InterpCurveVector SplineInfo => new InterpCurveVector(AddrOf(0x58));
        public TArray<System.IntPtr> Points => new TArray<System.IntPtr>(AddrOf(0x70)); // TArray<struct>
        public Box Bounds => new Box(AddrOf(0x80));
        public TArray<System.IntPtr> LocalMeshComponents => new TArray<System.IntPtr>(AddrOf(0xA0)); // TArray<UObject*>
    }

    public class LandscapeStreamingProxy : LandscapeProxy
    {
        public const string UeClassName = "LandscapeStreamingProxy";
        public LandscapeStreamingProxy(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeStreamingProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeStreamingProxy(p);
        public static LandscapeStreamingProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeStreamingProxy(o.Pointer); }
        public static LandscapeStreamingProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeStreamingProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeStreamingProxy(a[i].Pointer); return r; }
        public Landscape LandscapeActor { get { var __p = GetAt<System.IntPtr>(0x558); return __p==System.IntPtr.Zero?null:new Landscape(__p); } set => SetAt(0x558, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class LandscapeSubsystem : WorldSubsystem
    {
        public const string UeClassName = "LandscapeSubsystem";
        public LandscapeSubsystem(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeSubsystem FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeSubsystem(p);
        public static LandscapeSubsystem FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeSubsystem(o.Pointer); }
        public static LandscapeSubsystem[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeSubsystem[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeSubsystem(a[i].Pointer); return r; }
    }

    public class LandscapeWeightmapUsage : Object
    {
        public const string UeClassName = "LandscapeWeightmapUsage";
        public LandscapeWeightmapUsage(System.IntPtr ptr) : base(ptr) {}
        public static new LandscapeWeightmapUsage FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LandscapeWeightmapUsage(p);
        public static LandscapeWeightmapUsage FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LandscapeWeightmapUsage(o.Pointer); }
        public static LandscapeWeightmapUsage[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LandscapeWeightmapUsage[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LandscapeWeightmapUsage(a[i].Pointer); return r; }
        public System.IntPtr ChannelUsage => AddrOf(0x28); // [4] static array
        public Guid LayerGuid => new Guid(AddrOf(0x48));
    }

    public class MaterialExpressionLandscapeGrassOutput : MaterialExpressionCustomOutput
    {
        public const string UeClassName = "MaterialExpressionLandscapeGrassOutput";
        public MaterialExpressionLandscapeGrassOutput(System.IntPtr ptr) : base(ptr) {}
        public static new MaterialExpressionLandscapeGrassOutput FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MaterialExpressionLandscapeGrassOutput(p);
        public static MaterialExpressionLandscapeGrassOutput FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MaterialExpressionLandscapeGrassOutput(o.Pointer); }
        public static MaterialExpressionLandscapeGrassOutput[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MaterialExpressionLandscapeGrassOutput[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MaterialExpressionLandscapeGrassOutput(a[i].Pointer); return r; }
        public TArray<System.IntPtr> GrassTypes => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<struct>
    }

    public class MaterialExpressionLandscapeLayerBlend : MaterialExpression
    {
        public const string UeClassName = "MaterialExpressionLandscapeLayerBlend";
        public MaterialExpressionLandscapeLayerBlend(System.IntPtr ptr) : base(ptr) {}
        public static new MaterialExpressionLandscapeLayerBlend FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MaterialExpressionLandscapeLayerBlend(p);
        public static MaterialExpressionLandscapeLayerBlend FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MaterialExpressionLandscapeLayerBlend(o.Pointer); }
        public static MaterialExpressionLandscapeLayerBlend[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MaterialExpressionLandscapeLayerBlend[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MaterialExpressionLandscapeLayerBlend(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Layers => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<struct>
        public Guid ExpressionGUID => new Guid(AddrOf(0x50));
    }

    public class MaterialExpressionLandscapeLayerCoords : MaterialExpression
    {
        public const string UeClassName = "MaterialExpressionLandscapeLayerCoords";
        public MaterialExpressionLandscapeLayerCoords(System.IntPtr ptr) : base(ptr) {}
        public static new MaterialExpressionLandscapeLayerCoords FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MaterialExpressionLandscapeLayerCoords(p);
        public static MaterialExpressionLandscapeLayerCoords FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MaterialExpressionLandscapeLayerCoords(o.Pointer); }
        public static MaterialExpressionLandscapeLayerCoords[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MaterialExpressionLandscapeLayerCoords[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MaterialExpressionLandscapeLayerCoords(a[i].Pointer); return r; }
        public byte MappingType { get => GetAt<byte>(0x39); set => SetAt(0x39, value); }
        public byte CustomUVType { get => GetAt<byte>(0x3A); set => SetAt(0x3A, value); }
        public float MappingScale { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public float MappingRotation { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public float MappingPanU { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public float MappingPanV { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
    }

    public class MaterialExpressionLandscapeLayerSample : MaterialExpression
    {
        public const string UeClassName = "MaterialExpressionLandscapeLayerSample";
        public MaterialExpressionLandscapeLayerSample(System.IntPtr ptr) : base(ptr) {}
        public static new MaterialExpressionLandscapeLayerSample FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MaterialExpressionLandscapeLayerSample(p);
        public static MaterialExpressionLandscapeLayerSample FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MaterialExpressionLandscapeLayerSample(o.Pointer); }
        public static MaterialExpressionLandscapeLayerSample[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MaterialExpressionLandscapeLayerSample[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MaterialExpressionLandscapeLayerSample(a[i].Pointer); return r; }
        public string ParameterName => Native.GetPropName(Pointer, "ParameterName"); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0x3C); set => SetAt(0x3C, value); }
        public float PreviewWeight { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public Guid ExpressionGUID => new Guid(AddrOf(0x48));
    }

    public class MaterialExpressionLandscapeLayerSwitch : MaterialExpression
    {
        public const string UeClassName = "MaterialExpressionLandscapeLayerSwitch";
        public MaterialExpressionLandscapeLayerSwitch(System.IntPtr ptr) : base(ptr) {}
        public static new MaterialExpressionLandscapeLayerSwitch FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MaterialExpressionLandscapeLayerSwitch(p);
        public static MaterialExpressionLandscapeLayerSwitch FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MaterialExpressionLandscapeLayerSwitch(o.Pointer); }
        public static MaterialExpressionLandscapeLayerSwitch[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MaterialExpressionLandscapeLayerSwitch[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MaterialExpressionLandscapeLayerSwitch(a[i].Pointer); return r; }
        public ExpressionInput LayerUsed => new ExpressionInput(AddrOf(0x3C));
        public ExpressionInput LayerNotUsed => new ExpressionInput(AddrOf(0x50));
        public string ParameterName => Native.GetPropName(Pointer, "ParameterName"); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0x64); set => SetAt(0x64, value); }
        public bool PreviewUsed { get => Native.GetPropBool(Pointer, "PreviewUsed"); set => Native.SetPropBool(Pointer, "PreviewUsed", value); }
        public Guid ExpressionGUID => new Guid(AddrOf(0x70));
    }

    public class MaterialExpressionLandscapeLayerWeight : MaterialExpression
    {
        public const string UeClassName = "MaterialExpressionLandscapeLayerWeight";
        public MaterialExpressionLandscapeLayerWeight(System.IntPtr ptr) : base(ptr) {}
        public static new MaterialExpressionLandscapeLayerWeight FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MaterialExpressionLandscapeLayerWeight(p);
        public static MaterialExpressionLandscapeLayerWeight FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MaterialExpressionLandscapeLayerWeight(o.Pointer); }
        public static MaterialExpressionLandscapeLayerWeight[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MaterialExpressionLandscapeLayerWeight[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MaterialExpressionLandscapeLayerWeight(a[i].Pointer); return r; }
        public ExpressionInput Base => new ExpressionInput(AddrOf(0x3C));
        public ExpressionInput Layer => new ExpressionInput(AddrOf(0x50));
        public string ParameterName => Native.GetPropName(Pointer, "ParameterName"); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0x64); set => SetAt(0x64, value); }
        public float PreviewWeight { get => GetAt<float>(0x6C); set => SetAt(0x6C, value); }
        public Vector ConstBase => new Vector(AddrOf(0x70));
        public Guid ExpressionGUID => new Guid(AddrOf(0x7C));
    }

    public class MaterialExpressionLandscapeVisibilityMask : MaterialExpression
    {
        public const string UeClassName = "MaterialExpressionLandscapeVisibilityMask";
        public MaterialExpressionLandscapeVisibilityMask(System.IntPtr ptr) : base(ptr) {}
        public static new MaterialExpressionLandscapeVisibilityMask FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MaterialExpressionLandscapeVisibilityMask(p);
        public static MaterialExpressionLandscapeVisibilityMask FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MaterialExpressionLandscapeVisibilityMask(o.Pointer); }
        public static MaterialExpressionLandscapeVisibilityMask[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MaterialExpressionLandscapeVisibilityMask[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MaterialExpressionLandscapeVisibilityMask(a[i].Pointer); return r; }
        public Guid ExpressionGUID => new Guid(AddrOf(0x3C));
    }

}
