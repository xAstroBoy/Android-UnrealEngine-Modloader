// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/WeaponWheel/WeaponWheelWidget
using System;

namespace UEModLoader.Game
{
    public class WeaponWheelWidget_C : UserWidget
    {
        public const string UeClassName = "WeaponWheelWidget_C";
        public WeaponWheelWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new WeaponWheelWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new WeaponWheelWidget_C(p);
        public static WeaponWheelWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WeaponWheelWidget_C(o.Pointer); }
        public static WeaponWheelWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WeaponWheelWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WeaponWheelWidget_C(a[i].Pointer); return r; }
        public Image Arrow { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BackgroundAshleyHeal { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BackgroundAshleyMove { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BackgroundGrenade { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BackgroundHeal { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BackgroundPistol { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BackgroundRifle { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay CenterParent { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image IconAshleyHeal { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image IconAshleyMove { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image IconAshleyStay { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image IconGrenade { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image IconHeal { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image IconPistol { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image IconRifle { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_AshleyHeal_Anchor { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_AshleyHeal_Parent { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_AshleyMove_Anchor { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_AshleyMove_Parent { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Grenade_Anchor { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Grenade_Parent { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Heal_Anchor { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Heal_Parent { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Master { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Pistol_Anchor { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Pistol_Parent { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Rifle_Anchor { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Rifle_Parent { get { var __p = GetAt<global::System.IntPtr>(0x308); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x308, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Master { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WeapManCheck_C WeapManCheck { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new WeapManCheck_C(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WeaponWheelWedge_C WeaponWheelWedgeAshleyHeal { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new WeaponWheelWedge_C(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WeaponWheelWedge_C WeaponWheelWedgeAshleyMove { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new WeaponWheelWedge_C(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WeaponWheelWedge_C WeaponWheelWedgeAshleyStay { get { var __p = GetAt<global::System.IntPtr>(0x330); return __p==global::System.IntPtr.Zero?null:new WeaponWheelWedge_C(__p); } set => SetAt(0x330, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WeaponWheelWedge_C WeaponWheelWedgeGrenade { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new WeaponWheelWedge_C(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WeaponWheelWedge_C WeaponWheelWedgeHeal { get { var __p = GetAt<global::System.IntPtr>(0x340); return __p==global::System.IntPtr.Zero?null:new WeaponWheelWedge_C(__p); } set => SetAt(0x340, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WeaponWheelWedge_C WeaponWheelWedgePistol { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new WeaponWheelWedge_C(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WeaponWheelWedge_C WeaponWheelWedgeRifle { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new WeaponWheelWedge_C(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
