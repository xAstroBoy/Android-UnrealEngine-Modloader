// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/FX/VR4/Environment/Blueprints/Interiors/BPFX_Interior_DustMotes_MainMenu
using System;

namespace UEModLoader.Game
{
    public class BPFX_Interior_DustMotes_MainMenu_C : Emitter
    {
        public const string UeClassName = "BPFX_Interior_DustMotes_MainMenu_C";
        public BPFX_Interior_DustMotes_MainMenu_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new BPFX_Interior_DustMotes_MainMenu_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BPFX_Interior_DustMotes_MainMenu_C(p);
        public static BPFX_Interior_DustMotes_MainMenu_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BPFX_Interior_DustMotes_MainMenu_C(o.Pointer); }
        public static BPFX_Interior_DustMotes_MainMenu_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BPFX_Interior_DustMotes_MainMenu_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BPFX_Interior_DustMotes_MainMenu_C(a[i].Pointer); return r; }
        public BoxComponent Box { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BillboardComponent Billboard { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new BillboardComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
