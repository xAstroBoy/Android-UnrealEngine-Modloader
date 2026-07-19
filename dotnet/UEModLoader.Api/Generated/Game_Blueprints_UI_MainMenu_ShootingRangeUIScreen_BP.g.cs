// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/ShootingRangeUIScreen_BP
using System;

namespace UEModLoader.Game
{
    public class ShootingRangeUIScreen_BP_C : LoadGameUIScreen_BP_C
    {
        public const string UeClassName = "ShootingRangeUIScreen_BP_C";
        public ShootingRangeUIScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new ShootingRangeUIScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ShootingRangeUIScreen_BP_C(p);
        public static ShootingRangeUIScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ShootingRangeUIScreen_BP_C(o.Pointer); }
        public static ShootingRangeUIScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ShootingRangeUIScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ShootingRangeUIScreen_BP_C(a[i].Pointer); return r; }
        public void IsValidSaveGame(SaveSlotInfo SaveSlotInfo, bool Valid)
        {
            var __pb = new ParamBuffer(65);
            __pb.Set<System.IntPtr>(0x0, SaveSlotInfo);
            __pb.Set<byte>(0x40, (byte)(Valid?1:0));
            CallRaw("IsValidSaveGame", __pb.Bytes);
        }
        public void SendSaveToLoad()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SendSaveToLoad", __pb.Bytes);
        }
    }

}
