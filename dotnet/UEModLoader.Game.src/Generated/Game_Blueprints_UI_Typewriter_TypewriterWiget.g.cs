// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Typewriter/TypewriterWiget
using System;

namespace UEModLoader.Game
{
    public class TypewriterWiget_C : UserWidget
    {
        public const string UeClassName = "TypewriterWiget_C";
        public TypewriterWiget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new TypewriterWiget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TypewriterWiget_C(p);
        public static TypewriterWiget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TypewriterWiget_C(o.Pointer); }
        public static TypewriterWiget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TypewriterWiget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TypewriterWiget_C(a[i].Pointer); return r; }
        public Image Image { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_2 { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ScrollBox ScrollBoxList { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new ScrollBox(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TypewriterEntry_C TypewriterEntry { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new TypewriterEntry_C(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TypewriterEntry_C TypewriterEntry_2 { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TypewriterEntry_C(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TypewriterEntry_C TypewriterEntry_3 { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new TypewriterEntry_C(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TypewriterEntry_C TypewriterEntry_4 { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new TypewriterEntry_C(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TypewriterEntry_C TypewriterEntry_5 { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new TypewriterEntry_C(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VerticalBox VerticalBoxList { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
