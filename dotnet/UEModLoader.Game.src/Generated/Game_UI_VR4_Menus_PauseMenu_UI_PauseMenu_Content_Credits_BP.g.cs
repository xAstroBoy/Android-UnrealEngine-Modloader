// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Content_Credits_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Content_Credits_BP_C : UI_PauseMenu_Content_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Content_Credits_BP_C";
        public UI_PauseMenu_Content_Credits_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Content_Credits_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Content_Credits_BP_C(p);
        public static UI_PauseMenu_Content_Credits_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Content_Credits_BP_C(o.Pointer); }
        public static UI_PauseMenu_Content_Credits_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Content_Credits_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Content_Credits_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x240));
        public SceneComponent ScreenAttach { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Track_Right { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Track_Left { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Frame_Right { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Panel_Menu { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Frame_Left { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Content { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent FilesPanel { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float PopBack_Value_7F84F01E4DF423D8671CAA9DD397D3EE { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public byte PopBack__Direction_7F84F01E4DF423D8671CAA9DD397D3EE { get => GetAt<byte>(0x28C); set => SetAt(0x28C, value); }
        public TimelineComponent PopBack { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float PopForward_NewTrack_0_6DEED3294F7F817638B4AF8F84481AB7 { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public byte PopForward__Direction_6DEED3294F7F817638B4AF8F84481AB7 { get => GetAt<byte>(0x29C); set => SetAt(0x29C, value); }
        public TimelineComponent PopForward { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Panel_SlideOut_SlideOut_7D71BF8544C672F25DC9089969A99A51 { get => GetAt<float>(0x2A8); set => SetAt(0x2A8, value); }
        public byte Panel_SlideOut__Direction_7D71BF8544C672F25DC9089969A99A51 { get => GetAt<byte>(0x2AC); set => SetAt(0x2AC, value); }
        public TimelineComponent Panel_SlideOut { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float FoldUp_Value_965D136F4E2FA35C2AB9108A15D0DDFD { get => GetAt<float>(0x2B8); set => SetAt(0x2B8, value); }
        public byte FoldUp__Direction_965D136F4E2FA35C2AB9108A15D0DDFD { get => GetAt<byte>(0x2BC); set => SetAt(0x2BC, value); }
        public TimelineComponent FoldUp { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Unfold_Value_431831A842386103742178B35EF47F82 { get => GetAt<float>(0x2C8); set => SetAt(0x2C8, value); }
        public byte Unfold__Direction_431831A842386103742178B35EF47F82 { get => GetAt<byte>(0x2CC); set => SetAt(0x2CC, value); }
        public TimelineComponent Unfold { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Panel_SlideIn_SlideIn_D13490F541BF088AEE24159A9E32E635 { get => GetAt<float>(0x2D8); set => SetAt(0x2D8, value); }
        public byte Panel_SlideIn__Direction_D13490F541BF088AEE24159A9E32E635 { get => GetAt<byte>(0x2DC); set => SetAt(0x2DC, value); }
        public TimelineComponent Panel_SlideIn { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsViewingNote { get => Native.GetPropBool(Pointer, "IsViewingNote"); set => Native.SetPropBool(Pointer, "IsViewingNote", value); }
        public int SubActionState { get => GetAt<int>(0x2EC); set => SetAt(0x2EC, value); }
        public float Position_OffScreen { get => GetAt<float>(0x2F0); set => SetAt(0x2F0, value); }
        public CreditsUIScreen_BP_C CreditsScreen { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new CreditsUIScreen_BP_C(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void Unfold__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unfold__FinishedFunc", __pb.Bytes);
        }
        public void Unfold__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unfold__UpdateFunc", __pb.Bytes);
        }
        public void FoldUp__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FoldUp__FinishedFunc", __pb.Bytes);
        }
        public void FoldUp__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FoldUp__UpdateFunc", __pb.Bytes);
        }
        public void PopForward__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PopForward__FinishedFunc", __pb.Bytes);
        }
        public void PopForward__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PopForward__UpdateFunc", __pb.Bytes);
        }
        public void PopBack__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PopBack__FinishedFunc", __pb.Bytes);
        }
        public void PopBack__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PopBack__UpdateFunc", __pb.Bytes);
        }
        public void Panel_SlideIn__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Panel_SlideIn__FinishedFunc", __pb.Bytes);
        }
        public void Panel_SlideIn__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Panel_SlideIn__UpdateFunc", __pb.Bytes);
        }
        public void Panel_SlideOut__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Panel_SlideOut__FinishedFunc", __pb.Bytes);
        }
        public void Panel_SlideOut__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Panel_SlideOut__UpdateFunc", __pb.Bytes);
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
        public void ExecuteUbergraph_UI_PauseMenu_Content_Credits_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Content_Credits_BP", __pb.Bytes);
        }
    }

}
