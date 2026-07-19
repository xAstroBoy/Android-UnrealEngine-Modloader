// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Pause/VR4PausePlayerHand_BP
using System;

namespace UEModLoader.Game
{
    public class VR4PausePlayerHand_BP_C : VR4PausePlayerHand
    {
        public const string UeClassName = "VR4PausePlayerHand_BP_C";
        public VR4PausePlayerHand_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4PausePlayerHand_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4PausePlayerHand_BP_C(p);
        public static VR4PausePlayerHand_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4PausePlayerHand_BP_C(o.Pointer); }
        public static VR4PausePlayerHand_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4PausePlayerHand_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4PausePlayerHand_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x5A0));
        public VR4DynamicHandPoseComponent AnimatedHandPose { get { var __p = GetAt<global::System.IntPtr>(0x5A8); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x5A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4DynamicHandPoseComponent StaticHandPose { get { var __p = GetAt<global::System.IntPtr>(0x5B0); return __p==global::System.IntPtr.Zero?null:new VR4DynamicHandPoseComponent(__p); } set => SetAt(0x5B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4PriorityListHandPoseSourceComponent MainHandPose { get { var __p = GetAt<global::System.IntPtr>(0x5B8); return __p==global::System.IntPtr.Zero?null:new VR4PriorityListHandPoseSourceComponent(__p); } set => SetAt(0x5B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4MenuHandPoseHelper_C HandPoseHelper { get { var __p = GetAt<global::System.IntPtr>(0x5C0); return __p==global::System.IntPtr.Zero?null:new VR4MenuHandPoseHelper_C(__p); } set => SetAt(0x5C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent ExamineWidget { get { var __p = GetAt<global::System.IntPtr>(0x5C8); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x5C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string FingerLaserSocketName => Native.GetPropName(Pointer, "FingerLaserSocketName"); // FName
        public FName FingerLaserSocketName_Raw { get => GetAt<FName>(0x5D0); set => SetAt(0x5D0, value); }
        public Inventory_ExamineWidget_C Ref_ExamineWidget { get { var __p = GetAt<global::System.IntPtr>(0x5D8); return __p==global::System.IntPtr.Zero?null:new Inventory_ExamineWidget_C(__p); } set => SetAt(0x5D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TimerHandle AutoInspectTimer => new TimerHandle(AddrOf(0x5E0));
        public TimerHandle ExaminePromptTimer => new TimerHandle(AddrOf(0x5E8));
        public bool ShouldShowExamine { get => Native.GetPropBool(Pointer, "ShouldShowExamine"); set => Native.SetPropBool(Pointer, "ShouldShowExamine", value); }
        public bool ItemGrabbed { get => Native.GetPropBool(Pointer, "ItemGrabbed"); set => Native.SetPropBool(Pointer, "ItemGrabbed", value); }
        public float ExaminePromptWaitTime { get => GetAt<float>(0x5F4); set => SetAt(0x5F4, value); }
        public float AutoExamineWaitTime { get => GetAt<float>(0x5F8); set => SetAt(0x5F8, value); }
        public void GetGripAxisValue(float Value)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Value);
            CallRaw("GetGripAxisValue", __pb.Bytes);
        }
        public void HideExamine()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideExamine", __pb.Bytes);
        }
        public void HideExaminePrompt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideExaminePrompt", __pb.Bytes);
        }
        public void ShowExamine()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowExamine", __pb.Bytes);
        }
        public void ShowExaminePrompt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowExaminePrompt", __pb.Bytes);
        }
        public void SetNullGripPressed(bool Pressed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pressed?1:0));
            CallRaw("SetNullGripPressed", __pb.Bytes);
        }
        public void InitHandPoses()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitHandPoses", __pb.Bytes);
        }
        public void InitLaserTransform()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitLaserTransform", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnItemGrabbed(AttacheItem_BP_C AttacheItem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, AttacheItem);
            CallRaw("OnItemGrabbed", __pb.Bytes);
        }
        public void OnItemReleased(bool ValidDrop)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(ValidDrop?1:0));
            CallRaw("OnItemReleased", __pb.Bytes);
        }
        public void ShowExamineWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowExamineWidget", __pb.Bytes);
        }
        public void HideExamineWidget()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideExamineWidget", __pb.Bytes);
        }
        public void PostTick(float DeltaTime)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaTime);
            CallRaw("PostTick", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void OnHandPointingStateChanged(EVR4MenuHandPointingState OldState, EVR4MenuHandPointingState NewState)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)OldState);
            __pb.Set<byte>(0x1, (byte)NewState);
            CallRaw("OnHandPointingStateChanged", __pb.Bytes);
        }
        public void OnUIObjectClicked(global::System.IntPtr Object)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Object);
            CallRaw("OnUIObjectClicked", __pb.Bytes);
        }
        public void OnItemIdGrabbed(int ItemId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ItemId);
            CallRaw("OnItemIdGrabbed", __pb.Bytes);
        }
        public void OnItemPreReleased()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnItemPreReleased", __pb.Bytes);
        }
        public void DisplayTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisplayTimerExpired", __pb.Bytes);
        }
        public void DisplayPromptExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisplayPromptExpired", __pb.Bytes);
        }
        public void PromptHidden()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PromptHidden", __pb.Bytes);
        }
        public void ExamineHidden()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ExamineHidden", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4PausePlayerHand_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4PausePlayerHand_BP", __pb.Bytes);
        }
    }

}
