// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/FloatingUI_Flytext_BP
using System;

namespace UEModLoader.Game
{
    public class FloatingUI_Flytext_BP_C : Actor
    {
        public const string UeClassName = "FloatingUI_Flytext_BP_C";
        public FloatingUI_Flytext_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new FloatingUI_Flytext_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FloatingUI_Flytext_BP_C(p);
        public static FloatingUI_Flytext_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FloatingUI_Flytext_BP_C(o.Pointer); }
        public static FloatingUI_Flytext_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FloatingUI_Flytext_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FloatingUI_Flytext_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ScaleRoot { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Scene { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Movement_Movement_78B7D5A14FCAFBA3EB4C7580A6D13188 { get => GetAt<float>(0x240); set => SetAt(0x240, value); }
        public float Timeline_Movement_Size_78B7D5A14FCAFBA3EB4C7580A6D13188 { get => GetAt<float>(0x244); set => SetAt(0x244, value); }
        public byte Timeline_Movement__Direction_78B7D5A14FCAFBA3EB4C7580A6D13188 { get => GetAt<byte>(0x248); set => SetAt(0x248, value); }
        public TimelineComponent Timeline_Movement { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Message => AddrOf(0x258); // 
        public SceneComponent AttachPoint { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Flytext_C FlyTextWidget { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new UI_Flytext_C(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void Timeline_Movement__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Movement__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Movement__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Movement__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void MoveWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("MoveWidget", __pb.Bytes);
        }
        public void Abort(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("Abort", __pb.Bytes);
        }
        public void ExecuteUbergraph_FloatingUI_Flytext_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_FloatingUI_Flytext_BP", __pb.Bytes);
        }
    }

}
