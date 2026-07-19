// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/AttacheCase_BP
using System;

namespace UEModLoader.Game
{
    public class AttacheCase_BP_C : AttacheCase
    {
        public const string UeClassName = "AttacheCase_BP_C";
        public AttacheCase_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new AttacheCase_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AttacheCase_BP_C(p);
        public static AttacheCase_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AttacheCase_BP_C(o.Pointer); }
        public static AttacheCase_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AttacheCase_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AttacheCase_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2B0));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public InventoryUiManager_C UIManager { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new InventoryUiManager_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void DebugDrawRegion(global::System.IntPtr region, global::System.IntPtr Color)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, region);
            __pb.Set<global::System.IntPtr>(0x10, Color);
            CallRaw("DebugDrawRegion", __pb.Bytes);
        }
        public void DebugDrawGrid()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DebugDrawGrid", __pb.Bytes);
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
        public void ItemRemoved(AttacheItem Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("ItemRemoved", __pb.Bytes);
        }
        public void ExecuteUbergraph_AttacheCase_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_AttacheCase_BP", __pb.Bytes);
        }
    }

}
