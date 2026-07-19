// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Button_Discard_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Button_Discard_BP_C : Actor
    {
        public const string UeClassName = "UI_Button_Discard_BP_C";
        public UI_Button_Discard_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Button_Discard_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Button_Discard_BP_C(p);
        public static UI_Button_Discard_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Button_Discard_BP_C(o.Pointer); }
        public static UI_Button_Discard_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Button_Discard_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Button_Discard_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public StaticMeshComponent Static_Button { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Discard { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent Button { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Rotate_Rotation_34DAEE7F4E72DB8BB18EA39B93F3E2F3 { get => GetAt<float>(0x248); set => SetAt(0x248, value); }
        public byte Timeline_Rotate__Direction_34DAEE7F4E72DB8BB18EA39B93F3E2F3 { get => GetAt<byte>(0x24C); set => SetAt(0x24C, value); }
        public TimelineComponent Timeline_Rotate { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Flash_Flash_6B49A9D44928544724ACB897C4B68587 { get => GetAt<float>(0x258); set => SetAt(0x258, value); }
        public byte Timeline_Flash__Direction_6B49A9D44928544724ACB897C4B68587 { get => GetAt<byte>(0x25C); set => SetAt(0x25C, value); }
        public TimelineComponent Timeline_Flash { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_Button_Discard_Widget_C Ref_Widget { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new UI_Button_Discard_Widget_C(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsHidden { get => Native.GetPropBool(Pointer, "IsHidden"); set => Native.SetPropBool(Pointer, "IsHidden", value); }
        public void Timeline_Flash__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Flash__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Flash__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Flash__UpdateFunc", __pb.Bytes);
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
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void Button_Hover(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("Button_Hover", __pb.Bytes);
        }
        public void Button_Unhover(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("Button_Unhover", __pb.Bytes);
        }
        public void Button_Click(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("Button_Click", __pb.Bytes);
        }
        public void SetButtonFill(float FillPercent)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, FillPercent);
            CallRaw("SetButtonFill", __pb.Bytes);
        }
        public void FlashButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlashButton", __pb.Bytes);
        }
        public void RotateIn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RotateIn", __pb.Bytes);
        }
        public void RotateOut()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RotateOut", __pb.Bytes);
        }
        public void HideButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideButton", __pb.Bytes);
        }
        public void ShowButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowButton", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Button_Discard_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Button_Discard_BP", __pb.Bytes);
        }
    }

}
