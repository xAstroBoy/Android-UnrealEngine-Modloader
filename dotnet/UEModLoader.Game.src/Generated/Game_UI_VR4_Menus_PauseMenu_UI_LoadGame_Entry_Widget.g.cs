// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_LoadGame_Entry_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_LoadGame_Entry_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_LoadGame_Entry_Widget_C";
        public UI_LoadGame_Entry_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_LoadGame_Entry_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_LoadGame_Entry_Widget_C(p);
        public static UI_LoadGame_Entry_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_LoadGame_Entry_Widget_C(o.Pointer); }
        public static UI_LoadGame_Entry_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_LoadGame_Entry_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_LoadGame_Entry_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ChapterText { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Highlight { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock IndexText { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ModeText { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ModeText_Plus { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock RoundText { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SavesText { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TimeText { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Underline { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsSelected { get => Native.GetPropBool(Pointer, "IsSelected"); set => Native.SetPropBool(Pointer, "IsSelected", value); }
        public global::System.IntPtr ColorList => AddrOf(0x290); // struct UI_WidgetColors_Struct
        public bool IsNewGamePlus { get => Native.GetPropBool(Pointer, "IsNewGamePlus"); set => Native.SetPropBool(Pointer, "IsNewGamePlus", value); }
        public global::System.IntPtr NewGamePlusColorList => AddrOf(0x4A0); // struct UI_WidgetColors_NGPlus_Struct
        public SlateColor Color_FG_Selected_Hover => new SlateColor(AddrOf(0x5E0));
        public SlateColor Color_FG_Selected_Unhover => new SlateColor(AddrOf(0x608));
        public SlateColor Color_FG_Unselected_Hover => new SlateColor(AddrOf(0x630));
        public SlateColor Color_FG_Unselected_Unhover => new SlateColor(AddrOf(0x658));
        public SlateColor Color_BG_Selected_Hover => new SlateColor(AddrOf(0x680));
        public SlateColor Color_BG_Unselected_Hover => new SlateColor(AddrOf(0x6A8));
        public SlateColor Color_Difficulty_Selected_Hover => new SlateColor(AddrOf(0x6D0));
        public SlateColor Color_Difficulty_Selected_Unhover => new SlateColor(AddrOf(0x6F8));
        public SlateColor Color_Difficulty_Unselected_Hover => new SlateColor(AddrOf(0x720));
        public SlateColor Color_Difficulty_Unselected_Unhover => new SlateColor(AddrOf(0x748));
        public bool IsEndGameSave { get => Native.GetPropBool(Pointer, "IsEndGameSave"); set => Native.SetPropBool(Pointer, "IsEndGameSave", value); }
        public void SetEndGameSave(bool IsEndGameSave)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsEndGameSave?1:0));
            CallRaw("SetEndGameSave", __pb.Bytes);
        }
        public void SetEntryBlank()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetEntryBlank", __pb.Bytes);
        }
        public void SetEntryInfo(int Index, global::System.IntPtr Chapter, int Saves, global::System.IntPtr Time, int Round, EGameMode Mode, bool IsEndGameSave)
        {
            var __pb = new ParamBuffer(70);
            __pb.Set(0x0, Index);
            __pb.Set<global::System.IntPtr>(0x8, Chapter);
            __pb.Set(0x20, Saves);
            __pb.Set<global::System.IntPtr>(0x28, Time);
            __pb.Set(0x40, Round);
            __pb.Set<byte>(0x44, (byte)Mode);
            __pb.Set<byte>(0x45, (byte)(IsEndGameSave?1:0));
            CallRaw("SetEntryInfo", __pb.Bytes);
        }
        public void SetNewGamePlus(bool IsNewGamePlus)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsNewGamePlus?1:0));
            CallRaw("SetNewGamePlus", __pb.Bytes);
        }
        public void HoverButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HoverButton", __pb.Bytes);
        }
        public void UnhoverButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnhoverButton", __pb.Bytes);
        }
        public void DisableButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableButton", __pb.Bytes);
        }
        public void SelectButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SelectButton", __pb.Bytes);
        }
        public void UnselectButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnselectButton", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_LoadGame_Entry_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_LoadGame_Entry_Widget", __pb.Bytes);
        }
    }

}
