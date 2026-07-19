// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AudioPlatformConfiguration
using System;

namespace UEModLoader.Game
{
    public enum ESoundwaveSampleRateSettings
    {
        Max = 0,
        High = 1,
        Medium = 2,
        Low = 3,
        Min = 4,
        MatchDevice = 5,
    }

    public class PlatformRuntimeAudioCompressionOverrides : StructProxy
    {
        public PlatformRuntimeAudioCompressionOverrides(System.IntPtr ptr) : base(ptr) {}
        public bool bOverrideCompressionTimes { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float DurationThreshold { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public int MaxNumRandomBranches { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public int SoundCueQualityIndex { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
    }

}
