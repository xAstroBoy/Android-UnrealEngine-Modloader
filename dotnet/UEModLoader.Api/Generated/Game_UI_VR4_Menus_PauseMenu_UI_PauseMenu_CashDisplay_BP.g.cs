// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_CashDisplay_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_CashDisplay_BP_C : Actor
    {
        public const string UeClassName = "UI_PauseMenu_CashDisplay_BP_C";
        public UI_PauseMenu_CashDisplay_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_CashDisplay_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_PauseMenu_CashDisplay_BP_C(p);
        public static UI_PauseMenu_CashDisplay_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_CashDisplay_BP_C(o.Pointer); }
        public static UI_PauseMenu_CashDisplay_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_CashDisplay_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_CashDisplay_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget_Cash { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_CashLabel { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public void SetCashValue(int Value)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Value);
            CallRaw("SetCashValue", __pb.Bytes);
        }
        public void DisableDisplay(int Value)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Value);
            CallRaw("DisableDisplay", __pb.Bytes);
        }
        public void EnableDisplay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EnableDisplay", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_CashDisplay_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_CashDisplay_BP", __pb.Bytes);
        }
    }

}
