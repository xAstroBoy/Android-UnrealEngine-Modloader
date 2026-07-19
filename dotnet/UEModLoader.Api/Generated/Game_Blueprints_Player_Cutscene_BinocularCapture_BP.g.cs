// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Cutscene/BinocularCapture_BP
using System;

namespace UEModLoader.Game
{
    public class BinocularCapture_BP_C : Actor
    {
        public const string UeClassName = "BinocularCapture_BP_C";
        public BinocularCapture_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new BinocularCapture_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BinocularCapture_BP_C(p);
        public static BinocularCapture_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BinocularCapture_BP_C(o.Pointer); }
        public static BinocularCapture_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BinocularCapture_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BinocularCapture_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent BinocularOverlay { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneCaptureComponent2D BinocularCaptureComponent2D { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new SceneCaptureComponent2D(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public bool Active { get => Native.GetPropBool(Pointer, "Active"); set => Native.SetPropBool(Pointer, "Active", value); }
        public BinocularOverlay_BP_C Ref_Widget { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new BinocularOverlay_BP_C(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4CutsceneManager_BP_C Ref_CutsceneManager { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new VR4CutsceneManager_BP_C(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public void UpdateState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateState", __pb.Bytes);
        }
        public void UserConstructionScript()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UserConstructionScript", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_BinocularCapture_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_BinocularCapture_BP", __pb.Bytes);
        }
    }

}
