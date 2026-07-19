// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/ChapterSummary/UI_ChapterSummary_NextButton_BP
using System;

namespace UEModLoader.Game
{
    public class UI_ChapterSummary_NextButton_BP_C : UI_Button_BP_C
    {
        public const string UeClassName = "UI_ChapterSummary_NextButton_BP_C";
        public UI_ChapterSummary_NextButton_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_ChapterSummary_NextButton_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_ChapterSummary_NextButton_BP_C(p);
        public static UI_ChapterSummary_NextButton_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_ChapterSummary_NextButton_BP_C(o.Pointer); }
        public static UI_ChapterSummary_NextButton_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_ChapterSummary_NextButton_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_ChapterSummary_NextButton_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x308));
        public UI_ChapterSummary_Next_Button_Widget_C Ref_Next_Button_Widget { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new UI_ChapterSummary_Next_Button_Widget_C(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool IsMercenaries { get => Native.GetPropBool(Pointer, "IsMercenaries"); set => Native.SetPropBool(Pointer, "IsMercenaries", value); }
        public void SetAlpha(float alpha)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, alpha);
            CallRaw("SetAlpha", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_ChapterSummary_NextButton_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_ChapterSummary_NextButton_BP", __pb.Bytes);
        }
    }

}
