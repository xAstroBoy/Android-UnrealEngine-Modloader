// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/AttacheItem_BP
using System;

namespace UEModLoader.Game
{
    public class AttacheItem_BP_C : AttacheItem
    {
        public const string UeClassName = "AttacheItem_BP_C";
        public AttacheItem_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new AttacheItem_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AttacheItem_BP_C(p);
        public static AttacheItem_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AttacheItem_BP_C(o.Pointer); }
        public static AttacheItem_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AttacheItem_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AttacheItem_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x340));
        public SkeletalMeshComponent SkeletalMesh { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent GenericGrabbedHandPose { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent PrimaryGripGrabbedHandPose { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGrip PrimaryGrip { get { var __p = GetAt<global::System.IntPtr>(0x360); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGrip(__p); } set => SetAt(0x360, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent LowResMesh { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GenericLocator PrimaryGripControllerLocatorRight { get { var __p = GetAt<global::System.IntPtr>(0x370); return __p==global::System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x370, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GenericLocator PrimaryGripControllerLocatorLeft { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget PrimaryGripIKTarget { get { var __p = GetAt<global::System.IntPtr>(0x380); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x380, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AudioComponent CombineButtonSFX { get { var __p = GetAt<global::System.IntPtr>(0x388); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x388, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent ShadowMesh { get { var __p = GetAt<global::System.IntPtr>(0x390); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x390, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent CombineButton { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<global::System.IntPtr>(0x3A0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public byte Timeline_FlipLinkIcon__Direction_2AB715ED4F020D396FF2ACAC95F37647 { get => GetAt<byte>(0x3A8); set => SetAt(0x3A8, value); }
        public TimelineComponent Timeline_FlipLinkIcon { get { var __p = GetAt<global::System.IntPtr>(0x3B0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> EquipTextures => new TArray<global::System.IntPtr>(AddrOf(0x3B8)); // TArray<UObject*>
        public TArray<global::System.IntPtr> CombineLinkTextures => new TArray<global::System.IntPtr>(AddrOf(0x3C8)); // TArray<UObject*>
        public TArray<global::System.IntPtr> CombineUnlinkTextures => new TArray<global::System.IntPtr>(AddrOf(0x3D8)); // TArray<UObject*>
        public TArray<global::System.IntPtr> CombineMixTextures => new TArray<global::System.IntPtr>(AddrOf(0x3E8)); // TArray<UObject*>
        public float WidgetDefaultScale { get => GetAt<float>(0x3F8); set => SetAt(0x3F8, value); }
        public float WidgetHoverScale { get => GetAt<float>(0x3FC); set => SetAt(0x3FC, value); }
        public float WidgetHoverXOffset { get => GetAt<float>(0x400); set => SetAt(0x400, value); }
        public float HoldDetachStartTime { get => GetAt<float>(0x404); set => SetAt(0x404, value); }
        public float HoldDetachTime { get => GetAt<float>(0x408); set => SetAt(0x408, value); }
        public float AnimationTime { get => GetAt<float>(0x40C); set => SetAt(0x40C, value); }
        public MaterialInstanceDynamic ShadowMaterial { get { var __p = GetAt<global::System.IntPtr>(0x410); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x410, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AttacheItem_CombineWidget_C CombineWidgetRef { get { var __p = GetAt<global::System.IntPtr>(0x418); return __p==global::System.IntPtr.Zero?null:new AttacheItem_CombineWidget_C(__p); } set => SetAt(0x418, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EUISound CombineBuildUp { get => (EUISound)GetAt<byte>(0x420); set => SetAt(0x420, (byte)value); }
        public EUISound CombineFinished { get => (EUISound)GetAt<byte>(0x421); set => SetAt(0x421, (byte)value); }
        public MeshComponent ActiveMeshComponent { get { var __p = GetAt<global::System.IntPtr>(0x428); return __p==global::System.IntPtr.Zero?null:new MeshComponent(__p); } set => SetAt(0x428, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Object ActiveMeshReference { get { var __p = GetAt<global::System.IntPtr>(0x430); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x430, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool UsingGrip { get => Native.GetPropBool(Pointer, "UsingGrip"); set => Native.SetPropBool(Pointer, "UsingGrip", value); }
        public string PrimaryGripIKTargetSocketName => Native.GetPropName(Pointer, "PrimaryGripIKTargetSocketName"); // FName
        public FName PrimaryGripIKTargetSocketName_Raw { get => GetAt<FName>(0x45C); set => SetAt(0x45C, value); }
        public string PrimaryGripControllerLocatorBothSocketName => Native.GetPropName(Pointer, "PrimaryGripControllerLocatorBothSocketName"); // FName
        public FName PrimaryGripControllerLocatorBothSocketName_Raw { get => GetAt<FName>(0x464); set => SetAt(0x464, value); }
        public string PrimaryGripControllerLocatorLeftSocketName => Native.GetPropName(Pointer, "PrimaryGripControllerLocatorLeftSocketName"); // FName
        public FName PrimaryGripControllerLocatorLeftSocketName_Raw { get => GetAt<FName>(0x46C); set => SetAt(0x46C, value); }
        public string PrimaryGripControllerLocatorRightSocketName => Native.GetPropName(Pointer, "PrimaryGripControllerLocatorRightSocketName"); // FName
        public FName PrimaryGripControllerLocatorRightSocketName_Raw { get => GetAt<FName>(0x474); set => SetAt(0x474, value); }
        public global::System.IntPtr HandPoses_LH => AddrOf(0x47C); // struct AttacheItemHandPoseSet
        public global::System.IntPtr HandPoses_RH => AddrOf(0x484); // struct AttacheItemHandPoseSet
        public bool HasLowResMesh { get => Native.GetPropBool(Pointer, "HasLowResMesh"); set => Native.SetPropBool(Pointer, "HasLowResMesh", value); }
        public bool FlippingLinkIcon { get => Native.GetPropBool(Pointer, "FlippingLinkIcon"); set => Native.SetPropBool(Pointer, "FlippingLinkIcon", value); }
        public TimerHandle SeparateTimer => new TimerHandle(AddrOf(0x490));
        public float SeparateLabelTime { get => GetAt<float>(0x498); set => SetAt(0x498, value); }
        public Transform Base_StaticMeshTransform => new Transform(AddrOf(0x4A0));
        public Transform Base_LowResMeshTransform => new Transform(AddrOf(0x4D0));
        public float CombineButtonSize_Default { get => GetAt<float>(0x500); set => SetAt(0x500, value); }
        public float CombineButtonSize_Hovered { get => GetAt<float>(0x504); set => SetAt(0x504, value); }
        public bool HasFlashedCombineIcon { get => Native.GetPropBool(Pointer, "HasFlashedCombineIcon"); set => Native.SetPropBool(Pointer, "HasFlashedCombineIcon", value); }
        public InventoryGridSlot_C CountSlotRef { get { var __p = GetAt<global::System.IntPtr>(0x510); return __p==global::System.IntPtr.Zero?null:new InventoryGridSlot_C(__p); } set => SetAt(0x510, value?.Pointer ?? global::System.IntPtr.Zero); }
        public InventoryGridSlot_C EquipIconRef { get { var __p = GetAt<global::System.IntPtr>(0x518); return __p==global::System.IntPtr.Zero?null:new InventoryGridSlot_C(__p); } set => SetAt(0x518, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool TuneUpVisible { get => Native.GetPropBool(Pointer, "TuneUpVisible"); set => Native.SetPropBool(Pointer, "TuneUpVisible", value); }
        public bool TuneUpCanAfford { get => Native.GetPropBool(Pointer, "TuneUpCanAfford"); set => Native.SetPropBool(Pointer, "TuneUpCanAfford", value); }
        public int CachedRow { get => GetAt<int>(0x524); set => SetAt(0x524, value); }
        public int CachedColumn { get => GetAt<int>(0x528); set => SetAt(0x528, value); }
        public int CachedCorner { get => GetAt<int>(0x52C); set => SetAt(0x52C, value); }
        public bool EnableShadows { get => Native.GetPropBool(Pointer, "EnableShadows"); set => Native.SetPropBool(Pointer, "EnableShadows", value); }
        public bool EnableMesh { get => Native.GetPropBool(Pointer, "EnableMesh"); set => Native.SetPropBool(Pointer, "EnableMesh", value); }
        public bool EnableCombineWidget { get => Native.GetPropBool(Pointer, "EnableCombineWidget"); set => Native.SetPropBool(Pointer, "EnableCombineWidget", value); }
        public Vector HoldModelScale => new Vector(AddrOf(0x534));
        public Object StaticMeshAsset { get { var __p = GetAt<global::System.IntPtr>(0x540); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x540, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Object SkeletalMeshAsset { get { var __p = GetAt<global::System.IntPtr>(0x548); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x548, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool UseHeldScale { get => Native.GetPropBool(Pointer, "UseHeldScale"); set => Native.SetPropBool(Pointer, "UseHeldScale", value); }
        public bool UsingGoldenGunsMaterials { get => Native.GetPropBool(Pointer, "UsingGoldenGunsMaterials"); set => Native.SetPropBool(Pointer, "UsingGoldenGunsMaterials", value); }
        public bool LowResUsingGoldenGunsMaterials { get => Native.GetPropBool(Pointer, "LowResUsingGoldenGunsMaterials"); set => Native.SetPropBool(Pointer, "LowResUsingGoldenGunsMaterials", value); }
        public TArray<global::System.IntPtr> vOriginalMaterials => new TArray<global::System.IntPtr>(AddrOf(0x558)); // TArray<UObject*>
        public TArray<global::System.IntPtr> vOriginalLowResMaterials => new TArray<global::System.IntPtr>(AddrOf(0x568)); // TArray<UObject*>
        public TArray<global::System.IntPtr> vGoldenGunMaterials => new TArray<global::System.IntPtr>(AddrOf(0x578)); // TArray<UObject*>
        public VR4ItemTableRow ItemTableRow => new VR4ItemTableRow(AddrOf(0x588));
        public void SetUsingOverrideMaterials(MeshComponent MeshComponent, bool UsingOverrides, global::System.IntPtr OriginalMaterials, global::System.IntPtr GoldenGunsMaterials, bool ShouldUseOverrides)
        {
            var __pb = new ParamBuffer(73);
            __pb.SetObject(0x0, MeshComponent);
            __pb.Set<byte>(0x8, (byte)(UsingOverrides?1:0));
            __pb.Set<global::System.IntPtr>(0x10, OriginalMaterials);
            __pb.Set<global::System.IntPtr>(0x20, GoldenGunsMaterials);
            __pb.Set<byte>(0x48, (byte)(ShouldUseOverrides?1:0));
            CallRaw("SetUsingOverrideMaterials", __pb.Bytes);
        }
        public void UpdateGoldenGunMaterial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateGoldenGunMaterial", __pb.Bytes);
        }
        public void SetHeldScale(global::System.IntPtr HeldScale)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, HeldScale);
            CallRaw("SetHeldScale", __pb.Bytes);
        }
        public void GetCombineTextures(global::System.IntPtr Textures)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, Textures);
            CallRaw("GetCombineTextures", __pb.Bytes);
        }
        public void GetMeshComponent(MeshComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("GetMeshComponent", __pb.Bytes);
        }
        public void GetCornerInfo(int ItemCorner, int row, int Column, int corner)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, ItemCorner);
            __pb.Set(0x4, row);
            __pb.Set(0x8, Column);
            __pb.Set(0xC, corner);
            CallRaw("GetCornerInfo", __pb.Bytes);
        }
        public void Hide_Tune_Up_Widget(bool KeepState)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(KeepState?1:0));
            CallRaw("Hide Tune Up Widget", __pb.Bytes);
        }
        public void GetTuneUpCorner(int row, int Column, int corner, InventoryUiManager_C UIManager)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.Set(0x8, corner);
            __pb.SetObject(0x10, UIManager);
            CallRaw("GetTuneUpCorner", __pb.Bytes);
        }
        public void ShowTuneUpWidget(bool CanAfford)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(CanAfford?1:0));
            CallRaw("ShowTuneUpWidget", __pb.Bytes);
        }
        public void UpdateShadowPosition()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateShadowPosition", __pb.Bytes);
        }
        public void GetShadowInfo(float OffsetX, float OffsetY, float ScaleX, float ScaleY)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, OffsetX);
            __pb.Set(0x4, OffsetY);
            __pb.Set(0x8, ScaleX);
            __pb.Set(0xC, ScaleY);
            CallRaw("GetShadowInfo", __pb.Bytes);
        }
        public void HideEquipIcon(bool instant)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(instant?1:0));
            CallRaw("HideEquipIcon", __pb.Bytes);
        }
        public void GetCountIconCorner(bool UseCached, int row, int Column, int corner, int Count, bool AlwaysShow, InventoryUiManager_C UIManager)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<byte>(0x0, (byte)(UseCached?1:0));
            __pb.Set(0x4, row);
            __pb.Set(0x8, Column);
            __pb.Set(0xC, corner);
            __pb.Set(0x10, Count);
            __pb.Set<byte>(0x14, (byte)(AlwaysShow?1:0));
            __pb.SetObject(0x18, UIManager);
            CallRaw("GetCountIconCorner", __pb.Bytes);
        }
        public void GetCombineIconCorner(int row, int Column, int corner, InventoryUiManager_C UIManager)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.Set(0x8, corner);
            __pb.SetObject(0x10, UIManager);
            CallRaw("GetCombineIconCorner", __pb.Bytes);
        }
        public void GetEquipIconCorner(int row, int Column, int corner, InventoryUiManager_C UIManager)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.Set(0x8, corner);
            __pb.SetObject(0x10, UIManager);
            CallRaw("GetEquipIconCorner", __pb.Bytes);
        }
        public void UpdateTravelMesh()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateTravelMesh", __pb.Bytes);
        }
        public void StateChanged(EAttacheItemState PrevState, EAttacheItemState currentState)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)PrevState);
            __pb.Set<byte>(0x1, (byte)currentState);
            CallRaw("StateChanged", __pb.Bytes);
        }
        public void GetHandPoseSet(EHandedness Hand, global::System.IntPtr HandPoseSet)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<byte>(0x0, (byte)Hand);
            __pb.Set<global::System.IntPtr>(0x4, HandPoseSet);
            CallRaw("GetHandPoseSet", __pb.Bytes);
        }
        public void SetUpControllerLocator(SceneComponent SocketOwner, global::System.IntPtr SocketNames, SceneComponent Locator, SceneComponent LocatorUsed)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, SocketOwner);
            __pb.Set<global::System.IntPtr>(0x8, SocketNames);
            __pb.SetObject(0x18, Locator);
            __pb.SetObject(0x20, LocatorUsed);
            CallRaw("SetUpControllerLocator", __pb.Bytes);
        }
        public void IsHoveredByAttachedItem(bool Result, EVR4PartAttachColor Color)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(Result?1:0));
            __pb.Set<byte>(0x1, (byte)Color);
            CallRaw("IsHoveredByAttachedItem", __pb.Bytes);
        }
        public void ResetCombineWidgetFill()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetCombineWidgetFill", __pb.Bytes);
        }
        public void UpdateDetachFill()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateDetachFill", __pb.Bytes);
        }
        public void UpdateCountWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateCountWidget", __pb.Bytes);
        }
        public void UpdateCombineWidget(EVR4PartAttachColor Color, bool Unlink)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Color);
            __pb.Set<byte>(0x1, (byte)(Unlink?1:0));
            CallRaw("UpdateCombineWidget", __pb.Bytes);
        }
        public void UpdateWidgetTransforms()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateWidgetTransforms", __pb.Bytes);
        }
        public void GetHighlightColor(EAttacheItemState State, global::System.IntPtr Color)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<byte>(0x0, (byte)State);
            __pb.Set<global::System.IntPtr>(0x4, Color);
            CallRaw("GetHighlightColor", __pb.Bytes);
        }
        public void UpdateStateFX(EAttacheItemState ItemState)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)ItemState);
            CallRaw("UpdateStateFX", __pb.Bytes);
        }
        public void InitializeShadow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeShadow", __pb.Bytes);
        }
        public void Initialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void Timeline_FlipLinkIcon__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FlipLinkIcon__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_FlipLinkIcon__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FlipLinkIcon__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_FlipLinkIcon__Flip__EventFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FlipLinkIcon__Flip__EventFunc", __pb.Bytes);
        }
        public void OnLoaded_FD5A02AD49E19AC05C6C1BA09A065C80(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_FD5A02AD49E19AC05C6C1BA09A065C80", __pb.Bytes);
        }
        public void OnLoaded_2739CE5B4000E7565B3C0287B7936296(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_2739CE5B4000E7565B3C0287B7936296", __pb.Bytes);
        }
        public void OnLoaded_4B17292D43C01997899B469D3E9C3024(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_4B17292D43C01997899B469D3E9C3024", __pb.Bytes);
        }
        public void OnLoaded_E05A2DD940BE6775A9B25BB74B861D59(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_E05A2DD940BE6775A9B25BB74B861D59", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void Event_OnStateChanged(EAttacheItemState previousState, EAttacheItemState currentState)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)previousState);
            __pb.Set<byte>(0x1, (byte)currentState);
            CallRaw("Event OnStateChanged", __pb.Bytes);
        }
        public void OnItemEquipped(EPropSlot Slot)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Slot);
            CallRaw("OnItemEquipped", __pb.Bytes);
        }
        public void OnItemUnequipped(EPropSlot Slot)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Slot);
            CallRaw("OnItemUnequipped", __pb.Bytes);
        }
        public void UpdateWidgets()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateWidgets", __pb.Bytes);
        }
        public void UpdateMesh()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateMesh", __pb.Bytes);
        }
        public void Load_Mesh()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Load Mesh", __pb.Bytes);
        }
        public void OnItemDetached()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnItemDetached", __pb.Bytes);
        }
        public void BndEvt__CombineButton_K2Node_ComponentBoundEvent_1_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__CombineButton_K2Node_ComponentBoundEvent_1_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void BndEvt__CombineButton_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__CombineButton_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__CombineButton_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__CombineButton_K2Node_ComponentBoundEvent_3_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__CombineButton_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__CombineButton_K2Node_ComponentBoundEvent_5_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__CombineButton_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__CombineButton_K2Node_ComponentBoundEvent_6_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void UpdateWidgets2()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateWidgets2", __pb.Bytes);
        }
        public void UpdateMesh2()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateMesh2", __pb.Bytes);
        }
        public void LoadShadow(global::System.IntPtr ShadowTexture)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<global::System.IntPtr>(0x0, ShadowTexture);
            CallRaw("LoadShadow", __pb.Bytes);
        }
        public void OnGrabbedByHand(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("OnGrabbedByHand", __pb.Bytes);
        }
        public void OnReleasedByHand(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("OnReleasedByHand", __pb.Bytes);
        }
        public void StartFlippingLinkIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartFlippingLinkIcon", __pb.Bytes);
        }
        public void StopFlippingLinkIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopFlippingLinkIcon", __pb.Bytes);
        }
        public void OnStoppedTraveling()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnStoppedTraveling", __pb.Bytes);
        }
        public void ShowSeparateLabel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowSeparateLabel", __pb.Bytes);
        }
        public void HideSeparateLabel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideSeparateLabel", __pb.Bytes);
        }
        public void StartShowingWidgets()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartShowingWidgets", __pb.Bytes);
        }
        public void StopShowingWidgets()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopShowingWidgets", __pb.Bytes);
        }
        public void UpdateMeshScale(float T)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, T);
            CallRaw("UpdateMeshScale", __pb.Bytes);
        }
        public void TryEnterInventoryNormalState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TryEnterInventoryNormalState", __pb.Bytes);
        }
        public void OnItemCombined(EVR4ItemCombineType combineType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)combineType);
            CallRaw("OnItemCombined", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void OnPlayerSettingsChanged(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("OnPlayerSettingsChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_AttacheItem_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_AttacheItem_BP", __pb.Bytes);
        }
    }

}
