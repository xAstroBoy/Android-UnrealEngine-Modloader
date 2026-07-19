// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Frontend/Buttons/Button_Main
using System;

namespace UEModLoader.Game
{
    public class Button_Main_C : Actor
    {
        public const string UeClassName = "Button_Main_C";
        public Button_Main_C(System.IntPtr ptr) : base(ptr) {}
        public static new Button_Main_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Button_Main_C(p);
        public static Button_Main_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Button_Main_C(o.Pointer); }
        public static Button_Main_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Button_Main_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Button_Main_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr DisplayText => AddrOf(0x240); // 
        public int ButtonId { get => GetAt<int>(0x258); set => SetAt(0x258, value); }
        public Vector2D Size => new Vector2D(AddrOf(0x25C));
        public Button_MainWidget_C ButtonWidget { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Button_MainWidget_C(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x270); // struct Button_Main_Atr
        public bool Enabled { get => Native.GetPropBool(Pointer, "Enabled"); set => Native.SetPropBool(Pointer, "Enabled", value); }
        public System.IntPtr ButtonPressed => AddrOf(0x2F8); // 
        public VR4UIScreen ParentMenu { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public bool ProperScaling { get => Native.GetPropBool(Pointer, "ProperScaling"); set => Native.SetPropBool(Pointer, "ProperScaling", value); }
        public void SetMercColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercColors", __pb.Bytes);
        }
        public void EnableButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EnableButton", __pb.Bytes);
        }
        public void DisableButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableButton", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_3_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_3_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_Button_Main(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Button_Main", __pb.Bytes);
        }
        public void ButtonPressed__DelegateSignature(int ButtonId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ButtonId);
            CallRaw("ButtonPressed__DelegateSignature", __pb.Bytes);
        }
    }

}
