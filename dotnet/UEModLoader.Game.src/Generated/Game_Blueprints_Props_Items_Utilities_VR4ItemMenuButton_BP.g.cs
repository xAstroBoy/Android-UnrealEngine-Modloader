// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Props/Items/Utilities/VR4ItemMenuButton_BP
using System;

namespace UEModLoader.Game
{
    public class VR4ItemMenuButton_BP_C : VR4ItemMenuButton
    {
        public const string UeClassName = "VR4ItemMenuButton_BP_C";
        public VR4ItemMenuButton_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4ItemMenuButton_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4ItemMenuButton_BP_C(p);
        public static VR4ItemMenuButton_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4ItemMenuButton_BP_C(o.Pointer); }
        public static VR4ItemMenuButton_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4ItemMenuButton_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4ItemMenuButton_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x240));
        public BoxComponent Box { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGripIndicator VR4GamePlayerGripIndicator { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGripIndicator(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGrip VR4GamePlayerGrip { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGrip(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GrabbableComponent VR4Grabbable { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new VR4GrabbableComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_0_NewTrack_0_4FECF8644AD2609F8D4E3D9A01E4A98A { get => GetAt<float>(0x270); set => SetAt(0x270, value); }
        public byte Timeline_0__Direction_4FECF8644AD2609F8D4E3D9A01E4A98A { get => GetAt<byte>(0x274); set => SetAt(0x274, value); }
        public TimelineComponent Timeline { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float NewVar { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public global::System.IntPtr OnShrunk => AddrOf(0x288); // 
        public float NormalSize { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public float HoverSize { get => GetAt<float>(0x29C); set => SetAt(0x29C, value); }
        public void Timeline_0__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_0__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_0__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_0__UpdateFunc", __pb.Bytes);
        }
        public void BndEvt__VR4GamePlayerGrip_K2Node_ComponentBoundEvent_0_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__VR4GamePlayerGrip_K2Node_ComponentBoundEvent_0_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4GamePlayerGrip_K2Node_ComponentBoundEvent_1_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__VR4GamePlayerGrip_K2Node_ComponentBoundEvent_1_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4GamePlayerGrip_K2Node_ComponentBoundEvent_2_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__VR4GamePlayerGrip_K2Node_ComponentBoundEvent_2_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void Grow(float Delay)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Delay);
            CallRaw("Grow", __pb.Bytes);
        }
        public void Shrink(float Delay)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Delay);
            CallRaw("Shrink", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4ItemMenuButton_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4ItemMenuButton_BP", __pb.Bytes);
        }
        public void OnShrunk__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnShrunk__DelegateSignature", __pb.Bytes);
        }
    }

}
