// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AndroidRuntimeSettings
using System;

namespace UEModLoader.Game
{
    public enum EAndroidGraphicsDebugger
    {
        None = 0,
        Mali = 1,
        Adreno = 2,
    }

    public enum EGoogleVRCaps
    {
        Cardboard = 0,
        Daydream33 = 1,
        Daydream63 = 2,
        Daydream66 = 3,
    }

    public enum EGoogleVRMode
    {
        Cardboard = 0,
        Daydream = 1,
        DaydreamAndCardboard = 2,
    }

    public enum EAndroidAudio
    {
        Default = 0,
        OGG = 1,
        ADPCM = 2,
    }

    public enum EOculusMobileDevice
    {
        Quest = 1,
    }

    public enum EAndroidInstallLocation
    {
        InternalOnly = 0,
        PreferExternal = 1,
        Auto = 2,
    }

    public enum EAndroidDepthBufferPreference
    {
        Default = 0,
        Bits16 = 16,
        Bits24 = 24,
        Bits32 = 32,
    }

    public enum EAndroidScreenOrientation
    {
        Portrait = 0,
        ReversePortrait = 1,
        SensorPortrait = 2,
        Landscape = 3,
        ReverseLandscape = 4,
        SensorLandscape = 5,
        Sensor = 6,
        FullSensor = 7,
    }

    public class GooglePlayLeaderboardMapping : StructProxy
    {
        public GooglePlayLeaderboardMapping(System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string LeaderboardID => Native.ReadFStringAt(AddrOf(0x10)); // FString
    }

    public class GooglePlayAchievementMapping : StructProxy
    {
        public GooglePlayAchievementMapping(System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string AchievementId => Native.ReadFStringAt(AddrOf(0x10)); // FString
    }

    public class AndroidRuntimeSettings : Object
    {
        public const string UeClassName = "AndroidRuntimeSettings";
        public AndroidRuntimeSettings(System.IntPtr ptr) : base(ptr) {}
        public static new AndroidRuntimeSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AndroidRuntimeSettings(p);
        public static AndroidRuntimeSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AndroidRuntimeSettings(o.Pointer); }
        public static AndroidRuntimeSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AndroidRuntimeSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AndroidRuntimeSettings(a[i].Pointer); return r; }
        public string PackageName => Native.GetPropString(Pointer, "PackageName"); // FString
        public int StoreVersion { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
        public int StoreVersionOffsetArmV7 { get => GetAt<int>(0x3C); set => SetAt(0x3C, value); }
        public int StoreVersionOffsetArm64 { get => GetAt<int>(0x40); set => SetAt(0x40, value); }
        public int StoreVersionOffsetX8664 { get => GetAt<int>(0x44); set => SetAt(0x44, value); }
        public string ApplicationDisplayName => Native.GetPropString(Pointer, "ApplicationDisplayName"); // FString
        public string VersionDisplayName => Native.GetPropString(Pointer, "VersionDisplayName"); // FString
        public int MinSDKVersion { get => GetAt<int>(0x68); set => SetAt(0x68, value); }
        public int TargetSDKVersion { get => GetAt<int>(0x6C); set => SetAt(0x6C, value); }
        public byte InstallLocation { get => GetAt<byte>(0x70); set => SetAt(0x70, value); }
        public bool bEnableGradle { get => Native.GetPropBool(Pointer, "bEnableGradle"); set => Native.SetPropBool(Pointer, "bEnableGradle", value); }
        public bool bEnableLint { get => Native.GetPropBool(Pointer, "bEnableLint"); set => Native.SetPropBool(Pointer, "bEnableLint", value); }
        public bool bPackageDataInsideApk { get => Native.GetPropBool(Pointer, "bPackageDataInsideApk"); set => Native.SetPropBool(Pointer, "bPackageDataInsideApk", value); }
        public bool bCreateAllPlatformsInstall { get => Native.GetPropBool(Pointer, "bCreateAllPlatformsInstall"); set => Native.SetPropBool(Pointer, "bCreateAllPlatformsInstall", value); }
        public bool bDisableVerifyOBBOnStartUp { get => Native.GetPropBool(Pointer, "bDisableVerifyOBBOnStartUp"); set => Native.SetPropBool(Pointer, "bDisableVerifyOBBOnStartUp", value); }
        public bool bForceSmallOBBFiles { get => Native.GetPropBool(Pointer, "bForceSmallOBBFiles"); set => Native.SetPropBool(Pointer, "bForceSmallOBBFiles", value); }
        public bool bAllowLargeOBBFiles { get => Native.GetPropBool(Pointer, "bAllowLargeOBBFiles"); set => Native.SetPropBool(Pointer, "bAllowLargeOBBFiles", value); }
        public bool bAllowPatchOBBFile { get => Native.GetPropBool(Pointer, "bAllowPatchOBBFile"); set => Native.SetPropBool(Pointer, "bAllowPatchOBBFile", value); }
        public bool bUseExternalFilesDir { get => Native.GetPropBool(Pointer, "bUseExternalFilesDir"); set => Native.SetPropBool(Pointer, "bUseExternalFilesDir", value); }
        public bool bPublicLogFiles { get => Native.GetPropBool(Pointer, "bPublicLogFiles"); set => Native.SetPropBool(Pointer, "bPublicLogFiles", value); }
        public byte Orientation { get => GetAt<byte>(0x7B); set => SetAt(0x7B, value); }
        public float MaxAspectRatio { get => GetAt<float>(0x7C); set => SetAt(0x7C, value); }
        public bool bUseDisplayCutout { get => Native.GetPropBool(Pointer, "bUseDisplayCutout"); set => Native.SetPropBool(Pointer, "bUseDisplayCutout", value); }
        public bool bRestoreNotificationsOnReboot { get => Native.GetPropBool(Pointer, "bRestoreNotificationsOnReboot"); set => Native.SetPropBool(Pointer, "bRestoreNotificationsOnReboot", value); }
        public bool bFullScreen { get => Native.GetPropBool(Pointer, "bFullScreen"); set => Native.SetPropBool(Pointer, "bFullScreen", value); }
        public bool bEnableNewKeyboard { get => Native.GetPropBool(Pointer, "bEnableNewKeyboard"); set => Native.SetPropBool(Pointer, "bEnableNewKeyboard", value); }
        public byte DepthBufferPreference { get => GetAt<byte>(0x84); set => SetAt(0x84, value); }
        public bool bValidateTextureFormats { get => Native.GetPropBool(Pointer, "bValidateTextureFormats"); set => Native.SetPropBool(Pointer, "bValidateTextureFormats", value); }
        public bool bEnableBundle { get => Native.GetPropBool(Pointer, "bEnableBundle"); set => Native.SetPropBool(Pointer, "bEnableBundle", value); }
        public bool bEnableUniversalAPK { get => Native.GetPropBool(Pointer, "bEnableUniversalAPK"); set => Native.SetPropBool(Pointer, "bEnableUniversalAPK", value); }
        public bool bBundleABISplit { get => Native.GetPropBool(Pointer, "bBundleABISplit"); set => Native.SetPropBool(Pointer, "bBundleABISplit", value); }
        public bool bBundleLanguageSplit { get => Native.GetPropBool(Pointer, "bBundleLanguageSplit"); set => Native.SetPropBool(Pointer, "bBundleLanguageSplit", value); }
        public bool bBundleDensitySplit { get => Native.GetPropBool(Pointer, "bBundleDensitySplit"); set => Native.SetPropBool(Pointer, "bBundleDensitySplit", value); }
        public TArray<System.IntPtr> ExtraManifestNodeTags => new TArray<System.IntPtr>(AddrOf(0x90)); // TArray<FString>
        public TArray<System.IntPtr> ExtraApplicationNodeTags => new TArray<System.IntPtr>(AddrOf(0xA0)); // TArray<FString>
        public string ExtraApplicationSettings => Native.GetPropString(Pointer, "ExtraApplicationSettings"); // FString
        public TArray<System.IntPtr> ExtraActivityNodeTags => new TArray<System.IntPtr>(AddrOf(0xC0)); // TArray<FString>
        public string ExtraActivitySettings => Native.GetPropString(Pointer, "ExtraActivitySettings"); // FString
        public TArray<System.IntPtr> ExtraPermissions => new TArray<System.IntPtr>(AddrOf(0xE0)); // TArray<FString>
        public bool bAndroidVoiceEnabled { get => Native.GetPropBool(Pointer, "bAndroidVoiceEnabled"); set => Native.SetPropBool(Pointer, "bAndroidVoiceEnabled", value); }
        public TArray<System.IntPtr> PackageForOculusMobile => new TArray<System.IntPtr>(AddrOf(0xF8)); // TArray<uint8>
        public bool bRemoveOSIG { get => Native.GetPropBool(Pointer, "bRemoveOSIG"); set => Native.SetPropBool(Pointer, "bRemoveOSIG", value); }
        public TArray<System.IntPtr> GoogleVRCaps => new TArray<System.IntPtr>(AddrOf(0x110)); // TArray<uint8>
        public bool bGoogleVRSustainedPerformance { get => Native.GetPropBool(Pointer, "bGoogleVRSustainedPerformance"); set => Native.SetPropBool(Pointer, "bGoogleVRSustainedPerformance", value); }
        public string KeyStore => Native.GetPropString(Pointer, "KeyStore"); // FString
        public string KeyAlias => Native.GetPropString(Pointer, "KeyAlias"); // FString
        public string KeyStorePassword => Native.GetPropString(Pointer, "KeyStorePassword"); // FString
        public string KeyPassword => Native.GetPropString(Pointer, "KeyPassword"); // FString
        public bool bBuildForArmV7 { get => Native.GetPropBool(Pointer, "bBuildForArmV7"); set => Native.SetPropBool(Pointer, "bBuildForArmV7", value); }
        public bool bBuildForArm64 { get => Native.GetPropBool(Pointer, "bBuildForArm64"); set => Native.SetPropBool(Pointer, "bBuildForArm64", value); }
        public bool bBuildForX8664 { get => Native.GetPropBool(Pointer, "bBuildForX8664"); set => Native.SetPropBool(Pointer, "bBuildForX8664", value); }
        public bool bBuildForES31 { get => Native.GetPropBool(Pointer, "bBuildForES31"); set => Native.SetPropBool(Pointer, "bBuildForES31", value); }
        public bool bSupportsVulkan { get => Native.GetPropBool(Pointer, "bSupportsVulkan"); set => Native.SetPropBool(Pointer, "bSupportsVulkan", value); }
        public bool bSupportsVulkanSM5 { get => Native.GetPropBool(Pointer, "bSupportsVulkanSM5"); set => Native.SetPropBool(Pointer, "bSupportsVulkanSM5", value); }
        public bool bDetectVulkanByDefault { get => Native.GetPropBool(Pointer, "bDetectVulkanByDefault"); set => Native.SetPropBool(Pointer, "bDetectVulkanByDefault", value); }
        public bool bBuildWithHiddenSymbolVisibility { get => Native.GetPropBool(Pointer, "bBuildWithHiddenSymbolVisibility"); set => Native.SetPropBool(Pointer, "bBuildWithHiddenSymbolVisibility", value); }
        public bool bSaveSymbols { get => Native.GetPropBool(Pointer, "bSaveSymbols"); set => Native.SetPropBool(Pointer, "bSaveSymbols", value); }
        public bool bForceLDLinker { get => Native.GetPropBool(Pointer, "bForceLDLinker"); set => Native.SetPropBool(Pointer, "bForceLDLinker", value); }
        public bool bEnableGooglePlaySupport { get => Native.GetPropBool(Pointer, "bEnableGooglePlaySupport"); set => Native.SetPropBool(Pointer, "bEnableGooglePlaySupport", value); }
        public bool bUseGetAccounts { get => Native.GetPropBool(Pointer, "bUseGetAccounts"); set => Native.SetPropBool(Pointer, "bUseGetAccounts", value); }
        public string GamesAppID => Native.GetPropString(Pointer, "GamesAppID"); // FString
        public TArray<System.IntPtr> AchievementMap => new TArray<System.IntPtr>(AddrOf(0x188)); // TArray<struct>
        public TArray<System.IntPtr> LeaderboardMap => new TArray<System.IntPtr>(AddrOf(0x198)); // TArray<struct>
        public bool bEnableSnapshots { get => Native.GetPropBool(Pointer, "bEnableSnapshots"); set => Native.SetPropBool(Pointer, "bEnableSnapshots", value); }
        public bool bSupportAdMob { get => Native.GetPropBool(Pointer, "bSupportAdMob"); set => Native.SetPropBool(Pointer, "bSupportAdMob", value); }
        public string AdMobAdUnitID => Native.GetPropString(Pointer, "AdMobAdUnitID"); // FString
        public TArray<System.IntPtr> AdMobAdUnitIDs => new TArray<System.IntPtr>(AddrOf(0x1C0)); // TArray<FString>
        public string GooglePlayLicenseKey => Native.GetPropString(Pointer, "GooglePlayLicenseKey"); // FString
        public string GCMClientSenderID => Native.GetPropString(Pointer, "GCMClientSenderID"); // FString
        public bool bShowLaunchImage { get => Native.GetPropBool(Pointer, "bShowLaunchImage"); set => Native.SetPropBool(Pointer, "bShowLaunchImage", value); }
        public bool bAllowIMU { get => Native.GetPropBool(Pointer, "bAllowIMU"); set => Native.SetPropBool(Pointer, "bAllowIMU", value); }
        public bool bAllowControllers { get => Native.GetPropBool(Pointer, "bAllowControllers"); set => Native.SetPropBool(Pointer, "bAllowControllers", value); }
        public bool bBlockAndroidKeysOnControllers { get => Native.GetPropBool(Pointer, "bBlockAndroidKeysOnControllers"); set => Native.SetPropBool(Pointer, "bBlockAndroidKeysOnControllers", value); }
        public bool bControllersBlockDeviceFeedback { get => Native.GetPropBool(Pointer, "bControllersBlockDeviceFeedback"); set => Native.SetPropBool(Pointer, "bControllersBlockDeviceFeedback", value); }
        public byte AndroidAudio { get => GetAt<byte>(0x1F5); set => SetAt(0x1F5, value); }
        public int AudioSampleRate { get => GetAt<int>(0x1F8); set => SetAt(0x1F8, value); }
        public int AudioCallbackBufferFrameSize { get => GetAt<int>(0x1FC); set => SetAt(0x1FC, value); }
        public int AudioNumBuffersToEnqueue { get => GetAt<int>(0x200); set => SetAt(0x200, value); }
        public int AudioMaxChannels { get => GetAt<int>(0x204); set => SetAt(0x204, value); }
        public int AudioNumSourceWorkers { get => GetAt<int>(0x208); set => SetAt(0x208, value); }
        public string SpatializationPlugin => Native.GetPropString(Pointer, "SpatializationPlugin"); // FString
        public string ReverbPlugin => Native.GetPropString(Pointer, "ReverbPlugin"); // FString
        public string OcclusionPlugin => Native.GetPropString(Pointer, "OcclusionPlugin"); // FString
        public PlatformRuntimeAudioCompressionOverrides CompressionOverrides => new PlatformRuntimeAudioCompressionOverrides(AddrOf(0x240));
        public bool bUseAudioStreamCaching { get => Native.GetPropBool(Pointer, "bUseAudioStreamCaching"); set => Native.SetPropBool(Pointer, "bUseAudioStreamCaching", value); }
        public int CacheSizeKB { get => GetAt<int>(0x254); set => SetAt(0x254, value); }
        public bool bResampleForDevice { get => Native.GetPropBool(Pointer, "bResampleForDevice"); set => Native.SetPropBool(Pointer, "bResampleForDevice", value); }
        public int SoundCueCookQualityIndex { get => GetAt<int>(0x25C); set => SetAt(0x25C, value); }
        public float MaxSampleRate { get => GetAt<float>(0x260); set => SetAt(0x260, value); }
        public float HighSampleRate { get => GetAt<float>(0x264); set => SetAt(0x264, value); }
        public float MedSampleRate { get => GetAt<float>(0x268); set => SetAt(0x268, value); }
        public float LowSampleRate { get => GetAt<float>(0x26C); set => SetAt(0x26C, value); }
        public float MinSampleRate { get => GetAt<float>(0x270); set => SetAt(0x270, value); }
        public float CompressionQualityModifier { get => GetAt<float>(0x274); set => SetAt(0x274, value); }
        public float AutoStreamingThreshold { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public byte AndroidGraphicsDebugger { get => GetAt<byte>(0x27C); set => SetAt(0x27C, value); }
        public DirectoryPath MaliGraphicsDebuggerPath => new DirectoryPath(AddrOf(0x280));
        public bool bMultiTargetFormat_ETC2 { get => Native.GetPropBool(Pointer, "bMultiTargetFormat_ETC2"); set => Native.SetPropBool(Pointer, "bMultiTargetFormat_ETC2", value); }
        public bool bMultiTargetFormat_DXT { get => Native.GetPropBool(Pointer, "bMultiTargetFormat_DXT"); set => Native.SetPropBool(Pointer, "bMultiTargetFormat_DXT", value); }
        public bool bMultiTargetFormat_ASTC { get => Native.GetPropBool(Pointer, "bMultiTargetFormat_ASTC"); set => Native.SetPropBool(Pointer, "bMultiTargetFormat_ASTC", value); }
        public float TextureFormatPriority_ETC2 { get => GetAt<float>(0x294); set => SetAt(0x294, value); }
        public float TextureFormatPriority_DXT { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public float TextureFormatPriority_ASTC { get => GetAt<float>(0x29C); set => SetAt(0x29C, value); }
        public string SDKAPILevelOverride => Native.GetPropString(Pointer, "SDKAPILevelOverride"); // FString
        public string NDKAPILevelOverride => Native.GetPropString(Pointer, "NDKAPILevelOverride"); // FString
    }

}
