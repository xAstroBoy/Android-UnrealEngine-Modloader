// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/RichTextDecoraterMerc
using System;

namespace UEModLoader.Game
{
    public class RichTextDecoraterMerc_C : RichTextBlockImageDecorator
    {
        public const string UeClassName = "RichTextDecoraterMerc_C";
        public RichTextDecoraterMerc_C(System.IntPtr ptr) : base(ptr) {}
        public static new RichTextDecoraterMerc_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RichTextDecoraterMerc_C(p);
        public static RichTextDecoraterMerc_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RichTextDecoraterMerc_C(o.Pointer); }
        public static RichTextDecoraterMerc_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RichTextDecoraterMerc_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RichTextDecoraterMerc_C(a[i].Pointer); return r; }
    }

}
