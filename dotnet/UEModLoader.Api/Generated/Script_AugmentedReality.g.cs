// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AugmentedReality
using System;

namespace UEModLoader.Game
{
    public enum EARTrackingState
    {
        Unknown = 0,
        Tracking = 1,
        NotTracking = 2,
        StoppedTracking = 3,
    }

    public enum EARSessionTrackingFeature
    {
        None = 0,
        PoseDetection2D = 1,
        PersonSegmentation = 2,
        PersonSegmentationWithDepth = 3,
    }

    public enum EARFaceTrackingUpdate
    {
        CurvesAndGeo = 0,
        CurvesOnly = 1,
    }

    public enum EAREnvironmentCaptureProbeType
    {
        None = 0,
        Manual = 1,
        Automatic = 2,
    }

    public enum EARFrameSyncMode
    {
        SyncTickWithCameraImage = 0,
        SyncTickWithoutCameraImage = 1,
    }

    public enum EARLightEstimationMode
    {
        None = 0,
        AmbientLightEstimate = 1,
        DirectionalLightEstimate = 2,
    }

    public enum EARPlaneDetectionMode
    {
        None = 0,
        HorizontalPlaneDetection = 1,
        VerticalPlaneDetection = 2,
    }

    public enum EARSessionType
    {
        None = 0,
        Orientation = 1,
        World = 2,
        Face = 3,
        Image = 4,
        ObjectScanning = 5,
        PoseTracking = 6,
    }

    public enum EARWorldAlignment
    {
        Gravity = 0,
        GravityAndHeading = 1,
        Camera = 2,
    }

    public enum EARDepthAccuracy
    {
        Unkown = 0,
        Approximate = 1,
        Accurate = 2,
    }

    public enum EARDepthQuality
    {
        Unkown = 0,
        Low = 1,
        High = 2,
    }

    public enum EARTextureType
    {
        CameraImage = 0,
        CameraDepth = 1,
        EnvironmentCapture = 2,
    }

    public enum EAREye
    {
        LeftEye = 0,
        RightEye = 1,
    }

    public enum EARFaceBlendShape
    {
        EyeBlinkLeft = 0,
        EyeLookDownLeft = 1,
        EyeLookInLeft = 2,
        EyeLookOutLeft = 3,
        EyeLookUpLeft = 4,
        EyeSquintLeft = 5,
        EyeWideLeft = 6,
        EyeBlinkRight = 7,
        EyeLookDownRight = 8,
        EyeLookInRight = 9,
        EyeLookOutRight = 10,
        EyeLookUpRight = 11,
        EyeSquintRight = 12,
        EyeWideRight = 13,
        JawForward = 14,
        JawLeft = 15,
        JawRight = 16,
        JawOpen = 17,
        MouthClose = 18,
        MouthFunnel = 19,
        MouthPucker = 20,
        MouthLeft = 21,
        MouthRight = 22,
        MouthSmileLeft = 23,
        MouthSmileRight = 24,
        MouthFrownLeft = 25,
        MouthFrownRight = 26,
        MouthDimpleLeft = 27,
        MouthDimpleRight = 28,
        MouthStretchLeft = 29,
        MouthStretchRight = 30,
        MouthRollLower = 31,
        MouthRollUpper = 32,
        MouthShrugLower = 33,
        MouthShrugUpper = 34,
        MouthPressLeft = 35,
        MouthPressRight = 36,
        MouthLowerDownLeft = 37,
        MouthLowerDownRight = 38,
        MouthUpperUpLeft = 39,
        MouthUpperUpRight = 40,
        BrowDownLeft = 41,
        BrowDownRight = 42,
        BrowInnerUp = 43,
        BrowOuterUpLeft = 44,
        BrowOuterUpRight = 45,
        CheekPuff = 46,
        CheekSquintLeft = 47,
        CheekSquintRight = 48,
        NoseSneerLeft = 49,
        NoseSneerRight = 50,
        TongueOut = 51,
        HeadYaw = 52,
        HeadPitch = 53,
        HeadRoll = 54,
        LeftEyeYaw = 55,
        LeftEyePitch = 56,
        LeftEyeRoll = 57,
        RightEyeYaw = 58,
        RightEyePitch = 59,
        RightEyeRoll = 60,
        MAX = 61,
    }

    public enum EARFaceTrackingDirection
    {
        FaceRelative = 0,
        FaceMirrored = 1,
    }

    public enum EARCandidateImageOrientation
    {
        Landscape = 0,
        Portrait = 1,
    }

    public enum EARJointTransformSpace
    {
        Model = 0,
        ParentJoint = 1,
    }

    public enum EARObjectClassification
    {
        NotApplicable = 0,
        Unknown = 1,
        Wall = 2,
        Ceiling = 3,
        Floor = 4,
        Table = 5,
        Seat = 6,
        Face = 7,
        Image = 8,
        World = 9,
        SceneObject = 10,
        HandMesh = 11,
    }

    public enum EARPlaneOrientation
    {
        Horizontal = 0,
        Vertical = 1,
        Diagonal = 2,
    }

    public enum EARWorldMappingState
    {
        NotAvailable = 0,
        StillMappingNotRelocalizable = 1,
        StillMappingRelocalizable = 2,
        Mapped = 3,
    }

    public enum EARSessionStatus
    {
        NotStarted = 0,
        Running = 1,
        NotSupported = 2,
        FatalError = 3,
        PermissionNotGranted = 4,
        UnsupportedConfiguration = 5,
        Other = 6,
    }

    public enum EARTrackingQualityReason
    {
        None = 0,
        Initializing = 1,
        Relocalizing = 2,
        ExcessiveMotion = 3,
        InsufficientFeatures = 4,
    }

    public enum EARTrackingQuality
    {
        NotTracking = 0,
        OrientationOnly = 1,
        OrientationAndPosition = 2,
    }

    public enum EARLineTraceChannels
    {
        None = 0,
        FeaturePoint = 1,
        GroundPlane = 2,
        PlaneUsingExtent = 4,
        PlaneUsingBoundaryPolygon = 8,
    }

    public class ARSharedWorldReplicationState : StructProxy
    {
        public ARSharedWorldReplicationState(System.IntPtr ptr) : base(ptr) {}
        public int PreviewImageOffset { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int ARWorldOffset { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class ARTraceResult : StructProxy
    {
        public ARTraceResult(System.IntPtr ptr) : base(ptr) {}
        public float DistanceFromCamera { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public EARLineTraceChannels TraceChannel { get => (EARLineTraceChannels)GetAt<byte>(0x4); set => SetAt(0x4, (byte)value); }
        public Transform LocalToTrackingTransform => new Transform(AddrOf(0x10));
        public ARTrackedGeometry TrackedGeometry { get { var __p = GetAt<System.IntPtr>(0x40); return __p==System.IntPtr.Zero?null:new ARTrackedGeometry(__p); } set => SetAt(0x40, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class ARPose3D : StructProxy
    {
        public ARPose3D(System.IntPtr ptr) : base(ptr) {}
        public ARSkeletonDefinition SkeletonDefinition => new ARSkeletonDefinition(AddrOf(0x0));
        public TArray<System.IntPtr> JointTransforms => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public TArray<System.IntPtr> IsJointTracked => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<bool>
        public EARJointTransformSpace JointTransformSpace { get => (EARJointTransformSpace)GetAt<byte>(0x48); set => SetAt(0x48, (byte)value); }
    }

    public class ARSkeletonDefinition : StructProxy
    {
        public ARSkeletonDefinition(System.IntPtr ptr) : base(ptr) {}
        public int NumJoints { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public TArray<System.IntPtr> JointNames => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<FName>
        public TArray<System.IntPtr> ParentIndices => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<int32>
    }

    public class ARPose2D : StructProxy
    {
        public ARPose2D(System.IntPtr ptr) : base(ptr) {}
        public ARSkeletonDefinition SkeletonDefinition => new ARSkeletonDefinition(AddrOf(0x0));
        public TArray<System.IntPtr> JointLocations => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public TArray<System.IntPtr> IsJointTracked => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<bool>
    }

    public class ARVideoFormat : StructProxy
    {
        public ARVideoFormat(System.IntPtr ptr) : base(ptr) {}
        public int FPS { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int Width { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int Height { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
    }

    public class ARSessionStatus : StructProxy
    {
        public ARSessionStatus(System.IntPtr ptr) : base(ptr) {}
        public string AdditionalInfo => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public EARSessionStatus Status { get => (EARSessionStatus)GetAt<byte>(0x10); set => SetAt(0x10, (byte)value); }
    }

    public class ARBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "ARBlueprintLibrary";
        public ARBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new ARBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARBlueprintLibrary(p);
        public static ARBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARBlueprintLibrary(o.Pointer); }
        public static ARBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7382AB8 — hookable via Hooks.InstallAt(NativeFunc_UnpinComponent).</summary>
        public static System.IntPtr NativeFunc_UnpinComponent => Memory.ModuleBase() + 0x7382AB8;
        public void UnpinComponent(SceneComponent ComponentToUnpin)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ComponentToUnpin);
            CallRaw("UnpinComponent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7383C84 — hookable via Hooks.InstallAt(NativeFunc_StopARSession).</summary>
        public static System.IntPtr NativeFunc_StopARSession => Memory.ModuleBase() + 0x7383C84;
        public void StopARSession()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopARSession", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7383CAC — hookable via Hooks.InstallAt(NativeFunc_StartARSession).</summary>
        public static System.IntPtr NativeFunc_StartARSession => Memory.ModuleBase() + 0x7383CAC;
        public void StartARSession(ARSessionConfig SessionConfig)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, SessionConfig);
            CallRaw("StartARSession", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7383AC4 — hookable via Hooks.InstallAt(NativeFunc_SetAlignmentTransform).</summary>
        public static System.IntPtr NativeFunc_SetAlignmentTransform => Memory.ModuleBase() + 0x7383AC4;
        public void SetAlignmentTransform(Transform InAlignmentTransform)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, InAlignmentTransform);
            CallRaw("SetAlignmentTransform", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7382A24 — hookable via Hooks.InstallAt(NativeFunc_RemovePin).</summary>
        public static System.IntPtr NativeFunc_RemovePin => Memory.ModuleBase() + 0x7382A24;
        public void RemovePin(ARPin PinToRemove)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, PinToRemove);
            CallRaw("RemovePin", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7382B4C — hookable via Hooks.InstallAt(NativeFunc_PinComponentToTraceResult).</summary>
        public static System.IntPtr NativeFunc_PinComponentToTraceResult => Memory.ModuleBase() + 0x7382B4C;
        public ARPin PinComponentToTraceResult(SceneComponent ComponentToPin, ARTraceResult TraceResult, FName DebugName)
        {
            var __pb = new ParamBuffer(128);
            __pb.SetObject(0x0, ComponentToPin);
            __pb.Set<System.IntPtr>(0x10, TraceResult);
            __pb.Set(0x70, DebugName);
            CallRaw("PinComponentToTraceResult", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x78); return __p==System.IntPtr.Zero?null:new ARPin(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7382CDC — hookable via Hooks.InstallAt(NativeFunc_PinComponent).</summary>
        public static System.IntPtr NativeFunc_PinComponent => Memory.ModuleBase() + 0x7382CDC;
        public ARPin PinComponent(SceneComponent ComponentToPin, Transform PinToWorldTransform, ARTrackedGeometry TrackedGeometry, FName DebugName)
        {
            var __pb = new ParamBuffer(88);
            __pb.SetObject(0x0, ComponentToPin);
            __pb.Set<System.IntPtr>(0x10, PinToWorldTransform);
            __pb.SetObject(0x40, TrackedGeometry);
            __pb.Set(0x48, DebugName);
            CallRaw("PinComponent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x50); return __p==System.IntPtr.Zero?null:new ARPin(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7383C98 — hookable via Hooks.InstallAt(NativeFunc_PauseARSession).</summary>
        public static System.IntPtr NativeFunc_PauseARSession => Memory.ModuleBase() + 0x7383C98;
        public void PauseARSession()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PauseARSession", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7383400 — hookable via Hooks.InstallAt(NativeFunc_LineTraceTrackedObjects3D).</summary>
        public static System.IntPtr NativeFunc_LineTraceTrackedObjects3D => Memory.ModuleBase() + 0x7383400;
        public System.IntPtr LineTraceTrackedObjects3D(Vector Start, Vector End, bool bTestFeaturePoints, bool bTestGroundPlane, bool bTestPlaneExtents, bool bTestPlaneBoundaryPolygon)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, Start);
            __pb.Set<System.IntPtr>(0xC, End);
            __pb.Set<byte>(0x18, (byte)(bTestFeaturePoints?1:0));
            __pb.Set<byte>(0x19, (byte)(bTestGroundPlane?1:0));
            __pb.Set<byte>(0x1A, (byte)(bTestPlaneExtents?1:0));
            __pb.Set<byte>(0x1B, (byte)(bTestPlaneBoundaryPolygon?1:0));
            CallRaw("LineTraceTrackedObjects3D", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x20);
        }
        /// <summary>[Native] thunk RVA 0x7383784 — hookable via Hooks.InstallAt(NativeFunc_LineTraceTrackedObjects).</summary>
        public static System.IntPtr NativeFunc_LineTraceTrackedObjects => Memory.ModuleBase() + 0x7383784;
        public System.IntPtr LineTraceTrackedObjects(Vector2D ScreenCoord, bool bTestFeaturePoints, bool bTestGroundPlane, bool bTestPlaneExtents, bool bTestPlaneBoundaryPolygon)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, ScreenCoord);
            __pb.Set<byte>(0x8, (byte)(bTestFeaturePoints?1:0));
            __pb.Set<byte>(0x9, (byte)(bTestGroundPlane?1:0));
            __pb.Set<byte>(0xA, (byte)(bTestPlaneExtents?1:0));
            __pb.Set<byte>(0xB, (byte)(bTestPlaneBoundaryPolygon?1:0));
            CallRaw("LineTraceTrackedObjects", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x73831D8 — hookable via Hooks.InstallAt(NativeFunc_IsSessionTypeSupported).</summary>
        public static System.IntPtr NativeFunc_IsSessionTypeSupported => Memory.ModuleBase() + 0x73831D8;
        public bool IsSessionTypeSupported(EARSessionType SessionType)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)SessionType);
            CallRaw("IsSessionTypeSupported", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        /// <summary>[Native] thunk RVA 0x738213C — hookable via Hooks.InstallAt(NativeFunc_IsSessionTrackingFeatureSupported).</summary>
        public static System.IntPtr NativeFunc_IsSessionTrackingFeatureSupported => Memory.ModuleBase() + 0x738213C;
        public bool IsSessionTrackingFeatureSupported(EARSessionType SessionType, EARSessionTrackingFeature SessionTrackingFeature)
        {
            var __pb = new ParamBuffer(3);
            __pb.Set<byte>(0x0, (byte)SessionType);
            __pb.Set<byte>(0x1, (byte)SessionTrackingFeature);
            CallRaw("IsSessionTrackingFeatureSupported", __pb.Bytes);
            return __pb.Get<byte>(0x2) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7383D40 — hookable via Hooks.InstallAt(NativeFunc_IsARSupported).</summary>
        public static System.IntPtr NativeFunc_IsARSupported => Memory.ModuleBase() + 0x7383D40;
        public bool IsARSupported()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsARSupported", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7382598 — hookable via Hooks.InstallAt(NativeFunc_GetWorldMappingStatus).</summary>
        public static System.IntPtr NativeFunc_GetWorldMappingStatus => Memory.ModuleBase() + 0x7382598;
        public EARWorldMappingState GetWorldMappingStatus()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetWorldMappingStatus", __pb.Bytes);
            return (EARWorldMappingState)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7383398 — hookable via Hooks.InstallAt(NativeFunc_GetTrackingQualityReason).</summary>
        public static System.IntPtr NativeFunc_GetTrackingQualityReason => Memory.ModuleBase() + 0x7383398;
        public EARTrackingQualityReason GetTrackingQualityReason()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetTrackingQualityReason", __pb.Bytes);
            return (EARTrackingQualityReason)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73833CC — hookable via Hooks.InstallAt(NativeFunc_GetTrackingQuality).</summary>
        public static System.IntPtr NativeFunc_GetTrackingQuality => Memory.ModuleBase() + 0x73833CC;
        public EARTrackingQuality GetTrackingQuality()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetTrackingQuality", __pb.Bytes);
            return (EARTrackingQuality)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73823F8 — hookable via Hooks.InstallAt(NativeFunc_GetSupportedVideoFormats).</summary>
        public static System.IntPtr NativeFunc_GetSupportedVideoFormats => Memory.ModuleBase() + 0x73823F8;
        public System.IntPtr GetSupportedVideoFormats(EARSessionType SessionType)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)SessionType);
            CallRaw("GetSupportedVideoFormats", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7383B90 — hookable via Hooks.InstallAt(NativeFunc_GetSessionConfig).</summary>
        public static System.IntPtr NativeFunc_GetSessionConfig => Memory.ModuleBase() + 0x7383B90;
        public ARSessionConfig GetSessionConfig()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSessionConfig", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARSessionConfig(__p); }
        }
        /// <summary>[Native] thunk RVA 0x73824E8 — hookable via Hooks.InstallAt(NativeFunc_GetPointCloud).</summary>
        public static System.IntPtr NativeFunc_GetPointCloud => Memory.ModuleBase() + 0x73824E8;
        public System.IntPtr GetPointCloud()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetPointCloud", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7381EC4 — hookable via Hooks.InstallAt(NativeFunc_GetPersonSegmentationImage).</summary>
        public static System.IntPtr NativeFunc_GetPersonSegmentationImage => Memory.ModuleBase() + 0x7381EC4;
        public ARTextureCameraImage GetPersonSegmentationImage()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetPersonSegmentationImage", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARTextureCameraImage(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7381E90 — hookable via Hooks.InstallAt(NativeFunc_GetPersonSegmentationDepthImage).</summary>
        public static System.IntPtr NativeFunc_GetPersonSegmentationDepthImage => Memory.ModuleBase() + 0x7381E90;
        public ARTextureCameraImage GetPersonSegmentationDepthImage()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetPersonSegmentationDepthImage", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARTextureCameraImage(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7382E74 — hookable via Hooks.InstallAt(NativeFunc_GetCurrentLightEstimate).</summary>
        public static System.IntPtr NativeFunc_GetCurrentLightEstimate => Memory.ModuleBase() + 0x7382E74;
        public ARLightEstimate GetCurrentLightEstimate()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetCurrentLightEstimate", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARLightEstimate(__p); }
        }
        /// <summary>[Native] thunk RVA 0x73832B4 — hookable via Hooks.InstallAt(NativeFunc_GetCameraImage).</summary>
        public static System.IntPtr NativeFunc_GetCameraImage => Memory.ModuleBase() + 0x73832B4;
        public ARTextureCameraImage GetCameraImage()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetCameraImage", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARTextureCameraImage(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7383280 — hookable via Hooks.InstallAt(NativeFunc_GetCameraDepth).</summary>
        public static System.IntPtr NativeFunc_GetCameraDepth => Memory.ModuleBase() + 0x7383280;
        public ARTextureCameraDepth GetCameraDepth()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetCameraDepth", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARTextureCameraDepth(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7383BC4 — hookable via Hooks.InstallAt(NativeFunc_GetARSessionStatus).</summary>
        public static System.IntPtr NativeFunc_GetARSessionStatus => Memory.ModuleBase() + 0x7383BC4;
        public ARSessionStatus GetARSessionStatus()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetARSessionStatus", __pb.Bytes);
            return __pb.Get<ARSessionStatus>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7381EF8 — hookable via Hooks.InstallAt(NativeFunc_GetAllTrackedPoses).</summary>
        public static System.IntPtr NativeFunc_GetAllTrackedPoses => Memory.ModuleBase() + 0x7381EF8;
        public System.IntPtr GetAllTrackedPoses()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllTrackedPoses", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7382814 — hookable via Hooks.InstallAt(NativeFunc_GetAllTrackedPoints).</summary>
        public static System.IntPtr NativeFunc_GetAllTrackedPoints => Memory.ModuleBase() + 0x7382814;
        public System.IntPtr GetAllTrackedPoints()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllTrackedPoints", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73828C4 — hookable via Hooks.InstallAt(NativeFunc_GetAllTrackedPlanes).</summary>
        public static System.IntPtr NativeFunc_GetAllTrackedPlanes => Memory.ModuleBase() + 0x73828C4;
        public System.IntPtr GetAllTrackedPlanes()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllTrackedPlanes", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7382764 — hookable via Hooks.InstallAt(NativeFunc_GetAllTrackedImages).</summary>
        public static System.IntPtr NativeFunc_GetAllTrackedImages => Memory.ModuleBase() + 0x7382764;
        public System.IntPtr GetAllTrackedImages()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllTrackedImages", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73826B4 — hookable via Hooks.InstallAt(NativeFunc_GetAllTrackedEnvironmentCaptureProbes).</summary>
        public static System.IntPtr NativeFunc_GetAllTrackedEnvironmentCaptureProbes => Memory.ModuleBase() + 0x73826B4;
        public System.IntPtr GetAllTrackedEnvironmentCaptureProbes()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllTrackedEnvironmentCaptureProbes", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7381FA8 — hookable via Hooks.InstallAt(NativeFunc_GetAllTracked2DPoses).</summary>
        public static System.IntPtr NativeFunc_GetAllTracked2DPoses => Memory.ModuleBase() + 0x7381FA8;
        public System.IntPtr GetAllTracked2DPoses()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllTracked2DPoses", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7382974 — hookable via Hooks.InstallAt(NativeFunc_GetAllPins).</summary>
        public static System.IntPtr NativeFunc_GetAllPins => Memory.ModuleBase() + 0x7382974;
        public System.IntPtr GetAllPins()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllPins", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73832E8 — hookable via Hooks.InstallAt(NativeFunc_GetAllGeometries).</summary>
        public static System.IntPtr NativeFunc_GetAllGeometries => Memory.ModuleBase() + 0x73832E8;
        public System.IntPtr GetAllGeometries()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllGeometries", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7383040 — hookable via Hooks.InstallAt(NativeFunc_DebugDrawTrackedGeometry).</summary>
        public static System.IntPtr NativeFunc_DebugDrawTrackedGeometry => Memory.ModuleBase() + 0x7383040;
        public void DebugDrawTrackedGeometry(ARTrackedGeometry TrackedGeometry, Object WorldContextObject, LinearColor Color, float OutlineThickness, float PersistForSeconds)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, TrackedGeometry);
            __pb.SetObject(0x8, WorldContextObject);
            __pb.Set<System.IntPtr>(0x10, Color);
            __pb.Set(0x20, OutlineThickness);
            __pb.Set(0x24, PersistForSeconds);
            CallRaw("DebugDrawTrackedGeometry", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7382EA8 — hookable via Hooks.InstallAt(NativeFunc_DebugDrawPin).</summary>
        public static System.IntPtr NativeFunc_DebugDrawPin => Memory.ModuleBase() + 0x7382EA8;
        public void DebugDrawPin(ARPin ARPin, Object WorldContextObject, LinearColor Color, float Scale, float PersistForSeconds)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, ARPin);
            __pb.SetObject(0x8, WorldContextObject);
            __pb.Set<System.IntPtr>(0x10, Color);
            __pb.Set(0x20, Scale);
            __pb.Set(0x24, PersistForSeconds);
            CallRaw("DebugDrawPin", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7382228 — hookable via Hooks.InstallAt(NativeFunc_AddRuntimeCandidateImage).</summary>
        public static System.IntPtr NativeFunc_AddRuntimeCandidateImage => Memory.ModuleBase() + 0x7382228;
        public ARCandidateImage AddRuntimeCandidateImage(ARSessionConfig SessionConfig, Texture2D CandidateTexture, System.IntPtr FriendlyName, float PhysicalWidth)
        {
            var __pb = new ParamBuffer(48);
            __pb.SetObject(0x0, SessionConfig);
            __pb.SetObject(0x8, CandidateTexture);
            __pb.Set<System.IntPtr>(0x10, FriendlyName);
            __pb.Set(0x20, PhysicalWidth);
            CallRaw("AddRuntimeCandidateImage", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new ARCandidateImage(__p); }
        }
        /// <summary>[Native] thunk RVA 0x73825CC — hookable via Hooks.InstallAt(NativeFunc_AddManualEnvironmentCaptureProbe).</summary>
        public static System.IntPtr NativeFunc_AddManualEnvironmentCaptureProbe => Memory.ModuleBase() + 0x73825CC;
        public bool AddManualEnvironmentCaptureProbe(Vector Location, Vector Extent)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, Location);
            __pb.Set<System.IntPtr>(0xC, Extent);
            CallRaw("AddManualEnvironmentCaptureProbe", __pb.Bytes);
            return __pb.Get<byte>(0x18) != 0;
        }
    }

    public class ARTraceResultLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "ARTraceResultLibrary";
        public ARTraceResultLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new ARTraceResultLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTraceResultLibrary(p);
        public static ARTraceResultLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTraceResultLibrary(o.Pointer); }
        public static ARTraceResultLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTraceResultLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTraceResultLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7384E80 — hookable via Hooks.InstallAt(NativeFunc_GetTrackedGeometry).</summary>
        public static System.IntPtr NativeFunc_GetTrackedGeometry => Memory.ModuleBase() + 0x7384E80;
        public ARTrackedGeometry GetTrackedGeometry(ARTraceResult TraceResult)
        {
            var __pb = new ParamBuffer(104);
            __pb.Set<System.IntPtr>(0x0, TraceResult);
            CallRaw("GetTrackedGeometry", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x60); return __p==System.IntPtr.Zero?null:new ARTrackedGeometry(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7384D68 — hookable via Hooks.InstallAt(NativeFunc_GetTraceChannel).</summary>
        public static System.IntPtr NativeFunc_GetTraceChannel => Memory.ModuleBase() + 0x7384D68;
        public EARLineTraceChannels GetTraceChannel(ARTraceResult TraceResult)
        {
            var __pb = new ParamBuffer(97);
            __pb.Set<System.IntPtr>(0x0, TraceResult);
            CallRaw("GetTraceChannel", __pb.Bytes);
            return (EARLineTraceChannels)__pb.Get<byte>(0x60);
        }
        /// <summary>[Native] thunk RVA 0x7384F98 — hookable via Hooks.InstallAt(NativeFunc_GetLocalToWorldTransform).</summary>
        public static System.IntPtr NativeFunc_GetLocalToWorldTransform => Memory.ModuleBase() + 0x7384F98;
        public Transform GetLocalToWorldTransform(ARTraceResult TraceResult)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<System.IntPtr>(0x0, TraceResult);
            CallRaw("GetLocalToWorldTransform", __pb.Bytes);
            return __pb.Get<Transform>(0x60);
        }
        /// <summary>[Native] thunk RVA 0x73850C0 — hookable via Hooks.InstallAt(NativeFunc_GetLocalToTrackingTransform).</summary>
        public static System.IntPtr NativeFunc_GetLocalToTrackingTransform => Memory.ModuleBase() + 0x73850C0;
        public Transform GetLocalToTrackingTransform(ARTraceResult TraceResult)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<System.IntPtr>(0x0, TraceResult);
            CallRaw("GetLocalToTrackingTransform", __pb.Bytes);
            return __pb.Get<Transform>(0x60);
        }
        /// <summary>[Native] thunk RVA 0x73851E8 — hookable via Hooks.InstallAt(NativeFunc_GetDistanceFromCamera).</summary>
        public static System.IntPtr NativeFunc_GetDistanceFromCamera => Memory.ModuleBase() + 0x73851E8;
        public float GetDistanceFromCamera(ARTraceResult TraceResult)
        {
            var __pb = new ParamBuffer(100);
            __pb.Set<System.IntPtr>(0x0, TraceResult);
            CallRaw("GetDistanceFromCamera", __pb.Bytes);
            return __pb.Get<float>(0x60);
        }
    }

    public class ARBaseAsyncTaskBlueprintProxy : BlueprintAsyncActionBase
    {
        public const string UeClassName = "ARBaseAsyncTaskBlueprintProxy";
        public ARBaseAsyncTaskBlueprintProxy(System.IntPtr ptr) : base(ptr) {}
        public static new ARBaseAsyncTaskBlueprintProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARBaseAsyncTaskBlueprintProxy(p);
        public static ARBaseAsyncTaskBlueprintProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARBaseAsyncTaskBlueprintProxy(o.Pointer); }
        public static ARBaseAsyncTaskBlueprintProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARBaseAsyncTaskBlueprintProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARBaseAsyncTaskBlueprintProxy(a[i].Pointer); return r; }
    }

    public class ARSaveWorldAsyncTaskBlueprintProxy : ARBaseAsyncTaskBlueprintProxy
    {
        public const string UeClassName = "ARSaveWorldAsyncTaskBlueprintProxy";
        public ARSaveWorldAsyncTaskBlueprintProxy(System.IntPtr ptr) : base(ptr) {}
        public static new ARSaveWorldAsyncTaskBlueprintProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARSaveWorldAsyncTaskBlueprintProxy(p);
        public static ARSaveWorldAsyncTaskBlueprintProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARSaveWorldAsyncTaskBlueprintProxy(o.Pointer); }
        public static ARSaveWorldAsyncTaskBlueprintProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARSaveWorldAsyncTaskBlueprintProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARSaveWorldAsyncTaskBlueprintProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x50); // 
        public System.IntPtr OnFailed => AddrOf(0x60); // 
        /// <summary>[Native] thunk RVA 0x7386260 — hookable via Hooks.InstallAt(NativeFunc_ARSaveWorld).</summary>
        public static System.IntPtr NativeFunc_ARSaveWorld => Memory.ModuleBase() + 0x7386260;
        public ARSaveWorldAsyncTaskBlueprintProxy ARSaveWorld(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("ARSaveWorld", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new ARSaveWorldAsyncTaskBlueprintProxy(__p); }
        }
    }

    public class ARGetCandidateObjectAsyncTaskBlueprintProxy : ARBaseAsyncTaskBlueprintProxy
    {
        public const string UeClassName = "ARGetCandidateObjectAsyncTaskBlueprintProxy";
        public ARGetCandidateObjectAsyncTaskBlueprintProxy(System.IntPtr ptr) : base(ptr) {}
        public static new ARGetCandidateObjectAsyncTaskBlueprintProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARGetCandidateObjectAsyncTaskBlueprintProxy(p);
        public static ARGetCandidateObjectAsyncTaskBlueprintProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARGetCandidateObjectAsyncTaskBlueprintProxy(o.Pointer); }
        public static ARGetCandidateObjectAsyncTaskBlueprintProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARGetCandidateObjectAsyncTaskBlueprintProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARGetCandidateObjectAsyncTaskBlueprintProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x50); // 
        public System.IntPtr OnFailed => AddrOf(0x60); // 
        /// <summary>[Native] thunk RVA 0x73867E8 — hookable via Hooks.InstallAt(NativeFunc_ARGetCandidateObject).</summary>
        public static System.IntPtr NativeFunc_ARGetCandidateObject => Memory.ModuleBase() + 0x73867E8;
        public ARGetCandidateObjectAsyncTaskBlueprintProxy ARGetCandidateObject(Object WorldContextObject, Vector Location, Vector Extent)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, Location);
            __pb.Set<System.IntPtr>(0x14, Extent);
            CallRaw("ARGetCandidateObject", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new ARGetCandidateObjectAsyncTaskBlueprintProxy(__p); }
        }
    }

    public class ARLightEstimate : Object
    {
        public const string UeClassName = "ARLightEstimate";
        public ARLightEstimate(System.IntPtr ptr) : base(ptr) {}
        public static new ARLightEstimate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARLightEstimate(p);
        public static ARLightEstimate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARLightEstimate(o.Pointer); }
        public static ARLightEstimate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARLightEstimate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARLightEstimate(a[i].Pointer); return r; }
    }

    public class ARBasicLightEstimate : ARLightEstimate
    {
        public const string UeClassName = "ARBasicLightEstimate";
        public ARBasicLightEstimate(System.IntPtr ptr) : base(ptr) {}
        public static new ARBasicLightEstimate FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARBasicLightEstimate(p);
        public static ARBasicLightEstimate FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARBasicLightEstimate(o.Pointer); }
        public static ARBasicLightEstimate[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARBasicLightEstimate[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARBasicLightEstimate(a[i].Pointer); return r; }
        public float AmbientIntensityLumens { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public float AmbientColorTemperatureKelvin { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public LinearColor AmbientColor => new LinearColor(AddrOf(0x30));
        /// <summary>[Native] thunk RVA 0x7387828 — hookable via Hooks.InstallAt(NativeFunc_GetAmbientIntensityLumens).</summary>
        public static System.IntPtr NativeFunc_GetAmbientIntensityLumens => Memory.ModuleBase() + 0x7387828;
        public float GetAmbientIntensityLumens()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetAmbientIntensityLumens", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73877F4 — hookable via Hooks.InstallAt(NativeFunc_GetAmbientColorTemperatureKelvin).</summary>
        public static System.IntPtr NativeFunc_GetAmbientColorTemperatureKelvin => Memory.ModuleBase() + 0x73877F4;
        public float GetAmbientColorTemperatureKelvin()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetAmbientColorTemperatureKelvin", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73877BC — hookable via Hooks.InstallAt(NativeFunc_GetAmbientColor).</summary>
        public static System.IntPtr NativeFunc_GetAmbientColor => Memory.ModuleBase() + 0x73877BC;
        public LinearColor GetAmbientColor()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAmbientColor", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
    }

    public class AROriginActor : Actor
    {
        public const string UeClassName = "AROriginActor";
        public AROriginActor(System.IntPtr ptr) : base(ptr) {}
        public static new AROriginActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AROriginActor(p);
        public static AROriginActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AROriginActor(o.Pointer); }
        public static AROriginActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AROriginActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AROriginActor(a[i].Pointer); return r; }
    }

    public class ARPin : Object
    {
        public const string UeClassName = "ARPin";
        public ARPin(System.IntPtr ptr) : base(ptr) {}
        public static new ARPin FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARPin(p);
        public static ARPin FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARPin(o.Pointer); }
        public static ARPin[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARPin[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARPin(a[i].Pointer); return r; }
        public ARTrackedGeometry TrackedGeometry { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new ARTrackedGeometry(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent PinnedComponent { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public Transform LocalToTrackingTransform => new Transform(AddrOf(0x40));
        public Transform LocalToAlignedTrackingTransform => new Transform(AddrOf(0x70));
        public EARTrackingState TrackingState { get => (EARTrackingState)GetAt<byte>(0xA0); set => SetAt(0xA0, (byte)value); }
        public System.IntPtr OnARTrackingStateChanged => AddrOf(0xC0); // 
        public System.IntPtr OnARTransformUpdated => AddrOf(0xD0); // 
        /// <summary>[Native] thunk RVA 0x7388C44 — hookable via Hooks.InstallAt(NativeFunc_GetTrackingState).</summary>
        public static System.IntPtr NativeFunc_GetTrackingState => Memory.ModuleBase() + 0x7388C44;
        public EARTrackingState GetTrackingState()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetTrackingState", __pb.Bytes);
            return (EARTrackingState)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7388C10 — hookable via Hooks.InstallAt(NativeFunc_GetTrackedGeometry).</summary>
        public static System.IntPtr NativeFunc_GetTrackedGeometry => Memory.ModuleBase() + 0x7388C10;
        public ARTrackedGeometry GetTrackedGeometry()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetTrackedGeometry", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARTrackedGeometry(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7388BDC — hookable via Hooks.InstallAt(NativeFunc_GetPinnedComponent).</summary>
        public static System.IntPtr NativeFunc_GetPinnedComponent => Memory.ModuleBase() + 0x7388BDC;
        public SceneComponent GetPinnedComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetPinnedComponent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7388C78 — hookable via Hooks.InstallAt(NativeFunc_GetLocalToWorldTransform).</summary>
        public static System.IntPtr NativeFunc_GetLocalToWorldTransform => Memory.ModuleBase() + 0x7388C78;
        public Transform GetLocalToWorldTransform()
        {
            var __pb = new ParamBuffer(48);
            CallRaw("GetLocalToWorldTransform", __pb.Bytes);
            return __pb.Get<Transform>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7388CE4 — hookable via Hooks.InstallAt(NativeFunc_GetLocalToTrackingTransform).</summary>
        public static System.IntPtr NativeFunc_GetLocalToTrackingTransform => Memory.ModuleBase() + 0x7388CE4;
        public Transform GetLocalToTrackingTransform()
        {
            var __pb = new ParamBuffer(48);
            CallRaw("GetLocalToTrackingTransform", __pb.Bytes);
            return __pb.Get<Transform>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7388A2C — hookable via Hooks.InstallAt(NativeFunc_GetDebugName).</summary>
        public static System.IntPtr NativeFunc_GetDebugName => Memory.ModuleBase() + 0x7388A2C;
        public FName GetDebugName()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDebugName", __pb.Bytes);
            return __pb.Get<FName>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7388A60 — hookable via Hooks.InstallAt(NativeFunc_DebugDraw).</summary>
        public static System.IntPtr NativeFunc_DebugDraw => Memory.ModuleBase() + 0x7388A60;
        public void DebugDraw(World World, LinearColor Color, float Scale, float PersistForSeconds)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, World);
            __pb.Set<System.IntPtr>(0x8, Color);
            __pb.Set(0x18, Scale);
            __pb.Set(0x1C, PersistForSeconds);
            CallRaw("DebugDraw", __pb.Bytes);
        }
    }

    public class ARSessionConfig : DataAsset
    {
        public const string UeClassName = "ARSessionConfig";
        public ARSessionConfig(System.IntPtr ptr) : base(ptr) {}
        public static new ARSessionConfig FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARSessionConfig(p);
        public static ARSessionConfig FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARSessionConfig(o.Pointer); }
        public static ARSessionConfig[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARSessionConfig[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARSessionConfig(a[i].Pointer); return r; }
        public bool bGenerateMeshDataFromTrackedGeometry { get => Native.GetPropBool(Pointer, "bGenerateMeshDataFromTrackedGeometry"); set => Native.SetPropBool(Pointer, "bGenerateMeshDataFromTrackedGeometry", value); }
        public bool bGenerateCollisionForMeshData { get => Native.GetPropBool(Pointer, "bGenerateCollisionForMeshData"); set => Native.SetPropBool(Pointer, "bGenerateCollisionForMeshData", value); }
        public bool bGenerateNavMeshForMeshData { get => Native.GetPropBool(Pointer, "bGenerateNavMeshForMeshData"); set => Native.SetPropBool(Pointer, "bGenerateNavMeshForMeshData", value); }
        public bool bUseMeshDataForOcclusion { get => Native.GetPropBool(Pointer, "bUseMeshDataForOcclusion"); set => Native.SetPropBool(Pointer, "bUseMeshDataForOcclusion", value); }
        public bool bRenderMeshDataInWireframe { get => Native.GetPropBool(Pointer, "bRenderMeshDataInWireframe"); set => Native.SetPropBool(Pointer, "bRenderMeshDataInWireframe", value); }
        public bool bTrackSceneObjects { get => Native.GetPropBool(Pointer, "bTrackSceneObjects"); set => Native.SetPropBool(Pointer, "bTrackSceneObjects", value); }
        public bool bUsePersonSegmentationForOcclusion { get => Native.GetPropBool(Pointer, "bUsePersonSegmentationForOcclusion"); set => Native.SetPropBool(Pointer, "bUsePersonSegmentationForOcclusion", value); }
        public EARWorldAlignment WorldAlignment { get => (EARWorldAlignment)GetAt<byte>(0x37); set => SetAt(0x37, (byte)value); }
        public EARSessionType SessionType { get => (EARSessionType)GetAt<byte>(0x38); set => SetAt(0x38, (byte)value); }
        public EARPlaneDetectionMode PlaneDetectionMode { get => (EARPlaneDetectionMode)GetAt<byte>(0x39); set => SetAt(0x39, (byte)value); }
        public bool bHorizontalPlaneDetection { get => Native.GetPropBool(Pointer, "bHorizontalPlaneDetection"); set => Native.SetPropBool(Pointer, "bHorizontalPlaneDetection", value); }
        public bool bVerticalPlaneDetection { get => Native.GetPropBool(Pointer, "bVerticalPlaneDetection"); set => Native.SetPropBool(Pointer, "bVerticalPlaneDetection", value); }
        public bool bEnableAutoFocus { get => Native.GetPropBool(Pointer, "bEnableAutoFocus"); set => Native.SetPropBool(Pointer, "bEnableAutoFocus", value); }
        public EARLightEstimationMode LightEstimationMode { get => (EARLightEstimationMode)GetAt<byte>(0x3D); set => SetAt(0x3D, (byte)value); }
        public EARFrameSyncMode FrameSyncMode { get => (EARFrameSyncMode)GetAt<byte>(0x3E); set => SetAt(0x3E, (byte)value); }
        public bool bEnableAutomaticCameraOverlay { get => Native.GetPropBool(Pointer, "bEnableAutomaticCameraOverlay"); set => Native.SetPropBool(Pointer, "bEnableAutomaticCameraOverlay", value); }
        public bool bEnableAutomaticCameraTracking { get => Native.GetPropBool(Pointer, "bEnableAutomaticCameraTracking"); set => Native.SetPropBool(Pointer, "bEnableAutomaticCameraTracking", value); }
        public bool bResetCameraTracking { get => Native.GetPropBool(Pointer, "bResetCameraTracking"); set => Native.SetPropBool(Pointer, "bResetCameraTracking", value); }
        public bool bResetTrackedObjects { get => Native.GetPropBool(Pointer, "bResetTrackedObjects"); set => Native.SetPropBool(Pointer, "bResetTrackedObjects", value); }
        public TArray<System.IntPtr> CandidateImages => new TArray<System.IntPtr>(AddrOf(0x48)); // TArray<UObject*>
        public int MaxNumSimultaneousImagesTracked { get => GetAt<int>(0x58); set => SetAt(0x58, value); }
        public EAREnvironmentCaptureProbeType EnvironmentCaptureProbeType { get => (EAREnvironmentCaptureProbeType)GetAt<byte>(0x5C); set => SetAt(0x5C, (byte)value); }
        public TArray<System.IntPtr> WorldMapData => new TArray<System.IntPtr>(AddrOf(0x60)); // TArray<uint8>
        public TArray<System.IntPtr> CandidateObjects => new TArray<System.IntPtr>(AddrOf(0x70)); // TArray<UObject*>
        public ARVideoFormat DesiredVideoFormat => new ARVideoFormat(AddrOf(0x80));
        public EARFaceTrackingDirection FaceTrackingDirection { get => (EARFaceTrackingDirection)GetAt<byte>(0x8C); set => SetAt(0x8C, (byte)value); }
        public EARFaceTrackingUpdate FaceTrackingUpdate { get => (EARFaceTrackingUpdate)GetAt<byte>(0x8D); set => SetAt(0x8D, (byte)value); }
        public TArray<System.IntPtr> SerializedARCandidateImageDatabase => new TArray<System.IntPtr>(AddrOf(0x90)); // TArray<uint8>
        public EARSessionTrackingFeature EnabledSessionTrackingFeature { get => (EARSessionTrackingFeature)GetAt<byte>(0xA0); set => SetAt(0xA0, (byte)value); }
        /// <summary>[Native] thunk RVA 0x738A8D0 — hookable via Hooks.InstallAt(NativeFunc_ShouldResetTrackedObjects).</summary>
        public static System.IntPtr NativeFunc_ShouldResetTrackedObjects => Memory.ModuleBase() + 0x738A8D0;
        public bool ShouldResetTrackedObjects()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("ShouldResetTrackedObjects", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x738A9B4 — hookable via Hooks.InstallAt(NativeFunc_ShouldResetCameraTracking).</summary>
        public static System.IntPtr NativeFunc_ShouldResetCameraTracking => Memory.ModuleBase() + 0x738A9B4;
        public bool ShouldResetCameraTracking()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("ShouldResetCameraTracking", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x738AB08 — hookable via Hooks.InstallAt(NativeFunc_ShouldRenderCameraOverlay).</summary>
        public static System.IntPtr NativeFunc_ShouldRenderCameraOverlay => Memory.ModuleBase() + 0x738AB08;
        public bool ShouldRenderCameraOverlay()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("ShouldRenderCameraOverlay", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x738AAD0 — hookable via Hooks.InstallAt(NativeFunc_ShouldEnableCameraTracking).</summary>
        public static System.IntPtr NativeFunc_ShouldEnableCameraTracking => Memory.ModuleBase() + 0x738AAD0;
        public bool ShouldEnableCameraTracking()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("ShouldEnableCameraTracking", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x738AA98 — hookable via Hooks.InstallAt(NativeFunc_ShouldEnableAutoFocus).</summary>
        public static System.IntPtr NativeFunc_ShouldEnableAutoFocus => Memory.ModuleBase() + 0x738AA98;
        public bool ShouldEnableAutoFocus()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("ShouldEnableAutoFocus", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x738A518 — hookable via Hooks.InstallAt(NativeFunc_SetWorldMapData).</summary>
        public static System.IntPtr NativeFunc_SetWorldMapData => Memory.ModuleBase() + 0x738A518;
        public void SetWorldMapData(System.IntPtr WorldMapData)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, WorldMapData);
            CallRaw("SetWorldMapData", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7389FC4 — hookable via Hooks.InstallAt(NativeFunc_SetSessionTrackingFeatureToEnable).</summary>
        public static System.IntPtr NativeFunc_SetSessionTrackingFeatureToEnable => Memory.ModuleBase() + 0x7389FC4;
        public void SetSessionTrackingFeatureToEnable(EARSessionTrackingFeature InSessionTrackingFeature)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InSessionTrackingFeature);
            CallRaw("SetSessionTrackingFeatureToEnable", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738A824 — hookable via Hooks.InstallAt(NativeFunc_SetResetTrackedObjects).</summary>
        public static System.IntPtr NativeFunc_SetResetTrackedObjects => Memory.ModuleBase() + 0x738A824;
        public void SetResetTrackedObjects(bool bNewValue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bNewValue?1:0));
            CallRaw("SetResetTrackedObjects", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738A908 — hookable via Hooks.InstallAt(NativeFunc_SetResetCameraTracking).</summary>
        public static System.IntPtr NativeFunc_SetResetCameraTracking => Memory.ModuleBase() + 0x738A908;
        public void SetResetCameraTracking(bool bNewValue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bNewValue?1:0));
            CallRaw("SetResetCameraTracking", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738A09C — hookable via Hooks.InstallAt(NativeFunc_SetFaceTrackingUpdate).</summary>
        public static System.IntPtr NativeFunc_SetFaceTrackingUpdate => Memory.ModuleBase() + 0x738A09C;
        public void SetFaceTrackingUpdate(EARFaceTrackingUpdate InUpdate)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InUpdate);
            CallRaw("SetFaceTrackingUpdate", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738A174 — hookable via Hooks.InstallAt(NativeFunc_SetFaceTrackingDirection).</summary>
        public static System.IntPtr NativeFunc_SetFaceTrackingDirection => Memory.ModuleBase() + 0x738A174;
        public void SetFaceTrackingDirection(EARFaceTrackingDirection InDirection)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InDirection);
            CallRaw("SetFaceTrackingDirection", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738A9EC — hookable via Hooks.InstallAt(NativeFunc_SetEnableAutoFocus).</summary>
        public static System.IntPtr NativeFunc_SetEnableAutoFocus => Memory.ModuleBase() + 0x738A9EC;
        public void SetEnableAutoFocus(bool bNewValue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bNewValue?1:0));
            CallRaw("SetEnableAutoFocus", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738A24C — hookable via Hooks.InstallAt(NativeFunc_SetDesiredVideoFormat).</summary>
        public static System.IntPtr NativeFunc_SetDesiredVideoFormat => Memory.ModuleBase() + 0x738A24C;
        public void SetDesiredVideoFormat(ARVideoFormat NewFormat)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, NewFormat);
            CallRaw("SetDesiredVideoFormat", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738A3D4 — hookable via Hooks.InstallAt(NativeFunc_SetCandidateObjectList).</summary>
        public static System.IntPtr NativeFunc_SetCandidateObjectList => Memory.ModuleBase() + 0x738A3D4;
        public void SetCandidateObjectList(System.IntPtr InCandidateObjects)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InCandidateObjects);
            CallRaw("SetCandidateObjectList", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738A610 — hookable via Hooks.InstallAt(NativeFunc_GetWorldMapData).</summary>
        public static System.IntPtr NativeFunc_GetWorldMapData => Memory.ModuleBase() + 0x738A610;
        public System.IntPtr GetWorldMapData()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetWorldMapData", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738AC10 — hookable via Hooks.InstallAt(NativeFunc_GetWorldAlignment).</summary>
        public static System.IntPtr NativeFunc_GetWorldAlignment => Memory.ModuleBase() + 0x738AC10;
        public EARWorldAlignment GetWorldAlignment()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetWorldAlignment", __pb.Bytes);
            return (EARWorldAlignment)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738ABDC — hookable via Hooks.InstallAt(NativeFunc_GetSessionType).</summary>
        public static System.IntPtr NativeFunc_GetSessionType => Memory.ModuleBase() + 0x738ABDC;
        public EARSessionType GetSessionType()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetSessionType", __pb.Bytes);
            return (EARSessionType)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738ABA8 — hookable via Hooks.InstallAt(NativeFunc_GetPlaneDetectionMode).</summary>
        public static System.IntPtr NativeFunc_GetPlaneDetectionMode => Memory.ModuleBase() + 0x738ABA8;
        public EARPlaneDetectionMode GetPlaneDetectionMode()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetPlaneDetectionMode", __pb.Bytes);
            return (EARPlaneDetectionMode)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738A6C8 — hookable via Hooks.InstallAt(NativeFunc_GetMaxNumSimultaneousImagesTracked).</summary>
        public static System.IntPtr NativeFunc_GetMaxNumSimultaneousImagesTracked => Memory.ModuleBase() + 0x738A6C8;
        public int GetMaxNumSimultaneousImagesTracked()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMaxNumSimultaneousImagesTracked", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738AB74 — hookable via Hooks.InstallAt(NativeFunc_GetLightEstimationMode).</summary>
        public static System.IntPtr NativeFunc_GetLightEstimationMode => Memory.ModuleBase() + 0x738AB74;
        public EARLightEstimationMode GetLightEstimationMode()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetLightEstimationMode", __pb.Bytes);
            return (EARLightEstimationMode)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738AB40 — hookable via Hooks.InstallAt(NativeFunc_GetFrameSyncMode).</summary>
        public static System.IntPtr NativeFunc_GetFrameSyncMode => Memory.ModuleBase() + 0x738AB40;
        public EARFrameSyncMode GetFrameSyncMode()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetFrameSyncMode", __pb.Bytes);
            return (EARFrameSyncMode)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738A140 — hookable via Hooks.InstallAt(NativeFunc_GetFaceTrackingUpdate).</summary>
        public static System.IntPtr NativeFunc_GetFaceTrackingUpdate => Memory.ModuleBase() + 0x738A140;
        public EARFaceTrackingUpdate GetFaceTrackingUpdate()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetFaceTrackingUpdate", __pb.Bytes);
            return (EARFaceTrackingUpdate)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738A218 — hookable via Hooks.InstallAt(NativeFunc_GetFaceTrackingDirection).</summary>
        public static System.IntPtr NativeFunc_GetFaceTrackingDirection => Memory.ModuleBase() + 0x738A218;
        public EARFaceTrackingDirection GetFaceTrackingDirection()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetFaceTrackingDirection", __pb.Bytes);
            return (EARFaceTrackingDirection)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738A694 — hookable via Hooks.InstallAt(NativeFunc_GetEnvironmentCaptureProbeType).</summary>
        public static System.IntPtr NativeFunc_GetEnvironmentCaptureProbeType => Memory.ModuleBase() + 0x738A694;
        public EAREnvironmentCaptureProbeType GetEnvironmentCaptureProbeType()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetEnvironmentCaptureProbeType", __pb.Bytes);
            return (EAREnvironmentCaptureProbeType)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738A068 — hookable via Hooks.InstallAt(NativeFunc_GetEnabledSessionTrackingFeature).</summary>
        public static System.IntPtr NativeFunc_GetEnabledSessionTrackingFeature => Memory.ModuleBase() + 0x738A068;
        public EARSessionTrackingFeature GetEnabledSessionTrackingFeature()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetEnabledSessionTrackingFeature", __pb.Bytes);
            return (EARSessionTrackingFeature)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738A2F8 — hookable via Hooks.InstallAt(NativeFunc_GetDesiredVideoFormat).</summary>
        public static System.IntPtr NativeFunc_GetDesiredVideoFormat => Memory.ModuleBase() + 0x738A2F8;
        public ARVideoFormat GetDesiredVideoFormat()
        {
            var __pb = new ParamBuffer(12);
            CallRaw("GetDesiredVideoFormat", __pb.Bytes);
            return __pb.Get<ARVideoFormat>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738A494 — hookable via Hooks.InstallAt(NativeFunc_GetCandidateObjectList).</summary>
        public static System.IntPtr NativeFunc_GetCandidateObjectList => Memory.ModuleBase() + 0x738A494;
        public System.IntPtr GetCandidateObjectList()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetCandidateObjectList", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738A7A0 — hookable via Hooks.InstallAt(NativeFunc_GetCandidateImageList).</summary>
        public static System.IntPtr NativeFunc_GetCandidateImageList => Memory.ModuleBase() + 0x738A7A0;
        public System.IntPtr GetCandidateImageList()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetCandidateImageList", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x738A330 — hookable via Hooks.InstallAt(NativeFunc_AddCandidateObject).</summary>
        public static System.IntPtr NativeFunc_AddCandidateObject => Memory.ModuleBase() + 0x738A330;
        public void AddCandidateObject(ARCandidateObject CandidateObject)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, CandidateObject);
            CallRaw("AddCandidateObject", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738A6FC — hookable via Hooks.InstallAt(NativeFunc_AddCandidateImage).</summary>
        public static System.IntPtr NativeFunc_AddCandidateImage => Memory.ModuleBase() + 0x738A6FC;
        public void AddCandidateImage(ARCandidateImage NewCandidateImage)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewCandidateImage);
            CallRaw("AddCandidateImage", __pb.Bytes);
        }
    }

    public class ARSharedWorldGameMode : GameMode
    {
        public const string UeClassName = "ARSharedWorldGameMode";
        public ARSharedWorldGameMode(System.IntPtr ptr) : base(ptr) {}
        public static new ARSharedWorldGameMode FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARSharedWorldGameMode(p);
        public static ARSharedWorldGameMode FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARSharedWorldGameMode(o.Pointer); }
        public static ARSharedWorldGameMode[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARSharedWorldGameMode[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARSharedWorldGameMode(a[i].Pointer); return r; }
        public int BufferSizePerChunk { get => GetAt<int>(0x304); set => SetAt(0x304, value); }
        /// <summary>[Native] thunk RVA 0x738C318 — hookable via Hooks.InstallAt(NativeFunc_SetPreviewImageData).</summary>
        public static System.IntPtr NativeFunc_SetPreviewImageData => Memory.ModuleBase() + 0x738C318;
        public void SetPreviewImageData(System.IntPtr ImageData)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, ImageData);
            CallRaw("SetPreviewImageData", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738C20C — hookable via Hooks.InstallAt(NativeFunc_SetARWorldSharingIsReady).</summary>
        public static System.IntPtr NativeFunc_SetARWorldSharingIsReady => Memory.ModuleBase() + 0x738C20C;
        public void SetARWorldSharingIsReady()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetARWorldSharingIsReady", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738C220 — hookable via Hooks.InstallAt(NativeFunc_SetARSharedWorldData).</summary>
        public static System.IntPtr NativeFunc_SetARSharedWorldData => Memory.ModuleBase() + 0x738C220;
        public void SetARSharedWorldData(System.IntPtr ARWorldData)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, ARWorldData);
            CallRaw("SetARSharedWorldData", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738C1D8 — hookable via Hooks.InstallAt(NativeFunc_GetARSharedWorldGameState).</summary>
        public static System.IntPtr NativeFunc_GetARSharedWorldGameState => Memory.ModuleBase() + 0x738C1D8;
        public ARSharedWorldGameState GetARSharedWorldGameState()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetARSharedWorldGameState", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARSharedWorldGameState(__p); }
        }
    }

    public class ARSharedWorldGameState : GameState
    {
        public const string UeClassName = "ARSharedWorldGameState";
        public ARSharedWorldGameState(System.IntPtr ptr) : base(ptr) {}
        public static new ARSharedWorldGameState FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARSharedWorldGameState(p);
        public static ARSharedWorldGameState FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARSharedWorldGameState(o.Pointer); }
        public static ARSharedWorldGameState[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARSharedWorldGameState[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARSharedWorldGameState(a[i].Pointer); return r; }
        public TArray<System.IntPtr> PreviewImageData => new TArray<System.IntPtr>(AddrOf(0x288)); // TArray<uint8>
        public TArray<System.IntPtr> ARWorldData => new TArray<System.IntPtr>(AddrOf(0x298)); // TArray<uint8>
        public int PreviewImageBytesTotal { get => GetAt<int>(0x2A8); set => SetAt(0x2A8, value); }
        public int ARWorldBytesTotal { get => GetAt<int>(0x2AC); set => SetAt(0x2AC, value); }
        public int PreviewImageBytesDelivered { get => GetAt<int>(0x2B0); set => SetAt(0x2B0, value); }
        public int ARWorldBytesDelivered { get => GetAt<int>(0x2B4); set => SetAt(0x2B4, value); }
        public void K2_OnARWorldMapIsReady()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("K2_OnARWorldMapIsReady", __pb.Bytes);
        }
    }

    public class ARSharedWorldPlayerController : PlayerController
    {
        public const string UeClassName = "ARSharedWorldPlayerController";
        public ARSharedWorldPlayerController(System.IntPtr ptr) : base(ptr) {}
        public static new ARSharedWorldPlayerController FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARSharedWorldPlayerController(p);
        public static ARSharedWorldPlayerController FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARSharedWorldPlayerController(o.Pointer); }
        public static ARSharedWorldPlayerController[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARSharedWorldPlayerController[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARSharedWorldPlayerController(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x738DC58 — hookable via Hooks.InstallAt(NativeFunc_ServerMarkReadyForReceiving).</summary>
        public static System.IntPtr NativeFunc_ServerMarkReadyForReceiving => Memory.ModuleBase() + 0x738DC58;
        public void ServerMarkReadyForReceiving()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ServerMarkReadyForReceiving", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738DA04 — hookable via Hooks.InstallAt(NativeFunc_ClientUpdatePreviewImageData).</summary>
        public static System.IntPtr NativeFunc_ClientUpdatePreviewImageData => Memory.ModuleBase() + 0x738DA04;
        public void ClientUpdatePreviewImageData(int Offset, System.IntPtr Buffer)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Offset);
            __pb.Set<System.IntPtr>(0x8, Buffer);
            CallRaw("ClientUpdatePreviewImageData", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738D8D4 — hookable via Hooks.InstallAt(NativeFunc_ClientUpdateARWorldData).</summary>
        public static System.IntPtr NativeFunc_ClientUpdateARWorldData => Memory.ModuleBase() + 0x738D8D4;
        public void ClientUpdateARWorldData(int Offset, System.IntPtr Buffer)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Offset);
            __pb.Set<System.IntPtr>(0x8, Buffer);
            CallRaw("ClientUpdateARWorldData", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x738DB34 — hookable via Hooks.InstallAt(NativeFunc_ClientInitSharedWorld).</summary>
        public static System.IntPtr NativeFunc_ClientInitSharedWorld => Memory.ModuleBase() + 0x738DB34;
        public void ClientInitSharedWorld(int PreviewImageSize, int ARWorldDataSize)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, PreviewImageSize);
            __pb.Set(0x4, ARWorldDataSize);
            CallRaw("ClientInitSharedWorld", __pb.Bytes);
        }
    }

    public class ARSkyLight : SkyLight
    {
        public const string UeClassName = "ARSkyLight";
        public ARSkyLight(System.IntPtr ptr) : base(ptr) {}
        public static new ARSkyLight FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARSkyLight(p);
        public static ARSkyLight FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARSkyLight(o.Pointer); }
        public static ARSkyLight[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARSkyLight[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARSkyLight(a[i].Pointer); return r; }
        public AREnvironmentCaptureProbe CaptureProbe { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new AREnvironmentCaptureProbe(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x738E888 — hookable via Hooks.InstallAt(NativeFunc_SetEnvironmentCaptureProbe).</summary>
        public static System.IntPtr NativeFunc_SetEnvironmentCaptureProbe => Memory.ModuleBase() + 0x738E888;
        public void SetEnvironmentCaptureProbe(AREnvironmentCaptureProbe InCaptureProbe)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InCaptureProbe);
            CallRaw("SetEnvironmentCaptureProbe", __pb.Bytes);
        }
    }

    public class ARTexture : Texture
    {
        public const string UeClassName = "ARTexture";
        public ARTexture(System.IntPtr ptr) : base(ptr) {}
        public static new ARTexture FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTexture(p);
        public static ARTexture FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTexture(o.Pointer); }
        public static ARTexture[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTexture[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTexture(a[i].Pointer); return r; }
        public EARTextureType TextureType { get => (EARTextureType)GetAt<byte>(0xB8); set => SetAt(0xB8, (byte)value); }
        public float Timestamp { get => GetAt<float>(0xBC); set => SetAt(0xBC, value); }
        public Guid ExternalTextureGuid => new Guid(AddrOf(0xC0));
        public Vector2D Size => new Vector2D(AddrOf(0xD0));
    }

    public class ARTextureCameraImage : ARTexture
    {
        public const string UeClassName = "ARTextureCameraImage";
        public ARTextureCameraImage(System.IntPtr ptr) : base(ptr) {}
        public static new ARTextureCameraImage FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTextureCameraImage(p);
        public static ARTextureCameraImage FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTextureCameraImage(o.Pointer); }
        public static ARTextureCameraImage[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTextureCameraImage[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTextureCameraImage(a[i].Pointer); return r; }
    }

    public class ARTextureCameraDepth : ARTexture
    {
        public const string UeClassName = "ARTextureCameraDepth";
        public ARTextureCameraDepth(System.IntPtr ptr) : base(ptr) {}
        public static new ARTextureCameraDepth FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTextureCameraDepth(p);
        public static ARTextureCameraDepth FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTextureCameraDepth(o.Pointer); }
        public static ARTextureCameraDepth[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTextureCameraDepth[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTextureCameraDepth(a[i].Pointer); return r; }
        public EARDepthQuality DepthQuality { get => (EARDepthQuality)GetAt<byte>(0xD8); set => SetAt(0xD8, (byte)value); }
        public EARDepthAccuracy DepthAccuracy { get => (EARDepthAccuracy)GetAt<byte>(0xD9); set => SetAt(0xD9, (byte)value); }
        public bool bIsTemporallySmoothed { get => Native.GetPropBool(Pointer, "bIsTemporallySmoothed"); set => Native.SetPropBool(Pointer, "bIsTemporallySmoothed", value); }
    }

    public class AREnvironmentCaptureProbeTexture : TextureCube
    {
        public const string UeClassName = "AREnvironmentCaptureProbeTexture";
        public AREnvironmentCaptureProbeTexture(System.IntPtr ptr) : base(ptr) {}
        public static new AREnvironmentCaptureProbeTexture FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AREnvironmentCaptureProbeTexture(p);
        public static AREnvironmentCaptureProbeTexture FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AREnvironmentCaptureProbeTexture(o.Pointer); }
        public static AREnvironmentCaptureProbeTexture[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AREnvironmentCaptureProbeTexture[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AREnvironmentCaptureProbeTexture(a[i].Pointer); return r; }
        public EARTextureType TextureType { get => (EARTextureType)GetAt<byte>(0x110); set => SetAt(0x110, (byte)value); }
        public float Timestamp { get => GetAt<float>(0x114); set => SetAt(0x114, value); }
        public Guid ExternalTextureGuid => new Guid(AddrOf(0x118));
        public Vector2D Size => new Vector2D(AddrOf(0x128));
    }

    public class ARTraceResultDummy : Object
    {
        public const string UeClassName = "ARTraceResultDummy";
        public ARTraceResultDummy(System.IntPtr ptr) : base(ptr) {}
        public static new ARTraceResultDummy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTraceResultDummy(p);
        public static ARTraceResultDummy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTraceResultDummy(o.Pointer); }
        public static ARTraceResultDummy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTraceResultDummy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTraceResultDummy(a[i].Pointer); return r; }
    }

    public class ARTrackedGeometry : Object
    {
        public const string UeClassName = "ARTrackedGeometry";
        public ARTrackedGeometry(System.IntPtr ptr) : base(ptr) {}
        public static new ARTrackedGeometry FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTrackedGeometry(p);
        public static ARTrackedGeometry FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTrackedGeometry(o.Pointer); }
        public static ARTrackedGeometry[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTrackedGeometry[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTrackedGeometry(a[i].Pointer); return r; }
        public Guid UniqueId => new Guid(AddrOf(0x28));
        public Transform LocalToTrackingTransform => new Transform(AddrOf(0x40));
        public Transform LocalToAlignedTrackingTransform => new Transform(AddrOf(0x70));
        public EARTrackingState TrackingState { get => (EARTrackingState)GetAt<byte>(0xA0); set => SetAt(0xA0, (byte)value); }
        public MRMeshComponent UnderlyingMesh { get { var __p = GetAt<System.IntPtr>(0xB0); return __p==System.IntPtr.Zero?null:new MRMeshComponent(__p); } set => SetAt(0xB0, value?.Pointer ?? System.IntPtr.Zero); }
        public EARObjectClassification ObjectClassification { get => (EARObjectClassification)GetAt<byte>(0xB8); set => SetAt(0xB8, (byte)value); }
        public int LastUpdateFrameNumber { get => GetAt<int>(0xD0); set => SetAt(0xD0, value); }
        public string DebugName => Native.GetPropName(Pointer, "DebugName"); // FName
        public FName DebugName_Raw { get => GetAt<FName>(0xE0); set => SetAt(0xE0, value); }
        /// <summary>[Native] thunk RVA 0x7391ACC — hookable via Hooks.InstallAt(NativeFunc_IsTracked).</summary>
        public static System.IntPtr NativeFunc_IsTracked => Memory.ModuleBase() + 0x7391ACC;
        public bool IsTracked()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsTracked", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73919FC — hookable via Hooks.InstallAt(NativeFunc_GetUnderlyingMesh).</summary>
        public static System.IntPtr NativeFunc_GetUnderlyingMesh => Memory.ModuleBase() + 0x73919FC;
        public MRMeshComponent GetUnderlyingMesh()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetUnderlyingMesh", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MRMeshComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7391B04 — hookable via Hooks.InstallAt(NativeFunc_GetTrackingState).</summary>
        public static System.IntPtr NativeFunc_GetTrackingState => Memory.ModuleBase() + 0x7391B04;
        public EARTrackingState GetTrackingState()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetTrackingState", __pb.Bytes);
            return (EARTrackingState)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73919E0 — hookable via Hooks.InstallAt(NativeFunc_GetObjectClassification).</summary>
        public static System.IntPtr NativeFunc_GetObjectClassification => Memory.ModuleBase() + 0x73919E0;
        public EARObjectClassification GetObjectClassification()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetObjectClassification", __pb.Bytes);
            return (EARObjectClassification)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7391BA4 — hookable via Hooks.InstallAt(NativeFunc_GetLocalToWorldTransform).</summary>
        public static System.IntPtr NativeFunc_GetLocalToWorldTransform => Memory.ModuleBase() + 0x7391BA4;
        public Transform GetLocalToWorldTransform()
        {
            var __pb = new ParamBuffer(48);
            CallRaw("GetLocalToWorldTransform", __pb.Bytes);
            return __pb.Get<Transform>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7391B38 — hookable via Hooks.InstallAt(NativeFunc_GetLocalToTrackingTransform).</summary>
        public static System.IntPtr NativeFunc_GetLocalToTrackingTransform => Memory.ModuleBase() + 0x7391B38;
        public Transform GetLocalToTrackingTransform()
        {
            var __pb = new ParamBuffer(48);
            CallRaw("GetLocalToTrackingTransform", __pb.Bytes);
            return __pb.Get<Transform>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7391A30 — hookable via Hooks.InstallAt(NativeFunc_GetLastUpdateTimestamp).</summary>
        public static System.IntPtr NativeFunc_GetLastUpdateTimestamp => Memory.ModuleBase() + 0x7391A30;
        public float GetLastUpdateTimestamp()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetLastUpdateTimestamp", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7391A64 — hookable via Hooks.InstallAt(NativeFunc_GetLastUpdateFrameNumber).</summary>
        public static System.IntPtr NativeFunc_GetLastUpdateFrameNumber => Memory.ModuleBase() + 0x7391A64;
        public int GetLastUpdateFrameNumber()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetLastUpdateFrameNumber", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7391A98 — hookable via Hooks.InstallAt(NativeFunc_GetDebugName).</summary>
        public static System.IntPtr NativeFunc_GetDebugName => Memory.ModuleBase() + 0x7391A98;
        public FName GetDebugName()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDebugName", __pb.Bytes);
            return __pb.Get<FName>(0x0);
        }
    }

    public class ARPlaneGeometry : ARTrackedGeometry
    {
        public const string UeClassName = "ARPlaneGeometry";
        public ARPlaneGeometry(System.IntPtr ptr) : base(ptr) {}
        public static new ARPlaneGeometry FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARPlaneGeometry(p);
        public static ARPlaneGeometry FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARPlaneGeometry(o.Pointer); }
        public static ARPlaneGeometry[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARPlaneGeometry[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARPlaneGeometry(a[i].Pointer); return r; }
        public EARPlaneOrientation Orientation { get => (EARPlaneOrientation)GetAt<byte>(0xE8); set => SetAt(0xE8, (byte)value); }
        public Vector Center => new Vector(AddrOf(0xEC));
        public Vector Extent => new Vector(AddrOf(0xF8));
        public ARPlaneGeometry SubsumedBy { get { var __p = GetAt<System.IntPtr>(0x118); return __p==System.IntPtr.Zero?null:new ARPlaneGeometry(__p); } set => SetAt(0x118, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x7392348 — hookable via Hooks.InstallAt(NativeFunc_GetSubsumedBy).</summary>
        public static System.IntPtr NativeFunc_GetSubsumedBy => Memory.ModuleBase() + 0x7392348;
        public ARPlaneGeometry GetSubsumedBy()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSubsumedBy", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARPlaneGeometry(__p); }
        }
        /// <summary>[Native] thunk RVA 0x739232C — hookable via Hooks.InstallAt(NativeFunc_GetOrientation).</summary>
        public static System.IntPtr NativeFunc_GetOrientation => Memory.ModuleBase() + 0x739232C;
        public EARPlaneOrientation GetOrientation()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetOrientation", __pb.Bytes);
            return (EARPlaneOrientation)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7392454 — hookable via Hooks.InstallAt(NativeFunc_GetExtent).</summary>
        public static System.IntPtr NativeFunc_GetExtent => Memory.ModuleBase() + 0x7392454;
        public Vector GetExtent()
        {
            var __pb = new ParamBuffer(12);
            CallRaw("GetExtent", __pb.Bytes);
            return __pb.Get<Vector>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7392478 — hookable via Hooks.InstallAt(NativeFunc_GetCenter).</summary>
        public static System.IntPtr NativeFunc_GetCenter => Memory.ModuleBase() + 0x7392478;
        public Vector GetCenter()
        {
            var __pb = new ParamBuffer(12);
            CallRaw("GetCenter", __pb.Bytes);
            return __pb.Get<Vector>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7392364 — hookable via Hooks.InstallAt(NativeFunc_GetBoundaryPolygonInLocalSpace).</summary>
        public static System.IntPtr NativeFunc_GetBoundaryPolygonInLocalSpace => Memory.ModuleBase() + 0x7392364;
        public System.IntPtr GetBoundaryPolygonInLocalSpace()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetBoundaryPolygonInLocalSpace", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class ARTrackedPoint : ARTrackedGeometry
    {
        public const string UeClassName = "ARTrackedPoint";
        public ARTrackedPoint(System.IntPtr ptr) : base(ptr) {}
        public static new ARTrackedPoint FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTrackedPoint(p);
        public static ARTrackedPoint FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTrackedPoint(o.Pointer); }
        public static ARTrackedPoint[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTrackedPoint[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTrackedPoint(a[i].Pointer); return r; }
    }

    public class ARTrackedImage : ARTrackedGeometry
    {
        public const string UeClassName = "ARTrackedImage";
        public ARTrackedImage(System.IntPtr ptr) : base(ptr) {}
        public static new ARTrackedImage FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTrackedImage(p);
        public static ARTrackedImage FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTrackedImage(o.Pointer); }
        public static ARTrackedImage[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTrackedImage[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTrackedImage(a[i].Pointer); return r; }
        public ARCandidateImage DetectedImage { get { var __p = GetAt<System.IntPtr>(0xE8); return __p==System.IntPtr.Zero?null:new ARCandidateImage(__p); } set => SetAt(0xE8, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector2D EstimatedSize => new Vector2D(AddrOf(0xF0));
        /// <summary>[Native] thunk RVA 0x7392F04 — hookable via Hooks.InstallAt(NativeFunc_GetEstimateSize).</summary>
        public static System.IntPtr NativeFunc_GetEstimateSize => Memory.ModuleBase() + 0x7392F04;
        public Vector2D GetEstimateSize()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetEstimateSize", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7392F38 — hookable via Hooks.InstallAt(NativeFunc_GetDetectedImage).</summary>
        public static System.IntPtr NativeFunc_GetDetectedImage => Memory.ModuleBase() + 0x7392F38;
        public ARCandidateImage GetDetectedImage()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDetectedImage", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARCandidateImage(__p); }
        }
    }

    public class ARTrackedQRCode : ARTrackedImage
    {
        public const string UeClassName = "ARTrackedQRCode";
        public ARTrackedQRCode(System.IntPtr ptr) : base(ptr) {}
        public static new ARTrackedQRCode FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTrackedQRCode(p);
        public static ARTrackedQRCode FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTrackedQRCode(o.Pointer); }
        public static ARTrackedQRCode[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTrackedQRCode[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTrackedQRCode(a[i].Pointer); return r; }
        public string QRCode => Native.GetPropString(Pointer, "QRCode"); // FString
        public int Version { get => GetAt<int>(0x108); set => SetAt(0x108, value); }
    }

    public class ARFaceGeometry : ARTrackedGeometry
    {
        public const string UeClassName = "ARFaceGeometry";
        public ARFaceGeometry(System.IntPtr ptr) : base(ptr) {}
        public static new ARFaceGeometry FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARFaceGeometry(p);
        public static ARFaceGeometry FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARFaceGeometry(o.Pointer); }
        public static ARFaceGeometry[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARFaceGeometry[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARFaceGeometry(a[i].Pointer); return r; }
        public Vector LookAtTarget => new Vector(AddrOf(0xE8));
        public bool bIsTracked { get => Native.GetPropBool(Pointer, "bIsTracked"); set => Native.SetPropBool(Pointer, "bIsTracked", value); }
        public System.IntPtr BlendShapes => AddrOf(0xF8); // 
        /// <summary>[Native] thunk RVA 0x73938D0 — hookable via Hooks.InstallAt(NativeFunc_GetWorldSpaceEyeTransform).</summary>
        public static System.IntPtr NativeFunc_GetWorldSpaceEyeTransform => Memory.ModuleBase() + 0x73938D0;
        public Transform GetWorldSpaceEyeTransform(EAREye eye)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<byte>(0x0, (byte)eye);
            CallRaw("GetWorldSpaceEyeTransform", __pb.Bytes);
            return __pb.Get<Transform>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x739398C — hookable via Hooks.InstallAt(NativeFunc_GetLocalSpaceEyeTransform).</summary>
        public static System.IntPtr NativeFunc_GetLocalSpaceEyeTransform => Memory.ModuleBase() + 0x739398C;
        public Transform GetLocalSpaceEyeTransform(EAREye eye)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<byte>(0x0, (byte)eye);
            CallRaw("GetLocalSpaceEyeTransform", __pb.Bytes);
            return __pb.Get<Transform>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x7393B14 — hookable via Hooks.InstallAt(NativeFunc_GetBlendShapeValue).</summary>
        public static System.IntPtr NativeFunc_GetBlendShapeValue => Memory.ModuleBase() + 0x7393B14;
        public float GetBlendShapeValue(EARFaceBlendShape BlendShape)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)BlendShape);
            CallRaw("GetBlendShapeValue", __pb.Bytes);
            return __pb.Get<float>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x7393A44 — hookable via Hooks.InstallAt(NativeFunc_GetBlendShapes).</summary>
        public static System.IntPtr NativeFunc_GetBlendShapes => Memory.ModuleBase() + 0x7393A44;
        public System.IntPtr GetBlendShapes()
        {
            var __pb = new ParamBuffer(80);
            CallRaw("GetBlendShapes", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class AREnvironmentCaptureProbe : ARTrackedGeometry
    {
        public const string UeClassName = "AREnvironmentCaptureProbe";
        public AREnvironmentCaptureProbe(System.IntPtr ptr) : base(ptr) {}
        public static new AREnvironmentCaptureProbe FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AREnvironmentCaptureProbe(p);
        public static AREnvironmentCaptureProbe FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AREnvironmentCaptureProbe(o.Pointer); }
        public static AREnvironmentCaptureProbe[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AREnvironmentCaptureProbe[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AREnvironmentCaptureProbe(a[i].Pointer); return r; }
        public AREnvironmentCaptureProbeTexture EnvironmentCaptureTexture { get { var __p = GetAt<System.IntPtr>(0xF8); return __p==System.IntPtr.Zero?null:new AREnvironmentCaptureProbeTexture(__p); } set => SetAt(0xF8, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x7394314 — hookable via Hooks.InstallAt(NativeFunc_GetExtent).</summary>
        public static System.IntPtr NativeFunc_GetExtent => Memory.ModuleBase() + 0x7394314;
        public Vector GetExtent()
        {
            var __pb = new ParamBuffer(12);
            CallRaw("GetExtent", __pb.Bytes);
            return __pb.Get<Vector>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73942E0 — hookable via Hooks.InstallAt(NativeFunc_GetEnvironmentCaptureTexture).</summary>
        public static System.IntPtr NativeFunc_GetEnvironmentCaptureTexture => Memory.ModuleBase() + 0x73942E0;
        public AREnvironmentCaptureProbeTexture GetEnvironmentCaptureTexture()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetEnvironmentCaptureTexture", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new AREnvironmentCaptureProbeTexture(__p); }
        }
    }

    public class ARTrackedObject : ARTrackedGeometry
    {
        public const string UeClassName = "ARTrackedObject";
        public ARTrackedObject(System.IntPtr ptr) : base(ptr) {}
        public static new ARTrackedObject FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTrackedObject(p);
        public static ARTrackedObject FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTrackedObject(o.Pointer); }
        public static ARTrackedObject[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTrackedObject[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTrackedObject(a[i].Pointer); return r; }
        public ARCandidateObject DetectedObject { get { var __p = GetAt<System.IntPtr>(0xE8); return __p==System.IntPtr.Zero?null:new ARCandidateObject(__p); } set => SetAt(0xE8, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x7394880 — hookable via Hooks.InstallAt(NativeFunc_GetDetectedObject).</summary>
        public static System.IntPtr NativeFunc_GetDetectedObject => Memory.ModuleBase() + 0x7394880;
        public ARCandidateObject GetDetectedObject()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDetectedObject", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ARCandidateObject(__p); }
        }
    }

    public class ARTrackedPose : ARTrackedGeometry
    {
        public const string UeClassName = "ARTrackedPose";
        public ARTrackedPose(System.IntPtr ptr) : base(ptr) {}
        public static new ARTrackedPose FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTrackedPose(p);
        public static ARTrackedPose FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTrackedPose(o.Pointer); }
        public static ARTrackedPose[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTrackedPose[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTrackedPose(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7394DB0 — hookable via Hooks.InstallAt(NativeFunc_GetTrackedPoseData).</summary>
        public static System.IntPtr NativeFunc_GetTrackedPoseData => Memory.ModuleBase() + 0x7394DB0;
        public ARPose3D GetTrackedPoseData()
        {
            var __pb = new ParamBuffer(80);
            CallRaw("GetTrackedPoseData", __pb.Bytes);
            return __pb.Get<ARPose3D>(0x0);
        }
    }

    public class ARTrackableNotifyComponent : ActorComponent
    {
        public const string UeClassName = "ARTrackableNotifyComponent";
        public ARTrackableNotifyComponent(System.IntPtr ptr) : base(ptr) {}
        public static new ARTrackableNotifyComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTrackableNotifyComponent(p);
        public static ARTrackableNotifyComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTrackableNotifyComponent(o.Pointer); }
        public static ARTrackableNotifyComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTrackableNotifyComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTrackableNotifyComponent(a[i].Pointer); return r; }
        public System.IntPtr OnAddTrackedGeometry => AddrOf(0xB0); // 
        public System.IntPtr OnUpdateTrackedGeometry => AddrOf(0xC0); // 
        public System.IntPtr OnRemoveTrackedGeometry => AddrOf(0xD0); // 
        public System.IntPtr OnAddTrackedPlane => AddrOf(0xE0); // 
        public System.IntPtr OnUpdateTrackedPlane => AddrOf(0xF0); // 
        public System.IntPtr OnRemoveTrackedPlane => AddrOf(0x100); // 
        public System.IntPtr OnAddTrackedPoint => AddrOf(0x110); // 
        public System.IntPtr OnUpdateTrackedPoint => AddrOf(0x120); // 
        public System.IntPtr OnRemoveTrackedPoint => AddrOf(0x130); // 
        public System.IntPtr OnAddTrackedImage => AddrOf(0x140); // 
        public System.IntPtr OnUpdateTrackedImage => AddrOf(0x150); // 
        public System.IntPtr OnRemoveTrackedImage => AddrOf(0x160); // 
        public System.IntPtr OnAddTrackedFace => AddrOf(0x170); // 
        public System.IntPtr OnUpdateTrackedFace => AddrOf(0x180); // 
        public System.IntPtr OnRemoveTrackedFace => AddrOf(0x190); // 
        public System.IntPtr OnAddTrackedEnvProbe => AddrOf(0x1A0); // 
        public System.IntPtr OnUpdateTrackedEnvProbe => AddrOf(0x1B0); // 
        public System.IntPtr OnRemoveTrackedEnvProbe => AddrOf(0x1C0); // 
        public System.IntPtr OnAddTrackedObject => AddrOf(0x1D0); // 
        public System.IntPtr OnUpdateTrackedObject => AddrOf(0x1E0); // 
        public System.IntPtr OnRemoveTrackedObject => AddrOf(0x1F0); // 
    }

    public class ARTypesDummyClass : Object
    {
        public const string UeClassName = "ARTypesDummyClass";
        public ARTypesDummyClass(System.IntPtr ptr) : base(ptr) {}
        public static new ARTypesDummyClass FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARTypesDummyClass(p);
        public static ARTypesDummyClass FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARTypesDummyClass(o.Pointer); }
        public static ARTypesDummyClass[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARTypesDummyClass[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARTypesDummyClass(a[i].Pointer); return r; }
    }

    public class ARCandidateImage : DataAsset
    {
        public const string UeClassName = "ARCandidateImage";
        public ARCandidateImage(System.IntPtr ptr) : base(ptr) {}
        public static new ARCandidateImage FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARCandidateImage(p);
        public static ARCandidateImage FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARCandidateImage(o.Pointer); }
        public static ARCandidateImage[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARCandidateImage[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARCandidateImage(a[i].Pointer); return r; }
        public Texture2D CandidateTexture { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public string FriendlyName => Native.GetPropString(Pointer, "FriendlyName"); // FString
        public float Width { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float Height { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public EARCandidateImageOrientation Orientation { get => (EARCandidateImageOrientation)GetAt<byte>(0x50); set => SetAt(0x50, (byte)value); }
        /// <summary>[Native] thunk RVA 0x7398074 — hookable via Hooks.InstallAt(NativeFunc_GetPhysicalWidth).</summary>
        public static System.IntPtr NativeFunc_GetPhysicalWidth => Memory.ModuleBase() + 0x7398074;
        public float GetPhysicalWidth()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPhysicalWidth", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7398058 — hookable via Hooks.InstallAt(NativeFunc_GetPhysicalHeight).</summary>
        public static System.IntPtr NativeFunc_GetPhysicalHeight => Memory.ModuleBase() + 0x7398058;
        public float GetPhysicalHeight()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPhysicalHeight", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x739803C — hookable via Hooks.InstallAt(NativeFunc_GetOrientation).</summary>
        public static System.IntPtr NativeFunc_GetOrientation => Memory.ModuleBase() + 0x739803C;
        public EARCandidateImageOrientation GetOrientation()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetOrientation", __pb.Bytes);
            return (EARCandidateImageOrientation)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7398090 — hookable via Hooks.InstallAt(NativeFunc_GetFriendlyName).</summary>
        public static System.IntPtr NativeFunc_GetFriendlyName => Memory.ModuleBase() + 0x7398090;
        public System.IntPtr GetFriendlyName()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetFriendlyName", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7398114 — hookable via Hooks.InstallAt(NativeFunc_GetCandidateTexture).</summary>
        public static System.IntPtr NativeFunc_GetCandidateTexture => Memory.ModuleBase() + 0x7398114;
        public Texture2D GetCandidateTexture()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetCandidateTexture", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Texture2D(__p); }
        }
    }

    public class ARCandidateObject : DataAsset
    {
        public const string UeClassName = "ARCandidateObject";
        public ARCandidateObject(System.IntPtr ptr) : base(ptr) {}
        public static new ARCandidateObject FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ARCandidateObject(p);
        public static ARCandidateObject FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ARCandidateObject(o.Pointer); }
        public static ARCandidateObject[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ARCandidateObject[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ARCandidateObject(a[i].Pointer); return r; }
        public TArray<System.IntPtr> CandidateObjectData => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<uint8>
        public string FriendlyName => Native.GetPropString(Pointer, "FriendlyName"); // FString
        public Box BoundingBox => new Box(AddrOf(0x50));
        /// <summary>[Native] thunk RVA 0x73987F4 — hookable via Hooks.InstallAt(NativeFunc_SetFriendlyName).</summary>
        public static System.IntPtr NativeFunc_SetFriendlyName => Memory.ModuleBase() + 0x73987F4;
        public void SetFriendlyName(System.IntPtr NewName)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewName);
            CallRaw("SetFriendlyName", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7398978 — hookable via Hooks.InstallAt(NativeFunc_SetCandidateObjectData).</summary>
        public static System.IntPtr NativeFunc_SetCandidateObjectData => Memory.ModuleBase() + 0x7398978;
        public void SetCandidateObjectData(System.IntPtr InCandidateObject)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InCandidateObject);
            CallRaw("SetCandidateObjectData", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7398718 — hookable via Hooks.InstallAt(NativeFunc_SetBoundingBox).</summary>
        public static System.IntPtr NativeFunc_SetBoundingBox => Memory.ModuleBase() + 0x7398718;
        public void SetBoundingBox(Box InBoundingBox)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<System.IntPtr>(0x0, InBoundingBox);
            CallRaw("SetBoundingBox", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73988F4 — hookable via Hooks.InstallAt(NativeFunc_GetFriendlyName).</summary>
        public static System.IntPtr NativeFunc_GetFriendlyName => Memory.ModuleBase() + 0x73988F4;
        public System.IntPtr GetFriendlyName()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetFriendlyName", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7398A88 — hookable via Hooks.InstallAt(NativeFunc_GetCandidateObjectData).</summary>
        public static System.IntPtr NativeFunc_GetCandidateObjectData => Memory.ModuleBase() + 0x7398A88;
        public System.IntPtr GetCandidateObjectData()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetCandidateObjectData", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73987D0 — hookable via Hooks.InstallAt(NativeFunc_GetBoundingBox).</summary>
        public static System.IntPtr NativeFunc_GetBoundingBox => Memory.ModuleBase() + 0x73987D0;
        public Box GetBoundingBox()
        {
            var __pb = new ParamBuffer(28);
            CallRaw("GetBoundingBox", __pb.Bytes);
            return __pb.Get<Box>(0x0);
        }
    }

}
