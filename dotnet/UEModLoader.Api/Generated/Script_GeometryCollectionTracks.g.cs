// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/GeometryCollectionTracks
using System;

namespace UEModLoader.Game
{
    public class MovieSceneGeometryCollectionParams : StructProxy
    {
        public MovieSceneGeometryCollectionParams(System.IntPtr ptr) : base(ptr) {}
        public SoftObjectPath GeometryCollectionCache => new SoftObjectPath(AddrOf(0x8));
        public FrameNumber StartFrameOffset => new FrameNumber(AddrOf(0x20));
        public FrameNumber EndFrameOffset => new FrameNumber(AddrOf(0x24));
        public float PlayRate { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
    }

    public class MovieSceneGeometryCollectionSectionTemplate : StructProxy
    {
        public MovieSceneGeometryCollectionSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneGeometryCollectionSectionTemplateParameters Params => new MovieSceneGeometryCollectionSectionTemplateParameters(AddrOf(0x18));
    }

    public class MovieSceneGeometryCollectionSectionTemplateParameters : StructProxy
    {
        public MovieSceneGeometryCollectionSectionTemplateParameters(System.IntPtr ptr) : base(ptr) {}
        public FrameNumber SectionStartTime => new FrameNumber(AddrOf(0x2C));
        public FrameNumber SectionEndTime => new FrameNumber(AddrOf(0x30));
    }

    public class MovieSceneGeometryCollectionSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneGeometryCollectionSection";
        public MovieSceneGeometryCollectionSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneGeometryCollectionSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneGeometryCollectionSection(p);
        public static MovieSceneGeometryCollectionSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneGeometryCollectionSection(o.Pointer); }
        public static MovieSceneGeometryCollectionSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneGeometryCollectionSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneGeometryCollectionSection(a[i].Pointer); return r; }
        public MovieSceneGeometryCollectionParams Params => new MovieSceneGeometryCollectionParams(AddrOf(0xD8));
    }

    public class MovieSceneGeometryCollectionTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneGeometryCollectionTrack";
        public MovieSceneGeometryCollectionTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneGeometryCollectionTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneGeometryCollectionTrack(p);
        public static MovieSceneGeometryCollectionTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneGeometryCollectionTrack(o.Pointer); }
        public static MovieSceneGeometryCollectionTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneGeometryCollectionTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneGeometryCollectionTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> AnimationSections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

}
