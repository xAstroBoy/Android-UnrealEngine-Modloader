// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/MovieSceneTracks
using System;

namespace UEModLoader.Game
{
    public enum MovieScene3DPathSection_Axis
    {
        X = 0,
        Y = 1,
        Z = 2,
        NEG_X = 3,
        NEG_Y = 4,
        NEG_Z = 5,
    }

    public enum EFireEventsAtPosition
    {
        AtStartOfEvaluation = 0,
        AtEndOfEvaluation = 1,
        AfterSpawn = 2,
    }

    public enum ELevelVisibility
    {
        Visible = 0,
        Hidden = 1,
    }

    public enum EParticleKey
    {
        Activate = 0,
        Deactivate = 1,
        Trigger = 2,
    }

    public class MovieScene3DAttachSectionTemplate : StructProxy
    {
        public MovieScene3DAttachSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneObjectBindingID AttachBindingID => new MovieSceneObjectBindingID(AddrOf(0x14));
        public string AttachSocketName => Native.FNameToString(GetAt<int>(0x2C)); // FName
        public FName AttachSocketName_Raw { get => GetAt<FName>(0x2C); set => SetAt(0x2C, value); }
        public string AttachComponentName => Native.FNameToString(GetAt<int>(0x34)); // FName
        public FName AttachComponentName_Raw { get => GetAt<FName>(0x34); set => SetAt(0x34, value); }
        public EAttachmentRule AttachmentLocationRule { get => (EAttachmentRule)GetAt<byte>(0x3C); set => SetAt(0x3C, (byte)value); }
        public EAttachmentRule AttachmentRotationRule { get => (EAttachmentRule)GetAt<byte>(0x3D); set => SetAt(0x3D, (byte)value); }
        public EAttachmentRule AttachmentScaleRule { get => (EAttachmentRule)GetAt<byte>(0x3E); set => SetAt(0x3E, (byte)value); }
        public EDetachmentRule DetachmentLocationRule { get => (EDetachmentRule)GetAt<byte>(0x3F); set => SetAt(0x3F, (byte)value); }
        public EDetachmentRule DetachmentRotationRule { get => (EDetachmentRule)GetAt<byte>(0x40); set => SetAt(0x40, (byte)value); }
        public EDetachmentRule DetachmentScaleRule { get => (EDetachmentRule)GetAt<byte>(0x41); set => SetAt(0x41, (byte)value); }
    }

    public class MovieScene3DPathSectionTemplate : StructProxy
    {
        public MovieScene3DPathSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneObjectBindingID PathBindingID => new MovieSceneObjectBindingID(AddrOf(0x14));
        public MovieSceneFloatChannel TimingCurve => new MovieSceneFloatChannel(AddrOf(0x30));
        public MovieScene3DPathSection_Axis FrontAxisEnum { get => (MovieScene3DPathSection_Axis)GetAt<byte>(0xD0); set => SetAt(0xD0, (byte)value); }
        public MovieScene3DPathSection_Axis UpAxisEnum { get => (MovieScene3DPathSection_Axis)GetAt<byte>(0xD1); set => SetAt(0xD1, (byte)value); }
        public bool bFollow { get => (GetAt<byte>(0xD2) & 0x1) != 0; set { var __b = GetAt<byte>(0xD2); SetAt(0xD2, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bReverse { get => (GetAt<byte>(0xD2) & 0x2) != 0; set { var __b = GetAt<byte>(0xD2); SetAt(0xD2, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bForceUpright { get => (GetAt<byte>(0xD2) & 0x4) != 0; set { var __b = GetAt<byte>(0xD2); SetAt(0xD2, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
    }

    public class MovieSceneTransformMask : StructProxy
    {
        public MovieSceneTransformMask(System.IntPtr ptr) : base(ptr) {}
        public uint Mask { get => GetAt<uint>(0x0); set => SetAt(0x0, value); }
    }

    public class MovieScene3DTransformKeyStruct : StructProxy
    {
        public MovieScene3DTransformKeyStruct(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x8));
        public Rotator Rotation => new Rotator(AddrOf(0x14));
        public Vector Scale => new Vector(AddrOf(0x20));
        public FrameNumber Time => new FrameNumber(AddrOf(0x2C));
    }

    public class MovieScene3DScaleKeyStruct : StructProxy
    {
        public MovieScene3DScaleKeyStruct(System.IntPtr ptr) : base(ptr) {}
        public Vector Scale => new Vector(AddrOf(0x8));
        public FrameNumber Time => new FrameNumber(AddrOf(0x14));
    }

    public class MovieScene3DRotationKeyStruct : StructProxy
    {
        public MovieScene3DRotationKeyStruct(System.IntPtr ptr) : base(ptr) {}
        public Rotator Rotation => new Rotator(AddrOf(0x8));
        public FrameNumber Time => new FrameNumber(AddrOf(0x14));
    }

    public class MovieScene3DLocationKeyStruct : StructProxy
    {
        public MovieScene3DLocationKeyStruct(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x8));
        public FrameNumber Time => new FrameNumber(AddrOf(0x14));
    }

    public class MovieSceneComponentTransformSectionTemplate : StructProxy
    {
        public MovieSceneComponentTransformSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieScene3DTransformTemplateData TemplateData => new MovieScene3DTransformTemplateData(AddrOf(0x18));
    }

    public class MovieScene3DTransformTemplateData : StructProxy
    {
        public MovieScene3DTransformTemplateData(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr TranslationCurve => AddrOf(0x0); // [3] static array
        public System.IntPtr RotationCurve => AddrOf(0x1E0); // [3] static array
        public System.IntPtr ScaleCurve => AddrOf(0x3C0); // [3] static array
        public MovieSceneFloatChannel ManualWeight => new MovieSceneFloatChannel(AddrOf(0x5A0));
        public EMovieSceneBlendType BlendType { get => (EMovieSceneBlendType)GetAt<byte>(0x640); set => SetAt(0x640, (byte)value); }
        public MovieSceneTransformMask Mask => new MovieSceneTransformMask(AddrOf(0x644));
        public bool bUseQuaternionInterpolation { get => (GetAt<byte>(0x648) & 0xFF) != 0; set { var __b = GetAt<byte>(0x648); SetAt(0x648, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class MovieSceneActorReferenceData : StructProxy
    {
        public MovieSceneActorReferenceData(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> KeyTimes => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public TArray<System.IntPtr> KeyValues => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<struct>
    }

    public class MovieSceneActorReferenceKey : StructProxy
    {
        public MovieSceneActorReferenceKey(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneObjectBindingID Object => new MovieSceneObjectBindingID(AddrOf(0x0));
        public string ComponentName => Native.FNameToString(GetAt<int>(0x18)); // FName
        public FName ComponentName_Raw { get => GetAt<FName>(0x18); set => SetAt(0x18, value); }
        public string SocketName => Native.FNameToString(GetAt<int>(0x20)); // FName
        public FName SocketName_Raw { get => GetAt<FName>(0x20); set => SetAt(0x20, value); }
    }

    public class MovieSceneActorReferenceSectionTemplate : StructProxy
    {
        public MovieSceneActorReferenceSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieScenePropertySectionData PropertyData => new MovieScenePropertySectionData(AddrOf(0x18));
        public MovieSceneActorReferenceData ActorReferenceData => new MovieSceneActorReferenceData(AddrOf(0x40));
    }

    public class MovieSceneAudioSectionTemplate : StructProxy
    {
        public MovieSceneAudioSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneAudioSection AudioSection { get { var __p = GetAt<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new MovieSceneAudioSection(__p); } set => SetAt(0x18, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieSceneCameraAnimSectionData : StructProxy
    {
        public MovieSceneCameraAnimSectionData(System.IntPtr ptr) : base(ptr) {}
        public CameraAnim CameraAnim { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new CameraAnim(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public float PlayRate { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float PlayScale { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float BlendInTime { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public float BlendOutTime { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public bool bLooping { get => (GetAt<byte>(0x18) & 0xFF) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class MovieSceneAdditiveCameraAnimationTemplate : StructProxy
    {
        public MovieSceneAdditiveCameraAnimationTemplate(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneCameraShakeSectionTemplate : StructProxy
    {
        public MovieSceneCameraShakeSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneCameraShakeSectionData SourceData => new MovieSceneCameraShakeSectionData(AddrOf(0x18));
        public FrameNumber SectionStartTime => new FrameNumber(AddrOf(0x38));
    }

    public class MovieSceneCameraShakeSectionData : StructProxy
    {
        public MovieSceneCameraShakeSectionData(System.IntPtr ptr) : base(ptr) {}
        public CameraShake ShakeClass { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new CameraShake(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public float PlayScale { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public byte PlaySpace { get => GetAt<byte>(0xC); set => SetAt(0xC, value); }
        public Rotator UserDefinedPlaySpace => new Rotator(AddrOf(0x10));
    }

    public class MovieSceneCameraAnimSectionTemplate : StructProxy
    {
        public MovieSceneCameraAnimSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneCameraAnimSectionData SourceData => new MovieSceneCameraAnimSectionData(AddrOf(0x18));
        public FrameNumber SectionStartTime => new FrameNumber(AddrOf(0x38));
    }

    public class MovieSceneCameraCutSectionTemplate : StructProxy
    {
        public MovieSceneCameraCutSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneObjectBindingID CameraBindingID => new MovieSceneObjectBindingID(AddrOf(0x14));
        public Transform CutTransform => new Transform(AddrOf(0x30));
        public bool bHasCutTransform { get => (GetAt<byte>(0x60) & 0xFF) != 0; set { var __b = GetAt<byte>(0x60); SetAt(0x60, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bIsFinalSection { get => (GetAt<byte>(0x61) & 0xFF) != 0; set { var __b = GetAt<byte>(0x61); SetAt(0x61, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class MovieSceneColorKeyStruct : StructProxy
    {
        public MovieSceneColorKeyStruct(System.IntPtr ptr) : base(ptr) {}
        public LinearColor Color => new LinearColor(AddrOf(0x8));
        public FrameNumber Time => new FrameNumber(AddrOf(0x18));
    }

    public class MovieSceneColorSectionTemplate : StructProxy
    {
        public MovieSceneColorSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr Curves => AddrOf(0x40); // [4] static array
        public EMovieSceneBlendType BlendType { get => (EMovieSceneBlendType)GetAt<byte>(0x2C0); set => SetAt(0x2C0, (byte)value); }
    }

    public class MovieSceneEvent : StructProxy
    {
        public MovieSceneEvent(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneEventPtrs Ptrs => new MovieSceneEventPtrs(AddrOf(0x0));
    }

    public class MovieSceneEventPtrs : StructProxy
    {
        public MovieSceneEventPtrs(System.IntPtr ptr) : base(ptr) {}
        public Function Function { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Function(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr BoundObjectProperty => AddrOf(0x8); // 
    }

    public class MovieSceneEventPayloadVariable : StructProxy
    {
        public MovieSceneEventPayloadVariable(System.IntPtr ptr) : base(ptr) {}
        public string Value => Native.ReadFStringAt(AddrOf(0x0)); // FString
    }

    public class MovieSceneEventChannel : StructProxy
    {
        public MovieSceneEventChannel(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> KeyTimes => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public TArray<System.IntPtr> KeyValues => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<struct>
    }

    public class MovieSceneEventSectionData : StructProxy
    {
        public MovieSceneEventSectionData(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Times => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public TArray<System.IntPtr> KeyValues => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<struct>
    }

    public class EventPayload : StructProxy
    {
        public EventPayload(System.IntPtr ptr) : base(ptr) {}
        public string EventName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName EventName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public MovieSceneEventParameters Parameters => new MovieSceneEventParameters(AddrOf(0x8));
    }

    public class MovieSceneEventParameters : StructProxy
    {
        public MovieSceneEventParameters(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneEventTemplateBase : StructProxy
    {
        public MovieSceneEventTemplateBase(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> EventReceivers => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<struct>
        public bool bFireEventsWhenForwards { get => (GetAt<byte>(0x28) & 0x1) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bFireEventsWhenBackwards { get => (GetAt<byte>(0x28) & 0x2) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
    }

    public class MovieSceneEventRepeaterTemplate : StructProxy
    {
        public MovieSceneEventRepeaterTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneEventPtrs EventToTrigger => new MovieSceneEventPtrs(AddrOf(0x30));
    }

    public class MovieSceneEventTriggerTemplate : StructProxy
    {
        public MovieSceneEventTriggerTemplate(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> EventTimes => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public TArray<System.IntPtr> Events => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<struct>
    }

    public class MovieSceneEventSectionTemplate : StructProxy
    {
        public MovieSceneEventSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneEventSectionData EventData => new MovieSceneEventSectionData(AddrOf(0x30));
    }

    public class MovieSceneFadeSectionTemplate : StructProxy
    {
        public MovieSceneFadeSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneFloatChannel FadeCurve => new MovieSceneFloatChannel(AddrOf(0x18));
        public LinearColor FadeColor => new LinearColor(AddrOf(0xB8));
        public bool bFadeAudio { get => (GetAt<byte>(0xC8) & 0x1) != 0; set { var __b = GetAt<byte>(0xC8); SetAt(0xC8, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class MovieSceneLevelVisibilitySectionTemplate : StructProxy
    {
        public MovieSceneLevelVisibilitySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public ELevelVisibility Visibility { get => (ELevelVisibility)GetAt<byte>(0x14); set => SetAt(0x14, (byte)value); }
        public TArray<System.IntPtr> LevelNames => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<FName>
    }

    public class MovieSceneParameterSectionTemplate : StructProxy
    {
        public MovieSceneParameterSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Scalars => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<struct>
        public TArray<System.IntPtr> Bools => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public TArray<System.IntPtr> Vector2Ds => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<struct>
        public TArray<System.IntPtr> Vectors => new TArray<System.IntPtr>(AddrOf(0x48)); // TArray<struct>
        public TArray<System.IntPtr> Colors => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<struct>
        public TArray<System.IntPtr> Transforms => new TArray<System.IntPtr>(AddrOf(0x68)); // TArray<struct>
    }

    public class TransformParameterNameAndCurves : StructProxy
    {
        public TransformParameterNameAndCurves(System.IntPtr ptr) : base(ptr) {}
        public string ParameterName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public System.IntPtr Translation => AddrOf(0x8); // [3] static array
        public System.IntPtr Rotation => AddrOf(0x1E8); // [3] static array
        public System.IntPtr Scale => AddrOf(0x3C8); // [3] static array
    }

    public class ColorParameterNameAndCurves : StructProxy
    {
        public ColorParameterNameAndCurves(System.IntPtr ptr) : base(ptr) {}
        public string ParameterName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public MovieSceneFloatChannel RedCurve => new MovieSceneFloatChannel(AddrOf(0x8));
        public MovieSceneFloatChannel GreenCurve => new MovieSceneFloatChannel(AddrOf(0xA8));
        public MovieSceneFloatChannel BlueCurve => new MovieSceneFloatChannel(AddrOf(0x148));
        public MovieSceneFloatChannel AlphaCurve => new MovieSceneFloatChannel(AddrOf(0x1E8));
    }

    public class VectorParameterNameAndCurves : StructProxy
    {
        public VectorParameterNameAndCurves(System.IntPtr ptr) : base(ptr) {}
        public string ParameterName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public MovieSceneFloatChannel XCurve => new MovieSceneFloatChannel(AddrOf(0x8));
        public MovieSceneFloatChannel YCurve => new MovieSceneFloatChannel(AddrOf(0xA8));
        public MovieSceneFloatChannel ZCurve => new MovieSceneFloatChannel(AddrOf(0x148));
    }

    public class Vector2DParameterNameAndCurves : StructProxy
    {
        public Vector2DParameterNameAndCurves(System.IntPtr ptr) : base(ptr) {}
        public string ParameterName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public MovieSceneFloatChannel XCurve => new MovieSceneFloatChannel(AddrOf(0x8));
        public MovieSceneFloatChannel YCurve => new MovieSceneFloatChannel(AddrOf(0xA8));
    }

    public class BoolParameterNameAndCurve : StructProxy
    {
        public BoolParameterNameAndCurve(System.IntPtr ptr) : base(ptr) {}
        public string ParameterName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public MovieSceneBoolChannel ParameterCurve => new MovieSceneBoolChannel(AddrOf(0x8));
    }

    public class ScalarParameterNameAndCurve : StructProxy
    {
        public ScalarParameterNameAndCurve(System.IntPtr ptr) : base(ptr) {}
        public string ParameterName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName ParameterName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public MovieSceneFloatChannel ParameterCurve => new MovieSceneFloatChannel(AddrOf(0x8));
    }

    public class MovieSceneMaterialParameterCollectionTemplate : StructProxy
    {
        public MovieSceneMaterialParameterCollectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MaterialParameterCollection MPC { get { var __p = GetAt<System.IntPtr>(0x78); return __p==System.IntPtr.Zero?null:new MaterialParameterCollection(__p); } set => SetAt(0x78, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieSceneObjectPropertyTemplate : StructProxy
    {
        public MovieSceneObjectPropertyTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneObjectPathChannel ObjectChannel => new MovieSceneObjectPathChannel(AddrOf(0x40));
    }

    public class MovieSceneComponentMaterialSectionTemplate : StructProxy
    {
        public MovieSceneComponentMaterialSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public int MaterialIndex { get => GetAt<int>(0x78); set => SetAt(0x78, value); }
    }

    public class MovieSceneParticleParameterSectionTemplate : StructProxy
    {
        public MovieSceneParticleParameterSectionTemplate(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneParticleChannel : StructProxy
    {
        public MovieSceneParticleChannel(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneParticleSectionTemplate : StructProxy
    {
        public MovieSceneParticleSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneParticleChannel ParticleKeys => new MovieSceneParticleChannel(AddrOf(0x18));
    }

    public class MovieScenePrimitiveMaterialTemplate : StructProxy
    {
        public MovieScenePrimitiveMaterialTemplate(System.IntPtr ptr) : base(ptr) {}
        public int MaterialIndex { get => GetAt<int>(0x14); set => SetAt(0x14, value); }
        public MovieSceneObjectPathChannel MaterialChannel => new MovieSceneObjectPathChannel(AddrOf(0x18));
    }

    public class MovieSceneEulerTransformPropertySectionTemplate : StructProxy
    {
        public MovieSceneEulerTransformPropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieScene3DTransformTemplateData TemplateData => new MovieScene3DTransformTemplateData(AddrOf(0x40));
    }

    public class MovieSceneTransformPropertySectionTemplate : StructProxy
    {
        public MovieSceneTransformPropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieScene3DTransformTemplateData TemplateData => new MovieScene3DTransformTemplateData(AddrOf(0x40));
    }

    public class MovieSceneVectorPropertySectionTemplate : StructProxy
    {
        public MovieSceneVectorPropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr ComponentCurves => AddrOf(0x40); // [4] static array
        public int NumChannelsUsed { get => GetAt<int>(0x2C0); set => SetAt(0x2C0, value); }
        public EMovieSceneBlendType BlendType { get => (EMovieSceneBlendType)GetAt<byte>(0x2C4); set => SetAt(0x2C4, (byte)value); }
    }

    public class MovieSceneStringPropertySectionTemplate : StructProxy
    {
        public MovieSceneStringPropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneStringChannel StringCurve => new MovieSceneStringChannel(AddrOf(0x40));
    }

    public class MovieSceneStringChannel : StructProxy
    {
        public MovieSceneStringChannel(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Times => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public TArray<System.IntPtr> Values => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<FString>
        public string DefaultValue => Native.ReadFStringAt(AddrOf(0x28)); // FString
        public bool bHasDefaultValue { get => (GetAt<byte>(0x38) & 0xFF) != 0; set { var __b = GetAt<byte>(0x38); SetAt(0x38, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class MovieSceneIntegerPropertySectionTemplate : StructProxy
    {
        public MovieSceneIntegerPropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneIntegerChannel IntegerCurve => new MovieSceneIntegerChannel(AddrOf(0x40));
        public EMovieSceneBlendType BlendType { get => (EMovieSceneBlendType)GetAt<byte>(0xD0); set => SetAt(0xD0, (byte)value); }
    }

    public class MovieSceneEnumPropertySectionTemplate : StructProxy
    {
        public MovieSceneEnumPropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneByteChannel EnumCurve => new MovieSceneByteChannel(AddrOf(0x40));
    }

    public class MovieSceneBytePropertySectionTemplate : StructProxy
    {
        public MovieSceneBytePropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneByteChannel ByteCurve => new MovieSceneByteChannel(AddrOf(0x40));
    }

    public class MovieSceneFloatPropertySectionTemplate : StructProxy
    {
        public MovieSceneFloatPropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneFloatChannel FloatFunction => new MovieSceneFloatChannel(AddrOf(0x40));
        public EMovieSceneBlendType BlendType { get => (EMovieSceneBlendType)GetAt<byte>(0xE0); set => SetAt(0xE0, (byte)value); }
    }

    public class MovieSceneBoolPropertySectionTemplate : StructProxy
    {
        public MovieSceneBoolPropertySectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneBoolChannel BoolCurve => new MovieSceneBoolChannel(AddrOf(0x40));
    }

    public class MovieSceneSkeletalAnimationParams : StructProxy
    {
        public MovieSceneSkeletalAnimationParams(System.IntPtr ptr) : base(ptr) {}
        public AnimSequenceBase Animation { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new AnimSequenceBase(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public FrameNumber FirstLoopStartFrameOffset => new FrameNumber(AddrOf(0x8));
        public FrameNumber StartFrameOffset => new FrameNumber(AddrOf(0xC));
        public FrameNumber EndFrameOffset => new FrameNumber(AddrOf(0x10));
        public float PlayRate { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public bool bReverse { get => (GetAt<byte>(0x18) & 0x1) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public string SlotName => Native.FNameToString(GetAt<int>(0x1C)); // FName
        public FName SlotName_Raw { get => GetAt<FName>(0x1C); set => SetAt(0x1C, value); }
        public MovieSceneFloatChannel Weight => new MovieSceneFloatChannel(AddrOf(0x28));
        public bool bSkipAnimNotifiers { get => (GetAt<byte>(0xC8) & 0xFF) != 0; set { var __b = GetAt<byte>(0xC8); SetAt(0xC8, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bForceCustomMode { get => (GetAt<byte>(0xC9) & 0xFF) != 0; set { var __b = GetAt<byte>(0xC9); SetAt(0xC9, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float StartOffset { get => GetAt<float>(0xCC); set => SetAt(0xCC, value); }
        public float EndOffset { get => GetAt<float>(0xD0); set => SetAt(0xD0, value); }
    }

    public class MovieSceneSkeletalAnimationSectionTemplate : StructProxy
    {
        public MovieSceneSkeletalAnimationSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneSkeletalAnimationSectionTemplateParameters Params => new MovieSceneSkeletalAnimationSectionTemplateParameters(AddrOf(0x18));
    }

    public class MovieSceneSkeletalAnimationSectionTemplateParameters : StructProxy
    {
        public MovieSceneSkeletalAnimationSectionTemplateParameters(System.IntPtr ptr) : base(ptr) {}
        public FrameNumber SectionStartTime => new FrameNumber(AddrOf(0xD4));
        public FrameNumber SectionEndTime => new FrameNumber(AddrOf(0xD8));
    }

    public class MovieSceneSlomoSectionTemplate : StructProxy
    {
        public MovieSceneSlomoSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneFloatChannel SlomoCurve => new MovieSceneFloatChannel(AddrOf(0x18));
    }

    public class MovieSceneSpawnSectionTemplate : StructProxy
    {
        public MovieSceneSpawnSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneBoolChannel Curve => new MovieSceneBoolChannel(AddrOf(0x18));
    }

    public class MovieSceneVectorKeyStructBase : StructProxy
    {
        public MovieSceneVectorKeyStructBase(System.IntPtr ptr) : base(ptr) {}
        public FrameNumber Time => new FrameNumber(AddrOf(0x8));
    }

    public class MovieSceneVector4KeyStruct : StructProxy
    {
        public MovieSceneVector4KeyStruct(System.IntPtr ptr) : base(ptr) {}
        public Vector4 Vector => new Vector4(AddrOf(0x30));
    }

    public class MovieSceneVectorKeyStruct : StructProxy
    {
        public MovieSceneVectorKeyStruct(System.IntPtr ptr) : base(ptr) {}
        public Vector Vector => new Vector(AddrOf(0x28));
    }

    public class MovieSceneVector2DKeyStruct : StructProxy
    {
        public MovieSceneVector2DKeyStruct(System.IntPtr ptr) : base(ptr) {}
        public Vector2D Vector => new Vector2D(AddrOf(0x28));
    }

    public class MovieSceneVisibilitySectionTemplate : StructProxy
    {
        public MovieSceneVisibilitySectionTemplate(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieSceneTransformOrigin : Interface
    {
        public const string UeClassName = "MovieSceneTransformOrigin";
        public MovieSceneTransformOrigin(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneTransformOrigin FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneTransformOrigin(p);
        public static MovieSceneTransformOrigin FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneTransformOrigin(o.Pointer); }
        public static MovieSceneTransformOrigin[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneTransformOrigin[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneTransformOrigin(a[i].Pointer); return r; }
        public Transform BP_GetTransformOrigin()
        {
            var __pb = new ParamBuffer(48);
            CallRaw("BP_GetTransformOrigin", __pb.Bytes);
            return __pb.Get<Transform>(0x0);
        }
    }

    public class MovieScene3DConstraintSection : MovieSceneSection
    {
        public const string UeClassName = "MovieScene3DConstraintSection";
        public MovieScene3DConstraintSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene3DConstraintSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene3DConstraintSection(p);
        public static MovieScene3DConstraintSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene3DConstraintSection(o.Pointer); }
        public static MovieScene3DConstraintSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene3DConstraintSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene3DConstraintSection(a[i].Pointer); return r; }
        public Guid ConstraintId => new Guid(AddrOf(0xD8));
        public MovieSceneObjectBindingID ConstraintBindingID => new MovieSceneObjectBindingID(AddrOf(0xE8));
        /// <summary>[Native] thunk RVA 0x7CD407C — hookable via Hooks.InstallAt(NativeFunc_SetConstraintBindingID).</summary>
        public static System.IntPtr NativeFunc_SetConstraintBindingID => Memory.ModuleBase() + 0x7CD407C;
        public void SetConstraintBindingID(MovieSceneObjectBindingID InConstraintBindingID)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InConstraintBindingID);
            CallRaw("SetConstraintBindingID", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7CD4154 — hookable via Hooks.InstallAt(NativeFunc_GetConstraintBindingID).</summary>
        public static System.IntPtr NativeFunc_GetConstraintBindingID => Memory.ModuleBase() + 0x7CD4154;
        public MovieSceneObjectBindingID GetConstraintBindingID()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetConstraintBindingID", __pb.Bytes);
            return __pb.Get<MovieSceneObjectBindingID>(0x0);
        }
    }

    public class MovieScene3DAttachSection : MovieScene3DConstraintSection
    {
        public const string UeClassName = "MovieScene3DAttachSection";
        public MovieScene3DAttachSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene3DAttachSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene3DAttachSection(p);
        public static MovieScene3DAttachSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene3DAttachSection(o.Pointer); }
        public static MovieScene3DAttachSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene3DAttachSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene3DAttachSection(a[i].Pointer); return r; }
        public string AttachSocketName => Native.GetPropName(Pointer, "AttachSocketName"); // FName
        public FName AttachSocketName_Raw { get => GetAt<FName>(0x100); set => SetAt(0x100, value); }
        public string AttachComponentName => Native.GetPropName(Pointer, "AttachComponentName"); // FName
        public FName AttachComponentName_Raw { get => GetAt<FName>(0x108); set => SetAt(0x108, value); }
        public EAttachmentRule AttachmentLocationRule { get => (EAttachmentRule)GetAt<byte>(0x110); set => SetAt(0x110, (byte)value); }
        public EAttachmentRule AttachmentRotationRule { get => (EAttachmentRule)GetAt<byte>(0x111); set => SetAt(0x111, (byte)value); }
        public EAttachmentRule AttachmentScaleRule { get => (EAttachmentRule)GetAt<byte>(0x112); set => SetAt(0x112, (byte)value); }
        public EDetachmentRule DetachmentLocationRule { get => (EDetachmentRule)GetAt<byte>(0x113); set => SetAt(0x113, (byte)value); }
        public EDetachmentRule DetachmentRotationRule { get => (EDetachmentRule)GetAt<byte>(0x114); set => SetAt(0x114, (byte)value); }
        public EDetachmentRule DetachmentScaleRule { get => (EDetachmentRule)GetAt<byte>(0x115); set => SetAt(0x115, (byte)value); }
    }

    public class MovieScene3DConstraintTrack : MovieSceneTrack
    {
        public const string UeClassName = "MovieScene3DConstraintTrack";
        public MovieScene3DConstraintTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene3DConstraintTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene3DConstraintTrack(p);
        public static MovieScene3DConstraintTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene3DConstraintTrack(o.Pointer); }
        public static MovieScene3DConstraintTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene3DConstraintTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene3DConstraintTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> ConstraintSections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieScene3DAttachTrack : MovieScene3DConstraintTrack
    {
        public const string UeClassName = "MovieScene3DAttachTrack";
        public MovieScene3DAttachTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene3DAttachTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene3DAttachTrack(p);
        public static MovieScene3DAttachTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene3DAttachTrack(o.Pointer); }
        public static MovieScene3DAttachTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene3DAttachTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene3DAttachTrack(a[i].Pointer); return r; }
    }

    public class MovieScene3DPathSection : MovieScene3DConstraintSection
    {
        public const string UeClassName = "MovieScene3DPathSection";
        public MovieScene3DPathSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene3DPathSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene3DPathSection(p);
        public static MovieScene3DPathSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene3DPathSection(o.Pointer); }
        public static MovieScene3DPathSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene3DPathSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene3DPathSection(a[i].Pointer); return r; }
        public MovieSceneFloatChannel TimingCurve => new MovieSceneFloatChannel(AddrOf(0x100));
        public MovieScene3DPathSection_Axis FrontAxisEnum { get => (MovieScene3DPathSection_Axis)GetAt<byte>(0x1A0); set => SetAt(0x1A0, (byte)value); }
        public MovieScene3DPathSection_Axis UpAxisEnum { get => (MovieScene3DPathSection_Axis)GetAt<byte>(0x1A1); set => SetAt(0x1A1, (byte)value); }
        public bool bFollow { get => Native.GetPropBool(Pointer, "bFollow"); set => Native.SetPropBool(Pointer, "bFollow", value); }
        public bool bReverse { get => Native.GetPropBool(Pointer, "bReverse"); set => Native.SetPropBool(Pointer, "bReverse", value); }
        public bool bForceUpright { get => Native.GetPropBool(Pointer, "bForceUpright"); set => Native.SetPropBool(Pointer, "bForceUpright", value); }
    }

    public class MovieScene3DPathTrack : MovieScene3DConstraintTrack
    {
        public const string UeClassName = "MovieScene3DPathTrack";
        public MovieScene3DPathTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene3DPathTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene3DPathTrack(p);
        public static MovieScene3DPathTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene3DPathTrack(o.Pointer); }
        public static MovieScene3DPathTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene3DPathTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene3DPathTrack(a[i].Pointer); return r; }
    }

    public class MovieScene3DTransformSection : MovieSceneSection
    {
        public const string UeClassName = "MovieScene3DTransformSection";
        public MovieScene3DTransformSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene3DTransformSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene3DTransformSection(p);
        public static MovieScene3DTransformSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene3DTransformSection(o.Pointer); }
        public static MovieScene3DTransformSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene3DTransformSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene3DTransformSection(a[i].Pointer); return r; }
        public MovieSceneTransformMask TransformMask => new MovieSceneTransformMask(AddrOf(0xD8));
        public System.IntPtr Translation => AddrOf(0xE0); // [3] static array
        public System.IntPtr Rotation => AddrOf(0x2C0); // [3] static array
        public System.IntPtr Scale => AddrOf(0x4A0); // [3] static array
        public MovieSceneFloatChannel ManualWeight => new MovieSceneFloatChannel(AddrOf(0x680));
        public bool bUseQuaternionInterpolation { get => Native.GetPropBool(Pointer, "bUseQuaternionInterpolation"); set => Native.SetPropBool(Pointer, "bUseQuaternionInterpolation", value); }
    }

    public class MovieScenePropertyTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieScenePropertyTrack";
        public MovieScenePropertyTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScenePropertyTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScenePropertyTrack(p);
        public static MovieScenePropertyTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScenePropertyTrack(o.Pointer); }
        public static MovieScenePropertyTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScenePropertyTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScenePropertyTrack(a[i].Pointer); return r; }
        public MovieSceneSection SectionToKey { get { var __p = GetAt<System.IntPtr>(0x58); return __p==System.IntPtr.Zero?null:new MovieSceneSection(__p); } set => SetAt(0x58, value?.Pointer ?? System.IntPtr.Zero); }
        public string PropertyName => Native.GetPropName(Pointer, "PropertyName"); // FName
        public FName PropertyName_Raw { get => GetAt<FName>(0x60); set => SetAt(0x60, value); }
        public string PropertyPath => Native.GetPropString(Pointer, "PropertyPath"); // FString
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x78)); // TArray<UObject*>
    }

    public class MovieScene3DTransformTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieScene3DTransformTrack";
        public MovieScene3DTransformTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene3DTransformTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene3DTransformTrack(p);
        public static MovieScene3DTransformTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene3DTransformTrack(o.Pointer); }
        public static MovieScene3DTransformTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene3DTransformTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene3DTransformTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneActorReferenceSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneActorReferenceSection";
        public MovieSceneActorReferenceSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneActorReferenceSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneActorReferenceSection(p);
        public static MovieSceneActorReferenceSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneActorReferenceSection(o.Pointer); }
        public static MovieSceneActorReferenceSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneActorReferenceSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneActorReferenceSection(a[i].Pointer); return r; }
        public MovieSceneActorReferenceData ActorReferenceData => new MovieSceneActorReferenceData(AddrOf(0xD8));
        public IntegralCurve ActorGuidIndexCurve => new IntegralCurve(AddrOf(0x188));
        public TArray<System.IntPtr> ActorGuidStrings => new TArray<System.IntPtr>(AddrOf(0x208)); // TArray<FString>
    }

    public class MovieSceneActorReferenceTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneActorReferenceTrack";
        public MovieSceneActorReferenceTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneActorReferenceTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneActorReferenceTrack(p);
        public static MovieSceneActorReferenceTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneActorReferenceTrack(o.Pointer); }
        public static MovieSceneActorReferenceTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneActorReferenceTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneActorReferenceTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneAudioSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneAudioSection";
        public MovieSceneAudioSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneAudioSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneAudioSection(p);
        public static MovieSceneAudioSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneAudioSection(o.Pointer); }
        public static MovieSceneAudioSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneAudioSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneAudioSection(a[i].Pointer); return r; }
        public SoundBase Sound { get { var __p = GetAt<System.IntPtr>(0xD8); return __p==System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0xD8, value?.Pointer ?? System.IntPtr.Zero); }
        public FrameNumber StartFrameOffset => new FrameNumber(AddrOf(0xE0));
        public float StartOffset { get => GetAt<float>(0xE4); set => SetAt(0xE4, value); }
        public float AudioStartTime { get => GetAt<float>(0xE8); set => SetAt(0xE8, value); }
        public float AudioDilationFactor { get => GetAt<float>(0xEC); set => SetAt(0xEC, value); }
        public float AudioVolume { get => GetAt<float>(0xF0); set => SetAt(0xF0, value); }
        public MovieSceneFloatChannel SoundVolume => new MovieSceneFloatChannel(AddrOf(0xF8));
        public MovieSceneFloatChannel PitchMultiplier => new MovieSceneFloatChannel(AddrOf(0x198));
        public MovieSceneActorReferenceData AttachActorData => new MovieSceneActorReferenceData(AddrOf(0x238));
        public bool bSuppressSubtitles { get => Native.GetPropBool(Pointer, "bSuppressSubtitles"); set => Native.SetPropBool(Pointer, "bSuppressSubtitles", value); }
        public bool bOverrideAttenuation { get => Native.GetPropBool(Pointer, "bOverrideAttenuation"); set => Native.SetPropBool(Pointer, "bOverrideAttenuation", value); }
        public SoundAttenuation AttenuationSettings { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new SoundAttenuation(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr OnQueueSubtitles => AddrOf(0x2F8); // 
        public System.IntPtr OnAudioFinished => AddrOf(0x308); // 
        public System.IntPtr OnAudioPlaybackPercent => AddrOf(0x318); // 
        /// <summary>[Native] thunk RVA 0x7CDD1C4 — hookable via Hooks.InstallAt(NativeFunc_SetStartOffset).</summary>
        public static System.IntPtr NativeFunc_SetStartOffset => Memory.ModuleBase() + 0x7CDD1C4;
        public void SetStartOffset(FrameNumber InStartOffset)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<System.IntPtr>(0x0, InStartOffset);
            CallRaw("SetStartOffset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7CDD280 — hookable via Hooks.InstallAt(NativeFunc_SetSound).</summary>
        public static System.IntPtr NativeFunc_SetSound => Memory.ModuleBase() + 0x7CDD280;
        public void SetSound(SoundBase InSound)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InSound);
            CallRaw("SetSound", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7CDD1A8 — hookable via Hooks.InstallAt(NativeFunc_GetStartOffset).</summary>
        public static System.IntPtr NativeFunc_GetStartOffset => Memory.ModuleBase() + 0x7CDD1A8;
        public FrameNumber GetStartOffset()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetStartOffset", __pb.Bytes);
            return __pb.Get<FrameNumber>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7CDD264 — hookable via Hooks.InstallAt(NativeFunc_GetSound).</summary>
        public static System.IntPtr NativeFunc_GetSound => Memory.ModuleBase() + 0x7CDD264;
        public SoundBase GetSound()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSound", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new SoundBase(__p); }
        }
    }

    public class MovieSceneAudioTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneAudioTrack";
        public MovieSceneAudioTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneAudioTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneAudioTrack(p);
        public static MovieSceneAudioTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneAudioTrack(o.Pointer); }
        public static MovieSceneAudioTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneAudioTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneAudioTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> AudioSections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieSceneBoolSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneBoolSection";
        public MovieSceneBoolSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneBoolSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneBoolSection(p);
        public static MovieSceneBoolSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneBoolSection(o.Pointer); }
        public static MovieSceneBoolSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneBoolSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneBoolSection(a[i].Pointer); return r; }
        public bool DefaultValue { get => Native.GetPropBool(Pointer, "DefaultValue"); set => Native.SetPropBool(Pointer, "DefaultValue", value); }
        public MovieSceneBoolChannel BoolCurve => new MovieSceneBoolChannel(AddrOf(0xE0));
    }

    public class MovieSceneBoolTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneBoolTrack";
        public MovieSceneBoolTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneBoolTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneBoolTrack(p);
        public static MovieSceneBoolTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneBoolTrack(o.Pointer); }
        public static MovieSceneBoolTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneBoolTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneBoolTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneByteSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneByteSection";
        public MovieSceneByteSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneByteSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneByteSection(p);
        public static MovieSceneByteSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneByteSection(o.Pointer); }
        public static MovieSceneByteSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneByteSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneByteSection(a[i].Pointer); return r; }
        public MovieSceneByteChannel ByteCurve => new MovieSceneByteChannel(AddrOf(0xD8));
    }

    public class MovieSceneByteTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneByteTrack";
        public MovieSceneByteTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneByteTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneByteTrack(p);
        public static MovieSceneByteTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneByteTrack(o.Pointer); }
        public static MovieSceneByteTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneByteTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneByteTrack(a[i].Pointer); return r; }
        public Enum Enum { get { var __p = GetAt<System.IntPtr>(0x88); return __p==System.IntPtr.Zero?null:new Enum(__p); } set => SetAt(0x88, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieSceneCameraAnimSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneCameraAnimSection";
        public MovieSceneCameraAnimSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCameraAnimSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneCameraAnimSection(p);
        public static MovieSceneCameraAnimSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCameraAnimSection(o.Pointer); }
        public static MovieSceneCameraAnimSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCameraAnimSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCameraAnimSection(a[i].Pointer); return r; }
        public MovieSceneCameraAnimSectionData AnimData => new MovieSceneCameraAnimSectionData(AddrOf(0xD8));
        public CameraAnim CameraAnim { get { var __p = GetAt<System.IntPtr>(0xF8); return __p==System.IntPtr.Zero?null:new CameraAnim(__p); } set => SetAt(0xF8, value?.Pointer ?? System.IntPtr.Zero); }
        public float PlayRate { get => GetAt<float>(0x100); set => SetAt(0x100, value); }
        public float PlayScale { get => GetAt<float>(0x104); set => SetAt(0x104, value); }
        public float BlendInTime { get => GetAt<float>(0x108); set => SetAt(0x108, value); }
        public float BlendOutTime { get => GetAt<float>(0x10C); set => SetAt(0x10C, value); }
        public bool bLooping { get => Native.GetPropBool(Pointer, "bLooping"); set => Native.SetPropBool(Pointer, "bLooping", value); }
    }

    public class MovieSceneCameraAnimTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneCameraAnimTrack";
        public MovieSceneCameraAnimTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCameraAnimTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneCameraAnimTrack(p);
        public static MovieSceneCameraAnimTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCameraAnimTrack(o.Pointer); }
        public static MovieSceneCameraAnimTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCameraAnimTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCameraAnimTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> CameraAnimSections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieSceneCameraCutSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneCameraCutSection";
        public MovieSceneCameraCutSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCameraCutSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneCameraCutSection(p);
        public static MovieSceneCameraCutSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCameraCutSection(o.Pointer); }
        public static MovieSceneCameraCutSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCameraCutSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCameraCutSection(a[i].Pointer); return r; }
        public Guid CameraGuid => new Guid(AddrOf(0xD8));
        public MovieSceneObjectBindingID CameraBindingID => new MovieSceneObjectBindingID(AddrOf(0xE8));
        /// <summary>[Native] thunk RVA 0x7CE3510 — hookable via Hooks.InstallAt(NativeFunc_SetCameraBindingID).</summary>
        public static System.IntPtr NativeFunc_SetCameraBindingID => Memory.ModuleBase() + 0x7CE3510;
        public void SetCameraBindingID(MovieSceneObjectBindingID InCameraBindingID)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InCameraBindingID);
            CallRaw("SetCameraBindingID", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7CE35E8 — hookable via Hooks.InstallAt(NativeFunc_GetCameraBindingID).</summary>
        public static System.IntPtr NativeFunc_GetCameraBindingID => Memory.ModuleBase() + 0x7CE35E8;
        public MovieSceneObjectBindingID GetCameraBindingID()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetCameraBindingID", __pb.Bytes);
            return __pb.Get<MovieSceneObjectBindingID>(0x0);
        }
    }

    public class MovieSceneCameraCutTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneCameraCutTrack";
        public MovieSceneCameraCutTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCameraCutTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneCameraCutTrack(p);
        public static MovieSceneCameraCutTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCameraCutTrack(o.Pointer); }
        public static MovieSceneCameraCutTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCameraCutTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCameraCutTrack(a[i].Pointer); return r; }
        public bool bCanBlend { get => Native.GetPropBool(Pointer, "bCanBlend"); set => Native.SetPropBool(Pointer, "bCanBlend", value); }
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieSceneCameraShakeSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneCameraShakeSection";
        public MovieSceneCameraShakeSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCameraShakeSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneCameraShakeSection(p);
        public static MovieSceneCameraShakeSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCameraShakeSection(o.Pointer); }
        public static MovieSceneCameraShakeSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCameraShakeSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCameraShakeSection(a[i].Pointer); return r; }
        public MovieSceneCameraShakeSectionData ShakeData => new MovieSceneCameraShakeSectionData(AddrOf(0xD8));
        public CameraShake ShakeClass { get { var __p = GetAt<System.IntPtr>(0xF8); return __p==System.IntPtr.Zero?null:new CameraShake(__p); } set => SetAt(0xF8, value?.Pointer ?? System.IntPtr.Zero); }
        public float PlayScale { get => GetAt<float>(0x100); set => SetAt(0x100, value); }
        public byte PlaySpace { get => GetAt<byte>(0x104); set => SetAt(0x104, value); }
        public Rotator UserDefinedPlaySpace => new Rotator(AddrOf(0x108));
    }

    public class MovieSceneCameraShakeTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneCameraShakeTrack";
        public MovieSceneCameraShakeTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCameraShakeTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneCameraShakeTrack(p);
        public static MovieSceneCameraShakeTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCameraShakeTrack(o.Pointer); }
        public static MovieSceneCameraShakeTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCameraShakeTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCameraShakeTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> CameraShakeSections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieSceneCinematicShotSection : MovieSceneSubSection
    {
        public const string UeClassName = "MovieSceneCinematicShotSection";
        public MovieSceneCinematicShotSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCinematicShotSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneCinematicShotSection(p);
        public static MovieSceneCinematicShotSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCinematicShotSection(o.Pointer); }
        public static MovieSceneCinematicShotSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCinematicShotSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCinematicShotSection(a[i].Pointer); return r; }
        public string ShotDisplayName => Native.GetPropString(Pointer, "ShotDisplayName"); // FString
        public System.IntPtr DisplayName => AddrOf(0x160); // 
        /// <summary>[Native] thunk RVA 0x7CE6390 — hookable via Hooks.InstallAt(NativeFunc_SetShotDisplayName).</summary>
        public static System.IntPtr NativeFunc_SetShotDisplayName => Memory.ModuleBase() + 0x7CE6390;
        public void SetShotDisplayName(System.IntPtr InShotDisplayName)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InShotDisplayName);
            CallRaw("SetShotDisplayName", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7CE64A0 — hookable via Hooks.InstallAt(NativeFunc_GetShotDisplayName).</summary>
        public static System.IntPtr NativeFunc_GetShotDisplayName => Memory.ModuleBase() + 0x7CE64A0;
        public System.IntPtr GetShotDisplayName()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetShotDisplayName", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class MovieSceneCinematicShotTrack : MovieSceneSubTrack
    {
        public const string UeClassName = "MovieSceneCinematicShotTrack";
        public MovieSceneCinematicShotTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCinematicShotTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneCinematicShotTrack(p);
        public static MovieSceneCinematicShotTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCinematicShotTrack(o.Pointer); }
        public static MovieSceneCinematicShotTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCinematicShotTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCinematicShotTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneColorSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneColorSection";
        public MovieSceneColorSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneColorSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneColorSection(p);
        public static MovieSceneColorSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneColorSection(o.Pointer); }
        public static MovieSceneColorSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneColorSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneColorSection(a[i].Pointer); return r; }
        public MovieSceneFloatChannel RedCurve => new MovieSceneFloatChannel(AddrOf(0xD8));
        public MovieSceneFloatChannel GreenCurve => new MovieSceneFloatChannel(AddrOf(0x178));
        public MovieSceneFloatChannel BlueCurve => new MovieSceneFloatChannel(AddrOf(0x218));
        public MovieSceneFloatChannel AlphaCurve => new MovieSceneFloatChannel(AddrOf(0x2B8));
    }

    public class MovieSceneColorTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneColorTrack";
        public MovieSceneColorTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneColorTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneColorTrack(p);
        public static MovieSceneColorTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneColorTrack(o.Pointer); }
        public static MovieSceneColorTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneColorTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneColorTrack(a[i].Pointer); return r; }
        public bool bIsSlateColor { get => Native.GetPropBool(Pointer, "bIsSlateColor"); set => Native.SetPropBool(Pointer, "bIsSlateColor", value); }
    }

    public class MovieSceneEnumSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneEnumSection";
        public MovieSceneEnumSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEnumSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEnumSection(p);
        public static MovieSceneEnumSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEnumSection(o.Pointer); }
        public static MovieSceneEnumSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEnumSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEnumSection(a[i].Pointer); return r; }
        public MovieSceneByteChannel EnumCurve => new MovieSceneByteChannel(AddrOf(0xD8));
    }

    public class MovieSceneEnumTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneEnumTrack";
        public MovieSceneEnumTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEnumTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEnumTrack(p);
        public static MovieSceneEnumTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEnumTrack(o.Pointer); }
        public static MovieSceneEnumTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEnumTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEnumTrack(a[i].Pointer); return r; }
        public Enum Enum { get { var __p = GetAt<System.IntPtr>(0x88); return __p==System.IntPtr.Zero?null:new Enum(__p); } set => SetAt(0x88, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieSceneEulerTransformTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneEulerTransformTrack";
        public MovieSceneEulerTransformTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEulerTransformTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEulerTransformTrack(p);
        public static MovieSceneEulerTransformTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEulerTransformTrack(o.Pointer); }
        public static MovieSceneEulerTransformTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEulerTransformTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEulerTransformTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneEventSectionBase : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneEventSectionBase";
        public MovieSceneEventSectionBase(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEventSectionBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEventSectionBase(p);
        public static MovieSceneEventSectionBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEventSectionBase(o.Pointer); }
        public static MovieSceneEventSectionBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEventSectionBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEventSectionBase(a[i].Pointer); return r; }
    }

    public class MovieSceneEventRepeaterSection : MovieSceneEventSectionBase
    {
        public const string UeClassName = "MovieSceneEventRepeaterSection";
        public MovieSceneEventRepeaterSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEventRepeaterSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEventRepeaterSection(p);
        public static MovieSceneEventRepeaterSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEventRepeaterSection(o.Pointer); }
        public static MovieSceneEventRepeaterSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEventRepeaterSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEventRepeaterSection(a[i].Pointer); return r; }
        public MovieSceneEvent Event => new MovieSceneEvent(AddrOf(0xD8));
    }

    public class MovieSceneEventSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneEventSection";
        public MovieSceneEventSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEventSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEventSection(p);
        public static MovieSceneEventSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEventSection(o.Pointer); }
        public static MovieSceneEventSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEventSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEventSection(a[i].Pointer); return r; }
        public NameCurve Events => new NameCurve(AddrOf(0xD8));
        public MovieSceneEventSectionData EventData => new MovieSceneEventSectionData(AddrOf(0x150));
    }

    public class MovieSceneEventTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneEventTrack";
        public MovieSceneEventTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEventTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEventTrack(p);
        public static MovieSceneEventTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEventTrack(o.Pointer); }
        public static MovieSceneEventTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEventTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEventTrack(a[i].Pointer); return r; }
        public bool bFireEventsWhenForwards { get => Native.GetPropBool(Pointer, "bFireEventsWhenForwards"); set => Native.SetPropBool(Pointer, "bFireEventsWhenForwards", value); }
        public bool bFireEventsWhenBackwards { get => Native.GetPropBool(Pointer, "bFireEventsWhenBackwards"); set => Native.SetPropBool(Pointer, "bFireEventsWhenBackwards", value); }
        public EFireEventsAtPosition EventPosition { get => (EFireEventsAtPosition)GetAt<byte>(0x57); set => SetAt(0x57, (byte)value); }
        public TArray<System.IntPtr> EventReceivers => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<struct>
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x68)); // TArray<UObject*>
    }

    public class MovieSceneEventTriggerSection : MovieSceneEventSectionBase
    {
        public const string UeClassName = "MovieSceneEventTriggerSection";
        public MovieSceneEventTriggerSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneEventTriggerSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneEventTriggerSection(p);
        public static MovieSceneEventTriggerSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneEventTriggerSection(o.Pointer); }
        public static MovieSceneEventTriggerSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneEventTriggerSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneEventTriggerSection(a[i].Pointer); return r; }
        public MovieSceneEventChannel EventChannel => new MovieSceneEventChannel(AddrOf(0xD8));
    }

    public class MovieSceneFloatSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneFloatSection";
        public MovieSceneFloatSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneFloatSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneFloatSection(p);
        public static MovieSceneFloatSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneFloatSection(o.Pointer); }
        public static MovieSceneFloatSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneFloatSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneFloatSection(a[i].Pointer); return r; }
        public MovieSceneFloatChannel FloatCurve => new MovieSceneFloatChannel(AddrOf(0xD8));
    }

    public class MovieSceneFadeSection : MovieSceneFloatSection
    {
        public const string UeClassName = "MovieSceneFadeSection";
        public MovieSceneFadeSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneFadeSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneFadeSection(p);
        public static MovieSceneFadeSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneFadeSection(o.Pointer); }
        public static MovieSceneFadeSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneFadeSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneFadeSection(a[i].Pointer); return r; }
        public LinearColor FadeColor => new LinearColor(AddrOf(0x178));
        public bool bFadeAudio { get => Native.GetPropBool(Pointer, "bFadeAudio"); set => Native.SetPropBool(Pointer, "bFadeAudio", value); }
    }

    public class MovieSceneFloatTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneFloatTrack";
        public MovieSceneFloatTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneFloatTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneFloatTrack(p);
        public static MovieSceneFloatTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneFloatTrack(o.Pointer); }
        public static MovieSceneFloatTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneFloatTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneFloatTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneFadeTrack : MovieSceneFloatTrack
    {
        public const string UeClassName = "MovieSceneFadeTrack";
        public MovieSceneFadeTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneFadeTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneFadeTrack(p);
        public static MovieSceneFadeTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneFadeTrack(o.Pointer); }
        public static MovieSceneFadeTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneFadeTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneFadeTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneIntegerSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneIntegerSection";
        public MovieSceneIntegerSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneIntegerSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneIntegerSection(p);
        public static MovieSceneIntegerSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneIntegerSection(o.Pointer); }
        public static MovieSceneIntegerSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneIntegerSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneIntegerSection(a[i].Pointer); return r; }
        public MovieSceneIntegerChannel IntegerCurve => new MovieSceneIntegerChannel(AddrOf(0xD8));
    }

    public class MovieSceneIntegerTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneIntegerTrack";
        public MovieSceneIntegerTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneIntegerTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneIntegerTrack(p);
        public static MovieSceneIntegerTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneIntegerTrack(o.Pointer); }
        public static MovieSceneIntegerTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneIntegerTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneIntegerTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneLevelVisibilitySection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneLevelVisibilitySection";
        public MovieSceneLevelVisibilitySection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneLevelVisibilitySection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneLevelVisibilitySection(p);
        public static MovieSceneLevelVisibilitySection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneLevelVisibilitySection(o.Pointer); }
        public static MovieSceneLevelVisibilitySection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneLevelVisibilitySection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneLevelVisibilitySection(a[i].Pointer); return r; }
        public ELevelVisibility Visibility { get => (ELevelVisibility)GetAt<byte>(0xD8); set => SetAt(0xD8, (byte)value); }
        public TArray<System.IntPtr> LevelNames => new TArray<System.IntPtr>(AddrOf(0xE0)); // TArray<FName>
        /// <summary>[Native] thunk RVA 0x7CF4FD4 — hookable via Hooks.InstallAt(NativeFunc_SetVisibility).</summary>
        public static System.IntPtr NativeFunc_SetVisibility => Memory.ModuleBase() + 0x7CF4FD4;
        public void SetVisibility(ELevelVisibility InVisibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InVisibility);
            CallRaw("SetVisibility", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7CF4E40 — hookable via Hooks.InstallAt(NativeFunc_SetLevelNames).</summary>
        public static System.IntPtr NativeFunc_SetLevelNames => Memory.ModuleBase() + 0x7CF4E40;
        public void SetLevelNames(System.IntPtr InLevelNames)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InLevelNames);
            CallRaw("SetLevelNames", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7CF5078 — hookable via Hooks.InstallAt(NativeFunc_GetVisibility).</summary>
        public static System.IntPtr NativeFunc_GetVisibility => Memory.ModuleBase() + 0x7CF5078;
        public ELevelVisibility GetVisibility()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetVisibility", __pb.Bytes);
            return (ELevelVisibility)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7CF4F50 — hookable via Hooks.InstallAt(NativeFunc_GetLevelNames).</summary>
        public static System.IntPtr NativeFunc_GetLevelNames => Memory.ModuleBase() + 0x7CF4F50;
        public System.IntPtr GetLevelNames()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetLevelNames", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class MovieSceneLevelVisibilityTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneLevelVisibilityTrack";
        public MovieSceneLevelVisibilityTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneLevelVisibilityTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneLevelVisibilityTrack(p);
        public static MovieSceneLevelVisibilityTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneLevelVisibilityTrack(o.Pointer); }
        public static MovieSceneLevelVisibilityTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneLevelVisibilityTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneLevelVisibilityTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieSceneMaterialTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneMaterialTrack";
        public MovieSceneMaterialTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneMaterialTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneMaterialTrack(p);
        public static MovieSceneMaterialTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneMaterialTrack(o.Pointer); }
        public static MovieSceneMaterialTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneMaterialTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneMaterialTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieSceneMaterialParameterCollectionTrack : MovieSceneMaterialTrack
    {
        public const string UeClassName = "MovieSceneMaterialParameterCollectionTrack";
        public MovieSceneMaterialParameterCollectionTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneMaterialParameterCollectionTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneMaterialParameterCollectionTrack(p);
        public static MovieSceneMaterialParameterCollectionTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneMaterialParameterCollectionTrack(o.Pointer); }
        public static MovieSceneMaterialParameterCollectionTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneMaterialParameterCollectionTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneMaterialParameterCollectionTrack(a[i].Pointer); return r; }
        public MaterialParameterCollection MPC { get { var __p = GetAt<System.IntPtr>(0x68); return __p==System.IntPtr.Zero?null:new MaterialParameterCollection(__p); } set => SetAt(0x68, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieSceneComponentMaterialTrack : MovieSceneMaterialTrack
    {
        public const string UeClassName = "MovieSceneComponentMaterialTrack";
        public MovieSceneComponentMaterialTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneComponentMaterialTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneComponentMaterialTrack(p);
        public static MovieSceneComponentMaterialTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneComponentMaterialTrack(o.Pointer); }
        public static MovieSceneComponentMaterialTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneComponentMaterialTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneComponentMaterialTrack(a[i].Pointer); return r; }
        public int MaterialIndex { get => GetAt<int>(0x68); set => SetAt(0x68, value); }
    }

    public class MovieSceneObjectPropertySection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneObjectPropertySection";
        public MovieSceneObjectPropertySection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneObjectPropertySection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneObjectPropertySection(p);
        public static MovieSceneObjectPropertySection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneObjectPropertySection(o.Pointer); }
        public static MovieSceneObjectPropertySection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneObjectPropertySection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneObjectPropertySection(a[i].Pointer); return r; }
        public MovieSceneObjectPathChannel ObjectChannel => new MovieSceneObjectPathChannel(AddrOf(0xD8));
    }

    public class MovieSceneObjectPropertyTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneObjectPropertyTrack";
        public MovieSceneObjectPropertyTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneObjectPropertyTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneObjectPropertyTrack(p);
        public static MovieSceneObjectPropertyTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneObjectPropertyTrack(o.Pointer); }
        public static MovieSceneObjectPropertyTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneObjectPropertyTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneObjectPropertyTrack(a[i].Pointer); return r; }
        public Object PropertyClass { get { var __p = GetAt<System.IntPtr>(0x88); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x88, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class MovieSceneParameterSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneParameterSection";
        public MovieSceneParameterSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneParameterSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneParameterSection(p);
        public static MovieSceneParameterSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneParameterSection(o.Pointer); }
        public static MovieSceneParameterSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneParameterSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneParameterSection(a[i].Pointer); return r; }
        public TArray<System.IntPtr> BoolParameterNamesAndCurves => new TArray<System.IntPtr>(AddrOf(0xD8)); // TArray<struct>
        public TArray<System.IntPtr> ScalarParameterNamesAndCurves => new TArray<System.IntPtr>(AddrOf(0xE8)); // TArray<struct>
        public TArray<System.IntPtr> Vector2DParameterNamesAndCurves => new TArray<System.IntPtr>(AddrOf(0xF8)); // TArray<struct>
        public TArray<System.IntPtr> VectorParameterNamesAndCurves => new TArray<System.IntPtr>(AddrOf(0x108)); // TArray<struct>
        public TArray<System.IntPtr> ColorParameterNamesAndCurves => new TArray<System.IntPtr>(AddrOf(0x118)); // TArray<struct>
        public TArray<System.IntPtr> TransformParameterNamesAndCurves => new TArray<System.IntPtr>(AddrOf(0x128)); // TArray<struct>
    }

    public class MovieSceneParticleParameterTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneParticleParameterTrack";
        public MovieSceneParticleParameterTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneParticleParameterTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneParticleParameterTrack(p);
        public static MovieSceneParticleParameterTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneParticleParameterTrack(o.Pointer); }
        public static MovieSceneParticleParameterTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneParticleParameterTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneParticleParameterTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieSceneParticleSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneParticleSection";
        public MovieSceneParticleSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneParticleSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneParticleSection(p);
        public static MovieSceneParticleSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneParticleSection(o.Pointer); }
        public static MovieSceneParticleSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneParticleSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneParticleSection(a[i].Pointer); return r; }
        public MovieSceneParticleChannel ParticleKeys => new MovieSceneParticleChannel(AddrOf(0xD8));
    }

    public class MovieSceneParticleTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneParticleTrack";
        public MovieSceneParticleTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneParticleTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneParticleTrack(p);
        public static MovieSceneParticleTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneParticleTrack(o.Pointer); }
        public static MovieSceneParticleTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneParticleTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneParticleTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> ParticleSections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
    }

    public class MovieScenePrimitiveMaterialSection : MovieSceneSection
    {
        public const string UeClassName = "MovieScenePrimitiveMaterialSection";
        public MovieScenePrimitiveMaterialSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScenePrimitiveMaterialSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScenePrimitiveMaterialSection(p);
        public static MovieScenePrimitiveMaterialSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScenePrimitiveMaterialSection(o.Pointer); }
        public static MovieScenePrimitiveMaterialSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScenePrimitiveMaterialSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScenePrimitiveMaterialSection(a[i].Pointer); return r; }
        public MovieSceneObjectPathChannel MaterialChannel => new MovieSceneObjectPathChannel(AddrOf(0xD8));
    }

    public class MovieScenePrimitiveMaterialTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieScenePrimitiveMaterialTrack";
        public MovieScenePrimitiveMaterialTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScenePrimitiveMaterialTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScenePrimitiveMaterialTrack(p);
        public static MovieScenePrimitiveMaterialTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScenePrimitiveMaterialTrack(o.Pointer); }
        public static MovieScenePrimitiveMaterialTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScenePrimitiveMaterialTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScenePrimitiveMaterialTrack(a[i].Pointer); return r; }
        public int MaterialIndex { get => GetAt<int>(0x88); set => SetAt(0x88, value); }
    }

    public class MovieSceneSkeletalAnimationSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneSkeletalAnimationSection";
        public MovieSceneSkeletalAnimationSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSkeletalAnimationSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSkeletalAnimationSection(p);
        public static MovieSceneSkeletalAnimationSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSkeletalAnimationSection(o.Pointer); }
        public static MovieSceneSkeletalAnimationSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSkeletalAnimationSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSkeletalAnimationSection(a[i].Pointer); return r; }
        public MovieSceneSkeletalAnimationParams Params => new MovieSceneSkeletalAnimationParams(AddrOf(0xD8));
        public AnimSequence AnimSequence { get { var __p = GetAt<System.IntPtr>(0x1B0); return __p==System.IntPtr.Zero?null:new AnimSequence(__p); } set => SetAt(0x1B0, value?.Pointer ?? System.IntPtr.Zero); }
        public AnimSequenceBase Animation { get { var __p = GetAt<System.IntPtr>(0x1B8); return __p==System.IntPtr.Zero?null:new AnimSequenceBase(__p); } set => SetAt(0x1B8, value?.Pointer ?? System.IntPtr.Zero); }
        public float StartOffset { get => GetAt<float>(0x1C0); set => SetAt(0x1C0, value); }
        public float EndOffset { get => GetAt<float>(0x1C4); set => SetAt(0x1C4, value); }
        public float PlayRate { get => GetAt<float>(0x1C8); set => SetAt(0x1C8, value); }
        public bool bReverse { get => Native.GetPropBool(Pointer, "bReverse"); set => Native.SetPropBool(Pointer, "bReverse", value); }
        public string SlotName => Native.GetPropName(Pointer, "SlotName"); // FName
        public FName SlotName_Raw { get => GetAt<FName>(0x1D0); set => SetAt(0x1D0, value); }
    }

    public class MovieSceneSkeletalAnimationTrack : MovieSceneNameableTrack
    {
        public const string UeClassName = "MovieSceneSkeletalAnimationTrack";
        public MovieSceneSkeletalAnimationTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSkeletalAnimationTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSkeletalAnimationTrack(p);
        public static MovieSceneSkeletalAnimationTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSkeletalAnimationTrack(o.Pointer); }
        public static MovieSceneSkeletalAnimationTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSkeletalAnimationTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSkeletalAnimationTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> AnimationSections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
        public bool bUseLegacySectionIndexBlend { get => Native.GetPropBool(Pointer, "bUseLegacySectionIndexBlend"); set => Native.SetPropBool(Pointer, "bUseLegacySectionIndexBlend", value); }
    }

    public class MovieSceneSlomoSection : MovieSceneFloatSection
    {
        public const string UeClassName = "MovieSceneSlomoSection";
        public MovieSceneSlomoSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSlomoSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSlomoSection(p);
        public static MovieSceneSlomoSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSlomoSection(o.Pointer); }
        public static MovieSceneSlomoSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSlomoSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSlomoSection(a[i].Pointer); return r; }
    }

    public class MovieSceneSlomoTrack : MovieSceneFloatTrack
    {
        public const string UeClassName = "MovieSceneSlomoTrack";
        public MovieSceneSlomoTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSlomoTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSlomoTrack(p);
        public static MovieSceneSlomoTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSlomoTrack(o.Pointer); }
        public static MovieSceneSlomoTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSlomoTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSlomoTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneSpawnSection : MovieSceneBoolSection
    {
        public const string UeClassName = "MovieSceneSpawnSection";
        public MovieSceneSpawnSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSpawnSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSpawnSection(p);
        public static MovieSceneSpawnSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSpawnSection(o.Pointer); }
        public static MovieSceneSpawnSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSpawnSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSpawnSection(a[i].Pointer); return r; }
    }

    public class MovieSceneSpawnTrack : MovieSceneTrack
    {
        public const string UeClassName = "MovieSceneSpawnTrack";
        public MovieSceneSpawnTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneSpawnTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneSpawnTrack(p);
        public static MovieSceneSpawnTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneSpawnTrack(o.Pointer); }
        public static MovieSceneSpawnTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneSpawnTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneSpawnTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
        public Guid ObjectGuid => new Guid(AddrOf(0x68));
    }

    public class MovieSceneStringSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneStringSection";
        public MovieSceneStringSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneStringSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneStringSection(p);
        public static MovieSceneStringSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneStringSection(o.Pointer); }
        public static MovieSceneStringSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneStringSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneStringSection(a[i].Pointer); return r; }
        public MovieSceneStringChannel StringCurve => new MovieSceneStringChannel(AddrOf(0xD8));
    }

    public class MovieSceneStringTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneStringTrack";
        public MovieSceneStringTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneStringTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneStringTrack(p);
        public static MovieSceneStringTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneStringTrack(o.Pointer); }
        public static MovieSceneStringTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneStringTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneStringTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneTransformTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneTransformTrack";
        public MovieSceneTransformTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneTransformTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneTransformTrack(p);
        public static MovieSceneTransformTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneTransformTrack(o.Pointer); }
        public static MovieSceneTransformTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneTransformTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneTransformTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneVectorSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneVectorSection";
        public MovieSceneVectorSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneVectorSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneVectorSection(p);
        public static MovieSceneVectorSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneVectorSection(o.Pointer); }
        public static MovieSceneVectorSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneVectorSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneVectorSection(a[i].Pointer); return r; }
        public System.IntPtr Curves => AddrOf(0xD8); // [4] static array
        public int ChannelsUsed { get => GetAt<int>(0x358); set => SetAt(0x358, value); }
    }

    public class MovieSceneVectorTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneVectorTrack";
        public MovieSceneVectorTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneVectorTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneVectorTrack(p);
        public static MovieSceneVectorTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneVectorTrack(o.Pointer); }
        public static MovieSceneVectorTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneVectorTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneVectorTrack(a[i].Pointer); return r; }
        public int NumChannelsUsed { get => GetAt<int>(0x88); set => SetAt(0x88, value); }
    }

    public class MovieSceneVisibilityTrack : MovieSceneBoolTrack
    {
        public const string UeClassName = "MovieSceneVisibilityTrack";
        public MovieSceneVisibilityTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneVisibilityTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneVisibilityTrack(p);
        public static MovieSceneVisibilityTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneVisibilityTrack(o.Pointer); }
        public static MovieSceneVisibilityTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneVisibilityTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneVisibilityTrack(a[i].Pointer); return r; }
    }

}
