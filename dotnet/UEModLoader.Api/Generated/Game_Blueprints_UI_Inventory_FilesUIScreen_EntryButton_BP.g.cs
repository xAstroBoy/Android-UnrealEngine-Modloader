// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/FilesUIScreen_EntryButton_BP
using System;

namespace UEModLoader.Game
{
    public class FilesUIScreen_EntryButton_BP_C : Actor
    {
        public const string UeClassName = "FilesUIScreen_EntryButton_BP_C";
        public FilesUIScreen_EntryButton_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new FilesUIScreen_EntryButton_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FilesUIScreen_EntryButton_BP_C(p);
        public static FilesUIScreen_EntryButton_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FilesUIScreen_EntryButton_BP_C(o.Pointer); }
        public static FilesUIScreen_EntryButton_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FilesUIScreen_EntryButton_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FilesUIScreen_EntryButton_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget_Text { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent Button { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4MissionFileContent FileContent => new VR4MissionFileContent(AddrOf(0x240));
        public UI_Files_Button_Widget_C WidgetRef { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new UI_Files_Button_Widget_C(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public void UpdateButtonText(System.IntPtr newText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, newText);
            CallRaw("UpdateButtonText", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnClick_Button(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClick_Button", __pb.Bytes);
        }
        public void OnUnhover_Button(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhover_Button", __pb.Bytes);
        }
        public void OnHover_Button(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHover_Button", __pb.Bytes);
        }
        public void ExecuteUbergraph_FilesUIScreen_EntryButton_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_FilesUIScreen_EntryButton_BP", __pb.Bytes);
        }
    }

}
