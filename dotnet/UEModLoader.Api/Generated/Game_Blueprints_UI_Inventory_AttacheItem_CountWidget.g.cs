// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/AttacheItem_CountWidget
using System;

namespace UEModLoader.Game
{
    public class AttacheItem_CountWidget_C : UserWidget
    {
        public const string UeClassName = "AttacheItem_CountWidget_C";
        public AttacheItem_CountWidget_C(System.IntPtr ptr) : base(ptr) {}
        public static new AttacheItem_CountWidget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AttacheItem_CountWidget_C(p);
        public static AttacheItem_CountWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AttacheItem_CountWidget_C(o.Pointer); }
        public static AttacheItem_CountWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AttacheItem_CountWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AttacheItem_CountWidget_C(a[i].Pointer); return r; }
        public TextBlock TextBlock { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public void SetInfinite()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetInfinite", __pb.Bytes);
        }
        public void SetCount(int Count)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Count);
            CallRaw("SetCount", __pb.Bytes);
        }
    }

}
