#pragma once
// modloader/include/modloader/crash_guard.h
// ═══════════════════════════════════════════════════════════════════════════
// Crash Guard v2 — recoverable-fault policy + suppressed-crash filing.
//
// This module owns the DECISION ("may this fault be recovered, and where to?")
// and the RECORD ("file every suppressed crash so it is still seen").
// crash_handler.cpp's signal handler calls try_recover() as its first step;
// if a guard region is armed on the faulting thread and the guard is enabled,
// the fault is FILED into a lock-free ring buffer (async-signal-safe) and then
// siglongjmp'd back to the guard checkpoint — the game keeps running and the
// guard site returns a safe default. If no guard is armed (or the guard is
// disabled), try_recover() returns and the fault becomes a real crash report
// + tombstone exactly as before.
//
// v1 was removed because it HID crashes and its logging flooded the log.
// v2 answers both objections instead of deleting the feature:
//   - every suppressed crash is written to modloader_recovered.log with
//     signal, fault address, PC, registers, thread, and a backtrace — crashes
//     are still seen, the game just doesn't die for them;
//   - filing is rate-limited PER CRASH SITE (first few get full reports,
//     after that one summary line per N), and the handler-side capture does
//     no malloc/stdio — it fills a preallocated slot and leaves; a normal
//     thread drains the ring to disk later;
//   - the whole thing is a single runtime toggle (config key
//     "crash_guard_enabled", Lua SetCrashGuardEnabled) so it can be switched
//     off for bug-hunting sessions where tombstones are wanted.
// ═══════════════════════════════════════════════════════════════════════════

#include <cstdint>
#include <string>
#include <signal.h>

namespace crash_guard
{

    // Which guard region a recovered fault was inside. Priority order matters:
    // innermost guards first (a fault during hook install while a mod is
    // loading must unwind to the hook installer, not skip the whole mod).
    enum class Kind : uint8_t
    {
        None = 0,
        SafeCall,      // safe_call::execute() region
        HookOriginal,  // dispatch_full() calling a hooked original (incl. crash guards)
        HookInstall,   // DobbyHook() during install_at()
        UFunctionCall, // Call()/CallBg() ProcessEvent invocation
        ModLoad,       // a mod's main.lua executing during load
        GlobalSkip,    // instruction-skip recovery anywhere in game code
    };

    // ═══ Master toggle ══════════════════════════════════════════════════════
    // Default ON. Reads are a relaxed atomic load — safe from the signal
    // handler. When OFF, try_recover() never jumps and every fault is fatal
    // (report + tombstone), i.e. exactly the behavior before this module.
    bool enabled();
    void set_enabled(bool on);

    // ═══ Global (whole-process) recovery mode ═══════════════════════════════
    // The guard regions above only cover code the modloader itself calls.
    // Global mode covers EVERYTHING ELSE the APK maps: when a SIGSEGV/SIGBUS
    // fires at a PC with no guard armed, the handler decodes the faulting
    // ARM64 instruction and — if it is a load/store (the unguarded-null-deref
    // family this engine is riddled with) — zeroes the destination register(s),
    // applies any writeback, advances PC past it, and resumes the thread.
    // The crash is filed like every other recovery. Faults that cannot be
    // skipped safely (wild jump, undecodable PC, fault inside libmodloader.so
    // itself) stay fatal.
    //
    //   Off      — no global recovery (guard regions only)
    //   NullOnly — only faults at tiny addresses (< 1MB: NULL + field offset)
    //   All      — any unmapped/protected address (maximum survivability)
    //
    // A global storm brake trips if skips exceed ~2000/s — a fault re-executing
    // in a tight loop means skipping is no longer making progress, and a hang
    // is worse than a crash. When tripped, the next fault is fatal.
    enum class GlobalMode : uint8_t { Off = 0, NullOnly = 1, All = 2 };
    GlobalMode global_mode();
    void set_global_mode(GlobalMode m);
    GlobalMode global_mode_from_string(const std::string &s); // "off"/"null"/"all"

    // ═══ Handler-side entry point (ASYNC-SIGNAL-SAFE) ═══════════════════════
    // Called by crash_handler's signal handler for SIGSEGV/SIGBUS/SIGFPE/SIGABRT.
    // Three outcomes:
    //   - guard-region recovery: files the crash and siglongjmps (no return)
    //   - global instruction-skip: files the crash, patches ucontext, returns
    //     TRUE — the caller must simply return from the handler to resume
    //   - not recoverable: returns FALSE — caller proceeds with fatal handling
    bool try_recover(int sig, siginfo_t *info, void *ucontext_raw);

    // ═══ Boot-time init (normal context) ════════════════════════════════════
    // Pre-opens /proc/self/mem (for the async-safe backtrace walk) and zeroes
    // the ring. Call once from crash_handler::install().
    void init();

    // ═══ Drain (normal context) ═════════════════════════════════════════════
    // Writes pending ring records to modloader_recovered.log, symbolicating
    // with dladdr and applying per-site rate limiting. Called by the signal-
    // handler watchdog thread every ~5s and opportunistically after mod-load
    // recovery. Safe to call from any thread; serialized internally.
    void drain();

    // ═══ Stats (normal context; for Lua / console / crash report) ═══════════
    struct Stats
    {
        uint64_t total;          // recoveries since boot (all kinds)
        uint64_t by_kind[7];     // indexed by Kind
        uint64_t dropped;        // ring overflow — counted but not filed
        uint64_t sites;          // distinct crash PCs seen by drain()
        uint64_t suppressed_log; // records counted-only due to per-site limit
        bool storm_tripped;      // global-skip storm brake fired (skips > ~2000/s)
    };
    Stats stats();

    // ═══ Auto-quarantine ════════════════════════════════════════════════════
    // When >= threshold recovered crashes are attributed to one mod — or
    // immediately when a crash PC executes inside bytes that mod wrote
    // (critical) — the guard REVERTS the mod's live modifications (unloads its
    // hooks, restores its byte patches' original bytes) on the game thread and
    // posts a notification. The mod is not persistently disabled. 0 = off.
    void set_quarantine_threshold(int n);

    // One-line human summary of the most recent recovered crash ("" if none).
    std::string last_summary();

    // Async-signal-safe raw counter (readable from the fatal-crash report).
    uint64_t total_recovered();

    const char *kind_name(Kind k);

} // namespace crash_guard
