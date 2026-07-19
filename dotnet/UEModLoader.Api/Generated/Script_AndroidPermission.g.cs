// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/AndroidPermission
using System;

namespace UEModLoader.Game
{
    public class AndroidPermissionCallbackProxy : Object
    {
        public const string UeClassName = "AndroidPermissionCallbackProxy";
        public AndroidPermissionCallbackProxy(System.IntPtr ptr) : base(ptr) {}
        public static new AndroidPermissionCallbackProxy FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AndroidPermissionCallbackProxy(p);
        public static AndroidPermissionCallbackProxy FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AndroidPermissionCallbackProxy(o.Pointer); }
        public static AndroidPermissionCallbackProxy[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AndroidPermissionCallbackProxy[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AndroidPermissionCallbackProxy(a[i].Pointer); return r; }
        public System.IntPtr OnPermissionsGrantedDynamicDelegate => AddrOf(0x28); // 
    }

    public class AndroidPermissionFunctionLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "AndroidPermissionFunctionLibrary";
        public AndroidPermissionFunctionLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new AndroidPermissionFunctionLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new AndroidPermissionFunctionLibrary(p);
        public static AndroidPermissionFunctionLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AndroidPermissionFunctionLibrary(o.Pointer); }
        public static AndroidPermissionFunctionLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AndroidPermissionFunctionLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AndroidPermissionFunctionLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x5C2600C — hookable via Hooks.InstallAt(NativeFunc_CheckPermission).</summary>
        public static System.IntPtr NativeFunc_CheckPermission => Memory.ModuleBase() + 0x5C2600C;
        public bool CheckPermission(System.IntPtr permission)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, permission);
            CallRaw("CheckPermission", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5C25F18 — hookable via Hooks.InstallAt(NativeFunc_AcquirePermissions).</summary>
        public static System.IntPtr NativeFunc_AcquirePermissions => Memory.ModuleBase() + 0x5C25F18;
        public AndroidPermissionCallbackProxy AcquirePermissions(System.IntPtr Permissions)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Permissions);
            CallRaw("AcquirePermissions", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new AndroidPermissionCallbackProxy(__p); }
        }
    }

}
