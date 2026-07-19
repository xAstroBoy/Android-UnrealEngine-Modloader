// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_CreditsEntry_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_CreditsEntry_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_CreditsEntry_Widget_C";
        public UI_CreditsEntry_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_CreditsEntry_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_CreditsEntry_Widget_C(p);
        public static UI_CreditsEntry_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_CreditsEntry_Widget_C(o.Pointer); }
        public static UI_CreditsEntry_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_CreditsEntry_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_CreditsEntry_Widget_C(a[i].Pointer); return r; }
        public Spacer EndCreditSpacer { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new Spacer(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock RichEntryText { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Paddings => AddrOf(0x248); // 
        public void EnableSpacer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EnableSpacer", __pb.Bytes);
        }
        public void SetEntry(byte EntryStyle, global::System.IntPtr Text, global::System.IntPtr Image)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set(0x0, EntryStyle);
            __pb.Set<global::System.IntPtr>(0x8, Text);
            __pb.Set<global::System.IntPtr>(0x18, Image);
            CallRaw("SetEntry", __pb.Bytes);
        }
    }

}
