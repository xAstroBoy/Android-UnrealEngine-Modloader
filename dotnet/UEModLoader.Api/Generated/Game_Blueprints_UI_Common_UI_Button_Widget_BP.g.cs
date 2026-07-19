// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Common/UI_Button_Widget_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Button_Widget_BP_C : UserWidget
    {
        public const string UeClassName = "UI_Button_Widget_BP_C";
        public UI_Button_Widget_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Button_Widget_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Button_Widget_BP_C(p);
        public static UI_Button_Widget_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Button_Widget_BP_C(o.Pointer); }
        public static UI_Button_Widget_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Button_Widget_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Button_Widget_BP_C(a[i].Pointer); return r; }
        public System.IntPtr Text => AddrOf(0x230); // 
        public bool ToggleState { get => Native.GetPropBool(Pointer, "ToggleState"); set => Native.SetPropBool(Pointer, "ToggleState", value); }
        public bool HighlightState { get => Native.GetPropBool(Pointer, "HighlightState"); set => Native.SetPropBool(Pointer, "HighlightState", value); }
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
        public void SetText(System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Text);
            CallRaw("SetText", __pb.Bytes);
        }
        public void Disable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Disable", __pb.Bytes);
        }
        public void enable()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("enable", __pb.Bytes);
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
    }

}
