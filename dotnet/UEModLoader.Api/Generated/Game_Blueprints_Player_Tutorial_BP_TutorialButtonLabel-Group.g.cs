// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/BP_TutorialButtonLabel-Group
using System;

namespace UEModLoader.Game
{
    public class BP_TutorialButtonLabel_Group_C : Actor
    {
        public const string UeClassName = "BP_TutorialButtonLabel-Group_C";
        public BP_TutorialButtonLabel_Group_C(System.IntPtr ptr) : base(ptr) {}
        public static new BP_TutorialButtonLabel_Group_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BP_TutorialButtonLabel_Group_C(p);
        public static BP_TutorialButtonLabel_Group_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BP_TutorialButtonLabel_Group_C(o.Pointer); }
        public static BP_TutorialButtonLabel_Group_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BP_TutorialButtonLabel_Group_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BP_TutorialButtonLabel_Group_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public StaticMeshComponent HLineR { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent HlineRAnchor { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent HLineL { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent HlineLAnchor { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent TutorialAnchor { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public LineComponent VLineR { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent VLineRAnchor { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public LineComponent VLineL { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent VLineLAnchor { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Width_Alpha_91B1630445A312593B25598DB7B1C4C1 { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public byte Timeline_Width__Direction_91B1630445A312593B25598DB7B1C4C1 { get => GetAt<byte>(0x27C); set => SetAt(0x27C, value); }
        public TimelineComponent Timeline_Width { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Height_Alpha_5216C6C843D5C3E0C55F2B98AAEE8411 { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public byte Timeline_Height__Direction_5216C6C843D5C3E0C55F2B98AAEE8411 { get => GetAt<byte>(0x28C); set => SetAt(0x28C, value); }
        public TimelineComponent Timeline_Height { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public float LineDisplayTime { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public float Width { get => GetAt<float>(0x29C); set => SetAt(0x29C, value); }
        public float Height { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public System.IntPtr GrowComplete => AddrOf(0x2A8); // 
        public System.IntPtr ShrinkComplete => AddrOf(0x2B8); // 
        public TimerHandle ShrinkTimer => new TimerHandle(AddrOf(0x2C8));
        public void SetupLines()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupLines", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void UserConstructionScript()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UserConstructionScript", __pb.Bytes);
        }
        public void Timeline_Height__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Height__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Height__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Height__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Width__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Width__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Width__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Width__UpdateFunc", __pb.Bytes);
        }
        public void GrowLines()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GrowLines", __pb.Bytes);
        }
        public void HideLines(bool instant)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(instant?1:0));
            CallRaw("HideLines", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ShrinkDelayExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShrinkDelayExpired", __pb.Bytes);
        }
        public void ExecuteUbergraph_BP_TutorialButtonLabel_Group(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_BP_TutorialButtonLabel-Group", __pb.Bytes);
        }
        public void ShrinkComplete__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShrinkComplete__DelegateSignature", __pb.Bytes);
        }
        public void GrowComplete__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GrowComplete__DelegateSignature", __pb.Bytes);
        }
    }

}
