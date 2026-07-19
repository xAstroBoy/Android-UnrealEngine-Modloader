// modloader/src/core/arm64_asm.cpp
// See arm64_asm.h. A small, deliberately-limited AArch64 encoder for the
// instruction families static code patches use.

#include "modloader/arm64_asm.h"
#include <cctype>
#include <cstdlib>
#include <cstring>

namespace arm64
{

    // ── PC-relative branches ─────────────────────────────────────────────────
    static bool imm26_branch(uintptr_t from, uintptr_t to, uint32_t base, uint32_t &out)
    {
        if ((from & 3) || (to & 3))
            return false;
        int64_t off = static_cast<int64_t>(to) - static_cast<int64_t>(from);
        if (off < -(1LL << 27) || off >= (1LL << 27))
            return false; // ±128 MB
        uint32_t imm26 = static_cast<uint32_t>((off >> 2) & 0x03FFFFFF);
        out = base | imm26;
        return true;
    }

    bool b(uintptr_t from, uintptr_t to, uint32_t &out) { return imm26_branch(from, to, 0x14000000u, out); }
    bool bl(uintptr_t from, uintptr_t to, uint32_t &out) { return imm26_branch(from, to, 0x94000000u, out); }

    static bool imm19_cbranch(uintptr_t from, uintptr_t to, int reg, bool is64,
                              uint32_t op, uint32_t &out)
    {
        if ((from & 3) || (to & 3))
            return false;
        int64_t off = static_cast<int64_t>(to) - static_cast<int64_t>(from);
        if (off < -(1LL << 20) || off >= (1LL << 20))
            return false; // ±1 MB
        uint32_t imm19 = static_cast<uint32_t>((off >> 2) & 0x7FFFF);
        out = op | (is64 ? 0x80000000u : 0u) | (imm19 << 5) | (reg & 31);
        return true;
    }

    bool cbz(uintptr_t from, uintptr_t to, int reg, bool is64, uint32_t &out)
    {
        return imm19_cbranch(from, to, reg, is64, 0x34000000u, out);
    }
    bool cbnz(uintptr_t from, uintptr_t to, int reg, bool is64, uint32_t &out)
    {
        return imm19_cbranch(from, to, reg, is64, 0x35000000u, out);
    }

    // ── Moves ────────────────────────────────────────────────────────────────
    static uint32_t mov_wide(uint32_t opc, int rd, uint16_t imm16, int shift)
    {
        return (1u << 31) | (opc << 29) | (0x25u << 23) |
               ((shift & 3) << 21) | (static_cast<uint32_t>(imm16) << 5) | (rd & 31);
    }
    uint32_t movz(int rd, uint16_t imm16, int shift) { return mov_wide(0b10, rd, imm16, shift); }
    uint32_t movk(int rd, uint16_t imm16, int shift) { return mov_wide(0b11, rd, imm16, shift); }
    uint32_t movn(int rd, uint16_t imm16, int shift) { return mov_wide(0b00, rd, imm16, shift); }

    uint32_t mov_reg(int rd, int rm)
    {
        // ORR Xd, XZR, Xm
        return 0xAA0003E0u | ((rm & 31) << 16) | (rd & 31);
    }

    void mov_imm64(int rd, uint64_t imm, std::vector<uint32_t> &out)
    {
        // First non-zero 16-bit chunk via MOVZ, remaining non-zero via MOVK.
        // (For imm==0 emit a single MOVZ #0.)
        bool emitted = false;
        for (int s = 0; s < 4; s++)
        {
            uint16_t chunk = static_cast<uint16_t>((imm >> (s * 16)) & 0xFFFF);
            if (chunk == 0 && emitted)
                continue;
            if (chunk == 0 && !emitted)
                continue;
            if (!emitted)
            {
                out.push_back(movz(rd, chunk, s));
                emitted = true;
            }
            else
            {
                out.push_back(movk(rd, chunk, s));
            }
        }
        if (!emitted)
            out.push_back(movz(rd, 0, 0));
    }

    // ── Assembler ────────────────────────────────────────────────────────────
    static std::string lower(std::string s)
    {
        for (auto &c : s)
            c = static_cast<char>(std::tolower(static_cast<unsigned char>(c)));
        return s;
    }

    // Parse a register token like "x5" / "w12" / "xzr" / "wzr" / "sp".
    // Returns register number (31 for zr/sp) and sets is64. False if not a reg.
    static bool parse_reg(const std::string &tok, int &reg, bool &is64)
    {
        if (tok == "xzr" || tok == "sp") { reg = 31; is64 = true; return true; }
        if (tok == "wzr" || tok == "wsp") { reg = 31; is64 = false; return true; }
        if (tok.size() >= 2 && (tok[0] == 'x' || tok[0] == 'w'))
        {
            is64 = (tok[0] == 'x');
            char *end = nullptr;
            long n = std::strtol(tok.c_str() + 1, &end, 10);
            if (end && *end == 0 && n >= 0 && n <= 30) { reg = static_cast<int>(n); return true; }
        }
        return false;
    }

    // Parse an immediate: "#0x1234", "0x1234", "#42", "42". Leading '#' optional.
    static bool parse_imm(std::string tok, uint64_t &val)
    {
        if (!tok.empty() && tok[0] == '#')
            tok.erase(0, 1);
        if (tok.empty())
            return false;
        char *end = nullptr;
        errno = 0;
        uint64_t v = std::strtoull(tok.c_str(), &end, 0);
        if (end && *end == 0 && errno == 0) { val = v; return true; }
        return false;
    }

    // Split a line into lowercase tokens, stripping commas and comments.
    static std::vector<std::string> tokenize(const std::string &line_in)
    {
        std::string line = line_in;
        // strip comments: ';' or '//' anywhere; '#' only if it starts the line.
        for (size_t i = 0; i < line.size(); i++)
        {
            if (line[i] == ';' || (line[i] == '/' && i + 1 < line.size() && line[i + 1] == '/'))
            {
                line = line.substr(0, i);
                break;
            }
        }
        std::vector<std::string> toks;
        std::string cur;
        auto flush = [&]() { if (!cur.empty()) { toks.push_back(cur); cur.clear(); } };
        for (char c : line)
        {
            if (c == ',' || std::isspace(static_cast<unsigned char>(c)))
                flush();
            else
                cur += c;
        }
        flush();
        return toks;
    }

    bool assemble(const std::string &text, uintptr_t pc,
                  std::vector<uint32_t> &words, std::string &err)
    {
        size_t start = 0;
        while (start <= text.size())
        {
            size_t nl = text.find('\n', start);
            std::string raw = text.substr(start, nl == std::string::npos ? std::string::npos : nl - start);
            start = (nl == std::string::npos) ? text.size() + 1 : nl + 1;

            // Skip a whole-line '#' comment before tokenizing.
            size_t fnb = raw.find_first_not_of(" \t\r");
            if (fnb != std::string::npos && raw[fnb] == '#')
                continue;

            std::vector<std::string> t = tokenize(lower(raw));
            if (t.empty())
                continue;

            const std::string &op = t[0];
            uintptr_t here = pc + words.size() * 4;
            uint32_t w = 0;
            int rd, rm;
            bool d64, m64;
            uint64_t imm;

            auto fail = [&](const char *why) { err = raw + "  <- " + why; return false; };

            if (op == "nop") { words.push_back(nop()); continue; }
            if (op == "ret")
            {
                int reg = 30;
                if (t.size() >= 2) { bool x; if (!parse_reg(t[1], reg, x)) return fail("bad ret reg"); }
                words.push_back(ret(reg));
                continue;
            }
            if (op == "br" || op == "blr")
            {
                if (t.size() < 2 || !parse_reg(t[1], rd, d64)) return fail("bad reg");
                words.push_back(op == "br" ? br(rd) : blr(rd));
                continue;
            }
            if (op == ".word" || op == ".inst" || op == ".long")
            {
                if (t.size() < 2 || !parse_imm(t[1], imm)) return fail("bad .word");
                words.push_back(static_cast<uint32_t>(imm));
                continue;
            }
            if (op == "b" || op == "bl")
            {
                if (t.size() < 2 || !parse_imm(t[1], imm)) return fail("bad branch target");
                bool ok = (op == "b") ? b(here, imm, w) : bl(here, imm, w);
                if (!ok) return fail("branch target out of range / misaligned");
                words.push_back(w);
                continue;
            }
            if (op == "cbz" || op == "cbnz")
            {
                if (t.size() < 3 || !parse_reg(t[1], rd, d64) || !parse_imm(t[2], imm))
                    return fail("cbz needs reg,target");
                bool ok = (op == "cbz") ? cbz(here, imm, rd, d64, w) : cbnz(here, imm, rd, d64, w);
                if (!ok) return fail("cbz target out of range");
                words.push_back(w);
                continue;
            }
            if (op == "movz" || op == "movk" || op == "movn")
            {
                if (t.size() < 3 || !parse_reg(t[1], rd, d64) || !parse_imm(t[2], imm))
                    return fail("movz needs reg,#imm");
                int shift = 0;
                // optional: lsl #N
                for (size_t i = 3; i + 1 < t.size(); i++)
                {
                    if (t[i] == "lsl")
                    {
                        uint64_t s = 0;
                        if (!parse_imm(t[i + 1], s) || (s % 16) != 0 || s > 48)
                            return fail("bad lsl amount");
                        shift = static_cast<int>(s / 16);
                    }
                }
                if (imm > 0xFFFF) return fail("movz imm > 16 bits (use mov for wide)");
                uint16_t i16 = static_cast<uint16_t>(imm);
                words.push_back(op == "movz" ? movz(rd, i16, shift)
                                : op == "movk" ? movk(rd, i16, shift)
                                               : movn(rd, i16, shift));
                continue;
            }
            if (op == "mov")
            {
                if (t.size() < 3 || !parse_reg(t[1], rd, d64)) return fail("bad mov dest");
                // mov reg, reg  (incl. xzr) OR mov reg, #imm (any width)
                if (parse_reg(t[2], rm, m64))
                {
                    words.push_back(mov_reg(rd, rm));
                }
                else if (parse_imm(t[2], imm))
                {
                    mov_imm64(rd, imm, words); // 1..4 words
                }
                else
                    return fail("mov src not a reg or #imm");
                continue;
            }
            return fail("unknown mnemonic");
        }
        return true;
    }

    bool assemble_bytes(const std::string &text, uintptr_t pc,
                        std::vector<uint8_t> &bytes, std::string &err)
    {
        std::vector<uint32_t> words;
        if (!assemble(text, pc, words, err))
            return false;
        bytes.clear();
        bytes.reserve(words.size() * 4);
        for (uint32_t w : words)
        {
            bytes.push_back(static_cast<uint8_t>(w & 0xFF));
            bytes.push_back(static_cast<uint8_t>((w >> 8) & 0xFF));
            bytes.push_back(static_cast<uint8_t>((w >> 16) & 0xFF));
            bytes.push_back(static_cast<uint8_t>((w >> 24) & 0xFF));
        }
        return true;
    }

} // namespace arm64
