// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_Message_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_Message_Widget_C : UI_Merchant_Button_Widget_BP_C
    {
        public const string UeClassName = "UI_Merchant_Message_Widget_C";
        public UI_Merchant_Message_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_Message_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_Message_Widget_C(p);
        public static UI_Merchant_Message_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_Message_Widget_C(o.Pointer); }
        public static UI_Merchant_Message_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_Message_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_Message_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public Image Image_Arrow { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_BG { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_Description { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_InvisibleSizeSetter { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetTextVisibility(bool IsVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsVisible?1:0));
            CallRaw("SetTextVisibility", __pb.Bytes);
        }
        public void SetFullTextSize(global::System.IntPtr NewParam)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, NewParam);
            CallRaw("SetFullTextSize", __pb.Bytes);
        }
        public void SetArrowVisibility(bool IsVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsVisible?1:0));
            CallRaw("SetArrowVisibility", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_Message_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_Message_Widget", __pb.Bytes);
        }
    }

}
