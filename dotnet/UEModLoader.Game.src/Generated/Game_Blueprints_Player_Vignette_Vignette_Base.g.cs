// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Vignette/Vignette_Base
using System;

namespace UEModLoader.Game
{
    public class Vignette_Base_C : VR4Vignette
    {
        public const string UeClassName = "Vignette_Base_C";
        public Vignette_Base_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Vignette_Base_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Vignette_Base_C(p);
        public static Vignette_Base_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Vignette_Base_C(o.Pointer); }
        public static Vignette_Base_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Vignette_Base_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Vignette_Base_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x308));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetTimeScaleInternal(float worldValue, float pawnValue)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, worldValue);
            __pb.Set(0x4, pawnValue);
            CallRaw("SetTimeScaleInternal", __pb.Bytes);
        }
        public float GetColorSaturation()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetColorSaturation", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        public void SetColorSaturation(float Saturation)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Saturation);
            CallRaw("SetColorSaturation", __pb.Bytes);
        }
        public void SetTimeScales(float worldValue, float pawnValue)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, worldValue);
            __pb.Set(0x4, pawnValue);
            CallRaw("SetTimeScales", __pb.Bytes);
        }
        public void ExecuteUbergraph_Vignette_Base(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Vignette_Base", __pb.Bytes);
        }
    }

}
