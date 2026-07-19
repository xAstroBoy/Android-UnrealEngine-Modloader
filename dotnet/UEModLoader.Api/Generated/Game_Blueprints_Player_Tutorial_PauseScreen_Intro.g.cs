// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/PauseScreen_Intro
using System;

namespace UEModLoader.Game
{
    public class PauseScreen_Intro_C : VR4PauseUIScreen
    {
        public const string UeClassName = "PauseScreen_Intro_C";
        public PauseScreen_Intro_C(System.IntPtr ptr) : base(ptr) {}
        public static new PauseScreen_Intro_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PauseScreen_Intro_C(p);
        public static PauseScreen_Intro_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PauseScreen_Intro_C(o.Pointer); }
        public static PauseScreen_Intro_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PauseScreen_Intro_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PauseScreen_Intro_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public StaticMeshComponent LineHorizontal2 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent LineDiagonal1 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget1 { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent LineHorizontal1 { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public Actor BindingActor { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public void MoveButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("MoveButton", __pb.Bytes);
        }
        public void SaveProgress()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SaveProgress", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnPressed(int ButtonId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ButtonId);
            CallRaw("OnPressed", __pb.Bytes);
        }
        public void ExecuteUbergraph_PauseScreen_Intro(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PauseScreen_Intro", __pb.Bytes);
        }
    }

}
