// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/OptionsScreen_Slider
using System;

namespace UEModLoader.Game
{
    public class OptionsScreen_Slider_C : Actor
    {
        public const string UeClassName = "OptionsScreen_Slider_C";
        public OptionsScreen_Slider_C(System.IntPtr ptr) : base(ptr) {}
        public static new OptionsScreen_Slider_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OptionsScreen_Slider_C(p);
        public static OptionsScreen_Slider_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OptionsScreen_Slider_C(o.Pointer); }
        public static OptionsScreen_Slider_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OptionsScreen_Slider_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OptionsScreen_Slider_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UISliderComponent VR4UISlider { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new VR4UISliderComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Options_Slider_Widget_C Ref_SliderWidget { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new UI_Options_Slider_Widget_C(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public OptionsScreen_Button_C Ref_ParentButton { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new OptionsScreen_Button_C(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public float CurrentThresholdValue { get => GetAt<float>(0x250); set => SetAt(0x250, value); }
        public int NewValue { get => GetAt<int>(0x254); set => SetAt(0x254, value); }
        public bool isChanging { get => Native.GetPropBool(Pointer, "isChanging"); set => Native.SetPropBool(Pointer, "isChanging", value); }
        public bool UseMercColors { get => Native.GetPropBool(Pointer, "UseMercColors"); set => Native.SetPropBool(Pointer, "UseMercColors", value); }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_0_SliderComponentValueChanged__DelegateSignature(VR4UISliderComponent component, int Value)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, component);
            __pb.Set(0x8, Value);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_0_SliderComponentValueChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void SetParentReference(Actor ParentReference)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ParentReference);
            CallRaw("SetParentReference", __pb.Bytes);
        }
        public void Set_Slider_Display_Text(System.IntPtr New_Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, New_Text);
            CallRaw("Set Slider Display Text", __pb.Bytes);
        }
        public void Enable_Slider_Display_Text()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Enable Slider Display Text", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_3_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_3_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_5_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UISlider_K2Node_ComponentBoundEvent_5_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void DelayedUpdate()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DelayedUpdate", __pb.Bytes);
        }
        public void ExecuteUbergraph_OptionsScreen_Slider(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_OptionsScreen_Slider", __pb.Bytes);
        }
    }

}
