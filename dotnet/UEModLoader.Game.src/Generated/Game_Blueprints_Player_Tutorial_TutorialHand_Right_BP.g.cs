// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/TutorialHand_Right_BP
using System;

namespace UEModLoader.Game
{
    public class TutorialHand_Right_BP_C : TutorialHand_Base_BP_C
    {
        public const string UeClassName = "TutorialHand_Right_BP_C";
        public TutorialHand_Right_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new TutorialHand_Right_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TutorialHand_Right_BP_C(p);
        public static TutorialHand_Right_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TutorialHand_Right_BP_C(o.Pointer); }
        public static TutorialHand_Right_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TutorialHand_Right_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TutorialHand_Right_BP_C(a[i].Pointer); return r; }
    }

}
