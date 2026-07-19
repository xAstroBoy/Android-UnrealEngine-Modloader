// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/TopRing
using System;

namespace UEModLoader.Game
{
    public class TopRing_C : UserWidget
    {
        public const string UeClassName = "TopRing_C";
        public TopRing_C(System.IntPtr ptr) : base(ptr) {}
        public static new TopRing_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TopRing_C(p);
        public static TopRing_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TopRing_C(o.Pointer); }
        public static TopRing_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TopRing_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TopRing_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation FlashBack { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation ShowTimer { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation ShowMedalion { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation ShowSubtitle { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock AddedBonusCount { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public VerticalBox BonusGroup { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BonusLine { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock BonusTimeCount { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock BonusTimeText0 { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock BonusTimeText1 { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox BounsCountMover { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock ComboCount { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public VerticalBox ComboGroup { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ComboLine { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock ComboText { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Head { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay MedalionAnchor { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock MedalionText { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock MedalionTextBack { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public VerticalBox MercLeftSide { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock MercScore { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox NormalTopRingParent { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Overlay_BonusCountAnchor { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay OverlayMedallion { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay OverlayMercTimer { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBoxMercParent { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock SubtitleText { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerDivider0 { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerDivider1 { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerDividerMerc0 { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerDividerMerc1 { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerTextMercMin { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerTextMercMs { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerTextMercSec { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerTextMin { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerTextMs { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock TimerTextSec { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr UpdateRendering => AddrOf(0x360); // 
        public bool MedalilionVisible { get => Native.GetPropBool(Pointer, "MedalilionVisible"); set => Native.SetPropBool(Pointer, "MedalilionVisible", value); }
        public bool TimerVisible { get => Native.GetPropBool(Pointer, "TimerVisible"); set => Native.SetPropBool(Pointer, "TimerVisible", value); }
        public bool SubtitleVisible { get => Native.GetPropBool(Pointer, "SubtitleVisible"); set => Native.SetPropBool(Pointer, "SubtitleVisible", value); }
        public TimerHandle SubtitleTimer => new TimerHandle(AddrOf(0x378));
        public bool MedalilionClosing { get => Native.GetPropBool(Pointer, "MedalilionClosing"); set => Native.SetPropBool(Pointer, "MedalilionClosing", value); }
        public bool TimerClosing { get => Native.GetPropBool(Pointer, "TimerClosing"); set => Native.SetPropBool(Pointer, "TimerClosing", value); }
        public bool SubtitleClosing { get => Native.GetPropBool(Pointer, "SubtitleClosing"); set => Native.SetPropBool(Pointer, "SubtitleClosing", value); }
        public System.IntPtr HideCoin => AddrOf(0x388); // 
        public TimerHandle MedalilonTimer => new TimerHandle(AddrOf(0x398));
        public System.IntPtr newText => AddrOf(0x3A0); // 
        public TimerHandle ColorTimer => new TimerHandle(AddrOf(0x3B8));
        public TimerHandle TimerTimer => new TimerHandle(AddrOf(0x3C0));
        public bool TimerAllowed { get => Native.GetPropBool(Pointer, "TimerAllowed"); set => Native.SetPropBool(Pointer, "TimerAllowed", value); }
        public int Countdown { get => GetAt<int>(0x3CC); set => SetAt(0x3CC, value); }
        public bool InitialMercDelayActive { get => Native.GetPropBool(Pointer, "InitialMercDelayActive"); set => Native.SetPropBool(Pointer, "InitialMercDelayActive", value); }
        public bool LeonOverride { get => Native.GetPropBool(Pointer, "LeonOverride"); set => Native.SetPropBool(Pointer, "LeonOverride", value); }
        public void Hide_Medalion_Instantly()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Hide Medalion Instantly", __pb.Bytes);
        }
        public void AnimationPlaying_(bool NoAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(NoAnimation?1:0));
            CallRaw("AnimationPlaying?", __pb.Bytes);
        }
        public void HideWidget_()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideWidget?", __pb.Bytes);
        }
        public void HideTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideTimer", __pb.Bytes);
        }
        public void HideTimerComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideTimerComplete", __pb.Bytes);
        }
        public void DisplayMedallion(int Count, int Max)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Count);
            __pb.Set(0x4, Max);
            CallRaw("DisplayMedallion", __pb.Bytes);
        }
        public void HideMedalian()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideMedalian", __pb.Bytes);
        }
        public void HideMedalionComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideMedalionComplete", __pb.Bytes);
        }
        public void DisplayAshleySubtitle(System.IntPtr Text, float Duration, bool LeonOverride)
        {
            var __pb = new ParamBuffer(29);
            __pb.Set<System.IntPtr>(0x0, Text);
            __pb.Set(0x18, Duration);
            __pb.Set<byte>(0x1C, (byte)(LeonOverride?1:0));
            CallRaw("DisplayAshleySubtitle", __pb.Bytes);
        }
        public void HideAshleySubtile()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideAshleySubtile", __pb.Bytes);
        }
        public void HideSubtitleComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideSubtitleComplete", __pb.Bytes);
        }
        public void ChangeColor()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ChangeColor", __pb.Bytes);
        }
        public void DisplayTimer(int Min, int Sec, int Csec, bool isWarning)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set(0x0, Min);
            __pb.Set(0x4, Sec);
            __pb.Set(0x8, Csec);
            __pb.Set<byte>(0xC, (byte)(isWarning?1:0));
            CallRaw("DisplayTimer", __pb.Bytes);
        }
        public void InstantHideTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InstantHideTimer", __pb.Bytes);
        }
        public void ExecuteUbergraph_TopRing(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_TopRing", __pb.Bytes);
        }
        public void HideCoin__DelegateSignature(bool instant)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(instant?1:0));
            CallRaw("HideCoin__DelegateSignature", __pb.Bytes);
        }
        public void UpdateRendering__DelegateSignature(bool Visible, bool UseManualRedraw)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            __pb.Set<byte>(0x1, (byte)(UseManualRedraw?1:0));
            CallRaw("UpdateRendering__DelegateSignature", __pb.Bytes);
        }
    }

}
