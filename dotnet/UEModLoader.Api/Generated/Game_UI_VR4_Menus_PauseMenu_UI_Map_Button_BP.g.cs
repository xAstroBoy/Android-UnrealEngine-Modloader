// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Map_Button_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Map_Button_BP_C : Actor
    {
        public const string UeClassName = "UI_Map_Button_BP_C";
        public UI_Map_Button_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Map_Button_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Map_Button_BP_C(p);
        public static UI_Map_Button_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Map_Button_BP_C(o.Pointer); }
        public static UI_Map_Button_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Map_Button_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Map_Button_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public VR4UIButtonComponent Button { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Flash_Alpha_76DC87F947F4FFFC60CA8192D854A232 { get => GetAt<float>(0x240); set => SetAt(0x240, value); }
        public byte Timeline_Flash__Direction_76DC87F947F4FFFC60CA8192D854A232 { get => GetAt<byte>(0x244); set => SetAt(0x244, value); }
        public TimelineComponent Timeline_Flash { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr ButtonText => AddrOf(0x250); // 
        public EVR4MapMode MapMode { get => (EVR4MapMode)GetAt<byte>(0x268); set => SetAt(0x268, (byte)value); }
        public bool Enabled { get => Native.GetPropBool(Pointer, "Enabled"); set => Native.SetPropBool(Pointer, "Enabled", value); }
        public UI_Map_Button_Widget_C Ref_Button_Widget { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new UI_Map_Button_Widget_C(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public void Timeline_Flash__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Flash__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Flash__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Flash__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__Button_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__Button_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void UpdateButtonState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateButtonState", __pb.Bytes);
        }
        public void BndEvt__Button_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__Button_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__Button_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__Button_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void FlashWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlashWidget", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Map_Button_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Map_Button_BP", __pb.Bytes);
        }
    }

}
