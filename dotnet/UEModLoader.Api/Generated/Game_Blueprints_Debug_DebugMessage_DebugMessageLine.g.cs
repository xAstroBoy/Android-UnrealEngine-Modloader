// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMessage/DebugMessageLine
using System;

namespace UEModLoader.Game
{
    public class DebugMessageLine_C : DebugScreenTextWidget
    {
        public const string UeClassName = "DebugMessageLine_C";
        public DebugMessageLine_C(System.IntPtr ptr) : base(ptr) {}
        public static new DebugMessageLine_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DebugMessageLine_C(p);
        public static DebugMessageLine_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugMessageLine_C(o.Pointer); }
        public static DebugMessageLine_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugMessageLine_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugMessageLine_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public Image BackgroundImage { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock DisplayText { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public DebugMessageList_C MessageList { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new DebugMessageList_C(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public void ReadProperties()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReadProperties", __pb.Bytes);
        }
        public void ExecuteUbergraph_DebugMessageLine(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_DebugMessageLine", __pb.Bytes);
        }
    }

}
