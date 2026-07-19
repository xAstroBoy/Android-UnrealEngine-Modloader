// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/OnlineSubsystem
using System;

namespace UEModLoader.Game
{
    public enum EInAppPurchaseState
    {
        Unknown = 0,
        Success = 1,
        Failed = 2,
        Cancelled = 3,
        Invalid = 4,
        NotAllowed = 5,
        Restored = 6,
        AlreadyOwned = 7,
    }

    public enum EMPMatchOutcome
    {
        None = 0,
        Quit = 1,
        Won = 2,
        Lost = 3,
        Tied = 4,
        TimeExpired = 5,
        First = 6,
        Second = 7,
        Third = 8,
        Fourth = 9,
    }

    public class InAppPurchaseProductInfo : StructProxy
    {
        public InAppPurchaseProductInfo(System.IntPtr ptr) : base(ptr) {}
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
    }

    public class InAppPurchaseRestoreInfo : StructProxy
    {
        public InAppPurchaseRestoreInfo(System.IntPtr ptr) : base(ptr) {}
        public string Identifier => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string ReceiptData => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public string TransactionIdentifier => Native.ReadFStringAt(AddrOf(0x20)); // FString
    }

    public class NamedInterfaceDef : StructProxy
    {
        public NamedInterfaceDef(System.IntPtr ptr) : base(ptr) {}
        public string InterfaceName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName InterfaceName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string InterfaceClassName => Native.ReadFStringAt(AddrOf(0x8)); // FString
    }

    public class NamedInterface : StructProxy
    {
        public NamedInterface(System.IntPtr ptr) : base(ptr) {}
        public string InterfaceName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName InterfaceName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public Object InterfaceObject { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class InAppPurchaseProductRequest : StructProxy
    {
        public InAppPurchaseProductRequest(System.IntPtr ptr) : base(ptr) {}
        public string ProductIdentifier => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public bool bIsConsumable { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class NamedInterfaces : Object
    {
        public const string UeClassName = "NamedInterfaces";
        public NamedInterfaces(System.IntPtr ptr) : base(ptr) {}
        public static new NamedInterfaces FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new NamedInterfaces(p);
        public static NamedInterfaces FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NamedInterfaces(o.Pointer); }
        public static NamedInterfaces[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NamedInterfaces[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NamedInterfaces(a[i].Pointer); return r; }
        public TArray<System.IntPtr> NamedInterfaces_2 => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public TArray<System.IntPtr> NamedInterfaceDefs => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<struct>
    }

    public class TurnBasedMatchInterface : Interface
    {
        public const string UeClassName = "TurnBasedMatchInterface";
        public TurnBasedMatchInterface(System.IntPtr ptr) : base(ptr) {}
        public static new TurnBasedMatchInterface FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TurnBasedMatchInterface(p);
        public static TurnBasedMatchInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TurnBasedMatchInterface(o.Pointer); }
        public static TurnBasedMatchInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TurnBasedMatchInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TurnBasedMatchInterface(a[i].Pointer); return r; }
        public void OnMatchReceivedTurn(System.IntPtr Match, bool bDidBecomeActive)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, Match);
            __pb.Set<byte>(0x10, (byte)(bDidBecomeActive?1:0));
            CallRaw("OnMatchReceivedTurn", __pb.Bytes);
        }
        public void OnMatchEnded(System.IntPtr Match)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Match);
            CallRaw("OnMatchEnded", __pb.Bytes);
        }
    }

}
