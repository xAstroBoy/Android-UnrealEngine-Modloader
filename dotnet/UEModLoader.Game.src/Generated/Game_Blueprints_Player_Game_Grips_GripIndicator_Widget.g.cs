// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Grips/GripIndicator_Widget
using System;

namespace UEModLoader.Game
{
    public class GripIndicator_Widget_C : VR4GamePlayerGripIndicatorWidget
    {
        public const string UeClassName = "GripIndicator_Widget_C";
        public GripIndicator_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new GripIndicator_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GripIndicator_Widget_C(p);
        public static GripIndicator_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GripIndicator_Widget_C(o.Pointer); }
        public static GripIndicator_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GripIndicator_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GripIndicator_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x260));
        public WidgetAnimation ShrinkToDot { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation GrowToRing { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image CircleImage { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image dot { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LinearColor NormalColor => new LinearColor(AddrOf(0x288));
        public LinearColor HoverColor => new LinearColor(AddrOf(0x298));
        public Vector2D NormalScale => new Vector2D(AddrOf(0x2A8));
        public Vector2D HoverScale => new Vector2D(AddrOf(0x2B0));
        public bool hovering { get => Native.GetPropBool(Pointer, "hovering"); set => Native.SetPropBool(Pointer, "hovering", value); }
        public bool TutorialActive { get => Native.GetPropBool(Pointer, "TutorialActive"); set => Native.SetPropBool(Pointer, "TutorialActive", value); }
        public bool UseNewAnimations { get => Native.GetPropBool(Pointer, "UseNewAnimations"); set => Native.SetPropBool(Pointer, "UseNewAnimations", value); }
        public void SetParameters(global::System.IntPtr Color, global::System.IntPtr Scale)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Color);
            __pb.Set<global::System.IntPtr>(0x10, Scale);
            CallRaw("SetParameters", __pb.Bytes);
        }
        public void BeginHover()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BeginHover", __pb.Bytes);
        }
        public void EndHover()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndHover", __pb.Bytes);
        }
        public void ShowDot()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowDot", __pb.Bytes);
        }
        public void TutorialStart()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TutorialStart", __pb.Bytes);
        }
        public void TutorialEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TutorialEnd", __pb.Bytes);
        }
        public void OnInitialized()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnInitialized", __pb.Bytes);
        }
        public void SetRingScale(float Scale)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Scale);
            CallRaw("SetRingScale", __pb.Bytes);
        }
        public void SetDotVisible(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("SetDotVisible", __pb.Bytes);
        }
        public void ExecuteUbergraph_GripIndicator_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_GripIndicator_Widget", __pb.Bytes);
        }
    }

}
