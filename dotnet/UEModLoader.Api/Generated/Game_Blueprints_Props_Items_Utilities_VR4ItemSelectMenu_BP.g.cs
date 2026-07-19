// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Props/Items/Utilities/VR4ItemSelectMenu_BP
using System;

namespace UEModLoader.Game
{
    public class VR4ItemSelectMenu_BP_C : VR4ItemSelectMenu
    {
        public const string UeClassName = "VR4ItemSelectMenu_BP_C";
        public VR4ItemSelectMenu_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new VR4ItemSelectMenu_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new VR4ItemSelectMenu_BP_C(p);
        public static VR4ItemSelectMenu_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4ItemSelectMenu_BP_C(o.Pointer); }
        public static VR4ItemSelectMenu_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4ItemSelectMenu_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4ItemSelectMenu_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2A8));
        public SceneComponent MenuLineAnchor { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public LineComponent LineToMenu { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public LineComponent LineToReceptacle { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new LineComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public float ButtonDelay { get => GetAt<float>(0x2D8); set => SetAt(0x2D8, value); }
        public void InitAnchors()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitAnchors", __pb.Bytes);
        }
        public void OnNoItemsFound()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnNoItemsFound", __pb.Bytes);
        }
        public void OnGrab(VR4GamePlayerHand Hand)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Hand);
            CallRaw("OnGrab", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void CloseMenu()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CloseMenu", __pb.Bytes);
        }
        public void ShowIcons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowIcons", __pb.Bytes);
        }
        public void HideIcons()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideIcons", __pb.Bytes);
        }
        public void OnSelected(VR4GamePlayerHand playerHand, EItemId ItemId)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, playerHand);
            __pb.Set<byte>(0x8, (byte)ItemId);
            CallRaw("OnSelected", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4ItemSelectMenu_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4ItemSelectMenu_BP", __pb.Bytes);
        }
    }

}
