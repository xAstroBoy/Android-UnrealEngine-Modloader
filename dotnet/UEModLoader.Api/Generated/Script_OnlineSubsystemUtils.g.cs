// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/OnlineSubsystemUtils
using System;

namespace UEModLoader.Game
{
    public enum EInAppPurchaseStatus
    {
        Invalid = 0,
        Failed = 1,
        Deferred = 2,
        Canceled = 3,
        Purchased = 4,
        Restored = 5,
    }

    public enum EOnlineProxyStoreOfferDiscountType
    {
        NotOnSale = 0,
        Percentage = 1,
        DiscountAmount = 2,
        PayAmount = 3,
    }

    public enum EBeaconConnectionState
    {
        Invalid = 0,
        Closed = 1,
        Pending = 2,
        Open = 3,
    }

    public enum EClientRequestType
    {
        NonePending = 0,
        ExistingSessionReservation = 1,
        ReservationUpdate = 2,
        EmptyServerReservation = 3,
        Reconnect = 4,
        Abandon = 5,
        ReservationRemoveMembers = 6,
    }

    public enum EPartyReservationResult
    {
        NoResult = 0,
        RequestPending = 1,
        GeneralError = 2,
        PartyLimitReached = 3,
        IncorrectPlayerCount = 4,
        RequestTimedOut = 5,
        ReservationDuplicate = 6,
        ReservationNotFound = 7,
        ReservationAccepted = 8,
        ReservationDenied = 9,
        ReservationDenied_CrossPlayRestriction = 10,
        ReservationDenied_Banned = 11,
        ReservationRequestCanceled = 12,
        ReservationInvalid = 13,
        BadSessionId = 14,
        ReservationDenied_ContainsExistingPlayers = 15,
    }

    public enum ESpectatorClientRequestType
    {
        NonePending = 0,
        ExistingSessionReservation = 1,
        ReservationUpdate = 2,
        EmptyServerReservation = 3,
        Reconnect = 4,
        Abandon = 5,
    }

    public enum ESpectatorReservationResult
    {
        NoResult = 0,
        RequestPending = 1,
        GeneralError = 2,
        SpectatorLimitReached = 3,
        IncorrectPlayerCount = 4,
        RequestTimedOut = 5,
        ReservationDuplicate = 6,
        ReservationNotFound = 7,
        ReservationAccepted = 8,
        ReservationDenied = 9,
        ReservationDenied_CrossPlayRestriction = 10,
        ReservationDenied_Banned = 11,
        ReservationRequestCanceled = 12,
        ReservationInvalid = 13,
        BadSessionId = 14,
        ReservationDenied_ContainsExistingPlayers = 15,
    }

    public class BlueprintSessionResult : StructProxy
    {
        public BlueprintSessionResult(System.IntPtr ptr) : base(ptr) {}
    }

    public class InAppPurchaseReceiptInfo2 : StructProxy
    {
        public InAppPurchaseReceiptInfo2(System.IntPtr ptr) : base(ptr) {}
        public string ItemName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string ItemId => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public string ValidationInfo => Native.ReadFStringAt(AddrOf(0x20)); // FString
    }

    public class OnlineProxyStoreOffer : StructProxy
    {
        public OnlineProxyStoreOffer(System.IntPtr ptr) : base(ptr) {}
        public string OfferId => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public System.IntPtr Title => AddrOf(0x10); // 
        public System.IntPtr Description => AddrOf(0x28); // 
        public System.IntPtr LongDescription => AddrOf(0x40); // 
        public System.IntPtr RegularPriceText => AddrOf(0x58); // 
        public int RegularPrice { get => GetAt<int>(0x70); set => SetAt(0x70, value); }
        public System.IntPtr PriceText => AddrOf(0x78); // 
        public int NumericPrice { get => GetAt<int>(0x90); set => SetAt(0x90, value); }
        public string CurrencyCode => Native.ReadFStringAt(AddrOf(0x98)); // FString
        public DateTime ReleaseDate => new DateTime(AddrOf(0xA8));
        public DateTime ExpirationDate => new DateTime(AddrOf(0xB0));
        public EOnlineProxyStoreOfferDiscountType DiscountType { get => (EOnlineProxyStoreOfferDiscountType)GetAt<byte>(0xB8); set => SetAt(0xB8, (byte)value); }
        public System.IntPtr DynamicFields => AddrOf(0xC0); // 
    }

    public class InAppPurchaseRestoreInfo2 : StructProxy
    {
        public InAppPurchaseRestoreInfo2(System.IntPtr ptr) : base(ptr) {}
        public string ItemName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string ItemId => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public string ValidationInfo => Native.ReadFStringAt(AddrOf(0x20)); // FString
    }

    public class InAppPurchaseReceiptInfo : StructProxy
    {
        public InAppPurchaseReceiptInfo(System.IntPtr ptr) : base(ptr) {}
        public string ItemName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string ItemId => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public string ValidationInfo => Native.ReadFStringAt(AddrOf(0x20)); // FString
    }

    public class InAppPurchaseProductInfo2 : StructProxy
    {
        public InAppPurchaseProductInfo2(System.IntPtr ptr) : base(ptr) {}
        public string Identifier => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string TransactionIdentifier => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public string DisplayName => Native.ReadFStringAt(AddrOf(0x20)); // FString
        public string DisplayDescription => Native.ReadFStringAt(AddrOf(0x30)); // FString
        public string DisplayPrice => Native.ReadFStringAt(AddrOf(0x40)); // FString
        public float RawPrice { get => GetAt<float>(0x50); set => SetAt(0x50, value); }
        public string CurrencyCode => Native.ReadFStringAt(AddrOf(0x58)); // FString
        public string CurrencySymbol => Native.ReadFStringAt(AddrOf(0x68)); // FString
        public string DecimalSeparator => Native.ReadFStringAt(AddrOf(0x78)); // FString
        public string GroupingSeparator => Native.ReadFStringAt(AddrOf(0x88)); // FString
        public string ReceiptData => Native.ReadFStringAt(AddrOf(0x98)); // FString
        public System.IntPtr DynamicFields => AddrOf(0xA8); // 
    }

    public class InAppPurchaseProductRequest2 : StructProxy
    {
        public InAppPurchaseProductRequest2(System.IntPtr ptr) : base(ptr) {}
        public string ProductIdentifier => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public bool bIsConsumable { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class PlayerReservation : StructProxy
    {
        public PlayerReservation(System.IntPtr ptr) : base(ptr) {}
        public UniqueNetIdRepl UniqueId => new UniqueNetIdRepl(AddrOf(0x0));
        public string ValidationStr => Native.ReadFStringAt(AddrOf(0x28)); // FString
        public string Platform => Native.ReadFStringAt(AddrOf(0x38)); // FString
        public bool bAllowCrossplay { get => (GetAt<byte>(0x48) & 0xFF) != 0; set { var __b = GetAt<byte>(0x48); SetAt(0x48, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float ElapsedTime { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
    }

    public class PIELoginSettingsInternal : StructProxy
    {
        public PIELoginSettingsInternal(System.IntPtr ptr) : base(ptr) {}
        public string ID => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string Token => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public string Type => Native.ReadFStringAt(AddrOf(0x20)); // FString
        public TArray<System.IntPtr> TokenBytes => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<uint8>
    }

    public class PartyReservation : StructProxy
    {
        public PartyReservation(System.IntPtr ptr) : base(ptr) {}
        public int TeamNum { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public UniqueNetIdRepl PartyLeader => new UniqueNetIdRepl(AddrOf(0x8));
        public TArray<System.IntPtr> PartyMembers => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public TArray<System.IntPtr> RemovedPartyMembers => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<struct>
    }

    public class SpectatorReservation : StructProxy
    {
        public SpectatorReservation(System.IntPtr ptr) : base(ptr) {}
        public UniqueNetIdRepl SpectatorId => new UniqueNetIdRepl(AddrOf(0x0));
        public PlayerReservation Spectator => new PlayerReservation(AddrOf(0x28));
    }

    public class IpConnection : NetConnection
    {
        public const string UeClassName = "IpConnection";
        public IpConnection(System.IntPtr ptr) : base(ptr) {}
        public static new IpConnection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new IpConnection(p);
        public static IpConnection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new IpConnection(o.Pointer); }
        public static IpConnection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new IpConnection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new IpConnection(a[i].Pointer); return r; }
        public float SocketErrorDisconnectDelay { get => GetAt<float>(0x1A80); set => SetAt(0x1A80, value); }
    }

    public class IpNetDriver : NetDriver
    {
        public const string UeClassName = "IpNetDriver";
        public IpNetDriver(System.IntPtr ptr) : base(ptr) {}
        public static new IpNetDriver FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new IpNetDriver(p);
        public static IpNetDriver FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new IpNetDriver(o.Pointer); }
        public static IpNetDriver[] All() { var a = UObject.FindAllOf(UeClassName); var r = new IpNetDriver[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new IpNetDriver(a[i].Pointer); return r; }
        public bool LogPortUnreach { get => Native.GetPropBool(Pointer, "LogPortUnreach"); set => Native.SetPropBool(Pointer, "LogPortUnreach", value); }
        public bool AllowPlayerPortUnreach { get => Native.GetPropBool(Pointer, "AllowPlayerPortUnreach"); set => Native.SetPropBool(Pointer, "AllowPlayerPortUnreach", value); }
        public uint MaxPortCountToTry { get => GetAt<uint>(0x748); set => SetAt(0x748, value); }
        public uint ServerDesiredSocketReceiveBufferBytes { get => GetAt<uint>(0x75C); set => SetAt(0x75C, value); }
        public uint ServerDesiredSocketSendBufferBytes { get => GetAt<uint>(0x760); set => SetAt(0x760, value); }
        public uint ClientDesiredSocketReceiveBufferBytes { get => GetAt<uint>(0x764); set => SetAt(0x764, value); }
        public uint ClientDesiredSocketSendBufferBytes { get => GetAt<uint>(0x768); set => SetAt(0x768, value); }
        public double MaxSecondsInReceive { get => GetAt<double>(0x770); set => SetAt(0x770, value); }
        public int NbPacketsBetweenReceiveTimeTest { get => GetAt<int>(0x778); set => SetAt(0x778, value); }
        public float ResolutionConnectionTimeout { get => GetAt<float>(0x77C); set => SetAt(0x77C, value); }
    }

    public class AchievementBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "AchievementBlueprintLibrary";
        public AchievementBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new AchievementBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AchievementBlueprintLibrary(p);
        public static AchievementBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AchievementBlueprintLibrary(o.Pointer); }
        public static AchievementBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AchievementBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AchievementBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x56B3A28 — hookable via Hooks.InstallAt(NativeFunc_GetCachedAchievementProgress).</summary>
        public static System.IntPtr NativeFunc_GetCachedAchievementProgress => Memory.ModuleBase() + 0x56B3A28;
        public void GetCachedAchievementProgress(Object WorldContextObject, PlayerController PlayerController, FName AchievementId, bool bFoundID, float Progress)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set(0x10, AchievementId);
            __pb.Set<byte>(0x18, (byte)(bFoundID?1:0));
            __pb.Set(0x1C, Progress);
            CallRaw("GetCachedAchievementProgress", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56B363C — hookable via Hooks.InstallAt(NativeFunc_GetCachedAchievementDescription).</summary>
        public static System.IntPtr NativeFunc_GetCachedAchievementDescription => Memory.ModuleBase() + 0x56B363C;
        public void GetCachedAchievementDescription(Object WorldContextObject, PlayerController PlayerController, FName AchievementId, bool bFoundID, System.IntPtr Title, System.IntPtr LockedDescription, System.IntPtr UnlockedDescription, bool bHidden)
        {
            var __pb = new ParamBuffer(105);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set(0x10, AchievementId);
            __pb.Set<byte>(0x18, (byte)(bFoundID?1:0));
            __pb.Set<System.IntPtr>(0x20, Title);
            __pb.Set<System.IntPtr>(0x38, LockedDescription);
            __pb.Set<System.IntPtr>(0x50, UnlockedDescription);
            __pb.Set<byte>(0x68, (byte)(bHidden?1:0));
            CallRaw("GetCachedAchievementDescription", __pb.Bytes);
        }
    }

    public class AchievementQueryCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "AchievementQueryCallbackProxy";
        public AchievementQueryCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new AchievementQueryCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AchievementQueryCallbackProxy(p);
        public static AchievementQueryCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AchievementQueryCallbackProxy(o.Pointer); }
        public static AchievementQueryCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AchievementQueryCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AchievementQueryCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56B4580 — hookable via Hooks.InstallAt(NativeFunc_CacheAchievements).</summary>
        public static System.IntPtr NativeFunc_CacheAchievements => Memory.ModuleBase() + 0x56B4580;
        public AchievementQueryCallbackProxy CacheAchievements(Object WorldContextObject, PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            CallRaw("CacheAchievements", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new AchievementQueryCallbackProxy(__p); }
        }
        /// <summary>[Native] thunk RVA 0x56B449C — hookable via Hooks.InstallAt(NativeFunc_CacheAchievementDescriptions).</summary>
        public static System.IntPtr NativeFunc_CacheAchievementDescriptions => Memory.ModuleBase() + 0x56B449C;
        public AchievementQueryCallbackProxy CacheAchievementDescriptions(Object WorldContextObject, PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            CallRaw("CacheAchievementDescriptions", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new AchievementQueryCallbackProxy(__p); }
        }
    }

    public class AchievementWriteCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "AchievementWriteCallbackProxy";
        public AchievementWriteCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new AchievementWriteCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AchievementWriteCallbackProxy(p);
        public static AchievementWriteCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AchievementWriteCallbackProxy(o.Pointer); }
        public static AchievementWriteCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AchievementWriteCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AchievementWriteCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56B4F44 — hookable via Hooks.InstallAt(NativeFunc_WriteAchievementProgress).</summary>
        public static System.IntPtr NativeFunc_WriteAchievementProgress => Memory.ModuleBase() + 0x56B4F44;
        public AchievementWriteCallbackProxy WriteAchievementProgress(Object WorldContextObject, PlayerController PlayerController, FName AchievementName, float Progress, int UserTag)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set(0x10, AchievementName);
            __pb.Set(0x18, Progress);
            __pb.Set(0x1C, UserTag);
            CallRaw("WriteAchievementProgress", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new AchievementWriteCallbackProxy(__p); }
        }
    }

    public class ConnectionCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "ConnectionCallbackProxy";
        public ConnectionCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new ConnectionCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ConnectionCallbackProxy(p);
        public static ConnectionCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ConnectionCallbackProxy(o.Pointer); }
        public static ConnectionCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ConnectionCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ConnectionCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56B5AA0 — hookable via Hooks.InstallAt(NativeFunc_ConnectToService).</summary>
        public static System.IntPtr NativeFunc_ConnectToService => Memory.ModuleBase() + 0x56B5AA0;
        public ConnectionCallbackProxy ConnectToService(Object WorldContextObject, PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            CallRaw("ConnectToService", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new ConnectionCallbackProxy(__p); }
        }
    }

    public class CreateSessionCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "CreateSessionCallbackProxy";
        public CreateSessionCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new CreateSessionCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CreateSessionCallbackProxy(p);
        public static CreateSessionCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CreateSessionCallbackProxy(o.Pointer); }
        public static CreateSessionCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CreateSessionCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CreateSessionCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56B64E0 — hookable via Hooks.InstallAt(NativeFunc_CreateSession).</summary>
        public static System.IntPtr NativeFunc_CreateSession => Memory.ModuleBase() + 0x56B64E0;
        public CreateSessionCallbackProxy CreateSession(Object WorldContextObject, PlayerController PlayerController, int PublicConnections, bool bUseLAN)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set(0x10, PublicConnections);
            __pb.Set<byte>(0x14, (byte)(bUseLAN?1:0));
            CallRaw("CreateSession", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new CreateSessionCallbackProxy(__p); }
        }
    }

    public class DestroySessionCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "DestroySessionCallbackProxy";
        public DestroySessionCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new DestroySessionCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DestroySessionCallbackProxy(p);
        public static DestroySessionCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DestroySessionCallbackProxy(o.Pointer); }
        public static DestroySessionCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DestroySessionCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DestroySessionCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56B6FC0 — hookable via Hooks.InstallAt(NativeFunc_DestroySession).</summary>
        public static System.IntPtr NativeFunc_DestroySession => Memory.ModuleBase() + 0x56B6FC0;
        public DestroySessionCallbackProxy DestroySession(Object WorldContextObject, PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            CallRaw("DestroySession", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new DestroySessionCallbackProxy(__p); }
        }
    }

    public class EndMatchCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "EndMatchCallbackProxy";
        public EndMatchCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new EndMatchCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EndMatchCallbackProxy(p);
        public static EndMatchCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EndMatchCallbackProxy(o.Pointer); }
        public static EndMatchCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EndMatchCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EndMatchCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56B7A00 — hookable via Hooks.InstallAt(NativeFunc_EndMatch).</summary>
        public static System.IntPtr NativeFunc_EndMatch => Memory.ModuleBase() + 0x56B7A00;
        public EndMatchCallbackProxy EndMatch(Object WorldContextObject, PlayerController PlayerController, UObject MatchActor, System.IntPtr MatchID, byte LocalPlayerOutcome, byte OtherPlayersOutcome)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.SetObject(0x10, MatchActor);
            __pb.Set<System.IntPtr>(0x20, MatchID);
            __pb.Set(0x30, LocalPlayerOutcome);
            __pb.Set(0x31, OtherPlayersOutcome);
            CallRaw("EndMatch", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x38); return __p==System.IntPtr.Zero?null:new EndMatchCallbackProxy(__p); }
        }
    }

    public class EndTurnCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "EndTurnCallbackProxy";
        public EndTurnCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new EndTurnCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EndTurnCallbackProxy(p);
        public static EndTurnCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EndTurnCallbackProxy(o.Pointer); }
        public static EndTurnCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EndTurnCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EndTurnCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56B84C8 — hookable via Hooks.InstallAt(NativeFunc_EndTurn).</summary>
        public static System.IntPtr NativeFunc_EndTurn => Memory.ModuleBase() + 0x56B84C8;
        public EndTurnCallbackProxy EndTurn(Object WorldContextObject, PlayerController PlayerController, System.IntPtr MatchID, UObject TurnBasedMatchInterface)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set<System.IntPtr>(0x10, MatchID);
            __pb.SetObject(0x20, TurnBasedMatchInterface);
            CallRaw("EndTurn", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new EndTurnCallbackProxy(__p); }
        }
    }

    public class FindSessionsCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "FindSessionsCallbackProxy";
        public FindSessionsCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new FindSessionsCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FindSessionsCallbackProxy(p);
        public static FindSessionsCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FindSessionsCallbackProxy(o.Pointer); }
        public static FindSessionsCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FindSessionsCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FindSessionsCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56B92EC — hookable via Hooks.InstallAt(NativeFunc_GetServerName).</summary>
        public static System.IntPtr NativeFunc_GetServerName => Memory.ModuleBase() + 0x56B92EC;
        public System.IntPtr GetServerName(BlueprintSessionResult Result)
        {
            var __pb = new ParamBuffer(200);
            __pb.Set<System.IntPtr>(0x0, Result);
            CallRaw("GetServerName", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0xB8);
        }
        /// <summary>[Native] thunk RVA 0x56B944C — hookable via Hooks.InstallAt(NativeFunc_GetPingInMs).</summary>
        public static System.IntPtr NativeFunc_GetPingInMs => Memory.ModuleBase() + 0x56B944C;
        public int GetPingInMs(BlueprintSessionResult Result)
        {
            var __pb = new ParamBuffer(188);
            __pb.Set<System.IntPtr>(0x0, Result);
            CallRaw("GetPingInMs", __pb.Bytes);
            return __pb.Get<int>(0xB8);
        }
        /// <summary>[Native] thunk RVA 0x56B90A4 — hookable via Hooks.InstallAt(NativeFunc_GetMaxPlayers).</summary>
        public static System.IntPtr NativeFunc_GetMaxPlayers => Memory.ModuleBase() + 0x56B90A4;
        public int GetMaxPlayers(BlueprintSessionResult Result)
        {
            var __pb = new ParamBuffer(188);
            __pb.Set<System.IntPtr>(0x0, Result);
            CallRaw("GetMaxPlayers", __pb.Bytes);
            return __pb.Get<int>(0xB8);
        }
        /// <summary>[Native] thunk RVA 0x56B91C8 — hookable via Hooks.InstallAt(NativeFunc_GetCurrentPlayers).</summary>
        public static System.IntPtr NativeFunc_GetCurrentPlayers => Memory.ModuleBase() + 0x56B91C8;
        public int GetCurrentPlayers(BlueprintSessionResult Result)
        {
            var __pb = new ParamBuffer(188);
            __pb.Set<System.IntPtr>(0x0, Result);
            CallRaw("GetCurrentPlayers", __pb.Bytes);
            return __pb.Get<int>(0xB8);
        }
        /// <summary>[Native] thunk RVA 0x56B9570 — hookable via Hooks.InstallAt(NativeFunc_FindSessions).</summary>
        public static System.IntPtr NativeFunc_FindSessions => Memory.ModuleBase() + 0x56B9570;
        public FindSessionsCallbackProxy FindSessions(Object WorldContextObject, PlayerController PlayerController, int MaxResults, bool bUseLAN)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set(0x10, MaxResults);
            __pb.Set<byte>(0x14, (byte)(bUseLAN?1:0));
            CallRaw("FindSessions", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new FindSessionsCallbackProxy(__p); }
        }
    }

    public class FindTurnBasedMatchCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "FindTurnBasedMatchCallbackProxy";
        public FindTurnBasedMatchCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new FindTurnBasedMatchCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FindTurnBasedMatchCallbackProxy(p);
        public static FindTurnBasedMatchCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FindTurnBasedMatchCallbackProxy(o.Pointer); }
        public static FindTurnBasedMatchCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FindTurnBasedMatchCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FindTurnBasedMatchCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56BA484 — hookable via Hooks.InstallAt(NativeFunc_FindTurnBasedMatch).</summary>
        public static System.IntPtr NativeFunc_FindTurnBasedMatch => Memory.ModuleBase() + 0x56BA484;
        public FindTurnBasedMatchCallbackProxy FindTurnBasedMatch(Object WorldContextObject, PlayerController PlayerController, UObject MatchActor, int MinPlayers, int MaxPlayers, int PlayerGroup, bool ShowExistingMatches)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.SetObject(0x10, MatchActor);
            __pb.Set(0x20, MinPlayers);
            __pb.Set(0x24, MaxPlayers);
            __pb.Set(0x28, PlayerGroup);
            __pb.Set<byte>(0x2C, (byte)(ShowExistingMatches?1:0));
            CallRaw("FindTurnBasedMatch", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new FindTurnBasedMatchCallbackProxy(__p); }
        }
    }

    public class InAppPurchaseCallbackProxy : Object
    {
        public const string UeClassName = "InAppPurchaseCallbackProxy";
        public InAppPurchaseCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new InAppPurchaseCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InAppPurchaseCallbackProxy(p);
        public static InAppPurchaseCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InAppPurchaseCallbackProxy(o.Pointer); }
        public static InAppPurchaseCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InAppPurchaseCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InAppPurchaseCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x28); // 
        public System.IntPtr OnFailure => AddrOf(0x38); // 
        /// <summary>[Native] thunk RVA 0x56BB0CC — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForInAppPurchase).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForInAppPurchase => Memory.ModuleBase() + 0x56BB0CC;
        public InAppPurchaseCallbackProxy CreateProxyObjectForInAppPurchase(PlayerController PlayerController, InAppPurchaseProductRequest ProductRequest)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, PlayerController);
            __pb.Set<System.IntPtr>(0x8, ProductRequest);
            CallRaw("CreateProxyObjectForInAppPurchase", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new InAppPurchaseCallbackProxy(__p); }
        }
    }

    public class InAppPurchaseCallbackProxy2 : Object
    {
        public const string UeClassName = "InAppPurchaseCallbackProxy2";
        public InAppPurchaseCallbackProxy2(System.IntPtr ptr) : base(ptr) {}
        public static new InAppPurchaseCallbackProxy2 FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InAppPurchaseCallbackProxy2(p);
        public static InAppPurchaseCallbackProxy2 FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InAppPurchaseCallbackProxy2(o.Pointer); }
        public static InAppPurchaseCallbackProxy2[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InAppPurchaseCallbackProxy2[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InAppPurchaseCallbackProxy2(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x28); // 
        public System.IntPtr OnFailure => AddrOf(0x38); // 
        /// <summary>[Native] thunk RVA 0x56BC430 — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForInAppPurchaseUnprocessedPurchases).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForInAppPurchaseUnprocessedPurchases => Memory.ModuleBase() + 0x56BC430;
        public InAppPurchaseCallbackProxy2 CreateProxyObjectForInAppPurchaseUnprocessedPurchases(PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, PlayerController);
            CallRaw("CreateProxyObjectForInAppPurchaseUnprocessedPurchases", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new InAppPurchaseCallbackProxy2(__p); }
        }
        /// <summary>[Native] thunk RVA 0x56BC38C — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForInAppPurchaseQueryOwned).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForInAppPurchaseQueryOwned => Memory.ModuleBase() + 0x56BC38C;
        public InAppPurchaseCallbackProxy2 CreateProxyObjectForInAppPurchaseQueryOwned(PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, PlayerController);
            CallRaw("CreateProxyObjectForInAppPurchaseQueryOwned", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new InAppPurchaseCallbackProxy2(__p); }
        }
        /// <summary>[Native] thunk RVA 0x56BC4D4 — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForInAppPurchase).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForInAppPurchase => Memory.ModuleBase() + 0x56BC4D4;
        public InAppPurchaseCallbackProxy2 CreateProxyObjectForInAppPurchase(PlayerController PlayerController, InAppPurchaseProductRequest2 ProductRequest)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, PlayerController);
            __pb.Set<System.IntPtr>(0x8, ProductRequest);
            CallRaw("CreateProxyObjectForInAppPurchase", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new InAppPurchaseCallbackProxy2(__p); }
        }
    }

    public class InAppPurchaseQueryCallbackProxy : Object
    {
        public const string UeClassName = "InAppPurchaseQueryCallbackProxy";
        public InAppPurchaseQueryCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new InAppPurchaseQueryCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InAppPurchaseQueryCallbackProxy(p);
        public static InAppPurchaseQueryCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InAppPurchaseQueryCallbackProxy(o.Pointer); }
        public static InAppPurchaseQueryCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InAppPurchaseQueryCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InAppPurchaseQueryCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x28); // 
        public System.IntPtr OnFailure => AddrOf(0x38); // 
        /// <summary>[Native] thunk RVA 0x56BDC00 — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForInAppPurchaseQuery).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForInAppPurchaseQuery => Memory.ModuleBase() + 0x56BDC00;
        public InAppPurchaseQueryCallbackProxy CreateProxyObjectForInAppPurchaseQuery(PlayerController PlayerController, System.IntPtr ProductIdentifiers)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, PlayerController);
            __pb.Set<System.IntPtr>(0x8, ProductIdentifiers);
            CallRaw("CreateProxyObjectForInAppPurchaseQuery", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new InAppPurchaseQueryCallbackProxy(__p); }
        }
    }

    public class InAppPurchaseQueryCallbackProxy2 : Object
    {
        public const string UeClassName = "InAppPurchaseQueryCallbackProxy2";
        public InAppPurchaseQueryCallbackProxy2(System.IntPtr ptr) : base(ptr) {}
        public static new InAppPurchaseQueryCallbackProxy2 FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InAppPurchaseQueryCallbackProxy2(p);
        public static InAppPurchaseQueryCallbackProxy2 FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InAppPurchaseQueryCallbackProxy2(o.Pointer); }
        public static InAppPurchaseQueryCallbackProxy2[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InAppPurchaseQueryCallbackProxy2[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InAppPurchaseQueryCallbackProxy2(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x28); // 
        public System.IntPtr OnFailure => AddrOf(0x38); // 
        /// <summary>[Native] thunk RVA 0x56BE8F8 — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForInAppPurchaseQuery).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForInAppPurchaseQuery => Memory.ModuleBase() + 0x56BE8F8;
        public InAppPurchaseQueryCallbackProxy2 CreateProxyObjectForInAppPurchaseQuery(PlayerController PlayerController, System.IntPtr ProductIdentifiers)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, PlayerController);
            __pb.Set<System.IntPtr>(0x8, ProductIdentifiers);
            CallRaw("CreateProxyObjectForInAppPurchaseQuery", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new InAppPurchaseQueryCallbackProxy2(__p); }
        }
    }

    public class InAppPurchaseRestoreCallbackProxy : Object
    {
        public const string UeClassName = "InAppPurchaseRestoreCallbackProxy";
        public InAppPurchaseRestoreCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new InAppPurchaseRestoreCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InAppPurchaseRestoreCallbackProxy(p);
        public static InAppPurchaseRestoreCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InAppPurchaseRestoreCallbackProxy(o.Pointer); }
        public static InAppPurchaseRestoreCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InAppPurchaseRestoreCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InAppPurchaseRestoreCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x28); // 
        public System.IntPtr OnFailure => AddrOf(0x38); // 
        /// <summary>[Native] thunk RVA 0x56BF9FC — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForInAppPurchaseRestore).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForInAppPurchaseRestore => Memory.ModuleBase() + 0x56BF9FC;
        public InAppPurchaseRestoreCallbackProxy CreateProxyObjectForInAppPurchaseRestore(System.IntPtr ConsumableProductFlags, PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, ConsumableProductFlags);
            __pb.SetObject(0x10, PlayerController);
            CallRaw("CreateProxyObjectForInAppPurchaseRestore", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new InAppPurchaseRestoreCallbackProxy(__p); }
        }
    }

    public class InAppPurchaseRestoreCallbackProxy2 : Object
    {
        public const string UeClassName = "InAppPurchaseRestoreCallbackProxy2";
        public InAppPurchaseRestoreCallbackProxy2(System.IntPtr ptr) : base(ptr) {}
        public static new InAppPurchaseRestoreCallbackProxy2 FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InAppPurchaseRestoreCallbackProxy2(p);
        public static InAppPurchaseRestoreCallbackProxy2 FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InAppPurchaseRestoreCallbackProxy2(o.Pointer); }
        public static InAppPurchaseRestoreCallbackProxy2[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InAppPurchaseRestoreCallbackProxy2[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InAppPurchaseRestoreCallbackProxy2(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x28); // 
        public System.IntPtr OnFailure => AddrOf(0x38); // 
        /// <summary>[Native] thunk RVA 0x56C05F4 — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForInAppPurchaseRestore).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForInAppPurchaseRestore => Memory.ModuleBase() + 0x56C05F4;
        public InAppPurchaseRestoreCallbackProxy2 CreateProxyObjectForInAppPurchaseRestore(System.IntPtr ConsumableProductFlags, PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, ConsumableProductFlags);
            __pb.SetObject(0x10, PlayerController);
            CallRaw("CreateProxyObjectForInAppPurchaseRestore", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new InAppPurchaseRestoreCallbackProxy2(__p); }
        }
    }

    public class JoinSessionCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "JoinSessionCallbackProxy";
        public JoinSessionCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new JoinSessionCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new JoinSessionCallbackProxy(p);
        public static JoinSessionCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new JoinSessionCallbackProxy(o.Pointer); }
        public static JoinSessionCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new JoinSessionCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new JoinSessionCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56C21BC — hookable via Hooks.InstallAt(NativeFunc_JoinSession).</summary>
        public static System.IntPtr NativeFunc_JoinSession => Memory.ModuleBase() + 0x56C21BC;
        public JoinSessionCallbackProxy JoinSession(Object WorldContextObject, PlayerController PlayerController, BlueprintSessionResult SearchResult)
        {
            var __pb = new ParamBuffer(208);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set<System.IntPtr>(0x10, SearchResult);
            CallRaw("JoinSession", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0xC8); return __p==System.IntPtr.Zero?null:new JoinSessionCallbackProxy(__p); }
        }
    }

    public class LeaderboardBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "LeaderboardBlueprintLibrary";
        public LeaderboardBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new LeaderboardBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LeaderboardBlueprintLibrary(p);
        public static LeaderboardBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LeaderboardBlueprintLibrary(o.Pointer); }
        public static LeaderboardBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LeaderboardBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LeaderboardBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x56C2D18 — hookable via Hooks.InstallAt(NativeFunc_WriteLeaderboardInteger).</summary>
        public static System.IntPtr NativeFunc_WriteLeaderboardInteger => Memory.ModuleBase() + 0x56C2D18;
        public bool WriteLeaderboardInteger(PlayerController PlayerController, FName StatName, int StatValue)
        {
            var __pb = new ParamBuffer(21);
            __pb.SetObject(0x0, PlayerController);
            __pb.Set(0x8, StatName);
            __pb.Set(0x10, StatValue);
            CallRaw("WriteLeaderboardInteger", __pb.Bytes);
            return __pb.Get<byte>(0x14) != 0;
        }
    }

    public class LeaderboardFlushCallbackProxy : Object
    {
        public const string UeClassName = "LeaderboardFlushCallbackProxy";
        public LeaderboardFlushCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new LeaderboardFlushCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LeaderboardFlushCallbackProxy(p);
        public static LeaderboardFlushCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LeaderboardFlushCallbackProxy(o.Pointer); }
        public static LeaderboardFlushCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LeaderboardFlushCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LeaderboardFlushCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x28); // 
        public System.IntPtr OnFailure => AddrOf(0x38); // 
        /// <summary>[Native] thunk RVA 0x56C36D4 — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForFlush).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForFlush => Memory.ModuleBase() + 0x56C36D4;
        public LeaderboardFlushCallbackProxy CreateProxyObjectForFlush(PlayerController PlayerController, FName SessionName)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, PlayerController);
            __pb.Set(0x8, SessionName);
            CallRaw("CreateProxyObjectForFlush", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new LeaderboardFlushCallbackProxy(__p); }
        }
    }

    public class LeaderboardQueryCallbackProxy : Object
    {
        public const string UeClassName = "LeaderboardQueryCallbackProxy";
        public LeaderboardQueryCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new LeaderboardQueryCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LeaderboardQueryCallbackProxy(p);
        public static LeaderboardQueryCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LeaderboardQueryCallbackProxy(o.Pointer); }
        public static LeaderboardQueryCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LeaderboardQueryCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LeaderboardQueryCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x28); // 
        public System.IntPtr OnFailure => AddrOf(0x38); // 
        /// <summary>[Native] thunk RVA 0x56C4128 — hookable via Hooks.InstallAt(NativeFunc_CreateProxyObjectForIntQuery).</summary>
        public static System.IntPtr NativeFunc_CreateProxyObjectForIntQuery => Memory.ModuleBase() + 0x56C4128;
        public LeaderboardQueryCallbackProxy CreateProxyObjectForIntQuery(PlayerController PlayerController, FName StatName)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, PlayerController);
            __pb.Set(0x8, StatName);
            CallRaw("CreateProxyObjectForIntQuery", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new LeaderboardQueryCallbackProxy(__p); }
        }
    }

    public class LogoutCallbackProxy : BlueprintAsyncActionBase
    {
        public const string UeClassName = "LogoutCallbackProxy";
        public LogoutCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new LogoutCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LogoutCallbackProxy(p);
        public static LogoutCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LogoutCallbackProxy(o.Pointer); }
        public static LogoutCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LogoutCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LogoutCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56C4B90 — hookable via Hooks.InstallAt(NativeFunc_Logout).</summary>
        public static System.IntPtr NativeFunc_Logout => Memory.ModuleBase() + 0x56C4B90;
        public LogoutCallbackProxy Logout(Object WorldContextObject, PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            CallRaw("Logout", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new LogoutCallbackProxy(__p); }
        }
    }

    public class OnlineBeacon : Actor
    {
        public const string UeClassName = "OnlineBeacon";
        public OnlineBeacon(System.IntPtr ptr) : base(ptr) {}
        public static new OnlineBeacon FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OnlineBeacon(p);
        public static OnlineBeacon FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OnlineBeacon(o.Pointer); }
        public static OnlineBeacon[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OnlineBeacon[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OnlineBeacon(a[i].Pointer); return r; }
        public float BeaconConnectionInitialTimeout { get => GetAt<float>(0x228); set => SetAt(0x228, value); }
        public float BeaconConnectionTimeout { get => GetAt<float>(0x22C); set => SetAt(0x22C, value); }
        public NetDriver NetDriver { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new NetDriver(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class OnlineBeaconClient : OnlineBeacon
    {
        public const string UeClassName = "OnlineBeaconClient";
        public OnlineBeaconClient(System.IntPtr ptr) : base(ptr) {}
        public static new OnlineBeaconClient FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OnlineBeaconClient(p);
        public static OnlineBeaconClient FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OnlineBeaconClient(o.Pointer); }
        public static OnlineBeaconClient[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OnlineBeaconClient[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OnlineBeaconClient(a[i].Pointer); return r; }
        public OnlineBeaconHostObject BeaconOwner { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new OnlineBeaconHostObject(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public NetConnection BeaconConnection { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new NetConnection(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public EBeaconConnectionState ConnectionState { get => (EBeaconConnectionState)GetAt<byte>(0x260); set => SetAt(0x260, (byte)value); }
        /// <summary>[Native] thunk RVA 0x56C5D1C — hookable via Hooks.InstallAt(NativeFunc_ClientOnConnected).</summary>
        public static System.IntPtr NativeFunc_ClientOnConnected => Memory.ModuleBase() + 0x56C5D1C;
        public void ClientOnConnected()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClientOnConnected", __pb.Bytes);
        }
    }

    public class OnlineBeaconHost : OnlineBeacon
    {
        public const string UeClassName = "OnlineBeaconHost";
        public OnlineBeaconHost(System.IntPtr ptr) : base(ptr) {}
        public static new OnlineBeaconHost FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OnlineBeaconHost(p);
        public static OnlineBeaconHost FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OnlineBeaconHost(o.Pointer); }
        public static OnlineBeaconHost[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OnlineBeaconHost[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OnlineBeaconHost(a[i].Pointer); return r; }
        public int ListenPort { get => GetAt<int>(0x250); set => SetAt(0x250, value); }
        public TArray<System.IntPtr> ClientActors => new TArray<System.IntPtr>(AddrOf(0x258)); // TArray<UObject*>
    }

    public class OnlineBeaconHostObject : Actor
    {
        public const string UeClassName = "OnlineBeaconHostObject";
        public OnlineBeaconHostObject(System.IntPtr ptr) : base(ptr) {}
        public static new OnlineBeaconHostObject FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OnlineBeaconHostObject(p);
        public static OnlineBeaconHostObject FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OnlineBeaconHostObject(o.Pointer); }
        public static OnlineBeaconHostObject[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OnlineBeaconHostObject[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OnlineBeaconHostObject(a[i].Pointer); return r; }
        public string BeaconTypeName => Native.GetPropString(Pointer, "BeaconTypeName"); // FString
        public OnlineBeaconClient ClientBeaconActorClass { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new OnlineBeaconClient(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> ClientActors => new TArray<System.IntPtr>(AddrOf(0x238)); // TArray<UObject*>
    }

    public class OnlineEngineInterfaceImpl : OnlineEngineInterface
    {
        public const string UeClassName = "OnlineEngineInterfaceImpl";
        public OnlineEngineInterfaceImpl(System.IntPtr ptr) : base(ptr) {}
        public static new OnlineEngineInterfaceImpl FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OnlineEngineInterfaceImpl(p);
        public static OnlineEngineInterfaceImpl FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OnlineEngineInterfaceImpl(o.Pointer); }
        public static OnlineEngineInterfaceImpl[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OnlineEngineInterfaceImpl[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OnlineEngineInterfaceImpl(a[i].Pointer); return r; }
        public string VoiceSubsystemNameOverride => Native.GetPropName(Pointer, "VoiceSubsystemNameOverride"); // FName
        public FName VoiceSubsystemNameOverride_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
    }

    public class OnlinePIESettings : DeveloperSettings
    {
        public const string UeClassName = "OnlinePIESettings";
        public OnlinePIESettings(System.IntPtr ptr) : base(ptr) {}
        public static new OnlinePIESettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OnlinePIESettings(p);
        public static OnlinePIESettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OnlinePIESettings(o.Pointer); }
        public static OnlinePIESettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OnlinePIESettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OnlinePIESettings(a[i].Pointer); return r; }
        public bool bOnlinePIEEnabled { get => Native.GetPropBool(Pointer, "bOnlinePIEEnabled"); set => Native.SetPropBool(Pointer, "bOnlinePIEEnabled", value); }
        public TArray<System.IntPtr> Logins => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<struct>
    }

    public class OnlineSessionClient : OnlineSession
    {
        public const string UeClassName = "OnlineSessionClient";
        public OnlineSessionClient(System.IntPtr ptr) : base(ptr) {}
        public static new OnlineSessionClient FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OnlineSessionClient(p);
        public static OnlineSessionClient FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OnlineSessionClient(o.Pointer); }
        public static OnlineSessionClient[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OnlineSessionClient[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OnlineSessionClient(a[i].Pointer); return r; }
        public bool bIsFromInvite { get => Native.GetPropBool(Pointer, "bIsFromInvite"); set => Native.SetPropBool(Pointer, "bIsFromInvite", value); }
        public bool bHandlingDisconnect { get => Native.GetPropBool(Pointer, "bHandlingDisconnect"); set => Native.SetPropBool(Pointer, "bHandlingDisconnect", value); }
    }

    public class PartyBeaconClient : OnlineBeaconClient
    {
        public const string UeClassName = "PartyBeaconClient";
        public PartyBeaconClient(System.IntPtr ptr) : base(ptr) {}
        public static new PartyBeaconClient FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PartyBeaconClient(p);
        public static PartyBeaconClient FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PartyBeaconClient(o.Pointer); }
        public static PartyBeaconClient[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PartyBeaconClient[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PartyBeaconClient(a[i].Pointer); return r; }
        public string DestSessionId => Native.GetPropString(Pointer, "DestSessionId"); // FString
        public PartyReservation PendingReservation => new PartyReservation(AddrOf(0x2F0));
        public EClientRequestType RequestType { get => (EClientRequestType)GetAt<byte>(0x340); set => SetAt(0x340, (byte)value); }
        public bool bPendingReservationSent { get => Native.GetPropBool(Pointer, "bPendingReservationSent"); set => Native.SetPropBool(Pointer, "bPendingReservationSent", value); }
        public bool bCancelReservation { get => Native.GetPropBool(Pointer, "bCancelReservation"); set => Native.SetPropBool(Pointer, "bCancelReservation", value); }
        /// <summary>[Native] thunk RVA 0x56CA11C — hookable via Hooks.InstallAt(NativeFunc_ServerUpdateReservationRequest).</summary>
        public static System.IntPtr NativeFunc_ServerUpdateReservationRequest => Memory.ModuleBase() + 0x56CA11C;
        public void ServerUpdateReservationRequest(System.IntPtr SessionId, PartyReservation ReservationUpdate)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<System.IntPtr>(0x0, SessionId);
            __pb.Set<System.IntPtr>(0x10, ReservationUpdate);
            CallRaw("ServerUpdateReservationRequest", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CA2FC — hookable via Hooks.InstallAt(NativeFunc_ServerReservationRequest).</summary>
        public static System.IntPtr NativeFunc_ServerReservationRequest => Memory.ModuleBase() + 0x56CA2FC;
        public void ServerReservationRequest(System.IntPtr SessionId, PartyReservation Reservation)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<System.IntPtr>(0x0, SessionId);
            __pb.Set<System.IntPtr>(0x10, Reservation);
            CallRaw("ServerReservationRequest", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56C9F3C — hookable via Hooks.InstallAt(NativeFunc_ServerRemoveMemberFromReservationRequest).</summary>
        public static System.IntPtr NativeFunc_ServerRemoveMemberFromReservationRequest => Memory.ModuleBase() + 0x56C9F3C;
        public void ServerRemoveMemberFromReservationRequest(System.IntPtr SessionId, PartyReservation ReservationUpdate)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<System.IntPtr>(0x0, SessionId);
            __pb.Set<System.IntPtr>(0x10, ReservationUpdate);
            CallRaw("ServerRemoveMemberFromReservationRequest", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56C9DC0 — hookable via Hooks.InstallAt(NativeFunc_ServerCancelReservationRequest).</summary>
        public static System.IntPtr NativeFunc_ServerCancelReservationRequest => Memory.ModuleBase() + 0x56C9DC0;
        public void ServerCancelReservationRequest(UniqueNetIdRepl PartyLeader)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, PartyLeader);
            CallRaw("ServerCancelReservationRequest", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CA4F8 — hookable via Hooks.InstallAt(NativeFunc_ClientSendReservationUpdates).</summary>
        public static System.IntPtr NativeFunc_ClientSendReservationUpdates => Memory.ModuleBase() + 0x56CA4F8;
        public void ClientSendReservationUpdates(int NumRemainingReservations)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumRemainingReservations);
            CallRaw("ClientSendReservationUpdates", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CA4DC — hookable via Hooks.InstallAt(NativeFunc_ClientSendReservationFull).</summary>
        public static System.IntPtr NativeFunc_ClientSendReservationFull => Memory.ModuleBase() + 0x56CA4DC;
        public void ClientSendReservationFull()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClientSendReservationFull", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CA650 — hookable via Hooks.InstallAt(NativeFunc_ClientReservationResponse).</summary>
        public static System.IntPtr NativeFunc_ClientReservationResponse => Memory.ModuleBase() + 0x56CA650;
        public void ClientReservationResponse(byte ReservationResponse)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, ReservationResponse);
            CallRaw("ClientReservationResponse", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CA5A4 — hookable via Hooks.InstallAt(NativeFunc_ClientCancelReservationResponse).</summary>
        public static System.IntPtr NativeFunc_ClientCancelReservationResponse => Memory.ModuleBase() + 0x56CA5A4;
        public void ClientCancelReservationResponse(byte ReservationResponse)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, ReservationResponse);
            CallRaw("ClientCancelReservationResponse", __pb.Bytes);
        }
    }

    public class PartyBeaconHost : OnlineBeaconHostObject
    {
        public const string UeClassName = "PartyBeaconHost";
        public PartyBeaconHost(System.IntPtr ptr) : base(ptr) {}
        public static new PartyBeaconHost FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PartyBeaconHost(p);
        public static PartyBeaconHost FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PartyBeaconHost(o.Pointer); }
        public static PartyBeaconHost[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PartyBeaconHost[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PartyBeaconHost(a[i].Pointer); return r; }
        public PartyBeaconState State { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new PartyBeaconState(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bLogoutOnSessionTimeout { get => Native.GetPropBool(Pointer, "bLogoutOnSessionTimeout"); set => Native.SetPropBool(Pointer, "bLogoutOnSessionTimeout", value); }
        public float SessionTimeoutSecs { get => GetAt<float>(0x2B4); set => SetAt(0x2B4, value); }
        public float TravelSessionTimeoutSecs { get => GetAt<float>(0x2B8); set => SetAt(0x2B8, value); }
    }

    public class PartyBeaconState : Object
    {
        public const string UeClassName = "PartyBeaconState";
        public PartyBeaconState(System.IntPtr ptr) : base(ptr) {}
        public static new PartyBeaconState FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PartyBeaconState(p);
        public static PartyBeaconState FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PartyBeaconState(o.Pointer); }
        public static PartyBeaconState[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PartyBeaconState[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PartyBeaconState(a[i].Pointer); return r; }
        public string SessionName => Native.GetPropName(Pointer, "SessionName"); // FName
        public FName SessionName_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
        public int NumConsumedReservations { get => GetAt<int>(0x30); set => SetAt(0x30, value); }
        public int MaxReservations { get => GetAt<int>(0x34); set => SetAt(0x34, value); }
        public int NumTeams { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
        public int NumPlayersPerTeam { get => GetAt<int>(0x3C); set => SetAt(0x3C, value); }
        public string TeamAssignmentMethod => Native.GetPropName(Pointer, "TeamAssignmentMethod"); // FName
        public FName TeamAssignmentMethod_Raw { get => GetAt<FName>(0x40); set => SetAt(0x40, value); }
        public int ReservedHostTeamNum { get => GetAt<int>(0x48); set => SetAt(0x48, value); }
        public int ForceTeamNum { get => GetAt<int>(0x4C); set => SetAt(0x4C, value); }
        public bool bRestrictCrossConsole { get => Native.GetPropBool(Pointer, "bRestrictCrossConsole"); set => Native.SetPropBool(Pointer, "bRestrictCrossConsole", value); }
        public bool bEnableRemovalRequests { get => Native.GetPropBool(Pointer, "bEnableRemovalRequests"); set => Native.SetPropBool(Pointer, "bEnableRemovalRequests", value); }
        public TArray<System.IntPtr> Reservations => new TArray<System.IntPtr>(AddrOf(0x58)); // TArray<struct>
    }

    public class QuitMatchCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "QuitMatchCallbackProxy";
        public QuitMatchCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new QuitMatchCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new QuitMatchCallbackProxy(p);
        public static QuitMatchCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new QuitMatchCallbackProxy(o.Pointer); }
        public static QuitMatchCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new QuitMatchCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new QuitMatchCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56CCF18 — hookable via Hooks.InstallAt(NativeFunc_QuitMatch).</summary>
        public static System.IntPtr NativeFunc_QuitMatch => Memory.ModuleBase() + 0x56CCF18;
        public QuitMatchCallbackProxy QuitMatch(Object WorldContextObject, PlayerController PlayerController, System.IntPtr MatchID, byte Outcome, int TurnTimeoutInSeconds)
        {
            var __pb = new ParamBuffer(48);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set<System.IntPtr>(0x10, MatchID);
            __pb.Set(0x20, Outcome);
            __pb.Set(0x24, TurnTimeoutInSeconds);
            CallRaw("QuitMatch", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new QuitMatchCallbackProxy(__p); }
        }
    }

    public class ShowLoginUICallbackProxy : BlueprintAsyncActionBase
    {
        public const string UeClassName = "ShowLoginUICallbackProxy";
        public ShowLoginUICallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new ShowLoginUICallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ShowLoginUICallbackProxy(p);
        public static ShowLoginUICallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ShowLoginUICallbackProxy(o.Pointer); }
        public static ShowLoginUICallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ShowLoginUICallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ShowLoginUICallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x56CD9C4 — hookable via Hooks.InstallAt(NativeFunc_ShowExternalLoginUI).</summary>
        public static System.IntPtr NativeFunc_ShowExternalLoginUI => Memory.ModuleBase() + 0x56CD9C4;
        public ShowLoginUICallbackProxy ShowExternalLoginUI(Object WorldContextObject, PlayerController InPlayerController)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, InPlayerController);
            CallRaw("ShowExternalLoginUI", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new ShowLoginUICallbackProxy(__p); }
        }
    }

    public class SpectatorBeaconClient : OnlineBeaconClient
    {
        public const string UeClassName = "SpectatorBeaconClient";
        public SpectatorBeaconClient(System.IntPtr ptr) : base(ptr) {}
        public static new SpectatorBeaconClient FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SpectatorBeaconClient(p);
        public static SpectatorBeaconClient FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SpectatorBeaconClient(o.Pointer); }
        public static SpectatorBeaconClient[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SpectatorBeaconClient[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SpectatorBeaconClient(a[i].Pointer); return r; }
        public string DestSessionId => Native.GetPropString(Pointer, "DestSessionId"); // FString
        public SpectatorReservation PendingReservation => new SpectatorReservation(AddrOf(0x2F0));
        public ESpectatorClientRequestType RequestType { get => (ESpectatorClientRequestType)GetAt<byte>(0x368); set => SetAt(0x368, (byte)value); }
        public bool bPendingReservationSent { get => Native.GetPropBool(Pointer, "bPendingReservationSent"); set => Native.SetPropBool(Pointer, "bPendingReservationSent", value); }
        public bool bCancelReservation { get => Native.GetPropBool(Pointer, "bCancelReservation"); set => Native.SetPropBool(Pointer, "bCancelReservation", value); }
        /// <summary>[Native] thunk RVA 0x56CE564 — hookable via Hooks.InstallAt(NativeFunc_ServerReservationRequest).</summary>
        public static System.IntPtr NativeFunc_ServerReservationRequest => Memory.ModuleBase() + 0x56CE564;
        public void ServerReservationRequest(System.IntPtr SessionId, SpectatorReservation Reservation)
        {
            var __pb = new ParamBuffer(136);
            __pb.Set<System.IntPtr>(0x0, SessionId);
            __pb.Set<System.IntPtr>(0x10, Reservation);
            CallRaw("ServerReservationRequest", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CE3E8 — hookable via Hooks.InstallAt(NativeFunc_ServerCancelReservationRequest).</summary>
        public static System.IntPtr NativeFunc_ServerCancelReservationRequest => Memory.ModuleBase() + 0x56CE3E8;
        public void ServerCancelReservationRequest(UniqueNetIdRepl Spectator)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, Spectator);
            CallRaw("ServerCancelReservationRequest", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CE6E4 — hookable via Hooks.InstallAt(NativeFunc_ClientSendReservationUpdates).</summary>
        public static System.IntPtr NativeFunc_ClientSendReservationUpdates => Memory.ModuleBase() + 0x56CE6E4;
        public void ClientSendReservationUpdates(int NumRemainingReservations)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumRemainingReservations);
            CallRaw("ClientSendReservationUpdates", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CE6C8 — hookable via Hooks.InstallAt(NativeFunc_ClientSendReservationFull).</summary>
        public static System.IntPtr NativeFunc_ClientSendReservationFull => Memory.ModuleBase() + 0x56CE6C8;
        public void ClientSendReservationFull()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClientSendReservationFull", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CE83C — hookable via Hooks.InstallAt(NativeFunc_ClientReservationResponse).</summary>
        public static System.IntPtr NativeFunc_ClientReservationResponse => Memory.ModuleBase() + 0x56CE83C;
        public void ClientReservationResponse(byte ReservationResponse)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, ReservationResponse);
            CallRaw("ClientReservationResponse", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56CE790 — hookable via Hooks.InstallAt(NativeFunc_ClientCancelReservationResponse).</summary>
        public static System.IntPtr NativeFunc_ClientCancelReservationResponse => Memory.ModuleBase() + 0x56CE790;
        public void ClientCancelReservationResponse(byte ReservationResponse)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, ReservationResponse);
            CallRaw("ClientCancelReservationResponse", __pb.Bytes);
        }
    }

    public class SpectatorBeaconHost : OnlineBeaconHostObject
    {
        public const string UeClassName = "SpectatorBeaconHost";
        public SpectatorBeaconHost(System.IntPtr ptr) : base(ptr) {}
        public static new SpectatorBeaconHost FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SpectatorBeaconHost(p);
        public static SpectatorBeaconHost FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SpectatorBeaconHost(o.Pointer); }
        public static SpectatorBeaconHost[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SpectatorBeaconHost[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SpectatorBeaconHost(a[i].Pointer); return r; }
        public SpectatorBeaconState State { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new SpectatorBeaconState(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bLogoutOnSessionTimeout { get => Native.GetPropBool(Pointer, "bLogoutOnSessionTimeout"); set => Native.SetPropBool(Pointer, "bLogoutOnSessionTimeout", value); }
        public float SessionTimeoutSecs { get => GetAt<float>(0x2B4); set => SetAt(0x2B4, value); }
        public float TravelSessionTimeoutSecs { get => GetAt<float>(0x2B8); set => SetAt(0x2B8, value); }
    }

    public class SpectatorBeaconState : Object
    {
        public const string UeClassName = "SpectatorBeaconState";
        public SpectatorBeaconState(System.IntPtr ptr) : base(ptr) {}
        public static new SpectatorBeaconState FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SpectatorBeaconState(p);
        public static SpectatorBeaconState FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SpectatorBeaconState(o.Pointer); }
        public static SpectatorBeaconState[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SpectatorBeaconState[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SpectatorBeaconState(a[i].Pointer); return r; }
        public string SessionName => Native.GetPropName(Pointer, "SessionName"); // FName
        public FName SessionName_Raw { get => GetAt<FName>(0x28); set => SetAt(0x28, value); }
        public int NumConsumedReservations { get => GetAt<int>(0x30); set => SetAt(0x30, value); }
        public int MaxReservations { get => GetAt<int>(0x34); set => SetAt(0x34, value); }
        public bool bRestrictCrossConsole { get => Native.GetPropBool(Pointer, "bRestrictCrossConsole"); set => Native.SetPropBool(Pointer, "bRestrictCrossConsole", value); }
        public TArray<System.IntPtr> Reservations => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<struct>
    }

    public class TestBeaconClient : OnlineBeaconClient
    {
        public const string UeClassName = "TestBeaconClient";
        public TestBeaconClient(System.IntPtr ptr) : base(ptr) {}
        public static new TestBeaconClient FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TestBeaconClient(p);
        public static TestBeaconClient FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TestBeaconClient(o.Pointer); }
        public static TestBeaconClient[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TestBeaconClient[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TestBeaconClient(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x56D0B28 — hookable via Hooks.InstallAt(NativeFunc_ServerPong).</summary>
        public static System.IntPtr NativeFunc_ServerPong => Memory.ModuleBase() + 0x56D0B28;
        public void ServerPong()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ServerPong", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56D0B84 — hookable via Hooks.InstallAt(NativeFunc_ClientPing).</summary>
        public static System.IntPtr NativeFunc_ClientPing => Memory.ModuleBase() + 0x56D0B84;
        public void ClientPing()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClientPing", __pb.Bytes);
        }
    }

    public class TestBeaconHost : OnlineBeaconHostObject
    {
        public const string UeClassName = "TestBeaconHost";
        public TestBeaconHost(System.IntPtr ptr) : base(ptr) {}
        public static new TestBeaconHost FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TestBeaconHost(p);
        public static TestBeaconHost FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TestBeaconHost(o.Pointer); }
        public static TestBeaconHost[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TestBeaconHost[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TestBeaconHost(a[i].Pointer); return r; }
    }

    public class TurnBasedBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "TurnBasedBlueprintLibrary";
        public TurnBasedBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new TurnBasedBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TurnBasedBlueprintLibrary(p);
        public static TurnBasedBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TurnBasedBlueprintLibrary(o.Pointer); }
        public static TurnBasedBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TurnBasedBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TurnBasedBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x56D1E64 — hookable via Hooks.InstallAt(NativeFunc_RegisterTurnBasedMatchInterfaceObject).</summary>
        public static System.IntPtr NativeFunc_RegisterTurnBasedMatchInterfaceObject => Memory.ModuleBase() + 0x56D1E64;
        public void RegisterTurnBasedMatchInterfaceObject(Object WorldContextObject, PlayerController PlayerController, Object Object)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.SetObject(0x10, Object);
            CallRaw("RegisterTurnBasedMatchInterfaceObject", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56D1C34 — hookable via Hooks.InstallAt(NativeFunc_GetPlayerDisplayName).</summary>
        public static System.IntPtr NativeFunc_GetPlayerDisplayName => Memory.ModuleBase() + 0x56D1C34;
        public void GetPlayerDisplayName(Object WorldContextObject, PlayerController PlayerController, System.IntPtr MatchID, int PlayerIndex, System.IntPtr PlayerDisplayName)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set<System.IntPtr>(0x10, MatchID);
            __pb.Set(0x20, PlayerIndex);
            __pb.Set<System.IntPtr>(0x28, PlayerDisplayName);
            CallRaw("GetPlayerDisplayName", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56D1F7C — hookable via Hooks.InstallAt(NativeFunc_GetMyPlayerIndex).</summary>
        public static System.IntPtr NativeFunc_GetMyPlayerIndex => Memory.ModuleBase() + 0x56D1F7C;
        public void GetMyPlayerIndex(Object WorldContextObject, PlayerController PlayerController, System.IntPtr MatchID, int PlayerIndex)
        {
            var __pb = new ParamBuffer(36);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set<System.IntPtr>(0x10, MatchID);
            __pb.Set(0x20, PlayerIndex);
            CallRaw("GetMyPlayerIndex", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x56D215C — hookable via Hooks.InstallAt(NativeFunc_GetIsMyTurn).</summary>
        public static System.IntPtr NativeFunc_GetIsMyTurn => Memory.ModuleBase() + 0x56D215C;
        public void GetIsMyTurn(Object WorldContextObject, PlayerController PlayerController, System.IntPtr MatchID, bool bIsMyTurn)
        {
            var __pb = new ParamBuffer(33);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, PlayerController);
            __pb.Set<System.IntPtr>(0x10, MatchID);
            __pb.Set<byte>(0x20, (byte)(bIsMyTurn?1:0));
            CallRaw("GetIsMyTurn", __pb.Bytes);
        }
    }

    public class VoipListenerSynthComponent : SynthComponent
    {
        public const string UeClassName = "VoipListenerSynthComponent";
        public VoipListenerSynthComponent(System.IntPtr ptr) : base(ptr) {}
        public static new VoipListenerSynthComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VoipListenerSynthComponent(p);
        public static VoipListenerSynthComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VoipListenerSynthComponent(o.Pointer); }
        public static VoipListenerSynthComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VoipListenerSynthComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VoipListenerSynthComponent(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x56D2C64 — hookable via Hooks.InstallAt(NativeFunc_IsIdling).</summary>
        public static System.IntPtr NativeFunc_IsIdling => Memory.ModuleBase() + 0x56D2C64;
        public bool IsIdling()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsIdling", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

}
