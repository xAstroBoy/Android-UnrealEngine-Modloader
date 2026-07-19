// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/FilesUIScreen_Note_Widget
using System;

namespace UEModLoader.Game
{
    public class FilesUIScreen_Note_Widget_C : UserWidget
    {
        public const string UeClassName = "FilesUIScreen_Note_Widget_C";
        public FilesUIScreen_Note_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new FilesUIScreen_Note_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FilesUIScreen_Note_Widget_C(p);
        public static FilesUIScreen_Note_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FilesUIScreen_Note_Widget_C(o.Pointer); }
        public static FilesUIScreen_Note_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FilesUIScreen_Note_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FilesUIScreen_Note_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image ArrowLeft { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ArrowRight { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image EdgeLeft { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image EdgeRight { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock pageNumber { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock PageText { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock PageText_JP { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Texture { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image XButton { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image XButton_BG { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image XButton_Highlight { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x290); // struct UI_WidgetColors_Struct
        public void SetTexture(global::System.IntPtr PageTexture)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<global::System.IntPtr>(0x0, PageTexture);
            CallRaw("SetTexture", __pb.Bytes);
        }
        public void SetPageNumber(int Page, int PageCount)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Page);
            __pb.Set(0x4, PageCount);
            CallRaw("SetPageNumber", __pb.Bytes);
        }
        public void SetPageText(global::System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            CallRaw("SetPageText", __pb.Bytes);
        }
        public void ShowLeftArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowLeftArrow", __pb.Bytes);
        }
        public void HideLeftArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideLeftArrow", __pb.Bytes);
        }
        public void ShowRightArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowRightArrow", __pb.Bytes);
        }
        public void HideRightArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideRightArrow", __pb.Bytes);
        }
        public void Hover_XButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hover_XButton", __pb.Bytes);
        }
        public void Unhover_XButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhover_XButton", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_FilesUIScreen_Note_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_FilesUIScreen_Note_Widget", __pb.Bytes);
        }
    }

}
