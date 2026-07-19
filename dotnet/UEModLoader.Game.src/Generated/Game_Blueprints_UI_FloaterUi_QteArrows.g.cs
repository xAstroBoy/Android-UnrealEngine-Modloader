// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/FloaterUi/QteArrows
using System;

namespace UEModLoader.Game
{
    public class QteArrows_C : UserWidget
    {
        public const string UeClassName = "QteArrows_C";
        public QteArrows_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new QteArrows_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new QteArrows_C(p);
        public static QteArrows_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new QteArrows_C(o.Pointer); }
        public static QteArrows_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new QteArrows_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new QteArrows_C(a[i].Pointer); return r; }
        public Image Image { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Image_2 { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_One { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay Overlay_Two { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Overlay OverlayTriggerCircles { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new Overlay(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow1D { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow1L { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow1R { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow1U { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2LD { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2LDL { get { var __p = GetAt<global::System.IntPtr>(0x280); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x280, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2LL { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2LR { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2LU { get { var __p = GetAt<global::System.IntPtr>(0x298); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x298, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2LUL { get { var __p = GetAt<global::System.IntPtr>(0x2A0); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x2A0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2RD { get { var __p = GetAt<global::System.IntPtr>(0x2A8); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x2A8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2RDR { get { var __p = GetAt<global::System.IntPtr>(0x2B0); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x2B0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2RL { get { var __p = GetAt<global::System.IntPtr>(0x2B8); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x2B8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2RR { get { var __p = GetAt<global::System.IntPtr>(0x2C0); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x2C0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2RU { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public QteArrow_C QteArrow2RUR { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new QteArrow_C(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetTriggleCircles()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetTriggleCircles", __pb.Bytes);
        }
        public void success()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("success", __pb.Bytes);
        }
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
        public void Set_Motion_Type(EMotionActionType MotionType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)MotionType);
            CallRaw("Set Motion Type", __pb.Bytes);
        }
    }

}
