// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Ammo/VR4GamePlayerAmmo_Wep13_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayerAmmo_Wep13_BP_C : VR4GamePlayerAmmo
    {
        public const string UeClassName = "VR4GamePlayerAmmo_Wep13_BP_C";
        public VR4GamePlayerAmmo_Wep13_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayerAmmo_Wep13_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4GamePlayerAmmo_Wep13_BP_C(p);
        public static VR4GamePlayerAmmo_Wep13_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayerAmmo_Wep13_BP_C(o.Pointer); }
        public static VR4GamePlayerAmmo_Wep13_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayerAmmo_Wep13_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayerAmmo_Wep13_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x630));
        public AudioComponent SFX_Ammo { get { var __p = GetAt<global::System.IntPtr>(0x638); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x638, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent PrimaryGripReloadHandPose { get { var __p = GetAt<global::System.IntPtr>(0x640); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x640, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent PrimaryGripMainHainPose { get { var __p = GetAt<global::System.IntPtr>(0x648); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x648, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4PriorityListHandPoseSourceComponent PrimaryGripGrabbedHandPose { get { var __p = GetAt<global::System.IntPtr>(0x650); return __p==global::System.IntPtr.Zero?null:new VR4PriorityListHandPoseSourceComponent(__p); } set => SetAt(0x650, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget SkeletalPrimaryGripIKTarget { get { var __p = GetAt<global::System.IntPtr>(0x658); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x658, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent PouchRocket { get { var __p = GetAt<global::System.IntPtr>(0x660); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x660, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Pivot { get { var __p = GetAt<global::System.IntPtr>(0x668); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x668, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent TopRef { get { var __p = GetAt<global::System.IntPtr>(0x670); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x670, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SkeletalMeshComponent PouchMesh { get { var __p = GetAt<global::System.IntPtr>(0x678); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x678, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Ammo_ScaleIn_Scale_ED18694241AD764A456BC8B968B243A6 { get => GetAt<float>(0x680); set => SetAt(0x680, value); }
        public byte Ammo_ScaleIn__Direction_ED18694241AD764A456BC8B968B243A6 { get => GetAt<byte>(0x684); set => SetAt(0x684, value); }
        public TimelineComponent Ammo_ScaleIn { get { var __p = GetAt<global::System.IntPtr>(0x688); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x688, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool holstered { get => Native.GetPropBool(Pointer, "holstered"); set => Native.SetPropBool(Pointer, "holstered", value); }
        public bool Visible { get => Native.GetPropBool(Pointer, "Visible"); set => Native.SetPropBool(Pointer, "Visible", value); }
        public bool pouchOpen { get => Native.GetPropBool(Pointer, "pouchOpen"); set => Native.SetPropBool(Pointer, "pouchOpen", value); }
        public bool AmmoAvailable { get => Native.GetPropBool(Pointer, "AmmoAvailable"); set => Native.SetPropBool(Pointer, "AmmoAvailable", value); }
        public int reserves { get => GetAt<int>(0x694); set => SetAt(0x694, value); }
        public TArray<global::System.IntPtr> ReloadHandPosePair => new TArray<global::System.IntPtr>(AddrOf(0x698)); // TArray<struct>
        public void WorldDilationChanged(float WorldTimeDilation, float PlayerTimeDilation, float CustomTimeDilation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, WorldTimeDilation);
            __pb.Set(0x4, PlayerTimeDilation);
            __pb.Set(0x8, CustomTimeDilation);
            CallRaw("WorldDilationChanged", __pb.Bytes);
        }
        public void GetReloadHandPosePair(int reloadAnimIndex, global::System.IntPtr Result)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set(0x0, reloadAnimIndex);
            __pb.Set<global::System.IntPtr>(0x4, Result);
            CallRaw("GetReloadHandPosePair", __pb.Bytes);
        }
        public void GetCurrentAnimMontage(bool held, int reloadAnimIndex, EHandedness Handedness, AnimMontage Montage)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)(held?1:0));
            __pb.Set(0x4, reloadAnimIndex);
            __pb.Set<byte>(0x8, (byte)Handedness);
            __pb.SetObject(0x10, Montage);
            CallRaw("GetCurrentAnimMontage", __pb.Bytes);
        }
        public void UpdateVisibility_Internal(bool Visible, bool holstered, bool held, bool pouchOpen, bool AmmoAvailable, bool loadingAidSpent, int reserves, int gunCapacity, int loadedAmmo, int totalAmmo, int reloadAnimIndex, EHandedness Handedness)
        {
            var __pb = new ParamBuffer(29);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            __pb.Set<byte>(0x1, (byte)(holstered?1:0));
            __pb.Set<byte>(0x2, (byte)(held?1:0));
            __pb.Set<byte>(0x3, (byte)(pouchOpen?1:0));
            __pb.Set<byte>(0x4, (byte)(AmmoAvailable?1:0));
            __pb.Set<byte>(0x5, (byte)(loadingAidSpent?1:0));
            __pb.Set(0x8, reserves);
            __pb.Set(0xC, gunCapacity);
            __pb.Set(0x10, loadedAmmo);
            __pb.Set(0x14, totalAmmo);
            __pb.Set(0x18, reloadAnimIndex);
            __pb.Set<byte>(0x1C, (byte)Handedness);
            CallRaw("UpdateVisibility_Internal", __pb.Bytes);
        }
        public void Ammo_ScaleIn__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Ammo_ScaleIn__FinishedFunc", __pb.Bytes);
        }
        public void Ammo_ScaleIn__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Ammo_ScaleIn__UpdateFunc", __pb.Bytes);
        }
        public void OnNotifyEnd_A7374A024E33C3E48A5C49B292BC1DA2(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnNotifyEnd_A7374A024E33C3E48A5C49B292BC1DA2", __pb.Bytes);
        }
        public void OnNotifyBegin_A7374A024E33C3E48A5C49B292BC1DA2(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnNotifyBegin_A7374A024E33C3E48A5C49B292BC1DA2", __pb.Bytes);
        }
        public void OnInterrupted_A7374A024E33C3E48A5C49B292BC1DA2(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnInterrupted_A7374A024E33C3E48A5C49B292BC1DA2", __pb.Bytes);
        }
        public void OnBlendOut_A7374A024E33C3E48A5C49B292BC1DA2(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnBlendOut_A7374A024E33C3E48A5C49B292BC1DA2", __pb.Bytes);
        }
        public void OnCompleted_A7374A024E33C3E48A5C49B292BC1DA2(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnCompleted_A7374A024E33C3E48A5C49B292BC1DA2", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_0_GripEventSignature__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_0_GripEventSignature__DelegateSignature", __pb.Bytes);
        }
        public void UpdateVisibility(bool Visible, bool holstered, bool held, bool pouchOpen, bool AmmoAvailable, bool loadingAidSpent, int reserves, int gunCapacity, int loadedAmmo, int totalAmmo, int reloadAnimIndex, EHandedness Handedness)
        {
            var __pb = new ParamBuffer(29);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            __pb.Set<byte>(0x1, (byte)(holstered?1:0));
            __pb.Set<byte>(0x2, (byte)(held?1:0));
            __pb.Set<byte>(0x3, (byte)(pouchOpen?1:0));
            __pb.Set<byte>(0x4, (byte)(AmmoAvailable?1:0));
            __pb.Set<byte>(0x5, (byte)(loadingAidSpent?1:0));
            __pb.Set(0x8, reserves);
            __pb.Set(0xC, gunCapacity);
            __pb.Set(0x10, loadedAmmo);
            __pb.Set(0x14, totalAmmo);
            __pb.Set(0x18, reloadAnimIndex);
            __pb.Set<byte>(0x1C, (byte)Handedness);
            CallRaw("UpdateVisibility", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnLoadedIntoGun()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnLoadedIntoGun", __pb.Bytes);
        }
        public void UpdateMaterial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateMaterial", __pb.Bytes);
        }
        public void OnActiveReloadAnimationIndexChanged(int reloadAnimIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, reloadAnimIndex);
            CallRaw("OnActiveReloadAnimationIndexChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4GamePlayerAmmo_Wep13_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4GamePlayerAmmo_Wep13_BP", __pb.Bytes);
        }
    }

}
