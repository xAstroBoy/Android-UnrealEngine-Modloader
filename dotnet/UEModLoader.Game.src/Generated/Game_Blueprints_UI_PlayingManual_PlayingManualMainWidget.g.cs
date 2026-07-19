// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PlayingManual/PlayingManualMainWidget
using System;

namespace UEModLoader.Game
{
    public class PlayingManualMainWidget_C : UserWidget
    {
        public const string UeClassName = "PlayingManualMainWidget_C";
        public PlayingManualMainWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new PlayingManualMainWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PlayingManualMainWidget_C(p);
        public static PlayingManualMainWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PlayingManualMainWidget_C(o.Pointer); }
        public static PlayingManualMainWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PlayingManualMainWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PlayingManualMainWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox CategoryBox { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_2 { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_3 { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_4 { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_5 { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_6 { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_7 { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_8 { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_9 { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_10 { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_11 { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_12 { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_13 { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_14 { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_15 { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_16 { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_17 { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_18 { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_19 { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_20 { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_21 { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_22 { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_23 { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_24 { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_25 { get { var __p = GetAt<global::System.IntPtr>(0x308); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x308, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_26 { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_27 { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_28 { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_29 { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_30 { get { var __p = GetAt<global::System.IntPtr>(0x330); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x330, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_31 { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_32 { get { var __p = GetAt<global::System.IntPtr>(0x340); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x340, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_33 { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_34 { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_35 { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_36 { get { var __p = GetAt<global::System.IntPtr>(0x360); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x360, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_37 { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_38 { get { var __p = GetAt<global::System.IntPtr>(0x370); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x370, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_39 { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_40 { get { var __p = GetAt<global::System.IntPtr>(0x380); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x380, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_41 { get { var __p = GetAt<global::System.IntPtr>(0x388); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x388, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_42 { get { var __p = GetAt<global::System.IntPtr>(0x390); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x390, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_43 { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_44 { get { var __p = GetAt<global::System.IntPtr>(0x3A0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_45 { get { var __p = GetAt<global::System.IntPtr>(0x3A8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_46 { get { var __p = GetAt<global::System.IntPtr>(0x3B0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_47 { get { var __p = GetAt<global::System.IntPtr>(0x3B8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_48 { get { var __p = GetAt<global::System.IntPtr>(0x3C0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_49 { get { var __p = GetAt<global::System.IntPtr>(0x3C8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_50 { get { var __p = GetAt<global::System.IntPtr>(0x3D0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_51 { get { var __p = GetAt<global::System.IntPtr>(0x3D8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_52 { get { var __p = GetAt<global::System.IntPtr>(0x3E0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_53 { get { var __p = GetAt<global::System.IntPtr>(0x3E8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_54 { get { var __p = GetAt<global::System.IntPtr>(0x3F0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_55 { get { var __p = GetAt<global::System.IntPtr>(0x3F8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x3F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_56 { get { var __p = GetAt<global::System.IntPtr>(0x400); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x400, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_57 { get { var __p = GetAt<global::System.IntPtr>(0x408); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x408, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_58 { get { var __p = GetAt<global::System.IntPtr>(0x410); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x410, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_59 { get { var __p = GetAt<global::System.IntPtr>(0x418); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x418, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_ImageOnly { get { var __p = GetAt<global::System.IntPtr>(0x420); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x420, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_LeaderboardsBG { get { var __p = GetAt<global::System.IntPtr>(0x428); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x428, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_MercHudBG { get { var __p = GetAt<global::System.IntPtr>(0x430); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x430, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox ImageCaption { get { var __p = GetAt<global::System.IntPtr>(0x438); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x438, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox ImageCaption_2 { get { var __p = GetAt<global::System.IntPtr>(0x440); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x440, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox ImageCaption_3 { get { var __p = GetAt<global::System.IntPtr>(0x448); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x448, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Images4L_Callout_AshleyHelath { get { var __p = GetAt<global::System.IntPtr>(0x450); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x450, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Images4L_Callout_L0 { get { var __p = GetAt<global::System.IntPtr>(0x458); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x458, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Images4L_Callout_L1 { get { var __p = GetAt<global::System.IntPtr>(0x460); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x460, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Images4L_Callout_L2 { get { var __p = GetAt<global::System.IntPtr>(0x468); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x468, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Images4L_Callout_R0 { get { var __p = GetAt<global::System.IntPtr>(0x470); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x470, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Images4L_Callout_R2 { get { var __p = GetAt<global::System.IntPtr>(0x478); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x478, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Images4L_Image0 { get { var __p = GetAt<global::System.IntPtr>(0x480); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x480, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Images4L_Image1 { get { var __p = GetAt<global::System.IntPtr>(0x488); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x488, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Images4L_Image2 { get { var __p = GetAt<global::System.IntPtr>(0x490); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x490, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Images4L_Main { get { var __p = GetAt<global::System.IntPtr>(0x498); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x498, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Images4L_Text0 { get { var __p = GetAt<global::System.IntPtr>(0x4A0); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x4A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Images4L_Text1 { get { var __p = GetAt<global::System.IntPtr>(0x4A8); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x4A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Images4L_Text2 { get { var __p = GetAt<global::System.IntPtr>(0x4B0); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x4B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Images4L_Text_Main { get { var __p = GetAt<global::System.IntPtr>(0x4B8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x4B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesLImage0 { get { var __p = GetAt<global::System.IntPtr>(0x4C0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x4C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesLImage1 { get { var __p = GetAt<global::System.IntPtr>(0x4C8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x4C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesLImage2 { get { var __p = GetAt<global::System.IntPtr>(0x4D0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x4D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock ImagesLText0 { get { var __p = GetAt<global::System.IntPtr>(0x4D8); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x4D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock ImagesLText1 { get { var __p = GetAt<global::System.IntPtr>(0x4E0); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x4E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ImagesLText2 { get { var __p = GetAt<global::System.IntPtr>(0x4E8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x4E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesRImage0 { get { var __p = GetAt<global::System.IntPtr>(0x4F0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x4F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesRImage0_2 { get { var __p = GetAt<global::System.IntPtr>(0x4F8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x4F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesRImage0_3 { get { var __p = GetAt<global::System.IntPtr>(0x500); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x500, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesRImage0_4 { get { var __p = GetAt<global::System.IntPtr>(0x508); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x508, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesRImage0_5 { get { var __p = GetAt<global::System.IntPtr>(0x510); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x510, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesRImage1 { get { var __p = GetAt<global::System.IntPtr>(0x518); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x518, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesRImage1_2 { get { var __p = GetAt<global::System.IntPtr>(0x520); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x520, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesRImage2 { get { var __p = GetAt<global::System.IntPtr>(0x528); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x528, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image ImagesRImage2_2 { get { var __p = GetAt<global::System.IntPtr>(0x530); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x530, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock ImagesRText0 { get { var __p = GetAt<global::System.IntPtr>(0x538); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x538, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock ImagesRText1 { get { var __p = GetAt<global::System.IntPtr>(0x540); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x540, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ImagesRText2 { get { var __p = GetAt<global::System.IntPtr>(0x548); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x548, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MercImage0 { get { var __p = GetAt<global::System.IntPtr>(0x550); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x550, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MercImage1 { get { var __p = GetAt<global::System.IntPtr>(0x558); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x558, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock MercText0 { get { var __p = GetAt<global::System.IntPtr>(0x560); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x560, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock MercText1 { get { var __p = GetAt<global::System.IntPtr>(0x568); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x568, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock MercText2 { get { var __p = GetAt<global::System.IntPtr>(0x570); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x570, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieCover { get { var __p = GetAt<global::System.IntPtr>(0x578); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x578, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieCover_QuickSelect { get { var __p = GetAt<global::System.IntPtr>(0x580); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x580, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieCover_SpecialTuneUp { get { var __p = GetAt<global::System.IntPtr>(0x588); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x588, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieCover_V1I { get { var __p = GetAt<global::System.IntPtr>(0x590); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x590, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieCoverL { get { var __p = GetAt<global::System.IntPtr>(0x598); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x598, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieCoverL_Alt { get { var __p = GetAt<global::System.IntPtr>(0x5A0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieCoverMerc { get { var __p = GetAt<global::System.IntPtr>(0x5A8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieCoverSpecialCombine { get { var __p = GetAt<global::System.IntPtr>(0x5B0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieTexture { get { var __p = GetAt<global::System.IntPtr>(0x5B8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieTexture_QuickSelect { get { var __p = GetAt<global::System.IntPtr>(0x5C0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieTexture_SpecialTuneUp { get { var __p = GetAt<global::System.IntPtr>(0x5C8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieTexture_V1I { get { var __p = GetAt<global::System.IntPtr>(0x5D0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieTextureL { get { var __p = GetAt<global::System.IntPtr>(0x5D8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieTextureL_Alt { get { var __p = GetAt<global::System.IntPtr>(0x5E0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieTextureMerc { get { var __p = GetAt<global::System.IntPtr>(0x5E8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image MovieTextureSpecialCombine { get { var __p = GetAt<global::System.IntPtr>(0x5F0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x5F8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x5F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_2 { get { var __p = GetAt<global::System.IntPtr>(0x600); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x600, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_3 { get { var __p = GetAt<global::System.IntPtr>(0x608); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x608, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_4 { get { var __p = GetAt<global::System.IntPtr>(0x610); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x610, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_5 { get { var __p = GetAt<global::System.IntPtr>(0x618); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x618, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_6 { get { var __p = GetAt<global::System.IntPtr>(0x620); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x620, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_7 { get { var __p = GetAt<global::System.IntPtr>(0x628); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x628, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_8 { get { var __p = GetAt<global::System.IntPtr>(0x630); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x630, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_9 { get { var __p = GetAt<global::System.IntPtr>(0x638); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x638, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_10 { get { var __p = GetAt<global::System.IntPtr>(0x640); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x640, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_11 { get { var __p = GetAt<global::System.IntPtr>(0x648); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x648, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_12 { get { var __p = GetAt<global::System.IntPtr>(0x650); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x650, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_13 { get { var __p = GetAt<global::System.IntPtr>(0x658); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x658, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_14 { get { var __p = GetAt<global::System.IntPtr>(0x660); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x660, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_15 { get { var __p = GetAt<global::System.IntPtr>(0x668); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x668, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_16 { get { var __p = GetAt<global::System.IntPtr>(0x670); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x670, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_17 { get { var __p = GetAt<global::System.IntPtr>(0x678); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x678, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_18 { get { var __p = GetAt<global::System.IntPtr>(0x680); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x680, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_19 { get { var __p = GetAt<global::System.IntPtr>(0x688); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x688, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_20 { get { var __p = GetAt<global::System.IntPtr>(0x690); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x690, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_21 { get { var __p = GetAt<global::System.IntPtr>(0x698); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x698, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_22 { get { var __p = GetAt<global::System.IntPtr>(0x6A0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x6A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_23 { get { var __p = GetAt<global::System.IntPtr>(0x6A8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x6A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_24 { get { var __p = GetAt<global::System.IntPtr>(0x6B0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x6B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay OverlayTemplateGroup { get { var __p = GetAt<global::System.IntPtr>(0x6B8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x6B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Quick_Image0 { get { var __p = GetAt<global::System.IntPtr>(0x6C0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x6C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Quick_Image1 { get { var __p = GetAt<global::System.IntPtr>(0x6C8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x6C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Quick_Text_Consumable { get { var __p = GetAt<global::System.IntPtr>(0x6D0); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x6D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Quick_Text_Grenade { get { var __p = GetAt<global::System.IntPtr>(0x6D8); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x6D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Quick_Text_OneHand { get { var __p = GetAt<global::System.IntPtr>(0x6E0); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x6E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Quick_Text_Stick { get { var __p = GetAt<global::System.IntPtr>(0x6E8); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x6E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Quick_Text_Trigger { get { var __p = GetAt<global::System.IntPtr>(0x6F0); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x6F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Quick_Text_TwoHand { get { var __p = GetAt<global::System.IntPtr>(0x6F8); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x6F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox QuickSelectCaption { get { var __p = GetAt<global::System.IntPtr>(0x700); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x700, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock QuickSelectTextCaption { get { var __p = GetAt<global::System.IntPtr>(0x708); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x708, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_AshleyHealth { get { var __p = GetAt<global::System.IntPtr>(0x710); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x710, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_AButton { get { var __p = GetAt<global::System.IntPtr>(0x718); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x718, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_BButton { get { var __p = GetAt<global::System.IntPtr>(0x720); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x720, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_LGrip { get { var __p = GetAt<global::System.IntPtr>(0x728); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x728, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_LStick { get { var __p = GetAt<global::System.IntPtr>(0x730); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x730, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_Menu { get { var __p = GetAt<global::System.IntPtr>(0x738); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x738, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_Oculus { get { var __p = GetAt<global::System.IntPtr>(0x740); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x740, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_RGrip { get { var __p = GetAt<global::System.IntPtr>(0x748); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x748, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_RStick { get { var __p = GetAt<global::System.IntPtr>(0x750); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x750, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_TriggerL { get { var __p = GetAt<global::System.IntPtr>(0x758); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x758, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_TriggerR { get { var __p = GetAt<global::System.IntPtr>(0x760); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x760, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_XButton { get { var __p = GetAt<global::System.IntPtr>(0x768); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x768, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Controller_YButton { get { var __p = GetAt<global::System.IntPtr>(0x770); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x770, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Costume { get { var __p = GetAt<global::System.IntPtr>(0x778); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x778, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_Inventory { get { var __p = GetAt<global::System.IntPtr>(0x780); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x780, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_MercHud_BonusTime { get { var __p = GetAt<global::System.IntPtr>(0x788); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x788, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_MercHud_Combo { get { var __p = GetAt<global::System.IntPtr>(0x790); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x790, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_MercHud_Score { get { var __p = GetAt<global::System.IntPtr>(0x798); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x798, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBox_MercHud_Time { get { var __p = GetAt<global::System.IntPtr>(0x7A0); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x7A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBoxLeaderboardClassic { get { var __p = GetAt<global::System.IntPtr>(0x7A8); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x7A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBoxLeaderboardFilterWorld { get { var __p = GetAt<global::System.IntPtr>(0x7B0); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x7B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBoxLeaderboardFocus { get { var __p = GetAt<global::System.IntPtr>(0x7B8); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x7B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBoxLeaderboardGameMode { get { var __p = GetAt<global::System.IntPtr>(0x7C0); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x7C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SizeBoxLeaderboardStats { get { var __p = GetAt<global::System.IntPtr>(0x7C8); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x7C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SpecialCombine_TextBottom { get { var __p = GetAt<global::System.IntPtr>(0x7D0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x7D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SpecialCombine_TextMiddle { get { var __p = GetAt<global::System.IntPtr>(0x7D8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x7D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SpecialCombine_TextTop { get { var __p = GetAt<global::System.IntPtr>(0x7E0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x7E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SpecialCombineCaption { get { var __p = GetAt<global::System.IntPtr>(0x7E8); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x7E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image SpecialCombineImage0 { get { var __p = GetAt<global::System.IntPtr>(0x7F0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x7F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image SpecialCombineImage1 { get { var __p = GetAt<global::System.IntPtr>(0x7F8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x7F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock SpecialCombineText0 { get { var __p = GetAt<global::System.IntPtr>(0x800); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x800, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock SpecialCombineText1 { get { var __p = GetAt<global::System.IntPtr>(0x808); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x808, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SpecialCombineTextCaption { get { var __p = GetAt<global::System.IntPtr>(0x810); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x810, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SpecialTuneUp_CaptionText { get { var __p = GetAt<global::System.IntPtr>(0x818); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x818, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image SpecialTuneUp_Image { get { var __p = GetAt<global::System.IntPtr>(0x820); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x820, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SpecialTuneUp_TextBottom { get { var __p = GetAt<global::System.IntPtr>(0x828); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x828, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock SpecialTuneUp_TextMain { get { var __p = GetAt<global::System.IntPtr>(0x830); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x830, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SpecialTuneUp_TextMiddle { get { var __p = GetAt<global::System.IntPtr>(0x838); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x838, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock SpecialTuneUp_TextTop { get { var __p = GetAt<global::System.IntPtr>(0x840); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x840, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox SpecialTuneUpCaption { get { var __p = GetAt<global::System.IntPtr>(0x848); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x848, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image TemplateFade { get { var __p = GetAt<global::System.IntPtr>(0x850); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x850, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextButtonA { get { var __p = GetAt<global::System.IntPtr>(0x858); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x858, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextButtonB { get { var __p = GetAt<global::System.IntPtr>(0x860); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x860, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextButtonMenu { get { var __p = GetAt<global::System.IntPtr>(0x868); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x868, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextButtonX { get { var __p = GetAt<global::System.IntPtr>(0x870); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x870, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextButtonY { get { var __p = GetAt<global::System.IntPtr>(0x878); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x878, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextCategory { get { var __p = GetAt<global::System.IntPtr>(0x880); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x880, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextGripL { get { var __p = GetAt<global::System.IntPtr>(0x888); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x888, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextGripR { get { var __p = GetAt<global::System.IntPtr>(0x890); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x890, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextHandedness { get { var __p = GetAt<global::System.IntPtr>(0x898); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x898, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextLeaderboardClassic { get { var __p = GetAt<global::System.IntPtr>(0x8A0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextLeaderboardFocus { get { var __p = GetAt<global::System.IntPtr>(0x8A8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextLeaderboardsFilter { get { var __p = GetAt<global::System.IntPtr>(0x8B0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextLeaderboardsGameMode { get { var __p = GetAt<global::System.IntPtr>(0x8B8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextLeaderboardStats { get { var __p = GetAt<global::System.IntPtr>(0x8C0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextMercHudBonusTime { get { var __p = GetAt<global::System.IntPtr>(0x8C8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextMercHudCombo { get { var __p = GetAt<global::System.IntPtr>(0x8D0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextMercHudScore { get { var __p = GetAt<global::System.IntPtr>(0x8D8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextMercHudTime { get { var __p = GetAt<global::System.IntPtr>(0x8E0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextMovementStyle { get { var __p = GetAt<global::System.IntPtr>(0x8E8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextOculus { get { var __p = GetAt<global::System.IntPtr>(0x8F0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextStickL { get { var __p = GetAt<global::System.IntPtr>(0x8F8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x8F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextStickR { get { var __p = GetAt<global::System.IntPtr>(0x900); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x900, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape { get { var __p = GetAt<global::System.IntPtr>(0x908); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x908, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_2 { get { var __p = GetAt<global::System.IntPtr>(0x910); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x910, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_3 { get { var __p = GetAt<global::System.IntPtr>(0x918); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x918, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_1_1 { get { var __p = GetAt<global::System.IntPtr>(0x920); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x920, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_1_2 { get { var __p = GetAt<global::System.IntPtr>(0x928); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x928, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_2_1 { get { var __p = GetAt<global::System.IntPtr>(0x930); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x930, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_2_2 { get { var __p = GetAt<global::System.IntPtr>(0x938); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x938, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_3_1 { get { var __p = GetAt<global::System.IntPtr>(0x940); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x940, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_3_2 { get { var __p = GetAt<global::System.IntPtr>(0x948); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x948, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_4_1 { get { var __p = GetAt<global::System.IntPtr>(0x950); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x950, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_4_2 { get { var __p = GetAt<global::System.IntPtr>(0x958); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x958, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_L1 { get { var __p = GetAt<global::System.IntPtr>(0x960); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x960, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_L2 { get { var __p = GetAt<global::System.IntPtr>(0x968); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x968, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_L3 { get { var __p = GetAt<global::System.IntPtr>(0x970); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x970, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_R1 { get { var __p = GetAt<global::System.IntPtr>(0x978); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x978, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_R2 { get { var __p = GetAt<global::System.IntPtr>(0x980); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x980, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_R3 { get { var __p = GetAt<global::System.IntPtr>(0x988); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x988, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_SpecialCombine { get { var __p = GetAt<global::System.IntPtr>(0x990); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x990, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_SpecialCombine_2 { get { var __p = GetAt<global::System.IntPtr>(0x998); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x998, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_SpecialCombine_Bottom { get { var __p = GetAt<global::System.IntPtr>(0x9A0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_SpecialCombine_Middle { get { var __p = GetAt<global::System.IntPtr>(0x9A8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_SpecialCombine_Top { get { var __p = GetAt<global::System.IntPtr>(0x9B0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_SpecialTuneUp_Bottom { get { var __p = GetAt<global::System.IntPtr>(0x9B8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_SpecialTuneUp_Main { get { var __p = GetAt<global::System.IntPtr>(0x9C0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_SpecialTuneUp_Middle { get { var __p = GetAt<global::System.IntPtr>(0x9C8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_SpecialTuneUp_Top { get { var __p = GetAt<global::System.IntPtr>(0x9D0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_V1Image_Left { get { var __p = GetAt<global::System.IntPtr>(0x9D8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_V1Image_Main { get { var __p = GetAt<global::System.IntPtr>(0x9E0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTape_V1Image_Right { get { var __p = GetAt<global::System.IntPtr>(0x9E8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTapeMerc0 { get { var __p = GetAt<global::System.IntPtr>(0x9F0); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay TextTapMerc1 { get { var __p = GetAt<global::System.IntPtr>(0x9F8); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x9F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextTitle { get { var __p = GetAt<global::System.IntPtr>(0xA00); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0xA00, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextTriggerL { get { var __p = GetAt<global::System.IntPtr>(0xA08); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0xA08, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextTriggerR { get { var __p = GetAt<global::System.IntPtr>(0xA10); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0xA10, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextWeaponMode { get { var __p = GetAt<global::System.IntPtr>(0xA18); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0xA18, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox TitleBox { get { var __p = GetAt<global::System.IntPtr>(0xA20); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0xA20, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Video1Image_CaptionText { get { var __p = GetAt<global::System.IntPtr>(0xA28); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0xA28, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Video1Image_Image { get { var __p = GetAt<global::System.IntPtr>(0xA30); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0xA30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Video1Image_TextLeft { get { var __p = GetAt<global::System.IntPtr>(0xA38); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xA38, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Video1Image_TextMain { get { var __p = GetAt<global::System.IntPtr>(0xA40); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xA40, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock Video1Image_TextRight { get { var __p = GetAt<global::System.IntPtr>(0xA48); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xA48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox Video1ImageCaption { get { var __p = GetAt<global::System.IntPtr>(0xA50); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0xA50, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VerticalBox VideoBox { get { var __p = GetAt<global::System.IntPtr>(0xA58); return __p==global::System.IntPtr.Zero?null:new VerticalBox(__p); } set => SetAt(0xA58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox VideoCaption { get { var __p = GetAt<global::System.IntPtr>(0xA60); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0xA60, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox VideoCaption_2 { get { var __p = GetAt<global::System.IntPtr>(0xA68); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0xA68, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox VideoCaption_3 { get { var __p = GetAt<global::System.IntPtr>(0xA70); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0xA70, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox VideoCaptionMerc { get { var __p = GetAt<global::System.IntPtr>(0xA78); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0xA78, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image VideoL_Alt_Image { get { var __p = GetAt<global::System.IntPtr>(0xA80); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0xA80, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock VideoL_Alt_Text0 { get { var __p = GetAt<global::System.IntPtr>(0xA88); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0xA88, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoL_Alt_Text_L1 { get { var __p = GetAt<global::System.IntPtr>(0xA90); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xA90, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoL_Alt_Text_L2 { get { var __p = GetAt<global::System.IntPtr>(0xA98); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xA98, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoL_Alt_Text_L3 { get { var __p = GetAt<global::System.IntPtr>(0xAA0); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xAA0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoL_Alt_Text_R1 { get { var __p = GetAt<global::System.IntPtr>(0xAA8); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xAA8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoL_Alt_Text_R2 { get { var __p = GetAt<global::System.IntPtr>(0xAB0); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xAB0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoL_Alt_Text_R3 { get { var __p = GetAt<global::System.IntPtr>(0xAB8); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xAB8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image VideoLImage0 { get { var __p = GetAt<global::System.IntPtr>(0xAC0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0xAC0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image VideoLImage1 { get { var __p = GetAt<global::System.IntPtr>(0xAC8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0xAC8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoLText0 { get { var __p = GetAt<global::System.IntPtr>(0xAD0); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xAD0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoLText1 { get { var __p = GetAt<global::System.IntPtr>(0xAD8); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xAD8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock VideoLText2 { get { var __p = GetAt<global::System.IntPtr>(0xAE0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0xAE0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image VideoRImage0 { get { var __p = GetAt<global::System.IntPtr>(0xAE8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0xAE8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image VideoRImage1 { get { var __p = GetAt<global::System.IntPtr>(0xAF0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0xAF0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoRText0 { get { var __p = GetAt<global::System.IntPtr>(0xAF8); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xAF8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public RichTextBlock VideoRText1 { get { var __p = GetAt<global::System.IntPtr>(0xB00); return __p==global::System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0xB00, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock VideoRText2 { get { var __p = GetAt<global::System.IntPtr>(0xB08); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0xB08, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcherMain { get { var __p = GetAt<global::System.IntPtr>(0xB10); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0xB10, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0xB18); // struct UI_WidgetColors_Struct
        public float LabelOpacity { get => GetAt<float>(0xD20); set => SetAt(0xD20, value); }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void SetPhotoLabelVisibility(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("SetPhotoLabelVisibility", __pb.Bytes);
        }
        public void SetCaptionVisibility(bool Visibility)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visibility?1:0));
            CallRaw("SetCaptionVisibility", __pb.Bytes);
        }
        public void SetVertLabelCaptionVisibility(int Index, bool SetHidden)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Index);
            __pb.Set<byte>(0x4, (byte)(SetHidden?1:0));
            CallRaw("SetVertLabelCaptionVisibility", __pb.Bytes);
        }
        public void Set3LabelsVisibility(int Index, bool SetHidden)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Index);
            __pb.Set<byte>(0x4, (byte)(SetHidden?1:0));
            CallRaw("Set3LabelsVisibility", __pb.Bytes);
        }
        public void Set2LabelsVisibility(int Index, bool SetHidden)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Index);
            __pb.Set<byte>(0x4, (byte)(SetHidden?1:0));
            CallRaw("Set2LabelsVisibility", __pb.Bytes);
        }
        public void Set3StringsColor(bool SetBlue)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SetBlue?1:0));
            CallRaw("Set3StringsColor", __pb.Bytes);
        }
        public void SetMercCostumeVisibilty(bool Visible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            CallRaw("SetMercCostumeVisibilty", __pb.Bytes);
        }
        public void ExecuteUbergraph_PlayingManualMainWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_PlayingManualMainWidget", __pb.Bytes);
        }
    }

}
