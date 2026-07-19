// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/ChaosCloth
using System;

namespace UEModLoader.Game
{
    public enum EChaosWeightMapTarget
    {
        None = 0,
        MaxDistance = 1,
        BackstopDistance = 2,
        BackstopRadius = 3,
        AnimDriveMultiplier = 4,
    }

    public class ChaosClothConfig : ClothConfigCommon
    {
        public const string UeClassName = "ChaosClothConfig";
        public ChaosClothConfig(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosClothConfig FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosClothConfig(p);
        public static ChaosClothConfig FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosClothConfig(o.Pointer); }
        public static ChaosClothConfig[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosClothConfig[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosClothConfig(a[i].Pointer); return r; }
        public EClothMassMode MassMode { get => (EClothMassMode)GetAt<byte>(0x28); set => SetAt(0x28, (byte)value); }
        public float UniformMass { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float TotalMass { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float Density { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public float MinPerParticleMass { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public float EdgeStiffness { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public float BendingStiffness { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public float AreaStiffness { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public float VolumeStiffness { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float StrainLimitingStiffness { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public float LimitScale { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
        public bool bUseGeodesicDistance { get => Native.GetPropBool(Pointer, "bUseGeodesicDistance"); set => Native.SetPropBool(Pointer, "bUseGeodesicDistance", value); }
        public float ShapeTargetStiffness { get => GetAt<float>(0x58); set => SetAt(0x58, value); }
        public float CollisionThickness { get => GetAt<float>(0x5C); set => SetAt(0x5C, value); }
        public float FrictionCoefficient { get => GetAt<float>(0x60); set => SetAt(0x60, value); }
        public float DampingCoefficient { get => GetAt<float>(0x64); set => SetAt(0x64, value); }
        public float DragCoefficient { get => GetAt<float>(0x68); set => SetAt(0x68, value); }
        public float AnimDriveSpringStiffness { get => GetAt<float>(0x6C); set => SetAt(0x6C, value); }
        public bool bUseBendingElements { get => Native.GetPropBool(Pointer, "bUseBendingElements"); set => Native.SetPropBool(Pointer, "bUseBendingElements", value); }
        public bool bUseTetrahedralConstraints { get => Native.GetPropBool(Pointer, "bUseTetrahedralConstraints"); set => Native.SetPropBool(Pointer, "bUseTetrahedralConstraints", value); }
        public bool bUseThinShellVolumeConstraints { get => Native.GetPropBool(Pointer, "bUseThinShellVolumeConstraints"); set => Native.SetPropBool(Pointer, "bUseThinShellVolumeConstraints", value); }
        public bool bUseSelfCollisions { get => Native.GetPropBool(Pointer, "bUseSelfCollisions"); set => Native.SetPropBool(Pointer, "bUseSelfCollisions", value); }
        public bool bUseContinuousCollisionDetection { get => Native.GetPropBool(Pointer, "bUseContinuousCollisionDetection"); set => Native.SetPropBool(Pointer, "bUseContinuousCollisionDetection", value); }
        public Vector LinearVelocityScale => new Vector(AddrOf(0x78));
        public float AngularVelocityScale { get => GetAt<float>(0x84); set => SetAt(0x84, value); }
    }

    public class ChaosClothSharedSimConfig : ClothSharedConfigCommon
    {
        public const string UeClassName = "ChaosClothSharedSimConfig";
        public ChaosClothSharedSimConfig(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosClothSharedSimConfig FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosClothSharedSimConfig(p);
        public static ChaosClothSharedSimConfig FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosClothSharedSimConfig(o.Pointer); }
        public static ChaosClothSharedSimConfig[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosClothSharedSimConfig[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosClothSharedSimConfig(a[i].Pointer); return r; }
        public int IterationCount { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public int SubdivisionCount { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public float SelfCollisionThickness { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float CollisionThickness { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public bool bUseDampingOverride { get => Native.GetPropBool(Pointer, "bUseDampingOverride"); set => Native.SetPropBool(Pointer, "bUseDampingOverride", value); }
        public float Damping { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public bool bUseGravityOverride { get => Native.GetPropBool(Pointer, "bUseGravityOverride"); set => Native.SetPropBool(Pointer, "bUseGravityOverride", value); }
        public float GravityScale { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public Vector Gravity => new Vector(AddrOf(0x48));
        public bool bUseLocalSpaceSimulation { get => Native.GetPropBool(Pointer, "bUseLocalSpaceSimulation"); set => Native.SetPropBool(Pointer, "bUseLocalSpaceSimulation", value); }
        public bool bUseXPBDConstraints { get => Native.GetPropBool(Pointer, "bUseXPBDConstraints"); set => Native.SetPropBool(Pointer, "bUseXPBDConstraints", value); }
    }

    public class ChaosClothingSimulationFactory : ClothingSimulationFactory
    {
        public const string UeClassName = "ChaosClothingSimulationFactory";
        public ChaosClothingSimulationFactory(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosClothingSimulationFactory FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosClothingSimulationFactory(p);
        public static ChaosClothingSimulationFactory FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosClothingSimulationFactory(o.Pointer); }
        public static ChaosClothingSimulationFactory[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosClothingSimulationFactory[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosClothingSimulationFactory(a[i].Pointer); return r; }
    }

    public class ChaosClothingSimulationInteractor : ClothingSimulationInteractor
    {
        public const string UeClassName = "ChaosClothingSimulationInteractor";
        public ChaosClothingSimulationInteractor(System.IntPtr ptr) : base(ptr) {}
        public static new ChaosClothingSimulationInteractor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ChaosClothingSimulationInteractor(p);
        public static ChaosClothingSimulationInteractor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ChaosClothingSimulationInteractor(o.Pointer); }
        public static ChaosClothingSimulationInteractor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ChaosClothingSimulationInteractor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ChaosClothingSimulationInteractor(a[i].Pointer); return r; }
    }

}
