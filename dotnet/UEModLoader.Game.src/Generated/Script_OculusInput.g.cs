// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/OculusInput
using System;

namespace UEModLoader.Game
{
    public enum ESystemGestureBehavior
    {
        None = 0,
        SwapMaterial = 1,
    }

    public enum EConfidenceBehavior
    {
        None = 0,
        HideActor = 1,
    }

    public enum EBone
    {
        Wrist_Root = 0,
        Hand_Start = 0,
        Forearm_Stub = 1,
        Thumb = 2,
        Index = 6,
        Middle = 9,
        Ring = 12,
        Pinky = 15,
        Thumb_Tip = 19,
        Max_Skinnable = 19,
        Index_Tip = 20,
        Middle_Tip = 21,
        Ring_Tip = 22,
        Pinky_Tip = 23,
        Hand_End = 24,
        Bone_Max = 24,
        Invalid = 25,
    }

    public enum ETrackingConfidence
    {
        Low = 0,
        High = 1,
    }

    public enum EOculusHandType
    {
        None = 0,
        HandLeft = 1,
        HandRight = 2,
    }

    public class OculusCapsuleCollider : StructProxy
    {
        public OculusCapsuleCollider(global::System.IntPtr ptr) : base(ptr) {}
        public CapsuleComponent Capsule { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new CapsuleComponent(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EBone BoneId { get => (EBone)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
    }

    public class OculusHandComponent : PoseableMeshComponent
    {
        public const string UeClassName = "OculusHandComponent";
        public OculusHandComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusHandComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusHandComponent(p);
        public static OculusHandComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusHandComponent(o.Pointer); }
        public static OculusHandComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusHandComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusHandComponent(a[i].Pointer); return r; }
        public EOculusHandType SkeletonType { get => (EOculusHandType)GetAt<byte>(0x791); set => SetAt(0x791, (byte)value); }
        public EOculusHandType MeshType { get => (EOculusHandType)GetAt<byte>(0x792); set => SetAt(0x792, (byte)value); }
        public EConfidenceBehavior ConfidenceBehavior { get => (EConfidenceBehavior)GetAt<byte>(0x793); set => SetAt(0x793, (byte)value); }
        public ESystemGestureBehavior SystemGestureBehavior { get => (ESystemGestureBehavior)GetAt<byte>(0x794); set => SetAt(0x794, (byte)value); }
        public MaterialInterface SystemGestureMaterial { get { var __p = GetAt<global::System.IntPtr>(0x798); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x798, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bInitializePhysics { get => Native.GetPropBool(Pointer, "bInitializePhysics"); set => Native.SetPropBool(Pointer, "bInitializePhysics", value); }
        public bool bUpdateHandScale { get => Native.GetPropBool(Pointer, "bUpdateHandScale"); set => Native.SetPropBool(Pointer, "bUpdateHandScale", value); }
        public MaterialInterface MaterialOverride { get { var __p = GetAt<global::System.IntPtr>(0x7A8); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x7A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr BoneNameMappings => AddrOf(0x7B0); // 
        public TArray<global::System.IntPtr> CollisionCapsules => new TArray<global::System.IntPtr>(AddrOf(0x800)); // TArray<struct>
        public bool bSkeletalMeshInitialized { get => Native.GetPropBool(Pointer, "bSkeletalMeshInitialized"); set => Native.SetPropBool(Pointer, "bSkeletalMeshInitialized", value); }
    }

    public class OculusInputFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "OculusInputFunctionLibrary";
        public OculusInputFunctionLibrary(global::System.IntPtr ptr) : base(ptr) {}
        public static new OculusInputFunctionLibrary FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new OculusInputFunctionLibrary(p);
        public static OculusInputFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusInputFunctionLibrary(o.Pointer); }
        public static OculusInputFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusInputFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusInputFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5C76E34 — hookable via Hooks.InstallAt(NativeFunc_IsPointerPoseValid).</summary>
        public static global::System.IntPtr NativeFunc_IsPointerPoseValid => Memory.ModuleBase() + 0x5C76E34;
        public bool IsPointerPoseValid(EOculusHandType DeviceHand, int ControllerIndex)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<byte>(0x0, (byte)DeviceHand);
            __pb.Set(0x4, ControllerIndex);
            CallRaw("IsPointerPoseValid", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C76B88 — hookable via Hooks.InstallAt(NativeFunc_IsHandTrackingEnabled).</summary>
        public static global::System.IntPtr NativeFunc_IsHandTrackingEnabled => Memory.ModuleBase() + 0x5C76B88;
        public bool IsHandTrackingEnabled()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsHandTrackingEnabled", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C77148 — hookable via Hooks.InstallAt(NativeFunc_InitializeHandPhysics).</summary>
        public static global::System.IntPtr NativeFunc_InitializeHandPhysics => Memory.ModuleBase() + 0x5C77148;
        public global::System.IntPtr InitializeHandPhysics(EOculusHandType SkeletonType, SkinnedMeshComponent HandComponent, float WorldToMeters)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<byte>(0x0, (byte)SkeletonType);
            __pb.SetObject(0x8, HandComponent);
            __pb.Set(0x10, WorldToMeters);
            CallRaw("InitializeHandPhysics", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x18);
        }
        /// <summary>[Native] thunk RVA 0x5C76D4C — hookable via Hooks.InstallAt(NativeFunc_GetTrackingConfidence).</summary>
        public static global::System.IntPtr NativeFunc_GetTrackingConfidence => Memory.ModuleBase() + 0x5C76D4C;
        public ETrackingConfidence GetTrackingConfidence(EOculusHandType DeviceHand, int ControllerIndex)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<byte>(0x0, (byte)DeviceHand);
            __pb.Set(0x4, ControllerIndex);
            CallRaw("GetTrackingConfidence", __pb.Bytes);
            return (ETrackingConfidence)__pb.Get<byte>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5C76F20 — hookable via Hooks.InstallAt(NativeFunc_GetPointerPose).</summary>
        public static global::System.IntPtr NativeFunc_GetPointerPose => Memory.ModuleBase() + 0x5C76F20;
        public global::System.IntPtr GetPointerPose(EOculusHandType DeviceHand, int ControllerIndex)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<byte>(0x0, (byte)DeviceHand);
            __pb.Set(0x4, ControllerIndex);
            CallRaw("GetPointerPose", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5C772C0 — hookable via Hooks.InstallAt(NativeFunc_GetHandSkeletalMesh).</summary>
        public static global::System.IntPtr NativeFunc_GetHandSkeletalMesh => Memory.ModuleBase() + 0x5C772C0;
        public bool GetHandSkeletalMesh(SkeletalMesh HandSkeletalMesh, EOculusHandType SkeletonType, EOculusHandType MeshType, float WorldToMeters)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, HandSkeletalMesh);
            __pb.Set<byte>(0x8, (byte)SkeletonType);
            __pb.Set<byte>(0x9, (byte)MeshType);
            __pb.Set(0xC, WorldToMeters);
            CallRaw("GetHandSkeletalMesh", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C76C64 — hookable via Hooks.InstallAt(NativeFunc_GetHandScale).</summary>
        public static global::System.IntPtr NativeFunc_GetHandScale => Memory.ModuleBase() + 0x5C76C64;
        public float GetHandScale(EOculusHandType DeviceHand, int ControllerIndex)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<byte>(0x0, (byte)DeviceHand);
            __pb.Set(0x4, ControllerIndex);
            CallRaw("GetHandScale", __pb.Bytes);
            return __pb.Get<float>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5C76BC0 — hookable via Hooks.InstallAt(NativeFunc_GetDominantHand).</summary>
        public static global::System.IntPtr NativeFunc_GetDominantHand => Memory.ModuleBase() + 0x5C76BC0;
        public EOculusHandType GetDominantHand(int ControllerIndex)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, ControllerIndex);
            CallRaw("GetDominantHand", __pb.Bytes);
            return (EOculusHandType)__pb.Get<byte>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5C77018 — hookable via Hooks.InstallAt(NativeFunc_GetBoneRotation).</summary>
        public static global::System.IntPtr NativeFunc_GetBoneRotation => Memory.ModuleBase() + 0x5C77018;
        public global::System.IntPtr GetBoneRotation(EOculusHandType DeviceHand, EBone BoneId, int ControllerIndex)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<byte>(0x0, (byte)DeviceHand);
            __pb.Set<byte>(0x1, (byte)BoneId);
            __pb.Set(0x4, ControllerIndex);
            CallRaw("GetBoneRotation", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5C76A98 — hookable via Hooks.InstallAt(NativeFunc_GetBoneName).</summary>
        public static global::System.IntPtr NativeFunc_GetBoneName => Memory.ModuleBase() + 0x5C76A98;
        public global::System.IntPtr GetBoneName(EBone BoneId)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)BoneId);
            CallRaw("GetBoneName", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
    }

}
