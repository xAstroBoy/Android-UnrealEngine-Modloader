// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Pause/VR4PausePlayerPawn_BP
using System;

namespace UEModLoader.Game
{
    public class VR4PausePlayerPawn_BP_C : VR4PausePlayerPawn
    {
        public const string UeClassName = "VR4PausePlayerPawn_BP_C";
        public VR4PausePlayerPawn_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4PausePlayerPawn_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4PausePlayerPawn_BP_C(p);
        public static VR4PausePlayerPawn_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4PausePlayerPawn_BP_C(o.Pointer); }
        public static VR4PausePlayerPawn_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4PausePlayerPawn_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4PausePlayerPawn_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x11C0));
        public SceneComponent AmmoRoot2 { get { var __p = GetAt<global::System.IntPtr>(0x11C8); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x11C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SkeletalMeshComponent Ammo2 { get { var __p = GetAt<global::System.IntPtr>(0x11D0); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x11D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent FakeGrenade { get { var __p = GetAt<global::System.IntPtr>(0x11D8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x11D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent grenade { get { var __p = GetAt<global::System.IntPtr>(0x11E0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x11E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Gun1 { get { var __p = GetAt<global::System.IntPtr>(0x11E8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x11E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent GunRoot { get { var __p = GetAt<global::System.IntPtr>(0x11F0); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x11F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Knife { get { var __p = GetAt<global::System.IntPtr>(0x11F8); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x11F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent KnifeRoot { get { var __p = GetAt<global::System.IntPtr>(0x1200); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1200, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SkeletalMeshComponent Ammo { get { var __p = GetAt<global::System.IntPtr>(0x1208); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x1208, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent AmmoRoot { get { var __p = GetAt<global::System.IntPtr>(0x1210); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1210, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent OffsetProps { get { var __p = GetAt<global::System.IntPtr>(0x1218); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x1218, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Fade_Alpha_6F63581F4FF347A1776E82944BAEA88C { get => GetAt<float>(0x1220); set => SetAt(0x1220, value); }
        public byte Fade__Direction_6F63581F4FF347A1776E82944BAEA88C { get => GetAt<byte>(0x1224); set => SetAt(0x1224, value); }
        public TimelineComponent Fade { get { var __p = GetAt<global::System.IntPtr>(0x1228); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x1228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float FadeDuration { get => GetAt<float>(0x1230); set => SetAt(0x1230, value); }
        public Actor watchActor { get { var __p = GetAt<global::System.IntPtr>(0x1238); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x1238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UObject Watch { get { var __p = GetAt<global::System.IntPtr>(0x1240); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x1240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr TutorialPerHandStateLH => AddrOf(0x1250); // struct VR4TutorialPlayerPawnPerHandState
        public global::System.IntPtr TutorialPerHandStateRH => AddrOf(0x1252); // struct VR4TutorialPlayerPawnPerHandState
        public TimerHandle PropTimerHandle => new TimerHandle(AddrOf(0x1258));
        public TArray<global::System.IntPtr> PropsDisplayed => new TArray<global::System.IntPtr>(AddrOf(0x1260)); // TArray<enum>
        public void IsHandVisibleForTutorial(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("IsHandVisibleForTutorial", __pb.Bytes);
        }
        public void GetForcePropVisibleForTutorial(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("GetForcePropVisibleForTutorial", __pb.Bytes);
        }
        public void CloseMap(EHandedness Hand)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Hand);
            CallRaw("CloseMap", __pb.Bytes);
        }
        public bool CalculatePropVisibility(EHandedness Handedness)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            CallRaw("CalculatePropVisibility", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        public bool CalculateMeshVisibility(EHandedness Handedness)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            CallRaw("CalculateMeshVisibility", __pb.Bytes);
            return __pb.Get<byte>(0x1) != 0;
        }
        public void GetForcePropVisibleForTutorialInternal(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("GetForcePropVisibleForTutorialInternal", __pb.Bytes);
        }
        public void SetForcePropVisibleForTutorialInternal(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("SetForcePropVisibleForTutorialInternal", __pb.Bytes);
        }
        public void IsHandVisibleForTutorialInternal(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("IsHandVisibleForTutorialInternal", __pb.Bytes);
        }
        public void SetHandVisibleForTutorialInternal(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("SetHandVisibleForTutorialInternal", __pb.Bytes);
        }
        public void SpawnWatch(VR4PlayerPawn Pawn, SkeletalMeshComponent Mesh, Actor Actor, UObject Interface)
        {
            var __pb = new ParamBuffer(40);
            __pb.SetObject(0x0, Pawn);
            __pb.SetObject(0x8, Mesh);
            __pb.SetObject(0x10, Actor);
            __pb.SetObject(0x18, Interface);
            CallRaw("SpawnWatch", __pb.Bytes);
        }
        public void DestroyUI()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DestroyUI", __pb.Bytes);
        }
        public void SpawnUI()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnUI", __pb.Bytes);
        }
        public void Fade__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Fade__FinishedFunc", __pb.Bytes);
        }
        public void Fade__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Fade__UpdateFunc", __pb.Bytes);
        }
        public void InpActEvt_Button_A_K2Node_InputActionEvent_1(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button A_K2Node_InputActionEvent_1", __pb.Bytes);
        }
        public void InpActEvt_Button_X_K2Node_InputActionEvent_0(global::System.IntPtr Key)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Key);
            CallRaw("InpActEvt_Button X_K2Node_InputActionEvent_0", __pb.Bytes);
        }
        public void SetHandVisibleForTutorial(EHandedness Handedness, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("SetHandVisibleForTutorial", __pb.Bytes);
        }
        public void SetForcePropVisibleForTutorial(EHandedness Handedness, bool ForceVisible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Handedness);
            __pb.Set<byte>(0x1, (byte)(ForceVisible?1:0));
            CallRaw("SetForcePropVisibleForTutorial", __pb.Bytes);
        }
        public void OnAnimationStateChanged(EVR4PauseAnimationState animState)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)animState);
            CallRaw("OnAnimationStateChanged", __pb.Bytes);
        }
        public void FadeOut()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeOut", __pb.Bytes);
        }
        public void FadeIn(float Delay)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Delay);
            CallRaw("FadeIn", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void PropSlotCleared(EPropSlot propSlot)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)propSlot);
            CallRaw("PropSlotCleared", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void OnHandsStateChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnHandsStateChanged", __pb.Bytes);
        }
        public void OnVisibilityChanged(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("OnVisibilityChanged", __pb.Bytes);
        }
        public void OnMeshVisibilityChanged(EHandedness Hand, bool Visible)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Hand);
            __pb.Set<byte>(0x1, (byte)(Visible?1:0));
            CallRaw("OnMeshVisibilityChanged", __pb.Bytes);
        }
        public void OnHolsterOffsetChange(VR4GamePlayerPropHolster Holster, EPropSlot propSlot)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Holster);
            __pb.Set<byte>(0x8, (byte)propSlot);
            CallRaw("OnHolsterOffsetChange", __pb.Bytes);
        }
        public void HideProps()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideProps", __pb.Bytes);
        }
        public void OnSeatedModeChanged()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnSeatedModeChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4PausePlayerPawn_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4PausePlayerPawn_BP", __pb.Bytes);
        }
    }

}
