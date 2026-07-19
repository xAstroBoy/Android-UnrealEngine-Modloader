// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Cutscene/ButtonImage
using System;

namespace UEModLoader.Game
{
    public class ButtonImage_C : UserWidget
    {
        public const string UeClassName = "ButtonImage_C";
        public ButtonImage_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new ButtonImage_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ButtonImage_C(p);
        public static ButtonImage_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ButtonImage_C(o.Pointer); }
        public static ButtonImage_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ButtonImage_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ButtonImage_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation Flash { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation FillClear { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation Fill { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ButtonImage { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Ring { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public byte ButtonType { get => GetAt<byte>(0x260); set => SetAt(0x260, value); }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void SetButtonType(byte ButtonType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, ButtonType);
            CallRaw("SetButtonType", __pb.Bytes);
        }
        public void StartFill(float PlaybackSpeed)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, PlaybackSpeed);
            CallRaw("StartFill", __pb.Bytes);
        }
        public void StopFill()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopFill", __pb.Bytes);
        }
        public void ExecuteUbergraph_ButtonImage(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ButtonImage", __pb.Bytes);
        }
    }

}
