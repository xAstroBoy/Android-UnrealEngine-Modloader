// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Menu/VR4MenuHand_Base_BP
using System;

namespace UEModLoader.Game
{
    public class VR4MenuHand_Base_BP_C : VR4MenuPlayerHand
    {
        public const string UeClassName = "VR4MenuHand_Base_BP_C";
        public VR4MenuHand_Base_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4MenuHand_Base_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4MenuHand_Base_BP_C(p);
        public static VR4MenuHand_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4MenuHand_Base_BP_C(o.Pointer); }
        public static VR4MenuHand_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4MenuHand_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4MenuHand_Base_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x580));
        public VR4DynamicHandPoseComponent AnimatedHandPose { get { var __p = GetAt<System.IntPtr>(0x588); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x588, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent StaticHandPose { get { var __p = GetAt<System.IntPtr>(0x590); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x590, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4PriorityListHandPoseSourceComponent MainHandPose { get { var __p = GetAt<System.IntPtr>(0x598); return __p==System.IntPtr.Zero?null:new VR4PriorityListHandPoseSourceComponent(__p); } set => SetAt(0x598, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4MenuHandPoseHelper_C HandPoseHelper { get { var __p = GetAt<System.IntPtr>(0x5A0); return __p==System.IntPtr.Zero?null:new VR4MenuHandPoseHelper_C(__p); } set => SetAt(0x5A0, value?.Pointer ?? System.IntPtr.Zero); }
        public string FingerLaserSocketName => Native.GetPropName(Pointer, "FingerLaserSocketName"); // FName
        public FName FingerLaserSocketName_Raw { get => GetAt<FName>(0x5A8); set => SetAt(0x5A8, value); }
        public void InitHandPoses()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitHandPoses", __pb.Bytes);
        }
        public void InitLaserTransform()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitLaserTransform", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnHandPointingStateChanged(EVR4MenuHandPointingState OldState, EVR4MenuHandPointingState NewState)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)OldState);
            __pb.Set<byte>(0x1, (byte)NewState);
            CallRaw("OnHandPointingStateChanged", __pb.Bytes);
        }
        public void OnUIObjectClicked(VR4UIObject Object)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Object);
            CallRaw("OnUIObjectClicked", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4MenuHand_Base_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4MenuHand_Base_BP", __pb.Bytes);
        }
    }

}
