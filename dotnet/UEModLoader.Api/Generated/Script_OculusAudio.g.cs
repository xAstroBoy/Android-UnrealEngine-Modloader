// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/OculusAudio
using System;

namespace UEModLoader.Game
{
    public enum EOculusAudioAmbisonicsMode
    {
        SphericalHarmonics = 0,
        VirtualSpeakers = 1,
    }

    public enum EOculusAudioMaterial
    {
        ACOUSTICTILE = 0,
        BRICK = 1,
        BRICKPAINTED = 2,
        CARPET = 3,
        CARPETHEAVY = 4,
        CARPETHEAVYPADDED = 5,
        CERAMICTILE = 6,
        CONCRETE = 7,
        CONCRETEROUGH = 8,
        CONCRETEBLOCK = 9,
        CONCRETEBLOCKPAINTED = 10,
        CURTAIN = 11,
        FOLIAGE = 12,
        GLASS = 13,
        GLASSHEAVY = 14,
        GRASS = 15,
        GRAVEL = 16,
        GYPSUMBOARD = 17,
        PLASTERONBRICK = 18,
        PLASTERONCONCRETEBLOCK = 19,
        SOIL = 20,
        SOUNDPROOF = 21,
        SNOW = 22,
        STEEL = 23,
        WATER = 24,
        WOODTHIN = 25,
        WOODTHICK = 26,
        WOODFLOOR = 27,
        WOODONCONCRETE = 28,
        NOMATERIAL = 255,
    }

    public class SubmixEffectOculusAmbisonicSpatializerSettings : StructProxy
    {
        public SubmixEffectOculusAmbisonicSpatializerSettings(System.IntPtr ptr) : base(ptr) {}
        public EOculusAudioAmbisonicsMode AmbisonicMode { get => (EOculusAudioAmbisonicsMode)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
    }

    public class SubmixEffectOculusReverbPluginSettings : StructProxy
    {
        public SubmixEffectOculusReverbPluginSettings(System.IntPtr ptr) : base(ptr) {}
    }

    public class OculusAudioSoundfieldSettings : SoundfieldEncodingSettingsBase
    {
        public const string UeClassName = "OculusAudioSoundfieldSettings";
        public OculusAudioSoundfieldSettings(System.IntPtr ptr) : base(ptr) {}
        public static new OculusAudioSoundfieldSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusAudioSoundfieldSettings(p);
        public static OculusAudioSoundfieldSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusAudioSoundfieldSettings(o.Pointer); }
        public static OculusAudioSoundfieldSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusAudioSoundfieldSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusAudioSoundfieldSettings(a[i].Pointer); return r; }
        public EOculusAudioAmbisonicsMode SpatializationMode { get => (EOculusAudioAmbisonicsMode)GetAt<byte>(0x28); set => SetAt(0x28, (byte)value); }
    }

    public class OculusAudioMaterialComponent : ActorComponent
    {
        public const string UeClassName = "OculusAudioMaterialComponent";
        public OculusAudioMaterialComponent(System.IntPtr ptr) : base(ptr) {}
        public static new OculusAudioMaterialComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusAudioMaterialComponent(p);
        public static OculusAudioMaterialComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusAudioMaterialComponent(o.Pointer); }
        public static OculusAudioMaterialComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusAudioMaterialComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusAudioMaterialComponent(a[i].Pointer); return r; }
        public EOculusAudioMaterial MaterialPreset { get => (EOculusAudioMaterial)GetAt<byte>(0xB0); set => SetAt(0xB0, (byte)value); }
        public float Absorption63Hz { get => GetAt<float>(0xB4); set => SetAt(0xB4, value); }
        public float Absorption125Hz { get => GetAt<float>(0xB8); set => SetAt(0xB8, value); }
        public float Absorption250Hz { get => GetAt<float>(0xBC); set => SetAt(0xBC, value); }
        public float Absorption500Hz { get => GetAt<float>(0xC0); set => SetAt(0xC0, value); }
        public float Absorption1000Hz { get => GetAt<float>(0xC4); set => SetAt(0xC4, value); }
        public float Absorption2000Hz { get => GetAt<float>(0xC8); set => SetAt(0xC8, value); }
        public float Absorption4000Hz { get => GetAt<float>(0xCC); set => SetAt(0xCC, value); }
        public float Absorption8000Hz { get => GetAt<float>(0xD0); set => SetAt(0xD0, value); }
        public float Transmission63Hz { get => GetAt<float>(0xD4); set => SetAt(0xD4, value); }
        public float Transmission125Hz { get => GetAt<float>(0xD8); set => SetAt(0xD8, value); }
        public float Transmission250Hz { get => GetAt<float>(0xDC); set => SetAt(0xDC, value); }
        public float Transmission500Hz { get => GetAt<float>(0xE0); set => SetAt(0xE0, value); }
        public float Transmission1000Hz { get => GetAt<float>(0xE4); set => SetAt(0xE4, value); }
        public float Transmission2000Hz { get => GetAt<float>(0xE8); set => SetAt(0xE8, value); }
        public float Transmission4000Hz { get => GetAt<float>(0xEC); set => SetAt(0xEC, value); }
        public float Transmission8000Hz { get => GetAt<float>(0xF0); set => SetAt(0xF0, value); }
        public float Scattering63Hz { get => GetAt<float>(0xF4); set => SetAt(0xF4, value); }
        public float Scattering125Hz { get => GetAt<float>(0xF8); set => SetAt(0xF8, value); }
        public float Scattering250Hz { get => GetAt<float>(0xFC); set => SetAt(0xFC, value); }
        public float Scattering500Hz { get => GetAt<float>(0x100); set => SetAt(0x100, value); }
        public float Scattering1000Hz { get => GetAt<float>(0x104); set => SetAt(0x104, value); }
        public float Scattering2000Hz { get => GetAt<float>(0x108); set => SetAt(0x108, value); }
        public float Scattering4000Hz { get => GetAt<float>(0x10C); set => SetAt(0x10C, value); }
        public float Scattering8000Hz { get => GetAt<float>(0x110); set => SetAt(0x110, value); }
    }

    public class OculusAudioGeometryBSP : OculusAudioMaterialComponent
    {
        public const string UeClassName = "OculusAudioGeometryBSP";
        public OculusAudioGeometryBSP(System.IntPtr ptr) : base(ptr) {}
        public static new OculusAudioGeometryBSP FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusAudioGeometryBSP(p);
        public static OculusAudioGeometryBSP FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusAudioGeometryBSP(o.Pointer); }
        public static OculusAudioGeometryBSP[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusAudioGeometryBSP[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusAudioGeometryBSP(a[i].Pointer); return r; }
    }

    public class OculusAudioGeometryComponent : ActorComponent
    {
        public const string UeClassName = "OculusAudioGeometryComponent";
        public OculusAudioGeometryComponent(System.IntPtr ptr) : base(ptr) {}
        public static new OculusAudioGeometryComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusAudioGeometryComponent(p);
        public static OculusAudioGeometryComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusAudioGeometryComponent(o.Pointer); }
        public static OculusAudioGeometryComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusAudioGeometryComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusAudioGeometryComponent(a[i].Pointer); return r; }
        public bool IncludeChildren { get => Native.GetPropBool(Pointer, "IncludeChildren"); set => Native.SetPropBool(Pointer, "IncludeChildren", value); }
    }

    public class OculusAudioGeometryLandscape : OculusAudioMaterialComponent
    {
        public const string UeClassName = "OculusAudioGeometryLandscape";
        public OculusAudioGeometryLandscape(System.IntPtr ptr) : base(ptr) {}
        public static new OculusAudioGeometryLandscape FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusAudioGeometryLandscape(p);
        public static OculusAudioGeometryLandscape FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusAudioGeometryLandscape(o.Pointer); }
        public static OculusAudioGeometryLandscape[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusAudioGeometryLandscape[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusAudioGeometryLandscape(a[i].Pointer); return r; }
    }

    public class SubmixEffectOculusReverbPluginPreset : SoundEffectSubmixPreset
    {
        public const string UeClassName = "SubmixEffectOculusReverbPluginPreset";
        public SubmixEffectOculusReverbPluginPreset(System.IntPtr ptr) : base(ptr) {}
        public static new SubmixEffectOculusReverbPluginPreset FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SubmixEffectOculusReverbPluginPreset(p);
        public static SubmixEffectOculusReverbPluginPreset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SubmixEffectOculusReverbPluginPreset(o.Pointer); }
        public static SubmixEffectOculusReverbPluginPreset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SubmixEffectOculusReverbPluginPreset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SubmixEffectOculusReverbPluginPreset(a[i].Pointer); return r; }
        public SubmixEffectOculusReverbPluginSettings Settings => new SubmixEffectOculusReverbPluginSettings(AddrOf(0x65));
        /// <summary>[Native] thunk RVA 0x5506AF0 — hookable via Hooks.InstallAt(NativeFunc_SetSettings).</summary>
        public static System.IntPtr NativeFunc_SetSettings => Memory.ModuleBase() + 0x5506AF0;
        public void SetSettings(SubmixEffectOculusReverbPluginSettings InSettings)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<System.IntPtr>(0x0, InSettings);
            CallRaw("SetSettings", __pb.Bytes);
        }
    }

    public class OculusAudioSettings : Object
    {
        public const string UeClassName = "OculusAudioSettings";
        public OculusAudioSettings(System.IntPtr ptr) : base(ptr) {}
        public static new OculusAudioSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusAudioSettings(p);
        public static OculusAudioSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusAudioSettings(o.Pointer); }
        public static OculusAudioSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusAudioSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusAudioSettings(a[i].Pointer); return r; }
        public SoftObjectPath OutputSubmix => new SoftObjectPath(AddrOf(0x28));
        public float ReverbWetLevel { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public bool EarlyReflections { get => Native.GetPropBool(Pointer, "EarlyReflections"); set => Native.SetPropBool(Pointer, "EarlyReflections", value); }
        public bool LateReverberation { get => Native.GetPropBool(Pointer, "LateReverberation"); set => Native.SetPropBool(Pointer, "LateReverberation", value); }
        public float PropagationQuality { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float Width { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public float Height { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
        public float Depth { get => GetAt<float>(0x54); set => SetAt(0x54, value); }
        public float ReflectionCoefRight { get => GetAt<float>(0x58); set => SetAt(0x58, value); }
        public float ReflectionCoefLeft { get => GetAt<float>(0x5C); set => SetAt(0x5C, value); }
        public float ReflectionCoefUp { get => GetAt<float>(0x60); set => SetAt(0x60, value); }
        public float ReflectionCoefDown { get => GetAt<float>(0x64); set => SetAt(0x64, value); }
        public float ReflectionCoefBack { get => GetAt<float>(0x68); set => SetAt(0x68, value); }
        public float ReflectionCoefFront { get => GetAt<float>(0x6C); set => SetAt(0x6C, value); }
    }

    public class OculusAudioSourceSettings : SpatializationPluginSourceSettingsBase
    {
        public const string UeClassName = "OculusAudioSourceSettings";
        public OculusAudioSourceSettings(System.IntPtr ptr) : base(ptr) {}
        public static new OculusAudioSourceSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusAudioSourceSettings(p);
        public static OculusAudioSourceSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusAudioSourceSettings(o.Pointer); }
        public static OculusAudioSourceSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusAudioSourceSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusAudioSourceSettings(a[i].Pointer); return r; }
        public bool EarlyReflectionsEnabled { get => Native.GetPropBool(Pointer, "EarlyReflectionsEnabled"); set => Native.SetPropBool(Pointer, "EarlyReflectionsEnabled", value); }
        public bool AttenuationEnabled { get => Native.GetPropBool(Pointer, "AttenuationEnabled"); set => Native.SetPropBool(Pointer, "AttenuationEnabled", value); }
        public float AttenuationRangeMinimum { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float AttenuationRangeMaximum { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float VolumetricRadius { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public float ReverbSendLevel { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
    }

}
