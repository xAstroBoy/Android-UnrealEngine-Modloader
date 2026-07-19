// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AudioExtensions
using System;

namespace UEModLoader.Game
{
    public class SoundModulationParameter : StructProxy
    {
        public SoundModulationParameter(System.IntPtr ptr) : base(ptr) {}
        public string Control => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Control_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public float Value { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class SoundModulation : StructProxy
    {
        public SoundModulation(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Settings => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<UObject*>
    }

    public class SoundfieldEncodingSettingsBase : Object
    {
        public const string UeClassName = "SoundfieldEncodingSettingsBase";
        public SoundfieldEncodingSettingsBase(System.IntPtr ptr) : base(ptr) {}
        public static new SoundfieldEncodingSettingsBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SoundfieldEncodingSettingsBase(p);
        public static SoundfieldEncodingSettingsBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SoundfieldEncodingSettingsBase(o.Pointer); }
        public static SoundfieldEncodingSettingsBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SoundfieldEncodingSettingsBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SoundfieldEncodingSettingsBase(a[i].Pointer); return r; }
    }

    public class SpatializationPluginSourceSettingsBase : Object
    {
        public const string UeClassName = "SpatializationPluginSourceSettingsBase";
        public SpatializationPluginSourceSettingsBase(System.IntPtr ptr) : base(ptr) {}
        public static new SpatializationPluginSourceSettingsBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SpatializationPluginSourceSettingsBase(p);
        public static SpatializationPluginSourceSettingsBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SpatializationPluginSourceSettingsBase(o.Pointer); }
        public static SpatializationPluginSourceSettingsBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SpatializationPluginSourceSettingsBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SpatializationPluginSourceSettingsBase(a[i].Pointer); return r; }
    }

    public class AudioEndpointSettingsBase : Object
    {
        public const string UeClassName = "AudioEndpointSettingsBase";
        public AudioEndpointSettingsBase(System.IntPtr ptr) : base(ptr) {}
        public static new AudioEndpointSettingsBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AudioEndpointSettingsBase(p);
        public static AudioEndpointSettingsBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AudioEndpointSettingsBase(o.Pointer); }
        public static AudioEndpointSettingsBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AudioEndpointSettingsBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AudioEndpointSettingsBase(a[i].Pointer); return r; }
    }

    public class OcclusionPluginSourceSettingsBase : Object
    {
        public const string UeClassName = "OcclusionPluginSourceSettingsBase";
        public OcclusionPluginSourceSettingsBase(System.IntPtr ptr) : base(ptr) {}
        public static new OcclusionPluginSourceSettingsBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OcclusionPluginSourceSettingsBase(p);
        public static OcclusionPluginSourceSettingsBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OcclusionPluginSourceSettingsBase(o.Pointer); }
        public static OcclusionPluginSourceSettingsBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OcclusionPluginSourceSettingsBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OcclusionPluginSourceSettingsBase(a[i].Pointer); return r; }
    }

    public class SoundModulationPluginSourceSettingsBase : Object
    {
        public const string UeClassName = "SoundModulationPluginSourceSettingsBase";
        public SoundModulationPluginSourceSettingsBase(System.IntPtr ptr) : base(ptr) {}
        public static new SoundModulationPluginSourceSettingsBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SoundModulationPluginSourceSettingsBase(p);
        public static SoundModulationPluginSourceSettingsBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SoundModulationPluginSourceSettingsBase(o.Pointer); }
        public static SoundModulationPluginSourceSettingsBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SoundModulationPluginSourceSettingsBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SoundModulationPluginSourceSettingsBase(a[i].Pointer); return r; }
    }

    public class ReverbPluginSourceSettingsBase : Object
    {
        public const string UeClassName = "ReverbPluginSourceSettingsBase";
        public ReverbPluginSourceSettingsBase(System.IntPtr ptr) : base(ptr) {}
        public static new ReverbPluginSourceSettingsBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ReverbPluginSourceSettingsBase(p);
        public static ReverbPluginSourceSettingsBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ReverbPluginSourceSettingsBase(o.Pointer); }
        public static ReverbPluginSourceSettingsBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ReverbPluginSourceSettingsBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ReverbPluginSourceSettingsBase(a[i].Pointer); return r; }
    }

    public class SoundfieldEndpointSettingsBase : Object
    {
        public const string UeClassName = "SoundfieldEndpointSettingsBase";
        public SoundfieldEndpointSettingsBase(System.IntPtr ptr) : base(ptr) {}
        public static new SoundfieldEndpointSettingsBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SoundfieldEndpointSettingsBase(p);
        public static SoundfieldEndpointSettingsBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SoundfieldEndpointSettingsBase(o.Pointer); }
        public static SoundfieldEndpointSettingsBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SoundfieldEndpointSettingsBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SoundfieldEndpointSettingsBase(a[i].Pointer); return r; }
    }

    public class SoundfieldEffectSettingsBase : Object
    {
        public const string UeClassName = "SoundfieldEffectSettingsBase";
        public SoundfieldEffectSettingsBase(System.IntPtr ptr) : base(ptr) {}
        public static new SoundfieldEffectSettingsBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SoundfieldEffectSettingsBase(p);
        public static SoundfieldEffectSettingsBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SoundfieldEffectSettingsBase(o.Pointer); }
        public static SoundfieldEffectSettingsBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SoundfieldEffectSettingsBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SoundfieldEffectSettingsBase(a[i].Pointer); return r; }
    }

    public class SoundfieldEffectBase : Object
    {
        public const string UeClassName = "SoundfieldEffectBase";
        public SoundfieldEffectBase(System.IntPtr ptr) : base(ptr) {}
        public static new SoundfieldEffectBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SoundfieldEffectBase(p);
        public static SoundfieldEffectBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SoundfieldEffectBase(o.Pointer); }
        public static SoundfieldEffectBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SoundfieldEffectBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SoundfieldEffectBase(a[i].Pointer); return r; }
        public SoundfieldEffectSettingsBase Settings { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new SoundfieldEffectSettingsBase(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
    }

}
