// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/GunHandPoseHelper
using System;

namespace UEModLoader.Game
{
    public class GunHandPoseHelper_C : ActorComponent
    {
        public const string UeClassName = "GunHandPoseHelper_C";
        public GunHandPoseHelper_C(System.IntPtr ptr) : base(ptr) {}
        public static new GunHandPoseHelper_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GunHandPoseHelper_C(p);
        public static GunHandPoseHelper_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GunHandPoseHelper_C(o.Pointer); }
        public static GunHandPoseHelper_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GunHandPoseHelper_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GunHandPoseHelper_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0xB0));
        public bool ForcedTriggerDiscipline { get => Native.GetPropBool(Pointer, "ForcedTriggerDiscipline"); set => Native.SetPropBool(Pointer, "ForcedTriggerDiscipline", value); }
        public VR4HandPosePair HandPoses_PrimaryGrip_Normal => new VR4HandPosePair(AddrOf(0xBC));
        public VR4HandPosePair HandPoses_PrimaryGrip_TriggerDiscipline => new VR4HandPosePair(AddrOf(0xCC));
        public VR4DynamicHandPoseComponent HandPoseObject_PrimaryGripGrabbedStatic { get { var __p = GetAt<System.IntPtr>(0xE0); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0xE0, value?.Pointer ?? System.IntPtr.Zero); }
        public string Tag_HandPoseObject_PrimaryGripGrabbedStatic => Native.GetPropName(Pointer, "Tag_HandPoseObject_PrimaryGripGrabbedStatic"); // FName
        public FName Tag_HandPoseObject_PrimaryGripGrabbedStatic_Raw { get => GetAt<FName>(0xE8); set => SetAt(0xE8, value); }
        public VR4GamePlayerGun OwningGun { get { var __p = GetAt<System.IntPtr>(0xF0); return __p==System.IntPtr.Zero?null:new VR4GamePlayerGun(__p); } set => SetAt(0xF0, value?.Pointer ?? System.IntPtr.Zero); }
        public string Tag_HandPoseObject_PrimaryGripGrabbedAnim => Native.GetPropName(Pointer, "Tag_HandPoseObject_PrimaryGripGrabbedAnim"); // FName
        public FName Tag_HandPoseObject_PrimaryGripGrabbedAnim_Raw { get => GetAt<FName>(0xF8); set => SetAt(0xF8, value); }
        public VR4DynamicHandPoseComponent HandPoseObject_PrimaryGripGrabbedAnim { get { var __p = GetAt<System.IntPtr>(0x100); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x100, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4HandPosePair HandPoses_PrimaryGrip_PullTrigger => new VR4HandPosePair(AddrOf(0x108));
        public bool TriggerPulled { get => Native.GetPropBool(Pointer, "TriggerPulled"); set => Native.SetPropBool(Pointer, "TriggerPulled", value); }
        public void SetHandPoses(VR4HandPosePair Normal, VR4HandPosePair TriggerDiscipline, VR4HandPosePair PullTrigger)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, Normal);
            __pb.Set<System.IntPtr>(0x10, TriggerDiscipline);
            __pb.Set<System.IntPtr>(0x20, PullTrigger);
            CallRaw("SetHandPoses", __pb.Bytes);
        }
        public void PlayPrimaryGripHandPoseAnimation(VR4HandPosePair HandPoses)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, HandPoses);
            CallRaw("PlayPrimaryGripHandPoseAnimation", __pb.Bytes);
        }
        public void SetPrimaryGripGrabbedAnimHandPoseObject(VR4DynamicHandPoseComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("SetPrimaryGripGrabbedAnimHandPoseObject", __pb.Bytes);
        }
        public void GetSingleComponentByTag(Actor Actor, ActorComponent ComponentClass, FName Tag, ActorComponent Object)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, Actor);
            __pb.SetObject(0x8, ComponentClass);
            __pb.Set(0x10, Tag);
            __pb.SetObject(0x18, Object);
            CallRaw("GetSingleComponentByTag", __pb.Bytes);
        }
        public void SetPrimaryGripGrabbedStaticHandPoseObject(VR4DynamicHandPoseComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("SetPrimaryGripGrabbedStaticHandPoseObject", __pb.Bytes);
        }
        public void UpdatePrimaryGripHandPose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdatePrimaryGripHandPose", __pb.Bytes);
        }
        public bool ShouldShowTriggerDiscipline()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("ShouldShowTriggerDiscipline", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void SetForceTriggerDiscipline(bool Forced)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Forced?1:0));
            CallRaw("SetForceTriggerDiscipline", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void HandleReadyToFireChanged(VR4GamePlayerGun Source)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Source);
            CallRaw("HandleReadyToFireChanged", __pb.Bytes);
        }
        public void HandleFiringBlockedChanged(VR4GamePlayerGun Source)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Source);
            CallRaw("HandleFiringBlockedChanged", __pb.Bytes);
        }
        public void HandleFired(VR4GamePlayerGun Source)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Source);
            CallRaw("HandleFired", __pb.Bytes);
        }
        public void HandleDryFire(VR4GamePlayerGun Source)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Source);
            CallRaw("HandleDryFire", __pb.Bytes);
        }
        public void HandleTriggerPulled(VR4GamePlayerGun Source)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Source);
            CallRaw("HandleTriggerPulled", __pb.Bytes);
        }
        public void HandleTriggerReleased(VR4GamePlayerGun Source)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Source);
            CallRaw("HandleTriggerReleased", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_GunHandPoseHelper(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_GunHandPoseHelper", __pb.Bytes);
        }
    }

}
