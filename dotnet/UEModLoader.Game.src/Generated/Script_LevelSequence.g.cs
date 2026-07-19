// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/LevelSequence
using System;

namespace UEModLoader.Game
{
    public class LevelSequenceCameraSettings : StructProxy
    {
        public LevelSequenceCameraSettings(global::System.IntPtr ptr) : base(ptr) {}
        public bool bOverrideAspectRatioAxisConstraint { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public byte AspectRatioAxisConstraint { get => GetAt<byte>(0x1); set => SetAt(0x1, value); }
    }

    public class BoundActorProxy : StructProxy
    {
        public BoundActorProxy(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class LevelSequenceBindingReferences : StructProxy
    {
        public LevelSequenceBindingReferences(global::System.IntPtr ptr) : base(ptr) {}
        public global::System.IntPtr BindingIdToReferences => AddrOf(0x0); // 
        public global::System.IntPtr AnimSequenceInstances => AddrOf(0x50); // 
    }

    public class LevelSequenceBindingReferenceArray : StructProxy
    {
        public LevelSequenceBindingReferenceArray(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> References => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class LevelSequenceBindingReference : StructProxy
    {
        public LevelSequenceBindingReference(global::System.IntPtr ptr) : base(ptr) {}
        public string PackageName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public SoftObjectPath ExternalObjectPath => new SoftObjectPath(AddrOf(0x10));
        public string ObjectPath => Native.ReadFStringAt(AddrOf(0x28)); // FString
    }

    public class LevelSequenceObjectReferenceMap : StructProxy
    {
        public LevelSequenceObjectReferenceMap(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class LevelSequenceLegacyObjectReference : StructProxy
    {
        public LevelSequenceLegacyObjectReference(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class LevelSequenceObject : StructProxy
    {
        public LevelSequenceObject(global::System.IntPtr ptr) : base(ptr) {}
        public Object ObjectOrOwner { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string ComponentName => Native.ReadFStringAt(AddrOf(0x20)); // FString
        public Object CachedComponent { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class LevelSequencePlayerSnapshot : StructProxy
    {
        public LevelSequencePlayerSnapshot(global::System.IntPtr ptr) : base(ptr) {}
        public string MasterName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public QualifiedFrameTime MasterTime => new QualifiedFrameTime(AddrOf(0x10));
        public QualifiedFrameTime SourceTime => new QualifiedFrameTime(AddrOf(0x20));
        public string CurrentShotName => Native.ReadFStringAt(AddrOf(0x30)); // FString
        public QualifiedFrameTime CurrentShotLocalTime => new QualifiedFrameTime(AddrOf(0x40));
        public QualifiedFrameTime CurrentShotSourceTime => new QualifiedFrameTime(AddrOf(0x50));
        public string SourceTimecode => Native.ReadFStringAt(AddrOf(0x60)); // FString
        public CameraComponent CameraComponent { get { var __p = GetAt<global::System.IntPtr>(0x70); return __p==global::System.IntPtr.Zero?null:new CameraComponent(__p); } set => SetAt(0x70, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LevelSequenceSnapshotSettings Settings => new LevelSequenceSnapshotSettings(AddrOf(0x98));
        public LevelSequence ActiveShot { get { var __p = GetAt<global::System.IntPtr>(0xA8); return __p==global::System.IntPtr.Zero?null:new LevelSequence(__p); } set => SetAt(0xA8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MovieSceneSequenceID ShotID => new MovieSceneSequenceID(AddrOf(0xB0));
    }

    public class LevelSequenceSnapshotSettings : StructProxy
    {
        public LevelSequenceSnapshotSettings(global::System.IntPtr ptr) : base(ptr) {}
        public byte ZeroPadAmount { get => GetAt<byte>(0x0); set => SetAt(0x0, value); }
        public FrameRate FrameRate => new FrameRate(AddrOf(0x4));
    }

    public class DefaultLevelSequenceInstanceData : Object
    {
        public const string UeClassName = "DefaultLevelSequenceInstanceData";
        public DefaultLevelSequenceInstanceData(global::System.IntPtr ptr) : base(ptr) {}
        public static new DefaultLevelSequenceInstanceData FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DefaultLevelSequenceInstanceData(p);
        public static DefaultLevelSequenceInstanceData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DefaultLevelSequenceInstanceData(o.Pointer); }
        public static DefaultLevelSequenceInstanceData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DefaultLevelSequenceInstanceData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DefaultLevelSequenceInstanceData(a[i].Pointer); return r; }
        public Actor TransformOriginActor { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Transform TransformOrigin => new Transform(AddrOf(0x40));
    }

    public class LevelSequenceMetaData : Interface
    {
        public const string UeClassName = "LevelSequenceMetaData";
        public LevelSequenceMetaData(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelSequenceMetaData FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelSequenceMetaData(p);
        public static LevelSequenceMetaData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelSequenceMetaData(o.Pointer); }
        public static LevelSequenceMetaData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelSequenceMetaData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelSequenceMetaData(a[i].Pointer); return r; }
    }

    public class LevelSequence : MovieSceneSequence
    {
        public const string UeClassName = "LevelSequence";
        public LevelSequence(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelSequence FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelSequence(p);
        public static LevelSequence FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelSequence(o.Pointer); }
        public static LevelSequence[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelSequence[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelSequence(a[i].Pointer); return r; }
        public MovieScene MovieScene { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new MovieScene(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LevelSequenceObjectReferenceMap ObjectReferences => new LevelSequenceObjectReferenceMap(AddrOf(0x350));
        public LevelSequenceBindingReferences BindingReferences => new LevelSequenceBindingReferences(AddrOf(0x3A0));
        public global::System.IntPtr PossessedObjects => AddrOf(0x440); // 
        public Object DirectorClass { get { var __p = GetAt<global::System.IntPtr>(0x490); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x490, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x820A2A8 — hookable via Hooks.InstallAt(NativeFunc_RemoveMetaDataByClass).</summary>
        public static global::System.IntPtr NativeFunc_RemoveMetaDataByClass => Memory.ModuleBase() + 0x820A2A8;
        public void RemoveMetaDataByClass(Object InClass)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InClass);
            CallRaw("RemoveMetaDataByClass", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820A3D0 — hookable via Hooks.InstallAt(NativeFunc_FindOrAddMetaDataByClass).</summary>
        public static global::System.IntPtr NativeFunc_FindOrAddMetaDataByClass => Memory.ModuleBase() + 0x820A3D0;
        public Object FindOrAddMetaDataByClass(Object InClass)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, InClass);
            CallRaw("FindOrAddMetaDataByClass", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new Object(__p); }
        }
        /// <summary>[Native] thunk RVA 0x820A46C — hookable via Hooks.InstallAt(NativeFunc_FindMetaDataByClass).</summary>
        public static global::System.IntPtr NativeFunc_FindMetaDataByClass => Memory.ModuleBase() + 0x820A46C;
        public Object FindMetaDataByClass(Object InClass)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, InClass);
            CallRaw("FindMetaDataByClass", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new Object(__p); }
        }
        /// <summary>[Native] thunk RVA 0x820A334 — hookable via Hooks.InstallAt(NativeFunc_CopyMetaData).</summary>
        public static global::System.IntPtr NativeFunc_CopyMetaData => Memory.ModuleBase() + 0x820A334;
        public Object CopyMetaData(Object InMetaData)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, InMetaData);
            CallRaw("CopyMetaData", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new Object(__p); }
        }
    }

    public class LevelSequenceBurnInInitSettings : Object
    {
        public const string UeClassName = "LevelSequenceBurnInInitSettings";
        public LevelSequenceBurnInInitSettings(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelSequenceBurnInInitSettings FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelSequenceBurnInInitSettings(p);
        public static LevelSequenceBurnInInitSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelSequenceBurnInInitSettings(o.Pointer); }
        public static LevelSequenceBurnInInitSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelSequenceBurnInInitSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelSequenceBurnInInitSettings(a[i].Pointer); return r; }
    }

    public class LevelSequenceBurnInOptions : Object
    {
        public const string UeClassName = "LevelSequenceBurnInOptions";
        public LevelSequenceBurnInOptions(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelSequenceBurnInOptions FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelSequenceBurnInOptions(p);
        public static LevelSequenceBurnInOptions FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelSequenceBurnInOptions(o.Pointer); }
        public static LevelSequenceBurnInOptions[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelSequenceBurnInOptions[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelSequenceBurnInOptions(a[i].Pointer); return r; }
        public bool bUseBurnIn { get => Native.GetPropBool(Pointer, "bUseBurnIn"); set => Native.SetPropBool(Pointer, "bUseBurnIn", value); }
        public SoftClassPath BurnInClass => new SoftClassPath(AddrOf(0x30));
        public LevelSequenceBurnInInitSettings Settings { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new LevelSequenceBurnInInitSettings(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x820B7D8 — hookable via Hooks.InstallAt(NativeFunc_SetBurnIn).</summary>
        public static global::System.IntPtr NativeFunc_SetBurnIn => Memory.ModuleBase() + 0x820B7D8;
        public void SetBurnIn(global::System.IntPtr InBurnInClass)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, InBurnInClass);
            CallRaw("SetBurnIn", __pb.Bytes);
        }
    }

    public class LevelSequenceActor : Actor
    {
        public const string UeClassName = "LevelSequenceActor";
        public LevelSequenceActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelSequenceActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelSequenceActor(p);
        public static LevelSequenceActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelSequenceActor(o.Pointer); }
        public static LevelSequenceActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelSequenceActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelSequenceActor(a[i].Pointer); return r; }
        public MovieSceneSequencePlaybackSettings PlaybackSettings => new MovieSceneSequencePlaybackSettings(AddrOf(0x230));
        public LevelSequencePlayer SequencePlayer { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new LevelSequencePlayer(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoftObjectPath LevelSequence => new SoftObjectPath(AddrOf(0x250));
        public TArray<global::System.IntPtr> AdditionalEventReceivers => new TArray<global::System.IntPtr>(AddrOf(0x268)); // TArray<UObject*>
        public LevelSequenceCameraSettings CameraSettings => new LevelSequenceCameraSettings(AddrOf(0x278));
        public LevelSequenceBurnInOptions BurnInOptions { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new LevelSequenceBurnInOptions(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MovieSceneBindingOverrides BindingOverrides { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new MovieSceneBindingOverrides(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bAutoPlay { get => Native.GetPropBool(Pointer, "bAutoPlay"); set => Native.SetPropBool(Pointer, "bAutoPlay", value); }
        public bool bOverrideInstanceData { get => Native.GetPropBool(Pointer, "bOverrideInstanceData"); set => Native.SetPropBool(Pointer, "bOverrideInstanceData", value); }
        public bool bReplicatePlayback { get => Native.GetPropBool(Pointer, "bReplicatePlayback"); set => Native.SetPropBool(Pointer, "bReplicatePlayback", value); }
        public Object DefaultInstanceData { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LevelSequenceBurnIn BurnInInstance { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new LevelSequenceBurnIn(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bShowBurnin { get => Native.GetPropBool(Pointer, "bShowBurnin"); set => Native.SetPropBool(Pointer, "bShowBurnin", value); }
        /// <summary>[Native] thunk RVA 0x820C734 — hookable via Hooks.InstallAt(NativeFunc_ShowBurnin).</summary>
        public static global::System.IntPtr NativeFunc_ShowBurnin => Memory.ModuleBase() + 0x820C734;
        public void ShowBurnin()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowBurnin", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820C994 — hookable via Hooks.InstallAt(NativeFunc_SetSequence).</summary>
        public static global::System.IntPtr NativeFunc_SetSequence => Memory.ModuleBase() + 0x820C994;
        public void SetSequence(LevelSequence InSequence)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InSequence);
            CallRaw("SetSequence", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820C790 — hookable via Hooks.InstallAt(NativeFunc_SetReplicatePlayback).</summary>
        public static global::System.IntPtr NativeFunc_SetReplicatePlayback => Memory.ModuleBase() + 0x820C790;
        public void SetReplicatePlayback(bool ReplicatePlayback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(ReplicatePlayback?1:0));
            CallRaw("SetReplicatePlayback", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820C83C — hookable via Hooks.InstallAt(NativeFunc_SetEventReceivers).</summary>
        public static global::System.IntPtr NativeFunc_SetEventReceivers => Memory.ModuleBase() + 0x820C83C;
        public void SetEventReceivers(global::System.IntPtr AdditionalReceivers)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, AdditionalReceivers);
            CallRaw("SetEventReceivers", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820C470 — hookable via Hooks.InstallAt(NativeFunc_SetBindingByTag).</summary>
        public static global::System.IntPtr NativeFunc_SetBindingByTag => Memory.ModuleBase() + 0x820C470;
        public void SetBindingByTag(FName BindingTag, global::System.IntPtr Actors, bool bAllowBindingsFromAsset)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set(0x0, BindingTag);
            __pb.Set<global::System.IntPtr>(0x8, Actors);
            __pb.Set<byte>(0x18, (byte)(bAllowBindingsFromAsset?1:0));
            CallRaw("SetBindingByTag", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820C5C0 — hookable via Hooks.InstallAt(NativeFunc_SetBinding).</summary>
        public static global::System.IntPtr NativeFunc_SetBinding => Memory.ModuleBase() + 0x820C5C0;
        public void SetBinding(global::System.IntPtr Binding, global::System.IntPtr Actors, bool bAllowBindingsFromAsset)
        {
            var __pb = new ParamBuffer(41);
            __pb.Set<global::System.IntPtr>(0x0, Binding);
            __pb.Set<global::System.IntPtr>(0x18, Actors);
            __pb.Set<byte>(0x28, (byte)(bAllowBindingsFromAsset?1:0));
            CallRaw("SetBinding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820BF1C — hookable via Hooks.InstallAt(NativeFunc_ResetBindings).</summary>
        public static global::System.IntPtr NativeFunc_ResetBindings => Memory.ModuleBase() + 0x820BF1C;
        public void ResetBindings()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetBindings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820BF30 — hookable via Hooks.InstallAt(NativeFunc_ResetBinding).</summary>
        public static global::System.IntPtr NativeFunc_ResetBinding => Memory.ModuleBase() + 0x820BF30;
        public void ResetBinding(global::System.IntPtr Binding)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Binding);
            CallRaw("ResetBinding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820BFF8 — hookable via Hooks.InstallAt(NativeFunc_RemoveBindingByTag).</summary>
        public static global::System.IntPtr NativeFunc_RemoveBindingByTag => Memory.ModuleBase() + 0x820BFF8;
        public void RemoveBindingByTag(FName Tag, Actor Actor)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Tag);
            __pb.SetObject(0x8, Actor);
            CallRaw("RemoveBindingByTag", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820C0DC — hookable via Hooks.InstallAt(NativeFunc_RemoveBinding).</summary>
        public static global::System.IntPtr NativeFunc_RemoveBinding => Memory.ModuleBase() + 0x820C0DC;
        public void RemoveBinding(global::System.IntPtr Binding, Actor Actor)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, Binding);
            __pb.SetObject(0x18, Actor);
            CallRaw("RemoveBinding", __pb.Bytes);
        }
        public void OnLevelSequenceLoaded__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnLevelSequenceLoaded__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820CA38 — hookable via Hooks.InstallAt(NativeFunc_LoadSequence).</summary>
        public static global::System.IntPtr NativeFunc_LoadSequence => Memory.ModuleBase() + 0x820CA38;
        public LevelSequence LoadSequence()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("LoadSequence", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new LevelSequence(__p); }
        }
        /// <summary>[Native] thunk RVA 0x820C748 — hookable via Hooks.InstallAt(NativeFunc_HideBurnin).</summary>
        public static global::System.IntPtr NativeFunc_HideBurnin => Memory.ModuleBase() + 0x820C748;
        public void HideBurnin()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideBurnin", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820C75C — hookable via Hooks.InstallAt(NativeFunc_GetSequencePlayer).</summary>
        public static global::System.IntPtr NativeFunc_GetSequencePlayer => Memory.ModuleBase() + 0x820C75C;
        public LevelSequencePlayer GetSequencePlayer()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSequencePlayer", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new LevelSequencePlayer(__p); }
        }
        /// <summary>[Native] thunk RVA 0x820CA6C — hookable via Hooks.InstallAt(NativeFunc_GetSequence).</summary>
        public static global::System.IntPtr NativeFunc_GetSequence => Memory.ModuleBase() + 0x820CA6C;
        public LevelSequence GetSequence()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSequence", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new LevelSequence(__p); }
        }
        /// <summary>[Native] thunk RVA 0x820BD5C — hookable via Hooks.InstallAt(NativeFunc_FindNamedBindings).</summary>
        public static global::System.IntPtr NativeFunc_FindNamedBindings => Memory.ModuleBase() + 0x820BD5C;
        public global::System.IntPtr FindNamedBindings(FName Tag)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Tag);
            CallRaw("FindNamedBindings", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x820BE58 — hookable via Hooks.InstallAt(NativeFunc_FindNamedBinding).</summary>
        public static global::System.IntPtr NativeFunc_FindNamedBinding => Memory.ModuleBase() + 0x820BE58;
        public global::System.IntPtr FindNamedBinding(FName Tag)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set(0x0, Tag);
            CallRaw("FindNamedBinding", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x820C1E8 — hookable via Hooks.InstallAt(NativeFunc_AddBindingByTag).</summary>
        public static global::System.IntPtr NativeFunc_AddBindingByTag => Memory.ModuleBase() + 0x820C1E8;
        public void AddBindingByTag(FName BindingTag, Actor Actor, bool bAllowBindingsFromAsset)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set(0x0, BindingTag);
            __pb.SetObject(0x8, Actor);
            __pb.Set<byte>(0x10, (byte)(bAllowBindingsFromAsset?1:0));
            CallRaw("AddBindingByTag", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820C318 — hookable via Hooks.InstallAt(NativeFunc_AddBinding).</summary>
        public static global::System.IntPtr NativeFunc_AddBinding => Memory.ModuleBase() + 0x820C318;
        public void AddBinding(global::System.IntPtr Binding, Actor Actor, bool bAllowBindingsFromAsset)
        {
            var __pb = new ParamBuffer(33);
            __pb.Set<global::System.IntPtr>(0x0, Binding);
            __pb.SetObject(0x18, Actor);
            __pb.Set<byte>(0x20, (byte)(bAllowBindingsFromAsset?1:0));
            CallRaw("AddBinding", __pb.Bytes);
        }
    }

    public class LevelSequenceBurnIn : UserWidget
    {
        public const string UeClassName = "LevelSequenceBurnIn";
        public LevelSequenceBurnIn(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelSequenceBurnIn FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelSequenceBurnIn(p);
        public static LevelSequenceBurnIn FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelSequenceBurnIn(o.Pointer); }
        public static LevelSequenceBurnIn[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelSequenceBurnIn[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelSequenceBurnIn(a[i].Pointer); return r; }
        public LevelSequencePlayerSnapshot FrameInformation => new LevelSequencePlayerSnapshot(AddrOf(0x230));
        public LevelSequenceActor LevelSequenceActor { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new LevelSequenceActor(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetSettings(Object InSettings)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x820F40C — hookable via Hooks.InstallAt(NativeFunc_GetSettingsClass).</summary>
        public static global::System.IntPtr NativeFunc_GetSettingsClass => Memory.ModuleBase() + 0x820F40C;
        public LevelSequenceBurnInInitSettings GetSettingsClass()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSettingsClass", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new LevelSequenceBurnInInitSettings(__p); }
        }
    }

    public class LevelSequenceDirector : Object
    {
        public const string UeClassName = "LevelSequenceDirector";
        public LevelSequenceDirector(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelSequenceDirector FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelSequenceDirector(p);
        public static LevelSequenceDirector FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelSequenceDirector(o.Pointer); }
        public static LevelSequenceDirector[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelSequenceDirector[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelSequenceDirector(a[i].Pointer); return r; }
        public LevelSequencePlayer Player { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new LevelSequencePlayer(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void OnCreated()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnCreated", __pb.Bytes);
        }
    }

    public class LegacyLevelSequenceDirectorBlueprint : Blueprint
    {
        public const string UeClassName = "LegacyLevelSequenceDirectorBlueprint";
        public LegacyLevelSequenceDirectorBlueprint(global::System.IntPtr ptr) : base(ptr) {}
        public static new LegacyLevelSequenceDirectorBlueprint FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LegacyLevelSequenceDirectorBlueprint(p);
        public static LegacyLevelSequenceDirectorBlueprint FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LegacyLevelSequenceDirectorBlueprint(o.Pointer); }
        public static LegacyLevelSequenceDirectorBlueprint[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LegacyLevelSequenceDirectorBlueprint[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LegacyLevelSequenceDirectorBlueprint(a[i].Pointer); return r; }
    }

    public class LevelSequencePlayer : MovieSceneSequencePlayer
    {
        public const string UeClassName = "LevelSequencePlayer";
        public LevelSequencePlayer(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelSequencePlayer FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelSequencePlayer(p);
        public static LevelSequencePlayer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelSequencePlayer(o.Pointer); }
        public static LevelSequencePlayer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelSequencePlayer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelSequencePlayer(a[i].Pointer); return r; }
        public global::System.IntPtr OnCameraCut => AddrOf(0x888); // 
        /// <summary>[Native] thunk RVA 0x82128EC — hookable via Hooks.InstallAt(NativeFunc_GetActiveCameraComponent).</summary>
        public static global::System.IntPtr NativeFunc_GetActiveCameraComponent => Memory.ModuleBase() + 0x82128EC;
        public CameraComponent GetActiveCameraComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetActiveCameraComponent", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new CameraComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x8212924 — hookable via Hooks.InstallAt(NativeFunc_CreateLevelSequencePlayer).</summary>
        public static global::System.IntPtr NativeFunc_CreateLevelSequencePlayer => Memory.ModuleBase() + 0x8212924;
        public LevelSequencePlayer CreateLevelSequencePlayer(Object WorldContextObject, LevelSequence LevelSequence, global::System.IntPtr Settings, LevelSequenceActor OutActor)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, LevelSequence);
            __pb.Set<global::System.IntPtr>(0x10, Settings);
            __pb.SetObject(0x28, OutActor);
            CallRaw("CreateLevelSequencePlayer", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new LevelSequencePlayer(__p); }
        }
    }

    public class LevelSequenceMediaController : Actor
    {
        public const string UeClassName = "LevelSequenceMediaController";
        public LevelSequenceMediaController(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelSequenceMediaController FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelSequenceMediaController(p);
        public static LevelSequenceMediaController FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelSequenceMediaController(o.Pointer); }
        public static LevelSequenceMediaController[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelSequenceMediaController[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelSequenceMediaController(a[i].Pointer); return r; }
        public LevelSequenceActor Sequence { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new LevelSequenceActor(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MediaComponent MediaComponent { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new MediaComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float ServerStartTimeSeconds { get => GetAt<float>(0x238); set => SetAt(0x238, value); }
        /// <summary>[Native] thunk RVA 0x8213D48 — hookable via Hooks.InstallAt(NativeFunc_SynchronizeToServer).</summary>
        public static global::System.IntPtr NativeFunc_SynchronizeToServer => Memory.ModuleBase() + 0x8213D48;
        public void SynchronizeToServer(float DesyncThresholdSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DesyncThresholdSeconds);
            CallRaw("SynchronizeToServer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8213E24 — hookable via Hooks.InstallAt(NativeFunc_Play).</summary>
        public static global::System.IntPtr NativeFunc_Play => Memory.ModuleBase() + 0x8213E24;
        public void Play()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Play", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8213D34 — hookable via Hooks.InstallAt(NativeFunc_OnRep_ServerStartTimeSeconds).</summary>
        public static global::System.IntPtr NativeFunc_OnRep_ServerStartTimeSeconds => Memory.ModuleBase() + 0x8213D34;
        public void OnRep_ServerStartTimeSeconds()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnRep_ServerStartTimeSeconds", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8213DEC — hookable via Hooks.InstallAt(NativeFunc_GetSequence).</summary>
        public static global::System.IntPtr NativeFunc_GetSequence => Memory.ModuleBase() + 0x8213DEC;
        public LevelSequenceActor GetSequence()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSequence", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new LevelSequenceActor(__p); }
        }
        /// <summary>[Native] thunk RVA 0x8213E08 — hookable via Hooks.InstallAt(NativeFunc_GetMediaComponent).</summary>
        public static global::System.IntPtr NativeFunc_GetMediaComponent => Memory.ModuleBase() + 0x8213E08;
        public MediaComponent GetMediaComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetMediaComponent", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MediaComponent(__p); }
        }
    }

}
