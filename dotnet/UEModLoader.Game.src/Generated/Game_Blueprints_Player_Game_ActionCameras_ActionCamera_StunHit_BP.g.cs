// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/ActionCameras/ActionCamera_StunHit_BP
using System;

namespace UEModLoader.Game
{
    public class ActionCamera_StunHit_BP_C : VR4CameraActionBase
    {
        public const string UeClassName = "ActionCamera_StunHit_BP_C";
        public ActionCamera_StunHit_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new ActionCamera_StunHit_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ActionCamera_StunHit_BP_C(p);
        public static ActionCamera_StunHit_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ActionCamera_StunHit_BP_C(o.Pointer); }
        public static ActionCamera_StunHit_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ActionCamera_StunHit_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ActionCamera_StunHit_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x30));
        public float FadeRise { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public float FadeFall { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public float FadeHold { get => GetAt<float>(0x40); set => SetAt(0x40, value); }
        public LinearColor FadeColorScale => new LinearColor(AddrOf(0x44));
        public CurveFloat FadeColorScaleCurve { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LinearColor FadeColorOffset => new LinearColor(AddrOf(0x60));
        public CurveFloat FadeColorOffsetCurve { get { var __p = GetAt<global::System.IntPtr>(0x70); return __p==global::System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x70, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void OnCameraControlGained(VR4Bio4PlayerPawn Pawn, global::System.IntPtr transitionParameters)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, Pawn);
            __pb.Set<global::System.IntPtr>(0x8, transitionParameters);
            CallRaw("OnCameraControlGained", __pb.Bytes);
        }
        public void ExecuteUbergraph_ActionCamera_StunHit_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ActionCamera_StunHit_BP", __pb.Bytes);
        }
    }

}
