// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMessage/DebugMessageParent
using System;

namespace UEModLoader.Game
{
    public class DebugMessageParent_C : UserWidget
    {
        public const string UeClassName = "DebugMessageParent_C";
        public DebugMessageParent_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new DebugMessageParent_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DebugMessageParent_C(p);
        public static DebugMessageParent_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugMessageParent_C(o.Pointer); }
        public static DebugMessageParent_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugMessageParent_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugMessageParent_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public DebugMessageList_C DebugMessageListB { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public DebugMessageList_C DebugMessageListBL { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public DebugMessageList_C DebugMessageListBR { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public DebugMessageList_C DebugMessageListCn { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public DebugMessageList_C DebugMessageListL { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public DebugMessageList_C DebugMessageListR { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public DebugMessageList_C DebugMessageListU { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public DebugMessageList_C DebugMessageListUL { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public DebugMessageList_C DebugMessageListUR { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void ExecuteUbergraph_DebugMessageParent(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_DebugMessageParent", __pb.Bytes);
        }
    }

}
