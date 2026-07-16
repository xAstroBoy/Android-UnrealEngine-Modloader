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
local function tGetHP(p)      return ReadS32(Offset(p, OFF.hp)) end
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
        tyrants.instances[ptr] = { ptr=ptr, lastState=-1, spawnTime=os.clock(), moveCount=0, transitions=0 }
        tyrants.count = tyrants.count + 1
        Log(TAG .. string.format(": Tyrant SPAWNED @ 0x%X (total %d)", ptr, tyrants.count))
    end
    return tyrants.instances[ptr]
end
local function untrackTyrant(ptr)
    local inst = tyrants.instances[ptr]
    if inst then
        Log(TAG .. string.format(": Tyrant DESTROYED @ 0x%X (lived %.1fs moves=%d)",
            ptr, os.clock()-inst.spawnTime, inst.moveCount))
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

pcall(function()
    RegisterNativeHook("cEm09_move",
        function(emPtr)
            if emPtr == 0 then return emPtr end
            local inst = tyrants.instances[emPtr] or trackTyrant(emPtr)
            inst.moveCount = inst.moveCount + 1
            local packed = tGetState(emPtr)
            if packed ~= inst.lastState then
                if tyrants.logTransitions then
                    Log(TAG .. string.format(": Tyrant %s -> %s [HP=%s dist=%.0f]",
                        stateName(inst.lastState), stateName(packed), tostring(tGetHP(emPtr)),
                        math.sqrt(math.max(0, tGetDistSq(emPtr) or 0))))
                end
                inst.transitions = inst.transitions + 1
                inst.lastState = packed
            end
            return emPtr
        end, nil)
    Log(TAG .. ": Hook — cEm09::move (Tyrant AI monitor)")
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
        Log(string.format("── Tyrant @ 0x%X ── %s HP=%s dist=%.0f anim=%s moves=%d",
            ptr, stateName(tGetState(ptr)), tostring(tGetHP(ptr)),
            math.sqrt(math.max(0, tGetDistSq(ptr) or 0)),
            string.format("0x%X", tGetAnim(ptr) or 0), inst.moveCount))
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
