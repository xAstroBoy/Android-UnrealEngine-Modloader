// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Singletons/VR4Achievements_BP
using System;

namespace UEModLoader.Game
{
    public class VR4Achievements_BP_C : VR4Achievements
    {
        public const string UeClassName = "VR4Achievements_BP_C";
        public VR4Achievements_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4Achievements_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4Achievements_BP_C(p);
        public static VR4Achievements_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4Achievements_BP_C(o.Pointer); }
        public static VR4Achievements_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4Achievements_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4Achievements_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void OnInitialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnInitialize", __pb.Bytes);
        }
        public void OnAchievementUnlocked(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("OnAchievementUnlocked", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4Achievements_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4Achievements_BP", __pb.Bytes);
        }
    }

}
