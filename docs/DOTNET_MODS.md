# .NET / C# Mods for the UE ModLoader (MelonLoader / LemonLoader-style)

Status: **foundation landed, runtime binary not yet bundled.** The native host,
the managed API, and the proxy generator all build; what remains before C# mods
run on-device is dropping a Mono runtime pack into `modloader/dotnet/runtime/`
(see “Runtime pack”, below). Until that pack is present the host logs
`dotnet: Mono runtime not found — C# mods disabled` and the loader boots exactly
as before. Nothing here changes the existing Lua path.

## Reconciliation: this is MelonLoader-shaped, but the target is native Unreal

MelonLoader/LemonLoader are **Unity** loaders — their power comes from Unity
having *managed* game code that HarmonyX IL-patches and Il2CppInterop wraps.
RE4 is **native Unreal (C++)**: there is no managed game assembly. So we keep
MelonLoader's *ergonomics* (see `LemonLoader/MelonLoader/Melons/MelonBase.cs`)
and retarget the *mechanism*:

| MelonLoader (Unity)            | Here (native Unreal)                                   |
|--------------------------------|--------------------------------------------------------|
| `MelonMod` + lifecycle         | `UnrealMod` with the **same** override names           |
| `[assembly: MelonInfo]`        | `[MelonInfo]` (class or assembly)                       |
| `HarmonyInstance.PatchAll`     | `HarmonyInstance.PatchAll` → native/UFunction hooks     |
| Harmony Prefix/Postfix (IL)    | native-symbol / UFunction (ProcessEvent) pre/post hooks |
| Harmony Transpiler (IL)        | **native ARM64 rewrite** or **Blueprint/Kismet** rewrite|
| Il2CppInterop typed wrappers   | generated `UEModLoader.Game` proxies over UE reflection |

## What a modder gets

```csharp
using UEModLoader;
using UEModLoader.Game;   // generated proxies — real classes, typeof-able

[MelonInfo(typeof(MyMod), "MyMod", "1.0", "me")]
public class MyMod : UnrealMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"{ACharacter.All().Length} characters live"); // tagged 'MyMod'
    }

    public override void OnUpdate()                     // once per game tick
    {
        var pawn = BP_VR_Pawn_C.FirstOf();
        if (pawn != null) pawn.SmoothMoveSpeed = 400.0; // faithful field at the real offset
    }

    // HarmonyX-style — target a native symbol, or a proxy type + method (typeof):
    [HarmonyPatch(typeof(BP_Enemy_C), "TakeDamage")]
    class TakeDamagePatch
    {
        static void Prefix(NativeContext ctx) { ctx.Block(); } // skip original
    }

    // Transpiler = native rewrite (or Blueprint.Neuter()/SetBytecode for Kismet):
    [HarmonyPatch("cModel::getPartsPtr")]
    class Rewrite { [HarmonyTranspiler] static void T(IntPtr addr) => Patch.Nop(addr, 1); }
}
```

Reference the single **`UEModLoader.dll`** (API + generated proxies), inherit
`UnrealMod`, override MelonMod-named events, drop the built DLL in
`mods_dotnet/`. Standard `try/catch/throw` works (custom `ModException` etc.);
the host wraps every call so a throw is logged with the mod identity, not fatal.

## The three pieces

### 1. Native host — `modloader/src/dotnet/dotnet_host.cpp`
Embeds Mono (soft dependency: `dlopen("libmonosgen-2.0.so")`, all entry points
resolved by `dlsym`, so the modloader links and boots with or without it). On
boot it:
- points Mono at `modloader/dotnet/runtime/` (assemblies + config),
- `mono_jit_init`s a domain,
- registers the **icall bridge** (native functions the managed side calls with
  zero P/Invoke marshalling overhead — `UEModLoader.Native::*`),
- loads `UEModLoader.Api.dll`, then every `mods_dotnet/*.dll`,
- reflects each assembly for non-abstract `Mod` subclasses, instantiates them,
  calls `OnInitialize`,
- drives `OnUpdate`/`OnLateUpdate` from the game-thread ProcessEvent drain
  (`dotnet_host::tick()` is called once per frame from `hooked_process_event`),
- on unload reverts each mod’s patches/hooks (shares the `mod_tracker` +
  `codepatch` reversal ledger, so the crash guard can quarantine a C# mod
  exactly like a Lua one).

### 2. Managed API — `dotnet/UEModLoader.Api/` (C# source + csproj)
The dependency modders reference. Mirrors the Lua surface:
- `Mod` — base class + lifecycle (`OnInitialize`, `OnUpdate`, `OnLateUpdate`,
  `OnModUnload`) + `ModInfo`.
- `Log` — into the native logger.
- `UObject` — **faithful proxy**: wraps the native `UObject*` as an `IntPtr`
  (exposed via `.Pointer`), `Get<T>/Set<T>` read/write at the **real property
  offset**, `Call` invokes the UFunction through ProcessEvent under the crash
  guard, plus `Find/FindFirstOf/FindAllOf/Spawn`. Drop to raw whenever you want.
- `Memory` — Read/Write/Alloc + AOB scan (`/proc/self/mem`-backed).
- `Patch` / `Asm` — the generic static-patch primitives (`codepatch` +
  `arm64_asm`): `Patch.Bytes/Nop/Asm/Branch`, `Asm.Assemble`. Same reversible,
  i-cache-correct engine the Lua `PatchBytes/PatchAsm/...` use.
- `Hooks` — native symbol/address pre/post/replace with managed callbacks;
  `[Patch(...)]` attribute discovery builds on it.

### 3. Proxy generator — `modloader/src/dotnet/csharp_proxy_generator.cpp`
Walks the live reflection graph (same source as the SDK/Lua dumps) and emits
`UEModLoader.Game/*.cs`: one C# class per UClass, **faithfully matching**:
- inheritance chain (`class BP_Enemy_C : ACharacter`),
- fields as typed properties at the exact `Offset_Internal` (baked as `const`
  offsets + typed `Get/Set`, so `enemy.Health` reads the real bytes),
- functions as methods with **matching parameter names/types**, marshalled into
  the params struct at the real parameter offsets and invoked via ProcessEvent,
- structs/enums with matching layout,
- `IntPtr Pointer` + `static T FromPointer(IntPtr)` so the typed proxy and raw
  pointer/reflection-walk/`Memory` utilities interoperate freely — use matching
  data, spawn data, edit data, or go raw, all against the same object.

Generated on demand (`GenerateCSharpProxies()` from Lua / bridge) so it always
matches the running build.

## Runtime pack (the one remaining on-device step)
Drop an arm64-v8a Mono runtime into `modloader/dotnet/runtime/`:
- `libmonosgen-2.0.so` (next to `libmodloader.so`, or in the module lib dir),
- the BCL assemblies (`mscorlib.dll`, `System.dll`, …) under `runtime/lib/`,
- `mono/4.5/machine.config` etc. as Mono expects.
A LemonLoader/Xamarin Mono pack works. The host calls `mono_set_dirs(runtime,
runtime)` and `mono_set_assemblies_path(runtime/lib)` before init.

## Cross-cutting capabilities (shared by Lua AND C# mods)

- **Generic static patching** — instead of the modloader shipping a bespoke C++
  patcher per bug, both languages get the same reversible, i-cache-correct
  primitives (`codepatch` + `arm64_asm`): Lua `PatchBytes/PatchAsm/PatchNop/
  PatchBranch/Asm/RestorePatch`; C# `Patch.Bytes/Asm/Nop/Branch`, `Asm.Assemble`.
  ARM64 assembler covers control-flow + moves; patches auto-revert on unload.
- **Native function tracing** — the reflection walk now captures each UFunction's
  native C++ thunk (`FUNC_Native`). The Lua SDK dump annotates `---@native_func
  0x… (RVA 0x…)`; the C# proxies emit `NativeFunc_Method` (hookable directly).
- **Blueprint / Kismet takeover** — `Blueprint.Find("Class:Fn").SetBytecode/
  Neuter/NativeFunc/Flags` overhauls cooked Blueprint logic at runtime (e.g. gut
  the built-in debug menu) without touching the .pak.
- **Bridge command register + WRAP** — Lua `RegisterCommand`/`RegisterBridgeCommand`/
  `WrapBridgeCommand`; C# `Commands.Register`/`Commands.Wrap`. Wrapping hands a
  `callOriginal` so a mod can append to / post-process / override a STOCK command.
- **Cross-mod dependencies** — C# `ModRegistry.Export/Import<T>`; C#→Lua via
  `Lua.Eval`.
- **Logging** — every line carries a timestamp (native logger) + the MOD IDENTITY
  as the tag: C# `LoggerInstance.Msg/Warning/Error/Debug`; Lua `Log/LogInfo/
  LogWarn/LogError/LogDebug`. DEBUG is suppressed by default — enable with the
  `log_level` bridge command (`level=debug`), Lua `SetLogLevel("debug")`, or the
  config `log_level` key.

## Config
`modloader_config.json`:
- `dotnet_enabled` (default true) — master toggle for the C# subsystem.
- `log_level` (default `info`) — `debug` enables DEBUG output for both languages.
