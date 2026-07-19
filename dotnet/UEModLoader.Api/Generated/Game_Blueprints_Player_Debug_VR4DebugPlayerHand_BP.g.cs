// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Debug/VR4DebugPlayerHand_BP
using System;

namespace UEModLoader.Game
{
    public class VR4DebugPlayerHand_BP_C : VR4DebugPlayerHand
    {
        public const string UeClassName = "VR4DebugPlayerHand_BP_C";
        public VR4DebugPlayerHand_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4DebugPlayerHand_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4DebugPlayerHand_BP_C(p);
        public static VR4DebugPlayerHand_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4DebugPlayerHand_BP_C(o.Pointer); }
        public static VR4DebugPlayerHand_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4DebugPlayerHand_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4DebugPlayerHand_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x350));
        public StaticMeshComponent Mesh { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public void PlatformChanged(byte NewActivePlatform, bool Callback)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set(0x0, NewActivePlatform);
            __pb.Set<byte>(0x1, (byte)(Callback?1:0));
            CallRaw("PlatformChanged", __pb.Bytes);
        }
        public void UpdateMesh(byte ActivePlatform)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, ActivePlatform);
            CallRaw("UpdateMesh", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4DebugPlayerHand_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4DebugPlayerHand_BP", __pb.Bytes);
        }
    }

}
