// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Cutscene/CutscenePaused
using System;

namespace UEModLoader.Game
{
    public class CutscenePaused_C : UserWidget
    {
        public const string UeClassName = "CutscenePaused_C";
        public CutscenePaused_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new CutscenePaused_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new CutscenePaused_C(p);
        public static CutscenePaused_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CutscenePaused_C(o.Pointer); }
        public static CutscenePaused_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CutscenePaused_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CutscenePaused_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public ButtonImage_C ButtonImagePause { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay InnerBox { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay OutterBox { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void ExecuteUbergraph_CutscenePaused(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_CutscenePaused", __pb.Bytes);
        }
    }

}
