// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_CashDisplay_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_CashDisplay_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_PauseMenu_CashDisplay_Widget_C";
        public UI_PauseMenu_CashDisplay_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_CashDisplay_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_PauseMenu_CashDisplay_Widget_C(p);
        public static UI_PauseMenu_CashDisplay_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_CashDisplay_Widget_C(o.Pointer); }
        public static UI_PauseMenu_CashDisplay_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_CashDisplay_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_CashDisplay_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation ShowValue { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Outline { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Value { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x258); // struct UI_WidgetColors_Struct
        public System.IntPtr MercColors => AddrOf(0x460); // struct UI_WidgetColorsMercenaries_Struct
        public bool UseMercColors { get => Native.GetPropBool(Pointer, "UseMercColors"); set => Native.SetPropBool(Pointer, "UseMercColors", value); }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void Set_CashValue(int Cash)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Cash);
            CallRaw("Set_CashValue", __pb.Bytes);
        }
        public void SetMercColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercColors", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_CashDisplay_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_CashDisplay_Widget", __pb.Bytes);
        }
    }

}
