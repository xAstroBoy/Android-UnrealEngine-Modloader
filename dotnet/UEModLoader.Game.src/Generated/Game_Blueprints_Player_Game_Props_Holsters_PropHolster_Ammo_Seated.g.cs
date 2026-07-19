// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Ammo_Seated
using System;

namespace UEModLoader.Game
{
    public class PropHolster_Ammo_Seated_C : Base_PropHolster_Icon_C
    {
        public const string UeClassName = "PropHolster_Ammo_Seated_C";
        public PropHolster_Ammo_Seated_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropHolster_Ammo_Seated_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropHolster_Ammo_Seated_C(p);
        public static PropHolster_Ammo_Seated_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropHolster_Ammo_Seated_C(o.Pointer); }
        public static PropHolster_Ammo_Seated_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropHolster_Ammo_Seated_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropHolster_Ammo_Seated_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x470));
        public StaticMeshComponent ArcMeshL3 { get { var __p = GetAt<global::System.IntPtr>(0x478); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x478, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshL2 { get { var __p = GetAt<global::System.IntPtr>(0x480); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x480, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshL1 { get { var __p = GetAt<global::System.IntPtr>(0x488); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x488, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshR3 { get { var __p = GetAt<global::System.IntPtr>(0x490); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x490, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshR2 { get { var __p = GetAt<global::System.IntPtr>(0x498); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x498, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshR1 { get { var __p = GetAt<global::System.IntPtr>(0x4A0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x4A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool AmmoAvailable { get => Native.GetPropBool(Pointer, "AmmoAvailable"); set => Native.SetPropBool(Pointer, "AmmoAvailable", value); }
        public UI_SeatedIcon_Ammo_Widget_C AmmoIconWidget { get { var __p = GetAt<global::System.IntPtr>(0x4B0); return __p==global::System.IntPtr.Zero?null:new UI_SeatedIcon_Ammo_Widget_C(__p); } set => SetAt(0x4B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsBowEquipped()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsBowEquipped", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void UpdateVisibility_Internal(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("UpdateVisibility_Internal", __pb.Bytes);
        }
        public void AmmoPropUpdate(bool GunHeld, bool AmmoAvailable)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(GunHeld?1:0));
            __pb.Set<byte>(0x1, (byte)(AmmoAvailable?1:0));
            CallRaw("AmmoPropUpdate", __pb.Bytes);
        }
        public void SetHandedness(EHandedness Handedness)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Handedness);
            CallRaw("SetHandedness", __pb.Bytes);
        }
        public void UpdateIconVisibility(bool shouldBeVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(shouldBeVisible?1:0));
            CallRaw("UpdateIconVisibility", __pb.Bytes);
        }
        public void ExecuteUbergraph_PropHolster_Ammo_Seated(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PropHolster_Ammo_Seated", __pb.Bytes);
        }
    }

}
