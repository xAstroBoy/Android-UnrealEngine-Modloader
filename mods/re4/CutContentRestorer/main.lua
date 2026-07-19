-- mods/CutContentRestorer/main.lua v1.0
-- ═══════════════════════════════════════════════════════════════════════
-- CUT CONTENT RESTORER — makes RE4 VR's cut enemies spawn, render, and
-- animate without crashing. Consolidates three older mods:
--   • SaddlerAdaFix   → em3f (Saddler-Ada) model provision
--   • TyrantAI        → em09 (Tyrant) state-machine monitor + control
--   • (new) cloth fix → skeleton-mismatch crash guard for ALL cut enemies
--
-- THREE mechanisms, each independent:
--
-- 1. CLOTH-BONE SANITIZER (crash fix)
--    Cut enemies were ported from RE4 UHD with a DIFFERENT skeleton than the
--    VR engine's cloth code expects. PenClothSet(cModel*,CLOTH_INFO*,float)
--    resolves cloth bone indices via cModel::getPartsPtr; a ported/short rig
--    returns null → PenClothSet writes null+0x1d8 → SIGSEGV (tombstone_20:
--    PenClothSet ← cEm3f::move ← EmSetEvent). The modloader's pure-C++
--    InstallClothBoneSanitizer hooks PenClothSet and rewrites every bone the
--    model can't resolve to 0xFF (the engine's "skip this point" sentinel).
--    Cloth stays LIVE on every real bone; the missing (cut) bones skip. No-op
--    for enemies whose rig is complete.
--
-- 2. MODEL-CLASS PROVISION (render fix)
--    Each enemy's init looks up its visible model class via one of:
--      GetEmModelClass(id)  → DataSingleton+0x80 (EmModelData, 255 slots)
--      GetEtcModelClass(id) → DataSingleton+0x88 (EtcModelData, 112 slots)
--    → UVR4ModelData::GetClassWithIndex(id) → LoadSynchronous(slot[id]).
--    Cut enemies have an EMPTY slot in the base game (no model) → invisible.
--    EnemyFixes_P.pak ships a "*_Poseable" Blueprint for each. We pre-hook
--    both lookups and, for a cut emId, write the Poseable BP's FSoftObjectPtr
--    into slot[id] so the engine's own LoadSynchronous streams it in. Verified
--    end-to-end on em3f (Saddler-Ada renders).
--    REQUIRES EnemyFixes_P.pak mounted (ships the Poseable BPs + mesh data).
--
-- 3. TYRANT AI (em09 monitor/control) — folded from TyrantAI v3.1.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "CutContentRestorer"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

-- ═══════════════════════════════════════════════════════════════════════
-- SHARED HELPERS
-- ═══════════════════════════════════════════════════════════════════════
local function safePtr(p) return p and not IsNull(p) end

-- UVR4DataSingleton chain: &GEngine @ RVA 0xAAD7740 → GEngine → +0x288 = DS
local GENGINE_RVA = 0xAAD7740
local DS_OFF      = 0x288
local EM_OFF      = 0x80   -- DS+0x80 = EmModelData  (GetEmModelClass)
local ETC_OFF     = 0x88   -- DS+0x88 = EtcModelData (GetEtcModelClass)
local LIST_OFF    = 0x30   -- UVR4ModelData: ModelClassList array ptr
local COUNT_OFF   = 0x38   -- UVR4ModelData: element count
local STRIDE      = 40     -- FSoftObjectPtr / TSoftClassPtr stride

local function resolveDataSingleton()
    local base = nil
    pcall(function() base = GetLibBase() end)
    if not safePtr(base) then return nil end
    local geng = nil
    pcall(function() geng = ReadPtr(Offset(base, GENGINE_RVA)) end)
    if not safePtr(geng) then return nil end
    local ds = nil
    pcall(function() ds = ReadPtr(Offset(geng, DS_OFF)) end)
    if not safePtr(ds) then return nil end
    return ds
end

-- ═══════════════════════════════════════════════════════════════════════
-- 1. CLOTH-BONE SANITIZER — install the pure-C++ crash guard on PenClothSet
-- ═══════════════════════════════════════════════════════════════════════
do
    local addr = nil
    pcall(function() addr = Resolve("_Z11PenClothSetP3cEmP10CLOTH_INFOf", 0x05FC4270) end)
    if safePtr(addr) and InstallClothBoneSanitizer then
        local ok = false
        pcall(function() ok = InstallClothBoneSanitizer(addr) end)
        if ok then
            Log(TAG .. ": Cloth-bone sanitizer installed @ " .. ToHex(addr)
                .. " — cut-enemy cloth crash guarded (missing bones skip, real bones stay live)")
        else
            LogWarn(TAG .. ": InstallClothBoneSanitizer FAILED @ " .. ToHex(addr))
        end
    else
        LogWarn(TAG .. ": PenClothSet not resolved OR InstallClothBoneSanitizer missing"
            .. " (modloader too old?) — cloth crash NOT guarded")
    end
end

-- ═══════════════════════════════════════════════════════════════════════
-- 1b. MODEL-LOAD RESTORE — make cut enemies spawn a VISIBLE UE actor
-- ═══════════════════════════════════════════════════════════════════════
-- em3f's cEm3f::move init runs the native archive modelInit but never calls
-- VR4ModelInit (working enemies do BOTH), so no AVR4Model is ever spawned →
-- invisible. InstallModelRestore hooks cEm3f::move and injects the missing
-- VR4ModelInit(this, EmModelClassLookUp(this)) in C++ (native pointers, no MTE
-- mangle) on the tick after modelInit builds the skeleton. Self-guards on
-- cModel+988, so it's a no-op for enemies that build their own UE model.
do
    -- Enemies whose cEmXX::move needs the model-load restored (cut content).
    local MOVE_ADDRS = {
        { name = "cEm3f", sym = "_ZN5cEm3f4moveEv", rva = 0x5EA2580 },
    }

    -- ── em3f MeshRef paths: FIXED IN THE PAK, nothing to do at runtime ──────
    -- em3f_meshTable's three plaga rows (keys 684544 / 745920 / 2190400) used to
    -- point their MeshRefs at /Game/Characters/BIO4/EM/em25_plaga/Geometry/<mesh>
    -- while the assets were packed under /BOSS/em30_Saddler/Geometry/<mesh>, so
    -- FSoftObjectPath::TryLoad returned null and those parts loaded no mesh at all.
    -- We used to repoint the cached MeshRef FName here via AddEm3fMeshPathFix().
    -- EnemyFixes_P.pak now ships the correct paths (verified by decoding it: all
    -- 1940 MeshRefs across its 55 tables resolve), so the pak is the source of
    -- truth and this override is gone — it would only mask a future path change.
    -- The AddEm3fMeshPathFix binding stays available in native_hooks if ever needed.

    -- ── CUT VILLAGER GANADOS — REAL SPAWN FIX (ids 6/7/8/0xA/0xB/0xD/0x33/0x37) ──
    -- Spawning a cut villager killed the game (tombstones 27/30):
    --   EmSetEvent → cEmMgr::construct → Pl11Init → cSubAshley::modelSet
    --     → cModel::modelInit → cModel::initJoint+144   ← SIGSEGV
    -- Guarding modelInit/initJoint did NOT work (tombstone_30 shows the guard in
    -- the stack and the game still died) — by then the wrong init is already
    -- running on the wrong data. The real defect:
    --   * ArmEmCallProlog(id) is `switch (id - 3)`, and every prolog is one line:
    --     `EmInitFunc = <Init>` (a GLOBAL). These ids have NO case → it returns 0
    --     and leaves EmInitFunc STALE. EmReadSearch nulls only its cached copy but
    --     still returns the loaded archive, and cEmMgr::construct only checks
    --     `if (!result)` → so it calls the PREVIOUS enemy's init (Pl11Init, left by
    --     an Ashley/Luis sub-char, ids 3/5/12) over ganado data → initJoint → dead.
    -- These ids are VILLAGER GANADOS and EmFileTbl already maps them correctly to
    -- "em/em10.das" — not a placeholder, they SHARE the ganado archive. Proof in
    -- EnemyFixes_P.pak: em07/em08/em09/em10_meshTable are all 132 rows and
    -- IDENTICAL, and the pak ships Em07_Poseable/Em08_Poseable under
    -- Ganado/Villager. Ids 9 (_prologEm09) and 0x10 (_prologEm10set) use that same
    -- archive and work — so give each cut id the id-9 case and they spawn with the
    -- real ganado init AND real ganado AI. (Earlier attempt repointed id 7 at
    -- pl07.das: WRONG — pl07 is a separate cutscene cop with its own
    -- Player/pl07_Police_MeshTable and an 11-entry archive.)
    if InstallCutVillagerFix then
        pcall(function()
            local ok = InstallCutVillagerFix()
            Log(TAG .. ": cut villager ganado fix: " .. (ok and "installed" or "FAILED")
                .. " — ids 6/7/8/A/B/D/33/37 → _prologEm09 (real ganado AI)")
        end)
    else
        LogWarn(TAG .. ": InstallCutVillagerFix missing — rebuild the modloader")
    end

    -- Crossover pool ids 0x60-0x6F sit OUTSIDE ArmEmCallProlog's switch, so the
    -- villager fix can't reach them: the global EmInitFunc stays stale and
    -- cEmMgr::construct runs the previous enemy's init -> stack smash into
    -- 0xA54AB68 (PC==LR every time). Remap the id at construct entry to a real
    -- base enemy (0x68→em18, 0x66→em46, 0x6C/6D/6F→em4c/4d/4f, ema-series→em09).
    -- gameRoomInit calls vtable[0x90] on every enemy with NO null check, and the
    -- BASE cEm vtable has no entry there (_ZTV3cEm +0x90 = NULL, while cEmObj and
    -- cEm09 both have one). Any enemy left as a bare cEm therefore makes room init
    -- BLR address 0:
    --     signal 11 SEGV_MAPERR, fault addr 0x0, "null pointer dereference"
    --     #00 pc 0  <unknown>      #01 gameRoomInit()+2260   #02 ABio4::Tick
    -- Guarding the CALL SITE fixes every id at once instead of guessing which
    -- enemy ended up as a base cEm.
    if InstallGameRoomInitVCallGuard then
        pcall(function()
            local site = Offset(GetLibBase(), 0x5F43B38)   -- ldr x8,[x8,#0x90]
            local ok = InstallGameRoomInitVCallGuard(site)
            Log(TAG .. ": gameRoomInit NULL-vcall guard: " .. (ok and "installed" or "FAILED"))
        end)
    else
        LogWarn(TAG .. ": InstallGameRoomInitVCallGuard missing — rebuild the modloader")
    end

    -- EmSetFromList2 runs BEFORE cEmMgr::construct, so the construct remap below
    -- is too late for it: an id the room cannot build faults inside the spawn-list
    -- read itself, the safe-call guard "recovers" it by returning 0/0.0, and the
    -- half-built spawn takes the process down shortly after with no tombstone.
    -- Observed every time with id 0x59 (all other placed ids passed cleanly).
    -- Remapping X0 at entry means there is no fault to recover in the first place.
    -- ── THE REAL REASON U3 WAS UNKILLABLE ────────────────────────────────
    -- Found with a HARDWARE WATCHPOINT on a live U3's HP (cEm+0x3F0), not by
    -- reading code: exactly ONE writer, 3 hits while the player was shooting —
    --     libUE4.so+0x5EEF1F8  inside LifeDownSet2(cEm*, dmg, ...)
    --       v33 = hp - dmg;
    --       if (v33 <= 0 && (a4 & 1) != 0) v33 = 1;   // "keep alive" flag
    --       *(int16*)(cEm + 0x3F0) = v33;
    -- So the damage ALWAYS landed. U3's hitboxes were fine and YarareAdd had run;
    -- the caller just passes "never let this one die", which is right for scripted
    -- encounters and wrong for a boss spawned out of context. HP sat at 1 forever
    -- (its max at +0x3F2 still read the true 7500 the spawn list gave it).
    -- Clearing that bit per-em-id lets HP reach 0 so the normal death runs.
    if InstallLifeDownKeepAliveFix then
        pcall(function()
            local fn = Resolve("_Z12LifeDownSet2P3cEmiijib", 0x5EEEF88)
            local ok = InstallLifeDownKeepAliveFix(fn)
            Log(TAG .. ": LifeDownSet2 keep-alive fix: " .. (ok and "installed" or "FAILED"))
            if ok and SetEmKillable then
                -- U3 (em32 = 0x32 = 50) — the one this was diagnosed on.
                pcall(SetEmKillable, 0x32, true)
                -- The other bosses that are unkillable for the same reason when
                -- spawned outside their own scenario.
                -- Keep this list in sync with BOSS_BASE_HP in mods/re4/BossFixes:
                -- a boss with scaled HP but no keep-alive clear is unkillable, and
                -- BossFixes no longer force-kills anything to paper over it.
                --   0x09 Tyrant  0x2B El Gigante  0x2C Novistador  0x2F Salamander
                --   0x31 Saddler-After  0x33 Novistador-Event  0x35 Mendez
                --   0x37 Verdugo  0x38 Verdugo-After  0x39 Krauser  0x3F Saddler-Ada
                for _, id in ipairs({ 0x09, 0x2B, 0x2C, 0x2F, 0x31, 0x33, 0x35, 0x37, 0x38, 0x39, 0x3F }) do
                    pcall(SetEmKillable, id, true)
                end
            end
        end)
    else
        LogWarn(TAG .. ": InstallLifeDownKeepAliveFix missing — rebuild the modloader")
    end

    -- ═══════════════════════════════════════════════════════════════════
    -- CROSSOVER ID REMAP — OFF BY DEFAULT.  IT ATE LEVEL CONTENT.
    -- ═══════════════════════════════════════════════════════════════════
    -- These three hooks substitute "unbuildable" em ids with the inert object
    -- (0x50) so a MOD-SPAWNED crossover enemy cannot crash the room. The design
    -- assumption was that ids 0x59/0x60-0x6F are only ever introduced by the
    -- Randomizer / EnemySpawner. THAT ASSUMPTION IS WRONG.
    --
    -- r10b (the boat / lake level) AUTHORS ids in that range itself. With the
    -- Randomizer switched OFF and doing nothing, the log still showed:
    --     XEMAP EmSetFromList2 id 0x64 -> 0x50   (unbuildable here)
    --     XEMAP EmSetFromList2 id 0x65 -> 0x50
    --     XEMAP EmSetFromList2 id 0x69 -> 0x50
    --     XEMAP EmSetFromList2 id 0x6B -> 0x50
    --     XEMAP EmSetFromList2 id 0x6E -> 0x50
    --     XEMAP crossover em   0x60 -> em 0x50
    -- i.e. the level's OWN Salamander and boat were replaced by inert objects.
    -- Reported in-game as "it swapped the Salamander & boat".
    --
    -- is_em_id_supported() answers "can the BASE table build this id", which is
    -- NOT the same question as "did the level author it". Until the native side
    -- can tell mod-injected ids from level-authored ones, a blanket substitution
    -- is destructive and must not run. The crash it prevented only happens when
    -- a mod actually places a crossover enemy, so the correct scope is "only
    -- while a mod is injecting", not "always".
    --
    -- Flip to true only to reproduce/debug the original crossover crash.
    local ENABLE_CROSSOVER_REMAP = false

    if not ENABLE_CROSSOVER_REMAP then
        Log(TAG .. ": crossover id remap DISABLED (it substituted level-authored "
            .. "ids — r10b Salamander/boat became inert objects)")
    end

    if ENABLE_CROSSOVER_REMAP and InstallEmSetFromListIdRemap then
        pcall(function()
            local entry = Resolve("_Z14EmSetFromList2jj", 0x5EE9A6C)
            local ok = InstallEmSetFromListIdRemap(entry)
            Log(TAG .. ": EmSetFromList2 id remap: " .. (ok and "installed" or "FAILED"))
        end)
    end

    -- EmSetFromList() (no "2") is the WHOLE-LIST pass and takes NO arguments, so
    -- there is no id register to remap — it reads every id from the global spawn
    -- list (pG + 32*i + 21661, 256 slots; the same 32-byte stride the Randomizer
    -- rewrites). An unbuildable id there builds an enemy whose vtable+0x28 is
    -- garbage and the pass's final virtual call jumps to it:
    --     SIGSEGV fault=0x13c pc=0x13c  cause: EmSetFromList
    -- so the LIST itself gets cleaned before the pass reads it.
    -- Same reason as above: this one rewrote the AUTHORED spawn list in place,
    -- so it is the most destructive of the three. It was also the one taking a
    -- SIGSEGV inside EmSetFromList+0xE8 that the crash guard kept recovering.
    if ENABLE_CROSSOVER_REMAP and InstallEmSetFromListSanitize then
        pcall(function()
            local entry = Resolve("_Z13EmSetFromListv", 0x5EE9610)
            local pg    = Offset(GetLibBase(), 0x0A456E48)   -- &pG (the pointer variable)
            local ok = InstallEmSetFromListSanitize(entry, pg)
            Log(TAG .. ": EmSetFromList list sanitiser: " .. (ok and "installed" or "FAILED"))
        end)
    end

    if ENABLE_CROSSOVER_REMAP and InstallCrossoverEnemyRemap then
        pcall(function()
            local entry = Offset(GetLibBase(), 0x5D90288)   -- cEmMgr::construct
            local ok = InstallCrossoverEnemyRemap(entry)
            Log(TAG .. ": crossover enemy remap (0x60-0x6F): " .. (ok and "installed" or "FAILED"))
        end)
    end

    -- FAsyncLoadingThread::Run polls GGCSingleton+8; if the GC singleton isn't up
    -- (startup / level transition) it's NULL -> fault 0x8 -> level never loads
    -- (black). Redirect the null read to 0 = "GC idle".
    if InstallAsyncGcSingletonGuard then
        pcall(function()
            local site = Offset(GetLibBase(), 0x68957DC)   -- LDAR W8,[X8]
            local ok = InstallAsyncGcSingletonGuard(site)
            Log(TAG .. ": async-loader GGCSingleton null guard: " .. (ok and "installed" or "FAILED"))
        end)
    else
        LogWarn(TAG .. ": InstallAsyncGcSingletonGuard missing — rebuild the modloader")
    end

    -- NOTE: do NOT safe-call-guard InverseKinematics — it is called per-enemy
    -- PER FRAME, and routing something that hot through dispatch_full re-enters
    -- the recovery path and crashes libmodloader itself (fault 0x30 in
    -- dispatch_full). The IK fault-storm is instead avoided upstream: the
    -- crash-prone crossover ids are remapped to an inert cEmObj (no model, no IK)
    -- in install_crossover_enemy_remap.

    -- em32's init (sub_5E49AA0) asks SetObj00 for two sub-object models, CBZ-checks
    -- each result, then dereferences it anyway 4 instructions later:
    --   LDR X2,[X25,#0xA88] ; LDR X8,[X2,#0x180]   => SIGSEGV, fault addr 0x180
    -- SetObj00 returns NULL when cModel::modelInit can't find the model in the
    -- archive — routine for cut content, whose sub-object data never shipped.
    -- Retail never spawns em32, so nobody hit it. The punchline: the callee
    -- (VR4CreateEmSubObject) null-checks both pointers and returns, so the game
    -- dies building an argument that would have been discarded. The guard makes the
    -- two loads read a scratch buffer and zeroes the cEm arg so the callee opts out
    -- at its first `if` — no-op when the pointer isn't null.
    -- Null-`this` guards — the check the game forgot.
    --
    -- A whole family of crashes is ONE bug repeated per enemy: a NULL
    -- sub-object/model (normal for cut or unsupported content whose data the room
    -- never loaded) dereferenced with no null check. They all die as
    -- NULL+fieldOffset, reached via EmSetFromList2 -> cEmXX::move:
    --   cObjChain::setChain  -> fault 0x438   (cEm2b)
    --   cEm2d::setReset      -> fault 0x0d    (Novistador)
    -- setChain is the proof; the ENTIRE function is:
    --   *((_QWORD*)this + 135) = a2;  if (a2) return PenClothSet(this);  return this;
    -- 135*8 = 0x438 — it writes through `this` without ever checking it.
    -- Guarding the ENTRY means the enemy loses its cloth instead of the game dying.
    -- Entry hooks only: two inline hooks <16 bytes apart shred each other.
    for _, g in ipairs({
        { sym = "_ZN9cObjChain8setChainEP10CLOTH_INFO", rva = 0x5FA18F0, name = "cObjChain::setChain" },
        { sym = "_ZN5cEm2d8setResetEP3VecS1_",          rva = 0x5E2452C, name = "cEm2d::setReset"     },
        -- cModel::setParent — `this` is VALID here; the NULL is a FIELD:
        --     LDR X8, [X0,#0x108]     ; x0 fine
        --     STR X1, [X8,#0x78]      ; X8 == NULL -> fault addr 0x78
        -- Seen as: cObjLauncher::loadRocket -> cModel::setParent, i.e. the rocket
        -- launcher whose rocket model never loaded. Testing x0 alone misses it, so
        -- this one guards the field at +0x108.
        { sym = "_ZN6cModel9setParentEP6cCoordR3VecS3_", rva = 0x5F8245C,
          name = "cModel::setParent", field = 0x108 },
    }) do
        if InstallNullThisGuard then
            pcall(function()
                local a = Resolve(g.sym, g.rva)
                local ok = InstallNullThisGuard(a, g.name, g.field)
                Log(TAG .. ": null guard " .. g.name .. (g.field and (" (field +0x" .. string.format("%X", g.field) .. ")") or "")
                    .. ": " .. (ok and "installed" or "FAILED"))
            end)
        end
    end
    if not InstallNullThisGuard then
        LogWarn(TAG .. ": InstallNullThisGuard missing — rebuild the modloader")
    end

    -- IKInit(cModel*, MOTION_INFO*) — the game forgot a null check here too:
    --   PartsPtr = cModel::getPartsPtr(model, motion->partIdx[i]);
    --   v11 = *(_DWORD *)(PartsPtr + 472);      // 472 = 0x1D8  → fault addr 0x1D8
    -- getPartsPtr correctly returns NULL when the model has no such bone/part —
    -- routine for a cut/crossover enemy whose rig doesn't match the motion it was
    -- handed. Observed: cEm3c::move -> MotionSetCore -> IKInit -> SIGSEGV 0x1d8.
    -- `this` is NOT null here, so the null-this guard can't help; route it through
    -- the safe-call guard instead. The circuit breaker means a permanently broken
    -- IK trips after 8 faults and stops being called — enemies lose IK (foot
    -- placement), the game keeps its frame rate.
    -- LASER SIGHT — a REAL fix, not a crash guard.
    --
    -- Aiming at a crossover enemy whose rig has no part 0 killed the game every
    -- frame the laser was on it:
    --   5eef834  BL  cModel::getPartsPtr   ; -> NULL
    --   5eef8c4  ADD X1, X0, #0x80         ; NULL + 0x80
    --   5eef8d0  BL  MTXMultVec            ; LDP S2,S3,[X1] -> fault 0x80
    --
    -- I first "fixed" this with InstallCrashGuard. That did NOTHING, and the next
    -- tombstone proved it — thunk_4 -> dispatch_full -> GetWepTargetPos -> fault
    -- 0x80, i.e. the guard was right there in the stack and the game still died.
    -- crash_handler.cpp DELIBERATELY REMOVED all five siglongjmp recovery paths
    -- ("Crashes are meant to be seen and fixed, not hidden"), so the sigsetjmp in
    -- dispatch_full is armed and nothing ever jumps back. install_safe_call_guard
    -- logs "installed (sigsetjmp active)" and protects nothing. Same for the
    -- circuit breaker: it only counts recoveries, which never happen.
    --
    -- So neutralise the pointer instead — the em32 site-2 pattern, which held.
    if InstallLaserSightFix then
        pcall(function()
            local site = Offset(GetLibBase(), 0x5EEF8C4)   -- ADD X1, X0, #0x80
            local ok = InstallLaserSightFix(site)
            Log(TAG .. ": laser-sight null-parts fix: " .. (ok and "installed" or "FAILED"))
        end)
    else
        LogWarn(TAG .. ": InstallLaserSightFix missing — rebuild the modloader")
    end

    -- ═══════════════════════════════════════════════════════════════════════
    -- ENGINE-WIDE NULL GUARDS — the other ~3900 unguarded derefs
    -- ═══════════════════════════════════════════════════════════════════════
    -- Scanned ALL 14091 functions in the RE4 code range (0x5D00000-0x6250000), not
    -- just the ones whose NAME looked like a getter. 3456 can return NULL; after
    -- taint-tracking every call site, 38 have callers that deref the result with no
    -- null check — 3999 sites — and FOUR functions are 98% of it:
    --     cRoomData::getRoomSavePtr  2975/3176
    --     SmdGetObjPtr                651/2300
    --     cEmWrap::getPtr             158/754
    --     SceAtPtr                    125/255
    -- The devs KNEW. SmdGetObjPtr literally does
    --     LogErr(0, 0, "SmdGetObjPtr() invalid ID [%d] used", a1);
    -- and cEmWrap::getPtr does
    --     LogErr(0, 0, "EM_SET_NO(%d) cEmWrap::getPtr error", ...)
    -- immediately before `return 0`. They wrote the diagnostic and shipped 3900
    -- callers that deref it anyway.
    --
    -- A plain dummy would be WORSE than the crash here, which is why this is not a
    -- blanket patch: those three get vtable-dispatched (8/29/30 verified sites, by
    -- checking the BLR target is a reg LOADED FROM the pointer — the naive "any BLR
    -- nearby" count was 3x inflated), so a zeroed dummy would BLR a NULL slot; and
    -- 3/3/8 callers sit in loops that EXIT on NULL, which a non-NULL dummy would
    -- spin forever. So: the dummy carries a stub vtable (every slot returns 0), and
    -- the guard is return-address aware — those 14 exact call sites still get a real
    -- NULL. All four only return NULL for INVALID input (bad room id, OOB index,
    -- dead cEm, id not found), i.e. cases that were going to fault anyway, so this
    -- never displaces working behaviour.
    if InstallNullReturnGuards then
        pcall(function()
            local ok = InstallNullReturnGuards()
            Log(TAG .. ": engine null guards: " .. (ok and "installed" or "FAILED")
                .. " — covers ~3909 unguarded derefs")
        end)
    else
        LogWarn(TAG .. ": InstallNullReturnGuards missing — rebuild the modloader")
    end

    -- ═══════════════════════════════════════════════════════════════════════
    -- THE ROOT FIX — cModel::getPartsPtr
    -- ═══════════════════════════════════════════════════════════════════════
    -- I spent a whole session fixing this family ONE VICTIM AT A TIME: setChain,
    -- setReset, setParent, em32, the laser sight, Emmark, the XSB parser. Every fix
    -- was real and every one was a symptom. A scan of every call site in libUE4:
    --
    --     cModel::getPartsPtr — 2420 call sites, 1101 UNGUARDED, 82 guarded
    --
    -- 1101 places deref that pointer without ever testing it. That is the engine's
    -- house style — "the part is always there" — true for authored rooms, false the
    -- instant an enemy stands somewhere it was never authored. The victims I chased
    -- are just the handful that happen to get hit first:
    --     IKInit            *(getPartsPtr(..) + 472)   -> fault 0x1d8
    --     GetWepTargetPos   ADD X1, getPartsPtr, #0x80 -> fault 0x80
    --     cModel::setParent                            -> fault 0x108 = 264,
    --                       which is getPartsPtr's OWN list walk doing *(NULL+264)
    --
    -- So patch the source, not the 1101. NULL -> a zeroed self-chaining dummy, and
    -- the list walk gets the null check the devs left out. Checked the one way this
    -- could backfire BEFORE writing it: a caller doing `while (getPartsPtr(i++))`
    -- would spin forever on a non-NULL dummy. Scanned for it — 0 such loops, as the
    -- code predicts (ARRAY mode never returns NULL, so NULL-termination was never
    -- usable). Trade-off, stated honestly: the 82 sites that DO null-check now get a
    -- zeroed part instead of skipping — a visual no-op, not a crash, for 1101 crash
    -- sites closed.
    if InstallGetPartsPtrGuard then
        pcall(function()
            local site = Offset(GetLibBase(), 0x5F81AFC)   -- cModel::getPartsPtr(int)
            local ok = InstallGetPartsPtrGuard(site)
            Log(TAG .. ": getPartsPtr root guard: " .. (ok and "installed" or "FAILED")
                .. " — covers 1101 unguarded derefs")
        end)
    else
        LogWarn(TAG .. ": InstallGetPartsPtrGuard missing — rebuild the modloader")
    end

    -- ── Enemy sound bank over-run — SEGV_ACCERR in StrToI ───────────────────
    -- tombstone_30: StrToI <- ExtractTrackIndex <- ExtractTracksFromXSB <-
    -- TryLoadGenericFromDas <- ArmLoadSoundBlockEnemy <- cEmMgr::construct.
    -- This is a REAL GAME BUG in ExtractTrackIndex, not a missing null check:
    --     result = strtol(*a2, &endptr, 10);           <== reads the cursor FIRST
    --     if (v7 < *(u64*)(this+192) + hdr[42] + hdr[30])   <== bounds-checks AFTER
    -- The bound is right and the walk loop honours it; only the first read escapes
    -- it. Authored rooms always ship an .xsb with as many tracks as the .das wants,
    -- so the cursor never starts past the end and the bug never fires. Crossover
    -- enemies get a room whose .xsb is short => cursor off the buffer => ACCERR.
    -- (ACCERR not MAPERR = just past a live allocation, i.e. an over-run.)
    -- The guard applies the game's own bound before the read. Skipping a track is
    -- safe: ArmLoadSoundBlockEnemy already falls back to LoadGeneric ("em"/"pl")
    -- whenever the .das sound load fails, so worst case is generic sounds.
    if InstallXsbTrackBoundsGuard then
        pcall(function()
            local site = Offset(GetLibBase(), 0x61AF06C)   -- CArmSoundBlock::ExtractTrackIndex
            local ok = InstallXsbTrackBoundsGuard(site)
            Log(TAG .. ": XSB track-bounds guard: " .. (ok and "installed" or "FAILED"))
        end)
    else
        LogWarn(TAG .. ": InstallXsbTrackBoundsGuard missing — rebuild the modloader")
    end

    -- ── cEmMark (shooting-gallery target) in a normal room — fault 0x181 ─────
    -- tombstone_29: armIsShootingGamePaused()+24 <- cEmMark::move()+20 <- cEmMgr::move.
    --     60d1b10  ADRP X8, #qword_A597D28@PAGE
    --     60d1b14  LDR  X8, [X8,#qword_A597D28@PAGEOFF]  ; shooting-minigame mgr
    --     60d1b18  LDRB W8, [X8,#0x181]                  ; <== NULL -> fault 0x181
    --     60d1b1c  CMP  W8, #0
    --     60d1b20  CSET W0, NE                           ; return (paused != 0)
    --
    -- Two facts from IDA make this surgical rather than a guess:
    --   * qword_A597D28 has exactly ONE writer in the entire binary — R22cInit —
    --     so the manager only exists while the shooting range is loaded and is
    --     NULL in every other room. The randomizer putting a mark anywhere else
    --     therefore ALWAYS hits this.
    --   * armIsShootingGamePaused has exactly ONE caller (cEmMark::move), so
    --     neutralising it cannot touch any other enemy.
    -- Zeroing the pointer makes the byte read 0 => W0 = 0 = "not paused", which is
    -- the truthful answer when the minigame is not running, and the mark then
    -- moves like a normal enemy instead of killing the process.
    if InstallShootGamePausedGuard then
        pcall(function()
            local site = Offset(GetLibBase(), 0x60D1B18)   -- LDRB W8,[X8,#0x181]
            local ok = InstallShootGamePausedGuard(site)
            Log(TAG .. ": cEmMark shooting-game null guard: " .. (ok and "installed" or "FAILED"))
        end)
    else
        LogWarn(TAG .. ": InstallShootGamePausedGuard missing — rebuild the modloader")
    end

    -- NOTE: IKInit still had its InstallCrashGuard removed (getPartsPtr NULL ->
    -- *(NULL+472) fault 0x1d8) — it's per-enemy and a real fix is still owed.

    -- CArmSoundBlock::ExtractTracksFromXSB (0x61ae54c) — the XSB track parser.
    -- When a spawned enemy's sound bank is missing (crossover / Randomizer picks an
    -- enemy this room never authored), LoadXSBFile returns a header whose track
    -- offset-table points into the absent bank. The inner ExtractTrackIndex then
    -- walks a string with bounds *(hdr+42)+*(hdr+30) that run off the mapping ->
    -- SEGV_ACCERR *inside a tight loop*. The global instruction-skipper "recovers"
    -- each fault but immediately re-enters the same loop and re-faults — hundreds
    -- of signal round-trips per call = the EXTREME LAG (not a crash; the room shows).
    --
    -- crash_guard was rebuilt since the old "guards are inert" note — siglongjmp
    -- recovery works now. Guarding the parent chokepoint (every sound path —
    -- SndInit2/LoadRoomData/LoadWeapon/LoadGeneric — funnels through it) converts
    -- the storm into ONE clean bail: it returns 0 = "no XSB", the game's own
    -- no-sound path. Enemy is silent; game is smooth. Sound is not gameplay-
    -- critical (unlike U3's hitboxes below), so bailing here is safe.
    if InstallCrashGuard then
        pcall(function()
            local xsb = Offset(GetLibBase(), 0x61ae54c)   -- CArmSoundBlock::ExtractTracksFromXSB
            local ok = InstallCrashGuard(xsb, "CArmSoundBlock::ExtractTracksFromXSB")
            Log(TAG .. ": XSB track-parser storm guard: " .. (ok and "installed" or "FAILED"))
        end)
    else
        LogWarn(TAG .. ": InstallCrashGuard missing — rebuild the modloader")
    end

    -- U3 "It" (emId 50 = 0x32 = cEm32) — killable OUTSIDE its scripted level.
    --
    -- This is the same bug as the fault-0x180 crash, wearing a different hat.
    -- sub_5E49AA0 (U3's init) builds its parts model with:
    --     SetObj00(U3_archive + [U3_archive+596],       -- its own archive: fine
    --              [pG+0x68] + [[pG+0x68]+20], ...)     -- a GLOBAL/stage archive
    -- Away from U3's level that global archive doesn't hold the parts, modelInit
    -- fails, SetObj00 returns 0, and the game dereferences the NULL it JUST
    -- null-checked:  *((_QWORD*)v50 + 48)  ->  NULL + 384  ->  fault 0x180.
    --
    -- Everything after that line is U3's combat setup — YarareInit + ~28
    -- YarareAdd calls, which ARE its damage regions. So the crash guard "fixing"
    -- the crash by siglongjmp-ing out is EXACTLY what made U3 invulnerable: the
    -- init never reaches its hitboxes. No guard can make U3 killable; the init has
    -- to complete.
    --
    -- Fix: when SetObj00 fails inside U3's init, retry with U3's OWN archive for
    -- the skeleton param — the same source modelInit uses for U3's MAIN model
    -- (modelInit(a1, arch+[arch+16], arch+[arch+20])). Model builds -> no NULL ->
    -- init runs to the end -> YarareAdd registers the hitboxes -> U3 is killable.
    -- Installed BEFORE the em32 guard on purpose: the guard is only a backstop for
    -- the case where the retry can't build it either.
    if InstallU3KillableFix then
        pcall(function()
            -- sub_5E49AA0 has no symbol (it's a sub_), so use the RVA directly.
            local init = Offset(GetLibBase(), 0x5E49AA0)
            local so   = Resolve("_Z8SetObj00mmP3VecS0_", 0x5F8AEB4)
            local ok = InstallU3KillableFix(init, so)
            Log(TAG .. ": U3 (em32) killable-anywhere fix: " .. (ok and "installed" or "FAILED"))
        end)
    else
        LogWarn(TAG .. ": InstallU3KillableFix missing — rebuild the modloader")
    end

    if InstallEm32SubObjectGuard then
        pcall(function()
            local ok = InstallEm32SubObjectGuard()
            Log(TAG .. ": em32 sub-object null guard: " .. (ok and "installed" or "FAILED")
                .. " — missing sub-object models skip instead of crashing")
        end)
    else
        LogWarn(TAG .. ": InstallEm32SubObjectGuard missing — rebuild the modloader")
    end

    if InstallModelRestore then
        for _, e in ipairs(MOVE_ADDRS) do
            local addr = nil
            pcall(function() addr = Resolve(e.sym, e.rva) end)
            if safePtr(addr) then
                local ok = false
                pcall(function() ok = InstallModelRestore(addr) end)
                Log(TAG .. ": model-restore " .. e.name .. " @ " .. ToHex(addr)
                    .. " : " .. (ok and "installed" or "FAILED"))
            else
                LogWarn(TAG .. ": " .. e.name .. "::move not resolved — model-restore skipped")
            end
        end
    else
        LogWarn(TAG .. ": InstallModelRestore missing (modloader too old?) — cut enemies stay invisible")
    end
end

-- ═══════════════════════════════════════════════════════════════════════
-- 2. MODEL-CLASS PROVISION — fill cut-enemy model slots from EnemyFixes_P.pak
-- ═══════════════════════════════════════════════════════════════════════
-- emId → Poseable Blueprint class path (exact casing from the pak index).
-- Villager Ganados + Vehicles resolve via GetEmModelClass (EmModelData);
-- em3f (Saddler-Ada, a Boss) resolves via GetEtcModelClass (EtcModelData).
-- Both lookups are hooked and fed from this ONE table — each fills its own
-- ModelData instance for the requested id, so we never need to know in
-- advance which lookup a given enemy uses (filling the other, unused
-- instance's slot is harmless — it is simply never read).
local V_DIR   = "/Game/Blueprints/Characters/Ganado/Villager/"
local VEH_DIR = "/Game/Blueprints/Characters/Vehicles/"
local PL_DIR  = "/Game/Blueprints/Characters/Player/"

-- Ganados + Vehicles + cutscene NPCs resolve via GetEmModelClass → EmModelData
-- (DS+0x80). cEm AND cPl both call cEm::EmModelClassLookUp, which reads the
-- emId at cEm+0x118 and looks up EmModelData[emId] — so the same table covers
-- gameplay enemies and the cutscene "player-style" NPCs.
local EM_MODELS = {
    -- emId 0x07 is a VILLAGER GANADO, not the police. It was wired to
    -- PL07_Police_Poseable_BP on the belief that "the port intended id 7 = police"
    -- — but that belief came from reading back THIS line, which we had written.
    -- The pak settles it: em07_meshTable is 132 rows and IDENTICAL to
    -- em09/em10_meshTable (same keys, same em1000/em1001/em10rh00 meshes), and
    -- EmFileTbl[7] maps to em/em10.das (the ganado archive) like ids 6/8/9/A/B/D.
    -- Em07_Poseable is the correct model; it matches the archive the id loads.
    -- (PL07_Police is a SEPARATE cutscene cop: Player/pl07_Police_MeshTable, keys
    -- 128/179488/320736/500448/660352 into the 11-entry pl07.das. Different
    -- character, different archive — not this id.)
    [0x06] = V_DIR   .. "Em07_Poseable.Em07_Poseable_C",  -- shares em10.das; no dedicated BP
    [0x07] = V_DIR   .. "Em07_Poseable.Em07_Poseable_C",
    [0x08] = V_DIR   .. "Em08_Poseable.Em08_Poseable_C",
    [0x09] = V_DIR   .. "Em09_Poseable.Em09_Poseable_C",
    -- 0x0A / 0x0B / 0x0D were MISSING, and that is why they could not spawn:
    -- install_cut_villager_fix makes them constructible (prolog 0x82 -> _prologEm09,
    -- confirmed in the log), but with no model class registered the factory
    -- (EmMgr vtable+56) fails, EmSetEvent returns errEm, and EnemySpawner reported
    -- "EmSetEvent returned NULL" — then retried 19 positions and smashed the stack.
    --
    -- They belong here for the SAME reason 6/7/8 do: EmFileTbl maps ids
    -- 6/7/8/9/A/B/D to em/em10.das, the ganado archive (see the note above), so
    -- the ganado poseable is the model that matches the archive the id loads.
    --
    -- ⚠ NOTE: these are ganado variants, NOT characters. EnemySpawner labels
    -- 0x0A "Krauser (NPC)", 0x0D "Wesker", 0x06 "HUNK" — that comes from the
    -- PLAYER id space (PL0A_Krauser / PL0D_Wesker / PL06_Hunk), which is a
    -- DIFFERENT table. The real Krauser enemy is em 0x39 (EM39_Poseable_BP),
    -- already in the spawner as "Krauser Knife (No3)" / "Krauser Mutant" (id 57).
    [0x0A] = V_DIR   .. "Em10_Poseable.Em10_Poseable_C",
    [0x0B] = V_DIR   .. "Em10_Poseable.Em10_Poseable_C",
    [0x0D] = V_DIR   .. "Em10_Poseable.Em10_Poseable_C",
    [0x10] = V_DIR   .. "Em10_Poseable.Em10_Poseable_C",
    [0x33] = V_DIR   .. "Em33_Poseable.Em33_Poseable_C",
    [0x37] = V_DIR   .. "Em37_Poseable.Em37_Poseable_C",
    [0x40] = V_DIR   .. "Em40_Poseable.Em40_Poseable_C",
    [0x41] = V_DIR   .. "Em41_Poseable.Em41_Poseable_C",
    [0x42] = V_DIR   .. "Em42_Poseable.Em42_Poseable_C",
    [0x44] = V_DIR   .. "Em44_Poseable.Em44_Poseable_C",
    [0x45] = V_DIR   .. "Em45_Poseable.Em45_Poseable_C",
    [0x4b] = VEH_DIR .. "Em4b_Poseable.Em4b_Poseable_C",
    [0x4e] = VEH_DIR .. "Em4e_Poseable.Em4e_Poseable_C",
}
-- em3f (Saddler-Ada) is a Boss — resolves via GetEtcModelClass → EtcModelData (DS+0x88).
local ETC_MODELS = {
    [0x3f] = "/Game/Blueprints/Characters/Bosses/EM3F_Poseable_BP.EM3F_Poseable_BP_C",
}
local function cutModelCount()
    local n = 0
    for _ in pairs(EM_MODELS) do n = n + 1 end
    for _ in pairs(ETC_MODELS) do n = n + 1 end
    return n
end

-- Cache the interned FName comparison index per path (created lazily — the
-- FName pool must be up, which it is by the time we run in-level).
local fnIdxCache = {}
local function fnameIndexFor(path)
    local c = fnIdxCache[path]
    if c then return c end
    local ok, fn = pcall(FName, path)
    if not ok or not fn then return nil end
    local idx = nil
    pcall(function() idx = fn:GetComparisonIndex() end)
    if idx then fnIdxCache[path] = idx end
    return idx
end

-- Write a full-path FName into slot[id]'s FSoftObjectPath.AssetPathName so
-- GetClassWithIndex → LoadSynchronous loads the class from the pak.
-- FSoftObjectPtr (40B): WeakPtr{ObjIdx@0,Serial@4} CachedTag@8
--   FSoftObjectPath{ AssetPathName FName{Comp@0x10,Num@0x14}, SubPath FString@0x18 }
local fillStats = { filled = 0, already = 0 }
local function fillModelSlot(instOff, emId, path)
    local ds = resolveDataSingleton()
    if not ds then return false end
    local inst = nil
    pcall(function() inst = ReadPtr(Offset(ds, instOff)) end)
    if not safePtr(inst) then return false end

    local count = 0
    pcall(function() count = ReadU32(Offset(inst, COUNT_OFF)) or 0 end)
    if emId < 0 or emId >= count then return false end   -- out of this instance's range

    local arr = nil
    pcall(function() arr = ReadPtr(Offset(inst, LIST_OFF)) end)
    if not safePtr(arr) then return false end

    local idx = fnameIndexFor(path)
    if not idx then return false end

    local slot = Offset(arr, emId * STRIDE)

    -- Idempotent: slot already carries our AssetPathName? (LoadSynchronous
    -- populates the WeakPtr but leaves AssetPathName intact, so this stays true
    -- once loaded — we never needlessly re-trigger a load.)
    local cur = nil
    pcall(function() cur = ReadU32(Offset(slot, 0x10)) end)
    if cur == idx then fillStats.already = fillStats.already + 1; return true end

    local ok = pcall(function()
        WriteU32(slot, 0xFFFFFFFF);        WriteU32(Offset(slot, 0x04), 0)  -- WeakPtr = null
        WriteU32(Offset(slot, 0x08), 0);   WriteU32(Offset(slot, 0x0C), 0)  -- CachedTag + pad
        WriteU32(Offset(slot, 0x10), idx); WriteU32(Offset(slot, 0x14), 0)  -- AssetPathName FName
        WriteU64(Offset(slot, 0x18), 0)                                     -- SubPath ptr
        WriteU32(Offset(slot, 0x20), 0);   WriteU32(Offset(slot, 0x24), 0)  -- SubPath count/max
    end)
    if ok then
        fillStats.filled = fillStats.filled + 1
        Log(TAG .. string.format(": filled slot[0x%X] -> %s", emId, path))
        return true
    end
    return false
end

-- Fill every cut slot in its correct ModelData instance. Returns writes done.
local function fillAllNow()
    local n = 0
    for emId, path in pairs(EM_MODELS)  do if fillModelSlot(EM_OFF,  emId, path) then n = n + 1 end end
    for emId, path in pairs(ETC_MODELS) do if fillModelSlot(ETC_OFF, emId, path) then n = n + 1 end end
    return n
end

-- PROACTIVE FILL via LoopAsync — runs on the GAME THREAD at a clean drain
-- point (NOT re-entrant like a native-hook Lua callback, so no shared
-- lua_State race — the crash class from cut-content spawn waves). Fills once
-- the DataSingleton is live (in-level); idempotent, so it also re-fills after
-- a level change re-creates the ModelData instances. The engine's own
-- LoadSynchronous streams the Poseable BP in on the enemy's next lookup.
local loopHandle = nil
pcall(function()
    loopHandle = LoopAsync(1500, function()
        if not resolveDataSingleton() then return end   -- not in a level yet
        fillAllNow()
    end)
end)
if loopHandle then
    Log(TAG .. ": model-fill loop active (1.5s, game-thread) — " .. cutModelCount() .. " cut models")
else
    LogWarn(TAG .. ": LoopAsync unavailable — cut models fill only via 'cut_fill' command")
end

RegisterCommand("cut_fill", function()
    local n = fillAllNow()
    Log(TAG .. string.format(": cut_fill — %d writes (filled=%d already=%d)",
        n, fillStats.filled, fillStats.already))
end)
RegisterCommand("cut_status", function()
    local ds = resolveDataSingleton()
    Log(TAG .. ": DataSingleton = " .. (ds and ToHex(ds) or "NOT READY (load a level)"))
    Log(TAG .. string.format(": fills=%d already=%d | %d cut models mapped",
        fillStats.filled, fillStats.already, cutModelCount()))
end)

-- ═══════════════════════════════════════════════════════════════════════
-- 3. TYRANT AI (em09) — state-machine monitor + control (folded TyrantAI v3.1)
-- ═══════════════════════════════════════════════════════════════════════
local OFF = {
    mainState = 0x114, subState = 0x115, phase = 0x116, param = 0x117,
    emId = 0x118, posX = 0x0A4, posY = 0x178, posZ = 0x0AC,
    hp = 0x3F0, distSq = 0x458, animTable = 0x460, routeFlags = 0x4FD,
    angle = 0x72D, grabFlag = 0x779,
}
local STATE_NAMES = {
    [0x0000]="INIT",[0x0001]="IDLE",[0x0002]="HIT_REACT",[0x0003]="DEAD",
    [0x0101]="APPROACH",[0x0401]="PATHFIND",[0x0501]="CHASE",[0x0601]="REPO_FWD",
    [0x0701]="ATK_RANGE",[0x0801]="CLOSE_ATK",[0x0901]="TURN_ATK",
}
local function stateName(p)
    if not p then return "?" end
    if STATE_NAMES[p] then return STATE_NAMES[p] end
    return "S" .. (p & 0xFF) .. ":" .. ((p >> 8) & 0xFF)
end
-- HP is an int16, not int32. cEmWrap::setHp does
--     if (wrap[11]==1 && (cem=*(cEm**)wrap) && (cem->flags & 0x201)==1)
--         *(int16*)(cem + 1008) = hp;      // 1008 = 0x3F0
-- Reading S32 here splices the adjacent field into the value, which is exactly
-- why the monitor kept printing nonsense like "HP=196611000" / "HP=491527500".
local function tGetHP(p)      return ReadU16(Offset(p, OFF.hp)) end

-- Is this pointer STILL a live em09? Two things make a tracked pointer go bad:
--   1. install_cut_villager_fix() wires ids 6/7/8/A/B/D/33/37 to _prologEm09, so
--      Em09Init fires for every VILLAGER too and they all get tracked as Tyrants.
--   2. When a spawn faults and the safe-call guard recovers (or the Randomizer
--      rewrites the level), the enemy is freed/reused WITHOUT cEm09_dtor running,
--      so untrackTyrant is never called and the pointer dangles.
-- The poll then reads freed memory every 250ms. That is what produced
--     "Tyrant S255:255 -> INIT [HP=...]"
-- (state 0xFFFF = the all-ones pattern of unmapped/freed memory) immediately
-- before the process died with no tombstone. Validate before every read.
-- Every id that install_cut_villager_fix() wires to _prologEm09 is CONSTRUCTED as
-- a cEm09 object, so the em09 state machine (and the stuck-in-INIT watchdog below)
-- applies to all of them — not just literal em09. Restricting this to id==9 is why
-- the watchdog never saw the real offenders: the two objects caught pegging the
-- game thread were emId 0x33 and 0x37, both on this list.
-- Doubles as the dangling-pointer guard: freed/reused memory reads back as 0x00 or
-- 0xFF, neither of which is in this set.
local EM09_CLASS_IDS = {
    [0x06] = true, [0x07] = true, [0x08] = true, [0x09] = true, [0x0A] = true,
    [0x0B] = true, [0x0D] = true, [0x33] = true, [0x37] = true,
}
local function tIsLiveTyrant(p)
    if not p or p == 0 then return false end
    local ok, id = pcall(function() return ReadU8(Offset(p, OFF.emId)) end)
    if not ok or id == nil then return false end
    return EM09_CLASS_IDS[id] == true
end
local function tGetState(p)   return ReadU16(Offset(p, OFF.mainState)) end
local function tGetMain(p)    return ReadU8(Offset(p, OFF.mainState)) end
local function tSetState(p,v) WriteU16(Offset(p, OFF.mainState), v) end
local function tSetPhase(p,v) WriteU8(Offset(p, OFF.phase), v) end
local function tSetParam(p,v) WriteU8(Offset(p, OFF.param), v) end
local function tSetHP(p,v)    WriteS32(Offset(p, OFF.hp), v) end
local function tGetAnim(p)    return ReadPointer(Offset(p, OFF.animTable)) end
local function tGetDistSq(p)  return ReadFloat(Offset(p, OFF.distSq)) end
local function tGetAngle(p)   return ReadFloat(Offset(p, OFF.angle)) end

local tyrants = { instances = {}, count = 0, logTransitions = true, verbose = false }

local function trackTyrant(ptr)
    if not tyrants.instances[ptr] then
        -- no moveCount: counting move() calls needs a per-frame hook, and a Lua
        -- callback on cEm09::move is what corrupted the heap. transitions is kept
        -- and maintained by the poll instead.
        tyrants.instances[ptr] = { ptr=ptr, lastState=-1, spawnTime=os.clock(), transitions=0 }
        tyrants.count = tyrants.count + 1
        -- ToHex(ptr), NOT string.format("%X", ptr): ptr is light userdata and %X
        -- wants a number, which raises a sol::error that aborts the process.
        Log(TAG .. ": Tyrant SPAWNED @ " .. ToHex(ptr) .. " (total " .. tyrants.count .. ")")
    end
    return tyrants.instances[ptr]
end
local function untrackTyrant(ptr)
    local inst = tyrants.instances[ptr]
    if inst then
        Log(TAG .. ": Tyrant DESTROYED @ " .. ToHex(ptr)
            .. string.format(" (lived %.1fs transitions=%d)",
                os.clock() - inst.spawnTime, inst.transitions or 0))
        tyrants.instances[ptr] = nil
        tyrants.count = tyrants.count - 1
    end
end
local function forEachTyrant(fn)
    local n = 0
    for _, inst in pairs(tyrants.instances) do fn(inst.ptr, inst); n = n + 1 end
    if n == 0 then Log(TAG .. ": No live Tyrants") end
    return n
end

pcall(function()
    RegisterNativeHook("Em09Init", function(emPtr) return emPtr end,
        function(retval, emPtr)
            if emPtr ~= 0 then trackTyrant(emPtr) end
            return retval
        end)
    Log(TAG .. ": Hook — Em09Init (Tyrant spawn)")
end)

-- Tyrant state monitor — POLLED, never hooked.
--
-- This used to be a Lua callback on cEm09::move. That is the single thing we must
-- never do: move() runs on the game thread ONCE PER ENEMY PER FRAME, and the
-- callback did Lua table inserts and string.format allocations on every call,
-- racing the shared lua_State against the mod loop and bridge thread. It got far
-- worse once install_cut_villager_fix() wired ids 6/7/8/A/B/D/33/37 to
-- _prologEm09: cEm09::move then fires for EVERY VILLAGER in the room, not just a
-- Tyrant, so a whole room's worth of enemies each allocated Lua every frame. The
-- corruption showed up as SIGSEGV/SEGV_ACCERR with the PC executing INSIDE THE
-- STACK (a BR through a smashed pointer) — nowhere near this code.
--
-- The giveaway that it was reading nonsense: it logged
--   "Tyrant S255:255 -> INIT [HP=196611000 dist=8833]"
-- i.e. Tyrant offsets (hp @0x3F0) read off a villager cEm that has no such field.
--
-- This was only ever DIAGNOSTICS — it drives no AI. tyrant_status already reads
-- state live on demand, so polling loses nothing but the moveCount counter, and
-- the poll runs on the modloader's own timer instead of the render-critical path.
local TYRANT_POLL_SEC = 0.25
pcall(function()
    LoopAsync(math.floor(TYRANT_POLL_SEC * 1000), function()
        -- NOTE: the stuck-in-INIT watchdog below must run even when transition
        -- LOGGING is off, so this no longer early-returns on logTransitions —
        -- that flag now gates only the log line.
        -- Drop dangling/never-really-a-Tyrant entries BEFORE reading anything off
        -- them. Without this the poll dereferences freed memory every 250ms.
        local dead = nil
        for ptr, _ in pairs(tyrants.instances) do
            if not tIsLiveTyrant(ptr) then
                dead = dead or {}
                dead[#dead + 1] = ptr
            end
        end
        if dead then
            for _, ptr in ipairs(dead) do
                tyrants.instances[ptr] = nil
                tyrants.count = math.max(0, tyrants.count - 1)
            end
        end
        -- ── STUCK-IN-INIT WATCHDOG ──────────────────────────────────────────
        -- THE 99%-GAME-THREAD BUG. cEm09::move dispatches on the state byte at
        -- +0x114 through a function-pointer table (0x9D3D660, indexed with NO
        -- bounds check), and state 0 is the spawn/init handler @0x5D91D80. That
        -- handler is meant to run for ONE frame and advance the state. A cut id
        -- wired to _prologEm09 (0x33/0x37/...) spawned outside its own scenario
        -- never gets the data it needs to advance, so it re-runs the whole init
        -- EVERY FRAME — re-setting HP to 1000, redoing motion setup, and landing
        -- in an indirect call to libm fmod with garbage operands. fmod's remainder
        -- loop costs one iteration per bit of exponent difference, so a single
        -- stuck enemy pegged the game thread at 99% with 99.5% of all samples in
        -- fmod. Proven live: poking this one byte 0->1 dropped the game thread
        -- from 99% to 75% and removed fmod from the profile entirely.
        -- Repair, don't remove: state 1 = IDLE, the same value the tyrant_idle
        -- command writes, so the enemy stays alive and playable.
        for ptr, inst in pairs(tyrants.instances) do
            local mok, main = pcall(tGetMain, ptr)
            if mok and main == 0 then
                inst.initPolls = (inst.initPolls or 0) + 1
                -- A healthy init clears within a frame. 8 polls = ~2s, far beyond
                -- any legitimate INIT, so this cannot fight a normal spawn.
                if inst.initPolls >= 8 then
                    inst.initPolls = 0
                    inst.initRepairs = (inst.initRepairs or 0) + 1
                    pcall(tSetState, ptr, 0x0001)
                    pcall(tSetPhase, ptr, 0)
                    pcall(tSetParam, ptr, 0)
                    if inst.initRepairs <= 5 then
                        -- ptr is LIGHT USERDATA, not a number: string.format("%X", ptr)
                        -- raises "bad argument #2 to 'format'", and because this runs
                        -- inside the Lua tick the sol::error escapes into native code
                        -- and ABORTS THE PROCESS (tombstone_08). ToHex() is the
                        -- pointer formatter — use it, never %X/%d, for a pointer.
                        pcall(function()
                            Log(TAG .. ": Tyrant/cut-em stuck in INIT @ " .. ToHex(ptr)
                                .. " — forced to IDLE (repair #" .. inst.initRepairs .. ")")
                        end)
                    end
                end
            else
                inst.initPolls = 0
            end
        end

        if not tyrants.logTransitions then return false end
        for ptr, inst in pairs(tyrants.instances) do
            local ok, packed = pcall(tGetState, ptr)
            if ok and packed and packed ~= inst.lastState then
                local hp   = select(2, pcall(tGetHP, ptr))
                local dsq  = select(2, pcall(tGetDistSq, ptr))
                Log(TAG .. string.format(": Tyrant %s -> %s [HP=%s dist=%.0f]",
                    stateName(inst.lastState), stateName(packed), tostring(hp),
                    math.sqrt(math.max(0, tonumber(dsq) or 0))))
                inst.transitions = inst.transitions + 1
                inst.lastState = packed
            end
        end
        return false   -- keep polling
    end)
    Log(TAG .. ": Tyrant AI monitor — polled every " .. TYRANT_POLL_SEC
        .. "s (NOT hooked on cEm09::move; a per-frame Lua hook there corrupts the heap)")
end)

pcall(function()
    local dtor = Resolve("_ZN5cEm09D0Ev", 0x05D91D7C)
    if safePtr(dtor) then
        RegisterNativeHookAt(dtor, "cEm09_dtor",
            function(emPtr) untrackTyrant(emPtr); return emPtr end, nil)
        Log(TAG .. ": Hook — cEm09::~cEm09 @ " .. ToHex(dtor) .. " (Tyrant destroy)")
    end
end)

RegisterCommand("tyrant_status", function()
    forEachTyrant(function(ptr, inst)
        -- Read live, on demand — no per-frame hook needed to answer this.
        -- Both ptr and tGetAnim()'s result are light userdata — they must go
        -- through ToHex(), not %X, or this command aborts the process.
        Log("── Tyrant @ " .. ToHex(ptr) .. " ── " .. stateName(tGetState(ptr))
            .. " HP=" .. tostring(tGetHP(ptr))
            .. string.format(" dist=%.0f", math.sqrt(math.max(0, tGetDistSq(ptr) or 0)))
            .. " anim=" .. ToHex(tGetAnim(ptr))
            .. " transitions=" .. tostring(inst.transitions or 0))
    end)
end)
RegisterCommand("tyrant_idle",   function() forEachTyrant(function(p) tSetState(p,0x0001); tSetPhase(p,0); tSetParam(p,0); Log(TAG..": Tyrant → IDLE") end) end)
RegisterCommand("tyrant_chase",  function() forEachTyrant(function(p) tSetState(p,0x0501); tSetPhase(p,0); tSetParam(p,0); Log(TAG..": Tyrant → CHASE") end) end)
RegisterCommand("tyrant_attack", function() forEachTyrant(function(p) tSetState(p,0x0801); tSetPhase(p,0); tSetParam(p,0); Log(TAG..": Tyrant → CLOSE_ATK") end) end)
RegisterCommand("tyrant_heal",   function() forEachTyrant(function(p)
    tSetHP(p,1000)
    if tGetMain(p) == 3 then tSetState(p,0x0001); tSetPhase(p,0); Log(TAG..": Tyrant revived → IDLE") else Log(TAG..": Tyrant healed 1000") end
end) end)
RegisterCommand("tyrant_god",    function() forEachTyrant(function(p) tSetHP(p,99999); Log(TAG..": Tyrant god ON") end) end)

-- ═══════════════════════════════════════════════════════════════════════
-- SHARED API + DEBUG MENU
-- ═══════════════════════════════════════════════════════════════════════
if SharedAPI then
    SharedAPI.CutContentRestorer = {
        fillAllNow  = fillAllNow,
        EM_MODELS   = EM_MODELS,
        ETC_MODELS  = ETC_MODELS,
        fillStats   = fillStats,
        TyrantAI    = { tracker = tyrants, forEachTyrant = forEachTyrant,
                        getHP = tGetHP, setHP = tSetHP, stateName = stateName },
    }
end
if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterAction("CutContent", "Fill Cut Models", function() fillAllNow() end)
    SharedAPI.DebugMenu.RegisterAction("CutContent", "Cut Status",
        function() Log(TAG .. string.format(": fills=%d already=%d", fillStats.filled, fillStats.already)) end)
    SharedAPI.DebugMenu.RegisterAction("TyrantAI", "Tyrant Status",
        function() forEachTyrant(function(p) Log(TAG..": "..stateName(tGetState(p)).." HP="..tostring(tGetHP(p))) end) end)
end

Log(TAG .. ": v1.0 loaded — cloth-crash guard + " .. cutModelCount()
    .. " cut-enemy models (Em/Etc provision) + Tyrant AI"
    .. " | needs EnemyFixes_P.pak | cmds: cut_fill, cut_status, tyrant_*")
