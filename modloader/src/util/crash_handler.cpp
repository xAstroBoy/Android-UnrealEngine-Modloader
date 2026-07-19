// modloader/src/util/crash_handler.cpp
// Signal handler for SIGSEGV, SIGABRT, SIGBUS, SIGFPE
// Writes modloader_crash.log with:
//   - fault address and signal info
//   - register dump with addr2line hints
//   - native backtrace (via _Unwind_Backtrace or android backtrace)
//   - library map for crash address resolution
//   - last 500 lines of UEModLoader.log
// Posts a notification before dying

#include "modloader/crash_handler.h"
#include "modloader/crash_guard.h"
#include "modloader/arch.h"
#include "modloader/memtrace.h"
#include "modloader/safe_call.h"
#include "modloader/logger.h"
#include "modloader/paths.h"
#include "modloader/notification.h"
#include <signal.h>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <cstdint>
#include <unistd.h>
#include <fcntl.h>
#include <ucontext.h>
#include <unwind.h>
#include <dlfcn.h>
#include <link.h>
#include <sys/time.h>
#include <time.h>
#include <setjmp.h>

// ═══════════════════════════════════════════════════════════════════════════
// CRASH GUARD v2 — recovery RESTORED, with the v1 objections fixed.
//
// History: v1 consulted five siglongjmp guards (safe_call, hook install,
// hooked-original calls, ProcessEvent/Call, mod load) and silently resumed any
// fault inside them. It was removed because it HID crashes (a dangling deref
// became an invisible "return nil") and its logging could flood the log. But
// removing it meant this RE4 port — whose engine derefs NULL in thousands of
// call sites (see the engine null audit) — died to faults the guards existed
// to absorb.
//
// v2 (crash_guard.cpp) restores the recovery under a different contract:
//   - crash_guard::try_recover() runs FIRST for every fatal signal. If a
//     guard region is armed on the faulting thread AND the guard is enabled,
//     the crash is FILED (signal, fault, pc, registers, backtrace → ring
//     buffer → modloader_recovered.log, rate-limited per site) and THEN
//     suppressed via siglongjmp. Crashes stay visible; the game stays alive.
//   - it is toggleable at runtime (config "crash_guard_enabled", Lua
//     SetCrashGuardEnabled). Disabled = every fault is fatal, as in the
//     removed-recovery era, for bug-hunting with real tombstones.
//   - unguarded faults are UNCHANGED: report below (for faults inside
//     libmodloader.so) + chain to the platform handler → real tombstone.
//
// safe_call::probe_read / safe_memcpy stay non-faulting (pread on
// /proc/self/mem) — boot-time offset scans never enter the signal path.
// ═══════════════════════════════════════════════════════════════════════════

namespace crash_handler
{

    // ── MASTER TOGGLE ───────────────────────────────────────────────────────
    // TRUE = the handler is installed in REPORT-ONLY mode: it captures every
    // fault async-signal-safely to modloader_crash.log (signal, fault addr, PC,
    // registers, backtrace — works even with a corrupt game heap) and then
    // CHAINS to the old handler / debuggerd for a real tombstone. It does NOT
    // recover — recovery is the crash GUARD, which is a SEPARATE switch and
    // stays OFF (init.cpp) so faults remain fatal. This is what "fix the crash
    // handler" means: we finally SEE the fault instead of a silent death (with
    // the handler off, the game's own Oculus/UE4 handler ate the fault and
    // exited with nothing). Set false only to hand faults straight to debuggerd
    // with no modloader report at all.
    static bool s_handler_enabled = true;
    void set_enabled(bool e) { s_handler_enabled = e; }
    bool enabled() { return s_handler_enabled; }

    // Previous handlers, captured when we install()/reinstall() on top. A fatal
    // fault chains to these (the VR runtime / debuggerd) so a real tombstone is
    // produced after we write our report.
    static struct sigaction s_old_sigsegv;
    static struct sigaction s_old_sigabrt;
    static struct sigaction s_old_sigbus;
    static struct sigaction s_old_sigfpe;

    // Boot grace period — skip SIGABRT logging during first 5 seconds.
    // Frida's gadget (libfrda.so) calls abort() ~1.4s after boot which
    // is expected/handled. After boot completes, we catch everything.
    static volatile bool s_boot_complete = false;

    // Track our own library's address range so we can distinguish
    // modloader crashes from game crashes
    static uintptr_t s_modloader_base = 0;
    static uintptr_t s_modloader_end = 0;

    static int find_modloader_cb(struct dl_phdr_info *info, size_t, void *)
    {
        if (info->dlpi_name && strstr(info->dlpi_name, "libmodloader.so"))
        {
            uintptr_t lo = UINTPTR_MAX, hi = 0;
            for (int i = 0; i < info->dlpi_phnum; i++)
            {
                if (info->dlpi_phdr[i].p_type == PT_LOAD)
                {
                    uintptr_t seg_lo = info->dlpi_addr + info->dlpi_phdr[i].p_vaddr;
                    uintptr_t seg_hi = seg_lo + info->dlpi_phdr[i].p_memsz;
                    if (seg_lo < lo)
                        lo = seg_lo;
                    if (seg_hi > hi)
                        hi = seg_hi;
                }
            }
            s_modloader_base = lo;
            s_modloader_end = hi;
            return 1;
        }
        return 0;
    }

    static bool pc_in_modloader(uintptr_t pc)
    {
        if (s_modloader_base == 0)
            return false;
        return pc >= s_modloader_base && pc < s_modloader_end;
    }

    struct BacktraceState
    {
        void **frames;
        int max_depth;
        int count;
    };

    static _Unwind_Reason_Code unwind_callback(struct _Unwind_Context *context, void *arg)
    {
        auto *state = static_cast<BacktraceState *>(arg);
        uintptr_t pc = _Unwind_GetIP(context);
        if (pc != 0)
        {
            if (state->count < state->max_depth)
            {
                state->frames[state->count] = reinterpret_cast<void *>(pc);
                state->count++;
            }
            else
            {
                return _URC_END_OF_STACK;
            }
        }
        return _URC_NO_REASON;
    }

    static int capture_backtrace(void **frames, int max_depth)
    {
        BacktraceState state;
        state.frames = frames;
        state.max_depth = max_depth;
        state.count = 0;
        _Unwind_Backtrace(unwind_callback, &state);
        return state.count;
    }

    static const char *signal_name(int sig)
    {
        switch (sig)
        {
        case SIGSEGV:
            return "SIGSEGV";
        case SIGABRT:
            return "SIGABRT";
        case SIGBUS:
            return "SIGBUS";
        case SIGFPE:
            return "SIGFPE";
        default:
            return "UNKNOWN";
        }
    }

    static const char *signal_code_name(int sig, int code)
    {
        if (sig == SIGSEGV)
        {
            switch (code)
            {
            case SEGV_MAPERR:
                return "SEGV_MAPERR (address not mapped)";
            case SEGV_ACCERR:
                return "SEGV_ACCERR (access permission fault)";
            default:
                return "unknown code";
            }
        }
        if (sig == SIGBUS)
        {
            switch (code)
            {
            case BUS_ADRALN:
                return "BUS_ADRALN (alignment fault)";
            case BUS_ADRERR:
                return "BUS_ADRERR (nonexistent physical address)";
            case BUS_OBJERR:
                return "BUS_OBJERR (object-specific HW error)";
            default:
                return "unknown code";
            }
        }
        return "unknown code";
    }

    // ── ASYNC-SIGNAL-SAFE crash dump ─────────────────────────────────────────
    // Writes signal + fault addr + PC (lib+offset) + registers + backtrace using
    // ONLY open/write/snprintf-to-a-stack-buffer — NO malloc, NO stdio, NO
    // heap. Safe even when the GAME'S heap is corrupt (the exact case the old
    // fprintf report could not handle, so it skipped game crashes entirely and
    // we saw nothing). This is what captures the enemy/null-deref fault so it can
    // be fixed at the source. dladdr takes only the linker lock; capture_backtrace
    // walks via the pre-opened /proc/self/mem (crash_guard::init). Recovery is
    // independent and stays OFF — this only REPORTS, it never resumes.
    static void async_safe_dump(int sig, siginfo_t *info, ucontext_t *uc)
    {
        int fd = open(paths::crash_log().c_str(), O_WRONLY | O_CREAT | O_TRUNC, 0666);
        if (fd < 0) return;
        char b[1536];
        int n;

        // ── PHASE 1: RAW values only — NO dladdr, NO backtrace ───────────────
        // Front-loaded and fsync'd FIRST so the PC + registers ALWAYS land, even
        // if the fancy annotation below re-faults (an earlier version died in
        // dladdr/unwind and lost the PC). This block calls nothing that can page
        // fault: just field reads + snprintf + write.
        uintptr_t pc = uc ? arch::uc_pc(uc) : 0;
        uintptr_t lr = uc ? arch::uc_lr(uc) : 0;
        uintptr_t sp = uc ? arch::uc_sp(uc) : 0;
        uintptr_t base = s_modloader_base, end = s_modloader_end;
        bool pc_in_mod = (pc >= base && pc < end);
        n = snprintf(b, sizeof(b),
                     "=== MODLOADER CRASH (async-safe, report-only) ===\n"
                     "Signal: %s (%d)  code: %d  fault_addr: 0x%lx\n"
                     "PC = 0x%016lx  %s%s0x%lx\n"
                     "LR = 0x%016lx\nSP = 0x%016lx\n"
                     "libmodloader.so: 0x%lx - 0x%lx\n",
                     signal_name(sig), sig, info ? info->si_code : 0,
                     (unsigned long)(info ? (uintptr_t)info->si_addr : 0),
                     (unsigned long)pc,
                     pc_in_mod ? "libmodloader.so+" : "(game/other) ",
                     pc_in_mod ? "0x" : "",
                     (unsigned long)(pc_in_mod ? pc - base : pc),
                     (unsigned long)lr, (unsigned long)sp,
                     (unsigned long)base, (unsigned long)end);
        write(fd, b, n);
        if (uc)
            for (int i = 0; i < arch::UC_NGREG; i++)
            {
                n = snprintf(b, sizeof(b), "%c%-2d = 0x%016llx\n",
                             arch::UC_NGREG == 16 ? 'R' : 'X', i,
                             (unsigned long long)arch::uc_reg(uc, i));
                write(fd, b, n);
            }
        fsync(fd);   // PC + registers are now durable regardless of what follows

        // ── PHASE 2: annotate PC's library (dladdr — linker lock only) ───────
        if (uc && dladdr)
        {
            Dl_info dl;
            if (dladdr((void *)pc, &dl) && dl.dli_fname)
            {
                const char *ls = strrchr(dl.dli_fname, '/');
                ls = ls ? ls + 1 : dl.dli_fname;
                n = snprintf(b, sizeof(b), "PC library: %s + 0x%lx%s%s\n", ls,
                             (unsigned long)(pc - (uintptr_t)dl.dli_fbase),
                             dl.dli_sname ? "  near: " : "",
                             dl.dli_sname ? dl.dli_sname : "");
                write(fd, b, n);
            }
            fsync(fd);
        }

        // ── PHASE 2.5: STACK RETURN-ADDRESS SCAN ─────────────────────────────
        // The saved {x29,x30} pair was smashed (fp=0x33, lr=garbage) so the
        // unwinder is blind. Scan raw stack words and print any that point into
        // libUE4's executable range — that is the real call chain leading to the
        // corruption site (the caller that returned into garbage is the first
        // libUE4 return address here). Reading the live stack is safe (mapped);
        // bounded to 4 KB. dladdr under the linker lock is acceptable while dying.
        if (sp)
        {
            write(fd, "=== STACK RETURN-ADDR SCAN (SP .. SP+4KB) ===\n", 46);
            const uintptr_t *stk = (const uintptr_t *)sp;
            for (int i = 0; i < 512; i++)
            {
                uintptr_t v = stk[i];
                if (v < 0x10000) continue;
                Dl_info d;
                if (dladdr((void *)v, &d) && d.dli_fname)
                {
                    const char *ls = strrchr(d.dli_fname, '/');
                    ls = ls ? ls + 1 : d.dli_fname;
                    if (strstr(ls, "libUE4.so") || strstr(ls, "libmodloader.so"))
                    {
                        n = snprintf(b, sizeof(b), "  SP+0x%04x = %s+0x%lx%s%s\n",
                                     i * 8, ls, (unsigned long)(v - (uintptr_t)d.dli_fbase),
                                     d.dli_sname ? "  " : "", d.dli_sname ? d.dli_sname : "");
                        write(fd, b, n);
                    }
                }
            }
            fsync(fd);
        }

        // ── PHASE 3: backtrace (unwind CAN fault on bad frames) — LAST ───────
        write(fd, "=== BACKTRACE ===\n", 18);
        void *frames[64];
        int depth = capture_backtrace(frames, 64);
        for (int i = 0; i < depth; i++)
        {
            Dl_info d;
            if (dladdr(frames[i], &d) && d.dli_fname)
            {
                const char *ls = strrchr(d.dli_fname, '/');
                ls = ls ? ls + 1 : d.dli_fname;
                n = snprintf(b, sizeof(b), "#%02d  0x%lx  %s + 0x%lx  (%s)\n", i,
                             (unsigned long)(uintptr_t)frames[i],
                             d.dli_sname ? d.dli_sname : "?",
                             (unsigned long)((uintptr_t)frames[i] - (uintptr_t)d.dli_fbase), ls);
            }
            else
            {
                n = snprintf(b, sizeof(b), "#%02d  0x%lx  ?\n", i, (unsigned long)(uintptr_t)frames[i]);
            }
            write(fd, b, n);
        }
        write(fd, "=== END (chaining to debuggerd) ===\n", 36);
        fsync(fd);
        close(fd);
    }

    static void crash_handler_fn(int sig, siginfo_t *info, void *ucontext_raw)
    {
        // ── SIGABRT BOOT GRACE PERIOD ────────────────────────────────────────
        // During the first ~5s, Frida's gadget calls abort() which is expected
        // (not a real bug). Forward it to the old handler. This is NOT crash
        // suppression — it's letting a known-benign startup abort proceed.
        if (sig == SIGABRT && !s_boot_complete)
        {
            if (s_old_sigabrt.sa_sigaction)
                s_old_sigabrt.sa_sigaction(sig, info, ucontext_raw);
            else if (s_old_sigabrt.sa_handler != SIG_DFL && s_old_sigabrt.sa_handler != SIG_IGN)
                s_old_sigabrt.sa_handler(sig);
            else
            {
                signal(sig, SIG_DFL);
                raise(sig);
            }
            return;
        }

        // ── CRASH GUARD v2 RECOVERY DISPATCH ────────────────────────────────
        // If a guard region (hook install / hooked original / safe_call /
        // ProcessEvent call / mod load) is armed on THIS thread and the guard
        // is enabled, this files the crash into the recovered-crash ring and
        // siglongjmps back to the checkpoint — it does not return in that
        // case. If NO guard is armed but global instruction-skip mode covers
        // the fault, the ucontext is patched (fault neutralized, pc advanced)
        // and try_recover returns true — we return from the handler and the
        // faulting thread resumes. Everything below only runs for genuinely
        // fatal faults, or when the guard is toggled off.
        if (crash_guard::try_recover(sig, info, ucontext_raw))
            return;

        // ── RE-ENTRANCY GUARD ───────────────────────────────────────────────
        // If we fault AGAIN while already writing a crash report on this thread
        // (e.g. the unwind/dladdr in async_safe_dump hit bad memory), do NOT run
        // the whole report path again — that risks the malloc-based fprintf on a
        // corrupt heap and an infinite fault loop. Restore the default action and
        // re-raise so debuggerd takes it cleanly. The first pass already fsync'd
        // the PC + registers to modloader_crash.log.
        static thread_local int t_in_handler = 0;
        if (t_in_handler)
        {
            signal(sig, SIG_DFL);
            raise(sig);
            return;
        }
        t_in_handler = 1;

        // ── LAST-GASP MEMORY-TRACE FLUSH ────────────────────────────────────
        // The fault is fatal. Before we die, flush whatever the hardware
        // watchpoints still have in their perf rings to memtrace_live.log —
        // async-signal-safe (raw reads + write() to a pre-opened fd). This is
        // the crash-point evidence that used to vanish with the process.
        memtrace::crash_drain(sig);

        // Determine if crash PC is inside libmodloader.so or game code.
        ucontext_t *uc = static_cast<ucontext_t *>(ucontext_raw);
        bool is_modloader_crash = false;
        if (uc)
        {
            uintptr_t pc = arch::uc_pc(uc);
            is_modloader_crash = pc_in_modloader(pc);
        }

        // For game/external crashes: DON'T write a crash report.
        // fprintf/fopen use malloc internally, which is NOT async-signal-safe.
        // If the game's heap is corrupted (common for SIGSEGV in renderer/allocator),
        // calling malloc from the signal handler will deadlock or double-corrupt,
        // killing the process instead of letting the game's own handler deal with it.
        // We only write full reports for crashes inside libmodloader.so where we
        // control the heap state.
        if (!is_modloader_crash)
        {
            // Game-side crash. The game heap may be corrupt so we must NOT touch
            // malloc/stdio — but we STILL capture the fault, async-signal-safely,
            // so the enemy/null-deref bug is diagnosable (this is exactly what the
            // old "skip and chain" left us blind to). Then chain to debuggerd for
            // a full tombstone. Recovery is off → the crash stays fatal.
            async_safe_dump(sig, info, uc);
            goto chain_to_old_handler;
        }

        // Write full crash report ONLY for libmodloader.so crashes (safe — we control our heap)
        {
            FILE *f = fopen(paths::crash_log().c_str(), "w");
            if (f)
            {
                // Timestamp
                struct timeval tv;
                gettimeofday(&tv, nullptr);
                struct tm tm_info;
                localtime_r(&tv.tv_sec, &tm_info);
                char date_buf[64];
                strftime(date_buf, sizeof(date_buf), "%Y-%m-%d %H:%M:%S", &tm_info);

                fprintf(f, "=== MODLOADER CRASH REPORT ===\n");
                fprintf(f, "Time: %s.%03ld\n", date_buf, tv.tv_usec / 1000);
                fprintf(f, "Signal: %s (%d)\n", signal_name(sig), sig);
                fprintf(f, "Code: %s (%d)\n", signal_code_name(sig, info->si_code), info->si_code);
                fprintf(f, "Fault address: %p\n", info->si_addr);
                fprintf(f, "Crash origin: %s\n", is_modloader_crash ? "libmodloader.so (OUR CODE)" : "GAME / EXTERNAL (possibly triggered by our hooks)");
                // Resolve crashing library via dladdr
                if (uc)
                {
                    uintptr_t crash_pc = arch::uc_pc(uc);
                    Dl_info crash_dl;
                    if (dladdr(reinterpret_cast<void *>(crash_pc), &crash_dl) && crash_dl.dli_fname)
                    {
                        fprintf(f, "Crash library: %s\n", crash_dl.dli_fname);
                        fprintf(f, "Crash offset:  0x%lX\n",
                                (unsigned long)(crash_pc - reinterpret_cast<uintptr_t>(crash_dl.dli_fbase)));
                    }
                }
                fprintf(f, "Crash log path: %s\n", paths::crash_log().c_str());
                fprintf(f, "\n");
                fprintf(f, "=== LIBRARY BASE ADDRESSES ===\n");
                fprintf(f, "libmodloader.so base: 0x%lX\n", (unsigned long)s_modloader_base);
                fprintf(f, "libmodloader.so end:  0x%lX\n", (unsigned long)s_modloader_end);
                fprintf(f, "libmodloader.so size: 0x%lX\n",
                        (unsigned long)(s_modloader_end - s_modloader_base));

                // Register dump (ARM64)
                ucontext_t *uc_reg = static_cast<ucontext_t *>(ucontext_raw);
                if (uc_reg)
                {
                    uintptr_t pc = arch::uc_pc(uc_reg);
                    uintptr_t pc_offset = (pc >= s_modloader_base) ? (pc - s_modloader_base) : 0;

                    fprintf(f, "\n=== CRASH PC ===\n");
                    fprintf(f, "PC  = 0x%016llx\n", (unsigned long long)pc);
                    if (pc_in_modloader(pc))
                    {
                        fprintf(f, "PC offset in libmodloader.so: 0x%lX\n", (unsigned long)pc_offset);
                        fprintf(f, "\n");
                        fprintf(f, "To symbolicate on host PC:\n");
                        fprintf(f, "  llvm-addr2line -e build/libmodloader.so -f 0x%lX\n",
                                (unsigned long)pc_offset);
                        fprintf(f, "  ndk-stack -sym build/ -dump <this_file>\n");
                    }
                    else
                    {
                        // Game crash — show which library and offset
                        Dl_info pc_dl;
                        if (dladdr(reinterpret_cast<void *>(pc), &pc_dl) && pc_dl.dli_fname)
                        {
                            uintptr_t lib_offset = pc - reinterpret_cast<uintptr_t>(pc_dl.dli_fbase);
                            fprintf(f, "PC in %s + 0x%lX\n", pc_dl.dli_fname, (unsigned long)lib_offset);
                            if (pc_dl.dli_sname)
                                fprintf(f, "Near symbol: %s\n", pc_dl.dli_sname);
                        }
                        else
                        {
                            fprintf(f, "PC not in any known library (unmapped?)\n");
                        }
                    }

                    fprintf(f, "\n=== REGISTERS ===\n");
                    for (int i = 0; i < arch::UC_NGREG; i++)
                    {
                        uintptr_t reg_val = arch::uc_reg(uc_reg, i);
                        fprintf(f, "%c%-2d = 0x%016llx", arch::UC_NGREG == 16 ? 'R' : 'X', i,
                                (unsigned long long)reg_val);
                        // Annotate registers pointing into libmodloader.so
                        if (pc_in_modloader(reg_val))
                        {
                            fprintf(f, "  (libmodloader.so+0x%lX)",
                                    (unsigned long)(reg_val - s_modloader_base));
                        }
                        else
                        {
                            Dl_info reg_dl;
                            if (reg_val > 0x10000 && dladdr(reinterpret_cast<void *>(reg_val), &reg_dl) &&
                                reg_dl.dli_fname)
                            {
                                fprintf(f, "  (%s+0x%lX)", reg_dl.dli_fname,
                                        (unsigned long)(reg_val - reinterpret_cast<uintptr_t>(reg_dl.dli_fbase)));
                            }
                        }
                        fprintf(f, "\n");
                    }
                    fprintf(f, "SP  = 0x%016llx\n", (unsigned long long)arch::uc_sp(uc_reg));
                    fprintf(f, "PC  = 0x%016llx\n", (unsigned long long)arch::uc_pc(uc_reg));
                }

                // Backtrace with addr2line hints
                fprintf(f, "\n=== BACKTRACE ===\n");
                fprintf(f, "# addr2line commands for libmodloader.so frames:\n");
                void *frames[64];
                int depth = capture_backtrace(frames, 64);
                for (int i = 0; i < depth; i++)
                {
                    Dl_info dl_info;
                    if (dladdr(frames[i], &dl_info))
                    {
                        uintptr_t offset = reinterpret_cast<uintptr_t>(frames[i]) -
                                           reinterpret_cast<uintptr_t>(dl_info.dli_fbase);
                        const char *lib_short = dl_info.dli_fname;
                        // Extract just filename from path
                        const char *slash = strrchr(lib_short, '/');
                        if (slash)
                            lib_short = slash + 1;

                        fprintf(f, "#%02d  %p  %s + 0x%lx (%s)\n",
                                i, frames[i],
                                dl_info.dli_sname ? dl_info.dli_sname : "???",
                                (unsigned long)offset,
                                lib_short);

                        // If this frame is in libmodloader.so, print addr2line command
                        if (dl_info.dli_fname && strstr(dl_info.dli_fname, "libmodloader.so"))
                        {
                            fprintf(f, "     -> llvm-addr2line -e build/libmodloader.so -f 0x%lX\n",
                                    (unsigned long)offset);
                        }
                    }
                    else
                    {
                        fprintf(f, "#%02d  %p  ???\n", i, frames[i]);
                    }
                }

                // Crash-guard statistics (atomics only — async-signal-safe reads)
                fprintf(f, "\n=== CRASH GUARD ===\n");
                fprintf(f, "Enabled: %s\n", crash_guard::enabled() ? "yes" : "no");
                fprintf(f, "Crashes recovered before this fatal one: %llu "
                           "(see modloader_recovered.log)\n",
                        (unsigned long long)crash_guard::total_recovered());

                // Safe-call statistics
                fprintf(f, "\n=== SAFE-CALL STATS ===\n");
                fprintf(f, "Total crash recoveries: %llu\n",
                        (unsigned long long)safe_call::crash_recovery_count());
                fprintf(f, "Exception recoveries:   %llu\n",
                        (unsigned long long)safe_call::exception_count());
                fprintf(f, "Signal recoveries:      %llu\n",
                        (unsigned long long)safe_call::signal_recovery_count());
                const std::string &last_ctx = safe_call::last_crash_context();
                if (!last_ctx.empty())
                {
                    fprintf(f, "Last crash context:     %s\n", last_ctx.c_str());
                }

                // Append last 500 lines of UEModLoader.log
                fprintf(f, "\n=== LAST 500 LOG LINES ===\n");
                auto tail_text = logger::get_tail(500);
                fprintf(f, "%s", tail_text.c_str());

                fprintf(f, "\n=== END CRASH REPORT ===\n");
                fprintf(f, "Crash log location: %s\n", paths::crash_log().c_str());
                fflush(f);
                fclose(f);
            }

            // Post crash notification (best effort — may fail in signal context)
            notification::post_crash();
        } // end crash-report scope

    chain_to_old_handler:
        // Re-raise with original handler
        struct sigaction *old_action = nullptr;
        switch (sig)
        {
        case SIGSEGV:
            old_action = &s_old_sigsegv;
            break;
        case SIGABRT:
            old_action = &s_old_sigabrt;
            break;
        case SIGBUS:
            old_action = &s_old_sigbus;
            break;
        case SIGFPE:
            old_action = &s_old_sigfpe;
            break;
        }

        if (old_action && old_action->sa_sigaction)
        {
            old_action->sa_sigaction(sig, info, ucontext_raw);
        }
        else if (old_action && old_action->sa_handler != SIG_DFL && old_action->sa_handler != SIG_IGN)
        {
            old_action->sa_handler(sig);
        }
        else
        {
            // Restore default and re-raise
            signal(sig, SIG_DFL);
            raise(sig);
        }
    }

    // ── Per-thread alternate signal stack ───────────────────────────────────
    // SA_ONSTACK on the handler is a NO-OP unless an alt-stack is registered on
    // the crashing thread. Without it, a stack OVERFLOW or stack SMASH (return
    // address corrupted, SP into a guard page) makes the handler run on the
    // already-broken stack → instant double-fault → process death, defeating
    // every siglongjmp recovery guard. With a clean alt-stack the handler always
    // runs and can siglongjmp back to the guard checkpoint (whose SP is above the
    // corruption), so even a smashed/overflowed stack is survivable.
    //
    // This MUST be called on every thread that runs guarded game code (esp. the
    // game thread). It's cheap + idempotent per thread.
    static thread_local void *t_altstack_sp = nullptr;

    void ensure_thread_sigaltstack()
    {
        if (t_altstack_sp)
            return;
        const size_t kSize = 512 * 1024; // generous — report path + deep game frames
        // Keep any existing alt-stack that's already large enough (e.g. bionic's).
        stack_t cur;
        memset(&cur, 0, sizeof(cur));
        if (sigaltstack(nullptr, &cur) == 0 && (cur.ss_flags & SS_DISABLE) == 0 &&
            cur.ss_sp != nullptr && cur.ss_size >= kSize)
        {
            t_altstack_sp = cur.ss_sp;
            return;
        }
        void *sp = malloc(kSize);
        if (!sp)
            return;
        stack_t ss;
        memset(&ss, 0, sizeof(ss));
        ss.ss_sp = sp;
        ss.ss_size = kSize;
        ss.ss_flags = 0;
        if (sigaltstack(&ss, nullptr) == 0)
            t_altstack_sp = sp; // leak intentionally — lives for the thread's lifetime
        else
            free(sp);
    }

    void install()
    {
        if (!s_handler_enabled)
        {
            logger::log_warn("CRASH", "Crash handler DISABLED (flag) — faults go straight to debuggerd (real tombstones)");
            return;
        }
        // Install a big alt-stack on THIS thread up front so the handler survives
        // stack overflow/smash from the very first guarded call.
        ensure_thread_sigaltstack();

        // Crash guard v2: pre-open /proc/self/mem for the async-safe backtrace
        // walk and announce the recovered-crash log path.
        crash_guard::init();

        // Find our own library's address range first
        dl_iterate_phdr(find_modloader_cb, nullptr);
        if (s_modloader_base != 0)
        {
            logger::log_info("CRASH", "libmodloader.so range: 0x%lX - 0x%lX",
                             (unsigned long)s_modloader_base, (unsigned long)s_modloader_end);
        }
        else
        {
            logger::log_warn("CRASH", "Could not find libmodloader.so address range — all crashes will be reported");
        }

        struct sigaction sa;
        memset(&sa, 0, sizeof(sa));
        sa.sa_sigaction = crash_handler_fn;
        sa.sa_flags = SA_SIGINFO | SA_ONSTACK;
        sigemptyset(&sa.sa_mask);

        // Handle ALL crash signals including SIGABRT.
        // SIGABRT during boot grace period (first ~5s) is forwarded to old handler
        // to let Frida's gadget abort() work. After boot completes, we catch everything.
        sigaction(SIGSEGV, &sa, &s_old_sigsegv);
        sigaction(SIGABRT, &sa, &s_old_sigabrt);
        sigaction(SIGBUS, &sa, &s_old_sigbus);
        sigaction(SIGFPE, &sa, &s_old_sigfpe);
    }

    void mark_boot_complete()
    {
        s_boot_complete = true;
        logger::log_info("CRASH", "Boot complete — SIGABRT handler now active (all signals caught)");
    }

    void reinstall()
    {
        if (!s_handler_enabled) return;   // flag off — never take over the signal handlers
        // Re-assert our signal handler on top of whatever replaced it.
        // The Oculus VR runtime (libvrapi.so) and Frida both install their own
        // SIGSEGV handlers after our initial install(). This overwrites ours,
        // which means crashes inside hooked functions (where g_in_hook_original_call
        // is set) won't be caught by siglongjmp — they'll kill the process.
        //
        // We save the current handler as our new "old" handler (to chain to),
        // then re-install ours on top.
        struct sigaction sa;
        memset(&sa, 0, sizeof(sa));
        sa.sa_sigaction = crash_handler_fn;
        sa.sa_flags = SA_SIGINFO | SA_ONSTACK;
        sigemptyset(&sa.sa_mask);

        // Peek current handlers first.
        struct sigaction cur_segv, cur_abrt, cur_bus, cur_fpe;
        sigaction(SIGSEGV, nullptr, &cur_segv);
        sigaction(SIGABRT, nullptr, &cur_abrt);
        sigaction(SIGBUS, nullptr, &cur_bus);
        sigaction(SIGFPE, nullptr, &cur_fpe);

        // Did something (VR runtime / Frida) actually replace one of ours since
        // last time? Only then is a re-install meaningful — and only then do we
        // log. This watchdog runs every ~5s; logging unconditionally spammed the
        // log with an identical line forever. Silent when nothing changed.
        bool replaced =
            (cur_segv.sa_sigaction != crash_handler_fn) ||
            (cur_abrt.sa_sigaction != crash_handler_fn && s_boot_complete) ||
            (cur_bus.sa_sigaction != crash_handler_fn) ||
            (cur_fpe.sa_sigaction != crash_handler_fn);

        // Re-install ours.
        sigaction(SIGSEGV, &sa, nullptr);
        sigaction(SIGABRT, &sa, nullptr);
        sigaction(SIGBUS, &sa, nullptr);
        sigaction(SIGFPE, &sa, nullptr);

        // Update chain targets only if previous handlers were not ourselves.
        if (cur_segv.sa_sigaction != crash_handler_fn)
            s_old_sigsegv = cur_segv;
        if (cur_abrt.sa_sigaction != crash_handler_fn)
            s_old_sigabrt = cur_abrt;
        if (cur_bus.sa_sigaction != crash_handler_fn)
            s_old_sigbus = cur_bus;
        if (cur_fpe.sa_sigaction != crash_handler_fn)
            s_old_sigfpe = cur_fpe;

        if (replaced)
            logger::log_info("CRASH", "Signal handler re-asserted (a runtime handler had replaced ours)");
    }

} // namespace crash_handler
