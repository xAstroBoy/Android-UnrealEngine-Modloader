// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/FieldSystemEngine
using System;

namespace UEModLoader.Game
{
    public class FieldSystemActor : Actor
    {
        public const string UeClassName = "FieldSystemActor";
        public FieldSystemActor(System.IntPtr ptr) : base(ptr) {}
        public static new FieldSystemActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldSystemActor(p);
        public static FieldSystemActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldSystemActor(o.Pointer); }
        public static FieldSystemActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldSystemActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldSystemActor(a[i].Pointer); return r; }
        public FieldSystemComponent FieldSystemComponent { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new FieldSystemComponent(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class FieldSystem : Object
    {
        public const string UeClassName = "FieldSystem";
        public FieldSystem(System.IntPtr ptr) : base(ptr) {}
        public static new FieldSystem FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldSystem(p);
        public static FieldSystem FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldSystem(o.Pointer); }
        public static FieldSystem[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldSystem[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldSystem(a[i].Pointer); return r; }
    }

    public class FieldSystemComponent : PrimitiveComponent
    {
        public const string UeClassName = "FieldSystemComponent";
        public FieldSystemComponent(System.IntPtr ptr) : base(ptr) {}
        public static new FieldSystemComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldSystemComponent(p);
        public static FieldSystemComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldSystemComponent(o.Pointer); }
        public static FieldSystemComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldSystemComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldSystemComponent(a[i].Pointer); return r; }
        public FieldSystem FieldSystem { get { var __p = GetAt<System.IntPtr>(0x408); return __p==System.IntPtr.Zero?null:new FieldSystem(__p); } set => SetAt(0x408, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> SupportedSolvers => new TArray<System.IntPtr>(AddrOf(0x420)); // TArray<TSoftObjectPtr>
        /// <summary>[Native] thunk RVA 0x92425E0 — hookable via Hooks.InstallAt(NativeFunc_ResetFieldSystem).</summary>
        public static System.IntPtr NativeFunc_ResetFieldSystem => Memory.ModuleBase() + 0x92425E0;
        public void ResetFieldSystem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetFieldSystem", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9242924 — hookable via Hooks.InstallAt(NativeFunc_ApplyUniformVectorFalloffForce).</summary>
        public static System.IntPtr NativeFunc_ApplyUniformVectorFalloffForce => Memory.ModuleBase() + 0x9242924;
        public void ApplyUniformVectorFalloffForce(bool Enabled, Vector Position, Vector Direction, float Radius, float Magnitude)
        {
            var __pb = new ParamBuffer(36);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            __pb.Set<System.IntPtr>(0x4, Position);
            __pb.Set<System.IntPtr>(0x10, Direction);
            __pb.Set(0x1C, Radius);
            __pb.Set(0x20, Magnitude);
            CallRaw("ApplyUniformVectorFalloffForce", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x924276C — hookable via Hooks.InstallAt(NativeFunc_ApplyStrainField).</summary>
        public static System.IntPtr NativeFunc_ApplyStrainField => Memory.ModuleBase() + 0x924276C;
        public void ApplyStrainField(bool Enabled, Vector Position, float Radius, float Magnitude, int Iterations)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            __pb.Set<System.IntPtr>(0x4, Position);
            __pb.Set(0x10, Radius);
            __pb.Set(0x14, Magnitude);
            __pb.Set(0x18, Iterations);
            CallRaw("ApplyStrainField", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9242D80 — hookable via Hooks.InstallAt(NativeFunc_ApplyStayDynamicField).</summary>
        public static System.IntPtr NativeFunc_ApplyStayDynamicField => Memory.ModuleBase() + 0x9242D80;
        public void ApplyStayDynamicField(bool Enabled, Vector Position, float Radius)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            __pb.Set<System.IntPtr>(0x4, Position);
            __pb.Set(0x10, Radius);
            CallRaw("ApplyStayDynamicField", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9242AD8 — hookable via Hooks.InstallAt(NativeFunc_ApplyRadialVectorFalloffForce).</summary>
        public static System.IntPtr NativeFunc_ApplyRadialVectorFalloffForce => Memory.ModuleBase() + 0x9242AD8;
        public void ApplyRadialVectorFalloffForce(bool Enabled, Vector Position, float Radius, float Magnitude)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            __pb.Set<System.IntPtr>(0x4, Position);
            __pb.Set(0x10, Radius);
            __pb.Set(0x14, Magnitude);
            CallRaw("ApplyRadialVectorFalloffForce", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9242C4C — hookable via Hooks.InstallAt(NativeFunc_ApplyRadialForce).</summary>
        public static System.IntPtr NativeFunc_ApplyRadialForce => Memory.ModuleBase() + 0x9242C4C;
        public void ApplyRadialForce(bool Enabled, Vector Position, float Magnitude)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            __pb.Set<System.IntPtr>(0x4, Position);
            __pb.Set(0x10, Magnitude);
            CallRaw("ApplyRadialForce", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92425F4 — hookable via Hooks.InstallAt(NativeFunc_ApplyPhysicsField).</summary>
        public static System.IntPtr NativeFunc_ApplyPhysicsField => Memory.ModuleBase() + 0x92425F4;
        public void ApplyPhysicsField(bool Enabled, byte Target, FieldSystemMetaData MetaData, FieldNodeBase Field)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            __pb.Set(0x1, Target);
            __pb.SetObject(0x8, MetaData);
            __pb.SetObject(0x10, Field);
            CallRaw("ApplyPhysicsField", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9242EB4 — hookable via Hooks.InstallAt(NativeFunc_ApplyLinearForce).</summary>
        public static System.IntPtr NativeFunc_ApplyLinearForce => Memory.ModuleBase() + 0x9242EB4;
        public void ApplyLinearForce(bool Enabled, Vector Direction, float Magnitude)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            __pb.Set<System.IntPtr>(0x4, Direction);
            __pb.Set(0x10, Magnitude);
            CallRaw("ApplyLinearForce", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x9242468 — hookable via Hooks.InstallAt(NativeFunc_AddFieldCommand).</summary>
        public static System.IntPtr NativeFunc_AddFieldCommand => Memory.ModuleBase() + 0x9242468;
        public void AddFieldCommand(bool Enabled, byte Target, FieldSystemMetaData MetaData, FieldNodeBase Field)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            __pb.Set(0x1, Target);
            __pb.SetObject(0x8, MetaData);
            __pb.SetObject(0x10, Field);
            CallRaw("AddFieldCommand", __pb.Bytes);
        }
    }

    public class FieldSystemMetaData : ActorComponent
    {
        public const string UeClassName = "FieldSystemMetaData";
        public FieldSystemMetaData(System.IntPtr ptr) : base(ptr) {}
        public static new FieldSystemMetaData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldSystemMetaData(p);
        public static FieldSystemMetaData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldSystemMetaData(o.Pointer); }
        public static FieldSystemMetaData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldSystemMetaData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldSystemMetaData(a[i].Pointer); return r; }
    }

    public class FieldSystemMetaDataIteration : FieldSystemMetaData
    {
        public const string UeClassName = "FieldSystemMetaDataIteration";
        public FieldSystemMetaDataIteration(System.IntPtr ptr) : base(ptr) {}
        public static new FieldSystemMetaDataIteration FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldSystemMetaDataIteration(p);
        public static FieldSystemMetaDataIteration FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldSystemMetaDataIteration(o.Pointer); }
        public static FieldSystemMetaDataIteration[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldSystemMetaDataIteration[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldSystemMetaDataIteration(a[i].Pointer); return r; }
        public int Iterations { get => GetAt<int>(0xB0); set => SetAt(0xB0, value); }
        /// <summary>[Native] thunk RVA 0x92441A4 — hookable via Hooks.InstallAt(NativeFunc_SetMetaDataIteration).</summary>
        public static System.IntPtr NativeFunc_SetMetaDataIteration => Memory.ModuleBase() + 0x92441A4;
        public FieldSystemMetaDataIteration SetMetaDataIteration(int Iterations)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Iterations);
            CallRaw("SetMetaDataIteration", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new FieldSystemMetaDataIteration(__p); }
        }
    }

    public class FieldSystemMetaDataProcessingResolution : FieldSystemMetaData
    {
        public const string UeClassName = "FieldSystemMetaDataProcessingResolution";
        public FieldSystemMetaDataProcessingResolution(System.IntPtr ptr) : base(ptr) {}
        public static new FieldSystemMetaDataProcessingResolution FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldSystemMetaDataProcessingResolution(p);
        public static FieldSystemMetaDataProcessingResolution FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldSystemMetaDataProcessingResolution(o.Pointer); }
        public static FieldSystemMetaDataProcessingResolution[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldSystemMetaDataProcessingResolution[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldSystemMetaDataProcessingResolution(a[i].Pointer); return r; }
        public byte ResolutionType { get => GetAt<byte>(0xB0); set => SetAt(0xB0, value); }
        /// <summary>[Native] thunk RVA 0x9244724 — hookable via Hooks.InstallAt(NativeFunc_SetMetaDataaProcessingResolutionType).</summary>
        public static System.IntPtr NativeFunc_SetMetaDataaProcessingResolutionType => Memory.ModuleBase() + 0x9244724;
        public FieldSystemMetaDataProcessingResolution SetMetaDataaProcessingResolutionType(byte ResolutionType)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, ResolutionType);
            CallRaw("SetMetaDataaProcessingResolutionType", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new FieldSystemMetaDataProcessingResolution(__p); }
        }
    }

    public class FieldNodeBase : ActorComponent
    {
        public const string UeClassName = "FieldNodeBase";
        public FieldNodeBase(System.IntPtr ptr) : base(ptr) {}
        public static new FieldNodeBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldNodeBase(p);
        public static FieldNodeBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldNodeBase(o.Pointer); }
        public static FieldNodeBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldNodeBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldNodeBase(a[i].Pointer); return r; }
    }

    public class FieldNodeInt : FieldNodeBase
    {
        public const string UeClassName = "FieldNodeInt";
        public FieldNodeInt(System.IntPtr ptr) : base(ptr) {}
        public static new FieldNodeInt FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldNodeInt(p);
        public static FieldNodeInt FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldNodeInt(o.Pointer); }
        public static FieldNodeInt[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldNodeInt[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldNodeInt(a[i].Pointer); return r; }
    }

    public class FieldNodeFloat : FieldNodeBase
    {
        public const string UeClassName = "FieldNodeFloat";
        public FieldNodeFloat(System.IntPtr ptr) : base(ptr) {}
        public static new FieldNodeFloat FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldNodeFloat(p);
        public static FieldNodeFloat FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldNodeFloat(o.Pointer); }
        public static FieldNodeFloat[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldNodeFloat[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldNodeFloat(a[i].Pointer); return r; }
    }

    public class FieldNodeVector : FieldNodeBase
    {
        public const string UeClassName = "FieldNodeVector";
        public FieldNodeVector(System.IntPtr ptr) : base(ptr) {}
        public static new FieldNodeVector FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FieldNodeVector(p);
        public static FieldNodeVector FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FieldNodeVector(o.Pointer); }
        public static FieldNodeVector[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FieldNodeVector[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FieldNodeVector(a[i].Pointer); return r; }
    }

    public class UniformInteger : FieldNodeInt
    {
        public const string UeClassName = "UniformInteger";
        public UniformInteger(System.IntPtr ptr) : base(ptr) {}
        public static new UniformInteger FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UniformInteger(p);
        public static UniformInteger FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UniformInteger(o.Pointer); }
        public static UniformInteger[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UniformInteger[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UniformInteger(a[i].Pointer); return r; }
        public int Magnitude { get => GetAt<int>(0xB0); set => SetAt(0xB0, value); }
        /// <summary>[Native] thunk RVA 0x9245BE4 — hookable via Hooks.InstallAt(NativeFunc_SetUniformInteger).</summary>
        public static System.IntPtr NativeFunc_SetUniformInteger => Memory.ModuleBase() + 0x9245BE4;
        public UniformInteger SetUniformInteger(int Magnitude)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Magnitude);
            CallRaw("SetUniformInteger", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new UniformInteger(__p); }
        }
    }

    public class RadialIntMask : FieldNodeInt
    {
        public const string UeClassName = "RadialIntMask";
        public RadialIntMask(System.IntPtr ptr) : base(ptr) {}
        public static new RadialIntMask FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RadialIntMask(p);
        public static RadialIntMask FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RadialIntMask(o.Pointer); }
        public static RadialIntMask[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RadialIntMask[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RadialIntMask(a[i].Pointer); return r; }
        public float Radius { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public Vector Position => new Vector(AddrOf(0xB4));
        public int InteriorValue { get => GetAt<int>(0xC0); set => SetAt(0xC0, value); }
        public int ExteriorValue { get => GetAt<int>(0xC4); set => SetAt(0xC4, value); }
        public byte SetMaskCondition { get => GetAt<byte>(0xC8); set => SetAt(0xC8, value); }
        /// <summary>[Native] thunk RVA 0x924616C — hookable via Hooks.InstallAt(NativeFunc_SetRadialIntMask).</summary>
        public static System.IntPtr NativeFunc_SetRadialIntMask => Memory.ModuleBase() + 0x924616C;
        public RadialIntMask SetRadialIntMask(float Radius, Vector Position, int InteriorValue, int ExteriorValue, byte SetMaskConditionIn)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set(0x0, Radius);
            __pb.Set<System.IntPtr>(0x4, Position);
            __pb.Set(0x10, InteriorValue);
            __pb.Set(0x14, ExteriorValue);
            __pb.Set(0x18, SetMaskConditionIn);
            CallRaw("SetRadialIntMask", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new RadialIntMask(__p); }
        }
    }

    public class UniformScalar : FieldNodeFloat
    {
        public const string UeClassName = "UniformScalar";
        public UniformScalar(System.IntPtr ptr) : base(ptr) {}
        public static new UniformScalar FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UniformScalar(p);
        public static UniformScalar FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UniformScalar(o.Pointer); }
        public static UniformScalar[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UniformScalar[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UniformScalar(a[i].Pointer); return r; }
        public float Magnitude { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        /// <summary>[Native] thunk RVA 0x9246808 — hookable via Hooks.InstallAt(NativeFunc_SetUniformScalar).</summary>
        public static System.IntPtr NativeFunc_SetUniformScalar => Memory.ModuleBase() + 0x9246808;
        public UniformScalar SetUniformScalar(float Magnitude)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Magnitude);
            CallRaw("SetUniformScalar", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new UniformScalar(__p); }
        }
    }

    public class RadialFalloff : FieldNodeFloat
    {
        public const string UeClassName = "RadialFalloff";
        public RadialFalloff(System.IntPtr ptr) : base(ptr) {}
        public static new RadialFalloff FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RadialFalloff(p);
        public static RadialFalloff FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RadialFalloff(o.Pointer); }
        public static RadialFalloff[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RadialFalloff[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RadialFalloff(a[i].Pointer); return r; }
        public float Magnitude { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public float MinRange { get => GetAt<float>(0xB4); set => SetAt(0xB4, value); }
        public float MaxRange { get => GetAt<float>(0xB8); set => SetAt(0xB8, value); }
        public float Default { get => GetAt<float>(0xBC); set => SetAt(0xBC, value); }
        public float Radius { get => GetAt<float>(0xC0); set => SetAt(0xC0, value); }
        public Vector Position => new Vector(AddrOf(0xC4));
        public byte Falloff { get => GetAt<byte>(0xD0); set => SetAt(0xD0, value); }
        /// <summary>[Native] thunk RVA 0x9246D94 — hookable via Hooks.InstallAt(NativeFunc_SetRadialFalloff).</summary>
        public static System.IntPtr NativeFunc_SetRadialFalloff => Memory.ModuleBase() + 0x9246D94;
        public RadialFalloff SetRadialFalloff(float Magnitude, float MinRange, float MaxRange, float Default, float Radius, Vector Position, byte Falloff)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set(0x0, Magnitude);
            __pb.Set(0x4, MinRange);
            __pb.Set(0x8, MaxRange);
            __pb.Set(0xC, Default);
            __pb.Set(0x10, Radius);
            __pb.Set<System.IntPtr>(0x14, Position);
            __pb.Set(0x20, Falloff);
            CallRaw("SetRadialFalloff", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new RadialFalloff(__p); }
        }
    }

    public class PlaneFalloff : FieldNodeFloat
    {
        public const string UeClassName = "PlaneFalloff";
        public PlaneFalloff(System.IntPtr ptr) : base(ptr) {}
        public static new PlaneFalloff FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PlaneFalloff(p);
        public static PlaneFalloff FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlaneFalloff(o.Pointer); }
        public static PlaneFalloff[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlaneFalloff[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlaneFalloff(a[i].Pointer); return r; }
        public float Magnitude { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public float MinRange { get => GetAt<float>(0xB4); set => SetAt(0xB4, value); }
        public float MaxRange { get => GetAt<float>(0xB8); set => SetAt(0xB8, value); }
        public float Default { get => GetAt<float>(0xBC); set => SetAt(0xBC, value); }
        public float Distance { get => GetAt<float>(0xC0); set => SetAt(0xC0, value); }
        public Vector Position => new Vector(AddrOf(0xC4));
        public Vector Normal => new Vector(AddrOf(0xD0));
        public byte Falloff { get => GetAt<byte>(0xDC); set => SetAt(0xDC, value); }
        /// <summary>[Native] thunk RVA 0x92474C8 — hookable via Hooks.InstallAt(NativeFunc_SetPlaneFalloff).</summary>
        public static System.IntPtr NativeFunc_SetPlaneFalloff => Memory.ModuleBase() + 0x92474C8;
        public PlaneFalloff SetPlaneFalloff(float Magnitude, float MinRange, float MaxRange, float Default, float Distance, Vector Position, Vector Normal, byte Falloff)
        {
            var __pb = new ParamBuffer(56);
            __pb.Set(0x0, Magnitude);
            __pb.Set(0x4, MinRange);
            __pb.Set(0x8, MaxRange);
            __pb.Set(0xC, Default);
            __pb.Set(0x10, Distance);
            __pb.Set<System.IntPtr>(0x14, Position);
            __pb.Set<System.IntPtr>(0x20, Normal);
            __pb.Set(0x2C, Falloff);
            CallRaw("SetPlaneFalloff", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new PlaneFalloff(__p); }
        }
    }

    public class BoxFalloff : FieldNodeFloat
    {
        public const string UeClassName = "BoxFalloff";
        public BoxFalloff(System.IntPtr ptr) : base(ptr) {}
        public static new BoxFalloff FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BoxFalloff(p);
        public static BoxFalloff FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BoxFalloff(o.Pointer); }
        public static BoxFalloff[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BoxFalloff[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BoxFalloff(a[i].Pointer); return r; }
        public float Magnitude { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public float MinRange { get => GetAt<float>(0xB4); set => SetAt(0xB4, value); }
        public float MaxRange { get => GetAt<float>(0xB8); set => SetAt(0xB8, value); }
        public float Default { get => GetAt<float>(0xBC); set => SetAt(0xBC, value); }
        public Transform Transform => new Transform(AddrOf(0xC0));
        public byte Falloff { get => GetAt<byte>(0xF0); set => SetAt(0xF0, value); }
        /// <summary>[Native] thunk RVA 0x9247C50 — hookable via Hooks.InstallAt(NativeFunc_SetBoxFalloff).</summary>
        public static System.IntPtr NativeFunc_SetBoxFalloff => Memory.ModuleBase() + 0x9247C50;
        public BoxFalloff SetBoxFalloff(float Magnitude, float MinRange, float MaxRange, float Default, Transform Transform, byte Falloff)
        {
            var __pb = new ParamBuffer(80);
            __pb.Set(0x0, Magnitude);
            __pb.Set(0x4, MinRange);
            __pb.Set(0x8, MaxRange);
            __pb.Set(0xC, Default);
            __pb.Set<System.IntPtr>(0x10, Transform);
            __pb.Set(0x40, Falloff);
            CallRaw("SetBoxFalloff", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x48); return __p==System.IntPtr.Zero?null:new BoxFalloff(__p); }
        }
    }

    public class NoiseField : FieldNodeFloat
    {
        public const string UeClassName = "NoiseField";
        public NoiseField(System.IntPtr ptr) : base(ptr) {}
        public static new NoiseField FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new NoiseField(p);
        public static NoiseField FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NoiseField(o.Pointer); }
        public static NoiseField[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NoiseField[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NoiseField(a[i].Pointer); return r; }
        public float MinRange { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public float MaxRange { get => GetAt<float>(0xB4); set => SetAt(0xB4, value); }
        public Transform Transform => new Transform(AddrOf(0xC0));
        /// <summary>[Native] thunk RVA 0x92483A8 — hookable via Hooks.InstallAt(NativeFunc_SetNoiseField).</summary>
        public static System.IntPtr NativeFunc_SetNoiseField => Memory.ModuleBase() + 0x92483A8;
        public NoiseField SetNoiseField(float MinRange, float MaxRange, Transform Transform)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set(0x0, MinRange);
            __pb.Set(0x4, MaxRange);
            __pb.Set<System.IntPtr>(0x10, Transform);
            CallRaw("SetNoiseField", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x40); return __p==System.IntPtr.Zero?null:new NoiseField(__p); }
        }
    }

    public class UniformVector : FieldNodeVector
    {
        public const string UeClassName = "UniformVector";
        public UniformVector(System.IntPtr ptr) : base(ptr) {}
        public static new UniformVector FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UniformVector(p);
        public static UniformVector FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UniformVector(o.Pointer); }
        public static UniformVector[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UniformVector[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UniformVector(a[i].Pointer); return r; }
        public float Magnitude { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public Vector Direction => new Vector(AddrOf(0xB4));
        /// <summary>[Native] thunk RVA 0x9248A44 — hookable via Hooks.InstallAt(NativeFunc_SetUniformVector).</summary>
        public static System.IntPtr NativeFunc_SetUniformVector => Memory.ModuleBase() + 0x9248A44;
        public UniformVector SetUniformVector(float Magnitude, Vector Direction)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Magnitude);
            __pb.Set<System.IntPtr>(0x4, Direction);
            CallRaw("SetUniformVector", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new UniformVector(__p); }
        }
    }

    public class RadialVector : FieldNodeVector
    {
        public const string UeClassName = "RadialVector";
        public RadialVector(System.IntPtr ptr) : base(ptr) {}
        public static new RadialVector FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RadialVector(p);
        public static RadialVector FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RadialVector(o.Pointer); }
        public static RadialVector[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RadialVector[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RadialVector(a[i].Pointer); return r; }
        public float Magnitude { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public Vector Position => new Vector(AddrOf(0xB4));
        /// <summary>[Native] thunk RVA 0x9249010 — hookable via Hooks.InstallAt(NativeFunc_SetRadialVector).</summary>
        public static System.IntPtr NativeFunc_SetRadialVector => Memory.ModuleBase() + 0x9249010;
        public RadialVector SetRadialVector(float Magnitude, Vector Position)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Magnitude);
            __pb.Set<System.IntPtr>(0x4, Position);
            CallRaw("SetRadialVector", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new RadialVector(__p); }
        }
    }

    public class RandomVector : FieldNodeVector
    {
        public const string UeClassName = "RandomVector";
        public RandomVector(System.IntPtr ptr) : base(ptr) {}
        public static new RandomVector FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RandomVector(p);
        public static RandomVector FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RandomVector(o.Pointer); }
        public static RandomVector[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RandomVector[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RandomVector(a[i].Pointer); return r; }
        public float Magnitude { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        /// <summary>[Native] thunk RVA 0x92495DC — hookable via Hooks.InstallAt(NativeFunc_SetRandomVector).</summary>
        public static System.IntPtr NativeFunc_SetRandomVector => Memory.ModuleBase() + 0x92495DC;
        public RandomVector SetRandomVector(float Magnitude)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Magnitude);
            CallRaw("SetRandomVector", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new RandomVector(__p); }
        }
    }

    public class OperatorField : FieldNodeBase
    {
        public const string UeClassName = "OperatorField";
        public OperatorField(System.IntPtr ptr) : base(ptr) {}
        public static new OperatorField FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OperatorField(p);
        public static OperatorField FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OperatorField(o.Pointer); }
        public static OperatorField[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OperatorField[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OperatorField(a[i].Pointer); return r; }
        public float Magnitude { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public FieldNodeBase RightField { get { var __p = GetAt<System.IntPtr>(0xB8); return __p==System.IntPtr.Zero?null:new FieldNodeBase(__p); } set => SetAt(0xB8, value?.Pointer ?? System.IntPtr.Zero); }
        public FieldNodeBase LeftField { get { var __p = GetAt<System.IntPtr>(0xC0); return __p==System.IntPtr.Zero?null:new FieldNodeBase(__p); } set => SetAt(0xC0, value?.Pointer ?? System.IntPtr.Zero); }
        public byte Operation { get => GetAt<byte>(0xC8); set => SetAt(0xC8, value); }
        /// <summary>[Native] thunk RVA 0x9249B68 — hookable via Hooks.InstallAt(NativeFunc_SetOperatorField).</summary>
        public static System.IntPtr NativeFunc_SetOperatorField => Memory.ModuleBase() + 0x9249B68;
        public OperatorField SetOperatorField(float Magnitude, FieldNodeBase RightField, FieldNodeBase LeftField, byte Operation)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set(0x0, Magnitude);
            __pb.SetObject(0x8, RightField);
            __pb.SetObject(0x10, LeftField);
            __pb.Set(0x18, Operation);
            CallRaw("SetOperatorField", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new OperatorField(__p); }
        }
    }

    public class ToIntegerField : FieldNodeInt
    {
        public const string UeClassName = "ToIntegerField";
        public ToIntegerField(System.IntPtr ptr) : base(ptr) {}
        public static new ToIntegerField FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ToIntegerField(p);
        public static ToIntegerField FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ToIntegerField(o.Pointer); }
        public static ToIntegerField[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ToIntegerField[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ToIntegerField(a[i].Pointer); return r; }
        public FieldNodeFloat FloatField { get { var __p = GetAt<System.IntPtr>(0xB0); return __p==System.IntPtr.Zero?null:new FieldNodeFloat(__p); } set => SetAt(0xB0, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x924A1C4 — hookable via Hooks.InstallAt(NativeFunc_SetToIntegerField).</summary>
        public static System.IntPtr NativeFunc_SetToIntegerField => Memory.ModuleBase() + 0x924A1C4;
        public ToIntegerField SetToIntegerField(FieldNodeFloat FloatField)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, FloatField);
            CallRaw("SetToIntegerField", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new ToIntegerField(__p); }
        }
    }

    public class ToFloatField : FieldNodeFloat
    {
        public const string UeClassName = "ToFloatField";
        public ToFloatField(System.IntPtr ptr) : base(ptr) {}
        public static new ToFloatField FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ToFloatField(p);
        public static ToFloatField FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ToFloatField(o.Pointer); }
        public static ToFloatField[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ToFloatField[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ToFloatField(a[i].Pointer); return r; }
        public FieldNodeInt IntField { get { var __p = GetAt<System.IntPtr>(0xB0); return __p==System.IntPtr.Zero?null:new FieldNodeInt(__p); } set => SetAt(0xB0, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x924A74C — hookable via Hooks.InstallAt(NativeFunc_SetToFloatField).</summary>
        public static System.IntPtr NativeFunc_SetToFloatField => Memory.ModuleBase() + 0x924A74C;
        public ToFloatField SetToFloatField(FieldNodeInt IntegerField)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, IntegerField);
            CallRaw("SetToFloatField", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new ToFloatField(__p); }
        }
    }

    public class CullingField : FieldNodeBase
    {
        public const string UeClassName = "CullingField";
        public CullingField(System.IntPtr ptr) : base(ptr) {}
        public static new CullingField FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CullingField(p);
        public static CullingField FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CullingField(o.Pointer); }
        public static CullingField[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CullingField[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CullingField(a[i].Pointer); return r; }
        public FieldNodeBase Culling { get { var __p = GetAt<System.IntPtr>(0xB0); return __p==System.IntPtr.Zero?null:new FieldNodeBase(__p); } set => SetAt(0xB0, value?.Pointer ?? System.IntPtr.Zero); }
        public FieldNodeBase Field { get { var __p = GetAt<System.IntPtr>(0xB8); return __p==System.IntPtr.Zero?null:new FieldNodeBase(__p); } set => SetAt(0xB8, value?.Pointer ?? System.IntPtr.Zero); }
        public byte Operation { get => GetAt<byte>(0xC0); set => SetAt(0xC0, value); }
        /// <summary>[Native] thunk RVA 0x924ACD4 — hookable via Hooks.InstallAt(NativeFunc_SetCullingField).</summary>
        public static System.IntPtr NativeFunc_SetCullingField => Memory.ModuleBase() + 0x924ACD4;
        public CullingField SetCullingField(FieldNodeBase Culling, FieldNodeBase Field, byte Operation)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, Culling);
            __pb.SetObject(0x8, Field);
            __pb.Set(0x10, Operation);
            CallRaw("SetCullingField", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new CullingField(__p); }
        }
    }

    public class ReturnResultsTerminal : FieldNodeBase
    {
        public const string UeClassName = "ReturnResultsTerminal";
        public ReturnResultsTerminal(System.IntPtr ptr) : base(ptr) {}
        public static new ReturnResultsTerminal FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ReturnResultsTerminal(p);
        public static ReturnResultsTerminal FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ReturnResultsTerminal(o.Pointer); }
        public static ReturnResultsTerminal[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ReturnResultsTerminal[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ReturnResultsTerminal(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x924B2E4 — hookable via Hooks.InstallAt(NativeFunc_SetReturnResultsTerminal).</summary>
        public static System.IntPtr NativeFunc_SetReturnResultsTerminal => Memory.ModuleBase() + 0x924B2E4;
        public ReturnResultsTerminal SetReturnResultsTerminal()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("SetReturnResultsTerminal", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new ReturnResultsTerminal(__p); }
        }
    }

}
