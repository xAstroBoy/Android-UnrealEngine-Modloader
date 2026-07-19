// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/VariantManagerContent
using System;

namespace UEModLoader.Game
{
    public enum EPropertyValueCategory
    {
        Undefined = 0,
        Generic = 1,
        RelativeLocation = 2,
        RelativeRotation = 4,
        RelativeScale3D = 8,
        Visibility = 16,
        Material = 32,
        Color = 64,
        Option = 128,
    }

    public class FunctionCaller : StructProxy
    {
        public FunctionCaller(global::System.IntPtr ptr) : base(ptr) {}
        public string FunctionName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName FunctionName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
    }

    public class CapturedPropSegment : StructProxy
    {
        public CapturedPropSegment(global::System.IntPtr ptr) : base(ptr) {}
        public string PropertyName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public int PropertyIndex { get => GetAt<int>(0x10); set => SetAt(0x10, value); }
        public string ComponentName => Native.ReadFStringAt(AddrOf(0x18)); // FString
    }

    public class LevelVariantSets : Object
    {
        public const string UeClassName = "LevelVariantSets";
        public LevelVariantSets(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelVariantSets FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelVariantSets(p);
        public static LevelVariantSets FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelVariantSets(o.Pointer); }
        public static LevelVariantSets[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelVariantSets[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelVariantSets(a[i].Pointer); return r; }
        public Object DirectorClass { get { var __p = GetAt<global::System.IntPtr>(0x28); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x28, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> VariantSets => new TArray<global::System.IntPtr>(AddrOf(0x30)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x573CF4C — hookable via Hooks.InstallAt(NativeFunc_GetVariantSetByName).</summary>
        public static global::System.IntPtr NativeFunc_GetVariantSetByName => Memory.ModuleBase() + 0x573CF4C;
        public VariantSet GetVariantSetByName(global::System.IntPtr VariantSetName)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VariantSetName);
            CallRaw("GetVariantSetByName", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new VariantSet(__p); }
        }
        /// <summary>[Native] thunk RVA 0x573D054 — hookable via Hooks.InstallAt(NativeFunc_GetVariantSet).</summary>
        public static global::System.IntPtr NativeFunc_GetVariantSet => Memory.ModuleBase() + 0x573D054;
        public VariantSet GetVariantSet(int VariantSetIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, VariantSetIndex);
            CallRaw("GetVariantSet", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new VariantSet(__p); }
        }
        /// <summary>[Native] thunk RVA 0x573D100 — hookable via Hooks.InstallAt(NativeFunc_GetNumVariantSets).</summary>
        public static global::System.IntPtr NativeFunc_GetNumVariantSets => Memory.ModuleBase() + 0x573D100;
        public int GetNumVariantSets()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumVariantSets", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
    }

    public class LevelVariantSetsActor : Actor
    {
        public const string UeClassName = "LevelVariantSetsActor";
        public LevelVariantSetsActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelVariantSetsActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelVariantSetsActor(p);
        public static LevelVariantSetsActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelVariantSetsActor(o.Pointer); }
        public static LevelVariantSetsActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelVariantSetsActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelVariantSetsActor(a[i].Pointer); return r; }
        public SoftObjectPath LevelVariantSets => new SoftObjectPath(AddrOf(0x220));
        /// <summary>[Native] thunk RVA 0x573DAF4 — hookable via Hooks.InstallAt(NativeFunc_SwitchOnVariantByName).</summary>
        public static global::System.IntPtr NativeFunc_SwitchOnVariantByName => Memory.ModuleBase() + 0x573DAF4;
        public bool SwitchOnVariantByName(global::System.IntPtr VariantSetName, global::System.IntPtr VariantName)
        {
            var __pb = new ParamBuffer(33);
            __pb.Set<global::System.IntPtr>(0x0, VariantSetName);
            __pb.Set<global::System.IntPtr>(0x10, VariantName);
            CallRaw("SwitchOnVariantByName", __pb.Bytes);
            return __pb.Get<byte>(0x20) != 0;
        }
        /// <summary>[Native] thunk RVA 0x573DA04 — hookable via Hooks.InstallAt(NativeFunc_SwitchOnVariantByIndex).</summary>
        public static global::System.IntPtr NativeFunc_SwitchOnVariantByIndex => Memory.ModuleBase() + 0x573DA04;
        public bool SwitchOnVariantByIndex(int VariantSetIndex, int VariantIndex)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, VariantSetIndex);
            __pb.Set(0x4, VariantIndex);
            CallRaw("SwitchOnVariantByIndex", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x573DC98 — hookable via Hooks.InstallAt(NativeFunc_SetLevelVariantSets).</summary>
        public static global::System.IntPtr NativeFunc_SetLevelVariantSets => Memory.ModuleBase() + 0x573DC98;
        public void SetLevelVariantSets(LevelVariantSets InVariantSets)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, InVariantSets);
            CallRaw("SetLevelVariantSets", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x573DD3C — hookable via Hooks.InstallAt(NativeFunc_GetLevelVariantSets).</summary>
        public static global::System.IntPtr NativeFunc_GetLevelVariantSets => Memory.ModuleBase() + 0x573DD3C;
        public LevelVariantSets GetLevelVariantSets(bool bLoad)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<byte>(0x0, (byte)(bLoad?1:0));
            CallRaw("GetLevelVariantSets", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new LevelVariantSets(__p); }
        }
    }

    public class LevelVariantSetsFunctionDirector : Object
    {
        public const string UeClassName = "LevelVariantSetsFunctionDirector";
        public LevelVariantSetsFunctionDirector(global::System.IntPtr ptr) : base(ptr) {}
        public static new LevelVariantSetsFunctionDirector FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LevelVariantSetsFunctionDirector(p);
        public static LevelVariantSetsFunctionDirector FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LevelVariantSetsFunctionDirector(o.Pointer); }
        public static LevelVariantSetsFunctionDirector[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LevelVariantSetsFunctionDirector[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LevelVariantSetsFunctionDirector(a[i].Pointer); return r; }
    }

    public class PropertyValue : Object
    {
        public const string UeClassName = "PropertyValue";
        public PropertyValue(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropertyValue FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropertyValue(p);
        public static PropertyValue FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropertyValue(o.Pointer); }
        public static PropertyValue[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropertyValue[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropertyValue(a[i].Pointer); return r; }
        public TArray<global::System.IntPtr> Properties => new TArray<global::System.IntPtr>(AddrOf(0x88)); // TArray<FFieldPath>
        public TArray<global::System.IntPtr> PropertyIndices => new TArray<global::System.IntPtr>(AddrOf(0x98)); // TArray<int32>
        public TArray<global::System.IntPtr> CapturedPropSegments => new TArray<global::System.IntPtr>(AddrOf(0xA8)); // TArray<struct>
        public string FullDisplayString => Native.GetPropString(Pointer, "FullDisplayString"); // FString
        public string PropertySetterName => Native.GetPropName(Pointer, "PropertySetterName"); // FName
        public FName PropertySetterName_Raw { get => GetAt<FName>(0xC8); set => SetAt(0xC8, value); }
        public global::System.IntPtr PropertySetterParameterDefaults => AddrOf(0xD0); // 
        public bool bHasRecordedData { get => Native.GetPropBool(Pointer, "bHasRecordedData"); set => Native.SetPropBool(Pointer, "bHasRecordedData", value); }
        public Object LeafPropertyClass { get { var __p = GetAt<global::System.IntPtr>(0x128); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x128, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> ValueBytes => new TArray<global::System.IntPtr>(AddrOf(0x138)); // TArray<uint8>
        public EPropertyValueCategory PropCategory { get => (EPropertyValueCategory)GetAt<byte>(0x148); set => SetAt(0x148, (byte)value); }
        /// <summary>[Native] thunk RVA 0x573F0EC — hookable via Hooks.InstallAt(NativeFunc_HasRecordedData).</summary>
        public static global::System.IntPtr NativeFunc_HasRecordedData => Memory.ModuleBase() + 0x573F0EC;
        public bool HasRecordedData()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("HasRecordedData", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x573F1A8 — hookable via Hooks.InstallAt(NativeFunc_GetPropertyTooltip).</summary>
        public static global::System.IntPtr NativeFunc_GetPropertyTooltip => Memory.ModuleBase() + 0x573F1A8;
        public global::System.IntPtr GetPropertyTooltip()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetPropertyTooltip", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x573F124 — hookable via Hooks.InstallAt(NativeFunc_GetFullDisplayString).</summary>
        public static global::System.IntPtr NativeFunc_GetFullDisplayString => Memory.ModuleBase() + 0x573F124;
        public global::System.IntPtr GetFullDisplayString()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetFullDisplayString", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
    }

    public class PropertyValueTransform : PropertyValue
    {
        public const string UeClassName = "PropertyValueTransform";
        public PropertyValueTransform(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropertyValueTransform FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropertyValueTransform(p);
        public static PropertyValueTransform FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropertyValueTransform(o.Pointer); }
        public static PropertyValueTransform[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropertyValueTransform[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropertyValueTransform(a[i].Pointer); return r; }
    }

    public class PropertyValueVisibility : PropertyValue
    {
        public const string UeClassName = "PropertyValueVisibility";
        public PropertyValueVisibility(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropertyValueVisibility FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropertyValueVisibility(p);
        public static PropertyValueVisibility FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropertyValueVisibility(o.Pointer); }
        public static PropertyValueVisibility[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropertyValueVisibility[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropertyValueVisibility(a[i].Pointer); return r; }
    }

    public class PropertyValueColor : PropertyValue
    {
        public const string UeClassName = "PropertyValueColor";
        public PropertyValueColor(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropertyValueColor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropertyValueColor(p);
        public static PropertyValueColor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropertyValueColor(o.Pointer); }
        public static PropertyValueColor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropertyValueColor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropertyValueColor(a[i].Pointer); return r; }
    }

    public class PropertyValueMaterial : PropertyValue
    {
        public const string UeClassName = "PropertyValueMaterial";
        public PropertyValueMaterial(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropertyValueMaterial FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropertyValueMaterial(p);
        public static PropertyValueMaterial FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropertyValueMaterial(o.Pointer); }
        public static PropertyValueMaterial[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropertyValueMaterial[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropertyValueMaterial(a[i].Pointer); return r; }
    }

    public class PropertyValueOption : PropertyValue
    {
        public const string UeClassName = "PropertyValueOption";
        public PropertyValueOption(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropertyValueOption FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropertyValueOption(p);
        public static PropertyValueOption FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropertyValueOption(o.Pointer); }
        public static PropertyValueOption[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropertyValueOption[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropertyValueOption(a[i].Pointer); return r; }
    }

    public class PropertyValueSoftObject : PropertyValue
    {
        public const string UeClassName = "PropertyValueSoftObject";
        public PropertyValueSoftObject(global::System.IntPtr ptr) : base(ptr) {}
        public static new PropertyValueSoftObject FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new PropertyValueSoftObject(p);
        public static PropertyValueSoftObject FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new PropertyValueSoftObject(o.Pointer); }
        public static PropertyValueSoftObject[] All() { var a = UObject.FindAllOf(UeClassName); var r = new PropertyValueSoftObject[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new PropertyValueSoftObject(a[i].Pointer); return r; }
    }

    public class SwitchActor : Actor
    {
        public const string UeClassName = "SwitchActor";
        public SwitchActor(global::System.IntPtr ptr) : base(ptr) {}
        public static new SwitchActor FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new SwitchActor(p);
        public static SwitchActor FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new SwitchActor(o.Pointer); }
        public static SwitchActor[] All() { var a = UObject.FindAllOf(UeClassName); var r = new SwitchActor[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new SwitchActor(a[i].Pointer); return r; }
        public SceneComponent SceneComponent { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int LastSelectedOption { get => GetAt<int>(0x240); set => SetAt(0x240, value); }
        /// <summary>[Native] thunk RVA 0x5742724 — hookable via Hooks.InstallAt(NativeFunc_SelectOption).</summary>
        public static global::System.IntPtr NativeFunc_SelectOption => Memory.ModuleBase() + 0x5742724;
        public void SelectOption(int OptionIndex)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, OptionIndex);
            CallRaw("SelectOption", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x57427C8 — hookable via Hooks.InstallAt(NativeFunc_GetSelectedOption).</summary>
        public static global::System.IntPtr NativeFunc_GetSelectedOption => Memory.ModuleBase() + 0x57427C8;
        public int GetSelectedOption()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetSelectedOption", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x57427FC — hookable via Hooks.InstallAt(NativeFunc_GetOptions).</summary>
        public static global::System.IntPtr NativeFunc_GetOptions => Memory.ModuleBase() + 0x57427FC;
        public global::System.IntPtr GetOptions()
        {
            var __pb = new ParamBuffer(16);
            CallRaw("GetOptions", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
    }

    public class Variant : Object
    {
        public const string UeClassName = "Variant";
        public Variant(global::System.IntPtr ptr) : base(ptr) {}
        public static new Variant FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new Variant(p);
        public static Variant FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new Variant(o.Pointer); }
        public static Variant[] All() { var a = UObject.FindAllOf(UeClassName); var r = new Variant[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new Variant(a[i].Pointer); return r; }
        public global::System.IntPtr DisplayText => AddrOf(0x28); // 
        public TArray<global::System.IntPtr> ObjectBindings => new TArray<global::System.IntPtr>(AddrOf(0x58)); // TArray<UObject*>
        public Texture2D Thumbnail { get { var __p = GetAt<global::System.IntPtr>(0x68); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); } set => SetAt(0x68, value?.Pointer ?? global::System.IntPtr.Zero); }
        /// <summary>[Native] thunk RVA 0x5743214 — hookable via Hooks.InstallAt(NativeFunc_SwitchOn).</summary>
        public static global::System.IntPtr NativeFunc_SwitchOn => Memory.ModuleBase() + 0x5743214;
        public void SwitchOn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SwitchOn", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x57433E0 — hookable via Hooks.InstallAt(NativeFunc_SetDisplayText).</summary>
        public static global::System.IntPtr NativeFunc_SetDisplayText => Memory.ModuleBase() + 0x57433E0;
        public void SetDisplayText(global::System.IntPtr NewDisplayText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, NewDisplayText);
            CallRaw("SetDisplayText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x57431DC — hookable via Hooks.InstallAt(NativeFunc_IsActive).</summary>
        public static global::System.IntPtr NativeFunc_IsActive => Memory.ModuleBase() + 0x57431DC;
        public bool IsActive()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsActive", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        /// <summary>[Native] thunk RVA 0x57431A8 — hookable via Hooks.InstallAt(NativeFunc_GetThumbnail).</summary>
        public static global::System.IntPtr NativeFunc_GetThumbnail => Memory.ModuleBase() + 0x57431A8;
        public Texture2D GetThumbnail()
        {
            var __pb = new ParamBuffer(8);
            CallRaw("GetThumbnail", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x0); return __p==global::System.IntPtr.Zero?null:new Texture2D(__p); }
        }
        /// <summary>[Native] thunk RVA 0x57432D4 — hookable via Hooks.InstallAt(NativeFunc_GetNumActors).</summary>
        public static global::System.IntPtr NativeFunc_GetNumActors => Memory.ModuleBase() + 0x57432D4;
        public int GetNumActors()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumActors", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5743308 — hookable via Hooks.InstallAt(NativeFunc_GetDisplayText).</summary>
        public static global::System.IntPtr NativeFunc_GetDisplayText => Memory.ModuleBase() + 0x5743308;
        public global::System.IntPtr GetDisplayText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetDisplayText", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5743228 — hookable via Hooks.InstallAt(NativeFunc_GetActor).</summary>
        public static global::System.IntPtr NativeFunc_GetActor => Memory.ModuleBase() + 0x5743228;
        public Actor GetActor(int ActorIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, ActorIndex);
            CallRaw("GetActor", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new Actor(__p); }
        }
    }

    public class VariantObjectBinding : Object
    {
        public const string UeClassName = "VariantObjectBinding";
        public VariantObjectBinding(global::System.IntPtr ptr) : base(ptr) {}
        public static new VariantObjectBinding FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VariantObjectBinding(p);
        public static VariantObjectBinding FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VariantObjectBinding(o.Pointer); }
        public static VariantObjectBinding[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VariantObjectBinding[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VariantObjectBinding(a[i].Pointer); return r; }
        public string CachedActorLabel => Native.GetPropString(Pointer, "CachedActorLabel"); // FString
        public SoftObjectPath ObjectPtr => new SoftObjectPath(AddrOf(0x38));
        public Object LazyObjectPtr { get { var __p = GetAt<global::System.IntPtr>(0x50); return __p==global::System.IntPtr.Zero?null:new Object(__p); } set => SetAt(0x50, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> CapturedProperties => new TArray<global::System.IntPtr>(AddrOf(0x70)); // TArray<UObject*>
        public TArray<global::System.IntPtr> FunctionCallers => new TArray<global::System.IntPtr>(AddrOf(0x80)); // TArray<struct>
    }

    public class VariantSet : Object
    {
        public const string UeClassName = "VariantSet";
        public VariantSet(global::System.IntPtr ptr) : base(ptr) {}
        public static new VariantSet FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VariantSet(p);
        public static VariantSet FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VariantSet(o.Pointer); }
        public static VariantSet[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VariantSet[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VariantSet(a[i].Pointer); return r; }
        public global::System.IntPtr DisplayText => AddrOf(0x28); // 
        public bool bExpanded { get => Native.GetPropBool(Pointer, "bExpanded"); set => Native.SetPropBool(Pointer, "bExpanded", value); }
        public TArray<global::System.IntPtr> Variants => new TArray<global::System.IntPtr>(AddrOf(0x60)); // TArray<UObject*>
        /// <summary>[Native] thunk RVA 0x5744E90 — hookable via Hooks.InstallAt(NativeFunc_SetDisplayText).</summary>
        public static global::System.IntPtr NativeFunc_SetDisplayText => Memory.ModuleBase() + 0x5744E90;
        public void SetDisplayText(global::System.IntPtr NewDisplayText)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, NewDisplayText);
            CallRaw("SetDisplayText", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x5744BD0 — hookable via Hooks.InstallAt(NativeFunc_GetVariantByName).</summary>
        public static global::System.IntPtr NativeFunc_GetVariantByName => Memory.ModuleBase() + 0x5744BD0;
        public Variant GetVariantByName(global::System.IntPtr VariantName)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<global::System.IntPtr>(0x0, VariantName);
            CallRaw("GetVariantByName", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x10); return __p==global::System.IntPtr.Zero?null:new Variant(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5744CD8 — hookable via Hooks.InstallAt(NativeFunc_GetVariant).</summary>
        public static global::System.IntPtr NativeFunc_GetVariant => Memory.ModuleBase() + 0x5744CD8;
        public Variant GetVariant(int VariantIndex)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set(0x0, VariantIndex);
            CallRaw("GetVariant", __pb.Bytes);
            { var __p = __pb.Get<global::System.IntPtr>(0x8); return __p==global::System.IntPtr.Zero?null:new Variant(__p); }
        }
        /// <summary>[Native] thunk RVA 0x5744D84 — hookable via Hooks.InstallAt(NativeFunc_GetNumVariants).</summary>
        public static global::System.IntPtr NativeFunc_GetNumVariants => Memory.ModuleBase() + 0x5744D84;
        public int GetNumVariants()
        {
            var __pb = new ParamBuffer(4);
            CallRaw("GetNumVariants", __pb.Bytes);
            return __pb.Get<int>(0x0);
        }
        /// <summary>[Native] thunk RVA 0x5744DB8 — hookable via Hooks.InstallAt(NativeFunc_GetDisplayText).</summary>
        public static global::System.IntPtr NativeFunc_GetDisplayText => Memory.ModuleBase() + 0x5744DB8;
        public global::System.IntPtr GetDisplayText()
        {
            var __pb = new ParamBuffer(24);
            CallRaw("GetDisplayText", __pb.Bytes);
            return __pb.Get<global::System.IntPtr>(0x0);
        }
    }

}
