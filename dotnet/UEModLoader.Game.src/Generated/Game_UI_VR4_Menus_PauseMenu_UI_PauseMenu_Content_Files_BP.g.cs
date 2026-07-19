// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Content_Files_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Content_Files_BP_C : UI_PauseMenu_Content_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Content_Files_BP_C";
        public UI_PauseMenu_Content_Files_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Content_Files_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Content_Files_BP_C(p);
        public static UI_PauseMenu_Content_Files_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Content_Files_BP_C(o.Pointer); }
        public static UI_PauseMenu_Content_Files_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Content_Files_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Content_Files_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x240));
        public StaticMeshComponent Track_Right { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Track_Left { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Frame_Right { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Panel_Notes { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Panel_Menu { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Frame_Left { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Content { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent NoteBlocker { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent MenuBlocker { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_OpenToFile_Alpha_E89A3D1A4349CAD80F5B07BA3C49639A { get => GetAt<float>(0x290); set => SetAt(0x290, value); }
        public byte Timeline_OpenToFile__Direction_E89A3D1A4349CAD80F5B07BA3C49639A { get => GetAt<byte>(0x294); set => SetAt(0x294, value); }
        public TimelineComponent Timeline_OpenToFile { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Unfold_TweenValue_5B28E5DD4AB05EED7C282689BAE60050 { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public byte Unfold__Direction_5B28E5DD4AB05EED7C282689BAE60050 { get => GetAt<byte>(0x2A4); set => SetAt(0x2A4, value); }
        public TimelineComponent Unfold { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float FoldUp_BigPanel_Frame_Right_093B4B3E46B51309B56038A71B675AC2 { get => GetAt<float>(0x2B0); set => SetAt(0x2B0, value); }
        public byte FoldUp_BigPanel__Direction_093B4B3E46B51309B56038A71B675AC2 { get => GetAt<byte>(0x2B4); set => SetAt(0x2B4, value); }
        public TimelineComponent FoldUp_BigPanel { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float PopBack_NewTrack_0_5038267D44C986B792289A9B599D4256 { get => GetAt<float>(0x2C0); set => SetAt(0x2C0, value); }
        public byte PopBack__Direction_5038267D44C986B792289A9B599D4256 { get => GetAt<byte>(0x2C4); set => SetAt(0x2C4, value); }
        public TimelineComponent PopBack { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float PopForward_TweenValue_3BFE682C4D6C1445561B7FA7B04EC668 { get => GetAt<float>(0x2D0); set => SetAt(0x2D0, value); }
        public byte PopForward__Direction_3BFE682C4D6C1445561B7FA7B04EC668 { get => GetAt<byte>(0x2D4); set => SetAt(0x2D4, value); }
        public TimelineComponent PopForward { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float ContractFrame_Panel_Note_Scale_1993C8C841A466B0016D38A3D57C4A36 { get => GetAt<float>(0x2E0); set => SetAt(0x2E0, value); }
        public float ContractFrame_Panel_Note_Location_1993C8C841A466B0016D38A3D57C4A36 { get => GetAt<float>(0x2E4); set => SetAt(0x2E4, value); }
        public float ContractFrame_Panel_Menu_Scale_1993C8C841A466B0016D38A3D57C4A36 { get => GetAt<float>(0x2E8); set => SetAt(0x2E8, value); }
        public float ContractFrame_Panel_Menu_Location_1993C8C841A466B0016D38A3D57C4A36 { get => GetAt<float>(0x2EC); set => SetAt(0x2EC, value); }
        public float ContractFrame_Frame_Left_1993C8C841A466B0016D38A3D57C4A36 { get => GetAt<float>(0x2F0); set => SetAt(0x2F0, value); }
        public float ContractFrame_Frame_Right_1993C8C841A466B0016D38A3D57C4A36 { get => GetAt<float>(0x2F4); set => SetAt(0x2F4, value); }
        public byte ContractFrame__Direction_1993C8C841A466B0016D38A3D57C4A36 { get => GetAt<byte>(0x2F8); set => SetAt(0x2F8, value); }
        public TimelineComponent ContractFrame { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float WidenFrame_Panel_Note_Scale_A3E7AE3042D2A49684A1719A24676177 { get => GetAt<float>(0x308); set => SetAt(0x308, value); }
        public float WidenFrame_Panel_Note_Location_A3E7AE3042D2A49684A1719A24676177 { get => GetAt<float>(0x30C); set => SetAt(0x30C, value); }
        public float WidenFrame_Panel_Menu_Scale_A3E7AE3042D2A49684A1719A24676177 { get => GetAt<float>(0x310); set => SetAt(0x310, value); }
        public float WidenFrame_Panel_Menu_Location_A3E7AE3042D2A49684A1719A24676177 { get => GetAt<float>(0x314); set => SetAt(0x314, value); }
        public float WidenFrame_Frame_Left_A3E7AE3042D2A49684A1719A24676177 { get => GetAt<float>(0x318); set => SetAt(0x318, value); }
        public float WidenFrame_Frame_Right_A3E7AE3042D2A49684A1719A24676177 { get => GetAt<float>(0x31C); set => SetAt(0x31C, value); }
        public byte WidenFrame__Direction_A3E7AE3042D2A49684A1719A24676177 { get => GetAt<byte>(0x320); set => SetAt(0x320, value); }
        public TimelineComponent WidenFrame { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Panel_SlideOut_SlideOut_B4BCC5EA42323BFBCBC1298697702941 { get => GetAt<float>(0x330); set => SetAt(0x330, value); }
        public byte Panel_SlideOut__Direction_B4BCC5EA42323BFBCBC1298697702941 { get => GetAt<byte>(0x334); set => SetAt(0x334, value); }
        public TimelineComponent Panel_SlideOut { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float FoldUp_TweenValue_D1E6534F4AC47D19D859EFBA82F891A9 { get => GetAt<float>(0x340); set => SetAt(0x340, value); }
        public byte FoldUp__Direction_D1E6534F4AC47D19D859EFBA82F891A9 { get => GetAt<byte>(0x344); set => SetAt(0x344, value); }
        public TimelineComponent FoldUp { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Panel_SlideIn_SlideIn_71E54E9F43524C30D064DDB149FE2A94 { get => GetAt<float>(0x350); set => SetAt(0x350, value); }
        public byte Panel_SlideIn__Direction_71E54E9F43524C30D064DDB149FE2A94 { get => GetAt<byte>(0x354); set => SetAt(0x354, value); }
        public TimelineComponent Panel_SlideIn { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsViewingNote { get => Native.GetPropBool(Pointer, "IsViewingNote"); set => Native.SetPropBool(Pointer, "IsViewingNote", value); }
        public int SubActionState { get => GetAt<int>(0x364); set => SetAt(0x364, value); }
        public MaterialInstanceDynamic NoteMaterial { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> NotesArray => new TArray<global::System.IntPtr>(AddrOf(0x370)); // TArray<FText>
        public TArray<global::System.IntPtr> PageNumberArray => new TArray<global::System.IntPtr>(AddrOf(0x380)); // TArray<FText>
        public FilesUIScreen_Entries_BP_C EntriesScreen { get { var __p = GetAt<global::System.IntPtr>(0x390); return __p==global::System.IntPtr.Zero?null:new FilesUIScreen_Entries_BP_C(__p); } set => SetAt(0x390, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool SkipList { get => Native.GetPropBool(Pointer, "SkipList"); set => Native.SetPropBool(Pointer, "SkipList", value); }
        public FilesUIScreen_Note_BP_C NoteScreen { get { var __p = GetAt<global::System.IntPtr>(0x3A0); return __p==global::System.IntPtr.Zero?null:new FilesUIScreen_Note_BP_C(__p); } set => SetAt(0x3A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4MissionFileContent FirstFile => new VR4MissionFileContent(AddrOf(0x3A8));
        public VR4GameInstance_BP_C GameInstance { get { var __p = GetAt<global::System.IntPtr>(0x3C8); return __p==global::System.IntPtr.Zero?null:new VR4GameInstance_BP_C(__p); } set => SetAt(0x3C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool StatusSet { get => Native.GetPropBool(Pointer, "StatusSet"); set => Native.SetPropBool(Pointer, "StatusSet", value); }
        public void InstantFile_(bool TRUE)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(TRUE?1:0));
            CallRaw("InstantFile?", __pb.Bytes);
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
        public void WidenFrame__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WidenFrame__FinishedFunc", __pb.Bytes);
        }
        public void WidenFrame__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WidenFrame__UpdateFunc", __pb.Bytes);
        }
        public void WidenFrame__SwitchVisibility__EventFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WidenFrame__SwitchVisibility__EventFunc", __pb.Bytes);
        }
        public void ContractFrame__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContractFrame__FinishedFunc", __pb.Bytes);
        }
        public void ContractFrame__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContractFrame__UpdateFunc", __pb.Bytes);
        }
        public void ContractFrame__SwitchVisibility__EventFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContractFrame__SwitchVisibility__EventFunc", __pb.Bytes);
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
        public void FoldUp_BigPanel__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FoldUp_BigPanel__FinishedFunc", __pb.Bytes);
        }
        public void FoldUp_BigPanel__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FoldUp_BigPanel__UpdateFunc", __pb.Bytes);
        }
        public void FoldUp_BigPanel__SwitchVisibility__EventFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FoldUp_BigPanel__SwitchVisibility__EventFunc", __pb.Bytes);
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
        public void Timeline_OpenToFile__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_OpenToFile__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_OpenToFile__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_OpenToFile__UpdateFunc", __pb.Bytes);
        }
        public void ExpandPanel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ExpandPanel", __pb.Bytes);
        }
        public void ContractPanel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContractPanel", __pb.Bytes);
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
        public void ShowFile(global::System.IntPtr Content)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<global::System.IntPtr>(0x0, Content);
            CallRaw("ShowFile", __pb.Bytes);
        }
        public void ExitFile()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ExitFile", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void OpenDirectlyWide()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OpenDirectlyWide", __pb.Bytes);
        }
        public void SkipIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipIntro", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Content_Files_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Content_Files_BP", __pb.Bytes);
        }
    }

}
