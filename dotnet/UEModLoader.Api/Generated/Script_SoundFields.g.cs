// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/SoundFields
using System;

namespace UEModLoader.Game
{
    public class AmbisonicsEncodingSettings : SoundfieldEncodingSettingsBase
    {
        public const string UeClassName = "AmbisonicsEncodingSettings";
        public AmbisonicsEncodingSettings(System.IntPtr ptr) : base(ptr) {}
        public static new AmbisonicsEncodingSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AmbisonicsEncodingSettings(p);
        public static AmbisonicsEncodingSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AmbisonicsEncodingSettings(o.Pointer); }
        public static AmbisonicsEncodingSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AmbisonicsEncodingSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AmbisonicsEncodingSettings(a[i].Pointer); return r; }
        public int AmbisonicsOrder { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
    }

}
