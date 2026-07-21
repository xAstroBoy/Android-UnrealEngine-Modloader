-- mods/ObjectPool/main.lua v1.2
-- ═══════════════════════════════════════════════════════════════════════
-- OBJECT POOL — the real "only N mines / rockets then it dry-fires" limit,
-- plus the NULL-deref crash the rocket launcher hits when it runs out.
--
-- Found by reading the tombstone, then IDA. Not inferred, not guessed.
--
-- ── THE LIMIT ───────────────────────────────────────────────────────────
-- cObjMgr is the shared pool for every dynamic world object: rockets, mines,
-- dropped items, effects. gameRoomInit @0x5F43268 sizes it INLINE (there is
-- no cObjMgr::arrayAlloc — unlike cEmMgr, which is why the enemy-pool hook in
-- re4_native_hooks.cpp never touched this):
--
--   5f43550  BL   ConsGetRoomValue(1)   ; the room's authored object count
--   5f43558  BL   SmdGetObjNum()        ; the room's SMD object count
--   5f43560  ADD  W8,  W22, W0          ; roomObjs + smdObjs
--   5f43564  ADD  W22, W8,  #0x28       ; ★ + 40  <- ALL the dynamic headroom
--   5f43590  MUL  W1,  W9,  W22         ; bytes = stride * count
--   5f43594  BLR  X8+0x10               ; memAlloc
--   5f4359c  STR  W22, [ObjMgr+0x10]    ; count
--
-- #0x28 == 40. That immediate IS the limit — "I see 40-ish mines on the floor"
-- is that constant, observed. stride is 1272 (cObjMgr ctor writes ObjMgr+0x10
-- = 0x4F800000000, so +0x14 = 0x4F8), so the stock dynamic headroom is a mere
-- 40 * 1272 = ~50 KB.
--
-- Raising the immediate scales the ALLOCATION and the COUNT together (the MUL
-- feeds memAlloc from the same register that is stored as the count), so it is
-- self-consistent — there is no second field to keep in sync.
--
-- ── THE CRASH ───────────────────────────────────────────────────────────
-- Two consumers, and they disagree about failure.
--
--   SetObj00 @0x5F8AEB4 (mines, items, the generic spawn) is written CORRECTLY:
--   three separate `return 0;` on exhaustion. Caller gets NULL, nothing spawns.
--   That is your dry fire, and it is harmless.
--
--   cObjLauncher::loadRocket @0x5FB6B94 is NOT:
--       5fb6be0  TBNZ W8,#0x1F, loc_5FB6C5C   ; no free slot
--       5fb6c24  CBZ  W0,       loc_5FB6C5C   ; create failed
--       5fb6c5c  MOV  X20, XZR                ; v4 = NULL ... and FALLS THROUGH
--       5fb6c64  STR  X20, [X19,#0x478]       ; store NULL
--       5fb6c68  BL   cObjRocket::init        ; init(NULL)
--       5fb6c90  BL   cModel::setParent       ; setParent(NULL, ...)
--       5fb6c94  LDR  X0, [X19,#0x478]        ; X0 = NULL
--       5fb6ca0  LDR  X8, [X0]                ; NULL vtable load
--       5fb6ca4  LDR  X1, [X8,#0x28]
--       5fb6cac  BR   X1                      ; ★ tail call -> pc = 0
--   It never null-checks the failed allocation — the RE4 house style already
--   documented for getRoomSavePtr/getPartsPtr/cEmWrap::getPtr.
--
-- WHY THE TOMBSTONE SAID pc=0 AND HAD NO loadRocket FRAME:
--   BR (not BLR) is a TAIL CALL, so lr still pointed at moveFire+0x6C and no
--   frame was pushed. And the global instruction-skip crash guard SKIPPED both
--   faulting LDRs, leaving X1 = 0, so `BR X1` jumped to address zero — which is
--   not a faulting instruction and therefore unrecoverable. Instruction-skip
--   turned a clean, attributable null deref into a jump to nowhere.
--
-- WHY THE cObjRocket::init CRASH GUARD MADE IT WORSE (removed from Rapidfire):
--   Guarding init only aborted ONE call in the middle of the wreck. Execution
--   resumed at setParent(NULL) and walked into the NULL tail call anyway. The
--   guard was downstream of the actual decision. Fix the branch, not the fallout.
--
-- ── THE PATCHES ─────────────────────────────────────────────────────────
--   [1] loadRocket+0xC8  MOV X20, XZR  ->  B loc_5FB6BAC
--       0xAA1F03F4       ->  0x17FFFFD4   (b #-0xB0)
--       0x5FB6BAC is the function's OWN early-return epilogue — the path taken
--       when a rocket is already loaded (CBZ X8 at +0x14). It restores exactly
--       the registers this prologue saved and RETs, so it is the canonical
--       "return having done nothing" exit. Skipping the STR is correct: we only
--       reach here when [X19+0x478] was ALREADY 0 (that is the entry condition),
--       so the field needs no write. Pool exhaustion becomes a dry fire, which
--       is precisely what SetObj00 already does for mines.
--
--   [2] gameRoomInit+0x2FC  ADD W22, W8, #0x28  ->  ADD W22, W8, #N
--       0x1100A116  ->  0x11000000 | (N<<10) | (8<<5) | 22
--       Takes effect on the NEXT room load (it is the sizing code).
--
-- COST, STATED HONESTLY: gameRoomInit NULLs ObjMgr+8 at 0x5F4353C BEFORE the
-- CBZ/memFree at 0x5F43568, so the free is unreachable BY DESIGN and the pool
-- leaks every room load — the same deliberate leak as cEmMgr (old pointers
-- still reference the buffer; see the EnemySpawner FIX_POOL_LEAK comment).
-- So this costs (N - 40) * 1272 bytes per room transition. At N=512 that is
-- ~600 KB per load. That is why N is capped, not unbounded: if memAlloc ever
-- returned NULL the pool pointer would be NULL with a nonzero count and the
-- free-slot scan would deref it. 512 is ~12.8x the stock mine count.
--
-- CHANGELOG
--   v1.0  loadRocket null-bail + configurable object-pool headroom.
--   v1.1  512 -> 256 default; added the coupled effect-pool multiplier (x4) after
--         a 512-slot session died in EspCommonTrans with a garbage esp parent.
--   v1.2  REVERTED to stock sizes. v1.1 crashed in the SAME place with effects
--         at x4, ~60s after launch — so it was never exhaustion. The pool bump
--         is now opt-in; the null-bail (the actual crash fix) stays on.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "ObjectPool"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

-- ★ DEFAULT IS STOCK. Raising this is OPT-IN and is known to destabilise the
--   renderer — see "WHY THE POOL BUMP IS OFF" below before changing it.
local STOCK_SLOTS   = 40        -- 0x28, the shipped immediate
local DEFAULT_SLOTS = STOCK_SLOTS
local MIN_SLOTS     = 40        -- never go BELOW stock
local MAX_SLOTS     = 2048      -- 2048 * 1272 = ~2.6 MB; imm12 caps at 4095

-- ── THE EFFECT POOL IS COUPLED — RAISE IT TOO ───────────────────────────
-- v1.0 shipped 512 object slots and the very next crash was NOT the launcher,
-- it was the EFFECT system:
--     fault 0x065ea6e0
--     #00 MTXConcat+132
--     #01 EspCommonTrans+2600     ; LDR X8,[X27,#0x40] -> ADD X0,X8,#0x18
--     #02 ExecOt -> Render
-- i.e. a live cEsp with a garbage PARENT pointer. First EspCommonTrans crash
-- in 20 tombstones, and it appeared the session my 512 landed.
--
-- The structural reason (verified, EspArrayAlloc @0x5EF6948):
--     result = mem_alloc(464 * a1, ...)      ; a1 = ConsGetRoomValue(2)
-- The effect pool is sized EXACTLY to the room's authored effect count, with
-- ZERO headroom — no `+0x28` slack like cObjMgr gets. Objects spawn effects
-- (mine idle glow, rocket trail, explosions), so raising the object pool 12.8x
-- while leaving effects at the authored count moves the wall instead of
-- removing it. This is the same "find the amplifier" lesson as the enemy pool.
--
-- HONEST STATUS: the coupling and the zero headroom are FACTS read out of the
-- binary. That this specific crash was caused by the 512 is a strong inference,
-- NOT proof — Randomizer was also very active that session and has its own
-- documented missing-data crash family. Raising the effect pool is safe either
-- way: EspArrayAlloc Mem_free()s the old pool and reallocs (no leak), and the
-- one register scaled feeds BOTH the allocation and the stored count.
--
--   EspArrayAlloc+0x20  MOV W19, W0  ->  LSL W19, W0, #n
--     0x2A0003F3        ->  UBFM-alias, see encodeLslW19()
--   5ef6990  UMULL X20, W19, W8   ; alloc bytes = W19 * 464
--   5ef69b8  STR   W19, [X21,#0x10] ; stored count = W19   <- same register
-- Default is x4, and the object default dropped 512 -> 256 to stay inside what
-- the effect budget can plausibly follow. Dial with `objpool` / `esppool`.
-- ── WHY THE POOL BUMP IS OFF BY DEFAULT (v1.2) ──────────────────────────
-- It was tried twice and crashed BOTH times, in the same place:
--     v1.0  objects 512, effects x1  -> EspCommonTrans+2600 / MTXConcat
--     v1.1  objects 256, effects x4  -> EspCommonTrans+2600 / MTXConcat  (identical)
-- Raising the effect pool did NOT help, which kills the "effects ran out"
-- theory. And the v1.1 crash came ~60 SECONDS after launch, not after sustained
-- firing — so it is not exhaustion of anything. The only constant across both
-- is that the object count was not 40.
--
-- The engine reason: a room's content budget is GLOBAL and everything
-- downstream is sized to it, none of it null-checked.
--     * effect pool  = mem_alloc(464 * ConsGetRoomValue(2))  — EXACTLY the
--       authored count, zero headroom
--     * ordering table = g_OtWork[2*type], fixed-capacity, walked by ExecOt,
--       which BLR's each entry's +8 as a draw callback
-- Push more objects through and something downstream overflows and hands
-- EspCommonTrans a cEsp whose parent (+0x40) is garbage. That is the crash.
--
-- THIS IS THE SAME LESSON AS THE ENEMY POOL, AND IT IS ALREADY WRITTEN DOWN:
-- POOL_MULT had to go back to 1 because x4 caused a tombstone storm across five
-- unrelated subsystems. cObjMgr has the same architecture. "Find the amplifier"
-- applies to amplifiers WE add, too.
--
-- So the shipped default is stock 40 / x1, and the ONLY thing this mod does out
-- of the box is the loadRocket null-bail — which cannot cause this, because it
-- alters behaviour solely on the exhaustion path (dry fire instead of a NULL
-- vtable tail call). If you want to experiment, step up SLOWLY: `objpool 64`,
-- play a while, then 96. Do not jump to 256+ again.
local DEFAULT_ESP_SHIFT = 0     -- 0 = stock x1
local MAX_ESP_SHIFT     = 3     -- x8 ceiling; 464*count*8 gets expensive

local CFG_VER = 2   -- bump to force-discard the v1.0/v1.1 sizes that crashed

local state = { ver = CFG_VER, enabled = false, slots = DEFAULT_SLOTS, espShift = DEFAULT_ESP_SHIFT }

local saved = ModConfig.Load("ObjectPool")
-- MIGRATION: v1.0 saved slots=512 and v1.1 saved slots=256/espShift=2, and BOTH
-- crashed. Honouring an old config would silently re-arm the exact setting this
-- version exists to back out of, so anything older is discarded outright.
if saved and saved.ver == CFG_VER then
    if saved.enabled ~= nil then state.enabled = saved.enabled end
    if type(saved.slots) == "number" then state.slots = saved.slots end
    if type(saved.espShift) == "number" then state.espShift = saved.espShift end
elseif saved then
    Log(TAG .. ": discarding pre-v1.2 config (slots=" .. tostring(saved.slots)
        .. ") — those sizes destabilised the renderer; back to stock")
end

local function clampSlots(n)
    n = math.floor(tonumber(n) or DEFAULT_SLOTS)
    if n < MIN_SLOTS then n = MIN_SLOTS end
    if n > MAX_SLOTS then n = MAX_SLOTS end
    return n
end
state.slots = clampSlots(state.slots)

local function clampShift(n)
    n = math.floor(tonumber(n) or DEFAULT_ESP_SHIFT)
    if n < 0 then n = 0 end                    -- 0 = stock (x1)
    if n > MAX_ESP_SHIFT then n = MAX_ESP_SHIFT end
    return n
end
state.espShift = clampShift(state.espShift)

-- ToHex() is the POINTER formatter and throws on a plain number; instruction
-- words are numbers. (Same trap that broke NoFlashBlind's first load.)
local function hexword(n) return string.format("0x%08X", n or 0) end

-- ═══════════════════════════════════════════════════════════════════════
-- PATCH SITES
-- ═══════════════════════════════════════════════════════════════════════

local LOADROCKET_SYM = "_ZN12cObjLauncher10loadRocketEv"
local LOADROCKET_RVA = 0x05FB6B94
local BAIL_OFF       = 0xC8              -- -> 0x5FB6C5C
local BAIL_ORIG      = 0xAA1F03F4        -- mov x20, xzr
local BAIL_PATCH     = 0x17FFFFD4        -- b #-0xB0  -> 0x5FB6BAC (epilogue)

local ROOMINIT_SYM   = "_Z12gameRoomInitv"
local ROOMINIT_RVA   = 0x05F43268
local POOL_OFF       = 0x2FC             -- -> 0x5F43564
local POOL_ORIG      = 0x1100A116        -- add w22, w8, #0x28

-- ADD Wd, Wn, #imm12  ->  0x11000000 | imm12<<10 | Rn<<5 | Rd   (Rn=8, Rd=22)
local function encodeAddImm(imm)
    return 0x11000000 | ((imm & 0xFFF) << 10) | (8 << 5) | 22
end

-- Resolve a mid-function site and verify the word is one we reverse-engineered,
-- so a shifted binary is a no-op instead of silent corruption.
local function resolveSite(sym, rva, off, accept)
    local ok, base = pcall(Resolve, sym, rva)
    if not ok or not base or IsNull(base) then
        LogWarn(TAG .. ": " .. sym .. " not resolved — that patch is skipped")
        return nil
    end
    local addr = Offset(base, off)
    local ok2, word = pcall(ReadU32, addr)
    if not ok2 or not word then
        LogWarn(TAG .. ": could not read " .. sym .. "+" .. hexword(off) .. " — skipped")
        return nil
    end
    if not accept(word) then
        LogWarn(TAG .. ": UNEXPECTED word at " .. sym .. "+" .. string.format("0x%X", off)
                .. " (" .. hexword(word) .. ") — binary changed, refusing to patch")
        return nil
    end
    return addr, word
end

-- ── [1] loadRocket null-bail ────────────────────────────────────────────
local bailAddr, bailApplied = nil, false

local function applyBailPatch()
    if bailApplied then return true end
    local addr = resolveSite(LOADROCKET_SYM, LOADROCKET_RVA, BAIL_OFF,
        function(w) return w == BAIL_ORIG or w == BAIL_PATCH end)
    if not addr then return false end
    bailAddr = addr
    if not pcall(WriteU32, addr, BAIL_PATCH) then
        LogWarn(TAG .. ": WriteU32 failed @ " .. ToHex(addr)); return false
    end
    bailApplied = true
    -- Expose to PCBridge's native-patch registry for live per-patch toggling.
    if RegisterNativePatch then
        pcall(RegisterNativePatch, "re4.objectpool.loadrocket_bail",
            TAG .. ": loadRocket null-bail (rocket pool-exhaustion crash fix)",
            addr, BAIL_ORIG, BAIL_PATCH, true)
    end
    Log(TAG .. ": PATCHED loadRocket+0xC8 @ " .. ToHex(addr)
        .. " — pool exhaustion now dry-fires instead of NULL-tail-calling")
    return true
end

local function restoreBailPatch()
    if not bailAddr or not bailApplied then return end
    if pcall(WriteU32, bailAddr, BAIL_ORIG) then
        bailApplied = false
        if RegisterNativePatch then
            pcall(RegisterNativePatch, "re4.objectpool.loadrocket_bail",
                TAG .. ": loadRocket null-bail (rocket pool-exhaustion crash fix)",
                bailAddr, BAIL_ORIG, BAIL_PATCH, false)
        end
        Log(TAG .. ": RESTORED loadRocket+0xC8 (rocket launcher can crash again)")
    end
end

-- ── [2] object-pool headroom ────────────────────────────────────────────
local poolAddr, poolApplied = nil, false

local function applyPoolPatch()
    local want = state.enabled and state.slots or STOCK_SLOTS
    local addr = poolAddr
    if not addr then
        -- Accept the stock word or ANY re-encoding of it we could have written,
        -- so a reload/toggle does not trip the guard on our own patch.
        addr = resolveSite(ROOMINIT_SYM, ROOMINIT_RVA, POOL_OFF, function(w)
            return (w & 0xFFC003FF) == (POOL_ORIG & 0xFFC003FF)
        end)
        if not addr then return false end
        poolAddr = addr
    end
    local word = encodeAddImm(want)
    if not pcall(WriteU32, addr, word) then
        LogWarn(TAG .. ": WriteU32 failed @ " .. ToHex(addr)); return false
    end
    poolApplied = (want ~= STOCK_SLOTS)
    Log(TAG .. ": object pool headroom " .. STOCK_SLOTS .. " -> " .. want
        .. " slots (" .. hexword(word) .. " @ " .. ToHex(addr) .. ") — takes effect on next room load"
        .. string.format(" [+%.0f KB/room]", (want - STOCK_SLOTS) * 1272 / 1024))
    return true
end

-- ── [3] effect-pool multiplier ──────────────────────────────────────────
local ESPALLOC_SYM = "_Z13EspArrayAllocj"
local ESPALLOC_RVA = 0x05EF6948
local ESP_OFF      = 0x20                -- -> 0x5EF6968
local ESP_ORIG     = 0x2A0003F3          -- mov w19, w0   (orr w19, wzr, w0)

-- LSL Wd,Wn,#s is an alias of UBFM Wd,Wn,#(-s mod 32),#(31-s).
-- Here Rd=19 (the count register), Rn=0 (the incoming arg).
local function encodeLslW19(shift)
    if shift <= 0 then return ESP_ORIG end
    local immr = (32 - shift) % 32
    local imms = 31 - shift
    return 0x53000000 | (immr << 16) | (imms << 10) | (0 << 5) | 19
end

local espAddr = nil

local function applyEspPatch()
    local want = state.enabled and state.espShift or 0
    if not espAddr then
        -- Accept the stock MOV or any LSL we could have written (same Rd/Rn).
        espAddr = resolveSite(ESPALLOC_SYM, ESPALLOC_RVA, ESP_OFF, function(w)
            if w == ESP_ORIG then return true end
            return (w & 0xFFC003FF) == (0x53000000 | 19)   -- UBFM Wd=19, Rn=0
        end)
        if not espAddr then return false end
    end
    local word = encodeLslW19(want)
    if not pcall(WriteU32, espAddr, word) then
        LogWarn(TAG .. ": WriteU32 failed @ " .. ToHex(espAddr)); return false
    end
    Log(TAG .. ": effect pool x" .. (1 << want) .. " (" .. hexword(word)
        .. " @ " .. ToHex(espAddr) .. ") — takes effect on next room load")
    return true
end

-- The bail patch is a pure crash fix and costs nothing, so it goes on
-- unconditionally — independent of the `enabled` toggle, which only governs
-- the pool SIZE. Turning the size off should not re-arm a null deref.
applyBailPatch()
applyPoolPatch()
applyEspPatch()

-- ═══════════════════════════════════════════════════════════════════════
-- COMMANDS
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("objpool", function(arg)
    local n = tonumber(arg)
    if n then
        state.slots = clampSlots(n)
        state.enabled = true
        applyPoolPatch()
        ModConfig.Save("ObjectPool", state)
        Notify(TAG, "pool " .. state.slots .. " (reload room)")
    else
        Log(TAG .. ": pool headroom = " .. (state.enabled and state.slots or STOCK_SLOTS)
            .. " (stock " .. STOCK_SLOTS .. ", max " .. MAX_SLOTS .. ")"
            .. " | bail patch " .. (bailApplied and "ON" or "OFF"))
        Log(TAG .. ": usage — objpool <" .. MIN_SLOTS .. ".." .. MAX_SLOTS .. ">")
    end
end)

RegisterCommand("esppool", function(arg)
    local n = tonumber(arg)
    if n then
        -- Accept either a shift or a multiplier: 4 -> x4, 2 -> x2, 0/1 -> stock.
        local shift = n
        if n >= 2 then
            shift = 0
            local v = 1
            while v < n and shift < MAX_ESP_SHIFT do v = v * 2; shift = shift + 1 end
        elseif n <= 1 then
            shift = 0
        end
        state.espShift = clampShift(shift)
        applyEspPatch()
        ModConfig.Save("ObjectPool", state)
        Notify(TAG, "effects x" .. (1 << state.espShift) .. " (reload room)")
    else
        Log(TAG .. ": effect pool = x" .. (1 << state.espShift)
            .. " (stock x1, max x" .. (1 << MAX_ESP_SHIFT) .. ")")
        Log(TAG .. ": usage — esppool <1|2|4|8>")
    end
end)

RegisterCommand("objpool_bail", function()
    if bailApplied then restoreBailPatch() else applyBailPatch() end
    Notify(TAG, "loadRocket bail " .. (bailApplied and "ON" or "OFF"))
end)

-- ═══════════════════════════════════════════════════════════════════════
-- DEBUG MENU
-- ═══════════════════════════════════════════════════════════════════════

if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("ObjectPool", "Big Object Pool (mines/rockets)",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            applyPoolPatch()
            ModConfig.Save("ObjectPool", state)
        end)
end

Log(TAG .. ": v1.2 loaded — headroom "
    .. (state.enabled and state.slots or STOCK_SLOTS) .. "/" .. STOCK_SLOTS
    .. ", loadRocket null-bail " .. (bailApplied and "ACTIVE" or "FAILED"))
