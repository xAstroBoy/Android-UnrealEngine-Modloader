// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/NiagaraCore
using System;

namespace UEModLoader.Game
{
    public class NiagaraCompileHash : StructProxy
    {
        public NiagaraCompileHash(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> DataHash => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<uint8>
    }

    public class NiagaraMergeable : Object
    {
        public const string UeClassName = "NiagaraMergeable";
        public NiagaraMergeable(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraMergeable FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraMergeable(p);
        public static NiagaraMergeable FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraMergeable(o.Pointer); }
        public static NiagaraMergeable[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraMergeable[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraMergeable(a[i].Pointer); return r; }
    }

    public class NiagaraDataInterfaceBase : NiagaraMergeable
    {
        public const string UeClassName = "NiagaraDataInterfaceBase";
        public NiagaraDataInterfaceBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new NiagaraDataInterfaceBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NiagaraDataInterfaceBase(p);
        public static NiagaraDataInterfaceBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NiagaraDataInterfaceBase(o.Pointer); }
        public static NiagaraDataInterfaceBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NiagaraDataInterfaceBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NiagaraDataInterfaceBase(a[i].Pointer); return r; }
    }

}
