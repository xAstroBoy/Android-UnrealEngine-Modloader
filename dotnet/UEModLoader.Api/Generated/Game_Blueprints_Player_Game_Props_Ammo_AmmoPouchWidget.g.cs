// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Ammo/AmmoPouchWidget
using System;

namespace UEModLoader.Game
{
    public class AmmoPouchWidget_C : UserWidget
    {
        public const string UeClassName = "AmmoPouchWidget_C";
        public AmmoPouchWidget_C(System.IntPtr ptr) : base(ptr) {}
        public static new AmmoPouchWidget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AmmoPouchWidget_C(p);
        public static AmmoPouchWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AmmoPouchWidget_C(o.Pointer); }
        public static AmmoPouchWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AmmoPouchWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AmmoPouchWidget_C(a[i].Pointer); return r; }
        public Image background { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Fullsize { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Fullsize_2 { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TextCount { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TextMessage { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_text { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public void UpdateColor(bool Empty)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Empty?1:0));
            CallRaw("UpdateColor", __pb.Bytes);
        }
        public void SetIcon(EAmmoType AmmoType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)AmmoType);
            CallRaw("SetIcon", __pb.Bytes);
        }
        public void SetMessage(System.IntPtr Message)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Message);
            CallRaw("SetMessage", __pb.Bytes);
        }
        public void SetCount(int ammoCount)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ammoCount);
            CallRaw("SetCount", __pb.Bytes);
        }
    }

}
