// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/LoadManager
using System;

namespace UEModLoader.Game
{
    public class LoadManager_C : Interface
    {
        public const string UeClassName = "LoadManager_C";
        public LoadManager_C(System.IntPtr ptr) : base(ptr) {}
        public static new LoadManager_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new LoadManager_C(p);
        public static LoadManager_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LoadManager_C(o.Pointer); }
        public static LoadManager_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LoadManager_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LoadManager_C(a[i].Pointer); return r; }
        public void LM_DoSavesExist(bool SavesExist)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SavesExist?1:0));
            CallRaw("LM_DoSavesExist", __pb.Bytes);
        }
        public void LM_GetSlotInfo(System.IntPtr SaveSlotInfo)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, SaveSlotInfo);
            CallRaw("LM_GetSlotInfo", __pb.Bytes);
        }
        public void LM_NotifySlotSelected(int saveSlot, bool isClearSaveSlot, bool Callback)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set(0x0, saveSlot);
            __pb.Set<byte>(0x4, (byte)(isClearSaveSlot?1:0));
            __pb.Set<byte>(0x5, (byte)(Callback?1:0));
            CallRaw("LM_NotifySlotSelected", __pb.Bytes);
        }
        public void LM_NotifyCancel(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("LM_NotifyCancel", __pb.Bytes);
        }
        public void LM_DataReady_(bool Ready)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Ready?1:0));
            CallRaw("LM_DataReady?", __pb.Bytes);
        }
    }

}
