// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Consumables/VR4Consumable_Base
using System;

namespace UEModLoader.Game
{
    public class VR4Consumable_Base_C : VR4GamePlayerConsumable
    {
        public const string UeClassName = "VR4Consumable_Base_C";
        public VR4Consumable_Base_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4Consumable_Base_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4Consumable_Base_C(p);
        public static VR4Consumable_Base_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4Consumable_Base_C(o.Pointer); }
        public static VR4Consumable_Base_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4Consumable_Base_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4Consumable_Base_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x5D0));
        public AudioComponent SFX_Grab { get { var __p = GetAt<System.IntPtr>(0x5D8); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x5D8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ScaleTarget { get { var __p = GetAt<System.IntPtr>(0x5E0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x5E0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent TutorialAnchorAlt { get { var __p = GetAt<System.IntPtr>(0x5E8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x5E8, value?.Pointer ?? System.IntPtr.Zero); }
        public GenericLocator PrimaryGripControllerLocatorRight { get { var __p = GetAt<System.IntPtr>(0x5F0); return __p==System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x5F0, value?.Pointer ?? System.IntPtr.Zero); }
        public GenericLocator PrimaryGripControllerLocatorLeft { get { var __p = GetAt<System.IntPtr>(0x5F8); return __p==System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x5F8, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget PrimaryGripIKTarget { get { var __p = GetAt<System.IntPtr>(0x600); return __p==System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x600, value?.Pointer ?? System.IntPtr.Zero); }
        public AudioComponent BuildUpSFX { get { var __p = GetAt<System.IntPtr>(0x608); return __p==System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x608, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent FxRoot { get { var __p = GetAt<System.IntPtr>(0x610); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x610, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ProgressIndicatorInventoryLocation { get { var __p = GetAt<System.IntPtr>(0x618); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x618, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent TutorialAnchor { get { var __p = GetAt<System.IntPtr>(0x620); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x620, value?.Pointer ?? System.IntPtr.Zero); }
        public float ShrinkOutro_Scale_DC299C7F4B950B601493B2B894FC8AB7 { get => GetAt<float>(0x628); set => SetAt(0x628, value); }
        public byte ShrinkOutro__Direction_DC299C7F4B950B601493B2B894FC8AB7 { get => GetAt<byte>(0x62C); set => SetAt(0x62C, value); }
        public TimelineComponent ShrinkOutro { get { var __p = GetAt<System.IntPtr>(0x630); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x630, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr ItemUseStarted => AddrOf(0x638); // 
        public SoundBase UseSound { get { var __p = GetAt<System.IntPtr>(0x648); return __p==System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x648, value?.Pointer ?? System.IntPtr.Zero); }
        public string InventoryProgressIndicatorSocketName => Native.GetPropName(Pointer, "InventoryProgressIndicatorSocketName"); // FName
        public FName InventoryProgressIndicatorSocketName_Raw { get => GetAt<FName>(0x650); set => SetAt(0x650, value); }
        public string ConsumeTutorialNameL => Native.GetPropName(Pointer, "ConsumeTutorialNameL"); // FName
        public FName ConsumeTutorialNameL_Raw { get => GetAt<FName>(0x658); set => SetAt(0x658, value); }
        public string ConsumeTutorialNameR => Native.GetPropName(Pointer, "ConsumeTutorialNameR"); // FName
        public FName ConsumeTutorialNameR_Raw { get => GetAt<FName>(0x660); set => SetAt(0x660, value); }
        public TutorialHelper_C ActiveTutorial { get { var __p = GetAt<System.IntPtr>(0x668); return __p==System.IntPtr.Zero?null:new TutorialHelper_C(__p); } set => SetAt(0x668, value?.Pointer ?? System.IntPtr.Zero); }
        public bool FinishWithTransient { get => Native.GetPropBool(Pointer, "FinishWithTransient"); set => Native.SetPropBool(Pointer, "FinishWithTransient", value); }
        public ParticleSystem UseFinishedFx { get { var __p = GetAt<System.IntPtr>(0x678); return __p==System.IntPtr.Zero?null:new ParticleSystem(__p); } set => SetAt(0x678, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4GamePlayerHand Hand { get { var __p = GetAt<System.IntPtr>(0x680); return __p==System.IntPtr.Zero?null:new VR4GamePlayerHand(__p); } set => SetAt(0x680, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneActor ShrinkActor { get { var __p = GetAt<System.IntPtr>(0x688); return __p==System.IntPtr.Zero?null:new SceneActor(__p); } set => SetAt(0x688, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4FlyText flyText { get { var __p = GetAt<System.IntPtr>(0x690); return __p==System.IntPtr.Zero?null:new VR4FlyText(__p); } set => SetAt(0x690, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector FlyTextOffset => new Vector(AddrOf(0x698));
        public void ReleaseAndAttachToHand()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReleaseAndAttachToHand", __pb.Bytes);
        }
        public void VerifyParentSocket(SceneComponent component, SceneComponent ComponentIfSocketValid)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, ComponentIfSocketValid);
            CallRaw("VerifyParentSocket", __pb.Bytes);
        }
        public void StartConsumeInInventory(VR4PlayerHand inventoryScreenHand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, inventoryScreenHand);
            CallRaw("StartConsumeInInventory", __pb.Bytes);
        }
        public void ShrinkOutro__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShrinkOutro__FinishedFunc", __pb.Bytes);
        }
        public void ShrinkOutro__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShrinkOutro__UpdateFunc", __pb.Bytes);
        }
        public void OnItemUseStart()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnItemUseStart", __pb.Bytes);
        }
        public void OnItemUseCancelled()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnItemUseCancelled", __pb.Bytes);
        }
        public void OnItemUseFinished(EConsumableUseResult Result)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Result);
            CallRaw("OnItemUseFinished", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void SetupLocators()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupLocators", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_1_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_1_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void ParentOnGrabbed(VR4PlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("ParentOnGrabbed", __pb.Bytes);
        }
        public void ParentOnReleased(VR4PlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("ParentOnReleased", __pb.Bytes);
        }
        public void PlayUseOutro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayUseOutro", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_2_GripHandEventMulticastDelegate__DelegateSignature(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("BndEvt__PrimaryGrip_K2Node_ComponentBoundEvent_2_GripHandEventMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void OnSpawnFlyText(VR4PlayerHand Hand, System.IntPtr Text)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, Hand);
            __pb.Set<System.IntPtr>(0x8, Text);
            CallRaw("OnSpawnFlyText", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4Consumable_Base(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4Consumable_Base", __pb.Bytes);
        }
        public void ItemUseStarted__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ItemUseStarted__DelegateSignature", __pb.Bytes);
        }
    }

}
