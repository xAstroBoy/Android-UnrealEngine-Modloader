// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Typewriter/TypewriterEntry
using System;

namespace UEModLoader.Game
{
    public class TypewriterEntry_C : UserWidget
    {
        public const string UeClassName = "TypewriterEntry_C";
        public TypewriterEntry_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new TypewriterEntry_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TypewriterEntry_C(p);
        public static TypewriterEntry_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TypewriterEntry_C(o.Pointer); }
        public static TypewriterEntry_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TypewriterEntry_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TypewriterEntry_C(a[i].Pointer); return r; }
        public TextBlock ChapterText { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock IndexText { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ModeText { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock RoundText { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SavesText { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TimeText { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
