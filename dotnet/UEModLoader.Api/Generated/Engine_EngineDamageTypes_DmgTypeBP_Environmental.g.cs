// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Engine/EngineDamageTypes/DmgTypeBP_Environmental
using System;

namespace UEModLoader.Game
{
    public class DmgTypeBP_Environmental_C : DamageType
    {
        public const string UeClassName = "DmgTypeBP_Environmental_C";
        public DmgTypeBP_Environmental_C(System.IntPtr ptr) : base(ptr) {}
        public static new DmgTypeBP_Environmental_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DmgTypeBP_Environmental_C(p);
        public static DmgTypeBP_Environmental_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DmgTypeBP_Environmental_C(o.Pointer); }
        public static DmgTypeBP_Environmental_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DmgTypeBP_Environmental_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DmgTypeBP_Environmental_C(a[i].Pointer); return r; }
    }

}
