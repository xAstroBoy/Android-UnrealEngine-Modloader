// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/GeometryCacheTracks
using System;

namespace UEModLoader.Game
{
    public class MovieSceneGeometryCacheParams : StructProxy
    {
        public MovieSceneGeometryCacheParams(global::System.IntPtr ptr) : base(ptr) {}
        public GeometryCache GeometryCacheAsset { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new GeometryCache(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public FrameNumber FirstLoopStartFrameOffset => new FrameNumber(AddrOf(0x8));
        public FrameNumber StartFrameOffset => new FrameNumber(AddrOf(0xC));
        public FrameNumber EndFrameOffset => new FrameNumber(AddrOf(0x10));
        public float PlayRate { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public bool bReverse { get => (GetAt<byte>(0x18) & 0x1) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public float StartOffset { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public float EndOffset { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public SoftObjectPath GeometryCache => new SoftObjectPath(AddrOf(0x28));
    }

    public class MovieSceneGeometryCacheSectionTemplate : StructProxy
    {
        public MovieSceneGeometryCacheSectionTemplate(global::System.IntPtr ptr) : base(ptr) {}
        public MovieSceneGeometryCacheSectionTemplateParameters Params => new MovieSceneGeometryCacheSectionTemplateParameters(AddrOf(0x18));
    }

    public class MovieSceneGeometryCacheSectionTemplateParameters : StructProxy
    {
        public MovieSceneGeometryCacheSectionTemplateParameters(global::System.IntPtr ptr) : base(ptr) {}
        public FrameNumber SectionStartTime => new FrameNumber(AddrOf(0x40));
        public FrameNumber SectionEndTime => new FrameNumber(AddrOf(0x44));
    }

    public class MovieSceneGeometryCacheSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneGeometryCacheSection";
        public MovieSceneGeometryCacheSection(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneGeometryCacheSection FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneGeometryCacheSection(p);
        public static MovieSceneGeometryCacheSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneGeometryCacheSection(o.Pointer); }
        public static MovieSceneGeometryCacheSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneGeometryCacheSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneGeometryCacheSection(a[i].Pointer); return r; }
        public MovieSceneGeometryCacheParams Params => new MovieSceneGeometryCacheParams(AddrOf(0xD8));
    }

    public class MovieSceneGeometryCacheTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneGeometryCacheTrack";
        public MovieSceneGeometryCacheTrack(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneGeometryCacheTrack FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneGeometryCacheTrack(p);
        public static MovieSceneGeometryCacheTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneGeometryCacheTrack(o.Pointer); }
        public static MovieSceneGeometryCacheTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneGeometryCacheTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneGeometryCacheTrack(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> AnimationSections => new TArray<global::System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

}
