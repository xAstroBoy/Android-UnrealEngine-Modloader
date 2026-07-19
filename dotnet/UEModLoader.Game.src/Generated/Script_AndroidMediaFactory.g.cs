// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AndroidMediaFactory
using System;

namespace UEModLoader.Game
{
    public class AndroidMediaSettings : Object
    {
        public const string UeClassName = "AndroidMediaSettings";
        public AndroidMediaSettings(global::System.IntPtr ptr) : base(ptr) {}
        public static new AndroidMediaSettings FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AndroidMediaSettings(p);
        public static AndroidMediaSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AndroidMediaSettings(o.Pointer); }
        public static AndroidMediaSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AndroidMediaSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AndroidMediaSettings(a[i].Pointer); return r; }
        public bool CacheableVideoSampleBuffers { get => Native.GetPropBool(Pointer, "CacheableVideoSampleBuffers"); set => Native.SetPropBool(Pointer, "CacheableVideoSampleBuffers", value); }
    }

}
