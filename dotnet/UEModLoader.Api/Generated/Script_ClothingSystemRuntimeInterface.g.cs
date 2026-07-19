// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/ClothingSystemRuntimeInterface
using System;

namespace UEModLoader.Game
{
    public class ClothCollisionData : StructProxy
    {
        public ClothCollisionData(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Spheres => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> SphereConnections => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<System.IntPtr> Convexes => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<struct>
        public TArray<System.IntPtr> Boxes => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<struct>
    }

    public class ClothCollisionPrim_Box : StructProxy
    {
        public ClothCollisionPrim_Box(System.IntPtr ptr) : base(ptr) {}
        public Vector LocalPosition => new Vector(AddrOf(0x0));
        public Quat LocalRotation => new Quat(AddrOf(0x10));
        public Vector HalfExtents => new Vector(AddrOf(0x20));
        public int BoneIndex { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
    }

    public class ClothCollisionPrim_Convex : StructProxy
    {
        public ClothCollisionPrim_Convex(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Planes => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> SurfacePoints => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public int BoneIndex { get => GetAt<int>(0x20); set => SetAt(0x20, value); }
    }

    public class ClothCollisionPrim_SphereConnection : StructProxy
    {
        public ClothCollisionPrim_SphereConnection(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr SphereIndices => AddrOf(0x0); // [2] static array
    }

    public class ClothCollisionPrim_Sphere : StructProxy
    {
        public ClothCollisionPrim_Sphere(System.IntPtr ptr) : base(ptr) {}
        public int BoneIndex { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public float Radius { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public Vector LocalPosition => new Vector(AddrOf(0x8));
    }

    public class ClothVertBoneData : StructProxy
    {
        public ClothVertBoneData(System.IntPtr ptr) : base(ptr) {}
        public int NumInfluences { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public System.IntPtr BoneIndices => AddrOf(0x4); // [12] static array
        public System.IntPtr BoneWeights => AddrOf(0x1C); // [12] static array
    }

    public class ClothConfigBase : Object
    {
        public const string UeClassName = "ClothConfigBase";
        public ClothConfigBase(System.IntPtr ptr) : base(ptr) {}
        public static new ClothConfigBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothConfigBase(p);
        public static ClothConfigBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothConfigBase(o.Pointer); }
        public static ClothConfigBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothConfigBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothConfigBase(a[i].Pointer); return r; }
    }

    public class ClothingSimulationFactory : Object
    {
        public const string UeClassName = "ClothingSimulationFactory";
        public ClothingSimulationFactory(System.IntPtr ptr) : base(ptr) {}
        public static new ClothingSimulationFactory FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothingSimulationFactory(p);
        public static ClothingSimulationFactory FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothingSimulationFactory(o.Pointer); }
        public static ClothingSimulationFactory[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothingSimulationFactory[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothingSimulationFactory(a[i].Pointer); return r; }
    }

    public class ClothingSimulationInteractor : Object
    {
        public const string UeClassName = "ClothingSimulationInteractor";
        public ClothingSimulationInteractor(System.IntPtr ptr) : base(ptr) {}
        public static new ClothingSimulationInteractor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothingSimulationInteractor(p);
        public static ClothingSimulationInteractor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothingSimulationInteractor(o.Pointer); }
        public static ClothingSimulationInteractor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothingSimulationInteractor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothingSimulationInteractor(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x81BC1F4 — hookable via Hooks.InstallAt(NativeFunc_SetAnimDriveSpringStiffness).</summary>
        public static System.IntPtr NativeFunc_SetAnimDriveSpringStiffness => Memory.ModuleBase() + 0x81BC1F4;
        public void SetAnimDriveSpringStiffness(float InStiffness)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InStiffness);
            CallRaw("SetAnimDriveSpringStiffness", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81BC2BC — hookable via Hooks.InstallAt(NativeFunc_PhysicsAssetUpdated).</summary>
        public static System.IntPtr NativeFunc_PhysicsAssetUpdated => Memory.ModuleBase() + 0x81BC2BC;
        public void PhysicsAssetUpdated()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PhysicsAssetUpdated", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81BC13C — hookable via Hooks.InstallAt(NativeFunc_EnableGravityOverride).</summary>
        public static System.IntPtr NativeFunc_EnableGravityOverride => Memory.ModuleBase() + 0x81BC13C;
        public void EnableGravityOverride(Vector InVector)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, InVector);
            CallRaw("EnableGravityOverride", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81BC120 — hookable via Hooks.InstallAt(NativeFunc_DisableGravityOverride).</summary>
        public static System.IntPtr NativeFunc_DisableGravityOverride => Memory.ModuleBase() + 0x81BC120;
        public void DisableGravityOverride()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableGravityOverride", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81BC2A0 — hookable via Hooks.InstallAt(NativeFunc_ClothConfigUpdated).</summary>
        public static System.IntPtr NativeFunc_ClothConfigUpdated => Memory.ModuleBase() + 0x81BC2A0;
        public void ClothConfigUpdated()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClothConfigUpdated", __pb.Bytes);
        }
    }

    public class ClothSharedSimConfigBase : Object
    {
        public const string UeClassName = "ClothSharedSimConfigBase";
        public ClothSharedSimConfigBase(System.IntPtr ptr) : base(ptr) {}
        public static new ClothSharedSimConfigBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothSharedSimConfigBase(p);
        public static ClothSharedSimConfigBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothSharedSimConfigBase(o.Pointer); }
        public static ClothSharedSimConfigBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothSharedSimConfigBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothSharedSimConfigBase(a[i].Pointer); return r; }
    }

    public class ClothingAssetBase : Object
    {
        public const string UeClassName = "ClothingAssetBase";
        public ClothingAssetBase(System.IntPtr ptr) : base(ptr) {}
        public static new ClothingAssetBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothingAssetBase(p);
        public static ClothingAssetBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothingAssetBase(o.Pointer); }
        public static ClothingAssetBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothingAssetBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothingAssetBase(a[i].Pointer); return r; }
        public string ImportedFilePath => Native.GetPropString(Pointer, "ImportedFilePath"); // FString
        public Guid AssetGuid => new Guid(AddrOf(0x38));
    }

    public class ClothPhysicalMeshDataBase_Legacy : Object
    {
        public const string UeClassName = "ClothPhysicalMeshDataBase_Legacy";
        public ClothPhysicalMeshDataBase_Legacy(System.IntPtr ptr) : base(ptr) {}
        public static new ClothPhysicalMeshDataBase_Legacy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothPhysicalMeshDataBase_Legacy(p);
        public static ClothPhysicalMeshDataBase_Legacy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothPhysicalMeshDataBase_Legacy(o.Pointer); }
        public static ClothPhysicalMeshDataBase_Legacy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothPhysicalMeshDataBase_Legacy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothPhysicalMeshDataBase_Legacy(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Vertices => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public TArray<System.IntPtr> Normals => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<struct>
        public TArray<System.IntPtr> Indices => new TArray<System.IntPtr>(AddrOf(0x48)); // TArray<uint32>
        public TArray<System.IntPtr> InverseMasses => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<float>
        public TArray<System.IntPtr> BoneData => new TArray<System.IntPtr>(AddrOf(0x68)); // TArray<struct>
        public int NumFixedVerts { get => GetAt<int>(0x78); set => SetAt(0x78, value); }
        public int MaxBoneWeights { get => GetAt<int>(0x7C); set => SetAt(0x7C, value); }
        public TArray<System.IntPtr> SelfCollisionIndices => new TArray<System.IntPtr>(AddrOf(0x80)); // TArray<uint32>
    }

}
