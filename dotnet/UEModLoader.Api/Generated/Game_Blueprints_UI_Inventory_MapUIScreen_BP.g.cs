// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/MapUIScreen_BP
using System;

namespace UEModLoader.Game
{
    public class MapUIScreen_BP_C : VR4MapUIScreen
    {
        public const string UeClassName = "MapUIScreen_BP_C";
        public MapUIScreen_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new MapUIScreen_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MapUIScreen_BP_C(p);
        public static MapUIScreen_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MapUIScreen_BP_C(o.Pointer); }
        public static MapUIScreen_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MapUIScreen_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MapUIScreen_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x408));
        public StaticMeshComponent StaticBackground { get { var __p = GetAt<System.IntPtr>(0x410); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x410, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent Static { get { var __p = GetAt<System.IntPtr>(0x418); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x418, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent background { get { var __p = GetAt<System.IntPtr>(0x420); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x420, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent Lines { get { var __p = GetAt<System.IntPtr>(0x428); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x428, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Heading { get { var __p = GetAt<System.IntPtr>(0x430); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x430, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetComponent Widget_Footer { get { var __p = GetAt<System.IntPtr>(0x438); return __p==System.IntPtr.Zero?null:new WidgetComponent(__p); } set => SetAt(0x438, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Overlay { get { var __p = GetAt<System.IntPtr>(0x440); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x440, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent DisplayMesh { get { var __p = GetAt<System.IntPtr>(0x448); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x448, value?.Pointer ?? System.IntPtr.Zero); }
        public void UpdateStatic()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdateStatic", __pb.Bytes);
        }
        public bool OnActionReleased(VR4PlayerHand Hand, EVR4UIAction Action)
        {
            var __pb = new ParamBuffer(10);
            __pb.SetObject(0x0, Hand);
            __pb.Set<byte>(0x8, (byte)Action);
            CallRaw("OnActionReleased", __pb.Bytes);
            return __pb.Get<byte>(0x9) != 0;
        }
        public bool OnActionPressed(VR4PlayerHand Hand, EVR4UIAction Action)
        {
            var __pb = new ParamBuffer(10);
            __pb.SetObject(0x0, Hand);
            __pb.Set<byte>(0x8, (byte)Action);
            CallRaw("OnActionPressed", __pb.Bytes);
            return __pb.Get<byte>(0x9) != 0;
        }
        public void TryEnterScalingState(VR4PausePlayerHand SecondHand, EVR4UIAction Action, bool success)
        {
            var __pb = new ParamBuffer(10);
            __pb.SetObject(0x0, SecondHand);
            __pb.Set<byte>(0x8, (byte)Action);
            __pb.Set<byte>(0x9, (byte)(success?1:0));
            CallRaw("TryEnterScalingState", __pb.Bytes);
        }
        public void TryEnterNormalState(bool success)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(success?1:0));
            CallRaw("TryEnterNormalState", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEnterScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveEnterScreen", __pb.Bytes);
        }
        public void ReceiveExitScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveExitScreen", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void ExecuteUbergraph_MapUIScreen_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_MapUIScreen_BP", __pb.Bytes);
        }
    }

}
