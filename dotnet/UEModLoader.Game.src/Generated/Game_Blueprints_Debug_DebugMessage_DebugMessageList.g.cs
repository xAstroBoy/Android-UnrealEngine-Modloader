// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMessage/DebugMessageList
using System;

namespace UEModLoader.Game
{
    public class DebugMessageList_C : UserWidget
    {
        public const string UeClassName = "DebugMessageList_C";
        public DebugMessageList_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new DebugMessageList_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DebugMessageList_C(p);
        public static DebugMessageList_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugMessageList_C(o.Pointer); }
        public static DebugMessageList_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugMessageList_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugMessageList_C(a[i].Pointer); return r; }
        public VerticalBox ListBox { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
