// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/Renderer
using System;

namespace UEModLoader.Game
{
    public class LightPropagationVolumeSettings : StructProxy
    {
        public LightPropagationVolumeSettings(System.IntPtr ptr) : base(ptr) {}
        public bool bOverride_LPVIntensity { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bOverride_LPVDirectionalOcclusionIntensity { get => (GetAt<byte>(0x0) & 0x2) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bOverride_LPVDirectionalOcclusionRadius { get => (GetAt<byte>(0x0) & 0x4) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bOverride_LPVDiffuseOcclusionExponent { get => (GetAt<byte>(0x0) & 0x8) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bOverride_LPVSpecularOcclusionExponent { get => (GetAt<byte>(0x0) & 0x10) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bOverride_LPVDiffuseOcclusionIntensity { get => (GetAt<byte>(0x0) & 0x20) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool bOverride_LPVSpecularOcclusionIntensity { get => (GetAt<byte>(0x0) & 0x40) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
        public bool bOverride_LPVSize { get => (GetAt<byte>(0x0) & 0x80) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x80) : (__b & ~0x80))); } }
        public bool bOverride_LPVSecondaryOcclusionIntensity { get => (GetAt<byte>(0x1) & 0x1) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bOverride_LPVSecondaryBounceIntensity { get => (GetAt<byte>(0x1) & 0x2) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bOverride_LPVGeometryVolumeBias { get => (GetAt<byte>(0x1) & 0x4) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bOverride_LPVVplInjectionBias { get => (GetAt<byte>(0x1) & 0x8) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bOverride_LPVEmissiveInjectionIntensity { get => (GetAt<byte>(0x1) & 0x10) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public float LPVIntensity { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float LPVVplInjectionBias { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float LPVSize { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float LPVSecondaryOcclusionIntensity { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public float LPVSecondaryBounceIntensity { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public float LPVGeometryVolumeBias { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
        public float LPVEmissiveInjectionIntensity { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public float LPVDirectionalOcclusionIntensity { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public float LPVDirectionalOcclusionRadius { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public float LPVDiffuseOcclusionExponent { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public float LPVSpecularOcclusionExponent { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float LPVDiffuseOcclusionIntensity { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public float LPVSpecularOcclusionIntensity { get => GetAt<float>(0x34); set => SetAt(0x34, value); }
        public float LPVFadeRange { get => GetAt<float>(0x38); set => SetAt(0x38, value); }
        public float LPVDirectionalOcclusionFadeRange { get => GetAt<float>(0x3C); set => SetAt(0x3C, value); }
    }

}
