// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/OptionsScreen_Button
using System;

namespace UEModLoader.Game
{
    public class OptionsScreen_Button_C : Actor
    {
        public const string UeClassName = "OptionsScreen_Button_C";
        public OptionsScreen_Button_C(System.IntPtr ptr) : base(ptr) {}
        public static new OptionsScreen_Button_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OptionsScreen_Button_C(p);
        public static OptionsScreen_Button_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OptionsScreen_Button_C(o.Pointer); }
        public static OptionsScreen_Button_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OptionsScreen_Button_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OptionsScreen_Button_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public VR4UIButtonComponent ToggleButton { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent SliderAttach { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Button { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Entry { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Option { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Button { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent ButtonButton { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4MenuEntryHandle Handle => new VR4MenuEntryHandle(AddrOf(0x268));
        public OptionsUIScreen_BP_C OptionsScreen { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new OptionsUIScreen_BP_C(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Options_Button_Widget_C Ref_WidgetButton { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new UI_Options_Button_Widget_C(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Options_Entry_Widget_C Ref_WidgetEntry { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new UI_Options_Entry_Widget_C(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public OptionsScreen_Slider_C SliderActor { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new OptionsScreen_Slider_C(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr OptionsButtonHovered => AddrOf(0x290); // 
        public System.IntPtr OptionsButtonUnHovered => AddrOf(0x2A0); // 
        public int CurrentToggleValue { get => GetAt<int>(0x2B0); set => SetAt(0x2B0, value); }
        public bool UseMercColors { get => Native.GetPropBool(Pointer, "UseMercColors"); set => Native.SetPropBool(Pointer, "UseMercColors", value); }
        public int IndexOffset { get => GetAt<int>(0x2B8); set => SetAt(0x2B8, value); }
        public void UpdateColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateColors", __pb.Bytes);
        }
        public void SetUnderlineVisible(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("SetUnderlineVisible", __pb.Bytes);
        }
        public void Update(int elementIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, elementIndex);
            CallRaw("Update", __pb.Bytes);
        }
        public void Initialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void LinkPressed(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("LinkPressed", __pb.Bytes);
        }
        public void ButtonPressed(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("ButtonPressed", __pb.Bytes);
        }
        public void ToggleUpPressed(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("ToggleUpPressed", __pb.Bytes);
        }
        public void ToggleDownPressed(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("ToggleDownPressed", __pb.Bytes);
        }
        public void SliderValueChanged(VR4UISliderComponent component, int Value)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, component);
            __pb.Set(0x8, Value);
            CallRaw("SliderValueChanged", __pb.Bytes);
        }
        public void ButtonHovered(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("ButtonHovered", __pb.Bytes);
        }
        public void ButtonUnhovered(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("ButtonUnhovered", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void ToggleValueChanged(int NewToggleValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewToggleValue);
            CallRaw("ToggleValueChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_OptionsScreen_Button(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_OptionsScreen_Button", __pb.Bytes);
        }
        public void OptionsButtonUnHovered__DelegateSignature(VR4MenuEntryHandle Handle)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Handle);
            CallRaw("OptionsButtonUnHovered__DelegateSignature", __pb.Bytes);
        }
        public void OptionsButtonHovered__DelegateSignature(VR4MenuEntryHandle Handle)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Handle);
            CallRaw("OptionsButtonHovered__DelegateSignature", __pb.Bytes);
        }
    }

}
