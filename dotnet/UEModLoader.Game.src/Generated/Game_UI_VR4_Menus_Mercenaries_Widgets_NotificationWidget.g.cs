// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/Mercenaries/Widgets/NotificationWidget
using System;

namespace UEModLoader.Game
{
    public class NotificationWidget_C : UserWidget
    {
        public const string UeClassName = "NotificationWidget_C";
        public NotificationWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new NotificationWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NotificationWidget_C(p);
        public static NotificationWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NotificationWidget_C(o.Pointer); }
        public static NotificationWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NotificationWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NotificationWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BG_2 { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x258); // struct UI_WidgetColors_Struct
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_NotificationWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_NotificationWidget", __pb.Bytes);
        }
    }

}
