// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Bio4/VR4Bio4PlayerPawn_BP
using System;

namespace UEModLoader.Game
{
    public class VR4Bio4PlayerPawn_BP_C : VR4Bio4PlayerPawn
    {
        public const string UeClassName = "VR4Bio4PlayerPawn_BP_C";
        public VR4Bio4PlayerPawn_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4Bio4PlayerPawn_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4Bio4PlayerPawn_BP_C(p);
        public static VR4Bio4PlayerPawn_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4Bio4PlayerPawn_BP_C(o.Pointer); }
        public static VR4Bio4PlayerPawn_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4Bio4PlayerPawn_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4Bio4PlayerPawn_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x1650));
        public StaticMeshComponent TriggerSphere { get { var __p = GetAt<System.IntPtr>(0x1658); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x1658, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent NightLight { get { var __p = GetAt<System.IntPtr>(0x1660); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x1660, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4ActionCameraComponent VR4ActionCamera { get { var __p = GetAt<System.IntPtr>(0x1668); return __p==System.IntPtr.Zero?null:new VR4ActionCameraComponent(__p); } set => SetAt(0x1668, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_ShrinkLureHead_SetMesh_A816D9074B985917104BFEB1621F54BA { get => GetAt<float>(0x1670); set => SetAt(0x1670, value); }
        public float Timeline_ShrinkLureHead_Scale_A816D9074B985917104BFEB1621F54BA { get => GetAt<float>(0x1674); set => SetAt(0x1674, value); }
        public byte Timeline_ShrinkLureHead__Direction_A816D9074B985917104BFEB1621F54BA { get => GetAt<byte>(0x1678); set => SetAt(0x1678, value); }
        public TimelineComponent Timeline_ShrinkLureHead { get { var __p = GetAt<System.IntPtr>(0x1680); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x1680, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_GrowLureHead_SetMesh_BE17B3E84D090E434F921BA1865BFDA1 { get => GetAt<float>(0x1688); set => SetAt(0x1688, value); }
        public float Timeline_GrowLureHead_Scale_BE17B3E84D090E434F921BA1865BFDA1 { get => GetAt<float>(0x168C); set => SetAt(0x168C, value); }
        public byte Timeline_GrowLureHead__Direction_BE17B3E84D090E434F921BA1865BFDA1 { get => GetAt<byte>(0x1690); set => SetAt(0x1690, value); }
        public TimelineComponent Timeline_GrowLureHead { get { var __p = GetAt<System.IntPtr>(0x1698); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x1698, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_DamageFlinch_HandApproachAlpha_371388334C48F238A776C59378D6DA28 { get => GetAt<float>(0x16A0); set => SetAt(0x16A0, value); }
        public byte Timeline_DamageFlinch__Direction_371388334C48F238A776C59378D6DA28 { get => GetAt<byte>(0x16A4); set => SetAt(0x16A4, value); }
        public TimelineComponent Timeline_DamageFlinch { get { var __p = GetAt<System.IntPtr>(0x16A8); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x16A8, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr OpaqueMaterials => AddrOf(0x16B0); // 
        public System.IntPtr TranslucentMaterials => AddrOf(0x1700); // 
        public Vector LastHeadPos => new Vector(AddrOf(0x1750));
        public Actor watchActor { get { var __p = GetAt<System.IntPtr>(0x1760); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x1760, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_HealthVignette_BP_C HealthHud { get { var __p = GetAt<System.IntPtr>(0x1768); return __p==System.IntPtr.Zero?null:new UI_HealthVignette_BP_C(__p); } set => SetAt(0x1768, value?.Pointer ?? System.IntPtr.Zero); }
        public WeaponWheel_C WeaponWheel { get { var __p = GetAt<System.IntPtr>(0x1770); return __p==System.IntPtr.Zero?null:new WeaponWheel_C(__p); } set => SetAt(0x1770, value?.Pointer ?? System.IntPtr.Zero); }
        public TimerHandle WheelTimer => new TimerHandle(AddrOf(0x1778));
        public bool HasPathfindDestination { get => Native.GetPropBool(Pointer, "HasPathfindDestination"); set => Native.SetPropBool(Pointer, "HasPathfindDestination", value); }
        public Vector PathfindDestination => new Vector(AddrOf(0x1784));
        public TArray<System.IntPtr> PathfindingPositions => new TArray<System.IntPtr>(AddrOf(0x1790)); // TArray<struct>
        public TArray<System.IntPtr> ArcPositions => new TArray<System.IntPtr>(AddrOf(0x17A0)); // TArray<struct>
        public Vector PathfindDestinationNormal => new Vector(AddrOf(0x17B0));
        public TArray<System.IntPtr> SplineMeshes => new TArray<System.IntPtr>(AddrOf(0x17C0)); // TArray<UObject*>
        public CurveFloat VerticalSpeedCurve { get { var __p = GetAt<System.IntPtr>(0x17D0); return __p==System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x17D0, value?.Pointer ?? System.IntPtr.Zero); }
        public bool BigLureHead { get => Native.GetPropBool(Pointer, "BigLureHead"); set => Native.SetPropBool(Pointer, "BigLureHead", value); }
        public bool PathfindingDestinationInView { get => Native.GetPropBool(Pointer, "PathfindingDestinationInView"); set => Native.SetPropBool(Pointer, "PathfindingDestinationInView", value); }
        public float PathLureVerticalOffset { get => GetAt<float>(0x17DC); set => SetAt(0x17DC, value); }
        public bool DisableQuickSelect { get => Native.GetPropBool(Pointer, "DisableQuickSelect"); set => Native.SetPropBool(Pointer, "DisableQuickSelect", value); }
        public SoundMix LastMixModifier { get { var __p = GetAt<System.IntPtr>(0x17E8); return __p==System.IntPtr.Zero?null:new SoundMix(__p); } set => SetAt(0x17E8, value?.Pointer ?? System.IntPtr.Zero); }
        public UObject Watch { get { var __p = GetAt<System.IntPtr>(0x17F0); return __p==System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x17F0, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr WeaponWheelCreated => AddrOf(0x1800); // 
        public bool DisableWeaponToggle { get => Native.GetPropBool(Pointer, "DisableWeaponToggle"); set => Native.SetPropBool(Pointer, "DisableWeaponToggle", value); }
        public bool DisableWheel { get => Native.GetPropBool(Pointer, "DisableWheel"); set => Native.SetPropBool(Pointer, "DisableWheel", value); }
        public bool SprayTutorialActive { get => Native.GetPropBool(Pointer, "SprayTutorialActive"); set => Native.SetPropBool(Pointer, "SprayTutorialActive", value); }
        public System.IntPtr TutorialPerHandStateLH => AddrOf(0x1813); // struct VR4TutorialPlayerPawnPerHandState
        public System.IntPtr TutorialPerHandStateRH => AddrOf(0x1815); // struct VR4TutorialPlayerPawnPerHandState
        public bool WheelFilled { get => Native.GetPropBool(Pointer, "WheelFilled"); set => Native.SetPropBool(Pointer, "WheelFilled", value); }
        public bool QsTriggerPressed { get => Native.GetPropBool(Pointer, "QsTriggerPressed"); set => Native.SetPropBool(Pointer, "QsTriggerPressed", value); }
        public TimerHandle NewEquipmentTimer => new TimerHandle(AddrOf(0x1820));
        public TArray<System.IntPtr> WeaponTutorials => new TArray<System.IntPtr>(AddrOf(0x1828)); // TArray<UObject*>
        public TutorialHelper_C FirstShotgunTutorial { get { var __p = GetAt<System.IntPtr>(0x1838); return __p==System.IntPtr.Zero?null:new TutorialHelper_C(__p); } set => SetAt(0x1838, value?.Pointer ?? System.IntPtr.Zero); }
        public string TutorialCacheName => Native.GetPropName(Pointer, "TutorialCacheName"); // FName
        public FName TutorialCacheName_Raw { get => GetAt<FName>(0x1840); set => SetAt(0x1840, value); }
        public TArray<System.IntPtr> FireParticles => new TArray<System.IntPtr>(AddrOf(0x1848)); // TArray<UObject*>
        public float MaxTeleportDistance { get => GetAt<float>(0x1858); set => SetAt(0x1858, value); }
        public UI_HealthVignette_BP_C HealthUI { get { var __p = GetAt<System.IntPtr>(0x1860); return __p==System.IntPtr.Zero?null:new UI_HealthVignette_BP_C(__p); } set => SetAt(0x1860, value?.Pointer ?? System.IntPtr.Zero); }
        public bool QsCanToggle { get => Native.GetPropBool(Pointer, "QsCanToggle"); set => Native.SetPropBool(Pointer, "QsCanToggle", value); }
        public void IsHandVisibleForTutorial(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("IsHandVisibleForTutorial", __pb.Bytes);
        }
        public void GetForcePropVisibleForTutorial(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("GetForcePropVisibleForTutorial", __pb.Bytes);
        }
        public void SetupWildWestProps()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupWildWestProps", __pb.Bytes);
        }
        public void UpdateLureArcPointCount()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateLureArcPointCount", __pb.Bytes);
        }
        public void ClearWheelFilledIfTriggerNotHeld()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearWheelFilledIfTriggerNotHeld", __pb.Bytes);
        }
        public void CheckForDeferredQSTriggerPress()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckForDeferredQSTriggerPress", __pb.Bytes);
        }
        public void GetActorsToHideFromScopeView(System.IntPtr OutActors)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, OutActors);
            CallRaw("GetActorsToHideFromScopeView", __pb.Bytes);
        }
        public void Apply_Stun_Data(EPlayerStunType stunType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)stunType);
            CallRaw("Apply Stun Data", __pb.Bytes);
        }
        public void OpenMap(EHandedness Hand)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Hand);
            CallRaw("OpenMap", __pb.Bytes);
        }
        public void ExecuteQuickTeleport(Vector Direction, float Distance)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Direction);
            __pb.Set(0xC, Distance);
            CallRaw("ExecuteQuickTeleport", __pb.Bytes);
        }
        public void ApplyMaterials(PrimitiveComponent TargetMesh, System.IntPtr Materials)
        {
            var __pb = new ParamBuffer(88);
            __pb.SetObject(0x0, TargetMesh);
            __pb.Set<System.IntPtr>(0x8, Materials);
            CallRaw("ApplyMaterials", __pb.Bytes);
        }
        public void GetMaterials(MeshComponent SourceMesh, System.IntPtr MaterialSlotList, System.IntPtr Map)
        {
            var __pb = new ParamBuffer(104);
            __pb.SetObject(0x0, SourceMesh);
            __pb.Set<System.IntPtr>(0x8, MaterialSlotList);
            __pb.Set<System.IntPtr>(0x18, Map);
            CallRaw("GetMaterials", __pb.Bytes);
        }
        public void ClearTutorials()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearTutorials", __pb.Bytes);
        }
        public void RefreshTutorialList()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RefreshTutorialList", __pb.Bytes);
        }
        public bool CalculatePropVisibility(EHandedness Handedness)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            CallRaw("CalculatePropVisibility", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        public void GetForcePropVisibleForTutorialInternal(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("GetForcePropVisibleForTutorialInternal", __pb.Bytes);
        }
        public void SetForcePropVisibleForTutorialInternal(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("SetForcePropVisibleForTutorialInternal", __pb.Bytes);
        }
        public void IsHandVisibleForTutorialInternal(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("IsHandVisibleForTutorialInternal", __pb.Bytes);
        }
        public void SetHandVisibleForTutorialInternal(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("SetHandVisibleForTutorialInternal", __pb.Bytes);
        }
        public bool CalculateMeshVisibility(EHandedness Handedness)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            CallRaw("CalculateMeshVisibility", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        public bool IsQuickSelectMenuAllowed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsQuickSelectMenuAllowed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void SpawnSensors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnSensors", __pb.Bytes);
        }
        public void SpawnWatch(VR4PlayerPawn Pawn, SkeletalMeshComponent Mesh, Actor Actor, UObject Interface)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, Pawn);
            __pb.SetObject(0x8, Mesh);
            __pb.SetObject(0x10, Actor);
            __pb.SetObject(0x18, Interface);
            CallRaw("SpawnWatch", __pb.Bytes);
        }
        public void DisableWeaponWheel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableWeaponWheel", __pb.Bytes);
        }
        public void ExecuteLure()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ExecuteLure", __pb.Bytes);
        }
        public void Update_Lure(bool Beginning, Vector2D localInput, VR4GamePlayerHand lureHand)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<byte>(0x0, (byte)(Beginning?1:0));
            __pb.Set<System.IntPtr>(0x4, localInput);
            __pb.SetObject(0x10, lureHand);
            CallRaw("Update Lure", __pb.Bytes);
        }
        public bool ShouldTeleportToPathfindDestination()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("ShouldTeleportToPathfindDestination", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void Set_Hand_Damage_Alpha(float alpha)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, alpha);
            CallRaw("Set Hand Damage Alpha", __pb.Bytes);
        }
        public void DestroyWheel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyWheel", __pb.Bytes);
        }
        public void SetPlayerVisible(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("SetPlayerVisible", __pb.Bytes);
        }
        public void UpdateUi()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateUi", __pb.Bytes);
        }
        public void DestroyUI()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyUI", __pb.Bytes);
        }
        public void SpawnUI()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnUI", __pb.Bytes);
        }
        public void Initialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void Timeline_DamageFlinch__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_DamageFlinch__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_DamageFlinch__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_DamageFlinch__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_GrowLureHead__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_GrowLureHead__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_GrowLureHead__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_GrowLureHead__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_ShrinkLureHead__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ShrinkLureHead__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ShrinkLureHead__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ShrinkLureHead__UpdateFunc", __pb.Bytes);
        }
        public void InpActEvt__R__Trigger_K2Node_InputActionEvent_5(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Trigger_K2Node_InputActionEvent_5", __pb.Bytes);
        }
        public void InpActEvt__R__Trigger_K2Node_InputActionEvent_4(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Trigger_K2Node_InputActionEvent_4", __pb.Bytes);
        }
        public void InpActEvt__L__Trigger_K2Node_InputActionEvent_3(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Trigger_K2Node_InputActionEvent_3", __pb.Bytes);
        }
        public void InpActEvt__L__Trigger_K2Node_InputActionEvent_2(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Trigger_K2Node_InputActionEvent_2", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_1(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_1", __pb.Bytes);
        }
        public void InpActEvt_Button_X_K2Node_InputActionEvent_0(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button X_K2Node_InputActionEvent_0", __pb.Bytes);
        }
        public void SetHandVisibleForTutorial(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("SetHandVisibleForTutorial", __pb.Bytes);
        }
        public void SetForcePropVisibleForTutorial(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("SetForcePropVisibleForTutorial", __pb.Bytes);
        }
        public void PropAssigned(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("PropAssigned", __pb.Bytes);
        }
        public void CheckNewEquipment(float Time)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Time);
            CallRaw("CheckNewEquipment", __pb.Bytes);
        }
        public void NewEquipmentTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("NewEquipmentTimerExpired", __pb.Bytes);
        }
        public void PropGrabbed(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("PropGrabbed", __pb.Bytes);
        }
        public void ShotgunReleased(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("ShotgunReleased", __pb.Bytes);
        }
        public void SpawnFirstShotgunTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnFirstShotgunTutorial", __pb.Bytes);
        }
        public void WaitForShotgunReleased()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WaitForShotgunReleased", __pb.Bytes);
        }
        public void OnCameraModeChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnCameraModeChanged", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnBeginActivePlayerPawn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnBeginActivePlayerPawn", __pb.Bytes);
        }
        public void OnEndActivePlayerPawn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnEndActivePlayerPawn", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void CreateWeaponwheel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateWeaponwheel", __pb.Bytes);
        }
        public void PlayHandFlourish(EHandedness Hand)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Hand);
            CallRaw("PlayHandFlourish", __pb.Bytes);
        }
        public void OnStunnedChanged(EPlayerStunType stunType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)stunType);
            CallRaw("OnStunnedChanged", __pb.Bytes);
        }
        public void PlayDamageFlinch()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayDamageFlinch", __pb.Bytes);
        }
        public void OnWaggleUpdated()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnWaggleUpdated", __pb.Bytes);
        }
        public void BeginPathfindingLure(Vector2D localInput, VR4GamePlayerHand lureHand)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, localInput);
            __pb.SetObject(0x8, lureHand);
            CallRaw("BeginPathfindingLure", __pb.Bytes);
        }
        public void UpdatePathfindingLure(Vector2D localInput, VR4GamePlayerHand lureHand)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, localInput);
            __pb.SetObject(0x8, lureHand);
            CallRaw("UpdatePathfindingLure", __pb.Bytes);
        }
        public void FinishPathfindingLure()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FinishPathfindingLure", __pb.Bytes);
        }
        public void CancelPathfindingLure()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CancelPathfindingLure", __pb.Bytes);
        }
        public void GrowLureHead(bool instant)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(instant?1:0));
            CallRaw("GrowLureHead", __pb.Bytes);
        }
        public void ShrinkLureHead(bool instant)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(instant?1:0));
            CallRaw("ShrinkLureHead", __pb.Bytes);
        }
        public void OnQuickTurnQueued()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnQuickTurnQueued", __pb.Bytes);
        }
        public void OnHandsCreated()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnHandsCreated", __pb.Bytes);
        }
        public void OnReceivedHandsPropsAndHolsters()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnReceivedHandsPropsAndHolsters", __pb.Bytes);
        }
        public void OnVisibilityChanged(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("OnVisibilityChanged", __pb.Bytes);
        }
        public void OnMeshVisibilityChanged(EHandedness Hand, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Hand);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("OnMeshVisibilityChanged", __pb.Bytes);
        }
        public void ClearFireParticles()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearFireParticles", __pb.Bytes);
        }
        public void PrepareToLoseHandsPropsAndHolsters()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PrepareToLoseHandsPropsAndHolsters", __pb.Bytes);
        }
        public void DeferredQSTriggerPress()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DeferredQSTriggerPress", __pb.Bytes);
        }
        public void RegularGameplayActiveChanged(bool Active)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Active?1:0));
            CallRaw("RegularGameplayActiveChanged", __pb.Bytes);
        }
        public void QuickTeleport(Vector Direction, float Distance)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Direction);
            __pb.Set(0xC, Distance);
            CallRaw("QuickTeleport", __pb.Bytes);
        }
        public void SetupWildWest()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupWildWest", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4Bio4PlayerPawn_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4Bio4PlayerPawn_BP", __pb.Bytes);
        }
        public void WeaponWheelCreated__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WeaponWheelCreated__DelegateSignature", __pb.Bytes);
        }
    }

}
