// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Map_FilterLabel_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Map_FilterLabel_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Map_FilterLabel_Widget_C";
        public UI_Map_FilterLabel_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Map_FilterLabel_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Map_FilterLabel_Widget_C(p);
        public static UI_Map_FilterLabel_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Map_FilterLabel_Widget_C(o.Pointer); }
        public static UI_Map_FilterLabel_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Map_FilterLabel_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Map_FilterLabel_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image Image { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Heading_Door_Widget_C UI_Heading_Door_Widget { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new UI_Heading_Door_Widget_C(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void InitializeEntries()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeEntries", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void OnInitialized()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnInitialized", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Map_FilterLabel_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Map_FilterLabel_Widget", __pb.Bytes);
        }
    }

}
