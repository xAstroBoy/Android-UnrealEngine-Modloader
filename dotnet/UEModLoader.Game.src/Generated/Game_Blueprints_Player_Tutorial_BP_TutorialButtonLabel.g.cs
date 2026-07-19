// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/BP_TutorialButtonLabel
using System;

namespace UEModLoader.Game
{
    public class BP_TutorialButtonLabel_C : VR4TutorialButtonLabel
    {
        public const string UeClassName = "BP_TutorialButtonLabel_C";
        public BP_TutorialButtonLabel_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new BP_TutorialButtonLabel_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BP_TutorialButtonLabel_C(p);
        public static BP_TutorialButtonLabel_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BP_TutorialButtonLabel_C(o.Pointer); }
        public static BP_TutorialButtonLabel_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BP_TutorialButtonLabel_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BP_TutorialButtonLabel_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2B8));
        public StaticMeshComponent Sphere { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LineComponent InitialLine { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LineComponent EndLine { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LineComponent LeftLine { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh1 { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ScaleWidget_LeaderlIne_4271D32C4394B53F2A33439AC5419C58 { get => GetAt<float>(0x2F0); set => SetAt(0x2F0, value); }
        public float Timeline_ScaleWidget_NewTrack_0_4271D32C4394B53F2A33439AC5419C58 { get => GetAt<float>(0x2F4); set => SetAt(0x2F4, value); }
        public byte Timeline_ScaleWidget__Direction_4271D32C4394B53F2A33439AC5419C58 { get => GetAt<byte>(0x2F8); set => SetAt(0x2F8, value); }
        public TimelineComponent Timeline_ScaleWidget { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr OnClose => AddrOf(0x308); // 
        public EHandedness Handness { get => (EHandedness)GetAt<byte>(0x318); set => SetAt(0x318, (byte)value); }
        public SceneComponent SceneAnchor { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LineComponent LineAnchor { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr HeaderText => AddrOf(0x330); // 
        public global::System.IntPtr CompareText => AddrOf(0x348); // 
        public LineComponent FirstLine { get { var __p = GetAt<global::System.IntPtr>(0x360); return __p==global::System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x360, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vector EndLineOffset => new Vector(AddrOf(0x368));
        public ButtonLabelWidget_C LabelWidget { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new ButtonLabelWidget_C(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool hasCompleted { get => Native.GetPropBool(Pointer, "hasCompleted"); set => Native.SetPropBool(Pointer, "hasCompleted", value); }
        public ELineTweenState TweenState { get => (ELineTweenState)GetAt<byte>(0x381); set => SetAt(0x381, (byte)value); }
        public TArray<global::System.IntPtr> Lines => new TArray<global::System.IntPtr>(AddrOf(0x388)); // TArray<UObject*>
        public void WorldDilationChanged(float WorldTimeDilation, float PlayerTimeDilation, float CustomTimeDilation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, WorldTimeDilation);
            __pb.Set(0x4, PlayerTimeDilation);
            __pb.Set(0x8, CustomTimeDilation);
            CallRaw("WorldDilationChanged", __pb.Bytes);
        }
        public void EnableLabel(bool Enabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Enabled?1:0));
            CallRaw("EnableLabel", __pb.Bytes);
        }
        public void GetHalfWidth(float HalfWidth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, HalfWidth);
            CallRaw("GetHalfWidth", __pb.Bytes);
        }
        public void Set_Label_Position(bool IsRight)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsRight?1:0));
            CallRaw("Set Label Position", __pb.Bytes);
        }
        public void Timeline_ScaleWidget__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleWidget__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ScaleWidget__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleWidget__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void SetLabel(global::System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            CallRaw("SetLabel", __pb.Bytes);
        }
        public void Hide(bool isCompleted)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(isCompleted?1:0));
            CallRaw("Hide", __pb.Bytes);
        }
        public void Show()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Show", __pb.Bytes);
        }
        public void SelectLineTarget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SelectLineTarget", __pb.Bytes);
        }
        public void ProcessHandTargets(EHandedness Handedness)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Handedness);
            CallRaw("ProcessHandTargets", __pb.Bytes);
        }
        public void StartLineTracking()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartLineTracking", __pb.Bytes);
        }
        public void SetHeaderText(global::System.IntPtr Text, float Scale)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<global::System.IntPtr>(0x0, Text);
            __pb.Set(0x18, Scale);
            CallRaw("SetHeaderText", __pb.Bytes);
        }
        public void ExecuteUbergraph_BP_TutorialButtonLabel(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_BP_TutorialButtonLabel", __pb.Bytes);
        }
        public void OnClose__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnClose__DelegateSignature", __pb.Bytes);
        }
    }

}
