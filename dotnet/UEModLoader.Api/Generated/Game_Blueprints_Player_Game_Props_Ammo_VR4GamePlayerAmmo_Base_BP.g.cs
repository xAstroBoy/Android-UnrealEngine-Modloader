// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Ammo/VR4GamePlayerAmmo_Base_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayerAmmo_Base_BP_C : VR4GamePlayerAmmo
    {
        public const string UeClassName = "VR4GamePlayerAmmo_Base_BP_C";
        public VR4GamePlayerAmmo_Base_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayerAmmo_Base_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4GamePlayerAmmo_Base_BP_C(p);
        public static VR4GamePlayerAmmo_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayerAmmo_Base_BP_C(o.Pointer); }
        public static VR4GamePlayerAmmo_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayerAmmo_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayerAmmo_Base_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x630));
        public AudioComponent SFX_Ammo_Grab { get { var __p = GetAt<System.IntPtr>(0x638); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x638, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent PrimaryGripReloadHandPose { get { var __p = GetAt<System.IntPtr>(0x640); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x640, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent PrimaryGripMainHainPose { get { var __p = GetAt<System.IntPtr>(0x648); return __p==System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x648, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4PriorityListHandPoseSourceComponent PrimaryGripGrabbedHandPose { get { var __p = GetAt<System.IntPtr>(0x650); return __p==System.IntPtr.Zero?null:new VR4PriorityListHandPoseSourceComponent(__p); } set => SetAt(0x650, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget PrimaryGripSkeletalIKTarget { get { var __p = GetAt<System.IntPtr>(0x658); return __p==System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x658, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent AmmoCounterOutside { get { var __p = GetAt<System.IntPtr>(0x660); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x660, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent AmmoCounterInside { get { var __p = GetAt<System.IntPtr>(0x668); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x668, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Pivot { get { var __p = GetAt<System.IntPtr>(0x670); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x670, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent TopRef { get { var __p = GetAt<System.IntPtr>(0x678); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x678, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent PouchMesh { get { var __p = GetAt<System.IntPtr>(0x680); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x680, value?.Pointer ?? System.IntPtr.Zero); }
        public AmmoPouch_AnimBP_C AnimBP { get { var __p = GetAt<System.IntPtr>(0x688); return __p==System.IntPtr.Zero?null:new AmmoPouch_AnimBP_C(__p); } set => SetAt(0x688, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> PouchMags => new TArray<System.IntPtr>(AddrOf(0x690)); // TArray<UObject*>
        public bool MagsAreRounds { get => Native.GetPropBool(Pointer, "MagsAreRounds"); set => Native.SetPropBool(Pointer, "MagsAreRounds", value); }
        public bool holstered { get => Native.GetPropBool(Pointer, "holstered"); set => Native.SetPropBool(Pointer, "holstered", value); }
        public bool Visible { get => Native.GetPropBool(Pointer, "Visible"); set => Native.SetPropBool(Pointer, "Visible", value); }
        public bool pouchOpen { get => Native.GetPropBool(Pointer, "pouchOpen"); set => Native.SetPropBool(Pointer, "pouchOpen", value); }
        public bool AmmoAvailable { get => Native.GetPropBool(Pointer, "AmmoAvailable"); set => Native.SetPropBool(Pointer, "AmmoAvailable", value); }
        public int reserves { get => GetAt<int>(0x6A8); set => SetAt(0x6A8, value); }
        public int gunCapacity { get => GetAt<int>(0x6AC); set => SetAt(0x6AC, value); }
        public int AnimatedTotalVisibleMags { get => GetAt<int>(0x6B0); set => SetAt(0x6B0, value); }
        public bool AnimatedAmmoInPouch { get => Native.GetPropBool(Pointer, "AnimatedAmmoInPouch"); set => Native.SetPropBool(Pointer, "AnimatedAmmoInPouch", value); }
        public int AnimatedVisibleMagsInPouch { get => GetAt<int>(0x6B8); set => SetAt(0x6B8, value); }
        public bool JustReloaded { get => Native.GetPropBool(Pointer, "JustReloaded"); set => Native.SetPropBool(Pointer, "JustReloaded", value); }
        public bool JustHolstered { get => Native.GetPropBool(Pointer, "JustHolstered"); set => Native.SetPropBool(Pointer, "JustHolstered", value); }
        public int loadedAmmo { get => GetAt<int>(0x6C0); set => SetAt(0x6C0, value); }
        public int totalAmmo { get => GetAt<int>(0x6C4); set => SetAt(0x6C4, value); }
        public bool loadingAidSpent { get => Native.GetPropBool(Pointer, "loadingAidSpent"); set => Native.SetPropBool(Pointer, "loadingAidSpent", value); }
        public AmmoPouchWidget_C CounterInside { get { var __p = GetAt<System.IntPtr>(0x6D0); return __p==System.IntPtr.Zero?null:new AmmoPouchWidget_C(__p); } set => SetAt(0x6D0, value?.Pointer ?? System.IntPtr.Zero); }
        public AmmoPouchWidget_C CounterOutside { get { var __p = GetAt<System.IntPtr>(0x6D8); return __p==System.IntPtr.Zero?null:new AmmoPouchWidget_C(__p); } set => SetAt(0x6D8, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> ReloadHandPosePair => new TArray<System.IntPtr>(AddrOf(0x6E0)); // TArray<struct>
        public bool GoldenGunMagMatsInitialized { get => Native.GetPropBool(Pointer, "GoldenGunMagMatsInitialized"); set => Native.SetPropBool(Pointer, "GoldenGunMagMatsInitialized", value); }
        public TArray<System.IntPtr> OriginalMats => new TArray<System.IntPtr>(AddrOf(0x6F8)); // TArray<UObject*>
        public bool UsingGoldenGunMats { get => Native.GetPropBool(Pointer, "UsingGoldenGunMats"); set => Native.SetPropBool(Pointer, "UsingGoldenGunMats", value); }
        public void WorldDilationChanged(float WorldTimeDilation, float PlayerTimeDilation, float CustomTimeDilation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, WorldTimeDilation);
            __pb.Set(0x4, PlayerTimeDilation);
            __pb.Set(0x8, CustomTimeDilation);
            CallRaw("WorldDilationChanged", __pb.Bytes);
        }
        public void Update_Golden_Gun_Mags()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Update Golden Gun Mags", __pb.Bytes);
        }
        public void GetReloadHandPosePair(int reloadAnimIndex, VR4HandPosePair Result)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set(0x0, reloadAnimIndex);
            __pb.Set<System.IntPtr>(0x4, Result);
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
        public void UpdateMags()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateMags", __pb.Bytes);
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
        public void OnNotifyEnd_A426680B4F5A05B557CA789DDF1CA674(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnNotifyEnd_A426680B4F5A05B557CA789DDF1CA674", __pb.Bytes);
        }
        public void OnNotifyBegin_A426680B4F5A05B557CA789DDF1CA674(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnNotifyBegin_A426680B4F5A05B557CA789DDF1CA674", __pb.Bytes);
        }
        public void OnInterrupted_A426680B4F5A05B557CA789DDF1CA674(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnInterrupted_A426680B4F5A05B557CA789DDF1CA674", __pb.Bytes);
        }
        public void OnBlendOut_A426680B4F5A05B557CA789DDF1CA674(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnBlendOut_A426680B4F5A05B557CA789DDF1CA674", __pb.Bytes);
        }
        public void OnCompleted_A426680B4F5A05B557CA789DDF1CA674(FName NotifyName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, NotifyName);
            CallRaw("OnCompleted_A426680B4F5A05B557CA789DDF1CA674", __pb.Bytes);
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
        public void OnTossHolsterEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnTossHolsterEnd", __pb.Bytes);
        }
        public void HandlePlayerSettingsChanged(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("HandlePlayerSettingsChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4GamePlayerAmmo_Base_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4GamePlayerAmmo_Base_BP", __pb.Bytes);
        }
    }

}
