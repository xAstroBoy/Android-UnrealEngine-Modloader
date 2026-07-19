// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/HUD/UI_WristWatch_Base_BP
using System;

namespace UEModLoader.Game
{
    public class UI_WristWatch_Base_BP_C : Actor
    {
        public const string UeClassName = "UI_WristWatch_Base_BP_C";
        public UI_WristWatch_Base_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_WristWatch_Base_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_WristWatch_Base_BP_C(p);
        public static UI_WristWatch_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_WristWatch_Base_BP_C(o.Pointer); }
        public static UI_WristWatch_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_WristWatch_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_WristWatch_Base_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4PlayerPawn Pawn { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new VR4PlayerPawn(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SkeletalMeshComponent Mesh { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void UpdateTimeLeft(global::System.IntPtr Min, global::System.IntPtr Sec, global::System.IntPtr Csec, bool isWarning, bool Callback)
        {
            var __pb = new ParamBuffer(74);
            __pb.Set<global::System.IntPtr>(0x0, Min);
            __pb.Set<global::System.IntPtr>(0x18, Sec);
            __pb.Set<global::System.IntPtr>(0x30, Csec);
            __pb.Set<byte>(0x48, (byte)(isWarning?1:0));
            __pb.Set<byte>(0x49, (byte)(Callback?1:0));
            CallRaw("UpdateTimeLeft", __pb.Bytes);
        }
        public void UpdateWatchScore(int Score, bool Callback)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Score);
            __pb.Set<byte>(0x4, (byte)(Callback?1:0));
            CallRaw("UpdateWatchScore", __pb.Bytes);
        }
        public void UpdateArm(EHandedness NewHand, bool Callback)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)NewHand);
            __pb.Set<byte>(0x1, (byte)(Callback?1:0));
            CallRaw("UpdateArm", __pb.Bytes);
        }
        public void UpdateMercScore(int Score)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Score);
            CallRaw("UpdateMercScore", __pb.Bytes);
        }
        public void UpdateMercTime(global::System.IntPtr Min, global::System.IntPtr Sec, global::System.IntPtr Csec, bool isWarning)
        {
            var __pb = new ParamBuffer(73);
            __pb.Set<global::System.IntPtr>(0x0, Min);
            __pb.Set<global::System.IntPtr>(0x18, Sec);
            __pb.Set<global::System.IntPtr>(0x30, Csec);
            __pb.Set<byte>(0x48, (byte)(isWarning?1:0));
            CallRaw("UpdateMercTime", __pb.Bytes);
        }
        public void GetPawn(VR4PlayerPawn Pawn)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Pawn);
            CallRaw("GetPawn", __pb.Bytes);
        }
        public void CameraModeChanged(ECameraMode Mode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Mode);
            CallRaw("CameraModeChanged", __pb.Bytes);
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
        public void ExecuteUbergraph_UI_WristWatch_Base_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_WristWatch_Base_BP", __pb.Bytes);
        }
    }

}
