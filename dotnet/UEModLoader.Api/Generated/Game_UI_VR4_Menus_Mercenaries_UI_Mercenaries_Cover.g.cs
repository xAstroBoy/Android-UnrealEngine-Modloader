// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/Mercenaries/UI_Mercenaries_Cover
using System;

namespace UEModLoader.Game
{
    public class UI_Mercenaries_Cover_C : VR4UIScreen
    {
        public const string UeClassName = "UI_Mercenaries_Cover_C";
        public UI_Mercenaries_Cover_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Mercenaries_Cover_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Mercenaries_Cover_C(p);
        public static UI_Mercenaries_Cover_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Mercenaries_Cover_C(o.Pointer); }
        public static UI_Mercenaries_Cover_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Mercenaries_Cover_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Mercenaries_Cover_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public StaticMeshComponent MercLogo { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton0 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4MenuComponent VR4Menu { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new VR4MenuComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Sweep_Alpha_8F8378664FC6F1CBB5708582F96DDB32 { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public byte Timeline_Sweep__Direction_8F8378664FC6F1CBB5708582F96DDB32 { get => GetAt<byte>(0x28C); set => SetAt(0x28C, value); }
        public TimelineComponent Timeline_Sweep { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public bool SelectionMade { get => Native.GetPropBool(Pointer, "SelectionMade"); set => Native.SetPropBool(Pointer, "SelectionMade", value); }
        public MercCoverWidget_C MercCover { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new MercCoverWidget_C(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_PauseMenu_Content_Mercenaries_BP_C MercContent { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Content_Mercenaries_BP_C(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_PauseMenu_Single_C Parent { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Single_C(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
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
        public void Timeline_Sweep__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Sweep__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Sweep__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Sweep__UpdateFunc", __pb.Bytes);
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
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void PlaySweep()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlaySweep", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Mercenaries_Cover(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Mercenaries_Cover", __pb.Bytes);
        }
    }

}
