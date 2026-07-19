// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Common/Materials/MaterialBlueprints/CMN_PostProcessVariables
using System;

namespace UEModLoader.Game
{
    public class CMN_PostProcessVariables_C : Actor
    {
        public const string UeClassName = "CMN_PostProcessVariables_C";
        public CMN_PostProcessVariables_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new CMN_PostProcessVariables_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new CMN_PostProcessVariables_C(p);
        public static CMN_PostProcessVariables_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CMN_PostProcessVariables_C(o.Pointer); }
        public static CMN_PostProcessVariables_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CMN_PostProcessVariables_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CMN_PostProcessVariables_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public LinearColor Fog_Color => new LinearColor(AddrOf(0x230));
        public float Fog_Depth { get => GetAt<float>(0x240); set => SetAt(0x240, value); }
        public float Scene_Contrast { get => GetAt<float>(0x244); set => SetAt(0x244, value); }
        public float Scene_Color_Saturation { get => GetAt<float>(0x248); set => SetAt(0x248, value); }
        public float Fog_Opacity { get => GetAt<float>(0x24C); set => SetAt(0x24C, value); }
        public float Fog_Start_Distance { get => GetAt<float>(0x250); set => SetAt(0x250, value); }
        public float Ambient_Bounce_Color_Contribution { get => GetAt<float>(0x254); set => SetAt(0x254, value); }
        public float Base_Color_Contribution { get => GetAt<float>(0x258); set => SetAt(0x258, value); }
        public float NearFog { get => GetAt<float>(0x25C); set => SetAt(0x25C, value); }
        public float FarFog { get => GetAt<float>(0x260); set => SetAt(0x260, value); }
        public LinearColor DustParticleColor => new LinearColor(AddrOf(0x264));
        public void Get_Color_Saturation(float Scene_Color_Saturation)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Scene_Color_Saturation);
            CallRaw("Get Color Saturation", __pb.Bytes);
        }
        public void SetSceneVariablesMaster()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetSceneVariablesMaster", __pb.Bytes);
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
        public void ExecuteUbergraph_CMN_PostProcessVariables(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_CMN_PostProcessVariables", __pb.Bytes);
        }
    }

}
