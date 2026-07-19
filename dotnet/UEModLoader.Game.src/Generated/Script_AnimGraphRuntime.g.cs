// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AnimGraphRuntime
using System;

namespace UEModLoader.Game
{
    public enum ESphericalLimitType
    {
        Inner = 0,
        Outer = 1,
    }

    public enum AnimPhysSimSpaceType
    {
        Component = 0,
        Actor = 1,
        World = 2,
        RootRelative = 3,
        BoneRelative = 4,
        ExternalActor = 5,
    }

    public enum AnimPhysLinearConstraintType
    {
        Free = 0,
        Limited = 1,
    }

    public enum AnimPhysAngularConstraintType
    {
        Angular = 0,
        Cone = 1,
    }

    public enum EBlendListTransitionType
    {
        StandardBlend = 0,
        Inertialization = 1,
    }

    public enum EDrivenDestinationMode
    {
        Bone = 0,
        MorphTarget = 1,
        MaterialParameter = 2,
    }

    public enum EDrivenBoneModificationMode
    {
        AddToInput = 0,
        ReplaceComponent = 1,
        AddToRefPose = 2,
    }

    public enum EConstraintOffsetOption
    {
        None = 0,
        Offset_RefPose = 1,
    }

    public enum CopyBoneDeltaMode
    {
        Accumulate = 0,
        Copy = 1,
    }

    public enum EInterpolationBlend
    {
        Linear = 0,
        Cubic = 1,
        Sinusoidal = 2,
        EaseInOutExponent2 = 3,
        EaseInOutExponent3 = 4,
        EaseInOutExponent4 = 5,
        EaseInOutExponent5 = 6,
        MAX = 7,
    }

    public enum EBoneModificationMode
    {
        BMM_Ignore = 0,
        BMM_Replace = 1,
        BMM_Additive = 2,
    }

    public enum EModifyCurveApplyMode
    {
        Add = 0,
        Scale = 1,
        Blend = 2,
        WeightedMovingAverage = 3,
        RemapCurve = 4,
    }

    public enum EPoseDriverOutput
    {
        DrivePoses = 0,
        DriveCurves = 1,
    }

    public enum EPoseDriverSource
    {
        Rotation = 0,
        Translation = 1,
    }

    public enum EPoseDriverType
    {
        SwingAndTwist = 0,
        SwingOnly = 1,
        Translation = 2,
    }

    public enum ESnapshotSourceMode
    {
        NamedSnapshot = 0,
        SnapshotPin = 1,
    }

    public enum ERefPoseType
    {
        EIT_LocalSpace = 0,
        EIT_Additive = 1,
    }

    public enum ESimulationSpace
    {
        ComponentSpace = 0,
        WorldSpace = 1,
        BaseBoneSpace = 2,
    }

    public enum EScaleChainInitialLength
    {
        FixedDefaultLengthValue = 0,
        Distance = 1,
        ChainLength = 2,
    }

    public enum ESequenceEvalReinit
    {
        NoReset = 0,
        StartPosition = 1,
        ExplicitTime = 2,
    }

    public enum ESplineBoneAxis
    {
        None = 0,
        X = 1,
        Y = 2,
        Z = 3,
    }

    public enum ERotationComponent
    {
        EulerX = 0,
        EulerY = 1,
        EulerZ = 2,
        QuaternionAngle = 3,
        SwingAngle = 4,
        TwistAngle = 5,
    }

    public enum EEasingFuncType
    {
        Linear = 0,
        Sinusoidal = 1,
        Cubic = 2,
        QuadraticInOut = 3,
        CubicInOut = 4,
        HermiteCubic = 5,
        QuarticInOut = 6,
        QuinticInOut = 7,
        CircularIn = 8,
        CircularOut = 9,
        CircularInOut = 10,
        ExpIn = 11,
        ExpOut = 12,
        ExpInOut = 13,
        CustomCurve = 14,
    }

    public enum ERBFNormalizeMethod
    {
        OnlyNormalizeAboveOne = 0,
        AlwaysNormalize = 1,
        NormalizeWithinMedian = 2,
        NoNormalization = 3,
    }

    public enum ERBFDistanceMethod
    {
        Euclidean = 0,
        Quaternion = 1,
        SwingAngle = 2,
        TwistAngle = 3,
        DefaultMethod = 4,
    }

    public enum ERBFFunctionType
    {
        Gaussian = 0,
        Exponential = 1,
        Linear = 2,
        Cubic = 3,
        Quintic = 4,
        DefaultFunction = 5,
    }

    public enum ERBFSolverType
    {
        Additive = 0,
        Interpolative = 1,
    }

    public class AnimNode_SkeletalControlBase : StructProxy
    {
        public AnimNode_SkeletalControlBase(global::System.IntPtr ptr) : base(ptr) {}
        public ComponentSpacePoseLink ComponentPose => new ComponentSpacePoseLink(AddrOf(0x10));
        public int LODThreshold { get => GetAt<int>(0x20); set => SetAt(0x20, value); }
        public float ActualAlpha { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public EAnimAlphaInputType AlphaInputType { get => (EAnimAlphaInputType)GetAt<byte>(0x28); set => SetAt(0x28, (byte)value); }
        public bool bAlphaBoolEnabled { get => (GetAt<byte>(0x29) & 0xFF) != 0; set { var __b = GetAt<byte>(0x29); SetAt(0x29, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float alpha { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public InputScaleBias AlphaScaleBias => new InputScaleBias(AddrOf(0x30));
        public InputAlphaBoolBlend AlphaBoolBlend => new InputAlphaBoolBlend(AddrOf(0x38));
        public string AlphaCurveName => Native.FNameToString(GetAt<int>(0x80)); // FName
        public FName AlphaCurveName_Raw { get => GetAt<FName>(0x80); set => SetAt(0x80, value); }
        public InputScaleBiasClamp AlphaScaleBiasClamp => new InputScaleBiasClamp(AddrOf(0x88));
    }

    public class AnimNode_BlendSpacePlayer : StructProxy
    {
        public AnimNode_BlendSpacePlayer(global::System.IntPtr ptr) : base(ptr) {}
        public float X { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float Y { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public float Z { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public float PlayRate { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public bool bLoop { get => (GetAt<byte>(0x40) & 0xFF) != 0; set { var __b = GetAt<byte>(0x40); SetAt(0x40, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bResetPlayTimeWhenBlendSpaceChanges { get => (GetAt<byte>(0x41) & 0xFF) != 0; set { var __b = GetAt<byte>(0x41); SetAt(0x41, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float StartPosition { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public BlendSpaceBase BlendSpace { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new BlendSpaceBase(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BlendSpaceBase PreviousBlendSpace { get { var __p = GetAt<global::System.IntPtr>(0xD8); return __p==global::System.IntPtr.Zero?null:new BlendSpaceBase(__p); } set => SetAt(0xD8, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class AnimNode_AimOffsetLookAt : StructProxy
    {
        public AnimNode_AimOffsetLookAt(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink BasePose => new PoseLink(AddrOf(0x140));
        public int LODThreshold { get => GetAt<int>(0x150); set => SetAt(0x150, value); }
        public string SourceSocketName => Native.FNameToString(GetAt<int>(0x154)); // FName
        public FName SourceSocketName_Raw { get => GetAt<FName>(0x154); set => SetAt(0x154, value); }
        public string PivotSocketName => Native.FNameToString(GetAt<int>(0x15C)); // FName
        public FName PivotSocketName_Raw { get => GetAt<FName>(0x15C); set => SetAt(0x15C, value); }
        public Vector LookAtLocation => new Vector(AddrOf(0x164));
        public Vector SocketAxis => new Vector(AddrOf(0x170));
        public float alpha { get => GetAt<float>(0x17C); set => SetAt(0x17C, value); }
    }

    public class AnimNode_AnimDynamics : StructProxy
    {
        public AnimNode_AnimDynamics(global::System.IntPtr ptr) : base(ptr) {}
        public float LinearDampingOverride { get => GetAt<float>(0xC8); set => SetAt(0xC8, value); }
        public float AngularDampingOverride { get => GetAt<float>(0xCC); set => SetAt(0xCC, value); }
        public BoneReference RelativeSpaceBone => new BoneReference(AddrOf(0x130));
        public BoneReference BoundBone => new BoneReference(AddrOf(0x140));
        public BoneReference ChainEnd => new BoneReference(AddrOf(0x150));
        public Vector BoxExtents => new Vector(AddrOf(0x160));
        public Vector LocalJointOffset => new Vector(AddrOf(0x16C));
        public float GravityScale { get => GetAt<float>(0x178); set => SetAt(0x178, value); }
        public Vector GravityOverride => new Vector(AddrOf(0x17C));
        public float LinearSpringConstant { get => GetAt<float>(0x188); set => SetAt(0x188, value); }
        public float AngularSpringConstant { get => GetAt<float>(0x18C); set => SetAt(0x18C, value); }
        public float WindScale { get => GetAt<float>(0x190); set => SetAt(0x190, value); }
        public Vector ComponentLinearAccScale => new Vector(AddrOf(0x194));
        public Vector ComponentLinearVelScale => new Vector(AddrOf(0x1A0));
        public Vector ComponentAppliedLinearAccClamp => new Vector(AddrOf(0x1AC));
        public float AngularBiasOverride { get => GetAt<float>(0x1B8); set => SetAt(0x1B8, value); }
        public int NumSolverIterationsPreUpdate { get => GetAt<int>(0x1BC); set => SetAt(0x1BC, value); }
        public int NumSolverIterationsPostUpdate { get => GetAt<int>(0x1C0); set => SetAt(0x1C0, value); }
        public AnimPhysConstraintSetup ConstraintSetup => new AnimPhysConstraintSetup(AddrOf(0x1C4));
        public TArray<global::System.IntPtr> SphericalLimits => new TArray<global::System.IntPtr>(AddrOf(0x210)); // TArray<struct>
        public float SphereCollisionRadius { get => GetAt<float>(0x220); set => SetAt(0x220, value); }
        public Vector ExternalForce => new Vector(AddrOf(0x224));
        public TArray<global::System.IntPtr> PlanarLimits => new TArray<global::System.IntPtr>(AddrOf(0x230)); // TArray<struct>
        public AnimPhysCollisionType CollisionType { get => (AnimPhysCollisionType)GetAt<byte>(0x240); set => SetAt(0x240, (byte)value); }
        public AnimPhysSimSpaceType SimulationSpace { get => (AnimPhysSimSpaceType)GetAt<byte>(0x241); set => SetAt(0x241, (byte)value); }
        public Actor ExternalSimActor { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool GravityOnly { get => (GetAt<byte>(0x250) & 0xFF) != 0; set { var __b = GetAt<byte>(0x250); SetAt(0x250, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bUseSphericalLimits { get => (GetAt<byte>(0x253) & 0x1) != 0; set { var __b = GetAt<byte>(0x253); SetAt(0x253, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bUsePlanarLimit { get => (GetAt<byte>(0x253) & 0x2) != 0; set { var __b = GetAt<byte>(0x253); SetAt(0x253, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bDoUpdate { get => (GetAt<byte>(0x253) & 0x4) != 0; set { var __b = GetAt<byte>(0x253); SetAt(0x253, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bDoEval { get => (GetAt<byte>(0x253) & 0x8) != 0; set { var __b = GetAt<byte>(0x253); SetAt(0x253, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bOverrideLinearDamping { get => (GetAt<byte>(0x253) & 0x10) != 0; set { var __b = GetAt<byte>(0x253); SetAt(0x253, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bOverrideAngularBias { get => (GetAt<byte>(0x253) & 0x20) != 0; set { var __b = GetAt<byte>(0x253); SetAt(0x253, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool bOverrideAngularDamping { get => (GetAt<byte>(0x253) & 0x40) != 0; set { var __b = GetAt<byte>(0x253); SetAt(0x253, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
        public bool bEnableWind { get => (GetAt<byte>(0x253) & 0x80) != 0; set { var __b = GetAt<byte>(0x253); SetAt(0x253, (byte)(value ? (__b | 0x80) : (__b & ~0x80))); } }
        public bool bUseGravityOverride { get => (GetAt<byte>(0x254) & 0x2) != 0; set { var __b = GetAt<byte>(0x254); SetAt(0x254, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bLinearSpring { get => (GetAt<byte>(0x254) & 0x4) != 0; set { var __b = GetAt<byte>(0x254); SetAt(0x254, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bAngularSpring { get => (GetAt<byte>(0x254) & 0x8) != 0; set { var __b = GetAt<byte>(0x254); SetAt(0x254, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bChain { get => (GetAt<byte>(0x254) & 0x10) != 0; set { var __b = GetAt<byte>(0x254); SetAt(0x254, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public RotationRetargetingInfo RetargetingSettings => new RotationRetargetingInfo(AddrOf(0x260));
    }

    public class RotationRetargetingInfo : StructProxy
    {
        public RotationRetargetingInfo(global::System.IntPtr ptr) : base(ptr) {}
        public bool bEnabled { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public Transform Source => new Transform(AddrOf(0x10));
        public Transform Target => new Transform(AddrOf(0x40));
        public ERotationComponent RotationComponent { get => (ERotationComponent)GetAt<byte>(0x70); set => SetAt(0x70, (byte)value); }
        public Vector TwistAxis => new Vector(AddrOf(0x74));
        public bool bUseAbsoluteAngle { get => (GetAt<byte>(0x80) & 0xFF) != 0; set { var __b = GetAt<byte>(0x80); SetAt(0x80, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float SourceMinimum { get => GetAt<float>(0x84); set => SetAt(0x84, value); }
        public float SourceMaximum { get => GetAt<float>(0x88); set => SetAt(0x88, value); }
        public float TargetMinimum { get => GetAt<float>(0x8C); set => SetAt(0x8C, value); }
        public float TargetMaximum { get => GetAt<float>(0x90); set => SetAt(0x90, value); }
        public EEasingFuncType EasingType { get => (EEasingFuncType)GetAt<byte>(0x94); set => SetAt(0x94, (byte)value); }
        public RuntimeFloatCurve CustomCurve => new RuntimeFloatCurve(AddrOf(0x98));
        public bool bFlipEasing { get => (GetAt<byte>(0x120) & 0xFF) != 0; set { var __b = GetAt<byte>(0x120); SetAt(0x120, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float EasingWeight { get => GetAt<float>(0x124); set => SetAt(0x124, value); }
        public bool bClamp { get => (GetAt<byte>(0x128) & 0xFF) != 0; set { var __b = GetAt<byte>(0x128); SetAt(0x128, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimPhysPlanarLimit : StructProxy
    {
        public AnimPhysPlanarLimit(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference DrivingBone => new BoneReference(AddrOf(0x0));
        public Transform PlaneTransform => new Transform(AddrOf(0x10));
    }

    public class AnimPhysSphericalLimit : StructProxy
    {
        public AnimPhysSphericalLimit(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference DrivingBone => new BoneReference(AddrOf(0x0));
        public Vector SphereLocalOffset => new Vector(AddrOf(0x10));
        public float LimitRadius { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public ESphericalLimitType LimitType { get => (ESphericalLimitType)GetAt<byte>(0x20); set => SetAt(0x20, (byte)value); }
    }

    public class AnimPhysConstraintSetup : StructProxy
    {
        public AnimPhysConstraintSetup(global::System.IntPtr ptr) : base(ptr) {}
        public AnimPhysLinearConstraintType LinearXLimitType { get => (AnimPhysLinearConstraintType)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public AnimPhysLinearConstraintType LinearYLimitType { get => (AnimPhysLinearConstraintType)GetAt<byte>(0x1); set => SetAt(0x1, (byte)value); }
        public AnimPhysLinearConstraintType LinearZLimitType { get => (AnimPhysLinearConstraintType)GetAt<byte>(0x2); set => SetAt(0x2, (byte)value); }
        public Vector LinearAxesMin => new Vector(AddrOf(0x4));
        public Vector LinearAxesMax => new Vector(AddrOf(0x10));
        public AnimPhysAngularConstraintType AngularConstraintType { get => (AnimPhysAngularConstraintType)GetAt<byte>(0x1C); set => SetAt(0x1C, (byte)value); }
        public AnimPhysTwistAxis TwistAxis { get => (AnimPhysTwistAxis)GetAt<byte>(0x1D); set => SetAt(0x1D, (byte)value); }
        public AnimPhysTwistAxis AngularTargetAxis { get => (AnimPhysTwistAxis)GetAt<byte>(0x1E); set => SetAt(0x1E, (byte)value); }
        public float ConeAngle { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public Vector AngularLimitsMin => new Vector(AddrOf(0x24));
        public Vector AngularLimitsMax => new Vector(AddrOf(0x30));
        public Vector AngularTarget => new Vector(AddrOf(0x3C));
    }

    public class AnimNode_ApplyAdditive : StructProxy
    {
        public AnimNode_ApplyAdditive(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink Base => new PoseLink(AddrOf(0x10));
        public PoseLink Additive => new PoseLink(AddrOf(0x20));
        public float alpha { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public InputScaleBias AlphaScaleBias => new InputScaleBias(AddrOf(0x34));
        public int LODThreshold { get => GetAt<int>(0x3C); set => SetAt(0x3C, value); }
        public InputAlphaBoolBlend AlphaBoolBlend => new InputAlphaBoolBlend(AddrOf(0x40));
        public string AlphaCurveName => Native.FNameToString(GetAt<int>(0x88)); // FName
        public FName AlphaCurveName_Raw { get => GetAt<FName>(0x88); set => SetAt(0x88, value); }
        public InputScaleBiasClamp AlphaScaleBiasClamp => new InputScaleBiasClamp(AddrOf(0x90));
        public EAnimAlphaInputType AlphaInputType { get => (EAnimAlphaInputType)GetAt<byte>(0xC4); set => SetAt(0xC4, (byte)value); }
        public bool bAlphaBoolEnabled { get => (GetAt<byte>(0xC5) & 0xFF) != 0; set { var __b = GetAt<byte>(0xC5); SetAt(0xC5, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimNode_ApplyLimits : StructProxy
    {
        public AnimNode_ApplyLimits(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> AngularRangeLimits => new TArray<global::System.IntPtr>(AddrOf(0xC8)); // TArray<struct>
        public TArray<global::System.IntPtr> AngularOffsets => new TArray<global::System.IntPtr>(AddrOf(0xD8)); // TArray<struct>
    }

    public class AngularRangeLimit : StructProxy
    {
        public AngularRangeLimit(global::System.IntPtr ptr) : base(ptr) {}
        public Vector LimitMin => new Vector(AddrOf(0x0));
        public Vector LimitMax => new Vector(AddrOf(0xC));
        public BoneReference Bone => new BoneReference(AddrOf(0x18));
    }

    public class AnimNode_BlendBoneByChannel : StructProxy
    {
        public AnimNode_BlendBoneByChannel(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink A => new PoseLink(AddrOf(0x10));
        public PoseLink B => new PoseLink(AddrOf(0x20));
        public TArray<global::System.IntPtr> BoneDefinitions => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public float alpha { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
        public InputScaleBias AlphaScaleBias => new InputScaleBias(AddrOf(0x58));
        public byte TransformsSpace { get => GetAt<byte>(0x60); set => SetAt(0x60, value); }
    }

    public class BlendBoneByChannelEntry : StructProxy
    {
        public BlendBoneByChannelEntry(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference SourceBone => new BoneReference(AddrOf(0x0));
        public BoneReference TargetBone => new BoneReference(AddrOf(0x10));
        public bool bBlendTranslation { get => (GetAt<byte>(0x20) & 0xFF) != 0; set { var __b = GetAt<byte>(0x20); SetAt(0x20, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bBlendRotation { get => (GetAt<byte>(0x21) & 0xFF) != 0; set { var __b = GetAt<byte>(0x21); SetAt(0x21, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bBlendScale { get => (GetAt<byte>(0x22) & 0xFF) != 0; set { var __b = GetAt<byte>(0x22); SetAt(0x22, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimNode_BlendListBase : StructProxy
    {
        public AnimNode_BlendListBase(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> BlendPose => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<global::System.IntPtr> BlendTime => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<float>
        public EBlendListTransitionType TransitionType { get => (EBlendListTransitionType)GetAt<byte>(0x30); set => SetAt(0x30, (byte)value); }
        public EAlphaBlendOption BlendType { get => (EAlphaBlendOption)GetAt<byte>(0x31); set => SetAt(0x31, (byte)value); }
        public bool bResetChildOnActivation { get => (GetAt<byte>(0x32) & 0xFF) != 0; set { var __b = GetAt<byte>(0x32); SetAt(0x32, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public CurveFloat CustomBlendCurve { get { var __p = GetAt<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x38, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BlendProfile BlendProfile { get { var __p = GetAt<global::System.IntPtr>(0x40); return __p==global::System.IntPtr.Zero?null:new BlendProfile(__p); } set => SetAt(0x40, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class AnimNode_BlendListByBool : StructProxy
    {
        public AnimNode_BlendListByBool(global::System.IntPtr ptr) : base(ptr) {}
        public bool bActiveValue { get => (GetAt<byte>(0x98) & 0xFF) != 0; set { var __b = GetAt<byte>(0x98); SetAt(0x98, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimNode_BlendListByEnum : StructProxy
    {
        public AnimNode_BlendListByEnum(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> EnumToPoseIndex => new TArray<global::System.IntPtr>(AddrOf(0x98)); // TArray<int32>
        public byte ActiveEnumValue { get => GetAt<byte>(0xA8); set => SetAt(0xA8, value); }
    }

    public class AnimNode_BlendListByInt : StructProxy
    {
        public AnimNode_BlendListByInt(global::System.IntPtr ptr) : base(ptr) {}
        public int ActiveChildIndex { get => GetAt<int>(0x98); set => SetAt(0x98, value); }
    }

    public class AnimNode_BlendSpaceEvaluator : StructProxy
    {
        public AnimNode_BlendSpaceEvaluator(global::System.IntPtr ptr) : base(ptr) {}
        public float NormalizedTime { get => GetAt<float>(0xE0); set => SetAt(0xE0, value); }
    }

    public class AnimNode_BoneDrivenController : StructProxy
    {
        public AnimNode_BoneDrivenController(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference SourceBone => new BoneReference(AddrOf(0xC8));
        public CurveFloat DrivingCurve { get { var __p = GetAt<global::System.IntPtr>(0xD8); return __p==global::System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0xD8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Multiplier { get => GetAt<float>(0xE0); set => SetAt(0xE0, value); }
        public float RangeMin { get => GetAt<float>(0xE4); set => SetAt(0xE4, value); }
        public float RangeMax { get => GetAt<float>(0xE8); set => SetAt(0xE8, value); }
        public float RemappedMin { get => GetAt<float>(0xEC); set => SetAt(0xEC, value); }
        public float RemappedMax { get => GetAt<float>(0xF0); set => SetAt(0xF0, value); }
        public string ParameterName => Native.FNameToString(GetAt<int>(0xF4)); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0xF4); set => SetAt(0xF4, value); }
        public BoneReference TargetBone => new BoneReference(AddrOf(0xFC));
        public EDrivenDestinationMode DestinationMode { get => (EDrivenDestinationMode)GetAt<byte>(0x10C); set => SetAt(0x10C, (byte)value); }
        public EDrivenBoneModificationMode ModificationMode { get => (EDrivenBoneModificationMode)GetAt<byte>(0x10D); set => SetAt(0x10D, (byte)value); }
        public byte SourceComponent { get => GetAt<byte>(0x10E); set => SetAt(0x10E, value); }
        public bool bUseRange { get => (GetAt<byte>(0x10F) & 0x1) != 0; set { var __b = GetAt<byte>(0x10F); SetAt(0x10F, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bAffectTargetTranslationX { get => (GetAt<byte>(0x10F) & 0x2) != 0; set { var __b = GetAt<byte>(0x10F); SetAt(0x10F, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bAffectTargetTranslationY { get => (GetAt<byte>(0x10F) & 0x4) != 0; set { var __b = GetAt<byte>(0x10F); SetAt(0x10F, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bAffectTargetTranslationZ { get => (GetAt<byte>(0x10F) & 0x8) != 0; set { var __b = GetAt<byte>(0x10F); SetAt(0x10F, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bAffectTargetRotationX { get => (GetAt<byte>(0x10F) & 0x10) != 0; set { var __b = GetAt<byte>(0x10F); SetAt(0x10F, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bAffectTargetRotationY { get => (GetAt<byte>(0x10F) & 0x20) != 0; set { var __b = GetAt<byte>(0x10F); SetAt(0x10F, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool bAffectTargetRotationZ { get => (GetAt<byte>(0x10F) & 0x40) != 0; set { var __b = GetAt<byte>(0x10F); SetAt(0x10F, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
        public bool bAffectTargetScaleX { get => (GetAt<byte>(0x10F) & 0x80) != 0; set { var __b = GetAt<byte>(0x10F); SetAt(0x10F, (byte)(value ? (__b | 0x80) : (__b & ~0x80))); } }
        public bool bAffectTargetScaleY { get => (GetAt<byte>(0x110) & 0x1) != 0; set { var __b = GetAt<byte>(0x110); SetAt(0x110, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bAffectTargetScaleZ { get => (GetAt<byte>(0x110) & 0x2) != 0; set { var __b = GetAt<byte>(0x110); SetAt(0x110, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
    }

    public class AnimNode_CCDIK : StructProxy
    {
        public AnimNode_CCDIK(global::System.IntPtr ptr) : base(ptr) {}
        public Vector EffectorLocation => new Vector(AddrOf(0xC8));
        public byte EffectorLocationSpace { get => GetAt<byte>(0xD4); set => SetAt(0xD4, value); }
        public BoneSocketTarget EffectorTarget => new BoneSocketTarget(AddrOf(0xE0));
        public BoneReference TipBone => new BoneReference(AddrOf(0x140));
        public BoneReference RootBone => new BoneReference(AddrOf(0x150));
        public float Precision { get => GetAt<float>(0x160); set => SetAt(0x160, value); }
        public int MaxIterations { get => GetAt<int>(0x164); set => SetAt(0x164, value); }
        public bool bStartFromTail { get => (GetAt<byte>(0x168) & 0xFF) != 0; set { var __b = GetAt<byte>(0x168); SetAt(0x168, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bEnableRotationLimit { get => (GetAt<byte>(0x169) & 0xFF) != 0; set { var __b = GetAt<byte>(0x169); SetAt(0x169, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public TArray<global::System.IntPtr> RotationLimitPerJoints => new TArray<global::System.IntPtr>(AddrOf(0x170)); // TArray<float>
    }

    public class BoneSocketTarget : StructProxy
    {
        public BoneSocketTarget(global::System.IntPtr ptr) : base(ptr) {}
        public bool bUseSocket { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public BoneReference BoneReference => new BoneReference(AddrOf(0x4));
        public SocketReference SocketReference => new SocketReference(AddrOf(0x20));
    }

    public class SocketReference : StructProxy
    {
        public SocketReference(global::System.IntPtr ptr) : base(ptr) {}
        public string SocketName => Native.FNameToString(GetAt<int>(0x30)); // FName
        public FName SocketName_Raw { get => GetAt<FName>(0x30); set => SetAt(0x30, value); }
    }

    public class AnimNode_Constraint : StructProxy
    {
        public AnimNode_Constraint(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference BoneToModify => new BoneReference(AddrOf(0xC8));
        public TArray<global::System.IntPtr> ConstraintSetup => new TArray<global::System.IntPtr>(AddrOf(0xD8)); // TArray<struct>
        public TArray<global::System.IntPtr> ConstraintWeights => new TArray<global::System.IntPtr>(AddrOf(0xE8)); // TArray<float>
    }

    public class Constraint : StructProxy
    {
        public Constraint(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference TargetBone => new BoneReference(AddrOf(0x0));
        public EConstraintOffsetOption OffsetOption { get => (EConstraintOffsetOption)GetAt<byte>(0x10); set => SetAt(0x10, (byte)value); }
        public ETransformConstraintType TransformType { get => (ETransformConstraintType)GetAt<byte>(0x11); set => SetAt(0x11, (byte)value); }
        public FilterOptionPerAxis PerAxis => new FilterOptionPerAxis(AddrOf(0x12));
    }

    public class AnimNode_CopyBone : StructProxy
    {
        public AnimNode_CopyBone(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference SourceBone => new BoneReference(AddrOf(0xC8));
        public BoneReference TargetBone => new BoneReference(AddrOf(0xD8));
        public bool bCopyTranslation { get => (GetAt<byte>(0xE8) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE8); SetAt(0xE8, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bCopyRotation { get => (GetAt<byte>(0xE9) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE9); SetAt(0xE9, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bCopyScale { get => (GetAt<byte>(0xEA) & 0xFF) != 0; set { var __b = GetAt<byte>(0xEA); SetAt(0xEA, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public byte ControlSpace { get => GetAt<byte>(0xEB); set => SetAt(0xEB, value); }
    }

    public class AnimNode_CopyBoneDelta : StructProxy
    {
        public AnimNode_CopyBoneDelta(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference SourceBone => new BoneReference(AddrOf(0xC8));
        public BoneReference TargetBone => new BoneReference(AddrOf(0xD8));
        public bool bCopyTranslation { get => (GetAt<byte>(0xE8) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE8); SetAt(0xE8, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bCopyRotation { get => (GetAt<byte>(0xE9) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE9); SetAt(0xE9, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bCopyScale { get => (GetAt<byte>(0xEA) & 0xFF) != 0; set { var __b = GetAt<byte>(0xEA); SetAt(0xEA, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public CopyBoneDeltaMode CopyMode { get => (CopyBoneDeltaMode)GetAt<byte>(0xEB); set => SetAt(0xEB, (byte)value); }
        public float TranslationMultiplier { get => GetAt<float>(0xEC); set => SetAt(0xEC, value); }
        public float RotationMultiplier { get => GetAt<float>(0xF0); set => SetAt(0xF0, value); }
        public float ScaleMultiplier { get => GetAt<float>(0xF4); set => SetAt(0xF4, value); }
    }

    public class AnimNode_CopyPoseFromMesh : StructProxy
    {
        public AnimNode_CopyPoseFromMesh(global::System.IntPtr ptr) : base(ptr) {}
        public SkeletalMeshComponent SourceMeshComponent { get { var __p = GetAt<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x10, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bUseAttachedParent { get => (GetAt<byte>(0x18) & 0xFF) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bCopyCurves { get => (GetAt<byte>(0x19) & 0xFF) != 0; set { var __b = GetAt<byte>(0x19); SetAt(0x19, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimNode_CurveSource : StructProxy
    {
        public AnimNode_CurveSource(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink SourcePose => new PoseLink(AddrOf(0x10));
        public string SourceBinding => Native.FNameToString(GetAt<int>(0x20)); // FName
        public FName SourceBinding_Raw { get => GetAt<FName>(0x20); set => SetAt(0x20, value); }
        public float alpha { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public UObject CurveSource { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class AnimNode_Fabrik : StructProxy
    {
        public AnimNode_Fabrik(global::System.IntPtr ptr) : base(ptr) {}
        public Transform EffectorTransform => new Transform(AddrOf(0xD0));
        public BoneSocketTarget EffectorTarget => new BoneSocketTarget(AddrOf(0x100));
        public BoneReference TipBone => new BoneReference(AddrOf(0x160));
        public BoneReference RootBone => new BoneReference(AddrOf(0x170));
        public float Precision { get => GetAt<float>(0x180); set => SetAt(0x180, value); }
        public int MaxIterations { get => GetAt<int>(0x184); set => SetAt(0x184, value); }
        public bool AllowStretching { get => (GetAt<byte>(0x188) & 0xFF) != 0; set { var __b = GetAt<byte>(0x188); SetAt(0x188, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool PreventTwistOfLastLink { get => (GetAt<byte>(0x189) & 0xFF) != 0; set { var __b = GetAt<byte>(0x189); SetAt(0x189, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float ApplyLastLinkTwistPercentage { get => GetAt<float>(0x18C); set => SetAt(0x18C, value); }
        public float TwistDegreesToAddToLastLink { get => GetAt<float>(0x190); set => SetAt(0x190, value); }
        public byte EffectorTransformSpace { get => GetAt<byte>(0x194); set => SetAt(0x194, value); }
        public byte EffectorRotationSource { get => GetAt<byte>(0x195); set => SetAt(0x195, value); }
    }

    public class AnimNode_HandIKRetargeting : StructProxy
    {
        public AnimNode_HandIKRetargeting(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference RightHandFK => new BoneReference(AddrOf(0xC8));
        public BoneReference LeftHandFK => new BoneReference(AddrOf(0xD8));
        public BoneReference RightHandIK => new BoneReference(AddrOf(0xE8));
        public BoneReference LeftHandIK => new BoneReference(AddrOf(0xF8));
        public TArray<global::System.IntPtr> IKBonesToMove => new TArray<global::System.IntPtr>(AddrOf(0x108)); // TArray<struct>
        public float HandFKWeight { get => GetAt<float>(0x118); set => SetAt(0x118, value); }
    }

    public class AnimNode_LayeredBoneBlend : StructProxy
    {
        public AnimNode_LayeredBoneBlend(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink BasePose => new PoseLink(AddrOf(0x10));
        public TArray<global::System.IntPtr> BlendPoses => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<struct>
        public TArray<global::System.IntPtr> LayerSetup => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public TArray<global::System.IntPtr> BlendWeights => new TArray<global::System.IntPtr>(AddrOf(0x40)); // TArray<float>
        public bool bMeshSpaceRotationBlend { get => (GetAt<byte>(0x50) & 0xFF) != 0; set { var __b = GetAt<byte>(0x50); SetAt(0x50, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bMeshSpaceScaleBlend { get => (GetAt<byte>(0x51) & 0xFF) != 0; set { var __b = GetAt<byte>(0x51); SetAt(0x51, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public byte CurveBlendOption { get => GetAt<byte>(0x52); set => SetAt(0x52, value); }
        public bool bBlendRootMotionBasedOnRootBone { get => (GetAt<byte>(0x53) & 0xFF) != 0; set { var __b = GetAt<byte>(0x53); SetAt(0x53, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int LODThreshold { get => GetAt<int>(0x58); set => SetAt(0x58, value); }
        public TArray<global::System.IntPtr> PerBoneBlendWeights => new TArray<global::System.IntPtr>(AddrOf(0x60)); // TArray<struct>
        public Guid SkeletonGuid => new Guid(AddrOf(0x70));
        public Guid VirtualBoneGuid => new Guid(AddrOf(0x80));
    }

    public class AnimNode_LegIK : StructProxy
    {
        public AnimNode_LegIK(global::System.IntPtr ptr) : base(ptr) {}
        public float ReachPrecision { get => GetAt<float>(0xC8); set => SetAt(0xC8, value); }
        public int MaxIterations { get => GetAt<int>(0xCC); set => SetAt(0xCC, value); }
        public TArray<global::System.IntPtr> LegsDefinition => new TArray<global::System.IntPtr>(AddrOf(0xD0)); // TArray<struct>
    }

    public class AnimLegIKDefinition : StructProxy
    {
        public AnimLegIKDefinition(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference IKFootBone => new BoneReference(AddrOf(0x0));
        public BoneReference FKFootBone => new BoneReference(AddrOf(0x10));
        public int NumBonesInLimb { get => GetAt<int>(0x20); set => SetAt(0x20, value); }
        public float MinRotationAngle { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public byte FootBoneForwardAxis { get => GetAt<byte>(0x28); set => SetAt(0x28, value); }
        public byte HingeRotationAxis { get => GetAt<byte>(0x29); set => SetAt(0x29, value); }
        public bool bEnableRotationLimit { get => (GetAt<byte>(0x2A) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2A); SetAt(0x2A, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bEnableKneeTwistCorrection { get => (GetAt<byte>(0x2B) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2B); SetAt(0x2B, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimLegIKData : StructProxy
    {
        public AnimLegIKData(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class IKChain : StructProxy
    {
        public IKChain(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class IKChainLink : StructProxy
    {
        public IKChainLink(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class AnimNode_LookAt : StructProxy
    {
        public AnimNode_LookAt(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference BoneToModify => new BoneReference(AddrOf(0xC8));
        public BoneSocketTarget LookAtTarget => new BoneSocketTarget(AddrOf(0xE0));
        public Vector LookAtLocation => new Vector(AddrOf(0x140));
        public Axis LookAt_Axis => new Axis(AddrOf(0x14C));
        public bool bUseLookUpAxis { get => (GetAt<byte>(0x15C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x15C); SetAt(0x15C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public byte InterpolationType { get => GetAt<byte>(0x15D); set => SetAt(0x15D, value); }
        public Axis LookUp_Axis => new Axis(AddrOf(0x160));
        public float LookAtClamp { get => GetAt<float>(0x170); set => SetAt(0x170, value); }
        public float InterpolationTime { get => GetAt<float>(0x174); set => SetAt(0x174, value); }
        public float InterpolationTriggerThreashold { get => GetAt<float>(0x178); set => SetAt(0x178, value); }
    }

    public class AnimNode_MakeDynamicAdditive : StructProxy
    {
        public AnimNode_MakeDynamicAdditive(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink Base => new PoseLink(AddrOf(0x10));
        public PoseLink Additive => new PoseLink(AddrOf(0x20));
        public bool bMeshSpaceAdditive { get => (GetAt<byte>(0x30) & 0xFF) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimNode_ModifyBone : StructProxy
    {
        public AnimNode_ModifyBone(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference BoneToModify => new BoneReference(AddrOf(0xC8));
        public Vector Translation => new Vector(AddrOf(0xD8));
        public Rotator Rotation => new Rotator(AddrOf(0xE4));
        public Vector Scale => new Vector(AddrOf(0xF0));
        public byte TranslationMode { get => GetAt<byte>(0xFC); set => SetAt(0xFC, value); }
        public byte RotationMode { get => GetAt<byte>(0xFD); set => SetAt(0xFD, value); }
        public byte ScaleMode { get => GetAt<byte>(0xFE); set => SetAt(0xFE, value); }
        public byte TranslationSpace { get => GetAt<byte>(0xFF); set => SetAt(0xFF, value); }
        public byte RotationSpace { get => GetAt<byte>(0x100); set => SetAt(0x100, value); }
        public byte ScaleSpace { get => GetAt<byte>(0x101); set => SetAt(0x101, value); }
    }

    public class AnimNode_ModifyCurve : StructProxy
    {
        public AnimNode_ModifyCurve(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink SourcePose => new PoseLink(AddrOf(0x10));
        public TArray<global::System.IntPtr> CurveValues => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<float>
        public TArray<global::System.IntPtr> CurveNames => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<FName>
        public float alpha { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
        public EModifyCurveApplyMode ApplyMode { get => (EModifyCurveApplyMode)GetAt<byte>(0x54); set => SetAt(0x54, (byte)value); }
    }

    public class AnimNode_MultiWayBlend : StructProxy
    {
        public AnimNode_MultiWayBlend(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Poses => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<global::System.IntPtr> DesiredAlphas => new TArray<global::System.IntPtr>(AddrOf(0x20)); // TArray<float>
        public InputScaleBias AlphaScaleBias => new InputScaleBias(AddrOf(0x40));
        public bool bAdditiveNode { get => (GetAt<byte>(0x48) & 0xFF) != 0; set { var __b = GetAt<byte>(0x48); SetAt(0x48, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bNormalizeAlpha { get => (GetAt<byte>(0x49) & 0xFF) != 0; set { var __b = GetAt<byte>(0x49); SetAt(0x49, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimNode_ObserveBone : StructProxy
    {
        public AnimNode_ObserveBone(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference BoneToObserve => new BoneReference(AddrOf(0xC8));
        public byte DisplaySpace { get => GetAt<byte>(0xD8); set => SetAt(0xD8, value); }
        public bool bRelativeToRefPose { get => (GetAt<byte>(0xD9) & 0xFF) != 0; set { var __b = GetAt<byte>(0xD9); SetAt(0xD9, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public Vector Translation => new Vector(AddrOf(0xDC));
        public Rotator Rotation => new Rotator(AddrOf(0xE8));
        public Vector Scale => new Vector(AddrOf(0xF4));
    }

    public class AnimNode_PoseHandler : StructProxy
    {
        public AnimNode_PoseHandler(global::System.IntPtr ptr) : base(ptr) {}
        public PoseAsset PoseAsset { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new PoseAsset(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class AnimNode_PoseBlendNode : StructProxy
    {
        public AnimNode_PoseBlendNode(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink SourcePose => new PoseLink(AddrOf(0x78));
        public EAlphaBlendOption BlendOption { get => (EAlphaBlendOption)GetAt<byte>(0x88); set => SetAt(0x88, (byte)value); }
        public CurveFloat CustomCurve { get { var __p = GetAt<global::System.IntPtr>(0x90); return __p==global::System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x90, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class AnimNode_PoseByName : StructProxy
    {
        public AnimNode_PoseByName(global::System.IntPtr ptr) : base(ptr) {}
        public string PoseName => Native.FNameToString(GetAt<int>(0x78)); // FName
        public FName PoseName_Raw { get => GetAt<FName>(0x78); set => SetAt(0x78, value); }
        public float PoseWeight { get => GetAt<float>(0x80); set => SetAt(0x80, value); }
    }

    public class AnimNode_PoseDriver : StructProxy
    {
        public AnimNode_PoseDriver(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink SourcePose => new PoseLink(AddrOf(0x78));
        public TArray<global::System.IntPtr> SourceBones => new TArray<global::System.IntPtr>(AddrOf(0x88)); // TArray<struct>
        public TArray<global::System.IntPtr> OnlyDriveBones => new TArray<global::System.IntPtr>(AddrOf(0x98)); // TArray<struct>
        public TArray<global::System.IntPtr> PoseTargets => new TArray<global::System.IntPtr>(AddrOf(0xA8)); // TArray<struct>
        public BoneReference EvalSpaceBone => new BoneReference(AddrOf(0xE8));
        public RBFParams RBFParams => new RBFParams(AddrOf(0xF8));
        public EPoseDriverSource DriveSource { get => (EPoseDriverSource)GetAt<byte>(0x124); set => SetAt(0x124, (byte)value); }
        public EPoseDriverOutput DriveOutput { get => (EPoseDriverOutput)GetAt<byte>(0x125); set => SetAt(0x125, (byte)value); }
        public bool bOnlyDriveSelectedBones { get => (GetAt<byte>(0x126) & 0x1) != 0; set { var __b = GetAt<byte>(0x126); SetAt(0x126, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class RBFParams : StructProxy
    {
        public RBFParams(global::System.IntPtr ptr) : base(ptr) {}
        public int TargetDimensions { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public ERBFSolverType SolverType { get => (ERBFSolverType)GetAt<byte>(0x4); set => SetAt(0x4, (byte)value); }
        public float Radius { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public ERBFFunctionType Function { get => (ERBFFunctionType)GetAt<byte>(0xC); set => SetAt(0xC, (byte)value); }
        public ERBFDistanceMethod DistanceMethod { get => (ERBFDistanceMethod)GetAt<byte>(0xD); set => SetAt(0xD, (byte)value); }
        public byte TwistAxis { get => GetAt<byte>(0xE); set => SetAt(0xE, value); }
        public float WeightThreshold { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public ERBFNormalizeMethod NormalizeMethod { get => (ERBFNormalizeMethod)GetAt<byte>(0x14); set => SetAt(0x14, (byte)value); }
        public Vector MedianReference => new Vector(AddrOf(0x18));
        public float MedianMin { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public float MedianMax { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
    }

    public class PoseDriverTarget : StructProxy
    {
        public PoseDriverTarget(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> BoneTransforms => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public Rotator TargetRotation => new Rotator(AddrOf(0x10));
        public float TargetScale { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public ERBFDistanceMethod DistanceMethod { get => (ERBFDistanceMethod)GetAt<byte>(0x20); set => SetAt(0x20, (byte)value); }
        public ERBFFunctionType FunctionType { get => (ERBFFunctionType)GetAt<byte>(0x21); set => SetAt(0x21, (byte)value); }
        public bool bApplyCustomCurve { get => (GetAt<byte>(0x22) & 0xFF) != 0; set { var __b = GetAt<byte>(0x22); SetAt(0x22, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public RichCurve CustomCurve => new RichCurve(AddrOf(0x28));
        public string DrivenName => Native.FNameToString(GetAt<int>(0xA8)); // FName
        public FName DrivenName_Raw { get => GetAt<FName>(0xA8); set => SetAt(0xA8, value); }
        public bool bIsHidden { get => (GetAt<byte>(0xB8) & 0xFF) != 0; set { var __b = GetAt<byte>(0xB8); SetAt(0xB8, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class PoseDriverTransform : StructProxy
    {
        public PoseDriverTransform(global::System.IntPtr ptr) : base(ptr) {}
        public Vector TargetTranslation => new Vector(AddrOf(0x0));
        public Rotator TargetRotation => new Rotator(AddrOf(0xC));
    }

    public class AnimNode_PoseSnapshot : StructProxy
    {
        public AnimNode_PoseSnapshot(global::System.IntPtr ptr) : base(ptr) {}
        public string SnapshotName => Native.FNameToString(GetAt<int>(0x10)); // FName
        public FName SnapshotName_Raw { get => GetAt<FName>(0x10); set => SetAt(0x10, value); }
        public PoseSnapshot Snapshot => new PoseSnapshot(AddrOf(0x18));
        public ESnapshotSourceMode Mode { get => (ESnapshotSourceMode)GetAt<byte>(0x50); set => SetAt(0x50, (byte)value); }
    }

    public class AnimNode_RandomPlayer : StructProxy
    {
        public AnimNode_RandomPlayer(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Entries => new TArray<global::System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public bool bShuffleMode { get => (GetAt<byte>(0x70) & 0xFF) != 0; set { var __b = GetAt<byte>(0x70); SetAt(0x70, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class RandomPlayerSequenceEntry : StructProxy
    {
        public RandomPlayerSequenceEntry(global::System.IntPtr ptr) : base(ptr) {}
        public AnimSequence Sequence { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new AnimSequence(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float ChanceToPlay { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public int MinLoopCount { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
        public int MaxLoopCount { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
        public float MinPlayRate { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public float MaxPlayRate { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
        public AlphaBlend BlendIn => new AlphaBlend(AddrOf(0x20));
    }

    public class AnimNode_MeshSpaceRefPose : StructProxy
    {
        public AnimNode_MeshSpaceRefPose(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class AnimNode_RefPose : StructProxy
    {
        public AnimNode_RefPose(global::System.IntPtr ptr) : base(ptr) {}
        public byte RefPoseType { get => GetAt<byte>(0x10); set => SetAt(0x10, value); }
    }

    public class AnimNode_ResetRoot : StructProxy
    {
        public AnimNode_ResetRoot(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class AnimNode_RigidBody : StructProxy
    {
        public AnimNode_RigidBody(global::System.IntPtr ptr) : base(ptr) {}
        public PhysicsAsset OverridePhysicsAsset { get { var __p = GetAt<global::System.IntPtr>(0xC8); return __p==global::System.IntPtr.Zero?null:new PhysicsAsset(__p); } set => SetAt(0xC8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vector OverrideWorldGravity => new Vector(AddrOf(0x168));
        public Vector ExternalForce => new Vector(AddrOf(0x174));
        public Vector ComponentLinearAccScale => new Vector(AddrOf(0x180));
        public Vector ComponentLinearVelScale => new Vector(AddrOf(0x18C));
        public Vector ComponentAppliedLinearAccClamp => new Vector(AddrOf(0x198));
        public float CachedBoundsScale { get => GetAt<float>(0x1A4); set => SetAt(0x1A4, value); }
        public BoneReference BaseBoneRef => new BoneReference(AddrOf(0x1A8));
        public byte OverlapChannel { get => GetAt<byte>(0x1B8); set => SetAt(0x1B8, value); }
        public ESimulationSpace SimulationSpace { get => (ESimulationSpace)GetAt<byte>(0x1B9); set => SetAt(0x1B9, (byte)value); }
        public bool bForceDisableCollisionBetweenConstraintBodies { get => (GetAt<byte>(0x1BA) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1BA); SetAt(0x1BA, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bEnableWorldGeometry { get => (GetAt<byte>(0x1BC) & 0x1) != 0; set { var __b = GetAt<byte>(0x1BC); SetAt(0x1BC, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bOverrideWorldGravity { get => (GetAt<byte>(0x1BC) & 0x2) != 0; set { var __b = GetAt<byte>(0x1BC); SetAt(0x1BC, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bTransferBoneVelocities { get => (GetAt<byte>(0x1BC) & 0x4) != 0; set { var __b = GetAt<byte>(0x1BC); SetAt(0x1BC, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bFreezeIncomingPoseOnStart { get => (GetAt<byte>(0x1BC) & 0x8) != 0; set { var __b = GetAt<byte>(0x1BC); SetAt(0x1BC, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bClampLinearTranslationLimitToRefPose { get => (GetAt<byte>(0x1BC) & 0x10) != 0; set { var __b = GetAt<byte>(0x1BC); SetAt(0x1BC, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public SolverIterations OverrideSolverIterations => new SolverIterations(AddrOf(0x1C0));
    }

    public class AnimNode_RigidBody_Chaos : StructProxy
    {
        public AnimNode_RigidBody_Chaos(global::System.IntPtr ptr) : base(ptr) {}
        public PhysicsAsset OverridePhysicsAsset { get { var __p = GetAt<global::System.IntPtr>(0xC8); return __p==global::System.IntPtr.Zero?null:new PhysicsAsset(__p); } set => SetAt(0xC8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vector OverrideWorldGravity => new Vector(AddrOf(0xD0));
        public Vector ExternalForce => new Vector(AddrOf(0xDC));
        public Vector ComponentLinearAccScale => new Vector(AddrOf(0xE8));
        public Vector ComponentLinearVelScale => new Vector(AddrOf(0xF4));
        public Vector ComponentAppliedLinearAccClamp => new Vector(AddrOf(0x100));
        public float CachedBoundsScale { get => GetAt<float>(0x10C); set => SetAt(0x10C, value); }
        public BoneReference BaseBoneRef => new BoneReference(AddrOf(0x110));
        public byte OverlapChannel { get => GetAt<byte>(0x120); set => SetAt(0x120, value); }
        public ESimulationSpace SimulationSpace { get => (ESimulationSpace)GetAt<byte>(0x121); set => SetAt(0x121, (byte)value); }
        public bool bForceDisableCollisionBetweenConstraintBodies { get => (GetAt<byte>(0x122) & 0xFF) != 0; set { var __b = GetAt<byte>(0x122); SetAt(0x122, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bEnableWorldGeometry { get => (GetAt<byte>(0x123) & 0x1) != 0; set { var __b = GetAt<byte>(0x123); SetAt(0x123, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bOverrideWorldGravity { get => (GetAt<byte>(0x123) & 0x2) != 0; set { var __b = GetAt<byte>(0x123); SetAt(0x123, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bTransferBoneVelocities { get => (GetAt<byte>(0x123) & 0x4) != 0; set { var __b = GetAt<byte>(0x123); SetAt(0x123, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bFreezeIncomingPoseOnStart { get => (GetAt<byte>(0x123) & 0x8) != 0; set { var __b = GetAt<byte>(0x123); SetAt(0x123, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bClampLinearTranslationLimitToRefPose { get => (GetAt<byte>(0x123) & 0x10) != 0; set { var __b = GetAt<byte>(0x123); SetAt(0x123, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public SolverIterations OverrideSolverIterations => new SolverIterations(AddrOf(0x124));
    }

    public class AnimNode_RotateRootBone : StructProxy
    {
        public AnimNode_RotateRootBone(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink BasePose => new PoseLink(AddrOf(0x10));
        public float Pitch { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public float Yaw { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public InputScaleBiasClamp PitchScaleBiasClamp => new InputScaleBiasClamp(AddrOf(0x28));
        public InputScaleBiasClamp YawScaleBiasClamp => new InputScaleBiasClamp(AddrOf(0x58));
        public Rotator MeshToComponent => new Rotator(AddrOf(0x88));
    }

    public class AnimNode_RotationMultiplier : StructProxy
    {
        public AnimNode_RotationMultiplier(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference TargetBone => new BoneReference(AddrOf(0xC8));
        public BoneReference SourceBone => new BoneReference(AddrOf(0xD8));
        public float Multiplier { get => GetAt<float>(0xE8); set => SetAt(0xE8, value); }
        public byte RotationAxisToRefer { get => GetAt<byte>(0xEC); set => SetAt(0xEC, value); }
        public bool bIsAdditive { get => (GetAt<byte>(0xED) & 0xFF) != 0; set { var __b = GetAt<byte>(0xED); SetAt(0xED, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimNode_RotationOffsetBlendSpace : StructProxy
    {
        public AnimNode_RotationOffsetBlendSpace(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink BasePose => new PoseLink(AddrOf(0xE0));
        public int LODThreshold { get => GetAt<int>(0xF0); set => SetAt(0xF0, value); }
        public float alpha { get => GetAt<float>(0xF4); set => SetAt(0xF4, value); }
        public InputScaleBias AlphaScaleBias => new InputScaleBias(AddrOf(0xF8));
        public InputAlphaBoolBlend AlphaBoolBlend => new InputAlphaBoolBlend(AddrOf(0x100));
        public string AlphaCurveName => Native.FNameToString(GetAt<int>(0x148)); // FName
        public FName AlphaCurveName_Raw { get => GetAt<FName>(0x148); set => SetAt(0x148, value); }
        public InputScaleBiasClamp AlphaScaleBiasClamp => new InputScaleBiasClamp(AddrOf(0x150));
        public EAnimAlphaInputType AlphaInputType { get => (EAnimAlphaInputType)GetAt<byte>(0x184); set => SetAt(0x184, (byte)value); }
        public bool bAlphaBoolEnabled { get => (GetAt<byte>(0x185) & 0xFF) != 0; set { var __b = GetAt<byte>(0x185); SetAt(0x185, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimNode_ScaleChainLength : StructProxy
    {
        public AnimNode_ScaleChainLength(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink InputPose => new PoseLink(AddrOf(0x10));
        public float DefaultChainLength { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public BoneReference ChainStartBone => new BoneReference(AddrOf(0x24));
        public BoneReference ChainEndBone => new BoneReference(AddrOf(0x34));
        public Vector TargetLocation => new Vector(AddrOf(0x44));
        public float alpha { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
        public InputScaleBias AlphaScaleBias => new InputScaleBias(AddrOf(0x58));
        public EScaleChainInitialLength ChainInitialLength { get => (EScaleChainInitialLength)GetAt<byte>(0x60); set => SetAt(0x60, (byte)value); }
    }

    public class AnimNode_SequenceEvaluator : StructProxy
    {
        public AnimNode_SequenceEvaluator(global::System.IntPtr ptr) : base(ptr) {}
        public AnimSequenceBase Sequence { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new AnimSequenceBase(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float ExplicitTime { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public bool bShouldLoop { get => (GetAt<byte>(0x3C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bTeleportToExplicitTime { get => (GetAt<byte>(0x3D) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3D); SetAt(0x3D, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public byte ReinitializationBehavior { get => GetAt<byte>(0x3E); set => SetAt(0x3E, value); }
        public float StartPosition { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
    }

    public class AnimNode_Slot : StructProxy
    {
        public AnimNode_Slot(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink Source => new PoseLink(AddrOf(0x10));
        public string SlotName => Native.FNameToString(GetAt<int>(0x20)); // FName
        public FName SlotName_Raw { get => GetAt<FName>(0x20); set => SetAt(0x20, value); }
        public bool bAlwaysUpdateSourcePose { get => (GetAt<byte>(0x28) & 0xFF) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimNode_SplineIK : StructProxy
    {
        public AnimNode_SplineIK(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference StartBone => new BoneReference(AddrOf(0xC8));
        public BoneReference EndBone => new BoneReference(AddrOf(0xD8));
        public ESplineBoneAxis BoneAxis { get => (ESplineBoneAxis)GetAt<byte>(0xE8); set => SetAt(0xE8, (byte)value); }
        public bool bAutoCalculateSpline { get => (GetAt<byte>(0xE9) & 0xFF) != 0; set { var __b = GetAt<byte>(0xE9); SetAt(0xE9, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int PointCount { get => GetAt<int>(0xEC); set => SetAt(0xEC, value); }
        public TArray<global::System.IntPtr> ControlPoints => new TArray<global::System.IntPtr>(AddrOf(0xF0)); // TArray<struct>
        public float Roll { get => GetAt<float>(0x100); set => SetAt(0x100, value); }
        public float TwistStart { get => GetAt<float>(0x104); set => SetAt(0x104, value); }
        public float TwistEnd { get => GetAt<float>(0x108); set => SetAt(0x108, value); }
        public AlphaBlend TwistBlend => new AlphaBlend(AddrOf(0x110));
        public float Stretch { get => GetAt<float>(0x140); set => SetAt(0x140, value); }
        public float Offset { get => GetAt<float>(0x144); set => SetAt(0x144, value); }
    }

    public class SplineIKCachedBoneData : StructProxy
    {
        public SplineIKCachedBoneData(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference Bone => new BoneReference(AddrOf(0x0));
        public int RefSkeletonIndex { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
    }

    public class AnimNode_SpringBone : StructProxy
    {
        public AnimNode_SpringBone(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference SpringBone => new BoneReference(AddrOf(0xC8));
        public float MaxDisplacement { get => GetAt<float>(0xD8); set => SetAt(0xD8, value); }
        public float SpringStiffness { get => GetAt<float>(0xDC); set => SetAt(0xDC, value); }
        public float SpringDamping { get => GetAt<float>(0xE0); set => SetAt(0xE0, value); }
        public float ErrorResetThresh { get => GetAt<float>(0xE4); set => SetAt(0xE4, value); }
        public bool bLimitDisplacement { get => (GetAt<byte>(0x124) & 0x1) != 0; set { var __b = GetAt<byte>(0x124); SetAt(0x124, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bTranslateX { get => (GetAt<byte>(0x124) & 0x2) != 0; set { var __b = GetAt<byte>(0x124); SetAt(0x124, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bTranslateY { get => (GetAt<byte>(0x124) & 0x4) != 0; set { var __b = GetAt<byte>(0x124); SetAt(0x124, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bTranslateZ { get => (GetAt<byte>(0x124) & 0x8) != 0; set { var __b = GetAt<byte>(0x124); SetAt(0x124, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bRotateX { get => (GetAt<byte>(0x124) & 0x10) != 0; set { var __b = GetAt<byte>(0x124); SetAt(0x124, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bRotateY { get => (GetAt<byte>(0x124) & 0x20) != 0; set { var __b = GetAt<byte>(0x124); SetAt(0x124, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool bRotateZ { get => (GetAt<byte>(0x124) & 0x40) != 0; set { var __b = GetAt<byte>(0x124); SetAt(0x124, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
    }

    public class AnimNode_StateResult : StructProxy
    {
        public AnimNode_StateResult(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class AnimNode_Trail : StructProxy
    {
        public AnimNode_Trail(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference TrailBone => new BoneReference(AddrOf(0x100));
        public int ChainLength { get => GetAt<int>(0x110); set => SetAt(0x110, value); }
        public byte ChainBoneAxis { get => GetAt<byte>(0x114); set => SetAt(0x114, value); }
        public bool bInvertChainBoneAxis { get => (GetAt<byte>(0x115) & 0x1) != 0; set { var __b = GetAt<byte>(0x115); SetAt(0x115, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bLimitStretch { get => (GetAt<byte>(0x115) & 0x2) != 0; set { var __b = GetAt<byte>(0x115); SetAt(0x115, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bLimitRotation { get => (GetAt<byte>(0x115) & 0x4) != 0; set { var __b = GetAt<byte>(0x115); SetAt(0x115, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bUsePlanarLimit { get => (GetAt<byte>(0x115) & 0x8) != 0; set { var __b = GetAt<byte>(0x115); SetAt(0x115, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bActorSpaceFakeVel { get => (GetAt<byte>(0x115) & 0x10) != 0; set { var __b = GetAt<byte>(0x115); SetAt(0x115, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bReorientParentToChild { get => (GetAt<byte>(0x115) & 0x20) != 0; set { var __b = GetAt<byte>(0x115); SetAt(0x115, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public float MaxDeltaTime { get => GetAt<float>(0x118); set => SetAt(0x118, value); }
        public float RelaxationSpeedScale { get => GetAt<float>(0x11C); set => SetAt(0x11C, value); }
        public RuntimeFloatCurve TrailRelaxationSpeed => new RuntimeFloatCurve(AddrOf(0x120));
        public InputScaleBiasClamp RelaxationSpeedScaleInputProcessor => new InputScaleBiasClamp(AddrOf(0x1A8));
        public TArray<global::System.IntPtr> RotationLimits => new TArray<global::System.IntPtr>(AddrOf(0x1D8)); // TArray<struct>
        public TArray<global::System.IntPtr> RotationOffsets => new TArray<global::System.IntPtr>(AddrOf(0x1E8)); // TArray<struct>
        public TArray<global::System.IntPtr> PlanarLimits => new TArray<global::System.IntPtr>(AddrOf(0x1F8)); // TArray<struct>
        public float StretchLimit { get => GetAt<float>(0x208); set => SetAt(0x208, value); }
        public Vector FakeVelocity => new Vector(AddrOf(0x20C));
        public BoneReference BaseJoint => new BoneReference(AddrOf(0x218));
        public float LastBoneRotationAnimAlphaBlend { get => GetAt<float>(0x228); set => SetAt(0x228, value); }
    }

    public class RotationLimit : StructProxy
    {
        public RotationLimit(global::System.IntPtr ptr) : base(ptr) {}
        public Vector LimitMin => new Vector(AddrOf(0x0));
        public Vector LimitMax => new Vector(AddrOf(0xC));
    }

    public class AnimNode_TwistCorrectiveNode : StructProxy
    {
        public AnimNode_TwistCorrectiveNode(global::System.IntPtr ptr) : base(ptr) {}
        public ReferenceBoneFrame BaseFrame => new ReferenceBoneFrame(AddrOf(0xC8));
        public ReferenceBoneFrame TwistFrame => new ReferenceBoneFrame(AddrOf(0xE8));
        public Axis TwistPlaneNormalAxis => new Axis(AddrOf(0x108));
        public float RangeMax { get => GetAt<float>(0x118); set => SetAt(0x118, value); }
        public float RemappedMin { get => GetAt<float>(0x11C); set => SetAt(0x11C, value); }
        public float RemappedMax { get => GetAt<float>(0x120); set => SetAt(0x120, value); }
        public AnimCurveParam Curve => new AnimCurveParam(AddrOf(0x124));
    }

    public class ReferenceBoneFrame : StructProxy
    {
        public ReferenceBoneFrame(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference Bone => new BoneReference(AddrOf(0x0));
        public Axis Axis => new Axis(AddrOf(0x10));
    }

    public class AnimNode_TwoBoneIK : StructProxy
    {
        public AnimNode_TwoBoneIK(global::System.IntPtr ptr) : base(ptr) {}
        public BoneReference IKBone => new BoneReference(AddrOf(0xC8));
        public float StartStretchRatio { get => GetAt<float>(0xD8); set => SetAt(0xD8, value); }
        public float MaxStretchScale { get => GetAt<float>(0xDC); set => SetAt(0xDC, value); }
        public Vector EffectorLocation => new Vector(AddrOf(0xE0));
        public BoneSocketTarget EffectorTarget => new BoneSocketTarget(AddrOf(0xF0));
        public Vector JointTargetLocation => new Vector(AddrOf(0x150));
        public BoneSocketTarget JointTarget => new BoneSocketTarget(AddrOf(0x160));
        public Axis TwistAxis => new Axis(AddrOf(0x1C0));
        public byte EffectorLocationSpace { get => GetAt<byte>(0x1D0); set => SetAt(0x1D0, value); }
        public byte JointTargetLocationSpace { get => GetAt<byte>(0x1D1); set => SetAt(0x1D1, value); }
        public bool bAllowStretching { get => (GetAt<byte>(0x1D2) & 0x1) != 0; set { var __b = GetAt<byte>(0x1D2); SetAt(0x1D2, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bTakeRotationFromEffectorSpace { get => (GetAt<byte>(0x1D2) & 0x2) != 0; set { var __b = GetAt<byte>(0x1D2); SetAt(0x1D2, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bMaintainEffectorRelRot { get => (GetAt<byte>(0x1D2) & 0x4) != 0; set { var __b = GetAt<byte>(0x1D2); SetAt(0x1D2, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bAllowTwist { get => (GetAt<byte>(0x1D2) & 0x8) != 0; set { var __b = GetAt<byte>(0x1D2); SetAt(0x1D2, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
    }

    public class AnimNode_TwoWayBlend : StructProxy
    {
        public AnimNode_TwoWayBlend(global::System.IntPtr ptr) : base(ptr) {}
        public PoseLink A => new PoseLink(AddrOf(0x10));
        public PoseLink B => new PoseLink(AddrOf(0x20));
        public EAnimAlphaInputType AlphaInputType { get => (EAnimAlphaInputType)GetAt<byte>(0x30); set => SetAt(0x30, (byte)value); }
        public bool bAlphaBoolEnabled { get => (GetAt<byte>(0x31) & 0x1) != 0; set { var __b = GetAt<byte>(0x31); SetAt(0x31, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bResetChildOnActivation { get => (GetAt<byte>(0x31) & 0x8) != 0; set { var __b = GetAt<byte>(0x31); SetAt(0x31, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public float alpha { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public InputScaleBias AlphaScaleBias => new InputScaleBias(AddrOf(0x38));
        public InputAlphaBoolBlend AlphaBoolBlend => new InputAlphaBoolBlend(AddrOf(0x40));
        public string AlphaCurveName => Native.FNameToString(GetAt<int>(0x88)); // FName
        public FName AlphaCurveName_Raw { get => GetAt<FName>(0x88); set => SetAt(0x88, value); }
        public InputScaleBiasClamp AlphaScaleBiasClamp => new InputScaleBiasClamp(AddrOf(0x90));
    }

    public class AnimSequencerInstanceProxy : StructProxy
    {
        public AnimSequencerInstanceProxy(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class PositionHistory : StructProxy
    {
        public PositionHistory(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Positions => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public float Range { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
    }

    public class RBFEntry : StructProxy
    {
        public RBFEntry(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Values => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<float>
    }

    public class RBFTarget : StructProxy
    {
        public RBFTarget(global::System.IntPtr ptr) : base(ptr) {}
        public float ScaleFactor { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public bool bApplyCustomCurve { get => (GetAt<byte>(0x14) & 0xFF) != 0; set { var __b = GetAt<byte>(0x14); SetAt(0x14, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public RichCurve CustomCurve => new RichCurve(AddrOf(0x18));
        public ERBFDistanceMethod DistanceMethod { get => (ERBFDistanceMethod)GetAt<byte>(0x98); set => SetAt(0x98, (byte)value); }
        public ERBFFunctionType FunctionType { get => (ERBFFunctionType)GetAt<byte>(0x99); set => SetAt(0x99, (byte)value); }
    }

    public class AnimNotify_PlayMontageNotify : AnimNotify
    {
        public const string UeClassName = "AnimNotify_PlayMontageNotify";
        public AnimNotify_PlayMontageNotify(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimNotify_PlayMontageNotify FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimNotify_PlayMontageNotify(p);
        public static AnimNotify_PlayMontageNotify FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimNotify_PlayMontageNotify(o.Pointer); }
        public static AnimNotify_PlayMontageNotify[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimNotify_PlayMontageNotify[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimNotify_PlayMontageNotify(a[i].Pointer); return r; }
        public string NotifyName => Native.GetPropName(Pointer, "NotifyName"); // FName
        public FName NotifyName_Raw { get => GetAt<FName>(0x38); set => SetAt(0x38, value); }
    }

    public class AnimNotify_PlayMontageNotifyWindow : AnimNotifyState
    {
        public const string UeClassName = "AnimNotify_PlayMontageNotifyWindow";
        public AnimNotify_PlayMontageNotifyWindow(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimNotify_PlayMontageNotifyWindow FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimNotify_PlayMontageNotifyWindow(p);
        public static AnimNotify_PlayMontageNotifyWindow FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimNotify_PlayMontageNotifyWindow(o.Pointer); }
        public static AnimNotify_PlayMontageNotifyWindow[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimNotify_PlayMontageNotifyWindow[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimNotify_PlayMontageNotifyWindow(a[i].Pointer); return r; }
        public string NotifyName => Native.GetPropName(Pointer, "NotifyName"); // FName
        public FName NotifyName_Raw { get => GetAt<FName>(0x2C); set => SetAt(0x2C, value); }
    }

    public class AnimSequencerInstance : AnimInstance
    {
        public const string UeClassName = "AnimSequencerInstance";
        public AnimSequencerInstance(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimSequencerInstance FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimSequencerInstance(p);
        public static AnimSequencerInstance FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimSequencerInstance(o.Pointer); }
        public static AnimSequencerInstance[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimSequencerInstance[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimSequencerInstance(a[i].Pointer); return r; }
    }

    public class KismetAnimationLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "KismetAnimationLibrary";
        public KismetAnimationLibrary(global::System.IntPtr ptr) : base(ptr) {}
        public static new KismetAnimationLibrary FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new KismetAnimationLibrary(p);
        public static KismetAnimationLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new KismetAnimationLibrary(o.Pointer); }
        public static KismetAnimationLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new KismetAnimationLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new KismetAnimationLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7C482A8 — hookable via Hooks.InstallAt(NativeFunc_K2_TwoBoneIK).</summary>
        public static global::System.IntPtr NativeFunc_K2_TwoBoneIK => Memory.ModuleBase() + 0x7C482A8;
        public void K2_TwoBoneIK(global::System.IntPtr RootPos, global::System.IntPtr JointPos, global::System.IntPtr EndPos, global::System.IntPtr JointTarget, global::System.IntPtr Effector, global::System.IntPtr OutJointPos, global::System.IntPtr OutEndPos, bool bAllowStretching, float StartStretchRatio, float MaxStretchScale)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<global::System.IntPtr>(0x0, RootPos);
            __pb.Set<global::System.IntPtr>(0xC, JointPos);
            __pb.Set<global::System.IntPtr>(0x18, EndPos);
            __pb.Set<global::System.IntPtr>(0x24, JointTarget);
            __pb.Set<global::System.IntPtr>(0x30, Effector);
            __pb.Set<global::System.IntPtr>(0x3C, OutJointPos);
            __pb.Set<global::System.IntPtr>(0x48, OutEndPos);
            __pb.Set<byte>(0x54, (byte)(bAllowStretching?1:0));
            __pb.Set(0x58, StartStretchRatio);
            __pb.Set(0x5C, MaxStretchScale);
            CallRaw("K2_TwoBoneIK", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7C4720C — hookable via Hooks.InstallAt(NativeFunc_K2_StartProfilingTimer).</summary>
        public static global::System.IntPtr NativeFunc_K2_StartProfilingTimer => Memory.ModuleBase() + 0x7C4720C;
        public void K2_StartProfilingTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("K2_StartProfilingTimer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7C47960 — hookable via Hooks.InstallAt(NativeFunc_K2_MakePerlinNoiseVectorAndRemap).</summary>
        public static global::System.IntPtr NativeFunc_K2_MakePerlinNoiseVectorAndRemap => Memory.ModuleBase() + 0x7C47960;
        public global::System.IntPtr K2_MakePerlinNoiseVectorAndRemap(float X, float Y, float Z, float RangeOutMinX, float RangeOutMaxX, float RangeOutMinY, float RangeOutMaxY, float RangeOutMinZ, float RangeOutMaxZ)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set(0x0, X);
            __pb.Set(0x4, Y);
            __pb.Set(0x8, Z);
            __pb.Set(0xC, RangeOutMinX);
            __pb.Set(0x10, RangeOutMaxX);
            __pb.Set(0x14, RangeOutMinY);
            __pb.Set(0x18, RangeOutMaxY);
            __pb.Set(0x1C, RangeOutMinZ);
            __pb.Set(0x20, RangeOutMaxZ);
            CallRaw("K2_MakePerlinNoiseVectorAndRemap", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x24);
        }
        /// <summary>[Native] thunk RVA 0x7C47838 — hookable via Hooks.InstallAt(NativeFunc_K2_MakePerlinNoiseAndRemap).</summary>
        public static global::System.IntPtr NativeFunc_K2_MakePerlinNoiseAndRemap => Memory.ModuleBase() + 0x7C47838;
        public float K2_MakePerlinNoiseAndRemap(float Value, float RangeOutMin, float RangeOutMax)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Value);
            __pb.Set(0x4, RangeOutMin);
            __pb.Set(0x8, RangeOutMax);
            CallRaw("K2_MakePerlinNoiseAndRemap", __pb.Bytes);
            return __pb.Get<float>(0xC);
        }
        /// <summary>[Native] thunk RVA 0x7C48050 — hookable via Hooks.InstallAt(NativeFunc_K2_LookAt).</summary>
        public static global::System.IntPtr NativeFunc_K2_LookAt => Memory.ModuleBase() + 0x7C48050;
        public global::System.IntPtr K2_LookAt(global::System.IntPtr CurrentTransform, global::System.IntPtr TargetPosition, global::System.IntPtr LookAtVector, bool bUseUpVector, global::System.IntPtr UpVector, float ClampConeInDegree)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<global::System.IntPtr>(0x0, CurrentTransform);
            __pb.Set<global::System.IntPtr>(0x30, TargetPosition);
            __pb.Set<global::System.IntPtr>(0x3C, LookAtVector);
            __pb.Set<byte>(0x48, (byte)(bUseUpVector?1:0));
            __pb.Set<global::System.IntPtr>(0x4C, UpVector);
            __pb.Set(0x58, ClampConeInDegree);
            CallRaw("K2_LookAt", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x60);
        }
        /// <summary>[Native] thunk RVA 0x7C4710C — hookable via Hooks.InstallAt(NativeFunc_K2_EndProfilingTimer).</summary>
        public static global::System.IntPtr NativeFunc_K2_EndProfilingTimer => Memory.ModuleBase() + 0x7C4710C;
        public float K2_EndProfilingTimer(bool bLog, global::System.IntPtr LogPrefix)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<byte>(0x0, (byte)(bLog?1:0));
            __pb.Set<global::System.IntPtr>(0x8, LogPrefix);
            CallRaw("K2_EndProfilingTimer", __pb.Bytes);
            return __pb.Get<float>(0x18);
        }
        /// <summary>[Native] thunk RVA 0x7C47D48 — hookable via Hooks.InstallAt(NativeFunc_K2_DistanceBetweenTwoSocketsAndMapRange).</summary>
        public static global::System.IntPtr NativeFunc_K2_DistanceBetweenTwoSocketsAndMapRange => Memory.ModuleBase() + 0x7C47D48;
        public float K2_DistanceBetweenTwoSocketsAndMapRange(SkeletalMeshComponent component, FName SocketOrBoneNameA, byte SocketSpaceA, FName SocketOrBoneNameB, byte SocketSpaceB, bool bRemapRange, float InRangeMin, float InRangeMax, float OutRangeMin, float OutRangeMax)
        {
            var __pb = new ParamBuffer(52);
            __pb.SetObject(0x0, component);
            __pb.Set(0x8, SocketOrBoneNameA);
            __pb.Set(0x10, SocketSpaceA);
            __pb.Set(0x14, SocketOrBoneNameB);
            __pb.Set(0x1C, SocketSpaceB);
            __pb.Set<byte>(0x1D, (byte)(bRemapRange?1:0));
            __pb.Set(0x20, InRangeMin);
            __pb.Set(0x24, InRangeMax);
            __pb.Set(0x28, OutRangeMin);
            __pb.Set(0x2C, OutRangeMax);
            CallRaw("K2_DistanceBetweenTwoSocketsAndMapRange", __pb.Bytes);
            return __pb.Get<float>(0x30);
        }
        /// <summary>[Native] thunk RVA 0x7C47C1C — hookable via Hooks.InstallAt(NativeFunc_K2_DirectionBetweenSockets).</summary>
        public static global::System.IntPtr NativeFunc_K2_DirectionBetweenSockets => Memory.ModuleBase() + 0x7C47C1C;
        public global::System.IntPtr K2_DirectionBetweenSockets(SkeletalMeshComponent component, FName SocketOrBoneNameFrom, FName SocketOrBoneNameTo)
        {
            var __pb = new ParamBuffer(36);
            __pb.SetObject(0x0, component);
            __pb.Set(0x8, SocketOrBoneNameFrom);
            __pb.Set(0x10, SocketOrBoneNameTo);
            CallRaw("K2_DirectionBetweenSockets", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x18);
        }
        /// <summary>[Native] thunk RVA 0x7C47220 — hookable via Hooks.InstallAt(NativeFunc_K2_CalculateVelocityFromSockets).</summary>
        public static global::System.IntPtr NativeFunc_K2_CalculateVelocityFromSockets => Memory.ModuleBase() + 0x7C47220;
        public float K2_CalculateVelocityFromSockets(float DeltaSeconds, SkeletalMeshComponent component, FName SocketOrBoneName, FName ReferenceSocketOrBone, byte SocketSpace, global::System.IntPtr OffsetInBoneSpace, global::System.IntPtr History, int NumberOfSamples, float VelocityMin, float VelocityMax, EEasingFuncType EasingType, global::System.IntPtr CustomCurve)
        {
            var __pb = new ParamBuffer(252);
            __pb.Set(0x0, DeltaSeconds);
            __pb.SetObject(0x8, component);
            __pb.Set(0x10, SocketOrBoneName);
            __pb.Set(0x18, ReferenceSocketOrBone);
            __pb.Set(0x20, SocketSpace);
            __pb.Set<global::System.IntPtr>(0x24, OffsetInBoneSpace);
            __pb.Set<global::System.IntPtr>(0x30, History);
            __pb.Set(0x60, NumberOfSamples);
            __pb.Set(0x64, VelocityMin);
            __pb.Set(0x68, VelocityMax);
            __pb.Set<byte>(0x6C, (byte)EasingType);
            __pb.Set<global::System.IntPtr>(0x70, CustomCurve);
            CallRaw("K2_CalculateVelocityFromSockets", __pb.Bytes);
            return __pb.Get<float>(0xF8);
        }
        /// <summary>[Native] thunk RVA 0x7C47624 — hookable via Hooks.InstallAt(NativeFunc_K2_CalculateVelocityFromPositionHistory).</summary>
        public static global::System.IntPtr NativeFunc_K2_CalculateVelocityFromPositionHistory => Memory.ModuleBase() + 0x7C47624;
        public float K2_CalculateVelocityFromPositionHistory(float DeltaSeconds, global::System.IntPtr Position, global::System.IntPtr History, int NumberOfSamples, float VelocityMin, float VelocityMax)
        {
            var __pb = new ParamBuffer(80);
            __pb.Set(0x0, DeltaSeconds);
            __pb.Set<global::System.IntPtr>(0x4, Position);
            __pb.Set<global::System.IntPtr>(0x10, History);
            __pb.Set(0x40, NumberOfSamples);
            __pb.Set(0x44, VelocityMin);
            __pb.Set(0x48, VelocityMax);
            CallRaw("K2_CalculateVelocityFromPositionHistory", __pb.Bytes);
            return __pb.Get<float>(0x4C);
        }
    }

    public class PlayMontageCallbackProxy : Object
    {
        public const string UeClassName = "PlayMontageCallbackProxy";
        public PlayMontageCallbackProxy(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlayMontageCallbackProxy FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlayMontageCallbackProxy(p);
        public static PlayMontageCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayMontageCallbackProxy(o.Pointer); }
        public static PlayMontageCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayMontageCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayMontageCallbackProxy(a[i].Pointer); return r; }
        public global::System.IntPtr OnCompleted => AddrOf(0x28); // 
        public global::System.IntPtr OnBlendOut => AddrOf(0x38); // 
        public global::System.IntPtr OnInterrupted => AddrOf(0x48); // 
        public global::System.IntPtr OnNotifyBegin => AddrOf(0x58); // 
        public global::System.IntPtr OnNotifyEnd => AddrOf(0x68); // 
        /// <summary>[Native] thunk RVA 0x7C49854 — hookable via Hooks.InstallAt(NativeFunc_OnNotifyEndReceived).</summary>
        public static global::System.IntPtr NativeFunc_OnNotifyEndReceived => Memory.ModuleBase() + 0x7C49854;
        public void OnNotifyEndReceived(FName NotifyName, global::System.IntPtr BranchingPointNotifyPayload)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set(0x0, NotifyName);
            __pb.Set<global::System.IntPtr>(0x8, BranchingPointNotifyPayload);
            CallRaw("OnNotifyEndReceived", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7C49950 — hookable via Hooks.InstallAt(NativeFunc_OnNotifyBeginReceived).</summary>
        public static global::System.IntPtr NativeFunc_OnNotifyBeginReceived => Memory.ModuleBase() + 0x7C49950;
        public void OnNotifyBeginReceived(FName NotifyName, global::System.IntPtr BranchingPointNotifyPayload)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set(0x0, NotifyName);
            __pb.Set<global::System.IntPtr>(0x8, BranchingPointNotifyPayload);
            CallRaw("OnNotifyBeginReceived", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7C49A4C — hookable via Hooks.InstallAt(NativeFunc_OnMontageEnded).</summary>
        public static global::System.IntPtr NativeFunc_OnMontageEnded => Memory.ModuleBase() + 0x7C49A4C;
        public void OnMontageEnded(AnimMontage Montage, bool bInterrupted)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Montage);
            __pb.Set<byte>(0x8, (byte)(bInterrupted?1:0));
            CallRaw("OnMontageEnded", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7C49B3C — hookable via Hooks.InstallAt(NativeFunc_OnMontageBlendingOut).</summary>
        public static global::System.IntPtr NativeFunc_OnMontageBlendingOut => Memory.ModuleBase() + 0x7C49B3C;
        public void OnMontageBlendingOut(AnimMontage Montage, bool bInterrupted)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Montage);
            __pb.Set<byte>(0x8, (byte)(bInterrupted?1:0));
            CallRaw("OnMontageBlendingOut", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7C49C2C — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForPlayMontage).</summary>
        public static global::System.IntPtr NativeFunc_CreateProxyObjectForPlayMontage => Memory.ModuleBase() + 0x7C49C2C;
        public PlayMontageCallbackProxy CreateProxyObjectForPlayMontage(SkeletalMeshComponent InSkeletalMeshComponent, AnimMontage MontageToPlay, float PlayRate, float StartingPosition, FName StartingSection)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, InSkeletalMeshComponent);
            __pb.SetObject(0x8, MontageToPlay);
            __pb.Set(0x10, PlayRate);
            __pb.Set(0x14, StartingPosition);
            __pb.Set(0x18, StartingSection);
            CallRaw("CreateProxyObjectForPlayMontage", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x20); return __p==global::System.IntPtr.Zero?null:new PlayMontageCallbackProxy(__p); }
        }
    }

    public class SequencerAnimationSupport : Interface
    {
        public const string UeClassName = "SequencerAnimationSupport";
        public SequencerAnimationSupport(global::System.IntPtr ptr) : base(ptr) {}
        public static new SequencerAnimationSupport FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SequencerAnimationSupport(p);
        public static SequencerAnimationSupport FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SequencerAnimationSupport(o.Pointer); }
        public static SequencerAnimationSupport[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SequencerAnimationSupport[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SequencerAnimationSupport(a[i].Pointer); return r; }
    }

}
