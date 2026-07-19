// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Screens/UI_Merchant_GridTable_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_GridTable_BP_C : UI_MerchantSubScreen_BP_C
    {
        public const string UeClassName = "UI_Merchant_GridTable_BP_C";
        public UI_Merchant_GridTable_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_GridTable_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_GridTable_BP_C(p);
        public static UI_Merchant_GridTable_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_GridTable_BP_C(o.Pointer); }
        public static UI_Merchant_GridTable_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_GridTable_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_GridTable_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2B8));
        public ChildActorComponent GunVice { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent AttachePoint { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent GridMesh { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent panel1 { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Table { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Rotate_Rotation_524F58BA4BD7FEDE8DBB43A7C4785118 { get => GetAt<float>(0x2E8); set => SetAt(0x2E8, value); }
        public byte Timeline_Rotate__Direction_524F58BA4BD7FEDE8DBB43A7C4785118 { get => GetAt<byte>(0x2EC); set => SetAt(0x2EC, value); }
        public TimelineComponent Timeline_Rotate { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool ViceShown { get => Native.GetPropBool(Pointer, "ViceShown"); set => Native.SetPropBool(Pointer, "ViceShown", value); }
        public bool TableRotated { get => Native.GetPropBool(Pointer, "TableRotated"); set => Native.SetPropBool(Pointer, "TableRotated", value); }
        public InventoryUIScreen_BP_C Ref_InventoryScreen { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new InventoryUIScreen_BP_C(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr OnGridActive => AddrOf(0x308); // 
        public GunVice_BP_C Ref_GunVice { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new GunVice_BP_C(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsRotating { get => Native.GetPropBool(Pointer, "IsRotating"); set => Native.SetPropBool(Pointer, "IsRotating", value); }
        public void IsScreenAnimating(bool Animating)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Animating?1:0));
            CallRaw("IsScreenAnimating", __pb.Bytes);
        }
        public void HideVice()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideVice", __pb.Bytes);
        }
        public void Show_Vice()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Show Vice", __pb.Bytes);
        }
        public void HandleViceItemPlaced(AttacheItem AttacheItem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, AttacheItem);
            CallRaw("HandleViceItemPlaced", __pb.Bytes);
        }
        public void SetViceVisibility(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("SetViceVisibility", __pb.Bytes);
        }
        public bool IsEmpty()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsEmpty", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void RotateTable(bool ToRotated, bool instant, bool InstantIfEmpty)
        {
            var __pb = new ParamBuffer(3);
            __pb.Set<byte>(0x0, (byte)(ToRotated?1:0));
            __pb.Set<byte>(0x1, (byte)(instant?1:0));
            __pb.Set<byte>(0x2, (byte)(InstantIfEmpty?1:0));
            CallRaw("RotateTable", __pb.Bytes);
        }
        public void OnRotateComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnRotateComplete", __pb.Bytes);
        }
        public void SetInventoryScreen(InventoryUIScreen_BP_C InventoryScreen)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InventoryScreen);
            CallRaw("SetInventoryScreen", __pb.Bytes);
        }
        public void HandleOnEnterState(EVR4MerchantScreenStates previousState, EVR4MerchantScreenStates State)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)previousState);
            __pb.Set<byte>(0x1, (byte)State);
            CallRaw("HandleOnEnterState", __pb.Bytes);
        }
        public void Timeline_Rotate__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Rotate__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Rotate__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Rotate__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void PlayRotation()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayRotation", __pb.Bytes);
        }
        public void InstantRotation()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InstantRotation", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_GridTable_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_GridTable_BP", __pb.Bytes);
        }
        public void OnGridActive__DelegateSignature(bool Active)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Active?1:0));
            CallRaw("OnGridActive__DelegateSignature", __pb.Bytes);
        }
    }

}
