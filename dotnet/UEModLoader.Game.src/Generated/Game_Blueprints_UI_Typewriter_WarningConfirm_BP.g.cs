// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Typewriter/WarningConfirm_BP
using System;

namespace UEModLoader.Game
{
    public class WarningConfirm_BP_C : VR4PauseUIScreen
    {
        public const string UeClassName = "WarningConfirm_BP_C";
        public WarningConfirm_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new WarningConfirm_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new WarningConfirm_BP_C(p);
        public static WarningConfirm_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WarningConfirm_BP_C(o.Pointer); }
        public static WarningConfirm_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WarningConfirm_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WarningConfirm_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public ChildActorComponent ButtonCancel { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ChildActorComponent ButtonOk { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent ScaleRoot { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Scale_Alpha_40BC5DD2494C6D46E447108A90FB3341 { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public byte Timeline_Scale__Direction_40BC5DD2494C6D46E447108A90FB3341 { get => GetAt<byte>(0x28C); set => SetAt(0x28C, value); }
        public TimelineComponent Timeline_Scale { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WarningConfirmWidget_C WarningWidget { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new WarningConfirmWidget_C(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr ButtonColors => AddrOf(0x2A0); // struct UI_WidgetColors_Struct
        public global::System.IntPtr WarningTryAgain => AddrOf(0x4A8); // 
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
        public void ExecuteUbergraph_WarningConfirm_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_WarningConfirm_BP", __pb.Bytes);
        }
        public void WarningTryAgain__DelegateSignature(bool TryAgain)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(TryAgain?1:0));
            CallRaw("WarningTryAgain__DelegateSignature", __pb.Bytes);
        }
    }

}
