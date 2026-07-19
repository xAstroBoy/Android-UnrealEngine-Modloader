// modloader/src/hook/re4_native_hooks.cpp
// ═══════════════════════════════════════════════════════════════════════
// RE4 VR (com.Armature.VR4) — GAME-SPECIFIC native hooks and byte patches
// ═══════════════════════════════════════════════════════════════════════
// Split out of native_hooks.cpp: everything here is tied to THIS title's
// engine internals — hardcoded RVAs, cEm/cModel layouts, em ids, weapon
// classes. native_hooks.cpp keeps only the game-agnostic machinery (hook
// install/remove, the callback chain, the assembly thunks + dispatch, the
// sigsetjmp safe-call guard and the site/owner lookups).
//
// Everything is still declared in modloader/native_hooks.h and lives in the
// same `native_hooks` namespace, so no caller changes.
//
// Shared with native_hooks.cpp (do NOT duplicate): install_at(), HookId,
// NativeCallContext and the hook registry. Helpers used ONLY by this file
// (patch_code / patch_ro / is_em_id_supported / the LUTs) moved with it.
// ═══════════════════════════════════════════════════════════════════════
#include "modloader/native_hooks.h"
#include "modloader/arch.h"
#include "modloader/symbols.h"
#include "modloader/logger.h"
#include "modloader/lua_ue4ss_globals.h"
#include "modloader/reflection_walker.h"
#include <dobby.h>
#include <dlfcn.h>
#include <cmath>
#include <unordered_map>
#include <mutex>
#include <atomic>
#include <cstring>
#include <cstdio>
#include <vector>
#include <string>
#include <sys/mman.h>
#include <unistd.h>

namespace native_hooks {

// ═══════════════════════════════════════════════════════════════════════
// CLOTH BONE SANITIZER  (RE4 cut-content skeleton-mismatch guard)
// ═══════════════════════════════════════════════════════════════════════
// Cut enemies (Saddler-Ada / em3f, spider, etc.) were ported from RE4 UHD
// with a DIFFERENT skeleton than the classic rig the VR engine's cloth code
// expects. PenClothSet(cModel*, CLOTH_INFO*, float) walks the cloth's bone-
// index arrays and calls cModel::getPartsPtr(model, boneIdx). When the ported
// model's bone chain is SHORTER than the cloth expects, getPartsPtr walks off
// the end and returns null → PenClothSet writes null+0x1d8 → crash
// (tombstone_20: PenClothSet+172 ← cEm3f::move ← EmSetEvent).
//
// FIX: before the original runs, rewrite any bone index the model can't
// resolve to 0xFF — the engine's universal "skip this point" sentinel, handled
// gracefully in BOTH PenClothSet and PenClothMove3. Every cloth point that maps
// to a REAL bone stays live; only the missing (cut) bones skip. No-op when the
// rig is complete (all bones resolve). PenClothSet is SHARED across enemies, so
// one hook covers every cut enemy's cloth.
//
// CLOTH_INFO layout (Em3fClothSet1/2 + PenClothSet/PenClothMove3):
//   +0   u32  count            (cloth1=6, cloth2=10)
//   +8   ptr  bone-idx array a2[1]  (primary — the cloth vertices themselves)
//   +16  ptr  bone-idx array a2[2]
//   +24  ptr  bone-idx array a2[3]
//   +32  ptr  bone-idx array a2[4]  (null for em3f)
//   +40  ptr  bone-idx array a2[5]  (null for em3f)
//   +48  ptr  bone-idx array a2[6]  (connections — heavily used)
//   +56  ptr  bone-idx array a2[7]
//   (a2[8]+ = float/data arrays — NOT bone indices)
// Each array holds `count` bytes; 0xFF already means "no bone".
static inline bool cloth_addr_ok(const void* p) {
    return p && reflection::is_readable_ptr(p);
}

// Replicate cModel::getPartsPtr(model, idx) with full null/mapped guards so it
// NEVER faults — this runs in the pre-callback, OUTSIDE the sigsetjmp guard
// that only wraps the ORIGINAL call. Returns the part ptr, or null if the index
// does not resolve to a real, mapped part.
static void* cloth_resolve_part(void* model, int idx) {
    if (idx < 0 || idx >= 255) return nullptr;
    if (!cloth_addr_ok(model)) return nullptr;
    uint8_t f9 = *((const uint8_t*)model + 9);
    void* head = *reinterpret_cast<void* const*>((const char*)model + 264);
    if (!cloth_addr_ok(head)) return nullptr;
    if (f9 & 0x20) {                                  // contiguous parts array
        void* p = (char*)head + (int64_t)496 * idx;
        return cloth_addr_ok(p) ? p : nullptr;
    }
    void* p = head;                                  // linked list: hop idx times
    for (int a = idx; a > 0; --a) {
        if (!cloth_addr_ok(p)) return nullptr;
        p = *reinterpret_cast<void* const*>((const char*)p + 264);
    }
    return cloth_addr_ok(p) ? p : nullptr;
}

// Make a single byte writable (bone-index globals may live in .data.rel.ro /
// .rodata) and store `val`. Leaves the page RW — harmless for a mod.
static void cloth_write_byte(uint8_t* addr, uint8_t val) {
    if (!addr || *addr == val) return;
    long ps = sysconf(_SC_PAGESIZE);
    if (ps <= 0) ps = 4096;
    uintptr_t page = reinterpret_cast<uintptr_t>(addr) & ~(uintptr_t)(ps - 1);
    mprotect(reinterpret_cast<void*>(page), (size_t)ps, PROT_READ | PROT_WRITE);
    *addr = val;
}

static void cloth_sanitize(void* model, uint32_t* ci) {
    if (!cloth_addr_ok(model) || !cloth_addr_ok(ci)) return;
    uint32_t count = ci[0];
    if (count == 0 || count > 128) return;           // sanity — real cloth is 6/10
    static const int kBoneArrOffsets[] = { 8, 16, 24, 32, 40, 48, 56 };
    int fixed = 0, total = 0;
    for (int off : kBoneArrOffsets) {
        uint8_t* arr = *reinterpret_cast<uint8_t* const*>((const char*)ci + off);
        if (!cloth_addr_ok(arr)) continue;           // null / unmapped array ptr
        for (uint32_t k = 0; k < count; ++k) {
            uint8_t idx = arr[k];
            if (idx == 0xFF) continue;
            ++total;
            if (!cloth_resolve_part(model, idx)) {
                cloth_write_byte(arr + k, 0xFF);
                ++fixed;
            }
        }
    }
    if (fixed > 0) {
        logger::log_info("CLOTH",
            "Sanitized model=%p ci=%p count=%u : %d/%d bone(s) -> skip (missing in ported rig)",
            model, ci, count, fixed, total);
    }
}

static void cloth_sanitize_pre(NativeCallContext& ctx) {
    // Refresh the /proc/self/maps snapshot ONCE per spawn so freshly-allocated
    // part pages read as mapped (avoids a false "missing bone").
    reflection::refresh_memory_map();
    cloth_sanitize(reinterpret_cast<void*>(ctx.x[0]),
                   reinterpret_cast<uint32_t*>(ctx.x[1]));
    // never block — let the (now-safe) original run
}

HookId install_cloth_bone_sanitizer(void* addr) {
    if (!addr) {
        logger::log_error("NHOOK", "cloth_bone_sanitizer: null addr");
        return 0;
    }
    HookId id = install_at(addr, "__cloth_bone_sanitizer",
                           cloth_sanitize_pre, nullptr, "ClothBoneSanitizer");
    logger::log_info("NHOOK", "Cloth bone sanitizer @0x%lX : %s",
                     (unsigned long)reinterpret_cast<uintptr_t>(addr),
                     id ? "installed" : "FAILED");
    return id;
}

// ═══════════════════════════════════════════════════════════════════════
// CUT-ENEMY MODEL-LOAD RESTORE  (em3f / Saddler-Ada renders)
// ═══════════════════════════════════════════════════════════════════════
// Cut enemies (em3f) have a cEmXX::move whose init state runs the native
// archive modelInit but NEVER the VR4ModelInit that spawns the visible UE
// AVR4Model — working enemies (cEm21::init) do BOTH. So em3f gets a native
// skeleton (cModel+384 = cModelInfo list) but no drawn actor (cModel+980=null,
// +988=0) → invisible. This hook injects the missing
//   VR4ModelInit(this, EmModelClassLookUp(this))
// on the tick AFTER modelInit built the model (cModel+384 != 0) and only while
// no UE model exists yet (cModel+988 == 0). Runs in the actor-tick context
// (SpawnActor-safe) with NATIVE register-passed pointers — the MTE-tagged class
// ptr from EmModelClassLookUp goes straight into VR4ModelInit, no Lua round-trip
// to mangle the tag (that mangle is why the exec_lua test faulted in SpawnActor).
// Self-guards on +988, so it is a no-op for enemies that already build their own
// UE model — safe to install on any cEmXX::move.
typedef void* (*cEm_EmModelClassLookUp_t)(void* cEm, const void* a2);
// The POSEABLE model init (0x5F83A68): spawns the poseable actor from `uclass`,
// then vtable[1584](actor, a3, cEm) loads the mesh (from the actor's MeshDataClass
// / meshTable — the pak assets) and SetBaseSkeleton builds it. a3 = the archive
// bin file (archive + *(uint32*)(archive + binOff)), matching em3d's sub_5EA06B0.
typedef void* (*cModel_VR4PoseableModelInit_t)(void* cModel, void* uclass, void* a3);
typedef void* (*FWeakObjectPtr_Get_t)(void* weakptr);
// AVR4PoseableModel::AddOrSwapSkeletalMesh(this, FName bone(by value=u64), uint key,
//                                          const cModelInfo*, UVR4MeshData*)
typedef void  (*AddOrSwapSkeletalMesh_t)(void* poseableModel, uint64_t bone, uint32_t key,
                                         const void* cModelInfo, void* meshData);
typedef uint32_t (*poseable_meshload_t)(void* actor, void* a3, void* cEm);  // actor vtable[+1584]
static cEm_EmModelClassLookUp_t       s_EmModelClassLookUp   = nullptr;
static cModel_VR4PoseableModelInit_t  s_VR4PoseableModelInit = nullptr;
static FWeakObjectPtr_Get_t           s_FWeakGet             = nullptr;
static AddOrSwapSkeletalMesh_t        s_AddOrSwapSkeletalMesh = nullptr;
// UVR4MeshData::TryCacheMap(this, char forceReload) — builds the cached key map
// (meshData+80 TSet) from the meshTable DataTable rows, keyed by FMeshDataSet+8
// (OffsetKey). At cEm3f::move hook time this map is EMPTY until this runs.
typedef void (*UVR4MeshData_TryCacheMap_t)(void* meshData, char forceReload);
// cModInfoMgr::create(&ModInfoMgr, archive+partOffset, archive+commonOffset) → cModelInfo*
// Pool-allocates a node, relocates the archive part data in place (guarded by flag
// 0x100000 so it is idempotent), stores partData @node+24 / commonData @node+32, and
// returns null if the pool is exhausted. cModel::addModel appends it to the cEm+384
// chain (linked via +40). This is verbatim what em3f's init (sub_5EA3678) does for
// its four hand-coded parts.
typedef void* (*cModInfoMgr_create_t)(void* mgr, void* partData, void* commonData);
typedef void* (*cModel_addModel_t)(void* cModel, void* modelInfo);
static cModInfoMgr_create_t s_ModInfoMgrCreate = nullptr;
static cModel_addModel_t    s_addModel         = nullptr;
static void*                s_ModInfoMgr       = nullptr;   // &ModInfoMgr, RVA 0xA578670
// VR4CreateEmSubObject(bin, parentEm, subObj) [0x5D9136C] — the port's entry point for
// giving a cObj SUB-OBJECT a renderer: runs the meshload on the PARENT's actor to get a
// mesh key, then cModel::VR4ModelInit(subObj, key, parentActor->meshData), which spawns
// the sub-object's actor from the PLAIN AVR4PoseableModel class (never a BP class).
typedef void* (*VR4CreateEmSubObject_t)(void* bin, void* parentEm, void* subObj);
static VR4CreateEmSubObject_t s_VR4CreateEmSubObject = nullptr;
static UVR4MeshData_TryCacheMap_t     s_TryCacheMap = nullptr;
// em3f_meshTable OffsetKeys decoded on PC from EnemyFixes_P.pak (7 poseable parts:
// EM3F04..EM3F94 → em3f_004..094; 2190400 = em3f_094 tentacle). Fallback keys in
// case the runtime cached-map enumeration comes up empty.
static const uint32_t s_em3fMeshKeys[7] = { 311872, 452736, 638432, 661504, 684544, 745920, 2190400 };
// ── em3f BROKEN SOFT-PATH FIXES ───────────────────────────────────────────────
// em3f_meshTable ships WRONG MeshRefs for every part sourced from the plaga set:
// rows em3f_008 / em3f_009 / em3f_094 all point at
//   /Game/Characters/BIO4/EM/em25_plaga/Geometry/<mesh>
// but those assets are actually packed (verified by decoding EnemyFixes_P.pak on
// PC, and live: LoadAsset on the em25_plaga path fails, em30_Saddler loads) at
//   /Game/Characters/BIO4/BOSS/em30_Saddler/Geometry/<mesh>
// so FSoftObjectPath::TryLoad returns null → SetMesh assigns NO mesh → those
// components render nothing (you only see the plaga attack's particles).
// Per-spawn logging confirmed keys 684544/745920 dead and 2190400 fixed once
// repointed. We rewrite each cached entry's AssetPathName FName to the correct
// path right after TryCacheMap rebuilds it, so the game's own loader resolves the
// mesh. Comparison indices come from Lua (FName(path):GetComparisonIndex()).
struct Em3fPathFix { uint32_t key; int32_t fname_idx; };
static Em3fPathFix s_em3fPathFixes[8] = {};
static int         s_em3fPathFixCount = 0;
// em3f's ETS_DATA header holds 4 model-part bin offsets: +32 (robe=base, done by
// SetBaseSkeleton) then +36/+40/+44 (body/head/hands). sub_5EA3678 builds all 4 as
// native cModelInfos (chained at cModel+384 via +40); we attach parts 1..3 to the UE
// poseable actor with AddOrSwapSkeletalMesh so the whole Saddler-Ada renders.
static const uint32_t s_partBinFields[4] = { 32, 36, 40, 44 };

static void model_restore_pre(NativeCallContext& ctx) {
    void* cEm = reinterpret_cast<void*>(ctx.x[0]);
    if (!cEm) return;
    // Read fields through the (MTE-tagged) this ptr exactly as the game does.
    uint8_t initDone = *reinterpret_cast<volatile uint8_t*>((char*)cEm + 988);
    if (initDone) return;                       // already has a UE model (or we ran)
    void* modelInfo = *reinterpret_cast<void* const volatile*>((char*)cEm + 384);
    if (!modelInfo) return;                     // native modelInit not done yet — wait a tick
    if (!s_EmModelClassLookUp || !s_VR4PoseableModelInit) return;
    void* archive = *reinterpret_cast<void* const volatile*>((char*)cEm + 1120);
    if (!archive) return;                       // ETS_DATA archive not attached

    // ── ONE-SHOT ARCHIVE PROBE ─────────────────────────────────────────────
    // em3f.das uncompresses to 2,481,120 bytes in the base pak, and the largest
    // meshTable key is 2,190,400 — so every key falls INSIDE the archive and the
    // plaga/tentacle/knife data ships with the VR game. We only ever read 4 bin
    // offsets (+32/36/40/44); dump the whole header so we can see how many the
    // archive really declares, and which offsets they point at.
    {
        static bool probed = false;
        if (!probed) {
            probed = true;
            const volatile uint32_t* h = reinterpret_cast<const volatile uint32_t*>(archive);
            // h[0] = entry count (109); the offset table starts at h[4] (byte +16).
            uint32_t count = h[0];
            logger::log_info("EM3F", "archive: %u entries, table at +16", count);
            if (count > 0 && count < 512) {
                for (uint32_t i = 0; i < count; i += 8) {
                    char line[256]; int p = 0;
                    for (uint32_t j = i; j < i + 8 && j < count; ++j)
                        p += snprintf(line + p, sizeof(line) - p, "%10u ", h[4 + j]);
                    logger::log_info("EM3F", "  ent[%3u..]: %s", i, line);
                }
                // Which table index does each meshTable key correspond to?
                static const uint32_t want[7] = { 311872, 452736, 638432, 661504,
                                                  684544, 745920, 2190400 };
                for (int k = 0; k < 7; ++k) {
                    int found = -1;
                    for (uint32_t j = 0; j < count; ++j)
                        if (h[4 + j] == want[k]) { found = (int)j; break; }
                    logger::log_info("EM3F", "  key %8u -> table idx %d (hdr byte +%d)%s",
                                     want[k], found, found >= 0 ? 16 + found * 4 : -1,
                                     found < 0 ? "   *** NOT AN ARCHIVE ENTRY ***" : "");
                }
            }
            int n = 0;
            for (void* ci = *reinterpret_cast<void* const volatile*>((char*)cEm + 384);
                 ci && n < 24;
                 ci = *reinterpret_cast<void* const volatile*>((char*)ci + 40), ++n) {
                void* dp = *reinterpret_cast<void* const volatile*>((char*)ci + 24);
                long long d = dp ? (long long)((uintptr_t)dp - (uintptr_t)archive) : -1;
                logger::log_info("EM3F", "  cModelInfo[%d] = %p  data=%p  key(delta)=%lld", n, ci, dp, d);
            }
            logger::log_info("EM3F", "  chain length = %d node(s)", n);
        }
    }

    // NOTE: em3f_008 (entry 8) and em3f_009 (entry 9) are NOT parts of this cModel.
    // SetObj41(cEm, 0/1) builds each as its own cObj with its own cModel::modelInit
    // (hence its own initJoint / 15- and 12-bone rig, and its own texture at entries
    // 2/3), parents it at obj+1024, and drives it with its own motion stream. The
    // game already creates both in em3f's init — they are invisible only because no
    // UE actor was ever made for them, exactly like the body was. They are handled
    // after the body below; do NOT add them to this chain as parts (that skins them
    // onto the body's 54-bone hierarchy = the deformed heap).
    void* cls = s_EmModelClassLookUp(cEm, nullptr);   // → GetEmModelClass(emId @cEm+0x118)
    if (!cls) return;                           // class not in EmModelData / not loaded yet
    // Base part (robe) = archive bin at header +32.
    uint32_t binOff0 = *reinterpret_cast<const uint32_t volatile*>((char*)archive + s_partBinFields[0]);
    void* a3 = (char*)archive + binOff0;
    s_VR4PoseableModelInit(cEm, cls, a3);       // spawn poseable actor + build BASE mesh, sets +988=1

    // Attach ALL the OTHER meshTable parts (body/head/hands/tentacle) so the full
    // model renders. The head/hands are pak-only meshes with no native archive bin,
    // so their keys can't come from the archive — instead we ENUMERATE the meshData's
    // cached key map (TryCacheMap built a TSet<TTuple<uint key, FVR4RawMeshData>> at
    // meshData+80: Data ptr @+80, ArrayNum @+88, element stride 120, int key @elem+0)
    // and AddOrSwapSkeletalMesh(actor, NAME_None, key, cModelInfo, meshData) each key.
    // SetBaseSkeleton already placed the base key; AddOrSwap on it just swaps (no harm).
    int attached = 0;
    if (s_FWeakGet && s_AddOrSwapSkeletalMesh) {
        void* actor = s_FWeakGet((char*)cEm + 980);
        if (actor) {
            void* meshData = *reinterpret_cast<void* const volatile*>((char*)actor + 560);
            void* baseCi   = *reinterpret_cast<void* const volatile*>((char*)cEm + 384);  // base cModelInfo
            if (meshData) {
                // CRITICAL: build the cached key map from the DataTable FIRST. At hook
                // time it is empty (TryCacheMap hasn't run) → enumeration found 0 parts,
                // which is why only the base robe rendered. Force-rebuild it now.
                if (s_TryCacheMap) s_TryCacheMap(meshData, 1);
                void* elems  = *reinterpret_cast<void* const volatile*>((char*)meshData + 80);   // TSparseArray Data
                int32_t num  = *reinterpret_cast<const int32_t volatile*>((char*)meshData + 88);  // ArrayNum
                // Repoint every broken MeshRef (em25_plaga -> em30_Saddler) in the
                // freshly-rebuilt cache, BEFORE the attach loop asks SetMesh to load them.
                // Element: {uint key @+0, FSoftObjectPath @+8}; AssetPathName FName =
                // {ComparisonIndex @+8, Number @+12}. Stride 120.
                if (s_em3fPathFixCount && elems && num > 0 && num < 64) {
                    for (int i = 0; i < num; ++i) {
                        char* e = (char*)elems + 120 * i;
                        uint32_t k = *reinterpret_cast<const uint32_t volatile*>(e);
                        for (int fx = 0; fx < s_em3fPathFixCount; ++fx) {
                            if (s_em3fPathFixes[fx].key != k) continue;
                            int32_t want = s_em3fPathFixes[fx].fname_idx;
                            if (*reinterpret_cast<const int32_t volatile*>(e + 8) != want) {
                                *reinterpret_cast<int32_t volatile*>(e + 8)  = want;
                                *reinterpret_cast<int32_t volatile*>(e + 12) = 0;
                                logger::log_info("EM3F", "MeshRef repointed key=%u em25_plaga -> em30_Saddler (FName idx %d)",
                                                 k, want);
                            }
                            break;
                        }
                    }
                }
                // Each part MUST get a distinct component-slot FName: FindOrCreateComponent
                // keys its TSet<TTuple<FName,FMeshPartData>> by the bone FName (a2), so a
                // shared NAME_None collapsed all 7 onto ONE component (each swapped the last,
                // leaving only the tentacle). Parts attach to the master via
                // SetMasterPoseComponent at identity, so the FName is purely a unique key —
                // {ComparisonIndex=None, Number=i+1} gives 7 distinct slots.
                // Map OffsetKey -> its OWN cModelInfo. Each chain node's data pointer
                // (node+24) lives at archiveBase + OffsetKey, so the key is just the
                // delta — verified from a live dump: the node deltas (140864, 185696,
                // 23072) exactly match the meshTable key deltas (311872 -> 452736 ->
                // 638432 -> 661504). Handing every part the BASE node made SetMesh's
                // TSet<cModelInfo*,component> (this+848) treat all 7 as ONE part, so
                // they inherited the base transform and piled up unanimated.
                // The chain now has 7 nodes: em3f's init builds 4 and we build the
                // three entries it skips (8/9/94) just above, so every meshTable key
                // resolves to its OWN node here. A key with no node would still be
                // skipped below rather than wrongly bound to the base part.
                struct CiEntry { uint32_t key; void* ci; };
                CiEntry cimap[16];
                int cimapN = 0;
                {
                    void* ci = *reinterpret_cast<void* const volatile*>((char*)cEm + 384);
                    for (int n = 0; ci && n < 16; ++n) {
                        void* dp = *reinterpret_cast<void* const volatile*>((char*)ci + 24);
                        if (dp && archive) {
                            uintptr_t d = (uintptr_t)dp - (uintptr_t)archive;
                            if (d < 0x8000000u) cimap[cimapN++] = { (uint32_t)d, ci };
                        }
                        ci = *reinterpret_cast<void* const volatile*>((char*)ci + 40);
                    }
                }
                // Attach every part that has a cModelInfo — now all 7, since we build
                // the three nodes em3f's init skips. Each part carries its OWN node, so
                // SetMesh's TSet<cModelInfo*,component> (this+848) keeps them distinct
                // and the native rig drives each one from its own archive joint data.
                //
                // This is what the earlier master-pose attempt got wrong: em3f_008/009/094
                // are separate armatures (15/12/own bones) that reuse the same `bone_N`
                // names as em3f_skeleton in a different order, so SetMasterPoseComponent
                // matched by name and wrenched the tentacle onto the torso joints = the
                // heap at the model centre. With their own nodes they no longer need the
                // master's rig at all.
                if (elems && num > 0 && num < 64) {
                    for (int i = 0; i < num; ++i) {
                        uint32_t key = *reinterpret_cast<const uint32_t volatile*>((char*)elems + 120 * i);
                        void* partCi = nullptr;
                        for (int m = 0; m < cimapN; ++m)
                            if (cimap[m].key == key) { partCi = cimap[m].ci; break; }
                        if (!partCi) {
                            // Expected for 684544/745920 (obj41 sub-objects, own cModel
                            // + own rig — see below) and 2190400 (em3f_094, the knife:
                            // no em3f code references archive entry 94 at all).
                            logger::log_info("EM3F", "  skip key=%u (not a part of this cModel)", key);
                            continue;
                        }
                        uint64_t slotName = (uint64_t)(i + 1) << 32;   // FName{None, i+1}
                        s_AddOrSwapSkeletalMesh(actor, slotName, key, partCi, meshData);
                        logger::log_info("EM3F", "  attach key=%u ci=%p (own node)", key, partCi);
                        ++attached;
                    }
                }
                // Fallback: if the cached map was still empty/unreadable, attach the 7
                // OffsetKeys decoded from the pak so the parts render regardless.
                if (attached == 0) {
                    for (int i = 0; i < 7; ++i) {
                        void* partCi = nullptr;
                        for (int m = 0; m < cimapN; ++m)
                            if (cimap[m].key == s_em3fMeshKeys[i]) { partCi = cimap[m].ci; break; }
                        if (!partCi) continue;          // separate rig — leave it to the game
                        uint64_t slotName = (uint64_t)(i + 1) << 32;
                        s_AddOrSwapSkeletalMesh(actor, slotName, s_em3fMeshKeys[i], partCi, meshData);
                        ++attached;
                    }
                }
            }
        }
    }
    logger::log_info("EM3F", "restored POSEABLE model: cEm=%p cls=%p +988=%d meshTableParts=%d",
                     cEm, cls, *reinterpret_cast<volatile uint8_t*>((char*)cEm + 988), attached);

    // (The per-node head-word dump that used to live here has served its purpose:
    // the part offset is node+24's delta from the archive base = the meshTable
    // OffsetKey. That mapping is now built into `cimap` above.)

    // Report what ACTUALLY landed per part, so one spawn tells us which links
    // resolved a mesh and which came back empty — no live poking needed.
    // Component map @ actor+688 (Data) / +696 (Num); 32B elems {FName@0, comp@8,
    // key@16}. USkeletalMeshComponent::SkeletalMesh lives at comp+0x430
    // (confirmed via USkeletalMeshComponent::SetSkeletalMesh's `LDR X8,[X0,#0x430]`).
    if (s_FWeakGet) {
        void* actor2 = s_FWeakGet((char*)cEm + 980);
        if (actor2) {
            void* mapData = *reinterpret_cast<void* const volatile*>((char*)actor2 + 688);
            int32_t mapNum = *reinterpret_cast<const int32_t volatile*>((char*)actor2 + 696);
            if (mapData && mapNum > 0 && mapNum < 32) {
                for (int i = 0; i < mapNum; ++i) {
                    char* e = (char*)mapData + 32 * i;
                    void* comp = *reinterpret_cast<void* const volatile*>(e + 8);
                    if (!comp) continue;
                    uint32_t k    = *reinterpret_cast<const uint32_t volatile*>(e + 16);
                    void*    mesh = *reinterpret_cast<void* const volatile*>((char*)comp + 0x430);
                    logger::log_info("EM3F", "  part key=%u comp=%p mesh=%p %s",
                                     k, comp, mesh, mesh ? "OK" : "<-- NO MESH (link dead)");
                }
            }
        }
    }

    // ── obj41 SUB-OBJECTS: em3f_008 + em3f_009 (THE TENTACLE) ──────────────
    // These are NOT parts of Saddler's cModel — they are separate cObj objects that
    // em3f's init already creates and the native code already animates every frame:
    //
    //   init:  *(cEm+1373) = SetObj41(cEm, 0);   // em3f_008, archive entry 8
    //          *(cEm+1381) = SetObj41(cEm, 1);   // em3f_009, archive entry 9
    //
    // SetObj41 runs a full cModel::modelInit on each (bin = archive + hdr[+48/+52],
    // tex = archive + hdr[+24/+28] = entries 2/3), so each gets its OWN initJoint and
    // therefore its own rig — which is exactly why they have 15/12 bones and could
    // never be master-posed onto the body's 54-bone hierarchy without deforming.
    // Placement is a hardcoded tie in sub_5FA35BC via obj+1032:
    //   obj41 #0 -> 36  : MTXConcat onto parent bone 36's matrix
    //   obj41 #1 -> -1  : follows the parent's root transform
    // and MotSetObj41 feeds each its own motion (archive +320 / +384 = entries 76/92).
    //
    // So the whole system works natively already, and they are invisible for the SAME
    // reason the body was: no UE actor.
    //
    // Use the port's PURPOSE-BUILT sub-object entry point — do NOT hand a cObj its own
    // BP actor. em38 (sub_5E74AF0) shows the sanctioned pattern for exactly this case:
    //     SetObj00(...); OyaSetObj00(obj, this, 0x3A);
    //     VR4CreateEmSubObject(archive + hdr[+324], this, obj);
    // VR4CreateEmSubObject(bin, parentEm, subObj) [0x5D9136C]:
    //     actor = FWeakGet(parentEm + 980);              // the PARENT's actor
    //     key   = actor->vtable[1584](actor, bin, parentEm);   // meshload on the PARENT
    //     cModel::VR4ModelInit(subObj, key, actor->meshData@+560);
    // and that VR4ModelInit overload [0x5F83668] spawns the sub-object's actor from
    // AVR4PoseableModel::GetPrivateStaticClass() — the PLAIN ENGINE CLASS.
    //
    // That distinction is the whole bug in the previous attempt: passing
    // EmModelClassLookUp(cEm) (= the EM3F_Poseable_BP Blueprint, whose tick logic
    // expects a real cEm) to VR4PoseableModelInit and SetBio4Model'ing it onto a cObj
    // corrupted state far away — the pPL player global went NULL (killing SndWatcher,
    // which derefs it unguarded) plus a RenderThread FMeshBatch::Add crash.
    // Sub-objects get the plain AVR4PoseableModel; only cEm gets the BP class.
    if (s_VR4CreateEmSubObject) {
        struct Obj41 { uint32_t emOff; uint32_t entry; const char* what; };
        static const Obj41 kObj41[2] = {
            { 1373, 8, "em3f_008 (plaga, tied to bone 36)" },
            { 1381, 9, "em3f_009 (TENTACLE, follows root)" },
        };
        const volatile uint32_t* h = reinterpret_cast<const volatile uint32_t*>(archive);
        uint32_t count = h[0];
        for (int i = 0; i < 2 && count > 0 && count < 512; ++i) {
            if (kObj41[i].entry >= count) continue;
            // cEm+1373 / +1381 are UNALIGNED qwords — copy, don't deref.
            void* obj = nullptr;
            __builtin_memcpy(&obj, (char*)cEm + kObj41[i].emOff, sizeof(obj));
            if (!obj) continue;                                   // SetObj41 failed/not run
            if (*reinterpret_cast<volatile uint8_t*>((char*)obj + 988)) continue;  // has one
            uint32_t binOff = h[4 + kObj41[i].entry];
            if (!binOff || binOff >= 0x4000000u) continue;
            // Needs the PARENT's actor to already exist — VR4PoseableModelInit above.
            s_VR4CreateEmSubObject((char*)archive + binOff, cEm, obj);
            void* oactor = s_FWeakGet ? s_FWeakGet((char*)obj + 980) : nullptr;
            logger::log_info("EM3F", "obj41 sub-object: %s  obj=%p bin=+%u actor=%p %s",
                             kObj41[i].what, obj, binOff, oactor,
                             oactor ? "OK" : "<-- no actor (mesh key unresolved?)");
        }
    }
}

// ═══════════════════════════════════════════════════════════════════════
// CUT VILLAGER GANADOS (em ids 6/7/8/0xA/0xB/0xD/0x33/0x37) — REAL SPAWN FIX
// ═══════════════════════════════════════════════════════════════════════
// Engine defect, fully traced. `ArmEmCallProlog(id)` [0x617E62C] is
// `v1 = id-3; switch (v1)` and every prolog is ONE line, e.g.
//     void _prologEm09() { EmInitFunc = Em09Init; }     // EmInitFunc is a GLOBAL
// An id with no case hits `default:`, returns 0, and NEVER touches the global.
// `EmReadSearch` [0x617E904] then nulls only its CACHED copy
// (`if ((v39 & 1) == 0) v41 = nullptr;`) but leaves the global STALE and still
// returns the loaded archive; `cEmMgr::construct` only guards `if (!result)`.
// => it calls the PREVIOUS enemy's init. When that was a Pl11-family sub-char
// (Ashley/Luis, ids 3/5/12), Pl11Init -> cSubAshley::modelSet ran over ganado
// data -> cModInfoMgr::create's `*a2 = (int64)a2 + *a2` fixup -> ~0xaf..15ec ->
// cModel::initJoint+144 -> SIGSEGV (tombstones 27/30). Guarding modelInit does
// NOT help (tombstone_30 has the guard in the stack and the game still died):
// by then the wrong function is already running on the wrong data.
//
// THESE IDS ARE VILLAGER GANADOS AND THEIR ARCHIVE MAPPING WAS ALWAYS CORRECT.
// EmFileTbl (RVA 0xA4672CC, 8B stride {u16 dasIdx, u16 relIdx, u16, u16}) maps
// ids 0x06-0x0B/0x0D/0x10/0x33/0x37 -> idx 24 = "em/em10.das". That is NOT a
// placeholder: they are variants that SHARE the ganado archive. Proof from
// EnemyFixes_P.pak — em07/em08/em09/em10_meshTable are all 132 rows and
// IDENTICAL (same keys 1900896/3921440/4007616..., same em1000/em1001/em10rh00
// meshes), and the pak ships Em07_Poseable/Em08_Poseable under Ganado/Villager.
// (Do NOT repoint EmFileTbl[7] at pl07.das: pl07 is a SEPARATE cutscene cop with
// its own Player/pl07_Police_MeshTable and an 11-entry archive. Forcing id 7
// there needs Ashley's layout and dies in EspDataLoad/setHand.)
//
// So the ONLY missing piece is the prolog. Ids 9 (_prologEm09) and 0x10
// (_prologEm10set) use the SAME em10.das and work — same archive == same layout,
// so a cut id can take the same init and gets REAL ganado AI for free.
// Pure DATA patch, no hook:
//   jpt_617E658 (RVA 0x4326B50, .rodata byte table): BR = loc_617E65C + jpt[id-3]*4
//   jpt[id-3] = jpt[6]   (id 9 -> _prologEm09, byte 0x04)
//
// NEVER HOOK ArmEmCallProlog: its body is `ADRL X9, jpt / ADR X10, case0 /
// LDRB W11,[X9,X8] / BR X10`; the trampoline relocates those PC-relative ops ->
// X9 wrong -> BR jumps into the stack (tombstone_02: SEGV_ACCERR, pc==lr==fault,
// single [anon:stack_and_tls] frame) — and it fires on EVERY enemy load.
static const uint32_t kEmFileTblRva = 0xA4672CC;
static const uint32_t kJptRva       = 0x4326B50;  // jpt_617E658
static const int      kJptIdx_id9   = 6;          // id 9 -> _prologEm09 (byte 0x04)
// Cut ids that map to em10.das but have no prolog. (id 9 = _prologEm09 and
// id 0x10 = _prologEm10set already work — deliberately not touched.)
static const uint8_t  kCutVillagerIds[] = { 0x06, 0x07, 0x08, 0x0A, 0x0B, 0x0D, 0x33, 0x37 };

// Patch EXECUTABLE code (.text). Distinct from patch_ro on purpose: patch_ro
// mprotects READ|WRITE, which DROPS PROT_EXEC — do that to a code page and the
// next call into it kills the process. Code needs RWX and, on ARM64, an explicit
// icache flush: the CPU can happily keep executing the stale instruction out of
// the instruction cache after the data write lands.
static bool patch_code(void* addr, const void* src, size_t n) {
    if (!addr || !n) return false;
    long ps = sysconf(_SC_PAGESIZE);
    if (ps <= 0) ps = 4096;
    uintptr_t a     = reinterpret_cast<uintptr_t>(addr);
    uintptr_t first = a & ~(uintptr_t)(ps - 1);
    uintptr_t last  = (a + n - 1) & ~(uintptr_t)(ps - 1);
    size_t    len   = (size_t)(last - first + ps);
    if (mprotect(reinterpret_cast<void*>(first), len,
                 PROT_READ | PROT_WRITE | PROT_EXEC) != 0) {
        logger::log_error("PATCH", "mprotect RWX failed at %p", addr);
        return false;
    }
    __builtin_memcpy(addr, src, n);
    __builtin___clear_cache(reinterpret_cast<char*>(addr),
                            reinterpret_cast<char*>(a + n));
    // Leave it RX — never leave game code writable behind us.
    mprotect(reinterpret_cast<void*>(first), len, PROT_READ | PROT_EXEC);
    return true;
}

// Write through a possibly read-only page (.rodata / .data.rel.ro). Leaves it RW.
static void patch_ro(void* addr, const void* src, size_t n) {
    if (!addr || !n) return;
    long ps = sysconf(_SC_PAGESIZE);
    if (ps <= 0) ps = 4096;
    uintptr_t a     = reinterpret_cast<uintptr_t>(addr);
    uintptr_t first = a & ~(uintptr_t)(ps - 1);
    uintptr_t last  = (a + n - 1) & ~(uintptr_t)(ps - 1);
    mprotect(reinterpret_cast<void*>(first), (size_t)(last - first + ps),
             PROT_READ | PROT_WRITE);
    __builtin_memcpy(addr, src, n);
}

// Is `id` an em the engine can actually construct?
//
// cEmMgr::construct [0x5D90288] guards the ARCHIVE but not the INIT POINTER:
//     BL   EmReadSearch ; STR X0,[X19,#0x460] ; CBZ X0, ret   <- archive checked
//     LDR  X8,[X8]      ; BLR X8                              <- EmInitFunc, UNCHECKED
// EmInitFunc is a global that only ArmEmCallProlog's per-id case sets. An id with
// no case leaves it at whatever the last enemy stored — or NULL if nothing has
// spawned yet, which is a straight `BLR 0` (tombstone: pc=0, "null pointer
// dereference"). So spawning an unimplemented id either runs the WRONG init over
// the wrong archive or jumps to zero. Neither is survivable and no guard helps,
// because by then the wrong function is already running.
//
// The jump table IS the ground truth for "does this id have an init", so ask it
// instead of maintaining a hand-written list that will rot:
//     supported  <=>  0 <= id-3 <= 0x4C  &&  jpt[id-3] != <the default case byte>
// Per IDA the default cases are ids 6-8,10,11,13,51,55,75,78 — we wire the first
// eight to _prologEm09 (they share em10.das with id 9), which leaves 75/78
// (em4b.das / em4e.das = the vehicles + Houdai cannon) genuinely unimplemented.
bool is_em_id_supported(uint32_t id) {
    uintptr_t base = symbols::lib_base();
    if (!base) return true;                 // can't tell — don't block the caller
    int idx = static_cast<int>(id) - 3;
    if (idx < 0 || idx > 0x4C) return false;   // outside the switch => default
    const uint8_t* jpt = reinterpret_cast<const uint8_t*>(base + kJptRva);
    // The default's byte = (def_617E658 - loc_617E65C)/4 = (0x617E864-0x617E65C)/4.
    // Derive it rather than trusting a constant, so a game update can't silently
    // turn this into "everything is supported".
    static const uint8_t kDefaultByte = (uint8_t)((0x617E864u - 0x617E65Cu) / 4u);  // 0x82
    return jpt[idx] != kDefaultByte;
}

bool install_cut_villager_fix() {
    uintptr_t base = symbols::lib_base();
    if (!base) {
        logger::log_error("CUTEM", "lib_base unavailable — cut-villager fix skipped");
        return false;
    }
    const volatile uint16_t* emft = reinterpret_cast<const volatile uint16_t*>(base + kEmFileTblRva);
    uint8_t* jpt  = reinterpret_cast<uint8_t*>(base + kJptRva);
    uint8_t  want = jpt[kJptIdx_id9];     // id 9's case byte -> _prologEm09
    uint16_t das9 = emft[(9 * 8) / 2];    // id 9's file idx (24 = em10.das) = the family marker
    int done = 0, total = (int)sizeof(kCutVillagerIds);
    for (int i = 0; i < total; ++i) {
        uint8_t id = kCutVillagerIds[i];
        // Only touch ids that genuinely share id 9's archive — never guess.
        uint16_t das = emft[(id * 8) / 2];
        if (das != das9) {
            logger::log_warn("CUTEM", "em id 0x%02X -> file idx %u, not id 9's %u — skipped (different archive)",
                             id, das, das9);
            continue;
        }
        int idx = (int)id - 3;            // jump-table index
        if (idx < 0 || idx > 0x4C) continue;
        if (jpt[idx] == want) { ++done; continue; }
        uint8_t old = jpt[idx];
        patch_ro(&jpt[idx], &want, 1);
        logger::log_info("CUTEM", "em id 0x%02X: prolog 0x%02X (none) -> 0x%02X (_prologEm09) — shares em10.das with id 9",
                         id, old, jpt[idx]);
        ++done;
    }
    logger::log_info("CUTEM", "cut villager ganados wired to the id-9 ganado init: %d/%d (real AI; no stale EmInitFunc)",
                     done, total);
    return done > 0;
}

// ═══════════════════════════════════════════════════════════════════════
// CROSSOVER ENEMY REMAP — ids 0x60-0x6F (the Randomizer's above-base pool)
// ═══════════════════════════════════════════════════════════════════════
// These ids are OUTSIDE ArmEmCallProlog's switch (id-3 = 0x5D..0x6C > 0x4C), so
// the villager jump-table patch cannot reach them: ArmEmCallProlog returns 0,
// the global EmInitFunc stays at the PREVIOUS enemy's init, and cEmMgr::construct
// (which never null-checks it) runs that wrong init on the wrong archive -> the
// init smashes its own saved {x29,x30} -> RET into 0xA54AB68 (data near EmMgr).
// Signature: PC==LR==X30==0xA54AB68, identical every crash (fixed global target).
//
// Fix: remap the id arg (W2) at construct ENTRY to a supported base enemy. W2 is
// read for the switch, EmReadSearch, EmInitFunc, ArmLoadSoundBlockEnemy AND stored
// as the cEm's own id (STRB W20,[X19,#0x118]) — rewriting it at entry (before the
// first MOV W20,W2) makes the WHOLE enemy a real one, so there is no stale init to
// call. Ids whose .das already references a base archive keep the same model
// (0x68->em18, 0x66->em46, 0x6C/6D/6F->em4c/4d/4f); the ema-series (unique .das
// with no base to borrow) fall back to em09 = a generic ganado. Any target that is
// itself unsupported also falls back to em09. DobbyInstrument on the entry is safe:
// the first instruction is `STR X21,[SP,#-0x30]!` (position-independent), unlike
// ArmEmCallProlog's ADRL/ADR which the trampoline would have broken.
namespace {
struct CrossoverMap { uint8_t from, to; };
// Targets: 0x46/0x18/0x4C/0x4D/0x4F are REAL base enemies whose .das these ids
// already reference (they can spawn as real enemies). The "ema-series" have no
// base enemy to borrow AND their em09 fallback crashes — em09's model/skeleton
// isn't loaded in these rooms, so IK/motion walk a garbage bone chain (thousands
// of faults/sec). Route those to 0x50 = cEmObj: construct case 80 makes a bare
// cModel + object vtable, does NOT call EmReadSearch (no model load) and never
// runs IK/motion → inert but 100% stable. (0x50 = 80 = the first object case.)
const uint8_t kInertObj = 0x50;   // cEmObj — construct case 80, no model/IK
const CrossoverMap kCrossoverMap[] = {
    {0x66, 0x46}, {0x68, 0x18}, {0x6C, 0x4C}, {0x6D, 0x4D}, {0x6F, 0x4F},
    {0x60, kInertObj}, {0x61, kInertObj}, {0x62, kInertObj}, {0x63, kInertObj},
    {0x64, kInertObj}, {0x65, kInertObj}, {0x67, kInertObj}, {0x69, kInertObj},
    {0x6A, kInertObj}, {0x6B, kInertObj}, {0x6E, kInertObj},
    // 0x59: observed live to fault inside EmSetFromList2 itself, EVERY time, and
    // it is the last call before the process dies. Every other id the randomiser
    // placed (0x64,0x65,0x66,0x68,0x69,0x6B,0x6C,0x6D,0x6E) passes through fine.
    // It sits in the object-id range so the construct switch would accept it, but
    // EmSetFromList2 runs BEFORE construct and cannot build it here.
    {0x59, kInertObj},
};
uint8_t s_crossover_lut[256] = {0};    // [id] = target id, 0 = no remap
std::atomic<uint64_t> s_crossover_hits{0};
}

static void crossover_remap_construct(void* /*addr*/, DobbyRegisterContext* ctx) {
    uint8_t id = (uint8_t)(ARCH_DREG(ctx, 2) & 0xFF);
    uint8_t to = s_crossover_lut[id];
    if (to) {
        ARCH_DREG(ctx, 2) = (ARCH_DREG(ctx, 2) & ~0xFFULL) | to;
        uint64_t n = s_crossover_hits.fetch_add(1, std::memory_order_relaxed) + 1;
        if (n <= 16 || (n % 500) == 0)
            logger::log_info("XEMAP", "crossover em 0x%02X -> em 0x%02X (real enemy, no stale init) [%lu]",
                             id, to, (unsigned long)n);
    }
}

// ═══════════════════════════════════════════════════════════════════════════
// gameRoomInit — NULL virtual call on a bare cEm
// ═══════════════════════════════════════════════════════════════════════════
// Tombstone (SEGV_MAPERR, fault addr 0x0, "Cause: null pointer dereference"):
//     #00 pc 0000000000000000  <unknown>        <- BLR'd a NULL fn pointer
//     #01 gameRoomInit()+2260
//     #02 ABio4::Tick(float)+1032
// The site is:
//     5f43b30  ldr x0, [x22]        ; the enemy
//     5f43b34  ldr x8, [x0]         ; its vtable
//     5f43b38  ldr x8, [x8, #0x90]  ; vtable slot 0x90
//     5f43b3c  blr x8               ; called with NO null check
// Checking the vtables explains it exactly:
//     _ZTV6cEmObj  +0x90 -> 0x5d91d80   (present)
//     _ZTV5cEm09   +0x90 -> 0x5d92198   (present)
//     _ZTV3cEm     +0x90 -> NULL         <-- base class has no implementation
// so any enemy left as a bare cEm makes gameRoomInit jump to 0. This is the
// engine's own unguarded-virtual house style (same family as getRoomSavePtr /
// getPartsPtr), not a mod bug — the remap targets both have valid entries.
//
// Guarding the CALL SITE fixes every id at once instead of playing whack-a-mole
// with which enemy ended up as a base cEm. One DobbyInstrument, exactly like the
// em32 site-2 fix: if X8 is NULL, point it at a stub that just returns, so the
// BLR is a no-op and room init continues. The instrumented instruction is a
// plain LDR (position-independent), so the trampoline can relocate it safely.
static void vcall_noop_stub(void) { /* deliberately empty: absorb the dead call */ }
static std::atomic<uint64_t> s_gri_nullvcalls{0};

static void gameroominit_null_vcall(void* /*addr*/, DobbyRegisterContext* ctx) {
    if (ARCH_DREG(ctx, 8) == 0) {
        ARCH_DREG(ctx, 8) = reinterpret_cast<uint64_t>(&vcall_noop_stub);
        uint64_t n = s_gri_nullvcalls.fetch_add(1, std::memory_order_relaxed) + 1;
        if (n <= 8 || (n % 250) == 0)
            logger::log_info("GRIGUARD", "gameRoomInit: NULL vtable[0x90] on a bare cEm — "
                                         "call absorbed, room init continues [%lu]", (unsigned long)n);
    }
}

// EmSetFromList2(unsigned id, unsigned flags) @0x5EE9A6C — the SPAWN-LIST path.
// The construct remap is too late for this one: EmSetFromList2 runs BEFORE
// cEmMgr::construct, and for an id the room cannot build it dereferences missing
// data and faults. The safe-call guard "recovers" it by returning 0/0.0, which
// leaves the spawn half-built and the process dies shortly after with no
// tombstone. Observed every single time with id 0x59, while every other id the
// randomiser placed passed cleanly.
//
// Fix: apply the SAME crossover LUT to the id argument (X0) at entry, so an
// unbuildable id becomes the inert object before the function ever reads its
// data. Identical mechanism to crossover_remap_construct, just an earlier point
// and a different register. Entry is `str x25,[sp,#-0x50]!` — position
// independent, so DobbyInstrument can relocate it safely (unlike a thunk).
//
// Spawn COUNT and randomiser freedom are unchanged: the slot still spawns, it
// just spawns something the room can actually construct.
static std::atomic<uint64_t> s_esfl_hits{0};

static void emsetfromlist_remap_id(void* /*addr*/, DobbyRegisterContext* ctx) {
    uint8_t id = (uint8_t)(ARCH_DREG(ctx, 0) & 0xFF);
    uint8_t to = s_crossover_lut[id];
    if (to && to != id) {
        ARCH_DREG(ctx, 0) = (ARCH_DREG(ctx, 0) & ~0xFFULL) | to;
        uint64_t n = s_esfl_hits.fetch_add(1, std::memory_order_relaxed) + 1;
        if (n <= 16 || (n % 250) == 0)
            logger::log_info("XEMAP", "EmSetFromList2 id 0x%02X -> 0x%02X (unbuildable here; "
                                      "remapped BEFORE the list read) [%lu]",
                             id, to, (unsigned long)n);
    }
}

// EmSetFromList() @0x5EE9610 — the WHOLE-LIST spawn pass. Unlike EmSetFromList2
// it takes NO arguments, so there is no id register to remap: it reads every id
// straight out of the global spawn list. From the decompile:
//     for (i = 0; i != 256; ++i) {
//         flags = pG + 32*i + 21660;          // (*flags & 3) == 1 => slot active
//         id    = *(uint8_t*)(pG + 32*i + 21661);
//         ... construct(id) ...
//         (*(void(**)(void*))(enemy->vtable + 40))(enemy);   // vtable[0x28]
//     }
// which is exactly the 32-byte stride / 255 slots the randomiser rewrites. An id
// the room cannot build produces an enemy whose vtable+0x28 is garbage, and the
// final virtual call jumps to it:
//     SIGSEGV fault=0x13c pc=0x13c (unmapped?) cause: EmSetFromList
//     tombstone #00 pc ... <anonymous:...>     (executing outside any library)
//
// So sanitise the DATA before the pass reads it: walk the 256 slots and swap any
// unbuildable id for its LUT substitute. Same LUT, same substitutions, applied to
// the list instead of a register. Spawn count and randomiser choice are untouched
// — only ids that would guarantee a bad construct are replaced.
static std::atomic<uint64_t> s_esfl_slots{0};
static uintptr_t s_esfl_pg_addr = 0;

// ⚠ MUST be a proper hook (install_at), NOT a DobbyInstrument.
// EmSetFromList's first instruction is
//     5ee9610  str d8, [sp, #-0x70]!
// i.e. a CALLEE-SAVED FP register stored with SP PRE-INDEX WRITEBACK.
// DobbyInstrument relocating that corrupts the frame, and the game died with
//     SIGBUS  PC = LR = X30 = 0x0101010101010101   (RET into a smashed stack)
//     X15/X20/X23 = the pG address this callback is passed
// EmSetFromList2 gets away with an instrument because its entry is
// `str x25,[sp,#-0x50]!` — an INTEGER store. Never assume "starts with str =
// safe to instrument"; check whether it writes back SP and which bank it saves.
static void emsetfromlist_sanitize_pre(NativeCallContext& /*ctx*/) {
    if (!s_esfl_pg_addr) return;
    uintptr_t pg = *reinterpret_cast<volatile uintptr_t*>(s_esfl_pg_addr);
    if (!pg) return;
    // Validate the list block ONCE, not per slot. ue::is_mapped_ptr is an msync
    // syscall (~500ns) and its own header says "not in hot loops" — calling it
    // 256x per spawn pass was 256 syscalls. The list is a fixed 256 x 32-byte
    // block, so probing the first and last slot proves the whole range.
    const uintptr_t first = pg + 21660;
    const uintptr_t last  = pg + 32 * 255 + 21661;
    if (!ue::is_mapped_ptr(reinterpret_cast<void*>(first)) ||
        !ue::is_mapped_ptr(reinterpret_cast<void*>(last)))
        return;
    uint32_t fixed = 0;
    for (int i = 0; i < 256; ++i) {
        uint8_t* flags = reinterpret_cast<uint8_t*>(pg + 32 * i + 21660);
        uint8_t* idp   = flags + 1;
        if ((*flags & 3) != 1) continue;         // slot not active; leave it alone
        uint8_t id = *idp;
        uint8_t to = s_crossover_lut[id];
        if (to && to != id) { *idp = to; ++fixed; }
    }
    if (fixed) {
        uint64_t n = s_esfl_slots.fetch_add(fixed, std::memory_order_relaxed) + fixed;
        logger::log_info("XEMAP", "EmSetFromList: sanitised %u spawn-list slot(s) before the pass "
                                  "(unbuildable ids -> inert object) [total %lu]",
                         fixed, (unsigned long)n);
    }
}

// ═══════════════════════════════════════════════════════════════════════════
// "UNKILLABLE BOSS" — the keep-alive clamp in LifeDownSet2
// ═══════════════════════════════════════════════════════════════════════════
// Found with a HARDWARE WATCHPOINT on a live U3's HP (cEm+0x3F0), not by
// reading code: exactly ONE writer, 3 hits while the player shot it —
//     libUE4.so + 0x5EEF1F8   inside LifeDownSet2(cEm*, dmg, ...)
//
//     v31 = *((int16*)a1 + 504);        // 504*2 = 0x3F0 = current HP
//     if (a2 > v31) a2 = v31;           // clamp damage to remaining HP
//     v33 = v31 - a2;                   // new HP
//     if (v33 <= 0 && (a4 & 1) != 0)    // a4 bit0 = "keep this enemy alive"
//         v33 = 1;                      // <-- floored at 1, forever
//     *((int16*)a1 + 504) = v33;        // 0x5EEF1F8
//
// in ARM64:
//     5eef1e0  and   w9, w20, #1        ; w9 = a4 & 1
//     5eef1e4  cmp   w10, #0
//     5eef1e8  ccmp  w9, #0, #4, le
//     5eef1ec  csinc w8, w8, wzr, eq    ; flag set -> w8 = 1
//
// So the damage ALWAYS landed — U3 was not missing hitboxes and its YarareAdd
// regions were fine. The caller simply passes "never let this one die", which is
// correct for scripted encounters and wrong for a boss spawned out of context.
//
// Clearing bit 0 of a4 (X3) for SELECTED enemy ids lets HP reach 0 so the normal
// death path runs — animation included. A blanket byte-patch of the clamp would
// also kill enemies the game intends to keep alive during scripted sequences, so
// this is opt-in per em id.
//
// MUST be install_at(), NOT DobbyInstrument: LifeDownSet2 opens with
//     5eeef88  str d8, [sp, #-0x50]!
// a callee-saved FP register stored with SP pre-index writeback — instrumenting
// that is what produced SIGBUS PC=LR=X30=0x0101010101010101 on EmSetFromList.
static uint8_t s_killable_em[256] = {0};        // [emId] = 1 -> allow it to die
static std::atomic<uint64_t> s_keepalive_cleared{0};

static void lifedown_keepalive_pre(NativeCallContext& ctx) {
    if ((ctx.x[3] & 1ULL) == 0) return;          // clamp not requested — nothing to do
    const void* em = reinterpret_cast<const void*>(ctx.x[0]);
    if (!em) return;
    uint8_t emId = *(reinterpret_cast<const volatile uint8_t*>(em) + 0x118);
    if (!s_killable_em[emId]) return;            // not one we were asked to free
    ctx.x[3] &= ~1ULL;                           // drop "keep alive" -> HP may reach 0
    uint64_t n = s_keepalive_cleared.fetch_add(1, std::memory_order_relaxed) + 1;
    if (n <= 8 || (n % 100) == 0)
        logger::log_info("KILLABLE", "LifeDownSet2: cleared keep-alive for em 0x%02X — "
                                     "HP may now reach 0 [%lu]", emId, (unsigned long)n);
}

bool install_lifedown_keepalive_fix(uintptr_t lifedownset2) {
    if (!lifedownset2) return false;
    HookId id = install_at(reinterpret_cast<void*>(lifedownset2), "__lifedown_keepalive",
                           lifedown_keepalive_pre, nullptr, "CutContentRestorer:killable");
    if (!id) {
        logger::log_error("KILLABLE", "install_at failed at LifeDownSet2 0x%lX",
                          (unsigned long)lifedownset2);
        return false;
    }
    logger::log_info("KILLABLE", "LifeDownSet2 keep-alive fix installed @0x%lX — flagged enemies "
                                 "are no longer floored at 1 HP", (unsigned long)lifedownset2);
    return true;
}

void set_em_killable(uint32_t em_id, bool on) {
    if (em_id > 255) return;
    s_killable_em[em_id] = on ? 1 : 0;
    logger::log_info("KILLABLE", "em 0x%02X killable = %s", em_id, on ? "YES" : "no");
}

uint64_t keepalive_cleared_count() { return s_keepalive_cleared.load(std::memory_order_relaxed); }

bool install_emsetfromlist_sanitize(uintptr_t entry, uintptr_t pg_addr) {
    if (!entry || !pg_addr) return false;
    s_esfl_pg_addr = pg_addr;
    // install_at() = DobbyHook + trampoline, which relocates the whole prologue
    // properly. DobbyInstrument on this entry smashed the stack (see the note on
    // emsetfromlist_sanitize_pre): its first instruction stores a callee-saved FP
    // register with SP pre-index writeback.
    HookId id = install_at(reinterpret_cast<void*>(entry), "__emsetfromlist_sanitize",
                           emsetfromlist_sanitize_pre, nullptr, "CutContentRestorer:esfl");
    if (!id) {
        logger::log_error("XEMAP", "install_at failed at EmSetFromList 0x%lX",
                          (unsigned long)entry);
        return false;
    }
    logger::log_info("XEMAP", "EmSetFromList list sanitiser installed @0x%lX (pG @0x%lX) — the "
                              "spawn list is cleaned before the 256-slot pass reads it",
                     (unsigned long)entry, (unsigned long)pg_addr);
    return true;
}

bool install_emsetfromlist_id_remap(uintptr_t entry) {
    if (!entry) return false;
    if (DobbyInstrument(reinterpret_cast<void*>(entry), emsetfromlist_remap_id) != RT_SUCCESS) {
        logger::log_error("XEMAP", "DobbyInstrument failed at EmSetFromList2 0x%lX",
                          (unsigned long)entry);
        return false;
    }
    logger::log_info("XEMAP", "EmSetFromList2 id remap installed @0x%lX — unbuildable ids are "
                              "substituted before the spawn-list read (no fault to recover)",
                     (unsigned long)entry);
    return true;
}

bool install_gameroominit_vcall_guard(uintptr_t site) {
    if (!site) return false;
    if (DobbyInstrument(reinterpret_cast<void*>(site), gameroominit_null_vcall) != RT_SUCCESS) {
        logger::log_error("GRIGUARD", "DobbyInstrument failed at 0x%lX", (unsigned long)site);
        return false;
    }
    logger::log_info("GRIGUARD", "gameRoomInit NULL-vcall guard installed @0x%lX — a bare cEm "
                                 "(whose vtable+0x90 is NULL) no longer BLRs 0 during room init",
                     (unsigned long)site);
    return true;
}

bool install_crossover_enemy_remap(uintptr_t construct_entry) {
    if (!construct_entry) return false;
    // Build the LUT, falling back to em09 (ganado) for any unsupported target.
    int mapped = 0;
    for (const auto& m : kCrossoverMap) {
        uint8_t to = m.to;
        // Object ids (construct cases 80-97, 255) are handled by construct's own
        // switch, NOT ArmEmCallProlog, so is_em_id_supported (which reads the
        // prolog jump table) doesn't apply to them — take them verbatim. Only
        // real-enemy targets (< 0x50) are validated, falling back to em09.
        if (to < 0x50 && !is_em_id_supported(to)) to = 0x09;
        s_crossover_lut[m.from] = to;
        if (to) ++mapped;
    }
    if (mapped == 0) {
        logger::log_error("XEMAP", "no supported remap target (em09 missing?) — crossover remap skipped");
        return false;
    }

    // ── GENERAL SAFETY NET: every id ArmEmCallProlog can't build ─────────
    // 0x60-0x6F above was never the whole problem — it was just the range we
    // had names for. ANY id whose prolog case is the switch default hits the
    // exact same stale-EmInitFunc path, and the engine never null-checks it.
    // Observed live: the spawn path faulted repeatedly with
    //     [NHOOK] Hook 'EmSetFromList2' original crashed (signal 11) [fault N/8]
    // and because the safe-call guard returns 0/0.0 each time, the spawn is left
    // half-built, the same slot faults again, and the stack eventually dies
    // (SEGV_ACCERR on [anon:stack_and_tls]). Recovering the fault is not enough;
    // the id has to never reach construct in the first place.
    //
    // This does NOT cap or reweight anything: the same number of enemies spawn,
    // the randomiser still picks freely. Ids the room genuinely cannot build are
    // substituted with the inert object (exactly what the ema-series already do),
    // which is the one target proven 100% stable — construct case 80 makes a bare
    // cModel, never calls EmReadSearch and never runs IK/motion.
    //
    // Range note: only 0x00-0x4F are real enemies driven by the prolog table.
    // 0x50+ are construct's own object cases and must be left alone.
    // START AT 3, NOT 0. is_em_id_supported does `idx = id - 3` and returns false
    // for anything below the switch, so ids 0/1/2 report "unsupported" — but they
    // are NOT enemies, they are empty-slot / sentinel values. Netting them turned
    // every empty list slot into a spawned inert object:
    //     [XEMAP] crossover em 0x00 -> em 0x50 ...
    // which is far worse than the crash it was meant to prevent. Only ids that are
    // genuinely inside the prolog switch but land on its default case qualify
    // (per IDA that's 75/78 = em4b/em4e, the vehicles + Houdai cannon).
    int netted = 0;
    for (int id = 3; id < 0x50; ++id) {
        if (s_crossover_lut[id]) continue;              // explicitly mapped above
        if (is_em_id_supported((uint32_t)id)) continue; // room can build it — leave it
        s_crossover_lut[id] = kInertObj;
        ++netted;
    }
    if (netted)
        logger::log_info("XEMAP", "safety net: %d additional unsupported em id(s) -> inert object "
                                  "(same spawn count, no stale init, no EmSetFromList2 fault)", netted);
    if (DobbyInstrument(reinterpret_cast<void*>(construct_entry),
                        crossover_remap_construct) != RT_SUCCESS) {
        logger::log_error("XEMAP", "DobbyInstrument failed at construct 0x%lX", (unsigned long)construct_entry);
        return false;
    }
    logger::log_info("XEMAP", "crossover enemy remap installed @0x%lX — ids 0x60-0x6F -> real base enemies "
                              "(%d mapped; 0x68->em18, 0x66->em46, 0x6C/6D/6F->em4c/4d/4f, ema-series->em09)",
                     (unsigned long)construct_entry, mapped);
    return true;
}

// ═══════════════════════════════════════════════════════════════════════
// U3 (em32) — make it KILLABLE outside its own level
// ═══════════════════════════════════════════════════════════════════════
// U3 "It" is emId 50 = 0x32 = cEm32. Spawn it anywhere but its scripted level
// and it is invulnerable. Same root as the fault-0x180 crash — one bug, two
// symptoms. From sub_5E49AA0 (U3's init):
//
//     v49 = *(_QWORD *)(a1 + 3965);          // the parts model from SetObj00
//     if (v49) { ...; v50 = *(cModel **)(a1 + 3965); }
//     else     { v50 = nullptr; }            // checked...
//     VR4CreateEmSubObject(*(int **)(*((_QWORD *)v50 + 48) + 24LL), a1, v50);
//                                   // ...then *(v50 + 384) => NULL + 0x180. Boom.
//
// And crucially, EVERYTHING BELOW that line is U3's combat setup:
//     YarareInit(a1, ...); YarareAdd(a1, a1+1349, 3, 5, ...);   // ~28 of them
// YarareAdd registers the DAMAGE REGIONS. A crash guard "fixes" the crash by
// siglongjmp-ing out BEFORE those ever run, so U3 spawns with no hitboxes at all
// — which is exactly why it stopped crashing and became unkillable. Guarding was
// never going to make it killable; the init has to actually COMPLETE.
//
// Why the parts model is NULL:
//     SetObj00(U3_archive + [U3_archive+596],        // its own archive — fine
//              [pG+0x68] + [[pG+0x68]+20], ...)      // a DIFFERENT global archive
// The parts pull their skeleton from the global/stage archive at pG+0x68, which
// outside U3's level is not the one holding them, so cModel::modelInit fails and
// SetObj00 returns 0. Compare U3's MAIN model, which the same function builds from
// its OWN archive:
//     cModel::modelInit(a1, arch + [arch+16], arch + [arch+20]);
//
// So: when SetObj00 fails while we are inside U3's init, retry it with U3's own
// archive for that second parameter — the same source the main model uses. If the
// retry builds the model, v49 is non-NULL, the deref never happens, the init runs
// to completion, YarareAdd registers the hitboxes, and U3 is killable anywhere.
// Two ENTRY hooks, no mid-function patching.
static thread_local uint64_t s_u3_cEm = 0;      // non-zero <=> inside em32's init
static std::atomic<uint32_t> s_u3_rescued{0};
static std::atomic<bool>     s_u3_enabled{true};

using U3InitFn    = uint64_t (*)(uint64_t);
using U3SetObj00Fn = uint64_t (*)(uint64_t, uint64_t, void*, void*);
static U3InitFn     s_u3_init_orig  = nullptr;
static U3SetObj00Fn s_u3_setobj_orig = nullptr;

static uint64_t u3_init_thunk(uint64_t cEm) {
    // Scope the SetObj00 rescue to U3's init only — SetObj00 is shared by many
    // enemies and a global retry could paper over a legitimate failure elsewhere.
    uint64_t prev = s_u3_cEm;
    s_u3_cEm = cEm;
    uint64_t r = s_u3_init_orig(cEm);
    s_u3_cEm = prev;
    return r;
}

static uint64_t u3_setobj00_thunk(uint64_t a1, uint64_t a2, void* a3, void* a4) {
    uint64_t r = s_u3_setobj_orig(a1, a2, a3, a4);
    if (r || !s_u3_cEm || !s_u3_enabled.load(std::memory_order_relaxed))
        return r;

    // Failed, and we're inside U3's init. Retry with U3's OWN archive for the
    // skeleton param, mirroring what modelInit does for U3's main model.
    uint64_t arch = 0;
    __builtin_memcpy(&arch, reinterpret_cast<void*>(s_u3_cEm + 1120), sizeof(arch));
    if (!arch) return r;
    uint32_t off20 = *reinterpret_cast<volatile uint32_t*>(arch + 20);
    uint64_t a2_own = arch + off20;
    if (a2_own == a2) return r;          // already what we'd try — nothing to gain

    r = s_u3_setobj_orig(a1, a2_own, a3, a4);
    if (r) {
        uint32_t n = s_u3_rescued.fetch_add(1, std::memory_order_relaxed) + 1;
        if (n <= 4) {
            logger::log_info("U3", "parts model rebuilt from U3's own archive "
                                   "(stage archive at pG+0x68 doesn't have it here) — "
                                   "init can now reach YarareAdd, so U3 is killable [%u]", n);
        }
    }
    return r;
}

bool install_u3_killable_fix(uintptr_t em32_init, uintptr_t setobj00) {
    if (!em32_init || !setobj00) {
        logger::log_error("U3", "null address (init=0x%lX setobj00=0x%lX)",
                          (unsigned long)em32_init, (unsigned long)setobj00);
        return false;
    }
    if (s_u3_init_orig && s_u3_setobj_orig) return true;   // idempotent
    if (!s_u3_init_orig &&
        DobbyHook(reinterpret_cast<void*>(em32_init),
                  reinterpret_cast<dobby_dummy_func_t>(u3_init_thunk),
                  reinterpret_cast<dobby_dummy_func_t*>(&s_u3_init_orig)) != RT_SUCCESS) {
        s_u3_init_orig = nullptr;
        logger::log_error("U3", "DobbyHook failed on em32 init @0x%lX", (unsigned long)em32_init);
        return false;
    }
    if (!s_u3_setobj_orig &&
        DobbyHook(reinterpret_cast<void*>(setobj00),
                  reinterpret_cast<dobby_dummy_func_t>(u3_setobj00_thunk),
                  reinterpret_cast<dobby_dummy_func_t*>(&s_u3_setobj_orig)) != RT_SUCCESS) {
        s_u3_setobj_orig = nullptr;
        logger::log_error("U3", "DobbyHook failed on SetObj00 @0x%lX", (unsigned long)setobj00);
        return false;
    }
    logger::log_info("U3", "killable-anywhere fix installed (em32 init @0x%lX + SetObj00 @0x%lX): "
                           "a failed parts build now retries from U3's own archive so the init "
                           "reaches YarareAdd (its damage regions) instead of dying at NULL+0x180",
                     (unsigned long)em32_init, (unsigned long)setobj00);
    return true;
}

uint32_t u3_rescued_count() { return s_u3_rescued.load(std::memory_order_relaxed); }

// ═══════════════════════════════════════════════════════════════════════
// LASER SIGHT — aiming at an enemy with no part 0 killed the game
// ═══════════════════════════════════════════════════════════════════════
//     fault addr 0x80
//     MTXMultVec+4
//     GetWepTargetPos(Vec*, Vec*, uint, uint, cEm**, uint*)+980
//     AVR4GamePlayerGun::UpdateLaserSight(float)+700   <- every frame you aim
//
//     5eef82c  MOV X0, X23              ; the cEm
//     5eef830  MOV W1, WZR              ; part index 0
//     5eef834  BL  cModel::getPartsPtr  ; -> NULL when the rig has no part 0
//     5eef844  B.HI loc_5EEF8C4
//     5eef8c4  ADD X1, X0, #0x80        ; NULL + 0x80 = 0x80
//     5eef8d0  BL  MTXMultVec           ; LDP S2,S3,[X1] -> fault 0x80
// getPartsPtr correctly returns NULL for a crossover enemy whose rig lacks that
// bone; the caller adds 0x80 and hands it to MTXMultVec unchecked. So merely
// POINTING THE LASER at such an enemy kills the game.
//
// Fixed at the SOURCE rather than by recovery. Crash guard v2 restored the
// siglongjmp recovery (dispatch_full's guard IS live again, and a global
// instruction-skip mode covers this exact fault too) — but this fires every
// single frame you hold the laser on the enemy, and recovering a per-frame
// fault means a signal + handler + siglongjmp 60x/sec. Neutralising the NULL
// at the source is strictly cheaper, so we keep doing that here.
//
// Fix the actual NULL, the way em32 site 2 was fixed (and that one held):
// one instrument, and when getPartsPtr returned NULL point X0 at a zeroed buffer.
// MTXMultVec then reads zeros and writes a zero vector — the laser simply gets no
// lock-on for that target instead of taking the process down. No-op when the part
// exists, so normal targeting is untouched. ONE instrument: nothing else is hooked
// within 16 bytes (the 4-byte-apart disaster is documented at install_em32_*).
alignas(16) static uint8_t g_zero_parts[0x100];   // reads land at +0x80..+0x88

static void laser_null_parts_to_zero(void* addr, DobbyRegisterContext* ctx) {
    (void)addr;
    if (ARCH_DREG(ctx, 0) == 0)
        ARCH_DREG(ctx, 0) = reinterpret_cast<uint64_t>(g_zero_parts);
}

// ═══════════════════════════════════════════════════════════════════════
// GENERIC NULL-RETURN GUARD — the engine-wide audit's other 3,900 sites
// ═══════════════════════════════════════════════════════════════════════
// Audit of the RE4 code range (0x5D00000-0x6250000): 14091 functions, 3456 that
// can return NULL, and after taint-tracking every BL call site (X0 tainted, taint
// KILLED on redefinition, stop at first CBZ/CBNZ/CMP-vs-0 or first deref):
//
//     38 functions have callers that deref the result with NO null check,
//     3999 unguarded deref sites. FOUR functions are 98% of them:
//        cRoomData::getRoomSavePtr  2975/3176   0x61809e0
//        SmdGetObjPtr                651/2300   0x6198858
//        cEmWrap::getPtr             158/754    0x5d7e4b8
//        SceAtPtr                    125/255    0x6187c04
//
// The devs KNEW these return NULL — SmdGetObjPtr logs "SmdGetObjPtr() invalid ID
// [%d] used" and cEmWrap::getPtr logs "EM_SET_NO(%d) cEmWrap::getPtr error" — and
// then thousands of callers deref anyway. That is the whole crash family.
//
// A plain zeroed dummy is NOT safe for these three, and the checks say why:
//   * loops that EXIT on NULL would spin forever on a non-NULL dummy
//        getRoomSavePtr 3, SmdGetObjPtr 3, cEmWrap::getPtr 8
//   * callers that BLR through the result's vtable would call a NULL slot —
//     WORSE than the original crash. Verified properly (BLR target must be a reg
//     LOADED FROM the returned pointer; the crude "any BLR nearby" count was ~3x
//     inflated): getRoomSavePtr 8, SmdGetObjPtr 29, cEmWrap::getPtr 30.
//
// So the dummy carries a STUB VTABLE (every slot returns 0), and the guard is
// RETURN-ADDRESS AWARE: the handful of loop-exit sites still receive a real NULL,
// everything else gets the dummy. Deny-lists are the exact return addresses from
// the scan, as RVAs.
//
// Why this is strictly better and not a gamble: all four only return NULL for
// INVALID input (bad room id, OOB index, dead cEm, id not found) — cases where the
// caller was going to fault anyway. The dummy never displaces working behaviour;
// it only replaces a SIGSEGV with an inert object. Writes land in the dummy and
// are discarded, which for an invalid room is exactly right.
extern "C" uint64_t nullguard_stub_ret0() { return 0; }
alignas(16) static void*   g_stub_vtable[128];
alignas(16) static uint8_t g_null_dummy[0x1000];
static std::atomic<bool>   g_null_dummy_ready{false};

static void null_dummy_init() {
    if (g_null_dummy_ready.load(std::memory_order_acquire)) return;
    for (auto& s : g_stub_vtable) s = reinterpret_cast<void*>(&nullguard_stub_ret0);
    *reinterpret_cast<void**>(g_null_dummy) = g_stub_vtable;   // obj[0] = vtable
    g_null_dummy_ready.store(true, std::memory_order_release);
}

using NrgFn = uint64_t (*)(uint64_t, uint64_t, uint64_t, uint64_t,
                          uint64_t, uint64_t, uint64_t, uint64_t);
struct NullRetSlot {
    NrgFn             orig = nullptr;
    const char*      name = "";
    const uintptr_t* deny = nullptr;   // RVAs that MUST still see NULL
    size_t           deny_n = 0;
    std::atomic<uint64_t> subs{0};
};
static NullRetSlot g_nrg[6];

static uint64_t null_ret_common(int slot, uint64_t a0, uint64_t a1, uint64_t a2, uint64_t a3,
                                  uint64_t a4, uint64_t a5, uint64_t a6, uint64_t a7,
                                  void* ret_addr) {
    NullRetSlot& s = g_nrg[slot];
    uint64_t r = s.orig(a0, a1, a2, a3, a4, a5, a6, a7);
    if (r) return r;
    uintptr_t base = symbols::lib_base();
    uintptr_t rva  = base ? (reinterpret_cast<uintptr_t>(ret_addr) - base) : 0;
    for (size_t i = 0; i < s.deny_n; ++i)          // a loop that terminates on NULL
        if (s.deny[i] == rva) return 0;            // -> must keep seeing NULL
    null_dummy_init();
    uint64_t n = s.subs.fetch_add(1, std::memory_order_relaxed) + 1;
    if (n <= 2 || (n % 500) == 0)
        logger::log_info("NULLGUARD", "%s returned NULL -> inert dummy (caller rva 0x%lX, %lu so far)",
                         s.name, (unsigned long)rva, (unsigned long)n);
    return reinterpret_cast<uint64_t>(g_null_dummy);
}

template <int N>
static uint64_t nrg_thunk(uint64_t a0, uint64_t a1, uint64_t a2, uint64_t a3,
                         uint64_t a4, uint64_t a5, uint64_t a6, uint64_t a7) {
    return null_ret_common(N, a0, a1, a2, a3, a4, a5, a6, a7, __builtin_return_address(0));
}

// Deny-lists: exact RETURN addresses (RVA) of call sites whose loop EXITS on NULL.
static const uintptr_t kDenyRoomSave[]  = {0x6188aa0, 0x6188c64, 0x6188e28};
static const uintptr_t kDenySmdGetObj[] = {0x5d3a5c0, 0x5d4481c, 0x5d449dc};
static const uintptr_t kDenyEmWrapGet[] = {0x60eb114, 0x61693a0, 0x61693c8, 0x61693f0,
                                           0x616c4b4, 0x616c8a8, 0x616cc9c, 0x616d0a0};

bool install_null_return_guards() {
    struct Spec { uintptr_t rva; const char* name; const uintptr_t* deny; size_t n; NrgFn thunk; };
    static const Spec specs[] = {
        {0x61809e0, "cRoomData::getRoomSavePtr", kDenyRoomSave,  3, &nrg_thunk<0>},
        {0x6198858, "SmdGetObjPtr",              kDenySmdGetObj, 3, &nrg_thunk<1>},
        {0x5d7e4b8, "cEmWrap::getPtr",           kDenyEmWrapGet, 8, &nrg_thunk<2>},
        {0x6187c04, "SceAtPtr",                  nullptr,        0, &nrg_thunk<3>},
    };
    uintptr_t base = symbols::lib_base();
    if (!base) { logger::log_error("NULLGUARD", "lib_base unavailable"); return false; }
    null_dummy_init();
    int ok = 0;
    for (int i = 0; i < 4; ++i) {
        if (g_nrg[i].orig) { ++ok; continue; }        // idempotent across mod reloads
        g_nrg[i].name   = specs[i].name;
        g_nrg[i].deny   = specs[i].deny;
        g_nrg[i].deny_n = specs[i].n;
        void* fn = reinterpret_cast<void*>(base + specs[i].rva);
        if (DobbyHook(fn, reinterpret_cast<dobby_dummy_func_t>(specs[i].thunk),
                      reinterpret_cast<dobby_dummy_func_t*>(&g_nrg[i].orig)) != RT_SUCCESS) {
            g_nrg[i].orig = nullptr;
            logger::log_error("NULLGUARD", "DobbyHook failed for %s @0x%lX",
                              specs[i].name, (unsigned long)(base + specs[i].rva));
            continue;
        }
        ++ok;
        logger::log_info("NULLGUARD", "%s guarded (deny-list %zu sites keep real NULL)",
                         specs[i].name, specs[i].n);
    }
    logger::log_info("NULLGUARD", "%d/4 installed — covers ~3909 unguarded derefs "
                                  "(getRoomSavePtr 2975, SmdGetObjPtr 651, cEmWrap::getPtr 158, "
                                  "SceAtPtr 125)", ok);
    return ok > 0;
}

uint64_t null_guard_substitutions() {
    uint64_t t = 0;
    for (auto& s : g_nrg) t += s.subs.load(std::memory_order_relaxed);
    return t;
}

// ═══════════════════════════════════════════════════════════════════════
// cModel::getPartsPtr — THE ROOT OF THE WHOLE CROSSOVER CRASH FAMILY
// ═══════════════════════════════════════════════════════════════════════
// Scanned every call site in libUE4 (taint X0 from the BL, stop at the first
// CBZ/CBNZ/CMP-vs-0 or the first deref):
//     cModel::getPartsPtr — 2420 call sites, 1101 UNGUARDED, 82 guarded
// 1101 places dereference this pointer without ever testing it. That is not a
// handful of oversights, it is the engine's house style: "the part is always
// there", which holds for authored rooms and collapses the moment an enemy is
// somewhere it was not authored. Patching 1101 sites is not a plan; patching the
// ONE function they all call is.
//
// The function itself (0x5F81AFC), exactly as shipped:
//     if ((a2 & 0x80000000) == 0) {          // a2 >= 0
//         this = *(_QWORD *)(this + 264);    // parts head
//         if (this) {
//             if ((*(_BYTE *)(v2 + 9) & 0x20))
//                 this += 496LL * a2;             // ARRAY: no bounds check
//             else
//                 for (; a2; --a2)
//                     this = *(_QWORD *)(this + 264);  // LIST: no null check
//         }
//     }
//     return this;                           // may be NULL
// TWO defects, both ours to fix:
//   * LIST mode walks a2 links with no null check, so a model with fewer parts
//     than asked derefs *(NULL + 264). 264 = 0x108 — that IS the cModel::setParent
//     fault 0x108 in the crash table, i.e. the crash is INSIDE this walk.
//   * It returns NULL, and 1101 callers deref it. IKInit does *(ret + 472) =>
//     fault 0x1d8; GetWepTargetPos does ADD X1,ret,#0x80 => fault 0x80. Both are
//     in the tombstones.
//
// Fix: return a zeroed dummy instead of NULL, so every unguarded deref reads
// zeros. Verified safe before writing a line of it — the one way this could
// backfire is a caller doing `while (getPartsPtr(i++))`, which a non-NULL dummy
// would spin forever. A scan for "BL getPartsPtr; CBZ X0, <target outside a
// back-edge>" found **0** such loops, which is exactly what the code predicts:
// in ARRAY mode it never returns NULL for a2>=0, so NULL-termination was never a
// usable idiom here. Nothing can hang on this.
//
// Cost: the 82 sites that DO test for NULL now see a non-NULL zeroed part and take
// their "part exists" branch with zeros — an origin-positioned, all-zero part
// instead of a skip. That is a visual/no-op difference, not a crash, and it buys
// 1101 crash sites. Stated plainly because it IS a real trade.
//
// NOT FIXED and deliberately left alone: ARRAY mode's `+= 496 * a2` has no bounds
// check, so an out-of-range index returns an out-of-bounds GARBAGE pointer (not
// NULL) that no null check anywhere can catch. Bounding it needs the part count,
// which is not a field I have identified yet. That is a strong candidate for the
// still-unsolved EmSetFromList garbage-pointer tombstones (27/28) — do not claim
// it is fixed.
alignas(16) static uint8_t g_dummy_parts[0x800];   // seen derefs: +0xBC, +0x80, +0x1D8, +264
static std::atomic<bool>     s_dummy_parts_ready{false};
static std::atomic<uint64_t> s_getparts_dummies{0};

// A NULL check is NOT enough here, and a tombstone proved it:
//     #00 getparts_safe+68            <- `*(self + 264)`, fault 0x0040026039045611
//     #01 IKInit+392  #02 MotionSetCore+552  #03 cRoutine::moveWepDown+104
//     x0 = 0xf940026039045509   x1 = 0xfe (idx 254)
// x0 is not a pointer at all — 0xf9400260 is `ldr x0,[x19]` and 0x39045509 is
// `strb w9,[x8,#0x115]`. That is ARM64 INSTRUCTION ENCODING being used as a
// cModel*, and `if (!self)` waved it straight through into the deref.
//
// Where it came from is written a few lines up, in the ARRAY-mode caveat that was
// knowingly left unfixed: `p + 496*idx` has no bounds check, so an out-of-range
// index hands back an out-of-bounds GARBAGE pointer instead of NULL. Something
// stored that result as a model and handed it back to us later as `self`. idx=254
// here is exactly the out-of-range shape that produces it. So the guard was not
// just failing to catch bad input — it was MANUFACTURING it.
//
// Fix both ends:
//   * validate every pointer before dereferencing it (in), and
//   * never RETURN a pointer that fails the same test (out), which stops the
//     garbage at the source instead of waiting for it to come back as a `self`.
//
// The test is a range/alignment check, not a mapped-memory probe: this is a hot
// path (per motion-set, per model) and a /proc/self/maps consult here would cost
// far more than it saves. It catches the observed failure decisively — user VAs
// on this device are 48-bit, and 0x40026039045509 is ~1.8e16, well past 2^48.
static inline bool plausible_model_ptr(uint64_t p) {
    // PR_TAGGED_ADDR_ENABLE is on for this process, so the top byte is an
    // address tag the CPU ignores — strip it before range-checking, exactly as
    // the hardware does when it computes the faulting address.
    p &= 0x00FFFFFFFFFFFFFFull;
    if (p < 0x10000ull)        return false;   // NULL page / small integer
    if (p >= (1ull << 48))     return false;   // beyond the user address space
    if (p & 7ull)              return false;   // a cModel* is 8-byte aligned
    return true;
}

// Largest sane ARRAY-mode part index. The real part count is a field I still have
// not identified (see the caveat above), so this is a backstop, not a bound: it
// only has to be comfortably above any legitimate index while rejecting the
// wild ones. Observed good indices are small; the crash used 254.
static constexpr int kMaxPartIdx = 512;
static std::atomic<uint64_t> s_getparts_rejects{0};

static uint64_t getparts_safe(uint64_t self, int idx) {
    // Self-pointing chain: any caller that walks the dummy's own +264 link stays
    // inside the dummy instead of falling off into NULL. Same trick as the em32
    // null-model buffer.
    if (!s_dummy_parts_ready.load(std::memory_order_acquire)) {
        *reinterpret_cast<void**>(g_dummy_parts + 264) = g_dummy_parts;
        s_dummy_parts_ready.store(true, std::memory_order_release);
    }
    uint64_t dummy = reinterpret_cast<uint64_t>(g_dummy_parts);

    // IN: reject anything that cannot be a model before touching it. This is the
    // check whose absence produced the tombstone above.
    if (!plausible_model_ptr(self)) {
        s_getparts_rejects.fetch_add(1, std::memory_order_relaxed);
        return dummy;
    }
    if (idx < 0) return self;                       // stock behaviour: returns `this`

    uint64_t p = *reinterpret_cast<volatile uint64_t*>(self + 264);
    if (!plausible_model_ptr(p)) {
        s_getparts_dummies.fetch_add(1, std::memory_order_relaxed);
        return dummy;
    }

    if (*reinterpret_cast<volatile uint8_t*>(self + 9) & 0x20) {
        // ARRAY mode. OUT: an out-of-range idx used to escape as a garbage
        // pointer — the very thing that came back as `self` in the tombstone.
        if (idx > kMaxPartIdx) {
            s_getparts_rejects.fetch_add(1, std::memory_order_relaxed);
            return dummy;
        }
        uint64_t arr = p + 496ull * static_cast<uint32_t>(idx);
        if (!plausible_model_ptr(arr)) {
            s_getparts_rejects.fetch_add(1, std::memory_order_relaxed);
            return dummy;
        }
        return arr;
    }

    for (; idx; --idx) {                            // LIST mode
        p = *reinterpret_cast<volatile uint64_t*>(p + 264);
        if (!plausible_model_ptr(p)) {              // <== the check the game omits
            s_getparts_dummies.fetch_add(1, std::memory_order_relaxed);
            return dummy;
        }
    }
    return p;
}

uint64_t getpartsptr_reject_count() { return s_getparts_rejects.load(std::memory_order_relaxed); }

uint64_t getpartsptr_dummy_count() { return s_getparts_dummies.load(std::memory_order_relaxed); }

bool install_getpartsptr_guard(uintptr_t getparts) {
    if (!getparts) return false;
    static bool installed = false;
    if (installed) { logger::log_info("PARTS", "already installed"); return true; }
    // Full replacement, not a wrapper: the stock body is 10 instructions and is
    // reproduced above exactly, so there is nothing to call through to.
    if (DobbyHook(reinterpret_cast<void*>(getparts),
                  reinterpret_cast<dobby_dummy_func_t>(getparts_safe),
                  nullptr) != RT_SUCCESS) {
        logger::log_error("PARTS", "DobbyHook failed at 0x%lX", (unsigned long)getparts);
        return false;
    }
    installed = true;
    logger::log_info("PARTS", "cModel::getPartsPtr guard installed @0x%lX — NULL now yields a "
                              "zeroed dummy (1101 unguarded derefs in libUE4) and the LIST walk "
                              "null-checks (was: *(NULL+264) = fault 0x108)",
                     (unsigned long)getparts);
    return true;
}

// ═══════════════════════════════════════════════════════════════════════
// XSB TRACK PARSER OVER-RUN — ArmLoadSoundBlockEnemy, SEGV_ACCERR
// ═══════════════════════════════════════════════════════════════════════
// tombstone_30:
//     StrToI<long>+64                       <- SEGV_ACCERR
//     CArmSoundBlock::ExtractTrackIndex+60
//     CArmSoundBlock::ExtractTracksFromXSB+124
//     CArmSoundBlock::TryLoadGenericFromDas+320
//     ArmLoadSoundBlockEnemy(int)+296
//     cEmMgr::construct+756 <- EmSetFromList
//
// This one is a REAL GAME BUG, not a missing null check. ExtractTrackIndex does:
//     if (*a2) {
//         endptr = *a2;
//         result = strtol(*a2, &endptr, 10);            // <== READS FIRST
//         v8 = *(u32*)(hdr + 42);  v9 = *(u32*)(hdr + 30);
//         if (v7 < *(u64*)(this+192) + v8 + v9)         // <== CHECKS AFTER
//             while (...) { ...; if (v7 >= end) break; ... }   // walk IS bounded
//     }
// The game computes the correct end-of-name-table bound and the walk loop honours
// it — but strtol runs on the cursor BEFORE anything validates it. In an authored
// room the .xsb always has as many tracks as the .das asks for, so the cursor never
// starts past the end and the ordering bug is invisible. Give an enemy a room whose
// .xsb has fewer tracks (exactly what "any enemy anywhere" does) and the cursor
// walks off the malloc'd buffer; strtol then reads into the guard page => ACCERR.
// Note it is ACCERR, not MAPERR: the pointer is just past a real allocation.
//
// So: apply the game's OWN bound, computed from its OWN header fields, before the
// read instead of after it. Nothing invented — this is the same expression at
// 0x61af0d4, evaluated one step earlier.
//
// Bailing is safe and does NOT mute the enemy: ArmLoadSoundBlockEnemy already has
// a fallback for exactly this case —
//     if (a1 > 0x4F || (TryLoadGenericFromDas(...) & 1) == 0)
//         LoadGeneric(block, a1 >= 16 ? "em" : "pl", v3);
// TryLoadGenericFromDas returns `*((u64*)this + 2) != 0`, so a skipped track just
// means fewer tracks; if the block ends up empty the game loads generic sounds by
// itself. Worst case is a crossover enemy with generic sounds instead of a crash.
using XsbTrackFn = uint64_t (*)(uint64_t, char**, uint64_t, uint64_t);
static XsbTrackFn s_xsb_track_orig = nullptr;
static std::atomic<uint64_t> s_xsb_skips{0};

static uint64_t xsb_track_guarded(uint64_t self, char** cursor, uint64_t a3, uint64_t a4) {
    if (!self || !cursor || !*cursor) return 0;
    // this+192 = the XSB buffer, this+200 = its header. Both are set by
    // ExtractTracksFromXSB straight from LoadXSBFile, which returns NULL when the
    // file is missing — so a null here means "nothing to parse", not "corrupt".
    uint64_t xsb = *reinterpret_cast<volatile uint64_t*>(self + 192);
    uint64_t hdr = *reinterpret_cast<volatile uint64_t*>(self + 200);
    if (!xsb || !hdr) return 0;
    uint64_t end = xsb + *reinterpret_cast<volatile uint32_t*>(hdr + 42)
                       + *reinterpret_cast<volatile uint32_t*>(hdr + 30);
    uint64_t p = reinterpret_cast<uint64_t>(*cursor);

    // The header-derived [xsb,end) bound is NOT enough on its own: ExtractTracksFromXSB
    // sets BOTH this+192 and this+200 to the same LoadXSBFile buffer, and the cursor is
    // `buffer + hdr[42]`, so `end = buffer + hdr[42] + hdr[30]` scales with the very
    // offset that's garbage on a short/malformed .xsb — p stays < end while pointing
    // PAST the real malloc, and strtol() then reads into the guard page (SEGV_ACCERR).
    // That over-run recurred through this guard. So the authoritative check is: is the
    // cursor actually in mapped, readable memory? strtol may scan a short numeric run,
    // so require the first and last-plausible byte to be readable. If not, skip the
    // track — ArmLoadSoundBlockEnemy's generic-sound fallback covers it (see above).
    bool out_of_table = (p < xsb || p >= end);
    bool unreadable   = !reflection::is_readable_ptr(reinterpret_cast<const void*>(p))
                     || !reflection::is_readable_ptr(reinterpret_cast<const void*>(p + 15));
    if (out_of_table || unreadable) {
        uint64_t n = s_xsb_skips.fetch_add(1, std::memory_order_relaxed) + 1;
        if (n <= 3 || (n % 250) == 0)
            logger::log_info("XSB", "track cursor unsafe (p=0x%lX, table=[0x%lX,0x%lX), %s) — "
                                    "skipped, generic sound fallback takes over (%lu so far)",
                             (unsigned long)p, (unsigned long)xsb, (unsigned long)end,
                             unreadable ? "UNREADABLE" : "off-table", (unsigned long)n);
        return 0;
    }
    return s_xsb_track_orig(self, cursor, a3, a4);
}

bool install_xsb_track_bounds_guard(uintptr_t extract_track_index) {
    if (!extract_track_index) return false;
    if (s_xsb_track_orig) {
        logger::log_info("XSB", "already installed");
        return true;
    }
    if (DobbyHook(reinterpret_cast<void*>(extract_track_index),
                  reinterpret_cast<dobby_dummy_func_t>(xsb_track_guarded),
                  reinterpret_cast<dobby_dummy_func_t*>(&s_xsb_track_orig)) != RT_SUCCESS) {
        s_xsb_track_orig = nullptr;
        logger::log_error("XSB", "DobbyHook failed at 0x%lX", (unsigned long)extract_track_index);
        return false;
    }
    logger::log_info("XSB", "ExtractTrackIndex bounds guard installed @0x%lX — the game's own "
                            "end-of-name-table bound is now applied BEFORE strtol, not after",
                     (unsigned long)extract_track_index);
    return true;
}

// ═══════════════════════════════════════════════════════════════════════
// cEmMark OUTSIDE THE SHOOTING GALLERY — fault addr 0x181
// ═══════════════════════════════════════════════════════════════════════
// cEmMark is the shooting-gallery target. Its move() asks whether the minigame
// is paused, and that reads a GLOBAL manager pointer:
//     60d1b10  ADRP X8, #qword_A597D28@PAGE
//     60d1b14  LDR  X8, [X8,#qword_A597D28@PAGEOFF]   ; the shooting-game mgr
//     60d1b18  LDRB W8, [X8,#0x181]                   ; <== NULL outside R22
//     60d1b1c  CMP  W8, #0
//     60d1b20  CSET W0, NE                            ; return (paused != 0)
// IDA says qword_A597D28 has exactly ONE writer — R22cInit — so the pointer is
// only ever set while the shooting range itself is loaded, and is NULL in every
// other room. armIsShootingGamePaused has exactly ONE caller (cEmMark::move), so
// neutralising it here cannot affect anything but a gallery target.
//
// Redirecting the NULL to a zeroed buffer makes the LDRB read 0, so CSET yields
// W0 = 0 = "not paused" — which is the truthful answer when the minigame is not
// running at all, and lets the mark move like any other enemy.
alignas(16) static uint8_t g_zero_shootgame[0x200];   // the read lands at +0x181

static void shootgame_null_to_zero(void* /*addr*/, DobbyRegisterContext* ctx) {
    if (ARCH_DREG(ctx, 8) == 0)
        ARCH_DREG(ctx, 8) = reinterpret_cast<uint64_t>(g_zero_shootgame);
}

bool install_shootgame_paused_guard(uintptr_t ldrb_site) {
    if (!ldrb_site) return false;
    // Verify it really is `LDRB W8,[X8,#0x181]` before instrumenting it.
    //   LDRB (imm, unsigned offset) = 0x39400000 | (imm12 << 10) | (Rn << 5) | Rt
    const uint32_t kLdrbW8_X8_181 = 0x39400000u | (0x181u << 10) | (8u << 5) | 8u;  // 0x39460508
    uint32_t w = *reinterpret_cast<const uint32_t*>(ldrb_site);
    if (w != kLdrbW8_X8_181) {
        logger::log_warn("EMMARK", "0x%lX is not `LDRB W8,[X8,#0x181]` (insn 0x%08X) — fix skipped",
                         (unsigned long)ldrb_site, w);
        return false;
    }
    if (DobbyInstrument(reinterpret_cast<void*>(ldrb_site),
                        shootgame_null_to_zero) != RT_SUCCESS) {
        logger::log_error("EMMARK", "DobbyInstrument failed at 0x%lX", (unsigned long)ldrb_site);
        return false;
    }
    logger::log_info("EMMARK", "shooting-game null guard installed @0x%lX — a gallery target "
                               "spawned outside R22 now reads 'not paused' instead of SIGSEGV 0x181",
                     (unsigned long)ldrb_site);
    return true;
}

// ═══════════════════════════════════════════════════════════════════════
// ASYNC LOADER before GC init — GGCSingleton NULL -> fault addr 0x8
// ═══════════════════════════════════════════════════════════════════════
// FAsyncLoadingThread::Run's loop polls the GC singleton every tick:
//     68957d4  LDR  X8, [X20]     ; X8 = GGCSingleton (null if GC not yet built)
//     68957d8  ADD  X8, X8, #8
//     68957dc  LDAR W8, [X8]      ; <== null+8 = SIGSEGV 0x8
//     68957e0  CBZ  W8, tick      ; 0 => "GC idle" => run the async tick
// The async thread can start (and loop) before/while GGCSingleton is (re)created
// on a level transition. The crash guard's global null-skip used to absorb this;
// with the guard off it is fatal and the level never finishes loading (black).
// Redirect the null read to a zeroed word so LDAR yields 0 = "GC idle", which is
// the correct answer when there is no GC singleton to be busy — the loader then
// ticks normally and picks up the real singleton on the next iteration.
alignas(16) static uint8_t g_zero_gcsingleton[16];

static void gcsingleton_null_to_zero(void* /*addr*/, DobbyRegisterContext* ctx) {
    // X8 here = GGCSingleton + 8; if GGCSingleton was null it is a tiny bad addr.
    if (ARCH_DREG(ctx, 8) < 0x1000)
        ARCH_DREG(ctx, 8) = reinterpret_cast<uint64_t>(g_zero_gcsingleton);
}

bool install_async_gc_singleton_guard(uintptr_t ldar_site) {
    if (!ldar_site) return false;
    const uint32_t kLdarW8_X8 = 0x88DFFD08u;   // LDAR W8, [X8]
    uint32_t w = *reinterpret_cast<const uint32_t*>(ldar_site);
    if (w != kLdarW8_X8) {
        logger::log_warn("ASYNCGC", "0x%lX is not `LDAR W8,[X8]` (insn 0x%08X) — fix skipped",
                         (unsigned long)ldar_site, w);
        return false;
    }
    if (DobbyInstrument(reinterpret_cast<void*>(ldar_site), gcsingleton_null_to_zero) != RT_SUCCESS) {
        logger::log_error("ASYNCGC", "DobbyInstrument failed at 0x%lX", (unsigned long)ldar_site);
        return false;
    }
    logger::log_info("ASYNCGC", "async-loader GGCSingleton null-guard installed @0x%lX — reads 0 (GC idle) "
                                "instead of SIGSEGV 0x8 when the GC singleton isn't up yet",
                     (unsigned long)ldar_site);
    return true;
}

bool install_laser_sight_fix(uintptr_t add_x1_site) {
    if (!add_x1_site) return false;
    // Verify it really is `ADD X1, X0, #0x80` before touching it.
    //   ADD (immediate, 64-bit): sf=1 op=0 S=0 100010 sh imm12 Rn Rd
    //   = 0x91000000 | (0x80 << 10) | (0 << 5) | 1
    const uint32_t kAddX1X0_80 = 0x91020001u;
    uint32_t w = *reinterpret_cast<const uint32_t*>(add_x1_site);
    if (w != kAddX1X0_80) {
        logger::log_warn("LASER", "0x%lX is not `ADD X1,X0,#0x80` (insn 0x%08X) — fix skipped",
                         (unsigned long)add_x1_site, w);
        return false;
    }
    if (DobbyInstrument(reinterpret_cast<void*>(add_x1_site),
                        laser_null_parts_to_zero) != RT_SUCCESS) {
        logger::log_error("LASER", "DobbyInstrument failed at 0x%lX", (unsigned long)add_x1_site);
        return false;
    }
    logger::log_info("LASER", "laser-sight null-parts fix installed @0x%lX — aiming at an enemy "
                              "whose rig has no part 0 now yields no lock-on instead of SIGSEGV 0x80",
                     (unsigned long)add_x1_site);
    return true;
}

// ═══════════════════════════════════════════════════════════════════════
// MINE THROWER fast reload — pure C++, because moveReload is a VTABLE entry
// ═══════════════════════════════════════════════════════════════════════
// The Mine Thrower has no ::InstantReload, so after each shot cObjMine::moveReload
// plays a full animated reload. It is a per-frame state machine on this+1067:
//   1st call (flag==0): let the ORIGINAL run — it re-chambers the next mine.
//                       Blocking it outright leaves the weapon stuck after one shot.
//   2nd call (flag==1): refill (cItemMgr::reload), clear the flags, and skip the
//                       rest of the animation => reload done in ~2 frames.
//
// This logic used to live in a LUA CALLBACK, and moveReload is NOT cold — IDA says
// it is a vtable slot:
//     9d46a40 -> cObjMine::moveFire
//     9d46a48 -> cObjMine::moveDown
//     9d46a50 -> cObjMine::moveReload   <- here
//     9d46a58 -> cObjWep::moveDrop
// i.e. dispatched from cObjWep::move, on the game thread, every frame the weapon
// is reloading — and with the reload cut to ~2 frames you are firing constantly,
// so it fires constantly. That callback raced the shared lua_State and the
// corruption surfaced far away as pc=0x24cc / FMallocBinned2 / atan2f. Same class
// as ScoreControl, DualFire, the Tyrant monitor and NoVignette.
//
// The work is four memory ops and one call, so it belongs in C. Identical
// behaviour, no lua_State, nothing to race.
static std::atomic<bool> s_mt_enabled{true};
static uintptr_t s_mt_itemmgr  = 0;
static uint32_t  s_mt_inprog   = 1067;   // cObjMine: "reload started"
static uint32_t  s_mt_subflag  = 1066;

using MtReloadFn    = uint64_t (*)(void*);     // cItemMgr::reload()
using MtMoveReload  = uint64_t (*)(uint64_t);  // cObjMine::moveReload()
static MtReloadFn   s_mt_reload = nullptr;
static MtMoveReload s_mt_orig   = nullptr;

static uint64_t mt_movereload_thunk(uint64_t self) {
    if (s_mt_enabled.load(std::memory_order_relaxed) && self && s_mt_reload && s_mt_itemmgr) {
        if (*reinterpret_cast<volatile uint8_t*>(self + s_mt_inprog) == 1) {
            // 2nd frame: finish the reload now and skip the animation.
            s_mt_reload(reinterpret_cast<void*>(s_mt_itemmgr));
            *reinterpret_cast<volatile uint8_t*>(self + s_mt_inprog)  = 0;
            *reinterpret_cast<volatile uint8_t*>(self + s_mt_subflag) = 0;
            return 0;   // block the original — this is what the Lua `return true` did
        }
        // 1st frame: fall through so the original re-chambers the next mine.
    }
    return s_mt_orig(self);
}

bool install_minethrower_fast_reload(uintptr_t movereload, uintptr_t itemmgr,
                                     uintptr_t reload_fn, uint32_t inprog_off,
                                     uint32_t subflag_off) {
    if (!movereload || !itemmgr || !reload_fn) {
        logger::log_error("MINETHR", "null address (moveReload=0x%lX itemMgr=0x%lX reload=0x%lX)",
                          (unsigned long)movereload, (unsigned long)itemmgr, (unsigned long)reload_fn);
        return false;
    }
    s_mt_itemmgr = itemmgr;
    s_mt_reload  = reinterpret_cast<MtReloadFn>(reload_fn);
    s_mt_inprog  = inprog_off  ? inprog_off  : 1067;
    s_mt_subflag = subflag_off ? subflag_off : 1066;
    if (s_mt_orig) {                       // idempotent across mod reloads
        logger::log_info("MINETHR", "already installed — refreshed addresses only");
        return true;
    }
    if (DobbyHook(reinterpret_cast<void*>(movereload),
                  reinterpret_cast<dobby_dummy_func_t>(mt_movereload_thunk),
                  reinterpret_cast<dobby_dummy_func_t*>(&s_mt_orig)) != RT_SUCCESS) {
        s_mt_orig = nullptr;
        logger::log_error("MINETHR", "DobbyHook failed at 0x%lX", (unsigned long)movereload);
        return false;
    }
    logger::log_info("MINETHR", "pure-C++ fast reload installed @0x%lX (inProg=+%u subFlag=+%u) "
                                "— no Lua on cObjMine::moveReload (a vtable slot off cObjWep::move)",
                     (unsigned long)movereload, s_mt_inprog, s_mt_subflag);
    return true;
}

void set_minethrower_enabled(bool on) { s_mt_enabled.store(on, std::memory_order_relaxed); }

// ═══════════════════════════════════════════════════════════════════════
// NULL-`this` GUARD — the null check the game forgot
// ═══════════════════════════════════════════════════════════════════════
// A whole family of RE4 crashes is one bug repeated per enemy: an enemy's
// sub-object/model is NULL (routine for cut or unsupported content, whose data
// the room never loaded), the game dereferences it WITHOUT a null check, and it
// dies far from the cause. Observed, all via EmSetFromList2 -> cEmXX::move:
//   cObjChain::setChain  -> fault 0x438   (`*((_QWORD*)this + 135) = a2` on NULL)
//   sub_5E49AA0 (em32)   -> fault 0x180
//   cEm2d::setReset      -> fault 0x0d
// The fault addresses ARE the field offsets — classic NULL + offset.
//
// setChain is the clearest case; the whole function is:
//     *((_QWORD*)this + 135) = a2;  if (a2) return PenClothSet(this);  return this;
// It never checks `this`. Add the check at the ENTRY and the enemy simply has no
// cloth instead of taking the process down.
//
// ENTRY hooks only — deliberately. Patching mid-function is what turned a clean
// `fault 0x180` into `pc = 0x512c662204`: libmodloader loads ~251MB from libUE4,
// past ARM64's +/-128MB branch range, so Dobby must write a 16-byte absolute
// sequence and two hooks <16 bytes apart shred each other. A function entry has
// no neighbour to clobber.
//
// Each guarded function needs its OWN trampoline slot to hold its original, hence
// the templated thunks. 8 args are forwarded (x0-x7 covers every AAPCS64 integer
// arg); v0-v7 are untouched, so float args (e.g. PenClothSet's float) pass through
// intact. Returning 0 matches what these functions return for "nothing to do".
static const int kMaxNullGuards = 8;
using NgFn = uint64_t (*)(uint64_t, uint64_t, uint64_t, uint64_t,
                          uint64_t, uint64_t, uint64_t, uint64_t);
static NgFn s_ng_orig[kMaxNullGuards] = {};
static uintptr_t s_ng_addr[kMaxNullGuards] = {};
// Which pointer to test: -1 = `this` (x0) itself, >=0 = the FIELD at
// x0+off. cModel::setParent needs the latter — `this` is valid there and it
// is *(this+0x108) that is NULL:
//     LDR X8, [X0,#0x108]      ; x0 fine
//     STR X1, [X8,#0x78]       ; X8 == NULL -> fault 0x78
static int64_t s_ng_field[kMaxNullGuards] = {};
// OWN the name. The Lua binding hands us a std::string::c_str() that dies the
// moment the call returns, and the thunk logs it much later, from another thread.
static char s_ng_name[kMaxNullGuards][48] = {};
static std::atomic<uint32_t> s_ng_hits[kMaxNullGuards];
static int  s_ng_count = 0;

template <int N>
static uint64_t ng_thunk(uint64_t a0, uint64_t a1, uint64_t a2, uint64_t a3,
                         uint64_t a4, uint64_t a5, uint64_t a6, uint64_t a7) {
    bool bad = (a0 == 0);
    if (!bad && s_ng_field[N] >= 0) {
        // a0 is valid; the NULL is a FIELD inside it.
        uint64_t f = 0;
        __builtin_memcpy(&f, reinterpret_cast<void*>(a0 + (uint64_t)s_ng_field[N]), sizeof(f));
        bad = (f == 0);
    }
    if (bad) {
        // First hit only — this can fire per-frame, so never log in a loop.
        if (s_ng_hits[N].fetch_add(1, std::memory_order_relaxed) == 0)
            logger::log_warn("NULLGUARD", "%s: %s is NULL — returning 0 instead of faulting "
                                          "(missing model/sub-object; further hits silent)",
                             s_ng_name[N],
                             s_ng_field[N] >= 0 ? "a required field" : "`this`");
        return 0;
    }
    return s_ng_orig[N](a0, a1, a2, a3, a4, a5, a6, a7);
}

static NgFn s_ng_thunks[kMaxNullGuards] = {
    ng_thunk<0>, ng_thunk<1>, ng_thunk<2>, ng_thunk<3>,
    ng_thunk<4>, ng_thunk<5>, ng_thunk<6>, ng_thunk<7>,
};

bool install_null_this_guard(uintptr_t addr, const char* name, int64_t field_off) {
    if (!addr) {
        logger::log_error("NULLGUARD", "null address for '%s'", name ? name : "?");
        return false;
    }
    for (int i = 0; i < s_ng_count; ++i) {
        if (s_ng_addr[i] == addr) return true;   // idempotent: never stack on a reload
    }
    if (s_ng_count >= kMaxNullGuards) {
        logger::log_error("NULLGUARD", "no free slot for '%s' (max %d)", name ? name : "?", kMaxNullGuards);
        return false;
    }
    int n = s_ng_count;
    __builtin_strncpy(s_ng_name[n], name ? name : "?", sizeof(s_ng_name[n]) - 1);
    s_ng_name[n][sizeof(s_ng_name[n]) - 1] = 0;   
    s_ng_hits[n].store(0, std::memory_order_relaxed);
    s_ng_field[n] = field_off;
    if (DobbyHook(reinterpret_cast<void*>(addr),
                  reinterpret_cast<dobby_dummy_func_t>(s_ng_thunks[n]),
                  reinterpret_cast<dobby_dummy_func_t*>(&s_ng_orig[n])) != RT_SUCCESS) {
        logger::log_error("NULLGUARD", "DobbyHook failed for '%s' @0x%lX", name ? name : "?", (unsigned long)addr);
        return false;
    }
    s_ng_addr[n] = addr;
    ++s_ng_count;
    logger::log_info("NULLGUARD", "%s @0x%lX guarded — returns 0 when `this` is NULL "
                                  "(the check the game is missing)", name ? name : "?", (unsigned long)addr);
    return true;
}

// ═══════════════════════════════════════════════════════════════════════
// DUAL-FIRE ARM — pure C++, because TryFire is a HOT function
// ═══════════════════════════════════════════════════════════════════════
// RE4 has ONE global "armed weapon". AVR4GamePlayerGun::TryFire only fires the
// gun if it IS the armed one at that instant, so with two guns held only one
// ever fires. The fix is to arm THIS gun inside its OWN TryFire, right before
// the fire-check — TryFire(A) arms A then fires A, TryFire(B) arms B then fires
// B, both in the same frame.
//
// That logic used to live in a LUA CALLBACK on TryFire. That is the one thing we
// know we must never do: TryFire runs on the game thread on every trigger pull
// (continuously with rapid-fire, and once per gun with dual-wield), so the
// callback raced the shared lua_State against the mod loop and the bridge
// thread. The result was heap and stack corruption that surfaced far away and
// looked like innocent engine code -- observed as FMallocBinned2 dying in
// IncrementalPurgeGarbage while freeing an FString, and as a RET into a smashed
// return address (pc=lr=1). Same class of bug as the ScoreControl hot-hook.
//
// The work is trivially expressible in C, so it belongs in C: read the gun's
// weapon-no, look up its cItem, arm it, call the original. No Lua, no lock, no
// allocation, nothing that can race. This mirrors the game's OWN code at the tail
// of TryFire (cItemMgr::ArmSearchWeaponNo(&ItemMgr, gun[3360]) -> cItemMgr::arm),
// which is why it is safe to do from here.
//
// Addresses come from Lua (Resolve() already handles symbol + fallback there);
// only the hot path lives here.
static std::atomic<bool> s_dualfire_on{true};
static uintptr_t         s_df_itemmgr = 0;
static uint32_t          s_df_wno_off = 3360;
// &pG (the pointer variable), and the GLOBAL armed weapon-no's offset from pG's
// VALUE. Straight out of TryFire itself:
//     LDR  X8, [X24]          ; X8 = pG value
//     MOV  W9, #0x504C        ; armed weapon-no offset
//     LDRB W8, [X8,X9]        ; armed_wno
//     LDRB W9, [X19,#0xD20]   ; this gun's wno (3360)
//     CMP  W8, W9
//     B.NE loc_62DC614        ; only arms when they DIFFER
static uintptr_t s_df_pg        = 0;
static uint32_t  s_df_armed_off = 0x504C;

using DfArmSearchFn = void*    (*)(void*, uint8_t);   // cItemMgr::ArmSearchWeaponNo
using DfArmFn       = uint64_t (*)(void*, void*);     // cItemMgr::arm
using DfTryFireFn   = uint64_t (*)(uint64_t);         // AVR4GamePlayerGun::TryFire

static DfArmSearchFn s_df_search = nullptr;
static DfArmFn       s_df_arm    = nullptr;
static DfTryFireFn   s_df_orig   = nullptr;

// ═══════════════════════════════════════════════════════════════════════════
// PRIMARY-HAND FALLBACK — lets a two-handed weapon fire from ONE grip
// ═══════════════════════════════════════════════════════════════════════════
// AVR4GamePlayerProp::GetPrimaryHand only ever looks at the PRIMARY grip:
//     return UVR4GamePlayerGrip::GetCurrentHand(prop[78]);   // prop+624
// Hold a two-handed weapon by the forestock alone and that grip has no hand, so
// it returns NULL. Every weapon PreBio4Tick then does
//     if (ready && GetPrimaryHand(this)) TryFire(this); else DryFire(this);
// so the trigger clicks and nothing comes out — regardless of ammo, chamber
// state or IsReadyToFire. That is why weapon-side patches did nothing.
//
// NOPing that CBZ is WRONG: I tried it and the shot went through, then
// cObjLauncher::launch() faulted (12x libUE4+0x5fb6ff0/0x5fb7020) because it
// needs a real hand for the muzzle/aim anchor. The guard is load-bearing.
//
// So instead of deleting the check, give it something valid to return: if the
// primary grip has no hand, ask the grip GROUP which grip is actually held
// (UVR4GamePlayerGripGroupComponent::GetAnyCurrentGrip, group at prop+0xD38 —
// straight out of ForestockGripGrabbed: `ldr x0,[x19,#0xd38]; bl GetAnyCurrentGrip`)
// and return THAT grip's hand. Downstream code gets a genuine hand either way.
static std::atomic<bool> s_ph_on{true};
static uint32_t s_ph_group_off = 0xD38;
using PhGetHandFn  = void* (*)(void*);
using PhAnyGripFn  = void* (*)(void*);
static PhGetHandFn s_ph_orig     = nullptr;   // GetPrimaryHand   (original)
static PhGetHandFn s_fh_orig     = nullptr;   // GetForestockHand (original)
static PhAnyGripFn s_ph_anygrip  = nullptr;   // GetAnyCurrentGrip
static PhGetHandFn s_ph_curhand  = nullptr;   // Grip::GetCurrentHand
static void*       s_ph_group_vtbl = nullptr; // UVR4GamePlayerGripGroupComponent vtable
std::atomic<uint64_t> g_ph_fallbacks{0};

// Shared fallback: the requested grip has no hand, so return the hand from
// whichever grip the player IS actually holding.
//
// Two-handed weapons need BOTH of these to be non-NULL to fire. Straight out of
// AVR4GamePlayerRocketLauncher::PreBio4Tick:
//     if ( GetFiringHand(this) )                       // = GetForestockHand
//         if ( IsReadyToFire(this) && GetPrimaryHand(this) )
//             TryFire(this);
//         else DryFire(this);
// GetFiringHand is a thunk to GunTwoHanded::GetForestockHand, so with only one
// grip held the OUTER gate short-circuits and the trigger does nothing at all.
// That is the "needs two grips on two different grips to fire" behaviour.
static inline void* ph_fallback(void* prop, void* orig_result) {
    if (orig_result || !prop) return orig_result;
    if (!s_ph_on.load(std::memory_order_relaxed) || !s_ph_anygrip || !s_ph_curhand)
        return orig_result;
    void* group = *reinterpret_cast<void* const*>(
        reinterpret_cast<const char*>(prop) + s_ph_group_off);
    if (!ue::is_mapped_ptr(group)) return orig_result;
    // TYPE CHECK — the offset alone is NOT enough. GetPrimaryHand lives on
    // AVR4GamePlayerProp, the base of EVERY prop (consumables, herbs, ammo,
    // flashlight), and only GUNS have a grip group at +0xD38. Without this the
    // fallback read unrelated memory on a Consumable, and because that garbage
    // happened to be a MAPPED address it sailed past is_mapped_ptr straight into
    // GetAnyCurrentGrip:
    //     #00 GetAnyCurrentGrip+144
    //     #01 ph_get_primary_hand+144
    //     #02 AVR4GamePlayerConsumable::Tick+280   -> SIGSEGV fault 0x3e78
    // Verifying the vtable proves the pointer really is a GripGroupComponent.
    if (s_ph_group_vtbl) {
        void* vt = *reinterpret_cast<void* const*>(group);
        if (vt != s_ph_group_vtbl) return orig_result;   // not a gun -> leave alone
    }
    void* grip = s_ph_anygrip(group);
    if (!ue::is_mapped_ptr(grip)) return orig_result;
    void* alt = s_ph_curhand(grip);
    if (alt) g_ph_fallbacks.fetch_add(1, std::memory_order_relaxed);
    return alt;
}

static void* ph_get_primary_hand(void* prop) {
    return ph_fallback(prop, s_ph_orig ? s_ph_orig(prop) : nullptr);
}
static void* ph_get_forestock_hand(void* prop) {
    return ph_fallback(prop, s_fh_orig ? s_fh_orig(prop) : nullptr);
}

bool install_primary_hand_fallback(uintptr_t getprimaryhand, uintptr_t anygrip,
                                   uintptr_t getcurrenthand, uint32_t group_off,
                                   uintptr_t getforestockhand, uintptr_t group_vtbl) {
    if (!getprimaryhand || !anygrip || !getcurrenthand) {
        logger::log_error("ONEHAND", "install: null address");
        return false;
    }
    if (s_ph_orig) { logger::log_info("ONEHAND", "already installed"); return true; }
    s_ph_anygrip = reinterpret_cast<PhAnyGripFn>(anygrip);
    s_ph_curhand = reinterpret_cast<PhGetHandFn>(getcurrenthand);
    if (group_off) s_ph_group_off = group_off;
    // vptr = vtable symbol + 16 (past the RTTI header)
    if (group_vtbl) s_ph_group_vtbl = reinterpret_cast<void*>(group_vtbl + 16);
    if (DobbyHook(reinterpret_cast<void*>(getprimaryhand),
                  reinterpret_cast<dobby_dummy_func_t>(ph_get_primary_hand),
                  reinterpret_cast<dobby_dummy_func_t*>(&s_ph_orig)) != RT_SUCCESS) {
        logger::log_error("ONEHAND", "DobbyHook failed at 0x%lX", (unsigned long)getprimaryhand);
        s_ph_orig = nullptr;
        return false;
    }
    // The FORESTOCK hand is the one that actually matters for two-handed weapons:
    // GetFiringHand thunks to it, and PreBio4Tick tests it FIRST, so without it
    // the trigger is dead before any ammo/ready check runs.
    if (getforestockhand) {
        if (DobbyHook(reinterpret_cast<void*>(getforestockhand),
                      reinterpret_cast<dobby_dummy_func_t>(ph_get_forestock_hand),
                      reinterpret_cast<dobby_dummy_func_t*>(&s_fh_orig)) != RT_SUCCESS) {
            logger::log_error("ONEHAND", "forestock DobbyHook failed at 0x%lX",
                              (unsigned long)getforestockhand);
            s_fh_orig = nullptr;
        } else {
            logger::log_info("ONEHAND", "forestock-hand fallback installed @0x%lX "
                             "(GetFiringHand thunks here — this is the gate that "
                             "required a SECOND grip)", (unsigned long)getforestockhand);
        }
    }
    logger::log_info("ONEHAND",
        "primary-hand fallback installed @0x%lX (groupOff=0x%X) — a two-handed "
        "weapon held by ONE grip now reports a real hand instead of NULL, so "
        "PreBio4Tick reaches TryFire instead of DryFire",
        (unsigned long)getprimaryhand, s_ph_group_off);
    return true;
}

// VTABLE-SLOT fallback for the firing hand. Inline-hooking is not usable here:
//   * GunTwoHanded::GetForestockHand is SHARED with IK/hand-pose/aiming code that
//     assumes the forestock hand differs from the primary -> SIGBUS 0x601.
//   * RocketLauncher::GetFiringHand is a THUNK (one branch); Dobby's 16-byte
//     inline patch overwrites the following function -> broke two-handed firing.
// Swapping the vtable entry avoids both: no code is modified, and only virtual
// dispatch through this class (i.e. PreBio4Tick's gate) sees the replacement.
// Safe because PreBio4Tick only tests the result for non-NULL — it never stores
// or dereferences the returned hand.
bool install_firing_hand_vtable_fallback(uintptr_t vtable_slot) {
    if (!vtable_slot) { logger::log_error("ONEHAND", "vtable: null slot"); return false; }
    void** slot = reinterpret_cast<void**>(vtable_slot);
    if (!ue::is_mapped_ptr(slot)) {
        logger::log_error("ONEHAND", "vtable: slot 0x%lX unmapped", (unsigned long)vtable_slot);
        return false;
    }
    if (s_fh_orig) { logger::log_info("ONEHAND", "vtable fallback already installed"); return true; }
    s_fh_orig = reinterpret_cast<PhGetHandFn>(*slot);
    if (!s_fh_orig) { logger::log_error("ONEHAND", "vtable: slot holds null"); return false; }

    long ps = sysconf(_SC_PAGESIZE); if (ps <= 0) ps = 4096;
    uintptr_t page = vtable_slot & ~(uintptr_t)(ps - 1);
    mprotect(reinterpret_cast<void*>(page), (size_t)ps * 2, PROT_READ | PROT_WRITE);
    *slot = reinterpret_cast<void*>(&ph_get_forestock_hand);

    logger::log_info("ONEHAND",
        "firing-hand VTABLE fallback installed: slot 0x%lX  orig=%p -> fallback "
        "(one grip now satisfies PreBio4Tick's GetFiringHand gate; no code patched)",
        (unsigned long)vtable_slot, (void*)s_fh_orig);
    return true;
}

void set_primary_hand_fallback_enabled(bool on) {
    s_ph_on.store(on, std::memory_order_relaxed);
    logger::log_info("ONEHAND", "%s", on ? "enabled" : "disabled");
}

// ═══════════════════════════════════════════════════════════════════════════
// FAST fmodf — the enemy-AI hot path, without touching gameplay
// ═══════════════════════════════════════════════════════════════════════════
// Profiling the game thread under a full room puts it in libm's fmodf on
// essentially every sample:
//     #00 libm.so (fmodf+364)
//     #01 libUE4.so 0x5d90924        (enemy virtual move())
//     #02 cEmMgr::move()+180
// cEmMgr::move walks every active enemy serially each frame and their AI does
// float angle-wrapping, so fmodf is called an enormous number of times. This is
// GAME code — no mod is involved — so the only way to speed it up without
// capping or reweighting enemies is to make the function itself cheaper.
//
// bionic's fmodf is a generic bit-manipulation loop. On ARM64 the same result
// comes from three hardware instructions:
//     q = x / y ;  t = truncf(q) [FRINTZ] ;  r = x - t*y [FNMSUB]
// which gives C99 semantics exactly: sign of x, |r| < |y|.
//
// Correctness guard: float32 only represents integers exactly up to 2^24, so if
// |x/y| exceeds that, truncf(q) is not the true quotient and the fast path would
// be wrong. Those cases (and NaN/Inf/zero-divisor) fall through to the ORIGINAL
// fmodf, so behaviour is unchanged wherever it actually matters.
static std::atomic<bool> s_fmodf_on{true};
using FmodfFn = float (*)(float, float);
static FmodfFn s_fmodf_orig = nullptr;
std::atomic<uint64_t> g_fmodf_fast{0};
std::atomic<uint64_t> g_fmodf_slow{0};

static float fast_fmodf(float x, float y) {
    if (s_fmodf_on.load(std::memory_order_relaxed)) {
        float q = x / y;
        float aq = __builtin_fabsf(q);
        // finite, non-zero divisor, and quotient inside float's exact-integer range
        if (aq < 16777216.0f && __builtin_isfinite(x) && y != 0.0f) {
            g_fmodf_fast.fetch_add(1, std::memory_order_relaxed);
            return x - __builtin_truncf(q) * y;
        }
    }
    g_fmodf_slow.fetch_add(1, std::memory_order_relaxed);
    return s_fmodf_orig(x, y);
}

bool install_fast_fmodf() {
    if (s_fmodf_orig) { logger::log_info("FASTMATH", "already installed"); return true; }
    void* h = dlopen("libm.so", RTLD_NOLOAD | RTLD_NOW);
    void* addr = h ? dlsym(h, "fmodf") : reinterpret_cast<void*>(&fmodf);
    if (!addr) { logger::log_error("FASTMATH", "fmodf not found"); return false; }
    if (DobbyHook(addr, reinterpret_cast<dobby_dummy_func_t>(fast_fmodf),
                  reinterpret_cast<dobby_dummy_func_t*>(&s_fmodf_orig)) != RT_SUCCESS) {
        logger::log_error("FASTMATH", "DobbyHook fmodf failed at %p", addr);
        s_fmodf_orig = nullptr;
        return false;
    }
    logger::log_info("FASTMATH",
        "fast fmodf installed @%p — enemy AI angle math now uses 3 hardware FP "
        "instructions instead of bionic's bit loop; out-of-range/NaN inputs still "
        "use the original, so results are unchanged", addr);
    return true;
}

void set_fast_fmodf_enabled(bool on) {
    s_fmodf_on.store(on, std::memory_order_relaxed);
    logger::log_info("FASTMATH", "fast fmodf %s", on ? "enabled" : "disabled");
}

// ── TryFire instrumentation (diagnostic; atomics only, no logging here) ──
// Answers the question a backtrace cannot: when a two-handed weapon refuses to
// fire one-handed, is TryFire even REACHED, and what does it return? If calls
// keep climbing while ok stays 0, the weapon is being polled and TryFire itself
// rejects it; if calls stop climbing, the trigger never routes to the gun at all
// and the block is in the hand/grip layer, not in any weapon gate.
std::atomic<uint64_t> g_df_calls{0};
std::atomic<uint64_t> g_df_ok{0};
std::atomic<uint64_t> g_df_last_self{0};
std::atomic<uint64_t> g_df_last_ret{0};

static uint64_t df_tryfire(uint64_t self) {
    g_df_calls.fetch_add(1, std::memory_order_relaxed);
    g_df_last_self.store(self, std::memory_order_relaxed);
    if (s_dualfire_on.load(std::memory_order_relaxed) && self &&
        s_df_search && s_df_arm && s_df_itemmgr)
    {
        // Fresh lookup every call — a dropped/re-picked weapon must never leave a
        // stale cItem to arm.
        uint8_t wno = *reinterpret_cast<volatile uint8_t*>(self + s_df_wno_off);
        if (wno) {
            // ONLY arm if this gun is not ALREADY the armed one — exactly what
            // TryFire itself does (CMP armed_wno, gun[0xD20] / B.NE arm-path).
            // Re-arming an already-armed gun on every trigger poll resets its
            // weapon state: that is what stopped the MINIGUN from firing, because
            // its spin-up was thrown away 60x/sec. Arming is for the OTHER gun in
            // a dual-wield, never for the one the engine already has armed.
            bool already_armed = false;
            if (s_df_pg) {
                uint64_t g = *reinterpret_cast<volatile uint64_t*>(s_df_pg);
                if (g) already_armed =
                    (*reinterpret_cast<volatile uint8_t*>(g + s_df_armed_off) == wno);
            }
            if (!already_armed) {
                void* item = s_df_search(reinterpret_cast<void*>(s_df_itemmgr), wno);
                if (item) s_df_arm(reinterpret_cast<void*>(s_df_itemmgr), item);
            }
        }
    }
    uint64_t r = s_df_orig(self);
    g_df_last_ret.store(r, std::memory_order_relaxed);
    if (r) g_df_ok.fetch_add(1, std::memory_order_relaxed);
    return r;
}

bool install_dualfire_arm(uintptr_t tryfire, uintptr_t itemmgr,
                          uintptr_t armsearch, uintptr_t armfn, uint32_t wno_off,
                          uintptr_t pg_addr, uint32_t armed_off) {
    if (!tryfire || !itemmgr || !armsearch || !armfn) {
        logger::log_error("DUALFIRE", "install: null address (tryfire=0x%lX itemmgr=0x%lX "
                                      "search=0x%lX arm=0x%lX) — not installed",
                          (unsigned long)tryfire, (unsigned long)itemmgr,
                          (unsigned long)armsearch, (unsigned long)armfn);
        return false;
    }
    if (s_df_orig) {          // idempotent: a mod reload must not stack hooks
        s_df_itemmgr = itemmgr;
        s_df_wno_off = wno_off ? wno_off : 3360;
        s_df_search  = reinterpret_cast<DfArmSearchFn>(armsearch);
        s_df_arm     = reinterpret_cast<DfArmFn>(armfn);
        s_df_pg        = pg_addr;
        s_df_armed_off = armed_off ? armed_off : 0x504C;
        logger::log_info("DUALFIRE", "already installed — refreshed addresses only");
        return true;
    }
    s_df_itemmgr = itemmgr;
    s_df_wno_off = wno_off ? wno_off : 3360;
    s_df_search  = reinterpret_cast<DfArmSearchFn>(armsearch);
    s_df_arm     = reinterpret_cast<DfArmFn>(armfn);
    s_df_pg        = pg_addr;
    s_df_armed_off = armed_off ? armed_off : 0x504C;

    if (DobbyHook(reinterpret_cast<void*>(tryfire),
                  reinterpret_cast<dobby_dummy_func_t>(df_tryfire),
                  reinterpret_cast<dobby_dummy_func_t*>(&s_df_orig)) != RT_SUCCESS) {
        s_df_orig = nullptr;
        logger::log_error("DUALFIRE", "DobbyHook failed at 0x%lX", (unsigned long)tryfire);
        return false;
    }
    logger::log_info("DUALFIRE", "pure-C++ TryFire arm installed @0x%lX (itemMgr=0x%lX wnoOff=%u) "
                                 "— no Lua on the trigger path",
                     (unsigned long)tryfire, (unsigned long)itemmgr, s_df_wno_off);
    return true;
}

void set_dualfire_enabled(bool on) {
    s_dualfire_on.store(on, std::memory_order_relaxed);
    logger::log_info("DUALFIRE", "%s", on ? "enabled" : "disabled");
}

bool is_dualfire_enabled() { return s_dualfire_on.load(std::memory_order_relaxed); }

// ═══════════════════════════════════════════════════════════════════════
// em32 SUB-OBJECT NULL GUARD — the "cut enemy explodes on spawn" crash
// ═══════════════════════════════════════════════════════════════════════
// sub_5E49AA0 (em32's init, reached from cEm32::move) builds two sub-object
// models with SetObj00 and hands each to VR4CreateEmSubObject. SetObj00 returns
// NULL whenever cModel::modelInit can't find the model in the archive — which is
// exactly what happens for cut content, whose sub-object data was never shipped.
//
// The game checks for that NULL and then dereferences it anyway, four
// instructions later:
//     5e4a31c  BL   SetObj00
//     5e4a320  STR  X0, [X25,#0xA88]     ; may be NULL
//     5e4a324  CBZ  X0, loc_5E4A33C      ; ...checked here...
//     5e4a36c  LDR  X2, [X25,#0xA88]     ; ...reloaded...
//     5e4a374  LDR  X8, [X2,#0x180]      ; ...and derefed. SIGSEGV, fault 0x180.
// The first site (0x5e4a358) is worse: one path literally does MOV X2, XZR and
// falls straight into the same load. Retail never spawns em32, so it never fired.
//
// The joke is that the callee never wanted the value:
//     VR4CreateEmSubObject(archive, cEm *a2, cModel *a3) { if (a2) if (a3) {...} }
// It null-checks both pointers and returns. The crash happens purely while
// COMPUTING AN ARGUMENT THAT WOULD HAVE BEEN THROWN AWAY. So we don't need to
// skip the call — we need the two loads not to fault, and the callee will opt out
// on its own.
//
// Both loads are fed a scratch buffer that points at itself (+0x180 -> self), so
// LDR X8,[X2,#0x180] yields the buffer and LDR X0,[X8,#0x18] yields 0. X8 then
// doubles as the "we substituted" flag for the second instrument, which zeroes X1
// (the cEm) — that is what makes VR4CreateEmSubObject bail at its very first `if`.
// Nothing is written, no actor is spawned, and X0's return is discarded by the
// caller anyway. When the pointer is NOT null, every handler is a no-op, so the
// normal path keeps its exact original behaviour.
//
// Checked all 107 VR4CreateEmSubObject call sites: the other 105 take X0 from the
// cEm's own archive (LDR X8,[X19,#0x460] / ADD X0,X9,X8) and never dereference the
// cModel, so a NULL model is already harmless there. sub_5E49AA0 is the only
// function that sources X0 from the model itself — hence the only one that can
// fault. Two sites, four instruments, whole class of cut-content AI covered.
static const uintptr_t kEm32InitRva    = 0x5E49AA0;   // sub_5E49AA0 — em32's init
static const uintptr_t kEm32MovX2Zr    = 0x5E4A354;   // `MOV X2, XZR` on the NULL path
static const uintptr_t kEm32Site2Setup = 0x5E4A36C;   // `LDR X2,[X25,#0xA88]` — site 2's setup
static const uint32_t  kInsnMovX2Xzr   = 0xAA1F03E2;  // MOV X2, XZR (ORR X2,XZR,XZR)
// +0x180 must land inside and point back at the buffer; +0x18 must read 0.
alignas(16) static uint8_t g_em32_null_model[0x400];

// Only fires on a pointer that is ALREADY guaranteed to fault one insn later.
static void em32_sub_null_to_dummy(void* addr, DobbyRegisterContext* ctx) {
    (void)addr;
    if (ARCH_DREG(ctx, 2) == 0) {
        ARCH_DREG(ctx, 2) = reinterpret_cast<uint64_t>(g_em32_null_model);
        ARCH_DREG(ctx, 1) = 0;   // VR4CreateEmSubObject returns at its first `if (a2)`
    }
}
static const uintptr_t kEm32Guard[][2] = {   // fingerprint only — NOT hook sites
    { 0x5E4A358, 0x5E4A364 },                // sub-object 1 (cEm+0xA80)
    { 0x5E4A374, 0x5E4A378 },                // sub-object 2 (cEm+0xA88) — observed crash
};

static bool em32_guard_is_ldr_x_imm(uint32_t w, int* rt, int* rn, uint32_t* off) {
    if ((w & 0xFFC00000u) != 0xF9400000u) return false;   // LDR Xt,[Xn,#imm] unsigned
    *rt  = (int)(w & 0x1F);
    *rn  = (int)((w >> 5) & 0x1F);
    *off = ((w >> 10) & 0xFFF) * 8u;
    return true;
}



// ── WHY THE MID-FUNCTION INSTRUMENT APPROACH WAS RIPPED OUT ──────────────
// The first version DobbyInstrument'ed FOUR addresses inside sub_5E49AA0 to
// swap X2/X1 in the register context. It made things WORSE, and the tombstones
// say so plainly — same function, same path, before vs after:
//     before:  cEm32::move+1508 -> fault addr 0x180        (a clean null deref)
//     after:   cEm32::move+1508 -> pc = 0x512c662204       (a BR into garbage)
// Two of the instrument sites were FOUR BYTES apart (0x5e4a374 / 0x5e4a378).
// libmodloader loads ~251MB away from libUE4 — past ARM64's +/-128MB branch
// range — so Dobby cannot always patch a 4-byte B and must write a 16-byte
// absolute sequence (LDR x17,#8 / BR x17 / .quad target). 16 bytes at 0x374
// swallows 0x378, 0x37c (the BL) and 0x380, and instrumenting 0x378 then writes
// INTO that patch. Shredded code, wild jump.
//
// RULE: never place two inline hooks within 16 bytes of each other, and prefer
// function-ENTRY hooks. Mid-function register surgery is not worth it here.
//
// What we do instead is the mechanism already proven on this title: a
// callback-less safe-call guard on em32's init. If the unchecked deref faults,
// the SIGSEGV is caught and the init returns 0 instead of killing the game. The
// enemy may come out half-built — but it is CUT CONTENT that retail never spawns,
// and a half-built cut enemy beats a hard crash. No code is rewritten, no
// registers are touched, and there is nothing to overlap.
bool install_em32_subobject_guard() {
    uintptr_t base = symbols::lib_base();
    if (!base) {
        logger::log_error("EM32", "lib_base unavailable — guard skipped");
        return false;
    }
    // Verify BOTH `LDR Xd,[X2,#0x180]` sites are where we think before touching
    // anything. If a game update moved this code, do nothing.
    int rt1, rn1, rt2, rn2; uint32_t off1, off2;
    uint32_t w1 = *reinterpret_cast<const uint32_t*>(base + kEm32Guard[0][0]);
    uint32_t w2 = *reinterpret_cast<const uint32_t*>(base + kEm32Guard[1][0]);
    if (!em32_guard_is_ldr_x_imm(w1, &rt1, &rn1, &off1) || off1 != 0x180 || rn1 != 2 ||
        !em32_guard_is_ldr_x_imm(w2, &rt2, &rn2, &off2) || off2 != 0x180 || rn2 != 2) {
        logger::log_warn("EM32", "sub_5E49AA0 doesn't match the expected em32 init — guard skipped");
        return false;
    }
    *reinterpret_cast<void**>(g_em32_null_model + 0x180) = g_em32_null_model;

    int done = 0;

    // ── SITE 1 (cEm+0xA80): a ONE-INSTRUCTION byte patch ──────────────────
    //   5e4a340  CBZ X8, loc_5E4A354      ; model is NULL ->
    //   5e4a354  MOV X2, XZR              ; ...v50 = nullptr...
    //   5e4a358  LDR X8, [X2,#0x180]      ; ...and deref it. fault 0x180.
    // The NULL path is a dead end that only exists to crash, so branch straight
    // over the whole call to site 2's setup at 0x5e4a36c. One instruction, no
    // hook, no trampoline, nothing to overlap — permanent and free.
    uintptr_t movzr = base + kEm32MovX2Zr;
    if (*reinterpret_cast<const uint32_t*>(movzr) == kInsnMovX2Xzr) {
        int64_t delta = (int64_t)(base + kEm32Site2Setup) - (int64_t)movzr;   // +0x18
        uint32_t br = 0x14000000u | (uint32_t)((delta >> 2) & 0x03FFFFFFu);   // B imm26
        patch_code(reinterpret_cast<void*>(movzr), &br, sizeof(br));
        logger::log_info("EM32", "site 1: `MOV X2,XZR` @0x%lX -> `B +0x%lX` — the NULL path now "
                                 "skips its VR4CreateEmSubObject instead of faulting",
                         (unsigned long)kEm32MovX2Zr, (unsigned long)delta);
        ++done;
    } else {
        logger::log_warn("EM32", "site 1: 0x%lX is not `MOV X2,XZR` (0x%08X) — left alone",
                         (unsigned long)kEm32MovX2Zr, *reinterpret_cast<const uint32_t*>(movzr));
    }

    // ── SITE 2 (cEm+0xA88): ONE DobbyInstrument ───────────────────────────
    // No CBZ to hijack here — the game reloads the pointer and derefs it with no
    // check at all, and a byte patch can't fit (it needs 4 ops in 3 slots).
    // ONE instrument is safe: Dobby relocates the instructions it overwrites into
    // its own trampoline. The earlier disaster was FOUR instruments with two of
    // them 4 BYTES APART, shredding each other — nothing else is hooked within 16
    // bytes of this one.
    //
    // When X2 is NULL we point it at a scratch buffer that points to itself, so
    // the two loads read harmless zeros, AND zero X1 — VR4CreateEmSubObject's
    // FIRST statement is `if (a2)`, so it returns instantly without touching a
    // thing. Nothing writes X1 between here and the BL, so it sticks.
    //
    // Critically this lets the init CONTINUE, which is the whole point: every
    // line below is YarareInit/YarareAdd — U3's damage regions. A crash guard
    // siglongjmp'd out before them, which is exactly what left U3 unkillable.
    if (DobbyInstrument(reinterpret_cast<void*>(base + kEm32Guard[1][0]),
                        em32_sub_null_to_dummy) == RT_SUCCESS) {
        logger::log_info("EM32", "site 2: 0x%lX instrumented — a NULL sub-object now no-ops the "
                                 "call and the init runs on to YarareAdd (U3 keeps its hitboxes)",
                         (unsigned long)kEm32Guard[1][0]);
        ++done;
    } else {
        logger::log_error("EM32", "site 2: DobbyInstrument FAILED at 0x%lX",
                          (unsigned long)kEm32Guard[1][0]);
    }

    logger::log_info("EM32", "em32/U3 sub-object fix: %d/2 sites", done);
    return done > 0;
}

// ═══════════════════════════════════════════════════════════════════════
// ENEMY POOL SIZE — lift the per-level cap on live enemies
// ═══════════════════════════════════════════════════════════════════════
// EmSetEvent [0x5EE9E8C] hands out cEm slots from a fixed pool and returns the
// `errEm` sentinel when every slot is busy — that IS the "hard limit of enemies
// allowed for each level" (EnemySpawner surfaces it as "Pool full or invalid
// emId"). The pool is the usual manager shape:
//     EmMgr @ 0xA54AB68 : +0 vtable, +8 pool base, +16 slot count, +20 stride
// so bumping the COUNT alone would walk the free-slot scan straight off the end
// of the allocation — corruption, not more enemies.
//
// cEmMgr::arrayAlloc(this, n) [0x5D90680] is the one place that sizes it, and it
// is perfectly self-consistent:
//     free(pool); pool = memAlloc(stride * n); count = n; memClear(pool, stride * n);
// so scaling its `n` argument scales the ALLOCATION and the COUNT together.
// A pre-hook rewriting x1 is therefore the whole fix — no reallocation dance, no
// stale pointers (it runs before any cEm exists), nothing to keep in sync.
// Its prologue is STP/STP/ADD/LDR — position-independent, so the trampoline is
// safe here (unlike ArmEmCallProlog, whose ADRL/ADR jump-table setup it broke).
//
// Cost is stride * (mult-1) extra bytes once per level load. The engine still
// enforces its own per-type AI/anim budgets, so this raises the ceiling; it does
// not promise 100 ganados will path or render well.
// ── PERSISTENT POOL (allocate once, reuse forever) ────────────────────────
// The comment above says "no stale pointers (it runs before any cEm exists)".
// That is TRUE for the multiplier, but the surrounding memory management is a
// different story, and it is why a big multiplier used to be unusable:
//
//   gameRoomInit  0x5F43518 : str xzr,[x20,#8]   ; EmMgr+8 = NULL
//                 0x5F43530 : bl  arrayAlloc
//   arrayAlloc              : if (pool) free(pool);      <- UNREACHABLE
//                             pool = memAlloc(stride*n);
//
// NULLing the pointer first makes the free unreachable ON PURPOSE: the previous
// buffer is ABANDONED, not freed, because pPL/pSUB/pSUB2 (and mine parents, SceAt
// refs, ...) still point INTO it until gameRoomInit rebuilds them a few lines
// later. Patching the NULL-store out so the free runs turns a bounded leak into
// a use-after-free — verified the hard way: the first room load after doing that
// crashed arrayAlloc with SIGSEGV, followed by GRIGUARD catching a NULL vtable on
// a bare cEm. The leak is load-bearing.
//
// So the stock behaviour costs stride*count per room load, and multiplying the
// count multiplies the bleed (x20 = ~5.3 MB every transition).
//
// This replacement takes the third option: allocate the big buffer ONCE and
// REUSE it on every subsequent room load.
//   * nothing is freed  -> no dangling pointers, the hazard above cannot happen
//   * nothing is realloc'd -> no per-room leak, so the multiplier is unbounded
//   * the buffer is memset and the same three globals are cleared, so the
//     manager is left in exactly the state arrayAlloc would have left it in.
// Only when a room genuinely needs MORE slots than we hold do we fall through to
// the original, adopt its (bigger) buffer, and abandon the previous one once —
// which is stock behaviour, not a regression.
static uint32_t s_em_pool_mult = 1;

using ArrayAllocFn = int64_t (*)(void*, uint32_t);
static ArrayAllocFn s_arrayalloc_orig  = nullptr;
static void*        s_em_pool_buf      = nullptr;
static uint32_t     s_em_pool_slots    = 0;
static uint32_t     s_em_pool_stride   = 0;
// Bytes ACTUALLY allocated for s_em_pool_buf. Tracking slots alone was not
// enough and cost a SIGSEGV: the reuse path cleared stride*want, which is only
// correct if the buffer really is that big. If the two ever disagree the memset
// walks straight off the end of the mapping —
//     SEGV_MAPERR 0x73799be000  memset+196 <- em_pool_arrayalloc+324 <- gameRoomInit
// so the clear is now bounded by this, which is measured, not inferred.
static size_t       s_em_pool_bytes    = 0;
// OFF until the reuse path has proven itself in game. With this false the
// function behaves exactly like the old pre-hook: scale the count, let the
// original allocate. That is the known-good path.
static bool         s_em_pool_persist  = false;

// EmMgr layout: +0x08 pool base, +0x10 slot count, +0x14 stride.
static constexpr uintptr_t RVA_pPL   = 0xA54AB40;
static constexpr uintptr_t RVA_pSUB  = 0xA54AB48;
static constexpr uintptr_t RVA_pSUB2 = 0xA54AB50;

static int64_t em_pool_arrayalloc(void* mgr, uint32_t count) {
    uint8_t* m = static_cast<uint8_t*>(mgr);
    if (!m || !s_arrayalloc_orig) {
        return s_arrayalloc_orig ? s_arrayalloc_orig(mgr, count) : 0;
    }

    const uint32_t stride = *reinterpret_cast<uint32_t*>(m + 0x14);
    uint64_t want = static_cast<uint64_t>(count) * (s_em_pool_mult ? s_em_pool_mult : 1);
    if (want < count) want = count;              // overflow guard
    if (want > 4096)  want = 4096;
    if (!stride || !want) return s_arrayalloc_orig(mgr, count);

    const size_t needBytes = static_cast<size_t>(stride) * static_cast<size_t>(want);

    if (s_em_pool_persist && s_em_pool_buf &&
        stride == s_em_pool_stride && s_em_pool_slots >= want &&
        needBytes <= s_em_pool_bytes)          // <- the check whose absence crashed
    {
        // REUSE. Reproduce arrayAlloc's observable effects exactly, minus the
        // free/alloc: pool ptr, count, zeroed buffer, and the three globals it
        // resets (0x5D90710..0x5D9071C).
        *reinterpret_cast<void**>(m + 0x08)    = s_em_pool_buf;
        *reinterpret_cast<uint32_t*>(m + 0x10) = static_cast<uint32_t>(want);
        std::memset(s_em_pool_buf, 0, needBytes);

        if (uintptr_t b = symbols::lib_base()) {
            *reinterpret_cast<uintptr_t*>(b + RVA_pPL)   = 0;
            *reinterpret_cast<uintptr_t*>(b + RVA_pSUB)  = 0;
            *reinterpret_cast<uintptr_t*>(b + RVA_pSUB2) = 0;
        }
        logger::log_info("EMPOOL", "reused persistent pool: %u slots (asked %u x%u) — no alloc, no leak",
                         s_em_pool_slots, count, s_em_pool_mult);
        return 1;
    }

    // First call, or this room wants more than we hold: let the original size it.
    const int64_t r = s_arrayalloc_orig(mgr, static_cast<uint32_t>(want));
    s_em_pool_buf    = *reinterpret_cast<void**>(m + 0x08);
    // Trust the manager's own count, not what we asked for — if the original
    // clamped or failed, `want` would be a lie and the next reuse would clear
    // memory that was never allocated.
    const uint32_t got = *reinterpret_cast<uint32_t*>(m + 0x10);
    s_em_pool_slots  = got;
    s_em_pool_stride = stride;
    s_em_pool_bytes  = s_em_pool_buf ? static_cast<size_t>(stride) * got : 0;
    if (!s_em_pool_buf) {
        s_em_pool_slots = 0; s_em_pool_bytes = 0;
        logger::log_error("EMPOOL", "arrayAlloc returned a NULL pool for %u slots — reuse disabled", (unsigned)want);
    }
    logger::log_info("EMPOOL", "allocated persistent pool: %u -> %u slots (x%u, %.1f MB) — reused from now on",
                     count, s_em_pool_slots, s_em_pool_mult,
                     (double)stride * s_em_pool_slots / 1048576.0);
    return r;
}

bool set_enemy_pool_multiplier(uint32_t mult) {
    if (mult < 1) mult = 1;
    // Persistent reuse means the buffer is allocated once, so a large multiplier
    // no longer compounds per room load. The 4096-slot cap below still applies.
    if (mult > 64) mult = 64;
    s_em_pool_mult = mult;
    void* fn = symbols::resolve("_ZN6cEmMgr10arrayAllocEj");
    if (!fn) {
        uintptr_t b = symbols::lib_base();
        if (!b) { logger::log_error("EMPOOL", "lib_base unavailable"); return false; }
        fn = reinterpret_cast<void*>(b + 0x5D90680);
    }
    // FULL REPLACEMENT, not a pre-hook. A pre-hook can only rewrite the count,
    // which still leaves arrayAlloc allocating a fresh buffer every room load
    // (and abandoning the old one). em_pool_arrayalloc owns the decision, so it
    // can reuse the existing buffer and allocate nothing at all.
    //
    // Install once; later calls just update s_em_pool_mult. arrayAlloc's prologue
    // is STP/STP/ADD/LDR — position-independent, so DobbyHook's trampoline is
    // safe here (the FP-store+SP-writeback prologues are the dangerous ones).
    if (!s_arrayalloc_orig) {
        if (DobbyHook(fn,
                      reinterpret_cast<dobby_dummy_func_t>(em_pool_arrayalloc),
                      reinterpret_cast<dobby_dummy_func_t*>(&s_arrayalloc_orig)) != RT_SUCCESS
            || !s_arrayalloc_orig) {
            logger::log_error("EMPOOL", "DobbyHook failed on cEmMgr::arrayAlloc @%p", fn);
            s_arrayalloc_orig = nullptr;
            return false;
        }
        logger::log_info("EMPOOL", "persistent-pool hook installed @%p", fn);
    }

    logger::log_info("EMPOOL",
                     "enemy pool multiplier x%u : armed (persistent reuse %s; applies on next level load)",
                     s_em_pool_mult, s_em_pool_persist ? "ON — allocated once, no per-room leak" : "OFF");
    return true;
}

// Escape hatch: turn persistence off to get the stock allocate-and-abandon
// behaviour back without rebuilding (e.g. to A/B a suspected regression).
bool set_enemy_pool_persist(bool on) {
    s_em_pool_persist = on;
    if (!on) { s_em_pool_buf = nullptr; s_em_pool_slots = 0; s_em_pool_stride = 0; }
    logger::log_info("EMPOOL", "persistent pool %s", on ? "ENABLED" : "DISABLED (stock behaviour)");
    return true;
}

// ── Targeted safe-call guard ───────────────────────────────────────────────
// install_builtin_crash_guards() is SKIPPED on this title (guarding the render
// path black-screens VR), so guarding a single known-crashy function needs its
// own opt-in entry point. Installs a hook with NO callbacks: dispatch_full()
// then runs the original inside the sigsetjmp safe-call guard, so a SIGSEGV in
// it recovers and returns 0 instead of killing the game.
//
// Primary user: cModel::initJoint. Spawning the CUT police NPC (em07/PL07) goes
//   EmSetEvent → cEmMgr::construct → Pl11Init → cSubAshley::modelSet
//     → cModel::modelInit → cModel::initJoint   ← SIGSEGV
// initJoint+144 derefs joint/parts data that was never populated for the cut NPC:
//     v10 = **(_QWORD**)(*(this+0x180) + 0x18);
//     v11 = *(uint8*)(v10 + 1);        // ← fault (tombstone_27, 0x6fe1444c10)
// That chain is built by makePartsList INSIDE initJoint, so a pre-hook can't
// validate it up-front — routing the whole call through the guard is the fix.

void add_em3f_mesh_path_fix(uint32_t key, int32_t comparison_index) {
    const int cap = (int)(sizeof(s_em3fPathFixes) / sizeof(s_em3fPathFixes[0]));
    for (int i = 0; i < s_em3fPathFixCount; ++i) {          // update in place
        if (s_em3fPathFixes[i].key == key) {
            s_em3fPathFixes[i].fname_idx = comparison_index;
            logger::log_info("EM3F", "mesh path-fix updated: key=%u -> FName idx %d", key, comparison_index);
            return;
        }
    }
    if (s_em3fPathFixCount >= cap) {
        logger::log_warn("EM3F", "mesh path-fix table full (%d) — key=%u dropped", cap, key);
        return;
    }
    s_em3fPathFixes[s_em3fPathFixCount++] = { key, comparison_index };
    logger::log_info("EM3F", "mesh path-fix armed: key=%u -> FName idx %d (%d total)",
                     key, comparison_index, s_em3fPathFixCount);
}

HookId install_model_restore(void* move_addr) {
    if (!move_addr) {
        logger::log_error("EM3F", "model_restore: null move addr");
        return 0;
    }
    if (!s_EmModelClassLookUp)
        s_EmModelClassLookUp = reinterpret_cast<cEm_EmModelClassLookUp_t>(
            symbols::resolve("_ZN3cEm18EmModelClassLookUpEPKS_"));
    if (!s_VR4PoseableModelInit)
        s_VR4PoseableModelInit = reinterpret_cast<cModel_VR4PoseableModelInit_t>(
            symbols::resolve("_ZN6cModel20VR4PoseableModelInitEP6UClassPv"));
    if (!s_FWeakGet)
        s_FWeakGet = reinterpret_cast<FWeakObjectPtr_Get_t>(
            symbols::resolve("_ZNK14FWeakObjectPtr3GetEv"));
    if (!s_AddOrSwapSkeletalMesh)
        s_AddOrSwapSkeletalMesh = reinterpret_cast<AddOrSwapSkeletalMesh_t>(
            symbols::resolve("_ZN17AVR4PoseableModel21AddOrSwapSkeletalMeshE5FNamejPK10cModelInfoP12UVR4MeshData"));
    if (!s_TryCacheMap)
        s_TryCacheMap = reinterpret_cast<UVR4MeshData_TryCacheMap_t>(
            symbols::resolve("_ZN12UVR4MeshData11TryCacheMapEb"));
    if (!s_VR4CreateEmSubObject)
        s_VR4CreateEmSubObject = reinterpret_cast<VR4CreateEmSubObject_t>(
            symbols::resolve("_Z20VR4CreateEmSubObjectPvP3cEmP6cModel"));
    if (!s_ModInfoMgrCreate)
        s_ModInfoMgrCreate = reinterpret_cast<cModInfoMgr_create_t>(
            symbols::resolve("_ZN11cModInfoMgr6createEmm"));
    if (!s_addModel)
        s_addModel = reinterpret_cast<cModel_addModel_t>(
            symbols::resolve("_ZN6cModel8addModelEP10cModelInfo"));
    if (!s_ModInfoMgr) {
        // `ModInfoMgr` is a static object; the em3f init takes its address
        // (adrp 0xa3c2000 + ldr #0x8a8 -> GOT slot holding &ModInfoMgr @ 0xA578670).
        s_ModInfoMgr = symbols::resolve("ModInfoMgr");
        if (!s_ModInfoMgr) {
            uintptr_t b = symbols::lib_base();
            if (b) s_ModInfoMgr = reinterpret_cast<void*>(b + 0xA578670);
        }
    }
    if (!s_EmModelClassLookUp || !s_VR4PoseableModelInit) {
        logger::log_error("EM3F", "model_restore: unresolved EmModelClassLookUp=%p VR4PoseableModelInit=%p",
                          (void*)s_EmModelClassLookUp, (void*)s_VR4PoseableModelInit);
        return 0;
    }
    if (!s_FWeakGet || !s_AddOrSwapSkeletalMesh)
        logger::log_warn("EM3F", "model_restore: multi-part attach unavailable (FWeakGet=%p AddOrSwap=%p) — base only",
                         (void*)s_FWeakGet, (void*)s_AddOrSwapSkeletalMesh);
    HookId id = install_at(move_addr, "__model_restore",
                           model_restore_pre, nullptr, "ModelRestore");
    logger::log_info("EM3F", "model-restore hook @0x%lX : %s",
                     (unsigned long)reinterpret_cast<uintptr_t>(move_addr),
                     id ? "installed" : "FAILED");
    return id;
}

} // namespace native_hooks
