// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/PauseScreen_FirstTime
using System;

namespace UEModLoader.Game
{
    public class PauseScreen_FirstTime_C : VR4PauseUIScreen
    {
        public const string UeClassName = "PauseScreen_FirstTime_C";
        public PauseScreen_FirstTime_C(System.IntPtr ptr) : base(ptr) {}
        public static new PauseScreen_FirstTime_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PauseScreen_FirstTime_C(p);
        public static PauseScreen_FirstTime_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PauseScreen_FirstTime_C(o.Pointer); }
        public static PauseScreen_FirstTime_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PauseScreen_FirstTime_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PauseScreen_FirstTime_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public ChildActorComponent Button { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new ChildActorComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ScaleRoot { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Scale_Alpha_16465D3040D2ED44D39577B82E8DF6BD { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public byte Timeline_Scale__Direction_16465D3040D2ED44D39577B82E8DF6BD { get => GetAt<byte>(0x284); set => SetAt(0x284, value); }
        public TimelineComponent Timeline_Scale { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public Actor BindingActor { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public PauseScreen_FirstTimeWidget_C FirstTimeWidget { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new PauseScreen_FirstTimeWidget_C(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public EPauseMenuScreen ActiveTab { get => (EPauseMenuScreen)GetAt<byte>(0x2A0); set => SetAt(0x2A0, (byte)value); }
        public string ActiveTutorialName => Native.GetPropName(Pointer, "ActiveTutorialName"); // FName
        public FName ActiveTutorialName_Raw { get => GetAt<FName>(0x2A4); set => SetAt(0x2A4, value); }
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
        public void OnPressed(int ButtonId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ButtonId);
            CallRaw("OnPressed", __pb.Bytes);
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
        public void ExecuteUbergraph_PauseScreen_FirstTime(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PauseScreen_FirstTime", __pb.Bytes);
        }
    }

}
