// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/AttacheItem_CombineWidget
using System;

namespace UEModLoader.Game
{
    public class AttacheItem_CombineWidget_C : UserWidget
    {
        public const string UeClassName = "AttacheItem_CombineWidget_C";
        public AttacheItem_CombineWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new AttacheItem_CombineWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AttacheItem_CombineWidget_C(p);
        public static AttacheItem_CombineWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AttacheItem_CombineWidget_C(o.Pointer); }
        public static AttacheItem_CombineWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AttacheItem_CombineWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AttacheItem_CombineWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation ShowLabelAnimation { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ProgressBar BG_Label_Fill { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new ProgressBar(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BG_Preamble { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image CombineIcon { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Label { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Preamble { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock RichText_Preamble { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Ring { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_Label { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Texture2D linkIcon { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Texture2D UnlinkIcon { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool FlipIcon { get => Native.GetPropBool(Pointer, "FlipIcon"); set => Native.SetPropBool(Pointer, "FlipIcon", value); }
        public global::System.IntPtr Text_Stack_Label => AddrOf(0x298); // 
        public global::System.IntPtr Text_Mix_Label => AddrOf(0x2B0); // 
        public global::System.IntPtr Text_Attach_Label => AddrOf(0x2C8); // 
        public global::System.IntPtr Text_Seperate_Label => AddrOf(0x2E0); // 
        public bool IsShowingLabel { get => Native.GetPropBool(Pointer, "IsShowingLabel"); set => Native.SetPropBool(Pointer, "IsShowingLabel", value); }
        public bool IsHidingLabel { get => Native.GetPropBool(Pointer, "IsHidingLabel"); set => Native.SetPropBool(Pointer, "IsHidingLabel", value); }
        public bool IsLabelVisible { get => Native.GetPropBool(Pointer, "IsLabelVisible"); set => Native.SetPropBool(Pointer, "IsLabelVisible", value); }
        public global::System.IntPtr Text_HoldTo => AddrOf(0x300); // 
        public global::System.IntPtr Text_DropHere => AddrOf(0x318); // 
        public void ChooseLabelText(byte Version)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, Version);
            CallRaw("ChooseLabelText", __pb.Bytes);
        }
        public void SetLabelVisibilities(float MainOpacity, float LabelOpacity, float PreambleOpacity, float BGFill)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, MainOpacity);
            __pb.Set(0x4, LabelOpacity);
            __pb.Set(0x8, PreambleOpacity);
            __pb.Set(0xC, BGFill);
            CallRaw("SetLabelVisibilities", __pb.Bytes);
        }
        public void SetToLinkIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetToLinkIcon", __pb.Bytes);
        }
        public void FlipLinkIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlipLinkIcon", __pb.Bytes);
        }
        public void RememberBothIcons(Texture2D linkIcon, Texture2D UnlinkIcon)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, linkIcon);
            __pb.SetObject(0x8, UnlinkIcon);
            CallRaw("RememberBothIcons", __pb.Bytes);
        }
        public void SetFill(float Fill)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Fill);
            CallRaw("SetFill", __pb.Bytes);
        }
        public void Finished_DE85B3114E2FFD269C4F04B3EC36E6CF()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_DE85B3114E2FFD269C4F04B3EC36E6CF", __pb.Bytes);
        }
        public void Finished_71BB4BFC4B500575C8209B9BCFD6E0F6()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_71BB4BFC4B500575C8209B9BCFD6E0F6", __pb.Bytes);
        }
        public void DEBUG_COLOR()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DEBUG COLOR", __pb.Bytes);
        }
        public void ShowLabel(byte combineType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, combineType);
            CallRaw("ShowLabel", __pb.Bytes);
        }
        public void HideLabel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideLabel", __pb.Bytes);
        }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void ExecuteUbergraph_AttacheItem_CombineWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_AttacheItem_CombineWidget", __pb.Bytes);
        }
    }

}
