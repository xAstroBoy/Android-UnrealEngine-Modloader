// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMenu/DebugMenuWidget
using System;

namespace UEModLoader.Game
{
    public class DebugMenuWidget_C : UserWidget
    {
        public const string UeClassName = "DebugMenuWidget_C";
        public DebugMenuWidget_C(System.IntPtr ptr) : base(ptr) {}
        public static new DebugMenuWidget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DebugMenuWidget_C(p);
        public static DebugMenuWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugMenuWidget_C(o.Pointer); }
        public static DebugMenuWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugMenuWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugMenuWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public TextBlock BuildVersion { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public DebugVBoxList_C DebugVBoxList { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new DebugVBoxList_C(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public ScaleBox ScaleBox_MapS1 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new ScaleBox(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public ScaleBox ScaleBox_MapS2 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new ScaleBox(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public ScaleBox ScaleBox_MapS3 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new ScaleBox(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TitleText { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VerticalBox WidgetVBox { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void ExecuteUbergraph_DebugMenuWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_DebugMenuWidget", __pb.Bytes);
        }
    }

}
