#pragma once
// modloader/include/modloader/memtrace.h
// Crash-surviving live log for the hardware-watchpoint memory tracer.
//
// The watchpoint (WatchAccess) samples hitting PCs into a kernel perf ring
// that used to be read ONLY by an explicit Lua WatchRead() — so when the game
// crashed, everything still in the ring (including the accesses immediately
// before death, i.e. exactly the crash-point evidence) was lost with the
// process. Now:
//   - live_drain()  — periodic (signal-handler watchdog thread, ~5s): drains
//     every armed watch ring, accumulates per-IP counts, and appends compact
//     lines to memtrace_live.log. Data on disk survives any later crash.
//   - crash_drain() — LAST GASP, called from the fatal signal handler:
//     async-signal-safe (raw reads of the perf mmap + write() to a pre-opened
//     fd, no locks/malloc) so the ring contents at the instant of death are
//     flushed too. The final lines of memtrace_live.log answer "what touched
//     the watched address right before the crash".
// WatchRead() still works and now reports CUMULATIVE counts (ring + what the
// periodic drain already collected), so the two consumers don't steal from
// each other.

#include <string>

namespace memtrace
{

    // Periodic drain — normal context only (takes the watch mutex).
    void live_drain();

    // Last-gasp drain — async-signal-safe; call ONLY from the crash handler.
    void crash_drain(int sig);

    // Where the live log lives (data_dir/memtrace_live.log).
    std::string live_path();

} // namespace memtrace
