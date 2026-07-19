#pragma once
// modloader/include/modloader/dotnet_host.h
// Embeds a Mono runtime so C# mods (MelonLoader/LemonLoader-style) run inside
// the game. Soft dependency: the Mono shared library and BCL are dlopen'd at
// runtime; if the runtime pack is absent, init() logs and no-ops and the rest
// of the modloader is unaffected.
//
// Layout on device (under the modloader data dir):
//   dotnet/runtime/            libmonosgen-2.0.so + Mono BCL (mscorlib, ...)
//   dotnet/UEModLoader.dll     the API + generated proxies (one dependency)
//   dotnet/userlibs/*.dll      shared libraries mods depend on (loaded, not run)
//   mods_dotnet/*.dll          user mods (each UnrealMod subclass is instantiated)

#include <string>

namespace dotnet_host
{

    // Boot the runtime and load every C# mod. Safe to call once, on the game
    // thread, after reflection is available. No-op (returns false) if the Mono
    // runtime pack isn't installed or dotnet is disabled in config.
    bool init();

    // True if the runtime booted and is usable.
    bool available();

    // Drive OnUpdate/OnLateUpdate for every loaded mod. Called once per game
    // frame from the ProcessEvent drain (game thread). Cheap no-op if unavailable.
    void tick();

    // Fired when a level finishes loading (world swap), if detected.
    void on_level_loaded();

    // Number of loaded C# mods.
    int mod_count();

    // A short status string for the console/bridge.
    std::string status();

    // Unload everything (best effort) — reverts each mod's patches/hooks.
    void shutdown();

} // namespace dotnet_host
