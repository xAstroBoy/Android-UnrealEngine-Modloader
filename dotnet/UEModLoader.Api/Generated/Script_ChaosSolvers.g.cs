// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/ChaosSolvers
using System;

namespace UEModLoader.Game
{
    public class SolverBreakingFilterSettings : StructProxy
    {
        public SolverBreakingFilterSettings(System.IntPtr ptr) : base(ptr) {}
        public bool FilterEnabled { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float MinMass { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float MinSpeed { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float MinVolume { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

    public class SolverCollisionFilterSettings : StructProxy
    {
        public SolverCollisionFilterSettings(System.IntPtr ptr) : base(ptr) {}
        public bool FilterEnabled { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float MinMass { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float MinSpeed { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float MinImpulse { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

    public class SolverTrailingFilterSettings : StructProxy
    {
        public SolverTrailingFilterSettings(System.IntPtr ptr) : base(ptr) {}
        public bool FilterEnabled { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public float MinMass { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float MinSpeed { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float MinVolume { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
    }

}
