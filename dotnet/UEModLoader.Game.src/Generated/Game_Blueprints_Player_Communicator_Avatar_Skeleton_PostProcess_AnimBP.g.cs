// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Communicator/Avatar_Skeleton_PostProcess_AnimBP
using System;

namespace UEModLoader.Game
{
    public class Avatar_Skeleton_PostProcess_AnimBP_C : AnimInstance
    {
        public const string UeClassName = "Avatar_Skeleton_PostProcess_AnimBP_C";
        public Avatar_Skeleton_PostProcess_AnimBP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Avatar_Skeleton_PostProcess_AnimBP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Avatar_Skeleton_PostProcess_AnimBP_C(p);
        public static Avatar_Skeleton_PostProcess_AnimBP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Avatar_Skeleton_PostProcess_AnimBP_C(o.Pointer); }
        public static Avatar_Skeleton_PostProcess_AnimBP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Avatar_Skeleton_PostProcess_AnimBP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Avatar_Skeleton_PostProcess_AnimBP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x270));
        public AnimNode_CopyBone AnimGraphNode_CopyBone => new AnimNode_CopyBone(AddrOf(0x278));
        public AnimNode_CopyBone AnimGraphNode_CopyBone_2 => new AnimNode_CopyBone(AddrOf(0x368));
        public AnimNode_RotationMultiplier AnimGraphNode_RotationMultiplier => new AnimNode_RotationMultiplier(AddrOf(0x458));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0x548));
        public AnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace => new AnimNode_ConvertLocalToComponentSpace(AddrOf(0x568));
        public AnimNode_RotationMultiplier AnimGraphNode_RotationMultiplier_2 => new AnimNode_RotationMultiplier(AddrOf(0x588));
        public AnimNode_LookAt AnimGraphNode_LookAt => new AnimNode_LookAt(AddrOf(0x680));
        public AnimNode_CopyBone AnimGraphNode_CopyBone_3 => new AnimNode_CopyBone(AddrOf(0x830));
        public AnimNode_CopyBone AnimGraphNode_CopyBone_4 => new AnimNode_CopyBone(AddrOf(0x920));
        public AnimNode_LookAt AnimGraphNode_LookAt_2 => new AnimNode_LookAt(AddrOf(0xA10));
        public AnimNode_CopyBone AnimGraphNode_CopyBone_5 => new AnimNode_CopyBone(AddrOf(0xBC0));
        public AnimNode_CopyBone AnimGraphNode_CopyBone_6 => new AnimNode_CopyBone(AddrOf(0xCB0));
        public AnimNode_LookAt AnimGraphNode_LookAt_3 => new AnimNode_LookAt(AddrOf(0xDA0));
        public AnimNode_CopyBone AnimGraphNode_CopyBone_7 => new AnimNode_CopyBone(AddrOf(0xF50));
        public AnimNode_CopyBone AnimGraphNode_CopyBone_8 => new AnimNode_CopyBone(AddrOf(0x1040));
        public AnimNode_VR4WristBend AnimGraphNode_VR4WristBend => new AnimNode_VR4WristBend(AddrOf(0x1130));
        public AnimNode_VR4WristBend AnimGraphNode_VR4WristBend_2 => new AnimNode_VR4WristBend(AddrOf(0x12C0));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace_2 => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0x1450));
        public AnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose => new AnimNode_LinkedInputPose(AddrOf(0x1470));
        public AnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace_2 => new AnimNode_ConvertLocalToComponentSpace(AddrOf(0x14E8));
        public AnimNode_LookAt AnimGraphNode_LookAt_4 => new AnimNode_LookAt(AddrOf(0x1510));
        public AnimNode_Root AnimGraphNode_Root => new AnimNode_Root(AddrOf(0x16C0));
        public AnimNode_PoseBlendNode AnimGraphNode_PoseBlendNode => new AnimNode_PoseBlendNode(AddrOf(0x16F0));
        public AnimNode_PoseBlendNode AnimGraphNode_PoseBlendNode_2 => new AnimNode_PoseBlendNode(AddrOf(0x1788));
        public AnimNode_PoseBlendNode AnimGraphNode_PoseBlendNode_3 => new AnimNode_PoseBlendNode(AddrOf(0x1820));
        public AnimNode_PoseBlendNode AnimGraphNode_PoseBlendNode_4 => new AnimNode_PoseBlendNode(AddrOf(0x18B8));
        public Rotator TestRotation => new Rotator(AddrOf(0x1950));
        public global::System.IntPtr CorrectionData => AddrOf(0x1960); // struct PlayerSkeletonCorrectionData
        public void AnimGraph(global::System.IntPtr InPose, global::System.IntPtr AnimGraph)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InPose);
            __pb.Set<global::System.IntPtr>(0x10, AnimGraph);
            CallRaw("AnimGraph", __pb.Bytes);
        }
        public void InitCachedVars()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitCachedVars", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_Avatar_Skeleton_PostProcess_AnimBP_AnimGraphNode_VR4WristBend_A089700944EA3F29A78E30AA3ABDA849()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_Avatar_Skeleton_PostProcess_AnimBP_AnimGraphNode_VR4WristBend_A089700944EA3F29A78E30AA3ABDA849", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_Avatar_Skeleton_PostProcess_AnimBP_AnimGraphNode_VR4WristBend_C93C175C4058F08B192B08A5B4B107E0()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_Avatar_Skeleton_PostProcess_AnimBP_AnimGraphNode_VR4WristBend_C93C175C4058F08B192B08A5B4B107E0", __pb.Bytes);
        }
        public void BlueprintInitializeAnimation()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BlueprintInitializeAnimation", __pb.Bytes);
        }
        public void ExecuteUbergraph_Avatar_Skeleton_PostProcess_AnimBP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Avatar_Skeleton_PostProcess_AnimBP", __pb.Bytes);
        }
    }

}
