// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/InventoryGridSlot
using System;

namespace UEModLoader.Game
{
    public class InventoryGridSlot_C : UserWidget
    {
        public const string UeClassName = "InventoryGridSlot_C";
        public InventoryGridSlot_C(System.IntPtr ptr) : base(ptr) {}
        public static new InventoryGridSlot_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InventoryGridSlot_C(p);
        public static InventoryGridSlot_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InventoryGridSlot_C(o.Pointer); }
        public static InventoryGridSlot_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InventoryGridSlot_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InventoryGridSlot_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation Flash { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation ScaleEquip { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public AttacheItem_CountWidget_C AttacheItem_CountWidget { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new AttacheItem_CountWidget_C(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public AttacheItem_EquipWidget_C AttacheItem_EquipWidget { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new AttacheItem_EquipWidget_C(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public AttacheItem_FlashWidget_C AttacheItem_FlashWidget { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new AttacheItem_FlashWidget_C(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public AttacheItem_TuneUpWidget_C AttacheItem_TuneUpWidget { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new AttacheItem_TuneUpWidget_C(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public InvalidationBox InvalidationBox_Slot { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new InvalidationBox(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public ScaleBox ScaleBox_Count { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new ScaleBox(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_Equip { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_Flash { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_TuneUp { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr GridAnimStart => AddrOf(0x290); // 
        public System.IntPtr GridAnimEnd => AddrOf(0x2A0); // 
        public void HideTuneUpIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideTuneUpIcon", __pb.Bytes);
        }
        public void ShowTuneUpIcon(int corner, bool CanAfford)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, corner);
            __pb.Set<byte>(0x4, (byte)(CanAfford?1:0));
            CallRaw("ShowTuneUpIcon", __pb.Bytes);
        }
        public void CheckAnimState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckAnimState", __pb.Bytes);
        }
        public void ShowFlash(int corner)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, corner);
            CallRaw("ShowFlash", __pb.Bytes);
        }
        public void HideCount()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideCount", __pb.Bytes);
        }
        public void ShowCount(int Count, int corner, bool AlwaysShow)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, Count);
            __pb.Set(0x4, corner);
            __pb.Set<byte>(0x8, (byte)(AlwaysShow?1:0));
            CallRaw("ShowCount", __pb.Bytes);
        }
        public void SetEquipIcon(EPropSlot Type)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Type);
            CallRaw("SetEquipIcon", __pb.Bytes);
        }
        public void HideEquipIcon(bool instant)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(instant?1:0));
            CallRaw("HideEquipIcon", __pb.Bytes);
        }
        public void ShowEquipIcon(int corner, bool instant)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, corner);
            __pb.Set<byte>(0x4, (byte)(instant?1:0));
            CallRaw("ShowEquipIcon", __pb.Bytes);
        }
        public void ShrinkFinished()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShrinkFinished", __pb.Bytes);
        }
        public void FlashFinished()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlashFinished", __pb.Bytes);
        }
        public void GrowFinished()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GrowFinished", __pb.Bytes);
        }
        public void ExecuteUbergraph_InventoryGridSlot(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_InventoryGridSlot", __pb.Bytes);
        }
        public void GridAnimEnd__DelegateSignature(InventoryGridSlot_C GridSlot)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, GridSlot);
            CallRaw("GridAnimEnd__DelegateSignature", __pb.Bytes);
        }
        public void GridAnimStart__DelegateSignature(InventoryGridSlot_C GridSlot)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, GridSlot);
            CallRaw("GridAnimStart__DelegateSignature", __pb.Bytes);
        }
    }

}
