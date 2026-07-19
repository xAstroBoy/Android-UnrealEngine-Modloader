// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/NetCore
using System;

namespace UEModLoader.Game
{
    public class NetAnalyticsDataConfig : StructProxy
    {
        public NetAnalyticsDataConfig(global::System.IntPtr ptr) : base(ptr) {}
        public string DataName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName DataName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public bool bEnabled { get => (GetAt<byte>(0x8) & 0xFF) != 0; set { var __b = GetAt<byte>(0x8); SetAt(0x8, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class NetAnalyticsAggregatorConfig : Object
    {
        public const string UeClassName = "NetAnalyticsAggregatorConfig";
        public NetAnalyticsAggregatorConfig(global::System.IntPtr ptr) : base(ptr) {}
        public static new NetAnalyticsAggregatorConfig FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NetAnalyticsAggregatorConfig(p);
        public static NetAnalyticsAggregatorConfig FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NetAnalyticsAggregatorConfig(o.Pointer); }
        public static NetAnalyticsAggregatorConfig[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NetAnalyticsAggregatorConfig[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NetAnalyticsAggregatorConfig(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> NetAnalyticsData => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
    }

}
