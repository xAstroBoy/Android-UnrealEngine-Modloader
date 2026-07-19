// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Props/Items/Utilities/ItemThumbnailWidget
using System;

namespace UEModLoader.Game
{
    public class ItemThumbnailWidget_C : UserWidget
    {
        public const string UeClassName = "ItemThumbnailWidget_C";
        public ItemThumbnailWidget_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new ItemThumbnailWidget_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new ItemThumbnailWidget_C(p);
        public static ItemThumbnailWidget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ItemThumbnailWidget_C(o.Pointer); }
        public static ItemThumbnailWidget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ItemThumbnailWidget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ItemThumbnailWidget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image Image { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SizeBox QuestionMark { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new SizeBox(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TextBlock TextBlock { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void ShowQuestMark(bool Show)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            CallRaw("ShowQuestMark", __pb.Bytes);
        }
        public void ExecuteUbergraph_ItemThumbnailWidget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_ItemThumbnailWidget", __pb.Bytes);
        }
    }

}
