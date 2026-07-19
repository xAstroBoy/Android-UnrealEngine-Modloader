// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Bio4/VR4TutorialPlayerPawn
using System;

namespace UEModLoader.Game
{
    public class VR4TutorialPlayerPawn_C : Interface
    {
        public const string UeClassName = "VR4TutorialPlayerPawn_C";
        public VR4TutorialPlayerPawn_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4TutorialPlayerPawn_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4TutorialPlayerPawn_C(p);
        public static VR4TutorialPlayerPawn_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4TutorialPlayerPawn_C(o.Pointer); }
        public static VR4TutorialPlayerPawn_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4TutorialPlayerPawn_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4TutorialPlayerPawn_C(a[i].Pointer); return r; }
        public void GetForcePropVisibleForTutorial(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("GetForcePropVisibleForTutorial", __pb.Bytes);
        }
        public void SetForcePropVisibleForTutorial(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("SetForcePropVisibleForTutorial", __pb.Bytes);
        }
        public void IsHandVisibleForTutorial(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("IsHandVisibleForTutorial", __pb.Bytes);
        }
        public void SetHandVisibleForTutorial(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("SetHandVisibleForTutorial", __pb.Bytes);
        }
    }

}
