// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/ComfortCustomizeConfirm_BP
using System;

namespace UEModLoader.Game
{
    public class ComfortCustomizeConfirm_BP_C : VR4PauseUIScreen
    {
        public const string UeClassName = "ComfortCustomizeConfirm_BP_C";
        public ComfortCustomizeConfirm_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new ComfortCustomizeConfirm_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ComfortCustomizeConfirm_BP_C(p);
        public static ComfortCustomizeConfirm_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ComfortCustomizeConfirm_BP_C(o.Pointer); }
        public static ComfortCustomizeConfirm_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ComfortCustomizeConfirm_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ComfortCustomizeConfirm_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public ChildActorComponent ButtonCancel { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent ButtonConfirm { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ScaleRoot { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_MovieFade_Alpha_1F084C0C46D7BC18A8BFECAB1081FAAE { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public byte Timeline_MovieFade__Direction_1F084C0C46D7BC18A8BFECAB1081FAAE { get => GetAt<byte>(0x28C); set => SetAt(0x28C, value); }
        public TimelineComponent Timeline_MovieFade { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Scale_Alpha_1E7008BC4789349B9F2A00B2D381BE48 { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public byte Timeline_Scale__Direction_1E7008BC4789349B9F2A00B2D381BE48 { get => GetAt<byte>(0x29C); set => SetAt(0x29C, value); }
        public TimelineComponent Timeline_Scale { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor BindingActor { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EPauseMenuScreen ActiveTab { get => (EPauseMenuScreen)GetAt<byte>(0x2B0); set => SetAt(0x2B0, (byte)value); }
        public string ActiveTutorialName => Native.GetPropName(Pointer, "ActiveTutorialName"); // FName
        public FName ActiveTutorialName_Raw { get => GetAt<FName>(0x2B4); set => SetAt(0x2B4, value); }
        public bool Confirmed_ { get => Native.GetPropBool(Pointer, "Confirmed?"); set => Native.SetPropBool(Pointer, "Confirmed?", value); }
        public global::System.IntPtr TitleText => AddrOf(0x2C0); // 
        public global::System.IntPtr DescriptionText => AddrOf(0x2D8); // 
        public float ButtonOffset { get => GetAt<float>(0x2F0); set => SetAt(0x2F0, value); }
        public UI_FullMotionConfirm_Widget_C ConfirmWidget { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new UI_FullMotionConfirm_Widget_C(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public MediaPlayer MediaPlayer { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new MediaPlayer(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool ComfortConfirm { get => Native.GetPropBool(Pointer, "ComfortConfirm"); set => Native.SetPropBool(Pointer, "ComfortConfirm", value); }
        public BinkMediaPlayer BinkMediaPlayer { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new BinkMediaPlayer(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr ModeConfirmed => AddrOf(0x318); // 
        public bool UseMercenariesColors { get => Native.GetPropBool(Pointer, "UseMercenariesColors"); set => Native.SetPropBool(Pointer, "UseMercenariesColors", value); }
        public void MoveButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("MoveButton", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void Timeline_Scale__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Scale__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Scale__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Scale__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_MovieFade__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MovieFade__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_MovieFade__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_MovieFade__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnConfirmPressed(int ButtonId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ButtonId);
            CallRaw("OnConfirmPressed", __pb.Bytes);
        }
        public void ScaleUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ScaleUp", __pb.Bytes);
        }
        public void Scaledown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Scaledown", __pb.Bytes);
        }
        public void OnCancelPressed(int ButtonId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ButtonId);
            CallRaw("OnCancelPressed", __pb.Bytes);
        }
        public void FadeInMovie()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeInMovie", __pb.Bytes);
        }
        public void PlayMovie()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayMovie", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_ComfortCustomizeConfirm_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ComfortCustomizeConfirm_BP", __pb.Bytes);
        }
        public void ModeConfirmed__DelegateSignature(bool ComfortConfirmed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(ComfortConfirmed?1:0));
            CallRaw("ModeConfirmed__DelegateSignature", __pb.Bytes);
        }
    }

}
