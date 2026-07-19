// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_MerchantScreen_ButtonFrame_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_MerchantScreen_ButtonFrame_Widget_C : UI_Button_Widget_BP_C
    {
        public const string UeClassName = "UI_MerchantScreen_ButtonFrame_Widget_C";
        public UI_MerchantScreen_ButtonFrame_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_MerchantScreen_ButtonFrame_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_MerchantScreen_ButtonFrame_Widget_C(p);
        public static UI_MerchantScreen_ButtonFrame_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MerchantScreen_ButtonFrame_Widget_C(o.Pointer); }
        public static UI_MerchantScreen_ButtonFrame_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MerchantScreen_ButtonFrame_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MerchantScreen_ButtonFrame_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public ProgressBar Fill { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new ProgressBar(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BG { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BGFlash { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BGHighlight { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Label { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public bool IsSelected { get => Native.GetPropBool(Pointer, "IsSelected"); set => Native.SetPropBool(Pointer, "IsSelected", value); }
        public System.IntPtr Colors => AddrOf(0x288); // struct UI_WidgetColors_Struct
        public System.IntPtr MerchantColors => AddrOf(0x490); // struct UI_MerchantColors_Struct
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
        public void Disable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Disable", __pb.Bytes);
        }
        public void SetText(System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Text);
            CallRaw("SetText", __pb.Bytes);
        }
        public void SetWidgetSelectedState(bool _IsSelected)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(_IsSelected?1:0));
            CallRaw("SetWidgetSelectedState", __pb.Bytes);
        }
        public void GetWidgetSelectedState(bool IsSelected)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsSelected?1:0));
            CallRaw("GetWidgetSelectedState", __pb.Bytes);
        }
        public void SetBGGlowOpacity(float Opacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Opacity);
            CallRaw("SetBGGlowOpacity", __pb.Bytes);
        }
        public void SetBGFlashOpacity(float Opacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Opacity);
            CallRaw("SetBGFlashOpacity", __pb.Bytes);
        }
        public void FlashSelection()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlashSelection", __pb.Bytes);
        }
        public void SetFill(float FillPercent)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, FillPercent);
            CallRaw("SetFill", __pb.Bytes);
        }
        public void ShowIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowIcon", __pb.Bytes);
        }
        public void HideIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideIcon", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MerchantScreen_ButtonFrame_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MerchantScreen_ButtonFrame_Widget", __pb.Bytes);
        }
    }

}
