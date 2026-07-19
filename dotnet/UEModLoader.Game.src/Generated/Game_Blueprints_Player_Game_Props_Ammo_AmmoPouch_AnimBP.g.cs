// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Ammo/AmmoPouch_AnimBP
using System;

namespace UEModLoader.Game
{
    public class AmmoPouch_AnimBP_C : AnimInstance
    {
        public const string UeClassName = "AmmoPouch_AnimBP_C";
        public AmmoPouch_AnimBP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new AmmoPouch_AnimBP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AmmoPouch_AnimBP_C(p);
        public static AmmoPouch_AnimBP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AmmoPouch_AnimBP_C(o.Pointer); }
        public static AmmoPouch_AnimBP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AmmoPouch_AnimBP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AmmoPouch_AnimBP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x270));
        public AnimNode_Root AnimGraphNode_Root => new AnimNode_Root(AddrOf(0x278));
        public AnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose => new AnimNode_LinkedInputPose(AddrOf(0x2A8));
        public AnimNode_TransitionResult AnimGraphNode_TransitionResult => new AnimNode_TransitionResult(AddrOf(0x320));
        public AnimNode_TransitionResult AnimGraphNode_TransitionResult_2 => new AnimNode_TransitionResult(AddrOf(0x348));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone => new AnimNode_ModifyBone(AddrOf(0x370));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_2 => new AnimNode_ModifyBone(AddrOf(0x478));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_3 => new AnimNode_ModifyBone(AddrOf(0x580));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_4 => new AnimNode_ModifyBone(AddrOf(0x688));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose => new AnimNode_UseCachedPose(AddrOf(0x790));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0x7B8));
        public AnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace => new AnimNode_ConvertLocalToComponentSpace(AddrOf(0x7D8));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_5 => new AnimNode_ModifyBone(AddrOf(0x7F8));
        public AnimNode_StateResult AnimGraphNode_StateResult => new AnimNode_StateResult(AddrOf(0x900));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose_2 => new AnimNode_UseCachedPose(AddrOf(0x930));
        public AnimNode_StateResult AnimGraphNode_StateResult_2 => new AnimNode_StateResult(AddrOf(0x958));
        public AnimNode_StateMachine AnimGraphNode_StateMachine => new AnimNode_StateMachine(AddrOf(0x988));
        public AnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose => new AnimNode_SaveCachedPose(AddrOf(0xA38));
        public bool ShouldBeOpen { get => Native.GetPropBool(Pointer, "ShouldBeOpen"); set => Native.SetPropBool(Pointer, "ShouldBeOpen", value); }
        public float ForceClosedTimer { get => GetAt<float>(0xAF4); set => SetAt(0xAF4, value); }
        public bool IsOpen { get => Native.GetPropBool(Pointer, "IsOpen"); set => Native.SetPropBool(Pointer, "IsOpen", value); }
        public void AnimGraph(global::System.IntPtr InPose, global::System.IntPtr AnimGraph)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InPose);
            __pb.Set<global::System.IntPtr>(0x10, AnimGraph);
            CallRaw("AnimGraph", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_AmmoPouch_AnimBP_AnimGraphNode_TransitionResult_FCF4F4B347B2EF38606D55A3C5694E14()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_AmmoPouch_AnimBP_AnimGraphNode_TransitionResult_FCF4F4B347B2EF38606D55A3C5694E14", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_AmmoPouch_AnimBP_AnimGraphNode_TransitionResult_9F02559C4795FA52AE255891A32C2813()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_AmmoPouch_AnimBP_AnimGraphNode_TransitionResult_9F02559C4795FA52AE255891A32C2813", __pb.Bytes);
        }
        public void BlueprintUpdateAnimation(float DeltaTimeX)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaTimeX);
            CallRaw("BlueprintUpdateAnimation", __pb.Bytes);
        }
        public void AnimNotify_EnterOpen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AnimNotify_EnterOpen", __pb.Bytes);
        }
        public void AnimNotify_FullyClosed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AnimNotify_FullyClosed", __pb.Bytes);
        }
        public void ExecuteUbergraph_AmmoPouch_AnimBP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_AmmoPouch_AnimBP", __pb.Bytes);
        }
    }

}
