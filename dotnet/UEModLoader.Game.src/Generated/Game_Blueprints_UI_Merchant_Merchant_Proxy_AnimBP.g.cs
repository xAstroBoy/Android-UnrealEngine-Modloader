// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Merchant_Proxy_AnimBP
using System;

namespace UEModLoader.Game
{
    public class Merchant_Proxy_AnimBP_C : AnimInstance
    {
        public const string UeClassName = "Merchant_Proxy_AnimBP_C";
        public Merchant_Proxy_AnimBP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Merchant_Proxy_AnimBP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Merchant_Proxy_AnimBP_C(p);
        public static Merchant_Proxy_AnimBP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Merchant_Proxy_AnimBP_C(o.Pointer); }
        public static Merchant_Proxy_AnimBP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Merchant_Proxy_AnimBP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Merchant_Proxy_AnimBP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x270));
        public AnimNode_Root AnimGraphNode_Root => new AnimNode_Root(AddrOf(0x278));
        public AnimNode_ModifyBone AnimGraphNode_ModifyBone => new AnimNode_ModifyBone(AddrOf(0x2A8));
        public AnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace => new AnimNode_ConvertLocalToComponentSpace(AddrOf(0x3B0));
        public AnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace => new AnimNode_ConvertComponentToLocalSpace(AddrOf(0x3D0));
        public AnimNode_SequencePlayer AnimGraphNode_SequencePlayer => new AnimNode_SequencePlayer(AddrOf(0x3F0));
        public AnimNode_StateResult AnimGraphNode_StateResult => new AnimNode_StateResult(AddrOf(0x468));
        public AnimNode_StateMachine AnimGraphNode_StateMachine => new AnimNode_StateMachine(AddrOf(0x498));
        public float BigHeadScale { get => GetAt<float>(0x548); set => SetAt(0x548, value); }
        public void AnimGraph(global::System.IntPtr AnimGraph)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, AnimGraph);
            CallRaw("AnimGraph", __pb.Bytes);
        }
        public void EvaluateGraphExposedInputs_ExecuteUbergraph_Merchant_Proxy_AnimBP_AnimGraphNode_ModifyBone_2752E959436894FB31B76E83948C2B2E()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EvaluateGraphExposedInputs_ExecuteUbergraph_Merchant_Proxy_AnimBP_AnimGraphNode_ModifyBone_2752E959436894FB31B76E83948C2B2E", __pb.Bytes);
        }
        public void BlueprintBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BlueprintBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_Merchant_Proxy_AnimBP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Merchant_Proxy_AnimBP", __pb.Bytes);
        }
    }

}
