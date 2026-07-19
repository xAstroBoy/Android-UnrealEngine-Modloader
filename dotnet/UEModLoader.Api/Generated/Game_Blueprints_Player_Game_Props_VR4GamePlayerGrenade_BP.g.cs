// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/VR4GamePlayerGrenade_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayerGrenade_BP_C : VR4GamePlayerGrenade
    {
        public const string UeClassName = "VR4GamePlayerGrenade_BP_C";
        public VR4GamePlayerGrenade_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayerGrenade_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4GamePlayerGrenade_BP_C(p);
        public static VR4GamePlayerGrenade_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayerGrenade_BP_C(o.Pointer); }
        public static VR4GamePlayerGrenade_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayerGrenade_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayerGrenade_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x640));
        public AudioComponent SFX_Grenade { get { var __p = GetAt<System.IntPtr>(0x648); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x648, value?.Pointer ?? System.IntPtr.Zero); }
        public SplineComponent LureArc { get { var __p = GetAt<System.IntPtr>(0x650); return __p==System.IntPtr.Zero?null:new SplineComponent(__p); } set => SetAt(0x650, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent LureHead { get { var __p = GetAt<System.IntPtr>(0x658); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x658, value?.Pointer ?? System.IntPtr.Zero); }
        public SocketForwardingSceneComponent PrimaryGripContainer { get { var __p = GetAt<System.IntPtr>(0x660); return __p==System.IntPtr.Zero?null:new SocketForwardingSceneComponent(__p); } set => SetAt(0x660, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent Indicator { get { var __p = GetAt<System.IntPtr>(0x668); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x668, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent PrimaryGripFreeHandPose { get { var __p = GetAt<System.IntPtr>(0x670); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x670, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent PrimaryGripGrabbedHandPose { get { var __p = GetAt<System.IntPtr>(0x678); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x678, value?.Pointer ?? System.IntPtr.Zero); }
        public GenericLocator PrimaryGripControllerLocatorRight { get { var __p = GetAt<System.IntPtr>(0x680); return __p==System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x680, value?.Pointer ?? System.IntPtr.Zero); }
        public GenericLocator PrimaryGripControllerLocatorLeft { get { var __p = GetAt<System.IntPtr>(0x688); return __p==System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x688, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget PrimaryGripIKTarget { get { var __p = GetAt<System.IntPtr>(0x690); return __p==System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x690, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4GamePlayerGripIndicator PrimaryGripIndicator_New { get { var __p = GetAt<System.IntPtr>(0x698); return __p==System.IntPtr.Zero?null:new VR4GamePlayerGripIndicator(__p); } set => SetAt(0x698, value?.Pointer ?? System.IntPtr.Zero); }
        public BoxComponent PrimaryGripBox_New { get { var __p = GetAt<System.IntPtr>(0x6A0); return __p==System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x6A0, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent SkeletalPin { get { var __p = GetAt<System.IntPtr>(0x6A8); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x6A8, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget PinGripIKTarget { get { var __p = GetAt<System.IntPtr>(0x6B0); return __p==System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x6B0, value?.Pointer ?? System.IntPtr.Zero); }
        public PoseableMeshComponent HiddenGrenadePlacementOnly { get { var __p = GetAt<System.IntPtr>(0x6B8); return __p==System.IntPtr.Zero?null:new PoseableMeshComponent(__p); } set => SetAt(0x6B8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent TinySphere { get { var __p = GetAt<System.IntPtr>(0x6C0); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x6C0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool HasFirstAssign { get => Native.GetPropBool(Pointer, "HasFirstAssign"); set => Native.SetPropBool(Pointer, "HasFirstAssign", value); }
        public float multiGrenadeDelay { get => GetAt<float>(0x6CC); set => SetAt(0x6CC, value); }
        public MaterialInterface StoredMaterial { get { var __p = GetAt<System.IntPtr>(0x6D0); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x6D0, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4Model TranslucentActor { get { var __p = GetAt<System.IntPtr>(0x6D8); return __p==System.IntPtr.Zero?null:new VR4Model(__p); } set => SetAt(0x6D8, value?.Pointer ?? System.IntPtr.Zero); }
        public string TutorialGrenade => Native.GetPropName(Pointer, "TutorialGrenade"); // FName
        public FName TutorialGrenade_Raw { get => GetAt<FName>(0x6E0); set => SetAt(0x6E0, value); }
        public string TutorialIncendiary => Native.GetPropName(Pointer, "TutorialIncendiary"); // FName
        public FName TutorialIncendiary_Raw { get => GetAt<FName>(0x6E8); set => SetAt(0x6E8, value); }
        public string TutorialFlash => Native.GetPropName(Pointer, "TutorialFlash"); // FName
        public FName TutorialFlash_Raw { get => GetAt<FName>(0x6F0); set => SetAt(0x6F0, value); }
        public string TutorialEgg => Native.GetPropName(Pointer, "TutorialEgg"); // FName
        public FName TutorialEgg_Raw { get => GetAt<FName>(0x6F8); set => SetAt(0x6F8, value); }
        public VR4HandPosePair HandPoses_Hold => new VR4HandPosePair(AddrOf(0x700));
        public VR4HandPosePair HandPoses_Hold_Pull_Pin => new VR4HandPosePair(AddrOf(0x710));
        public VR4HandPosePair HandPoses_Hold_Armed => new VR4HandPosePair(AddrOf(0x720));
        public VR4HandPosePair HandPoses_Throw_Release => new VR4HandPosePair(AddrOf(0x730));
        public VR4HandPosePair HandPoses_ => new VR4HandPosePair(AddrOf(0x740));
        public bool IsOpaqueProp { get => Native.GetPropBool(Pointer, "IsOpaqueProp"); set => Native.SetPropBool(Pointer, "IsOpaqueProp", value); }
        public TArray<System.IntPtr> SplineMeshes => new TArray<System.IntPtr>(AddrOf(0x758)); // TArray<UObject*>
        public VR4HandPosePair HandPoses_Hold_Eggs => new VR4HandPosePair(AddrOf(0x768));
        public TArray<System.IntPtr> Names => new TArray<System.IntPtr>(AddrOf(0x778)); // TArray<FName>
        public TimerHandle GrenadeJustThrownTimerHandle => new TimerHandle(AddrOf(0x788));
        public void GetInsertLabelTarget(SceneComponent Target, bool Top)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Target);
            __pb.Set<byte>(0x8, (byte)(Top?1:0));
            CallRaw("GetInsertLabelTarget", __pb.Bytes);
        }
        public void GetFirstEquipName(FName FirstEquipName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, FirstEquipName);
            CallRaw("GetFirstEquipName", __pb.Bytes);
        }
        public void GetAutoEquipName(FName AutoEquipName, EPropSlot Slot)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, AutoEquipName);
            __pb.Set<byte>(0x8, (byte)Slot);
            CallRaw("GetAutoEquipName", __pb.Bytes);
        }
        public void SetOpaqueProp(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("SetOpaqueProp", __pb.Bytes);
        }
        public void SetTranslucentProp(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("SetTranslucentProp", __pb.Bytes);
        }
        public void CancelGrenadeJustThrownTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CancelGrenadeJustThrownTimer", __pb.Bytes);
        }
        public void SetGrenadeJustThrownTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetGrenadeJustThrownTimer", __pb.Bytes);
        }
        public void SetPinAnimPhysics(bool Anim_Simulate)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Anim_Simulate?1:0));
            CallRaw("SetPinAnimPhysics", __pb.Bytes);
        }
        public bool NeedsHandleTeleport()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("NeedsHandleTeleport", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void UpdateLocators(bool SetLocators)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SetLocators?1:0));
            CallRaw("UpdateLocators", __pb.Bytes);
        }
        public void IsEgg(bool IsEgg)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsEgg?1:0));
            CallRaw("IsEgg", __pb.Bytes);
        }
        public void PlaceLureHead(Vector ContactPosition, Vector ContactNormal)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, ContactPosition);
            __pb.Set<System.IntPtr>(0xC, ContactNormal);
            CallRaw("PlaceLureHead", __pb.Bytes);
        }
        public void OrientLure(System.IntPtr LurePositions)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, LurePositions);
            CallRaw("OrientLure", __pb.Bytes);
        }
        public void ClearLure()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearLure", __pb.Bytes);
        }
        public void UpdateLureArcCount(System.IntPtr ArcPositions)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, ArcPositions);
            CallRaw("UpdateLureArcCount", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void UpdateHandPoses()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateHandPoses", __pb.Bytes);
        }
        public SceneComponent GetPinMeshFromBP()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetPinMeshFromBP", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); }
        }
        public void DisablePinHeld()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisablePinHeld", __pb.Bytes);
        }
        public void SetTopRotation(Vector HandLocation, Rotator InRot)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, HandLocation);
            __pb.Set<System.IntPtr>(0xC, InRot);
            CallRaw("SetTopRotation", __pb.Bytes);
        }
        public void SetPinRotations(Vector HandLocation, Rotator InRot)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, HandLocation);
            __pb.Set<System.IntPtr>(0xC, InRot);
            CallRaw("SetPinRotations", __pb.Bytes);
        }
        public void SetGrenadeSimulatePhysics(bool Simulate)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Simulate?1:0));
            CallRaw("SetGrenadeSimulatePhysics", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__PinrGripIKTarget_K2Node_ComponentBoundEvent_0_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PinrGripIKTarget_K2Node_ComponentBoundEvent_0_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__PinGrip_K2Node_ComponentBoundEvent_2_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PinGrip_K2Node_ComponentBoundEvent_2_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void UpdatePinModel(Transform handTransform)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, handTransform);
            CallRaw("UpdatePinModel", __pb.Bytes);
        }
        public void OnGrenadePinPulled()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnGrenadePinPulled", __pb.Bytes);
        }
        public void BndEvt__PinGrip_K2Node_ComponentBoundEvent_3_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PinGrip_K2Node_ComponentBoundEvent_3_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void OnGrenadeAssigned(Actor ModelActor, EGamePlayerPropAssignedContext Context)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, ModelActor);
            __pb.Set<byte>(0x8, (byte)Context);
            CallRaw("OnGrenadeAssigned", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_1_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_1_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_5_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_5_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_4_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_4_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__PinGrip_K2Node_ComponentBoundEvent_6_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PinGrip_K2Node_ComponentBoundEvent_6_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void OnLiveGrenadeReleased(VR4GamePlayerHand ThrowingHand, EVR4GamePlayerGrenadeLiveReleaseCause Cause)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, ThrowingHand);
            __pb.Set<byte>(0x8, (byte)Cause);
            CallRaw("OnLiveGrenadeReleased", __pb.Bytes);
        }
        public void BeginGrenadeLure()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BeginGrenadeLure", __pb.Bytes);
        }
        public void EndGrenadeLure()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndGrenadeLure", __pb.Bytes);
        }
        public void UpdateGrenadeLure()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateGrenadeLure", __pb.Bytes);
        }
        public void PreHandleTeleport()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PreHandleTeleport", __pb.Bytes);
        }
        public void PostHandleTeleport()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PostHandleTeleport", __pb.Bytes);
        }
        public void GrenadeJustThrownTimer()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GrenadeJustThrownTimer", __pb.Bytes);
        }
        public void OnWeaponsModeChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnWeaponsModeChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4GamePlayerGrenade_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4GamePlayerGrenade_BP", __pb.Bytes);
        }
    }

}
