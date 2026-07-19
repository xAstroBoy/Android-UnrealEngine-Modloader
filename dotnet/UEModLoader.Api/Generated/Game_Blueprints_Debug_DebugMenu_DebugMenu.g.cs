// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMenu/DebugMenu
using System;

namespace UEModLoader.Game
{
    public class DebugMenu_C : VR4DebugScreenActor
    {
        public const string UeClassName = "DebugMenu_C";
        public DebugMenu_C(System.IntPtr ptr) : base(ptr) {}
        public static new DebugMenu_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DebugMenu_C(p);
        public static DebugMenu_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugMenu_C(o.Pointer); }
        public static DebugMenu_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugMenu_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugMenu_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4Bio4PlayerPawn Player { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new VR4Bio4PlayerPawn(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> ActiveOptionList => new TArray<System.IntPtr>(AddrOf(0x240)); // TArray<FName>
        public TArray<System.IntPtr> ActiveOptionsWidgets => new TArray<System.IntPtr>(AddrOf(0x250)); // TArray<UObject*>
        public int CurrentIndex { get => GetAt<int>(0x260); set => SetAt(0x260, value); }
        public byte ActiveMenu { get => GetAt<byte>(0x264); set => SetAt(0x264, value); }
        public TArray<System.IntPtr> BoolStrings => new TArray<System.IntPtr>(AddrOf(0x268)); // TArray<FString>
        public DebugMenuWidget_C ParentWidget { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new DebugMenuWidget_C(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public bool LevelSelectActive { get => Native.GetPropBool(Pointer, "LevelSelectActive"); set => Native.SetPropBool(Pointer, "LevelSelectActive", value); }
        public stage1debugmap_C Stage1Map { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new stage1debugmap_C(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public stage2debugmap_C Stage2Map { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new stage2debugmap_C(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public stage3debugmap_C Stage3Map { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new stage3debugmap_C(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public TimerHandle ScrollTimer => new TimerHandle(AddrOf(0x2A0));
        public string HackLevelName => Native.GetPropName(Pointer, "HackLevelName"); // FName
        public FName HackLevelName_Raw { get => GetAt<FName>(0x2A8); set => SetAt(0x2A8, value); }
        public TArray<System.IntPtr> PIckupItemQuickMenu => new TArray<System.IntPtr>(AddrOf(0x2B0)); // TArray<enum>
        public bool ShowAllItems { get => Native.GetPropBool(Pointer, "ShowAllItems"); set => Native.SetPropBool(Pointer, "ShowAllItems", value); }
        public TArray<System.IntPtr> PreviousMenus => new TArray<System.IntPtr>(AddrOf(0x2C8)); // TArray<uint8>
        public bool FogIsEnabled { get => Native.GetPropBool(Pointer, "FogIsEnabled"); set => Native.SetPropBool(Pointer, "FogIsEnabled", value); }
        public VR4DebugSettings DebugSettings => new VR4DebugSettings(AddrOf(0x2E0));
        public byte FinishGameDifficulty { get => GetAt<byte>(0x380); set => SetAt(0x380, value); }
        public TArray<System.IntPtr> Favorites => new TArray<System.IntPtr>(AddrOf(0x388)); // TArray<FName>
        public TimerHandle DoubleClickTimer => new TimerHandle(AddrOf(0x398));
        public byte OptionMenuType { get => GetAt<byte>(0x3A0); set => SetAt(0x3A0, value); }
        public string ActiveShortcut => Native.GetPropName(Pointer, "ActiveShortcut"); // FName
        public FName ActiveShortcut_Raw { get => GetAt<FName>(0x3A4); set => SetAt(0x3A4, value); }
        public bool EcheckBool { get => Native.GetPropBool(Pointer, "EcheckBool"); set => Native.SetPropBool(Pointer, "EcheckBool", value); }
        public bool FavShowAllItems { get => Native.GetPropBool(Pointer, "FavShowAllItems"); set => Native.SetPropBool(Pointer, "FavShowAllItems", value); }
        public System.IntPtr UnlockTooltipText => AddrOf(0x3B0); // 
        public void IsActive(bool Active)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Active?1:0));
            CallRaw("IsActive", __pb.Bytes);
        }
        public void OpenDebugMenu(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("OpenDebugMenu", __pb.Bytes);
        }
        public void HideDebugMenu(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("HideDebugMenu", __pb.Bytes);
        }
        public void ToggleMercRainFX()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleMercRainFX", __pb.Bytes);
        }
        public void BuildUnlockableTooltips(System.IntPtr OptionName, System.IntPtr Tooltip)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, OptionName);
            __pb.Set<System.IntPtr>(0x10, Tooltip);
            CallRaw("BuildUnlockableTooltips", __pb.Bytes);
        }
        public void IsUnlockEnabled(EMercenariesUnlockable MercenariesUnlock, System.IntPtr EnchancementString, bool IsUnlocked, bool IsEnabled)
        {
            var __pb = new ParamBuffer(26);
            __pb.Set<byte>(0x0, (byte)MercenariesUnlock);
            __pb.Set<System.IntPtr>(0x8, EnchancementString);
            __pb.Set<byte>(0x18, (byte)(IsUnlocked?1:0));
            __pb.Set<byte>(0x19, (byte)(IsEnabled?1:0));
            CallRaw("IsUnlockEnabled", __pb.Bytes);
        }
        public void ProcessUnlocks(System.IntPtr OptionName)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, OptionName);
            CallRaw("ProcessUnlocks", __pb.Bytes);
        }
        public void DrawCharacterUnlocks()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DrawCharacterUnlocks", __pb.Bytes);
        }
        public void DrawMercenariesUnlocks()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DrawMercenariesUnlocks", __pb.Bytes);
        }
        public void ToggleGoldenGunsUnlock()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleGoldenGunsUnlock", __pb.Bytes);
        }
        public void Get_Raise_Weapon_Setting(int NewParam)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewParam);
            CallRaw("Get Raise Weapon Setting", __pb.Bytes);
        }
        public void ProcessNewRaiseWeaponSetting(System.IntPtr Setting)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Setting);
            CallRaw("ProcessNewRaiseWeaponSetting", __pb.Bytes);
        }
        public void RefreshKeysTreasures()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RefreshKeysTreasures", __pb.Bytes);
        }
        public void RefreshInventory()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RefreshInventory", __pb.Bytes);
        }
        public void ProcessCutsceneSetting(System.IntPtr NewSetting)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewSetting);
            CallRaw("ProcessCutsceneSetting", __pb.Bytes);
        }
        public void ProcessFinishGameDifficulty(System.IntPtr NewSetting)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewSetting);
            CallRaw("ProcessFinishGameDifficulty", __pb.Bytes);
        }
        public void MaxOutPlayerInventory()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("MaxOutPlayerInventory", __pb.Bytes);
        }
        public void DrawAchievements()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DrawAchievements", __pb.Bytes);
        }
        public void ProcessFogSetting(System.IntPtr NewSetting)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewSetting);
            CallRaw("ProcessFogSetting", __pb.Bytes);
        }
        public void PreviousMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PreviousMenu", __pb.Bytes);
        }
        public void AddTreasureItems(ETreasureItem Start, ETreasureItem End)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Start);
            __pb.Set<byte>(0x1, (byte)End);
            CallRaw("AddTreasureItems", __pb.Bytes);
        }
        public void GetRenderingOptionIndex(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("GetRenderingOptionIndex", __pb.Bytes);
        }
        public void ProcessPixelDensitySetting(System.IntPtr NewSetting)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewSetting);
            CallRaw("ProcessPixelDensitySetting", __pb.Bytes);
        }
        public void CreateActiveOption(System.IntPtr Option)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Option);
            CallRaw("CreateActiveOption", __pb.Bytes);
        }
        public void ProcessParticleSetting(System.IntPtr NewSetting)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewSetting);
            CallRaw("ProcessParticleSetting", __pb.Bytes);
        }
        public void BuildTooltip(System.IntPtr Return)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Return);
            CallRaw("BuildTooltip", __pb.Bytes);
        }
        public void UpdateTooltip()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateTooltip", __pb.Bytes);
        }
        public void DoAction()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DoAction", __pb.Bytes);
        }
        public void ClearWidgets()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearWidgets", __pb.Bytes);
        }
        public void UpdateOptionHighlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateOptionHighlight", __pb.Bytes);
        }
        public void GetActiveOption(System.IntPtr CurrentOption)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<System.IntPtr>(0x0, CurrentOption);
            CallRaw("GetActiveOption", __pb.Bytes);
        }
        public void GetOptionIndex(System.IntPtr Option, int CurrentIndex)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<System.IntPtr>(0x0, Option);
            __pb.Set(0x10, CurrentIndex);
            CallRaw("GetOptionIndex", __pb.Bytes);
        }
        public void NewMenu(byte NewMenu, bool DontResetIndex)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set(0x0, NewMenu);
            __pb.Set<byte>(0x1, (byte)(DontResetIndex?1:0));
            CallRaw("NewMenu", __pb.Bytes);
        }
        public void ProcessNewSetting(System.IntPtr NewSetting)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewSetting);
            CallRaw("ProcessNewSetting", __pb.Bytes);
        }
        public void Initialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void StartScrollDown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartScrollDown", __pb.Bytes);
        }
        public void TriggerScrollDown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TriggerScrollDown", __pb.Bytes);
        }
        public void ContinueScrollDown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContinueScrollDown", __pb.Bytes);
        }
        public void StartScrollUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartScrollUp", __pb.Bytes);
        }
        public void ContinueScrollUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContinueScrollUp", __pb.Bytes);
        }
        public void TriggerScrollUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TriggerScrollUp", __pb.Bytes);
        }
        public void TimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TimerExpired", __pb.Bytes);
        }
        public void InputActionFavorite(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionFavorite", __pb.Bytes);
        }
        public void InputActionConfirm(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionConfirm", __pb.Bytes);
        }
        public void InputActionBack(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionBack", __pb.Bytes);
        }
        public void InputActionScrollDown(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionScrollDown", __pb.Bytes);
        }
        public void InputActionScrollUp(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionScrollUp", __pb.Bytes);
        }
        public void InputActionSetShortcutAX()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InputActionSetShortcutAX", __pb.Bytes);
        }
        public void InputActionSetShortcutBY()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InputActionSetShortcutBY", __pb.Bytes);
        }
        public void InputActionDoShortcut(bool AX)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(AX?1:0));
            CallRaw("InputActionDoShortcut", __pb.Bytes);
        }
        public void ExecuteUbergraph_DebugMenu(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_DebugMenu", __pb.Bytes);
        }
    }

}
