// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Singletons/VR4LobbyGameMode_BP
using System;

namespace UEModLoader.Game
{
    public class VR4LobbyGameMode_BP_C : VR4GameMode
    {
        public const string UeClassName = "VR4LobbyGameMode_BP_C";
        public VR4LobbyGameMode_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4LobbyGameMode_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4LobbyGameMode_BP_C(p);
        public static VR4LobbyGameMode_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4LobbyGameMode_BP_C(o.Pointer); }
        public static VR4LobbyGameMode_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4LobbyGameMode_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4LobbyGameMode_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x580));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x588); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x588, value?.Pointer ?? System.IntPtr.Zero); }
        public void PostBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PostBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4LobbyGameMode_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4LobbyGameMode_BP", __pb.Bytes);
        }
    }

}
