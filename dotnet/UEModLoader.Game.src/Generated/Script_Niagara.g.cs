// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/Niagara
using System;

namespace UEModLoader.Game
{
    public enum ENiagaraSystemSpawnSectionEndBehavior
    {
        SetSystemInactive = 0,
        Deactivate = 1,
        None = 2,
    }

    public enum ENiagaraSystemSpawnSectionEvaluateBehavior
    {
        ActivateIfInactive = 0,
        None = 1,
    }

    public enum ENiagaraSystemSpawnSectionStartBehavior
    {
        Activate = 0,
    }

    public enum ENiagaraCollisionMode
    {
        None = 0,
        SceneGeometry = 1,
        DepthBuffer = 2,
        DistanceField = 3,
    }

    public enum ENiagaraLegacyTrailWidthMode
    {
        FromCentre = 0,
        FromFirst = 1,
        FromSecond = 2,
    }

    public enum ENiagaraIterationSource
    {
        Particles = 0,
        DataInterface = 1,
    }

    public enum ENiagaraScriptGroup
    {
        Particle = 0,
        Emitter = 1,
        System = 2,
        Max = 3,
    }

    public enum ENiagaraScriptUsage
    {
        Function = 0,
        Module = 1,
        DynamicInput = 2,
        ParticleSpawnScript = 3,
        ParticleSpawnScriptInterpolated = 4,
        ParticleUpdateScript = 5,
        ParticleEventScript = 6,
        ParticleSimulationStageScript = 7,
        ParticleGPUComputeScript = 8,
        EmitterSpawnScript = 9,
        EmitterUpdateScript = 10,
        SystemSpawnScript = 11,
        SystemUpdateScript = 12,
    }

    public enum ENiagaraScriptCompileStatus
    {
        NCS_Unknown = 0,
        NCS_Dirty = 1,
        NCS_Error = 2,
        NCS_UpToDate = 3,
        NCS_BeingCreated = 4,
        NCS_UpToDateWithWarnings = 5,
        NCS_ComputeUpToDateWithWarnings = 6,
    }

    public enum ENiagaraInputNodeUsage
    {
        Undefined = 0,
        Parameter = 1,
        Attribute = 2,
        SystemConstant = 3,
        TranslatorConstant = 4,
        RapidIterationParameter = 5,
    }

    public enum ENiagaraDataSetType
    {
        ParticleData = 0,
        Shared = 1,
        Event = 2,
    }

    public enum ENiagaraAgeUpdateMode
    {
        TickDeltaTime = 0,
        DesiredAge = 1,
        DesiredAgeNoSeek = 2,
    }

    public enum ENiagaraSimTarget
    {
        CPUSim = 0,
        GPUComputeSim = 1,
    }

    public enum ENiagaraDefaultMode
    {
        Value = 0,
        Binding = 1,
        Custom = 2,
    }

    public enum ENiagaraTickBehavior
    {
        UsePrereqs = 0,
        UseComponentTickGroup = 1,
        ForceTickFirst = 2,
        ForceTickLast = 3,
    }

    public enum ENCPoolMethod
    {
        None = 0,
        AutoRelease = 1,
        ManualRelease = 2,
        ManualRelease_OnComplete = 3,
        FreeInPool = 4,
    }

    public enum ENDISkeletalMesh_SkinningMode
    {
        Invalid = 255,
        None = 0,
        SkinOnTheFly = 1,
        PreSkin = 2,
    }

    public enum ENiagaraScalabilityUpdateFrequency
    {
        SpawnOnly = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Continuous = 4,
    }

    public enum ENiagaraCullReaction
    {
        Deactivate = 0,
        DeactivateImmediate = 1,
        DeactivateResume = 2,
        DeactivateImmediateResume = 3,
    }

    public enum EParticleAllocationMode
    {
        AutomaticEstimate = 0,
        ManualEstimate = 1,
    }

    public enum EScriptExecutionMode
    {
        EveryParticle = 0,
        SpawnedParticles = 1,
        SingleParticle = 2,
    }

    public enum ENiagaraSortMode
    {
        None = 0,
        ViewDepth = 1,
        ViewDistance = 2,
        CustomAscending = 3,
        CustomDecending = 4,
    }

    public enum ENiagaraMeshLockedAxisSpace
    {
        Simulation = 0,
        World = 1,
        Local = 2,
    }

    public enum ENiagaraMeshFacingMode
    {
        Default = 0,
        Velocity = 1,
        CameraPosition = 2,
        CameraPlane = 3,
    }

    public enum ENiagaraPlatformSetState
    {
        Disabled = 0,
        Enabled = 1,
        Active = 2,
        Unknown = 3,
    }

    public enum ENiagaraPlatformSelectionState
    {
        Default = 0,
        Enabled = 1,
        Disabled = 2,
    }

    public enum ENiagaraPreviewGridResetMode
    {
        Never = 0,
        Individual = 1,
        All = 2,
    }

    public enum ENiagaraRibbonTessellationMode
    {
        Automatic = 0,
        Custom = 1,
        Disabled = 2,
    }

    public enum ENiagaraRibbonDrawDirection
    {
        FrontToBack = 0,
        BackToFront = 1,
    }

    public enum ENiagaraRibbonAgeOffsetMode
    {
        Scale = 0,
        Clip = 1,
    }

    public enum ENiagaraRibbonFacingMode
    {
        Screen = 0,
        Custom = 1,
        CustomSideVector = 2,
    }

    public enum ENiagaraModuleDependencyScriptConstraint
    {
        SameScript = 0,
        AllScripts = 1,
    }

    public enum ENiagaraModuleDependencyType
    {
        PreDependency = 0,
        PostDependency = 1,
    }

    public enum EUnusedAttributeBehaviour
    {
        Copy = 0,
        Zero = 1,
        None = 2,
        MarkInvalid = 3,
        PassThrough = 4,
    }

    public enum ENiagaraSpriteFacingMode
    {
        FaceCamera = 0,
        FaceCameraPlane = 1,
        CustomFacingVector = 2,
        FaceCameraPosition = 3,
        FaceCameraDistanceBlend = 4,
    }

    public enum ENiagaraSpriteAlignment
    {
        Unaligned = 0,
        VelocityAligned = 1,
        CustomAlignment = 2,
    }

    public enum ENiagaraParameterPanelCategory
    {
        Input = 0,
        Attributes = 1,
        Output = 2,
        Local = 3,
        User = 4,
        Engine = 5,
        Owner = 6,
        System = 7,
        Emitter = 8,
        Particles = 9,
        ScriptTransient = 10,
        StaticSwitch = 11,
        None = 12,
        Num = 13,
    }

    public enum ENiagaraScriptParameterUsage
    {
        Input = 0,
        Output = 1,
        Local = 2,
        InputOutput = 3,
        InitialValueInput = 4,
        None = 5,
        Num = 6,
    }

    public enum ENiagaraParameterScope
    {
        Input = 0,
        User = 1,
        Engine = 2,
        Owner = 3,
        System = 4,
        Emitter = 5,
        Particles = 6,
        ScriptPersistent = 7,
        ScriptTransient = 8,
        Local = 9,
        Custom = 10,
        DISPLAY_ONLY_StaticSwitch = 11,
        Output = 12,
        None = 13,
        Num = 14,
    }

    public enum ENiagaraExecutionState
    {
        Active = 0,
        Inactive = 1,
        InactiveClear = 2,
        Complete = 3,
        Disabled = 4,
        Num = 5,
    }

    public enum ENiagaraExecutionStateSource
    {
        Scalability = 0,
        Internal = 1,
        Owner = 2,
        InternalCompletion = 3,
    }

    public enum ENiagaraNumericOutputTypeSelectionMode
    {
        None = 0,
        Largest = 1,
        Smallest = 2,
        Scalar = 3,
    }

    public enum ENiagaraVariantMode
    {
        None = 0,
        Object = 1,
        DataInterface = 2,
        Bytes = 3,
    }

    public class MovieSceneNiagaraParameterSectionTemplate : StructProxy
    {
        public MovieSceneNiagaraParameterSectionTemplate(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraVariable Parameter => new NiagaraVariable(AddrOf(0x18));
    }

    public class NiagaraVariableBase : StructProxy
    {
        public NiagaraVariableBase(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public NiagaraTypeDefinition TypeDef => new NiagaraTypeDefinition(AddrOf(0x8));
    }

    public class NiagaraTypeDefinition : StructProxy
    {
        public NiagaraTypeDefinition(global::System.IntPtr ptr) : base(ptr) {}
        public Object ClassStructOrEnum { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ushort UnderlyingType { get => GetAt<ushort>(0x8); set => SetAt(0x8, value); }
    }

    public class NiagaraVariable : StructProxy
    {
        public NiagaraVariable(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> VarData => new TArray<global::System.IntPtr>(AddrOf(0x18)); // TArray<uint8>
    }

    public class MovieSceneNiagaraBoolParameterSectionTemplate : StructProxy
    {
        public MovieSceneNiagaraBoolParameterSectionTemplate(global::System.IntPtr ptr) : base(ptr) {}
        public MovieSceneBoolChannel BoolChannel => new MovieSceneBoolChannel(AddrOf(0x40));
    }

    public class MovieSceneNiagaraColorParameterSectionTemplate : StructProxy
    {
        public MovieSceneNiagaraColorParameterSectionTemplate(global::System.IntPtr ptr) : base(ptr) {}
        public MovieSceneFloatChannel RedChannel => new MovieSceneFloatChannel(AddrOf(0x40));
        public MovieSceneFloatChannel GreenChannel => new MovieSceneFloatChannel(AddrOf(0xE0));
        public MovieSceneFloatChannel BlueChannel => new MovieSceneFloatChannel(AddrOf(0x180));
        public MovieSceneFloatChannel AlphaChannel => new MovieSceneFloatChannel(AddrOf(0x220));
    }

    public class MovieSceneNiagaraFloatParameterSectionTemplate : StructProxy
    {
        public MovieSceneNiagaraFloatParameterSectionTemplate(global::System.IntPtr ptr) : base(ptr) {}
        public MovieSceneFloatChannel FloatChannel => new MovieSceneFloatChannel(AddrOf(0x40));
    }

    public class MovieSceneNiagaraIntegerParameterSectionTemplate : StructProxy
    {
        public MovieSceneNiagaraIntegerParameterSectionTemplate(global::System.IntPtr ptr) : base(ptr) {}
        public MovieSceneIntegerChannel IntegerChannel => new MovieSceneIntegerChannel(AddrOf(0x40));
    }

    public class MovieSceneNiagaraSystemTrackImplementation : StructProxy
    {
        public MovieSceneNiagaraSystemTrackImplementation(global::System.IntPtr ptr) : base(ptr) {}
        public FrameNumber SpawnSectionStartFrame => new FrameNumber(AddrOf(0xC));
        public FrameNumber SpawnSectionEndFrame => new FrameNumber(AddrOf(0x10));
        public ENiagaraSystemSpawnSectionStartBehavior SpawnSectionStartBehavior { get => (ENiagaraSystemSpawnSectionStartBehavior)GetAt<int>(0x14); set => SetAt(0x14, (int)value); }
        public ENiagaraSystemSpawnSectionEvaluateBehavior SpawnSectionEvaluateBehavior { get => (ENiagaraSystemSpawnSectionEvaluateBehavior)GetAt<int>(0x18); set => SetAt(0x18, (int)value); }
        public ENiagaraSystemSpawnSectionEndBehavior SpawnSectionEndBehavior { get => (ENiagaraSystemSpawnSectionEndBehavior)GetAt<int>(0x1C); set => SetAt(0x1C, (int)value); }
        public ENiagaraAgeUpdateMode AgeUpdateMode { get => (ENiagaraAgeUpdateMode)GetAt<byte>(0x20); set => SetAt(0x20, (byte)value); }
    }

    public class MovieSceneNiagaraSystemTrackTemplate : StructProxy
    {
        public MovieSceneNiagaraSystemTrackTemplate(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneNiagaraVectorParameterSectionTemplate : StructProxy
    {
        public MovieSceneNiagaraVectorParameterSectionTemplate(global::System.IntPtr ptr) : base(ptr) {}
        public global::System.IntPtr VectorChannels => AddrOf(0x40); // [4] static array
        public int ChannelsUsed { get => GetAt<int>(0x2C0); set => SetAt(0x2C0, value); }
    }

    public class NiagaraRandInfo : StructProxy
    {
        public NiagaraRandInfo(global::System.IntPtr ptr) : base(ptr) {}
        public int Seed1 { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int Seed2 { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int Seed3 { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
    }

    public class NiagaraUserParameterBinding : StructProxy
    {
        public NiagaraUserParameterBinding(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraVariable Parameter => new NiagaraVariable(AddrOf(0x0));
    }

    public class NiagaraScriptVariableBinding : StructProxy
    {
        public NiagaraScriptVariableBinding(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
    }

    public class NiagaraVariableDataInterfaceBinding : StructProxy
    {
        public NiagaraVariableDataInterfaceBinding(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraVariable BoundVariable => new NiagaraVariable(AddrOf(0x0));
    }

    public class NiagaraVariableAttributeBinding : StructProxy
    {
        public NiagaraVariableAttributeBinding(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraVariable BoundVariable => new NiagaraVariable(AddrOf(0x0));
        public NiagaraVariable DataSetVariable => new NiagaraVariable(AddrOf(0x28));
        public NiagaraVariable DefaultValueIfNonExistent => new NiagaraVariable(AddrOf(0x50));
    }

    public class NiagaraVariableInfo : StructProxy
    {
        public NiagaraVariableInfo(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraVariable Variable => new NiagaraVariable(AddrOf(0x0));
        public global::System.IntPtr Definition => AddrOf(0x28); // 
        public NiagaraDataInterface DataInterface { get { var __p = GetAt<global::System.IntPtr>(0x40); return __p==global::System.IntPtr.Zero?null:new NiagaraDataInterface(__p); } set => SetAt(0x40, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NiagaraSystemUpdateContext : StructProxy
    {
        public NiagaraSystemUpdateContext(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> ComponentsToReset => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<UObject*>
        public TArray<global::System.IntPtr> ComponentsToReInit => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<UObject*>
        public TArray<global::System.IntPtr> SystemSimsToDestroy => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<UObject*>
    }

    public class VMExternalFunctionBindingInfo : StructProxy
    {
        public VMExternalFunctionBindingInfo(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string OwnerName => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName OwnerName_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
        public TArray<global::System.IntPtr> InputParamLocations => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<bool>
        public int NumOutputs { get => GetAt<int>(0x20); set => SetAt(0x20, value); }
        public TArray<global::System.IntPtr> FunctionSpecifiers => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
    }

    public class VMFunctionSpecifier : StructProxy
    {
        public VMFunctionSpecifier(global::System.IntPtr ptr) : base(ptr) {}
        public string Key => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Key_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string Value => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName Value_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
    }

    public class NiagaraStatScope : StructProxy
    {
        public NiagaraStatScope(global::System.IntPtr ptr) : base(ptr) {}
        public string FullName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName FullName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string FriendlyName => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName FriendlyName_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
    }

    public class NiagaraScriptDataInterfaceCompileInfo : StructProxy
    {
        public NiagaraScriptDataInterfaceCompileInfo(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public int UserPtrIdx { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public NiagaraTypeDefinition Type => new NiagaraTypeDefinition(AddrOf(0x10));
        public string RegisteredParameterMapRead => Native.FNameToString(GetAt<int>(0x20)); // FName
        public FName RegisteredParameterMapRead_Raw { get => GetAt<FName>(0x20); set => SetAt(0x20, value); }
        public string RegisteredParameterMapWrite => Native.FNameToString(GetAt<int>(0x28)); // FName
        public FName RegisteredParameterMapWrite_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
        public bool bIsPlaceholder { get => (GetAt<byte>(0x30) & 0xFF) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class NiagaraScriptDataInterfaceInfo : StructProxy
    {
        public NiagaraScriptDataInterfaceInfo(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraDataInterface DataInterface { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new NiagaraDataInterface(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string Name => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
        public int UserPtrIdx { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
        public NiagaraTypeDefinition Type => new NiagaraTypeDefinition(AddrOf(0x18));
        public string RegisteredParameterMapRead => Native.FNameToString(GetAt<int>(0x28)); // FName
        public FName RegisteredParameterMapRead_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
        public string RegisteredParameterMapWrite => Native.FNameToString(GetAt<int>(0x30)); // FName
        public FName RegisteredParameterMapWrite_Raw { get => GetAt<FName>(0x30); set => SetAt(0x30, value); }
    }

    public class NiagaraFunctionSignature : StructProxy
    {
        public NiagaraFunctionSignature(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public TArray<global::System.IntPtr> Inputs => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public TArray<global::System.IntPtr> Outputs => new TArray<global::System.IntPtr>(AddrOf(0x18)); // TArray<struct>
        public string OwnerName => Native.FNameToString(GetAt<int>(0x28)); // FName
        public FName OwnerName_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
        public bool bRequiresContext { get => (GetAt<byte>(0x30) & 0x1) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bMemberFunction { get => (GetAt<byte>(0x30) & 0x2) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bExperimental { get => (GetAt<byte>(0x30) & 0x4) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bSupportsCPU { get => (GetAt<byte>(0x30) & 0x8) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bSupportsGPU { get => (GetAt<byte>(0x30) & 0x10) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bWriteFunction { get => (GetAt<byte>(0x30) & 0x20) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public global::System.IntPtr FunctionSpecifiers => AddrOf(0x38); // 
    }

    public class NiagaraScriptDataUsageInfo : StructProxy
    {
        public NiagaraScriptDataUsageInfo(global::System.IntPtr ptr) : base(ptr) {}
        public bool bReadsAttributeData { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class NiagaraDataSetProperties : StructProxy
    {
        public NiagaraDataSetProperties(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraDataSetID ID => new NiagaraDataSetID(AddrOf(0x0));
        public TArray<global::System.IntPtr> Variables => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<struct>
    }

    public class NiagaraDataSetID : StructProxy
    {
        public NiagaraDataSetID(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public ENiagaraDataSetType Type { get => (ENiagaraDataSetType)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
    }

    public class NCPool : StructProxy
    {
        public NCPool(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> FreeElements => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<global::System.IntPtr> InUseComponents_Auto => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<UObject*>
        public TArray<global::System.IntPtr> InUseComponents_Manual => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<UObject*>
    }

    public class NCPoolElement : StructProxy
    {
        public NCPoolElement(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraComponent component { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new NiagaraComponent(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class BasicParticleData : StructProxy
    {
        public BasicParticleData(global::System.IntPtr ptr) : base(ptr) {}
        public Vector Position => new Vector(AddrOf(0x0));
        public float Size { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public Vector Velocity => new Vector(AddrOf(0x10));
    }

    public class MeshTriCoordinate : StructProxy
    {
        public MeshTriCoordinate(global::System.IntPtr ptr) : base(ptr) {}
        public int Tri { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public Vector BaryCoord => new Vector(AddrOf(0x4));
    }

    public class NDIStaticMeshSectionFilter : StructProxy
    {
        public NDIStaticMeshSectionFilter(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> AllowedMaterialSlots => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<int32>
    }

    public class NiagaraDataSetCompiledData : StructProxy
    {
        public NiagaraDataSetCompiledData(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Variables => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<global::System.IntPtr> VariableLayouts => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public uint TotalFloatComponents { get => GetAt<uint>(0x20); set => SetAt(0x20, value); }
        public uint TotalInt32Components { get => GetAt<uint>(0x24); set => SetAt(0x24, value); }
        public bool bRequiresPersistentIDs { get => (GetAt<byte>(0x28) & 0x1) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public NiagaraDataSetID ID => new NiagaraDataSetID(AddrOf(0x2C));
        public ENiagaraSimTarget SimTarget { get => (ENiagaraSimTarget)GetAt<byte>(0x38); set => SetAt(0x38, (byte)value); }
    }

    public class NiagaraVariableLayoutInfo : StructProxy
    {
        public NiagaraVariableLayoutInfo(global::System.IntPtr ptr) : base(ptr) {}
        public uint FloatComponentStart { get => GetAt<uint>(0x0); set => SetAt(0x0, value); }
        public uint Int32ComponentStart { get => GetAt<uint>(0x4); set => SetAt(0x4, value); }
        public NiagaraTypeLayoutInfo LayoutInfo => new NiagaraTypeLayoutInfo(AddrOf(0x8));
    }

    public class NiagaraTypeLayoutInfo : StructProxy
    {
        public NiagaraTypeLayoutInfo(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> FloatComponentByteOffsets => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<uint32>
        public TArray<global::System.IntPtr> FloatComponentRegisterOffsets => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<uint32>
        public TArray<global::System.IntPtr> Int32ComponentByteOffsets => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<uint32>
        public TArray<global::System.IntPtr> Int32ComponentRegisterOffsets => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<uint32>
    }

    public class NiagaraGraphViewSettings : StructProxy
    {
        public NiagaraGraphViewSettings(global::System.IntPtr ptr) : base(ptr) {}
        public Vector2D Location => new Vector2D(AddrOf(0x0));
        public float Zoom { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public bool bIsValid { get => (GetAt<byte>(0xC) & 0xFF) != 0; set { var __b = GetAt<byte>(0xC); SetAt(0xC, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class NiagaraEmitterScalabilityOverrides : StructProxy
    {
        public NiagaraEmitterScalabilityOverrides(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Overrides => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class NiagaraEmitterScalabilitySettings : StructProxy
    {
        public NiagaraEmitterScalabilitySettings(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraPlatformSet Platforms => new NiagaraPlatformSet(AddrOf(0x0));
        public bool bScaleSpawnCount { get => (GetAt<byte>(0x20) & 0x1) != 0; set { var __b = GetAt<byte>(0x20); SetAt(0x20, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public float SpawnCountScale { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
    }

    public class NiagaraPlatformSet : StructProxy
    {
        public NiagaraPlatformSet(global::System.IntPtr ptr) : base(ptr) {}
        public int QualityLevelMask { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public TArray<global::System.IntPtr> DeviceProfileStates => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<struct>
    }

    public class NiagaraDeviceProfileStateEntry : StructProxy
    {
        public NiagaraDeviceProfileStateEntry(global::System.IntPtr ptr) : base(ptr) {}
        public string ProfileName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ProfileName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public uint QualityLevelMask { get => GetAt<uint>(0x8); set => SetAt(0x8, value); }
        public uint SetQualityLevelMask { get => GetAt<uint>(0xC); set => SetAt(0xC, value); }
    }

    public class NiagaraEmitterScalabilityOverride : StructProxy
    {
        public NiagaraEmitterScalabilityOverride(global::System.IntPtr ptr) : base(ptr) {}
        public bool bOverrideSpawnCountScale { get => (GetAt<byte>(0x28) & 0x1) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class NiagaraEmitterScalabilitySettingsArray : StructProxy
    {
        public NiagaraEmitterScalabilitySettingsArray(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Settings => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class NiagaraSystemScalabilityOverrides : StructProxy
    {
        public NiagaraSystemScalabilityOverrides(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Overrides => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class NiagaraSystemScalabilitySettings : StructProxy
    {
        public NiagaraSystemScalabilitySettings(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraPlatformSet Platforms => new NiagaraPlatformSet(AddrOf(0x0));
        public bool bCullByDistance { get => (GetAt<byte>(0x20) & 0x1) != 0; set { var __b = GetAt<byte>(0x20); SetAt(0x20, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bCullMaxInstanceCount { get => (GetAt<byte>(0x20) & 0x2) != 0; set { var __b = GetAt<byte>(0x20); SetAt(0x20, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bCullByMaxTimeWithoutRender { get => (GetAt<byte>(0x20) & 0x4) != 0; set { var __b = GetAt<byte>(0x20); SetAt(0x20, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public float MaxDistance { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public float MaxInstances { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public float MaxTimeWithoutRender { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
    }

    public class NiagaraSystemScalabilityOverride : StructProxy
    {
        public NiagaraSystemScalabilityOverride(global::System.IntPtr ptr) : base(ptr) {}
        public bool bOverrideDistanceSettings { get => (GetAt<byte>(0x30) & 0x1) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bOverrideInstanceCountSettings { get => (GetAt<byte>(0x30) & 0x2) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bOverrideTimeSinceRendererSettings { get => (GetAt<byte>(0x30) & 0x4) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
    }

    public class NiagaraSystemScalabilitySettingsArray : StructProxy
    {
        public NiagaraSystemScalabilitySettingsArray(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Settings => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class NiagaraDetailsLevelScaleOverrides : StructProxy
    {
        public NiagaraDetailsLevelScaleOverrides(global::System.IntPtr ptr) : base(ptr) {}
        public float Low { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Medium { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float High { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float Epic { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float Cine { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
    }

    public class NiagaraEmitterScriptProperties : StructProxy
    {
        public NiagaraEmitterScriptProperties(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraScript Script { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new NiagaraScript(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> EventReceivers => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public TArray<global::System.IntPtr> EventGenerators => new TArray<global::System.IntPtr>(AddrOf(0x18)); // TArray<struct>
    }

    public class NiagaraEventGeneratorProperties : StructProxy
    {
        public NiagaraEventGeneratorProperties(global::System.IntPtr ptr) : base(ptr) {}
        public int MaxEventsPerFrame { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public string ID => Native.FNameToString(GetAt<int>(0x4)); // FName
        public FName ID_Raw { get => GetAt<FName>(0x4); set => SetAt(0x4, value); }
        public NiagaraDataSetCompiledData DataSetCompiledData => new NiagaraDataSetCompiledData(AddrOf(0x10));
    }

    public class NiagaraEventReceiverProperties : StructProxy
    {
        public NiagaraEventReceiverProperties(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string SourceEventGenerator => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName SourceEventGenerator_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
        public string SourceEmitter => Native.FNameToString(GetAt<int>(0x10)); // FName
        public FName SourceEmitter_Raw { get => GetAt<FName>(0x10); set => SetAt(0x10, value); }
    }

    public class NiagaraEventScriptProperties : StructProxy
    {
        public NiagaraEventScriptProperties(global::System.IntPtr ptr) : base(ptr) {}
        public EScriptExecutionMode ExecutionMode { get => (EScriptExecutionMode)GetAt<byte>(0x28); set => SetAt(0x28, (byte)value); }
        public uint SpawnNumber { get => GetAt<uint>(0x2C); set => SetAt(0x2C, value); }
        public uint MaxEventsPerFrame { get => GetAt<uint>(0x30); set => SetAt(0x30, value); }
        public Guid SourceEmitterID => new Guid(AddrOf(0x34));
        public string SourceEventName => Native.FNameToString(GetAt<int>(0x44)); // FName
        public FName SourceEventName_Raw { get => GetAt<FName>(0x44); set => SetAt(0x44, value); }
        public bool bRandomSpawnNumber { get => (GetAt<byte>(0x4C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x4C); SetAt(0x4C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public uint MinSpawnNumber { get => GetAt<uint>(0x50); set => SetAt(0x50, value); }
    }

    public class NiagaraEmitterHandle : StructProxy
    {
        public NiagaraEmitterHandle(global::System.IntPtr ptr) : base(ptr) {}
        public Guid ID => new Guid(AddrOf(0x0));
        public string IdName => Native.FNameToString(GetAt<int>(0x10)); // FName
        public FName IdName_Raw { get => GetAt<FName>(0x10); set => SetAt(0x10, value); }
        public bool bIsEnabled { get => (GetAt<byte>(0x18) & 0xFF) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public string Name => Native.FNameToString(GetAt<int>(0x1C)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x1C); set => SetAt(0x1C, value); }
        public NiagaraEmitter Instance { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new NiagaraEmitter(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NiagaraCollisionEventPayload : StructProxy
    {
        public NiagaraCollisionEventPayload(global::System.IntPtr ptr) : base(ptr) {}
        public Vector CollisionPos => new Vector(AddrOf(0x0));
        public Vector CollisionNormal => new Vector(AddrOf(0xC));
        public Vector CollisionVelocity => new Vector(AddrOf(0x18));
        public int ParticleIndex { get => GetAt<int>(0x24); set => SetAt(0x24, value); }
        public int PhysicalMaterialIndex { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
    }

    public class NiagaraMeshMaterialOverride : StructProxy
    {
        public NiagaraMeshMaterialOverride(global::System.IntPtr ptr) : base(ptr) {}
        public MaterialInterface ExplicitMat { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NiagaraUserParameterBinding UserParamBinding => new NiagaraUserParameterBinding(AddrOf(0x8));
    }

    public class NiagaraParameters : StructProxy
    {
        public NiagaraParameters(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Parameters => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class NiagaraParameterStore : StructProxy
    {
        public NiagaraParameterStore(global::System.IntPtr ptr) : base(ptr) {}
        public Object Owner { get { var __p = GetAt<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> SortedParameterOffsets => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<global::System.IntPtr> ParameterData => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<uint8>
        public TArray<global::System.IntPtr> DataInterfaces => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<UObject*>
        public TArray<global::System.IntPtr> UObjects => new TArray<global::System.IntPtr>(AddrOf(0x40)); // TArray<UObject*>
    }

    public class NiagaraVariableWithOffset : StructProxy
    {
        public NiagaraVariableWithOffset(global::System.IntPtr ptr) : base(ptr) {}
        public int Offset { get => GetAt<int>(0x18); set => SetAt(0x18, value); }
    }

    public class NiagaraBoundParameter : StructProxy
    {
        public NiagaraBoundParameter(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraVariable Parameter => new NiagaraVariable(AddrOf(0x0));
        public int SrcOffset { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public int DestOffset { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
    }

    public class NiagaraPlatformSetConflictInfo : StructProxy
    {
        public NiagaraPlatformSetConflictInfo(global::System.IntPtr ptr) : base(ptr) {}
        public int SetAIndex { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int SetBIndex { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public TArray<global::System.IntPtr> Conflicts => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<struct>
    }

    public class NiagaraPlatformSetConflictEntry : StructProxy
    {
        public NiagaraPlatformSetConflictEntry(global::System.IntPtr ptr) : base(ptr) {}
        public string ProfileName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ProfileName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public int QualityLevelMask { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
    }

    public class NiagaraScalabilityManager : StructProxy
    {
        public NiagaraScalabilityManager(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraEffectType EffectType { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new NiagaraEffectType(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> ManagedComponents => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<UObject*>
    }

    public class NiagaraVMExecutableData : StructProxy
    {
        public NiagaraVMExecutableData(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> ByteCode => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<uint8>
        public TArray<global::System.IntPtr> OptimizedByteCode => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<uint8>
        public int NumTempRegisters { get => GetAt<int>(0x20); set => SetAt(0x20, value); }
        public int NumUserPtrs { get => GetAt<int>(0x24); set => SetAt(0x24, value); }
        public NiagaraParameters Parameters => new NiagaraParameters(AddrOf(0x28));
        public NiagaraParameters InternalParameters => new NiagaraParameters(AddrOf(0x38));
        public global::System.IntPtr DataSetToParameters => AddrOf(0x48); // 
        public TArray<global::System.IntPtr> Attributes => new TArray<global::System.IntPtr>(AddrOf(0x98)); // TArray<struct>
        public NiagaraScriptDataUsageInfo DataUsage => new NiagaraScriptDataUsageInfo(AddrOf(0xA8));
        public TArray<global::System.IntPtr> DataInterfaceInfo => new TArray<global::System.IntPtr>(AddrOf(0xB0)); // TArray<struct>
        public TArray<global::System.IntPtr> CalledVMExternalFunctions => new TArray<global::System.IntPtr>(AddrOf(0xC0)); // TArray<struct>
        public TArray<global::System.IntPtr> ReadDataSets => new TArray<global::System.IntPtr>(AddrOf(0xD0)); // TArray<struct>
        public TArray<global::System.IntPtr> WriteDataSets => new TArray<global::System.IntPtr>(AddrOf(0xE0)); // TArray<struct>
        public TArray<global::System.IntPtr> StatScopes => new TArray<global::System.IntPtr>(AddrOf(0xF0)); // TArray<struct>
        public TArray<global::System.IntPtr> DIParamInfo => new TArray<global::System.IntPtr>(AddrOf(0x100)); // TArray<struct>
        public ENiagaraScriptCompileStatus LastCompileStatus { get => (ENiagaraScriptCompileStatus)GetAt<byte>(0x110); set => SetAt(0x110, (byte)value); }
        public TArray<global::System.IntPtr> SimulationStageMetaData => new TArray<global::System.IntPtr>(AddrOf(0x118)); // TArray<struct>
    }

    public class SimulationStageMetaData : StructProxy
    {
        public SimulationStageMetaData(global::System.IntPtr ptr) : base(ptr) {}
        public string IterationSource => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName IterationSource_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public bool bSpawnOnly { get => (GetAt<byte>(0x8) & 0x1) != 0; set { var __b = GetAt<byte>(0x8); SetAt(0x8, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bWritesParticles { get => (GetAt<byte>(0x8) & 0x2) != 0; set { var __b = GetAt<byte>(0x8); SetAt(0x8, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public TArray<global::System.IntPtr> OutputDestinations => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<FName>
        public int MinStage { get => GetAt<int>(0x20); set => SetAt(0x20, value); }
        public int MaxStage { get => GetAt<int>(0x24); set => SetAt(0x24, value); }
    }

    public class NiagaraVMExecutableDataId : StructProxy
    {
        public NiagaraVMExecutableDataId(global::System.IntPtr ptr) : base(ptr) {}
        public Guid CompilerVersionID => new Guid(AddrOf(0x0));
        public ENiagaraScriptUsage ScriptUsageType { get => (ENiagaraScriptUsage)GetAt<byte>(0x10); set => SetAt(0x10, (byte)value); }
        public Guid ScriptUsageTypeID => new Guid(AddrOf(0x14));
        public bool bUsesRapidIterationParams { get => (GetAt<byte>(0x24) & 0x1) != 0; set { var __b = GetAt<byte>(0x24); SetAt(0x24, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bInterpolatedSpawn { get => (GetAt<byte>(0x24) & 0x2) != 0; set { var __b = GetAt<byte>(0x24); SetAt(0x24, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bRequiresPersistentIDs { get => (GetAt<byte>(0x24) & 0x4) != 0; set { var __b = GetAt<byte>(0x24); SetAt(0x24, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public Guid BaseScriptID => new Guid(AddrOf(0x28));
        public NiagaraCompileHash BaseScriptCompileHash => new NiagaraCompileHash(AddrOf(0x38));
    }

    public class NiagaraModuleDependency : StructProxy
    {
        public NiagaraModuleDependency(global::System.IntPtr ptr) : base(ptr) {}
        public string ID => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ID_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public ENiagaraModuleDependencyType Type { get => (ENiagaraModuleDependencyType)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
        public ENiagaraModuleDependencyScriptConstraint ScriptConstraint { get => (ENiagaraModuleDependencyScriptConstraint)GetAt<byte>(0x9); set => SetAt(0x9, (byte)value); }
        public global::System.IntPtr Description => AddrOf(0x10); // 
    }

    public class NiagaraScriptExecutionParameterStore : StructProxy
    {
        public NiagaraScriptExecutionParameterStore(global::System.IntPtr ptr) : base(ptr) {}
        public int ParameterSize { get => GetAt<int>(0xB8); set => SetAt(0xB8, value); }
        public uint PaddedParameterSize { get => GetAt<uint>(0xBC); set => SetAt(0xBC, value); }
        public TArray<global::System.IntPtr> PaddingInfo => new TArray<global::System.IntPtr>(AddrOf(0xC0)); // TArray<struct>
        public bool bInitialized { get => (GetAt<byte>(0xD0) & 0x1) != 0; set { var __b = GetAt<byte>(0xD0); SetAt(0xD0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class NiagaraScriptExecutionPaddingInfo : StructProxy
    {
        public NiagaraScriptExecutionPaddingInfo(global::System.IntPtr ptr) : base(ptr) {}
        public ushort SrcOffset { get => GetAt<ushort>(0x0); set => SetAt(0x0, value); }
        public ushort DestOffset { get => GetAt<ushort>(0x2); set => SetAt(0x2, value); }
        public ushort SrcSize { get => GetAt<ushort>(0x4); set => SetAt(0x4, value); }
        public ushort DestSize { get => GetAt<ushort>(0x6); set => SetAt(0x6, value); }
    }

    public class NiagaraScriptHighlight : StructProxy
    {
        public NiagaraScriptHighlight(global::System.IntPtr ptr) : base(ptr) {}
        public LinearColor Color => new LinearColor(AddrOf(0x0));
        public global::System.IntPtr DisplayName => AddrOf(0x10); // 
    }

    public class NiagaraSystemCompileRequest : StructProxy
    {
        public NiagaraSystemCompileRequest(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> RootObjects => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<UObject*>
    }

    public class EmitterCompiledScriptPair : StructProxy
    {
        public EmitterCompiledScriptPair(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class NiagaraSystemCompiledData : StructProxy
    {
        public NiagaraSystemCompiledData(global::System.IntPtr ptr) : base(ptr) {}
        public NiagaraParameterStore InstanceParamStore => new NiagaraParameterStore(AddrOf(0x0));
        public NiagaraDataSetCompiledData DataSetCompiledData => new NiagaraDataSetCompiledData(AddrOf(0xB8));
        public NiagaraDataSetCompiledData SpawnInstanceParamsDataSetCompiledData => new NiagaraDataSetCompiledData(AddrOf(0xF8));
        public NiagaraDataSetCompiledData UpdateInstanceParamsDataSetCompiledData => new NiagaraDataSetCompiledData(AddrOf(0x138));
        public NiagaraParameterDataSetBindingCollection SpawnInstanceGlobalBinding => new NiagaraParameterDataSetBindingCollection(AddrOf(0x178));
        public NiagaraParameterDataSetBindingCollection SpawnInstanceSystemBinding => new NiagaraParameterDataSetBindingCollection(AddrOf(0x198));
        public NiagaraParameterDataSetBindingCollection SpawnInstanceOwnerBinding => new NiagaraParameterDataSetBindingCollection(AddrOf(0x1B8));
        public TArray<global::System.IntPtr> SpawnInstanceEmitterBindings => new TArray<global::System.IntPtr>(AddrOf(0x1D8)); // TArray<struct>
        public NiagaraParameterDataSetBindingCollection UpdateInstanceGlobalBinding => new NiagaraParameterDataSetBindingCollection(AddrOf(0x1E8));
        public NiagaraParameterDataSetBindingCollection UpdateInstanceSystemBinding => new NiagaraParameterDataSetBindingCollection(AddrOf(0x208));
        public NiagaraParameterDataSetBindingCollection UpdateInstanceOwnerBinding => new NiagaraParameterDataSetBindingCollection(AddrOf(0x228));
        public TArray<global::System.IntPtr> UpdateInstanceEmitterBindings => new TArray<global::System.IntPtr>(AddrOf(0x248)); // TArray<struct>
    }

    public class NiagaraParameterDataSetBindingCollection : StructProxy
    {
        public NiagaraParameterDataSetBindingCollection(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> FloatOffsets => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<global::System.IntPtr> Int32Offsets => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<struct>
    }

    public class NiagaraParameterDataSetBinding : StructProxy
    {
        public NiagaraParameterDataSetBinding(global::System.IntPtr ptr) : base(ptr) {}
        public int ParameterOffset { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int DataSetComponentOffset { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class NiagaraEmitterCompiledData : StructProxy
    {
        public NiagaraEmitterCompiledData(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> SpawnAttributes => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<FName>
        public NiagaraVariable EmitterSpawnIntervalVar => new NiagaraVariable(AddrOf(0x10));
        public NiagaraVariable EmitterInterpSpawnStartDTVar => new NiagaraVariable(AddrOf(0x38));
        public NiagaraVariable EmitterSpawnGroupVar => new NiagaraVariable(AddrOf(0x60));
        public NiagaraVariable EmitterAgeVar => new NiagaraVariable(AddrOf(0x88));
        public NiagaraVariable EmitterRandomSeedVar => new NiagaraVariable(AddrOf(0xB0));
        public NiagaraVariable EmitterTotalSpawnedParticlesVar => new NiagaraVariable(AddrOf(0xD8));
        public NiagaraDataSetCompiledData DataSetCompiledData => new NiagaraDataSetCompiledData(AddrOf(0x100));
    }

    public class NiagaraVariableMetaData : StructProxy
    {
        public NiagaraVariableMetaData(global::System.IntPtr ptr) : base(ptr) {}
        public global::System.IntPtr Description => AddrOf(0x0); // 
        public global::System.IntPtr CategoryName => AddrOf(0x18); // 
        public bool bAdvancedDisplay { get => (GetAt<byte>(0x30) & 0xFF) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int EditorSortPriority { get => GetAt<int>(0x34); set => SetAt(0x34, value); }
        public bool bInlineEditConditionToggle { get => (GetAt<byte>(0x38) & 0xFF) != 0; set { var __b = GetAt<byte>(0x38); SetAt(0x38, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public NiagaraInputConditionMetadata EditCondition => new NiagaraInputConditionMetadata(AddrOf(0x40));
        public NiagaraInputConditionMetadata VisibleCondition => new NiagaraInputConditionMetadata(AddrOf(0x58));
        public global::System.IntPtr PropertyMetaData => AddrOf(0x70); // 
        public string ScopeName => Native.FNameToString(GetAt<int>(0xC0)); // FName
        public FName ScopeName_Raw { get => GetAt<FName>(0xC0); set => SetAt(0xC0, value); }
        public ENiagaraScriptParameterUsage Usage { get => (ENiagaraScriptParameterUsage)GetAt<int>(0xC8); set => SetAt(0xC8, (int)value); }
        public bool bIsStaticSwitch { get => (GetAt<byte>(0xCC) & 0xFF) != 0; set { var __b = GetAt<byte>(0xCC); SetAt(0xCC, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int StaticSwitchDefaultValue { get => GetAt<int>(0xD0); set => SetAt(0xD0, value); }
        public bool bAddedToNodeGraphDeepCopy { get => (GetAt<byte>(0xD4) & 0xFF) != 0; set { var __b = GetAt<byte>(0xD4); SetAt(0xD4, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bOutputIsPersistent { get => (GetAt<byte>(0xD5) & 0xFF) != 0; set { var __b = GetAt<byte>(0xD5); SetAt(0xD5, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public string CachedNamespacelessVariableName => Native.FNameToString(GetAt<int>(0xD8)); // FName
        public FName CachedNamespacelessVariableName_Raw { get => GetAt<FName>(0xD8); set => SetAt(0xD8, value); }
        public bool bCreatedInSystemEditor { get => (GetAt<byte>(0xE0) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE0); SetAt(0xE0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bUseLegacyNameString { get => (GetAt<byte>(0xE1) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE1); SetAt(0xE1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class NiagaraInputConditionMetadata : StructProxy
    {
        public NiagaraInputConditionMetadata(global::System.IntPtr ptr) : base(ptr) {}
        public string InputName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName InputName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public TArray<global::System.IntPtr> TargetValues => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<FString>
    }

    public class NiagaraParameterScopeInfo : StructProxy
    {
        public NiagaraParameterScopeInfo(global::System.IntPtr ptr) : base(ptr) {}
        public ENiagaraParameterScope Scope { get => (ENiagaraParameterScope)GetAt<int>(0x0); set => SetAt(0x0, (int)value); }
        public string NamespaceString => Native.ReadFStringAt(AddrOf(0x8)); // FString
    }

    public class NiagaraCompileHashVisitorDebugInfo : StructProxy
    {
        public NiagaraCompileHashVisitorDebugInfo(global::System.IntPtr ptr) : base(ptr) {}
        public string Object => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public TArray<global::System.IntPtr> PropertyKeys => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<FString>
        public TArray<global::System.IntPtr> PropertyValues => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<FString>
    }

    public class NiagaraID : StructProxy
    {
        public NiagaraID(global::System.IntPtr ptr) : base(ptr) {}
        public int Index { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int AcquireTag { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class NiagaraSpawnInfo : StructProxy
    {
        public NiagaraSpawnInfo(global::System.IntPtr ptr) : base(ptr) {}
        public int Count { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public float InterpStartDt { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float IntervalDt { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public int SpawnGroup { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
    }

    public class NiagaraMatrix : StructProxy
    {
        public NiagaraMatrix(global::System.IntPtr ptr) : base(ptr) {}
        public Vector4 Row0 => new Vector4(AddrOf(0x0));
        public Vector4 Row1 => new Vector4(AddrOf(0x10));
        public Vector4 Row2 => new Vector4(AddrOf(0x20));
        public Vector4 Row3 => new Vector4(AddrOf(0x30));
    }

    public class NiagaraTestStruct : StructProxy
    {
        public NiagaraTestStruct(global::System.IntPtr ptr) : base(ptr) {}
        public Vector Vector1 => new Vector(AddrOf(0x0));
        public Vector Vector2 => new Vector(AddrOf(0xC));
        public NiagaraTestStructInner InnerStruct1 => new NiagaraTestStructInner(AddrOf(0x18));
        public NiagaraTestStructInner InnerStruct2 => new NiagaraTestStructInner(AddrOf(0x30));
    }

    public class NiagaraTestStructInner : StructProxy
    {
        public NiagaraTestStructInner(global::System.IntPtr ptr) : base(ptr) {}
        public Vector InnerVector1 => new Vector(AddrOf(0x0));
        public Vector InnerVector2 => new Vector(AddrOf(0xC));
    }

    public class NiagaraParameterMap : StructProxy
    {
        public NiagaraParameterMap(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class NiagaraNumeric : StructProxy
    {
        public NiagaraNumeric(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class NiagaraBool : StructProxy
    {
        public NiagaraBool(global::System.IntPtr ptr) : base(ptr) {}
        public int Value { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
    }

    public class NiagaraInt32 : StructProxy
    {
        public NiagaraInt32(global::System.IntPtr ptr) : base(ptr) {}
        public int Value { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
    }

    public class NiagaraFloat : StructProxy
    {
        public NiagaraFloat(global::System.IntPtr ptr) : base(ptr) {}
        public float Value { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
    }

    public class NiagaraUserRedirectionParameterStore : StructProxy
    {
        public NiagaraUserRedirectionParameterStore(global::System.IntPtr ptr) : base(ptr) {}
        public global::System.IntPtr UserParameterRedirects => AddrOf(0xB8); // 
    }

    public class NiagaraVariant : StructProxy
    {
        public NiagaraVariant(global::System.IntPtr ptr) : base(ptr) {}
        public Object Object { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NiagaraDataInterface DataInterface { get { var __p = GetAt<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new NiagaraDataInterface(__p); } set => SetAt(0x8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> Bytes => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<uint8>
        public ENiagaraVariantMode CurrentMode { get => (ENiagaraVariantMode)GetAt<int>(0x20); set => SetAt(0x20, (int)value); }
    }

    public class NiagaraWorldManagerTickFunction : StructProxy
    {
        public NiagaraWorldManagerTickFunction(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneNiagaraTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneNiagaraTrack";
        public MovieSceneNiagaraTrack(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNiagaraTrack FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneNiagaraTrack(p);
        public static MovieSceneNiagaraTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNiagaraTrack(o.Pointer); }
        public static MovieSceneNiagaraTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNiagaraTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNiagaraTrack(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Sections => new TArray<global::System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieSceneNiagaraParameterTrack : MovieSceneNiagaraTrack
    {
        public const string UeClassName = "MovieSceneNiagaraParameterTrack";
        public MovieSceneNiagaraParameterTrack(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNiagaraParameterTrack FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneNiagaraParameterTrack(p);
        public static MovieSceneNiagaraParameterTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNiagaraParameterTrack(o.Pointer); }
        public static MovieSceneNiagaraParameterTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNiagaraParameterTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNiagaraParameterTrack(a[i].Pointer); return r; }
        public NiagaraVariable Parameter => new NiagaraVariable(AddrOf(0x68));
    }

    public class MovieSceneNiagaraBoolParameterTrack : MovieSceneNiagaraParameterTrack
    {
        public const string UeClassName = "MovieSceneNiagaraBoolParameterTrack";
        public MovieSceneNiagaraBoolParameterTrack(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNiagaraBoolParameterTrack FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneNiagaraBoolParameterTrack(p);
        public static MovieSceneNiagaraBoolParameterTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNiagaraBoolParameterTrack(o.Pointer); }
        public static MovieSceneNiagaraBoolParameterTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNiagaraBoolParameterTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNiagaraBoolParameterTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneNiagaraColorParameterTrack : MovieSceneNiagaraParameterTrack
    {
        public const string UeClassName = "MovieSceneNiagaraColorParameterTrack";
        public MovieSceneNiagaraColorParameterTrack(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNiagaraColorParameterTrack FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneNiagaraColorParameterTrack(p);
        public static MovieSceneNiagaraColorParameterTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNiagaraColorParameterTrack(o.Pointer); }
        public static MovieSceneNiagaraColorParameterTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNiagaraColorParameterTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNiagaraColorParameterTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneNiagaraFloatParameterTrack : MovieSceneNiagaraParameterTrack
    {
        public const string UeClassName = "MovieSceneNiagaraFloatParameterTrack";
        public MovieSceneNiagaraFloatParameterTrack(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNiagaraFloatParameterTrack FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneNiagaraFloatParameterTrack(p);
        public static MovieSceneNiagaraFloatParameterTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNiagaraFloatParameterTrack(o.Pointer); }
        public static MovieSceneNiagaraFloatParameterTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNiagaraFloatParameterTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNiagaraFloatParameterTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneNiagaraIntegerParameterTrack : MovieSceneNiagaraParameterTrack
    {
        public const string UeClassName = "MovieSceneNiagaraIntegerParameterTrack";
        public MovieSceneNiagaraIntegerParameterTrack(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNiagaraIntegerParameterTrack FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneNiagaraIntegerParameterTrack(p);
        public static MovieSceneNiagaraIntegerParameterTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNiagaraIntegerParameterTrack(o.Pointer); }
        public static MovieSceneNiagaraIntegerParameterTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNiagaraIntegerParameterTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNiagaraIntegerParameterTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneNiagaraSystemSpawnSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneNiagaraSystemSpawnSection";
        public MovieSceneNiagaraSystemSpawnSection(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNiagaraSystemSpawnSection FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneNiagaraSystemSpawnSection(p);
        public static MovieSceneNiagaraSystemSpawnSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNiagaraSystemSpawnSection(o.Pointer); }
        public static MovieSceneNiagaraSystemSpawnSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNiagaraSystemSpawnSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNiagaraSystemSpawnSection(a[i].Pointer); return r; }
        public ENiagaraSystemSpawnSectionStartBehavior SectionStartBehavior { get => (ENiagaraSystemSpawnSectionStartBehavior)GetAt<int>(0xD8); set => SetAt(0xD8, (int)value); }
        public ENiagaraSystemSpawnSectionEvaluateBehavior SectionEvaluateBehavior { get => (ENiagaraSystemSpawnSectionEvaluateBehavior)GetAt<int>(0xDC); set => SetAt(0xDC, (int)value); }
        public ENiagaraSystemSpawnSectionEndBehavior SectionEndBehavior { get => (ENiagaraSystemSpawnSectionEndBehavior)GetAt<int>(0xE0); set => SetAt(0xE0, (int)value); }
        public ENiagaraAgeUpdateMode AgeUpdateMode { get => (ENiagaraAgeUpdateMode)GetAt<byte>(0xE4); set => SetAt(0xE4, (byte)value); }
    }

    public class MovieSceneNiagaraSystemTrack : MovieSceneNiagaraTrack
    {
        public const string UeClassName = "MovieSceneNiagaraSystemTrack";
        public MovieSceneNiagaraSystemTrack(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNiagaraSystemTrack FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneNiagaraSystemTrack(p);
        public static MovieSceneNiagaraSystemTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNiagaraSystemTrack(o.Pointer); }
        public static MovieSceneNiagaraSystemTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNiagaraSystemTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNiagaraSystemTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneNiagaraVectorParameterTrack : MovieSceneNiagaraParameterTrack
    {
        public const string UeClassName = "MovieSceneNiagaraVectorParameterTrack";
        public MovieSceneNiagaraVectorParameterTrack(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNiagaraVectorParameterTrack FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneNiagaraVectorParameterTrack(p);
        public static MovieSceneNiagaraVectorParameterTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNiagaraVectorParameterTrack(o.Pointer); }
        public static MovieSceneNiagaraVectorParameterTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNiagaraVectorParameterTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNiagaraVectorParameterTrack(a[i].Pointer); return r; }
        public int ChannelsUsed { get => GetAt<int>(0x90); set => SetAt(0x90, value); }
    }

    public class NiagaraActor : Actor
    {
        public const string UeClassName = "NiagaraActor";
        public NiagaraActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraActor(p);
        public static NiagaraActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraActor(o.Pointer); }
        public static NiagaraActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraActor(a[i].Pointer); return r; }
        public NiagaraComponent NiagaraComponent { get { var __p = GetAt<global::System.IntPtr>(0x220); return __p==global::System.IntPtr.Zero?null:new NiagaraComponent(__p); } set => SetAt(0x220, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bDestroyOnSystemFinish { get => Native.GetPropBool(Pointer, "bDestroyOnSystemFinish"); set => Native.SetPropBool(Pointer, "bDestroyOnSystemFinish", value); }
        /// <summary>[Native] thunk RVA 0x5B8B5E8 — hookable via Hooks.InstallAt(NativeFunc_SetDestroyOnSystemFinish).</summary>
        public static global::System.IntPtr NativeFunc_SetDestroyOnSystemFinish => Memory.ModuleBase() + 0x5B8B5E8;
        public void SetDestroyOnSystemFinish(bool bShouldDestroyOnSystemFinish)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bShouldDestroyOnSystemFinish?1:0));
            CallRaw("SetDestroyOnSystemFinish", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B8B544 — hookable via Hooks.InstallAt(NativeFunc_OnNiagaraSystemFinished).</summary>
        public static global::System.IntPtr NativeFunc_OnNiagaraSystemFinished => Memory.ModuleBase() + 0x5B8B544;
        public void OnNiagaraSystemFinished(NiagaraComponent FinishedComponent)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, FinishedComponent);
            CallRaw("OnNiagaraSystemFinished", __pb.Bytes);
        }
    }

    public class NiagaraComponent : FXSystemComponent
    {
        public const string UeClassName = "NiagaraComponent";
        public NiagaraComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraComponent(p);
        public static NiagaraComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraComponent(o.Pointer); }
        public static NiagaraComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraComponent(a[i].Pointer); return r; }
        public NiagaraSystem Asset { get { var __p = GetAt<global::System.IntPtr>(0x408); return __p==global::System.IntPtr.Zero?null:new NiagaraSystem(__p); } set => SetAt(0x408, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ENiagaraTickBehavior TickBehavior { get => (ENiagaraTickBehavior)GetAt<byte>(0x410); set => SetAt(0x410, (byte)value); }
        public NiagaraUserRedirectionParameterStore OverrideParameters => new NiagaraUserRedirectionParameterStore(AddrOf(0x418));
        public bool bForceSolo { get => Native.GetPropBool(Pointer, "bForceSolo"); set => Native.SetPropBool(Pointer, "bForceSolo", value); }
        public bool bAutoDestroy { get => Native.GetPropBool(Pointer, "bAutoDestroy"); set => Native.SetPropBool(Pointer, "bAutoDestroy", value); }
        public bool bRenderingEnabled { get => Native.GetPropBool(Pointer, "bRenderingEnabled"); set => Native.SetPropBool(Pointer, "bRenderingEnabled", value); }
        public bool bAutoManageAttachment { get => Native.GetPropBool(Pointer, "bAutoManageAttachment"); set => Native.SetPropBool(Pointer, "bAutoManageAttachment", value); }
        public bool bAutoAttachWeldSimulatedBodies { get => Native.GetPropBool(Pointer, "bAutoAttachWeldSimulatedBodies"); set => Native.SetPropBool(Pointer, "bAutoAttachWeldSimulatedBodies", value); }
        public float MaxTimeBeforeForceUpdateTransform { get => GetAt<float>(0x54C); set => SetAt(0x54C, value); }
        public global::System.IntPtr OnSystemFinished => AddrOf(0x558); // 
        public SceneComponent AutoAttachParent { get { var __p = GetAt<global::System.IntPtr>(0x568); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x568, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string AutoAttachSocketName => Native.GetPropName(Pointer, "AutoAttachSocketName"); // FName
        public FName AutoAttachSocketName_Raw { get => GetAt<FName>(0x570); set => SetAt(0x570, value); }
        public EAttachmentRule AutoAttachLocationRule { get => (EAttachmentRule)GetAt<byte>(0x578); set => SetAt(0x578, (byte)value); }
        public EAttachmentRule AutoAttachRotationRule { get => (EAttachmentRule)GetAt<byte>(0x579); set => SetAt(0x579, (byte)value); }
        public EAttachmentRule AutoAttachScaleRule { get => (EAttachmentRule)GetAt<byte>(0x57A); set => SetAt(0x57A, (byte)value); }
        /// <summary>[Native] thunk RVA 0x5B92C00 — hookable via Hooks.InstallAt(NativeFunc_SetVariableVec4).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableVec4 => Memory.ModuleBase() + 0x5B92C00;
        public void SetVariableVec4(FName InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetVariableVec4", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B92838 — hookable via Hooks.InstallAt(NativeFunc_SetVariableVec3).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableVec3 => Memory.ModuleBase() + 0x5B92838;
        public void SetVariableVec3(FName InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x8, InValue);
            CallRaw("SetVariableVec3", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9266C — hookable via Hooks.InstallAt(NativeFunc_SetVariableVec2).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableVec2 => Memory.ModuleBase() + 0x5B9266C;
        public void SetVariableVec2(FName InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x8, InValue);
            CallRaw("SetVariableVec2", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B92A0C — hookable via Hooks.InstallAt(NativeFunc_SetVariableQuat).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableQuat => Memory.ModuleBase() + 0x5B92A0C;
        public void SetVariableQuat(FName InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetVariableQuat", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B91D18 — hookable via Hooks.InstallAt(NativeFunc_SetVariableObject).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableObject => Memory.ModuleBase() + 0x5B91D18;
        public void SetVariableObject(FName InVariableName, Object Object)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, InVariableName);
            __pb.SetObject(0x8, Object);
            CallRaw("SetVariableObject", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B91C34 — hookable via Hooks.InstallAt(NativeFunc_SetVariableMaterial).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableMaterial => Memory.ModuleBase() + 0x5B91C34;
        public void SetVariableMaterial(FName InVariableName, MaterialInterface Object)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, InVariableName);
            __pb.SetObject(0x8, Object);
            CallRaw("SetVariableMaterial", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B92DFC — hookable via Hooks.InstallAt(NativeFunc_SetVariableLinearColor).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableLinearColor => Memory.ModuleBase() + 0x5B92DFC;
        public void SetVariableLinearColor(FName InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x8, InValue);
            CallRaw("SetVariableLinearColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B922B4 — hookable via Hooks.InstallAt(NativeFunc_SetVariableInt).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableInt => Memory.ModuleBase() + 0x5B922B4;
        public void SetVariableInt(FName InVariableName, int InValue)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, InVariableName);
            __pb.Set(0x8, InValue);
            CallRaw("SetVariableInt", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B92490 — hookable via Hooks.InstallAt(NativeFunc_SetVariableFloat).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableFloat => Memory.ModuleBase() + 0x5B92490;
        public void SetVariableFloat(FName InVariableName, float InValue)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, InVariableName);
            __pb.Set(0x8, InValue);
            CallRaw("SetVariableFloat", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B920C8 — hookable via Hooks.InstallAt(NativeFunc_SetVariableBool).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableBool => Memory.ModuleBase() + 0x5B920C8;
        public void SetVariableBool(FName InVariableName, bool InValue)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, InVariableName);
            __pb.Set<byte>(0x8, (byte)(InValue?1:0));
            CallRaw("SetVariableBool", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B91EF0 — hookable via Hooks.InstallAt(NativeFunc_SetVariableActor).</summary>
        public static global::System.IntPtr NativeFunc_SetVariableActor => Memory.ModuleBase() + 0x5B91EF0;
        public void SetVariableActor(FName InVariableName, Actor Actor)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, InVariableName);
            __pb.SetObject(0x8, Actor);
            CallRaw("SetVariableActor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9317C — hookable via Hooks.InstallAt(NativeFunc_SetSeekDelta).</summary>
        public static global::System.IntPtr NativeFunc_SetSeekDelta => Memory.ModuleBase() + 0x5B9317C;
        public void SetSeekDelta(float InSeekDelta)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InSeekDelta);
            CallRaw("SetSeekDelta", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B917D8 — hookable via Hooks.InstallAt(NativeFunc_SetRenderingEnabled).</summary>
        public static global::System.IntPtr NativeFunc_SetRenderingEnabled => Memory.ModuleBase() + 0x5B917D8;
        public void SetRenderingEnabled(bool bInRenderingEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInRenderingEnabled?1:0));
            CallRaw("SetRenderingEnabled", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9137C — hookable via Hooks.InstallAt(NativeFunc_SetPreviewLODDistance).</summary>
        public static global::System.IntPtr NativeFunc_SetPreviewLODDistance => Memory.ModuleBase() + 0x5B9137C;
        public void SetPreviewLODDistance(bool bEnablePreviewLODDistance, float PreviewLODDistance)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)(bEnablePreviewLODDistance?1:0));
            __pb.Set(0x4, PreviewLODDistance);
            CallRaw("SetPreviewLODDistance", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B91560 — hookable via Hooks.InstallAt(NativeFunc_SetPaused).</summary>
        public static global::System.IntPtr NativeFunc_SetPaused => Memory.ModuleBase() + 0x5B91560;
        public void SetPaused(bool bInPaused)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInPaused?1:0));
            CallRaw("SetPaused", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B92CF8 — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableVec4).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableVec4 => Memory.ModuleBase() + 0x5B92CF8;
        public void SetNiagaraVariableVec4(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetNiagaraVariableVec4", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9291C — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableVec3).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableVec3 => Memory.ModuleBase() + 0x5B9291C;
        public void SetNiagaraVariableVec3(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetNiagaraVariableVec3", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9274C — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableVec2).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableVec2 => Memory.ModuleBase() + 0x5B9274C;
        public void SetNiagaraVariableVec2(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetNiagaraVariableVec2", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B92B00 — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableQuat).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableQuat => Memory.ModuleBase() + 0x5B92B00;
        public void SetNiagaraVariableQuat(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetNiagaraVariableQuat", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B91DFC — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableObject).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableObject => Memory.ModuleBase() + 0x5B91DFC;
        public void SetNiagaraVariableObject(global::System.IntPtr InVariableName, Object Object)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.SetObject(0x10, Object);
            CallRaw("SetNiagaraVariableObject", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B92EF0 — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableLinearColor).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableLinearColor => Memory.ModuleBase() + 0x5B92EF0;
        public void SetNiagaraVariableLinearColor(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetNiagaraVariableLinearColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9239C — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableInt).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableInt => Memory.ModuleBase() + 0x5B9239C;
        public void SetNiagaraVariableInt(global::System.IntPtr InVariableName, int InValue)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set(0x10, InValue);
            CallRaw("SetNiagaraVariableInt", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B92578 — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableFloat).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableFloat => Memory.ModuleBase() + 0x5B92578;
        public void SetNiagaraVariableFloat(global::System.IntPtr InVariableName, float InValue)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set(0x10, InValue);
            CallRaw("SetNiagaraVariableFloat", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B921B8 — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableBool).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableBool => Memory.ModuleBase() + 0x5B921B8;
        public void SetNiagaraVariableBool(global::System.IntPtr InVariableName, bool InValue)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<byte>(0x10, (byte)(InValue?1:0));
            CallRaw("SetNiagaraVariableBool", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B91FD4 — hookable via Hooks.InstallAt(NativeFunc_SetNiagaraVariableActor).</summary>
        public static global::System.IntPtr NativeFunc_SetNiagaraVariableActor => Memory.ModuleBase() + 0x5B91FD4;
        public void SetNiagaraVariableActor(global::System.IntPtr InVariableName, Actor Actor)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.SetObject(0x10, Actor);
            CallRaw("SetNiagaraVariableActor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B930A4 — hookable via Hooks.InstallAt(NativeFunc_SetMaxSimTime).</summary>
        public static global::System.IntPtr NativeFunc_SetMaxSimTime => Memory.ModuleBase() + 0x5B930A4;
        public void SetMaxSimTime(float InMaxTime)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMaxTime);
            CallRaw("SetMaxSimTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B93574 — hookable via Hooks.InstallAt(NativeFunc_SetForceSolo).</summary>
        public static global::System.IntPtr NativeFunc_SetForceSolo => Memory.ModuleBase() + 0x5B93574;
        public void SetForceSolo(bool bInForceSolo)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInForceSolo?1:0));
            CallRaw("SetForceSolo", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B933A4 — hookable via Hooks.InstallAt(NativeFunc_SetDesiredAge).</summary>
        public static global::System.IntPtr NativeFunc_SetDesiredAge => Memory.ModuleBase() + 0x5B933A4;
        public void SetDesiredAge(float InDesiredAge)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDesiredAge);
            CallRaw("SetDesiredAge", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B93254 — hookable via Hooks.InstallAt(NativeFunc_SetCanRenderWhileSeeking).</summary>
        public static global::System.IntPtr NativeFunc_SetCanRenderWhileSeeking => Memory.ModuleBase() + 0x5B93254;
        public void SetCanRenderWhileSeeking(bool bInCanRenderWhileSeeking)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInCanRenderWhileSeeking?1:0));
            CallRaw("SetCanRenderWhileSeeking", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B92FF0 — hookable via Hooks.InstallAt(NativeFunc_SetAutoDestroy).</summary>
        public static global::System.IntPtr NativeFunc_SetAutoDestroy => Memory.ModuleBase() + 0x5B92FF0;
        public void SetAutoDestroy(bool bInAutoDestroy)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInAutoDestroy?1:0));
            CallRaw("SetAutoDestroy", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9363C — hookable via Hooks.InstallAt(NativeFunc_SetAsset).</summary>
        public static global::System.IntPtr NativeFunc_SetAsset => Memory.ModuleBase() + 0x5B9363C;
        public void SetAsset(NiagaraSystem InAsset)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InAsset);
            CallRaw("SetAsset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B912A0 — hookable via Hooks.InstallAt(NativeFunc_SetAllowScalability).</summary>
        public static global::System.IntPtr NativeFunc_SetAllowScalability => Memory.ModuleBase() + 0x5B912A0;
        public void SetAllowScalability(bool bAllow)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bAllow?1:0));
            CallRaw("SetAllowScalability", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9347C — hookable via Hooks.InstallAt(NativeFunc_SetAgeUpdateMode).</summary>
        public static global::System.IntPtr NativeFunc_SetAgeUpdateMode => Memory.ModuleBase() + 0x5B9347C;
        public void SetAgeUpdateMode(ENiagaraAgeUpdateMode InAgeUpdateMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InAgeUpdateMode);
            CallRaw("SetAgeUpdateMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B93300 — hookable via Hooks.InstallAt(NativeFunc_SeekToDesiredAge).</summary>
        public static global::System.IntPtr NativeFunc_SeekToDesiredAge => Memory.ModuleBase() + 0x5B93300;
        public void SeekToDesiredAge(float InDesiredAge)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDesiredAge);
            CallRaw("SeekToDesiredAge", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B91898 — hookable via Hooks.InstallAt(NativeFunc_ResetSystem).</summary>
        public static global::System.IntPtr NativeFunc_ResetSystem => Memory.ModuleBase() + 0x5B91898;
        public void ResetSystem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetSystem", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B91884 — hookable via Hooks.InstallAt(NativeFunc_ReinitializeSystem).</summary>
        public static global::System.IntPtr NativeFunc_ReinitializeSystem => Memory.ModuleBase() + 0x5B91884;
        public void ReinitializeSystem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReinitializeSystem", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B91528 — hookable via Hooks.InstallAt(NativeFunc_IsPaused).</summary>
        public static global::System.IntPtr NativeFunc_IsPaused => Memory.ModuleBase() + 0x5B91528;
        public bool IsPaused()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPaused", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5B93220 — hookable via Hooks.InstallAt(NativeFunc_GetSeekDelta).</summary>
        public static global::System.IntPtr NativeFunc_GetSeekDelta => Memory.ModuleBase() + 0x5B93220;
        public float GetSeekDelta()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetSeekDelta", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5B91364 — hookable via Hooks.InstallAt(NativeFunc_GetPreviewLODDistanceEnabled).</summary>
        public static global::System.IntPtr NativeFunc_GetPreviewLODDistanceEnabled => Memory.ModuleBase() + 0x5B91364;
        public bool GetPreviewLODDistanceEnabled()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetPreviewLODDistanceEnabled", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5B9134C — hookable via Hooks.InstallAt(NativeFunc_GetPreviewLODDistance).</summary>
        public static global::System.IntPtr NativeFunc_GetPreviewLODDistance => Memory.ModuleBase() + 0x5B9134C;
        public int GetPreviewLODDistance()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPreviewLODDistance", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5B918AC — hookable via Hooks.InstallAt(NativeFunc_GetNiagaraParticleValueVec3_DebugOnly).</summary>
        public static global::System.IntPtr NativeFunc_GetNiagaraParticleValueVec3_DebugOnly => Memory.ModuleBase() + 0x5B918AC;
        public global::System.IntPtr GetNiagaraParticleValueVec3_DebugOnly(global::System.IntPtr InEmitterName, global::System.IntPtr InValueName)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<global::System.IntPtr>(0x0, InEmitterName);
            __pb.Set<global::System.IntPtr>(0x10, InValueName);
            CallRaw("GetNiagaraParticleValueVec3_DebugOnly", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x20);
        }
        /// <summary>[Native] thunk RVA 0x5B919F4 — hookable via Hooks.InstallAt(NativeFunc_GetNiagaraParticleValues_DebugOnly).</summary>
        public static global::System.IntPtr NativeFunc_GetNiagaraParticleValues_DebugOnly => Memory.ModuleBase() + 0x5B919F4;
        public global::System.IntPtr GetNiagaraParticleValues_DebugOnly(global::System.IntPtr InEmitterName, global::System.IntPtr InValueName)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<global::System.IntPtr>(0x0, InEmitterName);
            __pb.Set<global::System.IntPtr>(0x10, InValueName);
            CallRaw("GetNiagaraParticleValues_DebugOnly", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x20);
        }
        /// <summary>[Native] thunk RVA 0x5B91B3C — hookable via Hooks.InstallAt(NativeFunc_GetNiagaraParticlePositions_DebugOnly).</summary>
        public static global::System.IntPtr NativeFunc_GetNiagaraParticlePositions_DebugOnly => Memory.ModuleBase() + 0x5B91B3C;
        public global::System.IntPtr GetNiagaraParticlePositions_DebugOnly(global::System.IntPtr InEmitterName)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InEmitterName);
            CallRaw("GetNiagaraParticlePositions_DebugOnly", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5B93148 — hookable via Hooks.InstallAt(NativeFunc_GetMaxSimTime).</summary>
        public static global::System.IntPtr NativeFunc_GetMaxSimTime => Memory.ModuleBase() + 0x5B93148;
        public float GetMaxSimTime()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMaxSimTime", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5B93554 — hookable via Hooks.InstallAt(NativeFunc_GetForceSolo).</summary>
        public static global::System.IntPtr NativeFunc_GetForceSolo => Memory.ModuleBase() + 0x5B93554;
        public bool GetForceSolo()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetForceSolo", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5B93448 — hookable via Hooks.InstallAt(NativeFunc_GetDesiredAge).</summary>
        public static global::System.IntPtr NativeFunc_GetDesiredAge => Memory.ModuleBase() + 0x5B93448;
        public float GetDesiredAge()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetDesiredAge", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5B91470 — hookable via Hooks.InstallAt(NativeFunc_GetDataInterface).</summary>
        public static global::System.IntPtr NativeFunc_GetDataInterface => Memory.ModuleBase() + 0x5B91470;
        public NiagaraDataInterface GetDataInterface(global::System.IntPtr Name)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Name);
            CallRaw("GetDataInterface", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new NiagaraDataInterface(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5B93620 — hookable via Hooks.InstallAt(NativeFunc_GetAsset).</summary>
        public static global::System.IntPtr NativeFunc_GetAsset => Memory.ModuleBase() + 0x5B93620;
        public NiagaraSystem GetAsset()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetAsset", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new NiagaraSystem(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5B93520 — hookable via Hooks.InstallAt(NativeFunc_GetAgeUpdateMode).</summary>
        public static global::System.IntPtr NativeFunc_GetAgeUpdateMode => Memory.ModuleBase() + 0x5B93520;
        public ENiagaraAgeUpdateMode GetAgeUpdateMode()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetAgeUpdateMode", __pb.Bytes);
            return (ENiagaraAgeUpdateMode)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5B9160C — hookable via Hooks.InstallAt(NativeFunc_AdvanceSimulationByTime).</summary>
        public static global::System.IntPtr NativeFunc_AdvanceSimulationByTime => Memory.ModuleBase() + 0x5B9160C;
        public void AdvanceSimulationByTime(float SimulateTime, float TickDeltaSeconds)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, SimulateTime);
            __pb.Set(0x4, TickDeltaSeconds);
            CallRaw("AdvanceSimulationByTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B916F0 — hookable via Hooks.InstallAt(NativeFunc_AdvanceSimulation).</summary>
        public static global::System.IntPtr NativeFunc_AdvanceSimulation => Memory.ModuleBase() + 0x5B916F0;
        public void AdvanceSimulation(int TickCount, float TickDeltaSeconds)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, TickCount);
            __pb.Set(0x4, TickDeltaSeconds);
            CallRaw("AdvanceSimulation", __pb.Bytes);
        }
    }

    public class NiagaraComponentPool : Object
    {
        public const string UeClassName = "NiagaraComponentPool";
        public NiagaraComponentPool(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraComponentPool FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraComponentPool(p);
        public static NiagaraComponentPool FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraComponentPool(o.Pointer); }
        public static NiagaraComponentPool[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraComponentPool[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraComponentPool(a[i].Pointer); return r; }
        public global::System.IntPtr WorldParticleSystemPools => AddrOf(0x28); // 
    }

    public class NiagaraConvertInPlaceUtilityBase : Object
    {
        public const string UeClassName = "NiagaraConvertInPlaceUtilityBase";
        public NiagaraConvertInPlaceUtilityBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraConvertInPlaceUtilityBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraConvertInPlaceUtilityBase(p);
        public static NiagaraConvertInPlaceUtilityBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraConvertInPlaceUtilityBase(o.Pointer); }
        public static NiagaraConvertInPlaceUtilityBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraConvertInPlaceUtilityBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraConvertInPlaceUtilityBase(a[i].Pointer); return r; }
    }

    public class NiagaraDataInterface : NiagaraDataInterfaceBase
    {
        public const string UeClassName = "NiagaraDataInterface";
        public NiagaraDataInterface(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterface FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterface(p);
        public static NiagaraDataInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterface(o.Pointer); }
        public static NiagaraDataInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterface(a[i].Pointer); return r; }
    }

    public class NiagaraDataInterfaceAudioSubmix : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceAudioSubmix";
        public NiagaraDataInterfaceAudioSubmix(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceAudioSubmix FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceAudioSubmix(p);
        public static NiagaraDataInterfaceAudioSubmix FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceAudioSubmix(o.Pointer); }
        public static NiagaraDataInterfaceAudioSubmix[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceAudioSubmix[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceAudioSubmix(a[i].Pointer); return r; }
        public SoundSubmix Submix { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new SoundSubmix(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NiagaraDataInterfaceAudioOscilloscope : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceAudioOscilloscope";
        public NiagaraDataInterfaceAudioOscilloscope(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceAudioOscilloscope FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceAudioOscilloscope(p);
        public static NiagaraDataInterfaceAudioOscilloscope FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceAudioOscilloscope(o.Pointer); }
        public static NiagaraDataInterfaceAudioOscilloscope[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceAudioOscilloscope[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceAudioOscilloscope(a[i].Pointer); return r; }
        public SoundSubmix Submix { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new SoundSubmix(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int Resolution { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
        public float ScopeInMilliseconds { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
    }

    public class NiagaraDataInterfaceAudioSpectrum : NiagaraDataInterfaceAudioSubmix
    {
        public const string UeClassName = "NiagaraDataInterfaceAudioSpectrum";
        public NiagaraDataInterfaceAudioSpectrum(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceAudioSpectrum FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceAudioSpectrum(p);
        public static NiagaraDataInterfaceAudioSpectrum FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceAudioSpectrum(o.Pointer); }
        public static NiagaraDataInterfaceAudioSpectrum[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceAudioSpectrum[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceAudioSpectrum(a[i].Pointer); return r; }
        public int Resolution { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
        public float MinimumFrequency { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public float MaximumFrequency { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public float NoiseFloorDb { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
    }

    public class NiagaraDataInterfaceCamera : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceCamera";
        public NiagaraDataInterfaceCamera(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceCamera FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceCamera(p);
        public static NiagaraDataInterfaceCamera FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceCamera(o.Pointer); }
        public static NiagaraDataInterfaceCamera[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceCamera[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceCamera(a[i].Pointer); return r; }
        public int PlayerControllerIndex { get => GetAt<int>(0x30); set => SetAt(0x30, value); }
    }

    public class NiagaraDataInterfaceCollisionQuery : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceCollisionQuery";
        public NiagaraDataInterfaceCollisionQuery(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceCollisionQuery FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceCollisionQuery(p);
        public static NiagaraDataInterfaceCollisionQuery FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceCollisionQuery(o.Pointer); }
        public static NiagaraDataInterfaceCollisionQuery[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceCollisionQuery[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceCollisionQuery(a[i].Pointer); return r; }
    }

    public class NiagaraDataInterfaceCurveBase : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceCurveBase";
        public NiagaraDataInterfaceCurveBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceCurveBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceCurveBase(p);
        public static NiagaraDataInterfaceCurveBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceCurveBase(o.Pointer); }
        public static NiagaraDataInterfaceCurveBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceCurveBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceCurveBase(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> ShaderLUT => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<float>
        public float LUTMinTime { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public float LUTMaxTime { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public float LUTInvTimeRange { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float LUTNumSamplesMinusOne { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public bool bUseLUT { get => Native.GetPropBool(Pointer, "bUseLUT"); set => Native.SetPropBool(Pointer, "bUseLUT", value); }
    }

    public class NiagaraDataInterfaceColorCurve : NiagaraDataInterfaceCurveBase
    {
        public const string UeClassName = "NiagaraDataInterfaceColorCurve";
        public NiagaraDataInterfaceColorCurve(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceColorCurve FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceColorCurve(p);
        public static NiagaraDataInterfaceColorCurve FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceColorCurve(o.Pointer); }
        public static NiagaraDataInterfaceColorCurve[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceColorCurve[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceColorCurve(a[i].Pointer); return r; }
        public RichCurve RedCurve => new RichCurve(AddrOf(0x58));
        public RichCurve GreenCurve => new RichCurve(AddrOf(0xD8));
        public RichCurve BlueCurve => new RichCurve(AddrOf(0x158));
        public RichCurve AlphaCurve => new RichCurve(AddrOf(0x1D8));
    }

    public class NiagaraDataInterfaceCurlNoise : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceCurlNoise";
        public NiagaraDataInterfaceCurlNoise(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceCurlNoise FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceCurlNoise(p);
        public static NiagaraDataInterfaceCurlNoise FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceCurlNoise(o.Pointer); }
        public static NiagaraDataInterfaceCurlNoise[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceCurlNoise[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceCurlNoise(a[i].Pointer); return r; }
        public uint Seed { get => GetAt<uint>(0x30); set => SetAt(0x30, value); }
    }

    public class NiagaraDataInterfaceCurve : NiagaraDataInterfaceCurveBase
    {
        public const string UeClassName = "NiagaraDataInterfaceCurve";
        public NiagaraDataInterfaceCurve(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceCurve FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceCurve(p);
        public static NiagaraDataInterfaceCurve FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceCurve(o.Pointer); }
        public static NiagaraDataInterfaceCurve[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceCurve[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceCurve(a[i].Pointer); return r; }
        public RichCurve Curve => new RichCurve(AddrOf(0x58));
    }

    public class NiagaraParticleCallbackHandler : Interface
    {
        public const string UeClassName = "NiagaraParticleCallbackHandler";
        public NiagaraParticleCallbackHandler(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraParticleCallbackHandler FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraParticleCallbackHandler(p);
        public static NiagaraParticleCallbackHandler FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraParticleCallbackHandler(o.Pointer); }
        public static NiagaraParticleCallbackHandler[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraParticleCallbackHandler[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraParticleCallbackHandler(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5B9B4C4 — hookable via Hooks.InstallAt(NativeFunc_ReceiveParticleData).</summary>
        public static global::System.IntPtr NativeFunc_ReceiveParticleData => Memory.ModuleBase() + 0x5B9B4C4;
        public void ReceiveParticleData(global::System.IntPtr Data, NiagaraSystem NiagaraSystem)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Data);
            __pb.SetObject(0x10, NiagaraSystem);
            CallRaw("ReceiveParticleData", __pb.Bytes);
        }
    }

    public class NiagaraDataInterfaceExport : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceExport";
        public NiagaraDataInterfaceExport(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceExport FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceExport(p);
        public static NiagaraDataInterfaceExport FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceExport(o.Pointer); }
        public static NiagaraDataInterfaceExport[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceExport[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceExport(a[i].Pointer); return r; }
        public NiagaraUserParameterBinding CallbackHandlerParameter => new NiagaraUserParameterBinding(AddrOf(0x30));
    }

    public class NiagaraDataInterfaceRWBase : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceRWBase";
        public NiagaraDataInterfaceRWBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceRWBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceRWBase(p);
        public static NiagaraDataInterfaceRWBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceRWBase(o.Pointer); }
        public static NiagaraDataInterfaceRWBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceRWBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceRWBase(a[i].Pointer); return r; }
        public global::System.IntPtr OutputShaderStages => AddrOf(0x30); // 
        public global::System.IntPtr IterationShaderStages => AddrOf(0x80); // 
    }

    public class NiagaraDataInterfaceGrid2D : NiagaraDataInterfaceRWBase
    {
        public const string UeClassName = "NiagaraDataInterfaceGrid2D";
        public NiagaraDataInterfaceGrid2D(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceGrid2D FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceGrid2D(p);
        public static NiagaraDataInterfaceGrid2D FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceGrid2D(o.Pointer); }
        public static NiagaraDataInterfaceGrid2D[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceGrid2D[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceGrid2D(a[i].Pointer); return r; }
        public int NumCellsX { get => GetAt<int>(0xD0); set => SetAt(0xD0, value); }
        public int NumCellsY { get => GetAt<int>(0xD4); set => SetAt(0xD4, value); }
        public int NumCellsMaxAxis { get => GetAt<int>(0xD8); set => SetAt(0xD8, value); }
        public int NumAttributes { get => GetAt<int>(0xDC); set => SetAt(0xDC, value); }
        public bool SetGridFromMaxAxis { get => Native.GetPropBool(Pointer, "SetGridFromMaxAxis"); set => Native.SetPropBool(Pointer, "SetGridFromMaxAxis", value); }
        public Vector2D WorldBBoxSize => new Vector2D(AddrOf(0xE4));
    }

    public class NiagaraDataInterfaceGrid2DCollection : NiagaraDataInterfaceGrid2D
    {
        public const string UeClassName = "NiagaraDataInterfaceGrid2DCollection";
        public NiagaraDataInterfaceGrid2DCollection(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceGrid2DCollection FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceGrid2DCollection(p);
        public static NiagaraDataInterfaceGrid2DCollection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceGrid2DCollection(o.Pointer); }
        public static NiagaraDataInterfaceGrid2DCollection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceGrid2DCollection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceGrid2DCollection(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5B9C700 — hookable via Hooks.InstallAt(NativeFunc_GetTextureSize).</summary>
        public static global::System.IntPtr NativeFunc_GetTextureSize => Memory.ModuleBase() + 0x5B9C700;
        public void GetTextureSize(NiagaraComponent component, int SizeX, int SizeY)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.Set(0x8, SizeX);
            __pb.Set(0xC, SizeY);
            CallRaw("GetTextureSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9C854 — hookable via Hooks.InstallAt(NativeFunc_GetRawTextureSize).</summary>
        public static global::System.IntPtr NativeFunc_GetRawTextureSize => Memory.ModuleBase() + 0x5B9C854;
        public void GetRawTextureSize(NiagaraComponent component, int SizeX, int SizeY)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.Set(0x8, SizeX);
            __pb.Set(0xC, SizeY);
            CallRaw("GetRawTextureSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5B9CB50 — hookable via Hooks.InstallAt(NativeFunc_FillTexture2D).</summary>
        public static global::System.IntPtr NativeFunc_FillTexture2D => Memory.ModuleBase() + 0x5B9CB50;
        public bool FillTexture2D(NiagaraComponent component, TextureRenderTarget2D Dest, int AttributeIndex)
        {
            var __pb = new ParamBuffer(21);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, Dest);
            __pb.Set(0x10, AttributeIndex);
            CallRaw("FillTexture2D", __pb.Bytes);
            return __pb.Get<byte>(0x14) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5B9C9A8 — hookable via Hooks.InstallAt(NativeFunc_FillRawTexture2D).</summary>
        public static global::System.IntPtr NativeFunc_FillRawTexture2D => Memory.ModuleBase() + 0x5B9C9A8;
        public bool FillRawTexture2D(NiagaraComponent component, TextureRenderTarget2D Dest, int TilesX, int TilesY)
        {
            var __pb = new ParamBuffer(25);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, Dest);
            __pb.Set(0x10, TilesX);
            __pb.Set(0x14, TilesY);
            CallRaw("FillRawTexture2D", __pb.Bytes);
            return __pb.Get<byte>(0x18) != 0;
        }
    }

    public class NiagaraDataInterfaceGrid3D : NiagaraDataInterfaceRWBase
    {
        public const string UeClassName = "NiagaraDataInterfaceGrid3D";
        public NiagaraDataInterfaceGrid3D(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceGrid3D FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceGrid3D(p);
        public static NiagaraDataInterfaceGrid3D FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceGrid3D(o.Pointer); }
        public static NiagaraDataInterfaceGrid3D[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceGrid3D[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceGrid3D(a[i].Pointer); return r; }
        public IntVector NumVoxels => new IntVector(AddrOf(0xD0));
        public float VoxelSize { get => GetAt<float>(0xDC); set => SetAt(0xDC, value); }
        public bool SetGridFromVoxelSize { get => Native.GetPropBool(Pointer, "SetGridFromVoxelSize"); set => Native.SetPropBool(Pointer, "SetGridFromVoxelSize", value); }
        public Vector WorldBBoxSize => new Vector(AddrOf(0xE4));
    }

    public class NiagaraDataInterfaceNeighborGrid3D : NiagaraDataInterfaceGrid3D
    {
        public const string UeClassName = "NiagaraDataInterfaceNeighborGrid3D";
        public NiagaraDataInterfaceNeighborGrid3D(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceNeighborGrid3D FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceNeighborGrid3D(p);
        public static NiagaraDataInterfaceNeighborGrid3D FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceNeighborGrid3D(o.Pointer); }
        public static NiagaraDataInterfaceNeighborGrid3D[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceNeighborGrid3D[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceNeighborGrid3D(a[i].Pointer); return r; }
        public uint MaxNeighborsPerVoxel { get => GetAt<uint>(0xF0); set => SetAt(0xF0, value); }
    }

    public class NiagaraDataInterfaceOcclusion : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceOcclusion";
        public NiagaraDataInterfaceOcclusion(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceOcclusion FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceOcclusion(p);
        public static NiagaraDataInterfaceOcclusion FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceOcclusion(o.Pointer); }
        public static NiagaraDataInterfaceOcclusion[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceOcclusion[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceOcclusion(a[i].Pointer); return r; }
    }

    public class NiagaraDataInterfaceParticleRead : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceParticleRead";
        public NiagaraDataInterfaceParticleRead(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceParticleRead FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceParticleRead(p);
        public static NiagaraDataInterfaceParticleRead FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceParticleRead(o.Pointer); }
        public static NiagaraDataInterfaceParticleRead[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceParticleRead[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceParticleRead(a[i].Pointer); return r; }
        public string EmitterName => Native.GetPropString(Pointer, "EmitterName"); // FString
    }

    public class NiagaraDataInterfaceSimpleCounter : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceSimpleCounter";
        public NiagaraDataInterfaceSimpleCounter(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceSimpleCounter FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceSimpleCounter(p);
        public static NiagaraDataInterfaceSimpleCounter FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceSimpleCounter(o.Pointer); }
        public static NiagaraDataInterfaceSimpleCounter[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceSimpleCounter[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceSimpleCounter(a[i].Pointer); return r; }
    }

    public class NiagaraDataInterfaceSkeletalMesh : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceSkeletalMesh";
        public NiagaraDataInterfaceSkeletalMesh(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceSkeletalMesh FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceSkeletalMesh(p);
        public static NiagaraDataInterfaceSkeletalMesh FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceSkeletalMesh(o.Pointer); }
        public static NiagaraDataInterfaceSkeletalMesh[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceSkeletalMesh[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceSkeletalMesh(a[i].Pointer); return r; }
        public Actor Source { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NiagaraUserParameterBinding MeshUserParameter => new NiagaraUserParameterBinding(AddrOf(0x38));
        public SkeletalMeshComponent SourceComponent { get { var __p = GetAt<global::System.IntPtr>(0x60); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x60, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ENDISkeletalMesh_SkinningMode SkinningMode { get => (ENDISkeletalMesh_SkinningMode)GetAt<byte>(0x68); set => SetAt(0x68, (byte)value); }
        public TArray<global::System.IntPtr> SamplingRegions => new TArray<global::System.IntPtr>(AddrOf(0x70)); // TArray<FName>
        public int WholeMeshLOD { get => GetAt<int>(0x80); set => SetAt(0x80, value); }
        public TArray<global::System.IntPtr> FilteredBones => new TArray<global::System.IntPtr>(AddrOf(0x88)); // TArray<FName>
        public TArray<global::System.IntPtr> FilteredSockets => new TArray<global::System.IntPtr>(AddrOf(0x98)); // TArray<FName>
        public string ExcludeBoneName => Native.GetPropName(Pointer, "ExcludeBoneName"); // FName
        public FName ExcludeBoneName_Raw { get => GetAt<FName>(0xA8); set => SetAt(0xA8, value); }
        public bool bExcludeBone { get => Native.GetPropBool(Pointer, "bExcludeBone"); set => Native.SetPropBool(Pointer, "bExcludeBone", value); }
    }

    public class NiagaraDataInterfaceSpline : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceSpline";
        public NiagaraDataInterfaceSpline(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceSpline FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceSpline(p);
        public static NiagaraDataInterfaceSpline FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceSpline(o.Pointer); }
        public static NiagaraDataInterfaceSpline[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceSpline[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceSpline(a[i].Pointer); return r; }
        public Actor Source { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NiagaraDataInterfaceStaticMesh : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceStaticMesh";
        public NiagaraDataInterfaceStaticMesh(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceStaticMesh FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceStaticMesh(p);
        public static NiagaraDataInterfaceStaticMesh FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceStaticMesh(o.Pointer); }
        public static NiagaraDataInterfaceStaticMesh[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceStaticMesh[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceStaticMesh(a[i].Pointer); return r; }
        public StaticMesh DefaultMesh { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor Source { get { var __p = GetAt<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x38, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent SourceComponent { get { var __p = GetAt<global::System.IntPtr>(0x40); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x40, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NDIStaticMeshSectionFilter SectionFilter => new NDIStaticMeshSectionFilter(AddrOf(0x48));
    }

    public class NiagaraDataInterfaceTexture : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceTexture";
        public NiagaraDataInterfaceTexture(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceTexture FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceTexture(p);
        public static NiagaraDataInterfaceTexture FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceTexture(o.Pointer); }
        public static NiagaraDataInterfaceTexture[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceTexture[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceTexture(a[i].Pointer); return r; }
        public Texture Texture { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new Texture(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NiagaraDataInterfaceVector2DCurve : NiagaraDataInterfaceCurveBase
    {
        public const string UeClassName = "NiagaraDataInterfaceVector2DCurve";
        public NiagaraDataInterfaceVector2DCurve(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceVector2DCurve FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceVector2DCurve(p);
        public static NiagaraDataInterfaceVector2DCurve FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceVector2DCurve(o.Pointer); }
        public static NiagaraDataInterfaceVector2DCurve[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceVector2DCurve[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceVector2DCurve(a[i].Pointer); return r; }
        public RichCurve XCurve => new RichCurve(AddrOf(0x58));
        public RichCurve YCurve => new RichCurve(AddrOf(0xD8));
    }

    public class NiagaraDataInterfaceVector4Curve : NiagaraDataInterfaceCurveBase
    {
        public const string UeClassName = "NiagaraDataInterfaceVector4Curve";
        public NiagaraDataInterfaceVector4Curve(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceVector4Curve FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceVector4Curve(p);
        public static NiagaraDataInterfaceVector4Curve FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceVector4Curve(o.Pointer); }
        public static NiagaraDataInterfaceVector4Curve[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceVector4Curve[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceVector4Curve(a[i].Pointer); return r; }
        public RichCurve XCurve => new RichCurve(AddrOf(0x58));
        public RichCurve YCurve => new RichCurve(AddrOf(0xD8));
        public RichCurve ZCurve => new RichCurve(AddrOf(0x158));
        public RichCurve WCurve => new RichCurve(AddrOf(0x1D8));
    }

    public class NiagaraDataInterfaceVectorCurve : NiagaraDataInterfaceCurveBase
    {
        public const string UeClassName = "NiagaraDataInterfaceVectorCurve";
        public NiagaraDataInterfaceVectorCurve(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceVectorCurve FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceVectorCurve(p);
        public static NiagaraDataInterfaceVectorCurve FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceVectorCurve(o.Pointer); }
        public static NiagaraDataInterfaceVectorCurve[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceVectorCurve[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceVectorCurve(a[i].Pointer); return r; }
        public RichCurve XCurve => new RichCurve(AddrOf(0x58));
        public RichCurve YCurve => new RichCurve(AddrOf(0xD8));
        public RichCurve ZCurve => new RichCurve(AddrOf(0x158));
    }

    public class NiagaraDataInterfaceVectorField : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceVectorField";
        public NiagaraDataInterfaceVectorField(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceVectorField FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceVectorField(p);
        public static NiagaraDataInterfaceVectorField FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceVectorField(o.Pointer); }
        public static NiagaraDataInterfaceVectorField[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceVectorField[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceVectorField(a[i].Pointer); return r; }
        public VectorField Field { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new VectorField(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bTileX { get => Native.GetPropBool(Pointer, "bTileX"); set => Native.SetPropBool(Pointer, "bTileX", value); }
        public bool bTileY { get => Native.GetPropBool(Pointer, "bTileY"); set => Native.SetPropBool(Pointer, "bTileY", value); }
        public bool bTileZ { get => Native.GetPropBool(Pointer, "bTileZ"); set => Native.SetPropBool(Pointer, "bTileZ", value); }
    }

    public class NiagaraDataInterfaceVolumeTexture : NiagaraDataInterface
    {
        public const string UeClassName = "NiagaraDataInterfaceVolumeTexture";
        public NiagaraDataInterfaceVolumeTexture(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceVolumeTexture FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceVolumeTexture(p);
        public static NiagaraDataInterfaceVolumeTexture FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceVolumeTexture(o.Pointer); }
        public static NiagaraDataInterfaceVolumeTexture[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceVolumeTexture[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceVolumeTexture(a[i].Pointer); return r; }
        public VolumeTexture Texture { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new VolumeTexture(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NiagaraEditorDataBase : Object
    {
        public const string UeClassName = "NiagaraEditorDataBase";
        public NiagaraEditorDataBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraEditorDataBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraEditorDataBase(p);
        public static NiagaraEditorDataBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraEditorDataBase(o.Pointer); }
        public static NiagaraEditorDataBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraEditorDataBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraEditorDataBase(a[i].Pointer); return r; }
    }

    public class NiagaraEffectType : Object
    {
        public const string UeClassName = "NiagaraEffectType";
        public NiagaraEffectType(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraEffectType FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraEffectType(p);
        public static NiagaraEffectType FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraEffectType(o.Pointer); }
        public static NiagaraEffectType[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraEffectType[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraEffectType(a[i].Pointer); return r; }
        public ENiagaraScalabilityUpdateFrequency UpdateFrequency { get => (ENiagaraScalabilityUpdateFrequency)GetAt<int>(0x28); set => SetAt(0x28, (int)value); }
        public ENiagaraCullReaction CullReaction { get => (ENiagaraCullReaction)GetAt<int>(0x2C); set => SetAt(0x2C, (int)value); }
        public TArray<global::System.IntPtr> DetailLevelScalabilitySettings => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public NiagaraSystemScalabilitySettingsArray SystemScalabilitySettings => new NiagaraSystemScalabilitySettingsArray(AddrOf(0x40));
        public NiagaraEmitterScalabilitySettingsArray EmitterScalabilitySettings => new NiagaraEmitterScalabilitySettingsArray(AddrOf(0x50));
    }

    public class NiagaraEmitter : Object
    {
        public const string UeClassName = "NiagaraEmitter";
        public NiagaraEmitter(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraEmitter FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraEmitter(p);
        public static NiagaraEmitter FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraEmitter(o.Pointer); }
        public static NiagaraEmitter[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraEmitter[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraEmitter(a[i].Pointer); return r; }
        public bool bLocalSpace { get => Native.GetPropBool(Pointer, "bLocalSpace"); set => Native.SetPropBool(Pointer, "bLocalSpace", value); }
        public bool bDeterminism { get => Native.GetPropBool(Pointer, "bDeterminism"); set => Native.SetPropBool(Pointer, "bDeterminism", value); }
        public int RandomSeed { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public EParticleAllocationMode AllocationMode { get => (EParticleAllocationMode)GetAt<byte>(0x30); set => SetAt(0x30, (byte)value); }
        public int PreAllocationCount { get => GetAt<int>(0x34); set => SetAt(0x34, value); }
        public NiagaraEmitterScriptProperties UpdateScriptProps => new NiagaraEmitterScriptProperties(AddrOf(0x38));
        public NiagaraEmitterScriptProperties SpawnScriptProps => new NiagaraEmitterScriptProperties(AddrOf(0x60));
        public NiagaraEmitterScriptProperties EmitterSpawnScriptProps => new NiagaraEmitterScriptProperties(AddrOf(0x88));
        public NiagaraEmitterScriptProperties EmitterUpdateScriptProps => new NiagaraEmitterScriptProperties(AddrOf(0xB0));
        public ENiagaraSimTarget SimTarget { get => (ENiagaraSimTarget)GetAt<byte>(0xD8); set => SetAt(0xD8, (byte)value); }
        public Box FixedBounds => new Box(AddrOf(0xDC));
        public int MinDetailLevel { get => GetAt<int>(0xF8); set => SetAt(0xF8, value); }
        public int MaxDetailLevel { get => GetAt<int>(0xFC); set => SetAt(0xFC, value); }
        public NiagaraDetailsLevelScaleOverrides GlobalSpawnCountScaleOverrides => new NiagaraDetailsLevelScaleOverrides(AddrOf(0x100));
        public NiagaraPlatformSet Platforms => new NiagaraPlatformSet(AddrOf(0x118));
        public NiagaraEmitterScalabilityOverrides ScalabilityOverrides => new NiagaraEmitterScalabilityOverrides(AddrOf(0x138));
        public bool bInterpolatedSpawning { get => Native.GetPropBool(Pointer, "bInterpolatedSpawning"); set => Native.SetPropBool(Pointer, "bInterpolatedSpawning", value); }
        public bool bFixedBounds { get => Native.GetPropBool(Pointer, "bFixedBounds"); set => Native.SetPropBool(Pointer, "bFixedBounds", value); }
        public bool bUseMinDetailLevel { get => Native.GetPropBool(Pointer, "bUseMinDetailLevel"); set => Native.SetPropBool(Pointer, "bUseMinDetailLevel", value); }
        public bool bUseMaxDetailLevel { get => Native.GetPropBool(Pointer, "bUseMaxDetailLevel"); set => Native.SetPropBool(Pointer, "bUseMaxDetailLevel", value); }
        public bool bOverrideGlobalSpawnCountScale { get => Native.GetPropBool(Pointer, "bOverrideGlobalSpawnCountScale"); set => Native.SetPropBool(Pointer, "bOverrideGlobalSpawnCountScale", value); }
        public bool bRequiresPersistentIDs { get => Native.GetPropBool(Pointer, "bRequiresPersistentIDs"); set => Native.SetPropBool(Pointer, "bRequiresPersistentIDs", value); }
        public float MaxDeltaTimePerTick { get => GetAt<float>(0x14C); set => SetAt(0x14C, value); }
        public uint DefaultShaderStageIndex { get => GetAt<uint>(0x150); set => SetAt(0x150, value); }
        public uint MaxUpdateIterations { get => GetAt<uint>(0x154); set => SetAt(0x154, value); }
        public global::System.IntPtr SpawnStages => AddrOf(0x158); // 
        public bool bSimulationStagesEnabled { get => Native.GetPropBool(Pointer, "bSimulationStagesEnabled"); set => Native.SetPropBool(Pointer, "bSimulationStagesEnabled", value); }
        public bool bDeprecatedShaderStagesEnabled { get => Native.GetPropBool(Pointer, "bDeprecatedShaderStagesEnabled"); set => Native.SetPropBool(Pointer, "bDeprecatedShaderStagesEnabled", value); }
        public bool bLimitDeltaTime { get => Native.GetPropBool(Pointer, "bLimitDeltaTime"); set => Native.SetPropBool(Pointer, "bLimitDeltaTime", value); }
        public string UniqueEmitterName => Native.GetPropString(Pointer, "UniqueEmitterName"); // FString
        public TArray<global::System.IntPtr> RendererProperties => new TArray<global::System.IntPtr>(AddrOf(0x1C0)); // TArray<UObject*>
        public TArray<global::System.IntPtr> EventHandlerScriptProps => new TArray<global::System.IntPtr>(AddrOf(0x1D0)); // TArray<struct>
        public TArray<global::System.IntPtr> SimulationStages => new TArray<global::System.IntPtr>(AddrOf(0x1E0)); // TArray<UObject*>
        public NiagaraScript GPUComputeScript { get { var __p = GetAt<global::System.IntPtr>(0x1F0); return __p==global::System.IntPtr.Zero?null:new NiagaraScript(__p); } set => SetAt(0x1F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> SharedEventGeneratorIds => new TArray<global::System.IntPtr>(AddrOf(0x1F8)); // TArray<FName>
    }

    public class NiagaraEventReceiverEmitterAction : Object
    {
        public const string UeClassName = "NiagaraEventReceiverEmitterAction";
        public NiagaraEventReceiverEmitterAction(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraEventReceiverEmitterAction FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraEventReceiverEmitterAction(p);
        public static NiagaraEventReceiverEmitterAction FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraEventReceiverEmitterAction(o.Pointer); }
        public static NiagaraEventReceiverEmitterAction[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraEventReceiverEmitterAction[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraEventReceiverEmitterAction(a[i].Pointer); return r; }
    }

    public class NiagaraEventReceiverEmitterAction_SpawnParticles : NiagaraEventReceiverEmitterAction
    {
        public const string UeClassName = "NiagaraEventReceiverEmitterAction_SpawnParticles";
        public NiagaraEventReceiverEmitterAction_SpawnParticles(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraEventReceiverEmitterAction_SpawnParticles FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraEventReceiverEmitterAction_SpawnParticles(p);
        public static NiagaraEventReceiverEmitterAction_SpawnParticles FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraEventReceiverEmitterAction_SpawnParticles(o.Pointer); }
        public static NiagaraEventReceiverEmitterAction_SpawnParticles[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraEventReceiverEmitterAction_SpawnParticles[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraEventReceiverEmitterAction_SpawnParticles(a[i].Pointer); return r; }
        public uint NumParticles { get => GetAt<uint>(0x28); set => SetAt(0x28, value); }
    }

    public class NiagaraFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "NiagaraFunctionLibrary";
        public NiagaraFunctionLibrary(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraFunctionLibrary FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraFunctionLibrary(p);
        public static NiagaraFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraFunctionLibrary(o.Pointer); }
        public static NiagaraFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5BADB90 — hookable via Hooks.InstallAt(NativeFunc_SpawnSystemAttached).</summary>
        public static global::System.IntPtr NativeFunc_SpawnSystemAttached => Memory.ModuleBase() + 0x5BADB90;
        public NiagaraComponent SpawnSystemAttached(NiagaraSystem SystemTemplate, SceneComponent AttachToComponent, FName AttachPointName, global::System.IntPtr Location, global::System.IntPtr Rotation, byte LocationType, bool bAutoDestroy, bool bAutoActivate, ENCPoolMethod PoolingMethod, bool bPreCullCheck)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, SystemTemplate);
            __pb.SetObject(0x8, AttachToComponent);
            __pb.Set(0x10, AttachPointName);
            __pb.Set<global::System.IntPtr>(0x18, Location);
            __pb.Set<global::System.IntPtr>(0x24, Rotation);
            __pb.Set(0x30, LocationType);
            __pb.Set<byte>(0x31, (byte)(bAutoDestroy?1:0));
            __pb.Set<byte>(0x32, (byte)(bAutoActivate?1:0));
            __pb.Set<byte>(0x33, (byte)PoolingMethod);
            __pb.Set<byte>(0x34, (byte)(bPreCullCheck?1:0));
            CallRaw("SpawnSystemAttached", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new NiagaraComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5BADEB4 — hookable via Hooks.InstallAt(NativeFunc_SpawnSystemAtLocation).</summary>
        public static global::System.IntPtr NativeFunc_SpawnSystemAtLocation => Memory.ModuleBase() + 0x5BADEB4;
        public NiagaraComponent SpawnSystemAtLocation(Object WorldContextObject, NiagaraSystem SystemTemplate, global::System.IntPtr Location, global::System.IntPtr Rotation, global::System.IntPtr Scale, bool bAutoDestroy, bool bAutoActivate, ENCPoolMethod PoolingMethod, bool bPreCullCheck)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SystemTemplate);
            __pb.Set<global::System.IntPtr>(0x10, Location);
            __pb.Set<global::System.IntPtr>(0x1C, Rotation);
            __pb.Set<global::System.IntPtr>(0x28, Scale);
            __pb.Set<byte>(0x34, (byte)(bAutoDestroy?1:0));
            __pb.Set<byte>(0x35, (byte)(bAutoActivate?1:0));
            __pb.Set<byte>(0x36, (byte)PoolingMethod);
            __pb.Set<byte>(0x37, (byte)(bPreCullCheck?1:0));
            CallRaw("SpawnSystemAtLocation", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new NiagaraComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5BAD5C8 — hookable via Hooks.InstallAt(NativeFunc_SetVolumeTextureObject).</summary>
        public static global::System.IntPtr NativeFunc_SetVolumeTextureObject => Memory.ModuleBase() + 0x5BAD5C8;
        public void SetVolumeTextureObject(NiagaraComponent NiagaraSystem, global::System.IntPtr OverrideName, VolumeTexture Texture)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, NiagaraSystem);
            __pb.Set<global::System.IntPtr>(0x8, OverrideName);
            __pb.SetObject(0x18, Texture);
            CallRaw("SetVolumeTextureObject", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BAD6F0 — hookable via Hooks.InstallAt(NativeFunc_SetTextureObject).</summary>
        public static global::System.IntPtr NativeFunc_SetTextureObject => Memory.ModuleBase() + 0x5BAD6F0;
        public void SetTextureObject(NiagaraComponent NiagaraSystem, global::System.IntPtr OverrideName, Texture Texture)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, NiagaraSystem);
            __pb.Set<global::System.IntPtr>(0x8, OverrideName);
            __pb.SetObject(0x18, Texture);
            CallRaw("SetTextureObject", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BADA68 — hookable via Hooks.InstallAt(NativeFunc_OverrideSystemUserVariableStaticMeshComponent).</summary>
        public static global::System.IntPtr NativeFunc_OverrideSystemUserVariableStaticMeshComponent => Memory.ModuleBase() + 0x5BADA68;
        public void OverrideSystemUserVariableStaticMeshComponent(NiagaraComponent NiagaraSystem, global::System.IntPtr OverrideName, StaticMeshComponent StaticMeshComponent)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, NiagaraSystem);
            __pb.Set<global::System.IntPtr>(0x8, OverrideName);
            __pb.SetObject(0x18, StaticMeshComponent);
            CallRaw("OverrideSystemUserVariableStaticMeshComponent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BAD940 — hookable via Hooks.InstallAt(NativeFunc_OverrideSystemUserVariableStaticMesh).</summary>
        public static global::System.IntPtr NativeFunc_OverrideSystemUserVariableStaticMesh => Memory.ModuleBase() + 0x5BAD940;
        public void OverrideSystemUserVariableStaticMesh(NiagaraComponent NiagaraSystem, global::System.IntPtr OverrideName, StaticMesh StaticMesh)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, NiagaraSystem);
            __pb.Set<global::System.IntPtr>(0x8, OverrideName);
            __pb.SetObject(0x18, StaticMesh);
            CallRaw("OverrideSystemUserVariableStaticMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BAD818 — hookable via Hooks.InstallAt(NativeFunc_OverrideSystemUserVariableSkeletalMeshComponent).</summary>
        public static global::System.IntPtr NativeFunc_OverrideSystemUserVariableSkeletalMeshComponent => Memory.ModuleBase() + 0x5BAD818;
        public void OverrideSystemUserVariableSkeletalMeshComponent(NiagaraComponent NiagaraSystem, global::System.IntPtr OverrideName, SkeletalMeshComponent SkeletalMeshComponent)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, NiagaraSystem);
            __pb.Set<global::System.IntPtr>(0x8, OverrideName);
            __pb.SetObject(0x18, SkeletalMeshComponent);
            CallRaw("OverrideSystemUserVariableSkeletalMeshComponent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BAD4E4 — hookable via Hooks.InstallAt(NativeFunc_GetNiagaraParameterCollection).</summary>
        public static global::System.IntPtr NativeFunc_GetNiagaraParameterCollection => Memory.ModuleBase() + 0x5BAD4E4;
        public NiagaraParameterCollectionInstance GetNiagaraParameterCollection(Object WorldContextObject, NiagaraParameterCollection Collection)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, Collection);
            CallRaw("GetNiagaraParameterCollection", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new NiagaraParameterCollectionInstance(__p); }
        }
    }

    public class NiagaraRendererProperties : NiagaraMergeable
    {
        public const string UeClassName = "NiagaraRendererProperties";
        public NiagaraRendererProperties(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraRendererProperties FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraRendererProperties(p);
        public static NiagaraRendererProperties FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraRendererProperties(o.Pointer); }
        public static NiagaraRendererProperties[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraRendererProperties[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraRendererProperties(a[i].Pointer); return r; }
        public int SortOrderHint { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public bool bIsEnabled { get => Native.GetPropBool(Pointer, "bIsEnabled"); set => Native.SetPropBool(Pointer, "bIsEnabled", value); }
        public bool bMotionBlurEnabled { get => Native.GetPropBool(Pointer, "bMotionBlurEnabled"); set => Native.SetPropBool(Pointer, "bMotionBlurEnabled", value); }
    }

    public class NiagaraLightRendererProperties : NiagaraRendererProperties
    {
        public const string UeClassName = "NiagaraLightRendererProperties";
        public NiagaraLightRendererProperties(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraLightRendererProperties FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraLightRendererProperties(p);
        public static NiagaraLightRendererProperties FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraLightRendererProperties(o.Pointer); }
        public static NiagaraLightRendererProperties[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraLightRendererProperties[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraLightRendererProperties(a[i].Pointer); return r; }
        public bool bUseInverseSquaredFalloff { get => Native.GetPropBool(Pointer, "bUseInverseSquaredFalloff"); set => Native.SetPropBool(Pointer, "bUseInverseSquaredFalloff", value); }
        public bool bAffectsTranslucency { get => Native.GetPropBool(Pointer, "bAffectsTranslucency"); set => Native.SetPropBool(Pointer, "bAffectsTranslucency", value); }
        public bool bOverrideRenderingEnabled { get => Native.GetPropBool(Pointer, "bOverrideRenderingEnabled"); set => Native.SetPropBool(Pointer, "bOverrideRenderingEnabled", value); }
        public float RadiusScale { get => GetAt<float>(0x54); set => SetAt(0x54, value); }
        public Vector ColorAdd => new Vector(AddrOf(0x58));
        public NiagaraVariableAttributeBinding LightRenderingEnabledBinding => new NiagaraVariableAttributeBinding(AddrOf(0x68));
        public NiagaraVariableAttributeBinding LightExponentBinding => new NiagaraVariableAttributeBinding(AddrOf(0xE0));
        public NiagaraVariableAttributeBinding PositionBinding => new NiagaraVariableAttributeBinding(AddrOf(0x158));
        public NiagaraVariableAttributeBinding ColorBinding => new NiagaraVariableAttributeBinding(AddrOf(0x1D0));
        public NiagaraVariableAttributeBinding RadiusBinding => new NiagaraVariableAttributeBinding(AddrOf(0x248));
        public NiagaraVariableAttributeBinding VolumetricScatteringBinding => new NiagaraVariableAttributeBinding(AddrOf(0x2C0));
    }

    public class NiagaraMeshRendererProperties : NiagaraRendererProperties
    {
        public const string UeClassName = "NiagaraMeshRendererProperties";
        public NiagaraMeshRendererProperties(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraMeshRendererProperties FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraMeshRendererProperties(p);
        public static NiagaraMeshRendererProperties FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraMeshRendererProperties(o.Pointer); }
        public static NiagaraMeshRendererProperties[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraMeshRendererProperties[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraMeshRendererProperties(a[i].Pointer); return r; }
        public StaticMesh ParticleMesh { get { var __p = GetAt<global::System.IntPtr>(0x50); return __p==global::System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x50, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ENiagaraSortMode SortMode { get => (ENiagaraSortMode)GetAt<byte>(0x58); set => SetAt(0x58, (byte)value); }
        public bool bOverrideMaterials { get => Native.GetPropBool(Pointer, "bOverrideMaterials"); set => Native.SetPropBool(Pointer, "bOverrideMaterials", value); }
        public bool bSortOnlyWhenTranslucent { get => Native.GetPropBool(Pointer, "bSortOnlyWhenTranslucent"); set => Native.SetPropBool(Pointer, "bSortOnlyWhenTranslucent", value); }
        public TArray<global::System.IntPtr> OverrideMaterials => new TArray<global::System.IntPtr>(AddrOf(0x60)); // TArray<struct>
        public Vector2D SubImageSize => new Vector2D(AddrOf(0x70));
        public bool bSubImageBlend { get => Native.GetPropBool(Pointer, "bSubImageBlend"); set => Native.SetPropBool(Pointer, "bSubImageBlend", value); }
        public ENiagaraMeshFacingMode FacingMode { get => (ENiagaraMeshFacingMode)GetAt<byte>(0x79); set => SetAt(0x79, (byte)value); }
        public bool bLockedAxisEnable { get => Native.GetPropBool(Pointer, "bLockedAxisEnable"); set => Native.SetPropBool(Pointer, "bLockedAxisEnable", value); }
        public Vector LockedAxis => new Vector(AddrOf(0x7C));
        public ENiagaraMeshLockedAxisSpace LockedAxisSpace { get => (ENiagaraMeshLockedAxisSpace)GetAt<byte>(0x88); set => SetAt(0x88, (byte)value); }
        public NiagaraVariableAttributeBinding PositionBinding => new NiagaraVariableAttributeBinding(AddrOf(0x90));
        public NiagaraVariableAttributeBinding ColorBinding => new NiagaraVariableAttributeBinding(AddrOf(0x108));
        public NiagaraVariableAttributeBinding VelocityBinding => new NiagaraVariableAttributeBinding(AddrOf(0x180));
        public NiagaraVariableAttributeBinding MeshOrientationBinding => new NiagaraVariableAttributeBinding(AddrOf(0x1F8));
        public NiagaraVariableAttributeBinding ScaleBinding => new NiagaraVariableAttributeBinding(AddrOf(0x270));
        public NiagaraVariableAttributeBinding SubImageIndexBinding => new NiagaraVariableAttributeBinding(AddrOf(0x2E8));
        public NiagaraVariableAttributeBinding DynamicMaterialBinding => new NiagaraVariableAttributeBinding(AddrOf(0x360));
        public NiagaraVariableAttributeBinding DynamicMaterial1Binding => new NiagaraVariableAttributeBinding(AddrOf(0x3D8));
        public NiagaraVariableAttributeBinding DynamicMaterial2Binding => new NiagaraVariableAttributeBinding(AddrOf(0x450));
        public NiagaraVariableAttributeBinding DynamicMaterial3Binding => new NiagaraVariableAttributeBinding(AddrOf(0x4C8));
        public NiagaraVariableAttributeBinding MaterialRandomBinding => new NiagaraVariableAttributeBinding(AddrOf(0x540));
        public NiagaraVariableAttributeBinding CustomSortingBinding => new NiagaraVariableAttributeBinding(AddrOf(0x5B8));
        public NiagaraVariableAttributeBinding NormalizedAgeBinding => new NiagaraVariableAttributeBinding(AddrOf(0x630));
        public NiagaraVariableAttributeBinding CameraOffsetBinding => new NiagaraVariableAttributeBinding(AddrOf(0x6A8));
    }

    public class NiagaraParameterCollectionInstance : Object
    {
        public const string UeClassName = "NiagaraParameterCollectionInstance";
        public NiagaraParameterCollectionInstance(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraParameterCollectionInstance FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraParameterCollectionInstance(p);
        public static NiagaraParameterCollectionInstance FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraParameterCollectionInstance(o.Pointer); }
        public static NiagaraParameterCollectionInstance[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraParameterCollectionInstance[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraParameterCollectionInstance(a[i].Pointer); return r; }
        public NiagaraParameterCollection Collection { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new NiagaraParameterCollection(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> OverridenParameters => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public NiagaraParameterStore ParameterStorage => new NiagaraParameterStore(AddrOf(0x40));
        /// <summary>[Native] thunk RVA 0x5BB10C8 — hookable via Hooks.InstallAt(NativeFunc_SetVectorParameter).</summary>
        public static global::System.IntPtr NativeFunc_SetVectorParameter => Memory.ModuleBase() + 0x5BB10C8;
        public void SetVectorParameter(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetVectorParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB0FC4 — hookable via Hooks.InstallAt(NativeFunc_SetVector4Parameter).</summary>
        public static global::System.IntPtr NativeFunc_SetVector4Parameter => Memory.ModuleBase() + 0x5BB0FC4;
        public void SetVector4Parameter(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetVector4Parameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB11B8 — hookable via Hooks.InstallAt(NativeFunc_SetVector2DParameter).</summary>
        public static global::System.IntPtr NativeFunc_SetVector2DParameter => Memory.ModuleBase() + 0x5BB11B8;
        public void SetVector2DParameter(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetVector2DParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB0DD4 — hookable via Hooks.InstallAt(NativeFunc_SetQuatParameter).</summary>
        public static global::System.IntPtr NativeFunc_SetQuatParameter => Memory.ModuleBase() + 0x5BB0DD4;
        public void SetQuatParameter(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetQuatParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB12A4 — hookable via Hooks.InstallAt(NativeFunc_SetIntParameter).</summary>
        public static global::System.IntPtr NativeFunc_SetIntParameter => Memory.ModuleBase() + 0x5BB12A4;
        public void SetIntParameter(global::System.IntPtr InVariableName, int InValue)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set(0x10, InValue);
            CallRaw("SetIntParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB1398 — hookable via Hooks.InstallAt(NativeFunc_SetFloatParameter).</summary>
        public static global::System.IntPtr NativeFunc_SetFloatParameter => Memory.ModuleBase() + 0x5BB1398;
        public void SetFloatParameter(global::System.IntPtr InVariableName, float InValue)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set(0x10, InValue);
            CallRaw("SetFloatParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB0ED4 — hookable via Hooks.InstallAt(NativeFunc_SetColorParameter).</summary>
        public static global::System.IntPtr NativeFunc_SetColorParameter => Memory.ModuleBase() + 0x5BB0ED4;
        public void SetColorParameter(global::System.IntPtr InVariableName, global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<global::System.IntPtr>(0x10, InValue);
            CallRaw("SetColorParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB148C — hookable via Hooks.InstallAt(NativeFunc_SetBoolParameter).</summary>
        public static global::System.IntPtr NativeFunc_SetBoolParameter => Memory.ModuleBase() + 0x5BB148C;
        public void SetBoolParameter(global::System.IntPtr InVariableName, bool InValue)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            __pb.Set<byte>(0x10, (byte)(InValue?1:0));
            CallRaw("SetBoolParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB17BC — hookable via Hooks.InstallAt(NativeFunc_GetVectorParameter).</summary>
        public static global::System.IntPtr NativeFunc_GetVectorParameter => Memory.ModuleBase() + 0x5BB17BC;
        public global::System.IntPtr GetVectorParameter(global::System.IntPtr InVariableName)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            CallRaw("GetVectorParameter", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5BB1700 — hookable via Hooks.InstallAt(NativeFunc_GetVector4Parameter).</summary>
        public static global::System.IntPtr NativeFunc_GetVector4Parameter => Memory.ModuleBase() + 0x5BB1700;
        public global::System.IntPtr GetVector4Parameter(global::System.IntPtr InVariableName)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            CallRaw("GetVector4Parameter", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5BB1878 — hookable via Hooks.InstallAt(NativeFunc_GetVector2DParameter).</summary>
        public static global::System.IntPtr NativeFunc_GetVector2DParameter => Memory.ModuleBase() + 0x5BB1878;
        public global::System.IntPtr GetVector2DParameter(global::System.IntPtr InVariableName)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            CallRaw("GetVector2DParameter", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5BB1644 — hookable via Hooks.InstallAt(NativeFunc_GetQuatParameter).</summary>
        public static global::System.IntPtr NativeFunc_GetQuatParameter => Memory.ModuleBase() + 0x5BB1644;
        public global::System.IntPtr GetQuatParameter(global::System.IntPtr InVariableName)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            CallRaw("GetQuatParameter", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5BB1930 — hookable via Hooks.InstallAt(NativeFunc_GetIntParameter).</summary>
        public static global::System.IntPtr NativeFunc_GetIntParameter => Memory.ModuleBase() + 0x5BB1930;
        public int GetIntParameter(global::System.IntPtr InVariableName)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            CallRaw("GetIntParameter", __pb.Bytes);
            return __pb.Get<int>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5BB19E8 — hookable via Hooks.InstallAt(NativeFunc_GetFloatParameter).</summary>
        public static global::System.IntPtr NativeFunc_GetFloatParameter => Memory.ModuleBase() + 0x5BB19E8;
        public float GetFloatParameter(global::System.IntPtr InVariableName)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            CallRaw("GetFloatParameter", __pb.Bytes);
            return __pb.Get<float>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5BB1588 — hookable via Hooks.InstallAt(NativeFunc_GetColorParameter).</summary>
        public static global::System.IntPtr NativeFunc_GetColorParameter => Memory.ModuleBase() + 0x5BB1588;
        public global::System.IntPtr GetColorParameter(global::System.IntPtr InVariableName)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            CallRaw("GetColorParameter", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5BB1AA0 — hookable via Hooks.InstallAt(NativeFunc_GetBoolParameter).</summary>
        public static global::System.IntPtr NativeFunc_GetBoolParameter => Memory.ModuleBase() + 0x5BB1AA0;
        public bool GetBoolParameter(global::System.IntPtr InVariableName)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, InVariableName);
            CallRaw("GetBoolParameter", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
    }

    public class NiagaraParameterCollection : Object
    {
        public const string UeClassName = "NiagaraParameterCollection";
        public NiagaraParameterCollection(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraParameterCollection FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraParameterCollection(p);
        public static NiagaraParameterCollection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraParameterCollection(o.Pointer); }
        public static NiagaraParameterCollection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraParameterCollection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraParameterCollection(a[i].Pointer); return r; }
        public string Namespace => Native.GetPropName(Pointer, "Namespace"); // FName
        public FName Namespace_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
        public TArray<global::System.IntPtr> Parameters => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public NiagaraParameterCollectionInstance DefaultInstance { get { var __p = GetAt<global::System.IntPtr>(0x40); return __p==global::System.IntPtr.Zero?null:new NiagaraParameterCollectionInstance(__p); } set => SetAt(0x40, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Guid CompileId => new Guid(AddrOf(0x48));
    }

    public class NiagaraPrecompileContainer : Object
    {
        public const string UeClassName = "NiagaraPrecompileContainer";
        public NiagaraPrecompileContainer(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPrecompileContainer FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPrecompileContainer(p);
        public static NiagaraPrecompileContainer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPrecompileContainer(o.Pointer); }
        public static NiagaraPrecompileContainer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPrecompileContainer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPrecompileContainer(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Scripts => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<UObject*>
        public NiagaraSystem System { get { var __p = GetAt<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new NiagaraSystem(__p); } set => SetAt(0x38, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NiagaraPreviewBase : Actor
    {
        public const string UeClassName = "NiagaraPreviewBase";
        public NiagaraPreviewBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewBase(p);
        public static NiagaraPreviewBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewBase(o.Pointer); }
        public static NiagaraPreviewBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewBase(a[i].Pointer); return r; }
        public void SetSystem(NiagaraSystem InSystem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InSystem);
            CallRaw("SetSystem", __pb.Bytes);
        }
        public void SetLabelText(global::System.IntPtr InXAxisText, global::System.IntPtr InYAxisText)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<global::System.IntPtr>(0x0, InXAxisText);
            __pb.Set<global::System.IntPtr>(0x18, InYAxisText);
            CallRaw("SetLabelText", __pb.Bytes);
        }
    }

    public class NiagaraPreviewAxis : Object
    {
        public const string UeClassName = "NiagaraPreviewAxis";
        public NiagaraPreviewAxis(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewAxis FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis(p);
        public static NiagaraPreviewAxis FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewAxis(o.Pointer); }
        public static NiagaraPreviewAxis[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewAxis[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewAxis(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5BB66A8 — hookable via Hooks.InstallAt(NativeFunc_Num).</summary>
        public static global::System.IntPtr NativeFunc_Num => Memory.ModuleBase() + 0x5BB66A8;
        public int Num()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("Num", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5BB6514 — hookable via Hooks.InstallAt(NativeFunc_ApplyToPreview).</summary>
        public static global::System.IntPtr NativeFunc_ApplyToPreview => Memory.ModuleBase() + 0x5BB6514;
        public void ApplyToPreview(NiagaraComponent PreviewComponent, int PreviewIndex, bool bIsXAxis, global::System.IntPtr OutLabelText)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, PreviewComponent);
            __pb.Set(0x8, PreviewIndex);
            __pb.Set<byte>(0xC, (byte)(bIsXAxis?1:0));
            __pb.Set<global::System.IntPtr>(0x10, OutLabelText);
            CallRaw("ApplyToPreview", __pb.Bytes);
        }
    }

    public class NiagaraPreviewAxis_InterpParamBase : NiagaraPreviewAxis
    {
        public const string UeClassName = "NiagaraPreviewAxis_InterpParamBase";
        public NiagaraPreviewAxis_InterpParamBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewAxis_InterpParamBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis_InterpParamBase(p);
        public static NiagaraPreviewAxis_InterpParamBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewAxis_InterpParamBase(o.Pointer); }
        public static NiagaraPreviewAxis_InterpParamBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewAxis_InterpParamBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewAxis_InterpParamBase(a[i].Pointer); return r; }
        public string Param => Native.GetPropName(Pointer, "Param"); // FName
        public FName Param_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
        public int Count { get => GetAt<int>(0x30); set => SetAt(0x30, value); }
    }

    public class NiagaraPreviewAxis_InterpParamInt32 : NiagaraPreviewAxis_InterpParamBase
    {
        public const string UeClassName = "NiagaraPreviewAxis_InterpParamInt32";
        public NiagaraPreviewAxis_InterpParamInt32(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewAxis_InterpParamInt32 FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis_InterpParamInt32(p);
        public static NiagaraPreviewAxis_InterpParamInt32 FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewAxis_InterpParamInt32(o.Pointer); }
        public static NiagaraPreviewAxis_InterpParamInt32[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewAxis_InterpParamInt32[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewAxis_InterpParamInt32(a[i].Pointer); return r; }
        public int Min { get => GetAt<int>(0x34); set => SetAt(0x34, value); }
        public int Max { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
    }

    public class NiagaraPreviewAxis_InterpParamFloat : NiagaraPreviewAxis_InterpParamBase
    {
        public const string UeClassName = "NiagaraPreviewAxis_InterpParamFloat";
        public NiagaraPreviewAxis_InterpParamFloat(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewAxis_InterpParamFloat FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis_InterpParamFloat(p);
        public static NiagaraPreviewAxis_InterpParamFloat FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewAxis_InterpParamFloat(o.Pointer); }
        public static NiagaraPreviewAxis_InterpParamFloat[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewAxis_InterpParamFloat[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewAxis_InterpParamFloat(a[i].Pointer); return r; }
        public float Min { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public float Max { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
    }

    public class NiagaraPreviewAxis_InterpParamVector2D : NiagaraPreviewAxis_InterpParamBase
    {
        public const string UeClassName = "NiagaraPreviewAxis_InterpParamVector2D";
        public NiagaraPreviewAxis_InterpParamVector2D(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewAxis_InterpParamVector2D FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis_InterpParamVector2D(p);
        public static NiagaraPreviewAxis_InterpParamVector2D FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewAxis_InterpParamVector2D(o.Pointer); }
        public static NiagaraPreviewAxis_InterpParamVector2D[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewAxis_InterpParamVector2D[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewAxis_InterpParamVector2D(a[i].Pointer); return r; }
        public Vector2D Min => new Vector2D(AddrOf(0x34));
        public Vector2D Max => new Vector2D(AddrOf(0x3C));
    }

    public class NiagaraPreviewAxis_InterpParamVector : NiagaraPreviewAxis_InterpParamBase
    {
        public const string UeClassName = "NiagaraPreviewAxis_InterpParamVector";
        public NiagaraPreviewAxis_InterpParamVector(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewAxis_InterpParamVector FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis_InterpParamVector(p);
        public static NiagaraPreviewAxis_InterpParamVector FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewAxis_InterpParamVector(o.Pointer); }
        public static NiagaraPreviewAxis_InterpParamVector[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewAxis_InterpParamVector[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewAxis_InterpParamVector(a[i].Pointer); return r; }
        public Vector Min => new Vector(AddrOf(0x34));
        public Vector Max => new Vector(AddrOf(0x40));
    }

    public class NiagaraPreviewAxis_InterpParamVector4 : NiagaraPreviewAxis_InterpParamBase
    {
        public const string UeClassName = "NiagaraPreviewAxis_InterpParamVector4";
        public NiagaraPreviewAxis_InterpParamVector4(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewAxis_InterpParamVector4 FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis_InterpParamVector4(p);
        public static NiagaraPreviewAxis_InterpParamVector4 FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewAxis_InterpParamVector4(o.Pointer); }
        public static NiagaraPreviewAxis_InterpParamVector4[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewAxis_InterpParamVector4[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewAxis_InterpParamVector4(a[i].Pointer); return r; }
        public Vector4 Min => new Vector4(AddrOf(0x40));
        public Vector4 Max => new Vector4(AddrOf(0x50));
    }

    public class NiagaraPreviewAxis_InterpParamLinearColor : NiagaraPreviewAxis_InterpParamBase
    {
        public const string UeClassName = "NiagaraPreviewAxis_InterpParamLinearColor";
        public NiagaraPreviewAxis_InterpParamLinearColor(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewAxis_InterpParamLinearColor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis_InterpParamLinearColor(p);
        public static NiagaraPreviewAxis_InterpParamLinearColor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewAxis_InterpParamLinearColor(o.Pointer); }
        public static NiagaraPreviewAxis_InterpParamLinearColor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewAxis_InterpParamLinearColor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewAxis_InterpParamLinearColor(a[i].Pointer); return r; }
        public LinearColor Min => new LinearColor(AddrOf(0x34));
        public LinearColor Max => new LinearColor(AddrOf(0x44));
    }

    public class NiagaraPreviewGrid : Actor
    {
        public const string UeClassName = "NiagaraPreviewGrid";
        public NiagaraPreviewGrid(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraPreviewGrid FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraPreviewGrid(p);
        public static NiagaraPreviewGrid FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraPreviewGrid(o.Pointer); }
        public static NiagaraPreviewGrid[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraPreviewGrid[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraPreviewGrid(a[i].Pointer); return r; }
        public NiagaraSystem System { get { var __p = GetAt<global::System.IntPtr>(0x220); return __p==global::System.IntPtr.Zero?null:new NiagaraSystem(__p); } set => SetAt(0x220, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ENiagaraPreviewGridResetMode ResetMode { get => (ENiagaraPreviewGridResetMode)GetAt<byte>(0x228); set => SetAt(0x228, (byte)value); }
        public NiagaraPreviewAxis PreviewAxisX { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NiagaraPreviewAxis PreviewAxisY { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new NiagaraPreviewAxis(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NiagaraPreviewBase PreviewClass { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new NiagaraPreviewBase(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float SpacingX { get => GetAt<float>(0x248); set => SetAt(0x248, value); }
        public float SpacingY { get => GetAt<float>(0x24C); set => SetAt(0x24C, value); }
        public int NumX { get => GetAt<int>(0x250); set => SetAt(0x250, value); }
        public int NumY { get => GetAt<int>(0x254); set => SetAt(0x254, value); }
        public TArray<global::System.IntPtr> PreviewComponents => new TArray<global::System.IntPtr>(AddrOf(0x258)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x5BB886C — hookable via Hooks.InstallAt(NativeFunc_SetPaused).</summary>
        public static global::System.IntPtr NativeFunc_SetPaused => Memory.ModuleBase() + 0x5BB886C;
        public void SetPaused(bool bPaused)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bPaused?1:0));
            CallRaw("SetPaused", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB87AC — hookable via Hooks.InstallAt(NativeFunc_GetPreviews).</summary>
        public static global::System.IntPtr NativeFunc_GetPreviews => Memory.ModuleBase() + 0x5BB87AC;
        public void GetPreviews(global::System.IntPtr OutPreviews)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, OutPreviews);
            CallRaw("GetPreviews", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB8918 — hookable via Hooks.InstallAt(NativeFunc_DeactivatePreviews).</summary>
        public static global::System.IntPtr NativeFunc_DeactivatePreviews => Memory.ModuleBase() + 0x5BB8918;
        public void DeactivatePreviews()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DeactivatePreviews", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5BB892C — hookable via Hooks.InstallAt(NativeFunc_ActivatePreviews).</summary>
        public static global::System.IntPtr NativeFunc_ActivatePreviews => Memory.ModuleBase() + 0x5BB892C;
        public void ActivatePreviews(bool bReset)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bReset?1:0));
            CallRaw("ActivatePreviews", __pb.Bytes);
        }
    }

    public class NiagaraRibbonRendererProperties : NiagaraRendererProperties
    {
        public const string UeClassName = "NiagaraRibbonRendererProperties";
        public NiagaraRibbonRendererProperties(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraRibbonRendererProperties FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraRibbonRendererProperties(p);
        public static NiagaraRibbonRendererProperties FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraRibbonRendererProperties(o.Pointer); }
        public static NiagaraRibbonRendererProperties[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraRibbonRendererProperties[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraRibbonRendererProperties(a[i].Pointer); return r; }
        public MaterialInterface Material { get { var __p = GetAt<global::System.IntPtr>(0x50); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x50, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NiagaraUserParameterBinding MaterialUserParamBinding => new NiagaraUserParameterBinding(AddrOf(0x58));
        public ENiagaraRibbonFacingMode FacingMode { get => (ENiagaraRibbonFacingMode)GetAt<byte>(0x80); set => SetAt(0x80, (byte)value); }
        public float UV0TilingDistance { get => GetAt<float>(0x84); set => SetAt(0x84, value); }
        public Vector2D UV0Scale => new Vector2D(AddrOf(0x88));
        public Vector2D UV0Offset => new Vector2D(AddrOf(0x90));
        public ENiagaraRibbonAgeOffsetMode UV0AgeOffsetMode { get => (ENiagaraRibbonAgeOffsetMode)GetAt<byte>(0x98); set => SetAt(0x98, (byte)value); }
        public float UV1TilingDistance { get => GetAt<float>(0x9C); set => SetAt(0x9C, value); }
        public Vector2D UV1Scale => new Vector2D(AddrOf(0xA0));
        public Vector2D UV1Offset => new Vector2D(AddrOf(0xA8));
        public ENiagaraRibbonAgeOffsetMode UV1AgeOffsetMode { get => (ENiagaraRibbonAgeOffsetMode)GetAt<byte>(0xB0); set => SetAt(0xB0, (byte)value); }
        public ENiagaraRibbonDrawDirection DrawDirection { get => (ENiagaraRibbonDrawDirection)GetAt<byte>(0xB1); set => SetAt(0xB1, (byte)value); }
        public float CurveTension { get => GetAt<float>(0xB4); set => SetAt(0xB4, value); }
        public ENiagaraRibbonTessellationMode TessellationMode { get => (ENiagaraRibbonTessellationMode)GetAt<byte>(0xB8); set => SetAt(0xB8, (byte)value); }
        public int TessellationFactor { get => GetAt<int>(0xBC); set => SetAt(0xBC, value); }
        public bool bUseConstantFactor { get => Native.GetPropBool(Pointer, "bUseConstantFactor"); set => Native.SetPropBool(Pointer, "bUseConstantFactor", value); }
        public float TessellationAngle { get => GetAt<float>(0xC4); set => SetAt(0xC4, value); }
        public bool bScreenSpaceTessellation { get => Native.GetPropBool(Pointer, "bScreenSpaceTessellation"); set => Native.SetPropBool(Pointer, "bScreenSpaceTessellation", value); }
        public NiagaraVariableAttributeBinding PositionBinding => new NiagaraVariableAttributeBinding(AddrOf(0xD0));
        public NiagaraVariableAttributeBinding ColorBinding => new NiagaraVariableAttributeBinding(AddrOf(0x148));
        public NiagaraVariableAttributeBinding VelocityBinding => new NiagaraVariableAttributeBinding(AddrOf(0x1C0));
        public NiagaraVariableAttributeBinding NormalizedAgeBinding => new NiagaraVariableAttributeBinding(AddrOf(0x238));
        public NiagaraVariableAttributeBinding RibbonTwistBinding => new NiagaraVariableAttributeBinding(AddrOf(0x2B0));
        public NiagaraVariableAttributeBinding RibbonWidthBinding => new NiagaraVariableAttributeBinding(AddrOf(0x328));
        public NiagaraVariableAttributeBinding RibbonFacingBinding => new NiagaraVariableAttributeBinding(AddrOf(0x3A0));
        public NiagaraVariableAttributeBinding RibbonIdBinding => new NiagaraVariableAttributeBinding(AddrOf(0x418));
        public NiagaraVariableAttributeBinding RibbonLinkOrderBinding => new NiagaraVariableAttributeBinding(AddrOf(0x490));
        public NiagaraVariableAttributeBinding MaterialRandomBinding => new NiagaraVariableAttributeBinding(AddrOf(0x508));
        public NiagaraVariableAttributeBinding DynamicMaterialBinding => new NiagaraVariableAttributeBinding(AddrOf(0x580));
        public NiagaraVariableAttributeBinding DynamicMaterial1Binding => new NiagaraVariableAttributeBinding(AddrOf(0x5F8));
        public NiagaraVariableAttributeBinding DynamicMaterial2Binding => new NiagaraVariableAttributeBinding(AddrOf(0x670));
        public NiagaraVariableAttributeBinding DynamicMaterial3Binding => new NiagaraVariableAttributeBinding(AddrOf(0x6E8));
    }

    public class NiagaraScript : Object
    {
        public const string UeClassName = "NiagaraScript";
        public NiagaraScript(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraScript FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraScript(p);
        public static NiagaraScript FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraScript(o.Pointer); }
        public static NiagaraScript[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraScript[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraScript(a[i].Pointer); return r; }
        public ENiagaraScriptUsage Usage { get => (ENiagaraScriptUsage)GetAt<byte>(0x28); set => SetAt(0x28, (byte)value); }
        public int UsageIndex { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public Guid UsageId => new Guid(AddrOf(0x30));
        public NiagaraParameterStore RapidIterationParameters => new NiagaraParameterStore(AddrOf(0x40));
        public NiagaraScriptExecutionParameterStore ScriptExecutionParamStore => new NiagaraScriptExecutionParameterStore(AddrOf(0xF8));
        public TArray<global::System.IntPtr> ScriptExecutionBoundParameters => new TArray<global::System.IntPtr>(AddrOf(0x1D0)); // TArray<struct>
        public NiagaraVMExecutableDataId CachedScriptVMId => new NiagaraVMExecutableDataId(AddrOf(0x1E0));
        public NiagaraVMExecutableData CachedScriptVM => new NiagaraVMExecutableData(AddrOf(0x3D8));
        public TArray<global::System.IntPtr> CachedParameterCollectionReferences => new TArray<global::System.IntPtr>(AddrOf(0x500)); // TArray<UObject*>
        public TArray<global::System.IntPtr> CachedDefaultDataInterfaces => new TArray<global::System.IntPtr>(AddrOf(0x510)); // TArray<struct>
        /// <summary>[Native] thunk RVA 0x5BBC558 — hookable via Hooks.InstallAt(NativeFunc_RaiseOnGPUCompilationComplete).</summary>
        public static global::System.IntPtr NativeFunc_RaiseOnGPUCompilationComplete => Memory.ModuleBase() + 0x5BBC558;
        public void RaiseOnGPUCompilationComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RaiseOnGPUCompilationComplete", __pb.Bytes);
        }
    }

    public class NiagaraScriptSourceBase : Object
    {
        public const string UeClassName = "NiagaraScriptSourceBase";
        public NiagaraScriptSourceBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraScriptSourceBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraScriptSourceBase(p);
        public static NiagaraScriptSourceBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraScriptSourceBase(o.Pointer); }
        public static NiagaraScriptSourceBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraScriptSourceBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraScriptSourceBase(a[i].Pointer); return r; }
    }

    public class NiagaraSettings : DeveloperSettings
    {
        public const string UeClassName = "NiagaraSettings";
        public NiagaraSettings(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraSettings FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraSettings(p);
        public static NiagaraSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraSettings(o.Pointer); }
        public static NiagaraSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraSettings(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> AdditionalParameterTypes => new TArray<global::System.IntPtr>(AddrOf(0x38)); // TArray<struct>
        public TArray<global::System.IntPtr> AdditionalPayloadTypes => new TArray<global::System.IntPtr>(AddrOf(0x48)); // TArray<struct>
        public TArray<global::System.IntPtr> AdditionalParameterEnums => new TArray<global::System.IntPtr>(AddrOf(0x58)); // TArray<struct>
        public SoftObjectPath DefaultEffectType => new SoftObjectPath(AddrOf(0x68));
        public TArray<global::System.IntPtr> QualityLevels => new TArray<global::System.IntPtr>(AddrOf(0x80)); // TArray<FText>
        public NiagaraEffectType DefaultEffectTypePtr { get { var __p = GetAt<global::System.IntPtr>(0x90); return __p==global::System.IntPtr.Zero?null:new NiagaraEffectType(__p); } set => SetAt(0x90, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NiagaraSimulationStageBase : NiagaraMergeable
    {
        public const string UeClassName = "NiagaraSimulationStageBase";
        public NiagaraSimulationStageBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraSimulationStageBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraSimulationStageBase(p);
        public static NiagaraSimulationStageBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraSimulationStageBase(o.Pointer); }
        public static NiagaraSimulationStageBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraSimulationStageBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraSimulationStageBase(a[i].Pointer); return r; }
        public NiagaraScript Script { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new NiagaraScript(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string SimulationStageName => Native.GetPropName(Pointer, "SimulationStageName"); // FName
        public FName SimulationStageName_Raw { get => GetAt<FName>(0x30); set => SetAt(0x30, value); }
    }

    public class NiagaraSimulationStageGeneric : NiagaraSimulationStageBase
    {
        public const string UeClassName = "NiagaraSimulationStageGeneric";
        public NiagaraSimulationStageGeneric(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraSimulationStageGeneric FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraSimulationStageGeneric(p);
        public static NiagaraSimulationStageGeneric FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraSimulationStageGeneric(o.Pointer); }
        public static NiagaraSimulationStageGeneric[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraSimulationStageGeneric[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraSimulationStageGeneric(a[i].Pointer); return r; }
        public ENiagaraIterationSource IterationSource { get => (ENiagaraIterationSource)GetAt<byte>(0x38); set => SetAt(0x38, (byte)value); }
        public int Iterations { get => GetAt<int>(0x3C); set => SetAt(0x3C, value); }
        public bool bSpawnOnly { get => Native.GetPropBool(Pointer, "bSpawnOnly"); set => Native.SetPropBool(Pointer, "bSpawnOnly", value); }
        public NiagaraVariableDataInterfaceBinding DataInterface => new NiagaraVariableDataInterfaceBinding(AddrOf(0x48));
    }

    public class NiagaraSpriteRendererProperties : NiagaraRendererProperties
    {
        public const string UeClassName = "NiagaraSpriteRendererProperties";
        public NiagaraSpriteRendererProperties(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraSpriteRendererProperties FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraSpriteRendererProperties(p);
        public static NiagaraSpriteRendererProperties FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraSpriteRendererProperties(o.Pointer); }
        public static NiagaraSpriteRendererProperties[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraSpriteRendererProperties[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraSpriteRendererProperties(a[i].Pointer); return r; }
        public MaterialInterface Material { get { var __p = GetAt<global::System.IntPtr>(0x50); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x50, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NiagaraUserParameterBinding MaterialUserParamBinding => new NiagaraUserParameterBinding(AddrOf(0x58));
        public ENiagaraSpriteAlignment Alignment { get => (ENiagaraSpriteAlignment)GetAt<byte>(0x80); set => SetAt(0x80, (byte)value); }
        public ENiagaraSpriteFacingMode FacingMode { get => (ENiagaraSpriteFacingMode)GetAt<byte>(0x81); set => SetAt(0x81, (byte)value); }
        public Vector2D PivotInUVSpace => new Vector2D(AddrOf(0x84));
        public ENiagaraSortMode SortMode { get => (ENiagaraSortMode)GetAt<byte>(0x8C); set => SetAt(0x8C, (byte)value); }
        public Vector2D SubImageSize => new Vector2D(AddrOf(0x90));
        public bool bSubImageBlend { get => Native.GetPropBool(Pointer, "bSubImageBlend"); set => Native.SetPropBool(Pointer, "bSubImageBlend", value); }
        public bool bRemoveHMDRollInVR { get => Native.GetPropBool(Pointer, "bRemoveHMDRollInVR"); set => Native.SetPropBool(Pointer, "bRemoveHMDRollInVR", value); }
        public bool bSortOnlyWhenTranslucent { get => Native.GetPropBool(Pointer, "bSortOnlyWhenTranslucent"); set => Native.SetPropBool(Pointer, "bSortOnlyWhenTranslucent", value); }
        public float MinFacingCameraBlendDistance { get => GetAt<float>(0x9C); set => SetAt(0x9C, value); }
        public float MaxFacingCameraBlendDistance { get => GetAt<float>(0xA0); set => SetAt(0xA0, value); }
        public NiagaraVariableAttributeBinding PositionBinding => new NiagaraVariableAttributeBinding(AddrOf(0xA8));
        public NiagaraVariableAttributeBinding ColorBinding => new NiagaraVariableAttributeBinding(AddrOf(0x120));
        public NiagaraVariableAttributeBinding VelocityBinding => new NiagaraVariableAttributeBinding(AddrOf(0x198));
        public NiagaraVariableAttributeBinding SpriteRotationBinding => new NiagaraVariableAttributeBinding(AddrOf(0x210));
        public NiagaraVariableAttributeBinding SpriteSizeBinding => new NiagaraVariableAttributeBinding(AddrOf(0x288));
        public NiagaraVariableAttributeBinding SpriteFacingBinding => new NiagaraVariableAttributeBinding(AddrOf(0x300));
        public NiagaraVariableAttributeBinding SpriteAlignmentBinding => new NiagaraVariableAttributeBinding(AddrOf(0x378));
        public NiagaraVariableAttributeBinding SubImageIndexBinding => new NiagaraVariableAttributeBinding(AddrOf(0x3F0));
        public NiagaraVariableAttributeBinding DynamicMaterialBinding => new NiagaraVariableAttributeBinding(AddrOf(0x468));
        public NiagaraVariableAttributeBinding DynamicMaterial1Binding => new NiagaraVariableAttributeBinding(AddrOf(0x4E0));
        public NiagaraVariableAttributeBinding DynamicMaterial2Binding => new NiagaraVariableAttributeBinding(AddrOf(0x558));
        public NiagaraVariableAttributeBinding DynamicMaterial3Binding => new NiagaraVariableAttributeBinding(AddrOf(0x5D0));
        public NiagaraVariableAttributeBinding CameraOffsetBinding => new NiagaraVariableAttributeBinding(AddrOf(0x648));
        public NiagaraVariableAttributeBinding UVScaleBinding => new NiagaraVariableAttributeBinding(AddrOf(0x6C0));
        public NiagaraVariableAttributeBinding MaterialRandomBinding => new NiagaraVariableAttributeBinding(AddrOf(0x738));
        public NiagaraVariableAttributeBinding CustomSortingBinding => new NiagaraVariableAttributeBinding(AddrOf(0x7B0));
        public NiagaraVariableAttributeBinding NormalizedAgeBinding => new NiagaraVariableAttributeBinding(AddrOf(0x828));
    }

    public class NiagaraSystem : FXSystemAsset
    {
        public const string UeClassName = "NiagaraSystem";
        public NiagaraSystem(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraSystem FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraSystem(p);
        public static NiagaraSystem FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraSystem(o.Pointer); }
        public static NiagaraSystem[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraSystem[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraSystem(a[i].Pointer); return r; }
        public bool bDumpDebugSystemInfo { get => Native.GetPropBool(Pointer, "bDumpDebugSystemInfo"); set => Native.SetPropBool(Pointer, "bDumpDebugSystemInfo", value); }
        public bool bDumpDebugEmitterInfo { get => Native.GetPropBool(Pointer, "bDumpDebugEmitterInfo"); set => Native.SetPropBool(Pointer, "bDumpDebugEmitterInfo", value); }
        public bool bFixedBounds { get => Native.GetPropBool(Pointer, "bFixedBounds"); set => Native.SetPropBool(Pointer, "bFixedBounds", value); }
        public NiagaraEffectType EffectType { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new NiagaraEffectType(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bOverrideScalabilitySettings { get => Native.GetPropBool(Pointer, "bOverrideScalabilitySettings"); set => Native.SetPropBool(Pointer, "bOverrideScalabilitySettings", value); }
        public TArray<global::System.IntPtr> ScalabilityOverrides => new TArray<global::System.IntPtr>(AddrOf(0x40)); // TArray<struct>
        public NiagaraSystemScalabilityOverrides SystemScalabilityOverrides => new NiagaraSystemScalabilityOverrides(AddrOf(0x50));
        public TArray<global::System.IntPtr> EmitterHandles => new TArray<global::System.IntPtr>(AddrOf(0x60)); // TArray<struct>
        public TArray<global::System.IntPtr> ParameterCollectionOverrides => new TArray<global::System.IntPtr>(AddrOf(0x70)); // TArray<UObject*>
        public NiagaraScript SystemSpawnScript { get { var __p = GetAt<global::System.IntPtr>(0x80); return __p==global::System.IntPtr.Zero?null:new NiagaraScript(__p); } set => SetAt(0x80, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NiagaraScript SystemUpdateScript { get { var __p = GetAt<global::System.IntPtr>(0x88); return __p==global::System.IntPtr.Zero?null:new NiagaraScript(__p); } set => SetAt(0x88, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NiagaraSystemCompiledData SystemCompiledData => new NiagaraSystemCompiledData(AddrOf(0xA0));
        public NiagaraUserRedirectionParameterStore ExposedParameters => new NiagaraUserRedirectionParameterStore(AddrOf(0x2F8));
        public Box FixedBounds => new Box(AddrOf(0x400));
        public bool bAutoDeactivate { get => Native.GetPropBool(Pointer, "bAutoDeactivate"); set => Native.SetPropBool(Pointer, "bAutoDeactivate", value); }
        public float WarmupTime { get => GetAt<float>(0x420); set => SetAt(0x420, value); }
        public int WarmupTickCount { get => GetAt<int>(0x424); set => SetAt(0x424, value); }
        public float WarmupTickDelta { get => GetAt<float>(0x428); set => SetAt(0x428, value); }
        public bool bHasSystemScriptDIsWithPerInstanceData { get => Native.GetPropBool(Pointer, "bHasSystemScriptDIsWithPerInstanceData"); set => Native.SetPropBool(Pointer, "bHasSystemScriptDIsWithPerInstanceData", value); }
        public TArray<global::System.IntPtr> UserDINamesReadInSystemScripts => new TArray<global::System.IntPtr>(AddrOf(0x430)); // TArray<FName>
    }

}
