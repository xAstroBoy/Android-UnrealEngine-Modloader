// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/SessionMessages
using System;

namespace UEModLoader.Game
{
    public class SessionServiceLogUnsubscribe : StructProxy
    {
        public SessionServiceLogUnsubscribe(System.IntPtr ptr) : base(ptr) {}
    }

    public class SessionServiceLogSubscribe : StructProxy
    {
        public SessionServiceLogSubscribe(System.IntPtr ptr) : base(ptr) {}
    }

    public class SessionServiceLog : StructProxy
    {
        public SessionServiceLog(System.IntPtr ptr) : base(ptr) {}
        public string Category => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Category_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string Data => Native.ReadFStringAt(AddrOf(0x8)); // FString
        public Guid InstanceId => new Guid(AddrOf(0x18));
        public double TimeSeconds { get => GetAt<double>(0x28); set => SetAt(0x28, value); }
        public byte Verbosity { get => GetAt<byte>(0x30); set => SetAt(0x30, value); }
    }

    public class SessionServicePong : StructProxy
    {
        public SessionServicePong(System.IntPtr ptr) : base(ptr) {}
        public bool Authorized { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public string BuildDate => Native.ReadFStringAt(AddrOf(0x8)); // FString
        public string DeviceName => Native.ReadFStringAt(AddrOf(0x18)); // FString
        public Guid InstanceId => new Guid(AddrOf(0x28));
        public string InstanceName => Native.ReadFStringAt(AddrOf(0x38)); // FString
        public string PlatformName => Native.ReadFStringAt(AddrOf(0x48)); // FString
        public Guid SessionId => new Guid(AddrOf(0x58));
        public string SessionName => Native.ReadFStringAt(AddrOf(0x68)); // FString
        public string SessionOwner => Native.ReadFStringAt(AddrOf(0x78)); // FString
        public bool Standalone { get => (GetAt<byte>(0x88) & 0xFF) != 0; set { var __b = GetAt<byte>(0x88); SetAt(0x88, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class SessionServicePing : StructProxy
    {
        public SessionServicePing(System.IntPtr ptr) : base(ptr) {}
        public string UserName => Native.ReadFStringAt(AddrOf(0x0)); // FString
    }

}
