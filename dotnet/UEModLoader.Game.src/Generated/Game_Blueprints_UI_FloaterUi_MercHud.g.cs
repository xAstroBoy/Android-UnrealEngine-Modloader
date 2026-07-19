// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/MercHud
using System;

namespace UEModLoader.Game
{
    public class MercHud_C : Interface
    {
        public const string UeClassName = "MercHud_C";
        public MercHud_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new MercHud_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MercHud_C(p);
        public static MercHud_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MercHud_C(o.Pointer); }
        public static MercHud_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MercHud_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MercHud_C(a[i].Pointer); return r; }
        public void MercUpdateKrauserUIState(EKrauserSuperUIState NewState, bool Callback)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)NewState);
            __pb.Set<byte>(0x1, (byte)(Callback?1:0));
            CallRaw("MercUpdateKrauserUIState", __pb.Bytes);
        }
        public void MercHideItemPromptRight(bool NewText_, global::System.IntPtr Text, bool Callback)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<byte>(0x0, (byte)(NewText_?1:0));
            __pb.Set<global::System.IntPtr>(0x8, Text);
            __pb.Set<byte>(0x18, (byte)(Callback?1:0));
            CallRaw("MercHideItemPromptRight", __pb.Bytes);
        }
        public void MercHideItemPromptLeft(bool NewText_, global::System.IntPtr Text, int TimeIncrease, bool Callback)
        {
            var __pb = new ParamBuffer(29);
            __pb.Set<byte>(0x0, (byte)(NewText_?1:0));
            __pb.Set<global::System.IntPtr>(0x8, Text);
            __pb.Set(0x18, TimeIncrease);
            __pb.Set<byte>(0x1C, (byte)(Callback?1:0));
            CallRaw("MercHideItemPromptLeft", __pb.Bytes);
        }
        public void MercHideItemPrompt(bool ColorChange_, bool NewText_, global::System.IntPtr UpdatedText, bool Callback)
        {
            var __pb = new ParamBuffer(33);
            __pb.Set<byte>(0x0, (byte)(ColorChange_?1:0));
            __pb.Set<byte>(0x1, (byte)(NewText_?1:0));
            __pb.Set<global::System.IntPtr>(0x8, UpdatedText);
            __pb.Set<byte>(0x20, (byte)(Callback?1:0));
            CallRaw("MercHideItemPrompt", __pb.Bytes);
        }
        public void MercDisplayItemPrompt(global::System.IntPtr Prompt, bool Callback)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, Prompt);
            __pb.Set<byte>(0x10, (byte)(Callback?1:0));
            CallRaw("MercDisplayItemPrompt", __pb.Bytes);
        }
    }

}
