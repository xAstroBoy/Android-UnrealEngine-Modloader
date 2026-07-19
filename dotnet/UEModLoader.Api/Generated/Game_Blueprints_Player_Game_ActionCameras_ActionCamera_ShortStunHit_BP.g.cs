// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/ActionCameras/ActionCamera_ShortStunHit_BP
using System;

namespace UEModLoader.Game
{
    public class ActionCamera_ShortStunHit_BP_C : VR4CameraAction_Default
    {
        public const string UeClassName = "ActionCamera_ShortStunHit_BP_C";
        public ActionCamera_ShortStunHit_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new ActionCamera_ShortStunHit_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ActionCamera_ShortStunHit_BP_C(p);
        public static ActionCamera_ShortStunHit_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ActionCamera_ShortStunHit_BP_C(o.Pointer); }
        public static ActionCamera_ShortStunHit_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ActionCamera_ShortStunHit_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ActionCamera_ShortStunHit_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x30));
        public CameraShake ShakeClass { get { var __p = GetAt<System.IntPtr>(0x38); return __p==System.IntPtr.Zero?null:new CameraShake(__p); } set => SetAt(0x38, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4Bio4PlayerPawn_BP_C PlayerPawn { get { var __p = GetAt<System.IntPtr>(0x40); return __p==System.IntPtr.Zero?null:new VR4Bio4PlayerPawn_BP_C(__p); } set => SetAt(0x40, value?.Pointer ?? System.IntPtr.Zero); }
        public void OnCameraControlGained(VR4Bio4PlayerPawn Pawn, AnchorTransitionParameters transitionParameters)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, Pawn);
            __pb.Set<System.IntPtr>(0x8, transitionParameters);
            CallRaw("OnCameraControlGained", __pb.Bytes);
        }
        public void OnCameraControlLost(VR4Bio4PlayerPawn Pawn, AnchorTransitionParameters transitionParameters, EActionCameraType nextCameraType)
        {
            var __pb = new ParamBuffer(41);
            __pb.SetObject(0x0, Pawn);
            __pb.Set<System.IntPtr>(0x8, transitionParameters);
            __pb.Set<byte>(0x28, (byte)nextCameraType);
            CallRaw("OnCameraControlLost", __pb.Bytes);
        }
        public void ExecuteUbergraph_ActionCamera_ShortStunHit_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ActionCamera_ShortStunHit_BP", __pb.Bytes);
        }
    }

}
