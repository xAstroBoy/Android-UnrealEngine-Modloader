// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Bio4/VR4Bio4PlayerHand_BP
using System;

namespace UEModLoader.Game
{
    public class VR4Bio4PlayerHand_BP_C : VR4Bio4PlayerHand
    {
        public const string UeClassName = "VR4Bio4PlayerHand_BP_C";
        public VR4Bio4PlayerHand_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4Bio4PlayerHand_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4Bio4PlayerHand_BP_C(p);
        public static VR4Bio4PlayerHand_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4Bio4PlayerHand_BP_C(o.Pointer); }
        public static VR4Bio4PlayerHand_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4Bio4PlayerHand_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4Bio4PlayerHand_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x530));
        public VR4DynamicHandPoseComponent NullGripHandPose { get { var __p = GetAt<global::System.IntPtr>(0x538); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x538, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent HandProxy { get { var __p = GetAt<global::System.IntPtr>(0x540); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x540, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SkeletalMeshComponent Gun { get { var __p = GetAt<global::System.IntPtr>(0x548); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x548, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent SpaceFix { get { var __p = GetAt<global::System.IntPtr>(0x550); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x550, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Controller { get { var __p = GetAt<global::System.IntPtr>(0x558); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x558, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EVR4GamePlayerAnimInstanceHandPosePriority NullGripHandPosePriority { get => (EVR4GamePlayerAnimInstanceHandPosePriority)GetAt<byte>(0x560); set => SetAt(0x560, (byte)value); }
        public TArray<global::System.IntPtr> NullGripClosingOrigins_LH => new TArray<global::System.IntPtr>(AddrOf(0x568)); // TArray<FName>
        public TArray<global::System.IntPtr> NullGripClosingOrigins_RH => new TArray<global::System.IntPtr>(AddrOf(0x578)); // TArray<FName>
        public TArray<global::System.IntPtr> NullGripOpeningOrigins_LH => new TArray<global::System.IntPtr>(AddrOf(0x588)); // TArray<FName>
        public TArray<global::System.IntPtr> NullGripOpeningOrigins_RH => new TArray<global::System.IntPtr>(AddrOf(0x598)); // TArray<FName>
        public void WorldDilationChanged(float WorldTimeDilation, float PlayerTimeDilation, float CustomTimeDilation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, WorldTimeDilation);
            __pb.Set(0x4, PlayerTimeDilation);
            __pb.Set(0x8, CustomTimeDilation);
            CallRaw("WorldDilationChanged", __pb.Bytes);
        }
        public void IsHandPosePriorityEmpty(EVR4GamePlayerAnimInstanceHandPosePriority Priority, bool Result)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Priority);
            __pb.Set<byte>(0x1, (byte)(Result?1:0));
            CallRaw("IsHandPosePriorityEmpty", __pb.Bytes);
        }
        public void RemoveNullGripHandPose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RemoveNullGripHandPose", __pb.Bytes);
        }
        public void ApplyNullGripHandPose(EVR4GamePlayerHandInputCause Selection)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Selection);
            CallRaw("ApplyNullGripHandPose", __pb.Bytes);
        }
        public void InitializeNullGripHandPose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeNullGripHandPose", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void HandleNullGripPressed(VR4GamePlayerHand Source, EVR4GamePlayerHandInputCause Cause)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Source);
            __pb.Set<byte>(0x8, (byte)Cause);
            CallRaw("HandleNullGripPressed", __pb.Bytes);
        }
        public void HandleNullGripReleased(VR4GamePlayerHand Source, EVR4GamePlayerHandInputCause Cause)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Source);
            __pb.Set<byte>(0x8, (byte)Cause);
            CallRaw("HandleNullGripReleased", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4Bio4PlayerHand_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4Bio4PlayerHand_BP", __pb.Bytes);
        }
    }

}
