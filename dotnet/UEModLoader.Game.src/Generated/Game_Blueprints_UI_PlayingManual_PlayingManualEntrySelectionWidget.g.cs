// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualEntrySelectionWidget
using System;

namespace UEModLoader.Game
{
    public class PlayingManualEntrySelectionWidget_C : UserWidget
    {
        public const string UeClassName = "PlayingManualEntrySelectionWidget_C";
        public PlayingManualEntrySelectionWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualEntrySelectionWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlayingManualEntrySelectionWidget_C(p);
        public static PlayingManualEntrySelectionWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualEntrySelectionWidget_C(o.Pointer); }
        public static PlayingManualEntrySelectionWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualEntrySelectionWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualEntrySelectionWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Box_BG { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Options_ScrollArrow_C ScrollArrow_Down { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new UI_Options_ScrollArrow_C(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Options_ScrollArrow_C ScrollArrow_Up { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new UI_Options_ScrollArrow_C(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Button_Arrow_Widget_C UI_Button_Arrow_Widget { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new UI_Button_Arrow_Widget_C(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Heading_Wide_Widget_C UI_Heading_Wide_Widget { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new UI_Heading_Wide_Widget_C(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x270); // struct UI_WidgetColors_Struct
        public bool UseMercColors { get => Native.GetPropBool(Pointer, "UseMercColors"); set => Native.SetPropBool(Pointer, "UseMercColors", value); }
        public global::System.IntPtr MercColors => AddrOf(0x480); // struct UI_WidgetColorsMercenaries_Struct
        public void SetLowerAreaVisibility(ESlateVisibility Visibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Visibility);
            CallRaw("SetLowerAreaVisibility", __pb.Bytes);
        }
        public void SetHeadingText(global::System.IntPtr newText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, newText);
            CallRaw("SetHeadingText", __pb.Bytes);
        }
        public void ShowBackArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowBackArrow", __pb.Bytes);
        }
        public void HideBackArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideBackArrow", __pb.Bytes);
        }
        public void HoverButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverButton", __pb.Bytes);
        }
        public void UnhoverButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverButton", __pb.Bytes);
        }
        public void Show_Arrow_Up()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Show_Arrow_Up", __pb.Bytes);
        }
        public void Hide_Arrow_Up()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hide_Arrow_Up", __pb.Bytes);
        }
        public void Show_Arrow_Down()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Show_Arrow_Down", __pb.Bytes);
        }
        public void Hide_Arrow_Down()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hide_Arrow_Down", __pb.Bytes);
        }
        public void SetDescriptionText(global::System.IntPtr newText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, newText);
            CallRaw("SetDescriptionText", __pb.Bytes);
        }
        public void HoverDown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverDown", __pb.Bytes);
        }
        public void UnhoverDown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverDown", __pb.Bytes);
        }
        public void HoverUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverUp", __pb.Bytes);
        }
        public void UnhoverUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverUp", __pb.Bytes);
        }
        public void UseMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UseMercenariesColors", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualEntrySelectionWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualEntrySelectionWidget", __pb.Bytes);
        }
    }

}
