// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/Synthesis
using System;

namespace UEModLoader.Game
{
    public enum ESynth1PatchDestination
    {
        Osc1Gain = 0,
        Osc1Frequency = 1,
        Osc1Pulsewidth = 2,
        Osc2Gain = 3,
        Osc2Frequency = 4,
        Osc2Pulsewidth = 5,
        FilterFrequency = 6,
        FilterQ = 7,
        Gain = 8,
        Pan = 9,
        LFO1Frequency = 10,
        LFO1Gain = 11,
        LFO2Frequency = 12,
        LFO2Gain = 13,
        Count = 14,
    }

    public enum ESynth1PatchSource
    {
        LFO1 = 0,
        LFO2 = 1,
        Envelope = 2,
        BiasEnvelope = 3,
        Count = 4,
    }

    public enum ESynthStereoDelayMode
    {
        Normal = 0,
        Cross = 1,
        PingPong = 2,
        Count = 3,
    }

    public enum ESynthFilterAlgorithm
    {
        OnePole = 0,
        StateVariable = 1,
        Ladder = 2,
        Count = 3,
    }

    public enum ESynthFilterType
    {
        LowPass = 0,
        HighPass = 1,
        BandPass = 2,
        BandStop = 3,
        Count = 4,
    }

    public enum ESynthModEnvBiasPatch
    {
        PatchToNone = 0,
        PatchToOscFreq = 1,
        PatchToFilterFreq = 2,
        PatchToFilterQ = 3,
        PatchToLFO1Gain = 4,
        PatchToLFO2Gain = 5,
        PatchToLFO1Freq = 6,
        PatchToLFO2Freq = 7,
        Count = 8,
    }

    public enum ESynthModEnvPatch
    {
        PatchToNone = 0,
        PatchToOscFreq = 1,
        PatchToFilterFreq = 2,
        PatchToFilterQ = 3,
        PatchToLFO1Gain = 4,
        PatchToLFO2Gain = 5,
        PatchToLFO1Freq = 6,
        PatchToLFO2Freq = 7,
        Count = 8,
    }

    public enum ESynthLFOPatchType
    {
        PatchToNone = 0,
        PatchToGain = 1,
        PatchToOscFreq = 2,
        PatchToFilterFreq = 3,
        PatchToFilterQ = 4,
        PatchToOscPulseWidth = 5,
        PatchToOscPan = 6,
        PatchLFO1ToLFO2Frequency = 7,
        PatchLFO1ToLFO2Gain = 8,
        Count = 9,
    }

    public enum ESynthLFOMode
    {
        Sync = 0,
        OneShot = 1,
        Free = 2,
        Count = 3,
    }

    public enum ESynthLFOType
    {
        Sine = 0,
        UpSaw = 1,
        DownSaw = 2,
        Square = 3,
        Triangle = 4,
        Exponential = 5,
        RandomSampleHold = 6,
        Count = 7,
    }

    public enum ESynth1OscType
    {
        Sine = 0,
        Saw = 1,
        Triangle = 2,
        Square = 3,
        Noise = 4,
        Count = 5,
    }

    public enum ESourceEffectDynamicsPeakMode
    {
        MeanSquared = 0,
        RootMeanSquared = 1,
        Peak = 2,
        Count = 3,
    }

    public enum ESourceEffectDynamicsProcessorType
    {
        Compressor = 0,
        Limiter = 1,
        Expander = 2,
        Gate = 3,
        Count = 4,
    }

    public enum EEnvelopeFollowerPeakMode
    {
        MeanSquared = 0,
        RootMeanSquared = 1,
        Peak = 2,
        Count = 3,
    }

    public enum ESourceEffectFilterType
    {
        LowPass = 0,
        HighPass = 1,
        BandPass = 2,
        BandStop = 3,
        Count = 4,
    }

    public enum ESourceEffectFilterCircuit
    {
        OnePole = 0,
        StateVariable = 1,
        Ladder = 2,
        Count = 3,
    }

    public enum EStereoChannelMode
    {
        MidSide = 0,
        LeftRight = 1,
        count = 2,
    }

    public enum EPhaserLFOType
    {
        Sine = 0,
        UpSaw = 1,
        DownSaw = 2,
        Square = 3,
        Triangle = 4,
        Exponential = 5,
        RandomSampleHold = 6,
        Count = 7,
    }

    public enum ERingModulatorTypeSourceEffect
    {
        Sine = 0,
        Saw = 1,
        Triangle = 2,
        Square = 3,
        Count = 4,
    }

    public enum EStereoDelaySourceEffect
    {
        Normal = 0,
        Cross = 1,
        PingPong = 2,
        Count = 3,
    }

    public enum ESubmixEffectConvolutionReverbBlockSize
    {
        BlockSize256 = 0,
        BlockSize512 = 1,
        BlockSize1024 = 2,
    }

    public enum ESubmixFilterAlgorithm
    {
        OnePole = 0,
        StateVariable = 1,
        Ladder = 2,
        Count = 3,
    }

    public enum ESubmixFilterType
    {
        LowPass = 0,
        HighPass = 1,
        BandPass = 2,
        BandStop = 3,
        Count = 4,
    }

    public enum ETapLineMode
    {
        SendToChannel = 0,
        Panning = 1,
        Disabled = 2,
    }

    public enum EGranularSynthSeekType
    {
        FromBeginning = 0,
        FromCurrentPosition = 1,
        Count = 2,
    }

    public enum EGranularSynthEnvelopeType
    {
        Rectangular = 0,
        Triangle = 1,
        DownwardTriangle = 2,
        UpwardTriangle = 3,
        ExponentialDecay = 4,
        ExponentialIncrease = 5,
        Gaussian = 6,
        Hanning = 7,
        Lanczos = 8,
        Cosine = 9,
        CosineSquared = 10,
        Welch = 11,
        Blackman = 12,
        BlackmanHarris = 13,
        Count = 14,
    }

    public enum CurveInterpolationType
    {
        AUTOINTERP = 0,
        LINEAR = 1,
        CONSTANT = 2,
    }

    public enum ESamplePlayerSeekType
    {
        FromBeginning = 0,
        FromCurrentPosition = 1,
        FromEnd = 2,
        Count = 3,
    }

    public enum ESynthKnobSize
    {
        Medium = 0,
        Large = 1,
        Count = 2,
    }

    public enum ESynthSlateColorStyle
    {
        Light = 0,
        Dark = 1,
        Count = 2,
    }

    public enum ESynthSlateSizeType
    {
        Small = 0,
        Medium = 1,
        Large = 2,
        Count = 3,
    }

    public class ModularSynthPresetBankEntry : StructProxy
    {
        public ModularSynthPresetBankEntry(global::System.IntPtr ptr) : base(ptr) {}
        public string PresetName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public ModularSynthPreset Preset => new ModularSynthPreset(AddrOf(0x10));
    }

    public class ModularSynthPreset : StructProxy
    {
        public ModularSynthPreset(global::System.IntPtr ptr) : base(ptr) {}
        public bool bEnablePolyphony { get => (GetAt<byte>(0x8) & 0x1) != 0; set { var __b = GetAt<byte>(0x8); SetAt(0x8, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public ESynth1OscType Osc1Type { get => (ESynth1OscType)GetAt<byte>(0x9); set => SetAt(0x9, (byte)value); }
        public float Osc1Gain { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float Osc1Octave { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public float Osc1Semitones { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public float Osc1Cents { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
        public float Osc1PulseWidth { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public ESynth1OscType Osc2Type { get => (ESynth1OscType)GetAt<byte>(0x20); set => SetAt(0x20, (byte)value); }
        public float Osc2Gain { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public float Osc2Octave { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public float Osc2Semitones { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float Osc2Cents { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float Osc2PulseWidth { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public float Portamento { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public bool bEnableUnison { get => (GetAt<byte>(0x3C) & 0x1) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bEnableOscillatorSync { get => (GetAt<byte>(0x3C) & 0x2) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public float Spread { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public float Pan { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public float LFO1Frequency { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float LFO1Gain { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public ESynthLFOType LFO1Type { get => (ESynthLFOType)GetAt<byte>(0x50); set => SetAt(0x50, (byte)value); }
        public ESynthLFOMode LFO1Mode { get => (ESynthLFOMode)GetAt<byte>(0x51); set => SetAt(0x51, (byte)value); }
        public ESynthLFOPatchType LFO1PatchType { get => (ESynthLFOPatchType)GetAt<byte>(0x52); set => SetAt(0x52, (byte)value); }
        public float LFO2Frequency { get => GetAt<float>(0x54); set => SetAt(0x54, value); }
        public float LFO2Gain { get => GetAt<float>(0x58); set => SetAt(0x58, value); }
        public ESynthLFOType LFO2Type { get => (ESynthLFOType)GetAt<byte>(0x5C); set => SetAt(0x5C, (byte)value); }
        public ESynthLFOMode LFO2Mode { get => (ESynthLFOMode)GetAt<byte>(0x5D); set => SetAt(0x5D, (byte)value); }
        public ESynthLFOPatchType LFO2PatchType { get => (ESynthLFOPatchType)GetAt<byte>(0x5E); set => SetAt(0x5E, (byte)value); }
        public float GainDb { get => GetAt<float>(0x60); set => SetAt(0x60, value); }
        public float AttackTime { get => GetAt<float>(0x64); set => SetAt(0x64, value); }
        public float DecayTime { get => GetAt<float>(0x68); set => SetAt(0x68, value); }
        public float SustainGain { get => GetAt<float>(0x6C); set => SetAt(0x6C, value); }
        public float ReleaseTime { get => GetAt<float>(0x70); set => SetAt(0x70, value); }
        public ESynthModEnvPatch ModEnvPatchType { get => (ESynthModEnvPatch)GetAt<byte>(0x74); set => SetAt(0x74, (byte)value); }
        public ESynthModEnvBiasPatch ModEnvBiasPatchType { get => (ESynthModEnvBiasPatch)GetAt<byte>(0x75); set => SetAt(0x75, (byte)value); }
        public bool bInvertModulationEnvelope { get => (GetAt<byte>(0x76) & 0x1) != 0; set { var __b = GetAt<byte>(0x76); SetAt(0x76, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bInvertModulationEnvelopeBias { get => (GetAt<byte>(0x76) & 0x2) != 0; set { var __b = GetAt<byte>(0x76); SetAt(0x76, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public float ModulationEnvelopeDepth { get => GetAt<float>(0x78); set => SetAt(0x78, value); }
        public float ModulationEnvelopeAttackTime { get => GetAt<float>(0x7C); set => SetAt(0x7C, value); }
        public float ModulationEnvelopeDecayTime { get => GetAt<float>(0x80); set => SetAt(0x80, value); }
        public float ModulationEnvelopeSustainGain { get => GetAt<float>(0x84); set => SetAt(0x84, value); }
        public float ModulationEnvelopeReleaseTime { get => GetAt<float>(0x88); set => SetAt(0x88, value); }
        public bool bLegato { get => (GetAt<byte>(0x8C) & 0x1) != 0; set { var __b = GetAt<byte>(0x8C); SetAt(0x8C, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bRetrigger { get => (GetAt<byte>(0x8C) & 0x2) != 0; set { var __b = GetAt<byte>(0x8C); SetAt(0x8C, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public float FilterFrequency { get => GetAt<float>(0x90); set => SetAt(0x90, value); }
        public float FilterQ { get => GetAt<float>(0x94); set => SetAt(0x94, value); }
        public ESynthFilterType FilterType { get => (ESynthFilterType)GetAt<byte>(0x98); set => SetAt(0x98, (byte)value); }
        public ESynthFilterAlgorithm FilterAlgorithm { get => (ESynthFilterAlgorithm)GetAt<byte>(0x99); set => SetAt(0x99, (byte)value); }
        public bool bStereoDelayEnabled { get => (GetAt<byte>(0x9A) & 0x1) != 0; set { var __b = GetAt<byte>(0x9A); SetAt(0x9A, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public ESynthStereoDelayMode StereoDelayMode { get => (ESynthStereoDelayMode)GetAt<byte>(0x9B); set => SetAt(0x9B, (byte)value); }
        public float StereoDelayTime { get => GetAt<float>(0x9C); set => SetAt(0x9C, value); }
        public float StereoDelayFeedback { get => GetAt<float>(0xA0); set => SetAt(0xA0, value); }
        public float StereoDelayWetlevel { get => GetAt<float>(0xA4); set => SetAt(0xA4, value); }
        public float StereoDelayRatio { get => GetAt<float>(0xA8); set => SetAt(0xA8, value); }
        public bool bChorusEnabled { get => (GetAt<byte>(0xAC) & 0x1) != 0; set { var __b = GetAt<byte>(0xAC); SetAt(0xAC, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public float ChorusDepth { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public float ChorusFeedback { get => GetAt<float>(0xB4); set => SetAt(0xB4, value); }
        public float ChorusFrequency { get => GetAt<float>(0xB8); set => SetAt(0xB8, value); }
        public TArray<global::System.IntPtr> Patches => new TArray<global::System.IntPtr>(AddrOf(0xC0)); // TArray<struct>
    }

    public class EpicSynth1Patch : StructProxy
    {
        public EpicSynth1Patch(global::System.IntPtr ptr) : base(ptr) {}
        public ESynth1PatchSource PatchSource { get => (ESynth1PatchSource)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public TArray<global::System.IntPtr> PatchCables => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<struct>
    }

    public class Synth1PatchCable : StructProxy
    {
        public Synth1PatchCable(global::System.IntPtr ptr) : base(ptr) {}
        public float Depth { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public ESynth1PatchDestination Destination { get => (ESynth1PatchDestination)GetAt<byte>(0x4); set => SetAt(0x4, (byte)value); }
    }

    public class PatchId : StructProxy
    {
        public PatchId(global::System.IntPtr ptr) : base(ptr) {}
        public int ID { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
    }

    public class SourceEffectBitCrusherSettings : StructProxy
    {
        public SourceEffectBitCrusherSettings(global::System.IntPtr ptr) : base(ptr) {}
        public float CrushedSampleRate { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float CrushedBits { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class SourceEffectChorusSettings : StructProxy
    {
        public SourceEffectChorusSettings(global::System.IntPtr ptr) : base(ptr) {}
        public float Depth { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Frequency { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Feedback { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float WetLevel { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float DryLevel { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public float Spread { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
    }

    public class SourceEffectDynamicsProcessorSettings : StructProxy
    {
        public SourceEffectDynamicsProcessorSettings(global::System.IntPtr ptr) : base(ptr) {}
        public ESourceEffectDynamicsProcessorType DynamicsProcessorType { get => (ESourceEffectDynamicsProcessorType)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public ESourceEffectDynamicsPeakMode PeakMode { get => (ESourceEffectDynamicsPeakMode)GetAt<byte>(0x1); set => SetAt(0x1, (byte)value); }
        public float LookAheadMsec { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float AttackTimeMsec { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float ReleaseTimeMsec { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float ThresholdDb { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public float Ratio { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public float KneeBandwidthDb { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
        public float InputGainDb { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public float OutputGainDb { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public bool bStereoLinked { get => (GetAt<byte>(0x24) & 0x1) != 0; set { var __b = GetAt<byte>(0x24); SetAt(0x24, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bAnalogMode { get => (GetAt<byte>(0x24) & 0x2) != 0; set { var __b = GetAt<byte>(0x24); SetAt(0x24, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
    }

    public class SourceEffectEnvelopeFollowerSettings : StructProxy
    {
        public SourceEffectEnvelopeFollowerSettings(global::System.IntPtr ptr) : base(ptr) {}
        public float AttackTime { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float ReleaseTime { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public EEnvelopeFollowerPeakMode PeakMode { get => (EEnvelopeFollowerPeakMode)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
        public bool bIsAnalogMode { get => (GetAt<byte>(0x9) & 0xFF) != 0; set { var __b = GetAt<byte>(0x9); SetAt(0x9, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class SourceEffectEQSettings : StructProxy
    {
        public SourceEffectEQSettings(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> EQBands => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class SourceEffectEQBand : StructProxy
    {
        public SourceEffectEQBand(global::System.IntPtr ptr) : base(ptr) {}
        public float Frequency { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Bandwidth { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float GainDb { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public bool bEnabled { get => (GetAt<byte>(0xC) & 0x1) != 0; set { var __b = GetAt<byte>(0xC); SetAt(0xC, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class SourceEffectFilterSettings : StructProxy
    {
        public SourceEffectFilterSettings(global::System.IntPtr ptr) : base(ptr) {}
        public ESourceEffectFilterCircuit FilterCircuit { get => (ESourceEffectFilterCircuit)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public ESourceEffectFilterType FilterType { get => (ESourceEffectFilterType)GetAt<byte>(0x1); set => SetAt(0x1, (byte)value); }
        public float CutoffFrequency { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float FilterQ { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class SourceEffectFoldbackDistortionSettings : StructProxy
    {
        public SourceEffectFoldbackDistortionSettings(global::System.IntPtr ptr) : base(ptr) {}
        public float InputGainDb { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float ThresholdDb { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float OutputGainDb { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class SourceEffectMidSideSpreaderSettings : StructProxy
    {
        public SourceEffectMidSideSpreaderSettings(global::System.IntPtr ptr) : base(ptr) {}
        public EStereoChannelMode InputMode { get => (EStereoChannelMode)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public float SpreadAmount { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public EStereoChannelMode OutputMode { get => (EStereoChannelMode)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
        public bool bEqualPower { get => (GetAt<byte>(0x9) & 0xFF) != 0; set { var __b = GetAt<byte>(0x9); SetAt(0x9, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class SourceEffectPannerSettings : StructProxy
    {
        public SourceEffectPannerSettings(global::System.IntPtr ptr) : base(ptr) {}
        public float Spread { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Pan { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class SourceEffectPhaserSettings : StructProxy
    {
        public SourceEffectPhaserSettings(global::System.IntPtr ptr) : base(ptr) {}
        public float WetLevel { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Frequency { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Feedback { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public EPhaserLFOType LFOType { get => (EPhaserLFOType)GetAt<byte>(0xC); set => SetAt(0xC, (byte)value); }
        public bool UseQuadraturePhase { get => (GetAt<byte>(0xD) & 0xFF) != 0; set { var __b = GetAt<byte>(0xD); SetAt(0xD, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class SourceEffectRingModulationSettings : StructProxy
    {
        public SourceEffectRingModulationSettings(global::System.IntPtr ptr) : base(ptr) {}
        public ERingModulatorTypeSourceEffect ModulatorType { get => (ERingModulatorTypeSourceEffect)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public float Frequency { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Depth { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float DryLevel { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float WetLevel { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
    }

    public class SourceEffectSimpleDelaySettings : StructProxy
    {
        public SourceEffectSimpleDelaySettings(global::System.IntPtr ptr) : base(ptr) {}
        public float SpeedOfSound { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float DelayAmount { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float DryAmount { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float WetAmount { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float Feedback { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public bool bDelayBasedOnDistance { get => (GetAt<byte>(0x14) & 0x1) != 0; set { var __b = GetAt<byte>(0x14); SetAt(0x14, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class SourceEffectStereoDelaySettings : StructProxy
    {
        public SourceEffectStereoDelaySettings(global::System.IntPtr ptr) : base(ptr) {}
        public EStereoDelaySourceEffect DelayMode { get => (EStereoDelaySourceEffect)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public float DelayTimeMsec { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Feedback { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float DelayRatio { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float WetLevel { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
    }

    public class SourceEffectWaveShaperSettings : StructProxy
    {
        public SourceEffectWaveShaperSettings(global::System.IntPtr ptr) : base(ptr) {}
        public float Amount { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float OutputGainDb { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class SubmixEffectConvolutionReverbSettings : StructProxy
    {
        public SubmixEffectConvolutionReverbSettings(global::System.IntPtr ptr) : base(ptr) {}
        public float NormalizationVolumeDb { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float SurroundRearChannelBleedDb { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public bool bInvertRearChannelBleedPhase { get => (GetAt<byte>(0x8) & 0xFF) != 0; set { var __b = GetAt<byte>(0x8); SetAt(0x8, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bSurroundRearChannelFlip { get => (GetAt<byte>(0x9) & 0xFF) != 0; set { var __b = GetAt<byte>(0x9); SetAt(0x9, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float SurroundRearChannelBleedAmount { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public AudioImpulseResponse ImpulseResponse { get { var __p = GetAt<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new AudioImpulseResponse(__p); } set => SetAt(0x10, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool AllowHArdwareAcceleration { get => (GetAt<byte>(0x18) & 0xFF) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class SubmixEffectDelaySettings : StructProxy
    {
        public SubmixEffectDelaySettings(global::System.IntPtr ptr) : base(ptr) {}
        public float MaximumDelayLength { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float InterpolationTime { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float DelayLength { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class SubmixEffectFilterSettings : StructProxy
    {
        public SubmixEffectFilterSettings(global::System.IntPtr ptr) : base(ptr) {}
        public ESubmixFilterType FilterType { get => (ESubmixFilterType)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public ESubmixFilterAlgorithm FilterAlgorithm { get => (ESubmixFilterAlgorithm)GetAt<byte>(0x1); set => SetAt(0x1, (byte)value); }
        public float FilterFrequency { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float FilterQ { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class SubmixEffectFlexiverbSettings : StructProxy
    {
        public SubmixEffectFlexiverbSettings(global::System.IntPtr ptr) : base(ptr) {}
        public float PreDelay { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float DecayTime { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float RoomDampening { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public int Complexity { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
    }

    public class SubmixEffectTapDelaySettings : StructProxy
    {
        public SubmixEffectTapDelaySettings(global::System.IntPtr ptr) : base(ptr) {}
        public float MaximumDelayLength { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float InterpolationTime { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public TArray<global::System.IntPtr> Taps => new TArray<global::System.IntPtr>(AddrOf(0x8)); // TArray<struct>
    }

    public class TapDelayInfo : StructProxy
    {
        public TapDelayInfo(global::System.IntPtr ptr) : base(ptr) {}
        public ETapLineMode TapLineMode { get => (ETapLineMode)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public float DelayLength { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Gain { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public int OutputChannel { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
        public float PanInDegrees { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public int TapId { get => GetAt<int>(0x14); set => SetAt(0x14, value); }
    }

    public class Synth2DSliderStyle : StructProxy
    {
        public Synth2DSliderStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush NormalThumbImage => new SlateBrush(AddrOf(0x8));
        public SlateBrush DisabledThumbImage => new SlateBrush(AddrOf(0x90));
        public SlateBrush NormalBarImage => new SlateBrush(AddrOf(0x118));
        public SlateBrush DisabledBarImage => new SlateBrush(AddrOf(0x1A0));
        public SlateBrush BackgroundImage => new SlateBrush(AddrOf(0x228));
        public float BarThickness { get => GetAt<float>(0x2B0); set => SetAt(0x2B0, value); }
    }

    public class SynthKnobStyle : StructProxy
    {
        public SynthKnobStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush LargeKnob => new SlateBrush(AddrOf(0x8));
        public SlateBrush LargeKnobOverlay => new SlateBrush(AddrOf(0x90));
        public SlateBrush MediumKnob => new SlateBrush(AddrOf(0x118));
        public SlateBrush MediumKnobOverlay => new SlateBrush(AddrOf(0x1A0));
        public float MinValueAngle { get => GetAt<float>(0x228); set => SetAt(0x228, value); }
        public float MaxValueAngle { get => GetAt<float>(0x22C); set => SetAt(0x22C, value); }
        public ESynthKnobSize KnobSize { get => (ESynthKnobSize)GetAt<byte>(0x230); set => SetAt(0x230, (byte)value); }
    }

    public class SynthSlateStyle : StructProxy
    {
        public SynthSlateStyle(global::System.IntPtr ptr) : base(ptr) {}
        public ESynthSlateSizeType SizeType { get => (ESynthSlateSizeType)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
        public ESynthSlateColorStyle ColorStyle { get => (ESynthSlateColorStyle)GetAt<byte>(0x9); set => SetAt(0x9, (byte)value); }
    }

    public class ModularSynthPresetBank : Object
    {
        public const string UeClassName = "ModularSynthPresetBank";
        public ModularSynthPresetBank(global::System.IntPtr ptr) : base(ptr) {}
        public static new ModularSynthPresetBank FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ModularSynthPresetBank(p);
        public static ModularSynthPresetBank FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ModularSynthPresetBank(o.Pointer); }
        public static ModularSynthPresetBank[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ModularSynthPresetBank[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ModularSynthPresetBank(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Presets => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
    }

    public class ModularSynthLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "ModularSynthLibrary";
        public ModularSynthLibrary(global::System.IntPtr ptr) : base(ptr) {}
        public static new ModularSynthLibrary FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ModularSynthLibrary(p);
        public static ModularSynthLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ModularSynthLibrary(o.Pointer); }
        public static ModularSynthLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ModularSynthLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ModularSynthLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5CD0114 — hookable via Hooks.InstallAt(NativeFunc_AddModularSynthPresetToBankAsset).</summary>
        public static global::System.IntPtr NativeFunc_AddModularSynthPresetToBankAsset => Memory.ModuleBase() + 0x5CD0114;
        public void AddModularSynthPresetToBankAsset(ModularSynthPresetBank InBank, global::System.IntPtr Preset, global::System.IntPtr PresetName)
        {
            var __pb = new ParamBuffer(232);
            __pb.SetObject(0x0, InBank);
            __pb.Set<global::System.IntPtr>(0x8, Preset);
            __pb.Set<global::System.IntPtr>(0xD8, PresetName);
            CallRaw("AddModularSynthPresetToBankAsset", __pb.Bytes);
        }
    }

    public class ModularSynthComponent : SynthComponent
    {
        public const string UeClassName = "ModularSynthComponent";
        public ModularSynthComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new ModularSynthComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ModularSynthComponent(p);
        public static ModularSynthComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ModularSynthComponent(o.Pointer); }
        public static ModularSynthComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ModularSynthComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ModularSynthComponent(a[i].Pointer); return r; }
        public int VoiceCount { get => GetAt<int>(0x6D0); set => SetAt(0x6D0, value); }
        /// <summary>[Native] thunk RVA 0x5CD0AC4 — hookable via Hooks.InstallAt(NativeFunc_SetSynthPreset).</summary>
        public static global::System.IntPtr NativeFunc_SetSynthPreset => Memory.ModuleBase() + 0x5CD0AC4;
        public void SetSynthPreset(global::System.IntPtr SynthPreset)
        {
            var __pb = new ParamBuffer(208);
            __pb.Set<global::System.IntPtr>(0x0, SynthPreset);
            CallRaw("SetSynthPreset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1EC8 — hookable via Hooks.InstallAt(NativeFunc_SetSustainGain).</summary>
        public static global::System.IntPtr NativeFunc_SetSustainGain => Memory.ModuleBase() + 0x5CD1EC8;
        public void SetSustainGain(float SustainGain)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, SustainGain);
            CallRaw("SetSustainGain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD0FE4 — hookable via Hooks.InstallAt(NativeFunc_SetStereoDelayWetlevel).</summary>
        public static global::System.IntPtr NativeFunc_SetStereoDelayWetlevel => Memory.ModuleBase() + 0x5CD0FE4;
        public void SetStereoDelayWetlevel(float DelayWetlevel)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DelayWetlevel);
            CallRaw("SetStereoDelayWetlevel", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD112C — hookable via Hooks.InstallAt(NativeFunc_SetStereoDelayTime).</summary>
        public static global::System.IntPtr NativeFunc_SetStereoDelayTime => Memory.ModuleBase() + 0x5CD112C;
        public void SetStereoDelayTime(float DelayTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DelayTimeMsec);
            CallRaw("SetStereoDelayTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD0F40 — hookable via Hooks.InstallAt(NativeFunc_SetStereoDelayRatio).</summary>
        public static global::System.IntPtr NativeFunc_SetStereoDelayRatio => Memory.ModuleBase() + 0x5CD0F40;
        public void SetStereoDelayRatio(float DelayRatio)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DelayRatio);
            CallRaw("SetStereoDelayRatio", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD11D0 — hookable via Hooks.InstallAt(NativeFunc_SetStereoDelayMode).</summary>
        public static global::System.IntPtr NativeFunc_SetStereoDelayMode => Memory.ModuleBase() + 0x5CD11D0;
        public void SetStereoDelayMode(ESynthStereoDelayMode StereoDelayMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)StereoDelayMode);
            CallRaw("SetStereoDelayMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1274 — hookable via Hooks.InstallAt(NativeFunc_SetStereoDelayIsEnabled).</summary>
        public static global::System.IntPtr NativeFunc_SetStereoDelayIsEnabled => Memory.ModuleBase() + 0x5CD1274;
        public void SetStereoDelayIsEnabled(bool StereoDelayEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(StereoDelayEnabled?1:0));
            CallRaw("SetStereoDelayIsEnabled", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1088 — hookable via Hooks.InstallAt(NativeFunc_SetStereoDelayFeedback).</summary>
        public static global::System.IntPtr NativeFunc_SetStereoDelayFeedback => Memory.ModuleBase() + 0x5CD1088;
        public void SetStereoDelayFeedback(float DelayFeedback)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DelayFeedback);
            CallRaw("SetStereoDelayFeedback", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD27B0 — hookable via Hooks.InstallAt(NativeFunc_SetSpread).</summary>
        public static global::System.IntPtr NativeFunc_SetSpread => Memory.ModuleBase() + 0x5CD27B0;
        public void SetSpread(float Spread)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Spread);
            CallRaw("SetSpread", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1E24 — hookable via Hooks.InstallAt(NativeFunc_SetReleaseTime).</summary>
        public static global::System.IntPtr NativeFunc_SetReleaseTime => Memory.ModuleBase() + 0x5CD1E24;
        public void SetReleaseTime(float ReleaseTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ReleaseTimeMsec);
            CallRaw("SetReleaseTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2B38 — hookable via Hooks.InstallAt(NativeFunc_SetPortamento).</summary>
        public static global::System.IntPtr NativeFunc_SetPortamento => Memory.ModuleBase() + 0x5CD2B38;
        public void SetPortamento(float Portamento)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Portamento);
            CallRaw("SetPortamento", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2BDC — hookable via Hooks.InstallAt(NativeFunc_SetPitchBend).</summary>
        public static global::System.IntPtr NativeFunc_SetPitchBend => Memory.ModuleBase() + 0x5CD2BDC;
        public void SetPitchBend(float PitchBend)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, PitchBend);
            CallRaw("SetPitchBend", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2854 — hookable via Hooks.InstallAt(NativeFunc_SetPan).</summary>
        public static global::System.IntPtr NativeFunc_SetPan => Memory.ModuleBase() + 0x5CD2854;
        public void SetPan(float Pan)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Pan);
            CallRaw("SetPan", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2F38 — hookable via Hooks.InstallAt(NativeFunc_SetOscType).</summary>
        public static global::System.IntPtr NativeFunc_SetOscType => Memory.ModuleBase() + 0x5CD2F38;
        public void SetOscType(int OscIndex, ESynth1OscType OscType)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, OscIndex);
            __pb.Set<byte>(0x4, (byte)OscType);
            CallRaw("SetOscType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD28F8 — hookable via Hooks.InstallAt(NativeFunc_SetOscSync).</summary>
        public static global::System.IntPtr NativeFunc_SetOscSync => Memory.ModuleBase() + 0x5CD28F8;
        public void SetOscSync(bool bIsSynced)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bIsSynced?1:0));
            CallRaw("SetOscSync", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2D68 — hookable via Hooks.InstallAt(NativeFunc_SetOscSemitones).</summary>
        public static global::System.IntPtr NativeFunc_SetOscSemitones => Memory.ModuleBase() + 0x5CD2D68;
        public void SetOscSemitones(int OscIndex, float Semitones)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, OscIndex);
            __pb.Set(0x4, Semitones);
            CallRaw("SetOscSemitones", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2A50 — hookable via Hooks.InstallAt(NativeFunc_SetOscPulsewidth).</summary>
        public static global::System.IntPtr NativeFunc_SetOscPulsewidth => Memory.ModuleBase() + 0x5CD2A50;
        public void SetOscPulsewidth(int OscIndex, float Pulsewidth)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, OscIndex);
            __pb.Set(0x4, Pulsewidth);
            CallRaw("SetOscPulsewidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2E50 — hookable via Hooks.InstallAt(NativeFunc_SetOscOctave).</summary>
        public static global::System.IntPtr NativeFunc_SetOscOctave => Memory.ModuleBase() + 0x5CD2E50;
        public void SetOscOctave(int OscIndex, float Octave)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, OscIndex);
            __pb.Set(0x4, Octave);
            CallRaw("SetOscOctave", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD3108 — hookable via Hooks.InstallAt(NativeFunc_SetOscGainMod).</summary>
        public static global::System.IntPtr NativeFunc_SetOscGainMod => Memory.ModuleBase() + 0x5CD3108;
        public void SetOscGainMod(int OscIndex, float OscGainMod)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, OscIndex);
            __pb.Set(0x4, OscGainMod);
            CallRaw("SetOscGainMod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD31F0 — hookable via Hooks.InstallAt(NativeFunc_SetOscGain).</summary>
        public static global::System.IntPtr NativeFunc_SetOscGain => Memory.ModuleBase() + 0x5CD31F0;
        public void SetOscGain(int OscIndex, float OscGain)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, OscIndex);
            __pb.Set(0x4, OscGain);
            CallRaw("SetOscGain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD3020 — hookable via Hooks.InstallAt(NativeFunc_SetOscFrequencyMod).</summary>
        public static global::System.IntPtr NativeFunc_SetOscFrequencyMod => Memory.ModuleBase() + 0x5CD3020;
        public void SetOscFrequencyMod(int OscIndex, float OscFreqMod)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, OscIndex);
            __pb.Set(0x4, OscFreqMod);
            CallRaw("SetOscFrequencyMod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2C80 — hookable via Hooks.InstallAt(NativeFunc_SetOscCents).</summary>
        public static global::System.IntPtr NativeFunc_SetOscCents => Memory.ModuleBase() + 0x5CD2C80;
        public void SetOscCents(int OscIndex, float Cents)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, OscIndex);
            __pb.Set(0x4, Cents);
            CallRaw("SetOscCents", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD18F4 — hookable via Hooks.InstallAt(NativeFunc_SetModEnvSustainGain).</summary>
        public static global::System.IntPtr NativeFunc_SetModEnvSustainGain => Memory.ModuleBase() + 0x5CD18F4;
        public void SetModEnvSustainGain(float SustainGain)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, SustainGain);
            CallRaw("SetModEnvSustainGain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1850 — hookable via Hooks.InstallAt(NativeFunc_SetModEnvReleaseTime).</summary>
        public static global::System.IntPtr NativeFunc_SetModEnvReleaseTime => Memory.ModuleBase() + 0x5CD1850;
        public void SetModEnvReleaseTime(float Release)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Release);
            CallRaw("SetModEnvReleaseTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1D80 — hookable via Hooks.InstallAt(NativeFunc_SetModEnvPatch).</summary>
        public static global::System.IntPtr NativeFunc_SetModEnvPatch => Memory.ModuleBase() + 0x5CD1D80;
        public void SetModEnvPatch(ESynthModEnvPatch InPatchType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InPatchType);
            CallRaw("SetModEnvPatch", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1C30 — hookable via Hooks.InstallAt(NativeFunc_SetModEnvInvert).</summary>
        public static global::System.IntPtr NativeFunc_SetModEnvInvert => Memory.ModuleBase() + 0x5CD1C30;
        public void SetModEnvInvert(bool bInvert)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInvert?1:0));
            CallRaw("SetModEnvInvert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1AE0 — hookable via Hooks.InstallAt(NativeFunc_SetModEnvDepth).</summary>
        public static global::System.IntPtr NativeFunc_SetModEnvDepth => Memory.ModuleBase() + 0x5CD1AE0;
        public void SetModEnvDepth(float Depth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Depth);
            CallRaw("SetModEnvDepth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1998 — hookable via Hooks.InstallAt(NativeFunc_SetModEnvDecayTime).</summary>
        public static global::System.IntPtr NativeFunc_SetModEnvDecayTime => Memory.ModuleBase() + 0x5CD1998;
        public void SetModEnvDecayTime(float DecayTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DecayTimeMsec);
            CallRaw("SetModEnvDecayTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1CDC — hookable via Hooks.InstallAt(NativeFunc_SetModEnvBiasPatch).</summary>
        public static global::System.IntPtr NativeFunc_SetModEnvBiasPatch => Memory.ModuleBase() + 0x5CD1CDC;
        public void SetModEnvBiasPatch(ESynthModEnvBiasPatch InPatchType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InPatchType);
            CallRaw("SetModEnvBiasPatch", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1B84 — hookable via Hooks.InstallAt(NativeFunc_SetModEnvBiasInvert).</summary>
        public static global::System.IntPtr NativeFunc_SetModEnvBiasInvert => Memory.ModuleBase() + 0x5CD1B84;
        public void SetModEnvBiasInvert(bool bInvert)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInvert?1:0));
            CallRaw("SetModEnvBiasInvert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1A3C — hookable via Hooks.InstallAt(NativeFunc_SetModEnvAttackTime).</summary>
        public static global::System.IntPtr NativeFunc_SetModEnvAttackTime => Memory.ModuleBase() + 0x5CD1A3C;
        public void SetModEnvAttackTime(float AttackTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, AttackTimeMsec);
            CallRaw("SetModEnvAttackTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2328 — hookable via Hooks.InstallAt(NativeFunc_SetLFOType).</summary>
        public static global::System.IntPtr NativeFunc_SetLFOType => Memory.ModuleBase() + 0x5CD2328;
        public void SetLFOType(int LFOIndex, ESynthLFOType LFOType)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, LFOIndex);
            __pb.Set<byte>(0x4, (byte)LFOType);
            CallRaw("SetLFOType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2158 — hookable via Hooks.InstallAt(NativeFunc_SetLFOPatch).</summary>
        public static global::System.IntPtr NativeFunc_SetLFOPatch => Memory.ModuleBase() + 0x5CD2158;
        public void SetLFOPatch(int LFOIndex, ESynthLFOPatchType LFOPatchType)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, LFOIndex);
            __pb.Set<byte>(0x4, (byte)LFOPatchType);
            CallRaw("SetLFOPatch", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2240 — hookable via Hooks.InstallAt(NativeFunc_SetLFOMode).</summary>
        public static global::System.IntPtr NativeFunc_SetLFOMode => Memory.ModuleBase() + 0x5CD2240;
        public void SetLFOMode(int LFOIndex, ESynthLFOMode LFOMode)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, LFOIndex);
            __pb.Set<byte>(0x4, (byte)LFOMode);
            CallRaw("SetLFOMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2410 — hookable via Hooks.InstallAt(NativeFunc_SetLFOGainMod).</summary>
        public static global::System.IntPtr NativeFunc_SetLFOGainMod => Memory.ModuleBase() + 0x5CD2410;
        public void SetLFOGainMod(int LFOIndex, float GainMod)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, LFOIndex);
            __pb.Set(0x4, GainMod);
            CallRaw("SetLFOGainMod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD24F8 — hookable via Hooks.InstallAt(NativeFunc_SetLFOGain).</summary>
        public static global::System.IntPtr NativeFunc_SetLFOGain => Memory.ModuleBase() + 0x5CD24F8;
        public void SetLFOGain(int LFOIndex, float Gain)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, LFOIndex);
            __pb.Set(0x4, Gain);
            CallRaw("SetLFOGain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD25E0 — hookable via Hooks.InstallAt(NativeFunc_SetLFOFrequencyMod).</summary>
        public static global::System.IntPtr NativeFunc_SetLFOFrequencyMod => Memory.ModuleBase() + 0x5CD25E0;
        public void SetLFOFrequencyMod(int LFOIndex, float FrequencyModHz)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, LFOIndex);
            __pb.Set(0x4, FrequencyModHz);
            CallRaw("SetLFOFrequencyMod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD26C8 — hookable via Hooks.InstallAt(NativeFunc_SetLFOFrequency).</summary>
        public static global::System.IntPtr NativeFunc_SetLFOFrequency => Memory.ModuleBase() + 0x5CD26C8;
        public void SetLFOFrequency(int LFOIndex, float FrequencyHz)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, LFOIndex);
            __pb.Set(0x4, FrequencyHz);
            CallRaw("SetLFOFrequency", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD20B4 — hookable via Hooks.InstallAt(NativeFunc_SetGainDb).</summary>
        public static global::System.IntPtr NativeFunc_SetGainDb => Memory.ModuleBase() + 0x5CD20B4;
        public void SetGainDb(float GainDb)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, GainDb);
            CallRaw("SetGainDb", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD13C4 — hookable via Hooks.InstallAt(NativeFunc_SetFilterType).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterType => Memory.ModuleBase() + 0x5CD13C4;
        public void SetFilterType(ESynthFilterType FilterType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)FilterType);
            CallRaw("SetFilterType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1468 — hookable via Hooks.InstallAt(NativeFunc_SetFilterQMod).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterQMod => Memory.ModuleBase() + 0x5CD1468;
        public void SetFilterQMod(float FilterQ)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, FilterQ);
            CallRaw("SetFilterQMod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD150C — hookable via Hooks.InstallAt(NativeFunc_SetFilterQ).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterQ => Memory.ModuleBase() + 0x5CD150C;
        public void SetFilterQ(float FilterQ)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, FilterQ);
            CallRaw("SetFilterQ", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD15B0 — hookable via Hooks.InstallAt(NativeFunc_SetFilterFrequencyMod).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterFrequencyMod => Memory.ModuleBase() + 0x5CD15B0;
        public void SetFilterFrequencyMod(float FilterFrequencyHz)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, FilterFrequencyHz);
            CallRaw("SetFilterFrequencyMod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1654 — hookable via Hooks.InstallAt(NativeFunc_SetFilterFrequency).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterFrequency => Memory.ModuleBase() + 0x5CD1654;
        public void SetFilterFrequency(float FilterFrequencyHz)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, FilterFrequencyHz);
            CallRaw("SetFilterFrequency", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1320 — hookable via Hooks.InstallAt(NativeFunc_SetFilterAlgorithm).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterAlgorithm => Memory.ModuleBase() + 0x5CD1320;
        public void SetFilterAlgorithm(ESynthFilterAlgorithm FilterAlgorithm)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)FilterAlgorithm);
            CallRaw("SetFilterAlgorithm", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD29A4 — hookable via Hooks.InstallAt(NativeFunc_SetEnableUnison).</summary>
        public static global::System.IntPtr NativeFunc_SetEnableUnison => Memory.ModuleBase() + 0x5CD29A4;
        public void SetEnableUnison(bool EnableUnison)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(EnableUnison?1:0));
            CallRaw("SetEnableUnison", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD16F8 — hookable via Hooks.InstallAt(NativeFunc_SetEnableRetrigger).</summary>
        public static global::System.IntPtr NativeFunc_SetEnableRetrigger => Memory.ModuleBase() + 0x5CD16F8;
        public void SetEnableRetrigger(bool RetriggerEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(RetriggerEnabled?1:0));
            CallRaw("SetEnableRetrigger", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD32D8 — hookable via Hooks.InstallAt(NativeFunc_SetEnablePolyphony).</summary>
        public static global::System.IntPtr NativeFunc_SetEnablePolyphony => Memory.ModuleBase() + 0x5CD32D8;
        public void SetEnablePolyphony(bool bEnablePolyphony)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bEnablePolyphony?1:0));
            CallRaw("SetEnablePolyphony", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD0868 — hookable via Hooks.InstallAt(NativeFunc_SetEnablePatch).</summary>
        public static global::System.IntPtr NativeFunc_SetEnablePatch => Memory.ModuleBase() + 0x5CD0868;
        public bool SetEnablePatch(global::System.IntPtr PatchId, bool bIsEnabled)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set<global::System.IntPtr>(0x0, PatchId);
            __pb.Set<byte>(0x4, (byte)(bIsEnabled?1:0));
            CallRaw("SetEnablePatch", __pb.Bytes);
            return __pb.Get<byte>(0x5) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5CD17A4 — hookable via Hooks.InstallAt(NativeFunc_SetEnableLegato).</summary>
        public static global::System.IntPtr NativeFunc_SetEnableLegato => Memory.ModuleBase() + 0x5CD17A4;
        public void SetEnableLegato(bool LegatoEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(LegatoEnabled?1:0));
            CallRaw("SetEnableLegato", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD1F6C — hookable via Hooks.InstallAt(NativeFunc_SetDecayTime).</summary>
        public static global::System.IntPtr NativeFunc_SetDecayTime => Memory.ModuleBase() + 0x5CD1F6C;
        public void SetDecayTime(float DecayTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DecayTimeMsec);
            CallRaw("SetDecayTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD0CA8 — hookable via Hooks.InstallAt(NativeFunc_SetChorusFrequency).</summary>
        public static global::System.IntPtr NativeFunc_SetChorusFrequency => Memory.ModuleBase() + 0x5CD0CA8;
        public void SetChorusFrequency(float Frequency)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Frequency);
            CallRaw("SetChorusFrequency", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD0D4C — hookable via Hooks.InstallAt(NativeFunc_SetChorusFeedback).</summary>
        public static global::System.IntPtr NativeFunc_SetChorusFeedback => Memory.ModuleBase() + 0x5CD0D4C;
        public void SetChorusFeedback(float Feedback)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Feedback);
            CallRaw("SetChorusFeedback", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD0E94 — hookable via Hooks.InstallAt(NativeFunc_SetChorusEnabled).</summary>
        public static global::System.IntPtr NativeFunc_SetChorusEnabled => Memory.ModuleBase() + 0x5CD0E94;
        public void SetChorusEnabled(bool EnableChorus)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(EnableChorus?1:0));
            CallRaw("SetChorusEnabled", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD0DF0 — hookable via Hooks.InstallAt(NativeFunc_SetChorusDepth).</summary>
        public static global::System.IntPtr NativeFunc_SetChorusDepth => Memory.ModuleBase() + 0x5CD0DF0;
        public void SetChorusDepth(float Depth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Depth);
            CallRaw("SetChorusDepth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD2010 — hookable via Hooks.InstallAt(NativeFunc_SetAttackTime).</summary>
        public static global::System.IntPtr NativeFunc_SetAttackTime => Memory.ModuleBase() + 0x5CD2010;
        public void SetAttackTime(float AttackTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, AttackTimeMsec);
            CallRaw("SetAttackTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD34C4 — hookable via Hooks.InstallAt(NativeFunc_NoteOn).</summary>
        public static global::System.IntPtr NativeFunc_NoteOn => Memory.ModuleBase() + 0x5CD34C4;
        public void NoteOn(float Note, int Velocity, float Duration)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, Note);
            __pb.Set(0x4, Velocity);
            __pb.Set(0x8, Duration);
            CallRaw("NoteOn", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD3384 — hookable via Hooks.InstallAt(NativeFunc_NoteOff).</summary>
        public static global::System.IntPtr NativeFunc_NoteOff => Memory.ModuleBase() + 0x5CD3384;
        public void NoteOff(float Note, bool bAllNotesOff, bool bKillAllNotes)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set(0x0, Note);
            __pb.Set<byte>(0x4, (byte)(bAllNotesOff?1:0));
            __pb.Set<byte>(0x5, (byte)(bKillAllNotes?1:0));
            CallRaw("NoteOff", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CD0964 — hookable via Hooks.InstallAt(NativeFunc_CreatePatch).</summary>
        public static global::System.IntPtr NativeFunc_CreatePatch => Memory.ModuleBase() + 0x5CD0964;
        public global::System.IntPtr CreatePatch(ESynth1PatchSource PatchSource, global::System.IntPtr PatchCables, bool bEnableByDefault)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<byte>(0x0, (byte)PatchSource);
            __pb.Set<global::System.IntPtr>(0x8, PatchCables);
            __pb.Set<byte>(0x18, (byte)(bEnableByDefault?1:0));
            CallRaw("CreatePatch", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x1C);
        }
    }

    public class SourceEffectBitCrusherPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectBitCrusherPreset";
        public SourceEffectBitCrusherPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectBitCrusherPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectBitCrusherPreset(p);
        public static SourceEffectBitCrusherPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectBitCrusherPreset(o.Pointer); }
        public static SourceEffectBitCrusherPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectBitCrusherPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectBitCrusherPreset(a[i].Pointer); return r; }
        public SourceEffectBitCrusherSettings Settings => new SourceEffectBitCrusherSettings(AddrOf(0x6C));
        /// <summary>[Native] thunk RVA 0x5CD7538 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CD7538;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectChorusPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectChorusPreset";
        public SourceEffectChorusPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectChorusPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectChorusPreset(p);
        public static SourceEffectChorusPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectChorusPreset(o.Pointer); }
        public static SourceEffectChorusPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectChorusPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectChorusPreset(a[i].Pointer); return r; }
        public SourceEffectChorusSettings Settings => new SourceEffectChorusSettings(AddrOf(0x7C));
        /// <summary>[Native] thunk RVA 0x5CD86F8 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CD86F8;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectDynamicsProcessorPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectDynamicsProcessorPreset";
        public SourceEffectDynamicsProcessorPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectDynamicsProcessorPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectDynamicsProcessorPreset(p);
        public static SourceEffectDynamicsProcessorPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectDynamicsProcessorPreset(o.Pointer); }
        public static SourceEffectDynamicsProcessorPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectDynamicsProcessorPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectDynamicsProcessorPreset(a[i].Pointer); return r; }
        public SourceEffectDynamicsProcessorSettings Settings => new SourceEffectDynamicsProcessorSettings(AddrOf(0x8C));
        /// <summary>[Native] thunk RVA 0x5CD9A9C — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CD9A9C;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class EnvelopeFollowerListener : ActorComponent
    {
        public const string UeClassName = "EnvelopeFollowerListener";
        public EnvelopeFollowerListener(global::System.IntPtr ptr) : base(ptr) {}
        public static new EnvelopeFollowerListener FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new EnvelopeFollowerListener(p);
        public static EnvelopeFollowerListener FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EnvelopeFollowerListener(o.Pointer); }
        public static EnvelopeFollowerListener[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EnvelopeFollowerListener[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EnvelopeFollowerListener(a[i].Pointer); return r; }
        public global::System.IntPtr OnEnvelopeFollowerUpdate => AddrOf(0xB0); // 
    }

    public class SourceEffectEnvelopeFollowerPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectEnvelopeFollowerPreset";
        public SourceEffectEnvelopeFollowerPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectEnvelopeFollowerPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectEnvelopeFollowerPreset(p);
        public static SourceEffectEnvelopeFollowerPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectEnvelopeFollowerPreset(o.Pointer); }
        public static SourceEffectEnvelopeFollowerPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectEnvelopeFollowerPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectEnvelopeFollowerPreset(a[i].Pointer); return r; }
        public SourceEffectEnvelopeFollowerSettings Settings => new SourceEffectEnvelopeFollowerSettings(AddrOf(0x70));
        /// <summary>[Native] thunk RVA 0x5CDB230 — hookable via Hooks.InstallAt(NativeFunc_UnregisterEnvelopeFollowerListener).</summary>
        public static global::System.IntPtr NativeFunc_UnregisterEnvelopeFollowerListener => Memory.ModuleBase() + 0x5CDB230;
        public void UnregisterEnvelopeFollowerListener(EnvelopeFollowerListener EnvelopeFollowerListener)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, EnvelopeFollowerListener);
            CallRaw("UnregisterEnvelopeFollowerListener", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CDB378 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CDB378;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CDB2D4 — hookable via Hooks.InstallAt(NativeFunc_RegisterEnvelopeFollowerListener).</summary>
        public static global::System.IntPtr NativeFunc_RegisterEnvelopeFollowerListener => Memory.ModuleBase() + 0x5CDB2D4;
        public void RegisterEnvelopeFollowerListener(EnvelopeFollowerListener EnvelopeFollowerListener)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, EnvelopeFollowerListener);
            CallRaw("RegisterEnvelopeFollowerListener", __pb.Bytes);
        }
    }

    public class SourceEffectEQPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectEQPreset";
        public SourceEffectEQPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectEQPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectEQPreset(p);
        public static SourceEffectEQPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectEQPreset(o.Pointer); }
        public static SourceEffectEQPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectEQPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectEQPreset(a[i].Pointer); return r; }
        public SourceEffectEQSettings Settings => new SourceEffectEQSettings(AddrOf(0x78));
        /// <summary>[Native] thunk RVA 0x5CDC940 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CDC940;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectFilterPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectFilterPreset";
        public SourceEffectFilterPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectFilterPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectFilterPreset(p);
        public static SourceEffectFilterPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectFilterPreset(o.Pointer); }
        public static SourceEffectFilterPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectFilterPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectFilterPreset(a[i].Pointer); return r; }
        public SourceEffectFilterSettings Settings => new SourceEffectFilterSettings(AddrOf(0x70));
        /// <summary>[Native] thunk RVA 0x5CDDF54 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CDDF54;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectFoldbackDistortionPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectFoldbackDistortionPreset";
        public SourceEffectFoldbackDistortionPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectFoldbackDistortionPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectFoldbackDistortionPreset(p);
        public static SourceEffectFoldbackDistortionPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectFoldbackDistortionPreset(o.Pointer); }
        public static SourceEffectFoldbackDistortionPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectFoldbackDistortionPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectFoldbackDistortionPreset(a[i].Pointer); return r; }
        public SourceEffectFoldbackDistortionSettings Settings => new SourceEffectFoldbackDistortionSettings(AddrOf(0x70));
        /// <summary>[Native] thunk RVA 0x5CDF110 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CDF110;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectMidSideSpreaderPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectMidSideSpreaderPreset";
        public SourceEffectMidSideSpreaderPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectMidSideSpreaderPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectMidSideSpreaderPreset(p);
        public static SourceEffectMidSideSpreaderPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectMidSideSpreaderPreset(o.Pointer); }
        public static SourceEffectMidSideSpreaderPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectMidSideSpreaderPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectMidSideSpreaderPreset(a[i].Pointer); return r; }
        public SourceEffectMidSideSpreaderSettings Settings => new SourceEffectMidSideSpreaderSettings(AddrOf(0x70));
        /// <summary>[Native] thunk RVA 0x5CE0390 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CE0390;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectPannerPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectPannerPreset";
        public SourceEffectPannerPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectPannerPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectPannerPreset(p);
        public static SourceEffectPannerPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectPannerPreset(o.Pointer); }
        public static SourceEffectPannerPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectPannerPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectPannerPreset(a[i].Pointer); return r; }
        public SourceEffectPannerSettings Settings => new SourceEffectPannerSettings(AddrOf(0x6C));
        /// <summary>[Native] thunk RVA 0x5CE1534 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CE1534;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectPhaserPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectPhaserPreset";
        public SourceEffectPhaserPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectPhaserPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectPhaserPreset(p);
        public static SourceEffectPhaserPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectPhaserPreset(o.Pointer); }
        public static SourceEffectPhaserPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectPhaserPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectPhaserPreset(a[i].Pointer); return r; }
        public SourceEffectPhaserSettings Settings => new SourceEffectPhaserSettings(AddrOf(0x74));
        /// <summary>[Native] thunk RVA 0x5CE27F4 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CE27F4;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectRingModulationPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectRingModulationPreset";
        public SourceEffectRingModulationPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectRingModulationPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectRingModulationPreset(p);
        public static SourceEffectRingModulationPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectRingModulationPreset(o.Pointer); }
        public static SourceEffectRingModulationPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectRingModulationPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectRingModulationPreset(a[i].Pointer); return r; }
        public SourceEffectRingModulationSettings Settings => new SourceEffectRingModulationSettings(AddrOf(0x78));
        /// <summary>[Native] thunk RVA 0x5CE3AB8 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CE3AB8;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectSimpleDelayPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectSimpleDelayPreset";
        public SourceEffectSimpleDelayPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectSimpleDelayPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectSimpleDelayPreset(p);
        public static SourceEffectSimpleDelayPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectSimpleDelayPreset(o.Pointer); }
        public static SourceEffectSimpleDelayPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectSimpleDelayPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectSimpleDelayPreset(a[i].Pointer); return r; }
        public SourceEffectSimpleDelaySettings Settings => new SourceEffectSimpleDelaySettings(AddrOf(0x7C));
        /// <summary>[Native] thunk RVA 0x5CE4C5C — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CE4C5C;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectStereoDelayPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectStereoDelayPreset";
        public SourceEffectStereoDelayPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectStereoDelayPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectStereoDelayPreset(p);
        public static SourceEffectStereoDelayPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectStereoDelayPreset(o.Pointer); }
        public static SourceEffectStereoDelayPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectStereoDelayPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectStereoDelayPreset(a[i].Pointer); return r; }
        public SourceEffectStereoDelaySettings Settings => new SourceEffectStereoDelaySettings(AddrOf(0x78));
        /// <summary>[Native] thunk RVA 0x5CE5F28 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CE5F28;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SourceEffectWaveShaperPreset : SoundEffectSourcePreset
    {
        public const string UeClassName = "SourceEffectWaveShaperPreset";
        public SourceEffectWaveShaperPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SourceEffectWaveShaperPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SourceEffectWaveShaperPreset(p);
        public static SourceEffectWaveShaperPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SourceEffectWaveShaperPreset(o.Pointer); }
        public static SourceEffectWaveShaperPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SourceEffectWaveShaperPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SourceEffectWaveShaperPreset(a[i].Pointer); return r; }
        public SourceEffectWaveShaperSettings Settings => new SourceEffectWaveShaperSettings(AddrOf(0x6C));
        /// <summary>[Native] thunk RVA 0x5CE70CC — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CE70CC;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class AudioImpulseResponse : Object
    {
        public const string UeClassName = "AudioImpulseResponse";
        public AudioImpulseResponse(global::System.IntPtr ptr) : base(ptr) {}
        public static new AudioImpulseResponse FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AudioImpulseResponse(p);
        public static AudioImpulseResponse FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AudioImpulseResponse(o.Pointer); }
        public static AudioImpulseResponse[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AudioImpulseResponse[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AudioImpulseResponse(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> ImpulseResponse => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<float>
        public int NumChannels { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
        public int SampleRate { get => GetAt<int>(0x3C); set => SetAt(0x3C, value); }
        public float NormalizationVolumeDb { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public TArray<global::System.IntPtr> IRData => new TArray<global::System.IntPtr>(AddrOf(0x48)); // TArray<float>
    }

    public class SubmixEffectConvolutionReverbPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectConvolutionReverbPreset";
        public SubmixEffectConvolutionReverbPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectConvolutionReverbPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SubmixEffectConvolutionReverbPreset(p);
        public static SubmixEffectConvolutionReverbPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectConvolutionReverbPreset(o.Pointer); }
        public static SubmixEffectConvolutionReverbPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectConvolutionReverbPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectConvolutionReverbPreset(a[i].Pointer); return r; }
        public SubmixEffectConvolutionReverbSettings Settings => new SubmixEffectConvolutionReverbSettings(AddrOf(0x40));
        public AudioImpulseResponse ImpulseResponse { get { var __p = GetAt<global::System.IntPtr>(0x60); return __p==global::System.IntPtr.Zero?null:new AudioImpulseResponse(__p); } set => SetAt(0x60, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ESubmixEffectConvolutionReverbBlockSize BlockSize { get => (ESubmixEffectConvolutionReverbBlockSize)GetAt<byte>(0x68); set => SetAt(0x68, (byte)value); }
        public bool bEnableHardwareAcceleration { get => Native.GetPropBool(Pointer, "bEnableHardwareAcceleration"); set => Native.SetPropBool(Pointer, "bEnableHardwareAcceleration", value); }
        /// <summary>[Native] thunk RVA 0x5CE87B0 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CE87B0;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CE870C — hookable via Hooks.InstallAt(NativeFunc_SetImpulseResponse).</summary>
        public static global::System.IntPtr NativeFunc_SetImpulseResponse => Memory.ModuleBase() + 0x5CE870C;
        public void SetImpulseResponse(AudioImpulseResponse InImpulseResponse)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InImpulseResponse);
            CallRaw("SetImpulseResponse", __pb.Bytes);
        }
    }

    public class SubmixEffectDelayPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectDelayPreset";
        public SubmixEffectDelayPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectDelayPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SubmixEffectDelayPreset(p);
        public static SubmixEffectDelayPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectDelayPreset(o.Pointer); }
        public static SubmixEffectDelayPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectDelayPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectDelayPreset(a[i].Pointer); return r; }
        public SubmixEffectDelaySettings Settings => new SubmixEffectDelaySettings(AddrOf(0x70));
        public SubmixEffectDelaySettings DynamicSettings => new SubmixEffectDelaySettings(AddrOf(0x7C));
        /// <summary>[Native] thunk RVA 0x5CE96C0 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CE96C0;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CE9600 — hookable via Hooks.InstallAt(NativeFunc_SetInterpolationTime).</summary>
        public static global::System.IntPtr NativeFunc_SetInterpolationTime => Memory.ModuleBase() + 0x5CE9600;
        public void SetInterpolationTime(float Time)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Time);
            CallRaw("SetInterpolationTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CE955C — hookable via Hooks.InstallAt(NativeFunc_SetDelay).</summary>
        public static global::System.IntPtr NativeFunc_SetDelay => Memory.ModuleBase() + 0x5CE955C;
        public void SetDelay(float Length)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Length);
            CallRaw("SetDelay", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CE96A4 — hookable via Hooks.InstallAt(NativeFunc_GetMaxDelayInMilliseconds).</summary>
        public static global::System.IntPtr NativeFunc_GetMaxDelayInMilliseconds => Memory.ModuleBase() + 0x5CE96A4;
        public float GetMaxDelayInMilliseconds()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMaxDelayInMilliseconds", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
    }

    public class SubmixEffectFilterPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectFilterPreset";
        public SubmixEffectFilterPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectFilterPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SubmixEffectFilterPreset(p);
        public static SubmixEffectFilterPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectFilterPreset(o.Pointer); }
        public static SubmixEffectFilterPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectFilterPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectFilterPreset(a[i].Pointer); return r; }
        public SubmixEffectFilterSettings Settings => new SubmixEffectFilterSettings(AddrOf(0x70));
        /// <summary>[Native] thunk RVA 0x5CEAA28 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CEAA28;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEA984 — hookable via Hooks.InstallAt(NativeFunc_SetFilterType).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterType => Memory.ModuleBase() + 0x5CEA984;
        public void SetFilterType(ESubmixFilterType InType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InType);
            CallRaw("SetFilterType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEA650 — hookable via Hooks.InstallAt(NativeFunc_SetFilterQMod).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterQMod => Memory.ModuleBase() + 0x5CEA650;
        public void SetFilterQMod(float InQ)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InQ);
            CallRaw("SetFilterQMod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEA6F4 — hookable via Hooks.InstallAt(NativeFunc_SetFilterQ).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterQ => Memory.ModuleBase() + 0x5CEA6F4;
        public void SetFilterQ(float InQ)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InQ);
            CallRaw("SetFilterQ", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEA798 — hookable via Hooks.InstallAt(NativeFunc_SetFilterCutoffFrequencyMod).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterCutoffFrequencyMod => Memory.ModuleBase() + 0x5CEA798;
        public void SetFilterCutoffFrequencyMod(float InFrequency)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InFrequency);
            CallRaw("SetFilterCutoffFrequencyMod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEA83C — hookable via Hooks.InstallAt(NativeFunc_SetFilterCutoffFrequency).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterCutoffFrequency => Memory.ModuleBase() + 0x5CEA83C;
        public void SetFilterCutoffFrequency(float InFrequency)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InFrequency);
            CallRaw("SetFilterCutoffFrequency", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEA8E0 — hookable via Hooks.InstallAt(NativeFunc_SetFilterAlgorithm).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterAlgorithm => Memory.ModuleBase() + 0x5CEA8E0;
        public void SetFilterAlgorithm(ESubmixFilterAlgorithm InAlgorithm)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InAlgorithm);
            CallRaw("SetFilterAlgorithm", __pb.Bytes);
        }
    }

    public class SubmixEffectFlexiverbPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectFlexiverbPreset";
        public SubmixEffectFlexiverbPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectFlexiverbPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SubmixEffectFlexiverbPreset(p);
        public static SubmixEffectFlexiverbPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectFlexiverbPreset(o.Pointer); }
        public static SubmixEffectFlexiverbPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectFlexiverbPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectFlexiverbPreset(a[i].Pointer); return r; }
        public SubmixEffectFlexiverbSettings Settings => new SubmixEffectFlexiverbSettings(AddrOf(0x74));
        /// <summary>[Native] thunk RVA 0x5CEBD80 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CEBD80;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SubmixEffectTapDelayPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectTapDelayPreset";
        public SubmixEffectTapDelayPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectTapDelayPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SubmixEffectTapDelayPreset(p);
        public static SubmixEffectTapDelayPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectTapDelayPreset(o.Pointer); }
        public static SubmixEffectTapDelayPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectTapDelayPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectTapDelayPreset(a[i].Pointer); return r; }
        public SubmixEffectTapDelaySettings Settings => new SubmixEffectTapDelaySettings(AddrOf(0x80));
        /// <summary>[Native] thunk RVA 0x5CED390 — hookable via Hooks.InstallAt(NativeFunc_SetTap).</summary>
        public static global::System.IntPtr NativeFunc_SetTap => Memory.ModuleBase() + 0x5CED390;
        public void SetTap(int TapId, global::System.IntPtr TapInfo)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set(0x0, TapId);
            __pb.Set<global::System.IntPtr>(0x4, TapInfo);
            CallRaw("SetTap", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CED5DC — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static global::System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5CED5DC;
        public void SetSettings(global::System.IntPtr InSettings)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CED11C — hookable via Hooks.InstallAt(NativeFunc_SetInterpolationTime).</summary>
        public static global::System.IntPtr NativeFunc_SetInterpolationTime => Memory.ModuleBase() + 0x5CED11C;
        public void SetInterpolationTime(float Time)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Time);
            CallRaw("SetInterpolationTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CED484 — hookable via Hooks.InstallAt(NativeFunc_RemoveTap).</summary>
        public static global::System.IntPtr NativeFunc_RemoveTap => Memory.ModuleBase() + 0x5CED484;
        public void RemoveTap(int TapId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, TapId);
            CallRaw("RemoveTap", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CED1DC — hookable via Hooks.InstallAt(NativeFunc_GetTapIds).</summary>
        public static global::System.IntPtr NativeFunc_GetTapIds => Memory.ModuleBase() + 0x5CED1DC;
        public void GetTapIds(global::System.IntPtr TapIds)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, TapIds);
            CallRaw("GetTapIds", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CED29C — hookable via Hooks.InstallAt(NativeFunc_GetTap).</summary>
        public static global::System.IntPtr NativeFunc_GetTap => Memory.ModuleBase() + 0x5CED29C;
        public void GetTap(int TapId, global::System.IntPtr TapInfo)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set(0x0, TapId);
            __pb.Set<global::System.IntPtr>(0x4, TapInfo);
            CallRaw("GetTap", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CED1C0 — hookable via Hooks.InstallAt(NativeFunc_GetMaxDelayInMilliseconds).</summary>
        public static global::System.IntPtr NativeFunc_GetMaxDelayInMilliseconds => Memory.ModuleBase() + 0x5CED1C0;
        public float GetMaxDelayInMilliseconds()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMaxDelayInMilliseconds", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5CED528 — hookable via Hooks.InstallAt(NativeFunc_AddTap).</summary>
        public static global::System.IntPtr NativeFunc_AddTap => Memory.ModuleBase() + 0x5CED528;
        public void AddTap(int TapId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, TapId);
            CallRaw("AddTap", __pb.Bytes);
        }
    }

    public class Synth2DSlider : Widget
    {
        public const string UeClassName = "Synth2DSlider";
        public Synth2DSlider(global::System.IntPtr ptr) : base(ptr) {}
        public static new Synth2DSlider FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Synth2DSlider(p);
        public static Synth2DSlider FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Synth2DSlider(o.Pointer); }
        public static Synth2DSlider[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Synth2DSlider[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Synth2DSlider(a[i].Pointer); return r; }
        public float ValueX { get => GetAt<float>(0x108); set => SetAt(0x108, value); }
        public float ValueY { get => GetAt<float>(0x10C); set => SetAt(0x10C, value); }
        public global::System.IntPtr ValueXDelegate => AddrOf(0x110); // 
        public global::System.IntPtr ValueYDelegate => AddrOf(0x120); // 
        public Synth2DSliderStyle WidgetStyle => new Synth2DSliderStyle(AddrOf(0x130));
        public LinearColor SliderHandleColor => new LinearColor(AddrOf(0x3E8));
        public bool IndentHandle { get => Native.GetPropBool(Pointer, "IndentHandle"); set => Native.SetPropBool(Pointer, "IndentHandle", value); }
        public bool Locked { get => Native.GetPropBool(Pointer, "Locked"); set => Native.SetPropBool(Pointer, "Locked", value); }
        public float StepSize { get => GetAt<float>(0x3FC); set => SetAt(0x3FC, value); }
        public bool IsFocusable { get => Native.GetPropBool(Pointer, "IsFocusable"); set => Native.SetPropBool(Pointer, "IsFocusable", value); }
        public global::System.IntPtr OnMouseCaptureBegin => AddrOf(0x408); // 
        public global::System.IntPtr OnMouseCaptureEnd => AddrOf(0x418); // 
        public global::System.IntPtr OnControllerCaptureBegin => AddrOf(0x428); // 
        public global::System.IntPtr OnControllerCaptureEnd => AddrOf(0x438); // 
        public global::System.IntPtr OnValueChangedX => AddrOf(0x448); // 
        public global::System.IntPtr OnValueChangedY => AddrOf(0x458); // 
        /// <summary>[Native] thunk RVA 0x5CEEA10 — hookable via Hooks.InstallAt(NativeFunc_SetValue).</summary>
        public static global::System.IntPtr NativeFunc_SetValue => Memory.ModuleBase() + 0x5CEEA10;
        public void SetValue(global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, InValue);
            CallRaw("SetValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEE814 — hookable via Hooks.InstallAt(NativeFunc_SetStepSize).</summary>
        public static global::System.IntPtr NativeFunc_SetStepSize => Memory.ModuleBase() + 0x5CEE814;
        public void SetStepSize(float InValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InValue);
            CallRaw("SetStepSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEE770 — hookable via Hooks.InstallAt(NativeFunc_SetSliderHandleColor).</summary>
        public static global::System.IntPtr NativeFunc_SetSliderHandleColor => Memory.ModuleBase() + 0x5CEE770;
        public void SetSliderHandleColor(global::System.IntPtr InValue)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, InValue);
            CallRaw("SetSliderHandleColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEE8B8 — hookable via Hooks.InstallAt(NativeFunc_SetLocked).</summary>
        public static global::System.IntPtr NativeFunc_SetLocked => Memory.ModuleBase() + 0x5CEE8B8;
        public void SetLocked(bool InValue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InValue?1:0));
            CallRaw("SetLocked", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEE964 — hookable via Hooks.InstallAt(NativeFunc_SetIndentHandle).</summary>
        public static global::System.IntPtr NativeFunc_SetIndentHandle => Memory.ModuleBase() + 0x5CEE964;
        public void SetIndentHandle(bool InValue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InValue?1:0));
            CallRaw("SetIndentHandle", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEEAB0 — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static global::System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x5CEEAB0;
        public global::System.IntPtr GetValue()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetValue", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
    }

    public class GranularSynth : SynthComponent
    {
        public const string UeClassName = "GranularSynth";
        public GranularSynth(global::System.IntPtr ptr) : base(ptr) {}
        public static new GranularSynth FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GranularSynth(p);
        public static GranularSynth FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GranularSynth(o.Pointer); }
        public static GranularSynth[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GranularSynth[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GranularSynth(a[i].Pointer); return r; }
        public SoundWave GranulatedSoundWave { get { var __p = GetAt<global::System.IntPtr>(0x6D0); return __p==global::System.IntPtr.Zero?null:new SoundWave(__p); } set => SetAt(0x6D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x5CF07A8 — hookable via Hooks.InstallAt(NativeFunc_SetSustainGain).</summary>
        public static global::System.IntPtr NativeFunc_SetSustainGain => Memory.ModuleBase() + 0x5CF07A8;
        public void SetSustainGain(float SustainGain)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, SustainGain);
            CallRaw("SetSustainGain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF0994 — hookable via Hooks.InstallAt(NativeFunc_SetSoundWave).</summary>
        public static global::System.IntPtr NativeFunc_SetSoundWave => Memory.ModuleBase() + 0x5CF0994;
        public void SetSoundWave(SoundWave InSoundWave)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InSoundWave);
            CallRaw("SetSoundWave", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEFDF8 — hookable via Hooks.InstallAt(NativeFunc_SetScrubMode).</summary>
        public static global::System.IntPtr NativeFunc_SetScrubMode => Memory.ModuleBase() + 0x5CEFDF8;
        public void SetScrubMode(bool bScrubMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bScrubMode?1:0));
            CallRaw("SetScrubMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF0704 — hookable via Hooks.InstallAt(NativeFunc_SetReleaseTimeMsec).</summary>
        public static global::System.IntPtr NativeFunc_SetReleaseTimeMsec => Memory.ModuleBase() + 0x5CF0704;
        public void SetReleaseTimeMsec(float ReleaseTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ReleaseTimeMsec);
            CallRaw("SetReleaseTimeMsec", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEFCD0 — hookable via Hooks.InstallAt(NativeFunc_SetPlayheadTime).</summary>
        public static global::System.IntPtr NativeFunc_SetPlayheadTime => Memory.ModuleBase() + 0x5CEFCD0;
        public void SetPlayheadTime(float InPositionSec, float LerpTimeSec, EGranularSynthSeekType SeekType)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, InPositionSec);
            __pb.Set(0x4, LerpTimeSec);
            __pb.Set<byte>(0x8, (byte)SeekType);
            CallRaw("SetPlayheadTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF0258 — hookable via Hooks.InstallAt(NativeFunc_SetPlaybackSpeed).</summary>
        public static global::System.IntPtr NativeFunc_SetPlaybackSpeed => Memory.ModuleBase() + 0x5CF0258;
        public void SetPlaybackSpeed(float InPlayheadRate)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InPlayheadRate);
            CallRaw("SetPlaybackSpeed", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF0098 — hookable via Hooks.InstallAt(NativeFunc_SetGrainVolume).</summary>
        public static global::System.IntPtr NativeFunc_SetGrainVolume => Memory.ModuleBase() + 0x5CF0098;
        public void SetGrainVolume(float BaseVolume, global::System.IntPtr VolumeRange)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, BaseVolume);
            __pb.Set<global::System.IntPtr>(0x4, VolumeRange);
            CallRaw("SetGrainVolume", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF0444 — hookable via Hooks.InstallAt(NativeFunc_SetGrainsPerSecond).</summary>
        public static global::System.IntPtr NativeFunc_SetGrainsPerSecond => Memory.ModuleBase() + 0x5CF0444;
        public void SetGrainsPerSecond(float InGrainsPerSecond)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InGrainsPerSecond);
            CallRaw("SetGrainsPerSecond", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF03A0 — hookable via Hooks.InstallAt(NativeFunc_SetGrainProbability).</summary>
        public static global::System.IntPtr NativeFunc_SetGrainProbability => Memory.ModuleBase() + 0x5CF03A0;
        public void SetGrainProbability(float InGrainProbability)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InGrainProbability);
            CallRaw("SetGrainProbability", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF0178 — hookable via Hooks.InstallAt(NativeFunc_SetGrainPitch).</summary>
        public static global::System.IntPtr NativeFunc_SetGrainPitch => Memory.ModuleBase() + 0x5CF0178;
        public void SetGrainPitch(float BasePitch, global::System.IntPtr PitchRange)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, BasePitch);
            __pb.Set<global::System.IntPtr>(0x4, PitchRange);
            CallRaw("SetGrainPitch", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEFFB8 — hookable via Hooks.InstallAt(NativeFunc_SetGrainPan).</summary>
        public static global::System.IntPtr NativeFunc_SetGrainPan => Memory.ModuleBase() + 0x5CEFFB8;
        public void SetGrainPan(float BasePan, global::System.IntPtr PanRange)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, BasePan);
            __pb.Set<global::System.IntPtr>(0x4, PanRange);
            CallRaw("SetGrainPan", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF02FC — hookable via Hooks.InstallAt(NativeFunc_SetGrainEnvelopeType).</summary>
        public static global::System.IntPtr NativeFunc_SetGrainEnvelopeType => Memory.ModuleBase() + 0x5CF02FC;
        public void SetGrainEnvelopeType(EGranularSynthEnvelopeType EnvelopeType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)EnvelopeType);
            CallRaw("SetGrainEnvelopeType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEFED8 — hookable via Hooks.InstallAt(NativeFunc_SetGrainDuration).</summary>
        public static global::System.IntPtr NativeFunc_SetGrainDuration => Memory.ModuleBase() + 0x5CEFED8;
        public void SetGrainDuration(float BaseDurationMsec, global::System.IntPtr DurationRange)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, BaseDurationMsec);
            __pb.Set<global::System.IntPtr>(0x4, DurationRange);
            CallRaw("SetGrainDuration", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF084C — hookable via Hooks.InstallAt(NativeFunc_SetDecayTime).</summary>
        public static global::System.IntPtr NativeFunc_SetDecayTime => Memory.ModuleBase() + 0x5CF084C;
        public void SetDecayTime(float DecayTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DecayTimeMsec);
            CallRaw("SetDecayTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF08F0 — hookable via Hooks.InstallAt(NativeFunc_SetAttackTime).</summary>
        public static global::System.IntPtr NativeFunc_SetAttackTime => Memory.ModuleBase() + 0x5CF08F0;
        public void SetAttackTime(float AttackTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, AttackTimeMsec);
            CallRaw("SetAttackTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF05D8 — hookable via Hooks.InstallAt(NativeFunc_NoteOn).</summary>
        public static global::System.IntPtr NativeFunc_NoteOn => Memory.ModuleBase() + 0x5CF05D8;
        public void NoteOn(float Note, int Velocity, float Duration)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, Note);
            __pb.Set(0x4, Velocity);
            __pb.Set(0x8, Duration);
            CallRaw("NoteOn", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF04E8 — hookable via Hooks.InstallAt(NativeFunc_NoteOff).</summary>
        public static global::System.IntPtr NativeFunc_NoteOff => Memory.ModuleBase() + 0x5CF04E8;
        public void NoteOff(float Note, bool bKill)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Note);
            __pb.Set<byte>(0x4, (byte)(bKill?1:0));
            CallRaw("NoteOff", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CEFC64 — hookable via Hooks.InstallAt(NativeFunc_IsLoaded).</summary>
        public static global::System.IntPtr NativeFunc_IsLoaded => Memory.ModuleBase() + 0x5CEFC64;
        public bool IsLoaded()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsLoaded", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5CEFEA4 — hookable via Hooks.InstallAt(NativeFunc_GetSampleDuration).</summary>
        public static global::System.IntPtr NativeFunc_GetSampleDuration => Memory.ModuleBase() + 0x5CEFEA4;
        public float GetSampleDuration()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetSampleDuration", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5CEFC9C — hookable via Hooks.InstallAt(NativeFunc_GetCurrentPlayheadTime).</summary>
        public static global::System.IntPtr NativeFunc_GetCurrentPlayheadTime => Memory.ModuleBase() + 0x5CEFC9C;
        public float GetCurrentPlayheadTime()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetCurrentPlayheadTime", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
    }

    public class MonoWaveTableSynthPreset : Object
    {
        public const string UeClassName = "MonoWaveTableSynthPreset";
        public MonoWaveTableSynthPreset(global::System.IntPtr ptr) : base(ptr) {}
        public static new MonoWaveTableSynthPreset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MonoWaveTableSynthPreset(p);
        public static MonoWaveTableSynthPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MonoWaveTableSynthPreset(o.Pointer); }
        public static MonoWaveTableSynthPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MonoWaveTableSynthPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MonoWaveTableSynthPreset(a[i].Pointer); return r; }
        public string PresetName => Native.GetPropString(Pointer, "PresetName"); // FString
        public bool bLockKeyframesToGridBool { get => Native.GetPropBool(Pointer, "bLockKeyframesToGridBool"); set => Native.SetPropBool(Pointer, "bLockKeyframesToGridBool", value); }
        public int LockKeyframesToGrid { get => GetAt<int>(0x3C); set => SetAt(0x3C, value); }
        public int WaveTableResolution { get => GetAt<int>(0x40); set => SetAt(0x40, value); }
        public TArray<global::System.IntPtr> WaveTable => new TArray<global::System.IntPtr>(AddrOf(0x48)); // TArray<struct>
        public bool bNormalizeWaveTables { get => Native.GetPropBool(Pointer, "bNormalizeWaveTables"); set => Native.SetPropBool(Pointer, "bNormalizeWaveTables", value); }
    }

    public class SynthComponentMonoWaveTable : SynthComponent
    {
        public const string UeClassName = "SynthComponentMonoWaveTable";
        public SynthComponentMonoWaveTable(global::System.IntPtr ptr) : base(ptr) {}
        public static new SynthComponentMonoWaveTable FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SynthComponentMonoWaveTable(p);
        public static SynthComponentMonoWaveTable FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SynthComponentMonoWaveTable(o.Pointer); }
        public static SynthComponentMonoWaveTable[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SynthComponentMonoWaveTable[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SynthComponentMonoWaveTable(a[i].Pointer); return r; }
        public global::System.IntPtr OnTableAltered => AddrOf(0x6D0); // 
        public global::System.IntPtr OnNumTablesChanged => AddrOf(0x6E0); // 
        public MonoWaveTableSynthPreset CurrentPreset { get { var __p = GetAt<global::System.IntPtr>(0x6F0); return __p==global::System.IntPtr.Zero?null:new MonoWaveTableSynthPreset(__p); } set => SetAt(0x6F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x5CF35F8 — hookable via Hooks.InstallAt(NativeFunc_SetWaveTablePosition).</summary>
        public static global::System.IntPtr NativeFunc_SetWaveTablePosition => Memory.ModuleBase() + 0x5CF35F8;
        public void SetWaveTablePosition(float InPosition)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InPosition);
            CallRaw("SetWaveTablePosition", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF3888 — hookable via Hooks.InstallAt(NativeFunc_SetSustainPedalState).</summary>
        public static global::System.IntPtr NativeFunc_SetSustainPedalState => Memory.ModuleBase() + 0x5CF3888;
        public void SetSustainPedalState(bool InSustainPedalState)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InSustainPedalState?1:0));
            CallRaw("SetSustainPedalState", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF3354 — hookable via Hooks.InstallAt(NativeFunc_SetPosLfoType).</summary>
        public static global::System.IntPtr NativeFunc_SetPosLfoType => Memory.ModuleBase() + 0x5CF3354;
        public void SetPosLfoType(ESynthLFOType InLfoType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InLfoType);
            CallRaw("SetPosLfoType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF349C — hookable via Hooks.InstallAt(NativeFunc_SetPosLfoFrequency).</summary>
        public static global::System.IntPtr NativeFunc_SetPosLfoFrequency => Memory.ModuleBase() + 0x5CF349C;
        public void SetPosLfoFrequency(float InLfoFrequency)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InLfoFrequency);
            CallRaw("SetPosLfoFrequency", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF33F8 — hookable via Hooks.InstallAt(NativeFunc_SetPosLfoDepth).</summary>
        public static global::System.IntPtr NativeFunc_SetPosLfoDepth => Memory.ModuleBase() + 0x5CF33F8;
        public void SetPosLfoDepth(float InLfoDepth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InLfoDepth);
            CallRaw("SetPosLfoDepth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF25C0 — hookable via Hooks.InstallAt(NativeFunc_SetPositionEnvelopeSustainGain).</summary>
        public static global::System.IntPtr NativeFunc_SetPositionEnvelopeSustainGain => Memory.ModuleBase() + 0x5CF25C0;
        public void SetPositionEnvelopeSustainGain(float InSustainGain)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InSustainGain);
            CallRaw("SetPositionEnvelopeSustainGain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF251C — hookable via Hooks.InstallAt(NativeFunc_SetPositionEnvelopeReleaseTime).</summary>
        public static global::System.IntPtr NativeFunc_SetPositionEnvelopeReleaseTime => Memory.ModuleBase() + 0x5CF251C;
        public void SetPositionEnvelopeReleaseTime(float InReleaseTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InReleaseTimeMsec);
            CallRaw("SetPositionEnvelopeReleaseTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2470 — hookable via Hooks.InstallAt(NativeFunc_SetPositionEnvelopeInvert).</summary>
        public static global::System.IntPtr NativeFunc_SetPositionEnvelopeInvert => Memory.ModuleBase() + 0x5CF2470;
        public void SetPositionEnvelopeInvert(bool bInInvert)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInInvert?1:0));
            CallRaw("SetPositionEnvelopeInvert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2320 — hookable via Hooks.InstallAt(NativeFunc_SetPositionEnvelopeDepth).</summary>
        public static global::System.IntPtr NativeFunc_SetPositionEnvelopeDepth => Memory.ModuleBase() + 0x5CF2320;
        public void SetPositionEnvelopeDepth(float InDepth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDepth);
            CallRaw("SetPositionEnvelopeDepth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2664 — hookable via Hooks.InstallAt(NativeFunc_SetPositionEnvelopeDecayTime).</summary>
        public static global::System.IntPtr NativeFunc_SetPositionEnvelopeDecayTime => Memory.ModuleBase() + 0x5CF2664;
        public void SetPositionEnvelopeDecayTime(float InDecayTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDecayTimeMsec);
            CallRaw("SetPositionEnvelopeDecayTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF23C4 — hookable via Hooks.InstallAt(NativeFunc_SetPositionEnvelopeBiasInvert).</summary>
        public static global::System.IntPtr NativeFunc_SetPositionEnvelopeBiasInvert => Memory.ModuleBase() + 0x5CF23C4;
        public void SetPositionEnvelopeBiasInvert(bool bInBiasInvert)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInBiasInvert?1:0));
            CallRaw("SetPositionEnvelopeBiasInvert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF227C — hookable via Hooks.InstallAt(NativeFunc_SetPositionEnvelopeBiasDepth).</summary>
        public static global::System.IntPtr NativeFunc_SetPositionEnvelopeBiasDepth => Memory.ModuleBase() + 0x5CF227C;
        public void SetPositionEnvelopeBiasDepth(float InDepth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDepth);
            CallRaw("SetPositionEnvelopeBiasDepth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2708 — hookable via Hooks.InstallAt(NativeFunc_SetPositionEnvelopeAttackTime).</summary>
        public static global::System.IntPtr NativeFunc_SetPositionEnvelopeAttackTime => Memory.ModuleBase() + 0x5CF2708;
        public void SetPositionEnvelopeAttackTime(float InAttackTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InAttackTimeMsec);
            CallRaw("SetPositionEnvelopeAttackTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF320C — hookable via Hooks.InstallAt(NativeFunc_SetLowPassFilterResonance).</summary>
        public static global::System.IntPtr NativeFunc_SetLowPassFilterResonance => Memory.ModuleBase() + 0x5CF320C;
        public void SetLowPassFilterResonance(float InNewQ)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InNewQ);
            CallRaw("SetLowPassFilterResonance", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF32B0 — hookable via Hooks.InstallAt(NativeFunc_SetLowPassFilterFrequency).</summary>
        public static global::System.IntPtr NativeFunc_SetLowPassFilterFrequency => Memory.ModuleBase() + 0x5CF32B0;
        public void SetLowPassFilterFrequency(float InNewFrequency)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InNewFrequency);
            CallRaw("SetLowPassFilterFrequency", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF369C — hookable via Hooks.InstallAt(NativeFunc_SetFrequencyWithMidiNote).</summary>
        public static global::System.IntPtr NativeFunc_SetFrequencyWithMidiNote => Memory.ModuleBase() + 0x5CF369C;
        public void SetFrequencyWithMidiNote(float InMidiNote)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMidiNote);
            CallRaw("SetFrequencyWithMidiNote", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF3740 — hookable via Hooks.InstallAt(NativeFunc_SetFrequencyPitchBend).</summary>
        public static global::System.IntPtr NativeFunc_SetFrequencyPitchBend => Memory.ModuleBase() + 0x5CF3740;
        public void SetFrequencyPitchBend(float FrequencyOffsetCents)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, FrequencyOffsetCents);
            CallRaw("SetFrequencyPitchBend", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF37E4 — hookable via Hooks.InstallAt(NativeFunc_SetFrequency).</summary>
        public static global::System.IntPtr NativeFunc_SetFrequency => Memory.ModuleBase() + 0x5CF37E4;
        public void SetFrequency(float FrequencyHz)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, FrequencyHz);
            CallRaw("SetFrequency", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2AF0 — hookable via Hooks.InstallAt(NativeFunc_SetFilterEnvelopeSustainGain).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterEnvelopeSustainGain => Memory.ModuleBase() + 0x5CF2AF0;
        public void SetFilterEnvelopeSustainGain(float InSustainGain)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InSustainGain);
            CallRaw("SetFilterEnvelopeSustainGain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2A4C — hookable via Hooks.InstallAt(NativeFunc_SetFilterEnvelopeReleaseTime).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterEnvelopeReleaseTime => Memory.ModuleBase() + 0x5CF2A4C;
        public void SetFilterEnvelopeReleaseTime(float InReleaseTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InReleaseTimeMsec);
            CallRaw("SetFilterEnvelopeReleaseTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2B94 — hookable via Hooks.InstallAt(NativeFunc_SetFilterEnvelopenDecayTime).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterEnvelopenDecayTime => Memory.ModuleBase() + 0x5CF2B94;
        public void SetFilterEnvelopenDecayTime(float InDecayTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDecayTimeMsec);
            CallRaw("SetFilterEnvelopenDecayTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF29A0 — hookable via Hooks.InstallAt(NativeFunc_SetFilterEnvelopeInvert).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterEnvelopeInvert => Memory.ModuleBase() + 0x5CF29A0;
        public void SetFilterEnvelopeInvert(bool bInInvert)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInInvert?1:0));
            CallRaw("SetFilterEnvelopeInvert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2850 — hookable via Hooks.InstallAt(NativeFunc_SetFilterEnvelopeDepth).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterEnvelopeDepth => Memory.ModuleBase() + 0x5CF2850;
        public void SetFilterEnvelopeDepth(float InDepth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDepth);
            CallRaw("SetFilterEnvelopeDepth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF28F4 — hookable via Hooks.InstallAt(NativeFunc_SetFilterEnvelopeBiasInvert).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterEnvelopeBiasInvert => Memory.ModuleBase() + 0x5CF28F4;
        public void SetFilterEnvelopeBiasInvert(bool bInBiasInvert)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInBiasInvert?1:0));
            CallRaw("SetFilterEnvelopeBiasInvert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF27AC — hookable via Hooks.InstallAt(NativeFunc_SetFilterEnvelopeBiasDepth).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterEnvelopeBiasDepth => Memory.ModuleBase() + 0x5CF27AC;
        public void SetFilterEnvelopeBiasDepth(float InDepth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDepth);
            CallRaw("SetFilterEnvelopeBiasDepth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2C38 — hookable via Hooks.InstallAt(NativeFunc_SetFilterEnvelopeAttackTime).</summary>
        public static global::System.IntPtr NativeFunc_SetFilterEnvelopeAttackTime => Memory.ModuleBase() + 0x5CF2C38;
        public void SetFilterEnvelopeAttackTime(float InAttackTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InAttackTimeMsec);
            CallRaw("SetFilterEnvelopeAttackTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2114 — hookable via Hooks.InstallAt(NativeFunc_SetCurveValue).</summary>
        public static global::System.IntPtr NativeFunc_SetCurveValue => Memory.ModuleBase() + 0x5CF2114;
        public bool SetCurveValue(int TableIndex, int KeyframeIndex, float NewValue)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set(0x0, TableIndex);
            __pb.Set(0x4, KeyframeIndex);
            __pb.Set(0x8, NewValue);
            CallRaw("SetCurveValue", __pb.Bytes);
            return __pb.Get<byte>(0xC) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5CF1F2C — hookable via Hooks.InstallAt(NativeFunc_SetCurveTangent).</summary>
        public static global::System.IntPtr NativeFunc_SetCurveTangent => Memory.ModuleBase() + 0x5CF1F2C;
        public bool SetCurveTangent(int TableIndex, float InNewTangent)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, TableIndex);
            __pb.Set(0x4, InNewTangent);
            CallRaw("SetCurveTangent", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5CF2020 — hookable via Hooks.InstallAt(NativeFunc_SetCurveInterpolationType).</summary>
        public static global::System.IntPtr NativeFunc_SetCurveInterpolationType => Memory.ModuleBase() + 0x5CF2020;
        public bool SetCurveInterpolationType(CurveInterpolationType InterpolationType, int TableIndex)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<byte>(0x0, (byte)InterpolationType);
            __pb.Set(0x4, TableIndex);
            CallRaw("SetCurveInterpolationType", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5CF3020 — hookable via Hooks.InstallAt(NativeFunc_SetAmpEnvelopeSustainGain).</summary>
        public static global::System.IntPtr NativeFunc_SetAmpEnvelopeSustainGain => Memory.ModuleBase() + 0x5CF3020;
        public void SetAmpEnvelopeSustainGain(float InSustainGain)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InSustainGain);
            CallRaw("SetAmpEnvelopeSustainGain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2F7C — hookable via Hooks.InstallAt(NativeFunc_SetAmpEnvelopeReleaseTime).</summary>
        public static global::System.IntPtr NativeFunc_SetAmpEnvelopeReleaseTime => Memory.ModuleBase() + 0x5CF2F7C;
        public void SetAmpEnvelopeReleaseTime(float InReleaseTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InReleaseTimeMsec);
            CallRaw("SetAmpEnvelopeReleaseTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2ED0 — hookable via Hooks.InstallAt(NativeFunc_SetAmpEnvelopeInvert).</summary>
        public static global::System.IntPtr NativeFunc_SetAmpEnvelopeInvert => Memory.ModuleBase() + 0x5CF2ED0;
        public void SetAmpEnvelopeInvert(bool bInInvert)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInInvert?1:0));
            CallRaw("SetAmpEnvelopeInvert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2D80 — hookable via Hooks.InstallAt(NativeFunc_SetAmpEnvelopeDepth).</summary>
        public static global::System.IntPtr NativeFunc_SetAmpEnvelopeDepth => Memory.ModuleBase() + 0x5CF2D80;
        public void SetAmpEnvelopeDepth(float InDepth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDepth);
            CallRaw("SetAmpEnvelopeDepth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF30C4 — hookable via Hooks.InstallAt(NativeFunc_SetAmpEnvelopeDecayTime).</summary>
        public static global::System.IntPtr NativeFunc_SetAmpEnvelopeDecayTime => Memory.ModuleBase() + 0x5CF30C4;
        public void SetAmpEnvelopeDecayTime(float InDecayTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDecayTimeMsec);
            CallRaw("SetAmpEnvelopeDecayTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2E24 — hookable via Hooks.InstallAt(NativeFunc_SetAmpEnvelopeBiasInvert).</summary>
        public static global::System.IntPtr NativeFunc_SetAmpEnvelopeBiasInvert => Memory.ModuleBase() + 0x5CF2E24;
        public void SetAmpEnvelopeBiasInvert(bool bInBiasInvert)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInBiasInvert?1:0));
            CallRaw("SetAmpEnvelopeBiasInvert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF2CDC — hookable via Hooks.InstallAt(NativeFunc_SetAmpEnvelopeBiasDepth).</summary>
        public static global::System.IntPtr NativeFunc_SetAmpEnvelopeBiasDepth => Memory.ModuleBase() + 0x5CF2CDC;
        public void SetAmpEnvelopeBiasDepth(float InDepth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InDepth);
            CallRaw("SetAmpEnvelopeBiasDepth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF3168 — hookable via Hooks.InstallAt(NativeFunc_SetAmpEnvelopeAttackTime).</summary>
        public static global::System.IntPtr NativeFunc_SetAmpEnvelopeAttackTime => Memory.ModuleBase() + 0x5CF3168;
        public void SetAmpEnvelopeAttackTime(float InAttackTimeMsec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InAttackTimeMsec);
            CallRaw("SetAmpEnvelopeAttackTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF3554 — hookable via Hooks.InstallAt(NativeFunc_RefreshWaveTable).</summary>
        public static global::System.IntPtr NativeFunc_RefreshWaveTable => Memory.ModuleBase() + 0x5CF3554;
        public void RefreshWaveTable(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("RefreshWaveTable", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF3540 — hookable via Hooks.InstallAt(NativeFunc_RefreshAllWaveTables).</summary>
        public static global::System.IntPtr NativeFunc_RefreshAllWaveTables => Memory.ModuleBase() + 0x5CF3540;
        public void RefreshAllWaveTables()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RefreshAllWaveTables", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF39D8 — hookable via Hooks.InstallAt(NativeFunc_NoteOn).</summary>
        public static global::System.IntPtr NativeFunc_NoteOn => Memory.ModuleBase() + 0x5CF39D8;
        public void NoteOn(float InMidiNote, float InVelocity)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, InMidiNote);
            __pb.Set(0x4, InVelocity);
            CallRaw("NoteOn", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF3934 — hookable via Hooks.InstallAt(NativeFunc_NoteOff).</summary>
        public static global::System.IntPtr NativeFunc_NoteOff => Memory.ModuleBase() + 0x5CF3934;
        public void NoteOff(float InMidiNote)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMidiNote);
            CallRaw("NoteOff", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF3ABC — hookable via Hooks.InstallAt(NativeFunc_GetNumTableEntries).</summary>
        public static global::System.IntPtr NativeFunc_GetNumTableEntries => Memory.ModuleBase() + 0x5CF3ABC;
        public int GetNumTableEntries()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumTableEntries", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5CF2248 — hookable via Hooks.InstallAt(NativeFunc_GetMaxTableIndex).</summary>
        public static global::System.IntPtr NativeFunc_GetMaxTableIndex => Memory.ModuleBase() + 0x5CF2248;
        public int GetMaxTableIndex()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMaxTableIndex", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5CF1D88 — hookable via Hooks.InstallAt(NativeFunc_GetKeyFrameValuesForTable).</summary>
        public static global::System.IntPtr NativeFunc_GetKeyFrameValuesForTable => Memory.ModuleBase() + 0x5CF1D88;
        public global::System.IntPtr GetKeyFrameValuesForTable(float TableIndex)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, TableIndex);
            CallRaw("GetKeyFrameValuesForTable", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5CF1E80 — hookable via Hooks.InstallAt(NativeFunc_GetCurveTangent).</summary>
        public static global::System.IntPtr NativeFunc_GetCurveTangent => Memory.ModuleBase() + 0x5CF1E80;
        public float GetCurveTangent(int TableIndex)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, TableIndex);
            CallRaw("GetCurveTangent", __pb.Bytes);
            return __pb.Get<float>(0x4);
        }
    }

    public class SynthSamplePlayer : SynthComponent
    {
        public const string UeClassName = "SynthSamplePlayer";
        public SynthSamplePlayer(global::System.IntPtr ptr) : base(ptr) {}
        public static new SynthSamplePlayer FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SynthSamplePlayer(p);
        public static SynthSamplePlayer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SynthSamplePlayer(o.Pointer); }
        public static SynthSamplePlayer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SynthSamplePlayer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SynthSamplePlayer(a[i].Pointer); return r; }
        public SoundWave SoundWave { get { var __p = GetAt<global::System.IntPtr>(0x6D0); return __p==global::System.IntPtr.Zero?null:new SoundWave(__p); } set => SetAt(0x6D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr OnSampleLoaded => AddrOf(0x6D8); // 
        public global::System.IntPtr OnSamplePlaybackProgress => AddrOf(0x6E8); // 
        /// <summary>[Native] thunk RVA 0x5CF57A0 — hookable via Hooks.InstallAt(NativeFunc_SetSoundWave).</summary>
        public static global::System.IntPtr NativeFunc_SetSoundWave => Memory.ModuleBase() + 0x5CF57A0;
        public void SetSoundWave(SoundWave InSoundWave)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InSoundWave);
            CallRaw("SetSoundWave", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF5438 — hookable via Hooks.InstallAt(NativeFunc_SetScrubTimeWidth).</summary>
        public static global::System.IntPtr NativeFunc_SetScrubTimeWidth => Memory.ModuleBase() + 0x5CF5438;
        public void SetScrubTimeWidth(float InScrubTimeWidthSec)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InScrubTimeWidthSec);
            CallRaw("SetScrubTimeWidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF54DC — hookable via Hooks.InstallAt(NativeFunc_SetScrubMode).</summary>
        public static global::System.IntPtr NativeFunc_SetScrubMode => Memory.ModuleBase() + 0x5CF54DC;
        public void SetScrubMode(bool bScrubMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bScrubMode?1:0));
            CallRaw("SetScrubMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF56BC — hookable via Hooks.InstallAt(NativeFunc_SetPitch).</summary>
        public static global::System.IntPtr NativeFunc_SetPitch => Memory.ModuleBase() + 0x5CF56BC;
        public void SetPitch(float InPitch, float TimeSec)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, InPitch);
            __pb.Set(0x4, TimeSec);
            CallRaw("SetPitch", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF5588 — hookable via Hooks.InstallAt(NativeFunc_SeekToTime).</summary>
        public static global::System.IntPtr NativeFunc_SeekToTime => Memory.ModuleBase() + 0x5CF5588;
        public void SeekToTime(float TimeSec, ESamplePlayerSeekType SeekType, bool bWrap)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set(0x0, TimeSec);
            __pb.Set<byte>(0x4, (byte)SeekType);
            __pb.Set<byte>(0x5, (byte)(bWrap?1:0));
            CallRaw("SeekToTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF5364 — hookable via Hooks.InstallAt(NativeFunc_IsLoaded).</summary>
        public static global::System.IntPtr NativeFunc_IsLoaded => Memory.ModuleBase() + 0x5CF5364;
        public bool IsLoaded()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsLoaded", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5CF5404 — hookable via Hooks.InstallAt(NativeFunc_GetSampleDuration).</summary>
        public static global::System.IntPtr NativeFunc_GetSampleDuration => Memory.ModuleBase() + 0x5CF5404;
        public float GetSampleDuration()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetSampleDuration", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5CF53D0 — hookable via Hooks.InstallAt(NativeFunc_GetCurrentPlaybackProgressTime).</summary>
        public static global::System.IntPtr NativeFunc_GetCurrentPlaybackProgressTime => Memory.ModuleBase() + 0x5CF53D0;
        public float GetCurrentPlaybackProgressTime()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetCurrentPlaybackProgressTime", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5CF539C — hookable via Hooks.InstallAt(NativeFunc_GetCurrentPlaybackProgressPercent).</summary>
        public static global::System.IntPtr NativeFunc_GetCurrentPlaybackProgressPercent => Memory.ModuleBase() + 0x5CF539C;
        public float GetCurrentPlaybackProgressPercent()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetCurrentPlaybackProgressPercent", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
    }

    public class SynthKnob : Widget
    {
        public const string UeClassName = "SynthKnob";
        public SynthKnob(global::System.IntPtr ptr) : base(ptr) {}
        public static new SynthKnob FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SynthKnob(p);
        public static SynthKnob FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SynthKnob(o.Pointer); }
        public static SynthKnob[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SynthKnob[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SynthKnob(a[i].Pointer); return r; }
        public float Value { get => GetAt<float>(0x108); set => SetAt(0x108, value); }
        public float StepSize { get => GetAt<float>(0x10C); set => SetAt(0x10C, value); }
        public float MouseSpeed { get => GetAt<float>(0x110); set => SetAt(0x110, value); }
        public float MouseFineTuneSpeed { get => GetAt<float>(0x114); set => SetAt(0x114, value); }
        public bool ShowTooltipInfo { get => Native.GetPropBool(Pointer, "ShowTooltipInfo"); set => Native.SetPropBool(Pointer, "ShowTooltipInfo", value); }
        public global::System.IntPtr ParameterName => AddrOf(0x120); // 
        public global::System.IntPtr ParameterUnits => AddrOf(0x138); // 
        public global::System.IntPtr ValueDelegate => AddrOf(0x150); // 
        public SynthKnobStyle WidgetStyle => new SynthKnobStyle(AddrOf(0x160));
        public bool Locked { get => Native.GetPropBool(Pointer, "Locked"); set => Native.SetPropBool(Pointer, "Locked", value); }
        public bool IsFocusable { get => Native.GetPropBool(Pointer, "IsFocusable"); set => Native.SetPropBool(Pointer, "IsFocusable", value); }
        public global::System.IntPtr OnMouseCaptureBegin => AddrOf(0x3A0); // 
        public global::System.IntPtr OnMouseCaptureEnd => AddrOf(0x3B0); // 
        public global::System.IntPtr OnControllerCaptureBegin => AddrOf(0x3C0); // 
        public global::System.IntPtr OnControllerCaptureEnd => AddrOf(0x3D0); // 
        public global::System.IntPtr OnValueChanged => AddrOf(0x3E0); // 
        /// <summary>[Native] thunk RVA 0x5CF661C — hookable via Hooks.InstallAt(NativeFunc_SetValue).</summary>
        public static global::System.IntPtr NativeFunc_SetValue => Memory.ModuleBase() + 0x5CF661C;
        public void SetValue(float InValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InValue);
            CallRaw("SetValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF64CC — hookable via Hooks.InstallAt(NativeFunc_SetStepSize).</summary>
        public static global::System.IntPtr NativeFunc_SetStepSize => Memory.ModuleBase() + 0x5CF64CC;
        public void SetStepSize(float InValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InValue);
            CallRaw("SetStepSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF6570 — hookable via Hooks.InstallAt(NativeFunc_SetLocked).</summary>
        public static global::System.IntPtr NativeFunc_SetLocked => Memory.ModuleBase() + 0x5CF6570;
        public void SetLocked(bool InValue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InValue?1:0));
            CallRaw("SetLocked", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5CF66C0 — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static global::System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x5CF66C0;
        public float GetValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
    }

}
