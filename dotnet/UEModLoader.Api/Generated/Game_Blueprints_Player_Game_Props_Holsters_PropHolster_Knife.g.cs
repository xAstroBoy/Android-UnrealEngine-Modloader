// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Knife
using System;

namespace UEModLoader.Game
{
    public class PropHolster_Knife_C : Base_PropHolster_C
    {
        public const string UeClassName = "PropHolster_Knife_C";
        public PropHolster_Knife_C(System.IntPtr ptr) : base(ptr) {}
        public static new PropHolster_Knife_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PropHolster_Knife_C(p);
        public static PropHolster_Knife_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropHolster_Knife_C(o.Pointer); }
        public static PropHolster_Knife_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropHolster_Knife_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropHolster_Knife_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x440));
        public void SetHandedness(EHandedness Handedness)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Handedness);
            CallRaw("SetHandedness", __pb.Bytes);
        }
        public void ExecuteUbergraph_PropHolster_Knife(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PropHolster_Knife", __pb.Bytes);
        }
    }

}
