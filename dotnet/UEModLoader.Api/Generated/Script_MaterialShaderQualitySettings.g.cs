// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/MaterialShaderQualitySettings
using System;

namespace UEModLoader.Game
{
    public enum EMobileCSMQuality
    {
        NoFiltering = 0,
        PCF_1x1 = 1,
        PCF_2x2 = 2,
        PCF_3x3 = 3,
    }

    public class MaterialQualityOverrides : StructProxy
    {
        public MaterialQualityOverrides(System.IntPtr ptr) : base(ptr) {}
        public bool bDiscardQualityDuringCook { get => (GetAt<byte>(0x0) & 0xFF) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bEnableOverride { get => (GetAt<byte>(0x1) & 0xFF) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bForceFullyRough { get => (GetAt<byte>(0x2) & 0xFF) != 0; set { var __b = GetAt<byte>(0x2); SetAt(0x2, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bForceNonMetal { get => (GetAt<byte>(0x3) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3); SetAt(0x3, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bForceDisableLMDirectionality { get => (GetAt<byte>(0x4) & 0xFF) != 0; set { var __b = GetAt<byte>(0x4); SetAt(0x4, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bForceLQReflections { get => (GetAt<byte>(0x5) & 0xFF) != 0; set { var __b = GetAt<byte>(0x5); SetAt(0x5, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bForceDisablePreintegratedGF { get => (GetAt<byte>(0x6) & 0xFF) != 0; set { var __b = GetAt<byte>(0x6); SetAt(0x6, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bDisableMaterialNormalCalculation { get => (GetAt<byte>(0x7) & 0xFF) != 0; set { var __b = GetAt<byte>(0x7); SetAt(0x7, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public EMobileCSMQuality MobileCSMQuality { get => (EMobileCSMQuality)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
    }

    public class MaterialShaderQualitySettings : Object
    {
        public const string UeClassName = "MaterialShaderQualitySettings";
        public MaterialShaderQualitySettings(System.IntPtr ptr) : base(ptr) {}
        public static new MaterialShaderQualitySettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MaterialShaderQualitySettings(p);
        public static MaterialShaderQualitySettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MaterialShaderQualitySettings(o.Pointer); }
        public static MaterialShaderQualitySettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MaterialShaderQualitySettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MaterialShaderQualitySettings(a[i].Pointer); return r; }
        public System.IntPtr ForwardSettingMap => AddrOf(0x28); // 
    }

    public class ShaderPlatformQualitySettings : Object
    {
        public const string UeClassName = "ShaderPlatformQualitySettings";
        public ShaderPlatformQualitySettings(System.IntPtr ptr) : base(ptr) {}
        public static new ShaderPlatformQualitySettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ShaderPlatformQualitySettings(p);
        public static ShaderPlatformQualitySettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ShaderPlatformQualitySettings(o.Pointer); }
        public static ShaderPlatformQualitySettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ShaderPlatformQualitySettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ShaderPlatformQualitySettings(a[i].Pointer); return r; }
        public System.IntPtr QualityOverrides => AddrOf(0x28); // [3] static array
    }

}
