// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PauseMenu/KeysAndTreasures/Widgets/UI_KeysTreasures_Count_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_KeysTreasures_Count_Widget_C : UI_Button_Widget_BP_C
    {
        public const string UeClassName = "UI_KeysTreasures_Count_Widget_C";
        public UI_KeysTreasures_Count_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_KeysTreasures_Count_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_KeysTreasures_Count_Widget_C(p);
        public static UI_KeysTreasures_Count_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_KeysTreasures_Count_Widget_C(o.Pointer); }
        public static UI_KeysTreasures_Count_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_KeysTreasures_Count_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_KeysTreasures_Count_Widget_C(a[i].Pointer); return r; }
        public TextBlock TextBlock { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
