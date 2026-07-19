// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Singletons/Bio4Dependencies
using System;

namespace UEModLoader.Game
{
    public class Bio4Dependencies_C : Actor
    {
        public const string UeClassName = "Bio4Dependencies_C";
        public Bio4Dependencies_C(System.IntPtr ptr) : base(ptr) {}
        public static new Bio4Dependencies_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Bio4Dependencies_C(p);
        public static Bio4Dependencies_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Bio4Dependencies_C(o.Pointer); }
        public static Bio4Dependencies_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Bio4Dependencies_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Bio4Dependencies_C(a[i].Pointer); return r; }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x220); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x220, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_PauseMenu_BP_C PauseMenuBp { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_BP_C(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
    }

}
