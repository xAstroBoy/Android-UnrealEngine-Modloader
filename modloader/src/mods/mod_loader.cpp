// modloader/src/mods/mod_loader.cpp
// Scans mods/ directory, loads each mod's main.lua in a sandboxed environment
// Tracks mod status, errors, supports hot-reload via ADB
// Includes SIGSEGV recovery to prevent one mod from crashing the entire process

#include "modloader/mod_loader.h"
#include "modloader/lua_engine.h"
#include "modloader/mod_tracker.h"
#include "modloader/logger.h"
#include "modloader/paths.h"

#include <dirent.h>
#include <sys/stat.h>
#include <cstring>
#include <algorithm>
#include <signal.h>
#include <setjmp.h>
#include <atomic>
#include <fstream>
#include <set>

namespace mod_loader
{

    static std::vector<ModInfo> s_mods;
    static std::mutex s_mods_mutex;
    static std::atomic<int> s_active_mod_loaders{0};

    // ═══ Persisted disabled set ═════════════════════════════════════════════
    // One mod name per line at <data_dir>/disabled_mods.txt. Mods listed here
    // are skipped at boot and shown as DISABLED. Kept in memory + mirrored to
    // disk so the choice survives a restart / game update.
    static std::set<std::string> s_disabled;
    static std::mutex s_disabled_mutex;
    static bool s_disabled_loaded = false;

    static std::string disabled_file_path()
    {
        return paths::data_dir() + "/disabled_mods.txt";
    }

    static void load_disabled_set_locked()
    {
        if (s_disabled_loaded)
            return;
        s_disabled_loaded = true;
        std::ifstream ifs(disabled_file_path());
        if (!ifs.is_open())
            return;
        std::string line;
        while (std::getline(ifs, line))
        {
            // trim CR/whitespace
            while (!line.empty() && (line.back() == '\r' || line.back() == '\n' ||
                                     line.back() == ' ' || line.back() == '\t'))
                line.pop_back();
            if (!line.empty())
                s_disabled.insert(line);
        }
        logger::log_info("MOD", "Loaded disabled set: %zu mod(s) disabled", s_disabled.size());
    }

    static void save_disabled_set_locked()
    {
        std::ofstream ofs(disabled_file_path(), std::ios::trunc);
        if (!ofs.is_open())
        {
            logger::log_error("MOD", "Could not write disabled set to %s",
                              disabled_file_path().c_str());
            return;
        }
        for (const auto &n : s_disabled)
            ofs << n << "\n";
    }

    bool is_disabled(const std::string &name)
    {
        std::lock_guard<std::mutex> lock(s_disabled_mutex);
        load_disabled_set_locked();
        return s_disabled.count(name) > 0;
    }

    static void set_disabled_persist(const std::string &name, bool disabled)
    {
        std::lock_guard<std::mutex> lock(s_disabled_mutex);
        load_disabled_set_locked();
        if (disabled)
            s_disabled.insert(name);
        else
            s_disabled.erase(name);
        save_disabled_set_locked();
    }

    // Set/refresh a mod's ModInfo status entry (create if missing).
    static void set_mod_status(const std::string &name, ModStatus status, bool enabled,
                               const std::string &error = "")
    {
        std::lock_guard<std::mutex> lock(s_mods_mutex);
        for (auto &m : s_mods)
        {
            if (m.name == name)
            {
                m.status = status;
                m.enabled = enabled;
                if (!error.empty())
                    m.error = error;
                return;
            }
        }
        ModInfo mi;
        mi.name = name;
        mi.path = paths::mods_dir() + "/" + name;
        mi.status = status;
        mi.enabled = enabled;
        mi.error = error;
        s_mods.push_back(mi);
    }

    // ═══ SIGSEGV recovery for mod loading ═══════════════════════════════════
    // When a mod causes a SIGSEGV during loading, we recover via siglongjmp
    // instead of letting the process die. This allows the modloader to skip
    // the crashing mod and continue loading the remaining mods.
    //
    // CRITICAL: jmpbuf and flag must be thread_local. Signal handlers are
    // process-wide but SIGSEGV is delivered to the faulting thread.
    // Without thread_local, a game thread SIGSEGV during mod loading would
    // siglongjmp using the modloader thread's jmpbuf = undefined behavior.
    //
    // NOTE: These are NOT static — they are referenced by crash_handler.cpp
    // as the LOWEST PRIORITY recovery point in the unified signal handler.
    // This ensures that inner recovery guards (hook install, hook execution,
    // ProcessEvent, safe_call) fire BEFORE mod-loading recovery. Previously,
    // a separate mod_load_signal_handler would bypass those inner guards,
    // causing DobbyHook() crashes to kill entire mods instead of just
    // skipping the failed hook.
    thread_local sigjmp_buf s_mod_jmpbuf;
    thread_local volatile sig_atomic_t s_in_mod_loading = 0;

    static bool file_exists(const std::string &path)
    {
        struct stat st;
        return stat(path.c_str(), &st) == 0 && S_ISREG(st.st_mode);
    }

    static bool dir_exists(const std::string &path)
    {
        struct stat st;
        return stat(path.c_str(), &st) == 0 && S_ISDIR(st.st_mode);
    }

    // ═══ Scan and load all mods ═════════════════════════════════════════════
    int load_all()
    {
        s_active_mod_loaders.fetch_add(1, std::memory_order_relaxed);

        std::string mods_path = paths::mods_dir();

        if (!dir_exists(mods_path))
        {
            logger::log_warn("MOD", "Mods directory does not exist: %s", mods_path.c_str());
            // Try to create it
            mkdir(mods_path.c_str(), 0755);
            s_active_mod_loaders.fetch_sub(1, std::memory_order_relaxed);
            return 0;
        }

        DIR *dir = opendir(mods_path.c_str());
        if (!dir)
        {
            logger::log_error("MOD", "Failed to open mods directory: %s", mods_path.c_str());
            s_active_mod_loaders.fetch_sub(1, std::memory_order_relaxed);
            return 0;
        }

        std::vector<std::string> mod_dirs;
        struct dirent *entry;
        while ((entry = readdir(dir)) != nullptr)
        {
            // Skip . and ..
            if (entry->d_name[0] == '.')
                continue;

            std::string mod_path = mods_path + "/" + entry->d_name;
            if (!dir_exists(mod_path))
                continue;

            std::string main_lua = mod_path + "/main.lua";
            if (file_exists(main_lua))
            {
                mod_dirs.push_back(entry->d_name);   // flat: mods/<Mod>/main.lua
                continue;
            }

            // ── CATEGORY FOLDER: mods/<category>/<Mod>/main.lua ────────────
            // One level of nesting, so mods can be filed by what they DO —
            // qol/ vs cheats/ vs fixes/ — and you can install just the set you
            // want instead of dropping 23 folders in and hoping. Requested
            // because "cheese" and "QOL" being mixed makes it impossible to hand
            // someone an improved-but-not-cheated setup. Purely additive: a flat
            // mods/<Mod>/main.lua still loads exactly as before, so nobody's
            // existing layout breaks.
            DIR *sub = opendir(mod_path.c_str());
            if (!sub)
            {
                logger::log_warn("MOD", "Skipping '%s' — no main.lua and not readable", entry->d_name);
                continue;
            }
            int found_here = 0;
            struct dirent *se;
            while ((se = readdir(sub)) != nullptr)
            {
                if (se->d_name[0] == '.')
                    continue;
                std::string child = std::string(entry->d_name) + "/" + se->d_name;
                std::string child_path = mods_path + "/" + child;
                if (!dir_exists(child_path))
                    continue;
                if (!file_exists(child_path + "/main.lua"))
                    continue;
                mod_dirs.push_back(child);       // e.g. "qol/HeadBlocker"
                ++found_here;
            }
            closedir(sub);

            if (found_here)
                logger::log_info("MOD", "category '%s': %d mod(s)", entry->d_name, found_here);
            else
                logger::log_warn("MOD", "Skipping '%s' — no main.lua, and no mods inside it either",
                                 entry->d_name);
        }
        closedir(dir);

        // Sort alphabetically for deterministic load order
        std::sort(mod_dirs.begin(), mod_dirs.end());

        int loaded = 0;
        int failed = 0;

        // NOTE: No separate signal handler installed here.
        // crash_handler.cpp's unified handler checks s_in_mod_loading as
        // the LOWEST priority recovery, ensuring inner guards (hook install,
        // hook execution, ProcessEvent, safe_call) fire first.

        int skipped = 0;
        for (const auto &mod_name : mod_dirs)
        {
            // Respect the persisted disabled set — list it, but don't execute it.
            if (is_disabled(mod_name))
            {
                set_mod_status(mod_name, ModStatus::DISABLED, false);
                logger::log_info("MOD", "Skipping disabled mod: %s", mod_name.c_str());
                skipped++;
                continue;
            }
            if (load_mod(mod_name))
            {
                loaded++;
            }
            else
            {
                failed++;
            }
        }

        logger::log_info("MOD", "Loaded %d mods, %d failed, %d disabled (from %s)",
                         loaded, failed, skipped, mods_path.c_str());
        s_active_mod_loaders.fetch_sub(1, std::memory_order_relaxed);
        return loaded;
    }

    // ═══ Load a single mod ══════════════════════════════════════════════════
    bool load_mod(const std::string &name)
    {
        s_active_mod_loaders.fetch_add(1, std::memory_order_relaxed);

        // Never execute a disabled mod — enable_mod() clears the flag before
        // it calls here, so this only blocks accidental direct loads.
        if (is_disabled(name))
        {
            logger::log_warn("MOD", "Mod '%s' is disabled — refusing to load", name.c_str());
            set_mod_status(name, ModStatus::DISABLED, false);
            s_active_mod_loaders.fetch_sub(1, std::memory_order_relaxed);
            return false;
        }

        std::lock_guard<std::mutex> lock(s_mods_mutex);

        // Check if already loaded
        for (auto &m : s_mods)
        {
            if (m.name == name && m.status == ModStatus::LOADED)
            {
                logger::log_warn("MOD", "Mod '%s' is already loaded", name.c_str());
                s_active_mod_loaders.fetch_sub(1, std::memory_order_relaxed);
                return true;
            }
        }

        std::string mods_path = paths::mods_dir();
        std::string mod_dir = mods_path + "/" + name;
        std::string main_lua = mod_dir + "/main.lua";

        if (!file_exists(main_lua))
        {
            logger::log_error("MOD", "Mod '%s': main.lua not found at %s", name.c_str(), main_lua.c_str());
            ModInfo mi;
            mi.name = name;
            mi.path = mod_dir;
            mi.status = ModStatus::FAILED;
            mi.error = "main.lua not found";
            mi.error_count = 1;
            s_mods.push_back(mi);
            s_active_mod_loaders.fetch_sub(1, std::memory_order_relaxed);
            return false;
        }

        logger::log_info("MOD", "Loading %s", main_lua.c_str());

        // Set up SIGSEGV recovery point — if the mod causes a crash,
        // siglongjmp brings us back here with the signal number
        s_in_mod_loading = 1;
        int crash_sig = sigsetjmp(s_mod_jmpbuf, 1);
        if (crash_sig != 0)
        {
            // We got here via siglongjmp — the mod CRASHED
            s_in_mod_loading = 0;

            const char *sig_name = "UNKNOWN";
            if (crash_sig == SIGSEGV)
                sig_name = "SIGSEGV";
            else if (crash_sig == SIGBUS)
                sig_name = "SIGBUS";
            else if (crash_sig == SIGABRT)
                sig_name = "SIGABRT";

            logger::log_error("MOD", "%s: CRASHED with %s during load — skipping to next mod",
                              name.c_str(), sig_name);
            logger::log_error("MOD", "%s: This mod caused a native crash. Check for invalid memory access.",
                              name.c_str());

            // CRITICAL: the siglongjmp above unwound the C++ stack but NOT the Lua
            // VM's call stack — the mod's chunk was running inside safe_script_file's
            // lua_pcall, so the shared lua_State is now left with a dangling L->ci /
            // L->top. If we leave it, the next garbage-collection cycle traverses the
            // corrupt thread and SIGSEGVs deep in the GC (traversethread/propagatemark)
            // — which is why the game began crash-looping on boot once the game-thread
            // queue started draining and running the GC. Reset the main Lua thread now
            // so the remaining mods load onto a clean stack and the GC stays sane.
            lua_engine::reset_after_crash();

            ModInfo mi;
            mi.name = name;
            mi.path = mod_dir;
            mi.status = ModStatus::FAILED;
            mi.error = std::string("Native crash: ") + sig_name;
            mi.error_count = 1;

            // Remove any existing entry for this mod
            s_mods.erase(
                std::remove_if(s_mods.begin(), s_mods.end(),
                               [&name](const ModInfo &m)
                               { return m.name == name; }),
                s_mods.end());
            s_mods.push_back(mi);

            s_active_mod_loaders.fetch_sub(1, std::memory_order_relaxed);
            return false;
        }

        // Create a sandboxed environment for this mod
        sol::environment env = lua_engine::create_mod_environment(name);

        // Execute the mod's main.lua in its environment
        auto result = lua_engine::exec_file_in_env(main_lua, env);

        // Clear the recovery point
        s_in_mod_loading = 0;

        ModInfo mi;
        mi.name = name;
        mi.path = mod_dir;
        mi.enabled = true;

        if (result.success)
        {
            mi.status = ModStatus::LOADED;
            mi.error_count = 0;
            logger::log_info("MOD", "%s: loaded successfully", name.c_str());
        }
        else
        {
            mi.status = ModStatus::ERRORED;
            mi.error = result.error;
            mi.error_count = 1;
            logger::log_error("MOD", "%s: %s", name.c_str(), result.error.c_str());
            logger::log_info("MOD", "%s: loaded with Lua errors — continuing", name.c_str());
        }

        // Remove any existing entry for this mod
        s_mods.erase(
            std::remove_if(s_mods.begin(), s_mods.end(),
                           [&name](const ModInfo &m)
                           { return m.name == name; }),
            s_mods.end());

        s_mods.push_back(mi);
        s_active_mod_loaders.fetch_sub(1, std::memory_order_relaxed);
        return result.success;
    }

    // ═══ Hot-reload a mod ═══════════════════════════════════════════════════
    bool reload_mod(const std::string &name)
    {
        logger::log_info("MOD", "Hot-reloading mod: %s", name.c_str());

        // Tear down the mod's previous hooks/patches/timers/commands FIRST so a
        // reload doesn't stack a second set of callbacks (or leak a code patch)
        // on top of the old ones. Safe no-op if the mod registered nothing.
        mod_tracker::release_mod(name);

        // Remove the old entry
        {
            std::lock_guard<std::mutex> lock(s_mods_mutex);
            s_mods.erase(
                std::remove_if(s_mods.begin(), s_mods.end(),
                               [&name](const ModInfo &m)
                               { return m.name == name; }),
                s_mods.end());
        }

        // Reload
        bool ok = load_mod(name);

        if (ok)
        {
            logger::log_info("MOD", "%s: hot-reload successful", name.c_str());
        }
        else
        {
            logger::log_error("MOD", "%s: hot-reload failed", name.c_str());
        }

        return ok;
    }

    // ═══ Unload / disable / enable ══════════════════════════════════════════

    bool unload_mod(const std::string &name)
    {
        bool was_loaded = false;
        {
            std::lock_guard<std::mutex> lock(s_mods_mutex);
            for (const auto &m : s_mods)
            {
                if (m.name == name &&
                    (m.status == ModStatus::LOADED || m.status == ModStatus::ERRORED))
                {
                    was_loaded = true;
                    break;
                }
            }
        }

        // Release resources OUTSIDE the mods mutex — mod_tracker touches other
        // subsystems (pe_hook, native_hooks, delayed, bridge) with their own locks.
        auto stats = mod_tracker::release_mod(name);
        (void)stats;

        // Mark UNLOADED but keep enabled=true (transient release). If it isn't
        // in the list at all, add a stub so the UI reflects the state.
        set_mod_status(name, ModStatus::UNLOADED, true);

        logger::log_info("MOD", "%s: unloaded (%s)", name.c_str(),
                         was_loaded ? "was loaded" : "was not loaded");
        return was_loaded;
    }

    bool disable_mod(const std::string &name)
    {
        logger::log_info("MOD", "Disabling mod: %s", name.c_str());
        // Tear down its live resources, then persist the choice.
        mod_tracker::release_mod(name);
        set_disabled_persist(name, true);
        set_mod_status(name, ModStatus::DISABLED, false);
        return true;
    }

    bool enable_mod(const std::string &name)
    {
        logger::log_info("MOD", "Enabling mod: %s", name.c_str());
        // Clear the persisted flag FIRST so load_mod's disabled guard passes.
        set_disabled_persist(name, false);

        // Drop any stale DISABLED/UNLOADED entry so load_mod starts clean.
        {
            std::lock_guard<std::mutex> lock(s_mods_mutex);
            s_mods.erase(
                std::remove_if(s_mods.begin(), s_mods.end(),
                               [&name](const ModInfo &m)
                               { return m.name == name && m.status != ModStatus::LOADED; }),
                s_mods.end());
        }
        return load_mod(name);
    }

    int set_all_enabled(bool enabled)
    {
        // Snapshot the on-disk mod directory names so we affect every scanned
        // mod, not just those with a current ModInfo entry.
        std::vector<std::string> names;
        std::string mods_path = paths::mods_dir();
        if (DIR *dir = opendir(mods_path.c_str()))
        {
            struct dirent *entry;
            while ((entry = readdir(dir)) != nullptr)
            {
                if (entry->d_name[0] == '.')
                    continue;
                std::string mp = mods_path + "/" + entry->d_name;
                if (!dir_exists(mp))
                    continue;
                if (!file_exists(mp + "/main.lua"))
                    continue;
                names.push_back(entry->d_name);
            }
            closedir(dir);
        }

        // Snapshot current status by value (avoid holding a ModInfo* across the
        // enable/disable calls below, which mutate s_mods).
        auto status_of = [](const std::string &n, bool &found) -> ModStatus
        {
            std::lock_guard<std::mutex> lock(s_mods_mutex);
            for (const auto &m : s_mods)
            {
                if (m.name == n)
                {
                    found = true;
                    return m.status;
                }
            }
            found = false;
            return ModStatus::FAILED;
        };

        int affected = 0;
        for (const auto &n : names)
        {
            if (enabled)
            {
                bool found = false;
                ModStatus st = status_of(n, found);
                if (is_disabled(n) || !found || st != ModStatus::LOADED)
                {
                    if (enable_mod(n))
                        affected++;
                }
            }
            else
            {
                if (!is_disabled(n))
                {
                    disable_mod(n);
                    affected++;
                }
            }
        }
        logger::log_info("MOD", "set_all_enabled(%s): %d mod(s) affected",
                         enabled ? "true" : "false", affected);
        return affected;
    }

    // ═══ Query mod status ═══════════════════════════════════════════════════
    const std::vector<ModInfo> &get_all_mods()
    {
        return s_mods;
    }

    int loaded_count()
    {
        std::lock_guard<std::mutex> lock(s_mods_mutex);
        int count = 0;
        for (const auto &m : s_mods)
        {
            if (m.status == ModStatus::LOADED)
                count++;
        }
        return count;
    }

    int failed_count()
    {
        std::lock_guard<std::mutex> lock(s_mods_mutex);
        int count = 0;
        for (const auto &m : s_mods)
        {
            if (m.status == ModStatus::FAILED || m.status == ModStatus::ERRORED)
                count++;
        }
        return count;
    }

    int total_count()
    {
        std::lock_guard<std::mutex> lock(s_mods_mutex);
        return static_cast<int>(s_mods.size());
    }

    const ModInfo *find_mod(const std::string &name)
    {
        std::lock_guard<std::mutex> lock(s_mods_mutex);
        for (const auto &m : s_mods)
        {
            if (m.name == name)
                return &m;
        }
        return nullptr;
    }

    bool is_any_mod_loading()
    {
        return s_active_mod_loaders.load(std::memory_order_relaxed) > 0;
    }

} // namespace mod_loader
