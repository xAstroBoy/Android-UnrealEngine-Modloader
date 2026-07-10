// modloader/src/reflection/ida_mapping_generator.cpp
// IDA / Ghidra / x64dbg mapping generator — Dumper-7 style function renaming.
//
// For every native UFunction discovered by reflection::walk_all(), reads the
// EXEC native pointer (UFunction::Func), converts it to a module RVA, and emits
// disassembler scripts that rename those addresses to "<Class>_<Function>".
//
// See ida_mapping_generator.h for the output file list and format notes.

#include "modloader/ida_mapping_generator.h"
#include "modloader/reflection_walker.h"
#include "modloader/symbols.h"
#include "modloader/game_profile.h"
#include "modloader/paths.h"
#include "modloader/logger.h"
#include "modloader/types.h"

#include <cstdio>
#include <cstring>
#include <cerrno>
#include <cstdint>
#include <string>
#include <vector>
#include <map>
#include <unordered_map>
#include <unordered_set>
#include <algorithm>
#include <ctime>
#include <sys/stat.h>

namespace ida_map
{
    static int s_func_count = 0;
    static int s_global_count = 0;

    // ── One renamed address ────────────────────────────────────────────────
    struct MapEntry
    {
        uintptr_t rva;          // addr - engine module base
        std::string ident;      // sanitized, unique IDA identifier
        std::string full_name;  // ClassName::FunctionName  (comment)
        std::string ue_path;    // /Script/Pkg.Class:Function (comment)
        uint32_t flags;         // EFunctionFlags
        bool is_code;           // true = function, false = data global
    };

    // ── Engine module address range (from /proc/self/maps) ──────────────────
    // Used to reject Func pointers that don't live inside the engine library
    // (blueprint functions share UObject::ProcessInternal, and a handful of
    // game natives may live in other libs — those must not be emitted with a
    // bogus RVA relative to the engine base).
    struct ModuleRange
    {
        uintptr_t start = 0;
        uintptr_t end = 0;
        bool valid = false;
    };

    static ModuleRange get_engine_module_range()
    {
        ModuleRange r;
        const std::string &lib_name = game_profile::engine_lib_name();
        FILE *f = fopen("/proc/self/maps", "r");
        if (!f)
            return r;
        char line[1024];
        while (fgets(line, sizeof(line), f))
        {
            // Only consider lines that name the engine lib, or the common
            // fallbacks when the profile lib name doesn't match this build.
            if (!strstr(line, lib_name.c_str()) &&
                !strstr(line, "libUE4.so") &&
                !strstr(line, "libUnreal4.so") &&
                !strstr(line, "libUnreal.so"))
                continue;
            uintptr_t start = 0, end = 0;
            if (sscanf(line, "%lx-%lx", &start, &end) == 2)
            {
                if (!r.valid)
                {
                    r.start = start;
                    r.end = end;
                    r.valid = true;
                }
                else
                {
                    if (start < r.start)
                        r.start = start;
                    if (end > r.end)
                        r.end = end;
                }
            }
        }
        fclose(f);
        return r;
    }

    // ── Sanitize a name into a valid IDA/C identifier ──────────────────────
    // IDA names must match [A-Za-z_][A-Za-z0-9_]*. Replace anything else with
    // '_' and prefix a digit-leading name with '_'.
    static std::string sanitize_ident(const std::string &in)
    {
        std::string out;
        out.reserve(in.size());
        for (char c : in)
        {
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
                (c >= '0' && c <= '9') || c == '_')
                out.push_back(c);
            else
                out.push_back('_');
        }
        if (out.empty())
            out = "unnamed";
        if (out[0] >= '0' && out[0] <= '9')
            out = "_" + out;
        return out;
    }

    // Escape a string for embedding in a Python double-quoted literal.
    static std::string py_escape(const std::string &in)
    {
        std::string out;
        out.reserve(in.size() + 4);
        for (char c : in)
        {
            if (c == '\\' || c == '"')
                out.push_back('\\');
            out.push_back(c);
        }
        return out;
    }

    // Escape a string for a JSON string literal.
    static std::string json_escape(const std::string &in)
    {
        std::string out;
        out.reserve(in.size() + 4);
        for (char c : in)
        {
            switch (c)
            {
            case '\\':
                out += "\\\\";
                break;
            case '"':
                out += "\\\"";
                break;
            case '\n':
                out += "\\n";
                break;
            case '\r':
                out += "\\r";
                break;
            case '\t':
                out += "\\t";
                break;
            default:
                out.push_back(c);
            }
        }
        return out;
    }

    static void ensure_dir(const std::string &dir)
    {
        mkdir(dir.c_str(), 0755);
    }

    // Build the "flags" descriptor string for a UFunction (for comments).
    static std::string func_flags_str(uint32_t flags)
    {
        std::string s;
        if (flags & ue::FUNC_Native)
            s += "Native ";
        if (flags & ue::FUNC_Static)
            s += "Static ";
        if (flags & ue::FUNC_Event)
            s += "Event ";
        if (flags & ue::FUNC_BlueprintCallable)
            s += "BlueprintCallable ";
        if (!s.empty() && s.back() == ' ')
            s.pop_back();
        return s;
    }

    // ── Collect every native UFunction address → MapEntry ──────────────────
    static std::vector<MapEntry> collect_functions(uintptr_t base, const ModuleRange &range)
    {
        std::vector<MapEntry> entries;
        const auto &classes = reflection::get_classes();

        // Track how many times each address is claimed. Non-native functions
        // all point at the shared VM entry (ProcessInternal); if a native
        // pointer somehow collides we keep only the first and note it.
        std::unordered_map<uintptr_t, int> addr_uses;
        std::unordered_set<std::string> used_idents;

        for (const auto &ci : classes)
        {
            for (const auto &fi : ci.functions)
            {
                // Only native functions have a meaningful, unique exec pointer.
                if (!(fi.flags & ue::FUNC_Native))
                    continue;
                if (!fi.raw)
                    continue;

                void *fp = ue::ufunc_get_func_ptr(fi.raw);
                uintptr_t addr = reinterpret_cast<uintptr_t>(fp);
                if (addr == 0)
                    continue;

                // Must live inside the engine module (reject shared VM entry
                // and out-of-module natives that would get a bogus RVA).
                if (range.valid)
                {
                    if (addr < range.start || addr >= range.end)
                        continue;
                }
                else
                {
                    if (addr < base)
                        continue;
                }

                // De-duplicate colliding addresses (keeps the interpreter entry
                // from being renamed to one arbitrary function).
                if (++addr_uses[addr] > 1)
                    continue;

                MapEntry e;
                e.rva = addr - base;
                e.full_name = ci.name + "::" + fi.name;
                e.ue_path = ci.full_name.empty() ? (ci.name + ":" + fi.name)
                                                 : (ci.full_name + ":" + fi.name);
                e.flags = fi.flags;
                e.is_code = true;

                // Unique identifier: exec_<Class>_<Function>, disambiguated.
                std::string base_ident = sanitize_ident("exec_" + ci.name + "_" + fi.name);
                std::string ident = base_ident;
                int suffix = 1;
                while (used_idents.count(ident))
                    ident = base_ident + "_" + std::to_string(suffix++);
                used_idents.insert(ident);
                e.ident = ident;

                entries.push_back(std::move(e));
            }
        }

        // Sort by RVA for stable, diff-friendly output.
        std::sort(entries.begin(), entries.end(),
                  [](const MapEntry &a, const MapEntry &b)
                  { return a.rva < b.rva; });
        return entries;
    }

    // ── Collect resolved engine globals/exports ────────────────────────────
    static std::vector<MapEntry> collect_globals(uintptr_t base, const ModuleRange &range)
    {
        std::vector<MapEntry> entries;

        auto add = [&](const char *name, void *ptr, bool is_code)
        {
            uintptr_t addr = reinterpret_cast<uintptr_t>(ptr);
            if (addr == 0)
                return;
            if (range.valid)
            {
                if (addr < range.start || addr >= range.end)
                    return;
            }
            else if (addr < base)
                return;

            MapEntry e;
            e.rva = addr - base;
            e.ident = sanitize_ident(name);
            e.full_name = name;
            e.ue_path = name;
            e.flags = 0;
            e.is_code = is_code;
            entries.push_back(std::move(e));
        };

        // Code exports.
        add("UObject__ProcessEvent", reinterpret_cast<void *>(symbols::ProcessEvent), true);
        add("StaticFindObject", reinterpret_cast<void *>(symbols::StaticFindObject), true);
        add("StaticLoadObject", reinterpret_cast<void *>(symbols::StaticLoadObject), true);
        add("StaticConstructObject_Internal", reinterpret_cast<void *>(symbols::StaticConstructObject), true);
        add("FName__Init", reinterpret_cast<void *>(symbols::FName_Init), true);
        add("GetTransientPackage", reinterpret_cast<void *>(symbols::GetTransientPackage), true);

        // Data globals.
        add("GUObjectArray", symbols::GUObjectArray, false);
        add("GNames", symbols::GNames, false);
        add("GEngine", symbols::GEngine, false);
        add("GWorld", symbols::GWorld, false);

        std::sort(entries.begin(), entries.end(),
                  [](const MapEntry &a, const MapEntry &b)
                  { return a.rva < b.rva; });
        return entries;
    }

    // ── IDAPython script writer ─────────────────────────────────────────────
    static bool write_idapython(const std::string &path,
                                const std::string &title,
                                const std::vector<MapEntry> &entries)
    {
        FILE *f = fopen(path.c_str(), "w");
        if (!f)
        {
            logger::log_error("IDAMAP", "fopen failed for %s: %s", path.c_str(), strerror(errno));
            return false;
        }

        fprintf(f, "# %s\n", title.c_str());
        fprintf(f, "# Auto-generated by Quest UE4 ModLoader (live reflection walk).\n");
        fprintf(f, "# Load libUE4.so in IDA, then run:  File > Script file...  (this .py)\n");
        fprintf(f, "# RVAs are relative to the engine module base; get_imagebase() rebases them.\n#\n");
        fprintf(f, "import idaapi, idc, ida_name\n\n");
        fprintf(f, "BASE = idaapi.get_imagebase()\n");
        fprintf(f, "renamed = 0\n");
        fprintf(f, "skipped = 0\n\n");
        fprintf(f, "def nm(rva, name, comment, is_code):\n");
        fprintf(f, "    global renamed, skipped\n");
        fprintf(f, "    ea = BASE + rva\n");
        fprintf(f, "    # SN_NOWARN suppresses dialogs; names are already unique.\n");
        fprintf(f, "    if idc.set_name(ea, name, idc.SN_NOWARN):\n");
        fprintf(f, "        renamed += 1\n");
        fprintf(f, "    else:\n");
        fprintf(f, "        skipped += 1\n");
        fprintf(f, "    if comment:\n");
        fprintf(f, "        idc.set_cmt(ea, comment, 1)\n\n");

        for (const auto &e : entries)
        {
            std::string comment = e.full_name;
            if (!e.ue_path.empty() && e.ue_path != e.full_name)
                comment += "  |  " + e.ue_path;
            std::string fstr = func_flags_str(e.flags);
            if (!fstr.empty())
                comment += "  [" + fstr + "]";

            fprintf(f, "nm(0x%lX, \"%s\", \"%s\", %s)\n",
                    (unsigned long)e.rva,
                    py_escape(e.ident).c_str(),
                    py_escape(comment).c_str(),
                    e.is_code ? "True" : "False");
        }

        fprintf(f, "\nprint(\"[UEModLoader] %s: %%d renamed, %%d skipped (of %zu)\" %% (renamed, skipped))\n",
                title.c_str(), entries.size());
        fclose(f);
        return true;
    }

    // ── Ghidra / generic symbol map writer ("<name> 0x<rva>") ───────────────
    // Compatible with Ghidra's ImportSymbolsScript.py (name, address, [type]).
    static bool write_symbol_map(const std::string &path,
                                 const std::vector<MapEntry> &funcs,
                                 const std::vector<MapEntry> &globals)
    {
        FILE *f = fopen(path.c_str(), "w");
        if (!f)
        {
            logger::log_error("IDAMAP", "fopen failed for %s: %s", path.c_str(), strerror(errno));
            return false;
        }
        fprintf(f, "# Quest UE4 ModLoader symbol map — RVAs relative to engine module base.\n");
        fprintf(f, "# Ghidra: run ImportSymbolsScript.py and pick this file.\n");
        for (const auto &e : globals)
            fprintf(f, "%s 0x%lX %s\n", e.ident.c_str(), (unsigned long)e.rva, e.is_code ? "f" : "l");
        for (const auto &e : funcs)
            fprintf(f, "%s 0x%lX f\n", e.ident.c_str(), (unsigned long)e.rva);
        fclose(f);
        return true;
    }

    // ── JSON writer ─────────────────────────────────────────────────────────
    static bool write_json(const std::string &path,
                           uintptr_t base,
                           const std::vector<MapEntry> &funcs,
                           const std::vector<MapEntry> &globals)
    {
        FILE *f = fopen(path.c_str(), "w");
        if (!f)
        {
            logger::log_error("IDAMAP", "fopen failed for %s: %s", path.c_str(), strerror(errno));
            return false;
        }

        time_t now = time(nullptr);
        struct tm tm_info;
        localtime_r(&now, &tm_info);
        char timebuf[64];
        strftime(timebuf, sizeof(timebuf), "%Y-%m-%dT%H:%M:%SZ", &tm_info);

        fprintf(f, "{\n");
        fprintf(f, "  \"generated\": \"%s\",\n", timebuf);
        fprintf(f, "  \"engine_lib\": \"%s\",\n", json_escape(game_profile::engine_lib_name()).c_str());
        fprintf(f, "  \"engine_base\": \"0x%lX\",\n", (unsigned long)base);
        fprintf(f, "  \"function_count\": %zu,\n", funcs.size());
        fprintf(f, "  \"global_count\": %zu,\n", globals.size());

        auto emit_array = [&](const char *key, const std::vector<MapEntry> &v)
        {
            fprintf(f, "  \"%s\": [\n", key);
            for (size_t i = 0; i < v.size(); i++)
            {
                const auto &e = v[i];
                fprintf(f, "    {\"rva\": \"0x%lX\", \"name\": \"%s\", \"full_name\": \"%s\", "
                           "\"ue_path\": \"%s\", \"flags\": \"0x%X\", \"kind\": \"%s\"}%s\n",
                        (unsigned long)e.rva,
                        json_escape(e.ident).c_str(),
                        json_escape(e.full_name).c_str(),
                        json_escape(e.ue_path).c_str(),
                        e.flags,
                        e.is_code ? "code" : "data",
                        (i + 1 < v.size()) ? "," : "");
            }
            fprintf(f, "  ]");
        };

        emit_array("globals", globals);
        fprintf(f, ",\n");
        emit_array("functions", funcs);
        fprintf(f, "\n}\n");
        fclose(f);
        return true;
    }

    int generate()
    {
        s_func_count = 0;
        s_global_count = 0;

        uintptr_t base = symbols::lib_base();
        if (base == 0)
        {
            logger::log_error("IDAMAP", "engine module base is 0 — cannot compute RVAs. "
                                        "Is the engine library loaded and symbols::init() done?");
            return 0;
        }

        ModuleRange range = get_engine_module_range();
        if (range.valid)
        {
            logger::log_info("IDAMAP", "engine module range: 0x%lX-0x%lX (base 0x%lX)",
                             (unsigned long)range.start, (unsigned long)range.end, (unsigned long)base);
        }
        else
        {
            logger::log_warn("IDAMAP", "could not read engine module range from /proc/self/maps — "
                                       "using base-only lower bound");
        }

        std::vector<MapEntry> funcs = collect_functions(base, range);
        std::vector<MapEntry> globals = collect_globals(base, range);

        s_func_count = static_cast<int>(funcs.size());
        s_global_count = static_cast<int>(globals.size());

        if (funcs.empty())
        {
            logger::log_warn("IDAMAP", "no native UFunction exec pointers found — "
                                       "reflection cache may be empty (run a walk first)");
        }

        std::string dir = paths::ida_dir();
        ensure_dir(dir);

        int files = 0;
        if (write_idapython(dir + "UnrealFunctions.py", "UnrealFunctions", funcs))
            files++;
        if (write_idapython(dir + "UnrealGlobals.py", "UnrealGlobals", globals))
            files++;
        if (write_symbol_map(dir + "UnrealSymbols.map", funcs, globals))
            files++;
        if (write_json(dir + "UnrealMappings.json", base, funcs, globals))
            files++;

        logger::log_info("IDAMAP", "IDA mapping complete: %d functions, %d globals, %d files in %s",
                         s_func_count, s_global_count, files, dir.c_str());
        return files;
    }

    int function_count() { return s_func_count; }
    int global_count() { return s_global_count; }

} // namespace ida_map
