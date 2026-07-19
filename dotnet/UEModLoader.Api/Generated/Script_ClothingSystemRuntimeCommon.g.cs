// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/ClothingSystemRuntimeCommon
using System;

namespace UEModLoader.Game
{
    public enum EClothingWindMethod_Legacy
    {
        Legacy = 0,
        Accurate = 1,
    }

    public enum EWeightMapTargetCommon
    {
        None = 0,
        MaxDistance = 1,
        BackstopDistance = 2,
        BackstopRadius = 3,
        AnimDriveMultiplier = 4,
    }

    public class ClothConfig_Legacy : StructProxy
    {
        public ClothConfig_Legacy(System.IntPtr ptr) : base(ptr) {}
        public EClothingWindMethod_Legacy WindMethod { get => (EClothingWindMethod_Legacy)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public ClothConstraintSetup_Legacy VerticalConstraintConfig => new ClothConstraintSetup_Legacy(AddrOf(0x4));
        public ClothConstraintSetup_Legacy HorizontalConstraintConfig => new ClothConstraintSetup_Legacy(AddrOf(0x14));
        public ClothConstraintSetup_Legacy BendConstraintConfig => new ClothConstraintSetup_Legacy(AddrOf(0x24));
        public ClothConstraintSetup_Legacy ShearConstraintConfig => new ClothConstraintSetup_Legacy(AddrOf(0x34));
        public float SelfCollisionRadius { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public float SelfCollisionStiffness { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float SelfCollisionCullScale { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public Vector Damping => new Vector(AddrOf(0x50));
        public float Friction { get => GetAt<float>(0x5C); set => SetAt(0x5C, value); }
        public float WindDragCoefficient { get => GetAt<float>(0x60); set => SetAt(0x60, value); }
        public float WindLiftCoefficient { get => GetAt<float>(0x64); set => SetAt(0x64, value); }
        public Vector LinearDrag => new Vector(AddrOf(0x68));
        public Vector AngularDrag => new Vector(AddrOf(0x74));
        public Vector LinearInertiaScale => new Vector(AddrOf(0x80));
        public Vector AngularInertiaScale => new Vector(AddrOf(0x8C));
        public Vector CentrifugalInertiaScale => new Vector(AddrOf(0x98));
        public float SolverFrequency { get => GetAt<float>(0xA4); set => SetAt(0xA4, value); }
        public float StiffnessFrequency { get => GetAt<float>(0xA8); set => SetAt(0xA8, value); }
        public float GravityScale { get => GetAt<float>(0xAC); set => SetAt(0xAC, value); }
        public Vector GravityOverride => new Vector(AddrOf(0xB0));
        public bool bUseGravityOverride { get => (GetAt<byte>(0xBC) & 0xFF) != 0; set { var __b = GetAt<byte>(0xBC); SetAt(0xBC, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float TetherStiffness { get => GetAt<float>(0xC0); set => SetAt(0xC0, value); }
        public float TetherLimit { get => GetAt<float>(0xC4); set => SetAt(0xC4, value); }
        public float CollisionThickness { get => GetAt<float>(0xC8); set => SetAt(0xC8, value); }
        public float AnimDriveSpringStiffness { get => GetAt<float>(0xCC); set => SetAt(0xCC, value); }
        public float AnimDriveDamperStiffness { get => GetAt<float>(0xD0); set => SetAt(0xD0, value); }
    }

    public class ClothConstraintSetup_Legacy : StructProxy
    {
        public ClothConstraintSetup_Legacy(System.IntPtr ptr) : base(ptr) {}
        public float Stiffness { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float StiffnessMultiplier { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float StretchLimit { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float CompressionLimit { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

    public class ClothLODDataCommon : StructProxy
    {
        public ClothLODDataCommon(System.IntPtr ptr) : base(ptr) {}
        public ClothPhysicalMeshData PhysicalMeshData => new ClothPhysicalMeshData(AddrOf(0x0));
        public ClothCollisionData CollisionData => new ClothCollisionData(AddrOf(0xF8));
    }

    public class ClothPhysicalMeshData : StructProxy
    {
        public ClothPhysicalMeshData(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Vertices => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> Normals => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<System.IntPtr> Indices => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<uint32>
        public System.IntPtr WeightMaps => AddrOf(0x30); // 
        public TArray<System.IntPtr> InverseMasses => new TArray<System.IntPtr>(AddrOf(0x80)); // TArray<float>
        public TArray<System.IntPtr> BoneData => new TArray<System.IntPtr>(AddrOf(0x90)); // TArray<struct>
        public int MaxBoneWeights { get => GetAt<int>(0xA0); set => SetAt(0xA0, value); }
        public int NumFixedVerts { get => GetAt<int>(0xA4); set => SetAt(0xA4, value); }
        public TArray<System.IntPtr> SelfCollisionIndices => new TArray<System.IntPtr>(AddrOf(0xA8)); // TArray<uint32>
        public TArray<System.IntPtr> MaxDistances => new TArray<System.IntPtr>(AddrOf(0xB8)); // TArray<float>
        public TArray<System.IntPtr> BackstopDistances => new TArray<System.IntPtr>(AddrOf(0xC8)); // TArray<float>
        public TArray<System.IntPtr> BackstopRadiuses => new TArray<System.IntPtr>(AddrOf(0xD8)); // TArray<float>
        public TArray<System.IntPtr> AnimDriveMultipliers => new TArray<System.IntPtr>(AddrOf(0xE8)); // TArray<float>
    }

    public class PointWeightMap : StructProxy
    {
        public PointWeightMap(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Values => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<float>
    }

    public class ClothParameterMask_Legacy : StructProxy
    {
        public ClothParameterMask_Legacy(System.IntPtr ptr) : base(ptr) {}
        public string MaskName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName MaskName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public EWeightMapTargetCommon CurrentTarget { get => (EWeightMapTargetCommon)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
        public float MaxValue { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float MinValue { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public TArray<System.IntPtr> Values => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<float>
        public bool bEnabled { get => (GetAt<byte>(0x28) & 0xFF) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class ClothConfigCommon : ClothConfigBase
    {
        public const string UeClassName = "ClothConfigCommon";
        public ClothConfigCommon(System.IntPtr ptr) : base(ptr) {}
        public static new ClothConfigCommon FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothConfigCommon(p);
        public static ClothConfigCommon FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothConfigCommon(o.Pointer); }
        public static ClothConfigCommon[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothConfigCommon[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothConfigCommon(a[i].Pointer); return r; }
    }

    public class ClothSharedConfigCommon : ClothConfigCommon
    {
        public const string UeClassName = "ClothSharedConfigCommon";
        public ClothSharedConfigCommon(System.IntPtr ptr) : base(ptr) {}
        public static new ClothSharedConfigCommon FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothSharedConfigCommon(p);
        public static ClothSharedConfigCommon FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothSharedConfigCommon(o.Pointer); }
        public static ClothSharedConfigCommon[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothSharedConfigCommon[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothSharedConfigCommon(a[i].Pointer); return r; }
    }

    public class ClothingAssetCustomData : Object
    {
        public const string UeClassName = "ClothingAssetCustomData";
        public ClothingAssetCustomData(System.IntPtr ptr) : base(ptr) {}
        public static new ClothingAssetCustomData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothingAssetCustomData(p);
        public static ClothingAssetCustomData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothingAssetCustomData(o.Pointer); }
        public static ClothingAssetCustomData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothingAssetCustomData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothingAssetCustomData(a[i].Pointer); return r; }
    }

    public class ClothingAssetCommon : ClothingAssetBase
    {
        public const string UeClassName = "ClothingAssetCommon";
        public ClothingAssetCommon(System.IntPtr ptr) : base(ptr) {}
        public static new ClothingAssetCommon FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothingAssetCommon(p);
        public static ClothingAssetCommon FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothingAssetCommon(o.Pointer); }
        public static ClothingAssetCommon[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothingAssetCommon[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothingAssetCommon(a[i].Pointer); return r; }
        public PhysicsAsset PhysicsAsset { get { var __p = GetAt<System.IntPtr>(0x48); return __p==System.IntPtr.Zero?null:new PhysicsAsset(__p); } set => SetAt(0x48, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr ClothConfigs => AddrOf(0x50); // 
        public ClothConfigBase ClothSharedSimConfig { get { var __p = GetAt<System.IntPtr>(0xA0); return __p==System.IntPtr.Zero?null:new ClothConfigBase(__p); } set => SetAt(0xA0, value?.Pointer ?? System.IntPtr.Zero); }
        public ClothConfigBase ClothSimConfig { get { var __p = GetAt<System.IntPtr>(0xA8); return __p==System.IntPtr.Zero?null:new ClothConfigBase(__p); } set => SetAt(0xA8, value?.Pointer ?? System.IntPtr.Zero); }
        public ClothConfigBase ChaosClothSimConfig { get { var __p = GetAt<System.IntPtr>(0xB0); return __p==System.IntPtr.Zero?null:new ClothConfigBase(__p); } set => SetAt(0xB0, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> ClothLODData => new TArray<System.IntPtr>(AddrOf(0xB8)); // TArray<UObject*>
        public TArray<System.IntPtr> LODData => new TArray<System.IntPtr>(AddrOf(0xC8)); // TArray<struct>
        public TArray<System.IntPtr> LodMap => new TArray<System.IntPtr>(AddrOf(0xD8)); // TArray<int32>
        public TArray<System.IntPtr> UsedBoneNames => new TArray<System.IntPtr>(AddrOf(0xE8)); // TArray<FName>
        public TArray<System.IntPtr> UsedBoneIndices => new TArray<System.IntPtr>(AddrOf(0xF8)); // TArray<int32>
        public int ReferenceBoneIndex { get => GetAt<int>(0x108); set => SetAt(0x108, value); }
        public ClothingAssetCustomData CustomData { get { var __p = GetAt<System.IntPtr>(0x110); return __p==System.IntPtr.Zero?null:new ClothingAssetCustomData(__p); } set => SetAt(0x110, value?.Pointer ?? System.IntPtr.Zero); }
        public ClothConfig_Legacy ClothConfig => new ClothConfig_Legacy(AddrOf(0x118));
    }

    public class ClothLODDataCommon_Legacy : Object
    {
        public const string UeClassName = "ClothLODDataCommon_Legacy";
        public ClothLODDataCommon_Legacy(System.IntPtr ptr) : base(ptr) {}
        public static new ClothLODDataCommon_Legacy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothLODDataCommon_Legacy(p);
        public static ClothLODDataCommon_Legacy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothLODDataCommon_Legacy(o.Pointer); }
        public static ClothLODDataCommon_Legacy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothLODDataCommon_Legacy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothLODDataCommon_Legacy(a[i].Pointer); return r; }
        public ClothPhysicalMeshDataBase_Legacy PhysicalMeshData { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new ClothPhysicalMeshDataBase_Legacy(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public ClothPhysicalMeshData ClothPhysicalMeshData => new ClothPhysicalMeshData(AddrOf(0x30));
        public ClothCollisionData CollisionData => new ClothCollisionData(AddrOf(0x128));
    }

}
