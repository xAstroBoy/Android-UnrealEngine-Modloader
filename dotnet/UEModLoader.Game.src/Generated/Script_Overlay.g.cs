// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/Overlay
using System;

namespace UEModLoader.Game
{
    public class OverlayItem : StructProxy
    {
        public OverlayItem(global::System.IntPtr ptr) : base(ptr) {}
        public Timespan StartTime => new Timespan(AddrOf(0x0));
        public Timespan EndTime => new Timespan(AddrOf(0x8));
        public string Text => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public Vector2D Position => new Vector2D(AddrOf(0x20));
    }

    public class Overlays : Object
    {
        public const string UeClassName = "Overlays";
        public Overlays(global::System.IntPtr ptr) : base(ptr) {}
        public static new Overlays FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Overlays(p);
        public static Overlays FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Overlays(o.Pointer); }
        public static Overlays[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Overlays[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Overlays(a[i].Pointer); return r; }
    }

    public class BasicOverlays : Overlays
    {
        public const string UeClassName = "BasicOverlays";
        public BasicOverlays(global::System.IntPtr ptr) : base(ptr) {}
        public static new BasicOverlays FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BasicOverlays(p);
        public static BasicOverlays FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BasicOverlays(o.Pointer); }
        public static BasicOverlays[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BasicOverlays[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BasicOverlays(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Overlays => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
    }

    public class LocalizedOverlays : Overlays
    {
        public const string UeClassName = "LocalizedOverlays";
        public LocalizedOverlays(global::System.IntPtr ptr) : base(ptr) {}
        public static new LocalizedOverlays FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LocalizedOverlays(p);
        public static LocalizedOverlays FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LocalizedOverlays(o.Pointer); }
        public static LocalizedOverlays[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LocalizedOverlays[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LocalizedOverlays(a[i].Pointer); return r; }
        public BasicOverlays DefaultOverlays { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new BasicOverlays(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr LocaleToOverlaysMap => AddrOf(0x30); // 
    }

}
