// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/HelpSectionButton
using System;

namespace UEModLoader.Game
{
    public class HelpSectionButton_C : Actor
    {
        public const string UeClassName = "HelpSectionButton_C";
        public HelpSectionButton_C(System.IntPtr ptr) : base(ptr) {}
        public static new HelpSectionButton_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new HelpSectionButton_C(p);
        public static HelpSectionButton_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new HelpSectionButton_C(o.Pointer); }
        public static HelpSectionButton_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new HelpSectionButton_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new HelpSectionButton_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public VR4UIButtonComponent VR4UIButton { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ScaleRoot { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Scale_Alpha_068D599E48F4FFB388CD78893FBE4C9F { get => GetAt<float>(0x248); set => SetAt(0x248, value); }
        public byte Timeline_Scale__Direction_068D599E48F4FFB388CD78893FBE4C9F { get => GetAt<byte>(0x24C); set => SetAt(0x24C, value); }
        public TimelineComponent Timeline_Scale { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public string ManualEntry => Native.GetPropName(Pointer, "ManualEntry"); // FName
        public FName ManualEntry_Raw { get => GetAt<FName>(0x258); set => SetAt(0x258, value); }
        public bool Enabled { get => Native.GetPropBool(Pointer, "Enabled"); set => Native.SetPropBool(Pointer, "Enabled", value); }
        public VR4UIScreen ParentMenu { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public HelpSectionWidget_C HelpSectionWidget { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new HelpSectionWidget_C(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr HelpButonPressed => AddrOf(0x278); // 
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
        public void Timeline_Scale__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Scale__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Scale__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Scale__UpdateFunc", __pb.Bytes);
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
        public void ScaleUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ScaleUp", __pb.Bytes);
        }
        public void Scaledown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Scaledown", __pb.Bytes);
        }
        public void ExecuteUbergraph_HelpSectionButton(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_HelpSectionButton", __pb.Bytes);
        }
        public void HelpButonPressed__DelegateSignature(FName ManualEntry)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, ManualEntry);
            CallRaw("HelpButonPressed__DelegateSignature", __pb.Bytes);
        }
    }

}
