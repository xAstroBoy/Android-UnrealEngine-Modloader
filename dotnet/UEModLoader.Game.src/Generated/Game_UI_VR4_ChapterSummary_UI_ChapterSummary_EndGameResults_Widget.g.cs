// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/ChapterSummary/UI_ChapterSummary_EndGameResults_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_ChapterSummary_EndGameResults_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_ChapterSummary_EndGameResults_Widget_C";
        public UI_ChapterSummary_EndGameResults_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_ChapterSummary_EndGameResults_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_ChapterSummary_EndGameResults_Widget_C(p);
        public static UI_ChapterSummary_EndGameResults_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_ChapterSummary_EndGameResults_Widget_C(o.Pointer); }
        public static UI_ChapterSummary_EndGameResults_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_ChapterSummary_EndGameResults_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_ChapterSummary_EndGameResults_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Overlay Bar_Died { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Bar_Heading { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Bar_HitRatio { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Bar_Killed { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Bar_Time { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_BG { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_Black { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_Blur { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_EndResults { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_EndResults_2 { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_EndResults_3 { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_EndResults_4 { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_EndResults_5 { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_Heading { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_HitRatioNotation { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_Label_ClearTime { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_Label_Died { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_Label_HitRatio { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_Label_Killed { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_Value_ClearTime { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_Value_Died { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_Value_HitRatio { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_EndResults_Value_Killed { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x2F0); // struct UI_WidgetColors_Struct
        public void PulseAnimation()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PulseAnimation", __pb.Bytes);
        }
        public void SetBlurOpacity(float Blur)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Blur);
            CallRaw("SetBlurOpacity", __pb.Bytes);
        }
        public void SetCoverOpacity(float alpha)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, alpha);
            CallRaw("SetCoverOpacity", __pb.Bytes);
        }
        public void SetBGImage(Texture2D Image, Texture2D BlurredImage)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Image);
            __pb.SetObject(0x8, BlurredImage);
            CallRaw("SetBGImage", __pb.Bytes);
        }
        public void SetBoxOpacity(float alpha)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, alpha);
            CallRaw("SetBoxOpacity", __pb.Bytes);
        }
        public void SetResultsValues(global::System.IntPtr HitRatio, global::System.IntPtr KilledNumber, global::System.IntPtr DiedNumber, global::System.IntPtr ClearTime)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<global::System.IntPtr>(0x0, HitRatio);
            __pb.Set<global::System.IntPtr>(0x18, KilledNumber);
            __pb.Set<global::System.IntPtr>(0x30, DiedNumber);
            __pb.Set<global::System.IntPtr>(0x48, ClearTime);
            CallRaw("SetResultsValues", __pb.Bytes);
        }
        public void SetTextAlphas(float Group1Alpha, float Group2Alpha, float Group3Alpha, float Group4Alpha, float Group5Alpha)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set(0x0, Group1Alpha);
            __pb.Set(0x4, Group2Alpha);
            __pb.Set(0x8, Group3Alpha);
            __pb.Set(0xC, Group4Alpha);
            __pb.Set(0x10, Group5Alpha);
            CallRaw("SetTextAlphas", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_ChapterSummary_EndGameResults_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_ChapterSummary_EndGameResults_Widget", __pb.Bytes);
        }
    }

}
