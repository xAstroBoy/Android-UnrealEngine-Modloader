// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/MeshDescription
using System;

namespace UEModLoader.Game
{
    public enum EComputeNTBsOptions
    {
        None = 0,
        Normals = 1,
        Tangents = 2,
        WeightedNTBs = 4,
    }

    public class ElementID : StructProxy
    {
        public ElementID(global::System.IntPtr ptr) : base(ptr) {}
        public int IDValue { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
    }

    public class PolygonGroupID : StructProxy
    {
        public PolygonGroupID(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class PolygonID : StructProxy
    {
        public PolygonID(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class VertexID : StructProxy
    {
        public VertexID(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class VertexInstanceID : StructProxy
    {
        public VertexInstanceID(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class EdgeID : StructProxy
    {
        public EdgeID(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class TriangleID : StructProxy
    {
        public TriangleID(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class MeshDescription : Object
    {
        public const string UeClassName = "MeshDescription";
        public MeshDescription(global::System.IntPtr ptr) : base(ptr) {}
        public static new MeshDescription FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MeshDescription(p);
        public static MeshDescription FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MeshDescription(o.Pointer); }
        public static MeshDescription[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MeshDescription[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MeshDescription(a[i].Pointer); return r; }
    }

    public class MeshDescriptionBase : Object
    {
        public const string UeClassName = "MeshDescriptionBase";
        public MeshDescriptionBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new MeshDescriptionBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new MeshDescriptionBase(p);
        public static MeshDescriptionBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MeshDescriptionBase(o.Pointer); }
        public static MeshDescriptionBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MeshDescriptionBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MeshDescriptionBase(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x8017C34 — hookable via Hooks.InstallAt(NativeFunc_SetVertexPosition).</summary>
        public static global::System.IntPtr NativeFunc_SetVertexPosition => Memory.ModuleBase() + 0x8017C34;
        public void SetVertexPosition(global::System.IntPtr VertexID, global::System.IntPtr Position)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            __pb.Set<global::System.IntPtr>(0x4, Position);
            CallRaw("SetVertexPosition", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8015B48 — hookable via Hooks.InstallAt(NativeFunc_SetPolygonVertexInstance).</summary>
        public static global::System.IntPtr NativeFunc_SetPolygonVertexInstance => Memory.ModuleBase() + 0x8015B48;
        public void SetPolygonVertexInstance(global::System.IntPtr PolygonID, int PerimeterIndex, global::System.IntPtr VertexInstanceID)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set(0x4, PerimeterIndex);
            __pb.Set<global::System.IntPtr>(0x8, VertexInstanceID);
            CallRaw("SetPolygonVertexInstance", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8015A4C — hookable via Hooks.InstallAt(NativeFunc_SetPolygonPolygonGroup).</summary>
        public static global::System.IntPtr NativeFunc_SetPolygonPolygonGroup => Memory.ModuleBase() + 0x8015A4C;
        public void SetPolygonPolygonGroup(global::System.IntPtr PolygonID, global::System.IntPtr PolygonGroupID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x4, PolygonGroupID);
            CallRaw("SetPolygonPolygonGroup", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801599C — hookable via Hooks.InstallAt(NativeFunc_ReversePolygonFacing).</summary>
        public static global::System.IntPtr NativeFunc_ReversePolygonFacing => Memory.ModuleBase() + 0x801599C;
        public void ReversePolygonFacing(global::System.IntPtr PolygonID)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            CallRaw("ReversePolygonFacing", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801A310 — hookable via Hooks.InstallAt(NativeFunc_ReserveNewVertices).</summary>
        public static global::System.IntPtr NativeFunc_ReserveNewVertices => Memory.ModuleBase() + 0x801A310;
        public void ReserveNewVertices(int NumberOfNewVertices)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumberOfNewVertices);
            CallRaw("ReserveNewVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801A01C — hookable via Hooks.InstallAt(NativeFunc_ReserveNewVertexInstances).</summary>
        public static global::System.IntPtr NativeFunc_ReserveNewVertexInstances => Memory.ModuleBase() + 0x801A01C;
        public void ReserveNewVertexInstances(int NumberOfNewVertexInstances)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumberOfNewVertexInstances);
            CallRaw("ReserveNewVertexInstances", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801972C — hookable via Hooks.InstallAt(NativeFunc_ReserveNewTriangles).</summary>
        public static global::System.IntPtr NativeFunc_ReserveNewTriangles => Memory.ModuleBase() + 0x801972C;
        public void ReserveNewTriangles(int NumberOfNewTriangles)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumberOfNewTriangles);
            CallRaw("ReserveNewTriangles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x80190BC — hookable via Hooks.InstallAt(NativeFunc_ReserveNewPolygons).</summary>
        public static global::System.IntPtr NativeFunc_ReserveNewPolygons => Memory.ModuleBase() + 0x80190BC;
        public void ReserveNewPolygons(int NumberOfNewPolygons)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumberOfNewPolygons);
            CallRaw("ReserveNewPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8018A4C — hookable via Hooks.InstallAt(NativeFunc_ReserveNewPolygonGroups).</summary>
        public static global::System.IntPtr NativeFunc_ReserveNewPolygonGroups => Memory.ModuleBase() + 0x8018A4C;
        public void ReserveNewPolygonGroups(int NumberOfNewPolygonGroups)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumberOfNewPolygonGroups);
            CallRaw("ReserveNewPolygonGroups", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8019BF4 — hookable via Hooks.InstallAt(NativeFunc_ReserveNewEdges).</summary>
        public static global::System.IntPtr NativeFunc_ReserveNewEdges => Memory.ModuleBase() + 0x8019BF4;
        public void ReserveNewEdges(int NumberOfNewEdges)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, NumberOfNewEdges);
            CallRaw("ReserveNewEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801A0C0 — hookable via Hooks.InstallAt(NativeFunc_IsVertexValid).</summary>
        public static global::System.IntPtr NativeFunc_IsVertexValid => Memory.ModuleBase() + 0x801A0C0;
        public bool IsVertexValid(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("IsVertexValid", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x8018740 — hookable via Hooks.InstallAt(NativeFunc_IsVertexOrphaned).</summary>
        public static global::System.IntPtr NativeFunc_IsVertexOrphaned => Memory.ModuleBase() + 0x8018740;
        public bool IsVertexOrphaned(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("IsVertexOrphaned", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x8019C98 — hookable via Hooks.InstallAt(NativeFunc_IsVertexInstanceValid).</summary>
        public static global::System.IntPtr NativeFunc_IsVertexInstanceValid => Memory.ModuleBase() + 0x8019C98;
        public bool IsVertexInstanceValid(global::System.IntPtr VertexInstanceID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            CallRaw("IsVertexInstanceValid", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x8019160 — hookable via Hooks.InstallAt(NativeFunc_IsTriangleValid).</summary>
        public static global::System.IntPtr NativeFunc_IsTriangleValid => Memory.ModuleBase() + 0x8019160;
        public bool IsTriangleValid(global::System.IntPtr TriangleID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            CallRaw("IsTriangleValid", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x8016D3C — hookable via Hooks.InstallAt(NativeFunc_IsTrianglePartOfNgon).</summary>
        public static global::System.IntPtr NativeFunc_IsTrianglePartOfNgon => Memory.ModuleBase() + 0x8016D3C;
        public bool IsTrianglePartOfNgon(global::System.IntPtr TriangleID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            CallRaw("IsTrianglePartOfNgon", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x8018AF0 — hookable via Hooks.InstallAt(NativeFunc_IsPolygonValid).</summary>
        public static global::System.IntPtr NativeFunc_IsPolygonValid => Memory.ModuleBase() + 0x8018AF0;
        public bool IsPolygonValid(global::System.IntPtr PolygonID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            CallRaw("IsPolygonValid", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x80187FC — hookable via Hooks.InstallAt(NativeFunc_IsPolygonGroupValid).</summary>
        public static global::System.IntPtr NativeFunc_IsPolygonGroupValid => Memory.ModuleBase() + 0x80187FC;
        public bool IsPolygonGroupValid(global::System.IntPtr PolygonGroupID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<global::System.IntPtr>(0x0, PolygonGroupID);
            CallRaw("IsPolygonGroupValid", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x801A3B4 — hookable via Hooks.InstallAt(NativeFunc_IsEmpty).</summary>
        public static global::System.IntPtr NativeFunc_IsEmpty => Memory.ModuleBase() + 0x801A3B4;
        public bool IsEmpty()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsEmpty", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x80197D0 — hookable via Hooks.InstallAt(NativeFunc_IsEdgeValid).</summary>
        public static global::System.IntPtr NativeFunc_IsEdgeValid => Memory.ModuleBase() + 0x80197D0;
        public bool IsEdgeValid(global::System.IntPtr EdgeID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            CallRaw("IsEdgeValid", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x801750C — hookable via Hooks.InstallAt(NativeFunc_IsEdgeInternalToPolygon).</summary>
        public static global::System.IntPtr NativeFunc_IsEdgeInternalToPolygon => Memory.ModuleBase() + 0x801750C;
        public bool IsEdgeInternalToPolygon(global::System.IntPtr EdgeID, global::System.IntPtr PolygonID)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            __pb.Set<global::System.IntPtr>(0x4, PolygonID);
            CallRaw("IsEdgeInternalToPolygon", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x801761C — hookable via Hooks.InstallAt(NativeFunc_IsEdgeInternal).</summary>
        public static global::System.IntPtr NativeFunc_IsEdgeInternal => Memory.ModuleBase() + 0x801761C;
        public bool IsEdgeInternal(global::System.IntPtr EdgeID)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            CallRaw("IsEdgeInternal", __pb.Bytes);
            return __pb.Get<byte>(0x4) != 0;
        }
        /// <summary>[Native] thunk RVA 0x8018354 — hookable via Hooks.InstallAt(NativeFunc_GetVertexVertexInstances).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexVertexInstances => Memory.ModuleBase() + 0x8018354;
        public void GetVertexVertexInstances(global::System.IntPtr VertexID, global::System.IntPtr OutVertexInstanceIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            __pb.Set<global::System.IntPtr>(0x8, OutVertexInstanceIDs);
            CallRaw("GetVertexVertexInstances", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8017D34 — hookable via Hooks.InstallAt(NativeFunc_GetVertexPosition).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexPosition => Memory.ModuleBase() + 0x8017D34;
        public global::System.IntPtr GetVertexPosition(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("GetVertexPosition", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8018634 — hookable via Hooks.InstallAt(NativeFunc_GetVertexPairEdge).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexPairEdge => Memory.ModuleBase() + 0x8018634;
        public global::System.IntPtr GetVertexPairEdge(global::System.IntPtr VertexID0, global::System.IntPtr VertexID1)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, VertexID0);
            __pb.Set<global::System.IntPtr>(0x4, VertexID1);
            CallRaw("GetVertexPairEdge", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x8017B7C — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceVertex).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexInstanceVertex => Memory.ModuleBase() + 0x8017B7C;
        public global::System.IntPtr GetVertexInstanceVertex(global::System.IntPtr VertexInstanceID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            CallRaw("GetVertexInstanceVertex", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8017A70 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstancePairEdge).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexInstancePairEdge => Memory.ModuleBase() + 0x8017A70;
        public global::System.IntPtr GetVertexInstancePairEdge(global::System.IntPtr VertexInstanceID0, global::System.IntPtr VertexInstanceID1)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID0);
            __pb.Set<global::System.IntPtr>(0x4, VertexInstanceID1);
            CallRaw("GetVertexInstancePairEdge", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x80166E8 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceForTriangleVertex).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexInstanceForTriangleVertex => Memory.ModuleBase() + 0x80166E8;
        public global::System.IntPtr GetVertexInstanceForTriangleVertex(global::System.IntPtr TriangleID, global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            __pb.Set<global::System.IntPtr>(0x4, VertexID);
            CallRaw("GetVertexInstanceForTriangleVertex", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x8015C84 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceForPolygonVertex).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexInstanceForPolygonVertex => Memory.ModuleBase() + 0x8015C84;
        public global::System.IntPtr GetVertexInstanceForPolygonVertex(global::System.IntPtr PolygonID, global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x4, VertexID);
            CallRaw("GetVertexInstanceForPolygonVertex", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x801795C — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceConnectedTriangles).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexInstanceConnectedTriangles => Memory.ModuleBase() + 0x801795C;
        public void GetVertexInstanceConnectedTriangles(global::System.IntPtr VertexInstanceID, global::System.IntPtr OutConnectedTriangleIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            __pb.Set<global::System.IntPtr>(0x8, OutConnectedTriangleIDs);
            CallRaw("GetVertexInstanceConnectedTriangles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8017790 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceConnectedPolygons).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexInstanceConnectedPolygons => Memory.ModuleBase() + 0x8017790;
        public void GetVertexInstanceConnectedPolygons(global::System.IntPtr VertexInstanceID, global::System.IntPtr OutConnectedPolygonIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            __pb.Set<global::System.IntPtr>(0x8, OutConnectedPolygonIDs);
            CallRaw("GetVertexInstanceConnectedPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8018188 — hookable via Hooks.InstallAt(NativeFunc_GetVertexConnectedTriangles).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexConnectedTriangles => Memory.ModuleBase() + 0x8018188;
        public void GetVertexConnectedTriangles(global::System.IntPtr VertexID, global::System.IntPtr OutConnectedTriangleIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            __pb.Set<global::System.IntPtr>(0x8, OutConnectedTriangleIDs);
            CallRaw("GetVertexConnectedTriangles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8017FBC — hookable via Hooks.InstallAt(NativeFunc_GetVertexConnectedPolygons).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexConnectedPolygons => Memory.ModuleBase() + 0x8017FBC;
        public void GetVertexConnectedPolygons(global::System.IntPtr VertexID, global::System.IntPtr OutConnectedPolygonIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            __pb.Set<global::System.IntPtr>(0x8, OutConnectedPolygonIDs);
            CallRaw("GetVertexConnectedPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8018520 — hookable via Hooks.InstallAt(NativeFunc_GetVertexConnectedEdges).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexConnectedEdges => Memory.ModuleBase() + 0x8018520;
        public void GetVertexConnectedEdges(global::System.IntPtr VertexID, global::System.IntPtr OutEdgeIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            __pb.Set<global::System.IntPtr>(0x8, OutEdgeIDs);
            CallRaw("GetVertexConnectedEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8017DF0 — hookable via Hooks.InstallAt(NativeFunc_GetVertexAdjacentVertices).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexAdjacentVertices => Memory.ModuleBase() + 0x8017DF0;
        public void GetVertexAdjacentVertices(global::System.IntPtr VertexID, global::System.IntPtr OutAdjacentVertexIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            __pb.Set<global::System.IntPtr>(0x8, OutAdjacentVertexIDs);
            CallRaw("GetVertexAdjacentVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8016A1C — hookable via Hooks.InstallAt(NativeFunc_GetTriangleVertices).</summary>
        public static global::System.IntPtr NativeFunc_GetTriangleVertices => Memory.ModuleBase() + 0x8016A1C;
        public void GetTriangleVertices(global::System.IntPtr TriangleID, global::System.IntPtr OutVertexIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            __pb.Set<global::System.IntPtr>(0x8, OutVertexIDs);
            CallRaw("GetTriangleVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8016C28 — hookable via Hooks.InstallAt(NativeFunc_GetTriangleVertexInstances).</summary>
        public static global::System.IntPtr NativeFunc_GetTriangleVertexInstances => Memory.ModuleBase() + 0x8016C28;
        public void GetTriangleVertexInstances(global::System.IntPtr TriangleID, global::System.IntPtr OutVertexInstanceIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            __pb.Set<global::System.IntPtr>(0x8, OutVertexInstanceIDs);
            CallRaw("GetTriangleVertexInstances", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8016B30 — hookable via Hooks.InstallAt(NativeFunc_GetTriangleVertexInstance).</summary>
        public static global::System.IntPtr NativeFunc_GetTriangleVertexInstance => Memory.ModuleBase() + 0x8016B30;
        public global::System.IntPtr GetTriangleVertexInstance(global::System.IntPtr TriangleID, int Index)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            __pb.Set(0x4, Index);
            CallRaw("GetTriangleVertexInstance", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x8016DF8 — hookable via Hooks.InstallAt(NativeFunc_GetTrianglePolygonGroup).</summary>
        public static global::System.IntPtr NativeFunc_GetTrianglePolygonGroup => Memory.ModuleBase() + 0x8016DF8;
        public global::System.IntPtr GetTrianglePolygonGroup(global::System.IntPtr TriangleID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            CallRaw("GetTrianglePolygonGroup", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8016EB0 — hookable via Hooks.InstallAt(NativeFunc_GetTrianglePolygon).</summary>
        public static global::System.IntPtr NativeFunc_GetTrianglePolygon => Memory.ModuleBase() + 0x8016EB0;
        public global::System.IntPtr GetTrianglePolygon(global::System.IntPtr TriangleID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            CallRaw("GetTrianglePolygon", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8016908 — hookable via Hooks.InstallAt(NativeFunc_GetTriangleEdges).</summary>
        public static global::System.IntPtr NativeFunc_GetTriangleEdges => Memory.ModuleBase() + 0x8016908;
        public void GetTriangleEdges(global::System.IntPtr TriangleID, global::System.IntPtr OutEdgeIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            __pb.Set<global::System.IntPtr>(0x8, OutEdgeIDs);
            CallRaw("GetTriangleEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x80167F4 — hookable via Hooks.InstallAt(NativeFunc_GetTriangleAdjacentTriangles).</summary>
        public static global::System.IntPtr NativeFunc_GetTriangleAdjacentTriangles => Memory.ModuleBase() + 0x80167F4;
        public void GetTriangleAdjacentTriangles(global::System.IntPtr TriangleID, global::System.IntPtr OutTriangleIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            __pb.Set<global::System.IntPtr>(0x8, OutTriangleIDs);
            CallRaw("GetTriangleAdjacentTriangles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801623C — hookable via Hooks.InstallAt(NativeFunc_GetPolygonVertices).</summary>
        public static global::System.IntPtr NativeFunc_GetPolygonVertices => Memory.ModuleBase() + 0x801623C;
        public void GetPolygonVertices(global::System.IntPtr PolygonID, global::System.IntPtr OutVertexIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x8, OutVertexIDs);
            CallRaw("GetPolygonVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8016408 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonVertexInstances).</summary>
        public static global::System.IntPtr NativeFunc_GetPolygonVertexInstances => Memory.ModuleBase() + 0x8016408;
        public void GetPolygonVertexInstances(global::System.IntPtr PolygonID, global::System.IntPtr OutVertexInstanceIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x8, OutVertexInstanceIDs);
            CallRaw("GetPolygonVertexInstances", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x80165D4 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonTriangles).</summary>
        public static global::System.IntPtr NativeFunc_GetPolygonTriangles => Memory.ModuleBase() + 0x80165D4;
        public void GetPolygonTriangles(global::System.IntPtr PolygonID, global::System.IntPtr OutTriangleIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x8, OutTriangleIDs);
            CallRaw("GetPolygonTriangles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8015D90 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPolygonGroup).</summary>
        public static global::System.IntPtr NativeFunc_GetPolygonPolygonGroup => Memory.ModuleBase() + 0x8015D90;
        public global::System.IntPtr GetPolygonPolygonGroup(global::System.IntPtr PolygonID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            CallRaw("GetPolygonPolygonGroup", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8016128 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonPerimeterEdges).</summary>
        public static global::System.IntPtr NativeFunc_GetPolygonPerimeterEdges => Memory.ModuleBase() + 0x8016128;
        public void GetPolygonPerimeterEdges(global::System.IntPtr PolygonID, global::System.IntPtr OutEdgeIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x8, OutEdgeIDs);
            CallRaw("GetPolygonPerimeterEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8016014 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonInternalEdges).</summary>
        public static global::System.IntPtr NativeFunc_GetPolygonInternalEdges => Memory.ModuleBase() + 0x8016014;
        public void GetPolygonInternalEdges(global::System.IntPtr PolygonID, global::System.IntPtr OutEdgeIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x8, OutEdgeIDs);
            CallRaw("GetPolygonInternalEdges", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x80157D8 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonGroupPolygons).</summary>
        public static global::System.IntPtr NativeFunc_GetPolygonGroupPolygons => Memory.ModuleBase() + 0x80157D8;
        public void GetPolygonGroupPolygons(global::System.IntPtr PolygonGroupID, global::System.IntPtr OutPolygonIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, PolygonGroupID);
            __pb.Set<global::System.IntPtr>(0x8, OutPolygonIDs);
            CallRaw("GetPolygonGroupPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8015E48 — hookable via Hooks.InstallAt(NativeFunc_GetPolygonAdjacentPolygons).</summary>
        public static global::System.IntPtr NativeFunc_GetPolygonAdjacentPolygons => Memory.ModuleBase() + 0x8015E48;
        public void GetPolygonAdjacentPolygons(global::System.IntPtr PolygonID, global::System.IntPtr OutPolygonIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x8, OutPolygonIDs);
            CallRaw("GetPolygonAdjacentPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801829C — hookable via Hooks.InstallAt(NativeFunc_GetNumVertexVertexInstances).</summary>
        public static global::System.IntPtr NativeFunc_GetNumVertexVertexInstances => Memory.ModuleBase() + 0x801829C;
        public int GetNumVertexVertexInstances(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("GetNumVertexVertexInstances", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x80178A4 — hookable via Hooks.InstallAt(NativeFunc_GetNumVertexInstanceConnectedTriangles).</summary>
        public static global::System.IntPtr NativeFunc_GetNumVertexInstanceConnectedTriangles => Memory.ModuleBase() + 0x80178A4;
        public int GetNumVertexInstanceConnectedTriangles(global::System.IntPtr VertexInstanceID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            CallRaw("GetNumVertexInstanceConnectedTriangles", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x80176D8 — hookable via Hooks.InstallAt(NativeFunc_GetNumVertexInstanceConnectedPolygons).</summary>
        public static global::System.IntPtr NativeFunc_GetNumVertexInstanceConnectedPolygons => Memory.ModuleBase() + 0x80176D8;
        public int GetNumVertexInstanceConnectedPolygons(global::System.IntPtr VertexInstanceID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            CallRaw("GetNumVertexInstanceConnectedPolygons", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x80180D0 — hookable via Hooks.InstallAt(NativeFunc_GetNumVertexConnectedTriangles).</summary>
        public static global::System.IntPtr NativeFunc_GetNumVertexConnectedTriangles => Memory.ModuleBase() + 0x80180D0;
        public int GetNumVertexConnectedTriangles(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("GetNumVertexConnectedTriangles", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8017F04 — hookable via Hooks.InstallAt(NativeFunc_GetNumVertexConnectedPolygons).</summary>
        public static global::System.IntPtr NativeFunc_GetNumVertexConnectedPolygons => Memory.ModuleBase() + 0x8017F04;
        public int GetNumVertexConnectedPolygons(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("GetNumVertexConnectedPolygons", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8018468 — hookable via Hooks.InstallAt(NativeFunc_GetNumVertexConnectedEdges).</summary>
        public static global::System.IntPtr NativeFunc_GetNumVertexConnectedEdges => Memory.ModuleBase() + 0x8018468;
        public int GetNumVertexConnectedEdges(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("GetNumVertexConnectedEdges", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8016350 — hookable via Hooks.InstallAt(NativeFunc_GetNumPolygonVertices).</summary>
        public static global::System.IntPtr NativeFunc_GetNumPolygonVertices => Memory.ModuleBase() + 0x8016350;
        public int GetNumPolygonVertices(global::System.IntPtr PolygonID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            CallRaw("GetNumPolygonVertices", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x801651C — hookable via Hooks.InstallAt(NativeFunc_GetNumPolygonTriangles).</summary>
        public static global::System.IntPtr NativeFunc_GetNumPolygonTriangles => Memory.ModuleBase() + 0x801651C;
        public int GetNumPolygonTriangles(global::System.IntPtr PolygonID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            CallRaw("GetNumPolygonTriangles", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8015F5C — hookable via Hooks.InstallAt(NativeFunc_GetNumPolygonInternalEdges).</summary>
        public static global::System.IntPtr NativeFunc_GetNumPolygonInternalEdges => Memory.ModuleBase() + 0x8015F5C;
        public int GetNumPolygonInternalEdges(global::System.IntPtr PolygonID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            CallRaw("GetNumPolygonInternalEdges", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8015720 — hookable via Hooks.InstallAt(NativeFunc_GetNumPolygonGroupPolygons).</summary>
        public static global::System.IntPtr NativeFunc_GetNumPolygonGroupPolygons => Memory.ModuleBase() + 0x8015720;
        public int GetNumPolygonGroupPolygons(global::System.IntPtr PolygonGroupID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, PolygonGroupID);
            CallRaw("GetNumPolygonGroupPolygons", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8017340 — hookable via Hooks.InstallAt(NativeFunc_GetNumEdgeConnectedTriangles).</summary>
        public static global::System.IntPtr NativeFunc_GetNumEdgeConnectedTriangles => Memory.ModuleBase() + 0x8017340;
        public int GetNumEdgeConnectedTriangles(global::System.IntPtr EdgeID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            CallRaw("GetNumEdgeConnectedTriangles", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8017174 — hookable via Hooks.InstallAt(NativeFunc_GetNumEdgeConnectedPolygons).</summary>
        public static global::System.IntPtr NativeFunc_GetNumEdgeConnectedPolygons => Memory.ModuleBase() + 0x8017174;
        public int GetNumEdgeConnectedPolygons(global::System.IntPtr EdgeID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            CallRaw("GetNumEdgeConnectedPolygons", __pb.Bytes);
            return __pb.Get<int>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x8016F68 — hookable via Hooks.InstallAt(NativeFunc_GetEdgeVertices).</summary>
        public static global::System.IntPtr NativeFunc_GetEdgeVertices => Memory.ModuleBase() + 0x8016F68;
        public void GetEdgeVertices(global::System.IntPtr EdgeID, global::System.IntPtr OutVertexIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            __pb.Set<global::System.IntPtr>(0x8, OutVertexIDs);
            CallRaw("GetEdgeVertices", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801707C — hookable via Hooks.InstallAt(NativeFunc_GetEdgeVertex).</summary>
        public static global::System.IntPtr NativeFunc_GetEdgeVertex => Memory.ModuleBase() + 0x801707C;
        public global::System.IntPtr GetEdgeVertex(global::System.IntPtr EdgeID, int VertexNumber)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            __pb.Set(0x4, VertexNumber);
            CallRaw("GetEdgeVertex", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x80173F8 — hookable via Hooks.InstallAt(NativeFunc_GetEdgeConnectedTriangles).</summary>
        public static global::System.IntPtr NativeFunc_GetEdgeConnectedTriangles => Memory.ModuleBase() + 0x80173F8;
        public void GetEdgeConnectedTriangles(global::System.IntPtr EdgeID, global::System.IntPtr OutConnectedTriangleIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            __pb.Set<global::System.IntPtr>(0x8, OutConnectedTriangleIDs);
            CallRaw("GetEdgeConnectedTriangles", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801722C — hookable via Hooks.InstallAt(NativeFunc_GetEdgeConnectedPolygons).</summary>
        public static global::System.IntPtr NativeFunc_GetEdgeConnectedPolygons => Memory.ModuleBase() + 0x801722C;
        public void GetEdgeConnectedPolygons(global::System.IntPtr EdgeID, global::System.IntPtr OutConnectedPolygonIDs)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            __pb.Set<global::System.IntPtr>(0x8, OutConnectedPolygonIDs);
            CallRaw("GetEdgeConnectedPolygons", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801A3EC — hookable via Hooks.InstallAt(NativeFunc_Empty).</summary>
        public static global::System.IntPtr NativeFunc_Empty => Memory.ModuleBase() + 0x801A3EC;
        public void Empty()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Empty", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8019D54 — hookable via Hooks.InstallAt(NativeFunc_DeleteVertexInstance).</summary>
        public static global::System.IntPtr NativeFunc_DeleteVertexInstance => Memory.ModuleBase() + 0x8019D54;
        public void DeleteVertexInstance(global::System.IntPtr VertexInstanceID, global::System.IntPtr OrphanedVertices)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            __pb.Set<global::System.IntPtr>(0x8, OrphanedVertices);
            CallRaw("DeleteVertexInstance", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801A17C — hookable via Hooks.InstallAt(NativeFunc_DeleteVertex).</summary>
        public static global::System.IntPtr NativeFunc_DeleteVertex => Memory.ModuleBase() + 0x801A17C;
        public void DeleteVertex(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("DeleteVertex", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801921C — hookable via Hooks.InstallAt(NativeFunc_DeleteTriangle).</summary>
        public static global::System.IntPtr NativeFunc_DeleteTriangle => Memory.ModuleBase() + 0x801921C;
        public void DeleteTriangle(global::System.IntPtr TriangleID, global::System.IntPtr OrphanedEdges, global::System.IntPtr OrphanedVertexInstances, global::System.IntPtr OrphanedPolygonGroupsPtr)
        {
            var __pb = new ParamBuffer(56);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            __pb.Set<global::System.IntPtr>(0x8, OrphanedEdges);
            __pb.Set<global::System.IntPtr>(0x18, OrphanedVertexInstances);
            __pb.Set<global::System.IntPtr>(0x28, OrphanedPolygonGroupsPtr);
            CallRaw("DeleteTriangle", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x80188B8 — hookable via Hooks.InstallAt(NativeFunc_DeletePolygonGroup).</summary>
        public static global::System.IntPtr NativeFunc_DeletePolygonGroup => Memory.ModuleBase() + 0x80188B8;
        public void DeletePolygonGroup(global::System.IntPtr PolygonGroupID)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<global::System.IntPtr>(0x0, PolygonGroupID);
            CallRaw("DeletePolygonGroup", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8018BAC — hookable via Hooks.InstallAt(NativeFunc_DeletePolygon).</summary>
        public static global::System.IntPtr NativeFunc_DeletePolygon => Memory.ModuleBase() + 0x8018BAC;
        public void DeletePolygon(global::System.IntPtr PolygonID, global::System.IntPtr OrphanedEdges, global::System.IntPtr OrphanedVertexInstances, global::System.IntPtr OrphanedPolygonGroups)
        {
            var __pb = new ParamBuffer(56);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x8, OrphanedEdges);
            __pb.Set<global::System.IntPtr>(0x18, OrphanedVertexInstances);
            __pb.Set<global::System.IntPtr>(0x28, OrphanedPolygonGroups);
            CallRaw("DeletePolygon", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801988C — hookable via Hooks.InstallAt(NativeFunc_DeleteEdge).</summary>
        public static global::System.IntPtr NativeFunc_DeleteEdge => Memory.ModuleBase() + 0x801988C;
        public void DeleteEdge(global::System.IntPtr EdgeID, global::System.IntPtr OrphanedVertices)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            __pb.Set<global::System.IntPtr>(0x8, OrphanedVertices);
            CallRaw("DeleteEdge", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x801A22C — hookable via Hooks.InstallAt(NativeFunc_CreateVertexWithID).</summary>
        public static global::System.IntPtr NativeFunc_CreateVertexWithID => Memory.ModuleBase() + 0x801A22C;
        public void CreateVertexWithID(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("CreateVertexWithID", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8019E68 — hookable via Hooks.InstallAt(NativeFunc_CreateVertexInstanceWithID).</summary>
        public static global::System.IntPtr NativeFunc_CreateVertexInstanceWithID => Memory.ModuleBase() + 0x8019E68;
        public void CreateVertexInstanceWithID(global::System.IntPtr VertexInstanceID, global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            __pb.Set<global::System.IntPtr>(0x4, VertexID);
            CallRaw("CreateVertexInstanceWithID", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8019F64 — hookable via Hooks.InstallAt(NativeFunc_CreateVertexInstance).</summary>
        public static global::System.IntPtr NativeFunc_CreateVertexInstance => Memory.ModuleBase() + 0x8019F64;
        public global::System.IntPtr CreateVertexInstance(global::System.IntPtr VertexID)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, VertexID);
            CallRaw("CreateVertexInstance", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x4);
        }
        /// <summary>[Native] thunk RVA 0x801A2DC — hookable via Hooks.InstallAt(NativeFunc_CreateVertex).</summary>
        public static global::System.IntPtr NativeFunc_CreateVertex => Memory.ModuleBase() + 0x801A2DC;
        public global::System.IntPtr CreateVertex()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("CreateVertex", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x80193F0 — hookable via Hooks.InstallAt(NativeFunc_CreateTriangleWithID).</summary>
        public static global::System.IntPtr NativeFunc_CreateTriangleWithID => Memory.ModuleBase() + 0x80193F0;
        public void CreateTriangleWithID(global::System.IntPtr TriangleID, global::System.IntPtr PolygonGroupID, global::System.IntPtr VertexInstanceIDs, global::System.IntPtr NewEdgeIDs)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<global::System.IntPtr>(0x0, TriangleID);
            __pb.Set<global::System.IntPtr>(0x4, PolygonGroupID);
            __pb.Set<global::System.IntPtr>(0x8, VertexInstanceIDs);
            __pb.Set<global::System.IntPtr>(0x18, NewEdgeIDs);
            CallRaw("CreateTriangleWithID", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x80195AC — hookable via Hooks.InstallAt(NativeFunc_CreateTriangle).</summary>
        public static global::System.IntPtr NativeFunc_CreateTriangle => Memory.ModuleBase() + 0x80195AC;
        public global::System.IntPtr CreateTriangle(global::System.IntPtr PolygonGroupID, global::System.IntPtr VertexInstanceIDs, global::System.IntPtr NewEdgeIDs)
        {
            var __pb = new ParamBuffer(44);
            __pb.Set<global::System.IntPtr>(0x0, PolygonGroupID);
            __pb.Set<global::System.IntPtr>(0x8, VertexInstanceIDs);
            __pb.Set<global::System.IntPtr>(0x18, NewEdgeIDs);
            CallRaw("CreateTriangle", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x28);
        }
        /// <summary>[Native] thunk RVA 0x8018D80 — hookable via Hooks.InstallAt(NativeFunc_CreatePolygonWithID).</summary>
        public static global::System.IntPtr NativeFunc_CreatePolygonWithID => Memory.ModuleBase() + 0x8018D80;
        public void CreatePolygonWithID(global::System.IntPtr PolygonID, global::System.IntPtr PolygonGroupID, global::System.IntPtr VertexInstanceIDs, global::System.IntPtr NewEdgeIDs)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            __pb.Set<global::System.IntPtr>(0x4, PolygonGroupID);
            __pb.Set<global::System.IntPtr>(0x8, VertexInstanceIDs);
            __pb.Set<global::System.IntPtr>(0x18, NewEdgeIDs);
            CallRaw("CreatePolygonWithID", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8018968 — hookable via Hooks.InstallAt(NativeFunc_CreatePolygonGroupWithID).</summary>
        public static global::System.IntPtr NativeFunc_CreatePolygonGroupWithID => Memory.ModuleBase() + 0x8018968;
        public void CreatePolygonGroupWithID(global::System.IntPtr PolygonGroupID)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<global::System.IntPtr>(0x0, PolygonGroupID);
            CallRaw("CreatePolygonGroupWithID", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8018A18 — hookable via Hooks.InstallAt(NativeFunc_CreatePolygonGroup).</summary>
        public static global::System.IntPtr NativeFunc_CreatePolygonGroup => Memory.ModuleBase() + 0x8018A18;
        public global::System.IntPtr CreatePolygonGroup()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("CreatePolygonGroup", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x8018F3C — hookable via Hooks.InstallAt(NativeFunc_CreatePolygon).</summary>
        public static global::System.IntPtr NativeFunc_CreatePolygon => Memory.ModuleBase() + 0x8018F3C;
        public global::System.IntPtr CreatePolygon(global::System.IntPtr PolygonGroupID, global::System.IntPtr VertexInstanceIDs, global::System.IntPtr NewEdgeIDs)
        {
            var __pb = new ParamBuffer(44);
            __pb.Set<global::System.IntPtr>(0x0, PolygonGroupID);
            __pb.Set<global::System.IntPtr>(0x8, VertexInstanceIDs);
            __pb.Set<global::System.IntPtr>(0x18, NewEdgeIDs);
            CallRaw("CreatePolygon", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x28);
        }
        /// <summary>[Native] thunk RVA 0x80199A0 — hookable via Hooks.InstallAt(NativeFunc_CreateEdgeWithID).</summary>
        public static global::System.IntPtr NativeFunc_CreateEdgeWithID => Memory.ModuleBase() + 0x80199A0;
        public void CreateEdgeWithID(global::System.IntPtr EdgeID, global::System.IntPtr VertexID0, global::System.IntPtr VertexID1)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, EdgeID);
            __pb.Set<global::System.IntPtr>(0x4, VertexID0);
            __pb.Set<global::System.IntPtr>(0x8, VertexID1);
            CallRaw("CreateEdgeWithID", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8019AE8 — hookable via Hooks.InstallAt(NativeFunc_CreateEdge).</summary>
        public static global::System.IntPtr NativeFunc_CreateEdge => Memory.ModuleBase() + 0x8019AE8;
        public global::System.IntPtr CreateEdge(global::System.IntPtr VertexID0, global::System.IntPtr VertexID1)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, VertexID0);
            __pb.Set<global::System.IntPtr>(0x4, VertexID1);
            CallRaw("CreateEdge", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x80158EC — hookable via Hooks.InstallAt(NativeFunc_ComputePolygonTriangulation).</summary>
        public static global::System.IntPtr NativeFunc_ComputePolygonTriangulation => Memory.ModuleBase() + 0x80158EC;
        public void ComputePolygonTriangulation(global::System.IntPtr PolygonID)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set<global::System.IntPtr>(0x0, PolygonID);
            CallRaw("ComputePolygonTriangulation", __pb.Bytes);
        }
    }

}
