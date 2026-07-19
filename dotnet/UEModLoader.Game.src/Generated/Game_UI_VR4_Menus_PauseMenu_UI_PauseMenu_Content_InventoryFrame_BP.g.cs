// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Content_InventoryFrame_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Content_InventoryFrame_BP_C : UI_PauseMenu_Content_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Content_InventoryFrame_BP_C";
        public UI_PauseMenu_Content_InventoryFrame_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Content_InventoryFrame_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Content_InventoryFrame_BP_C(p);
        public static UI_PauseMenu_Content_InventoryFrame_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Content_InventoryFrame_BP_C(o.Pointer); }
        public static UI_PauseMenu_Content_InventoryFrame_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Content_InventoryFrame_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Content_InventoryFrame_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x240));
        public StaticMeshComponent NewHealthPlane_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent BlockingPlane_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent MaxPlane_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent NewHealthPlane_Leon { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent BlockingPlane_Leon { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent MaxPlane_Leon { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent AshleyDisplay { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Tick_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent TickAnchor_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent TickAnchor_Leon { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Tick_Leon { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Drop_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Drop_Leon { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Label_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Label_Leon { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent AshleyDisplayMesh { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent Button_AshleyScreen { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent Button_LeonScreen { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent HealthPlane_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent HealthPlane_Leon { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Dial_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Dial_Leon { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Disk_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Disk_Leon { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent LeonDisplayMesh { get { var __p = GetAt<global::System.IntPtr>(0x308); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x308, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent LeonDisplay { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ExtensionHinge_Right { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorMesh_Right { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ExtensionHinge_Left { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorMesh_Left { get { var __p = GetAt<global::System.IntPtr>(0x330); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x330, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorExtension_Right { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent DoorExtension_Left { get { var __p = GetAt<global::System.IntPtr>(0x340); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x340, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent QuickSelectSlot1 { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent QuickSelectSlot4 { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent QuickSelectSlot3 { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent QuickSelectSlot2 { get { var __p = GetAt<global::System.IntPtr>(0x360); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x360, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ExaminePoint { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent InventoryAttach { get { var __p = GetAt<global::System.IntPtr>(0x370); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x370, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent InventoryPanel { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent TempSwapParent { get { var __p = GetAt<global::System.IntPtr>(0x380); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x380, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent GridParent { get { var __p = GetAt<global::System.IntPtr>(0x388); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x388, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ContentParent { get { var __p = GetAt<global::System.IntPtr>(0x390); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x390, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Door_Left { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Frame { get { var __p = GetAt<global::System.IntPtr>(0x3A0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x3A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Door_Right { get { var __p = GetAt<global::System.IntPtr>(0x3A8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x3A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent BottomPanel { get { var __p = GetAt<global::System.IntPtr>(0x3B0); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x3B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_AshleyDrop_Slide_546AB96744261C7BFF754487149C6F6D { get => GetAt<float>(0x3B8); set => SetAt(0x3B8, value); }
        public byte Timeline_AshleyDrop__Direction_546AB96744261C7BFF754487149C6F6D { get => GetAt<byte>(0x3BC); set => SetAt(0x3BC, value); }
        public TimelineComponent Timeline_AshleyDrop { get { var __p = GetAt<global::System.IntPtr>(0x3C0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_LeonDrop_Slide_846DFFB24E017072292DE686F3F5B3B8 { get => GetAt<float>(0x3C8); set => SetAt(0x3C8, value); }
        public byte Timeline_LeonDrop__Direction_846DFFB24E017072292DE686F3F5B3B8 { get => GetAt<byte>(0x3CC); set => SetAt(0x3CC, value); }
        public TimelineComponent Timeline_LeonDrop { get { var __p = GetAt<global::System.IntPtr>(0x3D0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_HealthSweep_Ashley_Slide_07B77037450F0EB34B11BAA67E97A8C2 { get => GetAt<float>(0x3D8); set => SetAt(0x3D8, value); }
        public byte Timeline_HealthSweep_Ashley__Direction_07B77037450F0EB34B11BAA67E97A8C2 { get => GetAt<byte>(0x3DC); set => SetAt(0x3DC, value); }
        public TimelineComponent Timeline_HealthSweep_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x3E0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_HealthSweep_Leon_Slide_914F045B476FAD2EC08ED08988F8CE64 { get => GetAt<float>(0x3E8); set => SetAt(0x3E8, value); }
        public byte Timeline_HealthSweep_Leon__Direction_914F045B476FAD2EC08ED08988F8CE64 { get => GetAt<byte>(0x3EC); set => SetAt(0x3EC, value); }
        public TimelineComponent Timeline_HealthSweep_Leon { get { var __p = GetAt<global::System.IntPtr>(0x3F0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x3F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_AshleyPanel_Outro_AshleyPanel_5F753AF44A30AF06A8186B909B015B06 { get => GetAt<float>(0x3F8); set => SetAt(0x3F8, value); }
        public byte Timeline_AshleyPanel_Outro__Direction_5F753AF44A30AF06A8186B909B015B06 { get => GetAt<byte>(0x3FC); set => SetAt(0x3FC, value); }
        public TimelineComponent Timeline_AshleyPanel_Outro { get { var __p = GetAt<global::System.IntPtr>(0x400); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x400, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_AshleyPanel_Intro_AshleyPanel_B4E388724088AC072376BB88F30FA0A0 { get => GetAt<float>(0x408); set => SetAt(0x408, value); }
        public byte Timeline_AshleyPanel_Intro__Direction_B4E388724088AC072376BB88F30FA0A0 { get => GetAt<byte>(0x40C); set => SetAt(0x40C, value); }
        public TimelineComponent Timeline_AshleyPanel_Intro { get { var __p = GetAt<global::System.IntPtr>(0x410); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x410, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float RotateClose_ExtensionRotation_60D7EC5B41C0CAB4F65706B1205EE8AB { get => GetAt<float>(0x418); set => SetAt(0x418, value); }
        public float RotateClose_Grid_60D7EC5B41C0CAB4F65706B1205EE8AB { get => GetAt<float>(0x41C); set => SetAt(0x41C, value); }
        public float RotateClose_Slide_60D7EC5B41C0CAB4F65706B1205EE8AB { get => GetAt<float>(0x420); set => SetAt(0x420, value); }
        public float RotateClose_Rotation_60D7EC5B41C0CAB4F65706B1205EE8AB { get => GetAt<float>(0x424); set => SetAt(0x424, value); }
        public byte RotateClose__Direction_60D7EC5B41C0CAB4F65706B1205EE8AB { get => GetAt<byte>(0x428); set => SetAt(0x428, value); }
        public TimelineComponent RotateClose { get { var __p = GetAt<global::System.IntPtr>(0x430); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x430, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float RotateOpen_ExtensionRotation_9AC75F1B4D8B9946FCC10B8A3DBEFAEE { get => GetAt<float>(0x438); set => SetAt(0x438, value); }
        public float RotateOpen_Grid_9AC75F1B4D8B9946FCC10B8A3DBEFAEE { get => GetAt<float>(0x43C); set => SetAt(0x43C, value); }
        public float RotateOpen_Slide_9AC75F1B4D8B9946FCC10B8A3DBEFAEE { get => GetAt<float>(0x440); set => SetAt(0x440, value); }
        public float RotateOpen_Rotation_9AC75F1B4D8B9946FCC10B8A3DBEFAEE { get => GetAt<float>(0x444); set => SetAt(0x444, value); }
        public byte RotateOpen__Direction_9AC75F1B4D8B9946FCC10B8A3DBEFAEE { get => GetAt<byte>(0x448); set => SetAt(0x448, value); }
        public TimelineComponent RotateOpen { get { var __p = GetAt<global::System.IntPtr>(0x450); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x450, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Settle_Back_Bounce_87C8342A46C036F3B0FCA7874FA65898 { get => GetAt<float>(0x458); set => SetAt(0x458, value); }
        public byte Settle_Back__Direction_87C8342A46C036F3B0FCA7874FA65898 { get => GetAt<byte>(0x45C); set => SetAt(0x45C, value); }
        public TimelineComponent Settle_Back { get { var __p = GetAt<global::System.IntPtr>(0x460); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x460, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float SlideOut_SlideOut_78BFA1C544A3DA5F96945C98C9361FFC { get => GetAt<float>(0x468); set => SetAt(0x468, value); }
        public byte SlideOut__Direction_78BFA1C544A3DA5F96945C98C9361FFC { get => GetAt<byte>(0x46C); set => SetAt(0x46C, value); }
        public TimelineComponent SlideOut { get { var __p = GetAt<global::System.IntPtr>(0x470); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x470, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float SlideIn_SlideIn_BFF205B7486FFA62953675BA10E0F568 { get => GetAt<float>(0x478); set => SetAt(0x478, value); }
        public byte SlideIn__Direction_BFF205B7486FFA62953675BA10E0F568 { get => GetAt<byte>(0x47C); set => SetAt(0x47C, value); }
        public TimelineComponent SlideIn { get { var __p = GetAt<global::System.IntPtr>(0x480); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x480, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int PanelSize { get => GetAt<int>(0x488); set => SetAt(0x488, value); }
        public bool IsSwitchingPanel { get => Native.GetPropBool(Pointer, "IsSwitchingPanel"); set => Native.SetPropBool(Pointer, "IsSwitchingPanel", value); }
        public bool IsBottomPanelOpen { get => Native.GetPropBool(Pointer, "IsBottomPanelOpen"); set => Native.SetPropBool(Pointer, "IsBottomPanelOpen", value); }
        public InventoryUIScreen_BP_C InventoryScreen { get { var __p = GetAt<global::System.IntPtr>(0x490); return __p==global::System.IntPtr.Zero?null:new InventoryUIScreen_BP_C(__p); } set => SetAt(0x490, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsBottomPanelRotating { get => Native.GetPropBool(Pointer, "IsBottomPanelRotating"); set => Native.SetPropBool(Pointer, "IsBottomPanelRotating", value); }
        public global::System.IntPtr BottomPanelRotationComplete => AddrOf(0x4A0); // 
        public UI_InventoryHealth_Widget_C Ref_Leon_Widget { get { var __p = GetAt<global::System.IntPtr>(0x4B0); return __p==global::System.IntPtr.Zero?null:new UI_InventoryHealth_Widget_C(__p); } set => SetAt(0x4B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic HpMaterial_Leon { get { var __p = GetAt<global::System.IntPtr>(0x4B8); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x4B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic HpMaterial_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x4C0); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x4C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic DisplayMaterial_Leon { get { var __p = GetAt<global::System.IntPtr>(0x4C8); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x4C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic DisplayMaterial_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x4D0); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x4D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_InventoryHealth_Widget_C Ref_Ashley_Widget { get { var __p = GetAt<global::System.IntPtr>(0x4D8); return __p==global::System.IntPtr.Zero?null:new UI_InventoryHealth_Widget_C(__p); } set => SetAt(0x4D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Name_Leon => AddrOf(0x4E0); // 
        public global::System.IntPtr Name_Ashley => AddrOf(0x4F8); // 
        public int Health_Leon_TotalMax { get => GetAt<int>(0x510); set => SetAt(0x510, value); }
        public LinearColor Color_Health_Good => new LinearColor(AddrOf(0x514));
        public LinearColor Color_Health_Caution => new LinearColor(AddrOf(0x524));
        public LinearColor Color_Health_Danger => new LinearColor(AddrOf(0x534));
        public int Health_Ashley_TotalMax { get => GetAt<int>(0x544); set => SetAt(0x544, value); }
        public byte CurrentHealthState { get => GetAt<byte>(0x548); set => SetAt(0x548, value); }
        public int Health_Leon_CautionThreshold { get => GetAt<int>(0x54C); set => SetAt(0x54C, value); }
        public int Health_Leon_DangerThreshold { get => GetAt<int>(0x550); set => SetAt(0x550, value); }
        public int Health_Ashley_DangerThreshold { get => GetAt<int>(0x554); set => SetAt(0x554, value); }
        public int Health_Ashley_CautionThreshold { get => GetAt<int>(0x558); set => SetAt(0x558, value); }
        public VR4Bio4PlayerHand_Left_BP_C Bio4HandLeft { get { var __p = GetAt<global::System.IntPtr>(0x560); return __p==global::System.IntPtr.Zero?null:new VR4Bio4PlayerHand_Left_BP_C(__p); } set => SetAt(0x560, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4Bio4PlayerHand_Right_BP_C Bio4HandRight { get { var __p = GetAt<global::System.IntPtr>(0x568); return __p==global::System.IntPtr.Zero?null:new VR4Bio4PlayerHand_Right_BP_C(__p); } set => SetAt(0x568, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LinearColor Color_Panel_Unhover => new LinearColor(AddrOf(0x570));
        public LinearColor Color_Panel_Hover_Heal => new LinearColor(AddrOf(0x580));
        public bool AshleyDisplayUnfolded { get => Native.GetPropBool(Pointer, "AshleyDisplayUnfolded"); set => Native.SetPropBool(Pointer, "AshleyDisplayUnfolded", value); }
        public ConsumableUseData CachedAshleyUseResult => new ConsumableUseData(AddrOf(0x594));
        public bool AnimatingLeonHeal { get => Native.GetPropBool(Pointer, "AnimatingLeonHeal"); set => Native.SetPropBool(Pointer, "AnimatingLeonHeal", value); }
        public bool AnimatingAshleyHeal { get => Native.GetPropBool(Pointer, "AnimatingAshleyHeal"); set => Native.SetPropBool(Pointer, "AnimatingAshleyHeal", value); }
        public TimerHandle LeonHealErrorTimerHandle => new TimerHandle(AddrOf(0x5A8));
        public TimerHandle AshleyHealErrorTimerHandle => new TimerHandle(AddrOf(0x5B0));
        public float HealthErrorDuration { get => GetAt<float>(0x5B8); set => SetAt(0x5B8, value); }
        public LinearColor Color_Panel_Hover_IncreaseMax => new LinearColor(AddrOf(0x5BC));
        public MaterialInstanceDynamic HpMaxMaterial_Leon { get { var __p = GetAt<global::System.IntPtr>(0x5D0); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x5D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic HpBlockingMaterial_Leon { get { var __p = GetAt<global::System.IntPtr>(0x5D8); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x5D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic HpNewHealth_Leon { get { var __p = GetAt<global::System.IntPtr>(0x5E0); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x5E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic Hp_MaxMaterial_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x5E8); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x5E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic Hp_BlockingMaterial_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x5F0); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x5F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MaterialInstanceDynamic Hp_NewHealth_Ashley { get { var __p = GetAt<global::System.IntPtr>(0x5F8); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x5F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Fill_PreviewMax_Leon { get => GetAt<float>(0x600); set => SetAt(0x600, value); }
        public float Fill_PreviewBlocking_Leon { get => GetAt<float>(0x604); set => SetAt(0x604, value); }
        public float Fill_PreviewNewHealth_Leon { get => GetAt<float>(0x608); set => SetAt(0x608, value); }
        public float Fill_PreviewMax_Ashley { get => GetAt<float>(0x60C); set => SetAt(0x60C, value); }
        public float Fill_PreviewBlocking_Ashley { get => GetAt<float>(0x610); set => SetAt(0x610, value); }
        public float Fill_PreviewNewHealth_Ashley { get => GetAt<float>(0x614); set => SetAt(0x614, value); }
        public UI_Inventory_BottomPanel_C Ref_BottomPanel { get { var __p = GetAt<global::System.IntPtr>(0x618); return __p==global::System.IntPtr.Zero?null:new UI_Inventory_BottomPanel_C(__p); } set => SetAt(0x618, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsBottomPanelInOutAnimating { get => Native.GetPropBool(Pointer, "IsBottomPanelInOutAnimating"); set => Native.SetPropBool(Pointer, "IsBottomPanelInOutAnimating", value); }
        public bool IsPlayingOutro { get => Native.GetPropBool(Pointer, "IsPlayingOutro"); set => Native.SetPropBool(Pointer, "IsPlayingOutro", value); }
        public bool IsOutroAnimating { get => Native.GetPropBool(Pointer, "IsOutroAnimating"); set => Native.SetPropBool(Pointer, "IsOutroAnimating", value); }
        public bool IsLeonDropShowing { get => Native.GetPropBool(Pointer, "IsLeonDropShowing"); set => Native.SetPropBool(Pointer, "IsLeonDropShowing", value); }
        public bool IsAshleyDropShowing { get => Native.GetPropBool(Pointer, "IsAshleyDropShowing"); set => Native.SetPropBool(Pointer, "IsAshleyDropShowing", value); }
        public InventoryScreen_LeonDisplay_BP_C LeonDisplayActor { get { var __p = GetAt<global::System.IntPtr>(0x628); return __p==global::System.IntPtr.Zero?null:new InventoryScreen_LeonDisplay_BP_C(__p); } set => SetAt(0x628, value?.Pointer ?? global::System.IntPtr.Zero); }
        public InventoryScreen_AshleyDisplay_BP_C AshleyDisplayActor { get { var __p = GetAt<global::System.IntPtr>(0x630); return __p==global::System.IntPtr.Zero?null:new InventoryScreen_AshleyDisplay_BP_C(__p); } set => SetAt(0x630, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Inventory_Health_Drop_Widget_C DropWidgetRef { get { var __p = GetAt<global::System.IntPtr>(0x638); return __p==global::System.IntPtr.Zero?null:new UI_Inventory_Health_Drop_Widget_C(__p); } set => SetAt(0x638, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Inventory_Health_Drop_Widget_C DropLeonRef { get { var __p = GetAt<global::System.IntPtr>(0x640); return __p==global::System.IntPtr.Zero?null:new UI_Inventory_Health_Drop_Widget_C(__p); } set => SetAt(0x640, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Inventory_Health_Drop_Widget_C DropAshleyRef { get { var __p = GetAt<global::System.IntPtr>(0x648); return __p==global::System.IntPtr.Zero?null:new UI_Inventory_Health_Drop_Widget_C(__p); } set => SetAt(0x648, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool ShouldUpdateHealthAndAmmo { get => Native.GetPropBool(Pointer, "ShouldUpdateHealthAndAmmo"); set => Native.SetPropBool(Pointer, "ShouldUpdateHealthAndAmmo", value); }
        public float UpdateHealthAndAmmoTimer { get => GetAt<float>(0x654); set => SetAt(0x654, value); }
        public void GetInventoryPanelActor(Actor PanelCalss)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, PanelCalss);
            CallRaw("GetInventoryPanelActor", __pb.Bytes);
        }
        public void GetPlayerCharacterName(global::System.IntPtr Name)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Name);
            CallRaw("GetPlayerCharacterName", __pb.Bytes);
        }
        public void IsPlayerAshley(bool IsAshley)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsAshley?1:0));
            CallRaw("IsPlayerAshley", __pb.Bytes);
        }
        public void ShowItems()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowItems", __pb.Bytes);
        }
        public void UpdateRenderTargetAshley(bool Show)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            CallRaw("UpdateRenderTargetAshley", __pb.Bytes);
        }
        public void UpdateRenderTargetLeon(bool Show)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            CallRaw("UpdateRenderTargetLeon", __pb.Bytes);
        }
        public void CheckOutroFinished()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckOutroFinished", __pb.Bytes);
        }
        public void SetHealthPreview(bool IsHovered, bool IsAshley)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(IsHovered?1:0));
            __pb.Set<byte>(0x1, (byte)(IsAshley?1:0));
            CallRaw("SetHealthPreview", __pb.Bytes);
        }
        public void ClearCharacterHealthError(bool IsAshley)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsAshley?1:0));
            CallRaw("ClearCharacterHealthError", __pb.Bytes);
        }
        public void SetCharacterDisplayHovered(bool IsHovered, bool IsAshley)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(IsHovered?1:0));
            __pb.Set<byte>(0x1, (byte)(IsAshley?1:0));
            CallRaw("SetCharacterDisplayHovered", __pb.Bytes);
        }
        public void SetCharacterDisplayEnabled(global::System.IntPtr UseResult, bool IsAshley)
        {
            var __pb = new ParamBuffer(13);
            __pb.Set<global::System.IntPtr>(0x0, UseResult);
            __pb.Set<byte>(0xC, (byte)(IsAshley?1:0));
            CallRaw("SetCharacterDisplayEnabled", __pb.Bytes);
        }
        public void UpdateAmmo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateAmmo", __pb.Bytes);
        }
        public void UpdateHealth()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateHealth", __pb.Bytes);
        }
        public void CreateReferences()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CreateReferences", __pb.Bytes);
        }
        public void RemoveItemComplete()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RemoveItemComplete", __pb.Bytes);
        }
        public void PlayClosePanelFx()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayClosePanelFx", __pb.Bytes);
        }
        public void PlayOpenPanelFx()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayOpenPanelFx", __pb.Bytes);
        }
        public void DiscardItem()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DiscardItem", __pb.Bytes);
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
        public void Settle_Back__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Settle Back__FinishedFunc", __pb.Bytes);
        }
        public void Settle_Back__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Settle Back__UpdateFunc", __pb.Bytes);
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
        public void Timeline_AshleyPanel_Intro__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_AshleyPanel_Intro__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_AshleyPanel_Intro__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_AshleyPanel_Intro__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_AshleyPanel_Outro__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_AshleyPanel_Outro__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_AshleyPanel_Outro__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_AshleyPanel_Outro__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_HealthSweep_Leon__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_HealthSweep_Leon__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_HealthSweep_Leon__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_HealthSweep_Leon__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_HealthSweep_Ashley__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_HealthSweep_Ashley__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_HealthSweep_Ashley__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_HealthSweep_Ashley__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_LeonDrop__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_LeonDrop__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_LeonDrop__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_LeonDrop__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_AshleyDrop__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_AshleyDrop__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_AshleyDrop__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_AshleyDrop__UpdateFunc", __pb.Bytes);
        }
        public void PlayOutro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayOutro", __pb.Bytes);
        }
        public void SetPanelSize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetPanelSize", __pb.Bytes);
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
        public void HideBottomPanel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideBottomPanel", __pb.Bytes);
        }
        public void ShowBottomPanel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowBottomPanel", __pb.Bytes);
        }
        public void SkipIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipIntro", __pb.Bytes);
        }
        public void ContinueOpen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContinueOpen", __pb.Bytes);
        }
        public void DragHover_Leon(VR4UIComponent component, VR4UIComponent payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, payload);
            CallRaw("DragHover_Leon", __pb.Bytes);
        }
        public void DragUnhover_Leon(VR4UIComponent component, VR4UIComponent payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, payload);
            CallRaw("DragUnhover_Leon", __pb.Bytes);
        }
        public void DragDrop_Leon(VR4UIComponent component, VR4UIComponent payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, payload);
            CallRaw("DragDrop_Leon", __pb.Bytes);
        }
        public void FoldOut_AshleyPanel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FoldOut_AshleyPanel", __pb.Bytes);
        }
        public void TryHealLeon(EConsumableUseResult UseResult)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)UseResult);
            CallRaw("TryHealLeon", __pb.Bytes);
        }
        public void TryHealAshley(EConsumableUseResult UseResult)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)UseResult);
            CallRaw("TryHealAshley", __pb.Bytes);
        }
        public void DragDrop_Ashley(VR4UIComponent component, VR4UIComponent payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, payload);
            CallRaw("DragDrop_Ashley", __pb.Bytes);
        }
        public void DragHover_Ashley(VR4UIComponent component, VR4UIComponent payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, payload);
            CallRaw("DragHover_Ashley", __pb.Bytes);
        }
        public void DragUnhover_Ashley(VR4UIComponent component, VR4UIComponent payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, payload);
            CallRaw("DragUnhover_Ashley", __pb.Bytes);
        }
        public void ShowLeonHealthError(EConsumableUseResult UseResult)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)UseResult);
            CallRaw("ShowLeonHealthError", __pb.Bytes);
        }
        public void HideLeonHealthError()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideLeonHealthError", __pb.Bytes);
        }
        public void ShowAshleyHealthError(EConsumableUseResult UseResult)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)UseResult);
            CallRaw("ShowAshleyHealthError", __pb.Bytes);
        }
        public void HideAshleyHealthError()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideAshleyHealthError", __pb.Bytes);
        }
        public void BottomPanelInOutAnimationFinished()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BottomPanelInOutAnimationFinished", __pb.Bytes);
        }
        public void ShowLeonDrop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowLeonDrop", __pb.Bytes);
        }
        public void HideLeonDrop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideLeonDrop", __pb.Bytes);
        }
        public void ShowAshleyDrop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowAshleyDrop", __pb.Bytes);
        }
        public void HideAshleyDrop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideAshleyDrop", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Content_InventoryFrame_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Content_InventoryFrame_BP", __pb.Bytes);
        }
        public void BottomPanelRotationComplete__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BottomPanelRotationComplete__DelegateSignature", __pb.Bytes);
        }
    }

}
