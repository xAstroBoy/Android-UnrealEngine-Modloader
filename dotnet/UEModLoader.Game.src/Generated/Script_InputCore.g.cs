// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/InputCore
using System;

namespace UEModLoader.Game
{
    public enum ETouchIndex
    {
        Touch1 = 0,
        Touch2 = 1,
        Touch3 = 2,
        Touch4 = 3,
        Touch5 = 4,
        Touch6 = 5,
        Touch7 = 6,
        Touch8 = 7,
        Touch9 = 8,
        Touch10 = 9,
        CursorPointerIndex = 10,
        MAX_TOUCHES = 11,
    }

    public enum ETouchType
    {
        Began = 0,
        Moved = 1,
        Stationary = 2,
        ForceChanged = 3,
        FirstMove = 4,
        Ended = 5,
        NumTypes = 6,
    }

    public enum EConsoleForGamepadLabels
    {
        None = 0,
        XBoxOne = 1,
        PS4 = 2,
    }

    public enum EControllerHand
    {
        Left = 0,
        Right = 1,
        AnyHand = 2,
        Pad = 3,
        ExternalCamera = 4,
        Gun = 5,
        Special = 6,
        ControllerHand_Count = 17,
    }

    public class Key : StructProxy
    {
        public Key(global::System.IntPtr ptr) : base(ptr) {}
        public string KeyName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName KeyName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
    }

    public class InputCoreTypes : Object
    {
        public const string UeClassName = "InputCoreTypes";
        public InputCoreTypes(global::System.IntPtr ptr) : base(ptr) {}
        public static new InputCoreTypes FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InputCoreTypes(p);
        public static InputCoreTypes FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InputCoreTypes(o.Pointer); }
        public static InputCoreTypes[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InputCoreTypes[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InputCoreTypes(a[i].Pointer); return r; }
    }

}
