// modloader/src/bridge/adb_bridge.cpp
// TCP socket server on 127.0.0.1:19420 — JSON command protocol
// No root required — accessible via `adb forward tcp:19420 tcp:19420`

#include "modloader/adb_bridge.h"
#include "modloader/lua_engine.h"
#include "modloader/mod_loader.h"
#include "modloader/pak_mounter.h"
#include "modloader/lua_dump_generator.h"
#include "modloader/ida_mapping_generator.h"
#include "modloader/reflection_walker.h"
#include "modloader/process_event_hook.h"
#include "modloader/pe_trace.h"
#include "modloader/class_rebuilder.h"
#include "modloader/object_monitor.h"
#include "modloader/symbols.h"
#include "modloader/safe_call.h"
#include "modloader/logger.h"
#include "modloader/paths.h"
#include "modloader/aes_extractor.h"

#include <nlohmann/json.hpp>

#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>
#include <fcntl.h>
#include <pthread.h>
#include <cerrno>
#include <cstring>
#include <cstdio>
#include <cstdlib>
#include <atomic>
#include <mutex>
#include <condition_variable>
#include <unordered_map>
#include <functional>
#include <memory>
#include <vector>
#include <string>
#include <fstream>
#include <algorithm>
#include <cctype>

using json = nlohmann::json;

namespace adb_bridge
{

    static int s_server_fd = -1;
    static std::atomic<bool> s_running{false};
    static std::atomic<int> s_game_thread_command_depth{0};
    static pthread_t s_server_thread;
    static std::chrono::steady_clock::time_point s_start_time;

    struct GameThreadCommandScope
    {
        GameThreadCommandScope()
        {
            s_game_thread_command_depth.fetch_add(1, std::memory_order_acq_rel);
        }

        ~GameThreadCommandScope()
        {
            s_game_thread_command_depth.fetch_sub(1, std::memory_order_acq_rel);
        }
    };

    // ═══ Custom command registry ════════════════════════════════════════════
    static std::unordered_map<std::string, CommandHandler> s_custom_commands;
    static std::mutex s_command_mutex;

    void register_command(const std::string &name, CommandHandler handler)
    {
        std::lock_guard<std::mutex> lock(s_command_mutex);
        s_custom_commands[name] = handler;
        logger::log_info("ADB", "Registered custom command: '%s'", name.c_str());
    }

    void unregister_command(const std::string &name)
    {
        std::lock_guard<std::mutex> lock(s_command_mutex);
        if (s_custom_commands.erase(name) > 0)
        {
            logger::log_info("ADB", "Unregistered custom command: '%s'", name.c_str());
        }
    }

    std::vector<std::string> get_registered_commands()
    {
        std::lock_guard<std::mutex> lock(s_command_mutex);
        std::vector<std::string> names;
        for (const auto &pair : s_custom_commands)
        {
            names.push_back(pair.first);
        }
        return names;
    }

    bool is_game_thread_command_active()
    {
        return s_game_thread_command_depth.load(std::memory_order_acquire) > 0;
    }

    // ═══ JSON response helpers ══════════════════════════════════════════════
    static std::string ok_response(const json &result)
    {
        json resp;
        resp["ok"] = true;
        resp["result"] = result;
        return resp.dump() + "\n";
    }

    static std::string error_response(const std::string &msg)
    {
        json resp;
        resp["ok"] = false;
        resp["error"] = msg;
        return resp.dump() + "\n";
    }

    // ═══ NATIVE memory primitives ═══════════════════════════════════════════
    // mem_read / mem_write / mem_read_bytes / mem_regions / module_base run
    // ENTIRELY on the bridge socket thread via /proc/self/mem + /proc/self/maps.
    // They deliberately do NOT queue on the game thread: reading process memory
    // needs no UE reflection, and the game thread is frozen whenever the VR
    // runtime pauses the app (headset off face / proximity sleep) or during
    // cutscenes that stall the tick. Previously these were shipped as exec_lua
    // wrappers (MemReadU64 etc.), so they timed out exactly when you most need
    // to inspect live memory. Now they always work while the process is alive.

    // Shared /proc/self/mem fd (kernel-mediated R/W; works on PROT_NONE pages).
    static int bridge_mem_fd()
    {
        static int fd = -1;
        if (fd < 0)
            fd = open("/proc/self/mem", O_RDWR);
        return fd;
    }

    // Parse an address/value field that may arrive as a JSON string ("0x..",
    // decimal) or a JSON number. Strings avoid float precision loss on >2^53
    // addresses, so the MCP sends decimal strings; we accept both for safety.
    static uint64_t json_u64(const json &j, uint64_t dflt = 0)
    {
        if (j.is_string())
            return strtoull(j.get<std::string>().c_str(), nullptr, 0);
        if (j.is_number_unsigned())
            return j.get<uint64_t>();
        if (j.is_number_integer())
            return (uint64_t)j.get<int64_t>();
        if (j.is_number_float())
            return (uint64_t)(int64_t)j.get<double>();
        return dflt;
    }

    static bool mem_type_size(const std::string &t, int &size, char &kind)
    {
        if (t == "u8"  || t == "i8")  { size = 1; kind = (t[0]=='i')?'s':'u'; return true; }
        if (t == "u16" || t == "i16") { size = 2; kind = (t[0]=='i')?'s':'u'; return true; }
        if (t == "u32" || t == "i32") { size = 4; kind = (t[0]=='i')?'s':'u'; return true; }
        if (t == "u64" || t == "i64") { size = 8; kind = (t[0]=='i')?'s':'u'; return true; }
        if (t == "f32" || t == "float") { size = 4; kind = 'f'; return true; }
        if (t == "f64" || t == "double") { size = 8; kind = 'd'; return true; }
        return false;
    }

    static std::string handle_mem_read(const json &cmd)
    {
        if (!cmd.contains("addr"))
            return error_response("mem_read: missing 'addr'");
        uint64_t addr = json_u64(cmd["addr"]);
        std::string type = cmd.value("type", std::string("u64"));
        int size = 8; char kind = 'u';
        if (!mem_type_size(type, size, kind))
            return error_response("mem_read: bad type '" + type + "'");
        int fd = bridge_mem_fd();
        if (fd < 0)
            return error_response("mem_read: cannot open /proc/self/mem");
        uint64_t bits = 0;
        if (pread64(fd, &bits, size, (off64_t)addr) != size)
            return error_response("mem_read: read failed at 0x" + [&]{ char b[24]; snprintf(b,sizeof b,"%llX",(unsigned long long)addr); return std::string(b); }() + " (unmapped?)");
        char val[64];
        switch (kind)
        {
        case 'f': { float f; std::memcpy(&f, &bits, 4); snprintf(val, sizeof val, "%g", (double)f); break; }
        case 'd': { double d; std::memcpy(&d, &bits, 8); snprintf(val, sizeof val, "%g", d); break; }
        case 's':
            if (size == 1) snprintf(val, sizeof val, "%d", (int)(int8_t)(uint8_t)bits);
            else if (size == 2) snprintf(val, sizeof val, "%d", (int)(int16_t)(uint16_t)bits);
            else if (size == 4) snprintf(val, sizeof val, "%d", (int)(int32_t)(uint32_t)bits);
            else snprintf(val, sizeof val, "%lld", (long long)bits);
            break;
        default:
            if (size == 1) snprintf(val, sizeof val, "%u", (unsigned)(uint8_t)bits);
            else if (size == 2) snprintf(val, sizeof val, "%u", (unsigned)(uint16_t)bits);
            else if (size == 4) snprintf(val, sizeof val, "%u", (unsigned)(uint32_t)bits);
            else snprintf(val, sizeof val, "%llu", (unsigned long long)bits);
            break;
        }
        char out[160];
        snprintf(out, sizeof out, "0x%llX = %s (%s)", (unsigned long long)addr, val, type.c_str());
        return ok_response(std::string(out));
    }

    static std::string handle_mem_write(const json &cmd)
    {
        if (!cmd.contains("addr") || !cmd.contains("value"))
            return error_response("mem_write: missing 'addr'/'value'");
        uint64_t addr = json_u64(cmd["addr"]);
        std::string type = cmd.value("type", std::string("u64"));
        int size = 8; char kind = 'u';
        if (!mem_type_size(type, size, kind))
            return error_response("mem_write: bad type '" + type + "'");
        // Value comes as a string/number; interpret via double (Lua-number parity)
        // then reinterpret into the target width.
        double dv = 0.0;
        if (cmd["value"].is_string()) dv = strtod(cmd["value"].get<std::string>().c_str(), nullptr);
        else if (cmd["value"].is_number()) dv = cmd["value"].get<double>();
        uint64_t bits = 0;
        if (kind == 'f') { float f = (float)dv; std::memcpy(&bits, &f, 4); }
        else if (kind == 'd') { std::memcpy(&bits, &dv, 8); }
        else { long long iv = (long long)dv; bits = (uint64_t)iv; }
        int fd = bridge_mem_fd();
        if (fd < 0)
            return error_response("mem_write: cannot open /proc/self/mem");
        bool ok = (pwrite64(fd, &bits, size, (off64_t)addr) == size);
        char out[160];
        snprintf(out, sizeof out, "write 0x%llX = %g (%s) -> %s",
                 (unsigned long long)addr, dv, type.c_str(), ok ? "true" : "false");
        return ok_response(std::string(out));
    }

    static std::string handle_mem_read_bytes(const json &cmd)
    {
        if (!cmd.contains("addr"))
            return error_response("mem_read_bytes: missing 'addr'");
        uint64_t addr = json_u64(cmd["addr"]);
        int len = cmd.value("len", 32);
        if (len <= 0 || len > 4096)
            return error_response("mem_read_bytes: len out of range (1..4096)");
        int fd = bridge_mem_fd();
        if (fd < 0)
            return error_response("mem_read_bytes: cannot open /proc/self/mem");
        std::vector<uint8_t> buf(len, 0);
        if (pread64(fd, buf.data(), len, (off64_t)addr) != len)
            return error_response("mem_read_bytes: read failed (unmapped?)");
        static const char *hx = "0123456789abcdef";
        std::string s; s.reserve(len * 2);
        for (int i = 0; i < len; i++) { s += hx[buf[i] >> 4]; s += hx[buf[i] & 0xF]; }
        return ok_response(s);
    }

    static std::string handle_mem_regions(const json &cmd)
    {
        std::string filter = cmd.value("filter", std::string(""));
        std::ifstream maps("/proc/self/maps");
        if (!maps.is_open())
            return error_response("mem_regions: cannot open /proc/self/maps");
        std::string line;
        std::vector<std::string> rows;
        while (std::getline(maps, line))
        {
            uintptr_t s = 0, e = 0; char perms[8] = {0}; char path[512] = {0};
            int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %511[^\n]", &s, &e, perms, path);
            if (n < 3) continue;
            std::string p = (n >= 4) ? path : "";
            if (!filter.empty() && p.find(filter) == std::string::npos) continue;
            char b[640];
            snprintf(b, sizeof b, "0x%llX-0x%llX %s %-9llu %s",
                     (unsigned long long)s, (unsigned long long)e, perms,
                     (unsigned long long)(e - s), p.c_str());
            rows.push_back(b);
        }
        std::string out = std::to_string(rows.size()) + " regions\n";
        for (size_t i = 0; i < rows.size(); i++) { out += rows[i]; if (i + 1 < rows.size()) out += "\n"; }
        return ok_response(out);
    }

    static std::string handle_module_base(const json &cmd)
    {
        std::string want = cmd.value("name", std::string("libUnreal.so"));
        std::ifstream maps("/proc/self/maps");
        if (!maps.is_open())
            return error_response("module_base: cannot open /proc/self/maps");
        std::string line; uintptr_t best = 0;
        while (std::getline(maps, line))
        {
            uintptr_t s = 0, e = 0; char pr[8] = {0}; char path[512] = {0};
            int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %511[^\n]", &s, &e, pr, path);
            if (n < 4) continue;
            std::string p = path;
            if (p.find(want) != std::string::npos && (best == 0 || s < best)) best = s;
        }
        char out[32];
        snprintf(out, sizeof out, "0x%llX", (unsigned long long)best);
        return ok_response(std::string(out));
    }

    // ═══ Command handlers ═══════════════════════════════════════════════════

    // Forward decl — mod enable/disable/unload handlers (defined below) queue
    // work onto the game thread via this helper, which is defined further down.
    static bool run_modop_on_game_thread(const std::function<bool()> &fn, int timeout_s, bool &timed_out);

    static const char *mod_status_str(mod_loader::ModStatus s)
    {
        switch (s)
        {
        case mod_loader::ModStatus::LOADED:
            return "loaded";
        case mod_loader::ModStatus::ERRORED:
            return "errored";
        case mod_loader::ModStatus::DISABLED:
            return "disabled";
        case mod_loader::ModStatus::UNLOADED:
            return "unloaded";
        default:
            return "failed";
        }
    }

    static std::string handle_list_mods()
    {
        auto &mods = mod_loader::get_all_mods();
        json result = json::array();
        for (const auto &m : mods)
        {
            json entry;
            entry["name"] = m.name;
            entry["status"] = mod_status_str(m.status);
            entry["enabled"] = m.enabled;
            entry["errors"] = m.error_count;
            if (!m.error.empty())
                entry["last_error"] = m.error;
            result.push_back(entry);
        }
        return ok_response(result);
    }

    // enable/disable/unload a single mod — must run on the game thread because
    // tearing a mod down drops the sol::function refs its hooks hold (touching
    // the game-thread-owned Lua state), and re-enabling executes Lua.
    static std::string handle_mod_toggle(const json &payload, int mode)
    {
        // mode: 0 = enable, 1 = disable, 2 = unload
        if (!payload.contains("name"))
            return error_response("missing 'name' parameter");
        std::string name = payload["name"];
        bool timed_out = false;
        bool ok = run_modop_on_game_thread([name, mode]()
                                           {
            switch (mode) {
            case 0: return mod_loader::enable_mod(name);
            case 1: return mod_loader::disable_mod(name);
            default: return mod_loader::unload_mod(name);
            } }, 20, timed_out);
        const char *verb = (mode == 0) ? "enable" : (mode == 1) ? "disable"
                                                                 : "unload";
        if (timed_out)
            return error_response(std::string(verb) + " queued on game thread but exceeded 20s; it may still finish");
        std::string msg = std::string(verb) + (ok ? "d: " : " (no-op): ") + name;
        return ok_response(msg);
    }

    static std::string handle_set_all_mods(const json &payload)
    {
        bool enabled = payload.value("enabled", true);
        bool timed_out = false;
        int affected = 0;
        run_modop_on_game_thread([enabled, &affected]()
                                 {
            affected = mod_loader::set_all_enabled(enabled);
            return true; }, 60, timed_out);
        if (timed_out)
            return error_response("set_all_mods queued on game thread but exceeded 60s; it may still finish");
        json result;
        result["enabled"] = enabled;
        result["affected"] = affected;
        return ok_response(result);
    }

    // Run a mod load/reload on the GAME THREAD and block for the result. Loading a mod
    // executes its Lua chunk (FindAllOf / RegisterHook / UObject calls) against the
    // game-thread-owned Lua state; doing that on the bridge thread races the game
    // thread's Lua (ProcessEvent hooks, delayed actions) and corrupts it -> crash on
    // reload. Queue it the same way exec_lua does. `timed_out` is set if the game
    // thread didn't finish within the window (the work still completes on the game
    // thread; only the bridge reply gives up).
    static bool run_modop_on_game_thread(const std::function<bool()> &fn, int timeout_s, bool &timed_out)
    {
        struct Ctx
        {
            std::mutex mtx;
            std::condition_variable cv;
            std::atomic<bool> done{false};
            std::atomic<bool> cancelled{false};
            bool ok{false};
        };
        auto ctx = std::make_shared<Ctx>();
        pe_hook::queue_game_thread([ctx, fn]()
                                   {
            if (ctx->cancelled.load(std::memory_order_acquire)) return;
            GameThreadCommandScope scope;
            bool r = fn();
            { std::lock_guard<std::mutex> lk(ctx->mtx); ctx->ok = r; ctx->done.store(true, std::memory_order_release); }
            ctx->cv.notify_one(); });

        std::unique_lock<std::mutex> lk(ctx->mtx);
        if (!ctx->cv.wait_for(lk, std::chrono::seconds(timeout_s), [&]
                              { return ctx->done.load(); }))
        {
            ctx->cancelled.store(true, std::memory_order_release);
            timed_out = true;
            return false;
        }
        timed_out = false;
        return ctx->ok;
    }

    static std::string handle_reload_mod(const json &payload)
    {
        if (!payload.contains("name"))
            return error_response("missing 'name' parameter");
        std::string name = payload["name"];
        bool timed_out = false;
        bool ok = run_modop_on_game_thread([name]()
                                           { return mod_loader::reload_mod(name); }, 20, timed_out);
        if (timed_out)
            return error_response("reload_mod queued on game thread but exceeded 20s (heavy mod?); it may still finish");
        return ok ? ok_response("reloaded: " + name) : error_response("reload failed: " + name);
    }

    static std::string handle_load_mod(const json &payload)
    {
        if (!payload.contains("name"))
            return error_response("missing 'name' parameter");
        std::string name = payload["name"];
        bool timed_out = false;
        bool ok = run_modop_on_game_thread([name]()
                                           { return mod_loader::load_mod(name); }, 20, timed_out);
        if (timed_out)
            return error_response("load_mod queued on game thread but exceeded 20s; it may still finish");
        return ok ? ok_response("loaded: " + name) : error_response("load failed: " + name);
    }

    static std::string handle_exec_lua(const json &payload)
    {
        if (!payload.contains("code"))
            return error_response("missing 'code' parameter");
        std::string code = payload["code"];

        // Lua is NOT thread-safe. exec_lua runs on the bridge thread but the Lua state
        // is owned by the game thread (ProcessEvent hooks fire there). We must queue the
        // execution onto the game thread and block until the result is ready.
        struct ExecContext
        {
            std::mutex mtx;
            std::condition_variable cv;
            std::atomic<bool> done{false};
            std::atomic<bool> cancelled{false}; // set when bridge times out
            lua_engine::ExecResult result;
        };
        auto ctx = std::make_shared<ExecContext>();

        pe_hook::queue_game_thread([ctx, code]()
                                   {
        // CRITICAL: If the bridge already timed out and the caller disconnected,
        // skip execution to avoid running stale/dangerous code on the game thread.
        if (ctx->cancelled.load(std::memory_order_acquire)) {
            logger::log_warn("ADB", "exec_lua: skipping cancelled/timed-out command");
            return;
        }

        GameThreadCommandScope scope;

        // Use instruction limit for bridge exec_lua to prevent infinite loops/recursion
        // from freezing the game thread. 10M instructions is plenty for any reasonable
        // bridge command but catches runaway code before it can block the game.
        ctx->result = lua_engine::exec_string(code, "=adb", 10'000'000);
        {
            std::lock_guard<std::mutex> lk(ctx->mtx);
            ctx->done.store(true, std::memory_order_release);
        }
        ctx->cv.notify_one(); });

        // Wait up to 8 seconds for the game thread to process it
        {
            std::unique_lock<std::mutex> lk(ctx->mtx);
            if (!ctx->cv.wait_for(lk, std::chrono::seconds(8), [&]
                                  { return ctx->done.load(); }))
            {
                // Mark as cancelled so the queued lambda skips execution
                ctx->cancelled.store(true, std::memory_order_release);
                logger::log_warn("ADB", "exec_lua: timed out, marking queued command as cancelled");
                return error_response(
                    "exec_lua timed out (game thread did not drain queue in 8s). If persistent, the "
                    "game thread is frozen (headset off / proximity sleep) — put the headset on. "
                    "mem_read/mem_write/mem_regions/module_base run natively and work regardless.");
            }
        }

        if (ctx->result.success)
        {
            return ok_response(ctx->result.output.empty() ? "ok" : ctx->result.output);
        }
        return error_response(ctx->result.error);
    }

    static std::string handle_list_hooks()
    {
        auto stats = pe_hook::get_func_stats();
        json result = json::array();
        for (const auto &fs : stats)
        {
            json entry;
            entry["path"] = fs.name;
            entry["call_count"] = fs.call_count;
            result.push_back(entry);
        }
        return ok_response(result);
    }

    static std::string handle_dump_sdk()
    {
        // Re-walk GUObjectArray to capture newly loaded classes, then regenerate SDK
        int files = sdk_gen::regenerate();
        json result;
        result["classes"] = sdk_gen::class_count();
        result["structs"] = sdk_gen::struct_count();
        result["enums"] = sdk_gen::enum_count();
        result["files_written"] = files;
        result["cxx_header_path"] = paths::cxx_header_dir();
        result["lua_types_path"] = paths::lua_types_dir();
        result["legacy_sdk_path"] = paths::sdk_dir();
        result["note"] = "Re-walked GUObjectArray and regenerated SDK (CXXHeaderDump + Lua + Legacy)";
        return ok_response(result);
    }

    static std::string handle_dump_ida()
    {
        // Re-walk GUObjectArray so newly loaded classes are covered, then emit
        // the IDA/Ghidra function-rename mappings (Dumper-7 style).
        reflection::walk_all();
        int files = ida_map::generate();
        json result;
        result["functions"] = ida_map::function_count();
        result["globals"] = ida_map::global_count();
        result["files_written"] = files;
        result["ida_path"] = paths::ida_dir();
        result["note"] = "Renamed native UFunction exec pointers → IDAMapping/UnrealFunctions.py "
                         "(+ UnrealGlobals.py, UnrealSymbols.map, UnrealMappings.json)";
        return ok_response(result);
    }

    static std::string handle_object_count()
    {
        int32_t live = object_monitor::get_live_count();
        int32_t last_walk = reflection::get_object_count();
        json result;
        result["live_object_count"] = live;
        result["last_walk_count"] = last_walk;
        result["growth_since_walk"] = live - last_walk;
        result["classes_known"] = reflection::get_classes().size();
        result["structs_known"] = reflection::get_structs().size();
        result["enums_known"] = reflection::get_enums().size();
        result["auto_dumps"] = object_monitor::auto_dump_count();
        return ok_response(result);
    }

    static std::string handle_mount_pak(const json &payload)
    {
        if (!payload.contains("path") && !payload.contains("name"))
        {
            return error_response("missing 'path' or 'name' parameter");
        }
        std::string pak = payload.contains("path") ? payload["path"].get<std::string>()
                                                   : payload["name"].get<std::string>();
        bool ok = pak_mounter::mount(pak);
        return ok ? ok_response("mounted: " + pak) : error_response("mount failed: " + pak);
    }

    static std::string handle_list_paks()
    {
        auto &paks = pak_mounter::get_all();
        json result = json::array();
        for (const auto &p : paks)
        {
            json entry;
            entry["name"] = p.name;
            entry["path"] = p.path;
            entry["mounted"] = p.mounted;
            entry["size_mb"] = p.file_size / (1024.0 * 1024.0);
            if (!p.error.empty())
                entry["error"] = p.error;
            result.push_back(entry);
        }
        return ok_response(result);
    }

    static std::string handle_log_tail(const json &payload)
    {
        int lines = 50;
        if (payload.contains("lines"))
            lines = payload["lines"];
        auto tail = logger::get_tail(lines);
        json result = json::array();
        for (const auto &line : tail)
        {
            result.push_back(line);
        }
        return ok_response(result);
    }

    static std::string handle_get_stats()
    {
        auto elapsed = std::chrono::steady_clock::now() - s_start_time;
        auto secs = std::chrono::duration_cast<std::chrono::seconds>(elapsed).count();

        json result;
        result["uptime_seconds"] = secs;
        result["mods_loaded"] = mod_loader::loaded_count();
        result["mods_failed"] = mod_loader::failed_count();
        result["mods_total"] = mod_loader::total_count();
        result["classes_known"] = reflection::get_classes().size();
        result["structs_known"] = reflection::get_structs().size();
        result["enums_known"] = reflection::get_enums().size();
        result["live_object_count"] = object_monitor::get_live_count();
        result["last_walk_count"] = reflection::get_object_count();
        result["auto_dumps"] = object_monitor::auto_dump_count();

        auto stats = pe_hook::get_func_stats();
        int64_t total_calls = 0;
        for (const auto &fs : stats)
            total_calls += fs.call_count;
        result["total_hook_calls"] = total_calls;
        result["active_hooks"] = stats.size();
        result["aes_key_count"] = aes_extractor::key_count();

        return ok_response(result);
    }

    static std::string handle_aes_scan()
    {
        int found = aes_extractor::scan_for_keys();
        json result;
        result["found_now"] = found;
        result["total_keys"] = aes_extractor::key_count();
        return ok_response(result);
    }

    static std::string handle_aes_latest()
    {
        auto key = aes_extractor::get_latest_key();
        bool empty = true;
        for (int i = 0; i < 32; i++)
        {
            if (key.bytes[i] != 0)
            {
                empty = false;
                break;
            }
        }

        if (empty)
        {
            return error_response("no AES keys captured yet");
        }

        json result;
        result["hex"] = aes_extractor::key_to_hex(key);
        result["base64"] = aes_extractor::key_to_base64(key);
        result["source"] = key.source;
        result["pak"] = key.pak_name;
        result["timestamp_ms"] = key.timestamp;
        return ok_response(result);
    }

    static std::string handle_aes_keys()
    {
        auto keys = aes_extractor::get_keys();
        json result = json::array();
        for (const auto &k : keys)
        {
            json entry;
            entry["hex"] = aes_extractor::key_to_hex(k);
            entry["base64"] = aes_extractor::key_to_base64(k);
            entry["source"] = k.source;
            entry["pak"] = k.pak_name;
            entry["timestamp_ms"] = k.timestamp;
            result.push_back(entry);
        }
        return ok_response(result);
    }

    static std::string handle_find_object(const json &payload)
    {
        if (!payload.contains("name"))
            return error_response("missing 'name' parameter");
        std::string name = payload["name"];
        ue::UObject *obj = reflection::find_object_by_name(name);
        if (!obj)
            return error_response("object not found: " + name);

        json result;
        result["name"] = reflection::get_short_name(obj);
        result["full_name"] = reflection::get_full_name(obj);
        char addr_buf[32];
        snprintf(addr_buf, sizeof(addr_buf), "0x%lX", (unsigned long)reinterpret_cast<uintptr_t>(obj));
        result["address"] = std::string(addr_buf);

        ue::UClass *cls = ue::uobj_get_class(obj);
        if (cls)
        {
            result["class"] = reflection::get_short_name(reinterpret_cast<const ue::UObject *>(cls));
        }

        return ok_response(result);
    }

    static std::string handle_find_class(const json &payload)
    {
        if (!payload.contains("name"))
            return error_response("missing 'name' parameter");
        std::string name = payload["name"];
        ue::UClass *cls = reflection::find_class_ptr(name);
        if (!cls)
            return error_response("class not found: " + name);

        std::string class_name = reflection::get_short_name(reinterpret_cast<const ue::UObject *>(cls));
        auto *rc = rebuilder::rebuild(class_name);

        json result;
        result["name"] = class_name;
        char addr_buf[32];
        snprintf(addr_buf, sizeof(addr_buf), "0x%lX", (unsigned long)reinterpret_cast<uintptr_t>(cls));
        result["address"] = std::string(addr_buf);

        if (rc)
        {
            result["properties"] = rc->all_properties.size();
            result["functions"] = rc->all_functions.size();
            result["instances"] = rc->instance_count();
            result["parent"] = rc->parent_name;
        }

        return ok_response(result);
    }

    // ═══ Live object inspector ══════════════════════════════════════════════
    // list_instances / inspect read live UObject state for the PCBridge object
    // inspector. CRITICAL: every game-memory read goes through the non-faulting
    // safe_call::safe_memcpy (/proc/self/mem). With the crash suppressor removed,
    // a raw deref of a stale/freed instance would tombstone the GAME — inspecting
    // must never do that. A bad read simply yields "<unreadable>".

    // Read a UE FString (u16 chars) safely; truncates long strings for display.
    static std::string read_fstring_safe(const void *fstr_addr)
    {
        struct FStr
        {
            const char16_t *data;
            int32_t num, max;
        } fs{};
        if (!safe_call::safe_memcpy(&fs, fstr_addr, sizeof(fs)))
            return std::string();
        if (!fs.data || fs.num <= 0 || fs.num > 8192)
            return std::string();
        int n = fs.num > 256 ? 256 : fs.num;
        std::vector<char16_t> tmp(n, 0);
        if (!safe_call::safe_memcpy(tmp.data(), fs.data, (size_t)n * sizeof(char16_t)))
            return std::string();
        std::string out;
        for (int i = 0; i < n && tmp[i]; i++)
        {
            char16_t c = tmp[i];
            out += (c < 0x80) ? (char)c : '?';
        }
        return out;
    }

    // Describe an object-typed property target: "ClassName @ 0xADDR" or "null".
    static std::string describe_obj_ptr(const uint8_t *buf)
    {
        ue::UObject *o = *reinterpret_cast<ue::UObject *const *>(buf);
        if (!o || !ue::is_mapped_ptr(o))
            return o ? "0x?(bad)" : "null";
        ue::UClass *cls = ue::uobj_get_class(o);
        std::string cn = (cls && ue::is_valid_ptr(cls))
                             ? reflection::get_short_name(reinterpret_cast<const ue::UObject *>(cls))
                             : "UObject";
        char b[96];
        snprintf(b, sizeof(b), "%s @ 0x%lX", cn.c_str(), (unsigned long)reinterpret_cast<uintptr_t>(o));
        return std::string(b);
    }

    // Format one property's live value as a JSON value (typed where possible).
    static json format_prop_value(const rebuilder::RebuiltProperty &p, ue::UObject *obj)
    {
        const uint8_t *base = reinterpret_cast<const uint8_t *>(obj) + p.offset;
        uint8_t buf[16] = {0};

        auto read = [&](size_t n) -> bool
        {
            return n <= sizeof(buf) && safe_call::safe_memcpy(buf, base, n);
        };

        switch (p.type)
        {
        case reflection::PropType::BoolProperty:
        {
            uint8_t b = 0;
            if (!safe_call::safe_memcpy(&b, base + p.bool_byte_offset_extra, 1))
                return "<unreadable>";
            return p.bool_byte_mask ? ((b & p.bool_byte_mask) != 0) : (b != 0);
        }
        case reflection::PropType::IntProperty:
            return read(4) ? json(*reinterpret_cast<int32_t *>(buf)) : json("<unreadable>");
        case reflection::PropType::UInt32Property:
            return read(4) ? json(*reinterpret_cast<uint32_t *>(buf)) : json("<unreadable>");
        case reflection::PropType::Int64Property:
            return read(8) ? json(*reinterpret_cast<int64_t *>(buf)) : json("<unreadable>");
        case reflection::PropType::UInt64Property:
            return read(8) ? json(*reinterpret_cast<uint64_t *>(buf)) : json("<unreadable>");
        case reflection::PropType::Int16Property:
            return read(2) ? json(*reinterpret_cast<int16_t *>(buf)) : json("<unreadable>");
        case reflection::PropType::UInt16Property:
            return read(2) ? json(*reinterpret_cast<uint16_t *>(buf)) : json("<unreadable>");
        case reflection::PropType::Int8Property:
            return read(1) ? json((int)*reinterpret_cast<int8_t *>(buf)) : json("<unreadable>");
        case reflection::PropType::ByteProperty:
            return read(1) ? json((unsigned)buf[0]) : json("<unreadable>");
        case reflection::PropType::EnumProperty:
        {
            int sz = p.element_size > 0 && p.element_size <= 8 ? p.element_size : 1;
            if (!read((size_t)sz))
                return "<unreadable>";
            int64_t v = 0;
            std::memcpy(&v, buf, sz);
            return v;
        }
        case reflection::PropType::FloatProperty:
            return read(4) ? json(*reinterpret_cast<float *>(buf)) : json("<unreadable>");
        case reflection::PropType::DoubleProperty:
            return read(8) ? json(*reinterpret_cast<double *>(buf)) : json("<unreadable>");
        case reflection::PropType::NameProperty:
            return read(4) ? json(reflection::fname_to_string(*reinterpret_cast<int32_t *>(buf)))
                           : json("<unreadable>");
        case reflection::PropType::StrProperty:
            return read_fstring_safe(base);
        case reflection::PropType::ObjectProperty:
        case reflection::PropType::WeakObjectProperty:
        case reflection::PropType::LazyObjectProperty:
        case reflection::PropType::ClassProperty:
        case reflection::PropType::InterfaceProperty:
            return read(sizeof(void *)) ? json(describe_obj_ptr(buf)) : json("<unreadable>");
        case reflection::PropType::TextProperty:
            return "<FText>";
        case reflection::PropType::StructProperty:
            return std::string("<struct ") + p.type_name + ">";
        case reflection::PropType::ArrayProperty:
            return "<array>";
        case reflection::PropType::MapProperty:
            return "<map>";
        case reflection::PropType::SetProperty:
            return "<set>";
        default:
            return std::string("<") + p.type_name + ">";
        }
    }

    // Resolve an inspect/list target from the payload → UObject* (or class ptr).
    static ue::UObject *resolve_target_object(const json &cmd)
    {
        if (cmd.contains("address"))
        {
            uint64_t a = json_u64(cmd["address"]);
            return reinterpret_cast<ue::UObject *>(static_cast<uintptr_t>(a));
        }
        if (cmd.contains("name"))
            return reflection::find_object_by_name(cmd["name"].get<std::string>());
        if (cmd.contains("class"))
        {
            std::string cls = cmd["class"].get<std::string>();
            int index = cmd.value("index", 0);
            auto insts = reflection::find_all_instances(cls);
            if (index >= 0 && index < (int)insts.size())
                return insts[index];
        }
        return nullptr;
    }

    // Case-insensitive substring test.
    static bool icontains(const std::string &hay, const std::string &needle)
    {
        if (needle.empty())
            return true;
        auto it = std::search(
            hay.begin(), hay.end(), needle.begin(), needle.end(),
            [](char a, char b)
            { return std::tolower((unsigned char)a) == std::tolower((unsigned char)b); });
        return it != hay.end();
    }

    // list_classes — all reflection-known UClass names (cached, instant), for the
    // Objects-tab class browser. Optional 'filter' (case-insensitive substring).
    static std::string handle_list_classes(const json &cmd)
    {
        std::string filter = cmd.value("filter", std::string(""));
        int limit = cmd.value("limit", 0); // 0 = unlimited (no clamping)

        const auto &classes = reflection::get_classes();
        json arr = json::array();
        int n = 0;
        for (const auto &ci : classes)
        {
            if (!icontains(ci.name, filter))
                continue;
            json e;
            e["name"] = ci.name;
            e["package"] = ci.package_name;
            arr.push_back(e);
            n++;
            if (limit > 0 && n >= limit)
                break;
        }
        json result;
        result["total_known"] = (int)classes.size();
        result["returned"] = n;
        result["classes"] = arr;
        return ok_response(result);
    }

    // class_counts — walk GUObjectArray ONCE and tally live instances per class.
    // This is the "what can I actually inspect right now" view. Reads are guarded
    // (is_mapped_ptr / is_valid_ptr) so a torn object during the walk can't crash
    // the game now that the crash suppressor is gone.
    static std::string handle_class_counts(const json &cmd)
    {
        int min_count = cmd.value("min", 1);
        int limit = cmd.value("limit", 0); // 0 = unlimited (no clamping)
        std::string filter = cmd.value("filter", std::string(""));

        int32_t total = reflection::get_live_object_count();
        std::unordered_map<std::string, int> counts;
        counts.reserve(4096);
        for (int32_t i = 0; i < total; i++)
        {
            ue::UObject *obj = reflection::get_object_by_index(i);
            if (!obj || !ue::is_mapped_ptr(obj))
                continue;
            ue::UClass *cls = ue::uobj_get_class(obj);
            if (!cls || !ue::is_valid_ptr(cls))
                continue;
            std::string cn = reflection::get_short_name(reinterpret_cast<const ue::UObject *>(cls));
            if (cn.empty())
                continue;
            counts[cn]++;
        }

        std::vector<std::pair<std::string, int>> rows;
        rows.reserve(counts.size());
        for (auto &kv : counts)
        {
            if (kv.second >= min_count && icontains(kv.first, filter))
                rows.push_back(kv);
        }
        std::sort(rows.begin(), rows.end(),
                  [](const std::pair<std::string, int> &a, const std::pair<std::string, int> &b)
                  { return a.second != b.second ? a.second > b.second : a.first < b.first; });

        json arr = json::array();
        int n = 0;
        for (auto &r : rows)
        {
            json e;
            e["name"] = r.first;
            e["count"] = r.second;
            arr.push_back(e);
            n++;
            if (limit > 0 && n >= limit)
                break;
        }
        json result;
        result["scanned_objects"] = total;
        result["distinct_classes"] = (int)counts.size();
        result["returned"] = n;
        result["classes"] = arr;
        return ok_response(result);
    }

    static std::string handle_list_instances(const json &cmd)
    {
        if (!cmd.contains("class"))
            return error_response("list_instances: missing 'class'");
        std::string cls = cmd["class"].get<std::string>();
        int limit = cmd.value("limit", 0); // 0 = unlimited (no clamping)

        auto insts = reflection::find_all_instances(cls);
        json arr = json::array();
        int n = 0;
        for (auto *obj : insts)
        {
            if (limit > 0 && n >= limit)
                break;
            if (!obj || !ue::is_mapped_ptr(obj))
                continue;
            json e;
            char addr[24];
            snprintf(addr, sizeof(addr), "0x%lX", (unsigned long)reinterpret_cast<uintptr_t>(obj));
            e["address"] = std::string(addr);
            e["name"] = reflection::get_short_name(obj);
            e["full_name"] = reflection::get_full_name(obj);
            arr.push_back(e);
            n++;
        }
        json result;
        result["class"] = cls;
        result["total"] = (int)insts.size();
        result["returned"] = n;
        result["instances"] = arr;
        return ok_response(result);
    }

    static std::string handle_inspect(const json &cmd)
    {
        ue::UObject *obj = resolve_target_object(cmd);
        if (!obj || !ue::is_mapped_ptr(obj))
            return error_response("inspect: object not found / not resolvable "
                                  "(pass 'address', 'name', or 'class'[+'index'])");

        ue::UClass *cls = ue::uobj_get_class(obj);
        if (!cls || !ue::is_valid_ptr(cls))
            return error_response("inspect: object has no valid class");
        std::string class_name = reflection::get_short_name(reinterpret_cast<const ue::UObject *>(cls));

        auto *rc = rebuilder::rebuild(class_name);
        if (!rc)
            return error_response("inspect: could not rebuild class " + class_name);

        json result;
        char addr[24];
        snprintf(addr, sizeof(addr), "0x%lX", (unsigned long)reinterpret_cast<uintptr_t>(obj));
        result["address"] = std::string(addr);
        result["name"] = reflection::get_short_name(obj);
        result["full_name"] = reflection::get_full_name(obj);
        result["class"] = class_name;
        result["parent"] = rc->parent_name;

        bool want_values = cmd.value("values", true);
        json props = json::array();
        for (const auto &p : rc->all_properties)
        {
            json e;
            e["name"] = p.name;
            e["type"] = p.type_name;
            e["offset"] = p.offset;
            if (want_values)
                e["value"] = format_prop_value(p, obj);
            props.push_back(e);
        }
        result["properties"] = props;

        json funcs = json::array();
        for (const auto &f : rc->all_functions)
        {
            json e;
            e["name"] = f.name;
            e["num_parms"] = f.num_parms;
            e["flags"] = f.flags;
            json params = json::array();
            for (const auto &pp : f.params)
            {
                json pe;
                pe["name"] = pp.name;
                pe["type"] = (int)pp.type;
                params.push_back(pe);
            }
            e["params"] = params;
            funcs.push_back(e);
        }
        result["functions"] = funcs;
        return ok_response(result);
    }

    // ═══ Dispatch command ═══════════════════════════════════════════════════
    static std::string dispatch(const std::string &raw_json)
    {
        json cmd = json::parse(raw_json, nullptr, false);
        if (cmd.is_discarded())
        {
            return error_response("invalid JSON");
        }

        if (!cmd.contains("cmd"))
            return error_response("missing 'cmd' field");

        std::string command = cmd["cmd"];
        logger::log_info("ADB", "Command: %s", command.c_str());

        if (command == "list_mods")
            return handle_list_mods();
        if (command == "reload_mod")
            return handle_reload_mod(cmd);
        if (command == "load_mod")
            return handle_load_mod(cmd);
        if (command == "enable_mod")
            return handle_mod_toggle(cmd, 0);
        if (command == "disable_mod")
            return handle_mod_toggle(cmd, 1);
        if (command == "unload_mod")
            return handle_mod_toggle(cmd, 2);
        if (command == "set_all_mods")
            return handle_set_all_mods(cmd);
        if (command == "exec_lua")
            return handle_exec_lua(cmd);
        if (command == "list_hooks")
            return handle_list_hooks();
        if (command == "dump_sdk")
            return handle_dump_sdk();
        if (command == "redump")
            return handle_dump_sdk();
        if (command == "dump_ida")
            return handle_dump_ida();
        if (command == "mount_pak")
            return handle_mount_pak(cmd);
        if (command == "list_paks")
            return handle_list_paks();
        if (command == "log_tail")
            return handle_log_tail(cmd);
        if (command == "get_stats")
            return handle_get_stats();
        if (command == "find_object")
            return handle_find_object(cmd);
        if (command == "find_class")
            return handle_find_class(cmd);
        if (command == "list_classes")
            return handle_list_classes(cmd);
        if (command == "class_counts")
            return handle_class_counts(cmd);
        if (command == "list_instances")
            return handle_list_instances(cmd);
        if (command == "inspect")
            return handle_inspect(cmd);
        if (command == "object_count")
            return handle_object_count();
        if (command == "aes_scan")
            return handle_aes_scan();
        if (command == "aes_latest")
            return handle_aes_latest();
        if (command == "aes_keys")
            return handle_aes_keys();

        // ═══ PE Trace commands ═══════════════════════════════════════════════
        if (command == "pe_trace_start")
        {
            std::string filter;
            if (cmd.contains("filter"))
                filter = cmd["filter"].get<std::string>();
            pe_trace::start(filter);
            return ok_response("tracing started" + (filter.empty() ? std::string("") : " (filter: " + filter + ")"));
        }
        if (command == "pe_trace_stop")
        {
            pe_trace::stop();
            return ok_response(pe_trace::status());
        }
        if (command == "pe_trace_clear")
        {
            pe_trace::clear();
            return ok_response("trace data cleared");
        }
        if (command == "pe_trace_status")
        {
            return ok_response(pe_trace::status());
        }
        if (command == "pe_trace_top")
        {
            int n = 50;
            if (cmd.contains("n"))
                n = cmd["n"].get<int>();
            if (cmd.contains("lines"))
                n = cmd["lines"].get<int>();
            return ok_response(pe_trace::top(n));
        }
        if (command == "pe_trace_dump")
        {
            std::string result = pe_trace::dump_to_file();
            return ok_response(result);
        }

        // ═══ NATIVE memory primitives (socket-thread; no game thread) ════════
        // These read/write /proc/self/mem directly and work even while the game
        // thread is frozen (headset off / cutscene stall). See handlers above.
        if (command == "mem_read")
            return handle_mem_read(cmd);
        if (command == "mem_write")
            return handle_mem_write(cmd);
        if (command == "mem_read_bytes")
            return handle_mem_read_bytes(cmd);
        if (command == "mem_regions")
            return handle_mem_regions(cmd);
        if (command == "module_base")
            return handle_module_base(cmd);

        // simple ping for console connectivity
        if (command == "ping")
        {
            return ok_response("pong");
        }

        // ═══ exec_console — execute a UE console command via bridge ═════════
        // Usage: {"cmd": "exec_console", "command": "stat fps"}
        // This runs the command via PlayerController::ConsoleCommand (ProcessEvent)
        // which works even in shipping builds (no FExec::Exec guard).
        if (command == "exec_console")
        {
            if (!cmd.contains("command"))
                return error_response("exec_console: missing 'command' field");
            std::string console_cmd = cmd["command"].get<std::string>();

            // exec_console must run on the game thread (PlayerController access is game-thread only)
            // Queue it and wait for result
            std::string exec_result;
            std::mutex mtx;
            std::condition_variable cv;
            bool done = false;

            pe_hook::queue_game_thread([&]()
                                       {
                // Find PlayerController
                ue::UObject* pc = nullptr;
                static const char* pc_classes[] = {
                    "BP_PlayerController_C", "VR4PlayerController_BP_C",
                    "PFXPlayerController", "PlayerController", nullptr
                };
                for (int i = 0; pc_classes[i] && !pc; i++) {
                    auto* rc = rebuilder::rebuild(pc_classes[i]);
                    if (rc) pc = rc->get_first_instance();
                }
                if (!pc) pc = reflection::find_first_instance("PlayerController");

                if (!pc) {
                    std::lock_guard<std::mutex> lk(mtx);
                    exec_result = "ERROR: no PlayerController";
                    done = true;
                    cv.notify_one();
                    return;
                }

                auto* func = pe_hook::resolve_func_path("PlayerController:ConsoleCommand");
                if (!func) {
                    std::lock_guard<std::mutex> lk(mtx);
                    exec_result = "ERROR: ConsoleCommand not found";
                    done = true;
                    cv.notify_one();
                    return;
                }

                uint16_t parms_size = ue::ufunc_get_parms_size(func);
                std::vector<uint8_t> parms(parms_size > 0 ? parms_size : 128, 0);

                std::u16string u16cmd(console_cmd.begin(), console_cmd.end());
                u16cmd.push_back(u'\0');
                struct FStr { const char16_t* data; int32_t num, max; };
                FStr fs;
                fs.data = u16cmd.c_str();
                fs.num = static_cast<int32_t>(u16cmd.size());
                fs.max = fs.num;
                std::memcpy(parms.data(), &fs, sizeof(FStr));

                auto pe = pe_hook::get_original();
                if (!pe) pe = symbols::ProcessEvent;
                if (pe) {
                    pe(pc, func, parms.data());
                    std::lock_guard<std::mutex> lk(mtx);
                    exec_result = "OK: executed '" + console_cmd + "'";
                } else {
                    std::lock_guard<std::mutex> lk(mtx);
                    exec_result = "ERROR: ProcessEvent not available";
                }
                done = true;
                cv.notify_one(); });

            // Wait up to 8 seconds for game thread to execute
            {
                std::unique_lock<std::mutex> lk(mtx);
                if (!cv.wait_for(lk, std::chrono::seconds(8), [&]
                                 { return done; }))
                {
                    return error_response("exec_console timed out");
                }
            }

            logger::log_info("ADB", "exec_console: %s -> %s", console_cmd.c_str(), exec_result.c_str());
            return ok_response(exec_result);
        }

        // dump_console_commands — dump all known console commands/CVars
        if (command == "dump_console_commands")
        {
            json result = json::array();
            const auto &classes = reflection::get_classes();
            for (const auto &ci : classes)
            {
                for (const auto &fi : ci.functions)
                {
                    if (fi.flags & 0x00000200)
                    { // FUNC_Exec
                        json entry;
                        entry["class"] = ci.name;
                        entry["name"] = fi.name;
                        entry["full"] = ci.name + ":" + fi.name;
                        entry["params"] = fi.num_parms;
                        result.push_back(entry);
                    }
                }
            }
            logger::log_info("ADB", "dump_console_commands: %d commands", (int)result.size());
            return ok_response(result);
        }

        // dump_symbols — writes all ELF symbols from libUE4.so to a file
        if (command == "dump_symbols")
        {
            std::string out_path = paths::data_dir() + "/symbol_dump.txt";
            int count = symbols::dump_symbols(out_path);
            if (count > 0)
            {
                json result;
                result["symbols"] = count;
                result["path"] = out_path;
                return ok_response(result);
            }
            return error_response("symbol dump failed — see log");
        }

        // log_stream is handled specially in the client loop
        if (command == "log_stream")
            return ""; // sentinel

        // help: list all built-in and custom commands
        if (command == "help")
        {
            json result = json::array();
            // list built-ins hardcoded as in dispatch table
            std::vector<std::string> built = {
                "list_mods", "reload_mod", "load_mod",
                "enable_mod", "disable_mod", "unload_mod", "set_all_mods",
                "exec_lua", "list_hooks",
                "dump_sdk", "dump_ida", "mount_pak", "list_paks", "log_tail", "get_stats",
                "find_object", "find_class", "list_classes", "class_counts",
                "list_instances", "inspect",
                "object_count", "dump_symbols",
                "exec_console", "dump_console_commands",
                "aes_scan", "aes_latest", "aes_keys",
                "pe_trace_start", "pe_trace_stop", "pe_trace_clear", "pe_trace_status",
                "pe_trace_top", "pe_trace_dump", "ping"};
            for (auto &b : built)
                result.push_back(b);
            // then append custom
            {
                std::lock_guard<std::mutex> lock(s_command_mutex);
                for (const auto &pair : s_custom_commands)
                {
                    result.push_back(pair.first);
                }
            }
            return ok_response(result);
        }

        // Check custom commands registered by Lua mods
        // These callbacks invoke Lua functions — must run on game thread
        {
            CommandHandler handler;
            std::string args;
            {
                std::lock_guard<std::mutex> lock(s_command_mutex);
                auto it = s_custom_commands.find(command);
                if (it != s_custom_commands.end())
                {
                    handler = it->second;
                    if (cmd.contains("args"))
                    {
                        args = cmd["args"].get<std::string>();
                    }
                }
            }
            if (handler)
            {
                struct CmdContext
                {
                    std::mutex mtx;
                    std::condition_variable cv;
                    std::atomic<bool> done{false};
                    std::atomic<bool> cancelled{false};
                    std::string result;
                };
                auto ctx = std::make_shared<CmdContext>();

                pe_hook::queue_game_thread([ctx, handler, args]()
                                           {
                if (ctx->cancelled.load(std::memory_order_acquire)) {
                    logger::log_warn("ADB", "Custom command: skipping cancelled/timed-out");
                    return;
                }
                GameThreadCommandScope scope;
                ctx->result = handler(args);
                {
                    std::lock_guard<std::mutex> lk(ctx->mtx);
                    ctx->done.store(true, std::memory_order_release);
                }
                ctx->cv.notify_one(); });

                std::unique_lock<std::mutex> lk(ctx->mtx);
                if (!ctx->cv.wait_for(lk, std::chrono::seconds(8), [&]
                                      { return ctx->done.load(); }))
                {
                    ctx->cancelled.store(true, std::memory_order_release);
                    return error_response("command '" + command + "' timed out (game thread did not process within 8s)");
                }
                return ok_response(ctx->result);
            }
        }

        return error_response("unknown command: " + command);
    }

    // ═══ Handle a single client connection ══════════════════════════════════
    static void handle_client(int client_fd)
    {
        char buf[8192];
        std::string accumulated;

        while (s_running)
        {
            ssize_t n = recv(client_fd, buf, sizeof(buf) - 1, 0);
            if (n <= 0)
                break;

            buf[n] = '\0';
            accumulated += buf;

            // Process complete lines (newline-delimited JSON)
            size_t pos;
            while ((pos = accumulated.find('\n')) != std::string::npos)
            {
                std::string line = accumulated.substr(0, pos);
                accumulated = accumulated.substr(pos + 1);

                if (line.empty())
                    continue;

                // Check for log_stream command
                {
                    json cmd = json::parse(line, nullptr, false);
                    if (!cmd.is_discarded() && cmd.contains("cmd") && cmd["cmd"] == "log_stream")
                    {
                        // Stream logs until client disconnects
                        logger::log_info("ADB", "Starting log stream for client");
                        logger::add_stream_socket(client_fd);

                        // Send existing tail first
                        auto tail = logger::get_tail(100);
                        if (!tail.empty())
                        {
                            send(client_fd, tail.c_str(), tail.size(), MSG_NOSIGNAL);
                        }

                        // Block until client disconnects — logger will push new lines via the stream socket
                        char drain[256];
                        while (s_running)
                        {
                            ssize_t r = recv(client_fd, drain, sizeof(drain), 0);
                            if (r <= 0)
                                break;
                        }

                        logger::remove_stream_socket(client_fd);
                        logger::log_info("ADB", "Log stream client disconnected");
                        close(client_fd);
                        return;
                    }
                }

                std::string response = dispatch(line);
                if (!response.empty())
                {
                    send(client_fd, response.c_str(), response.size(), MSG_NOSIGNAL);
                }
            }

            // If there is no newline yet, try processing accumulated as a single command
            if (!accumulated.empty() && accumulated.find('{') != std::string::npos && accumulated.find('}') != std::string::npos)
            {
                std::string response = dispatch(accumulated);
                accumulated.clear();
                if (!response.empty())
                {
                    send(client_fd, response.c_str(), response.size(), MSG_NOSIGNAL);
                }
            }
        }

        close(client_fd);
    }

    // ═══ Server thread ══════════════════════════════════════════════════════
    static void *server_thread_fn(void *arg)
    {
        (void)arg;

        while (s_running)
        {
            struct sockaddr_in client_addr;
            socklen_t client_len = sizeof(client_addr);

            int client_fd = accept(s_server_fd, (struct sockaddr *)&client_addr, &client_len);
            if (client_fd < 0)
            {
                if (s_running)
                {
                    logger::log_error("ADB", "accept() failed: %s", strerror(errno));
                }
                continue;
            }

            char client_ip[INET_ADDRSTRLEN];
            inet_ntop(AF_INET, &client_addr.sin_addr, client_ip, sizeof(client_ip));
            logger::log_info("ADB", "Client connected from %s:%d",
                             client_ip, ntohs(client_addr.sin_port));

            // Handle client in a detached thread
            pthread_t client_thread;
            int *fd_copy = new int(client_fd);
            pthread_create(&client_thread, nullptr, [](void *arg) -> void *
                           {
            int fd = *reinterpret_cast<int*>(arg);
            delete reinterpret_cast<int*>(arg);
            handle_client(fd);
            return nullptr; }, fd_copy);
            pthread_detach(client_thread);
        }

        return nullptr;
    }

    // ═══ Public API ═════════════════════════════════════════════════════════
    bool start()
    {
        if (s_running)
            return true;

        s_start_time = std::chrono::steady_clock::now();

        s_server_fd = socket(AF_INET, SOCK_STREAM, 0);
        if (s_server_fd < 0)
        {
            logger::log_error("ADB", "socket() failed: %s", strerror(errno));
            return false;
        }

        int opt = 1;
        setsockopt(s_server_fd, SOL_SOCKET, SO_REUSEADDR, &opt, sizeof(opt));

        struct sockaddr_in addr;
        memset(&addr, 0, sizeof(addr));
        addr.sin_family = AF_INET;
        addr.sin_addr.s_addr = inet_addr("127.0.0.1");
        addr.sin_port = htons(ADB_BRIDGE_PORT);

        if (bind(s_server_fd, (struct sockaddr *)&addr, sizeof(addr)) < 0)
        {
            logger::log_error("ADB", "bind() failed on port %d: %s", ADB_BRIDGE_PORT, strerror(errno));
            close(s_server_fd);
            s_server_fd = -1;
            return false;
        }

        if (listen(s_server_fd, 4) < 0)
        {
            logger::log_error("ADB", "listen() failed: %s", strerror(errno));
            close(s_server_fd);
            s_server_fd = -1;
            return false;
        }

        s_running = true;
        pthread_create(&s_server_thread, nullptr, server_thread_fn, nullptr);

        logger::log_info("ADB", "Bridge listening on 127.0.0.1:%d", ADB_BRIDGE_PORT);
        return true;
    }

    void stop()
    {
        s_running = false;
        if (s_server_fd >= 0)
        {
            shutdown(s_server_fd, SHUT_RDWR);
            close(s_server_fd);
            s_server_fd = -1;
        }
        logger::log_info("ADB", "Bridge stopped");
    }

    bool is_running()
    {
        return s_running;
    }

} // namespace adb_bridge
