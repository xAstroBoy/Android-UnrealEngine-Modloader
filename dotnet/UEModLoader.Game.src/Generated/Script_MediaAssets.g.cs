// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/MediaAssets
using System;

namespace UEModLoader.Game
{
    public enum EMediaWebcamCaptureDeviceFilter
    {
        None = 0,
        DepthSensor = 1,
        Front = 2,
        Rear = 4,
        Unknown = 8,
    }

    public enum EMediaVideoCaptureDeviceFilter
    {
        None = 0,
        Card = 1,
        Software = 2,
        Unknown = 4,
        Webcam = 8,
    }

    public enum EMediaAudioCaptureDeviceFilter
    {
        None = 0,
        Card = 1,
        Microphone = 2,
        Software = 4,
        Unknown = 8,
    }

    public enum EMediaPlayerTrack
    {
        Audio = 0,
        Caption = 1,
        Metadata = 2,
        Script = 3,
        Subtitle = 4,
        Text = 5,
        Video = 6,
    }

    public enum EMediaSoundComponentFFTSize
    {
        Min = 0,
        Small = 1,
        Medium = 2,
        Large = 3,
    }

    public enum EMediaSoundChannels
    {
        Mono = 0,
        Stereo = 1,
        Surround = 2,
    }

    public class MediaCaptureDevice : StructProxy
    {
        public MediaCaptureDevice(global::System.IntPtr ptr) : base(ptr) {}
        public global::System.IntPtr DisplayName => AddrOf(0x0); // 
        public string URL => Native.ReadFStringAt(AddrOf(0x18)); // FString
    }

    public class MediaSoundComponentSpectralData : StructProxy
    {
        public MediaSoundComponentSpectralData(global::System.IntPtr ptr) : base(ptr) {}
        public float FrequencyHz { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Magnitude { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class MediaSource : Object
    {
        public const string UeClassName = "MediaSource";
        public MediaSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new MediaSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MediaSource(p);
        public static MediaSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MediaSource(o.Pointer); }
        public static MediaSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MediaSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MediaSource(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x81F5AF0 — hookable via Hooks.InstallAt(NativeFunc_Validate).</summary>
        public static global::System.IntPtr NativeFunc_Validate => Memory.ModuleBase() + 0x81F5AF0;
        public bool Validate()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Validate", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81F570C — hookable via Hooks.InstallAt(NativeFunc_SetMediaOptionString).</summary>
        public static global::System.IntPtr NativeFunc_SetMediaOptionString => Memory.ModuleBase() + 0x81F570C;
        public void SetMediaOptionString(FName Key, global::System.IntPtr Value)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Key);
            __pb.Set<global::System.IntPtr>(0x8, Value);
            CallRaw("SetMediaOptionString", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F580C — hookable via Hooks.InstallAt(NativeFunc_SetMediaOptionInt64).</summary>
        public static global::System.IntPtr NativeFunc_SetMediaOptionInt64 => Memory.ModuleBase() + 0x81F580C;
        public void SetMediaOptionInt64(FName Key, long Value)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Key);
            __pb.Set(0x8, Value);
            CallRaw("SetMediaOptionInt64", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F5900 — hookable via Hooks.InstallAt(NativeFunc_SetMediaOptionFloat).</summary>
        public static global::System.IntPtr NativeFunc_SetMediaOptionFloat => Memory.ModuleBase() + 0x81F5900;
        public void SetMediaOptionFloat(FName Key, float Value)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, Key);
            __pb.Set(0x8, Value);
            CallRaw("SetMediaOptionFloat", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F59F4 — hookable via Hooks.InstallAt(NativeFunc_SetMediaOptionBool).</summary>
        public static global::System.IntPtr NativeFunc_SetMediaOptionBool => Memory.ModuleBase() + 0x81F59F4;
        public void SetMediaOptionBool(FName Key, bool Value)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, Key);
            __pb.Set<byte>(0x8, (byte)(Value?1:0));
            CallRaw("SetMediaOptionBool", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F5B30 — hookable via Hooks.InstallAt(NativeFunc_GetUrl).</summary>
        public static global::System.IntPtr NativeFunc_GetUrl => Memory.ModuleBase() + 0x81F5B30;
        public global::System.IntPtr GetUrl()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetUrl", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
    }

    public class BaseMediaSource : MediaSource
    {
        public const string UeClassName = "BaseMediaSource";
        public BaseMediaSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new BaseMediaSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BaseMediaSource(p);
        public static BaseMediaSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BaseMediaSource(o.Pointer); }
        public static BaseMediaSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BaseMediaSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BaseMediaSource(a[i].Pointer); return r; }
        public string PlayerName => Native.GetPropName(Pointer, "PlayerName"); // FName
        public FName PlayerName_Raw { get => GetAt<FName>(0x80); set => SetAt(0x80, value); }
    }

    public class FileMediaSource : BaseMediaSource
    {
        public const string UeClassName = "FileMediaSource";
        public FileMediaSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new FileMediaSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FileMediaSource(p);
        public static FileMediaSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FileMediaSource(o.Pointer); }
        public static FileMediaSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FileMediaSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FileMediaSource(a[i].Pointer); return r; }
        public string FilePath => Native.GetPropString(Pointer, "FilePath"); // FString
        public bool PrecacheFile { get => Native.GetPropBool(Pointer, "PrecacheFile"); set => Native.SetPropBool(Pointer, "PrecacheFile", value); }
        /// <summary>[Native] thunk RVA 0x81EB278 — hookable via Hooks.InstallAt(NativeFunc_SetFilePath).</summary>
        public static global::System.IntPtr NativeFunc_SetFilePath => Memory.ModuleBase() + 0x81EB278;
        public void SetFilePath(global::System.IntPtr Path)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, Path);
            CallRaw("SetFilePath", __pb.Bytes);
        }
    }

    public class MediaBlueprintFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "MediaBlueprintFunctionLibrary";
        public MediaBlueprintFunctionLibrary(global::System.IntPtr ptr) : base(ptr) {}
        public static new MediaBlueprintFunctionLibrary FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MediaBlueprintFunctionLibrary(p);
        public static MediaBlueprintFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MediaBlueprintFunctionLibrary(o.Pointer); }
        public static MediaBlueprintFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MediaBlueprintFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MediaBlueprintFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x81EC2C8 — hookable via Hooks.InstallAt(NativeFunc_EnumerateWebcamCaptureDevices).</summary>
        public static global::System.IntPtr NativeFunc_EnumerateWebcamCaptureDevices => Memory.ModuleBase() + 0x81EC2C8;
        public void EnumerateWebcamCaptureDevices(global::System.IntPtr OutDevices, int Filter)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, OutDevices);
            __pb.Set(0x10, Filter);
            CallRaw("EnumerateWebcamCaptureDevices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81EC45C — hookable via Hooks.InstallAt(NativeFunc_EnumerateVideoCaptureDevices).</summary>
        public static global::System.IntPtr NativeFunc_EnumerateVideoCaptureDevices => Memory.ModuleBase() + 0x81EC45C;
        public void EnumerateVideoCaptureDevices(global::System.IntPtr OutDevices, int Filter)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, OutDevices);
            __pb.Set(0x10, Filter);
            CallRaw("EnumerateVideoCaptureDevices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81EC5F0 — hookable via Hooks.InstallAt(NativeFunc_EnumerateAudioCaptureDevices).</summary>
        public static global::System.IntPtr NativeFunc_EnumerateAudioCaptureDevices => Memory.ModuleBase() + 0x81EC5F0;
        public void EnumerateAudioCaptureDevices(global::System.IntPtr OutDevices, int Filter)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, OutDevices);
            __pb.Set(0x10, Filter);
            CallRaw("EnumerateAudioCaptureDevices", __pb.Bytes);
        }
    }

    public class MediaComponent : ActorComponent
    {
        public const string UeClassName = "MediaComponent";
        public MediaComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new MediaComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MediaComponent(p);
        public static MediaComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MediaComponent(o.Pointer); }
        public static MediaComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MediaComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MediaComponent(a[i].Pointer); return r; }
        public MediaTexture MediaTexture { get { var __p = GetAt<global::System.IntPtr>(0xB0); return __p==global::System.IntPtr.Zero?null:new MediaTexture(__p); } set => SetAt(0xB0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MediaPlayer MediaPlayer { get { var __p = GetAt<global::System.IntPtr>(0xB8); return __p==global::System.IntPtr.Zero?null:new MediaPlayer(__p); } set => SetAt(0xB8, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x81ED518 — hookable via Hooks.InstallAt(NativeFunc_GetMediaTexture).</summary>
        public static global::System.IntPtr NativeFunc_GetMediaTexture => Memory.ModuleBase() + 0x81ED518;
        public MediaTexture GetMediaTexture()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetMediaTexture", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MediaTexture(__p); }
        }
        /// <summary>[Native] thunk RVA 0x81ED54C — hookable via Hooks.InstallAt(NativeFunc_GetMediaPlayer).</summary>
        public static global::System.IntPtr NativeFunc_GetMediaPlayer => Memory.ModuleBase() + 0x81ED54C;
        public MediaPlayer GetMediaPlayer()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetMediaPlayer", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MediaPlayer(__p); }
        }
    }

    public class MediaPlayer : Object
    {
        public const string UeClassName = "MediaPlayer";
        public MediaPlayer(global::System.IntPtr ptr) : base(ptr) {}
        public static new MediaPlayer FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MediaPlayer(p);
        public static MediaPlayer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MediaPlayer(o.Pointer); }
        public static MediaPlayer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MediaPlayer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MediaPlayer(a[i].Pointer); return r; }
        public global::System.IntPtr OnEndReached => AddrOf(0x28); // 
        public global::System.IntPtr OnMediaClosed => AddrOf(0x38); // 
        public global::System.IntPtr OnMediaOpened => AddrOf(0x48); // 
        public global::System.IntPtr OnMediaOpenFailed => AddrOf(0x58); // 
        public global::System.IntPtr OnPlaybackResumed => AddrOf(0x68); // 
        public global::System.IntPtr OnPlaybackSuspended => AddrOf(0x78); // 
        public global::System.IntPtr OnSeekCompleted => AddrOf(0x88); // 
        public global::System.IntPtr OnTracksChanged => AddrOf(0x98); // 
        public Timespan CacheAhead => new Timespan(AddrOf(0xA8));
        public Timespan CacheBehind => new Timespan(AddrOf(0xB0));
        public Timespan CacheBehindGame => new Timespan(AddrOf(0xB8));
        public bool NativeAudioOut { get => Native.GetPropBool(Pointer, "NativeAudioOut"); set => Native.SetPropBool(Pointer, "NativeAudioOut", value); }
        public bool PlayOnOpen { get => Native.GetPropBool(Pointer, "PlayOnOpen"); set => Native.SetPropBool(Pointer, "PlayOnOpen", value); }
        public bool Shuffle { get => Native.GetPropBool(Pointer, "Shuffle"); set => Native.SetPropBool(Pointer, "Shuffle", value); }
        public bool Loop { get => Native.GetPropBool(Pointer, "Loop"); set => Native.SetPropBool(Pointer, "Loop", value); }
        public MediaPlaylist Playlist { get { var __p = GetAt<global::System.IntPtr>(0xC8); return __p==global::System.IntPtr.Zero?null:new MediaPlaylist(__p); } set => SetAt(0xC8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int PlaylistIndex { get => GetAt<int>(0xD0); set => SetAt(0xD0, value); }
        public Timespan TimeDelay => new Timespan(AddrOf(0xD8));
        public float HorizontalFieldOfView { get => GetAt<float>(0xE0); set => SetAt(0xE0, value); }
        public float VerticalFieldOfView { get => GetAt<float>(0xE4); set => SetAt(0xE4, value); }
        public Rotator ViewRotation => new Rotator(AddrOf(0xE8));
        public Guid PlayerGuid => new Guid(AddrOf(0x120));
        /// <summary>[Native] thunk RVA 0x81EE000 — hookable via Hooks.InstallAt(NativeFunc_SupportsSeeking).</summary>
        public static global::System.IntPtr NativeFunc_SupportsSeeking => Memory.ModuleBase() + 0x81EE000;
        public bool SupportsSeeking()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("SupportsSeeking", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE038 — hookable via Hooks.InstallAt(NativeFunc_SupportsScrubbing).</summary>
        public static global::System.IntPtr NativeFunc_SupportsScrubbing => Memory.ModuleBase() + 0x81EE038;
        public bool SupportsScrubbing()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("SupportsScrubbing", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE070 — hookable via Hooks.InstallAt(NativeFunc_SupportsRate).</summary>
        public static global::System.IntPtr NativeFunc_SupportsRate => Memory.ModuleBase() + 0x81EE070;
        public bool SupportsRate(float Rate, bool Unthinned)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set(0x0, Rate);
            __pb.Set<byte>(0x4, (byte)(Unthinned?1:0));
            CallRaw("SupportsRate", __pb.Bytes);
            return __pb.Get<byte>(0x5) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE20C — hookable via Hooks.InstallAt(NativeFunc_SetViewRotation).</summary>
        public static global::System.IntPtr NativeFunc_SetViewRotation => Memory.ModuleBase() + 0x81EE20C;
        public bool SetViewRotation(global::System.IntPtr Rotation, bool Absolute)
        {
            var __pb = new ParamBuffer(14);
            __pb.Set<global::System.IntPtr>(0x0, Rotation);
            __pb.Set<byte>(0xC, (byte)(Absolute?1:0));
            CallRaw("SetViewRotation", __pb.Bytes);
            return __pb.Get<byte>(0xD) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE318 — hookable via Hooks.InstallAt(NativeFunc_SetViewField).</summary>
        public static global::System.IntPtr NativeFunc_SetViewField => Memory.ModuleBase() + 0x81EE318;
        public bool SetViewField(float Horizontal, float Vertical, bool Absolute)
        {
            var __pb = new ParamBuffer(10);
            __pb.Set(0x0, Horizontal);
            __pb.Set(0x4, Vertical);
            __pb.Set<byte>(0x8, (byte)(Absolute?1:0));
            CallRaw("SetViewField", __pb.Bytes);
            return __pb.Get<byte>(0x9) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE454 — hookable via Hooks.InstallAt(NativeFunc_SetVideoTrackFrameRate).</summary>
        public static global::System.IntPtr NativeFunc_SetVideoTrackFrameRate => Memory.ModuleBase() + 0x81EE454;
        public bool SetVideoTrackFrameRate(int TrackIndex, int FormatIndex, float FrameRate)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set(0x0, TrackIndex);
            __pb.Set(0x4, FormatIndex);
            __pb.Set(0x8, FrameRate);
            CallRaw("SetVideoTrackFrameRate", __pb.Bytes);
            return __pb.Get<byte>(0xC) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE588 — hookable via Hooks.InstallAt(NativeFunc_SetTrackFormat).</summary>
        public static global::System.IntPtr NativeFunc_SetTrackFormat => Memory.ModuleBase() + 0x81EE588;
        public bool SetTrackFormat(EMediaPlayerTrack TrackType, int TrackIndex, int FormatIndex)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set<byte>(0x0, (byte)TrackType);
            __pb.Set(0x4, TrackIndex);
            __pb.Set(0x8, FormatIndex);
            CallRaw("SetTrackFormat", __pb.Bytes);
            return __pb.Get<byte>(0xC) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE16C — hookable via Hooks.InstallAt(NativeFunc_SetTimeDelay).</summary>
        public static global::System.IntPtr NativeFunc_SetTimeDelay => Memory.ModuleBase() + 0x81EE16C;
        public void SetTimeDelay(global::System.IntPtr TimeDelay)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, TimeDelay);
            CallRaw("SetTimeDelay", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81EE76C — hookable via Hooks.InstallAt(NativeFunc_SetRate).</summary>
        public static global::System.IntPtr NativeFunc_SetRate => Memory.ModuleBase() + 0x81EE76C;
        public bool SetRate(float Rate)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Rate);
            CallRaw("SetRate", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE6BC — hookable via Hooks.InstallAt(NativeFunc_SetNativeVolume).</summary>
        public static global::System.IntPtr NativeFunc_SetNativeVolume => Memory.ModuleBase() + 0x81EE6BC;
        public bool SetNativeVolume(float Volume)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Volume);
            CallRaw("SetNativeVolume", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE81C — hookable via Hooks.InstallAt(NativeFunc_SetMediaOptions).</summary>
        public static global::System.IntPtr NativeFunc_SetMediaOptions => Memory.ModuleBase() + 0x81EE81C;
        public void SetMediaOptions(MediaSource Options)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Options);
            CallRaw("SetMediaOptions", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81EE8C0 — hookable via Hooks.InstallAt(NativeFunc_SetLooping).</summary>
        public static global::System.IntPtr NativeFunc_SetLooping => Memory.ModuleBase() + 0x81EE8C0;
        public bool SetLooping(bool Looping)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(Looping?1:0));
            CallRaw("SetLooping", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EE978 — hookable via Hooks.InstallAt(NativeFunc_SetDesiredPlayerName).</summary>
        public static global::System.IntPtr NativeFunc_SetDesiredPlayerName => Memory.ModuleBase() + 0x81EE978;
        public void SetDesiredPlayerName(FName PlayerName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, PlayerName);
            CallRaw("SetDesiredPlayerName", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81EEA1C — hookable via Hooks.InstallAt(NativeFunc_SetBlockOnTime).</summary>
        public static global::System.IntPtr NativeFunc_SetBlockOnTime => Memory.ModuleBase() + 0x81EEA1C;
        public void SetBlockOnTime(global::System.IntPtr Time)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, Time);
            CallRaw("SetBlockOnTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81EEACC — hookable via Hooks.InstallAt(NativeFunc_SelectTrack).</summary>
        public static global::System.IntPtr NativeFunc_SelectTrack => Memory.ModuleBase() + 0x81EEACC;
        public bool SelectTrack(EMediaPlayerTrack TrackType, int TrackIndex)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<byte>(0x0, (byte)TrackType);
            __pb.Set(0x4, TrackIndex);
            CallRaw("SelectTrack", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EEBC0 — hookable via Hooks.InstallAt(NativeFunc_Seek).</summary>
        public static global::System.IntPtr NativeFunc_Seek => Memory.ModuleBase() + 0x81EEBC0;
        public bool Seek(global::System.IntPtr Time)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<global::System.IntPtr>(0x0, Time);
            CallRaw("Seek", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EEC7C — hookable via Hooks.InstallAt(NativeFunc_Rewind).</summary>
        public static global::System.IntPtr NativeFunc_Rewind => Memory.ModuleBase() + 0x81EEC7C;
        public bool Rewind()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Rewind", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EECB4 — hookable via Hooks.InstallAt(NativeFunc_Reopen).</summary>
        public static global::System.IntPtr NativeFunc_Reopen => Memory.ModuleBase() + 0x81EECB4;
        public bool Reopen()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Reopen", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EECEC — hookable via Hooks.InstallAt(NativeFunc_Previous).</summary>
        public static global::System.IntPtr NativeFunc_Previous => Memory.ModuleBase() + 0x81EECEC;
        public bool Previous()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Previous", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EED24 — hookable via Hooks.InstallAt(NativeFunc_PlayAndSeek).</summary>
        public static global::System.IntPtr NativeFunc_PlayAndSeek => Memory.ModuleBase() + 0x81EED24;
        public void PlayAndSeek()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayAndSeek", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81EED38 — hookable via Hooks.InstallAt(NativeFunc_Play).</summary>
        public static global::System.IntPtr NativeFunc_Play => Memory.ModuleBase() + 0x81EED38;
        public bool Play()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Play", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EED70 — hookable via Hooks.InstallAt(NativeFunc_Pause).</summary>
        public static global::System.IntPtr NativeFunc_Pause => Memory.ModuleBase() + 0x81EED70;
        public bool Pause()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Pause", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EEDA8 — hookable via Hooks.InstallAt(NativeFunc_OpenUrl).</summary>
        public static global::System.IntPtr NativeFunc_OpenUrl => Memory.ModuleBase() + 0x81EEDA8;
        public bool OpenUrl(global::System.IntPtr URL)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, URL);
            CallRaw("OpenUrl", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF054 — hookable via Hooks.InstallAt(NativeFunc_OpenSourceWithOptions).</summary>
        public static global::System.IntPtr NativeFunc_OpenSourceWithOptions => Memory.ModuleBase() + 0x81EF054;
        public bool OpenSourceWithOptions(MediaSource MediaSource, global::System.IntPtr Options)
        {
            var __pb = new ParamBuffer(57);
            __pb.SetObject(0x0, MediaSource);
            __pb.Set<global::System.IntPtr>(0x8, Options);
            CallRaw("OpenSourceWithOptions", __pb.Bytes);
            return __pb.Get<byte>(0x38) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EEE64 — hookable via Hooks.InstallAt(NativeFunc_OpenSourceLatent).</summary>
        public static global::System.IntPtr NativeFunc_OpenSourceLatent => Memory.ModuleBase() + 0x81EEE64;
        public void OpenSourceLatent(Object WorldContextObject, global::System.IntPtr LatentInfo, MediaSource MediaSource, global::System.IntPtr Options, bool bSuccess)
        {
            var __pb = new ParamBuffer(89);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, LatentInfo);
            __pb.SetObject(0x20, MediaSource);
            __pb.Set<global::System.IntPtr>(0x28, Options);
            __pb.Set<byte>(0x58, (byte)(bSuccess?1:0));
            CallRaw("OpenSourceLatent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81EF16C — hookable via Hooks.InstallAt(NativeFunc_OpenSource).</summary>
        public static global::System.IntPtr NativeFunc_OpenSource => Memory.ModuleBase() + 0x81EF16C;
        public bool OpenSource(MediaSource MediaSource)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, MediaSource);
            CallRaw("OpenSource", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF21C — hookable via Hooks.InstallAt(NativeFunc_OpenPlaylistIndex).</summary>
        public static global::System.IntPtr NativeFunc_OpenPlaylistIndex => Memory.ModuleBase() + 0x81EF21C;
        public bool OpenPlaylistIndex(MediaPlaylist InPlaylist, int Index)
        {
            var __pb = new ParamBuffer(13);
            __pb.SetObject(0x0, InPlaylist);
            __pb.Set(0x8, Index);
            CallRaw("OpenPlaylistIndex", __pb.Bytes);
            return __pb.Get<byte>(0xC) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF310 — hookable via Hooks.InstallAt(NativeFunc_OpenPlaylist).</summary>
        public static global::System.IntPtr NativeFunc_OpenPlaylist => Memory.ModuleBase() + 0x81EF310;
        public bool OpenPlaylist(MediaPlaylist InPlaylist)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, InPlaylist);
            CallRaw("OpenPlaylist", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF3C4 — hookable via Hooks.InstallAt(NativeFunc_OpenFile).</summary>
        public static global::System.IntPtr NativeFunc_OpenFile => Memory.ModuleBase() + 0x81EF3C4;
        public bool OpenFile(global::System.IntPtr FilePath)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, FilePath);
            CallRaw("OpenFile", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF480 — hookable via Hooks.InstallAt(NativeFunc_Next).</summary>
        public static global::System.IntPtr NativeFunc_Next => Memory.ModuleBase() + 0x81EF480;
        public bool Next()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Next", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF4B8 — hookable via Hooks.InstallAt(NativeFunc_IsReady).</summary>
        public static global::System.IntPtr NativeFunc_IsReady => Memory.ModuleBase() + 0x81EF4B8;
        public bool IsReady()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsReady", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF528 — hookable via Hooks.InstallAt(NativeFunc_IsPreparing).</summary>
        public static global::System.IntPtr NativeFunc_IsPreparing => Memory.ModuleBase() + 0x81EF528;
        public bool IsPreparing()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPreparing", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF560 — hookable via Hooks.InstallAt(NativeFunc_IsPlaying).</summary>
        public static global::System.IntPtr NativeFunc_IsPlaying => Memory.ModuleBase() + 0x81EF560;
        public bool IsPlaying()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPlaying", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF598 — hookable via Hooks.InstallAt(NativeFunc_IsPaused).</summary>
        public static global::System.IntPtr NativeFunc_IsPaused => Memory.ModuleBase() + 0x81EF598;
        public bool IsPaused()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPaused", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF5D0 — hookable via Hooks.InstallAt(NativeFunc_IsLooping).</summary>
        public static global::System.IntPtr NativeFunc_IsLooping => Memory.ModuleBase() + 0x81EF5D0;
        public bool IsLooping()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsLooping", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF608 — hookable via Hooks.InstallAt(NativeFunc_IsConnecting).</summary>
        public static global::System.IntPtr NativeFunc_IsConnecting => Memory.ModuleBase() + 0x81EF608;
        public bool IsConnecting()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsConnecting", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF4F0 — hookable via Hooks.InstallAt(NativeFunc_IsClosed).</summary>
        public static global::System.IntPtr NativeFunc_IsClosed => Memory.ModuleBase() + 0x81EF4F0;
        public bool IsClosed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsClosed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF640 — hookable via Hooks.InstallAt(NativeFunc_IsBuffering).</summary>
        public static global::System.IntPtr NativeFunc_IsBuffering => Memory.ModuleBase() + 0x81EF640;
        public bool IsBuffering()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsBuffering", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF678 — hookable via Hooks.InstallAt(NativeFunc_HasError).</summary>
        public static global::System.IntPtr NativeFunc_HasError => Memory.ModuleBase() + 0x81EF678;
        public bool HasError()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasError", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81EF6E4 — hookable via Hooks.InstallAt(NativeFunc_GetViewRotation).</summary>
        public static global::System.IntPtr NativeFunc_GetViewRotation => Memory.ModuleBase() + 0x81EF6E4;
        public global::System.IntPtr GetViewRotation()
        {
            var __pb = new ParamBuffer(12);
            CallRaw("GetViewRotation", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81EF71C — hookable via Hooks.InstallAt(NativeFunc_GetVideoTrackType).</summary>
        public static global::System.IntPtr NativeFunc_GetVideoTrackType => Memory.ModuleBase() + 0x81EF71C;
        public global::System.IntPtr GetVideoTrackType(int TrackIndex, int FormatIndex)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, TrackIndex);
            __pb.Set(0x4, FormatIndex);
            CallRaw("GetVideoTrackType", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81EF854 — hookable via Hooks.InstallAt(NativeFunc_GetVideoTrackFrameRates).</summary>
        public static global::System.IntPtr NativeFunc_GetVideoTrackFrameRates => Memory.ModuleBase() + 0x81EF854;
        public global::System.IntPtr GetVideoTrackFrameRates(int TrackIndex, int FormatIndex)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, TrackIndex);
            __pb.Set(0x4, FormatIndex);
            CallRaw("GetVideoTrackFrameRates", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81EF940 — hookable via Hooks.InstallAt(NativeFunc_GetVideoTrackFrameRate).</summary>
        public static global::System.IntPtr NativeFunc_GetVideoTrackFrameRate => Memory.ModuleBase() + 0x81EF940;
        public float GetVideoTrackFrameRate(int TrackIndex, int FormatIndex)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, TrackIndex);
            __pb.Set(0x4, FormatIndex);
            CallRaw("GetVideoTrackFrameRate", __pb.Bytes);
            return __pb.Get<float>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81EFA2C — hookable via Hooks.InstallAt(NativeFunc_GetVideoTrackDimensions).</summary>
        public static global::System.IntPtr NativeFunc_GetVideoTrackDimensions => Memory.ModuleBase() + 0x81EFA2C;
        public global::System.IntPtr GetVideoTrackDimensions(int TrackIndex, int FormatIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, TrackIndex);
            __pb.Set(0x4, FormatIndex);
            CallRaw("GetVideoTrackDimensions", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81EFB1C — hookable via Hooks.InstallAt(NativeFunc_GetVideoTrackAspectRatio).</summary>
        public static global::System.IntPtr NativeFunc_GetVideoTrackAspectRatio => Memory.ModuleBase() + 0x81EFB1C;
        public float GetVideoTrackAspectRatio(int TrackIndex, int FormatIndex)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, TrackIndex);
            __pb.Set(0x4, FormatIndex);
            CallRaw("GetVideoTrackAspectRatio", __pb.Bytes);
            return __pb.Get<float>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81EFC08 — hookable via Hooks.InstallAt(NativeFunc_GetVerticalFieldOfView).</summary>
        public static global::System.IntPtr NativeFunc_GetVerticalFieldOfView => Memory.ModuleBase() + 0x81EFC08;
        public float GetVerticalFieldOfView()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetVerticalFieldOfView", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81EFC3C — hookable via Hooks.InstallAt(NativeFunc_GetUrl).</summary>
        public static global::System.IntPtr NativeFunc_GetUrl => Memory.ModuleBase() + 0x81EFC3C;
        public global::System.IntPtr GetUrl()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetUrl", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81EFCC0 — hookable via Hooks.InstallAt(NativeFunc_GetTrackLanguage).</summary>
        public static global::System.IntPtr NativeFunc_GetTrackLanguage => Memory.ModuleBase() + 0x81EFCC0;
        public global::System.IntPtr GetTrackLanguage(EMediaPlayerTrack TrackType, int TrackIndex)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)TrackType);
            __pb.Set(0x4, TrackIndex);
            CallRaw("GetTrackLanguage", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81EFDFC — hookable via Hooks.InstallAt(NativeFunc_GetTrackFormat).</summary>
        public static global::System.IntPtr NativeFunc_GetTrackFormat => Memory.ModuleBase() + 0x81EFDFC;
        public int GetTrackFormat(EMediaPlayerTrack TrackType, int TrackIndex)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<byte>(0x0, (byte)TrackType);
            __pb.Set(0x4, TrackIndex);
            CallRaw("GetTrackFormat", __pb.Bytes);
            return __pb.Get<int>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81EFEEC — hookable via Hooks.InstallAt(NativeFunc_GetTrackDisplayName).</summary>
        public static global::System.IntPtr NativeFunc_GetTrackDisplayName => Memory.ModuleBase() + 0x81EFEEC;
        public global::System.IntPtr GetTrackDisplayName(EMediaPlayerTrack TrackType, int TrackIndex)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<byte>(0x0, (byte)TrackType);
            __pb.Set(0x4, TrackIndex);
            CallRaw("GetTrackDisplayName", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81EF6B0 — hookable via Hooks.InstallAt(NativeFunc_GetTimeDelay).</summary>
        public static global::System.IntPtr NativeFunc_GetTimeDelay => Memory.ModuleBase() + 0x81EF6B0;
        public global::System.IntPtr GetTimeDelay()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetTimeDelay", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F00B8 — hookable via Hooks.InstallAt(NativeFunc_GetTime).</summary>
        public static global::System.IntPtr NativeFunc_GetTime => Memory.ModuleBase() + 0x81F00B8;
        public global::System.IntPtr GetTime()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetTime", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F00EC — hookable via Hooks.InstallAt(NativeFunc_GetSupportedRates).</summary>
        public static global::System.IntPtr NativeFunc_GetSupportedRates => Memory.ModuleBase() + 0x81F00EC;
        public void GetSupportedRates(global::System.IntPtr OutRates, bool Unthinned)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, OutRates);
            __pb.Set<byte>(0x10, (byte)(Unthinned?1:0));
            CallRaw("GetSupportedRates", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F01F4 — hookable via Hooks.InstallAt(NativeFunc_GetSelectedTrack).</summary>
        public static global::System.IntPtr NativeFunc_GetSelectedTrack => Memory.ModuleBase() + 0x81F01F4;
        public int GetSelectedTrack(EMediaPlayerTrack TrackType)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)TrackType);
            CallRaw("GetSelectedTrack", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x81F02A0 — hookable via Hooks.InstallAt(NativeFunc_GetRate).</summary>
        public static global::System.IntPtr NativeFunc_GetRate => Memory.ModuleBase() + 0x81F02A0;
        public float GetRate()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetRate", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F02D4 — hookable via Hooks.InstallAt(NativeFunc_GetPlaylistIndex).</summary>
        public static global::System.IntPtr NativeFunc_GetPlaylistIndex => Memory.ModuleBase() + 0x81F02D4;
        public int GetPlaylistIndex()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPlaylistIndex", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F02F0 — hookable via Hooks.InstallAt(NativeFunc_GetPlaylist).</summary>
        public static global::System.IntPtr NativeFunc_GetPlaylist => Memory.ModuleBase() + 0x81F02F0;
        public MediaPlaylist GetPlaylist()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetPlaylist", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MediaPlaylist(__p); }
        }
        /// <summary>[Native] thunk RVA 0x81F030C — hookable via Hooks.InstallAt(NativeFunc_GetPlayerName).</summary>
        public static global::System.IntPtr NativeFunc_GetPlayerName => Memory.ModuleBase() + 0x81F030C;
        public FName GetPlayerName()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetPlayerName", __pb.Bytes);
            return __pb.Get<FName>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F0430 — hookable via Hooks.InstallAt(NativeFunc_GetNumTracks).</summary>
        public static global::System.IntPtr NativeFunc_GetNumTracks => Memory.ModuleBase() + 0x81F0430;
        public int GetNumTracks(EMediaPlayerTrack TrackType)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)TrackType);
            CallRaw("GetNumTracks", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x81F0340 — hookable via Hooks.InstallAt(NativeFunc_GetNumTrackFormats).</summary>
        public static global::System.IntPtr NativeFunc_GetNumTrackFormats => Memory.ModuleBase() + 0x81F0340;
        public int GetNumTrackFormats(EMediaPlayerTrack TrackType, int TrackIndex)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<byte>(0x0, (byte)TrackType);
            __pb.Set(0x4, TrackIndex);
            CallRaw("GetNumTrackFormats", __pb.Bytes);
            return __pb.Get<int>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81F04DC — hookable via Hooks.InstallAt(NativeFunc_GetMediaName).</summary>
        public static global::System.IntPtr NativeFunc_GetMediaName => Memory.ModuleBase() + 0x81F04DC;
        public global::System.IntPtr GetMediaName()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetMediaName", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F0050 — hookable via Hooks.InstallAt(NativeFunc_GetLastVideoSampleProcessedTime).</summary>
        public static global::System.IntPtr NativeFunc_GetLastVideoSampleProcessedTime => Memory.ModuleBase() + 0x81F0050;
        public global::System.IntPtr GetLastVideoSampleProcessedTime()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetLastVideoSampleProcessedTime", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F0084 — hookable via Hooks.InstallAt(NativeFunc_GetLastAudioSampleProcessedTime).</summary>
        public static global::System.IntPtr NativeFunc_GetLastAudioSampleProcessedTime => Memory.ModuleBase() + 0x81F0084;
        public global::System.IntPtr GetLastAudioSampleProcessedTime()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetLastAudioSampleProcessedTime", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F05BC — hookable via Hooks.InstallAt(NativeFunc_GetHorizontalFieldOfView).</summary>
        public static global::System.IntPtr NativeFunc_GetHorizontalFieldOfView => Memory.ModuleBase() + 0x81F05BC;
        public float GetHorizontalFieldOfView()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetHorizontalFieldOfView", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F05F0 — hookable via Hooks.InstallAt(NativeFunc_GetDuration).</summary>
        public static global::System.IntPtr NativeFunc_GetDuration => Memory.ModuleBase() + 0x81F05F0;
        public global::System.IntPtr GetDuration()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDuration", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F0624 — hookable via Hooks.InstallAt(NativeFunc_GetDesiredPlayerName).</summary>
        public static global::System.IntPtr NativeFunc_GetDesiredPlayerName => Memory.ModuleBase() + 0x81F0624;
        public FName GetDesiredPlayerName()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDesiredPlayerName", __pb.Bytes);
            return __pb.Get<FName>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F0658 — hookable via Hooks.InstallAt(NativeFunc_GetAudioTrackType).</summary>
        public static global::System.IntPtr NativeFunc_GetAudioTrackType => Memory.ModuleBase() + 0x81F0658;
        public global::System.IntPtr GetAudioTrackType(int TrackIndex, int FormatIndex)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, TrackIndex);
            __pb.Set(0x4, FormatIndex);
            CallRaw("GetAudioTrackType", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81F0790 — hookable via Hooks.InstallAt(NativeFunc_GetAudioTrackSampleRate).</summary>
        public static global::System.IntPtr NativeFunc_GetAudioTrackSampleRate => Memory.ModuleBase() + 0x81F0790;
        public int GetAudioTrackSampleRate(int TrackIndex, int FormatIndex)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, TrackIndex);
            __pb.Set(0x4, FormatIndex);
            CallRaw("GetAudioTrackSampleRate", __pb.Bytes);
            return __pb.Get<int>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81F087C — hookable via Hooks.InstallAt(NativeFunc_GetAudioTrackChannels).</summary>
        public static global::System.IntPtr NativeFunc_GetAudioTrackChannels => Memory.ModuleBase() + 0x81F087C;
        public int GetAudioTrackChannels(int TrackIndex, int FormatIndex)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, TrackIndex);
            __pb.Set(0x4, FormatIndex);
            CallRaw("GetAudioTrackChannels", __pb.Bytes);
            return __pb.Get<int>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x81F0968 — hookable via Hooks.InstallAt(NativeFunc_Close).</summary>
        public static global::System.IntPtr NativeFunc_Close => Memory.ModuleBase() + 0x81F0968;
        public void Close()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Close", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F097C — hookable via Hooks.InstallAt(NativeFunc_CanPlayUrl).</summary>
        public static global::System.IntPtr NativeFunc_CanPlayUrl => Memory.ModuleBase() + 0x81F097C;
        public bool CanPlayUrl(global::System.IntPtr URL)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, URL);
            CallRaw("CanPlayUrl", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81F0A38 — hookable via Hooks.InstallAt(NativeFunc_CanPlaySource).</summary>
        public static global::System.IntPtr NativeFunc_CanPlaySource => Memory.ModuleBase() + 0x81F0A38;
        public bool CanPlaySource(MediaSource MediaSource)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, MediaSource);
            CallRaw("CanPlaySource", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81F0AE8 — hookable via Hooks.InstallAt(NativeFunc_CanPause).</summary>
        public static global::System.IntPtr NativeFunc_CanPause => Memory.ModuleBase() + 0x81F0AE8;
        public bool CanPause()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("CanPause", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class MediaPlaylist : Object
    {
        public const string UeClassName = "MediaPlaylist";
        public MediaPlaylist(global::System.IntPtr ptr) : base(ptr) {}
        public static new MediaPlaylist FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MediaPlaylist(p);
        public static MediaPlaylist FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MediaPlaylist(o.Pointer); }
        public static MediaPlaylist[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MediaPlaylist[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MediaPlaylist(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Items => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x81F2B28 — hookable via Hooks.InstallAt(NativeFunc_Replace).</summary>
        public static global::System.IntPtr NativeFunc_Replace => Memory.ModuleBase() + 0x81F2B28;
        public bool Replace(int Index, MediaSource Replacement)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set(0x0, Index);
            __pb.SetObject(0x8, Replacement);
            CallRaw("Replace", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81F2C1C — hookable via Hooks.InstallAt(NativeFunc_RemoveAt).</summary>
        public static global::System.IntPtr NativeFunc_RemoveAt => Memory.ModuleBase() + 0x81F2C1C;
        public bool RemoveAt(int Index)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Index);
            CallRaw("RemoveAt", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81F2CCC — hookable via Hooks.InstallAt(NativeFunc_Remove).</summary>
        public static global::System.IntPtr NativeFunc_Remove => Memory.ModuleBase() + 0x81F2CCC;
        public bool Remove(MediaSource MediaSource)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, MediaSource);
            CallRaw("Remove", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81F2D7C — hookable via Hooks.InstallAt(NativeFunc_Num).</summary>
        public static global::System.IntPtr NativeFunc_Num => Memory.ModuleBase() + 0x81F2D7C;
        public int Num()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("Num", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F2D98 — hookable via Hooks.InstallAt(NativeFunc_Insert).</summary>
        public static global::System.IntPtr NativeFunc_Insert => Memory.ModuleBase() + 0x81F2D98;
        public void Insert(MediaSource MediaSource, int Index)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, MediaSource);
            __pb.Set(0x8, Index);
            CallRaw("Insert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F2E80 — hookable via Hooks.InstallAt(NativeFunc_GetRandom).</summary>
        public static global::System.IntPtr NativeFunc_GetRandom => Memory.ModuleBase() + 0x81F2E80;
        public MediaSource GetRandom(int OutIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, OutIndex);
            CallRaw("GetRandom", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new MediaSource(__p); }
        }
        /// <summary>[Native] thunk RVA 0x81F2F3C — hookable via Hooks.InstallAt(NativeFunc_GetPrevious).</summary>
        public static global::System.IntPtr NativeFunc_GetPrevious => Memory.ModuleBase() + 0x81F2F3C;
        public MediaSource GetPrevious(int InOutIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, InOutIndex);
            CallRaw("GetPrevious", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new MediaSource(__p); }
        }
        /// <summary>[Native] thunk RVA 0x81F2FF8 — hookable via Hooks.InstallAt(NativeFunc_GetNext).</summary>
        public static global::System.IntPtr NativeFunc_GetNext => Memory.ModuleBase() + 0x81F2FF8;
        public MediaSource GetNext(int InOutIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, InOutIndex);
            CallRaw("GetNext", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new MediaSource(__p); }
        }
        /// <summary>[Native] thunk RVA 0x81F30B4 — hookable via Hooks.InstallAt(NativeFunc_Get).</summary>
        public static global::System.IntPtr NativeFunc_Get => Memory.ModuleBase() + 0x81F30B4;
        public MediaSource Get(int Index)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Index);
            CallRaw("Get", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new MediaSource(__p); }
        }
        /// <summary>[Native] thunk RVA 0x81F3160 — hookable via Hooks.InstallAt(NativeFunc_AddUrl).</summary>
        public static global::System.IntPtr NativeFunc_AddUrl => Memory.ModuleBase() + 0x81F3160;
        public bool AddUrl(global::System.IntPtr URL)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, URL);
            CallRaw("AddUrl", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81F321C — hookable via Hooks.InstallAt(NativeFunc_AddFile).</summary>
        public static global::System.IntPtr NativeFunc_AddFile => Memory.ModuleBase() + 0x81F321C;
        public bool AddFile(global::System.IntPtr FilePath)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, FilePath);
            CallRaw("AddFile", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81F32D8 — hookable via Hooks.InstallAt(NativeFunc_Add).</summary>
        public static global::System.IntPtr NativeFunc_Add => Memory.ModuleBase() + 0x81F32D8;
        public bool Add(MediaSource MediaSource)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, MediaSource);
            CallRaw("Add", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
    }

    public class MediaSoundComponent : SynthComponent
    {
        public const string UeClassName = "MediaSoundComponent";
        public MediaSoundComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new MediaSoundComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MediaSoundComponent(p);
        public static MediaSoundComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MediaSoundComponent(o.Pointer); }
        public static MediaSoundComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MediaSoundComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MediaSoundComponent(a[i].Pointer); return r; }
        public EMediaSoundChannels Channels { get => (EMediaSoundChannels)GetAt<int>(0x6D0); set => SetAt(0x6D0, (int)value); }
        public bool DynamicRateAdjustment { get => Native.GetPropBool(Pointer, "DynamicRateAdjustment"); set => Native.SetPropBool(Pointer, "DynamicRateAdjustment", value); }
        public float RateAdjustmentFactor { get => GetAt<float>(0x6D8); set => SetAt(0x6D8, value); }
        public FloatRange RateAdjustmentRange => new FloatRange(AddrOf(0x6DC));
        public MediaPlayer MediaPlayer { get { var __p = GetAt<global::System.IntPtr>(0x6F0); return __p==global::System.IntPtr.Zero?null:new MediaPlayer(__p); } set => SetAt(0x6F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x81F4580 — hookable via Hooks.InstallAt(NativeFunc_SetSpectralAnalysisSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSpectralAnalysisSettings => Memory.ModuleBase() + 0x81F4580;
        public void SetSpectralAnalysisSettings(global::System.IntPtr InFrequenciesToAnalyze, EMediaSoundComponentFFTSize InFFTSize)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, InFrequenciesToAnalyze);
            __pb.Set<byte>(0x10, (byte)InFFTSize);
            CallRaw("SetSpectralAnalysisSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F4768 — hookable via Hooks.InstallAt(NativeFunc_SetMediaPlayer).</summary>
        public static global::System.IntPtr NativeFunc_SetMediaPlayer => Memory.ModuleBase() + 0x81F4768;
        public void SetMediaPlayer(MediaPlayer NewMediaPlayer)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewMediaPlayer);
            CallRaw("SetMediaPlayer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F4340 — hookable via Hooks.InstallAt(NativeFunc_SetEnvelopeFollowingsettings).</summary>
        public static global::System.IntPtr NativeFunc_SetEnvelopeFollowingsettings => Memory.ModuleBase() + 0x81F4340;
        public void SetEnvelopeFollowingsettings(int AttackTimeMsec, int ReleaseTimeMsec)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, AttackTimeMsec);
            __pb.Set(0x4, ReleaseTimeMsec);
            CallRaw("SetEnvelopeFollowingsettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F46BC — hookable via Hooks.InstallAt(NativeFunc_SetEnableSpectralAnalysis).</summary>
        public static global::System.IntPtr NativeFunc_SetEnableSpectralAnalysis => Memory.ModuleBase() + 0x81F46BC;
        public void SetEnableSpectralAnalysis(bool bInSpectralAnalysisEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInSpectralAnalysisEnabled?1:0));
            CallRaw("SetEnableSpectralAnalysis", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F4424 — hookable via Hooks.InstallAt(NativeFunc_SetEnableEnvelopeFollowing).</summary>
        public static global::System.IntPtr NativeFunc_SetEnableEnvelopeFollowing => Memory.ModuleBase() + 0x81F4424;
        public void SetEnableEnvelopeFollowing(bool bInEnvelopeFollowing)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInEnvelopeFollowing?1:0));
            CallRaw("SetEnableEnvelopeFollowing", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F44D0 — hookable via Hooks.InstallAt(NativeFunc_GetSpectralData).</summary>
        public static global::System.IntPtr NativeFunc_GetSpectralData => Memory.ModuleBase() + 0x81F44D0;
        public global::System.IntPtr GetSpectralData()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetSpectralData", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F480C — hookable via Hooks.InstallAt(NativeFunc_GetMediaPlayer).</summary>
        public static global::System.IntPtr NativeFunc_GetMediaPlayer => Memory.ModuleBase() + 0x81F480C;
        public MediaPlayer GetMediaPlayer()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetMediaPlayer", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MediaPlayer(__p); }
        }
        /// <summary>[Native] thunk RVA 0x81F430C — hookable via Hooks.InstallAt(NativeFunc_GetEnvelopeValue).</summary>
        public static global::System.IntPtr NativeFunc_GetEnvelopeValue => Memory.ModuleBase() + 0x81F430C;
        public float GetEnvelopeValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetEnvelopeValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F4840 — hookable via Hooks.InstallAt(NativeFunc_BP_GetAttenuationSettingsToApply).</summary>
        public static global::System.IntPtr NativeFunc_BP_GetAttenuationSettingsToApply => Memory.ModuleBase() + 0x81F4840;
        public bool BP_GetAttenuationSettingsToApply(global::System.IntPtr OutAttenuationSettings)
        {
            var __pb = new ParamBuffer(929);
            __pb.Set<global::System.IntPtr>(0x0, OutAttenuationSettings);
            CallRaw("BP_GetAttenuationSettingsToApply", __pb.Bytes);
            return __pb.Get<byte>(0x3A0) != 0;
        }
    }

    public class MediaTexture : Texture
    {
        public const string UeClassName = "MediaTexture";
        public MediaTexture(global::System.IntPtr ptr) : base(ptr) {}
        public static new MediaTexture FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MediaTexture(p);
        public static MediaTexture FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MediaTexture(o.Pointer); }
        public static MediaTexture[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MediaTexture[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MediaTexture(a[i].Pointer); return r; }
        public byte AddressX { get => GetAt<byte>(0xB8); set => SetAt(0xB8, value); }
        public byte AddressY { get => GetAt<byte>(0xB9); set => SetAt(0xB9, value); }
        public bool AutoClear { get => Native.GetPropBool(Pointer, "AutoClear"); set => Native.SetPropBool(Pointer, "AutoClear", value); }
        public LinearColor ClearColor => new LinearColor(AddrOf(0xBC));
        public bool EnableGenMips { get => Native.GetPropBool(Pointer, "EnableGenMips"); set => Native.SetPropBool(Pointer, "EnableGenMips", value); }
        public byte NumMips { get => GetAt<byte>(0xCD); set => SetAt(0xCD, value); }
        public MediaPlayer MediaPlayer { get { var __p = GetAt<global::System.IntPtr>(0xD0); return __p==global::System.IntPtr.Zero?null:new MediaPlayer(__p); } set => SetAt(0xD0, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x81F6560 — hookable via Hooks.InstallAt(NativeFunc_SetMediaPlayer).</summary>
        public static global::System.IntPtr NativeFunc_SetMediaPlayer => Memory.ModuleBase() + 0x81F6560;
        public void SetMediaPlayer(MediaPlayer NewMediaPlayer)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewMediaPlayer);
            CallRaw("SetMediaPlayer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81F6604 — hookable via Hooks.InstallAt(NativeFunc_GetWidth).</summary>
        public static global::System.IntPtr NativeFunc_GetWidth => Memory.ModuleBase() + 0x81F6604;
        public int GetWidth()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetWidth", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F6638 — hookable via Hooks.InstallAt(NativeFunc_GetMediaPlayer).</summary>
        public static global::System.IntPtr NativeFunc_GetMediaPlayer => Memory.ModuleBase() + 0x81F6638;
        public MediaPlayer GetMediaPlayer()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetMediaPlayer", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new MediaPlayer(__p); }
        }
        /// <summary>[Native] thunk RVA 0x81F666C — hookable via Hooks.InstallAt(NativeFunc_GetHeight).</summary>
        public static global::System.IntPtr NativeFunc_GetHeight => Memory.ModuleBase() + 0x81F666C;
        public int GetHeight()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetHeight", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x81F66A0 — hookable via Hooks.InstallAt(NativeFunc_GetAspectRatio).</summary>
        public static global::System.IntPtr NativeFunc_GetAspectRatio => Memory.ModuleBase() + 0x81F66A0;
        public float GetAspectRatio()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetAspectRatio", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
    }

    public class PlatformMediaSource : MediaSource
    {
        public const string UeClassName = "PlatformMediaSource";
        public PlatformMediaSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlatformMediaSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlatformMediaSource(p);
        public static PlatformMediaSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlatformMediaSource(o.Pointer); }
        public static PlatformMediaSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlatformMediaSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlatformMediaSource(a[i].Pointer); return r; }
        public MediaSource MediaSource { get { var __p = GetAt<global::System.IntPtr>(0x80); return __p==global::System.IntPtr.Zero?null:new MediaSource(__p); } set => SetAt(0x80, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class StreamMediaSource : BaseMediaSource
    {
        public const string UeClassName = "StreamMediaSource";
        public StreamMediaSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new StreamMediaSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new StreamMediaSource(p);
        public static StreamMediaSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new StreamMediaSource(o.Pointer); }
        public static StreamMediaSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new StreamMediaSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new StreamMediaSource(a[i].Pointer); return r; }
        public string StreamUrl => Native.GetPropString(Pointer, "StreamUrl"); // FString
    }

    public class TimeSynchronizableMediaSource : BaseMediaSource
    {
        public const string UeClassName = "TimeSynchronizableMediaSource";
        public TimeSynchronizableMediaSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new TimeSynchronizableMediaSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TimeSynchronizableMediaSource(p);
        public static TimeSynchronizableMediaSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TimeSynchronizableMediaSource(o.Pointer); }
        public static TimeSynchronizableMediaSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TimeSynchronizableMediaSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TimeSynchronizableMediaSource(a[i].Pointer); return r; }
        public bool bUseTimeSynchronization { get => Native.GetPropBool(Pointer, "bUseTimeSynchronization"); set => Native.SetPropBool(Pointer, "bUseTimeSynchronization", value); }
        public int FrameDelay { get => GetAt<int>(0x8C); set => SetAt(0x8C, value); }
        public double TimeDelay { get => GetAt<double>(0x90); set => SetAt(0x90, value); }
    }

}
