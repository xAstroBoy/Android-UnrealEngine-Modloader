// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Fx/Mercenaries_Skybox_lightning_BP
using System;

namespace UEModLoader.Game
{
    public class Mercenaries_Skybox_lightning_BP_C : Skybox_lightning_BP_C
    {
        public const string UeClassName = "Mercenaries_Skybox_lightning_BP_C";
        public Mercenaries_Skybox_lightning_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new Mercenaries_Skybox_lightning_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Mercenaries_Skybox_lightning_BP_C(p);
        public static Mercenaries_Skybox_lightning_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Mercenaries_Skybox_lightning_BP_C(o.Pointer); }
        public static Mercenaries_Skybox_lightning_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Mercenaries_Skybox_lightning_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Mercenaries_Skybox_lightning_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x288));
        public MaterialInstance StormSkyMaterial { get { var __p = GetAt<global::System.IntPtr>(0x290); return __p==global::System.IntPtr.Zero?null:new MaterialInstance(__p); } set => SetAt(0x290, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void Storm()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Storm", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_Mercenaries_Skybox_lightning_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Mercenaries_Skybox_lightning_BP", __pb.Bytes);
        }
    }

}
