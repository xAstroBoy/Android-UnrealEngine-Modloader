// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Singletons/Bio4_BP
using System;

namespace UEModLoader.Game
{
    public class Bio4_BP_C : Bio4
    {
        public const string UeClassName = "Bio4_BP_C";
        public Bio4_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new Bio4_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Bio4_BP_C(p);
        public static Bio4_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Bio4_BP_C(o.Pointer); }
        public static Bio4_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Bio4_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Bio4_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2A0));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public Object RefHolder { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public void OnLoaded_B60EF4F74FB11B03FAE59D94267F4645(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_B60EF4F74FB11B03FAE59D94267F4645", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_Bio4_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Bio4_BP", __pb.Bytes);
        }
    }

}
