// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/SimpleSocketAnimationLibrary
using System;

namespace UEModLoader.Game
{
    public class SimpleSocketAnimationLibrary_C : BlueprintFunctionLibrary
    {
        public const string UeClassName = "SimpleSocketAnimationLibrary_C";
        public SimpleSocketAnimationLibrary_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new SimpleSocketAnimationLibrary_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SimpleSocketAnimationLibrary_C(p);
        public static SimpleSocketAnimationLibrary_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SimpleSocketAnimationLibrary_C(o.Pointer); }
        public static SimpleSocketAnimationLibrary_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SimpleSocketAnimationLibrary_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SimpleSocketAnimationLibrary_C(a[i].Pointer); return r; }
        public void ApplySimpleTransformAnimationToPoseableMesh(PoseableMeshComponent MeshComponent, FName BoneName, byte BoneSpace, float alpha, global::System.IntPtr Transforms, Object __WorldContext)
        {
            var __pb = new ParamBuffer(136);
            __pb.SetObject(0x0, MeshComponent);
            __pb.Set(0x8, BoneName);
            __pb.Set(0x10, BoneSpace);
            __pb.Set(0x14, alpha);
            __pb.Set<global::System.IntPtr>(0x20, Transforms);
            __pb.SetObject(0x80, __WorldContext);
            CallRaw("ApplySimpleTransformAnimationToPoseableMesh", __pb.Bytes);
        }
        public void ApplySimpleLocalTransformAnimationToPoseableMesh(PoseableMeshComponent MeshComponent, FName BoneName, float alpha, global::System.IntPtr Transforms, Object __WorldContext)
        {
            var __pb = new ParamBuffer(136);
            __pb.SetObject(0x0, MeshComponent);
            __pb.Set(0x8, BoneName);
            __pb.Set(0x10, alpha);
            __pb.Set<global::System.IntPtr>(0x20, Transforms);
            __pb.SetObject(0x80, __WorldContext);
            CallRaw("ApplySimpleLocalTransformAnimationToPoseableMesh", __pb.Bytes);
        }
        public void GetSimpleSocketAnimationTransforms(SceneComponent SocketSource, global::System.IntPtr Settings, byte TransformSpace, Object __WorldContext, global::System.IntPtr Transforms)
        {
            var __pb = new ParamBuffer(144);
            __pb.SetObject(0x0, SocketSource);
            __pb.Set<global::System.IntPtr>(0x8, Settings);
            __pb.Set(0x20, TransformSpace);
            __pb.SetObject(0x28, __WorldContext);
            __pb.Set<global::System.IntPtr>(0x30, Transforms);
            CallRaw("GetSimpleSocketAnimationTransforms", __pb.Bytes);
        }
    }

}
