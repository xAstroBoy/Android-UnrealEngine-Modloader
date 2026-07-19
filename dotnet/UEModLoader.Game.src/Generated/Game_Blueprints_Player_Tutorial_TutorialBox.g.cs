// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/TutorialBox
using System;

namespace UEModLoader.Game
{
    public class TutorialBox_C : UserWidget
    {
        public const string UeClassName = "TutorialBox_C";
        public TutorialBox_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new TutorialBox_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TutorialBox_C(p);
        public static TutorialBox_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TutorialBox_C(o.Pointer); }
        public static TutorialBox_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TutorialBox_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TutorialBox_C(a[i].Pointer); return r; }
    }

}
