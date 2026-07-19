// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/OptionsConfirmRestart_BP
using System;

namespace UEModLoader.Game
{
    public class OptionsConfirmRestart_BP_C : VR4PauseUIScreen
    {
        public const string UeClassName = "OptionsConfirmRestart_BP_C";
        public OptionsConfirmRestart_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new OptionsConfirmRestart_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OptionsConfirmRestart_BP_C(p);
        public static OptionsConfirmRestart_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OptionsConfirmRestart_BP_C(o.Pointer); }
        public static OptionsConfirmRestart_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OptionsConfirmRestart_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OptionsConfirmRestart_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public ChildActorComponent ButtonCancel { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent ButtonConfirm { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ScaleRoot { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_FadeOut_Fade_7537507B4BB790CC7C5CDE946D032D7D { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public byte Timeline_FadeOut__Direction_7537507B4BB790CC7C5CDE946D032D7D { get => GetAt<byte>(0x28C); set => SetAt(0x28C, value); }
        public TimelineComponent Timeline_FadeOut { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Scale_Alpha_141B200D45C756EB2D201B9A38C4FD4E { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public byte Timeline_Scale__Direction_141B200D45C756EB2D201B9A38C4FD4E { get => GetAt<byte>(0x29C); set => SetAt(0x29C, value); }
        public TimelineComponent Timeline_Scale { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public Actor BindingActor { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public PauseScreen_FirstTimeWidget_C ConfirmationWidget { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new PauseScreen_FirstTimeWidget_C(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public EPauseMenuScreen ActiveTab { get => (EPauseMenuScreen)GetAt<byte>(0x2B8); set => SetAt(0x2B8, (byte)value); }
        public string ActiveTutorialName => Native.GetPropName(Pointer, "ActiveTutorialName"); // FName
        public FName ActiveTutorialName_Raw { get => GetAt<FName>(0x2BC); set => SetAt(0x2BC, value); }
        public bool shouldResetGame_ { get => Native.GetPropBool(Pointer, "shouldResetGame?"); set => Native.SetPropBool(Pointer, "shouldResetGame?", value); }
        public System.IntPtr TitleText => AddrOf(0x2C8); // 
        public System.IntPtr DescriptionText => AddrOf(0x2E0); // 
        public float ButtonOffset { get => GetAt<float>(0x2F8); set => SetAt(0x2F8, value); }
        public bool MercColors { get => Native.GetPropBool(Pointer, "MercColors"); set => Native.SetPropBool(Pointer, "MercColors", value); }
        public bool RestartMerc_ { get => Native.GetPropBool(Pointer, "RestartMerc?"); set => Native.SetPropBool(Pointer, "RestartMerc?", value); }
        public bool ExitMerc_ { get => Native.GetPropBool(Pointer, "ExitMerc?"); set => Native.SetPropBool(Pointer, "ExitMerc?", value); }
        public float MinWidth { get => GetAt<float>(0x300); set => SetAt(0x300, value); }
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
        public void Timeline_FadeOut__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FadeOut__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_FadeOut__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_FadeOut__UpdateFunc", __pb.Bytes);
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
        public void ExecuteUbergraph_OptionsConfirmRestart_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_OptionsConfirmRestart_BP", __pb.Bytes);
        }
    }

}
