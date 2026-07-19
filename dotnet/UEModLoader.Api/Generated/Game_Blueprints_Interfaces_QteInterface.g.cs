// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/QteInterface
using System;

namespace UEModLoader.Game
{
    public class QteInterface_C : Interface
    {
        public const string UeClassName = "QteInterface_C";
        public QteInterface_C(System.IntPtr ptr) : base(ptr) {}
        public static new QteInterface_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new QteInterface_C(p);
        public static QteInterface_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new QteInterface_C(o.Pointer); }
        public static QteInterface_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new QteInterface_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new QteInterface_C(a[i].Pointer); return r; }
        public void QteCancelled(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("QteCancelled", __pb.Bytes);
        }
        public void QteStarted(float Duration, float Scale, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, Duration);
            __pb.Set(0x4, Scale);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("QteStarted", __pb.Bytes);
        }
    }

}
