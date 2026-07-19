// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Single
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Single_C : UI_PauseMenu_Content_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Single_C";
        public UI_PauseMenu_Single_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Single_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_PauseMenu_Single_C(p);
        public static UI_PauseMenu_Single_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Single_C(o.Pointer); }
        public static UI_PauseMenu_Single_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Single_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Single_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x240));
        public StaticMeshComponent Background_Plane { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent Frame_Mesh { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Main_Content_AttachPoint { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ContentParent { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public float SlideOut_SlideOut_CA5C64D24AC588D8EB9E7EA23AD15046 { get => GetAt<float>(0x268); set => SetAt(0x268, value); }
        public byte SlideOut__Direction_CA5C64D24AC588D8EB9E7EA23AD15046 { get => GetAt<byte>(0x26C); set => SetAt(0x26C, value); }
        public TimelineComponent SlideOut { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public float SlideIn_SlideIn_3C98AF234D3A6D32F49574BDF0449BE2 { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public byte SlideIn__Direction_3C98AF234D3A6D32F49574BDF0449BE2 { get => GetAt<byte>(0x27C); set => SetAt(0x27C, value); }
        public TimelineComponent SlideIn { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIScreen UIScreen { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIScreen UIScreen_BP { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public void SlideIn__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlideIn__FinishedFunc", __pb.Bytes);
        }
        public void SlideIn__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlideIn__UpdateFunc", __pb.Bytes);
        }
        public void SlideOut__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlideOut__FinishedFunc", __pb.Bytes);
        }
        public void SlideOut__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlideOut__UpdateFunc", __pb.Bytes);
        }
        public void PlayIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayIntro", __pb.Bytes);
        }
        public void PlayOutro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayOutro", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void SkipIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipIntro", __pb.Bytes);
        }
        public void MercPlaySelected()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("MercPlaySelected", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Single(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Single", __pb.Bytes);
        }
    }

}
