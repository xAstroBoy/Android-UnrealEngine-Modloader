// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Inventory/InventoryScreen_LeonDisplay_BP
using System;

namespace UEModLoader.Game
{
    public class InventoryScreen_LeonDisplay_BP_C : Actor
    {
        public const string UeClassName = "InventoryScreen_LeonDisplay_BP_C";
        public InventoryScreen_LeonDisplay_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new InventoryScreen_LeonDisplay_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new InventoryScreen_LeonDisplay_BP_C(p);
        public static InventoryScreen_LeonDisplay_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InventoryScreen_LeonDisplay_BP_C(o.Pointer); }
        public static InventoryScreen_LeonDisplay_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InventoryScreen_LeonDisplay_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InventoryScreen_LeonDisplay_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public PointLightComponent Result_AdaLight_03 { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_AdaLight_02 { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_AdaLight_01 { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_LeonLight_02 { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_LeonLight_01 { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_WeskerLight_02 { get { var __p = GetAt<System.IntPtr>(0x250); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x250, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_WeskerLight_01 { get { var __p = GetAt<System.IntPtr>(0x258); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x258, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_KrauserLight_04 { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_KrauserLight_03 { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_KrauserLight_02 { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_KrauserLight_01 { get { var __p = GetAt<System.IntPtr>(0x278); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x278, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_HunkLight_03 { get { var __p = GetAt<System.IntPtr>(0x280); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x280, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_HunkLight_02 { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Result_HunkLight_01 { get { var __p = GetAt<System.IntPtr>(0x290); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x290, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ResultLights_Wesker { get { var __p = GetAt<System.IntPtr>(0x298); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x298, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ResultLights_Hunk { get { var __p = GetAt<System.IntPtr>(0x2A0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2A0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ResultLights_Krauser { get { var __p = GetAt<System.IntPtr>(0x2A8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2A8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ResultLights_Ada { get { var __p = GetAt<System.IntPtr>(0x2B0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2B0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ResultLights_Leon { get { var __p = GetAt<System.IntPtr>(0x2B8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2B8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent ResultLights { get { var __p = GetAt<System.IntPtr>(0x2C0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2C0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_LeonLight_05 { get { var __p = GetAt<System.IntPtr>(0x2C8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x2C8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_LeonLight_06 { get { var __p = GetAt<System.IntPtr>(0x2D0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x2D0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_WeskerLight_02 { get { var __p = GetAt<System.IntPtr>(0x2D8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_WeskerLight_01 { get { var __p = GetAt<System.IntPtr>(0x2E0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x2E0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_KrauserLight_04 { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_KrauserLight_03 { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_KrauserLight_02 { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_KrauserLight_01 { get { var __p = GetAt<System.IntPtr>(0x300); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x300, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_HunkLight_03 { get { var __p = GetAt<System.IntPtr>(0x308); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x308, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_HunkLight_02 { get { var __p = GetAt<System.IntPtr>(0x310); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x310, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_HunkLight_01 { get { var __p = GetAt<System.IntPtr>(0x318); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x318, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_AdaLight_03 { get { var __p = GetAt<System.IntPtr>(0x320); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x320, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_AdaLight_02 { get { var __p = GetAt<System.IntPtr>(0x328); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x328, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Merc_Inv_AdaLight_01 { get { var __p = GetAt<System.IntPtr>(0x330); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x330, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Merc_Inv_Wesker { get { var __p = GetAt<System.IntPtr>(0x338); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x338, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Merc_Inv_Krauser { get { var __p = GetAt<System.IntPtr>(0x340); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x340, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Merc_Inv_Hunk { get { var __p = GetAt<System.IntPtr>(0x348); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x348, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Merc_Inv_Ada { get { var __p = GetAt<System.IntPtr>(0x350); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x350, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Merc_Inv_Leon { get { var __p = GetAt<System.IntPtr>(0x358); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x358, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent MercInventoryLights { get { var __p = GetAt<System.IntPtr>(0x360); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x360, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_KrauserLight_07 { get { var __p = GetAt<System.IntPtr>(0x368); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x368, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_KrauserLight_010 { get { var __p = GetAt<System.IntPtr>(0x370); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x370, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_KrauserLight_09 { get { var __p = GetAt<System.IntPtr>(0x378); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x378, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_KrauserLight_08 { get { var __p = GetAt<System.IntPtr>(0x380); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x380, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_HunkLight_07 { get { var __p = GetAt<System.IntPtr>(0x388); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x388, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_HunkLight_09 { get { var __p = GetAt<System.IntPtr>(0x390); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x390, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_HunkLight_08 { get { var __p = GetAt<System.IntPtr>(0x398); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x398, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_AdaLight_06 { get { var __p = GetAt<System.IntPtr>(0x3A0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3A0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_AdaLight_08 { get { var __p = GetAt<System.IntPtr>(0x3A8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3A8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_AdaLight_07 { get { var __p = GetAt<System.IntPtr>(0x3B0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3B0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_WeskerLight_02 { get { var __p = GetAt<System.IntPtr>(0x3B8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3B8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_WeskerLight_01 { get { var __p = GetAt<System.IntPtr>(0x3C0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3C0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_AdaLight_03 { get { var __p = GetAt<System.IntPtr>(0x3C8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3C8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_AdaLight_02 { get { var __p = GetAt<System.IntPtr>(0x3D0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3D0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_AdaLight_01 { get { var __p = GetAt<System.IntPtr>(0x3D8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3D8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent StartMatch_Ada { get { var __p = GetAt<System.IntPtr>(0x3E0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x3E0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_LeonLight_02 { get { var __p = GetAt<System.IntPtr>(0x3E8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3E8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_LeonLight_01 { get { var __p = GetAt<System.IntPtr>(0x3F0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x3F0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent StartMatch_Leon { get { var __p = GetAt<System.IntPtr>(0x3F8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x3F8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent StartMatch_Wesker { get { var __p = GetAt<System.IntPtr>(0x400); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x400, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_KrauserLight_04 { get { var __p = GetAt<System.IntPtr>(0x408); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x408, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_KrauserLight_03 { get { var __p = GetAt<System.IntPtr>(0x410); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x410, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_KrauserLight_02 { get { var __p = GetAt<System.IntPtr>(0x418); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x418, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_KrauserLight_01 { get { var __p = GetAt<System.IntPtr>(0x420); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x420, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent StartMatch_Krauser { get { var __p = GetAt<System.IntPtr>(0x428); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x428, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_HunkLight_03 { get { var __p = GetAt<System.IntPtr>(0x430); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x430, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_HunkLight_02 { get { var __p = GetAt<System.IntPtr>(0x438); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x438, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent StartMatch_HunkLight_01 { get { var __p = GetAt<System.IntPtr>(0x440); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x440, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent StartMatch_Hunk { get { var __p = GetAt<System.IntPtr>(0x448); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x448, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneCaptureComponent2D CaptureComponent_StartScreen { get { var __p = GetAt<System.IntPtr>(0x450); return __p==System.IntPtr.Zero?null:new SceneCaptureComponent2D(__p); } set => SetAt(0x450, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneCaptureComponent2D CaptureComponent_MercenariesResults { get { var __p = GetAt<System.IntPtr>(0x458); return __p==System.IntPtr.Zero?null:new SceneCaptureComponent2D(__p); } set => SetAt(0x458, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent StartMatchSelectLights { get { var __p = GetAt<System.IntPtr>(0x460); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x460, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_KrauserLight_01 { get { var __p = GetAt<System.IntPtr>(0x468); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x468, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Unlock_Krauser { get { var __p = GetAt<System.IntPtr>(0x470); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x470, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_KrauserLight_02 { get { var __p = GetAt<System.IntPtr>(0x478); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x478, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_HunkLight_06 { get { var __p = GetAt<System.IntPtr>(0x480); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x480, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_KrauserLight_06 { get { var __p = GetAt<System.IntPtr>(0x488); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x488, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_KrauserLight_05 { get { var __p = GetAt<System.IntPtr>(0x490); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x490, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_HunkLight_05 { get { var __p = GetAt<System.IntPtr>(0x498); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x498, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_AdaLight_05 { get { var __p = GetAt<System.IntPtr>(0x4A0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4A0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_AdaLight_05 { get { var __p = GetAt<System.IntPtr>(0x4A8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4A8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_AdaLight_06 { get { var __p = GetAt<System.IntPtr>(0x4B0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4B0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_HunkLight_04 { get { var __p = GetAt<System.IntPtr>(0x4B8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4B8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_LeonLight_04 { get { var __p = GetAt<System.IntPtr>(0x4C0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4C0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_LeonLight_03 { get { var __p = GetAt<System.IntPtr>(0x4C8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4C8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_LeonLight_02 { get { var __p = GetAt<System.IntPtr>(0x4D0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4D0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_AdaLight_04 { get { var __p = GetAt<System.IntPtr>(0x4D8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4D8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_AdaLight_03 { get { var __p = GetAt<System.IntPtr>(0x4E0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4E0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_HunkLight_03 { get { var __p = GetAt<System.IntPtr>(0x4E8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4E8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Char_Ada { get { var __p = GetAt<System.IntPtr>(0x4F0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x4F0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_KrauserLight_04 { get { var __p = GetAt<System.IntPtr>(0x4F8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x4F8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_KrauserLight_03 { get { var __p = GetAt<System.IntPtr>(0x500); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x500, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_WeskerLight_04 { get { var __p = GetAt<System.IntPtr>(0x508); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x508, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Char_WeskerLight_03 { get { var __p = GetAt<System.IntPtr>(0x510); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x510, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Char_Leon { get { var __p = GetAt<System.IntPtr>(0x518); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x518, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Char_Wesker { get { var __p = GetAt<System.IntPtr>(0x520); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x520, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Char_Krauser { get { var __p = GetAt<System.IntPtr>(0x528); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x528, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Char_Hunk { get { var __p = GetAt<System.IntPtr>(0x530); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x530, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Inv_Leon { get { var __p = GetAt<System.IntPtr>(0x538); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x538, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_WeskerLight_02 { get { var __p = GetAt<System.IntPtr>(0x540); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x540, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_WeskerLight_01 { get { var __p = GetAt<System.IntPtr>(0x548); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x548, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Inv_Wesker { get { var __p = GetAt<System.IntPtr>(0x550); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x550, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Inv_Krauser { get { var __p = GetAt<System.IntPtr>(0x558); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x558, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Inv_HUNK { get { var __p = GetAt<System.IntPtr>(0x560); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x560, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Inv_Ada { get { var __p = GetAt<System.IntPtr>(0x568); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x568, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Inv_LeonLight_01 { get { var __p = GetAt<System.IntPtr>(0x570); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x570, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_WeskerLight_01 { get { var __p = GetAt<System.IntPtr>(0x578); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x578, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_HunkLight_01 { get { var __p = GetAt<System.IntPtr>(0x580); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x580, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent InventoryLights { get { var __p = GetAt<System.IntPtr>(0x588); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x588, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent CharacterSelectLights { get { var __p = GetAt<System.IntPtr>(0x590); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x590, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_AdaLight_01 { get { var __p = GetAt<System.IntPtr>(0x598); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x598, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent UnlockLights { get { var __p = GetAt<System.IntPtr>(0x5A0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x5A0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_HunkLight_02 { get { var __p = GetAt<System.IntPtr>(0x5A8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x5A8, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_HunkLight_03 { get { var __p = GetAt<System.IntPtr>(0x5B0); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x5B0, value?.Pointer ?? System.IntPtr.Zero); }
        public PointLightComponent Unlock_WeskerLight_02 { get { var __p = GetAt<System.IntPtr>(0x5B8); return __p==System.IntPtr.Zero?null:new PointLightComponent(__p); } set => SetAt(0x5B8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent PlayerRoot { get { var __p = GetAt<System.IntPtr>(0x5C0); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x5C0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent PlayerMover { get { var __p = GetAt<System.IntPtr>(0x5C8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x5C8, value?.Pointer ?? System.IntPtr.Zero); }
        public ParticleSystemComponent ParticleSystem { get { var __p = GetAt<System.IntPtr>(0x5D0); return __p==System.IntPtr.Zero?null:new ParticleSystemComponent(__p); } set => SetAt(0x5D0, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneCaptureComponent2D CaptureComponent_CharacterUnlock { get { var __p = GetAt<System.IntPtr>(0x5D8); return __p==System.IntPtr.Zero?null:new SceneCaptureComponent2D(__p); } set => SetAt(0x5D8, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent Map_Mark { get { var __p = GetAt<System.IntPtr>(0x5E0); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x5E0, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent WeaponMesh { get { var __p = GetAt<System.IntPtr>(0x5E8); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x5E8, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneCaptureComponent2D CaptureComponent { get { var __p = GetAt<System.IntPtr>(0x5F0); return __p==System.IntPtr.Zero?null:new SceneCaptureComponent2D(__p); } set => SetAt(0x5F0, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent Face { get { var __p = GetAt<System.IntPtr>(0x5F8); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x5F8, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent Jacket { get { var __p = GetAt<System.IntPtr>(0x600); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x600, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent StaticWeaponMesh { get { var __p = GetAt<System.IntPtr>(0x608); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x608, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent Body { get { var __p = GetAt<System.IntPtr>(0x610); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x610, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent Eyes { get { var __p = GetAt<System.IntPtr>(0x618); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x618, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent Hair { get { var __p = GetAt<System.IntPtr>(0x620); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x620, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent Head { get { var __p = GetAt<System.IntPtr>(0x628); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x628, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent RightHand { get { var __p = GetAt<System.IntPtr>(0x630); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x630, value?.Pointer ?? System.IntPtr.Zero); }
        public SkeletalMeshComponent LeftHand { get { var __p = GetAt<System.IntPtr>(0x638); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x638, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Root { get { var __p = GetAt<System.IntPtr>(0x640); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x640, value?.Pointer ?? System.IntPtr.Zero); }
        public bool IsAshley { get => Native.GetPropBool(Pointer, "IsAshley"); set => Native.SetPropBool(Pointer, "IsAshley", value); }
        public EPropSlot CurrentSlot { get => (EPropSlot)GetAt<byte>(0x649); set => SetAt(0x649, (byte)value); }
        public int CurrentItemId { get => GetAt<int>(0x64C); set => SetAt(0x64C, value); }
        public int CurrentLoadingItemID { get => GetAt<int>(0x650); set => SetAt(0x650, value); }
        public VR4InventoryPoseTableRow CurrentlyLoadingRow => new VR4InventoryPoseTableRow(AddrOf(0x658));
        public int QueuedItemID { get => GetAt<int>(0x788); set => SetAt(0x788, value); }
        public TArray<System.IntPtr> LeonCostumes => new TArray<System.IntPtr>(AddrOf(0x790)); // TArray<struct>
        public TArray<System.IntPtr> AshleyCostumes => new TArray<System.IntPtr>(AddrOf(0x7A0)); // TArray<struct>
        public int TestCharacter { get => GetAt<int>(0x7B0); set => SetAt(0x7B0, value); }
        public int TestCostume { get => GetAt<int>(0x7B4); set => SetAt(0x7B4, value); }
        public TArray<System.IntPtr> ComponentStates => new TArray<System.IntPtr>(AddrOf(0x7B8)); // TArray<struct>
        public System.IntPtr CurrentCostume => AddrOf(0x7C8); // struct CostumePieces
        public bool IsMercenaries { get => Native.GetPropBool(Pointer, "IsMercenaries"); set => Native.SetPropBool(Pointer, "IsMercenaries", value); }
        public System.IntPtr MercenariesPoses => AddrOf(0x810); // 
        public EBio4PlayerType CurrentMercenary { get => (EBio4PlayerType)GetAt<byte>(0x860); set => SetAt(0x860, (byte)value); }
        public int CaptureDelay { get => GetAt<int>(0x864); set => SetAt(0x864, value); }
        public TArray<System.IntPtr> AdaCostumes => new TArray<System.IntPtr>(AddrOf(0x868)); // TArray<struct>
        public TArray<System.IntPtr> HunkCostumes => new TArray<System.IntPtr>(AddrOf(0x878)); // TArray<struct>
        public TArray<System.IntPtr> KrauserCostumes => new TArray<System.IntPtr>(AddrOf(0x888)); // TArray<struct>
        public TArray<System.IntPtr> WeskerCostumes => new TArray<System.IntPtr>(AddrOf(0x898)); // TArray<struct>
        public int CurrentCharacter { get => GetAt<int>(0x8A8); set => SetAt(0x8A8, value); }
        public bool IsCharacterUnlock { get => Native.GetPropBool(Pointer, "IsCharacterUnlock"); set => Native.SetPropBool(Pointer, "IsCharacterUnlock", value); }
        public int CurrentMercenaryCostume { get => GetAt<int>(0x8B0); set => SetAt(0x8B0, value); }
        public System.IntPtr DefaultMercenariesCostumes => AddrOf(0x8B8); // 
        public Transform CameraAda => new Transform(AddrOf(0x910));
        public Transform CameraKrauser => new Transform(AddrOf(0x940));
        public Transform CameraHUNK => new Transform(AddrOf(0x970));
        public Transform CameraWesker => new Transform(AddrOf(0x9A0));
        public int CurrentCharacterCostume { get => GetAt<int>(0x9D0); set => SetAt(0x9D0, value); }
        public bool IsMercenariesResults { get => Native.GetPropBool(Pointer, "IsMercenariesResults"); set => Native.SetPropBool(Pointer, "IsMercenariesResults", value); }
        public bool StartScreenActive { get => Native.GetPropBool(Pointer, "StartScreenActive"); set => Native.SetPropBool(Pointer, "StartScreenActive", value); }
        public bool IsMercenariesCreateGame { get => Native.GetPropBool(Pointer, "IsMercenariesCreateGame"); set => Native.SetPropBool(Pointer, "IsMercenariesCreateGame", value); }
        public bool StaticUsingGoldenGunsMaterials { get => Native.GetPropBool(Pointer, "StaticUsingGoldenGunsMaterials"); set => Native.SetPropBool(Pointer, "StaticUsingGoldenGunsMaterials", value); }
        public bool UsingGoldenGunsMaterials { get => Native.GetPropBool(Pointer, "UsingGoldenGunsMaterials"); set => Native.SetPropBool(Pointer, "UsingGoldenGunsMaterials", value); }
        public TArray<System.IntPtr> vOriginalMaterials => new TArray<System.IntPtr>(AddrOf(0x9E0)); // TArray<UObject*>
        public TArray<System.IntPtr> vOriginalStaticMaterials => new TArray<System.IntPtr>(AddrOf(0x9F0)); // TArray<UObject*>
        public bool Active { get => Native.GetPropBool(Pointer, "Active"); set => Native.SetPropBool(Pointer, "Active", value); }
        public void IsParentComponentHidden(Actor Actor, bool Hidden)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, Actor);
            __pb.Set<byte>(0x8, (byte)(Hidden?1:0));
            CallRaw("IsParentComponentHidden", __pb.Bytes);
        }
        public void IsHidden(bool Hidden)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Hidden?1:0));
            CallRaw("IsHidden", __pb.Bytes);
        }
        public void ClearGoldenGunMaterials()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearGoldenGunMaterials", __pb.Bytes);
        }
        public void GetGoldenGunMaterials(System.IntPtr Materials)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, Materials);
            CallRaw("GetGoldenGunMaterials", __pb.Bytes);
        }
        public void SetUsingOverrideMaterials(MeshComponent MeshComp, bool UsingOverride, System.IntPtr Original, System.IntPtr GoldenGun, bool ShouldUse)
        {
            var __pb = new ParamBuffer(73);
            __pb.SetObject(0x0, MeshComp);
            __pb.Set<byte>(0x8, (byte)(UsingOverride?1:0));
            __pb.Set<System.IntPtr>(0x10, Original);
            __pb.Set<System.IntPtr>(0x20, GoldenGun);
            __pb.Set<byte>(0x48, (byte)(ShouldUse?1:0));
            CallRaw("SetUsingOverrideMaterials", __pb.Bytes);
        }
        public void UpdateGoldenGunMaterials(bool Clear)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Clear?1:0));
            CallRaw("UpdateGoldenGunMaterials", __pb.Bytes);
        }
        public void SwapToStartScreen(bool StartScreenActive)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(StartScreenActive?1:0));
            CallRaw("SwapToStartScreen", __pb.Bytes);
        }
        public void SetParticleTemplate(ParticleSystem NewTemplate)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewTemplate);
            CallRaw("SetParticleTemplate", __pb.Bytes);
        }
        public void Set_To_MercenariesResults()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Set To MercenariesResults", __pb.Bytes);
        }
        public void FilterValidCostumes(int costume, EBio4PlayerType Character, int OutCostume)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, costume);
            __pb.Set<byte>(0x4, (byte)Character);
            __pb.Set(0x8, OutCostume);
            CallRaw("FilterValidCostumes", __pb.Bytes);
        }
        public void ConfigureLights(EBio4PlayerType PlayerType)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)PlayerType);
            CallRaw("ConfigureLights", __pb.Bytes);
        }
        public void SetToDefaultMercenariesCostume()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetToDefaultMercenariesCostume", __pb.Bytes);
        }
        public void Set_To_Character_Unlock(EBio4PlayerType Type)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Type);
            CallRaw("Set To Character Unlock", __pb.Bytes);
        }
        public void Set_To_Mercenaries_Character(EBio4PlayerType Type, bool Force)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)Type);
            __pb.Set<byte>(0x1, (byte)(Force?1:0));
            CallRaw("Set To Mercenaries Character", __pb.Bytes);
        }
        public void SetComponentLoaded(byte component, bool loaded, Object Object)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, component);
            __pb.Set<byte>(0x1, (byte)(loaded?1:0));
            __pb.SetObject(0x8, Object);
            CallRaw("SetComponentLoaded", __pb.Bytes);
        }
        public void SetComponentSoftObject(byte component, System.IntPtr SoftObject)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set(0x0, component);
            __pb.Set<System.IntPtr>(0x8, SoftObject);
            CallRaw("SetComponentSoftObject", __pb.Bytes);
        }
        public void ClearComponentStates()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearComponentStates", __pb.Bytes);
        }
        public void FindComponentByObject(Object Object, byte component, bool Found)
        {
            var __pb = new ParamBuffer(10);
            __pb.SetObject(0x0, Object);
            __pb.Set(0x8, component);
            __pb.Set<byte>(0x9, (byte)(Found?1:0));
            CallRaw("FindComponentByObject", __pb.Bytes);
        }
        public void GetComponentObject(byte component, Object Object)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, component);
            __pb.SetObject(0x8, Object);
            CallRaw("GetComponentObject", __pb.Bytes);
        }
        public void UpdatePoseMeshes()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdatePoseMeshes", __pb.Bytes);
        }
        public void CheckIfFinishedLoading()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("CheckIfFinishedLoading", __pb.Bytes);
        }
        public void SetToCharacter(int Type, int costume)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Type);
            __pb.Set(0x4, costume);
            CallRaw("SetToCharacter", __pb.Bytes);
        }
        public void SetToCostumePieces(System.IntPtr costume)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, costume);
            CallRaw("SetToCostumePieces", __pb.Bytes);
        }
        public void InitializeCostume(bool success)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(success?1:0));
            CallRaw("InitializeCostume", __pb.Bytes);
        }
        public void UserConstructionScript()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UserConstructionScript", __pb.Bytes);
        }
        public void OnLoaded_EB38EF22444CC43F347DB3B0DD753AF5(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_EB38EF22444CC43F347DB3B0DD753AF5", __pb.Bytes);
        }
        public void OnLoaded_84A256D04DE747D18A5DA8925247A2A9(Object loaded)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, loaded);
            CallRaw("OnLoaded_84A256D04DE747D18A5DA8925247A2A9", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void LoadPose(int ItemId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ItemId);
            CallRaw("LoadPose", __pb.Bytes);
        }
        public void ItemEquipped(int ItemId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ItemId);
            CallRaw("ItemEquipped", __pb.Bytes);
        }
        public void ItemUnequipped(int ItemId)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, ItemId);
            CallRaw("ItemUnequipped", __pb.Bytes);
        }
        public void InitializePose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializePose", __pb.Bytes);
        }
        public void FinishLoadingLeonAnimation()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("FinishLoadingLeonAnimation", __pb.Bytes);
        }
        public void UpdatePose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UpdatePose", __pb.Bytes);
        }
        public void LoadAshleyPose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("LoadAshleyPose", __pb.Bytes);
        }
        public void DoAsyncLoad(byte component, VR4InventoryPoseTableRow row)
        {
            var __pb = new ParamBuffer(312);
            __pb.Set(0x0, component);
            __pb.Set<System.IntPtr>(0x8, row);
            CallRaw("DoAsyncLoad", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void DeactivateCapture()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DeactivateCapture", __pb.Bytes);
        }
        public void ActivateCapture()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ActivateCapture", __pb.Bytes);
        }
        public void OnPlayerSettingsChanged(Object Sender, VR4EventBasePayload payload)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Sender);
            __pb.SetObject(0x8, payload);
            CallRaw("OnPlayerSettingsChanged", __pb.Bytes);
        }
        public void ExecuteUbergraph_InventoryScreen_LeonDisplay_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_InventoryScreen_LeonDisplay_BP", __pb.Bytes);
        }
    }

}
