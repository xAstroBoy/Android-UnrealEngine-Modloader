// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_KeysTreasures_Title_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_KeysTreasures_Title_Widget_C : UI_Button_Widget_BP_C
    {
        public const string UeClassName = "UI_KeysTreasures_Title_Widget_C";
        public UI_KeysTreasures_Title_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_KeysTreasures_Title_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_KeysTreasures_Title_Widget_C(p);
        public static UI_KeysTreasures_Title_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_KeysTreasures_Title_Widget_C(o.Pointer); }
        public static UI_KeysTreasures_Title_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_KeysTreasures_Title_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_KeysTreasures_Title_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public Image Image_Backing { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Heading { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateColor Color_Heading => new SlateColor(AddrOf(0x268));
        public SlateColor Color_Subheading => new SlateColor(AddrOf(0x290));
        public SlateColor Color_Highlighted => new SlateColor(AddrOf(0x2B8));
        public SlateColor Color_Selected => new SlateColor(AddrOf(0x2E0));
        public SlateColor Bg_Color_Highlighted => new SlateColor(AddrOf(0x308));
        public SlateColor Bg_Color_Selected => new SlateColor(AddrOf(0x330));
        public SlateColor DefaultColor => new SlateColor(AddrOf(0x358));
        public bool IsSubHeading { get => Native.GetPropBool(Pointer, "IsSubHeading"); set => Native.SetPropBool(Pointer, "IsSubHeading", value); }
        public void Unhighlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhighlight", __pb.Bytes);
        }
        public void Highlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Highlight", __pb.Bytes);
        }
        public void SetColorAsSubheading()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetColorAsSubheading", __pb.Bytes);
        }
        public void SetColorAsHeading()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetColorAsHeading", __pb.Bytes);
        }
        public void OnHovered()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnHovered", __pb.Bytes);
        }
        public void OnUnhovered()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnUnhovered", __pb.Bytes);
        }
        public void OnSelected()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnSelected", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_KeysTreasures_Title_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_KeysTreasures_Title_Widget", __pb.Bytes);
        }
    }

}
