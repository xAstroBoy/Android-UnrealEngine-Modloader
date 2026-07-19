// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PauseMenu/KeysAndTreasures/Widgets/UI_KeysTreasures_Next_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_KeysTreasures_Next_Widget_C : UI_Button_Widget_BP_C
    {
        public const string UeClassName = "UI_KeysTreasures_Next_Widget_C";
        public UI_KeysTreasures_Next_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_KeysTreasures_Next_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_KeysTreasures_Next_Widget_C(p);
        public static UI_KeysTreasures_Next_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_KeysTreasures_Next_Widget_C(o.Pointer); }
        public static UI_KeysTreasures_Next_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_KeysTreasures_Next_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_KeysTreasures_Next_Widget_C(a[i].Pointer); return r; }
        public Image Arrow { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow_2 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow_Inner { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow_Inner_2 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image circle { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Image circle_2 { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Circle_Inner { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Circle_Inner_2 { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Frame { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public void ToggleOff()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleOff", __pb.Bytes);
        }
        public void ToggleOn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleOn", __pb.Bytes);
        }
        public void Unhighlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhighlight", __pb.Bytes);
        }
        public void Highlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Highlight", __pb.Bytes);
        }
        public void test()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("test", __pb.Bytes);
        }
    }

}
