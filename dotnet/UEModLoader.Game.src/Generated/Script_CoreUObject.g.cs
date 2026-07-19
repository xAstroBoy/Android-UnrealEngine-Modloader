// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/CoreUObject
using System;

namespace UEModLoader.Game
{
    public enum EInterpCurveMode
    {
        CIM_Linear = 0,
        CIM_CurveAuto = 1,
        CIM_Constant = 2,
        CIM_CurveUser = 3,
        CIM_CurveBreak = 4,
        CIM_CurveAutoClamped = 5,
    }

    public enum ERangeBoundTypes
    {
        Exclusive = 0,
        Inclusive = 1,
        Open = 2,
    }

    public enum ELocalizedTextSourceCategory
    {
        Game = 0,
        Engine = 1,
        Editor = 2,
    }

    public enum EAutomationEventType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }

    public enum ELifetimeCondition
    {
        COND_None = 0,
        COND_InitialOnly = 1,
        COND_OwnerOnly = 2,
        COND_SkipOwner = 3,
        COND_SimulatedOnly = 4,
        COND_AutonomousOnly = 5,
        COND_SimulatedOrPhysics = 6,
        COND_InitialOrOwner = 7,
        COND_Custom = 8,
        COND_ReplayOrOwner = 9,
        COND_ReplayOnly = 10,
        COND_SimulatedOnlyNoReplay = 11,
        COND_SimulatedOrPhysicsNoReplay = 12,
        COND_SkipReplay = 13,
        COND_Never = 15,
        COND_Max = 16,
    }

    public enum EDataValidationResult
    {
        Invalid = 0,
        Valid = 1,
        NotValidated = 2,
    }

    public enum EPropertyAccessChangeNotifyMode
    {
        Default = 0,
        Never = 1,
        Always = 2,
    }

    public enum EUnit
    {
        Micrometers = 0,
        Millimeters = 1,
        Centimeters = 2,
        Meters = 3,
        Kilometers = 4,
        Inches = 5,
        Feet = 6,
        Yards = 7,
        Miles = 8,
        Lightyears = 9,
        Degrees = 10,
        Radians = 11,
        MetersPerSecond = 12,
        KilometersPerHour = 13,
        MilesPerHour = 14,
        Celsius = 15,
        Farenheit = 16,
        Kelvin = 17,
        Micrograms = 18,
        Milligrams = 19,
        Grams = 20,
        Kilograms = 21,
        MetricTons = 22,
        Ounces = 23,
        Pounds = 24,
        Stones = 25,
        Newtons = 26,
        PoundsForce = 27,
        KilogramsForce = 28,
        Hertz = 29,
        Kilohertz = 30,
        Megahertz = 31,
        Gigahertz = 32,
        RevolutionsPerMinute = 33,
        Bytes = 34,
        Kilobytes = 35,
        Megabytes = 36,
        Gigabytes = 37,
        Terabytes = 38,
        Lumens = 39,
        Milliseconds = 43,
        Seconds = 44,
        Minutes = 45,
        Hours = 46,
        Days = 47,
        Months = 48,
        Years = 49,
        Multiplier = 52,
        Percentage = 51,
        Unspecified = 53,
    }

    public enum EMouseCursor
    {
        None = 0,
        Default = 1,
        TextEditBeam = 2,
        ResizeLeftRight = 3,
        ResizeUpDown = 4,
        ResizeSouthEast = 5,
        ResizeSouthWest = 6,
        CardinalCross = 7,
        Crosshairs = 8,
        Hand = 9,
        GrabHand = 10,
        GrabHandClosed = 11,
        SlashedCircle = 12,
        EyeDropper = 13,
    }

    public enum EPixelFormat
    {
        PF_Unknown = 0,
        PF_A32B32G32R32F = 1,
        PF_B8G8R8A8 = 2,
        PF_G8 = 3,
        PF_G16 = 4,
        PF_DXT1 = 5,
        PF_DXT3 = 6,
        PF_DXT5 = 7,
        PF_UYVY = 8,
        PF_FloatRGB = 9,
        PF_FloatRGBA = 10,
        PF_DepthStencil = 11,
        PF_ShadowDepth = 12,
        PF_R32_FLOAT = 13,
        PF_G16R16 = 14,
        PF_G16R16F = 15,
        PF_G16R16F_FILTER = 16,
        PF_G32R32F = 17,
        PF_A2B10G10R10 = 18,
        PF_A16B16G16R16 = 19,
        PF_D24 = 20,
        PF_R16F = 21,
        PF_R16F_FILTER = 22,
        PF_BC5 = 23,
        PF_V8U8 = 24,
        PF_A1 = 25,
        PF_FloatR11G11B10 = 26,
        PF_A8 = 27,
        PF_R32_UINT = 28,
        PF_R32_SINT = 29,
        PF_PVRTC2 = 30,
        PF_PVRTC4 = 31,
        PF_R16_UINT = 32,
        PF_R16_SINT = 33,
        PF_R16G16B16A16_UINT = 34,
        PF_R16G16B16A16_SINT = 35,
        PF_R5G6B5_UNORM = 36,
        PF_R8G8B8A8 = 37,
        PF_A8R8G8B8 = 38,
        PF_BC4 = 39,
        PF_R8G8 = 40,
        PF_ATC_RGB = 41,
        PF_ATC_RGBA_E = 42,
        PF_ATC_RGBA_I = 43,
        PF_X24_G8 = 44,
        PF_ETC1 = 45,
        PF_ETC2_RGB = 46,
        PF_ETC2_RGBA = 47,
        PF_R32G32B32A32_UINT = 48,
        PF_R16G16_UINT = 49,
        PF_ASTC_4x4 = 50,
        PF_ASTC_6x6 = 51,
        PF_ASTC_8x8 = 52,
        PF_ASTC_10x10 = 53,
        PF_ASTC_12x12 = 54,
        PF_BC6H = 55,
        PF_BC7 = 56,
        PF_R8_UINT = 57,
        PF_L8 = 58,
        PF_XGXR8 = 59,
        PF_R8G8B8A8_UINT = 60,
        PF_R8G8B8A8_SNORM = 61,
        PF_R16G16B16A16_UNORM = 62,
        PF_R16G16B16A16_SNORM = 63,
        PF_PLATFORM_HDR = 64,
        PF_NV12 = 67,
        PF_R32G32_UINT = 68,
        PF_ETC2_R11_EAC = 69,
        PF_ETC2_RG11_EAC = 70,
    }

    public enum EAxis
    {
        None = 0,
        X = 1,
        Y = 2,
        Z = 3,
    }

    public enum ELogTimes
    {
        None = 0,
        UTC = 1,
        SinceGStartTime = 2,
        Local = 3,
    }

    public enum ESearchDir
    {
        FromStart = 0,
        FromEnd = 1,
    }

    public enum ESearchCase
    {
        CaseSensitive = 0,
        IgnoreCase = 1,
    }

    public class JoinabilitySettings : StructProxy
    {
        public JoinabilitySettings(global::System.IntPtr ptr) : base(ptr) {}
        public string SessionName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName SessionName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public bool bPublicSearchable { get => (GetAt<byte>(0x8) & 0xFF) != 0; set { var __b = GetAt<byte>(0x8); SetAt(0x8, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bAllowInvites { get => (GetAt<byte>(0x9) & 0xFF) != 0; set { var __b = GetAt<byte>(0x9); SetAt(0x9, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bJoinViaPresence { get => (GetAt<byte>(0xA) & 0xFF) != 0; set { var __b = GetAt<byte>(0xA); SetAt(0xA, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bJoinViaPresenceFriendsOnly { get => (GetAt<byte>(0xB) & 0xFF) != 0; set { var __b = GetAt<byte>(0xB); SetAt(0xB, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public int MaxPlayers { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
        public int MaxPartySize { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
    }

    public class UniqueNetIdWrapper : StructProxy
    {
        public UniqueNetIdWrapper(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class Guid : StructProxy
    {
        public Guid(global::System.IntPtr ptr) : base(ptr) {}
        public int A { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int B { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int C { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public int D { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
    }

    public class Vector : StructProxy
    {
        public Vector(global::System.IntPtr ptr) : base(ptr) {}
        public float X { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Y { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Z { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class Vector4 : StructProxy
    {
        public Vector4(global::System.IntPtr ptr) : base(ptr) {}
        public float X { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Y { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Z { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float W { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

    public class Vector2D : StructProxy
    {
        public Vector2D(global::System.IntPtr ptr) : base(ptr) {}
        public float X { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Y { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class TwoVectors : StructProxy
    {
        public TwoVectors(global::System.IntPtr ptr) : base(ptr) {}
        public Vector v1 => new Vector(AddrOf(0x0));
        public Vector v2 => new Vector(AddrOf(0xC));
    }

    public class Plane : StructProxy
    {
        public Plane(global::System.IntPtr ptr) : base(ptr) {}
        public float W { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

    public class Rotator : StructProxy
    {
        public Rotator(global::System.IntPtr ptr) : base(ptr) {}
        public float Pitch { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Yaw { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Roll { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
    }

    public class Quat : StructProxy
    {
        public Quat(global::System.IntPtr ptr) : base(ptr) {}
        public float X { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Y { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float Z { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float W { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

    public class PackedNormal : StructProxy
    {
        public PackedNormal(global::System.IntPtr ptr) : base(ptr) {}
        public byte X { get => GetAt<byte>(0x0); set => SetAt(0x0, value); }
        public byte Y { get => GetAt<byte>(0x1); set => SetAt(0x1, value); }
        public byte Z { get => GetAt<byte>(0x2); set => SetAt(0x2, value); }
        public byte W { get => GetAt<byte>(0x3); set => SetAt(0x3, value); }
    }

    public class PackedRGB10A2N : StructProxy
    {
        public PackedRGB10A2N(global::System.IntPtr ptr) : base(ptr) {}
        public int Packed { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
    }

    public class PackedRGBA16N : StructProxy
    {
        public PackedRGBA16N(global::System.IntPtr ptr) : base(ptr) {}
        public int XY { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int ZW { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class IntPoint : StructProxy
    {
        public IntPoint(global::System.IntPtr ptr) : base(ptr) {}
        public int X { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int Y { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class IntVector : StructProxy
    {
        public IntVector(global::System.IntPtr ptr) : base(ptr) {}
        public int X { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int Y { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int Z { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
    }

    public class Color : StructProxy
    {
        public Color(global::System.IntPtr ptr) : base(ptr) {}
        public byte B { get => GetAt<byte>(0x0); set => SetAt(0x0, value); }
        public byte G { get => GetAt<byte>(0x1); set => SetAt(0x1, value); }
        public byte R { get => GetAt<byte>(0x2); set => SetAt(0x2, value); }
        public byte A { get => GetAt<byte>(0x3); set => SetAt(0x3, value); }
    }

    public class LinearColor : StructProxy
    {
        public LinearColor(global::System.IntPtr ptr) : base(ptr) {}
        public float R { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float G { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float B { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float A { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

    public class Box : StructProxy
    {
        public Box(global::System.IntPtr ptr) : base(ptr) {}
        public Vector Min => new Vector(AddrOf(0x0));
        public Vector Max => new Vector(AddrOf(0xC));
        public byte IsValid { get => GetAt<byte>(0x18); set => SetAt(0x18, value); }
    }

    public class Box2D : StructProxy
    {
        public Box2D(global::System.IntPtr ptr) : base(ptr) {}
        public Vector2D Min => new Vector2D(AddrOf(0x0));
        public Vector2D Max => new Vector2D(AddrOf(0x8));
        public byte bIsValid { get => GetAt<byte>(0x10); set => SetAt(0x10, value); }
    }

    public class BoxSphereBounds : StructProxy
    {
        public BoxSphereBounds(global::System.IntPtr ptr) : base(ptr) {}
        public Vector Origin => new Vector(AddrOf(0x0));
        public Vector BoxExtent => new Vector(AddrOf(0xC));
        public float SphereRadius { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
    }

    public class OrientedBox : StructProxy
    {
        public OrientedBox(global::System.IntPtr ptr) : base(ptr) {}
        public Vector Center => new Vector(AddrOf(0x0));
        public Vector AxisX => new Vector(AddrOf(0xC));
        public Vector AxisY => new Vector(AddrOf(0x18));
        public Vector AxisZ => new Vector(AddrOf(0x24));
        public float ExtentX { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float ExtentY { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public float ExtentZ { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
    }

    public class Matrix : StructProxy
    {
        public Matrix(global::System.IntPtr ptr) : base(ptr) {}
        public Plane XPlane => new Plane(AddrOf(0x0));
        public Plane YPlane => new Plane(AddrOf(0x10));
        public Plane ZPlane => new Plane(AddrOf(0x20));
        public Plane WPlane => new Plane(AddrOf(0x30));
    }

    public class InterpCurvePointFloat : StructProxy
    {
        public InterpCurvePointFloat(global::System.IntPtr ptr) : base(ptr) {}
        public float InVal { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float OutVal { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float ArriveTangent { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float LeaveTangent { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public byte InterpMode { get => GetAt<byte>(0x10); set => SetAt(0x10, value); }
    }

    public class InterpCurveFloat : StructProxy
    {
        public InterpCurveFloat(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Points => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public bool bIsLooped { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float LoopKeyOffset { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
    }

    public class InterpCurvePointVector2D : StructProxy
    {
        public InterpCurvePointVector2D(global::System.IntPtr ptr) : base(ptr) {}
        public float InVal { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public Vector2D OutVal => new Vector2D(AddrOf(0x4));
        public Vector2D ArriveTangent => new Vector2D(AddrOf(0xC));
        public Vector2D LeaveTangent => new Vector2D(AddrOf(0x14));
        public byte InterpMode { get => GetAt<byte>(0x1C); set => SetAt(0x1C, value); }
    }

    public class InterpCurveVector2D : StructProxy
    {
        public InterpCurveVector2D(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Points => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public bool bIsLooped { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float LoopKeyOffset { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
    }

    public class InterpCurvePointVector : StructProxy
    {
        public InterpCurvePointVector(global::System.IntPtr ptr) : base(ptr) {}
        public float InVal { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public Vector OutVal => new Vector(AddrOf(0x4));
        public Vector ArriveTangent => new Vector(AddrOf(0x10));
        public Vector LeaveTangent => new Vector(AddrOf(0x1C));
        public byte InterpMode { get => GetAt<byte>(0x28); set => SetAt(0x28, value); }
    }

    public class InterpCurveVector : StructProxy
    {
        public InterpCurveVector(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Points => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public bool bIsLooped { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float LoopKeyOffset { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
    }

    public class InterpCurvePointQuat : StructProxy
    {
        public InterpCurvePointQuat(global::System.IntPtr ptr) : base(ptr) {}
        public float InVal { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public Quat OutVal => new Quat(AddrOf(0x10));
        public Quat ArriveTangent => new Quat(AddrOf(0x20));
        public Quat LeaveTangent => new Quat(AddrOf(0x30));
        public byte InterpMode { get => GetAt<byte>(0x40); set => SetAt(0x40, value); }
    }

    public class InterpCurveQuat : StructProxy
    {
        public InterpCurveQuat(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Points => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public bool bIsLooped { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float LoopKeyOffset { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
    }

    public class InterpCurvePointTwoVectors : StructProxy
    {
        public InterpCurvePointTwoVectors(global::System.IntPtr ptr) : base(ptr) {}
        public float InVal { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public TwoVectors OutVal => new TwoVectors(AddrOf(0x4));
        public TwoVectors ArriveTangent => new TwoVectors(AddrOf(0x1C));
        public TwoVectors LeaveTangent => new TwoVectors(AddrOf(0x34));
        public byte InterpMode { get => GetAt<byte>(0x4C); set => SetAt(0x4C, value); }
    }

    public class InterpCurveTwoVectors : StructProxy
    {
        public InterpCurveTwoVectors(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Points => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public bool bIsLooped { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float LoopKeyOffset { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
    }

    public class InterpCurvePointLinearColor : StructProxy
    {
        public InterpCurvePointLinearColor(global::System.IntPtr ptr) : base(ptr) {}
        public float InVal { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public LinearColor OutVal => new LinearColor(AddrOf(0x4));
        public LinearColor ArriveTangent => new LinearColor(AddrOf(0x14));
        public LinearColor LeaveTangent => new LinearColor(AddrOf(0x24));
        public byte InterpMode { get => GetAt<byte>(0x34); set => SetAt(0x34, value); }
    }

    public class InterpCurveLinearColor : StructProxy
    {
        public InterpCurveLinearColor(global::System.IntPtr ptr) : base(ptr) {}
        public TArray<global::System.IntPtr> Points => new TArray<global::System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public bool bIsLooped { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float LoopKeyOffset { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
    }

    public class Transform : StructProxy
    {
        public Transform(global::System.IntPtr ptr) : base(ptr) {}
        public Quat Rotation => new Quat(AddrOf(0x0));
        public Vector Translation => new Vector(AddrOf(0x10));
        public Vector Scale3D => new Vector(AddrOf(0x1C));
    }

    public class RandomStream : StructProxy
    {
        public RandomStream(global::System.IntPtr ptr) : base(ptr) {}
        public int InitialSeed { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int Seed { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class DateTime : StructProxy
    {
        public DateTime(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class FrameNumber : StructProxy
    {
        public FrameNumber(global::System.IntPtr ptr) : base(ptr) {}
        public int Value { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
    }

    public class FrameRate : StructProxy
    {
        public FrameRate(global::System.IntPtr ptr) : base(ptr) {}
        public int Numerator { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int Denominator { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class FrameTime : StructProxy
    {
        public FrameTime(global::System.IntPtr ptr) : base(ptr) {}
        public FrameNumber FrameNumber => new FrameNumber(AddrOf(0x0));
        public float SubFrame { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class QualifiedFrameTime : StructProxy
    {
        public QualifiedFrameTime(global::System.IntPtr ptr) : base(ptr) {}
        public FrameTime Time => new FrameTime(AddrOf(0x0));
        public FrameRate Rate => new FrameRate(AddrOf(0x8));
    }

    public class Timecode : StructProxy
    {
        public Timecode(global::System.IntPtr ptr) : base(ptr) {}
        public int Hours { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int Minutes { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int Seconds { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public int Frames { get => GetAt<int>(0xC); set => SetAt(0xC, value); }
        public bool bDropFrameFormat { get => (GetAt<byte>(0x10) & 0xFF) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class Timespan : StructProxy
    {
        public Timespan(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class SoftObjectPath : StructProxy
    {
        public SoftObjectPath(global::System.IntPtr ptr) : base(ptr) {}
        public string AssetPathName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName AssetPathName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string SubPathString => Native.ReadFStringAt(AddrOf(0x8)); // FString
    }

    public class SoftClassPath : StructProxy
    {
        public SoftClassPath(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class PrimaryAssetType : StructProxy
    {
        public PrimaryAssetType(global::System.IntPtr ptr) : base(ptr) {}
        public string Name => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName Name_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
    }

    public class PrimaryAssetId : StructProxy
    {
        public PrimaryAssetId(global::System.IntPtr ptr) : base(ptr) {}
        public PrimaryAssetType PrimaryAssetType => new PrimaryAssetType(AddrOf(0x0));
        public string PrimaryAssetName => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName PrimaryAssetName_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
    }

    public class FallbackStruct : StructProxy
    {
        public FallbackStruct(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class FloatRangeBound : StructProxy
    {
        public FloatRangeBound(global::System.IntPtr ptr) : base(ptr) {}
        public byte Type { get => GetAt<byte>(0x0); set => SetAt(0x0, value); }
        public float Value { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class FloatRange : StructProxy
    {
        public FloatRange(global::System.IntPtr ptr) : base(ptr) {}
        public FloatRangeBound LowerBound => new FloatRangeBound(AddrOf(0x0));
        public FloatRangeBound UpperBound => new FloatRangeBound(AddrOf(0x8));
    }

    public class Int32RangeBound : StructProxy
    {
        public Int32RangeBound(global::System.IntPtr ptr) : base(ptr) {}
        public byte Type { get => GetAt<byte>(0x0); set => SetAt(0x0, value); }
        public int Value { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class Int32Range : StructProxy
    {
        public Int32Range(global::System.IntPtr ptr) : base(ptr) {}
        public Int32RangeBound LowerBound => new Int32RangeBound(AddrOf(0x0));
        public Int32RangeBound UpperBound => new Int32RangeBound(AddrOf(0x8));
    }

    public class FloatInterval : StructProxy
    {
        public FloatInterval(global::System.IntPtr ptr) : base(ptr) {}
        public float Min { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float Max { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class Int32Interval : StructProxy
    {
        public Int32Interval(global::System.IntPtr ptr) : base(ptr) {}
        public int Min { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int Max { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class PolyglotTextData : StructProxy
    {
        public PolyglotTextData(global::System.IntPtr ptr) : base(ptr) {}
        public ELocalizedTextSourceCategory Category { get => (ELocalizedTextSourceCategory)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public string NativeCulture => Native.ReadFStringAt(AddrOf(0x8)); // FString
        public string Namespace => Native.ReadFStringAt(AddrOf(0x18)); // FString
        public string Key => Native.ReadFStringAt(AddrOf(0x28)); // FString
        public string NativeString => Native.ReadFStringAt(AddrOf(0x38)); // FString
        public global::System.IntPtr LocalizedStrings => AddrOf(0x48); // 
        public bool bIsMinimalPatch { get => (GetAt<byte>(0x98) & 0xFF) != 0; set { var __b = GetAt<byte>(0x98); SetAt(0x98, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public global::System.IntPtr CachedText => AddrOf(0xA0); // 
    }

    public class AutomationEvent : StructProxy
    {
        public AutomationEvent(global::System.IntPtr ptr) : base(ptr) {}
        public EAutomationEventType Type { get => (EAutomationEventType)GetAt<byte>(0x0); set => SetAt(0x0, (byte)value); }
        public string Message => Native.ReadFStringAt(AddrOf(0x8)); // FString
        public string Context => Native.ReadFStringAt(AddrOf(0x18)); // FString
        public Guid Artifact => new Guid(AddrOf(0x28));
    }

    public class AutomationExecutionEntry : StructProxy
    {
        public AutomationExecutionEntry(global::System.IntPtr ptr) : base(ptr) {}
        public AutomationEvent Event => new AutomationEvent(AddrOf(0x0));
        public string Filename => Native.ReadFStringAt(AddrOf(0x38)); // FString
        public int LineNumber { get => GetAt<int>(0x48); set => SetAt(0x48, value); }
        public DateTime Timestamp => new DateTime(AddrOf(0x50));
    }

    public class Object : UObject
    {
        public const string UeClassName = "Object";
        public Object(global::System.IntPtr ptr) : base(ptr) {}
        public static new Object FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Object(p);
        public static Object FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Object(o.Pointer); }
        public static Object[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Object[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Object(a[i].Pointer); return r; }
        public void ExecuteUbergraph(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph", __pb.Bytes);
        }
    }

    public class Interface : Object
    {
        public const string UeClassName = "Interface";
        public Interface(global::System.IntPtr ptr) : base(ptr) {}
        public static new Interface FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Interface(p);
        public static Interface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Interface(o.Pointer); }
        public static Interface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Interface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Interface(a[i].Pointer); return r; }
    }

    public class GCObjectReferencer : Object
    {
        public const string UeClassName = "GCObjectReferencer";
        public GCObjectReferencer(global::System.IntPtr ptr) : base(ptr) {}
        public static new GCObjectReferencer FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new GCObjectReferencer(p);
        public static GCObjectReferencer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GCObjectReferencer(o.Pointer); }
        public static GCObjectReferencer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GCObjectReferencer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GCObjectReferencer(a[i].Pointer); return r; }
    }

    public class TextBuffer : Object
    {
        public const string UeClassName = "TextBuffer";
        public TextBuffer(global::System.IntPtr ptr) : base(ptr) {}
        public static new TextBuffer FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TextBuffer(p);
        public static TextBuffer FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TextBuffer(o.Pointer); }
        public static TextBuffer[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TextBuffer[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TextBuffer(a[i].Pointer); return r; }
    }

    public class Field : Object
    {
        public const string UeClassName = "Field";
        public Field(global::System.IntPtr ptr) : base(ptr) {}
        public static new Field FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Field(p);
        public static Field FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Field(o.Pointer); }
        public static Field[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Field[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Field(a[i].Pointer); return r; }
    }

    public class Struct : Field
    {
        public const string UeClassName = "Struct";
        public Struct(global::System.IntPtr ptr) : base(ptr) {}
        public static new Struct FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Struct(p);
        public static Struct FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Struct(o.Pointer); }
        public static Struct[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Struct[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Struct(a[i].Pointer); return r; }
    }

    public class ScriptStruct : Struct
    {
        public const string UeClassName = "ScriptStruct";
        public ScriptStruct(global::System.IntPtr ptr) : base(ptr) {}
        public static new ScriptStruct FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ScriptStruct(p);
        public static ScriptStruct FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ScriptStruct(o.Pointer); }
        public static ScriptStruct[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ScriptStruct[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ScriptStruct(a[i].Pointer); return r; }
    }

    public class Package : Object
    {
        public const string UeClassName = "Package";
        public Package(global::System.IntPtr ptr) : base(ptr) {}
        public static new Package FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Package(p);
        public static Package FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Package(o.Pointer); }
        public static Package[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Package[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Package(a[i].Pointer); return r; }
    }

    public class Class : Struct
    {
        public const string UeClassName = "Class";
        public Class(global::System.IntPtr ptr) : base(ptr) {}
        public static new Class FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Class(p);
        public static Class FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Class(o.Pointer); }
        public static Class[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Class[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Class(a[i].Pointer); return r; }
    }

    public class Function : Struct
    {
        public const string UeClassName = "Function";
        public Function(global::System.IntPtr ptr) : base(ptr) {}
        public static new Function FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Function(p);
        public static Function FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Function(o.Pointer); }
        public static Function[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Function[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Function(a[i].Pointer); return r; }
    }

    public class DelegateFunction : Function
    {
        public const string UeClassName = "DelegateFunction";
        public DelegateFunction(global::System.IntPtr ptr) : base(ptr) {}
        public static new DelegateFunction FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DelegateFunction(p);
        public static DelegateFunction FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DelegateFunction(o.Pointer); }
        public static DelegateFunction[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DelegateFunction[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DelegateFunction(a[i].Pointer); return r; }
    }

    public class SparseDelegateFunction : DelegateFunction
    {
        public const string UeClassName = "SparseDelegateFunction";
        public SparseDelegateFunction(global::System.IntPtr ptr) : base(ptr) {}
        public static new SparseDelegateFunction FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SparseDelegateFunction(p);
        public static SparseDelegateFunction FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SparseDelegateFunction(o.Pointer); }
        public static SparseDelegateFunction[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SparseDelegateFunction[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SparseDelegateFunction(a[i].Pointer); return r; }
    }

    public class DynamicClass : Class
    {
        public const string UeClassName = "DynamicClass";
        public DynamicClass(global::System.IntPtr ptr) : base(ptr) {}
        public static new DynamicClass FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DynamicClass(p);
        public static DynamicClass FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DynamicClass(o.Pointer); }
        public static DynamicClass[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DynamicClass[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DynamicClass(a[i].Pointer); return r; }
    }

    public class PackageMap : Object
    {
        public const string UeClassName = "PackageMap";
        public PackageMap(global::System.IntPtr ptr) : base(ptr) {}
        public static new PackageMap FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PackageMap(p);
        public static PackageMap FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PackageMap(o.Pointer); }
        public static PackageMap[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PackageMap[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PackageMap(a[i].Pointer); return r; }
    }

    public class Enum : Field
    {
        public const string UeClassName = "Enum";
        public Enum(global::System.IntPtr ptr) : base(ptr) {}
        public static new Enum FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Enum(p);
        public static Enum FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Enum(o.Pointer); }
        public static Enum[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Enum[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Enum(a[i].Pointer); return r; }
    }

    public class LinkerPlaceholderClass : Class
    {
        public const string UeClassName = "LinkerPlaceholderClass";
        public LinkerPlaceholderClass(global::System.IntPtr ptr) : base(ptr) {}
        public static new LinkerPlaceholderClass FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LinkerPlaceholderClass(p);
        public static LinkerPlaceholderClass FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LinkerPlaceholderClass(o.Pointer); }
        public static LinkerPlaceholderClass[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LinkerPlaceholderClass[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LinkerPlaceholderClass(a[i].Pointer); return r; }
    }

    public class LinkerPlaceholderExportObject : Object
    {
        public const string UeClassName = "LinkerPlaceholderExportObject";
        public LinkerPlaceholderExportObject(global::System.IntPtr ptr) : base(ptr) {}
        public static new LinkerPlaceholderExportObject FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LinkerPlaceholderExportObject(p);
        public static LinkerPlaceholderExportObject FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LinkerPlaceholderExportObject(o.Pointer); }
        public static LinkerPlaceholderExportObject[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LinkerPlaceholderExportObject[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LinkerPlaceholderExportObject(a[i].Pointer); return r; }
    }

    public class LinkerPlaceholderFunction : Function
    {
        public const string UeClassName = "LinkerPlaceholderFunction";
        public LinkerPlaceholderFunction(global::System.IntPtr ptr) : base(ptr) {}
        public static new LinkerPlaceholderFunction FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LinkerPlaceholderFunction(p);
        public static LinkerPlaceholderFunction FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LinkerPlaceholderFunction(o.Pointer); }
        public static LinkerPlaceholderFunction[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LinkerPlaceholderFunction[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LinkerPlaceholderFunction(a[i].Pointer); return r; }
    }

    public class MetaData : Object
    {
        public const string UeClassName = "MetaData";
        public MetaData(global::System.IntPtr ptr) : base(ptr) {}
        public static new MetaData FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MetaData(p);
        public static MetaData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MetaData(o.Pointer); }
        public static MetaData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MetaData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MetaData(a[i].Pointer); return r; }
    }

    public class ObjectRedirector : Object
    {
        public const string UeClassName = "ObjectRedirector";
        public ObjectRedirector(global::System.IntPtr ptr) : base(ptr) {}
        public static new ObjectRedirector FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ObjectRedirector(p);
        public static ObjectRedirector FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ObjectRedirector(o.Pointer); }
        public static ObjectRedirector[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ObjectRedirector[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ObjectRedirector(a[i].Pointer); return r; }
    }

    public class Property : Field
    {
        public const string UeClassName = "Property";
        public Property(global::System.IntPtr ptr) : base(ptr) {}
        public static new Property FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Property(p);
        public static Property FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Property(o.Pointer); }
        public static Property[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Property[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Property(a[i].Pointer); return r; }
    }

    public class EnumProperty : Property
    {
        public const string UeClassName = "EnumProperty";
        public EnumProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new EnumProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new EnumProperty(p);
        public static EnumProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EnumProperty(o.Pointer); }
        public static EnumProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EnumProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EnumProperty(a[i].Pointer); return r; }
    }

    public class ArrayProperty : Property
    {
        public const string UeClassName = "ArrayProperty";
        public ArrayProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new ArrayProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ArrayProperty(p);
        public static ArrayProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ArrayProperty(o.Pointer); }
        public static ArrayProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ArrayProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ArrayProperty(a[i].Pointer); return r; }
    }

    public class ObjectPropertyBase : Property
    {
        public const string UeClassName = "ObjectPropertyBase";
        public ObjectPropertyBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new ObjectPropertyBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ObjectPropertyBase(p);
        public static ObjectPropertyBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ObjectPropertyBase(o.Pointer); }
        public static ObjectPropertyBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ObjectPropertyBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ObjectPropertyBase(a[i].Pointer); return r; }
    }

    public class BoolProperty : Property
    {
        public const string UeClassName = "BoolProperty";
        public BoolProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new BoolProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BoolProperty(p);
        public static BoolProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BoolProperty(o.Pointer); }
        public static BoolProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BoolProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BoolProperty(a[i].Pointer); return r; }
    }

    public class NumericProperty : Property
    {
        public const string UeClassName = "NumericProperty";
        public NumericProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new NumericProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NumericProperty(p);
        public static NumericProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NumericProperty(o.Pointer); }
        public static NumericProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NumericProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NumericProperty(a[i].Pointer); return r; }
    }

    public class ByteProperty : NumericProperty
    {
        public const string UeClassName = "ByteProperty";
        public ByteProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new ByteProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ByteProperty(p);
        public static ByteProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ByteProperty(o.Pointer); }
        public static ByteProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ByteProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ByteProperty(a[i].Pointer); return r; }
    }

    public class ObjectProperty : ObjectPropertyBase
    {
        public const string UeClassName = "ObjectProperty";
        public ObjectProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new ObjectProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ObjectProperty(p);
        public static ObjectProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ObjectProperty(o.Pointer); }
        public static ObjectProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ObjectProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ObjectProperty(a[i].Pointer); return r; }
    }

    public class ClassProperty : ObjectProperty
    {
        public const string UeClassName = "ClassProperty";
        public ClassProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new ClassProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ClassProperty(p);
        public static ClassProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ClassProperty(o.Pointer); }
        public static ClassProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ClassProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ClassProperty(a[i].Pointer); return r; }
    }

    public class DelegateProperty : Property
    {
        public const string UeClassName = "DelegateProperty";
        public DelegateProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new DelegateProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DelegateProperty(p);
        public static DelegateProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DelegateProperty(o.Pointer); }
        public static DelegateProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DelegateProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DelegateProperty(a[i].Pointer); return r; }
    }

    public class DoubleProperty : NumericProperty
    {
        public const string UeClassName = "DoubleProperty";
        public DoubleProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new DoubleProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DoubleProperty(p);
        public static DoubleProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DoubleProperty(o.Pointer); }
        public static DoubleProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DoubleProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DoubleProperty(a[i].Pointer); return r; }
    }

    public class FloatProperty : NumericProperty
    {
        public const string UeClassName = "FloatProperty";
        public FloatProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new FloatProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new FloatProperty(p);
        public static FloatProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FloatProperty(o.Pointer); }
        public static FloatProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FloatProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FloatProperty(a[i].Pointer); return r; }
    }

    public class IntProperty : NumericProperty
    {
        public const string UeClassName = "IntProperty";
        public IntProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new IntProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new IntProperty(p);
        public static IntProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new IntProperty(o.Pointer); }
        public static IntProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new IntProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new IntProperty(a[i].Pointer); return r; }
    }

    public class Int8Property : NumericProperty
    {
        public const string UeClassName = "Int8Property";
        public Int8Property(global::System.IntPtr ptr) : base(ptr) {}
        public static new Int8Property FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Int8Property(p);
        public static Int8Property FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Int8Property(o.Pointer); }
        public static Int8Property[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Int8Property[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Int8Property(a[i].Pointer); return r; }
    }

    public class Int16Property : NumericProperty
    {
        public const string UeClassName = "Int16Property";
        public Int16Property(global::System.IntPtr ptr) : base(ptr) {}
        public static new Int16Property FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Int16Property(p);
        public static Int16Property FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Int16Property(o.Pointer); }
        public static Int16Property[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Int16Property[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Int16Property(a[i].Pointer); return r; }
    }

    public class Int64Property : NumericProperty
    {
        public const string UeClassName = "Int64Property";
        public Int64Property(global::System.IntPtr ptr) : base(ptr) {}
        public static new Int64Property FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Int64Property(p);
        public static Int64Property FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Int64Property(o.Pointer); }
        public static Int64Property[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Int64Property[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Int64Property(a[i].Pointer); return r; }
    }

    public class InterfaceProperty : Property
    {
        public const string UeClassName = "InterfaceProperty";
        public InterfaceProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new InterfaceProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InterfaceProperty(p);
        public static InterfaceProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InterfaceProperty(o.Pointer); }
        public static InterfaceProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InterfaceProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InterfaceProperty(a[i].Pointer); return r; }
    }

    public class LazyObjectProperty : ObjectPropertyBase
    {
        public const string UeClassName = "LazyObjectProperty";
        public LazyObjectProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new LazyObjectProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LazyObjectProperty(p);
        public static LazyObjectProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LazyObjectProperty(o.Pointer); }
        public static LazyObjectProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LazyObjectProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LazyObjectProperty(a[i].Pointer); return r; }
    }

    public class MapProperty : Property
    {
        public const string UeClassName = "MapProperty";
        public MapProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new MapProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MapProperty(p);
        public static MapProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MapProperty(o.Pointer); }
        public static MapProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MapProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MapProperty(a[i].Pointer); return r; }
    }

    public class MulticastDelegateProperty : Property
    {
        public const string UeClassName = "MulticastDelegateProperty";
        public MulticastDelegateProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new MulticastDelegateProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MulticastDelegateProperty(p);
        public static MulticastDelegateProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MulticastDelegateProperty(o.Pointer); }
        public static MulticastDelegateProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MulticastDelegateProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MulticastDelegateProperty(a[i].Pointer); return r; }
    }

    public class MulticastInlineDelegateProperty : MulticastDelegateProperty
    {
        public const string UeClassName = "MulticastInlineDelegateProperty";
        public MulticastInlineDelegateProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new MulticastInlineDelegateProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MulticastInlineDelegateProperty(p);
        public static MulticastInlineDelegateProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MulticastInlineDelegateProperty(o.Pointer); }
        public static MulticastInlineDelegateProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MulticastInlineDelegateProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MulticastInlineDelegateProperty(a[i].Pointer); return r; }
    }

    public class MulticastSparseDelegateProperty : MulticastDelegateProperty
    {
        public const string UeClassName = "MulticastSparseDelegateProperty";
        public MulticastSparseDelegateProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new MulticastSparseDelegateProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MulticastSparseDelegateProperty(p);
        public static MulticastSparseDelegateProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MulticastSparseDelegateProperty(o.Pointer); }
        public static MulticastSparseDelegateProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MulticastSparseDelegateProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MulticastSparseDelegateProperty(a[i].Pointer); return r; }
    }

    public class NameProperty : Property
    {
        public const string UeClassName = "NameProperty";
        public NameProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new NameProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NameProperty(p);
        public static NameProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NameProperty(o.Pointer); }
        public static NameProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NameProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NameProperty(a[i].Pointer); return r; }
    }

    public class SetProperty : Property
    {
        public const string UeClassName = "SetProperty";
        public SetProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new SetProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SetProperty(p);
        public static SetProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SetProperty(o.Pointer); }
        public static SetProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SetProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SetProperty(a[i].Pointer); return r; }
    }

    public class SoftObjectProperty : ObjectPropertyBase
    {
        public const string UeClassName = "SoftObjectProperty";
        public SoftObjectProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new SoftObjectProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SoftObjectProperty(p);
        public static SoftObjectProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SoftObjectProperty(o.Pointer); }
        public static SoftObjectProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SoftObjectProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SoftObjectProperty(a[i].Pointer); return r; }
    }

    public class SoftClassProperty : SoftObjectProperty
    {
        public const string UeClassName = "SoftClassProperty";
        public SoftClassProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new SoftClassProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SoftClassProperty(p);
        public static SoftClassProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SoftClassProperty(o.Pointer); }
        public static SoftClassProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SoftClassProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SoftClassProperty(a[i].Pointer); return r; }
    }

    public class StrProperty : Property
    {
        public const string UeClassName = "StrProperty";
        public StrProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new StrProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new StrProperty(p);
        public static StrProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new StrProperty(o.Pointer); }
        public static StrProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new StrProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new StrProperty(a[i].Pointer); return r; }
    }

    public class StructProperty : Property
    {
        public const string UeClassName = "StructProperty";
        public StructProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new StructProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new StructProperty(p);
        public static StructProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new StructProperty(o.Pointer); }
        public static StructProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new StructProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new StructProperty(a[i].Pointer); return r; }
    }

    public class UInt16Property : NumericProperty
    {
        public const string UeClassName = "UInt16Property";
        public UInt16Property(global::System.IntPtr ptr) : base(ptr) {}
        public static new UInt16Property FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UInt16Property(p);
        public static UInt16Property FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UInt16Property(o.Pointer); }
        public static UInt16Property[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UInt16Property[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UInt16Property(a[i].Pointer); return r; }
    }

    public class UInt32Property : NumericProperty
    {
        public const string UeClassName = "UInt32Property";
        public UInt32Property(global::System.IntPtr ptr) : base(ptr) {}
        public static new UInt32Property FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UInt32Property(p);
        public static UInt32Property FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UInt32Property(o.Pointer); }
        public static UInt32Property[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UInt32Property[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UInt32Property(a[i].Pointer); return r; }
    }

    public class UInt64Property : NumericProperty
    {
        public const string UeClassName = "UInt64Property";
        public UInt64Property(global::System.IntPtr ptr) : base(ptr) {}
        public static new UInt64Property FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UInt64Property(p);
        public static UInt64Property FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UInt64Property(o.Pointer); }
        public static UInt64Property[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UInt64Property[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UInt64Property(a[i].Pointer); return r; }
    }

    public class WeakObjectProperty : ObjectPropertyBase
    {
        public const string UeClassName = "WeakObjectProperty";
        public WeakObjectProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new WeakObjectProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new WeakObjectProperty(p);
        public static WeakObjectProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WeakObjectProperty(o.Pointer); }
        public static WeakObjectProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WeakObjectProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WeakObjectProperty(a[i].Pointer); return r; }
    }

    public class TextProperty : Property
    {
        public const string UeClassName = "TextProperty";
        public TextProperty(global::System.IntPtr ptr) : base(ptr) {}
        public static new TextProperty FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TextProperty(p);
        public static TextProperty FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TextProperty(o.Pointer); }
        public static TextProperty[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TextProperty[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TextProperty(a[i].Pointer); return r; }
    }

    public class PropertyWrapper : Object
    {
        public const string UeClassName = "PropertyWrapper";
        public PropertyWrapper(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropertyWrapper FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropertyWrapper(p);
        public static PropertyWrapper FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropertyWrapper(o.Pointer); }
        public static PropertyWrapper[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropertyWrapper[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropertyWrapper(a[i].Pointer); return r; }
    }

    public class MulticastDelegatePropertyWrapper : PropertyWrapper
    {
        public const string UeClassName = "MulticastDelegatePropertyWrapper";
        public MulticastDelegatePropertyWrapper(global::System.IntPtr ptr) : base(ptr) {}
        public static new MulticastDelegatePropertyWrapper FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MulticastDelegatePropertyWrapper(p);
        public static MulticastDelegatePropertyWrapper FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MulticastDelegatePropertyWrapper(o.Pointer); }
        public static MulticastDelegatePropertyWrapper[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MulticastDelegatePropertyWrapper[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MulticastDelegatePropertyWrapper(a[i].Pointer); return r; }
    }

    public class MulticastInlineDelegatePropertyWrapper : MulticastDelegatePropertyWrapper
    {
        public const string UeClassName = "MulticastInlineDelegatePropertyWrapper";
        public MulticastInlineDelegatePropertyWrapper(global::System.IntPtr ptr) : base(ptr) {}
        public static new MulticastInlineDelegatePropertyWrapper FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MulticastInlineDelegatePropertyWrapper(p);
        public static MulticastInlineDelegatePropertyWrapper FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MulticastInlineDelegatePropertyWrapper(o.Pointer); }
        public static MulticastInlineDelegatePropertyWrapper[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MulticastInlineDelegatePropertyWrapper[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MulticastInlineDelegatePropertyWrapper(a[i].Pointer); return r; }
    }

}
