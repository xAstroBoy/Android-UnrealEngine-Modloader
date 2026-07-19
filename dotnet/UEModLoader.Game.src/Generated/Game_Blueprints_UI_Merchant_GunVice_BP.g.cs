// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/GunVice_BP
using System;

namespace UEModLoader.Game
{
    public class GunVice_BP_C : VR4GunVice
    {
        public const string UeClassName = "GunVice_BP_C";
        public GunVice_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new GunVice_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GunVice_BP_C(p);
        public static GunVice_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GunVice_BP_C(o.Pointer); }
        public static GunVice_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GunVice_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GunVice_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x260));
        public StaticMeshComponent StaticMesh2 { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh3 { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent SlideRootL { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent SlideLeftAnchor { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMeshSlideR { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent SlideRootR { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh4 { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_MoveSlideR_Alpha_895E12AA4F81DB0D7E50A6971E84AB68 { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public byte Timeline_MoveSlideR__Direction_895E12AA4F81DB0D7E50A6971E84AB68 { get => GetAt<byte>(0x2A4); set => SetAt(0x2A4, value); }
        public TimelineComponent Timeline_MoveSlideR { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_MoveSlideL_Alpha_356272AA4DC814A8921440A0D9C29DF9 { get => GetAt<float>(0x2B0); set => SetAt(0x2B0, value); }
        public byte Timeline_MoveSlideL__Direction_356272AA4DC814A8921440A0D9C29DF9 { get => GetAt<byte>(0x2B4); set => SetAt(0x2B4, value); }
        public TimelineComponent Timeline_MoveSlideL { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int ItemId { get => GetAt<int>(0x2C0); set => SetAt(0x2C0, value); }
        public Vector ItemOffset => new Vector(AddrOf(0x2C4));
        public float ItemSlideDistanceL { get => GetAt<float>(0x2D0); set => SetAt(0x2D0, value); }
        public float ItemSlideDistanceR { get => GetAt<float>(0x2D4); set => SetAt(0x2D4, value); }
        public bool Debug { get => Native.GetPropBool(Pointer, "Debug"); set => Native.SetPropBool(Pointer, "Debug", value); }
        public bool WeaponPlaced { get => Native.GetPropBool(Pointer, "WeaponPlaced"); set => Native.SetPropBool(Pointer, "WeaponPlaced", value); }
        public TimerHandle ReleaseTimer => new TimerHandle(AddrOf(0x2E0));
        public Vector WeaponTransformLocation => new Vector(AddrOf(0x2E8));
        public AudioComponent SFX_SlideL { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public AudioComponent SFX_SlideR { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void AttacheItemGrabbed(AttacheItem_BP_C AttacheItem, bool Callback)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, AttacheItem);
            __pb.Set<byte>(0x8, (byte)(Callback?1:0));
            CallRaw("AttacheItemGrabbed", __pb.Bytes);
        }
        public void AttacheItemReleased(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("AttacheItemReleased", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void Timeline_MoveSlideR__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MoveSlideR__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_MoveSlideR__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MoveSlideR__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_MoveSlideL__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MoveSlideL__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_MoveSlideL__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MoveSlideL__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void WeaponGrabbed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WeaponGrabbed", __pb.Bytes);
        }
        public void WeaponReleased()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WeaponReleased", __pb.Bytes);
        }
        public void WeaponPlacedFinish(AttacheItem Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("WeaponPlacedFinish", __pb.Bytes);
        }
        public void WeaponCleared()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WeaponCleared", __pb.Bytes);
        }
        public void ReleaseTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReleaseTimerExpired", __pb.Bytes);
        }
        public void ExecuteUbergraph_GunVice_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_GunVice_BP", __pb.Bytes);
        }
    }

}
