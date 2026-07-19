// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Buttons/UI_Merchant_Message_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_Message_BP_C : UI_MerchantScreen_Button_BP_C
    {
        public const string UeClassName = "UI_Merchant_Message_BP_C";
        public UI_Merchant_Message_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_Message_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_Message_BP_C(p);
        public static UI_Merchant_Message_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_Message_BP_C(o.Pointer); }
        public static UI_Merchant_Message_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_Message_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_Message_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x310));
        public AudioComponent SFX_Pulse_Loop { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new AudioComponent(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent Button_Icon { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_Icon { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ScaleDownMessage_Width_2FF19618417A995BF008969E0958AC73 { get => GetAt<float>(0x330); set => SetAt(0x330, value); }
        public float Timeline_ScaleDownMessage_Height_2FF19618417A995BF008969E0958AC73 { get => GetAt<float>(0x334); set => SetAt(0x334, value); }
        public byte Timeline_ScaleDownMessage__Direction_2FF19618417A995BF008969E0958AC73 { get => GetAt<byte>(0x338); set => SetAt(0x338, value); }
        public TimelineComponent Timeline_ScaleDownMessage { get { var __p = GetAt<global::System.IntPtr>(0x340); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x340, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_ScaleUpMessage_Width_5F942F1C49846841D08662A71EEC6CA5 { get => GetAt<float>(0x348); set => SetAt(0x348, value); }
        public float Timeline_ScaleUpMessage_Height_5F942F1C49846841D08662A71EEC6CA5 { get => GetAt<float>(0x34C); set => SetAt(0x34C, value); }
        public byte Timeline_ScaleUpMessage__Direction_5F942F1C49846841D08662A71EEC6CA5 { get => GetAt<byte>(0x350); set => SetAt(0x350, value); }
        public TimelineComponent Timeline_ScaleUpMessage { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Message => AddrOf(0x360); // 
        public int TypingIndex { get => GetAt<int>(0x378); set => SetAt(0x378, value); }
        public bool Typing { get => Native.GetPropBool(Pointer, "Typing"); set => Native.SetPropBool(Pointer, "Typing", value); }
        public float TimeBetweenStrokes { get => GetAt<float>(0x380); set => SetAt(0x380, value); }
        public float TimeSinceLastStroke { get => GetAt<float>(0x384); set => SetAt(0x384, value); }
        public UI_Merchant_MessageIcon_Widget_C Ref_Icon_Widget { get { var __p = GetAt<global::System.IntPtr>(0x388); return __p==global::System.IntPtr.Zero?null:new UI_Merchant_MessageIcon_Widget_C(__p); } set => SetAt(0x388, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool MessageExpanded { get => Native.GetPropBool(Pointer, "MessageExpanded"); set => Native.SetPropBool(Pointer, "MessageExpanded", value); }
        public bool IsShowing { get => Native.GetPropBool(Pointer, "IsShowing"); set => Native.SetPropBool(Pointer, "IsShowing", value); }
        public UI_Merchant_Message_Widget_C Ref_Message_Widget { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new UI_Merchant_Message_Widget_C(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4MerchantQuestDialog QuestDialog => new VR4MerchantQuestDialog(AddrOf(0x3A0));
        public int QuestTextIndex { get => GetAt<int>(0x3B8); set => SetAt(0x3B8, value); }
        public global::System.IntPtr OnMessageRead => AddrOf(0x3C0); // 
        public bool ShowPulse { get => Native.GetPropBool(Pointer, "ShowPulse"); set => Native.SetPropBool(Pointer, "ShowPulse", value); }
        public void HideIcon(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("HideIcon", __pb.Bytes);
        }
        public void ShowIcon(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("ShowIcon", __pb.Bytes);
        }
        public void HandleOnClicked(UI_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Button);
            CallRaw("HandleOnClicked", __pb.Bytes);
        }
        public void ShowQuestDialog(global::System.IntPtr QuestDialog, bool OverrideRead)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<global::System.IntPtr>(0x0, QuestDialog);
            __pb.Set<byte>(0x18, (byte)(OverrideRead?1:0));
            CallRaw("ShowQuestDialog", __pb.Bytes);
        }
        public void ContractMessage(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("ContractMessage", __pb.Bytes);
        }
        public void ExpandMessage(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("ExpandMessage", __pb.Bytes);
        }
        public void HideMessage(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("HideMessage", __pb.Bytes);
        }
        public void ShowMessage(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("ShowMessage", __pb.Bytes);
        }
        public void Register(VR4UIScreen Screen)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Screen);
            CallRaw("Register", __pb.Bytes);
        }
        public void JumpToEndOfMessage()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("JumpToEndOfMessage", __pb.Bytes);
        }
        public void TypeOutMessage(global::System.IntPtr Message)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, Message);
            CallRaw("TypeOutMessage", __pb.Bytes);
        }
        public void Timeline_ScaleUpMessage__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleUpMessage__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ScaleUpMessage__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleUpMessage__UpdateFunc", __pb.Bytes);
        }
        public void Timeline_ScaleDownMessage__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleDownMessage__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_ScaleDownMessage__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_ScaleDownMessage__UpdateFunc", __pb.Bytes);
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
        public void BndEvt__Button_Icon_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature(VR4UIComponent component, global::System.IntPtr State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, State);
            CallRaw("BndEvt__Button_Icon_K2Node_ComponentBoundEvent_0_OnUIComponentClicked__DelegateSignature", __pb.Bytes);
        }
        public void ScaleUpMessage(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("ScaleUpMessage", __pb.Bytes);
        }
        public void ScaleDownMessage(bool SkipAnimation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SkipAnimation?1:0));
            CallRaw("ScaleDownMessage", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_Message_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_Message_BP", __pb.Bytes);
        }
        public void OnMessageRead__DelegateSignature(global::System.IntPtr QuestDialog)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, QuestDialog);
            CallRaw("OnMessageRead__DelegateSignature", __pb.Bytes);
        }
    }

}
