// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Environment/BIO4/1st/r117/CandleLight_Blueprint
using System;

namespace UEModLoader.Game
{
    public class CandleLight_Blueprint_C : PointLight
    {
        public const string UeClassName = "CandleLight_Blueprint_C";
        public CandleLight_Blueprint_C(System.IntPtr ptr) : base(ptr) {}
        public static new CandleLight_Blueprint_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CandleLight_Blueprint_C(p);
        public static CandleLight_Blueprint_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CandleLight_Blueprint_C(o.Pointer); }
        public static CandleLight_Blueprint_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CandleLight_Blueprint_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CandleLight_Blueprint_C(a[i].Pointer); return r; }
    }

}
