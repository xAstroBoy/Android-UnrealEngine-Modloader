// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/PacketHandler
using System;

namespace UEModLoader.Game
{
    public class HandlerComponentFactory : Object
    {
        public const string UeClassName = "HandlerComponentFactory";
        public HandlerComponentFactory(System.IntPtr ptr) : base(ptr) {}
        public static new HandlerComponentFactory FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new HandlerComponentFactory(p);
        public static HandlerComponentFactory FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new HandlerComponentFactory(o.Pointer); }
        public static HandlerComponentFactory[] All() { var a = UObject.FindAllOf(UeClassName); var r = new HandlerComponentFactory[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new HandlerComponentFactory(a[i].Pointer); return r; }
    }

    public class PacketHandlerProfileConfig : Object
    {
        public const string UeClassName = "PacketHandlerProfileConfig";
        public PacketHandlerProfileConfig(System.IntPtr ptr) : base(ptr) {}
        public static new PacketHandlerProfileConfig FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PacketHandlerProfileConfig(p);
        public static PacketHandlerProfileConfig FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PacketHandlerProfileConfig(o.Pointer); }
        public static PacketHandlerProfileConfig[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PacketHandlerProfileConfig[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PacketHandlerProfileConfig(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Components => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<FString>
    }

}
