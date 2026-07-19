// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Vignette/Vignette_QTE
using System;

namespace UEModLoader.Game
{
    public class Vignette_QTE_C : Vignette_Base_C
    {
        public const string UeClassName = "Vignette_QTE_C";
        public Vignette_QTE_C(System.IntPtr ptr) : base(ptr) {}
        public static new Vignette_QTE_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Vignette_QTE_C(p);
        public static Vignette_QTE_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Vignette_QTE_C(o.Pointer); }
        public static Vignette_QTE_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Vignette_QTE_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Vignette_QTE_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x318));
        public bool PausingForbidden { get => Native.GetPropBool(Pointer, "PausingForbidden"); set => Native.SetPropBool(Pointer, "PausingForbidden", value); }
        public VR4Bio4PlayerPawn_BP_C Bio4PawnBp { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new VR4Bio4PlayerPawn_BP_C(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public float InitialDelay { get => GetAt<float>(0x330); set => SetAt(0x330, value); }
        public SoundBase IntroSound { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public SoundBase OutroSound { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new SoundBase(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public bool FullyActivated { get => Native.GetPropBool(Pointer, "FullyActivated"); set => Native.SetPropBool(Pointer, "FullyActivated", value); }
        public bool HoldDestroy { get => Native.GetPropBool(Pointer, "HoldDestroy"); set => Native.SetPropBool(Pointer, "HoldDestroy", value); }
        public bool WaitForFullyActive { get => Native.GetPropBool(Pointer, "WaitForFullyActive"); set => Native.SetPropBool(Pointer, "WaitForFullyActive", value); }
        public void UnforbidPausing()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UnforbidPausing", __pb.Bytes);
        }
        public void ForbidPausing()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ForbidPausing", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void StartTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StartTutorial", __pb.Bytes);
        }
        public void StopTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopTutorial", __pb.Bytes);
        }
        public void OnFullyInactive_Event(VR4Vignette Vignette)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Vignette);
            CallRaw("OnFullyInactive_Event", __pb.Bytes);
        }
        public void TutorialExpired(VR4Vignette Vignette)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Vignette);
            CallRaw("TutorialExpired", __pb.Bytes);
        }
        public void DelayedUpdate(float Duration)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Duration);
            CallRaw("DelayedUpdate", __pb.Bytes);
        }
        public void FullyActive(VR4Vignette Vignette)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Vignette);
            CallRaw("FullyActive", __pb.Bytes);
        }
        public void FinishSetInacive()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FinishSetInacive", __pb.Bytes);
        }
        public void ExecuteUbergraph_Vignette_QTE(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Vignette_QTE", __pb.Bytes);
        }
    }

}
