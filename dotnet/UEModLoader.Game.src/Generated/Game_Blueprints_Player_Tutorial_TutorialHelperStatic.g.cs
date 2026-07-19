// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/TutorialHelperStatic
using System;

namespace UEModLoader.Game
{
    public class TutorialHelperStatic_C : Actor
    {
        public const string UeClassName = "TutorialHelperStatic_C";
        public TutorialHelperStatic_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new TutorialHelperStatic_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TutorialHelperStatic_C(p);
        public static TutorialHelperStatic_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TutorialHelperStatic_C(o.Pointer); }
        public static TutorialHelperStatic_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TutorialHelperStatic_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TutorialHelperStatic_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string Tutorial => Native.GetPropName(Pointer, "Tutorial"); // FName
        public FName Tutorial_Raw { get => GetAt<FName>(0x230); set => SetAt(0x230, value); }
        public TimerHandle WaitTimer => new TimerHandle(AddrOf(0x238));
        public global::System.IntPtr LabelInfo => AddrOf(0x240); // struct TutorialEntry
        public bool PreviouslyCompleted { get => Native.GetPropBool(Pointer, "PreviouslyCompleted"); set => Native.SetPropBool(Pointer, "PreviouslyCompleted", value); }
        public Actor BindingActor { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float DisplayTimeLimit { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public global::System.IntPtr TimeLimitReached => AddrOf(0x2A8); // 
        public TArray<global::System.IntPtr> LabelList => new TArray<global::System.IntPtr>(AddrOf(0x2B8)); // TArray<UObject*>
        public TArray<global::System.IntPtr> Anchors => new TArray<global::System.IntPtr>(AddrOf(0x2C8)); // TArray<UObject*>
        public bool ForGroupLabel { get => Native.GetPropBool(Pointer, "ForGroupLabel"); set => Native.SetPropBool(Pointer, "ForGroupLabel", value); }
        public global::System.IntPtr LabelsDisplayed => AddrOf(0x2E0); // 
        public void TutorialComplete(bool Completed, bool instant)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(Completed?1:0));
            __pb.Set<byte>(0x1, (byte)(instant?1:0));
            CallRaw("TutorialComplete", __pb.Bytes);
        }
        public void SpawnTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnTutorial", __pb.Bytes);
        }
        public void GetDelay(float Delay)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Delay);
            CallRaw("GetDelay", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ShowTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowTutorial", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void BindingActorDestroyed(Actor DestroyedActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, DestroyedActor);
            CallRaw("BindingActorDestroyed", __pb.Bytes);
        }
        public void DisplayTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisplayTimerExpired", __pb.Bytes);
        }
        public void ExecuteUbergraph_TutorialHelperStatic(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_TutorialHelperStatic", __pb.Bytes);
        }
        public void LabelsDisplayed__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("LabelsDisplayed__DelegateSignature", __pb.Bytes);
        }
        public void TimeLimitReached__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TimeLimitReached__DelegateSignature", __pb.Bytes);
        }
    }

}
