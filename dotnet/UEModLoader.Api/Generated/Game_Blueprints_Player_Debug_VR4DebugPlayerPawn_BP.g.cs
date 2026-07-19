// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Debug/VR4DebugPlayerPawn_BP
using System;

namespace UEModLoader.Game
{
    public class VR4DebugPlayerPawn_BP_C : VR4DebugPlayerPawn
    {
        public const string UeClassName = "VR4DebugPlayerPawn_BP_C";
        public VR4DebugPlayerPawn_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4DebugPlayerPawn_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4DebugPlayerPawn_BP_C(p);
        public static VR4DebugPlayerPawn_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4DebugPlayerPawn_BP_C(o.Pointer); }
        public static VR4DebugPlayerPawn_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4DebugPlayerPawn_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4DebugPlayerPawn_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x570));
        public int TeleportCount { get => GetAt<int>(0x578); set => SetAt(0x578, value); }
        public bool APressed { get => Native.GetPropBool(Pointer, "APressed"); set => Native.SetPropBool(Pointer, "APressed", value); }
        public bool BPressed { get => Native.GetPropBool(Pointer, "BPressed"); set => Native.SetPropBool(Pointer, "BPressed", value); }
        public bool CanTeleport { get => Native.GetPropBool(Pointer, "CanTeleport"); set => Native.SetPropBool(Pointer, "CanTeleport", value); }
        public bool CanMove { get => Native.GetPropBool(Pointer, "CanMove"); set => Native.SetPropBool(Pointer, "CanMove", value); }
        public void GetTooltip(System.IntPtr Return)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Return);
            CallRaw("GetTooltip", __pb.Bytes);
        }
        public void UpdateMovement()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateMovement", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_4(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_4", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_3(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_3", __pb.Bytes);
        }
        public void InpActEvt_Button_B_K2Node_InputActionEvent_2(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button B_K2Node_InputActionEvent_2", __pb.Bytes);
        }
        public void InpActEvt_Button_B_K2Node_InputActionEvent_1(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button B_K2Node_InputActionEvent_1", __pb.Bytes);
        }
        public void InpActEvt__R__Thumbstick_Press_K2Node_InputActionEvent_0(Key Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Thumbstick Press_K2Node_InputActionEvent_0", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void PostBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PostBeginPlay", __pb.Bytes);
        }
        public void OnQuickTurnQueued()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnQuickTurnQueued", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4DebugPlayerPawn_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4DebugPlayerPawn_BP", __pb.Bytes);
        }
    }

}
