// modloader/src/mods/mod_tracker.cpp
// Per-mod resource registry — see mod_tracker.h.

#include "modloader/mod_tracker.h"
#include "modloader/process_event_hook.h"
#include "modloader/native_hooks.h"
#include "modloader/lua_delayed_actions.h"
#include "modloader/adb_bridge.h"
#include "modloader/logger.h"

#include <sys/mman.h>
#include <fcntl.h>
#include <unistd.h>
#include <cstdio>
#include <cstring>
#include <mutex>
#include <vector>
#include <unordered_map>
#include <algorithm>
#include <chrono>

namespace mod_tracker
{

    struct CodePatch
    {
        uintptr_t addr;
        std::vector<uint8_t> original;
    };

    struct ModResources
    {
        std::vector<uint64_t> pe_hooks;
        std::vector<std::string> commands;
        std::vector<CodePatch> code_patches; // in patch order; restored in reverse
    };

    static std::mutex s_mutex;
    static std::unordered_map<std::string, ModResources> s_mods;

    // ═══ Executable-region check ════════════════════════════════════════════
    // Cached snapshot of executable ranges from /proc/self/maps. Mappings
    // change as the game loads libraries, so a miss triggers ONE refresh.

    struct ExecRange
    {
        uintptr_t start, end;
    };
    static std::vector<ExecRange> s_exec_ranges;
    static std::mutex s_ranges_mutex;

    static void refresh_exec_ranges()
    {
        FILE *f = fopen("/proc/self/maps", "r");
        if (!f)
            return;
        s_exec_ranges.clear();
        char line[768];
        while (fgets(line, sizeof(line), f))
        {
            uintptr_t start = 0, end = 0;
            char perms[8] = {0};
            if (sscanf(line, "%zx-%zx %7s", &start, &end, perms) < 3)
                continue;
            if (perms[2] == 'x')
                s_exec_ranges.push_back({start, end});
        }
        fclose(f);
    }

    static bool in_exec_range_locked(uintptr_t a, uintptr_t b)
    {
        for (const auto &r : s_exec_ranges)
        {
            if (a >= r.start && b <= r.end)
                return true;
        }
        return false;
    }

    // Distinguish a code patch (write into an executable mapping) from an
    // ordinary data write. Mods write DATA every frame (UObject fields), so this
    // is a hot path — it must NOT reparse /proc/self/maps on every data write.
    // We cache the executable ranges and only refresh on a miss at most once per
    // few seconds (a real code patch that lands in a newly-loaded library will
    // be caught on the next refresh; a data write just stays a cheap miss).
    static bool is_exec_address(uintptr_t addr, size_t size)
    {
        using clock = std::chrono::steady_clock;
        std::lock_guard<std::mutex> lock(s_ranges_mutex);
        uintptr_t end = addr + size;

        static bool s_have_ranges = false;
        static clock::time_point s_last_refresh{};

        if (!s_have_ranges)
        {
            refresh_exec_ranges();
            s_have_ranges = true;
            s_last_refresh = clock::now();
        }

        if (in_exec_range_locked(addr, end))
            return true;

        // Miss — refresh at most every 3s so per-frame data writes stay cheap.
        auto now = clock::now();
        if (std::chrono::duration_cast<std::chrono::milliseconds>(now - s_last_refresh).count() >= 3000)
        {
            refresh_exec_ranges();
            s_last_refresh = now;
            return in_exec_range_locked(addr, end);
        }
        return false;
    }

    // Kernel-mediated read that works on PROT_NONE / execute-only pages
    // (same trick as the bridge's mem_read — the write bindings mprotect
    // AFTER we capture, so a direct read could fault here).
    static bool read_original_bytes(uintptr_t addr, uint8_t *out, size_t size)
    {
        static int fd = -1;
        if (fd < 0)
            fd = open("/proc/self/mem", O_RDONLY);
        if (fd < 0)
            return false;
        return pread64(fd, out, size, (off64_t)addr) == (ssize_t)size;
    }

    // ═══ Tracking ═══════════════════════════════════════════════════════════

    void track_pe_hook(const std::string &mod, uint64_t hook_id)
    {
        if (mod.empty() || hook_id == 0)
            return;
        std::lock_guard<std::mutex> lock(s_mutex);
        s_mods[mod].pe_hooks.push_back(hook_id);
    }

    void untrack_pe_hook(uint64_t hook_id)
    {
        if (hook_id == 0)
            return;
        std::lock_guard<std::mutex> lock(s_mutex);
        for (auto &pair : s_mods)
        {
            auto &v = pair.second.pe_hooks;
            v.erase(std::remove(v.begin(), v.end(), hook_id), v.end());
        }
    }

    void track_command(const std::string &mod, const std::string &command)
    {
        if (mod.empty() || command.empty())
            return;
        std::lock_guard<std::mutex> lock(s_mutex);
        auto &v = s_mods[mod].commands;
        if (std::find(v.begin(), v.end(), command) == v.end())
            v.push_back(command);
    }

    void note_code_write(const std::string &mod, void *addr_p, size_t size)
    {
        if (mod.empty() || !addr_p || size == 0 || size > 16)
            return;
        uintptr_t addr = reinterpret_cast<uintptr_t>(addr_p);
        if (!is_exec_address(addr, size))
            return; // data write — game state, not a code patch

        uint8_t buf[16];
        if (!read_original_bytes(addr, buf, size))
        {
            logger::log_warn("MODTRK", "%s: code write at 0x%zx — could not capture original bytes",
                             mod.c_str(), addr);
            return;
        }

        std::lock_guard<std::mutex> lock(s_mutex);
        auto &patches = s_mods[mod].code_patches;
        // First write wins — the earliest capture is the true original.
        for (const auto &p : patches)
        {
            if (p.addr == addr && p.original.size() == size)
                return;
        }
        patches.push_back({addr, std::vector<uint8_t>(buf, buf + size)});
        logger::log_info("MODTRK", "%s: code patch recorded at 0x%zx (%zu bytes)",
                         mod.c_str(), addr, size);
    }

    // ═══ Teardown ═══════════════════════════════════════════════════════════

    static void restore_patch(const CodePatch &p)
    {
        void *addr = reinterpret_cast<void *>(p.addr);
        void *page = reinterpret_cast<void *>(p.addr & ~0xFFFULL);
        mprotect(page, 4096 * 2, PROT_READ | PROT_WRITE | PROT_EXEC);
        std::memcpy(addr, p.original.data(), p.original.size());
        __builtin___clear_cache(
            reinterpret_cast<char *>(addr),
            reinterpret_cast<char *>(addr) + p.original.size());
    }

    ReleaseStats release_mod(const std::string &mod)
    {
        ReleaseStats stats;
        if (mod.empty())
            return stats;

        ModResources res;
        {
            std::lock_guard<std::mutex> lock(s_mutex);
            auto it = s_mods.find(mod);
            if (it != s_mods.end())
            {
                res = std::move(it->second);
                s_mods.erase(it);
            }
        }

        // 1. ProcessEvent hook callbacks (drops the sol::function refs)
        for (uint64_t id : res.pe_hooks)
        {
            pe_hook::unregister(id);
            stats.pe_hooks++;
        }

        // 2. Native (Dobby) chain entries. The trampoline itself stays
        //    installed — an empty chain is a pass-through to the original,
        //    and DobbyDestroy while the game thread may be executing the
        //    trampoline would be unsafe (see native_hooks::remove_key).
        stats.native_keys = native_hooks::remove_keys_with_prefix(mod + ":");

        // 3. Delayed actions (LoopAsync / ExecuteWithDelay loops)
        stats.delayed_actions = lua_delayed::cancel_all_for_mod(mod);

        // 4. Custom bridge commands
        for (const auto &cmd : res.commands)
        {
            adb_bridge::unregister_command(cmd);
            stats.commands++;
        }

        // 5. Code patches — restore original bytes in REVERSE patch order so
        //    overlapping patches unwind back to the true original.
        for (auto it = res.code_patches.rbegin(); it != res.code_patches.rend(); ++it)
        {
            restore_patch(*it);
            stats.code_patches++;
        }

        if (stats.pe_hooks || stats.native_keys || stats.delayed_actions ||
            stats.commands || stats.code_patches)
        {
            logger::log_info("MODTRK",
                             "%s: released %d PE hooks, %d native hook entries, %d delayed actions, "
                             "%d commands, %d code patches restored",
                             mod.c_str(), stats.pe_hooks, stats.native_keys,
                             stats.delayed_actions, stats.commands, stats.code_patches);
        }
        return stats;
    }

} // namespace mod_tracker
