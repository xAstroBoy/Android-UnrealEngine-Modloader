#pragma once
// modloader/include/modloader/arm64_asm.h
// Minimal ARM64 (AArch64) instruction encoder + one-line assembler.
//
// Purpose: give MODS (Lua and .NET) the power to do static code patches
// themselves — NOP-out a call, branch over a bad path, force a return, load an
// immediate into a register, redirect a branch — instead of that logic being
// hardcoded into the modloader as a dedicated C++ patcher per bug. Combined
// with codepatch::write_code() (RWX + i-cache flush + reversible tracking),
// this is the whole "static bytepatch / ARM replacement from a mod" surface.
//
// Scope: the instruction families that STATIC PATCHES actually use — control
// flow (b/bl/br/blr/ret/cbz/cbnz), no-ops, and moves (movz/movk/movn/mov +
// a load-any-64-bit-immediate helper). Not a full assembler; unknown mnemonics
// return an error rather than mis-encoding. Everything is little-endian 32-bit
// words, matching AArch64.

#include <cstdint>
#include <string>
#include <vector>

namespace arm64
{

    // ── Single-instruction encoders (return the 32-bit word) ────────────────
    inline uint32_t nop() { return 0xD503201Fu; }
    inline uint32_t ret(int reg = 30) { return 0xD65F0000u | ((reg & 31) << 5); }
    inline uint32_t br(int reg) { return 0xD61F0000u | ((reg & 31) << 5); }
    inline uint32_t blr(int reg) { return 0xD63F0000u | ((reg & 31) << 5); }

    // PC-relative branches. from/to are ABSOLUTE addresses; range ±128MB (b/bl).
    // Returns false if the target is out of range or misaligned.
    bool b(uintptr_t from, uintptr_t to, uint32_t &out);
    bool bl(uintptr_t from, uintptr_t to, uint32_t &out);

    // Compare-and-branch (32/64-bit reg). from/to absolute; range ±1MB.
    bool cbz(uintptr_t from, uintptr_t to, int reg, bool is64, uint32_t &out);
    bool cbnz(uintptr_t from, uintptr_t to, int reg, bool is64, uint32_t &out);

    // MOVZ/MOVK/MOVN: rd, #imm16, LSL #(shift*16). shift ∈ {0,1,2,3}. 64-bit.
    uint32_t movz(int rd, uint16_t imm16, int shift);
    uint32_t movk(int rd, uint16_t imm16, int shift);
    uint32_t movn(int rd, uint16_t imm16, int shift);
    // MOV rd, rm  (alias of ORR rd, xzr, rm). 64-bit.
    uint32_t mov_reg(int rd, int rm);
    // MOV rd, #imm  — materialize ANY 64-bit immediate as a MOVZ/MOVK sequence
    // (1..4 words). Appends to `out`.
    void mov_imm64(int rd, uint64_t imm, std::vector<uint32_t> &out);

    // ── One-line-per-instruction assembler ──────────────────────────────────
    // Parses text like:
    //     nop
    //     ret
    //     mov x2, xzr
    //     movz x0, #0x1234
    //     movk x0, #0xabcd, lsl #16
    //     b   0x5e4a36c            ; absolute target
    //     bl  #0x5eef000
    //     br  x8
    //     cbz x0, 0x5e4a374
    //     .word 0xd503201f          ; raw literal
    //     mov x0, #0x7ff0000000     ; expands to a movz/movk chain
    // `pc` is the ABSOLUTE address the first word will live at (needed to encode
    // PC-relative branches); each subsequent instruction advances pc by 4.
    // Semicolon/`//`/`#`-at-line-start comments and blank lines are ignored.
    // On success returns true and fills `words`; on error returns false and sets
    // `err` to the offending line + reason.
    bool assemble(const std::string &text, uintptr_t pc,
                  std::vector<uint32_t> &words, std::string &err);

    // Convenience: assemble to a little-endian byte buffer.
    bool assemble_bytes(const std::string &text, uintptr_t pc,
                        std::vector<uint8_t> &bytes, std::string &err);

} // namespace arm64
