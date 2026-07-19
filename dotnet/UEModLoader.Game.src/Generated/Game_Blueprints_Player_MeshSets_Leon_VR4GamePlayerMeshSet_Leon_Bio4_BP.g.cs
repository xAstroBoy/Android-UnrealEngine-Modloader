// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/MeshSets/Leon/VR4GamePlayerMeshSet_Leon_Bio4_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayerMeshSet_Leon_Bio4_BP_C : VR4GamePlayerMeshSet_Leon_Base_BP_C
    {
        public const string UeClassName = "VR4GamePlayerMeshSet_Leon_Bio4_BP_C";
        public VR4GamePlayerMeshSet_Leon_Bio4_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayerMeshSet_Leon_Bio4_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4GamePlayerMeshSet_Leon_Bio4_BP_C(p);
        public static VR4GamePlayerMeshSet_Leon_Bio4_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayerMeshSet_Leon_Bio4_BP_C(o.Pointer); }
        public static VR4GamePlayerMeshSet_Leon_Bio4_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayerMeshSet_Leon_Bio4_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayerMeshSet_Leon_Bio4_BP_C(a[i].Pointer); return r; }
    }

}
