// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/MercRingOwner
using System;

namespace UEModLoader.Game
{
    public class MercRingOwner_C : Interface
    {
        public const string UeClassName = "MercRingOwner_C";
        public MercRingOwner_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new MercRingOwner_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MercRingOwner_C(p);
        public static MercRingOwner_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MercRingOwner_C(o.Pointer); }
        public static MercRingOwner_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MercRingOwner_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MercRingOwner_C(a[i].Pointer); return r; }
        public void InitMercRing(FloatingUI_BP_C FloatingUI)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, FloatingUI);
            CallRaw("InitMercRing", __pb.Bytes);
        }
    }

}
