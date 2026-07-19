// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualInfoText
using System;

namespace UEModLoader.Game
{
    public class PlayingManualInfoText_C : VR4UIScreen
    {
        public const string UeClassName = "PlayingManualInfoText_C";
        public PlayingManualInfoText_C(System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualInfoText_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new PlayingManualInfoText_C(p);
        public static PlayingManualInfoText_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualInfoText_C(o.Pointer); }
        public static PlayingManualInfoText_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualInfoText_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualInfoText_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent Widget_InfoText { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Fade_Alpha_C4C5C8A04FC5FEC370F81E860A85969E { get => GetAt<float>(0x268); set => SetAt(0x268, value); }
        public byte Timeline_Fade__Direction_C4C5C8A04FC5FEC370F81E860A85969E { get => GetAt<byte>(0x26C); set => SetAt(0x26C, value); }
        public TimelineComponent Timeline_Fade { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public PlayingManualInfoTextWidget_C Info { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new PlayingManualInfoTextWidget_C(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr newText => AddrOf(0x280); // 
        public bool MercColors { get => Native.GetPropBool(Pointer, "MercColors"); set => Native.SetPropBool(Pointer, "MercColors", value); }
        public void ParseManualText(System.IntPtr Text, System.IntPtr ParsedText)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, Text);
            __pb.Set<System.IntPtr>(0x18, ParsedText);
            CallRaw("ParseManualText", __pb.Bytes);
        }
        public void Update_Info(FName Name)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Name);
            CallRaw("Update Info", __pb.Bytes);
        }
        public void Init()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Init", __pb.Bytes);
        }
        public void Timeline_Fade__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Fade__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Fade__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Fade__UpdateFunc", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void FadeOutText()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeOutText", __pb.Bytes);
        }
        public void FadeInText()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FadeInText", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualInfoText(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualInfoText", __pb.Bytes);
        }
    }

}
