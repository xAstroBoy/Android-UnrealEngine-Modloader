// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/GeometryCache
using System;

namespace UEModLoader.Game
{
    public class TrackRenderData : StructProxy
    {
        public TrackRenderData(System.IntPtr ptr) : base(ptr) {}
    }

    public class GeometryCacheMeshData : StructProxy
    {
        public GeometryCacheMeshData(System.IntPtr ptr) : base(ptr) {}
    }

    public class GeometryCacheVertexInfo : StructProxy
    {
        public GeometryCacheVertexInfo(System.IntPtr ptr) : base(ptr) {}
    }

    public class GeometryCacheMeshBatchInfo : StructProxy
    {
        public GeometryCacheMeshBatchInfo(System.IntPtr ptr) : base(ptr) {}
    }

    public class GeometryCache : Object
    {
        public const string UeClassName = "GeometryCache";
        public GeometryCache(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCache FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCache(p);
        public static GeometryCache FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCache(o.Pointer); }
        public static GeometryCache[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCache[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCache(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Materials => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<UObject*>
        public TArray<System.IntPtr> Tracks => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<UObject*>
        public int StartFrame { get => GetAt<int>(0x60); set => SetAt(0x60, value); }
        public int EndFrame { get => GetAt<int>(0x64); set => SetAt(0x64, value); }
    }

    public class GeometryCacheActor : Actor
    {
        public const string UeClassName = "GeometryCacheActor";
        public GeometryCacheActor(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheActor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheActor(p);
        public static GeometryCacheActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheActor(o.Pointer); }
        public static GeometryCacheActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheActor(a[i].Pointer); return r; }
        public GeometryCacheComponent GeometryCacheComponent { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new GeometryCacheComponent(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x5761B80 — hookable via Hooks.InstallAt(NativeFunc_GetGeometryCacheComponent).</summary>
        public static System.IntPtr NativeFunc_GetGeometryCacheComponent => Memory.ModuleBase() + 0x5761B80;
        public GeometryCacheComponent GetGeometryCacheComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetGeometryCacheComponent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new GeometryCacheComponent(__p); }
        }
    }

    public class GeometryCacheCodecBase : Object
    {
        public const string UeClassName = "GeometryCacheCodecBase";
        public GeometryCacheCodecBase(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheCodecBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheCodecBase(p);
        public static GeometryCacheCodecBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheCodecBase(o.Pointer); }
        public static GeometryCacheCodecBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheCodecBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheCodecBase(a[i].Pointer); return r; }
        public TArray<System.IntPtr> TopologyRanges => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<int32>
    }

    public class GeometryCacheCodecRaw : GeometryCacheCodecBase
    {
        public const string UeClassName = "GeometryCacheCodecRaw";
        public GeometryCacheCodecRaw(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheCodecRaw FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheCodecRaw(p);
        public static GeometryCacheCodecRaw FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheCodecRaw(o.Pointer); }
        public static GeometryCacheCodecRaw[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheCodecRaw[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheCodecRaw(a[i].Pointer); return r; }
        public int DummyProperty { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
    }

    public class GeometryCacheCodecV1 : GeometryCacheCodecBase
    {
        public const string UeClassName = "GeometryCacheCodecV1";
        public GeometryCacheCodecV1(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheCodecV1 FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheCodecV1(p);
        public static GeometryCacheCodecV1 FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheCodecV1(o.Pointer); }
        public static GeometryCacheCodecV1[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheCodecV1[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheCodecV1(a[i].Pointer); return r; }
    }

    public class GeometryCacheComponent : MeshComponent
    {
        public const string UeClassName = "GeometryCacheComponent";
        public GeometryCacheComponent(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheComponent(p);
        public static GeometryCacheComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheComponent(o.Pointer); }
        public static GeometryCacheComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheComponent(a[i].Pointer); return r; }
        public GeometryCache GeometryCache { get { var __p = GetAt<System.IntPtr>(0x430); return __p==System.IntPtr.Zero?null:new GeometryCache(__p); } set => SetAt(0x430, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bRunning { get => Native.GetPropBool(Pointer, "bRunning"); set => Native.SetPropBool(Pointer, "bRunning", value); }
        public bool bLooping { get => Native.GetPropBool(Pointer, "bLooping"); set => Native.SetPropBool(Pointer, "bLooping", value); }
        public float StartTimeOffset { get => GetAt<float>(0x43C); set => SetAt(0x43C, value); }
        public float PlaybackSpeed { get => GetAt<float>(0x440); set => SetAt(0x440, value); }
        public int NumTracks { get => GetAt<int>(0x444); set => SetAt(0x444, value); }
        public float ElapsedTime { get => GetAt<float>(0x448); set => SetAt(0x448, value); }
        public float Duration { get => GetAt<float>(0x47C); set => SetAt(0x47C, value); }
        public bool bManualTick { get => Native.GetPropBool(Pointer, "bManualTick"); set => Native.SetPropBool(Pointer, "bManualTick", value); }
        /// <summary>[Native] thunk RVA 0x576383C — hookable via Hooks.InstallAt(NativeFunc_TickAtThisTime).</summary>
        public static System.IntPtr NativeFunc_TickAtThisTime => Memory.ModuleBase() + 0x576383C;
        public void TickAtThisTime(float Time, bool bInIsRunning, bool bInBackwards, bool bInIsLooping)
        {
            var __pb = new ParamBuffer(7);
            __pb.Set(0x0, Time);
            __pb.Set<byte>(0x4, (byte)(bInIsRunning?1:0));
            __pb.Set<byte>(0x5, (byte)(bInBackwards?1:0));
            __pb.Set<byte>(0x6, (byte)(bInIsLooping?1:0));
            CallRaw("TickAtThisTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763E58 — hookable via Hooks.InstallAt(NativeFunc_Stop).</summary>
        public static System.IntPtr NativeFunc_Stop => Memory.ModuleBase() + 0x5763E58;
        public void Stop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Stop", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763AA4 — hookable via Hooks.InstallAt(NativeFunc_SetStartTimeOffset).</summary>
        public static System.IntPtr NativeFunc_SetStartTimeOffset => Memory.ModuleBase() + 0x5763AA4;
        public void SetStartTimeOffset(float NewStartTimeOffset)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewStartTimeOffset);
            CallRaw("SetStartTimeOffset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763C2C — hookable via Hooks.InstallAt(NativeFunc_SetPlaybackSpeed).</summary>
        public static System.IntPtr NativeFunc_SetPlaybackSpeed => Memory.ModuleBase() + 0x5763C2C;
        public void SetPlaybackSpeed(float NewPlaybackSpeed)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewPlaybackSpeed);
            CallRaw("SetPlaybackSpeed", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763D04 — hookable via Hooks.InstallAt(NativeFunc_SetLooping).</summary>
        public static System.IntPtr NativeFunc_SetLooping => Memory.ModuleBase() + 0x5763D04;
        public void SetLooping(bool bNewLooping)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bNewLooping?1:0));
            CallRaw("SetLooping", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763B7C — hookable via Hooks.InstallAt(NativeFunc_SetGeometryCache).</summary>
        public static System.IntPtr NativeFunc_SetGeometryCache => Memory.ModuleBase() + 0x5763B7C;
        public bool SetGeometryCache(GeometryCache NewGeomCache)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, NewGeomCache);
            CallRaw("SetGeometryCache", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5763E80 — hookable via Hooks.InstallAt(NativeFunc_PlayReversedFromEnd).</summary>
        public static System.IntPtr NativeFunc_PlayReversedFromEnd => Memory.ModuleBase() + 0x5763E80;
        public void PlayReversedFromEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayReversedFromEnd", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763E94 — hookable via Hooks.InstallAt(NativeFunc_PlayReversed).</summary>
        public static System.IntPtr NativeFunc_PlayReversed => Memory.ModuleBase() + 0x5763E94;
        public void PlayReversed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayReversed", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763EA8 — hookable via Hooks.InstallAt(NativeFunc_PlayFromStart).</summary>
        public static System.IntPtr NativeFunc_PlayFromStart => Memory.ModuleBase() + 0x5763EA8;
        public void PlayFromStart()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayFromStart", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763EBC — hookable via Hooks.InstallAt(NativeFunc_Play).</summary>
        public static System.IntPtr NativeFunc_Play => Memory.ModuleBase() + 0x5763EBC;
        public void Play()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Play", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763E6C — hookable via Hooks.InstallAt(NativeFunc_Pause).</summary>
        public static System.IntPtr NativeFunc_Pause => Memory.ModuleBase() + 0x5763E6C;
        public void Pause()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Pause", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5763DE8 — hookable via Hooks.InstallAt(NativeFunc_IsPlayingReversed).</summary>
        public static System.IntPtr NativeFunc_IsPlayingReversed => Memory.ModuleBase() + 0x5763DE8;
        public bool IsPlayingReversed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPlayingReversed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5763E20 — hookable via Hooks.InstallAt(NativeFunc_IsPlaying).</summary>
        public static System.IntPtr NativeFunc_IsPlaying => Memory.ModuleBase() + 0x5763E20;
        public bool IsPlaying()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPlaying", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5763DB0 — hookable via Hooks.InstallAt(NativeFunc_IsLooping).</summary>
        public static System.IntPtr NativeFunc_IsLooping => Memory.ModuleBase() + 0x5763DB0;
        public bool IsLooping()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsLooping", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5763B48 — hookable via Hooks.InstallAt(NativeFunc_GetStartTimeOffset).</summary>
        public static System.IntPtr NativeFunc_GetStartTimeOffset => Memory.ModuleBase() + 0x5763B48;
        public float GetStartTimeOffset()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetStartTimeOffset", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5763CD0 — hookable via Hooks.InstallAt(NativeFunc_GetPlaybackSpeed).</summary>
        public static System.IntPtr NativeFunc_GetPlaybackSpeed => Memory.ModuleBase() + 0x5763CD0;
        public float GetPlaybackSpeed()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPlaybackSpeed", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5763A3C — hookable via Hooks.InstallAt(NativeFunc_GetPlaybackDirection).</summary>
        public static System.IntPtr NativeFunc_GetPlaybackDirection => Memory.ModuleBase() + 0x5763A3C;
        public float GetPlaybackDirection()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPlaybackDirection", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x57639D4 — hookable via Hooks.InstallAt(NativeFunc_GetNumberOfFrames).</summary>
        public static System.IntPtr NativeFunc_GetNumberOfFrames => Memory.ModuleBase() + 0x57639D4;
        public int GetNumberOfFrames()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumberOfFrames", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5763A08 — hookable via Hooks.InstallAt(NativeFunc_GetDuration).</summary>
        public static System.IntPtr NativeFunc_GetDuration => Memory.ModuleBase() + 0x5763A08;
        public float GetDuration()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetDuration", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5763A70 — hookable via Hooks.InstallAt(NativeFunc_GetAnimationTime).</summary>
        public static System.IntPtr NativeFunc_GetAnimationTime => Memory.ModuleBase() + 0x5763A70;
        public float GetAnimationTime()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetAnimationTime", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
    }

    public class GeometryCacheTrack : Object
    {
        public const string UeClassName = "GeometryCacheTrack";
        public GeometryCacheTrack(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheTrack(p);
        public static GeometryCacheTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheTrack(o.Pointer); }
        public static GeometryCacheTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheTrack(a[i].Pointer); return r; }
        public float Duration { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
    }

    public class GeometryCacheTrack_FlipbookAnimation : GeometryCacheTrack
    {
        public const string UeClassName = "GeometryCacheTrack_FlipbookAnimation";
        public GeometryCacheTrack_FlipbookAnimation(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheTrack_FlipbookAnimation FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheTrack_FlipbookAnimation(p);
        public static GeometryCacheTrack_FlipbookAnimation FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheTrack_FlipbookAnimation(o.Pointer); }
        public static GeometryCacheTrack_FlipbookAnimation[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheTrack_FlipbookAnimation[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheTrack_FlipbookAnimation(a[i].Pointer); return r; }
        public uint NumMeshSamples { get => GetAt<uint>(0x54); set => SetAt(0x54, value); }
        /// <summary>[Native] thunk RVA 0x57661EC — hookable via Hooks.InstallAt(NativeFunc_AddMeshSample).</summary>
        public static System.IntPtr NativeFunc_AddMeshSample => Memory.ModuleBase() + 0x57661EC;
        public void AddMeshSample(GeometryCacheMeshData MeshData, float SampleTime)
        {
            var __pb = new ParamBuffer(172);
            __pb.Set<System.IntPtr>(0x0, MeshData);
            __pb.Set(0xA8, SampleTime);
            CallRaw("AddMeshSample", __pb.Bytes);
        }
    }

    public class GeometryCacheTrackStreamable : GeometryCacheTrack
    {
        public const string UeClassName = "GeometryCacheTrackStreamable";
        public GeometryCacheTrackStreamable(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheTrackStreamable FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheTrackStreamable(p);
        public static GeometryCacheTrackStreamable FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheTrackStreamable(o.Pointer); }
        public static GeometryCacheTrackStreamable[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheTrackStreamable[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheTrackStreamable(a[i].Pointer); return r; }
        public GeometryCacheCodecBase Codec { get { var __p = GetAt<System.IntPtr>(0x58); return __p==System.IntPtr.Zero?null:new GeometryCacheCodecBase(__p); } set => SetAt(0x58, value?.Pointer ?? System.IntPtr.Zero); }
        public float StartSampleTime { get => GetAt<float>(0xC8); set => SetAt(0xC8, value); }
    }

    public class GeometryCacheTrack_TransformAnimation : GeometryCacheTrack
    {
        public const string UeClassName = "GeometryCacheTrack_TransformAnimation";
        public GeometryCacheTrack_TransformAnimation(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheTrack_TransformAnimation FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheTrack_TransformAnimation(p);
        public static GeometryCacheTrack_TransformAnimation FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheTrack_TransformAnimation(o.Pointer); }
        public static GeometryCacheTrack_TransformAnimation[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheTrack_TransformAnimation[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheTrack_TransformAnimation(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x57671D0 — hookable via Hooks.InstallAt(NativeFunc_SetMesh).</summary>
        public static System.IntPtr NativeFunc_SetMesh => Memory.ModuleBase() + 0x57671D0;
        public void SetMesh(GeometryCacheMeshData NewMeshData)
        {
            var __pb = new ParamBuffer(168);
            __pb.Set<System.IntPtr>(0x0, NewMeshData);
            CallRaw("SetMesh", __pb.Bytes);
        }
    }

    public class GeometryCacheTrack_TransformGroupAnimation : GeometryCacheTrack
    {
        public const string UeClassName = "GeometryCacheTrack_TransformGroupAnimation";
        public GeometryCacheTrack_TransformGroupAnimation(System.IntPtr ptr) : base(ptr) {}
        public static new GeometryCacheTrack_TransformGroupAnimation FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeometryCacheTrack_TransformGroupAnimation(p);
        public static GeometryCacheTrack_TransformGroupAnimation FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeometryCacheTrack_TransformGroupAnimation(o.Pointer); }
        public static GeometryCacheTrack_TransformGroupAnimation[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeometryCacheTrack_TransformGroupAnimation[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeometryCacheTrack_TransformGroupAnimation(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5767A98 — hookable via Hooks.InstallAt(NativeFunc_SetMesh).</summary>
        public static System.IntPtr NativeFunc_SetMesh => Memory.ModuleBase() + 0x5767A98;
        public void SetMesh(GeometryCacheMeshData NewMeshData)
        {
            var __pb = new ParamBuffer(168);
            __pb.Set<System.IntPtr>(0x0, NewMeshData);
            CallRaw("SetMesh", __pb.Bytes);
        }
    }

}
