// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Levels/Lobby
using System;

namespace UEModLoader.Game
{
    public class Lobby_C : LevelScriptActor
    {
        public const string UeClassName = "Lobby_C";
        public Lobby_C(System.IntPtr ptr) : base(ptr) {}
        public static new Lobby_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Lobby_C(p);
        public static Lobby_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Lobby_C(o.Pointer); }
        public static Lobby_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Lobby_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Lobby_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x228));
        public LinearColor LinearBlack => new LinearColor(AddrOf(0x230));
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_Lobby(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Lobby", __pb.Bytes);
        }
    }

}
