// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/NavigationSystem
using System;

namespace UEModLoader.Game
{
    public enum ERuntimeGenerationType
    {
        Static = 0,
        DynamicModifiersOnly = 1,
        Dynamic = 2,
        LegacyGeneration = 3,
    }

    public enum ENavCostDisplay
    {
        TotalCost = 0,
        HeuristicOnly = 1,
        RealCostOnly = 2,
    }

    public enum ENavSystemOverridePolicy
    {
        Override = 0,
        Append = 1,
        Skip = 2,
    }

    public enum ERecastPartitioning
    {
        Monotone = 0,
        Watershed = 1,
        ChunkyMonotone = 2,
    }

    public class NavCollisionBox : StructProxy
    {
        public NavCollisionBox(global::System.IntPtr ptr) : base(ptr) {}
        public Vector Offset => new Vector(AddrOf(0x0));
        public Vector Extent => new Vector(AddrOf(0xC));
    }

    public class NavCollisionCylinder : StructProxy
    {
        public NavCollisionCylinder(global::System.IntPtr ptr) : base(ptr) {}
        public Vector Offset => new Vector(AddrOf(0x0));
        public float Radius { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float Height { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
    }

    public class SupportedAreaData : StructProxy
    {
        public SupportedAreaData(global::System.IntPtr ptr) : base(ptr) {}
        public string AreaClassName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public int AreaID { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
        public Object AreaClass { get { var __p = GetAt<global::System.IntPtr>(0x18); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x18, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NavGraphNode : StructProxy
    {
        public NavGraphNode(global::System.IntPtr ptr) : base(ptr) {}
        public Object Owner { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NavGraphEdge : StructProxy
    {
        public NavGraphEdge(global::System.IntPtr ptr) : base(ptr) {}
    }

    public class NavigationFilterFlags : StructProxy
    {
        public NavigationFilterFlags(global::System.IntPtr ptr) : base(ptr) {}
        public bool bNavFlag0 { get => (GetAt<byte>(0x0) & 0x1) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bNavFlag1 { get => (GetAt<byte>(0x0) & 0x2) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bNavFlag2 { get => (GetAt<byte>(0x0) & 0x4) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bNavFlag3 { get => (GetAt<byte>(0x0) & 0x8) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bNavFlag4 { get => (GetAt<byte>(0x0) & 0x10) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bNavFlag5 { get => (GetAt<byte>(0x0) & 0x20) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool bNavFlag6 { get => (GetAt<byte>(0x0) & 0x40) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
        public bool bNavFlag7 { get => (GetAt<byte>(0x0) & 0x80) != 0; set { var __b = GetAt<byte>(0x0); SetAt(0x0, (byte)(value ? (__b | 0x80) : (__b & ~0x80))); } }
        public bool bNavFlag8 { get => (GetAt<byte>(0x1) & 0x1) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bNavFlag9 { get => (GetAt<byte>(0x1) & 0x2) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bNavFlag10 { get => (GetAt<byte>(0x1) & 0x4) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bNavFlag11 { get => (GetAt<byte>(0x1) & 0x8) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bNavFlag12 { get => (GetAt<byte>(0x1) & 0x10) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bNavFlag13 { get => (GetAt<byte>(0x1) & 0x20) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
        public bool bNavFlag14 { get => (GetAt<byte>(0x1) & 0x40) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x40) : (__b & ~0x40))); } }
        public bool bNavFlag15 { get => (GetAt<byte>(0x1) & 0x80) != 0; set { var __b = GetAt<byte>(0x1); SetAt(0x1, (byte)(value ? (__b | 0x80) : (__b & ~0x80))); } }
    }

    public class NavigationFilterArea : StructProxy
    {
        public NavigationFilterArea(global::System.IntPtr ptr) : base(ptr) {}
        public NavArea AreaClass { get { var __p = GetAt<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float TravelCostOverride { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float EnteringCostOverride { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public bool bIsExcluded { get => (GetAt<byte>(0x10) & 0x1) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bOverrideTravelCost { get => (GetAt<byte>(0x10) & 0x2) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bOverrideEnteringCost { get => (GetAt<byte>(0x10) & 0x4) != 0; set { var __b = GetAt<byte>(0x10); SetAt(0x10, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
    }

    public class NavLinkCustomInstanceData : StructProxy
    {
        public NavLinkCustomInstanceData(global::System.IntPtr ptr) : base(ptr) {}
        public uint NavLinkUserId { get => GetAt<uint>(0x58); set => SetAt(0x58, value); }
    }

    public class RecastNavMeshGenerationProperties : StructProxy
    {
        public RecastNavMeshGenerationProperties(global::System.IntPtr ptr) : base(ptr) {}
        public int TilePoolSize { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public float TileSizeUU { get => GetAt<float>(0x4); set => SetAt(0x4, value); }
        public float CellSize { get => GetAt<float>(0x8); set => SetAt(0x8, value); }
        public float CellHeight { get => GetAt<float>(0xC); set => SetAt(0xC, value); }
        public float AgentRadius { get => GetAt<float>(0x10); set => SetAt(0x10, value); }
        public float AgentHeight { get => GetAt<float>(0x14); set => SetAt(0x14, value); }
        public float AgentMaxSlope { get => GetAt<float>(0x18); set => SetAt(0x18, value); }
        public float AgentMaxStepHeight { get => GetAt<float>(0x1C); set => SetAt(0x1C, value); }
        public float MinRegionArea { get => GetAt<float>(0x20); set => SetAt(0x20, value); }
        public float MergeRegionSize { get => GetAt<float>(0x24); set => SetAt(0x24, value); }
        public float MaxSimplificationError { get => GetAt<float>(0x28); set => SetAt(0x28, value); }
        public int TileNumberHardLimit { get => GetAt<int>(0x2C); set => SetAt(0x2C, value); }
        public byte RegionPartitioning { get => GetAt<byte>(0x30); set => SetAt(0x30, value); }
        public byte LayerPartitioning { get => GetAt<byte>(0x31); set => SetAt(0x31, value); }
        public int RegionChunkSplits { get => GetAt<int>(0x34); set => SetAt(0x34, value); }
        public int LayerChunkSplits { get => GetAt<int>(0x38); set => SetAt(0x38, value); }
        public bool bSortNavigationAreasByCost { get => (GetAt<byte>(0x3C) & 0x1) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0x1) : (__b & ~0x1))); } }
        public bool bPerformVoxelFiltering { get => (GetAt<byte>(0x3C) & 0x2) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0x2) : (__b & ~0x2))); } }
        public bool bMarkLowHeightAreas { get => (GetAt<byte>(0x3C) & 0x4) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0x4) : (__b & ~0x4))); } }
        public bool bFilterLowSpanSequences { get => (GetAt<byte>(0x3C) & 0x8) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0x8) : (__b & ~0x8))); } }
        public bool bFilterLowSpanFromTileCache { get => (GetAt<byte>(0x3C) & 0x10) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0x10) : (__b & ~0x10))); } }
        public bool bFixedTilePoolSize { get => (GetAt<byte>(0x3C) & 0x20) != 0; set { var __b = GetAt<byte>(0x3C); SetAt(0x3C, (byte)(value ? (__b | 0x20) : (__b & ~0x20))); } }
    }

    public class NavigationData : Actor
    {
        public const string UeClassName = "NavigationData";
        public NavigationData(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationData FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationData(p);
        public static NavigationData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationData(o.Pointer); }
        public static NavigationData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationData(a[i].Pointer); return r; }
        public PrimitiveComponent RenderingComp { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new PrimitiveComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavDataConfig NavDataConfig => new NavDataConfig(AddrOf(0x230));
        public bool bEnableDrawing { get => Native.GetPropBool(Pointer, "bEnableDrawing"); set => Native.SetPropBool(Pointer, "bEnableDrawing", value); }
        public bool bForceRebuildOnLoad { get => Native.GetPropBool(Pointer, "bForceRebuildOnLoad"); set => Native.SetPropBool(Pointer, "bForceRebuildOnLoad", value); }
        public bool bAutoDestroyWhenNoNavigation { get => Native.GetPropBool(Pointer, "bAutoDestroyWhenNoNavigation"); set => Native.SetPropBool(Pointer, "bAutoDestroyWhenNoNavigation", value); }
        public bool bCanBeMainNavData { get => Native.GetPropBool(Pointer, "bCanBeMainNavData"); set => Native.SetPropBool(Pointer, "bCanBeMainNavData", value); }
        public bool bCanSpawnOnRebuild { get => Native.GetPropBool(Pointer, "bCanSpawnOnRebuild"); set => Native.SetPropBool(Pointer, "bCanSpawnOnRebuild", value); }
        public bool bRebuildAtRuntime { get => Native.GetPropBool(Pointer, "bRebuildAtRuntime"); set => Native.SetPropBool(Pointer, "bRebuildAtRuntime", value); }
        public ERuntimeGenerationType RuntimeGeneration { get => (ERuntimeGenerationType)GetAt<byte>(0x2A9); set => SetAt(0x2A9, (byte)value); }
        public float ObservedPathsTickInterval { get => GetAt<float>(0x2AC); set => SetAt(0x2AC, value); }
        public uint DataVersion { get => GetAt<uint>(0x2B0); set => SetAt(0x2B0, value); }
        public TArray<global::System.IntPtr> SupportedAreas => new TArray<global::System.IntPtr>(AddrOf(0x398)); // TArray<struct>
    }

    public class AbstractNavData : NavigationData
    {
        public const string UeClassName = "AbstractNavData";
        public AbstractNavData(global::System.IntPtr ptr) : base(ptr) {}
        public static new AbstractNavData FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new AbstractNavData(p);
        public static AbstractNavData FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new AbstractNavData(o.Pointer); }
        public static AbstractNavData[] All() { var a = UObject.FindAllOf(UeClassName); var r = new AbstractNavData[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new AbstractNavData(a[i].Pointer); return r; }
    }

    public class CrowdManagerBase : Object
    {
        public const string UeClassName = "CrowdManagerBase";
        public CrowdManagerBase(global::System.IntPtr ptr) : base(ptr) {}
        public static new CrowdManagerBase FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new CrowdManagerBase(p);
        public static CrowdManagerBase FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new CrowdManagerBase(o.Pointer); }
        public static CrowdManagerBase[] All() { var a = UObject.FindAllOf(UeClassName); var r = new CrowdManagerBase[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new CrowdManagerBase(a[i].Pointer); return r; }
    }

    public class NavArea : NavAreaBase
    {
        public const string UeClassName = "NavArea";
        public NavArea(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavArea FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavArea(p);
        public static NavArea FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavArea(o.Pointer); }
        public static NavArea[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavArea[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavArea(a[i].Pointer); return r; }
        public float DefaultCost { get => GetAt<float>(0x2C); set => SetAt(0x2C, value); }
        public float FixedAreaEnteringCost { get => GetAt<float>(0x30); set => SetAt(0x30, value); }
        public Color DrawColor => new Color(AddrOf(0x34));
        public NavAgentSelector SupportedAgents => new NavAgentSelector(AddrOf(0x38));
        public bool bSupportsAgent0 { get => Native.GetPropBool(Pointer, "bSupportsAgent0"); set => Native.SetPropBool(Pointer, "bSupportsAgent0", value); }
        public bool bSupportsAgent1 { get => Native.GetPropBool(Pointer, "bSupportsAgent1"); set => Native.SetPropBool(Pointer, "bSupportsAgent1", value); }
        public bool bSupportsAgent2 { get => Native.GetPropBool(Pointer, "bSupportsAgent2"); set => Native.SetPropBool(Pointer, "bSupportsAgent2", value); }
        public bool bSupportsAgent3 { get => Native.GetPropBool(Pointer, "bSupportsAgent3"); set => Native.SetPropBool(Pointer, "bSupportsAgent3", value); }
        public bool bSupportsAgent4 { get => Native.GetPropBool(Pointer, "bSupportsAgent4"); set => Native.SetPropBool(Pointer, "bSupportsAgent4", value); }
        public bool bSupportsAgent5 { get => Native.GetPropBool(Pointer, "bSupportsAgent5"); set => Native.SetPropBool(Pointer, "bSupportsAgent5", value); }
        public bool bSupportsAgent6 { get => Native.GetPropBool(Pointer, "bSupportsAgent6"); set => Native.SetPropBool(Pointer, "bSupportsAgent6", value); }
        public bool bSupportsAgent7 { get => Native.GetPropBool(Pointer, "bSupportsAgent7"); set => Native.SetPropBool(Pointer, "bSupportsAgent7", value); }
        public bool bSupportsAgent8 { get => Native.GetPropBool(Pointer, "bSupportsAgent8"); set => Native.SetPropBool(Pointer, "bSupportsAgent8", value); }
        public bool bSupportsAgent9 { get => Native.GetPropBool(Pointer, "bSupportsAgent9"); set => Native.SetPropBool(Pointer, "bSupportsAgent9", value); }
        public bool bSupportsAgent10 { get => Native.GetPropBool(Pointer, "bSupportsAgent10"); set => Native.SetPropBool(Pointer, "bSupportsAgent10", value); }
        public bool bSupportsAgent11 { get => Native.GetPropBool(Pointer, "bSupportsAgent11"); set => Native.SetPropBool(Pointer, "bSupportsAgent11", value); }
        public bool bSupportsAgent12 { get => Native.GetPropBool(Pointer, "bSupportsAgent12"); set => Native.SetPropBool(Pointer, "bSupportsAgent12", value); }
        public bool bSupportsAgent13 { get => Native.GetPropBool(Pointer, "bSupportsAgent13"); set => Native.SetPropBool(Pointer, "bSupportsAgent13", value); }
        public bool bSupportsAgent14 { get => Native.GetPropBool(Pointer, "bSupportsAgent14"); set => Native.SetPropBool(Pointer, "bSupportsAgent14", value); }
        public bool bSupportsAgent15 { get => Native.GetPropBool(Pointer, "bSupportsAgent15"); set => Native.SetPropBool(Pointer, "bSupportsAgent15", value); }
    }

    public class NavAreaMeta : NavArea
    {
        public const string UeClassName = "NavAreaMeta";
        public NavAreaMeta(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavAreaMeta FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavAreaMeta(p);
        public static NavAreaMeta FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavAreaMeta(o.Pointer); }
        public static NavAreaMeta[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavAreaMeta[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavAreaMeta(a[i].Pointer); return r; }
    }

    public class NavAreaMeta_SwitchByAgent : NavAreaMeta
    {
        public const string UeClassName = "NavAreaMeta_SwitchByAgent";
        public NavAreaMeta_SwitchByAgent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavAreaMeta_SwitchByAgent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavAreaMeta_SwitchByAgent(p);
        public static NavAreaMeta_SwitchByAgent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavAreaMeta_SwitchByAgent(o.Pointer); }
        public static NavAreaMeta_SwitchByAgent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavAreaMeta_SwitchByAgent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavAreaMeta_SwitchByAgent(a[i].Pointer); return r; }
        public NavArea Agent0Area { get { var __p = GetAt<global::System.IntPtr>(0x48); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x48, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent1Area { get { var __p = GetAt<global::System.IntPtr>(0x50); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x50, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent2Area { get { var __p = GetAt<global::System.IntPtr>(0x58); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x58, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent3Area { get { var __p = GetAt<global::System.IntPtr>(0x60); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x60, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent4Area { get { var __p = GetAt<global::System.IntPtr>(0x68); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x68, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent5Area { get { var __p = GetAt<global::System.IntPtr>(0x70); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x70, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent6Area { get { var __p = GetAt<global::System.IntPtr>(0x78); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x78, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent7Area { get { var __p = GetAt<global::System.IntPtr>(0x80); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x80, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent8Area { get { var __p = GetAt<global::System.IntPtr>(0x88); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x88, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent9Area { get { var __p = GetAt<global::System.IntPtr>(0x90); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x90, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent10Area { get { var __p = GetAt<global::System.IntPtr>(0x98); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x98, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent11Area { get { var __p = GetAt<global::System.IntPtr>(0xA0); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0xA0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent12Area { get { var __p = GetAt<global::System.IntPtr>(0xA8); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0xA8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent13Area { get { var __p = GetAt<global::System.IntPtr>(0xB0); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0xB0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent14Area { get { var __p = GetAt<global::System.IntPtr>(0xB8); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0xB8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea Agent15Area { get { var __p = GetAt<global::System.IntPtr>(0xC0); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0xC0, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NavArea_Default : NavArea
    {
        public const string UeClassName = "NavArea_Default";
        public NavArea_Default(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavArea_Default FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavArea_Default(p);
        public static NavArea_Default FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavArea_Default(o.Pointer); }
        public static NavArea_Default[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavArea_Default[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavArea_Default(a[i].Pointer); return r; }
    }

    public class NavArea_LowHeight : NavArea
    {
        public const string UeClassName = "NavArea_LowHeight";
        public NavArea_LowHeight(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavArea_LowHeight FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavArea_LowHeight(p);
        public static NavArea_LowHeight FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavArea_LowHeight(o.Pointer); }
        public static NavArea_LowHeight[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavArea_LowHeight[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavArea_LowHeight(a[i].Pointer); return r; }
    }

    public class NavArea_Null : NavArea
    {
        public const string UeClassName = "NavArea_Null";
        public NavArea_Null(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavArea_Null FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavArea_Null(p);
        public static NavArea_Null FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavArea_Null(o.Pointer); }
        public static NavArea_Null[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavArea_Null[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavArea_Null(a[i].Pointer); return r; }
    }

    public class NavArea_Obstacle : NavArea
    {
        public const string UeClassName = "NavArea_Obstacle";
        public NavArea_Obstacle(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavArea_Obstacle FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavArea_Obstacle(p);
        public static NavArea_Obstacle FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavArea_Obstacle(o.Pointer); }
        public static NavArea_Obstacle[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavArea_Obstacle[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavArea_Obstacle(a[i].Pointer); return r; }
    }

    public class NavCollision : NavCollisionBase
    {
        public const string UeClassName = "NavCollision";
        public NavCollision(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavCollision FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavCollision(p);
        public static NavCollision FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavCollision(o.Pointer); }
        public static NavCollision[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavCollision[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavCollision(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> CylinderCollision => new TArray<global::System.IntPtr>(AddrOf(0x80)); // TArray<struct>
        public TArray<global::System.IntPtr> BoxCollision => new TArray<global::System.IntPtr>(AddrOf(0x90)); // TArray<struct>
        public NavArea AreaClass { get { var __p = GetAt<global::System.IntPtr>(0xA0); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0xA0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bGatherConvexGeometry { get => Native.GetPropBool(Pointer, "bGatherConvexGeometry"); set => Native.SetPropBool(Pointer, "bGatherConvexGeometry", value); }
        public bool bCreateOnClient { get => Native.GetPropBool(Pointer, "bCreateOnClient"); set => Native.SetPropBool(Pointer, "bCreateOnClient", value); }
    }

    public class NavigationGraph : NavigationData
    {
        public const string UeClassName = "NavigationGraph";
        public NavigationGraph(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationGraph FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationGraph(p);
        public static NavigationGraph FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationGraph(o.Pointer); }
        public static NavigationGraph[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationGraph[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationGraph(a[i].Pointer); return r; }
    }

    public class NavigationGraphNode : Actor
    {
        public const string UeClassName = "NavigationGraphNode";
        public NavigationGraphNode(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationGraphNode FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationGraphNode(p);
        public static NavigationGraphNode FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationGraphNode(o.Pointer); }
        public static NavigationGraphNode[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationGraphNode[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationGraphNode(a[i].Pointer); return r; }
    }

    public class NavigationGraphNodeComponent : SceneComponent
    {
        public const string UeClassName = "NavigationGraphNodeComponent";
        public NavigationGraphNodeComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationGraphNodeComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationGraphNodeComponent(p);
        public static NavigationGraphNodeComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationGraphNodeComponent(o.Pointer); }
        public static NavigationGraphNodeComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationGraphNodeComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationGraphNodeComponent(a[i].Pointer); return r; }
        public NavGraphNode Node => new NavGraphNode(AddrOf(0x1F0));
        public NavigationGraphNodeComponent NextNodeComponent { get { var __p = GetAt<global::System.IntPtr>(0x208); return __p==global::System.IntPtr.Zero?null:new NavigationGraphNodeComponent(__p); } set => SetAt(0x208, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavigationGraphNodeComponent PrevNodeComponent { get { var __p = GetAt<global::System.IntPtr>(0x210); return __p==global::System.IntPtr.Zero?null:new NavigationGraphNodeComponent(__p); } set => SetAt(0x210, value?.Pointer ?? global::System.IntPtr.Zero); }
    }

    public class NavigationInvokerComponent : ActorComponent
    {
        public const string UeClassName = "NavigationInvokerComponent";
        public NavigationInvokerComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationInvokerComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationInvokerComponent(p);
        public static NavigationInvokerComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationInvokerComponent(o.Pointer); }
        public static NavigationInvokerComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationInvokerComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationInvokerComponent(a[i].Pointer); return r; }
        public float TileGenerationRadius { get => GetAt<float>(0xB0); set => SetAt(0xB0, value); }
        public float TileRemovalRadius { get => GetAt<float>(0xB4); set => SetAt(0xB4, value); }
    }

    public class NavigationPath : Object
    {
        public const string UeClassName = "NavigationPath";
        public NavigationPath(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationPath FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationPath(p);
        public static NavigationPath FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationPath(o.Pointer); }
        public static NavigationPath[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationPath[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationPath(a[i].Pointer); return r; }
        public global::System.IntPtr PathUpdatedNotifier => AddrOf(0x28); // 
        public TArray<global::System.IntPtr> PathPoints => new TArray<global::System.IntPtr>(AddrOf(0x38)); // TArray<struct>
        public byte RecalculateOnInvalidation { get => GetAt<byte>(0x48); set => SetAt(0x48, value); }
        /// <summary>[Native] thunk RVA 0x93D7DF8 — hookable via Hooks.InstallAt(NativeFunc_IsValid).</summary>
        public static global::System.IntPtr NativeFunc_IsValid => Memory.ModuleBase() + 0x93D7DF8;
        public bool IsValid()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsValid", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93D7DC0 — hookable via Hooks.InstallAt(NativeFunc_IsStringPulled).</summary>
        public static global::System.IntPtr NativeFunc_IsStringPulled => Memory.ModuleBase() + 0x93D7DC0;
        public bool IsStringPulled()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsStringPulled", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93D7E30 — hookable via Hooks.InstallAt(NativeFunc_IsPartial).</summary>
        public static global::System.IntPtr NativeFunc_IsPartial => Memory.ModuleBase() + 0x93D7E30;
        public bool IsPartial()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsPartial", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93D7E9C — hookable via Hooks.InstallAt(NativeFunc_GetPathLength).</summary>
        public static global::System.IntPtr NativeFunc_GetPathLength => Memory.ModuleBase() + 0x93D7E9C;
        public float GetPathLength()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPathLength", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x93D7E68 — hookable via Hooks.InstallAt(NativeFunc_GetPathCost).</summary>
        public static global::System.IntPtr NativeFunc_GetPathCost => Memory.ModuleBase() + 0x93D7E68;
        public float GetPathCost()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetPathCost", __pb.Bytes);
            return __pb.Get<float>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x93D8064 — hookable via Hooks.InstallAt(NativeFunc_GetDebugString).</summary>
        public static global::System.IntPtr NativeFunc_GetDebugString => Memory.ModuleBase() + 0x93D8064;
        public global::System.IntPtr GetDebugString()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetDebugString", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x93D7ED0 — hookable via Hooks.InstallAt(NativeFunc_EnableRecalculationOnInvalidation).</summary>
        public static global::System.IntPtr NativeFunc_EnableRecalculationOnInvalidation => Memory.ModuleBase() + 0x93D7ED0;
        public void EnableRecalculationOnInvalidation(byte DoRecalculation)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, DoRecalculation);
            CallRaw("EnableRecalculationOnInvalidation", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x93D7F74 — hookable via Hooks.InstallAt(NativeFunc_EnableDebugDrawing).</summary>
        public static global::System.IntPtr NativeFunc_EnableDebugDrawing => Memory.ModuleBase() + 0x93D7F74;
        public void EnableDebugDrawing(bool bShouldDrawDebugData, global::System.IntPtr PathColor)
        {
            var __pb = new ParamBuffer(20);
            __pb.Set<byte>(0x0, (byte)(bShouldDrawDebugData?1:0));
            __pb.Set<global::System.IntPtr>(0x4, PathColor);
            CallRaw("EnableDebugDrawing", __pb.Bytes);
        }
    }

    public class NavigationPathGenerator : Interface
    {
        public const string UeClassName = "NavigationPathGenerator";
        public NavigationPathGenerator(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationPathGenerator FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationPathGenerator(p);
        public static NavigationPathGenerator FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationPathGenerator(o.Pointer); }
        public static NavigationPathGenerator[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationPathGenerator[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationPathGenerator(a[i].Pointer); return r; }
    }

    public class NavigationQueryFilter : Object
    {
        public const string UeClassName = "NavigationQueryFilter";
        public NavigationQueryFilter(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationQueryFilter FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationQueryFilter(p);
        public static NavigationQueryFilter FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationQueryFilter(o.Pointer); }
        public static NavigationQueryFilter[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationQueryFilter[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationQueryFilter(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Areas => new TArray<global::System.IntPtr>(AddrOf(0x28)); // TArray<struct>
        public NavigationFilterFlags IncludeFlags => new NavigationFilterFlags(AddrOf(0x38));
        public NavigationFilterFlags ExcludeFlags => new NavigationFilterFlags(AddrOf(0x3C));
    }

    public class NavigationSystemV1 : NavigationSystemBase
    {
        public const string UeClassName = "NavigationSystemV1";
        public NavigationSystemV1(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationSystemV1 FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationSystemV1(p);
        public static NavigationSystemV1 FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationSystemV1(o.Pointer); }
        public static NavigationSystemV1[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationSystemV1[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationSystemV1(a[i].Pointer); return r; }
        public NavigationData MainNavData { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new NavigationData(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavigationData AbstractNavData { get { var __p = GetAt<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new NavigationData(__p); } set => SetAt(0x30, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string DefaultAgentName => Native.GetPropName(Pointer, "DefaultAgentName"); // FName
        public FName DefaultAgentName_Raw { get => GetAt<FName>(0x38); set => SetAt(0x38, value); }
        public UObject CrowdManagerClass { get { var __p = GetAt<global::System.IntPtr>(0x40); return __p==global::System.IntPtr.Zero?null:new UObject(__p); } set => SetAt(0x40, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bAutoCreateNavigationData { get => Native.GetPropBool(Pointer, "bAutoCreateNavigationData"); set => Native.SetPropBool(Pointer, "bAutoCreateNavigationData", value); }
        public bool bSpawnNavDataInNavBoundsLevel { get => Native.GetPropBool(Pointer, "bSpawnNavDataInNavBoundsLevel"); set => Native.SetPropBool(Pointer, "bSpawnNavDataInNavBoundsLevel", value); }
        public bool bAllowClientSideNavigation { get => Native.GetPropBool(Pointer, "bAllowClientSideNavigation"); set => Native.SetPropBool(Pointer, "bAllowClientSideNavigation", value); }
        public bool bShouldDiscardSubLevelNavData { get => Native.GetPropBool(Pointer, "bShouldDiscardSubLevelNavData"); set => Native.SetPropBool(Pointer, "bShouldDiscardSubLevelNavData", value); }
        public bool bTickWhilePaused { get => Native.GetPropBool(Pointer, "bTickWhilePaused"); set => Native.SetPropBool(Pointer, "bTickWhilePaused", value); }
        public bool bSupportRebuilding { get => Native.GetPropBool(Pointer, "bSupportRebuilding"); set => Native.SetPropBool(Pointer, "bSupportRebuilding", value); }
        public bool bInitialBuildingLocked { get => Native.GetPropBool(Pointer, "bInitialBuildingLocked"); set => Native.SetPropBool(Pointer, "bInitialBuildingLocked", value); }
        public bool bSkipAgentHeightCheckWhenPickingNavData { get => Native.GetPropBool(Pointer, "bSkipAgentHeightCheckWhenPickingNavData"); set => Native.SetPropBool(Pointer, "bSkipAgentHeightCheckWhenPickingNavData", value); }
        public ENavDataGatheringModeConfig DataGatheringMode { get => (ENavDataGatheringModeConfig)GetAt<byte>(0x6A); set => SetAt(0x6A, (byte)value); }
        public bool bGenerateNavigationOnlyAroundNavigationInvokers { get => Native.GetPropBool(Pointer, "bGenerateNavigationOnlyAroundNavigationInvokers"); set => Native.SetPropBool(Pointer, "bGenerateNavigationOnlyAroundNavigationInvokers", value); }
        public float ActiveTilesUpdateInterval { get => GetAt<float>(0x6C); set => SetAt(0x6C, value); }
        public TArray<global::System.IntPtr> SupportedAgents => new TArray<global::System.IntPtr>(AddrOf(0x70)); // TArray<struct>
        public NavAgentSelector SupportedAgentsMask => new NavAgentSelector(AddrOf(0x80));
        public TArray<global::System.IntPtr> NavDataSet => new TArray<global::System.IntPtr>(AddrOf(0x88)); // TArray<UObject*>
        public TArray<global::System.IntPtr> NavDataRegistrationQueue => new TArray<global::System.IntPtr>(AddrOf(0x98)); // TArray<UObject*>
        public global::System.IntPtr OnNavDataRegisteredEvent => AddrOf(0xB8); // 
        public global::System.IntPtr OnNavigationGenerationFinishedDelegate => AddrOf(0xC8); // 
        public FNavigationSystemRunMode OperationMode { get => (FNavigationSystemRunMode)GetAt<byte>(0x1B4); set => SetAt(0x1B4, (byte)value); }
        public float DirtyAreasUpdateFreq { get => GetAt<float>(0x50C); set => SetAt(0x50C, value); }
        /// <summary>[Native] thunk RVA 0x93DAC60 — hookable via Hooks.InstallAt(NativeFunc_UnregisterNavigationInvoker).</summary>
        public static global::System.IntPtr NativeFunc_UnregisterNavigationInvoker => Memory.ModuleBase() + 0x93DAC60;
        public void UnregisterNavigationInvoker(Actor Invoker)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Invoker);
            CallRaw("UnregisterNavigationInvoker", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x93DA2FC — hookable via Hooks.InstallAt(NativeFunc_SimpleMoveToLocation).</summary>
        public static global::System.IntPtr NativeFunc_SimpleMoveToLocation => Memory.ModuleBase() + 0x93DA2FC;
        public void SimpleMoveToLocation(Controller Controller, global::System.IntPtr Goal)
        {
            var __pb = new ParamBuffer(20);
            __pb.SetObject(0x0, Controller);
            __pb.Set<global::System.IntPtr>(0x8, Goal);
            CallRaw("SimpleMoveToLocation", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x93DA3E0 — hookable via Hooks.InstallAt(NativeFunc_SimpleMoveToActor).</summary>
        public static global::System.IntPtr NativeFunc_SimpleMoveToActor => Memory.ModuleBase() + 0x93DA3E0;
        public void SimpleMoveToActor(Controller Controller, Actor Goal)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Controller);
            __pb.SetObject(0x8, Goal);
            CallRaw("SimpleMoveToActor", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x93DAE40 — hookable via Hooks.InstallAt(NativeFunc_SetMaxSimultaneousTileGenerationJobsCount).</summary>
        public static global::System.IntPtr NativeFunc_SetMaxSimultaneousTileGenerationJobsCount => Memory.ModuleBase() + 0x93DAE40;
        public void SetMaxSimultaneousTileGenerationJobsCount(int MaxNumberOfJobs)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, MaxNumberOfJobs);
            CallRaw("SetMaxSimultaneousTileGenerationJobsCount", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x93DABBC — hookable via Hooks.InstallAt(NativeFunc_SetGeometryGatheringMode).</summary>
        public static global::System.IntPtr NativeFunc_SetGeometryGatheringMode => Memory.ModuleBase() + 0x93DABBC;
        public void SetGeometryGatheringMode(ENavDataGatheringModeConfig NewMode)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)NewMode);
            CallRaw("SetGeometryGatheringMode", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x93DAE2C — hookable via Hooks.InstallAt(NativeFunc_ResetMaxSimultaneousTileGenerationJobsCount).</summary>
        public static global::System.IntPtr NativeFunc_ResetMaxSimultaneousTileGenerationJobsCount => Memory.ModuleBase() + 0x93DAE2C;
        public void ResetMaxSimultaneousTileGenerationJobsCount()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetMaxSimultaneousTileGenerationJobsCount", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x93DAD04 — hookable via Hooks.InstallAt(NativeFunc_RegisterNavigationInvoker).</summary>
        public static global::System.IntPtr NativeFunc_RegisterNavigationInvoker => Memory.ModuleBase() + 0x93DAD04;
        public void RegisterNavigationInvoker(Actor Invoker, float TileGenerationRadius, float TileRemovalRadius)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, Invoker);
            __pb.Set(0x8, TileGenerationRadius);
            __pb.Set(0xC, TileRemovalRadius);
            CallRaw("RegisterNavigationInvoker", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x93DA82C — hookable via Hooks.InstallAt(NativeFunc_ProjectPointToNavigation).</summary>
        public static global::System.IntPtr NativeFunc_ProjectPointToNavigation => Memory.ModuleBase() + 0x93DA82C;
        public global::System.IntPtr ProjectPointToNavigation(Object WorldContextObject, global::System.IntPtr Point, NavigationData NavData, NavigationQueryFilter FilterClass, global::System.IntPtr QueryExtent)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, Point);
            __pb.SetObject(0x18, NavData);
            __pb.SetObject(0x20, FilterClass);
            __pb.Set<global::System.IntPtr>(0x28, QueryExtent);
            CallRaw("ProjectPointToNavigation", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x34);
        }
        /// <summary>[Native] thunk RVA 0x93DA9E4 — hookable via Hooks.InstallAt(NativeFunc_OnNavigationBoundsUpdated).</summary>
        public static global::System.IntPtr NativeFunc_OnNavigationBoundsUpdated => Memory.ModuleBase() + 0x93DA9E4;
        public void OnNavigationBoundsUpdated(NavMeshBoundsVolume NavVolume)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NavVolume);
            CallRaw("OnNavigationBoundsUpdated", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x93DAEE4 — hookable via Hooks.InstallAt(NativeFunc_NavigationRaycast).</summary>
        public static global::System.IntPtr NativeFunc_NavigationRaycast => Memory.ModuleBase() + 0x93DAEE4;
        public bool NavigationRaycast(Object WorldContextObject, global::System.IntPtr RayStart, global::System.IntPtr RayEnd, global::System.IntPtr HitLocation, NavigationQueryFilter FilterClass, Controller Querier)
        {
            var __pb = new ParamBuffer(65);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, RayStart);
            __pb.Set<global::System.IntPtr>(0x14, RayEnd);
            __pb.Set<global::System.IntPtr>(0x20, HitLocation);
            __pb.SetObject(0x30, FilterClass);
            __pb.SetObject(0x38, Querier);
            CallRaw("NavigationRaycast", __pb.Bytes);
            return __pb.Get<byte>(0x40) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93DAA88 — hookable via Hooks.InstallAt(NativeFunc_K2_ReplaceAreaInOctreeData).</summary>
        public static global::System.IntPtr NativeFunc_K2_ReplaceAreaInOctreeData => Memory.ModuleBase() + 0x93DAA88;
        public bool K2_ReplaceAreaInOctreeData(Object Object, NavArea OldArea, NavArea NewArea)
        {
            var __pb = new ParamBuffer(25);
            __pb.SetObject(0x0, Object);
            __pb.SetObject(0x8, OldArea);
            __pb.SetObject(0x10, NewArea);
            CallRaw("K2_ReplaceAreaInOctreeData", __pb.Bytes);
            return __pb.Get<byte>(0x18) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93DBE60 — hookable via Hooks.InstallAt(NativeFunc_K2_ProjectPointToNavigation).</summary>
        public static global::System.IntPtr NativeFunc_K2_ProjectPointToNavigation => Memory.ModuleBase() + 0x93DBE60;
        public bool K2_ProjectPointToNavigation(Object WorldContextObject, global::System.IntPtr Point, global::System.IntPtr ProjectedLocation, NavigationData NavData, NavigationQueryFilter FilterClass, global::System.IntPtr QueryExtent)
        {
            var __pb = new ParamBuffer(61);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, Point);
            __pb.Set<global::System.IntPtr>(0x14, ProjectedLocation);
            __pb.SetObject(0x20, NavData);
            __pb.SetObject(0x28, FilterClass);
            __pb.Set<global::System.IntPtr>(0x30, QueryExtent);
            CallRaw("K2_ProjectPointToNavigation", __pb.Bytes);
            return __pb.Get<byte>(0x3C) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93DBC50 — hookable via Hooks.InstallAt(NativeFunc_K2_GetRandomReachablePointInRadius).</summary>
        public static global::System.IntPtr NativeFunc_K2_GetRandomReachablePointInRadius => Memory.ModuleBase() + 0x93DBC50;
        public bool K2_GetRandomReachablePointInRadius(Object WorldContextObject, global::System.IntPtr Origin, global::System.IntPtr RandomLocation, float Radius, NavigationData NavData, NavigationQueryFilter FilterClass)
        {
            var __pb = new ParamBuffer(57);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, Origin);
            __pb.Set<global::System.IntPtr>(0x14, RandomLocation);
            __pb.Set(0x20, Radius);
            __pb.SetObject(0x28, NavData);
            __pb.SetObject(0x30, FilterClass);
            CallRaw("K2_GetRandomReachablePointInRadius", __pb.Bytes);
            return __pb.Get<byte>(0x38) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93DA0EC — hookable via Hooks.InstallAt(NativeFunc_K2_GetRandomPointInNavigableRadius).</summary>
        public static global::System.IntPtr NativeFunc_K2_GetRandomPointInNavigableRadius => Memory.ModuleBase() + 0x93DA0EC;
        public bool K2_GetRandomPointInNavigableRadius(Object WorldContextObject, global::System.IntPtr Origin, global::System.IntPtr RandomLocation, float Radius, NavigationData NavData, NavigationQueryFilter FilterClass)
        {
            var __pb = new ParamBuffer(57);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, Origin);
            __pb.Set<global::System.IntPtr>(0x14, RandomLocation);
            __pb.Set(0x20, Radius);
            __pb.SetObject(0x28, NavData);
            __pb.SetObject(0x30, FilterClass);
            CallRaw("K2_GetRandomPointInNavigableRadius", __pb.Bytes);
            return __pb.Get<byte>(0x38) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93DBA40 — hookable via Hooks.InstallAt(NativeFunc_K2_GetRandomLocationInNavigableRadius).</summary>
        public static global::System.IntPtr NativeFunc_K2_GetRandomLocationInNavigableRadius => Memory.ModuleBase() + 0x93DBA40;
        public bool K2_GetRandomLocationInNavigableRadius(Object WorldContextObject, global::System.IntPtr Origin, global::System.IntPtr RandomLocation, float Radius, NavigationData NavData, NavigationQueryFilter FilterClass)
        {
            var __pb = new ParamBuffer(57);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, Origin);
            __pb.Set<global::System.IntPtr>(0x14, RandomLocation);
            __pb.Set(0x20, Radius);
            __pb.SetObject(0x28, NavData);
            __pb.SetObject(0x30, FilterClass);
            CallRaw("K2_GetRandomLocationInNavigableRadius", __pb.Bytes);
            return __pb.Get<byte>(0x38) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93DB4C0 — hookable via Hooks.InstallAt(NativeFunc_IsNavigationBeingBuiltOrLocked).</summary>
        public static global::System.IntPtr NativeFunc_IsNavigationBeingBuiltOrLocked => Memory.ModuleBase() + 0x93DB4C0;
        public bool IsNavigationBeingBuiltOrLocked(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("IsNavigationBeingBuiltOrLocked", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93DB568 — hookable via Hooks.InstallAt(NativeFunc_IsNavigationBeingBuilt).</summary>
        public static global::System.IntPtr NativeFunc_IsNavigationBeingBuilt => Memory.ModuleBase() + 0x93DB568;
        public bool IsNavigationBeingBuilt(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(9);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("IsNavigationBeingBuilt", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x93DA670 — hookable via Hooks.InstallAt(NativeFunc_GetRandomReachablePointInRadius).</summary>
        public static global::System.IntPtr NativeFunc_GetRandomReachablePointInRadius => Memory.ModuleBase() + 0x93DA670;
        public global::System.IntPtr GetRandomReachablePointInRadius(Object WorldContextObject, global::System.IntPtr Origin, float Radius, NavigationData NavData, NavigationQueryFilter FilterClass)
        {
            var __pb = new ParamBuffer(52);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, Origin);
            __pb.Set(0x14, Radius);
            __pb.SetObject(0x18, NavData);
            __pb.SetObject(0x20, FilterClass);
            CallRaw("GetRandomReachablePointInRadius", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x28);
        }
        /// <summary>[Native] thunk RVA 0x93DA4B4 — hookable via Hooks.InstallAt(NativeFunc_GetRandomPointInNavigableRadius).</summary>
        public static global::System.IntPtr NativeFunc_GetRandomPointInNavigableRadius => Memory.ModuleBase() + 0x93DA4B4;
        public global::System.IntPtr GetRandomPointInNavigableRadius(Object WorldContextObject, global::System.IntPtr Origin, float Radius, NavigationData NavData, NavigationQueryFilter FilterClass)
        {
            var __pb = new ParamBuffer(52);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, Origin);
            __pb.Set(0x14, Radius);
            __pb.SetObject(0x18, NavData);
            __pb.SetObject(0x20, FilterClass);
            CallRaw("GetRandomPointInNavigableRadius", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x28);
        }
        /// <summary>[Native] thunk RVA 0x93DB610 — hookable via Hooks.InstallAt(NativeFunc_GetPathLength).</summary>
        public static global::System.IntPtr NativeFunc_GetPathLength => Memory.ModuleBase() + 0x93DB610;
        public byte GetPathLength(Object WorldContextObject, global::System.IntPtr PathStart, global::System.IntPtr PathEnd, float PathLength, NavigationData NavData, NavigationQueryFilter FilterClass)
        {
            var __pb = new ParamBuffer(57);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, PathStart);
            __pb.Set<global::System.IntPtr>(0x14, PathEnd);
            __pb.Set(0x20, PathLength);
            __pb.SetObject(0x28, NavData);
            __pb.SetObject(0x30, FilterClass);
            CallRaw("GetPathLength", __pb.Bytes);
            return __pb.Get<byte>(0x38);
        }
        /// <summary>[Native] thunk RVA 0x93DB828 — hookable via Hooks.InstallAt(NativeFunc_GetPathCost).</summary>
        public static global::System.IntPtr NativeFunc_GetPathCost => Memory.ModuleBase() + 0x93DB828;
        public byte GetPathCost(Object WorldContextObject, global::System.IntPtr PathStart, global::System.IntPtr PathEnd, float PathCost, NavigationData NavData, NavigationQueryFilter FilterClass)
        {
            var __pb = new ParamBuffer(57);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, PathStart);
            __pb.Set<global::System.IntPtr>(0x14, PathEnd);
            __pb.Set(0x20, PathCost);
            __pb.SetObject(0x28, NavData);
            __pb.SetObject(0x30, FilterClass);
            CallRaw("GetPathCost", __pb.Bytes);
            return __pb.Get<byte>(0x38);
        }
        /// <summary>[Native] thunk RVA 0x93DC06C — hookable via Hooks.InstallAt(NativeFunc_GetNavigationSystem).</summary>
        public static global::System.IntPtr NativeFunc_GetNavigationSystem => Memory.ModuleBase() + 0x93DC06C;
        public NavigationSystemV1 GetNavigationSystem(Object WorldContextObject)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, WorldContextObject);
            CallRaw("GetNavigationSystem", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new NavigationSystemV1(__p); }
        }
        /// <summary>[Native] thunk RVA 0x93DB2F8 — hookable via Hooks.InstallAt(NativeFunc_FindPathToLocationSynchronously).</summary>
        public static global::System.IntPtr NativeFunc_FindPathToLocationSynchronously => Memory.ModuleBase() + 0x93DB2F8;
        public NavigationPath FindPathToLocationSynchronously(Object WorldContextObject, global::System.IntPtr PathStart, global::System.IntPtr PathEnd, Actor PathfindingContext, NavigationQueryFilter FilterClass)
        {
            var __pb = new ParamBuffer(56);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, PathStart);
            __pb.Set<global::System.IntPtr>(0x14, PathEnd);
            __pb.SetObject(0x20, PathfindingContext);
            __pb.SetObject(0x28, FilterClass);
            CallRaw("FindPathToLocationSynchronously", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x30); return __p==global::System.IntPtr.Zero?null:new NavigationPath(__p); }
        }
        /// <summary>[Native] thunk RVA 0x93DB0FC — hookable via Hooks.InstallAt(NativeFunc_FindPathToActorSynchronously).</summary>
        public static global::System.IntPtr NativeFunc_FindPathToActorSynchronously => Memory.ModuleBase() + 0x93DB0FC;
        public NavigationPath FindPathToActorSynchronously(Object WorldContextObject, global::System.IntPtr PathStart, Actor GoalActor, float TetherDistance, Actor PathfindingContext, NavigationQueryFilter FilterClass)
        {
            var __pb = new ParamBuffer(64);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.Set<global::System.IntPtr>(0x8, PathStart);
            __pb.SetObject(0x18, GoalActor);
            __pb.Set(0x20, TetherDistance);
            __pb.SetObject(0x28, PathfindingContext);
            __pb.SetObject(0x30, FilterClass);
            CallRaw("FindPathToActorSynchronously", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x38); return __p==global::System.IntPtr.Zero?null:new NavigationPath(__p); }
        }
    }

    public class NavigationSystemModuleConfig : NavigationSystemConfig
    {
        public const string UeClassName = "NavigationSystemModuleConfig";
        public NavigationSystemModuleConfig(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationSystemModuleConfig FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationSystemModuleConfig(p);
        public static NavigationSystemModuleConfig FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationSystemModuleConfig(o.Pointer); }
        public static NavigationSystemModuleConfig[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationSystemModuleConfig[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationSystemModuleConfig(a[i].Pointer); return r; }
        public bool bStrictlyStatic { get => Native.GetPropBool(Pointer, "bStrictlyStatic"); set => Native.SetPropBool(Pointer, "bStrictlyStatic", value); }
        public bool bCreateOnClient { get => Native.GetPropBool(Pointer, "bCreateOnClient"); set => Native.SetPropBool(Pointer, "bCreateOnClient", value); }
        public bool bAutoSpawnMissingNavData { get => Native.GetPropBool(Pointer, "bAutoSpawnMissingNavData"); set => Native.SetPropBool(Pointer, "bAutoSpawnMissingNavData", value); }
        public bool bSpawnNavDataInNavBoundsLevel { get => Native.GetPropBool(Pointer, "bSpawnNavDataInNavBoundsLevel"); set => Native.SetPropBool(Pointer, "bSpawnNavDataInNavBoundsLevel", value); }
    }

    public class NavigationTestingActor : Actor
    {
        public const string UeClassName = "NavigationTestingActor";
        public NavigationTestingActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavigationTestingActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavigationTestingActor(p);
        public static NavigationTestingActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavigationTestingActor(o.Pointer); }
        public static NavigationTestingActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavigationTestingActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavigationTestingActor(a[i].Pointer); return r; }
        public CapsuleComponent CapsuleComponent { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new CapsuleComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavigationInvokerComponent InvokerComponent { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new NavigationInvokerComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool bActAsNavigationInvoker { get => Native.GetPropBool(Pointer, "bActAsNavigationInvoker"); set => Native.SetPropBool(Pointer, "bActAsNavigationInvoker", value); }
        public NavAgentProperties NavAgentProps => new NavAgentProperties(AddrOf(0x248));
        public Vector QueryingExtent => new Vector(AddrOf(0x278));
        public NavigationData MyNavData { get { var __p = GetAt<global::System.IntPtr>(0x288); return __p==global::System.IntPtr.Zero?null:new NavigationData(__p); } set => SetAt(0x288, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vector ProjectedLocation => new Vector(AddrOf(0x290));
        public bool bProjectedLocationValid { get => Native.GetPropBool(Pointer, "bProjectedLocationValid"); set => Native.SetPropBool(Pointer, "bProjectedLocationValid", value); }
        public bool bSearchStart { get => Native.GetPropBool(Pointer, "bSearchStart"); set => Native.SetPropBool(Pointer, "bSearchStart", value); }
        public float CostLimitFactor { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public float MinimumCostLimit { get => GetAt<float>(0x2A4); set => SetAt(0x2A4, value); }
        public bool bBacktracking { get => Native.GetPropBool(Pointer, "bBacktracking"); set => Native.SetPropBool(Pointer, "bBacktracking", value); }
        public bool bUseHierarchicalPathfinding { get => Native.GetPropBool(Pointer, "bUseHierarchicalPathfinding"); set => Native.SetPropBool(Pointer, "bUseHierarchicalPathfinding", value); }
        public bool bGatherDetailedInfo { get => Native.GetPropBool(Pointer, "bGatherDetailedInfo"); set => Native.SetPropBool(Pointer, "bGatherDetailedInfo", value); }
        public bool bDrawDistanceToWall { get => Native.GetPropBool(Pointer, "bDrawDistanceToWall"); set => Native.SetPropBool(Pointer, "bDrawDistanceToWall", value); }
        public bool bShowNodePool { get => Native.GetPropBool(Pointer, "bShowNodePool"); set => Native.SetPropBool(Pointer, "bShowNodePool", value); }
        public bool bShowBestPath { get => Native.GetPropBool(Pointer, "bShowBestPath"); set => Native.SetPropBool(Pointer, "bShowBestPath", value); }
        public bool bShowDiffWithPreviousStep { get => Native.GetPropBool(Pointer, "bShowDiffWithPreviousStep"); set => Native.SetPropBool(Pointer, "bShowDiffWithPreviousStep", value); }
        public bool bShouldBeVisibleInGame { get => Native.GetPropBool(Pointer, "bShouldBeVisibleInGame"); set => Native.SetPropBool(Pointer, "bShouldBeVisibleInGame", value); }
        public byte CostDisplayMode { get => GetAt<byte>(0x2A9); set => SetAt(0x2A9, value); }
        public Vector2D TextCanvasOffset => new Vector2D(AddrOf(0x2AC));
        public bool bPathExist { get => Native.GetPropBool(Pointer, "bPathExist"); set => Native.SetPropBool(Pointer, "bPathExist", value); }
        public bool bPathIsPartial { get => Native.GetPropBool(Pointer, "bPathIsPartial"); set => Native.SetPropBool(Pointer, "bPathIsPartial", value); }
        public bool bPathSearchOutOfNodes { get => Native.GetPropBool(Pointer, "bPathSearchOutOfNodes"); set => Native.SetPropBool(Pointer, "bPathSearchOutOfNodes", value); }
        public float PathfindingTime { get => GetAt<float>(0x2B8); set => SetAt(0x2B8, value); }
        public float PathCost { get => GetAt<float>(0x2BC); set => SetAt(0x2BC, value); }
        public int PathfindingSteps { get => GetAt<int>(0x2C0); set => SetAt(0x2C0, value); }
        public NavigationTestingActor OtherActor { get { var __p = GetAt<global::System.IntPtr>(0x2C8); return __p==global::System.IntPtr.Zero?null:new NavigationTestingActor(__p); } set => SetAt(0x2C8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavigationQueryFilter FilterClass { get { var __p = GetAt<global::System.IntPtr>(0x2D0); return __p==global::System.IntPtr.Zero?null:new NavigationQueryFilter(__p); } set => SetAt(0x2D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int ShowStepIndex { get => GetAt<int>(0x2D8); set => SetAt(0x2D8, value); }
        public float OffsetFromCornersDistance { get => GetAt<float>(0x2DC); set => SetAt(0x2DC, value); }
    }

    public class NavLinkComponent : PrimitiveComponent
    {
        public const string UeClassName = "NavLinkComponent";
        public NavLinkComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavLinkComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavLinkComponent(p);
        public static NavLinkComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavLinkComponent(o.Pointer); }
        public static NavLinkComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavLinkComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavLinkComponent(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Links => new TArray<global::System.IntPtr>(AddrOf(0x410)); // TArray<struct>
    }

    public class NavRelevantComponent : ActorComponent
    {
        public const string UeClassName = "NavRelevantComponent";
        public NavRelevantComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavRelevantComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavRelevantComponent(p);
        public static NavRelevantComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavRelevantComponent(o.Pointer); }
        public static NavRelevantComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavRelevantComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavRelevantComponent(a[i].Pointer); return r; }
        public bool bAttachToOwnersRoot { get => Native.GetPropBool(Pointer, "bAttachToOwnersRoot"); set => Native.SetPropBool(Pointer, "bAttachToOwnersRoot", value); }
        public Object CachedNavParent { get { var __p = GetAt<global::System.IntPtr>(0xD8); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0xD8, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x93E3D74 — hookable via Hooks.InstallAt(NativeFunc_SetNavigationRelevancy).</summary>
        public static global::System.IntPtr NativeFunc_SetNavigationRelevancy => Memory.ModuleBase() + 0x93E3D74;
        public void SetNavigationRelevancy(bool bRelevant)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(bRelevant?1:0));
            CallRaw("SetNavigationRelevancy", __pb.Bytes);
        }
    }

    public class NavLinkCustomComponent : NavRelevantComponent
    {
        public const string UeClassName = "NavLinkCustomComponent";
        public NavLinkCustomComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavLinkCustomComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavLinkCustomComponent(p);
        public static NavLinkCustomComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavLinkCustomComponent(o.Pointer); }
        public static NavLinkCustomComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavLinkCustomComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavLinkCustomComponent(a[i].Pointer); return r; }
        public uint NavLinkUserId { get => GetAt<uint>(0xE8); set => SetAt(0xE8, value); }
        public NavArea EnabledAreaClass { get { var __p = GetAt<global::System.IntPtr>(0xF0); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0xF0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavArea DisabledAreaClass { get { var __p = GetAt<global::System.IntPtr>(0xF8); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0xF8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public NavAgentSelector SupportedAgents => new NavAgentSelector(AddrOf(0x100));
        public Vector LinkRelativeStart => new Vector(AddrOf(0x104));
        public Vector LinkRelativeEnd => new Vector(AddrOf(0x110));
        public byte LinkDirection { get => GetAt<byte>(0x11C); set => SetAt(0x11C, value); }
        public bool bLinkEnabled { get => Native.GetPropBool(Pointer, "bLinkEnabled"); set => Native.SetPropBool(Pointer, "bLinkEnabled", value); }
        public bool bNotifyWhenEnabled { get => Native.GetPropBool(Pointer, "bNotifyWhenEnabled"); set => Native.SetPropBool(Pointer, "bNotifyWhenEnabled", value); }
        public bool bNotifyWhenDisabled { get => Native.GetPropBool(Pointer, "bNotifyWhenDisabled"); set => Native.SetPropBool(Pointer, "bNotifyWhenDisabled", value); }
        public bool bCreateBoxObstacle { get => Native.GetPropBool(Pointer, "bCreateBoxObstacle"); set => Native.SetPropBool(Pointer, "bCreateBoxObstacle", value); }
        public Vector ObstacleOffset => new Vector(AddrOf(0x120));
        public Vector ObstacleExtent => new Vector(AddrOf(0x12C));
        public NavArea ObstacleAreaClass { get { var __p = GetAt<global::System.IntPtr>(0x138); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x138, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float BroadcastRadius { get => GetAt<float>(0x140); set => SetAt(0x140, value); }
        public float BroadcastInterval { get => GetAt<float>(0x144); set => SetAt(0x144, value); }
        public byte BroadcastChannel { get => GetAt<byte>(0x148); set => SetAt(0x148, value); }
    }

    public class NavLinkCustomInterface : Interface
    {
        public const string UeClassName = "NavLinkCustomInterface";
        public NavLinkCustomInterface(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavLinkCustomInterface FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavLinkCustomInterface(p);
        public static NavLinkCustomInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavLinkCustomInterface(o.Pointer); }
        public static NavLinkCustomInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavLinkCustomInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavLinkCustomInterface(a[i].Pointer); return r; }
    }

    public class NavLinkHostInterface : Interface
    {
        public const string UeClassName = "NavLinkHostInterface";
        public NavLinkHostInterface(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavLinkHostInterface FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavLinkHostInterface(p);
        public static NavLinkHostInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavLinkHostInterface(o.Pointer); }
        public static NavLinkHostInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavLinkHostInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavLinkHostInterface(a[i].Pointer); return r; }
    }

    public class NavLinkRenderingComponent : PrimitiveComponent
    {
        public const string UeClassName = "NavLinkRenderingComponent";
        public NavLinkRenderingComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavLinkRenderingComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavLinkRenderingComponent(p);
        public static NavLinkRenderingComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavLinkRenderingComponent(o.Pointer); }
        public static NavLinkRenderingComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavLinkRenderingComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavLinkRenderingComponent(a[i].Pointer); return r; }
    }

    public class NavLinkTrivial : NavLinkDefinition
    {
        public const string UeClassName = "NavLinkTrivial";
        public NavLinkTrivial(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavLinkTrivial FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavLinkTrivial(p);
        public static NavLinkTrivial FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavLinkTrivial(o.Pointer); }
        public static NavLinkTrivial[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavLinkTrivial[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavLinkTrivial(a[i].Pointer); return r; }
    }

    public class NavMeshBoundsVolume : Volume
    {
        public const string UeClassName = "NavMeshBoundsVolume";
        public NavMeshBoundsVolume(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavMeshBoundsVolume FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavMeshBoundsVolume(p);
        public static NavMeshBoundsVolume FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavMeshBoundsVolume(o.Pointer); }
        public static NavMeshBoundsVolume[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavMeshBoundsVolume[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavMeshBoundsVolume(a[i].Pointer); return r; }
        public NavAgentSelector SupportedAgents => new NavAgentSelector(AddrOf(0x258));
    }

    public class NavMeshRenderingComponent : PrimitiveComponent
    {
        public const string UeClassName = "NavMeshRenderingComponent";
        public NavMeshRenderingComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavMeshRenderingComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavMeshRenderingComponent(p);
        public static NavMeshRenderingComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavMeshRenderingComponent(o.Pointer); }
        public static NavMeshRenderingComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavMeshRenderingComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavMeshRenderingComponent(a[i].Pointer); return r; }
    }

    public class NavModifierComponent : NavRelevantComponent
    {
        public const string UeClassName = "NavModifierComponent";
        public NavModifierComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavModifierComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavModifierComponent(p);
        public static NavModifierComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavModifierComponent(o.Pointer); }
        public static NavModifierComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavModifierComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavModifierComponent(a[i].Pointer); return r; }
        public NavArea AreaClass { get { var __p = GetAt<global::System.IntPtr>(0xE0); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0xE0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Vector FailsafeExtent => new Vector(AddrOf(0xE8));
        public bool bIncludeAgentHeight { get => Native.GetPropBool(Pointer, "bIncludeAgentHeight"); set => Native.SetPropBool(Pointer, "bIncludeAgentHeight", value); }
        /// <summary>[Native] thunk RVA 0x93E23D0 — hookable via Hooks.InstallAt(NativeFunc_SetAreaClass).</summary>
        public static global::System.IntPtr NativeFunc_SetAreaClass => Memory.ModuleBase() + 0x93E23D0;
        public void SetAreaClass(NavArea NewAreaClass)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewAreaClass);
            CallRaw("SetAreaClass", __pb.Bytes);
        }
    }

    public class NavModifierVolume : Volume
    {
        public const string UeClassName = "NavModifierVolume";
        public NavModifierVolume(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavModifierVolume FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavModifierVolume(p);
        public static NavModifierVolume FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavModifierVolume(o.Pointer); }
        public static NavModifierVolume[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavModifierVolume[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavModifierVolume(a[i].Pointer); return r; }
        public NavArea AreaClass { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new NavArea(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x93E2D28 — hookable via Hooks.InstallAt(NativeFunc_SetAreaClass).</summary>
        public static global::System.IntPtr NativeFunc_SetAreaClass => Memory.ModuleBase() + 0x93E2D28;
        public void SetAreaClass(NavArea NewAreaClass)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, NewAreaClass);
            CallRaw("SetAreaClass", __pb.Bytes);
        }
    }

    public class NavNodeInterface : Interface
    {
        public const string UeClassName = "NavNodeInterface";
        public NavNodeInterface(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavNodeInterface FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavNodeInterface(p);
        public static NavNodeInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavNodeInterface(o.Pointer); }
        public static NavNodeInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavNodeInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavNodeInterface(a[i].Pointer); return r; }
    }

    public class NavSystemConfigOverride : Actor
    {
        public const string UeClassName = "NavSystemConfigOverride";
        public NavSystemConfigOverride(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavSystemConfigOverride FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavSystemConfigOverride(p);
        public static NavSystemConfigOverride FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavSystemConfigOverride(o.Pointer); }
        public static NavSystemConfigOverride[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavSystemConfigOverride[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavSystemConfigOverride(a[i].Pointer); return r; }
        public NavigationSystemConfig NavigationSystemConfig { get { var __p = GetAt<global::System.IntPtr>(0x220); return __p==global::System.IntPtr.Zero?null:new NavigationSystemConfig(__p); } set => SetAt(0x220, value?.Pointer ?? global::System.IntPtr.Zero); }
        public ENavSystemOverridePolicy OverridePolicy { get => (ENavSystemOverridePolicy)GetAt<byte>(0x228); set => SetAt(0x228, (byte)value); }
        public bool bLoadOnClient { get => Native.GetPropBool(Pointer, "bLoadOnClient"); set => Native.SetPropBool(Pointer, "bLoadOnClient", value); }
    }

    public class NavTestRenderingComponent : PrimitiveComponent
    {
        public const string UeClassName = "NavTestRenderingComponent";
        public NavTestRenderingComponent(global::System.IntPtr ptr) : base(ptr) {}
        public static new NavTestRenderingComponent FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new NavTestRenderingComponent(p);
        public static NavTestRenderingComponent FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new NavTestRenderingComponent(o.Pointer); }
        public static NavTestRenderingComponent[] All() { var a = UObject.FindAllOf(UeClassName); var r = new NavTestRenderingComponent[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new NavTestRenderingComponent(a[i].Pointer); return r; }
    }

    public class RecastFilter_UseDefaultArea : NavigationQueryFilter
    {
        public const string UeClassName = "RecastFilter_UseDefaultArea";
        public RecastFilter_UseDefaultArea(global::System.IntPtr ptr) : base(ptr) {}
        public static new RecastFilter_UseDefaultArea FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new RecastFilter_UseDefaultArea(p);
        public static RecastFilter_UseDefaultArea FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RecastFilter_UseDefaultArea(o.Pointer); }
        public static RecastFilter_UseDefaultArea[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RecastFilter_UseDefaultArea[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RecastFilter_UseDefaultArea(a[i].Pointer); return r; }
    }

    public class RecastNavMesh : NavigationData
    {
        public const string UeClassName = "RecastNavMesh";
        public RecastNavMesh(global::System.IntPtr ptr) : base(ptr) {}
        public static new RecastNavMesh FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new RecastNavMesh(p);
        public static RecastNavMesh FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RecastNavMesh(o.Pointer); }
        public static RecastNavMesh[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RecastNavMesh[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RecastNavMesh(a[i].Pointer); return r; }
        public bool bDrawTriangleEdges { get => Native.GetPropBool(Pointer, "bDrawTriangleEdges"); set => Native.SetPropBool(Pointer, "bDrawTriangleEdges", value); }
        public bool bDrawPolyEdges { get => Native.GetPropBool(Pointer, "bDrawPolyEdges"); set => Native.SetPropBool(Pointer, "bDrawPolyEdges", value); }
        public bool bDrawFilledPolys { get => Native.GetPropBool(Pointer, "bDrawFilledPolys"); set => Native.SetPropBool(Pointer, "bDrawFilledPolys", value); }
        public bool bDrawNavMeshEdges { get => Native.GetPropBool(Pointer, "bDrawNavMeshEdges"); set => Native.SetPropBool(Pointer, "bDrawNavMeshEdges", value); }
        public bool bDrawTileBounds { get => Native.GetPropBool(Pointer, "bDrawTileBounds"); set => Native.SetPropBool(Pointer, "bDrawTileBounds", value); }
        public bool bDrawPathCollidingGeometry { get => Native.GetPropBool(Pointer, "bDrawPathCollidingGeometry"); set => Native.SetPropBool(Pointer, "bDrawPathCollidingGeometry", value); }
        public bool bDrawTileLabels { get => Native.GetPropBool(Pointer, "bDrawTileLabels"); set => Native.SetPropBool(Pointer, "bDrawTileLabels", value); }
        public bool bDrawPolygonLabels { get => Native.GetPropBool(Pointer, "bDrawPolygonLabels"); set => Native.SetPropBool(Pointer, "bDrawPolygonLabels", value); }
        public bool bDrawDefaultPolygonCost { get => Native.GetPropBool(Pointer, "bDrawDefaultPolygonCost"); set => Native.SetPropBool(Pointer, "bDrawDefaultPolygonCost", value); }
        public bool bDrawLabelsOnPathNodes { get => Native.GetPropBool(Pointer, "bDrawLabelsOnPathNodes"); set => Native.SetPropBool(Pointer, "bDrawLabelsOnPathNodes", value); }
        public bool bDrawNavLinks { get => Native.GetPropBool(Pointer, "bDrawNavLinks"); set => Native.SetPropBool(Pointer, "bDrawNavLinks", value); }
        public bool bDrawFailedNavLinks { get => Native.GetPropBool(Pointer, "bDrawFailedNavLinks"); set => Native.SetPropBool(Pointer, "bDrawFailedNavLinks", value); }
        public bool bDrawClusters { get => Native.GetPropBool(Pointer, "bDrawClusters"); set => Native.SetPropBool(Pointer, "bDrawClusters", value); }
        public bool bDrawOctree { get => Native.GetPropBool(Pointer, "bDrawOctree"); set => Native.SetPropBool(Pointer, "bDrawOctree", value); }
        public bool bDrawOctreeDetails { get => Native.GetPropBool(Pointer, "bDrawOctreeDetails"); set => Native.SetPropBool(Pointer, "bDrawOctreeDetails", value); }
        public bool bDrawMarkedForbiddenPolys { get => Native.GetPropBool(Pointer, "bDrawMarkedForbiddenPolys"); set => Native.SetPropBool(Pointer, "bDrawMarkedForbiddenPolys", value); }
        public bool bDistinctlyDrawTilesBeingBuilt { get => Native.GetPropBool(Pointer, "bDistinctlyDrawTilesBeingBuilt"); set => Native.SetPropBool(Pointer, "bDistinctlyDrawTilesBeingBuilt", value); }
        public bool bDrawNavMesh { get => Native.GetPropBool(Pointer, "bDrawNavMesh"); set => Native.SetPropBool(Pointer, "bDrawNavMesh", value); }
        public float DrawOffset { get => GetAt<float>(0x400); set => SetAt(0x400, value); }
        public bool bFixedTilePoolSize { get => Native.GetPropBool(Pointer, "bFixedTilePoolSize"); set => Native.SetPropBool(Pointer, "bFixedTilePoolSize", value); }
        public int TilePoolSize { get => GetAt<int>(0x408); set => SetAt(0x408, value); }
        public float TileSizeUU { get => GetAt<float>(0x40C); set => SetAt(0x40C, value); }
        public float CellSize { get => GetAt<float>(0x410); set => SetAt(0x410, value); }
        public float CellHeight { get => GetAt<float>(0x414); set => SetAt(0x414, value); }
        public float AgentRadius { get => GetAt<float>(0x418); set => SetAt(0x418, value); }
        public float AgentHeight { get => GetAt<float>(0x41C); set => SetAt(0x41C, value); }
        public float AgentMaxHeight { get => GetAt<float>(0x420); set => SetAt(0x420, value); }
        public float AgentMaxSlope { get => GetAt<float>(0x424); set => SetAt(0x424, value); }
        public float AgentMaxStepHeight { get => GetAt<float>(0x428); set => SetAt(0x428, value); }
        public float MinRegionArea { get => GetAt<float>(0x42C); set => SetAt(0x42C, value); }
        public float MergeRegionSize { get => GetAt<float>(0x430); set => SetAt(0x430, value); }
        public float MaxSimplificationError { get => GetAt<float>(0x434); set => SetAt(0x434, value); }
        public int MaxSimultaneousTileGenerationJobsCount { get => GetAt<int>(0x438); set => SetAt(0x438, value); }
        public int TileNumberHardLimit { get => GetAt<int>(0x43C); set => SetAt(0x43C, value); }
        public int PolyRefTileBits { get => GetAt<int>(0x440); set => SetAt(0x440, value); }
        public int PolyRefNavPolyBits { get => GetAt<int>(0x444); set => SetAt(0x444, value); }
        public int PolyRefSaltBits { get => GetAt<int>(0x448); set => SetAt(0x448, value); }
        public Vector NavMeshOriginOffset => new Vector(AddrOf(0x44C));
        public float DefaultDrawDistance { get => GetAt<float>(0x458); set => SetAt(0x458, value); }
        public float DefaultMaxSearchNodes { get => GetAt<float>(0x45C); set => SetAt(0x45C, value); }
        public float DefaultMaxHierarchicalSearchNodes { get => GetAt<float>(0x460); set => SetAt(0x460, value); }
        public byte RegionPartitioning { get => GetAt<byte>(0x464); set => SetAt(0x464, value); }
        public byte LayerPartitioning { get => GetAt<byte>(0x465); set => SetAt(0x465, value); }
        public int RegionChunkSplits { get => GetAt<int>(0x468); set => SetAt(0x468, value); }
        public int LayerChunkSplits { get => GetAt<int>(0x46C); set => SetAt(0x46C, value); }
        public bool bSortNavigationAreasByCost { get => Native.GetPropBool(Pointer, "bSortNavigationAreasByCost"); set => Native.SetPropBool(Pointer, "bSortNavigationAreasByCost", value); }
        public bool bPerformVoxelFiltering { get => Native.GetPropBool(Pointer, "bPerformVoxelFiltering"); set => Native.SetPropBool(Pointer, "bPerformVoxelFiltering", value); }
        public bool bMarkLowHeightAreas { get => Native.GetPropBool(Pointer, "bMarkLowHeightAreas"); set => Native.SetPropBool(Pointer, "bMarkLowHeightAreas", value); }
        public bool bFilterLowSpanSequences { get => Native.GetPropBool(Pointer, "bFilterLowSpanSequences"); set => Native.SetPropBool(Pointer, "bFilterLowSpanSequences", value); }
        public bool bFilterLowSpanFromTileCache { get => Native.GetPropBool(Pointer, "bFilterLowSpanFromTileCache"); set => Native.SetPropBool(Pointer, "bFilterLowSpanFromTileCache", value); }
        public bool bDoFullyAsyncNavDataGathering { get => Native.GetPropBool(Pointer, "bDoFullyAsyncNavDataGathering"); set => Native.SetPropBool(Pointer, "bDoFullyAsyncNavDataGathering", value); }
        public bool bUseBetterOffsetsFromCorners { get => Native.GetPropBool(Pointer, "bUseBetterOffsetsFromCorners"); set => Native.SetPropBool(Pointer, "bUseBetterOffsetsFromCorners", value); }
        public bool bStoreEmptyTileLayers { get => Native.GetPropBool(Pointer, "bStoreEmptyTileLayers"); set => Native.SetPropBool(Pointer, "bStoreEmptyTileLayers", value); }
        public bool bUseVirtualFilters { get => Native.GetPropBool(Pointer, "bUseVirtualFilters"); set => Native.SetPropBool(Pointer, "bUseVirtualFilters", value); }
        public bool bAllowNavLinkAsPathEnd { get => Native.GetPropBool(Pointer, "bAllowNavLinkAsPathEnd"); set => Native.SetPropBool(Pointer, "bAllowNavLinkAsPathEnd", value); }
        public bool bUseVoxelCache { get => Native.GetPropBool(Pointer, "bUseVoxelCache"); set => Native.SetPropBool(Pointer, "bUseVoxelCache", value); }
        public float TileSetUpdateInterval { get => GetAt<float>(0x474); set => SetAt(0x474, value); }
        public float HeuristicScale { get => GetAt<float>(0x478); set => SetAt(0x478, value); }
        public float VerticalDeviationFromGroundCompensation { get => GetAt<float>(0x47C); set => SetAt(0x47C, value); }
        /// <summary>[Native] thunk RVA 0x93E5F8C — hookable via Hooks.InstallAt(NativeFunc_K2_ReplaceAreaInTileBounds).</summary>
        public static global::System.IntPtr NativeFunc_K2_ReplaceAreaInTileBounds => Memory.ModuleBase() + 0x93E5F8C;
        public bool K2_ReplaceAreaInTileBounds(global::System.IntPtr Bounds, NavArea OldArea, NavArea NewArea, bool ReplaceLinks)
        {
            var __pb = new ParamBuffer(50);
            __pb.Set<global::System.IntPtr>(0x0, Bounds);
            __pb.SetObject(0x20, OldArea);
            __pb.SetObject(0x28, NewArea);
            __pb.Set<byte>(0x30, (byte)(ReplaceLinks?1:0));
            CallRaw("K2_ReplaceAreaInTileBounds", __pb.Bytes);
            return __pb.Get<byte>(0x31) != 0;
        }
    }

    public class RecastNavMeshDataChunk : NavigationDataChunk
    {
        public const string UeClassName = "RecastNavMeshDataChunk";
        public RecastNavMeshDataChunk(global::System.IntPtr ptr) : base(ptr) {}
        public static new RecastNavMeshDataChunk FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new RecastNavMeshDataChunk(p);
        public static RecastNavMeshDataChunk FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RecastNavMeshDataChunk(o.Pointer); }
        public static RecastNavMeshDataChunk[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RecastNavMeshDataChunk[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RecastNavMeshDataChunk(a[i].Pointer); return r; }
    }

}
