// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/AttacheItem_FlashWidget
using System;

namespace UEModLoader.Game
{
    public class AttacheItem_FlashWidget_C : UserWidget
    {
        public const string UeClassName = "AttacheItem_FlashWidget_C";
        public AttacheItem_FlashWidget_C(System.IntPtr ptr) : base(ptr) {}
        public static new AttacheItem_FlashWidget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AttacheItem_FlashWidget_C(p);
        public static AttacheItem_FlashWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AttacheItem_FlashWidget_C(o.Pointer); }
        public static AttacheItem_FlashWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AttacheItem_FlashWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AttacheItem_FlashWidget_C(a[i].Pointer); return r; }
        public Image Flash { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public bool FlashVisible { get => Native.GetPropBool(Pointer, "FlashVisible"); set => Native.SetPropBool(Pointer, "FlashVisible", value); }
        public float Scale0 { get => GetAt<float>(0x23C); set => SetAt(0x23C, value); }
        public float Scale1 { get => GetAt<float>(0x240); set => SetAt(0x240, value); }
        public float Alpha0 { get => GetAt<float>(0x244); set => SetAt(0x244, value); }
        public float Alpha1 { get => GetAt<float>(0x248); set => SetAt(0x248, value); }
        public void SetFlashVisibility(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("SetFlashVisibility", __pb.Bytes);
        }
        public void ScaleFlash(float T)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, T);
            CallRaw("ScaleFlash", __pb.Bytes);
        }
    }

}
