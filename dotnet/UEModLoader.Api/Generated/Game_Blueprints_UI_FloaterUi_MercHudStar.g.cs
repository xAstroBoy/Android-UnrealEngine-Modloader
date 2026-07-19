// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/MercHudStar
using System;

namespace UEModLoader.Game
{
    public class MercHudStar_C : UserWidget
    {
        public const string UeClassName = "MercHudStar_C";
        public MercHudStar_C(System.IntPtr ptr) : base(ptr) {}
        public static new MercHudStar_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MercHudStar_C(p);
        public static MercHudStar_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MercHudStar_C(o.Pointer); }
        public static MercHudStar_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MercHudStar_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MercHudStar_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public WidgetAnimation GlowChallenge { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public WidgetAnimation Glow { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new WidgetAnimation(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Layer1 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_Layer2 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public SizeBox SizeBox_Scale { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public void SetToChallenge()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetToChallenge", __pb.Bytes);
        }
        public void GlowBegin(float Delay, bool challenge)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Delay);
            __pb.Set<byte>(0x4, (byte)(challenge?1:0));
            CallRaw("GlowBegin", __pb.Bytes);
        }
        public void ExecuteUbergraph_MercHudStar(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_MercHudStar", __pb.Bytes);
        }
    }

}
