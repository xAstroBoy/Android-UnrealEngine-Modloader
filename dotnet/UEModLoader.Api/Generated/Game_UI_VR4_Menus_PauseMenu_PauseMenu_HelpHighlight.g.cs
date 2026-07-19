// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/PauseMenu_HelpHighlight
using System;

namespace UEModLoader.Game
{
    public class PauseMenu_HelpHighlight_C : UserWidget
    {
        public const string UeClassName = "PauseMenu_HelpHighlight_C";
        public PauseMenu_HelpHighlight_C(System.IntPtr ptr) : base(ptr) {}
        public static new PauseMenu_HelpHighlight_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PauseMenu_HelpHighlight_C(p);
        public static PauseMenu_HelpHighlight_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PauseMenu_HelpHighlight_C(o.Pointer); }
        public static PauseMenu_HelpHighlight_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PauseMenu_HelpHighlight_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PauseMenu_HelpHighlight_C(a[i].Pointer); return r; }
        public WidgetAnimation Alert { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
    }

}
