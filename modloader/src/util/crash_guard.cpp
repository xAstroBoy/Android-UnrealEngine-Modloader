// modloader/src/util/crash_guard.cpp
// Crash Guard v2 — see crash_guard.h for the design contract.
//
// Split of responsibilities:
//   try_recover()  — runs INSIDE the signal handler. Absolutely no malloc,
//                    no stdio, no locks. Reads thread_local guard flags,
//                    fills one preallocated ring slot (CAS-claimed), and
//                    siglongjmps to the armed checkpoint.
//   drain()        — runs on a normal thread (the signal-handler watchdog,
//                    every ~5s). Owns all the expensive/unsafe work:
//                    dladdr symbolication, per-site rate limiting, and the
//                    append to modloader_recovered.log.
//
// The recovery targets are the SAME thread_local sigsetjmp checkpoints the
// guard sites have armed all along (they were left in place when v1 was
// removed — every site still handles its "sigsetjmp returned non-zero" path,
// including nesting save/restore and the per-hook circuit breaker).

#include "modloader/crash_guard.h"
#include "modloader/arch.h"
#include "modloader/safe_call.h"
#include "modloader/logger.h"
#include "modloader/paths.h"
#include "modloader/mod_loader.h"
#include "modloader/process_event_hook.h"
#include "modloader/notification.h"
#include <atomic>
#include <cstdio>
#include <cstring>
#include <map>
#include <mutex>
#include <string>
#include <utility>
#include <dlfcn.h>
#include <fcntl.h>
#include <link.h>
#include <setjmp.h>
#include <ucontext.h>
#include <asm/sigcontext.h>
#include <sys/prctl.h>
#include <sys/stat.h>
#include <sys/syscall.h>
#include <time.h>
#include <unistd.h>

// ═══ Recovery checkpoints armed by the guard sites ══════════════════════════
// These already exist and are already armed/restored (with correct nesting
// semantics) by their owners; declared here so the handler can jump to them.

// native_hooks.cpp — global namespace
extern thread_local volatile int g_in_hook_original_call;
extern thread_local sigjmp_buf g_hook_recovery_jmp;
extern thread_local volatile int g_in_hook_install;
extern thread_local sigjmp_buf g_hook_install_jmp;
// Attribution: name of the hook whose original/install is executing on this
// thread (points into a HookRecord's std::string — records are never freed).
extern thread_local const char *g_hook_ctx_name;

namespace lua_uobject
{
    // lua_uobject.cpp — ScopedPeCrashGuard checkpoints
    extern thread_local volatile int g_in_call_ufunction;
    extern thread_local sigjmp_buf g_call_ufunction_jmp;
    extern thread_local volatile uintptr_t g_call_ufunction_fault_addr;
    // Attribution: "Class"/"Func" of the UFunction currently being Call()'d
    // (pointers into the prepared PE crash context — async-signal-safe reads).
    void pe_crash_ctx_names(const char **cls, const char **fn);
}

namespace mod_loader
{
    // mod_loader.cpp — per-mod main.lua execution checkpoint
    extern thread_local sigjmp_buf s_mod_jmpbuf;
    extern thread_local volatile sig_atomic_t s_in_mod_loading;
    // Attribution: name of the mod whose main.lua is executing on this thread.
    extern thread_local char t_loading_mod_name[64];
}

namespace native_hooks
{
    // Drain-time attribution for global skips: is this PC at/near a Dobby
    // entry patch or inside a trampoline? (normal context — takes hook mutex)
    bool describe_site(uintptr_t pc, char *out, size_t out_sz);
    bool site_owner_mod(uintptr_t pc, char *mod_out, size_t mod_sz);
    bool hook_owner_mod_by_name(const char *hook_name, char *mod_out, size_t mod_sz);
}

namespace mod_tracker
{
    // Drain-time attribution: which mod byte-patched code at/near this PC?
    bool find_patch_near(uintptr_t pc, std::string &mod_out,
                         uintptr_t &addr_out, size_t &size_out);
}

namespace crash_guard
{

    // ═══ Toggle ══════════════════════════════════════════════════════════════
    static std::atomic<bool> s_enabled{true};

    bool enabled() { return s_enabled.load(std::memory_order_relaxed); }

    void set_enabled(bool on)
    {
        bool was = s_enabled.exchange(on, std::memory_order_relaxed);
        if (was != on)
            logger::log_warn("CGUARD", "Crash guard %s — guarded faults will %s",
                             on ? "ENABLED" : "DISABLED",
                             on ? "be suppressed (filed to modloader_recovered.log)"
                                : "be FATAL (full report + tombstone)");
    }

    // ═══ Global-skip mode ═════════════════════════════════════════════════════
    static std::atomic<uint8_t> s_global_mode{static_cast<uint8_t>(GlobalMode::All)};
    static std::atomic<bool> s_storm_tripped{false};

    GlobalMode global_mode()
    {
        return static_cast<GlobalMode>(s_global_mode.load(std::memory_order_relaxed));
    }

    void set_global_mode(GlobalMode m)
    {
        GlobalMode was = static_cast<GlobalMode>(
            s_global_mode.exchange(static_cast<uint8_t>(m), std::memory_order_relaxed));
        if (was != m)
        {
            static const char *names[] = {"off", "null-only", "all"};
            logger::log_warn("CGUARD", "Global instruction-skip recovery: %s -> %s",
                             names[static_cast<int>(was)], names[static_cast<int>(m)]);
        }
    }

    GlobalMode global_mode_from_string(const std::string &s)
    {
        if (s == "all") return GlobalMode::All;
        if (s == "null" || s == "null-only") return GlobalMode::NullOnly;
        return GlobalMode::Off;
    }

    // ═══ Counters (async-signal-safe writers) ════════════════════════════════
    static std::atomic<uint64_t> s_total{0};
    static std::atomic<uint64_t> s_by_kind[7] = {};
    static std::atomic<uint64_t> s_dropped{0};
    static std::atomic<uint64_t> s_seq{0};

    uint64_t total_recovered() { return s_total.load(std::memory_order_relaxed); }

    const char *kind_name(Kind k)
    {
        switch (k)
        {
        case Kind::SafeCall:      return "safe_call";
        case Kind::HookOriginal:  return "hook-original";
        case Kind::HookInstall:   return "hook-install";
        case Kind::UFunctionCall: return "ufunction-call";
        case Kind::ModLoad:       return "mod-load";
        case Kind::GlobalSkip:    return "global-skip";
        default:                  return "none";
        }
    }

    // ═══ Suppressed-crash ring ═══════════════════════════════════════════════
    // Fixed-size, preallocated, multi-producer (any faulting thread) /
    // single-consumer (drain). Slot lifecycle: 0 free → 1 writing → 2 ready.
    static constexpr int kRingSize = 256;
    static constexpr int kMaxFrames = 16;

    // Plain-old-data payload, separated from the slot's atomic state so the
    // drain can copy/sort records with plain assignment.
    struct Payload
    {
        uint64_t seq;
        struct timespec ts;
        int tid;
        char thread_name[16];
        int sig;
        int code;
        uint8_t kind;
        uint32_t insn; // faulting instruction word (global-skip only, else 0)
        uintptr_t fault;
        uintptr_t pc, lr, sp, fp, x0;
        char ctx[96]; // culprit context captured at fault time ("" if none)
        int bt_n;
        uintptr_t bt[kMaxFrames];
    };

    struct Record
    {
        std::atomic<uint32_t> state; // 0 free, 1 writing, 2 ready
        Payload p;
    };

    static Record s_ring[kRingSize]; // zero-initialized (static storage)
    static std::atomic<uint64_t> s_write_idx{0};

    // ═══ Async-signal-safe memory read for the backtrace walk ════════════════
    // pread on /proc/self/mem is kernel-mediated: unmapped/protected pages give
    // -1 instead of a nested fault. fd is opened once in init() so the handler
    // never calls open().
    static int s_mem_fd = -1;

    static bool sig_safe_read(uintptr_t addr, void *out, size_t n)
    {
        if (s_mem_fd < 0 || addr < 0x1000)
            return false;
        return pread64(s_mem_fd, out, n, static_cast<off64_t>(addr)) ==
               static_cast<ssize_t>(n);
    }

    // ARM64 frame-pointer chain: x29 → { prev_x29, saved_x30 }.
    static int walk_frames(uintptr_t pc, uintptr_t lr, uintptr_t fp, uintptr_t sp,
                           uintptr_t *out, int max)
    {
        int n = 0;
        if (n < max && pc) out[n++] = pc;
        if (n < max && lr) out[n++] = lr;
        uintptr_t prev_fp = 0;
        for (int i = 0; i < 64 && n < max; i++)
        {
            if (!fp || (fp & 0xF) != 0)      // must be 16-aligned
                break;
            if (fp <= prev_fp)                // must strictly ascend the stack
                break;
            if (sp && (fp < sp || fp - sp > (16u << 20))) // stay near this stack
                break;
            uintptr_t pair[2];
            if (!sig_safe_read(fp, pair, sizeof(pair)))
                break;
            if (pair[1] < 0x10000)            // return address sanity
                break;
            out[n++] = pair[1];
            prev_fp = fp;
            fp = pair[0];
        }
        return n;
    }

    // Fill one ring slot. Async-signal-safe throughout. `ctx` = culprit label
    // captured from the guard site's thread_local state (may be null/empty);
    // `insn` = faulting instruction word for global skips.
    static void file_recovered(Kind kind, int sig, siginfo_t *info, void *ucontext_raw,
                               const char *ctx = nullptr, uint32_t insn = 0)
    {
        s_total.fetch_add(1, std::memory_order_relaxed);
        s_by_kind[static_cast<int>(kind)].fetch_add(1, std::memory_order_relaxed);

        uint64_t i = s_write_idx.fetch_add(1, std::memory_order_relaxed);
        Record &r = s_ring[i % kRingSize];
        uint32_t expected = 0;
        if (!r.state.compare_exchange_strong(expected, 1, std::memory_order_acquire))
        {
            // Slot still not drained — storm faster than the drain. Count only.
            s_dropped.fetch_add(1, std::memory_order_relaxed);
            return;
        }

        Payload &p = r.p;
        p.seq = s_seq.fetch_add(1, std::memory_order_relaxed);
        clock_gettime(CLOCK_REALTIME, &p.ts);
        p.tid = static_cast<int>(syscall(SYS_gettid));
        p.thread_name[0] = '\0';
        prctl(PR_GET_NAME, reinterpret_cast<unsigned long>(p.thread_name), 0, 0, 0);
        p.thread_name[sizeof(p.thread_name) - 1] = '\0';
        p.sig = sig;
        p.code = info ? info->si_code : 0;
        p.kind = static_cast<uint8_t>(kind);
        p.insn = insn;
        p.ctx[0] = '\0';
        if (ctx && ctx[0])
        {
            strncpy(p.ctx, ctx, sizeof(p.ctx) - 1);
            p.ctx[sizeof(p.ctx) - 1] = '\0';
        }
        p.fault = info ? reinterpret_cast<uintptr_t>(info->si_addr) : 0;
        p.pc = p.lr = p.sp = p.fp = p.x0 = 0;
        p.bt_n = 0;
        if (ucontext_raw)
        {
            ucontext_t *uc = static_cast<ucontext_t *>(ucontext_raw);
            p.pc = arch::uc_pc(uc);
            p.lr = arch::uc_lr(uc);
            p.sp = arch::uc_sp(uc);
            p.fp = arch::uc_fp(uc);
            p.x0 = arch::uc_reg(uc, 0);
            p.bt_n = walk_frames(p.pc, p.lr, p.fp, p.sp, p.bt, kMaxFrames);
        }

        r.state.store(2, std::memory_order_release);
    }

    // ═══ Our own library range (global skips must never hide OUR bugs) ═══════
    static uintptr_t s_self_base = 0, s_self_end = 0;

    static int find_self_cb(struct dl_phdr_info *dlinfo, size_t, void *)
    {
        if (dlinfo->dlpi_name && strstr(dlinfo->dlpi_name, "libmodloader.so"))
        {
            uintptr_t lo = UINTPTR_MAX, hi = 0;
            for (int i = 0; i < dlinfo->dlpi_phnum; i++)
            {
                if (dlinfo->dlpi_phdr[i].p_type == PT_LOAD)
                {
                    uintptr_t a = dlinfo->dlpi_addr + dlinfo->dlpi_phdr[i].p_vaddr;
                    uintptr_t b = a + dlinfo->dlpi_phdr[i].p_memsz;
                    if (a < lo) lo = a;
                    if (b > hi) hi = b;
                }
            }
            s_self_base = lo;
            s_self_end = hi;
            return 1;
        }
        return 0;
    }

#if defined(__arm__)
    // ═══ Global instruction-skip (ARM32 / Thumb load/store emulate-as-zero) ══
    // Conservative decoder: fully handles ARM (A32) single data transfers and
    // the 16-bit Thumb LDR/STR forms — on a load it zeroes the destination
    // register, applies base-register writeback so pointer-walk loops still
    // advance, and bumps PC by the encoded width (4 for A32, 2 for 16-bit
    // Thumb). 32-bit Thumb-2, LDM/STM and VFP/NEON transfers are refused
    // (return false → fatal), matching the "can't PROVE it → fatal" contract of
    // the AArch64 decoder. (There is no separate SIMD file to zero here.)
    static void zero_vreg(ucontext_t *, int) {}
    static bool skip_faulting_insn(ucontext_t *uc, uint32_t insn, bool apply)
    {
        mcontext_t &mc = uc->uc_mcontext;
        unsigned long *R = &mc.arm_r0; // r0..r15 contiguous
        const bool thumb = (mc.arm_cpsr & (1u << 5)) != 0;
        auto set_r = [&](int r) { if (apply && r >= 0 && r < 15) R[r] = 0; };

        if (!thumb)
        {
            // ARM (A32) single data transfer: LDR/STR/LDRB/STRB (bits[27:26]=01).
            if (((insn >> 26) & 0x3) == 0x1)
            {
                const bool reg_off = (insn >> 25) & 1;
                const bool pre     = (insn >> 24) & 1;
                const bool up      = (insn >> 23) & 1;
                const bool wb      = (insn >> 21) & 1;
                const bool load    = (insn >> 20) & 1;
                const int  rn      = (insn >> 16) & 0xF;
                const int  rt      = (insn >> 12) & 0xF;
                if (rt == 15) return false; // transfer involving PC — stay fatal
                const bool writes_base = (pre && wb) || !pre;
                if (reg_off)
                {
                    if (insn & 0x10) return false;  // bit4 set → media, not plain LS
                    if (writes_base) return false;  // reg-offset writeback: don't guess offset
                    if (load) set_r(rt);
                }
                else
                {
                    const long off = insn & 0xFFF;
                    if (writes_base && apply && rn < 15) R[rn] += up ? off : -off;
                    if (load) set_r(rt);
                }
                if (apply) mc.arm_pc += 4;
                return true;
            }
            return false;
        }

        // Thumb: first halfword is the low 16 bits of the little-endian stream.
        const uint16_t hw = static_cast<uint16_t>(insn & 0xFFFF);
        if ((hw & 0xF800) >= 0xE800)
            return false; // 32-bit Thumb-2 encoding — not decoded (stays fatal)

        int rt = -1; bool load = false, is_ls = false;
        if ((hw & 0xF000) == 0x5000) // load/store register offset (8 variants)
        {
            const int op = (hw >> 9) & 0x7; // op >= 3 → a load form
            load = op >= 3; rt = hw & 0x7; is_ls = true;
        }
        else if ((hw & 0xF000) == 0x6000 || (hw & 0xF000) == 0x7000 ||
                 (hw & 0xF000) == 0x8000) // LDR/STR / LDRB/STRB / LDRH/STRH imm
        {
            load = (hw >> 11) & 1; rt = hw & 0x7; is_ls = true;
        }
        else if ((hw & 0xF000) == 0x9000) // LDR/STR SP-relative
        {
            load = (hw >> 11) & 1; rt = (hw >> 8) & 0x7; is_ls = true;
        }
        else if ((hw & 0xF800) == 0x4800) // LDR literal (PC-relative)
        {
            load = true; rt = (hw >> 8) & 0x7; is_ls = true;
        }

        if (is_ls)
        {
            if (rt == 15) return false;
            if (load) set_r(rt);
            if (apply) mc.arm_pc += 2;
            return true;
        }
        return false;
    }
#else
    // ═══ Global instruction-skip (ARM64 load/store emulate-as-zero) ══════════
    // Zero a SIMD/FP register inside the signal frame (vregs live in the
    // fpsimd_context record of mcontext.__reserved).
    static void zero_vreg(ucontext_t *uc, int vt)
    {
        uint8_t *p = reinterpret_cast<uint8_t *>(uc->uc_mcontext.__reserved);
        uint8_t *end = p + sizeof(uc->uc_mcontext.__reserved);
        while (p + sizeof(_aarch64_ctx) <= end)
        {
            _aarch64_ctx *h = reinterpret_cast<_aarch64_ctx *>(p);
            if (h->magic == 0 || h->size == 0)
                break;
            if (h->magic == FPSIMD_MAGIC)
            {
                reinterpret_cast<fpsimd_context *>(p)->vregs[vt & 31] = 0;
                return;
            }
            p += h->size;
        }
    }

    // Decode the faulting instruction; if it is a data access we can neutralize
    // (load → dest := 0, store → drop), apply any base-register writeback so
    // pointer-walking loops still advance, bump PC past it, and return true.
    // Anything we can't PROVE is a plain data access returns false → fatal.
    // `apply=false` decodes without touching the context (dry run, so the
    // crash record can be filed with the PRE-mutation registers).
    static bool skip_faulting_insn(ucontext_t *uc, uint32_t insn, bool apply)
    {
        auto &mc = uc->uc_mcontext;
        const int rt = insn & 0x1F;
        const int rn = (insn >> 5) & 0x1F;
        const int rt2 = (insn >> 10) & 0x1F;
        const int rs = (insn >> 16) & 0x1F;
        const bool vec = (insn >> 26) & 1;

        auto set_x = [&](int r) { if (apply && r >= 0 && r < 31) mc.regs[r] = 0; };
        auto zero_dst = [&](int r) { if (!apply) return; if (vec) zero_vreg(uc, r); else set_x(r); };
        auto wb_rn = [&](int64_t delta) {
            if (!apply) return;
            if (rn == 31) mc.sp += delta; else mc.regs[rn] += delta;
        };

        bool handled = false;

        if ((insn & 0x3A000000) == 0x28000000)
        {
            // ── Load/store PAIR (LDP/STP, all addressing modes, incl. SIMD) ──
            const bool load = (insn >> 22) & 1;
            const int opc = (insn >> 30) & 3;
            const bool writeback = (insn >> 23) & 1;
            int scale = vec ? (2 + opc) : ((opc & 2) ? 3 : 2);
            if (writeback)
            {
                int64_t imm7 = static_cast<int64_t>((insn >> 15) & 0x7F);
                if (imm7 & 0x40) imm7 -= 0x80; // sign-extend
                wb_rn(imm7 << scale);
            }
            if (load) { zero_dst(rt); zero_dst(rt2); }
            handled = true;
        }
        else if ((insn & 0x3B000000) == 0x39000000)
        {
            // ── Load/store register, UNSIGNED immediate (LDR/STR imm) ────────
            const int size = (insn >> 30) & 3;
            const int opc = (insn >> 22) & 3;
            if (!vec && size == 3 && opc == 2)
            { /* PRFM — prefetch, no register effects */ }
            else
            {
                const bool load = vec ? (opc & 1)
                                      : (opc == 1 || (opc >= 2 && size != 3));
                if (load) zero_dst(rt);
            }
            handled = true;
        }
        else if ((insn & 0x3B000000) == 0x38000000)
        {
            // ── Load/store register: unscaled / pre / post / reg-offset /
            //    atomic RMW (LDADD..) / SWP ─────────────────────────────────
            const int size = (insn >> 30) & 3;
            const int opc = (insn >> 22) & 3;
            const bool bit21 = (insn >> 21) & 1;
            const int idx_mode = (insn >> 10) & 3;

            if (!bit21)
            {
                // LDUR/STUR (00), post-index (01), unprivileged (10), pre (11)
                if (idx_mode == 1 || idx_mode == 3)
                {
                    int64_t imm9 = static_cast<int64_t>((insn >> 12) & 0x1FF);
                    if (imm9 & 0x100) imm9 -= 0x200;
                    wb_rn(imm9);
                }
                const bool load = vec ? (opc & 1)
                                      : (opc == 1 || (opc >= 2 && size != 3));
                if (load) zero_dst(rt);
                handled = true;
            }
            else if (idx_mode == 2)
            {
                // Register offset: LDR/STR Rt, [Rn, Rm{, ext/shift}]
                const bool load = vec ? (opc & 1)
                                      : (opc == 1 || (opc >= 2 && size != 3));
                if (load) zero_dst(rt);
                handled = true;
            }
            else if (idx_mode == 0 && !vec)
            {
                // Atomic memory op (LDADD/LDSET/.../SWP): Rt receives the old
                // value (ST-alias uses Rt=31 → no effect). The store side is
                // dropped — acceptable for a fault we'd otherwise die on.
                set_x(rt);
                handled = true;
            }
        }
        else if ((insn & 0x3F000000) == 0x08000000)
        {
            // ── Exclusive / ordered (LDXR/STXR, LDAR/STLR, CAS, LDXP) ────────
            const bool load = (insn >> 22) & 1;
            const bool pair_or_cas = (insn >> 21) & 1;
            const bool ordered = (insn >> 23) & 1;
            if (load)
            {
                set_x(rt);
                if (pair_or_cas && rt2 != 31) set_x(rt2); // LDXP second dest
            }
            else if (!ordered && !pair_or_cas)
            {
                set_x(rs); // STXR status := 0 (success) so retry loops exit
            }
            else if (pair_or_cas && !ordered)
            {
                set_x(rs); // CAS: Rs receives the "old" value → 0
            }
            handled = true;
        }
        else if ((insn & 0x3B000000) == 0x18000000)
        {
            // ── LDR (literal) — PC-relative ──────────────────────────────────
            zero_dst(rt);
            handled = true;
        }

        if (handled && apply)
            mc.pc += 4;
        return handled;
    }
#endif // __arm__ vs AArch64 instruction-skip decoder

    // Storm brake: a fault that re-fires thousands of times per second means
    // skipping is not making progress (or is IN a tight loop) — a hang or a
    // corrupted-state spiral is worse than the crash. Trip → next fault fatal.
    static constexpr uint32_t kMaxSkipsPerSec = 2000;
    static std::atomic<uint32_t> s_skip_window_sec{0};
    static std::atomic<uint32_t> s_skips_in_window{0};

    static bool storm_brake_ok()
    {
        struct timespec ts;
        clock_gettime(CLOCK_MONOTONIC, &ts);
        uint32_t now = static_cast<uint32_t>(ts.tv_sec);
        uint32_t win = s_skip_window_sec.load(std::memory_order_relaxed);
        if (win != now)
        {
            s_skip_window_sec.store(now, std::memory_order_relaxed);
            s_skips_in_window.store(0, std::memory_order_relaxed);
        }
        if (s_skips_in_window.fetch_add(1, std::memory_order_relaxed) + 1 > kMaxSkipsPerSec)
        {
            s_storm_tripped.store(true, std::memory_order_relaxed);
            return false;
        }
        return true;
    }

    // ═══ Handler-side recovery dispatch ══════════════════════════════════════
    // Priority = innermost guard first (a Dobby fault during a hook install
    // that happens while a mod loads must unwind to install_at(), not skip the
    // whole mod). Each siglongjmp target's own recovery code restores its
    // nesting state — we only jump. If no guard is armed, global mode tries an
    // in-place instruction skip (patch ucontext, return true).
    bool try_recover(int sig, siginfo_t *info, void *ucontext_raw)
    {
        if (!enabled())
            return false;

        const bool hw_fault = (sig == SIGSEGV || sig == SIGBUS || sig == SIGFPE);
        // SIGABRT unwinds only the coarse regions that historically allowed it
        // (safe_call / mod load). Aborting inside a hot hooked original often
        // means the allocator detected corruption while holding its lock —
        // resuming that thread would deadlock it later, so let it be fatal.
        const bool abort_ok = (sig == SIGABRT);
        if (!hw_fault && !abort_ok)
            return false;

        uintptr_t fault = info ? reinterpret_cast<uintptr_t>(info->si_addr) : 0;

        if (hw_fault && g_in_hook_install)
        {
            file_recovered(Kind::HookInstall, sig, info, ucontext_raw, g_hook_ctx_name);
            siglongjmp(g_hook_install_jmp, sig);
        }

        if (hw_fault && g_in_hook_original_call)
        {
            file_recovered(Kind::HookOriginal, sig, info, ucontext_raw, g_hook_ctx_name);
            siglongjmp(g_hook_recovery_jmp, sig);
        }

        if (safe_call::is_in_safe_region())
        {
            file_recovered(Kind::SafeCall, sig, info, ucontext_raw);
            safe_call::signal_recovery(sig, fault); // siglongjmp — no return
        }

        if (hw_fault && lua_uobject::g_in_call_ufunction)
        {
            char ctx[96];
            const char *cls = nullptr, *fn = nullptr;
            lua_uobject::pe_crash_ctx_names(&cls, &fn);
            ctx[0] = '\0';
            if (cls || fn)
                snprintf(ctx, sizeof(ctx), "Call %s::%s",
                         cls ? cls : "?", fn ? fn : "?");
            file_recovered(Kind::UFunctionCall, sig, info, ucontext_raw, ctx);
            lua_uobject::g_call_ufunction_fault_addr = fault;
            siglongjmp(lua_uobject::g_call_ufunction_jmp, sig);
        }

        if (mod_loader::s_in_mod_loading)
        {
            file_recovered(Kind::ModLoad, sig, info, ucontext_raw,
                           mod_loader::t_loading_mod_name);
            siglongjmp(mod_loader::s_mod_jmpbuf, sig);
        }

        // ── GLOBAL LAST-RESORT: instruction skip anywhere in game code ──────
        // No guard armed on this thread. If global mode allows it, neutralize
        // the faulting load/store in place and resume: this covers EVERY
        // memory region the APK maps, not just code the modloader calls.
        do
        {
            GlobalMode gm = global_mode();
            if (gm == GlobalMode::Off)
                break;
            if (sig != SIGSEGV && sig != SIGBUS)
                break;
            if (!ucontext_raw)
                break;
            if (gm == GlobalMode::NullOnly && fault >= 0x100000)
                break; // not the NULL+field-offset family
            ucontext_t *uc = static_cast<ucontext_t *>(ucontext_raw);
            uintptr_t pc = arch::uc_pc(uc);
            if (pc >= s_self_base && pc < s_self_end)
                break; // our own bugs stay loud
            uint32_t insn = 0;
            if (!sig_safe_read(pc, &insn, 4))
                break; // wild jump — PC itself unreadable
            if (!storm_brake_ok())
                break;
            // Dry-run decode first: a refused instruction stays fatal and is
            // never filed as "recovered"; a accepted one is filed with the
            // PRE-skip register state, then the context is patched.
            if (!skip_faulting_insn(uc, insn, /*apply=*/false))
                break;
            file_recovered(Kind::GlobalSkip, sig, info, ucontext_raw, nullptr, insn);
            skip_faulting_insn(uc, insn, /*apply=*/true);
            return true; // handler returns → thread resumes at pc+4
        } while (false);

        return false; // not recoverable — fatal handling proceeds
    }

    // ═══ Boot init ════════════════════════════════════════════════════════════
    void init()
    {
        if (s_mem_fd < 0)
            s_mem_fd = open("/proc/self/mem", O_RDONLY | O_CLOEXEC);
        dl_iterate_phdr(find_self_cb, nullptr);
        static const char *gm_names[] = {"off", "null-only", "all"};
        logger::log_info("CGUARD",
                         "Crash guard v2 ready (enabled=%s, global=%s, ring=%d, mem_fd=%d, "
                         "self=0x%lx-0x%lx) — suppressed crashes are filed to %s",
                         enabled() ? "true" : "false",
                         gm_names[static_cast<int>(global_mode())],
                         kRingSize, s_mem_fd,
                         (unsigned long)s_self_base, (unsigned long)s_self_end,
                         paths::recovered_log().c_str());
    }

    // ═══ Drain — normal-context reporter ══════════════════════════════════════
    static std::mutex s_drain_mutex;

    // Per-crash-site (keyed by PC) rate limiting.
    static constexpr uint64_t kFullReportsPerSite = 3;   // full record for first N
    static constexpr uint64_t kSummaryEvery = 200;       // then 1 line per N more
    static constexpr long kLogMaxBytes = 2 * 1024 * 1024;

    struct SiteStats
    {
        uint64_t count = 0;
    };
    static std::map<uintptr_t, SiteStats> s_sites;         // drain-thread only (mutex)
    static std::atomic<uint64_t> s_suppressed_log{0};
    static std::string s_last_summary;                     // guarded by s_drain_mutex

    // ── Auto-quarantine ──────────────────────────────────────────────────────
    // When recovered crashes keep being attributed to ONE mod, revert what that
    // mod changed (unload_mod: releases its hooks and rewrites the original
    // bytes of its code patches) and post a notification. The mod is NOT
    // persistently disabled — it stays enabled and loads again next boot; only
    // its live modifications are backed out of the running game.
    //   - threshold path: >= s_quarantine_threshold recovered crashes
    //   - critical path : immediate, when the crash PC executes INSIDE bytes
    //     the mod itself wrote (its byte patch or its hook's entry patch) —
    //     that is direct evidence the mod's own code is what faulted.
    static std::atomic<int> s_quarantine_threshold{20};    // 0 = never quarantine
    static std::map<std::string, uint64_t> s_mod_faults;   // drain-thread only
    static std::map<std::string, bool> s_quarantined;      // already reverted

    void set_quarantine_threshold(int n)
    {
        s_quarantine_threshold.store(n, std::memory_order_relaxed);
    }

    static void quarantine_mod(const std::string &mod, uint64_t count, bool critical,
                               const char *evidence, FILE *f)
    {
        s_quarantined[mod] = true;
        logger::log_error("CGUARD",
                          "QUARANTINE: mod '%s' implicated in %llu recovered crash(es)%s — "
                          "reverting its hooks and code patches (mod stays enabled; "
                          "it will load again next boot). Evidence: %s",
                          mod.c_str(), (unsigned long long)count,
                          critical ? " [CRITICAL: fault inside bytes the mod wrote]" : "",
                          evidence);
        if (f)
            fprintf(f, "!! QUARANTINE mod '%s' after %llu crash(es)%s — patches reverted. %s\n",
                    mod.c_str(), (unsigned long long)count,
                    critical ? " (critical)" : "", evidence);
        // unload_mod MUST run on the game thread (it tears down hooks and
        // rewrites patched code the game thread executes).
        std::string m = mod;
        pe_hook::queue_game_thread([m]() {
            bool ok = mod_loader::unload_mod(m);
            logger::log_warn("CGUARD", "quarantine unload of '%s': %s",
                             m.c_str(), ok ? "done (patches reverted)" : "mod not loaded");
        });
        char body[192];
        snprintf(body, sizeof(body),
                 "Mod '%s' caused %llu crash(es)%s. Its patches were reverted — game kept alive. "
                 "See modloader_recovered.log.",
                 mod.c_str(), (unsigned long long)count, critical ? " (critical)" : "");
        notification::post("Crash Guard: mod quarantined", body,
                           notification::NOTIF_ID_CRASH);
    }

    static void format_addr(char *buf, size_t n, uintptr_t addr)
    {
        Dl_info dl;
        if (addr && dladdr(reinterpret_cast<void *>(addr), &dl) && dl.dli_fname)
        {
            const char *short_name = strrchr(dl.dli_fname, '/');
            short_name = short_name ? short_name + 1 : dl.dli_fname;
            uintptr_t off = addr - reinterpret_cast<uintptr_t>(dl.dli_fbase);
            if (dl.dli_sname)
                snprintf(buf, n, "%s+0x%lx (%s)", short_name, (unsigned long)off, dl.dli_sname);
            else
                snprintf(buf, n, "%s+0x%lx", short_name, (unsigned long)off);
        }
        else
        {
            snprintf(buf, n, "0x%lx (unmapped?)", (unsigned long)addr);
        }
    }

    static const char *sig_name(int sig)
    {
        switch (sig)
        {
        case SIGSEGV: return "SIGSEGV";
        case SIGABRT: return "SIGABRT";
        case SIGBUS:  return "SIGBUS";
        case SIGFPE:  return "SIGFPE";
        default:      return "SIG?";
        }
    }

    void drain()
    {
        std::lock_guard<std::mutex> lk(s_drain_mutex);

        // Collect ready records first (cheap), free their slots immediately so
        // a storm during our file I/O still has somewhere to land.
        static Payload batch[kRingSize]; // drain is serialized by s_drain_mutex
        int n = 0;
        for (int i = 0; i < kRingSize; i++)
        {
            Record &r = s_ring[i];
            if (r.state.load(std::memory_order_acquire) == 2)
            {
                batch[n++] = r.p;
                r.state.store(0, std::memory_order_release);
            }
        }
        if (n == 0)
            return;

        // Oldest first.
        for (int i = 1; i < n; i++)
            for (int j = i; j > 0 && batch[j].seq < batch[j - 1].seq; j--)
                std::swap(batch[j], batch[j - 1]);

        // Cap the recovered log: rotate once past the limit, never grow unbounded.
        std::string path = paths::recovered_log();
        struct stat st;
        if (stat(path.c_str(), &st) == 0 && st.st_size > kLogMaxBytes)
        {
            std::string old = path + ".1";
            remove(old.c_str());
            rename(path.c_str(), old.c_str());
        }

        FILE *f = fopen(path.c_str(), "a");

        for (int i = 0; i < n; i++)
        {
            Payload &r = batch[i];
            uint64_t site_count = ++s_sites[r.pc].count;

            char pc_s[192];
            format_addr(pc_s, sizeof(pc_s), r.pc);

            // ── Culprit attribution ──────────────────────────────────────────
            // 1) context captured at fault time (which hook / mod / UFunction
            //    was executing); 2) for global skips, whether the PC sits
            //    at/near a Dobby hook or a mod's byte patch. Also resolves the
            //    owning MOD (for quarantine) and whether the crash is CRITICAL
            //    (PC executing inside bytes the mod itself wrote).
            char cause[256];
            cause[0] = '\0';
            std::string culprit_mod;
            bool critical = false;
            if (r.ctx[0])
                snprintf(cause, sizeof(cause), "%s", r.ctx);
            {
                Kind k = static_cast<Kind>(r.kind);
                char modbuf[64];
                if ((k == Kind::HookOriginal || k == Kind::HookInstall) && r.ctx[0] &&
                    native_hooks::hook_owner_mod_by_name(r.ctx, modbuf, sizeof(modbuf)))
                    culprit_mod = modbuf;

                char site[160];
                if (native_hooks::describe_site(r.pc, site, sizeof(site)))
                {
                    size_t len = strlen(cause);
                    snprintf(cause + len, sizeof(cause) - len, "%s%s",
                             len ? "; " : "", site);
                    // "inside Dobby entry patch" = executing bytes we wrote
                    if (strstr(site, "inside Dobby entry patch"))
                        critical = true;
                    if (culprit_mod.empty() &&
                        native_hooks::site_owner_mod(r.pc, modbuf, sizeof(modbuf)))
                        culprit_mod = modbuf;
                }
                std::string patch_mod;
                uintptr_t patch_addr = 0;
                size_t patch_size = 0;
                if (mod_tracker::find_patch_near(r.pc, patch_mod, patch_addr, patch_size))
                {
                    size_t len = strlen(cause);
                    snprintf(cause + len, sizeof(cause) - len,
                             "%spc within 0x%lx of byte patch by mod '%s' @0x%lx (%zu bytes)",
                             len ? "; " : "",
                             (unsigned long)(r.pc - patch_addr), patch_mod.c_str(),
                             (unsigned long)patch_addr, patch_size);
                    if (culprit_mod.empty())
                        culprit_mod = patch_mod;
                    // PC INSIDE the patched byte range = the mod's own bytes fault
                    if (r.pc >= patch_addr && r.pc < patch_addr + patch_size)
                        critical = true;
                }
                // A crash during a mod's main.lua is already attributed by name.
                if (culprit_mod.empty() && k == Kind::ModLoad && r.ctx[0])
                    culprit_mod = r.ctx;
            }

            char summary[512];
            snprintf(summary, sizeof(summary),
                     "#%llu %s fault=0x%lx pc=%s kind=%s thread='%s'%s%s (site hit %llu)",
                     (unsigned long long)r.seq, sig_name(r.sig), (unsigned long)r.fault,
                     pc_s, kind_name(static_cast<Kind>(r.kind)), r.thread_name,
                     cause[0] ? " cause: " : "", cause,
                     (unsigned long long)site_count);
            s_last_summary = summary;

            // Main log: one line for a NEW site only — never floods.
            if (site_count == 1)
                logger::log_warn("CGUARD", "recovered crash: %s — details in %s",
                                 summary, path.c_str());

            // ── Quarantine check ─────────────────────────────────────────────
            // Threshold of attributed crashes, or immediately on a critical one
            // (fault inside bytes the mod wrote). Reverts the mod's patches and
            // hooks; does NOT persistently disable it.
            if (!culprit_mod.empty())
            {
                uint64_t mod_count = ++s_mod_faults[culprit_mod];
                int threshold = s_quarantine_threshold.load(std::memory_order_relaxed);
                if (threshold > 0 && !s_quarantined[culprit_mod] &&
                    (critical || mod_count >= static_cast<uint64_t>(threshold)))
                {
                    quarantine_mod(culprit_mod, mod_count, critical, summary, f);
                }
            }

            if (!f)
                continue;

            if (site_count <= kFullReportsPerSite)
            {
                struct tm tm_info;
                localtime_r(&r.ts.tv_sec, &tm_info);
                char date_buf[32];
                strftime(date_buf, sizeof(date_buf), "%Y-%m-%d %H:%M:%S", &tm_info);

                fprintf(f, "── RECOVERED CRASH #%llu ─ %s.%03ld ─────────────────────────\n",
                        (unsigned long long)r.seq, date_buf, r.ts.tv_nsec / 1000000);
                fprintf(f, "signal : %s (code %d)   guard: %s\n",
                        sig_name(r.sig), r.code, kind_name(static_cast<Kind>(r.kind)));
                fprintf(f, "fault  : 0x%lx\n", (unsigned long)r.fault);
                fprintf(f, "thread : '%s' tid=%d\n", r.thread_name, r.tid);
                if (cause[0])
                    fprintf(f, "cause  : %s\n", cause);
                if (r.insn)
                    fprintf(f, "insn   : 0x%08x (skipped; loads zeroed)\n", r.insn);
                fprintf(f, "pc     : %s\n", pc_s);
                char t[192];
                format_addr(t, sizeof(t), r.lr);
                fprintf(f, "lr     : %s\n", t);
                fprintf(f, "sp=0x%lx fp=0x%lx x0=0x%lx\n",
                        (unsigned long)r.sp, (unsigned long)r.fp, (unsigned long)r.x0);
                for (int k = 0; k < r.bt_n; k++)
                {
                    format_addr(t, sizeof(t), r.bt[k]);
                    fprintf(f, "  bt#%02d %s\n", k, t);
                    Dl_info dl;
                    if (dladdr(reinterpret_cast<void *>(r.bt[k]), &dl) && dl.dli_fname &&
                        strstr(dl.dli_fname, "libmodloader.so"))
                        fprintf(f, "        -> llvm-addr2line -e build/libmodloader.so -f 0x%lx\n",
                                (unsigned long)(r.bt[k] - reinterpret_cast<uintptr_t>(dl.dli_fbase)));
                }
                if (site_count == kFullReportsPerSite)
                    fprintf(f, "(site limit reached — further hits at this pc are counted, "
                               "one summary line per %llu)\n",
                            (unsigned long long)kSummaryEvery);
            }
            else
            {
                s_suppressed_log.fetch_add(1, std::memory_order_relaxed);
                if (site_count % kSummaryEvery == 0)
                    fprintf(f, "%s\n", summary);
            }
        }

        if (f)
        {
            fflush(f);
            fclose(f);
        }
    }

    // ═══ Stats ════════════════════════════════════════════════════════════════
    Stats stats()
    {
        Stats s{};
        s.total = s_total.load(std::memory_order_relaxed);
        for (int i = 0; i < 7; i++)
            s.by_kind[i] = s_by_kind[i].load(std::memory_order_relaxed);
        s.dropped = s_dropped.load(std::memory_order_relaxed);
        s.suppressed_log = s_suppressed_log.load(std::memory_order_relaxed);
        s.storm_tripped = s_storm_tripped.load(std::memory_order_relaxed);
        {
            std::lock_guard<std::mutex> lk(s_drain_mutex);
            s.sites = s_sites.size();
        }
        return s;
    }

    std::string last_summary()
    {
        std::lock_guard<std::mutex> lk(s_drain_mutex);
        return s_last_summary;
    }

} // namespace crash_guard
