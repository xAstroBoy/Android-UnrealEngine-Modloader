// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/HUD/UI_HealthVignette_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_HealthVignette_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_HealthVignette_Widget_C";
        public UI_HealthVignette_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_HealthVignette_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_HealthVignette_Widget_C(p);
        public static UI_HealthVignette_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_HealthVignette_Widget_C(o.Pointer); }
        public static UI_HealthVignette_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_HealthVignette_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_HealthVignette_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public CanvasPanel Canvas_HealthStatus { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Label_HealthStatus { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SlateColor TextColor_Red => new SlateColor(AddrOf(0x248));
        public SlateColor TextColor_Invisible => new SlateColor(AddrOf(0x270));
        public void FadeIn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeIn", __pb.Bytes);
        }
        public void FadeOut()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeOut", __pb.Bytes);
        }
        public void SetAlpha(float NewAlpha)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewAlpha);
            CallRaw("SetAlpha", __pb.Bytes);
        }
        public void SetText(global::System.IntPtr newText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, newText);
            CallRaw("SetText", __pb.Bytes);
        }
        public void SetTextAndColor(global::System.IntPtr newText, global::System.IntPtr Color)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<global::System.IntPtr>(0x0, newText);
            __pb.Set<global::System.IntPtr>(0x18, Color);
            CallRaw("SetTextAndColor", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_HealthVignette_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_HealthVignette_Widget", __pb.Bytes);
        }
    }

}
