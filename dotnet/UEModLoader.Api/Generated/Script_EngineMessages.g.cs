// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/EngineMessages
using System;

namespace UEModLoader.Game
{
    public class EngineServiceNotification : StructProxy
    {
        public EngineServiceNotification(System.IntPtr ptr) : base(ptr) {}
        public string Text => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public double TimeSeconds { get => GetAt<double>(0x10); set => SetAt(0x10, value); }
    }

    public class EngineServiceTerminate : StructProxy
    {
        public EngineServiceTerminate(System.IntPtr ptr) : base(ptr) {}
        public string UserName => Native.ReadFStringAt(AddrOf(0x0)); // FString
    }

    public class EngineServiceExecuteCommand : StructProxy
    {
        public EngineServiceExecuteCommand(System.IntPtr ptr) : base(ptr) {}
        public string Command => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string UserName => Native.ReadFStringAt(AddrOf(0x10)); // FString
    }

    public class EngineServiceAuthGrant : StructProxy
    {
        public EngineServiceAuthGrant(System.IntPtr ptr) : base(ptr) {}
        public string UserName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string UserToGrant => Native.ReadFStringAt(AddrOf(0x10)); // FString
    }

    public class EngineServiceAuthDeny : StructProxy
    {
        public EngineServiceAuthDeny(System.IntPtr ptr) : base(ptr) {}
        public string UserName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string UserToDeny => Native.ReadFStringAt(AddrOf(0x10)); // FString
    }

    public class EngineServicePong : StructProxy
    {
        public EngineServicePong(System.IntPtr ptr) : base(ptr) {}
        public string CurrentLevel => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public int EngineVersion { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
        public bool HasBegunPlay { get => (GetAt<byte>(0x14) & 0xFF) != 0; set { var __b = GetAt<byte>(0x14); SetAt(0x14, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public Guid InstanceId => new Guid(AddrOf(0x18));
        public string InstanceType => Native.ReadFStringAt(AddrOf(0x28)); // FString
        public Guid SessionId => new Guid(AddrOf(0x38));
        public float WorldTimeSeconds { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
    }

    public class EngineServicePing : StructProxy
    {
        public EngineServicePing(System.IntPtr ptr) : base(ptr) {}
    }

}
