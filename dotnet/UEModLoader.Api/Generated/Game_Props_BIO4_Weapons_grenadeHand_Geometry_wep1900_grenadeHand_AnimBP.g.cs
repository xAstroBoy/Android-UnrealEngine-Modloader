// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Props/BIO4/Weapons/grenadeHand/Geometry/wep1900_grenadeHand_AnimBP
using System;

namespace UEModLoader.Game
{
    public class wep1900_grenadeHand_AnimBP_C : AnimInstance
    {
        public const string UeClassName = "wep1900_grenadeHand_AnimBP_C";
        public wep1900_grenadeHand_AnimBP_C(System.IntPtr ptr) : base(ptr) {}
        public static new wep1900_grenadeHand_AnimBP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new wep1900_grenadeHand_AnimBP_C(p);
        public static wep1900_grenadeHand_AnimBP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new wep1900_grenadeHand_AnimBP_C(o.Pointer); }
        public static wep1900_grenadeHand_AnimBP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new wep1900_grenadeHand_AnimBP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new wep1900_grenadeHand_AnimBP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x270));
        public AnimNode_Root AnimGraphNode_Root => new AnimNode_Root(AddrOf(0x278));
        public AnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend => new AnimNode_TwoWayBlend(AddrOf(0x2A8));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone => new AnimNode_ModifyBone(AddrOf(0x370));
        public AnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace => new AnimNode_ConvertLocalToComponentSpace(AddrOf(0x478));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0x498));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_2 => new AnimNode_ModifyBone(AddrOf(0x4B8));
        public AnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend_2 => new AnimNode_TwoWayBlend(AddrOf(0x5C0));
        public AnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace_2 => new AnimNode_ConvertLocalToComponentSpace(AddrOf(0x688));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone_3 => new AnimNode_ModifyBone(AddrOf(0x6A8));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace_2 => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0x7B0));
        public bool PinPopped { get => Native.GetPropBool(Pointer, "PinPopped"); set => Native.SetPropBool(Pointer, "PinPopped", value); }
        public bool PinHeld { get => Native.GetPropBool(Pointer, "PinHeld"); set => Native.SetPropBool(Pointer, "PinHeld", value); }
        public Rotator World_Top_Rotation => new Rotator(AddrOf(0x7D4));
        public void AnimGraph(PoseLink AnimGraph)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, AnimGraph);
            CallRaw("AnimGraph", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_wep1900_grenadeHand_AnimBP_AnimGraphNode_ModifyBone_AD96B43342D75DE317162A8F484C3ED5()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_wep1900_grenadeHand_AnimBP_AnimGraphNode_ModifyBone_AD96B43342D75DE317162A8F484C3ED5", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_wep1900_grenadeHand_AnimBP_AnimGraphNode_ModifyBone_824CDB344B2B0D8D950E838E962E55FE()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_wep1900_grenadeHand_AnimBP_AnimGraphNode_ModifyBone_824CDB344B2B0D8D950E838E962E55FE", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_wep1900_grenadeHand_AnimBP_AnimGraphNode_ModifyBone_1477C136499E431B60D537A68DB3FB63()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_wep1900_grenadeHand_AnimBP_AnimGraphNode_ModifyBone_1477C136499E431B60D537A68DB3FB63", __pb.Bytes);
        }
        public void BlueprintBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BlueprintBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_wep1900_grenadeHand_AnimBP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_wep1900_grenadeHand_AnimBP", __pb.Bytes);
        }
    }

}
