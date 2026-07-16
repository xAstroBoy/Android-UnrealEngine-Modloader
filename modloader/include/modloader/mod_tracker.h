#pragma once
// modloader/include/modloader/mod_tracker.h
// Per-mod resource registry — records every PE hook, delayed action, bridge
// command and code patch a mod creates, so disable/unload can tear the mod
// down COMPLETELY and restore any original code bytes it overwrote.
//
// Native (Dobby) hooks are NOT tracked here: their chain entries already
// carry a "ModName:hookname" key, so release_mod() delegates to
// native_hooks::remove_keys_with_prefix("ModName:").

#include <string>
#include <cstdint>
#include <cstddef>

namespace mod_tracker
{

    struct ReleaseStats
    {
        int pe_hooks = 0;
        int native_keys = 0;
        int delayed_actions = 0;
        int commands = 0;
        int code_patches = 0;
    };

    // Called by the Lua bindings at registration time.
    // An empty mod name (bridge exec_lua, no mod env) is a no-op.
    void track_pe_hook(const std::string &mod, uint64_t hook_id);
    // Keep the registry clean when a mod unregisters a hook itself.
    void untrack_pe_hook(uint64_t hook_id);
    void track_command(const std::string &mod, const std::string &command);

    // Record the ORIGINAL bytes at [addr, addr+size) BEFORE a Lua mod
    // overwrites them — but only when addr lands in an EXECUTABLE mapping
    // (i.e. a code patch). Writes to data pages are game state, never
    // auto-restored. First write wins: repeated patches at the same address
    // keep the earliest (true original) bytes. Restored in reverse order.
    void note_code_write(const std::string &mod, void *addr, size_t size);

    // Tear down everything the mod registered: PE hook callbacks, native
    // (Dobby) chain entries, delayed actions, bridge commands, and code
    // patches (original bytes rewritten + icache flush).
    // MUST run on the game thread — same rule as load_mod/reload_mod.
    ReleaseStats release_mod(const std::string &mod);

} // namespace mod_tracker
