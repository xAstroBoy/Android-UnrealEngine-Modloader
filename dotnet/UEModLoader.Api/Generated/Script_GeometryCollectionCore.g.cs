// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/GeometryCollectionCore
using System;

namespace UEModLoader.Game
{
    public enum EGeometryCollectionCacheType
    {
        None = 0,
        Record = 1,
        Play = 2,
        RecordAndPlay = 3,
    }

    public class RecordedTransformTrack : StructProxy
    {
        public RecordedTransformTrack(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Records => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class RecordedFrame : StructProxy
    {
        public RecordedFrame(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Transforms => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> TransformIndices => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<int32>
        public TArray<System.IntPtr> PreviousTransformIndices => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<int32>
        public TArray<System.IntPtr> DisabledFlags => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<bool>
        public TArray<System.IntPtr> Collisions => new TArray<System.IntPtr>(AddrOf(0x40)); // TArray<struct>
        public TArray<System.IntPtr> Breakings => new TArray<System.IntPtr>(AddrOf(0x50)); // TArray<struct>
        public System.IntPtr Trailings => AddrOf(0x60); // 
        public float Timestamp { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
    }

    public class SolverTrailingData : StructProxy
    {
        public SolverTrailingData(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x0));
        public Vector Velocity => new Vector(AddrOf(0xC));
        public Vector AngularVelocity => new Vector(AddrOf(0x18));
        public float Mass { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public int ParticleIndex { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public int ParticleIndexMesh { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
    }

    public class SolverBreakingData : StructProxy
    {
        public SolverBreakingData(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x0));
        public Vector Velocity => new Vector(AddrOf(0xC));
        public Vector AngularVelocity => new Vector(AddrOf(0x18));
        public float Mass { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public int ParticleIndex { get => GetAt<int>(0x28); set => SetAt(0x28, value); }
        public int ParticleIndexMesh { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
    }

    public class SolverCollisionData : StructProxy
    {
        public SolverCollisionData(System.IntPtr ptr) : base(ptr) {}
        public Vector Location => new Vector(AddrOf(0x0));
        public Vector AccumulatedImpulse => new Vector(AddrOf(0xC));
        public Vector Normal => new Vector(AddrOf(0x18));
        public Vector Velocity1 => new Vector(AddrOf(0x24));
        public Vector Velocity2 => new Vector(AddrOf(0x30));
        public Vector AngularVelocity1 => new Vector(AddrOf(0x3C));
        public Vector AngularVelocity2 => new Vector(AddrOf(0x48));
        public float Mass1 { get => GetAt<float>(0x54); set => SetAt(0x54, value); }
        public float Mass2 { get => GetAt<float>(0x58); set => SetAt(0x58, value); }
        public int ParticleIndex { get => GetAt<int>(0x5C); set => SetAt(0x5C, value); }
        public int LevelsetIndex { get => GetAt<int>(0x60); set => SetAt(0x60, value); }
        public int ParticleIndexMesh { get => GetAt<int>(0x64); set => SetAt(0x64, value); }
        public int LevelsetIndexMesh { get => GetAt<int>(0x68); set => SetAt(0x68, value); }
    }

}
