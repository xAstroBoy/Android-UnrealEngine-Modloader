// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMessage/DebugMessageHandler
using System;

namespace UEModLoader.Game
{
    public class DebugMessageHandler_C : VR4DebugScreenActor
    {
        public const string UeClassName = "DebugMessageHandler_C";
        public DebugMessageHandler_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new DebugMessageHandler_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new DebugMessageHandler_C(p);
        public static DebugMessageHandler_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new DebugMessageHandler_C(o.Pointer); }
        public static DebugMessageHandler_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new DebugMessageHandler_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new DebugMessageHandler_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public WidgetComponent Widget { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public DebugMessageParent_C WidgetParent { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new DebugMessageParent_C(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void UpdateScreenTextPosition(DebugMessageLine_C TextWidget)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, TextWidget);
            CallRaw("UpdateScreenTextPosition", __pb.Bytes);
        }
        public void HasActiveText(bool Active)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Active?1:0));
            CallRaw("HasActiveText", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void MakeVisible()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("MakeVisible", __pb.Bytes);
        }
        public void ExecuteUbergraph_DebugMessageHandler(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_DebugMessageHandler", __pb.Bytes);
        }
    }

}
