// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Unlocks/UI_Unlocks_Widget
using System;

namespace UEModLoader.Game
{
    public class UI_Unlocks_Widget_C : UserWidget
    {
        public const string UeClassName = "UI_Unlocks_Widget_C";
        public UI_Unlocks_Widget_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Unlocks_Widget_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Unlocks_Widget_C(p);
        public static UI_Unlocks_Widget_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Unlocks_Widget_C(o.Pointer); }
        public static UI_Unlocks_Widget_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Unlocks_Widget_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Unlocks_Widget_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image Black_Fade { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public Image Image_BG { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_CenterBox { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public TextBlock Text_LowerBox { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new TextBlock(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public System.IntPtr LastUnlockShown => AddrOf(0x258); // 
        public int CurrentUnlockIndex { get => GetAt<int>(0x268); set => SetAt(0x268, value); }
        public System.IntPtr CurrentUnlocksMap => AddrOf(0x270); // 
        public int MapLength { get => GetAt<int>(0x2C0); set => SetAt(0x2C0, value); }
        public System.IntPtr NewUnlockShown => AddrOf(0x2C8); // 
        public void HasUnlocks_(bool UnlocksExist)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(UnlocksExist?1:0));
            CallRaw("HasUnlocks?", __pb.Bytes);
        }
        public void GetPrereqs(int Length)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Length);
            CallRaw("GetPrereqs", __pb.Bytes);
        }
        public void IncrementUnlocks()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IncrementUnlocks", __pb.Bytes);
        }
        public void SetDisplayEntryByIndex(int Index)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Index);
            CallRaw("SetDisplayEntryByIndex", __pb.Bytes);
        }
        public void SetDisplayEntryByName(FName RowName)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, RowName);
            CallRaw("SetDisplayEntryByName", __pb.Bytes);
        }
        public void ShowFirstUnlock()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowFirstUnlock", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Unlocks_Widget(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Unlocks_Widget", __pb.Bytes);
        }
        public void NewUnlockShown__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("NewUnlockShown__DelegateSignature", __pb.Bytes);
        }
        public void LastUnlockShown__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("LastUnlockShown__DelegateSignature", __pb.Bytes);
        }
    }

}
