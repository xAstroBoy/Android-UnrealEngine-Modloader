// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/ClothingSystemRuntimeNv
using System;

namespace UEModLoader.Game
{
    public enum EClothingWindMethodNv
    {
        Legacy = 0,
        Accurate = 1,
    }

    public class ClothConstraintSetupNv : StructProxy
    {
        public ClothConstraintSetupNv(System.IntPtr ptr) : base(ptr) {}
        public float Stiffness { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float StiffnessMultiplier { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float StretchLimit { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float CompressionLimit { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

    public class ClothConfigNv : ClothConfigCommon
    {
        public const string UeClassName = "ClothConfigNv";
        public ClothConfigNv(System.IntPtr ptr) : base(ptr) {}
        public static new ClothConfigNv FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothConfigNv(p);
        public static ClothConfigNv FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothConfigNv(o.Pointer); }
        public static ClothConfigNv[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothConfigNv[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothConfigNv(a[i].Pointer); return r; }
        public EClothingWindMethodNv ClothingWindMethod { get => (EClothingWindMethodNv)GetAt<byte>(0x28); set => SetAt(0x28, (byte)value); }
        public ClothConstraintSetupNv VerticalConstraint => new ClothConstraintSetupNv(AddrOf(0x2C));
        public ClothConstraintSetupNv HorizontalConstraint => new ClothConstraintSetupNv(AddrOf(0x3C));
        public ClothConstraintSetupNv BendConstraint => new ClothConstraintSetupNv(AddrOf(0x4C));
        public ClothConstraintSetupNv ShearConstraint => new ClothConstraintSetupNv(AddrOf(0x5C));
        public float SelfCollisionRadius { get => GetAt<float>(0x6C); set => SetAt(0x6C, value); }
        public float SelfCollisionStiffness { get => GetAt<float>(0x70); set => SetAt(0x70, value); }
        public float SelfCollisionCullScale { get => GetAt<float>(0x74); set => SetAt(0x74, value); }
        public Vector Damping => new Vector(AddrOf(0x78));
        public float Friction { get => GetAt<float>(0x84); set => SetAt(0x84, value); }
        public float WindDragCoefficient { get => GetAt<float>(0x88); set => SetAt(0x88, value); }
        public float WindLiftCoefficient { get => GetAt<float>(0x8C); set => SetAt(0x8C, value); }
        public Vector LinearDrag => new Vector(AddrOf(0x90));
        public Vector AngularDrag => new Vector(AddrOf(0x9C));
        public Vector LinearInertiaScale => new Vector(AddrOf(0xA8));
        public Vector AngularInertiaScale => new Vector(AddrOf(0xB4));
        public Vector CentrifugalInertiaScale => new Vector(AddrOf(0xC0));
        public float SolverFrequency { get => GetAt<float>(0xCC); set => SetAt(0xCC, value); }
        public float StiffnessFrequency { get => GetAt<float>(0xD0); set => SetAt(0xD0, value); }
        public float GravityScale { get => GetAt<float>(0xD4); set => SetAt(0xD4, value); }
        public Vector GravityOverride => new Vector(AddrOf(0xD8));
        public bool bUseGravityOverride { get => Native.GetPropBool(Pointer, "bUseGravityOverride"); set => Native.SetPropBool(Pointer, "bUseGravityOverride", value); }
        public float TetherStiffness { get => GetAt<float>(0xE8); set => SetAt(0xE8, value); }
        public float TetherLimit { get => GetAt<float>(0xEC); set => SetAt(0xEC, value); }
        public float CollisionThickness { get => GetAt<float>(0xF0); set => SetAt(0xF0, value); }
        public float AnimDriveSpringStiffness { get => GetAt<float>(0xF4); set => SetAt(0xF4, value); }
        public float AnimDriveDamperStiffness { get => GetAt<float>(0xF8); set => SetAt(0xF8, value); }
        public EClothingWindMethod_Legacy WindMethod { get => (EClothingWindMethod_Legacy)GetAt<byte>(0xFC); set => SetAt(0xFC, (byte)value); }
        public ClothConstraintSetup_Legacy VerticalConstraintConfig => new ClothConstraintSetup_Legacy(AddrOf(0x100));
        public ClothConstraintSetup_Legacy HorizontalConstraintConfig => new ClothConstraintSetup_Legacy(AddrOf(0x110));
        public ClothConstraintSetup_Legacy BendConstraintConfig => new ClothConstraintSetup_Legacy(AddrOf(0x120));
        public ClothConstraintSetup_Legacy ShearConstraintConfig => new ClothConstraintSetup_Legacy(AddrOf(0x130));
    }

    public class ClothingSimulationFactoryNv : ClothingSimulationFactory
    {
        public const string UeClassName = "ClothingSimulationFactoryNv";
        public ClothingSimulationFactoryNv(System.IntPtr ptr) : base(ptr) {}
        public static new ClothingSimulationFactoryNv FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothingSimulationFactoryNv(p);
        public static ClothingSimulationFactoryNv FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothingSimulationFactoryNv(o.Pointer); }
        public static ClothingSimulationFactoryNv[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothingSimulationFactoryNv[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothingSimulationFactoryNv(a[i].Pointer); return r; }
    }

    public class ClothingSimulationInteractorNv : ClothingSimulationInteractor
    {
        public const string UeClassName = "ClothingSimulationInteractorNv";
        public ClothingSimulationInteractorNv(System.IntPtr ptr) : base(ptr) {}
        public static new ClothingSimulationInteractorNv FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothingSimulationInteractorNv(p);
        public static ClothingSimulationInteractorNv FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothingSimulationInteractorNv(o.Pointer); }
        public static ClothingSimulationInteractorNv[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothingSimulationInteractorNv[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothingSimulationInteractorNv(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x919E9D8 — hookable via Hooks.InstallAt(NativeFunc_SetAnimDriveDamperStiffness).</summary>
        public static System.IntPtr NativeFunc_SetAnimDriveDamperStiffness => Memory.ModuleBase() + 0x919E9D8;
        public void SetAnimDriveDamperStiffness(float InStiffness)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InStiffness);
            CallRaw("SetAnimDriveDamperStiffness", __pb.Bytes);
        }
    }

    public class ClothPhysicalMeshDataNv_Legacy : ClothPhysicalMeshDataBase_Legacy
    {
        public const string UeClassName = "ClothPhysicalMeshDataNv_Legacy";
        public ClothPhysicalMeshDataNv_Legacy(System.IntPtr ptr) : base(ptr) {}
        public static new ClothPhysicalMeshDataNv_Legacy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ClothPhysicalMeshDataNv_Legacy(p);
        public static ClothPhysicalMeshDataNv_Legacy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClothPhysicalMeshDataNv_Legacy(o.Pointer); }
        public static ClothPhysicalMeshDataNv_Legacy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClothPhysicalMeshDataNv_Legacy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClothPhysicalMeshDataNv_Legacy(a[i].Pointer); return r; }
        public TArray<System.IntPtr> MaxDistances => new TArray<System.IntPtr>(AddrOf(0xE0)); // TArray<float>
        public TArray<System.IntPtr> BackstopDistances => new TArray<System.IntPtr>(AddrOf(0xF0)); // TArray<float>
        public TArray<System.IntPtr> BackstopRadiuses => new TArray<System.IntPtr>(AddrOf(0x100)); // TArray<float>
        public TArray<System.IntPtr> AnimDriveMultipliers => new TArray<System.IntPtr>(AddrOf(0x110)); // TArray<float>
    }

}
