// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Gun1_Seated_WW
using System;

namespace UEModLoader.Game
{
    public class PropHolster_Gun1_Seated_WW_C : Base_PropHolster_Icon_C
    {
        public const string UeClassName = "PropHolster_Gun1_Seated_WW_C";
        public PropHolster_Gun1_Seated_WW_C(System.IntPtr ptr) : base(ptr) {}
        public static new PropHolster_Gun1_Seated_WW_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PropHolster_Gun1_Seated_WW_C(p);
        public static PropHolster_Gun1_Seated_WW_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropHolster_Gun1_Seated_WW_C(o.Pointer); }
        public static PropHolster_Gun1_Seated_WW_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropHolster_Gun1_Seated_WW_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropHolster_Gun1_Seated_WW_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x470));
        public StaticMeshComponent ArcMeshL3 { get { var __p = GetAt<System.IntPtr>(0x478); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x478, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshL2 { get { var __p = GetAt<System.IntPtr>(0x480); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x480, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshL1 { get { var __p = GetAt<System.IntPtr>(0x488); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x488, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshR3 { get { var __p = GetAt<System.IntPtr>(0x490); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x490, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshR2 { get { var __p = GetAt<System.IntPtr>(0x498); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x498, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent ArcMeshR1 { get { var __p = GetAt<System.IntPtr>(0x4A0); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x4A0, value?.Pointer ?? System.IntPtr.Zero); }
        public void UpdateVisibility_Internal(bool Visibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visibility?1:0));
            CallRaw("UpdateVisibility_Internal", __pb.Bytes);
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
        public void ExecuteUbergraph_PropHolster_Gun1_Seated_WW(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PropHolster_Gun1_Seated_WW", __pb.Bytes);
        }
    }

}
