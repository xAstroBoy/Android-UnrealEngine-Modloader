// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/TimeDilation
using System;

namespace UEModLoader.Game
{
    public class TimeDilation_C : Interface
    {
        public const string UeClassName = "TimeDilation_C";
        public TimeDilation_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new TimeDilation_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TimeDilation_C(p);
        public static TimeDilation_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TimeDilation_C(o.Pointer); }
        public static TimeDilation_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TimeDilation_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TimeDilation_C(a[i].Pointer); return r; }
        public void WorldDilationChanged(float WorldTimeDilation, float PlayerTimeDilation, float CustomTimeDilation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, WorldTimeDilation);
            __pb.Set(0x4, PlayerTimeDilation);
            __pb.Set(0x8, CustomTimeDilation);
            CallRaw("WorldDilationChanged", __pb.Bytes);
        }
    }

}
