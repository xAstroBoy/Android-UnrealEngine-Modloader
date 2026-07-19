// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/NewGamePlusUIScreen_BP
using System;

namespace UEModLoader.Game
{
    public class NewGamePlusUIScreen_BP_C : LoadGameUIScreen_BP_C
    {
        public const string UeClassName = "NewGamePlusUIScreen_BP_C";
        public NewGamePlusUIScreen_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new NewGamePlusUIScreen_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NewGamePlusUIScreen_BP_C(p);
        public static NewGamePlusUIScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NewGamePlusUIScreen_BP_C(o.Pointer); }
        public static NewGamePlusUIScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NewGamePlusUIScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NewGamePlusUIScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x380));
        public void GetSaveSlotInfos(global::System.IntPtr SaveSlotInfos)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, SaveSlotInfos);
            CallRaw("GetSaveSlotInfos", __pb.Bytes);
        }
        public void IsValidSaveGame(global::System.IntPtr SaveSlotInfo, bool Valid)
        {
            var __pb = new ParamBuffer(65);
            __pb.Set<global::System.IntPtr>(0x0, SaveSlotInfo);
            __pb.Set<byte>(0x40, (byte)(Valid?1:0));
            CallRaw("IsValidSaveGame", __pb.Bytes);
        }
        public void SendSaveToLoad()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SendSaveToLoad", __pb.Bytes);
        }
        public void UnselectAllButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnselectAllButtons", __pb.Bytes);
        }
        public void SendNewGameSave()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SendNewGameSave", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_NewGamePlusUIScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_NewGamePlusUIScreen_BP", __pb.Bytes);
        }
    }

}
