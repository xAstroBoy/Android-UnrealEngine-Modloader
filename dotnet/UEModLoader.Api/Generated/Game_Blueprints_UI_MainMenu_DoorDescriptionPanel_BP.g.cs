// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/DoorDescriptionPanel_BP
using System;

namespace UEModLoader.Game
{
    public class DoorDescriptionPanel_BP_C : VR4UIScreen
    {
        public const string UeClassName = "DoorDescriptionPanel_BP_C";
        public DoorDescriptionPanel_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new DoorDescriptionPanel_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new DoorDescriptionPanel_BP_C(p);
        public static DoorDescriptionPanel_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DoorDescriptionPanel_BP_C(o.Pointer); }
        public static DoorDescriptionPanel_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DoorDescriptionPanel_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DoorDescriptionPanel_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x250));
        public WidgetComponent Description_Widget { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public UI_MainMenu_Info_Widget_C DescriptionWidget { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new UI_MainMenu_Info_Widget_C(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public void SetImage(Texture2D Image)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Image);
            CallRaw("SetImage", __pb.Bytes);
        }
        public void SetImageMode(bool isImage)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(isImage?1:0));
            CallRaw("SetImageMode", __pb.Bytes);
        }
        public void SetWidgetRefs()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetWidgetRefs", __pb.Bytes);
        }
        public void SetDescriptionText(System.IntPtr Text)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, Text);
            CallRaw("SetDescriptionText", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_DoorDescriptionPanel_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_DoorDescriptionPanel_BP", __pb.Bytes);
        }
    }

}
