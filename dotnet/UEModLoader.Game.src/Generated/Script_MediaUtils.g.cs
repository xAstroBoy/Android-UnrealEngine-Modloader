// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/MediaUtils
using System;

namespace UEModLoader.Game
{
    public enum EMediaPlayerOptionBooleanOverride
    {
        UseMediaPlayerSetting = 0,
        Enabled = 1,
        Disabled = 2,
    }

    public class MediaPlayerOptions : StructProxy
    {
        public MediaPlayerOptions(global::System.IntPtr ptr) : base(ptr) {}
        public MediaPlayerTrackOptions Tracks => new MediaPlayerTrackOptions(AddrOf(0x0));
        public Timespan SeekTime => new Timespan(AddrOf(0x20));
        public EMediaPlayerOptionBooleanOverride PlayOnOpen { get => (EMediaPlayerOptionBooleanOverride)GetAt<byte>(0x28); set => SetAt(0x28, (byte)value); }
        public EMediaPlayerOptionBooleanOverride Loop { get => (EMediaPlayerOptionBooleanOverride)GetAt<byte>(0x29); set => SetAt(0x29, (byte)value); }
    }

    public class MediaPlayerTrackOptions : StructProxy
    {
        public MediaPlayerTrackOptions(global::System.IntPtr ptr) : base(ptr) {}
        public int Audio { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int Caption { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int MetaData { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public int Script { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
        public int Subtitle { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
        public int Text { get => GetAt<int>(0x14); set => SetAt(0x14, value); }
        public int Video { get => GetAt<int>(0x18); set => SetAt(0x18, value); }
    }

}
