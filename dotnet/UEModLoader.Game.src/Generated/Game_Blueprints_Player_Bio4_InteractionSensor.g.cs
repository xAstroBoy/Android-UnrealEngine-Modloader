// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Bio4/InteractionSensor
using System;

namespace UEModLoader.Game
{
    public class InteractionSensor_C : Actor
    {
        public const string UeClassName = "InteractionSensor_C";
        public InteractionSensor_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new InteractionSensor_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new InteractionSensor_C(p);
        public static InteractionSensor_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new InteractionSensor_C(o.Pointer); }
        public static InteractionSensor_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new InteractionSensor_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new InteractionSensor_C(a[i].Pointer); return r; }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x220); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x220, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EHandedness Hand { get => (EHandedness)GetAt<byte>(0x228); set => SetAt(0x228, (byte)value); }
        public SkeletalMeshComponent Skeleton { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

}
