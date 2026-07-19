// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/SlateCore
using System;

namespace UEModLoader.Game
{
    public enum EWidgetClipping
    {
        Inherit = 0,
        ClipToBounds = 1,
        ClipToBoundsWithoutIntersecting = 2,
        ClipToBoundsAlways = 3,
        OnDemand = 4,
    }

    public enum EFontLayoutMethod
    {
        Metrics = 0,
        BoundingBox = 1,
    }

    public enum EFontLoadingPolicy
    {
        LazyLoad = 0,
        Stream = 1,
        Inline = 2,
    }

    public enum EFontHinting
    {
        Default = 0,
        Auto = 1,
        AutoLight = 2,
        Monochrome = 3,
        None = 4,
    }

    public enum EFocusCause
    {
        Mouse = 0,
        Navigation = 1,
        SetDirectly = 2,
        Cleared = 3,
        OtherWidgetLostFocus = 4,
        WindowActivate = 5,
    }

    public enum EFlowDirectionPreference
    {
        Inherit = 0,
        Culture = 1,
        LeftToRight = 2,
        RightToLeft = 3,
    }

    public enum ETextShapingMethod
    {
        Auto = 0,
        KerningOnly = 1,
        FullShaping = 2,
    }

    public enum EUINavigationRule
    {
        Escape = 0,
        Explicit = 1,
        Wrap = 2,
        Stop = 3,
        Custom = 4,
        CustomBoundary = 5,
        Invalid = 6,
    }

    public enum EColorVisionDeficiency
    {
        NormalVision = 0,
        Deuteranope = 1,
        Protanope = 2,
        Tritanope = 3,
    }

    public enum ESlateBrushImageType
    {
        NoImage = 0,
        FullColor = 1,
        Linear = 2,
    }

    public enum ESlateBrushMirrorType
    {
        NoMirror = 0,
        Horizontal = 1,
        Vertical = 2,
        Both = 3,
    }

    public enum ESlateBrushTileType
    {
        NoTile = 0,
        Horizontal = 1,
        Vertical = 2,
        Both = 3,
    }

    public enum ESlateBrushDrawType
    {
        NoDrawType = 0,
        Box = 1,
        Border = 2,
        Image = 3,
    }

    public enum ESlateColorStylingMode
    {
        UseColor_Specified = 0,
        UseColor_Specified_Link = 1,
        UseColor_Foreground = 2,
        UseColor_Foreground_Subdued = 3,
    }

    public enum ESlateDebuggingFocusEvent
    {
        FocusChanging = 0,
        FocusLost = 1,
        FocusReceived = 2,
    }

    public enum ESlateDebuggingNavigationMethod
    {
        Unknown = 0,
        Explicit = 1,
        CustomDelegateBound = 2,
        CustomDelegateUnbound = 3,
        NextOrPrevious = 4,
        HitTestGrid = 5,
    }

    public enum ESlateDebuggingStateChangeEvent
    {
        MouseCaptureGained = 0,
        MouseCaptureLost = 1,
    }

    public enum ESlateDebuggingInputEvent
    {
        MouseMove = 0,
        MouseEnter = 1,
        MouseLeave = 2,
        MouseButtonDown = 3,
        MouseButtonUp = 4,
        MouseButtonDoubleClick = 5,
        MouseWheel = 6,
        TouchStart = 7,
        TouchEnd = 8,
        DragDetected = 9,
        DragEnter = 10,
        DragLeave = 11,
        DragOver = 12,
        DragDrop = 13,
        DropMessage = 14,
        KeyDown = 15,
        KeyUp = 16,
        KeyChar = 17,
        AnalogInput = 18,
        TouchGesture = 19,
        COUNT = 20,
    }

    public enum ESelectInfo
    {
        OnKeyPress = 0,
        OnNavigation = 1,
        OnMouseClick = 2,
        Direct = 3,
    }

    public enum ETextCommit
    {
        Default = 0,
        OnEnter = 1,
        OnUserMovedFocus = 2,
        OnCleared = 3,
    }

    public enum EScrollDirection
    {
        Scroll_Down = 0,
        Scroll_Up = 1,
    }

    public enum EOrientation
    {
        Orient_Horizontal = 0,
        Orient_Vertical = 1,
    }

    public enum EMenuPlacement
    {
        MenuPlacement_BelowAnchor = 0,
        MenuPlacement_CenteredBelowAnchor = 1,
        MenuPlacement_BelowRightAnchor = 2,
        MenuPlacement_ComboBox = 3,
        MenuPlacement_ComboBoxRight = 4,
        MenuPlacement_MenuRight = 5,
        MenuPlacement_AboveAnchor = 6,
        MenuPlacement_CenteredAboveAnchor = 7,
        MenuPlacement_AboveRightAnchor = 8,
        MenuPlacement_MenuLeft = 9,
        MenuPlacement_Center = 10,
        MenuPlacement_RightLeftCenter = 11,
        MenuPlacement_MatchBottomLeft = 12,
    }

    public enum EVerticalAlignment
    {
        VAlign_Fill = 0,
        VAlign_Top = 1,
        VAlign_Center = 2,
        VAlign_Bottom = 3,
    }

    public enum EHorizontalAlignment
    {
        HAlign_Fill = 0,
        HAlign_Left = 1,
        HAlign_Center = 2,
        HAlign_Right = 3,
    }

    public enum ENavigationGenesis
    {
        Keyboard = 0,
        Controller = 1,
        User = 2,
    }

    public enum ENavigationSource
    {
        FocusedWidget = 0,
        WidgetUnderCursor = 1,
    }

    public enum EUINavigationAction
    {
        Accept = 0,
        Back = 1,
        Num = 2,
        Invalid = 3,
    }

    public enum EUINavigation
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3,
        Next = 4,
        Previous = 5,
        Num = 6,
        Invalid = 7,
    }

    public enum EButtonPressMethod
    {
        DownAndUp = 0,
        ButtonPress = 1,
        ButtonRelease = 2,
    }

    public enum EButtonTouchMethod
    {
        DownAndUp = 0,
        Down = 1,
        PreciseTap = 2,
    }

    public enum EButtonClickMethod
    {
        DownAndUp = 0,
        MouseDown = 1,
        MouseUp = 2,
        PreciseClick = 3,
    }

    public enum ECheckBoxState
    {
        Unchecked = 0,
        Checked = 1,
        Undetermined = 2,
    }

    public enum ESlateCheckBoxType
    {
        CheckBox = 0,
        ToggleButton = 1,
    }

    public enum ESlateParentWindowSearchMethod
    {
        ActiveWindow = 0,
        MainWindow = 1,
    }

    public enum EConsumeMouseWheel
    {
        WhenScrollingPossible = 0,
        Always = 1,
        Never = 2,
    }

    public class Geometry : StructProxy
    {
        public Geometry(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class SlateBrush : StructProxy
    {
        public SlateBrush(global::System.IntPtr ptr) : base(ptr) {}
        public Vector2D ImageSize => new Vector2D(AddrOf(0x8));
        public Margin Margin => new Margin(AddrOf(0x10));
        public SlateColor TintColor => new SlateColor(AddrOf(0x20));
        public Object ResourceObject { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string ResourceName => Native.FNameToString(GetAt<int>(0x50)); // FName
        public FName ResourceName_Raw { get => GetAt<FName>(0x50); set => SetAt(0x50, value); }
        public Box2D UVRegion => new Box2D(AddrOf(0x58));
        public byte DrawAs { get => GetAt<byte>(0x6C); set => SetAt(0x6C, value); }
        public byte Tiling { get => GetAt<byte>(0x6D); set => SetAt(0x6D, value); }
        public byte Mirroring { get => GetAt<byte>(0x6E); set => SetAt(0x6E, value); }
        public byte ImageType { get => GetAt<byte>(0x6F); set => SetAt(0x6F, value); }
        public bool bIsDynamicallyLoaded { get => (GetAt<byte>(0x80) & 0x1) != 0; set { var __b = GetAt<byte>(0x80); SetAt(0x80, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bHasUObject { get => (GetAt<byte>(0x80) & 0x2) != 0; set { var __b = GetAt<byte>(0x80); SetAt(0x80, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
    }

    public class SlateColor : StructProxy
    {
        public SlateColor(global::System.IntPtr ptr) : base(ptr) {}
        public LinearColor SpecifiedColor => new LinearColor(AddrOf(0x0));
        public byte ColorUseRule { get => GetAt<byte>(0x10); set => SetAt(0x10, value); }
    }

    public class Margin : StructProxy
    {
        public Margin(global::System.IntPtr ptr) : base(ptr) {}
        public float Left { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Top { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Right { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float Bottom { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

    public class InputEvent : StructProxy
    {
        public InputEvent(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class PointerEvent : StructProxy
    {
        public PointerEvent(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class CharacterEvent : StructProxy
    {
        public CharacterEvent(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class KeyEvent : StructProxy
    {
        public KeyEvent(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class NavigationEvent : StructProxy
    {
        public NavigationEvent(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class AnalogInputEvent : StructProxy
    {
        public AnalogInputEvent(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class SlateFontInfo : StructProxy
    {
        public SlateFontInfo(global::System.IntPtr ptr) : base(ptr) {}
        public Object FontObject { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Object FontMaterial { get { var __p = GetAt<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public FontOutlineSettings OutlineSettings => new FontOutlineSettings(AddrOf(0x10));
        public string TypefaceFontName => Native.FNameToString(GetAt<int>(0x40)); // FName
        public FName TypefaceFontName_Raw { get => GetAt<FName>(0x40); set => SetAt(0x40, value); }
        public int Size { get => GetAt<int>(0x48); set => SetAt(0x48, value); }
    }

    public class FontOutlineSettings : StructProxy
    {
        public FontOutlineSettings(global::System.IntPtr ptr) : base(ptr) {}
        public int OutlineSize { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public bool bSeparateFillAlpha { get => (GetAt<byte>(0x4) & 0xFF) != 0; set { var __b = GetAt<byte>(0x4); SetAt(0x4, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bApplyOutlineToDropShadows { get => (GetAt<byte>(0x5) & 0xFF) != 0; set { var __b = GetAt<byte>(0x5); SetAt(0x5, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public Object OutlineMaterial { get { var __p = GetAt<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LinearColor OutlineColor => new LinearColor(AddrOf(0x10));
    }

    public class SlateWidgetStyle : StructProxy
    {
        public SlateWidgetStyle(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class TableRowStyle : StructProxy
    {
        public TableRowStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush SelectorFocusedBrush => new SlateBrush(AddrOf(0x8));
        public SlateBrush ActiveHoveredBrush => new SlateBrush(AddrOf(0x90));
        public SlateBrush ActiveBrush => new SlateBrush(AddrOf(0x118));
        public SlateBrush InactiveHoveredBrush => new SlateBrush(AddrOf(0x1A0));
        public SlateBrush InactiveBrush => new SlateBrush(AddrOf(0x228));
        public SlateBrush EvenRowBackgroundHoveredBrush => new SlateBrush(AddrOf(0x2B0));
        public SlateBrush EvenRowBackgroundBrush => new SlateBrush(AddrOf(0x338));
        public SlateBrush OddRowBackgroundHoveredBrush => new SlateBrush(AddrOf(0x3C0));
        public SlateBrush OddRowBackgroundBrush => new SlateBrush(AddrOf(0x448));
        public SlateColor TextColor => new SlateColor(AddrOf(0x4D0));
        public SlateColor SelectedTextColor => new SlateColor(AddrOf(0x4F8));
        public SlateBrush DropIndicator_Above => new SlateBrush(AddrOf(0x520));
        public SlateBrush DropIndicator_Onto => new SlateBrush(AddrOf(0x5A8));
        public SlateBrush DropIndicator_Below => new SlateBrush(AddrOf(0x630));
        public SlateBrush ActiveHighlightedBrush => new SlateBrush(AddrOf(0x6B8));
        public SlateBrush InactiveHighlightedBrush => new SlateBrush(AddrOf(0x740));
    }

    public class ComboBoxStyle : StructProxy
    {
        public ComboBoxStyle(global::System.IntPtr ptr) : base(ptr) {}
        public ComboButtonStyle ComboButtonStyle => new ComboButtonStyle(AddrOf(0x8));
        public SlateSound PressedSlateSound => new SlateSound(AddrOf(0x3C0));
        public SlateSound SelectionChangeSlateSound => new SlateSound(AddrOf(0x3D8));
    }

    public class SlateSound : StructProxy
    {
        public SlateSound(global::System.IntPtr ptr) : base(ptr) {}
        public Object ResourceObject { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class ComboButtonStyle : StructProxy
    {
        public ComboButtonStyle(global::System.IntPtr ptr) : base(ptr) {}
        public ButtonStyle ButtonStyle => new ButtonStyle(AddrOf(0x8));
        public SlateBrush DownArrowImage => new SlateBrush(AddrOf(0x280));
        public Vector2D ShadowOffset => new Vector2D(AddrOf(0x308));
        public LinearColor ShadowColorAndOpacity => new LinearColor(AddrOf(0x310));
        public SlateBrush MenuBorderBrush => new SlateBrush(AddrOf(0x320));
        public Margin MenuBorderPadding => new Margin(AddrOf(0x3A8));
    }

    public class ButtonStyle : StructProxy
    {
        public ButtonStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush Normal => new SlateBrush(AddrOf(0x8));
        public SlateBrush Hovered => new SlateBrush(AddrOf(0x90));
        public SlateBrush Pressed => new SlateBrush(AddrOf(0x118));
        public SlateBrush Disabled => new SlateBrush(AddrOf(0x1A0));
        public Margin NormalPadding => new Margin(AddrOf(0x228));
        public Margin PressedPadding => new Margin(AddrOf(0x238));
        public SlateSound PressedSlateSound => new SlateSound(AddrOf(0x248));
        public SlateSound HoveredSlateSound => new SlateSound(AddrOf(0x260));
    }

    public class EditableTextStyle : StructProxy
    {
        public EditableTextStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0x8));
        public SlateColor ColorAndOpacity => new SlateColor(AddrOf(0x58));
        public SlateBrush BackgroundImageSelected => new SlateBrush(AddrOf(0x80));
        public SlateBrush BackgroundImageComposing => new SlateBrush(AddrOf(0x108));
        public SlateBrush CaretImage => new SlateBrush(AddrOf(0x190));
    }

    public class EditableTextBoxStyle : StructProxy
    {
        public EditableTextBoxStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush BackgroundImageNormal => new SlateBrush(AddrOf(0x8));
        public SlateBrush BackgroundImageHovered => new SlateBrush(AddrOf(0x90));
        public SlateBrush BackgroundImageFocused => new SlateBrush(AddrOf(0x118));
        public SlateBrush BackgroundImageReadOnly => new SlateBrush(AddrOf(0x1A0));
        public Margin Padding => new Margin(AddrOf(0x228));
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0x238));
        public SlateColor ForegroundColor => new SlateColor(AddrOf(0x288));
        public SlateColor BackgroundColor => new SlateColor(AddrOf(0x2B0));
        public SlateColor ReadOnlyForegroundColor => new SlateColor(AddrOf(0x2D8));
        public Margin HScrollBarPadding => new Margin(AddrOf(0x300));
        public Margin VScrollBarPadding => new Margin(AddrOf(0x310));
        public ScrollBarStyle ScrollBarStyle => new ScrollBarStyle(AddrOf(0x320));
    }

    public class ScrollBarStyle : StructProxy
    {
        public ScrollBarStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush HorizontalBackgroundImage => new SlateBrush(AddrOf(0x8));
        public SlateBrush VerticalBackgroundImage => new SlateBrush(AddrOf(0x90));
        public SlateBrush VerticalTopSlotImage => new SlateBrush(AddrOf(0x118));
        public SlateBrush HorizontalTopSlotImage => new SlateBrush(AddrOf(0x1A0));
        public SlateBrush VerticalBottomSlotImage => new SlateBrush(AddrOf(0x228));
        public SlateBrush HorizontalBottomSlotImage => new SlateBrush(AddrOf(0x2B0));
        public SlateBrush NormalThumbImage => new SlateBrush(AddrOf(0x338));
        public SlateBrush HoveredThumbImage => new SlateBrush(AddrOf(0x3C0));
        public SlateBrush DraggedThumbImage => new SlateBrush(AddrOf(0x448));
    }

    public class TextBlockStyle : StructProxy
    {
        public TextBlockStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0x8));
        public SlateColor ColorAndOpacity => new SlateColor(AddrOf(0x58));
        public Vector2D ShadowOffset => new Vector2D(AddrOf(0x80));
        public LinearColor ShadowColorAndOpacity => new LinearColor(AddrOf(0x88));
        public SlateColor SelectedBackgroundColor => new SlateColor(AddrOf(0x98));
        public LinearColor HighlightColor => new LinearColor(AddrOf(0xC0));
        public SlateBrush HighlightShape => new SlateBrush(AddrOf(0xD0));
        public SlateBrush StrikeBrush => new SlateBrush(AddrOf(0x158));
        public SlateBrush UnderlineBrush => new SlateBrush(AddrOf(0x1E0));
    }

    public class SpinBoxStyle : StructProxy
    {
        public SpinBoxStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush BackgroundBrush => new SlateBrush(AddrOf(0x8));
        public SlateBrush HoveredBackgroundBrush => new SlateBrush(AddrOf(0x90));
        public SlateBrush ActiveFillBrush => new SlateBrush(AddrOf(0x118));
        public SlateBrush InactiveFillBrush => new SlateBrush(AddrOf(0x1A0));
        public SlateBrush ArrowsImage => new SlateBrush(AddrOf(0x228));
        public SlateColor ForegroundColor => new SlateColor(AddrOf(0x2B0));
        public Margin TextPadding => new Margin(AddrOf(0x2D8));
    }

    public class CompositeFont : StructProxy
    {
        public CompositeFont(global::System.IntPtr ptr) : base(ptr) {}
        public Typeface DefaultTypeface => new Typeface(AddrOf(0x0));
        public CompositeFallbackFont FallbackTypeface => new CompositeFallbackFont(AddrOf(0x10));
        public TArray<global::System.IntPtr> SubTypefaces => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
    }

    public class CompositeFallbackFont : StructProxy
    {
        public CompositeFallbackFont(global::System.IntPtr ptr) : base(ptr) {}
        public Typeface Typeface => new Typeface(AddrOf(0x0));
        public float ScalingFactor { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
    }

    public class Typeface : StructProxy
    {
        public Typeface(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Fonts => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class TypefaceEntry : StructProxy
    {
        public TypefaceEntry(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public FontData Font => new FontData(AddrOf(0x8));
    }

    public class FontData : StructProxy
    {
        public FontData(global::System.IntPtr ptr) : base(ptr) {}
        public string FontFilename => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public EFontHinting Hinting { get => (EFontHinting)GetAt<byte>(0x10); set => SetAt(0x10, (byte)value); }
        public EFontLoadingPolicy LoadingPolicy { get => (EFontLoadingPolicy)GetAt<byte>(0x11); set => SetAt(0x11, (byte)value); }
        public int SubFaceIndex { get => GetAt<int>(0x14); set => SetAt(0x14, value); }
        public Object FontFaceAsset { get { var __p = GetAt<global::System.IntPtr>(0x18); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x18, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class CompositeSubFont : StructProxy
    {
        public CompositeSubFont(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> CharacterRanges => new TArray<global::System.IntPtr>(AddrOf(0x18)); // TArray<struct>
        public string Cultures => Native.ReadFStringAt(AddrOf(0x28)); // FString
    }

    public class MotionEvent : StructProxy
    {
        public MotionEvent(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class CaptureLostEvent : StructProxy
    {
        public CaptureLostEvent(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class FocusEvent : StructProxy
    {
        public FocusEvent(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class WindowStyle : StructProxy
    {
        public WindowStyle(global::System.IntPtr ptr) : base(ptr) {}
        public ButtonStyle MinimizeButtonStyle => new ButtonStyle(AddrOf(0x8));
        public ButtonStyle MaximizeButtonStyle => new ButtonStyle(AddrOf(0x280));
        public ButtonStyle RestoreButtonStyle => new ButtonStyle(AddrOf(0x4F8));
        public ButtonStyle CloseButtonStyle => new ButtonStyle(AddrOf(0x770));
        public TextBlockStyle TitleTextStyle => new TextBlockStyle(AddrOf(0x9E8));
        public SlateBrush ActiveTitleBrush => new SlateBrush(AddrOf(0xC50));
        public SlateBrush InactiveTitleBrush => new SlateBrush(AddrOf(0xCD8));
        public SlateBrush FlashTitleBrush => new SlateBrush(AddrOf(0xD60));
        public SlateColor BackgroundColor => new SlateColor(AddrOf(0xDE8));
        public SlateBrush OutlineBrush => new SlateBrush(AddrOf(0xE10));
        public SlateColor OutlineColor => new SlateColor(AddrOf(0xE98));
        public SlateBrush BorderBrush => new SlateBrush(AddrOf(0xEC0));
        public SlateBrush BackgroundBrush => new SlateBrush(AddrOf(0xF48));
        public SlateBrush ChildBackgroundBrush => new SlateBrush(AddrOf(0xFD0));
    }

    public class ScrollBorderStyle : StructProxy
    {
        public ScrollBorderStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush TopShadowBrush => new SlateBrush(AddrOf(0x8));
        public SlateBrush BottomShadowBrush => new SlateBrush(AddrOf(0x90));
    }

    public class ScrollBoxStyle : StructProxy
    {
        public ScrollBoxStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush TopShadowBrush => new SlateBrush(AddrOf(0x8));
        public SlateBrush BottomShadowBrush => new SlateBrush(AddrOf(0x90));
        public SlateBrush LeftShadowBrush => new SlateBrush(AddrOf(0x118));
        public SlateBrush RightShadowBrush => new SlateBrush(AddrOf(0x1A0));
    }

    public class DockTabStyle : StructProxy
    {
        public DockTabStyle(global::System.IntPtr ptr) : base(ptr) {}
        public ButtonStyle CloseButtonStyle => new ButtonStyle(AddrOf(0x8));
        public SlateBrush NormalBrush => new SlateBrush(AddrOf(0x280));
        public SlateBrush ActiveBrush => new SlateBrush(AddrOf(0x308));
        public SlateBrush ColorOverlayTabBrush => new SlateBrush(AddrOf(0x390));
        public SlateBrush ColorOverlayIconBrush => new SlateBrush(AddrOf(0x418));
        public SlateBrush ForegroundBrush => new SlateBrush(AddrOf(0x4A0));
        public SlateBrush HoveredBrush => new SlateBrush(AddrOf(0x528));
        public SlateBrush ContentAreaBrush => new SlateBrush(AddrOf(0x5B0));
        public SlateBrush TabWellBrush => new SlateBrush(AddrOf(0x638));
        public Margin TabPadding => new Margin(AddrOf(0x6C0));
        public float OverlapWidth { get => GetAt<float>(0x6D0); set => SetAt(0x6D0, value); }
        public SlateColor FlashColor => new SlateColor(AddrOf(0x6D8));
    }

    public class HeaderRowStyle : StructProxy
    {
        public HeaderRowStyle(global::System.IntPtr ptr) : base(ptr) {}
        public TableColumnHeaderStyle ColumnStyle => new TableColumnHeaderStyle(AddrOf(0x8));
        public TableColumnHeaderStyle LastColumnStyle => new TableColumnHeaderStyle(AddrOf(0x4D8));
        public SplitterStyle ColumnSplitterStyle => new SplitterStyle(AddrOf(0x9A8));
        public SlateBrush BackgroundBrush => new SlateBrush(AddrOf(0xAC0));
        public SlateColor ForegroundColor => new SlateColor(AddrOf(0xB48));
    }

    public class SplitterStyle : StructProxy
    {
        public SplitterStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush HandleNormalBrush => new SlateBrush(AddrOf(0x8));
        public SlateBrush HandleHighlightBrush => new SlateBrush(AddrOf(0x90));
    }

    public class TableColumnHeaderStyle : StructProxy
    {
        public TableColumnHeaderStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush SortPrimaryAscendingImage => new SlateBrush(AddrOf(0x8));
        public SlateBrush SortPrimaryDescendingImage => new SlateBrush(AddrOf(0x90));
        public SlateBrush SortSecondaryAscendingImage => new SlateBrush(AddrOf(0x118));
        public SlateBrush SortSecondaryDescendingImage => new SlateBrush(AddrOf(0x1A0));
        public SlateBrush NormalBrush => new SlateBrush(AddrOf(0x228));
        public SlateBrush HoveredBrush => new SlateBrush(AddrOf(0x2B0));
        public SlateBrush MenuDropdownImage => new SlateBrush(AddrOf(0x338));
        public SlateBrush MenuDropdownNormalBorderBrush => new SlateBrush(AddrOf(0x3C0));
        public SlateBrush MenuDropdownHoveredBorderBrush => new SlateBrush(AddrOf(0x448));
    }

    public class InlineTextImageStyle : StructProxy
    {
        public InlineTextImageStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush Image => new SlateBrush(AddrOf(0x8));
        public short Baseline { get => GetAt<short>(0x90); set => SetAt(0x90, value); }
    }

    public class VolumeControlStyle : StructProxy
    {
        public VolumeControlStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SliderStyle SliderStyle => new SliderStyle(AddrOf(0x8));
        public SlateBrush HighVolumeImage => new SlateBrush(AddrOf(0x348));
        public SlateBrush MidVolumeImage => new SlateBrush(AddrOf(0x3D0));
        public SlateBrush LowVolumeImage => new SlateBrush(AddrOf(0x458));
        public SlateBrush NoVolumeImage => new SlateBrush(AddrOf(0x4E0));
        public SlateBrush MutedImage => new SlateBrush(AddrOf(0x568));
    }

    public class SliderStyle : StructProxy
    {
        public SliderStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush NormalBarImage => new SlateBrush(AddrOf(0x8));
        public SlateBrush HoveredBarImage => new SlateBrush(AddrOf(0x90));
        public SlateBrush DisabledBarImage => new SlateBrush(AddrOf(0x118));
        public SlateBrush NormalThumbImage => new SlateBrush(AddrOf(0x1A0));
        public SlateBrush HoveredThumbImage => new SlateBrush(AddrOf(0x228));
        public SlateBrush DisabledThumbImage => new SlateBrush(AddrOf(0x2B0));
        public float BarThickness { get => GetAt<float>(0x338); set => SetAt(0x338, value); }
    }

    public class SearchBoxStyle : StructProxy
    {
        public SearchBoxStyle(global::System.IntPtr ptr) : base(ptr) {}
        public EditableTextBoxStyle TextBoxStyle => new EditableTextBoxStyle(AddrOf(0x8));
        public SlateFontInfo ActiveFontInfo => new SlateFontInfo(AddrOf(0x7F8));
        public SlateBrush UpArrowImage => new SlateBrush(AddrOf(0x848));
        public SlateBrush DownArrowImage => new SlateBrush(AddrOf(0x8D0));
        public SlateBrush GlassImage => new SlateBrush(AddrOf(0x958));
        public SlateBrush ClearImage => new SlateBrush(AddrOf(0x9E0));
        public Margin ImagePadding => new Margin(AddrOf(0xA68));
        public bool bLeftAlignButtons { get => (GetAt<byte>(0xA78) & 0xFF) != 0; set { var __b = GetAt<byte>(0xA78); SetAt(0xA78, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class ExpandableAreaStyle : StructProxy
    {
        public ExpandableAreaStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush CollapsedImage => new SlateBrush(AddrOf(0x8));
        public SlateBrush ExpandedImage => new SlateBrush(AddrOf(0x90));
        public float RolloutAnimationSeconds { get => GetAt<float>(0x118); set => SetAt(0x118, value); }
    }

    public class ProgressBarStyle : StructProxy
    {
        public ProgressBarStyle(global::System.IntPtr ptr) : base(ptr) {}
        public SlateBrush BackgroundImage => new SlateBrush(AddrOf(0x8));
        public SlateBrush FillImage => new SlateBrush(AddrOf(0x90));
        public SlateBrush MarqueeImage => new SlateBrush(AddrOf(0x118));
    }

    public class InlineEditableTextBlockStyle : StructProxy
    {
        public InlineEditableTextBlockStyle(global::System.IntPtr ptr) : base(ptr) {}
        public EditableTextBoxStyle EditableTextBoxStyle => new EditableTextBoxStyle(AddrOf(0x8));
        public TextBlockStyle TextStyle => new TextBlockStyle(AddrOf(0x7F8));
    }

    public class HyperlinkStyle : StructProxy
    {
        public HyperlinkStyle(global::System.IntPtr ptr) : base(ptr) {}
        public ButtonStyle UnderlineStyle => new ButtonStyle(AddrOf(0x8));
        public TextBlockStyle TextStyle => new TextBlockStyle(AddrOf(0x280));
        public Margin Padding => new Margin(AddrOf(0x4E8));
    }

    public class CheckBoxStyle : StructProxy
    {
        public CheckBoxStyle(global::System.IntPtr ptr) : base(ptr) {}
        public byte CheckBoxType { get => GetAt<byte>(0x8); set => SetAt(0x8, value); }
        public SlateBrush UncheckedImage => new SlateBrush(AddrOf(0x10));
        public SlateBrush UncheckedHoveredImage => new SlateBrush(AddrOf(0x98));
        public SlateBrush UncheckedPressedImage => new SlateBrush(AddrOf(0x120));
        public SlateBrush CheckedImage => new SlateBrush(AddrOf(0x1A8));
        public SlateBrush CheckedHoveredImage => new SlateBrush(AddrOf(0x230));
        public SlateBrush CheckedPressedImage => new SlateBrush(AddrOf(0x2B8));
        public SlateBrush UndeterminedImage => new SlateBrush(AddrOf(0x340));
        public SlateBrush UndeterminedHoveredImage => new SlateBrush(AddrOf(0x3C8));
        public SlateBrush UndeterminedPressedImage => new SlateBrush(AddrOf(0x450));
        public Margin Padding => new Margin(AddrOf(0x4D8));
        public SlateColor ForegroundColor => new SlateColor(AddrOf(0x4E8));
        public SlateColor BorderBackgroundColor => new SlateColor(AddrOf(0x510));
        public SlateSound CheckedSlateSound => new SlateSound(AddrOf(0x538));
        public SlateSound UncheckedSlateSound => new SlateSound(AddrOf(0x550));
        public SlateSound HoveredSlateSound => new SlateSound(AddrOf(0x568));
    }

    public class FontBulkData : Object
    {
        public const string UeClassName = "FontBulkData";
        public FontBulkData(global::System.IntPtr ptr) : base(ptr) {}
        public static new FontBulkData FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FontBulkData(p);
        public static FontBulkData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FontBulkData(o.Pointer); }
        public static FontBulkData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FontBulkData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FontBulkData(a[i].Pointer); return r; }
    }

    public class FontFaceInterface : Interface
    {
        public const string UeClassName = "FontFaceInterface";
        public FontFaceInterface(global::System.IntPtr ptr) : base(ptr) {}
        public static new FontFaceInterface FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FontFaceInterface(p);
        public static FontFaceInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FontFaceInterface(o.Pointer); }
        public static FontFaceInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FontFaceInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FontFaceInterface(a[i].Pointer); return r; }
    }

    public class FontProviderInterface : Interface
    {
        public const string UeClassName = "FontProviderInterface";
        public FontProviderInterface(global::System.IntPtr ptr) : base(ptr) {}
        public static new FontProviderInterface FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FontProviderInterface(p);
        public static FontProviderInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FontProviderInterface(o.Pointer); }
        public static FontProviderInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FontProviderInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FontProviderInterface(a[i].Pointer); return r; }
    }

    public class SlateTypes : Object
    {
        public const string UeClassName = "SlateTypes";
        public SlateTypes(global::System.IntPtr ptr) : base(ptr) {}
        public static new SlateTypes FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SlateTypes(p);
        public static SlateTypes FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SlateTypes(o.Pointer); }
        public static SlateTypes[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SlateTypes[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SlateTypes(a[i].Pointer); return r; }
    }

    public class SlateWidgetStyleAsset : Object
    {
        public const string UeClassName = "SlateWidgetStyleAsset";
        public SlateWidgetStyleAsset(global::System.IntPtr ptr) : base(ptr) {}
        public static new SlateWidgetStyleAsset FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SlateWidgetStyleAsset(p);
        public static SlateWidgetStyleAsset FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SlateWidgetStyleAsset(o.Pointer); }
        public static SlateWidgetStyleAsset[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SlateWidgetStyleAsset[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SlateWidgetStyleAsset(a[i].Pointer); return r; }
        public SlateWidgetStyleContainerBase CustomStyle { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new SlateWidgetStyleContainerBase(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class SlateWidgetStyleContainerBase : Object
    {
        public const string UeClassName = "SlateWidgetStyleContainerBase";
        public SlateWidgetStyleContainerBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new SlateWidgetStyleContainerBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SlateWidgetStyleContainerBase(p);
        public static SlateWidgetStyleContainerBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SlateWidgetStyleContainerBase(o.Pointer); }
        public static SlateWidgetStyleContainerBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SlateWidgetStyleContainerBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SlateWidgetStyleContainerBase(a[i].Pointer); return r; }
    }

    public class SlateWidgetStyleContainerInterface : Interface
    {
        public const string UeClassName = "SlateWidgetStyleContainerInterface";
        public SlateWidgetStyleContainerInterface(global::System.IntPtr ptr) : base(ptr) {}
        public static new SlateWidgetStyleContainerInterface FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SlateWidgetStyleContainerInterface(p);
        public static SlateWidgetStyleContainerInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SlateWidgetStyleContainerInterface(o.Pointer); }
        public static SlateWidgetStyleContainerInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SlateWidgetStyleContainerInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SlateWidgetStyleContainerInterface(a[i].Pointer); return r; }
    }

}
