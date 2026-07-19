// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMenu/DebugVBoxList
using System;

namespace UEModLoader.Game
{
    public class DebugVBoxList_C : UserWidget
    {
        public const string UeClassName = "DebugVBoxList_C";
        public DebugVBoxList_C(System.IntPtr ptr) : base(ptr) {}
        public static new DebugVBoxList_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DebugVBoxList_C(p);
        public static DebugVBoxList_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugVBoxList_C(o.Pointer); }
        public static DebugVBoxList_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugVBoxList_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugVBoxList_C(a[i].Pointer); return r; }
        public Image DownArrow { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public VerticalBox ParentVBox { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image UpArrow { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public int MaxVisible { get => GetAt<int>(0x248); set => SetAt(0x248, value); }
        public int FirstVisible { get => GetAt<int>(0x24C); set => SetAt(0x24C, value); }
        public int Selection { get => GetAt<int>(0x250); set => SetAt(0x250, value); }
        public void SelectionDecremented()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SelectionDecremented", __pb.Bytes);
        }
        public void SelectionIncremented()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SelectionIncremented", __pb.Bytes);
        }
        public void UpdateListView()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateListView", __pb.Bytes);
        }
        public void ClearWidgets()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearWidgets", __pb.Bytes);
        }
        public void AddWidget(Widget Widget, VerticalBoxSlot Slot)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            __pb.SetObject(0x8, Slot);
            CallRaw("AddWidget", __pb.Bytes);
        }
    }

}
