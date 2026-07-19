#pragma once
// modloader/include/modloader/codepatch.h
// Generic, reversible code/data patching primitives.
//
// This is the shared engine under both the Lua patch API and the .NET one, so a
// MOD can do its own static byte patches / ARM64 instruction replacement without
// the modloader shipping a dedicated C++ patcher per bug. It handles the two
// things a naive /proc/self/mem write gets wrong on ARM64 code:
//   1. permissions — a code page is RX; writing needs RWX then restore to RX
//      (NOT RW: dropping PROT_EXEC off a live code page kills the next call);
//   2. the i-cache — after the data write lands the CPU can keep executing the
//      stale instruction out of the instruction cache until an explicit flush.
//
// Reversal: write_code/write_data can be given an owner tag; the ORIGINAL bytes
// are captured (first write wins per address) so restore(owner) puts them back,
// and mod_tracker restores a mod's patches automatically on unload/quarantine.

#include <cstddef>
#include <cstdint>
#include <string>

namespace codepatch
{

    // Patch EXECUTABLE code: mprotect RWX → memcpy → __builtin___clear_cache →
    // restore RX. `owner` (e.g. a mod name, or "" for untracked) records the
    // original bytes for restore(). Returns false if mprotect fails.
    bool write_code(void *addr, const void *src, size_t n, const std::string &owner = "");

    // Patch read-only DATA (.rodata / .data.rel.ro / jump tables): mprotect RW →
    // memcpy. No i-cache flush (not code). Same reversal semantics.
    bool write_data(void *addr, const void *src, size_t n, const std::string &owner = "");

    // Assemble one-line-per-instruction ARM64 text at `addr` and write it as
    // code (uses arm64::assemble with pc=addr so branches resolve). On parse
    // error returns false and sets `err`.
    bool assemble_at(void *addr, const std::string &asm_text, const std::string &owner,
                     std::string &err);

    // Overwrite `count` instructions (count*4 bytes) at addr with NOPs.
    bool nop_code(void *addr, int count, const std::string &owner = "");

    // Convenience: parse a lowercase-hex string ("d503201f...") and write_code.
    bool write_code_hex(void *addr, const std::string &hex, const std::string &owner = "");

    // Restore every patch recorded under `owner`, newest first, and clear them.
    // Returns the number of patches reverted.
    int restore(const std::string &owner);

    // Restore ONE address if it was patched (any owner). Returns true if reverted.
    bool restore_addr(void *addr);

    // Number of live (un-reverted) patches recorded, total.
    size_t patch_count();

} // namespace codepatch
