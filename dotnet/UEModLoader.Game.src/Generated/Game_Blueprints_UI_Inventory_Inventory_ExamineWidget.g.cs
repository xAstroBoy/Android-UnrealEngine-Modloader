// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/Inventory_ExamineWidget
using System;

namespace UEModLoader.Game
{
    public class Inventory_ExamineWidget_C : UserWidget
    {
        public const string UeClassName = "Inventory_ExamineWidget_C";
        public Inventory_ExamineWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Inventory_ExamineWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Inventory_ExamineWidget_C(p);
        public static Inventory_ExamineWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Inventory_ExamineWidget_C(o.Pointer); }
        public static Inventory_ExamineWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Inventory_ExamineWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Inventory_ExamineWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation Reveal { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetAnimation RevealPrompt { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BG { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BG_2 { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BG_Description { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image BG_Weapon { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ButtonImage_C ButtonImage { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ButtonImage_C ButtonImage_2 { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ButtonImage_C ButtonImage_3 { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ButtonImage_C ButtonImage_4 { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new ButtonImage_C(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Capacity { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Capacity_Value { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image CoverGlow { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image CoverGlow_2 { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher Examine { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Bottom { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Bottom_2 { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Left { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Left_2 { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Left_3 { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Right { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Right_2 { get { var __p = GetAt<global::System.IntPtr>(0x2E0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Right_3 { get { var __p = GetAt<global::System.IntPtr>(0x2E8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Top { get { var __p = GetAt<global::System.IntPtr>(0x2F0); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Gradient_Top_2 { get { var __p = GetAt<global::System.IntPtr>(0x2F8); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ItemDescription { get { var __p = GetAt<global::System.IntPtr>(0x300); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x300, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock ItemName { get { var __p = GetAt<global::System.IntPtr>(0x308); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x308, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CanvasPanel ItemPanel { get { var __p = GetAt<global::System.IntPtr>(0x310); return __p==global::System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x310, value?.Pointer ?? global::System.IntPtr.Zero); }
        public HorizontalBox LeftListen { get { var __p = GetAt<global::System.IntPtr>(0x318); return __p==global::System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x318, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline { get { var __p = GetAt<global::System.IntPtr>(0x320); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x320, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_2 { get { var __p = GetAt<global::System.IntPtr>(0x328); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x328, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_Description { get { var __p = GetAt<global::System.IntPtr>(0x330); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x330, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Outline_Weapon { get { var __p = GetAt<global::System.IntPtr>(0x338); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x338, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Power { get { var __p = GetAt<global::System.IntPtr>(0x340); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x340, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Power_Value { get { var __p = GetAt<global::System.IntPtr>(0x348); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x348, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CanvasPanel Prompt { get { var __p = GetAt<global::System.IntPtr>(0x350); return __p==global::System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x350, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetSwitcher PromptSwitcher { get { var __p = GetAt<global::System.IntPtr>(0x358); return __p==global::System.IntPtr.Zero?null:new WidgetSwitcher(__p); } set => SetAt(0x358, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Reload { get { var __p = GetAt<global::System.IntPtr>(0x360); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x360, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Reload_Value { get { var __p = GetAt<global::System.IntPtr>(0x368); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x368, value?.Pointer ?? global::System.IntPtr.Zero); }
        public HorizontalBox RightListen { get { var __p = GetAt<global::System.IntPtr>(0x370); return __p==global::System.IntPtr.Zero?null:new HorizontalBox(__p); } set => SetAt(0x370, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Speed { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock Speed_Value { get { var __p = GetAt<global::System.IntPtr>(0x380); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x380, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock WeaponDescription { get { var __p = GetAt<global::System.IntPtr>(0x388); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x388, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock WeaponName { get { var __p = GetAt<global::System.IntPtr>(0x390); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x390, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CanvasPanel WeaponPanel { get { var __p = GetAt<global::System.IntPtr>(0x398); return __p==global::System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x398, value?.Pointer ?? global::System.IntPtr.Zero); }
        public CanvasPanel WidgetCanvas { get { var __p = GetAt<global::System.IntPtr>(0x3A0); return __p==global::System.IntPtr.Zero?null:new CanvasPanel(__p); } set => SetAt(0x3A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr Colors => AddrOf(0x3A8); // struct UI_WidgetColors_Struct
        public bool ExamineShown { get => Native.GetPropBool(Pointer, "ExamineShown"); set => Native.SetPropBool(Pointer, "ExamineShown", value); }
        public bool PromptShown { get => Native.GetPropBool(Pointer, "PromptShown"); set => Native.SetPropBool(Pointer, "PromptShown", value); }
        public global::System.IntPtr PromptHidden => AddrOf(0x5B8); // 
        public bool ExamineShowQueued { get => Native.GetPropBool(Pointer, "ExamineShowQueued"); set => Native.SetPropBool(Pointer, "ExamineShowQueued", value); }
        public global::System.IntPtr ExamineHidden => AddrOf(0x5D0); // 
        public void HideExamine()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideExamine", __pb.Bytes);
        }
        public void ShowExamine()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowExamine", __pb.Bytes);
        }
        public void HidePrompt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HidePrompt", __pb.Bytes);
        }
        public void ShowPrompt()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowPrompt", __pb.Bytes);
        }
        public void SetHand(VR4PlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("SetHand", __pb.Bytes);
        }
        public void SetCoverAlpha(float alpha)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, alpha);
            CallRaw("SetCoverAlpha", __pb.Bytes);
        }
        public void SetDescriptionAlpha(float Percent)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Percent);
            CallRaw("SetDescriptionAlpha", __pb.Bytes);
        }
        public void SetEdgeAlpha(float alpha)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, alpha);
            CallRaw("SetEdgeAlpha", __pb.Bytes);
        }
        public void SetTextVisibility(bool SetVisible)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SetVisible?1:0));
            CallRaw("SetTextVisibility", __pb.Bytes);
        }
        public void SetItemID(int ItemId, bool success)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, ItemId);
            __pb.Set<byte>(0x4, (byte)(success?1:0));
            CallRaw("SetItemID", __pb.Bytes);
        }
        public void SetItem(global::System.IntPtr Item_Handle, bool success)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<global::System.IntPtr>(0x0, Item_Handle);
            __pb.Set<byte>(0x8, (byte)(success?1:0));
            CallRaw("SetItem", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void RevealFinished()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RevealFinished", __pb.Bytes);
        }
        public void RevealPromptFinished()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RevealPromptFinished", __pb.Bytes);
        }
        public void ExecuteUbergraph_Inventory_ExamineWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Inventory_ExamineWidget", __pb.Bytes);
        }
        public void ExamineHidden__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ExamineHidden__DelegateSignature", __pb.Bytes);
        }
        public void PromptHidden__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PromptHidden__DelegateSignature", __pb.Bytes);
        }
    }

}
