#pragma once
// modloader/include/modloader/arch.h
// ─────────────────────────────────────────────────────────────────────────
// One source tree, both ABIs. The modloader builds for arm64-v8a (the default
// target) and — with no code fork — for armeabi-v7a as well, so 32-bit UE4
// titles (Face Your Fears 1/2) get the same modloader as the 64-bit ones. An
// ELF is single-arch by nature, so the build emits one libmodloader.so per ABI
// and Android loads the matching one from lib/<abi>/; this header keeps the few
// genuinely CPU-specific spots (signal-frame registers, the Dobby register
// union, the callee-saved clobber barrier) behind a common surface so the call
// sites are identical on both.
//
// arm64 is the DEFAULT everywhere below; the only thing tested for is the
// 32-bit exception (__arm__). Nothing "defines arm64".
//
// Android armeabi-v7a note: the ABI is *softfp* — floating-point call arguments
// are passed in the CORE registers r0-r3 (not VFP), so the AArch64 "capture
// D0-D7 separately" machinery simply has nothing to do on 32-bit.
// ─────────────────────────────────────────────────────────────────────────

#include <cstdint>
#include <ucontext.h>

namespace arch {

// ── Signal ucontext register access ─────────────────────────────────────
#if defined(__arm__)
// ARM32: named fields arm_r0..arm_r10, arm_fp/ip/sp/lr/pc, contiguous → r0..r15.
inline uintptr_t uc_pc (const ucontext_t *uc) { return (uintptr_t)uc->uc_mcontext.arm_pc; }
inline uintptr_t uc_sp (const ucontext_t *uc) { return (uintptr_t)uc->uc_mcontext.arm_sp; }
inline uintptr_t uc_lr (const ucontext_t *uc) { return (uintptr_t)uc->uc_mcontext.arm_lr; }
inline uintptr_t uc_fp (const ucontext_t *uc) { return (uintptr_t)uc->uc_mcontext.arm_fp; }
inline uintptr_t uc_reg(const ucontext_t *uc, int n) { return (uintptr_t)(&uc->uc_mcontext.arm_r0)[n]; }
inline void      uc_set_pc(ucontext_t *uc, uintptr_t v) { uc->uc_mcontext.arm_pc = v; }
constexpr int    UC_NGREG = 16; // r0..r15
#else
// AArch64 (default): GP regs in mcontext.regs[0..30], pc/sp named fields.
inline uintptr_t uc_pc (const ucontext_t *uc) { return (uintptr_t)uc->uc_mcontext.pc; }
inline uintptr_t uc_sp (const ucontext_t *uc) { return (uintptr_t)uc->uc_mcontext.sp; }
inline uintptr_t uc_lr (const ucontext_t *uc) { return (uintptr_t)uc->uc_mcontext.regs[30]; }
inline uintptr_t uc_fp (const ucontext_t *uc) { return (uintptr_t)uc->uc_mcontext.regs[29]; }
inline uintptr_t uc_reg(const ucontext_t *uc, int n) { return (uintptr_t)uc->uc_mcontext.regs[n]; }
inline void      uc_set_pc(ucontext_t *uc, uintptr_t v) { uc->uc_mcontext.pc = v; }
constexpr int    UC_NGREG = 31; // x0..x30
#endif

} // namespace arch

// ── Dobby register-context integer registers ────────────────────────────
// ARCH_DREG(ctx, n) is an lvalue for GP register n: ARM32 context union member
// is `r` (r[0..12]); AArch64 is `x` (x[0..28]).
#if defined(__arm__)
#  define ARCH_DREG(ctxptr, n) ((ctxptr)->general.r[(n)])
#else
#  define ARCH_DREG(ctxptr, n) ((ctxptr)->general.x[(n)])
#endif

// ── Callee-saved clobber barrier ────────────────────────────────────────
// Forces the compiler to spill/reload its own state via the stack across an
// untrusted callback, so a callback that violates the ABI and drops a
// callee-saved register cannot corrupt our locals. (ARM32 omits r7/r9 — the
// Thumb frame pointer and platform register — which the assembler reserves.)
#if defined(__arm__)
#  define NHOOK_CALLEE_SAVED_BARRIER() \
       __asm__ volatile("" ::: "r4", "r5", "r6", "r8", "r10", "r11", "memory")
#else
#  define NHOOK_CALLEE_SAVED_BARRIER() \
       __asm__ volatile("" ::: "x19", "x20", "x21", "x22", "x23", "x24", \
                               "x25", "x26", "x27", "x28", "memory")
#endif
