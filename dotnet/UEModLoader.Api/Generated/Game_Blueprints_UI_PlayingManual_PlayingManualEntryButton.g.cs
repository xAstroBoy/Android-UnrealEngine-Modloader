// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualEntryButton
using System;

namespace UEModLoader.Game
{
    public class PlayingManualEntryButton_C : Actor
    {
        public const string UeClassName = "PlayingManualEntryButton_C";
        public PlayingManualEntryButton_C(System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualEntryButton_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PlayingManualEntryButton_C(p);
        public static PlayingManualEntryButton_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualEntryButton_C(o.Pointer); }
        public static PlayingManualEntryButton_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualEntryButton_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualEntryButton_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget_Button { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Button { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4UIButtonComponent ButtonButton { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public string EntryName => Native.GetPropName(Pointer, "EntryName"); // FName
        public FName EntryName_Raw { get => GetAt<FName>(0x248); set => SetAt(0x248, value); }
        public System.IntPtr PlayerManualEntryButtonClicked => AddrOf(0x250); // 
        public PlayingManualEntryButtonWidget_C EntryButtonWidget { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new PlayingManualEntryButtonWidget_C(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public bool UseMercColors { get => Native.GetPropBool(Pointer, "UseMercColors"); set => Native.SetPropBool(Pointer, "UseMercColors", value); }
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
        public void ButtonPressed(VR4UIComponent component, VR4UIClickState State)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, component);
            __pb.Set<System.IntPtr>(0x8, State);
            CallRaw("ButtonPressed", __pb.Bytes);
        }
        public void ButtonHovered(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("ButtonHovered", __pb.Bytes);
        }
        public void ButtonUnhovered(VR4UIComponent component)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, component);
            CallRaw("ButtonUnhovered", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualEntryButton(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualEntryButton", __pb.Bytes);
        }
        public void PlayerManualEntryButtonClicked__DelegateSignature(FName EntryName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, EntryName);
            CallRaw("PlayerManualEntryButtonClicked__DelegateSignature", __pb.Bytes);
        }
    }

}
