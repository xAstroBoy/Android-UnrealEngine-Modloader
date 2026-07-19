// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/TimeManagement
using System;

namespace UEModLoader.Game
{
    public enum EFrameNumberDisplayFormats
    {
        NonDropFrameTimecode = 0,
        DropFrameTimecode = 1,
        Seconds = 2,
        Frames = 3,
        MAX_Count = 4,
    }

    public enum ETimedDataInputState
    {
        Connected = 0,
        Unresponsive = 1,
        Disconnected = 2,
    }

    public enum ETimedDataInputEvaluationType
    {
        None = 0,
        Timecode = 1,
        PlatformTime = 2,
    }

    public class TimedDataInputEvaluationData : StructProxy
    {
        public TimedDataInputEvaluationData(System.IntPtr ptr) : base(ptr) {}
        public float DistanceToNewestSampleSeconds { get => GetAt<float>(0x0); set => SetAt(0x0, value); }
        public float DistanceToOldestSampleSeconds { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
    }

    public class TimedDataChannelSampleTime : StructProxy
    {
        public TimedDataChannelSampleTime(System.IntPtr ptr) : base(ptr) {}
    }

    public class FixedFrameRateCustomTimeStep : EngineCustomTimeStep
    {
        public const string UeClassName = "FixedFrameRateCustomTimeStep";
        public FixedFrameRateCustomTimeStep(System.IntPtr ptr) : base(ptr) {}
        public static new FixedFrameRateCustomTimeStep FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new FixedFrameRateCustomTimeStep(p);
        public static FixedFrameRateCustomTimeStep FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new FixedFrameRateCustomTimeStep(o.Pointer); }
        public static FixedFrameRateCustomTimeStep[] All() { var a = UObject.FindAllOf(UeClassName); var r = new FixedFrameRateCustomTimeStep[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new FixedFrameRateCustomTimeStep(a[i].Pointer); return r; }
        public FrameRate FixedFrameRate => new FrameRate(AddrOf(0x28));
    }

    public class TimeManagementBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "TimeManagementBlueprintLibrary";
        public TimeManagementBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new TimeManagementBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TimeManagementBlueprintLibrary(p);
        public static TimeManagementBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TimeManagementBlueprintLibrary(o.Pointer); }
        public static TimeManagementBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TimeManagementBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TimeManagementBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7AFAB20 — hookable via Hooks.InstallAt(NativeFunc_TransformTime).</summary>
        public static System.IntPtr NativeFunc_TransformTime => Memory.ModuleBase() + 0x7AFAB20;
        public FrameTime TransformTime(FrameTime SourceTime, FrameRate SourceRate, FrameRate DestinationRate)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, SourceTime);
            __pb.Set<System.IntPtr>(0x8, SourceRate);
            __pb.Set<System.IntPtr>(0x10, DestinationRate);
            CallRaw("TransformTime", __pb.Bytes);
            return __pb.Get<FrameTime>(0x18);
        }
        /// <summary>[Native] thunk RVA 0x7AFA61C — hookable via Hooks.InstallAt(NativeFunc_Subtract_FrameNumberInteger).</summary>
        public static System.IntPtr NativeFunc_Subtract_FrameNumberInteger => Memory.ModuleBase() + 0x7AFA61C;
        public FrameNumber Subtract_FrameNumberInteger(FrameNumber A, int B)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set(0x4, B);
            CallRaw("Subtract_FrameNumberInteger", __pb.Bytes);
            return __pb.Get<FrameNumber>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7AFA7E4 — hookable via Hooks.InstallAt(NativeFunc_Subtract_FrameNumberFrameNumber).</summary>
        public static System.IntPtr NativeFunc_Subtract_FrameNumberFrameNumber => Memory.ModuleBase() + 0x7AFA7E4;
        public FrameNumber Subtract_FrameNumberFrameNumber(FrameNumber A, FrameNumber B)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set<System.IntPtr>(0x4, B);
            CallRaw("Subtract_FrameNumberFrameNumber", __pb.Bytes);
            return __pb.Get<FrameNumber>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7AFA9B4 — hookable via Hooks.InstallAt(NativeFunc_SnapFrameTimeToRate).</summary>
        public static System.IntPtr NativeFunc_SnapFrameTimeToRate => Memory.ModuleBase() + 0x7AFA9B4;
        public FrameTime SnapFrameTimeToRate(FrameTime SourceTime, FrameRate SourceRate, FrameRate SnapToRate)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, SourceTime);
            __pb.Set<System.IntPtr>(0x8, SourceRate);
            __pb.Set<System.IntPtr>(0x10, SnapToRate);
            CallRaw("SnapFrameTimeToRate", __pb.Bytes);
            return __pb.Get<FrameTime>(0x18);
        }
        /// <summary>[Native] thunk RVA 0x7AFAFB0 — hookable via Hooks.InstallAt(NativeFunc_Multiply_SecondsFrameRate).</summary>
        public static System.IntPtr NativeFunc_Multiply_SecondsFrameRate => Memory.ModuleBase() + 0x7AFAFB0;
        public FrameTime Multiply_SecondsFrameRate(float TimeInSeconds, FrameRate FrameRate)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set(0x0, TimeInSeconds);
            __pb.Set<System.IntPtr>(0x4, FrameRate);
            CallRaw("Multiply_SecondsFrameRate", __pb.Bytes);
            return __pb.Get<FrameTime>(0xC);
        }
        /// <summary>[Native] thunk RVA 0x7AFA538 — hookable via Hooks.InstallAt(NativeFunc_Multiply_FrameNumberInteger).</summary>
        public static System.IntPtr NativeFunc_Multiply_FrameNumberInteger => Memory.ModuleBase() + 0x7AFA538;
        public FrameNumber Multiply_FrameNumberInteger(FrameNumber A, int B)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set(0x4, B);
            CallRaw("Multiply_FrameNumberInteger", __pb.Bytes);
            return __pb.Get<FrameNumber>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7AFAC8C — hookable via Hooks.InstallAt(NativeFunc_IsValid_MultipleOf).</summary>
        public static System.IntPtr NativeFunc_IsValid_MultipleOf => Memory.ModuleBase() + 0x7AFAC8C;
        public bool IsValid_MultipleOf(FrameRate InFrameRate, FrameRate OtherFramerate)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, InFrameRate);
            __pb.Set<System.IntPtr>(0x8, OtherFramerate);
            CallRaw("IsValid_MultipleOf", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7AFADA4 — hookable via Hooks.InstallAt(NativeFunc_IsValid_Framerate).</summary>
        public static System.IntPtr NativeFunc_IsValid_Framerate => Memory.ModuleBase() + 0x7AFADA4;
        public bool IsValid_Framerate(FrameRate InFrameRate)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<System.IntPtr>(0x0, InFrameRate);
            CallRaw("IsValid_Framerate", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7AFA300 — hookable via Hooks.InstallAt(NativeFunc_GetTimecodeFrameRate).</summary>
        public static System.IntPtr NativeFunc_GetTimecodeFrameRate => Memory.ModuleBase() + 0x7AFA300;
        public FrameRate GetTimecodeFrameRate()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetTimecodeFrameRate", __pb.Bytes);
            return __pb.Get<FrameRate>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7AFA334 — hookable via Hooks.InstallAt(NativeFunc_GetTimecode).</summary>
        public static System.IntPtr NativeFunc_GetTimecode => Memory.ModuleBase() + 0x7AFA334;
        public Timecode GetTimecode()
        {
            var __pb = new ParamBuffer(20);
            CallRaw("GetTimecode", __pb.Bytes);
            return __pb.Get<Timecode>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x7AFA454 — hookable via Hooks.InstallAt(NativeFunc_Divide_FrameNumberInteger).</summary>
        public static System.IntPtr NativeFunc_Divide_FrameNumberInteger => Memory.ModuleBase() + 0x7AFA454;
        public FrameNumber Divide_FrameNumberInteger(FrameNumber A, int B)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set(0x4, B);
            CallRaw("Divide_FrameNumberInteger", __pb.Bytes);
            return __pb.Get<FrameNumber>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7AFAE64 — hookable via Hooks.InstallAt(NativeFunc_Conv_TimecodeToString).</summary>
        public static System.IntPtr NativeFunc_Conv_TimecodeToString => Memory.ModuleBase() + 0x7AFAE64;
        public System.IntPtr Conv_TimecodeToString(Timecode InTimecode, bool bForceSignDisplay)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, InTimecode);
            __pb.Set<byte>(0x14, (byte)(bForceSignDisplay?1:0));
            CallRaw("Conv_TimecodeToString", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x18);
        }
        /// <summary>[Native] thunk RVA 0x7AFB0A8 — hookable via Hooks.InstallAt(NativeFunc_Conv_QualifiedFrameTimeToSeconds).</summary>
        public static System.IntPtr NativeFunc_Conv_QualifiedFrameTimeToSeconds => Memory.ModuleBase() + 0x7AFB0A8;
        public float Conv_QualifiedFrameTimeToSeconds(QualifiedFrameTime InFrameTime)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<System.IntPtr>(0x0, InFrameTime);
            CallRaw("Conv_QualifiedFrameTimeToSeconds", __pb.Bytes);
            return __pb.Get<float>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x7AFB168 — hookable via Hooks.InstallAt(NativeFunc_Conv_FrameRateToSeconds).</summary>
        public static System.IntPtr NativeFunc_Conv_FrameRateToSeconds => Memory.ModuleBase() + 0x7AFB168;
        public float Conv_FrameRateToSeconds(FrameRate InFrameRate)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, InFrameRate);
            CallRaw("Conv_FrameRateToSeconds", __pb.Bytes);
            return __pb.Get<float>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7AFA3A0 — hookable via Hooks.InstallAt(NativeFunc_Conv_FrameNumberToInteger).</summary>
        public static System.IntPtr NativeFunc_Conv_FrameNumberToInteger => Memory.ModuleBase() + 0x7AFA3A0;
        public int Conv_FrameNumberToInteger(FrameNumber InFrameNumber)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, InFrameNumber);
            CallRaw("Conv_FrameNumberToInteger", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x7AFA700 — hookable via Hooks.InstallAt(NativeFunc_Add_FrameNumberInteger).</summary>
        public static System.IntPtr NativeFunc_Add_FrameNumberInteger => Memory.ModuleBase() + 0x7AFA700;
        public FrameNumber Add_FrameNumberInteger(FrameNumber A, int B)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set(0x4, B);
            CallRaw("Add_FrameNumberInteger", __pb.Bytes);
            return __pb.Get<FrameNumber>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7AFA8CC — hookable via Hooks.InstallAt(NativeFunc_Add_FrameNumberFrameNumber).</summary>
        public static System.IntPtr NativeFunc_Add_FrameNumberFrameNumber => Memory.ModuleBase() + 0x7AFA8CC;
        public FrameNumber Add_FrameNumberFrameNumber(FrameNumber A, FrameNumber B)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set<System.IntPtr>(0x4, B);
            CallRaw("Add_FrameNumberFrameNumber", __pb.Bytes);
            return __pb.Get<FrameNumber>(0x8);
        }
    }

    public class TimeSynchronizationSource : Object
    {
        public const string UeClassName = "TimeSynchronizationSource";
        public TimeSynchronizationSource(System.IntPtr ptr) : base(ptr) {}
        public static new TimeSynchronizationSource FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new TimeSynchronizationSource(p);
        public static TimeSynchronizationSource FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TimeSynchronizationSource(o.Pointer); }
        public static TimeSynchronizationSource[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TimeSynchronizationSource[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TimeSynchronizationSource(a[i].Pointer); return r; }
        public bool bUseForSynchronization { get => Native.GetPropBool(Pointer, "bUseForSynchronization"); set => Native.SetPropBool(Pointer, "bUseForSynchronization", value); }
        public int FrameOffset { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
    }

}
