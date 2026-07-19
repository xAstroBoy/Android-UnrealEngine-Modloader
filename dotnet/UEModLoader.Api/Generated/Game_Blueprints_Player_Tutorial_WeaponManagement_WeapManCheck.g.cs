// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/WeaponManagement/WeapManCheck
using System;

namespace UEModLoader.Game
{
    public class WeapManCheck_C : UserWidget
    {
        public const string UeClassName = "WeapManCheck_C";
        public WeapManCheck_C(System.IntPtr ptr) : base(ptr) {}
        public static new WeapManCheck_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WeapManCheck_C(p);
        public static WeapManCheck_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WeapManCheck_C(o.Pointer); }
        public static WeapManCheck_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WeapManCheck_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WeapManCheck_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation HideCheck { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation RevealCheck { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Ring1 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Ring2 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Ring3 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay ScaleParent { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public void ShowCheckmark()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowCheckmark", __pb.Bytes);
        }
        public void HideCheckmark()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideCheckmark", __pb.Bytes);
        }
        public void Clean()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Clean", __pb.Bytes);
        }
        public void ExecuteUbergraph_WeapManCheck(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_WeapManCheck", __pb.Bytes);
        }
    }

}
