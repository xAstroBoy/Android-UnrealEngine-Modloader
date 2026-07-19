// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Cinematics/r101_30_Interface
using System;

namespace UEModLoader.Game
{
    public class r101_30_Interface_C : Interface
    {
        public const string UeClassName = "r101_30_Interface_C";
        public r101_30_Interface_C(System.IntPtr ptr) : base(ptr) {}
        public static new r101_30_Interface_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new r101_30_Interface_C(p);
        public static r101_30_Interface_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new r101_30_Interface_C(o.Pointer); }
        public static r101_30_Interface_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new r101_30_Interface_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new r101_30_Interface_C(a[i].Pointer); return r; }
        public void PlayThankYou(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PlayThankYou", __pb.Bytes);
        }
    }

}
