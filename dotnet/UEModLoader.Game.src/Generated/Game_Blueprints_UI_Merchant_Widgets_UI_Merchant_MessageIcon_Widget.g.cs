// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_MessageIcon_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_MessageIcon_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Merchant_MessageIcon_Widget_C";
        public UI_Merchant_MessageIcon_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_MessageIcon_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_MessageIcon_Widget_C(p);
        public static UI_Merchant_MessageIcon_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_MessageIcon_Widget_C(o.Pointer); }
        public static UI_Merchant_MessageIcon_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_MessageIcon_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_MessageIcon_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation ScaleAnimation { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation Pulse { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Icon_QuestionMark { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Ring { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void Finished_A21542A543EF969E240602AC496245BB()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_A21542A543EF969E240602AC496245BB", __pb.Bytes);
        }
        public void Finished_CCEA591D4EE6FEC8CB593E960F4DD16C()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_CCEA591D4EE6FEC8CB593E960F4DD16C", __pb.Bytes);
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
        public void IconPulse(bool ShowPulse)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(ShowPulse?1:0));
            CallRaw("IconPulse", __pb.Bytes);
        }
        public void PlayIntro(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("PlayIntro", __pb.Bytes);
        }
        public void PlayOutro(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("PlayOutro", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_MessageIcon_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_MessageIcon_Widget", __pb.Bytes);
        }
    }

}
