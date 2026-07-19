// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Cutscene/CutsceneInfo
using System;

namespace UEModLoader.Game
{
    public class CutsceneInfo_C : UserWidget
    {
        public const string UeClassName = "CutsceneInfo_C";
        public CutsceneInfo_C(System.IntPtr ptr) : base(ptr) {}
        public static new CutsceneInfo_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CutsceneInfo_C(p);
        public static CutsceneInfo_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CutsceneInfo_C(o.Pointer); }
        public static CutsceneInfo_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CutsceneInfo_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CutsceneInfo_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public ButtonImage_C ButtonImageDrive { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public ButtonImage_C ButtonImageDrive_2 { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public ButtonImage_C ButtonImageDrive_3 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public ButtonImage_C ButtonImageDrive_4 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public ButtonImage_C ButtonImagePause { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public ButtonImage_C ButtonImageSkip { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public ButtonImage_C ButtonImageToggle { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox HorizontalBoxDrive { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox HorizontalBoxDrive_2 { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox HorizontalBoxPause { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox HorizontalBoxSkip { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox HorizontalBoxSkip_2 { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox HorizontalBoxToggle { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Inner { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Outer { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TextPause { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TextSkip { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TextSkip_2 { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TextToggle { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TextToggle_2 { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TextToggle_3 { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_Content { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public void ControlsDisabled()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ControlsDisabled", __pb.Bytes);
        }
        public void ControlsEnabled()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ControlsEnabled", __pb.Bytes);
        }
        public void DisableSkip()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableSkip", __pb.Bytes);
        }
        public void FillSkip(float PlaybackSpeed)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, PlaybackSpeed);
            CallRaw("FillSkip", __pb.Bytes);
        }
        public void StopFillSkip()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopFillSkip", __pb.Bytes);
        }
        public void SetSkipButton(byte New_Skip_Button)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, New_Skip_Button);
            CallRaw("SetSkipButton", __pb.Bytes);
        }
        public void ShowDrive()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowDrive", __pb.Bytes);
        }
        public void SkipOnly()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipOnly", __pb.Bytes);
        }
        public void SetSubtitleButton(byte NewSubtitleButton)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, NewSubtitleButton);
            CallRaw("SetSubtitleButton", __pb.Bytes);
        }
        public void ExecuteUbergraph_CutsceneInfo(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_CutsceneInfo", __pb.Bytes);
        }
    }

}
