// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/GameplayTags
using System;

namespace UEModLoader.Game
{
    public enum EGameplayTagQueryExprType
    {
        Undefined = 0,
        AnyTagsMatch = 1,
        AllTagsMatch = 2,
        NoTagsMatch = 3,
        AnyExprMatch = 4,
        AllExprMatch = 5,
        NoExprMatch = 6,
    }

    public enum EGameplayContainerMatchType
    {
        Any = 0,
        All = 1,
    }

    public enum EGameplayTagMatchType
    {
        Explicit = 0,
        IncludeParentTags = 1,
    }

    public enum EGameplayTagSelectionType
    {
        None = 0,
        NonRestrictedOnly = 1,
        RestrictedOnly = 2,
        All = 3,
    }

    public enum EGameplayTagSourceType
    {
        Native = 0,
        DefaultTagList = 1,
        TagList = 2,
        RestrictedTagList = 3,
        DataTable = 4,
        Invalid = 5,
    }

    public class GameplayTagQuery : StructProxy
    {
        public GameplayTagQuery(System.IntPtr ptr) : base(ptr) {}
        public int TokenStreamVersion { get => GetAt<int>(0x0); set => SetAt(0x0, value); }
        public TArray<System.IntPtr> TagDictionary => new TArray<System.IntPtr>(AddrOf(0x8)); // TArray<struct>
        public TArray<System.IntPtr> QueryTokenStream => new TArray<System.IntPtr>(AddrOf(0x18)); // TArray<uint8>
        public string UserDescription => Native.ReadFStringAt(AddrOf(0x28)); // FString
        public string AutoDescription => Native.ReadFStringAt(AddrOf(0x38)); // FString
    }

    public class GameplayTag : StructProxy
    {
        public GameplayTag(System.IntPtr ptr) : base(ptr) {}
        public string TagName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName TagName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
    }

    public class GameplayTagCreationWidgetHelper : StructProxy
    {
        public GameplayTagCreationWidgetHelper(System.IntPtr ptr) : base(ptr) {}
    }

    public class GameplayTagReferenceHelper : StructProxy
    {
        public GameplayTagReferenceHelper(System.IntPtr ptr) : base(ptr) {}
    }

    public class GameplayTagContainer : StructProxy
    {
        public GameplayTagContainer(System.IntPtr ptr) : base(ptr) {}
        public TArray<System.IntPtr> GameplayTags => new TArray<System.IntPtr>(AddrOf(0x0)); // TArray<struct>
        public TArray<System.IntPtr> ParentTags => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<struct>
    }

    public class GameplayTagNode : StructProxy
    {
        public GameplayTagNode(System.IntPtr ptr) : base(ptr) {}
    }

    public class GameplayTagSource : StructProxy
    {
        public GameplayTagSource(System.IntPtr ptr) : base(ptr) {}
        public string SourceName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName SourceName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public EGameplayTagSourceType SourceType { get => (EGameplayTagSourceType)GetAt<byte>(0x8); set => SetAt(0x8, (byte)value); }
        public GameplayTagsList SourceTagList { get { var __p = GetAt<System.IntPtr>(0x10); return __p==System.IntPtr.Zero?null:new GameplayTagsList(__p); } set => SetAt(0x10, value?.Pointer ?? System.IntPtr.Zero); }
        public RestrictedGameplayTagsList SourceRestrictedTagList { get { var __p = GetAt<System.IntPtr>(0x18); return __p==System.IntPtr.Zero?null:new RestrictedGameplayTagsList(__p); } set => SetAt(0x18, value?.Pointer ?? System.IntPtr.Zero); }
    }

    public class GameplayTagTableRow : StructProxy
    {
        public GameplayTagTableRow(System.IntPtr ptr) : base(ptr) {}
        public string Tag => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName Tag_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
        public string DevComment => Native.ReadFStringAt(AddrOf(0x10)); // FString
    }

    public class RestrictedGameplayTagTableRow : StructProxy
    {
        public RestrictedGameplayTagTableRow(System.IntPtr ptr) : base(ptr) {}
        public bool bAllowNonRestrictedChildren { get => (GetAt<byte>(0x20) & 0xFF) != 0; set { var __b = GetAt<byte>(0x20); SetAt(0x20, (byte)(value ? (__b | 0xFF) : (__b & ~0xFF))); } }
    }

    public class RestrictedConfigInfo : StructProxy
    {
        public RestrictedConfigInfo(System.IntPtr ptr) : base(ptr) {}
        public string RestrictedConfigName => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public TArray<System.IntPtr> Owners => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<FString>
    }

    public class GameplayTagCategoryRemap : StructProxy
    {
        public GameplayTagCategoryRemap(System.IntPtr ptr) : base(ptr) {}
        public string BaseCategory => Native.ReadFStringAt(AddrOf(0x0)); // FString
        public TArray<System.IntPtr> RemapCategories => new TArray<System.IntPtr>(AddrOf(0x10)); // TArray<FString>
    }

    public class GameplayTagRedirect : StructProxy
    {
        public GameplayTagRedirect(System.IntPtr ptr) : base(ptr) {}
        public string OldTagName => Native.FNameToString(GetAt<int>(0x0)); // FName
        public FName OldTagName_Raw { get => GetAt<FName>(0x0); set => SetAt(0x0, value); }
        public string NewTagName => Native.FNameToString(GetAt<int>(0x8)); // FName
        public FName NewTagName_Raw { get => GetAt<FName>(0x8); set => SetAt(0x8, value); }
    }

    public class BlueprintGameplayTagLibrary : BlueprintFunctionLibrary
    {
        public const string UeClassName = "BlueprintGameplayTagLibrary";
        public BlueprintGameplayTagLibrary(System.IntPtr ptr) : base(ptr) {}
        public static new BlueprintGameplayTagLibrary FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BlueprintGameplayTagLibrary(p);
        public static BlueprintGameplayTagLibrary FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BlueprintGameplayTagLibrary(o.Pointer); }
        public static BlueprintGameplayTagLibrary[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BlueprintGameplayTagLibrary[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BlueprintGameplayTagLibrary(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7FE5F14 — hookable via Hooks.InstallAt(NativeFunc_RemoveGameplayTag).</summary>
        public static System.IntPtr NativeFunc_RemoveGameplayTag => Memory.ModuleBase() + 0x7FE5F14;
        public bool RemoveGameplayTag(GameplayTagContainer TagContainer, GameplayTag Tag)
        {
            var __pb = new ParamBuffer(41);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            __pb.Set<System.IntPtr>(0x20, Tag);
            CallRaw("RemoveGameplayTag", __pb.Bytes);
            return __pb.Get<byte>(0x28) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE52A8 — hookable via Hooks.InstallAt(NativeFunc_NotEqual_TagTag).</summary>
        public static System.IntPtr NativeFunc_NotEqual_TagTag => Memory.ModuleBase() + 0x7FE52A8;
        public bool NotEqual_TagTag(GameplayTag A, System.IntPtr B)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set<System.IntPtr>(0x8, B);
            CallRaw("NotEqual_TagTag", __pb.Bytes);
            return __pb.Get<byte>(0x18) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE5120 — hookable via Hooks.InstallAt(NativeFunc_NotEqual_TagContainerTagContainer).</summary>
        public static System.IntPtr NativeFunc_NotEqual_TagContainerTagContainer => Memory.ModuleBase() + 0x7FE5120;
        public bool NotEqual_TagContainerTagContainer(GameplayTagContainer A, System.IntPtr B)
        {
            var __pb = new ParamBuffer(49);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set<System.IntPtr>(0x20, B);
            CallRaw("NotEqual_TagContainerTagContainer", __pb.Bytes);
            return __pb.Get<byte>(0x30) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE5B60 — hookable via Hooks.InstallAt(NativeFunc_NotEqual_GameplayTagContainer).</summary>
        public static System.IntPtr NativeFunc_NotEqual_GameplayTagContainer => Memory.ModuleBase() + 0x7FE5B60;
        public bool NotEqual_GameplayTagContainer(GameplayTagContainer A, GameplayTagContainer B)
        {
            var __pb = new ParamBuffer(65);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set<System.IntPtr>(0x20, B);
            CallRaw("NotEqual_GameplayTagContainer", __pb.Bytes);
            return __pb.Get<byte>(0x40) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE6C7C — hookable via Hooks.InstallAt(NativeFunc_NotEqual_GameplayTag).</summary>
        public static System.IntPtr NativeFunc_NotEqual_GameplayTag => Memory.ModuleBase() + 0x7FE6C7C;
        public bool NotEqual_GameplayTag(GameplayTag A, GameplayTag B)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set<System.IntPtr>(0x8, B);
            CallRaw("NotEqual_GameplayTag", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE6FA4 — hookable via Hooks.InstallAt(NativeFunc_MatchesTag).</summary>
        public static System.IntPtr NativeFunc_MatchesTag => Memory.ModuleBase() + 0x7FE6FA4;
        public bool MatchesTag(GameplayTag TagOne, GameplayTag TagTwo, bool bExactMatch)
        {
            var __pb = new ParamBuffer(18);
            __pb.Set<System.IntPtr>(0x0, TagOne);
            __pb.Set<System.IntPtr>(0x8, TagTwo);
            __pb.Set<byte>(0x10, (byte)(bExactMatch?1:0));
            CallRaw("MatchesTag", __pb.Bytes);
            return __pb.Get<byte>(0x11) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE6E4C — hookable via Hooks.InstallAt(NativeFunc_MatchesAnyTags).</summary>
        public static System.IntPtr NativeFunc_MatchesAnyTags => Memory.ModuleBase() + 0x7FE6E4C;
        public bool MatchesAnyTags(GameplayTag TagOne, GameplayTagContainer OtherContainer, bool bExactMatch)
        {
            var __pb = new ParamBuffer(42);
            __pb.Set<System.IntPtr>(0x0, TagOne);
            __pb.Set<System.IntPtr>(0x8, OtherContainer);
            __pb.Set<byte>(0x28, (byte)(bExactMatch?1:0));
            CallRaw("MatchesAnyTags", __pb.Bytes);
            return __pb.Get<byte>(0x29) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE5A50 — hookable via Hooks.InstallAt(NativeFunc_MakeLiteralGameplayTagContainer).</summary>
        public static System.IntPtr NativeFunc_MakeLiteralGameplayTagContainer => Memory.ModuleBase() + 0x7FE5A50;
        public GameplayTagContainer MakeLiteralGameplayTagContainer(GameplayTagContainer Value)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, Value);
            CallRaw("MakeLiteralGameplayTagContainer", __pb.Bytes);
            return __pb.Get<GameplayTagContainer>(0x20);
        }
        /// <summary>[Native] thunk RVA 0x7FE6A7C — hookable via Hooks.InstallAt(NativeFunc_MakeLiteralGameplayTag).</summary>
        public static System.IntPtr NativeFunc_MakeLiteralGameplayTag => Memory.ModuleBase() + 0x7FE6A7C;
        public GameplayTag MakeLiteralGameplayTag(GameplayTag Value)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, Value);
            CallRaw("MakeLiteralGameplayTag", __pb.Bytes);
            return __pb.Get<GameplayTag>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7FE5630 — hookable via Hooks.InstallAt(NativeFunc_MakeGameplayTagQuery).</summary>
        public static System.IntPtr NativeFunc_MakeGameplayTagQuery => Memory.ModuleBase() + 0x7FE5630;
        public GameplayTagQuery MakeGameplayTagQuery(GameplayTagQuery TagQuery)
        {
            var __pb = new ParamBuffer(144);
            __pb.Set<System.IntPtr>(0x0, TagQuery);
            CallRaw("MakeGameplayTagQuery", __pb.Bytes);
            return __pb.Get<GameplayTagQuery>(0x48);
        }
        /// <summary>[Native] thunk RVA 0x7FE58A4 — hookable via Hooks.InstallAt(NativeFunc_MakeGameplayTagContainerFromTag).</summary>
        public static System.IntPtr NativeFunc_MakeGameplayTagContainerFromTag => Memory.ModuleBase() + 0x7FE58A4;
        public GameplayTagContainer MakeGameplayTagContainerFromTag(GameplayTag SingleTag)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, SingleTag);
            CallRaw("MakeGameplayTagContainerFromTag", __pb.Bytes);
            return __pb.Get<GameplayTagContainer>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7FE596C — hookable via Hooks.InstallAt(NativeFunc_MakeGameplayTagContainerFromArray).</summary>
        public static System.IntPtr NativeFunc_MakeGameplayTagContainerFromArray => Memory.ModuleBase() + 0x7FE596C;
        public GameplayTagContainer MakeGameplayTagContainerFromArray(System.IntPtr GameplayTags)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, GameplayTags);
            CallRaw("MakeGameplayTagContainerFromArray", __pb.Bytes);
            return __pb.Get<GameplayTagContainer>(0x10);
        }
        /// <summary>[Native] thunk RVA 0x7FE6440 — hookable via Hooks.InstallAt(NativeFunc_IsTagQueryEmpty).</summary>
        public static System.IntPtr NativeFunc_IsTagQueryEmpty => Memory.ModuleBase() + 0x7FE6440;
        public bool IsTagQueryEmpty(GameplayTagQuery TagQuery)
        {
            var __pb = new ParamBuffer(73);
            __pb.Set<System.IntPtr>(0x0, TagQuery);
            CallRaw("IsTagQueryEmpty", __pb.Bytes);
            return __pb.Get<byte>(0x48) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE6BD4 — hookable via Hooks.InstallAt(NativeFunc_IsGameplayTagValid).</summary>
        public static System.IntPtr NativeFunc_IsGameplayTagValid => Memory.ModuleBase() + 0x7FE6BD4;
        public bool IsGameplayTagValid(GameplayTag GameplayTag)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<System.IntPtr>(0x0, GameplayTag);
            CallRaw("IsGameplayTagValid", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE684C — hookable via Hooks.InstallAt(NativeFunc_HasTag).</summary>
        public static System.IntPtr NativeFunc_HasTag => Memory.ModuleBase() + 0x7FE684C;
        public bool HasTag(GameplayTagContainer TagContainer, GameplayTag Tag, bool bExactMatch)
        {
            var __pb = new ParamBuffer(42);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            __pb.Set<System.IntPtr>(0x20, Tag);
            __pb.Set<byte>(0x28, (byte)(bExactMatch?1:0));
            CallRaw("HasTag", __pb.Bytes);
            return __pb.Get<byte>(0x29) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE66BC — hookable via Hooks.InstallAt(NativeFunc_HasAnyTags).</summary>
        public static System.IntPtr NativeFunc_HasAnyTags => Memory.ModuleBase() + 0x7FE66BC;
        public bool HasAnyTags(GameplayTagContainer TagContainer, GameplayTagContainer OtherContainer, bool bExactMatch)
        {
            var __pb = new ParamBuffer(66);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            __pb.Set<System.IntPtr>(0x20, OtherContainer);
            __pb.Set<byte>(0x40, (byte)(bExactMatch?1:0));
            CallRaw("HasAnyTags", __pb.Bytes);
            return __pb.Get<byte>(0x41) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE652C — hookable via Hooks.InstallAt(NativeFunc_HasAllTags).</summary>
        public static System.IntPtr NativeFunc_HasAllTags => Memory.ModuleBase() + 0x7FE652C;
        public bool HasAllTags(GameplayTagContainer TagContainer, GameplayTagContainer OtherContainer, bool bExactMatch)
        {
            var __pb = new ParamBuffer(66);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            __pb.Set<System.IntPtr>(0x20, OtherContainer);
            __pb.Set<byte>(0x40, (byte)(bExactMatch?1:0));
            CallRaw("HasAllTags", __pb.Bytes);
            return __pb.Get<byte>(0x41) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE5500 — hookable via Hooks.InstallAt(NativeFunc_HasAllMatchingGameplayTags).</summary>
        public static System.IntPtr NativeFunc_HasAllMatchingGameplayTags => Memory.ModuleBase() + 0x7FE5500;
        public bool HasAllMatchingGameplayTags(UObject TagContainerInterface, GameplayTagContainer OtherContainer)
        {
            var __pb = new ParamBuffer(49);
            __pb.SetObject(0x0, TagContainerInterface);
            __pb.Set<System.IntPtr>(0x10, OtherContainer);
            CallRaw("HasAllMatchingGameplayTags", __pb.Bytes);
            return __pb.Get<byte>(0x30) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE6B20 — hookable via Hooks.InstallAt(NativeFunc_GetTagName).</summary>
        public static System.IntPtr NativeFunc_GetTagName => Memory.ModuleBase() + 0x7FE6B20;
        public FName GetTagName(GameplayTag GameplayTag)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<System.IntPtr>(0x0, GameplayTag);
            CallRaw("GetTagName", __pb.Bytes);
            return __pb.Get<FName>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7FE69AC — hookable via Hooks.InstallAt(NativeFunc_GetNumGameplayTagsInContainer).</summary>
        public static System.IntPtr NativeFunc_GetNumGameplayTagsInContainer => Memory.ModuleBase() + 0x7FE69AC;
        public int GetNumGameplayTagsInContainer(GameplayTagContainer TagContainer)
        {
            var __pb = new ParamBuffer(36);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            CallRaw("GetNumGameplayTagsInContainer", __pb.Bytes);
            return __pb.Get<int>(0x20);
        }
        /// <summary>[Native] thunk RVA 0x7FE500C — hookable via Hooks.InstallAt(NativeFunc_GetDebugStringFromGameplayTagContainer).</summary>
        public static System.IntPtr NativeFunc_GetDebugStringFromGameplayTagContainer => Memory.ModuleBase() + 0x7FE500C;
        public System.IntPtr GetDebugStringFromGameplayTagContainer(GameplayTagContainer TagContainer)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            CallRaw("GetDebugStringFromGameplayTagContainer", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x20);
        }
        /// <summary>[Native] thunk RVA 0x7FE4F1C — hookable via Hooks.InstallAt(NativeFunc_GetDebugStringFromGameplayTag).</summary>
        public static System.IntPtr NativeFunc_GetDebugStringFromGameplayTag => Memory.ModuleBase() + 0x7FE4F1C;
        public System.IntPtr GetDebugStringFromGameplayTag(GameplayTag GameplayTag)
        {
            var __pb = new ParamBuffer(24);
            __pb.Set<System.IntPtr>(0x0, GameplayTag);
            CallRaw("GetDebugStringFromGameplayTag", __pb.Bytes);
            return __pb.Get<System.IntPtr>(0x8);
        }
        /// <summary>[Native] thunk RVA 0x7FE6130 — hookable via Hooks.InstallAt(NativeFunc_GetAllActorsOfClassMatchingTagQuery).</summary>
        public static System.IntPtr NativeFunc_GetAllActorsOfClassMatchingTagQuery => Memory.ModuleBase() + 0x7FE6130;
        public void GetAllActorsOfClassMatchingTagQuery(Object WorldContextObject, Actor ActorClass, GameplayTagQuery GameplayTagQuery, System.IntPtr OutActors)
        {
            var __pb = new ParamBuffer(104);
            __pb.SetObject(0x0, WorldContextObject);
            __pb.SetObject(0x8, ActorClass);
            __pb.Set<System.IntPtr>(0x10, GameplayTagQuery);
            __pb.Set<System.IntPtr>(0x58, OutActors);
            CallRaw("GetAllActorsOfClassMatchingTagQuery", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FE5CA0 — hookable via Hooks.InstallAt(NativeFunc_EqualEqual_GameplayTagContainer).</summary>
        public static System.IntPtr NativeFunc_EqualEqual_GameplayTagContainer => Memory.ModuleBase() + 0x7FE5CA0;
        public bool EqualEqual_GameplayTagContainer(GameplayTagContainer A, GameplayTagContainer B)
        {
            var __pb = new ParamBuffer(65);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set<System.IntPtr>(0x20, B);
            CallRaw("EqualEqual_GameplayTagContainer", __pb.Bytes);
            return __pb.Get<byte>(0x40) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE6D64 — hookable via Hooks.InstallAt(NativeFunc_EqualEqual_GameplayTag).</summary>
        public static System.IntPtr NativeFunc_EqualEqual_GameplayTag => Memory.ModuleBase() + 0x7FE6D64;
        public bool EqualEqual_GameplayTag(GameplayTag A, GameplayTag B)
        {
            var __pb = new ParamBuffer(17);
            __pb.Set<System.IntPtr>(0x0, A);
            __pb.Set<System.IntPtr>(0x8, B);
            CallRaw("EqualEqual_GameplayTag", __pb.Bytes);
            return __pb.Get<byte>(0x10) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE53F4 — hookable via Hooks.InstallAt(NativeFunc_DoesTagAssetInterfaceHaveTag).</summary>
        public static System.IntPtr NativeFunc_DoesTagAssetInterfaceHaveTag => Memory.ModuleBase() + 0x7FE53F4;
        public bool DoesTagAssetInterfaceHaveTag(UObject TagContainerInterface, GameplayTag Tag)
        {
            var __pb = new ParamBuffer(25);
            __pb.SetObject(0x0, TagContainerInterface);
            __pb.Set<System.IntPtr>(0x10, Tag);
            CallRaw("DoesTagAssetInterfaceHaveTag", __pb.Bytes);
            return __pb.Get<byte>(0x18) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE62E8 — hookable via Hooks.InstallAt(NativeFunc_DoesContainerMatchTagQuery).</summary>
        public static System.IntPtr NativeFunc_DoesContainerMatchTagQuery => Memory.ModuleBase() + 0x7FE62E8;
        public bool DoesContainerMatchTagQuery(GameplayTagContainer TagContainer, GameplayTagQuery TagQuery)
        {
            var __pb = new ParamBuffer(105);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            __pb.Set<System.IntPtr>(0x20, TagQuery);
            CallRaw("DoesContainerMatchTagQuery", __pb.Bytes);
            return __pb.Get<byte>(0x68) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE5780 — hookable via Hooks.InstallAt(NativeFunc_BreakGameplayTagContainer).</summary>
        public static System.IntPtr NativeFunc_BreakGameplayTagContainer => Memory.ModuleBase() + 0x7FE5780;
        public void BreakGameplayTagContainer(GameplayTagContainer GameplayTagContainer, System.IntPtr GameplayTags)
        {
            var __pb = new ParamBuffer(48);
            __pb.Set<System.IntPtr>(0x0, GameplayTagContainer);
            __pb.Set<System.IntPtr>(0x20, GameplayTags);
            CallRaw("BreakGameplayTagContainer", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FE5DE0 — hookable via Hooks.InstallAt(NativeFunc_AppendGameplayTagContainers).</summary>
        public static System.IntPtr NativeFunc_AppendGameplayTagContainers => Memory.ModuleBase() + 0x7FE5DE0;
        public void AppendGameplayTagContainers(GameplayTagContainer InOutTagContainer, GameplayTagContainer InTagContainer)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<System.IntPtr>(0x0, InOutTagContainer);
            __pb.Set<System.IntPtr>(0x20, InTagContainer);
            CallRaw("AppendGameplayTagContainers", __pb.Bytes);
        }
        /// <summary>[Native] thunk RVA 0x7FE6028 — hookable via Hooks.InstallAt(NativeFunc_AddGameplayTag).</summary>
        public static System.IntPtr NativeFunc_AddGameplayTag => Memory.ModuleBase() + 0x7FE6028;
        public void AddGameplayTag(GameplayTagContainer TagContainer, GameplayTag Tag)
        {
            var __pb = new ParamBuffer(40);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            __pb.Set<System.IntPtr>(0x20, Tag);
            CallRaw("AddGameplayTag", __pb.Bytes);
        }
    }

    public class GameplayTagAssetInterface : Interface
    {
        public const string UeClassName = "GameplayTagAssetInterface";
        public GameplayTagAssetInterface(System.IntPtr ptr) : base(ptr) {}
        public static new GameplayTagAssetInterface FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GameplayTagAssetInterface(p);
        public static GameplayTagAssetInterface FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GameplayTagAssetInterface(o.Pointer); }
        public static GameplayTagAssetInterface[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GameplayTagAssetInterface[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GameplayTagAssetInterface(a[i].Pointer); return r; }
        /// <summary>[Native] thunk RVA 0x7FE847C — hookable via Hooks.InstallAt(NativeFunc_HasMatchingGameplayTag).</summary>
        public static System.IntPtr NativeFunc_HasMatchingGameplayTag => Memory.ModuleBase() + 0x7FE847C;
        public bool HasMatchingGameplayTag(GameplayTag TagToCheck)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<System.IntPtr>(0x0, TagToCheck);
            CallRaw("HasMatchingGameplayTag", __pb.Bytes);
            return __pb.Get<byte>(0x8) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE82B4 — hookable via Hooks.InstallAt(NativeFunc_HasAnyMatchingGameplayTags).</summary>
        public static System.IntPtr NativeFunc_HasAnyMatchingGameplayTags => Memory.ModuleBase() + 0x7FE82B4;
        public bool HasAnyMatchingGameplayTags(GameplayTagContainer TagContainer)
        {
            var __pb = new ParamBuffer(33);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            CallRaw("HasAnyMatchingGameplayTags", __pb.Bytes);
            return __pb.Get<byte>(0x20) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE8398 — hookable via Hooks.InstallAt(NativeFunc_HasAllMatchingGameplayTags).</summary>
        public static System.IntPtr NativeFunc_HasAllMatchingGameplayTags => Memory.ModuleBase() + 0x7FE8398;
        public bool HasAllMatchingGameplayTags(GameplayTagContainer TagContainer)
        {
            var __pb = new ParamBuffer(33);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            CallRaw("HasAllMatchingGameplayTags", __pb.Bytes);
            return __pb.Get<byte>(0x20) != 0;
        }
        /// <summary>[Native] thunk RVA 0x7FE8534 — hookable via Hooks.InstallAt(NativeFunc_GetOwnedGameplayTags).</summary>
        public static System.IntPtr NativeFunc_GetOwnedGameplayTags => Memory.ModuleBase() + 0x7FE8534;
        public void GetOwnedGameplayTags(GameplayTagContainer TagContainer)
        {
            var __pb = new ParamBuffer(32);
            __pb.Set<System.IntPtr>(0x0, TagContainer);
            CallRaw("GetOwnedGameplayTags", __pb.Bytes);
        }
    }

    public class EditableGameplayTagQuery : Object
    {
        public const string UeClassName = "EditableGameplayTagQuery";
        public EditableGameplayTagQuery(System.IntPtr ptr) : base(ptr) {}
        public static new EditableGameplayTagQuery FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableGameplayTagQuery(p);
        public static EditableGameplayTagQuery FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableGameplayTagQuery(o.Pointer); }
        public static EditableGameplayTagQuery[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableGameplayTagQuery[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableGameplayTagQuery(a[i].Pointer); return r; }
        public string UserDescription => Native.GetPropString(Pointer, "UserDescription"); // FString
        public EditableGameplayTagQueryExpression RootExpression { get { var __p = GetAt<System.IntPtr>(0x48); return __p==System.IntPtr.Zero?null:new EditableGameplayTagQueryExpression(__p); } set => SetAt(0x48, value?.Pointer ?? System.IntPtr.Zero); }
        public GameplayTagQuery TagQueryExportText_Helper => new GameplayTagQuery(AddrOf(0x50));
    }

    public class EditableGameplayTagQueryExpression : Object
    {
        public const string UeClassName = "EditableGameplayTagQueryExpression";
        public EditableGameplayTagQueryExpression(System.IntPtr ptr) : base(ptr) {}
        public static new EditableGameplayTagQueryExpression FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableGameplayTagQueryExpression(p);
        public static EditableGameplayTagQueryExpression FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableGameplayTagQueryExpression(o.Pointer); }
        public static EditableGameplayTagQueryExpression[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableGameplayTagQueryExpression[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableGameplayTagQueryExpression(a[i].Pointer); return r; }
    }

    public class EditableGameplayTagQueryExpression_AnyTagsMatch : EditableGameplayTagQueryExpression
    {
        public const string UeClassName = "EditableGameplayTagQueryExpression_AnyTagsMatch";
        public EditableGameplayTagQueryExpression_AnyTagsMatch(System.IntPtr ptr) : base(ptr) {}
        public static new EditableGameplayTagQueryExpression_AnyTagsMatch FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableGameplayTagQueryExpression_AnyTagsMatch(p);
        public static EditableGameplayTagQueryExpression_AnyTagsMatch FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableGameplayTagQueryExpression_AnyTagsMatch(o.Pointer); }
        public static EditableGameplayTagQueryExpression_AnyTagsMatch[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableGameplayTagQueryExpression_AnyTagsMatch[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableGameplayTagQueryExpression_AnyTagsMatch(a[i].Pointer); return r; }
        public GameplayTagContainer Tags => new GameplayTagContainer(AddrOf(0x28));
    }

    public class EditableGameplayTagQueryExpression_AllTagsMatch : EditableGameplayTagQueryExpression
    {
        public const string UeClassName = "EditableGameplayTagQueryExpression_AllTagsMatch";
        public EditableGameplayTagQueryExpression_AllTagsMatch(System.IntPtr ptr) : base(ptr) {}
        public static new EditableGameplayTagQueryExpression_AllTagsMatch FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableGameplayTagQueryExpression_AllTagsMatch(p);
        public static EditableGameplayTagQueryExpression_AllTagsMatch FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableGameplayTagQueryExpression_AllTagsMatch(o.Pointer); }
        public static EditableGameplayTagQueryExpression_AllTagsMatch[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableGameplayTagQueryExpression_AllTagsMatch[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableGameplayTagQueryExpression_AllTagsMatch(a[i].Pointer); return r; }
        public GameplayTagContainer Tags => new GameplayTagContainer(AddrOf(0x28));
    }

    public class EditableGameplayTagQueryExpression_NoTagsMatch : EditableGameplayTagQueryExpression
    {
        public const string UeClassName = "EditableGameplayTagQueryExpression_NoTagsMatch";
        public EditableGameplayTagQueryExpression_NoTagsMatch(System.IntPtr ptr) : base(ptr) {}
        public static new EditableGameplayTagQueryExpression_NoTagsMatch FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableGameplayTagQueryExpression_NoTagsMatch(p);
        public static EditableGameplayTagQueryExpression_NoTagsMatch FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableGameplayTagQueryExpression_NoTagsMatch(o.Pointer); }
        public static EditableGameplayTagQueryExpression_NoTagsMatch[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableGameplayTagQueryExpression_NoTagsMatch[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableGameplayTagQueryExpression_NoTagsMatch(a[i].Pointer); return r; }
        public GameplayTagContainer Tags => new GameplayTagContainer(AddrOf(0x28));
    }

    public class EditableGameplayTagQueryExpression_AnyExprMatch : EditableGameplayTagQueryExpression
    {
        public const string UeClassName = "EditableGameplayTagQueryExpression_AnyExprMatch";
        public EditableGameplayTagQueryExpression_AnyExprMatch(System.IntPtr ptr) : base(ptr) {}
        public static new EditableGameplayTagQueryExpression_AnyExprMatch FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableGameplayTagQueryExpression_AnyExprMatch(p);
        public static EditableGameplayTagQueryExpression_AnyExprMatch FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableGameplayTagQueryExpression_AnyExprMatch(o.Pointer); }
        public static EditableGameplayTagQueryExpression_AnyExprMatch[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableGameplayTagQueryExpression_AnyExprMatch[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableGameplayTagQueryExpression_AnyExprMatch(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Expressions => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<UObject*>
    }

    public class EditableGameplayTagQueryExpression_AllExprMatch : EditableGameplayTagQueryExpression
    {
        public const string UeClassName = "EditableGameplayTagQueryExpression_AllExprMatch";
        public EditableGameplayTagQueryExpression_AllExprMatch(System.IntPtr ptr) : base(ptr) {}
        public static new EditableGameplayTagQueryExpression_AllExprMatch FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableGameplayTagQueryExpression_AllExprMatch(p);
        public static EditableGameplayTagQueryExpression_AllExprMatch FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableGameplayTagQueryExpression_AllExprMatch(o.Pointer); }
        public static EditableGameplayTagQueryExpression_AllExprMatch[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableGameplayTagQueryExpression_AllExprMatch[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableGameplayTagQueryExpression_AllExprMatch(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Expressions => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<UObject*>
    }

    public class EditableGameplayTagQueryExpression_NoExprMatch : EditableGameplayTagQueryExpression
    {
        public const string UeClassName = "EditableGameplayTagQueryExpression_NoExprMatch";
        public EditableGameplayTagQueryExpression_NoExprMatch(System.IntPtr ptr) : base(ptr) {}
        public static new EditableGameplayTagQueryExpression_NoExprMatch FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new EditableGameplayTagQueryExpression_NoExprMatch(p);
        public static EditableGameplayTagQueryExpression_NoExprMatch FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new EditableGameplayTagQueryExpression_NoExprMatch(o.Pointer); }
        public static EditableGameplayTagQueryExpression_NoExprMatch[] All() { var a = UObject.FindAllOf(UeClassName); var r = new EditableGameplayTagQueryExpression_NoExprMatch[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new EditableGameplayTagQueryExpression_NoExprMatch(a[i].Pointer); return r; }
        public TArray<System.IntPtr> Expressions => new TArray<System.IntPtr>(AddrOf(0x28)); // TArray<UObject*>
    }

    public class GameplayTagsManager : Object
    {
        public const string UeClassName = "GameplayTagsManager";
        public GameplayTagsManager(System.IntPtr ptr) : base(ptr) {}
        public static new GameplayTagsManager FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GameplayTagsManager(p);
        public static GameplayTagsManager FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GameplayTagsManager(o.Pointer); }
        public static GameplayTagsManager[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GameplayTagsManager[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GameplayTagsManager(a[i].Pointer); return r; }
        public TArray<System.IntPtr> TagSources => new TArray<System.IntPtr>(AddrOf(0xC0)); // TArray<struct>
        public TArray<System.IntPtr> GameplayTagTables => new TArray<System.IntPtr>(AddrOf(0x1B0)); // TArray<UObject*>
    }

    public class GameplayTagsList : Object
    {
        public const string UeClassName = "GameplayTagsList";
        public GameplayTagsList(System.IntPtr ptr) : base(ptr) {}
        public static new GameplayTagsList FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GameplayTagsList(p);
        public static GameplayTagsList FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GameplayTagsList(o.Pointer); }
        public static GameplayTagsList[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GameplayTagsList[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GameplayTagsList(a[i].Pointer); return r; }
        public string ConfigFileName => Native.GetPropString(Pointer, "ConfigFileName"); // FString
        public TArray<System.IntPtr> GameplayTagList => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<struct>
    }

    public class RestrictedGameplayTagsList : Object
    {
        public const string UeClassName = "RestrictedGameplayTagsList";
        public RestrictedGameplayTagsList(System.IntPtr ptr) : base(ptr) {}
        public static new RestrictedGameplayTagsList FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new RestrictedGameplayTagsList(p);
        public static RestrictedGameplayTagsList FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new RestrictedGameplayTagsList(o.Pointer); }
        public static RestrictedGameplayTagsList[] All() { var a = UObject.FindAllOf(UeClassName); var r = new RestrictedGameplayTagsList[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new RestrictedGameplayTagsList(a[i].Pointer); return r; }
        public string ConfigFileName => Native.GetPropString(Pointer, "ConfigFileName"); // FString
        public TArray<System.IntPtr> RestrictedGameplayTagList => new TArray<System.IntPtr>(AddrOf(0x38)); // TArray<struct>
    }

    public class GameplayTagsSettings : GameplayTagsList
    {
        public const string UeClassName = "GameplayTagsSettings";
        public GameplayTagsSettings(System.IntPtr ptr) : base(ptr) {}
        public static new GameplayTagsSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GameplayTagsSettings(p);
        public static GameplayTagsSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GameplayTagsSettings(o.Pointer); }
        public static GameplayTagsSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GameplayTagsSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GameplayTagsSettings(a[i].Pointer); return r; }
        public bool ImportTagsFromConfig { get => Native.GetPropBool(Pointer, "ImportTagsFromConfig"); set => Native.SetPropBool(Pointer, "ImportTagsFromConfig", value); }
        public bool WarnOnInvalidTags { get => Native.GetPropBool(Pointer, "WarnOnInvalidTags"); set => Native.SetPropBool(Pointer, "WarnOnInvalidTags", value); }
        public bool FastReplication { get => Native.GetPropBool(Pointer, "FastReplication"); set => Native.SetPropBool(Pointer, "FastReplication", value); }
        public string InvalidTagCharacters => Native.GetPropString(Pointer, "InvalidTagCharacters"); // FString
        public TArray<System.IntPtr> CategoryRemapping => new TArray<System.IntPtr>(AddrOf(0x60)); // TArray<struct>
        public TArray<System.IntPtr> GameplayTagTableList => new TArray<System.IntPtr>(AddrOf(0x70)); // TArray<struct>
        public TArray<System.IntPtr> GameplayTagRedirects => new TArray<System.IntPtr>(AddrOf(0x80)); // TArray<struct>
        public TArray<System.IntPtr> CommonlyReplicatedTags => new TArray<System.IntPtr>(AddrOf(0x90)); // TArray<FName>
        public int NumBitsForContainerSize { get => GetAt<int>(0xA0); set => SetAt(0xA0, value); }
        public int NetIndexFirstBitSegment { get => GetAt<int>(0xA4); set => SetAt(0xA4, value); }
        public TArray<System.IntPtr> RestrictedConfigFiles => new TArray<System.IntPtr>(AddrOf(0xA8)); // TArray<struct>
    }

    public class GameplayTagsDeveloperSettings : Object
    {
        public const string UeClassName = "GameplayTagsDeveloperSettings";
        public GameplayTagsDeveloperSettings(System.IntPtr ptr) : base(ptr) {}
        public static new GameplayTagsDeveloperSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new GameplayTagsDeveloperSettings(p);
        public static GameplayTagsDeveloperSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new GameplayTagsDeveloperSettings(o.Pointer); }
        public static GameplayTagsDeveloperSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new GameplayTagsDeveloperSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new GameplayTagsDeveloperSettings(a[i].Pointer); return r; }
        public string DeveloperConfigName => Native.GetPropString(Pointer, "DeveloperConfigName"); // FString
    }

}
