// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/Frontend
using System;

namespace UEModLoader.Game
{
    public class Frontend_C : Interface
    {
        public const string UeClassName = "Frontend_C";
        public Frontend_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Frontend_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Frontend_C(p);
        public static Frontend_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Frontend_C(o.Pointer); }
        public static Frontend_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Frontend_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Frontend_C(a[i].Pointer); return r; }
        public void FE_SwapFromMercTabMusic(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_SwapFromMercTabMusic", __pb.Bytes);
        }
        public void FE_SwapToMercTabMusic(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_SwapToMercTabMusic", __pb.Bytes);
        }
        public void FE_MercSelectionMade(EBio4PlayerType Character, EMercenariesStage Level, int Mode, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<byte>(0x0, (byte)Character);
            __pb.Set<byte>(0x1, (byte)Level);
            __pb.Set(0x4, Mode);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("FE_MercSelectionMade", __pb.Bytes);
        }
        public void FE_UnloadMerc(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_UnloadMerc", __pb.Bytes);
        }
        public void FE_LoadMerc(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_LoadMerc", __pb.Bytes);
        }
        public void FE_DataReady(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_DataReady", __pb.Bytes);
        }
        public void FE_IntroSelectionMade(bool IntroSelection, int CurrentNewGamePlusSlot, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<byte>(0x0, (byte)(IntroSelection?1:0));
            __pb.Set(0x4, CurrentNewGamePlusSlot);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("FE_IntroSelectionMade", __pb.Bytes);
        }
        public void FE_GameLoaded(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("FE_GameLoaded", __pb.Bytes);
        }
        public void FE_SavesExist_(bool SavesExist)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SavesExist?1:0));
            CallRaw("FE_SavesExist?", __pb.Bytes);
        }
    }

}
