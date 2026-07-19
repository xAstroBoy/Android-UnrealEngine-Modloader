// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Common/UI_Button_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Button_BP_C : Actor
    {
        public const string UeClassName = "UI_Button_BP_C";
        public UI_Button_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Button_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Button_BP_C(p);
        public static UI_Button_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Button_BP_C(o.Pointer); }
        public static UI_Button_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Button_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Button_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public VR4UIButtonComponent VRUIButton { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr OnClick => AddrOf(0x248); // 
        public System.IntPtr OnHover => AddrOf(0x258); // 
        public System.IntPtr OnUnhover => AddrOf(0x268); // 
        public bool HighlightOnHover { get => Native.GetPropBool(Pointer, "HighlightOnHover"); set => Native.SetPropBool(Pointer, "HighlightOnHover", value); }
        public System.IntPtr Text => AddrOf(0x280); // 
        public UI_Button_Widget_BP_C Ref_Widget { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new UI_Button_Widget_BP_C(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public bool IsToggle { get => Native.GetPropBool(Pointer, "IsToggle"); set => Native.SetPropBool(Pointer, "IsToggle", value); }
        public bool ToggleState { get => Native.GetPropBool(Pointer, "ToggleState"); set => Native.SetPropBool(Pointer, "ToggleState", value); }
        public System.IntPtr OnToggle => AddrOf(0x2A8); // 
        public bool Highlighted { get => Native.GetPropBool(Pointer, "Highlighted"); set => Native.SetPropBool(Pointer, "Highlighted", value); }
        public System.IntPtr OnPress => AddrOf(0x2C0); // 
        public VR4UIClickState LastClickState => new VR4UIClickState(AddrOf(0x2D0));
        public bool Hovered { get => Native.GetPropBool(Pointer, "Hovered"); set => Native.SetPropBool(Pointer, "Hovered", value); }
        public void SetHighlighted(bool Highlighted)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Highlighted?1:0));
            CallRaw("SetHighlighted", __pb.Bytes);
        }
        public void Unregister(VR4UIScreen Screen)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Screen);
            CallRaw("Unregister", __pb.Bytes);
        }
        public void Register(VR4UIScreen Screen)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Screen);
            CallRaw("Register", __pb.Bytes);
        }
        public void SetVisible(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("SetVisible", __pb.Bytes);
        }
        public void SetToggleState(bool NewState)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(NewState?1:0));
            CallRaw("SetToggleState", __pb.Bytes);
        }
        public void Toggle()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Toggle", __pb.Bytes);
        }
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
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__VRUIButton_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VRUIButton_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VRUIButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VRUIButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VRUIButton_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VRUIButton_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VRUIButton_K2Node_ComponentBoundEvent_3_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VRUIButton_K2Node_ComponentBoundEvent_3_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Button_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Button_BP", __pb.Bytes);
        }
        public void OnPress__DelegateSignature(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("OnPress__DelegateSignature", __pb.Bytes);
        }
        public void OnToggle__DelegateSignature(UI_Button_BP_C Button, bool ToggleState)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Button);
            __pb.Set<byte>(0x8, (byte)(ToggleState?1:0));
            CallRaw("OnToggle__DelegateSignature", __pb.Bytes);
        }
        public void OnUnhover__DelegateSignature(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("OnUnhover__DelegateSignature", __pb.Bytes);
        }
        public void OnHover__DelegateSignature(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("OnHover__DelegateSignature", __pb.Bytes);
        }
        public void OnClick__DelegateSignature(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("OnClick__DelegateSignature", __pb.Bytes);
        }
    }

}
