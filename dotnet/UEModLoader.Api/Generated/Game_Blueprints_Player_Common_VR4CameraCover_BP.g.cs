// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Common/VR4CameraCover_BP
using System;

namespace UEModLoader.Game
{
    public class VR4CameraCover_BP_C : VR4CameraCover
    {
        public const string UeClassName = "VR4CameraCover_BP_C";
        public VR4CameraCover_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4CameraCover_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4CameraCover_BP_C(p);
        public static VR4CameraCover_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4CameraCover_BP_C(o.Pointer); }
        public static VR4CameraCover_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4CameraCover_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4CameraCover_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public float DamageVignetteScaling_Timeline_Scale_7EEAE8AF471D86113C271CA169D57C72 { get => GetAt<float>(0x260); set => SetAt(0x260, value); }
        public byte DamageVignetteScaling_Timeline__Direction_7EEAE8AF471D86113C271CA169D57C72 { get => GetAt<byte>(0x264); set => SetAt(0x264, value); }
        public TimelineComponent DamageVignetteScaling_Timeline { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public LinearColor DamageColor => new LinearColor(AddrOf(0x270));
        public float PuasedDamageWipeValue { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public float DamageColorAmountWhileMoving { get => GetAt<float>(0x284); set => SetAt(0x284, value); }
        public Actor DamageSourceActor { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public void SetDamageVignetteScale(float Scale)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Scale);
            CallRaw("SetDamageVignetteScale", __pb.Bytes);
        }
        public void DamageVignetteScaling_Timeline__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DamageVignetteScaling_Timeline__FinishedFunc", __pb.Bytes);
        }
        public void DamageVignetteScaling_Timeline__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DamageVignetteScaling_Timeline__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void UpdateDamageVignette(LinearColor Color, float Scale, Actor sourceActor)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, Color);
            __pb.Set(0x10, Scale);
            __pb.SetObject(0x18, sourceActor);
            CallRaw("UpdateDamageVignette", __pb.Bytes);
        }
        public void PauseDamageVingette()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PauseDamageVingette", __pb.Bytes);
        }
        public void ResumeDamageVingette()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResumeDamageVingette", __pb.Bytes);
        }
        public void CancelDamageVignette()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CancelDamageVignette", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4CameraCover_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4CameraCover_BP", __pb.Bytes);
        }
    }

}
