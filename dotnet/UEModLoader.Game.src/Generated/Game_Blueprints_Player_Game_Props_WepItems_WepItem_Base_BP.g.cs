// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/WepItems/WepItem_Base_BP
using System;

namespace UEModLoader.Game
{
    public class WepItem_Base_BP_C : VR4WepItem
    {
        public const string UeClassName = "WepItem_Base_BP_C";
        public WepItem_Base_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new WepItem_Base_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new WepItem_Base_BP_C(p);
        public static WepItem_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WepItem_Base_BP_C(o.Pointer); }
        public static WepItem_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WepItem_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WepItem_Base_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x288));
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ScaleDown_Scale_E389068B46245093F47DEAB0F66EE403 { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public byte Timeline_ScaleDown__Direction_E389068B46245093F47DEAB0F66EE403 { get => GetAt<byte>(0x29C); set => SetAt(0x29C, value); }
        public TimelineComponent Timeline_ScaleDown { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void Timeline_ScaleDown__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleDown__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ScaleDown__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleDown__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_WepItem_Base_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_WepItem_Base_BP", __pb.Bytes);
        }
    }

}
