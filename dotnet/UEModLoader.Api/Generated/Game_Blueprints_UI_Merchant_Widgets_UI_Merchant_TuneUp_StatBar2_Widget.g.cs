// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_TuneUp_StatBar2_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_TuneUp_StatBar2_Widget_C : UI_Merchant_Button_Widget_BP_C
    {
        public const string UeClassName = "UI_Merchant_TuneUp_StatBar2_Widget_C";
        public UI_Merchant_TuneUp_StatBar2_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_TuneUp_StatBar2_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Merchant_TuneUp_StatBar2_Widget_C(p);
        public static UI_Merchant_TuneUp_StatBar2_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_TuneUp_StatBar2_Widget_C(o.Pointer); }
        public static UI_Merchant_TuneUp_StatBar2_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_TuneUp_StatBar2_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_TuneUp_StatBar2_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public Image Arrow { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Arrow_2 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG_Highlight { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG_Minus { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public Image BG_Plus { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Box_Minus { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Box_Plus { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox DowngradeGroup { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Minus { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Icon_Plus { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_2 { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image LevelPip { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image LevelPip_2 { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image LevelPip_3 { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image LevelPip_4 { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image LevelPip_5 { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image LevelPip_6 { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image LevelPip_7 { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox PriceBox { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_LevelLabel { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_PriceLabel { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_PriceValue { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_StatName { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_StatValue_Current { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_StatValue_Next { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_StatValue_Prev { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox UpgradeGroup { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public HorizontalBox ValuesBox { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public VR4MerchantBuyItemStat stat => new VR4MerchantBuyItemStat(AddrOf(0x348));
        public LinearColor Color_Text => new LinearColor(AddrOf(0x390));
        public LinearColor Color_HoverText => new LinearColor(AddrOf(0x3A0));
        public LinearColor Color_UnhoverText => new LinearColor(AddrOf(0x3B0));
        public LinearColor Color_PipHas => new LinearColor(AddrOf(0x3C0));
        public LinearColor Color_PipEmpty => new LinearColor(AddrOf(0x3D0));
        public LinearColor Color_PipUpgrade => new LinearColor(AddrOf(0x3E0));
        public LinearColor Color_PipHasExclusive => new LinearColor(AddrOf(0x3F0));
        public float CHARGE_INF { get => GetAt<float>(0x400); set => SetAt(0x400, value); }
        public System.IntPtr CHARGE_INF_TEXT => AddrOf(0x408); // 
        public bool ShowUpgrade { get => Native.GetPropBool(Pointer, "ShowUpgrade"); set => Native.SetPropBool(Pointer, "ShowUpgrade", value); }
        public bool ShowDowngrade { get => Native.GetPropBool(Pointer, "ShowDowngrade"); set => Native.SetPropBool(Pointer, "ShowDowngrade", value); }
        public VR4MerchantBuyItemStat DowngradeStat => new VR4MerchantBuyItemStat(AddrOf(0x428));
        public LinearColor Color_PipDowngrade => new LinearColor(AddrOf(0x470));
        public System.IntPtr MerchantColors => AddrOf(0x480); // struct UI_MerchantColors_Struct
        public SlateColor Color_PlusMinus => new SlateColor(AddrOf(0x7C8));
        public bool ShowPreviewPips { get => Native.GetPropBool(Pointer, "ShowPreviewPips"); set => Native.SetPropBool(Pointer, "ShowPreviewPips", value); }
        public void SetShowDowngrade(bool Show)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            CallRaw("SetShowDowngrade", __pb.Bytes);
        }
        public void SetShowUpgrade(bool Show)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            CallRaw("SetShowUpgrade", __pb.Bytes);
        }
        public void SetDowngradeStat(VR4MerchantBuyItemStat DowngradeStat)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<System.IntPtr>(0x0, DowngradeStat);
            CallRaw("SetDowngradeStat", __pb.Bytes);
        }
        public bool CanShowUpgrade()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("CanShowUpgrade", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void UpdateUpgradeVisibility()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateUpgradeVisibility", __pb.Bytes);
        }
        public LinearColor Get_LevelPip_7_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_7_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
        public LinearColor Get_LevelPip_6_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_6_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
        public LinearColor Get_LevelPip_5_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_5_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
        public LinearColor Get_LevelPip_4_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_4_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
        public LinearColor Get_LevelPip_3_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_3_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
        public LinearColor Get_LevelPip_2_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_2_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
        public LinearColor Get_LevelPip_1_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_1_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<LinearColor>(0x0);
        }
        public void GetPipcolorForLevel(int Level, LinearColor Return_Value)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set(0x0, Level);
            __pb.Set<System.IntPtr>(0x4, Return_Value);
            CallRaw("GetPipcolorForLevel", __pb.Bytes);
        }
        public void ToggleOff()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleOff", __pb.Bytes);
        }
        public void ToggleOn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ToggleOn", __pb.Bytes);
        }
        public void Unhighlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhighlight", __pb.Bytes);
        }
        public void Highlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Highlight", __pb.Bytes);
        }
        public void SetStat(VR4MerchantBuyItemStat stat)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<System.IntPtr>(0x0, stat);
            CallRaw("SetStat", __pb.Bytes);
        }
        public void Highlight_Plus()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Highlight_Plus", __pb.Bytes);
        }
        public void Unhighlight_Plus()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhighlight_Plus", __pb.Bytes);
        }
        public void Highlight_Minus()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Highlight_Minus", __pb.Bytes);
        }
        public void Unhighlight_Minus()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Unhighlight_Minus", __pb.Bytes);
        }
        public void SetPlusVisibility(bool IsVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsVisible?1:0));
            CallRaw("SetPlusVisibility", __pb.Bytes);
        }
        public void SetMinusVisibility(bool IsVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsVisible?1:0));
            CallRaw("SetMinusVisibility", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_TuneUp_StatBar2_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_TuneUp_StatBar2_Widget", __pb.Bytes);
        }
    }

}
