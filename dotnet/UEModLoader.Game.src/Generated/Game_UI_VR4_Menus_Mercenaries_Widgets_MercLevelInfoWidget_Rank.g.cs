// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/Mercenaries/Widgets/MercLevelInfoWidget_Rank
using System;

namespace UEModLoader.Game
{
    public class MercLevelInfoWidget_Rank_C : UserWidget
    {
        public const string UeClassName = "MercLevelInfoWidget_Rank_C";
        public MercLevelInfoWidget_Rank_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new MercLevelInfoWidget_Rank_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MercLevelInfoWidget_Rank_C(p);
        public static MercLevelInfoWidget_Rank_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MercLevelInfoWidget_Rank_C(o.Pointer); }
        public static MercLevelInfoWidget_Rank_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MercLevelInfoWidget_Rank_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MercLevelInfoWidget_Rank_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x230));
        public Image Empty { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Image Filled { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new Image(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool UseChallengeIcons { get => Native.GetPropBool(Pointer, "UseChallengeIcons"); set => Native.SetPropBool(Pointer, "UseChallengeIcons", value); }
        public bool HUD { get => Native.GetPropBool(Pointer, "HUD"); set => Native.SetPropBool(Pointer, "HUD", value); }
        public void SetFillState(bool IsFilled)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsFilled?1:0));
            CallRaw("SetFillState", __pb.Bytes);
        }
        public void UpdateStyle(bool UseChallengeIcons, bool UseHUD)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(UseChallengeIcons?1:0));
            __pb.Set<byte>(0x1, (byte)(UseHUD?1:0));
            CallRaw("UpdateStyle", __pb.Bytes);
        }
        public void PreConstruct(bool IsDesignTime)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(IsDesignTime?1:0));
            CallRaw("PreConstruct", __pb.Bytes);
        }
        public void ExecuteUbergraph_MercLevelInfoWidget_Rank(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_MercLevelInfoWidget_Rank", __pb.Bytes);
        }
    }

}
