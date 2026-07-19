// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/StaticMeshDescription
using System;

namespace UEModLoader.Game
{
    public class UVMapSettings : StructProxy
    {
        public UVMapSettings(global::System.IntPtr ptr) : base(ptr) {}
        public Vector Size => new Vector(AddrOf(0x0));
        public Vector2D UVTile => new Vector2D(AddrOf(0xC));
        public Vector Position => new Vector(AddrOf(0x14));
        public Rotator Rotation => new Rotator(AddrOf(0x20));
        public Vector Scale => new Vector(AddrOf(0x2C));
    }

    public class StaticMeshDescription : MeshDescriptionBase
    {
        public const string UeClassName = "StaticMeshDescription";
        public StaticMeshDescription(global::System.IntPtr ptr) : base(ptr) {}
        public static new StaticMeshDescription FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new StaticMeshDescription(p);
        public static StaticMeshDescription FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new StaticMeshDescription(o.Pointer); }
        public static StaticMeshDescription[] All() { var a = UObject.FindAllOf(UeClassName); var r = new StaticMeshDescription[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new StaticMeshDescription(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x80464F0 — hookable via Hooks.InstallAt(NativeFunc_SetVertexInstanceUV).</summary>
        public static global::System.IntPtr NativeFunc_SetVertexInstanceUV => Memory.ModuleBase() + 0x80464F0;
        public void SetVertexInstanceUV(global::System.IntPtr VertexInstanceID, global::System.IntPtr UV, int UVIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            __pb.Set<global::System.IntPtr>(0x4, UV);
            __pb.Set(0xC, UVIndex);
            CallRaw("SetVertexInstanceUV", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x80460B8 — hookable via Hooks.InstallAt(NativeFunc_SetPolygonGroupMaterialSlotName).</summary>
        public static global::System.IntPtr NativeFunc_SetPolygonGroupMaterialSlotName => Memory.ModuleBase() + 0x80460B8;
        public void SetPolygonGroupMaterialSlotName(global::System.IntPtr PolygonGroupID, FName SlotName)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set<global::System.IntPtr>(0x0, PolygonGroupID);
            __pb.Set(0x4, SlotName);
            CallRaw("SetPolygonGroupMaterialSlotName", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x8046620 — hookable via Hooks.InstallAt(NativeFunc_GetVertexInstanceUV).</summary>
        public static global::System.IntPtr NativeFunc_GetVertexInstanceUV => Memory.ModuleBase() + 0x8046620;
        public global::System.IntPtr GetVertexInstanceUV(global::System.IntPtr VertexInstanceID, int UVIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, VertexInstanceID);
            __pb.Set(0x4, UVIndex);
            CallRaw("GetVertexInstanceUV", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x80461C0 — hookable via Hooks.InstallAt(NativeFunc_CreateCube).</summary>
        public static global::System.IntPtr NativeFunc_CreateCube => Memory.ModuleBase() + 0x80461C0;
        public void CreateCube(global::System.IntPtr Center, global::System.IntPtr HalfExtents, global::System.IntPtr PolygonGroup, global::System.IntPtr PolygonID_PlusX, global::System.IntPtr PolygonID_MinusX, global::System.IntPtr PolygonID_PlusY, global::System.IntPtr PolygonID_MinusY, global::System.IntPtr PolygonID_PlusZ, global::System.IntPtr PolygonID_MinusZ)
        {
            var __pb = new ParamBuffer(52);
            __pb.Set<global::System.IntPtr>(0x0, Center);
            __pb.Set<global::System.IntPtr>(0xC, HalfExtents);
            __pb.Set<global::System.IntPtr>(0x18, PolygonGroup);
            __pb.Set<global::System.IntPtr>(0x1C, PolygonID_PlusX);
            __pb.Set<global::System.IntPtr>(0x20, PolygonID_MinusX);
            __pb.Set<global::System.IntPtr>(0x24, PolygonID_PlusY);
            __pb.Set<global::System.IntPtr>(0x28, PolygonID_MinusY);
            __pb.Set<global::System.IntPtr>(0x2C, PolygonID_PlusZ);
            __pb.Set<global::System.IntPtr>(0x30, PolygonID_MinusZ);
            CallRaw("CreateCube", __pb.Bytes);
        }
    }

}
