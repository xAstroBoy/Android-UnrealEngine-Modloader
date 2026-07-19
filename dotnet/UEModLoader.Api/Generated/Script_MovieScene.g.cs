// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/MovieScene
using System;

namespace UEModLoader.Game
{
    public enum EMovieSceneKeyInterpolation
    {
        Auto = 0,
        User = 1,
        Break = 2,
        Linear = 3,
        Constant = 4,
    }

    public enum EMovieSceneBlendType
    {
        Invalid = 0,
        Absolute = 1,
        Additive = 2,
        Relative = 4,
    }

    public enum EMovieSceneBuiltInEasing
    {
        Linear = 0,
        SinIn = 1,
        SinOut = 2,
        SinInOut = 3,
        QuadIn = 4,
        QuadOut = 5,
        QuadInOut = 6,
        CubicIn = 7,
        CubicOut = 8,
        CubicInOut = 9,
        QuartIn = 10,
        QuartOut = 11,
        QuartInOut = 12,
        QuintIn = 13,
        QuintOut = 14,
        QuintInOut = 15,
        ExpoIn = 16,
        ExpoOut = 17,
        ExpoInOut = 18,
        CircIn = 19,
        CircOut = 20,
        CircInOut = 21,
    }

    public enum EEvaluationMethod
    {
        Static = 0,
        Swept = 1,
    }

    public enum EUpdateClockSource
    {
        Tick = 0,
        Platform = 1,
        Audio = 2,
        RelativeTimecode = 3,
        Timecode = 4,
        Custom = 5,
    }

    public enum EMovieSceneEvaluationType
    {
        FrameLocked = 0,
        WithSubFrames = 1,
    }

    public enum EMovieScenePlayerStatus
    {
        Stopped = 0,
        Playing = 1,
        Recording = 2,
        Scrubbing = 3,
        Jumping = 4,
        Stepping = 5,
        Paused = 6,
        MAX = 7,
    }

    public enum EMovieSceneObjectBindingSpace
    {
        Local = 0,
        Root = 1,
    }

    public enum EMovieSceneCompletionMode
    {
        KeepState = 0,
        RestoreState = 1,
        ProjectDefault = 2,
    }

    public enum ESectionEvaluationFlags
    {
        None = 0,
        PreRoll = 1,
        PostRoll = 2,
    }

    public enum EUpdatePositionMethod
    {
        Play = 0,
        Jump = 1,
        Scrub = 2,
    }

    public enum ESpawnOwnership
    {
        InnerSequence = 0,
        MasterSequence = 1,
        External = 2,
    }

    public class MovieSceneEvalTemplateBase : StructProxy
    {
        public MovieSceneEvalTemplateBase(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneEvalTemplate : StructProxy
    {
        public MovieSceneEvalTemplate(System.IntPtr ptr) : base(ptr) {}
        public EMovieSceneCompletionMode CompletionMode { get => (EMovieSceneCompletionMode)GetAt<byte>(0x9); set => SetAt(0x9, (byte)value); }
        public MovieSceneSection SourceSectionPtr { get { var __p = GetAt<System.IntPtr>(0xC); return __p==System.IntPtr.Zero?null:new MovieSceneSection(__p); } set => SetAt(0xC, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieSceneChannel : StructProxy
    {
        public MovieSceneChannel(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneBoolChannel : StructProxy
    {
        public MovieSceneBoolChannel(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Times => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public bool DefaultValue { get => (GetAt<byte>(0x18) & 0xFF) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bHasDefaultValue { get => (GetAt<byte>(0x19) & 0xFF) != 0; set { var __b = GetAt<byte>(0x19); SetAt(0x19, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public TArray<System.IntPtr> Values => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<bool>
    }

    public class MovieSceneFloatChannel : StructProxy
    {
        public MovieSceneFloatChannel(System.IntPtr ptr) : base(ptr) {}
        public byte PreInfinityExtrap { get => GetAt<byte>(0x8); set => SetAt(0x8, value); }
        public byte PostInfinityExtrap { get => GetAt<byte>(0x9); set => SetAt(0x9, value); }
        public TArray<System.IntPtr> Times => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<System.IntPtr> Values => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<struct>
        public float DefaultValue { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public bool bHasDefaultValue { get => (GetAt<byte>(0x34) & 0xFF) != 0; set { var __b = GetAt<byte>(0x34); SetAt(0x34, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public MovieSceneKeyHandleMap KeyHandles => new MovieSceneKeyHandleMap(AddrOf(0x38));
        public FrameRate TickResolution => new FrameRate(AddrOf(0x98));
    }

    public class MovieSceneKeyHandleMap : StructProxy
    {
        public MovieSceneKeyHandleMap(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneFloatValue : StructProxy
    {
        public MovieSceneFloatValue(System.IntPtr ptr) : base(ptr) {}
        public float Value { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public MovieSceneTangentData Tangent => new MovieSceneTangentData(AddrOf(0x4));
        public byte InterpMode { get => GetAt<byte>(0x18); set => SetAt(0x18, value); }
        public byte TangentMode { get => GetAt<byte>(0x19); set => SetAt(0x19, value); }
        public byte PaddingByte { get => GetAt<byte>(0x1A); set => SetAt(0x1A, value); }
    }

    public class MovieSceneTangentData : StructProxy
    {
        public MovieSceneTangentData(System.IntPtr ptr) : base(ptr) {}
        public float ArriveTangent { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float LeaveTangent { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float ArriveTangentWeight { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float LeaveTangentWeight { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public byte TangentWeightMode { get => GetAt<byte>(0x10); set => SetAt(0x10, value); }
    }

    public class MovieSceneIntegerChannel : StructProxy
    {
        public MovieSceneIntegerChannel(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Times => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public int DefaultValue { get => GetAt<int>(0x18); set => SetAt(0x18, value); }
        public bool bHasDefaultValue { get => (GetAt<byte>(0x1C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1C); SetAt(0x1C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public TArray<System.IntPtr> Values => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<int32>
    }

    public class MovieSceneTrackImplementation : StructProxy
    {
        public MovieSceneTrackImplementation(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneSectionGroup : StructProxy
    {
        public MovieSceneSectionGroup(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<TWeakObjectPtr>
    }

    public class MovieSceneObjectBindingIDs : StructProxy
    {
        public MovieSceneObjectBindingIDs(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> IDs => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class MovieSceneObjectBindingID : StructProxy
    {
        public MovieSceneObjectBindingID(System.IntPtr ptr) : base(ptr) {}
        public int SequenceID { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public EMovieSceneObjectBindingSpace Space { get => (EMovieSceneObjectBindingSpace)GetAt<byte>(0x4); set => SetAt(0x4, (byte)value); }
        public Guid Guid => new Guid(AddrOf(0x8));
    }

    public class MovieSceneTrackLabels : StructProxy
    {
        public MovieSceneTrackLabels(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Strings => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<FString>
    }

    public class MovieSceneEditorData : StructProxy
    {
        public MovieSceneEditorData(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr ExpansionStates => AddrOf(0x0); // 
        public TArray<System.IntPtr> PinnedNodes => new TArray<System.IntPtr>(AddrOf(0x50)); // TArray<FString>
        public double ViewStart { get => GetAt<double>(0x60); set => SetAt(0x60, value); }
        public double ViewEnd { get => GetAt<double>(0x68); set => SetAt(0x68, value); }
        public double WorkStart { get => GetAt<double>(0x70); set => SetAt(0x70, value); }
        public double WorkEnd { get => GetAt<double>(0x78); set => SetAt(0x78, value); }
        public System.IntPtr MarkedFrames => AddrOf(0x80); // 
        public FloatRange WorkingRange => new FloatRange(AddrOf(0xD0));
        public FloatRange ViewRange => new FloatRange(AddrOf(0xE0));
    }

    public class MovieSceneExpansionState : StructProxy
    {
        public MovieSceneExpansionState(System.IntPtr ptr) : base(ptr) {}
        public bool bExpanded { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class MovieSceneMarkedFrame : StructProxy
    {
        public MovieSceneMarkedFrame(System.IntPtr ptr) : base(ptr) {}
        public FrameNumber FrameNumber => new FrameNumber(AddrOf(0x0));
        public string Label => Native.ReadFStringAt(AddrOf(0x8)); // FString
    }

    public class MovieSceneTimecodeSource : StructProxy
    {
        public MovieSceneTimecodeSource(System.IntPtr ptr) : base(ptr) {}
        public Timecode Timecode => new Timecode(AddrOf(0x0));
        public FrameNumber DeltaFrame => new FrameNumber(AddrOf(0x14));
    }

    public class MovieSceneBinding : StructProxy
    {
        public MovieSceneBinding(System.IntPtr ptr) : base(ptr) {}
        public Guid ObjectGuid => new Guid(AddrOf(0x0));
        public string BindingName => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public TArray<System.IntPtr> Tracks => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<UObject*>
    }

    public class MovieSceneBindingOverrideData : StructProxy
    {
        public MovieSceneBindingOverrideData(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneObjectBindingID ObjectBindingId => new MovieSceneObjectBindingID(AddrOf(0x0));
        public Object Object { get { var __p = GetAt<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x18, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bOverridesDefault { get => (GetAt<byte>(0x20) & 0xFF) != 0; set { var __b = GetAt<byte>(0x20); SetAt(0x20, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class OptionalMovieSceneBlendType : StructProxy
    {
        public OptionalMovieSceneBlendType(System.IntPtr ptr) : base(ptr) {}
        public EMovieSceneBlendType BlendType { get => (EMovieSceneBlendType)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public bool bIsValid { get => (GetAt<byte>(0x1) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class MovieSceneByteChannel : StructProxy
    {
        public MovieSceneByteChannel(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Times => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public byte DefaultValue { get => GetAt<byte>(0x18); set => SetAt(0x18, value); }
        public bool bHasDefaultValue { get => (GetAt<byte>(0x19) & 0xFF) != 0; set { var __b = GetAt<byte>(0x19); SetAt(0x19, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public TArray<System.IntPtr> Values => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<uint8>
        public Enum Enum { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new Enum(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieSceneEvalTemplatePtr : StructProxy
    {
        public MovieSceneEvalTemplatePtr(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneEmptyStruct : StructProxy
    {
        public MovieSceneEmptyStruct(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneEvaluationField : StructProxy
    {
        public MovieSceneEvaluationField(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Ranges => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> Groups => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<System.IntPtr> MetaData => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<struct>
    }

    public class MovieSceneEvaluationMetaData : StructProxy
    {
        public MovieSceneEvaluationMetaData(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> ActiveSequences => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> ActiveEntities => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public System.IntPtr SubTemplateSerialNumbers => AddrOf(0x20); // 
    }

    public class MovieSceneSequenceID : StructProxy
    {
        public MovieSceneSequenceID(System.IntPtr ptr) : base(ptr) {}
        public uint Value { get => GetAt<uint>(0x0); set => SetAt(0x0, value); }
    }

    public class MovieSceneOrderedEvaluationKey : StructProxy
    {
        public MovieSceneOrderedEvaluationKey(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneEvaluationKey Key => new MovieSceneEvaluationKey(AddrOf(0x0));
        public ushort SetupIndex { get => GetAt<ushort>(0xC); set => SetAt(0xC, value); }
        public ushort TearDownIndex { get => GetAt<ushort>(0xE); set => SetAt(0xE, value); }
    }

    public class MovieSceneEvaluationKey : StructProxy
    {
        public MovieSceneEvaluationKey(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneSequenceID SequenceID => new MovieSceneSequenceID(AddrOf(0x0));
        public MovieSceneTrackIdentifier TrackIdentifier => new MovieSceneTrackIdentifier(AddrOf(0x4));
        public uint SectionIndex { get => GetAt<uint>(0x8); set => SetAt(0x8, value); }
    }

    public class MovieSceneTrackIdentifier : StructProxy
    {
        public MovieSceneTrackIdentifier(System.IntPtr ptr) : base(ptr) {}
        public uint Value { get => GetAt<uint>(0x0); set => SetAt(0x0, value); }
    }

    public class MovieSceneEvaluationGroup : StructProxy
    {
        public MovieSceneEvaluationGroup(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> LUTIndices => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> SegmentPtrLUT => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
    }

    public class MovieSceneEvaluationFieldTrackPtr : StructProxy
    {
        public MovieSceneEvaluationFieldTrackPtr(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneSequenceID SequenceID => new MovieSceneSequenceID(AddrOf(0x0));
        public MovieSceneTrackIdentifier TrackIdentifier => new MovieSceneTrackIdentifier(AddrOf(0x4));
    }

    public class MovieSceneEvaluationFieldSegmentPtr : StructProxy
    {
        public MovieSceneEvaluationFieldSegmentPtr(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneSegmentIdentifier SegmentID => new MovieSceneSegmentIdentifier(AddrOf(0x8));
    }

    public class MovieSceneSegmentIdentifier : StructProxy
    {
        public MovieSceneSegmentIdentifier(System.IntPtr ptr) : base(ptr) {}
        public int IdentifierIndex { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
    }

    public class MovieSceneEvaluationGroupLUTIndex : StructProxy
    {
        public MovieSceneEvaluationGroupLUTIndex(System.IntPtr ptr) : base(ptr) {}
        public int LUTOffset { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int NumInitPtrs { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int NumEvalPtrs { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
    }

    public class MovieSceneFrameRange : StructProxy
    {
        public MovieSceneFrameRange(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneEvaluationOperand : StructProxy
    {
        public MovieSceneEvaluationOperand(System.IntPtr ptr) : base(ptr) {}
        public Guid ObjectBindingId => new Guid(AddrOf(0x0));
        public MovieSceneSequenceID SequenceID => new MovieSceneSequenceID(AddrOf(0x10));
    }

    public class MovieSceneEvaluationTemplate : StructProxy
    {
        public MovieSceneEvaluationTemplate(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr Tracks => AddrOf(0x0); // 
        public MovieSceneEvaluationField EvaluationField => new MovieSceneEvaluationField(AddrOf(0xA0));
        public MovieSceneSequenceHierarchy Hierarchy => new MovieSceneSequenceHierarchy(AddrOf(0xD0));
        public Guid SequenceSignature => new Guid(AddrOf(0x170));
        public MovieSceneEvaluationTemplateSerialNumber TemplateSerialNumber => new MovieSceneEvaluationTemplateSerialNumber(AddrOf(0x180));
        public MovieSceneTemplateGenerationLedger TemplateLedger => new MovieSceneTemplateGenerationLedger(AddrOf(0x188));
        public MovieSceneTrackFieldData TrackFieldData => new MovieSceneTrackFieldData(AddrOf(0x230));
        public MovieSceneSubSectionFieldData SubSectionFieldData => new MovieSceneSubSectionFieldData(AddrOf(0x290));
    }

    public class MovieSceneSubSectionFieldData : StructProxy
    {
        public MovieSceneSubSectionFieldData(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneTrackFieldData : StructProxy
    {
        public MovieSceneTrackFieldData(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneTemplateGenerationLedger : StructProxy
    {
        public MovieSceneTemplateGenerationLedger(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneTrackIdentifier LastTrackIdentifier => new MovieSceneTrackIdentifier(AddrOf(0x0));
        public System.IntPtr TrackSignatureToTrackIdentifier => AddrOf(0x8); // 
        public System.IntPtr SubSectionRanges => AddrOf(0x58); // 
    }

    public class MovieSceneEvaluationTemplateSerialNumber : StructProxy
    {
        public MovieSceneEvaluationTemplateSerialNumber(System.IntPtr ptr) : base(ptr) {}
        public uint Value { get => GetAt<uint>(0x0); set => SetAt(0x0, value); }
    }

    public class MovieSceneSequenceHierarchy : StructProxy
    {
        public MovieSceneSequenceHierarchy(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr SubSequences => AddrOf(0x0); // 
        public System.IntPtr Hierarchy => AddrOf(0x50); // 
    }

    public class MovieSceneSequenceHierarchyNode : StructProxy
    {
        public MovieSceneSequenceHierarchyNode(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneSequenceID ParentId => new MovieSceneSequenceID(AddrOf(0x0));
        public TArray<System.IntPtr> Children => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
    }

    public class MovieSceneSubSequenceData : StructProxy
    {
        public MovieSceneSubSequenceData(System.IntPtr ptr) : base(ptr) {}
        public SoftObjectPath Sequence => new SoftObjectPath(AddrOf(0x0));
        public MovieSceneSequenceTransform RootToSequenceTransform => new MovieSceneSequenceTransform(AddrOf(0x18));
        public FrameRate TickResolution => new FrameRate(AddrOf(0x38));
        public MovieSceneSequenceID DeterministicSequenceID => new MovieSceneSequenceID(AddrOf(0x40));
        public MovieSceneFrameRange PlayRange => new MovieSceneFrameRange(AddrOf(0x44));
        public MovieSceneFrameRange FullPlayRange => new MovieSceneFrameRange(AddrOf(0x54));
        public MovieSceneFrameRange UnwarpedPlayRange => new MovieSceneFrameRange(AddrOf(0x64));
        public MovieSceneFrameRange PreRollRange => new MovieSceneFrameRange(AddrOf(0x74));
        public MovieSceneFrameRange PostRollRange => new MovieSceneFrameRange(AddrOf(0x84));
        public int HierarchicalBias { get => GetAt<int>(0x94); set => SetAt(0x94, value); }
        public MovieSceneSequenceInstanceDataPtr InstanceData => new MovieSceneSequenceInstanceDataPtr(AddrOf(0x98));
        public Guid SubSectionSignature => new Guid(AddrOf(0xB8));
        public MovieSceneSequenceTransform OuterToInnerTransform => new MovieSceneSequenceTransform(AddrOf(0xC8));
    }

    public class MovieSceneSequenceTransform : StructProxy
    {
        public MovieSceneSequenceTransform(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneTimeTransform LinearTransform => new MovieSceneTimeTransform(AddrOf(0x0));
        public TArray<System.IntPtr> NestedTransforms => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
    }

    public class MovieSceneNestedSequenceTransform : StructProxy
    {
        public MovieSceneNestedSequenceTransform(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneTimeTransform LinearTransform => new MovieSceneTimeTransform(AddrOf(0x0));
        public MovieSceneTimeWarping Warping => new MovieSceneTimeWarping(AddrOf(0xC));
    }

    public class MovieSceneTimeWarping : StructProxy
    {
        public MovieSceneTimeWarping(System.IntPtr ptr) : base(ptr) {}
        public FrameNumber Start => new FrameNumber(AddrOf(0x0));
        public FrameNumber End => new FrameNumber(AddrOf(0x4));
    }

    public class MovieSceneTimeTransform : StructProxy
    {
        public MovieSceneTimeTransform(System.IntPtr ptr) : base(ptr) {}
        public float TimeScale { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public FrameTime Offset => new FrameTime(AddrOf(0x4));
    }

    public class MovieSceneSequenceInstanceDataPtr : StructProxy
    {
        public MovieSceneSequenceInstanceDataPtr(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneEvaluationTrack : StructProxy
    {
        public MovieSceneEvaluationTrack(System.IntPtr ptr) : base(ptr) {}
        public Guid ObjectBindingId => new Guid(AddrOf(0x0));
        public ushort EvaluationPriority { get => GetAt<ushort>(0x10); set => SetAt(0x10, value); }
        public EEvaluationMethod EvaluationMethod { get => (EEvaluationMethod)GetAt<byte>(0x12); set => SetAt(0x12, (byte)value); }
        public MovieSceneEvaluationTrackSegments Segments => new MovieSceneEvaluationTrackSegments(AddrOf(0x18));
        public MovieSceneTrack SourceTrack { get { var __p = GetAt<System.IntPtr>(0x38); return __p==System.IntPtr.Zero?null:new MovieSceneTrack(__p); } set => SetAt(0x38, value?.Pointer ?? System.IntPtr.Zero); }
        public SectionEvaluationDataTree EvaluationTree => new SectionEvaluationDataTree(AddrOf(0x40));
        public TArray<System.IntPtr> ChildTemplates => new TArray<System.IntPtr>(AddrOf(0xA0)); // TArray<struct>
        public MovieSceneTrackImplementationPtr TrackTemplate => new MovieSceneTrackImplementationPtr(AddrOf(0xB0));
        public string EvaluationGroup => Native.FNameToString(GetAt<int>(0xE8)); // FName
        public FName EvaluationGroup_Raw { get => GetAt<FName>(0xE8); set => SetAt(0xE8, value); }
        public bool bEvaluateInPreroll { get => (GetAt<byte>(0xF0) & 0x1) != 0; set { var __b = GetAt<byte>(0xF0); SetAt(0xF0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bEvaluateInPostroll { get => (GetAt<byte>(0xF0) & 0x2) != 0; set { var __b = GetAt<byte>(0xF0); SetAt(0xF0, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bTearDownPriority { get => (GetAt<byte>(0xF0) & 0x4) != 0; set { var __b = GetAt<byte>(0xF0); SetAt(0xF0, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
    }

    public class MovieSceneTrackImplementationPtr : StructProxy
    {
        public MovieSceneTrackImplementationPtr(System.IntPtr ptr) : base(ptr) {}
    }

    public class SectionEvaluationDataTree : StructProxy
    {
        public SectionEvaluationDataTree(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneEvaluationTrackSegments : StructProxy
    {
        public MovieSceneEvaluationTrackSegments(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> SegmentIdentifierToIndex => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<int32>
        public TArray<System.IntPtr> SortedSegments => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
    }

    public class MovieSceneSegment : StructProxy
    {
        public MovieSceneSegment(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneSubSectionData : StructProxy
    {
        public MovieSceneSubSectionData(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneSubSection Section { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MovieSceneSubSection(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public Guid ObjectBindingId => new Guid(AddrOf(0x8));
        public ESectionEvaluationFlags Flags { get => (ESectionEvaluationFlags)GetAt<byte>(0x18); set => SetAt(0x18, (byte)value); }
    }

    public class MovieSceneRootEvaluationTemplateInstance : StructProxy
    {
        public MovieSceneRootEvaluationTemplateInstance(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr DirectorInstances => AddrOf(0x18); // 
    }

    public class MovieSceneKeyStruct : StructProxy
    {
        public MovieSceneKeyStruct(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneKeyTimeStruct : StructProxy
    {
        public MovieSceneKeyTimeStruct(System.IntPtr ptr) : base(ptr) {}
        public FrameNumber Time => new FrameNumber(AddrOf(0x8));
    }

    public class GeneratedMovieSceneKeyStruct : StructProxy
    {
        public GeneratedMovieSceneKeyStruct(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneObjectPathChannel : StructProxy
    {
        public MovieSceneObjectPathChannel(System.IntPtr ptr) : base(ptr) {}
        public Object PropertyClass { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> Times => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<System.IntPtr> Values => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<struct>
        public MovieSceneObjectPathChannelKeyValue DefaultValue => new MovieSceneObjectPathChannelKeyValue(AddrOf(0x30));
    }

    public class MovieSceneObjectPathChannelKeyValue : StructProxy
    {
        public MovieSceneObjectPathChannelKeyValue(System.IntPtr ptr) : base(ptr) {}
        public Object SoftPtr { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public Object HardPtr { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieScenePossessable : StructProxy
    {
        public MovieScenePossessable(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Tags => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<FName>
        public Guid Guid => new Guid(AddrOf(0x10));
        public string Name => Native.ReadFStringAt(AddrOf(0x20)); // FString
        public Object PossessedObjectClass { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public Guid ParentGuid => new Guid(AddrOf(0x38));
    }

    public class MovieScenePropertySectionTemplate : StructProxy
    {
        public MovieScenePropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieScenePropertySectionData PropertyData => new MovieScenePropertySectionData(AddrOf(0x18));
    }

    public class MovieScenePropertySectionData : StructProxy
    {
        public MovieScenePropertySectionData(System.IntPtr ptr) : base(ptr) {}
        public string PropertyName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName PropertyName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string PropertyPath => Native.ReadFStringAt(AddrOf(0x8)); // FString
        public string FunctionName => Native.FNameToString(GetAt<int>(0x18)); // FName
        public FName FunctionName_Raw { get => GetAt<FName>(0x18); set => SetAt(0x18, value); }
        public string NotifyFunctionName => Native.FNameToString(GetAt<int>(0x20)); // FName
        public FName NotifyFunctionName_Raw { get => GetAt<FName>(0x20); set => SetAt(0x20, value); }
    }

    public class MovieSceneEasingSettings : StructProxy
    {
        public MovieSceneEasingSettings(System.IntPtr ptr) : base(ptr) {}
        public int AutoEaseInDuration { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int AutoEaseOutDuration { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public UObject EaseIn { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bManualEaseIn { get => (GetAt<byte>(0x18) & 0xFF) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int ManualEaseInDuration { get => GetAt<int>(0x1C); set => SetAt(0x1C, value); }
        public UObject EaseOut { get { var __p = GetAt<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x20, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bManualEaseOut { get => (GetAt<byte>(0x30) & 0xFF) != 0; set { var __b = GetAt<byte>(0x30); SetAt(0x30, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int ManualEaseOutDuration { get => GetAt<int>(0x34); set => SetAt(0x34, value); }
    }

    public class MovieSceneSectionEvalOptions : StructProxy
    {
        public MovieSceneSectionEvalOptions(System.IntPtr ptr) : base(ptr) {}
        public bool bCanEditCompletionMode { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public EMovieSceneCompletionMode CompletionMode { get => (EMovieSceneCompletionMode)GetAt<byte>(0x1); set => SetAt(0x1, (byte)value); }
    }

    public class MovieSceneSectionParameters : StructProxy
    {
        public MovieSceneSectionParameters(System.IntPtr ptr) : base(ptr) {}
        public FrameNumber StartFrameOffset => new FrameNumber(AddrOf(0x0));
        public bool bCanLoop { get => (GetAt<byte>(0x4) & 0xFF) != 0; set { var __b = GetAt<byte>(0x4); SetAt(0x4, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public FrameNumber EndFrameOffset => new FrameNumber(AddrOf(0x8));
        public FrameNumber FirstLoopStartFrameOffset => new FrameNumber(AddrOf(0xC));
        public float TimeScale { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public int HierarchicalBias { get => GetAt<int>(0x14); set => SetAt(0x14, value); }
        public float StartOffset { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
        public float PrerollTime { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public float PostrollTime { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
    }

    public class SectionEvaluationData : StructProxy
    {
        public SectionEvaluationData(System.IntPtr ptr) : base(ptr) {}
        public int ImplIndex { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public FrameNumber ForcedTime => new FrameNumber(AddrOf(0x4));
        public ESectionEvaluationFlags Flags { get => (ESectionEvaluationFlags)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
    }

    public class MovieSceneSequenceInstanceData : StructProxy
    {
        public MovieSceneSequenceInstanceData(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneSequencePlaybackSettings : StructProxy
    {
        public MovieSceneSequencePlaybackSettings(System.IntPtr ptr) : base(ptr) {}
        public bool bAutoPlay { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public MovieSceneSequenceLoopCount LoopCount => new MovieSceneSequenceLoopCount(AddrOf(0x4));
        public float PlayRate { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float StartTime { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public bool bRandomStartTime { get => (GetAt<byte>(0x10) & 0x1) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bRestoreState { get => (GetAt<byte>(0x10) & 0x2) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bDisableMovementInput { get => (GetAt<byte>(0x10) & 0x4) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bDisableLookAtInput { get => (GetAt<byte>(0x10) & 0x8) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bHidePlayer { get => (GetAt<byte>(0x10) & 0x10) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bHideHud { get => (GetAt<byte>(0x10) & 0x20) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool bDisableCameraCuts { get => (GetAt<byte>(0x10) & 0x40) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
        public bool bPauseAtEnd { get => (GetAt<byte>(0x10) & 0x80) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x80) : (__b & ~0x80))); } }
    }

    public class MovieSceneSequenceLoopCount : StructProxy
    {
        public MovieSceneSequenceLoopCount(System.IntPtr ptr) : base(ptr) {}
        public int Value { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
    }

    public class MovieSceneSequenceReplProperties : StructProxy
    {
        public MovieSceneSequenceReplProperties(System.IntPtr ptr) : base(ptr) {}
        public FrameTime LastKnownPosition => new FrameTime(AddrOf(0x0));
        public byte LastKnownStatus { get => GetAt<byte>(0x8); set => SetAt(0x8, value); }
        public int LastKnownNumLoops { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
    }

    public class MovieSceneWarpCounter : StructProxy
    {
        public MovieSceneWarpCounter(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> WarpCounts => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<uint32>
    }

    public class MovieSceneSpawnable : StructProxy
    {
        public MovieSceneSpawnable(System.IntPtr ptr) : base(ptr) {}
        public Transform SpawnTransform => new Transform(AddrOf(0x0));
        public TArray<System.IntPtr> Tags => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<FName>
        public bool bContinuouslyRespawn { get => (GetAt<byte>(0x40) & 0xFF) != 0; set { var __b = GetAt<byte>(0x40); SetAt(0x40, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public Guid Guid => new Guid(AddrOf(0x44));
        public string Name => Native.ReadFStringAt(AddrOf(0x58)); // FString
        public Object ObjectTemplate { get { var __p = GetAt<System.IntPtr>(0x68); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x68, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> ChildPossessables => new TArray<System.IntPtr>(AddrOf(0x70)); // TArray<struct>
        public ESpawnOwnership Ownership { get => (ESpawnOwnership)GetAt<byte>(0x80); set => SetAt(0x80, (byte)value); }
        public string LevelName => Native.FNameToString(GetAt<int>(0x84)); // FName
        public FName LevelName_Raw { get => GetAt<FName>(0x84); set => SetAt(0x84, value); }
    }

    public class TestMovieSceneEvalTemplate : StructProxy
    {
        public TestMovieSceneEvalTemplate(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneTrackDisplayOptions : StructProxy
    {
        public MovieSceneTrackDisplayOptions(System.IntPtr ptr) : base(ptr) {}
        public bool bShowVerticalFrames { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class MovieSceneTrackEvalOptions : StructProxy
    {
        public MovieSceneTrackEvalOptions(System.IntPtr ptr) : base(ptr) {}
        public bool bCanEvaluateNearestSection { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bEvalNearestSection { get => (GetAt<byte>(0x0) & 0x2) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bEvaluateInPreroll { get => (GetAt<byte>(0x0) & 0x4) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bEvaluateInPostroll { get => (GetAt<byte>(0x0) & 0x8) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bEvaluateNearestSection { get => (GetAt<byte>(0x0) & 0x10) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
    }

    public class MovieSceneSignedObject : Object
    {
        public const string UeClassName = "MovieSceneSignedObject";
        public MovieSceneSignedObject(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSignedObject FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSignedObject(p);
        public static MovieSceneSignedObject FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSignedObject(o.Pointer); }
        public static MovieSceneSignedObject[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSignedObject[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSignedObject(a[i].Pointer); return r; }
        public Guid Signature => new Guid(AddrOf(0x28));
    }

    public class MovieSceneSection : MovieSceneSignedObject
    {
        public const string UeClassName = "MovieSceneSection";
        public MovieSceneSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSection(p);
        public static MovieSceneSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSection(o.Pointer); }
        public static MovieSceneSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSection(a[i].Pointer); return r; }
        public MovieSceneSectionEvalOptions EvalOptions => new MovieSceneSectionEvalOptions(AddrOf(0x50));
        public MovieSceneEasingSettings Easing => new MovieSceneEasingSettings(AddrOf(0x58));
        public MovieSceneFrameRange SectionRange => new MovieSceneFrameRange(AddrOf(0x90));
        public FrameNumber PreRollFrames => new FrameNumber(AddrOf(0xA0));
        public FrameNumber PostRollFrames => new FrameNumber(AddrOf(0xA4));
        public int RowIndex { get => GetAt<int>(0xA8); set => SetAt(0xA8, value); }
        public int OverlapPriority { get => GetAt<int>(0xAC); set => SetAt(0xAC, value); }
        public bool bIsActive { get => Native.GetPropBool(Pointer, "bIsActive"); set => Native.SetPropBool(Pointer, "bIsActive", value); }
        public bool bIsLocked { get => Native.GetPropBool(Pointer, "bIsLocked"); set => Native.SetPropBool(Pointer, "bIsLocked", value); }
        public float StartTime { get => GetAt<float>(0xB4); set => SetAt(0xB4, value); }
        public float EndTime { get => GetAt<float>(0xB8); set => SetAt(0xB8, value); }
        public float PrerollTime { get => GetAt<float>(0xBC); set => SetAt(0xBC, value); }
        public float PostrollTime { get => GetAt<float>(0xC0); set => SetAt(0xC0, value); }
        public bool bIsInfinite { get => Native.GetPropBool(Pointer, "bIsInfinite"); set => Native.SetPropBool(Pointer, "bIsInfinite", value); }
        public bool bSupportsInfiniteRange { get => Native.GetPropBool(Pointer, "bSupportsInfiniteRange"); set => Native.SetPropBool(Pointer, "bSupportsInfiniteRange", value); }
        public OptionalMovieSceneBlendType BlendType => new OptionalMovieSceneBlendType(AddrOf(0xC6));
        /// <summary>[Native] thunk RVA 0x7B99958 — hookable via Hooks.InstallAt(NativeFunc_SetRowIndex).</summary>
        public static System.IntPtr NativeFunc_SetRowIndex => Memory.ModuleBase() + 0x7B99958;
        public void SetRowIndex(int NewRowIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewRowIndex);
            CallRaw("SetRowIndex", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B99628 — hookable via Hooks.InstallAt(NativeFunc_SetPreRollFrames).</summary>
        public static System.IntPtr NativeFunc_SetPreRollFrames => Memory.ModuleBase() + 0x7B99628;
        public void SetPreRollFrames(int InPreRollFrames)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InPreRollFrames);
            CallRaw("SetPreRollFrames", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B9955C — hookable via Hooks.InstallAt(NativeFunc_SetPostRollFrames).</summary>
        public static System.IntPtr NativeFunc_SetPostRollFrames => Memory.ModuleBase() + 0x7B9955C;
        public void SetPostRollFrames(int InPostRollFrames)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InPostRollFrames);
            CallRaw("SetPostRollFrames", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B9989C — hookable via Hooks.InstallAt(NativeFunc_SetOverlapPriority).</summary>
        public static System.IntPtr NativeFunc_SetOverlapPriority => Memory.ModuleBase() + 0x7B9989C;
        public void SetOverlapPriority(int NewPriority)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewPriority);
            CallRaw("SetOverlapPriority", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B996F8 — hookable via Hooks.InstallAt(NativeFunc_SetIsLocked).</summary>
        public static System.IntPtr NativeFunc_SetIsLocked => Memory.ModuleBase() + 0x7B996F8;
        public void SetIsLocked(bool bInIsLocked)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInIsLocked?1:0));
            CallRaw("SetIsLocked", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B997CC — hookable via Hooks.InstallAt(NativeFunc_SetIsActive).</summary>
        public static System.IntPtr NativeFunc_SetIsActive => Memory.ModuleBase() + 0x7B997CC;
        public void SetIsActive(bool bInIsActive)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInIsActive?1:0));
            CallRaw("SetIsActive", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B99AC0 — hookable via Hooks.InstallAt(NativeFunc_SetCompletionMode).</summary>
        public static System.IntPtr NativeFunc_SetCompletionMode => Memory.ModuleBase() + 0x7B99AC0;
        public void SetCompletionMode(EMovieSceneCompletionMode InCompletionMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InCompletionMode);
            CallRaw("SetCompletionMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B999F8 — hookable via Hooks.InstallAt(NativeFunc_SetBlendType).</summary>
        public static System.IntPtr NativeFunc_SetBlendType => Memory.ModuleBase() + 0x7B999F8;
        public void SetBlendType(EMovieSceneBlendType InBlendType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InBlendType);
            CallRaw("SetBlendType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B996D8 — hookable via Hooks.InstallAt(NativeFunc_IsLocked).</summary>
        public static System.IntPtr NativeFunc_IsLocked => Memory.ModuleBase() + 0x7B996D8;
        public bool IsLocked()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsLocked", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7B997AC — hookable via Hooks.InstallAt(NativeFunc_IsActive).</summary>
        public static System.IntPtr NativeFunc_IsActive => Memory.ModuleBase() + 0x7B997AC;
        public bool IsActive()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsActive", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7B9993C — hookable via Hooks.InstallAt(NativeFunc_GetRowIndex).</summary>
        public static System.IntPtr NativeFunc_GetRowIndex => Memory.ModuleBase() + 0x7B9993C;
        public int GetRowIndex()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetRowIndex", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7B9960C — hookable via Hooks.InstallAt(NativeFunc_GetPreRollFrames).</summary>
        public static System.IntPtr NativeFunc_GetPreRollFrames => Memory.ModuleBase() + 0x7B9960C;
        public int GetPreRollFrames()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPreRollFrames", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7B99540 — hookable via Hooks.InstallAt(NativeFunc_GetPostRollFrames).</summary>
        public static System.IntPtr NativeFunc_GetPostRollFrames => Memory.ModuleBase() + 0x7B99540;
        public int GetPostRollFrames()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPostRollFrames", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7B99880 — hookable via Hooks.InstallAt(NativeFunc_GetOverlapPriority).</summary>
        public static System.IntPtr NativeFunc_GetOverlapPriority => Memory.ModuleBase() + 0x7B99880;
        public int GetOverlapPriority()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetOverlapPriority", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7B99B60 — hookable via Hooks.InstallAt(NativeFunc_GetCompletionMode).</summary>
        public static System.IntPtr NativeFunc_GetCompletionMode => Memory.ModuleBase() + 0x7B99B60;
        public EMovieSceneCompletionMode GetCompletionMode()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetCompletionMode", __pb.Bytes);
            return (EMovieSceneCompletionMode)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7B99AA4 — hookable via Hooks.InstallAt(NativeFunc_GetBlendType).</summary>
        public static System.IntPtr NativeFunc_GetBlendType => Memory.ModuleBase() + 0x7B99AA4;
        public OptionalMovieSceneBlendType GetBlendType()
        {
            var __pb = new ParamBuffer(2);
            CallRaw("GetBlendType", __pb.Bytes);
            return __pb.Get<OptionalMovieSceneBlendType>(0x0);
        }
    }

    public class MovieSceneTrack : MovieSceneSignedObject
    {
        public const string UeClassName = "MovieSceneTrack";
        public MovieSceneTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneTrack(p);
        public static MovieSceneTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneTrack(o.Pointer); }
        public static MovieSceneTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneTrack(a[i].Pointer); return r; }
        public MovieSceneTrackEvalOptions EvalOptions => new MovieSceneTrackEvalOptions(AddrOf(0x50));
        public bool bIsEvalDisabled { get => Native.GetPropBool(Pointer, "bIsEvalDisabled"); set => Native.SetPropBool(Pointer, "bIsEvalDisabled", value); }
    }

    public class MovieSceneNameableTrack : MovieSceneTrack
    {
        public const string UeClassName = "MovieSceneNameableTrack";
        public MovieSceneNameableTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneNameableTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneNameableTrack(p);
        public static MovieSceneNameableTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneNameableTrack(o.Pointer); }
        public static MovieSceneNameableTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneNameableTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneNameableTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneCustomClockSource : Interface
    {
        public const string UeClassName = "MovieSceneCustomClockSource";
        public MovieSceneCustomClockSource(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCustomClockSource FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneCustomClockSource(p);
        public static MovieSceneCustomClockSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCustomClockSource(o.Pointer); }
        public static MovieSceneCustomClockSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCustomClockSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCustomClockSource(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7B7B6A4 — hookable via Hooks.InstallAt(NativeFunc_OnTick).</summary>
        public static System.IntPtr NativeFunc_OnTick => Memory.ModuleBase() + 0x7B7B6A4;
        public void OnTick(float DeltaSeconds, float InPlayRate)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, DeltaSeconds);
            __pb.Set(0x4, InPlayRate);
            CallRaw("OnTick", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B7B514 — hookable via Hooks.InstallAt(NativeFunc_OnStopPlaying).</summary>
        public static System.IntPtr NativeFunc_OnStopPlaying => Memory.ModuleBase() + 0x7B7B514;
        public void OnStopPlaying(QualifiedFrameTime InStopTime)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InStopTime);
            CallRaw("OnStopPlaying", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B7B5DC — hookable via Hooks.InstallAt(NativeFunc_OnStartPlaying).</summary>
        public static System.IntPtr NativeFunc_OnStartPlaying => Memory.ModuleBase() + 0x7B7B5DC;
        public void OnStartPlaying(QualifiedFrameTime InStartTime)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InStartTime);
            CallRaw("OnStartPlaying", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7B7B3FC — hookable via Hooks.InstallAt(NativeFunc_OnRequestCurrentTime).</summary>
        public static System.IntPtr NativeFunc_OnRequestCurrentTime => Memory.ModuleBase() + 0x7B7B3FC;
        public FrameTime OnRequestCurrentTime(QualifiedFrameTime InCurrentTime, float InPlayRate)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<System.IntPtr>(0x0, InCurrentTime);
            __pb.Set(0x10, InPlayRate);
            CallRaw("OnRequestCurrentTime", __pb.Bytes);
            return __pb.Get<FrameTime>(0x14);
        }
    }

    public class MovieScenePlaybackClient : Interface
    {
        public const string UeClassName = "MovieScenePlaybackClient";
        public MovieScenePlaybackClient(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScenePlaybackClient FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScenePlaybackClient(p);
        public static MovieScenePlaybackClient FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScenePlaybackClient(o.Pointer); }
        public static MovieScenePlaybackClient[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScenePlaybackClient[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScenePlaybackClient(a[i].Pointer); return r; }
    }

    public class MovieScene : MovieSceneSignedObject
    {
        public const string UeClassName = "MovieScene";
        public MovieScene(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene(p);
        public static MovieScene FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene(o.Pointer); }
        public static MovieScene[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Spawnables => new TArray<System.IntPtr>(AddrOf(0x50)); // TArray<struct>
        public TArray<System.IntPtr> Possessables => new TArray<System.IntPtr>(AddrOf(0x60)); // TArray<struct>
        public TArray<System.IntPtr> ObjectBindings => new TArray<System.IntPtr>(AddrOf(0x70)); // TArray<struct>
        public System.IntPtr BindingGroups => AddrOf(0x80); // 
        public TArray<System.IntPtr> MasterTracks => new TArray<System.IntPtr>(AddrOf(0xD0)); // TArray<UObject*>
        public MovieSceneTrack CameraCutTrack { get { var __p = GetAt<System.IntPtr>(0xE0); return __p==System.IntPtr.Zero?null:new MovieSceneTrack(__p); } set => SetAt(0xE0, value?.Pointer ?? System.IntPtr.Zero); }
        public MovieSceneFrameRange SelectionRange => new MovieSceneFrameRange(AddrOf(0xE8));
        public MovieSceneFrameRange PlaybackRange => new MovieSceneFrameRange(AddrOf(0xF8));
        public FrameRate TickResolution => new FrameRate(AddrOf(0x108));
        public FrameRate DisplayRate => new FrameRate(AddrOf(0x110));
        public EMovieSceneEvaluationType EvaluationType { get => (EMovieSceneEvaluationType)GetAt<byte>(0x118); set => SetAt(0x118, (byte)value); }
        public EUpdateClockSource ClockSource { get => (EUpdateClockSource)GetAt<byte>(0x119); set => SetAt(0x119, (byte)value); }
        public SoftObjectPath CustomClockSourcePath => new SoftObjectPath(AddrOf(0x120));
        public TArray<System.IntPtr> MarkedFrames => new TArray<System.IntPtr>(AddrOf(0x138)); // TArray<struct>
    }

    public class MovieSceneBindingOverrides : Object
    {
        public const string UeClassName = "MovieSceneBindingOverrides";
        public MovieSceneBindingOverrides(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneBindingOverrides FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneBindingOverrides(p);
        public static MovieSceneBindingOverrides FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneBindingOverrides(o.Pointer); }
        public static MovieSceneBindingOverrides[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneBindingOverrides[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneBindingOverrides(a[i].Pointer); return r; }
        public TArray<System.IntPtr> BindingData => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
    }

    public class MovieSceneBindingOwnerInterface : Interface
    {
        public const string UeClassName = "MovieSceneBindingOwnerInterface";
        public MovieSceneBindingOwnerInterface(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneBindingOwnerInterface FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneBindingOwnerInterface(p);
        public static MovieSceneBindingOwnerInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneBindingOwnerInterface(o.Pointer); }
        public static MovieSceneBindingOwnerInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneBindingOwnerInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneBindingOwnerInterface(a[i].Pointer); return r; }
    }

    public class MovieSceneBuiltInEasingFunction : Object
    {
        public const string UeClassName = "MovieSceneBuiltInEasingFunction";
        public MovieSceneBuiltInEasingFunction(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneBuiltInEasingFunction FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneBuiltInEasingFunction(p);
        public static MovieSceneBuiltInEasingFunction FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneBuiltInEasingFunction(o.Pointer); }
        public static MovieSceneBuiltInEasingFunction[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneBuiltInEasingFunction[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneBuiltInEasingFunction(a[i].Pointer); return r; }
        public EMovieSceneBuiltInEasing Type { get => (EMovieSceneBuiltInEasing)GetAt<byte>(0x30); set => SetAt(0x30, (byte)value); }
    }

    public class MovieSceneEasingExternalCurve : Object
    {
        public const string UeClassName = "MovieSceneEasingExternalCurve";
        public MovieSceneEasingExternalCurve(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEasingExternalCurve FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEasingExternalCurve(p);
        public static MovieSceneEasingExternalCurve FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEasingExternalCurve(o.Pointer); }
        public static MovieSceneEasingExternalCurve[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEasingExternalCurve[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEasingExternalCurve(a[i].Pointer); return r; }
        public CurveFloat Curve { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieSceneEasingFunction : Interface
    {
        public const string UeClassName = "MovieSceneEasingFunction";
        public MovieSceneEasingFunction(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEasingFunction FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEasingFunction(p);
        public static MovieSceneEasingFunction FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEasingFunction(o.Pointer); }
        public static MovieSceneEasingFunction[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEasingFunction[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEasingFunction(a[i].Pointer); return r; }
        public float OnEvaluate(float Interp)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Interp);
            CallRaw("OnEvaluate", __pb.Bytes);
            return __pb.Get<float>(0x4);
        }
    }

    public class MovieSceneFolder : Object
    {
        public const string UeClassName = "MovieSceneFolder";
        public MovieSceneFolder(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneFolder FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneFolder(p);
        public static MovieSceneFolder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneFolder(o.Pointer); }
        public static MovieSceneFolder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneFolder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneFolder(a[i].Pointer); return r; }
        public string FolderName => Native.GetPropName(Pointer, "FolderName"); // FName
        public FName FolderName_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
        public TArray<System.IntPtr> ChildFolders => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<UObject*>
        public TArray<System.IntPtr> ChildMasterTracks => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<UObject*>
        public TArray<System.IntPtr> ChildObjectBindingStrings => new TArray<System.IntPtr>(AddrOf(0x50)); // TArray<FString>
    }

    public class MovieSceneKeyProxy : Interface
    {
        public const string UeClassName = "MovieSceneKeyProxy";
        public MovieSceneKeyProxy(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneKeyProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneKeyProxy(p);
        public static MovieSceneKeyProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneKeyProxy(o.Pointer); }
        public static MovieSceneKeyProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneKeyProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneKeyProxy(a[i].Pointer); return r; }
    }

    public class MovieSceneSequence : MovieSceneSignedObject
    {
        public const string UeClassName = "MovieSceneSequence";
        public MovieSceneSequence(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSequence FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSequence(p);
        public static MovieSceneSequence FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSequence(o.Pointer); }
        public static MovieSceneSequence[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSequence[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSequence(a[i].Pointer); return r; }
        public MovieSceneEvaluationTemplate PrecompiledEvaluationTemplate => new MovieSceneEvaluationTemplate(AddrOf(0x50));
        public EMovieSceneCompletionMode DefaultCompletionMode { get => (EMovieSceneCompletionMode)GetAt<byte>(0x340); set => SetAt(0x340, (byte)value); }
        public bool bParentContextsAreSignificant { get => Native.GetPropBool(Pointer, "bParentContextsAreSignificant"); set => Native.SetPropBool(Pointer, "bParentContextsAreSignificant", value); }
        public bool bPlayableDirectly { get => Native.GetPropBool(Pointer, "bPlayableDirectly"); set => Native.SetPropBool(Pointer, "bPlayableDirectly", value); }
        /// <summary>[Native] thunk RVA 0x7B9CAA4 — hookable via Hooks.InstallAt(NativeFunc_FindBindingsByTag).</summary>
        public static System.IntPtr NativeFunc_FindBindingsByTag => Memory.ModuleBase() + 0x7B9CAA4;
        public System.IntPtr FindBindingsByTag(FName InBindingName)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, InBindingName);
            CallRaw("FindBindingsByTag", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7B9CBA0 — hookable via Hooks.InstallAt(NativeFunc_FindBindingByTag).</summary>
        public static System.IntPtr NativeFunc_FindBindingByTag => Memory.ModuleBase() + 0x7B9CBA0;
        public MovieSceneObjectBindingID FindBindingByTag(FName InBindingName)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set(0x0, InBindingName);
            CallRaw("FindBindingByTag", __pb.Bytes);
            return __pb.Get<MovieSceneObjectBindingID>(0x8);
        }
    }

    public class MovieSceneSequencePlayer : Object
    {
        public const string UeClassName = "MovieSceneSequencePlayer";
        public MovieSceneSequencePlayer(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSequencePlayer FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSequencePlayer(p);
        public static MovieSceneSequencePlayer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSequencePlayer(o.Pointer); }
        public static MovieSceneSequencePlayer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSequencePlayer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSequencePlayer(a[i].Pointer); return r; }
        public System.IntPtr OnPlay => AddrOf(0x408); // 
        public System.IntPtr OnPlayReverse => AddrOf(0x418); // 
        public System.IntPtr OnStop => AddrOf(0x428); // 
        public System.IntPtr OnPause => AddrOf(0x438); // 
        public System.IntPtr OnFinished => AddrOf(0x448); // 
        public byte Status { get => GetAt<byte>(0x458); set => SetAt(0x458, value); }
        public bool bReversePlayback { get => Native.GetPropBool(Pointer, "bReversePlayback"); set => Native.SetPropBool(Pointer, "bReversePlayback", value); }
        public MovieSceneSequence Sequence { get { var __p = GetAt<System.IntPtr>(0x460); return __p==System.IntPtr.Zero?null:new MovieSceneSequence(__p); } set => SetAt(0x460, value?.Pointer ?? System.IntPtr.Zero); }
        public FrameNumber StartTime => new FrameNumber(AddrOf(0x468));
        public int DurationFrames { get => GetAt<int>(0x46C); set => SetAt(0x46C, value); }
        public int CurrentNumLoops { get => GetAt<int>(0x470); set => SetAt(0x470, value); }
        public MovieSceneSequencePlaybackSettings PlaybackSettings => new MovieSceneSequencePlaybackSettings(AddrOf(0x488));
        public MovieSceneRootEvaluationTemplateInstance RootTemplateInstance => new MovieSceneRootEvaluationTemplateInstance(AddrOf(0x4A0));
        public MovieSceneSequenceReplProperties NetSyncProps => new MovieSceneSequenceReplProperties(AddrOf(0x828));
        public UObject PlaybackClient { get { var __p = GetAt<System.IntPtr>(0x838); return __p==System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x838, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x7BA161C — hookable via Hooks.InstallAt(NativeFunc_StopAtCurrentTime).</summary>
        public static System.IntPtr NativeFunc_StopAtCurrentTime => Memory.ModuleBase() + 0x7BA161C;
        public void StopAtCurrentTime()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopAtCurrentTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA1630 — hookable via Hooks.InstallAt(NativeFunc_Stop).</summary>
        public static System.IntPtr NativeFunc_Stop => Memory.ModuleBase() + 0x7BA1630;
        public void Stop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Stop", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA0E7C — hookable via Hooks.InstallAt(NativeFunc_SetTimeRange).</summary>
        public static System.IntPtr NativeFunc_SetTimeRange => Memory.ModuleBase() + 0x7BA0E7C;
        public void SetTimeRange(float StartTime, float Duration)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, StartTime);
            __pb.Set(0x4, Duration);
            CallRaw("SetTimeRange", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA06F0 — hookable via Hooks.InstallAt(NativeFunc_SetPlayRate).</summary>
        public static System.IntPtr NativeFunc_SetPlayRate => Memory.ModuleBase() + 0x7BA06F0;
        public void SetPlayRate(float PlayRate)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, PlayRate);
            CallRaw("SetPlayRate", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA1294 — hookable via Hooks.InstallAt(NativeFunc_SetPlaybackRange).</summary>
        public static System.IntPtr NativeFunc_SetPlaybackRange => Memory.ModuleBase() + 0x7BA1294;
        public void SetPlaybackRange(float NewStartTime, float NewEndTime)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NewStartTime);
            __pb.Set(0x4, NewEndTime);
            CallRaw("SetPlaybackRange", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA1378 — hookable via Hooks.InstallAt(NativeFunc_SetPlaybackPosition).</summary>
        public static System.IntPtr NativeFunc_SetPlaybackPosition => Memory.ModuleBase() + 0x7BA1378;
        public void SetPlaybackPosition(float NewPlaybackPosition)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewPlaybackPosition);
            CallRaw("SetPlaybackPosition", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA108C — hookable via Hooks.InstallAt(NativeFunc_SetFrameRate).</summary>
        public static System.IntPtr NativeFunc_SetFrameRate => Memory.ModuleBase() + 0x7BA108C;
        public void SetFrameRate(FrameRate FrameRate)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, FrameRate);
            CallRaw("SetFrameRate", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA0F60 — hookable via Hooks.InstallAt(NativeFunc_SetFrameRange).</summary>
        public static System.IntPtr NativeFunc_SetFrameRange => Memory.ModuleBase() + 0x7BA0F60;
        public void SetFrameRange(int StartFrame, int Duration)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, StartFrame);
            __pb.Set(0x4, Duration);
            CallRaw("SetFrameRange", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA063C — hookable via Hooks.InstallAt(NativeFunc_SetDisableCameraCuts).</summary>
        public static System.IntPtr NativeFunc_SetDisableCameraCuts => Memory.ModuleBase() + 0x7BA063C;
        public void SetDisableCameraCuts(bool bInDisableCameraCuts)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInDisableCameraCuts?1:0));
            CallRaw("SetDisableCameraCuts", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA0B48 — hookable via Hooks.InstallAt(NativeFunc_ScrubToSeconds).</summary>
        public static System.IntPtr NativeFunc_ScrubToSeconds => Memory.ModuleBase() + 0x7BA0B48;
        public void ScrubToSeconds(float TimeInSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, TimeInSeconds);
            CallRaw("ScrubToSeconds", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA092C — hookable via Hooks.InstallAt(NativeFunc_ScrubToMarkedFrame).</summary>
        public static System.IntPtr NativeFunc_ScrubToMarkedFrame => Memory.ModuleBase() + 0x7BA092C;
        public bool ScrubToMarkedFrame(System.IntPtr InLabel)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, InLabel);
            CallRaw("ScrubToMarkedFrame", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7BA0D34 — hookable via Hooks.InstallAt(NativeFunc_ScrubToFrame).</summary>
        public static System.IntPtr NativeFunc_ScrubToFrame => Memory.ModuleBase() + 0x7BA0D34;
        public void ScrubToFrame(FrameTime NewPosition)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, NewPosition);
            CallRaw("ScrubToFrame", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA1644 — hookable via Hooks.InstallAt(NativeFunc_Scrub).</summary>
        public static System.IntPtr NativeFunc_Scrub => Memory.ModuleBase() + 0x7BA1644;
        public void Scrub()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Scrub", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA026C — hookable via Hooks.InstallAt(NativeFunc_RPC_OnStopEvent).</summary>
        public static System.IntPtr NativeFunc_RPC_OnStopEvent => Memory.ModuleBase() + 0x7BA026C;
        public void RPC_OnStopEvent(FrameTime StoppedTime)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, StoppedTime);
            CallRaw("RPC_OnStopEvent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA0318 — hookable via Hooks.InstallAt(NativeFunc_RPC_ExplicitServerUpdateEvent).</summary>
        public static System.IntPtr NativeFunc_RPC_ExplicitServerUpdateEvent => Memory.ModuleBase() + 0x7BA0318;
        public void RPC_ExplicitServerUpdateEvent(EUpdatePositionMethod Method, FrameTime RelevantTime)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<byte>(0x0, (byte)Method);
            __pb.Set<System.IntPtr>(0x4, RelevantTime);
            CallRaw("RPC_ExplicitServerUpdateEvent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA0BEC — hookable via Hooks.InstallAt(NativeFunc_PlayToSeconds).</summary>
        public static System.IntPtr NativeFunc_PlayToSeconds => Memory.ModuleBase() + 0x7BA0BEC;
        public void PlayToSeconds(float TimeInSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, TimeInSeconds);
            CallRaw("PlayToSeconds", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA09E8 — hookable via Hooks.InstallAt(NativeFunc_PlayToMarkedFrame).</summary>
        public static System.IntPtr NativeFunc_PlayToMarkedFrame => Memory.ModuleBase() + 0x7BA09E8;
        public bool PlayToMarkedFrame(System.IntPtr InLabel)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, InLabel);
            CallRaw("PlayToMarkedFrame", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7BA0DD8 — hookable via Hooks.InstallAt(NativeFunc_PlayToFrame).</summary>
        public static System.IntPtr NativeFunc_PlayToFrame => Memory.ModuleBase() + 0x7BA0DD8;
        public void PlayToFrame(FrameTime NewPosition)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, NewPosition);
            CallRaw("PlayToFrame", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA1724 — hookable via Hooks.InstallAt(NativeFunc_PlayReverse).</summary>
        public static System.IntPtr NativeFunc_PlayReverse => Memory.ModuleBase() + 0x7BA1724;
        public void PlayReverse()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayReverse", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA166C — hookable via Hooks.InstallAt(NativeFunc_PlayLooping).</summary>
        public static System.IntPtr NativeFunc_PlayLooping => Memory.ModuleBase() + 0x7BA166C;
        public void PlayLooping(int NumLoops)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumLoops);
            CallRaw("PlayLooping", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA1738 — hookable via Hooks.InstallAt(NativeFunc_Play).</summary>
        public static System.IntPtr NativeFunc_Play => Memory.ModuleBase() + 0x7BA1738;
        public void Play()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Play", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA1658 — hookable via Hooks.InstallAt(NativeFunc_Pause).</summary>
        public static System.IntPtr NativeFunc_Pause => Memory.ModuleBase() + 0x7BA1658;
        public void Pause()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Pause", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA0AA4 — hookable via Hooks.InstallAt(NativeFunc_JumpToSeconds).</summary>
        public static System.IntPtr NativeFunc_JumpToSeconds => Memory.ModuleBase() + 0x7BA0AA4;
        public void JumpToSeconds(float TimeInSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, TimeInSeconds);
            CallRaw("JumpToSeconds", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA11F0 — hookable via Hooks.InstallAt(NativeFunc_JumpToPosition).</summary>
        public static System.IntPtr NativeFunc_JumpToPosition => Memory.ModuleBase() + 0x7BA11F0;
        public void JumpToPosition(float NewPlaybackPosition)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewPlaybackPosition);
            CallRaw("JumpToPosition", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA0870 — hookable via Hooks.InstallAt(NativeFunc_JumpToMarkedFrame).</summary>
        public static System.IntPtr NativeFunc_JumpToMarkedFrame => Memory.ModuleBase() + 0x7BA0870;
        public bool JumpToMarkedFrame(System.IntPtr InLabel)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, InLabel);
            CallRaw("JumpToMarkedFrame", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7BA0C90 — hookable via Hooks.InstallAt(NativeFunc_JumpToFrame).</summary>
        public static System.IntPtr NativeFunc_JumpToFrame => Memory.ModuleBase() + 0x7BA0C90;
        public void JumpToFrame(FrameTime NewPosition)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, NewPosition);
            CallRaw("JumpToFrame", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA07C8 — hookable via Hooks.InstallAt(NativeFunc_IsReversed).</summary>
        public static System.IntPtr NativeFunc_IsReversed => Memory.ModuleBase() + 0x7BA07C8;
        public bool IsReversed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsReversed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7BA0838 — hookable via Hooks.InstallAt(NativeFunc_IsPlaying).</summary>
        public static System.IntPtr NativeFunc_IsPlaying => Memory.ModuleBase() + 0x7BA0838;
        public bool IsPlaying()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPlaying", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7BA0800 — hookable via Hooks.InstallAt(NativeFunc_IsPaused).</summary>
        public static System.IntPtr NativeFunc_IsPaused => Memory.ModuleBase() + 0x7BA0800;
        public bool IsPaused()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPaused", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7BA1608 — hookable via Hooks.InstallAt(NativeFunc_GoToEndAndStop).</summary>
        public static System.IntPtr NativeFunc_GoToEndAndStop => Memory.ModuleBase() + 0x7BA1608;
        public void GoToEndAndStop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GoToEndAndStop", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA106C — hookable via Hooks.InstallAt(NativeFunc_GetStartTime).</summary>
        public static System.IntPtr NativeFunc_GetStartTime => Memory.ModuleBase() + 0x7BA106C;
        public QualifiedFrameTime GetStartTime()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetStartTime", __pb.Bytes);
            return __pb.Get<QualifiedFrameTime>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA0794 — hookable via Hooks.InstallAt(NativeFunc_GetPlayRate).</summary>
        public static System.IntPtr NativeFunc_GetPlayRate => Memory.ModuleBase() + 0x7BA0794;
        public float GetPlayRate()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPlayRate", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA14DC — hookable via Hooks.InstallAt(NativeFunc_GetPlaybackStart).</summary>
        public static System.IntPtr NativeFunc_GetPlaybackStart => Memory.ModuleBase() + 0x7BA14DC;
        public float GetPlaybackStart()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPlaybackStart", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA1560 — hookable via Hooks.InstallAt(NativeFunc_GetPlaybackPosition).</summary>
        public static System.IntPtr NativeFunc_GetPlaybackPosition => Memory.ModuleBase() + 0x7BA1560;
        public float GetPlaybackPosition()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPlaybackPosition", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA1480 — hookable via Hooks.InstallAt(NativeFunc_GetPlaybackEnd).</summary>
        public static System.IntPtr NativeFunc_GetPlaybackEnd => Memory.ModuleBase() + 0x7BA1480;
        public float GetPlaybackEnd()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPlaybackEnd", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA0408 — hookable via Hooks.InstallAt(NativeFunc_GetObjectBindings).</summary>
        public static System.IntPtr NativeFunc_GetObjectBindings => Memory.ModuleBase() + 0x7BA0408;
        public System.IntPtr GetObjectBindings(Object InObject)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, InObject);
            CallRaw("GetObjectBindings", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7BA152C — hookable via Hooks.InstallAt(NativeFunc_GetLength).</summary>
        public static System.IntPtr NativeFunc_GetLength => Memory.ModuleBase() + 0x7BA152C;
        public float GetLength()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetLength", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA1138 — hookable via Hooks.InstallAt(NativeFunc_GetFrameRate).</summary>
        public static System.IntPtr NativeFunc_GetFrameRate => Memory.ModuleBase() + 0x7BA1138;
        public FrameRate GetFrameRate()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetFrameRate", __pb.Bytes);
            return __pb.Get<FrameRate>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA1154 — hookable via Hooks.InstallAt(NativeFunc_GetFrameDuration).</summary>
        public static System.IntPtr NativeFunc_GetFrameDuration => Memory.ModuleBase() + 0x7BA1154;
        public int GetFrameDuration()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetFrameDuration", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA1044 — hookable via Hooks.InstallAt(NativeFunc_GetEndTime).</summary>
        public static System.IntPtr NativeFunc_GetEndTime => Memory.ModuleBase() + 0x7BA1044;
        public QualifiedFrameTime GetEndTime()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetEndTime", __pb.Bytes);
            return __pb.Get<QualifiedFrameTime>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA1188 — hookable via Hooks.InstallAt(NativeFunc_GetDuration).</summary>
        public static System.IntPtr NativeFunc_GetDuration => Memory.ModuleBase() + 0x7BA1188;
        public QualifiedFrameTime GetDuration()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetDuration", __pb.Bytes);
            return __pb.Get<QualifiedFrameTime>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA061C — hookable via Hooks.InstallAt(NativeFunc_GetDisableCameraCuts).</summary>
        public static System.IntPtr NativeFunc_GetDisableCameraCuts => Memory.ModuleBase() + 0x7BA061C;
        public bool GetDisableCameraCuts()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetDisableCameraCuts", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7BA11BC — hookable via Hooks.InstallAt(NativeFunc_GetCurrentTime).</summary>
        public static System.IntPtr NativeFunc_GetCurrentTime => Memory.ModuleBase() + 0x7BA11BC;
        public QualifiedFrameTime GetCurrentTime()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetCurrentTime", __pb.Bytes);
            return __pb.Get<QualifiedFrameTime>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7BA0500 — hookable via Hooks.InstallAt(NativeFunc_GetBoundObjects).</summary>
        public static System.IntPtr NativeFunc_GetBoundObjects => Memory.ModuleBase() + 0x7BA0500;
        public System.IntPtr GetBoundObjects(MovieSceneObjectBindingID ObjectBinding)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, ObjectBinding);
            CallRaw("GetBoundObjects", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x18);
        }
        /// <summary>[Native] thunk RVA 0x7BA1710 — hookable via Hooks.InstallAt(NativeFunc_ChangePlaybackDirection).</summary>
        public static System.IntPtr NativeFunc_ChangePlaybackDirection => Memory.ModuleBase() + 0x7BA1710;
        public void ChangePlaybackDirection()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ChangePlaybackDirection", __pb.Bytes);
        }
    }

    public class MovieSceneSubSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneSubSection";
        public MovieSceneSubSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSubSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSubSection(p);
        public static MovieSceneSubSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSubSection(o.Pointer); }
        public static MovieSceneSubSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSubSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSubSection(a[i].Pointer); return r; }
        public MovieSceneSectionParameters Parameters => new MovieSceneSectionParameters(AddrOf(0xD8));
        public float StartOffset { get => GetAt<float>(0xFC); set => SetAt(0xFC, value); }
        public float TimeScale { get => GetAt<float>(0x100); set => SetAt(0x100, value); }
        public float PrerollTime { get => GetAt<float>(0x104); set => SetAt(0x104, value); }
        public MovieSceneSequence SubSequence { get { var __p = GetAt<System.IntPtr>(0x108); return __p==System.IntPtr.Zero?null:new MovieSceneSequence(__p); } set => SetAt(0x108, value?.Pointer ?? System.IntPtr.Zero); }
        public Actor ActorToRecord { get { var __p = GetAt<System.IntPtr>(0x110); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x110, value?.Pointer ?? System.IntPtr.Zero); }
        public string TargetSequenceName => Native.GetPropString(Pointer, "TargetSequenceName"); // FString
        public DirectoryPath TargetPathToRecordTo => new DirectoryPath(AddrOf(0x140));
        /// <summary>[Native] thunk RVA 0x7BA5560 — hookable via Hooks.InstallAt(NativeFunc_SetSequence).</summary>
        public static System.IntPtr NativeFunc_SetSequence => Memory.ModuleBase() + 0x7BA5560;
        public void SetSequence(MovieSceneSequence Sequence)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Sequence);
            CallRaw("SetSequence", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7BA5604 — hookable via Hooks.InstallAt(NativeFunc_GetSequence).</summary>
        public static System.IntPtr NativeFunc_GetSequence => Memory.ModuleBase() + 0x7BA5604;
        public MovieSceneSequence GetSequence()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSequence", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MovieSceneSequence(__p); }
        }
    }

    public class MovieSceneSubTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneSubTrack";
        public MovieSceneSubTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSubTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSubTrack(p);
        public static MovieSceneSubTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSubTrack(o.Pointer); }
        public static MovieSceneSubTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSubTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSubTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class TestMovieSceneTrack : MovieSceneTrack
    {
        public const string UeClassName = "TestMovieSceneTrack";
        public TestMovieSceneTrack(System.IntPtr ptr) : base(ptr) {}
        public static new TestMovieSceneTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TestMovieSceneTrack(p);
        public static TestMovieSceneTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TestMovieSceneTrack(o.Pointer); }
        public static TestMovieSceneTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TestMovieSceneTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TestMovieSceneTrack(a[i].Pointer); return r; }
        public bool bHighPassFilter { get => Native.GetPropBool(Pointer, "bHighPassFilter"); set => Native.SetPropBool(Pointer, "bHighPassFilter", value); }
        public TArray<System.IntPtr> SectionArray => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class TestMovieSceneSection : MovieSceneSection
    {
        public const string UeClassName = "TestMovieSceneSection";
        public TestMovieSceneSection(System.IntPtr ptr) : base(ptr) {}
        public static new TestMovieSceneSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TestMovieSceneSection(p);
        public static TestMovieSceneSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TestMovieSceneSection(o.Pointer); }
        public static TestMovieSceneSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TestMovieSceneSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TestMovieSceneSection(a[i].Pointer); return r; }
    }

    public class TestMovieSceneSequence : MovieSceneSequence
    {
        public const string UeClassName = "TestMovieSceneSequence";
        public TestMovieSceneSequence(System.IntPtr ptr) : base(ptr) {}
        public static new TestMovieSceneSequence FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TestMovieSceneSequence(p);
        public static TestMovieSceneSequence FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TestMovieSceneSequence(o.Pointer); }
        public static TestMovieSceneSequence[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TestMovieSceneSequence[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TestMovieSceneSequence(a[i].Pointer); return r; }
        public MovieScene MovieScene { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new MovieScene(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class TestMovieSceneSubTrack : MovieSceneSubTrack
    {
        public const string UeClassName = "TestMovieSceneSubTrack";
        public TestMovieSceneSubTrack(System.IntPtr ptr) : base(ptr) {}
        public static new TestMovieSceneSubTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TestMovieSceneSubTrack(p);
        public static TestMovieSceneSubTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TestMovieSceneSubTrack(o.Pointer); }
        public static TestMovieSceneSubTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TestMovieSceneSubTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TestMovieSceneSubTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> SectionArray => new TArray<System.IntPtr>(AddrOf(0x68)); // TArray<UObject*>
    }

    public class TestMovieSceneSubSection : MovieSceneSubSection
    {
        public const string UeClassName = "TestMovieSceneSubSection";
        public TestMovieSceneSubSection(System.IntPtr ptr) : base(ptr) {}
        public static new TestMovieSceneSubSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TestMovieSceneSubSection(p);
        public static TestMovieSceneSubSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TestMovieSceneSubSection(o.Pointer); }
        public static TestMovieSceneSubSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TestMovieSceneSubSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TestMovieSceneSubSection(a[i].Pointer); return r; }
    }

}
