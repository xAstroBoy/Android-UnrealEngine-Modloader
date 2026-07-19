// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/Base_PropHolster
using System;

namespace UEModLoader.Game
{
    public class Base_PropHolster_C : VR4GamePlayerPropHolster
    {
        public const string UeClassName = "Base_PropHolster_C";
        public Base_PropHolster_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Base_PropHolster_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Base_PropHolster_C(p);
        public static Base_PropHolster_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Base_PropHolster_C(o.Pointer); }
        public static Base_PropHolster_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Base_PropHolster_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Base_PropHolster_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x430));
        public ActorPreviewComponent ActorPreview { get { var __p = GetAt<global::System.IntPtr>(0x438); return __p==global::System.IntPtr.Zero?null:new ActorPreviewComponent(__p); } set => SetAt(0x438, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void OnTossFlyBack(bool tossExpired, bool manualHolster)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(tossExpired?1:0));
            __pb.Set<byte>(0x1, (byte)(manualHolster?1:0));
            CallRaw("OnTossFlyBack", __pb.Bytes);
        }
        public void OnTossHolsterEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnTossHolsterEnd", __pb.Bytes);
        }
        public void ExecuteUbergraph_Base_PropHolster(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Base_PropHolster", __pb.Bytes);
        }
    }

}
