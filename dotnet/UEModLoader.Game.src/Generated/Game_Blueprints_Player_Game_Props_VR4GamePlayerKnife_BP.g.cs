// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/VR4GamePlayerKnife_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayerKnife_BP_C : VR4GamePlayerKnife
    {
        public const string UeClassName = "VR4GamePlayerKnife_BP_C";
        public VR4GamePlayerKnife_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayerKnife_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4GamePlayerKnife_BP_C(p);
        public static VR4GamePlayerKnife_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayerKnife_BP_C(o.Pointer); }
        public static VR4GamePlayerKnife_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayerKnife_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayerKnife_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x6D0));
        public AudioComponent SFX_Knife { get { var __p = GetAt<global::System.IntPtr>(0x6D8); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x6D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget PrimaryGripIKTarget { get { var __p = GetAt<global::System.IntPtr>(0x6E0); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x6E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool LastActivate { get => Native.GetPropBool(Pointer, "LastActivate"); set => Native.SetPropBool(Pointer, "LastActivate", value); }
        public MaterialInstanceDynamic TEST_TEST { get { var __p = GetAt<global::System.IntPtr>(0x6F0); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x6F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float SwingSoundStartTime { get => GetAt<float>(0x6F8); set => SetAt(0x6F8, value); }
        public bool IsOpaqueProp { get => Native.GetPropBool(Pointer, "IsOpaqueProp"); set => Native.SetPropBool(Pointer, "IsOpaqueProp", value); }
        public global::System.IntPtr KnifeSwingEnded => AddrOf(0x700); // 
        public TutorialHelper_C ActiveTutorial { get { var __p = GetAt<global::System.IntPtr>(0x710); return __p==global::System.IntPtr.Zero?null:new TutorialHelper_C(__p); } set => SetAt(0x710, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMesh PrimaryMesh { get { var __p = GetAt<global::System.IntPtr>(0x718); return __p==global::System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x718, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMesh HolsteredMesh { get { var __p = GetAt<global::System.IntPtr>(0x720); return __p==global::System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x720, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoundBase SFXHolsterGrab { get { var __p = GetAt<global::System.IntPtr>(0x728); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x728, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float CoGZAdjust { get => GetAt<float>(0x730); set => SetAt(0x730, value); }
        public bool IsUsingGoldenGunMaterials { get => Native.GetPropBool(Pointer, "IsUsingGoldenGunMaterials"); set => Native.SetPropBool(Pointer, "IsUsingGoldenGunMaterials", value); }
        public TArray<global::System.IntPtr> OriginalMaterials => new TArray<global::System.IntPtr>(AddrOf(0x738)); // TArray<UObject*>
        public MaterialInterface GoldenGunMaterial { get { var __p = GetAt<global::System.IntPtr>(0x748); return __p==global::System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x748, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool SwingTutorialHidden { get => Native.GetPropBool(Pointer, "SwingTutorialHidden"); set => Native.SetPropBool(Pointer, "SwingTutorialHidden", value); }
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
        public void HandlePlayerSettingsChanged(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("HandlePlayerSettingsChanged", __pb.Bytes);
        }
        public void InitializeOriginalMaterials()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeOriginalMaterials", __pb.Bytes);
        }
        public void UpdateGoldenGunMaterial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateGoldenGunMaterial", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void Tutorial_()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Tutorial?", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_1_GripEventSignature__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_1_GripEventSignature__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_0_GripEventSignature__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_0_GripEventSignature__DelegateSignature", __pb.Bytes);
        }
        public void OnSwingEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnSwingEnd", __pb.Bytes);
        }
        public void OnSwingStart()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnSwingStart", __pb.Bytes);
        }
        public void OnHolstered()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnHolstered", __pb.Bytes);
        }
        public void PlayHitParticle(global::System.IntPtr particleTransform, EKnifeSlashParticle particleType)
        {
            var __pb = new ParamBuffer(49);
            __pb.Set<global::System.IntPtr>(0x0, particleTransform);
            __pb.Set<byte>(0x30, (byte)particleType);
            CallRaw("PlayHitParticle", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4GamePlayerKnife_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4GamePlayerKnife_BP", __pb.Bytes);
        }
        public void KnifeSwingEnded__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("KnifeSwingEnded__DelegateSignature", __pb.Bytes);
        }
    }

}
