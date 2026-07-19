// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/InfoRing
using System;

namespace UEModLoader.Game
{
    public class InfoRing_C : UserWidget
    {
        public const string UeClassName = "InfoRing_C";
        public InfoRing_C(System.IntPtr ptr) : base(ptr) {}
        public static new InfoRing_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InfoRing_C(p);
        public static InfoRing_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InfoRing_C(o.Pointer); }
        public static InfoRing_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InfoRing_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InfoRing_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation WagglePulse { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation HideWaggle { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation ShowQteResult { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation ShowQteSuccess { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation SwapToLargeInstant { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation RevealSmallTextR { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation RevealSmallTextL { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation PulseRed { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation SwapToLarge { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Drip3Alt { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Drip2Alt { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Drip1Alt { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation FlashArrowAlt { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation FlashArrow { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation DripC2 { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation DripC1 { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Flash { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Drip3 { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Drip2 { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Drip1 { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay _3DBackingParent { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public Border Border_Brush { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new Border(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public Border Border_BrushAlt { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new Border(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public Border Border_sml { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new Border(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public Border Border_smr { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new Border(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay BorderPadding { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox CommandAnchor { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay CommandParent { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock CommandText { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock CommandTextSmL { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock CommandTextSmR { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay GlobalParent { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ImageQteRing { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public Image NextArrow { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public Image NextArrowAlt { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public Image NextArrowOutline { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public Image NextArrowOutlineAlt { get { var __p = GetAt<System.IntPtr>(0x360); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x360, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Overlay_QTE { get { var __p = GetAt<System.IntPtr>(0x368); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x368, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox PlusSign { get { var __p = GetAt<System.IntPtr>(0x370); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x370, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock QTE_CompleteText { get { var __p = GetAt<System.IntPtr>(0x378); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x378, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock QTE_CompleteTextAura { get { var __p = GetAt<System.IntPtr>(0x380); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x380, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock QTE_Text { get { var __p = GetAt<System.IntPtr>(0x388); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x388, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox QteResultIconParent { get { var __p = GetAt<System.IntPtr>(0x390); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x390, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_Drip1 { get { var __p = GetAt<System.IntPtr>(0x398); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x398, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_Drip1Alt { get { var __p = GetAt<System.IntPtr>(0x3A0); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3A0, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_Drip2 { get { var __p = GetAt<System.IntPtr>(0x3A8); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3A8, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_Drip2Alt { get { var __p = GetAt<System.IntPtr>(0x3B0); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3B0, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_Drip3 { get { var __p = GetAt<System.IntPtr>(0x3B8); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3B8, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_Drip3Alt { get { var __p = GetAt<System.IntPtr>(0x3C0); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3C0, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_DripC1 { get { var __p = GetAt<System.IntPtr>(0x3C8); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3C8, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_DripC2 { get { var __p = GetAt<System.IntPtr>(0x3D0); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3D0, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SmallIconParentL { get { var __p = GetAt<System.IntPtr>(0x3D8); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3D8, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SmallIconParentNo3D { get { var __p = GetAt<System.IntPtr>(0x3E0); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3E0, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SmallIconParentR { get { var __p = GetAt<System.IntPtr>(0x3E8); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x3E8, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay SmallTextParent { get { var __p = GetAt<System.IntPtr>(0x3F0); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x3F0, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Subtitle_Parent { get { var __p = GetAt<System.IntPtr>(0x3F8); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x3F8, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Subtitle_ParentAlt { get { var __p = GetAt<System.IntPtr>(0x400); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x400, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SubtitleAnchor { get { var __p = GetAt<System.IntPtr>(0x408); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x408, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SubtitleAnchorAlt { get { var __p = GetAt<System.IntPtr>(0x410); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x410, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock SubtitleText { get { var __p = GetAt<System.IntPtr>(0x418); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x418, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock SubtitleText_Alt { get { var __p = GetAt<System.IntPtr>(0x420); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x420, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay TextButtonParent { get { var __p = GetAt<System.IntPtr>(0x428); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x428, value?.Pointer ?? System.IntPtr.Zero); }
        public Image WaggleBG { get { var __p = GetAt<System.IntPtr>(0x430); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x430, value?.Pointer ?? System.IntPtr.Zero); }
        public Image WaggleFill { get { var __p = GetAt<System.IntPtr>(0x438); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x438, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay WaggleFillContainer { get { var __p = GetAt<System.IntPtr>(0x440); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x440, value?.Pointer ?? System.IntPtr.Zero); }
        public Image WaggleFillGlow { get { var __p = GetAt<System.IntPtr>(0x448); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x448, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox WaggleParent { get { var __p = GetAt<System.IntPtr>(0x450); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x450, value?.Pointer ?? System.IntPtr.Zero); }
        public Image WaggleRing { get { var __p = GetAt<System.IntPtr>(0x458); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x458, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_Icon { get { var __p = GetAt<System.IntPtr>(0x460); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x460, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_IconNo3d { get { var __p = GetAt<System.IntPtr>(0x468); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x468, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_IconRedL { get { var __p = GetAt<System.IntPtr>(0x470); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x470, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_IconRedR { get { var __p = GetAt<System.IntPtr>(0x478); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x478, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_QTE { get { var __p = GetAt<System.IntPtr>(0x480); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x480, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_QteResultIcon { get { var __p = GetAt<System.IntPtr>(0x488); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x488, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_Result { get { var __p = GetAt<System.IntPtr>(0x490); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x490, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetSwitcher WidgetSwitcher_SmType { get { var __p = GetAt<System.IntPtr>(0x498); return __p==System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x498, value?.Pointer ?? System.IntPtr.Zero); }
        public EQTEId QTE { get => (EQTEId)GetAt<byte>(0x4A0); set => SetAt(0x4A0, (byte)value); }
        public EActionButtonType Action { get => (EActionButtonType)GetAt<byte>(0x4A1); set => SetAt(0x4A1, (byte)value); }
        public bool IsWagglePulsing { get => Native.GetPropBool(Pointer, "IsWagglePulsing"); set => Native.SetPropBool(Pointer, "IsWagglePulsing", value); }
        public void ShrinkWaggleFill()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShrinkWaggleFill", __pb.Bytes);
        }
        public void SetupWaggleParent(EVR4CommandButton commandButton)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)commandButton);
            CallRaw("SetupWaggleParent", __pb.Bytes);
        }
        public void QteInstantResult(System.IntPtr SucceedText, bool success)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, SucceedText);
            __pb.Set<byte>(0x18, (byte)(success?1:0));
            CallRaw("QteInstantResult", __pb.Bytes);
        }
        public void QteReset()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("QteReset", __pb.Bytes);
        }
        public void Show_Qte_Result(bool success)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(success?1:0));
            CallRaw("Show Qte Result", __pb.Bytes);
        }
        public void ShowCommandButton_LargeInstant(bool Use3dIcon, EVR4CommandButton Button)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(Use3dIcon?1:0));
            __pb.Set<byte>(0x1, (byte)Button);
            CallRaw("ShowCommandButton_LargeInstant", __pb.Bytes);
        }
        public void RevealSmallText(EVR4CommandButton commandButton, bool RevealInstantly)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)commandButton);
            __pb.Set<byte>(0x1, (byte)(RevealInstantly?1:0));
            CallRaw("RevealSmallText", __pb.Bytes);
        }
        public void ResetCommand()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetCommand", __pb.Bytes);
        }
        public void ShowCommandButton_Large(EVR4CommandButton commandButton, bool Use3dIcon)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)commandButton);
            __pb.Set<byte>(0x1, (byte)(Use3dIcon?1:0));
            CallRaw("ShowCommandButton_Large", __pb.Bytes);
        }
        public void ShowRedCommandButton(EVR4CommandButton commandButton)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)commandButton);
            CallRaw("ShowRedCommandButton", __pb.Bytes);
        }
        public void SwapLargeToSmall(EVR4CommandButton commandButton)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)commandButton);
            CallRaw("SwapLargeToSmall", __pb.Bytes);
        }
        public void ShowCommandButton_Small(EVR4CommandButton commandButton)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)commandButton);
            CallRaw("ShowCommandButton_Small", __pb.Bytes);
        }
        public void HideCommandButton()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideCommandButton", __pb.Bytes);
        }
        public void ShowCommandButton(EVR4CommandButton commandButton, EActionButtonType Action, EQTEId QTE)
        {
            var __pb = new ParamBuffer(3);
            __pb.Set<byte>(0x0, (byte)commandButton);
            __pb.Set<byte>(0x1, (byte)Action);
            __pb.Set<byte>(0x2, (byte)QTE);
            CallRaw("ShowCommandButton", __pb.Bytes);
        }
        public void PlayWagglePulse()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayWagglePulse", __pb.Bytes);
        }
        public void StopWagglePulse()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StopWagglePulse", __pb.Bytes);
        }
        public void ExecuteUbergraph_InfoRing(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_InfoRing", __pb.Bytes);
        }
    }

}
