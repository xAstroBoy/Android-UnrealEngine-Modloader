// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Common/VR4PlayerController_BP
using System;

namespace UEModLoader.Game
{
    public class VR4PlayerController_BP_C : VR4PlayerController
    {
        public const string UeClassName = "VR4PlayerController_BP_C";
        public VR4PlayerController_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4PlayerController_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4PlayerController_BP_C(p);
        public static VR4PlayerController_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4PlayerController_BP_C(o.Pointer); }
        public static VR4PlayerController_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4PlayerController_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4PlayerController_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x5E8));
        public bool SlomoMode { get => Native.GetPropBool(Pointer, "SlomoMode"); set => Native.SetPropBool(Pointer, "SlomoMode", value); }
        public int SlomoSlowIndex { get => GetAt<int>(0x5F4); set => SetAt(0x5F4, value); }
        public TArray<global::System.IntPtr> SlomoOptionsSlow => new TArray<global::System.IntPtr>(AddrOf(0x5F8)); // TArray<float>
        public TArray<global::System.IntPtr> SlomoOptionsFast => new TArray<global::System.IntPtr>(AddrOf(0x608)); // TArray<float>
        public int SlomoFastIndex { get => GetAt<int>(0x618); set => SetAt(0x618, value); }
        public bool SlomoReset { get => Native.GetPropBool(Pointer, "SlomoReset"); set => Native.SetPropBool(Pointer, "SlomoReset", value); }
        public int MenuTaps { get => GetAt<int>(0x620); set => SetAt(0x620, value); }
        public int FrameStepCount { get => GetAt<int>(0x624); set => SetAt(0x624, value); }
        public int WorldScaleIndex { get => GetAt<int>(0x628); set => SetAt(0x628, value); }
        public TArray<global::System.IntPtr> WorldScaleOptions => new TArray<global::System.IntPtr>(AddrOf(0x630)); // TArray<float>
        public int MasterVolumeIndex { get => GetAt<int>(0x640); set => SetAt(0x640, value); }
        public bool isThumbRPressed { get => Native.GetPropBool(Pointer, "isThumbRPressed"); set => Native.SetPropBool(Pointer, "isThumbRPressed", value); }
        public bool EnableDebugMenuShortcutMode { get => Native.GetPropBool(Pointer, "EnableDebugMenuShortcutMode"); set => Native.SetPropBool(Pointer, "EnableDebugMenuShortcutMode", value); }
        public bool IgnoreNextSlomoText { get => Native.GetPropBool(Pointer, "IgnoreNextSlomoText"); set => Native.SetPropBool(Pointer, "IgnoreNextSlomoText", value); }
        public bool HideSpeedIndicator { get => Native.GetPropBool(Pointer, "HideSpeedIndicator"); set => Native.SetPropBool(Pointer, "HideSpeedIndicator", value); }
        public void WorldDilationChanged(float WorldTimeDilation, float PlayerTimeDilation, float CustomTimeDilation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, WorldTimeDilation);
            __pb.Set(0x4, PlayerTimeDilation);
            __pb.Set(0x8, CustomTimeDilation);
            CallRaw("WorldDilationChanged", __pb.Bytes);
        }
        public void UpdateMasterMix()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateMasterMix", __pb.Bytes);
        }
        public void SetMasterVolume(int VolumeIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, VolumeIndex);
            CallRaw("SetMasterVolume", __pb.Bytes);
        }
        public void IsSpecialDebugPawnActive(bool Return)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Return?1:0));
            CallRaw("IsSpecialDebugPawnActive", __pb.Bytes);
        }
        public void SetWorldScale(int WorldScaleIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, WorldScaleIndex);
            CallRaw("SetWorldScale", __pb.Bytes);
        }
        public void UpdateFrameStepText()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateFrameStepText", __pb.Bytes);
        }
        public void UpdateDebugControlsActive()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateDebugControlsActive", __pb.Bytes);
        }
        public void SlomoDecrement(int Index, global::System.IntPtr Array)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Index);
            __pb.Set<global::System.IntPtr>(0x8, Array);
            CallRaw("SlomoDecrement", __pb.Bytes);
        }
        public void SlomoIncrement(int Index, global::System.IntPtr Array)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, Index);
            __pb.Set<global::System.IntPtr>(0x8, Array);
            CallRaw("SlomoIncrement", __pb.Bytes);
        }
        public void Slomo(float Scale)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Scale);
            CallRaw("Slomo", __pb.Bytes);
        }
        public void InpActEvt__L__Thumbstick_Press_K2Node_InputActionEvent_2(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(L) Thumbstick Press_K2Node_InputActionEvent_2", __pb.Bytes);
        }
        public void InpActEvt__R__Thumbstick_Press_K2Node_InputActionEvent_1(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Thumbstick Press_K2Node_InputActionEvent_1", __pb.Bytes);
        }
        public void InpActEvt__R__Thumbstick_Press_K2Node_InputActionEvent_0(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_(R) Thumbstick Press_K2Node_InputActionEvent_0", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void UpdateSoundMixes()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateSoundMixes", __pb.Bytes);
        }
        public void KillSlomo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("KillSlomo", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_1_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_1_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_2_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_2_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_3_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_3_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_4_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_4_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_5_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_5_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void DebugMenuButtonPressed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DebugMenuButtonPressed", __pb.Bytes);
        }
        public void SlomoButtonPressed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlomoButtonPressed", __pb.Bytes);
        }
        public void SlomoButtonReleased()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlomoButtonReleased", __pb.Bytes);
        }
        public void SlomoResetButtonPressed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlomoResetButtonPressed", __pb.Bytes);
        }
        public void SlomoResetButtonReleased()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlomoResetButtonReleased", __pb.Bytes);
        }
        public void FrameSteppingButtonPressed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FrameSteppingButtonPressed", __pb.Bytes);
        }
        public void IncreaseSlomo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IncreaseSlomo", __pb.Bytes);
        }
        public void DecreaseSlomo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DecreaseSlomo", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_0_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_0_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_7_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_7_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_8_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_8_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_9_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_9_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_10_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_10_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_11_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_11_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_12_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_12_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_13_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_13_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__DebugInput_K2Node_ComponentBoundEvent_14_DebugKeyMulticastDelegate__DelegateSignature(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("BndEvt__DebugInput_K2Node_ComponentBoundEvent_14_DebugKeyMulticastDelegate__DelegateSignature", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4PlayerController_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4PlayerController_BP", __pb.Bytes);
        }
    }

}
