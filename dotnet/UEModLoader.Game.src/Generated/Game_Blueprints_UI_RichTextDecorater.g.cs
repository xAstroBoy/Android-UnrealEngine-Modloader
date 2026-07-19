// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/RichTextDecorater
using System;

namespace UEModLoader.Game
{
    public class RichTextDecorater_C : RichTextBlockImageDecorator
    {
        public const string UeClassName = "RichTextDecorater_C";
        public RichTextDecorater_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new RichTextDecorater_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new RichTextDecorater_C(p);
        public static RichTextDecorater_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RichTextDecorater_C(o.Pointer); }
        public static RichTextDecorater_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RichTextDecorater_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RichTextDecorater_C(a[i].Pointer); return r; }
    }

}
