// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Content_Trifold_Base_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Content_Trifold_Base_BP_C : UI_PauseMenu_Content_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Content_Trifold_Base_BP_C";
        public UI_PauseMenu_Content_Trifold_Base_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Content_Trifold_Base_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Content_Trifold_Base_BP_C(p);
        public static UI_PauseMenu_Content_Trifold_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Content_Trifold_Base_BP_C(o.Pointer); }
        public static UI_PauseMenu_Content_Trifold_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Content_Trifold_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Content_Trifold_Base_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x240));
        public SceneComponent Central_Cover { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Central_Cover_AttachPoint { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Background_Plane { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Door_Left_AttachPoint { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Door_Right_AttachPoint { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CentralCoverMesh { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ExtensionHinge_Right { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Door_Right_Mesh { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ExtensionHinge_Left { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Door_Left_Mesh { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Frame_Mesh { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorSlat_Left { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorSlat_Right { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Main_Content_AttachPoint { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Door_Left { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Door_Right { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ContentParent { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float RotateCloseBeforeCover_ExtensionRotation_813268494D82DE538963A5A73C58574E { get => GetAt<float>(0x2D0); set => SetAt(0x2D0, value); }
        public float RotateCloseBeforeCover_Back_813268494D82DE538963A5A73C58574E { get => GetAt<float>(0x2D4); set => SetAt(0x2D4, value); }
        public float RotateCloseBeforeCover_Slide_813268494D82DE538963A5A73C58574E { get => GetAt<float>(0x2D8); set => SetAt(0x2D8, value); }
        public float RotateCloseBeforeCover_Rotation_813268494D82DE538963A5A73C58574E { get => GetAt<float>(0x2DC); set => SetAt(0x2DC, value); }
        public byte RotateCloseBeforeCover__Direction_813268494D82DE538963A5A73C58574E { get => GetAt<byte>(0x2E0); set => SetAt(0x2E0, value); }
        public TimelineComponent RotateCloseBeforeCover { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float CoverSlideIn_SlideIn_1234E3044A0D6323112C93ADB0938AE9 { get => GetAt<float>(0x2F0); set => SetAt(0x2F0, value); }
        public byte CoverSlideIn__Direction_1234E3044A0D6323112C93ADB0938AE9 { get => GetAt<byte>(0x2F4); set => SetAt(0x2F4, value); }
        public TimelineComponent CoverSlideIn { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Cover_SlideOut_SlideOut_E9535FDA443615FC2B3E70811F3E34C1 { get => GetAt<float>(0x300); set => SetAt(0x300, value); }
        public byte Cover_SlideOut__Direction_E9535FDA443615FC2B3E70811F3E34C1 { get => GetAt<byte>(0x304); set => SetAt(0x304, value); }
        public TimelineComponent Cover_SlideOut { get { var __p = GetAt<global::System.IntPtr>(0x308); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x308, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float RotateClose_ExtensionRotation_95D5671648E0ED427A8993AFC53512F6 { get => GetAt<float>(0x310); set => SetAt(0x310, value); }
        public float RotateClose_Back_95D5671648E0ED427A8993AFC53512F6 { get => GetAt<float>(0x314); set => SetAt(0x314, value); }
        public float RotateClose_Slide_95D5671648E0ED427A8993AFC53512F6 { get => GetAt<float>(0x318); set => SetAt(0x318, value); }
        public float RotateClose_Rotation_95D5671648E0ED427A8993AFC53512F6 { get => GetAt<float>(0x31C); set => SetAt(0x31C, value); }
        public byte RotateClose__Direction_95D5671648E0ED427A8993AFC53512F6 { get => GetAt<byte>(0x320); set => SetAt(0x320, value); }
        public TimelineComponent RotateClose { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float RotateOpen_ExtensionRotation_1BAC935A4EE27E2B81CDF9AE974A6E50 { get => GetAt<float>(0x330); set => SetAt(0x330, value); }
        public float RotateOpen_Forward_1BAC935A4EE27E2B81CDF9AE974A6E50 { get => GetAt<float>(0x334); set => SetAt(0x334, value); }
        public float RotateOpen_Slide_1BAC935A4EE27E2B81CDF9AE974A6E50 { get => GetAt<float>(0x338); set => SetAt(0x338, value); }
        public float RotateOpen_Rotation_1BAC935A4EE27E2B81CDF9AE974A6E50 { get => GetAt<float>(0x33C); set => SetAt(0x33C, value); }
        public byte RotateOpen__Direction_1BAC935A4EE27E2B81CDF9AE974A6E50 { get => GetAt<byte>(0x340); set => SetAt(0x340, value); }
        public TimelineComponent RotateOpen { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float SlideOut_SlideOut_CC58379747CEB87AA0C306983D8F0EF3 { get => GetAt<float>(0x350); set => SetAt(0x350, value); }
        public byte SlideOut__Direction_CC58379747CEB87AA0C306983D8F0EF3 { get => GetAt<byte>(0x354); set => SetAt(0x354, value); }
        public TimelineComponent SlideOut { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float SlideIn_SlideIn_3E838F684318B7EA59ABC4872329C87A { get => GetAt<float>(0x360); set => SetAt(0x360, value); }
        public byte SlideIn__Direction_3E838F684318B7EA59ABC4872329C87A { get => GetAt<byte>(0x364); set => SetAt(0x364, value); }
        public TimelineComponent SlideIn { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIScreen UIScreen { get { var __p = GetAt<global::System.IntPtr>(0x370); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x370, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIScreen UIScreen_BP { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIScreen Door_Right_BP { get { var __p = GetAt<global::System.IntPtr>(0x380); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x380, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIScreen Door_Left_BP { get { var __p = GetAt<global::System.IntPtr>(0x388); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x388, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIScreen CentralCover_BP { get { var __p = GetAt<global::System.IntPtr>(0x390); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x390, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIScreen DoorRightScreen { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIScreen DoorLeftScreen { get { var __p = GetAt<global::System.IntPtr>(0x3A0); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x3A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIScreen CentralCoverScreen { get { var __p = GetAt<global::System.IntPtr>(0x3A8); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x3A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool arePanelsOpen_ { get => Native.GetPropBool(Pointer, "arePanelsOpen?"); set => Native.SetPropBool(Pointer, "arePanelsOpen?", value); }
        public VR4UIScreen CoverScreen { get { var __p = GetAt<global::System.IntPtr>(0x3B8); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x3B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr AllScreensReady => AddrOf(0x3C0); // 
        public bool areScreensReady_ { get => Native.GetPropBool(Pointer, "areScreensReady?"); set => Native.SetPropBool(Pointer, "areScreensReady?", value); }
        public global::System.IntPtr CoverScreenHasClosed => AddrOf(0x3D8); // 
        public bool UseLeftPanelOnly { get => Native.GetPropBool(Pointer, "UseLeftPanelOnly"); set => Native.SetPropBool(Pointer, "UseLeftPanelOnly", value); }
        public bool SkipToPanelsOpen { get => Native.GetPropBool(Pointer, "SkipToPanelsOpen"); set => Native.SetPropBool(Pointer, "SkipToPanelsOpen", value); }
        public bool isCoverScreenUpdate_ { get => Native.GetPropBool(Pointer, "isCoverScreenUpdate?"); set => Native.SetPropBool(Pointer, "isCoverScreenUpdate?", value); }
        public VR4UIScreen switchingUIScreen { get { var __p = GetAt<global::System.IntPtr>(0x3F0); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x3F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public byte CoverScreenUpdateType { get => GetAt<byte>(0x3F8); set => SetAt(0x3F8, value); }
        public VR4UIScreen UpdateCoverClass { get { var __p = GetAt<global::System.IntPtr>(0x400); return __p==global::System.IntPtr.Zero?null:new VR4UIScreen(__p); } set => SetAt(0x400, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool openAfterRestore { get => Native.GetPropBool(Pointer, "openAfterRestore"); set => Native.SetPropBool(Pointer, "openAfterRestore", value); }
        public bool isLargeCoverActive_ { get => Native.GetPropBool(Pointer, "isLargeCoverActive?"); set => Native.SetPropBool(Pointer, "isLargeCoverActive?", value); }
        public void ShouldPanelsStartOpen_(bool StartPanelsOpen)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(StartPanelsOpen?1:0));
            CallRaw("ShouldPanelsStartOpen?", __pb.Bytes);
        }
        public void SwapCoverMesh(bool isLargeCover_)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(isLargeCover_?1:0));
            CallRaw("SwapCoverMesh", __pb.Bytes);
        }
        public void Swap_Screen(VR4UIScreen NewScreenClass, VR4UIScreen Screen, SceneComponent AttachPoint, bool isNewGameOptions_, EQuickComfortSetting NewGameComfortOption)
        {
            var __pb = new ParamBuffer(26);
            __pb.SetObject(0x0, NewScreenClass);
            __pb.SetObject(0x8, Screen);
            __pb.SetObject(0x10, AttachPoint);
            __pb.Set<byte>(0x18, (byte)(isNewGameOptions_?1:0));
            __pb.Set<byte>(0x19, (byte)NewGameComfortOption);
            CallRaw("Swap Screen", __pb.Bytes);
        }
        public void Push_Cover_UIScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Push Cover UIScreen", __pb.Bytes);
        }
        public void PushOpenedUIScreens()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PushOpenedUIScreens", __pb.Bytes);
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
        public void CoverSlideIn__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CoverSlideIn__FinishedFunc", __pb.Bytes);
        }
        public void CoverSlideIn__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CoverSlideIn__UpdateFunc", __pb.Bytes);
        }
        public void Cover_SlideOut__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Cover_SlideOut__FinishedFunc", __pb.Bytes);
        }
        public void Cover_SlideOut__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Cover_SlideOut__UpdateFunc", __pb.Bytes);
        }
        public void RotateCloseBeforeCover__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RotateCloseBeforeCover__FinishedFunc", __pb.Bytes);
        }
        public void RotateCloseBeforeCover__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RotateCloseBeforeCover__UpdateFunc", __pb.Bytes);
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
        public void SubAction_A()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SubAction_A", __pb.Bytes);
        }
        public void SubAction_B()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SubAction_B", __pb.Bytes);
        }
        public void SkipIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipIntro", __pb.Bytes);
        }
        public void SkipCoverOpenPanels()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipCoverOpenPanels", __pb.Bytes);
        }
        public void UpdateCoverScreen(VR4UIScreen NewCoverScreen, VR4UIScreen switchingUIScreen, byte ECoverBehavior, bool OpenAfterRestore_)
        {
            var __pb = new ParamBuffer(18);
            __pb.SetObject(0x0, NewCoverScreen);
            __pb.SetObject(0x8, switchingUIScreen);
            __pb.Set(0x10, ECoverBehavior);
            __pb.Set<byte>(0x11, (byte)(OpenAfterRestore_?1:0));
            CallRaw("UpdateCoverScreen", __pb.Bytes);
        }
        public void LowerCoverScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("LowerCoverScreen", __pb.Bytes);
        }
        public void InstantSubActionA()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InstantSubActionA", __pb.Bytes);
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
        public void ExecuteUbergraph_UI_PauseMenu_Content_Trifold_Base_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Content_Trifold_Base_BP", __pb.Bytes);
        }
        public void CoverScreenHasClosed__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CoverScreenHasClosed__DelegateSignature", __pb.Bytes);
        }
        public void AllScreensReady__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AllScreensReady__DelegateSignature", __pb.Bytes);
        }
    }

}
