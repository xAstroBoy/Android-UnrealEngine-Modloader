// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/FilesUIScreen_Entries_BP
using System;

namespace UEModLoader.Game
{
    public class FilesUIScreen_Entries_BP_C : VR4FilesUIScreen_Entries
    {
        public const string UeClassName = "FilesUIScreen_Entries_BP_C";
        public FilesUIScreen_Entries_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new FilesUIScreen_Entries_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FilesUIScreen_Entries_BP_C(p);
        public static FilesUIScreen_Entries_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FilesUIScreen_Entries_BP_C(o.Pointer); }
        public static FilesUIScreen_Entries_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FilesUIScreen_Entries_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FilesUIScreen_Entries_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public WidgetComponent Widget_Frame { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent Button_Arrow_Right { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent Button_Arrow_Left { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIScrollComponent ListScroll { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new VR4UIScrollComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent HeaderAttach { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent StaticMesh { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> Files => new TArray<global::System.IntPtr>(AddrOf(0x298)); // TArray<struct>
        public FilesUIScreen_HeadingButton_BP_C HeaderButton { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new FilesUIScreen_HeadingButton_BP_C(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> Buttons => new TArray<global::System.IntPtr>(AddrOf(0x2B0)); // TArray<UObject*>
        public UI_PauseMenu_Content_Files_BP_C PauseMenu_FilesContent { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Content_Files_BP_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int CurrentListType { get => GetAt<int>(0x2C8); set => SetAt(0x2C8, value); }
        public int ListTypeCount { get => GetAt<int>(0x2CC); set => SetAt(0x2CC, value); }
        public UI_Files_ListFrame_C Ref_ListFrame_Widget { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new UI_Files_ListFrame_C(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void GetFileContentFromID(EItemId ItemId, global::System.IntPtr FileContent, bool Found)
        {
            var __pb = new ParamBuffer(41);
            __pb.Set<byte>(0x0, (byte)ItemId);
            __pb.Set<global::System.IntPtr>(0x8, FileContent);
            __pb.Set<byte>(0x28, (byte)(Found?1:0));
            CallRaw("GetFileContentFromID", __pb.Bytes);
        }
        public void UpdateHeaderText()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateHeaderText", __pb.Bytes);
        }
        public void GetEntryRelativeTransform(int Index, global::System.IntPtr Relative_Transform)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set(0x0, Index);
            __pb.Set<global::System.IntPtr>(0x10, Relative_Transform);
            CallRaw("GetEntryRelativeTransform", __pb.Bytes);
        }
        public void ClearButtons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearButtons", __pb.Bytes);
        }
        public void SpawnEntryButtons(int ListType)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ListType);
            CallRaw("SpawnEntryButtons", __pb.Bytes);
        }
        public void SpawnHeaderButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnHeaderButton", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void EntryButtonClicked(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("EntryButtonClicked", __pb.Bytes);
        }
        public void HeaderButtonClicked(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("HeaderButtonClicked", __pb.Bytes);
        }
        public void IncrementListType()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IncrementListType", __pb.Bytes);
        }
        public void DecrementListType()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DecrementListType", __pb.Bytes);
        }
        public void ReceiveEnterScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveEnterScreen", __pb.Bytes);
        }
        public void OnClick_Arrow_Left(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("OnClick_Arrow_Left", __pb.Bytes);
        }
        public void OnHover_Arrow_Left(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHover_Arrow_Left", __pb.Bytes);
        }
        public void OnUnhover_Arrow_Left(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhover_Arrow_Left", __pb.Bytes);
        }
        public void OnClick_Arrow_Right(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("OnClick_Arrow_Right", __pb.Bytes);
        }
        public void OnHover_Arrow_Right(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnHover_Arrow_Right", __pb.Bytes);
        }
        public void OnUnhover_Arrow_Right(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("OnUnhover_Arrow_Right", __pb.Bytes);
        }
        public void BndEvt__ListScroll_K2Node_ComponentBoundEvent_0_ScrollComponentUpdated__DelegateSignature(VR4UIScrollComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("BndEvt__ListScroll_K2Node_ComponentBoundEvent_0_ScrollComponentUpdated__DelegateSignature", __pb.Bytes);
        }
        public void PresetList(int ListType)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ListType);
            CallRaw("PresetList", __pb.Bytes);
        }
        public void ExecuteUbergraph_FilesUIScreen_Entries_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_FilesUIScreen_Entries_BP", __pb.Bytes);
        }
    }

}
