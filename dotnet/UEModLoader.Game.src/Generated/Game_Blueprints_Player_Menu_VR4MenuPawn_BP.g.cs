// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Menu/VR4MenuPawn_BP
using System;

namespace UEModLoader.Game
{
    public class VR4MenuPawn_BP_C : VR4MenuPlayerPawn
    {
        public const string UeClassName = "VR4MenuPawn_BP_C";
        public VR4MenuPawn_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4MenuPawn_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4MenuPawn_BP_C(p);
        public static VR4MenuPawn_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4MenuPawn_BP_C(o.Pointer); }
        public static VR4MenuPawn_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4MenuPawn_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4MenuPawn_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x10F0));
        public Actor watchActor { get { var __p = GetAt<global::System.IntPtr>(0x10F8); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x10F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_WristWatch_Base_BP_C WatchClass { get { var __p = GetAt<global::System.IntPtr>(0x1100); return __p==global::System.IntPtr.Zero?null:new UI_WristWatch_Base_BP_C(__p); } set => SetAt(0x1100, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SpawnUI()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnUI", __pb.Bytes);
        }
        public void DestroyUI()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyUI", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void OnHandsStateChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnHandsStateChanged", __pb.Bytes);
        }
        public void OnVisibilityChanged(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("OnVisibilityChanged", __pb.Bytes);
        }
        public void OnMeshVisibilityChanged(EHandedness Hand, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Hand);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("OnMeshVisibilityChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4MenuPawn_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4MenuPawn_BP", __pb.Bytes);
        }
    }

}
