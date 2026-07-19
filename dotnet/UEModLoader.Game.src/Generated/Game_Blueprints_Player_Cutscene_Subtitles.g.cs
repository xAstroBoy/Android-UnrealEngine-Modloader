// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Cutscene/Subtitles
using System;

namespace UEModLoader.Game
{
    public class Subtitles_C : UserWidget
    {
        public const string UeClassName = "Subtitles_C";
        public Subtitles_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Subtitles_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Subtitles_C(p);
        public static Subtitles_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Subtitles_C(o.Pointer); }
        public static Subtitles_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Subtitles_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Subtitles_C(a[i].Pointer); return r; }
        public TextBlock SubtitleText { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
