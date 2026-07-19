// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/OptionsUIScreen_BP
using System;

namespace UEModLoader.Game
{
    public class OptionsUIScreen_BP_C : VR4OptionsUIScreen
    {
        public const string UeClassName = "OptionsUIScreen_BP_C";
        public OptionsUIScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new OptionsUIScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OptionsUIScreen_BP_C(p);
        public static OptionsUIScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OptionsUIScreen_BP_C(o.Pointer); }
        public static OptionsUIScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OptionsUIScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OptionsUIScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2D0));
        public SceneComponent WarningLoc { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent AttachPoint { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public OptionsScreen_Menu_C CurrentMenu { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new OptionsScreen_Menu_C(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public float EntrySpacing { get => GetAt<float>(0x2F0); set => SetAt(0x2F0, value); }
        public string English => Native.GetPropString(Pointer, "English"); // FString
        public string French => Native.GetPropString(Pointer, "French"); // FString
        public string German => Native.GetPropString(Pointer, "German"); // FString
        public string Spanish => Native.GetPropString(Pointer, "Spanish"); // FString
        public string Italian => Native.GetPropString(Pointer, "Italian"); // FString
        public string Japanese => Native.GetPropString(Pointer, "Japanese"); // FString
        public string Korean => Native.GetPropString(Pointer, "Korean"); // FString
        public VR4GamePlayerSettings Settings => new VR4GamePlayerSettings(AddrOf(0x368));
        public TArray<System.IntPtr> EntryList => new TArray<System.IntPtr>(AddrOf(0x420)); // TArray<struct>
        public bool isStartMenuOptions_ { get => Native.GetPropBool(Pointer, "isStartMenuOptions?"); set => Native.SetPropBool(Pointer, "isStartMenuOptions?", value); }
        public DoorDescriptionPanel_BP_C DescriptionPanel { get { var __p = GetAt<System.IntPtr>(0x438); return __p==System.IntPtr.Zero?null:new DoorDescriptionPanel_BP_C(__p); } set => SetAt(0x438, value?.Pointer ?? System.IntPtr.Zero); }
        public bool isTriFoldMenu_ { get => Native.GetPropBool(Pointer, "isTriFoldMenu?"); set => Native.SetPropBool(Pointer, "isTriFoldMenu?", value); }
        public UI_PauseMenu_Content_Trifold_Base_BP_C TrifoldBaseBP { get { var __p = GetAt<System.IntPtr>(0x448); return __p==System.IntPtr.Zero?null:new UI_PauseMenu_Content_Trifold_Base_BP_C(__p); } set => SetAt(0x448, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> ButtonList => new TArray<System.IntPtr>(AddrOf(0x450)); // TArray<UObject*>
        public bool viewBackstory_ { get => Native.GetPropBool(Pointer, "viewBackstory?"); set => Native.SetPropBool(Pointer, "viewBackstory?", value); }
        public OptionsScreen_Button_C LastVisibleButton { get { var __p = GetAt<System.IntPtr>(0x468); return __p==System.IntPtr.Zero?null:new OptionsScreen_Button_C(__p); } set => SetAt(0x468, value?.Pointer ?? System.IntPtr.Zero); }
        public EQuickComfortSetting QuickSettingCustomization { get => (EQuickComfortSetting)GetAt<byte>(0x470); set => SetAt(0x470, (byte)value); }
        public bool MercColors { get => Native.GetPropBool(Pointer, "MercColors"); set => Native.SetPropBool(Pointer, "MercColors", value); }
        public WarningConfirm_BP_C Warning { get { var __p = GetAt<System.IntPtr>(0x478); return __p==System.IntPtr.Zero?null:new WarningConfirm_BP_C(__p); } set => SetAt(0x478, value?.Pointer ?? System.IntPtr.Zero); }
        public bool TryAgain { get => Native.GetPropBool(Pointer, "TryAgain"); set => Native.SetPropBool(Pointer, "TryAgain", value); }
        public int ValidIndex { get => GetAt<int>(0x484); set => SetAt(0x484, value); }
        public void ApplyNewGameComfortCustomization()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ApplyNewGameComfortCustomization", __pb.Bytes);
        }
        public void SetNewGameComfortCustomizations()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetNewGameComfortCustomizations", __pb.Bytes);
        }
        public void SetNewGameDefaults()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetNewGameDefaults", __pb.Bytes);
        }
        public void SetCostume(VR4MenuEntryDescription Description, int Value)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Value);
            CallRaw("SetCostume", __pb.Bytes);
        }
        public void GetCostume(VR4MenuEntryDescription Description, int Result)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Result);
            CallRaw("GetCostume", __pb.Bytes);
        }
        public void SetViewBackstory(VR4MenuEntryDescription Description, int Value)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Value);
            CallRaw("SetViewBackstory", __pb.Bytes);
        }
        public void GetViewBackstory(VR4MenuEntryDescription Description, int Result)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Result);
            CallRaw("GetViewBackstory", __pb.Bytes);
        }
        public void SetWatchSetting(VR4MenuEntryDescription Description, int Value)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Value);
            CallRaw("SetWatchSetting", __pb.Bytes);
        }
        public void GetWatchSetting(VR4MenuEntryDescription Description, int Value)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Value);
            CallRaw("GetWatchSetting", __pb.Bytes);
        }
        public void ApplyLanguageSetting(VR4MenuEntryDescription Description, int Value)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Value);
            CallRaw("ApplyLanguageSetting", __pb.Bytes);
        }
        public void GetLanguageSetting(VR4MenuEntryDescription Description, int Value)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Value);
            CallRaw("GetLanguageSetting", __pb.Bytes);
        }
        public void RedrawAllEntries()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RedrawAllEntries", __pb.Bytes);
        }
        public void SetOptionMenuContentBase()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetOptionMenuContentBase", __pb.Bytes);
        }
        public void SetDescriptionPanel()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetDescriptionPanel", __pb.Bytes);
        }
        public void GetRelativeEntryTransform(int Index, Transform Transform)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set(0x0, Index);
            __pb.Set<System.IntPtr>(0x10, Transform);
            CallRaw("GetRelativeEntryTransform", __pb.Bytes);
        }
        public Actor SpawnMenuEntry(VR4MenuEntryHandle Handle, int elementIndex)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Handle);
            __pb.Set(0x8, elementIndex);
            CallRaw("SpawnMenuEntry", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new Actor(__p); }
        }
        public Actor Spawn_Menu(VR4Menu menu)
        {
            var __pb = new ParamBuffer(208);
            __pb.Set<System.IntPtr>(0x0, menu);
            CallRaw("Spawn Menu", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0xC8); return __p==System.IntPtr.Zero?null:new Actor(__p); }
        }
        public void Exec_ExitToStartScreen(VR4MenuEntryDescription Description, int Value)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Value);
            CallRaw("Exec_ExitToStartScreen", __pb.Bytes);
        }
        public void Exec_LoadLastCheckpoint(VR4MenuEntryDescription Description, int Value)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Value);
            CallRaw("Exec_LoadLastCheckpoint", __pb.Bytes);
        }
        public void Exec_LoadGame(VR4MenuEntryDescription Description, int Value)
        {
            var __pb = new ParamBuffer(164);
            __pb.Set<System.IntPtr>(0x0, Description);
            __pb.Set(0xA0, Value);
            CallRaw("Exec_LoadGame", __pb.Bytes);
        }
        public void DisplayMenu(VR4Menu menu)
        {
            var __pb = new ParamBuffer(200);
            __pb.Set<System.IntPtr>(0x0, menu);
            CallRaw("DisplayMenu", __pb.Bytes);
        }
        public void UpdateMenuEntry(VR4MenuEntryHandle Handle, int elementIndex)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, Handle);
            __pb.Set(0x8, elementIndex);
            CallRaw("UpdateMenuEntry", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ButtonHovered(VR4MenuEntryHandle Handle)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Handle);
            CallRaw("ButtonHovered", __pb.Bytes);
        }
        public void ButtonUnhovered(VR4MenuEntryHandle Handle)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Handle);
            CallRaw("ButtonUnhovered", __pb.Bytes);
        }
        public void MenuUpdated(VR4Menu menu)
        {
            var __pb = new ParamBuffer(200);
            __pb.Set<System.IntPtr>(0x0, menu);
            CallRaw("MenuUpdated", __pb.Bytes);
        }
        public void CheckSaveFail(bool success)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(success?1:0));
            CallRaw("CheckSaveFail", __pb.Bytes);
        }
        public void SavePlayerSettings(VR4GamePlayerSettings Settings)
        {
            var __pb = new ParamBuffer(184);
            __pb.Set<System.IntPtr>(0x0, Settings);
            CallRaw("SavePlayerSettings", __pb.Bytes);
        }
        public void SelectionMade(bool TryAgain)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(TryAgain?1:0));
            CallRaw("SelectionMade", __pb.Bytes);
        }
        public void ShowSaveFailureMessage()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowSaveFailureMessage", __pb.Bytes);
        }
        public void FailMessageComplete(Actor DestroyedActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, DestroyedActor);
            CallRaw("FailMessageComplete", __pb.Bytes);
        }
        public void ExecuteUbergraph_OptionsUIScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_OptionsUIScreen_BP", __pb.Bytes);
        }
    }

}
