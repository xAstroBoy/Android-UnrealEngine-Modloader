// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PauseMenu/KeysAndTreasures/Blueprints/UI_Treasure_Item_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Treasure_Item_BP_C : Actor
    {
        public const string UeClassName = "UI_Treasure_Item_BP_C";
        public UI_Treasure_Item_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Treasure_Item_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Treasure_Item_BP_C(p);
        public static UI_Treasure_Item_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Treasure_Item_BP_C(o.Pointer); }
        public static UI_Treasure_Item_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Treasure_Item_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Treasure_Item_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SpotLightComponent SpotLight { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SpotLightComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent LightMesh { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent GenericGrabbedHandPose { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SkeletalMeshComponent SkeletalMesh { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent CombineIndicator { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGripIKTarget PrimaryGripIKTarget { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGripIKTarget(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GenericLocator PrimaryGripControllerLocatorRight { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GenericLocator PrimaryGripControllerLocatorLeft { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new GenericLocator(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4GamePlayerGrip PrimaryGrip { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerGrip(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent GrabButton { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent CountGroup { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent CountIndicator { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent NextButton { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Transform ModelTransform => new Transform(AddrOf(0x2A0));
        public Vector HeldModelExtraScale => new Vector(AddrOf(0x2D0));
        public global::System.IntPtr Models => AddrOf(0x2E0); // 
        public int CurrentItemId { get => GetAt<int>(0x330); set => SetAt(0x330, value); }
        public int CurrentItemIndex { get => GetAt<int>(0x334); set => SetAt(0x334, value); }
        public TArray<global::System.IntPtr> Items => new TArray<global::System.IntPtr>(AddrOf(0x338)); // TArray<int32>
        public UI_KeysTreasures_Count_Widget_C CountIndicatorWidget { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new UI_KeysTreasures_Count_Widget_C(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AttacheItem_CombineWidget_C CombineIndicatorWidget { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new AttacheItem_CombineWidget_C(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_KeysTreasures_Sold_Widget_C SoldIndicatorWidget { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new UI_KeysTreasures_Sold_Widget_C(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr SkeletalModels => AddrOf(0x360); // 
        public Transform CountIndicatorTransform => new Transform(AddrOf(0x3B0));
        public Transform GrabButtonTransform => new Transform(AddrOf(0x3E0));
        public UI_Button_BP_C Ref_NextButton { get { var __p = GetAt<global::System.IntPtr>(0x410); return __p==global::System.IntPtr.Zero?null:new UI_Button_BP_C(__p); } set => SetAt(0x410, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_KeysTreasures_Grab_Button_BP_C Ref_GrabButton { get { var __p = GetAt<global::System.IntPtr>(0x418); return __p==global::System.IntPtr.Zero?null:new UI_KeysTreasures_Grab_Button_BP_C(__p); } set => SetAt(0x418, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Transform HoldOffset => new Transform(AddrOf(0x420));
        public Vector2D GrabButtonSize => new Vector2D(AddrOf(0x450));
        public VR4UIScreen Screen { get { var __p = GetAt<global::System.IntPtr>(0x458); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x458, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4PausePlayerHand_BP_C GrabbedHand { get { var __p = GetAt<global::System.IntPtr>(0x460); return __p==global::System.IntPtr.Zero?null:new VR4PausePlayerHand_BP_C(__p); } set => SetAt(0x460, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Transform PreGrabbedTransform => new Transform(AddrOf(0x470));
        public VR4ItemHandle ItemHandle => new VR4ItemHandle(AddrOf(0x4A0));
        public bool ValidHandle { get => Native.GetPropBool(Pointer, "ValidHandle"); set => Native.SetPropBool(Pointer, "ValidHandle", value); }
        public global::System.IntPtr OnGrabHovered => AddrOf(0x4B0); // 
        public global::System.IntPtr OnGrabbed => AddrOf(0x4C0); // 
        public global::System.IntPtr OnDropped => AddrOf(0x4D0); // 
        public global::System.IntPtr OnGrabUnHovered => AddrOf(0x4E0); // 
        public bool HasItem { get => Native.GetPropBool(Pointer, "HasItem"); set => Native.SetPropBool(Pointer, "HasItem", value); }
        public bool DisableHandWhenGrabbed { get => Native.GetPropBool(Pointer, "DisableHandWhenGrabbed"); set => Native.SetPropBool(Pointer, "DisableHandWhenGrabbed", value); }
        public bool IsKey { get => Native.GetPropBool(Pointer, "IsKey"); set => Native.SetPropBool(Pointer, "IsKey", value); }
        public global::System.IntPtr SoldText => AddrOf(0x4F8); // 
        public global::System.IntPtr UsedText => AddrOf(0x510); // 
        public byte SoundId { get => GetAt<byte>(0x528); set => SetAt(0x528, value); }
        public bool PlayedSound { get => Native.GetPropBool(Pointer, "PlayedSound"); set => Native.SetPropBool(Pointer, "PlayedSound", value); }
        public global::System.IntPtr OnPlaySound => AddrOf(0x530); // 
        public bool ShowIfHasPossessed { get => Native.GetPropBool(Pointer, "ShowIfHasPossessed"); set => Native.SetPropBool(Pointer, "ShowIfHasPossessed", value); }
        public global::System.IntPtr ModelExtraText => AddrOf(0x548); // 
        public SoundBase GrabSound { get { var __p = GetAt<global::System.IntPtr>(0x598); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x598, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoundBase DroppedSound { get { var __p = GetAt<global::System.IntPtr>(0x5A0); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x5A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SoundBase CombineSound { get { var __p = GetAt<global::System.IntPtr>(0x5A8); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x5A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AttacheItem AttacheItem { get { var __p = GetAt<global::System.IntPtr>(0x5B0); return __p==global::System.IntPtr.Zero?null:new AttacheItem(__p); } set => SetAt(0x5B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AttacheCase AttacheCase { get { var __p = GetAt<global::System.IntPtr>(0x5B8); return __p==global::System.IntPtr.Zero?null:new AttacheCase(__p); } set => SetAt(0x5B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public InventoryUIScreen_BP_C InventoryUIScreen { get { var __p = GetAt<global::System.IntPtr>(0x5C0); return __p==global::System.IntPtr.Zero?null:new InventoryUIScreen_BP_C(__p); } set => SetAt(0x5C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Rotator StickRotation => new Rotator(AddrOf(0x5C8));
        public float StickRotationSpeed { get => GetAt<float>(0x5D4); set => SetAt(0x5D4, value); }
        public Vector StickRotVec => new Vector(AddrOf(0x5D8));
        public float FlyAlpha { get => GetAt<float>(0x5E4); set => SetAt(0x5E4, value); }
        public bool Flying { get => Native.GetPropBool(Pointer, "Flying"); set => Native.SetPropBool(Pointer, "Flying", value); }
        public Transform StartFlyTransform => new Transform(AddrOf(0x5F0));
        public Transform FlyTargetTransform => new Transform(AddrOf(0x620));
        public bool Debug { get => Native.GetPropBool(Pointer, "Debug"); set => Native.SetPropBool(Pointer, "Debug", value); }
        public SceneComponent LightComponent { get { var __p = GetAt<global::System.IntPtr>(0x658); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x658, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMesh LightModel { get { var __p = GetAt<global::System.IntPtr>(0x660); return __p==global::System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x660, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Transform LightTransform => new Transform(AddrOf(0x670));
        public bool AddSpotLight { get => Native.GetPropBool(Pointer, "AddSpotLight"); set => Native.SetPropBool(Pointer, "AddSpotLight", value); }
        public bool OtherItemHeld { get => Native.GetPropBool(Pointer, "OtherItemHeld"); set => Native.SetPropBool(Pointer, "OtherItemHeld", value); }
        public void GetAdjustedGrabButtonTransform(global::System.IntPtr Transform)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<global::System.IntPtr>(0x0, Transform);
            CallRaw("GetAdjustedGrabButtonTransform", __pb.Bytes);
        }
        public void BeginPlayConstruction()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BeginPlayConstruction", __pb.Bytes);
        }
        public void SetToTreasureConfiguration(global::System.IntPtr Configuration)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Configuration);
            CallRaw("SetToTreasureConfiguration", __pb.Bytes);
        }
        public void FlyTo(global::System.IntPtr Target)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<global::System.IntPtr>(0x0, Target);
            CallRaw("FlyTo", __pb.Bytes);
        }
        public void UpdateFly(float DT)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DT);
            CallRaw("UpdateFly", __pb.Bytes);
        }
        public void Update_Item_Rotation(Actor Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("Update Item Rotation", __pb.Bytes);
        }
        public void DestroyAttacheItem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyAttacheItem", __pb.Bytes);
        }
        public void PostDropItem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PostDropItem", __pb.Bytes);
        }
        public void DropItem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DropItem", __pb.Bytes);
        }
        public void OnInventoryCancelledMoveItem(AttacheItem AttacheItem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, AttacheItem);
            CallRaw("OnInventoryCancelledMoveItem", __pb.Bytes);
        }
        public void OnInventoryGrabbedItem(AttacheItem AttacheItem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, AttacheItem);
            CallRaw("OnInventoryGrabbedItem", __pb.Bytes);
        }
        public void ShouldDisplayItem(int ID, bool Display)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, ID);
            __pb.Set<byte>(0x4, (byte)(Display?1:0));
            CallRaw("ShouldDisplayItem", __pb.Bytes);
        }
        public void IsGrabbed(bool Grabbed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Grabbed?1:0));
            CallRaw("IsGrabbed", __pb.Bytes);
        }
        public void GrabWithHand(VR4PausePlayerHand_BP_C Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("GrabWithHand", __pb.Bytes);
        }
        public void UpdateAttacheItem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateAttacheItem", __pb.Bytes);
        }
        public void TryDropAttacheItem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TryDropAttacheItem", __pb.Bytes);
        }
        public void TryCreateAttacheItem(VR4PausePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("TryCreateAttacheItem", __pb.Bytes);
        }
        public bool CanBeCombined(bool IsHeldItem)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(IsHeldItem?1:0));
            CallRaw("CanBeCombined", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        public void UpdateSelectedIndex(int PreferedItemId, int OldItemId, global::System.IntPtr OldItemIds)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, PreferedItemId);
            __pb.Set(0x4, OldItemId);
            __pb.Set<global::System.IntPtr>(0x8, OldItemIds);
            CallRaw("UpdateSelectedIndex", __pb.Bytes);
        }
        public void TotalItem_Count(int Count)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Count);
            CallRaw("TotalItem Count", __pb.Bytes);
        }
        public void CombineWithItem(UI_Treasure_Item_BP_C Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("CombineWithItem", __pb.Bytes);
        }
        public void InitializeReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeReferences", __pb.Bytes);
        }
        public void AssignReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AssignReferences", __pb.Bytes);
        }
        public void UserDroppedOtherItem(UI_Treasure_Item_BP_C Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("UserDroppedOtherItem", __pb.Bytes);
        }
        public void UserPickedUpOtherItem(UI_Treasure_Item_BP_C Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("UserPickedUpOtherItem", __pb.Bytes);
        }
        public void HandleGrabUnHovered(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleGrabUnHovered", __pb.Bytes);
        }
        public void HandleGrabHovered(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleGrabHovered", __pb.Bytes);
        }
        public void UpdateUIState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateUIState", __pb.Bytes);
        }
        public void UpdateGrabbed(float DT)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DT);
            CallRaw("UpdateGrabbed", __pb.Bytes);
        }
        public void GrabItem(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("GrabItem", __pb.Bytes);
        }
        public bool HasNext()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasNext", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void NextItem(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("NextItem", __pb.Bytes);
        }
        public void SetToIndex(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("SetToIndex", __pb.Bytes);
        }
        public void SetRegistered(bool Register, VR4UIScreen Screen)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<byte>(0x0, (byte)(Register?1:0));
            __pb.SetObject(0x8, Screen);
            CallRaw("SetRegistered", __pb.Bytes);
        }
        public void EvaluateItem(int PreferredItemId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, PreferredItemId);
            CallRaw("EvaluateItem", __pb.Bytes);
        }
        public void SetToItem(int ItemId, bool SetItemHandle)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, ItemId);
            __pb.Set<byte>(0x4, (byte)(SetItemHandle?1:0));
            CallRaw("SetToItem", __pb.Bytes);
        }
        public void InpActEvt_Button_B_K2Node_InputActionEvent_3(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button B_K2Node_InputActionEvent_3", __pb.Bytes);
        }
        public void InpActEvt_Button_B_K2Node_InputActionEvent_2(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button B_K2Node_InputActionEvent_2", __pb.Bytes);
        }
        public void InpActEvt_Button_Y_K2Node_InputActionEvent_1(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button Y_K2Node_InputActionEvent_1", __pb.Bytes);
        }
        public void InpActEvt_Button_Y_K2Node_InputActionEvent_0(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button Y_K2Node_InputActionEvent_0", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
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
        public void ExecuteUbergraph_UI_Treasure_Item_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Treasure_Item_BP", __pb.Bytes);
        }
        public void OnPlaySound__DelegateSignature(byte SoundId)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, SoundId);
            CallRaw("OnPlaySound__DelegateSignature", __pb.Bytes);
        }
        public void OnGrabUnHovered__DelegateSignature(UI_Treasure_Item_BP_C Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("OnGrabUnHovered__DelegateSignature", __pb.Bytes);
        }
        public void OnDropped__DelegateSignature(UI_Treasure_Item_BP_C Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("OnDropped__DelegateSignature", __pb.Bytes);
        }
        public void OnGrabbed__DelegateSignature(UI_Treasure_Item_BP_C Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("OnGrabbed__DelegateSignature", __pb.Bytes);
        }
        public void OnGrabHovered__DelegateSignature(UI_Treasure_Item_BP_C Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("OnGrabHovered__DelegateSignature", __pb.Bytes);
        }
    }

}
