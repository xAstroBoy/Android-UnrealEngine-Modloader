// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/Mercenaries/UI_Mercenaries_CoverVignette
using System;

namespace UEModLoader.Game
{
    public class UI_Mercenaries_CoverVignette_C : Actor
    {
        public const string UeClassName = "UI_Mercenaries_CoverVignette_C";
        public UI_Mercenaries_CoverVignette_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Mercenaries_CoverVignette_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Mercenaries_CoverVignette_C(p);
        public static UI_Mercenaries_CoverVignette_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Mercenaries_CoverVignette_C(o.Pointer); }
        public static UI_Mercenaries_CoverVignette_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Mercenaries_CoverVignette_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Mercenaries_CoverVignette_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public ParticleSystemComponent ParticleSystem_Embers_BG { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new ParticleSystemComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Plane_BG { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ParticleSystemComponent ParticleSystem_BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new ParticleSystemComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Material_BG { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Plane_FG { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ParticleSystemComponent ParticleSystem_Embers_FG { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new ParticleSystemComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneCaptureComponent2D CaptureComponent { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new SceneCaptureComponent2D(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void UserConstructionScript()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UserConstructionScript", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Mercenaries_CoverVignette(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Mercenaries_CoverVignette", __pb.Bytes);
        }
    }

}
