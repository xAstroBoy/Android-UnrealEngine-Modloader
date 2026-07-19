// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Holsters/Base_PropHolster_Icon
using System;

namespace UEModLoader.Game
{
    public class Base_PropHolster_Icon_C : Base_PropHolster_C
    {
        public const string UeClassName = "Base_PropHolster_Icon_C";
        public Base_PropHolster_Icon_C(System.IntPtr ptr) : base(ptr) {}
        public static new Base_PropHolster_Icon_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Base_PropHolster_Icon_C(p);
        public static Base_PropHolster_Icon_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Base_PropHolster_Icon_C(o.Pointer); }
        public static Base_PropHolster_Icon_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Base_PropHolster_Icon_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Base_PropHolster_Icon_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x440));
        public WidgetComponent IconWidget { get { var __p = GetAt<System.IntPtr>(0x448); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x448, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent IconPivotBP { get { var __p = GetAt<System.IntPtr>(0x450); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x450, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent ArcMesh { get { var __p = GetAt<System.IntPtr>(0x458); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x458, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent IconRootBP { get { var __p = GetAt<System.IntPtr>(0x460); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x460, value?.Pointer ?? System.IntPtr.Zero); }
        public bool hovering { get => Native.GetPropBool(Pointer, "hovering"); set => Native.SetPropBool(Pointer, "hovering", value); }
        public int HoverCount { get => GetAt<int>(0x46C); set => SetAt(0x46C, value); }
        public void UpdateScale()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateScale", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void UpdateIconVisibility(bool shouldBeVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(shouldBeVisible?1:0));
            CallRaw("UpdateIconVisibility", __pb.Bytes);
        }
        public void UpdateIconParameters(LinearColor Color, float Scale)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<System.IntPtr>(0x0, Color);
            __pb.Set(0x10, Scale);
            CallRaw("UpdateIconParameters", __pb.Bytes);
        }
        public void OnPropGrabbableChanged(bool grabbable)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(grabbable?1:0));
            CallRaw("OnPropGrabbableChanged", __pb.Bytes);
        }
        public void BndEvt__HolsterGrip_K2Node_ComponentBoundEvent_0_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__HolsterGrip_K2Node_ComponentBoundEvent_0_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__HolsterGrip_K2Node_ComponentBoundEvent_1_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__HolsterGrip_K2Node_ComponentBoundEvent_1_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_Base_PropHolster_Icon(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Base_PropHolster_Icon", __pb.Bytes);
        }
    }

}
