// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/PlayerProp
using System;

namespace UEModLoader.Game
{
    public class PlayerProp_C : Interface
    {
        public const string UeClassName = "PlayerProp_C";
        public PlayerProp_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlayerProp_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlayerProp_C(p);
        public static PlayerProp_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayerProp_C(o.Pointer); }
        public static PlayerProp_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayerProp_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayerProp_C(a[i].Pointer); return r; }
        public void GetInsertLabelTarget(SceneComponent Target, bool Top)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Target);
            __pb.Set<byte>(0x8, (byte)(Top?1:0));
            CallRaw("GetInsertLabelTarget", __pb.Bytes);
        }
        public void GetFirstEquipName(FName FirstEquipName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, FirstEquipName);
            CallRaw("GetFirstEquipName", __pb.Bytes);
        }
        public void GetAutoEquipName(FName AutoEquipName, EPropSlot Slot)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, AutoEquipName);
            __pb.Set<byte>(0x8, (byte)Slot);
            CallRaw("GetAutoEquipName", __pb.Bytes);
        }
        public void SetOpaqueProp(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("SetOpaqueProp", __pb.Bytes);
        }
        public void SetTranslucentProp(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("SetTranslucentProp", __pb.Bytes);
        }
    }

}
