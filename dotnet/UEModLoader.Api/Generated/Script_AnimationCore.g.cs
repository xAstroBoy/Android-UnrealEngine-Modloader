// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AnimationCore
using System;

namespace UEModLoader.Game
{
    public enum ETransformConstraintType
    {
        Translation = 0,
        Rotation = 1,
        Scale = 2,
        Parent = 3,
    }

    public enum EConstraintType
    {
        Transform = 0,
        Aim = 1,
        MAX = 2,
    }

    public class EulerTransform : StructProxy
    {
        public EulerTransform(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x0));
        public Rotator Rotation => new Rotator(AddrOf(0xC));
        public Vector Scale => new Vector(AddrOf(0x18));
    }

    public class Axis : StructProxy
    {
        public Axis(System.IntPtr ptr) : base(ptr) {}
        public Vector Axis_2 => new Vector(AddrOf(0x0));
        public bool bInLocalSpace { get => (GetAt<byte>(0xC) & 0xFF) != 0; set { var __b = GetAt<byte>(0xC); SetAt(0xC, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class CCDIKChainLink : StructProxy
    {
        public CCDIKChainLink(System.IntPtr ptr) : base(ptr) {}
    }

    public class ConstraintData : StructProxy
    {
        public ConstraintData(System.IntPtr ptr) : base(ptr) {}
        public ConstraintDescriptor Constraint => new ConstraintDescriptor(AddrOf(0x0));
        public float Weight { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public bool bMaintainOffset { get => (GetAt<byte>(0x14) & 0xFF) != 0; set { var __b = GetAt<byte>(0x14); SetAt(0x14, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public Transform Offset => new Transform(AddrOf(0x20));
        public Transform CurrentTransform => new Transform(AddrOf(0x50));
    }

    public class ConstraintDescriptor : StructProxy
    {
        public ConstraintDescriptor(System.IntPtr ptr) : base(ptr) {}
        public EConstraintType Type { get => (EConstraintType)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
    }

    public class ConstraintDescriptionEx : StructProxy
    {
        public ConstraintDescriptionEx(System.IntPtr ptr) : base(ptr) {}
        public FilterOptionPerAxis AxesFilterOption => new FilterOptionPerAxis(AddrOf(0x8));
    }

    public class FilterOptionPerAxis : StructProxy
    {
        public FilterOptionPerAxis(System.IntPtr ptr) : base(ptr) {}
        public bool bX { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bY { get => (GetAt<byte>(0x1) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bZ { get => (GetAt<byte>(0x2) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AimConstraintDescription : StructProxy
    {
        public AimConstraintDescription(System.IntPtr ptr) : base(ptr) {}
        public Axis LookAt_Axis => new Axis(AddrOf(0xC));
        public Axis LookUp_Axis => new Axis(AddrOf(0x1C));
        public bool bUseLookUp { get => (GetAt<byte>(0x2C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2C); SetAt(0x2C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public Vector LookUpTarget => new Vector(AddrOf(0x30));
    }

    public class TransformConstraintDescription : StructProxy
    {
        public TransformConstraintDescription(System.IntPtr ptr) : base(ptr) {}
        public ETransformConstraintType TransformType { get => (ETransformConstraintType)GetAt<byte>(0xB); set => SetAt(0xB, (byte)value); }
    }

    public class TransformConstraint : StructProxy
    {
        public TransformConstraint(System.IntPtr ptr) : base(ptr) {}
        public ConstraintDescription Operator => new ConstraintDescription(AddrOf(0x0));
        public string SourceNode => Native.FNameToString(GetAt<int>(0x10)); // FName
        public FName SourceNode_Raw { get => GetAt<FName>(0x10); set => SetAt(0x10, value); }
        public string TargetNode => Native.FNameToString(GetAt<int>(0x18)); // FName
        public FName TargetNode_Raw { get => GetAt<FName>(0x18); set => SetAt(0x18, value); }
        public float Weight { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public bool bMaintainOffset { get => (GetAt<byte>(0x24) & 0xFF) != 0; set { var __b = GetAt<byte>(0x24); SetAt(0x24, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class ConstraintDescription : StructProxy
    {
        public ConstraintDescription(System.IntPtr ptr) : base(ptr) {}
        public bool bTranslation { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bRotation { get => (GetAt<byte>(0x1) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bScale { get => (GetAt<byte>(0x2) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bParent { get => (GetAt<byte>(0x3) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3); SetAt(0x3, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public FilterOptionPerAxis TranslationAxes => new FilterOptionPerAxis(AddrOf(0x4));
        public FilterOptionPerAxis RotationAxes => new FilterOptionPerAxis(AddrOf(0x7));
        public FilterOptionPerAxis ScaleAxes => new FilterOptionPerAxis(AddrOf(0xA));
    }

    public class ConstraintOffset : StructProxy
    {
        public ConstraintOffset(System.IntPtr ptr) : base(ptr) {}
        public Vector Translation => new Vector(AddrOf(0x0));
        public Quat Rotation => new Quat(AddrOf(0x10));
        public Vector Scale => new Vector(AddrOf(0x20));
        public Transform Parent => new Transform(AddrOf(0x30));
    }

    public class TransformFilter : StructProxy
    {
        public TransformFilter(System.IntPtr ptr) : base(ptr) {}
        public FilterOptionPerAxis TranslationFilter => new FilterOptionPerAxis(AddrOf(0x0));
        public FilterOptionPerAxis RotationFilter => new FilterOptionPerAxis(AddrOf(0x3));
        public FilterOptionPerAxis ScaleFilter => new FilterOptionPerAxis(AddrOf(0x6));
    }

    public class FABRIKChainLink : StructProxy
    {
        public FABRIKChainLink(System.IntPtr ptr) : base(ptr) {}
    }

    public class NodeChain : StructProxy
    {
        public NodeChain(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Nodes => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<FName>
    }

    public class NodeHierarchyWithUserData : StructProxy
    {
        public NodeHierarchyWithUserData(System.IntPtr ptr) : base(ptr) {}
        public NodeHierarchyData Hierarchy => new NodeHierarchyData(AddrOf(0x8));
    }

    public class NodeHierarchyData : StructProxy
    {
        public NodeHierarchyData(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Nodes => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> Transforms => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public System.IntPtr NodeNameToIndexMapping => AddrOf(0x20); // 
    }

    public class NodeObject : StructProxy
    {
        public NodeObject(System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string ParentName => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName ParentName_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
    }

    public class TransformNoScale : StructProxy
    {
        public TransformNoScale(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x0));
        public Quat Rotation => new Quat(AddrOf(0x10));
    }

    public class AnimationDataSourceRegistry : Object
    {
        public const string UeClassName = "AnimationDataSourceRegistry";
        public AnimationDataSourceRegistry(System.IntPtr ptr) : base(ptr) {}
        public static new AnimationDataSourceRegistry FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AnimationDataSourceRegistry(p);
        public static AnimationDataSourceRegistry FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimationDataSourceRegistry(o.Pointer); }
        public static AnimationDataSourceRegistry[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimationDataSourceRegistry[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimationDataSourceRegistry(a[i].Pointer); return r; }
        public System.IntPtr DataSources => AddrOf(0x28); // 
    }

}
