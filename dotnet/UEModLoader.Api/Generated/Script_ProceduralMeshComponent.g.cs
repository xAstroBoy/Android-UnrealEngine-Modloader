// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/ProceduralMeshComponent
using System;

namespace UEModLoader.Game
{
    public enum EProcMeshSliceCapOption
    {
        NoCap = 0,
        CreateNewSectionForCap = 1,
        UseLastSectionForCap = 2,
    }

    public class ProcMeshSection : StructProxy
    {
        public ProcMeshSection(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> ProcVertexBuffer => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> ProcIndexBuffer => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<uint32>
        public Box SectionLocalBox => new Box(AddrOf(0x20));
        public bool bEnableCollision { get => (GetAt<byte>(0x3C) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
        public bool bSectionVisible { get => (GetAt<byte>(0x3D) & 0xFF) != 0; set { var __b = GetAt<byte>(0x3D); SetAt(0x3D, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class ProcMeshVertex : StructProxy
    {
        public ProcMeshVertex(System.IntPtr ptr) : base(ptr) {}
        public Vector Position => new Vector(AddrOf(0x0));
        public Vector Normal => new Vector(AddrOf(0xC));
        public ProcMeshTangent Tangent => new ProcMeshTangent(AddrOf(0x18));
        public Color Color => new Color(AddrOf(0x28));
        public Vector2D UV0 => new Vector2D(AddrOf(0x2C));
        public Vector2D UV1 => new Vector2D(AddrOf(0x34));
        public Vector2D UV2 => new Vector2D(AddrOf(0x3C));
        public Vector2D UV3 => new Vector2D(AddrOf(0x44));
    }

    public class ProcMeshTangent : StructProxy
    {
        public ProcMeshTangent(System.IntPtr ptr) : base(ptr) {}
        public Vector TangentX => new Vector(AddrOf(0x0));
        public bool bFlipTangentY { get => (GetAt<byte>(0xC) & 0xFF) != 0; set { var __b = GetAt<byte>(0xC); SetAt(0xC, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class KismetProceduralMeshLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "KismetProceduralMeshLibrary";
        public KismetProceduralMeshLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new KismetProceduralMeshLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new KismetProceduralMeshLibrary(p);
        public static KismetProceduralMeshLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new KismetProceduralMeshLibrary(o.Pointer); }
        public static KismetProceduralMeshLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new KismetProceduralMeshLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new KismetProceduralMeshLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x59AF218 — hookable via Hooks.InstallAt(NativeFunc_SliceProceduralMesh).</summary>
        public static System.IntPtr NativeFunc_SliceProceduralMesh => Memory.ModuleBase() + 0x59AF218;
        public void SliceProceduralMesh(ProceduralMeshComponent InProcMesh, Vector PlanePosition, Vector PlaneNormal, bool bCreateOtherHalf, ProceduralMeshComponent OutOtherHalfProcMesh, EProcMeshSliceCapOption CapOption, MaterialInterface CapMaterial)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, InProcMesh);
            __pb.Set<System.IntPtr>(0x8, PlanePosition);
            __pb.Set<System.IntPtr>(0x14, PlaneNormal);
            __pb.Set<byte>(0x20, (byte)(bCreateOtherHalf?1:0));
            __pb.SetObject(0x28, OutOtherHalfProcMesh);
            __pb.Set<byte>(0x30, (byte)CapOption);
            __pb.SetObject(0x38, CapMaterial);
            CallRaw("SliceProceduralMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59AF874 — hookable via Hooks.InstallAt(NativeFunc_GetSectionFromStaticMesh).</summary>
        public static System.IntPtr NativeFunc_GetSectionFromStaticMesh => Memory.ModuleBase() + 0x59AF874;
        public void GetSectionFromStaticMesh(StaticMesh InMesh, int LODIndex, int SectionIndex, System.IntPtr Vertices, System.IntPtr Triangles, System.IntPtr Normals, System.IntPtr UVs, System.IntPtr Tangents)
        {
            var __pb = new ParamBuffer(96);
            __pb.SetObject(0x0, InMesh);
            __pb.Set(0x8, LODIndex);
            __pb.Set(0xC, SectionIndex);
            __pb.Set<System.IntPtr>(0x10, Vertices);
            __pb.Set<System.IntPtr>(0x20, Triangles);
            __pb.Set<System.IntPtr>(0x30, Normals);
            __pb.Set<System.IntPtr>(0x40, UVs);
            __pb.Set<System.IntPtr>(0x50, Tangents);
            CallRaw("GetSectionFromStaticMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59AF450 — hookable via Hooks.InstallAt(NativeFunc_GetSectionFromProceduralMesh).</summary>
        public static System.IntPtr NativeFunc_GetSectionFromProceduralMesh => Memory.ModuleBase() + 0x59AF450;
        public void GetSectionFromProceduralMesh(ProceduralMeshComponent InProcMesh, int SectionIndex, System.IntPtr Vertices, System.IntPtr Triangles, System.IntPtr Normals, System.IntPtr UVs, System.IntPtr Tangents)
        {
            var __pb = new ParamBuffer(96);
            __pb.SetObject(0x0, InProcMesh);
            __pb.Set(0x8, SectionIndex);
            __pb.Set<System.IntPtr>(0x10, Vertices);
            __pb.Set<System.IntPtr>(0x20, Triangles);
            __pb.Set<System.IntPtr>(0x30, Normals);
            __pb.Set<System.IntPtr>(0x40, UVs);
            __pb.Set<System.IntPtr>(0x50, Tangents);
            CallRaw("GetSectionFromProceduralMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B05BC — hookable via Hooks.InstallAt(NativeFunc_GenerateBoxMesh).</summary>
        public static System.IntPtr NativeFunc_GenerateBoxMesh => Memory.ModuleBase() + 0x59B05BC;
        public void GenerateBoxMesh(Vector BoxRadius, System.IntPtr Vertices, System.IntPtr Triangles, System.IntPtr Normals, System.IntPtr UVs, System.IntPtr Tangents)
        {
            var __pb = new ParamBuffer(96);
            __pb.Set<System.IntPtr>(0x0, BoxRadius);
            __pb.Set<System.IntPtr>(0x10, Vertices);
            __pb.Set<System.IntPtr>(0x20, Triangles);
            __pb.Set<System.IntPtr>(0x30, Normals);
            __pb.Set<System.IntPtr>(0x40, UVs);
            __pb.Set<System.IntPtr>(0x50, Tangents);
            CallRaw("GenerateBoxMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59AFE0C — hookable via Hooks.InstallAt(NativeFunc_CreateGridMeshWelded).</summary>
        public static System.IntPtr NativeFunc_CreateGridMeshWelded => Memory.ModuleBase() + 0x59AFE0C;
        public void CreateGridMeshWelded(int NumX, int NumY, System.IntPtr Triangles, System.IntPtr Vertices, System.IntPtr UVs, float GridSpacing)
        {
            var __pb = new ParamBuffer(60);
            __pb.Set(0x0, NumX);
            __pb.Set(0x4, NumY);
            __pb.Set<System.IntPtr>(0x8, Triangles);
            __pb.Set<System.IntPtr>(0x18, Vertices);
            __pb.Set<System.IntPtr>(0x28, UVs);
            __pb.Set(0x38, GridSpacing);
            CallRaw("CreateGridMeshWelded", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B0050 — hookable via Hooks.InstallAt(NativeFunc_CreateGridMeshTriangles).</summary>
        public static System.IntPtr NativeFunc_CreateGridMeshTriangles => Memory.ModuleBase() + 0x59B0050;
        public void CreateGridMeshTriangles(int NumX, int NumY, bool bWinding, System.IntPtr Triangles)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set(0x0, NumX);
            __pb.Set(0x4, NumY);
            __pb.Set<byte>(0x8, (byte)(bWinding?1:0));
            __pb.Set<System.IntPtr>(0x10, Triangles);
            CallRaw("CreateGridMeshTriangles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59AFB70 — hookable via Hooks.InstallAt(NativeFunc_CreateGridMeshSplit).</summary>
        public static System.IntPtr NativeFunc_CreateGridMeshSplit => Memory.ModuleBase() + 0x59AFB70;
        public void CreateGridMeshSplit(int NumX, int NumY, System.IntPtr Triangles, System.IntPtr Vertices, System.IntPtr UVs, System.IntPtr UV1s, float GridSpacing)
        {
            var __pb = new ParamBuffer(76);
            __pb.Set(0x0, NumX);
            __pb.Set(0x4, NumY);
            __pb.Set<System.IntPtr>(0x8, Triangles);
            __pb.Set<System.IntPtr>(0x18, Vertices);
            __pb.Set<System.IntPtr>(0x28, UVs);
            __pb.Set<System.IntPtr>(0x38, UV1s);
            __pb.Set(0x48, GridSpacing);
            CallRaw("CreateGridMeshSplit", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59AF70C — hookable via Hooks.InstallAt(NativeFunc_CopyProceduralMeshFromStaticMeshComponent).</summary>
        public static System.IntPtr NativeFunc_CopyProceduralMeshFromStaticMeshComponent => Memory.ModuleBase() + 0x59AF70C;
        public void CopyProceduralMeshFromStaticMeshComponent(StaticMeshComponent StaticMeshComponent, int LODIndex, ProceduralMeshComponent ProcMeshComponent, bool bCreateCollision)
        {
            var __pb = new ParamBuffer(25);
            __pb.SetObject(0x0, StaticMeshComponent);
            __pb.Set(0x8, LODIndex);
            __pb.SetObject(0x10, ProcMeshComponent);
            __pb.Set<byte>(0x18, (byte)(bCreateCollision?1:0));
            CallRaw("CopyProceduralMeshFromStaticMeshComponent", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B01D0 — hookable via Hooks.InstallAt(NativeFunc_ConvertQuadToTriangles).</summary>
        public static System.IntPtr NativeFunc_ConvertQuadToTriangles => Memory.ModuleBase() + 0x59B01D0;
        public void ConvertQuadToTriangles(System.IntPtr Triangles, int Vert0, int Vert1, int Vert2, int Vert3)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, Triangles);
            __pb.Set(0x10, Vert0);
            __pb.Set(0x14, Vert1);
            __pb.Set(0x18, Vert2);
            __pb.Set(0x1C, Vert3);
            CallRaw("ConvertQuadToTriangles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B038C — hookable via Hooks.InstallAt(NativeFunc_CalculateTangentsForMesh).</summary>
        public static System.IntPtr NativeFunc_CalculateTangentsForMesh => Memory.ModuleBase() + 0x59B038C;
        public void CalculateTangentsForMesh(System.IntPtr Vertices, System.IntPtr Triangles, System.IntPtr UVs, System.IntPtr Normals, System.IntPtr Tangents)
        {
            var __pb = new ParamBuffer(80);
            __pb.Set<System.IntPtr>(0x0, Vertices);
            __pb.Set<System.IntPtr>(0x10, Triangles);
            __pb.Set<System.IntPtr>(0x20, UVs);
            __pb.Set<System.IntPtr>(0x30, Normals);
            __pb.Set<System.IntPtr>(0x40, Tangents);
            CallRaw("CalculateTangentsForMesh", __pb.Bytes);
        }
    }

    public class ProceduralMeshComponent : MeshComponent
    {
        public const string UeClassName = "ProceduralMeshComponent";
        public ProceduralMeshComponent(System.IntPtr ptr) : base(ptr) {}
        public static new ProceduralMeshComponent FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new ProceduralMeshComponent(p);
        public static ProceduralMeshComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new ProceduralMeshComponent(o.Pointer); }
        public static ProceduralMeshComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new ProceduralMeshComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new ProceduralMeshComponent(a[i].Pointer); return r; }
        public bool bUseComplexAsSimpleCollision { get => Native.GetPropBool(Pointer, "bUseComplexAsSimpleCollision"); set => Native.SetPropBool(Pointer, "bUseComplexAsSimpleCollision", value); }
        public bool bUseAsyncCooking { get => Native.GetPropBool(Pointer, "bUseAsyncCooking"); set => Native.SetPropBool(Pointer, "bUseAsyncCooking", value); }
        public BodySetup ProcMeshBodySetup { get { var __p = GetAt<System.IntPtr>(0x440); return __p==System.IntPtr.Zero?null:new BodySetup(__p); } set => SetAt(0x440, value?.Pointer ?? System.IntPtr.Zero); }
        public TArray<System.IntPtr> ProcMeshSections => new TArray<System.IntPtr>(AddrOf(0x448)); // TArray<struct>
        public TArray<System.IntPtr> CollisionConvexElems => new TArray<System.IntPtr>(AddrOf(0x458)); // TArray<struct>
        public BoxSphereBounds LocalBounds => new BoxSphereBounds(AddrOf(0x468));
        public TArray<System.IntPtr> AsyncBodySetupQueue => new TArray<System.IntPtr>(AddrOf(0x488)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x59B1B40 — hookable via Hooks.InstallAt(NativeFunc_UpdateMeshSection_LinearColor).</summary>
        public static System.IntPtr NativeFunc_UpdateMeshSection_LinearColor => Memory.ModuleBase() + 0x59B1B40;
        public void UpdateMeshSection_LinearColor(int SectionIndex, System.IntPtr Vertices, System.IntPtr Normals, System.IntPtr UV0, System.IntPtr UV1, System.IntPtr UV2, System.IntPtr UV3, System.IntPtr VertexColors, System.IntPtr Tangents)
        {
            var __pb = new ParamBuffer(136);
            __pb.Set(0x0, SectionIndex);
            __pb.Set<System.IntPtr>(0x8, Vertices);
            __pb.Set<System.IntPtr>(0x18, Normals);
            __pb.Set<System.IntPtr>(0x28, UV0);
            __pb.Set<System.IntPtr>(0x38, UV1);
            __pb.Set<System.IntPtr>(0x48, UV2);
            __pb.Set<System.IntPtr>(0x58, UV3);
            __pb.Set<System.IntPtr>(0x68, VertexColors);
            __pb.Set<System.IntPtr>(0x78, Tangents);
            CallRaw("UpdateMeshSection_LinearColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B1EE4 — hookable via Hooks.InstallAt(NativeFunc_UpdateMeshSection).</summary>
        public static System.IntPtr NativeFunc_UpdateMeshSection => Memory.ModuleBase() + 0x59B1EE4;
        public void UpdateMeshSection(int SectionIndex, System.IntPtr Vertices, System.IntPtr Normals, System.IntPtr UV0, System.IntPtr VertexColors, System.IntPtr Tangents)
        {
            var __pb = new ParamBuffer(88);
            __pb.Set(0x0, SectionIndex);
            __pb.Set<System.IntPtr>(0x8, Vertices);
            __pb.Set<System.IntPtr>(0x18, Normals);
            __pb.Set<System.IntPtr>(0x28, UV0);
            __pb.Set<System.IntPtr>(0x38, VertexColors);
            __pb.Set<System.IntPtr>(0x48, Tangents);
            CallRaw("UpdateMeshSection", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B199C — hookable via Hooks.InstallAt(NativeFunc_SetMeshSectionVisible).</summary>
        public static System.IntPtr NativeFunc_SetMeshSectionVisible => Memory.ModuleBase() + 0x59B199C;
        public void SetMeshSectionVisible(int SectionIndex, bool bNewVisibility)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, SectionIndex);
            __pb.Set<byte>(0x4, (byte)(bNewVisibility?1:0));
            CallRaw("SetMeshSectionVisible", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B18EC — hookable via Hooks.InstallAt(NativeFunc_IsMeshSectionVisible).</summary>
        public static System.IntPtr NativeFunc_IsMeshSectionVisible => Memory.ModuleBase() + 0x59B18EC;
        public bool IsMeshSectionVisible(int SectionIndex)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, SectionIndex);
            CallRaw("IsMeshSectionVisible", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x59B18B8 — hookable via Hooks.InstallAt(NativeFunc_GetNumSections).</summary>
        public static System.IntPtr NativeFunc_GetNumSections => Memory.ModuleBase() + 0x59B18B8;
        public int GetNumSections()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumSections", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x59B2188 — hookable via Hooks.InstallAt(NativeFunc_CreateMeshSection_LinearColor).</summary>
        public static System.IntPtr NativeFunc_CreateMeshSection_LinearColor => Memory.ModuleBase() + 0x59B2188;
        public void CreateMeshSection_LinearColor(int SectionIndex, System.IntPtr Vertices, System.IntPtr Triangles, System.IntPtr Normals, System.IntPtr UV0, System.IntPtr UV1, System.IntPtr UV2, System.IntPtr UV3, System.IntPtr VertexColors, System.IntPtr Tangents, bool bCreateCollision)
        {
            var __pb = new ParamBuffer(153);
            __pb.Set(0x0, SectionIndex);
            __pb.Set<System.IntPtr>(0x8, Vertices);
            __pb.Set<System.IntPtr>(0x18, Triangles);
            __pb.Set<System.IntPtr>(0x28, Normals);
            __pb.Set<System.IntPtr>(0x38, UV0);
            __pb.Set<System.IntPtr>(0x48, UV1);
            __pb.Set<System.IntPtr>(0x58, UV2);
            __pb.Set<System.IntPtr>(0x68, UV3);
            __pb.Set<System.IntPtr>(0x78, VertexColors);
            __pb.Set<System.IntPtr>(0x88, Tangents);
            __pb.Set<byte>(0x98, (byte)(bCreateCollision?1:0));
            CallRaw("CreateMeshSection_LinearColor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B25DC — hookable via Hooks.InstallAt(NativeFunc_CreateMeshSection).</summary>
        public static System.IntPtr NativeFunc_CreateMeshSection => Memory.ModuleBase() + 0x59B25DC;
        public void CreateMeshSection(int SectionIndex, System.IntPtr Vertices, System.IntPtr Triangles, System.IntPtr Normals, System.IntPtr UV0, System.IntPtr VertexColors, System.IntPtr Tangents, bool bCreateCollision)
        {
            var __pb = new ParamBuffer(105);
            __pb.Set(0x0, SectionIndex);
            __pb.Set<System.IntPtr>(0x8, Vertices);
            __pb.Set<System.IntPtr>(0x18, Triangles);
            __pb.Set<System.IntPtr>(0x28, Normals);
            __pb.Set<System.IntPtr>(0x38, UV0);
            __pb.Set<System.IntPtr>(0x48, VertexColors);
            __pb.Set<System.IntPtr>(0x58, Tangents);
            __pb.Set<byte>(0x68, (byte)(bCreateCollision?1:0));
            CallRaw("CreateMeshSection", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B1A9C — hookable via Hooks.InstallAt(NativeFunc_ClearMeshSection).</summary>
        public static System.IntPtr NativeFunc_ClearMeshSection => Memory.ModuleBase() + 0x59B1A9C;
        public void ClearMeshSection(int SectionIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, SectionIndex);
            CallRaw("ClearMeshSection", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B17A8 — hookable via Hooks.InstallAt(NativeFunc_ClearCollisionConvexMeshes).</summary>
        public static System.IntPtr NativeFunc_ClearCollisionConvexMeshes => Memory.ModuleBase() + 0x59B17A8;
        public void ClearCollisionConvexMeshes()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearCollisionConvexMeshes", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B1A88 — hookable via Hooks.InstallAt(NativeFunc_ClearAllMeshSections).</summary>
        public static System.IntPtr NativeFunc_ClearAllMeshSections => Memory.ModuleBase() + 0x59B1A88;
        public void ClearAllMeshSections()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearAllMeshSections", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59B17BC — hookable via Hooks.InstallAt(NativeFunc_AddCollisionConvexMesh).</summary>
        public static System.IntPtr NativeFunc_AddCollisionConvexMesh => Memory.ModuleBase() + 0x59B17BC;
        public void AddCollisionConvexMesh(System.IntPtr ConvexVerts)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, ConvexVerts);
            CallRaw("AddCollisionConvexMesh", __pb.Bytes);
        }
    }

}
