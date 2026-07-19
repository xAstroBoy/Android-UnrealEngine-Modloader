// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/LightPropagationVolumeRuntime
using System;

namespace UEModLoader.Game
{
    public class LightPropagationVolumeBlendable : Object
    {
        public const string UeClassName = "LightPropagationVolumeBlendable";
        public LightPropagationVolumeBlendable(global::System.IntPtr ptr) : base(ptr) {}
        public static new LightPropagationVolumeBlendable FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LightPropagationVolumeBlendable(p);
        public static LightPropagationVolumeBlendable FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LightPropagationVolumeBlendable(o.Pointer); }
        public static LightPropagationVolumeBlendable[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LightPropagationVolumeBlendable[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LightPropagationVolumeBlendable(a[i].Pointer); return r; }
        public LightPropagationVolumeSettings Settings => new LightPropagationVolumeSettings(AddrOf(0x30));
        public float BlendWeight { get => GetAt<float>(0x70); set => SetAt(0x70, value); }
    }

}
