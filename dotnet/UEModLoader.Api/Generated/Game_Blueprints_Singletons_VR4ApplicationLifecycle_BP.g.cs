// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Singletons/VR4ApplicationLifecycle_BP
using System;

namespace UEModLoader.Game
{
    public class VR4ApplicationLifecycle_BP_C : Actor
    {
        public const string UeClassName = "VR4ApplicationLifecycle_BP_C";
        public VR4ApplicationLifecycle_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4ApplicationLifecycle_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4ApplicationLifecycle_BP_C(p);
        public static VR4ApplicationLifecycle_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4ApplicationLifecycle_BP_C(o.Pointer); }
        public static VR4ApplicationLifecycle_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4ApplicationLifecycle_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4ApplicationLifecycle_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ApplicationWillEnterBackground()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ApplicationWillEnterBackground", __pb.Bytes);
        }
        public void ApplicationHasEnteredForeground()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ApplicationHasEnteredForeground", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4ApplicationLifecycle_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4ApplicationLifecycle_BP", __pb.Bytes);
        }
    }

}
