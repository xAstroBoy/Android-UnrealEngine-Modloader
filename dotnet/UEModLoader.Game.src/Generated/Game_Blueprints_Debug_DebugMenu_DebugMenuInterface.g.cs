// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMenu/DebugMenuInterface
using System;

namespace UEModLoader.Game
{
    public class DebugMenuInterface_C : Interface
    {
        public const string UeClassName = "DebugMenuInterface_C";
        public DebugMenuInterface_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new DebugMenuInterface_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DebugMenuInterface_C(p);
        public static DebugMenuInterface_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugMenuInterface_C(o.Pointer); }
        public static DebugMenuInterface_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugMenuInterface_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugMenuInterface_C(a[i].Pointer); return r; }
        public void InputActionDoShortcut(bool AX)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(AX?1:0));
            CallRaw("InputActionDoShortcut", __pb.Bytes);
        }
        public void InputActionSetShortcutBY()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InputActionSetShortcutBY", __pb.Bytes);
        }
        public void InputActionSetShortcutAX()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InputActionSetShortcutAX", __pb.Bytes);
        }
        public void InputActionScrollDown(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionScrollDown", __pb.Bytes);
        }
        public void InputActionScrollUp(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionScrollUp", __pb.Bytes);
        }
        public void InputActionBack(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionBack", __pb.Bytes);
        }
        public void InputActionConfirm(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionConfirm", __pb.Bytes);
        }
        public void InputActionFavorite(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("InputActionFavorite", __pb.Bytes);
        }
        public void IsActive(bool Active)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Active?1:0));
            CallRaw("IsActive", __pb.Bytes);
        }
        public void HideDebugMenu(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("HideDebugMenu", __pb.Bytes);
        }
        public void OpenDebugMenu(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("OpenDebugMenu", __pb.Bytes);
        }
    }

}
