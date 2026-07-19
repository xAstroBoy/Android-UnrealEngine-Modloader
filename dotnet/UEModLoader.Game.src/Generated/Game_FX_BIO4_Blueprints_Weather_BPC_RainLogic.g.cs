// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/FX/BIO4/Blueprints/Weather/BPC_RainLogic
using System;

namespace UEModLoader.Game
{
    public class BPC_RainLogic_C : ActorComponent
    {
        public const string UeClassName = "BPC_RainLogic_C";
        public BPC_RainLogic_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new BPC_RainLogic_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new BPC_RainLogic_C(p);
        public static BPC_RainLogic_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BPC_RainLogic_C(o.Pointer); }
        public static BPC_RainLogic_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BPC_RainLogic_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BPC_RainLogic_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0xB0));
        public void UpdateMaterialParams(ParticleSystemComponent ParticleSystem, int MaterialIndex, global::System.IntPtr RoomInfo)
        {
            var __pb = new ParamBuffer(52);
            __pb.SetObject(0x0, ParticleSystem);
            __pb.Set(0x8, MaterialIndex);
            __pb.Set<global::System.IntPtr>(0xC, RoomInfo);
            CallRaw("UpdateMaterialParams", __pb.Bytes);
        }
        public void CreateDynamicMaterials(ParticleSystemComponent ParticleSystem, int MaterialIndex)
        {
            var __pb = new ParamBuffer(12);
            __pb.SetObject(0x0, ParticleSystem);
            __pb.Set(0x8, MaterialIndex);
            CallRaw("CreateDynamicMaterials", __pb.Bytes);
        }
        public void UpdateRain(ParticleSystemComponent ParticleSystem)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, ParticleSystem);
            CallRaw("UpdateRain", __pb.Bytes);
        }
        public void ExecuteUbergraph_BPC_RainLogic(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_BPC_RainLogic", __pb.Bytes);
        }
    }

}
