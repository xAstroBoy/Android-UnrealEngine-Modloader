// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_Inventory_QuickSelect_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Inventory_QuickSelect_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Inventory_QuickSelect_Widget_C";
        public UI_Inventory_QuickSelect_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Inventory_QuickSelect_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Inventory_QuickSelect_Widget_C(p);
        public static UI_Inventory_QuickSelect_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Inventory_QuickSelect_Widget_C(o.Pointer); }
        public static UI_Inventory_QuickSelect_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Inventory_QuickSelect_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Inventory_QuickSelect_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation WeaponFill { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Slide_RightLeft { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation BG_Flash { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation PlusIcon_Shrink { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation WeaponIcon_Flash { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation PlusIcon_Flash { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public CanvasPanel CanvasPanel { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public ProgressBar Fill_BG { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new ProgressBar(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public ProgressBar Fill_Preview { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new ProgressBar(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BG { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_DividerLine { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Flash { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Glow { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Icon_Plus { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Icon_Plus_Highlight { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Icon_Slot { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Icon_Weapon { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Icon_Weapon_Highlight { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Preview { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_Add { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_DropMessage { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_SlotName { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_WeaponName { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr FlashComplete => AddrOf(0x2F0); // 
        public bool IsFilled { get => Native.GetPropBool(Pointer, "IsFilled"); set => Native.SetPropBool(Pointer, "IsFilled", value); }
        public SlateColor Color_Filled_Hover => new SlateColor(AddrOf(0x308));
        public SlateColor Color_Filled_Unhover => new SlateColor(AddrOf(0x330));
        public SlateColor Color_Unfilled_Hover => new SlateColor(AddrOf(0x358));
        public SlateColor Color_Unfilled_Unhover => new SlateColor(AddrOf(0x380));
        public SlateColor Color_BG_Filled_Hover => new SlateColor(AddrOf(0x3A8));
        public SlateColor Color_BG_Filled_Unhover => new SlateColor(AddrOf(0x3D0));
        public SlateColor Color_BG_Unfilled_Hover => new SlateColor(AddrOf(0x3F8));
        public SlateColor Color_BG_Unfilled_Unhover => new SlateColor(AddrOf(0x420));
        public bool showingPlusIcon { get => Native.GetPropBool(Pointer, "showingPlusIcon"); set => Native.SetPropBool(Pointer, "showingPlusIcon", value); }
        public bool IsRight { get => Native.GetPropBool(Pointer, "IsRight"); set => Native.SetPropBool(Pointer, "IsRight", value); }
        public System.IntPtr Blank => AddrOf(0x450); // 
        public bool IsAvailable { get => Native.GetPropBool(Pointer, "IsAvailable"); set => Native.SetPropBool(Pointer, "IsAvailable", value); }
        public SlateColor Color_Black => new SlateColor(AddrOf(0x470));
        public SlateColor Color_Filled_Divider => new SlateColor(AddrOf(0x498));
        public SlateBrush BlankBrush => new SlateBrush(AddrOf(0x4C0));
        public bool IsPreviewEmpty { get => Native.GetPropBool(Pointer, "IsPreviewEmpty"); set => Native.SetPropBool(Pointer, "IsPreviewEmpty", value); }
        public System.IntPtr UpdateAutodraw => AddrOf(0x550); // 
        public bool UseOptimization { get => Native.GetPropBool(Pointer, "UseOptimization"); set => Native.SetPropBool(Pointer, "UseOptimization", value); }
        public bool ShowingFlash { get => Native.GetPropBool(Pointer, "ShowingFlash"); set => Native.SetPropBool(Pointer, "ShowingFlash", value); }
        public bool IsAnimating { get => Native.GetPropBool(Pointer, "IsAnimating"); set => Native.SetPropBool(Pointer, "IsAnimating", value); }
        public void UpdateRedraw(System.IntPtr DebugString)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, DebugString);
            CallRaw("UpdateRedraw", __pb.Bytes);
        }
        public void SetLeft(bool IsAvailable)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsAvailable?1:0));
            CallRaw("SetLeft", __pb.Bytes);
        }
        public void SetRight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetRight", __pb.Bytes);
        }
        public void Set_Colors(SlateColor Text_Color, SlateColor Icon_Color, SlateColor Glow_Color, SlateColor BG_Color, SlateColor Divider_Color)
        {
            var __pb = new ParamBuffer(200);
            __pb.Set<System.IntPtr>(0x0, Text_Color);
            __pb.Set<System.IntPtr>(0x28, Icon_Color);
            __pb.Set<System.IntPtr>(0x50, Glow_Color);
            __pb.Set<System.IntPtr>(0x78, BG_Color);
            __pb.Set<System.IntPtr>(0xA0, Divider_Color);
            CallRaw("Set Colors", __pb.Bytes);
        }
        public void Finished_CA10621E4D986DD25D9A22AAE7134A6A()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_CA10621E4D986DD25D9A22AAE7134A6A", __pb.Bytes);
        }
        public void Finished_B2ACA9DA4FA2D97D038D7A86DB0C10B2()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_B2ACA9DA4FA2D97D038D7A86DB0C10B2", __pb.Bytes);
        }
        public void Finished_43F7E3C743BA0A310F0EDBB490F49B07()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_43F7E3C743BA0A310F0EDBB490F49B07", __pb.Bytes);
        }
        public void Finished_B43796DA4F34AB513B45148497E77584()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_B43796DA4F34AB513B45148497E77584", __pb.Bytes);
        }
        public void Finished_5A3678164F7CAA11D36556B6E73CAF06()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_5A3678164F7CAA11D36556B6E73CAF06", __pb.Bytes);
        }
        public void Finished_DD63461D48F7AF5464EF3B90B90412B4()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_DD63461D48F7AF5464EF3B90B90412B4", __pb.Bytes);
        }
        public void Finished_1C6C340D455376C4F23442A65D0F41E9()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Finished_1C6C340D455376C4F23442A65D0F41E9", __pb.Bytes);
        }
        public void SetWeaponName(System.IntPtr WeaponName)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, WeaponName);
            CallRaw("SetWeaponName", __pb.Bytes);
        }
        public void SetSlotName(System.IntPtr SlotName)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, SlotName);
            CallRaw("SetSlotName", __pb.Bytes);
        }
        public void OnHover()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnHover", __pb.Bytes);
        }
        public void OnUnhover()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnUnhover", __pb.Bytes);
        }
        public void SetSlotIcons(EPropSlot NewParam)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)NewParam);
            CallRaw("SetSlotIcons", __pb.Bytes);
        }
        public void SetPreview(bool IsVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsVisible?1:0));
            CallRaw("SetPreview", __pb.Bytes);
        }
        public void SetAvailability(bool IsAvailable)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsAvailable?1:0));
            CallRaw("SetAvailability", __pb.Bytes);
        }
        public void SetSlotBackgrounds(Texture2D Texture)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Texture);
            CallRaw("SetSlotBackgrounds", __pb.Bytes);
        }
        public void SlideRight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlideRight", __pb.Bytes);
        }
        public void ShowPlus(bool AddFlash)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(AddFlash?1:0));
            CallRaw("ShowPlus", __pb.Bytes);
        }
        public void HidePlus(bool AddFlash)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(AddFlash?1:0));
            CallRaw("HidePlus", __pb.Bytes);
        }
        public void FlashWeaponIcon()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlashWeaponIcon", __pb.Bytes);
        }
        public void FlashBG()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlashBG", __pb.Bytes);
        }
        public void InitialSetUp()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitialSetUp", __pb.Bytes);
        }
        public void SlideLeft()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SlideLeft", __pb.Bytes);
        }
        public void PlayWeaponFill()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayWeaponFill", __pb.Bytes);
        }
        public void PlayWeaponEmpty()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayWeaponEmpty", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Inventory_QuickSelect_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Inventory_QuickSelect_Widget", __pb.Bytes);
        }
        public void UpdateAutodraw__DelegateSignature(bool AutoDraw)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(AutoDraw?1:0));
            CallRaw("UpdateAutodraw__DelegateSignature", __pb.Bytes);
        }
        public void FlashComplete__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FlashComplete__DelegateSignature", __pb.Bytes);
        }
    }

}
