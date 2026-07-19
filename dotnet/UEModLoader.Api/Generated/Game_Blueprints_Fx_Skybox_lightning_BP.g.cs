// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Fx/Skybox_lightning_BP
using System;

namespace UEModLoader.Game
{
    public class Skybox_lightning_BP_C : Actor
    {
        public const string UeClassName = "Skybox_lightning_BP_C";
        public Skybox_lightning_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new Skybox_lightning_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new Skybox_lightning_BP_C(p);
        public static Skybox_lightning_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Skybox_lightning_BP_C(o.Pointer); }
        public static Skybox_lightning_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Skybox_lightning_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Skybox_lightning_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public ArrowComponent LightDirectionArrow { get { var __p = GetAt<System.IntPtr>(0x228); return __p==System.IntPtr.Zero?null:new ArrowComponent(__p); } set => SetAt(0x228, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMeshComponent SkyboxMesh { get { var __p = GetAt<System.IntPtr>(0x230); return __p==System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? System.IntPtr.Zero); }
        public SpotLightComponent SpotLight { get { var __p = GetAt<System.IntPtr>(0x238); return __p==System.IntPtr.Zero?null:new SpotLightComponent(__p); } set => SetAt(0x238, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x240); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x240, value?.Pointer ?? System.IntPtr.Zero); }
        public MaterialInstanceDynamic SkyMaterial { get { var __p = GetAt<System.IntPtr>(0x248); return __p==System.IntPtr.Zero?null:new MaterialInstanceDynamic(__p); } set => SetAt(0x248, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> LightningLocations => new TArray<System.IntPtr>(AddrOf(0x250)); // TArray<struct>
        public int SpotLightScale { get => GetAt<int>(0x260); set => SetAt(0x260, value); }
        public float SpotLightDropOffRate { get => GetAt<float>(0x264); set => SetAt(0x264, value); }
        public int LifetimeSequenceIndex { get => GetAt<int>(0x268); set => SetAt(0x268, value); }
        public LinearColor lightningColor => new LinearColor(AddrOf(0x26C));
        public float LightningColorDropOffRate { get => GetAt<float>(0x27C); set => SetAt(0x27C, value); }
        public float LightningColorScale { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public bool UseSpotLight { get => Native.GetPropBool(Pointer, "UseSpotLight"); set => Native.SetPropBool(Pointer, "UseSpotLight", value); }
        public void SetLightningDirection()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetLightningDirection", __pb.Bytes);
        }
        public void ResetIntensity()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetIntensity", __pb.Bytes);
        }
        public void SetIntensity(float Intensity)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Intensity);
            CallRaw("SetIntensity", __pb.Bytes);
        }
        public void SetLightningLocation()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetLightningLocation", __pb.Bytes);
        }
        public void ReceiveTick(float DeltaSeconds)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, DeltaSeconds);
            CallRaw("ReceiveTick", __pb.Bytes);
        }
        public void SetLightningSwitch()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetLightningSwitch", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_Skybox_lightning_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_Skybox_lightning_BP", __pb.Bytes);
        }
    }

}
