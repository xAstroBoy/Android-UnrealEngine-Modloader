// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/AttacheItem_TuneUpWidget
using System;

namespace UEModLoader.Game
{
    public class AttacheItem_TuneUpWidget_C : UserWidget
    {
        public const string UeClassName = "AttacheItem_TuneUpWidget_C";
        public AttacheItem_TuneUpWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new AttacheItem_TuneUpWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AttacheItem_TuneUpWidget_C(p);
        public static AttacheItem_TuneUpWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AttacheItem_TuneUpWidget_C(o.Pointer); }
        public static AttacheItem_TuneUpWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AttacheItem_TuneUpWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AttacheItem_TuneUpWidget_C(a[i].Pointer); return r; }
        public WidgetAnimation Flash { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image TuneUpIcon { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetCanAfford(bool CanAfford)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(CanAfford?1:0));
            CallRaw("SetCanAfford", __pb.Bytes);
        }
        public void SetTexture(Texture2D Texture)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Texture);
            CallRaw("SetTexture", __pb.Bytes);
        }
    }

}
