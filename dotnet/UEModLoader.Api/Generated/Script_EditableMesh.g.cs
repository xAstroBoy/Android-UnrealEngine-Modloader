// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/EditableMesh
using System;

namespace UEModLoader.Game
{
    public enum ETriangleTessellationMode
    {
        ThreeTriangles = 0,
        FourTriangles = 1,
    }

    public enum EInsetPolygonsMode
    {
        All = 0,
        CenterPolygonOnly = 1,
        SidePolygonsOnly = 2,
    }

    public enum EPolygonEdgeHardness
    {
        NewEdgesSoft = 0,
        NewEdgesHard = 1,
        AllEdgesSoft = 2,
        AllEdgesHard = 3,
    }

    public enum EMeshElementAttributeType
    {
        None = 0,
        FVector4 = 1,
        FVector = 2,
        FVector2D = 3,
        Float = 4,
        Int = 5,
        Bool = 6,
        FName = 7,
    }

    public enum EMeshTopologyChange
    {
        NoTopologyChange = 0,
        TopologyChange = 1,
    }

    public enum EMeshModificationType
    {
        FirstInterim = 0,
        Interim = 1,
        Final = 2,
    }

    public class AdaptorPolygon2Group : StructProxy
    {
        public AdaptorPolygon2Group(System.IntPtr ptr) : base(ptr) {}
        public uint RenderingSectionIndex { get => GetAt<uint>(0x0); set => SetAt(0x0, value); }
        public int MaterialIndex { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int MaxTriangles { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
    }

    public class AdaptorPolygon : StructProxy
    {
        public AdaptorPolygon(System.IntPtr ptr) : base(ptr) {}
        public PolygonGroupID PolygonGroupID => new PolygonGroupID(AddrOf(0x0));
        public TArray<System.IntPtr> TriangulatedPolygonTriangleIndices => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
    }

    public class AdaptorTriangleID : StructProxy
    {
        public AdaptorTriangleID(System.IntPtr ptr) : base(ptr) {}
    }

    public class PolygonGroupForPolygon : StructProxy
    {
        public PolygonGroupForPolygon(System.IntPtr ptr) : base(ptr) {}
        public PolygonID PolygonID => new PolygonID(AddrOf(0x0));
        public PolygonGroupID PolygonGroupID => new PolygonGroupID(AddrOf(0x4));
    }

    public class PolygonGroupToCreate : StructProxy
    {
        public PolygonGroupToCreate(System.IntPtr ptr) : base(ptr) {}
        public MeshElementAttributeList PolygonGroupAttributes => new MeshElementAttributeList(AddrOf(0x0));
        public PolygonGroupID OriginalPolygonGroupID => new PolygonGroupID(AddrOf(0x10));
    }

    public class MeshElementAttributeList : StructProxy
    {
        public MeshElementAttributeList(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> Attributes => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class MeshElementAttributeData : StructProxy
    {
        public MeshElementAttributeData(System.IntPtr ptr) : base(ptr) {}
        public string AttributeName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName AttributeName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public int AttributeIndex { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
        public MeshElementAttributeValue AttributeValue => new MeshElementAttributeValue(AddrOf(0x10));
    }

    public class MeshElementAttributeValue : StructProxy
    {
        public MeshElementAttributeValue(System.IntPtr ptr) : base(ptr) {}
    }

    public class VertexToMove : StructProxy
    {
        public VertexToMove(System.IntPtr ptr) : base(ptr) {}
        public VertexID VertexID => new VertexID(AddrOf(0x0));
        public Vector NewVertexPosition => new Vector(AddrOf(0x4));
    }

    public class ChangeVertexInstancesForPolygon : StructProxy
    {
        public ChangeVertexInstancesForPolygon(System.IntPtr ptr) : base(ptr) {}
        public PolygonID PolygonID => new PolygonID(AddrOf(0x0));
        public TArray<System.IntPtr> PerimeterVertexIndicesAndInstanceIDs => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public TArray<System.IntPtr> VertexIndicesAndInstanceIDsForEachHole => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<struct>
    }

    public class VertexInstancesForPolygonHole : StructProxy
    {
        public VertexInstancesForPolygonHole(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> VertexIndicesAndInstanceIDs => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class VertexIndexAndInstanceID : StructProxy
    {
        public VertexIndexAndInstanceID(System.IntPtr ptr) : base(ptr) {}
        public int ContourIndex { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public VertexInstanceID VertexInstanceID => new VertexInstanceID(AddrOf(0x4));
    }

    public class VertexAttributesForPolygon : StructProxy
    {
        public VertexAttributesForPolygon(System.IntPtr ptr) : base(ptr) {}
        public PolygonID PolygonID => new PolygonID(AddrOf(0x0));
        public TArray<System.IntPtr> PerimeterVertexAttributeLists => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public TArray<System.IntPtr> VertexAttributeListsForEachHole => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<struct>
    }

    public class VertexAttributesForPolygonHole : StructProxy
    {
        public VertexAttributesForPolygonHole(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> VertexAttributeList => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class AttributesForEdge : StructProxy
    {
        public AttributesForEdge(System.IntPtr ptr) : base(ptr) {}
        public EdgeID EdgeID => new EdgeID(AddrOf(0x0));
        public MeshElementAttributeList EdgeAttributes => new MeshElementAttributeList(AddrOf(0x8));
    }

    public class AttributesForVertexInstance : StructProxy
    {
        public AttributesForVertexInstance(System.IntPtr ptr) : base(ptr) {}
        public VertexInstanceID VertexInstanceID => new VertexInstanceID(AddrOf(0x0));
        public MeshElementAttributeList VertexInstanceAttributes => new MeshElementAttributeList(AddrOf(0x8));
    }

    public class AttributesForVertex : StructProxy
    {
        public AttributesForVertex(System.IntPtr ptr) : base(ptr) {}
        public VertexID VertexID => new VertexID(AddrOf(0x0));
        public MeshElementAttributeList VertexAttributes => new MeshElementAttributeList(AddrOf(0x8));
    }

    public class PolygonToSplit : StructProxy
    {
        public PolygonToSplit(System.IntPtr ptr) : base(ptr) {}
        public PolygonID PolygonID => new PolygonID(AddrOf(0x0));
        public TArray<System.IntPtr> VertexPairsToSplitAt => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
    }

    public class VertexPair : StructProxy
    {
        public VertexPair(System.IntPtr ptr) : base(ptr) {}
        public VertexID VertexID0 => new VertexID(AddrOf(0x0));
        public VertexID VertexID1 => new VertexID(AddrOf(0x4));
    }

    public class PolygonToCreate : StructProxy
    {
        public PolygonToCreate(System.IntPtr ptr) : base(ptr) {}
        public PolygonGroupID PolygonGroupID => new PolygonGroupID(AddrOf(0x0));
        public TArray<System.IntPtr> PerimeterVertices => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public PolygonID OriginalPolygonID => new PolygonID(AddrOf(0x18));
        public EPolygonEdgeHardness PolygonEdgeHardness { get => (EPolygonEdgeHardness)GetAt<byte>(0x1C); set => SetAt(0x1C, (byte)value); }
    }

    public class VertexAndAttributes : StructProxy
    {
        public VertexAndAttributes(System.IntPtr ptr) : base(ptr) {}
        public VertexInstanceID VertexInstanceID => new VertexInstanceID(AddrOf(0x0));
        public VertexID VertexID => new VertexID(AddrOf(0x4));
        public MeshElementAttributeList PolygonVertexAttributes => new MeshElementAttributeList(AddrOf(0x8));
    }

    public class EdgeToCreate : StructProxy
    {
        public EdgeToCreate(System.IntPtr ptr) : base(ptr) {}
        public VertexID VertexID0 => new VertexID(AddrOf(0x0));
        public VertexID VertexID1 => new VertexID(AddrOf(0x4));
        public MeshElementAttributeList EdgeAttributes => new MeshElementAttributeList(AddrOf(0x8));
        public EdgeID OriginalEdgeID => new EdgeID(AddrOf(0x18));
    }

    public class VertexInstanceToCreate : StructProxy
    {
        public VertexInstanceToCreate(System.IntPtr ptr) : base(ptr) {}
        public VertexID VertexID => new VertexID(AddrOf(0x0));
        public MeshElementAttributeList VertexInstanceAttributes => new MeshElementAttributeList(AddrOf(0x8));
        public VertexInstanceID OriginalVertexInstanceID => new VertexInstanceID(AddrOf(0x18));
    }

    public class VertexToCreate : StructProxy
    {
        public VertexToCreate(System.IntPtr ptr) : base(ptr) {}
        public MeshElementAttributeList VertexAttributes => new MeshElementAttributeList(AddrOf(0x0));
        public VertexID OriginalVertexID => new VertexID(AddrOf(0x10));
    }

    public class SubdivisionLimitData : StructProxy
    {
        public SubdivisionLimitData(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> VertexPositions => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> Sections => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
        public TArray<System.IntPtr> SubdividedWireEdges => new TArray<System.IntPtr>(AddrOf(0x20)); // TArray<struct>
    }

    public class SubdividedWireEdge : StructProxy
    {
        public SubdividedWireEdge(System.IntPtr ptr) : base(ptr) {}
        public int EdgeVertex0PositionIndex { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public int EdgeVertex1PositionIndex { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
    }

    public class SubdivisionLimitSection : StructProxy
    {
        public SubdivisionLimitSection(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> SubdividedQuads => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
    }

    public class SubdividedQuad : StructProxy
    {
        public SubdividedQuad(System.IntPtr ptr) : base(ptr) {}
        public SubdividedQuadVertex QuadVertex0 => new SubdividedQuadVertex(AddrOf(0x0));
        public SubdividedQuadVertex QuadVertex1 => new SubdividedQuadVertex(AddrOf(0x34));
        public SubdividedQuadVertex QuadVertex2 => new SubdividedQuadVertex(AddrOf(0x68));
        public SubdividedQuadVertex QuadVertex3 => new SubdividedQuadVertex(AddrOf(0x9C));
    }

    public class SubdividedQuadVertex : StructProxy
    {
        public SubdividedQuadVertex(System.IntPtr ptr) : base(ptr) {}
        public int VertexPositionIndex { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public Vector2D TextureCoordinate0 => new Vector2D(AddrOf(0x4));
        public Vector2D TextureCoordinate1 => new Vector2D(AddrOf(0xC));
        public Color VertexColor => new Color(AddrOf(0x14));
        public Vector VertexNormal => new Vector(AddrOf(0x18));
        public Vector VertexTangent => new Vector(AddrOf(0x24));
        public float VertexBinormalSign { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
    }

    public class RenderingPolygonGroup : StructProxy
    {
        public RenderingPolygonGroup(System.IntPtr ptr) : base(ptr) {}
        public uint RenderingSectionIndex { get => GetAt<uint>(0x0); set => SetAt(0x0, value); }
        public int MaterialIndex { get => GetAt<int>(0x4); set => SetAt(0x4, value); }
        public int MaxTriangles { get => GetAt<int>(0x8); set => SetAt(0x8, value); }
    }

    public class RenderingPolygon : StructProxy
    {
        public RenderingPolygon(System.IntPtr ptr) : base(ptr) {}
        public PolygonGroupID PolygonGroupID => new PolygonGroupID(AddrOf(0x0));
        public TArray<System.IntPtr> TriangulatedPolygonTriangleIndices => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
    }

    public class EditableMeshAdapter : Object
    {
        public const string UeClassName = "EditableMeshAdapter";
        public EditableMeshAdapter(System.IntPtr ptr) : base(ptr) {}
        public static new EditableMeshAdapter FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableMeshAdapter(p);
        public static EditableMeshAdapter FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableMeshAdapter(o.Pointer); }
        public static EditableMeshAdapter[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableMeshAdapter[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableMeshAdapter(a[i].Pointer); return r; }
    }

    public class EditableGeometryCollectionAdapter : EditableMeshAdapter
    {
        public const string UeClassName = "EditableGeometryCollectionAdapter";
        public EditableGeometryCollectionAdapter(System.IntPtr ptr) : base(ptr) {}
        public static new EditableGeometryCollectionAdapter FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableGeometryCollectionAdapter(p);
        public static EditableGeometryCollectionAdapter FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableGeometryCollectionAdapter(o.Pointer); }
        public static EditableGeometryCollectionAdapter[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableGeometryCollectionAdapter[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableGeometryCollectionAdapter(a[i].Pointer); return r; }
        public GeometryCollection GeometryCollection { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new GeometryCollection(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public GeometryCollection OriginalGeometryCollection { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new GeometryCollection(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public int GeometryCollectionLODIndex { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
    }

    public class EditableMesh : Object
    {
        public const string UeClassName = "EditableMesh";
        public EditableMesh(System.IntPtr ptr) : base(ptr) {}
        public static new EditableMesh FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableMesh(p);
        public static EditableMesh FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableMesh(o.Pointer); }
        public static EditableMesh[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableMesh[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableMesh(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Adapters => new TArray<System.IntPtr>(AddrOf(0x3B8)); // TArray<UObject*>
        public int TextureCoordinateCount { get => GetAt<int>(0x3D0); set => SetAt(0x3D0, value); }
        public int PendingCompactCounter { get => GetAt<int>(0x51C); set => SetAt(0x51C, value); }
        public int SubdivisionCount { get => GetAt<int>(0x520); set => SetAt(0x520, value); }
        /// <summary>[Native] thunk RVA 0x5981108 — hookable via Hooks.InstallAt(NativeFunc_WeldVertices).</summary>
        public static System.IntPtr NativeFunc_WeldVertices => Memory.ModuleBase() + 0x5981108;
        public void WeldVertices(System.IntPtr VertexIDs, VertexID OutNewVertexID)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<System.IntPtr>(0x0, VertexIDs);
            __pb.Set<System.IntPtr>(0x10, OutNewVertexID);
            CallRaw("WeldVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x598248C — hookable via Hooks.InstallAt(NativeFunc_TryToRemoveVertex).</summary>
        public static System.IntPtr NativeFunc_TryToRemoveVertex => Memory.ModuleBase() + 0x598248C;
        public void TryToRemoveVertex(VertexID VertexID, bool bOutWasVertexRemoved, EdgeID OutNewEdgeID)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            __pb.Set<byte>(0x4, (byte)(bOutWasVertexRemoved?1:0));
            __pb.Set<System.IntPtr>(0x8, OutNewEdgeID);
            CallRaw("TryToRemoveVertex", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59825E8 — hookable via Hooks.InstallAt(NativeFunc_TryToRemovePolygonEdge).</summary>
        public static System.IntPtr NativeFunc_TryToRemovePolygonEdge => Memory.ModuleBase() + 0x59825E8;
        public void TryToRemovePolygonEdge(EdgeID EdgeID, bool bOutWasEdgeRemoved, PolygonID OutNewPolygonID)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set<byte>(0x4, (byte)(bOutWasEdgeRemoved?1:0));
            __pb.Set<System.IntPtr>(0x8, OutNewPolygonID);
            CallRaw("TryToRemovePolygonEdge", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x598153C — hookable via Hooks.InstallAt(NativeFunc_TriangulatePolygons).</summary>
        public static System.IntPtr NativeFunc_TriangulatePolygons => Memory.ModuleBase() + 0x598153C;
        public void TriangulatePolygons(System.IntPtr PolygonIDs, System.IntPtr OutNewTrianglePolygons)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, PolygonIDs);
            __pb.Set<System.IntPtr>(0x10, OutNewTrianglePolygons);
            CallRaw("TriangulatePolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5980FA4 — hookable via Hooks.InstallAt(NativeFunc_TessellatePolygons).</summary>
        public static System.IntPtr NativeFunc_TessellatePolygons => Memory.ModuleBase() + 0x5980FA4;
        public void TessellatePolygons(System.IntPtr PolygonIDs, ETriangleTessellationMode TriangleTessellationMode, System.IntPtr OutNewPolygonIDs)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, PolygonIDs);
            __pb.Set<byte>(0x10, (byte)TriangleTessellationMode);
            __pb.Set<System.IntPtr>(0x18, OutNewPolygonIDs);
            CallRaw("TessellatePolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5987C40 — hookable via Hooks.InstallAt(NativeFunc_StartModification).</summary>
        public static System.IntPtr NativeFunc_StartModification => Memory.ModuleBase() + 0x5987C40;
        public void StartModification(EMeshModificationType MeshModificationType, EMeshTopologyChange MeshTopologyChange)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)MeshModificationType);
            __pb.Set<byte>(0x1, (byte)MeshTopologyChange);
            CallRaw("StartModification", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983BE8 — hookable via Hooks.InstallAt(NativeFunc_SplitPolygons).</summary>
        public static System.IntPtr NativeFunc_SplitPolygons => Memory.ModuleBase() + 0x5983BE8;
        public void SplitPolygons(System.IntPtr PolygonsToSplit, System.IntPtr OutNewEdgeIDs)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, PolygonsToSplit);
            __pb.Set<System.IntPtr>(0x10, OutNewEdgeIDs);
            CallRaw("SplitPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5980BB4 — hookable via Hooks.InstallAt(NativeFunc_SplitPolygonalMesh).</summary>
        public static System.IntPtr NativeFunc_SplitPolygonalMesh => Memory.ModuleBase() + 0x5980BB4;
        public void SplitPolygonalMesh(Plane InPlane, System.IntPtr PolygonIDs1, System.IntPtr PolygonIDs2, System.IntPtr BoundaryIDs)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, InPlane);
            __pb.Set<System.IntPtr>(0x10, PolygonIDs1);
            __pb.Set<System.IntPtr>(0x20, PolygonIDs2);
            __pb.Set<System.IntPtr>(0x30, BoundaryIDs);
            CallRaw("SplitPolygonalMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983EB0 — hookable via Hooks.InstallAt(NativeFunc_SplitEdge).</summary>
        public static System.IntPtr NativeFunc_SplitEdge => Memory.ModuleBase() + 0x5983EB0;
        public void SplitEdge(EdgeID EdgeID, System.IntPtr Splits, System.IntPtr OutNewVertexIDs)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set<System.IntPtr>(0x8, Splits);
            __pb.Set<System.IntPtr>(0x18, OutNewVertexIDs);
            CallRaw("SplitEdge", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5981A50 — hookable via Hooks.InstallAt(NativeFunc_SetVerticesCornerSharpness).</summary>
        public static System.IntPtr NativeFunc_SetVerticesCornerSharpness => Memory.ModuleBase() + 0x5981A50;
        public void SetVerticesCornerSharpness(System.IntPtr VertexIDs, System.IntPtr VerticesNewCornerSharpness)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, VertexIDs);
            __pb.Set<System.IntPtr>(0x10, VerticesNewCornerSharpness);
            CallRaw("SetVerticesCornerSharpness", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5982B34 — hookable via Hooks.InstallAt(NativeFunc_SetVerticesAttributes).</summary>
        public static System.IntPtr NativeFunc_SetVerticesAttributes => Memory.ModuleBase() + 0x5982B34;
        public void SetVerticesAttributes(System.IntPtr AttributesForVertices)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, AttributesForVertices);
            CallRaw("SetVerticesAttributes", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5982A38 — hookable via Hooks.InstallAt(NativeFunc_SetVertexInstancesAttributes).</summary>
        public static System.IntPtr NativeFunc_SetVertexInstancesAttributes => Memory.ModuleBase() + 0x5982A38;
        public void SetVertexInstancesAttributes(System.IntPtr AttributesForVertexInstances)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, AttributesForVertexInstances);
            CallRaw("SetVertexInstancesAttributes", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5980F00 — hookable via Hooks.InstallAt(NativeFunc_SetTextureCoordinateCount).</summary>
        public static System.IntPtr NativeFunc_SetTextureCoordinateCount => Memory.ModuleBase() + 0x5980F00;
        public void SetTextureCoordinateCount(int NumTexCoords)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumTexCoords);
            CallRaw("SetTextureCoordinateCount", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59841F4 — hookable via Hooks.InstallAt(NativeFunc_SetSubdivisionCount).</summary>
        public static System.IntPtr NativeFunc_SetSubdivisionCount => Memory.ModuleBase() + 0x59841F4;
        public void SetSubdivisionCount(int NewSubdivisionCount)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NewSubdivisionCount);
            CallRaw("SetSubdivisionCount", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5982880 — hookable via Hooks.InstallAt(NativeFunc_SetPolygonsVertexAttributes).</summary>
        public static System.IntPtr NativeFunc_SetPolygonsVertexAttributes => Memory.ModuleBase() + 0x5982880;
        public void SetPolygonsVertexAttributes(System.IntPtr VertexAttributesForPolygons)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, VertexAttributesForPolygons);
            CallRaw("SetPolygonsVertexAttributes", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5981718 — hookable via Hooks.InstallAt(NativeFunc_SetEdgesHardnessAutomatically).</summary>
        public static System.IntPtr NativeFunc_SetEdgesHardnessAutomatically => Memory.ModuleBase() + 0x5981718;
        public void SetEdgesHardnessAutomatically(System.IntPtr EdgeIDs, float MaxDotProductForSoftEdge)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<System.IntPtr>(0x0, EdgeIDs);
            __pb.Set(0x10, MaxDotProductForSoftEdge);
            CallRaw("SetEdgesHardnessAutomatically", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5981818 — hookable via Hooks.InstallAt(NativeFunc_SetEdgesHardness).</summary>
        public static System.IntPtr NativeFunc_SetEdgesHardness => Memory.ModuleBase() + 0x5981818;
        public void SetEdgesHardness(System.IntPtr EdgeIDs, System.IntPtr EdgesNewIsHard)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, EdgeIDs);
            __pb.Set<System.IntPtr>(0x10, EdgesNewIsHard);
            CallRaw("SetEdgesHardness", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5981934 — hookable via Hooks.InstallAt(NativeFunc_SetEdgesCreaseSharpness).</summary>
        public static System.IntPtr NativeFunc_SetEdgesCreaseSharpness => Memory.ModuleBase() + 0x5981934;
        public void SetEdgesCreaseSharpness(System.IntPtr EdgeIDs, System.IntPtr EdgesNewCreaseSharpness)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, EdgeIDs);
            __pb.Set<System.IntPtr>(0x10, EdgesNewCreaseSharpness);
            CallRaw("SetEdgesCreaseSharpness", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x598293C — hookable via Hooks.InstallAt(NativeFunc_SetEdgesAttributes).</summary>
        public static System.IntPtr NativeFunc_SetEdgesAttributes => Memory.ModuleBase() + 0x598293C;
        public void SetEdgesAttributes(System.IntPtr AttributesForEdges)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, AttributesForEdges);
            CallRaw("SetEdgesAttributes", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59866D4 — hookable via Hooks.InstallAt(NativeFunc_SetAllowUndo).</summary>
        public static System.IntPtr NativeFunc_SetAllowUndo => Memory.ModuleBase() + 0x59866D4;
        public void SetAllowUndo(bool bInAllowUndo)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInAllowUndo?1:0));
            CallRaw("SetAllowUndo", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x598660C — hookable via Hooks.InstallAt(NativeFunc_SetAllowSpatialDatabase).</summary>
        public static System.IntPtr NativeFunc_SetAllowSpatialDatabase => Memory.ModuleBase() + 0x598660C;
        public void SetAllowSpatialDatabase(bool bInAllowSpatialDatabase)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInAllowSpatialDatabase?1:0));
            CallRaw("SetAllowSpatialDatabase", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5986510 — hookable via Hooks.InstallAt(NativeFunc_SetAllowCompact).</summary>
        public static System.IntPtr NativeFunc_SetAllowCompact => Memory.ModuleBase() + 0x5986510;
        public void SetAllowCompact(bool bInAllowCompact)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bInAllowCompact?1:0));
            CallRaw("SetAllowCompact", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5984298 — hookable via Hooks.InstallAt(NativeFunc_SearchSpatialDatabaseForPolygonsPotentiallyIntersectingPlane).</summary>
        public static System.IntPtr NativeFunc_SearchSpatialDatabaseForPolygonsPotentiallyIntersectingPlane => Memory.ModuleBase() + 0x5984298;
        public void SearchSpatialDatabaseForPolygonsPotentiallyIntersectingPlane(Plane InPlane, System.IntPtr OutPolygons)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, InPlane);
            __pb.Set<System.IntPtr>(0x10, OutPolygons);
            CallRaw("SearchSpatialDatabaseForPolygonsPotentiallyIntersectingPlane", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59844C0 — hookable via Hooks.InstallAt(NativeFunc_SearchSpatialDatabaseForPolygonsPotentiallyIntersectingLineSegment).</summary>
        public static System.IntPtr NativeFunc_SearchSpatialDatabaseForPolygonsPotentiallyIntersectingLineSegment => Memory.ModuleBase() + 0x59844C0;
        public void SearchSpatialDatabaseForPolygonsPotentiallyIntersectingLineSegment(Vector LineSegmentStart, Vector LineSegmentEnd, System.IntPtr OutPolygons)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, LineSegmentStart);
            __pb.Set<System.IntPtr>(0xC, LineSegmentEnd);
            __pb.Set<System.IntPtr>(0x18, OutPolygons);
            CallRaw("SearchSpatialDatabaseForPolygonsPotentiallyIntersectingLineSegment", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59843A4 — hookable via Hooks.InstallAt(NativeFunc_SearchSpatialDatabaseForPolygonsInVolume).</summary>
        public static System.IntPtr NativeFunc_SearchSpatialDatabaseForPolygonsInVolume => Memory.ModuleBase() + 0x59843A4;
        public void SearchSpatialDatabaseForPolygonsInVolume(System.IntPtr Planes, System.IntPtr OutPolygons)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, Planes);
            __pb.Set<System.IntPtr>(0x10, OutPolygons);
            CallRaw("SearchSpatialDatabaseForPolygonsInVolume", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5987A1C — hookable via Hooks.InstallAt(NativeFunc_RevertInstance).</summary>
        public static System.IntPtr NativeFunc_RevertInstance => Memory.ModuleBase() + 0x5987A1C;
        public EditableMesh RevertInstance()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("RevertInstance", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x0); return __p==System.IntPtr.Zero?null:new EditableMesh(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5987A50 — hookable via Hooks.InstallAt(NativeFunc_Revert).</summary>
        public static System.IntPtr NativeFunc_Revert => Memory.ModuleBase() + 0x5987A50;
        public void Revert()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Revert", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5987D28 — hookable via Hooks.InstallAt(NativeFunc_RebuildRenderMesh).</summary>
        public static System.IntPtr NativeFunc_RebuildRenderMesh => Memory.ModuleBase() + 0x5987D28;
        public void RebuildRenderMesh()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RebuildRenderMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5980E40 — hookable via Hooks.InstallAt(NativeFunc_QuadrangulateMesh).</summary>
        public static System.IntPtr NativeFunc_QuadrangulateMesh => Memory.ModuleBase() + 0x5980E40;
        public void QuadrangulateMesh(System.IntPtr OutNewPolygonIDs)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, OutNewPolygonIDs);
            CallRaw("QuadrangulateMesh", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5987A08 — hookable via Hooks.InstallAt(NativeFunc_PropagateInstanceChanges).</summary>
        public static System.IntPtr NativeFunc_PropagateInstanceChanges => Memory.ModuleBase() + 0x5987A08;
        public void PropagateInstanceChanges()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PropagateInstanceChanges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5984134 — hookable via Hooks.InstallAt(NativeFunc_MoveVertices).</summary>
        public static System.IntPtr NativeFunc_MoveVertices => Memory.ModuleBase() + 0x5984134;
        public void MoveVertices(System.IntPtr VerticesToMove)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, VerticesToMove);
            CallRaw("MoveVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59863E0 — hookable via Hooks.InstallAt(NativeFunc_MakeVertexID).</summary>
        public static System.IntPtr NativeFunc_MakeVertexID => Memory.ModuleBase() + 0x59863E0;
        public VertexID MakeVertexID(int VertexIndex)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, VertexIndex);
            CallRaw("MakeVertexID", __pb.Bytes);
            return __pb.Get<VertexID>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5986200 — hookable via Hooks.InstallAt(NativeFunc_MakePolygonID).</summary>
        public static System.IntPtr NativeFunc_MakePolygonID => Memory.ModuleBase() + 0x5986200;
        public PolygonID MakePolygonID(int PolygonIndex)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, PolygonIndex);
            CallRaw("MakePolygonID", __pb.Bytes);
            return __pb.Get<PolygonID>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x59862A0 — hookable via Hooks.InstallAt(NativeFunc_MakePolygonGroupID).</summary>
        public static System.IntPtr NativeFunc_MakePolygonGroupID => Memory.ModuleBase() + 0x59862A0;
        public PolygonGroupID MakePolygonGroupID(int PolygonGroupIndex)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, PolygonGroupIndex);
            CallRaw("MakePolygonGroupID", __pb.Bytes);
            return __pb.Get<PolygonGroupID>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5986340 — hookable via Hooks.InstallAt(NativeFunc_MakeEdgeID).</summary>
        public static System.IntPtr NativeFunc_MakeEdgeID => Memory.ModuleBase() + 0x5986340;
        public EdgeID MakeEdgeID(int EdgeIndex)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, EdgeIndex);
            CallRaw("MakeEdgeID", __pb.Bytes);
            return __pb.Get<EdgeID>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5987918 — hookable via Hooks.InstallAt(NativeFunc_IsValidVertex).</summary>
        public static System.IntPtr NativeFunc_IsValidVertex => Memory.ModuleBase() + 0x5987918;
        public bool IsValidVertex(VertexID VertexID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            CallRaw("IsValidVertex", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5986F88 — hookable via Hooks.InstallAt(NativeFunc_IsValidPolygonGroup).</summary>
        public static System.IntPtr NativeFunc_IsValidPolygonGroup => Memory.ModuleBase() + 0x5986F88;
        public bool IsValidPolygonGroup(PolygonGroupID PolygonGroupID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<System.IntPtr>(0x0, PolygonGroupID);
            CallRaw("IsValidPolygonGroup", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5986CE8 — hookable via Hooks.InstallAt(NativeFunc_IsValidPolygon).</summary>
        public static System.IntPtr NativeFunc_IsValidPolygon => Memory.ModuleBase() + 0x5986CE8;
        public bool IsValidPolygon(PolygonID PolygonID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            CallRaw("IsValidPolygon", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5987320 — hookable via Hooks.InstallAt(NativeFunc_IsValidEdge).</summary>
        public static System.IntPtr NativeFunc_IsValidEdge => Memory.ModuleBase() + 0x5987320;
        public bool IsValidEdge(EdgeID EdgeID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            CallRaw("IsValidEdge", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x598677C — hookable via Hooks.InstallAt(NativeFunc_IsUndoAllowed).</summary>
        public static System.IntPtr NativeFunc_IsUndoAllowed => Memory.ModuleBase() + 0x598677C;
        public bool IsUndoAllowed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsUndoAllowed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x59866B8 — hookable via Hooks.InstallAt(NativeFunc_IsSpatialDatabaseAllowed).</summary>
        public static System.IntPtr NativeFunc_IsSpatialDatabaseAllowed => Memory.ModuleBase() + 0x59866B8;
        public bool IsSpatialDatabaseAllowed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsSpatialDatabaseAllowed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x598612C — hookable via Hooks.InstallAt(NativeFunc_IsPreviewingSubdivisions).</summary>
        public static System.IntPtr NativeFunc_IsPreviewingSubdivisions => Memory.ModuleBase() + 0x598612C;
        public bool IsPreviewingSubdivisions()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPreviewingSubdivisions", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x598785C — hookable via Hooks.InstallAt(NativeFunc_IsOrphanedVertex).</summary>
        public static System.IntPtr NativeFunc_IsOrphanedVertex => Memory.ModuleBase() + 0x598785C;
        public bool IsOrphanedVertex(VertexID VertexID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            CallRaw("IsOrphanedVertex", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x59865B8 — hookable via Hooks.InstallAt(NativeFunc_IsCompactAllowed).</summary>
        public static System.IntPtr NativeFunc_IsCompactAllowed => Memory.ModuleBase() + 0x59865B8;
        public bool IsCompactAllowed()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsCompactAllowed", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5987B24 — hookable via Hooks.InstallAt(NativeFunc_IsCommittedAsInstance).</summary>
        public static System.IntPtr NativeFunc_IsCommittedAsInstance => Memory.ModuleBase() + 0x5987B24;
        public bool IsCommittedAsInstance()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsCommittedAsInstance", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5987B5C — hookable via Hooks.InstallAt(NativeFunc_IsCommitted).</summary>
        public static System.IntPtr NativeFunc_IsCommitted => Memory.ModuleBase() + 0x5987B5C;
        public bool IsCommitted()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsCommitted", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x5986798 — hookable via Hooks.InstallAt(NativeFunc_IsBeingModified).</summary>
        public static System.IntPtr NativeFunc_IsBeingModified => Memory.ModuleBase() + 0x5986798;
        public bool IsBeingModified()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsBeingModified", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x59864EC — hookable via Hooks.InstallAt(NativeFunc_InvalidVertexID).</summary>
        public static System.IntPtr NativeFunc_InvalidVertexID => Memory.ModuleBase() + 0x59864EC;
        public VertexID InvalidVertexID()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("InvalidVertexID", __pb.Bytes);
            return __pb.Get<VertexID>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5986480 — hookable via Hooks.InstallAt(NativeFunc_InvalidPolygonID).</summary>
        public static System.IntPtr NativeFunc_InvalidPolygonID => Memory.ModuleBase() + 0x5986480;
        public PolygonID InvalidPolygonID()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("InvalidPolygonID", __pb.Bytes);
            return __pb.Get<PolygonID>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x59864A4 — hookable via Hooks.InstallAt(NativeFunc_InvalidPolygonGroupID).</summary>
        public static System.IntPtr NativeFunc_InvalidPolygonGroupID => Memory.ModuleBase() + 0x59864A4;
        public PolygonGroupID InvalidPolygonGroupID()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("InvalidPolygonGroupID", __pb.Bytes);
            return __pb.Get<PolygonGroupID>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x59864C8 — hookable via Hooks.InstallAt(NativeFunc_InvalidEdgeID).</summary>
        public static System.IntPtr NativeFunc_InvalidEdgeID => Memory.ModuleBase() + 0x59864C8;
        public EdgeID InvalidEdgeID()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("InvalidEdgeID", __pb.Bytes);
            return __pb.Get<EdgeID>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5981D74 — hookable via Hooks.InstallAt(NativeFunc_InsetPolygons).</summary>
        public static System.IntPtr NativeFunc_InsetPolygons => Memory.ModuleBase() + 0x5981D74;
        public void InsetPolygons(System.IntPtr PolygonIDs, float InsetFixedDistance, float InsetProgressTowardCenter, EInsetPolygonsMode Mode, System.IntPtr OutNewCenterPolygonIDs, System.IntPtr OutNewSidePolygonIDs)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, PolygonIDs);
            __pb.Set(0x10, InsetFixedDistance);
            __pb.Set(0x14, InsetProgressTowardCenter);
            __pb.Set<byte>(0x18, (byte)Mode);
            __pb.Set<System.IntPtr>(0x20, OutNewCenterPolygonIDs);
            __pb.Set<System.IntPtr>(0x30, OutNewSidePolygonIDs);
            CallRaw("InsetPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983D40 — hookable via Hooks.InstallAt(NativeFunc_InsertEdgeLoop).</summary>
        public static System.IntPtr NativeFunc_InsertEdgeLoop => Memory.ModuleBase() + 0x5983D40;
        public void InsertEdgeLoop(EdgeID EdgeID, System.IntPtr Splits, System.IntPtr OutNewEdgeIDs)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set<System.IntPtr>(0x8, Splits);
            __pb.Set<System.IntPtr>(0x18, OutNewEdgeIDs);
            CallRaw("InsertEdgeLoop", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5987D3C — hookable via Hooks.InstallAt(NativeFunc_InitializeAdapters).</summary>
        public static System.IntPtr NativeFunc_InitializeAdapters => Memory.ModuleBase() + 0x5987D3C;
        public void InitializeAdapters()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("InitializeAdapters", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5985B78 — hookable via Hooks.InstallAt(NativeFunc_GetVertexPairEdge).</summary>
        public static System.IntPtr NativeFunc_GetVertexPairEdge => Memory.ModuleBase() + 0x5985B78;
        public EdgeID GetVertexPairEdge(VertexID VertexID, VertexID NextVertexID, bool bOutEdgeWindingIsReversed)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            __pb.Set<System.IntPtr>(0x4, NextVertexID);
            __pb.Set<byte>(0x8, (byte)(bOutEdgeWindingIsReversed?1:0));
            CallRaw("GetVertexPairEdge", __pb.Bytes);
            return __pb.Get<EdgeID>(0xC);
        }
        /// <summary>[Native] thunk RVA 0x59875C0 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceVertex).</summary>
        public static System.IntPtr NativeFunc_GetVertexInstanceVertex => Memory.ModuleBase() + 0x59875C0;
        public VertexID GetVertexInstanceVertex(VertexInstanceID VertexInstanceID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, VertexInstanceID);
            CallRaw("GetVertexInstanceVertex", __pb.Bytes);
            return __pb.Get<VertexID>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5987678 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceCount).</summary>
        public static System.IntPtr NativeFunc_GetVertexInstanceCount => Memory.ModuleBase() + 0x5987678;
        public int GetVertexInstanceCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetVertexInstanceCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5985DF0 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceConnectedPolygons).</summary>
        public static System.IntPtr NativeFunc_GetVertexInstanceConnectedPolygons => Memory.ModuleBase() + 0x5985DF0;
        public void GetVertexInstanceConnectedPolygons(VertexInstanceID VertexInstanceID, System.IntPtr OutConnectedPolygonIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, VertexInstanceID);
            __pb.Set<System.IntPtr>(0x8, OutConnectedPolygonIDs);
            CallRaw("GetVertexInstanceConnectedPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5987508 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceConnectedPolygonCount).</summary>
        public static System.IntPtr NativeFunc_GetVertexInstanceConnectedPolygonCount => Memory.ModuleBase() + 0x5987508;
        public int GetVertexInstanceConnectedPolygonCount(VertexInstanceID VertexInstanceID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, VertexInstanceID);
            CallRaw("GetVertexInstanceConnectedPolygonCount", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5987410 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceConnectedPolygon).</summary>
        public static System.IntPtr NativeFunc_GetVertexInstanceConnectedPolygon => Memory.ModuleBase() + 0x5987410;
        public PolygonID GetVertexInstanceConnectedPolygon(VertexInstanceID VertexInstanceID, int ConnectedPolygonNumber)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, VertexInstanceID);
            __pb.Set(0x4, ConnectedPolygonNumber);
            CallRaw("GetVertexInstanceConnectedPolygon", __pb.Bytes);
            return __pb.Get<PolygonID>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x59879D4 — hookable via Hooks.InstallAt(NativeFunc_GetVertexCount).</summary>
        public static System.IntPtr NativeFunc_GetVertexCount => Memory.ModuleBase() + 0x59879D4;
        public int GetVertexCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetVertexCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5985F04 — hookable via Hooks.InstallAt(NativeFunc_GetVertexConnectedPolygons).</summary>
        public static System.IntPtr NativeFunc_GetVertexConnectedPolygons => Memory.ModuleBase() + 0x5985F04;
        public void GetVertexConnectedPolygons(VertexID VertexID, System.IntPtr OutConnectedPolygonIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            __pb.Set<System.IntPtr>(0x8, OutConnectedPolygonIDs);
            CallRaw("GetVertexConnectedPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5986018 — hookable via Hooks.InstallAt(NativeFunc_GetVertexConnectedEdges).</summary>
        public static System.IntPtr NativeFunc_GetVertexConnectedEdges => Memory.ModuleBase() + 0x5986018;
        public void GetVertexConnectedEdges(VertexID VertexID, System.IntPtr OutConnectedEdgeIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            __pb.Set<System.IntPtr>(0x8, OutConnectedEdgeIDs);
            CallRaw("GetVertexConnectedEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59877A4 — hookable via Hooks.InstallAt(NativeFunc_GetVertexConnectedEdgeCount).</summary>
        public static System.IntPtr NativeFunc_GetVertexConnectedEdgeCount => Memory.ModuleBase() + 0x59877A4;
        public int GetVertexConnectedEdgeCount(VertexID VertexID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            CallRaw("GetVertexConnectedEdgeCount", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x59876AC — hookable via Hooks.InstallAt(NativeFunc_GetVertexConnectedEdge).</summary>
        public static System.IntPtr NativeFunc_GetVertexConnectedEdge => Memory.ModuleBase() + 0x59876AC;
        public EdgeID GetVertexConnectedEdge(VertexID VertexID, int ConnectedEdgeNumber)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            __pb.Set(0x4, ConnectedEdgeNumber);
            CallRaw("GetVertexConnectedEdge", __pb.Bytes);
            return __pb.Get<EdgeID>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5985CDC — hookable via Hooks.InstallAt(NativeFunc_GetVertexAdjacentVertices).</summary>
        public static System.IntPtr NativeFunc_GetVertexAdjacentVertices => Memory.ModuleBase() + 0x5985CDC;
        public void GetVertexAdjacentVertices(VertexID VertexID, System.IntPtr OutAdjacentVertexIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            __pb.Set<System.IntPtr>(0x8, OutAdjacentVertexIDs);
            CallRaw("GetVertexAdjacentVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5986198 — hookable via Hooks.InstallAt(NativeFunc_GetTextureCoordinateCount).</summary>
        public static System.IntPtr NativeFunc_GetTextureCoordinateCount => Memory.ModuleBase() + 0x5986198;
        public int GetTextureCoordinateCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetTextureCoordinateCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5984954 — hookable via Hooks.InstallAt(NativeFunc_GetSubdivisionLimitData).</summary>
        public static System.IntPtr NativeFunc_GetSubdivisionLimitData => Memory.ModuleBase() + 0x5984954;
        public SubdivisionLimitData GetSubdivisionLimitData()
        {
            var __pb = new ParamBuffer(48);
            CallRaw("GetSubdivisionLimitData", __pb.Bytes);
            return __pb.Get<SubdivisionLimitData>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5986164 — hookable via Hooks.InstallAt(NativeFunc_GetSubdivisionCount).</summary>
        public static System.IntPtr NativeFunc_GetSubdivisionCount => Memory.ModuleBase() + 0x5986164;
        public int GetSubdivisionCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetSubdivisionCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x59868D0 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonTriangulatedTriangleCount).</summary>
        public static System.IntPtr NativeFunc_GetPolygonTriangulatedTriangleCount => Memory.ModuleBase() + 0x59868D0;
        public int GetPolygonTriangulatedTriangleCount(PolygonID PolygonID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            CallRaw("GetPolygonTriangulatedTriangleCount", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x59867D8 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonTriangulatedTriangle).</summary>
        public static System.IntPtr NativeFunc_GetPolygonTriangulatedTriangle => Memory.ModuleBase() + 0x59867D8;
        public TriangleID GetPolygonTriangulatedTriangle(PolygonID PolygonID, int PolygonTriangleNumber)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set(0x4, PolygonTriangleNumber);
            CallRaw("GetPolygonTriangulatedTriangle", __pb.Bytes);
            return __pb.Get<TriangleID>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5985524 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPerimeterVertices).</summary>
        public static System.IntPtr NativeFunc_GetPolygonPerimeterVertices => Memory.ModuleBase() + 0x5985524;
        public void GetPolygonPerimeterVertices(PolygonID PolygonID, System.IntPtr OutPolygonPerimeterVertexIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set<System.IntPtr>(0x8, OutPolygonPerimeterVertexIDs);
            CallRaw("GetPolygonPerimeterVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5985410 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPerimeterVertexInstances).</summary>
        public static System.IntPtr NativeFunc_GetPolygonPerimeterVertexInstances => Memory.ModuleBase() + 0x5985410;
        public void GetPolygonPerimeterVertexInstances(PolygonID PolygonID, System.IntPtr OutPolygonPerimeterVertexInstanceIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set<System.IntPtr>(0x8, OutPolygonPerimeterVertexInstanceIDs);
            CallRaw("GetPolygonPerimeterVertexInstances", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5986988 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPerimeterVertexInstance).</summary>
        public static System.IntPtr NativeFunc_GetPolygonPerimeterVertexInstance => Memory.ModuleBase() + 0x5986988;
        public VertexInstanceID GetPolygonPerimeterVertexInstance(PolygonID PolygonID, int PolygonVertexNumber)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set(0x4, PolygonVertexNumber);
            CallRaw("GetPolygonPerimeterVertexInstance", __pb.Bytes);
            return __pb.Get<VertexInstanceID>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5986B78 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPerimeterVertexCount).</summary>
        public static System.IntPtr NativeFunc_GetPolygonPerimeterVertexCount => Memory.ModuleBase() + 0x5986B78;
        public int GetPolygonPerimeterVertexCount(PolygonID PolygonID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            CallRaw("GetPolygonPerimeterVertexCount", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5986A80 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPerimeterVertex).</summary>
        public static System.IntPtr NativeFunc_GetPolygonPerimeterVertex => Memory.ModuleBase() + 0x5986A80;
        public VertexID GetPolygonPerimeterVertex(PolygonID PolygonID, int PolygonVertexNumber)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set(0x4, PolygonVertexNumber);
            CallRaw("GetPolygonPerimeterVertex", __pb.Bytes);
            return __pb.Get<VertexID>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x59851AC — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPerimeterEdges).</summary>
        public static System.IntPtr NativeFunc_GetPolygonPerimeterEdges => Memory.ModuleBase() + 0x59851AC;
        public void GetPolygonPerimeterEdges(PolygonID PolygonID, System.IntPtr OutPolygonPerimeterEdgeIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set<System.IntPtr>(0x8, OutPolygonPerimeterEdgeIDs);
            CallRaw("GetPolygonPerimeterEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5985638 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPerimeterEdgeCount).</summary>
        public static System.IntPtr NativeFunc_GetPolygonPerimeterEdgeCount => Memory.ModuleBase() + 0x5985638;
        public int GetPolygonPerimeterEdgeCount(PolygonID PolygonID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            CallRaw("GetPolygonPerimeterEdgeCount", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x59852C0 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPerimeterEdge).</summary>
        public static System.IntPtr NativeFunc_GetPolygonPerimeterEdge => Memory.ModuleBase() + 0x59852C0;
        public EdgeID GetPolygonPerimeterEdge(PolygonID PolygonID, int PerimeterEdgeNumber, bool bOutEdgeWindingIsReversedForPolygon)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set(0x4, PerimeterEdgeNumber);
            __pb.Set<byte>(0x8, (byte)(bOutEdgeWindingIsReversedForPolygon?1:0));
            CallRaw("GetPolygonPerimeterEdge", __pb.Bytes);
            return __pb.Get<EdgeID>(0xC);
        }
        /// <summary>[Native] thunk RVA 0x5986DD8 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonInGroup).</summary>
        public static System.IntPtr NativeFunc_GetPolygonInGroup => Memory.ModuleBase() + 0x5986DD8;
        public PolygonID GetPolygonInGroup(PolygonGroupID PolygonGroupID, int PolygonNumber)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, PolygonGroupID);
            __pb.Set(0x4, PolygonNumber);
            CallRaw("GetPolygonInGroup", __pb.Bytes);
            return __pb.Get<PolygonID>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5987044 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonGroupCount).</summary>
        public static System.IntPtr NativeFunc_GetPolygonGroupCount => Memory.ModuleBase() + 0x5987044;
        public int GetPolygonGroupCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPolygonGroupCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5986ED0 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonCountInGroup).</summary>
        public static System.IntPtr NativeFunc_GetPolygonCountInGroup => Memory.ModuleBase() + 0x5986ED0;
        public int GetPolygonCountInGroup(PolygonGroupID PolygonGroupID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, PolygonGroupID);
            CallRaw("GetPolygonCountInGroup", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5986DA4 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonCount).</summary>
        public static System.IntPtr NativeFunc_GetPolygonCount => Memory.ModuleBase() + 0x5986DA4;
        public int GetPolygonCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPolygonCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5985098 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonAdjacentPolygons).</summary>
        public static System.IntPtr NativeFunc_GetPolygonAdjacentPolygons => Memory.ModuleBase() + 0x5985098;
        public void GetPolygonAdjacentPolygons(PolygonID PolygonID, System.IntPtr OutAdjacentPolygons)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set<System.IntPtr>(0x8, OutAdjacentPolygons);
            CallRaw("GetPolygonAdjacentPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5986C30 — hookable via Hooks.InstallAt(NativeFunc_GetGroupForPolygon).</summary>
        public static System.IntPtr NativeFunc_GetGroupForPolygon => Memory.ModuleBase() + 0x5986C30;
        public PolygonGroupID GetGroupForPolygon(PolygonID PolygonID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            CallRaw("GetGroupForPolygon", __pb.Bytes);
            return __pb.Get<PolygonGroupID>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x59861CC — hookable via Hooks.InstallAt(NativeFunc_GetFirstValidPolygonGroup).</summary>
        public static System.IntPtr NativeFunc_GetFirstValidPolygonGroup => Memory.ModuleBase() + 0x59861CC;
        public PolygonGroupID GetFirstValidPolygonGroup()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetFirstValidPolygonGroup", __pb.Bytes);
            return __pb.Get<PolygonGroupID>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5985A24 — hookable via Hooks.InstallAt(NativeFunc_GetEdgeVertices).</summary>
        public static System.IntPtr NativeFunc_GetEdgeVertices => Memory.ModuleBase() + 0x5985A24;
        public void GetEdgeVertices(EdgeID EdgeID, VertexID OutEdgeVertexID0, VertexID OutEdgeVertexID1)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set<System.IntPtr>(0x4, OutEdgeVertexID0);
            __pb.Set<System.IntPtr>(0x8, OutEdgeVertexID1);
            CallRaw("GetEdgeVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5987228 — hookable via Hooks.InstallAt(NativeFunc_GetEdgeVertex).</summary>
        public static System.IntPtr NativeFunc_GetEdgeVertex => Memory.ModuleBase() + 0x5987228;
        public VertexID GetEdgeVertex(EdgeID EdgeID, int EdgeVertexNumber)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set(0x4, EdgeVertexNumber);
            CallRaw("GetEdgeVertex", __pb.Bytes);
            return __pb.Get<VertexID>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x59856F0 — hookable via Hooks.InstallAt(NativeFunc_GetEdgeThatConnectsVertices).</summary>
        public static System.IntPtr NativeFunc_GetEdgeThatConnectsVertices => Memory.ModuleBase() + 0x59856F0;
        public EdgeID GetEdgeThatConnectsVertices(VertexID VertexID0, VertexID VertexID1)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, VertexID0);
            __pb.Set<System.IntPtr>(0x4, VertexID1);
            CallRaw("GetEdgeThatConnectsVertices", __pb.Bytes);
            return __pb.Get<EdgeID>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x59857FC — hookable via Hooks.InstallAt(NativeFunc_GetEdgeLoopElements).</summary>
        public static System.IntPtr NativeFunc_GetEdgeLoopElements => Memory.ModuleBase() + 0x59857FC;
        public void GetEdgeLoopElements(EdgeID EdgeID, System.IntPtr EdgeLoopIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set<System.IntPtr>(0x8, EdgeLoopIDs);
            CallRaw("GetEdgeLoopElements", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59873DC — hookable via Hooks.InstallAt(NativeFunc_GetEdgeCount).</summary>
        public static System.IntPtr NativeFunc_GetEdgeCount => Memory.ModuleBase() + 0x59873DC;
        public int GetEdgeCount()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetEdgeCount", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5985910 — hookable via Hooks.InstallAt(NativeFunc_GetEdgeConnectedPolygons).</summary>
        public static System.IntPtr NativeFunc_GetEdgeConnectedPolygons => Memory.ModuleBase() + 0x5985910;
        public void GetEdgeConnectedPolygons(EdgeID EdgeID, System.IntPtr OutConnectedPolygonIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set<System.IntPtr>(0x8, OutConnectedPolygonIDs);
            CallRaw("GetEdgeConnectedPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5987170 — hookable via Hooks.InstallAt(NativeFunc_GetEdgeConnectedPolygonCount).</summary>
        public static System.IntPtr NativeFunc_GetEdgeConnectedPolygonCount => Memory.ModuleBase() + 0x5987170;
        public int GetEdgeConnectedPolygonCount(EdgeID EdgeID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            CallRaw("GetEdgeConnectedPolygonCount", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5987078 — hookable via Hooks.InstallAt(NativeFunc_GetEdgeConnectedPolygon).</summary>
        public static System.IntPtr NativeFunc_GetEdgeConnectedPolygon => Memory.ModuleBase() + 0x5987078;
        public PolygonID GetEdgeConnectedPolygon(EdgeID EdgeID, int ConnectedPolygonNumber)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set(0x4, ConnectedPolygonNumber);
            CallRaw("GetEdgeConnectedPolygon", __pb.Bytes);
            return __pb.Get<PolygonID>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5980D80 — hookable via Hooks.InstallAt(NativeFunc_GeneratePolygonTangentsAndNormals).</summary>
        public static System.IntPtr NativeFunc_GeneratePolygonTangentsAndNormals => Memory.ModuleBase() + 0x5980D80;
        public void GeneratePolygonTangentsAndNormals(System.IntPtr PolygonIDs)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, PolygonIDs);
            CallRaw("GeneratePolygonTangentsAndNormals", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5981658 — hookable via Hooks.InstallAt(NativeFunc_FlipPolygons).</summary>
        public static System.IntPtr NativeFunc_FlipPolygons => Memory.ModuleBase() + 0x5981658;
        public void FlipPolygons(System.IntPtr PolygonIDs)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, PolygonIDs);
            CallRaw("FlipPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5984F8C — hookable via Hooks.InstallAt(NativeFunc_FindPolygonPerimeterVertexNumberForVertex).</summary>
        public static System.IntPtr NativeFunc_FindPolygonPerimeterVertexNumberForVertex => Memory.ModuleBase() + 0x5984F8C;
        public int FindPolygonPerimeterVertexNumberForVertex(PolygonID PolygonID, VertexID VertexID)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set<System.IntPtr>(0x4, VertexID);
            CallRaw("FindPolygonPerimeterVertexNumberForVertex", __pb.Bytes);
            return __pb.Get<int>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x5984E34 — hookable via Hooks.InstallAt(NativeFunc_FindPolygonPerimeterEdgeNumberForVertices).</summary>
        public static System.IntPtr NativeFunc_FindPolygonPerimeterEdgeNumberForVertices => Memory.ModuleBase() + 0x5984E34;
        public int FindPolygonPerimeterEdgeNumberForVertices(PolygonID PolygonID, VertexID EdgeVertexID0, VertexID EdgeVertexID1)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set<System.IntPtr>(0x4, EdgeVertexID0);
            __pb.Set<System.IntPtr>(0x8, EdgeVertexID1);
            CallRaw("FindPolygonPerimeterEdgeNumberForVertices", __pb.Bytes);
            return __pb.Get<int>(0xC);
        }
        /// <summary>[Native] thunk RVA 0x5984608 — hookable via Hooks.InstallAt(NativeFunc_FindPolygonLoop).</summary>
        public static System.IntPtr NativeFunc_FindPolygonLoop => Memory.ModuleBase() + 0x5984608;
        public void FindPolygonLoop(EdgeID EdgeID, System.IntPtr OutEdgeLoopEdgeIDs, System.IntPtr OutFlippedEdgeIDs, System.IntPtr OutReversedEdgeIDPathToTake, System.IntPtr OutPolygonIDsToSplit)
        {
            var __pb = new ParamBuffer(72);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set<System.IntPtr>(0x8, OutEdgeLoopEdgeIDs);
            __pb.Set<System.IntPtr>(0x18, OutFlippedEdgeIDs);
            __pb.Set<System.IntPtr>(0x28, OutReversedEdgeIDPathToTake);
            __pb.Set<System.IntPtr>(0x38, OutPolygonIDsToSplit);
            CallRaw("FindPolygonLoop", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59822E0 — hookable via Hooks.InstallAt(NativeFunc_ExtrudePolygons).</summary>
        public static System.IntPtr NativeFunc_ExtrudePolygons => Memory.ModuleBase() + 0x59822E0;
        public void ExtrudePolygons(System.IntPtr Polygons, float ExtrudeDistance, bool bKeepNeighborsTogether, System.IntPtr OutNewExtrudedFrontPolygons)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, Polygons);
            __pb.Set(0x10, ExtrudeDistance);
            __pb.Set<byte>(0x14, (byte)(bKeepNeighborsTogether?1:0));
            __pb.Set<System.IntPtr>(0x18, OutNewExtrudedFrontPolygons);
            CallRaw("ExtrudePolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5981FC0 — hookable via Hooks.InstallAt(NativeFunc_ExtendVertices).</summary>
        public static System.IntPtr NativeFunc_ExtendVertices => Memory.ModuleBase() + 0x5981FC0;
        public void ExtendVertices(System.IntPtr VertexIDs, bool bOnlyExtendClosestEdge, Vector ReferencePosition, System.IntPtr OutNewExtendedVertexIDs)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, VertexIDs);
            __pb.Set<byte>(0x10, (byte)(bOnlyExtendClosestEdge?1:0));
            __pb.Set<System.IntPtr>(0x14, ReferencePosition);
            __pb.Set<System.IntPtr>(0x20, OutNewExtendedVertexIDs);
            CallRaw("ExtendVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5982178 — hookable via Hooks.InstallAt(NativeFunc_ExtendEdges).</summary>
        public static System.IntPtr NativeFunc_ExtendEdges => Memory.ModuleBase() + 0x5982178;
        public void ExtendEdges(System.IntPtr EdgeIDs, bool bWeldNeighbors, System.IntPtr OutNewExtendedEdgeIDs)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, EdgeIDs);
            __pb.Set<byte>(0x10, (byte)(bWeldNeighbors?1:0));
            __pb.Set<System.IntPtr>(0x18, OutNewExtendedEdgeIDs);
            CallRaw("ExtendEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5987B94 — hookable via Hooks.InstallAt(NativeFunc_EndModification).</summary>
        public static System.IntPtr NativeFunc_EndModification => Memory.ModuleBase() + 0x5987B94;
        public void EndModification(bool bFromUndo)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bFromUndo?1:0));
            CallRaw("EndModification", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983638 — hookable via Hooks.InstallAt(NativeFunc_DeleteVertexInstances).</summary>
        public static System.IntPtr NativeFunc_DeleteVertexInstances => Memory.ModuleBase() + 0x5983638;
        public void DeleteVertexInstances(System.IntPtr VertexInstanceIDsToDelete, bool bDeleteOrphanedVertices)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, VertexInstanceIDsToDelete);
            __pb.Set<byte>(0x10, (byte)(bDeleteOrphanedVertices?1:0));
            CallRaw("DeleteVertexInstances", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983800 — hookable via Hooks.InstallAt(NativeFunc_DeleteVertexAndConnectedEdgesAndPolygons).</summary>
        public static System.IntPtr NativeFunc_DeleteVertexAndConnectedEdgesAndPolygons => Memory.ModuleBase() + 0x5983800;
        public void DeleteVertexAndConnectedEdgesAndPolygons(VertexID VertexID, bool bDeleteOrphanedEdges, bool bDeleteOrphanedVertices, bool bDeleteOrphanedVertexInstances, bool bDeleteEmptyPolygonGroups)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, VertexID);
            __pb.Set<byte>(0x4, (byte)(bDeleteOrphanedEdges?1:0));
            __pb.Set<byte>(0x5, (byte)(bDeleteOrphanedVertices?1:0));
            __pb.Set<byte>(0x6, (byte)(bDeleteOrphanedVertexInstances?1:0));
            __pb.Set<byte>(0x7, (byte)(bDeleteEmptyPolygonGroups?1:0));
            CallRaw("DeleteVertexAndConnectedEdgesAndPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5982C30 — hookable via Hooks.InstallAt(NativeFunc_DeletePolygons).</summary>
        public static System.IntPtr NativeFunc_DeletePolygons => Memory.ModuleBase() + 0x5982C30;
        public void DeletePolygons(System.IntPtr PolygonIDsToDelete, bool bDeleteOrphanedEdges, bool bDeleteOrphanedVertices, bool bDeleteOrphanedVertexInstances, bool bDeleteEmptyPolygonGroups)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<System.IntPtr>(0x0, PolygonIDsToDelete);
            __pb.Set<byte>(0x10, (byte)(bDeleteOrphanedEdges?1:0));
            __pb.Set<byte>(0x11, (byte)(bDeleteOrphanedVertices?1:0));
            __pb.Set<byte>(0x12, (byte)(bDeleteOrphanedVertexInstances?1:0));
            __pb.Set<byte>(0x13, (byte)(bDeleteEmptyPolygonGroups?1:0));
            CallRaw("DeletePolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x598132C — hookable via Hooks.InstallAt(NativeFunc_DeletePolygonGroups).</summary>
        public static System.IntPtr NativeFunc_DeletePolygonGroups => Memory.ModuleBase() + 0x598132C;
        public void DeletePolygonGroups(System.IntPtr PolygonGroupIDs)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, PolygonGroupIDs);
            CallRaw("DeletePolygonGroups", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983740 — hookable via Hooks.InstallAt(NativeFunc_DeleteOrphanVertices).</summary>
        public static System.IntPtr NativeFunc_DeleteOrphanVertices => Memory.ModuleBase() + 0x5983740;
        public void DeleteOrphanVertices(System.IntPtr VertexIDsToDelete)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, VertexIDsToDelete);
            CallRaw("DeleteOrphanVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983530 — hookable via Hooks.InstallAt(NativeFunc_DeleteEdges).</summary>
        public static System.IntPtr NativeFunc_DeleteEdges => Memory.ModuleBase() + 0x5983530;
        public void DeleteEdges(System.IntPtr EdgeIDsToDelete, bool bDeleteOrphanedVertices)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, EdgeIDsToDelete);
            __pb.Set<byte>(0x10, (byte)(bDeleteOrphanedVertices?1:0));
            CallRaw("DeleteEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59839F4 — hookable via Hooks.InstallAt(NativeFunc_DeleteEdgeAndConnectedPolygons).</summary>
        public static System.IntPtr NativeFunc_DeleteEdgeAndConnectedPolygons => Memory.ModuleBase() + 0x59839F4;
        public void DeleteEdgeAndConnectedPolygons(EdgeID EdgeID, bool bDeleteOrphanedEdges, bool bDeleteOrphanedVertices, bool bDeleteOrphanedVertexInstances, bool bDeleteEmptyPolygonGroups)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<System.IntPtr>(0x0, EdgeID);
            __pb.Set<byte>(0x4, (byte)(bDeleteOrphanedEdges?1:0));
            __pb.Set<byte>(0x5, (byte)(bDeleteOrphanedVertices?1:0));
            __pb.Set<byte>(0x6, (byte)(bDeleteOrphanedVertexInstances?1:0));
            __pb.Set<byte>(0x7, (byte)(bDeleteEmptyPolygonGroups?1:0));
            CallRaw("DeleteEdgeAndConnectedPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59832D8 — hookable via Hooks.InstallAt(NativeFunc_CreateVertices).</summary>
        public static System.IntPtr NativeFunc_CreateVertices => Memory.ModuleBase() + 0x59832D8;
        public void CreateVertices(System.IntPtr VerticesToCreate, System.IntPtr OutNewVertexIDs)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, VerticesToCreate);
            __pb.Set<System.IntPtr>(0x10, OutNewVertexIDs);
            CallRaw("CreateVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983180 — hookable via Hooks.InstallAt(NativeFunc_CreateVertexInstances).</summary>
        public static System.IntPtr NativeFunc_CreateVertexInstances => Memory.ModuleBase() + 0x5983180;
        public void CreateVertexInstances(System.IntPtr VertexInstancesToCreate, System.IntPtr OutNewVertexInstanceIDs)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, VertexInstancesToCreate);
            __pb.Set<System.IntPtr>(0x10, OutNewVertexInstanceIDs);
            CallRaw("CreateVertexInstances", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5982E38 — hookable via Hooks.InstallAt(NativeFunc_CreatePolygons).</summary>
        public static System.IntPtr NativeFunc_CreatePolygons => Memory.ModuleBase() + 0x5982E38;
        public void CreatePolygons(System.IntPtr PolygonsToCreate, System.IntPtr OutNewPolygonIDs, System.IntPtr OutNewEdgeIDs)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, PolygonsToCreate);
            __pb.Set<System.IntPtr>(0x10, OutNewPolygonIDs);
            __pb.Set<System.IntPtr>(0x20, OutNewEdgeIDs);
            CallRaw("CreatePolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59813EC — hookable via Hooks.InstallAt(NativeFunc_CreatePolygonGroups).</summary>
        public static System.IntPtr NativeFunc_CreatePolygonGroups => Memory.ModuleBase() + 0x59813EC;
        public void CreatePolygonGroups(System.IntPtr PolygonGroupsToCreate, System.IntPtr OutNewPolygonGroupIDs)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, PolygonGroupsToCreate);
            __pb.Set<System.IntPtr>(0x10, OutNewPolygonGroupIDs);
            CallRaw("CreatePolygonGroups", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5984020 — hookable via Hooks.InstallAt(NativeFunc_CreateMissingPolygonPerimeterEdges).</summary>
        public static System.IntPtr NativeFunc_CreateMissingPolygonPerimeterEdges => Memory.ModuleBase() + 0x5984020;
        public void CreateMissingPolygonPerimeterEdges(PolygonID PolygonID, System.IntPtr OutNewEdgeIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            __pb.Set<System.IntPtr>(0x8, OutNewEdgeIDs);
            CallRaw("CreateMissingPolygonPerimeterEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983428 — hookable via Hooks.InstallAt(NativeFunc_CreateEmptyVertexRange).</summary>
        public static System.IntPtr NativeFunc_CreateEmptyVertexRange => Memory.ModuleBase() + 0x5983428;
        public void CreateEmptyVertexRange(int NumVerticesToCreate, System.IntPtr OutNewVertexIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set(0x0, NumVerticesToCreate);
            __pb.Set<System.IntPtr>(0x8, OutNewVertexIDs);
            CallRaw("CreateEmptyVertexRange", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5983028 — hookable via Hooks.InstallAt(NativeFunc_CreateEdges).</summary>
        public static System.IntPtr NativeFunc_CreateEdges => Memory.ModuleBase() + 0x5983028;
        public void CreateEdges(System.IntPtr EdgesToCreate, System.IntPtr OutNewEdgeIDs)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, EdgesToCreate);
            __pb.Set<System.IntPtr>(0x10, OutNewEdgeIDs);
            CallRaw("CreateEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5984838 — hookable via Hooks.InstallAt(NativeFunc_ComputePolygonsSharedEdges).</summary>
        public static System.IntPtr NativeFunc_ComputePolygonsSharedEdges => Memory.ModuleBase() + 0x5984838;
        public void ComputePolygonsSharedEdges(System.IntPtr PolygonIDs, System.IntPtr OutSharedEdgeIDs)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, PolygonIDs);
            __pb.Set<System.IntPtr>(0x10, OutSharedEdgeIDs);
            CallRaw("ComputePolygonsSharedEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5984BE4 — hookable via Hooks.InstallAt(NativeFunc_ComputePolygonPlane).</summary>
        public static System.IntPtr NativeFunc_ComputePolygonPlane => Memory.ModuleBase() + 0x5984BE4;
        public Plane ComputePolygonPlane(PolygonID PolygonID)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            CallRaw("ComputePolygonPlane", __pb.Bytes);
            return __pb.Get<Plane>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x5984B28 — hookable via Hooks.InstallAt(NativeFunc_ComputePolygonNormal).</summary>
        public static System.IntPtr NativeFunc_ComputePolygonNormal => Memory.ModuleBase() + 0x5984B28;
        public Vector ComputePolygonNormal(PolygonID PolygonID)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            CallRaw("ComputePolygonNormal", __pb.Bytes);
            return __pb.Get<Vector>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5984CA0 — hookable via Hooks.InstallAt(NativeFunc_ComputePolygonCenter).</summary>
        public static System.IntPtr NativeFunc_ComputePolygonCenter => Memory.ModuleBase() + 0x5984CA0;
        public Vector ComputePolygonCenter(PolygonID PolygonID)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, PolygonID);
            CallRaw("ComputePolygonCenter", __pb.Bytes);
            return __pb.Get<Vector>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x5984D5C — hookable via Hooks.InstallAt(NativeFunc_ComputeBoundingBoxAndSphere).</summary>
        public static System.IntPtr NativeFunc_ComputeBoundingBoxAndSphere => Memory.ModuleBase() + 0x5984D5C;
        public BoxSphereBounds ComputeBoundingBoxAndSphere()
        {
            var __pb = new ParamBuffer(28);
            CallRaw("ComputeBoundingBoxAndSphere", __pb.Bytes);
            return __pb.Get<BoxSphereBounds>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5984DC8 — hookable via Hooks.InstallAt(NativeFunc_ComputeBoundingBox).</summary>
        public static System.IntPtr NativeFunc_ComputeBoundingBox => Memory.ModuleBase() + 0x5984DC8;
        public Box ComputeBoundingBox()
        {
            var __pb = new ParamBuffer(28);
            CallRaw("ComputeBoundingBox", __pb.Bytes);
            return __pb.Get<Box>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5987A64 — hookable via Hooks.InstallAt(NativeFunc_CommitInstance).</summary>
        public static System.IntPtr NativeFunc_CommitInstance => Memory.ModuleBase() + 0x5987A64;
        public EditableMesh CommitInstance(PrimitiveComponent ComponentToInstanceTo)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, ComponentToInstanceTo);
            CallRaw("CommitInstance", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x8); return __p==System.IntPtr.Zero?null:new EditableMesh(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5987B10 — hookable via Hooks.InstallAt(NativeFunc_Commit).</summary>
        public static System.IntPtr NativeFunc_Commit => Memory.ModuleBase() + 0x5987B10;
        public void Commit()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Commit", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5982744 — hookable via Hooks.InstallAt(NativeFunc_ChangePolygonsVertexInstances).</summary>
        public static System.IntPtr NativeFunc_ChangePolygonsVertexInstances => Memory.ModuleBase() + 0x5982744;
        public void ChangePolygonsVertexInstances(System.IntPtr VertexInstancesForPolygons)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, VertexInstancesForPolygons);
            CallRaw("ChangePolygonsVertexInstances", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5981B6C — hookable via Hooks.InstallAt(NativeFunc_BevelPolygons).</summary>
        public static System.IntPtr NativeFunc_BevelPolygons => Memory.ModuleBase() + 0x5981B6C;
        public void BevelPolygons(System.IntPtr PolygonIDs, float BevelFixedDistance, float BevelProgressTowardCenter, System.IntPtr OutNewCenterPolygonIDs, System.IntPtr OutNewSidePolygonIDs)
        {
            var __pb = new ParamBuffer(56);
            __pb.Set<System.IntPtr>(0x0, PolygonIDs);
            __pb.Set(0x10, BevelFixedDistance);
            __pb.Set(0x14, BevelProgressTowardCenter);
            __pb.Set<System.IntPtr>(0x18, OutNewCenterPolygonIDs);
            __pb.Set<System.IntPtr>(0x28, OutNewSidePolygonIDs);
            CallRaw("BevelPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5981224 — hookable via Hooks.InstallAt(NativeFunc_AssignPolygonsToPolygonGroups).</summary>
        public static System.IntPtr NativeFunc_AssignPolygonsToPolygonGroups => Memory.ModuleBase() + 0x5981224;
        public void AssignPolygonsToPolygonGroups(System.IntPtr PolygonGroupForPolygons, bool bDeleteOrphanedPolygonGroups)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, PolygonGroupForPolygons);
            __pb.Set<byte>(0x10, (byte)(bDeleteOrphanedPolygonGroups?1:0));
            CallRaw("AssignPolygonsToPolygonGroups", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x59865D4 — hookable via Hooks.InstallAt(NativeFunc_AnyChangesToUndo).</summary>
        public static System.IntPtr NativeFunc_AnyChangesToUndo => Memory.ModuleBase() + 0x59865D4;
        public bool AnyChangesToUndo()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("AnyChangesToUndo", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
    }

    public class EditableMeshFactory : Object
    {
        public const string UeClassName = "EditableMeshFactory";
        public EditableMeshFactory(System.IntPtr ptr) : base(ptr) {}
        public static new EditableMeshFactory FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableMeshFactory(p);
        public static EditableMeshFactory FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableMeshFactory(o.Pointer); }
        public static EditableMeshFactory[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableMeshFactory[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableMeshFactory(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x598D864 — hookable via Hooks.InstallAt(NativeFunc_MakeEditableMesh).</summary>
        public static System.IntPtr NativeFunc_MakeEditableMesh => Memory.ModuleBase() + 0x598D864;
        public EditableMesh MakeEditableMesh(PrimitiveComponent PrimitiveComponent, int LODIndex)
        {
            var __pb = new ParamBuffer(24);
            __pb.SetObject(0x0, PrimitiveComponent);
            __pb.Set(0x8, LODIndex);
            CallRaw("MakeEditableMesh", __pb.Bytes);
            { var __p = __pb.Get<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new EditableMesh(__p); }
        }
    }

    public class EditableStaticMeshAdapter : EditableMeshAdapter
    {
        public const string UeClassName = "EditableStaticMeshAdapter";
        public EditableStaticMeshAdapter(System.IntPtr ptr) : base(ptr) {}
        public static new EditableStaticMeshAdapter FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableStaticMeshAdapter(p);
        public static EditableStaticMeshAdapter FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableStaticMeshAdapter(o.Pointer); }
        public static EditableStaticMeshAdapter[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableStaticMeshAdapter[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableStaticMeshAdapter(a[i].Pointer); return r; }
        public StaticMesh StaticMesh { get { var __p = GetAt<System.IntPtr>(0x28); return __p==System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x28, value?.Pointer ?? System.IntPtr.Zero); }
        public StaticMesh OriginalStaticMesh { get { var __p = GetAt<System.IntPtr>(0x30); return __p==System.IntPtr.Zero?null:new StaticMesh(__p); } set => SetAt(0x30, value?.Pointer ?? System.IntPtr.Zero); }
        public int StaticMeshLODIndex { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
    }

}
