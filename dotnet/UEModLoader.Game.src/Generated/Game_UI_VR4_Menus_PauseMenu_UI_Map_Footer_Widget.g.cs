// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Map_Footer_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Map_Footer_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Map_Footer_Widget_C";
        public UI_Map_Footer_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Map_Footer_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Map_Footer_Widget_C(p);
        public static UI_Map_Footer_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Map_Footer_Widget_C(o.Pointer); }
        public static UI_Map_Footer_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Map_Footer_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Map_Footer_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image Image { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_2 { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_Fraction { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void Set_Quantity(global::System.IntPtr Quantity)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Quantity);
            CallRaw("Set_Quantity", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Map_Footer_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Map_Footer_Widget", __pb.Bytes);
        }
    }

}
