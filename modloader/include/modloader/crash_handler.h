#pragma once
// modloader/include/modloader/crash_handler.h
// Signal handler for SIGSEGV, SIGABRT, SIGBUS, SIGFPE
// Writes modloader_crash.log with backtrace + last 500 log lines + fault address

namespace crash_handler
{

    // Install signal handlers (first time — saves old handlers)
    void install();

    // Register a large alternate signal stack on the CURRENT thread (idempotent).
    // REQUIRED for the SA_ONSTACK handler to survive stack overflow/smash and
    // siglongjmp-recover. Call on every thread that runs guarded game code
    // (esp. the game thread — see the ProcessEvent hook).
    void ensure_thread_sigaltstack();

    // Re-install our signal handler on top of whatever replaced it.
    // Call this after mods load, after deferred init, and periodically
    // to prevent Oculus VR runtime / Frida from permanently replacing our handler.
    void reinstall();

    // Mark boot as complete — enables SIGABRT interception.
    // During the first ~5s of boot, SIGABRT is forwarded to the old handler
    // because Frida's gadget calls abort() during its init. After this call,
    // ALL signals are fully caught and logged.
    void mark_boot_complete();

} // namespace crash_handler
