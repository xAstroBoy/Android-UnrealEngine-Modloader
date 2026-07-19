// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Header_FrontEnd_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Header_FrontEnd_BP_C : UI_PauseMenu_Header_Base_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Header_FrontEnd_BP_C";
        public UI_PauseMenu_Header_FrontEnd_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Header_FrontEnd_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_PauseMenu_Header_FrontEnd_BP_C(p);
        public static UI_PauseMenu_Header_FrontEnd_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Header_FrontEnd_BP_C(o.Pointer); }
        public static UI_PauseMenu_Header_FrontEnd_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Header_FrontEnd_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Header_FrontEnd_BP_C(a[i].Pointer); return r; }
        public ChildActorComponent Button_Credits { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_Options { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_Merc { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_ShootingRange { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_LoadGame { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button_NewGame { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Header_Parent { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public void DisableNewNotificaion(byte Button)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, Button);
            CallRaw("DisableNewNotificaion", __pb.Bytes);
        }
        public void EnableNewNotification(byte Button)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, Button);
            CallRaw("EnableNewNotification", __pb.Bytes);
        }
        public void RestoreAll(EPauseMenuScreen Selected)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Selected);
            CallRaw("RestoreAll", __pb.Bytes);
        }
        public void Hide_All(byte Exclude)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, Exclude);
            CallRaw("Hide All", __pb.Bytes);
        }
    }

}
