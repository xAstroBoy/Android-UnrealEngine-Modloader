// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/NoteInstruction
using System;

namespace UEModLoader.Game
{
    public class NoteInstruction_C : UserWidget
    {
        public const string UeClassName = "NoteInstruction_C";
        public NoteInstruction_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new NoteInstruction_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NoteInstruction_C(p);
        public static NoteInstruction_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NoteInstruction_C(o.Pointer); }
        public static NoteInstruction_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NoteInstruction_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NoteInstruction_C(a[i].Pointer); return r; }
        public WidgetAnimation SwapToLargeInstant { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation RevealSmallTextR { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation RevealSmallTextL { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation PulseRed { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation Flash { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay _3DBackingParent { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Border Border_sml { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Border(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Border Border_smr { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Border(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox CommandAnchor { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay CommandParent { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock CommandTextSmL { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock CommandTextSmR { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay GlobalParent { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SmallIconParentNo3D { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay SmallTextParent { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_IconNo3d { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EQTEId QTE { get => (EQTEId)GetAt<byte>(0x2B0); set => SetAt(0x2B0, (byte)value); }
        public EActionButtonType Action { get => (EActionButtonType)GetAt<byte>(0x2B1); set => SetAt(0x2B1, (byte)value); }
        public void ShowCommandButtonNote_LargeInstant(bool Use3dIcon, EVR4CommandButton Command)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(Use3dIcon?1:0));
            __pb.Set<byte>(0x1, (byte)Command);
            CallRaw("ShowCommandButtonNote_LargeInstant", __pb.Bytes);
        }
        public void RevealSmallTextNote(EVR4CommandButton commandButton)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)commandButton);
            CallRaw("RevealSmallTextNote", __pb.Bytes);
        }
    }

}
