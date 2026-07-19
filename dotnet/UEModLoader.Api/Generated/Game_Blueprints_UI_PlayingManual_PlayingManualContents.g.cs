// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualContents
using System;

namespace UEModLoader.Game
{
    public class PlayingManualContents_C : VR4UIScreen
    {
        public const string UeClassName = "PlayingManualContents_C";
        public PlayingManualContents_C(System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualContents_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PlayingManualContents_C(p);
        public static PlayingManualContents_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualContents_C(o.Pointer); }
        public static PlayingManualContents_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualContents_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualContents_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public VR4UIButtonComponent VR4UIButton9 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton8 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton7 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton6 { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton5 { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton4 { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton3 { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton2 { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton1 { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton0 { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4MenuComponent VR4Menu { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new VR4MenuComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualContents_Widget_C Contents { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new PlayingManualContents_Widget_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> ValidCategories => new TArray<System.IntPtr>(AddrOf(0x2C8)); // TArray<FName>
        public bool SelectionMade { get => Native.GetPropBool(Pointer, "SelectionMade"); set => Native.SetPropBool(Pointer, "SelectionMade", value); }
        public UI_PauseMenu_Content_PlayingManual_BP_C ContentParent { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Content_PlayingManual_BP_C(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool MercColors { get => Native.GetPropBool(Pointer, "MercColors"); set => Native.SetPropBool(Pointer, "MercColors", value); }
        public void ParseManualText(System.IntPtr Text, System.IntPtr ParsedText)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, Text);
            __pb.Set<System.IntPtr>(0x18, ParsedText);
            CallRaw("ParseManualText", __pb.Bytes);
        }
        public void Reset()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Reset", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void ButtonSetup()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ButtonSetup", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnClicked0(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked0", __pb.Bytes);
        }
        public void OnUnhovered0(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered0", __pb.Bytes);
        }
        public void OnHovered0(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered0", __pb.Bytes);
        }
        public void OnClicked1(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked1", __pb.Bytes);
        }
        public void OnUnhovered1(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered1", __pb.Bytes);
        }
        public void OnHovered1(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered1", __pb.Bytes);
        }
        public void OnClicked2(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked2", __pb.Bytes);
        }
        public void OnUnhovered2(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered2", __pb.Bytes);
        }
        public void OnHovered2(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered2", __pb.Bytes);
        }
        public void OnClicked3(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked3", __pb.Bytes);
        }
        public void OnUnhovered3(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered3", __pb.Bytes);
        }
        public void OnHovered3(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered3", __pb.Bytes);
        }
        public void OnClicked4(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked4", __pb.Bytes);
        }
        public void OnUnhovered4(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered4", __pb.Bytes);
        }
        public void OnHovered4(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered4", __pb.Bytes);
        }
        public void OnClicked5(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked5", __pb.Bytes);
        }
        public void OnUnhovered5(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered5", __pb.Bytes);
        }
        public void OnHovered5(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered5", __pb.Bytes);
        }
        public void OnClicked6(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked6", __pb.Bytes);
        }
        public void OnUnhovered6(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered6", __pb.Bytes);
        }
        public void OnHovered6(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered6", __pb.Bytes);
        }
        public void OnClicked7(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked7", __pb.Bytes);
        }
        public void OnUnhovered7(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered7", __pb.Bytes);
        }
        public void OnHovered7(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered7", __pb.Bytes);
        }
        public void OnClicked8(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked8", __pb.Bytes);
        }
        public void OnUnhovered8(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered8", __pb.Bytes);
        }
        public void OnHovered8(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered8", __pb.Bytes);
        }
        public void OnClicked9(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClicked9", __pb.Bytes);
        }
        public void OnUnhovered9(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhovered9", __pb.Bytes);
        }
        public void OnHovered9(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHovered9", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualContents(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualContents", __pb.Bytes);
        }
    }

}
