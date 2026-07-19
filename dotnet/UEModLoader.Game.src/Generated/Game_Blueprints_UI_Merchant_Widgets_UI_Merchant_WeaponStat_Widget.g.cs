// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/Widgets/UI_Merchant_WeaponStat_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_WeaponStat_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Merchant_WeaponStat_Widget_C";
        public UI_Merchant_WeaponStat_Widget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_WeaponStat_Widget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_Merchant_WeaponStat_Widget_C(p);
        public static UI_Merchant_WeaponStat_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_WeaponStat_Widget_C(o.Pointer); }
        public static UI_Merchant_WeaponStat_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_WeaponStat_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_WeaponStat_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image LevelPip { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image LevelPip_2 { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image LevelPip_3 { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image LevelPip_4 { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image LevelPip_5 { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image LevelPip_6 { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_2 { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_3 { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_4 { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image StatCover { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_LevelLabel { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_StatName { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Text_StatValue_Current { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Name => AddrOf(0x2B0); // 
        public global::System.IntPtr Value => AddrOf(0x2C8); // 
        public VR4MerchantBuyItemStat stat => new VR4MerchantBuyItemStat(AddrOf(0x2E0));
        public LinearColor Color_PipEmpty => new LinearColor(AddrOf(0x328));
        public LinearColor Color_PipHas => new LinearColor(AddrOf(0x338));
        public LinearColor Color_PipHasExclusive => new LinearColor(AddrOf(0x348));
        public float CHARGE_INF { get => GetAt<float>(0x358); set => SetAt(0x358, value); }
        public global::System.IntPtr CHARGE_INF_TEXT => AddrOf(0x360); // 
        public global::System.IntPtr Colors => AddrOf(0x378); // struct UI_WidgetColors_Struct
        public global::System.IntPtr MerchantColors => AddrOf(0x580); // struct UI_MerchantColors_Struct
        public void SetStatVisibility(bool IsVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsVisible?1:0));
            CallRaw("SetStatVisibility", __pb.Bytes);
        }
        public void SetStatData(global::System.IntPtr Stat_)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<global::System.IntPtr>(0x0, Stat_);
            CallRaw("SetStatData", __pb.Bytes);
        }
        public global::System.IntPtr Get_LevelPip_6_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_6_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        public global::System.IntPtr Get_LevelPip_5_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_5_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        public global::System.IntPtr Get_LevelPip_4_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_4_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        public global::System.IntPtr Get_LevelPip_3_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_3_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        public global::System.IntPtr Get_LevelPip_2_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_2_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        public global::System.IntPtr Get_LevelPip_1_ColorAndOpacity_0()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("Get_LevelPip_1_ColorAndOpacity_0", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        public void GetPipcolorForLevel(int Level, global::System.IntPtr Return_Value)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set(0x0, Level);
            __pb.Set<global::System.IntPtr>(0x4, Return_Value);
            CallRaw("GetPipcolorForLevel", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_WeaponStat_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_WeaponStat_Widget", __pb.Bytes);
        }
    }

}
