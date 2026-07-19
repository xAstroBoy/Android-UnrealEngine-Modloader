// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/PauseMenu
using System;

namespace UEModLoader.Game
{
    public class PauseMenu_C : Interface
    {
        public const string UeClassName = "PauseMenu_C";
        public PauseMenu_C(System.IntPtr ptr) : base(ptr) {}
        public static new PauseMenu_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PauseMenu_C(p);
        public static PauseMenu_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PauseMenu_C(o.Pointer); }
        public static PauseMenu_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PauseMenu_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PauseMenu_C(a[i].Pointer); return r; }
        public void PM_NotifyClosing(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_NotifyClosing", __pb.Bytes);
        }
        public void PM_SetTitleText(System.IntPtr TitleText, bool ShowButton, bool Callback)
        {
            var __pb = new ParamBuffer(26);
            __pb.Set<System.IntPtr>(0x0, TitleText);
            __pb.Set<byte>(0x18, (byte)(ShowButton?1:0));
            __pb.Set<byte>(0x19, (byte)(Callback?1:0));
            CallRaw("PM_SetTitleText", __pb.Bytes);
        }
        public void PM_SetLinkTransition(FName LinkTransition, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, LinkTransition);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("PM_SetLinkTransition", __pb.Bytes);
        }
        public void PM_GetLinkTransition(FName LinkTransition)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, LinkTransition);
            CallRaw("PM_GetLinkTransition", __pb.Bytes);
        }
        public void PM_LoadGame(int saveSlot, bool Callback)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, saveSlot);
            __pb.Set<byte>(0x4, (byte)(Callback?1:0));
            CallRaw("PM_LoadGame", __pb.Bytes);
        }
        public void PM_GetLoadGameManager(TypewriterManager_Load_BP_C LoadGameManager)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, LoadGameManager);
            CallRaw("PM_GetLoadGameManager", __pb.Bytes);
        }
        public void PM_GetMenuType(bool InGame, bool Mercenaries)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(InGame?1:0));
            __pb.Set<byte>(0x1, (byte)(Mercenaries?1:0));
            CallRaw("PM_GetMenuType", __pb.Bytes);
        }
        public void PM_PopToUIScreen(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_PopToUIScreen", __pb.Bytes);
        }
        public void PM_SetMenuSwapping(bool MenuSwapping, bool Callback)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(MenuSwapping?1:0));
            __pb.Set<byte>(0x1, (byte)(Callback?1:0));
            CallRaw("PM_SetMenuSwapping", __pb.Bytes);
        }
        public void PM_SubActionEventStart(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_SubActionEventStart", __pb.Bytes);
        }
        public void PM_ContentExitDone(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_ContentExitDone", __pb.Bytes);
        }
        public void PM_ContentEnterDone(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("PM_ContentEnterDone", __pb.Bytes);
        }
    }

}
