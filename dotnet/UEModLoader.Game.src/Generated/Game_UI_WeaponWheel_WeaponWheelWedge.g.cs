// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/WeaponWheel/WeaponWheelWedge
using System;

namespace UEModLoader.Game
{
    public class WeaponWheelWedge_C : UserWidget
    {
        public const string UeClassName = "WeaponWheelWedge_C";
        public WeaponWheelWedge_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new WeaponWheelWedge_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new WeaponWheelWedge_C(p);
        public static WeaponWheelWedge_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WeaponWheelWedge_C(o.Pointer); }
        public static WeaponWheelWedge_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WeaponWheelWedge_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WeaponWheelWedge_C(a[i].Pointer); return r; }
        public Image background { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BackgroundFill { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Fill_Anchor { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Fill_Parent { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Icon { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image IconFill { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Anchor { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Parent { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
