// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/InteractiveToolsFramework
using System;

namespace UEModLoader.Game
{
    public enum EInputCaptureState
    {
        Begin = 1,
        Continue = 2,
        End = 3,
        Ignore = 4,
    }

    public enum EInputCaptureRequestType
    {
        Begin = 1,
        Ignore = 2,
    }

    public enum EInputCaptureSide
    {
        None = 0,
        Left = 1,
        Right = 2,
        Both = 3,
        Any = 99,
    }

    public enum EInputDevices
    {
        None = 0,
        Keyboard = 1,
        Mouse = 2,
        Gamepad = 4,
        OculusTouch = 8,
        HTCViveWands = 16,
        AnySpatialDevice = 24,
        TabletFingers = 1024,
    }

    public enum ETransformGizmoSubElements
    {
        None = 0,
        TranslateAxisX = 2,
        TranslateAxisY = 4,
        TranslateAxisZ = 8,
        TranslateAllAxes = 14,
        TranslatePlaneXY = 16,
        TranslatePlaneXZ = 32,
        TranslatePlaneYZ = 64,
        TranslateAllPlanes = 112,
        RotateAxisX = 128,
        RotateAxisY = 256,
        RotateAxisZ = 512,
        RotateAllAxes = 896,
        ScaleAxisX = 1024,
        ScaleAxisY = 2048,
        ScaleAxisZ = 4096,
        ScaleAllAxes = 7168,
        ScalePlaneYZ = 8192,
        ScalePlaneXZ = 16384,
        ScalePlaneXY = 32768,
        ScaleAllPlanes = 57344,
        ScaleUniform = 65536,
        StandardTranslateRotate = 1022,
        TranslateRotateUniformScale = 66558,
        FullTranslateRotateScale = 131070,
    }

    public enum EToolChangeTrackingMode
    {
        NoChangeTracking = 1,
        UndoToExit = 2,
        FullUndoRedo = 3,
    }

    public enum EToolSide
    {
        Left = 1,
        Mouse = 1,
        Right = 2,
    }

    public enum ESelectedObjectsModificationType
    {
        Replace = 0,
        Add = 1,
        Remove = 2,
        Clear = 3,
    }

    public enum EToolMessageLevel
    {
        Internal = 0,
        UserMessage = 1,
        UserNotification = 2,
        UserWarning = 3,
        UserError = 4,
    }

    public enum EToolContextCoordinateSystem
    {
        World = 0,
        Local = 1,
    }

    public enum EStandardToolContextMaterials
    {
        VertexColorMaterial = 1,
    }

    public enum ESceneSnapQueryTargetType
    {
        None = 0,
        MeshVertex = 1,
        MeshEdge = 2,
        Grid = 4,
        All = 7,
    }

    public enum ESceneSnapQueryType
    {
        Position = 1,
    }

    public class BrushStampData : StructProxy
    {
        public BrushStampData(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class BehaviorInfo : StructProxy
    {
        public BehaviorInfo(global::System.IntPtr ptr) : base(ptr) {}
        public InputBehavior Behavior { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new InputBehavior(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class InputRayHit : StructProxy
    {
        public InputRayHit(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class ActiveGizmo : StructProxy
    {
        public ActiveGizmo(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class GizmoFloatParameterChange : StructProxy
    {
        public GizmoFloatParameterChange(global::System.IntPtr ptr) : base(ptr) {}
        public float InitialValue { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float CurrentValue { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class GizmoVec2ParameterChange : StructProxy
    {
        public GizmoVec2ParameterChange(global::System.IntPtr ptr) : base(ptr) {}
        public Vector2D InitialValue => new Vector2D(AddrOf(0x0));
        public Vector2D CurrentValue => new Vector2D(AddrOf(0x8));
    }

    public class InputBehavior : Object
    {
        public const string UeClassName = "InputBehavior";
        public InputBehavior(global::System.IntPtr ptr) : base(ptr) {}
        public static new InputBehavior FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InputBehavior(p);
        public static InputBehavior FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InputBehavior(o.Pointer); }
        public static InputBehavior[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InputBehavior[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InputBehavior(a[i].Pointer); return r; }
    }

    public class AnyButtonInputBehavior : InputBehavior
    {
        public const string UeClassName = "AnyButtonInputBehavior";
        public AnyButtonInputBehavior(global::System.IntPtr ptr) : base(ptr) {}
        public static new AnyButtonInputBehavior FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AnyButtonInputBehavior(p);
        public static AnyButtonInputBehavior FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AnyButtonInputBehavior(o.Pointer); }
        public static AnyButtonInputBehavior[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AnyButtonInputBehavior[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AnyButtonInputBehavior(a[i].Pointer); return r; }
    }

    public class InteractiveGizmoBuilder : Object
    {
        public const string UeClassName = "InteractiveGizmoBuilder";
        public InteractiveGizmoBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveGizmoBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractiveGizmoBuilder(p);
        public static InteractiveGizmoBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveGizmoBuilder(o.Pointer); }
        public static InteractiveGizmoBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveGizmoBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveGizmoBuilder(a[i].Pointer); return r; }
    }

    public class AxisAngleGizmoBuilder : InteractiveGizmoBuilder
    {
        public const string UeClassName = "AxisAngleGizmoBuilder";
        public AxisAngleGizmoBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new AxisAngleGizmoBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AxisAngleGizmoBuilder(p);
        public static AxisAngleGizmoBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AxisAngleGizmoBuilder(o.Pointer); }
        public static AxisAngleGizmoBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AxisAngleGizmoBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AxisAngleGizmoBuilder(a[i].Pointer); return r; }
    }

    public class InteractiveGizmo : Object
    {
        public const string UeClassName = "InteractiveGizmo";
        public InteractiveGizmo(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveGizmo FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractiveGizmo(p);
        public static InteractiveGizmo FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveGizmo(o.Pointer); }
        public static InteractiveGizmo[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveGizmo[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveGizmo(a[i].Pointer); return r; }
        public InputBehaviorSet InputBehaviors { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new InputBehaviorSet(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class AxisAngleGizmo : InteractiveGizmo
    {
        public const string UeClassName = "AxisAngleGizmo";
        public AxisAngleGizmo(global::System.IntPtr ptr) : base(ptr) {}
        public static new AxisAngleGizmo FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AxisAngleGizmo(p);
        public static AxisAngleGizmo FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AxisAngleGizmo(o.Pointer); }
        public static AxisAngleGizmo[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AxisAngleGizmo[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AxisAngleGizmo(a[i].Pointer); return r; }
        public UObject AxisSource { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject AngleSource { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject HitTarget { get { var __p = GetAt<global::System.IntPtr>(0x68); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x68, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject StateTarget { get { var __p = GetAt<global::System.IntPtr>(0x78); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x78, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bInInteraction { get => Native.GetPropBool(Pointer, "bInInteraction"); set => Native.SetPropBool(Pointer, "bInInteraction", value); }
        public Vector RotationOrigin => new Vector(AddrOf(0x8C));
        public Vector RotationAxis => new Vector(AddrOf(0x98));
        public Vector RotationPlaneX => new Vector(AddrOf(0xA4));
        public Vector RotationPlaneY => new Vector(AddrOf(0xB0));
        public Vector InteractionStartPoint => new Vector(AddrOf(0xBC));
        public Vector InteractionCurPoint => new Vector(AddrOf(0xC8));
        public float InteractionStartAngle { get => GetAt<float>(0xD4); set => SetAt(0xD4, value); }
        public float InteractionCurAngle { get => GetAt<float>(0xD8); set => SetAt(0xD8, value); }
    }

    public class AxisPositionGizmoBuilder : InteractiveGizmoBuilder
    {
        public const string UeClassName = "AxisPositionGizmoBuilder";
        public AxisPositionGizmoBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new AxisPositionGizmoBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AxisPositionGizmoBuilder(p);
        public static AxisPositionGizmoBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AxisPositionGizmoBuilder(o.Pointer); }
        public static AxisPositionGizmoBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AxisPositionGizmoBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AxisPositionGizmoBuilder(a[i].Pointer); return r; }
    }

    public class AxisPositionGizmo : InteractiveGizmo
    {
        public const string UeClassName = "AxisPositionGizmo";
        public AxisPositionGizmo(global::System.IntPtr ptr) : base(ptr) {}
        public static new AxisPositionGizmo FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AxisPositionGizmo(p);
        public static AxisPositionGizmo FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AxisPositionGizmo(o.Pointer); }
        public static AxisPositionGizmo[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AxisPositionGizmo[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AxisPositionGizmo(a[i].Pointer); return r; }
        public UObject AxisSource { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject ParameterSource { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject HitTarget { get { var __p = GetAt<global::System.IntPtr>(0x68); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x68, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject StateTarget { get { var __p = GetAt<global::System.IntPtr>(0x78); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x78, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bEnableSignedAxis { get => Native.GetPropBool(Pointer, "bEnableSignedAxis"); set => Native.SetPropBool(Pointer, "bEnableSignedAxis", value); }
        public bool bInInteraction { get => Native.GetPropBool(Pointer, "bInInteraction"); set => Native.SetPropBool(Pointer, "bInInteraction", value); }
        public Vector InteractionOrigin => new Vector(AddrOf(0x8C));
        public Vector InteractionAxis => new Vector(AddrOf(0x98));
        public Vector InteractionStartPoint => new Vector(AddrOf(0xA4));
        public Vector InteractionCurPoint => new Vector(AddrOf(0xB0));
        public float InteractionStartParameter { get => GetAt<float>(0xBC); set => SetAt(0xBC, value); }
        public float InteractionCurParameter { get => GetAt<float>(0xC0); set => SetAt(0xC0, value); }
        public float ParameterSign { get => GetAt<float>(0xC4); set => SetAt(0xC4, value); }
    }

    public class GizmoConstantAxisSource : Object
    {
        public const string UeClassName = "GizmoConstantAxisSource";
        public GizmoConstantAxisSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoConstantAxisSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoConstantAxisSource(p);
        public static GizmoConstantAxisSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoConstantAxisSource(o.Pointer); }
        public static GizmoConstantAxisSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoConstantAxisSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoConstantAxisSource(a[i].Pointer); return r; }
        public Vector Origin => new Vector(AddrOf(0x30));
        public Vector Direction => new Vector(AddrOf(0x3C));
    }

    public class GizmoConstantFrameAxisSource : Object
    {
        public const string UeClassName = "GizmoConstantFrameAxisSource";
        public GizmoConstantFrameAxisSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoConstantFrameAxisSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoConstantFrameAxisSource(p);
        public static GizmoConstantFrameAxisSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoConstantFrameAxisSource(o.Pointer); }
        public static GizmoConstantFrameAxisSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoConstantFrameAxisSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoConstantFrameAxisSource(a[i].Pointer); return r; }
        public Vector Origin => new Vector(AddrOf(0x30));
        public Vector Direction => new Vector(AddrOf(0x3C));
        public Vector TangentX => new Vector(AddrOf(0x48));
        public Vector TangentY => new Vector(AddrOf(0x54));
    }

    public class GizmoWorldAxisSource : Object
    {
        public const string UeClassName = "GizmoWorldAxisSource";
        public GizmoWorldAxisSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoWorldAxisSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoWorldAxisSource(p);
        public static GizmoWorldAxisSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoWorldAxisSource(o.Pointer); }
        public static GizmoWorldAxisSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoWorldAxisSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoWorldAxisSource(a[i].Pointer); return r; }
        public Vector Origin => new Vector(AddrOf(0x30));
        public int AxisIndex { get => GetAt<int>(0x3C); set => SetAt(0x3C, value); }
    }

    public class GizmoComponentAxisSource : Object
    {
        public const string UeClassName = "GizmoComponentAxisSource";
        public GizmoComponentAxisSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoComponentAxisSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoComponentAxisSource(p);
        public static GizmoComponentAxisSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoComponentAxisSource(o.Pointer); }
        public static GizmoComponentAxisSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoComponentAxisSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoComponentAxisSource(a[i].Pointer); return r; }
        public SceneComponent component { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int AxisIndex { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
        public bool bLocalAxes { get => Native.GetPropBool(Pointer, "bLocalAxes"); set => Native.SetPropBool(Pointer, "bLocalAxes", value); }
    }

    public class InteractiveToolPropertySet : Object
    {
        public const string UeClassName = "InteractiveToolPropertySet";
        public InteractiveToolPropertySet(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveToolPropertySet FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractiveToolPropertySet(p);
        public static InteractiveToolPropertySet FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveToolPropertySet(o.Pointer); }
        public static InteractiveToolPropertySet[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveToolPropertySet[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveToolPropertySet(a[i].Pointer); return r; }
        public Object CachedProperties { get { var __p = GetAt<global::System.IntPtr>(0x40); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x40, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bIsPropertySetEnabled { get => Native.GetPropBool(Pointer, "bIsPropertySetEnabled"); set => Native.SetPropBool(Pointer, "bIsPropertySetEnabled", value); }
    }

    public class BrushBaseProperties : InteractiveToolPropertySet
    {
        public const string UeClassName = "BrushBaseProperties";
        public BrushBaseProperties(global::System.IntPtr ptr) : base(ptr) {}
        public static new BrushBaseProperties FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BrushBaseProperties(p);
        public static BrushBaseProperties FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BrushBaseProperties(o.Pointer); }
        public static BrushBaseProperties[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BrushBaseProperties[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BrushBaseProperties(a[i].Pointer); return r; }
        public float BrushSize { get => GetAt<float>(0x4C); set => SetAt(0x4C, value); }
        public bool bSpecifyRadius { get => Native.GetPropBool(Pointer, "bSpecifyRadius"); set => Native.SetPropBool(Pointer, "bSpecifyRadius", value); }
        public float BrushRadius { get => GetAt<float>(0x54); set => SetAt(0x54, value); }
        public float BrushStrength { get => GetAt<float>(0x58); set => SetAt(0x58, value); }
        public float BrushFalloffAmount { get => GetAt<float>(0x5C); set => SetAt(0x5C, value); }
        public bool bShowStrength { get => Native.GetPropBool(Pointer, "bShowStrength"); set => Native.SetPropBool(Pointer, "bShowStrength", value); }
        public bool bShowFalloff { get => Native.GetPropBool(Pointer, "bShowFalloff"); set => Native.SetPropBool(Pointer, "bShowFalloff", value); }
    }

    public class InteractiveTool : Object
    {
        public const string UeClassName = "InteractiveTool";
        public InteractiveTool(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveTool FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractiveTool(p);
        public static InteractiveTool FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveTool(o.Pointer); }
        public static InteractiveTool[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveTool[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveTool(a[i].Pointer); return r; }
        public InputBehaviorSet InputBehaviors { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new InputBehaviorSet(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> ToolPropertyObjects => new TArray<global::System.IntPtr>(AddrOf(0x50)); // TArray<UObject*>
    }

    public class SingleSelectionTool : InteractiveTool
    {
        public const string UeClassName = "SingleSelectionTool";
        public SingleSelectionTool(global::System.IntPtr ptr) : base(ptr) {}
        public static new SingleSelectionTool FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SingleSelectionTool(p);
        public static SingleSelectionTool FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SingleSelectionTool(o.Pointer); }
        public static SingleSelectionTool[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SingleSelectionTool[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SingleSelectionTool(a[i].Pointer); return r; }
    }

    public class MeshSurfacePointTool : SingleSelectionTool
    {
        public const string UeClassName = "MeshSurfacePointTool";
        public MeshSurfacePointTool(global::System.IntPtr ptr) : base(ptr) {}
        public static new MeshSurfacePointTool FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MeshSurfacePointTool(p);
        public static MeshSurfacePointTool FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MeshSurfacePointTool(o.Pointer); }
        public static MeshSurfacePointTool[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MeshSurfacePointTool[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MeshSurfacePointTool(a[i].Pointer); return r; }
    }

    public class BaseBrushTool : MeshSurfacePointTool
    {
        public const string UeClassName = "BaseBrushTool";
        public BaseBrushTool(global::System.IntPtr ptr) : base(ptr) {}
        public static new BaseBrushTool FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BaseBrushTool(p);
        public static BaseBrushTool FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BaseBrushTool(o.Pointer); }
        public static BaseBrushTool[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BaseBrushTool[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BaseBrushTool(a[i].Pointer); return r; }
        public BrushBaseProperties BrushProperties { get { var __p = GetAt<global::System.IntPtr>(0xC0); return __p==global::System.IntPtr.Zero?null:new BrushBaseProperties(__p); } set => SetAt(0xC0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bInBrushStroke { get => Native.GetPropBool(Pointer, "bInBrushStroke"); set => Native.SetPropBool(Pointer, "bInBrushStroke", value); }
        public BrushStampData LastBrushStamp => new BrushStampData(AddrOf(0xCC));
        public UObject PropertyClass { get { var __p = GetAt<global::System.IntPtr>(0x188); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x188, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BrushStampIndicator BrushStampIndicator { get { var __p = GetAt<global::System.IntPtr>(0x1B0); return __p==global::System.IntPtr.Zero?null:new BrushStampIndicator(__p); } set => SetAt(0x1B0, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class BrushStampIndicatorBuilder : InteractiveGizmoBuilder
    {
        public const string UeClassName = "BrushStampIndicatorBuilder";
        public BrushStampIndicatorBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new BrushStampIndicatorBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BrushStampIndicatorBuilder(p);
        public static BrushStampIndicatorBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BrushStampIndicatorBuilder(o.Pointer); }
        public static BrushStampIndicatorBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BrushStampIndicatorBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BrushStampIndicatorBuilder(a[i].Pointer); return r; }
    }

    public class BrushStampIndicator : InteractiveGizmo
    {
        public const string UeClassName = "BrushStampIndicator";
        public BrushStampIndicator(global::System.IntPtr ptr) : base(ptr) {}
        public static new BrushStampIndicator FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BrushStampIndicator(p);
        public static BrushStampIndicator FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BrushStampIndicator(o.Pointer); }
        public static BrushStampIndicator[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BrushStampIndicator[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BrushStampIndicator(a[i].Pointer); return r; }
        public float BrushRadius { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public float BrushFalloff { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
        public Vector BrushPosition => new Vector(AddrOf(0x40));
        public Vector BrushNormal => new Vector(AddrOf(0x4C));
        public bool bDrawIndicatorLines { get => Native.GetPropBool(Pointer, "bDrawIndicatorLines"); set => Native.SetPropBool(Pointer, "bDrawIndicatorLines", value); }
        public bool bDrawRadiusCircle { get => Native.GetPropBool(Pointer, "bDrawRadiusCircle"); set => Native.SetPropBool(Pointer, "bDrawRadiusCircle", value); }
        public bool bDrawFalloffCircle { get => Native.GetPropBool(Pointer, "bDrawFalloffCircle"); set => Native.SetPropBool(Pointer, "bDrawFalloffCircle", value); }
        public int SampleStepCount { get => GetAt<int>(0x5C); set => SetAt(0x5C, value); }
        public LinearColor LineColor => new LinearColor(AddrOf(0x60));
        public float LineThickness { get => GetAt<float>(0x70); set => SetAt(0x70, value); }
        public bool bDepthTested { get => Native.GetPropBool(Pointer, "bDepthTested"); set => Native.SetPropBool(Pointer, "bDepthTested", value); }
        public bool bDrawSecondaryLines { get => Native.GetPropBool(Pointer, "bDrawSecondaryLines"); set => Native.SetPropBool(Pointer, "bDrawSecondaryLines", value); }
        public float SecondaryLineThickness { get => GetAt<float>(0x78); set => SetAt(0x78, value); }
        public LinearColor SecondaryLineColor => new LinearColor(AddrOf(0x7C));
        public PrimitiveComponent AttachedComponent { get { var __p = GetAt<global::System.IntPtr>(0x90); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x90, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class ClickDragInputBehavior : AnyButtonInputBehavior
    {
        public const string UeClassName = "ClickDragInputBehavior";
        public ClickDragInputBehavior(global::System.IntPtr ptr) : base(ptr) {}
        public static new ClickDragInputBehavior FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ClickDragInputBehavior(p);
        public static ClickDragInputBehavior FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClickDragInputBehavior(o.Pointer); }
        public static ClickDragInputBehavior[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClickDragInputBehavior[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClickDragInputBehavior(a[i].Pointer); return r; }
        public bool bUpdateModifiersDuringDrag { get => Native.GetPropBool(Pointer, "bUpdateModifiersDuringDrag"); set => Native.SetPropBool(Pointer, "bUpdateModifiersDuringDrag", value); }
    }

    public class LocalClickDragInputBehavior : ClickDragInputBehavior
    {
        public const string UeClassName = "LocalClickDragInputBehavior";
        public LocalClickDragInputBehavior(global::System.IntPtr ptr) : base(ptr) {}
        public static new LocalClickDragInputBehavior FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LocalClickDragInputBehavior(p);
        public static LocalClickDragInputBehavior FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LocalClickDragInputBehavior(o.Pointer); }
        public static LocalClickDragInputBehavior[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LocalClickDragInputBehavior[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LocalClickDragInputBehavior(a[i].Pointer); return r; }
    }

    public class InteractiveToolBuilder : Object
    {
        public const string UeClassName = "InteractiveToolBuilder";
        public InteractiveToolBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveToolBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractiveToolBuilder(p);
        public static InteractiveToolBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveToolBuilder(o.Pointer); }
        public static InteractiveToolBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveToolBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveToolBuilder(a[i].Pointer); return r; }
    }

    public class ClickDragToolBuilder : InteractiveToolBuilder
    {
        public const string UeClassName = "ClickDragToolBuilder";
        public ClickDragToolBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new ClickDragToolBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ClickDragToolBuilder(p);
        public static ClickDragToolBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClickDragToolBuilder(o.Pointer); }
        public static ClickDragToolBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClickDragToolBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClickDragToolBuilder(a[i].Pointer); return r; }
    }

    public class ClickDragTool : InteractiveTool
    {
        public const string UeClassName = "ClickDragTool";
        public ClickDragTool(global::System.IntPtr ptr) : base(ptr) {}
        public static new ClickDragTool FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ClickDragTool(p);
        public static ClickDragTool FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClickDragTool(o.Pointer); }
        public static ClickDragTool[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClickDragTool[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClickDragTool(a[i].Pointer); return r; }
    }

    public class InternalToolFrameworkActor : Actor
    {
        public const string UeClassName = "InternalToolFrameworkActor";
        public InternalToolFrameworkActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new InternalToolFrameworkActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InternalToolFrameworkActor(p);
        public static InternalToolFrameworkActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InternalToolFrameworkActor(o.Pointer); }
        public static InternalToolFrameworkActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InternalToolFrameworkActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InternalToolFrameworkActor(a[i].Pointer); return r; }
    }

    public class GizmoActor : InternalToolFrameworkActor
    {
        public const string UeClassName = "GizmoActor";
        public GizmoActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoActor(p);
        public static GizmoActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoActor(o.Pointer); }
        public static GizmoActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoActor(a[i].Pointer); return r; }
    }

    public class GizmoBaseComponent : PrimitiveComponent
    {
        public const string UeClassName = "GizmoBaseComponent";
        public GizmoBaseComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoBaseComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoBaseComponent(p);
        public static GizmoBaseComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoBaseComponent(o.Pointer); }
        public static GizmoBaseComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoBaseComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoBaseComponent(a[i].Pointer); return r; }
        public LinearColor Color => new LinearColor(AddrOf(0x408));
        public float HoverSizeMultiplier { get => GetAt<float>(0x418); set => SetAt(0x418, value); }
        public float PixelHitDistanceThreshold { get => GetAt<float>(0x41C); set => SetAt(0x41C, value); }
        /// <summary>[Native] thunk RVA 0x92BBF88 — hookable via Hooks.InstallAt(NativeFunc_UpdateWorldLocalState).</summary>
        public static global::System.IntPtr NativeFunc_UpdateWorldLocalState => Memory.ModuleBase() + 0x92BBF88;
        public void UpdateWorldLocalState(bool bWorldIn)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bWorldIn?1:0));
            CallRaw("UpdateWorldLocalState", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92BC044 — hookable via Hooks.InstallAt(NativeFunc_UpdateHoverState).</summary>
        public static global::System.IntPtr NativeFunc_UpdateHoverState => Memory.ModuleBase() + 0x92BC044;
        public void UpdateHoverState(bool bHoveringIn)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bHoveringIn?1:0));
            CallRaw("UpdateHoverState", __pb.Bytes);
        }
    }

    public class GizmoArrowComponent : GizmoBaseComponent
    {
        public const string UeClassName = "GizmoArrowComponent";
        public GizmoArrowComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoArrowComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoArrowComponent(p);
        public static GizmoArrowComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoArrowComponent(o.Pointer); }
        public static GizmoArrowComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoArrowComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoArrowComponent(a[i].Pointer); return r; }
        public Vector Direction => new Vector(AddrOf(0x428));
        public float Gap { get => GetAt<float>(0x434); set => SetAt(0x434, value); }
        public float Length { get => GetAt<float>(0x438); set => SetAt(0x438, value); }
        public float Thickness { get => GetAt<float>(0x43C); set => SetAt(0x43C, value); }
    }

    public class GizmoBoxComponent : GizmoBaseComponent
    {
        public const string UeClassName = "GizmoBoxComponent";
        public GizmoBoxComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoBoxComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoBoxComponent(p);
        public static GizmoBoxComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoBoxComponent(o.Pointer); }
        public static GizmoBoxComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoBoxComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoBoxComponent(a[i].Pointer); return r; }
        public Vector Origin => new Vector(AddrOf(0x428));
        public Quat Rotation => new Quat(AddrOf(0x440));
        public Vector Dimensions => new Vector(AddrOf(0x450));
        public float LineThickness { get => GetAt<float>(0x45C); set => SetAt(0x45C, value); }
        public bool bRemoveHiddenLines { get => Native.GetPropBool(Pointer, "bRemoveHiddenLines"); set => Native.SetPropBool(Pointer, "bRemoveHiddenLines", value); }
        public bool bEnableAxisFlip { get => Native.GetPropBool(Pointer, "bEnableAxisFlip"); set => Native.SetPropBool(Pointer, "bEnableAxisFlip", value); }
    }

    public class GizmoCircleComponent : GizmoBaseComponent
    {
        public const string UeClassName = "GizmoCircleComponent";
        public GizmoCircleComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoCircleComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoCircleComponent(p);
        public static GizmoCircleComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoCircleComponent(o.Pointer); }
        public static GizmoCircleComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoCircleComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoCircleComponent(a[i].Pointer); return r; }
        public Vector Normal => new Vector(AddrOf(0x428));
        public float Radius { get => GetAt<float>(0x434); set => SetAt(0x434, value); }
        public float Thickness { get => GetAt<float>(0x438); set => SetAt(0x438, value); }
        public int NumSides { get => GetAt<int>(0x43C); set => SetAt(0x43C, value); }
        public bool bViewAligned { get => Native.GetPropBool(Pointer, "bViewAligned"); set => Native.SetPropBool(Pointer, "bViewAligned", value); }
        public bool bOnlyAllowFrontFacingHits { get => Native.GetPropBool(Pointer, "bOnlyAllowFrontFacingHits"); set => Native.SetPropBool(Pointer, "bOnlyAllowFrontFacingHits", value); }
    }

    public class GizmoTransformSource : Interface
    {
        public const string UeClassName = "GizmoTransformSource";
        public GizmoTransformSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoTransformSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoTransformSource(p);
        public static GizmoTransformSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoTransformSource(o.Pointer); }
        public static GizmoTransformSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoTransformSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoTransformSource(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x92BDAA8 — hookable via Hooks.InstallAt(NativeFunc_SetTransform).</summary>
        public static global::System.IntPtr NativeFunc_SetTransform => Memory.ModuleBase() + 0x92BDAA8;
        public void SetTransform(global::System.IntPtr newTransform)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<global::System.IntPtr>(0x0, newTransform);
            CallRaw("SetTransform", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92BDB8C — hookable via Hooks.InstallAt(NativeFunc_GetTransform).</summary>
        public static global::System.IntPtr NativeFunc_GetTransform => Memory.ModuleBase() + 0x92BDB8C;
        public global::System.IntPtr GetTransform()
        {
            var __pb = new ParamBuffer(48);
            CallRaw("GetTransform", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
    }

    public class GizmoAxisSource : Interface
    {
        public const string UeClassName = "GizmoAxisSource";
        public GizmoAxisSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoAxisSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoAxisSource(p);
        public static GizmoAxisSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoAxisSource(o.Pointer); }
        public static GizmoAxisSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoAxisSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoAxisSource(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x92BE214 — hookable via Hooks.InstallAt(NativeFunc_HasTangentVectors).</summary>
        public static global::System.IntPtr NativeFunc_HasTangentVectors => Memory.ModuleBase() + 0x92BE214;
        public bool HasTangentVectors()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasTangentVectors", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x92BE110 — hookable via Hooks.InstallAt(NativeFunc_GetTangentVectors).</summary>
        public static global::System.IntPtr NativeFunc_GetTangentVectors => Memory.ModuleBase() + 0x92BE110;
        public void GetTangentVectors(global::System.IntPtr TangentXOut, global::System.IntPtr TangentYOut)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, TangentXOut);
            __pb.Set<global::System.IntPtr>(0xC, TangentYOut);
            CallRaw("GetTangentVectors", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92BE294 — hookable via Hooks.InstallAt(NativeFunc_GetOrigin).</summary>
        public static global::System.IntPtr NativeFunc_GetOrigin => Memory.ModuleBase() + 0x92BE294;
        public global::System.IntPtr GetOrigin()
        {
            var __pb = new ParamBuffer(12);
            CallRaw("GetOrigin", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x92BE254 — hookable via Hooks.InstallAt(NativeFunc_GetDirection).</summary>
        public static global::System.IntPtr NativeFunc_GetDirection => Memory.ModuleBase() + 0x92BE254;
        public global::System.IntPtr GetDirection()
        {
            var __pb = new ParamBuffer(12);
            CallRaw("GetDirection", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
    }

    public class GizmoClickTarget : Interface
    {
        public const string UeClassName = "GizmoClickTarget";
        public GizmoClickTarget(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoClickTarget FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoClickTarget(p);
        public static GizmoClickTarget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoClickTarget(o.Pointer); }
        public static GizmoClickTarget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoClickTarget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoClickTarget(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x92BE888 — hookable via Hooks.InstallAt(NativeFunc_UpdateHoverState).</summary>
        public static global::System.IntPtr NativeFunc_UpdateHoverState => Memory.ModuleBase() + 0x92BE888;
        public void UpdateHoverState(bool bHovering)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bHovering?1:0));
            CallRaw("UpdateHoverState", __pb.Bytes);
        }
    }

    public class GizmoStateTarget : Interface
    {
        public const string UeClassName = "GizmoStateTarget";
        public GizmoStateTarget(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoStateTarget FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoStateTarget(p);
        public static GizmoStateTarget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoStateTarget(o.Pointer); }
        public static GizmoStateTarget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoStateTarget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoStateTarget(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x92BEE0C — hookable via Hooks.InstallAt(NativeFunc_EndUpdate).</summary>
        public static global::System.IntPtr NativeFunc_EndUpdate => Memory.ModuleBase() + 0x92BEE0C;
        public void EndUpdate()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndUpdate", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92BEE28 — hookable via Hooks.InstallAt(NativeFunc_BeginUpdate).</summary>
        public static global::System.IntPtr NativeFunc_BeginUpdate => Memory.ModuleBase() + 0x92BEE28;
        public void BeginUpdate()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BeginUpdate", __pb.Bytes);
        }
    }

    public class GizmoFloatParameterSource : Interface
    {
        public const string UeClassName = "GizmoFloatParameterSource";
        public GizmoFloatParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoFloatParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoFloatParameterSource(p);
        public static GizmoFloatParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoFloatParameterSource(o.Pointer); }
        public static GizmoFloatParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoFloatParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoFloatParameterSource(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x92BF370 — hookable via Hooks.InstallAt(NativeFunc_SetParameter).</summary>
        public static global::System.IntPtr NativeFunc_SetParameter => Memory.ModuleBase() + 0x92BF370;
        public void SetParameter(float NewValue)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewValue);
            CallRaw("SetParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92BF438 — hookable via Hooks.InstallAt(NativeFunc_GetParameter).</summary>
        public static global::System.IntPtr NativeFunc_GetParameter => Memory.ModuleBase() + 0x92BF438;
        public float GetParameter()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetParameter", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x92BF354 — hookable via Hooks.InstallAt(NativeFunc_EndModify).</summary>
        public static global::System.IntPtr NativeFunc_EndModify => Memory.ModuleBase() + 0x92BF354;
        public void EndModify()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndModify", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92BF41C — hookable via Hooks.InstallAt(NativeFunc_BeginModify).</summary>
        public static global::System.IntPtr NativeFunc_BeginModify => Memory.ModuleBase() + 0x92BF41C;
        public void BeginModify()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BeginModify", __pb.Bytes);
        }
    }

    public class GizmoVec2ParameterSource : Interface
    {
        public const string UeClassName = "GizmoVec2ParameterSource";
        public GizmoVec2ParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoVec2ParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoVec2ParameterSource(p);
        public static GizmoVec2ParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoVec2ParameterSource(o.Pointer); }
        public static GizmoVec2ParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoVec2ParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoVec2ParameterSource(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x92BFA38 — hookable via Hooks.InstallAt(NativeFunc_SetParameter).</summary>
        public static global::System.IntPtr NativeFunc_SetParameter => Memory.ModuleBase() + 0x92BFA38;
        public void SetParameter(global::System.IntPtr NewValue)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, NewValue);
            CallRaw("SetParameter", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92BFB0C — hookable via Hooks.InstallAt(NativeFunc_GetParameter).</summary>
        public static global::System.IntPtr NativeFunc_GetParameter => Memory.ModuleBase() + 0x92BFB0C;
        public global::System.IntPtr GetParameter()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetParameter", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x92BFA1C — hookable via Hooks.InstallAt(NativeFunc_EndModify).</summary>
        public static global::System.IntPtr NativeFunc_EndModify => Memory.ModuleBase() + 0x92BFA1C;
        public void EndModify()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("EndModify", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x92BFAF0 — hookable via Hooks.InstallAt(NativeFunc_BeginModify).</summary>
        public static global::System.IntPtr NativeFunc_BeginModify => Memory.ModuleBase() + 0x92BFAF0;
        public void BeginModify()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BeginModify", __pb.Bytes);
        }
    }

    public class GizmoLineHandleComponent : GizmoBaseComponent
    {
        public const string UeClassName = "GizmoLineHandleComponent";
        public GizmoLineHandleComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoLineHandleComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoLineHandleComponent(p);
        public static GizmoLineHandleComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoLineHandleComponent(o.Pointer); }
        public static GizmoLineHandleComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoLineHandleComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoLineHandleComponent(a[i].Pointer); return r; }
        public Vector Normal => new Vector(AddrOf(0x428));
        public float HandleSize { get => GetAt<float>(0x434); set => SetAt(0x434, value); }
        public float Thickness { get => GetAt<float>(0x438); set => SetAt(0x438, value); }
        public Vector Direction => new Vector(AddrOf(0x43C));
        public float Length { get => GetAt<float>(0x448); set => SetAt(0x448, value); }
        public bool bImageScale { get => Native.GetPropBool(Pointer, "bImageScale"); set => Native.SetPropBool(Pointer, "bImageScale", value); }
    }

    public class GizmoRectangleComponent : GizmoBaseComponent
    {
        public const string UeClassName = "GizmoRectangleComponent";
        public GizmoRectangleComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoRectangleComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoRectangleComponent(p);
        public static GizmoRectangleComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoRectangleComponent(o.Pointer); }
        public static GizmoRectangleComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoRectangleComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoRectangleComponent(a[i].Pointer); return r; }
        public Vector DirectionX => new Vector(AddrOf(0x428));
        public Vector DirectionY => new Vector(AddrOf(0x434));
        public float OffsetX { get => GetAt<float>(0x440); set => SetAt(0x440, value); }
        public float OffsetY { get => GetAt<float>(0x444); set => SetAt(0x444, value); }
        public float LengthX { get => GetAt<float>(0x448); set => SetAt(0x448, value); }
        public float LengthY { get => GetAt<float>(0x44C); set => SetAt(0x44C, value); }
        public float Thickness { get => GetAt<float>(0x450); set => SetAt(0x450, value); }
        public byte SegmentFlags { get => GetAt<byte>(0x454); set => SetAt(0x454, value); }
    }

    public class GizmoLambdaHitTarget : Object
    {
        public const string UeClassName = "GizmoLambdaHitTarget";
        public GizmoLambdaHitTarget(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoLambdaHitTarget FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoLambdaHitTarget(p);
        public static GizmoLambdaHitTarget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoLambdaHitTarget(o.Pointer); }
        public static GizmoLambdaHitTarget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoLambdaHitTarget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoLambdaHitTarget(a[i].Pointer); return r; }
    }

    public class GizmoComponentHitTarget : Object
    {
        public const string UeClassName = "GizmoComponentHitTarget";
        public GizmoComponentHitTarget(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoComponentHitTarget FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoComponentHitTarget(p);
        public static GizmoComponentHitTarget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoComponentHitTarget(o.Pointer); }
        public static GizmoComponentHitTarget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoComponentHitTarget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoComponentHitTarget(a[i].Pointer); return r; }
        public PrimitiveComponent component { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class InputBehaviorSet : Object
    {
        public const string UeClassName = "InputBehaviorSet";
        public InputBehaviorSet(global::System.IntPtr ptr) : base(ptr) {}
        public static new InputBehaviorSet FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InputBehaviorSet(p);
        public static InputBehaviorSet FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InputBehaviorSet(o.Pointer); }
        public static InputBehaviorSet[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InputBehaviorSet[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InputBehaviorSet(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Behaviors => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
    }

    public class InputBehaviorSource : Interface
    {
        public const string UeClassName = "InputBehaviorSource";
        public InputBehaviorSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new InputBehaviorSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InputBehaviorSource(p);
        public static InputBehaviorSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InputBehaviorSource(o.Pointer); }
        public static InputBehaviorSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InputBehaviorSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InputBehaviorSource(a[i].Pointer); return r; }
    }

    public class InputRouter : Object
    {
        public const string UeClassName = "InputRouter";
        public InputRouter(global::System.IntPtr ptr) : base(ptr) {}
        public static new InputRouter FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InputRouter(p);
        public static InputRouter FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InputRouter(o.Pointer); }
        public static InputRouter[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InputRouter[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InputRouter(a[i].Pointer); return r; }
        public bool bAutoInvalidateOnHover { get => Native.GetPropBool(Pointer, "bAutoInvalidateOnHover"); set => Native.SetPropBool(Pointer, "bAutoInvalidateOnHover", value); }
        public bool bAutoInvalidateOnCapture { get => Native.GetPropBool(Pointer, "bAutoInvalidateOnCapture"); set => Native.SetPropBool(Pointer, "bAutoInvalidateOnCapture", value); }
        public InputBehaviorSet ActiveInputBehaviors { get { var __p = GetAt<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new InputBehaviorSet(__p); } set => SetAt(0x38, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class InteractionMechanic : Object
    {
        public const string UeClassName = "InteractionMechanic";
        public InteractionMechanic(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractionMechanic FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractionMechanic(p);
        public static InteractionMechanic FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractionMechanic(o.Pointer); }
        public static InteractionMechanic[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractionMechanic[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractionMechanic(a[i].Pointer); return r; }
    }

    public class InteractiveGizmoManager : Object
    {
        public const string UeClassName = "InteractiveGizmoManager";
        public InteractiveGizmoManager(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveGizmoManager FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractiveGizmoManager(p);
        public static InteractiveGizmoManager FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveGizmoManager(o.Pointer); }
        public static InteractiveGizmoManager[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveGizmoManager[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveGizmoManager(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> ActiveGizmos => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<struct>
        public global::System.IntPtr GizmoBuilders => AddrOf(0x58); // 
    }

    public class ToolContextTransactionProvider : Interface
    {
        public const string UeClassName = "ToolContextTransactionProvider";
        public ToolContextTransactionProvider(global::System.IntPtr ptr) : base(ptr) {}
        public static new ToolContextTransactionProvider FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ToolContextTransactionProvider(p);
        public static ToolContextTransactionProvider FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ToolContextTransactionProvider(o.Pointer); }
        public static ToolContextTransactionProvider[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ToolContextTransactionProvider[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ToolContextTransactionProvider(a[i].Pointer); return r; }
    }

    public class InteractiveToolManager : Object
    {
        public const string UeClassName = "InteractiveToolManager";
        public InteractiveToolManager(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveToolManager FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractiveToolManager(p);
        public static InteractiveToolManager FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveToolManager(o.Pointer); }
        public static InteractiveToolManager[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveToolManager[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveToolManager(a[i].Pointer); return r; }
        public InteractiveTool ActiveLeftTool { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new InteractiveTool(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public InteractiveTool ActiveRightTool { get { var __p = GetAt<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new InteractiveTool(__p); } set => SetAt(0x38, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr ToolBuilders => AddrOf(0x90); // 
    }

    public class ToolFrameworkComponent : Interface
    {
        public const string UeClassName = "ToolFrameworkComponent";
        public ToolFrameworkComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new ToolFrameworkComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ToolFrameworkComponent(p);
        public static ToolFrameworkComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ToolFrameworkComponent(o.Pointer); }
        public static ToolFrameworkComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ToolFrameworkComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ToolFrameworkComponent(a[i].Pointer); return r; }
    }

    public class InteractiveToolsContext : Object
    {
        public const string UeClassName = "InteractiveToolsContext";
        public InteractiveToolsContext(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractiveToolsContext FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractiveToolsContext(p);
        public static InteractiveToolsContext FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractiveToolsContext(o.Pointer); }
        public static InteractiveToolsContext[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractiveToolsContext[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractiveToolsContext(a[i].Pointer); return r; }
        public InputRouter InputRouter { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new InputRouter(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public InteractiveToolManager ToolManager { get { var __p = GetAt<global::System.IntPtr>(0x60); return __p==global::System.IntPtr.Zero?null:new InteractiveToolManager(__p); } set => SetAt(0x60, value?.Pointer ?? global::System.IntPtr.Zero); }
        public InteractiveGizmoManager GizmoManager { get { var __p = GetAt<global::System.IntPtr>(0x68); return __p==global::System.IntPtr.Zero?null:new InteractiveGizmoManager(__p); } set => SetAt(0x68, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject ToolManagerClass { get { var __p = GetAt<global::System.IntPtr>(0x70); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x70, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class IntervalGizmoActor : GizmoActor
    {
        public const string UeClassName = "IntervalGizmoActor";
        public IntervalGizmoActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new IntervalGizmoActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new IntervalGizmoActor(p);
        public static IntervalGizmoActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new IntervalGizmoActor(o.Pointer); }
        public static IntervalGizmoActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new IntervalGizmoActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new IntervalGizmoActor(a[i].Pointer); return r; }
        public GizmoLineHandleComponent UpIntervalComponent { get { var __p = GetAt<global::System.IntPtr>(0x220); return __p==global::System.IntPtr.Zero?null:new GizmoLineHandleComponent(__p); } set => SetAt(0x220, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoLineHandleComponent DownIntervalComponent { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new GizmoLineHandleComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoLineHandleComponent ForwardIntervalComponent { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new GizmoLineHandleComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class IntervalGizmoBuilder : InteractiveGizmoBuilder
    {
        public const string UeClassName = "IntervalGizmoBuilder";
        public IntervalGizmoBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new IntervalGizmoBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new IntervalGizmoBuilder(p);
        public static IntervalGizmoBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new IntervalGizmoBuilder(o.Pointer); }
        public static IntervalGizmoBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new IntervalGizmoBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new IntervalGizmoBuilder(a[i].Pointer); return r; }
    }

    public class IntervalGizmo : InteractiveGizmo
    {
        public const string UeClassName = "IntervalGizmo";
        public IntervalGizmo(global::System.IntPtr ptr) : base(ptr) {}
        public static new IntervalGizmo FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new IntervalGizmo(p);
        public static IntervalGizmo FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new IntervalGizmo(o.Pointer); }
        public static IntervalGizmo[] All() { var a = UObject.FindAllOf(UeClassName); var r = new IntervalGizmo[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new IntervalGizmo(a[i].Pointer); return r; }
        public GizmoTransformChangeStateTarget StateTarget { get { var __p = GetAt<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new GizmoTransformChangeStateTarget(__p); } set => SetAt(0x38, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TransformProxy TransformProxy { get { var __p = GetAt<global::System.IntPtr>(0x50); return __p==global::System.IntPtr.Zero?null:new TransformProxy(__p); } set => SetAt(0x50, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> ActiveComponents => new TArray<global::System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
        public TArray<global::System.IntPtr> ActiveGizmos => new TArray<global::System.IntPtr>(AddrOf(0x68)); // TArray<UObject*>
        public GizmoComponentAxisSource AxisYSource { get { var __p = GetAt<global::System.IntPtr>(0x90); return __p==global::System.IntPtr.Zero?null:new GizmoComponentAxisSource(__p); } set => SetAt(0x90, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoComponentAxisSource AxisZSource { get { var __p = GetAt<global::System.IntPtr>(0x98); return __p==global::System.IntPtr.Zero?null:new GizmoComponentAxisSource(__p); } set => SetAt(0x98, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class GizmoBaseFloatParameterSource : Object
    {
        public const string UeClassName = "GizmoBaseFloatParameterSource";
        public GizmoBaseFloatParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoBaseFloatParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoBaseFloatParameterSource(p);
        public static GizmoBaseFloatParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoBaseFloatParameterSource(o.Pointer); }
        public static GizmoBaseFloatParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoBaseFloatParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoBaseFloatParameterSource(a[i].Pointer); return r; }
    }

    public class GizmoAxisIntervalParameterSource : GizmoBaseFloatParameterSource
    {
        public const string UeClassName = "GizmoAxisIntervalParameterSource";
        public GizmoAxisIntervalParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoAxisIntervalParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoAxisIntervalParameterSource(p);
        public static GizmoAxisIntervalParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoAxisIntervalParameterSource(o.Pointer); }
        public static GizmoAxisIntervalParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoAxisIntervalParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoAxisIntervalParameterSource(a[i].Pointer); return r; }
        public UObject FloatParameterSource { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float MinParameter { get => GetAt<float>(0x58); set => SetAt(0x58, value); }
        public float MaxParameter { get => GetAt<float>(0x5C); set => SetAt(0x5C, value); }
    }

    public class KeyAsModifierInputBehavior : InputBehavior
    {
        public const string UeClassName = "KeyAsModifierInputBehavior";
        public KeyAsModifierInputBehavior(global::System.IntPtr ptr) : base(ptr) {}
        public static new KeyAsModifierInputBehavior FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new KeyAsModifierInputBehavior(p);
        public static KeyAsModifierInputBehavior FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new KeyAsModifierInputBehavior(o.Pointer); }
        public static KeyAsModifierInputBehavior[] All() { var a = UObject.FindAllOf(UeClassName); var r = new KeyAsModifierInputBehavior[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new KeyAsModifierInputBehavior(a[i].Pointer); return r; }
    }

    public class MeshSurfacePointToolBuilder : InteractiveToolBuilder
    {
        public const string UeClassName = "MeshSurfacePointToolBuilder";
        public MeshSurfacePointToolBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new MeshSurfacePointToolBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MeshSurfacePointToolBuilder(p);
        public static MeshSurfacePointToolBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MeshSurfacePointToolBuilder(o.Pointer); }
        public static MeshSurfacePointToolBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MeshSurfacePointToolBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MeshSurfacePointToolBuilder(a[i].Pointer); return r; }
    }

    public class MouseHoverBehavior : InputBehavior
    {
        public const string UeClassName = "MouseHoverBehavior";
        public MouseHoverBehavior(global::System.IntPtr ptr) : base(ptr) {}
        public static new MouseHoverBehavior FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MouseHoverBehavior(p);
        public static MouseHoverBehavior FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MouseHoverBehavior(o.Pointer); }
        public static MouseHoverBehavior[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MouseHoverBehavior[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MouseHoverBehavior(a[i].Pointer); return r; }
    }

    public class MultiClickSequenceInputBehavior : AnyButtonInputBehavior
    {
        public const string UeClassName = "MultiClickSequenceInputBehavior";
        public MultiClickSequenceInputBehavior(global::System.IntPtr ptr) : base(ptr) {}
        public static new MultiClickSequenceInputBehavior FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MultiClickSequenceInputBehavior(p);
        public static MultiClickSequenceInputBehavior FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MultiClickSequenceInputBehavior(o.Pointer); }
        public static MultiClickSequenceInputBehavior[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MultiClickSequenceInputBehavior[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MultiClickSequenceInputBehavior(a[i].Pointer); return r; }
    }

    public class MultiSelectionTool : InteractiveTool
    {
        public const string UeClassName = "MultiSelectionTool";
        public MultiSelectionTool(global::System.IntPtr ptr) : base(ptr) {}
        public static new MultiSelectionTool FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MultiSelectionTool(p);
        public static MultiSelectionTool FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MultiSelectionTool(o.Pointer); }
        public static MultiSelectionTool[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MultiSelectionTool[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MultiSelectionTool(a[i].Pointer); return r; }
    }

    public class GizmoLocalFloatParameterSource : GizmoBaseFloatParameterSource
    {
        public const string UeClassName = "GizmoLocalFloatParameterSource";
        public GizmoLocalFloatParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoLocalFloatParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoLocalFloatParameterSource(p);
        public static GizmoLocalFloatParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoLocalFloatParameterSource(o.Pointer); }
        public static GizmoLocalFloatParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoLocalFloatParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoLocalFloatParameterSource(a[i].Pointer); return r; }
        public float Value { get => GetAt<float>(0x48); set => SetAt(0x48, value); }
        public GizmoFloatParameterChange LastChange => new GizmoFloatParameterChange(AddrOf(0x4C));
    }

    public class GizmoBaseVec2ParameterSource : Object
    {
        public const string UeClassName = "GizmoBaseVec2ParameterSource";
        public GizmoBaseVec2ParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoBaseVec2ParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoBaseVec2ParameterSource(p);
        public static GizmoBaseVec2ParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoBaseVec2ParameterSource(o.Pointer); }
        public static GizmoBaseVec2ParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoBaseVec2ParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoBaseVec2ParameterSource(a[i].Pointer); return r; }
    }

    public class GizmoLocalVec2ParameterSource : GizmoBaseVec2ParameterSource
    {
        public const string UeClassName = "GizmoLocalVec2ParameterSource";
        public GizmoLocalVec2ParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoLocalVec2ParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoLocalVec2ParameterSource(p);
        public static GizmoLocalVec2ParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoLocalVec2ParameterSource(o.Pointer); }
        public static GizmoLocalVec2ParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoLocalVec2ParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoLocalVec2ParameterSource(a[i].Pointer); return r; }
        public Vector2D Value => new Vector2D(AddrOf(0x48));
        public GizmoVec2ParameterChange LastChange => new GizmoVec2ParameterChange(AddrOf(0x50));
    }

    public class GizmoAxisTranslationParameterSource : GizmoBaseFloatParameterSource
    {
        public const string UeClassName = "GizmoAxisTranslationParameterSource";
        public GizmoAxisTranslationParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoAxisTranslationParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoAxisTranslationParameterSource(p);
        public static GizmoAxisTranslationParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoAxisTranslationParameterSource(o.Pointer); }
        public static GizmoAxisTranslationParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoAxisTranslationParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoAxisTranslationParameterSource(a[i].Pointer); return r; }
        public UObject AxisSource { get { var __p = GetAt<global::System.IntPtr>(0x90); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x90, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject TransformSource { get { var __p = GetAt<global::System.IntPtr>(0xA0); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0xA0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Parameter { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public GizmoFloatParameterChange LastChange => new GizmoFloatParameterChange(AddrOf(0xB4));
        public Vector CurTranslationAxis => new Vector(AddrOf(0xBC));
        public Vector CurTranslationOrigin => new Vector(AddrOf(0xC8));
        public Transform InitialTransform => new Transform(AddrOf(0xE0));
    }

    public class GizmoPlaneTranslationParameterSource : GizmoBaseVec2ParameterSource
    {
        public const string UeClassName = "GizmoPlaneTranslationParameterSource";
        public GizmoPlaneTranslationParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoPlaneTranslationParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoPlaneTranslationParameterSource(p);
        public static GizmoPlaneTranslationParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoPlaneTranslationParameterSource(o.Pointer); }
        public static GizmoPlaneTranslationParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoPlaneTranslationParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoPlaneTranslationParameterSource(a[i].Pointer); return r; }
        public UObject AxisSource { get { var __p = GetAt<global::System.IntPtr>(0x90); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x90, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject TransformSource { get { var __p = GetAt<global::System.IntPtr>(0xA0); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0xA0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vector2D Parameter => new Vector2D(AddrOf(0xB0));
        public GizmoVec2ParameterChange LastChange => new GizmoVec2ParameterChange(AddrOf(0xB8));
        public Vector CurTranslationOrigin => new Vector(AddrOf(0xC8));
        public Vector CurTranslationNormal => new Vector(AddrOf(0xD4));
        public Vector CurTranslationAxisX => new Vector(AddrOf(0xE0));
        public Vector CurTranslationAxisY => new Vector(AddrOf(0xEC));
        public Transform InitialTransform => new Transform(AddrOf(0x100));
    }

    public class GizmoAxisRotationParameterSource : GizmoBaseFloatParameterSource
    {
        public const string UeClassName = "GizmoAxisRotationParameterSource";
        public GizmoAxisRotationParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoAxisRotationParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoAxisRotationParameterSource(p);
        public static GizmoAxisRotationParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoAxisRotationParameterSource(o.Pointer); }
        public static GizmoAxisRotationParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoAxisRotationParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoAxisRotationParameterSource(a[i].Pointer); return r; }
        public UObject AxisSource { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject TransformSource { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Angle { get => GetAt<float>(0x68); set => SetAt(0x68, value); }
        public GizmoFloatParameterChange LastChange => new GizmoFloatParameterChange(AddrOf(0x6C));
        public Vector CurRotationAxis => new Vector(AddrOf(0x74));
        public Vector CurRotationOrigin => new Vector(AddrOf(0x80));
        public Transform InitialTransform => new Transform(AddrOf(0x90));
    }

    public class GizmoUniformScaleParameterSource : GizmoBaseVec2ParameterSource
    {
        public const string UeClassName = "GizmoUniformScaleParameterSource";
        public GizmoUniformScaleParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoUniformScaleParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoUniformScaleParameterSource(p);
        public static GizmoUniformScaleParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoUniformScaleParameterSource(o.Pointer); }
        public static GizmoUniformScaleParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoUniformScaleParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoUniformScaleParameterSource(a[i].Pointer); return r; }
        public UObject AxisSource { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject TransformSource { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float ScaleMultiplier { get => GetAt<float>(0x68); set => SetAt(0x68, value); }
        public Vector2D Parameter => new Vector2D(AddrOf(0x6C));
        public GizmoVec2ParameterChange LastChange => new GizmoVec2ParameterChange(AddrOf(0x74));
        public Vector CurScaleOrigin => new Vector(AddrOf(0x84));
        public Vector CurScaleNormal => new Vector(AddrOf(0x90));
        public Vector CurScaleAxisX => new Vector(AddrOf(0x9C));
        public Vector CurScaleAxisY => new Vector(AddrOf(0xA8));
        public Transform InitialTransform => new Transform(AddrOf(0xC0));
    }

    public class GizmoAxisScaleParameterSource : GizmoBaseFloatParameterSource
    {
        public const string UeClassName = "GizmoAxisScaleParameterSource";
        public GizmoAxisScaleParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoAxisScaleParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoAxisScaleParameterSource(p);
        public static GizmoAxisScaleParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoAxisScaleParameterSource(o.Pointer); }
        public static GizmoAxisScaleParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoAxisScaleParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoAxisScaleParameterSource(a[i].Pointer); return r; }
        public UObject AxisSource { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject TransformSource { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float ScaleMultiplier { get => GetAt<float>(0x68); set => SetAt(0x68, value); }
        public float Parameter { get => GetAt<float>(0x6C); set => SetAt(0x6C, value); }
        public GizmoFloatParameterChange LastChange => new GizmoFloatParameterChange(AddrOf(0x70));
        public Vector CurScaleAxis => new Vector(AddrOf(0x78));
        public Vector CurScaleOrigin => new Vector(AddrOf(0x84));
        public Transform InitialTransform => new Transform(AddrOf(0x90));
    }

    public class GizmoPlaneScaleParameterSource : GizmoBaseVec2ParameterSource
    {
        public const string UeClassName = "GizmoPlaneScaleParameterSource";
        public GizmoPlaneScaleParameterSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoPlaneScaleParameterSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoPlaneScaleParameterSource(p);
        public static GizmoPlaneScaleParameterSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoPlaneScaleParameterSource(o.Pointer); }
        public static GizmoPlaneScaleParameterSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoPlaneScaleParameterSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoPlaneScaleParameterSource(a[i].Pointer); return r; }
        public UObject AxisSource { get { var __p = GetAt<global::System.IntPtr>(0x90); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x90, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject TransformSource { get { var __p = GetAt<global::System.IntPtr>(0xA0); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0xA0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float ScaleMultiplier { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public Vector2D Parameter => new Vector2D(AddrOf(0xB4));
        public GizmoVec2ParameterChange LastChange => new GizmoVec2ParameterChange(AddrOf(0xBC));
        public Vector CurScaleOrigin => new Vector(AddrOf(0xCC));
        public Vector CurScaleNormal => new Vector(AddrOf(0xD8));
        public Vector CurScaleAxisX => new Vector(AddrOf(0xE4));
        public Vector CurScaleAxisY => new Vector(AddrOf(0xF0));
        public Transform InitialTransform => new Transform(AddrOf(0x100));
    }

    public class PlanePositionGizmoBuilder : InteractiveGizmoBuilder
    {
        public const string UeClassName = "PlanePositionGizmoBuilder";
        public PlanePositionGizmoBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlanePositionGizmoBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlanePositionGizmoBuilder(p);
        public static PlanePositionGizmoBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlanePositionGizmoBuilder(o.Pointer); }
        public static PlanePositionGizmoBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlanePositionGizmoBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlanePositionGizmoBuilder(a[i].Pointer); return r; }
    }

    public class PlanePositionGizmo : InteractiveGizmo
    {
        public const string UeClassName = "PlanePositionGizmo";
        public PlanePositionGizmo(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlanePositionGizmo FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlanePositionGizmo(p);
        public static PlanePositionGizmo FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlanePositionGizmo(o.Pointer); }
        public static PlanePositionGizmo[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlanePositionGizmo[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlanePositionGizmo(a[i].Pointer); return r; }
        public UObject AxisSource { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject ParameterSource { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject HitTarget { get { var __p = GetAt<global::System.IntPtr>(0x68); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x68, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject StateTarget { get { var __p = GetAt<global::System.IntPtr>(0x78); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x78, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bEnableSignedAxis { get => Native.GetPropBool(Pointer, "bEnableSignedAxis"); set => Native.SetPropBool(Pointer, "bEnableSignedAxis", value); }
        public bool bFlipX { get => Native.GetPropBool(Pointer, "bFlipX"); set => Native.SetPropBool(Pointer, "bFlipX", value); }
        public bool bFlipY { get => Native.GetPropBool(Pointer, "bFlipY"); set => Native.SetPropBool(Pointer, "bFlipY", value); }
        public bool bInInteraction { get => Native.GetPropBool(Pointer, "bInInteraction"); set => Native.SetPropBool(Pointer, "bInInteraction", value); }
        public Vector InteractionOrigin => new Vector(AddrOf(0x8C));
        public Vector InteractionNormal => new Vector(AddrOf(0x98));
        public Vector InteractionAxisX => new Vector(AddrOf(0xA4));
        public Vector InteractionAxisY => new Vector(AddrOf(0xB0));
        public Vector InteractionStartPoint => new Vector(AddrOf(0xBC));
        public Vector InteractionCurPoint => new Vector(AddrOf(0xC8));
        public Vector2D InteractionStartParameter => new Vector2D(AddrOf(0xD4));
        public Vector2D InteractionCurParameter => new Vector2D(AddrOf(0xDC));
        public Vector2D ParameterSigns => new Vector2D(AddrOf(0xE4));
    }

    public class SelectionSet : Object
    {
        public const string UeClassName = "SelectionSet";
        public SelectionSet(global::System.IntPtr ptr) : base(ptr) {}
        public static new SelectionSet FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SelectionSet(p);
        public static SelectionSet FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SelectionSet(o.Pointer); }
        public static SelectionSet[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SelectionSet[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SelectionSet(a[i].Pointer); return r; }
    }

    public class MeshSelectionSet : SelectionSet
    {
        public const string UeClassName = "MeshSelectionSet";
        public MeshSelectionSet(global::System.IntPtr ptr) : base(ptr) {}
        public static new MeshSelectionSet FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MeshSelectionSet(p);
        public static MeshSelectionSet FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MeshSelectionSet(o.Pointer); }
        public static MeshSelectionSet[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MeshSelectionSet[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MeshSelectionSet(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Vertices => new TArray<global::System.IntPtr>(AddrOf(0x40)); // TArray<int32>
        public TArray<global::System.IntPtr> Edges => new TArray<global::System.IntPtr>(AddrOf(0x50)); // TArray<int32>
        public TArray<global::System.IntPtr> Faces => new TArray<global::System.IntPtr>(AddrOf(0x60)); // TArray<int32>
        public TArray<global::System.IntPtr> Groups => new TArray<global::System.IntPtr>(AddrOf(0x70)); // TArray<int32>
    }

    public class SingleClickInputBehavior : AnyButtonInputBehavior
    {
        public const string UeClassName = "SingleClickInputBehavior";
        public SingleClickInputBehavior(global::System.IntPtr ptr) : base(ptr) {}
        public static new SingleClickInputBehavior FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SingleClickInputBehavior(p);
        public static SingleClickInputBehavior FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SingleClickInputBehavior(o.Pointer); }
        public static SingleClickInputBehavior[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SingleClickInputBehavior[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SingleClickInputBehavior(a[i].Pointer); return r; }
        public bool HitTestOnRelease { get => Native.GetPropBool(Pointer, "HitTestOnRelease"); set => Native.SetPropBool(Pointer, "HitTestOnRelease", value); }
    }

    public class SingleClickToolBuilder : InteractiveToolBuilder
    {
        public const string UeClassName = "SingleClickToolBuilder";
        public SingleClickToolBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new SingleClickToolBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SingleClickToolBuilder(p);
        public static SingleClickToolBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SingleClickToolBuilder(o.Pointer); }
        public static SingleClickToolBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SingleClickToolBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SingleClickToolBuilder(a[i].Pointer); return r; }
    }

    public class SingleClickTool : InteractiveTool
    {
        public const string UeClassName = "SingleClickTool";
        public SingleClickTool(global::System.IntPtr ptr) : base(ptr) {}
        public static new SingleClickTool FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SingleClickTool(p);
        public static SingleClickTool FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SingleClickTool(o.Pointer); }
        public static SingleClickTool[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SingleClickTool[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SingleClickTool(a[i].Pointer); return r; }
    }

    public class GizmoNilStateTarget : Object
    {
        public const string UeClassName = "GizmoNilStateTarget";
        public GizmoNilStateTarget(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoNilStateTarget FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoNilStateTarget(p);
        public static GizmoNilStateTarget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoNilStateTarget(o.Pointer); }
        public static GizmoNilStateTarget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoNilStateTarget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoNilStateTarget(a[i].Pointer); return r; }
    }

    public class GizmoLambdaStateTarget : Object
    {
        public const string UeClassName = "GizmoLambdaStateTarget";
        public GizmoLambdaStateTarget(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoLambdaStateTarget FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoLambdaStateTarget(p);
        public static GizmoLambdaStateTarget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoLambdaStateTarget(o.Pointer); }
        public static GizmoLambdaStateTarget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoLambdaStateTarget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoLambdaStateTarget(a[i].Pointer); return r; }
    }

    public class GizmoObjectModifyStateTarget : Object
    {
        public const string UeClassName = "GizmoObjectModifyStateTarget";
        public GizmoObjectModifyStateTarget(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoObjectModifyStateTarget FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoObjectModifyStateTarget(p);
        public static GizmoObjectModifyStateTarget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoObjectModifyStateTarget(o.Pointer); }
        public static GizmoObjectModifyStateTarget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoObjectModifyStateTarget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoObjectModifyStateTarget(a[i].Pointer); return r; }
    }

    public class GizmoTransformChangeStateTarget : Object
    {
        public const string UeClassName = "GizmoTransformChangeStateTarget";
        public GizmoTransformChangeStateTarget(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoTransformChangeStateTarget FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoTransformChangeStateTarget(p);
        public static GizmoTransformChangeStateTarget FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoTransformChangeStateTarget(o.Pointer); }
        public static GizmoTransformChangeStateTarget[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoTransformChangeStateTarget[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoTransformChangeStateTarget(a[i].Pointer); return r; }
        public UObject TransactionManager { get { var __p = GetAt<global::System.IntPtr>(0x50); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x50, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class TransformGizmoActor : GizmoActor
    {
        public const string UeClassName = "TransformGizmoActor";
        public TransformGizmoActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new TransformGizmoActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TransformGizmoActor(p);
        public static TransformGizmoActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TransformGizmoActor(o.Pointer); }
        public static TransformGizmoActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TransformGizmoActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TransformGizmoActor(a[i].Pointer); return r; }
        public PrimitiveComponent TranslateX { get { var __p = GetAt<global::System.IntPtr>(0x220); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x220, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent TranslateY { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent TranslateZ { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent TranslateYZ { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent TranslateXZ { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent TranslateXY { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent RotateX { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent RotateY { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent RotateZ { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent UniformScale { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent AxisScaleX { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent AxisScaleY { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent AxisScaleZ { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent PlaneScaleYZ { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent PlaneScaleXZ { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public PrimitiveComponent PlaneScaleXY { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class TransformGizmoBuilder : InteractiveGizmoBuilder
    {
        public const string UeClassName = "TransformGizmoBuilder";
        public TransformGizmoBuilder(global::System.IntPtr ptr) : base(ptr) {}
        public static new TransformGizmoBuilder FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TransformGizmoBuilder(p);
        public static TransformGizmoBuilder FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TransformGizmoBuilder(o.Pointer); }
        public static TransformGizmoBuilder[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TransformGizmoBuilder[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TransformGizmoBuilder(a[i].Pointer); return r; }
    }

    public class TransformGizmo : InteractiveGizmo
    {
        public const string UeClassName = "TransformGizmo";
        public TransformGizmo(global::System.IntPtr ptr) : base(ptr) {}
        public static new TransformGizmo FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TransformGizmo(p);
        public static TransformGizmo FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TransformGizmo(o.Pointer); }
        public static TransformGizmo[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TransformGizmo[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TransformGizmo(a[i].Pointer); return r; }
        public TransformProxy ActiveTarget { get { var __p = GetAt<global::System.IntPtr>(0x40); return __p==global::System.IntPtr.Zero?null:new TransformProxy(__p); } set => SetAt(0x40, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bSnapToWorldGrid { get => Native.GetPropBool(Pointer, "bSnapToWorldGrid"); set => Native.SetPropBool(Pointer, "bSnapToWorldGrid", value); }
        public bool bUseContextCoordinateSystem { get => Native.GetPropBool(Pointer, "bUseContextCoordinateSystem"); set => Native.SetPropBool(Pointer, "bUseContextCoordinateSystem", value); }
        public EToolContextCoordinateSystem CurrentCoordinateSystem { get => (EToolContextCoordinateSystem)GetAt<int>(0x4C); set => SetAt(0x4C, (int)value); }
        public TArray<global::System.IntPtr> ActiveComponents => new TArray<global::System.IntPtr>(AddrOf(0xE0)); // TArray<UObject*>
        public TArray<global::System.IntPtr> NonuniformScaleComponents => new TArray<global::System.IntPtr>(AddrOf(0xF0)); // TArray<UObject*>
        public TArray<global::System.IntPtr> ActiveGizmos => new TArray<global::System.IntPtr>(AddrOf(0x100)); // TArray<UObject*>
        public GizmoConstantFrameAxisSource CameraAxisSource { get { var __p = GetAt<global::System.IntPtr>(0x120); return __p==global::System.IntPtr.Zero?null:new GizmoConstantFrameAxisSource(__p); } set => SetAt(0x120, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoComponentAxisSource AxisXSource { get { var __p = GetAt<global::System.IntPtr>(0x128); return __p==global::System.IntPtr.Zero?null:new GizmoComponentAxisSource(__p); } set => SetAt(0x128, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoComponentAxisSource AxisYSource { get { var __p = GetAt<global::System.IntPtr>(0x130); return __p==global::System.IntPtr.Zero?null:new GizmoComponentAxisSource(__p); } set => SetAt(0x130, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoComponentAxisSource AxisZSource { get { var __p = GetAt<global::System.IntPtr>(0x138); return __p==global::System.IntPtr.Zero?null:new GizmoComponentAxisSource(__p); } set => SetAt(0x138, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoComponentAxisSource UnitAxisXSource { get { var __p = GetAt<global::System.IntPtr>(0x140); return __p==global::System.IntPtr.Zero?null:new GizmoComponentAxisSource(__p); } set => SetAt(0x140, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoComponentAxisSource UnitAxisYSource { get { var __p = GetAt<global::System.IntPtr>(0x148); return __p==global::System.IntPtr.Zero?null:new GizmoComponentAxisSource(__p); } set => SetAt(0x148, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoComponentAxisSource UnitAxisZSource { get { var __p = GetAt<global::System.IntPtr>(0x150); return __p==global::System.IntPtr.Zero?null:new GizmoComponentAxisSource(__p); } set => SetAt(0x150, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoTransformChangeStateTarget StateTarget { get { var __p = GetAt<global::System.IntPtr>(0x158); return __p==global::System.IntPtr.Zero?null:new GizmoTransformChangeStateTarget(__p); } set => SetAt(0x158, value?.Pointer ?? global::System.IntPtr.Zero); }
        public GizmoScaledTransformSource ScaledTransformSource { get { var __p = GetAt<global::System.IntPtr>(0x160); return __p==global::System.IntPtr.Zero?null:new GizmoScaledTransformSource(__p); } set => SetAt(0x160, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class TransformProxy : Object
    {
        public const string UeClassName = "TransformProxy";
        public TransformProxy(global::System.IntPtr ptr) : base(ptr) {}
        public static new TransformProxy FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TransformProxy(p);
        public static TransformProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TransformProxy(o.Pointer); }
        public static TransformProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TransformProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TransformProxy(a[i].Pointer); return r; }
        public bool bRotatePerObject { get => Native.GetPropBool(Pointer, "bRotatePerObject"); set => Native.SetPropBool(Pointer, "bRotatePerObject", value); }
        public bool bSetPivotMode { get => Native.GetPropBool(Pointer, "bSetPivotMode"); set => Native.SetPropBool(Pointer, "bSetPivotMode", value); }
        public Transform SharedTransform => new Transform(AddrOf(0x90));
        public Transform InitialSharedTransform => new Transform(AddrOf(0xC0));
    }

    public class GizmoBaseTransformSource : Object
    {
        public const string UeClassName = "GizmoBaseTransformSource";
        public GizmoBaseTransformSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoBaseTransformSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoBaseTransformSource(p);
        public static GizmoBaseTransformSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoBaseTransformSource(o.Pointer); }
        public static GizmoBaseTransformSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoBaseTransformSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoBaseTransformSource(a[i].Pointer); return r; }
    }

    public class GizmoComponentWorldTransformSource : GizmoBaseTransformSource
    {
        public const string UeClassName = "GizmoComponentWorldTransformSource";
        public GizmoComponentWorldTransformSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoComponentWorldTransformSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoComponentWorldTransformSource(p);
        public static GizmoComponentWorldTransformSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoComponentWorldTransformSource(o.Pointer); }
        public static GizmoComponentWorldTransformSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoComponentWorldTransformSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoComponentWorldTransformSource(a[i].Pointer); return r; }
        public SceneComponent component { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bModifyComponentOnTransform { get => Native.GetPropBool(Pointer, "bModifyComponentOnTransform"); set => Native.SetPropBool(Pointer, "bModifyComponentOnTransform", value); }
    }

    public class GizmoScaledTransformSource : GizmoBaseTransformSource
    {
        public const string UeClassName = "GizmoScaledTransformSource";
        public GizmoScaledTransformSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoScaledTransformSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoScaledTransformSource(p);
        public static GizmoScaledTransformSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoScaledTransformSource(o.Pointer); }
        public static GizmoScaledTransformSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoScaledTransformSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoScaledTransformSource(a[i].Pointer); return r; }
        public UObject ChildTransformSource { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class GizmoTransformProxyTransformSource : GizmoBaseTransformSource
    {
        public const string UeClassName = "GizmoTransformProxyTransformSource";
        public GizmoTransformProxyTransformSource(global::System.IntPtr ptr) : base(ptr) {}
        public static new GizmoTransformProxyTransformSource FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GizmoTransformProxyTransformSource(p);
        public static GizmoTransformProxyTransformSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GizmoTransformProxyTransformSource(o.Pointer); }
        public static GizmoTransformProxyTransformSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GizmoTransformProxyTransformSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GizmoTransformProxyTransformSource(a[i].Pointer); return r; }
        public TransformProxy Proxy { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new TransformProxy(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
