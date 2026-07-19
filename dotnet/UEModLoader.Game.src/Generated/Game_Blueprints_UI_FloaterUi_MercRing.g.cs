// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/MercRing
using System;

namespace UEModLoader.Game
{
    public class MercRing_C : UserWidget
    {
        public const string UeClassName = "MercRing_C";
        public MercRing_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new MercRing_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MercRing_C(p);
        public static MercRing_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MercRing_C(o.Pointer); }
        public static MercRing_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MercRing_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MercRing_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation Rank5 { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation Rank4 { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation Rank3 { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation Rank2 { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation Rank1 { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation RemovePromptRight_Active { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation SetToScope { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation FadeMessage { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation RemovePrompt { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation RemovePromptRight { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation RemovePromptLeft { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation ShowPrompt { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation EndMessage { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation RestoreTimer { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation ShowBonusCount { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation FlashBonustime { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation FlashComboCount { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation FlashMercTimer { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation Intro { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock AddedBonusCount { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ArrowCount { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VerticalBox BonusGroup { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock BonusTimeText0 { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public HorizontalBox BounsCountMover { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ComboCount { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VerticalBox ComboGroup { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ComboLine1 { get { var __p = GetAt<global::System.IntPtr>(0x308); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x308, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ComboLine2 { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ComboText { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public HorizontalBox HorizontalBox_Bonus { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercHudStar_C MercHudStar1 { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new MercHudStar_C(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercHudStar_C MercHudStar2 { get { var __p = GetAt<global::System.IntPtr>(0x330); return __p==global::System.IntPtr.Zero?null:new MercHudStar_C(__p); } set => SetAt(0x330, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercHudStar_C MercHudStar3 { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new MercHudStar_C(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercHudStar_C MercHudStar4 { get { var __p = GetAt<global::System.IntPtr>(0x340); return __p==global::System.IntPtr.Zero?null:new MercHudStar_C(__p); } set => SetAt(0x340, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercHudStar_C MercHudStar5 { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new MercHudStar_C(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VerticalBox MercLeftSide { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercLevelInfoWidget_Rank_C MercLevelInfoWidget_Rank1 { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new MercLevelInfoWidget_Rank_C(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercLevelInfoWidget_Rank_C MercLevelInfoWidget_Rank2 { get { var __p = GetAt<global::System.IntPtr>(0x360); return __p==global::System.IntPtr.Zero?null:new MercLevelInfoWidget_Rank_C(__p); } set => SetAt(0x360, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercLevelInfoWidget_Rank_C MercLevelInfoWidget_Rank3 { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new MercLevelInfoWidget_Rank_C(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercLevelInfoWidget_Rank_C MercLevelInfoWidget_Rank4 { get { var __p = GetAt<global::System.IntPtr>(0x370); return __p==global::System.IntPtr.Zero?null:new MercLevelInfoWidget_Rank_C(__p); } set => SetAt(0x370, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MercLevelInfoWidget_Rank_C MercLevelInfoWidget_Rank5 { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new MercLevelInfoWidget_Rank_C(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock MercScore { get { var __p = GetAt<global::System.IntPtr>(0x380); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x380, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_BonusCountAnchor { get { var __p = GetAt<global::System.IntPtr>(0x388); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x388, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay OverlayMercTimer { get { var __p = GetAt<global::System.IntPtr>(0x390); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x390, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock PromptText { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock PromptTextRemoveL { get { var __p = GetAt<global::System.IntPtr>(0x3A0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x3A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock PromptTextRemoveR { get { var __p = GetAt<global::System.IntPtr>(0x3A8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x3A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBoxHudParent { get { var __p = GetAt<global::System.IntPtr>(0x3B0); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TimerDividerMerc0 { get { var __p = GetAt<global::System.IntPtr>(0x3B8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x3B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TimerDividerMerc1 { get { var __p = GetAt<global::System.IntPtr>(0x3C0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x3C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TimerTextMercMin { get { var __p = GetAt<global::System.IntPtr>(0x3C8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x3C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TimerTextMercMs { get { var __p = GetAt<global::System.IntPtr>(0x3D0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x3D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TimerTextMercSec { get { var __p = GetAt<global::System.IntPtr>(0x3D8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x3D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr UpdateRendering => AddrOf(0x3E0); // 
        public global::System.IntPtr HideCoin => AddrOf(0x3F0); // 
        public int Countdown { get => GetAt<int>(0x400); set => SetAt(0x400, value); }
        public bool IsFlashMercTimer { get => Native.GetPropBool(Pointer, "IsFlashMercTimer"); set => Native.SetPropBool(Pointer, "IsFlashMercTimer", value); }
        public int BonusAmount { get => GetAt<int>(0x408); set => SetAt(0x408, value); }
        public bool IsFlashMercBonusCount { get => Native.GetPropBool(Pointer, "IsFlashMercBonusCount"); set => Native.SetPropBool(Pointer, "IsFlashMercBonusCount", value); }
        public bool IsFlashMercTimeBonus { get => Native.GetPropBool(Pointer, "IsFlashMercTimeBonus"); set => Native.SetPropBool(Pointer, "IsFlashMercTimeBonus", value); }
        public bool PromptVisible { get => Native.GetPropBool(Pointer, "PromptVisible"); set => Native.SetPropBool(Pointer, "PromptVisible", value); }
        public TimerHandle HideDelay => new TimerHandle(AddrOf(0x410));
        public bool IsScope { get => Native.GetPropBool(Pointer, "IsScope"); set => Native.SetPropBool(Pointer, "IsScope", value); }
        public bool KrauserStatusAllowed { get => Native.GetPropBool(Pointer, "KrauserStatusAllowed"); set => Native.SetPropBool(Pointer, "KrauserStatusAllowed", value); }
        public EKrauserSuperUIState KrauserState { get => (EKrauserSuperUIState)GetAt<byte>(0x41A); set => SetAt(0x41A, (byte)value); }
        public bool ReadyVisible { get => Native.GetPropBool(Pointer, "ReadyVisible"); set => Native.SetPropBool(Pointer, "ReadyVisible", value); }
        public bool IsShowingItemCounter { get => Native.GetPropBool(Pointer, "IsShowingItemCounter"); set => Native.SetPropBool(Pointer, "IsShowingItemCounter", value); }
        public int AddedTime { get => GetAt<int>(0x420); set => SetAt(0x420, value); }
        public TimerHandle ResetTimerDelay => new TimerHandle(AddrOf(0x428));
        public bool IsBonusVisible { get => Native.GetPropBool(Pointer, "IsBonusVisible"); set => Native.SetPropBool(Pointer, "IsBonusVisible", value); }
        public int Rank1Req { get => GetAt<int>(0x434); set => SetAt(0x434, value); }
        public int Rank2Req { get => GetAt<int>(0x438); set => SetAt(0x438, value); }
        public int Rank3Req { get => GetAt<int>(0x43C); set => SetAt(0x43C, value); }
        public int Rank4Req { get => GetAt<int>(0x440); set => SetAt(0x440, value); }
        public int Rank5Req { get => GetAt<int>(0x444); set => SetAt(0x444, value); }
        public int DisplayedRank { get => GetAt<int>(0x448); set => SetAt(0x448, value); }
        public ParticleSystem ClassicParticle { get { var __p = GetAt<global::System.IntPtr>(0x450); return __p==global::System.IntPtr.Zero?null:new ParticleSystem(__p); } set => SetAt(0x450, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ParticleSystem ChallengeParticle { get { var __p = GetAt<global::System.IntPtr>(0x458); return __p==global::System.IntPtr.Zero?null:new ParticleSystem(__p); } set => SetAt(0x458, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent StarLoc1 { get { var __p = GetAt<global::System.IntPtr>(0x460); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x460, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent StarLoc2 { get { var __p = GetAt<global::System.IntPtr>(0x468); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x468, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent StarLoc3 { get { var __p = GetAt<global::System.IntPtr>(0x470); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x470, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent StarLoc4 { get { var __p = GetAt<global::System.IntPtr>(0x478); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x478, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent StarLoc5 { get { var __p = GetAt<global::System.IntPtr>(0x480); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x480, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoundBase RankEarnedSFX { get { var __p = GetAt<global::System.IntPtr>(0x488); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x488, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool ComboActive { get => Native.GetPropBool(Pointer, "ComboActive"); set => Native.SetPropBool(Pointer, "ComboActive", value); }
        public TArray<global::System.IntPtr> Particles => new TArray<global::System.IntPtr>(AddrOf(0x498)); // TArray<UObject*>
        public TArray<global::System.IntPtr> HUDSounds => new TArray<global::System.IntPtr>(AddrOf(0x4A8)); // TArray<UObject*>
        public Actor ParentBp { get { var __p = GetAt<global::System.IntPtr>(0x4B8); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x4B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> WatchActors => new TArray<global::System.IntPtr>(AddrOf(0x4C0)); // TArray<UObject*>
        public global::System.IntPtr WatchTimeMin => AddrOf(0x4D0); // 
        public global::System.IntPtr WatchTimeSec => AddrOf(0x4E8); // 
        public global::System.IntPtr WatchTimeCSec => AddrOf(0x500); // 
        public bool WatchTimeIsWarning { get => Native.GetPropBool(Pointer, "WatchTimeIsWarning"); set => Native.SetPropBool(Pointer, "WatchTimeIsWarning", value); }
        public int WatchScore { get => GetAt<int>(0x51C); set => SetAt(0x51C, value); }
        public TimerHandle HideDelayL => new TimerHandle(AddrOf(0x520));
        public TimerHandle HideDelayR => new TimerHandle(AddrOf(0x528));
        public bool scopeVisible { get => Native.GetPropBool(Pointer, "scopeVisible"); set => Native.SetPropBool(Pointer, "scopeVisible", value); }
        public void RemoveRCheck()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RemoveRCheck", __pb.Bytes);
        }
        public void RemoveLCheck()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RemoveLCheck", __pb.Bytes);
        }
        public void PrimeWatchActors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PrimeWatchActors", __pb.Bytes);
        }
        public void StopSounds()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopSounds", __pb.Bytes);
        }
        public void Spawn5StarVFX()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Spawn5StarVFX", __pb.Bytes);
        }
        public void DestroyHudParticles()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyHudParticles", __pb.Bytes);
        }
        public void InitRankRequirements()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitRankRequirements", __pb.Bytes);
        }
        public void UpdateWatchScore(int Score)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Score);
            CallRaw("UpdateWatchScore", __pb.Bytes);
        }
        public void UpdateWatchTime(global::System.IntPtr Min, global::System.IntPtr Sec, global::System.IntPtr Csec, bool isWarning)
        {
            var __pb = new ParamBuffer(73);
            __pb.Set<global::System.IntPtr>(0x0, Min);
            __pb.Set<global::System.IntPtr>(0x18, Sec);
            __pb.Set<global::System.IntPtr>(0x30, Csec);
            __pb.Set<byte>(0x48, (byte)(isWarning?1:0));
            CallRaw("UpdateWatchTime", __pb.Bytes);
        }
        public void SpawnStarVFX(SceneComponent Loc, bool FinalStar)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Loc);
            __pb.Set<byte>(0x8, (byte)(FinalStar?1:0));
            CallRaw("SpawnStarVFX", __pb.Bytes);
        }
        public void SwitchToTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SwitchToTimer", __pb.Bytes);
        }
        public void SwitchToItemCounter()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SwitchToItemCounter", __pb.Bytes);
        }
        public void PlaySoundEffect(SoundBase Sound, float VolumeMultiplier, float PitchMultiplier, bool PlayInScope)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, Sound);
            __pb.Set(0x8, VolumeMultiplier);
            __pb.Set(0xC, PitchMultiplier);
            __pb.Set<byte>(0x10, (byte)(PlayInScope?1:0));
            CallRaw("PlaySoundEffect", __pb.Bytes);
        }
        public void SetToScopeView()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetToScopeView", __pb.Bytes);
        }
        public void BindMercRing(FloatingUI_BP_C FloatingUI)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, FloatingUI);
            CallRaw("BindMercRing", __pb.Bytes);
        }
        public void HandleOnUpdateItemCounter(EItemId ItemId, int ItemCount, bool isWarning, EVR4PromptUIAlignment Alignment)
        {
            var __pb = new ParamBuffer(10);
            __pb.Set<byte>(0x0, (byte)ItemId);
            __pb.Set(0x4, ItemCount);
            __pb.Set<byte>(0x8, (byte)(isWarning?1:0));
            __pb.Set<byte>(0x9, (byte)Alignment);
            CallRaw("HandleOnUpdateItemCounter", __pb.Bytes);
        }
        public void HandleOnUpdateTimerDisplay(int Minutes, int Seconds, int centiseconds, bool IsPaused, bool isWarning, EVR4PromptUIAlignment Alignment)
        {
            var __pb = new ParamBuffer(15);
            __pb.Set(0x0, Minutes);
            __pb.Set(0x4, Seconds);
            __pb.Set(0x8, centiseconds);
            __pb.Set<byte>(0xC, (byte)(IsPaused?1:0));
            __pb.Set<byte>(0xD, (byte)(isWarning?1:0));
            __pb.Set<byte>(0xE, (byte)Alignment);
            CallRaw("HandleOnUpdateTimerDisplay", __pb.Bytes);
        }
        public void HandleOnUpdateMercenariesUI(global::System.IntPtr newDisplayInfo)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<global::System.IntPtr>(0x0, newDisplayInfo);
            CallRaw("HandleOnUpdateMercenariesUI", __pb.Bytes);
        }
        public void CancelAnimationsMercRing()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CancelAnimationsMercRing", __pb.Bytes);
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
        public void UpdateMercUI(int Score, int Combo_Count, bool Combo_Ending_Warning, bool IsShowingBonusTime, int Bonus_Time_Multiplier, bool Bonus_Time_Ending_Warning)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set(0x0, Score);
            __pb.Set(0x4, Combo_Count);
            __pb.Set<byte>(0x8, (byte)(Combo_Ending_Warning?1:0));
            __pb.Set<byte>(0x9, (byte)(IsShowingBonusTime?1:0));
            __pb.Set(0xC, Bonus_Time_Multiplier);
            __pb.Set<byte>(0x10, (byte)(Bonus_Time_Ending_Warning?1:0));
            CallRaw("UpdateMercUI", __pb.Bytes);
        }
        public void BonusScoreAdded(int bonusScore)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, bonusScore);
            CallRaw("BonusScoreAdded", __pb.Bytes);
        }
        public void ShowItemPrompt(global::System.IntPtr Text)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            CallRaw("ShowItemPrompt", __pb.Bytes);
        }
        public void HideItemPrompt(bool ColorChange_, bool NewText_, global::System.IntPtr UpdatedText)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<byte>(0x0, (byte)(ColorChange_?1:0));
            __pb.Set<byte>(0x1, (byte)(NewText_?1:0));
            __pb.Set<global::System.IntPtr>(0x8, UpdatedText);
            CallRaw("HideItemPrompt", __pb.Bytes);
        }
        public void HideItemPromptLeft(bool NewText_, global::System.IntPtr Text, int TimeIncrease)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<byte>(0x0, (byte)(NewText_?1:0));
            __pb.Set<global::System.IntPtr>(0x8, Text);
            __pb.Set(0x18, TimeIncrease);
            CallRaw("HideItemPromptLeft", __pb.Bytes);
        }
        public void HideItemPromptRight(bool NewText_, global::System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)(NewText_?1:0));
            __pb.Set<global::System.IntPtr>(0x8, Text);
            CallRaw("HideItemPromptRight", __pb.Bytes);
        }
        public void HideComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideComplete", __pb.Bytes);
        }
        public void HideDelayExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideDelayExpired", __pb.Bytes);
        }
        public void RemovePromptLeftDone()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RemovePromptLeftDone", __pb.Bytes);
        }
        public void HideDelayExpired2()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideDelayExpired2", __pb.Bytes);
        }
        public void CustomEvent_1()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CustomEvent_1", __pb.Bytes);
        }
        public void PlayRightActive()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayRightActive", __pb.Bytes);
        }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void DisplayItemCounter(int ItemCount, EItemId ItemId, bool isWarning)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set(0x0, ItemCount);
            __pb.Set<byte>(0x4, (byte)ItemId);
            __pb.Set<byte>(0x5, (byte)(isWarning?1:0));
            CallRaw("DisplayItemCounter", __pb.Bytes);
        }
        public void ResetAddedtime()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetAddedtime", __pb.Bytes);
        }
        public void CustomEvent()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CustomEvent", __pb.Bytes);
        }
        public void ExecuteUbergraph_MercRing(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_MercRing", __pb.Bytes);
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
