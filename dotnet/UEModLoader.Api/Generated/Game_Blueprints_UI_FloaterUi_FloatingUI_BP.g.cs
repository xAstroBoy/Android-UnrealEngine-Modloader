// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/FloatingUI_BP
using System;

namespace UEModLoader.Game
{
    public class FloatingUI_BP_C : VR4FloaterUI
    {
        public const string UeClassName = "FloatingUI_BP_C";
        public FloatingUI_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new FloatingUI_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FloatingUI_BP_C(p);
        public static FloatingUI_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FloatingUI_BP_C(o.Pointer); }
        public static FloatingUI_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FloatingUI_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FloatingUI_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public SceneComponent FlyTextLocConsumbable { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent FlyTextLoc1 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ItemPromptAnchor { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent WidgetPivotTop { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent WidgetNotePivot { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent WidgetNote { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public BoxComponent Box3 { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent Coin { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent CoinRoot { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent WidgetTop { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public BoxComponent box2 { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent FlyTextLoc { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ChildActor3DController { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public BoxComponent box1 { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent WidgetPivot { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent LineTarget { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Scene { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_HideCoin_Alpha_055C381949957D38E32C00B25E56F1A7 { get => GetAt<float>(0x2F0); set => SetAt(0x2F0, value); }
        public byte Timeline_HideCoin__Direction_055C381949957D38E32C00B25E56F1A7 { get => GetAt<byte>(0x2F4); set => SetAt(0x2F4, value); }
        public TimelineComponent Timeline_HideCoin { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_ShowCoin_Translation_C7B9B93E49A39FC9C8B1A283B3B03702 { get => GetAt<float>(0x300); set => SetAt(0x300, value); }
        public float Timeline_ShowCoin_Rotation_C7B9B93E49A39FC9C8B1A283B3B03702 { get => GetAt<float>(0x304); set => SetAt(0x304, value); }
        public float Timeline_ShowCoin_Scale_C7B9B93E49A39FC9C8B1A283B3B03702 { get => GetAt<float>(0x308); set => SetAt(0x308, value); }
        public byte Timeline_ShowCoin__Direction_C7B9B93E49A39FC9C8B1A283B3B03702 { get => GetAt<byte>(0x30C); set => SetAt(0x30C, value); }
        public TimelineComponent Timeline_ShowCoin { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_WidgetOpacity_Alpha_1B2B6ED7436D65384A3E93B6F2610E2B { get => GetAt<float>(0x318); set => SetAt(0x318, value); }
        public byte Timeline_WidgetOpacity__Direction_1B2B6ED7436D65384A3E93B6F2610E2B { get => GetAt<byte>(0x31C); set => SetAt(0x31C, value); }
        public TimelineComponent Timeline_WidgetOpacity { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_MoveCommand_Alpha_12778CE7433950C98E6A7B93DCAB0230 { get => GetAt<float>(0x328); set => SetAt(0x328, value); }
        public byte Timeline_MoveCommand__Direction_12778CE7433950C98E6A7B93DCAB0230 { get => GetAt<byte>(0x32C); set => SetAt(0x32C, value); }
        public TimelineComponent Timeline_MoveCommand { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_SubtitleScaleAlt_alpha_D7805A214B461DEA1D6A57B8A002CE05 { get => GetAt<float>(0x338); set => SetAt(0x338, value); }
        public byte Timeline_SubtitleScaleAlt__Direction_D7805A214B461DEA1D6A57B8A002CE05 { get => GetAt<byte>(0x33C); set => SetAt(0x33C, value); }
        public TimelineComponent Timeline_SubtitleScaleAlt { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_SubtitleScale_alpha_C74C0F8C4288E08A3E533397B659C6AA { get => GetAt<float>(0x348); set => SetAt(0x348, value); }
        public byte Timeline_SubtitleScale__Direction_C74C0F8C4288E08A3E533397B659C6AA { get => GetAt<byte>(0x34C); set => SetAt(0x34C, value); }
        public TimelineComponent Timeline_SubtitleScale { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_CommandScale_NewTrack_2_BA4B8A5E4DD56CC57446B9A8CEB0355A { get => GetAt<float>(0x358); set => SetAt(0x358, value); }
        public byte Timeline_CommandScale__Direction_BA4B8A5E4DD56CC57446B9A8CEB0355A { get => GetAt<byte>(0x35C); set => SetAt(0x35C, value); }
        public TimelineComponent Timeline_CommandScale { get { var __p = GetAt<System.IntPtr>(0x360); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x360, value?.Pointer ?? System.IntPtr.Zero); }
        public InfoRing_C InfoRing { get { var __p = GetAt<System.IntPtr>(0x368); return __p==System.IntPtr.Zero?null:new InfoRing_C(__p); } set => SetAt(0x368, value?.Pointer ?? System.IntPtr.Zero); }
        public bool FlipText { get => Native.GetPropBool(Pointer, "FlipText"); set => Native.SetPropBool(Pointer, "FlipText", value); }
        public bool IsDisplayingThought { get => Native.GetPropBool(Pointer, "IsDisplayingThought"); set => Native.SetPropBool(Pointer, "IsDisplayingThought", value); }
        public Actor TextPromptOwner { get { var __p = GetAt<System.IntPtr>(0x378); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x378, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr NewMessageLine => AddrOf(0x380); // 
        public TimerHandle SubtitleTimer => new TimerHandle(AddrOf(0x398));
        public WidgetComponent Subtitles { get { var __p = GetAt<System.IntPtr>(0x3A0); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x3A0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent SubtitleWidget { get { var __p = GetAt<System.IntPtr>(0x3A8); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x3A8, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> Drip => new TArray<System.IntPtr>(AddrOf(0x3B0)); // TArray<UObject*>
        public TArray<System.IntPtr> DripAlt => new TArray<System.IntPtr>(AddrOf(0x3C0)); // TArray<UObject*>
        public TArray<System.IntPtr> DripC => new TArray<System.IntPtr>(AddrOf(0x3D0)); // TArray<UObject*>
        public bool UIActive { get => Native.GetPropBool(Pointer, "UIActive"); set => Native.SetPropBool(Pointer, "UIActive", value); }
        public bool IsClosing { get => Native.GetPropBool(Pointer, "IsClosing"); set => Native.SetPropBool(Pointer, "IsClosing", value); }
        public TimerHandle CloseTimer => new TimerHandle(AddrOf(0x3E8));
        public bool MuteSound { get => Native.GetPropBool(Pointer, "MuteSound"); set => Native.SetPropBool(Pointer, "MuteSound", value); }
        public bool ShowIcon { get => Native.GetPropBool(Pointer, "ShowIcon"); set => Native.SetPropBool(Pointer, "ShowIcon", value); }
        public bool CommandVisible { get => Native.GetPropBool(Pointer, "CommandVisible"); set => Native.SetPropBool(Pointer, "CommandVisible", value); }
        public bool SubtitleVisible { get => Native.GetPropBool(Pointer, "SubtitleVisible"); set => Native.SetPropBool(Pointer, "SubtitleVisible", value); }
        public bool SubtitleAltVisible { get => Native.GetPropBool(Pointer, "SubtitleAltVisible"); set => Native.SetPropBool(Pointer, "SubtitleAltVisible", value); }
        public System.IntPtr ItemTextQueue => AddrOf(0x3F8); // 
        public float MinimizeTime { get => GetAt<float>(0x410); set => SetAt(0x410, value); }
        public TimerHandle MinimizeTimer => new TimerHandle(AddrOf(0x418));
        public bool MinimizeLeft { get => Native.GetPropBool(Pointer, "MinimizeLeft"); set => Native.SetPropBool(Pointer, "MinimizeLeft", value); }
        public EVR4CommandButton commandButton { get => (EVR4CommandButton)GetAt<byte>(0x421); set => SetAt(0x421, (byte)value); }
        public Vector WidgetScale => new Vector(AddrOf(0x424));
        public ControllerIcon3d_C _3DIcon { get { var __p = GetAt<System.IntPtr>(0x430); return __p==System.IntPtr.Zero?null:new ControllerIcon3d_C(__p); } set => SetAt(0x430, value?.Pointer ?? System.IntPtr.Zero); }
        public TimerHandle PreTranslateDelay => new TimerHandle(AddrOf(0x438));
        public float MinimizeHDistance { get => GetAt<float>(0x440); set => SetAt(0x440, value); }
        public TimerHandle SmallTextTimer => new TimerHandle(AddrOf(0x448));
        public TArray<System.IntPtr> HideWidgetList => new TArray<System.IntPtr>(AddrOf(0x450)); // TArray<UObject*>
        public bool WidgetShouldBeHidden { get => Native.GetPropBool(Pointer, "WidgetShouldBeHidden"); set => Native.SetPropBool(Pointer, "WidgetShouldBeHidden", value); }
        public bool _3DIconActive { get => Native.GetPropBool(Pointer, "3DIconActive"); set => Native.SetPropBool(Pointer, "3DIconActive", value); }
        public Vignette_QTE_C SlowMo { get { var __p = GetAt<System.IntPtr>(0x468); return __p==System.IntPtr.Zero?null:new Vignette_QTE_C(__p); } set => SetAt(0x468, value?.Pointer ?? System.IntPtr.Zero); }
        public EActionButtonType CurrentAction { get => (EActionButtonType)GetAt<byte>(0x470); set => SetAt(0x470, (byte)value); }
        public TimerHandle IconDelay => new TimerHandle(AddrOf(0x478));
        public TimerHandle ObstructionTimer => new TimerHandle(AddrOf(0x480));
        public string NewCommand => Native.GetPropString(Pointer, "NewCommand"); // FString
        public bool CommandWasSmall { get => Native.GetPropBool(Pointer, "CommandWasSmall"); set => Native.SetPropBool(Pointer, "CommandWasSmall", value); }
        public TimerHandle KeepSmallTimer => new TimerHandle(AddrOf(0x4A0));
        public EQTEId CurrentQte { get => (EQTEId)GetAt<byte>(0x4A8); set => SetAt(0x4A8, (byte)value); }
        public TopRing_C TopRing { get { var __p = GetAt<System.IntPtr>(0x4B0); return __p==System.IntPtr.Zero?null:new TopRing_C(__p); } set => SetAt(0x4B0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool Use3DForSmallIcon { get => Native.GetPropBool(Pointer, "Use3DForSmallIcon"); set => Native.SetPropBool(Pointer, "Use3DForSmallIcon", value); }
        public NoteInstruction_C Note { get { var __p = GetAt<System.IntPtr>(0x4C0); return __p==System.IntPtr.Zero?null:new NoteInstruction_C(__p); } set => SetAt(0x4C0, value?.Pointer ?? System.IntPtr.Zero); }
        public EVR4CommandButton CommandButtonNote { get => (EVR4CommandButton)GetAt<byte>(0x4C8); set => SetAt(0x4C8, (byte)value); }
        public TimerHandle SmallTextNoteTimer => new TimerHandle(AddrOf(0x4D0));
        public bool QteResult { get => Native.GetPropBool(Pointer, "QteResult"); set => Native.SetPropBool(Pointer, "QteResult", value); }
        public TimerHandle QteResultTimer => new TimerHandle(AddrOf(0x4E0));
        public bool PlayerHasDied { get => Native.GetPropBool(Pointer, "PlayerHasDied"); set => Native.SetPropBool(Pointer, "PlayerHasDied", value); }
        public bool success { get => Native.GetPropBool(Pointer, "success"); set => Native.SetPropBool(Pointer, "success", value); }
        public bool ShouldPlayEffects { get => Native.GetPropBool(Pointer, "ShouldPlayEffects"); set => Native.SetPropBool(Pointer, "ShouldPlayEffects", value); }
        public bool DisplayingQte { get => Native.GetPropBool(Pointer, "DisplayingQte"); set => Native.SetPropBool(Pointer, "DisplayingQte", value); }
        public bool RevealPromptFast { get => Native.GetPropBool(Pointer, "RevealPromptFast"); set => Native.SetPropBool(Pointer, "RevealPromptFast", value); }
        public bool CanBeMinimized { get => Native.GetPropBool(Pointer, "CanBeMinimized"); set => Native.SetPropBool(Pointer, "CanBeMinimized", value); }
        public TArray<System.IntPtr> AlwaysLargePrompts => new TArray<System.IntPtr>(AddrOf(0x4F0)); // TArray<enum>
        public TArray<System.IntPtr> FastPrompts => new TArray<System.IntPtr>(AddrOf(0x500)); // TArray<enum>
        public FloatingUI_Flytext_BP_C ItemFlyText { get { var __p = GetAt<System.IntPtr>(0x510); return __p==System.IntPtr.Zero?null:new FloatingUI_Flytext_BP_C(__p); } set => SetAt(0x510, value?.Pointer ?? System.IntPtr.Zero); }
        public FloatingUI_Flytext_BP_C ConsumeFlyText { get { var __p = GetAt<System.IntPtr>(0x518); return __p==System.IntPtr.Zero?null:new FloatingUI_Flytext_BP_C(__p); } set => SetAt(0x518, value?.Pointer ?? System.IntPtr.Zero); }
        public bool ForceQTEResult_ { get => Native.GetPropBool(Pointer, "ForceQTEResult?"); set => Native.SetPropBool(Pointer, "ForceQTEResult?", value); }
        public bool IsHoldingNote { get => Native.GetPropBool(Pointer, "IsHoldingNote"); set => Native.SetPropBool(Pointer, "IsHoldingNote", value); }
        public Actor MercHud { get { var __p = GetAt<System.IntPtr>(0x528); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x528, value?.Pointer ?? System.IntPtr.Zero); }
        public int temp { get => GetAt<int>(0x530); set => SetAt(0x530, value); }
        public bool ShowDebugEvent { get => Native.GetPropBool(Pointer, "ShowDebugEvent"); set => Native.SetPropBool(Pointer, "ShowDebugEvent", value); }
        public System.IntPtr OnUpdateTimerDisplay => AddrOf(0x538); // 
        public System.IntPtr OnUpdateMercenariesUI => AddrOf(0x548); // 
        public System.IntPtr OnBonusScoreAdded => AddrOf(0x558); // 
        public System.IntPtr OnUpdateItemCounter => AddrOf(0x568); // 
        public void TryHideMercItemPrompt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TryHideMercItemPrompt", __pb.Bytes);
        }
        public void IsPlayerInScope(bool InScope)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InScope?1:0));
            CallRaw("IsPlayerInScope", __pb.Bytes);
        }
        public void DebugEvent(System.IntPtr String)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, String);
            CallRaw("DebugEvent", __pb.Bytes);
        }
        public void Get_Merc_Hud(Actor MercHud, bool Valid_)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, MercHud);
            __pb.Set<byte>(0x8, (byte)(Valid_?1:0));
            CallRaw("Get Merc Hud", __pb.Bytes);
        }
        public bool IsShowingNotePrompt()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsShowingNotePrompt", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void SpawnConsumableFlytext(System.IntPtr Message, Vector SpawnLocation)
        {
            var __pb = new ParamBuffer(36);
            __pb.Set<System.IntPtr>(0x0, Message);
            __pb.Set<System.IntPtr>(0x18, SpawnLocation);
            CallRaw("SpawnConsumableFlytext", __pb.Bytes);
        }
        public void SetCommandRenderTranslation(float XValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, XValue);
            CallRaw("SetCommandRenderTranslation", __pb.Bytes);
        }
        public bool IsClosing_2()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsClosing", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void StopQte()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopQte", __pb.Bytes);
        }
        public void RemoveSpikes()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RemoveSpikes", __pb.Bytes);
        }
        public void HideNote()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideNote", __pb.Bytes);
        }
        public void ShowInstantSmallTextNote(EVR4CommandButton commandButton, System.IntPtr NewPrompt)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<byte>(0x0, (byte)commandButton);
            __pb.Set<System.IntPtr>(0x8, NewPrompt);
            CallRaw("ShowInstantSmallTextNote", __pb.Bytes);
        }
        public void SpawnUiFlytext(System.IntPtr Message)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Message);
            CallRaw("SpawnUiFlytext", __pb.Bytes);
        }
        public void InstantSmallText()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InstantSmallText", __pb.Bytes);
        }
        public void StartSloMo(EVR4CommandButton Button, EActionButtonType Action, EQTEId QTEId, float SpikeDuration, float SpikeScale, float IconDelay)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<byte>(0x0, (byte)Button);
            __pb.Set<byte>(0x1, (byte)Action);
            __pb.Set<byte>(0x2, (byte)QTEId);
            __pb.Set(0x4, SpikeDuration);
            __pb.Set(0x8, SpikeScale);
            __pb.Set(0xC, IconDelay);
            CallRaw("StartSloMo", __pb.Bytes);
        }
        public bool IsDisplaying()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsDisplaying", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void ListEmpty_(Actor Actor, bool IsEmpty)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Actor);
            __pb.Set<byte>(0x8, (byte)(IsEmpty?1:0));
            CallRaw("ListEmpty?", __pb.Bytes);
        }
        public void CancelMove(bool instant, bool OnShowCommand, System.IntPtr Command, bool NormalShow)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<byte>(0x0, (byte)(instant?1:0));
            __pb.Set<byte>(0x1, (byte)(OnShowCommand?1:0));
            __pb.Set<System.IntPtr>(0x8, Command);
            __pb.Set<byte>(0x18, (byte)(NormalShow?1:0));
            CallRaw("CancelMove", __pb.Bytes);
        }
        public void UpdateWidgetVisibility()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateWidgetVisibility", __pb.Bytes);
        }
        public void ToggleInput()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleInput", __pb.Bytes);
        }
        public void Initialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void Timeline_ShowCoin__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ShowCoin__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ShowCoin__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ShowCoin__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_HideCoin__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_HideCoin__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_HideCoin__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_HideCoin__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_CommandScale__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_CommandScale__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_CommandScale__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_CommandScale__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_SubtitleScale__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_SubtitleScale__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_SubtitleScale__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_SubtitleScale__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_SubtitleScaleAlt__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_SubtitleScaleAlt__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_SubtitleScaleAlt__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_SubtitleScaleAlt__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_MoveCommand__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MoveCommand__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_MoveCommand__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MoveCommand__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_WidgetOpacity__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_WidgetOpacity__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_WidgetOpacity__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_WidgetOpacity__UpdateFunc", __pb.Bytes);
        }
        public void SetTimerDisplay(int Minutes, int Seconds, int centiseconds, bool IsPaused, bool isWarning, EVR4PromptUIAlignment Alignment)
        {
            var __pb = new ParamBuffer(15);
            __pb.Set(0x0, Minutes);
            __pb.Set(0x4, Seconds);
            __pb.Set(0x8, centiseconds);
            __pb.Set<byte>(0xC, (byte)(IsPaused?1:0));
            __pb.Set<byte>(0xD, (byte)(isWarning?1:0));
            __pb.Set<byte>(0xE, (byte)Alignment);
            CallRaw("SetTimerDisplay", __pb.Bytes);
        }
        public void UpdateTopWidgetRendering(bool Visible, bool UseManualRedraw)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            __pb.Set<byte>(0x1, (byte)(UseManualRedraw?1:0));
            CallRaw("UpdateTopWidgetRendering", __pb.Bytes);
        }
        public void ShowCoinMesh()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowCoinMesh", __pb.Bytes);
        }
        public void HideCoinMesh(bool instant)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(instant?1:0));
            CallRaw("HideCoinMesh", __pb.Bytes);
        }
        public void ShowAshleySubtitle(System.IntPtr Message, float DisplayTime)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<System.IntPtr>(0x0, Message);
            __pb.Set(0x18, DisplayTime);
            CallRaw("ShowAshleySubtitle", __pb.Bytes);
        }
        public void OnShotMedallion(int Count, int MaxCount)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Count);
            __pb.Set(0x4, MaxCount);
            CallRaw("OnShotMedallion", __pb.Bytes);
        }
        public void UpdateMercUI(MercDisplayInfo newDisplayInfo)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<System.IntPtr>(0x0, newDisplayInfo);
            CallRaw("UpdateMercUI", __pb.Bytes);
        }
        public void BonusScoreAdded(int bonusScore)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, bonusScore);
            CallRaw("BonusScoreAdded", __pb.Bytes);
        }
        public void SetItemCounterDisplay(EItemId ItemId, int ItemCount, bool isWarning, EVR4PromptUIAlignment Alignment)
        {
            var __pb = new ParamBuffer(10);
            __pb.Set<byte>(0x0, (byte)ItemId);
            __pb.Set(0x4, ItemCount);
            __pb.Set<byte>(0x8, (byte)(isWarning?1:0));
            __pb.Set<byte>(0x9, (byte)Alignment);
            CallRaw("SetItemCounterDisplay", __pb.Bytes);
        }
        public void ShowLeonSubtitleForR210()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowLeonSubtitleForR210", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void DisplayCommandInteraction(System.IntPtr NewPrompt, EVR4CommandButton commandButton)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, NewPrompt);
            __pb.Set<byte>(0x10, (byte)commandButton);
            CallRaw("DisplayCommandInteraction", __pb.Bytes);
        }
        public void ShowCommand()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowCommand", __pb.Bytes);
        }
        public void HideCommand()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideCommand", __pb.Bytes);
        }
        public void HideUI(bool playEffects)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(playEffects?1:0));
            CallRaw("HideUI", __pb.Bytes);
        }
        public void NextTextPrompt(System.IntPtr MessagePrompt)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, MessagePrompt);
            CallRaw("NextTextPrompt", __pb.Bytes);
        }
        public void NewSubtitle(System.IntPtr Message, float Duration, Actor Owner)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, Message);
            __pb.Set(0x18, Duration);
            __pb.SetObject(0x20, Owner);
            CallRaw("NewSubtitle", __pb.Bytes);
        }
        public void GrowSubtitle()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GrowSubtitle", __pb.Bytes);
        }
        public void ShrinkSubtitle(Actor Owner, bool ForceClose)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Owner);
            __pb.Set<byte>(0x8, (byte)(ForceClose?1:0));
            CallRaw("ShrinkSubtitle", __pb.Bytes);
        }
        public void ForceScaleDownSubtitle()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ForceScaleDownSubtitle", __pb.Bytes);
        }
        public void PlayDrips(UserWidget Target, System.IntPtr Drips)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Target);
            __pb.Set<System.IntPtr>(0x8, Drips);
            CallRaw("PlayDrips", __pb.Bytes);
        }
        public void StopDrips(UserWidget TargetWidget, System.IntPtr Drips)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, TargetWidget);
            __pb.Set<System.IntPtr>(0x8, Drips);
            CallRaw("StopDrips", __pb.Bytes);
        }
        public void GrowSubtitleAlt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GrowSubtitleAlt", __pb.Bytes);
        }
        public void ShrinkSubtitleAlt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShrinkSubtitleAlt", __pb.Bytes);
        }
        public void ForceScaleDownSubtitleAlt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ForceScaleDownSubtitleAlt", __pb.Bytes);
        }
        public void SubtitleTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SubtitleTimerExpired", __pb.Bytes);
        }
        public void SetInteractionCommand(System.IntPtr textPrompt, EVR4CommandButton commandButton, EActionButtonType actionType, EQTEId QTEId, EVR4PromptSize promptSize)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<System.IntPtr>(0x0, textPrompt);
            __pb.Set<byte>(0x18, (byte)commandButton);
            __pb.Set<byte>(0x19, (byte)actionType);
            __pb.Set<byte>(0x1A, (byte)QTEId);
            __pb.Set<byte>(0x1B, (byte)promptSize);
            CallRaw("SetInteractionCommand", __pb.Bytes);
        }
        public void SetThoughtPrompt(System.IntPtr textPrompt, EVR4PromptUIAlignment Alignment)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, textPrompt);
            __pb.Set<byte>(0x18, (byte)Alignment);
            CallRaw("SetThoughtPrompt", __pb.Bytes);
        }
        public void PlayNextEffect(bool FlashRing)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(FlashRing?1:0));
            CallRaw("PlayNextEffect", __pb.Bytes);
        }
        public void SetAlignment(EVR4PromptUIAlignment Alignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Alignment);
            CallRaw("SetAlignment", __pb.Bytes);
        }
        public void CloseTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CloseTimerExpired", __pb.Bytes);
        }
        public void PlaySound(SoundBase Sound)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Sound);
            CallRaw("PlaySound", __pb.Bytes);
        }
        public void SetItemPrompt(System.IntPtr textPrompt, EVR4PromptUIAlignment Alignment)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, textPrompt);
            __pb.Set<byte>(0x18, (byte)Alignment);
            CallRaw("SetItemPrompt", __pb.Bytes);
        }
        public void SetLineTarget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetLineTarget", __pb.Bytes);
        }
        public void OnClose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnClose", __pb.Bytes);
        }
        public void MinimizeCommand()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("MinimizeCommand", __pb.Bytes);
        }
        public void TimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TimerExpired", __pb.Bytes);
        }
        public void ScaleComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ScaleComplete", __pb.Bytes);
        }
        public void PreTranslateDelayFinished()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PreTranslateDelayFinished", __pb.Bytes);
        }
        public void ReverseMoveCommand()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReverseMoveCommand", __pb.Bytes);
        }
        public void RevealSmallText()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RevealSmallText", __pb.Bytes);
        }
        public void HideWidget(Actor Actor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Actor);
            CallRaw("HideWidget", __pb.Bytes);
        }
        public void ShowWidget(Actor Actor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Actor);
            CallRaw("ShowWidget", __pb.Bytes);
        }
        public void HideWidgetNow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideWidgetNow", __pb.Bytes);
        }
        public void ShowWidgetInstant()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowWidgetInstant", __pb.Bytes);
        }
        public void IconDelayExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IconDelayExpired", __pb.Bytes);
        }
        public void RevealSmallTextOnDelay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RevealSmallTextOnDelay", __pb.Bytes);
        }
        public void StartKeepSmallTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartKeepSmallTimer", __pb.Bytes);
        }
        public void KeepSmallTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("KeepSmallTimerExpired", __pb.Bytes);
        }
        public void ShowInstantSmallCommand(System.IntPtr NewPrompt, EVR4CommandButton commandButton, EQTEId CurrentQte, EActionButtonType CurrentAction)
        {
            var __pb = new ParamBuffer(27);
            __pb.Set<System.IntPtr>(0x0, NewPrompt);
            __pb.Set<byte>(0x18, (byte)commandButton);
            __pb.Set<byte>(0x19, (byte)CurrentQte);
            __pb.Set<byte>(0x1A, (byte)CurrentAction);
            CallRaw("ShowInstantSmallCommand", __pb.Bytes);
        }
        public void RevealSmallTextNote()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RevealSmallTextNote", __pb.Bytes);
        }
        public void RevealSmallTextNoteOnDelay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RevealSmallTextNoteOnDelay", __pb.Bytes);
        }
        public void QteSucceeded(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("QteSucceeded", __pb.Bytes);
        }
        public void PlayerDied(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("PlayerDied", __pb.Bytes);
        }
        public void QteResultTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("QteResultTimerExpired", __pb.Bytes);
        }
        public void CancelResult()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CancelResult", __pb.Bytes);
        }
        public void QteFailed(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("QteFailed", __pb.Bytes);
        }
        public void QteMotionFailed(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("QteMotionFailed", __pb.Bytes);
        }
        public void SetLevelPrompt(System.IntPtr textPrompt, EVR4CommandButton commandButton)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, textPrompt);
            __pb.Set<byte>(0x18, (byte)commandButton);
            CallRaw("SetLevelPrompt", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ExecuteUbergraph_FloatingUI_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_FloatingUI_BP", __pb.Bytes);
        }
        public void OnUpdateItemCounter__DelegateSignature(EItemId ItemId, int ItemCount, bool isWarning, EVR4PromptUIAlignment Alignment)
        {
            var __pb = new ParamBuffer(10);
            __pb.Set<byte>(0x0, (byte)ItemId);
            __pb.Set(0x4, ItemCount);
            __pb.Set<byte>(0x8, (byte)(isWarning?1:0));
            __pb.Set<byte>(0x9, (byte)Alignment);
            CallRaw("OnUpdateItemCounter__DelegateSignature", __pb.Bytes);
        }
        public void OnBonusScoreAdded__DelegateSignature(int bonusScore)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, bonusScore);
            CallRaw("OnBonusScoreAdded__DelegateSignature", __pb.Bytes);
        }
        public void OnUpdateMercenariesUI__DelegateSignature(MercDisplayInfo newDisplayInfo)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<System.IntPtr>(0x0, newDisplayInfo);
            CallRaw("OnUpdateMercenariesUI__DelegateSignature", __pb.Bytes);
        }
        public void OnUpdateTimerDisplay__DelegateSignature(int Minutes, int Seconds, int centiseconds, bool IsPaused, bool isWarning, EVR4PromptUIAlignment Alignment)
        {
            var __pb = new ParamBuffer(15);
            __pb.Set(0x0, Minutes);
            __pb.Set(0x4, Seconds);
            __pb.Set(0x8, centiseconds);
            __pb.Set<byte>(0xC, (byte)(IsPaused?1:0));
            __pb.Set<byte>(0xD, (byte)(isWarning?1:0));
            __pb.Set<byte>(0xE, (byte)Alignment);
            CallRaw("OnUpdateTimerDisplay__DelegateSignature", __pb.Bytes);
        }
    }

}
