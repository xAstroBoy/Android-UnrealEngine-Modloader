// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Ammo
using System;

namespace UEModLoader.Game
{
    public class PropHolster_Ammo_C : Base_PropHolster_C
    {
        public const string UeClassName = "PropHolster_Ammo_C";
        public PropHolster_Ammo_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropHolster_Ammo_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropHolster_Ammo_C(p);
        public static PropHolster_Ammo_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropHolster_Ammo_C(o.Pointer); }
        public static PropHolster_Ammo_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropHolster_Ammo_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropHolster_Ammo_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x440));
        public EHandedness Handedness { get => (EHandedness)GetAt<byte>(0x448); set => SetAt(0x448, (byte)value); }
        public void SnapToPivot(SceneComponent Pivot)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Pivot);
            CallRaw("SnapToPivot", __pb.Bytes);
        }
        public void OnPropsChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnPropsChanged", __pb.Bytes);
        }
        public void SetHandedness(EHandedness Handedness)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Handedness);
            CallRaw("SetHandedness", __pb.Bytes);
        }
        public void UpdatePivot()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdatePivot", __pb.Bytes);
        }
        public void ExecuteUbergraph_PropHolster_Ammo(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PropHolster_Ammo", __pb.Bytes);
        }
    }

}
