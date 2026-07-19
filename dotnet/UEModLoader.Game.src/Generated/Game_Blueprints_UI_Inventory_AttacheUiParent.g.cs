// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/AttacheUiParent
using System;

namespace UEModLoader.Game
{
    public class AttacheUiParent_C : UserWidget
    {
        public const string UeClassName = "AttacheUiParent_C";
        public AttacheUiParent_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new AttacheUiParent_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AttacheUiParent_C(p);
        public static AttacheUiParent_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AttacheUiParent_C(o.Pointer); }
        public static AttacheUiParent_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AttacheUiParent_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AttacheUiParent_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public UniformGridPanel GridPanel { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new UniformGridPanel(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Grid { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Master { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> GridSlots => new TArray<global::System.IntPtr>(AddrOf(0x250)); // TArray<UObject*>
        public global::System.IntPtr AutoDraw => AddrOf(0x260); // 
        public TArray<global::System.IntPtr> AnimatingSlots => new TArray<global::System.IntPtr>(AddrOf(0x270)); // TArray<UObject*>
        public void SetGridSize(int GridHeight, int GridWidth)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, GridHeight);
            __pb.Set(0x4, GridWidth);
            CallRaw("SetGridSize", __pb.Bytes);
        }
        public void creategrid(int GridHeight, int GridWidth)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, GridHeight);
            __pb.Set(0x4, GridWidth);
            CallRaw("creategrid", __pb.Bytes);
        }
        public void GridAnimationEnded(InventoryGridSlot_C GridSlot)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, GridSlot);
            CallRaw("GridAnimationEnded", __pb.Bytes);
        }
        public void GridAnimationStarted(InventoryGridSlot_C GridSlot)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, GridSlot);
            CallRaw("GridAnimationStarted", __pb.Bytes);
        }
        public void ExecuteUbergraph_AttacheUiParent(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_AttacheUiParent", __pb.Bytes);
        }
        public void AutoDraw__DelegateSignature(bool AutoDraw)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(AutoDraw?1:0));
            CallRaw("AutoDraw__DelegateSignature", __pb.Bytes);
        }
    }

}
