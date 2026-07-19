// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/GunVice
using System;

namespace UEModLoader.Game
{
    public class GunVice_C : Interface
    {
        public const string UeClassName = "GunVice_C";
        public GunVice_C(System.IntPtr ptr) : base(ptr) {}
        public static new GunVice_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GunVice_C(p);
        public static GunVice_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GunVice_C(o.Pointer); }
        public static GunVice_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GunVice_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GunVice_C(a[i].Pointer); return r; }
        public void AttacheItemReleased(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("AttacheItemReleased", __pb.Bytes);
        }
        public void AttacheItemGrabbed(AttacheItem_BP_C AttacheItem, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, AttacheItem);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("AttacheItemGrabbed", __pb.Bytes);
        }
    }

}
