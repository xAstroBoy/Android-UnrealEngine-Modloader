// modloader/src/core/auto_offsets.cpp
// ═══════════════════════════════════════════════════════════════════════════
// DYNAMIC OFFSET FINDER — heuristic-based discovery of UE engine internals
//
// Strategy per discovery:
//   1. Find a known string in .rodata (e.g. "FNamePool", "GUObjectArray")
//   2. Find code that references that string (ADRP+ADD → the string address)
//   3. In that code, find nearby ADRP+ADD/LDR to a .bss/.data address
//   4. That .bss address is the global pointer we're looking for
//   5. Validate by reading the pointer and checking structure integrity
//
// All ARM64-specific: ADRP = page-relative, ADD = page-offset,
// LDR = load from computed address.
// ═══════════════════════════════════════════════════════════════════════════

#include "modloader/auto_offsets.h"
#include "modloader/pattern_scanner.h"
#include "modloader/safe_call.h"
#include "modloader/game_profile.h"
#include "modloader/logger.h"
#include "modloader/symbols.h"
#include "modloader/types.h"
#include <cstring>
#include <cstdarg>
#include <algorithm>
#include <array>
#include <functional>
#include <limits>
#include <unordered_map>
#include <vector>
#include <cstdio>
#include <dlfcn.h>

namespace auto_offsets
{
    static const char *version_to_string(engine_versions::EngineVersion v)
    {
        using namespace engine_versions;
        switch (v)
        {
        case EngineVersion::UE4_25:
            return "UE4.25";
        case EngineVersion::UE4_26:
            return "UE4.26";
        case EngineVersion::UE4_27:
            return "UE4.27";
        case EngineVersion::UE5_0:
            return "UE5.0";
        case EngineVersion::UE5_1:
            return "UE5.1";
        case EngineVersion::UE5_2:
            return "UE5.2";
        case EngineVersion::UE5_3:
            return "UE5.3";
        case EngineVersion::UE5_4:
            return "UE5.4";
        case EngineVersion::UE5_5:
            return "UE5.5";
        case EngineVersion::UE5_6:
            return "UE5.6";
        default:
            return "UNKNOWN";
        }
    }

    static bool s_initialized = false;

    // ═══ ARM64 INSTRUCTION DECODERS ═════════════════════════════════════════

    // Check if instruction is ADRP (Address of 4KB page at PC-relative offset)
    // Encoding: [1] [immlo:2] [10000] [immhi:19] [Rd:5]
    static bool is_adrp(uint32_t instr)
    {
        return (instr & 0x9F000000) == 0x90000000;
    }

    // Check if instruction is ADD immediate (64-bit)
    // Encoding: [1] [0] [0] [10001] [shift:2] [imm12:12] [Rn:5] [Rd:5]
    static bool is_add_imm64(uint32_t instr)
    {
        return (instr & 0xFF000000) == 0x91000000;
    }

    // Check if instruction is LDR (64-bit, unsigned offset)
    // Encoding: [11] [111] [00] [01] [01] [imm12:12] [Rn:5] [Rt:5]
    static bool is_ldr_imm64(uint32_t instr)
    {
        return (instr & 0xFFC00000) == 0xF9400000;
    }

    // Check if instruction is BL (branch with link)
    static bool is_bl(uint32_t instr)
    {
        return (instr & 0xFC000000) == 0x94000000;
    }

    // Check if instruction is STP X29, X30 (function prologue)
    static bool is_stp_fp_lr(uint32_t instr)
    {
        // STP X29, X30, [SP, #imm]! (pre-index)
        // Encoding: [10] [101] [0011] [0] [imm7:7] [11110] [11101]
        // But there are multiple forms. Check for X29 (Rd=29) and X30 (Rt2=30)
        return (instr & 0x7FC07FFF) == 0x29807BFD || // STP X29,X30,[SP,#-offset]!
               (instr & 0xFFE07FFF) == 0xA9807BFD;   // STP X29,X30,[SP,#offset]!
    }

    // Decode ADRP target page
    static uintptr_t decode_adrp_page(uint32_t instr, uintptr_t pc)
    {
        if (!is_adrp(instr))
            return 0;
        int32_t immhi = static_cast<int32_t>((instr >> 5) & 0x7FFFF);
        int32_t immlo = static_cast<int32_t>((instr >> 29) & 0x3);
        int32_t imm = (immhi << 2) | immlo;
        // Sign extend from 21 bits
        if (imm & (1 << 20))
            imm |= ~((1 << 21) - 1);
        return (pc & ~0xFFFULL) + (static_cast<int64_t>(imm) << 12);
    }

    // Decode ADD immediate value
    static uint32_t decode_add_imm(uint32_t instr)
    {
        if (!is_add_imm64(instr))
            return 0;
        uint32_t imm12 = (instr >> 10) & 0xFFF;
        uint32_t shift = (instr >> 22) & 0x3;
        if (shift == 1)
            imm12 <<= 12;
        return imm12;
    }

    // Decode LDR unsigned offset (64-bit)
    static uint32_t decode_ldr_offset(uint32_t instr)
    {
        if (!is_ldr_imm64(instr))
            return 0;
        uint32_t imm12 = (instr >> 10) & 0xFFF;
        return imm12 * 8; // scale by 8 for 64-bit LDR
    }

    // Get register from ADRP/ADD/LDR Rd field
    static int get_rd(uint32_t instr) { return instr & 0x1F; }
    // Get register from ADD/LDR Rn field
    static int get_rn(uint32_t instr) { return (instr >> 5) & 0x1F; }

    static constexpr uintptr_t PTR_TAG_MASK = 0x00FFFFFFFFFFFFFFULL; // strip MTE/top-byte tag

    static int count_valid_uobject_slots(uintptr_t chunk0, uint32_t stride, int count)
    {
        const uintptr_t text_s = pattern::text_start();
        const uintptr_t text_e = pattern::text_end();

        int valid = 0;
        for (int i = 0; i < count; i++)
        {
            uintptr_t item_addr = chunk0 + static_cast<uintptr_t>(i) * stride;
            if (!safe_call::probe_read(reinterpret_cast<void *>(item_addr), 8))
                break;

            uintptr_t obj_ptr = *reinterpret_cast<uintptr_t *>(item_addr) & PTR_TAG_MASK;
            if (obj_ptr == 0)
                continue; // null slots are expected

            if (!safe_call::probe_read(reinterpret_cast<void *>(obj_ptr), 0x28))
                continue;

            // STRONG discriminator: a UObject's first field is its C++ vtable pointer,
            // and the vtable's first entry must be executable code inside libUnreal's
            // .text. A struct that merely holds readable pointers (float configs, record
            // arrays) fails this — which is exactly what let false positives score before.
            uintptr_t vtable = *reinterpret_cast<uintptr_t *>(obj_ptr) & PTR_TAG_MASK;
            if (!safe_call::probe_read(reinterpret_cast<void *>(vtable), 8))
                continue;
            uintptr_t vfunc0 = *reinterpret_cast<uintptr_t *>(vtable) & PTR_TAG_MASK;
            if (text_s && text_e && (vfunc0 < text_s || vfunc0 >= text_e))
                continue;

            uintptr_t class_ptr = *reinterpret_cast<uintptr_t *>(obj_ptr + 0x10) & PTR_TAG_MASK;
            uintptr_t outer_ptr = *reinterpret_cast<uintptr_t *>(obj_ptr + 0x20) & PTR_TAG_MASK;
            if (!safe_call::probe_read(reinterpret_cast<void *>(class_ptr), 0x28))
                continue;

            // Outer may be null for packages/singletons, but if present it should also be readable.
            if (outer_ptr != 0 && !safe_call::probe_read(reinterpret_cast<void *>(outer_ptr), 0x28))
                continue;

            valid++;
        }
        return valid;
    }

    static int score_guobjectarray_candidate(uintptr_t guobjectarray)
    {
        if (guobjectarray == 0 ||
            !safe_call::probe_read(reinterpret_cast<void *>(guobjectarray), 0x40))
            return 0;

        int best_score = 0;

        // ── Decisive chunked-FUObjectArray shape check (UE4.20+/UE5) ────────────
        // FUObjectArray { int32 ObjFirstGCIndex; int32 ObjLastNonGCIndex;
        //   int32 MaxObjectsNotConsideredByGC; int32 OpenForDisregardForGC;
        //   FChunkedFixedUObjectArray ObjObjects @ +0x10 { FUObjectItem** Objects;
        //     FUObjectItem* PreAllocatedObjects; int32 MaxElements; int32 NumElements;
        //     int32 MaxChunks; int32 NumChunks } ... }.
        // A real array satisfies EXACT chunk arithmetic (NumElementsPerChunk = 64*1024)
        // that random globals never do — verified live on Puzzling Places (Max=196608,
        // Num=55327, MaxCh=3, NumCh=1). Matching this + a chunk that derefs to real
        // UObjects (vtable in .text) is conclusive, so we award a dominating score.
        {
            uintptr_t objects = *reinterpret_cast<uintptr_t *>(guobjectarray + 0x10) & PTR_TAG_MASK;
            uint32_t maxEl = *reinterpret_cast<uint32_t *>(guobjectarray + 0x20);
            uint32_t numEl = *reinterpret_cast<uint32_t *>(guobjectarray + 0x24);
            uint32_t maxCh = *reinterpret_cast<uint32_t *>(guobjectarray + 0x28);
            uint32_t numCh = *reinterpret_cast<uint32_t *>(guobjectarray + 0x2C);
            const uint32_t NPC = 64u * 1024u; // FChunkedFixedUObjectArray::NumElementsPerChunk
            if (objects && (maxEl >= NPC) && (maxEl % NPC == 0) && (maxCh == maxEl / NPC) &&
                (numEl > 0) && (numEl <= maxEl) &&
                (numCh == (numEl + NPC - 1) / NPC) && (numCh >= 1) && (numCh <= maxCh) &&
                safe_call::probe_read(reinterpret_cast<void *>(objects), 8))
            {
                uintptr_t chunk0 = *reinterpret_cast<uintptr_t *>(objects) & PTR_TAG_MASK;
                if (safe_call::probe_read(reinterpret_cast<void *>(chunk0), 0x80))
                {
                    int v = count_valid_uobject_slots(chunk0, 0x18, 64);
                    if (v >= 8)
                        best_score = std::max(best_score, 1000 + v);
                }
            }
        }

        std::array<uint32_t, 6> embedded_offsets = {
            ue::GUOBJECTARRAY_TO_OBJECTS, 0x0, 0x8, 0x10, 0x18, 0x20};

        for (uint32_t embedded_off : embedded_offsets)
        {
            uintptr_t embedded = guobjectarray + embedded_off;
            if (!safe_call::probe_read(reinterpret_cast<void *>(embedded), 0x18))
                continue;

            uintptr_t objects_ptr = *reinterpret_cast<uintptr_t *>(embedded);
            if (!safe_call::probe_read(reinterpret_cast<void *>(objects_ptr), 8))
                continue;

            uintptr_t chunk0 = *reinterpret_cast<uintptr_t *>(objects_ptr);
            if (!safe_call::probe_read(reinterpret_cast<void *>(chunk0), 0x80))
                continue;

            uint32_t num_elements = *reinterpret_cast<uint32_t *>(embedded + 8);
            uint32_t max_elements = *reinterpret_cast<uint32_t *>(embedded + 12);

            int valid_14 = count_valid_uobject_slots(chunk0, 0x14, 64);
            int valid_18 = count_valid_uobject_slots(chunk0, 0x18, 64);
            int score = std::max(valid_14, valid_18) * 10;

            if (num_elements > 0 && num_elements < 100000000)
                score += 15;
            if (max_elements >= num_elements && max_elements < 100000000)
                score += 10;

            best_score = std::max(best_score, score);
        }

        return best_score;
    }

    // ═══ Public ARM64 helpers ═══════════════════════════════════════════════

    uintptr_t decode_adrp_add(uintptr_t addr)
    {
        if (!safe_call::probe_read(reinterpret_cast<void *>(addr), 8))
            return 0;

        uint32_t instr0 = *reinterpret_cast<uint32_t *>(addr);
        uint32_t instr1 = *reinterpret_cast<uint32_t *>(addr + 4);

        if (!is_adrp(instr0) || !is_add_imm64(instr1))
            return 0;

        uintptr_t page = decode_adrp_page(instr0, addr);
        uint32_t offset = decode_add_imm(instr1);
        return page + offset;
    }

    uintptr_t decode_adrp_ldr(uintptr_t addr)
    {
        if (!safe_call::probe_read(reinterpret_cast<void *>(addr), 8))
            return 0;

        uint32_t instr0 = *reinterpret_cast<uint32_t *>(addr);
        uint32_t instr1 = *reinterpret_cast<uint32_t *>(addr + 4);

        if (!is_adrp(instr0) || !is_ldr_imm64(instr1))
            return 0;
        if (get_rd(instr0) != get_rn(instr1))
            return 0;

        uintptr_t page = decode_adrp_page(instr0, addr);
        uint32_t offset = decode_ldr_offset(instr1);
        return page + offset;
    }

    std::vector<uintptr_t> find_adrp_refs_to(uintptr_t target_addr)
    {
        std::vector<uintptr_t> results;
        uintptr_t target_page = target_addr & ~0xFFFULL;

        uintptr_t text_s = pattern::text_start();
        uintptr_t text_e = pattern::text_end();
        if (text_s == 0 || text_e == 0)
            return results;

        const uint32_t *code = reinterpret_cast<const uint32_t *>(text_s);
        size_t count = (text_e - text_s) / 4;

        for (size_t i = 0; i < count; i++)
        {
            uint32_t instr = code[i];
            if (!is_adrp(instr))
                continue;

            uintptr_t pc = text_s + i * 4;
            uintptr_t page = decode_adrp_page(instr, pc);
            if (page != target_page)
                continue;

            // Check the next few instructions for ADD/LDR that materializes the full address.
            // Compilers often schedule one or two instructions between ADRP and its consumer.
            for (size_t lookahead = 1; lookahead <= 4 && i + lookahead < count; lookahead++)
            {
                uint32_t next = code[i + lookahead];
                if (is_add_imm64(next) && get_rn(next) == get_rd(instr))
                {
                    uintptr_t full = page + decode_add_imm(next);
                    if (full == target_addr)
                    {
                        results.push_back(pc);
                        break;
                    }
                }
                else if (is_ldr_imm64(next) && get_rn(next) == get_rd(instr))
                {
                    uintptr_t full = page + decode_ldr_offset(next);
                    if (full == target_addr)
                    {
                        results.push_back(pc);
                        break;
                    }
                }
            }
        }
        return results;
    }

    uintptr_t find_function_start(uintptr_t addr, int max_search)
    {
        // Scan backwards looking for STP X29, X30 (frame pointer setup)
        // This is the most common ARM64 function prologue
        for (int offset = 0; offset < max_search; offset += 4)
        {
            uintptr_t check = addr - offset;
            if (!safe_call::probe_read(reinterpret_cast<void *>(check), 4))
                break;

            uint32_t instr = *reinterpret_cast<uint32_t *>(check);

            // Check for STP x29, x30, [sp, #-offset]!
            // Multiple encodings for pre-indexed and signed-offset STP
            if ((instr & 0xFFE07FFF) == 0xA9807BFD || // STP X29,X30,[SP,#-N]!
                (instr & 0x7FC07FFF) == 0x29807BFD)   // STP X29,X30,[SP,#-N]!
            {
                return check;
            }

            // Also check for SUB SP, SP, #imm (another common prologue)
            // But only if preceded by nothing (i.e. this is the very first instruction)
            if ((instr & 0xFF0003FF) == 0xD10003FF) // SUB SP, SP, #imm
            {
                // Verify this is a real prologue by checking if previous word looks like
                // a return instruction or end of previous function
                if (offset > 0)
                {
                    uint32_t prev = *reinterpret_cast<uint32_t *>(check - 4);
                    if (prev == 0xD65F03C0) // RET
                        return check;
                }
            }
        }
        return 0;
    }

    // ═══ INTERNAL HELPERS ═══════════════════════════════════════════════════

    struct GlobalCandidate
    {
        uintptr_t address = 0;
        uintptr_t ref_pc = 0;
        uintptr_t instr_pc = 0;
        int pattern_score = 0;
        int hits = 0;
        std::string source;
    };

    static bool is_data_address(uintptr_t addr)
    {
        uintptr_t data_s = pattern::data_start();
        uintptr_t data_e = pattern::data_end();
        return addr >= data_s && addr < data_e;
    }

    static void add_global_candidate(std::unordered_map<uintptr_t, GlobalCandidate> &candidates,
                                     uintptr_t candidate_addr,
                                     uintptr_t ref_pc,
                                     uintptr_t instr_pc,
                                     int base_score,
                                     const char *source)
    {
        if (candidate_addr == 0 || !is_data_address(candidate_addr))
            return;
        if (!safe_call::probe_read(reinterpret_cast<void *>(candidate_addr), 8))
            return;

        auto &cand = candidates[candidate_addr];
        cand.address = candidate_addr;
        cand.ref_pc = cand.ref_pc ? cand.ref_pc : ref_pc;
        cand.instr_pc = cand.instr_pc ? cand.instr_pc : instr_pc;
        cand.hits += 1;
        cand.pattern_score += base_score;
        if (cand.source.empty())
            cand.source = source;

        uint64_t qword0 = *reinterpret_cast<uint64_t *>(candidate_addr);
        if (qword0 != 0)
            cand.pattern_score += 3;
    }

    static std::vector<GlobalCandidate> collect_global_candidates_near_string(const char *needle,
                                                                              const char *name,
                                                                              std::vector<std::string> &log)
    {
        void *str_addr = pattern::find_string(needle);
        if (!str_addr)
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: string '%s' not found in binary", name, needle);
            log.push_back(msg);
            return {};
        }

        uintptr_t str_ptr = reinterpret_cast<uintptr_t>(str_addr);
        char msg[256];
        snprintf(msg, sizeof(msg), "%s: string '%s' found at 0x%lX", name, needle,
                 static_cast<unsigned long>(str_ptr));
        log.push_back(msg);

        // Find code that references this string
        auto refs = find_adrp_refs_to(str_ptr);
        if (refs.empty())
        {
            snprintf(msg, sizeof(msg), "%s: no ADRP xrefs to string", name);
            log.push_back(msg);
            return {};
        }

        snprintf(msg, sizeof(msg), "%s: found %zu code xrefs to string", name, refs.size());
        log.push_back(msg);

        std::unordered_map<uintptr_t, GlobalCandidate> candidate_map;

        for (uintptr_t ref : refs)
        {
            uintptr_t scan_start = (ref >= 80) ? ref - 80 : ref;
            uintptr_t scan_end = ref + 160;

            std::array<bool, 32> have_page{};
            std::array<uintptr_t, 32> page_by_reg{};
            std::array<bool, 32> have_full_addr{};
            std::array<uintptr_t, 32> full_addr_by_reg{};

            for (uintptr_t pc = scan_start; pc < scan_end; pc += 4)
            {
                if (!safe_call::probe_read(reinterpret_cast<void *>(pc), 4))
                    continue;

                uint32_t instr0 = *reinterpret_cast<uint32_t *>(pc);

                if (is_adrp(instr0))
                {
                    int rd = get_rd(instr0);
                    have_page[rd] = true;
                    page_by_reg[rd] = decode_adrp_page(instr0, pc);
                    have_full_addr[rd] = false;
                    continue;
                }

                if (is_add_imm64(instr0))
                {
                    int rn = get_rn(instr0);
                    int rd = get_rd(instr0);
                    uintptr_t full = 0;
                    if (have_page[rn])
                        full = page_by_reg[rn] + decode_add_imm(instr0);
                    else if (have_full_addr[rn])
                        full = full_addr_by_reg[rn] + decode_add_imm(instr0);

                    if (full != 0)
                    {
                        have_full_addr[rd] = true;
                        full_addr_by_reg[rd] = full;

                        if (full != str_ptr)
                            add_global_candidate(candidate_map, full, ref, pc, 12,
                                                 "ADRP+ADD(.data)");
                    }
                    continue;
                }

                if (is_ldr_imm64(instr0))
                {
                    int rn = get_rn(instr0);
                    uintptr_t target = 0;
                    if (have_page[rn])
                        target = page_by_reg[rn] + decode_ldr_offset(instr0);
                    else if (have_full_addr[rn])
                        target = full_addr_by_reg[rn] + decode_ldr_offset(instr0);

                    if (target != 0)
                        add_global_candidate(candidate_map, target, ref, pc, 20,
                                             have_page[rn] ? "ADRP+LDR(.data)" : "ADDR+LDR(.data)");
                }
            }
        }

        std::vector<GlobalCandidate> candidates;
        candidates.reserve(candidate_map.size());
        for (auto &entry : candidate_map)
            candidates.push_back(entry.second);

        std::sort(candidates.begin(), candidates.end(), [](const GlobalCandidate &a, const GlobalCandidate &b)
                  {
                      if (a.pattern_score != b.pattern_score)
                          return a.pattern_score > b.pattern_score;
                      if (a.hits != b.hits)
                          return a.hits > b.hits;
                      return a.address < b.address; });

        if (candidates.empty())
        {
            snprintf(msg, sizeof(msg), "%s: no .bss/.data references found near string xrefs", name);
            log.push_back(msg);
            return {};
        }

        snprintf(msg, sizeof(msg), "%s: collected %zu global candidate(s)", name, candidates.size());
        log.push_back(msg);
        return candidates;
    }

    static uintptr_t find_pfx_guobjectarray_via_chunk_access(std::vector<std::string> &log)
    {
        if (!game_profile::is_pinball_fx())
            return 0;

        // Verified against both old and new Pinball FX VR dumps:
        // this sequence computes FUObjectItem* from GUObjectArray's chunk pointer table.
        // The 8 bytes immediately before the match are ADRP+ADD that materialize the
        // GUObjectArray base, and the body uses +0x10 (chunk table) and +0x24 (count).
        static constexpr const char *kPattern =
            "88 0E 40 B9 2A 25 40 B9 5F 01 08 6B ?? ?? ?? 54 "
            "0A FD 4D D3 29 09 40 F9 4A 3D 7D 92 08 3D 00 12 "
            "29 69 6A F8 8A 02 80 52 17 25 AA 9B";

        auto matches = pattern::scan_all(kPattern);

        char msg[320];
        snprintf(msg, sizeof(msg), "GUObjectArray(PFXChunkAccess): %zu pattern match(es)", matches.size());
        log.push_back(msg);

        uintptr_t best_addr = 0;
        int best_score = std::numeric_limits<int>::min();

        for (size_t i = 0; i < matches.size(); i++)
        {
            uintptr_t seq_pc = reinterpret_cast<uintptr_t>(matches[i]);
            if (seq_pc < 8 || !safe_call::probe_read(reinterpret_cast<void *>(seq_pc - 8), 8))
                continue;

            uintptr_t candidate = decode_adrp_add(seq_pc - 8);
            // Don't filter by is_data_address — GUObjectArray resides in .bss
            // which may be in an anonymous mapping outside the tracked .data range.
            // safe_call::probe_read below already validates readability.
            if (candidate == 0)
                continue;

            int structural_score = 0;
            if (safe_call::probe_read(reinterpret_cast<void *>(candidate), 0x28))
                structural_score += 25;
            if (safe_call::probe_read(reinterpret_cast<void *>(candidate + 0x10), 8))
                structural_score += 15;
            if (safe_call::probe_read(reinterpret_cast<void *>(candidate + 0x24), 4))
                structural_score += 15;

            int live_score = score_guobjectarray_candidate(candidate);
            int total_score = structural_score + live_score;

            snprintf(msg, sizeof(msg),
                     "GUObjectArray(PFXChunkAccess): candidate #%zu 0x%lX (structural=%d live=%d total=%d)",
                     i + 1,
                     static_cast<unsigned long>(candidate),
                     structural_score,
                     live_score,
                     total_score);
            log.push_back(msg);

            if (total_score > best_score)
            {
                best_score = total_score;
                best_addr = candidate;
            }
        }

        return best_addr;
    }

    // Find a global pointer near a string reference.
    // Strategy: collect all plausible ADRP+ADD/LDR data references near string xrefs,
    // then rank/validate them instead of returning the first one.
    static uintptr_t find_global_near_string(const char *needle, const char *name,
                                             std::vector<std::string> &log,
                                             const std::function<int(uintptr_t)> &validator = {},
                                             bool require_validation = false)
    {
        auto candidates = collect_global_candidates_near_string(needle, name, log);
        if (candidates.empty())
            return 0;

        uintptr_t best_addr = 0;
        int best_score = std::numeric_limits<int>::min();
        int best_validation = 0;

        size_t to_log = std::min<size_t>(candidates.size(), 6);
        for (size_t i = 0; i < candidates.size(); i++)
        {
            int validation_score = validator ? validator(candidates[i].address) : 0;
            int total_score = candidates[i].pattern_score + validation_score;
            if (total_score > best_score && (!require_validation || validation_score > 0))
            {
                best_score = total_score;
                best_addr = candidates[i].address;
                best_validation = validation_score;
            }

            if (i < to_log)
            {
                char msg[320];
                snprintf(msg, sizeof(msg),
                         "%s: candidate #%zu 0x%lX via %s (pattern=%d hits=%d validation=%d total=%d)",
                         name, i + 1,
                         static_cast<unsigned long>(candidates[i].address),
                         candidates[i].source.c_str(),
                         candidates[i].pattern_score,
                         candidates[i].hits,
                         validation_score,
                         total_score);
                log.push_back(msg);
            }
        }

        if (best_addr != 0)
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: selected 0x%lX (validation=%d total=%d)",
                     name, static_cast<unsigned long>(best_addr), best_validation, best_score);
            log.push_back(msg);
            return best_addr;
        }

        char msg[256];
        snprintf(msg, sizeof(msg), "%s: candidates found but none passed validation", name);
        log.push_back(msg);
        return 0;
    }

    struct StringAnchor
    {
        const char *needle;
        const char *name;
    };

    static uintptr_t find_global_from_anchor_set(const std::vector<StringAnchor> &anchors,
                                                 const char *group_name,
                                                 std::vector<std::string> &log,
                                                 const std::function<int(uintptr_t)> &validator = {},
                                                 bool require_validation = false)
    {
        std::unordered_map<uintptr_t, GlobalCandidate> merged;

        for (const auto &anchor : anchors)
        {
            auto local = collect_global_candidates_near_string(anchor.needle, anchor.name, log);
            for (const auto &cand : local)
            {
                auto &dst = merged[cand.address];
                if (dst.address == 0)
                {
                    dst = cand;
                }
                else
                {
                    dst.pattern_score += cand.pattern_score;
                    dst.hits += cand.hits;
                    if (dst.source.find(anchor.name) == std::string::npos)
                    {
                        if (!dst.source.empty())
                            dst.source += ", ";
                        dst.source += anchor.name;
                    }
                }

                // Surviving multiple anchors is a strong signal that this is the real global.
                dst.pattern_score += 25;
            }
        }

        std::vector<GlobalCandidate> candidates;
        candidates.reserve(merged.size());
        for (auto &entry : merged)
            candidates.push_back(entry.second);

        if (candidates.empty())
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: no candidates collected across anchor set", group_name);
            log.push_back(msg);
            return 0;
        }

        std::sort(candidates.begin(), candidates.end(), [](const GlobalCandidate &a, const GlobalCandidate &b)
                  {
                      if (a.pattern_score != b.pattern_score)
                          return a.pattern_score > b.pattern_score;
                      if (a.hits != b.hits)
                          return a.hits > b.hits;
                      return a.address < b.address; });

        uintptr_t best_addr = 0;
        int best_validation = 0;
        int best_total = std::numeric_limits<int>::min();

        size_t to_log = std::min<size_t>(candidates.size(), 8);
        for (size_t i = 0; i < candidates.size(); i++)
        {
            int validation_score = validator ? validator(candidates[i].address) : 0;
            int total_score = candidates[i].pattern_score + validation_score;
            if (total_score > best_total && (!require_validation || validation_score > 0))
            {
                best_total = total_score;
                best_addr = candidates[i].address;
                best_validation = validation_score;
            }

            if (i < to_log)
            {
                char msg[384];
                snprintf(msg, sizeof(msg),
                         "%s: merged candidate #%zu 0x%lX (pattern=%d hits=%d validation=%d total=%d sources=%s)",
                         group_name, i + 1,
                         static_cast<unsigned long>(candidates[i].address),
                         candidates[i].pattern_score,
                         candidates[i].hits,
                         validation_score,
                         total_score,
                         candidates[i].source.c_str());
                log.push_back(msg);
            }
        }

        if (best_addr != 0)
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: selected merged winner 0x%lX (validation=%d total=%d)",
                     group_name, static_cast<unsigned long>(best_addr), best_validation, best_total);
            log.push_back(msg);
            return best_addr;
        }

        char msg[256];
        snprintf(msg, sizeof(msg), "%s: merged candidates found but none passed validation", group_name);
        log.push_back(msg);
        return 0;
    }

    // Find a function near a string reference.
    // Strategy: find code that references the string, then find the function start.
    static uintptr_t find_func_near_string(const char *needle, const char *name,
                                           std::vector<std::string> &log)
    {
        void *str_addr = pattern::find_string(needle);
        if (!str_addr)
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: string '%s' not found", name, needle);
            log.push_back(msg);
            return 0;
        }

        uintptr_t str_ptr = reinterpret_cast<uintptr_t>(str_addr);
        auto refs = find_adrp_refs_to(str_ptr);
        if (refs.empty())
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: no xrefs to '%s'", name, needle);
            log.push_back(msg);
            return 0;
        }

        // Find the function containing the first reference
        uintptr_t func_start = find_function_start(refs[0]);
        if (func_start != 0)
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: function at 0x%lX (from string '%s' xref at 0x%lX)",
                     name, static_cast<unsigned long>(func_start), needle,
                     static_cast<unsigned long>(refs[0]));
            log.push_back(msg);
        }
        return func_start;
    }

    // Find function near an EXACT null-terminated C-string match.
    // This avoids substring collisions such as "ProcessEvent" matching
    // "processEvents" / "ProcessEvents1..N".
    static uintptr_t find_func_near_exact_string(const char *needle, const char *name,
                                                 std::vector<std::string> &log)
    {
        if (!needle || !needle[0])
            return 0;

        auto all = pattern::find_string_all(needle);
        if (all.empty())
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: exact string '%s' not found", name, needle);
            log.push_back(msg);
            return 0;
        }

        size_t needle_len = strlen(needle);
        uintptr_t chosen = 0;
        for (void *addr : all)
        {
            uintptr_t p = reinterpret_cast<uintptr_t>(addr);
            if (!safe_call::probe_read(reinterpret_cast<void *>(p + needle_len), 1))
                continue;

            const uint8_t next = *reinterpret_cast<uint8_t *>(p + needle_len);
            if (next == 0)
            {
                chosen = p;
                break;
            }
        }

        if (chosen == 0)
        {
            char msg[320];
            snprintf(msg, sizeof(msg), "%s: only substring matches found for '%s' (no exact NUL-terminated token)",
                     name, needle);
            log.push_back(msg);
            return 0;
        }

        auto refs = find_adrp_refs_to(chosen);
        if (refs.empty())
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: no xrefs to exact '%s'", name, needle);
            log.push_back(msg);
            return 0;
        }

        uintptr_t func_start = find_function_start(refs[0]);
        if (func_start != 0)
        {
            char msg[256];
            snprintf(msg, sizeof(msg), "%s: function at 0x%lX (from exact string '%s' xref at 0x%lX)",
                     name, static_cast<unsigned long>(func_start), needle,
                     static_cast<unsigned long>(refs[0]));
            log.push_back(msg);
        }
        return func_start;
    }

    // ═══ INITIALIZATION ═════════════════════════════════════════════════════

    void init()
    {
        if (s_initialized)
            return;
        s_initialized = true;
        // safe_call must be initialized before we start probing memory
        safe_call::init();
        logger::log_info("AUTOOFF", "Dynamic offset finder initialized");
    }

    // ═══ ENGINE VERSION DETECTION ═══════════════════════════════════════════

    engine_versions::EngineVersion detect_engine_version(std::string *out_version_string)
    {
        using namespace engine_versions;

        // Search for UE version markers in .rodata
        // These strings are compiled into every UE build
        struct VersionMarker
        {
            const char *pattern;
            EngineVersion version;
        };

        static const VersionMarker markers[] = {
            {"+UE5+Release-5.6", EngineVersion::UE5_6},
            {"+UE5+Release-5.5", EngineVersion::UE5_5},
            {"+UE5+Release-5.4", EngineVersion::UE5_4},
            {"+UE5+Release-5.3", EngineVersion::UE5_3},
            {"+UE5+Release-5.2", EngineVersion::UE5_2},
            {"+UE5+Release-5.1", EngineVersion::UE5_1},
            {"+UE5+Release-5.0", EngineVersion::UE5_0},
            {"+UE4+Release-4.27", EngineVersion::UE4_27},
            {"+UE4+Release-4.26", EngineVersion::UE4_26},
            {"+UE4+Release-4.25", EngineVersion::UE4_25},
        };

        for (const auto &marker : markers)
        {
            void *found = pattern::find_string(marker.pattern);
            if (found)
            {
                logger::log_info("AUTOOFF", "Engine version detected: %s (at 0x%lX)",
                                 marker.pattern, reinterpret_cast<unsigned long>(found));
                if (out_version_string)
                    *out_version_string = marker.pattern;
                return marker.version;
            }
        }

        // Fallback: check for generic UE5 or UE4 markers
        if (pattern::find_string("+UE5+"))
        {
            logger::log_warn("AUTOOFF", "Generic UE5 marker found but exact version unknown");
            if (out_version_string)
                *out_version_string = "+UE5+unknown";
            return EngineVersion::UE5_0; // best guess
        }
        if (pattern::find_string("+UE4+"))
        {
            logger::log_warn("AUTOOFF", "Generic UE4 marker found but exact version unknown");
            if (out_version_string)
                *out_version_string = "+UE4+unknown";
            return EngineVersion::UE4_27; // best guess
        }

        // Meta Quest fork detection: look for source path strings like
        // "UE5_3_2_MetaFork" or "UE4_25_MetaFork" embedded in .rodata
        // These come from __FILE__ macros in compiled engine source.
        {
            struct MetaForkMarker
            {
                const char *pattern;
                EngineVersion version;
                const char *label;
            };
            static const MetaForkMarker mf_markers[] = {
                {"UE5_6", EngineVersion::UE5_6, "5.6"},
                {"UE5_5", EngineVersion::UE5_5, "5.5"},
                {"UE5_4", EngineVersion::UE5_4, "5.4"},
                {"UE5_3", EngineVersion::UE5_3, "5.3"},
                {"UE5_2", EngineVersion::UE5_2, "5.2"},
                {"UE5_1", EngineVersion::UE5_1, "5.1"},
                {"UE5_0", EngineVersion::UE5_0, "5.0"},
                {"UE4_27", EngineVersion::UE4_27, "4.27"},
                {"UE4_26", EngineVersion::UE4_26, "4.26"},
                {"UE4_25", EngineVersion::UE4_25, "4.25"},
            };
            for (const auto &mf : mf_markers)
            {
                void *found = pattern::find_string(mf.pattern);
                if (found)
                {
                    bool is_meta_fork = pattern::find_string("IsUnrealEngineMetaFork") != nullptr;
                    logger::log_info("AUTOOFF", "Engine version detected via source path: %s%s (at 0x%lX)",
                                     mf.label, is_meta_fork ? " (Meta fork)" : "",
                                     reinterpret_cast<unsigned long>(found));
                    if (out_version_string)
                    {
                        *out_version_string = mf.pattern;
                        if (is_meta_fork)
                            *out_version_string += "_MetaFork";
                    }
                    return mf.version;
                }
            }
        }

        // UE5 without +UE5+ marker: check for UE5-specific strings.
        // IMPORTANT: don't promote libUE4.so titles to UE5 from this weak heuristic.
        // Some UE4 builds contain these tokens in diagnostics/dead strings.
        if (game_profile::engine_lib_name() != "libUE4.so" &&
            (pattern::find_string("FNamePool") || pattern::find_string("PreAllocatedObjects")))
        {
            logger::log_warn("AUTOOFF", "UE5-specific strings found — assuming UE5");
            if (out_version_string)
                *out_version_string = "UE5-inferred";
            return EngineVersion::UE5_0;
        }

        if (game_profile::engine_lib_name() == "libUE4.so")
        {
            logger::log_warn("AUTOOFF", "No explicit version markers found in libUE4.so — defaulting to UE4.27");
            if (out_version_string)
                *out_version_string = "UE4-libUE4-default";
            return EngineVersion::UE4_27;
        }

        logger::log_error("AUTOOFF", "Could not detect engine version from binary strings");
        return EngineVersion::UNKNOWN;
    }

    // ═══ FIND GNAMES ════════════════════════════════════════════════════════

    // ROBUST, string/symbol-AGNOSTIC GNames discovery. GNames is the global FNamePool
    // (UE4.23+/UE5). Its FNameEntryAllocator has an unmistakable runtime shape:
    //   +0x00 FRWLock (== 0 at rest)
    //   +0x08 uint32 CurrentBlock       (index of the block being filled)
    //   +0x0C uint32 CurrentByteCursor  (< block size)
    //   +0x10 uint8* Blocks[FNameMaxBlocks=8192]
    // A live pool is a run of (CurrentBlock+1) PAGE-ALIGNED heap block pointers followed
    // by a long NULL tail (the mostly-empty 8192-slot array), and Blocks[0] begins with
    // the "None" FNameEntry (FNameEntry = uint16 header then chars; index 0 = NAME_None).
    // Verified live on Puzzling Places (CurrentBlock=28, 29 blocks, Blocks[0]="None"...).
    // Needs the .bss to be in [data_start,data_end) — see pattern_scanner .bss absorption.
    static uintptr_t find_gnames_structural(std::vector<std::string> &log)
    {
        uintptr_t ds = pattern::data_start();
        uintptr_t de = pattern::data_end();
        if (ds == 0 || de == 0 || de <= ds)
        {
            log.push_back("GNames(structural): no .data/.bss bounds");
            return 0;
        }

        auto page_heap = [](uintptr_t p) -> bool {
            p &= PTR_TAG_MASK; // name blocks are page-aligned heap allocations
            return p >= 0x1000000000ULL && p < 0x8000000000ULL && (p & 0xFFFULL) == 0;
        };

        uintptr_t best = 0;
        int best_blocks = 0;
        size_t scored = 0;

        for (uintptr_t page = ds & ~0xFFFULL; page < de; page += 0x1000)
        {
            if (!safe_call::probe_read(reinterpret_cast<void *>(page), 0x1000))
                continue;
            uintptr_t win_end = page + 0x1000;
            uintptr_t a = (page < ds) ? ((ds + 7) & ~7ULL) : page;
            for (; a < win_end && a + 0x120 <= de; a += 8)
            {
                uintptr_t b0 = *reinterpret_cast<uintptr_t *>(a + 0x10);
                if (!page_heap(b0))
                    continue; // cheap prefilter on Blocks[0]

                uint32_t cur_block = *reinterpret_cast<uint32_t *>(a + 0x08);
                uint32_t byte_cursor = *reinterpret_cast<uint32_t *>(a + 0x0C);
                if (cur_block < 1 || cur_block > 8192 || byte_cursor > 0x20000)
                    continue;
                // need Blocks[0..cur_block] + 32 tail slots inside our data window
                if (a + 0x10 + 8ULL * (cur_block + 33) > de)
                    continue;
                scored++;

                bool ok = true;
                for (uint32_t k = 0; k <= cur_block; k++)
                {
                    if (!page_heap(*reinterpret_cast<uintptr_t *>(a + 0x10 + 8ULL * k)))
                    {
                        ok = false;
                        break;
                    }
                }
                if (!ok)
                    continue;
                for (uint32_t k = cur_block + 1; k <= cur_block + 32; k++)
                {
                    if (*reinterpret_cast<uintptr_t *>(a + 0x10 + 8ULL * k) != 0)
                    {
                        ok = false;
                        break;
                    }
                }
                if (!ok)
                    continue;

                // Blocks[0] must start with the "None" FNameEntry (header + "None").
                uintptr_t blk0 = b0 & PTR_TAG_MASK;
                if (!safe_call::probe_read(reinterpret_cast<void *>(blk0), 8))
                    continue;
                const char *s = reinterpret_cast<const char *>(blk0 + 2);
                if (!(s[0] == 'N' && s[1] == 'o' && s[2] == 'n' && s[3] == 'e'))
                    continue;

                int blocks = static_cast<int>(cur_block) + 1;
                if (blocks > best_blocks)
                {
                    best_blocks = blocks;
                    best = a;
                }
            }
        }

        char msg[192];
        snprintf(msg, sizeof(msg),
                 "GNames(structural): swept 0x%lX-0x%lX, %zu probed, best 0x%lX blocks=%d",
                 (unsigned long)ds, (unsigned long)de, scored, (unsigned long)best, best_blocks);
        log.push_back(msg);
        return best;
    }

    uintptr_t find_gnames()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        // Strategy 1: UE5 — look for "FNamePool" string xrefs
        result = find_global_near_string("FNamePool", "GNames(FNamePool)", log);
        if (result)
            goto done;

        // Strategy 2: UE4 — look for "NameCount" or FName-related strings
        result = find_global_near_string("MaxObjectsNotConsideredByGC", "GNames(UE4-via-GC)", log);
        if (result)
            goto done;

        // Strategy 3: look for "NameNumber_" (used in FName comparison code)
        result = find_global_near_string("NameNumber_", "GNames(NameNumber)", log);
        if (result)
            goto done;

        // Strategy 4: look for "GNames" literal
        result = find_global_near_string("GNames", "GNames(literal)", log);
        if (result)
            goto done;

        // ROBUST FALLBACK — string/symbol-agnostic structural FNamePool sweep. Catches
        // stripped builds where every anchor string is gone (e.g. Puzzling Places' UE4
        // build). Requires the .bss to be scannable (pattern_scanner .bss absorption).
        result = find_gnames_structural(log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());

        if (result)
            logger::log_info("AUTOOFF", "GNames discovered at 0x%lX", static_cast<unsigned long>(result));
        else
            logger::log_warn("AUTOOFF", "GNames NOT found via auto-discovery");

        return result;
    }

    // ═══ FIND GUOBJECTARRAY ═════════════════════════════════════════════════

    // ROBUST, version/string/symbol-AGNOSTIC discovery: sweep the whole .data/.bss
    // segment and run the structural validator on every 8-byte-aligned slot. GUObjectArray
    // is a global FUObjectArray whose shape is unmistakable — a pointer to a chunk table
    // whose chunks hold FUObjectItems pointing to UObjects whose vtables live in libUnreal's
    // r-x — so we don't need any anchor string or exported symbol (which fail on stripped /
    // differently-built UE games like this one). The data segment is our OWN mapped memory,
    // so the sweep reads it directly (no per-address syscall); the validator's probe_reads
    // only touch the heap for plausible candidates. This is the "never fails" safety net.
    static uintptr_t find_guobjectarray_structural(std::vector<std::string> &log)
    {
        uintptr_t ds = pattern::data_start();
        uintptr_t de = pattern::data_end();
        if (ds == 0 || de == 0 || de <= ds)
        {
            log.push_back("GUObjectArray(structural): no .data/.bss bounds");
            return 0;
        }

        auto plausible = [](uintptr_t p) -> bool {
            p &= 0x00FFFFFFFFFFFFFFULL;                 // strip MTE/top-byte tag
            return p >= 0x1000000000ULL && p < 0x8000000000ULL && (p & 7) == 0;
        };

        uintptr_t best = 0;
        int best_score = 0;
        size_t scored = 0;

        // Walk page-by-page so a gap / guard page inside the merged rw range can't fault our
        // direct pre-filter reads. Probe a 2-page window so a candidate whose fields spill
        // past the page end is still fully readable; fall back to a single non-straddling
        // page if the next page is a gap; skip the page entirely if unmapped.
        for (uintptr_t p = ds & ~0xFFFULL; p < de; p += 0x1000)
        {
            uintptr_t win_end;
            if (safe_call::probe_read(reinterpret_cast<void *>(p), 0x2000))
                win_end = p + 0x1000;           // [a, a+0x40) may spill into p+1 (verified readable)
            else if (safe_call::probe_read(reinterpret_cast<void *>(p), 0x1000))
                win_end = (p + 0x1000 > 0x40) ? (p + 0x1000 - 0x40) : p;  // non-straddling only
            else
                continue;                        // gap / unmapped -> skip

            uintptr_t a = (p < ds) ? ((ds + 7) & ~7ULL) : p;
            for (; a < win_end && a + 0x40 <= de; a += 8)
            {
                // CHEAP, HIGHLY-SELECTIVE pre-gate: the chunked FUObjectArray shape
                // (ObjObjects @ +0x10: Objects, PreAlloc, int32 Max@0x20, Num@0x24,
                // MaxChunks@0x28, NumChunks@0x2C). Every read here is INSIDE the probed
                // page window (anon .bss reads as zero-fill — never faults), so this costs
                // no syscalls. Exact chunk arithmetic (NumElementsPerChunk = 64*1024) is
                // satisfied by essentially only the real array, so the expensive deref
                // scoring below runs a handful of times instead of on every .bss pointer.
                // (This gate is what keeps the full-.bss sweep from grinding through
                // millions of probe faults — see score_guobjectarray_candidate.)
                uint32_t maxEl = *reinterpret_cast<uint32_t *>(a + 0x20);
                uint32_t numEl = *reinterpret_cast<uint32_t *>(a + 0x24);
                uint32_t maxCh = *reinterpret_cast<uint32_t *>(a + 0x28);
                uint32_t numCh = *reinterpret_cast<uint32_t *>(a + 0x2C);
                const uint32_t NPC = 64u * 1024u;
                if (!(maxEl >= NPC && (maxEl % NPC) == 0 && maxCh == maxEl / NPC &&
                      numEl > 0 && numEl <= maxEl &&
                      numCh == (numEl + NPC - 1) / NPC && numCh >= 1 && numCh <= maxCh))
                    continue;
                uintptr_t objects = *reinterpret_cast<uintptr_t *>(a + 0x10);
                if (!plausible(objects))
                    continue;

                int s = score_guobjectarray_candidate(a);
                if (s > best_score)
                {
                    best_score = s;
                    best = a;
                }
                scored++;
            }
        }

        char msg[256];
        snprintf(msg, sizeof(msg),
                 "GUObjectArray(structural): swept .data/.bss 0x%lX-0x%lX, %zu scored, best 0x%lX score=%d",
                 (unsigned long)ds, (unsigned long)de, scored, (unsigned long)best, best_score);
        log.push_back(msg);

        // A real object array has many valid UObject slots (each +10) plus sane counts;
        // random globals never reach this. Require >= ~8 live UObjects.
        if (best && best_score >= 100)
            return best;
        return 0;
    }

    uintptr_t find_guobjectarray()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        // Pinball FX VR: prefer the chunk-access sequence first.
        // It survived the update even when string-xref strategies produced nothing.
        result = find_pfx_guobjectarray_via_chunk_access(log);
        if (result)
            goto done;

        // Resistant PFX/UE strategy: collect candidates from all known anchors,
        // then pick the address that repeatedly appears AND validates as a live object array.
        result = find_global_from_anchor_set({
                                                 {"MaxObjectsNotConsideredByGC", "GUObjectArray(MaxObj)"},
                                                 {"OpenForDisregardForGC", "GUObjectArray(OpenGC)"},
                                                 {"SizeOfPermanentObjectPool", "GUObjectArray(PermPool)"},
                                                 {"NumElementsPerChunk", "GUObjectArray(ChunkedArr)"},
                                                 {"GUObjectArray", "GUObjectArray(literal)"},
                                             },
                                             "GUObjectArray(merged)", log, score_guobjectarray_candidate, true);
        if (result)
            goto done;

        // Fallback to individual strategies if the merged pass somehow finds nothing.
        result = find_global_near_string("MaxObjectsNotConsideredByGC", "GUObjectArray(MaxObj)", log,
                                         score_guobjectarray_candidate, true);
        if (result)
            goto done;

        result = find_global_near_string("OpenForDisregardForGC", "GUObjectArray(OpenGC)", log,
                                         score_guobjectarray_candidate, true);
        if (result)
            goto done;

        result = find_global_near_string("SizeOfPermanentObjectPool", "GUObjectArray(PermPool)", log,
                                         score_guobjectarray_candidate, true);
        if (result)
            goto done;

        result = find_global_near_string("NumElementsPerChunk", "GUObjectArray(ChunkedArr)", log,
                                         score_guobjectarray_candidate, true);
        if (result)
            goto done;

        result = find_global_near_string("GUObjectArray", "GUObjectArray(literal)", log,
                                         score_guobjectarray_candidate, true);
        if (result)
            goto done;

        // ROBUST FALLBACK — string/symbol-agnostic structural sweep. Catches every UE
        // build where the anchor-string heuristics above find nothing (stripped strings,
        // literal-pool refs, different code layout) — e.g. Puzzling Places' UE4 build.
        result = find_guobjectarray_structural(log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());

        if (result)
            logger::log_info("AUTOOFF", "GUObjectArray discovered at 0x%lX", static_cast<unsigned long>(result));
        else
            logger::log_warn("AUTOOFF", "GUObjectArray NOT found via auto-discovery");

        return result;
    }

    // ═══ FIND PROCESSEVENT ══════════════════════════════════════════════════

    // ROBUST ProcessEvent finder for stripped builds (log/assert strings gone but
    // __FILE__ source-path strings retained — e.g. Puzzling Places). Two facts pin it:
    //   (a) UObject::ProcessEvent lives in ScriptCore.cpp, so its code sits in the .text
    //       neighbourhood of the functions that reference the "ScriptCore.cpp" __FILE__
    //       string (ProcessEvent itself doesn't log, but its siblings ProcessInternal /
    //       CallFunction / etc. do — bracketing it).
    //   (b) ProcessEvent is a UObject virtual → present in the UObject vtable.
    // Intersect: the UObject vtable entry whose address falls inside that .text range is
    // ProcessEvent. Needs GUObjectArray (resolved before this) for a live UObject vtable.
    static uintptr_t find_process_event_via_vtable(uintptr_t guobjectarray, std::vector<std::string> &log)
    {
        if (!guobjectarray)
        {
            log.push_back("ProcessEvent(vtable): no GUObjectArray");
            return 0;
        }
        uintptr_t ts = pattern::text_start(), te = pattern::text_end();

        // 1. GUObjectArray -> ObjObjects.Objects -> chunk0 -> first non-null Object -> vtable.
        uintptr_t vtable = 0;
        if (safe_call::probe_read(reinterpret_cast<void *>(guobjectarray + 0x10), 8))
        {
            uintptr_t objects = *reinterpret_cast<uintptr_t *>(guobjectarray + 0x10) & PTR_TAG_MASK;
            if (objects && safe_call::probe_read(reinterpret_cast<void *>(objects), 8))
            {
                uintptr_t chunk0 = *reinterpret_cast<uintptr_t *>(objects) & PTR_TAG_MASK;
                if (chunk0 && safe_call::probe_read(reinterpret_cast<void *>(chunk0), 0x18 * 8))
                {
                    for (int i = 0; i < 8 && !vtable; i++)
                    {
                        uintptr_t obj = *reinterpret_cast<uintptr_t *>(chunk0 + (uintptr_t)i * 0x18) & PTR_TAG_MASK;
                        if (!obj || !safe_call::probe_read(reinterpret_cast<void *>(obj), 8))
                            continue;
                        uintptr_t vt = *reinterpret_cast<uintptr_t *>(obj) & PTR_TAG_MASK;
                        if (!safe_call::probe_read(reinterpret_cast<void *>(vt), 8))
                            continue;
                        uintptr_t f0 = *reinterpret_cast<uintptr_t *>(vt) & PTR_TAG_MASK;
                        if (ts && f0 >= ts && f0 < te)
                            vtable = vt;
                    }
                }
            }
        }
        if (!vtable)
        {
            log.push_back("ProcessEvent(vtable): could not reach a UObject vtable");
            return 0;
        }

        // 2. Find the "ScriptCore.cpp" __FILE__ string and back up to its start (byte
        //    after the preceding NUL) — the compiler references the full path start.
        const char *sc = reinterpret_cast<const char *>(pattern::find_string("ScriptCore.cpp"));
        if (!sc)
        {
            log.push_back("ProcessEvent(vtable): 'ScriptCore.cpp' string absent");
            return 0;
        }
        uintptr_t sstart = reinterpret_cast<uintptr_t>(sc);
        while (sstart > reinterpret_cast<uintptr_t>(sc) - 256 &&
               *reinterpret_cast<const char *>(sstart - 1) != '\0')
            sstart--;

        // 3. Functions referencing it bracket ProcessEvent -> [lo,hi] .text window.
        std::vector<uintptr_t> refs = find_adrp_refs_to(sstart);
        if (refs.empty())
        {
            log.push_back("ProcessEvent(vtable): no ADRP refs to ScriptCore.cpp path");
            return 0;
        }
        uintptr_t lo = ~0ULL, hi = 0;
        for (uintptr_t r : refs)
        {
            if (r < lo) lo = r;
            if (r > hi) hi = r;
        }
        lo = (lo > 0x800) ? lo - 0x800 : 0; // small margin; ProcessEvent doesn't log itself
        hi += 0x800;

        // 4. The UObject vtable entry inside [lo,hi] is ProcessEvent.
        uintptr_t found = 0;
        int hits = 0;
        for (int i = 0; i < 220; i++)
        {
            if (!safe_call::probe_read(reinterpret_cast<void *>(vtable + (uintptr_t)i * 8), 8))
                break;
            uintptr_t fn = *reinterpret_cast<uintptr_t *>(vtable + (uintptr_t)i * 8) & PTR_TAG_MASK;
            if (fn >= lo && fn <= hi && fn >= ts && fn < te)
            {
                if (!found) found = fn;
                hits++;
            }
        }
        char msg[192];
        snprintf(msg, sizeof(msg),
                 "ProcessEvent(vtable): ScriptCore range [0x%lX-0x%lX], vtable hits=%d -> 0x%lX",
                 (unsigned long)lo, (unsigned long)hi, hits, (unsigned long)found);
        log.push_back(msg);
        return found;
    }

    uintptr_t find_process_event(uintptr_t guobjectarray)
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        // Strategy 1: "ProcessEvent" string — often referenced in error/log messages
        // The function that references "Accessed None" with a ProcessEvent context
        result = find_func_near_string("Accessed None trying to read property", "ProcessEvent(AccessedNone)", log);
        if (result)
            goto done;

        // Strategy 2: "Script call stack:" — printed inside ProcessEvent error handling
        result = find_func_near_string("Script call stack:", "ProcessEvent(CallStack)", log);
        if (result)
            goto done;

        // Strategy 3: "CallFunction" — UObject::CallFunction is called by ProcessEvent
        result = find_func_near_string("CallFunction", "ProcessEvent(CallFunction)", log);
        if (result)
            goto done;

        // Strategy 4: Look for EXACT token "ProcessEvent" (NUL-terminated)
        // to avoid false positives like processEvents/ProcessEventsN.
        result = find_func_near_exact_string("ProcessEvent", "ProcessEvent(literal-exact)", log);
        if (result)
            goto done;

        // ROBUST FALLBACK — ScriptCore.cpp __FILE__ neighbourhood ∩ UObject vtable.
        // Resolves ProcessEvent on stripped builds where the log strings above are gone.
        result = find_process_event_via_vtable(guobjectarray, log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());

        if (result)
            logger::log_info("AUTOOFF", "ProcessEvent discovered at 0x%lX", static_cast<unsigned long>(result));
        else
            logger::log_warn("AUTOOFF", "ProcessEvent NOT found via auto-discovery");

        return result;
    }

    // ═══ FIND GENGINE ═══════════════════════════════════════════════════════

    uintptr_t find_gengine()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        // "Create GEngine" — logged during engine startup
        result = find_global_near_string("Create GEngine", "GEngine(CreateGEngine)", log);
        if (result)
            goto done;

        // "Failed to create engine" — error path references GEngine
        result = find_global_near_string("Failed to create engine", "GEngine(FailCreate)", log);
        if (result)
            goto done;

        // "GEngine" literal
        result = find_global_near_string("GEngine", "GEngine(literal)", log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());
        return result;
    }

    // ═══ FIND GWORLD ════════════════════════════════════════════════════════

    uintptr_t find_gworld()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        // "GWorld" is set during map load
        result = find_global_near_string("GWorld", "GWorld(literal)", log);
        if (result)
            goto done;

        // "World Context" / "Browse" — UEngine::LoadMap references GWorld
        result = find_global_near_string("LoadMap", "GWorld(LoadMap)", log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());
        return result;
    }

    // ═══ FIND FNAME_INIT ════════════════════════════════════════════════════

    uintptr_t find_fname_init()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        // FName::Init references "FName" related strings
        // In UE4, FName() constructor calls FNameEntry allocation
        result = find_func_near_string("Fname_Add_f", "FNameInit(Add)", log);
        if (result)
            goto done;

        result = find_func_near_string("FNameEntry", "FNameInit(Entry)", log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());
        return result;
    }

    // ═══ FIND STATICFINDOBJECT ══════════════════════════════════════════════

    uintptr_t find_static_find_object()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        // StaticFindObject logs/asserts with these strings
        result = find_func_near_string("StaticFindObject", "StaticFindObject(literal)", log);
        if (result)
            goto done;

        result = find_func_near_string("Ambiguous search, could be", "StaticFindObject(Ambiguous)", log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());
        return result;
    }

    // ═══ FIND STATICCONSTRUCTOBJECT ═════════════════════════════════════════

    uintptr_t find_static_construct_object()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        // ── PRIMARY: UE4.26+ params-struct form (ABI form B) ────────────────
        // Assert strings are stripped in shipping UE5, so the string heuristics below
        // mis-resolve to a NEIGHBORING function (e.g. FObjectInitializer::PostConstructInit),
        // which then crashes when called with the wrong ABI. Anchor instead on the
        // distinctive BODY of StaticConstructObject_Internal reading the params struct:
        //   MOV W9,#0x10000080 ; LDP X20,X21,[X0] (Class,Outer) ; LDR W22,[X0,#0x18] (SetFlags)
        //   ; LDR W8,[X20,#0xD4] (Class flags) ; TST W8,W9
        // Verified unique across the image; walk back to the prologue for the entry.
        {
            void *hit = pattern::scan(
                "09 10 80 52 09 00 A2 72 A8 83 1F F8 14 54 40 A9 16 18 40 B9 88 D6 40 B9 1F 01 09 6A");
            if (hit)
            {
                uintptr_t fn = find_function_start(reinterpret_cast<uintptr_t>(hit), 0x100);
                if (fn)
                {
                    symbols::StaticConstructObject_is_params_struct = true;
                    char buf[96];
                    snprintf(buf, sizeof(buf), "StaticConstructObject(params-struct AOB) @ 0x%lX", (unsigned long)fn);
                    log.push_back(buf);
                    result = fn;
                    goto done;
                }
            }
        }

        // ── FALLBACK: legacy multi-arg form (ABI form A) via string refs ────
        // UE4: "StaticConstructObject_Internal" in logging/asserts
        symbols::StaticConstructObject_is_params_struct = false;
        result = find_func_near_string("StaticConstructObject_Internal", "StaticConstructObject(literal)", log);
        if (result)
            goto done;

        // Fallback: the function references "is not a legal class" in an assertion
        result = find_func_near_string("is not a legal class", "StaticConstructObject(IllegalClass)", log);
        if (result)
            goto done;

        // Fallback: references "ConstructObject"
        result = find_func_near_string("ConstructObject", "StaticConstructObject(ConstructObject)", log);
        if (result)
            goto done;

        // Fallback: references "Abstract class" which StaticConstructObject asserts
        result = find_func_near_string("Abstract class", "StaticConstructObject(Abstract)", log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());
        return result;
    }

    // ═══ FIND STATICLOADOBJECT ══════════════════════════════════════════════

    uintptr_t find_static_load_object()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        result = find_func_near_exact_string("StaticLoadObject", "StaticLoadObject(literal)", log);
        if (result)
            goto done;

        // StaticLoadObjectInternal asserts/logs with these strings.
        result = find_func_near_string("Illegal call to StaticLoadObject", "StaticLoadObject(Illegal)", log);
        if (result)
            goto done;

        result = find_func_near_string("Failed to find object", "StaticLoadObject(FailFind)", log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());
        return result;
    }

    // ═══ FIND APPENDSTRING (FName::ToString) ════════════════════════════════
    // The name→string function reads an FNameEntry from the FNamePool: it loads
    // the 2-byte entry header (LDRH), extracts the length (shift right by 6), then
    // copies the characters out (STRB/STRH loop). We find every function that
    // references the FNamePool global and score them by that shape; the ToString /
    // AppendString routine scores highest. This is far more robust across ARM64
    // games than a fixed byte signature.
    uintptr_t find_append_string()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        uintptr_t pool = find_gnames();
        if (pool == 0)
        {
            log.push_back("AppendString: FNamePool unknown — cannot locate via xrefs");
            goto done;
        }

        {
            auto refs = find_adrp_refs_to(pool);
            char msg[256];
            snprintf(msg, sizeof(msg), "AppendString: %zu xref(s) to FNamePool 0x%lX",
                     refs.size(), static_cast<unsigned long>(pool));
            log.push_back(msg);

            std::unordered_map<uintptr_t, int> func_scores;
            for (uintptr_t ref : refs)
            {
                uintptr_t fstart = find_function_start(ref);
                if (fstart == 0)
                    continue;

                int score = 0;
                bool has_ldrh = false;
                bool has_shift6 = false;
                bool has_store = false;
                for (uintptr_t pc = fstart; pc < fstart + 0x400; pc += 4)
                {
                    if (!safe_call::probe_read(reinterpret_cast<void *>(pc), 4))
                        break;
                    uint32_t instr = *reinterpret_cast<uint32_t *>(pc);

                    // LDRH (unsigned offset) — read the 16-bit FNameEntry header.
                    if ((instr & 0xFFC00000) == 0x79400000)
                        has_ldrh = true;
                    // UBFX/LSR by #6 (immr=6): 32-bit UBFM has immr field at bits 16..21.
                    if ((instr & 0xFFC00000) == 0x53000000 && ((instr >> 16) & 0x3F) == 6)
                        has_shift6 = true;
                    // STRB (char copy-out loop).
                    if ((instr & 0xFFC00000) == 0x39000000)
                        has_store = true;

                    if (instr == 0xD65F03C0) // RET — end of function
                        break;
                }

                if (has_ldrh)
                    score += 5;
                if (has_shift6)
                    score += 6;
                if (has_store)
                    score += 3;

                if (score > func_scores[fstart])
                    func_scores[fstart] = score;
            }

            int best_score = 0;
            for (const auto &kv : func_scores)
            {
                if (kv.second > best_score)
                {
                    best_score = kv.second;
                    result = kv.first;
                }
            }

            if (result && best_score >= 8)
            {
                snprintf(msg, sizeof(msg), "AppendString: selected 0x%lX (shape score %d)",
                         static_cast<unsigned long>(result), best_score);
                log.push_back(msg);
            }
            else
            {
                snprintf(msg, sizeof(msg), "AppendString: no strong candidate (best score %d) — leaving unresolved",
                         best_score);
                log.push_back(msg);
                result = 0;
            }
        }

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());
        if (result)
            logger::log_info("AUTOOFF", "AppendString discovered at 0x%lX", static_cast<unsigned long>(result));
        return result;
    }

    // ═══ FIND GNATIVES ══════════════════════════════════════════════════════
    // GNatives is the bytecode-opcode → handler function-pointer table used by the
    // UFunction interpreter. It lives in .data and is referenced by the VM loop.
    uintptr_t find_gnatives()
    {
        std::vector<std::string> log;
        uintptr_t result = 0;

        result = find_global_near_string("GNatives", "GNatives(literal)", log);
        if (result)
            goto done;

        // The interpreter error path references these when it hits a bad opcode.
        result = find_global_near_string("Unknown code token", "GNatives(UnknownToken)", log);
        if (result)
            goto done;

        result = find_global_near_string("Bad bytecode", "GNatives(BadBytecode)", log);
        if (result)
            goto done;

    done:
        for (const auto &msg : log)
            logger::log_info("AUTOOFF", "  %s", msg.c_str());
        if (result)
            logger::log_info("AUTOOFF", "GNatives discovered at 0x%lX", static_cast<unsigned long>(result));
        return result;
    }

    // ═══ PROBE FUOBJECTITEM SIZE ════════════════════════════════════════════

    uint32_t probe_fuobjectitem_size(uintptr_t guobjectarray)
    {
        if (guobjectarray == 0)
            return 0;

        // GUObjectArray layout:
        //   [+0x00..+0x??] FChunkedFixedUObjectArray ObjObjects
        //   ObjObjects has: Objects** (ptr to chunk array), NumElements, ...
        //
        // FUObjectItem is either 0x14 (UE4) or 0x18 (UE5) bytes.
        // We determine this by:
        //   1. Read the Objects** chunk pointer
        //   2. Read the first chunk pointer
        //   3. Read objects at stride 0x18 and 0x14
        //   4. Validate which stride produces valid UObject pointers

        // The embedded array starts at guobjectarray + GUOBJECTARRAY_TO_OBJECTS
        // This offset varies but is typically 0x10-0x20
        // Try the configured offset first, then probe
        uint32_t embedded_off = ue::GUOBJECTARRAY_TO_OBJECTS;

        uintptr_t embedded = guobjectarray + embedded_off;
        if (!safe_call::probe_read(reinterpret_cast<void *>(embedded), 16))
        {
            logger::log_warn("AUTOOFF", "Cannot read GUObjectArray embedded array at 0x%lX",
                             static_cast<unsigned long>(embedded));
            return 0;
        }

        // Read Objects** (first field of the embedded array)
        uintptr_t objects_ptr = *reinterpret_cast<uintptr_t *>(embedded);
        if (!safe_call::probe_read(reinterpret_cast<void *>(objects_ptr), 8))
        {
            logger::log_warn("AUTOOFF", "Objects** invalid at 0x%lX",
                             static_cast<unsigned long>(objects_ptr));
            return 0;
        }

        // Read first chunk pointer
        uintptr_t chunk0 = *reinterpret_cast<uintptr_t *>(objects_ptr);
        if (!safe_call::probe_read(reinterpret_cast<void *>(chunk0), 64))
        {
            logger::log_warn("AUTOOFF", "First chunk invalid at 0x%lX",
                             static_cast<unsigned long>(chunk0));
            return 0;
        }

        // Try both strides and count valid UObject pointers
        int valid_14 = count_valid_uobject_slots(chunk0, 0x14, 50);
        int valid_18 = count_valid_uobject_slots(chunk0, 0x18, 50);

        logger::log_info("AUTOOFF", "FUObjectItem size probe: stride 0x14 → %d valid, stride 0x18 → %d valid",
                         valid_14, valid_18);

        if (valid_18 > valid_14 && valid_18 >= 10)
        {
            logger::log_info("AUTOOFF", "FUObjectItem size = 0x18 (UE5 style)");
            return 0x18;
        }
        else if (valid_14 > valid_18 && valid_14 >= 10)
        {
            logger::log_info("AUTOOFF", "FUObjectItem size = 0x14 (UE4 style)");
            return 0x14;
        }

        logger::log_warn("AUTOOFF", "FUObjectItem size AMBIGUOUS (14:%d, 18:%d)", valid_14, valid_18);
        return 0;
    }

    // ═══ PROBE FFIELD OWNER SIZE ════════════════════════════════════════════

    uint32_t probe_ffield_owner_size()
    {
        // FField owner is either:
        //   UE4: FFieldVariant (16 bytes)
        //   UE5: compact tagged FFieldVariant (8 bytes)
        //
        // We can detect this from the engine version
        auto ver = detect_engine_version();
        if (ver >= engine_versions::EngineVersion::UE5_0)
        {
            logger::log_info("AUTOOFF", "FField owner size = 8 (UE5 tagged FFieldVariant)");
            return 8;
        }
        else if (ver != engine_versions::EngineVersion::UNKNOWN)
        {
            logger::log_info("AUTOOFF", "FField owner size = 16 (UE4 FFieldVariant)");
            return 16;
        }
        return 0;
    }

    // ═══ DISCOVER ALL ═══════════════════════════════════════════════════════

    DiscoveryResult discover_all()
    {
        DiscoveryResult result;
        memset(&result, 0, sizeof(result)); // zero all numeric fields
        result.version_confidence = 0;
        result.gnames_confidence = 0;
        result.guobjectarray_confidence = 0;
        result.process_event_confidence = 0;
        result.total_discoveries = 0;
        result.failed_discoveries = 0;

        auto log = [&](const char *fmt, ...)
        {
            char buf[512];
            va_list args;
            va_start(args, fmt);
            vsnprintf(buf, sizeof(buf), fmt, args);
            va_end(args);
            result.discovery_log.push_back(buf);
            logger::log_info("AUTOOFF", "%s", buf);
        };

        log("═══ AUTO-OFFSET DISCOVERY START ═══");

        // 1. Engine version
        log("--- Detecting engine version ---");
        result.detected_version = detect_engine_version(&result.version_string);
        result.is_ue5 = (result.detected_version >= engine_versions::EngineVersion::UE5_0);
        if (result.detected_version != engine_versions::EngineVersion::UNKNOWN)
        {
            result.version_confidence = 1.0f;
            result.total_discoveries++;
            log("Engine version: %s (UE%s)", result.version_string.c_str(),
                result.is_ue5 ? "5" : "4");
        }
        else
        {
            result.failed_discoveries++;
            log("Engine version: UNKNOWN");
        }

        // 2. GNames
        log("--- Finding GNames ---");
        result.gnames = find_gnames();
        if (result.gnames)
        {
            result.gnames_confidence = 0.8f;
            result.total_discoveries++;
        }
        else
            result.failed_discoveries++;

        // 3. GUObjectArray
        log("--- Finding GUObjectArray ---");
        result.guobjectarray = find_guobjectarray();
        if (result.guobjectarray)
        {
            result.guobjectarray_confidence = 0.8f;
            result.total_discoveries++;

            // 3b. Probe FUObjectItem size using discovered GUObjectArray
            log("--- Probing FUObjectItem size ---");
            result.fuobjectitem_size = probe_fuobjectitem_size(result.guobjectarray);
            if (result.fuobjectitem_size)
                result.total_discoveries++;
            else
                result.failed_discoveries++;
        }
        else
            result.failed_discoveries++;

        // 4. ProcessEvent
        log("--- Finding ProcessEvent ---");
        result.process_event = find_process_event(result.guobjectarray);
        if (result.process_event)
        {
            result.process_event_confidence = 0.7f;
            result.total_discoveries++;
        }
        else
            result.failed_discoveries++;

        // 5. GEngine
        log("--- Finding GEngine ---");
        result.gengine = find_gengine();
        if (result.gengine)
            result.total_discoveries++;
        else
            result.failed_discoveries++;

        // 6. GWorld
        log("--- Finding GWorld ---");
        result.gworld = find_gworld();
        if (result.gworld)
            result.total_discoveries++;
        else
            result.failed_discoveries++;

        // 7. FName::Init
        log("--- Finding FName::Init ---");
        result.fname_init = find_fname_init();
        if (result.fname_init)
            result.total_discoveries++;
        else
            result.failed_discoveries++;

        // 8. StaticFindObject
        log("--- Finding StaticFindObject ---");
        result.static_find_object = find_static_find_object();
        if (result.static_find_object)
            result.total_discoveries++;
        else
            result.failed_discoveries++;

        // 9. StaticConstructObject
        log("--- Finding StaticConstructObject ---");
        result.static_construct_object = find_static_construct_object();
        if (result.static_construct_object)
            result.total_discoveries++;
        else
            result.failed_discoveries++;

        // 9b. StaticLoadObject
        log("--- Finding StaticLoadObject ---");
        result.static_load_object = find_static_load_object();
        if (result.static_load_object)
            result.total_discoveries++;
        else
            result.failed_discoveries++;

        // 9c. AppendString (FName::ToString) — Dumper-7 core scanner
        log("--- Finding AppendString (FName::ToString) ---");
        result.append_string = find_append_string();
        if (result.append_string)
            result.total_discoveries++;
        else
            result.failed_discoveries++;

        // 9d. GNatives — Dumper-7 core scanner
        log("--- Finding GNatives ---");
        result.gnatives = find_gnatives();
        if (result.gnatives)
            result.total_discoveries++;
        else
            result.failed_discoveries++;

        // 10. FField owner size
        log("--- Probing FField owner size ---");
        result.ffield_owner_size = probe_ffield_owner_size();
        if (result.ffield_owner_size)
            result.total_discoveries++;
        else
            result.failed_discoveries++;

        // 11. Standard UObject offsets (these are constant across all versions)
        result.uobject_name_offset = 0x18;
        result.uobject_class_offset = 0x10;
        result.uobject_outer_offset = 0x20;

        log("═══ AUTO-OFFSET DISCOVERY COMPLETE ═══");
        log("Discovered: %d, Failed: %d", result.total_discoveries, result.failed_discoveries);

        return result;
    }

    // ═══ APPLY TO PROFILE ═══════════════════════════════════════════════════

    void apply_to_profile(const DiscoveryResult &result)
    {
        auto &profile = game_profile::mutable_profile();

        // Apply binary-detected engine version if it is known and either:
        //   1) profile had no exact version yet, or
        //   2) profile was using a bootstrap assumption that differs.
        if (result.detected_version != engine_versions::EngineVersion::UNKNOWN &&
            profile.detected_engine_version != result.detected_version)
        {
            auto old_version = profile.detected_engine_version;
            profile.detected_engine_version = result.detected_version;
            profile.engine_version = std::string(version_to_string(result.detected_version)) + " (binary-detected)";
            logger::log_info("AUTOOFF", "Applied binary engine version to profile: %s -> %s [%s]",
                             version_to_string(old_version),
                             version_to_string(result.detected_version),
                             result.version_string.empty() ? "no marker string" : result.version_string.c_str());

            // Rebuild offsets for the detected version
            profile.offsets = game_profile::build_offsets_for_version(result.detected_version);
            ue::apply_type_offsets(profile.offsets);
            logger::log_info("AUTOOFF", "Rebuilt type offsets for binary-detected engine version");
        }
        else if (result.detected_version != engine_versions::EngineVersion::UNKNOWN)
        {
            logger::log_info("AUTOOFF", "Binary engine version matches bootstrap profile: %s [%s]",
                             version_to_string(result.detected_version),
                             result.version_string.empty() ? "no marker string" : result.version_string.c_str());
        }

        // Apply discovered pointers as offsets relative to the already-resolved
        // engine library base. This must use symbols::lib_base() (not dladdr on
        // a dlopen handle), otherwise base resolution can silently fail.
        uintptr_t lib_base = symbols::lib_base();
        if (lib_base == 0)
        {
            logger::log_warn("AUTOOFF", "Engine lib base unavailable — skipping offset registration this pass");
        }

        auto register_offset = [&](const char *name, uintptr_t addr)
        {
            if (addr == 0 || lib_base == 0)
                return;
            uintptr_t offset = addr - lib_base;

            bool updated_existing = false;
            for (auto &fo : profile.fallback_offsets)
            {
                if (fo.symbol_name == name)
                {
                    fo.offset = offset;
                    updated_existing = true;
                    break;
                }
            }

            if (!updated_existing)
            {
                profile.fallback_offsets.push_back({name, offset});
            }

            // Keep stable-global table in sync if an entry exists there.
            for (auto &sg : profile.stable_global_offsets)
            {
                if (sg.symbol_name == name)
                {
                    sg.offset = offset;
                    break;
                }
            }

            // Also register directly into the live symbol resolver map so
            // resolve_core_symbols() can consume dynamic discoveries in this boot.
            symbols::register_fallback(name, offset);

            logger::log_info("AUTOOFF", "%s fallback: %s = 0x%lX (offset 0x%lX)",
                             updated_existing ? "Updated" : "Registered",
                             name,
                             static_cast<unsigned long>(addr),
                             static_cast<unsigned long>(offset));
        };

        if (result.gnames)
            register_offset("GNames", result.gnames);
        if (result.guobjectarray)
            register_offset("GUObjectArray", result.guobjectarray);
        if (result.gengine)
            register_offset("GEngine", result.gengine);
        if (result.gworld)
            register_offset("GWorld", result.gworld);
        if (result.process_event)
            register_offset("ProcessEvent", result.process_event);
        if (result.fname_init)
            register_offset("FName::Init", result.fname_init);
        if (result.static_find_object)
            register_offset("StaticFindObject", result.static_find_object);
        if (result.static_construct_object)
            register_offset("StaticConstructObject", result.static_construct_object);
        if (result.static_load_object)
            register_offset("StaticLoadObject", result.static_load_object);
        if (result.append_string)
        {
            register_offset("AppendString", result.append_string);
            register_offset("FName::ToString", result.append_string);
        }
        if (result.gnatives)
            register_offset("GNatives", result.gnatives);

        // Apply structural offsets
        if (result.fuobjectitem_size != 0)
        {
            profile.offsets.FUObjectItem_size = result.fuobjectitem_size;
            logger::log_info("AUTOOFF", "Applied FUObjectItem size: 0x%X", result.fuobjectitem_size);
        }

        logger::log_info("AUTOOFF", "Profile update complete — %d discoveries applied",
                         result.total_discoveries);
    }

} // namespace auto_offsets
