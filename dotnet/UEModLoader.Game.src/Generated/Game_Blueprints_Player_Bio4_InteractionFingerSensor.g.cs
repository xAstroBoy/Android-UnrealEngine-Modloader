// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Bio4/InteractionFingerSensor
using System;

namespace UEModLoader.Game
{
    public class InteractionFingerSensor_C : InteractionSensor_C
    {
        public const string UeClassName = "InteractionFingerSensor_C";
        public InteractionFingerSensor_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractionFingerSensor_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractionFingerSensor_C(p);
        public static InteractionFingerSensor_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractionFingerSensor_C(o.Pointer); }
        public static InteractionFingerSensor_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractionFingerSensor_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractionFingerSensor_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x238));
        public CapsuleComponent Finger { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new CapsuleComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void GetHandObject(VR4PlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("GetHandObject", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_InteractionFingerSensor(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_InteractionFingerSensor", __pb.Bytes);
        }
    }

}
