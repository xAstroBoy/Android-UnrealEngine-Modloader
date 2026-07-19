// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Debug/DebugMenu/DebugMap/stage2debugmap
using System;

namespace UEModLoader.Game
{
    public class stage2debugmap_C : UserWidget
    {
        public const string UeClassName = "stage2debugmap_C";
        public stage2debugmap_C(System.IntPtr ptr) : base(ptr) {}
        public static new stage2debugmap_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new stage2debugmap_C(p);
        public static stage2debugmap_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new stage2debugmap_C(o.Pointer); }
        public static stage2debugmap_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new stage2debugmap_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new stage2debugmap_C(a[i].Pointer); return r; }
        public Image r200 { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r201 { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r202 { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r203 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r204 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r205 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r206 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r207 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r208 { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r209 { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r20a { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r20b { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r20c { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r20d { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r20e { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r20f { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r210 { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r211 { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r212 { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r213 { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r214 { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r215 { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r216 { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r217 { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r218 { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r219 { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r21a { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r21b { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r21d { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r220 { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r221 { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r222 { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r223 { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r224 { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r225 { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r226 { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r227 { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r228 { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r229 { get { var __p = GetAt<System.IntPtr>(0x360); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x360, value?.Pointer ?? System.IntPtr.Zero); }
        public Image r22a { get { var __p = GetAt<System.IntPtr>(0x368); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x368, value?.Pointer ?? System.IntPtr.Zero); }
        public RichTextBlock RichTextBlock { get { var __p = GetAt<System.IntPtr>(0x370); return __p==System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x370, value?.Pointer ?? System.IntPtr.Zero); }
        public RichTextBlock RichTextBlock_2 { get { var __p = GetAt<System.IntPtr>(0x378); return __p==System.IntPtr.Zero?null:new RichTextBlock(__p); } set => SetAt(0x378, value?.Pointer ?? System.IntPtr.Zero); }
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
