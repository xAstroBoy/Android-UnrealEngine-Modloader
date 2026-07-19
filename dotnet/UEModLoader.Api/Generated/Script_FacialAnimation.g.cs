// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/FacialAnimation
using System;

namespace UEModLoader.Game
{
    public class AudioCurveSourceComponent : AudioComponent
    {
        public const string UeClassName = "AudioCurveSourceComponent";
        public AudioCurveSourceComponent(System.IntPtr ptr) : base(ptr) {}
        public static new AudioCurveSourceComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AudioCurveSourceComponent(p);
        public static AudioCurveSourceComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AudioCurveSourceComponent(o.Pointer); }
        public static AudioCurveSourceComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AudioCurveSourceComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AudioCurveSourceComponent(a[i].Pointer); return r; }
        public string CurveSourceBindingName => Native.GetPropName(Pointer, "CurveSourceBindingName"); // FName
        public FName CurveSourceBindingName_Raw { get => GetAt<FName>(0x7D8); set => SetAt(0x7D8, value); }
        public float CurveSyncOffset { get => GetAt<float>(0x7E0); set => SetAt(0x7E0, value); }
    }

}
