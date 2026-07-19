// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Utils/VR4Utils
using System;

namespace UEModLoader.Game
{
    public class VR4Utils_C : BlueprintFunctionLibrary
    {
        public const string UeClassName = "VR4Utils_C";
        public VR4Utils_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4Utils_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4Utils_C(p);
        public static VR4Utils_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4Utils_C(o.Pointer); }
        public static VR4Utils_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4Utils_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4Utils_C(a[i].Pointer); return r; }
        public void SetLaserColor(Object __WorldContext)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, __WorldContext);
            CallRaw("SetLaserColor", __pb.Bytes);
        }
        public void SetMeshTranslucentProp(PrimitiveComponent Mesh, int MaterialIndex, MaterialInterface TranslucentMaterial, bool IsMeshOpaque, Object __WorldContext, bool Succeeded)
        {
            var __pb = new ParamBuffer(41);
            __pb.SetObject(0x0, Mesh);
            __pb.Set(0x8, MaterialIndex);
            __pb.SetObject(0x10, TranslucentMaterial);
            __pb.Set<byte>(0x18, (byte)(IsMeshOpaque?1:0));
            __pb.SetObject(0x20, __WorldContext);
            __pb.Set<byte>(0x28, (byte)(Succeeded?1:0));
            CallRaw("SetMeshTranslucentProp", __pb.Bytes);
        }
        public void SetMeshOpaqueProp(PrimitiveComponent Mesh, int MaterialIndex, MaterialInterface OpaqueMaterial, bool IsMeshOpaque, Object __WorldContext, bool Succeeded)
        {
            var __pb = new ParamBuffer(41);
            __pb.SetObject(0x0, Mesh);
            __pb.Set(0x8, MaterialIndex);
            __pb.SetObject(0x10, OpaqueMaterial);
            __pb.Set<byte>(0x18, (byte)(IsMeshOpaque?1:0));
            __pb.SetObject(0x20, __WorldContext);
            __pb.Set<byte>(0x28, (byte)(Succeeded?1:0));
            CallRaw("SetMeshOpaqueProp", __pb.Bytes);
        }
        public void GetActivePlatform(Object __WorldContext, byte ActivePlatform)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, __WorldContext);
            __pb.Set(0x8, ActivePlatform);
            CallRaw("GetActivePlatform", __pb.Bytes);
        }
        public void LoadGame(Object __WorldContext, VR4SaveGame_BP_C SaveGame)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, __WorldContext);
            __pb.SetObject(0x8, SaveGame);
            CallRaw("LoadGame", __pb.Bytes);
        }
        public void SaveGame(Object __WorldContext, bool SaveSucceeded)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, __WorldContext);
            __pb.Set<byte>(0x8, (byte)(SaveSucceeded?1:0));
            CallRaw("SaveGame", __pb.Bytes);
        }
        public void SetSaveGame(VR4SaveGame_BP_C SaveGame, Object __WorldContext)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, SaveGame);
            __pb.SetObject(0x8, __WorldContext);
            CallRaw("SetSaveGame", __pb.Bytes);
        }
        public void GetSaveGame(Object __WorldContext, VR4SaveGame_BP_C VR4SaveGame)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, __WorldContext);
            __pb.SetObject(0x8, VR4SaveGame);
            CallRaw("GetSaveGame", __pb.Bytes);
        }
    }

}
