// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/LoadGameEntry_BP
using System;

namespace UEModLoader.Game
{
    public class LoadGameEntry_BP_C : Actor
    {
        public const string UeClassName = "LoadGameEntry_BP_C";
        public LoadGameEntry_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new LoadGameEntry_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LoadGameEntry_BP_C(p);
        public static LoadGameEntry_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LoadGameEntry_BP_C(o.Pointer); }
        public static LoadGameEntry_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LoadGameEntry_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LoadGameEntry_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget_Entry { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public bool CurrentlySelected { get => Native.GetPropBool(Pointer, "CurrentlySelected"); set => Native.SetPropBool(Pointer, "CurrentlySelected", value); }
        public int Index { get => GetAt<int>(0x244); set => SetAt(0x244, value); }
        public int SaveChapter { get => GetAt<int>(0x248); set => SetAt(0x248, value); }
        public int SaveSection { get => GetAt<int>(0x24C); set => SetAt(0x24C, value); }
        public UI_LoadGame_Entry_Widget_C Ref_Entry_Widget { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new UI_LoadGame_Entry_Widget_C(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public void SetEntryText(bool SetEntryBlank, int Index, System.IntPtr Chapter, int Saves, System.IntPtr Time, int Round, EGameMode Mode, bool IsEndGameSave)
        {
            var __pb = new ParamBuffer(70);
            __pb.Set<byte>(0x0, (byte)(SetEntryBlank?1:0));
            __pb.Set(0x4, Index);
            __pb.Set<System.IntPtr>(0x8, Chapter);
            __pb.Set(0x20, Saves);
            __pb.Set<System.IntPtr>(0x28, Time);
            __pb.Set(0x40, Round);
            __pb.Set<byte>(0x44, (byte)Mode);
            __pb.Set<byte>(0x45, (byte)(IsEndGameSave?1:0));
            CallRaw("SetEntryText", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void UnSelected()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnSelected", __pb.Bytes);
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
        public void ForceClick()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ForceClick", __pb.Bytes);
        }
        public void ExecuteUbergraph_LoadGameEntry_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_LoadGameEntry_BP", __pb.Bytes);
        }
    }

}
