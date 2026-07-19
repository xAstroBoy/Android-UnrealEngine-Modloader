// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/SignificanceManager
using System;

namespace UEModLoader.Game
{
    public class SignificanceManager : Object
    {
        public const string UeClassName = "SignificanceManager";
        public SignificanceManager(System.IntPtr ptr) : base(ptr) {}
        public static new SignificanceManager FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SignificanceManager(p);
        public static SignificanceManager FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SignificanceManager(o.Pointer); }
        public static SignificanceManager[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SignificanceManager[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SignificanceManager(a[i].Pointer); return r; }
        public SoftClassPath SignificanceManagerClassName => new SoftClassPath(AddrOf(0x108));
    }

}
