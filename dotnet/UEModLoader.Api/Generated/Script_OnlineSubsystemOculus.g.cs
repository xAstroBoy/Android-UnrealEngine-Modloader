// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/OnlineSubsystemOculus
using System;

namespace UEModLoader.Game
{
    public class OculusCreateSessionCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "OculusCreateSessionCallbackProxy";
        public OculusCreateSessionCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new OculusCreateSessionCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusCreateSessionCallbackProxy(p);
        public static OculusCreateSessionCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusCreateSessionCallbackProxy(o.Pointer); }
        public static OculusCreateSessionCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusCreateSessionCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusCreateSessionCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x555717C — hookable via Hooks.InstallAt(NativeFunc_CreateSession).</summary>
        public static System.IntPtr NativeFunc_CreateSession => Memory.ModuleBase() + 0x555717C;
        public OculusCreateSessionCallbackProxy CreateSession(int PublicConnections, System.IntPtr OculusMatchmakingPool)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set(0x0, PublicConnections);
            __pb.Set<System.IntPtr>(0x8, OculusMatchmakingPool);
            CallRaw("CreateSession", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new OculusCreateSessionCallbackProxy(__p); }
        }
    }

    public class OculusEntitlementCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "OculusEntitlementCallbackProxy";
        public OculusEntitlementCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new OculusEntitlementCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusEntitlementCallbackProxy(p);
        public static OculusEntitlementCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusEntitlementCallbackProxy(o.Pointer); }
        public static OculusEntitlementCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusEntitlementCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusEntitlementCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x5557C70 — hookable via Hooks.InstallAt(NativeFunc_VerifyEntitlement).</summary>
        public static System.IntPtr NativeFunc_VerifyEntitlement => Memory.ModuleBase() + 0x5557C70;
        public OculusEntitlementCallbackProxy VerifyEntitlement()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("VerifyEntitlement", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new OculusEntitlementCallbackProxy(__p); }
        }
    }

    public class OculusFindSessionsCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "OculusFindSessionsCallbackProxy";
        public OculusFindSessionsCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new OculusFindSessionsCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusFindSessionsCallbackProxy(p);
        public static OculusFindSessionsCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusFindSessionsCallbackProxy(o.Pointer); }
        public static OculusFindSessionsCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusFindSessionsCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusFindSessionsCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x55585EC — hookable via Hooks.InstallAt(NativeFunc_FindModeratedSessions).</summary>
        public static System.IntPtr NativeFunc_FindModeratedSessions => Memory.ModuleBase() + 0x55585EC;
        public OculusFindSessionsCallbackProxy FindModeratedSessions(int MaxResults)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, MaxResults);
            CallRaw("FindModeratedSessions", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new OculusFindSessionsCallbackProxy(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5558690 — hookable via Hooks.InstallAt(NativeFunc_FindMatchmakingSessions).</summary>
        public static System.IntPtr NativeFunc_FindMatchmakingSessions => Memory.ModuleBase() + 0x5558690;
        public OculusFindSessionsCallbackProxy FindMatchmakingSessions(int MaxResults, System.IntPtr OculusMatchmakingPool)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set(0x0, MaxResults);
            __pb.Set<System.IntPtr>(0x8, OculusMatchmakingPool);
            CallRaw("FindMatchmakingSessions", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new OculusFindSessionsCallbackProxy(__p); }
        }
    }

    public class OculusIdentityCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "OculusIdentityCallbackProxy";
        public OculusIdentityCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new OculusIdentityCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusIdentityCallbackProxy(p);
        public static OculusIdentityCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusIdentityCallbackProxy(o.Pointer); }
        public static OculusIdentityCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusIdentityCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusIdentityCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x5559214 — hookable via Hooks.InstallAt(NativeFunc_GetOculusIdentity).</summary>
        public static System.IntPtr NativeFunc_GetOculusIdentity => Memory.ModuleBase() + 0x5559214;
        public OculusIdentityCallbackProxy GetOculusIdentity(int LocalUserNum)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, LocalUserNum);
            CallRaw("GetOculusIdentity", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new OculusIdentityCallbackProxy(__p); }
        }
    }

    public class OculusNetConnection : IpConnection
    {
        public const string UeClassName = "OculusNetConnection";
        public OculusNetConnection(System.IntPtr ptr) : base(ptr) {}
        public static new OculusNetConnection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusNetConnection(p);
        public static OculusNetConnection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusNetConnection(o.Pointer); }
        public static OculusNetConnection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusNetConnection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusNetConnection(a[i].Pointer); return r; }
    }

    public class OculusNetDriver : IpNetDriver
    {
        public const string UeClassName = "OculusNetDriver";
        public OculusNetDriver(System.IntPtr ptr) : base(ptr) {}
        public static new OculusNetDriver FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusNetDriver(p);
        public static OculusNetDriver FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusNetDriver(o.Pointer); }
        public static OculusNetDriver[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusNetDriver[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusNetDriver(a[i].Pointer); return r; }
    }

    public class OculusUpdateSessionCallbackProxy : OnlineBlueprintCallProxyBase
    {
        public const string UeClassName = "OculusUpdateSessionCallbackProxy";
        public OculusUpdateSessionCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new OculusUpdateSessionCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OculusUpdateSessionCallbackProxy(p);
        public static OculusUpdateSessionCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OculusUpdateSessionCallbackProxy(o.Pointer); }
        public static OculusUpdateSessionCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OculusUpdateSessionCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OculusUpdateSessionCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFailure => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x555ABCC — hookable via Hooks.InstallAt(NativeFunc_SetSessionEnqueue).</summary>
        public static System.IntPtr NativeFunc_SetSessionEnqueue => Memory.ModuleBase() + 0x555ABCC;
        public OculusUpdateSessionCallbackProxy SetSessionEnqueue(bool bShouldEnqueueInMatchmakingPool)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<byte>(0x0, (byte)(bShouldEnqueueInMatchmakingPool?1:0));
            CallRaw("SetSessionEnqueue", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new OculusUpdateSessionCallbackProxy(__p); }
        }
    }

}
