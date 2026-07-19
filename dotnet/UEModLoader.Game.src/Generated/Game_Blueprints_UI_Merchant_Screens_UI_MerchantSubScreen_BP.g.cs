// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Screens/UI_MerchantSubScreen_BP
using System;

namespace UEModLoader.Game
{
    public class UI_MerchantSubScreen_BP_C : VR4PauseUIScreen
    {
        public const string UeClassName = "UI_MerchantSubScreen_BP_C";
        public UI_MerchantSubScreen_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_MerchantSubScreen_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_MerchantSubScreen_BP_C(p);
        public static UI_MerchantSubScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MerchantSubScreen_BP_C(o.Pointer); }
        public static UI_MerchantSubScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MerchantSubScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MerchantSubScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public UI_MerchantScreen_BP_C MerchantScreen { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new UI_MerchantScreen_BP_C(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool Enabled { get => Native.GetPropBool(Pointer, "Enabled"); set => Native.SetPropBool(Pointer, "Enabled", value); }
        public bool IsVisible { get => Native.GetPropBool(Pointer, "IsVisible"); set => Native.SetPropBool(Pointer, "IsVisible", value); }
        public bool IsAnimating { get => Native.GetPropBool(Pointer, "IsAnimating"); set => Native.SetPropBool(Pointer, "IsAnimating", value); }
        public bool DesiredVisibility { get => Native.GetPropBool(Pointer, "DesiredVisibility"); set => Native.SetPropBool(Pointer, "DesiredVisibility", value); }
        public global::System.IntPtr OnEnabledChanged => AddrOf(0x278); // 
        public TArray<global::System.IntPtr> Buttons => new TArray<global::System.IntPtr>(AddrOf(0x288)); // TArray<UObject*>
        public global::System.IntPtr OnAnimationDone => AddrOf(0x298); // 
        public TArray<global::System.IntPtr> ExtraButtons => new TArray<global::System.IntPtr>(AddrOf(0x2A8)); // TArray<UObject*>
        public void IsScreenAnimating(bool Animating)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Animating?1:0));
            CallRaw("IsScreenAnimating", __pb.Bytes);
        }
        public void SetAnimating(bool Animating)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Animating?1:0));
            CallRaw("SetAnimating", __pb.Bytes);
        }
        public void SetEnabled(bool NewEnabled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(NewEnabled?1:0));
            CallRaw("SetEnabled", __pb.Bytes);
        }
        public void UpdateDesiredVisibility()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateDesiredVisibility", __pb.Bytes);
        }
        public void DoHide()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DoHide", __pb.Bytes);
        }
        public void DoShow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DoShow", __pb.Bytes);
        }
        public void BindToButtonOnToggle(ChildActorComponent component, global::System.IntPtr Event)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, Event);
            CallRaw("BindToButtonOnToggle", __pb.Bytes);
        }
        public void BindToButtonOnUnhover(ChildActorComponent component, global::System.IntPtr Event)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, Event);
            CallRaw("BindToButtonOnUnhover", __pb.Bytes);
        }
        public void BindToButtonOnHover(ChildActorComponent component, global::System.IntPtr Event)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, Event);
            CallRaw("BindToButtonOnHover", __pb.Bytes);
        }
        public void BindToButtonOnClick(ChildActorComponent component, global::System.IntPtr Event)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, component);
            __pb.Set<global::System.IntPtr>(0x8, Event);
            CallRaw("BindToButtonOnClick", __pb.Bytes);
        }
        public void GetMerchantButton(ChildActorComponent component, UI_MerchantScreen_Button_BP_C Button)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, Button);
            CallRaw("GetMerchantButton", __pb.Bytes);
        }
        public void OnHideDone()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnHideDone", __pb.Bytes);
        }
        public void HandleOnHide()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandleOnHide", __pb.Bytes);
        }
        public void OnShowDone()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnShowDone", __pb.Bytes);
        }
        public void HandleOnShow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HandleOnShow", __pb.Bytes);
        }
        public void ShouldDisplay(EVR4MerchantScreenStates State, bool ShouldDisplay)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)State);
            __pb.Set<byte>(0x1, (byte)(ShouldDisplay?1:0));
            CallRaw("ShouldDisplay", __pb.Bytes);
        }
        public void HandleOnExitState(EVR4MerchantScreenStates State, EVR4MerchantScreenStates NextState)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)State);
            __pb.Set<byte>(0x1, (byte)NextState);
            CallRaw("HandleOnExitState", __pb.Bytes);
        }
        public void HandleOnEnterState(EVR4MerchantScreenStates previousState, EVR4MerchantScreenStates State)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)previousState);
            __pb.Set<byte>(0x1, (byte)State);
            CallRaw("HandleOnEnterState", __pb.Bytes);
        }
        public void Initialize()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MerchantSubScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MerchantSubScreen_BP", __pb.Bytes);
        }
        public void OnAnimationDone__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnAnimationDone__DelegateSignature", __pb.Bytes);
        }
        public void OnEnabledChanged__DelegateSignature(bool Pushed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Pushed?1:0));
            CallRaw("OnEnabledChanged__DelegateSignature", __pb.Bytes);
        }
    }

}
