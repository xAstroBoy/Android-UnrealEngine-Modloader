// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/EngineSettings
using System;

namespace UEModLoader.Game
{
    public enum ESubLevelStripMode
    {
        ExactClass = 0,
        IsChildOf = 1,
    }

    public enum EFourPlayerSplitScreenType
    {
        Grid = 0,
        Vertical = 1,
        Horizontal = 2,
    }

    public enum EThreePlayerSplitScreenType
    {
        FavorTop = 0,
        FavorBottom = 1,
        Vertical = 2,
        Horizontal = 3,
    }

    public enum ETwoPlayerSplitScreenType
    {
        Horizontal = 0,
        Vertical = 1,
    }

    public class AutoCompleteCommand : StructProxy
    {
        public AutoCompleteCommand(System.IntPtr ptr) : base(ptr) {}
        public string Command => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string Desc => Native.ReadFStringAt(AddrOf(0x10)); // FString
    }

    public class GameModeName : StructProxy
    {
        public GameModeName(System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public SoftClassPath GameMode => new SoftClassPath(AddrOf(0x10));
    }

    public class ConsoleSettings : Object
    {
        public const string UeClassName = "ConsoleSettings";
        public ConsoleSettings(System.IntPtr ptr) : base(ptr) {}
        public static new ConsoleSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ConsoleSettings(p);
        public static ConsoleSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ConsoleSettings(o.Pointer); }
        public static ConsoleSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ConsoleSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ConsoleSettings(a[i].Pointer); return r; }
        public int MaxScrollbackSize { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public TArray<System.IntPtr> ManualAutoCompleteList => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public TArray<System.IntPtr> AutoCompleteMapPaths => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<FString>
        public float BackgroundOpacityPercentage { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
        public bool bOrderTopToBottom { get => Native.GetPropBool(Pointer, "bOrderTopToBottom"); set => Native.SetPropBool(Pointer, "bOrderTopToBottom", value); }
        public bool bDisplayHelpInAutoComplete { get => Native.GetPropBool(Pointer, "bDisplayHelpInAutoComplete"); set => Native.SetPropBool(Pointer, "bDisplayHelpInAutoComplete", value); }
        public Color InputColor => new Color(AddrOf(0x58));
        public Color HistoryColor => new Color(AddrOf(0x5C));
        public Color AutoCompleteCommandColor => new Color(AddrOf(0x60));
        public Color AutoCompleteCVarColor => new Color(AddrOf(0x64));
        public Color AutoCompleteFadedColor => new Color(AddrOf(0x68));
    }

    public class GameMapsSettings : Object
    {
        public const string UeClassName = "GameMapsSettings";
        public GameMapsSettings(System.IntPtr ptr) : base(ptr) {}
        public static new GameMapsSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GameMapsSettings(p);
        public static GameMapsSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GameMapsSettings(o.Pointer); }
        public static GameMapsSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GameMapsSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GameMapsSettings(a[i].Pointer); return r; }
        public string LocalMapOptions => Native.GetPropString(Pointer, "LocalMapOptions"); // FString
        public SoftObjectPath TransitionMap => new SoftObjectPath(AddrOf(0x38));
        public bool bUseSplitscreen { get => Native.GetPropBool(Pointer, "bUseSplitscreen"); set => Native.SetPropBool(Pointer, "bUseSplitscreen", value); }
        public byte TwoPlayerSplitscreenLayout { get => GetAt<byte>(0x51); set => SetAt(0x51, value); }
        public byte ThreePlayerSplitscreenLayout { get => GetAt<byte>(0x52); set => SetAt(0x52, value); }
        public EFourPlayerSplitScreenType FourPlayerSplitscreenLayout { get => (EFourPlayerSplitScreenType)GetAt<byte>(0x53); set => SetAt(0x53, (byte)value); }
        public bool bOffsetPlayerGamepadIds { get => Native.GetPropBool(Pointer, "bOffsetPlayerGamepadIds"); set => Native.SetPropBool(Pointer, "bOffsetPlayerGamepadIds", value); }
        public SoftClassPath GameInstanceClass => new SoftClassPath(AddrOf(0x58));
        public SoftObjectPath GameDefaultMap => new SoftObjectPath(AddrOf(0x70));
        public SoftObjectPath ServerDefaultMap => new SoftObjectPath(AddrOf(0x88));
        public SoftClassPath GlobalDefaultGameMode => new SoftClassPath(AddrOf(0xA0));
        public SoftClassPath GlobalDefaultServerGameMode => new SoftClassPath(AddrOf(0xB8));
        public TArray<System.IntPtr> GameModeMapPrefixes => new TArray<System.IntPtr>(AddrOf(0xD0)); // TArray<struct>
        public TArray<System.IntPtr> GameModeClassAliases => new TArray<System.IntPtr>(AddrOf(0xE0)); // TArray<struct>
        /// <summary>[Native] thunk RVA 0x70358F0 — hookable via Hooks.InstallAt(NativeFunc_SetSkipAssigningGamepadToPlayer1).</summary>
        public static System.IntPtr NativeFunc_SetSkipAssigningGamepadToPlayer1 => Memory.ModuleBase() + 0x70358F0;
        public void SetSkipAssigningGamepadToPlayer1(bool bSkipFirstPlayer)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bSkipFirstPlayer?1:0));
            CallRaw("SetSkipAssigningGamepadToPlayer1", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x70358B8 — hookable via Hooks.InstallAt(NativeFunc_GetSkipAssigningGamepadToPlayer1).</summary>
        public static System.IntPtr NativeFunc_GetSkipAssigningGamepadToPlayer1 => Memory.ModuleBase() + 0x70358B8;
        public bool GetSkipAssigningGamepadToPlayer1()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetSkipAssigningGamepadToPlayer1", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x703599C — hookable via Hooks.InstallAt(NativeFunc_GetGameMapsSettings).</summary>
        public static System.IntPtr NativeFunc_GetGameMapsSettings => Memory.ModuleBase() + 0x703599C;
        public GameMapsSettings GetGameMapsSettings()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetGameMapsSettings", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new GameMapsSettings(__p); }
        }
    }

    public class GameNetworkManagerSettings : Object
    {
        public const string UeClassName = "GameNetworkManagerSettings";
        public GameNetworkManagerSettings(System.IntPtr ptr) : base(ptr) {}
        public static new GameNetworkManagerSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GameNetworkManagerSettings(p);
        public static GameNetworkManagerSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GameNetworkManagerSettings(o.Pointer); }
        public static GameNetworkManagerSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GameNetworkManagerSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GameNetworkManagerSettings(a[i].Pointer); return r; }
        public int MinDynamicBandwidth { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public int MaxDynamicBandwidth { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public int TotalNetBandwidth { get => GetAt<int>(0x30); set => SetAt(0x30, value); }
        public int BadPingThreshold { get => GetAt<int>(0x34); set => SetAt(0x34, value); }
        public bool bIsStandbyCheckingEnabled { get => Native.GetPropBool(Pointer, "bIsStandbyCheckingEnabled"); set => Native.SetPropBool(Pointer, "bIsStandbyCheckingEnabled", value); }
        public float StandbyRxCheatTime { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public float StandbyTxCheatTime { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public float PercentMissingForRxStandby { get => GetAt<float>(0x44); set => SetAt(0x44, value); }
        public float PercentMissingForTxStandby { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public float PercentForBadPing { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public float JoinInProgressStandbyWaitTime { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
    }

    public class GameSessionSettings : Object
    {
        public const string UeClassName = "GameSessionSettings";
        public GameSessionSettings(System.IntPtr ptr) : base(ptr) {}
        public static new GameSessionSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GameSessionSettings(p);
        public static GameSessionSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GameSessionSettings(o.Pointer); }
        public static GameSessionSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GameSessionSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GameSessionSettings(a[i].Pointer); return r; }
        public int MaxSpectators { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public int MaxPlayers { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public bool bRequiresPushToTalk { get => Native.GetPropBool(Pointer, "bRequiresPushToTalk"); set => Native.SetPropBool(Pointer, "bRequiresPushToTalk", value); }
    }

    public class GeneralEngineSettings : Object
    {
        public const string UeClassName = "GeneralEngineSettings";
        public GeneralEngineSettings(System.IntPtr ptr) : base(ptr) {}
        public static new GeneralEngineSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeneralEngineSettings(p);
        public static GeneralEngineSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeneralEngineSettings(o.Pointer); }
        public static GeneralEngineSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeneralEngineSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeneralEngineSettings(a[i].Pointer); return r; }
    }

    public class GeneralProjectSettings : Object
    {
        public const string UeClassName = "GeneralProjectSettings";
        public GeneralProjectSettings(System.IntPtr ptr) : base(ptr) {}
        public static new GeneralProjectSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GeneralProjectSettings(p);
        public static GeneralProjectSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GeneralProjectSettings(o.Pointer); }
        public static GeneralProjectSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GeneralProjectSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GeneralProjectSettings(a[i].Pointer); return r; }
        public string CompanyName => Native.GetPropString(Pointer, "CompanyName"); // FString
        public string CompanyDistinguishedName => Native.GetPropString(Pointer, "CompanyDistinguishedName"); // FString
        public string CopyrightNotice => Native.GetPropString(Pointer, "CopyrightNotice"); // FString
        public string Description => Native.GetPropString(Pointer, "Description"); // FString
        public string Homepage => Native.GetPropString(Pointer, "Homepage"); // FString
        public string LicensingTerms => Native.GetPropString(Pointer, "LicensingTerms"); // FString
        public string PrivacyPolicy => Native.GetPropString(Pointer, "PrivacyPolicy"); // FString
        public Guid ProjectID => new Guid(AddrOf(0x98));
        public string ProjectName => Native.GetPropString(Pointer, "ProjectName"); // FString
        public string ProjectVersion => Native.GetPropString(Pointer, "ProjectVersion"); // FString
        public string SupportContact => Native.GetPropString(Pointer, "SupportContact"); // FString
        public System.IntPtr ProjectDisplayedTitle => AddrOf(0xD8); // 
        public System.IntPtr ProjectDebugTitleInfo => AddrOf(0xF0); // 
        public bool bShouldWindowPreserveAspectRatio { get => Native.GetPropBool(Pointer, "bShouldWindowPreserveAspectRatio"); set => Native.SetPropBool(Pointer, "bShouldWindowPreserveAspectRatio", value); }
        public bool bUseBorderlessWindow { get => Native.GetPropBool(Pointer, "bUseBorderlessWindow"); set => Native.SetPropBool(Pointer, "bUseBorderlessWindow", value); }
        public bool bStartInVR { get => Native.GetPropBool(Pointer, "bStartInVR"); set => Native.SetPropBool(Pointer, "bStartInVR", value); }
        public bool bStartInAR { get => Native.GetPropBool(Pointer, "bStartInAR"); set => Native.SetPropBool(Pointer, "bStartInAR", value); }
        public bool bSupportAR { get => Native.GetPropBool(Pointer, "bSupportAR"); set => Native.SetPropBool(Pointer, "bSupportAR", value); }
        public bool bAllowWindowResize { get => Native.GetPropBool(Pointer, "bAllowWindowResize"); set => Native.SetPropBool(Pointer, "bAllowWindowResize", value); }
        public bool bAllowClose { get => Native.GetPropBool(Pointer, "bAllowClose"); set => Native.SetPropBool(Pointer, "bAllowClose", value); }
        public bool bAllowMaximize { get => Native.GetPropBool(Pointer, "bAllowMaximize"); set => Native.SetPropBool(Pointer, "bAllowMaximize", value); }
        public bool bAllowMinimize { get => Native.GetPropBool(Pointer, "bAllowMinimize"); set => Native.SetPropBool(Pointer, "bAllowMinimize", value); }
    }

    public class HudSettings : Object
    {
        public const string UeClassName = "HudSettings";
        public HudSettings(System.IntPtr ptr) : base(ptr) {}
        public static new HudSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new HudSettings(p);
        public static HudSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new HudSettings(o.Pointer); }
        public static HudSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new HudSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new HudSettings(a[i].Pointer); return r; }
        public bool bShowHUD { get => Native.GetPropBool(Pointer, "bShowHUD"); set => Native.SetPropBool(Pointer, "bShowHUD", value); }
        public TArray<System.IntPtr> DebugDisplay => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<FName>
    }

}
