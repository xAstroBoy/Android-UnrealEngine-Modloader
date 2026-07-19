// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/HeadMountedDisplay
using System;

namespace UEModLoader.Game
{
    public enum EXRTrackedDeviceType
    {
        HeadMountedDisplay = 0,
        Controller = 1,
        TrackingReference = 2,
        Other = 3,
        Invalid = 254,
        Any = 255,
    }

    public enum ESpectatorScreenMode
    {
        Disabled = 0,
        SingleEyeLetterboxed = 1,
        Undistorted = 2,
        Distorted = 3,
        SingleEye = 4,
        SingleEyeCroppedToFill = 5,
        Texture = 6,
        TexturePlusEye = 7,
    }

    public enum EHMDWornState
    {
        Unknown = 0,
        Worn = 1,
        NotWorn = 2,
    }

    public enum EHMDTrackingOrigin
    {
        Floor = 0,
        Eye = 1,
        Stage = 2,
    }

    public enum EOrientPositionSelector
    {
        Orientation = 0,
        Position = 1,
        OrientationAndPosition = 2,
    }

    public enum ETrackingStatus
    {
        NotTracked = 0,
        InertialOnly = 1,
        Tracked = 2,
    }

    public class XRDeviceId : StructProxy
    {
        public XRDeviceId(System.IntPtr ptr) : base(ptr) {}
        public string SystemName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName SystemName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public int DeviceID { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
    }

    public class HeadMountedDisplayFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "HeadMountedDisplayFunctionLibrary";
        public HeadMountedDisplayFunctionLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new HeadMountedDisplayFunctionLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new HeadMountedDisplayFunctionLibrary(p);
        public static HeadMountedDisplayFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new HeadMountedDisplayFunctionLibrary(o.Pointer); }
        public static HeadMountedDisplayFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new HeadMountedDisplayFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new HeadMountedDisplayFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x73C36E4 — hookable via Hooks.InstallAt(NativeFunc_UpdateExternalTrackingHMDPosition).</summary>
        public static System.IntPtr NativeFunc_UpdateExternalTrackingHMDPosition => Memory.ModuleBase() + 0x73C36E4;
        public void UpdateExternalTrackingHMDPosition(Transform ExternalTrackingTransform)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, ExternalTrackingTransform);
            CallRaw("UpdateExternalTrackingHMDPosition", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C3A9C — hookable via Hooks.InstallAt(NativeFunc_SetWorldToMetersScale).</summary>
        public static System.IntPtr NativeFunc_SetWorldToMetersScale => Memory.ModuleBase() + 0x73C3A9C;
        public void SetWorldToMetersScale(Object WorldContext, float NewScale)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, WorldContext);
            __pb.Set(0x8, NewScale);
            CallRaw("SetWorldToMetersScale", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C3964 — hookable via Hooks.InstallAt(NativeFunc_SetTrackingOrigin).</summary>
        public static System.IntPtr NativeFunc_SetTrackingOrigin => Memory.ModuleBase() + 0x73C3964;
        public void SetTrackingOrigin(byte Origin)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, Origin);
            CallRaw("SetTrackingOrigin", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C3488 — hookable via Hooks.InstallAt(NativeFunc_SetSpectatorScreenTexture).</summary>
        public static System.IntPtr NativeFunc_SetSpectatorScreenTexture => Memory.ModuleBase() + 0x73C3488;
        public void SetSpectatorScreenTexture(Texture InTexture)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InTexture);
            CallRaw("SetSpectatorScreenTexture", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C3250 — hookable via Hooks.InstallAt(NativeFunc_SetSpectatorScreenModeTexturePlusEyeLayout).</summary>
        public static System.IntPtr NativeFunc_SetSpectatorScreenModeTexturePlusEyeLayout => Memory.ModuleBase() + 0x73C3250;
        public void SetSpectatorScreenModeTexturePlusEyeLayout(Vector2D EyeRectMin, Vector2D EyeRectMax, Vector2D TextureRectMin, Vector2D TextureRectMax, bool bDrawEyeFirst, bool bClearBlack, bool bUseAlpha)
        {
            var __pb = new ParamBuffer(35);
            __pb.Set<System.IntPtr>(0x0, EyeRectMin);
            __pb.Set<System.IntPtr>(0x8, EyeRectMax);
            __pb.Set<System.IntPtr>(0x10, TextureRectMin);
            __pb.Set<System.IntPtr>(0x18, TextureRectMax);
            __pb.Set<byte>(0x20, (byte)(bDrawEyeFirst?1:0));
            __pb.Set<byte>(0x21, (byte)(bClearBlack?1:0));
            __pb.Set<byte>(0x22, (byte)(bUseAlpha?1:0));
            CallRaw("SetSpectatorScreenModeTexturePlusEyeLayout", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C351C — hookable via Hooks.InstallAt(NativeFunc_SetSpectatorScreenMode).</summary>
        public static System.IntPtr NativeFunc_SetSpectatorScreenMode => Memory.ModuleBase() + 0x73C351C;
        public void SetSpectatorScreenMode(ESpectatorScreenMode Mode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Mode);
            CallRaw("SetSpectatorScreenMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C3BDC — hookable via Hooks.InstallAt(NativeFunc_SetClippingPlanes).</summary>
        public static System.IntPtr NativeFunc_SetClippingPlanes => Memory.ModuleBase() + 0x73C3BDC;
        public void SetClippingPlanes(float Near, float Far)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Near);
            __pb.Set(0x4, Far);
            CallRaw("SetClippingPlanes", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C3CB0 — hookable via Hooks.InstallAt(NativeFunc_ResetOrientationAndPosition).</summary>
        public static System.IntPtr NativeFunc_ResetOrientationAndPosition => Memory.ModuleBase() + 0x73C3CB0;
        public void ResetOrientationAndPosition(float Yaw, byte Options)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Yaw);
            __pb.Set(0x4, Options);
            CallRaw("ResetOrientationAndPosition", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C35B0 — hookable via Hooks.InstallAt(NativeFunc_IsSpectatorScreenModeControllable).</summary>
        public static System.IntPtr NativeFunc_IsSpectatorScreenModeControllable => Memory.ModuleBase() + 0x73C35B0;
        public bool IsSpectatorScreenModeControllable()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsSpectatorScreenModeControllable", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C3E14 — hookable via Hooks.InstallAt(NativeFunc_IsInLowPersistenceMode).</summary>
        public static System.IntPtr NativeFunc_IsInLowPersistenceMode => Memory.ModuleBase() + 0x73C3E14;
        public bool IsInLowPersistenceMode()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsInLowPersistenceMode", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C4740 — hookable via Hooks.InstallAt(NativeFunc_IsHeadMountedDisplayEnabled).</summary>
        public static System.IntPtr NativeFunc_IsHeadMountedDisplayEnabled => Memory.ModuleBase() + 0x73C4740;
        public bool IsHeadMountedDisplayEnabled()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsHeadMountedDisplayEnabled", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C4708 — hookable via Hooks.InstallAt(NativeFunc_IsHeadMountedDisplayConnected).</summary>
        public static System.IntPtr NativeFunc_IsHeadMountedDisplayConnected => Memory.ModuleBase() + 0x73C4708;
        public bool IsHeadMountedDisplayConnected()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsHeadMountedDisplayConnected", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C2C44 — hookable via Hooks.InstallAt(NativeFunc_IsDeviceTracking).</summary>
        public static System.IntPtr NativeFunc_IsDeviceTracking => Memory.ModuleBase() + 0x73C2C44;
        public bool IsDeviceTracking(XRDeviceId XRDeviceId)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set<System.IntPtr>(0x0, XRDeviceId);
            CallRaw("IsDeviceTracking", __pb.Bytes);
            return __pb.Get<byte>(0xC) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C44C4 — hookable via Hooks.InstallAt(NativeFunc_HasValidTrackingPosition).</summary>
        public static System.IntPtr NativeFunc_HasValidTrackingPosition => Memory.ModuleBase() + 0x73C44C4;
        public bool HasValidTrackingPosition()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasValidTrackingPosition", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C39F8 — hookable via Hooks.InstallAt(NativeFunc_GetWorldToMetersScale).</summary>
        public static System.IntPtr NativeFunc_GetWorldToMetersScale => Memory.ModuleBase() + 0x73C39F8;
        public float GetWorldToMetersScale(Object WorldContext)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, WorldContext);
            CallRaw("GetWorldToMetersScale", __pb.Bytes);
            return __pb.Get<float>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x73C35E8 — hookable via Hooks.InstallAt(NativeFunc_GetVRFocusState).</summary>
        public static System.IntPtr NativeFunc_GetVRFocusState => Memory.ModuleBase() + 0x73C35E8;
        public void GetVRFocusState(bool bUseFocus, bool bHasFocus)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(bUseFocus?1:0));
            __pb.Set<byte>(0x1, (byte)(bHasFocus?1:0));
            CallRaw("GetVRFocusState", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C387C — hookable via Hooks.InstallAt(NativeFunc_GetTrackingToWorldTransform).</summary>
        public static System.IntPtr NativeFunc_GetTrackingToWorldTransform => Memory.ModuleBase() + 0x73C387C;
        public Transform GetTrackingToWorldTransform(Object WorldContext)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, WorldContext);
            CallRaw("GetTrackingToWorldTransform", __pb.Bytes);
            return __pb.Get<Transform>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x73C40C0 — hookable via Hooks.InstallAt(NativeFunc_GetTrackingSensorParameters).</summary>
        public static System.IntPtr NativeFunc_GetTrackingSensorParameters => Memory.ModuleBase() + 0x73C40C0;
        public void GetTrackingSensorParameters(Vector Origin, Rotator Rotation, float LeftFOV, float RightFOV, float TopFOV, float BottomFOV, float Distance, float NearPlane, float FarPlane, bool IsActive, int Index)
        {
            var __pb = new ParamBuffer(60);
            __pb.Set<System.IntPtr>(0x0, Origin);
            __pb.Set<System.IntPtr>(0xC, Rotation);
            __pb.Set(0x18, LeftFOV);
            __pb.Set(0x1C, RightFOV);
            __pb.Set(0x20, TopFOV);
            __pb.Set(0x24, BottomFOV);
            __pb.Set(0x28, Distance);
            __pb.Set(0x2C, NearPlane);
            __pb.Set(0x30, FarPlane);
            __pb.Set<byte>(0x34, (byte)(IsActive?1:0));
            __pb.Set(0x38, Index);
            CallRaw("GetTrackingSensorParameters", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C3930 — hookable via Hooks.InstallAt(NativeFunc_GetTrackingOrigin).</summary>
        public static System.IntPtr NativeFunc_GetTrackingOrigin => Memory.ModuleBase() + 0x73C3930;
        public byte GetTrackingOrigin()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetTrackingOrigin", __pb.Bytes);
            return __pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C3BA8 — hookable via Hooks.InstallAt(NativeFunc_GetScreenPercentage).</summary>
        public static System.IntPtr NativeFunc_GetScreenPercentage => Memory.ModuleBase() + 0x73C3BA8;
        public float GetScreenPercentage()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetScreenPercentage", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C3E2C — hookable via Hooks.InstallAt(NativeFunc_GetPositionalTrackingCameraParameters).</summary>
        public static System.IntPtr NativeFunc_GetPositionalTrackingCameraParameters => Memory.ModuleBase() + 0x73C3E2C;
        public void GetPositionalTrackingCameraParameters(Vector CameraOrigin, Rotator CameraRotation, float HFOV, float VFOV, float CameraDistance, float NearPlane, float FarPlane)
        {
            var __pb = new ParamBuffer(44);
            __pb.Set<System.IntPtr>(0x0, CameraOrigin);
            __pb.Set<System.IntPtr>(0xC, CameraRotation);
            __pb.Set(0x18, HFOV);
            __pb.Set(0x1C, VFOV);
            __pb.Set(0x20, CameraDistance);
            __pb.Set(0x24, NearPlane);
            __pb.Set(0x28, FarPlane);
            CallRaw("GetPositionalTrackingCameraParameters", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C3B74 — hookable via Hooks.InstallAt(NativeFunc_GetPixelDensity).</summary>
        public static System.IntPtr NativeFunc_GetPixelDensity => Memory.ModuleBase() + 0x73C3B74;
        public float GetPixelDensity()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPixelDensity", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C44FC — hookable via Hooks.InstallAt(NativeFunc_GetOrientationAndPosition).</summary>
        public static System.IntPtr NativeFunc_GetOrientationAndPosition => Memory.ModuleBase() + 0x73C44FC;
        public void GetOrientationAndPosition(Rotator DeviceRotation, Vector DevicePosition)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, DeviceRotation);
            __pb.Set<System.IntPtr>(0xC, DevicePosition);
            CallRaw("GetOrientationAndPosition", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C4490 — hookable via Hooks.InstallAt(NativeFunc_GetNumOfTrackingSensors).</summary>
        public static System.IntPtr NativeFunc_GetNumOfTrackingSensors => Memory.ModuleBase() + 0x73C4490;
        public int GetNumOfTrackingSensors()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumOfTrackingSensors", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C45F0 — hookable via Hooks.InstallAt(NativeFunc_GetHMDWornState).</summary>
        public static System.IntPtr NativeFunc_GetHMDWornState => Memory.ModuleBase() + 0x73C45F0;
        public byte GetHMDWornState()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetHMDWornState", __pb.Bytes);
            return __pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C4624 — hookable via Hooks.InstallAt(NativeFunc_GetHMDDeviceName).</summary>
        public static System.IntPtr NativeFunc_GetHMDDeviceName => Memory.ModuleBase() + 0x73C4624;
        public FName GetHMDDeviceName()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetHMDDeviceName", __pb.Bytes);
            return __pb.Get<FName>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C2D00 — hookable via Hooks.InstallAt(NativeFunc_GetDeviceWorldPose).</summary>
        public static System.IntPtr NativeFunc_GetDeviceWorldPose => Memory.ModuleBase() + 0x73C2D00;
        public void GetDeviceWorldPose(Object WorldContext, XRDeviceId XRDeviceId, bool bIsTracked, Rotator Orientation, bool bHasPositionalTracking, Vector Position)
        {
            var __pb = new ParamBuffer(52);
            __pb.SetObject(0x0, WorldContext);
            __pb.Set<System.IntPtr>(0x8, XRDeviceId);
            __pb.Set<byte>(0x14, (byte)(bIsTracked?1:0));
            __pb.Set<System.IntPtr>(0x18, Orientation);
            __pb.Set<byte>(0x24, (byte)(bHasPositionalTracking?1:0));
            __pb.Set<System.IntPtr>(0x28, Position);
            CallRaw("GetDeviceWorldPose", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C2F2C — hookable via Hooks.InstallAt(NativeFunc_GetDevicePose).</summary>
        public static System.IntPtr NativeFunc_GetDevicePose => Memory.ModuleBase() + 0x73C2F2C;
        public void GetDevicePose(XRDeviceId XRDeviceId, bool bIsTracked, Rotator Orientation, bool bHasPositionalTracking, Vector Position)
        {
            var __pb = new ParamBuffer(44);
            __pb.Set<System.IntPtr>(0x0, XRDeviceId);
            __pb.Set<byte>(0xC, (byte)(bIsTracked?1:0));
            __pb.Set<System.IntPtr>(0x10, Orientation);
            __pb.Set<byte>(0x1C, (byte)(bHasPositionalTracking?1:0));
            __pb.Set<System.IntPtr>(0x20, Position);
            CallRaw("GetDevicePose", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C311C — hookable via Hooks.InstallAt(NativeFunc_EnumerateTrackedDevices).</summary>
        public static System.IntPtr NativeFunc_EnumerateTrackedDevices => Memory.ModuleBase() + 0x73C311C;
        public System.IntPtr EnumerateTrackedDevices(FName SystemId, EXRTrackedDeviceType DeviceType)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set(0x0, SystemId);
            __pb.Set<byte>(0x8, (byte)DeviceType);
            CallRaw("EnumerateTrackedDevices", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x73C3D88 — hookable via Hooks.InstallAt(NativeFunc_EnableLowPersistenceMode).</summary>
        public static System.IntPtr NativeFunc_EnableLowPersistenceMode => Memory.ModuleBase() + 0x73C3D88;
        public void EnableLowPersistenceMode(bool bEnable)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bEnable?1:0));
            CallRaw("EnableLowPersistenceMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C4658 — hookable via Hooks.InstallAt(NativeFunc_EnableHMD).</summary>
        public static System.IntPtr NativeFunc_EnableHMD => Memory.ModuleBase() + 0x73C4658;
        public bool EnableHMD(bool bEnable)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(bEnable?1:0));
            CallRaw("EnableHMD", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C37B0 — hookable via Hooks.InstallAt(NativeFunc_CalibrateExternalTrackingToHMD).</summary>
        public static System.IntPtr NativeFunc_CalibrateExternalTrackingToHMD => Memory.ModuleBase() + 0x73C37B0;
        public void CalibrateExternalTrackingToHMD(Transform ExternalTrackingTransform)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, ExternalTrackingTransform);
            CallRaw("CalibrateExternalTrackingToHMD", __pb.Bytes);
        }
    }

    public class MotionControllerComponent : PrimitiveComponent
    {
        public const string UeClassName = "MotionControllerComponent";
        public MotionControllerComponent(System.IntPtr ptr) : base(ptr) {}
        public static new MotionControllerComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MotionControllerComponent(p);
        public static MotionControllerComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MotionControllerComponent(o.Pointer); }
        public static MotionControllerComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MotionControllerComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MotionControllerComponent(a[i].Pointer); return r; }
        public int PlayerIndex { get => GetAt<int>(0x408); set => SetAt(0x408, value); }
        public EControllerHand Hand { get => (EControllerHand)GetAt<byte>(0x40C); set => SetAt(0x40C, (byte)value); }
        public string MotionSource => Native.GetPropName(Pointer, "MotionSource"); // FName
        public FName MotionSource_Raw { get => GetAt<FName>(0x410); set => SetAt(0x410, value); }
        public bool bDisableLowLatencyUpdate { get => Native.GetPropBool(Pointer, "bDisableLowLatencyUpdate"); set => Native.SetPropBool(Pointer, "bDisableLowLatencyUpdate", value); }
        public ETrackingStatus CurrentTrackingStatus { get => (ETrackingStatus)GetAt<byte>(0x419); set => SetAt(0x419, (byte)value); }
        public bool bDisplayDeviceModel { get => Native.GetPropBool(Pointer, "bDisplayDeviceModel"); set => Native.SetPropBool(Pointer, "bDisplayDeviceModel", value); }
        public string DisplayModelSource => Native.GetPropName(Pointer, "DisplayModelSource"); // FName
        public FName DisplayModelSource_Raw { get => GetAt<FName>(0x41C); set => SetAt(0x41C, value); }
        public StaticMesh CustomDisplayMesh { get { var __p = GetAt<System.IntPtr>(0x428); return __p==System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x428, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> DisplayMeshMaterialOverrides => new TArray<System.IntPtr>(AddrOf(0x430)); // TArray<UObject*>
        public PrimitiveComponent DisplayComponent { get { var __p = GetAt<System.IntPtr>(0x4A0); return __p==System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x4A0, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x73C6BE4 — hookable via Hooks.InstallAt(NativeFunc_SetTrackingSource).</summary>
        public static System.IntPtr NativeFunc_SetTrackingSource => Memory.ModuleBase() + 0x73C6BE4;
        public void SetTrackingSource(EControllerHand NewSource)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)NewSource);
            CallRaw("SetTrackingSource", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C6B0C — hookable via Hooks.InstallAt(NativeFunc_SetTrackingMotionSource).</summary>
        public static System.IntPtr NativeFunc_SetTrackingMotionSource => Memory.ModuleBase() + 0x73C6B0C;
        public void SetTrackingMotionSource(FName NewSource)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NewSource);
            CallRaw("SetTrackingMotionSource", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C6DD0 — hookable via Hooks.InstallAt(NativeFunc_SetShowDeviceModel).</summary>
        public static System.IntPtr NativeFunc_SetShowDeviceModel => Memory.ModuleBase() + 0x73C6DD0;
        public void SetShowDeviceModel(bool bShowControllerModel)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bShowControllerModel?1:0));
            CallRaw("SetShowDeviceModel", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C6D2C — hookable via Hooks.InstallAt(NativeFunc_SetDisplayModelSource).</summary>
        public static System.IntPtr NativeFunc_SetDisplayModelSource => Memory.ModuleBase() + 0x73C6D2C;
        public void SetDisplayModelSource(FName NewDisplayModelSource)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NewDisplayModelSource);
            CallRaw("SetDisplayModelSource", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C6C88 — hookable via Hooks.InstallAt(NativeFunc_SetCustomDisplayMesh).</summary>
        public static System.IntPtr NativeFunc_SetCustomDisplayMesh => Memory.ModuleBase() + 0x73C6C88;
        public void SetCustomDisplayMesh(StaticMesh NewDisplayMesh)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewDisplayMesh);
            CallRaw("SetCustomDisplayMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C6A68 — hookable via Hooks.InstallAt(NativeFunc_SetAssociatedPlayerIndex).</summary>
        public static System.IntPtr NativeFunc_SetAssociatedPlayerIndex => Memory.ModuleBase() + 0x73C6A68;
        public void SetAssociatedPlayerIndex(int NewPlayer)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewPlayer);
            CallRaw("SetAssociatedPlayerIndex", __pb.Bytes);
        }
        public void OnMotionControllerUpdated()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnMotionControllerUpdated", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C6E7C — hookable via Hooks.InstallAt(NativeFunc_IsTracked).</summary>
        public static System.IntPtr NativeFunc_IsTracked => Memory.ModuleBase() + 0x73C6E7C;
        public bool IsTracked()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsTracked", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C6BB0 — hookable via Hooks.InstallAt(NativeFunc_GetTrackingSource).</summary>
        public static System.IntPtr NativeFunc_GetTrackingSource => Memory.ModuleBase() + 0x73C6BB0;
        public EControllerHand GetTrackingSource()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetTrackingSource", __pb.Bytes);
            return (EControllerHand)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C6964 — hookable via Hooks.InstallAt(NativeFunc_GetParameterValue).</summary>
        public static System.IntPtr NativeFunc_GetParameterValue => Memory.ModuleBase() + 0x73C6964;
        public float GetParameterValue(FName InName, bool bValueFound)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, InName);
            __pb.Set<byte>(0x8, (byte)(bValueFound?1:0));
            CallRaw("GetParameterValue", __pb.Bytes);
            return __pb.Get<float>(0xC);
        }
        /// <summary>[Native] thunk RVA 0x73C685C — hookable via Hooks.InstallAt(NativeFunc_GetHandJointPosition).</summary>
        public static System.IntPtr NativeFunc_GetHandJointPosition => Memory.ModuleBase() + 0x73C685C;
        public Vector GetHandJointPosition(int jointIndex, bool bValueFound)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set(0x0, jointIndex);
            __pb.Set<byte>(0x4, (byte)(bValueFound?1:0));
            CallRaw("GetHandJointPosition", __pb.Bytes);
            return __pb.Get<Vector>(0x8);
        }
    }

    public class MotionTrackedDeviceFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "MotionTrackedDeviceFunctionLibrary";
        public MotionTrackedDeviceFunctionLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new MotionTrackedDeviceFunctionLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MotionTrackedDeviceFunctionLibrary(p);
        public static MotionTrackedDeviceFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MotionTrackedDeviceFunctionLibrary(o.Pointer); }
        public static MotionTrackedDeviceFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MotionTrackedDeviceFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MotionTrackedDeviceFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x73C8904 — hookable via Hooks.InstallAt(NativeFunc_SetIsControllerMotionTrackingEnabledByDefault).</summary>
        public static System.IntPtr NativeFunc_SetIsControllerMotionTrackingEnabledByDefault => Memory.ModuleBase() + 0x73C8904;
        public void SetIsControllerMotionTrackingEnabledByDefault(bool enable)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(enable?1:0));
            CallRaw("SetIsControllerMotionTrackingEnabledByDefault", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C86C4 — hookable via Hooks.InstallAt(NativeFunc_IsMotionTrackingEnabledForSource).</summary>
        public static System.IntPtr NativeFunc_IsMotionTrackingEnabledForSource => Memory.ModuleBase() + 0x73C86C4;
        public bool IsMotionTrackingEnabledForSource(int PlayerIndex, FName SourceName)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set(0x0, PlayerIndex);
            __pb.Set(0x4, SourceName);
            CallRaw("IsMotionTrackingEnabledForSource", __pb.Bytes);
            return __pb.Get<byte>(0xC) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C87B0 — hookable via Hooks.InstallAt(NativeFunc_IsMotionTrackingEnabledForDevice).</summary>
        public static System.IntPtr NativeFunc_IsMotionTrackingEnabledForDevice => Memory.ModuleBase() + 0x73C87B0;
        public bool IsMotionTrackingEnabledForDevice(int PlayerIndex, EControllerHand Hand)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set(0x0, PlayerIndex);
            __pb.Set<byte>(0x4, (byte)Hand);
            CallRaw("IsMotionTrackingEnabledForDevice", __pb.Bytes);
            return __pb.Get<byte>(0x5) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C861C — hookable via Hooks.InstallAt(NativeFunc_IsMotionTrackingEnabledForComponent).</summary>
        public static System.IntPtr NativeFunc_IsMotionTrackingEnabledForComponent => Memory.ModuleBase() + 0x73C861C;
        public bool IsMotionTrackingEnabledForComponent(MotionControllerComponent MotionControllerComponent)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, MotionControllerComponent);
            CallRaw("IsMotionTrackingEnabledForComponent", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C89A0 — hookable via Hooks.InstallAt(NativeFunc_IsMotionTrackedDeviceCountManagementNecessary).</summary>
        public static System.IntPtr NativeFunc_IsMotionTrackedDeviceCountManagementNecessary => Memory.ModuleBase() + 0x73C89A0;
        public bool IsMotionTrackedDeviceCountManagementNecessary()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsMotionTrackedDeviceCountManagementNecessary", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C7EE0 — hookable via Hooks.InstallAt(NativeFunc_IsMotionSourceTracking).</summary>
        public static System.IntPtr NativeFunc_IsMotionSourceTracking => Memory.ModuleBase() + 0x73C7EE0;
        public bool IsMotionSourceTracking(int PlayerIndex, FName SourceName)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set(0x0, PlayerIndex);
            __pb.Set(0x4, SourceName);
            CallRaw("IsMotionSourceTracking", __pb.Bytes);
            return __pb.Get<byte>(0xC) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C889C — hookable via Hooks.InstallAt(NativeFunc_GetMotionTrackingEnabledControllerCount).</summary>
        public static System.IntPtr NativeFunc_GetMotionTrackingEnabledControllerCount => Memory.ModuleBase() + 0x73C889C;
        public int GetMotionTrackingEnabledControllerCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMotionTrackingEnabledControllerCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C88D0 — hookable via Hooks.InstallAt(NativeFunc_GetMaximumMotionTrackedControllerCount).</summary>
        public static System.IntPtr NativeFunc_GetMaximumMotionTrackedControllerCount => Memory.ModuleBase() + 0x73C88D0;
        public int GetMaximumMotionTrackedControllerCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMaximumMotionTrackedControllerCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C7FCC — hookable via Hooks.InstallAt(NativeFunc_GetActiveTrackingSystemName).</summary>
        public static System.IntPtr NativeFunc_GetActiveTrackingSystemName => Memory.ModuleBase() + 0x73C7FCC;
        public FName GetActiveTrackingSystemName()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetActiveTrackingSystemName", __pb.Bytes);
            return __pb.Get<FName>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C8000 — hookable via Hooks.InstallAt(NativeFunc_EnumerateMotionSources).</summary>
        public static System.IntPtr NativeFunc_EnumerateMotionSources => Memory.ModuleBase() + 0x73C8000;
        public System.IntPtr EnumerateMotionSources()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("EnumerateMotionSources", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x73C8444 — hookable via Hooks.InstallAt(NativeFunc_EnableMotionTrackingOfSource).</summary>
        public static System.IntPtr NativeFunc_EnableMotionTrackingOfSource => Memory.ModuleBase() + 0x73C8444;
        public bool EnableMotionTrackingOfSource(int PlayerIndex, FName SourceName)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set(0x0, PlayerIndex);
            __pb.Set(0x4, SourceName);
            CallRaw("EnableMotionTrackingOfSource", __pb.Bytes);
            return __pb.Get<byte>(0xC) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C8530 — hookable via Hooks.InstallAt(NativeFunc_EnableMotionTrackingOfDevice).</summary>
        public static System.IntPtr NativeFunc_EnableMotionTrackingOfDevice => Memory.ModuleBase() + 0x73C8530;
        public bool EnableMotionTrackingOfDevice(int PlayerIndex, EControllerHand Hand)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set(0x0, PlayerIndex);
            __pb.Set<byte>(0x4, (byte)Hand);
            CallRaw("EnableMotionTrackingOfDevice", __pb.Bytes);
            return __pb.Get<byte>(0x5) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C839C — hookable via Hooks.InstallAt(NativeFunc_EnableMotionTrackingForComponent).</summary>
        public static System.IntPtr NativeFunc_EnableMotionTrackingForComponent => Memory.ModuleBase() + 0x73C839C;
        public bool EnableMotionTrackingForComponent(MotionControllerComponent MotionControllerComponent)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, MotionControllerComponent);
            CallRaw("EnableMotionTrackingForComponent", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x73C81EC — hookable via Hooks.InstallAt(NativeFunc_DisableMotionTrackingOfSource).</summary>
        public static System.IntPtr NativeFunc_DisableMotionTrackingOfSource => Memory.ModuleBase() + 0x73C81EC;
        public void DisableMotionTrackingOfSource(int PlayerIndex, FName SourceName)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, PlayerIndex);
            __pb.Set(0x4, SourceName);
            CallRaw("DisableMotionTrackingOfSource", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C82C4 — hookable via Hooks.InstallAt(NativeFunc_DisableMotionTrackingOfDevice).</summary>
        public static System.IntPtr NativeFunc_DisableMotionTrackingOfDevice => Memory.ModuleBase() + 0x73C82C4;
        public void DisableMotionTrackingOfDevice(int PlayerIndex, EControllerHand Hand)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, PlayerIndex);
            __pb.Set<byte>(0x4, (byte)Hand);
            CallRaw("DisableMotionTrackingOfDevice", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C80B0 — hookable via Hooks.InstallAt(NativeFunc_DisableMotionTrackingOfControllersForPlayer).</summary>
        public static System.IntPtr NativeFunc_DisableMotionTrackingOfControllersForPlayer => Memory.ModuleBase() + 0x73C80B0;
        public void DisableMotionTrackingOfControllersForPlayer(int PlayerIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, PlayerIndex);
            CallRaw("DisableMotionTrackingOfControllersForPlayer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C8144 — hookable via Hooks.InstallAt(NativeFunc_DisableMotionTrackingOfAllControllers).</summary>
        public static System.IntPtr NativeFunc_DisableMotionTrackingOfAllControllers => Memory.ModuleBase() + 0x73C8144;
        public void DisableMotionTrackingOfAllControllers()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableMotionTrackingOfAllControllers", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73C8158 — hookable via Hooks.InstallAt(NativeFunc_DisableMotionTrackingForComponent).</summary>
        public static System.IntPtr NativeFunc_DisableMotionTrackingForComponent => Memory.ModuleBase() + 0x73C8158;
        public void DisableMotionTrackingForComponent(MotionControllerComponent MotionControllerComponent)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, MotionControllerComponent);
            CallRaw("DisableMotionTrackingForComponent", __pb.Bytes);
        }
    }

    public class VRNotificationsComponent : ActorComponent
    {
        public const string UeClassName = "VRNotificationsComponent";
        public VRNotificationsComponent(System.IntPtr ptr) : base(ptr) {}
        public static new VRNotificationsComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VRNotificationsComponent(p);
        public static VRNotificationsComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VRNotificationsComponent(o.Pointer); }
        public static VRNotificationsComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VRNotificationsComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VRNotificationsComponent(a[i].Pointer); return r; }
        public System.IntPtr HMDTrackingInitializingAndNeedsHMDToBeTrackedDelegate => AddrOf(0xB0); // 
        public System.IntPtr HMDTrackingInitializedDelegate => AddrOf(0xC0); // 
        public System.IntPtr HMDRecenteredDelegate => AddrOf(0xD0); // 
        public System.IntPtr HMDLostDelegate => AddrOf(0xE0); // 
        public System.IntPtr HMDReconnectedDelegate => AddrOf(0xF0); // 
        public System.IntPtr HMDConnectCanceledDelegate => AddrOf(0x100); // 
        public System.IntPtr HMDPutOnHeadDelegate => AddrOf(0x110); // 
        public System.IntPtr HMDRemovedFromHeadDelegate => AddrOf(0x120); // 
        public System.IntPtr VRControllerRecenteredDelegate => AddrOf(0x130); // 
    }

    public class XRAssetFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "XRAssetFunctionLibrary";
        public XRAssetFunctionLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new XRAssetFunctionLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new XRAssetFunctionLibrary(p);
        public static XRAssetFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new XRAssetFunctionLibrary(o.Pointer); }
        public static XRAssetFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new XRAssetFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new XRAssetFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x73C9E7C — hookable via Hooks.InstallAt(NativeFunc_AddNamedDeviceVisualizationComponentBlocking).</summary>
        public static System.IntPtr NativeFunc_AddNamedDeviceVisualizationComponentBlocking => Memory.ModuleBase() + 0x73C9E7C;
        public PrimitiveComponent AddNamedDeviceVisualizationComponentBlocking(Actor Target, FName SystemName, FName DeviceName, bool bManualAttachment, Transform RelativeTransform, XRDeviceId XRDeviceId)
        {
            var __pb = new ParamBuffer(104);
            __pb.SetObject(0x0, Target);
            __pb.Set(0x8, SystemName);
            __pb.Set(0x10, DeviceName);
            __pb.Set<byte>(0x18, (byte)(bManualAttachment?1:0));
            __pb.Set<System.IntPtr>(0x20, RelativeTransform);
            __pb.Set<System.IntPtr>(0x50, XRDeviceId);
            CallRaw("AddNamedDeviceVisualizationComponentBlocking", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x60); return __p==System.IntPtr.Zero?null:new PrimitiveComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x73CA0C0 — hookable via Hooks.InstallAt(NativeFunc_AddDeviceVisualizationComponentBlocking).</summary>
        public static System.IntPtr NativeFunc_AddDeviceVisualizationComponentBlocking => Memory.ModuleBase() + 0x73CA0C0;
        public PrimitiveComponent AddDeviceVisualizationComponentBlocking(Actor Target, XRDeviceId XRDeviceId, bool bManualAttachment, Transform RelativeTransform)
        {
            var __pb = new ParamBuffer(88);
            __pb.SetObject(0x0, Target);
            __pb.Set<System.IntPtr>(0x8, XRDeviceId);
            __pb.Set<byte>(0x14, (byte)(bManualAttachment?1:0));
            __pb.Set<System.IntPtr>(0x20, RelativeTransform);
            CallRaw("AddDeviceVisualizationComponentBlocking", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x50); return __p==System.IntPtr.Zero?null:new PrimitiveComponent(__p); }
        }
    }

    public class AsyncTask_LoadXRDeviceVisComponent : BlueprintAsyncActionBase
    {
        public const string UeClassName = "AsyncTask_LoadXRDeviceVisComponent";
        public AsyncTask_LoadXRDeviceVisComponent(System.IntPtr ptr) : base(ptr) {}
        public static new AsyncTask_LoadXRDeviceVisComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AsyncTask_LoadXRDeviceVisComponent(p);
        public static AsyncTask_LoadXRDeviceVisComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AsyncTask_LoadXRDeviceVisComponent(o.Pointer); }
        public static AsyncTask_LoadXRDeviceVisComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AsyncTask_LoadXRDeviceVisComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AsyncTask_LoadXRDeviceVisComponent(a[i].Pointer); return r; }
        public System.IntPtr OnModelLoaded => AddrOf(0x30); // 
        public System.IntPtr OnLoadFailure => AddrOf(0x40); // 
        public PrimitiveComponent SpawnedComponent { get { var __p = GetAt<System.IntPtr>(0x58); return __p==System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x58, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x73CA968 — hookable via Hooks.InstallAt(NativeFunc_AddNamedDeviceVisualizationComponentAsync).</summary>
        public static System.IntPtr NativeFunc_AddNamedDeviceVisualizationComponentAsync => Memory.ModuleBase() + 0x73CA968;
        public AsyncTask_LoadXRDeviceVisComponent AddNamedDeviceVisualizationComponentAsync(Actor Target, FName SystemName, FName DeviceName, bool bManualAttachment, Transform RelativeTransform, XRDeviceId XRDeviceId, PrimitiveComponent NewComponent)
        {
            var __pb = new ParamBuffer(112);
            __pb.SetObject(0x0, Target);
            __pb.Set(0x8, SystemName);
            __pb.Set(0x10, DeviceName);
            __pb.Set<byte>(0x18, (byte)(bManualAttachment?1:0));
            __pb.Set<System.IntPtr>(0x20, RelativeTransform);
            __pb.Set<System.IntPtr>(0x50, XRDeviceId);
            __pb.SetObject(0x60, NewComponent);
            CallRaw("AddNamedDeviceVisualizationComponentAsync", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x68); return __p==System.IntPtr.Zero?null:new AsyncTask_LoadXRDeviceVisComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x73CA760 — hookable via Hooks.InstallAt(NativeFunc_AddDeviceVisualizationComponentAsync).</summary>
        public static System.IntPtr NativeFunc_AddDeviceVisualizationComponentAsync => Memory.ModuleBase() + 0x73CA760;
        public AsyncTask_LoadXRDeviceVisComponent AddDeviceVisualizationComponentAsync(Actor Target, XRDeviceId XRDeviceId, bool bManualAttachment, Transform RelativeTransform, PrimitiveComponent NewComponent)
        {
            var __pb = new ParamBuffer(96);
            __pb.SetObject(0x0, Target);
            __pb.Set<System.IntPtr>(0x8, XRDeviceId);
            __pb.Set<byte>(0x14, (byte)(bManualAttachment?1:0));
            __pb.Set<System.IntPtr>(0x20, RelativeTransform);
            __pb.SetObject(0x50, NewComponent);
            CallRaw("AddDeviceVisualizationComponentAsync", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x58); return __p==System.IntPtr.Zero?null:new AsyncTask_LoadXRDeviceVisComponent(__p); }
        }
    }

    public class XRLoadingScreenFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "XRLoadingScreenFunctionLibrary";
        public XRLoadingScreenFunctionLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new XRLoadingScreenFunctionLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new XRLoadingScreenFunctionLibrary(p);
        public static XRLoadingScreenFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new XRLoadingScreenFunctionLibrary(o.Pointer); }
        public static XRLoadingScreenFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new XRLoadingScreenFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new XRLoadingScreenFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x73CB55C — hookable via Hooks.InstallAt(NativeFunc_ShowLoadingScreen).</summary>
        public static System.IntPtr NativeFunc_ShowLoadingScreen => Memory.ModuleBase() + 0x73CB55C;
        public void ShowLoadingScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowLoadingScreen", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73CB768 — hookable via Hooks.InstallAt(NativeFunc_SetLoadingScreen).</summary>
        public static System.IntPtr NativeFunc_SetLoadingScreen => Memory.ModuleBase() + 0x73CB768;
        public void SetLoadingScreen(Texture Texture, Vector2D Scale, Vector Offset, bool bShowLoadingMovie, bool bShowOnSet)
        {
            var __pb = new ParamBuffer(30);
            __pb.SetObject(0x0, Texture);
            __pb.Set<System.IntPtr>(0x8, Scale);
            __pb.Set<System.IntPtr>(0x10, Offset);
            __pb.Set<byte>(0x1C, (byte)(bShowLoadingMovie?1:0));
            __pb.Set<byte>(0x1D, (byte)(bShowOnSet?1:0));
            CallRaw("SetLoadingScreen", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73CB548 — hookable via Hooks.InstallAt(NativeFunc_HideLoadingScreen).</summary>
        public static System.IntPtr NativeFunc_HideLoadingScreen => Memory.ModuleBase() + 0x73CB548;
        public void HideLoadingScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideLoadingScreen", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73CB754 — hookable via Hooks.InstallAt(NativeFunc_ClearLoadingScreenSplashes).</summary>
        public static System.IntPtr NativeFunc_ClearLoadingScreenSplashes => Memory.ModuleBase() + 0x73CB754;
        public void ClearLoadingScreenSplashes()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearLoadingScreenSplashes", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x73CB570 — hookable via Hooks.InstallAt(NativeFunc_AddLoadingScreenSplash).</summary>
        public static System.IntPtr NativeFunc_AddLoadingScreenSplash => Memory.ModuleBase() + 0x73CB570;
        public void AddLoadingScreenSplash(Texture Texture, Vector Translation, Rotator Rotation, Vector2D Size, Rotator DeltaRotation, bool bClearBeforeAdd)
        {
            var __pb = new ParamBuffer(53);
            __pb.SetObject(0x0, Texture);
            __pb.Set<System.IntPtr>(0x8, Translation);
            __pb.Set<System.IntPtr>(0x14, Rotation);
            __pb.Set<System.IntPtr>(0x20, Size);
            __pb.Set<System.IntPtr>(0x28, DeltaRotation);
            __pb.Set<byte>(0x34, (byte)(bClearBeforeAdd?1:0));
            CallRaw("AddLoadingScreenSplash", __pb.Bytes);
        }
    }

}
