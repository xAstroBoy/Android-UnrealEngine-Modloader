// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_TabTitle_BP
using System;

namespace UEModLoader.Game
{
    public class UI_TabTitle_BP_C : Actor
    {
        public const string UeClassName = "UI_TabTitle_BP_C";
        public UI_TabTitle_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_TabTitle_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_TabTitle_BP_C(p);
        public static UI_TabTitle_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_TabTitle_BP_C(o.Pointer); }
        public static UI_TabTitle_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_TabTitle_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_TabTitle_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetMercenariesColors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetMercenariesColors", __pb.Bytes);
        }
        public void SetTitleText(global::System.IntPtr NewTitle)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, NewTitle);
            CallRaw("SetTitleText", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_TabTitle_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_TabTitle_BP", __pb.Bytes);
        }
    }

}
