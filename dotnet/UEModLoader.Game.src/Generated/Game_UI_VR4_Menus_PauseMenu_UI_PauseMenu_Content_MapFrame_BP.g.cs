// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Content_MapFrame_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Content_MapFrame_BP_C : UI_PauseMenu_Content_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Content_MapFrame_BP_C";
        public UI_PauseMenu_Content_MapFrame_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Content_MapFrame_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Content_MapFrame_BP_C(p);
        public static UI_PauseMenu_Content_MapFrame_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Content_MapFrame_BP_C(o.Pointer); }
        public static UI_PauseMenu_Content_MapFrame_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Content_MapFrame_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Content_MapFrame_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x240));
        public WidgetComponent Heading { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Buttons { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ExtensionHinge_Right { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorMesh_Right { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ExtensionHinge_Left { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorMesh_Left { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Frame { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorSlat_Left { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorSlat_Right { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent MapParent { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent Button_04 { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent Button_03 { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent Button_02 { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent Button_01 { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Door_Left { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Door_Right { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ContentParent { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float RotateClose_ExtensionRotation_6A2280D946F5AE446947BFA7C032DE05 { get => GetAt<float>(0x2D8); set => SetAt(0x2D8, value); }
        public float RotateClose_Back_6A2280D946F5AE446947BFA7C032DE05 { get => GetAt<float>(0x2DC); set => SetAt(0x2DC, value); }
        public float RotateClose_Slide_6A2280D946F5AE446947BFA7C032DE05 { get => GetAt<float>(0x2E0); set => SetAt(0x2E0, value); }
        public float RotateClose_Rotation_6A2280D946F5AE446947BFA7C032DE05 { get => GetAt<float>(0x2E4); set => SetAt(0x2E4, value); }
        public byte RotateClose__Direction_6A2280D946F5AE446947BFA7C032DE05 { get => GetAt<byte>(0x2E8); set => SetAt(0x2E8, value); }
        public TimelineComponent RotateClose { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float RotateOpen_ExtensionRotation_C1E83EBE438B05358FFED1BFE9C0D9D8 { get => GetAt<float>(0x2F8); set => SetAt(0x2F8, value); }
        public float RotateOpen_Forward_C1E83EBE438B05358FFED1BFE9C0D9D8 { get => GetAt<float>(0x2FC); set => SetAt(0x2FC, value); }
        public float RotateOpen_Slide_C1E83EBE438B05358FFED1BFE9C0D9D8 { get => GetAt<float>(0x300); set => SetAt(0x300, value); }
        public float RotateOpen_Rotation_C1E83EBE438B05358FFED1BFE9C0D9D8 { get => GetAt<float>(0x304); set => SetAt(0x304, value); }
        public byte RotateOpen__Direction_C1E83EBE438B05358FFED1BFE9C0D9D8 { get => GetAt<byte>(0x308); set => SetAt(0x308, value); }
        public TimelineComponent RotateOpen { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float SlideOut_SlideOut_3EC3785D4400006473166F91B24C65CE { get => GetAt<float>(0x318); set => SetAt(0x318, value); }
        public byte SlideOut__Direction_3EC3785D4400006473166F91B24C65CE { get => GetAt<byte>(0x31C); set => SetAt(0x31C, value); }
        public TimelineComponent SlideOut { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float SlideIn_SlideIn_1B7E9BA94C962BF9EDBCC6996658EF97 { get => GetAt<float>(0x328); set => SetAt(0x328, value); }
        public byte SlideIn__Direction_1B7E9BA94C962BF9EDBCC6996658EF97 { get => GetAt<byte>(0x32C); set => SetAt(0x32C, value); }
        public TimelineComponent SlideIn { get { var __p = GetAt<global::System.IntPtr>(0x330); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x330, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MapUIScreen_BP_C MapScreen { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new MapUIScreen_BP_C(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void InitializeKeys()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeKeys", __pb.Bytes);
        }
        public void InitializeMarkerButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeMarkerButtons", __pb.Bytes);
        }
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
        public void RotateOpen__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RotateOpen__FinishedFunc", __pb.Bytes);
        }
        public void RotateOpen__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RotateOpen__UpdateFunc", __pb.Bytes);
        }
        public void RotateClose__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RotateClose__FinishedFunc", __pb.Bytes);
        }
        public void RotateClose__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RotateClose__UpdateFunc", __pb.Bytes);
        }
        public void PlayOutro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayOutro", __pb.Bytes);
        }
        public void PlayIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayIntro", __pb.Bytes);
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
        public void ContinueOpen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContinueOpen", __pb.Bytes);
        }
        public void SkipIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipIntro", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Content_MapFrame_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Content_MapFrame_BP", __pb.Bytes);
        }
    }

}
