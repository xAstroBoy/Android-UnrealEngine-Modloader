// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMenu/DebugOptionWidget
using System;

namespace UEModLoader.Game
{
    public class DebugOptionWidget_C : UserWidget
    {
        public const string UeClassName = "DebugOptionWidget_C";
        public DebugOptionWidget_C(System.IntPtr ptr) : base(ptr) {}
        public static new DebugOptionWidget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DebugOptionWidget_C(p);
        public static DebugOptionWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugOptionWidget_C(o.Pointer); }
        public static DebugOptionWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugOptionWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugOptionWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public TextBlock ActionText { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox Button0 { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox Button1 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock CurrentSettingText { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox Favorite0 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox Favorite1 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Favorite { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Favorite0 { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock OptionNameText { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher Switcher { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcherButton0 { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcherButton1 { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public string OptionName => Native.GetPropString(Pointer, "OptionName"); // FString
        public TArray<System.IntPtr> SettingList => new TArray<System.IntPtr>(AddrOf(0x2A8)); // TArray<FString>
        public int CurrentIndex { get => GetAt<int>(0x2B8); set => SetAt(0x2B8, value); }
        public string DebugOptionName => Native.GetPropName(Pointer, "DebugOptionName"); // FName
        public FName DebugOptionName_Raw { get => GetAt<FName>(0x2BC); set => SetAt(0x2BC, value); }
        public void OptionReset(System.IntPtr NewSetting)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewSetting);
            CallRaw("OptionReset", __pb.Bytes);
        }
        public void OptionIncremented(System.IntPtr NewSetting)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewSetting);
            CallRaw("OptionIncremented", __pb.Bytes);
        }
        public void UpdateLook(bool Active, bool Favorite, byte Shortcut)
        {
            var __pb = new ParamBuffer(3);
            __pb.Set<byte>(0x0, (byte)(Active?1:0));
            __pb.Set<byte>(0x1, (byte)(Favorite?1:0));
            __pb.Set(0x2, Shortcut);
            CallRaw("UpdateLook", __pb.Bytes);
        }
        public void Setup()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Setup", __pb.Bytes);
        }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void OnInitialized()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnInitialized", __pb.Bytes);
        }
        public void ExecuteUbergraph_DebugOptionWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_DebugOptionWidget", __pb.Bytes);
        }
    }

}
