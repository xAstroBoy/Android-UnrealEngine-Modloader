// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/BP_TutorialButtonLabel-Static
using System;

namespace UEModLoader.Game
{
    public class BP_TutorialButtonLabel_Static_C : Actor
    {
        public const string UeClassName = "BP_TutorialButtonLabel-Static_C";
        public BP_TutorialButtonLabel_Static_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new BP_TutorialButtonLabel_Static_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BP_TutorialButtonLabel_Static_C(p);
        public static BP_TutorialButtonLabel_Static_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BP_TutorialButtonLabel_Static_C(o.Pointer); }
        public static BP_TutorialButtonLabel_Static_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BP_TutorialButtonLabel_Static_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BP_TutorialButtonLabel_Static_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public StaticMeshComponent SphereRoot { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent VR4UIButton { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ButtonAnchor { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent WidgetRoot { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent LabelLineAnchor { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent AnchorDiagonal { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LineComponent line { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent AnchorLine { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent LineDiagonal { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LineComponent RightLine { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Sphere { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Widget_Alpha_5F1E4D2A45D4779962E5FDB9762395F8 { get => GetAt<float>(0x290); set => SetAt(0x290, value); }
        public byte Timeline_Widget__Direction_5F1E4D2A45D4779962E5FDB9762395F8 { get => GetAt<byte>(0x294); set => SetAt(0x294, value); }
        public TimelineComponent Timeline_Widget { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_LabelLine_Alpha_520D369744F5975D2DC5A2A074EAF209 { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public byte Timeline_LabelLine__Direction_520D369744F5975D2DC5A2A074EAF209 { get => GetAt<byte>(0x2A4); set => SetAt(0x2A4, value); }
        public TimelineComponent Timeline_LabelLine { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Diagonal_Alpha_9C72CAE84CC4CFC1BFAA61A0D58F1BE9 { get => GetAt<float>(0x2B0); set => SetAt(0x2B0, value); }
        public byte Timeline_Diagonal__Direction_9C72CAE84CC4CFC1BFAA61A0D58F1BE9 { get => GetAt<byte>(0x2B4); set => SetAt(0x2B4, value); }
        public TimelineComponent Timeline_Diagonal { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Leader_Alpha_6F443414431DB5BF2CF5ADB6957CB58A { get => GetAt<float>(0x2C0); set => SetAt(0x2C0, value); }
        public byte Timeline_Leader__Direction_6F443414431DB5BF2CF5ADB6957CB58A { get => GetAt<byte>(0x2C4); set => SetAt(0x2C4, value); }
        public TimelineComponent Timeline_Leader { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr ButtonPress => AddrOf(0x2D0); // 
        public SceneComponent SceneAnchor { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LineComponent LineAnchor { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr HeaderText => AddrOf(0x2F0); // 
        public global::System.IntPtr LabelText => AddrOf(0x308); // 
        public ButtonLabelWidget_C LabelWidget { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new ButtonLabelWidget_C(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vector LabelOffset => new Vector(AddrOf(0x328));
        public Rotator LabelRotationOffset => new Rotator(AddrOf(0x334));
        public bool HasButton { get => Native.GetPropBool(Pointer, "HasButton"); set => Native.SetPropBool(Pointer, "HasButton", value); }
        public string TutorialName => Native.GetPropName(Pointer, "TutorialName"); // FName
        public FName TutorialName_Raw { get => GetAt<FName>(0x344); set => SetAt(0x344, value); }
        public int LabelIndex { get => GetAt<int>(0x34C); set => SetAt(0x34C, value); }
        public bool Activated { get => Native.GetPropBool(Pointer, "Activated"); set => Native.SetPropBool(Pointer, "Activated", value); }
        public float LeaderLineLength { get => GetAt<float>(0x354); set => SetAt(0x354, value); }
        public float LabelLineLength { get => GetAt<float>(0x358); set => SetAt(0x358, value); }
        public float DiagScale { get => GetAt<float>(0x35C); set => SetAt(0x35C, value); }
        public float LineDisplayTime { get => GetAt<float>(0x360); set => SetAt(0x360, value); }
        public global::System.IntPtr ButtonRemoved => AddrOf(0x368); // 
        public bool VerticalLeaderLine { get => Native.GetPropBool(Pointer, "VerticalLeaderLine"); set => Native.SetPropBool(Pointer, "VerticalLeaderLine", value); }
        public float YPivot { get => GetAt<float>(0x37C); set => SetAt(0x37C, value); }
        public bool White { get => Native.GetPropBool(Pointer, "White"); set => Native.SetPropBool(Pointer, "White", value); }
        public void SetupLines()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetupLines", __pb.Bytes);
        }
        public void SetButtonSize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetButtonSize", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void Timeline_Leader__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Leader__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Leader__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Leader__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Diagonal__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Diagonal__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Diagonal__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Diagonal__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_LabelLine__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_LabelLine__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_LabelLine__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_LabelLine__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Widget__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Widget__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Widget__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Widget__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_0_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_1_OnUIComponentStateChanged__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__VR4UIButton_K2Node_ComponentBoundEvent_2_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ShowLabel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowLabel", __pb.Bytes);
        }
        public void HideLabel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideLabel", __pb.Bytes);
        }
        public void ExecuteUbergraph_BP_TutorialButtonLabel_Static(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_BP_TutorialButtonLabel-Static", __pb.Bytes);
        }
        public void ButtonRemoved__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ButtonRemoved__DelegateSignature", __pb.Bytes);
        }
        public void ButtonPress__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ButtonPress__DelegateSignature", __pb.Bytes);
        }
    }

}
