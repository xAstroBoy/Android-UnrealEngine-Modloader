// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/AttacheItem_EquipWidget
using System;

namespace UEModLoader.Game
{
    public class AttacheItem_EquipWidget_C : UserWidget
    {
        public const string UeClassName = "AttacheItem_EquipWidget_C";
        public AttacheItem_EquipWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new AttacheItem_EquipWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AttacheItem_EquipWidget_C(p);
        public static AttacheItem_EquipWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AttacheItem_EquipWidget_C(o.Pointer); }
        public static AttacheItem_EquipWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AttacheItem_EquipWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AttacheItem_EquipWidget_C(a[i].Pointer); return r; }
        public Image EquipIcon { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float firstAlpha { get => GetAt<float>(0x238); set => SetAt(0x238, value); }
        public float lastAlpha { get => GetAt<float>(0x23C); set => SetAt(0x23C, value); }
        public void SetTexture(Texture2D Texture)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Texture);
            CallRaw("SetTexture", __pb.Bytes);
        }
    }

}
