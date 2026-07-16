#pragma once
// modloader/include/modloader/mod_loader.h
// Scans mods/ directory, loads each mod's main.lua, tracks status

#include <string>
#include <vector>

namespace mod_loader
{

    enum class ModStatus
    {
        LOADED,
        ERRORED,
        FAILED,
        DISABLED, // user-disabled — not executed; hooks/patches torn down
        UNLOADED  // released at runtime but still enabled (transient)
    };

    struct ModInfo
    {
        std::string name;
        std::string path;
        ModStatus status = ModStatus::FAILED;
        std::string error;
        int error_count = 0;
        bool enabled = true; // false = persisted in the disabled set
    };

    // Scan mods/ directory and load all mods — returns number loaded.
    // Mods in the persisted disabled set are listed as DISABLED, not executed.
    int load_all();

    // Load a single mod by name
    bool load_mod(const std::string &name);

    // Hot-reload a mod (release its resources, then re-execute main.lua)
    bool reload_mod(const std::string &name);

    // Release a mod's runtime resources (hooks, patches, timers, commands) via
    // mod_tracker WITHOUT changing its enabled state. Marks it UNLOADED.
    // MUST run on the game thread. Returns true if the mod was loaded.
    bool unload_mod(const std::string &name);

    // Disable a mod: unload it AND persist it to the disabled set so it stays
    // off across restarts. Idempotent. MUST run on the game thread.
    bool disable_mod(const std::string &name);

    // Enable a previously disabled mod: remove from the disabled set and load
    // it. Idempotent. MUST run on the game thread.
    bool enable_mod(const std::string &name);

    // Enable or disable EVERY scanned mod at once. Returns count affected.
    // MUST run on the game thread.
    int set_all_enabled(bool enabled);

    // True if a mod name is in the persisted disabled set.
    bool is_disabled(const std::string &name);

    // Get all mod info
    const std::vector<ModInfo> &get_all_mods();

    // Find a specific mod by name
    const ModInfo *find_mod(const std::string &name);

    // Counts
    int loaded_count();
    int failed_count();
    int total_count();

    // True while the loader is in a mod-loading phase (initial batch and/or
    // an individual mod's main.lua is actively executing on any thread).
    bool is_any_mod_loading();

} // namespace mod_loader
