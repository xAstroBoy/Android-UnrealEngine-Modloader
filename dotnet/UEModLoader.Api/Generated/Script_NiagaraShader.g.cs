// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/NiagaraShader
using System;

namespace UEModLoader.Game
{
    public enum FNiagaraCompileEventSeverity
    {
        Log = 0,
        Warning = 1,
        Error = 2,
    }

    public class NiagaraDataInterfaceGPUParamInfo : StructProxy
    {
        public NiagaraDataInterfaceGPUParamInfo(System.IntPtr ptr) : base(ptr) {}
        public string DataInterfaceHLSLSymbol => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string DIClassName => Native.ReadFStringAt(AddrOf(0x10)); // FString
        public TArray<System.IntPtr> GeneratedFunctions => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<struct>
    }

    public class NiagaraDataInterfaceGeneratedFunction : StructProxy
    {
        public NiagaraDataInterfaceGeneratedFunction(System.IntPtr ptr) : base(ptr) {}
    }

    public class NiagaraCompileEvent : StructProxy
    {
        public NiagaraCompileEvent(System.IntPtr ptr) : base(ptr) {}
        public FNiagaraCompileEventSeverity Severity { get => (FNiagaraCompileEventSeverity)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public string Message => Native.ReadFStringAt(AddrOf(0x8)); // FString
        public Guid NodeGuid => new Guid(AddrOf(0x18));
        public Guid PinGuid => new Guid(AddrOf(0x28));
        public TArray<System.IntPtr> StackGuids => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<struct>
    }

}
