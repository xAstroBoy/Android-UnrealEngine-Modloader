// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/ShootingRange
using System;

namespace UEModLoader.Game
{
    public class ShootingRange_C : Interface
    {
        public const string UeClassName = "ShootingRange_C";
        public ShootingRange_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new ShootingRange_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ShootingRange_C(p);
        public static ShootingRange_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ShootingRange_C(o.Pointer); }
        public static ShootingRange_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ShootingRange_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ShootingRange_C(a[i].Pointer); return r; }
        public void MagazineInserted(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("MagazineInserted", __pb.Bytes);
        }
    }

}
