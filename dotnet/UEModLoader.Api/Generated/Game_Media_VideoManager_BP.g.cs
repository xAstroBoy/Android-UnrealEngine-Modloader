// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Media/VideoManager_BP
using System;

namespace UEModLoader.Game
{
    public class VideoManager_BP_C : Actor
    {
        public const string UeClassName = "VideoManager_BP_C";
        public VideoManager_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VideoManager_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VideoManager_BP_C(p);
        public static VideoManager_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VideoManager_BP_C(o.Pointer); }
        public static VideoManager_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VideoManager_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VideoManager_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public EPlayerPawn StoredPawnType { get => (EPlayerPawn)GetAt<byte>(0x230); set => SetAt(0x230, (byte)value); }
        public float FadeInTime { get => GetAt<float>(0x234); set => SetAt(0x234, value); }
        public TimerHandle Timer => new TimerHandle(AddrOf(0x238));
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void VideoComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("VideoComplete", __pb.Bytes);
        }
        public void ExecuteUbergraph_VideoManager_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VideoManager_BP", __pb.Bytes);
        }
    }

}
