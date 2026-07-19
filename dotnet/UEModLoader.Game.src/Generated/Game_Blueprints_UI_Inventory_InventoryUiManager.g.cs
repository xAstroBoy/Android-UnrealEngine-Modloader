// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/InventoryUiManager
using System;

namespace UEModLoader.Game
{
    public class InventoryUiManager_C : Actor
    {
        public const string UeClassName = "InventoryUiManager_C";
        public InventoryUiManager_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new InventoryUiManager_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InventoryUiManager_C(p);
        public static InventoryUiManager_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InventoryUiManager_C(o.Pointer); }
        public static InventoryUiManager_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InventoryUiManager_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InventoryUiManager_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent WidgetUiParent { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int Height { get => GetAt<int>(0x238); set => SetAt(0x238, value); }
        public int Width { get => GetAt<int>(0x23C); set => SetAt(0x23C, value); }
        public AttacheUiParent_C UiParent { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new AttacheUiParent_C(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AttacheCase_BP_C AttacheCase { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new AttacheCase_BP_C(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool UseMR { get => Native.GetPropBool(Pointer, "UseMR"); set => Native.SetPropBool(Pointer, "UseMR", value); }
        public bool RemainHidden { get => Native.GetPropBool(Pointer, "RemainHidden"); set => Native.SetPropBool(Pointer, "RemainHidden", value); }
        public void UpdateWidgetUIVisibility()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateWidgetUIVisibility", __pb.Bytes);
        }
        public void HandleOnItemAdded(AttacheItem Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("HandleOnItemAdded", __pb.Bytes);
        }
        public void HandleOnItemRemoved(AttacheItem Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("HandleOnItemRemoved", __pb.Bytes);
        }
        public void UpdateSize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateSize", __pb.Bytes);
        }
        public void ClearAll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearAll", __pb.Bytes);
        }
        public void HideTuneUpIcon(int row, int Column, InventoryGridSlot_C GridSlotRef)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.SetObject(0x8, GridSlotRef);
            CallRaw("HideTuneUpIcon", __pb.Bytes);
        }
        public void ShowTuneUpIcon(int row, int Column, int corner, bool CanAfford, InventoryGridSlot_C GridSlotRef)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.Set(0x8, corner);
            __pb.Set<byte>(0xC, (byte)(CanAfford?1:0));
            __pb.SetObject(0x10, GridSlotRef);
            CallRaw("ShowTuneUpIcon", __pb.Bytes);
        }
        public void ShowManager()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowManager", __pb.Bytes);
        }
        public void HideManager()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideManager", __pb.Bytes);
        }
        public void ShowFlash(int row, int Column, int corner)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.Set(0x8, corner);
            CallRaw("ShowFlash", __pb.Bytes);
        }
        public void HideCount(int row, int Column, InventoryGridSlot_C GridSlotRef)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.SetObject(0x8, GridSlotRef);
            CallRaw("HideCount", __pb.Bytes);
        }
        public void ShowCount(int row, int Column, int corner, int Count, bool AlwaysShow, InventoryGridSlot_C GridSlotRef)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.Set(0x8, corner);
            __pb.Set(0xC, Count);
            __pb.Set<byte>(0x10, (byte)(AlwaysShow?1:0));
            __pb.SetObject(0x18, GridSlotRef);
            CallRaw("ShowCount", __pb.Bytes);
        }
        public void DebugHideAll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DebugHideAll", __pb.Bytes);
        }
        public void SetEquipIcon(int row, int Column, EPropSlot Type, InventoryGridSlot_C GridSlotRef)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.Set<byte>(0x8, (byte)Type);
            __pb.SetObject(0x10, GridSlotRef);
            CallRaw("SetEquipIcon", __pb.Bytes);
        }
        public void DebugShowAll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DebugShowAll", __pb.Bytes);
        }
        public void HideEquipIcon(int row, int Column, bool instant, InventoryGridSlot_C GridSlotRef)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.Set<byte>(0x8, (byte)(instant?1:0));
            __pb.SetObject(0x10, GridSlotRef);
            CallRaw("HideEquipIcon", __pb.Bytes);
        }
        public void ShowEquipIcon(int row, int Column, int corner, bool instant, InventoryGridSlot_C GridSlotRef)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, row);
            __pb.Set(0x4, Column);
            __pb.Set(0x8, corner);
            __pb.Set<byte>(0xC, (byte)(instant?1:0));
            __pb.SetObject(0x10, GridSlotRef);
            CallRaw("ShowEquipIcon", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ItemCountChanged(AttacheItem Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("ItemCountChanged", __pb.Bytes);
        }
        public void UpdateRedraw(bool AutoDraw)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(AutoDraw?1:0));
            CallRaw("UpdateRedraw", __pb.Bytes);
        }
        public void ExecuteUbergraph_InventoryUiManager(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_InventoryUiManager", __pb.Bytes);
        }
    }

}
