// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Files_ListFrame
using System;

namespace UEModLoader.Game
{
    public class UI_Files_ListFrame_C : UserWidget
    {
        public const string UeClassName = "UI_Files_ListFrame_C";
        public UI_Files_ListFrame_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Files_ListFrame_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Files_ListFrame_C(p);
        public static UI_Files_ListFrame_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Files_ListFrame_C(o.Pointer); }
        public static UI_Files_ListFrame_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Files_ListFrame_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Files_ListFrame_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image Arrow_Down { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow_Up { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Box_BG { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Box_Edge { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Box_Edge_2 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Box_Edge_3 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Box_Edge_4 { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Button_Arrow_Widget_C Widget_Arrow_Left { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new UI_Button_Arrow_Widget_C(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Button_Arrow_Widget_C Widget_Arrow_Right { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new UI_Button_Arrow_Widget_C(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x288); // struct UI_WidgetColors_Struct
        public void HoverLeftArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverLeftArrow", __pb.Bytes);
        }
        public void UnhoverLeftArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverLeftArrow", __pb.Bytes);
        }
        public void DisableLeftArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableLeftArrow", __pb.Bytes);
        }
        public void HoverRightArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverRightArrow", __pb.Bytes);
        }
        public void UnhoverRightArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverRightArrow", __pb.Bytes);
        }
        public void DisableRightArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableRightArrow", __pb.Bytes);
        }
        public void ShowUpArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowUpArrow", __pb.Bytes);
        }
        public void HideUpArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideUpArrow", __pb.Bytes);
        }
        public void ShowDownArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowDownArrow", __pb.Bytes);
        }
        public void HideDownArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideDownArrow", __pb.Bytes);
        }
        public void ClickLeftArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClickLeftArrow", __pb.Bytes);
        }
        public void ClickRightArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClickRightArrow", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Files_ListFrame(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Files_ListFrame", __pb.Bytes);
        }
    }

}
