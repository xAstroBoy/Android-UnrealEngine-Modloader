// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Header_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Header_BP_C : UI_PauseMenu_Header_Base_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Header_BP_C";
        public UI_PauseMenu_Header_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Header_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_PauseMenu_Header_BP_C(p);
        public static UI_PauseMenu_Header_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Header_BP_C(o.Pointer); }
        public static UI_PauseMenu_Header_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Header_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Header_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public WidgetComponent Widget_HelpHighlight { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_Help { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_Exit { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_Options { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_Files { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_Map { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_Inventory { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_KeyItems { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Header_Parent { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> isTutorialComplete => new TArray<System.IntPtr>(AddrOf(0x2A8)); // TArray<FName>
        public bool isHelplActive { get => Native.GetPropBool(Pointer, "isHelplActive"); set => Native.SetPropBool(Pointer, "isHelplActive", value); }
        public PauseMenu_HelpHighlight_C HelpHighlight { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new PauseMenu_HelpHighlight_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public void IsButtonUsable(UI_PauseMenu_Header_Button_C Button, bool Usable)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Button);
            __pb.Set<byte>(0x8, (byte)(Usable?1:0));
            CallRaw("IsButtonUsable", __pb.Bytes);
        }
        public void CreateReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateReferences", __pb.Bytes);
        }
        public void HideHelpHighlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideHelpHighlight", __pb.Bytes);
        }
        public void ShowHelpHighlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowHelpHighlight", __pb.Bytes);
        }
        public void RestoreAll(EPauseMenuScreen Selection, bool FollowLink)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Selection);
            __pb.Set<byte>(0x1, (byte)(FollowLink?1:0));
            CallRaw("RestoreAll", __pb.Bytes);
        }
        public void HideAll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideAll", __pb.Bytes);
        }
        public void ToggleHelp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleHelp", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Header_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Header_BP", __pb.Bytes);
        }
    }

}
