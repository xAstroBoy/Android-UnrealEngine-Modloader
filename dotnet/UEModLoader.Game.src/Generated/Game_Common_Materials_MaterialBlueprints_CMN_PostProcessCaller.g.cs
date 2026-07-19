// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Common/Materials/MaterialBlueprints/CMN_PostProcessCaller
using System;

namespace UEModLoader.Game
{
    public class CMN_PostProcessCaller_C : BlueprintFunctionLibrary
    {
        public const string UeClassName = "CMN_PostProcessCaller_C";
        public CMN_PostProcessCaller_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new CMN_PostProcessCaller_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new CMN_PostProcessCaller_C(p);
        public static CMN_PostProcessCaller_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CMN_PostProcessCaller_C(o.Pointer); }
        public static CMN_PostProcessCaller_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CMN_PostProcessCaller_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CMN_PostProcessCaller_C(a[i].Pointer); return r; }
        public void GetRoomSaturation(Object Context, Object __WorldContext, float Scene_Color_Saturation)
        {
            var __pb = new ParamBuffer(20);
            __pb.SetObject(0x0, Context);
            __pb.SetObject(0x8, __WorldContext);
            __pb.Set(0x10, Scene_Color_Saturation);
            CallRaw("GetRoomSaturation", __pb.Bytes);
        }
        public void GetPostProcessActor(Object __WorldContext, CMN_PostProcessVariables_C AsCMN_Post_Process_Variables)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, __WorldContext);
            __pb.SetObject(0x8, AsCMN_Post_Process_Variables);
            CallRaw("GetPostProcessActor", __pb.Bytes);
        }
    }

}
