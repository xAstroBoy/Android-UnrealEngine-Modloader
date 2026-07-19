// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Bio4/InteractionHandSensor
using System;

namespace UEModLoader.Game
{
    public class InteractionHandSensor_C : InteractionSensor_C
    {
        public const string UeClassName = "InteractionHandSensor_C";
        public InteractionHandSensor_C(System.IntPtr ptr) : base(ptr) {}
        public static new InteractionHandSensor_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InteractionHandSensor_C(p);
        public static InteractionHandSensor_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractionHandSensor_C(o.Pointer); }
        public static InteractionHandSensor_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractionHandSensor_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractionHandSensor_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x238));
        public BoxComponent Palm { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_InteractionHandSensor(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_InteractionHandSensor", __pb.Bytes);
        }
    }

}
