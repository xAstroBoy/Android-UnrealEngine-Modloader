// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Menu/VR4MenuHandPoseHelper
using System;

namespace UEModLoader.Game
{
    public class VR4MenuHandPoseHelper_C : ActorComponent
    {
        public const string UeClassName = "VR4MenuHandPoseHelper_C";
        public VR4MenuHandPoseHelper_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4MenuHandPoseHelper_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4MenuHandPoseHelper_C(p);
        public static VR4MenuHandPoseHelper_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4MenuHandPoseHelper_C(o.Pointer); }
        public static VR4MenuHandPoseHelper_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4MenuHandPoseHelper_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4MenuHandPoseHelper_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0xB0));
        public System.IntPtr HandPoses => AddrOf(0xB8); // struct MenuHandPoseSet
        public VR4MenuPlayerHand Hand { get { var __p = GetAt<System.IntPtr>(0xE8); return __p==System.IntPtr.Zero?null:new VR4MenuPlayerHand(__p); } set => SetAt(0xE8, value?.Pointer ?? System.IntPtr.Zero); }
        public TimerHandle InteractablePoseTimer => new TimerHandle(AddrOf(0xF0));
        public EVR4MenuHandPointingState LastPointingState { get => (EVR4MenuHandPointingState)GetAt<byte>(0xF8); set => SetAt(0xF8, (byte)value); }
        public float InteractablePoseHoldDuration { get => GetAt<float>(0xFC); set => SetAt(0xFC, value); }
        public bool HoldingPointingPose { get => Native.GetPropBool(Pointer, "HoldingPointingPose"); set => Native.SetPropBool(Pointer, "HoldingPointingPose", value); }
        public CurveVector ConfirmHandPokeCurve { get { var __p = GetAt<System.IntPtr>(0x108); return __p==System.IntPtr.Zero?null:new CurveVector(__p); } set => SetAt(0x108, value?.Pointer ?? System.IntPtr.Zero); }
        public CurveVector CurrentHandOffsetCurve { get { var __p = GetAt<System.IntPtr>(0x110); return __p==System.IntPtr.Zero?null:new CurveVector(__p); } set => SetAt(0x110, value?.Pointer ?? System.IntPtr.Zero); }
        public float CurrentHandOffsetTime { get => GetAt<float>(0x118); set => SetAt(0x118, value); }
        public VR4DynamicHandPoseComponent StaticHandPoseTarget { get { var __p = GetAt<System.IntPtr>(0x120); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x120, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent AnimatedHandPoseTarget { get { var __p = GetAt<System.IntPtr>(0x128); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x128, value?.Pointer ?? System.IntPtr.Zero); }
        public string StaticHandPose => Native.GetPropName(Pointer, "StaticHandPose"); // FName
        public FName StaticHandPose_Raw { get => GetAt<FName>(0x130); set => SetAt(0x130, value); }
        public bool UseStandardNullGripHandling { get => Native.GetPropBool(Pointer, "UseStandardNullGripHandling"); set => Native.SetPropBool(Pointer, "UseStandardNullGripHandling", value); }
        public bool IsNullGripPressed { get => Native.GetPropBool(Pointer, "IsNullGripPressed"); set => Native.SetPropBool(Pointer, "IsNullGripPressed", value); }
        public void SetNullGripPressed(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("SetNullGripPressed", __pb.Bytes);
        }
        public void PropagateStaticHandPose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PropagateStaticHandPose", __pb.Bytes);
        }
        public void SetAnimatedHandPoseTarget(VR4DynamicHandPoseComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("SetAnimatedHandPoseTarget", __pb.Bytes);
        }
        public void SetStaticHandPose(FName Pose)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Pose);
            CallRaw("SetStaticHandPose", __pb.Bytes);
        }
        public void PlayOneShotHandPoseAnimation(FName PoseAnimation)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, PoseAnimation);
            CallRaw("PlayOneShotHandPoseAnimation", __pb.Bytes);
        }
        public void SetStaticHandPoseTarget(VR4DynamicHandPoseComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("SetStaticHandPoseTarget", __pb.Bytes);
        }
        public void UpdateHandOffset()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateHandOffset", __pb.Bytes);
        }
        public void PlayHandOffsetAnimation(CurveVector AnimCurve)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, AnimCurve);
            CallRaw("PlayHandOffsetAnimation", __pb.Bytes);
        }
        public void IsPointingOverridableState(EVR4MenuHandPointingState HandState, bool Overridable)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)HandState);
            __pb.Set<byte>(0x1, (byte)(Overridable?1:0));
            CallRaw("IsPointingOverridableState", __pb.Bytes);
        }
        public void CheckHoldInteractablePoseTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckHoldInteractablePoseTimer", __pb.Bytes);
        }
        public void StopHoldInteractablePoseTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopHoldInteractablePoseTimer", __pb.Bytes);
        }
        public void StartHoldInteractablePoseTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartHoldInteractablePoseTimer", __pb.Bytes);
        }
        public void UpdateLastPointingState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateLastPointingState", __pb.Bytes);
        }
        public void UpdateStaticHandPose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateStaticHandPose", __pb.Bytes);
        }
        public void ConnectHand()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ConnectHand", __pb.Bytes);
        }
        public void DisconnectHand()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisconnectHand", __pb.Bytes);
        }
        public void SetHand(VR4MenuPlayerHand NewHand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewHand);
            CallRaw("SetHand", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
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
        public void HandleUIObjectClicked()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandleUIObjectClicked", __pb.Bytes);
        }
        public void HandlePointingStateChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandlePointingStateChanged", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4MenuHandPoseHelper(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4MenuHandPoseHelper", __pb.Bytes);
        }
    }

}
