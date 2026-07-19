// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/Watch
using System;

namespace UEModLoader.Game
{
    public class Watch_C : Interface
    {
        public const string UeClassName = "Watch_C";
        public Watch_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Watch_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Watch_C(p);
        public static Watch_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Watch_C(o.Pointer); }
        public static Watch_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Watch_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Watch_C(a[i].Pointer); return r; }
        public void UpdateTimeLeft(global::System.IntPtr Min, global::System.IntPtr Sec, global::System.IntPtr Csec, bool isWarning, bool Callback)
        {
            var __pb = new ParamBuffer(74);
            __pb.Set<global::System.IntPtr>(0x0, Min);
            __pb.Set<global::System.IntPtr>(0x18, Sec);
            __pb.Set<global::System.IntPtr>(0x30, Csec);
            __pb.Set<byte>(0x48, (byte)(isWarning?1:0));
            __pb.Set<byte>(0x49, (byte)(Callback?1:0));
            CallRaw("UpdateTimeLeft", __pb.Bytes);
        }
        public void UpdateWatchScore(int Score, bool Callback)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Score);
            __pb.Set<byte>(0x4, (byte)(Callback?1:0));
            CallRaw("UpdateWatchScore", __pb.Bytes);
        }
        public void CameraModeChanged(ECameraMode Mode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Mode);
            CallRaw("CameraModeChanged", __pb.Bytes);
        }
        public void UpdateArm(EHandedness NewHand, bool Callback)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)NewHand);
            __pb.Set<byte>(0x1, (byte)(Callback?1:0));
            CallRaw("UpdateArm", __pb.Bytes);
        }
    }

}
