// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Communicator/VR4Player_FirstPerson_Game_AnimBP
using System;

namespace UEModLoader.Game
{
    public class VR4Player_FirstPerson_Game_AnimBP_C : VR4GamePlayerAnimInstance
    {
        public const string UeClassName = "VR4Player_FirstPerson_Game_AnimBP_C";
        public VR4Player_FirstPerson_Game_AnimBP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4Player_FirstPerson_Game_AnimBP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4Player_FirstPerson_Game_AnimBP_C(p);
        public static VR4Player_FirstPerson_Game_AnimBP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4Player_FirstPerson_Game_AnimBP_C(o.Pointer); }
        public static VR4Player_FirstPerson_Game_AnimBP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4Player_FirstPerson_Game_AnimBP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4Player_FirstPerson_Game_AnimBP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x3B0));
        public AnimNode_Root AnimGraphNode_Root => new AnimNode_Root(AddrOf(0x3B8));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0x3E8));
        public AnimNode_Fabrik AnimGraphNode_Fabrik => new AnimNode_Fabrik(AddrOf(0x410));
        public AnimNode_Fabrik AnimGraphNode_Fabrik_2 => new AnimNode_Fabrik(AddrOf(0x5B0));
        public AnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose => new AnimNode_SaveCachedPose(AddrOf(0x750));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose => new AnimNode_UseCachedPose(AddrOf(0x808));
        public AnimNode_LayeredBoneBlend AnimGraphNode_LayeredBoneBlend => new AnimNode_LayeredBoneBlend(AddrOf(0x830));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose_2 => new AnimNode_UseCachedPose(AddrOf(0x8F0));
        public AnimNode_Slot AnimGraphNode_Slot => new AnimNode_Slot(AddrOf(0x918));
        public AnimNode_LayeredBoneBlend AnimGraphNode_LayeredBoneBlend_2 => new AnimNode_LayeredBoneBlend(AddrOf(0x960));
        public AnimNode_Slot AnimGraphNode_Slot_2 => new AnimNode_Slot(AddrOf(0xA20));
        public AnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose => new AnimNode_LinkedInputPose(AddrOf(0xA68));
        public AnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_2 => new AnimNode_SaveCachedPose(AddrOf(0xAE0));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose_3 => new AnimNode_UseCachedPose(AddrOf(0xB98));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose_4 => new AnimNode_UseCachedPose(AddrOf(0xBC0));
        public AnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace => new AnimNode_ConvertLocalToComponentSpace(AddrOf(0xBE8));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone => new AnimNode_ModifyBone(AddrOf(0xC08));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_2 => new AnimNode_ModifyBone(AddrOf(0xD10));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_3 => new AnimNode_ModifyBone(AddrOf(0xE18));
        public AnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_3 => new AnimNode_SaveCachedPose(AddrOf(0xF20));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose_5 => new AnimNode_UseCachedPose(AddrOf(0xFD8));
        public AnimNode_LayeredBoneBlend AnimGraphNode_LayeredBoneBlend_3 => new AnimNode_LayeredBoneBlend(AddrOf(0x1000));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose_6 => new AnimNode_UseCachedPose(AddrOf(0x10C0));
        public AnimNode_Slot AnimGraphNode_Slot_3 => new AnimNode_Slot(AddrOf(0x10E8));
        public AnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_4 => new AnimNode_SaveCachedPose(AddrOf(0x1130));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose_7 => new AnimNode_UseCachedPose(AddrOf(0x11E8));
        public AnimNode_LayeredBoneBlend AnimGraphNode_LayeredBoneBlend_4 => new AnimNode_LayeredBoneBlend(AddrOf(0x1210));
        public AnimNode_UseCachedPose AnimGraphNode_UseCachedPose_8 => new AnimNode_UseCachedPose(AddrOf(0x12D0));
        public AnimNode_Slot AnimGraphNode_Slot_4 => new AnimNode_Slot(AddrOf(0x12F8));
        public AnimNode_Fabrik AnimGraphNode_Fabrik_3 => new AnimNode_Fabrik(AddrOf(0x1340));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_4 => new AnimNode_ModifyBone(AddrOf(0x14E0));
        public AnimNode_ModifyCurve AnimGraphNode_ModifyCurve => new AnimNode_ModifyCurve(AddrOf(0x15E8));
        public AnimNode_ModifyCurve AnimGraphNode_ModifyCurve_2 => new AnimNode_ModifyCurve(AddrOf(0x1640));
        public Transform LeftHandTarget => new Transform(AddrOf(0x16A0));
        public Transform RightHandTarget => new Transform(AddrOf(0x16D0));
        public bool MirrorView { get => Native.GetPropBool(Pointer, "MirrorView"); set => Native.SetPropBool(Pointer, "MirrorView", value); }
        public VR4GamePlayerPawn PlayerPawn { get { var __p = GetAt<global::System.IntPtr>(0x1708); return __p==global::System.IntPtr.Zero?null:new VR4GamePlayerPawn(__p); } set => SetAt(0x1708, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vector PelvisOffset => new Vector(AddrOf(0x1710));
        public float SpineTwist { get => GetAt<float>(0x171C); set => SetAt(0x171C, value); }
        public Transform HeadTarget => new Transform(AddrOf(0x1720));
        public void AnimGraph(global::System.IntPtr InPose, global::System.IntPtr AnimGraph)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, InPose);
            __pb.Set<global::System.IntPtr>(0x10, AnimGraph);
            CallRaw("AnimGraph", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_VR4Player_FirstPerson_Game_AnimBP_AnimGraphNode_ModifyBone_F9F5F71D473A49BEFC01F689E5BB8EE2()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_VR4Player_FirstPerson_Game_AnimBP_AnimGraphNode_ModifyBone_F9F5F71D473A49BEFC01F689E5BB8EE2", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_VR4Player_FirstPerson_Game_AnimBP_AnimGraphNode_ModifyBone_8324CD5C4BC254DCA6AB92A2E030E57A()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_VR4Player_FirstPerson_Game_AnimBP_AnimGraphNode_ModifyBone_8324CD5C4BC254DCA6AB92A2E030E57A", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_VR4Player_FirstPerson_Game_AnimBP_AnimGraphNode_ModifyBone_F9C85BFC4474CEE342B40889F7413C8D()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_VR4Player_FirstPerson_Game_AnimBP_AnimGraphNode_ModifyBone_F9C85BFC4474CEE342B40889F7413C8D", __pb.Bytes);
        }
        public void BlueprintUpdateAnimation(float DeltaTimeX)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaTimeX);
            CallRaw("BlueprintUpdateAnimation", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4Player_FirstPerson_Game_AnimBP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4Player_FirstPerson_Game_AnimBP", __pb.Bytes);
        }
    }

}
