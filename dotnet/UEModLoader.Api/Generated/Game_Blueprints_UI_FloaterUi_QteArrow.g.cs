// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/QteArrow
using System;

namespace UEModLoader.Game
{
    public class QteArrow_C : UserWidget
    {
        public const string UeClassName = "QteArrow_C";
        public QteArrow_C(System.IntPtr ptr) : base(ptr) {}
        public static new QteArrow_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new QteArrow_C(p);
        public static QteArrow_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new QteArrow_C(o.Pointer); }
        public static QteArrow_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new QteArrow_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new QteArrow_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image ArrowFront { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ArrowFrontShadow { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ArrowGlow { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image ArrowGlowShadow { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Overlay Overlay_Scale { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public int Orientation { get => GetAt<int>(0x260); set => SetAt(0x260, value); }
        public void GlowOff()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GlowOff", __pb.Bytes);
        }
        public void GlowOn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GlowOn", __pb.Bytes);
        }
        public void QteSuccess()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("QteSuccess", __pb.Bytes);
        }
        public void HideArrow()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideArrow", __pb.Bytes);
        }
        public void ShowHideArrow(bool Show)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            CallRaw("ShowHideArrow", __pb.Bytes);
        }
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_QteArrow(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_QteArrow", __pb.Bytes);
        }
    }

}
