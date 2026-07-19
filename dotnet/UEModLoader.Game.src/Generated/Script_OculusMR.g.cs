// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/OculusMR
using System;

namespace UEModLoader.Game
{
    public enum EOculusMR_CompositionMethod
    {
        ExternalComposition = 0,
        DirectComposition = 1,
    }

    public enum EOculusMR_PostProcessEffects
    {
        PPE_Off = 0,
        PPE_On = 1,
    }

    public enum EOculusMR_ClippingReference
    {
        CR_TrackingReference = 0,
        CR_Head = 1,
    }

    public enum EOculusMR_CameraDeviceEnum
    {
        CD_None = 0,
        CD_WebCamera0 = 1,
        CD_WebCamera1 = 2,
    }

    public class OculusMR_PlaneMeshTriangle : StructProxy
    {
        public OculusMR_PlaneMeshTriangle(global::System.IntPtr ptr) : base(ptr) {}
        public Vector Vertex0 => new Vector(AddrOf(0x0));
        public Vector2D UV0 => new Vector2D(AddrOf(0xC));
        public Vector Vertex1 => new Vector(AddrOf(0x14));
        public Vector2D UV1 => new Vector2D(AddrOf(0x20));
        public Vector Vertex2 => new Vector(AddrOf(0x28));
        public Vector2D UV2 => new Vector2D(AddrOf(0x34));
    }

    public class TrackedCamera : StructProxy
    {
        public TrackedCamera(global::System.IntPtr ptr) : base(ptr) {}
        public int Index { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public string Name => Native.ReadFStringAt(AddrOf(0x8)); // FString
        public double UpdateTime { get => GetAt<double>(0x18); set => SetAt(0x18, value); }
        public float FieldOfView { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public int SizeX { get => GetAt<int>(0x24); set => SetAt(0x24, value); }
        public int SizeY { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public ETrackedDeviceType AttachedTrackedDevice { get => (ETrackedDeviceType)GetAt<byte>(0x2C); set => SetAt(0x2C, (byte)value); }
        public Rotator CalibratedRotation => new Rotator(AddrOf(0x30));
        public Vector CalibratedOffset => new Vector(AddrOf(0x3C));
        public Rotator UserRotation => new Rotator(AddrOf(0x48));
        public Vector UserOffset => new Vector(AddrOf(0x54));
        public Rotator RawRotation => new Rotator(AddrOf(0x60));
        public Vector RawOffset => new Vector(AddrOf(0x6C));
    }

    public class OculusMRFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "OculusMRFunctionLibrary";
        public OculusMRFunctionLibrary(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusMRFunctionLibrary FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusMRFunctionLibrary(p);
        public static OculusMRFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusMRFunctionLibrary(o.Pointer); }
        public static OculusMRFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusMRFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusMRFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5C8316C — hookable via Hooks.InstallAt(NativeFunc_SetTrackingReferenceComponent).</summary>
        public static global::System.IntPtr NativeFunc_SetTrackingReferenceComponent => Memory.ModuleBase() + 0x5C8316C;
        public bool SetTrackingReferenceComponent(SceneComponent component)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, component);
            CallRaw("SetTrackingReferenceComponent", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C83090 — hookable via Hooks.InstallAt(NativeFunc_SetMrcScalingFactor).</summary>
        public static global::System.IntPtr NativeFunc_SetMrcScalingFactor => Memory.ModuleBase() + 0x5C83090;
        public bool SetMrcScalingFactor(float ScalingFactor)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, ScalingFactor);
            CallRaw("SetMrcScalingFactor", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C83058 — hookable via Hooks.InstallAt(NativeFunc_IsMrcEnabled).</summary>
        public static global::System.IntPtr NativeFunc_IsMrcEnabled => Memory.ModuleBase() + 0x5C83058;
        public bool IsMrcEnabled()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsMrcEnabled", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C83020 — hookable via Hooks.InstallAt(NativeFunc_IsMrcActive).</summary>
        public static global::System.IntPtr NativeFunc_IsMrcActive => Memory.ModuleBase() + 0x5C83020;
        public bool IsMrcActive()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsMrcActive", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C83214 — hookable via Hooks.InstallAt(NativeFunc_GetTrackingReferenceComponent).</summary>
        public static global::System.IntPtr NativeFunc_GetTrackingReferenceComponent => Memory.ModuleBase() + 0x5C83214;
        public SceneComponent GetTrackingReferenceComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetTrackingReferenceComponent", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5C83248 — hookable via Hooks.InstallAt(NativeFunc_GetOculusMRSettings).</summary>
        public static global::System.IntPtr NativeFunc_GetOculusMRSettings => Memory.ModuleBase() + 0x5C83248;
        public OculusMR_Settings GetOculusMRSettings()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetOculusMRSettings", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new OculusMR_Settings(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5C83138 — hookable via Hooks.InstallAt(NativeFunc_GetMrcScalingFactor).</summary>
        public static global::System.IntPtr NativeFunc_GetMrcScalingFactor => Memory.ModuleBase() + 0x5C83138;
        public float GetMrcScalingFactor()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMrcScalingFactor", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
    }

    public class OculusMR_CastingCameraActor : SceneCapture2D
    {
        public const string UeClassName = "OculusMR_CastingCameraActor";
        public OculusMR_CastingCameraActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusMR_CastingCameraActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusMR_CastingCameraActor(p);
        public static OculusMR_CastingCameraActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusMR_CastingCameraActor(o.Pointer); }
        public static OculusMR_CastingCameraActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusMR_CastingCameraActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusMR_CastingCameraActor(a[i].Pointer); return r; }
        public VRNotificationsComponent VRNotificationComponent { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new VRNotificationsComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Texture2D CameraColorTexture { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Texture2D CameraDepthTexture { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public OculusMR_PlaneMeshComponent PlaneMeshComponent { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new OculusMR_PlaneMeshComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Material ChromaKeyMaterial { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Material(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Material OpaqueColoredMaterial { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Material(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic ChromaKeyMaterialInstance { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic CameraFrameMaterialInstance { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic BackdropMaterialInstance { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Texture2D DefaultTexture_White { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> BackgroundRenderTargets => new TArray<global::System.IntPtr>(AddrOf(0x2D8)); // TArray<UObject*>
        public SceneCapture2D ForegroundCaptureActor { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new SceneCapture2D(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> ForegroundRenderTargets => new TArray<global::System.IntPtr>(AddrOf(0x2F0)); // TArray<UObject*>
        public TArray<global::System.IntPtr> PoseTimes => new TArray<global::System.IntPtr>(AddrOf(0x300)); // TArray<double>
        public OculusMR_Settings MRSettings { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new OculusMR_Settings(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public OculusMR_State MRState { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new OculusMR_State(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class OculusMR_PlaneMeshComponent : MeshComponent
    {
        public const string UeClassName = "OculusMR_PlaneMeshComponent";
        public OculusMR_PlaneMeshComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusMR_PlaneMeshComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusMR_PlaneMeshComponent(p);
        public static OculusMR_PlaneMeshComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusMR_PlaneMeshComponent(o.Pointer); }
        public static OculusMR_PlaneMeshComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusMR_PlaneMeshComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusMR_PlaneMeshComponent(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5C844E8 — hookable via Hooks.InstallAt(NativeFunc_SetCustomMeshTriangles).</summary>
        public static global::System.IntPtr NativeFunc_SetCustomMeshTriangles => Memory.ModuleBase() + 0x5C844E8;
        public bool SetCustomMeshTriangles(global::System.IntPtr Triangles)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, Triangles);
            CallRaw("SetCustomMeshTriangles", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C84414 — hookable via Hooks.InstallAt(NativeFunc_ClearCustomMeshTriangles).</summary>
        public static global::System.IntPtr NativeFunc_ClearCustomMeshTriangles => Memory.ModuleBase() + 0x5C84414;
        public void ClearCustomMeshTriangles()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearCustomMeshTriangles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C84428 — hookable via Hooks.InstallAt(NativeFunc_AddCustomMeshTriangles).</summary>
        public static global::System.IntPtr NativeFunc_AddCustomMeshTriangles => Memory.ModuleBase() + 0x5C84428;
        public void AddCustomMeshTriangles(global::System.IntPtr Triangles)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, Triangles);
            CallRaw("AddCustomMeshTriangles", __pb.Bytes);
        }
    }

    public class OculusMR_Settings : Object
    {
        public const string UeClassName = "OculusMR_Settings";
        public OculusMR_Settings(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusMR_Settings FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusMR_Settings(p);
        public static OculusMR_Settings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusMR_Settings(o.Pointer); }
        public static OculusMR_Settings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusMR_Settings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusMR_Settings(a[i].Pointer); return r; }
        public EOculusMR_ClippingReference ClippingReference { get => (EOculusMR_ClippingReference)GetAt<byte>(0x28); set => SetAt(0x28, (byte)value); }
        public bool bUseTrackedCameraResolution { get => Native.GetPropBool(Pointer, "bUseTrackedCameraResolution"); set => Native.SetPropBool(Pointer, "bUseTrackedCameraResolution", value); }
        public int WidthPerView { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public int HeightPerView { get => GetAt<int>(0x30); set => SetAt(0x30, value); }
        public float CastingLatency { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public Color BackdropColor => new Color(AddrOf(0x38));
        public float HandPoseStateLatency { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public Color ChromaKeyColor => new Color(AddrOf(0x40));
        public float ChromaKeySimilarity { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public float ChromaKeySmoothRange { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float ChromaKeySpillRange { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public EOculusMR_PostProcessEffects ExternalCompositionPostProcessEffects { get => (EOculusMR_PostProcessEffects)GetAt<byte>(0x50); set => SetAt(0x50, (byte)value); }
        public bool bIsCasting { get => Native.GetPropBool(Pointer, "bIsCasting"); set => Native.SetPropBool(Pointer, "bIsCasting", value); }
        public EOculusMR_CompositionMethod CompositionMethod { get => (EOculusMR_CompositionMethod)GetAt<byte>(0x52); set => SetAt(0x52, (byte)value); }
        public EOculusMR_CameraDeviceEnum CapturingCamera { get => (EOculusMR_CameraDeviceEnum)GetAt<byte>(0x53); set => SetAt(0x53, (byte)value); }
        /// <summary>[Native] thunk RVA 0x5C85538 — hookable via Hooks.InstallAt(NativeFunc_SetIsCasting).</summary>
        public static global::System.IntPtr NativeFunc_SetIsCasting => Memory.ModuleBase() + 0x5C85538;
        public void SetIsCasting(bool val)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(val?1:0));
            CallRaw("SetIsCasting", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C856C0 — hookable via Hooks.InstallAt(NativeFunc_SetCompositionMethod).</summary>
        public static global::System.IntPtr NativeFunc_SetCompositionMethod => Memory.ModuleBase() + 0x5C856C0;
        public void SetCompositionMethod(EOculusMR_CompositionMethod val)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)val);
            CallRaw("SetCompositionMethod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C85600 — hookable via Hooks.InstallAt(NativeFunc_SetCapturingCamera).</summary>
        public static global::System.IntPtr NativeFunc_SetCapturingCamera => Memory.ModuleBase() + 0x5C85600;
        public void SetCapturingCamera(EOculusMR_CameraDeviceEnum val)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)val);
            CallRaw("SetCapturingCamera", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C85450 — hookable via Hooks.InstallAt(NativeFunc_SaveToIni).</summary>
        public static global::System.IntPtr NativeFunc_SaveToIni => Memory.ModuleBase() + 0x5C85450;
        public void SaveToIni()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SaveToIni", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C85464 — hookable via Hooks.InstallAt(NativeFunc_LoadFromIni).</summary>
        public static global::System.IntPtr NativeFunc_LoadFromIni => Memory.ModuleBase() + 0x5C85464;
        public void LoadFromIni()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("LoadFromIni", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C855E4 — hookable via Hooks.InstallAt(NativeFunc_GetIsCasting).</summary>
        public static global::System.IntPtr NativeFunc_GetIsCasting => Memory.ModuleBase() + 0x5C855E4;
        public bool GetIsCasting()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetIsCasting", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C85764 — hookable via Hooks.InstallAt(NativeFunc_GetCompositionMethod).</summary>
        public static global::System.IntPtr NativeFunc_GetCompositionMethod => Memory.ModuleBase() + 0x5C85764;
        public EOculusMR_CompositionMethod GetCompositionMethod()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetCompositionMethod", __pb.Bytes);
            return (EOculusMR_CompositionMethod)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C856A4 — hookable via Hooks.InstallAt(NativeFunc_GetCapturingCamera).</summary>
        public static global::System.IntPtr NativeFunc_GetCapturingCamera => Memory.ModuleBase() + 0x5C856A4;
        public EOculusMR_CameraDeviceEnum GetCapturingCamera()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetCapturingCamera", __pb.Bytes);
            return (EOculusMR_CameraDeviceEnum)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C85478 — hookable via Hooks.InstallAt(NativeFunc_GetBindToTrackedCameraIndex).</summary>
        public static global::System.IntPtr NativeFunc_GetBindToTrackedCameraIndex => Memory.ModuleBase() + 0x5C85478;
        public int GetBindToTrackedCameraIndex()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetBindToTrackedCameraIndex", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C85494 — hookable via Hooks.InstallAt(NativeFunc_BindToTrackedCameraIndexIfAvailable).</summary>
        public static global::System.IntPtr NativeFunc_BindToTrackedCameraIndexIfAvailable => Memory.ModuleBase() + 0x5C85494;
        public void BindToTrackedCameraIndexIfAvailable(int InTrackedCameraIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InTrackedCameraIndex);
            CallRaw("BindToTrackedCameraIndexIfAvailable", __pb.Bytes);
        }
    }

    public class OculusMR_State : Object
    {
        public const string UeClassName = "OculusMR_State";
        public OculusMR_State(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusMR_State FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusMR_State(p);
        public static OculusMR_State FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusMR_State(o.Pointer); }
        public static OculusMR_State[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusMR_State[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusMR_State(a[i].Pointer); return r; }
        public TrackedCamera TrackedCamera => new TrackedCamera(AddrOf(0x28));
        public SceneComponent TrackingReferenceComponent { get { var __p = GetAt<global::System.IntPtr>(0xA0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0xA0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public double ScalingFactor { get => GetAt<double>(0xA8); set => SetAt(0xA8, value); }
        public bool ChangeCameraStateRequested { get => Native.GetPropBool(Pointer, "ChangeCameraStateRequested"); set => Native.SetPropBool(Pointer, "ChangeCameraStateRequested", value); }
        public bool BindToTrackedCameraIndexRequested { get => Native.GetPropBool(Pointer, "BindToTrackedCameraIndexRequested"); set => Native.SetPropBool(Pointer, "BindToTrackedCameraIndexRequested", value); }
    }

}
