// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Props/BIO4/Weapons/rocketLauncher/Animation/wep13_Mag_AnimBP
using System;

namespace UEModLoader.Game
{
    public class wep13_Mag_AnimBP_C : AnimInstance
    {
        public const string UeClassName = "wep13_Mag_AnimBP_C";
        public wep13_Mag_AnimBP_C(System.IntPtr ptr) : base(ptr) {}
        public static new wep13_Mag_AnimBP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new wep13_Mag_AnimBP_C(p);
        public static wep13_Mag_AnimBP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new wep13_Mag_AnimBP_C(o.Pointer); }
        public static wep13_Mag_AnimBP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new wep13_Mag_AnimBP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new wep13_Mag_AnimBP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x270));
        public AnimNode_Root AnimGraphNode_Root => new AnimNode_Root(AddrOf(0x278));
        public AnimNode_Slot AnimGraphNode_Slot => new AnimNode_Slot(AddrOf(0x2A8));
        public AnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose => new AnimNode_LinkedInputPose(AddrOf(0x2F0));
        public void AnimGraph(PoseLink InPose, PoseLink AnimGraph)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, InPose);
            __pb.Set<System.IntPtr>(0x10, AnimGraph);
            CallRaw("AnimGraph", __pb.Bytes);
        }
        public void ExecuteUbergraph_wep13_Mag_AnimBP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_wep13_Mag_AnimBP", __pb.Bytes);
        }
    }

}
