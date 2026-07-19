// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Header_Button
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Header_Button_C : Actor
    {
        public const string UeClassName = "UI_PauseMenu_Header_Button_C";
        public UI_PauseMenu_Header_Button_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Header_Button_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Header_Button_C(p);
        public static UI_PauseMenu_Header_Button_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Header_Button_C(o.Pointer); }
        public static UI_PauseMenu_Header_Button_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Header_Button_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Header_Button_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget_Icon { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh_BackingPlate { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent Button { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_NewIndicator_Alpha_737E5DB2460A4FADC0ECA9A96AD35819 { get => GetAt<float>(0x248); set => SetAt(0x248, value); }
        public byte Timeline_NewIndicator__Direction_737E5DB2460A4FADC0ECA9A96AD35819 { get => GetAt<byte>(0x24C); set => SetAt(0x24C, value); }
        public TimelineComponent Timeline_NewIndicator { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Pulse_Alpha_0A40CFC04CBEA736AFD8C385690283DE { get => GetAt<float>(0x258); set => SetAt(0x258, value); }
        public byte Timeline_Pulse__Direction_0A40CFC04CBEA736AFD8C385690283DE { get => GetAt<byte>(0x25C); set => SetAt(0x25C, value); }
        public TimelineComponent Timeline_Pulse { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Flickeroff_BigFlash_0F6B59EC482BB87A5169A6883F0D88AF { get => GetAt<float>(0x268); set => SetAt(0x268, value); }
        public float Timeline_Flickeroff_FlickerHighlight_0F6B59EC482BB87A5169A6883F0D88AF { get => GetAt<float>(0x26C); set => SetAt(0x26C, value); }
        public float Timeline_Flickeroff_Flicker_0F6B59EC482BB87A5169A6883F0D88AF { get => GetAt<float>(0x270); set => SetAt(0x270, value); }
        public byte Timeline_Flickeroff__Direction_0F6B59EC482BB87A5169A6883F0D88AF { get => GetAt<byte>(0x274); set => SetAt(0x274, value); }
        public TimelineComponent Timeline_Flickeroff { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_FlickerOn_BigFlash_9783AFD74A7A3D7CA6CAD79DBED9130A { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public float Timeline_FlickerOn_FlickerHighlight_9783AFD74A7A3D7CA6CAD79DBED9130A { get => GetAt<float>(0x284); set => SetAt(0x284, value); }
        public float Timeline_FlickerOn_FlickerIcon_9783AFD74A7A3D7CA6CAD79DBED9130A { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public byte Timeline_FlickerOn__Direction_9783AFD74A7A3D7CA6CAD79DBED9130A { get => GetAt<byte>(0x28C); set => SetAt(0x28C, value); }
        public TimelineComponent Timeline_FlickerOn { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Texture2D Icon_Tab { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_PauseMenu_Tab_Widget_C Ref_Tab_Widget { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Tab_Widget_C(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public byte MenuSelection { get => GetAt<byte>(0x2A8); set => SetAt(0x2A8, value); }
        public bool isFirstSelection { get => Native.GetPropBool(Pointer, "isFirstSelection"); set => Native.SetPropBool(Pointer, "isFirstSelection", value); }
        public Texture2D Icon_Tab_Highlight { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsSelected { get => Native.GetPropBool(Pointer, "IsSelected"); set => Native.SetPropBool(Pointer, "IsSelected", value); }
        public StaticMesh BackingPlate { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsNarrowTab { get => Native.GetPropBool(Pointer, "IsNarrowTab"); set => Native.SetPropBool(Pointer, "IsNarrowTab", value); }
        public bool IsToggleable { get => Native.GetPropBool(Pointer, "IsToggleable"); set => Native.SetPropBool(Pointer, "IsToggleable", value); }
        public global::System.IntPtr TabTitle => AddrOf(0x2D0); // 
        public global::System.IntPtr Clicked => AddrOf(0x2E8); // 
        public UI_PauseMenu_Header_Base_BP_C Ref_Parent_Header { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Header_Base_BP_C(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsHovered { get => Native.GetPropBool(Pointer, "IsHovered"); set => Native.SetPropBool(Pointer, "IsHovered", value); }
        public void SetTitle(global::System.IntPtr NewTitle)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, NewTitle);
            CallRaw("SetTitle", __pb.Bytes);
        }
        public void AnimationComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AnimationComplete", __pb.Bytes);
        }
        public void SetSelectedState(bool _IsSelected)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(_IsSelected?1:0));
            CallRaw("SetSelectedState", __pb.Bytes);
        }
        public void UserConstructionScript()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UserConstructionScript", __pb.Bytes);
        }
        public void Timeline_FlickerOn__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FlickerOn__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_FlickerOn__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FlickerOn__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_FlickerOn__FlashColor__EventFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FlickerOn__FlashColor__EventFunc", __pb.Bytes);
        }
        public void Timeline_FlickerOn__SetColor__EventFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FlickerOn__SetColor__EventFunc", __pb.Bytes);
        }
        public void Timeline_Flickeroff__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Flickeroff__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Flickeroff__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Flickeroff__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Pulse__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Pulse__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Pulse__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Pulse__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_NewIndicator__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_NewIndicator__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_NewIndicator__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_NewIndicator__UpdateFunc", __pb.Bytes);
        }
        public void OnClick(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("OnClick", __pb.Bytes);
        }
        public void OnHover(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHover", __pb.Bytes);
        }
        public void OnUnhover(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhover", __pb.Bytes);
        }
        public void FlickerOn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlickerOn", __pb.Bytes);
        }
        public void FlickerOff()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlickerOff", __pb.Bytes);
        }
        public void PulseOn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PulseOn", __pb.Bytes);
        }
        public void PulseOff()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PulseOff", __pb.Bytes);
        }
        public void HideButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideButton", __pb.Bytes);
        }
        public void ForceFlickerOff()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ForceFlickerOff", __pb.Bytes);
        }
        public void ShowNewIndicator()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowNewIndicator", __pb.Bytes);
        }
        public void HideNewIndicator()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideNewIndicator", __pb.Bytes);
        }
        public void ForceFlickerOn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ForceFlickerOn", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void Button_Unselected()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Button_Unselected", __pb.Bytes);
        }
        public void Button_Selected()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Button_Selected", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Header_Button(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Header_Button", __pb.Bytes);
        }
        public void Clicked__DelegateSignature(UI_PauseMenu_Header_Button_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("Clicked__DelegateSignature", __pb.Bytes);
        }
    }

}
