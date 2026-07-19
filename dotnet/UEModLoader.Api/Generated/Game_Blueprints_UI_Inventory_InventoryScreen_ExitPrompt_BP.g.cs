// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/InventoryScreen_ExitPrompt_BP
using System;

namespace UEModLoader.Game
{
    public class InventoryScreen_ExitPrompt_BP_C : VR4PauseUIScreen
    {
        public const string UeClassName = "InventoryScreen_ExitPrompt_BP_C";
        public InventoryScreen_ExitPrompt_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new InventoryScreen_ExitPrompt_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InventoryScreen_ExitPrompt_BP_C(p);
        public static InventoryScreen_ExitPrompt_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InventoryScreen_ExitPrompt_BP_C(o.Pointer); }
        public static InventoryScreen_ExitPrompt_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InventoryScreen_ExitPrompt_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InventoryScreen_ExitPrompt_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public ChildActorComponent Button { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnPressed(int ButtonId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ButtonId);
            CallRaw("OnPressed", __pb.Bytes);
        }
        public void ExecuteUbergraph_InventoryScreen_ExitPrompt_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_InventoryScreen_ExitPrompt_BP", __pb.Bytes);
        }
    }

}
