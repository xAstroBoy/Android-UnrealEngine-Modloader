// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/OptionsScreen_Menu
using System;

namespace UEModLoader.Game
{
    public class OptionsScreen_Menu_C : Actor
    {
        public const string UeClassName = "OptionsScreen_Menu_C";
        public OptionsScreen_Menu_C(System.IntPtr ptr) : base(ptr) {}
        public static new OptionsScreen_Menu_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OptionsScreen_Menu_C(p);
        public static OptionsScreen_Menu_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OptionsScreen_Menu_C(o.Pointer); }
        public static OptionsScreen_Menu_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OptionsScreen_Menu_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OptionsScreen_Menu_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public VR4UIButtonComponent DownArrowButton { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent UpArrowButton { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Heading { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent BackButton { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIScrollComponent Scroll { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new VR4UIScrollComponent(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public string menuName => Native.GetPropName(Pointer, "menuName"); // FName
        public FName menuName_Raw { get => GetAt<FName>(0x258); set => SetAt(0x258, value); }
        public VR4MenuEntryDescription Description => new VR4MenuEntryDescription(AddrOf(0x260));
        public OptionsUIScreen_BP_C OptionsScreen { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new OptionsUIScreen_BP_C(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Options_BG_Widget_C Ref_WidgetHeading { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new UI_Options_BG_Widget_C(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public bool isNewGameMenu_ { get => Native.GetPropBool(Pointer, "isNewGameMenu?"); set => Native.SetPropBool(Pointer, "isNewGameMenu?", value); }
        public bool isScrolling { get => Native.GetPropBool(Pointer, "isScrolling"); set => Native.SetPropBool(Pointer, "isScrolling", value); }
        public float targetScrollAmount { get => GetAt<float>(0x314); set => SetAt(0x314, value); }
        public float currentScrollAmount { get => GetAt<float>(0x318); set => SetAt(0x318, value); }
        public byte scrollDirection { get => GetAt<byte>(0x31C); set => SetAt(0x31C, value); }
        public float scrollAmount { get => GetAt<float>(0x320); set => SetAt(0x320, value); }
        public float currentScrollDelay { get => GetAt<float>(0x324); set => SetAt(0x324, value); }
        public float scrollDelay { get => GetAt<float>(0x328); set => SetAt(0x328, value); }
        public float scrollSpeed { get => GetAt<float>(0x32C); set => SetAt(0x32C, value); }
        public bool MenuActive { get => Native.GetPropBool(Pointer, "MenuActive"); set => Native.SetPropBool(Pointer, "MenuActive", value); }
        public VR4GameInstance_BP_C GameInstance { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new VR4GameInstance_BP_C(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public bool UseMercColors { get => Native.GetPropBool(Pointer, "UseMercColors"); set => Native.SetPropBool(Pointer, "UseMercColors", value); }
        public void RestoreLastPostion()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RestoreLastPostion", __pb.Bytes);
        }
        public void UpdateLastPosition()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateLastPosition", __pb.Bytes);
        }
        public void CalculateArrowScroll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CalculateArrowScroll", __pb.Bytes);
        }
        public void ProcessArrowScroll(float DeltaTime)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaTime);
            CallRaw("ProcessArrowScroll", __pb.Bytes);
        }
        public void Update_Scrolling(VR4UIScrollComponent ScrollComponent)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ScrollComponent);
            CallRaw("Update Scrolling", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__BackButton_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__BackButton_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__BackButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__BackButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__BackButton_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__BackButton_K2Node_ComponentBoundEvent_2_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__Scroll_K2Node_ComponentBoundEvent_3_ScrollComponentUpdated__DelegateSignature(VR4UIScrollComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__Scroll_K2Node_ComponentBoundEvent_3_ScrollComponentUpdated__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_4_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_7_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_8_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_8_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_9_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_9_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_11_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_11_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_12_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_12_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_10_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__DownArrowButton_K2Node_ComponentBoundEvent_10_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__UpArrowButton_K2Node_ComponentBoundEvent_13_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void FinishArrowScrolling()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FinishArrowScrolling", __pb.Bytes);
        }
        public void ExecuteUbergraph_OptionsScreen_Menu(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_OptionsScreen_Menu", __pb.Bytes);
        }
    }

}
