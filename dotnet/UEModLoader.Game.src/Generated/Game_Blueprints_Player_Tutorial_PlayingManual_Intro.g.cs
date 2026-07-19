// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/PlayingManual_Intro
using System;

namespace UEModLoader.Game
{
    public class PlayingManual_Intro_C : VR4PauseUIScreen
    {
        public const string UeClassName = "PlayingManual_Intro_C";
        public PlayingManual_Intro_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManual_Intro_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlayingManual_Intro_C(p);
        public static PlayingManual_Intro_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManual_Intro_C(o.Pointer); }
        public static PlayingManual_Intro_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManual_Intro_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManual_Intro_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public StaticMeshComponent LineHorizontal2 { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent LineDiagonal1 { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget1 { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent LineHorizontal1 { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor BindingActor { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_PauseMenu_Header_Button_C HeaderButton { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Header_Button_C(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
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
        public void ButtonPressed(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("ButtonPressed", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManual_Intro(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManual_Intro", __pb.Bytes);
        }
    }

}
