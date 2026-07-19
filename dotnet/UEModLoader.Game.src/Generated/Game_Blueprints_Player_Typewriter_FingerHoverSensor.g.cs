// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Typewriter/FingerHoverSensor
using System;

namespace UEModLoader.Game
{
    public class FingerHoverSensor_C : Actor
    {
        public const string UeClassName = "FingerHoverSensor_C";
        public FingerHoverSensor_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new FingerHoverSensor_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FingerHoverSensor_C(p);
        public static FingerHoverSensor_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FingerHoverSensor_C(o.Pointer); }
        public static FingerHoverSensor_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FingerHoverSensor_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FingerHoverSensor_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SphereComponent Sensor { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SphereComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4PlayerHand Hand { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new VR4PlayerHand(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetEnabled(bool Enabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            CallRaw("SetEnabled", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_FingerHoverSensor(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_FingerHoverSensor", __pb.Bytes);
        }
    }

}
