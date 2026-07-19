// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_MapKey_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_MapKey_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_MapKey_Widget_C";
        public UI_MapKey_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_MapKey_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_MapKey_Widget_C(p);
        public static UI_MapKey_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MapKey_Widget_C(o.Pointer); }
        public static UI_MapKey_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MapKey_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MapKey_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public UI_MapKey_Entry_Widget_C Entry_01_Open { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_02_Locked { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_03_HaveKey { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_04_Entered { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_05_NotEntered { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_06_Sealed { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_07_Destination { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_08_Typewriter { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_09_Merchant { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_10_Submission { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MapKey_Entry_Widget_C Entry_11_Treasure { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new UI_MapKey_Entry_Widget_C(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Heading_Door_Widget_C Heading { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new UI_Heading_Door_Widget_C(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Heading_Door_Widget_C Subheading { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new UI_Heading_Door_Widget_C(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VerticalBox VerticalBox_AreaNotMerc { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VerticalBox VerticalBox_Door { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetKeysVisible(bool typewriter, bool Merchant, bool SubMission, bool Treasure)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<byte>(0x0, (byte)(typewriter?1:0));
            __pb.Set<byte>(0x1, (byte)(Merchant?1:0));
            __pb.Set<byte>(0x2, (byte)(SubMission?1:0));
            __pb.Set<byte>(0x3, (byte)(Treasure?1:0));
            CallRaw("SetKeysVisible", __pb.Bytes);
        }
        public void InitializeKeyEntries()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeKeyEntries", __pb.Bytes);
        }
        public void GetEntry(byte KeyEntry, UI_MapKey_Entry_Widget_C NewParam)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, KeyEntry);
            __pb.SetObject(0x8, NewParam);
            CallRaw("GetEntry", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void PulseEntry(byte SelectedEntry)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, SelectedEntry);
            CallRaw("PulseEntry", __pb.Bytes);
        }
        public void StopPulse(byte SelectedEntry)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, SelectedEntry);
            CallRaw("StopPulse", __pb.Bytes);
        }
        public void ShowEntry(byte NewParam)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, NewParam);
            CallRaw("ShowEntry", __pb.Bytes);
        }
        public void HideEntry(byte NewParam)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, NewParam);
            CallRaw("HideEntry", __pb.Bytes);
        }
        public void OnInitialized()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnInitialized", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MapKey_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MapKey_Widget", __pb.Bytes);
        }
    }

}
