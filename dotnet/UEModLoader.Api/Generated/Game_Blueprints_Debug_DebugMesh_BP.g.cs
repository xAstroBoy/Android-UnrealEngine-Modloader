// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMesh_BP
using System;

namespace UEModLoader.Game
{
    public class DebugMesh_BP_C : DebugMesh
    {
        public const string UeClassName = "DebugMesh_BP_C";
        public DebugMesh_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new DebugMesh_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DebugMesh_BP_C(p);
        public static DebugMesh_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugMesh_BP_C(o.Pointer); }
        public static DebugMesh_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugMesh_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugMesh_BP_C(a[i].Pointer); return r; }
    }

}
