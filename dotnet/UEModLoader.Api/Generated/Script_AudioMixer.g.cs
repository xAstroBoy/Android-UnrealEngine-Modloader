// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AudioMixer
using System;

namespace UEModLoader.Game
{
    public enum EAudioSpectrumType
    {
        MagnitudeSpectrum = 0,
        PowerSpectrum = 1,
    }

    public enum EFFTWindowType
    {
        None = 0,
        Hamming = 1,
        Hann = 2,
        Blackman = 3,
    }

    public enum EFFTPeakInterpolationMethod
    {
        NearestNeighbor = 0,
        Linear = 1,
        Quadratic = 2,
    }

    public enum EFFTSize
    {
        DefaultSize = 0,
        Min = 1,
        Small = 2,
        Medium = 3,
        Large = 4,
        Max = 5,
    }

    public enum ESubmixEffectDynamicsChannelLinkMode
    {
        Disabled = 0,
        Average = 1,
        Peak = 2,
        Count = 3,
    }

    public enum ESubmixEffectDynamicsPeakMode
    {
        MeanSquared = 0,
        RootMeanSquared = 1,
        Peak = 2,
        Count = 3,
    }

    public enum ESubmixEffectDynamicsProcessorType
    {
        Compressor = 0,
        Limiter = 1,
        Expander = 2,
        Gate = 3,
        Count = 4,
    }

    public class SubmixEffectDynamicsProcessorSettings : StructProxy
    {
        public SubmixEffectDynamicsProcessorSettings(System.IntPtr ptr) : base(ptr) {}
        public ESubmixEffectDynamicsProcessorType DynamicsProcessorType { get => (ESubmixEffectDynamicsProcessorType)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public ESubmixEffectDynamicsPeakMode PeakMode { get => (ESubmixEffectDynamicsPeakMode)GetAt<byte>(0x1); set => SetAt(0x1, (byte)value); }
        public ESubmixEffectDynamicsChannelLinkMode LinkMode { get => (ESubmixEffectDynamicsChannelLinkMode)GetAt<byte>(0x2); set => SetAt(0x2, (byte)value); }
        public float InputGainDb { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float ThresholdDb { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float Ratio { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float KneeBandwidthDb { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public float LookAheadMsec { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public float AttackTimeMsec { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
        public float ReleaseTimeMsec { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public SoundSubmix ExternalSubmix { get { var __p = GetAt<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new SoundSubmix(__p); } set => SetAt(0x20, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bChannelLinked { get => (GetAt<byte>(0x28) & 0x1) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bAnalogMode { get => (GetAt<byte>(0x28) & 0x2) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bKeyAudition { get => (GetAt<byte>(0x28) & 0x4) != 0; set { var __b = GetAt<byte>(0x28); SetAt(0x28, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public float KeyGainDb { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float OutputGainDb { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public SubmixEffectDynamicProcessorFilterSettings KeyHighshelf => new SubmixEffectDynamicProcessorFilterSettings(AddrOf(0x34));
        public SubmixEffectDynamicProcessorFilterSettings KeyLowshelf => new SubmixEffectDynamicProcessorFilterSettings(AddrOf(0x40));
    }

    public class SubmixEffectDynamicProcessorFilterSettings : StructProxy
    {
        public SubmixEffectDynamicProcessorFilterSettings(System.IntPtr ptr) : base(ptr) {}
        public bool bEnabled { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public float Cutoff { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float GainDb { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class SubmixEffectSubmixEQSettings : StructProxy
    {
        public SubmixEffectSubmixEQSettings(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> EQBands => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class SubmixEffectEQBand : StructProxy
    {
        public SubmixEffectEQBand(System.IntPtr ptr) : base(ptr) {}
        public float Frequency { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Bandwidth { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float GainDb { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public bool bEnabled { get => (GetAt<byte>(0xC) & 0x1) != 0; set { var __b = GetAt<byte>(0xC); SetAt(0xC, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
    }

    public class SubmixEffectReverbSettings : StructProxy
    {
        public SubmixEffectReverbSettings(System.IntPtr ptr) : base(ptr) {}
        public float Density { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Diffusion { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Gain { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float GainHF { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float DecayTime { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public float DecayHFRatio { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public float ReflectionsGain { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
        public float ReflectionsDelay { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public float LateGain { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public float LateDelay { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public float AirAbsorptionGainHF { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public float WetLevel { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float DryLevel { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
    }

    public class SubmixEffectReverbFastSettings : StructProxy
    {
        public SubmixEffectReverbFastSettings(System.IntPtr ptr) : base(ptr) {}
        public bool bBypass { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float Density { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Diffusion { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float Gain { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float GainHF { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public float DecayTime { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public float DecayHFRatio { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
        public float ReflectionsGain { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public float ReflectionsDelay { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public float LateGain { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public float LateDelay { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public float AirAbsorptionGainHF { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float WetLevel { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float DryLevel { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
    }

    public class SynthComponent : SceneComponent
    {
        public const string UeClassName = "SynthComponent";
        public SynthComponent(System.IntPtr ptr) : base(ptr) {}
        public static new SynthComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SynthComponent(p);
        public static SynthComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SynthComponent(o.Pointer); }
        public static SynthComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SynthComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SynthComponent(a[i].Pointer); return r; }
        public bool bAutoDestroy { get => Native.GetPropBool(Pointer, "bAutoDestroy"); set => Native.SetPropBool(Pointer, "bAutoDestroy", value); }
        public bool bStopWhenOwnerDestroyed { get => Native.GetPropBool(Pointer, "bStopWhenOwnerDestroyed"); set => Native.SetPropBool(Pointer, "bStopWhenOwnerDestroyed", value); }
        public bool bAllowSpatialization { get => Native.GetPropBool(Pointer, "bAllowSpatialization"); set => Native.SetPropBool(Pointer, "bAllowSpatialization", value); }
        public bool bOverrideAttenuation { get => Native.GetPropBool(Pointer, "bOverrideAttenuation"); set => Native.SetPropBool(Pointer, "bOverrideAttenuation", value); }
        public bool bOutputToBusOnly { get => Native.GetPropBool(Pointer, "bOutputToBusOnly"); set => Native.SetPropBool(Pointer, "bOutputToBusOnly", value); }
        public SoundAttenuation AttenuationSettings { get { var __p = GetAt<System.IntPtr>(0x1F8); return __p==System.IntPtr.Zero?null:new SoundAttenuation(__p); } set => SetAt(0x1F8, value?.Pointer ?? System.IntPtr.Zero); }
        public SoundAttenuationSettings AttenuationOverrides => new SoundAttenuationSettings(AddrOf(0x200));
        public SoundConcurrency ConcurrencySettings { get { var __p = GetAt<System.IntPtr>(0x5A0); return __p==System.IntPtr.Zero?null:new SoundConcurrency(__p); } set => SetAt(0x5A0, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr ConcurrencySet => AddrOf(0x5A8); // 
        public SoundClass SoundClass { get { var __p = GetAt<System.IntPtr>(0x5F8); return __p==System.IntPtr.Zero?null:new SoundClass(__p); } set => SetAt(0x5F8, value?.Pointer ?? System.IntPtr.Zero); }
        public SoundEffectSourcePresetChain SourceEffectChain { get { var __p = GetAt<System.IntPtr>(0x600); return __p==System.IntPtr.Zero?null:new SoundEffectSourcePresetChain(__p); } set => SetAt(0x600, value?.Pointer ?? System.IntPtr.Zero); }
        public SoundSubmixBase SoundSubmix { get { var __p = GetAt<System.IntPtr>(0x608); return __p==System.IntPtr.Zero?null:new SoundSubmixBase(__p); } set => SetAt(0x608, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> SoundSubmixSends => new TArray<System.IntPtr>(AddrOf(0x610)); // TArray<struct>
        public TArray<System.IntPtr> BusSends => new TArray<System.IntPtr>(AddrOf(0x620)); // TArray<struct>
        public SoundModulation Modulation => new SoundModulation(AddrOf(0x630));
        public TArray<System.IntPtr> PreEffectBusSends => new TArray<System.IntPtr>(AddrOf(0x640)); // TArray<struct>
        public bool bIsUISound { get => Native.GetPropBool(Pointer, "bIsUISound"); set => Native.SetPropBool(Pointer, "bIsUISound", value); }
        public bool bIsPreviewSound { get => Native.GetPropBool(Pointer, "bIsPreviewSound"); set => Native.SetPropBool(Pointer, "bIsPreviewSound", value); }
        public int EnvelopeFollowerAttackTime { get => GetAt<int>(0x654); set => SetAt(0x654, value); }
        public int EnvelopeFollowerReleaseTime { get => GetAt<int>(0x658); set => SetAt(0x658, value); }
        public System.IntPtr OnAudioEnvelopeValue => AddrOf(0x660); // 
        public SynthSound Synth { get { var __p = GetAt<System.IntPtr>(0x690); return __p==System.IntPtr.Zero?null:new SynthSound(__p); } set => SetAt(0x690, value?.Pointer ?? System.IntPtr.Zero); }
        public AudioComponent AudioComponent { get { var __p = GetAt<System.IntPtr>(0x698); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x698, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x7F4EE50 — hookable via Hooks.InstallAt(NativeFunc_Stop).</summary>
        public static System.IntPtr NativeFunc_Stop => Memory.ModuleBase() + 0x7F4EE50;
        public void Stop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Stop", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F4EE64 — hookable via Hooks.InstallAt(NativeFunc_Start).</summary>
        public static System.IntPtr NativeFunc_Start => Memory.ModuleBase() + 0x7F4EE64;
        public void Start()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Start", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F4ED74 — hookable via Hooks.InstallAt(NativeFunc_SetVolumeMultiplier).</summary>
        public static System.IntPtr NativeFunc_SetVolumeMultiplier => Memory.ModuleBase() + 0x7F4ED74;
        public void SetVolumeMultiplier(float VolumeMultiplier)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, VolumeMultiplier);
            CallRaw("SetVolumeMultiplier", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F4EC8C — hookable via Hooks.InstallAt(NativeFunc_SetSubmixSend).</summary>
        public static System.IntPtr NativeFunc_SetSubmixSend => Memory.ModuleBase() + 0x7F4EC8C;
        public void SetSubmixSend(SoundSubmixBase Submix, float SendLevel)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, Submix);
            __pb.Set(0x8, SendLevel);
            CallRaw("SetSubmixSend", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F4EE18 — hookable via Hooks.InstallAt(NativeFunc_IsPlaying).</summary>
        public static System.IntPtr NativeFunc_IsPlaying => Memory.ModuleBase() + 0x7F4EE18;
        public bool IsPlaying()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPlaying", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class AudioGenerator : Object
    {
        public const string UeClassName = "AudioGenerator";
        public AudioGenerator(System.IntPtr ptr) : base(ptr) {}
        public static new AudioGenerator FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AudioGenerator(p);
        public static AudioGenerator FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AudioGenerator(o.Pointer); }
        public static AudioGenerator[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AudioGenerator[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AudioGenerator(a[i].Pointer); return r; }
    }

    public class AudioMixerBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "AudioMixerBlueprintLibrary";
        public AudioMixerBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new AudioMixerBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AudioMixerBlueprintLibrary(p);
        public static AudioMixerBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AudioMixerBlueprintLibrary(o.Pointer); }
        public static AudioMixerBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AudioMixerBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AudioMixerBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7F46424 — hookable via Hooks.InstallAt(NativeFunc_TrimAudioCache).</summary>
        public static System.IntPtr NativeFunc_TrimAudioCache => Memory.ModuleBase() + 0x7F46424;
        public float TrimAudioCache(float InMegabytesToFree)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, InMegabytesToFree);
            CallRaw("TrimAudioCache", __pb.Bytes);
            return __pb.Get<float>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x7F47240 — hookable via Hooks.InstallAt(NativeFunc_StopRecordingOutput).</summary>
        public static System.IntPtr NativeFunc_StopRecordingOutput => Memory.ModuleBase() + 0x7F47240;
        public SoundWave StopRecordingOutput(Object WorldContextObject, EAudioRecordingExportType ExportType, System.IntPtr Name, System.IntPtr Path, SoundSubmix SubmixToRecord, SoundWave ExistingSoundWaveToOverwrite)
        {
            var __pb = new ParamBuffer(72);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<byte>(0x8, (byte)ExportType);
            __pb.Set<System.IntPtr>(0x10, Name);
            __pb.Set<System.IntPtr>(0x20, Path);
            __pb.SetObject(0x30, SubmixToRecord);
            __pb.SetObject(0x38, ExistingSoundWaveToOverwrite);
            CallRaw("StopRecordingOutput", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x40); return __p==System.IntPtr.Zero?null:new SoundWave(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7F46DE0 — hookable via Hooks.InstallAt(NativeFunc_StopAnalyzingOutput).</summary>
        public static System.IntPtr NativeFunc_StopAnalyzingOutput => Memory.ModuleBase() + 0x7F46DE0;
        public void StopAnalyzingOutput(Object WorldContextObject, SoundSubmix SubmixToStopAnalyzing)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SubmixToStopAnalyzing);
            CallRaw("StopAnalyzingOutput", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F474A4 — hookable via Hooks.InstallAt(NativeFunc_StartRecordingOutput).</summary>
        public static System.IntPtr NativeFunc_StartRecordingOutput => Memory.ModuleBase() + 0x7F474A4;
        public void StartRecordingOutput(Object WorldContextObject, float ExpectedDuration, SoundSubmix SubmixToRecord)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set(0x8, ExpectedDuration);
            __pb.SetObject(0x10, SubmixToRecord);
            CallRaw("StartRecordingOutput", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F46EB4 — hookable via Hooks.InstallAt(NativeFunc_StartAnalyzingOutput).</summary>
        public static System.IntPtr NativeFunc_StartAnalyzingOutput => Memory.ModuleBase() + 0x7F46EB4;
        public void StartAnalyzingOutput(Object WorldContextObject, SoundSubmix SubmixToAnalyze, EFFTSize FFTSize, EFFTPeakInterpolationMethod InterpolationMethod, EFFTWindowType WindowType, float HopSize)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SubmixToAnalyze);
            __pb.Set<byte>(0x10, (byte)FFTSize);
            __pb.Set<byte>(0x11, (byte)InterpolationMethod);
            __pb.Set<byte>(0x12, (byte)WindowType);
            __pb.Set(0x14, HopSize);
            CallRaw("StartAnalyzingOutput", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F46720 — hookable via Hooks.InstallAt(NativeFunc_SetBypassSourceEffectChainEntry).</summary>
        public static System.IntPtr NativeFunc_SetBypassSourceEffectChainEntry => Memory.ModuleBase() + 0x7F46720;
        public void SetBypassSourceEffectChainEntry(Object WorldContextObject, SoundEffectSourcePresetChain PresetChain, int EntryIndex, bool bBypassed)
        {
            var __pb = new ParamBuffer(21);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PresetChain);
            __pb.Set(0x10, EntryIndex);
            __pb.Set<byte>(0x14, (byte)(bBypassed?1:0));
            CallRaw("SetBypassSourceEffectChainEntry", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F47098 — hookable via Hooks.InstallAt(NativeFunc_ResumeRecordingOutput).</summary>
        public static System.IntPtr NativeFunc_ResumeRecordingOutput => Memory.ModuleBase() + 0x7F47098;
        public void ResumeRecordingOutput(Object WorldContextObject, SoundSubmix SubmixToPause)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SubmixToPause);
            CallRaw("ResumeRecordingOutput", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F47694 — hookable via Hooks.InstallAt(NativeFunc_ReplaceSoundEffectSubmix).</summary>
        public static System.IntPtr NativeFunc_ReplaceSoundEffectSubmix => Memory.ModuleBase() + 0x7F47694;
        public void ReplaceSoundEffectSubmix(Object WorldContextObject, SoundSubmix InSoundSubmix, int SubmixChainIndex, SoundEffectSubmixPreset SubmixEffectPreset)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, InSoundSubmix);
            __pb.Set(0x10, SubmixChainIndex);
            __pb.SetObject(0x18, SubmixEffectPreset);
            CallRaw("ReplaceSoundEffectSubmix", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F477F0 — hookable via Hooks.InstallAt(NativeFunc_RemoveSubmixEffectPresetAtIndex).</summary>
        public static System.IntPtr NativeFunc_RemoveSubmixEffectPresetAtIndex => Memory.ModuleBase() + 0x7F477F0;
        public void RemoveSubmixEffectPresetAtIndex(Object WorldContextObject, SoundSubmix SoundSubmix, int SubmixChainIndex)
        {
            var __pb = new ParamBuffer(20);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SoundSubmix);
            __pb.Set(0x10, SubmixChainIndex);
            CallRaw("RemoveSubmixEffectPresetAtIndex", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F47908 — hookable via Hooks.InstallAt(NativeFunc_RemoveSubmixEffectPreset).</summary>
        public static System.IntPtr NativeFunc_RemoveSubmixEffectPreset => Memory.ModuleBase() + 0x7F47908;
        public void RemoveSubmixEffectPreset(Object WorldContextObject, SoundSubmix SoundSubmix, SoundEffectSubmixPreset SubmixEffectPreset)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SoundSubmix);
            __pb.SetObject(0x10, SubmixEffectPreset);
            CallRaw("RemoveSubmixEffectPreset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F46880 — hookable via Hooks.InstallAt(NativeFunc_RemoveSourceEffectFromPresetChain).</summary>
        public static System.IntPtr NativeFunc_RemoveSourceEffectFromPresetChain => Memory.ModuleBase() + 0x7F46880;
        public void RemoveSourceEffectFromPresetChain(Object WorldContextObject, SoundEffectSourcePresetChain PresetChain, int EntryIndex)
        {
            var __pb = new ParamBuffer(20);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PresetChain);
            __pb.Set(0x10, EntryIndex);
            CallRaw("RemoveSourceEffectFromPresetChain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F47BDC — hookable via Hooks.InstallAt(NativeFunc_RemoveMasterSubmixEffect).</summary>
        public static System.IntPtr NativeFunc_RemoveMasterSubmixEffect => Memory.ModuleBase() + 0x7F47BDC;
        public void RemoveMasterSubmixEffect(Object WorldContextObject, SoundEffectSubmixPreset SubmixEffectPreset)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SubmixEffectPreset);
            CallRaw("RemoveMasterSubmixEffect", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F4655C — hookable via Hooks.InstallAt(NativeFunc_PrimeSoundForPlayback).</summary>
        public static System.IntPtr NativeFunc_PrimeSoundForPlayback => Memory.ModuleBase() + 0x7F4655C;
        public void PrimeSoundForPlayback(SoundWave SoundWave, System.IntPtr OnLoadCompletion)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, SoundWave);
            __pb.Set<System.IntPtr>(0x8, OnLoadCompletion);
            CallRaw("PrimeSoundForPlayback", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F464C8 — hookable via Hooks.InstallAt(NativeFunc_PrimeSoundCueForPlayback).</summary>
        public static System.IntPtr NativeFunc_PrimeSoundCueForPlayback => Memory.ModuleBase() + 0x7F464C8;
        public void PrimeSoundCueForPlayback(SoundCue SoundCue)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, SoundCue);
            CallRaw("PrimeSoundCueForPlayback", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F4716C — hookable via Hooks.InstallAt(NativeFunc_PauseRecordingOutput).</summary>
        public static System.IntPtr NativeFunc_PauseRecordingOutput => Memory.ModuleBase() + 0x7F4716C;
        public void PauseRecordingOutput(Object WorldContextObject, SoundSubmix SubmixToPause)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SubmixToPause);
            CallRaw("PauseRecordingOutput", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F46AA8 — hookable via Hooks.InstallAt(NativeFunc_GetPhaseForFrequencies).</summary>
        public static System.IntPtr NativeFunc_GetPhaseForFrequencies => Memory.ModuleBase() + 0x7F46AA8;
        public void GetPhaseForFrequencies(Object WorldContextObject, System.IntPtr Frequencies, System.IntPtr Phases, SoundSubmix SubmixToAnalyze)
        {
            var __pb = new ParamBuffer(48);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, Frequencies);
            __pb.Set<System.IntPtr>(0x18, Phases);
            __pb.SetObject(0x28, SubmixToAnalyze);
            CallRaw("GetPhaseForFrequencies", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F4663C — hookable via Hooks.InstallAt(NativeFunc_GetNumberOfEntriesInSourceEffectChain).</summary>
        public static System.IntPtr NativeFunc_GetNumberOfEntriesInSourceEffectChain => Memory.ModuleBase() + 0x7F4663C;
        public int GetNumberOfEntriesInSourceEffectChain(Object WorldContextObject, SoundEffectSourcePresetChain PresetChain)
        {
            var __pb = new ParamBuffer(20);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PresetChain);
            CallRaw("GetNumberOfEntriesInSourceEffectChain", __pb.Bytes);
            return __pb.Get<int>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x7F46C44 — hookable via Hooks.InstallAt(NativeFunc_GetMagnitudeForFrequencies).</summary>
        public static System.IntPtr NativeFunc_GetMagnitudeForFrequencies => Memory.ModuleBase() + 0x7F46C44;
        public void GetMagnitudeForFrequencies(Object WorldContextObject, System.IntPtr Frequencies, System.IntPtr Magnitudes, SoundSubmix SubmixToAnalyze)
        {
            var __pb = new ParamBuffer(48);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, Frequencies);
            __pb.Set<System.IntPtr>(0x18, Magnitudes);
            __pb.SetObject(0x28, SubmixToAnalyze);
            CallRaw("GetMagnitudeForFrequencies", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F475C0 — hookable via Hooks.InstallAt(NativeFunc_ClearSubmixEffects).</summary>
        public static System.IntPtr NativeFunc_ClearSubmixEffects => Memory.ModuleBase() + 0x7F475C0;
        public void ClearSubmixEffects(Object WorldContextObject, SoundSubmix SoundSubmix)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SoundSubmix);
            CallRaw("ClearSubmixEffects", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F47B48 — hookable via Hooks.InstallAt(NativeFunc_ClearMasterSubmixEffects).</summary>
        public static System.IntPtr NativeFunc_ClearMasterSubmixEffects => Memory.ModuleBase() + 0x7F47B48;
        public void ClearMasterSubmixEffects(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("ClearMasterSubmixEffects", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F47A20 — hookable via Hooks.InstallAt(NativeFunc_AddSubmixEffect).</summary>
        public static System.IntPtr NativeFunc_AddSubmixEffect => Memory.ModuleBase() + 0x7F47A20;
        public int AddSubmixEffect(Object WorldContextObject, SoundSubmix SoundSubmix, SoundEffectSubmixPreset SubmixEffectPreset)
        {
            var __pb = new ParamBuffer(28);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SoundSubmix);
            __pb.SetObject(0x10, SubmixEffectPreset);
            CallRaw("AddSubmixEffect", __pb.Bytes);
            return __pb.Get<int>(0x18);
        }
        /// <summary>[Native] thunk RVA 0x7F46998 — hookable via Hooks.InstallAt(NativeFunc_AddSourceEffectToPresetChain).</summary>
        public static System.IntPtr NativeFunc_AddSourceEffectToPresetChain => Memory.ModuleBase() + 0x7F46998;
        public void AddSourceEffectToPresetChain(Object WorldContextObject, SoundEffectSourcePresetChain PresetChain, SourceEffectChainEntry Entry)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PresetChain);
            __pb.Set<System.IntPtr>(0x10, Entry);
            CallRaw("AddSourceEffectToPresetChain", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F47CB0 — hookable via Hooks.InstallAt(NativeFunc_AddMasterSubmixEffect).</summary>
        public static System.IntPtr NativeFunc_AddMasterSubmixEffect => Memory.ModuleBase() + 0x7F47CB0;
        public void AddMasterSubmixEffect(Object WorldContextObject, SoundEffectSubmixPreset SubmixEffectPreset)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, SubmixEffectPreset);
            CallRaw("AddMasterSubmixEffect", __pb.Bytes);
        }
    }

    public class SubmixEffectDynamicsProcessorPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectDynamicsProcessorPreset";
        public SubmixEffectDynamicsProcessorPreset(System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectDynamicsProcessorPreset FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SubmixEffectDynamicsProcessorPreset(p);
        public static SubmixEffectDynamicsProcessorPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectDynamicsProcessorPreset(o.Pointer); }
        public static SubmixEffectDynamicsProcessorPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectDynamicsProcessorPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectDynamicsProcessorPreset(a[i].Pointer); return r; }
        public SubmixEffectDynamicsProcessorSettings Settings => new SubmixEffectDynamicsProcessorSettings(AddrOf(0xB8));
        /// <summary>[Native] thunk RVA 0x7F492DC — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x7F492DC;
        public void SetSettings(SubmixEffectDynamicsProcessorSettings Settings)
        {
            var __pb = new ParamBuffer(80);
            __pb.Set<System.IntPtr>(0x0, Settings);
            CallRaw("SetSettings", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F493EC — hookable via Hooks.InstallAt(NativeFunc_SetExternalSubmix).</summary>
        public static System.IntPtr NativeFunc_SetExternalSubmix => Memory.ModuleBase() + 0x7F493EC;
        public void SetExternalSubmix(SoundSubmix Submix)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Submix);
            CallRaw("SetExternalSubmix", __pb.Bytes);
        }
    }

    public class SubmixEffectSubmixEQPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectSubmixEQPreset";
        public SubmixEffectSubmixEQPreset(System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectSubmixEQPreset FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SubmixEffectSubmixEQPreset(p);
        public static SubmixEffectSubmixEQPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectSubmixEQPreset(o.Pointer); }
        public static SubmixEffectSubmixEQPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectSubmixEQPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectSubmixEQPreset(a[i].Pointer); return r; }
        public SubmixEffectSubmixEQSettings Settings => new SubmixEffectSubmixEQSettings(AddrOf(0x78));
        /// <summary>[Native] thunk RVA 0x7F4AC18 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x7F4AC18;
        public void SetSettings(SubmixEffectSubmixEQSettings InSettings)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SubmixEffectReverbPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectReverbPreset";
        public SubmixEffectReverbPreset(System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectReverbPreset FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SubmixEffectReverbPreset(p);
        public static SubmixEffectReverbPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectReverbPreset(o.Pointer); }
        public static SubmixEffectReverbPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectReverbPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectReverbPreset(a[i].Pointer); return r; }
        public SubmixEffectReverbSettings Settings => new SubmixEffectReverbSettings(AddrOf(0x98));
        /// <summary>[Native] thunk RVA 0x7F4C0D4 — hookable via Hooks.InstallAt(NativeFunc_SetSettingsWithReverbEffect).</summary>
        public static System.IntPtr NativeFunc_SetSettingsWithReverbEffect => Memory.ModuleBase() + 0x7F4C0D4;
        public void SetSettingsWithReverbEffect(ReverbEffect InReverbEffect, float WetLevel, float DryLevel)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, InReverbEffect);
            __pb.Set(0x8, WetLevel);
            __pb.Set(0xC, DryLevel);
            CallRaw("SetSettingsWithReverbEffect", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F4C1FC — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x7F4C1FC;
        public void SetSettings(SubmixEffectReverbSettings InSettings)
        {
            var __pb = new ParamBuffer(52);
            __pb.Set<System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SubmixEffectReverbFastPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectReverbFastPreset";
        public SubmixEffectReverbFastPreset(System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectReverbFastPreset FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SubmixEffectReverbFastPreset(p);
        public static SubmixEffectReverbFastPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectReverbFastPreset(o.Pointer); }
        public static SubmixEffectReverbFastPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectReverbFastPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectReverbFastPreset(a[i].Pointer); return r; }
        public SubmixEffectReverbFastSettings Settings => new SubmixEffectReverbFastSettings(AddrOf(0x9C));
        /// <summary>[Native] thunk RVA 0x7F4D52C — hookable via Hooks.InstallAt(NativeFunc_SetSettingsWithReverbEffect).</summary>
        public static System.IntPtr NativeFunc_SetSettingsWithReverbEffect => Memory.ModuleBase() + 0x7F4D52C;
        public void SetSettingsWithReverbEffect(ReverbEffect InReverbEffect, float WetLevel, float DryLevel)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, InReverbEffect);
            __pb.Set(0x8, WetLevel);
            __pb.Set(0xC, DryLevel);
            CallRaw("SetSettingsWithReverbEffect", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7F4D654 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x7F4D654;
        public void SetSettings(SubmixEffectReverbFastSettings InSettings)
        {
            var __pb = new ParamBuffer(56);
            __pb.Set<System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class SynthSound : SoundWaveProcedural
    {
        public const string UeClassName = "SynthSound";
        public SynthSound(System.IntPtr ptr) : base(ptr) {}
        public static new SynthSound FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SynthSound(p);
        public static SynthSound FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SynthSound(o.Pointer); }
        public static SynthSound[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SynthSound[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SynthSound(a[i].Pointer); return r; }
        public SynthComponent OwningSynthComponent { get { var __p = GetAt<System.IntPtr>(0x360); return __p==System.IntPtr.Zero?null:new SynthComponent(__p); } set => SetAt(0x360, value?.Pointer ?? System.IntPtr.Zero); }
    }

}
