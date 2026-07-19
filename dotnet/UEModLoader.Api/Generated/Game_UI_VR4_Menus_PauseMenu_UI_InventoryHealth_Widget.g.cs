// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_InventoryHealth_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_InventoryHealth_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_InventoryHealth_Widget_C";
        public UI_InventoryHealth_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_InventoryHealth_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_InventoryHealth_Widget_C(p);
        public static UI_InventoryHealth_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_InventoryHealth_Widget_C(o.Pointer); }
        public static UI_InventoryHealth_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_InventoryHealth_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_InventoryHealth_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetSwitcher AltSwitcher { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock AmmoBacking1 { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock AmmoBacking2 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay AmmoCountParent { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BackgroundSprite { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Ammo { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Fullsize { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Heart_Green { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Heart_Yellow { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Person { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Overlay_Alt { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Ammo { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Ammo100 { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_AmmoInventory { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Empty { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Money { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Time { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Time_s { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_TimeWorld { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_TimeWorld_pm { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TextTimeWorld_Date { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image VignetteSprite { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_IconType { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public LinearColor Color_Background_Fine => new LinearColor(AddrOf(0x2F0));
        public LinearColor Color_Foreground_Fine => new LinearColor(AddrOf(0x300));
        public LinearColor Color_Vignette_Caution => new LinearColor(AddrOf(0x310));
        public LinearColor Color_Foreground_Caution => new LinearColor(AddrOf(0x320));
        public LinearColor Color_Vignette_Danger => new LinearColor(AddrOf(0x330));
        public LinearColor Color_Foreground_Danger => new LinearColor(AddrOf(0x340));
        public Texture2D Icon_PistolAmmo { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public Texture2D Icon_ShotgunAmmo { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public LinearColor Color_Background_Empty => new LinearColor(AddrOf(0x360));
        public LinearColor Color_Background_Caution => new LinearColor(AddrOf(0x370));
        public LinearColor Color_Background_Danger => new LinearColor(AddrOf(0x380));
        public LinearColor Color_Vignette_Empty => new LinearColor(AddrOf(0x390));
        public LinearColor Color_Vignette_Fine => new LinearColor(AddrOf(0x3A0));
        public LinearColor Color_Background_Default => new LinearColor(AddrOf(0x3B0));
        public LinearColor Color_Vignette_Default => new LinearColor(AddrOf(0x3C0));
        public EAmmoType CurrentType { get => (EAmmoType)GetAt<byte>(0x3D0); set => SetAt(0x3D0, (byte)value); }
        public TimerHandle AltTimer => new TimerHandle(AddrOf(0x3D8));
        public int PTAS { get => GetAt<int>(0x3E0); set => SetAt(0x3E0, value); }
        public LinearColor Color_Foreground_CashMoney => new LinearColor(AddrOf(0x3E4));
        public int FlashCount { get => GetAt<int>(0x3F4); set => SetAt(0x3F4, value); }
        public TimerHandle FlashTimer => new TimerHandle(AddrOf(0x3F8));
        public bool NoGame { get => Native.GetPropBool(Pointer, "NoGame"); set => Native.SetPropBool(Pointer, "NoGame", value); }
        public bool IsHovering { get => Native.GetPropBool(Pointer, "IsHovering"); set => Native.SetPropBool(Pointer, "IsHovering", value); }
        public bool IsInfiniteAmmo { get => Native.GetPropBool(Pointer, "IsInfiniteAmmo"); set => Native.SetPropBool(Pointer, "IsInfiniteAmmo", value); }
        public void UpdateIsInfiniteAmmo(EAmmoType Type, int Ammo, int Total)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<byte>(0x0, (byte)Type);
            __pb.Set(0x4, Ammo);
            __pb.Set(0x8, Total);
            CallRaw("UpdateIsInfiniteAmmo", __pb.Bytes);
        }
        public void AmmoWidgetIndex(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("AmmoWidgetIndex", __pb.Bytes);
        }
        public void ShowHeartOrAmmo(bool ShowGreenHeart, bool ShowYellowHeart, bool IsAshley)
        {
            var __pb = new ParamBuffer(3);
            __pb.Set<byte>(0x0, (byte)(ShowGreenHeart?1:0));
            __pb.Set<byte>(0x1, (byte)(ShowYellowHeart?1:0));
            __pb.Set<byte>(0x2, (byte)(IsAshley?1:0));
            CallRaw("ShowHeartOrAmmo", __pb.Bytes);
        }
        public void UpdateAltInfo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateAltInfo", __pb.Bytes);
        }
        public void ApplyDefaultColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ApplyDefaultColors", __pb.Bytes);
        }
        public void PulseCaution(float Amount)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Amount);
            CallRaw("PulseCaution", __pb.Bytes);
        }
        public void PulseDanger(float Amount)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Amount);
            CallRaw("PulseDanger", __pb.Bytes);
        }
        public void UpdateAmmo(EAmmoType EAmmoType, int Amount, int totalAmmo)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<byte>(0x0, (byte)EAmmoType);
            __pb.Set(0x4, Amount);
            __pb.Set(0x8, totalAmmo);
            CallRaw("UpdateAmmo", __pb.Bytes);
        }
        public void SetDefault_Fine()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetDefault_Fine", __pb.Bytes);
        }
        public void SetDefault_Empty()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetDefault_Empty", __pb.Bytes);
        }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void UpdateAlt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateAlt", __pb.Bytes);
        }
        public void ShowMoney()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowMoney", __pb.Bytes);
        }
        public void Flash()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Flash", __pb.Bytes);
        }
        public void HideAllIcons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideAllIcons", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_InventoryHealth_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_InventoryHealth_Widget", __pb.Bytes);
        }
    }

}
