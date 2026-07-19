// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/EyeTracker
using System;

namespace UEModLoader.Game
{
    public enum EEyeTrackerStatus
    {
        NotConnected = 0,
        NotTracking = 1,
        Tracking = 2,
    }

    public class EyeTrackerStereoGazeData : StructProxy
    {
        public EyeTrackerStereoGazeData(global::System.IntPtr ptr) : base(ptr) {}
        public Vector LeftEyeOrigin => new Vector(AddrOf(0x0));
        public Vector LeftEyeDirection => new Vector(AddrOf(0xC));
        public Vector RightEyeOrigin => new Vector(AddrOf(0x18));
        public Vector RightEyeDirection => new Vector(AddrOf(0x24));
        public Vector FixationPoint => new Vector(AddrOf(0x30));
        public float ConfidenceValue { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
    }

    public class EyeTrackerGazeData : StructProxy
    {
        public EyeTrackerGazeData(global::System.IntPtr ptr) : base(ptr) {}
        public Vector GazeOrigin => new Vector(AddrOf(0x0));
        public Vector GazeDirection => new Vector(AddrOf(0xC));
        public Vector FixationPoint => new Vector(AddrOf(0x18));
        public float ConfidenceValue { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
    }

    public class EyeTrackerFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "EyeTrackerFunctionLibrary";
        public EyeTrackerFunctionLibrary(global::System.IntPtr ptr) : base(ptr) {}
        public static new EyeTrackerFunctionLibrary FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new EyeTrackerFunctionLibrary(p);
        public static EyeTrackerFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EyeTrackerFunctionLibrary(o.Pointer); }
        public static EyeTrackerFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EyeTrackerFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EyeTrackerFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x81BE69C — hookable via Hooks.InstallAt(NativeFunc_SetEyeTrackedPlayer).</summary>
        public static global::System.IntPtr NativeFunc_SetEyeTrackedPlayer => Memory.ModuleBase() + 0x81BE69C;
        public void SetEyeTrackedPlayer(PlayerController PlayerController)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, PlayerController);
            CallRaw("SetEyeTrackedPlayer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x81BE8B0 — hookable via Hooks.InstallAt(NativeFunc_IsStereoGazeDataAvailable).</summary>
        public static global::System.IntPtr NativeFunc_IsStereoGazeDataAvailable => Memory.ModuleBase() + 0x81BE8B0;
        public bool IsStereoGazeDataAvailable()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsStereoGazeDataAvailable", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81BE8E8 — hookable via Hooks.InstallAt(NativeFunc_IsEyeTrackerConnected).</summary>
        public static global::System.IntPtr NativeFunc_IsEyeTrackerConnected => Memory.ModuleBase() + 0x81BE8E8;
        public bool IsEyeTrackerConnected()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsEyeTrackerConnected", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81BE730 — hookable via Hooks.InstallAt(NativeFunc_GetStereoGazeData).</summary>
        public static global::System.IntPtr NativeFunc_GetStereoGazeData => Memory.ModuleBase() + 0x81BE730;
        public bool GetStereoGazeData(global::System.IntPtr OutGazeData)
        {
            var __pb = new ParamBuffer(65);
            __pb.Set<global::System.IntPtr>(0x0, OutGazeData);
            CallRaw("GetStereoGazeData", __pb.Bytes);
            return __pb.Get<byte>(0x40) != 0;
        }
        /// <summary>[Native] thunk RVA 0x81BE7F0 — hookable via Hooks.InstallAt(NativeFunc_GetGazeData).</summary>
        public static global::System.IntPtr NativeFunc_GetGazeData => Memory.ModuleBase() + 0x81BE7F0;
        public bool GetGazeData(global::System.IntPtr OutGazeData)
        {
            var __pb = new ParamBuffer(41);
            __pb.Set<global::System.IntPtr>(0x0, OutGazeData);
            CallRaw("GetGazeData", __pb.Bytes);
            return __pb.Get<byte>(0x28) != 0;
        }
    }

}
