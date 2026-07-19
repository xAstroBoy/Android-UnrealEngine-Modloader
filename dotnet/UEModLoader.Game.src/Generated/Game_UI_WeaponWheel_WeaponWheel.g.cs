// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/WeaponWheel/WeaponWheel
using System;

namespace UEModLoader.Game
{
    public class WeaponWheel_C : Actor
    {
        public const string UeClassName = "WeaponWheel_C";
        public WeaponWheel_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new WeaponWheel_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new WeaponWheel_C(p);
        public static WeaponWheel_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new WeaponWheel_C(o.Pointer); }
        public static WeaponWheel_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new WeaponWheel_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new WeaponWheel_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Fill_Alpha_2C4E6E36427368A933649695647EAFC5 { get => GetAt<float>(0x238); set => SetAt(0x238, value); }
        public byte Timeline_Fill__Direction_2C4E6E36427368A933649695647EAFC5 { get => GetAt<byte>(0x23C); set => SetAt(0x23C, value); }
        public TimelineComponent Timeline_Fill { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_Scale_Alpha_FE59B18845187D2C79F330A86CDF4183 { get => GetAt<float>(0x248); set => SetAt(0x248, value); }
        public byte Timeline_Scale__Direction_FE59B18845187D2C79F330A86CDF4183 { get => GetAt<byte>(0x24C); set => SetAt(0x24C, value); }
        public TimelineComponent Timeline_Scale { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EItemId Slot0Item { get => (EItemId)GetAt<byte>(0x258); set => SetAt(0x258, (byte)value); }
        public EItemId Slot1Item { get => (EItemId)GetAt<byte>(0x259); set => SetAt(0x259, (byte)value); }
        public EItemId Slot2Item { get => (EItemId)GetAt<byte>(0x25A); set => SetAt(0x25A, (byte)value); }
        public EItemId Slot3Item { get => (EItemId)GetAt<byte>(0x25B); set => SetAt(0x25B, (byte)value); }
        public WeaponWheelWidget_C WheelWidget { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new WeaponWheelWidget_C(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool AllowSelection { get => Native.GetPropBool(Pointer, "AllowSelection"); set => Native.SetPropBool(Pointer, "AllowSelection", value); }
        public bool SelectionMade { get => Native.GetPropBool(Pointer, "SelectionMade"); set => Native.SetPropBool(Pointer, "SelectionMade", value); }
        public bool SlotPistolSelected { get => Native.GetPropBool(Pointer, "SlotPistolSelected"); set => Native.SetPropBool(Pointer, "SlotPistolSelected", value); }
        public bool SlotRifleSelected { get => Native.GetPropBool(Pointer, "SlotRifleSelected"); set => Native.SetPropBool(Pointer, "SlotRifleSelected", value); }
        public bool SlotGrenadeSelected { get => Native.GetPropBool(Pointer, "SlotGrenadeSelected"); set => Native.SetPropBool(Pointer, "SlotGrenadeSelected", value); }
        public bool SlotHealSelfSelected { get => Native.GetPropBool(Pointer, "SlotHealSelfSelected"); set => Native.SetPropBool(Pointer, "SlotHealSelfSelected", value); }
        public bool SlotPistolValid { get => Native.GetPropBool(Pointer, "SlotPistolValid"); set => Native.SetPropBool(Pointer, "SlotPistolValid", value); }
        public bool SlotRifleValid { get => Native.GetPropBool(Pointer, "SlotRifleValid"); set => Native.SetPropBool(Pointer, "SlotRifleValid", value); }
        public bool SlotGrenadeValid { get => Native.GetPropBool(Pointer, "SlotGrenadeValid"); set => Native.SetPropBool(Pointer, "SlotGrenadeValid", value); }
        public bool SlotHealSelfValid { get => Native.GetPropBool(Pointer, "SlotHealSelfValid"); set => Native.SetPropBool(Pointer, "SlotHealSelfValid", value); }
        public SoundBase Rollover { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4Bio4PlayerPawn_BP_C PlayerBP { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new VR4Bio4PlayerPawn_BP_C(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool AshleyCommandAvailable { get => Native.GetPropBool(Pointer, "AshleyCommandAvailable"); set => Native.SetPropBool(Pointer, "AshleyCommandAvailable", value); }
        public bool AshleyHealAvailable { get => Native.GetPropBool(Pointer, "AshleyHealAvailable"); set => Native.SetPropBool(Pointer, "AshleyHealAvailable", value); }
        public bool SlotToggleAshleySelected { get => Native.GetPropBool(Pointer, "SlotToggleAshleySelected"); set => Native.SetPropBool(Pointer, "SlotToggleAshleySelected", value); }
        public bool SlotHealAshleySelected { get => Native.GetPropBool(Pointer, "SlotHealAshleySelected"); set => Native.SetPropBool(Pointer, "SlotHealAshleySelected", value); }
        public LinearColor QuickSelectIconColor => new LinearColor(AddrOf(0x28C));
        public LinearColor QuickSelectIconColorSelected => new LinearColor(AddrOf(0x29C));
        public LinearColor QuickSelectBackgroundColor => new LinearColor(AddrOf(0x2AC));
        public LinearColor QuickSelectBackgroundColorSelected => new LinearColor(AddrOf(0x2BC));
        public LinearColor AshleyBackgroundColor => new LinearColor(AddrOf(0x2CC));
        public LinearColor AshleyBackgroundColorSelected => new LinearColor(AddrOf(0x2DC));
        public LinearColor FinalSelectionColor => new LinearColor(AddrOf(0x2EC));
        public int OldSelection { get => GetAt<int>(0x2FC); set => SetAt(0x2FC, value); }
        public InterpCurveFloat Curve => new InterpCurveFloat(AddrOf(0x300));
        public CurveFloat InputBiasL { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CurveFloat InputBiasR { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new CurveFloat(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool WheelTutorialActive { get => Native.GetPropBool(Pointer, "WheelTutorialActive"); set => Native.SetPropBool(Pointer, "WheelTutorialActive", value); }
        public bool ShowingCheck { get => Native.GetPropBool(Pointer, "ShowingCheck"); set => Native.SetPropBool(Pointer, "ShowingCheck", value); }
        public bool ShouldClose { get => Native.GetPropBool(Pointer, "ShouldClose"); set => Native.SetPropBool(Pointer, "ShouldClose", value); }
        public bool PistolTutorialActive { get => Native.GetPropBool(Pointer, "PistolTutorialActive"); set => Native.SetPropBool(Pointer, "PistolTutorialActive", value); }
        public bool StickActive { get => Native.GetPropBool(Pointer, "StickActive"); set => Native.SetPropBool(Pointer, "StickActive", value); }
        public global::System.IntPtr StickActiveChanged => AddrOf(0x330); // 
        public bool UseFill { get => Native.GetPropBool(Pointer, "UseFill"); set => Native.SetPropBool(Pointer, "UseFill", value); }
        public bool FillComplete { get => Native.GetPropBool(Pointer, "FillComplete"); set => Native.SetPropBool(Pointer, "FillComplete", value); }
        public global::System.IntPtr AshleyCommandMade => AddrOf(0x348); // 
        public bool ToggleAshleyTutorialActive { get => Native.GetPropBool(Pointer, "ToggleAshleyTutorialActive"); set => Native.SetPropBool(Pointer, "ToggleAshleyTutorialActive", value); }
        public bool HealAshleyTutorialActive { get => Native.GetPropBool(Pointer, "HealAshleyTutorialActive"); set => Native.SetPropBool(Pointer, "HealAshleyTutorialActive", value); }
        public void TryUseConsumable(bool targetSelf, EConsumableUseResult Result)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(targetSelf?1:0));
            __pb.Set<byte>(0x1, (byte)Result);
            CallRaw("TryUseConsumable", __pb.Bytes);
        }
        public void UpdateSlotDisplay(bool SelectionValid, float Direction)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)(SelectionValid?1:0));
            __pb.Set(0x4, Direction);
            CallRaw("UpdateSlotDisplay", __pb.Bytes);
        }
        public void PlaySelectionFX()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlaySelectionFX", __pb.Bytes);
        }
        public void HighlightSelection()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HighlightSelection", __pb.Bytes);
        }
        public void GetSlotData()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GetSlotData", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void Timeline_Scale__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Scale__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Scale__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Scale__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_Fill__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Fill__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Fill__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Fill__UpdateFunc", __pb.Bytes);
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
        public void ScaleUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ScaleUp", __pb.Bytes);
        }
        public void Scaledown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Scaledown", __pb.Bytes);
        }
        public void CloseWheel(bool FinalizeSelection)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(FinalizeSelection?1:0));
            CallRaw("CloseWheel", __pb.Bytes);
        }
        public void TrackLastSelection(int Selection)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Selection);
            CallRaw("TrackLastSelection", __pb.Bytes);
        }
        public void ShowTutorialCheckmark()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowTutorialCheckmark", __pb.Bytes);
        }
        public void StartFill()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartFill", __pb.Bytes);
        }
        public void StopFill()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopFill", __pb.Bytes);
        }
        public void ExecuteUbergraph_WeaponWheel(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_WeaponWheel", __pb.Bytes);
        }
        public void AshleyCommandMade__DelegateSignature(bool HealCommand)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(HealCommand?1:0));
            CallRaw("AshleyCommandMade__DelegateSignature", __pb.Bytes);
        }
        public void StickActiveChanged__DelegateSignature(bool StickActive)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(StickActive?1:0));
            CallRaw("StickActiveChanged__DelegateSignature", __pb.Bytes);
        }
    }

}
