// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/DatasmithContent
using System;

namespace UEModLoader.Game
{
    public enum EDatasmithAreaLightActorType
    {
        Point = 0,
        Spot = 1,
        Rect = 2,
    }

    public enum EDatasmithAreaLightActorShape
    {
        Rectangle = 0,
        Disc = 1,
        Sphere = 2,
        Cylinder = 3,
        None = 4,
    }

    public enum EDatasmithCADStitchingTechnique
    {
        StitchingNone = 0,
        StitchingHeal = 1,
        StitchingSew = 2,
    }

    public enum EDatasmithImportHierarchy
    {
        UseMultipleActors = 0,
        UseSingleActor = 1,
        UseOneBlueprint = 2,
    }

    public enum EDatasmithImportScene
    {
        NewLevel = 0,
        CurrentLevel = 1,
        AssetsOnly = 2,
    }

    public enum EDatasmithImportLightmapMax
    {
        LIGHTMAP = 0,
    }

    public enum EDatasmithImportLightmapMin
    {
        LIGHTMAP = 0,
    }

    public enum EDatasmithImportMaterialQuality
    {
        UseNoFresnelCurves = 0,
        UseSimplifierFresnelCurves = 1,
        UseRealFresnelCurves = 2,
    }

    public enum EDatasmithImportActorPolicy
    {
        Update = 0,
        Full = 1,
        Ignore = 2,
    }

    public enum EDatasmithImportAssetConflictPolicy
    {
        Replace = 0,
        Update = 1,
        Use = 2,
        Ignore = 3,
    }

    public enum EDatasmithImportSearchPackagePolicy
    {
        Current = 0,
        All = 1,
    }

    public class DatasmithCameraLookatTrackingSettingsTemplate : StructProxy
    {
        public DatasmithCameraLookatTrackingSettingsTemplate(System.IntPtr ptr) : base(ptr) {}
        public bool bEnableLookAtTracking { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bAllowRoll { get => (GetAt<byte>(0x0) & 0x2) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public Actor ActorToTrack { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class DatasmithPostProcessSettingsTemplate : StructProxy
    {
        public DatasmithPostProcessSettingsTemplate(System.IntPtr ptr) : base(ptr) {}
        public bool bOverride_WhiteTemp { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bOverride_ColorSaturation { get => (GetAt<byte>(0x0) & 0x2) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bOverride_VignetteIntensity { get => (GetAt<byte>(0x0) & 0x4) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bOverride_FilmWhitePoint { get => (GetAt<byte>(0x0) & 0x8) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bOverride_AutoExposureMethod { get => (GetAt<byte>(0x0) & 0x10) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bOverride_CameraISO { get => (GetAt<byte>(0x0) & 0x20) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool bOverride_CameraShutterSpeed { get => (GetAt<byte>(0x0) & 0x40) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
        public bool bOverride_DepthOfFieldFstop { get => (GetAt<byte>(0x0) & 0x80) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x80) : (__b & ~0x80))); } }
        public float WhiteTemp { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float VignetteIntensity { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public LinearColor FilmWhitePoint => new LinearColor(AddrOf(0xC));
        public Vector4 ColorSaturation => new Vector4(AddrOf(0x20));
        public byte AutoExposureMethod { get => GetAt<byte>(0x30); set => SetAt(0x30, value); }
        public float CameraISO { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public float CameraShutterSpeed { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public float DepthOfFieldFstop { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
    }

    public class DatasmithCameraFocusSettingsTemplate : StructProxy
    {
        public DatasmithCameraFocusSettingsTemplate(System.IntPtr ptr) : base(ptr) {}
        public ECameraFocusMethod FocusMethod { get => (ECameraFocusMethod)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public float ManualFocusDistance { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class DatasmithCameraLensSettingsTemplate : StructProxy
    {
        public DatasmithCameraLensSettingsTemplate(System.IntPtr ptr) : base(ptr) {}
        public float MaxFStop { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
    }

    public class DatasmithCameraFilmbackSettingsTemplate : StructProxy
    {
        public DatasmithCameraFilmbackSettingsTemplate(System.IntPtr ptr) : base(ptr) {}
        public float SensorWidth { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float SensorHeight { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class DatasmithTessellationOptions : StructProxy
    {
        public DatasmithTessellationOptions(System.IntPtr ptr) : base(ptr) {}
        public float ChordTolerance { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float MaxEdgeLength { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float NormalTolerance { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public EDatasmithCADStitchingTechnique StitchingTechnique { get => (EDatasmithCADStitchingTechnique)GetAt<byte>(0xC); set => SetAt(0xC, (byte)value); }
    }

    public class DatasmithImportBaseOptions : StructProxy
    {
        public DatasmithImportBaseOptions(System.IntPtr ptr) : base(ptr) {}
        public EDatasmithImportScene SceneHandling { get => (EDatasmithImportScene)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public bool bIncludeGeometry { get => (GetAt<byte>(0x1) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIncludeMaterial { get => (GetAt<byte>(0x2) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIncludeLight { get => (GetAt<byte>(0x3) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3); SetAt(0x3, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIncludeCamera { get => (GetAt<byte>(0x4) & 0xFF) != 0; set { var __b = GetAt<byte>(0x4); SetAt(0x4, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIncludeAnimation { get => (GetAt<byte>(0x5) & 0xFF) != 0; set { var __b = GetAt<byte>(0x5); SetAt(0x5, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public DatasmithAssetImportOptions AssetOptions => new DatasmithAssetImportOptions(AddrOf(0x8));
        public DatasmithStaticMeshImportOptions StaticMeshOptions => new DatasmithStaticMeshImportOptions(AddrOf(0x10));
    }

    public class DatasmithStaticMeshImportOptions : StructProxy
    {
        public DatasmithStaticMeshImportOptions(System.IntPtr ptr) : base(ptr) {}
        public EDatasmithImportLightmapMin MinLightmapResolution { get => (EDatasmithImportLightmapMin)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public EDatasmithImportLightmapMax MaxLightmapResolution { get => (EDatasmithImportLightmapMax)GetAt<byte>(0x1); set => SetAt(0x1, (byte)value); }
        public bool bGenerateLightmapUVs { get => (GetAt<byte>(0x2) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bRemoveDegenerates { get => (GetAt<byte>(0x3) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3); SetAt(0x3, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class DatasmithAssetImportOptions : StructProxy
    {
        public DatasmithAssetImportOptions(System.IntPtr ptr) : base(ptr) {}
        public string PackagePath => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName PackagePath_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
    }

    public class DatasmithReimportOptions : StructProxy
    {
        public DatasmithReimportOptions(System.IntPtr ptr) : base(ptr) {}
        public bool bUpdateActors { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bRespawnDeletedActors { get => (GetAt<byte>(0x1) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class DatasmithStaticParameterSetTemplate : StructProxy
    {
        public DatasmithStaticParameterSetTemplate(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr StaticSwitchParameters => AddrOf(0x0); // 
    }

    public class DatasmithMeshSectionInfoMapTemplate : StructProxy
    {
        public DatasmithMeshSectionInfoMapTemplate(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr Map => AddrOf(0x0); // 
    }

    public class DatasmithMeshSectionInfoTemplate : StructProxy
    {
        public DatasmithMeshSectionInfoTemplate(System.IntPtr ptr) : base(ptr) {}
        public int MaterialIndex { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
    }

    public class DatasmithStaticMaterialTemplate : StructProxy
    {
        public DatasmithStaticMaterialTemplate(System.IntPtr ptr) : base(ptr) {}
        public string MaterialSlotName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName MaterialSlotName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public MaterialInterface MaterialInterface { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class DatasmithMeshBuildSettingsTemplate : StructProxy
    {
        public DatasmithMeshBuildSettingsTemplate(System.IntPtr ptr) : base(ptr) {}
        public bool bUseMikkTSpace { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bRecomputeNormals { get => (GetAt<byte>(0x0) & 0x2) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bRecomputeTangents { get => (GetAt<byte>(0x0) & 0x4) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bRemoveDegenerates { get => (GetAt<byte>(0x0) & 0x8) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bBuildAdjacencyBuffer { get => (GetAt<byte>(0x0) & 0x10) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bUseHighPrecisionTangentBasis { get => (GetAt<byte>(0x0) & 0x20) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool bUseFullPrecisionUVs { get => (GetAt<byte>(0x0) & 0x40) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
        public bool bGenerateLightmapUVs { get => (GetAt<byte>(0x0) & 0x80) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x80) : (__b & ~0x80))); } }
        public int MinLightmapResolution { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int SrcLightmapIndex { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public int DstLightmapIndex { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
    }

    public class DatasmithObjectTemplate : Object
    {
        public const string UeClassName = "DatasmithObjectTemplate";
        public DatasmithObjectTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithObjectTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithObjectTemplate(p);
        public static DatasmithObjectTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithObjectTemplate(o.Pointer); }
        public static DatasmithObjectTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithObjectTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithObjectTemplate(a[i].Pointer); return r; }
    }

    public class DatasmithActorTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithActorTemplate";
        public DatasmithActorTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithActorTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithActorTemplate(p);
        public static DatasmithActorTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithActorTemplate(o.Pointer); }
        public static DatasmithActorTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithActorTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithActorTemplate(a[i].Pointer); return r; }
        public System.IntPtr Layers => AddrOf(0x30); // 
        public System.IntPtr Tags => AddrOf(0x80); // 
    }

    public class DatasmithAdditionalData : Object
    {
        public const string UeClassName = "DatasmithAdditionalData";
        public DatasmithAdditionalData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithAdditionalData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithAdditionalData(p);
        public static DatasmithAdditionalData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithAdditionalData(o.Pointer); }
        public static DatasmithAdditionalData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithAdditionalData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithAdditionalData(a[i].Pointer); return r; }
    }

    public class DatasmithAreaLightActor : Actor
    {
        public const string UeClassName = "DatasmithAreaLightActor";
        public DatasmithAreaLightActor(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithAreaLightActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithAreaLightActor(p);
        public static DatasmithAreaLightActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithAreaLightActor(o.Pointer); }
        public static DatasmithAreaLightActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithAreaLightActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithAreaLightActor(a[i].Pointer); return r; }
        public EDatasmithAreaLightActorType LightType { get => (EDatasmithAreaLightActorType)GetAt<byte>(0x220); set => SetAt(0x220, (byte)value); }
        public EDatasmithAreaLightActorShape LightShape { get => (EDatasmithAreaLightActorShape)GetAt<byte>(0x221); set => SetAt(0x221, (byte)value); }
        public Vector2D Dimensions => new Vector2D(AddrOf(0x224));
        public float Intensity { get => GetAt<float>(0x22C); set => SetAt(0x22C, value); }
        public ELightUnits IntensityUnits { get => (ELightUnits)GetAt<byte>(0x230); set => SetAt(0x230, (byte)value); }
        public LinearColor Color => new LinearColor(AddrOf(0x234));
        public float Temperature { get => GetAt<float>(0x244); set => SetAt(0x244, value); }
        public TextureLightProfile IESTexture { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new TextureLightProfile(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bUseIESBrightness { get => Native.GetPropBool(Pointer, "bUseIESBrightness"); set => Native.SetPropBool(Pointer, "bUseIESBrightness", value); }
        public float IESBrightnessScale { get => GetAt<float>(0x254); set => SetAt(0x254, value); }
        public Rotator Rotation => new Rotator(AddrOf(0x258));
        public float SourceRadius { get => GetAt<float>(0x264); set => SetAt(0x264, value); }
        public float SourceLength { get => GetAt<float>(0x268); set => SetAt(0x268, value); }
        public float AttenuationRadius { get => GetAt<float>(0x26C); set => SetAt(0x26C, value); }
        public float SpotlightInnerAngle { get => GetAt<float>(0x270); set => SetAt(0x270, value); }
        public float SpotlightOuterAngle { get => GetAt<float>(0x274); set => SetAt(0x274, value); }
    }

    public class DatasmithAreaLightActorTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithAreaLightActorTemplate";
        public DatasmithAreaLightActorTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithAreaLightActorTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithAreaLightActorTemplate(p);
        public static DatasmithAreaLightActorTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithAreaLightActorTemplate(o.Pointer); }
        public static DatasmithAreaLightActorTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithAreaLightActorTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithAreaLightActorTemplate(a[i].Pointer); return r; }
        public EDatasmithAreaLightActorType LightType { get => (EDatasmithAreaLightActorType)GetAt<byte>(0x29); set => SetAt(0x29, (byte)value); }
        public EDatasmithAreaLightActorShape LightShape { get => (EDatasmithAreaLightActorShape)GetAt<byte>(0x2A); set => SetAt(0x2A, (byte)value); }
        public Vector2D Dimensions => new Vector2D(AddrOf(0x2C));
        public LinearColor Color => new LinearColor(AddrOf(0x34));
        public float Intensity { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public ELightUnits IntensityUnits { get => (ELightUnits)GetAt<byte>(0x48); set => SetAt(0x48, (byte)value); }
        public float Temperature { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public TextureLightProfile IESTexture { get { var __p = GetAt<System.IntPtr>(0x50); return __p==System.IntPtr.Zero?null:new TextureLightProfile(__p); } set => SetAt(0x50, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bUseIESBrightness { get => Native.GetPropBool(Pointer, "bUseIESBrightness"); set => Native.SetPropBool(Pointer, "bUseIESBrightness", value); }
        public float IESBrightnessScale { get => GetAt<float>(0x7C); set => SetAt(0x7C, value); }
        public Rotator Rotation => new Rotator(AddrOf(0x80));
        public float SourceRadius { get => GetAt<float>(0x8C); set => SetAt(0x8C, value); }
        public float SourceLength { get => GetAt<float>(0x90); set => SetAt(0x90, value); }
        public float AttenuationRadius { get => GetAt<float>(0x94); set => SetAt(0x94, value); }
    }

    public class DatasmithAssetImportData : AssetImportData
    {
        public const string UeClassName = "DatasmithAssetImportData";
        public DatasmithAssetImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithAssetImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithAssetImportData(p);
        public static DatasmithAssetImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithAssetImportData(o.Pointer); }
        public static DatasmithAssetImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithAssetImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithAssetImportData(a[i].Pointer); return r; }
    }

    public class DatasmithStaticMeshImportData : DatasmithAssetImportData
    {
        public const string UeClassName = "DatasmithStaticMeshImportData";
        public DatasmithStaticMeshImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithStaticMeshImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithStaticMeshImportData(p);
        public static DatasmithStaticMeshImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithStaticMeshImportData(o.Pointer); }
        public static DatasmithStaticMeshImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithStaticMeshImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithStaticMeshImportData(a[i].Pointer); return r; }
    }

    public class DatasmithStaticMeshCADImportData : DatasmithStaticMeshImportData
    {
        public const string UeClassName = "DatasmithStaticMeshCADImportData";
        public DatasmithStaticMeshCADImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithStaticMeshCADImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithStaticMeshCADImportData(p);
        public static DatasmithStaticMeshCADImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithStaticMeshCADImportData(o.Pointer); }
        public static DatasmithStaticMeshCADImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithStaticMeshCADImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithStaticMeshCADImportData(a[i].Pointer); return r; }
    }

    public class DatasmithSceneImportData : AssetImportData
    {
        public const string UeClassName = "DatasmithSceneImportData";
        public DatasmithSceneImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithSceneImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithSceneImportData(p);
        public static DatasmithSceneImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithSceneImportData(o.Pointer); }
        public static DatasmithSceneImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithSceneImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithSceneImportData(a[i].Pointer); return r; }
    }

    public class DatasmithTranslatedSceneImportData : DatasmithSceneImportData
    {
        public const string UeClassName = "DatasmithTranslatedSceneImportData";
        public DatasmithTranslatedSceneImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithTranslatedSceneImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithTranslatedSceneImportData(p);
        public static DatasmithTranslatedSceneImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithTranslatedSceneImportData(o.Pointer); }
        public static DatasmithTranslatedSceneImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithTranslatedSceneImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithTranslatedSceneImportData(a[i].Pointer); return r; }
    }

    public class DatasmithCADImportSceneData : DatasmithSceneImportData
    {
        public const string UeClassName = "DatasmithCADImportSceneData";
        public DatasmithCADImportSceneData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithCADImportSceneData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithCADImportSceneData(p);
        public static DatasmithCADImportSceneData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithCADImportSceneData(o.Pointer); }
        public static DatasmithCADImportSceneData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithCADImportSceneData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithCADImportSceneData(a[i].Pointer); return r; }
    }

    public class DatasmithMDLSceneImportData : DatasmithSceneImportData
    {
        public const string UeClassName = "DatasmithMDLSceneImportData";
        public DatasmithMDLSceneImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithMDLSceneImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithMDLSceneImportData(p);
        public static DatasmithMDLSceneImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithMDLSceneImportData(o.Pointer); }
        public static DatasmithMDLSceneImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithMDLSceneImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithMDLSceneImportData(a[i].Pointer); return r; }
    }

    public class DatasmithGLTFSceneImportData : DatasmithSceneImportData
    {
        public const string UeClassName = "DatasmithGLTFSceneImportData";
        public DatasmithGLTFSceneImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithGLTFSceneImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithGLTFSceneImportData(p);
        public static DatasmithGLTFSceneImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithGLTFSceneImportData(o.Pointer); }
        public static DatasmithGLTFSceneImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithGLTFSceneImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithGLTFSceneImportData(a[i].Pointer); return r; }
        public string Generator => Native.GetPropString(Pointer, "Generator"); // FString
        public float Version { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public string Author => Native.GetPropString(Pointer, "Author"); // FString
        public string License => Native.GetPropString(Pointer, "License"); // FString
        public string Source => Native.GetPropString(Pointer, "Source"); // FString
    }

    public class DatasmithStaticMeshGLTFImportData : DatasmithStaticMeshImportData
    {
        public const string UeClassName = "DatasmithStaticMeshGLTFImportData";
        public DatasmithStaticMeshGLTFImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithStaticMeshGLTFImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithStaticMeshGLTFImportData(p);
        public static DatasmithStaticMeshGLTFImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithStaticMeshGLTFImportData(o.Pointer); }
        public static DatasmithStaticMeshGLTFImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithStaticMeshGLTFImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithStaticMeshGLTFImportData(a[i].Pointer); return r; }
        public string SourceMeshName => Native.GetPropString(Pointer, "SourceMeshName"); // FString
    }

    public class DatasmithFBXSceneImportData : DatasmithSceneImportData
    {
        public const string UeClassName = "DatasmithFBXSceneImportData";
        public DatasmithFBXSceneImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithFBXSceneImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithFBXSceneImportData(p);
        public static DatasmithFBXSceneImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithFBXSceneImportData(o.Pointer); }
        public static DatasmithFBXSceneImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithFBXSceneImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithFBXSceneImportData(a[i].Pointer); return r; }
        public bool bGenerateLightmapUVs { get => Native.GetPropBool(Pointer, "bGenerateLightmapUVs"); set => Native.SetPropBool(Pointer, "bGenerateLightmapUVs", value); }
        public string TexturesDir => Native.GetPropString(Pointer, "TexturesDir"); // FString
        public byte IntermediateSerialization { get => GetAt<byte>(0x40); set => SetAt(0x40, value); }
        public bool bColorizeMaterials { get => Native.GetPropBool(Pointer, "bColorizeMaterials"); set => Native.SetPropBool(Pointer, "bColorizeMaterials", value); }
    }

    public class DatasmithDeltaGenAssetImportData : DatasmithAssetImportData
    {
        public const string UeClassName = "DatasmithDeltaGenAssetImportData";
        public DatasmithDeltaGenAssetImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithDeltaGenAssetImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithDeltaGenAssetImportData(p);
        public static DatasmithDeltaGenAssetImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithDeltaGenAssetImportData(o.Pointer); }
        public static DatasmithDeltaGenAssetImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithDeltaGenAssetImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithDeltaGenAssetImportData(a[i].Pointer); return r; }
    }

    public class DatasmithDeltaGenSceneImportData : DatasmithFBXSceneImportData
    {
        public const string UeClassName = "DatasmithDeltaGenSceneImportData";
        public DatasmithDeltaGenSceneImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithDeltaGenSceneImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithDeltaGenSceneImportData(p);
        public static DatasmithDeltaGenSceneImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithDeltaGenSceneImportData(o.Pointer); }
        public static DatasmithDeltaGenSceneImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithDeltaGenSceneImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithDeltaGenSceneImportData(a[i].Pointer); return r; }
        public bool bMergeNodes { get => Native.GetPropBool(Pointer, "bMergeNodes"); set => Native.SetPropBool(Pointer, "bMergeNodes", value); }
        public bool bOptimizeDuplicatedNodes { get => Native.GetPropBool(Pointer, "bOptimizeDuplicatedNodes"); set => Native.SetPropBool(Pointer, "bOptimizeDuplicatedNodes", value); }
        public bool bRemoveInvisibleNodes { get => Native.GetPropBool(Pointer, "bRemoveInvisibleNodes"); set => Native.SetPropBool(Pointer, "bRemoveInvisibleNodes", value); }
        public bool bSimplifyNodeHierarchy { get => Native.GetPropBool(Pointer, "bSimplifyNodeHierarchy"); set => Native.SetPropBool(Pointer, "bSimplifyNodeHierarchy", value); }
        public bool bImportVar { get => Native.GetPropBool(Pointer, "bImportVar"); set => Native.SetPropBool(Pointer, "bImportVar", value); }
        public string VarPath => Native.GetPropString(Pointer, "VarPath"); // FString
        public bool bImportPos { get => Native.GetPropBool(Pointer, "bImportPos"); set => Native.SetPropBool(Pointer, "bImportPos", value); }
        public string PosPath => Native.GetPropString(Pointer, "PosPath"); // FString
        public bool bImportTml { get => Native.GetPropBool(Pointer, "bImportTml"); set => Native.SetPropBool(Pointer, "bImportTml", value); }
        public string TmlPath => Native.GetPropString(Pointer, "TmlPath"); // FString
    }

    public class DatasmithVREDAssetImportData : DatasmithAssetImportData
    {
        public const string UeClassName = "DatasmithVREDAssetImportData";
        public DatasmithVREDAssetImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithVREDAssetImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithVREDAssetImportData(p);
        public static DatasmithVREDAssetImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithVREDAssetImportData(o.Pointer); }
        public static DatasmithVREDAssetImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithVREDAssetImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithVREDAssetImportData(a[i].Pointer); return r; }
    }

    public class DatasmithVREDSceneImportData : DatasmithFBXSceneImportData
    {
        public const string UeClassName = "DatasmithVREDSceneImportData";
        public DatasmithVREDSceneImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithVREDSceneImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithVREDSceneImportData(p);
        public static DatasmithVREDSceneImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithVREDSceneImportData(o.Pointer); }
        public static DatasmithVREDSceneImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithVREDSceneImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithVREDSceneImportData(a[i].Pointer); return r; }
        public bool bMergeNodes { get => Native.GetPropBool(Pointer, "bMergeNodes"); set => Native.SetPropBool(Pointer, "bMergeNodes", value); }
        public bool bOptimizeDuplicatedNodes { get => Native.GetPropBool(Pointer, "bOptimizeDuplicatedNodes"); set => Native.SetPropBool(Pointer, "bOptimizeDuplicatedNodes", value); }
        public bool bImportMats { get => Native.GetPropBool(Pointer, "bImportMats"); set => Native.SetPropBool(Pointer, "bImportMats", value); }
        public string MatsPath => Native.GetPropString(Pointer, "MatsPath"); // FString
        public bool bImportVar { get => Native.GetPropBool(Pointer, "bImportVar"); set => Native.SetPropBool(Pointer, "bImportVar", value); }
        public bool bCleanVar { get => Native.GetPropBool(Pointer, "bCleanVar"); set => Native.SetPropBool(Pointer, "bCleanVar", value); }
        public string VarPath => Native.GetPropString(Pointer, "VarPath"); // FString
        public bool bImportLightInfo { get => Native.GetPropBool(Pointer, "bImportLightInfo"); set => Native.SetPropBool(Pointer, "bImportLightInfo", value); }
        public string LightInfoPath => Native.GetPropString(Pointer, "LightInfoPath"); // FString
        public bool bImportClipInfo { get => Native.GetPropBool(Pointer, "bImportClipInfo"); set => Native.SetPropBool(Pointer, "bImportClipInfo", value); }
        public string ClipInfoPath => Native.GetPropString(Pointer, "ClipInfoPath"); // FString
    }

    public class DatasmithIFCSceneImportData : DatasmithSceneImportData
    {
        public const string UeClassName = "DatasmithIFCSceneImportData";
        public DatasmithIFCSceneImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithIFCSceneImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithIFCSceneImportData(p);
        public static DatasmithIFCSceneImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithIFCSceneImportData(o.Pointer); }
        public static DatasmithIFCSceneImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithIFCSceneImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithIFCSceneImportData(a[i].Pointer); return r; }
    }

    public class DatasmithStaticMeshIFCImportData : DatasmithStaticMeshImportData
    {
        public const string UeClassName = "DatasmithStaticMeshIFCImportData";
        public DatasmithStaticMeshIFCImportData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithStaticMeshIFCImportData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithStaticMeshIFCImportData(p);
        public static DatasmithStaticMeshIFCImportData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithStaticMeshIFCImportData(o.Pointer); }
        public static DatasmithStaticMeshIFCImportData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithStaticMeshIFCImportData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithStaticMeshIFCImportData(a[i].Pointer); return r; }
        public string SourceGlobalId => Native.GetPropString(Pointer, "SourceGlobalId"); // FString
    }

    public class DatasmithAssetUserData : AssetUserData
    {
        public const string UeClassName = "DatasmithAssetUserData";
        public DatasmithAssetUserData(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithAssetUserData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithAssetUserData(p);
        public static DatasmithAssetUserData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithAssetUserData(o.Pointer); }
        public static DatasmithAssetUserData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithAssetUserData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithAssetUserData(a[i].Pointer); return r; }
        public System.IntPtr MetaData => AddrOf(0x28); // 
    }

    public class DatasmithCineCameraActorTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithCineCameraActorTemplate";
        public DatasmithCineCameraActorTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithCineCameraActorTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithCineCameraActorTemplate(p);
        public static DatasmithCineCameraActorTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithCineCameraActorTemplate(o.Pointer); }
        public static DatasmithCineCameraActorTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithCineCameraActorTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithCineCameraActorTemplate(a[i].Pointer); return r; }
        public DatasmithCameraLookatTrackingSettingsTemplate LookatTrackingSettings => new DatasmithCameraLookatTrackingSettingsTemplate(AddrOf(0x30));
    }

    public class DatasmithCineCameraComponentTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithCineCameraComponentTemplate";
        public DatasmithCineCameraComponentTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithCineCameraComponentTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithCineCameraComponentTemplate(p);
        public static DatasmithCineCameraComponentTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithCineCameraComponentTemplate(o.Pointer); }
        public static DatasmithCineCameraComponentTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithCineCameraComponentTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithCineCameraComponentTemplate(a[i].Pointer); return r; }
        public DatasmithCameraFilmbackSettingsTemplate FilmbackSettings => new DatasmithCameraFilmbackSettingsTemplate(AddrOf(0x2C));
        public DatasmithCameraLensSettingsTemplate LensSettings => new DatasmithCameraLensSettingsTemplate(AddrOf(0x34));
        public DatasmithCameraFocusSettingsTemplate FocusSettings => new DatasmithCameraFocusSettingsTemplate(AddrOf(0x38));
        public float CurrentFocalLength { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public float CurrentAperture { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public DatasmithPostProcessSettingsTemplate PostProcessSettings => new DatasmithPostProcessSettingsTemplate(AddrOf(0x50));
    }

    public class DatasmithContentBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "DatasmithContentBlueprintLibrary";
        public DatasmithContentBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithContentBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithContentBlueprintLibrary(p);
        public static DatasmithContentBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithContentBlueprintLibrary(o.Pointer); }
        public static DatasmithContentBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithContentBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithContentBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x571DD94 — hookable via Hooks.InstallAt(NativeFunc_GetDatasmithUserDataValueForKey).</summary>
        public static System.IntPtr NativeFunc_GetDatasmithUserDataValueForKey => Memory.ModuleBase() + 0x571DD94;
        public System.IntPtr GetDatasmithUserDataValueForKey(Object Object, FName Key)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, Object);
            __pb.Set(0x8, Key);
            CallRaw("GetDatasmithUserDataValueForKey", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x571DBB4 — hookable via Hooks.InstallAt(NativeFunc_GetDatasmithUserDataKeysAndValuesForValue).</summary>
        public static System.IntPtr NativeFunc_GetDatasmithUserDataKeysAndValuesForValue => Memory.ModuleBase() + 0x571DBB4;
        public void GetDatasmithUserDataKeysAndValuesForValue(Object Object, System.IntPtr StringToMatch, System.IntPtr OutKeys, System.IntPtr OutValues)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, Object);
            __pb.Set<System.IntPtr>(0x8, StringToMatch);
            __pb.Set<System.IntPtr>(0x18, OutKeys);
            __pb.Set<System.IntPtr>(0x28, OutValues);
            CallRaw("GetDatasmithUserDataKeysAndValuesForValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x571DEC4 — hookable via Hooks.InstallAt(NativeFunc_GetDatasmithUserData).</summary>
        public static System.IntPtr NativeFunc_GetDatasmithUserData => Memory.ModuleBase() + 0x571DEC4;
        public DatasmithAssetUserData GetDatasmithUserData(Object Object)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Object);
            CallRaw("GetDatasmithUserData", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new DatasmithAssetUserData(__p); }
        }
    }

    public class DatasmithCustomActionBase : Object
    {
        public const string UeClassName = "DatasmithCustomActionBase";
        public DatasmithCustomActionBase(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithCustomActionBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithCustomActionBase(p);
        public static DatasmithCustomActionBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithCustomActionBase(o.Pointer); }
        public static DatasmithCustomActionBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithCustomActionBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithCustomActionBase(a[i].Pointer); return r; }
    }

    public class DatasmithImportedSequencesActor : Actor
    {
        public const string UeClassName = "DatasmithImportedSequencesActor";
        public DatasmithImportedSequencesActor(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithImportedSequencesActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithImportedSequencesActor(p);
        public static DatasmithImportedSequencesActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithImportedSequencesActor(o.Pointer); }
        public static DatasmithImportedSequencesActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithImportedSequencesActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithImportedSequencesActor(a[i].Pointer); return r; }
        public TArray<System.IntPtr> ImportedSequences => new TArray<System.IntPtr>(AddrOf(0x220)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x571F2F0 — hookable via Hooks.InstallAt(NativeFunc_PlayLevelSequence).</summary>
        public static System.IntPtr NativeFunc_PlayLevelSequence => Memory.ModuleBase() + 0x571F2F0;
        public void PlayLevelSequence(LevelSequence SequenceToPlay)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, SequenceToPlay);
            CallRaw("PlayLevelSequence", __pb.Bytes);
        }
    }

    public class DatasmithOptionsBase : Object
    {
        public const string UeClassName = "DatasmithOptionsBase";
        public DatasmithOptionsBase(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithOptionsBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithOptionsBase(p);
        public static DatasmithOptionsBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithOptionsBase(o.Pointer); }
        public static DatasmithOptionsBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithOptionsBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithOptionsBase(a[i].Pointer); return r; }
    }

    public class DatasmithCommonTessellationOptions : DatasmithOptionsBase
    {
        public const string UeClassName = "DatasmithCommonTessellationOptions";
        public DatasmithCommonTessellationOptions(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithCommonTessellationOptions FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithCommonTessellationOptions(p);
        public static DatasmithCommonTessellationOptions FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithCommonTessellationOptions(o.Pointer); }
        public static DatasmithCommonTessellationOptions[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithCommonTessellationOptions[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithCommonTessellationOptions(a[i].Pointer); return r; }
        public DatasmithTessellationOptions Options => new DatasmithTessellationOptions(AddrOf(0x28));
    }

    public class DatasmithImportOptions : DatasmithOptionsBase
    {
        public const string UeClassName = "DatasmithImportOptions";
        public DatasmithImportOptions(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithImportOptions FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithImportOptions(p);
        public static DatasmithImportOptions FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithImportOptions(o.Pointer); }
        public static DatasmithImportOptions[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithImportOptions[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithImportOptions(a[i].Pointer); return r; }
        public EDatasmithImportSearchPackagePolicy SearchPackagePolicy { get => (EDatasmithImportSearchPackagePolicy)GetAt<byte>(0x28); set => SetAt(0x28, (byte)value); }
        public EDatasmithImportAssetConflictPolicy MaterialConflictPolicy { get => (EDatasmithImportAssetConflictPolicy)GetAt<byte>(0x29); set => SetAt(0x29, (byte)value); }
        public EDatasmithImportAssetConflictPolicy TextureConflictPolicy { get => (EDatasmithImportAssetConflictPolicy)GetAt<byte>(0x2A); set => SetAt(0x2A, (byte)value); }
        public EDatasmithImportActorPolicy StaticMeshActorImportPolicy { get => (EDatasmithImportActorPolicy)GetAt<byte>(0x2B); set => SetAt(0x2B, (byte)value); }
        public EDatasmithImportActorPolicy LightImportPolicy { get => (EDatasmithImportActorPolicy)GetAt<byte>(0x2C); set => SetAt(0x2C, (byte)value); }
        public EDatasmithImportActorPolicy CameraImportPolicy { get => (EDatasmithImportActorPolicy)GetAt<byte>(0x2D); set => SetAt(0x2D, (byte)value); }
        public EDatasmithImportActorPolicy OtherActorImportPolicy { get => (EDatasmithImportActorPolicy)GetAt<byte>(0x2E); set => SetAt(0x2E, (byte)value); }
        public EDatasmithImportMaterialQuality MaterialQuality { get => (EDatasmithImportMaterialQuality)GetAt<byte>(0x2F); set => SetAt(0x2F, (byte)value); }
        public DatasmithImportBaseOptions BaseOptions => new DatasmithImportBaseOptions(AddrOf(0x34));
        public DatasmithReimportOptions ReimportOptions => new DatasmithReimportOptions(AddrOf(0x48));
        public string Filename => Native.GetPropString(Pointer, "Filename"); // FString
        public string FilePath => Native.GetPropString(Pointer, "FilePath"); // FString
    }

    public class DatasmithLandscapeTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithLandscapeTemplate";
        public DatasmithLandscapeTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithLandscapeTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithLandscapeTemplate(p);
        public static DatasmithLandscapeTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithLandscapeTemplate(o.Pointer); }
        public static DatasmithLandscapeTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithLandscapeTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithLandscapeTemplate(a[i].Pointer); return r; }
        public MaterialInterface LandscapeMaterial { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public int StaticLightingLOD { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
    }

    public class DatasmithLightComponentTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithLightComponentTemplate";
        public DatasmithLightComponentTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithLightComponentTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithLightComponentTemplate(p);
        public static DatasmithLightComponentTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithLightComponentTemplate(o.Pointer); }
        public static DatasmithLightComponentTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithLightComponentTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithLightComponentTemplate(a[i].Pointer); return r; }
        public bool bVisible { get => Native.GetPropBool(Pointer, "bVisible"); set => Native.SetPropBool(Pointer, "bVisible", value); }
        public bool CastShadows { get => Native.GetPropBool(Pointer, "CastShadows"); set => Native.SetPropBool(Pointer, "CastShadows", value); }
        public bool bUseTemperature { get => Native.GetPropBool(Pointer, "bUseTemperature"); set => Native.SetPropBool(Pointer, "bUseTemperature", value); }
        public bool bUseIESBrightness { get => Native.GetPropBool(Pointer, "bUseIESBrightness"); set => Native.SetPropBool(Pointer, "bUseIESBrightness", value); }
        public float Intensity { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float Temperature { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float IESBrightnessScale { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public LinearColor LightColor => new LinearColor(AddrOf(0x38));
        public MaterialInterface LightFunctionMaterial { get { var __p = GetAt<System.IntPtr>(0x48); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x48, value?.Pointer ?? System.IntPtr.Zero); }
        public TextureLightProfile IESTexture { get { var __p = GetAt<System.IntPtr>(0x50); return __p==System.IntPtr.Zero?null:new TextureLightProfile(__p); } set => SetAt(0x50, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class DatasmithMaterialInstanceTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithMaterialInstanceTemplate";
        public DatasmithMaterialInstanceTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithMaterialInstanceTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithMaterialInstanceTemplate(p);
        public static DatasmithMaterialInstanceTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithMaterialInstanceTemplate(o.Pointer); }
        public static DatasmithMaterialInstanceTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithMaterialInstanceTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithMaterialInstanceTemplate(a[i].Pointer); return r; }
        public MaterialInterface ParentMaterial { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr ScalarParameterValues => AddrOf(0x58); // 
        public System.IntPtr VectorParameterValues => AddrOf(0xA8); // 
        public System.IntPtr TextureParameterValues => AddrOf(0xF8); // 
        public DatasmithStaticParameterSetTemplate StaticParameters => new DatasmithStaticParameterSetTemplate(AddrOf(0x148));
    }

    public class DatasmithPointLightComponentTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithPointLightComponentTemplate";
        public DatasmithPointLightComponentTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithPointLightComponentTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithPointLightComponentTemplate(p);
        public static DatasmithPointLightComponentTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithPointLightComponentTemplate(o.Pointer); }
        public static DatasmithPointLightComponentTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithPointLightComponentTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithPointLightComponentTemplate(a[i].Pointer); return r; }
        public ELightUnits IntensityUnits { get => (ELightUnits)GetAt<byte>(0x29); set => SetAt(0x29, (byte)value); }
        public float SourceRadius { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float SourceLength { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float AttenuationRadius { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
    }

    public class DatasmithPostProcessVolumeTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithPostProcessVolumeTemplate";
        public DatasmithPostProcessVolumeTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithPostProcessVolumeTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithPostProcessVolumeTemplate(p);
        public static DatasmithPostProcessVolumeTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithPostProcessVolumeTemplate(o.Pointer); }
        public static DatasmithPostProcessVolumeTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithPostProcessVolumeTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithPostProcessVolumeTemplate(a[i].Pointer); return r; }
        public DatasmithPostProcessSettingsTemplate Settings => new DatasmithPostProcessSettingsTemplate(AddrOf(0x30));
        public bool bEnabled { get => Native.GetPropBool(Pointer, "bEnabled"); set => Native.SetPropBool(Pointer, "bEnabled", value); }
        public bool bUnbound { get => Native.GetPropBool(Pointer, "bUnbound"); set => Native.SetPropBool(Pointer, "bUnbound", value); }
    }

    public class DatasmithScene : Object
    {
        public const string UeClassName = "DatasmithScene";
        public DatasmithScene(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithScene FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithScene(p);
        public static DatasmithScene FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithScene(o.Pointer); }
        public static DatasmithScene[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithScene[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithScene(a[i].Pointer); return r; }
    }

    public class DatasmithSceneActor : Actor
    {
        public const string UeClassName = "DatasmithSceneActor";
        public DatasmithSceneActor(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithSceneActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithSceneActor(p);
        public static DatasmithSceneActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithSceneActor(o.Pointer); }
        public static DatasmithSceneActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithSceneActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithSceneActor(a[i].Pointer); return r; }
        public DatasmithScene Scene { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new DatasmithScene(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr RelatedActors => AddrOf(0x228); // 
    }

    public class DatasmithSceneComponentTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithSceneComponentTemplate";
        public DatasmithSceneComponentTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithSceneComponentTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithSceneComponentTemplate(p);
        public static DatasmithSceneComponentTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithSceneComponentTemplate(o.Pointer); }
        public static DatasmithSceneComponentTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithSceneComponentTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithSceneComponentTemplate(a[i].Pointer); return r; }
        public Transform RelativeTransform => new Transform(AddrOf(0x30));
        public byte Mobility { get => GetAt<byte>(0x60); set => SetAt(0x60, value); }
        public SceneComponent AttachParent { get { var __p = GetAt<System.IntPtr>(0x68); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x68, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Tags => AddrOf(0x90); // 
    }

    public class DatasmithSkyLightComponentTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithSkyLightComponentTemplate";
        public DatasmithSkyLightComponentTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithSkyLightComponentTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithSkyLightComponentTemplate(p);
        public static DatasmithSkyLightComponentTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithSkyLightComponentTemplate(o.Pointer); }
        public static DatasmithSkyLightComponentTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithSkyLightComponentTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithSkyLightComponentTemplate(a[i].Pointer); return r; }
        public byte SourceType { get => GetAt<byte>(0x29); set => SetAt(0x29, value); }
        public int CubemapResolution { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public TextureCube Cubemap { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new TextureCube(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class DatasmithSpotLightComponentTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithSpotLightComponentTemplate";
        public DatasmithSpotLightComponentTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithSpotLightComponentTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithSpotLightComponentTemplate(p);
        public static DatasmithSpotLightComponentTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithSpotLightComponentTemplate(o.Pointer); }
        public static DatasmithSpotLightComponentTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithSpotLightComponentTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithSpotLightComponentTemplate(a[i].Pointer); return r; }
        public float InnerConeAngle { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float OuterConeAngle { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
    }

    public class DatasmithStaticMeshComponentTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithStaticMeshComponentTemplate";
        public DatasmithStaticMeshComponentTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithStaticMeshComponentTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithStaticMeshComponentTemplate(p);
        public static DatasmithStaticMeshComponentTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithStaticMeshComponentTemplate(o.Pointer); }
        public static DatasmithStaticMeshComponentTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithStaticMeshComponentTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithStaticMeshComponentTemplate(a[i].Pointer); return r; }
        public StaticMesh StaticMesh { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> OverrideMaterials => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<UObject*>
    }

    public class DatasmithStaticMeshTemplate : DatasmithObjectTemplate
    {
        public const string UeClassName = "DatasmithStaticMeshTemplate";
        public DatasmithStaticMeshTemplate(System.IntPtr ptr) : base(ptr) {}
        public static new DatasmithStaticMeshTemplate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DatasmithStaticMeshTemplate(p);
        public static DatasmithStaticMeshTemplate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DatasmithStaticMeshTemplate(o.Pointer); }
        public static DatasmithStaticMeshTemplate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DatasmithStaticMeshTemplate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DatasmithStaticMeshTemplate(a[i].Pointer); return r; }
        public DatasmithMeshSectionInfoMapTemplate SectionInfoMap => new DatasmithMeshSectionInfoMapTemplate(AddrOf(0x30));
        public int LightMapCoordinateIndex { get => GetAt<int>(0x80); set => SetAt(0x80, value); }
        public int LightMapResolution { get => GetAt<int>(0x84); set => SetAt(0x84, value); }
        public TArray<System.IntPtr> BuildSettings => new TArray<System.IntPtr>(AddrOf(0x88)); // TArray<struct>
        public TArray<System.IntPtr> StaticMaterials => new TArray<System.IntPtr>(AddrOf(0x98)); // TArray<struct>
    }

}
