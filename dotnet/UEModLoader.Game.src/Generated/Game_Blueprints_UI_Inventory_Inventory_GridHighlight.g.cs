// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/Inventory_GridHighlight
using System;

namespace UEModLoader.Game
{
    public class Inventory_GridHighlight_C : Actor
    {
        public const string UeClassName = "Inventory_GridHighlight_C";
        public Inventory_GridHighlight_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Inventory_GridHighlight_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Inventory_GridHighlight_C(p);
        public static Inventory_GridHighlight_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Inventory_GridHighlight_C(o.Pointer); }
        public static Inventory_GridHighlight_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Inventory_GridHighlight_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Inventory_GridHighlight_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float BorderWidth { get => GetAt<float>(0x238); set => SetAt(0x238, value); }
        public MaterialInstanceDynamic MeshMaterial { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void UpdateHighlight(AttacheCase_BP_C AttacheCase, global::System.IntPtr Item, global::System.IntPtr ItemTransform, EAttacheItemState ItemState, bool ShowBorder, bool HideHighlight)
        {
            var __pb = new ParamBuffer(67);
            __pb.SetObject(0x0, AttacheCase);
            __pb.Set<global::System.IntPtr>(0x8, Item);
            __pb.Set<global::System.IntPtr>(0x30, ItemTransform);
            __pb.Set<byte>(0x40, (byte)ItemState);
            __pb.Set<byte>(0x41, (byte)(ShowBorder?1:0));
            __pb.Set<byte>(0x42, (byte)(HideHighlight?1:0));
            CallRaw("UpdateHighlight", __pb.Bytes);
        }
        public void GetHighlightColors(EAttacheItemState Item_State, global::System.IntPtr Border_Color, global::System.IntPtr Base_Color)
        {
            var __pb = new ParamBuffer(36);
            __pb.Set<byte>(0x0, (byte)Item_State);
            __pb.Set<global::System.IntPtr>(0x4, Border_Color);
            __pb.Set<global::System.IntPtr>(0x14, Base_Color);
            CallRaw("GetHighlightColors", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_Inventory_GridHighlight(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Inventory_GridHighlight", __pb.Bytes);
        }
    }

}
