// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/BinkMediaPlayer
using System;

namespace UEModLoader.Game
{
    public enum EBinkMediaPlayerBinkDrawStyle
    {
        BMASM_Bink_DS_RenderToTexture = 0,
        BMASM_Bink_DS_OverlayFillScreenWithAspectRatio = 1,
        BMASM_Bink_DS_OverlayOriginalMovieSize = 2,
        BMASM_Bink_DS_OverlayFillScreen = 3,
        BMASM_Bink_DS_OverlaySpecificDestinationRectangle = 4,
    }

    public enum EBinkMediaPlayerBinkSoundTrack
    {
        BMASM_Bink_Sound_None = 0,
        BMASM_Bink_Sound_Simple = 1,
        BMASM_Bink_Sound_LanguageOverride = 2,
        BMASM_Bink_Sound = 3,
        BMASM_Bink_Sound_51LanguageOverride = 4,
        BMASM_Bink_Sound_71LanguageOverride = 6,
    }

    public enum EBinkMediaPlayerBinkBufferModes
    {
        BMASM_Bink_Stream = 0,
        BMASM_Bink_PreloadAll = 1,
        BMASM_Bink_StreamUntilResident = 2,
    }

    public enum EBinkMoviePlayerBinkSoundTrack
    {
        MP_Bink_Sound_None = 0,
        MP_Bink_Sound_Simple = 1,
        MP_Bink_Sound_LanguageOverride = 2,
        MP_Bink_Sound = 3,
        MP_Bink_Sound_51LanguageOverride = 4,
        MP_Bink_Sound_71LanguageOverride = 6,
    }

    public enum EBinkMoviePlayerBinkBufferModes
    {
        MP_Bink_Stream = 0,
        MP_Bink_PreloadAll = 1,
        MP_Bink_StreamUntilResident = 2,
    }

    public class BinkFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "BinkFunctionLibrary";
        public BinkFunctionLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new BinkFunctionLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BinkFunctionLibrary(p);
        public static BinkFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BinkFunctionLibrary(o.Pointer); }
        public static BinkFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BinkFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BinkFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x56E36FC — hookable via Hooks.InstallAt(NativeFunc_BinkLoadingMovie_GetTime).</summary>
        public static System.IntPtr NativeFunc_BinkLoadingMovie_GetTime => Memory.ModuleBase() + 0x56E36FC;
        public Timespan BinkLoadingMovie_GetTime()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("BinkLoadingMovie_GetTime", __pb.Bytes);
            return __pb.Get<Timespan>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x56E3730 — hookable via Hooks.InstallAt(NativeFunc_BinkLoadingMovie_GetDuration).</summary>
        public static System.IntPtr NativeFunc_BinkLoadingMovie_GetDuration => Memory.ModuleBase() + 0x56E3730;
        public Timespan BinkLoadingMovie_GetDuration()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("BinkLoadingMovie_GetDuration", __pb.Bytes);
            return __pb.Get<Timespan>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x56E3764 — hookable via Hooks.InstallAt(NativeFunc_Bink_DrawOverlays).</summary>
        public static System.IntPtr NativeFunc_Bink_DrawOverlays => Memory.ModuleBase() + 0x56E3764;
        public void Bink_DrawOverlays()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Bink_DrawOverlays", __pb.Bytes);
        }
    }

    public class BinkMediaPlayer : Object
    {
        public const string UeClassName = "BinkMediaPlayer";
        public BinkMediaPlayer(System.IntPtr ptr) : base(ptr) {}
        public static new BinkMediaPlayer FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BinkMediaPlayer(p);
        public static BinkMediaPlayer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BinkMediaPlayer(o.Pointer); }
        public static BinkMediaPlayer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BinkMediaPlayer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BinkMediaPlayer(a[i].Pointer); return r; }
        public System.IntPtr OnMediaClosed => AddrOf(0x30); // 
        public System.IntPtr OnMediaOpened => AddrOf(0x40); // 
        public System.IntPtr OnMediaReachedEnd => AddrOf(0x50); // 
        public System.IntPtr OnPlaybackSuspended => AddrOf(0x60); // 
        public bool Looping { get => Native.GetPropBool(Pointer, "Looping"); set => Native.SetPropBool(Pointer, "Looping", value); }
        public bool StartImmediately { get => Native.GetPropBool(Pointer, "StartImmediately"); set => Native.SetPropBool(Pointer, "StartImmediately", value); }
        public bool DelayedOpen { get => Native.GetPropBool(Pointer, "DelayedOpen"); set => Native.SetPropBool(Pointer, "DelayedOpen", value); }
        public Vector2D BinkDestinationUpperLeft => new Vector2D(AddrOf(0x74));
        public Vector2D BinkDestinationLowerRight => new Vector2D(AddrOf(0x7C));
        public string URL => Native.GetPropString(Pointer, "URL"); // FString
        public byte BinkBufferMode { get => GetAt<byte>(0x98); set => SetAt(0x98, value); }
        public byte BinkSoundTrack { get => GetAt<byte>(0x99); set => SetAt(0x99, value); }
        public int BinkSoundTrackStart { get => GetAt<int>(0x9C); set => SetAt(0x9C, value); }
        public byte BinkDrawStyle { get => GetAt<byte>(0xA0); set => SetAt(0xA0, value); }
        public int BinkLayerDepth { get => GetAt<int>(0xA4); set => SetAt(0xA4, value); }
        /// <summary>[Native] thunk RVA 0x56E46F4 — hookable via Hooks.InstallAt(NativeFunc_SupportsSeeking).</summary>
        public static System.IntPtr NativeFunc_SupportsSeeking => Memory.ModuleBase() + 0x56E46F4;
        public bool SupportsSeeking()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("SupportsSeeking", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E472C — hookable via Hooks.InstallAt(NativeFunc_SupportsScrubbing).</summary>
        public static System.IntPtr NativeFunc_SupportsScrubbing => Memory.ModuleBase() + 0x56E472C;
        public bool SupportsScrubbing()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("SupportsScrubbing", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4764 — hookable via Hooks.InstallAt(NativeFunc_SupportsRate).</summary>
        public static System.IntPtr NativeFunc_SupportsRate => Memory.ModuleBase() + 0x56E4764;
        public bool SupportsRate(float Rate, bool Unthinned)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set(0x0, Rate);
            __pb.Set<byte>(0x4, (byte)(Unthinned?1:0));
            CallRaw("SupportsRate", __pb.Bytes);
            return __pb.Get<byte>(0x5) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4860 — hookable via Hooks.InstallAt(NativeFunc_Stop).</summary>
        public static System.IntPtr NativeFunc_Stop => Memory.ModuleBase() + 0x56E4860;
        public void Stop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Stop", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56E4874 — hookable via Hooks.InstallAt(NativeFunc_SetVolume).</summary>
        public static System.IntPtr NativeFunc_SetVolume => Memory.ModuleBase() + 0x56E4874;
        public void SetVolume(float Rate)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Rate);
            CallRaw("SetVolume", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56E4918 — hookable via Hooks.InstallAt(NativeFunc_SetRate).</summary>
        public static System.IntPtr NativeFunc_SetRate => Memory.ModuleBase() + 0x56E4918;
        public bool SetRate(float Rate)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Rate);
            CallRaw("SetRate", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E49C8 — hookable via Hooks.InstallAt(NativeFunc_SetLooping).</summary>
        public static System.IntPtr NativeFunc_SetLooping => Memory.ModuleBase() + 0x56E49C8;
        public bool SetLooping(bool InLooping)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(InLooping?1:0));
            CallRaw("SetLooping", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4A80 — hookable via Hooks.InstallAt(NativeFunc_Seek).</summary>
        public static System.IntPtr NativeFunc_Seek => Memory.ModuleBase() + 0x56E4A80;
        public bool Seek(Timespan InTime)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<System.IntPtr>(0x0, InTime);
            CallRaw("Seek", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4B3C — hookable via Hooks.InstallAt(NativeFunc_Rewind).</summary>
        public static System.IntPtr NativeFunc_Rewind => Memory.ModuleBase() + 0x56E4B3C;
        public bool Rewind()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Rewind", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4B74 — hookable via Hooks.InstallAt(NativeFunc_Play).</summary>
        public static System.IntPtr NativeFunc_Play => Memory.ModuleBase() + 0x56E4B74;
        public bool Play()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Play", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4BAC — hookable via Hooks.InstallAt(NativeFunc_Pause).</summary>
        public static System.IntPtr NativeFunc_Pause => Memory.ModuleBase() + 0x56E4BAC;
        public bool Pause()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("Pause", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4BF8 — hookable via Hooks.InstallAt(NativeFunc_OpenUrl).</summary>
        public static System.IntPtr NativeFunc_OpenUrl => Memory.ModuleBase() + 0x56E4BF8;
        public bool OpenUrl(System.IntPtr NewUrl)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, NewUrl);
            CallRaw("OpenUrl", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4CB4 — hookable via Hooks.InstallAt(NativeFunc_IsStopped).</summary>
        public static System.IntPtr NativeFunc_IsStopped => Memory.ModuleBase() + 0x56E4CB4;
        public bool IsStopped()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsStopped", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4CEC — hookable via Hooks.InstallAt(NativeFunc_IsPlaying).</summary>
        public static System.IntPtr NativeFunc_IsPlaying => Memory.ModuleBase() + 0x56E4CEC;
        public bool IsPlaying()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPlaying", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4D24 — hookable via Hooks.InstallAt(NativeFunc_IsPaused).</summary>
        public static System.IntPtr NativeFunc_IsPaused => Memory.ModuleBase() + 0x56E4D24;
        public bool IsPaused()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPaused", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4D5C — hookable via Hooks.InstallAt(NativeFunc_IsLooping).</summary>
        public static System.IntPtr NativeFunc_IsLooping => Memory.ModuleBase() + 0x56E4D5C;
        public bool IsLooping()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsLooping", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E46D0 — hookable via Hooks.InstallAt(NativeFunc_IsInitialized).</summary>
        public static System.IntPtr NativeFunc_IsInitialized => Memory.ModuleBase() + 0x56E46D0;
        public bool IsInitialized()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsInitialized", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4D94 — hookable via Hooks.InstallAt(NativeFunc_GetUrl).</summary>
        public static System.IntPtr NativeFunc_GetUrl => Memory.ModuleBase() + 0x56E4D94;
        public System.IntPtr GetUrl()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetUrl", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x56E4E18 — hookable via Hooks.InstallAt(NativeFunc_GetTime).</summary>
        public static System.IntPtr NativeFunc_GetTime => Memory.ModuleBase() + 0x56E4E18;
        public Timespan GetTime()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetTime", __pb.Bytes);
            return __pb.Get<Timespan>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x56E4E4C — hookable via Hooks.InstallAt(NativeFunc_GetRate).</summary>
        public static System.IntPtr NativeFunc_GetRate => Memory.ModuleBase() + 0x56E4E4C;
        public float GetRate()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetRate", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x56E4E80 — hookable via Hooks.InstallAt(NativeFunc_GetDuration).</summary>
        public static System.IntPtr NativeFunc_GetDuration => Memory.ModuleBase() + 0x56E4E80;
        public Timespan GetDuration()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDuration", __pb.Bytes);
            return __pb.Get<Timespan>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x56E44B0 — hookable via Hooks.InstallAt(NativeFunc_Draw).</summary>
        public static System.IntPtr NativeFunc_Draw => Memory.ModuleBase() + 0x56E44B0;
        public void Draw(Texture Texture, bool tonemap, int out_nits, float alpha, bool srgb_decode, bool hdr)
        {
            var __pb = new ParamBuffer(22);
            __pb.SetObject(0x0, Texture);
            __pb.Set<byte>(0x8, (byte)(tonemap?1:0));
            __pb.Set(0xC, out_nits);
            __pb.Set(0x10, alpha);
            __pb.Set<byte>(0x14, (byte)(srgb_decode?1:0));
            __pb.Set<byte>(0x15, (byte)(hdr?1:0));
            CallRaw("Draw", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56E4BE4 — hookable via Hooks.InstallAt(NativeFunc_CloseUrl).</summary>
        public static System.IntPtr NativeFunc_CloseUrl => Memory.ModuleBase() + 0x56E4BE4;
        public void CloseUrl()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CloseUrl", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56E4EB4 — hookable via Hooks.InstallAt(NativeFunc_CanPlay).</summary>
        public static System.IntPtr NativeFunc_CanPlay => Memory.ModuleBase() + 0x56E4EB4;
        public bool CanPlay()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("CanPlay", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x56E4EEC — hookable via Hooks.InstallAt(NativeFunc_CanPause).</summary>
        public static System.IntPtr NativeFunc_CanPause => Memory.ModuleBase() + 0x56E4EEC;
        public bool CanPause()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("CanPause", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class BinkMediaTexture : Texture
    {
        public const string UeClassName = "BinkMediaTexture";
        public BinkMediaTexture(System.IntPtr ptr) : base(ptr) {}
        public static new BinkMediaTexture FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BinkMediaTexture(p);
        public static BinkMediaTexture FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BinkMediaTexture(o.Pointer); }
        public static BinkMediaTexture[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BinkMediaTexture[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BinkMediaTexture(a[i].Pointer); return r; }
        public byte AddressX { get => GetAt<byte>(0xB8); set => SetAt(0xB8, value); }
        public byte AddressY { get => GetAt<byte>(0xB9); set => SetAt(0xB9, value); }
        public BinkMediaPlayer MediaPlayer { get { var __p = GetAt<System.IntPtr>(0xC0); return __p==System.IntPtr.Zero?null:new BinkMediaPlayer(__p); } set => SetAt(0xC0, value?.Pointer ?? System.IntPtr.Zero); }
        public byte PixelFormat { get => GetAt<byte>(0xC8); set => SetAt(0xC8, value); }
        public bool tonemap { get => Native.GetPropBool(Pointer, "tonemap"); set => Native.SetPropBool(Pointer, "tonemap", value); }
        public float OutputNits { get => GetAt<float>(0xCC); set => SetAt(0xCC, value); }
        public float alpha { get => GetAt<float>(0xD0); set => SetAt(0xD0, value); }
        public bool DecodeSRGB { get => Native.GetPropBool(Pointer, "DecodeSRGB"); set => Native.SetPropBool(Pointer, "DecodeSRGB", value); }
        /// <summary>[Native] thunk RVA 0x56E62FC — hookable via Hooks.InstallAt(NativeFunc_SetMediaPlayer).</summary>
        public static System.IntPtr NativeFunc_SetMediaPlayer => Memory.ModuleBase() + 0x56E62FC;
        public void SetMediaPlayer(BinkMediaPlayer InMediaPlayer)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InMediaPlayer);
            CallRaw("SetMediaPlayer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56E62E8 — hookable via Hooks.InstallAt(NativeFunc_Clear).</summary>
        public static System.IntPtr NativeFunc_Clear => Memory.ModuleBase() + 0x56E62E8;
        public void Clear()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Clear", __pb.Bytes);
        }
    }

    public class BinkMoviePlayerSettings : Object
    {
        public const string UeClassName = "BinkMoviePlayerSettings";
        public BinkMoviePlayerSettings(System.IntPtr ptr) : base(ptr) {}
        public static new BinkMoviePlayerSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BinkMoviePlayerSettings(p);
        public static BinkMoviePlayerSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BinkMoviePlayerSettings(o.Pointer); }
        public static BinkMoviePlayerSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BinkMoviePlayerSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BinkMoviePlayerSettings(a[i].Pointer); return r; }
        public byte BinkBufferMode { get => GetAt<byte>(0x28); set => SetAt(0x28, value); }
        public byte BinkSoundTrack { get => GetAt<byte>(0x29); set => SetAt(0x29, value); }
        public int BinkSoundTrackStart { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public Vector2D BinkDestinationUpperLeft => new Vector2D(AddrOf(0x30));
        public Vector2D BinkDestinationLowerRight => new Vector2D(AddrOf(0x38));
        public byte BinkPixelFormat { get => GetAt<byte>(0x40); set => SetAt(0x40, value); }
    }

}
