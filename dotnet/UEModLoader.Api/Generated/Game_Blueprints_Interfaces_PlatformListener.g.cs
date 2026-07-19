// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/PlatformListener
using System;

namespace UEModLoader.Game
{
    public class PlatformListener_C : Interface
    {
        public const string UeClassName = "PlatformListener_C";
        public PlatformListener_C(System.IntPtr ptr) : base(ptr) {}
        public static new PlatformListener_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PlatformListener_C(p);
        public static PlatformListener_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlatformListener_C(o.Pointer); }
        public static PlatformListener_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlatformListener_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlatformListener_C(a[i].Pointer); return r; }
        public void PlatformChanged(byte NewActivePlatform, bool Callback)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set(0x0, NewActivePlatform);
            __pb.Set<byte>(0x1, (byte)(Callback?1:0));
            CallRaw("PlatformChanged", __pb.Bytes);
        }
    }

}
