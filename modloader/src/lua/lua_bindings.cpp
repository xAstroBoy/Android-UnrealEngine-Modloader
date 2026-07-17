// modloader/src/lua/lua_bindings.cpp
// Registers ALL global Lua API functions — the full UE4SS-equivalent surface
// Every function is fully implemented. No stubs. No TODOs.

#include "modloader/lua_bindings.h"
#include "modloader/crash_handler.h"
#include "modloader/lua_uobject.h"
#include "modloader/class_rebuilder.h"
#include "modloader/reflection_walker.h"
#include "modloader/process_event_hook.h"
#include "modloader/native_hooks.h"
#include "modloader/symbols.h"
#include "modloader/pattern_scanner.h"
#include "modloader/pak_mounter.h"
#include "modloader/notification.h"
#include "modloader/lua_dump_generator.h"
#include "modloader/adb_bridge.h"
#include "modloader/mod_tracker.h"
#include "modloader/object_monitor.h"
#include "modloader/logger.h"
#include "modloader/paths.h"
#include "modloader/types.h"
#include "modloader/safe_call.h"

#include <cstring>
#include <cstdlib>
#include <cstdio>
#include <cmath>
#include <thread>
#include <dlfcn.h>
#include <fcntl.h>
#include <unistd.h>
#include <sys/mman.h>
#include <sys/stat.h>
#include <fstream>
#include <sstream>
#include <functional>
#include <vector>
#include <array>
#include <algorithm>
#include <utility>
#include <nlohmann/json.hpp>

// Native storage for HeapSnapVec / HeapFilterMovedVec (motion-based struct find)
static std::vector<uintptr_t> g_snap_addr;
static std::vector<std::array<float, 3>> g_snap_val;

namespace lua_bindings
{

    // ═══ Native hook signature parsing ══════════════════════════════════════
    // Describes ARM64 AAPCS64 argument/return register mapping for native hooks.
    // Each 'p'/'i' = next X register (integer/pointer), 'f'/'d' = next D register (float).
    // A '>' separator marks the return type: ">f" = float return in D0.
    struct NativeHookSig
    {
        std::vector<char> arg_types; // 'p' or 'f' per parameter position
        bool float_return;           // true if return is float (D0), false = X0
    };

    static NativeHookSig parse_native_hook_sig(const std::string &sig)
    {
        NativeHookSig result;
        result.float_return = false;
        std::string args_part = sig;
        auto arrow = sig.find('>');
        if (arrow != std::string::npos)
        {
            args_part = sig.substr(0, arrow);
            std::string ret_part = sig.substr(arrow + 1);
            if (!ret_part.empty() && (ret_part[0] == 'f' || ret_part[0] == 'd'))
            {
                result.float_return = true;
            }
        }
        for (char c : args_part)
        {
            if (c == 'p' || c == 'i')
                result.arg_types.push_back('p');
            else if (c == 'f' || c == 'd')
                result.arg_types.push_back('f');
        }
        return result;
    }

    // Derive a native-hook "registrant key" from the calling mod's environment.
    // Each mod's Lua env carries MOD_NAME (see lua_engine::create_mod_environment),
    // so native hooks from DIFFERENT mods on the same address get distinct keys
    // and COEXIST (chain), while the SAME mod re-registering (hot-reload)
    // REPLACES its own entry. Returns "" when there's no mod env (e.g. bridge
    // exec_lua) — native_hooks then falls back to the hook name as the key.
    // `name` is the hook's own label so a single mod can register SEVERAL hooks
    // on the same address (distinct names) without them replacing each other,
    // while a reload of the same (mod,name) still lands on the same key.
    static std::string hook_key_from_env(const sol::this_environment &te, const std::string &name)
    {
        if (te.env)
        {
            sol::optional<std::string> mn = (*te.env)["MOD_NAME"];
            if (mn && !mn->empty())
                return *mn + ":" + name;
        }
        return std::string(); // no mod env → native_hooks falls back to `name`
    }

    // Just the MOD_NAME ("" when there is no mod env, e.g. bridge exec_lua).
    // Used to attribute PE hooks / commands / code patches to a mod so
    // disable/unload can tear them down via mod_tracker.
    static std::string mod_from_env(const sol::this_environment &te)
    {
        if (te.env)
        {
            sol::optional<std::string> mn = (*te.env)["MOD_NAME"];
            if (mn && !mn->empty())
                return *mn;
        }
        return std::string();
    }

    // ═══ Path normalization helpers ═════════════════════════════════════════
    // UE4SS mods pass full paths like "/Script/Game.ClassName:FuncName" but our
    // PE hook system matches by short "ClassName:FuncName".  These helpers strip
    // the /Script/ and /Game/ prefixes so hooks resolve immediately instead of
    // falling through to the expensive lazy-resolve codepath.

    // Normalize a hook path:  "/Script/Module.ClassName:FuncName" → "ClassName:FuncName"
    //                         "/Game/Maps/Level.Actor:Func"       → "Actor:Func"
    // Passes through already-short paths unchanged.
    static std::string normalize_hook_path(const std::string &raw)
    {
        if (raw.size() < 2)
            return raw;
        if (raw[0] != '/')
            return raw; // already short
        if (raw.compare(0, 8, "/Script/") != 0 &&
            raw.compare(0, 6, "/Game/") != 0)
            return raw; // unknown prefix

        size_t colon = raw.rfind(':');
        if (colon == std::string::npos)
        {
            // No colon — this is a class-only path, strip to class name
            size_t dot = raw.rfind('.');
            return (dot != std::string::npos) ? raw.substr(dot + 1) : raw;
        }
        std::string path_part = raw.substr(0, colon);
        std::string func_part = raw.substr(colon + 1);
        size_t dot = path_part.rfind('.');
        std::string class_part = (dot != std::string::npos) ? path_part.substr(dot + 1) : path_part;
        return class_part + ":" + func_part;
    }

    // Normalize a class-only path: "/Script/Game.ClassName" → "ClassName"
    // Used by FindFirstOf, FindAllOf, FindClass, NotifyOnNewObject, etc.
    static std::string normalize_class_name(const std::string &raw)
    {
        if (raw.empty() || raw[0] != '/')
            return raw; // already short
        if (raw.compare(0, 8, "/Script/") != 0 &&
            raw.compare(0, 6, "/Game/") != 0)
            return raw;
        // Strip everything before the last '.'
        size_t dot = raw.rfind('.');
        if (dot != std::string::npos)
            return raw.substr(dot + 1);
        // No dot — strip prefix up to last '/'
        size_t slash = raw.rfind('/');
        return (slash != std::string::npos) ? raw.substr(slash + 1) : raw;
    }

    static constexpr int32_t BULK_SCAN_UNSAFE_FLAGS =
        ue::RF_ClassDefaultObject |
        ue::RF_ArchetypeObject |
        ue::RF_NeedInitialization |
        ue::RF_NeedLoad |
        ue::RF_NeedPostLoad |
        ue::RF_NeedPostLoadSubobjects |
        ue::RF_BeginDestroyed |
        ue::RF_FinishDestroyed;

    static bool is_safe_bulk_scan_object(ue::UObject *obj)
    {
        if (!obj || !ue::is_valid_ptr(obj))
            return false;

        if (ue::uobj_get_flags(obj) & BULK_SCAN_UNSAFE_FLAGS)
            return false;

        std::string name = reflection::get_short_name(obj);
        if (name.empty() || ue::is_default_object(name.c_str()))
            return false;

        ue::UClass *cls = ue::uobj_get_class(obj);
        return cls && ue::is_valid_ptr(cls);
    }

    static void warn_bridge_bulk_scan(const char *api_name, int32_t live_count)
    {
        if (!adb_bridge::is_game_thread_command_active())
            return;

        logger::log_warn("LUA",
                         "%s running during live bridge command (%d live objects) — prefer targeted lookups when possible",
                         api_name, live_count);
    }

    // ═══ Pointer arithmetic helper ══════════════════════════════════════════
    static void *offset_ptr(void *base, int64_t offset)
    {
        return reinterpret_cast<void *>(reinterpret_cast<uintptr_t>(base) + offset);
    }

    // ═══ CallNative implementation — ARM64 ABI dispatch ═════════════════════
    // Uses inline assembly or function pointer casting to marshal args
    // Supports: p=pointer, i=int32, u=uint32, f=float, d=double, b=bool, v=void
    static sol::object call_native_impl(sol::this_state ts, void *addr,
                                        const std::string &sig, sol::variadic_args va)
    {
        sol::state_view lua(ts);

        if (!addr)
        {
            logger::log_error("LUA", "CallNative: null address");
            return sol::nil;
        }

        // Parse signature: first char is return type, rest are arg types
        // e.g. "v" = void(), "ip" = int32(ptr), "ppp" = ptr(ptr,ptr)
        char ret_type = (sig.empty()) ? 'v' : sig[0];
        std::string arg_types = (sig.size() > 1) ? sig.substr(1) : "";

        // Collect args into registers — ARM64 passes first 8 int/ptr in x0-x7, floats in d0-d7
        uint64_t x_regs[8] = {0};
        double d_regs[8] = {0};
        int x_idx = 0;
        int d_idx = 0;

        for (size_t i = 0; i < arg_types.size() && i < va.size(); i++)
        {
            char at = arg_types[i];
            sol::object arg = va[i];

            switch (at)
            {
            case 'p': // pointer / UObject*
                if (x_idx < 8)
                {
                    if (arg.is<lua_uobject::LuaUObject>())
                    {
                        x_regs[x_idx++] = reinterpret_cast<uint64_t>(arg.as<lua_uobject::LuaUObject &>().ptr);
                    }
                    else if (arg.is<void *>())
                    {
                        x_regs[x_idx++] = reinterpret_cast<uint64_t>(arg.as<void *>());
                    }
                    else if (arg.is<uint64_t>())
                    {
                        x_regs[x_idx++] = arg.as<uint64_t>();
                    }
                    else
                    {
                        x_regs[x_idx++] = 0;
                    }
                }
                break;

            case 'i': // int32
                if (x_idx < 8)
                {
                    x_regs[x_idx++] = static_cast<uint64_t>(static_cast<int64_t>(arg.as<int32_t>()));
                }
                break;

            case 'u': // uint32
                if (x_idx < 8)
                {
                    x_regs[x_idx++] = static_cast<uint64_t>(arg.as<uint32_t>());
                }
                break;

            case 'b': // bool
                if (x_idx < 8)
                {
                    x_regs[x_idx++] = arg.as<bool>() ? 1ULL : 0ULL;
                }
                break;

            case 'f': // float — passed in SIMD/FP registers on ARM64
                if (d_idx < 8)
                {
                    d_regs[d_idx++] = static_cast<double>(arg.as<float>());
                }
                break;

            case 'd': // double
                if (d_idx < 8)
                {
                    d_regs[d_idx++] = arg.as<double>();
                }
                break;

            default:
                if (x_idx < 8)
                    x_regs[x_idx++] = 0;
                break;
            }
        }

        // Call via function pointer casting based on arg count
        // ARM64 ABI: x0-x7 for int/ptr args, d0-d7 for float/double
        // We use a generic approach with typed casts for the common cases

        uint64_t result_int = 0;
        double result_float = 0.0;
        bool is_float_ret = (ret_type == 'f' || ret_type == 'd');

        // Common calling patterns — cast to appropriate function pointer type
        // This handles up to 8 integer arguments (most common case)
        typedef uint64_t (*fn_0)();
        typedef uint64_t (*fn_1)(uint64_t);
        typedef uint64_t (*fn_2)(uint64_t, uint64_t);
        typedef uint64_t (*fn_3)(uint64_t, uint64_t, uint64_t);
        typedef uint64_t (*fn_4)(uint64_t, uint64_t, uint64_t, uint64_t);
        typedef uint64_t (*fn_5)(uint64_t, uint64_t, uint64_t, uint64_t, uint64_t);
        typedef uint64_t (*fn_6)(uint64_t, uint64_t, uint64_t, uint64_t, uint64_t, uint64_t);
        typedef uint64_t (*fn_7)(uint64_t, uint64_t, uint64_t, uint64_t, uint64_t, uint64_t, uint64_t);
        typedef uint64_t (*fn_8)(uint64_t, uint64_t, uint64_t, uint64_t, uint64_t, uint64_t, uint64_t, uint64_t);

        // Guard the raw native call: a bad game function can stack-overflow/smash.
        // With the per-thread alt-stack the handler recovers via siglongjmp instead
        // of killing the game; we then return nil. FULL TOLERANCE for any callee.
        crash_handler::ensure_thread_sigaltstack();
        bool native_call_ok = safe_call::execute([&]()
        {
        if (!is_float_ret)
        {
            switch (x_idx)
            {
            case 0:
                result_int = ((fn_0)addr)();
                break;
            case 1:
                result_int = ((fn_1)addr)(x_regs[0]);
                break;
            case 2:
                result_int = ((fn_2)addr)(x_regs[0], x_regs[1]);
                break;
            case 3:
                result_int = ((fn_3)addr)(x_regs[0], x_regs[1], x_regs[2]);
                break;
            case 4:
                result_int = ((fn_4)addr)(x_regs[0], x_regs[1], x_regs[2], x_regs[3]);
                break;
            case 5:
                result_int = ((fn_5)addr)(x_regs[0], x_regs[1], x_regs[2], x_regs[3], x_regs[4]);
                break;
            case 6:
                result_int = ((fn_6)addr)(x_regs[0], x_regs[1], x_regs[2], x_regs[3], x_regs[4], x_regs[5]);
                break;
            case 7:
                result_int = ((fn_7)addr)(x_regs[0], x_regs[1], x_regs[2], x_regs[3], x_regs[4], x_regs[5], x_regs[6]);
                break;
            case 8:
                result_int = ((fn_8)addr)(x_regs[0], x_regs[1], x_regs[2], x_regs[3], x_regs[4], x_regs[5], x_regs[6], x_regs[7]);
                break;
            default:
                result_int = ((fn_8)addr)(x_regs[0], x_regs[1], x_regs[2], x_regs[3], x_regs[4], x_regs[5], x_regs[6], x_regs[7]);
                break;
            }
        }
        else
        {
            // Float return — use double-returning function pointers
            typedef double (*fn_f0)();
            typedef double (*fn_f1)(uint64_t);
            typedef double (*fn_f2)(uint64_t, uint64_t);
            typedef double (*fn_f3)(uint64_t, uint64_t, uint64_t);
            typedef double (*fn_f4)(uint64_t, uint64_t, uint64_t, uint64_t);

            switch (x_idx)
            {
            case 0:
                result_float = ((fn_f0)addr)();
                break;
            case 1:
                result_float = ((fn_f1)addr)(x_regs[0]);
                break;
            case 2:
                result_float = ((fn_f2)addr)(x_regs[0], x_regs[1]);
                break;
            case 3:
                result_float = ((fn_f3)addr)(x_regs[0], x_regs[1], x_regs[2]);
                break;
            default:
                result_float = ((fn_f4)addr)(x_regs[0], x_regs[1], x_regs[2], x_regs[3]);
                break;
            }
        }
        }, "CallNative").ok;
        if (!native_call_ok)
        {
            logger::log_error("LUA", "CallNative @ %p crashed (recovered via alt-stack guard) — returning nil", addr);
            return sol::nil;
        }

        // Return value based on ret_type
        switch (ret_type)
        {
        case 'v':
            return sol::nil;
        case 'i':
            return sol::make_object(lua, static_cast<int32_t>(result_int));
        case 'u':
            return sol::make_object(lua, static_cast<uint32_t>(result_int));
        case 'b':
            return sol::make_object(lua, result_int != 0);
        case 'p':
            return sol::make_object(lua, sol::lightuserdata_value(reinterpret_cast<void *>(result_int)));
        case 'f':
            return sol::make_object(lua, static_cast<float>(result_float));
        case 'd':
            return sol::make_object(lua, result_float);
        default:
            return sol::make_object(lua, sol::lightuserdata_value(reinterpret_cast<void *>(result_int)));
        }
    }

    // ═══ Register all global Lua API ════════════════════════════════════════
    void register_all(sol::state &lua)
    {

        // ── Logging ──────────────────────────────────────────────────────────
        lua.set_function("Log", [](const std::string &msg)
                         { logger::log_info("LUA", "%s", msg.c_str()); });

        lua.set_function("LogWarn", [](const std::string &msg)
                         { logger::log_warn("LUA", "%s", msg.c_str()); });

        lua.set_function("LogError", [](const std::string &msg)
                         { logger::log_error("LUA", "%s", msg.c_str()); });

        // ── Notifications ───────────────────────────────────────────────────
        lua.set_function("Notify", [](const std::string &title, const std::string &body,
                                      sol::optional<int> id)
                         {
        int nid = id.value_or(-1);
        if (nid < 0) {
            static std::atomic<int> s_auto_id{100};
            nid = s_auto_id.fetch_add(1);
        }
        notification::post(title, body, nid);
        logger::log_info("NOTIFY", "[%d] %s: %s", nid, title.c_str(), body.c_str()); });

        // ── Object finding ──────────────────────────────────────────────────
        lua.set_function("FindClass", [](sol::this_state ts, const std::string &raw_name) -> sol::object
                         {
        sol::state_view lua(ts);
        std::string name = normalize_class_name(raw_name);
        ue::UClass* cls = reflection::find_class_ptr(name);
        if (!cls) return sol::nil;
        return lua_uobject::wrap_or_nil(lua, reinterpret_cast<ue::UObject*>(cls)); });

        lua.set_function("FindObject", [](sol::this_state ts, const std::string &name) -> sol::object
                         {
        sol::state_view lua(ts);
        ue::UObject* obj = reflection::find_object_by_name(name);
        if (!obj) return sol::nil;
        return lua_uobject::wrap_or_nil(lua, obj); });

        lua.set_function("StaticFindObject", [](sol::this_state ts, const std::string &path) -> sol::object
                         {
        sol::state_view lua(ts);
        if (path.empty()) return sol::nil;
        // Use reflection-based path lookup (safe, no native function pointer needed)
        // This works on both UE4 and UE5, even with stripped binaries where
        // the native StaticFindObject offset may be wrong.
        ue::UObject* obj = reflection::find_object_by_path(path);
        if (!obj) return sol::nil;
        return lua_uobject::wrap_or_nil(lua, obj); });

        lua.set_function("StaticLoadClass", [](sol::this_state ts, const std::string &raw_base, const std::string &path) -> sol::object
                         {
        sol::state_view lua(ts);
        if (!symbols::StaticLoadClass) return sol::nil;
        if (path.empty()) return sol::nil;  // empty path would crash the engine

        // Find base class (normalize /Script/ prefix)
        ue::UClass* base = nullptr;
        if (!raw_base.empty()) {
            std::string base_class_name = normalize_class_name(raw_base);
            base = reflection::find_class_ptr(base_class_name);
        }

        std::u16string wpath(path.begin(), path.end());
        ue::UClass* loaded = nullptr;
        auto result = safe_call::execute([&]() {
            loaded = symbols::StaticLoadClass(base, nullptr, wpath.c_str(), nullptr, 0, nullptr);
        }, "StaticLoadClass");
        if (!result.ok) {
            logger::log_warn("LUA", "StaticLoadClass crashed for path '%s' — recovered via safe_call", path.c_str());
            return sol::nil;
        }
        if (!loaded) return sol::nil;
        return lua_uobject::wrap_or_nil(lua, reinterpret_cast<ue::UObject*>(loaded)); });

        lua.set_function("StaticLoadObject", [](sol::this_state ts, const std::string &raw_base, const std::string &path) -> sol::object
                         {
        sol::state_view lua(ts);
        if (!symbols::StaticLoadObject) return sol::nil;
        if (path.empty()) return sol::nil;  // empty path would crash the engine

        ue::UClass* base = nullptr;
        if (!raw_base.empty()) {
            std::string base_class_name = normalize_class_name(raw_base);
            base = reflection::find_class_ptr(base_class_name);
        }

        std::u16string wpath(path.begin(), path.end());
        ue::UObject* loaded = nullptr;
        auto result = safe_call::execute([&]() {
            loaded = symbols::StaticLoadObject(base, nullptr, wpath.c_str(), nullptr, 0, nullptr, false);
        }, "StaticLoadObject");
        if (!result.ok) {
            logger::log_warn("LUA", "StaticLoadObject crashed for path '%s' — recovered via safe_call", path.c_str());
            return sol::nil;
        }
        if (!loaded) return sol::nil;
        return lua_uobject::wrap_or_nil(lua, loaded); });

        // ── FindFirstOf — THE UE4SS equivalent ─────────────────────────────
        // FindFirstOf("ClassName") → returns the first live instance of the class
        // This is the #1 most-used UE4SS function. Mods rely on it heavily.
        lua.set_function("FindFirstOf", [](sol::this_state ts, const std::string &raw_class) -> sol::object
                         {
        sol::state_view lua(ts);
        std::string class_name = normalize_class_name(raw_class);
        ue::UObject* inst = nullptr;
        // Try rebuilder cache first (fast path)
        auto* rc = rebuilder::rebuild(class_name);
        if (rc) {
            inst = rc->get_first_instance();
        }
        // Always fall through to live GUObjectArray scan if not found
        // This handles classes not in boot-time reflection cache (e.g. DebugMenu_C)
        if (!inst) {
            inst = reflection::find_first_instance(class_name);
        }
        if (!inst) return sol::nil;
        return lua_uobject::wrap_or_nil(lua, inst); });

        // ── FindObjectByType — robust first-instance search by class/type ───
        // FindObjectByType("ClassName", include_subclasses=true)
        // Returns the first live object whose class matches the requested type.
        // This is tolerant to BP_Class vs BP_Class_C naming and supports IsA chain walk.
        lua.set_function("FindObjectByType", [](sol::this_state ts, const std::string &raw_class, sol::optional<bool> include_subclasses_opt) -> sol::object
                         {
        sol::state_view lua(ts);
        std::string class_name = normalize_class_name(raw_class);
        bool include_subclasses = include_subclasses_opt.value_or(true);

        if (!include_subclasses) {
            ue::UObject* inst = reflection::find_first_instance(class_name);
            if (!inst) return sol::nil;
            return lua_uobject::wrap_or_nil(lua, inst);
        }

        ue::UClass* target_cls = reflection::find_class_ptr(class_name);
        if (!target_cls) target_cls = reflection::find_class_ptr(class_name + "_C");
        if (!target_cls) return sol::nil;

        int32_t count = reflection::get_live_object_count();
        for (int32_t i = 0; i < count; i++) {
            ue::UObject* obj = reflection::get_object_by_index(i);
            if (!is_safe_bulk_scan_object(obj)) continue;

            ue::UClass* cls = ue::uobj_get_class(obj);
            while (cls) {
                if (cls == target_cls) {
                    return lua_uobject::wrap_or_nil(lua, obj);
                }
                cls = reinterpret_cast<ue::UClass*>(
                    ue::ustruct_get_super(reinterpret_cast<ue::UStruct*>(cls)));
            }
        }

        return sol::nil; });

        // ── FindAllOf — returns ALL live instances of a class ────────────────
        // When use_isa=true, also matches subclasses (IsA-style hierarchy walk).
        lua.set_function("FindAllOf", [](sol::this_state ts, const std::string &raw_class, sol::optional<bool> use_isa_opt) -> sol::object
                         {
        sol::state_view lua(ts);
        bool use_isa = use_isa_opt.value_or(false);
        std::string class_name = normalize_class_name(raw_class);
        std::vector<ue::UObject*> instances;

        if (use_isa) {
            // Walk GUObjectArray and include any object whose class chain contains target
            ue::UClass* target_cls = reflection::find_class_ptr(class_name);
            if (!target_cls) target_cls = reflection::find_class_ptr(class_name + "_C");
            if (!target_cls) return sol::nil;

            int32_t count = reflection::get_live_object_count();
            warn_bridge_bulk_scan("FindAllOf(..., true)", count);
            for (int32_t i = 0; i < count; i++) {
                ue::UObject* obj = reflection::get_object_by_index(i);
                if (!is_safe_bulk_scan_object(obj)) continue;
                ue::UClass* cls = ue::uobj_get_class(obj);
                while (cls) {
                    if (cls == target_cls) { instances.push_back(obj); break; }
                    cls = reinterpret_cast<ue::UClass*>(
                        ue::ustruct_get_super(reinterpret_cast<ue::UStruct*>(cls)));
                }
            }
        } else {
            // Exact match: try rebuilder cache first (fast path)
            auto* rc = rebuilder::rebuild(class_name);
            if (rc) {
                instances = rc->get_all_instances();
            }
            // Always fall through to live GUObjectArray scan if empty
            if (instances.empty()) {
                instances = reflection::find_all_instances(class_name);
            }
        }

        if (instances.empty()) return sol::nil;
        sol::table t = lua.create_table();
        int i = 1;
        for (auto* obj : instances) {
            if (obj && ue::is_valid_ptr(obj)) {
                lua_uobject::LuaUObject wrapped;
                wrapped.ptr = obj;
                t[i++] = wrapped;
            }
        }
        return sol::make_object(lua, t); });

        // ── ExecuteInGameThread — queues a function to run on the game thread ─
        // The queue is drained on every ProcessEvent call (which IS the game thread).
        // This is essential for UE4SS-style mods that need thread safety.
        lua.set_function("ExecuteInGameThread", [](sol::function callback)
                         { pe_hook::queue_game_thread([callback]()
                                                      {
            auto result = callback();
            if (!result.valid()) {
                sol::error err = result;
                logger::log_error("LUA", "ExecuteInGameThread callback error: %s", err.what());
            } }); });

        // ── NotifyOnNewObject — fires when a new instance of ClassName spawns ─
        // Registers targeted hooks on ReceiveBeginPlay/BeginPlay (NOT a global hook).
        // This is dramatically faster than the old global post-hook approach which
        // fired Lua on EVERY single ProcessEvent call.
        // callback(newObject) — receives the newly created UObject.
        lua.set_function("NotifyOnNewObject", [](sol::this_state ts, sol::this_environment te, sol::object class_obj, sol::object cb_obj) -> uint64_t
                         {
        // Validate arguments — MUST NOT crash on nil/wrong types
        if (!class_obj.is<std::string>()) {
            logger::log_error("LUA", "NotifyOnNewObject: first argument must be a string (got %s)",
                              lua_typename(ts, (int)class_obj.get_type()));
            return 0;
        }
        if (!cb_obj.is<sol::function>()) {
            logger::log_error("LUA", "NotifyOnNewObject: second argument must be a function (got %s)",
                              lua_typename(ts, (int)cb_obj.get_type()));
            return 0;
        }
        std::string raw_class = class_obj.as<std::string>();
        sol::function callback = cb_obj.as<sol::function>();

        std::string cls_filter = normalize_class_name(raw_class);
        if (cls_filter != raw_class) {
            logger::log_info("LUA", "NotifyOnNewObject: normalized class '%s' → '%s'",
                             raw_class.c_str(), cls_filter.c_str());
        }

        // Hook ReceiveBeginPlay (Blueprint) — this fires for most spawned actors
        std::string bp_path = cls_filter + ":ReceiveBeginPlay";
        auto bp_id = pe_hook::register_post(bp_path,
            [cls_filter, callback](ue::UObject* self, ue::UFunction* func, void* parms) {
                if (!self) return;
                // Verify class match — walk super chain for subclass support
                // e.g. hook on VR4GamePlayerPawn should fire for VR4Bio4PlayerPawn
                ue::UClass* cls = ue::uobj_get_class(self);
                if (!cls) return;
                bool match = false;
                ue::UStruct* walk = reinterpret_cast<ue::UStruct*>(cls);
                int depth = 0;
                while (walk && ue::is_valid_ptr(walk) && depth < 30) {
                    std::string name = reflection::get_short_name(
                        reinterpret_cast<const ue::UObject*>(walk));
                    if (name == cls_filter) { match = true; break; }
                    walk = ue::ustruct_get_super(walk);
                    depth++;
                }
                if (!match) return;
                lua_uobject::LuaUObject wrapped;
                wrapped.ptr = self;
                auto result = callback(wrapped);
                if (!result.valid()) {
                    sol::error err = result;
                    logger::log_error("LUA", "NotifyOnNewObject(%s) error: %s",
                                      cls_filter.c_str(), err.what());
                }
            });

        // Also hook native BeginPlay as fallback for C++ actors
        std::string native_path = cls_filter + ":BeginPlay";
        auto native_id = pe_hook::register_post(native_path,
            [cls_filter, callback](ue::UObject* self, ue::UFunction* func, void* parms) {
                if (!self) return;
                ue::UClass* cls = ue::uobj_get_class(self);
                if (!cls) return;
                bool match = false;
                ue::UStruct* walk = reinterpret_cast<ue::UStruct*>(cls);
                int depth = 0;
                while (walk && ue::is_valid_ptr(walk) && depth < 30) {
                    std::string name = reflection::get_short_name(
                        reinterpret_cast<const ue::UObject*>(walk));
                    if (name == cls_filter) { match = true; break; }
                    walk = ue::ustruct_get_super(walk);
                    depth++;
                }
                if (!match) return;
                lua_uobject::LuaUObject wrapped;
                wrapped.ptr = self;
                auto result = callback(wrapped);
                if (!result.valid()) {
                    sol::error err = result;
                    logger::log_error("LUA", "NotifyOnNewObject(%s/BeginPlay) error: %s",
                                      cls_filter.c_str(), err.what());
                }
            });

        std::string owning_mod = mod_from_env(te);
        mod_tracker::track_pe_hook(owning_mod, bp_id);
        mod_tracker::track_pe_hook(owning_mod, native_id);
        logger::log_info("LUA", "NotifyOnNewObject: %s -> targeted hooks on ReceiveBeginPlay + BeginPlay",
                         cls_filter.c_str());
        return bp_id; });

        lua.set_function("GetCDO", [](sol::this_state ts, const std::string &raw_class) -> sol::object
                         {
        sol::state_view lua(ts);
        std::string class_name = normalize_class_name(raw_class);
        ue::UObject* cdo = rebuilder::get_cdo(class_name);
        if (!cdo) return sol::nil;
        // CDO is read-only intent — wrap without filtering Default__ prefix
        lua_uobject::LuaUObject wrapped;
        wrapped.ptr = cdo;
        return sol::make_object(lua, wrapped); });

        lua.set_function("GetWorldContext", [](sol::this_state ts) -> sol::object
                         {
        sol::state_view lua(ts);
        if (!symbols::GWorld) return sol::nil;
        ue::UObject* world = *reinterpret_cast<ue::UObject**>(symbols::GWorld);
        if (!world) return sol::nil;
        return lua_uobject::wrap_or_nil(lua, world); });

        // ── Object construction ─────────────────────────────────────────────
        lua.set_function("ConstructObject", [](sol::this_state ts, sol::object class_arg, sol::optional<sol::object> outer_arg, sol::optional<std::string> name_arg) -> sol::object
                         {
        sol::state_view lua(ts);
        if (!symbols::StaticConstructObject) {
            logger::log_error("LUA", "ConstructObject: StaticConstructObject_Internal not resolved");
            return sol::nil;
        }

        ue::UClass* cls = nullptr;
        if (class_arg.is<lua_uobject::LuaUObject>()) {
            cls = reinterpret_cast<ue::UClass*>(class_arg.as<lua_uobject::LuaUObject&>().ptr);
        } else if (class_arg.is<std::string>()) {
            cls = reflection::find_class_ptr(class_arg.as<std::string>());
        }

        if (!cls) {
            logger::log_error("LUA", "ConstructObject: class is null");
            return sol::nil;
        }

        ue::UObject* outer = nullptr;
        if (outer_arg && outer_arg->is<lua_uobject::LuaUObject>()) {
            outer = outer_arg->as<lua_uobject::LuaUObject&>().ptr;
        }

        // Use GetTransientPackage as default outer
        if (!outer && symbols::GetTransientPackage) {
            outer = symbols::GetTransientPackage();
        }

        // FName NAME_None = {0, 0}
        ue::FName fname_none = {0, 0};

        ue::UObject* constructed = symbols::StaticConstructObject(
            cls, outer, fname_none, 0, 0, nullptr, false, nullptr, false);

        if (!constructed) {
            logger::log_error("LUA", "ConstructObject: returned null");
            return sol::nil;
        }

        logger::log_info("LUA", "ConstructObject: created instance of %s @ 0x%lX",
                          reflection::get_short_name(reinterpret_cast<const ue::UObject*>(cls)).c_str(),
                          (unsigned long)reinterpret_cast<uintptr_t>(constructed));

        return lua_uobject::wrap_or_nil(lua, constructed); });

        // ── EnableCheatsAsync — construct CheatManager on a background thread ─
        // EnableCheats is a NO-OP in shipping builds (returns instantly).
        // So we directly call StaticConstructObject_Internal to create the
        // CheatManager, then write it to PC->CheatManager via property offset.
        // The bg thread avoids the game-thread deadlock caused by
        // StaticConstructObject_Internal's busy-wait for async loading.
        lua.set_function("EnableCheatsAsync", [](sol::this_state ts, sol::optional<sol::object> pc_arg) -> bool
                         {
        // 1. Find or accept the PlayerController
        ue::UObject* pc = nullptr;
        if (pc_arg && pc_arg->is<lua_uobject::LuaUObject>()) {
            pc = pc_arg->as<lua_uobject::LuaUObject&>().ptr;
        }
        if (!pc) {
            auto* rc = rebuilder::rebuild("BP_PlayerController_C");
            if (rc) pc = rc->get_first_instance();
        }
        if (!pc) {
            auto* rc = rebuilder::rebuild("PFXPlayerController");
            if (rc) pc = rc->get_first_instance();
        }
        if (!pc) {
            auto* rc = rebuilder::rebuild("PlayerController");
            if (rc) pc = rc->get_first_instance();
        }
        if (!pc) pc = reflection::find_first_instance("PlayerController");
        if (!pc) {
            logger::log_error("LUA", "EnableCheatsAsync: No PlayerController found");
            return false;
        }

        // 2. Check if CheatManager already exists on the PC
        std::string pc_class_name = reflection::get_short_name(reinterpret_cast<const ue::UObject*>(ue::uobj_get_class(pc)));
        auto* rc = rebuilder::rebuild(pc_class_name);
        if (!rc) {
            // fallback to PlayerController
            rc = rebuilder::rebuild("PlayerController");
        }
        if (!rc) {
            logger::log_error("LUA", "EnableCheatsAsync: cannot rebuild PC class '%s'",
                              pc_class_name.c_str());
            return false;
        }

        auto* cm_prop = rc->find_property("CheatManager");
        if (!cm_prop) {
            logger::log_error("LUA", "EnableCheatsAsync: CheatManager property not found on %s",
                              pc_class_name.c_str());
            return false;
        }

        // Read current CheatManager pointer
        uintptr_t pc_addr = reinterpret_cast<uintptr_t>(pc);
        ue::UObject** cm_ptr = reinterpret_cast<ue::UObject**>(pc_addr + cm_prop->offset);
        if (*cm_ptr && ue::is_valid_ptr(*cm_ptr)) {
            logger::log_info("LUA", "EnableCheatsAsync: CheatManager already exists @ %p",
                             (void*)*cm_ptr);
            return true;
        }

        // 3. Find CheatClass on the PC (or resolve it ourselves)
        ue::UClass* cheat_class = nullptr;
        auto* cc_prop = rc->find_property("CheatClass");
        if (cc_prop) {
            ue::UClass** cc_ptr = reinterpret_cast<ue::UClass**>(pc_addr + cc_prop->offset);
            if (*cc_ptr && ue::is_valid_ptr(reinterpret_cast<ue::UObject*>(*cc_ptr))) {
                cheat_class = *cc_ptr;
                logger::log_info("LUA", "EnableCheatsAsync: CheatClass from PC = %p (%s)",
                                 (void*)cheat_class,
                                 reflection::get_short_name(reinterpret_cast<ue::UObject*>(cheat_class)).c_str());
            }
        }
        // If CheatClass is null, find it via reflection
        if (!cheat_class) {
            cheat_class = reinterpret_cast<ue::UClass*>(
                reflection::find_class_ptr("BP_CheatManager_C"));
        }
        if (!cheat_class) {
            cheat_class = reinterpret_cast<ue::UClass*>(
                reflection::find_class_ptr("PFXCheatManager"));
        }
        if (!cheat_class) {
            logger::log_error("LUA", "EnableCheatsAsync: cannot find CheatManager class");
            return false;
        }

        // 4. Verify StaticConstructObject is available
        if (!symbols::StaticConstructObject) {
            logger::log_error("LUA", "EnableCheatsAsync: StaticConstructObject_Internal not resolved");
            return false;
        }

        logger::log_info("LUA", "EnableCheatsAsync: Spawning bg thread — "
                         "PC=%p CheatClass=%p cm_offset=0x%X",
                         (void*)pc, (void*)cheat_class, cm_prop->offset);

        // 5. Spawn background thread — directly construct CheatManager
        // This is what Frida did: call StaticConstructObject from non-game thread
        uint32_t cm_offset = cm_prop->offset;
        std::thread([pc, cheat_class, cm_offset]() {
            logger::log_info("LUA", "EnableCheatsAsync: [BG] calling StaticConstructObject_Internal...");

            // ABI-correct construction: params-struct on UE4.26+, multi-arg on legacy.
            // (Previously this called the multi-arg ABI unconditionally, which on UE5
            // scribbled a UClass* as if it were an FStaticConstructObjectParameters& and
            // crashed at fault 0x10. construct_object() picks the right ABI.)
            ue::UObject* new_cm = symbols::construct_object(cheat_class, pc);

            if (!new_cm) {
                logger::log_error("LUA", "EnableCheatsAsync: [BG] StaticConstructObject returned NULL!");
                return;
            }

            logger::log_info("LUA", "EnableCheatsAsync: [BG] CheatManager created @ %p (%s)",
                             (void*)new_cm,
                             reflection::get_short_name(reinterpret_cast<const ue::UObject*>(ue::uobj_get_class(new_cm))).c_str());

            // Write CheatManager pointer on the PC
            uintptr_t pc_addr = reinterpret_cast<uintptr_t>(pc);
            ue::UObject** cm_slot = reinterpret_cast<ue::UObject**>(pc_addr + cm_offset);
            *cm_slot = new_cm;
            logger::log_info("LUA", "EnableCheatsAsync: [BG] PC->CheatManager set to %p", (void*)new_cm);

            // Call InitCheatManager via ProcessEvent (if UFunction exists)
            auto* init_func = pe_hook::resolve_func_path("CheatManager:InitCheatManager");
            if (init_func) {
                logger::log_info("LUA", "EnableCheatsAsync: [BG] dispatching InitCheatManager on game thread...");
                pe_hook::invoke_game_thread_sync(new_cm, init_func, nullptr,
                                                 "LUA", "EnableCheatsAsync.InitCheatManager", 8000);
                logger::log_info("LUA", "EnableCheatsAsync: [BG] InitCheatManager dispatched");
            }
        }).detach();

        return true; });

        // ── CallAsync — call UFunction(s) on a background thread ────────────
        // Some UE4 functions internally busy-wait (StaticConstructObject, saves, etc.)
        // and DEADLOCK the game thread. CallAsync runs them on a bg thread.
        // Usage: CallAsync(obj, "FunctionName") — single function
        //        CallAsync(obj, {"Func1", "Func2", ...}) — multiple functions
        lua.set_function("CallAsync", [](sol::this_state ts, sol::object obj_arg, sol::object func_arg) -> bool
                         {
        if (!obj_arg.is<lua_uobject::LuaUObject>()) {
            logger::log_error("LUA", "CallAsync: first arg must be a UObject");
            return false;
        }
        ue::UObject* obj = obj_arg.as<lua_uobject::LuaUObject&>().ptr;
        if (!obj || !ue::is_valid_ptr(obj)) {
            logger::log_error("LUA", "CallAsync: object is null/invalid");
            return false;
        }

        // Collect function names
        std::vector<std::string> func_names;
        if (func_arg.is<std::string>()) {
            func_names.push_back(func_arg.as<std::string>());
        } else if (func_arg.is<sol::table>()) {
            sol::table t = func_arg.as<sol::table>();
            for (auto& kv : t) {
                if (kv.second.is<std::string>()) {
                    func_names.push_back(kv.second.as<std::string>());
                }
            }
        } else {
            logger::log_error("LUA", "CallAsync: second arg must be string or table of strings");
            return false;
        }

        if (func_names.empty()) {
            logger::log_error("LUA", "CallAsync: no function names provided");
            return false;
        }

        // Resolve the object's class to find UFunctions
        std::string class_name = reflection::get_short_name(
            reinterpret_cast<const ue::UObject*>(ue::uobj_get_class(obj)));
        auto* rc = rebuilder::rebuild(class_name);

        // Resolve all UFunctions upfront (on game thread, safe)
        struct FuncCall {
            std::string name;
            ue::UFunction* func;
        };
        std::vector<FuncCall> calls;
        for (auto& fn : func_names) {
            ue::UFunction* uf = nullptr;
            // Try class:Function first
            if (rc) {
                auto* rf = rc->find_function(fn);
                if (rf) uf = rf->raw;
            }
            // Try direct resolve
            if (!uf) uf = pe_hook::resolve_func_path(class_name + ":" + fn);
            // Try parent classes
            if (!uf) uf = pe_hook::resolve_func_path("CheatManager:" + fn);
            if (!uf) uf = pe_hook::resolve_func_path("PlayerController:" + fn);

            if (uf) {
                calls.push_back({fn, uf});
            } else {
                logger::log_warn("LUA", "CallAsync: could not resolve '%s' on %s — skipping",
                                 fn.c_str(), class_name.c_str());
            }
        }

        if (calls.empty()) {
            logger::log_error("LUA", "CallAsync: no functions could be resolved");
            return false;
        }

        logger::log_info("LUA", "CallAsync: queueing %zu call(s) on game thread for %s @ %p",
                         calls.size(), class_name.c_str(), (void *)obj);

        pe_hook::queue_game_thread([obj, calls, class_name]() {
            auto original_pe = pe_hook::get_original();
            if (!original_pe)
                original_pe = symbols::ProcessEvent;
            if (!original_pe)
            {
                logger::log_error("LUA", "CallAsync: ProcessEvent not resolved on game thread");
                return;
            }
            for (auto& c : calls) {
                logger::log_info("LUA", "CallAsync: [GT] %s:%s...", class_name.c_str(), c.name.c_str());
                original_pe(obj, c.func, nullptr);
                logger::log_info("LUA", "CallAsync: [GT] %s:%s done", class_name.c_str(), c.name.c_str());
            }
            logger::log_info("LUA", "CallAsync: [GT] all %zu call(s) complete", calls.size());
        });

        return true; });

        // ── UObject from raw pointer ────────────────────────────────────────
        lua.set_function("UObjectFromPtr", [](sol::this_state ts, void *ptr) -> sol::object
                         {
        sol::state_view lua(ts);
        ue::UObject* obj = reinterpret_cast<ue::UObject*>(ptr);
        return lua_uobject::wrap_or_nil(lua, obj); });

        // ── Widget creation via WidgetBlueprintLibrary::Create ──────────────
        // CreateWidget(className [, owningPlayer]) → UserWidget or Widget instance
        // For UserWidget subclasses: uses WBL::Create (proper blueprint init)
        // For other widgets (TextBlock, Image, etc.): uses NewObject (ConstructObject)
        lua.set_function("CreateWidget", [](sol::this_state ts, sol::object class_arg, sol::optional<sol::object> owner_arg) -> sol::object
                         {
        sol::state_view lua(ts);

        // 1. Resolve the widget class
        ue::UClass* widget_cls = nullptr;
        std::string cls_name_str;
        if (class_arg.is<lua_uobject::LuaUObject>()) {
            widget_cls = reinterpret_cast<ue::UClass*>(class_arg.as<lua_uobject::LuaUObject&>().ptr);
            cls_name_str = reflection::get_short_name(reinterpret_cast<const ue::UObject*>(widget_cls));
        } else if (class_arg.is<std::string>()) {
            cls_name_str = class_arg.as<std::string>();
            widget_cls = reflection::find_class_ptr(cls_name_str);
        }
        if (!widget_cls) {
            logger::log_error("LUA", "CreateWidget: class '%s' not found", cls_name_str.c_str());
            return sol::nil;
        }

        // 2. Check if the class is a UserWidget subclass by walking the hierarchy
        bool is_user_widget = false;
        {
            ue::UStruct* walk = reinterpret_cast<ue::UStruct*>(widget_cls);
            while (walk) {
                std::string name = reflection::get_short_name(reinterpret_cast<const ue::UObject*>(walk));
                if (name == "UserWidget") {
                    is_user_widget = true;
                    break;
                }
                walk = ue::ustruct_get_super(walk);
            }
        }

        // 3. For NON-UserWidget types (TextBlock, Image, VerticalBox, etc.),
        //    these are Slate-backed UMG widgets that require proper initialization
        //    via the widget subsystem. StaticConstructObject/NewObject creates a bare
        //    UObject without Slate init, causing SIGSEGV when the engine touches it.
        //    SAFETY: Refuse creation and return nil with a clear error message.
        if (!is_user_widget) {
            // Check if it's at least a Widget subclass (so the error is helpful)
            bool is_widget = false;
            {
                ue::UStruct* walk = reinterpret_cast<ue::UStruct*>(widget_cls);
                while (walk) {
                    std::string name = reflection::get_short_name(reinterpret_cast<const ue::UObject*>(walk));
                    if (name == "Widget") {
                        is_widget = true;
                        break;
                    }
                    walk = ue::ustruct_get_super(walk);
                }
            }

            if (is_widget) {
                logger::log_error("LUA", "CreateWidget: '%s' is a native UMG Widget (not UserWidget). "
                                  "Cannot create via NewObject — requires Slate initialization. "
                                  "Only UserWidget subclasses (Blueprint widgets) can be created.",
                                  cls_name_str.c_str());
            } else {
                logger::log_error("LUA", "CreateWidget: '%s' is not a Widget subclass at all",
                                  cls_name_str.c_str());
            }
            return sol::nil;
        }

        // ── UserWidget path: use WidgetBlueprintLibrary::Create ──

        // 4. Find WidgetBlueprintLibrary CDO and its Create function
        ue::UObject* wbl_cdo = rebuilder::get_cdo("WidgetBlueprintLibrary");
        if (!wbl_cdo) {
            logger::log_error("LUA", "CreateWidget: WidgetBlueprintLibrary CDO not found");
            return sol::nil;
        }
        auto* rc = rebuilder::rebuild("WidgetBlueprintLibrary");
        if (!rc) {
            logger::log_error("LUA", "CreateWidget: cannot rebuild WidgetBlueprintLibrary");
            return sol::nil;
        }
        auto* rf = rc->find_function("Create");
        if (!rf || !rf->raw) {
            logger::log_error("LUA", "CreateWidget: Create function not found on WBL");
            return sol::nil;
        }

        // 5. Get owning player (required for blueprint UserWidgets).
        //    WBL::Create needs a valid APlayerController — UWorld itself does NOT work
        //    as WorldContextObject because GetWorld() returns null on raw UWorld.
        ue::UObject* player = nullptr;
        if (owner_arg && owner_arg->is<lua_uobject::LuaUObject>()) {
            player = owner_arg->as<lua_uobject::LuaUObject&>().ptr;
        }

        // Auto-find PlayerController if none provided
        if (!player) {
            auto* pc_rc = rebuilder::rebuild("PlayerController");
            if (pc_rc) {
                player = pc_rc->get_first_instance();
            }
        }
        // Fallback: try known game-specific controller class names
        if (!player) {
            for (const char* ctrl_name : {"BP_PlayerController_C", "VR4PlayerController_BP_C", "PFXPlayerController_C", "PFXPlayerController"}) {
                auto* rc2 = rebuilder::rebuild(ctrl_name);
                if (rc2) {
                    player = rc2->get_first_instance();
                    if (player) break;
                }
            }
        }

        if (!player) {
            logger::log_error("LUA", "CreateWidget: no PlayerController found — cannot create '%s'", cls_name_str.c_str());
            return sol::nil;
        }

        // WorldContextObject must be the PlayerController (an Actor whose GetWorld() works),
        // NOT the raw UWorld pointer.
        ue::UObject* world_ctx = player;

        // 7. Set up params buffer and call ProcessEvent
        ue::UFunction* func = static_cast<ue::UFunction*>(rf->raw);
        uint16_t parms_size = ue::ufunc_get_parms_size(func);
        std::vector<uint8_t> params_buf(parms_size, 0);

        for (const auto& pi : rf->params) {
            if (!(pi.flags & ue::CPF_Parm) || (pi.flags & ue::CPF_ReturnParm)) continue;
            uint8_t* p = params_buf.data() + pi.offset;

            if (pi.name == "WorldContextObject") {
                *reinterpret_cast<ue::UObject**>(p) = world_ctx;
            } else if (pi.name == "WidgetType") {
                *reinterpret_cast<ue::UClass**>(p) = widget_cls;
            } else if (pi.name == "OwningPlayer") {
                *reinterpret_cast<ue::UObject**>(p) = player;
            }
        }

        logger::log_info("LUA", "CreateWidget: calling WBL::Create for '%s' (world_ctx=%p, player=%p)",
                          cls_name_str.c_str(), world_ctx, player);
        if (!pe_hook::invoke_game_thread_sync(wbl_cdo, func, params_buf.data(),
                                              "LUA", "CreateWidget.WBL.Create", 8000)) {
            logger::log_error("LUA", "CreateWidget: WBL::Create dispatch failed for '%s'", cls_name_str.c_str());
            return sol::nil;
        }

        // 8. Extract return value
        if (rf->return_prop && rf->return_prop->raw) {
            const uint8_t* ret_ptr = params_buf.data() + rf->return_offset;
            ue::UObject* created = *reinterpret_cast<ue::UObject* const*>(ret_ptr);
            logger::log_info("LUA", "CreateWidget: return_offset=%u raw_ptr=%p valid=%d",
                              (unsigned)rf->return_offset, created, created ? (int)ue::is_valid_ptr(created) : 0);
            if (created && ue::is_valid_ptr(created)) {
                std::string result_cls = reflection::get_short_name(
                    reinterpret_cast<const ue::UObject*>(ue::uobj_get_class(created)));
                logger::log_info("LUA", "CreateWidget: created %s @ 0x%lX (WBL::Create)",
                                  result_cls.c_str(),
                                  (unsigned long)reinterpret_cast<uintptr_t>(created));
                lua_uobject::LuaUObject wrapped;
                wrapped.ptr = created;
                return sol::make_object(lua, wrapped);
            }
        } else {
            logger::log_error("LUA", "CreateWidget: no return_prop found for WBL::Create — parms_size=%u return_offset=%u",
                               (unsigned)parms_size, (unsigned)rf->return_offset);
        }

        logger::log_error("LUA", "CreateWidget: WBL::Create returned null for '%s'", cls_name_str.c_str());
        return sol::nil; });

        // ── Class Rebuild API ───────────────────────────────────────────────
        lua.set_function("RebuildClass", [](sol::this_state ts, const std::string &name) -> sol::object
                         {
        sol::state_view lua(ts);
        auto* rc = rebuilder::rebuild(name);
        if (!rc) return sol::nil;

        // Return a table representing the rebuilt class with methods
        sol::table cls_table = lua.create_table();
        cls_table["__name"] = rc->name;
        cls_table["__parent"] = rc->parent_name;
        cls_table["__raw"] = sol::lightuserdata_value(rc->raw);

        cls_table["GetInstance"] = [rc](sol::this_state ts2, sol::optional<int> index) -> sol::object {
            sol::state_view lua2(ts2);
            ue::UObject* inst = index ? rc->get_instance(*index) : rc->get_first_instance();
            return lua_uobject::wrap_or_nil(lua2, inst);
        };

        cls_table["GetAllInstances"] = [rc](sol::this_state ts2) -> sol::table {
            sol::state_view lua2(ts2);
            auto instances = rc->get_all_instances();
            sol::table t = lua2.create_table();
            int i = 1;
            for (auto* obj : instances) {
                lua_uobject::LuaUObject wrapped;
                wrapped.ptr = obj;
                t[i++] = wrapped;
            }
            return t;
        };

        cls_table["InstanceCount"] = [rc]() -> int {
            return rc->instance_count();
        };

        cls_table["HasProp"] = [rc](const std::string& prop_name) -> bool {
            return rc->has_property(prop_name);
        };

        cls_table["HasFunc"] = [rc](const std::string& func_name) -> bool {
            return rc->has_function(func_name);
        };

        cls_table["Properties"] = [rc](sol::this_state ts2) -> sol::table {
            sol::state_view lua2(ts2);
            sol::table t = lua2.create_table();
            for (auto& p : rc->all_properties) {
                sol::table prop_info = lua2.create_table();
                prop_info["name"] = p.name;
                prop_info["offset"] = p.offset;
                prop_info["type"] = p.type_name;
                prop_info["size"] = p.element_size;
                t[p.name] = prop_info;
            }
            return t;
        };

        cls_table["Functions"] = [rc](sol::this_state ts2) -> sol::table {
            sol::state_view lua2(ts2);
            sol::table t = lua2.create_table();
            for (auto& f : rc->all_functions) {
                sol::table func_info = lua2.create_table();
                func_info["name"] = f.name;
                func_info["flags"] = f.flags;
                func_info["parms_size"] = f.parms_size;
                func_info["num_parms"] = f.num_parms;
                t[f.name] = func_info;
            }
            return t;
        };

        cls_table["HookProp"] = [name](const std::string& prop_name, sol::function callback) -> uint64_t {
            return rebuilder::hook_property(name, prop_name,
                [callback](ue::UObject* obj, const std::string& pn, void* old_val, void* new_val) -> bool {
                    lua_uobject::LuaUObject wrapped;
                    wrapped.ptr = obj;
                    auto result = callback(wrapped, pn);
                    if (result.valid() && result.get_type() == sol::type::boolean) {
                        return result.get<bool>();
                    }
                    return false;
                });
        };

        cls_table["HookFunc"] = [name](const std::string& func_name,
                                         sol::object pre_obj,
                                         sol::object post_obj) -> uint64_t {
            rebuilder::FuncPreCallback pre_cb = nullptr;
            rebuilder::FuncPostCallback post_cb = nullptr;

            if (pre_obj.is<sol::function>()) {
                sol::function pre_fn = pre_obj.as<sol::function>();
                pre_cb = [pre_fn](ue::UObject* self, ue::UFunction* func, void* parms) -> bool {
                    lua_uobject::LuaUObject wrapped;
                    wrapped.ptr = self;
                    auto result = pre_fn(wrapped);
                    if (result.valid()) {
                        if (result.get_type() == sol::type::string) {
                            std::string s = result;
                            if (s == "BLOCK") return true;
                        }
                        if (result.get_type() == sol::type::boolean) {
                            return result.get<bool>();
                        }
                    }
                    return false;
                };
            }

            if (post_obj.is<sol::function>()) {
                sol::function post_fn = post_obj.as<sol::function>();
                post_cb = [post_fn](ue::UObject* self, ue::UFunction* func, void* parms) {
                    lua_uobject::LuaUObject wrapped;
                    wrapped.ptr = self;
                    post_fn(wrapped);
                };
            }

            return rebuilder::hook_function(name, func_name, pre_cb, post_cb);
        };

        return sol::make_object(lua, cls_table); });

        // ── ProcessEvent hooks (UE4SS-style RegisterHook) ───────────────────
        // RegisterHook supports multiple formats:
        //   "ClassName:FunctionName"              — hooks a specific UFunction
        //   "/Script/Module.ClassName:FuncName"   — UE4SS full path (auto-parsed)
        //   "Tick"                                — fires every game tick
        //
        // Callback signature: function(Context, ...)
        //   Context is a table with :get() that returns the UObject self.
        //   This matches UE4SS convention where mods write:
        //     RegisterHook("/Script/Phoenix.SpellTool:Start", function(Context, loc)
        //         local self = Context:get()
        //     end)
        // RegisterHook — UE4SS-compatible: returns (PreId, PostId)
        // Registers BOTH pre and post hooks. Callback fires on POST.
        // Pre-hook is a no-op by default but can be accessed via the PreId.
        // Callback signature: function(Context, ...) where Context:get() → self UObject
        lua.set_function("RegisterHook", [](sol::this_state ts, sol::this_environment te, sol::object path_obj, sol::object cb_obj) -> std::tuple<uint64_t, uint64_t>
                         {
        sol::state_view lua(ts);
        std::string owning_mod = mod_from_env(te);

        // Validate arguments — MUST NOT crash on nil/wrong types
        if (!path_obj.is<std::string>()) {
            logger::log_error("LUA", "RegisterHook: first argument must be a string (got %s)",
                              lua_typename(ts, (int)path_obj.get_type()));
            return std::make_tuple((uint64_t)0, (uint64_t)0);
        }
        if (!cb_obj.is<sol::function>()) {
            logger::log_error("LUA", "RegisterHook: second argument must be a function (got %s)",
                              lua_typename(ts, (int)cb_obj.get_type()));
            return std::make_tuple((uint64_t)0, (uint64_t)0);
        }
        std::string raw_path = path_obj.as<std::string>();
        sol::function callback = cb_obj.as<sol::function>();

        // Normalize /Script/Module.ClassName:FuncName → ClassName:FuncName
        std::string func_path = normalize_hook_path(raw_path);
        if (func_path != raw_path) {
            logger::log_info("LUA", "RegisterHook: normalized '%s' → '%s'",
                             raw_path.c_str(), func_path.c_str());
        }

        // Pre-hook: no-op, but registered so we get a valid PreId
        auto pre_id = pe_hook::register_pre(func_path,
            [](ue::UObject* self, ue::UFunction* func, void* parms) -> bool {
                return false; // never block by default
            });

        // Post-hook: passes a UE4SS-compatible Context with :get()
        auto post_id = pe_hook::register_post(func_path,
            [callback, lua, func_path](ue::UObject* self, ue::UFunction* func, void* parms) mutable {
                // Build a UE4SS-style Context table with :get() method
                sol::table context = lua.create_table();
                lua_uobject::LuaUObject wrapped;
                wrapped.ptr = self;
                context["get"] = [wrapped](sol::this_state ts2) -> sol::object {
                    sol::state_view inner(ts2);
                    return sol::make_object(inner, wrapped);
                };
                context["__self"] = wrapped;

                auto result = callback(context, sol::lightuserdata_value(parms));
                if (!result.valid()) {
                    sol::error err = result;
                    logger::log_error("LUA", "RegisterHook(%s) callback error: %s",
                                      func_path.c_str(), err.what());
                }
            });

        mod_tracker::track_pe_hook(owning_mod, pre_id);
        mod_tracker::track_pe_hook(owning_mod, post_id);
        logger::log_info("LUA", "RegisterHook: %s -> PreId=%lu PostId=%lu",
                         func_path.c_str(), (unsigned long)pre_id, (unsigned long)post_id);
        return std::make_tuple(pre_id, post_id); });

        // ── RegisterProcessEventHook (className, funcName, pre, post) ───────
        // This is the primary hook API used by most mods
        // Takes className and funcName as separate strings + separate pre/post callbacks
        // NOTE: Uses sol::object instead of sol::optional<sol::function> because sol2
        // misparses optional<function> when nil is passed before a valid function arg.
        // This was causing ALL post-only hooks to silently not register.
        lua.set_function("RegisterProcessEventHook", [](sol::this_environment te,
                                                        const std::string &raw_class,
                                                        const std::string &func_name,
                                                        sol::object pre_obj,
                                                        sol::object post_obj)
                         {
        std::string owning_mod = mod_from_env(te);
        std::string class_name = normalize_class_name(raw_class);
        std::string func_path = class_name + ":" + func_name;
        if (class_name != raw_class) {
            logger::log_info("LUA", "RegisterProcessEventHook: normalized class '%s' → '%s'",
                             raw_class.c_str(), class_name.c_str());
        }

        if (pre_obj.is<sol::function>()) {
            sol::function pre_fn = pre_obj.as<sol::function>();
            mod_tracker::track_pe_hook(owning_mod, pe_hook::register_pre(func_path,
                [pre_fn, func_path](ue::UObject* self, ue::UFunction* func, void* parms) -> bool {
                    lua_uobject::LuaUObject wrapped;
                    wrapped.ptr = self;
                    auto result = pre_fn(wrapped, sol::lightuserdata_value(parms));
                    if (result.valid()) {
                        if (result.get_type() == sol::type::string) {
                            std::string s = result;
                            if (s == "BLOCK") return true;
                        }
                        if (result.get_type() == sol::type::boolean) {
                            return result.get<bool>();
                        }
                    } else {
                        sol::error err = result;
                        logger::log_error("LUA", "RegisterProcessEventHook(%s) pre error: %s",
                                          func_path.c_str(), err.what());
                    }
                    return false;
                }));
        }

        if (post_obj.is<sol::function>()) {
            sol::function post_fn = post_obj.as<sol::function>();
            mod_tracker::track_pe_hook(owning_mod, pe_hook::register_post(func_path,
                [post_fn, func_path](ue::UObject* self, ue::UFunction* func, void* parms) {
                    lua_uobject::LuaUObject wrapped;
                    wrapped.ptr = self;
                    post_fn(wrapped, sol::lightuserdata_value(parms));
                }));
        }

        logger::log_info("LUA", "RegisterProcessEventHook: %s", func_path.c_str()); });

        lua.set_function("RegisterPreHook", [](sol::this_state ts, sol::this_environment te, sol::object path_obj, sol::object cb_obj) -> uint64_t
                         {
        // Validate arguments — MUST NOT crash on nil/wrong types
        if (!path_obj.is<std::string>()) {
            logger::log_error("LUA", "RegisterPreHook: first argument must be a string (got %s)",
                              lua_typename(ts, (int)path_obj.get_type()));
            return 0;
        }
        if (!cb_obj.is<sol::function>()) {
            logger::log_error("LUA", "RegisterPreHook: second argument must be a function (got %s)",
                              lua_typename(ts, (int)cb_obj.get_type()));
            return 0;
        }
        std::string raw_path = path_obj.as<std::string>();
        sol::function callback = cb_obj.as<sol::function>();

        std::string func_path = normalize_hook_path(raw_path);
        if (func_path != raw_path) {
            logger::log_info("LUA", "RegisterPreHook: normalized '%s' → '%s'",
                             raw_path.c_str(), func_path.c_str());
        }
        auto id = pe_hook::register_pre(func_path, [callback, func_path](ue::UObject* self, ue::UFunction* func, void* parms) -> bool {
            lua_uobject::LuaUObject wrapped;
            wrapped.ptr = self;
            auto result = callback(wrapped, sol::lightuserdata_value(func), sol::lightuserdata_value(parms));
            if (result.valid()) {
                if (result.get_type() == sol::type::string) {
                    std::string s = result;
                    if (s == "BLOCK") return true;
                }
                if (result.get_type() == sol::type::boolean) {
                    return result.get<bool>();
                }
            } else {
                sol::error err = result;
                logger::log_error("LUA", "RegisterPreHook(%s) error: %s",
                                  func_path.c_str(), err.what());
            }
            return false;
        });
        mod_tracker::track_pe_hook(mod_from_env(te), id);
        logger::log_info("LUA", "RegisterPreHook: %s -> Id=%lu",
                         func_path.c_str(), (unsigned long)id);
        return id; });

        lua.set_function("RegisterPostHook", [](sol::this_state ts, sol::this_environment te, sol::object path_obj, sol::object cb_obj) -> uint64_t
                         {
        // Validate arguments — MUST NOT crash on nil/wrong types
        if (!path_obj.is<std::string>()) {
            logger::log_error("LUA", "RegisterPostHook: first argument must be a string (got %s)",
                              lua_typename(ts, (int)path_obj.get_type()));
            return 0;
        }
        if (!cb_obj.is<sol::function>()) {
            logger::log_error("LUA", "RegisterPostHook: second argument must be a function (got %s)",
                              lua_typename(ts, (int)cb_obj.get_type()));
            return 0;
        }
        std::string raw_path = path_obj.as<std::string>();
        sol::function callback = cb_obj.as<sol::function>();

        std::string func_path = normalize_hook_path(raw_path);
        if (func_path != raw_path) {
            logger::log_info("LUA", "RegisterPostHook: normalized '%s' → '%s'",
                             raw_path.c_str(), func_path.c_str());
        }
        auto id = pe_hook::register_post(func_path, [callback, func_path](ue::UObject* self, ue::UFunction* func, void* parms) {
            lua_uobject::LuaUObject wrapped;
            wrapped.ptr = self;
            auto result = callback(wrapped, sol::lightuserdata_value(func), sol::lightuserdata_value(parms));
            if (!result.valid()) {
                sol::error err = result;
                logger::log_error("LUA", "RegisterPostHook(%s) error: %s",
                                  func_path.c_str(), err.what());
            }
        });
        mod_tracker::track_pe_hook(mod_from_env(te), id);
        logger::log_info("LUA", "RegisterPostHook: %s -> Id=%lu",
                         func_path.c_str(), (unsigned long)id);
        return id; });

        lua.set_function("UnregisterHook", [](uint64_t id)
                         {
        pe_hook::unregister(id);
        mod_tracker::untrack_pe_hook(id); });

        // ── Native hooks (Dobby) ────────────────────────────────────────────
        // Signature string format (optional 4th parameter):
        //   Each char = one parameter position in function-call order:
        //     'p' or 'i' = integer/pointer → taken from next X register, passed as lightuserdata
        //     'f' or 'd' = float/double    → taken from next D register, passed as Lua number
        //   A '>' separates arg types from return type:
        //     ">f" = function returns a float (D0)
        //     ">p" or ">i" or no '>' = function returns integer/pointer (X0)
        //   Examples:
        //     "pf"     → (ptr X0, float D0)             returns ptr (X0)
        //     "pfff"   → (ptr X0, float D0, D1, D2)     returns ptr (X0)
        //     "pf>f"   → (ptr X0, float D0)             returns float (D0)
        //     ">f"     → no custom arg mapping           returns float (D0)
        //     ""       → legacy mode: all X registers as lightuserdata, X0 return
        //   If no 4th parameter: legacy mode — full backward compatibility.

        // Helper: parse signature into arg types and return type
        // (NativeHookSig struct and parse_native_hook_sig defined at namespace scope above)

        lua.set_function("RegisterNativeHook", [](sol::this_environment te, const std::string &symbol_name, sol::object pre_obj, sol::object post_obj, sol::optional<std::string> sig_str) -> bool
                         {

        // Parse signature if provided
        bool has_sig = sig_str.has_value() && !sig_str->empty();
        NativeHookSig sig;
        if (has_sig) {
            sig = parse_native_hook_sig(*sig_str);
        }

        native_hooks::NativePreCallback pre_cb = nullptr;
        native_hooks::NativePostCallback post_cb = nullptr;

        if (pre_obj.is<sol::function>()) {
            sol::function pre_fn = pre_obj.as<sol::function>();
            pre_cb = [pre_fn, has_sig, sig](native_hooks::NativeCallContext& ctx) {
                // Build the Lua call arguments based on signature
                sol::state_view lua(pre_fn.lua_state());

                // Helper: process results from the Lua callback
                auto process_pre_result = [&](sol::protected_function_result& result) {
                    if (!result.valid()) return;
                    int n = result.return_count();
                    if (n == 0) return;

                    // Check if first return is "BLOCK" string
                    sol::object r0 = result[0];
                    if (r0.get_type() == sol::type::string) {
                        std::string s = r0.as<std::string>();
                        if (s == "BLOCK") {
                            ctx.blocked = true;
                            return;
                        }
                    }

                    if (has_sig && !sig.arg_types.empty()) {
                        // Write back returned values according to signature.
                        // Each return position corresponds to its signature position.
                        // 'p' returns → write to ctx.x[xi], 'f' returns → write to ctx.d[di]
                        int xi = 0;
                        int di = 0;
                        for (int i = 0; i < std::min(n, (int)sig.arg_types.size()); i++) {
                            sol::object ri = result[i];
                            char t = sig.arg_types[i];
                            if (t == 'p') {
                                if (xi < 8) {
                                    if (ri.get_type() == sol::type::lightuserdata) {
                                        ctx.x[xi] = reinterpret_cast<uintptr_t>(ri.as<void*>());
                                    } else if (ri.get_type() == sol::type::number) {
                                        ctx.x[xi] = static_cast<uint64_t>(ri.as<int64_t>());
                                    } else if (ri.get_type() == sol::type::boolean) {
                                        ctx.x[xi] = ri.as<bool>() ? 1ULL : 0ULL;
                                    }
                                    xi++;
                                }
                            } else { // 'f'
                                if (di < 8) {
                                    if (ri.get_type() == sol::type::number) {
                                        ctx.d[di] = ri.as<double>();
                                    }
                                    di++;
                                }
                            }
                        }
                    } else {
                        // Legacy mode — write all returns back to X registers
                        for (int i = 0; i < std::min(n, 8); i++) {
                            sol::object ri = result[i];
                            if (ri.get_type() == sol::type::lightuserdata) {
                                ctx.x[i] = reinterpret_cast<uintptr_t>(ri.as<void*>());
                            } else if (ri.get_type() == sol::type::number) {
                                if (ri.is<int64_t>()) {
                                    ctx.x[i] = static_cast<uint64_t>(ri.as<int64_t>());
                                } else {
                                    ctx.x[i] = static_cast<uint64_t>(static_cast<int64_t>(ri.as<double>()));
                                }
                            } else if (ri.get_type() == sol::type::boolean) {
                                ctx.x[i] = ri.as<bool>() ? 1ULL : 0ULL;
                            }
                        }
                    }
                };

                if (has_sig && !sig.arg_types.empty()) {
                    // Build argument list based on signature.
                    // Each 'p' takes from the next X register (lightuserdata).
                    // Each 'f' takes from the next D register (Lua number).
                    std::vector<sol::object> args;
                    int xi = 0; // X register index
                    int di = 0; // D register index
                    for (char t : sig.arg_types) {
                        if (t == 'p') {
                            if (xi < 8) {
                                args.push_back(sol::make_object(lua,
                                    sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[xi]))));
                                xi++;
                            }
                        } else { // 'f'
                            if (di < 8) {
                                args.push_back(sol::make_object(lua, ctx.d[di]));
                                di++;
                            }
                        }
                    }

                    // Call with the built arg list
                    switch (args.size()) {
                        case 0: { auto r = pre_fn(); process_pre_result(r); break; }
                        case 1: { auto r = pre_fn(args[0]); process_pre_result(r); break; }
                        case 2: { auto r = pre_fn(args[0], args[1]); process_pre_result(r); break; }
                        case 3: { auto r = pre_fn(args[0], args[1], args[2]); process_pre_result(r); break; }
                        case 4: { auto r = pre_fn(args[0], args[1], args[2], args[3]); process_pre_result(r); break; }
                        case 5: { auto r = pre_fn(args[0], args[1], args[2], args[3], args[4]); process_pre_result(r); break; }
                        case 6: { auto r = pre_fn(args[0], args[1], args[2], args[3], args[4], args[5]); process_pre_result(r); break; }
                        case 7: { auto r = pre_fn(args[0], args[1], args[2], args[3], args[4], args[5], args[6]); process_pre_result(r); break; }
                        default:{ auto r = pre_fn(args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]); process_pre_result(r); break; }
                    }
                } else {
                    // Legacy mode — pass all 8 X registers as lightuserdata
                    auto r = pre_fn(
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[0])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[1])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[2])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[3])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[4])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[5])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[6])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[7]))
                    );
                    process_pre_result(r);
                }
            };
        }

        if (post_obj.is<sol::function>()) {
            sol::function post_fn = post_obj.as<sol::function>();
            post_cb = [post_fn, has_sig, sig](native_hooks::NativeCallContext& ctx) {
                sol::state_view lua(post_fn.lua_state());

                // Helper: process results from the Lua post callback
                auto process_post_result = [&](sol::protected_function_result& result) {
                    if (!result.valid()) return;
                    if (result.return_count() == 0) return;

                    // Read back modified return value from first return
                    sol::object r0 = result[0];
                    if (has_sig && sig.float_return) {
                        // Float return — write to ret_d0
                        if (r0.get_type() == sol::type::number) {
                            ctx.ret_d0 = r0.as<double>();
                        }
                    } else {
                        // Integer/pointer return — write to ret_x0
                        if (r0.get_type() == sol::type::lightuserdata) {
                            ctx.ret_x0 = reinterpret_cast<uintptr_t>(r0.as<void*>());
                        } else if (r0.get_type() == sol::type::number) {
                            if (r0.is<int64_t>()) {
                                ctx.ret_x0 = static_cast<uint64_t>(r0.as<int64_t>());
                            } else {
                                ctx.ret_x0 = static_cast<uint64_t>(static_cast<int64_t>(r0.as<double>()));
                            }
                        } else if (r0.get_type() == sol::type::boolean) {
                            ctx.ret_x0 = r0.as<bool>() ? 1ULL : 0ULL;
                        }
                    }
                };

                // Helper: build args vector from signature (appended after retval)
                auto build_post_args = [&](sol::object retval_obj) -> std::vector<sol::object> {
                    std::vector<sol::object> args;
                    args.push_back(retval_obj);
                    int xi = 0, di = 0;
                    for (char t : sig.arg_types) {
                        if (t == 'p') {
                            if (xi < 8) {
                                args.push_back(sol::make_object(lua,
                                    sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[xi]))));
                                xi++;
                            }
                        } else {
                            if (di < 8) {
                                args.push_back(sol::make_object(lua, ctx.d[di]));
                                di++;
                            }
                        }
                    }
                    return args;
                };

                // Helper: call post_fn with a vector of args
                auto call_with_args = [&](std::vector<sol::object>& args) {
                    switch (args.size()) {
                        case 1: { auto r = post_fn(args[0]); process_post_result(r); break; }
                        case 2: { auto r = post_fn(args[0], args[1]); process_post_result(r); break; }
                        case 3: { auto r = post_fn(args[0], args[1], args[2]); process_post_result(r); break; }
                        case 4: { auto r = post_fn(args[0], args[1], args[2], args[3]); process_post_result(r); break; }
                        case 5: { auto r = post_fn(args[0], args[1], args[2], args[3], args[4]); process_post_result(r); break; }
                        case 6: { auto r = post_fn(args[0], args[1], args[2], args[3], args[4], args[5]); process_post_result(r); break; }
                        case 7: { auto r = post_fn(args[0], args[1], args[2], args[3], args[4], args[5], args[6]); process_post_result(r); break; }
                        default:{ auto r = post_fn(args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]); process_post_result(r); break; }
                    }
                };

                if (has_sig && sig.float_return) {
                    // Float return: pass ret_d0 as a Lua number FIRST, then args
                    if (!sig.arg_types.empty()) {
                        auto args = build_post_args(sol::make_object(lua, ctx.ret_d0));
                        call_with_args(args);
                    } else {
                        // No arg signature but float return — pass ret_d0 as number
                        // followed by all X args as lightuserdata
                        auto r = post_fn(
                            ctx.ret_d0,
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[0])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[1])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[2])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[3])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[4])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[5])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[6])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[7]))
                        );
                        process_post_result(r);
                    }
                } else {
                    // Integer/pointer return or legacy mode
                    if (has_sig && !sig.arg_types.empty()) {
                        auto args = build_post_args(sol::make_object(lua,
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.ret_x0))));
                        call_with_args(args);
                    } else {
                        // Full legacy mode — all lightuserdata
                        auto r = post_fn(
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.ret_x0)),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[0])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[1])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[2])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[3])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[4])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[5])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[6])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[7]))
                        );
                        process_post_result(r);
                    }
                }
            };
        }

        return native_hooks::install(symbol_name, pre_cb, post_cb, hook_key_from_env(te, symbol_name)); });

        // ── RegisterNativeHookAt — hook at a resolved address (lightuserdata) ─
        // Same as RegisterNativeHook but first arg is a lightuserdata address
        // (e.g. from Resolve()) and second arg is a string label for logging.
        // Signature: RegisterNativeHookAt(addr, name, pre, post, sig?)
        lua.set_function("RegisterNativeHookAt", [](sol::this_environment te, void *addr, const std::string &hook_name, sol::object pre_obj, sol::object post_obj, sol::optional<std::string> sig_str) -> bool
                         {
        if (!addr) {
            logger::log_error("LUA", "RegisterNativeHookAt: null address for '%s'", hook_name.c_str());
            return false;
        }

        bool has_sig = sig_str.has_value() && !sig_str->empty();
        NativeHookSig sig;
        if (has_sig) {
            sig = parse_native_hook_sig(*sig_str);
        }

        native_hooks::NativePreCallback pre_cb = nullptr;
        native_hooks::NativePostCallback post_cb = nullptr;

        if (pre_obj.is<sol::function>()) {
            sol::function pre_fn = pre_obj.as<sol::function>();
            pre_cb = [pre_fn, has_sig, sig](native_hooks::NativeCallContext& ctx) {
                sol::state_view lua(pre_fn.lua_state());
                auto process_pre_result = [&](sol::protected_function_result& result) {
                    if (!result.valid()) return;
                    int n = result.return_count();
                    if (n == 0) return;
                    sol::object r0 = result[0];
                    if (r0.get_type() == sol::type::string) {
                        std::string s = r0.as<std::string>();
                        if (s == "BLOCK") { ctx.blocked = true; return; }
                    }
                    if (has_sig && !sig.arg_types.empty()) {
                        int xi = 0, di = 0;
                        for (int i = 0; i < std::min(n, (int)sig.arg_types.size()); i++) {
                            sol::object ri = result[i];
                            char t = sig.arg_types[i];
                            if (t == 'p') {
                                if (xi < 8) {
                                    if (ri.get_type() == sol::type::lightuserdata)
                                        ctx.x[xi] = reinterpret_cast<uintptr_t>(ri.as<void*>());
                                    else if (ri.get_type() == sol::type::number)
                                        ctx.x[xi] = static_cast<uint64_t>(ri.as<int64_t>());
                                    else if (ri.get_type() == sol::type::boolean)
                                        ctx.x[xi] = ri.as<bool>() ? 1ULL : 0ULL;
                                    xi++;
                                }
                            } else {
                                if (di < 8) {
                                    if (ri.get_type() == sol::type::number) ctx.d[di] = ri.as<double>();
                                    di++;
                                }
                            }
                        }
                    } else {
                        for (int i = 0; i < std::min(n, 8); i++) {
                            sol::object ri = result[i];
                            if (ri.get_type() == sol::type::lightuserdata)
                                ctx.x[i] = reinterpret_cast<uintptr_t>(ri.as<void*>());
                            else if (ri.get_type() == sol::type::number) {
                                if (ri.is<int64_t>()) ctx.x[i] = static_cast<uint64_t>(ri.as<int64_t>());
                                else ctx.x[i] = static_cast<uint64_t>(static_cast<int64_t>(ri.as<double>()));
                            } else if (ri.get_type() == sol::type::boolean)
                                ctx.x[i] = ri.as<bool>() ? 1ULL : 0ULL;
                        }
                    }
                };
                if (has_sig && !sig.arg_types.empty()) {
                    std::vector<sol::object> args;
                    int xi = 0, di = 0;
                    for (char t : sig.arg_types) {
                        if (t == 'p') { if (xi < 8) { args.push_back(sol::make_object(lua, sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[xi])))); xi++; } }
                        else { if (di < 8) { args.push_back(sol::make_object(lua, ctx.d[di])); di++; } }
                    }
                    switch (args.size()) {
                        case 0: { auto r = pre_fn(); process_pre_result(r); break; }
                        case 1: { auto r = pre_fn(args[0]); process_pre_result(r); break; }
                        case 2: { auto r = pre_fn(args[0], args[1]); process_pre_result(r); break; }
                        case 3: { auto r = pre_fn(args[0], args[1], args[2]); process_pre_result(r); break; }
                        case 4: { auto r = pre_fn(args[0], args[1], args[2], args[3]); process_pre_result(r); break; }
                        case 5: { auto r = pre_fn(args[0], args[1], args[2], args[3], args[4]); process_pre_result(r); break; }
                        case 6: { auto r = pre_fn(args[0], args[1], args[2], args[3], args[4], args[5]); process_pre_result(r); break; }
                        case 7: { auto r = pre_fn(args[0], args[1], args[2], args[3], args[4], args[5], args[6]); process_pre_result(r); break; }
                        default:{ auto r = pre_fn(args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]); process_pre_result(r); break; }
                    }
                } else {
                    auto r = pre_fn(
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[0])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[1])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[2])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[3])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[4])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[5])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[6])),
                        sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[7])));
                    process_pre_result(r);
                }
            };
        }

        if (post_obj.is<sol::function>()) {
            sol::function post_fn = post_obj.as<sol::function>();
            post_cb = [post_fn, has_sig, sig](native_hooks::NativeCallContext& ctx) {
                sol::state_view lua(post_fn.lua_state());
                auto process_post_result = [&](sol::protected_function_result& result) {
                    if (!result.valid()) return;
                    if (result.return_count() == 0) return;
                    sol::object r0 = result[0];
                    if (has_sig && sig.float_return) {
                        if (r0.get_type() == sol::type::number) ctx.ret_d0 = r0.as<double>();
                    } else {
                        if (r0.get_type() == sol::type::lightuserdata)
                            ctx.ret_x0 = reinterpret_cast<uintptr_t>(r0.as<void*>());
                        else if (r0.get_type() == sol::type::number) {
                            if (r0.is<int64_t>()) ctx.ret_x0 = static_cast<uint64_t>(r0.as<int64_t>());
                            else ctx.ret_x0 = static_cast<uint64_t>(static_cast<int64_t>(r0.as<double>()));
                        } else if (r0.get_type() == sol::type::boolean)
                            ctx.ret_x0 = r0.as<bool>() ? 1ULL : 0ULL;
                    }
                };
                auto build_post_args = [&](sol::object retval_obj) -> std::vector<sol::object> {
                    std::vector<sol::object> args;
                    args.push_back(retval_obj);
                    int xi = 0, di = 0;
                    for (char t : sig.arg_types) {
                        if (t == 'p') { if (xi < 8) { args.push_back(sol::make_object(lua, sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[xi])))); xi++; } }
                        else { if (di < 8) { args.push_back(sol::make_object(lua, ctx.d[di])); di++; } }
                    }
                    return args;
                };
                auto call_with_args = [&](std::vector<sol::object>& args) {
                    switch (args.size()) {
                        case 1: { auto r = post_fn(args[0]); process_post_result(r); break; }
                        case 2: { auto r = post_fn(args[0], args[1]); process_post_result(r); break; }
                        case 3: { auto r = post_fn(args[0], args[1], args[2]); process_post_result(r); break; }
                        case 4: { auto r = post_fn(args[0], args[1], args[2], args[3]); process_post_result(r); break; }
                        case 5: { auto r = post_fn(args[0], args[1], args[2], args[3], args[4]); process_post_result(r); break; }
                        case 6: { auto r = post_fn(args[0], args[1], args[2], args[3], args[4], args[5]); process_post_result(r); break; }
                        case 7: { auto r = post_fn(args[0], args[1], args[2], args[3], args[4], args[5], args[6]); process_post_result(r); break; }
                        default:{ auto r = post_fn(args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]); process_post_result(r); break; }
                    }
                };
                if (has_sig && sig.float_return) {
                    if (!sig.arg_types.empty()) {
                        auto args = build_post_args(sol::make_object(lua, ctx.ret_d0));
                        call_with_args(args);
                    } else {
                        auto r = post_fn(ctx.ret_d0,
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[0])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[1])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[2])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[3])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[4])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[5])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[6])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[7])));
                        process_post_result(r);
                    }
                } else {
                    if (has_sig && !sig.arg_types.empty()) {
                        auto args = build_post_args(sol::make_object(lua,
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.ret_x0))));
                        call_with_args(args);
                    } else {
                        auto r = post_fn(
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.ret_x0)),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[0])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[1])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[2])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[3])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[4])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[5])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[6])),
                            sol::lightuserdata_value(reinterpret_cast<void*>(ctx.x[7])));
                        process_post_result(r);
                    }
                }
            };
        }

        return native_hooks::install_at(addr, hook_name, pre_cb, post_cb, hook_key_from_env(te, hook_name)); });

        // ── RegisterNativeArgFilter — a PURE-C++ hook (no Lua callback) ──────
        // On every call to `addr`, read a u32 field at (argN + field_off); if it
        // equals match_value, zero `clear_size` bytes at (argN + clear_off). The
        // predicate runs INLINE in the native hook dispatch — it is NEVER deferred
        // to the Lua game-thread queue — so it is safe on hot / mid-emulation
        // functions where a Lua hook callback crashes (see the WPC switch-setter).
        // enable_ptr (optional lightuserdata → a byte): while *enable_ptr == 0 the
        // filter is inert, so a mod can toggle it live without reinstalling.
        // Sig: RegisterNativeArgFilter(addr, name, argIdx, fieldOff, matchVal,
        //                              clearOff, clearSize?, enablePtr?)
        lua.set_function("RegisterNativeArgFilter",
            [](sol::this_environment te, void* addr, const std::string& name, int arg_index, int64_t field_off,
               uint32_t match_value, int64_t clear_off, sol::optional<int> clear_size_opt,
               sol::optional<void*> enable_ptr_opt) -> bool
        {
            if (!addr || arg_index < 0 || arg_index > 7) {
                logger::log_error("LUA", "RegisterNativeArgFilter: bad addr/argIdx for '%s'", name.c_str());
                return false;
            }
            int clear_size = clear_size_opt.value_or(1);
            void* enable_ptr = enable_ptr_opt.value_or(nullptr);
            native_hooks::NativePreCallback pre =
                [arg_index, field_off, match_value, clear_off, clear_size, enable_ptr]
                (native_hooks::NativeCallContext& ctx)
            {
                if (enable_ptr) {
                    if (!ue::is_mapped_ptr(enable_ptr)) return;
                    if (*reinterpret_cast<volatile uint8_t*>(enable_ptr) == 0) return; // toggled off
                }
                uintptr_t argp = ctx.x[arg_index];
                if (!argp || !ue::is_mapped_ptr(reinterpret_cast<void*>(argp))) return;
                if (*reinterpret_cast<uint32_t*>(argp + field_off) != match_value) return;
                void* cp = reinterpret_cast<void*>(argp + clear_off);
                switch (clear_size) {
                    case 2: *reinterpret_cast<uint16_t*>(cp) = 0; break;
                    case 4: *reinterpret_cast<uint32_t*>(cp) = 0; break;
                    case 8: *reinterpret_cast<uint64_t*>(cp) = 0; break;
                    default: *reinterpret_cast<uint8_t*>(cp)  = 0; break;
                }
            };
            bool ok = native_hooks::install_at(addr, name, pre, nullptr, hook_key_from_env(te, name)) != 0;
            logger::log_info("LUA", "RegisterNativeArgFilter '%s' @%p arg%d (+%lld)==%u -> zero(+%lld) sz%d : %s",
                             name.c_str(), addr, arg_index, (long long)field_off, match_value,
                             (long long)clear_off, clear_size, ok ? "OK" : "FAIL");
            return ok;
        });

        // ── InstallClothBoneSanitizer — PURE-C++ cut-content cloth guard ────
        // Hooks PenClothSet(cModel*, CLOTH_INFO*, float). Before each call it
        // rewrites any cloth bone index the model can't resolve (getPartsPtr
        // walks off a ported/short skeleton) to the 0xFF "skip" sentinel, so
        // cut enemies (em3f/Saddler-Ada) render with live cloth on the bones
        // they DO have instead of crashing at null+0x1d8. Pure C++ — safe on
        // the game thread (no Lua callback to race the shared lua_State).
        // Sig: InstallClothBoneSanitizer(penClothSetAddr) -> bool
        lua.set_function("InstallClothBoneSanitizer", [](void* addr) -> bool {
            return native_hooks::install_cloth_bone_sanitizer(addr) != 0;
        });

        // ── InstallModelRestore — cut-enemy visible-model restore ───────────
        // Hooks a cEmXX::move (e.g. cEm3f::move) and injects the VR4ModelInit
        // that the cut enemy's init omits, so it spawns a visible AVR4Model.
        // Pure C++, native pointers (no MTE-tag mangle). Self-guards on cModel
        // +988 → no-op for enemies that already build their own UE model.
        // Sig: InstallModelRestore(cEmMoveAddr) -> bool
        lua.set_function("InstallModelRestore", [](void* addr) -> bool {
            return native_hooks::install_model_restore(addr) != 0;
        });

        // ── AddEm3fMeshPathFix — repair em3f_meshTable's broken MeshRefs ────
        // Its plaga-sourced rows (em3f_008/009/094) point at
        // .../EM/em25_plaga/Geometry/<mesh> but the assets are packed at
        // .../BOSS/em30_Saddler/Geometry/<mesh>, so TryLoad returns null and those
        // parts get NO mesh (only the plaga attack particles render). Register the
        // row's OffsetKey + the FName comparison index of the CORRECT path;
        // model_restore repoints the cached MeshRef after TryCacheMap so the game's
        // own loader resolves it. Re-registering a key updates it.
        // Sig: AddEm3fMeshPathFix(offsetKey, FName(correctPath):GetComparisonIndex())
        lua.set_function("AddEm3fMeshPathFix", [](uint32_t key, int32_t idx) {
            native_hooks::add_em3f_mesh_path_fix(key, idx);
        });

        // ── InstallCrashGuard — sigsetjmp safe-call guard on ONE function ───
        // Installs a callback-less hook so dispatch_full() runs the original
        // inside the sigsetjmp guard: a SIGSEGV in it recovers (returns 0)
        // instead of killing the game. The built-in guard table is skipped on
        // RE4 (guarding the render path black-screens VR), so crashy functions
        // must be guarded individually. E.g. cModel::initJoint, which faults
        // when the cut police NPC (em07/PL07) spawns with no native model data.
        // Sig: InstallCrashGuard(addr, "name") -> bool
        lua.set_function("InstallCrashGuard", [](void* addr, const std::string& name) -> bool {
            return native_hooks::install_safe_call_guard(addr, name.c_str()) != 0;
        });

        // ── InstallCutVillagerFix — make the CUT GANADO VILLAGERS spawn ─────
        // Not a guard — it repairs the one thing the port left unfinished.
        // em ids 6/7/8/0xA/0xB/0xD/0x33/0x37 are villager variants that SHARE
        // em10.das with id 9 (proof: em07/em08/em09/em10_meshTable in
        // EnemyFixes_P.pak are all 132 rows and identical), but ArmEmCallProlog has
        // no case for them, so it returns 0 and leaves the GLOBAL EmInitFunc stale;
        // cEmMgr::construct then runs the PREVIOUS enemy's init over ganado data
        // => cModel::initJoint SIGSEGV. Since ids 9/0x10 use the same archive and
        // work, we patch the switch's jump table to give each cut id the id-9 case
        // (_prologEm09) — same archive, same layout, and they get REAL ganado AI.
        // Sig: InstallCutVillagerFix() -> bool
        lua.set_function("InstallCutVillagerFix", []() -> bool {
            return native_hooks::install_cut_villager_fix();
        });

        // ── InstallEm32SubObjectGuard — the cut-enemy spawn SIGSEGV ──────────
        // em32's init (sub_5E49AA0) calls SetObj00 for two sub-object models,
        // CBZ-checks each result, and then dereferences it anyway a few
        // instructions later: `LDR X2,[X25,#0xA88]; LDR X8,[X2,#0x180]` =>
        // SIGSEGV fault addr 0x180. SetObj00 returns NULL whenever
        // cModel::modelInit can't find the model in the archive, which is the norm
        // for cut content. Retail never spawns em32, so the bug shipped.
        // VR4CreateEmSubObject null-checks BOTH pointers and returns, so the fault
        // is entirely in building an argument the callee discards — we just make
        // the loads safe and zero the cEm so it opts out. No-op when non-null.
        // Sig: InstallEm32SubObjectGuard() -> bool
        lua.set_function("InstallEm32SubObjectGuard", []() -> bool {
            return native_hooks::install_em32_subobject_guard();
        });

        // ── InstallNullThisGuard — add the null check the game forgot ────────
        // A family of RE4 crashes is ONE bug repeated per enemy: a NULL
        // sub-object/model (normal for cut/unsupported content whose data the room
        // never loaded) dereferenced with no check. They die as NULL+fieldOffset,
        // always via EmSetFromList2 -> cEmXX::move:
        //   cObjChain::setChain -> 0x438  (it is literally
        //       `*((_QWORD*)this + 135) = a2;` — 135*8 = 0x438 — with no check)
        //   em32 init -> 0x180,  cEm2d::setReset -> 0x0d
        // Guards the function ENTRY and returns 0 when `this` is NULL, so the enemy
        // loses that one feature (e.g. cloth) instead of killing the process.
        // Sig: InstallNullThisGuard(addr, name) -> bool
        // fieldOff (optional): omit to test `this`; pass an offset to test the
        // pointer FIELD at this+off — cModel::setParent has a valid `this` and a
        // NULL *(this+0x108), so testing x0 alone would miss it entirely.
        lua.set_function("InstallNullThisGuard", [](void* addr, const std::string& name,
                                                    sol::optional<int64_t> field_off) -> bool {
            return native_hooks::install_null_this_guard(reinterpret_cast<uintptr_t>(addr),
                                                         name.c_str(), field_off.value_or(-1));
        });

        // ── InstallU3KillableFix — U3 (em32) killable outside its level ─────
        // U3 "It" = emId 50 = 0x32 = cEm32. Away from its scripted level it is
        // invulnerable, and it is the SAME bug as the fault-0x180 crash. Its init
        // (sub_5E49AA0) builds U3's parts via SetObj00 using the global/stage
        // archive at pG+0x68; elsewhere that archive lacks the data, modelInit
        // fails, SetObj00 returns 0, and the game derefs the NULL it just checked
        // (*(v50+384) => NULL+0x180). Everything after that line is
        // YarareInit/YarareAdd — U3's damage regions — so guarding the crash is
        // exactly what made it unkillable: the init never reaches its hitboxes.
        // Retrying SetObj00 with U3's OWN archive lets the init COMPLETE.
        // Sig: InstallU3KillableFix(em32InitAddr, setObj00Addr) -> bool
        lua.set_function("InstallU3KillableFix", [](void* em32_init, void* setobj00) -> bool {
            return native_hooks::install_u3_killable_fix(
                reinterpret_cast<uintptr_t>(em32_init), reinterpret_cast<uintptr_t>(setobj00));
        });
        // Sig: U3RescuedCount() -> int  (how many parts models we rebuilt)
        lua.set_function("U3RescuedCount", []() -> uint32_t {
            return native_hooks::u3_rescued_count();
        });

        // ── InstallMineThrowerFastReload — no Lua on a vtable move() slot ────
        // cObjMine::moveReload is a VTABLE entry (next to moveFire/moveDown),
        // dispatched from cObjWep::move every frame the weapon is reloading — and
        // the whole point of this mod is to reload constantly, so it runs
        // constantly. A Lua callback there races the shared lua_State; that is the
        // pc=0x24cc / FMallocBinned2 / atan2f corruption. The logic is four memory
        // ops and one call, so it lives in C++ now. Identical behaviour.
        // Sig: InstallMineThrowerFastReload(moveReloadAddr, itemMgrAddr, reloadAddr, inProgOff, subFlagOff) -> bool
        lua.set_function("InstallMineThrowerFastReload", [](void* movereload, void* itemmgr,
                                                            void* reload_fn,
                                                            sol::optional<uint32_t> inprog,
                                                            sol::optional<uint32_t> subflag) -> bool {
            return native_hooks::install_minethrower_fast_reload(
                reinterpret_cast<uintptr_t>(movereload), reinterpret_cast<uintptr_t>(itemmgr),
                reinterpret_cast<uintptr_t>(reload_fn),
                inprog.value_or(1067), subflag.value_or(1066));
        });
        lua.set_function("SetMineThrowerEnabled", [](bool on) {
            native_hooks::set_minethrower_enabled(on);
        });

        // ── InstallLaserSightFix — aiming at a crossover enemy killed the game
        // GetWepTargetPos derefs getPartsPtr's NULL result (ADD X1,X0,#0x80 ->
        // MTXMultVec -> fault 0x80), every frame the laser is on that target.
        // A crash guard CANNOT fix this: the handler's siglongjmp recovery was
        // removed on purpose, so install_safe_call_guard is inert. This
        // neutralises the pointer instead — no lock-on, no crash.
        // Sig: InstallLaserSightFix(addrOfAddX1X0_0x80) -> bool
        lua.set_function("InstallLaserSightFix", [](void* site) -> bool {
            return native_hooks::install_laser_sight_fix(reinterpret_cast<uintptr_t>(site));
        });

        // ── InstallGetPartsPtrGuard — the ROOT of the crossover crash family ──
        // A scan of every call site in libUE4 says cModel::getPartsPtr has 2420
        // callers and 1101 of them deref the result with NO null check. That is the
        // engine's house style ("the part is always there"), and it is why this
        // family never ends: IKInit derefs +472 (fault 0x1d8), GetWepTargetPos
        // derefs +0x80, cModel::setParent dies at +0x108 — which is getPartsPtr's
        // OWN list walk doing *(NULL+264). One patch at the source beats 1101.
        // NULL now yields a zeroed self-chaining dummy. Verified 0 caller loops
        // terminate on NULL, so nothing can hang.
        // Sig: InstallGetPartsPtrGuard(addrOfGetPartsPtr) -> bool
        lua.set_function("InstallGetPartsPtrGuard", [](void* site) -> bool {
            return native_hooks::install_getpartsptr_guard(reinterpret_cast<uintptr_t>(site));
        });
        // How many times a NULL was substituted — 0 means the family never fired.
        lua.set_function("GetPartsPtrDummyCount", []() -> uint64_t {
            return native_hooks::getpartsptr_dummy_count();
        });

        // ── InstallXsbTrackBoundsGuard — the enemy sound-bank over-run ────────
        // CArmSoundBlock::ExtractTrackIndex strtol()s its cursor BEFORE applying
        // the end-of-name-table bound it checks four instructions later. A room
        // whose .xsb has fewer tracks than the enemy's .das expects walks the
        // cursor off the malloc'd buffer => SEGV_ACCERR inside StrToI. We apply
        // the game's own bound first. Skipping is safe: ArmLoadSoundBlockEnemy
        // already falls back to LoadGeneric when the .das sound load fails.
        // Sig: InstallXsbTrackBoundsGuard(addrOfExtractTrackIndex) -> bool
        lua.set_function("InstallXsbTrackBoundsGuard", [](void* site) -> bool {
            return native_hooks::install_xsb_track_bounds_guard(reinterpret_cast<uintptr_t>(site));
        });

        // ── InstallShootGamePausedGuard — a gallery target in a normal room ──
        // cEmMark::move -> armIsShootingGamePaused reads the shooting-minigame
        // manager global (qword_A597D28) and derefs it at +0x181. That global has
        // exactly ONE writer in the whole binary — R22cInit — so it is NULL in
        // every room but the gallery, and the fault addr IS the field offset.
        // armIsShootingGamePaused has exactly one caller, so this is surgical.
        // NOTE: the param MUST be void* — Resolve/Offset return lightuserdata, and
        // a uint64_t param makes sol throw (a pcall then hides it as "returned
        // false"). Sig: InstallShootGamePausedGuard(addrOfLdrbW8X8_0x181) -> bool
        lua.set_function("InstallShootGamePausedGuard", [](void* site) -> bool {
            return native_hooks::install_shootgame_paused_guard(reinterpret_cast<uintptr_t>(site));
        });

        // ── InstallDualFireArm — dual-fire WITHOUT a Lua hook on TryFire ─────
        // RE4 arms ONE weapon globally and TryFire only fires the gun that IS the
        // armed one, so dual-wielding fires only one gun. Arming each gun inside
        // its own TryFire fixes that — but TryFire is HOT (every trigger pull, per
        // gun, non-stop under rapid-fire) and a Lua callback there races the shared
        // lua_State against the mod loop and bridge thread. That corruption is what
        // killed the game: FMallocBinned2 freeing an FString inside
        // IncrementalPurgeGarbage, and a RET into a smashed return address
        // (pc=lr=1) — both far from the real cause. Same class as the ScoreControl
        // hot-hook crash. So the whole trigger path is pure C++ now; Lua only
        // resolves the addresses once at load and flips the toggle.
        // Sig: InstallDualFireArm(tryFireAddr, itemMgrAddr, armSearchAddr, armAddr, wnoOff) -> bool
        // Addresses come in as void* — Resolve()/Offset() hand Lua LIGHTUSERDATA,
        // not numbers, and sol only binds those to void*. Taking uint64_t here
        // threw a type error that the mod's pcall swallowed, so the hook silently
        // never installed (log said "nativeHook=false" with no [DUALFIRE] line).
        // Every other address-taking binding uses void* — match it.
        lua.set_function("InstallDualFireArm", [](void* tryfire, void* itemmgr,
                                                  void* armsearch, void* armfn,
                                                  sol::optional<uint32_t> wno_off,
                                                  sol::optional<void*> pg_addr,
                                                  sol::optional<uint32_t> armed_off) -> bool {
            return native_hooks::install_dualfire_arm(
                reinterpret_cast<uintptr_t>(tryfire), reinterpret_cast<uintptr_t>(itemmgr),
                reinterpret_cast<uintptr_t>(armsearch), reinterpret_cast<uintptr_t>(armfn),
                wno_off.value_or(3360),
                reinterpret_cast<uintptr_t>(pg_addr.value_or(nullptr)),
                armed_off.value_or(0x504C));
        });
        // Sig: SetDualFireEnabled(bool) — flips an atomic; no hook churn.
        lua.set_function("SetDualFireEnabled", [](bool on) {
            native_hooks::set_dualfire_enabled(on);
        });
        // Sig: IsDualFireEnabled() -> bool
        lua.set_function("IsDualFireEnabled", []() -> bool {
            return native_hooks::is_dualfire_enabled();
        });

        // ── SetEnemyPoolMultiplier — lift the per-level enemy cap ────────────
        // EmSetEvent hands out cEm slots from a FIXED pool and returns the errEm
        // sentinel when they're gone — that's the "hard limit" (EnemySpawner
        // reports it as "Pool full or invalid emId"). cEmMgr::arrayAlloc(n) is the
        // only place that sizes it, and it does `pool = memAlloc(stride*n);
        // count = n`, so scaling n scales the ALLOCATION and the COUNT together —
        // bumping the count alone would run the slot scan off the allocation.
        // Applies on the NEXT level load. mult clamped 1..16.
        // Sig: SetEnemyPoolMultiplier(mult) -> bool
        lua.set_function("SetEnemyPoolMultiplier", [](uint32_t mult) -> bool {
            return native_hooks::set_enemy_pool_multiplier(mult);
        });

        // ── IsEmIdSupported — can the engine actually construct this em id? ──
        // cEmMgr::construct guards the archive but calls the EmInitFunc GLOBAL with
        // no null check. An id with no ArmEmCallProlog case leaves that global at
        // the previous enemy's init (wrong init, wrong archive => initJoint crash)
        // or at NULL if nothing spawned yet (=> BLR 0, tombstone pc=0). Spawning
        // such an id is unsurvivable, so ASK before spawning. Reads the jump table,
        // so it can't drift out of sync with a hand-maintained list.
        // Sig: IsEmIdSupported(id) -> bool
        lua.set_function("IsEmIdSupported", [](uint32_t id) -> bool {
            return native_hooks::is_em_id_supported(id);
        });

        // ── RegisterNativeCapture — a PURE-C++ hook (no Lua callback) ───────
        // On every call to `addr`, if arg `argIdx` is a pointer in the half-open
        // range [minHeap, maxHeap) (maxHeap == 0 → no upper bound), store its VALUE
        // into the 8-byte slot at destPtr. The predicate runs INLINE in the native
        // hook dispatch — NEVER deferred to the Lua game-thread queue, and it does
        // NO syscall and NEVER dereferences the captured pointer — so it is safe and
        // cheap on functions that fire thousands of times/sec on the ROM/emulation
        // thread. This replaces Lua-callback capture hooks (RegisterNativeHookAt) on
        // such hot functions: a Lua callback there runs the shared lua_State from the
        // emulation thread (or re-entrantly mid-VM), racing the game thread and
        // corrupting a live closure → the classic garbage-Proto luaV_execute crash.
        // destPtr must be a stable malloc'd slot the mod reads with MemReadU64; the
        // dereference of the captured object happens later, safely, on the game
        // thread. Sig: RegisterNativeCapture(addr,name,argIdx,destPtr,minHeap?,maxHeap?)
        lua.set_function("RegisterNativeCapture",
            [](sol::this_environment te, void* addr, const std::string& name, int arg_index, void* dest_ptr,
               sol::optional<double> min_heap_opt, sol::optional<double> max_heap_opt) -> bool
        {
            if (!addr || arg_index < 0 || arg_index > 7 || !dest_ptr) {
                logger::log_error("LUA", "RegisterNativeCapture: bad addr/argIdx/dest for '%s'", name.c_str());
                return false;
            }
            // Strip a possible MTE / top-byte tag from the destination slot, then
            // validate it ONCE here (never in the hot per-call path).
            void* dest = reinterpret_cast<void*>(
                reinterpret_cast<uintptr_t>(dest_ptr) & 0x00FFFFFFFFFFFFFFULL);
            if (!ue::is_mapped_ptr(dest)) {
                logger::log_error("LUA", "RegisterNativeCapture: dest %p not mapped for '%s'", dest, name.c_str());
                return false;
            }
            uint64_t min_heap = min_heap_opt.has_value()
                ? (uint64_t)(int64_t)min_heap_opt.value() : 0x7000000000ULL;
            uint64_t max_heap = max_heap_opt.has_value()
                ? (uint64_t)(int64_t)max_heap_opt.value() : 0ULL;
            native_hooks::NativePreCallback pre =
                [arg_index, dest, min_heap, max_heap](native_hooks::NativeCallContext& ctx)
            {
                uint64_t argp = (uint64_t)ctx.x[arg_index];
                if (argp < min_heap) return;
                if (max_heap && argp >= max_heap) return;
                *reinterpret_cast<volatile uint64_t*>(dest) = argp;
            };
            bool ok = native_hooks::install_at(addr, name, pre, nullptr, hook_key_from_env(te, name)) != 0;
            logger::log_info("LUA", "RegisterNativeCapture '%s' @%p arg%d -> [%p] heap[0x%llx,0x%llx) : %s",
                             name.c_str(), addr, arg_index, dest,
                             (unsigned long long)min_heap, (unsigned long long)max_heap, ok ? "OK" : "FAIL");
            return ok;
        });

        // ── CallNative — call any resolved address ──────────────────────────
        lua.set_function("CallNative", [](sol::this_state ts, void *addr, const std::string &sig, sol::variadic_args va) -> sol::object
                         { return call_native_impl(ts, addr, sig, va); });

        lua.set_function("CallNativeBySymbol", [](sol::this_state ts, const std::string &symbol, const std::string &sig, sol::variadic_args va) -> sol::object
                         {
        void* addr = symbols::resolve(symbol);
        if (!addr) {
            logger::log_error("LUA", "CallNativeBySymbol: '%s' not found", symbol.c_str());
            return sol::nil;
        }
        return call_native_impl(ts, addr, sig, va); });

        // ── Memory read/write (null-safe) ────────────────────────────────────
        // ALL read/write functions check for null before dereferencing.
        // Passing nil or lightuserdata(NULL) returns 0 instead of SIGSEGV.

        // ALL Read functions use msync page probe — catches junk/dangling/freed pointers
        lua.set_function("ReadU8", [](void *addr) -> int
                         {
        if (!ue::is_mapped_ptr(addr)) return 0;
        return *reinterpret_cast<uint8_t*>(addr); });

        lua.set_function("ReadU16", [](void *addr) -> int
                         {
        if (!ue::is_mapped_ptr(addr)) return 0;
        return *reinterpret_cast<uint16_t*>(addr); });

        lua.set_function("ReadU32", [](void *addr) -> uint32_t
                         {
        if (!ue::is_mapped_ptr(addr)) return 0;
        return *reinterpret_cast<uint32_t*>(addr); });

        lua.set_function("ReadU64", [](void *addr) -> double
                         {
        if (!ue::is_mapped_ptr(addr)) return 0.0;
        return static_cast<double>(*reinterpret_cast<uint64_t*>(addr)); });

        lua.set_function("ReadF32", [](void *addr) -> float
                         {
        if (!ue::is_mapped_ptr(addr)) return 0.0f;
        return *reinterpret_cast<float*>(addr); });

        lua.set_function("ReadF64", [](void *addr) -> double
                         {
        if (!ue::is_mapped_ptr(addr)) return 0.0;
        return *reinterpret_cast<double*>(addr); });

        lua.set_function("ReadPtr", [](void *addr) -> sol::lightuserdata_value
                         {
        if (!ue::is_mapped_ptr(addr)) return sol::lightuserdata_value(nullptr);
        void* val = *reinterpret_cast<void**>(addr);
        return sol::lightuserdata_value(val); });

        // ALL Write functions use msync page probe — prevents writes to junk/freed memory
        // Writes landing in EXECUTABLE mappings are recorded (original bytes) in
        // mod_tracker so disabling/unloading the mod restores the original code.
        lua.set_function("WriteU8", [](sol::this_environment te, void *addr, int val)
                         {
        if (!ue::is_mapped_ptr(addr)) return;
        mod_tracker::note_code_write(mod_from_env(te), addr, 1);
        void* page = reinterpret_cast<void*>(reinterpret_cast<uintptr_t>(addr) & ~0xFFFULL);
        mprotect(page, 4096 * 2, PROT_READ | PROT_WRITE | PROT_EXEC);
        *reinterpret_cast<uint8_t*>(addr) = static_cast<uint8_t>(val);
        __builtin___clear_cache(
            reinterpret_cast<char*>(addr),
            reinterpret_cast<char*>(addr) + 1
        ); });

        lua.set_function("WriteU16", [](sol::this_environment te, void *addr, int val)
                         {
        if (!ue::is_mapped_ptr(addr)) return;
        mod_tracker::note_code_write(mod_from_env(te), addr, 2);
        void* page = reinterpret_cast<void*>(reinterpret_cast<uintptr_t>(addr) & ~0xFFFULL);
        mprotect(page, 4096 * 2, PROT_READ | PROT_WRITE | PROT_EXEC);
        *reinterpret_cast<uint16_t*>(addr) = static_cast<uint16_t>(val);
        __builtin___clear_cache(
            reinterpret_cast<char*>(addr),
            reinterpret_cast<char*>(addr) + 2
        ); });

        lua.set_function("WriteU32", [](sol::this_environment te, void *addr, uint32_t val)
                         {
        if (!ue::is_mapped_ptr(addr)) return;
        mod_tracker::note_code_write(mod_from_env(te), addr, 4);
        // Need to make memory writable for code patches
        void* page = reinterpret_cast<void*>(reinterpret_cast<uintptr_t>(addr) & ~0xFFFULL);
        mprotect(page, 4096 * 2, PROT_READ | PROT_WRITE | PROT_EXEC);
        *reinterpret_cast<uint32_t*>(addr) = val;
        // Flush icache for ARM64
        __builtin___clear_cache(
            reinterpret_cast<char*>(addr),
            reinterpret_cast<char*>(addr) + 4
        ); });

        lua.set_function("WriteU64", [](sol::this_environment te, void *addr, double val)
                         {
        if (!ue::is_mapped_ptr(addr)) return;
        mod_tracker::note_code_write(mod_from_env(te), addr, 8);
        void* page = reinterpret_cast<void*>(reinterpret_cast<uintptr_t>(addr) & ~0xFFFULL);
        mprotect(page, 4096 * 2, PROT_READ | PROT_WRITE | PROT_EXEC);
        *reinterpret_cast<uint64_t*>(addr) = static_cast<uint64_t>(val);
        __builtin___clear_cache(
            reinterpret_cast<char*>(addr),
            reinterpret_cast<char*>(addr) + 8
        ); });

        lua.set_function("WriteF32", [](void *addr, float val)
                         {
        if (!ue::is_mapped_ptr(addr)) return;
        *reinterpret_cast<float*>(addr) = val; });

        lua.set_function("WriteF64", [](void *addr, double val)
                         {
        if (!ue::is_mapped_ptr(addr)) return;
        *reinterpret_cast<double*>(addr) = val; });

        lua.set_function("WritePtr", [](sol::this_environment te, void *addr, void *val)
                         {
        if (!ue::is_mapped_ptr(addr)) return;
        mod_tracker::note_code_write(mod_from_env(te), addr, 8);
        void* page = reinterpret_cast<void*>(reinterpret_cast<uintptr_t>(addr) & ~0xFFFULL);
        mprotect(page, 4096 * 2, PROT_READ | PROT_WRITE | PROT_EXEC);
        *reinterpret_cast<void**>(addr) = val;
        __builtin___clear_cache(
            reinterpret_cast<char*>(addr),
            reinterpret_cast<char*>(addr) + 8
        ); });

        // ── Address helpers ─────────────────────────────────────────────────
        lua.set_function("GetLibBase", []() -> sol::lightuserdata_value
                         { return sol::lightuserdata_value(symbols::get_lib_base()); });

        lua.set_function("FindSymbol", [](sol::this_state ts, const std::string &name) -> sol::object
                         {
        sol::state_view lua(ts);
        void* addr = symbols::resolve(name);
        if (!addr) return sol::nil;
        return sol::make_object(lua, sol::lightuserdata_value(addr)); });

        // ── Resolve — modloader-level symbol resolution with optional fallback ─
        // This is the preferred way for mods to resolve native symbols.
        // For UE SDK symbols already resolved at boot (ProcessEvent, StaticFindObject,
        // etc.), dynamic resolution always succeeds — no fallback needed.
        // For game-specific symbols, mods can provide a UE4Dumper fallback offset.
        //
        // Usage from Lua:
        //   local addr = Resolve("SetAmmoCheatState")              -- no fallback, nil if not found
        //   local addr = Resolve("SetAmmoCheatState", 0x0669B930)  -- with fallback offset
        //
        // The full resolution chain: dlsym → phdr scan → pattern scan → fallback offset
        // Every attempt is logged at every priority level.
        // Results are cached — subsequent calls for the same name return instantly.
        lua.set_function("Resolve", [](sol::this_state ts, const std::string &name, sol::optional<int64_t> fallback_offset) -> sol::object
                         {
        sol::state_view lua(ts);
        void* addr = nullptr;
        if (fallback_offset.has_value()) {
            addr = symbols::resolve_with_fallback(name, static_cast<uintptr_t>(*fallback_offset));
        } else {
            addr = symbols::resolve(name);
        }
        if (!addr) return sol::nil;
        return sol::make_object(lua, sol::lightuserdata_value(addr)); });

        lua.set_function("FindPattern", [](sol::this_state ts, const std::string &pattern) -> sol::object
                         {
        sol::state_view lua(ts);
        void* addr = pattern::scan(pattern);
        if (!addr) return sol::nil;
        return sol::make_object(lua, sol::lightuserdata_value(addr)); });

        lua.set_function("Offset", [](void *base, int64_t off) -> sol::lightuserdata_value
                         {
        if (!base) return sol::lightuserdata_value(nullptr);
        return sol::lightuserdata_value(offset_ptr(base, off)); });

        // ── Pointer ↔ integer conversion ────────────────────────────────────
        // Native hooks pass all X-register values as lightuserdata (void*).
        // PtrToInt converts lightuserdata → Lua integer for arithmetic/format.
        // IntToPtr converts Lua integer → lightuserdata for ReadU8/WriteU8/Offset.
        lua.set_function("PtrToInt", [](void *ptr) -> int64_t
                         { return static_cast<int64_t>(reinterpret_cast<uintptr_t>(ptr)); });

        lua.set_function("IntToPtr", [](int64_t val) -> sol::lightuserdata_value
                         { return sol::lightuserdata_value(reinterpret_cast<void *>(static_cast<uintptr_t>(val))); });

        // ── /proc/self/mem access ───────────────────────────────────────────
        // Direct dereference SIGSEGVs on the game's RELRO / physics-arena pages
        // (anti-tamper / PROT_NONE hiding). /proc/self/mem reads via the kernel
        // (FOLL_FORCE) and bypasses that — works on ALL mapped pages, read+write.
        // These are the reliable primitives for reading the YUP physics world.
        static int s_mem_fd = -1;
        auto get_mem_fd = []() -> int {
            if (s_mem_fd < 0) s_mem_fd = open("/proc/self/mem", O_RDWR);
            return s_mem_fd;
        };
        lua.set_function("MemReadU64", [get_mem_fd](int64_t addr) -> int64_t {
            int fd = get_mem_fd(); if (fd < 0) return 0;
            uint64_t v = 0;
            if (pread64(fd, &v, 8, (off64_t)(uintptr_t)addr) != 8) return 0;
            return (int64_t)v; });
        lua.set_function("MemReadFloat", [get_mem_fd](int64_t addr) -> double {
            int fd = get_mem_fd(); if (fd < 0) return 0.0;
            float v = 0.0f;
            if (pread64(fd, &v, 4, (off64_t)(uintptr_t)addr) != 4) return 0.0;
            return (double)v; });
        lua.set_function("MemWriteFloat", [get_mem_fd](int64_t addr, double val) -> bool {
            int fd = get_mem_fd(); if (fd < 0) return false;
            float v = (float)val;
            return pwrite64(fd, &v, 4, (off64_t)(uintptr_t)addr) == 4; });
        lua.set_function("MemWriteU64", [get_mem_fd](int64_t addr, int64_t val) -> bool {
            int fd = get_mem_fd(); if (fd < 0) return false;
            uint64_t v = (uint64_t)val;
            return pwrite64(fd, &v, 8, (off64_t)(uintptr_t)addr) == 8; });

        // ── Heap scanning ───────────────────────────────────────────────────
        // HeapScanPtr(targetInt, maxHits=64) → { addr1, addr2, ... }
        // Scans all rw anon/heap regions for 8-byte-aligned qwords equal to target.
        // Used to find native structs by a back-pointer (e.g. YUP ball_struct that
        // holds a pointer to the UE render component).
        lua.set_function("HeapScanPtr", [](sol::this_state ts, int64_t target, sol::optional<int> max_hits) -> sol::object
                         {
            sol::state_view lua(ts);
            sol::table results = lua.create_table();
            const uintptr_t tval = static_cast<uintptr_t>(target);
            const int cap = max_hits.value_or(64);
            int found = 0;
            std::ifstream maps("/proc/self/maps");
            if (!maps.is_open()) return results;
            std::string line;
            while (std::getline(maps, line) && found < cap) {
                uintptr_t start = 0, end = 0; char perms[8] = {0}; char path[256] = {0};
                int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %255[^\n]", &start, &end, perms, path);
                if (n < 3) continue;
                if (perms[0] != 'r' || perms[1] != 'w') continue;
                bool anon = (n < 4) || path[0] == '\0';
                bool heapish = anon || strncmp(path, "[anon", 5) == 0 || strncmp(path, "[heap", 5) == 0;
                if (!heapish) continue;
                size_t sz = (end > start) ? (end - start) : 0;
                if (sz == 0 || sz > (size_t)1024 * 1024 * 1024) continue;
                safe_call::execute([&]() {
                    for (uintptr_t a = start; a + 8 <= end && found < cap; a += 8) {
                        if (*reinterpret_cast<volatile uintptr_t *>(a) == tval) {
                            results[++found] = static_cast<int64_t>(a);
                        }
                    }
                }, "HeapScanPtr");
            }
            return results; });

        // ── Motion-based struct finding (frame-independent) ──────────────────
        // HeapSnapVec(boxHalf=20, maxEntries=4000000) → count
        //   Snapshots every 4-aligned float triple whose 3 comps are finite,
        //   |comp| <= boxHalf, and not all ~0. Stored natively for HeapFilterMovedVec.
        // HeapFilterMovedVec(dx, dy, dz, tol) → { addr, ... }
        //   Keeps snapshotted triples whose value changed by ~ (dx,dy,dz).
        // Usage: snap while ball at P0; let game run; filter with (P1-P0)*scale.
        lua.set_function("HeapSnapVec", [](double box_half, sol::optional<int> max_entries) -> int
                         {
            g_snap_addr.clear(); g_snap_val.clear();
            const float box = (float)box_half;
            const size_t cap = (size_t)max_entries.value_or(4000000);
            g_snap_addr.reserve(std::min(cap, (size_t)1000000));
            std::ifstream maps("/proc/self/maps");
            if (!maps.is_open()) return 0;
            std::string line;
            while (std::getline(maps, line) && g_snap_addr.size() < cap) {
                uintptr_t start = 0, end = 0; char perms[8] = {0}; char path[256] = {0};
                int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %255[^\n]", &start, &end, perms, path);
                if (n < 3) continue;
                if (perms[0] != 'r' || perms[1] != 'w') continue;
                bool anon = (n < 4) || path[0] == '\0';
                bool heapish = anon || strncmp(path, "[anon", 5) == 0 || strncmp(path, "[heap", 5) == 0;
                if (!heapish) continue;
                size_t sz = (end > start) ? (end - start) : 0;
                if (sz == 0 || sz > (size_t)1024 * 1024 * 1024) continue;
                safe_call::execute([&]() {
                    for (uintptr_t a = start; a + 12 <= end && g_snap_addr.size() < cap; a += 4) {
                        const float *p = reinterpret_cast<const float *>(a);
                        float x = p[0], y = p[1], z = p[2];
                        if (!(x == x) || !(y == y) || !(z == z)) continue;
                        if (fabsf(x) > box || fabsf(y) > box || fabsf(z) > box) continue;
                        if (fabsf(x) < 1e-6f && fabsf(y) < 1e-6f && fabsf(z) < 1e-6f) continue;
                        g_snap_addr.push_back(a);
                        g_snap_val.push_back({x, y, z});
                    }
                }, "HeapSnapVec");
            }
            return (int)g_snap_addr.size(); });

        lua.set_function("HeapFilterMovedVec", [](sol::this_state ts, double dx, double dy, double dz, double tol) -> sol::object
                         {
            sol::state_view lua(ts);
            sol::table results = lua.create_table();
            const float fdx = (float)dx, fdy = (float)dy, fdz = (float)dz, ftol = (float)tol;
            int found = 0;
            safe_call::execute([&]() {
                for (size_t i = 0; i < g_snap_addr.size(); ++i) {
                    const float *p = reinterpret_cast<const float *>(g_snap_addr[i]);
                    float cx = p[0], cy = p[1], cz = p[2];
                    if (!(cx == cx) || !(cy == cy) || !(cz == cz)) continue;
                    if (fabsf((cx - g_snap_val[i][0]) - fdx) <= ftol &&
                        fabsf((cy - g_snap_val[i][1]) - fdy) <= ftol &&
                        fabsf((cz - g_snap_val[i][2]) - fdz) <= ftol) {
                        results[++found] = static_cast<int64_t>(g_snap_addr[i]);
                    }
                }
            }, "HeapFilterMovedVec");
            return results; });

        // HeapFindBallWorld(maxHits=16) → { S1, ... }
        // Finds the YUP physics container S by structural fingerprint (all offsets from IDA):
        //   arr = *(S+0x5C0) is a heap ptr; for some idx in [0,7]:
        //   holder = *(arr+idx*8) heap ptr; bs = *(holder+0xA8) heap ptr; *(bs+4) is a finite float.
        // Race-free / ball-independent: S is stable per loaded table (works paused, between balls).
        lua.set_function("HeapFindBallWorld", [](sol::this_state ts, sol::optional<int> max_hits) -> sol::object
                         {
            sol::state_view lua(ts);
            sol::table results = lua.create_table();
            const int cap = max_hits.value_or(16);
            int found = 0;
            // Build sorted list of mapped [start,end) ranges (r--) so deref-chains never fault.
            std::vector<std::pair<uintptr_t,uintptr_t>> ranges;
            {
                std::ifstream m("/proc/self/maps"); std::string ln;
                while (std::getline(m, ln)) {
                    uintptr_t s=0,e=0; char pr[8]={0};
                    if (sscanf(ln.c_str(),"%lx-%lx %7s",&s,&e,pr)<3) continue;
                    if (pr[0]!='r') continue;
                    ranges.push_back({s,e});
                }
                std::sort(ranges.begin(), ranges.end());
            }
            auto mapped=[&](uintptr_t p, size_t need)->bool{
                if (p < 0x7000000000ULL || p >= 0x8000000000ULL || (p&7)) return false;
                size_t lo=0, hi=ranges.size();
                while (lo<hi){ size_t mid=(lo+hi)/2; if (ranges[mid].first<=p) lo=mid+1; else hi=mid; }
                if (lo==0) return false;
                auto &r=ranges[lo-1];
                return p>=r.first && p+need<=r.second;
            };
            auto rq=[&](uintptr_t p)->uintptr_t{ return *reinterpret_cast<uintptr_t*>(p); };
            std::ifstream maps("/proc/self/maps");
            if (!maps.is_open()) return results;
            std::string line;
            while (std::getline(maps, line) && found < cap) {
                uintptr_t start=0,end=0; char perms[8]={0}; char path[256]={0};
                int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %255[^\n]", &start,&end,perms,path);
                if (n<3) continue;
                if (perms[0]!='r'||perms[1]!='w') continue;
                bool anon=(n<4)||path[0]=='\0';
                bool heapish=anon||strncmp(path,"[anon",5)==0||strncmp(path,"[heap",5)==0;
                if (!heapish) continue;
                size_t sz=(end>start)?(end-start):0; if (sz==0||sz>(size_t)1024*1024*1024) continue;
                // Per-region fault guard: a concurrent unmap/remap can invalidate our snapshot
                // of mapped ranges mid-scan; safe_call catches the SIGSEGV and skips the region.
                safe_call::execute([&]() {
                    for (uintptr_t a=start; a+0x5C8<=end && found<cap; a+=8) {
                        uintptr_t arr = rq(a+0x5C0);
                        if (!mapped(arr, 16*8)) continue;
                        int good=0;
                        for (int idx=0; idx<16; ++idx) {
                            uintptr_t holder = rq(arr+idx*8);
                            if (!mapped(holder, 0xB0)) continue;
                            uintptr_t bs = rq(holder+0xA8);
                            if (!mapped(bs, 0x0C)) continue;
                            float x=*reinterpret_cast<float*>(bs+0);
                            float y=*reinterpret_cast<float*>(bs+4);
                            float z=*reinterpret_cast<float*>(bs+8);
                            if (x==x && y==y && z==z && fabsf(x)<100.f && fabsf(y)<100.f && fabsf(z)<100.f)
                                ++good;
                        }
                        if (good>=3) results[++found]=static_cast<int64_t>(a);
                    }
                }, "HeapFindBallWorld");
            }
            return results; });

        // HeapScanFloatVec(x, y, z, tol=0.5, maxHits=64) → { addrOfX1, ... }
        // Scans rw anon/heap regions (4-byte step) for 3 consecutive floats near (x,y,z).
        lua.set_function("HeapScanFloatVec", [](sol::this_state ts, double x, double y, double z,
                                                sol::optional<double> tol_opt, sol::optional<int> max_hits) -> sol::object
                         {
            sol::state_view lua(ts);
            sol::table results = lua.create_table();
            const float fx = (float)x, fy = (float)y, fz = (float)z;
            const float tol = (float)tol_opt.value_or(0.5);
            const int cap = max_hits.value_or(64);
            int found = 0;
            std::ifstream maps("/proc/self/maps");
            if (!maps.is_open()) return results;
            std::string line;
            while (std::getline(maps, line) && found < cap) {
                uintptr_t start = 0, end = 0; char perms[8] = {0}; char path[256] = {0};
                int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %255[^\n]", &start, &end, perms, path);
                if (n < 3) continue;
                if (perms[0] != 'r' || perms[1] != 'w') continue;
                bool anon = (n < 4) || path[0] == '\0';
                bool heapish = anon || strncmp(path, "[anon", 5) == 0 || strncmp(path, "[heap", 5) == 0;
                if (!heapish) continue;
                size_t sz = (end > start) ? (end - start) : 0;
                if (sz == 0 || sz > (size_t)1024 * 1024 * 1024) continue;
                safe_call::execute([&]() {
                    for (uintptr_t a = start; a + 12 <= end && found < cap; a += 4) {
                        const float *p = reinterpret_cast<const float *>(a);
                        if (fabsf(p[0] - fx) <= tol && fabsf(p[1] - fy) <= tol && fabsf(p[2] - fz) <= tol) {
                            results[++found] = static_cast<int64_t>(a);
                        }
                    }
                }, "HeapScanFloatVec");
            }
            return results; });

        // ── PAK mounting ────────────────────────────────────────────────────
        lua.set_function("MountPak", [](const std::string &pak_name) -> bool
                         { return pak_mounter::mount(pak_name); });

        // ── SDK dump ────────────────────────────────────────────────────────
        // DumpSDK() — re-walks GUObjectArray + regenerates all SDK files
        lua.set_function("DumpSDK", []()
                         {
            int files = sdk_gen::regenerate();
            logger::log_info("LUA", "DumpSDK: re-walked + regenerated %d files (%d classes, %d structs, %d enums)",
                             files, sdk_gen::class_count(), sdk_gen::struct_count(), sdk_gen::enum_count()); });

        // RedumpSDK() — alias for DumpSDK, explicitly re-walks + regenerates
        lua.set_function("RedumpSDK", []()
                         {
            int files = sdk_gen::regenerate();
            logger::log_info("LUA", "RedumpSDK: %d files (%d classes, %d structs, %d enums)",
                             files, sdk_gen::class_count(), sdk_gen::struct_count(), sdk_gen::enum_count()); });

        // ForceRedump() — queue a background re-dump via object monitor
        lua.set_function("ForceRedump", []()
                         {
            object_monitor::force_redump();
            logger::log_info("LUA", "ForceRedump: queued background re-dump"); });

        // GetObjectCount() — cached count from last walk
        lua.set_function("GetObjectCount", []() -> int32_t
                         { return reflection::get_object_count(); });

        // GetLiveObjectCount() — live count from GUObjectArray memory
        lua.set_function("GetLiveObjectCount", []() -> int32_t
                         { return reflection::get_live_object_count(); });

        // GetSDKCounts() — returns {classes=N, structs=N, enums=N}
        lua.set_function("GetSDKCounts", [](sol::this_state ts) -> sol::table
                         {
            sol::state_view lua(ts);
            sol::table t = lua.create_table();
            t["classes"] = sdk_gen::class_count();
            t["structs"] = sdk_gen::struct_count();
            t["enums"] = sdk_gen::enum_count();
            t["objects_walked"] = reflection::get_object_count();
            t["objects_live"] = reflection::get_live_object_count();
            return t; });

        // ── Symbol dump — writes all ELF symbols to file ────────────────────
        lua.set_function("DumpSymbols", [](sol::optional<std::string> custom_path) -> int
                         {
        std::string out_path;
        if (custom_path.has_value() && !custom_path->empty()) {
            out_path = *custom_path;
        } else {
            out_path = paths::data_dir() + "/symbol_dump.txt";
        }
        int count = symbols::dump_symbols(out_path);
        if (count > 0) {
            logger::log_info("LUA", "Symbol dump: %d symbols written to %s", count, out_path.c_str());
        }
        return count; });

        // ── GNames dump — writes all FNamePool entries to txt ────────────────
        lua.set_function("DumpGNames", [](sol::optional<std::string> custom_path) -> int
                         {
        std::string out_path;
        if (custom_path.has_value() && !custom_path->empty()) {
            out_path = *custom_path;
        } else {
            out_path = paths::data_dir() + "/gnames_dump.txt";
        }

        std::ofstream ofs(out_path);
        if (!ofs.is_open()) {
            logger::log_error("LUA", "DumpGNames: cannot open %s for writing", out_path.c_str());
            return 0;
        }

        // Walk FNamePool blocks sequentially — this correctly computes FName indices
        // by traversing each block's entries by their actual byte size.
        // Sequential index iteration (0,1,2,...) is WRONG because FName ComparisonIndex
        // encodes (block << 16 | byte_offset / stride), not a simple counter.
        int count = 0;
        reflection::walk_all_fnames([&](int32_t index, const std::string& name) {
            ofs << "[" << index << "] " << name << "\n";
            count++;
        });

        ofs.flush();
        ofs.close();
        logger::log_info("LUA", "DumpGNames: %d names written to %s", count, out_path.c_str());
        return count; });

        // ── GObjects dump — writes all GUObjectArray entries to txt ──────────
        lua.set_function("DumpGObjects", [](sol::optional<std::string> custom_path) -> int
                         {
        std::string out_path;
        if (custom_path.has_value() && !custom_path->empty()) {
            out_path = *custom_path;
        } else {
            out_path = paths::data_dir() + "/gobjects_dump.txt";
        }

        std::ofstream ofs(out_path);
        if (!ofs.is_open()) {
            logger::log_error("LUA", "DumpGObjects: cannot open %s for writing", out_path.c_str());
            return 0;
        }

        int32_t total = reflection::get_live_object_count();
        int count = 0;

        ofs << "# GUObjectArray Dump — " << total << " total slots\n";
        ofs << "# Format: [Index] ClassName FullPath (Address) Flags=0xHEX\n\n";

        for (int32_t i = 0; i < total; i++) {
            ue::UObject* obj = reflection::get_object_by_index(i);
            if (!obj || !ue::is_valid_ptr(obj)) continue;

            // Get object name
            std::string obj_name = reflection::get_short_name(obj);
            if (obj_name.empty()) continue;

            // Get full path (Package.Outer.Name)
            std::string full_name = reflection::get_full_name(obj);

            // Get class name
            std::string class_name = "???";
            ue::UClass* cls = ue::uobj_get_class(obj);
            if (cls && ue::is_valid_ptr(cls)) {
                class_name = reflection::get_short_name(reinterpret_cast<const ue::UObject*>(cls));
            }

            // Get flags
            int32_t flags = ue::uobj_get_flags(obj);

            // Write line: [Index] ClassName FullPath (0xAddr) Flags=0xHEX
            char addr_buf[32];
            snprintf(addr_buf, sizeof(addr_buf), "0x%lX", (unsigned long)(uintptr_t)obj);

            ofs << "[" << i << "] " << class_name << " " << full_name
                << " (" << addr_buf << ") Flags=0x" << std::hex << flags << std::dec << "\n";
            count++;
        }

        ofs.flush();
        ofs.close();
        logger::log_info("LUA", "DumpGObjects: %d objects written to %s (of %d total slots)",
                         count, out_path.c_str(), total);
        return count; });

        // ── Iteration ───────────────────────────────────────────────────────
        lua.set_function("ForEachUObject", [](sol::this_state ts, sol::function callback)
                         {
        sol::state_view lua(ts);
        int32_t count = reflection::get_live_object_count();
        warn_bridge_bulk_scan("ForEachUObject", count);
        for (int32_t i = 0; i < count; i++) {
            ue::UObject* obj = reflection::get_object_by_index(i);
            if (!is_safe_bulk_scan_object(obj)) continue;

            std::string name = reflection::get_short_name(obj);

            lua_uobject::LuaUObject wrapped;
            wrapped.ptr = obj;
            auto result = callback(wrapped, name);
            // Return true from callback to stop iteration
            if (result.valid() && result.get_type() == sol::type::boolean && result.get<bool>()) break;
        } });

        lua.set_function("GetKnownClasses", [](sol::this_state ts) -> sol::table
                         {
        sol::state_view lua(ts);
        auto& classes = reflection::get_classes();
        sol::table t = lua.create_table();
        int i = 1;
        for (const auto& ci : classes) {
            t[i++] = ci.name;
        }
        return t; });

        // ── Hex formatting helper ───────────────────────────────────────────
        lua.set_function("ToHex", [](void *addr) -> std::string
                         {
        char buf[32];
        snprintf(buf, sizeof(buf), "0x%016lX", (unsigned long)reinterpret_cast<uintptr_t>(addr));
        return std::string(buf); });

        // ── Null pointer detection helpers ──────────────────────────────────
        // In Lua, lightuserdata(NULL) == 0 is ALWAYS FALSE.
        // lightuserdata(NULL) == nil is ALWAYS FALSE.
        // These helpers correctly detect null pointers from Lua.

        // IsNull(ptr) → true if pointer is NULL
        // Usage: if IsNull(somePtr) then ... end
        lua.set_function("IsNull", [](void *addr) -> bool
                         { return addr == nullptr; });

        // IsValidPtr(ptr) → true if pointer is non-null AND mapped in memory
        // Uses msync to probe page mapping without risking a crash.
        // Usage: if IsValidPtr(somePtr) then ReadU8(somePtr) end
        lua.set_function("IsValidPtr", [](void *addr) -> bool
                         { return ue::is_mapped_ptr(addr); });

        // ── Memory read/write ALIASES (mod compatibility) ───────────────────
        // Mods use ReadFloat/WriteFloat/ReadPointer/ReadS32/WriteS32
        // instead of ReadF32/WriteF32/ReadPtr
        // Aliases also use msync page probe
        lua.set_function("ReadFloat", [](void *addr) -> float
                         {
        if (!ue::is_mapped_ptr(addr)) return 0.0f;
        return *reinterpret_cast<float*>(addr); });

        lua.set_function("WriteFloat", [](void *addr, float val)
                         {
        if (!ue::is_mapped_ptr(addr)) return;
        *reinterpret_cast<float*>(addr) = val; });

        lua.set_function("ReadPointer", [](void *addr) -> sol::lightuserdata_value
                         {
        if (!ue::is_mapped_ptr(addr)) return sol::lightuserdata_value(nullptr);
        void* val = *reinterpret_cast<void**>(addr);
        return sol::lightuserdata_value(val); });

        lua.set_function("ReadS32", [](void *addr) -> int32_t
                         {
        if (!ue::is_mapped_ptr(addr)) return 0;
        return *reinterpret_cast<int32_t*>(addr); });

        lua.set_function("WriteS32", [](void *addr, int32_t val)
                         {
        if (!ue::is_mapped_ptr(addr)) return;
        *reinterpret_cast<int32_t*>(addr) = val; });

        // ── Memory allocation ───────────────────────────────────────────────
        lua.set_function("AllocateMemory", [](int size) -> sol::lightuserdata_value
                         {
        void* mem = calloc(1, static_cast<size_t>(size));
        if (mem) {
            logger::log_info("LUA", "AllocateMemory: %d bytes @ 0x%lX",
                             size, (unsigned long)reinterpret_cast<uintptr_t>(mem));
        } else {
            logger::log_error("LUA", "AllocateMemory: failed to allocate %d bytes", size);
        }
        return sol::lightuserdata_value(mem); });

        // ── ADB command registration ────────────────────────────────────────
        lua.set_function("RegisterCommand", [](sol::this_environment te, const std::string &name, sol::function callback)
                         {
        mod_tracker::track_command(mod_from_env(te), name);
        adb_bridge::register_command(name, [callback](const std::string& args) -> std::string {
            sol::protected_function_result result;
            if (args.empty()) {
                result = callback();
            } else {
                result = callback(args);
            }
            if (result.valid() && result.return_count() > 0) {
                sol::object r0 = result[0];
                if (r0.get_type() == sol::type::string) {
                    return r0.as<std::string>();
                }
            }
            return std::string("ok");
        });
        logger::log_info("LUA", "RegisterCommand: '%s'", name.c_str()); });

        // ── RegisterBridgeCommand — like RegisterCommand, but the callback may
        //    RETURN a table (serialized to JSON for the reply) and RECEIVE its
        //    args as a parsed Lua table (from the request's JSON params) instead
        //    of a raw string. Used by DebugMenuAPI (debugmenu_status/pages/toggle
        //    etc.). Registers into the SAME bridge dispatch as RegisterCommand.
        lua.set_function("RegisterBridgeCommand", [](sol::this_state /*ts*/, sol::this_environment te, const std::string &name, sol::function callback)
                         {
        mod_tracker::track_command(mod_from_env(te), name);
        adb_bridge::register_command(name, [callback](const std::string& args) -> std::string {
            sol::state_view L(callback.lua_state());

            // JSON string → Lua value (nil/bool/number/string/array/object)
            std::function<sol::object(const nlohmann::json&)> json_to_lua;
            json_to_lua = [&](const nlohmann::json& v) -> sol::object {
                if (v.is_boolean())        return sol::make_object(L, v.get<bool>());
                if (v.is_number_integer()) return sol::make_object(L, v.get<int64_t>());
                if (v.is_number())         return sol::make_object(L, v.get<double>());
                if (v.is_string())         return sol::make_object(L, v.get<std::string>());
                if (v.is_array())  { sol::table t = L.create_table(); int i = 1; for (auto& e : v) t[i++] = json_to_lua(e); return t; }
                if (v.is_object()) { sol::table t = L.create_table(); for (auto it = v.begin(); it != v.end(); ++it) t[it.key()] = json_to_lua(it.value()); return t; }
                return sol::make_object(L, sol::nil);
            };

            // Lua value → JSON (bool/number/string/table)
            std::function<nlohmann::json(const sol::object&)> lua_to_json;
            lua_to_json = [&](const sol::object& obj) -> nlohmann::json {
                switch (obj.get_type()) {
                    case sol::type::boolean: return obj.as<bool>();
                    case sol::type::number: {
                        double d = obj.as<double>(); int64_t i = static_cast<int64_t>(d);
                        return (static_cast<double>(i) == d) ? nlohmann::json(i) : nlohmann::json(d);
                    }
                    case sol::type::string: return obj.as<std::string>();
                    case sol::type::table: {
                        sol::table t = obj.as<sol::table>();
                        bool is_array = true; int expected = 1;
                        for (auto& kv : t) { if (kv.first.get_type() != sol::type::number || kv.first.as<int>() != expected) { is_array = false; break; } expected++; }
                        if (is_array && expected > 1) { nlohmann::json a = nlohmann::json::array(); for (auto& kv : t) a.push_back(lua_to_json(kv.second)); return a; }
                        nlohmann::json o = nlohmann::json::object();
                        for (auto& kv : t) {
                            std::string key;
                            if (kv.first.get_type() == sol::type::string) key = kv.first.as<std::string>();
                            else if (kv.first.get_type() == sol::type::number) key = std::to_string(kv.first.as<int>());
                            else continue;
                            o[key] = lua_to_json(kv.second);
                        }
                        return o;
                    }
                    default: return nullptr;
                }
            };

            sol::protected_function_result result;
            if (!args.empty()) {
                nlohmann::json j = nlohmann::json::parse(args, nullptr, false);
                result = j.is_discarded() ? callback(args) : callback(json_to_lua(j));
            } else {
                result = callback();
            }

            if (!result.valid()) {
                sol::error err = result;
                return std::string("{\"ok\":false,\"error\":\"") + err.what() + "\"}";
            }
            if (result.return_count() == 0) return std::string("ok");
            sol::object r0 = result[0];
            if (r0.get_type() == sol::type::string) return r0.as<std::string>();
            return lua_to_json(r0).dump();
        });
        logger::log_info("LUA", "RegisterBridgeCommand: '%s'", name.c_str()); });

        // ── Debug menu entries (basic implementation) ────────────────────────
        // Stores menu entries for DebugMenuAPI to query
        lua.set_function("RegisterMenuEntry", [](sol::this_state ts, const std::string &id,
                                                 const std::string &label,
                                                 const std::string &type)
                         {
        // Store in a global Lua table for DebugMenuAPI to read
        sol::state_view lua(ts);
        sol::object menu_obj = lua["__menu_entries"];
        sol::table menu;
        if (menu_obj.get_type() != sol::type::table) {
            lua["__menu_entries"] = lua.create_table();
            menu = lua["__menu_entries"];
        } else {
            menu = menu_obj.as<sol::table>();
        }
        sol::table entry = lua.create_table();
        entry["id"] = id;
        entry["label"] = label;
        entry["type"] = type;
        menu[id] = entry;
        logger::log_info("LUA", "RegisterMenuEntry: '%s' (%s, %s)", id.c_str(), label.c_str(), type.c_str()); });

        // ── Mod Config — per-mod JSON save/load ─────────────────────────────
        // ModConfig.Load(modName) → table or nil
        // ModConfig.Save(modName, table) → bool
        // Files stored at <data_dir>/mods/<modName>/config.json
        sol::table mod_config = lua.create_named_table("ModConfig");

        mod_config.set_function("Load", [](sol::this_state ts, const std::string &mod_name) -> sol::object
                                {
        sol::state_view lua(ts);
        std::string config_path = paths::mods_dir() + "/" + mod_name + "/config.json";

        struct stat st;
        if (stat(config_path.c_str(), &st) != 0) {
            return sol::nil;
        }

        std::ifstream ifs(config_path);
        if (!ifs.is_open()) {
            logger::log_warn("CONFIG", "ModConfig.Load: cannot open %s", config_path.c_str());
            return sol::nil;
        }

        nlohmann::json j = nlohmann::json::parse(ifs, nullptr, false);
        if (j.is_discarded()) {
            logger::log_warn("CONFIG", "ModConfig.Load: parse error in %s", config_path.c_str());
            return sol::nil;
        }

        // Convert JSON to Lua table recursively
        std::function<sol::object(sol::state_view&, const nlohmann::json&)> json_to_lua;
        json_to_lua = [&](sol::state_view& L, const nlohmann::json& val) -> sol::object {
            if (val.is_null()) return sol::nil;
            if (val.is_boolean()) return sol::make_object(L, val.get<bool>());
            if (val.is_number_integer()) return sol::make_object(L, val.get<int64_t>());
            if (val.is_number_float()) return sol::make_object(L, val.get<double>());
            if (val.is_string()) return sol::make_object(L, val.get<std::string>());
            if (val.is_array()) {
                sol::table t = L.create_table();
                int i = 1;
                for (const auto& elem : val) {
                    t[i++] = json_to_lua(L, elem);
                }
                return t;
            }
            if (val.is_object()) {
                sol::table t = L.create_table();
                for (auto it = val.begin(); it != val.end(); ++it) {
                    t[it.key()] = json_to_lua(L, it.value());
                }
                return t;
            }
            return sol::nil;
        };

        logger::log_info("CONFIG", "ModConfig.Load: loaded %s", config_path.c_str());
        return json_to_lua(lua, j); });

        mod_config.set_function("Save", [](sol::this_state ts, const std::string &mod_name, sol::table data) -> bool
                                {
        std::string mod_dir = paths::mods_dir() + "/" + mod_name;
        std::string config_path = mod_dir + "/config.json";

        // Ensure mod directory exists
        mkdir(mod_dir.c_str(), 0755);

        // Convert Lua table to JSON recursively
        std::function<nlohmann::json(const sol::object&)> lua_to_json;
        lua_to_json = [&](const sol::object& obj) -> nlohmann::json {
            switch (obj.get_type()) {
                case sol::type::boolean: return obj.as<bool>();
                case sol::type::number: {
                    double d = obj.as<double>();
                    int64_t i = static_cast<int64_t>(d);
                    if (static_cast<double>(i) == d) return i;
                    return d;
                }
                case sol::type::string: return obj.as<std::string>();
                case sol::type::table: {
                    sol::table t = obj.as<sol::table>();
                    // Check if array-like (sequential integer keys starting at 1)
                    bool is_array = true;
                    int expected = 1;
                    for (auto& kv : t) {
                        if (kv.first.get_type() != sol::type::number ||
                            kv.first.as<int>() != expected) {
                            is_array = false;
                            break;
                        }
                        expected++;
                    }
                    if (is_array && expected > 1) {
                        nlohmann::json arr = nlohmann::json::array();
                        for (auto& kv : t) {
                            arr.push_back(lua_to_json(kv.second));
                        }
                        return arr;
                    }
                    nlohmann::json obj_json = nlohmann::json::object();
                    for (auto& kv : t) {
                        std::string key;
                        if (kv.first.get_type() == sol::type::string)
                            key = kv.first.as<std::string>();
                        else if (kv.first.get_type() == sol::type::number)
                            key = std::to_string(kv.first.as<int>());
                        else continue;
                        obj_json[key] = lua_to_json(kv.second);
                    }
                    return obj_json;
                }
                default: return nullptr;
            }
        };

        nlohmann::json j = lua_to_json(data);

        std::ofstream ofs(config_path);
        if (!ofs.is_open()) {
            logger::log_error("CONFIG", "ModConfig.Save: cannot write %s", config_path.c_str());
            return false;
        }

        ofs << j.dump(4) << std::endl;
        logger::log_info("CONFIG", "ModConfig.Save: saved %s", config_path.c_str());
        return true; });

        mod_config.set_function("GetPath", [](const std::string &mod_name) -> std::string
                                { return paths::mods_dir() + "/" + mod_name + "/config.json"; });

        // SharedAPI is initialized as a pure Lua global table via lua_engine::init_shared_api()
        // It is NOT registered from C++. See .copilot-instructions.md SharedAPI section.

        // ── File I/O helpers for mods ───────────────────────────────────────
        lua.set_function("ReadTextFile", [](sol::this_state ts, const std::string &path) -> sol::object
                         {
        sol::state_view lua(ts);
        std::ifstream ifs(path);
        if (!ifs.is_open()) return sol::nil;
        std::string content((std::istreambuf_iterator<char>(ifs)),
                             std::istreambuf_iterator<char>());
        return sol::make_object(lua, content); });

        lua.set_function("WriteTextFile", [](const std::string &path, const std::string &content) -> bool
                         {
        std::ofstream ofs(path);
        if (!ofs.is_open()) {
            logger::log_error("LUA", "WriteTextFile: cannot write %s", path.c_str());
            return false;
        }
        ofs << content;
        return true; });

        lua.set_function("FileExists", [](const std::string &path) -> bool
                         {
        struct stat st;
        return stat(path.c_str(), &st) == 0; });

        lua.set_function("GetModDir", [](const std::string &mod_name) -> std::string
                         { return paths::mods_dir() + "/" + mod_name; });

        lua.set_function("GetDataDir", []() -> std::string
                         { return paths::data_dir(); });

        // Memory toolkit: scanner / inspector / hardware watchpoint / AOB (lua_memtools.cpp)
        register_memtools(lua);

        logger::log_info("LUA", "All global Lua API functions registered");
    }

} // namespace lua_bindings
