// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/VR4GamePlayer_Wep07_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayer_Wep07_BP_C : VR4GamePlayerShotgun
    {
        public const string UeClassName = "VR4GamePlayer_Wep07_BP_C";
        public VR4GamePlayer_Wep07_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayer_Wep07_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4GamePlayer_Wep07_BP_C(p);
        public static VR4GamePlayer_Wep07_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayer_Wep07_BP_C(o.Pointer); }
        public static VR4GamePlayer_Wep07_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayer_Wep07_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayer_Wep07_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x11A0));
        public AudioComponent SFX_Wep_Shotgun_Trigger { get { var __p = GetAt<global::System.IntPtr>(0x11A8); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x11A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AudioComponent SFX_Wep_Shotgun_ForeStock { get { var __p = GetAt<global::System.IntPtr>(0x11B0); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x11B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent PrimaryGripGrabbedAnimHandPose { get { var __p = GetAt<global::System.IntPtr>(0x11B8); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x11B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4PriorityListHandPoseSourceComponent PrimaryGripGrabbedHandPose { get { var __p = GetAt<global::System.IntPtr>(0x11C0); return __p==global::System.IntPtr.Zero?null:new VR4PriorityListHandPoseSourceComponent(__p); } set => SetAt(0x11C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent PrimaryGripGrabbedStaticHandPose { get { var __p = GetAt<global::System.IntPtr>(0x11C8); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x11C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GunHandPoseHelper_C HandPoseHelper { get { var __p = GetAt<global::System.IntPtr>(0x11D0); return __p==global::System.IntPtr.Zero?null:new GunHandPoseHelper_C(__p); } set => SetAt(0x11D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BoxComponent ForestockGrip_ReleaseBox { get { var __p = GetAt<global::System.IntPtr>(0x11D8); return __p==global::System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x11D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ForestockGripPointB { get { var __p = GetAt<global::System.IntPtr>(0x11E0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x11E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ForestockGripPointA { get { var __p = GetAt<global::System.IntPtr>(0x11E8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x11E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget ForestockGripIKTarget_New { get { var __p = GetAt<global::System.IntPtr>(0x11F0); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x11F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGripIndicator ForestockGripIndicator_New { get { var __p = GetAt<global::System.IntPtr>(0x11F8); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGripIndicator(__p); } set => SetAt(0x11F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BoxComponent ForestockGripBoxRH { get { var __p = GetAt<global::System.IntPtr>(0x1200); return __p==global::System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x1200, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BoxComponent ForestockGripBoxLH { get { var __p = GetAt<global::System.IntPtr>(0x1208); return __p==global::System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x1208, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGripIndicator PrimaryGripIndicator_New { get { var __p = GetAt<global::System.IntPtr>(0x1210); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGripIndicator(__p); } set => SetAt(0x1210, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BoxComponent PrimaryGripBox_New { get { var __p = GetAt<global::System.IntPtr>(0x1218); return __p==global::System.IntPtr.Zero?null:new BoxComponent(__p); } set => SetAt(0x1218, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PropGrip_Defaults_BP_C ForestockGripRH { get { var __p = GetAt<global::System.IntPtr>(0x1220); return __p==global::System.IntPtr.Zero?null:new PropGrip_Defaults_BP_C(__p); } set => SetAt(0x1220, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PropGrip_Defaults_BP_C ForestockGripLH { get { var __p = GetAt<global::System.IntPtr>(0x1228); return __p==global::System.IntPtr.Zero?null:new PropGrip_Defaults_BP_C(__p); } set => SetAt(0x1228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GenericLocator PrimaryGripControllerLocator { get { var __p = GetAt<global::System.IntPtr>(0x1230); return __p==global::System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x1230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget PrimaryGripIKTarget { get { var __p = GetAt<global::System.IntPtr>(0x1238); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x1238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SocketForwardingSceneComponent ForestockGripContainer { get { var __p = GetAt<global::System.IntPtr>(0x1240); return __p==global::System.IntPtr.Zero?null:new SocketForwardingSceneComponent(__p); } set => SetAt(0x1240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SocketForwardingSceneComponent PrimaryGripContainer { get { var __p = GetAt<global::System.IntPtr>(0x1248); return __p==global::System.IntPtr.Zero?null:new SocketForwardingSceneComponent(__p); } set => SetAt(0x1248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ForestockGripBoxLocatorLH { get { var __p = GetAt<global::System.IntPtr>(0x1250); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ForestockGripBoxLocatorRH { get { var __p = GetAt<global::System.IntPtr>(0x1258); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent InsertLabelTarget { get { var __p = GetAt<global::System.IntPtr>(0x1260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CapsuleComponent PhysicsInteractionPump { get { var __p = GetAt<global::System.IntPtr>(0x1268); return __p==global::System.IntPtr.Zero?null:new CapsuleComponent(__p); } set => SetAt(0x1268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CapsuleComponent PhysicsInteractionBarrel { get { var __p = GetAt<global::System.IntPtr>(0x1270); return __p==global::System.IntPtr.Zero?null:new CapsuleComponent(__p); } set => SetAt(0x1270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float FiringMechanismForward_Alpha_566639FF4AB100A4F4E298A0EDEC833D { get => GetAt<float>(0x1278); set => SetAt(0x1278, value); }
        public byte FiringMechanismForward__Direction_566639FF4AB100A4F4E298A0EDEC833D { get => GetAt<byte>(0x127C); set => SetAt(0x127C, value); }
        public TimelineComponent FiringMechanismForward { get { var __p = GetAt<global::System.IntPtr>(0x1280); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x1280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float OpenEjectionChamber_Alpha_1577829E4A4E48230489B8B68FBE6781 { get => GetAt<float>(0x1288); set => SetAt(0x1288, value); }
        public byte OpenEjectionChamber__Direction_1577829E4A4E48230489B8B68FBE6781 { get => GetAt<byte>(0x128C); set => SetAt(0x128C, value); }
        public TimelineComponent OpenEjectionChamber { get { var __p = GetAt<global::System.IntPtr>(0x1290); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x1290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float OpenLoadingRamp_Alpha_F8BCCF8241AFC49090E7249C4D3AD13D { get => GetAt<float>(0x1298); set => SetAt(0x1298, value); }
        public byte OpenLoadingRamp__Direction_F8BCCF8241AFC49090E7249C4D3AD13D { get => GetAt<byte>(0x129C); set => SetAt(0x129C, value); }
        public TimelineComponent OpenLoadingRamp { get { var __p = GetAt<global::System.IntPtr>(0x12A0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x12A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool Reloading { get => Native.GetPropBool(Pointer, "Reloading"); set => Native.SetPropBool(Pointer, "Reloading", value); }
        public Vector OriginalForestockEndHandTarget => new Vector(AddrOf(0x12AC));
        public Vector OriginalReadyChamberForestockEndHandTarget => new Vector(AddrOf(0x12B8));
        public bool NeedsReloading { get => Native.GetPropBool(Pointer, "NeedsReloading"); set => Native.SetPropBool(Pointer, "NeedsReloading", value); }
        public global::System.IntPtr ShotgunCycled => AddrOf(0x12C8); // 
        public global::System.IntPtr ShotgunForestockGrabbed => AddrOf(0x12D8); // 
        public global::System.IntPtr ShotgunShellInserted => AddrOf(0x12E8); // 
        public global::System.IntPtr AT_EjectionChamber => AddrOf(0x1300); // struct SimpleAnimationTransformPair
        public global::System.IntPtr EjectionChamberAnimationSettings => AddrOf(0x1360); // struct SimpleSocketAnimationSettings
        public global::System.IntPtr FiringMechanismAnimationSettings => AddrOf(0x1378); // struct SimpleSocketAnimationSettings
        public global::System.IntPtr AT_FiringMechanism => AddrOf(0x1390); // struct SimpleAnimationTransformPair
        public global::System.IntPtr ReadyShellAnimationSettings => AddrOf(0x13F0); // struct SimpleSocketAnimationSettings
        public global::System.IntPtr AT_ReadyShell => AddrOf(0x1410); // struct SimpleAnimationTransformPair
        public global::System.IntPtr LoadingRampAnimationSettings => AddrOf(0x1470); // struct SimpleSocketAnimationSettings
        public global::System.IntPtr AT_LoadingRamp => AddrOf(0x1490); // struct SimpleAnimationTransformPair
        public string NextShellBoneName => Native.GetPropName(Pointer, "NextShellBoneName"); // FName
        public FName NextShellBoneName_Raw { get => GetAt<FName>(0x14F0); set => SetAt(0x14F0, value); }
        public string EmptyLoaderBoneName => Native.GetPropName(Pointer, "EmptyLoaderBoneName"); // FName
        public FName EmptyLoaderBoneName_Raw { get => GetAt<FName>(0x14F8); set => SetAt(0x14F8, value); }
        public bool IsOpaqueProp { get => Native.GetPropBool(Pointer, "IsOpaqueProp"); set => Native.SetPropBool(Pointer, "IsOpaqueProp", value); }
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
        public void InitAnimationTransforms()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitAnimationTransforms", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void UpdateChamberAndMagazine()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateChamberAndMagazine", __pb.Bytes);
        }
        public void UpdateWeaponIndicators_Internal(int ammoCount, int ammoCapacity, bool canFire, bool loadingRampOpen, bool ammoHeld)
        {
            var __pb = new ParamBuffer(11);
            __pb.Set(0x0, ammoCount);
            __pb.Set(0x4, ammoCapacity);
            __pb.Set<byte>(0x8, (byte)(canFire?1:0));
            __pb.Set<byte>(0x9, (byte)(loadingRampOpen?1:0));
            __pb.Set<byte>(0xA, (byte)(ammoHeld?1:0));
            CallRaw("UpdateWeaponIndicators_Internal", __pb.Bytes);
        }
        public void OpenEjectionChamber__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenEjectionChamber__FinishedFunc", __pb.Bytes);
        }
        public void OpenEjectionChamber__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenEjectionChamber__UpdateFunc", __pb.Bytes);
        }
        public void OpenLoadingRamp__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenLoadingRamp__FinishedFunc", __pb.Bytes);
        }
        public void OpenLoadingRamp__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenLoadingRamp__UpdateFunc", __pb.Bytes);
        }
        public void FiringMechanismForward__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FiringMechanismForward__FinishedFunc", __pb.Bytes);
        }
        public void FiringMechanismForward__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FiringMechanismForward__UpdateFunc", __pb.Bytes);
        }
        public void OnAmmoHoverChanged(bool hovering)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(hovering?1:0));
            CallRaw("OnAmmoHoverChanged", __pb.Bytes);
        }
        public void OnUpdateWeaponIndicators(int ammoCount, int ammoCapacity, bool canFire, bool loadingRampOpen, bool ammoHeld)
        {
            var __pb = new ParamBuffer(11);
            __pb.Set(0x0, ammoCount);
            __pb.Set(0x4, ammoCapacity);
            __pb.Set<byte>(0x8, (byte)(canFire?1:0));
            __pb.Set<byte>(0x9, (byte)(loadingRampOpen?1:0));
            __pb.Set<byte>(0xA, (byte)(ammoHeld?1:0));
            CallRaw("OnUpdateWeaponIndicators", __pb.Bytes);
        }
        public void OnForestockTargetPositionChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnForestockTargetPositionChanged", __pb.Bytes);
        }
        public void OnForestockTargetPositionReached()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnForestockTargetPositionReached", __pb.Bytes);
        }
        public void OnChamberStateChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnChamberStateChanged", __pb.Bytes);
        }
        public void OpenChamber()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenChamber", __pb.Bytes);
        }
        public void CloseChamber()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CloseChamber", __pb.Bytes);
        }
        public void OpenRamp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenRamp", __pb.Bytes);
        }
        public void CloseRamp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CloseRamp", __pb.Bytes);
        }
        public void OnShellInserted()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnShellInserted", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_0_GripEventSignature__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_0_GripEventSignature__DelegateSignature", __pb.Bytes);
        }
        public void OnDryFire()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnDryFire", __pb.Bytes);
        }
        public void PushFiringMechanism()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PushFiringMechanism", __pb.Bytes);
        }
        public void PullFiringMechanism()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PullFiringMechanism", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_3_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_3_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__ForestockGripGroup_K2Node_ComponentBoundEvent_5_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__ForestockGripGroup_K2Node_ComponentBoundEvent_5_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__ForestockGripGroup_K2Node_ComponentBoundEvent_7_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__ForestockGripGroup_K2Node_ComponentBoundEvent_7_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4GamePlayer_Wep07_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4GamePlayer_Wep07_BP", __pb.Bytes);
        }
        public void ShotgunShellInserted__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShotgunShellInserted__DelegateSignature", __pb.Bytes);
        }
        public void ShotgunForestockGrabbed__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShotgunForestockGrabbed__DelegateSignature", __pb.Bytes);
        }
        public void ShotgunCycled__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShotgunCycled__DelegateSignature", __pb.Bytes);
        }
    }

}
