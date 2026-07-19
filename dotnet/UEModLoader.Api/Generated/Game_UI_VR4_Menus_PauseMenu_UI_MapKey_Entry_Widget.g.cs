// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_MapKey_Entry_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_MapKey_Entry_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_MapKey_Entry_Widget_C";
        public UI_MapKey_Entry_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_MapKey_Entry_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(p);
        public static UI_MapKey_Entry_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MapKey_Entry_Widget_C(o.Pointer); }
        public static UI_MapKey_Entry_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MapKey_Entry_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MapKey_Entry_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation IconPulse { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_MapKey { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Label { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Colors => AddrOf(0x250); // struct UI_WidgetColors_Struct
        public SlateBrush Get_Icon_MapKey_Brush_0()
        {
            var __pb = new ParamBuffer(136);
            CallRaw("Get_Icon_MapKey_Brush_0", __pb.Bytes);
            return __pb.Get<SlateBrush>(0x0);
        }
        public System.IntPtr GetText_0()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetText_0", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        public void Set_Icon(Texture2D NewIcon)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewIcon);
            CallRaw("Set_Icon", __pb.Bytes);
        }
        public void Animation_StartPulse()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Animation_StartPulse", __pb.Bytes);
        }
        public void Animation_StopPulse()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Animation_StopPulse", __pb.Bytes);
        }
        public void Set_LabelText(System.IntPtr NewLabel)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, NewLabel);
            CallRaw("Set_LabelText", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MapKey_Entry_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MapKey_Entry_Widget", __pb.Bytes);
        }
    }

}
