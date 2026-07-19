// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/Inventory_QuickSelectSlot_BP
using System;

namespace UEModLoader.Game
{
    public class Inventory_QuickSelectSlot_BP_C : Actor
    {
        public const string UeClassName = "Inventory_QuickSelectSlot_BP_C";
        public Inventory_QuickSelectSlot_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Inventory_QuickSelectSlot_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Inventory_QuickSelectSlot_BP_C(p);
        public static Inventory_QuickSelectSlot_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Inventory_QuickSelectSlot_BP_C(o.Pointer); }
        public static Inventory_QuickSelectSlot_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Inventory_QuickSelectSlot_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Inventory_QuickSelectSlot_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public StaticMeshComponent GUI_Inventory_QuickSelect { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public WidgetComponent Widget_QuickSelect { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public VR4UIButtonComponent Button { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new VR4UIButtonComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EPropSlot propSlot { get => (EPropSlot)GetAt<byte>(0x248); set => SetAt(0x248, (byte)value); }
        public global::System.IntPtr SlotName => AddrOf(0x250); // 
        public int EquippedItemID { get => GetAt<int>(0x268); set => SetAt(0x268, value); }
        public UI_Inventory_QuickSelect_Widget_C Ref_Widget { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new UI_Inventory_QuickSelect_Widget_C(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TimerHandle FlashTimer => new TimerHandle(AddrOf(0x278));
        public TimerHandle RedrawTimer => new TimerHandle(AddrOf(0x280));
        public void UpdateQuickslotTexture()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateQuickslotTexture", __pb.Bytes);
        }
        public void GetInvalidItemID(int Value)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Value);
            CallRaw("GetInvalidItemID", __pb.Bytes);
        }
        public void IsValidItemID(int ItemId, bool Invalid)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, ItemId);
            __pb.Set<byte>(0x4, (byte)(Invalid?1:0));
            CallRaw("IsValidItemID", __pb.Bytes);
        }
        public void Initialize(EPropSlot Prop_Slot)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Prop_Slot);
            CallRaw("Initialize", __pb.Bytes);
        }
        public void SetItem(int ItemId, int WeaponID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, ItemId);
            __pb.Set(0x4, WeaponID);
            CallRaw("SetItem", __pb.Bytes);
        }
        public void BndEvt__Button_K2Node_ComponentBoundEvent_0_UIComponentDragAndDropEvent__DelegateSignature(VR4UIComponent component, VR4UIComponent payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, payload);
            CallRaw("BndEvt__Button_K2Node_ComponentBoundEvent_0_UIComponentDragAndDropEvent__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__Button_K2Node_ComponentBoundEvent_1_UIComponentDragAndDropEvent__DelegateSignature(VR4UIComponent component, VR4UIComponent payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, payload);
            CallRaw("BndEvt__Button_K2Node_ComponentBoundEvent_1_UIComponentDragAndDropEvent__DelegateSignature", __pb.Bytes);
        }
        public void BndEvt__Button_K2Node_ComponentBoundEvent_2_UIComponentDragAndDropEvent__DelegateSignature(VR4UIComponent component, VR4UIComponent payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, component);
            __pb.SetObject(0x8, payload);
            CallRaw("BndEvt__Button_K2Node_ComponentBoundEvent_2_UIComponentDragAndDropEvent__DelegateSignature", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void SetAvailability(bool IsAvailable)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsAvailable?1:0));
            CallRaw("SetAvailability", __pb.Bytes);
        }
        public void UpdateRedraw(bool AutoDraw)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(AutoDraw?1:0));
            CallRaw("UpdateRedraw", __pb.Bytes);
        }
        public void RedrawtimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RedrawtimerExpired", __pb.Bytes);
        }
        public void OnPlayerSettingsChanged(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("OnPlayerSettingsChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_Inventory_QuickSelectSlot_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Inventory_QuickSelectSlot_BP", __pb.Bytes);
        }
    }

}
