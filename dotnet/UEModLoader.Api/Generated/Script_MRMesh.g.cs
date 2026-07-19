// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/MRMesh
using System;

namespace UEModLoader.Game
{
    public enum EMeshTrackerVertexColorMode
    {
        None = 0,
        Confidence = 1,
        Block = 2,
    }

    public class MRMeshConfiguration : StructProxy
    {
        public MRMeshConfiguration(System.IntPtr ptr) : base(ptr) {}
    }

    public class MeshReconstructorBase : Object
    {
        public const string UeClassName = "MeshReconstructorBase";
        public MeshReconstructorBase(System.IntPtr ptr) : base(ptr) {}
        public static new MeshReconstructorBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MeshReconstructorBase(p);
        public static MeshReconstructorBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MeshReconstructorBase(o.Pointer); }
        public static MeshReconstructorBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MeshReconstructorBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MeshReconstructorBase(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x736B924 — hookable via Hooks.InstallAt(NativeFunc_StopReconstruction).</summary>
        public static System.IntPtr NativeFunc_StopReconstruction => Memory.ModuleBase() + 0x736B924;
        public void StopReconstruction()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopReconstruction", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x736B940 — hookable via Hooks.InstallAt(NativeFunc_StartReconstruction).</summary>
        public static System.IntPtr NativeFunc_StartReconstruction => Memory.ModuleBase() + 0x736B940;
        public void StartReconstruction()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartReconstruction", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x736B908 — hookable via Hooks.InstallAt(NativeFunc_PauseReconstruction).</summary>
        public static System.IntPtr NativeFunc_PauseReconstruction => Memory.ModuleBase() + 0x736B908;
        public void PauseReconstruction()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PauseReconstruction", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x736B8C8 — hookable via Hooks.InstallAt(NativeFunc_IsReconstructionStarted).</summary>
        public static System.IntPtr NativeFunc_IsReconstructionStarted => Memory.ModuleBase() + 0x736B8C8;
        public bool IsReconstructionStarted()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsReconstructionStarted", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x736B888 — hookable via Hooks.InstallAt(NativeFunc_IsReconstructionPaused).</summary>
        public static System.IntPtr NativeFunc_IsReconstructionPaused => Memory.ModuleBase() + 0x736B888;
        public bool IsReconstructionPaused()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsReconstructionPaused", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x736B7C0 — hookable via Hooks.InstallAt(NativeFunc_DisconnectMRMesh).</summary>
        public static System.IntPtr NativeFunc_DisconnectMRMesh => Memory.ModuleBase() + 0x736B7C0;
        public void DisconnectMRMesh()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisconnectMRMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x736B7DC — hookable via Hooks.InstallAt(NativeFunc_ConnectMRMesh).</summary>
        public static System.IntPtr NativeFunc_ConnectMRMesh => Memory.ModuleBase() + 0x736B7DC;
        public void ConnectMRMesh(MRMeshComponent Mesh)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Mesh);
            CallRaw("ConnectMRMesh", __pb.Bytes);
        }
    }

    public class MockDataMeshTrackerComponent : SceneComponent
    {
        public const string UeClassName = "MockDataMeshTrackerComponent";
        public MockDataMeshTrackerComponent(System.IntPtr ptr) : base(ptr) {}
        public static new MockDataMeshTrackerComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MockDataMeshTrackerComponent(p);
        public static MockDataMeshTrackerComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MockDataMeshTrackerComponent(o.Pointer); }
        public static MockDataMeshTrackerComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MockDataMeshTrackerComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MockDataMeshTrackerComponent(a[i].Pointer); return r; }
        public System.IntPtr OnMeshTrackerUpdated => AddrOf(0x1F0); // 
        public bool ScanWorld { get => Native.GetPropBool(Pointer, "ScanWorld"); set => Native.SetPropBool(Pointer, "ScanWorld", value); }
        public bool RequestNormals { get => Native.GetPropBool(Pointer, "RequestNormals"); set => Native.SetPropBool(Pointer, "RequestNormals", value); }
        public bool RequestVertexConfidence { get => Native.GetPropBool(Pointer, "RequestVertexConfidence"); set => Native.SetPropBool(Pointer, "RequestVertexConfidence", value); }
        public EMeshTrackerVertexColorMode VertexColorMode { get => (EMeshTrackerVertexColorMode)GetAt<byte>(0x203); set => SetAt(0x203, (byte)value); }
        public TArray<System.IntPtr> BlockVertexColors => new TArray<System.IntPtr>(AddrOf(0x208)); // TArray<struct>
        public LinearColor VertexColorFromConfidenceZero => new LinearColor(AddrOf(0x218));
        public LinearColor VertexColorFromConfidenceOne => new LinearColor(AddrOf(0x228));
        public float UpdateInterval { get => GetAt<float>(0x238); set => SetAt(0x238, value); }
        public MRMeshComponent MRMesh { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new MRMeshComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public void OnMockDataMeshTrackerUpdated__DelegateSignature(int Index, System.IntPtr Vertices, System.IntPtr Triangles, System.IntPtr Normals, System.IntPtr Confidence)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set(0x0, Index);
            __pb.Set<System.IntPtr>(0x8, Vertices);
            __pb.Set<System.IntPtr>(0x18, Triangles);
            __pb.Set<System.IntPtr>(0x28, Normals);
            __pb.Set<System.IntPtr>(0x38, Confidence);
            CallRaw("OnMockDataMeshTrackerUpdated__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x736C75C — hookable via Hooks.InstallAt(NativeFunc_DisconnectMRMesh).</summary>
        public static System.IntPtr NativeFunc_DisconnectMRMesh => Memory.ModuleBase() + 0x736C75C;
        public void DisconnectMRMesh(MRMeshComponent InMRMeshPtr)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InMRMeshPtr);
            CallRaw("DisconnectMRMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x736C800 — hookable via Hooks.InstallAt(NativeFunc_ConnectMRMesh).</summary>
        public static System.IntPtr NativeFunc_ConnectMRMesh => Memory.ModuleBase() + 0x736C800;
        public void ConnectMRMesh(MRMeshComponent InMRMeshPtr)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InMRMeshPtr);
            CallRaw("ConnectMRMesh", __pb.Bytes);
        }
    }

    public class MRMeshComponent : PrimitiveComponent
    {
        public const string UeClassName = "MRMeshComponent";
        public MRMeshComponent(System.IntPtr ptr) : base(ptr) {}
        public static new MRMeshComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MRMeshComponent(p);
        public static MRMeshComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MRMeshComponent(o.Pointer); }
        public static MRMeshComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MRMeshComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MRMeshComponent(a[i].Pointer); return r; }
        public MaterialInterface Material { get { var __p = GetAt<System.IntPtr>(0x410); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x410, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bCreateMeshProxySections { get => Native.GetPropBool(Pointer, "bCreateMeshProxySections"); set => Native.SetPropBool(Pointer, "bCreateMeshProxySections", value); }
        public bool bUpdateNavMeshOnMeshUpdate { get => Native.GetPropBool(Pointer, "bUpdateNavMeshOnMeshUpdate"); set => Native.SetPropBool(Pointer, "bUpdateNavMeshOnMeshUpdate", value); }
        public bool bNeverCreateCollisionMesh { get => Native.GetPropBool(Pointer, "bNeverCreateCollisionMesh"); set => Native.SetPropBool(Pointer, "bNeverCreateCollisionMesh", value); }
        public BodySetup CachedBodySetup { get { var __p = GetAt<System.IntPtr>(0x420); return __p==System.IntPtr.Zero?null:new BodySetup(__p); } set => SetAt(0x420, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> BodySetups => new TArray<System.IntPtr>(AddrOf(0x428)); // TArray<UObject*>
        public MaterialInterface WireframeMaterial { get { var __p = GetAt<System.IntPtr>(0x438); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x438, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x736D470 — hookable via Hooks.InstallAt(NativeFunc_IsConnected).</summary>
        public static System.IntPtr NativeFunc_IsConnected => Memory.ModuleBase() + 0x736D470;
        public bool IsConnected()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsConnected", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x736D45C — hookable via Hooks.InstallAt(NativeFunc_ForceNavMeshUpdate).</summary>
        public static System.IntPtr NativeFunc_ForceNavMeshUpdate => Memory.ModuleBase() + 0x736D45C;
        public void ForceNavMeshUpdate()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ForceNavMeshUpdate", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x736D440 — hookable via Hooks.InstallAt(NativeFunc_Clear).</summary>
        public static System.IntPtr NativeFunc_Clear => Memory.ModuleBase() + 0x736D440;
        public void Clear()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Clear", __pb.Bytes);
        }
    }

}
