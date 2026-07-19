// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Cutscene/BinocularOverlay_BP
using System;

namespace UEModLoader.Game
{
    public class BinocularOverlay_BP_C : UserWidget
    {
        public const string UeClassName = "BinocularOverlay_BP_C";
        public BinocularOverlay_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new BinocularOverlay_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BinocularOverlay_BP_C(p);
        public static BinocularOverlay_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BinocularOverlay_BP_C(o.Pointer); }
        public static BinocularOverlay_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BinocularOverlay_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BinocularOverlay_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation Cycle { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Intro { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow_01 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow_02 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow_03 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public CanvasPanel ArrowMask { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Blinker_Left { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Blinker_Right { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Bottom { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public Image CompassFrame { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public Image CompassGlow_Left { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public Image CompassGlow_Right { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public CanvasPanel CompassHeading { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public Image CompassSlide2_Left { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image CompassSlide2_Right { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image CompassSlide_Left { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image CompassSlide_Right { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Crescent { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Crescent_2 { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Crescent_3 { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image East { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image East_2 { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image EastCuttout { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image EastCuttout_2 { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_2 { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_3 { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_4 { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_5 { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_6 { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_7 { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_8 { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_9 { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_10 { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Left { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public Image line { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public Image line_2 { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public Image line_3 { get { var __p = GetAt<System.IntPtr>(0x360); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x360, value?.Pointer ?? System.IntPtr.Zero); }
        public Image line_4 { get { var __p = GetAt<System.IntPtr>(0x368); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x368, value?.Pointer ?? System.IntPtr.Zero); }
        public Image line_5 { get { var __p = GetAt<System.IntPtr>(0x370); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x370, value?.Pointer ?? System.IntPtr.Zero); }
        public CanvasPanel Master { get { var __p = GetAt<System.IntPtr>(0x378); return __p==System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x378, value?.Pointer ?? System.IntPtr.Zero); }
        public Image North { get { var __p = GetAt<System.IntPtr>(0x380); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x380, value?.Pointer ?? System.IntPtr.Zero); }
        public Image North_2 { get { var __p = GetAt<System.IntPtr>(0x388); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x388, value?.Pointer ?? System.IntPtr.Zero); }
        public Image NorthCuttout { get { var __p = GetAt<System.IntPtr>(0x390); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x390, value?.Pointer ?? System.IntPtr.Zero); }
        public Image NorthCuttout_2 { get { var __p = GetAt<System.IntPtr>(0x398); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x398, value?.Pointer ?? System.IntPtr.Zero); }
        public Image RedBack { get { var __p = GetAt<System.IntPtr>(0x3A0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3A0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Right { get { var __p = GetAt<System.IntPtr>(0x3A8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3A8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image South { get { var __p = GetAt<System.IntPtr>(0x3B0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3B0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image SouthCuttout { get { var __p = GetAt<System.IntPtr>(0x3B8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3B8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Top { get { var __p = GetAt<System.IntPtr>(0x3C0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3C0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image West { get { var __p = GetAt<System.IntPtr>(0x3C8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3C8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image West_2 { get { var __p = GetAt<System.IntPtr>(0x3D0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3D0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image WestCuttout { get { var __p = GetAt<System.IntPtr>(0x3D8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3D8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image WestCuttout_2 { get { var __p = GetAt<System.IntPtr>(0x3E0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3E0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ZoomBar { get { var __p = GetAt<System.IntPtr>(0x3E8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3E8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ZoomBar_Back { get { var __p = GetAt<System.IntPtr>(0x3F0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3F0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ZoomBorder { get { var __p = GetAt<System.IntPtr>(0x3F8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3F8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ZoomDecimal { get { var __p = GetAt<System.IntPtr>(0x400); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x400, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ZoomDecimalDigit { get { var __p = GetAt<System.IntPtr>(0x408); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x408, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ZoomHundredsDigit { get { var __p = GetAt<System.IntPtr>(0x410); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x410, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher ZoomSinglesDigit { get { var __p = GetAt<System.IntPtr>(0x418); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x418, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher ZoomTensDigit { get { var __p = GetAt<System.IntPtr>(0x420); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x420, value?.Pointer ?? System.IntPtr.Zero); }
        public float CompassDegrees { get => GetAt<float>(0x428); set => SetAt(0x428, value); }
        public int ZoomLevel { get => GetAt<int>(0x42C); set => SetAt(0x42C, value); }
        public bool IntroPlayed { get => Native.GetPropBool(Pointer, "IntroPlayed"); set => Native.SetPropBool(Pointer, "IntroPlayed", value); }
        public void ClearPlayedIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearPlayedIntro", __pb.Bytes);
        }
        public void PlayIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayIntro", __pb.Bytes);
        }
        public void SetCompassHeading(float Degrees)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Degrees);
            CallRaw("SetCompassHeading", __pb.Bytes);
        }
        public void SetZoomLevel(int Zoom)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Zoom);
            CallRaw("SetZoomLevel", __pb.Bytes);
        }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void Tick(Geometry MyGeometry, float InDeltaTime)
        {
            var __pb = new ParamBuffer(60);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set(0x38, InDeltaTime);
            CallRaw("Tick", __pb.Bytes);
        }
        public void ExecuteUbergraph_BinocularOverlay_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_BinocularOverlay_BP", __pb.Bytes);
        }
    }

}
