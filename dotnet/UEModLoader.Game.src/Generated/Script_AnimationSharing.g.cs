// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AnimationSharing
using System;

namespace UEModLoader.Game
{
    public class TickAnimationSharingFunction : StructProxy
    {
        public TickAnimationSharingFunction(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class AnimationSharingScalability : StructProxy
    {
        public AnimationSharingScalability(global::System.IntPtr ptr) : base(ptr) {}
        public PerPlatformBool UseBlendTransitions => new PerPlatformBool(AddrOf(0x0));
        public PerPlatformFloat BlendSignificanceValue => new PerPlatformFloat(AddrOf(0x4));
        public PerPlatformInt MaximumNumberConcurrentBlends => new PerPlatformInt(AddrOf(0x8));
        public PerPlatformFloat TickSignificanceValue => new PerPlatformFloat(AddrOf(0xC));
    }

    public class PerSkeletonAnimationSharingSetup : StructProxy
    {
        public PerSkeletonAnimationSharingSetup(global::System.IntPtr ptr) : base(ptr) {}
        public Skeleton Skeleton { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Skeleton(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SkeletalMesh SkeletalMesh { get { var __p = GetAt<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new SkeletalMesh(__p); } set => SetAt(0x8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AnimSharingTransitionInstance BlendAnimBlueprint { get { var __p = GetAt<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new AnimSharingTransitionInstance(__p); } set => SetAt(0x10, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AnimSharingAdditiveInstance AdditiveAnimBlueprint { get { var __p = GetAt<global::System.IntPtr>(0x18); return __p==global::System.IntPtr.Zero?null:new AnimSharingAdditiveInstance(__p); } set => SetAt(0x18, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AnimationSharingStateProcessor StateProcessorClass { get { var __p = GetAt<global::System.IntPtr>(0x20); return __p==global::System.IntPtr.Zero?null:new AnimationSharingStateProcessor(__p); } set => SetAt(0x20, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> AnimationStates => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
    }

    public class AnimationStateEntry : StructProxy
    {
        public AnimationStateEntry(global::System.IntPtr ptr) : base(ptr) {}
        public byte State { get => GetAt<byte>(0x0); set => SetAt(0x0, value); }
        public TArray<global::System.IntPtr> AnimationSetups => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public bool bOnDemand { get => (GetAt<byte>(0x18) & 0xFF) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bAdditive { get => (GetAt<byte>(0x19) & 0xFF) != 0; set { var __b = GetAt<byte>(0x19); SetAt(0x19, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float BlendTime { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public bool bReturnToPreviousState { get => (GetAt<byte>(0x20) & 0xFF) != 0; set { var __b = GetAt<byte>(0x20); SetAt(0x20, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bSetNextState { get => (GetAt<byte>(0x21) & 0xFF) != 0; set { var __b = GetAt<byte>(0x21); SetAt(0x21, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public byte NextState { get => GetAt<byte>(0x22); set => SetAt(0x22, value); }
        public PerPlatformInt MaximumNumberOfConcurrentInstances => new PerPlatformInt(AddrOf(0x24));
        public float WiggleTimePercentage { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public bool bRequiresCurves { get => (GetAt<byte>(0x2C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2C); SetAt(0x2C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class AnimationSetup : StructProxy
    {
        public AnimationSetup(global::System.IntPtr ptr) : base(ptr) {}
        public AnimSequence AnimSequence { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new AnimSequence(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AnimSharingStateInstance AnimBlueprint { get { var __p = GetAt<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new AnimSharingStateInstance(__p); } set => SetAt(0x8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PerPlatformInt NumRandomizedInstances => new PerPlatformInt(AddrOf(0x10));
        public PerPlatformBool Enabled => new PerPlatformBool(AddrOf(0x14));
    }

    public class AnimSharingStateInstance : AnimInstance
    {
        public const string UeClassName = "AnimSharingStateInstance";
        public AnimSharingStateInstance(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimSharingStateInstance FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimSharingStateInstance(p);
        public static AnimSharingStateInstance FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimSharingStateInstance(o.Pointer); }
        public static AnimSharingStateInstance[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimSharingStateInstance[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimSharingStateInstance(a[i].Pointer); return r; }
        public AnimSequence AnimationToPlay { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new AnimSequence(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float PermutationTimeOffset { get => GetAt<float>(0x270); set => SetAt(0x270, value); }
        public float PlayRate { get => GetAt<float>(0x274); set => SetAt(0x274, value); }
        public bool bStateBool { get => Native.GetPropBool(Pointer, "bStateBool"); set => Native.SetPropBool(Pointer, "bStateBool", value); }
        public AnimSharingInstance Instance { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new AnimSharingInstance(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x56F4BD4 — hookable via Hooks.InstallAt(NativeFunc_GetInstancedActors).</summary>
        public static global::System.IntPtr NativeFunc_GetInstancedActors => Memory.ModuleBase() + 0x56F4BD4;
        public void GetInstancedActors(global::System.IntPtr Actors)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, Actors);
            CallRaw("GetInstancedActors", __pb.Bytes);
        }
    }

    public class AnimSharingTransitionInstance : AnimInstance
    {
        public const string UeClassName = "AnimSharingTransitionInstance";
        public AnimSharingTransitionInstance(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimSharingTransitionInstance FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimSharingTransitionInstance(p);
        public static AnimSharingTransitionInstance FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimSharingTransitionInstance(o.Pointer); }
        public static AnimSharingTransitionInstance[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimSharingTransitionInstance[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimSharingTransitionInstance(a[i].Pointer); return r; }
        public SkeletalMeshComponent FromComponent { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SkeletalMeshComponent ToComponent { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float BlendTime { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public bool bBlendBool { get => Native.GetPropBool(Pointer, "bBlendBool"); set => Native.SetPropBool(Pointer, "bBlendBool", value); }
    }

    public class AnimSharingAdditiveInstance : AnimInstance
    {
        public const string UeClassName = "AnimSharingAdditiveInstance";
        public AnimSharingAdditiveInstance(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimSharingAdditiveInstance FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimSharingAdditiveInstance(p);
        public static AnimSharingAdditiveInstance FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimSharingAdditiveInstance(o.Pointer); }
        public static AnimSharingAdditiveInstance[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimSharingAdditiveInstance[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimSharingAdditiveInstance(a[i].Pointer); return r; }
        public SkeletalMeshComponent BaseComponent { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AnimSequence AdditiveAnimation { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new AnimSequence(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float alpha { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public bool bStateBool { get => Native.GetPropBool(Pointer, "bStateBool"); set => Native.SetPropBool(Pointer, "bStateBool", value); }
    }

    public class AnimSharingInstance : Object
    {
        public const string UeClassName = "AnimSharingInstance";
        public AnimSharingInstance(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimSharingInstance FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimSharingInstance(p);
        public static AnimSharingInstance FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimSharingInstance(o.Pointer); }
        public static AnimSharingInstance[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimSharingInstance[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimSharingInstance(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> RegisteredActors => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<UObject*>
        public AnimationSharingStateProcessor StateProcessor { get { var __p = GetAt<global::System.IntPtr>(0xA8); return __p==global::System.IntPtr.Zero?null:new AnimationSharingStateProcessor(__p); } set => SetAt(0xA8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> UsedAnimationSequences => new TArray<global::System.IntPtr>(AddrOf(0xE8)); // TArray<UObject*>
        public Enum StateEnum { get { var __p = GetAt<global::System.IntPtr>(0x108); return __p==global::System.IntPtr.Zero?null:new Enum(__p); } set => SetAt(0x108, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor SharingActor { get { var __p = GetAt<global::System.IntPtr>(0x110); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x110, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class AnimationSharingManager : Object
    {
        public const string UeClassName = "AnimationSharingManager";
        public AnimationSharingManager(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimationSharingManager FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimationSharingManager(p);
        public static AnimationSharingManager FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimationSharingManager(o.Pointer); }
        public static AnimationSharingManager[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimationSharingManager[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimationSharingManager(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Skeletons => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<UObject*>
        public TArray<global::System.IntPtr> PerSkeletonData => new TArray<global::System.IntPtr>(AddrOf(0x38)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x56F644C — hookable via Hooks.InstallAt(NativeFunc_RegisterActorWithSkeletonBP).</summary>
        public static global::System.IntPtr NativeFunc_RegisterActorWithSkeletonBP => Memory.ModuleBase() + 0x56F644C;
        public void RegisterActorWithSkeletonBP(Actor InActor, Skeleton SharingSkeleton)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, InActor);
            __pb.SetObject(0x8, SharingSkeleton);
            CallRaw("RegisterActorWithSkeletonBP", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56F6618 — hookable via Hooks.InstallAt(NativeFunc_GetAnimationSharingManager).</summary>
        public static global::System.IntPtr NativeFunc_GetAnimationSharingManager => Memory.ModuleBase() + 0x56F6618;
        public AnimationSharingManager GetAnimationSharingManager(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("GetAnimationSharingManager", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new AnimationSharingManager(__p); }
        }
        /// <summary>[Native] thunk RVA 0x56F6530 — hookable via Hooks.InstallAt(NativeFunc_CreateAnimationSharingManager).</summary>
        public static global::System.IntPtr NativeFunc_CreateAnimationSharingManager => Memory.ModuleBase() + 0x56F6530;
        public bool CreateAnimationSharingManager(Object WorldContextObject, AnimationSharingSetup Setup)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, Setup);
            CallRaw("CreateAnimationSharingManager", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56F6414 — hookable via Hooks.InstallAt(NativeFunc_AnimationSharingEnabled).</summary>
        public static global::System.IntPtr NativeFunc_AnimationSharingEnabled => Memory.ModuleBase() + 0x56F6414;
        public bool AnimationSharingEnabled()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("AnimationSharingEnabled", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class AnimationSharingSetup : Object
    {
        public const string UeClassName = "AnimationSharingSetup";
        public AnimationSharingSetup(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimationSharingSetup FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimationSharingSetup(p);
        public static AnimationSharingSetup FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimationSharingSetup(o.Pointer); }
        public static AnimationSharingSetup[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimationSharingSetup[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimationSharingSetup(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> SkeletonSetups => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public AnimationSharingScalability ScalabilitySettings => new AnimationSharingScalability(AddrOf(0x38));
    }

    public class AnimationSharingStateProcessor : Object
    {
        public const string UeClassName = "AnimationSharingStateProcessor";
        public AnimationSharingStateProcessor(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnimationSharingStateProcessor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnimationSharingStateProcessor(p);
        public static AnimationSharingStateProcessor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnimationSharingStateProcessor(o.Pointer); }
        public static AnimationSharingStateProcessor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnimationSharingStateProcessor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnimationSharingStateProcessor(a[i].Pointer); return r; }
        public Enum AnimationStateEnum { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new Enum(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x56F8144 — hookable via Hooks.InstallAt(NativeFunc_ProcessActorState).</summary>
        public static global::System.IntPtr NativeFunc_ProcessActorState => Memory.ModuleBase() + 0x56F8144;
        public void ProcessActorState(int OutState, Actor InActor, byte currentState, byte OnDemandState, bool bShouldProcess)
        {
            var __pb = new ParamBuffer(19);
            __pb.Set(0x0, OutState);
            __pb.SetObject(0x8, InActor);
            __pb.Set(0x10, currentState);
            __pb.Set(0x11, OnDemandState);
            __pb.Set<byte>(0x12, (byte)(bShouldProcess?1:0));
            CallRaw("ProcessActorState", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56F8108 — hookable via Hooks.InstallAt(NativeFunc_GetAnimationStateEnum).</summary>
        public static global::System.IntPtr NativeFunc_GetAnimationStateEnum => Memory.ModuleBase() + 0x56F8108;
        public Enum GetAnimationStateEnum()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetAnimationStateEnum", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Enum(__p); }
        }
    }

}
