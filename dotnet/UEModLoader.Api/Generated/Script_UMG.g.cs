// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/UMG
using System;

namespace UEModLoader.Game
{
    public enum ESlateAccessibleBehavior
    {
        NotAccessible = 0,
        Auto = 1,
        Summary = 2,
        Custom = 3,
        ToolTip = 4,
    }

    public enum ESlateVisibility
    {
        Visible = 0,
        Collapsed = 1,
        Hidden = 2,
        HitTestInvisible = 3,
        SelfHitTestInvisible = 4,
    }

    public enum EVirtualKeyboardType
    {
        Default = 0,
        Number = 1,
        Web = 2,
        Email = 3,
        Password = 4,
        AlphaNumeric = 5,
    }

    public enum EDragPivot
    {
        MouseDown = 0,
        TopLeft = 1,
        TopCenter = 2,
        TopRight = 3,
        CenterLeft = 4,
        CenterCenter = 5,
        CenterRight = 6,
        BottomLeft = 7,
        BottomCenter = 8,
        BottomRight = 9,
    }

    public enum EDynamicBoxType
    {
        Horizontal = 0,
        Vertical = 1,
        Wrap = 2,
        Overlay = 3,
    }

    public enum ESlateSizeRule
    {
        Automatic = 0,
        Fill = 1,
    }

    public enum EUMGSequencePlayMode
    {
        Forward = 0,
        Reverse = 1,
        PingPong = 2,
    }

    public enum EWidgetAnimationEvent
    {
        Started = 0,
        Finished = 1,
    }

    public enum EWidgetTickFrequency
    {
        Never = 0,
        Auto = 1,
    }

    public enum EWidgetDesignFlags
    {
        None = 0,
        Designing = 1,
        ShowOutline = 2,
        ExecutePreConstruct = 4,
    }

    public enum EBindingKind
    {
        Function = 0,
        Property = 1,
    }

    public enum EWindowVisibility
    {
        Visible = 0,
        SelfHitTestInvisible = 1,
    }

    public enum EWidgetGeometryMode
    {
        Plane = 0,
        Cylinder = 1,
    }

    public enum EWidgetBlendMode
    {
        Opaque = 0,
        Masked = 1,
        Transparent = 2,
    }

    public enum EWidgetTimingPolicy
    {
        RealTime = 0,
        GameTime = 1,
    }

    public enum EWidgetSpace
    {
        World = 0,
        Screen = 1,
    }

    public enum EWidgetInteractionSource
    {
        World = 0,
        Mouse = 1,
        CenterScreen = 2,
        Custom = 3,
    }

    public class EventReply : StructProxy
    {
        public EventReply(System.IntPtr ptr) : base(ptr) {}
    }

    public class WidgetTransform : StructProxy
    {
        public WidgetTransform(System.IntPtr ptr) : base(ptr) {}
        public Vector2D Translation => new Vector2D(AddrOf(0x0));
        public Vector2D Scale => new Vector2D(AddrOf(0x8));
        public Vector2D Shear => new Vector2D(AddrOf(0x10));
        public float Angle { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
    }

    public class PaintContext : StructProxy
    {
        public PaintContext(System.IntPtr ptr) : base(ptr) {}
    }

    public class ShapedTextOptions : StructProxy
    {
        public ShapedTextOptions(System.IntPtr ptr) : base(ptr) {}
        public bool bOverride_TextShapingMethod { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bOverride_TextFlowDirection { get => (GetAt<byte>(0x0) & 0x2) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public ETextShapingMethod TextShapingMethod { get => (ETextShapingMethod)GetAt<byte>(0x1); set => SetAt(0x1, (byte)value); }
        public ETextFlowDirection TextFlowDirection { get => (ETextFlowDirection)GetAt<byte>(0x2); set => SetAt(0x2, (byte)value); }
    }

    public class AnchorData : StructProxy
    {
        public AnchorData(System.IntPtr ptr) : base(ptr) {}
        public Margin Offsets => new Margin(AddrOf(0x0));
        public Anchors Anchors => new Anchors(AddrOf(0x10));
        public Vector2D Alignment => new Vector2D(AddrOf(0x20));
    }

    public class DynamicPropertyPath : StructProxy
    {
        public DynamicPropertyPath(System.IntPtr ptr) : base(ptr) {}
    }

    public class MovieScene2DTransformMask : StructProxy
    {
        public MovieScene2DTransformMask(System.IntPtr ptr) : base(ptr) {}
        public uint Mask { get => GetAt<uint>(0x0); set => SetAt(0x0, value); }
    }

    public class MovieScene2DTransformSectionTemplate : StructProxy
    {
        public MovieScene2DTransformSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public System.IntPtr Translation => AddrOf(0x40); // [2] static array
        public MovieSceneFloatChannel Rotation => new MovieSceneFloatChannel(AddrOf(0x180));
        public System.IntPtr Scale => AddrOf(0x220); // [2] static array
        public System.IntPtr Shear => AddrOf(0x360); // [2] static array
        public EMovieSceneBlendType BlendType { get => (EMovieSceneBlendType)GetAt<byte>(0x4A0); set => SetAt(0x4A0, (byte)value); }
        public MovieScene2DTransformMask Mask => new MovieScene2DTransformMask(AddrOf(0x4A4));
    }

    public class MovieSceneMarginSectionTemplate : StructProxy
    {
        public MovieSceneMarginSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public MovieSceneFloatChannel TopCurve => new MovieSceneFloatChannel(AddrOf(0x40));
        public MovieSceneFloatChannel LeftCurve => new MovieSceneFloatChannel(AddrOf(0xE0));
        public MovieSceneFloatChannel RightCurve => new MovieSceneFloatChannel(AddrOf(0x180));
        public MovieSceneFloatChannel BottomCurve => new MovieSceneFloatChannel(AddrOf(0x220));
        public EMovieSceneBlendType BlendType { get => (EMovieSceneBlendType)GetAt<byte>(0x2C0); set => SetAt(0x2C0, (byte)value); }
    }

    public class MovieSceneWidgetMaterialSectionTemplate : StructProxy
    {
        public MovieSceneWidgetMaterialSectionTemplate(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> BrushPropertyNamePath => new TArray<System.IntPtr>(AddrOf(0x78)); // TArray<FName>
    }

    public class RichTextStyleRow : StructProxy
    {
        public RichTextStyleRow(System.IntPtr ptr) : base(ptr) {}
        public TextBlockStyle TextStyle => new TextBlockStyle(AddrOf(0x8));
    }

    public class RichImageRow : StructProxy
    {
        public RichImageRow(System.IntPtr ptr) : base(ptr) {}
        public SlateBrush Brush => new SlateBrush(AddrOf(0x8));
    }

    public class SlateMeshVertex : StructProxy
    {
        public SlateMeshVertex(System.IntPtr ptr) : base(ptr) {}
        public Vector2D Position => new Vector2D(AddrOf(0x0));
        public Color Color => new Color(AddrOf(0x8));
        public Vector2D UV0 => new Vector2D(AddrOf(0xC));
        public Vector2D UV1 => new Vector2D(AddrOf(0x14));
        public Vector2D UV2 => new Vector2D(AddrOf(0x1C));
        public Vector2D UV3 => new Vector2D(AddrOf(0x24));
        public Vector2D UV4 => new Vector2D(AddrOf(0x2C));
        public Vector2D UV5 => new Vector2D(AddrOf(0x34));
    }

    public class SlateChildSize : StructProxy
    {
        public SlateChildSize(System.IntPtr ptr) : base(ptr) {}
        public float Value { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public byte SizeRule { get => GetAt<byte>(0x4); set => SetAt(0x4, value); }
    }

    public class NamedSlotBinding : StructProxy
    {
        public NamedSlotBinding(System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public Widget Content { get { var __p = GetAt<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new Widget(__p); } set => SetAt(0x8, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class AnimationEventBinding : StructProxy
    {
        public AnimationEventBinding(System.IntPtr ptr) : base(ptr) {}
        public WidgetAnimation Animation { get { var __p = GetAt<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x0, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr Delegate => AddrOf(0x8); // 
        public EWidgetAnimationEvent AnimationEvent { get => (EWidgetAnimationEvent)GetAt<byte>(0x18); set => SetAt(0x18, (byte)value); }
        public string UserTag => Native.FNameToString(GetAt<int>(0x1C)); // FName
        public FName UserTag_Raw { get => GetAt<FName>(0x1C); set => SetAt(0x1C, value); }
    }

    public class UserWidgetPool : StructProxy
    {
        public UserWidgetPool(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> ActiveWidgets => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<UObject*>
        public TArray<System.IntPtr> InactiveWidgets => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<UObject*>
    }

    public class WidgetAnimationBinding : StructProxy
    {
        public WidgetAnimationBinding(System.IntPtr ptr) : base(ptr) {}
        public string WidgetName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName WidgetName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string SlotWidgetName => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName SlotWidgetName_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
        public Guid AnimationGuid => new Guid(AddrOf(0x10));
        public bool bIsRootWidget { get => (GetAt<byte>(0x20) & 0xFF) != 0; set { var __b = GetAt<byte>(0x20); SetAt(0x20, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class BlueprintWidgetAnimationDelegateBinding : StructProxy
    {
        public BlueprintWidgetAnimationDelegateBinding(System.IntPtr ptr) : base(ptr) {}
        public EWidgetAnimationEvent Action { get => (EWidgetAnimationEvent)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public string AnimationToBind => Native.FNameToString(GetAt<int>(0x4)); // FName
        public FName AnimationToBind_Raw { get => GetAt<FName>(0x4); set => SetAt(0x4, value); }
        public string FunctionNameToBind => Native.FNameToString(GetAt<int>(0xC)); // FName
        public FName FunctionNameToBind_Raw { get => GetAt<FName>(0xC); set => SetAt(0xC, value); }
        public string UserTag => Native.FNameToString(GetAt<int>(0x14)); // FName
        public FName UserTag_Raw { get => GetAt<FName>(0x14); set => SetAt(0x14, value); }
    }

    public class DelegateRuntimeBinding : StructProxy
    {
        public DelegateRuntimeBinding(System.IntPtr ptr) : base(ptr) {}
        public string ObjectName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public string PropertyName => Native.FNameToString(GetAt<int>(0x10)); // FName
        public FName PropertyName_Raw { get => GetAt<FName>(0x10); set => SetAt(0x10, value); }
        public string FunctionName => Native.FNameToString(GetAt<int>(0x18)); // FName
        public FName FunctionName_Raw { get => GetAt<FName>(0x18); set => SetAt(0x18, value); }
        public DynamicPropertyPath SourcePath => new DynamicPropertyPath(AddrOf(0x20));
        public EBindingKind Kind { get => (EBindingKind)GetAt<byte>(0x48); set => SetAt(0x48, (byte)value); }
    }

    public class WidgetComponentInstanceData : StructProxy
    {
        public WidgetComponentInstanceData(System.IntPtr ptr) : base(ptr) {}
    }

    public class WidgetNavigationData : StructProxy
    {
        public WidgetNavigationData(System.IntPtr ptr) : base(ptr) {}
        public EUINavigationRule Rule { get => (EUINavigationRule)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public string WidgetToFocus => Native.FNameToString(GetAt<int>(0x4)); // FName
        public FName WidgetToFocus_Raw { get => GetAt<FName>(0x4); set => SetAt(0x4, value); }
        public Widget Widget { get { var __p = GetAt<System.IntPtr>(0xC); return __p==System.IntPtr.Zero?null:new Widget(__p); } set => SetAt(0xC, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr CustomDelegate => AddrOf(0x14); // 
    }

    public class Visual : Object
    {
        public const string UeClassName = "Visual";
        public Visual(System.IntPtr ptr) : base(ptr) {}
        public static new Visual FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Visual(p);
        public static Visual FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Visual(o.Pointer); }
        public static Visual[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Visual[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Visual(a[i].Pointer); return r; }
    }

    public class Widget : Visual
    {
        public const string UeClassName = "Widget";
        public Widget(System.IntPtr ptr) : base(ptr) {}
        public static new Widget FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Widget(p);
        public static Widget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Widget(o.Pointer); }
        public static Widget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Widget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Widget(a[i].Pointer); return r; }
        public PanelSlot Slot { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new PanelSlot(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr bIsEnabledDelegate => AddrOf(0x30); // 
        public System.IntPtr ToolTipText => AddrOf(0x40); // 
        public System.IntPtr ToolTipTextDelegate => AddrOf(0x58); // 
        public Widget ToolTipWidget { get { var __p = GetAt<System.IntPtr>(0x68); return __p==System.IntPtr.Zero?null:new Widget(__p); } set => SetAt(0x68, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr ToolTipWidgetDelegate => AddrOf(0x70); // 
        public System.IntPtr VisibilityDelegate => AddrOf(0x80); // 
        public WidgetTransform RenderTransform => new WidgetTransform(AddrOf(0x90));
        public Vector2D RenderTransformPivot => new Vector2D(AddrOf(0xAC));
        public bool bIsVariable { get => Native.GetPropBool(Pointer, "bIsVariable"); set => Native.SetPropBool(Pointer, "bIsVariable", value); }
        public bool bCreatedByConstructionScript { get => Native.GetPropBool(Pointer, "bCreatedByConstructionScript"); set => Native.SetPropBool(Pointer, "bCreatedByConstructionScript", value); }
        public bool bIsEnabled { get => Native.GetPropBool(Pointer, "bIsEnabled"); set => Native.SetPropBool(Pointer, "bIsEnabled", value); }
        public bool bOverride_Cursor { get => Native.GetPropBool(Pointer, "bOverride_Cursor"); set => Native.SetPropBool(Pointer, "bOverride_Cursor", value); }
        public SlateAccessibleWidgetData AccessibleWidgetData { get { var __p = GetAt<System.IntPtr>(0xB8); return __p==System.IntPtr.Zero?null:new SlateAccessibleWidgetData(__p); } set => SetAt(0xB8, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bIsVolatile { get => Native.GetPropBool(Pointer, "bIsVolatile"); set => Native.SetPropBool(Pointer, "bIsVolatile", value); }
        public byte Cursor { get => GetAt<byte>(0xC1); set => SetAt(0xC1, value); }
        public EWidgetClipping Clipping { get => (EWidgetClipping)GetAt<byte>(0xC2); set => SetAt(0xC2, (byte)value); }
        public ESlateVisibility Visibility { get => (ESlateVisibility)GetAt<byte>(0xC3); set => SetAt(0xC3, (byte)value); }
        public float RenderOpacity { get => GetAt<float>(0xC4); set => SetAt(0xC4, value); }
        public WidgetNavigation Navigation { get { var __p = GetAt<System.IntPtr>(0xC8); return __p==System.IntPtr.Zero?null:new WidgetNavigation(__p); } set => SetAt(0xC8, value?.Pointer ?? System.IntPtr.Zero); }
        public EFlowDirectionPreference FlowDirectionPreference { get => (EFlowDirectionPreference)GetAt<byte>(0xD0); set => SetAt(0xD0, (byte)value); }
        public TArray<System.IntPtr> NativeBindings => new TArray<System.IntPtr>(AddrOf(0xF8)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x7E9B9AC — hookable via Hooks.InstallAt(NativeFunc_SetVisibility).</summary>
        public static System.IntPtr NativeFunc_SetVisibility => Memory.ModuleBase() + 0x7E9B9AC;
        public void SetVisibility(ESlateVisibility InVisibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InVisibility);
            CallRaw("SetVisibility", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9B314 — hookable via Hooks.InstallAt(NativeFunc_SetUserFocus).</summary>
        public static System.IntPtr NativeFunc_SetUserFocus => Memory.ModuleBase() + 0x7E9B314;
        public void SetUserFocus(PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, PlayerController);
            CallRaw("SetUserFocus", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9BC20 — hookable via Hooks.InstallAt(NativeFunc_SetToolTipText).</summary>
        public static System.IntPtr NativeFunc_SetToolTipText => Memory.ModuleBase() + 0x7E9BC20;
        public void SetToolTipText(System.IntPtr InToolTipText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InToolTipText);
            CallRaw("SetToolTipText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9BB7C — hookable via Hooks.InstallAt(NativeFunc_SetToolTip).</summary>
        public static System.IntPtr NativeFunc_SetToolTip => Memory.ModuleBase() + 0x7E9BB7C;
        public void SetToolTip(Widget Widget)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Widget);
            CallRaw("SetToolTip", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9BEC4 — hookable via Hooks.InstallAt(NativeFunc_SetRenderTranslation).</summary>
        public static System.IntPtr NativeFunc_SetRenderTranslation => Memory.ModuleBase() + 0x7E9BEC4;
        public void SetRenderTranslation(Vector2D Translation)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Translation);
            CallRaw("SetRenderTranslation", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9BE24 — hookable via Hooks.InstallAt(NativeFunc_SetRenderTransformPivot).</summary>
        public static System.IntPtr NativeFunc_SetRenderTransformPivot => Memory.ModuleBase() + 0x7E9BE24;
        public void SetRenderTransformPivot(Vector2D Pivot)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Pivot);
            CallRaw("SetRenderTransformPivot", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9BF98 — hookable via Hooks.InstallAt(NativeFunc_SetRenderTransformAngle).</summary>
        public static System.IntPtr NativeFunc_SetRenderTransformAngle => Memory.ModuleBase() + 0x7E9BF98;
        public void SetRenderTransformAngle(float Angle)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Angle);
            CallRaw("SetRenderTransformAngle", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9C17C — hookable via Hooks.InstallAt(NativeFunc_SetRenderTransform).</summary>
        public static System.IntPtr NativeFunc_SetRenderTransform => Memory.ModuleBase() + 0x7E9C17C;
        public void SetRenderTransform(WidgetTransform InTransform)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<System.IntPtr>(0x0, InTransform);
            CallRaw("SetRenderTransform", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9C03C — hookable via Hooks.InstallAt(NativeFunc_SetRenderShear).</summary>
        public static System.IntPtr NativeFunc_SetRenderShear => Memory.ModuleBase() + 0x7E9C03C;
        public void SetRenderShear(Vector2D Shear)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Shear);
            CallRaw("SetRenderShear", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9C0DC — hookable via Hooks.InstallAt(NativeFunc_SetRenderScale).</summary>
        public static System.IntPtr NativeFunc_SetRenderScale => Memory.ModuleBase() + 0x7E9C0DC;
        public void SetRenderScale(Vector2D Scale)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Scale);
            CallRaw("SetRenderScale", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9B8D4 — hookable via Hooks.InstallAt(NativeFunc_SetRenderOpacity).</summary>
        public static System.IntPtr NativeFunc_SetRenderOpacity => Memory.ModuleBase() + 0x7E9B8D4;
        public void SetRenderOpacity(float InOpacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InOpacity);
            CallRaw("SetRenderOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9AED4 — hookable via Hooks.InstallAt(NativeFunc_SetNavigationRuleExplicit).</summary>
        public static System.IntPtr NativeFunc_SetNavigationRuleExplicit => Memory.ModuleBase() + 0x7E9AED4;
        public void SetNavigationRuleExplicit(EUINavigation Direction, Widget InWidget)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<byte>(0x0, (byte)Direction);
            __pb.SetObject(0x8, InWidget);
            CallRaw("SetNavigationRuleExplicit", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9ACF4 — hookable via Hooks.InstallAt(NativeFunc_SetNavigationRuleCustomBoundary).</summary>
        public static System.IntPtr NativeFunc_SetNavigationRuleCustomBoundary => Memory.ModuleBase() + 0x7E9ACF4;
        public void SetNavigationRuleCustomBoundary(EUINavigation Direction, System.IntPtr InCustomDelegate)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<byte>(0x0, (byte)Direction);
            __pb.Set<System.IntPtr>(0x4, InCustomDelegate);
            CallRaw("SetNavigationRuleCustomBoundary", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9ADE4 — hookable via Hooks.InstallAt(NativeFunc_SetNavigationRuleCustom).</summary>
        public static System.IntPtr NativeFunc_SetNavigationRuleCustom => Memory.ModuleBase() + 0x7E9ADE4;
        public void SetNavigationRuleCustom(EUINavigation Direction, System.IntPtr InCustomDelegate)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<byte>(0x0, (byte)Direction);
            __pb.Set<System.IntPtr>(0x4, InCustomDelegate);
            CallRaw("SetNavigationRuleCustom", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9AFBC — hookable via Hooks.InstallAt(NativeFunc_SetNavigationRuleBase).</summary>
        public static System.IntPtr NativeFunc_SetNavigationRuleBase => Memory.ModuleBase() + 0x7E9AFBC;
        public void SetNavigationRuleBase(EUINavigation Direction, EUINavigationRule Rule)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Direction);
            __pb.Set<byte>(0x1, (byte)Rule);
            CallRaw("SetNavigationRuleBase", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9B0A4 — hookable via Hooks.InstallAt(NativeFunc_SetNavigationRule).</summary>
        public static System.IntPtr NativeFunc_SetNavigationRule => Memory.ModuleBase() + 0x7E9B0A4;
        public void SetNavigationRule(EUINavigation Direction, EUINavigationRule Rule, FName WidgetToFocus)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<byte>(0x0, (byte)Direction);
            __pb.Set<byte>(0x1, (byte)Rule);
            __pb.Set(0x4, WidgetToFocus);
            CallRaw("SetNavigationRule", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9B59C — hookable via Hooks.InstallAt(NativeFunc_SetKeyboardFocus).</summary>
        public static System.IntPtr NativeFunc_SetKeyboardFocus => Memory.ModuleBase() + 0x7E9B59C;
        public void SetKeyboardFocus()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetKeyboardFocus", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9BD38 — hookable via Hooks.InstallAt(NativeFunc_SetIsEnabled).</summary>
        public static System.IntPtr NativeFunc_SetIsEnabled => Memory.ModuleBase() + 0x7E9BD38;
        public void SetIsEnabled(bool bInIsEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInIsEnabled?1:0));
            CallRaw("SetIsEnabled", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9B3B8 — hookable via Hooks.InstallAt(NativeFunc_SetFocus).</summary>
        public static System.IntPtr NativeFunc_SetFocus => Memory.ModuleBase() + 0x7E9B3B8;
        public void SetFocus()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetFocus", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9BAD8 — hookable via Hooks.InstallAt(NativeFunc_SetCursor).</summary>
        public static System.IntPtr NativeFunc_SetCursor => Memory.ModuleBase() + 0x7E9BAD8;
        public void SetCursor(byte InCursor)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InCursor);
            CallRaw("SetCursor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9B7FC — hookable via Hooks.InstallAt(NativeFunc_SetClipping).</summary>
        public static System.IntPtr NativeFunc_SetClipping => Memory.ModuleBase() + 0x7E9B7FC;
        public void SetClipping(EWidgetClipping InClipping)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InClipping);
            CallRaw("SetClipping", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9B1D0 — hookable via Hooks.InstallAt(NativeFunc_SetAllNavigationRules).</summary>
        public static System.IntPtr NativeFunc_SetAllNavigationRules => Memory.ModuleBase() + 0x7E9B1D0;
        public void SetAllNavigationRules(EUINavigationRule Rule, FName WidgetToFocus)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<byte>(0x0, (byte)Rule);
            __pb.Set(0x4, WidgetToFocus);
            CallRaw("SetAllNavigationRules", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9BAC4 — hookable via Hooks.InstallAt(NativeFunc_ResetCursor).</summary>
        public static System.IntPtr NativeFunc_ResetCursor => Memory.ModuleBase() + 0x7E9BAC4;
        public void ResetCursor()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetCursor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9ACA4 — hookable via Hooks.InstallAt(NativeFunc_RemoveFromParent).</summary>
        public static System.IntPtr NativeFunc_RemoveFromParent => Memory.ModuleBase() + 0x7E9ACA4;
        public void RemoveFromParent()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RemoveFromParent", __pb.Bytes);
        }
        public EventReply OnReply__DelegateSignature()
        {
            var __pb = new ParamBuffer(184);
            CallRaw("OnReply__DelegateSignature", __pb.Bytes);
            return __pb.Get<EventReply>(0x0);
        }
        public EventReply OnPointerEvent__DelegateSignature(Geometry MyGeometry, PointerEvent MouseEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, MouseEvent);
            CallRaw("OnPointerEvent__DelegateSignature", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        /// <summary>[Native] thunk RVA 0x7E9BA8C — hookable via Hooks.InstallAt(NativeFunc_IsVisible).</summary>
        public static System.IntPtr NativeFunc_IsVisible => Memory.ModuleBase() + 0x7E9BA8C;
        public bool IsVisible()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsVisible", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E9B710 — hookable via Hooks.InstallAt(NativeFunc_IsHovered).</summary>
        public static System.IntPtr NativeFunc_IsHovered => Memory.ModuleBase() + 0x7E9B710;
        public bool IsHovered()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsHovered", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E9B2EC — hookable via Hooks.InstallAt(NativeFunc_InvalidateLayoutAndVolatility).</summary>
        public static System.IntPtr NativeFunc_InvalidateLayoutAndVolatility => Memory.ModuleBase() + 0x7E9B2EC;
        public void InvalidateLayoutAndVolatility()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InvalidateLayoutAndVolatility", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9B3CC — hookable via Hooks.InstallAt(NativeFunc_HasUserFocusedDescendants).</summary>
        public static System.IntPtr NativeFunc_HasUserFocusedDescendants => Memory.ModuleBase() + 0x7E9B3CC;
        public bool HasUserFocusedDescendants(PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, PlayerController);
            CallRaw("HasUserFocusedDescendants", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E9B4EC — hookable via Hooks.InstallAt(NativeFunc_HasUserFocus).</summary>
        public static System.IntPtr NativeFunc_HasUserFocus => Memory.ModuleBase() + 0x7E9B4EC;
        public bool HasUserFocus(PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, PlayerController);
            CallRaw("HasUserFocus", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E9B5B0 — hookable via Hooks.InstallAt(NativeFunc_HasMouseCaptureByUser).</summary>
        public static System.IntPtr NativeFunc_HasMouseCaptureByUser => Memory.ModuleBase() + 0x7E9B5B0;
        public bool HasMouseCaptureByUser(int UserIndex, int PointerIndex)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, UserIndex);
            __pb.Set(0x4, PointerIndex);
            CallRaw("HasMouseCaptureByUser", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E9B6A0 — hookable via Hooks.InstallAt(NativeFunc_HasMouseCapture).</summary>
        public static System.IntPtr NativeFunc_HasMouseCapture => Memory.ModuleBase() + 0x7E9B6A0;
        public bool HasMouseCapture()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasMouseCapture", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E9B6D8 — hookable via Hooks.InstallAt(NativeFunc_HasKeyboardFocus).</summary>
        public static System.IntPtr NativeFunc_HasKeyboardFocus => Memory.ModuleBase() + 0x7E9B6D8;
        public bool HasKeyboardFocus()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasKeyboardFocus", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E9B47C — hookable via Hooks.InstallAt(NativeFunc_HasFocusedDescendants).</summary>
        public static System.IntPtr NativeFunc_HasFocusedDescendants => Memory.ModuleBase() + 0x7E9B47C;
        public bool HasFocusedDescendants()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasFocusedDescendants", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E9B4B4 — hookable via Hooks.InstallAt(NativeFunc_HasAnyUserFocus).</summary>
        public static System.IntPtr NativeFunc_HasAnyUserFocus => Memory.ModuleBase() + 0x7E9B4B4;
        public bool HasAnyUserFocus()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasAnyUserFocus", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public Widget GetWidget__DelegateSignature()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetWidget__DelegateSignature", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Widget(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E9BA58 — hookable via Hooks.InstallAt(NativeFunc_GetVisibility).</summary>
        public static System.IntPtr NativeFunc_GetVisibility => Memory.ModuleBase() + 0x7E9BA58;
        public ESlateVisibility GetVisibility()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetVisibility", __pb.Bytes);
            return (ESlateVisibility)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9AC34 — hookable via Hooks.InstallAt(NativeFunc_GetTickSpaceGeometry).</summary>
        public static System.IntPtr NativeFunc_GetTickSpaceGeometry => Memory.ModuleBase() + 0x7E9AC34;
        public Geometry GetTickSpaceGeometry()
        {
            var __pb = new ParamBuffer(56);
            CallRaw("GetTickSpaceGeometry", __pb.Bytes);
            return __pb.Get<Geometry>(0x0);
        }
        public System.IntPtr GetText__DelegateSignature()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetText__DelegateSignature", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        public ESlateVisibility GetSlateVisibility__DelegateSignature()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetSlateVisibility__DelegateSignature", __pb.Bytes);
            return (ESlateVisibility)__pb.Get<byte>(0x0);
        }
        public SlateColor GetSlateColor__DelegateSignature()
        {
            var __pb = new ParamBuffer(40);
            CallRaw("GetSlateColor__DelegateSignature", __pb.Bytes);
            return __pb.Get<SlateColor>(0x0);
        }
        public SlateBrush GetSlateBrush__DelegateSignature()
        {
            var __pb = new ParamBuffer(136);
            CallRaw("GetSlateBrush__DelegateSignature", __pb.Bytes);
            return __pb.Get<SlateBrush>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9BF64 — hookable via Hooks.InstallAt(NativeFunc_GetRenderTransformAngle).</summary>
        public static System.IntPtr NativeFunc_GetRenderTransformAngle => Memory.ModuleBase() + 0x7E9BF64;
        public float GetRenderTransformAngle()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetRenderTransformAngle", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9B978 — hookable via Hooks.InstallAt(NativeFunc_GetRenderOpacity).</summary>
        public static System.IntPtr NativeFunc_GetRenderOpacity => Memory.ModuleBase() + 0x7E9B978;
        public float GetRenderOpacity()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetRenderOpacity", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9ACC0 — hookable via Hooks.InstallAt(NativeFunc_GetParent).</summary>
        public static System.IntPtr NativeFunc_GetParent => Memory.ModuleBase() + 0x7E9ACC0;
        public PanelWidget GetParent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetParent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new PanelWidget(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E9ABFC — hookable via Hooks.InstallAt(NativeFunc_GetPaintSpaceGeometry).</summary>
        public static System.IntPtr NativeFunc_GetPaintSpaceGeometry => Memory.ModuleBase() + 0x7E9ABFC;
        public Geometry GetPaintSpaceGeometry()
        {
            var __pb = new ParamBuffer(56);
            CallRaw("GetPaintSpaceGeometry", __pb.Bytes);
            return __pb.Get<Geometry>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9AB8C — hookable via Hooks.InstallAt(NativeFunc_GetOwningPlayer).</summary>
        public static System.IntPtr NativeFunc_GetOwningPlayer => Memory.ModuleBase() + 0x7E9AB8C;
        public PlayerController GetOwningPlayer()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetOwningPlayer", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new PlayerController(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E9AB50 — hookable via Hooks.InstallAt(NativeFunc_GetOwningLocalPlayer).</summary>
        public static System.IntPtr NativeFunc_GetOwningLocalPlayer => Memory.ModuleBase() + 0x7E9AB50;
        public LocalPlayer GetOwningLocalPlayer()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetOwningLocalPlayer", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new LocalPlayer(__p); }
        }
        public byte GetMouseCursor__DelegateSignature()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetMouseCursor__DelegateSignature", __pb.Bytes);
            return __pb.Get<byte>(0x0);
        }
        public LinearColor GetLinearColor__DelegateSignature()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetLinearColor__DelegateSignature", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9BDEC — hookable via Hooks.InstallAt(NativeFunc_GetIsEnabled).</summary>
        public static System.IntPtr NativeFunc_GetIsEnabled => Memory.ModuleBase() + 0x7E9BDEC;
        public bool GetIsEnabled()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetIsEnabled", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public int GetInt32__DelegateSignature()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetInt32__DelegateSignature", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9ABC8 — hookable via Hooks.InstallAt(NativeFunc_GetGameInstance).</summary>
        public static System.IntPtr NativeFunc_GetGameInstance => Memory.ModuleBase() + 0x7E9ABC8;
        public GameInstance GetGameInstance()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetGameInstance", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new GameInstance(__p); }
        }
        public float GetFloat__DelegateSignature()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetFloat__DelegateSignature", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9B2B8 — hookable via Hooks.InstallAt(NativeFunc_GetDesiredSize).</summary>
        public static System.IntPtr NativeFunc_GetDesiredSize => Memory.ModuleBase() + 0x7E9B2B8;
        public Vector2D GetDesiredSize()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDesiredSize", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9B8A0 — hookable via Hooks.InstallAt(NativeFunc_GetClipping).</summary>
        public static System.IntPtr NativeFunc_GetClipping => Memory.ModuleBase() + 0x7E9B8A0;
        public EWidgetClipping GetClipping()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetClipping", __pb.Bytes);
            return (EWidgetClipping)__pb.Get<byte>(0x0);
        }
        public ECheckBoxState GetCheckBoxState__DelegateSignature()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetCheckBoxState__DelegateSignature", __pb.Bytes);
            return (ECheckBoxState)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9AC6C — hookable via Hooks.InstallAt(NativeFunc_GetCachedGeometry).</summary>
        public static System.IntPtr NativeFunc_GetCachedGeometry => Memory.ModuleBase() + 0x7E9AC6C;
        public Geometry GetCachedGeometry()
        {
            var __pb = new ParamBuffer(56);
            CallRaw("GetCachedGeometry", __pb.Bytes);
            return __pb.Get<Geometry>(0x0);
        }
        public bool GetBool__DelegateSignature()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetBool__DelegateSignature", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public Widget GenerateWidgetForString__DelegateSignature(System.IntPtr Item)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Item);
            CallRaw("GenerateWidgetForString__DelegateSignature", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new Widget(__p); }
        }
        public Widget GenerateWidgetForObject__DelegateSignature(Object Item)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Item);
            CallRaw("GenerateWidgetForObject__DelegateSignature", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new Widget(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E9B750 — hookable via Hooks.InstallAt(NativeFunc_ForceVolatile).</summary>
        public static System.IntPtr NativeFunc_ForceVolatile => Memory.ModuleBase() + 0x7E9B750;
        public void ForceVolatile(bool bForce)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bForce?1:0));
            CallRaw("ForceVolatile", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9B300 — hookable via Hooks.InstallAt(NativeFunc_ForceLayoutPrepass).</summary>
        public static System.IntPtr NativeFunc_ForceLayoutPrepass => Memory.ModuleBase() + 0x7E9B300;
        public void ForceLayoutPrepass()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ForceLayoutPrepass", __pb.Bytes);
        }
    }

    public class UserWidget : Widget
    {
        public const string UeClassName = "UserWidget";
        public UserWidget(System.IntPtr ptr) : base(ptr) {}
        public static new UserWidget FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UserWidget(p);
        public static UserWidget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UserWidget(o.Pointer); }
        public static UserWidget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UserWidget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UserWidget(a[i].Pointer); return r; }
        public LinearColor ColorAndOpacity => new LinearColor(AddrOf(0x110));
        public System.IntPtr ColorAndOpacityDelegate => AddrOf(0x120); // 
        public SlateColor ForegroundColor => new SlateColor(AddrOf(0x130));
        public System.IntPtr ForegroundColorDelegate => AddrOf(0x158); // 
        public Margin Padding => new Margin(AddrOf(0x168));
        public TArray<System.IntPtr> ActiveSequencePlayers => new TArray<System.IntPtr>(AddrOf(0x178)); // TArray<UObject*>
        public TArray<System.IntPtr> StoppedSequencePlayers => new TArray<System.IntPtr>(AddrOf(0x188)); // TArray<UObject*>
        public TArray<System.IntPtr> NamedSlotBindings => new TArray<System.IntPtr>(AddrOf(0x198)); // TArray<struct>
        public WidgetTree WidgetTree { get { var __p = GetAt<System.IntPtr>(0x1A8); return __p==System.IntPtr.Zero?null:new WidgetTree(__p); } set => SetAt(0x1A8, value?.Pointer ?? System.IntPtr.Zero); }
        public int Priority { get => GetAt<int>(0x1B0); set => SetAt(0x1B0, value); }
        public bool bSupportsKeyboardFocus { get => Native.GetPropBool(Pointer, "bSupportsKeyboardFocus"); set => Native.SetPropBool(Pointer, "bSupportsKeyboardFocus", value); }
        public bool bIsFocusable { get => Native.GetPropBool(Pointer, "bIsFocusable"); set => Native.SetPropBool(Pointer, "bIsFocusable", value); }
        public bool bStopAction { get => Native.GetPropBool(Pointer, "bStopAction"); set => Native.SetPropBool(Pointer, "bStopAction", value); }
        public bool bHasScriptImplementedTick { get => Native.GetPropBool(Pointer, "bHasScriptImplementedTick"); set => Native.SetPropBool(Pointer, "bHasScriptImplementedTick", value); }
        public bool bHasScriptImplementedPaint { get => Native.GetPropBool(Pointer, "bHasScriptImplementedPaint"); set => Native.SetPropBool(Pointer, "bHasScriptImplementedPaint", value); }
        public bool bCookedWidgetTree { get => Native.GetPropBool(Pointer, "bCookedWidgetTree"); set => Native.SetPropBool(Pointer, "bCookedWidgetTree", value); }
        public EWidgetTickFrequency TickFrequency { get => (EWidgetTickFrequency)GetAt<byte>(0x1C0); set => SetAt(0x1C0, (byte)value); }
        public InputComponent InputComponent { get { var __p = GetAt<System.IntPtr>(0x1C8); return __p==System.IntPtr.Zero?null:new InputComponent(__p); } set => SetAt(0x1C8, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> AnimationCallbacks => new TArray<System.IntPtr>(AddrOf(0x1D0)); // TArray<struct>
        /// <summary>[Native] thunk RVA 0x7E8D698 — hookable via Hooks.InstallAt(NativeFunc_UnregisterInputComponent).</summary>
        public static System.IntPtr NativeFunc_UnregisterInputComponent => Memory.ModuleBase() + 0x7E8D698;
        public void UnregisterInputComponent()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnregisterInputComponent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8EFD0 — hookable via Hooks.InstallAt(NativeFunc_UnbindFromAnimationStarted).</summary>
        public static System.IntPtr NativeFunc_UnbindFromAnimationStarted => Memory.ModuleBase() + 0x7E8EFD0;
        public void UnbindFromAnimationStarted(WidgetAnimation Animation, System.IntPtr Delegate)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Animation);
            __pb.Set<System.IntPtr>(0x8, Delegate);
            CallRaw("UnbindFromAnimationStarted", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8ED4C — hookable via Hooks.InstallAt(NativeFunc_UnbindFromAnimationFinished).</summary>
        public static System.IntPtr NativeFunc_UnbindFromAnimationFinished => Memory.ModuleBase() + 0x7E8ED4C;
        public void UnbindFromAnimationFinished(WidgetAnimation Animation, System.IntPtr Delegate)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Animation);
            __pb.Set<System.IntPtr>(0x8, Delegate);
            CallRaw("UnbindFromAnimationFinished", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8EF2C — hookable via Hooks.InstallAt(NativeFunc_UnbindAllFromAnimationStarted).</summary>
        public static System.IntPtr NativeFunc_UnbindAllFromAnimationStarted => Memory.ModuleBase() + 0x7E8EF2C;
        public void UnbindAllFromAnimationStarted(WidgetAnimation Animation)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Animation);
            CallRaw("UnbindAllFromAnimationStarted", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8ECA8 — hookable via Hooks.InstallAt(NativeFunc_UnbindAllFromAnimationFinished).</summary>
        public static System.IntPtr NativeFunc_UnbindAllFromAnimationFinished => Memory.ModuleBase() + 0x7E8ECA8;
        public void UnbindAllFromAnimationFinished(WidgetAnimation Animation)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Animation);
            CallRaw("UnbindAllFromAnimationFinished", __pb.Bytes);
        }
        public void Tick(Geometry MyGeometry, float InDeltaTime)
        {
            var __pb = new ParamBuffer(60);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set(0x38, InDeltaTime);
            CallRaw("Tick", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8D6D4 — hookable via Hooks.InstallAt(NativeFunc_StopListeningForInputAction).</summary>
        public static System.IntPtr NativeFunc_StopListeningForInputAction => Memory.ModuleBase() + 0x7E8D6D4;
        public void StopListeningForInputAction(FName ActionName, byte EventType)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, ActionName);
            __pb.Set(0x8, EventType);
            CallRaw("StopListeningForInputAction", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8D6C0 — hookable via Hooks.InstallAt(NativeFunc_StopListeningForAllInputActions).</summary>
        public static System.IntPtr NativeFunc_StopListeningForAllInputActions => Memory.ModuleBase() + 0x7E8D6C0;
        public void StopListeningForAllInputActions()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopListeningForAllInputActions", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F1B0 — hookable via Hooks.InstallAt(NativeFunc_StopAnimationsAndLatentActions).</summary>
        public static System.IntPtr NativeFunc_StopAnimationsAndLatentActions => Memory.ModuleBase() + 0x7E8F1B0;
        public void StopAnimationsAndLatentActions()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopAnimationsAndLatentActions", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8DF7C — hookable via Hooks.InstallAt(NativeFunc_StopAnimation).</summary>
        public static System.IntPtr NativeFunc_StopAnimation => Memory.ModuleBase() + 0x7E8DF7C;
        public void StopAnimation(WidgetAnimation InAnimation)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InAnimation);
            CallRaw("StopAnimation", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8DF68 — hookable via Hooks.InstallAt(NativeFunc_StopAllAnimations).</summary>
        public static System.IntPtr NativeFunc_StopAllAnimations => Memory.ModuleBase() + 0x7E8DF68;
        public void StopAllAnimations()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopAllAnimations", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F574 — hookable via Hooks.InstallAt(NativeFunc_SetPositionInViewport).</summary>
        public static System.IntPtr NativeFunc_SetPositionInViewport => Memory.ModuleBase() + 0x7E8F574;
        public void SetPositionInViewport(Vector2D Position, bool bRemoveDPIScale)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<System.IntPtr>(0x0, Position);
            __pb.Set<byte>(0x8, (byte)(bRemoveDPIScale?1:0));
            CallRaw("SetPositionInViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8DB58 — hookable via Hooks.InstallAt(NativeFunc_SetPlaybackSpeed).</summary>
        public static System.IntPtr NativeFunc_SetPlaybackSpeed => Memory.ModuleBase() + 0x7E8DB58;
        public void SetPlaybackSpeed(WidgetAnimation InAnimation, float PlaybackSpeed)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, InAnimation);
            __pb.Set(0x8, PlaybackSpeed);
            CallRaw("SetPlaybackSpeed", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8E6E8 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E8E6E8;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F20C — hookable via Hooks.InstallAt(NativeFunc_SetOwningPlayer).</summary>
        public static System.IntPtr NativeFunc_SetOwningPlayer => Memory.ModuleBase() + 0x7E8F20C;
        public void SetOwningPlayer(PlayerController LocalPlayerController)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, LocalPlayerController);
            CallRaw("SetOwningPlayer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8DC40 — hookable via Hooks.InstallAt(NativeFunc_SetNumLoopsToPlay).</summary>
        public static System.IntPtr NativeFunc_SetNumLoopsToPlay => Memory.ModuleBase() + 0x7E8DC40;
        public void SetNumLoopsToPlay(WidgetAnimation InAnimation, int NumLoopsToPlay)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, InAnimation);
            __pb.Set(0x8, NumLoopsToPlay);
            CallRaw("SetNumLoopsToPlay", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8D544 — hookable via Hooks.InstallAt(NativeFunc_SetInputActionPriority).</summary>
        public static System.IntPtr NativeFunc_SetInputActionPriority => Memory.ModuleBase() + 0x7E8D544;
        public void SetInputActionPriority(int NewPriority)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewPriority);
            CallRaw("SetInputActionPriority", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8D498 — hookable via Hooks.InstallAt(NativeFunc_SetInputActionBlocking).</summary>
        public static System.IntPtr NativeFunc_SetInputActionBlocking => Memory.ModuleBase() + 0x7E8D498;
        public void SetInputActionBlocking(bool bShouldBlock)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bShouldBlock?1:0));
            CallRaw("SetInputActionBlocking", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8E790 — hookable via Hooks.InstallAt(NativeFunc_SetForegroundColor).</summary>
        public static System.IntPtr NativeFunc_SetForegroundColor => Memory.ModuleBase() + 0x7E8E790;
        public void SetForegroundColor(SlateColor InForegroundColor)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, InForegroundColor);
            CallRaw("SetForegroundColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F4D4 — hookable via Hooks.InstallAt(NativeFunc_SetDesiredSizeInViewport).</summary>
        public static System.IntPtr NativeFunc_SetDesiredSizeInViewport => Memory.ModuleBase() + 0x7E8F4D4;
        public void SetDesiredSizeInViewport(Vector2D Size)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Size);
            CallRaw("SetDesiredSizeInViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8E934 — hookable via Hooks.InstallAt(NativeFunc_SetColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetColorAndOpacity => Memory.ModuleBase() + 0x7E8E934;
        public void SetColorAndOpacity(LinearColor InColorAndOpacity)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InColorAndOpacity);
            CallRaw("SetColorAndOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F42C — hookable via Hooks.InstallAt(NativeFunc_SetAnchorsInViewport).</summary>
        public static System.IntPtr NativeFunc_SetAnchorsInViewport => Memory.ModuleBase() + 0x7E8F42C;
        public void SetAnchorsInViewport(Anchors Anchors)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Anchors);
            CallRaw("SetAnchorsInViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F38C — hookable via Hooks.InstallAt(NativeFunc_SetAlignmentInViewport).</summary>
        public static System.IntPtr NativeFunc_SetAlignmentInViewport => Memory.ModuleBase() + 0x7E8F38C;
        public void SetAlignmentInViewport(Vector2D Alignment)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Alignment);
            CallRaw("SetAlignmentInViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8DAB4 — hookable via Hooks.InstallAt(NativeFunc_ReverseAnimation).</summary>
        public static System.IntPtr NativeFunc_ReverseAnimation => Memory.ModuleBase() + 0x7E8DAB4;
        public void ReverseAnimation(WidgetAnimation InAnimation)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InAnimation);
            CallRaw("ReverseAnimation", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F660 — hookable via Hooks.InstallAt(NativeFunc_RemoveFromViewport).</summary>
        public static System.IntPtr NativeFunc_RemoveFromViewport => Memory.ModuleBase() + 0x7E8F660;
        public void RemoveFromViewport()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RemoveFromViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8D6AC — hookable via Hooks.InstallAt(NativeFunc_RegisterInputComponent).</summary>
        public static System.IntPtr NativeFunc_RegisterInputComponent => Memory.ModuleBase() + 0x7E8D6AC;
        public void RegisterInputComponent()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RegisterInputComponent", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8D960 — hookable via Hooks.InstallAt(NativeFunc_PlaySound).</summary>
        public static System.IntPtr NativeFunc_PlaySound => Memory.ModuleBase() + 0x7E8D960;
        public void PlaySound(SoundBase SoundToPlay)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, SoundToPlay);
            CallRaw("PlaySound", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8E298 — hookable via Hooks.InstallAt(NativeFunc_PlayAnimationTimeRange).</summary>
        public static System.IntPtr NativeFunc_PlayAnimationTimeRange => Memory.ModuleBase() + 0x7E8E298;
        public UMGSequencePlayer PlayAnimationTimeRange(WidgetAnimation InAnimation, float StartAtTime, float EndAtTime, int NumLoopsToPlay, byte PlayMode, float PlaybackSpeed, bool bRestoreState)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, InAnimation);
            __pb.Set(0x8, StartAtTime);
            __pb.Set(0xC, EndAtTime);
            __pb.Set(0x10, NumLoopsToPlay);
            __pb.Set(0x14, PlayMode);
            __pb.Set(0x18, PlaybackSpeed);
            __pb.Set<byte>(0x1C, (byte)(bRestoreState?1:0));
            CallRaw("PlayAnimationTimeRange", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new UMGSequencePlayer(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E8E020 — hookable via Hooks.InstallAt(NativeFunc_PlayAnimationReverse).</summary>
        public static System.IntPtr NativeFunc_PlayAnimationReverse => Memory.ModuleBase() + 0x7E8E020;
        public UMGSequencePlayer PlayAnimationReverse(WidgetAnimation InAnimation, float PlaybackSpeed, bool bRestoreState)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, InAnimation);
            __pb.Set(0x8, PlaybackSpeed);
            __pb.Set<byte>(0xC, (byte)(bRestoreState?1:0));
            CallRaw("PlayAnimationReverse", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new UMGSequencePlayer(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E8E15C — hookable via Hooks.InstallAt(NativeFunc_PlayAnimationForward).</summary>
        public static System.IntPtr NativeFunc_PlayAnimationForward => Memory.ModuleBase() + 0x7E8E15C;
        public UMGSequencePlayer PlayAnimationForward(WidgetAnimation InAnimation, float PlaybackSpeed, bool bRestoreState)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, InAnimation);
            __pb.Set(0x8, PlaybackSpeed);
            __pb.Set<byte>(0xC, (byte)(bRestoreState?1:0));
            CallRaw("PlayAnimationForward", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new UMGSequencePlayer(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E8E4E0 — hookable via Hooks.InstallAt(NativeFunc_PlayAnimation).</summary>
        public static System.IntPtr NativeFunc_PlayAnimation => Memory.ModuleBase() + 0x7E8E4E0;
        public UMGSequencePlayer PlayAnimation(WidgetAnimation InAnimation, float StartAtTime, int NumLoopsToPlay, byte PlayMode, float PlaybackSpeed, bool bRestoreState)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, InAnimation);
            __pb.Set(0x8, StartAtTime);
            __pb.Set(0xC, NumLoopsToPlay);
            __pb.Set(0x10, PlayMode);
            __pb.Set(0x14, PlaybackSpeed);
            __pb.Set<byte>(0x18, (byte)(bRestoreState?1:0));
            CallRaw("PlayAnimation", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x20); return __p==System.IntPtr.Zero?null:new UMGSequencePlayer(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E8DEBC — hookable via Hooks.InstallAt(NativeFunc_PauseAnimation).</summary>
        public static System.IntPtr NativeFunc_PauseAnimation => Memory.ModuleBase() + 0x7E8DEBC;
        public float PauseAnimation(WidgetAnimation InAnimation)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, InAnimation);
            CallRaw("PauseAnimation", __pb.Bytes);
            return __pb.Get<float>(0x8);
        }
        public EventReply OnTouchStarted(Geometry MyGeometry, PointerEvent InTouchEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InTouchEvent);
            CallRaw("OnTouchStarted", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public EventReply OnTouchMoved(Geometry MyGeometry, PointerEvent InTouchEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InTouchEvent);
            CallRaw("OnTouchMoved", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public EventReply OnTouchGesture(Geometry MyGeometry, PointerEvent GestureEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, GestureEvent);
            CallRaw("OnTouchGesture", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public EventReply OnTouchForceChanged(Geometry MyGeometry, PointerEvent InTouchEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InTouchEvent);
            CallRaw("OnTouchForceChanged", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public EventReply OnTouchEnded(Geometry MyGeometry, PointerEvent InTouchEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InTouchEvent);
            CallRaw("OnTouchEnded", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public void OnRemovedFromFocusPath(FocusEvent InFocusEvent)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InFocusEvent);
            CallRaw("OnRemovedFromFocusPath", __pb.Bytes);
        }
        public EventReply OnPreviewMouseButtonDown(Geometry MyGeometry, PointerEvent MouseEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, MouseEvent);
            CallRaw("OnPreviewMouseButtonDown", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public EventReply OnPreviewKeyDown(Geometry MyGeometry, KeyEvent InKeyEvent)
        {
            var __pb = new ParamBuffer(296);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InKeyEvent);
            CallRaw("OnPreviewKeyDown", __pb.Bytes);
            return __pb.Get<EventReply>(0x70);
        }
        public void OnPaint(PaintContext Context)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, Context);
            CallRaw("OnPaint", __pb.Bytes);
        }
        public EventReply OnMouseWheel(Geometry MyGeometry, PointerEvent MouseEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, MouseEvent);
            CallRaw("OnMouseWheel", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public EventReply OnMouseMove(Geometry MyGeometry, PointerEvent MouseEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, MouseEvent);
            CallRaw("OnMouseMove", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public void OnMouseLeave(PointerEvent MouseEvent)
        {
            var __pb = new ParamBuffer(112);
            __pb.Set<System.IntPtr>(0x0, MouseEvent);
            CallRaw("OnMouseLeave", __pb.Bytes);
        }
        public void OnMouseEnter(Geometry MyGeometry, PointerEvent MouseEvent)
        {
            var __pb = new ParamBuffer(168);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, MouseEvent);
            CallRaw("OnMouseEnter", __pb.Bytes);
        }
        public void OnMouseCaptureLost()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnMouseCaptureLost", __pb.Bytes);
        }
        public EventReply OnMouseButtonUp(Geometry MyGeometry, PointerEvent MouseEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, MouseEvent);
            CallRaw("OnMouseButtonUp", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public EventReply OnMouseButtonDown(Geometry MyGeometry, PointerEvent MouseEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, MouseEvent);
            CallRaw("OnMouseButtonDown", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public EventReply OnMouseButtonDoubleClick(Geometry InMyGeometry, PointerEvent InMouseEvent)
        {
            var __pb = new ParamBuffer(352);
            __pb.Set<System.IntPtr>(0x0, InMyGeometry);
            __pb.Set<System.IntPtr>(0x38, InMouseEvent);
            CallRaw("OnMouseButtonDoubleClick", __pb.Bytes);
            return __pb.Get<EventReply>(0xA8);
        }
        public EventReply OnMotionDetected(Geometry MyGeometry, MotionEvent InMotionEvent)
        {
            var __pb = new ParamBuffer(312);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InMotionEvent);
            CallRaw("OnMotionDetected", __pb.Bytes);
            return __pb.Get<EventReply>(0x80);
        }
        public EventReply OnKeyUp(Geometry MyGeometry, KeyEvent InKeyEvent)
        {
            var __pb = new ParamBuffer(296);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InKeyEvent);
            CallRaw("OnKeyUp", __pb.Bytes);
            return __pb.Get<EventReply>(0x70);
        }
        public EventReply OnKeyDown(Geometry MyGeometry, KeyEvent InKeyEvent)
        {
            var __pb = new ParamBuffer(296);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InKeyEvent);
            CallRaw("OnKeyDown", __pb.Bytes);
            return __pb.Get<EventReply>(0x70);
        }
        public EventReply OnKeyChar(Geometry MyGeometry, CharacterEvent InCharacterEvent)
        {
            var __pb = new ParamBuffer(272);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InCharacterEvent);
            CallRaw("OnKeyChar", __pb.Bytes);
            return __pb.Get<EventReply>(0x58);
        }
        public void OnInitialized()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnInitialized", __pb.Bytes);
        }
        public EventReply OnFocusReceived(Geometry MyGeometry, FocusEvent InFocusEvent)
        {
            var __pb = new ParamBuffer(248);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InFocusEvent);
            CallRaw("OnFocusReceived", __pb.Bytes);
            return __pb.Get<EventReply>(0x40);
        }
        public void OnFocusLost(FocusEvent InFocusEvent)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InFocusEvent);
            CallRaw("OnFocusLost", __pb.Bytes);
        }
        public bool OnDrop(Geometry MyGeometry, PointerEvent PointerEvent, DragDropOperation Operation)
        {
            var __pb = new ParamBuffer(177);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, PointerEvent);
            __pb.SetObject(0xA8, Operation);
            CallRaw("OnDrop", __pb.Bytes);
            return __pb.Get<byte>(0xB0) != 0;
        }
        public bool OnDragOver(Geometry MyGeometry, PointerEvent PointerEvent, DragDropOperation Operation)
        {
            var __pb = new ParamBuffer(177);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, PointerEvent);
            __pb.SetObject(0xA8, Operation);
            CallRaw("OnDragOver", __pb.Bytes);
            return __pb.Get<byte>(0xB0) != 0;
        }
        public void OnDragLeave(PointerEvent PointerEvent, DragDropOperation Operation)
        {
            var __pb = new ParamBuffer(120);
            __pb.Set<System.IntPtr>(0x0, PointerEvent);
            __pb.SetObject(0x70, Operation);
            CallRaw("OnDragLeave", __pb.Bytes);
        }
        public void OnDragEnter(Geometry MyGeometry, PointerEvent PointerEvent, DragDropOperation Operation)
        {
            var __pb = new ParamBuffer(176);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, PointerEvent);
            __pb.SetObject(0xA8, Operation);
            CallRaw("OnDragEnter", __pb.Bytes);
        }
        public void OnDragDetected(Geometry MyGeometry, PointerEvent PointerEvent, DragDropOperation Operation)
        {
            var __pb = new ParamBuffer(176);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, PointerEvent);
            __pb.SetObject(0xA8, Operation);
            CallRaw("OnDragDetected", __pb.Bytes);
        }
        public void OnDragCancelled(PointerEvent PointerEvent, DragDropOperation Operation)
        {
            var __pb = new ParamBuffer(120);
            __pb.Set<System.IntPtr>(0x0, PointerEvent);
            __pb.SetObject(0x70, Operation);
            CallRaw("OnDragCancelled", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8EA84 — hookable via Hooks.InstallAt(NativeFunc_OnAnimationStarted).</summary>
        public static System.IntPtr NativeFunc_OnAnimationStarted => Memory.ModuleBase() + 0x7E8EA84;
        public void OnAnimationStarted(WidgetAnimation Animation)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Animation);
            CallRaw("OnAnimationStarted", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8E9D8 — hookable via Hooks.InstallAt(NativeFunc_OnAnimationFinished).</summary>
        public static System.IntPtr NativeFunc_OnAnimationFinished => Memory.ModuleBase() + 0x7E8E9D8;
        public void OnAnimationFinished(WidgetAnimation Animation)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Animation);
            CallRaw("OnAnimationFinished", __pb.Bytes);
        }
        public EventReply OnAnalogValueChanged(Geometry MyGeometry, AnalogInputEvent InAnalogInputEvent)
        {
            var __pb = new ParamBuffer(304);
            __pb.Set<System.IntPtr>(0x0, MyGeometry);
            __pb.Set<System.IntPtr>(0x38, InAnalogInputEvent);
            CallRaw("OnAnalogValueChanged", __pb.Bytes);
            return __pb.Get<EventReply>(0x78);
        }
        public void OnAddedToFocusPath(FocusEvent InFocusEvent)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InFocusEvent);
            CallRaw("OnAddedToFocusPath", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8D7BC — hookable via Hooks.InstallAt(NativeFunc_ListenForInputAction).</summary>
        public static System.IntPtr NativeFunc_ListenForInputAction => Memory.ModuleBase() + 0x7E8D7BC;
        public void ListenForInputAction(FName ActionName, byte EventType, bool bConsume, System.IntPtr Callback)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set(0x0, ActionName);
            __pb.Set(0x8, EventType);
            __pb.Set<byte>(0x9, (byte)(bConsume?1:0));
            __pb.Set<System.IntPtr>(0xC, Callback);
            CallRaw("ListenForInputAction", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8D93C — hookable via Hooks.InstallAt(NativeFunc_IsPlayingAnimation).</summary>
        public static System.IntPtr NativeFunc_IsPlayingAnimation => Memory.ModuleBase() + 0x7E8D93C;
        public bool IsPlayingAnimation()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPlayingAnimation", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E8D5E8 — hookable via Hooks.InstallAt(NativeFunc_IsListeningForInputAction).</summary>
        public static System.IntPtr NativeFunc_IsListeningForInputAction => Memory.ModuleBase() + 0x7E8D5E8;
        public bool IsListeningForInputAction(FName ActionName)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, ActionName);
            CallRaw("IsListeningForInputAction", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E8F2B0 — hookable via Hooks.InstallAt(NativeFunc_IsInViewport).</summary>
        public static System.IntPtr NativeFunc_IsInViewport => Memory.ModuleBase() + 0x7E8F2B0;
        public bool IsInViewport()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsInViewport", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public bool IsInteractable()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsInteractable", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E8DD28 — hookable via Hooks.InstallAt(NativeFunc_IsAnyAnimationPlaying).</summary>
        public static System.IntPtr NativeFunc_IsAnyAnimationPlaying => Memory.ModuleBase() + 0x7E8DD28;
        public bool IsAnyAnimationPlaying()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsAnyAnimationPlaying", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E8DA04 — hookable via Hooks.InstallAt(NativeFunc_IsAnimationPlayingForward).</summary>
        public static System.IntPtr NativeFunc_IsAnimationPlayingForward => Memory.ModuleBase() + 0x7E8DA04;
        public bool IsAnimationPlayingForward(WidgetAnimation InAnimation)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, InAnimation);
            CallRaw("IsAnimationPlayingForward", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E8DD60 — hookable via Hooks.InstallAt(NativeFunc_IsAnimationPlaying).</summary>
        public static System.IntPtr NativeFunc_IsAnimationPlaying => Memory.ModuleBase() + 0x7E8DD60;
        public bool IsAnimationPlaying(WidgetAnimation InAnimation)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, InAnimation);
            CallRaw("IsAnimationPlaying", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E8F1D8 — hookable via Hooks.InstallAt(NativeFunc_GetOwningPlayerPawn).</summary>
        public static System.IntPtr NativeFunc_GetOwningPlayerPawn => Memory.ModuleBase() + 0x7E8F1D8;
        public Pawn GetOwningPlayerPawn()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetOwningPlayerPawn", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Pawn(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E8F2E8 — hookable via Hooks.InstallAt(NativeFunc_GetIsVisible).</summary>
        public static System.IntPtr NativeFunc_GetIsVisible => Memory.ModuleBase() + 0x7E8F2E8;
        public bool GetIsVisible()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetIsVisible", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E8DE10 — hookable via Hooks.InstallAt(NativeFunc_GetAnimationCurrentTime).</summary>
        public static System.IntPtr NativeFunc_GetAnimationCurrentTime => Memory.ModuleBase() + 0x7E8DE10;
        public float GetAnimationCurrentTime(WidgetAnimation InAnimation)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, InAnimation);
            CallRaw("GetAnimationCurrentTime", __pb.Bytes);
            return __pb.Get<float>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7E8F354 — hookable via Hooks.InstallAt(NativeFunc_GetAnchorsInViewport).</summary>
        public static System.IntPtr NativeFunc_GetAnchorsInViewport => Memory.ModuleBase() + 0x7E8F354;
        public Anchors GetAnchorsInViewport()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAnchorsInViewport", __pb.Bytes);
            return __pb.Get<Anchors>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E8F320 — hookable via Hooks.InstallAt(NativeFunc_GetAlignmentInViewport).</summary>
        public static System.IntPtr NativeFunc_GetAlignmentInViewport => Memory.ModuleBase() + 0x7E8F320;
        public Vector2D GetAlignmentInViewport()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetAlignmentInViewport", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
        public void Destruct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Destruct", __pb.Bytes);
        }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F1C4 — hookable via Hooks.InstallAt(NativeFunc_CancelLatentActions).</summary>
        public static System.IntPtr NativeFunc_CancelLatentActions => Memory.ModuleBase() + 0x7E8F1C4;
        public void CancelLatentActions()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CancelLatentActions", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F0C0 — hookable via Hooks.InstallAt(NativeFunc_BindToAnimationStarted).</summary>
        public static System.IntPtr NativeFunc_BindToAnimationStarted => Memory.ModuleBase() + 0x7E8F0C0;
        public void BindToAnimationStarted(WidgetAnimation Animation, System.IntPtr Delegate)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Animation);
            __pb.Set<System.IntPtr>(0x8, Delegate);
            CallRaw("BindToAnimationStarted", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8EE3C — hookable via Hooks.InstallAt(NativeFunc_BindToAnimationFinished).</summary>
        public static System.IntPtr NativeFunc_BindToAnimationFinished => Memory.ModuleBase() + 0x7E8EE3C;
        public void BindToAnimationFinished(WidgetAnimation Animation, System.IntPtr Delegate)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Animation);
            __pb.Set<System.IntPtr>(0x8, Delegate);
            CallRaw("BindToAnimationFinished", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8EB30 — hookable via Hooks.InstallAt(NativeFunc_BindToAnimationEvent).</summary>
        public static System.IntPtr NativeFunc_BindToAnimationEvent => Memory.ModuleBase() + 0x7E8EB30;
        public void BindToAnimationEvent(WidgetAnimation Animation, System.IntPtr Delegate, EWidgetAnimationEvent AnimationEvent, FName UserTag)
        {
            var __pb = new ParamBuffer(36);
            __pb.SetObject(0x0, Animation);
            __pb.Set<System.IntPtr>(0x8, Delegate);
            __pb.Set<byte>(0x18, (byte)AnimationEvent);
            __pb.Set(0x1C, UserTag);
            CallRaw("BindToAnimationEvent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F724 — hookable via Hooks.InstallAt(NativeFunc_AddToViewport).</summary>
        public static System.IntPtr NativeFunc_AddToViewport => Memory.ModuleBase() + 0x7E8F724;
        public void AddToViewport(int ZOrder)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ZOrder);
            CallRaw("AddToViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8F674 — hookable via Hooks.InstallAt(NativeFunc_AddToPlayerScreen).</summary>
        public static System.IntPtr NativeFunc_AddToPlayerScreen => Memory.ModuleBase() + 0x7E8F674;
        public bool AddToPlayerScreen(int ZOrder)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, ZOrder);
            CallRaw("AddToPlayerScreen", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
    }

    public class WidgetComponent : MeshComponent
    {
        public const string UeClassName = "WidgetComponent";
        public WidgetComponent(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetComponent(p);
        public static WidgetComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetComponent(o.Pointer); }
        public static WidgetComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetComponent(a[i].Pointer); return r; }
        public EWidgetSpace Space { get => (EWidgetSpace)GetAt<byte>(0x429); set => SetAt(0x429, (byte)value); }
        public EWidgetTimingPolicy TimingPolicy { get => (EWidgetTimingPolicy)GetAt<byte>(0x42A); set => SetAt(0x42A, (byte)value); }
        public UserWidget WidgetClass { get { var __p = GetAt<System.IntPtr>(0x430); return __p==System.IntPtr.Zero?null:new UserWidget(__p); } set => SetAt(0x430, value?.Pointer ?? System.IntPtr.Zero); }
        public IntPoint DrawSize => new IntPoint(AddrOf(0x438));
        public bool bManuallyRedraw { get => Native.GetPropBool(Pointer, "bManuallyRedraw"); set => Native.SetPropBool(Pointer, "bManuallyRedraw", value); }
        public bool bRedrawRequested { get => Native.GetPropBool(Pointer, "bRedrawRequested"); set => Native.SetPropBool(Pointer, "bRedrawRequested", value); }
        public float RedrawTime { get => GetAt<float>(0x444); set => SetAt(0x444, value); }
        public IntPoint CurrentDrawSize => new IntPoint(AddrOf(0x450));
        public bool bDrawAtDesiredSize { get => Native.GetPropBool(Pointer, "bDrawAtDesiredSize"); set => Native.SetPropBool(Pointer, "bDrawAtDesiredSize", value); }
        public Vector2D Pivot => new Vector2D(AddrOf(0x45C));
        public bool bReceiveHardwareInput { get => Native.GetPropBool(Pointer, "bReceiveHardwareInput"); set => Native.SetPropBool(Pointer, "bReceiveHardwareInput", value); }
        public bool bWindowFocusable { get => Native.GetPropBool(Pointer, "bWindowFocusable"); set => Native.SetPropBool(Pointer, "bWindowFocusable", value); }
        public EWindowVisibility WindowVisibility { get => (EWindowVisibility)GetAt<byte>(0x466); set => SetAt(0x466, (byte)value); }
        public bool bApplyGammaCorrection { get => Native.GetPropBool(Pointer, "bApplyGammaCorrection"); set => Native.SetPropBool(Pointer, "bApplyGammaCorrection", value); }
        public LocalPlayer OwnerPlayer { get { var __p = GetAt<System.IntPtr>(0x468); return __p==System.IntPtr.Zero?null:new LocalPlayer(__p); } set => SetAt(0x468, value?.Pointer ?? System.IntPtr.Zero); }
        public LinearColor BackgroundColor => new LinearColor(AddrOf(0x470));
        public LinearColor TintColorAndOpacity => new LinearColor(AddrOf(0x480));
        public float OpacityFromTexture { get => GetAt<float>(0x490); set => SetAt(0x490, value); }
        public EWidgetBlendMode BlendMode { get => (EWidgetBlendMode)GetAt<byte>(0x494); set => SetAt(0x494, (byte)value); }
        public bool bIsTwoSided { get => Native.GetPropBool(Pointer, "bIsTwoSided"); set => Native.SetPropBool(Pointer, "bIsTwoSided", value); }
        public bool TickWhenOffscreen { get => Native.GetPropBool(Pointer, "TickWhenOffscreen"); set => Native.SetPropBool(Pointer, "TickWhenOffscreen", value); }
        public UserWidget Widget { get { var __p = GetAt<System.IntPtr>(0x498); return __p==System.IntPtr.Zero?null:new UserWidget(__p); } set => SetAt(0x498, value?.Pointer ?? System.IntPtr.Zero); }
        public BodySetup BodySetup { get { var __p = GetAt<System.IntPtr>(0x4C0); return __p==System.IntPtr.Zero?null:new BodySetup(__p); } set => SetAt(0x4C0, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface TranslucentMaterial { get { var __p = GetAt<System.IntPtr>(0x4C8); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x4C8, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface TranslucentMaterial_OneSided { get { var __p = GetAt<System.IntPtr>(0x4D0); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x4D0, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface OpaqueMaterial { get { var __p = GetAt<System.IntPtr>(0x4D8); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x4D8, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface OpaqueMaterial_OneSided { get { var __p = GetAt<System.IntPtr>(0x4E0); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x4E0, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface MaskedMaterial { get { var __p = GetAt<System.IntPtr>(0x4E8); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x4E8, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInterface MaskedMaterial_OneSided { get { var __p = GetAt<System.IntPtr>(0x4F0); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x4F0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextureRenderTarget2D RenderTarget { get { var __p = GetAt<System.IntPtr>(0x4F8); return __p==System.IntPtr.Zero?null:new TextureRenderTarget2D(__p); } set => SetAt(0x4F8, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInstanceDynamic MaterialInstance { get { var __p = GetAt<System.IntPtr>(0x500); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x500, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bAddedToScreen { get => Native.GetPropBool(Pointer, "bAddedToScreen"); set => Native.SetPropBool(Pointer, "bAddedToScreen", value); }
        public bool bEditTimeUsable { get => Native.GetPropBool(Pointer, "bEditTimeUsable"); set => Native.SetPropBool(Pointer, "bEditTimeUsable", value); }
        public string SharedLayerName => Native.GetPropName(Pointer, "SharedLayerName"); // FName
        public FName SharedLayerName_Raw { get => GetAt<FName>(0x50C); set => SetAt(0x50C, value); }
        public int LayerZOrder { get => GetAt<int>(0x514); set => SetAt(0x514, value); }
        public EWidgetGeometryMode GeometryMode { get => (EWidgetGeometryMode)GetAt<byte>(0x518); set => SetAt(0x518, (byte)value); }
        public float CylinderArcAngle { get => GetAt<float>(0x51C); set => SetAt(0x51C, value); }
        /// <summary>[Native] thunk RVA 0x7EA86B4 — hookable via Hooks.InstallAt(NativeFunc_SetWindowVisibility).</summary>
        public static System.IntPtr NativeFunc_SetWindowVisibility => Memory.ModuleBase() + 0x7EA86B4;
        public void SetWindowVisibility(EWindowVisibility InVisibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InVisibility);
            CallRaw("SetWindowVisibility", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8774 — hookable via Hooks.InstallAt(NativeFunc_SetWindowFocusable).</summary>
        public static System.IntPtr NativeFunc_SetWindowFocusable => Memory.ModuleBase() + 0x7EA8774;
        public void SetWindowFocusable(bool bInWindowFocusable)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInWindowFocusable?1:0));
            CallRaw("SetWindowFocusable", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA89B4 — hookable via Hooks.InstallAt(NativeFunc_SetWidgetSpace).</summary>
        public static System.IntPtr NativeFunc_SetWidgetSpace => Memory.ModuleBase() + 0x7EA89B4;
        public void SetWidgetSpace(EWidgetSpace NewSpace)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)NewSpace);
            CallRaw("SetWidgetSpace", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA925C — hookable via Hooks.InstallAt(NativeFunc_SetWidget).</summary>
        public static System.IntPtr NativeFunc_SetWidget => Memory.ModuleBase() + 0x7EA925C;
        public void SetWidget(UserWidget Widget)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Widget);
            CallRaw("SetWidget", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8ED0 — hookable via Hooks.InstallAt(NativeFunc_SetTwoSided).</summary>
        public static System.IntPtr NativeFunc_SetTwoSided => Memory.ModuleBase() + 0x7EA8ED0;
        public void SetTwoSided(bool bWantTwoSided)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bWantTwoSided?1:0));
            CallRaw("SetTwoSided", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8CC4 — hookable via Hooks.InstallAt(NativeFunc_SetTintColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetTintColorAndOpacity => Memory.ModuleBase() + 0x7EA8CC4;
        public void SetTintColorAndOpacity(LinearColor NewTintColorAndOpacity)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewTintColorAndOpacity);
            CallRaw("SetTintColorAndOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8E0C — hookable via Hooks.InstallAt(NativeFunc_SetTickWhenOffscreen).</summary>
        public static System.IntPtr NativeFunc_SetTickWhenOffscreen => Memory.ModuleBase() + 0x7EA8E0C;
        public void SetTickWhenOffscreen(bool bWantTickWhenOffscreen)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bWantTickWhenOffscreen?1:0));
            CallRaw("SetTickWhenOffscreen", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8A70 — hookable via Hooks.InstallAt(NativeFunc_SetRedrawTime).</summary>
        public static System.IntPtr NativeFunc_SetRedrawTime => Memory.ModuleBase() + 0x7EA8A70;
        public void SetRedrawTime(float InRedrawTime)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InRedrawTime);
            CallRaw("SetRedrawTime", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8BF0 — hookable via Hooks.InstallAt(NativeFunc_SetPivot).</summary>
        public static System.IntPtr NativeFunc_SetPivot => Memory.ModuleBase() + 0x7EA8BF0;
        public void SetPivot(Vector2D InPivot)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InPivot);
            CallRaw("SetPivot", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA91B8 — hookable via Hooks.InstallAt(NativeFunc_SetOwnerPlayer).</summary>
        public static System.IntPtr NativeFunc_SetOwnerPlayer => Memory.ModuleBase() + 0x7EA91B8;
        public void SetOwnerPlayer(LocalPlayer LocalPlayer)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, LocalPlayer);
            CallRaw("SetOwnerPlayer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA90F0 — hookable via Hooks.InstallAt(NativeFunc_SetManuallyRedraw).</summary>
        public static System.IntPtr NativeFunc_SetManuallyRedraw => Memory.ModuleBase() + 0x7EA90F0;
        public void SetManuallyRedraw(bool bUseManualRedraw)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bUseManualRedraw?1:0));
            CallRaw("SetManuallyRedraw", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA88F8 — hookable via Hooks.InstallAt(NativeFunc_SetGeometryMode).</summary>
        public static System.IntPtr NativeFunc_SetGeometryMode => Memory.ModuleBase() + 0x7EA88F8;
        public void SetGeometryMode(EWidgetGeometryMode InGeometryMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InGeometryMode);
            CallRaw("SetGeometryMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8FB4 — hookable via Hooks.InstallAt(NativeFunc_SetDrawSize).</summary>
        public static System.IntPtr NativeFunc_SetDrawSize => Memory.ModuleBase() + 0x7EA8FB4;
        public void SetDrawSize(Vector2D Size)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, Size);
            CallRaw("SetDrawSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8B2C — hookable via Hooks.InstallAt(NativeFunc_SetDrawAtDesiredSize).</summary>
        public static System.IntPtr NativeFunc_SetDrawAtDesiredSize => Memory.ModuleBase() + 0x7EA8B2C;
        public void SetDrawAtDesiredSize(bool bInDrawAtDesiredSize)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInDrawAtDesiredSize?1:0));
            CallRaw("SetDrawAtDesiredSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA883C — hookable via Hooks.InstallAt(NativeFunc_SetCylinderArcAngle).</summary>
        public static System.IntPtr NativeFunc_SetCylinderArcAngle => Memory.ModuleBase() + 0x7EA883C;
        public void SetCylinderArcAngle(float InCylinderArcAngle)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InCylinderArcAngle);
            CallRaw("SetCylinderArcAngle", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8D68 — hookable via Hooks.InstallAt(NativeFunc_SetBackgroundColor).</summary>
        public static System.IntPtr NativeFunc_SetBackgroundColor => Memory.ModuleBase() + 0x7EA8D68;
        public void SetBackgroundColor(LinearColor NewBackgroundColor)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewBackgroundColor);
            CallRaw("SetBackgroundColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8F98 — hookable via Hooks.InstallAt(NativeFunc_RequestRedraw).</summary>
        public static System.IntPtr NativeFunc_RequestRedraw => Memory.ModuleBase() + 0x7EA8F98;
        public void RequestRedraw()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RequestRedraw", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA8758 — hookable via Hooks.InstallAt(NativeFunc_GetWindowVisiblility).</summary>
        public static System.IntPtr NativeFunc_GetWindowVisiblility => Memory.ModuleBase() + 0x7EA8758;
        public EWindowVisibility GetWindowVisiblility()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetWindowVisiblility", __pb.Bytes);
            return (EWindowVisibility)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA8820 — hookable via Hooks.InstallAt(NativeFunc_GetWindowFocusable).</summary>
        public static System.IntPtr NativeFunc_GetWindowFocusable => Memory.ModuleBase() + 0x7EA8820;
        public bool GetWindowFocusable()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetWindowFocusable", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EA8A54 — hookable via Hooks.InstallAt(NativeFunc_GetWidgetSpace).</summary>
        public static System.IntPtr NativeFunc_GetWidgetSpace => Memory.ModuleBase() + 0x7EA8A54;
        public EWidgetSpace GetWidgetSpace()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetWidgetSpace", __pb.Bytes);
            return (EWidgetSpace)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA9370 — hookable via Hooks.InstallAt(NativeFunc_GetUserWidgetObject).</summary>
        public static System.IntPtr NativeFunc_GetUserWidgetObject => Memory.ModuleBase() + 0x7EA9370;
        public UserWidget GetUserWidgetObject()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetUserWidgetObject", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new UserWidget(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA8F7C — hookable via Hooks.InstallAt(NativeFunc_GetTwoSided).</summary>
        public static System.IntPtr NativeFunc_GetTwoSided => Memory.ModuleBase() + 0x7EA8F7C;
        public bool GetTwoSided()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetTwoSided", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EA8EB4 — hookable via Hooks.InstallAt(NativeFunc_GetTickWhenOffscreen).</summary>
        public static System.IntPtr NativeFunc_GetTickWhenOffscreen => Memory.ModuleBase() + 0x7EA8EB4;
        public bool GetTickWhenOffscreen()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetTickWhenOffscreen", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EA933C — hookable via Hooks.InstallAt(NativeFunc_GetRenderTarget).</summary>
        public static System.IntPtr NativeFunc_GetRenderTarget => Memory.ModuleBase() + 0x7EA933C;
        public TextureRenderTarget2D GetRenderTarget()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetRenderTarget", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new TextureRenderTarget2D(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA8B10 — hookable via Hooks.InstallAt(NativeFunc_GetRedrawTime).</summary>
        public static System.IntPtr NativeFunc_GetRedrawTime => Memory.ModuleBase() + 0x7EA8B10;
        public float GetRedrawTime()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetRedrawTime", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA8CA4 — hookable via Hooks.InstallAt(NativeFunc_GetPivot).</summary>
        public static System.IntPtr NativeFunc_GetPivot => Memory.ModuleBase() + 0x7EA8CA4;
        public Vector2D GetPivot()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetPivot", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA90BC — hookable via Hooks.InstallAt(NativeFunc_GetOwnerPlayer).</summary>
        public static System.IntPtr NativeFunc_GetOwnerPlayer => Memory.ModuleBase() + 0x7EA90BC;
        public LocalPlayer GetOwnerPlayer()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetOwnerPlayer", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new LocalPlayer(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA9308 — hookable via Hooks.InstallAt(NativeFunc_GetMaterialInstance).</summary>
        public static System.IntPtr NativeFunc_GetMaterialInstance => Memory.ModuleBase() + 0x7EA9308;
        public MaterialInstanceDynamic GetMaterialInstance()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetMaterialInstance", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA919C — hookable via Hooks.InstallAt(NativeFunc_GetManuallyRedraw).</summary>
        public static System.IntPtr NativeFunc_GetManuallyRedraw => Memory.ModuleBase() + 0x7EA919C;
        public bool GetManuallyRedraw()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetManuallyRedraw", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EA8998 — hookable via Hooks.InstallAt(NativeFunc_GetGeometryMode).</summary>
        public static System.IntPtr NativeFunc_GetGeometryMode => Memory.ModuleBase() + 0x7EA8998;
        public EWidgetGeometryMode GetGeometryMode()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetGeometryMode", __pb.Bytes);
            return (EWidgetGeometryMode)__pb.Get<byte>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA9088 — hookable via Hooks.InstallAt(NativeFunc_GetDrawSize).</summary>
        public static System.IntPtr NativeFunc_GetDrawSize => Memory.ModuleBase() + 0x7EA9088;
        public Vector2D GetDrawSize()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDrawSize", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA8BD4 — hookable via Hooks.InstallAt(NativeFunc_GetDrawAtDesiredSize).</summary>
        public static System.IntPtr NativeFunc_GetDrawAtDesiredSize => Memory.ModuleBase() + 0x7EA8BD4;
        public bool GetDrawAtDesiredSize()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetDrawAtDesiredSize", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EA88DC — hookable via Hooks.InstallAt(NativeFunc_GetCylinderArcAngle).</summary>
        public static System.IntPtr NativeFunc_GetCylinderArcAngle => Memory.ModuleBase() + 0x7EA88DC;
        public float GetCylinderArcAngle()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetCylinderArcAngle", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA9054 — hookable via Hooks.InstallAt(NativeFunc_GetCurrentDrawSize).</summary>
        public static System.IntPtr NativeFunc_GetCurrentDrawSize => Memory.ModuleBase() + 0x7EA9054;
        public Vector2D GetCurrentDrawSize()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetCurrentDrawSize", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
    }

    public class AsyncTaskDownloadImage : BlueprintAsyncActionBase
    {
        public const string UeClassName = "AsyncTaskDownloadImage";
        public AsyncTaskDownloadImage(System.IntPtr ptr) : base(ptr) {}
        public static new AsyncTaskDownloadImage FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AsyncTaskDownloadImage(p);
        public static AsyncTaskDownloadImage FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AsyncTaskDownloadImage(o.Pointer); }
        public static AsyncTaskDownloadImage[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AsyncTaskDownloadImage[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AsyncTaskDownloadImage(a[i].Pointer); return r; }
        public System.IntPtr OnSuccess => AddrOf(0x30); // 
        public System.IntPtr OnFail => AddrOf(0x40); // 
        /// <summary>[Native] thunk RVA 0x7E4710C — hookable via Hooks.InstallAt(NativeFunc_DownloadImage).</summary>
        public static System.IntPtr NativeFunc_DownloadImage => Memory.ModuleBase() + 0x7E4710C;
        public AsyncTaskDownloadImage DownloadImage(System.IntPtr URL)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, URL);
            CallRaw("DownloadImage", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new AsyncTaskDownloadImage(__p); }
        }
    }

    public class PanelWidget : Widget
    {
        public const string UeClassName = "PanelWidget";
        public PanelWidget(System.IntPtr ptr) : base(ptr) {}
        public static new PanelWidget FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PanelWidget(p);
        public static PanelWidget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PanelWidget(o.Pointer); }
        public static PanelWidget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PanelWidget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PanelWidget(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Slots => new TArray<System.IntPtr>(AddrOf(0x108)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x7E72468 — hookable via Hooks.InstallAt(NativeFunc_RemoveChildAt).</summary>
        public static System.IntPtr NativeFunc_RemoveChildAt => Memory.ModuleBase() + 0x7E72468;
        public bool RemoveChildAt(int Index)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Index);
            CallRaw("RemoveChildAt", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E7230C — hookable via Hooks.InstallAt(NativeFunc_RemoveChild).</summary>
        public static System.IntPtr NativeFunc_RemoveChild => Memory.ModuleBase() + 0x7E7230C;
        public bool RemoveChild(Widget Content)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Content);
            CallRaw("RemoveChild", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E72518 — hookable via Hooks.InstallAt(NativeFunc_HasChild).</summary>
        public static System.IntPtr NativeFunc_HasChild => Memory.ModuleBase() + 0x7E72518;
        public bool HasChild(Widget Content)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Content);
            CallRaw("HasChild", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E722D4 — hookable via Hooks.InstallAt(NativeFunc_HasAnyChildren).</summary>
        public static System.IntPtr NativeFunc_HasAnyChildren => Memory.ModuleBase() + 0x7E722D4;
        public bool HasAnyChildren()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasAnyChildren", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E727D0 — hookable via Hooks.InstallAt(NativeFunc_GetChildrenCount).</summary>
        public static System.IntPtr NativeFunc_GetChildrenCount => Memory.ModuleBase() + 0x7E727D0;
        public int GetChildrenCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetChildrenCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E725C8 — hookable via Hooks.InstallAt(NativeFunc_GetChildIndex).</summary>
        public static System.IntPtr NativeFunc_GetChildIndex => Memory.ModuleBase() + 0x7E725C8;
        public int GetChildIndex(Widget Content)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, Content);
            CallRaw("GetChildIndex", __pb.Bytes);
            return __pb.Get<int>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7E72724 — hookable via Hooks.InstallAt(NativeFunc_GetChildAt).</summary>
        public static System.IntPtr NativeFunc_GetChildAt => Memory.ModuleBase() + 0x7E72724;
        public Widget GetChildAt(int Index)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Index);
            CallRaw("GetChildAt", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new Widget(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E72674 — hookable via Hooks.InstallAt(NativeFunc_GetAllChildren).</summary>
        public static System.IntPtr NativeFunc_GetAllChildren => Memory.ModuleBase() + 0x7E72674;
        public System.IntPtr GetAllChildren()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllChildren", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E722B8 — hookable via Hooks.InstallAt(NativeFunc_ClearChildren).</summary>
        public static System.IntPtr NativeFunc_ClearChildren => Memory.ModuleBase() + 0x7E722B8;
        public void ClearChildren()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearChildren", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E723BC — hookable via Hooks.InstallAt(NativeFunc_AddChild).</summary>
        public static System.IntPtr NativeFunc_AddChild => Memory.ModuleBase() + 0x7E723BC;
        public PanelSlot AddChild(Widget Content)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Content);
            CallRaw("AddChild", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new PanelSlot(__p); }
        }
    }

    public class ContentWidget : PanelWidget
    {
        public const string UeClassName = "ContentWidget";
        public ContentWidget(System.IntPtr ptr) : base(ptr) {}
        public static new ContentWidget FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ContentWidget(p);
        public static ContentWidget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ContentWidget(o.Pointer); }
        public static ContentWidget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ContentWidget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ContentWidget(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E545C4 — hookable via Hooks.InstallAt(NativeFunc_SetContent).</summary>
        public static System.IntPtr NativeFunc_SetContent => Memory.ModuleBase() + 0x7E545C4;
        public PanelSlot SetContent(Widget Content)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Content);
            CallRaw("SetContent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new PanelSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E54670 — hookable via Hooks.InstallAt(NativeFunc_GetContentSlot).</summary>
        public static System.IntPtr NativeFunc_GetContentSlot => Memory.ModuleBase() + 0x7E54670;
        public PanelSlot GetContentSlot()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetContentSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new PanelSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E54590 — hookable via Hooks.InstallAt(NativeFunc_GetContent).</summary>
        public static System.IntPtr NativeFunc_GetContent => Memory.ModuleBase() + 0x7E54590;
        public Widget GetContent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetContent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Widget(__p); }
        }
    }

    public class BackgroundBlur : ContentWidget
    {
        public const string UeClassName = "BackgroundBlur";
        public BackgroundBlur(System.IntPtr ptr) : base(ptr) {}
        public static new BackgroundBlur FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BackgroundBlur(p);
        public static BackgroundBlur FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BackgroundBlur(o.Pointer); }
        public static BackgroundBlur[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BackgroundBlur[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BackgroundBlur(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x11C));
        public byte HorizontalAlignment { get => GetAt<byte>(0x12C); set => SetAt(0x12C, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x12D); set => SetAt(0x12D, value); }
        public bool bApplyAlphaToBlur { get => Native.GetPropBool(Pointer, "bApplyAlphaToBlur"); set => Native.SetPropBool(Pointer, "bApplyAlphaToBlur", value); }
        public float BlurStrength { get => GetAt<float>(0x130); set => SetAt(0x130, value); }
        public bool bOverrideAutoRadiusCalculation { get => Native.GetPropBool(Pointer, "bOverrideAutoRadiusCalculation"); set => Native.SetPropBool(Pointer, "bOverrideAutoRadiusCalculation", value); }
        public int BlurRadius { get => GetAt<int>(0x138); set => SetAt(0x138, value); }
        public SlateBrush LowQualityFallbackBrush => new SlateBrush(AddrOf(0x140));
        /// <summary>[Native] thunk RVA 0x7E47D78 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E47D78;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E47EC0 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E47EC0;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E479A0 — hookable via Hooks.InstallAt(NativeFunc_SetLowQualityFallbackBrush).</summary>
        public static System.IntPtr NativeFunc_SetLowQualityFallbackBrush => Memory.ModuleBase() + 0x7E479A0;
        public void SetLowQualityFallbackBrush(SlateBrush InBrush)
        {
            var __pb = new ParamBuffer(136);
            __pb.Set<System.IntPtr>(0x0, InBrush);
            CallRaw("SetLowQualityFallbackBrush", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E47E1C — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E47E1C;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E47B7C — hookable via Hooks.InstallAt(NativeFunc_SetBlurStrength).</summary>
        public static System.IntPtr NativeFunc_SetBlurStrength => Memory.ModuleBase() + 0x7E47B7C;
        public void SetBlurStrength(float InStrength)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InStrength);
            CallRaw("SetBlurStrength", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E47C28 — hookable via Hooks.InstallAt(NativeFunc_SetBlurRadius).</summary>
        public static System.IntPtr NativeFunc_SetBlurRadius => Memory.ModuleBase() + 0x7E47C28;
        public void SetBlurRadius(int InBlurRadius)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InBlurRadius);
            CallRaw("SetBlurRadius", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E47CCC — hookable via Hooks.InstallAt(NativeFunc_SetApplyAlphaToBlur).</summary>
        public static System.IntPtr NativeFunc_SetApplyAlphaToBlur => Memory.ModuleBase() + 0x7E47CCC;
        public void SetApplyAlphaToBlur(bool bInApplyAlphaToBlur)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInApplyAlphaToBlur?1:0));
            CallRaw("SetApplyAlphaToBlur", __pb.Bytes);
        }
    }

    public class PanelSlot : Visual
    {
        public const string UeClassName = "PanelSlot";
        public PanelSlot(System.IntPtr ptr) : base(ptr) {}
        public static new PanelSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PanelSlot(p);
        public static PanelSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PanelSlot(o.Pointer); }
        public static PanelSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PanelSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PanelSlot(a[i].Pointer); return r; }
        public PanelWidget Parent { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new PanelWidget(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public Widget Content { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new Widget(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class BackgroundBlurSlot : PanelSlot
    {
        public const string UeClassName = "BackgroundBlurSlot";
        public BackgroundBlurSlot(System.IntPtr ptr) : base(ptr) {}
        public static new BackgroundBlurSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BackgroundBlurSlot(p);
        public static BackgroundBlurSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BackgroundBlurSlot(o.Pointer); }
        public static BackgroundBlurSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BackgroundBlurSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BackgroundBlurSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x38));
        public byte HorizontalAlignment { get => GetAt<byte>(0x48); set => SetAt(0x48, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x49); set => SetAt(0x49, value); }
        /// <summary>[Native] thunk RVA 0x7E48C44 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E48C44;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E48D8C — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E48D8C;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E48CE8 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E48CE8;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class PropertyBinding : Object
    {
        public const string UeClassName = "PropertyBinding";
        public PropertyBinding(System.IntPtr ptr) : base(ptr) {}
        public static new PropertyBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PropertyBinding(p);
        public static PropertyBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropertyBinding(o.Pointer); }
        public static PropertyBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropertyBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropertyBinding(a[i].Pointer); return r; }
        public Object SourceObject { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public DynamicPropertyPath SourcePath => new DynamicPropertyPath(AddrOf(0x30));
        public string DestinationProperty => Native.GetPropName(Pointer, "DestinationProperty"); // FName
        public FName DestinationProperty_Raw { get => GetAt<FName>(0x58); set => SetAt(0x58, value); }
    }

    public class BoolBinding : PropertyBinding
    {
        public const string UeClassName = "BoolBinding";
        public BoolBinding(System.IntPtr ptr) : base(ptr) {}
        public static new BoolBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BoolBinding(p);
        public static BoolBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BoolBinding(o.Pointer); }
        public static BoolBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BoolBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BoolBinding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E4966C — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7E4966C;
        public bool GetValue()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetValue", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class Border : ContentWidget
    {
        public const string UeClassName = "Border";
        public Border(System.IntPtr ptr) : base(ptr) {}
        public static new Border FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Border(p);
        public static Border FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Border(o.Pointer); }
        public static Border[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Border[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Border(a[i].Pointer); return r; }
        public byte HorizontalAlignment { get => GetAt<byte>(0x119); set => SetAt(0x119, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x11A); set => SetAt(0x11A, value); }
        public bool bShowEffectWhenDisabled { get => Native.GetPropBool(Pointer, "bShowEffectWhenDisabled"); set => Native.SetPropBool(Pointer, "bShowEffectWhenDisabled", value); }
        public LinearColor ContentColorAndOpacity => new LinearColor(AddrOf(0x11C));
        public System.IntPtr ContentColorAndOpacityDelegate => AddrOf(0x12C); // 
        public Margin Padding => new Margin(AddrOf(0x13C));
        public SlateBrush background => new SlateBrush(AddrOf(0x150));
        public System.IntPtr BackgroundDelegate => AddrOf(0x1D8); // 
        public LinearColor BrushColor => new LinearColor(AddrOf(0x1E8));
        public System.IntPtr BrushColorDelegate => AddrOf(0x1F8); // 
        public Vector2D DesiredSizeScale => new Vector2D(AddrOf(0x208));
        public bool bFlipForRightToLeftFlowDirection { get => Native.GetPropBool(Pointer, "bFlipForRightToLeftFlowDirection"); set => Native.SetPropBool(Pointer, "bFlipForRightToLeftFlowDirection", value); }
        public System.IntPtr OnMouseButtonDownEvent => AddrOf(0x214); // 
        public System.IntPtr OnMouseButtonUpEvent => AddrOf(0x224); // 
        public System.IntPtr OnMouseMoveEvent => AddrOf(0x234); // 
        public System.IntPtr OnMouseDoubleClickEvent => AddrOf(0x244); // 
        /// <summary>[Native] thunk RVA 0x7E4A384 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E4A384;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4A4CC — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E4A4CC;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4A428 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E4A428;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E49E44 — hookable via Hooks.InstallAt(NativeFunc_SetDesiredSizeScale).</summary>
        public static System.IntPtr NativeFunc_SetDesiredSizeScale => Memory.ModuleBase() + 0x7E49E44;
        public void SetDesiredSizeScale(Vector2D InScale)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InScale);
            CallRaw("SetDesiredSizeScale", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4A574 — hookable via Hooks.InstallAt(NativeFunc_SetContentColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetContentColorAndOpacity => Memory.ModuleBase() + 0x7E4A574;
        public void SetContentColorAndOpacity(LinearColor InContentColorAndOpacity)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InContentColorAndOpacity);
            CallRaw("SetContentColorAndOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E49FBC — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromTexture).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromTexture => Memory.ModuleBase() + 0x7E49FBC;
        public void SetBrushFromTexture(Texture2D Texture)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Texture);
            CallRaw("SetBrushFromTexture", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E49F18 — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromMaterial).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromMaterial => Memory.ModuleBase() + 0x7E49F18;
        public void SetBrushFromMaterial(MaterialInterface Material)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Material);
            CallRaw("SetBrushFromMaterial", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4A060 — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromAsset).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromAsset => Memory.ModuleBase() + 0x7E4A060;
        public void SetBrushFromAsset(SlateBrushAsset Asset)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Asset);
            CallRaw("SetBrushFromAsset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4A2E0 — hookable via Hooks.InstallAt(NativeFunc_SetBrushColor).</summary>
        public static System.IntPtr NativeFunc_SetBrushColor => Memory.ModuleBase() + 0x7E4A2E0;
        public void SetBrushColor(LinearColor InBrushColor)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InBrushColor);
            CallRaw("SetBrushColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4A104 — hookable via Hooks.InstallAt(NativeFunc_SetBrush).</summary>
        public static System.IntPtr NativeFunc_SetBrush => Memory.ModuleBase() + 0x7E4A104;
        public void SetBrush(SlateBrush InBrush)
        {
            var __pb = new ParamBuffer(136);
            __pb.Set<System.IntPtr>(0x0, InBrush);
            CallRaw("SetBrush", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E49EE4 — hookable via Hooks.InstallAt(NativeFunc_GetDynamicMaterial).</summary>
        public static System.IntPtr NativeFunc_GetDynamicMaterial => Memory.ModuleBase() + 0x7E49EE4;
        public MaterialInstanceDynamic GetDynamicMaterial()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDynamicMaterial", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); }
        }
    }

    public class BorderSlot : PanelSlot
    {
        public const string UeClassName = "BorderSlot";
        public BorderSlot(System.IntPtr ptr) : base(ptr) {}
        public static new BorderSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BorderSlot(p);
        public static BorderSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BorderSlot(o.Pointer); }
        public static BorderSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BorderSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BorderSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x38));
        public byte HorizontalAlignment { get => GetAt<byte>(0x48); set => SetAt(0x48, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x49); set => SetAt(0x49, value); }
        /// <summary>[Native] thunk RVA 0x7E4B21C — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E4B21C;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4B364 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E4B364;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4B2C0 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E4B2C0;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class BrushBinding : PropertyBinding
    {
        public const string UeClassName = "BrushBinding";
        public BrushBinding(System.IntPtr ptr) : base(ptr) {}
        public static new BrushBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BrushBinding(p);
        public static BrushBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BrushBinding(o.Pointer); }
        public static BrushBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BrushBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BrushBinding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E4BC40 — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7E4BC40;
        public SlateBrush GetValue()
        {
            var __pb = new ParamBuffer(136);
            CallRaw("GetValue", __pb.Bytes);
            return __pb.Get<SlateBrush>(0x0);
        }
    }

    public class Button : ContentWidget
    {
        public const string UeClassName = "Button";
        public Button(System.IntPtr ptr) : base(ptr) {}
        public static new Button FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Button(p);
        public static Button FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Button(o.Pointer); }
        public static Button[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Button[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Button(a[i].Pointer); return r; }
        public SlateWidgetStyleAsset Style { get { var __p = GetAt<System.IntPtr>(0x120); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0x120, value?.Pointer ?? System.IntPtr.Zero); }
        public ButtonStyle WidgetStyle => new ButtonStyle(AddrOf(0x128));
        public LinearColor ColorAndOpacity => new LinearColor(AddrOf(0x3A0));
        public LinearColor BackgroundColor => new LinearColor(AddrOf(0x3B0));
        public byte ClickMethod { get => GetAt<byte>(0x3C0); set => SetAt(0x3C0, value); }
        public byte TouchMethod { get => GetAt<byte>(0x3C1); set => SetAt(0x3C1, value); }
        public byte PressMethod { get => GetAt<byte>(0x3C2); set => SetAt(0x3C2, value); }
        public bool IsFocusable { get => Native.GetPropBool(Pointer, "IsFocusable"); set => Native.SetPropBool(Pointer, "IsFocusable", value); }
        public System.IntPtr OnClicked => AddrOf(0x3C8); // 
        public System.IntPtr OnPressed => AddrOf(0x3D8); // 
        public System.IntPtr OnReleased => AddrOf(0x3E8); // 
        public System.IntPtr OnHovered => AddrOf(0x3F8); // 
        public System.IntPtr OnUnhovered => AddrOf(0x408); // 
        /// <summary>[Native] thunk RVA 0x7E4C6E8 — hookable via Hooks.InstallAt(NativeFunc_SetTouchMethod).</summary>
        public static System.IntPtr NativeFunc_SetTouchMethod => Memory.ModuleBase() + 0x7E4C6E8;
        public void SetTouchMethod(byte InTouchMethod)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InTouchMethod);
            CallRaw("SetTouchMethod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4C9B0 — hookable via Hooks.InstallAt(NativeFunc_SetStyle).</summary>
        public static System.IntPtr NativeFunc_SetStyle => Memory.ModuleBase() + 0x7E4C9B0;
        public void SetStyle(ButtonStyle InStyle)
        {
            var __pb = new ParamBuffer(632);
            __pb.Set<System.IntPtr>(0x0, InStyle);
            CallRaw("SetStyle", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4C644 — hookable via Hooks.InstallAt(NativeFunc_SetPressMethod).</summary>
        public static System.IntPtr NativeFunc_SetPressMethod => Memory.ModuleBase() + 0x7E4C644;
        public void SetPressMethod(byte InPressMethod)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InPressMethod);
            CallRaw("SetPressMethod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4C90C — hookable via Hooks.InstallAt(NativeFunc_SetColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetColorAndOpacity => Memory.ModuleBase() + 0x7E4C90C;
        public void SetColorAndOpacity(LinearColor InColorAndOpacity)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InColorAndOpacity);
            CallRaw("SetColorAndOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4C78C — hookable via Hooks.InstallAt(NativeFunc_SetClickMethod).</summary>
        public static System.IntPtr NativeFunc_SetClickMethod => Memory.ModuleBase() + 0x7E4C78C;
        public void SetClickMethod(byte InClickMethod)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InClickMethod);
            CallRaw("SetClickMethod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4C868 — hookable via Hooks.InstallAt(NativeFunc_SetBackgroundColor).</summary>
        public static System.IntPtr NativeFunc_SetBackgroundColor => Memory.ModuleBase() + 0x7E4C868;
        public void SetBackgroundColor(LinearColor InBackgroundColor)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InBackgroundColor);
            CallRaw("SetBackgroundColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4C830 — hookable via Hooks.InstallAt(NativeFunc_IsPressed).</summary>
        public static System.IntPtr NativeFunc_IsPressed => Memory.ModuleBase() + 0x7E4C830;
        public bool IsPressed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPressed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class ButtonSlot : PanelSlot
    {
        public const string UeClassName = "ButtonSlot";
        public ButtonSlot(System.IntPtr ptr) : base(ptr) {}
        public static new ButtonSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ButtonSlot(p);
        public static ButtonSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ButtonSlot(o.Pointer); }
        public static ButtonSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ButtonSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ButtonSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x38));
        public byte HorizontalAlignment { get => GetAt<byte>(0x48); set => SetAt(0x48, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x49); set => SetAt(0x49, value); }
        /// <summary>[Native] thunk RVA 0x7E4D440 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E4D440;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4D588 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E4D588;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4D4E4 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E4D4E4;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class CanvasPanel : PanelWidget
    {
        public const string UeClassName = "CanvasPanel";
        public CanvasPanel(System.IntPtr ptr) : base(ptr) {}
        public static new CanvasPanel FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CanvasPanel(p);
        public static CanvasPanel FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CanvasPanel(o.Pointer); }
        public static CanvasPanel[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CanvasPanel[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CanvasPanel(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E4DE64 — hookable via Hooks.InstallAt(NativeFunc_AddChildToCanvas).</summary>
        public static System.IntPtr NativeFunc_AddChildToCanvas => Memory.ModuleBase() + 0x7E4DE64;
        public CanvasPanelSlot AddChildToCanvas(Widget Content)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Content);
            CallRaw("AddChildToCanvas", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new CanvasPanelSlot(__p); }
        }
    }

    public class CanvasPanelSlot : PanelSlot
    {
        public const string UeClassName = "CanvasPanelSlot";
        public CanvasPanelSlot(System.IntPtr ptr) : base(ptr) {}
        public static new CanvasPanelSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CanvasPanelSlot(p);
        public static CanvasPanelSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CanvasPanelSlot(o.Pointer); }
        public static CanvasPanelSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CanvasPanelSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CanvasPanelSlot(a[i].Pointer); return r; }
        public AnchorData LayoutData => new AnchorData(AddrOf(0x38));
        public bool bAutoSize { get => Native.GetPropBool(Pointer, "bAutoSize"); set => Native.SetPropBool(Pointer, "bAutoSize", value); }
        public int ZOrder { get => GetAt<int>(0x64); set => SetAt(0x64, value); }
        /// <summary>[Native] thunk RVA 0x7E4E9A4 — hookable via Hooks.InstallAt(NativeFunc_SetZOrder).</summary>
        public static System.IntPtr NativeFunc_SetZOrder => Memory.ModuleBase() + 0x7E4E9A4;
        public void SetZOrder(int InZOrder)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InZOrder);
            CallRaw("SetZOrder", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4EDF4 — hookable via Hooks.InstallAt(NativeFunc_SetSize).</summary>
        public static System.IntPtr NativeFunc_SetSize => Memory.ModuleBase() + 0x7E4EDF4;
        public void SetSize(Vector2D InSize)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InSize);
            CallRaw("SetSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4EEC8 — hookable via Hooks.InstallAt(NativeFunc_SetPosition).</summary>
        public static System.IntPtr NativeFunc_SetPosition => Memory.ModuleBase() + 0x7E4EEC8;
        public void SetPosition(Vector2D InPosition)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InPosition);
            CallRaw("SetPosition", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4ED18 — hookable via Hooks.InstallAt(NativeFunc_SetOffsets).</summary>
        public static System.IntPtr NativeFunc_SetOffsets => Memory.ModuleBase() + 0x7E4ED18;
        public void SetOffsets(Margin InOffset)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InOffset);
            CallRaw("SetOffsets", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4E8D0 — hookable via Hooks.InstallAt(NativeFunc_SetMinimum).</summary>
        public static System.IntPtr NativeFunc_SetMinimum => Memory.ModuleBase() + 0x7E4E8D0;
        public void SetMinimum(Vector2D InMinimumAnchors)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InMinimumAnchors);
            CallRaw("SetMinimum", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4E830 — hookable via Hooks.InstallAt(NativeFunc_SetMaximum).</summary>
        public static System.IntPtr NativeFunc_SetMaximum => Memory.ModuleBase() + 0x7E4E830;
        public void SetMaximum(Vector2D InMaximumAnchors)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InMaximumAnchors);
            CallRaw("SetMaximum", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4EFD4 — hookable via Hooks.InstallAt(NativeFunc_SetLayout).</summary>
        public static System.IntPtr NativeFunc_SetLayout => Memory.ModuleBase() + 0x7E4EFD4;
        public void SetLayout(AnchorData InLayoutData)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, InLayoutData);
            CallRaw("SetLayout", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4EA80 — hookable via Hooks.InstallAt(NativeFunc_SetAutoSize).</summary>
        public static System.IntPtr NativeFunc_SetAutoSize => Memory.ModuleBase() + 0x7E4EA80;
        public void SetAutoSize(bool InbAutoSize)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InbAutoSize?1:0));
            CallRaw("SetAutoSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4EC38 — hookable via Hooks.InstallAt(NativeFunc_SetAnchors).</summary>
        public static System.IntPtr NativeFunc_SetAnchors => Memory.ModuleBase() + 0x7E4EC38;
        public void SetAnchors(Anchors InAnchors)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InAnchors);
            CallRaw("SetAnchors", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4EB60 — hookable via Hooks.InstallAt(NativeFunc_SetAlignment).</summary>
        public static System.IntPtr NativeFunc_SetAlignment => Memory.ModuleBase() + 0x7E4EB60;
        public void SetAlignment(Vector2D InAlignment)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InAlignment);
            CallRaw("SetAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4E970 — hookable via Hooks.InstallAt(NativeFunc_GetZOrder).</summary>
        public static System.IntPtr NativeFunc_GetZOrder => Memory.ModuleBase() + 0x7E4E970;
        public int GetZOrder()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetZOrder", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E4EDC0 — hookable via Hooks.InstallAt(NativeFunc_GetSize).</summary>
        public static System.IntPtr NativeFunc_GetSize => Memory.ModuleBase() + 0x7E4EDC0;
        public Vector2D GetSize()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetSize", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E4EE94 — hookable via Hooks.InstallAt(NativeFunc_GetPosition).</summary>
        public static System.IntPtr NativeFunc_GetPosition => Memory.ModuleBase() + 0x7E4EE94;
        public Vector2D GetPosition()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetPosition", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E4ECE0 — hookable via Hooks.InstallAt(NativeFunc_GetOffsets).</summary>
        public static System.IntPtr NativeFunc_GetOffsets => Memory.ModuleBase() + 0x7E4ECE0;
        public Margin GetOffsets()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetOffsets", __pb.Bytes);
            return __pb.Get<Margin>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E4EF68 — hookable via Hooks.InstallAt(NativeFunc_GetLayout).</summary>
        public static System.IntPtr NativeFunc_GetLayout => Memory.ModuleBase() + 0x7E4EF68;
        public AnchorData GetLayout()
        {
            var __pb = new ParamBuffer(40);
            CallRaw("GetLayout", __pb.Bytes);
            return __pb.Get<AnchorData>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E4EA48 — hookable via Hooks.InstallAt(NativeFunc_GetAutoSize).</summary>
        public static System.IntPtr NativeFunc_GetAutoSize => Memory.ModuleBase() + 0x7E4EA48;
        public bool GetAutoSize()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetAutoSize", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E4EC00 — hookable via Hooks.InstallAt(NativeFunc_GetAnchors).</summary>
        public static System.IntPtr NativeFunc_GetAnchors => Memory.ModuleBase() + 0x7E4EC00;
        public Anchors GetAnchors()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAnchors", __pb.Bytes);
            return __pb.Get<Anchors>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E4EB2C — hookable via Hooks.InstallAt(NativeFunc_GetAlignment).</summary>
        public static System.IntPtr NativeFunc_GetAlignment => Memory.ModuleBase() + 0x7E4EB2C;
        public Vector2D GetAlignment()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetAlignment", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
    }

    public class CheckBox : ContentWidget
    {
        public const string UeClassName = "CheckBox";
        public CheckBox(System.IntPtr ptr) : base(ptr) {}
        public static new CheckBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CheckBox(p);
        public static CheckBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CheckBox(o.Pointer); }
        public static CheckBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CheckBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CheckBox(a[i].Pointer); return r; }
        public ECheckBoxState CheckedState { get => (ECheckBoxState)GetAt<byte>(0x119); set => SetAt(0x119, (byte)value); }
        public System.IntPtr CheckedStateDelegate => AddrOf(0x11C); // 
        public CheckBoxStyle WidgetStyle => new CheckBoxStyle(AddrOf(0x130));
        public SlateWidgetStyleAsset Style { get { var __p = GetAt<System.IntPtr>(0x6B0); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0x6B0, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset UncheckedImage { get { var __p = GetAt<System.IntPtr>(0x6B8); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x6B8, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset UncheckedHoveredImage { get { var __p = GetAt<System.IntPtr>(0x6C0); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x6C0, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset UncheckedPressedImage { get { var __p = GetAt<System.IntPtr>(0x6C8); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x6C8, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset CheckedImage { get { var __p = GetAt<System.IntPtr>(0x6D0); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x6D0, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset CheckedHoveredImage { get { var __p = GetAt<System.IntPtr>(0x6D8); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x6D8, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset CheckedPressedImage { get { var __p = GetAt<System.IntPtr>(0x6E0); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x6E0, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset UndeterminedImage { get { var __p = GetAt<System.IntPtr>(0x6E8); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x6E8, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset UndeterminedHoveredImage { get { var __p = GetAt<System.IntPtr>(0x6F0); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x6F0, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset UndeterminedPressedImage { get { var __p = GetAt<System.IntPtr>(0x6F8); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x6F8, value?.Pointer ?? System.IntPtr.Zero); }
        public byte HorizontalAlignment { get => GetAt<byte>(0x700); set => SetAt(0x700, value); }
        public Margin Padding => new Margin(AddrOf(0x704));
        public SlateColor BorderBackgroundColor => new SlateColor(AddrOf(0x718));
        public bool IsFocusable { get => Native.GetPropBool(Pointer, "IsFocusable"); set => Native.SetPropBool(Pointer, "IsFocusable", value); }
        public System.IntPtr OnCheckStateChanged => AddrOf(0x748); // 
        /// <summary>[Native] thunk RVA 0x7E50068 — hookable via Hooks.InstallAt(NativeFunc_SetIsChecked).</summary>
        public static System.IntPtr NativeFunc_SetIsChecked => Memory.ModuleBase() + 0x7E50068;
        public void SetIsChecked(bool InIsChecked)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InIsChecked?1:0));
            CallRaw("SetIsChecked", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E4FFC4 — hookable via Hooks.InstallAt(NativeFunc_SetCheckedState).</summary>
        public static System.IntPtr NativeFunc_SetCheckedState => Memory.ModuleBase() + 0x7E4FFC4;
        public void SetCheckedState(ECheckBoxState InCheckedState)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InCheckedState);
            CallRaw("SetCheckedState", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E50180 — hookable via Hooks.InstallAt(NativeFunc_IsPressed).</summary>
        public static System.IntPtr NativeFunc_IsPressed => Memory.ModuleBase() + 0x7E50180;
        public bool IsPressed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPressed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E50148 — hookable via Hooks.InstallAt(NativeFunc_IsChecked).</summary>
        public static System.IntPtr NativeFunc_IsChecked => Memory.ModuleBase() + 0x7E50148;
        public bool IsChecked()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsChecked", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E50114 — hookable via Hooks.InstallAt(NativeFunc_GetCheckedState).</summary>
        public static System.IntPtr NativeFunc_GetCheckedState => Memory.ModuleBase() + 0x7E50114;
        public ECheckBoxState GetCheckedState()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetCheckedState", __pb.Bytes);
            return (ECheckBoxState)__pb.Get<byte>(0x0);
        }
    }

    public class CheckedStateBinding : PropertyBinding
    {
        public const string UeClassName = "CheckedStateBinding";
        public CheckedStateBinding(System.IntPtr ptr) : base(ptr) {}
        public static new CheckedStateBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CheckedStateBinding(p);
        public static CheckedStateBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CheckedStateBinding(o.Pointer); }
        public static CheckedStateBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CheckedStateBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CheckedStateBinding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E50B34 — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7E50B34;
        public ECheckBoxState GetValue()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetValue", __pb.Bytes);
            return (ECheckBoxState)__pb.Get<byte>(0x0);
        }
    }

    public class CircularThrobber : Widget
    {
        public const string UeClassName = "CircularThrobber";
        public CircularThrobber(System.IntPtr ptr) : base(ptr) {}
        public static new CircularThrobber FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new CircularThrobber(p);
        public static CircularThrobber FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CircularThrobber(o.Pointer); }
        public static CircularThrobber[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CircularThrobber[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CircularThrobber(a[i].Pointer); return r; }
        public int NumberOfPieces { get => GetAt<int>(0x108); set => SetAt(0x108, value); }
        public float Period { get => GetAt<float>(0x10C); set => SetAt(0x10C, value); }
        public float Radius { get => GetAt<float>(0x110); set => SetAt(0x110, value); }
        public SlateBrushAsset PieceImage { get { var __p = GetAt<System.IntPtr>(0x118); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x118, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrush Image => new SlateBrush(AddrOf(0x120));
        public bool bEnableRadius { get => Native.GetPropBool(Pointer, "bEnableRadius"); set => Native.SetPropBool(Pointer, "bEnableRadius", value); }
        /// <summary>[Native] thunk RVA 0x7E512FC — hookable via Hooks.InstallAt(NativeFunc_SetRadius).</summary>
        public static System.IntPtr NativeFunc_SetRadius => Memory.ModuleBase() + 0x7E512FC;
        public void SetRadius(float InRadius)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InRadius);
            CallRaw("SetRadius", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E513A0 — hookable via Hooks.InstallAt(NativeFunc_SetPeriod).</summary>
        public static System.IntPtr NativeFunc_SetPeriod => Memory.ModuleBase() + 0x7E513A0;
        public void SetPeriod(float InPeriod)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InPeriod);
            CallRaw("SetPeriod", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E51444 — hookable via Hooks.InstallAt(NativeFunc_SetNumberOfPieces).</summary>
        public static System.IntPtr NativeFunc_SetNumberOfPieces => Memory.ModuleBase() + 0x7E51444;
        public void SetNumberOfPieces(int InNumberOfPieces)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InNumberOfPieces);
            CallRaw("SetNumberOfPieces", __pb.Bytes);
        }
    }

    public class ColorBinding : PropertyBinding
    {
        public const string UeClassName = "ColorBinding";
        public ColorBinding(System.IntPtr ptr) : base(ptr) {}
        public static new ColorBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ColorBinding(p);
        public static ColorBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ColorBinding(o.Pointer); }
        public static ColorBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ColorBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ColorBinding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E51E10 — hookable via Hooks.InstallAt(NativeFunc_GetSlateValue).</summary>
        public static System.IntPtr NativeFunc_GetSlateValue => Memory.ModuleBase() + 0x7E51E10;
        public SlateColor GetSlateValue()
        {
            var __pb = new ParamBuffer(40);
            CallRaw("GetSlateValue", __pb.Bytes);
            return __pb.Get<SlateColor>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E51DD8 — hookable via Hooks.InstallAt(NativeFunc_GetLinearValue).</summary>
        public static System.IntPtr NativeFunc_GetLinearValue => Memory.ModuleBase() + 0x7E51DD8;
        public LinearColor GetLinearValue()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetLinearValue", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
    }

    public class ComboBox : Widget
    {
        public const string UeClassName = "ComboBox";
        public ComboBox(System.IntPtr ptr) : base(ptr) {}
        public static new ComboBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ComboBox(p);
        public static ComboBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ComboBox(o.Pointer); }
        public static ComboBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ComboBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ComboBox(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Items => new TArray<System.IntPtr>(AddrOf(0x108)); // TArray<UObject*>
        public System.IntPtr OnGenerateWidgetEvent => AddrOf(0x118); // 
        public bool bIsFocusable { get => Native.GetPropBool(Pointer, "bIsFocusable"); set => Native.SetPropBool(Pointer, "bIsFocusable", value); }
    }

    public class ComboBoxString : Widget
    {
        public const string UeClassName = "ComboBoxString";
        public ComboBoxString(System.IntPtr ptr) : base(ptr) {}
        public static new ComboBoxString FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ComboBoxString(p);
        public static ComboBoxString FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ComboBoxString(o.Pointer); }
        public static ComboBoxString[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ComboBoxString[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ComboBoxString(a[i].Pointer); return r; }
        public TArray<System.IntPtr> DefaultOptions => new TArray<System.IntPtr>(AddrOf(0x108)); // TArray<FString>
        public string SelectedOption => Native.GetPropString(Pointer, "SelectedOption"); // FString
        public ComboBoxStyle WidgetStyle => new ComboBoxStyle(AddrOf(0x128));
        public TableRowStyle ItemStyle => new TableRowStyle(AddrOf(0x518));
        public Margin ContentPadding => new Margin(AddrOf(0xCE0));
        public float MaxListHeight { get => GetAt<float>(0xCF0); set => SetAt(0xCF0, value); }
        public bool HasDownArrow { get => Native.GetPropBool(Pointer, "HasDownArrow"); set => Native.SetPropBool(Pointer, "HasDownArrow", value); }
        public bool EnableGamepadNavigationMode { get => Native.GetPropBool(Pointer, "EnableGamepadNavigationMode"); set => Native.SetPropBool(Pointer, "EnableGamepadNavigationMode", value); }
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0xCF8));
        public SlateColor ForegroundColor => new SlateColor(AddrOf(0xD48));
        public bool bIsFocusable { get => Native.GetPropBool(Pointer, "bIsFocusable"); set => Native.SetPropBool(Pointer, "bIsFocusable", value); }
        public System.IntPtr OnGenerateWidgetEvent => AddrOf(0xD74); // 
        public System.IntPtr OnSelectionChanged => AddrOf(0xD88); // 
        public System.IntPtr OnOpening => AddrOf(0xD98); // 
        /// <summary>[Native] thunk RVA 0x7E53118 — hookable via Hooks.InstallAt(NativeFunc_SetSelectedOption).</summary>
        public static System.IntPtr NativeFunc_SetSelectedOption => Memory.ModuleBase() + 0x7E53118;
        public void SetSelectedOption(System.IntPtr Option)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Option);
            CallRaw("SetSelectedOption", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E53074 — hookable via Hooks.InstallAt(NativeFunc_SetSelectedIndex).</summary>
        public static System.IntPtr NativeFunc_SetSelectedIndex => Memory.ModuleBase() + 0x7E53074;
        public void SetSelectedIndex(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("SetSelectedIndex", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E533FC — hookable via Hooks.InstallAt(NativeFunc_RemoveOption).</summary>
        public static System.IntPtr NativeFunc_RemoveOption => Memory.ModuleBase() + 0x7E533FC;
        public bool RemoveOption(System.IntPtr Option)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, Option);
            CallRaw("RemoveOption", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E53210 — hookable via Hooks.InstallAt(NativeFunc_RefreshOptions).</summary>
        public static System.IntPtr NativeFunc_RefreshOptions => Memory.ModuleBase() + 0x7E53210;
        public void RefreshOptions()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RefreshOptions", __pb.Bytes);
        }
        public void OnSelectionChangedEvent__DelegateSignature(System.IntPtr SelectedItem, byte SelectionType)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, SelectedItem);
            __pb.Set(0x10, SelectionType);
            CallRaw("OnSelectionChangedEvent__DelegateSignature", __pb.Bytes);
        }
        public void OnOpeningEvent__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnOpeningEvent__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E52F24 — hookable via Hooks.InstallAt(NativeFunc_IsOpen).</summary>
        public static System.IntPtr NativeFunc_IsOpen => Memory.ModuleBase() + 0x7E52F24;
        public bool IsOpen()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsOpen", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E52FC4 — hookable via Hooks.InstallAt(NativeFunc_GetSelectedOption).</summary>
        public static System.IntPtr NativeFunc_GetSelectedOption => Memory.ModuleBase() + 0x7E52FC4;
        public System.IntPtr GetSelectedOption()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetSelectedOption", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E52F90 — hookable via Hooks.InstallAt(NativeFunc_GetSelectedIndex).</summary>
        public static System.IntPtr NativeFunc_GetSelectedIndex => Memory.ModuleBase() + 0x7E52F90;
        public int GetSelectedIndex()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetSelectedIndex", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E52F5C — hookable via Hooks.InstallAt(NativeFunc_GetOptionCount).</summary>
        public static System.IntPtr NativeFunc_GetOptionCount => Memory.ModuleBase() + 0x7E52F5C;
        public int GetOptionCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetOptionCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E5324C — hookable via Hooks.InstallAt(NativeFunc_GetOptionAtIndex).</summary>
        public static System.IntPtr NativeFunc_GetOptionAtIndex => Memory.ModuleBase() + 0x7E5324C;
        public System.IntPtr GetOptionAtIndex(int Index)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Index);
            CallRaw("GetOptionAtIndex", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7E53344 — hookable via Hooks.InstallAt(NativeFunc_FindOptionIndex).</summary>
        public static System.IntPtr NativeFunc_FindOptionIndex => Memory.ModuleBase() + 0x7E53344;
        public int FindOptionIndex(System.IntPtr Option)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<System.IntPtr>(0x0, Option);
            CallRaw("FindOptionIndex", __pb.Bytes);
            return __pb.Get<int>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x7E53224 — hookable via Hooks.InstallAt(NativeFunc_ClearSelection).</summary>
        public static System.IntPtr NativeFunc_ClearSelection => Memory.ModuleBase() + 0x7E53224;
        public void ClearSelection()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearSelection", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E53238 — hookable via Hooks.InstallAt(NativeFunc_ClearOptions).</summary>
        public static System.IntPtr NativeFunc_ClearOptions => Memory.ModuleBase() + 0x7E53238;
        public void ClearOptions()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearOptions", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E534B8 — hookable via Hooks.InstallAt(NativeFunc_AddOption).</summary>
        public static System.IntPtr NativeFunc_AddOption => Memory.ModuleBase() + 0x7E534B8;
        public void AddOption(System.IntPtr Option)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Option);
            CallRaw("AddOption", __pb.Bytes);
        }
    }

    public class DragDropOperation : Object
    {
        public const string UeClassName = "DragDropOperation";
        public DragDropOperation(System.IntPtr ptr) : base(ptr) {}
        public static new DragDropOperation FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DragDropOperation(p);
        public static DragDropOperation FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DragDropOperation(o.Pointer); }
        public static DragDropOperation[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DragDropOperation[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DragDropOperation(a[i].Pointer); return r; }
        public string Tag => Native.GetPropString(Pointer, "Tag"); // FString
        public Object payload { get { var __p = GetAt<System.IntPtr>(0x38); return __p==System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x38, value?.Pointer ?? System.IntPtr.Zero); }
        public Widget DefaultDragVisual { get { var __p = GetAt<System.IntPtr>(0x40); return __p==System.IntPtr.Zero?null:new Widget(__p); } set => SetAt(0x40, value?.Pointer ?? System.IntPtr.Zero); }
        public EDragPivot Pivot { get => (EDragPivot)GetAt<byte>(0x48); set => SetAt(0x48, (byte)value); }
        public Vector2D Offset => new Vector2D(AddrOf(0x4C));
        public System.IntPtr OnDrop => AddrOf(0x58); // 
        public System.IntPtr OnDragCancelled => AddrOf(0x68); // 
        public System.IntPtr OnDragged => AddrOf(0x78); // 
        /// <summary>[Native] thunk RVA 0x7E55338 — hookable via Hooks.InstallAt(NativeFunc_Drop).</summary>
        public static System.IntPtr NativeFunc_Drop => Memory.ModuleBase() + 0x7E55338;
        public void Drop(PointerEvent PointerEvent)
        {
            var __pb = new ParamBuffer(112);
            __pb.Set<System.IntPtr>(0x0, PointerEvent);
            CallRaw("Drop", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E55060 — hookable via Hooks.InstallAt(NativeFunc_Dragged).</summary>
        public static System.IntPtr NativeFunc_Dragged => Memory.ModuleBase() + 0x7E55060;
        public void Dragged(PointerEvent PointerEvent)
        {
            var __pb = new ParamBuffer(112);
            __pb.Set<System.IntPtr>(0x0, PointerEvent);
            CallRaw("Dragged", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E551CC — hookable via Hooks.InstallAt(NativeFunc_DragCancelled).</summary>
        public static System.IntPtr NativeFunc_DragCancelled => Memory.ModuleBase() + 0x7E551CC;
        public void DragCancelled(PointerEvent PointerEvent)
        {
            var __pb = new ParamBuffer(112);
            __pb.Set<System.IntPtr>(0x0, PointerEvent);
            CallRaw("DragCancelled", __pb.Bytes);
        }
    }

    public class DynamicEntryBoxBase : Widget
    {
        public const string UeClassName = "DynamicEntryBoxBase";
        public DynamicEntryBoxBase(System.IntPtr ptr) : base(ptr) {}
        public static new DynamicEntryBoxBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DynamicEntryBoxBase(p);
        public static DynamicEntryBoxBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DynamicEntryBoxBase(o.Pointer); }
        public static DynamicEntryBoxBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DynamicEntryBoxBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DynamicEntryBoxBase(a[i].Pointer); return r; }
        public EDynamicBoxType EntryBoxType { get => (EDynamicBoxType)GetAt<byte>(0x108); set => SetAt(0x108, (byte)value); }
        public Vector2D EntrySpacing => new Vector2D(AddrOf(0x10C));
        public TArray<System.IntPtr> SpacingPattern => new TArray<System.IntPtr>(AddrOf(0x118)); // TArray<struct>
        public SlateChildSize EntrySizeRule => new SlateChildSize(AddrOf(0x128));
        public byte EntryHorizontalAlignment { get => GetAt<byte>(0x130); set => SetAt(0x130, value); }
        public byte EntryVerticalAlignment { get => GetAt<byte>(0x131); set => SetAt(0x131, value); }
        public int MaxElementSize { get => GetAt<int>(0x134); set => SetAt(0x134, value); }
        public UserWidgetPool EntryWidgetPool => new UserWidgetPool(AddrOf(0x148));
        /// <summary>[Native] thunk RVA 0x7E56C08 — hookable via Hooks.InstallAt(NativeFunc_SetEntrySpacing).</summary>
        public static System.IntPtr NativeFunc_SetEntrySpacing => Memory.ModuleBase() + 0x7E56C08;
        public void SetEntrySpacing(Vector2D InEntrySpacing)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InEntrySpacing);
            CallRaw("SetEntrySpacing", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E56CB8 — hookable via Hooks.InstallAt(NativeFunc_GetNumEntries).</summary>
        public static System.IntPtr NativeFunc_GetNumEntries => Memory.ModuleBase() + 0x7E56CB8;
        public int GetNumEntries()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumEntries", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E56CEC — hookable via Hooks.InstallAt(NativeFunc_GetAllEntries).</summary>
        public static System.IntPtr NativeFunc_GetAllEntries => Memory.ModuleBase() + 0x7E56CEC;
        public System.IntPtr GetAllEntries()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetAllEntries", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class DynamicEntryBox : DynamicEntryBoxBase
    {
        public const string UeClassName = "DynamicEntryBox";
        public DynamicEntryBox(System.IntPtr ptr) : base(ptr) {}
        public static new DynamicEntryBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DynamicEntryBox(p);
        public static DynamicEntryBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DynamicEntryBox(o.Pointer); }
        public static DynamicEntryBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DynamicEntryBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DynamicEntryBox(a[i].Pointer); return r; }
        public UserWidget EntryWidgetClass { get { var __p = GetAt<System.IntPtr>(0x1C8); return __p==System.IntPtr.Zero?null:new UserWidget(__p); } set => SetAt(0x1C8, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x7E56168 — hookable via Hooks.InstallAt(NativeFunc_Reset).</summary>
        public static System.IntPtr NativeFunc_Reset => Memory.ModuleBase() + 0x7E56168;
        public void Reset(bool bDeleteWidgets)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bDeleteWidgets?1:0));
            CallRaw("Reset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E560C4 — hookable via Hooks.InstallAt(NativeFunc_RemoveEntry).</summary>
        public static System.IntPtr NativeFunc_RemoveEntry => Memory.ModuleBase() + 0x7E560C4;
        public void RemoveEntry(UserWidget EntryWidget)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, EntryWidget);
            CallRaw("RemoveEntry", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E55FE4 — hookable via Hooks.InstallAt(NativeFunc_BP_CreateEntryOfClass).</summary>
        public static System.IntPtr NativeFunc_BP_CreateEntryOfClass => Memory.ModuleBase() + 0x7E55FE4;
        public UserWidget BP_CreateEntryOfClass(UserWidget EntryClass)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, EntryClass);
            CallRaw("BP_CreateEntryOfClass", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new UserWidget(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E56090 — hookable via Hooks.InstallAt(NativeFunc_BP_CreateEntry).</summary>
        public static System.IntPtr NativeFunc_BP_CreateEntry => Memory.ModuleBase() + 0x7E56090;
        public UserWidget BP_CreateEntry()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("BP_CreateEntry", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new UserWidget(__p); }
        }
    }

    public class EditableText : Widget
    {
        public const string UeClassName = "EditableText";
        public EditableText(System.IntPtr ptr) : base(ptr) {}
        public static new EditableText FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableText(p);
        public static EditableText FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableText(o.Pointer); }
        public static EditableText[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableText[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableText(a[i].Pointer); return r; }
        public System.IntPtr Text => AddrOf(0x108); // 
        public System.IntPtr TextDelegate => AddrOf(0x120); // 
        public System.IntPtr HintText => AddrOf(0x130); // 
        public System.IntPtr HintTextDelegate => AddrOf(0x148); // 
        public EditableTextStyle WidgetStyle => new EditableTextStyle(AddrOf(0x158));
        public SlateWidgetStyleAsset Style { get { var __p = GetAt<System.IntPtr>(0x370); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0x370, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset BackgroundImageSelected { get { var __p = GetAt<System.IntPtr>(0x378); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x378, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset BackgroundImageComposing { get { var __p = GetAt<System.IntPtr>(0x380); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x380, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset CaretImage { get { var __p = GetAt<System.IntPtr>(0x388); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x388, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0x390));
        public SlateColor ColorAndOpacity => new SlateColor(AddrOf(0x3E0));
        public bool IsReadOnly { get => Native.GetPropBool(Pointer, "IsReadOnly"); set => Native.SetPropBool(Pointer, "IsReadOnly", value); }
        public bool IsPassword { get => Native.GetPropBool(Pointer, "IsPassword"); set => Native.SetPropBool(Pointer, "IsPassword", value); }
        public float MinimumDesiredWidth { get => GetAt<float>(0x40C); set => SetAt(0x40C, value); }
        public bool IsCaretMovedWhenGainFocus { get => Native.GetPropBool(Pointer, "IsCaretMovedWhenGainFocus"); set => Native.SetPropBool(Pointer, "IsCaretMovedWhenGainFocus", value); }
        public bool SelectAllTextWhenFocused { get => Native.GetPropBool(Pointer, "SelectAllTextWhenFocused"); set => Native.SetPropBool(Pointer, "SelectAllTextWhenFocused", value); }
        public bool RevertTextOnEscape { get => Native.GetPropBool(Pointer, "RevertTextOnEscape"); set => Native.SetPropBool(Pointer, "RevertTextOnEscape", value); }
        public bool ClearKeyboardFocusOnCommit { get => Native.GetPropBool(Pointer, "ClearKeyboardFocusOnCommit"); set => Native.SetPropBool(Pointer, "ClearKeyboardFocusOnCommit", value); }
        public bool SelectAllTextOnCommit { get => Native.GetPropBool(Pointer, "SelectAllTextOnCommit"); set => Native.SetPropBool(Pointer, "SelectAllTextOnCommit", value); }
        public bool AllowContextMenu { get => Native.GetPropBool(Pointer, "AllowContextMenu"); set => Native.SetPropBool(Pointer, "AllowContextMenu", value); }
        public byte KeyboardType { get => GetAt<byte>(0x416); set => SetAt(0x416, value); }
        public VirtualKeyboardOptions VirtualKeyboardOptions => new VirtualKeyboardOptions(AddrOf(0x417));
        public EVirtualKeyboardTrigger VirtualKeyboardTrigger { get => (EVirtualKeyboardTrigger)GetAt<byte>(0x418); set => SetAt(0x418, (byte)value); }
        public EVirtualKeyboardDismissAction VirtualKeyboardDismissAction { get => (EVirtualKeyboardDismissAction)GetAt<byte>(0x419); set => SetAt(0x419, (byte)value); }
        public byte Justification { get => GetAt<byte>(0x41A); set => SetAt(0x41A, value); }
        public ShapedTextOptions ShapedTextOptions => new ShapedTextOptions(AddrOf(0x41B));
        public System.IntPtr OnTextChanged => AddrOf(0x420); // 
        public System.IntPtr OnTextCommitted => AddrOf(0x430); // 
        /// <summary>[Native] thunk RVA 0x7E58044 — hookable via Hooks.InstallAt(NativeFunc_SetText).</summary>
        public static System.IntPtr NativeFunc_SetText => Memory.ModuleBase() + 0x7E58044;
        public void SetText(System.IntPtr InText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InText);
            CallRaw("SetText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E57CB8 — hookable via Hooks.InstallAt(NativeFunc_SetJustification).</summary>
        public static System.IntPtr NativeFunc_SetJustification => Memory.ModuleBase() + 0x7E57CB8;
        public void SetJustification(byte InJustification)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InJustification);
            CallRaw("SetJustification", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E57D5C — hookable via Hooks.InstallAt(NativeFunc_SetIsReadOnly).</summary>
        public static System.IntPtr NativeFunc_SetIsReadOnly => Memory.ModuleBase() + 0x7E57D5C;
        public void SetIsReadOnly(bool InbIsReadyOnly)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InbIsReadyOnly?1:0));
            CallRaw("SetIsReadOnly", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E57F98 — hookable via Hooks.InstallAt(NativeFunc_SetIsPassword).</summary>
        public static System.IntPtr NativeFunc_SetIsPassword => Memory.ModuleBase() + 0x7E57F98;
        public void SetIsPassword(bool InbIsPassword)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InbIsPassword?1:0));
            CallRaw("SetIsPassword", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E57E08 — hookable via Hooks.InstallAt(NativeFunc_SetHintText).</summary>
        public static System.IntPtr NativeFunc_SetHintText => Memory.ModuleBase() + 0x7E57E08;
        public void SetHintText(System.IntPtr InHintText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InHintText);
            CallRaw("SetHintText", __pb.Bytes);
        }
        public void OnEditableTextCommittedEvent__DelegateSignature(System.IntPtr Text, byte CommitMethod)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, Text);
            __pb.Set(0x18, CommitMethod);
            CallRaw("OnEditableTextCommittedEvent__DelegateSignature", __pb.Bytes);
        }
        public void OnEditableTextChangedEvent__DelegateSignature(System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Text);
            CallRaw("OnEditableTextChangedEvent__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E581D4 — hookable via Hooks.InstallAt(NativeFunc_GetText).</summary>
        public static System.IntPtr NativeFunc_GetText => Memory.ModuleBase() + 0x7E581D4;
        public System.IntPtr GetText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetText", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class EditableTextBox : Widget
    {
        public const string UeClassName = "EditableTextBox";
        public EditableTextBox(System.IntPtr ptr) : base(ptr) {}
        public static new EditableTextBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableTextBox(p);
        public static EditableTextBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableTextBox(o.Pointer); }
        public static EditableTextBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableTextBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableTextBox(a[i].Pointer); return r; }
        public System.IntPtr Text => AddrOf(0x108); // 
        public System.IntPtr TextDelegate => AddrOf(0x120); // 
        public EditableTextBoxStyle WidgetStyle => new EditableTextBoxStyle(AddrOf(0x130));
        public SlateWidgetStyleAsset Style { get { var __p = GetAt<System.IntPtr>(0x920); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0x920, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr HintText => AddrOf(0x928); // 
        public System.IntPtr HintTextDelegate => AddrOf(0x940); // 
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0x950));
        public LinearColor ForegroundColor => new LinearColor(AddrOf(0x9A0));
        public LinearColor BackgroundColor => new LinearColor(AddrOf(0x9B0));
        public LinearColor ReadOnlyForegroundColor => new LinearColor(AddrOf(0x9C0));
        public bool IsReadOnly { get => Native.GetPropBool(Pointer, "IsReadOnly"); set => Native.SetPropBool(Pointer, "IsReadOnly", value); }
        public bool IsPassword { get => Native.GetPropBool(Pointer, "IsPassword"); set => Native.SetPropBool(Pointer, "IsPassword", value); }
        public float MinimumDesiredWidth { get => GetAt<float>(0x9D4); set => SetAt(0x9D4, value); }
        public Margin Padding => new Margin(AddrOf(0x9D8));
        public bool IsCaretMovedWhenGainFocus { get => Native.GetPropBool(Pointer, "IsCaretMovedWhenGainFocus"); set => Native.SetPropBool(Pointer, "IsCaretMovedWhenGainFocus", value); }
        public bool SelectAllTextWhenFocused { get => Native.GetPropBool(Pointer, "SelectAllTextWhenFocused"); set => Native.SetPropBool(Pointer, "SelectAllTextWhenFocused", value); }
        public bool RevertTextOnEscape { get => Native.GetPropBool(Pointer, "RevertTextOnEscape"); set => Native.SetPropBool(Pointer, "RevertTextOnEscape", value); }
        public bool ClearKeyboardFocusOnCommit { get => Native.GetPropBool(Pointer, "ClearKeyboardFocusOnCommit"); set => Native.SetPropBool(Pointer, "ClearKeyboardFocusOnCommit", value); }
        public bool SelectAllTextOnCommit { get => Native.GetPropBool(Pointer, "SelectAllTextOnCommit"); set => Native.SetPropBool(Pointer, "SelectAllTextOnCommit", value); }
        public bool AllowContextMenu { get => Native.GetPropBool(Pointer, "AllowContextMenu"); set => Native.SetPropBool(Pointer, "AllowContextMenu", value); }
        public byte KeyboardType { get => GetAt<byte>(0x9EE); set => SetAt(0x9EE, value); }
        public VirtualKeyboardOptions VirtualKeyboardOptions => new VirtualKeyboardOptions(AddrOf(0x9EF));
        public EVirtualKeyboardTrigger VirtualKeyboardTrigger { get => (EVirtualKeyboardTrigger)GetAt<byte>(0x9F0); set => SetAt(0x9F0, (byte)value); }
        public EVirtualKeyboardDismissAction VirtualKeyboardDismissAction { get => (EVirtualKeyboardDismissAction)GetAt<byte>(0x9F1); set => SetAt(0x9F1, (byte)value); }
        public byte Justification { get => GetAt<byte>(0x9F2); set => SetAt(0x9F2, value); }
        public ShapedTextOptions ShapedTextOptions => new ShapedTextOptions(AddrOf(0x9F3));
        public System.IntPtr OnTextChanged => AddrOf(0x9F8); // 
        public System.IntPtr OnTextCommitted => AddrOf(0xA08); // 
        /// <summary>[Native] thunk RVA 0x7E592EC — hookable via Hooks.InstallAt(NativeFunc_SetText).</summary>
        public static System.IntPtr NativeFunc_SetText => Memory.ModuleBase() + 0x7E592EC;
        public void SetText(System.IntPtr InText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InText);
            CallRaw("SetText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E58D84 — hookable via Hooks.InstallAt(NativeFunc_SetJustification).</summary>
        public static System.IntPtr NativeFunc_SetJustification => Memory.ModuleBase() + 0x7E58D84;
        public void SetJustification(byte InJustification)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InJustification);
            CallRaw("SetJustification", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E58F20 — hookable via Hooks.InstallAt(NativeFunc_SetIsReadOnly).</summary>
        public static System.IntPtr NativeFunc_SetIsReadOnly => Memory.ModuleBase() + 0x7E58F20;
        public void SetIsReadOnly(bool bReadOnly)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bReadOnly?1:0));
            CallRaw("SetIsReadOnly", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E58E74 — hookable via Hooks.InstallAt(NativeFunc_SetIsPassword).</summary>
        public static System.IntPtr NativeFunc_SetIsPassword => Memory.ModuleBase() + 0x7E58E74;
        public void SetIsPassword(bool bIsPassword)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bIsPassword?1:0));
            CallRaw("SetIsPassword", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5915C — hookable via Hooks.InstallAt(NativeFunc_SetHintText).</summary>
        public static System.IntPtr NativeFunc_SetHintText => Memory.ModuleBase() + 0x7E5915C;
        public void SetHintText(System.IntPtr InText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InText);
            CallRaw("SetHintText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E58FCC — hookable via Hooks.InstallAt(NativeFunc_SetError).</summary>
        public static System.IntPtr NativeFunc_SetError => Memory.ModuleBase() + 0x7E58FCC;
        public void SetError(System.IntPtr InError)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InError);
            CallRaw("SetError", __pb.Bytes);
        }
        public void OnEditableTextBoxCommittedEvent__DelegateSignature(System.IntPtr Text, byte CommitMethod)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, Text);
            __pb.Set(0x18, CommitMethod);
            CallRaw("OnEditableTextBoxCommittedEvent__DelegateSignature", __pb.Bytes);
        }
        public void OnEditableTextBoxChangedEvent__DelegateSignature(System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Text);
            CallRaw("OnEditableTextBoxChangedEvent__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E58E28 — hookable via Hooks.InstallAt(NativeFunc_HasError).</summary>
        public static System.IntPtr NativeFunc_HasError => Memory.ModuleBase() + 0x7E58E28;
        public bool HasError()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasError", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E5947C — hookable via Hooks.InstallAt(NativeFunc_GetText).</summary>
        public static System.IntPtr NativeFunc_GetText => Memory.ModuleBase() + 0x7E5947C;
        public System.IntPtr GetText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetText", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E58E60 — hookable via Hooks.InstallAt(NativeFunc_ClearError).</summary>
        public static System.IntPtr NativeFunc_ClearError => Memory.ModuleBase() + 0x7E58E60;
        public void ClearError()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearError", __pb.Bytes);
        }
    }

    public class ExpandableArea : Widget
    {
        public const string UeClassName = "ExpandableArea";
        public ExpandableArea(System.IntPtr ptr) : base(ptr) {}
        public static new ExpandableArea FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ExpandableArea(p);
        public static ExpandableArea FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ExpandableArea(o.Pointer); }
        public static ExpandableArea[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ExpandableArea[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ExpandableArea(a[i].Pointer); return r; }
        public ExpandableAreaStyle Style => new ExpandableAreaStyle(AddrOf(0x110));
        public SlateBrush BorderBrush => new SlateBrush(AddrOf(0x230));
        public SlateColor BorderColor => new SlateColor(AddrOf(0x2B8));
        public bool bIsExpanded { get => Native.GetPropBool(Pointer, "bIsExpanded"); set => Native.SetPropBool(Pointer, "bIsExpanded", value); }
        public float MaxHeight { get => GetAt<float>(0x2E4); set => SetAt(0x2E4, value); }
        public Margin HeaderPadding => new Margin(AddrOf(0x2E8));
        public Margin AreaPadding => new Margin(AddrOf(0x2F8));
        public System.IntPtr OnExpansionChanged => AddrOf(0x308); // 
        public Widget HeaderContent { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new Widget(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public Widget BodyContent { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new Widget(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x7E5A13C — hookable via Hooks.InstallAt(NativeFunc_SetIsExpanded_Animated).</summary>
        public static System.IntPtr NativeFunc_SetIsExpanded_Animated => Memory.ModuleBase() + 0x7E5A13C;
        public void SetIsExpanded_Animated(bool IsExpanded)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsExpanded?1:0));
            CallRaw("SetIsExpanded_Animated", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5A1E8 — hookable via Hooks.InstallAt(NativeFunc_SetIsExpanded).</summary>
        public static System.IntPtr NativeFunc_SetIsExpanded => Memory.ModuleBase() + 0x7E5A1E8;
        public void SetIsExpanded(bool IsExpanded)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsExpanded?1:0));
            CallRaw("SetIsExpanded", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5A294 — hookable via Hooks.InstallAt(NativeFunc_GetIsExpanded).</summary>
        public static System.IntPtr NativeFunc_GetIsExpanded => Memory.ModuleBase() + 0x7E5A294;
        public bool GetIsExpanded()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetIsExpanded", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class FloatBinding : PropertyBinding
    {
        public const string UeClassName = "FloatBinding";
        public FloatBinding(System.IntPtr ptr) : base(ptr) {}
        public static new FloatBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FloatBinding(p);
        public static FloatBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FloatBinding(o.Pointer); }
        public static FloatBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FloatBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FloatBinding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E5AB58 — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7E5AB58;
        public float GetValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
    }

    public class GridPanel : PanelWidget
    {
        public const string UeClassName = "GridPanel";
        public GridPanel(System.IntPtr ptr) : base(ptr) {}
        public static new GridPanel FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GridPanel(p);
        public static GridPanel FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GridPanel(o.Pointer); }
        public static GridPanel[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GridPanel[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GridPanel(a[i].Pointer); return r; }
        public TArray<System.IntPtr> ColumnFill => new TArray<System.IntPtr>(AddrOf(0x120)); // TArray<float>
        public TArray<System.IntPtr> RowFill => new TArray<System.IntPtr>(AddrOf(0x130)); // TArray<float>
        /// <summary>[Native] thunk RVA 0x7E5B31C — hookable via Hooks.InstallAt(NativeFunc_SetRowFill).</summary>
        public static System.IntPtr NativeFunc_SetRowFill => Memory.ModuleBase() + 0x7E5B31C;
        public void SetRowFill(int ColumnIndex, float Coefficient)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, ColumnIndex);
            __pb.Set(0x4, Coefficient);
            CallRaw("SetRowFill", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5B404 — hookable via Hooks.InstallAt(NativeFunc_SetColumnFill).</summary>
        public static System.IntPtr NativeFunc_SetColumnFill => Memory.ModuleBase() + 0x7E5B404;
        public void SetColumnFill(int ColumnIndex, float Coefficient)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, ColumnIndex);
            __pb.Set(0x4, Coefficient);
            CallRaw("SetColumnFill", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5B4EC — hookable via Hooks.InstallAt(NativeFunc_AddChildToGrid).</summary>
        public static System.IntPtr NativeFunc_AddChildToGrid => Memory.ModuleBase() + 0x7E5B4EC;
        public GridSlot AddChildToGrid(Widget Content, int InRow, int InColumn)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Content);
            __pb.Set(0x8, InRow);
            __pb.Set(0xC, InColumn);
            CallRaw("AddChildToGrid", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new GridSlot(__p); }
        }
    }

    public class GridSlot : PanelSlot
    {
        public const string UeClassName = "GridSlot";
        public GridSlot(System.IntPtr ptr) : base(ptr) {}
        public static new GridSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GridSlot(p);
        public static GridSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GridSlot(o.Pointer); }
        public static GridSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GridSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GridSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x38));
        public byte HorizontalAlignment { get => GetAt<byte>(0x48); set => SetAt(0x48, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x49); set => SetAt(0x49, value); }
        public int row { get => GetAt<int>(0x4C); set => SetAt(0x4C, value); }
        public int RowSpan { get => GetAt<int>(0x50); set => SetAt(0x50, value); }
        public int Column { get => GetAt<int>(0x54); set => SetAt(0x54, value); }
        public int ColumnSpan { get => GetAt<int>(0x58); set => SetAt(0x58, value); }
        public int Layer { get => GetAt<int>(0x5C); set => SetAt(0x5C, value); }
        public Vector2D Nudge => new Vector2D(AddrOf(0x60));
        /// <summary>[Native] thunk RVA 0x7E5BE94 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E5BE94;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5C268 — hookable via Hooks.InstallAt(NativeFunc_SetRowSpan).</summary>
        public static System.IntPtr NativeFunc_SetRowSpan => Memory.ModuleBase() + 0x7E5C268;
        public void SetRowSpan(int InRowSpan)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InRowSpan);
            CallRaw("SetRowSpan", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5C30C — hookable via Hooks.InstallAt(NativeFunc_SetRow).</summary>
        public static System.IntPtr NativeFunc_SetRow => Memory.ModuleBase() + 0x7E5C30C;
        public void SetRow(int InRow)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InRow);
            CallRaw("SetRow", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5C3B0 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E5C3B0;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5BFDC — hookable via Hooks.InstallAt(NativeFunc_SetNudge).</summary>
        public static System.IntPtr NativeFunc_SetNudge => Memory.ModuleBase() + 0x7E5BFDC;
        public void SetNudge(Vector2D InNudge)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InNudge);
            CallRaw("SetNudge", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5C07C — hookable via Hooks.InstallAt(NativeFunc_SetLayer).</summary>
        public static System.IntPtr NativeFunc_SetLayer => Memory.ModuleBase() + 0x7E5C07C;
        public void SetLayer(int InLayer)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InLayer);
            CallRaw("SetLayer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5BF38 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E5BF38;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5C120 — hookable via Hooks.InstallAt(NativeFunc_SetColumnSpan).</summary>
        public static System.IntPtr NativeFunc_SetColumnSpan => Memory.ModuleBase() + 0x7E5C120;
        public void SetColumnSpan(int InColumnSpan)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InColumnSpan);
            CallRaw("SetColumnSpan", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5C1C4 — hookable via Hooks.InstallAt(NativeFunc_SetColumn).</summary>
        public static System.IntPtr NativeFunc_SetColumn => Memory.ModuleBase() + 0x7E5C1C4;
        public void SetColumn(int InColumn)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InColumn);
            CallRaw("SetColumn", __pb.Bytes);
        }
    }

    public class HorizontalBox : PanelWidget
    {
        public const string UeClassName = "HorizontalBox";
        public HorizontalBox(System.IntPtr ptr) : base(ptr) {}
        public static new HorizontalBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new HorizontalBox(p);
        public static HorizontalBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new HorizontalBox(o.Pointer); }
        public static HorizontalBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new HorizontalBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new HorizontalBox(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E5CE50 — hookable via Hooks.InstallAt(NativeFunc_AddChildToHorizontalBox).</summary>
        public static System.IntPtr NativeFunc_AddChildToHorizontalBox => Memory.ModuleBase() + 0x7E5CE50;
        public HorizontalBoxSlot AddChildToHorizontalBox(Widget Content)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Content);
            CallRaw("AddChildToHorizontalBox", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new HorizontalBoxSlot(__p); }
        }
    }

    public class HorizontalBoxSlot : PanelSlot
    {
        public const string UeClassName = "HorizontalBoxSlot";
        public HorizontalBoxSlot(System.IntPtr ptr) : base(ptr) {}
        public static new HorizontalBoxSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new HorizontalBoxSlot(p);
        public static HorizontalBoxSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new HorizontalBoxSlot(o.Pointer); }
        public static HorizontalBoxSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new HorizontalBoxSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new HorizontalBoxSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x40));
        public SlateChildSize Size => new SlateChildSize(AddrOf(0x50));
        public byte HorizontalAlignment { get => GetAt<byte>(0x58); set => SetAt(0x58, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x59); set => SetAt(0x59, value); }
        /// <summary>[Native] thunk RVA 0x7E5D6D4 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E5D6D4;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5D81C — hookable via Hooks.InstallAt(NativeFunc_SetSize).</summary>
        public static System.IntPtr NativeFunc_SetSize => Memory.ModuleBase() + 0x7E5D81C;
        public void SetSize(SlateChildSize InSize)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InSize);
            CallRaw("SetSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5D8CC — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E5D8CC;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5D778 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E5D778;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class Image : Widget
    {
        public const string UeClassName = "Image";
        public Image(System.IntPtr ptr) : base(ptr) {}
        public static new Image FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Image(p);
        public static Image FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Image(o.Pointer); }
        public static Image[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Image[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Image(a[i].Pointer); return r; }
        public SlateBrush Brush => new SlateBrush(AddrOf(0x108));
        public System.IntPtr BrushDelegate => AddrOf(0x190); // 
        public LinearColor ColorAndOpacity => new LinearColor(AddrOf(0x1A0));
        public System.IntPtr ColorAndOpacityDelegate => AddrOf(0x1B0); // 
        public bool bFlipForRightToLeftFlowDirection { get => Native.GetPropBool(Pointer, "bFlipForRightToLeftFlowDirection"); set => Native.SetPropBool(Pointer, "bFlipForRightToLeftFlowDirection", value); }
        public System.IntPtr OnMouseButtonDownEvent => AddrOf(0x1C4); // 
        /// <summary>[Native] thunk RVA 0x7E5EE04 — hookable via Hooks.InstallAt(NativeFunc_SetOpacity).</summary>
        public static System.IntPtr NativeFunc_SetOpacity => Memory.ModuleBase() + 0x7E5EE04;
        public void SetOpacity(float InOpacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InOpacity);
            CallRaw("SetOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5EEA8 — hookable via Hooks.InstallAt(NativeFunc_SetColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetColorAndOpacity => Memory.ModuleBase() + 0x7E5EEA8;
        public void SetColorAndOpacity(LinearColor InColorAndOpacity)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InColorAndOpacity);
            CallRaw("SetColorAndOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5EBC0 — hookable via Hooks.InstallAt(NativeFunc_SetBrushTintColor).</summary>
        public static System.IntPtr NativeFunc_SetBrushTintColor => Memory.ModuleBase() + 0x7E5EBC0;
        public void SetBrushTintColor(SlateColor TintColor)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, TintColor);
            CallRaw("SetBrushTintColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5ED64 — hookable via Hooks.InstallAt(NativeFunc_SetBrushSize).</summary>
        public static System.IntPtr NativeFunc_SetBrushSize => Memory.ModuleBase() + 0x7E5ED64;
        public void SetBrushSize(Vector2D DesiredSize)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, DesiredSize);
            CallRaw("SetBrushSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5EB1C — hookable via Hooks.InstallAt(NativeFunc_SetBrushResourceObject).</summary>
        public static System.IntPtr NativeFunc_SetBrushResourceObject => Memory.ModuleBase() + 0x7E5EB1C;
        public void SetBrushResourceObject(Object ResourceObject)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ResourceObject);
            CallRaw("SetBrushResourceObject", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5E584 — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromTextureDynamic).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromTextureDynamic => Memory.ModuleBase() + 0x7E5E584;
        public void SetBrushFromTextureDynamic(Texture2DDynamic Texture, bool bMatchSize)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Texture);
            __pb.Set<byte>(0x8, (byte)(bMatchSize?1:0));
            CallRaw("SetBrushFromTextureDynamic", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5E794 — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromTexture).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromTexture => Memory.ModuleBase() + 0x7E5E794;
        public void SetBrushFromTexture(Texture2D Texture, bool bMatchSize)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Texture);
            __pb.Set<byte>(0x8, (byte)(bMatchSize?1:0));
            CallRaw("SetBrushFromTexture", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5E35C — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromSoftTexture).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromSoftTexture => Memory.ModuleBase() + 0x7E5E35C;
        public void SetBrushFromSoftTexture(System.IntPtr SoftTexture, bool bMatchSize)
        {
            var __pb = new ParamBuffer(41);
            __pb.Set<System.IntPtr>(0x0, SoftTexture);
            __pb.Set<byte>(0x28, (byte)(bMatchSize?1:0));
            CallRaw("SetBrushFromSoftTexture", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5E234 — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromSoftMaterial).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromSoftMaterial => Memory.ModuleBase() + 0x7E5E234;
        public void SetBrushFromSoftMaterial(System.IntPtr SoftMaterial)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, SoftMaterial);
            CallRaw("SetBrushFromSoftMaterial", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5E4D8 — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromMaterial).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromMaterial => Memory.ModuleBase() + 0x7E5E4D8;
        public void SetBrushFromMaterial(MaterialInterface Material)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Material);
            CallRaw("SetBrushFromMaterial", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5E67C — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromAtlasInterface).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromAtlasInterface => Memory.ModuleBase() + 0x7E5E67C;
        public void SetBrushFromAtlasInterface(UObject AtlasRegion, bool bMatchSize)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, AtlasRegion);
            __pb.Set<byte>(0x10, (byte)(bMatchSize?1:0));
            CallRaw("SetBrushFromAtlasInterface", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5E88C — hookable via Hooks.InstallAt(NativeFunc_SetBrushFromAsset).</summary>
        public static System.IntPtr NativeFunc_SetBrushFromAsset => Memory.ModuleBase() + 0x7E5E88C;
        public void SetBrushFromAsset(SlateBrushAsset Asset)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Asset);
            CallRaw("SetBrushFromAsset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5E938 — hookable via Hooks.InstallAt(NativeFunc_SetBrush).</summary>
        public static System.IntPtr NativeFunc_SetBrush => Memory.ModuleBase() + 0x7E5E938;
        public void SetBrush(SlateBrush InBrush)
        {
            var __pb = new ParamBuffer(136);
            __pb.Set<System.IntPtr>(0x0, InBrush);
            CallRaw("SetBrush", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5E200 — hookable via Hooks.InstallAt(NativeFunc_GetDynamicMaterial).</summary>
        public static System.IntPtr NativeFunc_GetDynamicMaterial => Memory.ModuleBase() + 0x7E5E200;
        public MaterialInstanceDynamic GetDynamicMaterial()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDynamicMaterial", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); }
        }
    }

    public class InputKeySelector : Widget
    {
        public const string UeClassName = "InputKeySelector";
        public InputKeySelector(System.IntPtr ptr) : base(ptr) {}
        public static new InputKeySelector FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InputKeySelector(p);
        public static InputKeySelector FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InputKeySelector(o.Pointer); }
        public static InputKeySelector[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InputKeySelector[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InputKeySelector(a[i].Pointer); return r; }
        public ButtonStyle WidgetStyle => new ButtonStyle(AddrOf(0x108));
        public TextBlockStyle TextStyle => new TextBlockStyle(AddrOf(0x380));
        public InputChord SelectedKey => new InputChord(AddrOf(0x5E8));
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0x608));
        public Margin Margin => new Margin(AddrOf(0x658));
        public LinearColor ColorAndOpacity => new LinearColor(AddrOf(0x668));
        public System.IntPtr KeySelectionText => AddrOf(0x678); // 
        public System.IntPtr NoKeySpecifiedText => AddrOf(0x690); // 
        public bool bAllowModifierKeys { get => Native.GetPropBool(Pointer, "bAllowModifierKeys"); set => Native.SetPropBool(Pointer, "bAllowModifierKeys", value); }
        public bool bAllowGamepadKeys { get => Native.GetPropBool(Pointer, "bAllowGamepadKeys"); set => Native.SetPropBool(Pointer, "bAllowGamepadKeys", value); }
        public TArray<System.IntPtr> EscapeKeys => new TArray<System.IntPtr>(AddrOf(0x6B0)); // TArray<struct>
        public System.IntPtr OnKeySelected => AddrOf(0x6C0); // 
        public System.IntPtr OnIsSelectingKeyChanged => AddrOf(0x6D0); // 
        /// <summary>[Native] thunk RVA 0x7E5FE2C — hookable via Hooks.InstallAt(NativeFunc_SetTextBlockVisibility).</summary>
        public static System.IntPtr NativeFunc_SetTextBlockVisibility => Memory.ModuleBase() + 0x7E5FE2C;
        public void SetTextBlockVisibility(ESlateVisibility InVisibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InVisibility);
            CallRaw("SetTextBlockVisibility", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E60380 — hookable via Hooks.InstallAt(NativeFunc_SetSelectedKey).</summary>
        public static System.IntPtr NativeFunc_SetSelectedKey => Memory.ModuleBase() + 0x7E60380;
        public void SetSelectedKey(InputChord InSelectedKey)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, InSelectedKey);
            CallRaw("SetSelectedKey", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E60060 — hookable via Hooks.InstallAt(NativeFunc_SetNoKeySpecifiedText).</summary>
        public static System.IntPtr NativeFunc_SetNoKeySpecifiedText => Memory.ModuleBase() + 0x7E60060;
        public void SetNoKeySpecifiedText(System.IntPtr InNoKeySpecifiedText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InNoKeySpecifiedText);
            CallRaw("SetNoKeySpecifiedText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E601F0 — hookable via Hooks.InstallAt(NativeFunc_SetKeySelectionText).</summary>
        public static System.IntPtr NativeFunc_SetKeySelectionText => Memory.ModuleBase() + 0x7E601F0;
        public void SetKeySelectionText(System.IntPtr InKeySelectionText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InKeySelectionText);
            CallRaw("SetKeySelectionText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5FCDC — hookable via Hooks.InstallAt(NativeFunc_SetEscapeKeys).</summary>
        public static System.IntPtr NativeFunc_SetEscapeKeys => Memory.ModuleBase() + 0x7E5FCDC;
        public void SetEscapeKeys(System.IntPtr InKeys)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InKeys);
            CallRaw("SetEscapeKeys", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5FFB4 — hookable via Hooks.InstallAt(NativeFunc_SetAllowModifierKeys).</summary>
        public static System.IntPtr NativeFunc_SetAllowModifierKeys => Memory.ModuleBase() + 0x7E5FFB4;
        public void SetAllowModifierKeys(bool bInAllowModifierKeys)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInAllowModifierKeys?1:0));
            CallRaw("SetAllowModifierKeys", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5FF08 — hookable via Hooks.InstallAt(NativeFunc_SetAllowGamepadKeys).</summary>
        public static System.IntPtr NativeFunc_SetAllowGamepadKeys => Memory.ModuleBase() + 0x7E5FF08;
        public void SetAllowGamepadKeys(bool bInAllowGamepadKeys)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInAllowGamepadKeys?1:0));
            CallRaw("SetAllowGamepadKeys", __pb.Bytes);
        }
        public void OnKeySelected__DelegateSignature(InputChord SelectedKey)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, SelectedKey);
            CallRaw("OnKeySelected__DelegateSignature", __pb.Bytes);
        }
        public void OnIsSelectingKeyChanged__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnIsSelectingKeyChanged__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E5FED0 — hookable via Hooks.InstallAt(NativeFunc_GetIsSelectingKey).</summary>
        public static System.IntPtr NativeFunc_GetIsSelectingKey => Memory.ModuleBase() + 0x7E5FED0;
        public bool GetIsSelectingKey()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetIsSelectingKey", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class Int32Binding : PropertyBinding
    {
        public const string UeClassName = "Int32Binding";
        public Int32Binding(System.IntPtr ptr) : base(ptr) {}
        public static new Int32Binding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Int32Binding(p);
        public static Int32Binding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Int32Binding(o.Pointer); }
        public static Int32Binding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Int32Binding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Int32Binding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E61304 — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7E61304;
        public int GetValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetValue", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
    }

    public class InvalidationBox : ContentWidget
    {
        public const string UeClassName = "InvalidationBox";
        public InvalidationBox(System.IntPtr ptr) : base(ptr) {}
        public static new InvalidationBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InvalidationBox(p);
        public static InvalidationBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InvalidationBox(o.Pointer); }
        public static InvalidationBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InvalidationBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InvalidationBox(a[i].Pointer); return r; }
        public bool bCanCache { get => Native.GetPropBool(Pointer, "bCanCache"); set => Native.SetPropBool(Pointer, "bCanCache", value); }
        public bool CacheRelativeTransforms { get => Native.GetPropBool(Pointer, "CacheRelativeTransforms"); set => Native.SetPropBool(Pointer, "CacheRelativeTransforms", value); }
        /// <summary>[Native] thunk RVA 0x7E61AC8 — hookable via Hooks.InstallAt(NativeFunc_SetCanCache).</summary>
        public static System.IntPtr NativeFunc_SetCanCache => Memory.ModuleBase() + 0x7E61AC8;
        public void SetCanCache(bool CanCache)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(CanCache?1:0));
            CallRaw("SetCanCache", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E61BAC — hookable via Hooks.InstallAt(NativeFunc_InvalidateCache).</summary>
        public static System.IntPtr NativeFunc_InvalidateCache => Memory.ModuleBase() + 0x7E61BAC;
        public void InvalidateCache()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InvalidateCache", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E61B74 — hookable via Hooks.InstallAt(NativeFunc_GetCanCache).</summary>
        public static System.IntPtr NativeFunc_GetCanCache => Memory.ModuleBase() + 0x7E61B74;
        public bool GetCanCache()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetCanCache", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class UserListEntry : Interface
    {
        public const string UeClassName = "UserListEntry";
        public UserListEntry(System.IntPtr ptr) : base(ptr) {}
        public static new UserListEntry FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UserListEntry(p);
        public static UserListEntry FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UserListEntry(o.Pointer); }
        public static UserListEntry[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UserListEntry[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UserListEntry(a[i].Pointer); return r; }
        public void BP_OnItemSelectionChanged(bool bIsSelected)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bIsSelected?1:0));
            CallRaw("BP_OnItemSelectionChanged", __pb.Bytes);
        }
        public void BP_OnItemExpansionChanged(bool bIsExpanded)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bIsExpanded?1:0));
            CallRaw("BP_OnItemExpansionChanged", __pb.Bytes);
        }
        public void BP_OnEntryReleased()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BP_OnEntryReleased", __pb.Bytes);
        }
    }

    public class UserListEntryLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "UserListEntryLibrary";
        public UserListEntryLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new UserListEntryLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UserListEntryLibrary(p);
        public static UserListEntryLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UserListEntryLibrary(o.Pointer); }
        public static UserListEntryLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UserListEntryLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UserListEntryLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E62BD4 — hookable via Hooks.InstallAt(NativeFunc_IsListItemSelected).</summary>
        public static System.IntPtr NativeFunc_IsListItemSelected => Memory.ModuleBase() + 0x7E62BD4;
        public bool IsListItemSelected(UObject UserListEntry)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, UserListEntry);
            CallRaw("IsListItemSelected", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E62B0C — hookable via Hooks.InstallAt(NativeFunc_IsListItemExpanded).</summary>
        public static System.IntPtr NativeFunc_IsListItemExpanded => Memory.ModuleBase() + 0x7E62B0C;
        public bool IsListItemExpanded(UObject UserListEntry)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, UserListEntry);
            CallRaw("IsListItemExpanded", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E62A48 — hookable via Hooks.InstallAt(NativeFunc_GetOwningListView).</summary>
        public static System.IntPtr NativeFunc_GetOwningListView => Memory.ModuleBase() + 0x7E62A48;
        public ListViewBase GetOwningListView(UObject UserListEntry)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, UserListEntry);
            CallRaw("GetOwningListView", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new ListViewBase(__p); }
        }
    }

    public class UserObjectListEntry : UserListEntry
    {
        public const string UeClassName = "UserObjectListEntry";
        public UserObjectListEntry(System.IntPtr ptr) : base(ptr) {}
        public static new UserObjectListEntry FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UserObjectListEntry(p);
        public static UserObjectListEntry FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UserObjectListEntry(o.Pointer); }
        public static UserObjectListEntry[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UserObjectListEntry[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UserObjectListEntry(a[i].Pointer); return r; }
        public void OnListItemObjectSet(Object ListItemObject)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ListItemObject);
            CallRaw("OnListItemObjectSet", __pb.Bytes);
        }
    }

    public class UserObjectListEntryLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "UserObjectListEntryLibrary";
        public UserObjectListEntryLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new UserObjectListEntryLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UserObjectListEntryLibrary(p);
        public static UserObjectListEntryLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UserObjectListEntryLibrary(o.Pointer); }
        public static UserObjectListEntryLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UserObjectListEntryLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UserObjectListEntryLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E63B14 — hookable via Hooks.InstallAt(NativeFunc_GetListItemObject).</summary>
        public static System.IntPtr NativeFunc_GetListItemObject => Memory.ModuleBase() + 0x7E63B14;
        public Object GetListItemObject(UObject UserObjectListEntry)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, UserObjectListEntry);
            CallRaw("GetListItemObject", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new Object(__p); }
        }
    }

    public class ListViewBase : Widget
    {
        public const string UeClassName = "ListViewBase";
        public ListViewBase(System.IntPtr ptr) : base(ptr) {}
        public static new ListViewBase FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ListViewBase(p);
        public static ListViewBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ListViewBase(o.Pointer); }
        public static ListViewBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ListViewBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ListViewBase(a[i].Pointer); return r; }
        public UserWidget EntryWidgetClass { get { var __p = GetAt<System.IntPtr>(0x108); return __p==System.IntPtr.Zero?null:new UserWidget(__p); } set => SetAt(0x108, value?.Pointer ?? System.IntPtr.Zero); }
        public float WheelScrollMultiplier { get => GetAt<float>(0x110); set => SetAt(0x110, value); }
        public bool bEnableScrollAnimation { get => Native.GetPropBool(Pointer, "bEnableScrollAnimation"); set => Native.SetPropBool(Pointer, "bEnableScrollAnimation", value); }
        public bool bEnableFixedLineOffset { get => Native.GetPropBool(Pointer, "bEnableFixedLineOffset"); set => Native.SetPropBool(Pointer, "bEnableFixedLineOffset", value); }
        public float FixedLineScrollOffset { get => GetAt<float>(0x118); set => SetAt(0x118, value); }
        public System.IntPtr BP_OnEntryGenerated => AddrOf(0x120); // 
        public System.IntPtr BP_OnEntryReleased => AddrOf(0x130); // 
        public UserWidgetPool EntryWidgetPool => new UserWidgetPool(AddrOf(0x140));
        /// <summary>[Native] thunk RVA 0x7E6636C — hookable via Hooks.InstallAt(NativeFunc_SetWheelScrollMultiplier).</summary>
        public static System.IntPtr NativeFunc_SetWheelScrollMultiplier => Memory.ModuleBase() + 0x7E6636C;
        public void SetWheelScrollMultiplier(float NewWheelScrollMultiplier)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewWheelScrollMultiplier);
            CallRaw("SetWheelScrollMultiplier", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E66410 — hookable via Hooks.InstallAt(NativeFunc_SetScrollOffset).</summary>
        public static System.IntPtr NativeFunc_SetScrollOffset => Memory.ModuleBase() + 0x7E66410;
        public void SetScrollOffset(float InScrollOffset)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InScrollOffset);
            CallRaw("SetScrollOffset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E662C8 — hookable via Hooks.InstallAt(NativeFunc_SetScrollbarVisibility).</summary>
        public static System.IntPtr NativeFunc_SetScrollbarVisibility => Memory.ModuleBase() + 0x7E662C8;
        public void SetScrollbarVisibility(ESlateVisibility InVisibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)InVisibility);
            CallRaw("SetScrollbarVisibility", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E664C8 — hookable via Hooks.InstallAt(NativeFunc_ScrollToTop).</summary>
        public static System.IntPtr NativeFunc_ScrollToTop => Memory.ModuleBase() + 0x7E664C8;
        public void ScrollToTop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ScrollToTop", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E664B4 — hookable via Hooks.InstallAt(NativeFunc_ScrollToBottom).</summary>
        public static System.IntPtr NativeFunc_ScrollToBottom => Memory.ModuleBase() + 0x7E664B4;
        public void ScrollToBottom()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ScrollToBottom", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E662B4 — hookable via Hooks.InstallAt(NativeFunc_RequestRefresh).</summary>
        public static System.IntPtr NativeFunc_RequestRefresh => Memory.ModuleBase() + 0x7E662B4;
        public void RequestRefresh()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RequestRefresh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E664DC — hookable via Hooks.InstallAt(NativeFunc_RegenerateAllEntries).</summary>
        public static System.IntPtr NativeFunc_RegenerateAllEntries => Memory.ModuleBase() + 0x7E664DC;
        public void RegenerateAllEntries()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RegenerateAllEntries", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E664F0 — hookable via Hooks.InstallAt(NativeFunc_GetDisplayedEntryWidgets).</summary>
        public static System.IntPtr NativeFunc_GetDisplayedEntryWidgets => Memory.ModuleBase() + 0x7E664F0;
        public System.IntPtr GetDisplayedEntryWidgets()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetDisplayedEntryWidgets", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class ListView : ListViewBase
    {
        public const string UeClassName = "ListView";
        public ListView(System.IntPtr ptr) : base(ptr) {}
        public static new ListView FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ListView(p);
        public static ListView FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ListView(o.Pointer); }
        public static ListView[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ListView[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ListView(a[i].Pointer); return r; }
        public byte Orientation { get => GetAt<byte>(0x2D8); set => SetAt(0x2D8, value); }
        public byte SelectionMode { get => GetAt<byte>(0x2D9); set => SetAt(0x2D9, value); }
        public EConsumeMouseWheel ConsumeMouseWheel { get => (EConsumeMouseWheel)GetAt<byte>(0x2DA); set => SetAt(0x2DA, (byte)value); }
        public bool bClearSelectionOnClick { get => Native.GetPropBool(Pointer, "bClearSelectionOnClick"); set => Native.SetPropBool(Pointer, "bClearSelectionOnClick", value); }
        public bool bIsFocusable { get => Native.GetPropBool(Pointer, "bIsFocusable"); set => Native.SetPropBool(Pointer, "bIsFocusable", value); }
        public float EntrySpacing { get => GetAt<float>(0x2E0); set => SetAt(0x2E0, value); }
        public bool bReturnFocusToSelection { get => Native.GetPropBool(Pointer, "bReturnFocusToSelection"); set => Native.SetPropBool(Pointer, "bReturnFocusToSelection", value); }
        public TArray<System.IntPtr> ListItems => new TArray<System.IntPtr>(AddrOf(0x2E8)); // TArray<UObject*>
        public System.IntPtr BP_OnEntryInitialized => AddrOf(0x308); // 
        public System.IntPtr BP_OnItemClicked => AddrOf(0x318); // 
        public System.IntPtr BP_OnItemDoubleClicked => AddrOf(0x328); // 
        public System.IntPtr BP_OnItemIsHoveredChanged => AddrOf(0x338); // 
        public System.IntPtr BP_OnItemSelectionChanged => AddrOf(0x348); // 
        public System.IntPtr BP_OnItemScrolledIntoView => AddrOf(0x358); // 
        /// <summary>[Native] thunk RVA 0x7E64E78 — hookable via Hooks.InstallAt(NativeFunc_SetSelectionMode).</summary>
        public static System.IntPtr NativeFunc_SetSelectionMode => Memory.ModuleBase() + 0x7E64E78;
        public void SetSelectionMode(byte SelectionMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, SelectionMode);
            CallRaw("SetSelectionMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E64CF8 — hookable via Hooks.InstallAt(NativeFunc_SetSelectedIndex).</summary>
        public static System.IntPtr NativeFunc_SetSelectedIndex => Memory.ModuleBase() + 0x7E64CF8;
        public void SetSelectedIndex(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("SetSelectedIndex", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E64D9C — hookable via Hooks.InstallAt(NativeFunc_ScrollIndexIntoView).</summary>
        public static System.IntPtr NativeFunc_ScrollIndexIntoView => Memory.ModuleBase() + 0x7E64D9C;
        public void ScrollIndexIntoView(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("ScrollIndexIntoView", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E650BC — hookable via Hooks.InstallAt(NativeFunc_RemoveItem).</summary>
        public static System.IntPtr NativeFunc_RemoveItem => Memory.ModuleBase() + 0x7E650BC;
        public void RemoveItem(Object Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("RemoveItem", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E64C54 — hookable via Hooks.InstallAt(NativeFunc_NavigateToIndex).</summary>
        public static System.IntPtr NativeFunc_NavigateToIndex => Memory.ModuleBase() + 0x7E64C54;
        public void NavigateToIndex(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("NavigateToIndex", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E64E40 — hookable via Hooks.InstallAt(NativeFunc_IsRefreshPending).</summary>
        public static System.IntPtr NativeFunc_IsRefreshPending => Memory.ModuleBase() + 0x7E64E40;
        public bool IsRefreshPending()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsRefreshPending", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E64FDC — hookable via Hooks.InstallAt(NativeFunc_GetNumItems).</summary>
        public static System.IntPtr NativeFunc_GetNumItems => Memory.ModuleBase() + 0x7E64FDC;
        public int GetNumItems()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumItems", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E65204 — hookable via Hooks.InstallAt(NativeFunc_GetListItems).</summary>
        public static System.IntPtr NativeFunc_GetListItems => Memory.ModuleBase() + 0x7E65204;
        public System.IntPtr GetListItems()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetListItems", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E65010 — hookable via Hooks.InstallAt(NativeFunc_GetItemAt).</summary>
        public static System.IntPtr NativeFunc_GetItemAt => Memory.ModuleBase() + 0x7E65010;
        public Object GetItemAt(int Index)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Index);
            CallRaw("GetItemAt", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new Object(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E64F30 — hookable via Hooks.InstallAt(NativeFunc_GetIndexForItem).</summary>
        public static System.IntPtr NativeFunc_GetIndexForItem => Memory.ModuleBase() + 0x7E64F30;
        public int GetIndexForItem(Object Item)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, Item);
            CallRaw("GetIndexForItem", __pb.Bytes);
            return __pb.Get<int>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7E64F1C — hookable via Hooks.InstallAt(NativeFunc_ClearListItems).</summary>
        public static System.IntPtr NativeFunc_ClearListItems => Memory.ModuleBase() + 0x7E64F1C;
        public void ClearListItems()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearListItems", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E64BB0 — hookable via Hooks.InstallAt(NativeFunc_BP_SetSelectedItem).</summary>
        public static System.IntPtr NativeFunc_BP_SetSelectedItem => Memory.ModuleBase() + 0x7E64BB0;
        public void BP_SetSelectedItem(Object Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("BP_SetSelectedItem", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E646E0 — hookable via Hooks.InstallAt(NativeFunc_BP_SetListItems).</summary>
        public static System.IntPtr NativeFunc_BP_SetListItems => Memory.ModuleBase() + 0x7E646E0;
        public void BP_SetListItems(System.IntPtr InListItems)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InListItems);
            CallRaw("BP_SetListItems", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E64AC0 — hookable via Hooks.InstallAt(NativeFunc_BP_SetItemSelection).</summary>
        public static System.IntPtr NativeFunc_BP_SetItemSelection => Memory.ModuleBase() + 0x7E64AC0;
        public void BP_SetItemSelection(Object Item, bool bSelected)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Item);
            __pb.Set<byte>(0x8, (byte)(bSelected?1:0));
            CallRaw("BP_SetItemSelection", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E647B4 — hookable via Hooks.InstallAt(NativeFunc_BP_ScrollItemIntoView).</summary>
        public static System.IntPtr NativeFunc_BP_ScrollItemIntoView => Memory.ModuleBase() + 0x7E647B4;
        public void BP_ScrollItemIntoView(Object Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("BP_ScrollItemIntoView", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E64858 — hookable via Hooks.InstallAt(NativeFunc_BP_NavigateToItem).</summary>
        public static System.IntPtr NativeFunc_BP_NavigateToItem => Memory.ModuleBase() + 0x7E64858;
        public void BP_NavigateToItem(Object Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("BP_NavigateToItem", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E648FC — hookable via Hooks.InstallAt(NativeFunc_BP_IsItemVisible).</summary>
        public static System.IntPtr NativeFunc_BP_IsItemVisible => Memory.ModuleBase() + 0x7E648FC;
        public bool BP_IsItemVisible(Object Item)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Item);
            CallRaw("BP_IsItemVisible", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E649AC — hookable via Hooks.InstallAt(NativeFunc_BP_GetSelectedItems).</summary>
        public static System.IntPtr NativeFunc_BP_GetSelectedItems => Memory.ModuleBase() + 0x7E649AC;
        public bool BP_GetSelectedItems(System.IntPtr Items)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, Items);
            CallRaw("BP_GetSelectedItems", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E646AC — hookable via Hooks.InstallAt(NativeFunc_BP_GetSelectedItem).</summary>
        public static System.IntPtr NativeFunc_BP_GetSelectedItem => Memory.ModuleBase() + 0x7E646AC;
        public Object BP_GetSelectedItem()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("BP_GetSelectedItem", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Object(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E64A78 — hookable via Hooks.InstallAt(NativeFunc_BP_GetNumItemsSelected).</summary>
        public static System.IntPtr NativeFunc_BP_GetNumItemsSelected => Memory.ModuleBase() + 0x7E64A78;
        public int BP_GetNumItemsSelected()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("BP_GetNumItemsSelected", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E64AAC — hookable via Hooks.InstallAt(NativeFunc_BP_ClearSelection).</summary>
        public static System.IntPtr NativeFunc_BP_ClearSelection => Memory.ModuleBase() + 0x7E64AAC;
        public void BP_ClearSelection()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BP_ClearSelection", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E647A0 — hookable via Hooks.InstallAt(NativeFunc_BP_CancelScrollIntoView).</summary>
        public static System.IntPtr NativeFunc_BP_CancelScrollIntoView => Memory.ModuleBase() + 0x7E647A0;
        public void BP_CancelScrollIntoView()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BP_CancelScrollIntoView", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E65160 — hookable via Hooks.InstallAt(NativeFunc_AddItem).</summary>
        public static System.IntPtr NativeFunc_AddItem => Memory.ModuleBase() + 0x7E65160;
        public void AddItem(Object Item)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Item);
            CallRaw("AddItem", __pb.Bytes);
        }
    }

    public class ListViewDesignerPreviewItem : Object
    {
        public const string UeClassName = "ListViewDesignerPreviewItem";
        public ListViewDesignerPreviewItem(System.IntPtr ptr) : base(ptr) {}
        public static new ListViewDesignerPreviewItem FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ListViewDesignerPreviewItem(p);
        public static ListViewDesignerPreviewItem FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ListViewDesignerPreviewItem(o.Pointer); }
        public static ListViewDesignerPreviewItem[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ListViewDesignerPreviewItem[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ListViewDesignerPreviewItem(a[i].Pointer); return r; }
    }

    public class MenuAnchor : ContentWidget
    {
        public const string UeClassName = "MenuAnchor";
        public MenuAnchor(System.IntPtr ptr) : base(ptr) {}
        public static new MenuAnchor FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MenuAnchor(p);
        public static MenuAnchor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MenuAnchor(o.Pointer); }
        public static MenuAnchor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MenuAnchor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MenuAnchor(a[i].Pointer); return r; }
        public UserWidget MenuClass { get { var __p = GetAt<System.IntPtr>(0x120); return __p==System.IntPtr.Zero?null:new UserWidget(__p); } set => SetAt(0x120, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr OnGetMenuContentEvent => AddrOf(0x128); // 
        public byte Placement { get => GetAt<byte>(0x138); set => SetAt(0x138, value); }
        public bool bFitInWindow { get => Native.GetPropBool(Pointer, "bFitInWindow"); set => Native.SetPropBool(Pointer, "bFitInWindow", value); }
        public bool ShouldDeferPaintingAfterWindowContent { get => Native.GetPropBool(Pointer, "ShouldDeferPaintingAfterWindowContent"); set => Native.SetPropBool(Pointer, "ShouldDeferPaintingAfterWindowContent", value); }
        public bool UseApplicationMenuStack { get => Native.GetPropBool(Pointer, "UseApplicationMenuStack"); set => Native.SetPropBool(Pointer, "UseApplicationMenuStack", value); }
        public System.IntPtr OnMenuOpenChanged => AddrOf(0x140); // 
        /// <summary>[Native] thunk RVA 0x7E67894 — hookable via Hooks.InstallAt(NativeFunc_ToggleOpen).</summary>
        public static System.IntPtr NativeFunc_ToggleOpen => Memory.ModuleBase() + 0x7E67894;
        public void ToggleOpen(bool bFocusOnOpen)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bFocusOnOpen?1:0));
            CallRaw("ToggleOpen", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E67764 — hookable via Hooks.InstallAt(NativeFunc_ShouldOpenDueToClick).</summary>
        public static System.IntPtr NativeFunc_ShouldOpenDueToClick => Memory.ModuleBase() + 0x7E67764;
        public bool ShouldOpenDueToClick()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("ShouldOpenDueToClick", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E679EC — hookable via Hooks.InstallAt(NativeFunc_SetPlacement).</summary>
        public static System.IntPtr NativeFunc_SetPlacement => Memory.ModuleBase() + 0x7E679EC;
        public void SetPlacement(byte InPlacement)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InPlacement);
            CallRaw("SetPlacement", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E677E8 — hookable via Hooks.InstallAt(NativeFunc_Open).</summary>
        public static System.IntPtr NativeFunc_Open => Memory.ModuleBase() + 0x7E677E8;
        public void Open(bool bFocusMenu)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bFocusMenu?1:0));
            CallRaw("Open", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6779C — hookable via Hooks.InstallAt(NativeFunc_IsOpen).</summary>
        public static System.IntPtr NativeFunc_IsOpen => Memory.ModuleBase() + 0x7E6779C;
        public bool IsOpen()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsOpen", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E676F8 — hookable via Hooks.InstallAt(NativeFunc_HasOpenSubMenus).</summary>
        public static System.IntPtr NativeFunc_HasOpenSubMenus => Memory.ModuleBase() + 0x7E676F8;
        public bool HasOpenSubMenus()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasOpenSubMenus", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E67730 — hookable via Hooks.InstallAt(NativeFunc_GetMenuPosition).</summary>
        public static System.IntPtr NativeFunc_GetMenuPosition => Memory.ModuleBase() + 0x7E67730;
        public Vector2D GetMenuPosition()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetMenuPosition", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E67940 — hookable via Hooks.InstallAt(NativeFunc_FitInWindow).</summary>
        public static System.IntPtr NativeFunc_FitInWindow => Memory.ModuleBase() + 0x7E67940;
        public void FitInWindow(bool bFit)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bFit?1:0));
            CallRaw("FitInWindow", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E677D4 — hookable via Hooks.InstallAt(NativeFunc_Close).</summary>
        public static System.IntPtr NativeFunc_Close => Memory.ModuleBase() + 0x7E677D4;
        public void Close()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Close", __pb.Bytes);
        }
    }

    public class MouseCursorBinding : PropertyBinding
    {
        public const string UeClassName = "MouseCursorBinding";
        public MouseCursorBinding(System.IntPtr ptr) : base(ptr) {}
        public static new MouseCursorBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MouseCursorBinding(p);
        public static MouseCursorBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MouseCursorBinding(o.Pointer); }
        public static MouseCursorBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MouseCursorBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MouseCursorBinding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E6854C — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7E6854C;
        public byte GetValue()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetValue", __pb.Bytes);
            return __pb.Get<byte>(0x0);
        }
    }

    public class MovieScene2DTransformSection : MovieSceneSection
    {
        public const string UeClassName = "MovieScene2DTransformSection";
        public MovieScene2DTransformSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene2DTransformSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene2DTransformSection(p);
        public static MovieScene2DTransformSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene2DTransformSection(o.Pointer); }
        public static MovieScene2DTransformSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene2DTransformSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene2DTransformSection(a[i].Pointer); return r; }
        public MovieScene2DTransformMask TransformMask => new MovieScene2DTransformMask(AddrOf(0xD8));
        public System.IntPtr Translation => AddrOf(0xE0); // [2] static array
        public MovieSceneFloatChannel Rotation => new MovieSceneFloatChannel(AddrOf(0x220));
        public System.IntPtr Scale => AddrOf(0x2C0); // [2] static array
        public System.IntPtr Shear => AddrOf(0x400); // [2] static array
    }

    public class MovieScene2DTransformTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieScene2DTransformTrack";
        public MovieScene2DTransformTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieScene2DTransformTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieScene2DTransformTrack(p);
        public static MovieScene2DTransformTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieScene2DTransformTrack(o.Pointer); }
        public static MovieScene2DTransformTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieScene2DTransformTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieScene2DTransformTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneMarginSection : MovieSceneSection
    {
        public const string UeClassName = "MovieSceneMarginSection";
        public MovieSceneMarginSection(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneMarginSection FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneMarginSection(p);
        public static MovieSceneMarginSection FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneMarginSection(o.Pointer); }
        public static MovieSceneMarginSection[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneMarginSection[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneMarginSection(a[i].Pointer); return r; }
        public MovieSceneFloatChannel TopCurve => new MovieSceneFloatChannel(AddrOf(0xD8));
        public MovieSceneFloatChannel LeftCurve => new MovieSceneFloatChannel(AddrOf(0x178));
        public MovieSceneFloatChannel RightCurve => new MovieSceneFloatChannel(AddrOf(0x218));
        public MovieSceneFloatChannel BottomCurve => new MovieSceneFloatChannel(AddrOf(0x2B8));
    }

    public class MovieSceneMarginTrack : MovieScenePropertyTrack
    {
        public const string UeClassName = "MovieSceneMarginTrack";
        public MovieSceneMarginTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneMarginTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneMarginTrack(p);
        public static MovieSceneMarginTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneMarginTrack(o.Pointer); }
        public static MovieSceneMarginTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneMarginTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneMarginTrack(a[i].Pointer); return r; }
    }

    public class MovieSceneWidgetMaterialTrack : MovieSceneMaterialTrack
    {
        public const string UeClassName = "MovieSceneWidgetMaterialTrack";
        public MovieSceneWidgetMaterialTrack(System.IntPtr ptr) : base(ptr) {}
        public static new MovieSceneWidgetMaterialTrack FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MovieSceneWidgetMaterialTrack(p);
        public static MovieSceneWidgetMaterialTrack FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MovieSceneWidgetMaterialTrack(o.Pointer); }
        public static MovieSceneWidgetMaterialTrack[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MovieSceneWidgetMaterialTrack[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MovieSceneWidgetMaterialTrack(a[i].Pointer); return r; }
        public TArray<System.IntPtr> BrushPropertyNamePath => new TArray<System.IntPtr>(AddrOf(0x68)); // TArray<FName>
        public string TrackName => Native.GetPropName(Pointer, "TrackName"); // FName
        public FName TrackName_Raw { get => GetAt<FName>(0x78); set => SetAt(0x78, value); }
    }

    public class TextLayoutWidget : Widget
    {
        public const string UeClassName = "TextLayoutWidget";
        public TextLayoutWidget(System.IntPtr ptr) : base(ptr) {}
        public static new TextLayoutWidget FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TextLayoutWidget(p);
        public static TextLayoutWidget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TextLayoutWidget(o.Pointer); }
        public static TextLayoutWidget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TextLayoutWidget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TextLayoutWidget(a[i].Pointer); return r; }
        public ShapedTextOptions ShapedTextOptions => new ShapedTextOptions(AddrOf(0x108));
        public byte Justification { get => GetAt<byte>(0x10B); set => SetAt(0x10B, value); }
        public ETextWrappingPolicy WrappingPolicy { get => (ETextWrappingPolicy)GetAt<byte>(0x10C); set => SetAt(0x10C, (byte)value); }
        public bool AutoWrapText { get => Native.GetPropBool(Pointer, "AutoWrapText"); set => Native.SetPropBool(Pointer, "AutoWrapText", value); }
        public float WrapTextAt { get => GetAt<float>(0x110); set => SetAt(0x110, value); }
        public Margin Margin => new Margin(AddrOf(0x114));
        public float LineHeightPercentage { get => GetAt<float>(0x124); set => SetAt(0x124, value); }
        /// <summary>[Native] thunk RVA 0x7E88194 — hookable via Hooks.InstallAt(NativeFunc_SetJustification).</summary>
        public static System.IntPtr NativeFunc_SetJustification => Memory.ModuleBase() + 0x7E88194;
        public void SetJustification(byte InJustification)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InJustification);
            CallRaw("SetJustification", __pb.Bytes);
        }
    }

    public class MultiLineEditableText : TextLayoutWidget
    {
        public const string UeClassName = "MultiLineEditableText";
        public MultiLineEditableText(System.IntPtr ptr) : base(ptr) {}
        public static new MultiLineEditableText FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MultiLineEditableText(p);
        public static MultiLineEditableText FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MultiLineEditableText(o.Pointer); }
        public static MultiLineEditableText[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MultiLineEditableText[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MultiLineEditableText(a[i].Pointer); return r; }
        public System.IntPtr Text => AddrOf(0x128); // 
        public System.IntPtr HintText => AddrOf(0x140); // 
        public System.IntPtr HintTextDelegate => AddrOf(0x158); // 
        public TextBlockStyle WidgetStyle => new TextBlockStyle(AddrOf(0x168));
        public bool bIsReadOnly { get => Native.GetPropBool(Pointer, "bIsReadOnly"); set => Native.SetPropBool(Pointer, "bIsReadOnly", value); }
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0x3D8));
        public bool SelectAllTextWhenFocused { get => Native.GetPropBool(Pointer, "SelectAllTextWhenFocused"); set => Native.SetPropBool(Pointer, "SelectAllTextWhenFocused", value); }
        public bool ClearTextSelectionOnFocusLoss { get => Native.GetPropBool(Pointer, "ClearTextSelectionOnFocusLoss"); set => Native.SetPropBool(Pointer, "ClearTextSelectionOnFocusLoss", value); }
        public bool RevertTextOnEscape { get => Native.GetPropBool(Pointer, "RevertTextOnEscape"); set => Native.SetPropBool(Pointer, "RevertTextOnEscape", value); }
        public bool ClearKeyboardFocusOnCommit { get => Native.GetPropBool(Pointer, "ClearKeyboardFocusOnCommit"); set => Native.SetPropBool(Pointer, "ClearKeyboardFocusOnCommit", value); }
        public bool AllowContextMenu { get => Native.GetPropBool(Pointer, "AllowContextMenu"); set => Native.SetPropBool(Pointer, "AllowContextMenu", value); }
        public VirtualKeyboardOptions VirtualKeyboardOptions => new VirtualKeyboardOptions(AddrOf(0x42D));
        public EVirtualKeyboardDismissAction VirtualKeyboardDismissAction { get => (EVirtualKeyboardDismissAction)GetAt<byte>(0x42E); set => SetAt(0x42E, (byte)value); }
        public System.IntPtr OnTextChanged => AddrOf(0x430); // 
        public System.IntPtr OnTextCommitted => AddrOf(0x440); // 
        /// <summary>[Native] thunk RVA 0x7E6D374 — hookable via Hooks.InstallAt(NativeFunc_SetWidgetStyle).</summary>
        public static System.IntPtr NativeFunc_SetWidgetStyle => Memory.ModuleBase() + 0x7E6D374;
        public void SetWidgetStyle(TextBlockStyle InWidgetStyle)
        {
            var __pb = new ParamBuffer(616);
            __pb.Set<System.IntPtr>(0x0, InWidgetStyle);
            CallRaw("SetWidgetStyle", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6D748 — hookable via Hooks.InstallAt(NativeFunc_SetText).</summary>
        public static System.IntPtr NativeFunc_SetText => Memory.ModuleBase() + 0x7E6D748;
        public void SetText(System.IntPtr InText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InText);
            CallRaw("SetText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6D434 — hookable via Hooks.InstallAt(NativeFunc_SetIsReadOnly).</summary>
        public static System.IntPtr NativeFunc_SetIsReadOnly => Memory.ModuleBase() + 0x7E6D434;
        public void SetIsReadOnly(bool bReadOnly)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bReadOnly?1:0));
            CallRaw("SetIsReadOnly", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6D4E0 — hookable via Hooks.InstallAt(NativeFunc_SetHintText).</summary>
        public static System.IntPtr NativeFunc_SetHintText => Memory.ModuleBase() + 0x7E6D4E0;
        public void SetHintText(System.IntPtr InHintText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InHintText);
            CallRaw("SetHintText", __pb.Bytes);
        }
        public void OnMultiLineEditableTextCommittedEvent__DelegateSignature(System.IntPtr Text, byte CommitMethod)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, Text);
            __pb.Set(0x18, CommitMethod);
            CallRaw("OnMultiLineEditableTextCommittedEvent__DelegateSignature", __pb.Bytes);
        }
        public void OnMultiLineEditableTextChangedEvent__DelegateSignature(System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Text);
            CallRaw("OnMultiLineEditableTextChangedEvent__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6D8D8 — hookable via Hooks.InstallAt(NativeFunc_GetText).</summary>
        public static System.IntPtr NativeFunc_GetText => Memory.ModuleBase() + 0x7E6D8D8;
        public System.IntPtr GetText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetText", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E6D670 — hookable via Hooks.InstallAt(NativeFunc_GetHintText).</summary>
        public static System.IntPtr NativeFunc_GetHintText => Memory.ModuleBase() + 0x7E6D670;
        public System.IntPtr GetHintText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetHintText", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class MultiLineEditableTextBox : TextLayoutWidget
    {
        public const string UeClassName = "MultiLineEditableTextBox";
        public MultiLineEditableTextBox(System.IntPtr ptr) : base(ptr) {}
        public static new MultiLineEditableTextBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MultiLineEditableTextBox(p);
        public static MultiLineEditableTextBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MultiLineEditableTextBox(o.Pointer); }
        public static MultiLineEditableTextBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MultiLineEditableTextBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MultiLineEditableTextBox(a[i].Pointer); return r; }
        public System.IntPtr Text => AddrOf(0x128); // 
        public System.IntPtr HintText => AddrOf(0x140); // 
        public System.IntPtr HintTextDelegate => AddrOf(0x158); // 
        public EditableTextBoxStyle WidgetStyle => new EditableTextBoxStyle(AddrOf(0x168));
        public TextBlockStyle TextStyle => new TextBlockStyle(AddrOf(0x958));
        public bool bIsReadOnly { get => Native.GetPropBool(Pointer, "bIsReadOnly"); set => Native.SetPropBool(Pointer, "bIsReadOnly", value); }
        public bool AllowContextMenu { get => Native.GetPropBool(Pointer, "AllowContextMenu"); set => Native.SetPropBool(Pointer, "AllowContextMenu", value); }
        public VirtualKeyboardOptions VirtualKeyboardOptions => new VirtualKeyboardOptions(AddrOf(0xBC2));
        public EVirtualKeyboardDismissAction VirtualKeyboardDismissAction { get => (EVirtualKeyboardDismissAction)GetAt<byte>(0xBC3); set => SetAt(0xBC3, (byte)value); }
        public SlateWidgetStyleAsset Style { get { var __p = GetAt<System.IntPtr>(0xBC8); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0xBC8, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0xBD0));
        public LinearColor ForegroundColor => new LinearColor(AddrOf(0xC20));
        public LinearColor BackgroundColor => new LinearColor(AddrOf(0xC30));
        public LinearColor ReadOnlyForegroundColor => new LinearColor(AddrOf(0xC40));
        public System.IntPtr OnTextChanged => AddrOf(0xC50); // 
        public System.IntPtr OnTextCommitted => AddrOf(0xC60); // 
        /// <summary>[Native] thunk RVA 0x7E6E42C — hookable via Hooks.InstallAt(NativeFunc_SetTextStyle).</summary>
        public static System.IntPtr NativeFunc_SetTextStyle => Memory.ModuleBase() + 0x7E6E42C;
        public void SetTextStyle(TextBlockStyle InTextStyle)
        {
            var __pb = new ParamBuffer(616);
            __pb.Set<System.IntPtr>(0x0, InTextStyle);
            CallRaw("SetTextStyle", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6E990 — hookable via Hooks.InstallAt(NativeFunc_SetText).</summary>
        public static System.IntPtr NativeFunc_SetText => Memory.ModuleBase() + 0x7E6E990;
        public void SetText(System.IntPtr InText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InText);
            CallRaw("SetText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6E4EC — hookable via Hooks.InstallAt(NativeFunc_SetIsReadOnly).</summary>
        public static System.IntPtr NativeFunc_SetIsReadOnly => Memory.ModuleBase() + 0x7E6E4EC;
        public void SetIsReadOnly(bool bReadOnly)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bReadOnly?1:0));
            CallRaw("SetIsReadOnly", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6E728 — hookable via Hooks.InstallAt(NativeFunc_SetHintText).</summary>
        public static System.IntPtr NativeFunc_SetHintText => Memory.ModuleBase() + 0x7E6E728;
        public void SetHintText(System.IntPtr InHintText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InHintText);
            CallRaw("SetHintText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6E598 — hookable via Hooks.InstallAt(NativeFunc_SetError).</summary>
        public static System.IntPtr NativeFunc_SetError => Memory.ModuleBase() + 0x7E6E598;
        public void SetError(System.IntPtr InError)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InError);
            CallRaw("SetError", __pb.Bytes);
        }
        public void OnMultiLineEditableTextBoxCommittedEvent__DelegateSignature(System.IntPtr Text, byte CommitMethod)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, Text);
            __pb.Set(0x18, CommitMethod);
            CallRaw("OnMultiLineEditableTextBoxCommittedEvent__DelegateSignature", __pb.Bytes);
        }
        public void OnMultiLineEditableTextBoxChangedEvent__DelegateSignature(System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Text);
            CallRaw("OnMultiLineEditableTextBoxChangedEvent__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E6EB20 — hookable via Hooks.InstallAt(NativeFunc_GetText).</summary>
        public static System.IntPtr NativeFunc_GetText => Memory.ModuleBase() + 0x7E6EB20;
        public System.IntPtr GetText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetText", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E6E8B8 — hookable via Hooks.InstallAt(NativeFunc_GetHintText).</summary>
        public static System.IntPtr NativeFunc_GetHintText => Memory.ModuleBase() + 0x7E6E8B8;
        public System.IntPtr GetHintText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetHintText", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class NamedSlot : ContentWidget
    {
        public const string UeClassName = "NamedSlot";
        public NamedSlot(System.IntPtr ptr) : base(ptr) {}
        public static new NamedSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new NamedSlot(p);
        public static NamedSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NamedSlot(o.Pointer); }
        public static NamedSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NamedSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NamedSlot(a[i].Pointer); return r; }
    }

    public class NamedSlotInterface : Interface
    {
        public const string UeClassName = "NamedSlotInterface";
        public NamedSlotInterface(System.IntPtr ptr) : base(ptr) {}
        public static new NamedSlotInterface FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new NamedSlotInterface(p);
        public static NamedSlotInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NamedSlotInterface(o.Pointer); }
        public static NamedSlotInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NamedSlotInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NamedSlotInterface(a[i].Pointer); return r; }
    }

    public class NativeWidgetHost : Widget
    {
        public const string UeClassName = "NativeWidgetHost";
        public NativeWidgetHost(System.IntPtr ptr) : base(ptr) {}
        public static new NativeWidgetHost FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new NativeWidgetHost(p);
        public static NativeWidgetHost FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NativeWidgetHost(o.Pointer); }
        public static NativeWidgetHost[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NativeWidgetHost[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NativeWidgetHost(a[i].Pointer); return r; }
    }

    public class Overlay : PanelWidget
    {
        public const string UeClassName = "Overlay";
        public Overlay(System.IntPtr ptr) : base(ptr) {}
        public static new Overlay FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Overlay(p);
        public static Overlay FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Overlay(o.Pointer); }
        public static Overlay[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Overlay[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Overlay(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E70A38 — hookable via Hooks.InstallAt(NativeFunc_AddChildToOverlay).</summary>
        public static System.IntPtr NativeFunc_AddChildToOverlay => Memory.ModuleBase() + 0x7E70A38;
        public OverlaySlot AddChildToOverlay(Widget Content)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Content);
            CallRaw("AddChildToOverlay", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new OverlaySlot(__p); }
        }
    }

    public class OverlaySlot : PanelSlot
    {
        public const string UeClassName = "OverlaySlot";
        public OverlaySlot(System.IntPtr ptr) : base(ptr) {}
        public static new OverlaySlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new OverlaySlot(p);
        public static OverlaySlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new OverlaySlot(o.Pointer); }
        public static OverlaySlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new OverlaySlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new OverlaySlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x40));
        public byte HorizontalAlignment { get => GetAt<byte>(0x50); set => SetAt(0x50, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x51); set => SetAt(0x51, value); }
        /// <summary>[Native] thunk RVA 0x7E712BC — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E712BC;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E71404 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E71404;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E71360 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E71360;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class ProgressBar : Widget
    {
        public const string UeClassName = "ProgressBar";
        public ProgressBar(System.IntPtr ptr) : base(ptr) {}
        public static new ProgressBar FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ProgressBar(p);
        public static ProgressBar FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ProgressBar(o.Pointer); }
        public static ProgressBar[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ProgressBar[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ProgressBar(a[i].Pointer); return r; }
        public ProgressBarStyle WidgetStyle => new ProgressBarStyle(AddrOf(0x108));
        public SlateWidgetStyleAsset Style { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset BackgroundImage { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset FillImage { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrushAsset MarqueeImage { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public float Percent { get => GetAt<float>(0x2C8); set => SetAt(0x2C8, value); }
        public byte BarFillType { get => GetAt<byte>(0x2CC); set => SetAt(0x2CC, value); }
        public bool bIsMarquee { get => Native.GetPropBool(Pointer, "bIsMarquee"); set => Native.SetPropBool(Pointer, "bIsMarquee", value); }
        public Vector2D BorderPadding => new Vector2D(AddrOf(0x2D0));
        public System.IntPtr PercentDelegate => AddrOf(0x2D8); // 
        public LinearColor FillColorAndOpacity => new LinearColor(AddrOf(0x2E8));
        public System.IntPtr FillColorAndOpacityDelegate => AddrOf(0x2F8); // 
        /// <summary>[Native] thunk RVA 0x7E73360 — hookable via Hooks.InstallAt(NativeFunc_SetPercent).</summary>
        public static System.IntPtr NativeFunc_SetPercent => Memory.ModuleBase() + 0x7E73360;
        public void SetPercent(float InPercent)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InPercent);
            CallRaw("SetPercent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E73210 — hookable via Hooks.InstallAt(NativeFunc_SetIsMarquee).</summary>
        public static System.IntPtr NativeFunc_SetIsMarquee => Memory.ModuleBase() + 0x7E73210;
        public void SetIsMarquee(bool InbIsMarquee)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InbIsMarquee?1:0));
            CallRaw("SetIsMarquee", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E732BC — hookable via Hooks.InstallAt(NativeFunc_SetFillColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetFillColorAndOpacity => Memory.ModuleBase() + 0x7E732BC;
        public void SetFillColorAndOpacity(LinearColor InColor)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InColor);
            CallRaw("SetFillColorAndOpacity", __pb.Bytes);
        }
    }

    public class RetainerBox : ContentWidget
    {
        public const string UeClassName = "RetainerBox";
        public RetainerBox(System.IntPtr ptr) : base(ptr) {}
        public static new RetainerBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RetainerBox(p);
        public static RetainerBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RetainerBox(o.Pointer); }
        public static RetainerBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RetainerBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RetainerBox(a[i].Pointer); return r; }
        public bool RenderOnInvalidation { get => Native.GetPropBool(Pointer, "RenderOnInvalidation"); set => Native.SetPropBool(Pointer, "RenderOnInvalidation", value); }
        public bool RenderOnPhase { get => Native.GetPropBool(Pointer, "RenderOnPhase"); set => Native.SetPropBool(Pointer, "RenderOnPhase", value); }
        public int Phase { get => GetAt<int>(0x11C); set => SetAt(0x11C, value); }
        public int PhaseCount { get => GetAt<int>(0x120); set => SetAt(0x120, value); }
        public MaterialInterface EffectMaterial { get { var __p = GetAt<System.IntPtr>(0x128); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x128, value?.Pointer ?? System.IntPtr.Zero); }
        public string TextureParameter => Native.GetPropName(Pointer, "TextureParameter"); // FName
        public FName TextureParameter_Raw { get => GetAt<FName>(0x130); set => SetAt(0x130, value); }
        /// <summary>[Native] thunk RVA 0x7E74278 — hookable via Hooks.InstallAt(NativeFunc_SetTextureParameter).</summary>
        public static System.IntPtr NativeFunc_SetTextureParameter => Memory.ModuleBase() + 0x7E74278;
        public void SetTextureParameter(FName TextureParameter)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, TextureParameter);
            CallRaw("SetTextureParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E74408 — hookable via Hooks.InstallAt(NativeFunc_SetRenderingPhase).</summary>
        public static System.IntPtr NativeFunc_SetRenderingPhase => Memory.ModuleBase() + 0x7E74408;
        public void SetRenderingPhase(int RenderPhase, int TotalPhases)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, RenderPhase);
            __pb.Set(0x4, TotalPhases);
            CallRaw("SetRenderingPhase", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7431C — hookable via Hooks.InstallAt(NativeFunc_SetEffectMaterial).</summary>
        public static System.IntPtr NativeFunc_SetEffectMaterial => Memory.ModuleBase() + 0x7E7431C;
        public void SetEffectMaterial(MaterialInterface EffectMaterial)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, EffectMaterial);
            CallRaw("SetEffectMaterial", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E743F4 — hookable via Hooks.InstallAt(NativeFunc_RequestRender).</summary>
        public static System.IntPtr NativeFunc_RequestRender => Memory.ModuleBase() + 0x7E743F4;
        public void RequestRender()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RequestRender", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E743C0 — hookable via Hooks.InstallAt(NativeFunc_GetEffectMaterial).</summary>
        public static System.IntPtr NativeFunc_GetEffectMaterial => Memory.ModuleBase() + 0x7E743C0;
        public MaterialInstanceDynamic GetEffectMaterial()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetEffectMaterial", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); }
        }
    }

    public class RichTextBlock : TextLayoutWidget
    {
        public const string UeClassName = "RichTextBlock";
        public RichTextBlock(System.IntPtr ptr) : base(ptr) {}
        public static new RichTextBlock FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RichTextBlock(p);
        public static RichTextBlock FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RichTextBlock(o.Pointer); }
        public static RichTextBlock[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RichTextBlock[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RichTextBlock(a[i].Pointer); return r; }
        public System.IntPtr Text => AddrOf(0x128); // 
        public DataTable TextStyleSet { get { var __p = GetAt<System.IntPtr>(0x140); return __p==System.IntPtr.Zero?null:new DataTable(__p); } set => SetAt(0x140, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> DecoratorClasses => new TArray<System.IntPtr>(AddrOf(0x148)); // TArray<UClass*>
        public bool bOverrideDefaultStyle { get => Native.GetPropBool(Pointer, "bOverrideDefaultStyle"); set => Native.SetPropBool(Pointer, "bOverrideDefaultStyle", value); }
        public TextBlockStyle DefaultTextStyleOverride => new TextBlockStyle(AddrOf(0x160));
        public float MinDesiredWidth { get => GetAt<float>(0x3C8); set => SetAt(0x3C8, value); }
        public TArray<System.IntPtr> InstanceDecorators => new TArray<System.IntPtr>(AddrOf(0x638)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x7E75000 — hookable via Hooks.InstallAt(NativeFunc_SetTextStyleSet).</summary>
        public static System.IntPtr NativeFunc_SetTextStyleSet => Memory.ModuleBase() + 0x7E75000;
        public void SetTextStyleSet(DataTable NewTextStyleSet)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewTextStyleSet);
            CallRaw("SetTextStyleSet", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E750A4 — hookable via Hooks.InstallAt(NativeFunc_SetText).</summary>
        public static System.IntPtr NativeFunc_SetText => Memory.ModuleBase() + 0x7E750A4;
        public void SetText(System.IntPtr InText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InText);
            CallRaw("SetText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7541C — hookable via Hooks.InstallAt(NativeFunc_SetMinDesiredWidth).</summary>
        public static System.IntPtr NativeFunc_SetMinDesiredWidth => Memory.ModuleBase() + 0x7E7541C;
        public void SetMinDesiredWidth(float InMinDesiredWidth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMinDesiredWidth);
            CallRaw("SetMinDesiredWidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E752B0 — hookable via Hooks.InstallAt(NativeFunc_SetDefaultTextStyle).</summary>
        public static System.IntPtr NativeFunc_SetDefaultTextStyle => Memory.ModuleBase() + 0x7E752B0;
        public void SetDefaultTextStyle(TextBlockStyle InDefaultTextStyle)
        {
            var __pb = new ParamBuffer(616);
            __pb.Set<System.IntPtr>(0x0, InDefaultTextStyle);
            CallRaw("SetDefaultTextStyle", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E754C0 — hookable via Hooks.InstallAt(NativeFunc_SetDefaultStrikeBrush).</summary>
        public static System.IntPtr NativeFunc_SetDefaultStrikeBrush => Memory.ModuleBase() + 0x7E754C0;
        public void SetDefaultStrikeBrush(SlateBrush InStrikeBrush)
        {
            var __pb = new ParamBuffer(136);
            __pb.Set<System.IntPtr>(0x0, InStrikeBrush);
            CallRaw("SetDefaultStrikeBrush", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E75848 — hookable via Hooks.InstallAt(NativeFunc_SetDefaultShadowOffset).</summary>
        public static System.IntPtr NativeFunc_SetDefaultShadowOffset => Memory.ModuleBase() + 0x7E75848;
        public void SetDefaultShadowOffset(Vector2D InShadowOffset)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InShadowOffset);
            CallRaw("SetDefaultShadowOffset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E758E8 — hookable via Hooks.InstallAt(NativeFunc_SetDefaultShadowColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetDefaultShadowColorAndOpacity => Memory.ModuleBase() + 0x7E758E8;
        public void SetDefaultShadowColorAndOpacity(LinearColor InShadowColorAndOpacity)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InShadowColorAndOpacity);
            CallRaw("SetDefaultShadowColorAndOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7569C — hookable via Hooks.InstallAt(NativeFunc_SetDefaultFont).</summary>
        public static System.IntPtr NativeFunc_SetDefaultFont => Memory.ModuleBase() + 0x7E7569C;
        public void SetDefaultFont(SlateFontInfo InFontInfo)
        {
            var __pb = new ParamBuffer(80);
            __pb.Set<System.IntPtr>(0x0, InFontInfo);
            CallRaw("SetDefaultFont", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7598C — hookable via Hooks.InstallAt(NativeFunc_SetDefaultColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetDefaultColorAndOpacity => Memory.ModuleBase() + 0x7E7598C;
        public void SetDefaultColorAndOpacity(SlateColor InColorAndOpacity)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, InColorAndOpacity);
            CallRaw("SetDefaultColorAndOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E75370 — hookable via Hooks.InstallAt(NativeFunc_SetAutoWrapText).</summary>
        public static System.IntPtr NativeFunc_SetAutoWrapText => Memory.ModuleBase() + 0x7E75370;
        public void SetAutoWrapText(bool InAutoTextWrap)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InAutoTextWrap?1:0));
            CallRaw("SetAutoWrapText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E751C4 — hookable via Hooks.InstallAt(NativeFunc_GetText).</summary>
        public static System.IntPtr NativeFunc_GetText => Memory.ModuleBase() + 0x7E751C4;
        public System.IntPtr GetText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetText", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E74F54 — hookable via Hooks.InstallAt(NativeFunc_GetDecoratorByClass).</summary>
        public static System.IntPtr NativeFunc_GetDecoratorByClass => Memory.ModuleBase() + 0x7E74F54;
        public RichTextBlockDecorator GetDecoratorByClass(RichTextBlockDecorator DecoratorClass)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, DecoratorClass);
            CallRaw("GetDecoratorByClass", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new RichTextBlockDecorator(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E7529C — hookable via Hooks.InstallAt(NativeFunc_ClearAllDefaultStyleOverrides).</summary>
        public static System.IntPtr NativeFunc_ClearAllDefaultStyleOverrides => Memory.ModuleBase() + 0x7E7529C;
        public void ClearAllDefaultStyleOverrides()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearAllDefaultStyleOverrides", __pb.Bytes);
        }
    }

    public class RichTextBlockDecorator : Object
    {
        public const string UeClassName = "RichTextBlockDecorator";
        public RichTextBlockDecorator(System.IntPtr ptr) : base(ptr) {}
        public static new RichTextBlockDecorator FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RichTextBlockDecorator(p);
        public static RichTextBlockDecorator FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RichTextBlockDecorator(o.Pointer); }
        public static RichTextBlockDecorator[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RichTextBlockDecorator[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RichTextBlockDecorator(a[i].Pointer); return r; }
    }

    public class RichTextBlockImageDecorator : RichTextBlockDecorator
    {
        public const string UeClassName = "RichTextBlockImageDecorator";
        public RichTextBlockImageDecorator(System.IntPtr ptr) : base(ptr) {}
        public static new RichTextBlockImageDecorator FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RichTextBlockImageDecorator(p);
        public static RichTextBlockImageDecorator FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RichTextBlockImageDecorator(o.Pointer); }
        public static RichTextBlockImageDecorator[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RichTextBlockImageDecorator[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RichTextBlockImageDecorator(a[i].Pointer); return r; }
        public DataTable ImageSet { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new DataTable(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class SafeZone : ContentWidget
    {
        public const string UeClassName = "SafeZone";
        public SafeZone(System.IntPtr ptr) : base(ptr) {}
        public static new SafeZone FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SafeZone(p);
        public static SafeZone FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SafeZone(o.Pointer); }
        public static SafeZone[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SafeZone[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SafeZone(a[i].Pointer); return r; }
        public bool PadLeft { get => Native.GetPropBool(Pointer, "PadLeft"); set => Native.SetPropBool(Pointer, "PadLeft", value); }
        public bool PadRight { get => Native.GetPropBool(Pointer, "PadRight"); set => Native.SetPropBool(Pointer, "PadRight", value); }
        public bool PadTop { get => Native.GetPropBool(Pointer, "PadTop"); set => Native.SetPropBool(Pointer, "PadTop", value); }
        public bool PadBottom { get => Native.GetPropBool(Pointer, "PadBottom"); set => Native.SetPropBool(Pointer, "PadBottom", value); }
        /// <summary>[Native] thunk RVA 0x7E77CCC — hookable via Hooks.InstallAt(NativeFunc_SetSidesToPad).</summary>
        public static System.IntPtr NativeFunc_SetSidesToPad => Memory.ModuleBase() + 0x7E77CCC;
        public void SetSidesToPad(bool InPadLeft, bool InPadRight, bool InPadTop, bool InPadBottom)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<byte>(0x0, (byte)(InPadLeft?1:0));
            __pb.Set<byte>(0x1, (byte)(InPadRight?1:0));
            __pb.Set<byte>(0x2, (byte)(InPadTop?1:0));
            __pb.Set<byte>(0x3, (byte)(InPadBottom?1:0));
            CallRaw("SetSidesToPad", __pb.Bytes);
        }
    }

    public class SafeZoneSlot : PanelSlot
    {
        public const string UeClassName = "SafeZoneSlot";
        public SafeZoneSlot(System.IntPtr ptr) : base(ptr) {}
        public static new SafeZoneSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SafeZoneSlot(p);
        public static SafeZoneSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SafeZoneSlot(o.Pointer); }
        public static SafeZoneSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SafeZoneSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SafeZoneSlot(a[i].Pointer); return r; }
        public bool bIsTitleSafe { get => Native.GetPropBool(Pointer, "bIsTitleSafe"); set => Native.SetPropBool(Pointer, "bIsTitleSafe", value); }
        public Margin SafeAreaScale => new Margin(AddrOf(0x3C));
        public byte HAlign { get => GetAt<byte>(0x4C); set => SetAt(0x4C, value); }
        public byte VAlign { get => GetAt<byte>(0x4D); set => SetAt(0x4D, value); }
        public Margin Padding => new Margin(AddrOf(0x50));
    }

    public class ScaleBox : ContentWidget
    {
        public const string UeClassName = "ScaleBox";
        public ScaleBox(System.IntPtr ptr) : base(ptr) {}
        public static new ScaleBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ScaleBox(p);
        public static ScaleBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ScaleBox(o.Pointer); }
        public static ScaleBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ScaleBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ScaleBox(a[i].Pointer); return r; }
        public byte Stretch { get => GetAt<byte>(0x119); set => SetAt(0x119, value); }
        public byte StretchDirection { get => GetAt<byte>(0x11A); set => SetAt(0x11A, value); }
        public float UserSpecifiedScale { get => GetAt<float>(0x11C); set => SetAt(0x11C, value); }
        public bool IgnoreInheritedScale { get => Native.GetPropBool(Pointer, "IgnoreInheritedScale"); set => Native.SetPropBool(Pointer, "IgnoreInheritedScale", value); }
        /// <summary>[Native] thunk RVA 0x7E78DF8 — hookable via Hooks.InstallAt(NativeFunc_SetUserSpecifiedScale).</summary>
        public static System.IntPtr NativeFunc_SetUserSpecifiedScale => Memory.ModuleBase() + 0x7E78DF8;
        public void SetUserSpecifiedScale(float InUserSpecifiedScale)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InUserSpecifiedScale);
            CallRaw("SetUserSpecifiedScale", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E78E9C — hookable via Hooks.InstallAt(NativeFunc_SetStretchDirection).</summary>
        public static System.IntPtr NativeFunc_SetStretchDirection => Memory.ModuleBase() + 0x7E78E9C;
        public void SetStretchDirection(byte InStretchDirection)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InStretchDirection);
            CallRaw("SetStretchDirection", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E78F40 — hookable via Hooks.InstallAt(NativeFunc_SetStretch).</summary>
        public static System.IntPtr NativeFunc_SetStretch => Memory.ModuleBase() + 0x7E78F40;
        public void SetStretch(byte InStretch)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InStretch);
            CallRaw("SetStretch", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E78D4C — hookable via Hooks.InstallAt(NativeFunc_SetIgnoreInheritedScale).</summary>
        public static System.IntPtr NativeFunc_SetIgnoreInheritedScale => Memory.ModuleBase() + 0x7E78D4C;
        public void SetIgnoreInheritedScale(bool bInIgnoreInheritedScale)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInIgnoreInheritedScale?1:0));
            CallRaw("SetIgnoreInheritedScale", __pb.Bytes);
        }
    }

    public class ScaleBoxSlot : PanelSlot
    {
        public const string UeClassName = "ScaleBoxSlot";
        public ScaleBoxSlot(System.IntPtr ptr) : base(ptr) {}
        public static new ScaleBoxSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ScaleBoxSlot(p);
        public static ScaleBoxSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ScaleBoxSlot(o.Pointer); }
        public static ScaleBoxSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ScaleBoxSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ScaleBoxSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x38));
        public byte HorizontalAlignment { get => GetAt<byte>(0x48); set => SetAt(0x48, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x49); set => SetAt(0x49, value); }
        /// <summary>[Native] thunk RVA 0x7E79AEC — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E79AEC;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E79C34 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E79C34;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E79B90 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E79B90;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class ScrollBar : Widget
    {
        public const string UeClassName = "ScrollBar";
        public ScrollBar(System.IntPtr ptr) : base(ptr) {}
        public static new ScrollBar FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ScrollBar(p);
        public static ScrollBar FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ScrollBar(o.Pointer); }
        public static ScrollBar[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ScrollBar[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ScrollBar(a[i].Pointer); return r; }
        public ScrollBarStyle WidgetStyle => new ScrollBarStyle(AddrOf(0x108));
        public SlateWidgetStyleAsset Style { get { var __p = GetAt<System.IntPtr>(0x5D8); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0x5D8, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bAlwaysShowScrollbar { get => Native.GetPropBool(Pointer, "bAlwaysShowScrollbar"); set => Native.SetPropBool(Pointer, "bAlwaysShowScrollbar", value); }
        public bool bAlwaysShowScrollbarTrack { get => Native.GetPropBool(Pointer, "bAlwaysShowScrollbarTrack"); set => Native.SetPropBool(Pointer, "bAlwaysShowScrollbarTrack", value); }
        public byte Orientation { get => GetAt<byte>(0x5E2); set => SetAt(0x5E2, value); }
        public Vector2D Thickness => new Vector2D(AddrOf(0x5E4));
        public Margin Padding => new Margin(AddrOf(0x5EC));
        /// <summary>[Native] thunk RVA 0x7E7A510 — hookable via Hooks.InstallAt(NativeFunc_SetState).</summary>
        public static System.IntPtr NativeFunc_SetState => Memory.ModuleBase() + 0x7E7A510;
        public void SetState(float InOffsetFraction, float InThumbSizeFraction)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, InOffsetFraction);
            __pb.Set(0x4, InThumbSizeFraction);
            CallRaw("SetState", __pb.Bytes);
        }
    }

    public class ScrollBox : PanelWidget
    {
        public const string UeClassName = "ScrollBox";
        public ScrollBox(System.IntPtr ptr) : base(ptr) {}
        public static new ScrollBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ScrollBox(p);
        public static ScrollBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ScrollBox(o.Pointer); }
        public static ScrollBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ScrollBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ScrollBox(a[i].Pointer); return r; }
        public ScrollBoxStyle WidgetStyle => new ScrollBoxStyle(AddrOf(0x120));
        public ScrollBarStyle WidgetBarStyle => new ScrollBarStyle(AddrOf(0x348));
        public SlateWidgetStyleAsset Style { get { var __p = GetAt<System.IntPtr>(0x818); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0x818, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateWidgetStyleAsset BarStyle { get { var __p = GetAt<System.IntPtr>(0x820); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0x820, value?.Pointer ?? System.IntPtr.Zero); }
        public byte Orientation { get => GetAt<byte>(0x828); set => SetAt(0x828, value); }
        public ESlateVisibility ScrollBarVisibility { get => (ESlateVisibility)GetAt<byte>(0x829); set => SetAt(0x829, (byte)value); }
        public EConsumeMouseWheel ConsumeMouseWheel { get => (EConsumeMouseWheel)GetAt<byte>(0x82A); set => SetAt(0x82A, (byte)value); }
        public Vector2D ScrollbarThickness => new Vector2D(AddrOf(0x82C));
        public Margin ScrollbarPadding => new Margin(AddrOf(0x834));
        public bool AlwaysShowScrollbar { get => Native.GetPropBool(Pointer, "AlwaysShowScrollbar"); set => Native.SetPropBool(Pointer, "AlwaysShowScrollbar", value); }
        public bool AlwaysShowScrollbarTrack { get => Native.GetPropBool(Pointer, "AlwaysShowScrollbarTrack"); set => Native.SetPropBool(Pointer, "AlwaysShowScrollbarTrack", value); }
        public bool AllowOverscroll { get => Native.GetPropBool(Pointer, "AllowOverscroll"); set => Native.SetPropBool(Pointer, "AllowOverscroll", value); }
        public bool bAnimateWheelScrolling { get => Native.GetPropBool(Pointer, "bAnimateWheelScrolling"); set => Native.SetPropBool(Pointer, "bAnimateWheelScrolling", value); }
        public EDescendantScrollDestination NavigationDestination { get => (EDescendantScrollDestination)GetAt<byte>(0x848); set => SetAt(0x848, (byte)value); }
        public float NavigationScrollPadding { get => GetAt<float>(0x84C); set => SetAt(0x84C, value); }
        public EScrollWhenFocusChanges ScrollWhenFocusChanges { get => (EScrollWhenFocusChanges)GetAt<byte>(0x850); set => SetAt(0x850, (byte)value); }
        public bool bAllowRightClickDragScrolling { get => Native.GetPropBool(Pointer, "bAllowRightClickDragScrolling"); set => Native.SetPropBool(Pointer, "bAllowRightClickDragScrolling", value); }
        public float WheelScrollMultiplier { get => GetAt<float>(0x854); set => SetAt(0x854, value); }
        public System.IntPtr OnUserScrolled => AddrOf(0x858); // 
        /// <summary>[Native] thunk RVA 0x7E7B134 — hookable via Hooks.InstallAt(NativeFunc_SetWheelScrollMultiplier).</summary>
        public static System.IntPtr NativeFunc_SetWheelScrollMultiplier => Memory.ModuleBase() + 0x7E7B134;
        public void SetWheelScrollMultiplier(float NewWheelScrollMultiplier)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewWheelScrollMultiplier);
            CallRaw("SetWheelScrollMultiplier", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7B07C — hookable via Hooks.InstallAt(NativeFunc_SetScrollOffset).</summary>
        public static System.IntPtr NativeFunc_SetScrollOffset => Memory.ModuleBase() + 0x7E7B07C;
        public void SetScrollOffset(float NewScrollOffset)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewScrollOffset);
            CallRaw("SetScrollOffset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7B540 — hookable via Hooks.InstallAt(NativeFunc_SetScrollbarVisibility).</summary>
        public static System.IntPtr NativeFunc_SetScrollbarVisibility => Memory.ModuleBase() + 0x7E7B540;
        public void SetScrollbarVisibility(ESlateVisibility NewScrollBarVisibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)NewScrollBarVisibility);
            CallRaw("SetScrollbarVisibility", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7B490 — hookable via Hooks.InstallAt(NativeFunc_SetScrollbarThickness).</summary>
        public static System.IntPtr NativeFunc_SetScrollbarThickness => Memory.ModuleBase() + 0x7E7B490;
        public void SetScrollbarThickness(Vector2D NewScrollbarThickness)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, NewScrollbarThickness);
            CallRaw("SetScrollbarThickness", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7B3DC — hookable via Hooks.InstallAt(NativeFunc_SetScrollbarPadding).</summary>
        public static System.IntPtr NativeFunc_SetScrollbarPadding => Memory.ModuleBase() + 0x7E7B3DC;
        public void SetScrollbarPadding(Margin NewScrollbarPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, NewScrollbarPadding);
            CallRaw("SetScrollbarPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7B5E4 — hookable via Hooks.InstallAt(NativeFunc_SetOrientation).</summary>
        public static System.IntPtr NativeFunc_SetOrientation => Memory.ModuleBase() + 0x7E7B5E4;
        public void SetOrientation(byte NewOrientation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, NewOrientation);
            CallRaw("SetOrientation", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7B688 — hookable via Hooks.InstallAt(NativeFunc_SetConsumeMouseWheel).</summary>
        public static System.IntPtr NativeFunc_SetConsumeMouseWheel => Memory.ModuleBase() + 0x7E7B688;
        public void SetConsumeMouseWheel(EConsumeMouseWheel NewConsumeMouseWheel)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)NewConsumeMouseWheel);
            CallRaw("SetConsumeMouseWheel", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7B1D8 — hookable via Hooks.InstallAt(NativeFunc_SetAnimateWheelScrolling).</summary>
        public static System.IntPtr NativeFunc_SetAnimateWheelScrolling => Memory.ModuleBase() + 0x7E7B1D8;
        public void SetAnimateWheelScrolling(bool bShouldAnimateWheelScrolling)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bShouldAnimateWheelScrolling?1:0));
            CallRaw("SetAnimateWheelScrolling", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7B330 — hookable via Hooks.InstallAt(NativeFunc_SetAlwaysShowScrollbar).</summary>
        public static System.IntPtr NativeFunc_SetAlwaysShowScrollbar => Memory.ModuleBase() + 0x7E7B330;
        public void SetAlwaysShowScrollbar(bool NewAlwaysShowScrollbar)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(NewAlwaysShowScrollbar?1:0));
            CallRaw("SetAlwaysShowScrollbar", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7B284 — hookable via Hooks.InstallAt(NativeFunc_SetAllowOverscroll).</summary>
        public static System.IntPtr NativeFunc_SetAllowOverscroll => Memory.ModuleBase() + 0x7E7B284;
        public void SetAllowOverscroll(bool NewAllowOverscroll)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(NewAllowOverscroll?1:0));
            CallRaw("SetAllowOverscroll", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7AE3C — hookable via Hooks.InstallAt(NativeFunc_ScrollWidgetIntoView).</summary>
        public static System.IntPtr NativeFunc_ScrollWidgetIntoView => Memory.ModuleBase() + 0x7E7AE3C;
        public void ScrollWidgetIntoView(Widget WidgetToFind, bool AnimateScroll, EDescendantScrollDestination ScrollDestination, float Padding)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WidgetToFind);
            __pb.Set<byte>(0x8, (byte)(AnimateScroll?1:0));
            __pb.Set<byte>(0x9, (byte)ScrollDestination);
            __pb.Set(0xC, Padding);
            CallRaw("ScrollWidgetIntoView", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7AFCC — hookable via Hooks.InstallAt(NativeFunc_ScrollToStart).</summary>
        public static System.IntPtr NativeFunc_ScrollToStart => Memory.ModuleBase() + 0x7E7AFCC;
        public void ScrollToStart()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ScrollToStart", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7AFB8 — hookable via Hooks.InstallAt(NativeFunc_ScrollToEnd).</summary>
        public static System.IntPtr NativeFunc_ScrollToEnd => Memory.ModuleBase() + 0x7E7AFB8;
        public void ScrollToEnd()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ScrollToEnd", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7AFE0 — hookable via Hooks.InstallAt(NativeFunc_GetViewOffsetFraction).</summary>
        public static System.IntPtr NativeFunc_GetViewOffsetFraction => Memory.ModuleBase() + 0x7E7AFE0;
        public float GetViewOffsetFraction()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetViewOffsetFraction", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E7B014 — hookable via Hooks.InstallAt(NativeFunc_GetScrollOffsetOfEnd).</summary>
        public static System.IntPtr NativeFunc_GetScrollOffsetOfEnd => Memory.ModuleBase() + 0x7E7B014;
        public float GetScrollOffsetOfEnd()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetScrollOffsetOfEnd", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E7B048 — hookable via Hooks.InstallAt(NativeFunc_GetScrollOffset).</summary>
        public static System.IntPtr NativeFunc_GetScrollOffset => Memory.ModuleBase() + 0x7E7B048;
        public float GetScrollOffset()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetScrollOffset", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E7B120 — hookable via Hooks.InstallAt(NativeFunc_EndInertialScrolling).</summary>
        public static System.IntPtr NativeFunc_EndInertialScrolling => Memory.ModuleBase() + 0x7E7B120;
        public void EndInertialScrolling()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndInertialScrolling", __pb.Bytes);
        }
    }

    public class ScrollBoxSlot : PanelSlot
    {
        public const string UeClassName = "ScrollBoxSlot";
        public ScrollBoxSlot(System.IntPtr ptr) : base(ptr) {}
        public static new ScrollBoxSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ScrollBoxSlot(p);
        public static ScrollBoxSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ScrollBoxSlot(o.Pointer); }
        public static ScrollBoxSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ScrollBoxSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ScrollBoxSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x38));
        public byte HorizontalAlignment { get => GetAt<byte>(0x48); set => SetAt(0x48, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x49); set => SetAt(0x49, value); }
        /// <summary>[Native] thunk RVA 0x7E7C460 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E7C460;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7C5A8 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E7C5A8;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7C504 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E7C504;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class SizeBox : ContentWidget
    {
        public const string UeClassName = "SizeBox";
        public SizeBox(System.IntPtr ptr) : base(ptr) {}
        public static new SizeBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SizeBox(p);
        public static SizeBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SizeBox(o.Pointer); }
        public static SizeBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SizeBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SizeBox(a[i].Pointer); return r; }
        public float WidthOverride { get => GetAt<float>(0x130); set => SetAt(0x130, value); }
        public float HeightOverride { get => GetAt<float>(0x134); set => SetAt(0x134, value); }
        public float MinDesiredWidth { get => GetAt<float>(0x138); set => SetAt(0x138, value); }
        public float MinDesiredHeight { get => GetAt<float>(0x13C); set => SetAt(0x13C, value); }
        public float MaxDesiredWidth { get => GetAt<float>(0x140); set => SetAt(0x140, value); }
        public float MaxDesiredHeight { get => GetAt<float>(0x144); set => SetAt(0x144, value); }
        public float MinAspectRatio { get => GetAt<float>(0x148); set => SetAt(0x148, value); }
        public float MaxAspectRatio { get => GetAt<float>(0x14C); set => SetAt(0x14C, value); }
        public bool bOverride_WidthOverride { get => Native.GetPropBool(Pointer, "bOverride_WidthOverride"); set => Native.SetPropBool(Pointer, "bOverride_WidthOverride", value); }
        public bool bOverride_HeightOverride { get => Native.GetPropBool(Pointer, "bOverride_HeightOverride"); set => Native.SetPropBool(Pointer, "bOverride_HeightOverride", value); }
        public bool bOverride_MinDesiredWidth { get => Native.GetPropBool(Pointer, "bOverride_MinDesiredWidth"); set => Native.SetPropBool(Pointer, "bOverride_MinDesiredWidth", value); }
        public bool bOverride_MinDesiredHeight { get => Native.GetPropBool(Pointer, "bOverride_MinDesiredHeight"); set => Native.SetPropBool(Pointer, "bOverride_MinDesiredHeight", value); }
        public bool bOverride_MaxDesiredWidth { get => Native.GetPropBool(Pointer, "bOverride_MaxDesiredWidth"); set => Native.SetPropBool(Pointer, "bOverride_MaxDesiredWidth", value); }
        public bool bOverride_MaxDesiredHeight { get => Native.GetPropBool(Pointer, "bOverride_MaxDesiredHeight"); set => Native.SetPropBool(Pointer, "bOverride_MaxDesiredHeight", value); }
        public bool bOverride_MinAspectRatio { get => Native.GetPropBool(Pointer, "bOverride_MinAspectRatio"); set => Native.SetPropBool(Pointer, "bOverride_MinAspectRatio", value); }
        public bool bOverride_MaxAspectRatio { get => Native.GetPropBool(Pointer, "bOverride_MaxAspectRatio"); set => Native.SetPropBool(Pointer, "bOverride_MaxAspectRatio", value); }
        /// <summary>[Native] thunk RVA 0x7E7D39C — hookable via Hooks.InstallAt(NativeFunc_SetWidthOverride).</summary>
        public static System.IntPtr NativeFunc_SetWidthOverride => Memory.ModuleBase() + 0x7E7D39C;
        public void SetWidthOverride(float InWidthOverride)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InWidthOverride);
            CallRaw("SetWidthOverride", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D22C — hookable via Hooks.InstallAt(NativeFunc_SetMinDesiredWidth).</summary>
        public static System.IntPtr NativeFunc_SetMinDesiredWidth => Memory.ModuleBase() + 0x7E7D22C;
        public void SetMinDesiredWidth(float InMinDesiredWidth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMinDesiredWidth);
            CallRaw("SetMinDesiredWidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D174 — hookable via Hooks.InstallAt(NativeFunc_SetMinDesiredHeight).</summary>
        public static System.IntPtr NativeFunc_SetMinDesiredHeight => Memory.ModuleBase() + 0x7E7D174;
        public void SetMinDesiredHeight(float InMinDesiredHeight)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMinDesiredHeight);
            CallRaw("SetMinDesiredHeight", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7CF4C — hookable via Hooks.InstallAt(NativeFunc_SetMinAspectRatio).</summary>
        public static System.IntPtr NativeFunc_SetMinAspectRatio => Memory.ModuleBase() + 0x7E7CF4C;
        public void SetMinAspectRatio(float InMinAspectRatio)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMinAspectRatio);
            CallRaw("SetMinAspectRatio", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D0BC — hookable via Hooks.InstallAt(NativeFunc_SetMaxDesiredWidth).</summary>
        public static System.IntPtr NativeFunc_SetMaxDesiredWidth => Memory.ModuleBase() + 0x7E7D0BC;
        public void SetMaxDesiredWidth(float InMaxDesiredWidth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMaxDesiredWidth);
            CallRaw("SetMaxDesiredWidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D004 — hookable via Hooks.InstallAt(NativeFunc_SetMaxDesiredHeight).</summary>
        public static System.IntPtr NativeFunc_SetMaxDesiredHeight => Memory.ModuleBase() + 0x7E7D004;
        public void SetMaxDesiredHeight(float InMaxDesiredHeight)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMaxDesiredHeight);
            CallRaw("SetMaxDesiredHeight", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7CEA8 — hookable via Hooks.InstallAt(NativeFunc_SetMaxAspectRatio).</summary>
        public static System.IntPtr NativeFunc_SetMaxAspectRatio => Memory.ModuleBase() + 0x7E7CEA8;
        public void SetMaxAspectRatio(float InMaxAspectRatio)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMaxAspectRatio);
            CallRaw("SetMaxAspectRatio", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D2E4 — hookable via Hooks.InstallAt(NativeFunc_SetHeightOverride).</summary>
        public static System.IntPtr NativeFunc_SetHeightOverride => Memory.ModuleBase() + 0x7E7D2E4;
        public void SetHeightOverride(float InHeightOverride)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InHeightOverride);
            CallRaw("SetHeightOverride", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D388 — hookable via Hooks.InstallAt(NativeFunc_ClearWidthOverride).</summary>
        public static System.IntPtr NativeFunc_ClearWidthOverride => Memory.ModuleBase() + 0x7E7D388;
        public void ClearWidthOverride()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearWidthOverride", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D218 — hookable via Hooks.InstallAt(NativeFunc_ClearMinDesiredWidth).</summary>
        public static System.IntPtr NativeFunc_ClearMinDesiredWidth => Memory.ModuleBase() + 0x7E7D218;
        public void ClearMinDesiredWidth()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMinDesiredWidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D160 — hookable via Hooks.InstallAt(NativeFunc_ClearMinDesiredHeight).</summary>
        public static System.IntPtr NativeFunc_ClearMinDesiredHeight => Memory.ModuleBase() + 0x7E7D160;
        public void ClearMinDesiredHeight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMinDesiredHeight", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7CE94 — hookable via Hooks.InstallAt(NativeFunc_ClearMinAspectRatio).</summary>
        public static System.IntPtr NativeFunc_ClearMinAspectRatio => Memory.ModuleBase() + 0x7E7CE94;
        public void ClearMinAspectRatio()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMinAspectRatio", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D0A8 — hookable via Hooks.InstallAt(NativeFunc_ClearMaxDesiredWidth).</summary>
        public static System.IntPtr NativeFunc_ClearMaxDesiredWidth => Memory.ModuleBase() + 0x7E7D0A8;
        public void ClearMaxDesiredWidth()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMaxDesiredWidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7CFF0 — hookable via Hooks.InstallAt(NativeFunc_ClearMaxDesiredHeight).</summary>
        public static System.IntPtr NativeFunc_ClearMaxDesiredHeight => Memory.ModuleBase() + 0x7E7CFF0;
        public void ClearMaxDesiredHeight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMaxDesiredHeight", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7CE80 — hookable via Hooks.InstallAt(NativeFunc_ClearMaxAspectRatio).</summary>
        public static System.IntPtr NativeFunc_ClearMaxAspectRatio => Memory.ModuleBase() + 0x7E7CE80;
        public void ClearMaxAspectRatio()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMaxAspectRatio", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7D2D0 — hookable via Hooks.InstallAt(NativeFunc_ClearHeightOverride).</summary>
        public static System.IntPtr NativeFunc_ClearHeightOverride => Memory.ModuleBase() + 0x7E7D2D0;
        public void ClearHeightOverride()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearHeightOverride", __pb.Bytes);
        }
    }

    public class SizeBoxSlot : PanelSlot
    {
        public const string UeClassName = "SizeBoxSlot";
        public SizeBoxSlot(System.IntPtr ptr) : base(ptr) {}
        public static new SizeBoxSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SizeBoxSlot(p);
        public static SizeBoxSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SizeBoxSlot(o.Pointer); }
        public static SizeBoxSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SizeBoxSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SizeBoxSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x38));
        public byte HorizontalAlignment { get => GetAt<byte>(0x58); set => SetAt(0x58, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x59); set => SetAt(0x59, value); }
        /// <summary>[Native] thunk RVA 0x7E7E10C — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E7E10C;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7E254 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E7E254;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7E1B0 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E7E1B0;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class SlateBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "SlateBlueprintLibrary";
        public SlateBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new SlateBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SlateBlueprintLibrary(p);
        public static SlateBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SlateBlueprintLibrary(o.Pointer); }
        public static SlateBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SlateBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SlateBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E7F618 — hookable via Hooks.InstallAt(NativeFunc_TransformVectorLocalToAbsolute).</summary>
        public static System.IntPtr NativeFunc_TransformVectorLocalToAbsolute => Memory.ModuleBase() + 0x7E7F618;
        public Vector2D TransformVectorLocalToAbsolute(Geometry Geometry, Vector2D LocalVector)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            __pb.Set<System.IntPtr>(0x38, LocalVector);
            CallRaw("TransformVectorLocalToAbsolute", __pb.Bytes);
            return __pb.Get<Vector2D>(0x40);
        }
        /// <summary>[Native] thunk RVA 0x7E7F70C — hookable via Hooks.InstallAt(NativeFunc_TransformVectorAbsoluteToLocal).</summary>
        public static System.IntPtr NativeFunc_TransformVectorAbsoluteToLocal => Memory.ModuleBase() + 0x7E7F70C;
        public Vector2D TransformVectorAbsoluteToLocal(Geometry Geometry, Vector2D AbsoluteVector)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            __pb.Set<System.IntPtr>(0x38, AbsoluteVector);
            CallRaw("TransformVectorAbsoluteToLocal", __pb.Bytes);
            return __pb.Get<Vector2D>(0x40);
        }
        /// <summary>[Native] thunk RVA 0x7E7F800 — hookable via Hooks.InstallAt(NativeFunc_TransformScalarLocalToAbsolute).</summary>
        public static System.IntPtr NativeFunc_TransformScalarLocalToAbsolute => Memory.ModuleBase() + 0x7E7F800;
        public float TransformScalarLocalToAbsolute(Geometry Geometry, float LocalScalar)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            __pb.Set(0x38, LocalScalar);
            CallRaw("TransformScalarLocalToAbsolute", __pb.Bytes);
            return __pb.Get<float>(0x3C);
        }
        /// <summary>[Native] thunk RVA 0x7E7F8F8 — hookable via Hooks.InstallAt(NativeFunc_TransformScalarAbsoluteToLocal).</summary>
        public static System.IntPtr NativeFunc_TransformScalarAbsoluteToLocal => Memory.ModuleBase() + 0x7E7F8F8;
        public float TransformScalarAbsoluteToLocal(Geometry Geometry, float AbsoluteScalar)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            __pb.Set(0x38, AbsoluteScalar);
            CallRaw("TransformScalarAbsoluteToLocal", __pb.Bytes);
            return __pb.Get<float>(0x3C);
        }
        /// <summary>[Native] thunk RVA 0x7E7EDC4 — hookable via Hooks.InstallAt(NativeFunc_ScreenToWidgetLocal).</summary>
        public static System.IntPtr NativeFunc_ScreenToWidgetLocal => Memory.ModuleBase() + 0x7E7EDC4;
        public void ScreenToWidgetLocal(Object WorldContextObject, Geometry Geometry, Vector2D ScreenPosition, Vector2D LocalCoordinate, bool bIncludeWindowPosition)
        {
            var __pb = new ParamBuffer(81);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, Geometry);
            __pb.Set<System.IntPtr>(0x40, ScreenPosition);
            __pb.Set<System.IntPtr>(0x48, LocalCoordinate);
            __pb.Set<byte>(0x50, (byte)(bIncludeWindowPosition?1:0));
            CallRaw("ScreenToWidgetLocal", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7EC54 — hookable via Hooks.InstallAt(NativeFunc_ScreenToWidgetAbsolute).</summary>
        public static System.IntPtr NativeFunc_ScreenToWidgetAbsolute => Memory.ModuleBase() + 0x7E7EC54;
        public void ScreenToWidgetAbsolute(Object WorldContextObject, Vector2D ScreenPosition, Vector2D AbsoluteCoordinate, bool bIncludeWindowPosition)
        {
            var __pb = new ParamBuffer(25);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, ScreenPosition);
            __pb.Set<System.IntPtr>(0x10, AbsoluteCoordinate);
            __pb.Set<byte>(0x18, (byte)(bIncludeWindowPosition?1:0));
            CallRaw("ScreenToWidgetAbsolute", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7EB34 — hookable via Hooks.InstallAt(NativeFunc_ScreenToViewport).</summary>
        public static System.IntPtr NativeFunc_ScreenToViewport => Memory.ModuleBase() + 0x7E7EB34;
        public void ScreenToViewport(Object WorldContextObject, Vector2D ScreenPosition, Vector2D ViewportPosition)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, ScreenPosition);
            __pb.Set<System.IntPtr>(0x10, ViewportPosition);
            CallRaw("ScreenToViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7F0F8 — hookable via Hooks.InstallAt(NativeFunc_LocalToViewport).</summary>
        public static System.IntPtr NativeFunc_LocalToViewport => Memory.ModuleBase() + 0x7E7F0F8;
        public void LocalToViewport(Object WorldContextObject, Geometry Geometry, Vector2D LocalCoordinate, Vector2D PixelPosition, Vector2D ViewportPosition)
        {
            var __pb = new ParamBuffer(88);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, Geometry);
            __pb.Set<System.IntPtr>(0x40, LocalCoordinate);
            __pb.Set<System.IntPtr>(0x48, PixelPosition);
            __pb.Set<System.IntPtr>(0x50, ViewportPosition);
            CallRaw("LocalToViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7FC18 — hookable via Hooks.InstallAt(NativeFunc_LocalToAbsolute).</summary>
        public static System.IntPtr NativeFunc_LocalToAbsolute => Memory.ModuleBase() + 0x7E7FC18;
        public Vector2D LocalToAbsolute(Geometry Geometry, Vector2D LocalCoordinate)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            __pb.Set<System.IntPtr>(0x38, LocalCoordinate);
            CallRaw("LocalToAbsolute", __pb.Bytes);
            return __pb.Get<Vector2D>(0x40);
        }
        /// <summary>[Native] thunk RVA 0x7E7FE00 — hookable via Hooks.InstallAt(NativeFunc_IsUnderLocation).</summary>
        public static System.IntPtr NativeFunc_IsUnderLocation => Memory.ModuleBase() + 0x7E7FE00;
        public bool IsUnderLocation(Geometry Geometry, Vector2D AbsoluteCoordinate)
        {
            var __pb = new ParamBuffer(65);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            __pb.Set<System.IntPtr>(0x38, AbsoluteCoordinate);
            CallRaw("IsUnderLocation", __pb.Bytes);
            return __pb.Get<byte>(0x40) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E7FB60 — hookable via Hooks.InstallAt(NativeFunc_GetLocalTopLeft).</summary>
        public static System.IntPtr NativeFunc_GetLocalTopLeft => Memory.ModuleBase() + 0x7E7FB60;
        public Vector2D GetLocalTopLeft(Geometry Geometry)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            CallRaw("GetLocalTopLeft", __pb.Bytes);
            return __pb.Get<Vector2D>(0x38);
        }
        /// <summary>[Native] thunk RVA 0x7E7FAA8 — hookable via Hooks.InstallAt(NativeFunc_GetLocalSize).</summary>
        public static System.IntPtr NativeFunc_GetLocalSize => Memory.ModuleBase() + 0x7E7FAA8;
        public Vector2D GetLocalSize(Geometry Geometry)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            CallRaw("GetLocalSize", __pb.Bytes);
            return __pb.Get<Vector2D>(0x38);
        }
        /// <summary>[Native] thunk RVA 0x7E7F9F0 — hookable via Hooks.InstallAt(NativeFunc_GetAbsoluteSize).</summary>
        public static System.IntPtr NativeFunc_GetAbsoluteSize => Memory.ModuleBase() + 0x7E7F9F0;
        public Vector2D GetAbsoluteSize(Geometry Geometry)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            CallRaw("GetAbsoluteSize", __pb.Bytes);
            return __pb.Get<Vector2D>(0x38);
        }
        /// <summary>[Native] thunk RVA 0x7E7F2BC — hookable via Hooks.InstallAt(NativeFunc_EqualEqual_SlateBrush).</summary>
        public static System.IntPtr NativeFunc_EqualEqual_SlateBrush => Memory.ModuleBase() + 0x7E7F2BC;
        public bool EqualEqual_SlateBrush(SlateBrush A, SlateBrush B)
        {
            var __pb = new ParamBuffer(273);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set<System.IntPtr>(0x88, B);
            CallRaw("EqualEqual_SlateBrush", __pb.Bytes);
            return __pb.Get<byte>(0x110) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E7EF84 — hookable via Hooks.InstallAt(NativeFunc_AbsoluteToViewport).</summary>
        public static System.IntPtr NativeFunc_AbsoluteToViewport => Memory.ModuleBase() + 0x7E7EF84;
        public void AbsoluteToViewport(Object WorldContextObject, Vector2D AbsoluteDesktopCoordinate, Vector2D PixelPosition, Vector2D ViewportPosition)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, AbsoluteDesktopCoordinate);
            __pb.Set<System.IntPtr>(0x10, PixelPosition);
            __pb.Set<System.IntPtr>(0x18, ViewportPosition);
            CallRaw("AbsoluteToViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E7FD0C — hookable via Hooks.InstallAt(NativeFunc_AbsoluteToLocal).</summary>
        public static System.IntPtr NativeFunc_AbsoluteToLocal => Memory.ModuleBase() + 0x7E7FD0C;
        public Vector2D AbsoluteToLocal(Geometry Geometry, Vector2D AbsoluteCoordinate)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<System.IntPtr>(0x0, Geometry);
            __pb.Set<System.IntPtr>(0x38, AbsoluteCoordinate);
            CallRaw("AbsoluteToLocal", __pb.Bytes);
            return __pb.Get<Vector2D>(0x40);
        }
    }

    public class SlateVectorArtData : Object
    {
        public const string UeClassName = "SlateVectorArtData";
        public SlateVectorArtData(System.IntPtr ptr) : base(ptr) {}
        public static new SlateVectorArtData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SlateVectorArtData(p);
        public static SlateVectorArtData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SlateVectorArtData(o.Pointer); }
        public static SlateVectorArtData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SlateVectorArtData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SlateVectorArtData(a[i].Pointer); return r; }
        public TArray<System.IntPtr> VertexData => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public TArray<System.IntPtr> IndexData => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<uint32>
        public MaterialInterface Material { get { var __p = GetAt<System.IntPtr>(0x48); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); } set => SetAt(0x48, value?.Pointer ?? System.IntPtr.Zero); }
        public Vector2D ExtentMin => new Vector2D(AddrOf(0x50));
        public Vector2D ExtentMax => new Vector2D(AddrOf(0x58));
    }

    public class SlateAccessibleWidgetData : Object
    {
        public const string UeClassName = "SlateAccessibleWidgetData";
        public SlateAccessibleWidgetData(System.IntPtr ptr) : base(ptr) {}
        public static new SlateAccessibleWidgetData FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SlateAccessibleWidgetData(p);
        public static SlateAccessibleWidgetData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SlateAccessibleWidgetData(o.Pointer); }
        public static SlateAccessibleWidgetData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SlateAccessibleWidgetData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SlateAccessibleWidgetData(a[i].Pointer); return r; }
        public bool bCanChildrenBeAccessible { get => Native.GetPropBool(Pointer, "bCanChildrenBeAccessible"); set => Native.SetPropBool(Pointer, "bCanChildrenBeAccessible", value); }
        public ESlateAccessibleBehavior AccessibleBehavior { get => (ESlateAccessibleBehavior)GetAt<byte>(0x29); set => SetAt(0x29, (byte)value); }
        public ESlateAccessibleBehavior AccessibleSummaryBehavior { get => (ESlateAccessibleBehavior)GetAt<byte>(0x2A); set => SetAt(0x2A, (byte)value); }
        public System.IntPtr AccessibleText => AddrOf(0x30); // 
        public System.IntPtr AccessibleTextDelegate => AddrOf(0x48); // 
        public System.IntPtr AccessibleSummaryText => AddrOf(0x58); // 
        public System.IntPtr AccessibleSummaryTextDelegate => AddrOf(0x70); // 
    }

    public class Slider : Widget
    {
        public const string UeClassName = "Slider";
        public Slider(System.IntPtr ptr) : base(ptr) {}
        public static new Slider FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Slider(p);
        public static Slider FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Slider(o.Pointer); }
        public static Slider[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Slider[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Slider(a[i].Pointer); return r; }
        public float Value { get => GetAt<float>(0x108); set => SetAt(0x108, value); }
        public System.IntPtr ValueDelegate => AddrOf(0x10C); // 
        public float MinValue { get => GetAt<float>(0x11C); set => SetAt(0x11C, value); }
        public float MaxValue { get => GetAt<float>(0x120); set => SetAt(0x120, value); }
        public SliderStyle WidgetStyle => new SliderStyle(AddrOf(0x128));
        public byte Orientation { get => GetAt<byte>(0x468); set => SetAt(0x468, value); }
        public LinearColor SliderBarColor => new LinearColor(AddrOf(0x46C));
        public LinearColor SliderHandleColor => new LinearColor(AddrOf(0x47C));
        public bool IndentHandle { get => Native.GetPropBool(Pointer, "IndentHandle"); set => Native.SetPropBool(Pointer, "IndentHandle", value); }
        public bool Locked { get => Native.GetPropBool(Pointer, "Locked"); set => Native.SetPropBool(Pointer, "Locked", value); }
        public bool MouseUsesStep { get => Native.GetPropBool(Pointer, "MouseUsesStep"); set => Native.SetPropBool(Pointer, "MouseUsesStep", value); }
        public bool RequiresControllerLock { get => Native.GetPropBool(Pointer, "RequiresControllerLock"); set => Native.SetPropBool(Pointer, "RequiresControllerLock", value); }
        public float StepSize { get => GetAt<float>(0x490); set => SetAt(0x490, value); }
        public bool IsFocusable { get => Native.GetPropBool(Pointer, "IsFocusable"); set => Native.SetPropBool(Pointer, "IsFocusable", value); }
        public System.IntPtr OnMouseCaptureBegin => AddrOf(0x498); // 
        public System.IntPtr OnMouseCaptureEnd => AddrOf(0x4A8); // 
        public System.IntPtr OnControllerCaptureBegin => AddrOf(0x4B8); // 
        public System.IntPtr OnControllerCaptureEnd => AddrOf(0x4C8); // 
        public System.IntPtr OnValueChanged => AddrOf(0x4D8); // 
        /// <summary>[Native] thunk RVA 0x7E82FCC — hookable via Hooks.InstallAt(NativeFunc_SetValue).</summary>
        public static System.IntPtr NativeFunc_SetValue => Memory.ModuleBase() + 0x7E82FCC;
        public void SetValue(float InValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InValue);
            CallRaw("SetValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E82C88 — hookable via Hooks.InstallAt(NativeFunc_SetStepSize).</summary>
        public static System.IntPtr NativeFunc_SetStepSize => Memory.ModuleBase() + 0x7E82C88;
        public void SetStepSize(float InValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InValue);
            CallRaw("SetStepSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E82B40 — hookable via Hooks.InstallAt(NativeFunc_SetSliderHandleColor).</summary>
        public static System.IntPtr NativeFunc_SetSliderHandleColor => Memory.ModuleBase() + 0x7E82B40;
        public void SetSliderHandleColor(LinearColor InValue)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InValue);
            CallRaw("SetSliderHandleColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E82BE4 — hookable via Hooks.InstallAt(NativeFunc_SetSliderBarColor).</summary>
        public static System.IntPtr NativeFunc_SetSliderBarColor => Memory.ModuleBase() + 0x7E82BE4;
        public void SetSliderBarColor(LinearColor InValue)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InValue);
            CallRaw("SetSliderBarColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E82F28 — hookable via Hooks.InstallAt(NativeFunc_SetMinValue).</summary>
        public static System.IntPtr NativeFunc_SetMinValue => Memory.ModuleBase() + 0x7E82F28;
        public void SetMinValue(float InValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InValue);
            CallRaw("SetMinValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E82E84 — hookable via Hooks.InstallAt(NativeFunc_SetMaxValue).</summary>
        public static System.IntPtr NativeFunc_SetMaxValue => Memory.ModuleBase() + 0x7E82E84;
        public void SetMaxValue(float InValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InValue);
            CallRaw("SetMaxValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E82D2C — hookable via Hooks.InstallAt(NativeFunc_SetLocked).</summary>
        public static System.IntPtr NativeFunc_SetLocked => Memory.ModuleBase() + 0x7E82D2C;
        public void SetLocked(bool InValue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InValue?1:0));
            CallRaw("SetLocked", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E82DD8 — hookable via Hooks.InstallAt(NativeFunc_SetIndentHandle).</summary>
        public static System.IntPtr NativeFunc_SetIndentHandle => Memory.ModuleBase() + 0x7E82DD8;
        public void SetIndentHandle(bool InValue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InValue?1:0));
            CallRaw("SetIndentHandle", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E830A4 — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7E830A4;
        public float GetValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E83070 — hookable via Hooks.InstallAt(NativeFunc_GetNormalizedValue).</summary>
        public static System.IntPtr NativeFunc_GetNormalizedValue => Memory.ModuleBase() + 0x7E83070;
        public float GetNormalizedValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNormalizedValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
    }

    public class Spacer : Widget
    {
        public const string UeClassName = "Spacer";
        public Spacer(System.IntPtr ptr) : base(ptr) {}
        public static new Spacer FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Spacer(p);
        public static Spacer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Spacer(o.Pointer); }
        public static Spacer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Spacer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Spacer(a[i].Pointer); return r; }
        public Vector2D Size => new Vector2D(AddrOf(0x108));
        /// <summary>[Native] thunk RVA 0x7E83BD4 — hookable via Hooks.InstallAt(NativeFunc_SetSize).</summary>
        public static System.IntPtr NativeFunc_SetSize => Memory.ModuleBase() + 0x7E83BD4;
        public void SetSize(Vector2D InSize)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InSize);
            CallRaw("SetSize", __pb.Bytes);
        }
    }

    public class SpinBox : Widget
    {
        public const string UeClassName = "SpinBox";
        public SpinBox(System.IntPtr ptr) : base(ptr) {}
        public static new SpinBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new SpinBox(p);
        public static SpinBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SpinBox(o.Pointer); }
        public static SpinBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SpinBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SpinBox(a[i].Pointer); return r; }
        public float Value { get => GetAt<float>(0x108); set => SetAt(0x108, value); }
        public System.IntPtr ValueDelegate => AddrOf(0x10C); // 
        public SpinBoxStyle WidgetStyle => new SpinBoxStyle(AddrOf(0x120));
        public SlateWidgetStyleAsset Style { get { var __p = GetAt<System.IntPtr>(0x408); return __p==System.IntPtr.Zero?null:new SlateWidgetStyleAsset(__p); } set => SetAt(0x408, value?.Pointer ?? System.IntPtr.Zero); }
        public int MinFractionalDigits { get => GetAt<int>(0x410); set => SetAt(0x410, value); }
        public int MaxFractionalDigits { get => GetAt<int>(0x414); set => SetAt(0x414, value); }
        public bool bAlwaysUsesDeltaSnap { get => Native.GetPropBool(Pointer, "bAlwaysUsesDeltaSnap"); set => Native.SetPropBool(Pointer, "bAlwaysUsesDeltaSnap", value); }
        public float Delta { get => GetAt<float>(0x41C); set => SetAt(0x41C, value); }
        public float SliderExponent { get => GetAt<float>(0x420); set => SetAt(0x420, value); }
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0x428));
        public byte Justification { get => GetAt<byte>(0x478); set => SetAt(0x478, value); }
        public float MinDesiredWidth { get => GetAt<float>(0x47C); set => SetAt(0x47C, value); }
        public bool ClearKeyboardFocusOnCommit { get => Native.GetPropBool(Pointer, "ClearKeyboardFocusOnCommit"); set => Native.SetPropBool(Pointer, "ClearKeyboardFocusOnCommit", value); }
        public bool SelectAllTextOnCommit { get => Native.GetPropBool(Pointer, "SelectAllTextOnCommit"); set => Native.SetPropBool(Pointer, "SelectAllTextOnCommit", value); }
        public SlateColor ForegroundColor => new SlateColor(AddrOf(0x488));
        public System.IntPtr OnValueChanged => AddrOf(0x4B0); // 
        public System.IntPtr OnValueCommitted => AddrOf(0x4C0); // 
        public System.IntPtr OnBeginSliderMovement => AddrOf(0x4D0); // 
        public System.IntPtr OnEndSliderMovement => AddrOf(0x4E0); // 
        public bool bOverride_MinValue { get => Native.GetPropBool(Pointer, "bOverride_MinValue"); set => Native.SetPropBool(Pointer, "bOverride_MinValue", value); }
        public bool bOverride_MaxValue { get => Native.GetPropBool(Pointer, "bOverride_MaxValue"); set => Native.SetPropBool(Pointer, "bOverride_MaxValue", value); }
        public bool bOverride_MinSliderValue { get => Native.GetPropBool(Pointer, "bOverride_MinSliderValue"); set => Native.SetPropBool(Pointer, "bOverride_MinSliderValue", value); }
        public bool bOverride_MaxSliderValue { get => Native.GetPropBool(Pointer, "bOverride_MaxSliderValue"); set => Native.SetPropBool(Pointer, "bOverride_MaxSliderValue", value); }
        public float MinValue { get => GetAt<float>(0x4F4); set => SetAt(0x4F4, value); }
        public float MaxValue { get => GetAt<float>(0x4F8); set => SetAt(0x4F8, value); }
        public float MinSliderValue { get => GetAt<float>(0x4FC); set => SetAt(0x4FC, value); }
        public float MaxSliderValue { get => GetAt<float>(0x500); set => SetAt(0x500, value); }
        /// <summary>[Native] thunk RVA 0x7E84E34 — hookable via Hooks.InstallAt(NativeFunc_SetValue).</summary>
        public static System.IntPtr NativeFunc_SetValue => Memory.ModuleBase() + 0x7E84E34;
        public void SetValue(float NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E849F0 — hookable via Hooks.InstallAt(NativeFunc_SetMinValue).</summary>
        public static System.IntPtr NativeFunc_SetMinValue => Memory.ModuleBase() + 0x7E849F0;
        public void SetMinValue(float NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetMinValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84818 — hookable via Hooks.InstallAt(NativeFunc_SetMinSliderValue).</summary>
        public static System.IntPtr NativeFunc_SetMinSliderValue => Memory.ModuleBase() + 0x7E84818;
        public void SetMinSliderValue(float NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetMinSliderValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84D5C — hookable via Hooks.InstallAt(NativeFunc_SetMinFractionalDigits).</summary>
        public static System.IntPtr NativeFunc_SetMinFractionalDigits => Memory.ModuleBase() + 0x7E84D5C;
        public void SetMinFractionalDigits(int NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetMinFractionalDigits", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84904 — hookable via Hooks.InstallAt(NativeFunc_SetMaxValue).</summary>
        public static System.IntPtr NativeFunc_SetMaxValue => Memory.ModuleBase() + 0x7E84904;
        public void SetMaxValue(float NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetMaxValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8472C — hookable via Hooks.InstallAt(NativeFunc_SetMaxSliderValue).</summary>
        public static System.IntPtr NativeFunc_SetMaxSliderValue => Memory.ModuleBase() + 0x7E8472C;
        public void SetMaxSliderValue(float NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetMaxSliderValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84C84 — hookable via Hooks.InstallAt(NativeFunc_SetMaxFractionalDigits).</summary>
        public static System.IntPtr NativeFunc_SetMaxFractionalDigits => Memory.ModuleBase() + 0x7E84C84;
        public void SetMaxFractionalDigits(int NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetMaxFractionalDigits", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84574 — hookable via Hooks.InstallAt(NativeFunc_SetForegroundColor).</summary>
        public static System.IntPtr NativeFunc_SetForegroundColor => Memory.ModuleBase() + 0x7E84574;
        public void SetForegroundColor(SlateColor InForegroundColor)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, InForegroundColor);
            CallRaw("SetForegroundColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84AC8 — hookable via Hooks.InstallAt(NativeFunc_SetDelta).</summary>
        public static System.IntPtr NativeFunc_SetDelta => Memory.ModuleBase() + 0x7E84AC8;
        public void SetDelta(float NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetDelta", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84BA0 — hookable via Hooks.InstallAt(NativeFunc_SetAlwaysUsesDeltaSnap).</summary>
        public static System.IntPtr NativeFunc_SetAlwaysUsesDeltaSnap => Memory.ModuleBase() + 0x7E84BA0;
        public void SetAlwaysUsesDeltaSnap(bool bNewValue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bNewValue?1:0));
            CallRaw("SetAlwaysUsesDeltaSnap", __pb.Bytes);
        }
        public void OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, byte CommitMethod)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, InValue);
            __pb.Set(0x4, CommitMethod);
            CallRaw("OnSpinBoxValueCommittedEvent__DelegateSignature", __pb.Bytes);
        }
        public void OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InValue);
            CallRaw("OnSpinBoxValueChangedEvent__DelegateSignature", __pb.Bytes);
        }
        public void OnSpinBoxBeginSliderMovement__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnSpinBoxBeginSliderMovement__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84ED8 — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7E84ED8;
        public float GetValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E84A94 — hookable via Hooks.InstallAt(NativeFunc_GetMinValue).</summary>
        public static System.IntPtr NativeFunc_GetMinValue => Memory.ModuleBase() + 0x7E84A94;
        public float GetMinValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMinValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E848BC — hookable via Hooks.InstallAt(NativeFunc_GetMinSliderValue).</summary>
        public static System.IntPtr NativeFunc_GetMinSliderValue => Memory.ModuleBase() + 0x7E848BC;
        public float GetMinSliderValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMinSliderValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E84E00 — hookable via Hooks.InstallAt(NativeFunc_GetMinFractionalDigits).</summary>
        public static System.IntPtr NativeFunc_GetMinFractionalDigits => Memory.ModuleBase() + 0x7E84E00;
        public int GetMinFractionalDigits()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMinFractionalDigits", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E849A8 — hookable via Hooks.InstallAt(NativeFunc_GetMaxValue).</summary>
        public static System.IntPtr NativeFunc_GetMaxValue => Memory.ModuleBase() + 0x7E849A8;
        public float GetMaxValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMaxValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E847D0 — hookable via Hooks.InstallAt(NativeFunc_GetMaxSliderValue).</summary>
        public static System.IntPtr NativeFunc_GetMaxSliderValue => Memory.ModuleBase() + 0x7E847D0;
        public float GetMaxSliderValue()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMaxSliderValue", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E84D28 — hookable via Hooks.InstallAt(NativeFunc_GetMaxFractionalDigits).</summary>
        public static System.IntPtr NativeFunc_GetMaxFractionalDigits => Memory.ModuleBase() + 0x7E84D28;
        public int GetMaxFractionalDigits()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetMaxFractionalDigits", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E84B6C — hookable via Hooks.InstallAt(NativeFunc_GetDelta).</summary>
        public static System.IntPtr NativeFunc_GetDelta => Memory.ModuleBase() + 0x7E84B6C;
        public float GetDelta()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetDelta", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E84C4C — hookable via Hooks.InstallAt(NativeFunc_GetAlwaysUsesDeltaSnap).</summary>
        public static System.IntPtr NativeFunc_GetAlwaysUsesDeltaSnap => Memory.ModuleBase() + 0x7E84C4C;
        public bool GetAlwaysUsesDeltaSnap()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetAlwaysUsesDeltaSnap", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7E849DC — hookable via Hooks.InstallAt(NativeFunc_ClearMinValue).</summary>
        public static System.IntPtr NativeFunc_ClearMinValue => Memory.ModuleBase() + 0x7E849DC;
        public void ClearMinValue()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMinValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84804 — hookable via Hooks.InstallAt(NativeFunc_ClearMinSliderValue).</summary>
        public static System.IntPtr NativeFunc_ClearMinSliderValue => Memory.ModuleBase() + 0x7E84804;
        public void ClearMinSliderValue()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMinSliderValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E848F0 — hookable via Hooks.InstallAt(NativeFunc_ClearMaxValue).</summary>
        public static System.IntPtr NativeFunc_ClearMaxValue => Memory.ModuleBase() + 0x7E848F0;
        public void ClearMaxValue()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMaxValue", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E84718 — hookable via Hooks.InstallAt(NativeFunc_ClearMaxSliderValue).</summary>
        public static System.IntPtr NativeFunc_ClearMaxSliderValue => Memory.ModuleBase() + 0x7E84718;
        public void ClearMaxSliderValue()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMaxSliderValue", __pb.Bytes);
        }
    }

    public class TextBinding : PropertyBinding
    {
        public const string UeClassName = "TextBinding";
        public TextBinding(System.IntPtr ptr) : base(ptr) {}
        public static new TextBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TextBinding(p);
        public static TextBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TextBinding(o.Pointer); }
        public static TextBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TextBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TextBinding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E85E98 — hookable via Hooks.InstallAt(NativeFunc_GetTextValue).</summary>
        public static System.IntPtr NativeFunc_GetTextValue => Memory.ModuleBase() + 0x7E85E98;
        public System.IntPtr GetTextValue()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetTextValue", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E85DE8 — hookable via Hooks.InstallAt(NativeFunc_GetStringValue).</summary>
        public static System.IntPtr NativeFunc_GetStringValue => Memory.ModuleBase() + 0x7E85DE8;
        public System.IntPtr GetStringValue()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetStringValue", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
    }

    public class TextBlock : TextLayoutWidget
    {
        public const string UeClassName = "TextBlock";
        public TextBlock(System.IntPtr ptr) : base(ptr) {}
        public static new TextBlock FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TextBlock(p);
        public static TextBlock FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TextBlock(o.Pointer); }
        public static TextBlock[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TextBlock[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TextBlock(a[i].Pointer); return r; }
        public System.IntPtr Text => AddrOf(0x128); // 
        public System.IntPtr TextDelegate => AddrOf(0x140); // 
        public SlateColor ColorAndOpacity => new SlateColor(AddrOf(0x150));
        public System.IntPtr ColorAndOpacityDelegate => AddrOf(0x178); // 
        public SlateFontInfo Font => new SlateFontInfo(AddrOf(0x188));
        public SlateBrush StrikeBrush => new SlateBrush(AddrOf(0x1D8));
        public Vector2D ShadowOffset => new Vector2D(AddrOf(0x260));
        public LinearColor ShadowColorAndOpacity => new LinearColor(AddrOf(0x268));
        public System.IntPtr ShadowColorAndOpacityDelegate => AddrOf(0x278); // 
        public float MinDesiredWidth { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public bool bWrapWithInvalidationPanel { get => Native.GetPropBool(Pointer, "bWrapWithInvalidationPanel"); set => Native.SetPropBool(Pointer, "bWrapWithInvalidationPanel", value); }
        public bool bAutoWrapText { get => Native.GetPropBool(Pointer, "bAutoWrapText"); set => Native.SetPropBool(Pointer, "bAutoWrapText", value); }
        public bool bSimpleTextMode { get => Native.GetPropBool(Pointer, "bSimpleTextMode"); set => Native.SetPropBool(Pointer, "bSimpleTextMode", value); }
        /// <summary>[Native] thunk RVA 0x7E86780 — hookable via Hooks.InstallAt(NativeFunc_SetText).</summary>
        public static System.IntPtr NativeFunc_SetText => Memory.ModuleBase() + 0x7E86780;
        public void SetText(System.IntPtr InText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, InText);
            CallRaw("SetText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E86BA8 — hookable via Hooks.InstallAt(NativeFunc_SetStrikeBrush).</summary>
        public static System.IntPtr NativeFunc_SetStrikeBrush => Memory.ModuleBase() + 0x7E86BA8;
        public void SetStrikeBrush(SlateBrush InStrikeBrush)
        {
            var __pb = new ParamBuffer(136);
            __pb.Set<System.IntPtr>(0x0, InStrikeBrush);
            CallRaw("SetStrikeBrush", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E87084 — hookable via Hooks.InstallAt(NativeFunc_SetShadowOffset).</summary>
        public static System.IntPtr NativeFunc_SetShadowOffset => Memory.ModuleBase() + 0x7E87084;
        public void SetShadowOffset(Vector2D InShadowOffset)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InShadowOffset);
            CallRaw("SetShadowOffset", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E87124 — hookable via Hooks.InstallAt(NativeFunc_SetShadowColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetShadowColorAndOpacity => Memory.ModuleBase() + 0x7E87124;
        public void SetShadowColorAndOpacity(LinearColor InShadowColorAndOpacity)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InShadowColorAndOpacity);
            CallRaw("SetShadowColorAndOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E871C8 — hookable via Hooks.InstallAt(NativeFunc_SetOpacity).</summary>
        public static System.IntPtr NativeFunc_SetOpacity => Memory.ModuleBase() + 0x7E871C8;
        public void SetOpacity(float InOpacity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InOpacity);
            CallRaw("SetOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E86B04 — hookable via Hooks.InstallAt(NativeFunc_SetMinDesiredWidth).</summary>
        public static System.IntPtr NativeFunc_SetMinDesiredWidth => Memory.ModuleBase() + 0x7E86B04;
        public void SetMinDesiredWidth(float InMinDesiredWidth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMinDesiredWidth);
            CallRaw("SetMinDesiredWidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E86ED8 — hookable via Hooks.InstallAt(NativeFunc_SetFont).</summary>
        public static System.IntPtr NativeFunc_SetFont => Memory.ModuleBase() + 0x7E86ED8;
        public void SetFont(SlateFontInfo InFontInfo)
        {
            var __pb = new ParamBuffer(80);
            __pb.Set<System.IntPtr>(0x0, InFontInfo);
            CallRaw("SetFont", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8726C — hookable via Hooks.InstallAt(NativeFunc_SetColorAndOpacity).</summary>
        public static System.IntPtr NativeFunc_SetColorAndOpacity => Memory.ModuleBase() + 0x7E8726C;
        public void SetColorAndOpacity(SlateColor InColorAndOpacity)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, InColorAndOpacity);
            CallRaw("SetColorAndOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E86A58 — hookable via Hooks.InstallAt(NativeFunc_SetAutoWrapText).</summary>
        public static System.IntPtr NativeFunc_SetAutoWrapText => Memory.ModuleBase() + 0x7E86A58;
        public void SetAutoWrapText(bool InAutoTextWrap)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InAutoTextWrap?1:0));
            CallRaw("SetAutoWrapText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E86918 — hookable via Hooks.InstallAt(NativeFunc_GetText).</summary>
        public static System.IntPtr NativeFunc_GetText => Memory.ModuleBase() + 0x7E86918;
        public System.IntPtr GetText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetText", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E869F0 — hookable via Hooks.InstallAt(NativeFunc_GetDynamicOutlineMaterial).</summary>
        public static System.IntPtr NativeFunc_GetDynamicOutlineMaterial => Memory.ModuleBase() + 0x7E869F0;
        public MaterialInstanceDynamic GetDynamicOutlineMaterial()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDynamicOutlineMaterial", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E86A24 — hookable via Hooks.InstallAt(NativeFunc_GetDynamicFontMaterial).</summary>
        public static System.IntPtr NativeFunc_GetDynamicFontMaterial => Memory.ModuleBase() + 0x7E86A24;
        public MaterialInstanceDynamic GetDynamicFontMaterial()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDynamicFontMaterial", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); }
        }
    }

    public class Throbber : Widget
    {
        public const string UeClassName = "Throbber";
        public Throbber(System.IntPtr ptr) : base(ptr) {}
        public static new Throbber FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Throbber(p);
        public static Throbber FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Throbber(o.Pointer); }
        public static Throbber[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Throbber[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Throbber(a[i].Pointer); return r; }
        public int NumberOfPieces { get => GetAt<int>(0x108); set => SetAt(0x108, value); }
        public bool bAnimateHorizontally { get => Native.GetPropBool(Pointer, "bAnimateHorizontally"); set => Native.SetPropBool(Pointer, "bAnimateHorizontally", value); }
        public bool bAnimateVertically { get => Native.GetPropBool(Pointer, "bAnimateVertically"); set => Native.SetPropBool(Pointer, "bAnimateVertically", value); }
        public bool bAnimateOpacity { get => Native.GetPropBool(Pointer, "bAnimateOpacity"); set => Native.SetPropBool(Pointer, "bAnimateOpacity", value); }
        public SlateBrushAsset PieceImage { get { var __p = GetAt<System.IntPtr>(0x110); return __p==System.IntPtr.Zero?null:new SlateBrushAsset(__p); } set => SetAt(0x110, value?.Pointer ?? System.IntPtr.Zero); }
        public SlateBrush Image => new SlateBrush(AddrOf(0x118));
        /// <summary>[Native] thunk RVA 0x7E88D94 — hookable via Hooks.InstallAt(NativeFunc_SetNumberOfPieces).</summary>
        public static System.IntPtr NativeFunc_SetNumberOfPieces => Memory.ModuleBase() + 0x7E88D94;
        public void SetNumberOfPieces(int InNumberOfPieces)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InNumberOfPieces);
            CallRaw("SetNumberOfPieces", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E88C3C — hookable via Hooks.InstallAt(NativeFunc_SetAnimateVertically).</summary>
        public static System.IntPtr NativeFunc_SetAnimateVertically => Memory.ModuleBase() + 0x7E88C3C;
        public void SetAnimateVertically(bool bInAnimateVertically)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInAnimateVertically?1:0));
            CallRaw("SetAnimateVertically", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E88B90 — hookable via Hooks.InstallAt(NativeFunc_SetAnimateOpacity).</summary>
        public static System.IntPtr NativeFunc_SetAnimateOpacity => Memory.ModuleBase() + 0x7E88B90;
        public void SetAnimateOpacity(bool bInAnimateOpacity)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInAnimateOpacity?1:0));
            CallRaw("SetAnimateOpacity", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E88CE8 — hookable via Hooks.InstallAt(NativeFunc_SetAnimateHorizontally).</summary>
        public static System.IntPtr NativeFunc_SetAnimateHorizontally => Memory.ModuleBase() + 0x7E88CE8;
        public void SetAnimateHorizontally(bool bInAnimateHorizontally)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInAnimateHorizontally?1:0));
            CallRaw("SetAnimateHorizontally", __pb.Bytes);
        }
    }

    public class TileView : ListView
    {
        public const string UeClassName = "TileView";
        public TileView(System.IntPtr ptr) : base(ptr) {}
        public static new TileView FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TileView(p);
        public static TileView FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TileView(o.Pointer); }
        public static TileView[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TileView[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TileView(a[i].Pointer); return r; }
        public float EntryHeight { get => GetAt<float>(0x368); set => SetAt(0x368, value); }
        public float EntryWidth { get => GetAt<float>(0x36C); set => SetAt(0x36C, value); }
        public EListItemAlignment TileAlignment { get => (EListItemAlignment)GetAt<byte>(0x370); set => SetAt(0x370, (byte)value); }
        public bool bWrapHorizontalNavigation { get => Native.GetPropBool(Pointer, "bWrapHorizontalNavigation"); set => Native.SetPropBool(Pointer, "bWrapHorizontalNavigation", value); }
        /// <summary>[Native] thunk RVA 0x7E897A8 — hookable via Hooks.InstallAt(NativeFunc_SetEntryWidth).</summary>
        public static System.IntPtr NativeFunc_SetEntryWidth => Memory.ModuleBase() + 0x7E897A8;
        public void SetEntryWidth(float newWidth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, newWidth);
            CallRaw("SetEntryWidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8984C — hookable via Hooks.InstallAt(NativeFunc_SetEntryHeight).</summary>
        public static System.IntPtr NativeFunc_SetEntryHeight => Memory.ModuleBase() + 0x7E8984C;
        public void SetEntryHeight(float newHeight)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, newHeight);
            CallRaw("SetEntryHeight", __pb.Bytes);
        }
    }

    public class TreeView : ListView
    {
        public const string UeClassName = "TreeView";
        public TreeView(System.IntPtr ptr) : base(ptr) {}
        public static new TreeView FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TreeView(p);
        public static TreeView FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TreeView(o.Pointer); }
        public static TreeView[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TreeView[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TreeView(a[i].Pointer); return r; }
        public System.IntPtr BP_OnGetItemChildren => AddrOf(0x378); // 
        public System.IntPtr BP_OnItemExpansionChanged => AddrOf(0x388); // 
        /// <summary>[Native] thunk RVA 0x7E8A208 — hookable via Hooks.InstallAt(NativeFunc_SetItemExpansion).</summary>
        public static System.IntPtr NativeFunc_SetItemExpansion => Memory.ModuleBase() + 0x7E8A208;
        public void SetItemExpansion(Object Item, bool bExpandItem)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Item);
            __pb.Set<byte>(0x8, (byte)(bExpandItem?1:0));
            CallRaw("SetItemExpansion", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8A1F4 — hookable via Hooks.InstallAt(NativeFunc_ExpandAll).</summary>
        public static System.IntPtr NativeFunc_ExpandAll => Memory.ModuleBase() + 0x7E8A1F4;
        public void ExpandAll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ExpandAll", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8A1E0 — hookable via Hooks.InstallAt(NativeFunc_CollapseAll).</summary>
        public static System.IntPtr NativeFunc_CollapseAll => Memory.ModuleBase() + 0x7E8A1E0;
        public void CollapseAll()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CollapseAll", __pb.Bytes);
        }
    }

    public class UMGSequencePlayer : Object
    {
        public const string UeClassName = "UMGSequencePlayer";
        public UMGSequencePlayer(System.IntPtr ptr) : base(ptr) {}
        public static new UMGSequencePlayer FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UMGSequencePlayer(p);
        public static UMGSequencePlayer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UMGSequencePlayer(o.Pointer); }
        public static UMGSequencePlayer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UMGSequencePlayer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UMGSequencePlayer(a[i].Pointer); return r; }
        public WidgetAnimation Animation { get { var __p = GetAt<System.IntPtr>(0x408); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x408, value?.Pointer ?? System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x7E8AC00 — hookable via Hooks.InstallAt(NativeFunc_SetUserTag).</summary>
        public static System.IntPtr NativeFunc_SetUserTag => Memory.ModuleBase() + 0x7E8AC00;
        public void SetUserTag(FName InUserTag)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, InUserTag);
            CallRaw("SetUserTag", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8ACA4 — hookable via Hooks.InstallAt(NativeFunc_GetUserTag).</summary>
        public static System.IntPtr NativeFunc_GetUserTag => Memory.ModuleBase() + 0x7E8ACA4;
        public FName GetUserTag()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetUserTag", __pb.Bytes);
            return __pb.Get<FName>(0x0);
        }
    }

    public class UniformGridPanel : PanelWidget
    {
        public const string UeClassName = "UniformGridPanel";
        public UniformGridPanel(System.IntPtr ptr) : base(ptr) {}
        public static new UniformGridPanel FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UniformGridPanel(p);
        public static UniformGridPanel FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UniformGridPanel(o.Pointer); }
        public static UniformGridPanel[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UniformGridPanel[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UniformGridPanel(a[i].Pointer); return r; }
        public Margin SlotPadding => new Margin(AddrOf(0x11C));
        public float MinDesiredSlotWidth { get => GetAt<float>(0x12C); set => SetAt(0x12C, value); }
        public float MinDesiredSlotHeight { get => GetAt<float>(0x130); set => SetAt(0x130, value); }
        /// <summary>[Native] thunk RVA 0x7E8B8D0 — hookable via Hooks.InstallAt(NativeFunc_SetSlotPadding).</summary>
        public static System.IntPtr NativeFunc_SetSlotPadding => Memory.ModuleBase() + 0x7E8B8D0;
        public void SetSlotPadding(Margin InSlotPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InSlotPadding);
            CallRaw("SetSlotPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8B82C — hookable via Hooks.InstallAt(NativeFunc_SetMinDesiredSlotWidth).</summary>
        public static System.IntPtr NativeFunc_SetMinDesiredSlotWidth => Memory.ModuleBase() + 0x7E8B82C;
        public void SetMinDesiredSlotWidth(float InMinDesiredSlotWidth)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMinDesiredSlotWidth);
            CallRaw("SetMinDesiredSlotWidth", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8B788 — hookable via Hooks.InstallAt(NativeFunc_SetMinDesiredSlotHeight).</summary>
        public static System.IntPtr NativeFunc_SetMinDesiredSlotHeight => Memory.ModuleBase() + 0x7E8B788;
        public void SetMinDesiredSlotHeight(float InMinDesiredSlotHeight)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InMinDesiredSlotHeight);
            CallRaw("SetMinDesiredSlotHeight", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8B658 — hookable via Hooks.InstallAt(NativeFunc_AddChildToUniformGrid).</summary>
        public static System.IntPtr NativeFunc_AddChildToUniformGrid => Memory.ModuleBase() + 0x7E8B658;
        public UniformGridSlot AddChildToUniformGrid(Widget Content, int InRow, int InColumn)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Content);
            __pb.Set(0x8, InRow);
            __pb.Set(0xC, InColumn);
            CallRaw("AddChildToUniformGrid", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new UniformGridSlot(__p); }
        }
    }

    public class UniformGridSlot : PanelSlot
    {
        public const string UeClassName = "UniformGridSlot";
        public UniformGridSlot(System.IntPtr ptr) : base(ptr) {}
        public static new UniformGridSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UniformGridSlot(p);
        public static UniformGridSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UniformGridSlot(o.Pointer); }
        public static UniformGridSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UniformGridSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UniformGridSlot(a[i].Pointer); return r; }
        public byte HorizontalAlignment { get => GetAt<byte>(0x38); set => SetAt(0x38, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x39); set => SetAt(0x39, value); }
        public int row { get => GetAt<int>(0x3C); set => SetAt(0x3C, value); }
        public int Column { get => GetAt<int>(0x40); set => SetAt(0x40, value); }
        /// <summary>[Native] thunk RVA 0x7E8C244 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E8C244;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8C430 — hookable via Hooks.InstallAt(NativeFunc_SetRow).</summary>
        public static System.IntPtr NativeFunc_SetRow => Memory.ModuleBase() + 0x7E8C430;
        public void SetRow(int InRow)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InRow);
            CallRaw("SetRow", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8C2E8 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E8C2E8;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E8C38C — hookable via Hooks.InstallAt(NativeFunc_SetColumn).</summary>
        public static System.IntPtr NativeFunc_SetColumn => Memory.ModuleBase() + 0x7E8C38C;
        public void SetColumn(int InColumn)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InColumn);
            CallRaw("SetColumn", __pb.Bytes);
        }
    }

    public class VerticalBox : PanelWidget
    {
        public const string UeClassName = "VerticalBox";
        public VerticalBox(System.IntPtr ptr) : base(ptr) {}
        public static new VerticalBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VerticalBox(p);
        public static VerticalBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VerticalBox(o.Pointer); }
        public static VerticalBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VerticalBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VerticalBox(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E977A0 — hookable via Hooks.InstallAt(NativeFunc_AddChildToVerticalBox).</summary>
        public static System.IntPtr NativeFunc_AddChildToVerticalBox => Memory.ModuleBase() + 0x7E977A0;
        public VerticalBoxSlot AddChildToVerticalBox(Widget Content)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Content);
            CallRaw("AddChildToVerticalBox", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new VerticalBoxSlot(__p); }
        }
    }

    public class VerticalBoxSlot : PanelSlot
    {
        public const string UeClassName = "VerticalBoxSlot";
        public VerticalBoxSlot(System.IntPtr ptr) : base(ptr) {}
        public static new VerticalBoxSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VerticalBoxSlot(p);
        public static VerticalBoxSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VerticalBoxSlot(o.Pointer); }
        public static VerticalBoxSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VerticalBoxSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VerticalBoxSlot(a[i].Pointer); return r; }
        public SlateChildSize Size => new SlateChildSize(AddrOf(0x38));
        public Margin Padding => new Margin(AddrOf(0x40));
        public byte HorizontalAlignment { get => GetAt<byte>(0x58); set => SetAt(0x58, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x59); set => SetAt(0x59, value); }
        /// <summary>[Native] thunk RVA 0x7E98024 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7E98024;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9816C — hookable via Hooks.InstallAt(NativeFunc_SetSize).</summary>
        public static System.IntPtr NativeFunc_SetSize => Memory.ModuleBase() + 0x7E9816C;
        public void SetSize(SlateChildSize InSize)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InSize);
            CallRaw("SetSize", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9821C — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7E9821C;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E980C8 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7E980C8;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class Viewport : ContentWidget
    {
        public const string UeClassName = "Viewport";
        public Viewport(System.IntPtr ptr) : base(ptr) {}
        public static new Viewport FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Viewport(p);
        public static Viewport FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Viewport(o.Pointer); }
        public static Viewport[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Viewport[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Viewport(a[i].Pointer); return r; }
        public LinearColor BackgroundColor => new LinearColor(AddrOf(0x11C));
        /// <summary>[Native] thunk RVA 0x7E98B50 — hookable via Hooks.InstallAt(NativeFunc_Spawn).</summary>
        public static System.IntPtr NativeFunc_Spawn => Memory.ModuleBase() + 0x7E98B50;
        public Actor Spawn(Actor ActorClass)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, ActorClass);
            CallRaw("Spawn", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new Actor(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E98BFC — hookable via Hooks.InstallAt(NativeFunc_SetViewRotation).</summary>
        public static System.IntPtr NativeFunc_SetViewRotation => Memory.ModuleBase() + 0x7E98BFC;
        public void SetViewRotation(Rotator Rotation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, Rotation);
            CallRaw("SetViewRotation", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E98CD8 — hookable via Hooks.InstallAt(NativeFunc_SetViewLocation).</summary>
        public static System.IntPtr NativeFunc_SetViewLocation => Memory.ModuleBase() + 0x7E98CD8;
        public void SetViewLocation(Vector Location)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, Location);
            CallRaw("SetViewLocation", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E98CA0 — hookable via Hooks.InstallAt(NativeFunc_GetViewRotation).</summary>
        public static System.IntPtr NativeFunc_GetViewRotation => Memory.ModuleBase() + 0x7E98CA0;
        public Rotator GetViewRotation()
        {
            var __pb = new ParamBuffer(12);
            CallRaw("GetViewRotation", __pb.Bytes);
            return __pb.Get<Rotator>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E98DB4 — hookable via Hooks.InstallAt(NativeFunc_GetViewportWorld).</summary>
        public static System.IntPtr NativeFunc_GetViewportWorld => Memory.ModuleBase() + 0x7E98DB4;
        public World GetViewportWorld()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetViewportWorld", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new World(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E98D7C — hookable via Hooks.InstallAt(NativeFunc_GetViewLocation).</summary>
        public static System.IntPtr NativeFunc_GetViewLocation => Memory.ModuleBase() + 0x7E98D7C;
        public Vector GetViewLocation()
        {
            var __pb = new ParamBuffer(12);
            CallRaw("GetViewLocation", __pb.Bytes);
            return __pb.Get<Vector>(0x0);
        }
    }

    public class VisibilityBinding : PropertyBinding
    {
        public const string UeClassName = "VisibilityBinding";
        public VisibilityBinding(System.IntPtr ptr) : base(ptr) {}
        public static new VisibilityBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VisibilityBinding(p);
        public static VisibilityBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VisibilityBinding(o.Pointer); }
        public static VisibilityBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VisibilityBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VisibilityBinding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7E99750 — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7E99750;
        public ESlateVisibility GetValue()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("GetValue", __pb.Bytes);
            return (ESlateVisibility)__pb.Get<byte>(0x0);
        }
    }

    public class WidgetAnimation : MovieSceneSequence
    {
        public const string UeClassName = "WidgetAnimation";
        public WidgetAnimation(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetAnimation FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetAnimation(p);
        public static WidgetAnimation FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetAnimation(o.Pointer); }
        public static WidgetAnimation[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetAnimation[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetAnimation(a[i].Pointer); return r; }
        public MovieScene MovieScene { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new MovieScene(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> AnimationBindings => new TArray<System.IntPtr>(AddrOf(0x350)); // TArray<struct>
        public bool bLegacyFinishOnStop { get => Native.GetPropBool(Pointer, "bLegacyFinishOnStop"); set => Native.SetPropBool(Pointer, "bLegacyFinishOnStop", value); }
        public string DisplayLabel => Native.GetPropString(Pointer, "DisplayLabel"); // FString
        /// <summary>[Native] thunk RVA 0x7E9DC44 — hookable via Hooks.InstallAt(NativeFunc_UnbindFromAnimationStarted).</summary>
        public static System.IntPtr NativeFunc_UnbindFromAnimationStarted => Memory.ModuleBase() + 0x7E9DC44;
        public void UnbindFromAnimationStarted(UserWidget Widget, System.IntPtr Delegate)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Widget);
            __pb.Set<System.IntPtr>(0x8, Delegate);
            CallRaw("UnbindFromAnimationStarted", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9D9C0 — hookable via Hooks.InstallAt(NativeFunc_UnbindFromAnimationFinished).</summary>
        public static System.IntPtr NativeFunc_UnbindFromAnimationFinished => Memory.ModuleBase() + 0x7E9D9C0;
        public void UnbindFromAnimationFinished(UserWidget Widget, System.IntPtr Delegate)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Widget);
            __pb.Set<System.IntPtr>(0x8, Delegate);
            CallRaw("UnbindFromAnimationFinished", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9DBA0 — hookable via Hooks.InstallAt(NativeFunc_UnbindAllFromAnimationStarted).</summary>
        public static System.IntPtr NativeFunc_UnbindAllFromAnimationStarted => Memory.ModuleBase() + 0x7E9DBA0;
        public void UnbindAllFromAnimationStarted(UserWidget Widget)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Widget);
            CallRaw("UnbindAllFromAnimationStarted", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9D91C — hookable via Hooks.InstallAt(NativeFunc_UnbindAllFromAnimationFinished).</summary>
        public static System.IntPtr NativeFunc_UnbindAllFromAnimationFinished => Memory.ModuleBase() + 0x7E9D91C;
        public void UnbindAllFromAnimationFinished(UserWidget Widget)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Widget);
            CallRaw("UnbindAllFromAnimationFinished", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9DE58 — hookable via Hooks.InstallAt(NativeFunc_GetStartTime).</summary>
        public static System.IntPtr NativeFunc_GetStartTime => Memory.ModuleBase() + 0x7E9DE58;
        public float GetStartTime()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetStartTime", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9DE24 — hookable via Hooks.InstallAt(NativeFunc_GetEndTime).</summary>
        public static System.IntPtr NativeFunc_GetEndTime => Memory.ModuleBase() + 0x7E9DE24;
        public float GetEndTime()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetEndTime", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7E9DD34 — hookable via Hooks.InstallAt(NativeFunc_BindToAnimationStarted).</summary>
        public static System.IntPtr NativeFunc_BindToAnimationStarted => Memory.ModuleBase() + 0x7E9DD34;
        public void BindToAnimationStarted(UserWidget Widget, System.IntPtr Delegate)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Widget);
            __pb.Set<System.IntPtr>(0x8, Delegate);
            CallRaw("BindToAnimationStarted", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7E9DAB0 — hookable via Hooks.InstallAt(NativeFunc_BindToAnimationFinished).</summary>
        public static System.IntPtr NativeFunc_BindToAnimationFinished => Memory.ModuleBase() + 0x7E9DAB0;
        public void BindToAnimationFinished(UserWidget Widget, System.IntPtr Delegate)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, Widget);
            __pb.Set<System.IntPtr>(0x8, Delegate);
            CallRaw("BindToAnimationFinished", __pb.Bytes);
        }
    }

    public class WidgetAnimationDelegateBinding : DynamicBlueprintBinding
    {
        public const string UeClassName = "WidgetAnimationDelegateBinding";
        public WidgetAnimationDelegateBinding(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetAnimationDelegateBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetAnimationDelegateBinding(p);
        public static WidgetAnimationDelegateBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetAnimationDelegateBinding(o.Pointer); }
        public static WidgetAnimationDelegateBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetAnimationDelegateBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetAnimationDelegateBinding(a[i].Pointer); return r; }
        public TArray<System.IntPtr> WidgetAnimationDelegateBindings => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<struct>
    }

    public class WidgetAnimationPlayCallbackProxy : Object
    {
        public const string UeClassName = "WidgetAnimationPlayCallbackProxy";
        public WidgetAnimationPlayCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetAnimationPlayCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetAnimationPlayCallbackProxy(p);
        public static WidgetAnimationPlayCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetAnimationPlayCallbackProxy(o.Pointer); }
        public static WidgetAnimationPlayCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetAnimationPlayCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetAnimationPlayCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr Finished => AddrOf(0x28); // 
        /// <summary>[Native] thunk RVA 0x7E9F814 — hookable via Hooks.InstallAt(NativeFunc_CreatePlayAnimationTimeRangeProxyObject).</summary>
        public static System.IntPtr NativeFunc_CreatePlayAnimationTimeRangeProxyObject => Memory.ModuleBase() + 0x7E9F814;
        public WidgetAnimationPlayCallbackProxy CreatePlayAnimationTimeRangeProxyObject(UMGSequencePlayer Result, UserWidget Widget, WidgetAnimation InAnimation, float StartAtTime, float EndAtTime, int NumLoopsToPlay, byte PlayMode, float PlaybackSpeed)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, Result);
            __pb.SetObject(0x8, Widget);
            __pb.SetObject(0x10, InAnimation);
            __pb.Set(0x18, StartAtTime);
            __pb.Set(0x1C, EndAtTime);
            __pb.Set(0x20, NumLoopsToPlay);
            __pb.Set(0x24, PlayMode);
            __pb.Set(0x28, PlaybackSpeed);
            CallRaw("CreatePlayAnimationTimeRangeProxyObject", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new WidgetAnimationPlayCallbackProxy(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7E9FA98 — hookable via Hooks.InstallAt(NativeFunc_CreatePlayAnimationProxyObject).</summary>
        public static System.IntPtr NativeFunc_CreatePlayAnimationProxyObject => Memory.ModuleBase() + 0x7E9FA98;
        public WidgetAnimationPlayCallbackProxy CreatePlayAnimationProxyObject(UMGSequencePlayer Result, UserWidget Widget, WidgetAnimation InAnimation, float StartAtTime, int NumLoopsToPlay, byte PlayMode, float PlaybackSpeed)
        {
            var __pb = new ParamBuffer(48);
            __pb.SetObject(0x0, Result);
            __pb.SetObject(0x8, Widget);
            __pb.SetObject(0x10, InAnimation);
            __pb.Set(0x18, StartAtTime);
            __pb.Set(0x1C, NumLoopsToPlay);
            __pb.Set(0x20, PlayMode);
            __pb.Set(0x24, PlaybackSpeed);
            CallRaw("CreatePlayAnimationProxyObject", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new WidgetAnimationPlayCallbackProxy(__p); }
        }
    }

    public class WidgetBinding : PropertyBinding
    {
        public const string UeClassName = "WidgetBinding";
        public WidgetBinding(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetBinding FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetBinding(p);
        public static WidgetBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetBinding(o.Pointer); }
        public static WidgetBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetBinding(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7EA04DC — hookable via Hooks.InstallAt(NativeFunc_GetValue).</summary>
        public static System.IntPtr NativeFunc_GetValue => Memory.ModuleBase() + 0x7EA04DC;
        public Widget GetValue()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetValue", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Widget(__p); }
        }
    }

    public class WidgetBlueprintGeneratedClass : BlueprintGeneratedClass
    {
        public const string UeClassName = "WidgetBlueprintGeneratedClass";
        public WidgetBlueprintGeneratedClass(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetBlueprintGeneratedClass FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetBlueprintGeneratedClass(p);
        public static WidgetBlueprintGeneratedClass FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetBlueprintGeneratedClass(o.Pointer); }
        public static WidgetBlueprintGeneratedClass[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetBlueprintGeneratedClass[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetBlueprintGeneratedClass(a[i].Pointer); return r; }
        public WidgetTree WidgetTree { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new WidgetTree(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public bool bAllowTemplate { get => Native.GetPropBool(Pointer, "bAllowTemplate"); set => Native.SetPropBool(Pointer, "bAllowTemplate", value); }
        public bool bAllowDynamicCreation { get => Native.GetPropBool(Pointer, "bAllowDynamicCreation"); set => Native.SetPropBool(Pointer, "bAllowDynamicCreation", value); }
        public bool bValidTemplate { get => Native.GetPropBool(Pointer, "bValidTemplate"); set => Native.SetPropBool(Pointer, "bValidTemplate", value); }
        public bool bTemplateInitialized { get => Native.GetPropBool(Pointer, "bTemplateInitialized"); set => Native.SetPropBool(Pointer, "bTemplateInitialized", value); }
        public bool bCookedTemplate { get => Native.GetPropBool(Pointer, "bCookedTemplate"); set => Native.SetPropBool(Pointer, "bCookedTemplate", value); }
        public bool bClassRequiresNativeTick { get => Native.GetPropBool(Pointer, "bClassRequiresNativeTick"); set => Native.SetPropBool(Pointer, "bClassRequiresNativeTick", value); }
        public TArray<System.IntPtr> Bindings => new TArray<System.IntPtr>(AddrOf(0x368)); // TArray<struct>
        public TArray<System.IntPtr> Animations => new TArray<System.IntPtr>(AddrOf(0x378)); // TArray<UObject*>
        public TArray<System.IntPtr> NamedSlots => new TArray<System.IntPtr>(AddrOf(0x388)); // TArray<FName>
        public UserWidget TemplateAsset { get { var __p = GetAt<System.IntPtr>(0x398); return __p==System.IntPtr.Zero?null:new UserWidget(__p); } set => SetAt(0x398, value?.Pointer ?? System.IntPtr.Zero); }
        public UserWidget Template { get { var __p = GetAt<System.IntPtr>(0x3C0); return __p==System.IntPtr.Zero?null:new UserWidget(__p); } set => SetAt(0x3C0, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class WidgetBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "WidgetBlueprintLibrary";
        public WidgetBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetBlueprintLibrary(p);
        public static WidgetBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetBlueprintLibrary(o.Pointer); }
        public static WidgetBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7EA5118 — hookable via Hooks.InstallAt(NativeFunc_UnlockMouse).</summary>
        public static System.IntPtr NativeFunc_UnlockMouse => Memory.ModuleBase() + 0x7EA5118;
        public EventReply UnlockMouse(EventReply Reply)
        {
            var __pb = new ParamBuffer(368);
            __pb.Set<System.IntPtr>(0x0, Reply);
            CallRaw("UnlockMouse", __pb.Bytes);
            return __pb.Get<EventReply>(0xB8);
        }
        /// <summary>[Native] thunk RVA 0x7EA55F8 — hookable via Hooks.InstallAt(NativeFunc_Unhandled).</summary>
        public static System.IntPtr NativeFunc_Unhandled => Memory.ModuleBase() + 0x7EA55F8;
        public EventReply Unhandled()
        {
            var __pb = new ParamBuffer(184);
            CallRaw("Unhandled", __pb.Bytes);
            return __pb.Get<EventReply>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA1FF8 — hookable via Hooks.InstallAt(NativeFunc_SetWindowTitleBarState).</summary>
        public static System.IntPtr NativeFunc_SetWindowTitleBarState => Memory.ModuleBase() + 0x7EA1FF8;
        public void SetWindowTitleBarState(Widget TitleBarContent, EWindowTitleBarMode Mode, bool bTitleBarDragEnabled, bool bWindowButtonsVisible, bool bTitleBarVisible)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, TitleBarContent);
            __pb.Set<byte>(0x8, (byte)Mode);
            __pb.Set<byte>(0x9, (byte)(bTitleBarDragEnabled?1:0));
            __pb.Set<byte>(0xA, (byte)(bWindowButtonsVisible?1:0));
            __pb.Set<byte>(0xB, (byte)(bTitleBarVisible?1:0));
            CallRaw("SetWindowTitleBarState", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA1F40 — hookable via Hooks.InstallAt(NativeFunc_SetWindowTitleBarOnCloseClickedDelegate).</summary>
        public static System.IntPtr NativeFunc_SetWindowTitleBarOnCloseClickedDelegate => Memory.ModuleBase() + 0x7EA1F40;
        public void SetWindowTitleBarOnCloseClickedDelegate(System.IntPtr Delegate)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Delegate);
            CallRaw("SetWindowTitleBarOnCloseClickedDelegate", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA1EA4 — hookable via Hooks.InstallAt(NativeFunc_SetWindowTitleBarCloseButtonActive).</summary>
        public static System.IntPtr NativeFunc_SetWindowTitleBarCloseButtonActive => Memory.ModuleBase() + 0x7EA1EA4;
        public void SetWindowTitleBarCloseButtonActive(bool bActive)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bActive?1:0));
            CallRaw("SetWindowTitleBarCloseButtonActive", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA4F70 — hookable via Hooks.InstallAt(NativeFunc_SetUserFocus).</summary>
        public static System.IntPtr NativeFunc_SetUserFocus => Memory.ModuleBase() + 0x7EA4F70;
        public EventReply SetUserFocus(EventReply Reply, Widget FocusWidget, bool bInAllUsers)
        {
            var __pb = new ParamBuffer(384);
            __pb.Set<System.IntPtr>(0x0, Reply);
            __pb.SetObject(0xB8, FocusWidget);
            __pb.Set<byte>(0xC0, (byte)(bInAllUsers?1:0));
            CallRaw("SetUserFocus", __pb.Bytes);
            return __pb.Get<EventReply>(0xC8);
        }
        /// <summary>[Native] thunk RVA 0x7EA49A8 — hookable via Hooks.InstallAt(NativeFunc_SetMousePosition).</summary>
        public static System.IntPtr NativeFunc_SetMousePosition => Memory.ModuleBase() + 0x7EA49A8;
        public EventReply SetMousePosition(EventReply Reply, Vector2D NewMousePosition)
        {
            var __pb = new ParamBuffer(376);
            __pb.Set<System.IntPtr>(0x0, Reply);
            __pb.Set<System.IntPtr>(0xB8, NewMousePosition);
            CallRaw("SetMousePosition", __pb.Bytes);
            return __pb.Get<EventReply>(0xC0);
        }
        /// <summary>[Native] thunk RVA 0x7EA6414 — hookable via Hooks.InstallAt(NativeFunc_SetInputMode_UIOnlyEx).</summary>
        public static System.IntPtr NativeFunc_SetInputMode_UIOnlyEx => Memory.ModuleBase() + 0x7EA6414;
        public void SetInputMode_UIOnlyEx(PlayerController PlayerController, Widget InWidgetToFocus, EMouseLockMode InMouseLockMode)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, PlayerController);
            __pb.SetObject(0x8, InWidgetToFocus);
            __pb.Set<byte>(0x10, (byte)InMouseLockMode);
            CallRaw("SetInputMode_UIOnlyEx", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA652C — hookable via Hooks.InstallAt(NativeFunc_SetInputMode_UIOnly).</summary>
        public static System.IntPtr NativeFunc_SetInputMode_UIOnly => Memory.ModuleBase() + 0x7EA652C;
        public void SetInputMode_UIOnly(PlayerController Target, Widget InWidgetToFocus, bool bLockMouseToViewport)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, Target);
            __pb.SetObject(0x8, InWidgetToFocus);
            __pb.Set<byte>(0x10, (byte)(bLockMouseToViewport?1:0));
            CallRaw("SetInputMode_UIOnly", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA60A4 — hookable via Hooks.InstallAt(NativeFunc_SetInputMode_GameOnly).</summary>
        public static System.IntPtr NativeFunc_SetInputMode_GameOnly => Memory.ModuleBase() + 0x7EA60A4;
        public void SetInputMode_GameOnly(PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, PlayerController);
            CallRaw("SetInputMode_GameOnly", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA6138 — hookable via Hooks.InstallAt(NativeFunc_SetInputMode_GameAndUIEx).</summary>
        public static System.IntPtr NativeFunc_SetInputMode_GameAndUIEx => Memory.ModuleBase() + 0x7EA6138;
        public void SetInputMode_GameAndUIEx(PlayerController PlayerController, Widget InWidgetToFocus, EMouseLockMode InMouseLockMode, bool bHideCursorDuringCapture)
        {
            var __pb = new ParamBuffer(18);
            __pb.SetObject(0x0, PlayerController);
            __pb.SetObject(0x8, InWidgetToFocus);
            __pb.Set<byte>(0x10, (byte)InMouseLockMode);
            __pb.Set<byte>(0x11, (byte)(bHideCursorDuringCapture?1:0));
            CallRaw("SetInputMode_GameAndUIEx", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA629C — hookable via Hooks.InstallAt(NativeFunc_SetInputMode_GameAndUI).</summary>
        public static System.IntPtr NativeFunc_SetInputMode_GameAndUI => Memory.ModuleBase() + 0x7EA629C;
        public void SetInputMode_GameAndUI(PlayerController Target, Widget InWidgetToFocus, bool bLockMouseToViewport, bool bHideCursorDuringCapture)
        {
            var __pb = new ParamBuffer(18);
            __pb.SetObject(0x0, Target);
            __pb.SetObject(0x8, InWidgetToFocus);
            __pb.Set<byte>(0x10, (byte)(bLockMouseToViewport?1:0));
            __pb.Set<byte>(0x11, (byte)(bHideCursorDuringCapture?1:0));
            CallRaw("SetInputMode_GameAndUI", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA21C4 — hookable via Hooks.InstallAt(NativeFunc_SetHardwareCursor).</summary>
        public static System.IntPtr NativeFunc_SetHardwareCursor => Memory.ModuleBase() + 0x7EA21C4;
        public bool SetHardwareCursor(Object WorldContextObject, byte CursorShape, FName CursorName, Vector2D HotSpot)
        {
            var __pb = new ParamBuffer(29);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set(0x8, CursorShape);
            __pb.Set(0xC, CursorName);
            __pb.Set<System.IntPtr>(0x14, HotSpot);
            CallRaw("SetHardwareCursor", __pb.Bytes);
            return __pb.Get<byte>(0x1C) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EA6090 — hookable via Hooks.InstallAt(NativeFunc_SetFocusToGameViewport).</summary>
        public static System.IntPtr NativeFunc_SetFocusToGameViewport => Memory.ModuleBase() + 0x7EA6090;
        public void SetFocusToGameViewport()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetFocusToGameViewport", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA2330 — hookable via Hooks.InstallAt(NativeFunc_SetColorVisionDeficiencyType).</summary>
        public static System.IntPtr NativeFunc_SetColorVisionDeficiencyType => Memory.ModuleBase() + 0x7EA2330;
        public void SetColorVisionDeficiencyType(EColorVisionDeficiency Type, float Severity, bool CorrectDeficiency, bool ShowCorrectionWithDeficiency)
        {
            var __pb = new ParamBuffer(10);
            __pb.Set<byte>(0x0, (byte)Type);
            __pb.Set(0x4, Severity);
            __pb.Set<byte>(0x8, (byte)(CorrectDeficiency?1:0));
            __pb.Set<byte>(0x9, (byte)(ShowCorrectionWithDeficiency?1:0));
            CallRaw("SetColorVisionDeficiencyType", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA355C — hookable via Hooks.InstallAt(NativeFunc_SetBrushResourceToTexture).</summary>
        public static System.IntPtr NativeFunc_SetBrushResourceToTexture => Memory.ModuleBase() + 0x7EA355C;
        public void SetBrushResourceToTexture(SlateBrush Brush, Texture2D Texture)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<System.IntPtr>(0x0, Brush);
            __pb.SetObject(0x88, Texture);
            CallRaw("SetBrushResourceToTexture", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA3348 — hookable via Hooks.InstallAt(NativeFunc_SetBrushResourceToMaterial).</summary>
        public static System.IntPtr NativeFunc_SetBrushResourceToMaterial => Memory.ModuleBase() + 0x7EA3348;
        public void SetBrushResourceToMaterial(SlateBrush Brush, MaterialInterface Material)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<System.IntPtr>(0x0, Brush);
            __pb.SetObject(0x88, Material);
            CallRaw("SetBrushResourceToMaterial", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA1FE4 — hookable via Hooks.InstallAt(NativeFunc_RestorePreviousWindowTitleBarState).</summary>
        public static System.IntPtr NativeFunc_RestorePreviousWindowTitleBarState => Memory.ModuleBase() + 0x7EA1FE4;
        public void RestorePreviousWindowTitleBarState()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RestorePreviousWindowTitleBarState", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA5388 — hookable via Hooks.InstallAt(NativeFunc_ReleaseMouseCapture).</summary>
        public static System.IntPtr NativeFunc_ReleaseMouseCapture => Memory.ModuleBase() + 0x7EA5388;
        public EventReply ReleaseMouseCapture(EventReply Reply)
        {
            var __pb = new ParamBuffer(368);
            __pb.Set<System.IntPtr>(0x0, Reply);
            CallRaw("ReleaseMouseCapture", __pb.Bytes);
            return __pb.Get<EventReply>(0xB8);
        }
        /// <summary>[Native] thunk RVA 0x7EA4B00 — hookable via Hooks.InstallAt(NativeFunc_ReleaseJoystickCapture).</summary>
        public static System.IntPtr NativeFunc_ReleaseJoystickCapture => Memory.ModuleBase() + 0x7EA4B00;
        public EventReply ReleaseJoystickCapture(EventReply Reply, bool bInAllJoysticks)
        {
            var __pb = new ParamBuffer(376);
            __pb.Set<System.IntPtr>(0x0, Reply);
            __pb.Set<byte>(0xB8, (byte)(bInAllJoysticks?1:0));
            CallRaw("ReleaseJoystickCapture", __pb.Bytes);
            return __pb.Get<EventReply>(0xC0);
        }
        public void OnGameWindowCloseButtonClickedDelegate__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnGameWindowCloseButtonClickedDelegate__DelegateSignature", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA3208 — hookable via Hooks.InstallAt(NativeFunc_NoResourceBrush).</summary>
        public static System.IntPtr NativeFunc_NoResourceBrush => Memory.ModuleBase() + 0x7EA3208;
        public SlateBrush NoResourceBrush()
        {
            var __pb = new ParamBuffer(136);
            CallRaw("NoResourceBrush", __pb.Bytes);
            return __pb.Get<SlateBrush>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA3F08 — hookable via Hooks.InstallAt(NativeFunc_MakeBrushFromTexture).</summary>
        public static System.IntPtr NativeFunc_MakeBrushFromTexture => Memory.ModuleBase() + 0x7EA3F08;
        public SlateBrush MakeBrushFromTexture(Texture2D Texture, int Width, int Height)
        {
            var __pb = new ParamBuffer(152);
            __pb.SetObject(0x0, Texture);
            __pb.Set(0x8, Width);
            __pb.Set(0xC, Height);
            CallRaw("MakeBrushFromTexture", __pb.Bytes);
            return __pb.Get<SlateBrush>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x7EA3D04 — hookable via Hooks.InstallAt(NativeFunc_MakeBrushFromMaterial).</summary>
        public static System.IntPtr NativeFunc_MakeBrushFromMaterial => Memory.ModuleBase() + 0x7EA3D04;
        public SlateBrush MakeBrushFromMaterial(MaterialInterface Material, int Width, int Height)
        {
            var __pb = new ParamBuffer(152);
            __pb.SetObject(0x0, Material);
            __pb.Set(0x8, Width);
            __pb.Set(0xC, Height);
            CallRaw("MakeBrushFromMaterial", __pb.Bytes);
            return __pb.Get<SlateBrush>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x7EA410C — hookable via Hooks.InstallAt(NativeFunc_MakeBrushFromAsset).</summary>
        public static System.IntPtr NativeFunc_MakeBrushFromAsset => Memory.ModuleBase() + 0x7EA410C;
        public SlateBrush MakeBrushFromAsset(SlateBrushAsset BrushAsset)
        {
            var __pb = new ParamBuffer(144);
            __pb.SetObject(0x0, BrushAsset);
            CallRaw("MakeBrushFromAsset", __pb.Bytes);
            return __pb.Get<SlateBrush>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7EA522C — hookable via Hooks.InstallAt(NativeFunc_LockMouse).</summary>
        public static System.IntPtr NativeFunc_LockMouse => Memory.ModuleBase() + 0x7EA522C;
        public EventReply LockMouse(EventReply Reply, Widget CapturingWidget)
        {
            var __pb = new ParamBuffer(376);
            __pb.Set<System.IntPtr>(0x0, Reply);
            __pb.SetObject(0xB8, CapturingWidget);
            CallRaw("LockMouse", __pb.Bytes);
            return __pb.Get<EventReply>(0xC0);
        }
        /// <summary>[Native] thunk RVA 0x7EA42D4 — hookable via Hooks.InstallAt(NativeFunc_IsDragDropping).</summary>
        public static System.IntPtr NativeFunc_IsDragDropping => Memory.ModuleBase() + 0x7EA42D4;
        public bool IsDragDropping()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsDragDropping", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EA5668 — hookable via Hooks.InstallAt(NativeFunc_Handled).</summary>
        public static System.IntPtr NativeFunc_Handled => Memory.ModuleBase() + 0x7EA5668;
        public EventReply Handled()
        {
            var __pb = new ParamBuffer(184);
            CallRaw("Handled", __pb.Bytes);
            return __pb.Get<EventReply>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EA24AC — hookable via Hooks.InstallAt(NativeFunc_GetSafeZonePadding).</summary>
        public static System.IntPtr NativeFunc_GetSafeZonePadding => Memory.ModuleBase() + 0x7EA24AC;
        public void GetSafeZonePadding(Object WorldContextObject, Vector4 SafePadding, Vector2D SafePaddingScale, Vector4 SpillOverPadding)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x10, SafePadding);
            __pb.Set<System.IntPtr>(0x20, SafePaddingScale);
            __pb.Set<System.IntPtr>(0x30, SpillOverPadding);
            CallRaw("GetSafeZonePadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA2968 — hookable via Hooks.InstallAt(NativeFunc_GetKeyEventFromAnalogInputEvent).</summary>
        public static System.IntPtr NativeFunc_GetKeyEventFromAnalogInputEvent => Memory.ModuleBase() + 0x7EA2968;
        public KeyEvent GetKeyEventFromAnalogInputEvent(AnalogInputEvent Event)
        {
            var __pb = new ParamBuffer(120);
            __pb.Set<System.IntPtr>(0x0, Event);
            CallRaw("GetKeyEventFromAnalogInputEvent", __pb.Bytes);
            return __pb.Get<KeyEvent>(0x40);
        }
        /// <summary>[Native] thunk RVA 0x7EA2720 — hookable via Hooks.InstallAt(NativeFunc_GetInputEventFromPointerEvent).</summary>
        public static System.IntPtr NativeFunc_GetInputEventFromPointerEvent => Memory.ModuleBase() + 0x7EA2720;
        public InputEvent GetInputEventFromPointerEvent(PointerEvent Event)
        {
            var __pb = new ParamBuffer(136);
            __pb.Set<System.IntPtr>(0x0, Event);
            CallRaw("GetInputEventFromPointerEvent", __pb.Bytes);
            return __pb.Get<InputEvent>(0x70);
        }
        /// <summary>[Native] thunk RVA 0x7EA2640 — hookable via Hooks.InstallAt(NativeFunc_GetInputEventFromNavigationEvent).</summary>
        public static System.IntPtr NativeFunc_GetInputEventFromNavigationEvent => Memory.ModuleBase() + 0x7EA2640;
        public InputEvent GetInputEventFromNavigationEvent(NavigationEvent Event)
        {
            var __pb = new ParamBuffer(56);
            __pb.Set<System.IntPtr>(0x0, Event);
            CallRaw("GetInputEventFromNavigationEvent", __pb.Bytes);
            return __pb.Get<InputEvent>(0x20);
        }
        /// <summary>[Native] thunk RVA 0x7EA2BB4 — hookable via Hooks.InstallAt(NativeFunc_GetInputEventFromKeyEvent).</summary>
        public static System.IntPtr NativeFunc_GetInputEventFromKeyEvent => Memory.ModuleBase() + 0x7EA2BB4;
        public InputEvent GetInputEventFromKeyEvent(KeyEvent Event)
        {
            var __pb = new ParamBuffer(80);
            __pb.Set<System.IntPtr>(0x0, Event);
            CallRaw("GetInputEventFromKeyEvent", __pb.Bytes);
            return __pb.Get<InputEvent>(0x38);
        }
        /// <summary>[Native] thunk RVA 0x7EA288C — hookable via Hooks.InstallAt(NativeFunc_GetInputEventFromCharacterEvent).</summary>
        public static System.IntPtr NativeFunc_GetInputEventFromCharacterEvent => Memory.ModuleBase() + 0x7EA288C;
        public InputEvent GetInputEventFromCharacterEvent(CharacterEvent Event)
        {
            var __pb = new ParamBuffer(56);
            __pb.Set<System.IntPtr>(0x0, Event);
            CallRaw("GetInputEventFromCharacterEvent", __pb.Bytes);
            return __pb.Get<InputEvent>(0x20);
        }
        /// <summary>[Native] thunk RVA 0x7EA302C — hookable via Hooks.InstallAt(NativeFunc_GetDynamicMaterial).</summary>
        public static System.IntPtr NativeFunc_GetDynamicMaterial => Memory.ModuleBase() + 0x7EA302C;
        public MaterialInstanceDynamic GetDynamicMaterial(SlateBrush Brush)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<System.IntPtr>(0x0, Brush);
            CallRaw("GetDynamicMaterial", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x88); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA42A0 — hookable via Hooks.InstallAt(NativeFunc_GetDragDroppingContent).</summary>
        public static System.IntPtr NativeFunc_GetDragDroppingContent => Memory.ModuleBase() + 0x7EA42A0;
        public DragDropOperation GetDragDroppingContent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetDragDroppingContent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new DragDropOperation(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA394C — hookable via Hooks.InstallAt(NativeFunc_GetBrushResourceAsTexture2D).</summary>
        public static System.IntPtr NativeFunc_GetBrushResourceAsTexture2D => Memory.ModuleBase() + 0x7EA394C;
        public Texture2D GetBrushResourceAsTexture2D(SlateBrush Brush)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<System.IntPtr>(0x0, Brush);
            CallRaw("GetBrushResourceAsTexture2D", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x88); return __p==System.IntPtr.Zero?null:new Texture2D(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA3770 — hookable via Hooks.InstallAt(NativeFunc_GetBrushResourceAsMaterial).</summary>
        public static System.IntPtr NativeFunc_GetBrushResourceAsMaterial => Memory.ModuleBase() + 0x7EA3770;
        public MaterialInterface GetBrushResourceAsMaterial(SlateBrush Brush)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<System.IntPtr>(0x0, Brush);
            CallRaw("GetBrushResourceAsMaterial", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x88); return __p==System.IntPtr.Zero?null:new MaterialInterface(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA3B28 — hookable via Hooks.InstallAt(NativeFunc_GetBrushResource).</summary>
        public static System.IntPtr NativeFunc_GetBrushResource => Memory.ModuleBase() + 0x7EA3B28;
        public Object GetBrushResource(SlateBrush Brush)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<System.IntPtr>(0x0, Brush);
            CallRaw("GetBrushResource", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x88); return __p==System.IntPtr.Zero?null:new Object(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA2D00 — hookable via Hooks.InstallAt(NativeFunc_GetAllWidgetsWithInterface).</summary>
        public static System.IntPtr NativeFunc_GetAllWidgetsWithInterface => Memory.ModuleBase() + 0x7EA2D00;
        public void GetAllWidgetsWithInterface(Object WorldContextObject, System.IntPtr FoundWidgets, Interface Interface, bool TopLevelOnly)
        {
            var __pb = new ParamBuffer(33);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, FoundWidgets);
            __pb.SetObject(0x18, Interface);
            __pb.Set<byte>(0x20, (byte)(TopLevelOnly?1:0));
            CallRaw("GetAllWidgetsWithInterface", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA2E8C — hookable via Hooks.InstallAt(NativeFunc_GetAllWidgetsOfClass).</summary>
        public static System.IntPtr NativeFunc_GetAllWidgetsOfClass => Memory.ModuleBase() + 0x7EA2E8C;
        public void GetAllWidgetsOfClass(Object WorldContextObject, System.IntPtr FoundWidgets, UserWidget WidgetClass, bool TopLevelOnly)
        {
            var __pb = new ParamBuffer(33);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<System.IntPtr>(0x8, FoundWidgets);
            __pb.SetObject(0x18, WidgetClass);
            __pb.Set<byte>(0x20, (byte)(TopLevelOnly?1:0));
            CallRaw("GetAllWidgetsOfClass", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA430C — hookable via Hooks.InstallAt(NativeFunc_EndDragDrop).</summary>
        public static System.IntPtr NativeFunc_EndDragDrop => Memory.ModuleBase() + 0x7EA430C;
        public EventReply EndDragDrop(EventReply Reply)
        {
            var __pb = new ParamBuffer(368);
            __pb.Set<System.IntPtr>(0x0, Reply);
            CallRaw("EndDragDrop", __pb.Bytes);
            return __pb.Get<EventReply>(0xB8);
        }
        /// <summary>[Native] thunk RVA 0x7EA56D8 — hookable via Hooks.InstallAt(NativeFunc_DrawTextFormatted).</summary>
        public static System.IntPtr NativeFunc_DrawTextFormatted => Memory.ModuleBase() + 0x7EA56D8;
        public void DrawTextFormatted(PaintContext Context, System.IntPtr Text, Vector2D Position, Font Font, int FontSize, FName FontTypeFace, LinearColor Tint)
        {
            var __pb = new ParamBuffer(116);
            __pb.Set<System.IntPtr>(0x0, Context);
            __pb.Set<System.IntPtr>(0x30, Text);
            __pb.Set<System.IntPtr>(0x48, Position);
            __pb.SetObject(0x50, Font);
            __pb.Set(0x58, FontSize);
            __pb.Set(0x5C, FontTypeFace);
            __pb.Set<System.IntPtr>(0x64, Tint);
            CallRaw("DrawTextFormatted", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA5984 — hookable via Hooks.InstallAt(NativeFunc_DrawText).</summary>
        public static System.IntPtr NativeFunc_DrawText => Memory.ModuleBase() + 0x7EA5984;
        public void DrawText(PaintContext Context, System.IntPtr inString, Vector2D Position, LinearColor Tint)
        {
            var __pb = new ParamBuffer(88);
            __pb.Set<System.IntPtr>(0x0, Context);
            __pb.Set<System.IntPtr>(0x30, inString);
            __pb.Set<System.IntPtr>(0x40, Position);
            __pb.Set<System.IntPtr>(0x48, Tint);
            CallRaw("DrawText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA5AFC — hookable via Hooks.InstallAt(NativeFunc_DrawLines).</summary>
        public static System.IntPtr NativeFunc_DrawLines => Memory.ModuleBase() + 0x7EA5AFC;
        public void DrawLines(PaintContext Context, System.IntPtr Points, LinearColor Tint, bool bAntiAlias, float Thickness)
        {
            var __pb = new ParamBuffer(88);
            __pb.Set<System.IntPtr>(0x0, Context);
            __pb.Set<System.IntPtr>(0x30, Points);
            __pb.Set<System.IntPtr>(0x40, Tint);
            __pb.Set<byte>(0x50, (byte)(bAntiAlias?1:0));
            __pb.Set(0x54, Thickness);
            CallRaw("DrawLines", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA5CE4 — hookable via Hooks.InstallAt(NativeFunc_DrawLine).</summary>
        public static System.IntPtr NativeFunc_DrawLine => Memory.ModuleBase() + 0x7EA5CE4;
        public void DrawLine(PaintContext Context, Vector2D PositionA, Vector2D PositionB, LinearColor Tint, bool bAntiAlias, float Thickness)
        {
            var __pb = new ParamBuffer(88);
            __pb.Set<System.IntPtr>(0x0, Context);
            __pb.Set<System.IntPtr>(0x30, PositionA);
            __pb.Set<System.IntPtr>(0x38, PositionB);
            __pb.Set<System.IntPtr>(0x40, Tint);
            __pb.Set<byte>(0x50, (byte)(bAntiAlias?1:0));
            __pb.Set(0x54, Thickness);
            CallRaw("DrawLine", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA5EE4 — hookable via Hooks.InstallAt(NativeFunc_DrawBox).</summary>
        public static System.IntPtr NativeFunc_DrawBox => Memory.ModuleBase() + 0x7EA5EE4;
        public void DrawBox(PaintContext Context, Vector2D Position, Vector2D Size, SlateBrushAsset Brush, LinearColor Tint)
        {
            var __pb = new ParamBuffer(88);
            __pb.Set<System.IntPtr>(0x0, Context);
            __pb.Set<System.IntPtr>(0x30, Position);
            __pb.Set<System.IntPtr>(0x38, Size);
            __pb.SetObject(0x40, Brush);
            __pb.Set<System.IntPtr>(0x48, Tint);
            CallRaw("DrawBox", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA3018 — hookable via Hooks.InstallAt(NativeFunc_DismissAllMenus).</summary>
        public static System.IntPtr NativeFunc_DismissAllMenus => Memory.ModuleBase() + 0x7EA3018;
        public void DismissAllMenus()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DismissAllMenus", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EA4420 — hookable via Hooks.InstallAt(NativeFunc_DetectDragIfPressed).</summary>
        public static System.IntPtr NativeFunc_DetectDragIfPressed => Memory.ModuleBase() + 0x7EA4420;
        public EventReply DetectDragIfPressed(PointerEvent PointerEvent, Widget WidgetDetectingDrag, Key DragKey)
        {
            var __pb = new ParamBuffer(328);
            __pb.Set<System.IntPtr>(0x0, PointerEvent);
            __pb.SetObject(0x70, WidgetDetectingDrag);
            __pb.Set<System.IntPtr>(0x78, DragKey);
            CallRaw("DetectDragIfPressed", __pb.Bytes);
            return __pb.Get<EventReply>(0x90);
        }
        /// <summary>[Native] thunk RVA 0x7EA4718 — hookable via Hooks.InstallAt(NativeFunc_DetectDrag).</summary>
        public static System.IntPtr NativeFunc_DetectDrag => Memory.ModuleBase() + 0x7EA4718;
        public EventReply DetectDrag(EventReply Reply, Widget WidgetDetectingDrag, Key DragKey)
        {
            var __pb = new ParamBuffer(400);
            __pb.Set<System.IntPtr>(0x0, Reply);
            __pb.SetObject(0xB8, WidgetDetectingDrag);
            __pb.Set<System.IntPtr>(0xC0, DragKey);
            CallRaw("DetectDrag", __pb.Bytes);
            return __pb.Get<EventReply>(0xD8);
        }
        /// <summary>[Native] thunk RVA 0x7EA664C — hookable via Hooks.InstallAt(NativeFunc_CreateDragDropOperation).</summary>
        public static System.IntPtr NativeFunc_CreateDragDropOperation => Memory.ModuleBase() + 0x7EA664C;
        public DragDropOperation CreateDragDropOperation(DragDropOperation OperationClass)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, OperationClass);
            CallRaw("CreateDragDropOperation", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new DragDropOperation(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA66F0 — hookable via Hooks.InstallAt(NativeFunc_Create).</summary>
        public static System.IntPtr NativeFunc_Create => Memory.ModuleBase() + 0x7EA66F0;
        public UserWidget Create(Object WorldContextObject, UserWidget WidgetType, PlayerController OwningPlayer)
        {
            var __pb = new ParamBuffer(32);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, WidgetType);
            __pb.SetObject(0x10, OwningPlayer);
            CallRaw("Create", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new UserWidget(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EA4C64 — hookable via Hooks.InstallAt(NativeFunc_ClearUserFocus).</summary>
        public static System.IntPtr NativeFunc_ClearUserFocus => Memory.ModuleBase() + 0x7EA4C64;
        public EventReply ClearUserFocus(EventReply Reply, bool bInAllUsers)
        {
            var __pb = new ParamBuffer(376);
            __pb.Set<System.IntPtr>(0x0, Reply);
            __pb.Set<byte>(0xB8, (byte)(bInAllUsers?1:0));
            CallRaw("ClearUserFocus", __pb.Bytes);
            return __pb.Get<EventReply>(0xC0);
        }
        /// <summary>[Native] thunk RVA 0x7EA549C — hookable via Hooks.InstallAt(NativeFunc_CaptureMouse).</summary>
        public static System.IntPtr NativeFunc_CaptureMouse => Memory.ModuleBase() + 0x7EA549C;
        public EventReply CaptureMouse(EventReply Reply, Widget CapturingWidget)
        {
            var __pb = new ParamBuffer(376);
            __pb.Set<System.IntPtr>(0x0, Reply);
            __pb.SetObject(0xB8, CapturingWidget);
            CallRaw("CaptureMouse", __pb.Bytes);
            return __pb.Get<EventReply>(0xC0);
        }
        /// <summary>[Native] thunk RVA 0x7EA4DC8 — hookable via Hooks.InstallAt(NativeFunc_CaptureJoystick).</summary>
        public static System.IntPtr NativeFunc_CaptureJoystick => Memory.ModuleBase() + 0x7EA4DC8;
        public EventReply CaptureJoystick(EventReply Reply, Widget CapturingWidget, bool bInAllJoysticks)
        {
            var __pb = new ParamBuffer(384);
            __pb.Set<System.IntPtr>(0x0, Reply);
            __pb.SetObject(0xB8, CapturingWidget);
            __pb.Set<byte>(0xC0, (byte)(bInAllJoysticks?1:0));
            CallRaw("CaptureJoystick", __pb.Bytes);
            return __pb.Get<EventReply>(0xC8);
        }
        /// <summary>[Native] thunk RVA 0x7EA428C — hookable via Hooks.InstallAt(NativeFunc_CancelDragDrop).</summary>
        public static System.IntPtr NativeFunc_CancelDragDrop => Memory.ModuleBase() + 0x7EA428C;
        public void CancelDragDrop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CancelDragDrop", __pb.Bytes);
        }
    }

    public class WidgetInteractionComponent : SceneComponent
    {
        public const string UeClassName = "WidgetInteractionComponent";
        public WidgetInteractionComponent(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetInteractionComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetInteractionComponent(p);
        public static WidgetInteractionComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetInteractionComponent(o.Pointer); }
        public static WidgetInteractionComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetInteractionComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetInteractionComponent(a[i].Pointer); return r; }
        public System.IntPtr OnHoveredWidgetChanged => AddrOf(0x1F0); // 
        public int VirtualUserIndex { get => GetAt<int>(0x210); set => SetAt(0x210, value); }
        public float PointerIndex { get => GetAt<float>(0x214); set => SetAt(0x214, value); }
        public byte TraceChannel { get => GetAt<byte>(0x218); set => SetAt(0x218, value); }
        public float InteractionDistance { get => GetAt<float>(0x21C); set => SetAt(0x21C, value); }
        public EWidgetInteractionSource InteractionSource { get => (EWidgetInteractionSource)GetAt<byte>(0x220); set => SetAt(0x220, (byte)value); }
        public bool bEnableHitTesting { get => Native.GetPropBool(Pointer, "bEnableHitTesting"); set => Native.SetPropBool(Pointer, "bEnableHitTesting", value); }
        public bool bShowDebug { get => Native.GetPropBool(Pointer, "bShowDebug"); set => Native.SetPropBool(Pointer, "bShowDebug", value); }
        public LinearColor DebugColor => new LinearColor(AddrOf(0x224));
        public HitResult CustomHitResult => new HitResult(AddrOf(0x2B0));
        public Vector2D LocalHitLocation => new Vector2D(AddrOf(0x338));
        public Vector2D LastLocalHitLocation => new Vector2D(AddrOf(0x340));
        public WidgetComponent HoveredWidgetComponent { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public HitResult LastHitResult => new HitResult(AddrOf(0x350));
        public bool bIsHoveredWidgetInteractable { get => Native.GetPropBool(Pointer, "bIsHoveredWidgetInteractable"); set => Native.SetPropBool(Pointer, "bIsHoveredWidgetInteractable", value); }
        public bool bIsHoveredWidgetFocusable { get => Native.GetPropBool(Pointer, "bIsHoveredWidgetFocusable"); set => Native.SetPropBool(Pointer, "bIsHoveredWidgetFocusable", value); }
        public bool bIsHoveredWidgetHitTestVisible { get => Native.GetPropBool(Pointer, "bIsHoveredWidgetHitTestVisible"); set => Native.SetPropBool(Pointer, "bIsHoveredWidgetHitTestVisible", value); }
        /// <summary>[Native] thunk RVA 0x7EAAF60 — hookable via Hooks.InstallAt(NativeFunc_SetFocus).</summary>
        public static System.IntPtr NativeFunc_SetFocus => Memory.ModuleBase() + 0x7EAAF60;
        public void SetFocus(Widget FocusWidget)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, FocusWidget);
            CallRaw("SetFocus", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAB004 — hookable via Hooks.InstallAt(NativeFunc_SetCustomHitResult).</summary>
        public static System.IntPtr NativeFunc_SetCustomHitResult => Memory.ModuleBase() + 0x7EAB004;
        public void SetCustomHitResult(HitResult HitResult)
        {
            var __pb = new ParamBuffer(136);
            __pb.Set<System.IntPtr>(0x0, HitResult);
            CallRaw("SetCustomHitResult", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAB2F0 — hookable via Hooks.InstallAt(NativeFunc_SendKeyChar).</summary>
        public static System.IntPtr NativeFunc_SendKeyChar => Memory.ModuleBase() + 0x7EAB2F0;
        public bool SendKeyChar(System.IntPtr Characters, bool bRepeat)
        {
            var __pb = new ParamBuffer(18);
            __pb.Set<System.IntPtr>(0x0, Characters);
            __pb.Set<byte>(0x10, (byte)(bRepeat?1:0));
            CallRaw("SendKeyChar", __pb.Bytes);
            return __pb.Get<byte>(0x11) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EAB244 — hookable via Hooks.InstallAt(NativeFunc_ScrollWheel).</summary>
        public static System.IntPtr NativeFunc_ScrollWheel => Memory.ModuleBase() + 0x7EAB244;
        public void ScrollWheel(float ScrollDelta)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ScrollDelta);
            CallRaw("ScrollWheel", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAB988 — hookable via Hooks.InstallAt(NativeFunc_ReleasePointerKey).</summary>
        public static System.IntPtr NativeFunc_ReleasePointerKey => Memory.ModuleBase() + 0x7EAB988;
        public void ReleasePointerKey(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("ReleasePointerKey", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAB5F4 — hookable via Hooks.InstallAt(NativeFunc_ReleaseKey).</summary>
        public static System.IntPtr NativeFunc_ReleaseKey => Memory.ModuleBase() + 0x7EAB5F4;
        public bool ReleaseKey(Key Key)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("ReleaseKey", __pb.Bytes);
            return __pb.Get<byte>(0x18) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EABB20 — hookable via Hooks.InstallAt(NativeFunc_PressPointerKey).</summary>
        public static System.IntPtr NativeFunc_PressPointerKey => Memory.ModuleBase() + 0x7EABB20;
        public void PressPointerKey(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("PressPointerKey", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAB798 — hookable via Hooks.InstallAt(NativeFunc_PressKey).</summary>
        public static System.IntPtr NativeFunc_PressKey => Memory.ModuleBase() + 0x7EAB798;
        public bool PressKey(Key Key, bool bRepeat)
        {
            var __pb = new ParamBuffer(26);
            __pb.Set<System.IntPtr>(0x0, Key);
            __pb.Set<byte>(0x18, (byte)(bRepeat?1:0));
            CallRaw("PressKey", __pb.Bytes);
            return __pb.Get<byte>(0x19) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EAB450 — hookable via Hooks.InstallAt(NativeFunc_PressAndReleaseKey).</summary>
        public static System.IntPtr NativeFunc_PressAndReleaseKey => Memory.ModuleBase() + 0x7EAB450;
        public bool PressAndReleaseKey(Key Key)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("PressAndReleaseKey", __pb.Bytes);
            return __pb.Get<byte>(0x18) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EAB1D8 — hookable via Hooks.InstallAt(NativeFunc_IsOverInteractableWidget).</summary>
        public static System.IntPtr NativeFunc_IsOverInteractableWidget => Memory.ModuleBase() + 0x7EAB1D8;
        public bool IsOverInteractableWidget()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsOverInteractableWidget", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EAB168 — hookable via Hooks.InstallAt(NativeFunc_IsOverHitTestVisibleWidget).</summary>
        public static System.IntPtr NativeFunc_IsOverHitTestVisibleWidget => Memory.ModuleBase() + 0x7EAB168;
        public bool IsOverHitTestVisibleWidget()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsOverHitTestVisibleWidget", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EAB1A0 — hookable via Hooks.InstallAt(NativeFunc_IsOverFocusableWidget).</summary>
        public static System.IntPtr NativeFunc_IsOverFocusableWidget => Memory.ModuleBase() + 0x7EAB1A0;
        public bool IsOverFocusableWidget()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsOverFocusableWidget", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EAB108 — hookable via Hooks.InstallAt(NativeFunc_GetLastHitResult).</summary>
        public static System.IntPtr NativeFunc_GetLastHitResult => Memory.ModuleBase() + 0x7EAB108;
        public HitResult GetLastHitResult()
        {
            var __pb = new ParamBuffer(136);
            CallRaw("GetLastHitResult", __pb.Bytes);
            return __pb.Get<HitResult>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EAB210 — hookable via Hooks.InstallAt(NativeFunc_GetHoveredWidgetComponent).</summary>
        public static System.IntPtr NativeFunc_GetHoveredWidgetComponent => Memory.ModuleBase() + 0x7EAB210;
        public WidgetComponent GetHoveredWidgetComponent()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetHoveredWidgetComponent", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EAB0D4 — hookable via Hooks.InstallAt(NativeFunc_Get2DHitLocation).</summary>
        public static System.IntPtr NativeFunc_Get2DHitLocation => Memory.ModuleBase() + 0x7EAB0D4;
        public Vector2D Get2DHitLocation()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("Get2DHitLocation", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
    }

    public class WidgetLayoutLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "WidgetLayoutLibrary";
        public WidgetLayoutLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetLayoutLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetLayoutLibrary(p);
        public static WidgetLayoutLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetLayoutLibrary(o.Pointer); }
        public static WidgetLayoutLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetLayoutLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetLayoutLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7EACB8C — hookable via Hooks.InstallAt(NativeFunc_SlotAsWrapBoxSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsWrapBoxSlot => Memory.ModuleBase() + 0x7EACB8C;
        public WrapBoxSlot SlotAsWrapBoxSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsWrapBoxSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new WrapBoxSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EACAE8 — hookable via Hooks.InstallAt(NativeFunc_SlotAsWidgetSwitcherSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsWidgetSwitcherSlot => Memory.ModuleBase() + 0x7EACAE8;
        public WidgetSwitcherSlot SlotAsWidgetSwitcherSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsWidgetSwitcherSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new WidgetSwitcherSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EACEC0 — hookable via Hooks.InstallAt(NativeFunc_SlotAsVerticalBoxSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsVerticalBoxSlot => Memory.ModuleBase() + 0x7EACEC0;
        public VerticalBoxSlot SlotAsVerticalBoxSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsVerticalBoxSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new VerticalBoxSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EACF64 — hookable via Hooks.InstallAt(NativeFunc_SlotAsUniformGridSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsUniformGridSlot => Memory.ModuleBase() + 0x7EACF64;
        public UniformGridSlot SlotAsUniformGridSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsUniformGridSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new UniformGridSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EACC30 — hookable via Hooks.InstallAt(NativeFunc_SlotAsSizeBoxSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsSizeBoxSlot => Memory.ModuleBase() + 0x7EACC30;
        public SizeBoxSlot SlotAsSizeBoxSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsSizeBoxSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new SizeBoxSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EACE1C — hookable via Hooks.InstallAt(NativeFunc_SlotAsScrollBoxSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsScrollBoxSlot => Memory.ModuleBase() + 0x7EACE1C;
        public ScrollBoxSlot SlotAsScrollBoxSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsScrollBoxSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new ScrollBoxSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EACCD4 — hookable via Hooks.InstallAt(NativeFunc_SlotAsScaleBoxSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsScaleBoxSlot => Memory.ModuleBase() + 0x7EACCD4;
        public ScaleBoxSlot SlotAsScaleBoxSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsScaleBoxSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new ScaleBoxSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EACD78 — hookable via Hooks.InstallAt(NativeFunc_SlotAsSafeBoxSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsSafeBoxSlot => Memory.ModuleBase() + 0x7EACD78;
        public SafeZoneSlot SlotAsSafeBoxSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsSafeBoxSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new SafeZoneSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EAD008 — hookable via Hooks.InstallAt(NativeFunc_SlotAsOverlaySlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsOverlaySlot => Memory.ModuleBase() + 0x7EAD008;
        public OverlaySlot SlotAsOverlaySlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsOverlaySlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new OverlaySlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EAD0AC — hookable via Hooks.InstallAt(NativeFunc_SlotAsHorizontalBoxSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsHorizontalBoxSlot => Memory.ModuleBase() + 0x7EAD0AC;
        public HorizontalBoxSlot SlotAsHorizontalBoxSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsHorizontalBoxSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new HorizontalBoxSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EAD150 — hookable via Hooks.InstallAt(NativeFunc_SlotAsGridSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsGridSlot => Memory.ModuleBase() + 0x7EAD150;
        public GridSlot SlotAsGridSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsGridSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new GridSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EAD1F4 — hookable via Hooks.InstallAt(NativeFunc_SlotAsCanvasSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsCanvasSlot => Memory.ModuleBase() + 0x7EAD1F4;
        public CanvasPanelSlot SlotAsCanvasSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsCanvasSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new CanvasPanelSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EAD298 — hookable via Hooks.InstallAt(NativeFunc_SlotAsBorderSlot).</summary>
        public static System.IntPtr NativeFunc_SlotAsBorderSlot => Memory.ModuleBase() + 0x7EAD298;
        public BorderSlot SlotAsBorderSlot(Widget Widget)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Widget);
            CallRaw("SlotAsBorderSlot", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new BorderSlot(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EACA54 — hookable via Hooks.InstallAt(NativeFunc_RemoveAllWidgets).</summary>
        public static System.IntPtr NativeFunc_RemoveAllWidgets => Memory.ModuleBase() + 0x7EACA54;
        public void RemoveAllWidgets(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("RemoveAllWidgets", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAD80C — hookable via Hooks.InstallAt(NativeFunc_ProjectWorldLocationToWidgetPosition).</summary>
        public static System.IntPtr NativeFunc_ProjectWorldLocationToWidgetPosition => Memory.ModuleBase() + 0x7EAD80C;
        public bool ProjectWorldLocationToWidgetPosition(PlayerController PlayerController, Vector WorldLocation, Vector2D ScreenPosition, bool bPlayerViewportRelative)
        {
            var __pb = new ParamBuffer(30);
            __pb.SetObject(0x0, PlayerController);
            __pb.Set<System.IntPtr>(0x8, WorldLocation);
            __pb.Set<System.IntPtr>(0x14, ScreenPosition);
            __pb.Set<byte>(0x1C, (byte)(bPlayerViewportRelative?1:0));
            CallRaw("ProjectWorldLocationToWidgetPosition", __pb.Bytes);
            return __pb.Get<byte>(0x1D) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EAD614 — hookable via Hooks.InstallAt(NativeFunc_GetViewportWidgetGeometry).</summary>
        public static System.IntPtr NativeFunc_GetViewportWidgetGeometry => Memory.ModuleBase() + 0x7EAD614;
        public Geometry GetViewportWidgetGeometry(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("GetViewportWidgetGeometry", __pb.Bytes);
            return __pb.Get<Geometry>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7EAD6C4 — hookable via Hooks.InstallAt(NativeFunc_GetViewportSize).</summary>
        public static System.IntPtr NativeFunc_GetViewportSize => Memory.ModuleBase() + 0x7EAD6C4;
        public Vector2D GetViewportSize(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("GetViewportSize", __pb.Bytes);
            return __pb.Get<Vector2D>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7EAD768 — hookable via Hooks.InstallAt(NativeFunc_GetViewportScale).</summary>
        public static System.IntPtr NativeFunc_GetViewportScale => Memory.ModuleBase() + 0x7EAD768;
        public float GetViewportScale(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("GetViewportScale", __pb.Bytes);
            return __pb.Get<float>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7EAD564 — hookable via Hooks.InstallAt(NativeFunc_GetPlayerScreenWidgetGeometry).</summary>
        public static System.IntPtr NativeFunc_GetPlayerScreenWidgetGeometry => Memory.ModuleBase() + 0x7EAD564;
        public Geometry GetPlayerScreenWidgetGeometry(PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, PlayerController);
            CallRaw("GetPlayerScreenWidgetGeometry", __pb.Bytes);
            return __pb.Get<Geometry>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7EAD33C — hookable via Hooks.InstallAt(NativeFunc_GetMousePositionScaledByDPI).</summary>
        public static System.IntPtr NativeFunc_GetMousePositionScaledByDPI => Memory.ModuleBase() + 0x7EAD33C;
        public bool GetMousePositionScaledByDPI(PlayerController Player, float LocationX, float LocationY)
        {
            var __pb = new ParamBuffer(17);
            __pb.SetObject(0x0, Player);
            __pb.Set(0x8, LocationX);
            __pb.Set(0xC, LocationY);
            CallRaw("GetMousePositionScaledByDPI", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7EAD48C — hookable via Hooks.InstallAt(NativeFunc_GetMousePositionOnViewport).</summary>
        public static System.IntPtr NativeFunc_GetMousePositionOnViewport => Memory.ModuleBase() + 0x7EAD48C;
        public Vector2D GetMousePositionOnViewport(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("GetMousePositionOnViewport", __pb.Bytes);
            return __pb.Get<Vector2D>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7EAD530 — hookable via Hooks.InstallAt(NativeFunc_GetMousePositionOnPlatform).</summary>
        public static System.IntPtr NativeFunc_GetMousePositionOnPlatform => Memory.ModuleBase() + 0x7EAD530;
        public Vector2D GetMousePositionOnPlatform()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetMousePositionOnPlatform", __pb.Bytes);
            return __pb.Get<Vector2D>(0x0);
        }
    }

    public class WidgetNavigation : Object
    {
        public const string UeClassName = "WidgetNavigation";
        public WidgetNavigation(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetNavigation FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetNavigation(p);
        public static WidgetNavigation FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetNavigation(o.Pointer); }
        public static WidgetNavigation[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetNavigation[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetNavigation(a[i].Pointer); return r; }
        public WidgetNavigationData Up => new WidgetNavigationData(AddrOf(0x28));
        public WidgetNavigationData Down => new WidgetNavigationData(AddrOf(0x4C));
        public WidgetNavigationData Left => new WidgetNavigationData(AddrOf(0x70));
        public WidgetNavigationData Right => new WidgetNavigationData(AddrOf(0x94));
        public WidgetNavigationData Next => new WidgetNavigationData(AddrOf(0xB8));
        public WidgetNavigationData Previous => new WidgetNavigationData(AddrOf(0xDC));
    }

    public class WidgetSwitcher : PanelWidget
    {
        public const string UeClassName = "WidgetSwitcher";
        public WidgetSwitcher(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetSwitcher FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetSwitcher(p);
        public static WidgetSwitcher FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetSwitcher(o.Pointer); }
        public static WidgetSwitcher[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetSwitcher[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetSwitcher(a[i].Pointer); return r; }
        public int ActiveWidgetIndex { get => GetAt<int>(0x11C); set => SetAt(0x11C, value); }
        /// <summary>[Native] thunk RVA 0x7EAF418 — hookable via Hooks.InstallAt(NativeFunc_SetActiveWidgetIndex).</summary>
        public static System.IntPtr NativeFunc_SetActiveWidgetIndex => Memory.ModuleBase() + 0x7EAF418;
        public void SetActiveWidgetIndex(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("SetActiveWidgetIndex", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAF36C — hookable via Hooks.InstallAt(NativeFunc_SetActiveWidget).</summary>
        public static System.IntPtr NativeFunc_SetActiveWidget => Memory.ModuleBase() + 0x7EAF36C;
        public void SetActiveWidget(Widget Widget)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Widget);
            CallRaw("SetActiveWidget", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAF2C0 — hookable via Hooks.InstallAt(NativeFunc_GetWidgetAtIndex).</summary>
        public static System.IntPtr NativeFunc_GetWidgetAtIndex => Memory.ModuleBase() + 0x7EAF2C0;
        public Widget GetWidgetAtIndex(int Index)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, Index);
            CallRaw("GetWidgetAtIndex", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new Widget(__p); }
        }
        /// <summary>[Native] thunk RVA 0x7EAF4F8 — hookable via Hooks.InstallAt(NativeFunc_GetNumWidgets).</summary>
        public static System.IntPtr NativeFunc_GetNumWidgets => Memory.ModuleBase() + 0x7EAF4F8;
        public int GetNumWidgets()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumWidgets", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EAF4C4 — hookable via Hooks.InstallAt(NativeFunc_GetActiveWidgetIndex).</summary>
        public static System.IntPtr NativeFunc_GetActiveWidgetIndex => Memory.ModuleBase() + 0x7EAF4C4;
        public int GetActiveWidgetIndex()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetActiveWidgetIndex", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7EAF28C — hookable via Hooks.InstallAt(NativeFunc_GetActiveWidget).</summary>
        public static System.IntPtr NativeFunc_GetActiveWidget => Memory.ModuleBase() + 0x7EAF28C;
        public Widget GetActiveWidget()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetActiveWidget", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new Widget(__p); }
        }
    }

    public class WidgetSwitcherSlot : PanelSlot
    {
        public const string UeClassName = "WidgetSwitcherSlot";
        public WidgetSwitcherSlot(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetSwitcherSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetSwitcherSlot(p);
        public static WidgetSwitcherSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetSwitcherSlot(o.Pointer); }
        public static WidgetSwitcherSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetSwitcherSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetSwitcherSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x40));
        public byte HorizontalAlignment { get => GetAt<byte>(0x50); set => SetAt(0x50, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x51); set => SetAt(0x51, value); }
        /// <summary>[Native] thunk RVA 0x7EAFE80 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7EAFE80;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAFFC8 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7EAFFC8;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EAFF24 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7EAFF24;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class WidgetTree : Object
    {
        public const string UeClassName = "WidgetTree";
        public WidgetTree(System.IntPtr ptr) : base(ptr) {}
        public static new WidgetTree FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WidgetTree(p);
        public static WidgetTree FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WidgetTree(o.Pointer); }
        public static WidgetTree[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WidgetTree[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WidgetTree(a[i].Pointer); return r; }
        public Widget RootWidget { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new Widget(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class WindowTitleBarArea : ContentWidget
    {
        public const string UeClassName = "WindowTitleBarArea";
        public WindowTitleBarArea(System.IntPtr ptr) : base(ptr) {}
        public static new WindowTitleBarArea FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WindowTitleBarArea(p);
        public static WindowTitleBarArea FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WindowTitleBarArea(o.Pointer); }
        public static WindowTitleBarArea[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WindowTitleBarArea[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WindowTitleBarArea(a[i].Pointer); return r; }
        public bool bWindowButtonsEnabled { get => Native.GetPropBool(Pointer, "bWindowButtonsEnabled"); set => Native.SetPropBool(Pointer, "bWindowButtonsEnabled", value); }
        public bool bDoubleClickTogglesFullscreen { get => Native.GetPropBool(Pointer, "bDoubleClickTogglesFullscreen"); set => Native.SetPropBool(Pointer, "bDoubleClickTogglesFullscreen", value); }
        /// <summary>[Native] thunk RVA 0x7EB1480 — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7EB1480;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB15C8 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7EB15C8;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB1524 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7EB1524;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class WindowTitleBarAreaSlot : PanelSlot
    {
        public const string UeClassName = "WindowTitleBarAreaSlot";
        public WindowTitleBarAreaSlot(System.IntPtr ptr) : base(ptr) {}
        public static new WindowTitleBarAreaSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WindowTitleBarAreaSlot(p);
        public static WindowTitleBarAreaSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WindowTitleBarAreaSlot(o.Pointer); }
        public static WindowTitleBarAreaSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WindowTitleBarAreaSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WindowTitleBarAreaSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x38));
        public byte HorizontalAlignment { get => GetAt<byte>(0x48); set => SetAt(0x48, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x49); set => SetAt(0x49, value); }
        /// <summary>[Native] thunk RVA 0x7EB1EFC — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7EB1EFC;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB2044 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7EB2044;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB1FA0 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7EB1FA0;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
    }

    public class WrapBox : PanelWidget
    {
        public const string UeClassName = "WrapBox";
        public WrapBox(System.IntPtr ptr) : base(ptr) {}
        public static new WrapBox FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WrapBox(p);
        public static WrapBox FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WrapBox(o.Pointer); }
        public static WrapBox[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WrapBox[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WrapBox(a[i].Pointer); return r; }
        public Vector2D InnerSlotPadding => new Vector2D(AddrOf(0x11C));
        public float WrapWidth { get => GetAt<float>(0x124); set => SetAt(0x124, value); }
        public bool bExplicitWrapWidth { get => Native.GetPropBool(Pointer, "bExplicitWrapWidth"); set => Native.SetPropBool(Pointer, "bExplicitWrapWidth", value); }
        /// <summary>[Native] thunk RVA 0x7EB2A0C — hookable via Hooks.InstallAt(NativeFunc_SetInnerSlotPadding).</summary>
        public static System.IntPtr NativeFunc_SetInnerSlotPadding => Memory.ModuleBase() + 0x7EB2A0C;
        public void SetInnerSlotPadding(Vector2D InPadding)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetInnerSlotPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB2960 — hookable via Hooks.InstallAt(NativeFunc_AddChildToWrapBox).</summary>
        public static System.IntPtr NativeFunc_AddChildToWrapBox => Memory.ModuleBase() + 0x7EB2960;
        public WrapBoxSlot AddChildToWrapBox(Widget Content)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Content);
            CallRaw("AddChildToWrapBox", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new WrapBoxSlot(__p); }
        }
    }

    public class WrapBoxSlot : PanelSlot
    {
        public const string UeClassName = "WrapBoxSlot";
        public WrapBoxSlot(System.IntPtr ptr) : base(ptr) {}
        public static new WrapBoxSlot FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new WrapBoxSlot(p);
        public static WrapBoxSlot FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WrapBoxSlot(o.Pointer); }
        public static WrapBoxSlot[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WrapBoxSlot[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WrapBoxSlot(a[i].Pointer); return r; }
        public Margin Padding => new Margin(AddrOf(0x38));
        public bool bFillEmptySpace { get => Native.GetPropBool(Pointer, "bFillEmptySpace"); set => Native.SetPropBool(Pointer, "bFillEmptySpace", value); }
        public float FillSpanWhenLessThan { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public byte HorizontalAlignment { get => GetAt<byte>(0x50); set => SetAt(0x50, value); }
        public byte VerticalAlignment { get => GetAt<byte>(0x51); set => SetAt(0x51, value); }
        /// <summary>[Native] thunk RVA 0x7EB32DC — hookable via Hooks.InstallAt(NativeFunc_SetVerticalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetVerticalAlignment => Memory.ModuleBase() + 0x7EB32DC;
        public void SetVerticalAlignment(byte InVerticalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InVerticalAlignment);
            CallRaw("SetVerticalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB3574 — hookable via Hooks.InstallAt(NativeFunc_SetPadding).</summary>
        public static System.IntPtr NativeFunc_SetPadding => Memory.ModuleBase() + 0x7EB3574;
        public void SetPadding(Margin InPadding)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, InPadding);
            CallRaw("SetPadding", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB3380 — hookable via Hooks.InstallAt(NativeFunc_SetHorizontalAlignment).</summary>
        public static System.IntPtr NativeFunc_SetHorizontalAlignment => Memory.ModuleBase() + 0x7EB3380;
        public void SetHorizontalAlignment(byte InHorizontalAlignment)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, InHorizontalAlignment);
            CallRaw("SetHorizontalAlignment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB3424 — hookable via Hooks.InstallAt(NativeFunc_SetFillSpanWhenLessThan).</summary>
        public static System.IntPtr NativeFunc_SetFillSpanWhenLessThan => Memory.ModuleBase() + 0x7EB3424;
        public void SetFillSpanWhenLessThan(float InFillSpanWhenLessThan)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, InFillSpanWhenLessThan);
            CallRaw("SetFillSpanWhenLessThan", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7EB34C8 — hookable via Hooks.InstallAt(NativeFunc_SetFillEmptySpace).</summary>
        public static System.IntPtr NativeFunc_SetFillEmptySpace => Memory.ModuleBase() + 0x7EB34C8;
        public void SetFillEmptySpace(bool InbFillEmptySpace)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(InbFillEmptySpace?1:0));
            CallRaw("SetFillEmptySpace", __pb.Bytes);
        }
    }

}
