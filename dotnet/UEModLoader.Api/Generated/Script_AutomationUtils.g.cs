// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AutomationUtils
using System;

namespace UEModLoader.Game
{
    public class AutomationUtilsBlueprintLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "AutomationUtilsBlueprintLibrary";
        public AutomationUtilsBlueprintLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new AutomationUtilsBlueprintLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AutomationUtilsBlueprintLibrary(p);
        public static AutomationUtilsBlueprintLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AutomationUtilsBlueprintLibrary(o.Pointer); }
        public static AutomationUtilsBlueprintLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AutomationUtilsBlueprintLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AutomationUtilsBlueprintLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x577385C — hookable via Hooks.InstallAt(NativeFunc_TakeGameplayAutomationScreenshot).</summary>
        public static System.IntPtr NativeFunc_TakeGameplayAutomationScreenshot => Memory.ModuleBase() + 0x577385C;
        public void TakeGameplayAutomationScreenshot(System.IntPtr ScreenshotName, float MaxGlobalError, float MaxLocalError, System.IntPtr MapNameOverride)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, ScreenshotName);
            __pb.Set(0x10, MaxGlobalError);
            __pb.Set(0x14, MaxLocalError);
            __pb.Set<System.IntPtr>(0x18, MapNameOverride);
            CallRaw("TakeGameplayAutomationScreenshot", __pb.Bytes);
        }
    }

}
