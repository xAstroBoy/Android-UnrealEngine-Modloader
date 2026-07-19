// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Ornaments_Gears
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Ornaments_Gears_C : Actor
    {
        public const string UeClassName = "UI_PauseMenu_Ornaments_Gears_C";
        public UI_PauseMenu_Ornaments_Gears_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Ornaments_Gears_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Ornaments_Gears_C(p);
        public static UI_PauseMenu_Ornaments_Gears_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Ornaments_Gears_C(o.Pointer); }
        public static UI_PauseMenu_Ornaments_Gears_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Ornaments_Gears_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Ornaments_Gears_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public StaticMeshComponent Gear_Left { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Gear_Right { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Gear_Right_2 { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Gear_Right_3 { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Gear_Left_2 { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Gear_Left_3 { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent GearParent { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_0_Rotation_70CEC4B64241483637738BA9EFDD1B4B { get => GetAt<float>(0x268); set => SetAt(0x268, value); }
        public byte Timeline_0__Direction_70CEC4B64241483637738BA9EFDD1B4B { get => GetAt<byte>(0x26C); set => SetAt(0x26C, value); }
        public TimelineComponent Timeline { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void Timeline_0__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_0__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_0__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_0__UpdateFunc", __pb.Bytes);
        }
        public void PlayRotation()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayRotation", __pb.Bytes);
        }
        public void StopRotation()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopRotation", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Ornaments_Gears(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Ornaments_Gears", __pb.Bytes);
        }
    }

}
