// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Content_ShootingRange_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Content_ShootingRange_BP_C : UI_PauseMenu_Content_Trifold_Base_BP_C
    {
        public const string UeClassName = "UI_PauseMenu_Content_ShootingRange_BP_C";
        public UI_PauseMenu_Content_ShootingRange_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Content_ShootingRange_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Content_ShootingRange_BP_C(p);
        public static UI_PauseMenu_Content_ShootingRange_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Content_ShootingRange_BP_C(o.Pointer); }
        public static UI_PauseMenu_Content_ShootingRange_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Content_ShootingRange_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Content_ShootingRange_BP_C(a[i].Pointer); return r; }
    }

}
