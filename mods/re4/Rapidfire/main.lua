-- mods/Rapidfire/main.lua v20.0
-- ═══════════════════════════════════════════════════════════════════════
-- TWO INDEPENDENT TOGGLES, both patching one instruction each:
--
--   [1] Rapid Fire  — ZERO fire-rate cooldown. Every trigger PULL fires
--       instantly; you can pull as fast as you physically can. NOT auto-fire.
--   [2] Auto-Fire   — HOLD the trigger and the weapon keeps shooting, at the
--       weapon's own fire rate. OFF by default.
--
-- Turn BOTH on and you get hold-to-fire with no rate limit at all (very fast —
-- that combination is intentional, not a bug).
--
-- ── [1] Rapid Fire (v19.0, verified live) ──────────────────────────────
--   AVR4GamePlayerGun::TryFire (0x062DC490) begins:
--       LDR  S0, [X0,#0xC58]   ; S0 = fire-rate cooldown timer (this+3160)
--       FCMP S0, #0.0
--       B.HI loc_62DC6F0       ; @+0x30 — timer>0 → bail
--   NOP that B.HI → the cooldown branch is never taken. Earlier attempts that
--   patched IsReadyToFire / UpdateFireTimer / IsFullyAutomatic did NOTHING,
--   because TryFire reads the timer DIRECTLY and never consults them.
--
-- ── [2] Auto-Fire — OPTIONAL ADD-ON (v20.2, IDA-verified) ──────────────
--   Hold the trigger and the weapon keeps shooting, instead of one shot per
--   pull. Completely independent of [1]; [1] is unchanged and still does its
--   own thing.
--
--   TWO WRONG ATTEMPTS FIRST — recorded so nobody repeats them:
--     a) NOP the edge check in UpdateTrigger+0xE8. Applied cleanly, did
--        NOTHING. UpdateTrigger only raises the OnTriggerPulled *Blueprint
--        delegate*; that is not the shot path.
--     b) Redirect AVR4GamePlayerGun::WasTriggerJustPressed to
--        IsTriggerPressed. Also wrong layer: AVR4GamePlayerGun::TryFire is
--        NOT the shot either — it checks a cooldown then does
--        cItemMgr::ArmSearchWeaponNo -> cItemMgr::arm -> WeaponChange() ->
--        PlMotionReset(), i.e. weapon ARM/EQUIP. Nothing there fires a bullet.
--     Also a dead end: AVR4GamePlayerGun::IsFullyAutomatic (vtable +0x7A8;
--     Gun returns 0, MachineGun/TommyGun return 1). That is a UE-side flag the
--     native firing code never consults — "marking a weapon automatic" is not
--     how this works.
--
--   THE ACTUAL FIRING SYSTEM (native bio4 layer):
--       VR trigger -> AVR4Bio4PlayerPawn::UpdateBio4Wep()
--                  -> key mask at global [0xa3c28e0], bit 7 (0x80) = FIRE
--                        +0x18 = KEY_ON  (held)
--                        +0x20 = KEY_TRG (edge)
--                  -> joyFireOn / joyFireTrg / joyFireOff
--                  -> RE4 native weapon code
--   joyFireOn  (0x600A890): ldrb w8,[x8,#0x18]  ; HELD  -> true while held
--   joyFireTrg (0x600A978): ldr  x8,[x8,#0x20]  ; EDGE  -> true on press only
--   Both then `tbz w8,#7` and apply the same secondary gates (pPL+0xA54, the
--   pG state flags). joyFireTrg IS the semi-auto limiter, natively, for every
--   weapon that uses it.
--
--   So the engine already supports continuous fire — point joyFireTrg at the
--   HELD mask and "just pressed" becomes "is held":
--       0x600a990  ldr x8,[x8,#0x20]  ->  ldr x8,[x8,#0x18]
--                  0xF9401108         ->  0xF9400D08          (imm12 4 -> 3)
--   One immediate, one instruction, all weapons, every safety gate intact.
--
--   CAVEAT: anything else keyed on fire-EDGE sees "held" too (some QTE /
--   prompt inputs may repeat). That is why this is opt-in and OFF by default.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "Rapidfire"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

-- autoFire defaults OFF: hold-to-fire is a deliberate cheat, not the baseline.
local state = { enabled = true, autoFire = false }
local saved = ModConfig.Load("Rapidfire")
if saved then
    if saved.enabled  ~= nil then state.enabled  = saved.enabled  end
    if saved.autoFire ~= nil then state.autoFire = saved.autoFire end
end

local ARM64_NOP = 0xD503201F

local PATCHES = {
    cooldown = {
        name     = "TryFire cooldown branch (0 cooldown, all guns)",
        mangled  = "_ZN17AVR4GamePlayerGun7TryFireEv",
        fb       = 0x062DC490,
        insn_off = 0x30,
        word     = ARM64_NOP,
        expect   = nil,        -- v19 never recorded one; accept whatever is there
    },
    autofire = {
        -- joyFireTrg: read the HELD key mask instead of the EDGE one.
        --   0x600a990   ldr x8,[x8,#0x20]   0xF9401108   ; +0x20 = KEY_TRG (edge)
        --           ->  ldr x8,[x8,#0x18]   0xF9400D08   ; +0x18 = KEY_ON  (held)
        -- Only the load offset changes (imm12 4 -> 3); everything else in the
        -- function, including all its safety gates, is untouched. That one load
        -- feeds BOTH branches of joyFireTrg, so a single word covers all paths.
        name     = "joyFireTrg edge -> held (native fire gate)",
        mangled  = "_Z10joyFireTrgv",
        fb       = 0x0600A978,
        insn_off = 0x18,
        word     = 0xF9400D08,
        expect   = 0xF9401108, -- ldr x8,[x8,#0x20] — refuse to patch anything else
    },
    -- Auto-fire needs BOTH gates open. Patching only the native one is not
    -- enough, and that is exactly what "handcannon still shoots once" showed:
    --   * AVR4GamePlayerGun::TryFire is what SETS the fire bit
    --         xmmword_A562B48 |= 0x80        (the KEY_ON/held mask)
    --   * but PreBio4Tick only calls TryFire when WasTriggerJustPressed() is
    --     true — the EDGE. So the UE layer pumps that bit for ONE frame per
    --     pull, and joyFireTrg then faithfully reads a bit that is already gone.
    -- So open the upstream gate too: make WasTriggerJustPressed report "the
    -- trigger is down NOW" by tail-calling IsTriggerPressed (same signature
    -- this -> bool; it still returns false when paused / flourishing / debug
    -- controls are active, so those guards survive).
    --     0x62daad8  sub sp,sp,#0x50  ->  b #0x62dc198
    --                0xD10143FF       ->  0x140005B0
    -- The branch is PC-relative but BOTH functions are in libUE4, so the delta
    -- (0x62DC198 - 0x62DAAD8 = 0x16C0, imm26 = 0x5B0) is constant at any load
    -- address. v20.1 tried to "recompute it at runtime", the helper failed, and
    -- the patch silently never applied — hence the [WARN] in the log. Constant.
    trigger_edge = {
        name     = "WasTriggerJustPressed -> IsTriggerPressed (UE fire gate)",
        mangled  = "_ZNK17AVR4GamePlayerGun21WasTriggerJustPressedEv",
        fb       = 0x062DAAD8,
        insn_off = 0x00,
        word     = 0x140005B0,
        expect   = 0xD10143FF, -- sub sp,sp,#0x50
    },
}

-- NOTE: this mod deliberately has NO toggle debounce.
-- Auto-fire used to switch itself off, and the cause was two real bugs in
-- DebugMenuAPI, both now fixed there rather than worked around here:
--   1. its confirm handler ran even with the menu CLOSED, so every gameplay
--      trigger pull dispatched a confirm on the last-selected item;
--   2. its "safety valve" re-armed on HOLD DURATION and then re-dispatched, so
--      a held button repeated the action every 2s.
-- If a toggle ever flickers again, fix it at the menu layer — do not add a
-- debounce here, it only hides the input bug from one mod.

-- Guarded patcher: verifies the instruction is the one we reverse-engineered
-- before overwriting it, so a shifted binary is a no-op instead of corruption.
local function applyPatch(p)
    local ok = false
    pcall(function()
        local sym = Resolve(p.mangled, p.fb)
        if not sym or IsNull(sym) then
            Log(TAG .. ": [WARN] " .. p.mangled .. " not resolved — " .. p.name .. " skipped")
            return
        end
        p.addr = Offset(sym, p.insn_off)
        local cur = ReadU32(p.addr)
        if p.expect and cur ~= p.expect and cur ~= p.word then
            Log(TAG .. ": [WARN] unexpected word " .. string.format("0x%08X", cur or 0)
                .. " at " .. ToHex(p.addr) .. " (expected " .. string.format("0x%08X", p.expect)
                .. ") — refusing to patch " .. p.name)
            p.addr = nil
            return
        end
        if not p.orig then p.orig = cur end
        WriteU32(p.addr, p.word)
        ok = true
        Log(TAG .. ": PATCHED " .. p.name .. " @ " .. ToHex(p.addr)
            .. " (was " .. string.format("0x%08X", p.orig or 0) .. " -> NOP)")
    end)
    return ok
end

local function restorePatch(p)
    if p.addr and p.orig then
        pcall(function() WriteU32(p.addr, p.orig) end)
        Log(TAG .. ": restored " .. p.name)
    end
end

local function applyCooldown()  applyPatch(PATCHES.cooldown)   end
local function restoreCooldown() restorePatch(PATCHES.cooldown) end
-- ── ROCKET-LAUNCHER CRASH: FIXED IN THE ObjectPool MOD, NOT HERE ────────
-- Holding the trigger on the rocket launcher CRASHED the game:
--     fault addr 0x0,  #00 pc 0x0 <unknown>
--     #01 cObjLauncher::moveFire+104        (no loadRocket frame — TAIL CALL)
-- v20.6 tried to fix that from here with InstallCrashGuard on cObjRocket::init.
-- IT DID NOT WORK, and the reason is worth keeping: the guard fired correctly
-- (the recovery line is in the tombstone's stack memory), but init was never
-- the problem. cObjLauncher::loadRocket @0x5FB6B94 does not null-check a failed
-- pool allocation — it sets X20=0 and FALLS THROUGH into init(NULL),
-- setParent(NULL), then `LDR X8,[X0]` / `BR X1` on a NULL vtable. Guarding init
-- aborted one call in the middle of that and let execution continue straight
-- into the NULL tail call. The guard was downstream of the decision.
--
-- Auto-fire only EXPOSED it: holding the trigger drains the 40-slot cObjMgr
-- headroom (gameRoomInit+0x2FC `ADD W22,W8,#0x28`), and exhaustion is what
-- takes the unchecked branch. The ObjectPool mod patches both the missing
-- null-bail and that immediate. Do not re-add a crash guard here.

-- Auto-fire = BOTH gates. Apply upstream (UE) first, then the native one, and
-- report each so a half-applied state is visible in the log instead of silently
-- behaving like semi-auto.
local function applyAutoFire()
    local a = applyPatch(PATCHES.trigger_edge)
    local b = applyPatch(PATCHES.autofire)
    if not (a and b) then
        Log(TAG .. ": [WARN] auto-fire only partially applied (UE gate="
            .. tostring(a) .. " native gate=" .. tostring(b)
            .. ") — it will still behave as semi-auto")
    end
    return a and b
end
local function restoreAutoFire()
    restorePatch(PATCHES.autofire)
    restorePatch(PATCHES.trigger_edge)
end

if state.enabled  then applyCooldown() end
if state.autoFire then applyAutoFire() end

-- ── Commands ────────────────────────────────────────────────────────────
RegisterCommand("rapidfire", function()
    state.enabled = not state.enabled
    if state.enabled then applyCooldown() else restoreCooldown() end
    ModConfig.Save("Rapidfire", state)
    Log(TAG .. ": rapid fire " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "Rapid Fire ON (0 cooldown)" or "Rapid Fire OFF")
    return state.enabled and "ON" or "OFF"
end)

RegisterCommand("autofire", function()
    state.autoFire = not state.autoFire
    if state.autoFire then applyAutoFire() else restoreAutoFire() end
    ModConfig.Save("Rapidfire", state)
    local msg = "auto-fire " .. (state.autoFire and "ON (hold the trigger)" or "OFF")
    Log(TAG .. ": " .. msg)
    Notify(TAG, state.autoFire and "Auto-Fire ON — hold trigger" or "Auto-Fire OFF")
    return msg
end)

RegisterCommand("rapidfire_status", function()
    local info = TAG .. ": rapidFire=" .. tostring(state.enabled)
        .. " (" .. (PATCHES.cooldown.addr and ToHex(PATCHES.cooldown.addr) or "unresolved") .. ")"
        .. " | autoFire=" .. tostring(state.autoFire)
        .. " (" .. (PATCHES.autofire.addr and ToHex(PATCHES.autofire.addr) or "unresolved") .. ")"
    Log(info); return info
end)

-- ── Debug menu ──────────────────────────────────────────────────────────
if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("Rapidfire", "Rapid Fire (0 cooldown)",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then applyCooldown() else restoreCooldown() end
            ModConfig.Save("Rapidfire", state)
        end)

    -- No debounce here by design: DebugMenuAPI now ignores confirms while the
    -- menu is closed, and no longer re-dispatches a held button.
    SharedAPI.DebugMenu.RegisterToggle("Rapidfire", "Auto-Fire (hold trigger)",
        function() return state.autoFire end,
        function(v)
            state.autoFire = v
            if v then applyAutoFire() else restoreAutoFire() end
            ModConfig.Save("Rapidfire", state)
        end)
end

Log(TAG .. ": v20.7 loaded — rapidFire=" .. tostring(state.enabled)
    .. " autoFire=" .. tostring(state.autoFire)
    .. " | toggles: 'rapidfire' (0 cooldown) + 'autofire' (hold trigger), both in the debug menu")
