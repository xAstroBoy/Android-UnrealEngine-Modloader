// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Interfaces/CutsceneListener
using System;

namespace UEModLoader.Game
{
    public class CutsceneListener_C : Interface
    {
        public const string UeClassName = "CutsceneListener_C";
        public CutsceneListener_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new CutsceneListener_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new CutsceneListener_C(p);
        public static CutsceneListener_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CutsceneListener_C(o.Pointer); }
        public static CutsceneListener_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CutsceneListener_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CutsceneListener_C(a[i].Pointer); return r; }
        public void CutsceneEnded(global::System.IntPtr Cutscene, bool Callback)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, Cutscene);
            __pb.Set<byte>(0x10, (byte)(Callback?1:0));
            CallRaw("CutsceneEnded", __pb.Bytes);
        }
        public void CutsceneStarted(global::System.IntPtr Cutscene, bool Callback)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<global::System.IntPtr>(0x0, Cutscene);
            __pb.Set<byte>(0x10, (byte)(Callback?1:0));
            CallRaw("CutsceneStarted", __pb.Bytes);
        }
    }

}
