// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugWorldTextActor_BP
using System;

namespace UEModLoader.Game
{
    public class DebugWorldTextActor_BP_C : DebugWorldTextActor
    {
        public const string UeClassName = "DebugWorldTextActor_BP_C";
        public DebugWorldTextActor_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new DebugWorldTextActor_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DebugWorldTextActor_BP_C(p);
        public static DebugWorldTextActor_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugWorldTextActor_BP_C(o.Pointer); }
        public static DebugWorldTextActor_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugWorldTextActor_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugWorldTextActor_BP_C(a[i].Pointer); return r; }
    }

}
