// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/TheatreBox
using System;

namespace UEModLoader.Game
{
    public class TheatreBox_C : Interface
    {
        public const string UeClassName = "TheatreBox_C";
        public TheatreBox_C(System.IntPtr ptr) : base(ptr) {}
        public static new TheatreBox_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TheatreBox_C(p);
        public static TheatreBox_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TheatreBox_C(o.Pointer); }
        public static TheatreBox_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TheatreBox_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TheatreBox_C(a[i].Pointer); return r; }
        public void Int_ExternalSubtitle(System.IntPtr Text, float Duration, bool Callback)
        {
            var __pb = new ParamBuffer(29);
            __pb.Set<System.IntPtr>(0x0, Text);
            __pb.Set(0x18, Duration);
            __pb.Set<byte>(0x1C, (byte)(Callback?1:0));
            CallRaw("Int_ExternalSubtitle", __pb.Bytes);
        }
        public void Int_PrepForEnd(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("Int_PrepForEnd", __pb.Bytes);
        }
    }

}
