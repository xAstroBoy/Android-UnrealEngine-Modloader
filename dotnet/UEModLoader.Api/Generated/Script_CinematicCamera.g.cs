// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/CinematicCamera
using System;

namespace UEModLoader.Game
{
    public enum ECameraFocusMethod
    {
        DoNotOverride = 0,
        Manual = 1,
        Tracking = 2,
        Disable = 3,
        MAX = 4,
    }

    public class CameraLookatTrackingSettings : StructProxy
    {
        public CameraLookatTrackingSettings(System.IntPtr ptr) : base(ptr) {}
        public bool bEnableLookAtTracking { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bDrawDebugLookAtTrackingPosition { get => (GetAt<byte>(0x0) & 0x2) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public float LookAtTrackingInterpSpeed { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public Actor ActorToTrack { get { var __p = GetAt<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x18, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector RelativeOffset => new Vector(AddrOf(0x40));
        public bool bAllowRoll { get => (GetAt<byte>(0x4C) & 0x1) != 0; set { var __b = GetAt<byte>(0x4C); SetAt(0x4C, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class CameraFocusSettings : StructProxy
    {
        public CameraFocusSettings(System.IntPtr ptr) : base(ptr) {}
        public ECameraFocusMethod FocusMethod { get => (ECameraFocusMethod)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public float ManualFocusDistance { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public CameraTrackingFocusSettings TrackingFocusSettings => new CameraTrackingFocusSettings(AddrOf(0x8));
        public bool bDrawDebugFocusPlane { get => (GetAt<byte>(0x40) & 0x1) != 0; set { var __b = GetAt<byte>(0x40); SetAt(0x40, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public Color DebugFocusPlaneColor => new Color(AddrOf(0x44));
        public bool bSmoothFocusChanges { get => (GetAt<byte>(0x48) & 0x1) != 0; set { var __b = GetAt<byte>(0x48); SetAt(0x48, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public float FocusSmoothingInterpSpeed { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public float FocusOffset { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
    }

    public class CameraTrackingFocusSettings : StructProxy
    {
        public CameraTrackingFocusSettings(System.IntPtr ptr) : base(ptr) {}
        public Actor ActorToTrack { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector RelativeOffset => new Vector(AddrOf(0x28));
        public bool bDrawDebugTrackingFocusPoint { get => (GetAt<byte>(0x34) & 0x1) != 0; set { var __b = GetAt<byte>(0x34); SetAt(0x34, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class NamedLensPreset : StructProxy
    {
        public NamedLensPreset(System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public CameraLensSettings LensSettings => new CameraLensSettings(AddrOf(0x10));
    }

    public class CameraLensSettings : StructProxy
    {
        public CameraLensSettings(System.IntPtr ptr) : base(ptr) {}
        public float MinFocalLength { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float MaxFocalLength { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float MinFStop { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float MaxFStop { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float MinimumFocusDistance { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public int DiaphragmBladeCount { get => GetAt<int>(0x14); set => SetAt(0x14, value); }
    }

    public class NamedFilmbackPreset : StructProxy
    {
        public NamedFilmbackPreset(System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public CameraFilmbackSettings FilmbackSettings => new CameraFilmbackSettings(AddrOf(0x10));
    }

    public class CameraFilmbackSettings : StructProxy
    {
        public CameraFilmbackSettings(System.IntPtr ptr) : base(ptr) {}
        public float SensorWidth { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float SensorHeight { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float SensorAspectRatio { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class CameraRig_Crane : Actor
    {
        public const string UeClassName = "CameraRig_Crane";
        public CameraRig_Crane(System.IntPtr ptr) : base(ptr) {}
        public static new CameraRig_Crane FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CameraRig_Crane(p);
        public static CameraRig_Crane FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CameraRig_Crane(o.Pointer); }
        public static CameraRig_Crane[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CameraRig_Crane[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CameraRig_Crane(a[i].Pointer); return r; }
        public float CranePitch { get => GetAt<float>(0x220); set => SetAt(0x220, value); }
        public float CraneYaw { get => GetAt<float>(0x224); set => SetAt(0x224, value); }
        public float CraneArmLength { get => GetAt<float>(0x228); set => SetAt(0x228, value); }
        public bool bLockMountPitch { get => Native.GetPropBool(Pointer, "bLockMountPitch"); set => Native.SetPropBool(Pointer, "bLockMountPitch", value); }
        public bool bLockMountYaw { get => Native.GetPropBool(Pointer, "bLockMountYaw"); set => Native.SetPropBool(Pointer, "bLockMountYaw", value); }
        public SceneComponent TransformComponent { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent CraneYawControl { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent CranePitchControl { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent CraneCameraMount { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class CameraRig_Rail : Actor
    {
        public const string UeClassName = "CameraRig_Rail";
        public CameraRig_Rail(System.IntPtr ptr) : base(ptr) {}
        public static new CameraRig_Rail FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CameraRig_Rail(p);
        public static CameraRig_Rail FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CameraRig_Rail(o.Pointer); }
        public static CameraRig_Rail[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CameraRig_Rail[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CameraRig_Rail(a[i].Pointer); return r; }
        public float CurrentPositionOnRail { get => GetAt<float>(0x220); set => SetAt(0x220, value); }
        public bool bLockOrientationToRail { get => Native.GetPropBool(Pointer, "bLockOrientationToRail"); set => Native.SetPropBool(Pointer, "bLockOrientationToRail", value); }
        public SceneComponent TransformComponent { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public SplineComponent RailSplineComponent { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new SplineComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent RailCameraMount { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x7EB791C — hookable via Hooks.InstallAt(NativeFunc_GetRailSplineComponent).</summary>
        public static System.IntPtr NativeFunc_GetRailSplineComponent => Memory.ModuleBase() + 0x7EB791C;
        public SplineComponent GetRailSplineComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetRailSplineComponent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new SplineComponent(__p); }
        }
    }

    public class CineCameraActor : CameraActor
    {
        public const string UeClassName = "CineCameraActor";
        public CineCameraActor(System.IntPtr ptr) : base(ptr) {}
        public static new CineCameraActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CineCameraActor(p);
        public static CineCameraActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CineCameraActor(o.Pointer); }
        public static CineCameraActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CineCameraActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CineCameraActor(a[i].Pointer); return r; }
        public CameraLookatTrackingSettings LookatTrackingSettings => new CameraLookatTrackingSettings(AddrOf(0x790));
        /// <summary>[Native] thunk RVA 0x7EB8308 — hookable via Hooks.InstallAt(NativeFunc_GetCineCameraComponent).</summary>
        public static System.IntPtr NativeFunc_GetCineCameraComponent => Memory.ModuleBase() + 0x7EB8308;
        public CineCameraComponent GetCineCameraComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetCineCameraComponent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new CineCameraComponent(__p); }
        }
    }

    public class CineCameraComponent : CameraComponent
    {
        public const string UeClassName = "CineCameraComponent";
        public CineCameraComponent(System.IntPtr ptr) : base(ptr) {}
        public static new CineCameraComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CineCameraComponent(p);
        public static CineCameraComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CineCameraComponent(o.Pointer); }
        public static CineCameraComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CineCameraComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CineCameraComponent(a[i].Pointer); return r; }
        public CameraFilmbackSettings FilmbackSettings => new CameraFilmbackSettings(AddrOf(0x7B0));
        public CameraFilmbackSettings Filmback => new CameraFilmbackSettings(AddrOf(0x7BC));
        public CameraLensSettings LensSettings => new CameraLensSettings(AddrOf(0x7C8));
        public CameraFocusSettings FocusSettings => new CameraFocusSettings(AddrOf(0x7E0));
        public float CurrentFocalLength { get => GetAt<float>(0x838); set => SetAt(0x838, value); }
        public float CurrentAperture { get => GetAt<float>(0x83C); set => SetAt(0x83C, value); }
        public float CurrentFocusDistance { get => GetAt<float>(0x840); set => SetAt(0x840, value); }
        public TArray<System.IntPtr> FilmbackPresets => new TArray<System.IntPtr>(AddrOf(0x850)); // TArray<struct>
        public TArray<System.IntPtr> LensPresets => new TArray<System.IntPtr>(AddrOf(0x860)); // TArray<struct>
        public string DefaultFilmbackPresetName => Native.GetPropString(Pointer, "DefaultFilmbackPresetName"); // FString
        public string DefaultFilmbackPreset => Native.GetPropString(Pointer, "DefaultFilmbackPreset"); // FString
        public string DefaultLensPresetName => Native.GetPropString(Pointer, "DefaultLensPresetName"); // FString
        public float DefaultLensFocalLength { get => GetAt<float>(0x8A0); set => SetAt(0x8A0, value); }
        public float DefaultLensFStop { get => GetAt<float>(0x8A4); set => SetAt(0x8A4, value); }
        /// <summary>[Native] thunk RVA 0x7EB984C — hookable via Hooks.InstallAt(NativeFunc_SetLensPresetByName).</summary>
        public static System.IntPtr NativeFunc_SetLensPresetByName => Memory.ModuleBase() + 0x7EB984C;
        public void SetLensPresetByName(System.IntPtr InPresetName)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPresetName);
            CallRaw("SetLensPresetByName", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB99AC — hookable via Hooks.InstallAt(NativeFunc_SetFilmbackPresetByName).</summary>
        public static System.IntPtr NativeFunc_SetFilmbackPresetByName => Memory.ModuleBase() + 0x7EB99AC;
        public void SetFilmbackPresetByName(System.IntPtr InPresetName)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPresetName);
            CallRaw("SetFilmbackPresetByName", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB9C60 — hookable via Hooks.InstallAt(NativeFunc_SetCurrentFocalLength).</summary>
        public static System.IntPtr NativeFunc_SetCurrentFocalLength => Memory.ModuleBase() + 0x7EB9C60;
        public void SetCurrentFocalLength(float InFocalLength)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InFocalLength);
            CallRaw("SetCurrentFocalLength", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB9BF8 — hookable via Hooks.InstallAt(NativeFunc_GetVerticalFieldOfView).</summary>
        public static System.IntPtr NativeFunc_GetVerticalFieldOfView => Memory.ModuleBase() + 0x7EB9BF8;
        public float GetVerticalFieldOfView()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetVerticalFieldOfView", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EB9734 — hookable via Hooks.InstallAt(NativeFunc_GetLensPresetsCopy).</summary>
        public static System.IntPtr NativeFunc_GetLensPresetsCopy => Memory.ModuleBase() + 0x7EB9734;
        public System.IntPtr GetLensPresetsCopy()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetLensPresetsCopy", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EB98FC — hookable via Hooks.InstallAt(NativeFunc_GetLensPresetName).</summary>
        public static System.IntPtr NativeFunc_GetLensPresetName => Memory.ModuleBase() + 0x7EB98FC;
        public System.IntPtr GetLensPresetName()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetLensPresetName", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EB9C2C — hookable via Hooks.InstallAt(NativeFunc_GetHorizontalFieldOfView).</summary>
        public static System.IntPtr NativeFunc_GetHorizontalFieldOfView => Memory.ModuleBase() + 0x7EB9C2C;
        public float GetHorizontalFieldOfView()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetHorizontalFieldOfView", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EB9B48 — hookable via Hooks.InstallAt(NativeFunc_GetFilmbackPresetName).</summary>
        public static System.IntPtr NativeFunc_GetFilmbackPresetName => Memory.ModuleBase() + 0x7EB9B48;
        public System.IntPtr GetFilmbackPresetName()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetFilmbackPresetName", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EB9A5C — hookable via Hooks.InstallAt(NativeFunc_GetDefaultFilmbackPresetName).</summary>
        public static System.IntPtr NativeFunc_GetDefaultFilmbackPresetName => Memory.ModuleBase() + 0x7EB9A5C;
        public System.IntPtr GetDefaultFilmbackPresetName()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetDefaultFilmbackPresetName", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

}
