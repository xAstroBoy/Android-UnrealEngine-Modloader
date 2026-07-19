// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/PauseMenu/KeysAndTreasures/Buttons/UI_KeysTreasures_Grab_Button_BP
using System;

namespace UEModLoader.Game
{
    public class UI_KeysTreasures_Grab_Button_BP_C : UI_Button_BP_C
    {
        public const string UeClassName = "UI_KeysTreasures_Grab_Button_BP_C";
        public UI_KeysTreasures_Grab_Button_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_KeysTreasures_Grab_Button_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_KeysTreasures_Grab_Button_BP_C(p);
        public static UI_KeysTreasures_Grab_Button_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_KeysTreasures_Grab_Button_BP_C(o.Pointer); }
        public static UI_KeysTreasures_Grab_Button_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_KeysTreasures_Grab_Button_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_KeysTreasures_Grab_Button_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x308));
        public Vector2D Size => new Vector2D(AddrOf(0x310));
        public void Construct()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Construct", __pb.Bytes);
        }
        public void UserConstructionScript()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("UserConstructionScript", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_KeysTreasures_Grab_Button_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_KeysTreasures_Grab_Button_BP", __pb.Bytes);
        }
    }

}
