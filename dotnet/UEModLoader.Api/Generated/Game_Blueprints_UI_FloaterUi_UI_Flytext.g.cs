// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/UI_Flytext
using System;

namespace UEModLoader.Game
{
    public class UI_Flytext_C : UserWidget
    {
        public const string UeClassName = "UI_Flytext_C";
        public UI_Flytext_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Flytext_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Flytext_C(p);
        public static UI_Flytext_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Flytext_C(o.Pointer); }
        public static UI_Flytext_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Flytext_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Flytext_C(a[i].Pointer); return r; }
        public WidgetAnimation Hide { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay GlobalParent { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock MessageText { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
    }

}
