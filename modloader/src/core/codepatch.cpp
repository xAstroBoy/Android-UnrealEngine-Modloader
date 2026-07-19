// modloader/src/core/codepatch.cpp
// See codepatch.h. Reversible code/data patching with correct ARM64 cache +
// permission handling. The Lua/.NET patch APIs are thin wrappers over this.

#include "modloader/codepatch.h"
#include "modloader/arm64_asm.h"
#include "modloader/logger.h"

#include <mutex>
#include <vector>
#include <cstring>
#include <unistd.h>
#include <sys/mman.h>

namespace codepatch
{

    // ── Reversal ledger ──────────────────────────────────────────────────────
    struct Patch
    {
        uintptr_t addr;
        std::vector<uint8_t> original; // bytes before OUR first write here
        bool is_code;
        std::string owner;
    };
    static std::vector<Patch> s_patches; // in apply order; restored in reverse
    static std::mutex s_mutex;

    // Record the original bytes at [addr,addr+n) the FIRST time we touch it, so a
    // later overlapping patch doesn't capture our own bytes as "original".
    static void record_original(uintptr_t addr, size_t n, bool is_code,
                                const std::string &owner)
    {
        if (owner.empty())
            return; // untracked write — reversal not requested
        for (const auto &p : s_patches)
            if (p.addr == addr && p.original.size() == n)
                return; // first write wins
        Patch p;
        p.addr = addr;
        p.original.assign(reinterpret_cast<const uint8_t *>(addr),
                          reinterpret_cast<const uint8_t *>(addr) + n);
        p.is_code = is_code;
        p.owner = owner;
        s_patches.push_back(std::move(p));
    }

    // ── Raw writers (permission + cache correct) ─────────────────────────────
    static bool raw_write_code(void *addr, const void *src, size_t n)
    {
        if (!addr || !n)
            return false;
        long ps = sysconf(_SC_PAGESIZE);
        if (ps <= 0)
            ps = 4096;
        uintptr_t a = reinterpret_cast<uintptr_t>(addr);
        uintptr_t first = a & ~(uintptr_t)(ps - 1);
        uintptr_t last = (a + n - 1) & ~(uintptr_t)(ps - 1);
        size_t len = (size_t)(last - first + ps);
        if (mprotect(reinterpret_cast<void *>(first), len,
                     PROT_READ | PROT_WRITE | PROT_EXEC) != 0)
        {
            logger::log_error("PATCH", "mprotect RWX failed at %p (n=%zu)", addr, n);
            return false;
        }
        std::memcpy(addr, src, n);
        __builtin___clear_cache(reinterpret_cast<char *>(a),
                                reinterpret_cast<char *>(a + n));
        mprotect(reinterpret_cast<void *>(first), len, PROT_READ | PROT_EXEC);
        return true;
    }

    static bool raw_write_data(void *addr, const void *src, size_t n)
    {
        if (!addr || !n)
            return false;
        long ps = sysconf(_SC_PAGESIZE);
        if (ps <= 0)
            ps = 4096;
        uintptr_t a = reinterpret_cast<uintptr_t>(addr);
        uintptr_t first = a & ~(uintptr_t)(ps - 1);
        uintptr_t last = (a + n - 1) & ~(uintptr_t)(ps - 1);
        if (mprotect(reinterpret_cast<void *>(first), (size_t)(last - first + ps),
                     PROT_READ | PROT_WRITE) != 0)
        {
            logger::log_error("PATCH", "mprotect RW failed at %p (n=%zu)", addr, n);
            return false;
        }
        std::memcpy(addr, src, n);
        return true;
    }

    // ── Public API ───────────────────────────────────────────────────────────
    bool write_code(void *addr, const void *src, size_t n, const std::string &owner)
    {
        std::lock_guard<std::mutex> lk(s_mutex);
        record_original(reinterpret_cast<uintptr_t>(addr), n, true, owner);
        bool ok = raw_write_code(addr, src, n);
        if (ok)
            logger::log_info("PATCH", "code patch @%p (%zu bytes)%s%s", addr, n,
                             owner.empty() ? "" : " owner=", owner.c_str());
        return ok;
    }

    bool write_data(void *addr, const void *src, size_t n, const std::string &owner)
    {
        std::lock_guard<std::mutex> lk(s_mutex);
        record_original(reinterpret_cast<uintptr_t>(addr), n, false, owner);
        bool ok = raw_write_data(addr, src, n);
        if (ok)
            logger::log_info("PATCH", "data patch @%p (%zu bytes)%s%s", addr, n,
                             owner.empty() ? "" : " owner=", owner.c_str());
        return ok;
    }

    bool assemble_at(void *addr, const std::string &asm_text, const std::string &owner,
                     std::string &err)
    {
        std::vector<uint8_t> bytes;
        if (!arm64::assemble_bytes(asm_text, reinterpret_cast<uintptr_t>(addr), bytes, err))
            return false;
        if (bytes.empty())
        {
            err = "assembled to 0 bytes";
            return false;
        }
        return write_code(addr, bytes.data(), bytes.size(), owner);
    }

    bool nop_code(void *addr, int count, const std::string &owner)
    {
        if (count <= 0 || count > 4096)
            return false;
        std::vector<uint32_t> words(count, arm64::nop());
        return write_code(addr, words.data(), words.size() * 4, owner);
    }

    static int hexval(char c)
    {
        if (c >= '0' && c <= '9') return c - '0';
        if (c >= 'a' && c <= 'f') return c - 'a' + 10;
        if (c >= 'A' && c <= 'F') return c - 'A' + 10;
        return -1;
    }

    bool write_code_hex(void *addr, const std::string &hex, const std::string &owner)
    {
        std::vector<uint8_t> bytes;
        bytes.reserve(hex.size() / 2);
        for (size_t i = 0; i + 1 < hex.size(); i += 2)
        {
            int hi = hexval(hex[i]), lo = hexval(hex[i + 1]);
            if (hi < 0 || lo < 0)
                return false;
            bytes.push_back(static_cast<uint8_t>((hi << 4) | lo));
        }
        if (bytes.empty())
            return false;
        return write_code(addr, bytes.data(), bytes.size(), owner);
    }

    int restore(const std::string &owner)
    {
        std::lock_guard<std::mutex> lk(s_mutex);
        int reverted = 0;
        for (auto it = s_patches.rbegin(); it != s_patches.rend();)
        {
            if (it->owner == owner)
            {
                void *a = reinterpret_cast<void *>(it->addr);
                bool ok = it->is_code
                              ? raw_write_code(a, it->original.data(), it->original.size())
                              : raw_write_data(a, it->original.data(), it->original.size());
                if (ok)
                    reverted++;
                // erase via base iterator
                auto base = std::next(it).base();
                base = s_patches.erase(base);
                it = std::reverse_iterator<decltype(base)>(base);
            }
            else
            {
                ++it;
            }
        }
        if (reverted)
            logger::log_info("PATCH", "restored %d patch(es) for owner '%s'",
                             reverted, owner.c_str());
        return reverted;
    }

    bool restore_addr(void *addr)
    {
        std::lock_guard<std::mutex> lk(s_mutex);
        uintptr_t a = reinterpret_cast<uintptr_t>(addr);
        for (auto it = s_patches.begin(); it != s_patches.end(); ++it)
        {
            if (it->addr == a)
            {
                bool ok = it->is_code
                              ? raw_write_code(addr, it->original.data(), it->original.size())
                              : raw_write_data(addr, it->original.data(), it->original.size());
                s_patches.erase(it);
                return ok;
            }
        }
        return false;
    }

    size_t patch_count()
    {
        std::lock_guard<std::mutex> lk(s_mutex);
        return s_patches.size();
    }

} // namespace codepatch
