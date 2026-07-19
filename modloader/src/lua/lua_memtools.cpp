// modloader/src/lua/lua_memtools.cpp
// Cheat-Engine-style memory toolkit exposed to Lua:
//   • Typed value scanner   — MemScanFirst / MemScanNext / MemScanList / MemScanCount / MemScanReset
//   • Inspector             — MemRegions / SymAddr / MemReadU8/U16/U32 / MemWriteU8/U16/U32 / MemReadBytes
//   • Find-what-accesses    — WatchAccess / WatchRead / WatchStop / WatchList
//
// The watchpoint uses an ARM64 HARDWARE breakpoint via perf_event_open with a
// PERF_SAMPLE_IP sampling ring buffer. When the watched thread reads/writes the
// address, the kernel records the writing instruction's PC into the ring buffer
// (no signal handler needed) — exactly like Cheat-Engine's "find out what writes
// to this address". Requires kernel.perf_event_paranoid <= 2 (we set -1 on root).
//
// perf_event_open with pid=0 attaches to the CALLING thread. Bridge exec_lua runs
// on the game thread, so watchpoints created from a bridge call watch the game
// thread — where gameplay/score writes happen.

#include "modloader/lua_bindings.h"
#include "modloader/safe_call.h"
#include "modloader/logger.h"
#include "modloader/pattern_scanner.h"
#include "modloader/memtrace.h"
#include "modloader/paths.h"

#include <sol/sol.hpp>

#include <cstdint>
#include <cstring>
#include <cstdio>
#include <cerrno>
#include <cmath>
#include <string>
#include <vector>
#include <map>
#include <unordered_map>
#include <algorithm>
#include <fstream>
#include <cctype>
#include <atomic>
#include <mutex>
#include <ctime>

#include <unistd.h>
#include <fcntl.h>
#include <sys/mman.h>
#include <sys/ioctl.h>
#include <sys/syscall.h>
#include <linux/perf_event.h>
#include <linux/hw_breakpoint.h>

namespace lua_bindings
{
    // ── Scanner state (Cheat-Engine style typed value scan) ─────────────────
    static std::vector<uintptr_t> g_scan_addr;   // matching addresses
    static std::vector<uint64_t>  g_scan_prev;   // last-seen raw bits (up to 8 bytes)
    static int  g_scan_size = 4;                  // bytes per element (1/2/4/8)
    static char g_scan_kind = 'u';                // 'u' uint, 's' int, 'f' float, 'd' double

    // ── Hardware watchpoint state ───────────────────────────────────────────
    // FIXED SLOTS (not a map) so the fatal-crash handler can walk them
    // async-signal-safely for the last-gasp drain (see memtrace.h). `fd` is
    // the publish flag: it is set LAST on arm and cleared FIRST on stop.
    // Stopped slots deliberately LEAK their ring mapping — munmap could race
    // the crash handler reading it, and a stopped watch is a rare debug event.
    struct MLWatchSlot
    {
        std::atomic<int> fd{-1};
        void *ring = nullptr;
        size_t ringsz = 0;
        uintptr_t addr = 0;
        int len = 0;
        char mode[8] = {};
        std::map<uint64_t, uint64_t> acc; // cumulative ip→count (normal ctx only)
    };
    static constexpr int kMaxWatchSlots = 8;
    static MLWatchSlot g_watch_slots[kMaxWatchSlots];
    static std::mutex g_watch_mutex;   // serializes Lua ops + live_drain
    static int g_memtrace_fd = -1;     // O_APPEND fd for memtrace_live.log

    static MLWatchSlot *watch_slot_by_fd(int fd)
    {
        for (int i = 0; i < kMaxWatchSlots; i++)
            if (g_watch_slots[i].fd.load(std::memory_order_acquire) == fd)
                return &g_watch_slots[i];
        return nullptr;
    }

    // Parse all pending PERF_RECORD_SAMPLE records out of a watch's ring and
    // hand each IP to `emit`. Plain memory reads + tail update — safe in both
    // normal and signal context (fn-pointer callback, no std::function).
    static void watch_parse_ring(MLWatchSlot &s, void (*emit)(void *, uint64_t), void *ctx)
    {
        char *mapbase = (char *)s.ring;
        if (!mapbase)
            return;
        auto *mp = (struct perf_event_mmap_page *)mapbase;
        uint64_t head = mp->data_head;
        __sync_synchronize();
        uint64_t tail = mp->data_tail;
        uint64_t doff = mp->data_offset ? mp->data_offset : 4096;
        uint64_t dsize = mp->data_size ? mp->data_size : (s.ringsz - 4096);
        char *data = mapbase + doff;
        int guard = 0;
        while (tail < head && guard++ < 100000)
        {
            uint32_t type = 0;
            uint16_t rsize = 0;
            for (int k = 0; k < 4; k++) ((char *)&type)[k] = data[(tail + k) % dsize];
            for (int k = 0; k < 2; k++) ((char *)&rsize)[k] = data[(tail + 6 + k) % dsize];
            if (rsize == 0)
                break;
            if (type == PERF_RECORD_SAMPLE)
            {
                uint64_t ip = 0;
                for (int k = 0; k < 8; k++) ((char *)&ip)[k] = data[(tail + 8 + k) % dsize];
                emit(ctx, ip);
            }
            tail += rsize;
        }
        mp->data_tail = head; // consume
    }

    // ── /proc/self/mem fd (kernel-mediated R/W; works on PROT_NONE pages) ────
    static int ml_mem_fd()
    {
        static int fd = -1;
        if (fd < 0) fd = open("/proc/self/mem", O_RDWR);
        return fd;
    }

    // Map a type string → (size, kind). Returns false on unknown type.
    static bool ml_parse_type(const std::string &t, int &size, char &kind)
    {
        if (t == "i8")  { size = 1; kind = 's'; return true; }
        if (t == "u8")  { size = 1; kind = 'u'; return true; }
        if (t == "i16") { size = 2; kind = 's'; return true; }
        if (t == "u16") { size = 2; kind = 'u'; return true; }
        if (t == "i32") { size = 4; kind = 's'; return true; }
        if (t == "u32") { size = 4; kind = 'u'; return true; }
        if (t == "i64") { size = 8; kind = 's'; return true; }
        if (t == "u64") { size = 8; kind = 'u'; return true; }
        if (t == "f32" || t == "float")  { size = 4; kind = 'f'; return true; }
        if (t == "f64" || t == "double") { size = 8; kind = 'd'; return true; }
        return false;
    }

    // Interpret raw little-endian bits as a double (all numeric kinds fit for
    // gameplay values; ints above 2^53 lose precision — use pointer scans for those).
    static double ml_interp(uint64_t bits, int size, char kind)
    {
        switch (kind)
        {
        case 'f': { float f; std::memcpy(&f, &bits, 4); return (double)f; }
        case 'd': { double d; std::memcpy(&d, &bits, 8); return d; }
        case 's':
            if (size == 1) return (double)(int8_t)(uint8_t)bits;
            if (size == 2) return (double)(int16_t)(uint16_t)bits;
            if (size == 4) return (double)(int32_t)(uint32_t)bits;
            return (double)(int64_t)bits;
        default:
            if (size == 1) return (double)(uint8_t)bits;
            if (size == 2) return (double)(uint16_t)bits;
            if (size == 4) return (double)(uint32_t)bits;
            return (double)bits;
        }
    }

    // A rw region of the process address space.
    struct MLRegion { uintptr_t start, end; char perms[8]; std::string path; };
    static std::vector<MLRegion> ml_rw_regions(bool heap_only)
    {
        std::vector<MLRegion> out;
        std::ifstream maps("/proc/self/maps");
        if (!maps.is_open()) return out;
        std::string line;
        while (std::getline(maps, line))
        {
            MLRegion r{}; char path[512] = {0};
            int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %511[^\n]",
                           &r.start, &r.end, r.perms, path);
            if (n < 3) continue;
            if (r.perms[0] != 'r' || r.perms[1] != 'w') continue;
            r.path = (n >= 4) ? path : "";
            if (heap_only)
            {
                bool anon = r.path.empty();
                bool heapish = anon || r.path.rfind("[anon", 0) == 0 || r.path.rfind("[heap", 0) == 0;
                if (!heapish) continue;
            }
            size_t sz = (r.end > r.start) ? (r.end - r.start) : 0;
            if (sz == 0 || sz > (size_t)2 * 1024 * 1024 * 1024) continue;
            out.push_back(std::move(r));
        }
        return out;
    }

    // Snapshot of all readable modules for IP → module+offset symbolization.
    struct MLMod { uintptr_t start, end, base; std::string name; };
    static std::vector<MLMod> ml_module_map()
    {
        std::vector<MLMod> mods;
        std::map<std::string, uintptr_t> base; // lowest start per path
        std::ifstream maps("/proc/self/maps");
        std::string line;
        while (std::getline(maps, line))
        {
            uintptr_t s = 0, e = 0; char perms[8] = {0}; char path[512] = {0};
            int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %511[^\n]", &s, &e, perms, path);
            if (n < 3 || perms[0] != 'r') continue;
            std::string p = (n >= 4) ? path : "";
            if (p.empty() || p[0] == '[') continue; // only real files
            auto it = base.find(p);
            if (it == base.end() || s < it->second) base[p] = s;
            MLMod m{s, e, 0, p};
            mods.push_back(m);
        }
        for (auto &m : mods) m.base = base[m.name];
        return mods;
    }

    static std::string ml_basename(const std::string &p)
    {
        auto pos = p.find_last_of('/');
        return pos == std::string::npos ? p : p.substr(pos + 1);
    }

    // Symbolize an absolute address → "module+0xoffset" (offset == IDA RVA when imagebase 0).
    static void ml_sym(const std::vector<MLMod> &mods, uintptr_t ip,
                       std::string &mod, uintptr_t &off)
    {
        for (const auto &m : mods)
            if (ip >= m.start && ip < m.end) { mod = ml_basename(m.name); off = ip - m.base; return; }
        mod = "?"; off = ip;
    }

    void register_memtools(sol::state &lua)
    {
        // ═══ INSPECTOR ═══════════════════════════════════════════════════════

        // MemRegions(filter?) → { {start,end,perms,path}, ... } (all r-- regions; optional substr filter)
        lua.set_function("MemRegions", [](sol::this_state ts, sol::optional<std::string> filt) -> sol::object
        {
            sol::state_view lua(ts);
            sol::table res = lua.create_table();
            std::ifstream maps("/proc/self/maps");
            std::string line; int i = 0;
            while (std::getline(maps, line))
            {
                uintptr_t s = 0, e = 0; char perms[8] = {0}; char path[512] = {0};
                int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %511[^\n]", &s, &e, perms, path);
                if (n < 3) continue;
                std::string p = (n >= 4) ? path : "";
                if (filt && !filt->empty() && p.find(*filt) == std::string::npos) continue;
                sol::table row = lua.create_table();
                row["start"] = (int64_t)s; row["end"] = (int64_t)e;
                row["size"] = (int64_t)(e - s); row["perms"] = std::string(perms); row["path"] = p;
                res[++i] = row;
            }
            return res;
        });

        // SymAddr(addr) → {module, base, off, abs}  (off is the IDA RVA for imagebase-0 libs)
        lua.set_function("SymAddr", [](sol::this_state ts, int64_t addr) -> sol::object
        {
            sol::state_view lua(ts);
            auto mods = ml_module_map();
            std::string mod; uintptr_t off;
            ml_sym(mods, (uintptr_t)addr, mod, off);
            sol::table r = lua.create_table();
            r["module"] = mod; r["off"] = (int64_t)off; r["abs"] = addr;
            for (const auto &m : mods) if ((uintptr_t)addr >= m.start && (uintptr_t)addr < m.end) { r["base"] = (int64_t)m.base; break; }
            return r;
        });

        // Typed reads/writes via /proc/self/mem (safe on protected pages).
        auto memread = [](int64_t addr, int size) -> uint64_t {
            int fd = ml_mem_fd(); if (fd < 0) return 0;
            uint64_t v = 0;
            if (pread64(fd, &v, size, (off64_t)(uintptr_t)addr) != size) return 0;
            return v;
        };
        auto memwrite = [](int64_t addr, int size, uint64_t v) -> bool {
            int fd = ml_mem_fd(); if (fd < 0) return false;
            return pwrite64(fd, &v, size, (off64_t)(uintptr_t)addr) == size;
        };
        lua.set_function("MemReadU8",  [memread](int64_t a) -> int64_t { return (int64_t)(uint8_t)memread(a, 1); });
        lua.set_function("MemReadU16", [memread](int64_t a) -> int64_t { return (int64_t)(uint16_t)memread(a, 2); });
        lua.set_function("MemReadU32", [memread](int64_t a) -> int64_t { return (int64_t)(uint32_t)memread(a, 4); });
        lua.set_function("MemWriteU8",  [memwrite](int64_t a, int64_t v) -> bool { return memwrite(a, 1, (uint64_t)v); });
        lua.set_function("MemWriteU16", [memwrite](int64_t a, int64_t v) -> bool { return memwrite(a, 2, (uint64_t)v); });
        lua.set_function("MemWriteU32", [memwrite](int64_t a, int64_t v) -> bool { return memwrite(a, 4, (uint64_t)v); });

        // MemReadBytes(addr, len) → lowercase hex string ("" on failure). len capped at 4096.
        lua.set_function("MemReadBytes", [](int64_t addr, int len) -> std::string
        {
            if (len <= 0 || len > 4096) return "";
            std::vector<uint8_t> buf(len, 0);
            int fd = ml_mem_fd(); if (fd < 0) return "";
            if (pread64(fd, buf.data(), len, (off64_t)(uintptr_t)addr) != len) return "";
            static const char *hx = "0123456789abcdef";
            std::string out; out.reserve(len * 2);
            for (int i = 0; i < len; i++) { out += hx[buf[i] >> 4]; out += hx[buf[i] & 0xF]; }
            return out;
        });

        // ═══ SCANNER ═════════════════════════════════════════════════════════

        // MemScanFirst(type, cmp, value?) → count
        //   type: i8/u8/i16/u16/i32/u32/i64/u64/f32/f64
        //   cmp : "eq","ne","gt","lt","ge","le" (need value) | "unknown" (snapshot all)
        //   heap_only defaults true (anon/heap only) — pass 4th arg false to scan all rw.
        lua.set_function("MemScanFirst", [](const std::string &type, const std::string &cmp,
                                            sol::object val, sol::optional<bool> heap_only) -> int64_t
        {
            int size = 4; char kind = 'u';
            if (!ml_parse_type(type, size, kind)) return -1;
            g_scan_size = size; g_scan_kind = kind;
            g_scan_addr.clear(); g_scan_prev.clear();
            const bool haveVal = val.valid() && val.get_type() != sol::type::none && val.get_type() != sol::type::nil;
            const double tnum = haveVal ? val.as<double>() : 0.0;
            const bool ho = heap_only.value_or(true);
            const size_t CAP = 3000000;

            auto keep = [&](double cur) -> bool {
                if (cmp == "unknown") return true;
                if (cmp == "eq") return cur == tnum;
                if (cmp == "ne") return cur != tnum;
                if (cmp == "gt") return cur > tnum;
                if (cmp == "lt") return cur < tnum;
                if (cmp == "ge") return cur >= tnum;
                if (cmp == "le") return cur <= tnum;
                return cur == tnum;
            };

            auto regions = ml_rw_regions(ho);
            for (const auto &r : regions)
            {
                if (g_scan_addr.size() >= CAP) break;
                safe_call::execute([&]() {
                    for (uintptr_t a = r.start; a + size <= r.end && g_scan_addr.size() < CAP; a += size)
                    {
                        uint64_t bits = 0; std::memcpy(&bits, reinterpret_cast<const void *>(a), size);
                        double cur = ml_interp(bits, size, kind);
                        if (keep(cur)) { g_scan_addr.push_back(a); g_scan_prev.push_back(bits); }
                    }
                }, "MemScanFirst");
            }
            return (int64_t)g_scan_addr.size();
        });

        // MemScanNext(cmp, value?) → count. Refines the current result set.
        //   cmp: "eq","ne","gt","lt","ge","le" (vs value) |
        //        "changed","unchanged","increased","decreased" (vs previous snapshot)
        lua.set_function("MemScanNext", [](const std::string &cmp, sol::object val) -> int64_t
        {
            const int size = g_scan_size; const char kind = g_scan_kind;
            const bool haveVal = val.valid() && val.get_type() != sol::type::none && val.get_type() != sol::type::nil;
            const double tnum = haveVal ? val.as<double>() : 0.0;
            std::vector<uintptr_t> na; std::vector<uint64_t> np;
            na.reserve(g_scan_addr.size());
            safe_call::execute([&]() {
                for (size_t i = 0; i < g_scan_addr.size(); ++i)
                {
                    uint64_t bits = 0; std::memcpy(&bits, reinterpret_cast<const void *>(g_scan_addr[i]), size);
                    double cur = ml_interp(bits, size, kind);
                    double prev = ml_interp(g_scan_prev[i], size, kind);
                    bool k;
                    if (cmp == "changed")        k = (cur != prev);
                    else if (cmp == "unchanged") k = (cur == prev);
                    else if (cmp == "increased") k = (cur > prev);
                    else if (cmp == "decreased") k = (cur < prev);
                    else if (cmp == "eq") k = (cur == tnum);
                    else if (cmp == "ne") k = (cur != tnum);
                    else if (cmp == "gt") k = (cur > tnum);
                    else if (cmp == "lt") k = (cur < tnum);
                    else if (cmp == "ge") k = (cur >= tnum);
                    else if (cmp == "le") k = (cur <= tnum);
                    else k = (cur == tnum);
                    if (k) { na.push_back(g_scan_addr[i]); np.push_back(bits); }
                }
            }, "MemScanNext");
            g_scan_addr.swap(na); g_scan_prev.swap(np);
            return (int64_t)g_scan_addr.size();
        });

        lua.set_function("MemScanCount", []() -> int64_t { return (int64_t)g_scan_addr.size(); });
        lua.set_function("MemScanReset", []() { g_scan_addr.clear(); g_scan_prev.clear(); });

        // MemScanList(offset?, limit?) → { {addr, value}, ... }
        lua.set_function("MemScanList", [](sol::this_state ts, sol::optional<int> off, sol::optional<int> lim) -> sol::object
        {
            sol::state_view lua(ts);
            sol::table res = lua.create_table();
            int o = off.value_or(0), l = lim.value_or(100);
            int n = 0;
            for (size_t i = (size_t)o; i < g_scan_addr.size() && n < l; ++i)
            {
                uint64_t bits = 0;
                safe_call::execute([&]() { std::memcpy(&bits, reinterpret_cast<const void *>(g_scan_addr[i]), g_scan_size); }, "MemScanList");
                sol::table row = lua.create_table();
                row["addr"] = (int64_t)g_scan_addr[i];
                row["value"] = ml_interp(bits, g_scan_size, g_scan_kind);
                res[++n] = row;
            }
            return res;
        });

        // ═══ FIND WHAT ACCESSES / WRITES (hardware watchpoint) ═══════════════

        // WatchAccess(addr, len?, mode?) → fd (>=0) | negative errno
        //   len : 1/2/4/8 (default 8)   mode: "w" (write) | "r" (read) | "rw"/"a" (access)
        // Attaches to the CALLING thread (game thread when called from bridge exec_lua).
        lua.set_function("WatchAccess", [](int64_t addr, sol::optional<int> len, sol::optional<std::string> mode) -> int64_t
        {
            struct perf_event_attr a; std::memset(&a, 0, sizeof(a));
            a.type = PERF_TYPE_BREAKPOINT;
            a.size = sizeof(a);
            a.sample_period = 1;
            a.sample_type = PERF_SAMPLE_IP;
            a.disabled = 1;
            a.exclude_kernel = 1;
            a.exclude_hv = 1;
            a.precise_ip = 2;
            std::string m = mode.value_or("w");
            if (m == "r")            a.bp_type = HW_BREAKPOINT_R;
            else if (m == "rw" || m == "a") a.bp_type = HW_BREAKPOINT_R | HW_BREAKPOINT_W;
            else                     a.bp_type = HW_BREAKPOINT_W;
            a.bp_addr = (uint64_t)(uintptr_t)addr;
            int L = len.value_or(8);
            a.bp_len = (L == 1) ? HW_BREAKPOINT_LEN_1 : (L == 2) ? HW_BREAKPOINT_LEN_2 : (L == 4) ? HW_BREAKPOINT_LEN_4 : HW_BREAKPOINT_LEN_8;

            long fd = syscall(__NR_perf_event_open, &a, 0, -1, -1, 0UL);
            if (fd < 0)
            {
                // retry without precise_ip (arm64 breakpoints don't support skid control)
                a.precise_ip = 0;
                fd = syscall(__NR_perf_event_open, &a, 0, -1, -1, 0UL);
            }
            if (fd < 0) { logger::log_warn("MEMTOOLS", "WatchAccess perf_event_open failed errno=%d", errno); return -(int64_t)errno; }

            long pg = sysconf(_SC_PAGESIZE);
            size_t ringsz = (size_t)(1 + 8) * pg;   // 1 header + 8 data pages
            void *ring = mmap(nullptr, ringsz, PROT_READ | PROT_WRITE, MAP_SHARED, (int)fd, 0);
            if (ring == MAP_FAILED) { close((int)fd); logger::log_warn("MEMTOOLS", "WatchAccess mmap failed errno=%d", errno); return -9999; }

            std::lock_guard<std::mutex> lock(g_watch_mutex);
            MLWatchSlot *slot = nullptr;
            for (int i = 0; i < kMaxWatchSlots; i++)
                if (g_watch_slots[i].fd.load(std::memory_order_relaxed) < 0) { slot = &g_watch_slots[i]; break; }
            if (!slot)
            {
                munmap(ring, ringsz); close((int)fd);
                logger::log_warn("MEMTOOLS", "WatchAccess: all %d watch slots in use", kMaxWatchSlots);
                return -9998;
            }

            // Crash-surviving live log — open once, append forever.
            if (g_memtrace_fd < 0)
                g_memtrace_fd = open(memtrace::live_path().c_str(),
                                     O_WRONLY | O_CREAT | O_APPEND | O_CLOEXEC, 0644);

            slot->ring = ring;
            slot->ringsz = ringsz;
            slot->addr = (uintptr_t)addr;
            slot->len = L;
            snprintf(slot->mode, sizeof(slot->mode), "%s", m.c_str());
            slot->acc.clear();
            ioctl((int)fd, PERF_EVENT_IOC_RESET, 0);
            ioctl((int)fd, PERF_EVENT_IOC_ENABLE, 0);
            slot->fd.store((int)fd, std::memory_order_release);   // publish LAST

            if (g_memtrace_fd >= 0)
            {
                char hdr[160];
                int n = snprintf(hdr, sizeof(hdr),
                                 "=== watch armed fd=%d addr=0x%lx len=%d mode=%s ===\n",
                                 (int)fd, (unsigned long)addr, L, m.c_str());
                if (n > 0) { ssize_t w = write(g_memtrace_fd, hdr, (size_t)n); (void)w; }
            }
            logger::log_info("MEMTOOLS", "WatchAccess fd=%d addr=0x%lx len=%d mode=%s armed (live log: %s)",
                             (int)fd, (unsigned long)addr, L, m.c_str(), memtrace::live_path().c_str());
            return (int64_t)fd;
        });

        // WatchRead(fd) → { hits, samples={ {abs,module,off,count}, ... } }
        // CUMULATIVE: merges the ring's pending samples into the slot's
        // accumulator (which the periodic live_drain also feeds), so hits the
        // watchdog already drained to memtrace_live.log still show up here.
        lua.set_function("WatchRead", [](sol::this_state ts, int fd) -> sol::object
        {
            sol::state_view lua(ts);
            sol::table res = lua.create_table();
            std::lock_guard<std::mutex> lock(g_watch_mutex);
            MLWatchSlot *slot = watch_slot_by_fd(fd);
            if (!slot) { res["error"] = "no such watch"; return res; }

            watch_parse_ring(*slot, [](void *ctx, uint64_t ip) {
                (*static_cast<std::map<uint64_t, uint64_t> *>(ctx))[ip]++;
            }, &slot->acc);

            uint64_t total = 0;
            for (auto &pr : slot->acc) total += pr.second;

            auto mods = ml_module_map();
            std::vector<std::pair<uint64_t, uint64_t>> v(slot->acc.begin(), slot->acc.end());
            std::sort(v.begin(), v.end(), [](auto &x, auto &y) { return x.second > y.second; });
            sol::table samples = lua.create_table();
            int i = 0;
            for (auto &pr : v)
            {
                std::string mod; uintptr_t off;
                ml_sym(mods, (uintptr_t)pr.first, mod, off);
                sol::table row = lua.create_table();
                row["abs"] = (int64_t)pr.first; row["module"] = mod; row["off"] = (int64_t)off; row["count"] = (int64_t)pr.second;
                samples[++i] = row;
            }
            res["hits"] = (int64_t)total;
            res["distinct"] = (int64_t)v.size();
            res["samples"] = samples;
            return res;
        });

        // WatchStop(fd) → bool
        lua.set_function("WatchStop", [](int fd) -> bool
        {
            std::lock_guard<std::mutex> lock(g_watch_mutex);
            MLWatchSlot *slot = watch_slot_by_fd(fd);
            if (!slot) return false;
            slot->fd.store(-1, std::memory_order_release); // unpublish FIRST
            ioctl(fd, PERF_EVENT_IOC_DISABLE, 0);
            close(fd);
            // NOTE: ring mapping deliberately NOT munmap'd — the crash
            // handler's last-gasp drain may race a stop; a leaked 36KB ring
            // per stopped watch is cheaper than a fault in the fatal path.
            slot->ring = nullptr;
            slot->acc.clear();
            logger::log_info("MEMTOOLS", "WatchStop fd=%d", fd);
            return true;
        });

        // WatchList() → { {fd,addr,len,mode}, ... }
        lua.set_function("WatchList", [](sol::this_state ts) -> sol::object
        {
            sol::state_view lua(ts);
            sol::table res = lua.create_table();
            std::lock_guard<std::mutex> lock(g_watch_mutex);
            int i = 0;
            for (int k = 0; k < kMaxWatchSlots; k++)
            {
                int fd = g_watch_slots[k].fd.load(std::memory_order_relaxed);
                if (fd < 0) continue;
                sol::table row = lua.create_table();
                row["fd"] = (int64_t)fd; row["addr"] = (int64_t)g_watch_slots[k].addr;
                row["len"] = (int64_t)g_watch_slots[k].len; row["mode"] = g_watch_slots[k].mode;
                res[++i] = row;
            }
            return res;
        });

        // MemTraceLivePath() → path of the crash-surviving watch trace log
        lua.set_function("MemTraceLivePath", []() -> std::string
        { return memtrace::live_path(); });

        // ═══ AOB / PATTERN (future-proof address resolution) ═════════════════
        // A signature scanner that survives game updates: author a sig once
        // (AOBUnique / IDA make_signature), embed it in a mod, and AOBScan it at
        // load — no hardcoded RVAs to rot on the next build.

        // parse "48 8B ?? E8 ? ? ?" → bytes[] + mask[] (mask 1=fixed, 0=wildcard)
        auto parse_aob = [](const std::string &pat, std::vector<uint8_t> &bytes, std::vector<uint8_t> &mask) -> bool {
            bytes.clear(); mask.clear();
            auto hexv = [](char c) -> int {
                if (c >= '0' && c <= '9') return c - '0';
                if (c >= 'a' && c <= 'f') return c - 'a' + 10;
                if (c >= 'A' && c <= 'F') return c - 'A' + 10;
                return -1;
            };
            size_t i = 0, n = pat.size();
            while (i < n)
            {
                while (i < n && std::isspace((unsigned char)pat[i])) i++;
                if (i >= n) break;
                if (pat[i] == '?') { bytes.push_back(0); mask.push_back(0); i++; if (i < n && pat[i] == '?') i++; continue; }
                int hi = hexv(pat[i]);
                if (hi < 0) { i++; continue; }
                size_t j = i + 1; int val = hi;
                if (j < n && hexv(pat[j]) >= 0) { val = (hi << 4) | hexv(pat[j]); j++; }
                bytes.push_back((uint8_t)val); mask.push_back(1); i = j;
            }
            return !bytes.empty();
        };

        // AOBScan(pattern, module?, limit?) → { {abs, module, off}, ... }
        //   module: substring filter of the mapping path (default: any named .so).
        //   Fast: anchors on the first fixed byte, scans r-x regions only.
        lua.set_function("AOBScan", [parse_aob](sol::this_state ts, const std::string &pattern,
                                                sol::optional<std::string> module, sol::optional<int> limit) -> sol::object
        {
            sol::state_view lua(ts);
            sol::table res = lua.create_table();
            std::vector<uint8_t> pb, pm;
            if (!parse_aob(pattern, pb, pm)) return res;
            int anchor = -1; for (size_t k = 0; k < pm.size(); k++) if (pm[k]) { anchor = (int)k; break; }
            if (anchor < 0) return res; // all-wildcard is nonsense
            const std::string modf = module.value_or("");
            const int cap = limit.value_or(1000);
            const size_t plen = pb.size();
            const uint8_t a0 = pb[anchor];
            auto mods = ml_module_map();
            int found = 0;
            std::ifstream maps("/proc/self/maps"); std::string line;
            while (std::getline(maps, line) && found < cap)
            {
                uintptr_t s = 0, e = 0; char pr[8] = {0}; char path[512] = {0};
                int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %511[^\n]", &s, &e, pr, path);
                if (n < 3 || pr[0] != 'r' || pr[2] != 'x') continue;
                std::string p = (n >= 4) ? path : "";
                if (!modf.empty()) { if (p.find(modf) == std::string::npos) continue; }
                else if (p.find(".so") == std::string::npos) continue;
                if (e <= s || (e - s) < plen) continue;
                safe_call::execute([&]() {
                    const uint8_t *b = reinterpret_cast<const uint8_t *>(s);
                    size_t len = e - s;
                    for (size_t off = 0; off + plen <= len && found < cap; off++)
                    {
                        if (b[off + anchor] != a0) continue;
                        bool ok = true;
                        for (size_t k = 0; k < plen; k++) if (pm[k] && b[off + k] != pb[k]) { ok = false; break; }
                        if (!ok) continue;
                        uintptr_t abs = s + off;
                        std::string mod; uintptr_t rva; ml_sym(mods, abs, mod, rva);
                        sol::table row = lua.create_table();
                        row["abs"] = (int64_t)abs; row["module"] = mod; row["off"] = (int64_t)rva;
                        res[++found] = row;
                    }
                }, "AOBScan");
            }
            return res;
        });

        // AOBMake(addr, len?) → "48 8B .." raw byte signature (uppercase, space-sep)
        lua.set_function("AOBMake", [](int64_t addr, sol::optional<int> len) -> std::string
        {
            int L = len.value_or(16); if (L <= 0 || L > 256) L = 16;
            std::vector<uint8_t> buf(L, 0);
            int fd = ml_mem_fd(); if (fd < 0) return "";
            if (pread64(fd, buf.data(), L, (off64_t)(uintptr_t)addr) != L) return "";
            static const char *hx = "0123456789ABCDEF";
            std::string out; out.reserve(L * 3);
            for (int i = 0; i < L; i++) { if (i) out += ' '; out += hx[buf[i] >> 4]; out += hx[buf[i] & 0xF]; }
            return out;
        });

        // AOBUnique(addr, maxlen?, module?) → {pattern, len, module, off} that matches
        //   the address UNIQUELY within its module — ready to paste into a mod.
        //   (Raw bytes; for cross-build resilience also wildcard volatile immediates
        //    via IDA make_signature. This is the fast runtime grabber.)
        lua.set_function("AOBUnique", [parse_aob](sol::this_state ts, int64_t addr,
                                                  sol::optional<int> maxlen, sol::optional<std::string> module) -> sol::object
        {
            sol::state_view lua(ts);
            sol::table res = lua.create_table();
            int maxL = maxlen.value_or(48); if (maxL < 8) maxL = 8; if (maxL > 256) maxL = 256;
            std::vector<uint8_t> buf(maxL, 0);
            int fd = ml_mem_fd();
            if (fd < 0 || pread64(fd, buf.data(), maxL, (off64_t)(uintptr_t)addr) != maxL) { res["error"] = "read failed"; return res; }
            auto mods = ml_module_map();
            std::string mod; uintptr_t rva; ml_sym(mods, (uintptr_t)addr, mod, rva);
            std::string modf = module.value_or(mod);
            static const char *hx = "0123456789ABCDEF";
            // find the module's r-x span to count matches within it (self-contained)
            uintptr_t xs = 0, xe = 0;
            { std::ifstream maps("/proc/self/maps"); std::string line;
              while (std::getline(maps, line)) { uintptr_t s=0,e=0; char pr[8]={0}; char path[512]={0};
                int n=sscanf(line.c_str(),"%lx-%lx %7s %*s %*s %*s %511[^\n]",&s,&e,pr,path);
                if(n<3||pr[0]!='r'||pr[2]!='x') continue; std::string p=(n>=4)?path:"";
                if(!modf.empty() && p.find(modf)==std::string::npos) continue;
                if((uintptr_t)addr>=s && (uintptr_t)addr<e){ xs=s; xe=e; break; } } }
            for (int L = 8; L <= maxL; L++)
            {
                int cnt = 0;
                safe_call::execute([&]() {
                    const uint8_t *b = reinterpret_cast<const uint8_t *>(xs);
                    if (xs == 0 || xe <= xs) return;
                    size_t len = xe - xs;
                    for (size_t off = 0; off + (size_t)L <= len && cnt < 2; off++)
                        if (std::memcmp(b + off, buf.data(), L) == 0) cnt++;
                }, "AOBUnique");
                if (cnt == 1)
                {
                    std::string pat; pat.reserve(L * 3);
                    for (int i = 0; i < L; i++) { if (i) pat += ' '; pat += hx[buf[i] >> 4]; pat += hx[buf[i] & 0xF]; }
                    res["pattern"] = pat; res["len"] = L; res["module"] = mod; res["off"] = (int64_t)rva; res["unique"] = true;
                    return res;
                }
            }
            res["error"] = "not unique within maxlen"; res["module"] = mod; res["off"] = (int64_t)rva;
            return res;
        });

        // ModuleBase(name?) → base address (lowest mapping) of a module (default libUnreal.so)
        lua.set_function("ModuleBase", [](sol::optional<std::string> name) -> int64_t
        {
            std::string want = name.value_or("libUnreal.so");
            std::ifstream maps("/proc/self/maps"); std::string line; uintptr_t best = 0;
            while (std::getline(maps, line))
            {
                uintptr_t s = 0, e = 0; char pr[8] = {0}; char path[512] = {0};
                int n = sscanf(line.c_str(), "%lx-%lx %7s %*s %*s %*s %511[^\n]", &s, &e, pr, path);
                if (n < 4) continue; std::string p = path;
                if (p.find(want) != std::string::npos && (best == 0 || s < best)) best = s;
            }
            return (int64_t)best;
        });

        logger::log_info("MEMTOOLS", "memory toolkit registered (scan/inspect/watch/aob)");
    }

} // namespace lua_bindings

// ═══════════════════════════════════════════════════════════════════════════
// memtrace — crash-surviving live log for the hardware watchpoint (see
// modloader/memtrace.h for the contract). Lives here because it shares the
// watch-slot state above.
// ═══════════════════════════════════════════════════════════════════════════
namespace memtrace
{

    std::string live_path()
    {
        return paths::data_dir() + "/memtrace_live.log";
    }

    // Periodic drain (watchdog thread): ring → accumulator + compact log line.
    void live_drain()
    {
        using namespace lua_bindings;
        std::lock_guard<std::mutex> lock(g_watch_mutex);
        for (int i = 0; i < kMaxWatchSlots; i++)
        {
            MLWatchSlot &s = g_watch_slots[i];
            int fd = s.fd.load(std::memory_order_acquire);
            if (fd < 0 || !s.ring)
                continue;

            std::map<uint64_t, uint64_t> fresh;
            watch_parse_ring(s, [](void *ctx, uint64_t ip) {
                (*static_cast<std::map<uint64_t, uint64_t> *>(ctx))[ip]++;
            }, &fresh);
            if (fresh.empty())
                continue;

            uint64_t total = 0;
            for (auto &pr : fresh)
            {
                s.acc[pr.first] += pr.second;
                total += pr.second;
            }

            if (g_memtrace_fd < 0)
                continue;
            struct timespec ts;
            clock_gettime(CLOCK_REALTIME, &ts);
            char buf[768];
            int n = snprintf(buf, sizeof(buf), "[%lld.%03ld] fd=%d addr=0x%lx +%llu hits:",
                             (long long)ts.tv_sec, ts.tv_nsec / 1000000, fd,
                             (unsigned long)s.addr, (unsigned long long)total);
            int shown = 0;
            for (auto &pr : fresh)
            {
                if (n >= (int)sizeof(buf) - 40 || shown >= 12)
                {
                    n += snprintf(buf + n, sizeof(buf) - n, " ...");
                    break;
                }
                n += snprintf(buf + n, sizeof(buf) - n, " 0x%llx x%llu",
                              (unsigned long long)pr.first, (unsigned long long)pr.second);
                shown++;
            }
            if (n < (int)sizeof(buf) - 2)
            {
                buf[n++] = '\n';
                ssize_t w = write(g_memtrace_fd, buf, (size_t)n);
                (void)w;
            }
        }
    }

    // Last-gasp drain from the FATAL signal handler. Async-signal-safe:
    // no locks (the process is dying; a torn read is acceptable), no malloc —
    // fixed-size aggregation + raw write() to the pre-opened O_APPEND fd.
    void crash_drain(int sig)
    {
        using namespace lua_bindings;
        if (g_memtrace_fd < 0)
            return;

        bool any = false;
        for (int i = 0; i < kMaxWatchSlots; i++)
        {
            MLWatchSlot &s = g_watch_slots[i];
            int fd = s.fd.load(std::memory_order_acquire);
            if (fd < 0 || !s.ring)
                continue;

            struct Agg
            {
                uint64_t ip[64];
                uint64_t count[64];
                int n;
                uint64_t total;
            } agg;
            agg.n = 0;
            agg.total = 0;
            watch_parse_ring(s, [](void *ctx, uint64_t ip) {
                Agg *a = static_cast<Agg *>(ctx);
                a->total++;
                for (int k = 0; k < a->n; k++)
                    if (a->ip[k] == ip) { a->count[k]++; return; }
                if (a->n < 64) { a->ip[a->n] = ip; a->count[a->n] = 1; a->n++; }
            }, &agg);

            if (!any)
            {
                char hdr[96];
                int hn = snprintf(hdr, sizeof(hdr),
                                  "=== CRASH last-gasp drain (signal %d) ===\n", sig);
                if (hn > 0) { ssize_t w = write(g_memtrace_fd, hdr, (size_t)hn); (void)w; }
                any = true;
            }

            char buf[768];
            int n = snprintf(buf, sizeof(buf), "CRASH fd=%d addr=0x%lx pending=%llu:",
                             fd, (unsigned long)s.addr, (unsigned long long)agg.total);
            for (int k = 0; k < agg.n && n < (int)sizeof(buf) - 40; k++)
                n += snprintf(buf + n, sizeof(buf) - n, " 0x%llx x%llu",
                              (unsigned long long)agg.ip[k], (unsigned long long)agg.count[k]);
            if (n < (int)sizeof(buf) - 2)
            {
                buf[n++] = '\n';
                ssize_t w = write(g_memtrace_fd, buf, (size_t)n);
                (void)w;
            }
        }
    }

} // namespace memtrace
