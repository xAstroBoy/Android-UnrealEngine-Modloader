// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Header_Base_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Header_Base_BP_C : Actor
    {
        public const string UeClassName = "UI_PauseMenu_Header_Base_BP_C";
        public UI_PauseMenu_Header_Base_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Header_Base_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Header_Base_BP_C(p);
        public static UI_PauseMenu_Header_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Header_Base_BP_C(o.Pointer); }
        public static UI_PauseMenu_Header_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Header_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Header_Base_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public ChildActorComponent TitleBar { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_TabTitle_BP_C Ref_Title { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new UI_TabTitle_BP_C(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_PauseMenu_BP_C Ref_Parent_PauseMenu { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new UI_PauseMenu_BP_C(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> HeaderButtons => new TArray<global::System.IntPtr>(AddrOf(0x248)); // TArray<UObject*>
        public void IsButtonUsable(UI_PauseMenu_Header_Button_C Button, bool Usable)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Button);
            __pb.Set<byte>(0x8, (byte)(Usable?1:0));
            CallRaw("IsButtonUsable", __pb.Bytes);
        }
        public void GetHeaderTab(byte MenuSelection, UI_PauseMenu_Header_Button_C Button)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, MenuSelection);
            __pb.SetObject(0x8, Button);
            CallRaw("GetHeaderTab", __pb.Bytes);
        }
        public void UpdateTitle(global::System.IntPtr NewTitle)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, NewTitle);
            CallRaw("UpdateTitle", __pb.Bytes);
        }
        public void Change_Tab_State(EPauseMenuScreen MenuSelection)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)MenuSelection);
            CallRaw("Change Tab State", __pb.Bytes);
        }
        public void ConvertToNewEnum(byte InputEnum, EPauseMenuScreen OutputEnum)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set(0x0, InputEnum);
            __pb.Set<byte>(0x1, (byte)OutputEnum);
            CallRaw("ConvertToNewEnum", __pb.Bytes);
        }
        public void ConvertToOldEnum(EPauseMenuScreen InputEnum, byte OutputEnum)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)InputEnum);
            __pb.Set(0x1, OutputEnum);
            CallRaw("ConvertToOldEnum", __pb.Bytes);
        }
        public void ChangeMenuState(byte MenuSelection)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, MenuSelection);
            CallRaw("ChangeMenuState", __pb.Bytes);
        }
        public void SelectOneButton(EPauseMenuScreen MenuSelection)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)MenuSelection);
            CallRaw("SelectOneButton", __pb.Bytes);
        }
        public void SetButtonsEnabled(bool Enabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            CallRaw("SetButtonsEnabled", __pb.Bytes);
        }
        public void CreateReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateReferences", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Header_Base_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Header_Base_BP", __pb.Bytes);
        }
    }

}
