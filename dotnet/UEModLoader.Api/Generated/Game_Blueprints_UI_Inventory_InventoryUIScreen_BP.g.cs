// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/InventoryUIScreen_BP
using System;

namespace UEModLoader.Game
{
    public class InventoryUIScreen_BP_C : VR4InventoryUIScreen
    {
        public const string UeClassName = "InventoryUIScreen_BP_C";
        public InventoryUIScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new InventoryUIScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InventoryUIScreen_BP_C(p);
        public static InventoryUIScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InventoryUIScreen_BP_C(o.Pointer); }
        public static InventoryUIScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InventoryUIScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InventoryUIScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x3C0));
        public SceneComponent ExitPromptPoint { get { var __p = GetAt<System.IntPtr>(0x3C8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x3C8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent AttachePoint { get { var __p = GetAt<System.IntPtr>(0x3D0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x3D0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x3D8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x3D8, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> QuickSelectSlots => new TArray<System.IntPtr>(AddrOf(0x3E0)); // TArray<UObject*>
        public Inventory_QuickSelectSlot_BP_C DroppedQuickSelectSlot { get { var __p = GetAt<System.IntPtr>(0x3F0); return __p==System.IntPtr.Zero?null:new Inventory_QuickSelectSlot_BP_C(__p); } set => SetAt(0x3F0, value?.Pointer ?? System.IntPtr.Zero); }
        public Inventory_GridHighlight_C GridHighlight { get { var __p = GetAt<System.IntPtr>(0x3F8); return __p==System.IntPtr.Zero?null:new Inventory_GridHighlight_C(__p); } set => SetAt(0x3F8, value?.Pointer ?? System.IntPtr.Zero); }
        public Inventory_GridHighlight_C GridHighlight_RightHand { get { var __p = GetAt<System.IntPtr>(0x400); return __p==System.IntPtr.Zero?null:new Inventory_GridHighlight_C(__p); } set => SetAt(0x400, value?.Pointer ?? System.IntPtr.Zero); }
        public float LastValidMoveTime { get => GetAt<float>(0x408); set => SetAt(0x408, value); }
        public float InvalidHoverMaxDuration { get => GetAt<float>(0x40C); set => SetAt(0x40C, value); }
        public InventoryScreen_ExitPrompt_BP_C ExitPrompt { get { var __p = GetAt<System.IntPtr>(0x410); return __p==System.IntPtr.Zero?null:new InventoryScreen_ExitPrompt_BP_C(__p); } set => SetAt(0x410, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4ItemTransform LastUniqueMoveTransform => new VR4ItemTransform(AddrOf(0x418));
        public AttacheCase LastUniqueMoveCase { get { var __p = GetAt<System.IntPtr>(0x428); return __p==System.IntPtr.Zero?null:new AttacheCase(__p); } set => SetAt(0x428, value?.Pointer ?? System.IntPtr.Zero); }
        public float LastUniqueMoveTime { get => GetAt<float>(0x430); set => SetAt(0x430, value); }
        public float UniqueMoveDelay { get => GetAt<float>(0x434); set => SetAt(0x434, value); }
        public InventoryScreen_LeonDisplay_BP_C LeonDisplay { get { var __p = GetAt<System.IntPtr>(0x438); return __p==System.IntPtr.Zero?null:new InventoryScreen_LeonDisplay_BP_C(__p); } set => SetAt(0x438, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr OnGrabbedItem => AddrOf(0x440); // 
        public System.IntPtr OnReleasedItem => AddrOf(0x450); // 
        public System.IntPtr OnCancelledMoveItem => AddrOf(0x460); // 
        public VR4UIButtonComponent LeonDisplayButton { get { var __p = GetAt<System.IntPtr>(0x470); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x470, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent AshleyDisplayButton { get { var __p = GetAt<System.IntPtr>(0x478); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x478, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIComponent DragAndDropTarget { get { var __p = GetAt<System.IntPtr>(0x480); return __p==System.IntPtr.Zero?null:new VR4UIComponent(__p); } set => SetAt(0x480, value?.Pointer ?? System.IntPtr.Zero); }
        public int LastEquippedSlot { get => GetAt<int>(0x488); set => SetAt(0x488, value); }
        public bool RetainSecondaryCaseWidgets { get => Native.GetPropBool(Pointer, "RetainSecondaryCaseWidgets"); set => Native.SetPropBool(Pointer, "RetainSecondaryCaseWidgets", value); }
        public float LastReleaseGripAxisValue { get => GetAt<float>(0x490); set => SetAt(0x490, value); }
        public float LastLeftGripAxisValue { get => GetAt<float>(0x494); set => SetAt(0x494, value); }
        public float LastRightGripAxisValue { get => GetAt<float>(0x498); set => SetAt(0x498, value); }
        public void CheckEarlyGripPressed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckEarlyGripPressed", __pb.Bytes);
        }
        public void CheckEarlyGripRelease()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckEarlyGripRelease", __pb.Bytes);
        }
        public void IsPlayerAshley(bool IsPlayerAshley)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsPlayerAshley?1:0));
            CallRaw("IsPlayerAshley", __pb.Bytes);
        }
        public void RefreshGunRelatedThings()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RefreshGunRelatedThings", __pb.Bytes);
        }
        public void UncombineTutorialReset()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UncombineTutorialReset", __pb.Bytes);
        }
        public void UncombineTutorialCheck()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UncombineTutorialCheck", __pb.Bytes);
        }
        public void OnItemsDumped()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnItemsDumped", __pb.Bytes);
        }
        public void UpdateDiscardButtonVisibility()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateDiscardButtonVisibility", __pb.Bytes);
        }
        public void HideDiscardButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideDiscardButton", __pb.Bytes);
        }
        public void ShowDiscardButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowDiscardButton", __pb.Bytes);
        }
        public void UpdateLastUniqueMove()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateLastUniqueMove", __pb.Bytes);
        }
        public bool TryStartUnpause()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("TryStartUnpause", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void UpdateHoverHighlight(Inventory_GridHighlight_C Highlight, VR4PlayerHand Hand, AttacheItem_BP_C IgnoreItem, AttacheItem_BP_C HoveredItem)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, Highlight);
            __pb.SetObject(0x8, Hand);
            __pb.SetObject(0x10, IgnoreItem);
            __pb.SetObject(0x18, HoveredItem);
            CallRaw("UpdateHoverHighlight", __pb.Bytes);
        }
        public void UpdateHoverHighlights()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateHoverHighlights", __pb.Bytes);
        }
        public bool OnActionReleased(VR4PlayerHand Hand, EVR4UIAction Action)
        {
            var __pb = new ParamBuffer(10);
            __pb.SetObject(0x0, Hand);
            __pb.Set<byte>(0x8, (byte)Action);
            CallRaw("OnActionReleased", __pb.Bytes);
            return __pb.Get<byte>(0x9) != 0;
        }
        public bool OnActionPressed(VR4PlayerHand Hand, EVR4UIAction Action)
        {
            var __pb = new ParamBuffer(10);
            __pb.SetObject(0x0, Hand);
            __pb.Set<byte>(0x8, (byte)Action);
            CallRaw("OnActionPressed", __pb.Bytes);
            return __pb.Get<byte>(0x9) != 0;
        }
        public void RefreshItem(AttacheItem Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("RefreshItem", __pb.Bytes);
        }
        public void CancelMoveItem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CancelMoveItem", __pb.Bytes);
        }
        public void ReleaseGrabbedItem(bool success)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(success?1:0));
            CallRaw("ReleaseGrabbedItem", __pb.Bytes);
        }
        public void UpdateMoveItem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateMoveItem", __pb.Bytes);
        }
        public void TryEnterMoveItemState(VR4PausePlayerHand Hand, AttacheItem Item, bool success)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, Hand);
            __pb.SetObject(0x8, Item);
            __pb.Set<byte>(0x10, (byte)(success?1:0));
            CallRaw("TryEnterMoveItemState", __pb.Bytes);
        }
        public void TryEnterNormalState(bool success)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(success?1:0));
            CallRaw("TryEnterNormalState", __pb.Bytes);
        }
        public void DisableCharacterDisplays()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableCharacterDisplays", __pb.Bytes);
        }
        public void UpdateCharacterDisplayState(VR4ItemHandle ItemHandle)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, ItemHandle);
            CallRaw("UpdateCharacterDisplayState", __pb.Bytes);
        }
        public void DisableQuickSlots()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisableQuickSlots", __pb.Bytes);
        }
        public void UpdateQuickSlotState(VR4ItemHandle ItemHandle)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, ItemHandle);
            CallRaw("UpdateQuickSlotState", __pb.Bytes);
        }
        public void OnGripReleased(VR4PausePlayerHand Hand, bool InputConsumed)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Hand);
            __pb.Set<byte>(0x8, (byte)(InputConsumed?1:0));
            CallRaw("OnGripReleased", __pb.Bytes);
        }
        public void OnGripPressed(VR4PausePlayerHand Hand, bool InputConsumed)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Hand);
            __pb.Set<byte>(0x8, (byte)(InputConsumed?1:0));
            CallRaw("OnGripPressed", __pb.Bytes);
        }
        public void PauseCleanup()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PauseCleanup", __pb.Bytes);
        }
        public void PauseInitialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PauseInitialize", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ReceiveEnterScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveEnterScreen", __pb.Bytes);
        }
        public void ReceiveExitScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveExitScreen", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnItemPlaced(AttacheItem Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("OnItemPlaced", __pb.Bytes);
        }
        public void OnItemEquipped(VR4GamePlayerProp prop, EPropSlot Slot)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, prop);
            __pb.Set<byte>(0x8, (byte)Slot);
            CallRaw("OnItemEquipped", __pb.Bytes);
        }
        public void OnItemsCombined(AttacheItem itemA, AttacheItem itemB, EVR4ItemCombineType combineType)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, itemA);
            __pb.SetObject(0x8, itemB);
            __pb.Set<byte>(0x10, (byte)combineType);
            CallRaw("OnItemsCombined", __pb.Bytes);
        }
        public void OnItemUsed(AttacheItem Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("OnItemUsed", __pb.Bytes);
        }
        public void ExecuteUbergraph_InventoryUIScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_InventoryUIScreen_BP", __pb.Bytes);
        }
        public void OnCancelledMoveItem__DelegateSignature(AttacheItem AttacheItem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, AttacheItem);
            CallRaw("OnCancelledMoveItem__DelegateSignature", __pb.Bytes);
        }
        public void OnReleasedItem__DelegateSignature(AttacheItem AttacheItem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, AttacheItem);
            CallRaw("OnReleasedItem__DelegateSignature", __pb.Bytes);
        }
        public void OnGrabbedItem__DelegateSignature(AttacheItem AttacheItem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, AttacheItem);
            CallRaw("OnGrabbedItem__DelegateSignature", __pb.Bytes);
        }
    }

}
