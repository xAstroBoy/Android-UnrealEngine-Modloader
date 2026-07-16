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
#include <ucontext.h>
#include <unwind.h>
#include <dlfcn.h>
#include <link.h>
#include <sys/time.h>
#include <time.h>
#include <setjmp.h>

// ═══════════════════════════════════════════════════════════════════════════
// CRASH-HIDING RECOVERY REMOVED (intentionally).
//
// This handler used to consult FIVE siglongjmp "recovery" guards — safe_call
// regions, hook installation, hooked-original calls, ProcessEvent/Call, and mod
// loading. On a fatal signal inside any of them, it jumped back to a checkpoint
// that RESUMED execution while returning a fake default (nil / 0 / skip-the-mod).
// That silently swallowed real SIGSEGV/SIGBUS faults — a dangling-pointer deref
// inside a hooked game function, a UFunction, or a mod became an invisible
// "return nil" instead of a crash, so genuine bugs never surfaced.
//
// ALL FIVE are now GONE. A fatal fault is never resumed: the handler writes a
// crash report (for faults inside libmodloader.so) and chains to the platform
// handler so debuggerd produces a real tombstone.
//
// The one legitimate use of the old recovery — safe_call::probe_read /
// safe_memcpy testing unknown pointers during boot-time offset discovery — was
// FIXED at the root instead of recovered: those primitives now test readability
// through the kernel (pread on /proc/self/mem, which returns an error rather
// than raising SIGSEGV), so the scanner probes garbage addresses without ever
// faulting. A readability test that crashes on unreadable memory was itself the
// bug. The inert scaffolding still in safe_call.cpp / native_hooks.cpp /
// lua_uobject.cpp / mod_loader.cpp (sigsetjmp checkpoints never jumped to) is
// harmless; its try/catch still guards C++ exceptions, a separate category from
// these hardware faults. Crashes are meant to be seen and fixed, not hidden.
// ═══════════════════════════════════════════════════════════════════════════

namespace crash_handler
{

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

        // NOTE: ALL five siglongjmp recovery guards that used to sit here —
        // safe_call regions, hook install, hooked-original call, ProcessEvent/
        // Call, and mod load — have been REMOVED (see the file-top banner). No
        // fatal fault is resumed anymore. Memory probing that used to fault-and-
        // recover (safe_call::probe_read / safe_memcpy) is now non-faulting
        // (/proc/self/mem), so the boot-time offset scanner needs no recovery.
        // Everything else that faults is a real bug: we report it (if it's ours)
        // and let it become a tombstone so it can be found and fixed.

        // Determine if crash PC is inside libmodloader.so or game code.
        ucontext_t *uc = static_cast<ucontext_t *>(ucontext_raw);
        bool is_modloader_crash = false;
        if (uc)
        {
            uintptr_t pc = static_cast<uintptr_t>(uc->uc_mcontext.pc);
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
            // Game-side crash — skip crash report entirely (fprintf uses malloc,
            // which is NOT async-signal-safe and will corrupt/deadlock the heap).
            // Chain directly to the original handler.
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
                    uintptr_t crash_pc = static_cast<uintptr_t>(uc->uc_mcontext.pc);
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
                    uintptr_t pc = static_cast<uintptr_t>(uc_reg->uc_mcontext.pc);
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
                    for (int i = 0; i < 31; i++)
                    {
                        uintptr_t reg_val = static_cast<uintptr_t>(uc_reg->uc_mcontext.regs[i]);
                        fprintf(f, "X%-2d = 0x%016llx", i,
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
                    fprintf(f, "SP  = 0x%016llx\n", (unsigned long long)uc_reg->uc_mcontext.sp);
                    fprintf(f, "PC  = 0x%016llx\n", (unsigned long long)uc_reg->uc_mcontext.pc);
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
        // Install a big alt-stack on THIS thread up front so the handler survives
        // stack overflow/smash from the very first guarded call.
        ensure_thread_sigaltstack();

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
