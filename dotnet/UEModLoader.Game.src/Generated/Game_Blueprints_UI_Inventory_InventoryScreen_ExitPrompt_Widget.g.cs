// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/InventoryScreen_ExitPrompt_Widget
using System;

namespace UEModLoader.Game
{
    public class InventoryScreen_ExitPrompt_Widget_C : UserWidget
    {
        public const string UeClassName = "InventoryScreen_ExitPrompt_Widget_C";
        public InventoryScreen_ExitPrompt_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new InventoryScreen_ExitPrompt_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InventoryScreen_ExitPrompt_Widget_C(p);
        public static InventoryScreen_ExitPrompt_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InventoryScreen_ExitPrompt_Widget_C(o.Pointer); }
        public static InventoryScreen_ExitPrompt_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InventoryScreen_ExitPrompt_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InventoryScreen_ExitPrompt_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x250); // struct UI_WidgetColors_Struct
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_InventoryScreen_ExitPrompt_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_InventoryScreen_ExitPrompt_Widget", __pb.Bytes);
        }
    }

}
