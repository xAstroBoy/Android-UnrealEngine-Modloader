// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Props/BIO4/Weapons/grenadeHand/Geometry/wepXX_grenadeHand_Pin_AnimBP
using System;

namespace UEModLoader.Game
{
    public class wepXX_grenadeHand_Pin_AnimBP_C : AnimInstance
    {
        public const string UeClassName = "wepXX_grenadeHand_Pin_AnimBP_C";
        public wepXX_grenadeHand_Pin_AnimBP_C(System.IntPtr ptr) : base(ptr) {}
        public static new wepXX_grenadeHand_Pin_AnimBP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new wepXX_grenadeHand_Pin_AnimBP_C(p);
        public static wepXX_grenadeHand_Pin_AnimBP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new wepXX_grenadeHand_Pin_AnimBP_C(o.Pointer); }
        public static wepXX_grenadeHand_Pin_AnimBP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new wepXX_grenadeHand_Pin_AnimBP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new wepXX_grenadeHand_Pin_AnimBP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x270));
        public AnimNode_Root AnimGraphNode_Root => new AnimNode_Root(AddrOf(0x278));
        public AnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend => new AnimNode_TwoWayBlend(AddrOf(0x2A8));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone => new AnimNode_ModifyBone(AddrOf(0x370));
        public AnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace => new AnimNode_ConvertLocalToComponentSpace(AddrOf(0x478));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_2 => new AnimNode_ModifyBone(AddrOf(0x498));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0x5A0));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace_2 => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0x5C0));
        public AnimNode_AnimDynamics AnimGraphNode_AnimDynamics => new AnimNode_AnimDynamics(AddrOf(0x5E0));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_3 => new AnimNode_ModifyBone(AddrOf(0xA30));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_4 => new AnimNode_ModifyBone(AddrOf(0xB38));
        public AnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend_2 => new AnimNode_TwoWayBlend(AddrOf(0xC40));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace_3 => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0xD08));
        public bool IsHeld { get => Native.GetPropBool(Pointer, "IsHeld"); set => Native.SetPropBool(Pointer, "IsHeld", value); }
        public Rotator RingRotation => new Rotator(AddrOf(0xD2C));
        public Rotator BaseRotation => new Rotator(AddrOf(0xD38));
        public Actor SimSpaceActor { get { var __p = GetAt<System.IntPtr>(0xD48); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0xD48, value?.Pointer ?? System.IntPtr.Zero); }
        public bool PhysicsActive { get => Native.GetPropBool(Pointer, "PhysicsActive"); set => Native.SetPropBool(Pointer, "PhysicsActive", value); }
        public void AnimGraph(PoseLink AnimGraph)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, AnimGraph);
            CallRaw("AnimGraph", __pb.Bytes);
        }
        public void BlueprintUpdateAnimation(float DeltaTimeX)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaTimeX);
            CallRaw("BlueprintUpdateAnimation", __pb.Bytes);
        }
        public void ExecuteUbergraph_wepXX_grenadeHand_Pin_AnimBP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_wepXX_grenadeHand_Pin_AnimBP", __pb.Bytes);
        }
    }

}
