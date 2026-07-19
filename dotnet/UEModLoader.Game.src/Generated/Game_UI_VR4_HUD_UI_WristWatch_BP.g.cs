// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/HUD/UI_WristWatch_BP
using System;

namespace UEModLoader.Game
{
    public class UI_WristWatch_BP_C : UI_WristWatch_Base_BP_C
    {
        public const string UeClassName = "UI_WristWatch_BP_C";
        public UI_WristWatch_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_WristWatch_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_WristWatch_BP_C(p);
        public static UI_WristWatch_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_WristWatch_BP_C(o.Pointer); }
        public static UI_WristWatch_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_WristWatch_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_WristWatch_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x240));
        public SceneComponent AshleyRoot { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent TickAnchor { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent HpPlane { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Watch_Display { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Face { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent TickAnchorAshley { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent HpPlaneAshley { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent TickAshley { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Tick { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int Health_Current { get => GetAt<int>(0x290); set => SetAt(0x290, value); }
        public int Health_CurrentMax { get => GetAt<int>(0x294); set => SetAt(0x294, value); }
        public int Health_TotalMax { get => GetAt<int>(0x298); set => SetAt(0x298, value); }
        public LinearColor Color_Health_Good => new LinearColor(AddrOf(0x29C));
        public LinearColor Color_Health_Caution => new LinearColor(AddrOf(0x2AC));
        public LinearColor Color_Health_Danger => new LinearColor(AddrOf(0x2BC));
        public int Health_CautionThreshold { get => GetAt<int>(0x2CC); set => SetAt(0x2CC, value); }
        public int Health_DangerThreshold { get => GetAt<int>(0x2D0); set => SetAt(0x2D0, value); }
        public UI_WristWatch_Face_Widget_C WatchWidget { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new UI_WristWatch_Face_Widget_C(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public byte HealthState_Current { get => GetAt<byte>(0x2E0); set => SetAt(0x2E0, value); }
        public EHandedness ActiveArm { get => (EHandedness)GetAt<byte>(0x2E1); set => SetAt(0x2E1, (byte)value); }
        public VR4PlayerHand HandLeft { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new VR4PlayerHand(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4PlayerHand HandRight { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new VR4PlayerHand(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4Bio4PlayerHand_Left_BP_C Bio4HandLeft { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new VR4Bio4PlayerHand_Left_BP_C(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4Bio4PlayerHand_Right_BP_C Bio4HandRight { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new VR4Bio4PlayerHand_Right_BP_C(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool NoGame { get => Native.GetPropBool(Pointer, "NoGame"); set => Native.SetPropBool(Pointer, "NoGame", value); }
        public MaterialInstanceDynamic HpMaterial { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool ForceUpdateState { get => Native.GetPropBool(Pointer, "ForceUpdateState"); set => Native.SetPropBool(Pointer, "ForceUpdateState", value); }
        public bool CinematicActive { get => Native.GetPropBool(Pointer, "CinematicActive"); set => Native.SetPropBool(Pointer, "CinematicActive", value); }
        public int Health_CautionThreshold_Ashley { get => GetAt<int>(0x31C); set => SetAt(0x31C, value); }
        public int Health_DangerThreshold_Ashley { get => GetAt<int>(0x320); set => SetAt(0x320, value); }
        public MaterialInstanceDynamic HpMaterialAshley { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int Health_CurrentAshley { get => GetAt<int>(0x330); set => SetAt(0x330, value); }
        public string LeftWristSocket => Native.GetPropName(Pointer, "LeftWristSocket"); // FName
        public FName LeftWristSocket_Raw { get => GetAt<FName>(0x334); set => SetAt(0x334, value); }
        public string RightWristSocket => Native.GetPropName(Pointer, "RightWristSocket"); // FName
        public FName RightWristSocket_Raw { get => GetAt<FName>(0x33C); set => SetAt(0x33C, value); }
        public void UpdateMercTime(global::System.IntPtr Min, global::System.IntPtr Sec, global::System.IntPtr Csec, bool isWarning)
        {
            var __pb = new ParamBuffer(73);
            __pb.Set<global::System.IntPtr>(0x0, Min);
            __pb.Set<global::System.IntPtr>(0x18, Sec);
            __pb.Set<global::System.IntPtr>(0x30, Csec);
            __pb.Set<byte>(0x48, (byte)(isWarning?1:0));
            CallRaw("UpdateMercTime", __pb.Bytes);
        }
        public void UpdateMercScore(int Score)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Score);
            CallRaw("UpdateMercScore", __pb.Bytes);
        }
        public void UpdateArm(EHandedness NewHand, bool Callback)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)NewHand);
            __pb.Set<byte>(0x1, (byte)(Callback?1:0));
            CallRaw("UpdateArm", __pb.Bytes);
        }
        public void GetHands(bool Valid)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Valid?1:0));
            CallRaw("GetHands", __pb.Bytes);
        }
        public void UpdateAmmo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateAmmo", __pb.Bytes);
        }
        public void AttachToArm(EHandedness arm)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)arm);
            CallRaw("AttachToArm", __pb.Bytes);
        }
        public void UpdateHP(int Health, int MaxHealth)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Health);
            __pb.Set(0x4, MaxHealth);
            CallRaw("UpdateHP", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void SetPulseEffect()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetPulseEffect", __pb.Bytes);
        }
        public void PollingLoop()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PollingLoop", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void CutsceneBegin(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("CutsceneBegin", __pb.Bytes);
        }
        public void CutsceneEnd(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("CutsceneEnd", __pb.Bytes);
        }
        public void CameraModeChanged(ECameraMode Mode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Mode);
            CallRaw("CameraModeChanged", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void PawnDestroyed(Actor DestroyedActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, DestroyedActor);
            CallRaw("PawnDestroyed", __pb.Bytes);
        }
        public void QuickAmmoUpdate(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("QuickAmmoUpdate", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_WristWatch_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_WristWatch_BP", __pb.Bytes);
        }
    }

}
