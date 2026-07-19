// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/FrontendNotification
using System;

namespace UEModLoader.Game
{
    public class FrontendNotification_C : VR4PauseUIScreen
    {
        public const string UeClassName = "FrontendNotification_C";
        public FrontendNotification_C(System.IntPtr ptr) : base(ptr) {}
        public static new FrontendNotification_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FrontendNotification_C(p);
        public static FrontendNotification_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FrontendNotification_C(o.Pointer); }
        public static FrontendNotification_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FrontendNotification_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FrontendNotification_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public ChildActorComponent Button { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ScaleRoot { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Scale_Alpha_D66B827B4E90DB49504D8D94E0EE6638 { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public byte Timeline_Scale__Direction_D66B827B4E90DB49504D8D94E0EE6638 { get => GetAt<byte>(0x284); set => SetAt(0x284, value); }
        public TimelineComponent Timeline_Scale { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public Actor BindingActor { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_PauseMenu_Header_Button_C HeaderButton { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Header_Button_C(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public void SaveProgress()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SaveProgress", __pb.Bytes);
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
        public void Continue(int ButtonId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ButtonId);
            CallRaw("Continue", __pb.Bytes);
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
        public void ExecuteUbergraph_FrontendNotification(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_FrontendNotification", __pb.Bytes);
        }
    }

}
