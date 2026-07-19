// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/Slate
using System;

namespace UEModLoader.Game
{
    public enum EVirtualKeyboardDismissAction
    {
        TextChangeOnDismiss = 0,
        TextCommitOnAccept = 1,
        TextCommitOnDismiss = 2,
    }

    public enum EVirtualKeyboardTrigger
    {
        OnFocusByPointer = 0,
        OnAllFocusEvents = 1,
    }

    public enum ETableViewMode
    {
        List = 0,
        Tile = 1,
        Tree = 2,
    }

    public enum ESelectionMode
    {
        None = 0,
        Single = 1,
        SingleToggle = 2,
        Multi = 3,
    }

    public enum EMultiBlockType
    {
        None = 0,
        ButtonRow = 1,
        EditableText = 2,
        Heading = 3,
        MenuEntry = 4,
        MenuSeparator = 5,
        ToolBarButton = 6,
        ToolBarComboButton = 7,
        ToolBarSeparator = 8,
        Widget = 9,
    }

    public enum EMultiBoxType
    {
        MenuBar = 0,
        ToolBar = 1,
        VerticalToolBar = 2,
        UniformToolBar = 3,
        Menu = 4,
        ButtonRow = 5,
        ToolMenuBar = 6,
    }

    public enum EProgressBarFillType
    {
        LeftToRight = 0,
        RightToLeft = 1,
        FillFromCenter = 2,
        TopToBottom = 3,
        BottomToTop = 4,
    }

    public enum EStretch
    {
        None = 0,
        Fill = 1,
        ScaleToFit = 2,
        ScaleToFitX = 3,
        ScaleToFitY = 4,
        ScaleToFill = 5,
        ScaleBySafeZone = 6,
        UserSpecified = 7,
    }

    public enum EStretchDirection
    {
        Both = 0,
        DownOnly = 1,
        UpOnly = 2,
    }

    public enum EScrollWhenFocusChanges
    {
        NoScroll = 0,
        InstantScroll = 1,
        AnimatedScroll = 2,
    }

    public enum EDescendantScrollDestination
    {
        IntoView = 0,
        TopOrLeft = 1,
        Center = 2,
    }

    public enum EListItemAlignment
    {
        EvenlyDistributed = 0,
        EvenlySize = 1,
        EvenlyWide = 2,
        LeftAligned = 3,
        RightAligned = 4,
        CenterAligned = 5,
        Fill = 6,
    }

    public enum ETextFlowDirection
    {
        Auto = 0,
        LeftToRight = 1,
        RightToLeft = 2,
    }

    public enum ETextWrappingPolicy
    {
        DefaultWrapping = 0,
        AllowPerCharacterWrapping = 1,
    }

    public enum ETextJustify
    {
        Left = 0,
        Center = 1,
        Right = 2,
    }

    public enum ECustomizedToolMenuVisibility
    {
        None = 0,
        Visible = 1,
        Hidden = 2,
    }

    public enum EMultipleKeyBindingIndex
    {
        Primary = 0,
        Secondary = 1,
        NumChords = 2,
    }

    public enum EUserInterfaceActionType
    {
        None = 0,
        Button = 1,
        ToggleButton = 2,
        RadioButton = 3,
        Check = 4,
        CollapsedButton = 5,
    }

    public class VirtualKeyboardOptions : StructProxy
    {
        public VirtualKeyboardOptions(System.IntPtr ptr) : base(ptr) {}
        public bool bEnableAutocorrect { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class InputChord : StructProxy
    {
        public InputChord(System.IntPtr ptr) : base(ptr) {}
        public Key Key => new Key(AddrOf(0x0));
        public bool bShift { get => (GetAt<byte>(0x18) & 0x1) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bCtrl { get => (GetAt<byte>(0x18) & 0x2) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bAlt { get => (GetAt<byte>(0x18) & 0x4) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bCmd { get => (GetAt<byte>(0x18) & 0x8) != 0; set { var __b = GetAt<byte>(0x18); SetAt(0x18, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
    }

    public class Anchors : StructProxy
    {
        public Anchors(System.IntPtr ptr) : base(ptr) {}
        public Vector2D Minimum => new Vector2D(AddrOf(0x0));
        public Vector2D Maximum => new Vector2D(AddrOf(0x8));
    }

    public class CustomizedToolMenu : StructProxy
    {
        public CustomizedToolMenu(System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public System.IntPtr Entries => AddrOf(0x8); // 
        public System.IntPtr Sections => AddrOf(0x58); // 
        public System.IntPtr EntryOrder => AddrOf(0xA8); // 
        public TArray<System.IntPtr> SectionOrder => new TArray<System.IntPtr>(AddrOf(0xF8)); // TArray<FName>
    }

    public class CustomizedToolMenuNameArray : StructProxy
    {
        public CustomizedToolMenuNameArray(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Names => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<FName>
    }

    public class CustomizedToolMenuSection : StructProxy
    {
        public CustomizedToolMenuSection(System.IntPtr ptr) : base(ptr) {}
        public ECustomizedToolMenuVisibility Visibility { get => (ECustomizedToolMenuVisibility)GetAt<int>(0x0); set => SetAt(0x0, (int)value); }
    }

    public class CustomizedToolMenuEntry : StructProxy
    {
        public CustomizedToolMenuEntry(System.IntPtr ptr) : base(ptr) {}
        public ECustomizedToolMenuVisibility Visibility { get => (ECustomizedToolMenuVisibility)GetAt<int>(0x0); set => SetAt(0x0, (int)value); }
    }

    public class ButtonWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "ButtonWidgetStyle";
        public ButtonWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new ButtonWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ButtonWidgetStyle(p);
        public static ButtonWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ButtonWidgetStyle(o.Pointer); }
        public static ButtonWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ButtonWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ButtonWidgetStyle(a[i].Pointer); return r; }
        public ButtonStyle ButtonStyle => new ButtonStyle(AddrOf(0x30));
    }

    public class CheckBoxWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "CheckBoxWidgetStyle";
        public CheckBoxWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new CheckBoxWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CheckBoxWidgetStyle(p);
        public static CheckBoxWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CheckBoxWidgetStyle(o.Pointer); }
        public static CheckBoxWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CheckBoxWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CheckBoxWidgetStyle(a[i].Pointer); return r; }
        public CheckBoxStyle CheckBoxStyle => new CheckBoxStyle(AddrOf(0x30));
    }

    public class ComboBoxWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "ComboBoxWidgetStyle";
        public ComboBoxWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new ComboBoxWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ComboBoxWidgetStyle(p);
        public static ComboBoxWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ComboBoxWidgetStyle(o.Pointer); }
        public static ComboBoxWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ComboBoxWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ComboBoxWidgetStyle(a[i].Pointer); return r; }
        public ComboBoxStyle ComboBoxStyle => new ComboBoxStyle(AddrOf(0x30));
    }

    public class ComboButtonWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "ComboButtonWidgetStyle";
        public ComboButtonWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new ComboButtonWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ComboButtonWidgetStyle(p);
        public static ComboButtonWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ComboButtonWidgetStyle(o.Pointer); }
        public static ComboButtonWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ComboButtonWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ComboButtonWidgetStyle(a[i].Pointer); return r; }
        public ComboButtonStyle ComboButtonStyle => new ComboButtonStyle(AddrOf(0x30));
    }

    public class EditableTextBoxWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "EditableTextBoxWidgetStyle";
        public EditableTextBoxWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new EditableTextBoxWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableTextBoxWidgetStyle(p);
        public static EditableTextBoxWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableTextBoxWidgetStyle(o.Pointer); }
        public static EditableTextBoxWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableTextBoxWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableTextBoxWidgetStyle(a[i].Pointer); return r; }
        public EditableTextBoxStyle EditableTextBoxStyle => new EditableTextBoxStyle(AddrOf(0x30));
    }

    public class EditableTextWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "EditableTextWidgetStyle";
        public EditableTextWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new EditableTextWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableTextWidgetStyle(p);
        public static EditableTextWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableTextWidgetStyle(o.Pointer); }
        public static EditableTextWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableTextWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableTextWidgetStyle(a[i].Pointer); return r; }
        public EditableTextStyle EditableTextStyle => new EditableTextStyle(AddrOf(0x30));
    }

    public class ProgressWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "ProgressWidgetStyle";
        public ProgressWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new ProgressWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ProgressWidgetStyle(p);
        public static ProgressWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ProgressWidgetStyle(o.Pointer); }
        public static ProgressWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ProgressWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ProgressWidgetStyle(a[i].Pointer); return r; }
        public ProgressBarStyle ProgressBarStyle => new ProgressBarStyle(AddrOf(0x30));
    }

    public class ScrollBarWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "ScrollBarWidgetStyle";
        public ScrollBarWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new ScrollBarWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ScrollBarWidgetStyle(p);
        public static ScrollBarWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ScrollBarWidgetStyle(o.Pointer); }
        public static ScrollBarWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ScrollBarWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ScrollBarWidgetStyle(a[i].Pointer); return r; }
        public ScrollBarStyle ScrollBarStyle => new ScrollBarStyle(AddrOf(0x30));
    }

    public class ScrollBoxWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "ScrollBoxWidgetStyle";
        public ScrollBoxWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new ScrollBoxWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ScrollBoxWidgetStyle(p);
        public static ScrollBoxWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ScrollBoxWidgetStyle(o.Pointer); }
        public static ScrollBoxWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ScrollBoxWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ScrollBoxWidgetStyle(a[i].Pointer); return r; }
        public ScrollBoxStyle ScrollBoxStyle => new ScrollBoxStyle(AddrOf(0x30));
    }

    public class SlateSettings : Object
    {
        public const string UeClassName = "SlateSettings";
        public SlateSettings(System.IntPtr ptr) : base(ptr) {}
        public static new SlateSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SlateSettings(p);
        public static SlateSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SlateSettings(o.Pointer); }
        public static SlateSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SlateSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SlateSettings(a[i].Pointer); return r; }
        public bool bExplicitCanvasChildZOrder { get => Native.GetPropBool(Pointer, "bExplicitCanvasChildZOrder"); set => Native.SetPropBool(Pointer, "bExplicitCanvasChildZOrder", value); }
    }

    public class SpinBoxWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "SpinBoxWidgetStyle";
        public SpinBoxWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new SpinBoxWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SpinBoxWidgetStyle(p);
        public static SpinBoxWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SpinBoxWidgetStyle(o.Pointer); }
        public static SpinBoxWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SpinBoxWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SpinBoxWidgetStyle(a[i].Pointer); return r; }
        public SpinBoxStyle SpinBoxStyle => new SpinBoxStyle(AddrOf(0x30));
    }

    public class TextBlockWidgetStyle : SlateWidgetStyleContainerBase
    {
        public const string UeClassName = "TextBlockWidgetStyle";
        public TextBlockWidgetStyle(System.IntPtr ptr) : base(ptr) {}
        public static new TextBlockWidgetStyle FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TextBlockWidgetStyle(p);
        public static TextBlockWidgetStyle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TextBlockWidgetStyle(o.Pointer); }
        public static TextBlockWidgetStyle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TextBlockWidgetStyle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TextBlockWidgetStyle(a[i].Pointer); return r; }
        public TextBlockStyle TextBlockStyle => new TextBlockStyle(AddrOf(0x30));
    }

    public class ToolMenuBase : Object
    {
        public const string UeClassName = "ToolMenuBase";
        public ToolMenuBase(System.IntPtr ptr) : base(ptr) {}
        public static new ToolMenuBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ToolMenuBase(p);
        public static ToolMenuBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ToolMenuBase(o.Pointer); }
        public static ToolMenuBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ToolMenuBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ToolMenuBase(a[i].Pointer); return r; }
    }

}
