// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/FilesUIScreen_Note_BP
using System;

namespace UEModLoader.Game
{
    public class FilesUIScreen_Note_BP_C : VR4FilesUIScreen_Note
    {
        public const string UeClassName = "FilesUIScreen_Note_BP_C";
        public FilesUIScreen_Note_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new FilesUIScreen_Note_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FilesUIScreen_Note_BP_C(p);
        public static FilesUIScreen_Note_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FilesUIScreen_Note_BP_C(o.Pointer); }
        public static FilesUIScreen_Note_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FilesUIScreen_Note_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FilesUIScreen_Note_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public VR4UIButtonComponent Button_Exit { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent Button_Backward { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent Button_Forward { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Page { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_PauseMenu_Content_Files_BP_C PauseMenu_FileContent { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Content_Files_BP_C(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4MissionFileContent FileContent => new VR4MissionFileContent(AddrOf(0x298));
        public int CurrentPage { get => GetAt<int>(0x2B8); set => SetAt(0x2B8, value); }
        public int CurrentTextureIndex { get => GetAt<int>(0x2BC); set => SetAt(0x2BC, value); }
        public FilesUIScreen_Note_Widget_C PageWidget { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new FilesUIScreen_Note_Widget_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public void SetFileContent(VR4MissionFileContent Content)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, Content);
            CallRaw("SetFileContent", __pb.Bytes);
        }
        public void OnLoaded_3C3B60424CD67CC19417F891429A133D(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_3C3B60424CD67CC19417F891429A133D", __pb.Bytes);
        }
        public void StartAsyncTextureLoad(System.IntPtr TextureRef)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, TextureRef);
            CallRaw("StartAsyncTextureLoad", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void SetPage(int Page)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Page);
            CallRaw("SetPage", __pb.Bytes);
        }
        public void Exit()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Exit", __pb.Bytes);
        }
        public void IncrementPage()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IncrementPage", __pb.Bytes);
        }
        public void DecrementPage()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DecrementPage", __pb.Bytes);
        }
        public void UpdateTexture()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateTexture", __pb.Bytes);
        }
        public void OnClick_Forward(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClick_Forward", __pb.Bytes);
        }
        public void OnHover_Forward(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHover_Forward", __pb.Bytes);
        }
        public void OnUnhover_Forward(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhover_Forward", __pb.Bytes);
        }
        public void OnClick_Backward(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClick_Backward", __pb.Bytes);
        }
        public void OnHover_Backward(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHover_Backward", __pb.Bytes);
        }
        public void OnUnhover_Backward(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhover_Backward", __pb.Bytes);
        }
        public void ExitDuringNote()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ExitDuringNote", __pb.Bytes);
        }
        public void OnClick_Exit(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("OnClick_Exit", __pb.Bytes);
        }
        public void OnHover_Exit(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHover_Exit", __pb.Bytes);
        }
        public void OnUnhover_Exit(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhover_Exit", __pb.Bytes);
        }
        public void ExecuteUbergraph_FilesUIScreen_Note_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_FilesUIScreen_Note_BP", __pb.Bytes);
        }
    }

}
