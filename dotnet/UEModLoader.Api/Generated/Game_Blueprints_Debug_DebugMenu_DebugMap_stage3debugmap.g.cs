// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMenu/DebugMap/stage3debugmap
using System;

namespace UEModLoader.Game
{
    public class stage3debugmap_C : UserWidget
    {
        public const string UeClassName = "stage3debugmap_C";
        public stage3debugmap_C(System.IntPtr ptr) : base(ptr) {}
        public static new stage3debugmap_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new stage3debugmap_C(p);
        public static stage3debugmap_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new stage3debugmap_C(o.Pointer); }
        public static stage3debugmap_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new stage3debugmap_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new stage3debugmap_C(a[i].Pointer); return r; }
        public Image r300 { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r301 { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r303 { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r304 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r305 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r306 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r307 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r308 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r309 { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r30a { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r30b { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r30c { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r30d { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r30e { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r30f { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r310 { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r311 { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r312 { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r315 { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r316 { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r317 { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r318 { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r31a { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r31b { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r31c { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r31d { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r320 { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r321 { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r325 { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r326 { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r327 { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r329 { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r330 { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r331 { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r332 { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public RichTextBlock RichTextBlock { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public RichTextBlock RichTextBlock_2 { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public void HighlightRegion(FName namesd)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, namesd);
            CallRaw("HighlightRegion", __pb.Bytes);
        }
        public void ClearHighlight()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearHighlight", __pb.Bytes);
        }
    }

}
