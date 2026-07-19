// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Inventory_Health_Label_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Inventory_Health_Label_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Inventory_Health_Label_Widget_C";
        public UI_Inventory_Health_Label_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Inventory_Health_Label_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Inventory_Health_Label_Widget_C(p);
        public static UI_Inventory_Health_Label_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Inventory_Health_Label_Widget_C(o.Pointer); }
        public static UI_Inventory_Health_Label_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Inventory_Health_Label_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Inventory_Health_Label_Widget_C(a[i].Pointer); return r; }
        public TextBlock Text_Label_Name { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetNameLabel(global::System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            CallRaw("SetNameLabel", __pb.Bytes);
        }
    }

}
