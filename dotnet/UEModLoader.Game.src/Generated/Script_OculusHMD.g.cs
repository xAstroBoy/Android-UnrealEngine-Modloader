// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/OculusHMD
using System;

namespace UEModLoader.Game
{
    public enum EOculusDeviceType
    {
        OculusMobile_Deprecated0 = 0,
        OculusQuest = 1,
        OculusMobile_Placeholder9 = 2,
        Rift = 100,
        Rift_S = 101,
        Quest_Link = 102,
        OculusUnknown = 200,
    }

    public enum EHandTrackingSupport
    {
        ControllersOnly = 0,
        ControllersAndHands = 1,
        HandsOnly = 2,
    }

    public enum EColorSpace
    {
        Unknown = 0,
        Unmanaged = 1,
        Rec = 2,
        Rift_CV1 = 4,
        Rift_S = 5,
        Quest = 6,
        P3 = 7,
        Adobe_RGB = 8,
    }

    public enum EBoundaryType
    {
        Boundary_Outer = 0,
        Boundary_PlayArea = 1,
    }

    public enum EFixedFoveatedRenderingLevel
    {
        FFR_Off = 0,
        FFR_Low = 1,
        FFR_Medium = 2,
        FFR_High = 3,
        FFR_HighTop = 4,
    }

    public enum ETrackedDeviceType
    {
        None = 0,
        HMD = 1,
        LTouch = 2,
        RTouch = 3,
        Touch = 4,
        DeviceObjectZero = 5,
        All = 6,
    }

    public class GuardianTestResult : StructProxy
    {
        public GuardianTestResult(global::System.IntPtr ptr) : base(ptr) {}
        public bool IsTriggering { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public ETrackedDeviceType DeviceType { get => (ETrackedDeviceType)GetAt<byte>(0x1); set => SetAt(0x1, (byte)value); }
        public float ClosestDistance { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public Vector ClosestPoint => new Vector(AddrOf(0x8));
        public Vector ClosestPointNormal => new Vector(AddrOf(0x14));
    }

    public class HmdUserProfile : StructProxy
    {
        public HmdUserProfile(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string Gender => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public float PlayerHeight { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public float EyeHeight { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public float IPD { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public Vector2D NeckToEyeDistance => new Vector2D(AddrOf(0x2C));
        public TArray<global::System.IntPtr> ExtraFields => new TArray<global::System.IntPtr>(AddrOf(0x38)); // TArray<struct>
    }

    public class HmdUserProfileField : StructProxy
    {
        public HmdUserProfileField(global::System.IntPtr ptr) : base(ptr) {}
        public string FieldName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string FieldValue => Native.ReadFStringAt(AddrOf(0x10)); // FString
    }

    public class OculusSplashDesc : StructProxy
    {
        public OculusSplashDesc(global::System.IntPtr ptr) : base(ptr) {}
        public SoftObjectPath TexturePath => new SoftObjectPath(AddrOf(0x0));
        public Transform TransformInMeters => new Transform(AddrOf(0x20));
        public Vector2D QuadSizeInMeters => new Vector2D(AddrOf(0x50));
        public Quat DeltaRotation => new Quat(AddrOf(0x60));
        public Vector2D TextureOffset => new Vector2D(AddrOf(0x70));
        public Vector2D TextureScale => new Vector2D(AddrOf(0x78));
        public bool bNoAlphaChannel { get => (GetAt<byte>(0x80) & 0xFF) != 0; set { var __b = GetAt<byte>(0x80); SetAt(0x80, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class OculusFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "OculusFunctionLibrary";
        public OculusFunctionLibrary(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusFunctionLibrary FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusFunctionLibrary(p);
        public static OculusFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusFunctionLibrary(o.Pointer); }
        public static OculusFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5C5C4E8 — hookable via Hooks.InstallAt(NativeFunc_SetReorientHMDOnControllerRecenter).</summary>
        public static global::System.IntPtr NativeFunc_SetReorientHMDOnControllerRecenter => Memory.ModuleBase() + 0x5C5C4E8;
        public void SetReorientHMDOnControllerRecenter(bool recenterMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(recenterMode?1:0));
            CallRaw("SetReorientHMDOnControllerRecenter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5C118 — hookable via Hooks.InstallAt(NativeFunc_SetPositionScale3D).</summary>
        public static global::System.IntPtr NativeFunc_SetPositionScale3D => Memory.ModuleBase() + 0x5C5C118;
        public void SetPositionScale3D(global::System.IntPtr PosScale3D)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, PosScale3D);
            CallRaw("SetPositionScale3D", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5AEC0 — hookable via Hooks.InstallAt(NativeFunc_SetGuardianVisibility).</summary>
        public static global::System.IntPtr NativeFunc_SetGuardianVisibility => Memory.ModuleBase() + 0x5C5AEC0;
        public void SetGuardianVisibility(bool GuardianVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(GuardianVisible?1:0));
            CallRaw("SetGuardianVisibility", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5BA60 — hookable via Hooks.InstallAt(NativeFunc_SetFixedFoveatedRenderingLevel).</summary>
        public static global::System.IntPtr NativeFunc_SetFixedFoveatedRenderingLevel => Memory.ModuleBase() + 0x5C5BA60;
        public void SetFixedFoveatedRenderingLevel(EFixedFoveatedRenderingLevel Level, bool isDynamic)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Level);
            __pb.Set<byte>(0x1, (byte)(isDynamic?1:0));
            CallRaw("SetFixedFoveatedRenderingLevel", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5B804 — hookable via Hooks.InstallAt(NativeFunc_SetDisplayFrequency).</summary>
        public static global::System.IntPtr NativeFunc_SetDisplayFrequency => Memory.ModuleBase() + 0x5C5B804;
        public void SetDisplayFrequency(float RequestedFrequency)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, RequestedFrequency);
            CallRaw("SetDisplayFrequency", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5C584 — hookable via Hooks.InstallAt(NativeFunc_SetCPUAndGPULevels).</summary>
        public static global::System.IntPtr NativeFunc_SetCPUAndGPULevels => Memory.ModuleBase() + 0x5C5C584;
        public void SetCPUAndGPULevels(int CPULevel, int GPULevel)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, CPULevel);
            __pb.Set(0x4, GPULevel);
            CallRaw("SetCPUAndGPULevels", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5B5AC — hookable via Hooks.InstallAt(NativeFunc_SetColorScaleAndOffset).</summary>
        public static global::System.IntPtr NativeFunc_SetColorScaleAndOffset => Memory.ModuleBase() + 0x5C5B5AC;
        public void SetColorScaleAndOffset(global::System.IntPtr ColorScale, global::System.IntPtr ColorOffset, bool bApplyToAllLayers)
        {
            var __pb = new ParamBuffer(33);
            __pb.Set<global::System.IntPtr>(0x0, ColorScale);
            __pb.Set<global::System.IntPtr>(0x10, ColorOffset);
            __pb.Set<byte>(0x20, (byte)(bApplyToAllLayers?1:0));
            CallRaw("SetColorScaleAndOffset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5B4AC — hookable via Hooks.InstallAt(NativeFunc_SetClientColorDesc).</summary>
        public static global::System.IntPtr NativeFunc_SetClientColorDesc => Memory.ModuleBase() + 0x5C5B4AC;
        public void SetClientColorDesc(EColorSpace ColorSpace)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)ColorSpace);
            CallRaw("SetClientColorDesc", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5C000 — hookable via Hooks.InstallAt(NativeFunc_SetBaseRotationAndPositionOffset).</summary>
        public static global::System.IntPtr NativeFunc_SetBaseRotationAndPositionOffset => Memory.ModuleBase() + 0x5C5C000;
        public void SetBaseRotationAndPositionOffset(global::System.IntPtr BaseRot, global::System.IntPtr PosOffset, byte Options)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<global::System.IntPtr>(0x0, BaseRot);
            __pb.Set<global::System.IntPtr>(0xC, PosOffset);
            __pb.Set(0x18, Options);
            CallRaw("SetBaseRotationAndPositionOffset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5C294 — hookable via Hooks.InstallAt(NativeFunc_SetBaseRotationAndBaseOffsetInMeters).</summary>
        public static global::System.IntPtr NativeFunc_SetBaseRotationAndBaseOffsetInMeters => Memory.ModuleBase() + 0x5C5C294;
        public void SetBaseRotationAndBaseOffsetInMeters(global::System.IntPtr Rotation, global::System.IntPtr BaseOffsetInMeters, byte Options)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<global::System.IntPtr>(0x0, Rotation);
            __pb.Set<global::System.IntPtr>(0xC, BaseOffsetInMeters);
            __pb.Set(0x18, Options);
            CallRaw("SetBaseRotationAndBaseOffsetInMeters", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5B3C4 — hookable via Hooks.InstallAt(NativeFunc_IsGuardianDisplayed).</summary>
        public static global::System.IntPtr NativeFunc_IsGuardianDisplayed => Memory.ModuleBase() + 0x5C5B3C4;
        public bool IsGuardianDisplayed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsGuardianDisplayed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C5B38C — hookable via Hooks.InstallAt(NativeFunc_IsGuardianConfigured).</summary>
        public static global::System.IntPtr NativeFunc_IsGuardianConfigured => Memory.ModuleBase() + 0x5C5B38C;
        public bool IsGuardianConfigured()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsGuardianConfigured", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C5C658 — hookable via Hooks.InstallAt(NativeFunc_IsDeviceTracked).</summary>
        public static global::System.IntPtr NativeFunc_IsDeviceTracked => Memory.ModuleBase() + 0x5C5C658;
        public bool IsDeviceTracked(ETrackedDeviceType DeviceType)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)DeviceType);
            CallRaw("IsDeviceTracked", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C5BCA4 — hookable via Hooks.InstallAt(NativeFunc_HasSystemOverlayPresent).</summary>
        public static global::System.IntPtr NativeFunc_HasSystemOverlayPresent => Memory.ModuleBase() + 0x5C5BCA4;
        public bool HasSystemOverlayPresent()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasSystemOverlayPresent", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C5BCDC — hookable via Hooks.InstallAt(NativeFunc_HasInputFocus).</summary>
        public static global::System.IntPtr NativeFunc_HasInputFocus => Memory.ModuleBase() + 0x5C5BCDC;
        public bool HasInputFocus()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasInputFocus", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C5C3AC — hookable via Hooks.InstallAt(NativeFunc_GetUserProfile).</summary>
        public static global::System.IntPtr NativeFunc_GetUserProfile => Memory.ModuleBase() + 0x5C5C3AC;
        public bool GetUserProfile(global::System.IntPtr Profile)
        {
            var __pb = new ParamBuffer(73);
            __pb.Set<global::System.IntPtr>(0x0, Profile);
            CallRaw("GetUserProfile", __pb.Bytes);
            return __pb.Get<byte>(0x48) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C5B574 — hookable via Hooks.InstallAt(NativeFunc_GetSystemHmd3DofModeEnabled).</summary>
        public static global::System.IntPtr NativeFunc_GetSystemHmd3DofModeEnabled => Memory.ModuleBase() + 0x5C5B574;
        public bool GetSystemHmd3DofModeEnabled()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetSystemHmd3DofModeEnabled", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C5C700 — hookable via Hooks.InstallAt(NativeFunc_GetRawSensorData).</summary>
        public static global::System.IntPtr NativeFunc_GetRawSensorData => Memory.ModuleBase() + 0x5C5C700;
        public void GetRawSensorData(global::System.IntPtr AngularAcceleration, global::System.IntPtr LinearAcceleration, global::System.IntPtr AngularVelocity, global::System.IntPtr LinearVelocity, float TimeInSeconds, ETrackedDeviceType DeviceType)
        {
            var __pb = new ParamBuffer(53);
            __pb.Set<global::System.IntPtr>(0x0, AngularAcceleration);
            __pb.Set<global::System.IntPtr>(0xC, LinearAcceleration);
            __pb.Set<global::System.IntPtr>(0x18, AngularVelocity);
            __pb.Set<global::System.IntPtr>(0x24, LinearVelocity);
            __pb.Set(0x30, TimeInSeconds);
            __pb.Set<byte>(0x34, (byte)DeviceType);
            CallRaw("GetRawSensorData", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5C92C — hookable via Hooks.InstallAt(NativeFunc_GetPose).</summary>
        public static global::System.IntPtr NativeFunc_GetPose => Memory.ModuleBase() + 0x5C5C92C;
        public void GetPose(global::System.IntPtr DeviceRotation, global::System.IntPtr DevicePosition, global::System.IntPtr NeckPosition, bool bUseOrienationForPlayerCamera, bool bUsePositionForPlayerCamera, global::System.IntPtr PositionScale)
        {
            var __pb = new ParamBuffer(52);
            __pb.Set<global::System.IntPtr>(0x0, DeviceRotation);
            __pb.Set<global::System.IntPtr>(0xC, DevicePosition);
            __pb.Set<global::System.IntPtr>(0x18, NeckPosition);
            __pb.Set<byte>(0x24, (byte)(bUseOrienationForPlayerCamera?1:0));
            __pb.Set<byte>(0x25, (byte)(bUsePositionForPlayerCamera?1:0));
            __pb.Set<global::System.IntPtr>(0x28, PositionScale);
            CallRaw("GetPose", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5B04C — hookable via Hooks.InstallAt(NativeFunc_GetPointGuardianIntersection).</summary>
        public static global::System.IntPtr NativeFunc_GetPointGuardianIntersection => Memory.ModuleBase() + 0x5C5B04C;
        public global::System.IntPtr GetPointGuardianIntersection(global::System.IntPtr Point, EBoundaryType BoundaryType)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<global::System.IntPtr>(0x0, Point);
            __pb.Set<byte>(0xC, (byte)BoundaryType);
            CallRaw("GetPointGuardianIntersection", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5C5B13C — hookable via Hooks.InstallAt(NativeFunc_GetPlayAreaTransform).</summary>
        public static global::System.IntPtr NativeFunc_GetPlayAreaTransform => Memory.ModuleBase() + 0x5C5B13C;
        public global::System.IntPtr GetPlayAreaTransform()
        {
            var __pb = new ParamBuffer(48);
            CallRaw("GetPlayAreaTransform", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C5AF5C — hookable via Hooks.InstallAt(NativeFunc_GetNodeGuardianIntersection).</summary>
        public static global::System.IntPtr NativeFunc_GetNodeGuardianIntersection => Memory.ModuleBase() + 0x5C5AF5C;
        public global::System.IntPtr GetNodeGuardianIntersection(ETrackedDeviceType DeviceType, EBoundaryType BoundaryType)
        {
            var __pb = new ParamBuffer(36);
            __pb.Set<byte>(0x0, (byte)DeviceType);
            __pb.Set<byte>(0x1, (byte)BoundaryType);
            CallRaw("GetNodeGuardianIntersection", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5C5B540 — hookable via Hooks.InstallAt(NativeFunc_GetHmdColorDesc).</summary>
        public static global::System.IntPtr NativeFunc_GetHmdColorDesc => Memory.ModuleBase() + 0x5C5B540;
        public EColorSpace GetHmdColorDesc()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetHmdColorDesc", __pb.Bytes);
            return (EColorSpace)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C5B250 — hookable via Hooks.InstallAt(NativeFunc_GetGuardianPoints).</summary>
        public static global::System.IntPtr NativeFunc_GetGuardianPoints => Memory.ModuleBase() + 0x5C5B250;
        public global::System.IntPtr GetGuardianPoints(EBoundaryType BoundaryType, bool UsePawnSpace)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)BoundaryType);
            __pb.Set<byte>(0x1, (byte)(UsePawnSpace?1:0));
            CallRaw("GetGuardianPoints", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5C5B1A8 — hookable via Hooks.InstallAt(NativeFunc_GetGuardianDimensions).</summary>
        public static global::System.IntPtr NativeFunc_GetGuardianDimensions => Memory.ModuleBase() + 0x5C5B1A8;
        public global::System.IntPtr GetGuardianDimensions(EBoundaryType BoundaryType)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<byte>(0x0, (byte)BoundaryType);
            CallRaw("GetGuardianDimensions", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5C5BBA8 — hookable via Hooks.InstallAt(NativeFunc_GetGPUUtilization).</summary>
        public static global::System.IntPtr NativeFunc_GetGPUUtilization => Memory.ModuleBase() + 0x5C5BBA8;
        public void GetGPUUtilization(bool IsGPUAvailable, float GPUUtilization)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)(IsGPUAvailable?1:0));
            __pb.Set(0x4, GPUUtilization);
            CallRaw("GetGPUUtilization", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5BB74 — hookable via Hooks.InstallAt(NativeFunc_GetGPUFrameTime).</summary>
        public static global::System.IntPtr NativeFunc_GetGPUFrameTime => Memory.ModuleBase() + 0x5C5BB74;
        public float GetGPUFrameTime()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetGPUFrameTime", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C5BB40 — hookable via Hooks.InstallAt(NativeFunc_GetFixedFoveatedRenderingLevel).</summary>
        public static global::System.IntPtr NativeFunc_GetFixedFoveatedRenderingLevel => Memory.ModuleBase() + 0x5C5BB40;
        public EFixedFoveatedRenderingLevel GetFixedFoveatedRenderingLevel()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetFixedFoveatedRenderingLevel", __pb.Bytes);
            return (EFixedFoveatedRenderingLevel)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C5B97C — hookable via Hooks.InstallAt(NativeFunc_GetDeviceType).</summary>
        public static global::System.IntPtr NativeFunc_GetDeviceType => Memory.ModuleBase() + 0x5C5B97C;
        public EOculusDeviceType GetDeviceType()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetDeviceType", __pb.Bytes);
            return (EOculusDeviceType)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C5B9B0 — hookable via Hooks.InstallAt(NativeFunc_GetDeviceName).</summary>
        public static global::System.IntPtr NativeFunc_GetDeviceName => Memory.ModuleBase() + 0x5C5B9B0;
        public global::System.IntPtr GetDeviceName()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetDeviceName", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C5B3FC — hookable via Hooks.InstallAt(NativeFunc_GetDeviceBuildNumber).</summary>
        public static global::System.IntPtr NativeFunc_GetDeviceBuildNumber => Memory.ModuleBase() + 0x5C5B3FC;
        public global::System.IntPtr GetDeviceBuildNumber()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetDeviceBuildNumber", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C5B898 — hookable via Hooks.InstallAt(NativeFunc_GetCurrentDisplayFrequency).</summary>
        public static global::System.IntPtr NativeFunc_GetCurrentDisplayFrequency => Memory.ModuleBase() + 0x5C5B898;
        public float GetCurrentDisplayFrequency()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetCurrentDisplayFrequency", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C5BF0C — hookable via Hooks.InstallAt(NativeFunc_GetBaseRotationAndPositionOffset).</summary>
        public static global::System.IntPtr NativeFunc_GetBaseRotationAndPositionOffset => Memory.ModuleBase() + 0x5C5BF0C;
        public void GetBaseRotationAndPositionOffset(global::System.IntPtr OutRot, global::System.IntPtr OutPosOffset)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, OutRot);
            __pb.Set<global::System.IntPtr>(0xC, OutPosOffset);
            CallRaw("GetBaseRotationAndPositionOffset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5C1A0 — hookable via Hooks.InstallAt(NativeFunc_GetBaseRotationAndBaseOffsetInMeters).</summary>
        public static global::System.IntPtr NativeFunc_GetBaseRotationAndBaseOffsetInMeters => Memory.ModuleBase() + 0x5C5C1A0;
        public void GetBaseRotationAndBaseOffsetInMeters(global::System.IntPtr OutRotation, global::System.IntPtr OutBaseOffsetInMeters)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, OutRotation);
            __pb.Set<global::System.IntPtr>(0xC, OutBaseOffsetInMeters);
            CallRaw("GetBaseRotationAndBaseOffsetInMeters", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5B8CC — hookable via Hooks.InstallAt(NativeFunc_GetAvailableDisplayFrequencies).</summary>
        public static global::System.IntPtr NativeFunc_GetAvailableDisplayFrequencies => Memory.ModuleBase() + 0x5C5B8CC;
        public global::System.IntPtr GetAvailableDisplayFrequencies()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAvailableDisplayFrequencies", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C5B768 — hookable via Hooks.InstallAt(NativeFunc_EnablePositionTracking).</summary>
        public static global::System.IntPtr NativeFunc_EnablePositionTracking => Memory.ModuleBase() + 0x5C5B768;
        public void EnablePositionTracking(bool bPositionTracking)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bPositionTracking?1:0));
            CallRaw("EnablePositionTracking", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5B6CC — hookable via Hooks.InstallAt(NativeFunc_EnableOrientationTracking).</summary>
        public static global::System.IntPtr NativeFunc_EnableOrientationTracking => Memory.ModuleBase() + 0x5C5B6CC;
        public void EnableOrientationTracking(bool bOrientationTracking)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bOrientationTracking?1:0));
            CallRaw("EnableOrientationTracking", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5BD14 — hookable via Hooks.InstallAt(NativeFunc_ClearLoadingSplashScreens).</summary>
        public static global::System.IntPtr NativeFunc_ClearLoadingSplashScreens => Memory.ModuleBase() + 0x5C5BD14;
        public void ClearLoadingSplashScreens()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearLoadingSplashScreens", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C5BD28 — hookable via Hooks.InstallAt(NativeFunc_AddLoadingSplashScreen).</summary>
        public static global::System.IntPtr NativeFunc_AddLoadingSplashScreen => Memory.ModuleBase() + 0x5C5BD28;
        public void AddLoadingSplashScreen(Texture2D Texture, global::System.IntPtr TranslationInMeters, global::System.IntPtr Rotation, global::System.IntPtr SizeInMeters, global::System.IntPtr DeltaRotation, bool bClearBeforeAdd)
        {
            var __pb = new ParamBuffer(53);
            __pb.SetObject(0x0, Texture);
            __pb.Set<global::System.IntPtr>(0x8, TranslationInMeters);
            __pb.Set<global::System.IntPtr>(0x14, Rotation);
            __pb.Set<global::System.IntPtr>(0x20, SizeInMeters);
            __pb.Set<global::System.IntPtr>(0x28, DeltaRotation);
            __pb.Set<byte>(0x34, (byte)(bClearBeforeAdd?1:0));
            CallRaw("AddLoadingSplashScreen", __pb.Bytes);
        }
    }

    public class OculusHMDRuntimeSettings : Object
    {
        public const string UeClassName = "OculusHMDRuntimeSettings";
        public OculusHMDRuntimeSettings(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusHMDRuntimeSettings FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusHMDRuntimeSettings(p);
        public static OculusHMDRuntimeSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusHMDRuntimeSettings(o.Pointer); }
        public static OculusHMDRuntimeSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusHMDRuntimeSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusHMDRuntimeSettings(a[i].Pointer); return r; }
        public bool bAutoEnabled { get => Native.GetPropBool(Pointer, "bAutoEnabled"); set => Native.SetPropBool(Pointer, "bAutoEnabled", value); }
        public TArray<global::System.IntPtr> SplashDescs => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public bool bEnableSpecificColorGamut { get => Native.GetPropBool(Pointer, "bEnableSpecificColorGamut"); set => Native.SetPropBool(Pointer, "bEnableSpecificColorGamut", value); }
        public EColorSpace ColorSpace { get => (EColorSpace)GetAt<byte>(0x41); set => SetAt(0x41, (byte)value); }
        public bool bSupportsDash { get => Native.GetPropBool(Pointer, "bSupportsDash"); set => Native.SetPropBool(Pointer, "bSupportsDash", value); }
        public bool bCompositesDepth { get => Native.GetPropBool(Pointer, "bCompositesDepth"); set => Native.SetPropBool(Pointer, "bCompositesDepth", value); }
        public bool bHQDistortion { get => Native.GetPropBool(Pointer, "bHQDistortion"); set => Native.SetPropBool(Pointer, "bHQDistortion", value); }
        public float PixelDensityMin { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float PixelDensityMax { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public int CPULevel { get => GetAt<int>(0x50); set => SetAt(0x50, value); }
        public int GPULevel { get => GetAt<int>(0x54); set => SetAt(0x54, value); }
        public EFixedFoveatedRenderingLevel FFRLevel { get => (EFixedFoveatedRenderingLevel)GetAt<byte>(0x58); set => SetAt(0x58, (byte)value); }
        public bool FFRDynamic { get => Native.GetPropBool(Pointer, "FFRDynamic"); set => Native.SetPropBool(Pointer, "FFRDynamic", value); }
        public bool bChromaCorrection { get => Native.GetPropBool(Pointer, "bChromaCorrection"); set => Native.SetPropBool(Pointer, "bChromaCorrection", value); }
        public bool bRecenterHMDWithController { get => Native.GetPropBool(Pointer, "bRecenterHMDWithController"); set => Native.SetPropBool(Pointer, "bRecenterHMDWithController", value); }
        public bool bFocusAware { get => Native.GetPropBool(Pointer, "bFocusAware"); set => Native.SetPropBool(Pointer, "bFocusAware", value); }
        public bool bRequiresSystemKeyboard { get => Native.GetPropBool(Pointer, "bRequiresSystemKeyboard"); set => Native.SetPropBool(Pointer, "bRequiresSystemKeyboard", value); }
        public EHandTrackingSupport HandTrackingSupport { get => (EHandTrackingSupport)GetAt<byte>(0x5E); set => SetAt(0x5E, (byte)value); }
        public bool bLateLatching { get => Native.GetPropBool(Pointer, "bLateLatching"); set => Native.SetPropBool(Pointer, "bLateLatching", value); }
    }

    public class OculusResourceHolder : Object
    {
        public const string UeClassName = "OculusResourceHolder";
        public OculusResourceHolder(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusResourceHolder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusResourceHolder(p);
        public static OculusResourceHolder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusResourceHolder(o.Pointer); }
        public static OculusResourceHolder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusResourceHolder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusResourceHolder(a[i].Pointer); return r; }
        public Material PokeAHoleMaterial { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new Material(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class OculusSceneCaptureCubemap : Object
    {
        public const string UeClassName = "OculusSceneCaptureCubemap";
        public OculusSceneCaptureCubemap(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusSceneCaptureCubemap FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusSceneCaptureCubemap(p);
        public static OculusSceneCaptureCubemap FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusSceneCaptureCubemap(o.Pointer); }
        public static OculusSceneCaptureCubemap[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusSceneCaptureCubemap[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusSceneCaptureCubemap(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> CaptureComponents => new TArray<global::System.IntPtr>(AddrOf(0x38)); // TArray<UObject*>
    }

}
