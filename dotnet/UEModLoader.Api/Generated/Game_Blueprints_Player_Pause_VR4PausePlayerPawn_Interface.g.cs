// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Pause/VR4PausePlayerPawn_Interface
using System;

namespace UEModLoader.Game
{
    public class VR4PausePlayerPawn_Interface_C : Interface
    {
        public const string UeClassName = "VR4PausePlayerPawn_Interface_C";
        public VR4PausePlayerPawn_Interface_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4PausePlayerPawn_Interface_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4PausePlayerPawn_Interface_C(p);
        public static VR4PausePlayerPawn_Interface_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4PausePlayerPawn_Interface_C(o.Pointer); }
        public static VR4PausePlayerPawn_Interface_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4PausePlayerPawn_Interface_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4PausePlayerPawn_Interface_C(a[i].Pointer); return r; }
        public void GetTooltip(System.IntPtr Return)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Return);
            CallRaw("GetTooltip", __pb.Bytes);
        }
    }

}
