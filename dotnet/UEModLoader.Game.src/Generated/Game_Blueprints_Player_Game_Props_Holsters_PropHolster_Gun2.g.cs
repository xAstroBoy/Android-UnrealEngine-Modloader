// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Gun2
using System;

namespace UEModLoader.Game
{
    public class PropHolster_Gun2_C : Base_PropHolster_C
    {
        public const string UeClassName = "PropHolster_Gun2_C";
        public PropHolster_Gun2_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropHolster_Gun2_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropHolster_Gun2_C(p);
        public static PropHolster_Gun2_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropHolster_Gun2_C(o.Pointer); }
        public static PropHolster_Gun2_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropHolster_Gun2_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropHolster_Gun2_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x440));
        public void OnPropsChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnPropsChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_PropHolster_Gun2(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PropHolster_Gun2", __pb.Bytes);
        }
    }

}
