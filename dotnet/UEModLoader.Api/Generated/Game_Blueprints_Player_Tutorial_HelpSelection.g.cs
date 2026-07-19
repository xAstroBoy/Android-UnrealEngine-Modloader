// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/HelpSelection
using System;

namespace UEModLoader.Game
{
    public class HelpSelection_C : VR4UIScreen
    {
        public const string UeClassName = "HelpSelection_C";
        public HelpSelection_C(System.IntPtr ptr) : base(ptr) {}
        public static new HelpSelection_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new HelpSelection_C(p);
        public static HelpSelection_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new HelpSelection_C(o.Pointer); }
        public static HelpSelection_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new HelpSelection_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new HelpSelection_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public SceneComponent RightPanel { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Info { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent LeftPanel { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent LowerTray { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Center { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public Actor BindingActor { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent HelpButton { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public EPauseMenuScreen ActiveTab { get => (EPauseMenuScreen)GetAt<byte>(0x298); set => SetAt(0x298, (byte)value); }
        public int KeysMenuIndex { get => GetAt<int>(0x29C); set => SetAt(0x29C, value); }
        public TArray<System.IntPtr> ButtonList => new TArray<System.IntPtr>(AddrOf(0x2A0)); // TArray<UObject*>
        public UI_PauseMenu_Header_BP_C Header { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Header_BP_C(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool Exiting { get => Native.GetPropBool(Pointer, "Exiting"); set => Native.SetPropBool(Pointer, "Exiting", value); }
        public bool SelectionActive { get => Native.GetPropBool(Pointer, "SelectionActive"); set => Native.SetPropBool(Pointer, "SelectionActive", value); }
        public bool HelpWindowClosing { get => Native.GetPropBool(Pointer, "HelpWindowClosing"); set => Native.SetPropBool(Pointer, "HelpWindowClosing", value); }
        public void DestroyButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyButtons", __pb.Bytes);
        }
        public void UnhighlightHelp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhighlightHelp", __pb.Bytes);
        }
        public void HighlightHelp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HighlightHelp", __pb.Bytes);
        }
        public void SpawnButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnButtons", __pb.Bytes);
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
        public void ParentDestroyed(Actor DestroyedActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, DestroyedActor);
            CallRaw("ParentDestroyed", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void HelpButtonPressed(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("HelpButtonPressed", __pb.Bytes);
        }
        public void HelpSelectionMade(FName ManualEntry)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, ManualEntry);
            CallRaw("HelpSelectionMade", __pb.Bytes);
        }
        public void ExecuteUbergraph_HelpSelection(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_HelpSelection", __pb.Bytes);
        }
    }

}
