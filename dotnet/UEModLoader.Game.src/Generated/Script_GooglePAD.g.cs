// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/GooglePAD
using System;

namespace UEModLoader.Game
{
    public enum EGooglePADCellularDataConfirmStatus
    {
        AssetPack_CONFIRM_UNKNOWN = 0,
        AssetPack_CONFIRM_PENDING = 1,
        AssetPack_CONFIRM_USER_APPROVED = 2,
        AssetPack_CONFIRM_USER_CANCELED = 3,
    }

    public enum EGooglePADStorageMethod
    {
        AssetPack_STORAGE_FILES = 0,
        AssetPack_STORAGE_APK = 1,
        AssetPack_STORAGE_UNKNOWN = 2,
        AssetPack_STORAGE_NOT_INSTALLED = 3,
    }

    public enum EGooglePADDownloadStatus
    {
        AssetPack_UNKNOWN = 0,
        AssetPack_DOWNLOAD_PENDING = 1,
        AssetPack_DOWNLOADING = 2,
        AssetPack_TRANSFERRING = 3,
        AssetPack_DOWNLOAD_COMPLETED = 4,
        AssetPack_DOWNLOAD_FAILED = 5,
        AssetPack_DOWNLOAD_CANCELED = 6,
        AssetPack_WAITING_FOR_WIFI = 7,
        AssetPack_NOT_INSTALLED = 8,
        AssetPack_INFO_PENDING = 9,
        AssetPack_INFO_FAILED = 10,
        AssetPack_REMOVAL_PENDING = 11,
        AssetPack_REMOVAL_FAILED = 12,
    }

    public enum EGooglePADErrorCode
    {
        AssetPack_NO_ERROR = 0,
        AssetPack_APP_UNAVAILABLE = 1,
        AssetPack_UNAVAILABLE = 2,
        AssetPack_INVALID_REQUEST = 3,
        AssetPack_DOWNLOAD_NOT_FOUND = 4,
        AssetPack_API_NOT_AVAILABLE = 5,
        AssetPack_NETWORK_ERROR = 6,
        AssetPack_ACCESS_DENIED = 7,
        AssetPack_INSUFFICIENT_STORAGE = 8,
        AssetPack_PLAY_STORE_NOT_FOUND = 9,
        AssetPack_NETWORK_UNRESTRICTED = 10,
        AssetPack_INTERNAL_ERROR = 11,
        AssetPack_INITIALIZATION_NEEDED = 12,
        AssetPack_INITIALIZATION_FAILED = 13,
    }

    public class GooglePADFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "GooglePADFunctionLibrary";
        public GooglePADFunctionLibrary(global::System.IntPtr ptr) : base(ptr) {}
        public static new GooglePADFunctionLibrary FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GooglePADFunctionLibrary(p);
        public static GooglePADFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GooglePADFunctionLibrary(o.Pointer); }
        public static GooglePADFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GooglePADFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GooglePADFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5C2DCA0 — hookable via Hooks.InstallAt(NativeFunc_ShowCellularDataConfirmation).</summary>
        public static global::System.IntPtr NativeFunc_ShowCellularDataConfirmation => Memory.ModuleBase() + 0x5C2DCA0;
        public EGooglePADErrorCode ShowCellularDataConfirmation()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("ShowCellularDataConfirmation", __pb.Bytes);
            return (EGooglePADErrorCode)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5C2DCD4 — hookable via Hooks.InstallAt(NativeFunc_RequestRemoval).</summary>
        public static global::System.IntPtr NativeFunc_RequestRemoval => Memory.ModuleBase() + 0x5C2DCD4;
        public EGooglePADErrorCode RequestRemoval(global::System.IntPtr Name)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, Name);
            CallRaw("RequestRemoval", __pb.Bytes);
            return (EGooglePADErrorCode)__pb.Get<byte>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5C2E46C — hookable via Hooks.InstallAt(NativeFunc_RequestInfo).</summary>
        public static global::System.IntPtr NativeFunc_RequestInfo => Memory.ModuleBase() + 0x5C2E46C;
        public EGooglePADErrorCode RequestInfo(global::System.IntPtr AssetPacks)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, AssetPacks);
            CallRaw("RequestInfo", __pb.Bytes);
            return (EGooglePADErrorCode)__pb.Get<byte>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5C2E2BC — hookable via Hooks.InstallAt(NativeFunc_RequestDownload).</summary>
        public static global::System.IntPtr NativeFunc_RequestDownload => Memory.ModuleBase() + 0x5C2E2BC;
        public EGooglePADErrorCode RequestDownload(global::System.IntPtr AssetPacks)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, AssetPacks);
            CallRaw("RequestDownload", __pb.Bytes);
            return (EGooglePADErrorCode)__pb.Get<byte>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5C2DF70 — hookable via Hooks.InstallAt(NativeFunc_ReleaseDownloadState).</summary>
        public static global::System.IntPtr NativeFunc_ReleaseDownloadState => Memory.ModuleBase() + 0x5C2DF70;
        public void ReleaseDownloadState(int State)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, State);
            CallRaw("ReleaseDownloadState", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C2DA50 — hookable via Hooks.InstallAt(NativeFunc_ReleaseAssetPackLocation).</summary>
        public static global::System.IntPtr NativeFunc_ReleaseAssetPackLocation => Memory.ModuleBase() + 0x5C2DA50;
        public void ReleaseAssetPackLocation(int Location)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Location);
            CallRaw("ReleaseAssetPackLocation", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5C2DD84 — hookable via Hooks.InstallAt(NativeFunc_GetTotalBytesToDownload).</summary>
        public static global::System.IntPtr NativeFunc_GetTotalBytesToDownload => Memory.ModuleBase() + 0x5C2DD84;
        public int GetTotalBytesToDownload(int State)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, State);
            CallRaw("GetTotalBytesToDownload", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5C2D9AC — hookable via Hooks.InstallAt(NativeFunc_GetStorageMethod).</summary>
        public static global::System.IntPtr NativeFunc_GetStorageMethod => Memory.ModuleBase() + 0x5C2D9AC;
        public EGooglePADStorageMethod GetStorageMethod(int Location)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Location);
            CallRaw("GetStorageMethod", __pb.Bytes);
            return (EGooglePADStorageMethod)__pb.Get<byte>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5C2DBEC — hookable via Hooks.InstallAt(NativeFunc_GetShowCellularDataConfirmationStatus).</summary>
        public static global::System.IntPtr NativeFunc_GetShowCellularDataConfirmationStatus => Memory.ModuleBase() + 0x5C2DBEC;
        public EGooglePADErrorCode GetShowCellularDataConfirmationStatus(EGooglePADCellularDataConfirmStatus Status)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Status);
            CallRaw("GetShowCellularDataConfirmationStatus", __pb.Bytes);
            return (EGooglePADErrorCode)__pb.Get<byte>(0x1);
        }
        /// <summary>[Native] thunk RVA 0x5C2DECC — hookable via Hooks.InstallAt(NativeFunc_GetDownloadStatus).</summary>
        public static global::System.IntPtr NativeFunc_GetDownloadStatus => Memory.ModuleBase() + 0x5C2DECC;
        public EGooglePADDownloadStatus GetDownloadStatus(int State)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, State);
            CallRaw("GetDownloadStatus", __pb.Bytes);
            return (EGooglePADDownloadStatus)__pb.Get<byte>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5C2E004 — hookable via Hooks.InstallAt(NativeFunc_GetDownloadState).</summary>
        public static global::System.IntPtr NativeFunc_GetDownloadState => Memory.ModuleBase() + 0x5C2E004;
        public EGooglePADErrorCode GetDownloadState(global::System.IntPtr Name, int State)
        {
            var __pb = new ParamBuffer(21);
            __pb.Set<global::System.IntPtr>(0x0, Name);
            __pb.Set(0x10, State);
            CallRaw("GetDownloadState", __pb.Bytes);
            return (EGooglePADErrorCode)__pb.Get<byte>(0x14);
        }
        /// <summary>[Native] thunk RVA 0x5C2DE28 — hookable via Hooks.InstallAt(NativeFunc_GetBytesDownloaded).</summary>
        public static global::System.IntPtr NativeFunc_GetBytesDownloaded => Memory.ModuleBase() + 0x5C2DE28;
        public int GetBytesDownloaded(int State)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, State);
            CallRaw("GetBytesDownloaded", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5C2D8BC — hookable via Hooks.InstallAt(NativeFunc_GetAssetsPath).</summary>
        public static global::System.IntPtr NativeFunc_GetAssetsPath => Memory.ModuleBase() + 0x5C2D8BC;
        public global::System.IntPtr GetAssetsPath(int Location)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Location);
            CallRaw("GetAssetsPath", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5C2DAE4 — hookable via Hooks.InstallAt(NativeFunc_GetAssetPackLocation).</summary>
        public static global::System.IntPtr NativeFunc_GetAssetPackLocation => Memory.ModuleBase() + 0x5C2DAE4;
        public EGooglePADErrorCode GetAssetPackLocation(global::System.IntPtr Name, int Location)
        {
            var __pb = new ParamBuffer(21);
            __pb.Set<global::System.IntPtr>(0x0, Name);
            __pb.Set(0x10, Location);
            CallRaw("GetAssetPackLocation", __pb.Bytes);
            return (EGooglePADErrorCode)__pb.Get<byte>(0x14);
        }
        /// <summary>[Native] thunk RVA 0x5C2E10C — hookable via Hooks.InstallAt(NativeFunc_CancelDownload).</summary>
        public static global::System.IntPtr NativeFunc_CancelDownload => Memory.ModuleBase() + 0x5C2E10C;
        public EGooglePADErrorCode CancelDownload(global::System.IntPtr AssetPacks)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, AssetPacks);
            CallRaw("CancelDownload", __pb.Bytes);
            return (EGooglePADErrorCode)__pb.Get<byte>(0x10);
        }
    }

}
