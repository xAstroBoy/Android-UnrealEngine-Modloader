// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/MovieSceneCapture
using System;

namespace UEModLoader.Game
{
    public enum EHDRCaptureGamut
    {
        HCGM_Rec709 = 0,
        HCGM_P3DCI = 1,
        HCGM_Rec2020 = 2,
        HCGM_ACES = 3,
        HCGM_ACEScg = 4,
        HCGM_Linear = 5,
    }

    public enum EMovieSceneCaptureProtocolState
    {
        Idle = 0,
        Initialized = 1,
        Capturing = 2,
        Finalizing = 3,
    }

    public class CompositionGraphCapturePasses : StructProxy
    {
        public CompositionGraphCapturePasses(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Value => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<FString>
    }

    public class FrameMetrics : StructProxy
    {
        public FrameMetrics(global::System.IntPtr ptr) : base(ptr) {}
        public float TotalElapsedTime { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float FrameDelta { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public int FrameNumber { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public int NumDroppedFrames { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
    }

    public class MovieSceneCaptureSettings : StructProxy
    {
        public MovieSceneCaptureSettings(global::System.IntPtr ptr) : base(ptr) {}
        public DirectoryPath OutputDirectory => new DirectoryPath(AddrOf(0x0));
        public GameModeBase GameModeOverride { get { var __p = GetAt<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new GameModeBase(__p); } set => SetAt(0x10, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string OutputFormat => Native.ReadFStringAt(AddrOf(0x18)); // FString
        public bool bOverwriteExisting { get => (GetAt<byte>(0x28) & 0xFF) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bUseRelativeFrameNumbers { get => (GetAt<byte>(0x29) & 0xFF) != 0; set { var __b = GetAt<byte>(0x29); SetAt(0x29, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int HandleFrames { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public string MovieExtension => Native.ReadFStringAt(AddrOf(0x30)); // FString
        public byte ZeroPadFrameNumbers { get => GetAt<byte>(0x40); set => SetAt(0x40, value); }
        public FrameRate FrameRate => new FrameRate(AddrOf(0x44));
        public bool bUseCustomFrameRate { get => (GetAt<byte>(0x4C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x4C); SetAt(0x4C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public FrameRate CustomFrameRate => new FrameRate(AddrOf(0x50));
        public CaptureResolution Resolution => new CaptureResolution(AddrOf(0x58));
        public bool bEnableTextureStreaming { get => (GetAt<byte>(0x60) & 0xFF) != 0; set { var __b = GetAt<byte>(0x60); SetAt(0x60, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bCinematicEngineScalability { get => (GetAt<byte>(0x61) & 0xFF) != 0; set { var __b = GetAt<byte>(0x61); SetAt(0x61, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bCinematicMode { get => (GetAt<byte>(0x62) & 0xFF) != 0; set { var __b = GetAt<byte>(0x62); SetAt(0x62, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bAllowMovement { get => (GetAt<byte>(0x63) & 0xFF) != 0; set { var __b = GetAt<byte>(0x63); SetAt(0x63, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bAllowTurning { get => (GetAt<byte>(0x64) & 0xFF) != 0; set { var __b = GetAt<byte>(0x64); SetAt(0x64, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bShowPlayer { get => (GetAt<byte>(0x65) & 0xFF) != 0; set { var __b = GetAt<byte>(0x65); SetAt(0x65, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bShowHUD { get => (GetAt<byte>(0x66) & 0xFF) != 0; set { var __b = GetAt<byte>(0x66); SetAt(0x66, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bUsePathTracer { get => (GetAt<byte>(0x67) & 0xFF) != 0; set { var __b = GetAt<byte>(0x67); SetAt(0x67, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int PathTracerSamplePerPixel { get => GetAt<int>(0x68); set => SetAt(0x68, value); }
    }

    public class CaptureResolution : StructProxy
    {
        public CaptureResolution(global::System.IntPtr ptr) : base(ptr) {}
        public int ResX { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int ResY { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class CapturedPixels : StructProxy
    {
        public CapturedPixels(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class CapturedPixelsID : StructProxy
    {
        public CapturedPixelsID(global::System.IntPtr ptr) : base(ptr) {}
        public global::System.IntPtr Identifiers => AddrOf(0x0); // 
    }

    public class MovieSceneCaptureProtocolBase : Object
    {
        public const string UeClassName = "MovieSceneCaptureProtocolBase";
        public MovieSceneCaptureProtocolBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCaptureProtocolBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneCaptureProtocolBase(p);
        public static MovieSceneCaptureProtocolBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCaptureProtocolBase(o.Pointer); }
        public static MovieSceneCaptureProtocolBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCaptureProtocolBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCaptureProtocolBase(a[i].Pointer); return r; }
        public EMovieSceneCaptureProtocolState State { get => (EMovieSceneCaptureProtocolState)GetAt<byte>(0x50); set => SetAt(0x50, (byte)value); }
        /// <summary>[Native] thunk RVA 0x822F954 — hookable via Hooks.InstallAt(NativeFunc_IsCapturing).</summary>
        public static global::System.IntPtr NativeFunc_IsCapturing => Memory.ModuleBase() + 0x822F954;
        public bool IsCapturing()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsCapturing", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x822F99C — hookable via Hooks.InstallAt(NativeFunc_GetState).</summary>
        public static global::System.IntPtr NativeFunc_GetState => Memory.ModuleBase() + 0x822F99C;
        public EMovieSceneCaptureProtocolState GetState()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetState", __pb.Bytes);
            return (EMovieSceneCaptureProtocolState)__pb.Get<byte>(0x0);
        }
    }

    public class MovieSceneAudioCaptureProtocolBase : MovieSceneCaptureProtocolBase
    {
        public const string UeClassName = "MovieSceneAudioCaptureProtocolBase";
        public MovieSceneAudioCaptureProtocolBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneAudioCaptureProtocolBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneAudioCaptureProtocolBase(p);
        public static MovieSceneAudioCaptureProtocolBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneAudioCaptureProtocolBase(o.Pointer); }
        public static MovieSceneAudioCaptureProtocolBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneAudioCaptureProtocolBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneAudioCaptureProtocolBase(a[i].Pointer); return r; }
    }

    public class NullAudioCaptureProtocol : MovieSceneAudioCaptureProtocolBase
    {
        public const string UeClassName = "NullAudioCaptureProtocol";
        public NullAudioCaptureProtocol(global::System.IntPtr ptr) : base(ptr) {}
        public static new NullAudioCaptureProtocol FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NullAudioCaptureProtocol(p);
        public static NullAudioCaptureProtocol FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NullAudioCaptureProtocol(o.Pointer); }
        public static NullAudioCaptureProtocol[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NullAudioCaptureProtocol[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NullAudioCaptureProtocol(a[i].Pointer); return r; }
    }

    public class MasterAudioSubmixCaptureProtocol : MovieSceneAudioCaptureProtocolBase
    {
        public const string UeClassName = "MasterAudioSubmixCaptureProtocol";
        public MasterAudioSubmixCaptureProtocol(global::System.IntPtr ptr) : base(ptr) {}
        public static new MasterAudioSubmixCaptureProtocol FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MasterAudioSubmixCaptureProtocol(p);
        public static MasterAudioSubmixCaptureProtocol FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MasterAudioSubmixCaptureProtocol(o.Pointer); }
        public static MasterAudioSubmixCaptureProtocol[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MasterAudioSubmixCaptureProtocol[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MasterAudioSubmixCaptureProtocol(a[i].Pointer); return r; }
        public string Filename => Native.GetPropString(Pointer, "Filename"); // FString
    }

    public class MovieSceneImageCaptureProtocolBase : MovieSceneCaptureProtocolBase
    {
        public const string UeClassName = "MovieSceneImageCaptureProtocolBase";
        public MovieSceneImageCaptureProtocolBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneImageCaptureProtocolBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneImageCaptureProtocolBase(p);
        public static MovieSceneImageCaptureProtocolBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneImageCaptureProtocolBase(o.Pointer); }
        public static MovieSceneImageCaptureProtocolBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneImageCaptureProtocolBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneImageCaptureProtocolBase(a[i].Pointer); return r; }
    }

    public class CompositionGraphCaptureProtocol : MovieSceneImageCaptureProtocolBase
    {
        public const string UeClassName = "CompositionGraphCaptureProtocol";
        public CompositionGraphCaptureProtocol(global::System.IntPtr ptr) : base(ptr) {}
        public static new CompositionGraphCaptureProtocol FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new CompositionGraphCaptureProtocol(p);
        public static CompositionGraphCaptureProtocol FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CompositionGraphCaptureProtocol(o.Pointer); }
        public static CompositionGraphCaptureProtocol[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CompositionGraphCaptureProtocol[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CompositionGraphCaptureProtocol(a[i].Pointer); return r; }
        public CompositionGraphCapturePasses IncludeRenderPasses => new CompositionGraphCapturePasses(AddrOf(0x58));
        public bool bCaptureFramesInHDR { get => Native.GetPropBool(Pointer, "bCaptureFramesInHDR"); set => Native.SetPropBool(Pointer, "bCaptureFramesInHDR", value); }
        public int HDRCompressionQuality { get => GetAt<int>(0x6C); set => SetAt(0x6C, value); }
        public byte CaptureGamut { get => GetAt<byte>(0x70); set => SetAt(0x70, value); }
        public SoftObjectPath PostProcessingMaterial => new SoftObjectPath(AddrOf(0x78));
        public bool bDisableScreenPercentage { get => Native.GetPropBool(Pointer, "bDisableScreenPercentage"); set => Native.SetPropBool(Pointer, "bDisableScreenPercentage", value); }
        public MaterialInterface PostProcessingMaterialPtr { get { var __p = GetAt<global::System.IntPtr>(0x98); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x98, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class FrameGrabberProtocol : MovieSceneImageCaptureProtocolBase
    {
        public const string UeClassName = "FrameGrabberProtocol";
        public FrameGrabberProtocol(global::System.IntPtr ptr) : base(ptr) {}
        public static new FrameGrabberProtocol FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FrameGrabberProtocol(p);
        public static FrameGrabberProtocol FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FrameGrabberProtocol(o.Pointer); }
        public static FrameGrabberProtocol[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FrameGrabberProtocol[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FrameGrabberProtocol(a[i].Pointer); return r; }
    }

    public class ImageSequenceProtocol : FrameGrabberProtocol
    {
        public const string UeClassName = "ImageSequenceProtocol";
        public ImageSequenceProtocol(global::System.IntPtr ptr) : base(ptr) {}
        public static new ImageSequenceProtocol FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ImageSequenceProtocol(p);
        public static ImageSequenceProtocol FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ImageSequenceProtocol(o.Pointer); }
        public static ImageSequenceProtocol[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ImageSequenceProtocol[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ImageSequenceProtocol(a[i].Pointer); return r; }
    }

    public class CompressedImageSequenceProtocol : ImageSequenceProtocol
    {
        public const string UeClassName = "CompressedImageSequenceProtocol";
        public CompressedImageSequenceProtocol(global::System.IntPtr ptr) : base(ptr) {}
        public static new CompressedImageSequenceProtocol FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new CompressedImageSequenceProtocol(p);
        public static CompressedImageSequenceProtocol FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CompressedImageSequenceProtocol(o.Pointer); }
        public static CompressedImageSequenceProtocol[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CompressedImageSequenceProtocol[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CompressedImageSequenceProtocol(a[i].Pointer); return r; }
        public int CompressionQuality { get => GetAt<int>(0xD8); set => SetAt(0xD8, value); }
    }

    public class ImageSequenceProtocol_BMP : ImageSequenceProtocol
    {
        public const string UeClassName = "ImageSequenceProtocol_BMP";
        public ImageSequenceProtocol_BMP(global::System.IntPtr ptr) : base(ptr) {}
        public static new ImageSequenceProtocol_BMP FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ImageSequenceProtocol_BMP(p);
        public static ImageSequenceProtocol_BMP FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ImageSequenceProtocol_BMP(o.Pointer); }
        public static ImageSequenceProtocol_BMP[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ImageSequenceProtocol_BMP[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ImageSequenceProtocol_BMP(a[i].Pointer); return r; }
    }

    public class ImageSequenceProtocol_PNG : CompressedImageSequenceProtocol
    {
        public const string UeClassName = "ImageSequenceProtocol_PNG";
        public ImageSequenceProtocol_PNG(global::System.IntPtr ptr) : base(ptr) {}
        public static new ImageSequenceProtocol_PNG FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ImageSequenceProtocol_PNG(p);
        public static ImageSequenceProtocol_PNG FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ImageSequenceProtocol_PNG(o.Pointer); }
        public static ImageSequenceProtocol_PNG[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ImageSequenceProtocol_PNG[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ImageSequenceProtocol_PNG(a[i].Pointer); return r; }
    }

    public class ImageSequenceProtocol_JPG : CompressedImageSequenceProtocol
    {
        public const string UeClassName = "ImageSequenceProtocol_JPG";
        public ImageSequenceProtocol_JPG(global::System.IntPtr ptr) : base(ptr) {}
        public static new ImageSequenceProtocol_JPG FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ImageSequenceProtocol_JPG(p);
        public static ImageSequenceProtocol_JPG FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ImageSequenceProtocol_JPG(o.Pointer); }
        public static ImageSequenceProtocol_JPG[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ImageSequenceProtocol_JPG[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ImageSequenceProtocol_JPG(a[i].Pointer); return r; }
    }

    public class ImageSequenceProtocol_EXR : ImageSequenceProtocol
    {
        public const string UeClassName = "ImageSequenceProtocol_EXR";
        public ImageSequenceProtocol_EXR(global::System.IntPtr ptr) : base(ptr) {}
        public static new ImageSequenceProtocol_EXR FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ImageSequenceProtocol_EXR(p);
        public static ImageSequenceProtocol_EXR FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ImageSequenceProtocol_EXR(o.Pointer); }
        public static ImageSequenceProtocol_EXR[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ImageSequenceProtocol_EXR[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ImageSequenceProtocol_EXR(a[i].Pointer); return r; }
        public bool bCompressed { get => Native.GetPropBool(Pointer, "bCompressed"); set => Native.SetPropBool(Pointer, "bCompressed", value); }
        public byte CaptureGamut { get => GetAt<byte>(0xD9); set => SetAt(0xD9, value); }
    }

    public class MovieSceneCaptureInterface : Interface
    {
        public const string UeClassName = "MovieSceneCaptureInterface";
        public MovieSceneCaptureInterface(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCaptureInterface FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneCaptureInterface(p);
        public static MovieSceneCaptureInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCaptureInterface(o.Pointer); }
        public static MovieSceneCaptureInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCaptureInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCaptureInterface(a[i].Pointer); return r; }
    }

    public class MovieSceneCapture : Object
    {
        public const string UeClassName = "MovieSceneCapture";
        public MovieSceneCapture(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCapture FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneCapture(p);
        public static MovieSceneCapture FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCapture(o.Pointer); }
        public static MovieSceneCapture[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCapture[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCapture(a[i].Pointer); return r; }
        public SoftClassPath ImageCaptureProtocolType => new SoftClassPath(AddrOf(0x38));
        public SoftClassPath AudioCaptureProtocolType => new SoftClassPath(AddrOf(0x50));
        public MovieSceneImageCaptureProtocolBase ImageCaptureProtocol { get { var __p = GetAt<global::System.IntPtr>(0x68); return __p==global::System.IntPtr.Zero?null:new MovieSceneImageCaptureProtocolBase(__p); } set => SetAt(0x68, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MovieSceneAudioCaptureProtocolBase AudioCaptureProtocol { get { var __p = GetAt<global::System.IntPtr>(0x70); return __p==global::System.IntPtr.Zero?null:new MovieSceneAudioCaptureProtocolBase(__p); } set => SetAt(0x70, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MovieSceneCaptureSettings Settings => new MovieSceneCaptureSettings(AddrOf(0x78));
        public bool bUseSeparateProcess { get => Native.GetPropBool(Pointer, "bUseSeparateProcess"); set => Native.SetPropBool(Pointer, "bUseSeparateProcess", value); }
        public bool bCloseEditorWhenCaptureStarts { get => Native.GetPropBool(Pointer, "bCloseEditorWhenCaptureStarts"); set => Native.SetPropBool(Pointer, "bCloseEditorWhenCaptureStarts", value); }
        public string AdditionalCommandLineArguments => Native.GetPropString(Pointer, "AdditionalCommandLineArguments"); // FString
        public string InheritedCommandLineArguments => Native.GetPropString(Pointer, "InheritedCommandLineArguments"); // FString
        /// <summary>[Native] thunk RVA 0x822E368 — hookable via Hooks.InstallAt(NativeFunc_SetImageCaptureProtocolType).</summary>
        public static global::System.IntPtr NativeFunc_SetImageCaptureProtocolType => Memory.ModuleBase() + 0x822E368;
        public void SetImageCaptureProtocolType(MovieSceneCaptureProtocolBase ProtocolType)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ProtocolType);
            CallRaw("SetImageCaptureProtocolType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x822E2C4 — hookable via Hooks.InstallAt(NativeFunc_SetAudioCaptureProtocolType).</summary>
        public static global::System.IntPtr NativeFunc_SetAudioCaptureProtocolType => Memory.ModuleBase() + 0x822E2C4;
        public void SetAudioCaptureProtocolType(MovieSceneCaptureProtocolBase ProtocolType)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ProtocolType);
            CallRaw("SetAudioCaptureProtocolType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x822E428 — hookable via Hooks.InstallAt(NativeFunc_GetImageCaptureProtocol).</summary>
        public static global::System.IntPtr NativeFunc_GetImageCaptureProtocol => Memory.ModuleBase() + 0x822E428;
        public MovieSceneCaptureProtocolBase GetImageCaptureProtocol()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetImageCaptureProtocol", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MovieSceneCaptureProtocolBase(__p); }
        }
        /// <summary>[Native] thunk RVA 0x822E40C — hookable via Hooks.InstallAt(NativeFunc_GetAudioCaptureProtocol).</summary>
        public static global::System.IntPtr NativeFunc_GetAudioCaptureProtocol => Memory.ModuleBase() + 0x822E40C;
        public MovieSceneCaptureProtocolBase GetAudioCaptureProtocol()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetAudioCaptureProtocol", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MovieSceneCaptureProtocolBase(__p); }
        }
    }

    public class LevelCapture : MovieSceneCapture
    {
        public const string UeClassName = "LevelCapture";
        public LevelCapture(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelCapture FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelCapture(p);
        public static LevelCapture FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelCapture(o.Pointer); }
        public static LevelCapture[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelCapture[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelCapture(a[i].Pointer); return r; }
        public bool bAutoStartCapture { get => Native.GetPropBool(Pointer, "bAutoStartCapture"); set => Native.SetPropBool(Pointer, "bAutoStartCapture", value); }
        public Guid PrerequisiteActorId => new Guid(AddrOf(0x22C));
    }

    public class MovieSceneCaptureEnvironment : Object
    {
        public const string UeClassName = "MovieSceneCaptureEnvironment";
        public MovieSceneCaptureEnvironment(global::System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneCaptureEnvironment FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MovieSceneCaptureEnvironment(p);
        public static MovieSceneCaptureEnvironment FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneCaptureEnvironment(o.Pointer); }
        public static MovieSceneCaptureEnvironment[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneCaptureEnvironment[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneCaptureEnvironment(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x822ED88 — hookable via Hooks.InstallAt(NativeFunc_IsCaptureInProgress).</summary>
        public static global::System.IntPtr NativeFunc_IsCaptureInProgress => Memory.ModuleBase() + 0x822ED88;
        public bool IsCaptureInProgress()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsCaptureInProgress", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x822EDF4 — hookable via Hooks.InstallAt(NativeFunc_GetCaptureFrameNumber).</summary>
        public static global::System.IntPtr NativeFunc_GetCaptureFrameNumber => Memory.ModuleBase() + 0x822EDF4;
        public int GetCaptureFrameNumber()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetCaptureFrameNumber", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x822EDC0 — hookable via Hooks.InstallAt(NativeFunc_GetCaptureElapsedTime).</summary>
        public static global::System.IntPtr NativeFunc_GetCaptureElapsedTime => Memory.ModuleBase() + 0x822EDC0;
        public float GetCaptureElapsedTime()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetCaptureElapsedTime", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x822ED54 — hookable via Hooks.InstallAt(NativeFunc_FindImageCaptureProtocol).</summary>
        public static global::System.IntPtr NativeFunc_FindImageCaptureProtocol => Memory.ModuleBase() + 0x822ED54;
        public MovieSceneImageCaptureProtocolBase FindImageCaptureProtocol()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("FindImageCaptureProtocol", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MovieSceneImageCaptureProtocolBase(__p); }
        }
        /// <summary>[Native] thunk RVA 0x822ED20 — hookable via Hooks.InstallAt(NativeFunc_FindAudioCaptureProtocol).</summary>
        public static global::System.IntPtr NativeFunc_FindAudioCaptureProtocol => Memory.ModuleBase() + 0x822ED20;
        public MovieSceneAudioCaptureProtocolBase FindAudioCaptureProtocol()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("FindAudioCaptureProtocol", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MovieSceneAudioCaptureProtocolBase(__p); }
        }
    }

    public class UserDefinedCaptureProtocol : MovieSceneImageCaptureProtocolBase
    {
        public const string UeClassName = "UserDefinedCaptureProtocol";
        public UserDefinedCaptureProtocol(global::System.IntPtr ptr) : base(ptr) {}
        public static new UserDefinedCaptureProtocol FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UserDefinedCaptureProtocol(p);
        public static UserDefinedCaptureProtocol FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UserDefinedCaptureProtocol(o.Pointer); }
        public static UserDefinedCaptureProtocol[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UserDefinedCaptureProtocol[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UserDefinedCaptureProtocol(a[i].Pointer); return r; }
        public World World { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new World(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x8231BF4 — hookable via Hooks.InstallAt(NativeFunc_StopCapturingFinalPixels).</summary>
        public static global::System.IntPtr NativeFunc_StopCapturingFinalPixels => Memory.ModuleBase() + 0x8231BF4;
        public void StopCapturingFinalPixels()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopCapturingFinalPixels", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8231C08 — hookable via Hooks.InstallAt(NativeFunc_StartCapturingFinalPixels).</summary>
        public static global::System.IntPtr NativeFunc_StartCapturingFinalPixels => Memory.ModuleBase() + 0x8231C08;
        public void StartCapturingFinalPixels(global::System.IntPtr StreamID)
        {
            var __pb = new ParamBuffer(80);
            __pb.Set<global::System.IntPtr>(0x0, StreamID);
            CallRaw("StartCapturingFinalPixels", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8231CE4 — hookable via Hooks.InstallAt(NativeFunc_ResolveBuffer).</summary>
        public static global::System.IntPtr NativeFunc_ResolveBuffer => Memory.ModuleBase() + 0x8231CE4;
        public void ResolveBuffer(Texture Buffer, global::System.IntPtr BufferID)
        {
            var __pb = new ParamBuffer(88);
            __pb.SetObject(0x0, Buffer);
            __pb.Set<global::System.IntPtr>(0x8, BufferID);
            CallRaw("ResolveBuffer", __pb.Bytes);
        }
        public void OnWarmUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnWarmUp", __pb.Bytes);
        }
        public void OnTick()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnTick", __pb.Bytes);
        }
        public void OnStartCapture()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnStartCapture", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8231E3C — hookable via Hooks.InstallAt(NativeFunc_OnSetup).</summary>
        public static global::System.IntPtr NativeFunc_OnSetup => Memory.ModuleBase() + 0x8231E3C;
        public bool OnSetup()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("OnSetup", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void OnPreTick()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnPreTick", __pb.Bytes);
        }
        public void OnPixelsReceived(global::System.IntPtr Pixels, global::System.IntPtr ID, global::System.IntPtr FrameMetrics)
        {
            var __pb = new ParamBuffer(112);
            __pb.Set<global::System.IntPtr>(0x0, Pixels);
            __pb.Set<global::System.IntPtr>(0x10, ID);
            __pb.Set<global::System.IntPtr>(0x60, FrameMetrics);
            CallRaw("OnPixelsReceived", __pb.Bytes);
        }
        public void OnPauseCapture()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnPauseCapture", __pb.Bytes);
        }
        public void OnFinalize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnFinalize", __pb.Bytes);
        }
        public void OnCaptureFrame()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnCaptureFrame", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8231DFC — hookable via Hooks.InstallAt(NativeFunc_OnCanFinalize).</summary>
        public static global::System.IntPtr NativeFunc_OnCanFinalize => Memory.ModuleBase() + 0x8231DFC;
        public bool OnCanFinalize()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("OnCanFinalize", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void OnBeginFinalize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnBeginFinalize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8231AC8 — hookable via Hooks.InstallAt(NativeFunc_GetCurrentFrameMetrics).</summary>
        public static global::System.IntPtr NativeFunc_GetCurrentFrameMetrics => Memory.ModuleBase() + 0x8231AC8;
        public global::System.IntPtr GetCurrentFrameMetrics()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetCurrentFrameMetrics", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x8231AE4 — hookable via Hooks.InstallAt(NativeFunc_GenerateFilename).</summary>
        public static global::System.IntPtr NativeFunc_GenerateFilename => Memory.ModuleBase() + 0x8231AE4;
        public global::System.IntPtr GenerateFilename(global::System.IntPtr InFrameMetrics)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InFrameMetrics);
            CallRaw("GenerateFilename", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x10);
        }
    }

    public class UserDefinedImageCaptureProtocol : UserDefinedCaptureProtocol
    {
        public const string UeClassName = "UserDefinedImageCaptureProtocol";
        public UserDefinedImageCaptureProtocol(global::System.IntPtr ptr) : base(ptr) {}
        public static new UserDefinedImageCaptureProtocol FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UserDefinedImageCaptureProtocol(p);
        public static UserDefinedImageCaptureProtocol FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UserDefinedImageCaptureProtocol(o.Pointer); }
        public static UserDefinedImageCaptureProtocol[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UserDefinedImageCaptureProtocol[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UserDefinedImageCaptureProtocol(a[i].Pointer); return r; }
        public EDesiredImageFormat Format { get => (EDesiredImageFormat)GetAt<byte>(0xD8); set => SetAt(0xD8, (byte)value); }
        public bool bEnableCompression { get => Native.GetPropBool(Pointer, "bEnableCompression"); set => Native.SetPropBool(Pointer, "bEnableCompression", value); }
        public int CompressionQuality { get => GetAt<int>(0xDC); set => SetAt(0xDC, value); }
        /// <summary>[Native] thunk RVA 0x8232CD4 — hookable via Hooks.InstallAt(NativeFunc_WriteImageToDisk).</summary>
        public static global::System.IntPtr NativeFunc_WriteImageToDisk => Memory.ModuleBase() + 0x8232CD4;
        public void WriteImageToDisk(global::System.IntPtr PixelData, global::System.IntPtr StreamID, global::System.IntPtr FrameMetrics, bool bCopyImageData)
        {
            var __pb = new ParamBuffer(113);
            __pb.Set<global::System.IntPtr>(0x0, PixelData);
            __pb.Set<global::System.IntPtr>(0x10, StreamID);
            __pb.Set<global::System.IntPtr>(0x60, FrameMetrics);
            __pb.Set<byte>(0x70, (byte)(bCopyImageData?1:0));
            CallRaw("WriteImageToDisk", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8232F00 — hookable via Hooks.InstallAt(NativeFunc_GenerateFilenameForCurrentFrame).</summary>
        public static global::System.IntPtr NativeFunc_GenerateFilenameForCurrentFrame => Memory.ModuleBase() + 0x8232F00;
        public global::System.IntPtr GenerateFilenameForCurrentFrame()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GenerateFilenameForCurrentFrame", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x8232FB0 — hookable via Hooks.InstallAt(NativeFunc_GenerateFilenameForBuffer).</summary>
        public static global::System.IntPtr NativeFunc_GenerateFilenameForBuffer => Memory.ModuleBase() + 0x8232FB0;
        public global::System.IntPtr GenerateFilenameForBuffer(Texture Buffer, global::System.IntPtr StreamID)
        {
            var __pb = new ParamBuffer(104);
            __pb.SetObject(0x0, Buffer);
            __pb.Set<global::System.IntPtr>(0x8, StreamID);
            CallRaw("GenerateFilenameForBuffer", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x58);
        }
    }

    public class VideoCaptureProtocol : FrameGrabberProtocol
    {
        public const string UeClassName = "VideoCaptureProtocol";
        public VideoCaptureProtocol(global::System.IntPtr ptr) : base(ptr) {}
        public static new VideoCaptureProtocol FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VideoCaptureProtocol(p);
        public static VideoCaptureProtocol FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VideoCaptureProtocol(o.Pointer); }
        public static VideoCaptureProtocol[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VideoCaptureProtocol[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VideoCaptureProtocol(a[i].Pointer); return r; }
        public bool bUseCompression { get => Native.GetPropBool(Pointer, "bUseCompression"); set => Native.SetPropBool(Pointer, "bUseCompression", value); }
        public float CompressionQuality { get => GetAt<float>(0x6C); set => SetAt(0x6C, value); }
    }

}
