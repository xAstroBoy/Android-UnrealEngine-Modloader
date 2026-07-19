// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Content_PlayingManual_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Content_PlayingManual_BP_C : UI_PauseMenu_Content_Trifold_Base_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Content_PlayingManual_BP_C";
        public UI_PauseMenu_Content_PlayingManual_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Content_PlayingManual_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_PauseMenu_Content_PlayingManual_BP_C(p);
        public static UI_PauseMenu_Content_PlayingManual_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Content_PlayingManual_BP_C(o.Pointer); }
        public static UI_PauseMenu_Content_PlayingManual_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Content_PlayingManual_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Content_PlayingManual_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x410));
        public string ActiveCategory => Native.GetPropName(Pointer, "ActiveCategory"); // FName
        public FName ActiveCategory_Raw { get => GetAt<FName>(0x418); set => SetAt(0x418, value); }
        public VR4GameInstance_BP_C GameInstnace { get { var __p = GetAt<System.IntPtr>(0x420); return __p==System.IntPtr.Zero?null:new VR4GameInstance_BP_C(__p); } set => SetAt(0x420, value?.Pointer ?? System.IntPtr.Zero); }
        public void ShouldPanelsStartOpen_(bool StartPanelsOpen)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(StartPanelsOpen?1:0));
            CallRaw("ShouldPanelsStartOpen?", __pb.Bytes);
        }
        public void BackToMain()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("BackToMain", __pb.Bytes);
        }
        public void CategorySelected(FName SelectedCategory)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, SelectedCategory);
            CallRaw("CategorySelected", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Content_PlayingManual_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Content_PlayingManual_BP", __pb.Bytes);
        }
    }

}
