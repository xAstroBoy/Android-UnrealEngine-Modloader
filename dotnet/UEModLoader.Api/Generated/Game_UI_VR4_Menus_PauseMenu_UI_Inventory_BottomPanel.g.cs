// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Inventory_BottomPanel
using System;

namespace UEModLoader.Game
{
    public class UI_Inventory_BottomPanel_C : Actor
    {
        public const string UeClassName = "UI_Inventory_BottomPanel_C";
        public UI_Inventory_BottomPanel_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Inventory_BottomPanel_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Inventory_BottomPanel_C(p);
        public static UI_Inventory_BottomPanel_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Inventory_BottomPanel_C(o.Pointer); }
        public static UI_Inventory_BottomPanel_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Inventory_BottomPanel_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Inventory_BottomPanel_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public StaticMeshComponent GUI_Inventory_Drawer_Base { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent GUI_Inventory_Drawer_Top { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent TableTiltParent { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent AttachePoint { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent TrayParent { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent PanelParent { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Rotate_Rotation_3F9C2DAF4A1E8E96F86D9EA7027ADBC5 { get => GetAt<float>(0x260); set => SetAt(0x260, value); }
        public byte Timeline_Rotate__Direction_3F9C2DAF4A1E8E96F86D9EA7027ADBC5 { get => GetAt<byte>(0x264); set => SetAt(0x264, value); }
        public TimelineComponent Timeline_Rotate { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_SlideTray_Rotation_5CD8C2274D25433746482387058D33E5 { get => GetAt<float>(0x270); set => SetAt(0x270, value); }
        public float Timeline_SlideTray_Position_5CD8C2274D25433746482387058D33E5 { get => GetAt<float>(0x274); set => SetAt(0x274, value); }
        public byte Timeline_SlideTray__Direction_5CD8C2274D25433746482387058D33E5 { get => GetAt<byte>(0x278); set => SetAt(0x278, value); }
        public TimelineComponent Timeline_SlideTray { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_Button_Discard_BP_C Ref_DiscardButton { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new UI_Button_Discard_BP_C(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr InOutAnimationFinished => AddrOf(0x290); // 
        public void Timeline_SlideTray__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_SlideTray__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_SlideTray__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_SlideTray__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Rotate__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Rotate__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Rotate__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Rotate__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Rotate__RemoveItems__EventFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Rotate__RemoveItems__EventFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void RotatePanel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RotatePanel", __pb.Bytes);
        }
        public void HidePanel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HidePanel", __pb.Bytes);
        }
        public void ShowPanel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowPanel", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Inventory_BottomPanel(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Inventory_BottomPanel", __pb.Bytes);
        }
        public void InOutAnimationFinished__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InOutAnimationFinished__DelegateSignature", __pb.Bytes);
        }
    }

}
