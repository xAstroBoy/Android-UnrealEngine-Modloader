-- mods/Rapidfire/main.lua v20.7
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
--        IsTriggerPressed. Also wrong layer on its own: AVR4GamePlayerGun::
--        TryFire is NOT the shot either — it checks a cooldown then does
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
--
--   Auto-fire needs BOTH gates open (patching only the native one is not
--   enough — "handcannon still shoots once" proved it):
--     * native: joyFireTrg reads the HELD mask instead of the EDGE one
--         0x600a990  ldr x8,[x8,#0x20]  ->  ldr x8,[x8,#0x18]
--                    0xF9401108         ->  0xF9400D08          (imm12 4 -> 3)
--     * UE upstream: PreBio4Tick only calls TryFire when WasTriggerJustPressed()
--       is true (the EDGE), so the UE layer only pumps the fire bit for ONE
--       frame per pull. Make WasTriggerJustPressed report "trigger is down NOW"
--       by tail-calling IsTriggerPressed:
--         0x62daad8  sub sp,sp,#0x50  ->  b #0x62dc198
--                    0xD10143FF       ->  0x140005B0
--       Both functions are in libUE4, so the delta (0x16C0, imm26 0x5B0) is
--       constant at any load address — hardcoded, not recomputed at runtime.
--
--   CAVEAT: anything else keyed on fire-EDGE sees "held" too (some QTE / prompt
--   inputs may repeat). That is why this is opt-in and OFF by default.
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
        id       = "re4.rapidfire.cooldown",
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
        id       = "re4.rapidfire.autofire",
        name     = "joyFireTrg edge -> held (native fire gate)",
        mangled  = "_Z10joyFireTrgv",
        fb       = 0x0600A978,
        insn_off = 0x18,
        word     = 0xF9400D08,
        expect   = 0xF9401108, -- ldr x8,[x8,#0x20] — refuse to patch anything else
    },
    trigger_edge = {
        id       = "re4.rapidfire.trigger_edge",
        -- WasTriggerJustPressed -> tail-call IsTriggerPressed (the UE fire gate).
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
-- DebugMenuAPI, both fixed there rather than worked around here:
--   1. its confirm handler ran even with the menu CLOSED, so every gameplay
--      trigger pull dispatched a confirm on the last-selected item;
--   2. its "safety valve" re-armed on HOLD DURATION and then re-dispatched, so
--      a held button repeated the action every 2s.
-- If a toggle ever flickers again, fix it at the menu layer — do not add a
-- debounce here, it only hides the input bug from one mod.

-- ── ROCKET-LAUNCHER CRASH: FIXED IN THE ObjectPool MOD, NOT HERE ────────
-- Holding the trigger on the rocket launcher used to crash. That is NOT a
-- Rapidfire bug and is no longer patched here: cObjLauncher::loadRocket falls
-- through a failed pool allocation into a NULL vtable tail call. The ObjectPool
-- mod patches the missing null-bail (and the 40-slot object cap). A crash guard
-- on cObjRocket::init was tried here and REMOVED — it sat downstream of the
-- decision and let execution walk into the NULL tail call anyway. Do not re-add.

-- Guarded patcher: verifies the instruction is the one we reverse-engineered
-- before overwriting it, so a shifted binary is a no-op instead of corruption.
local function applyPatch(p)
    local ok = false
    pcall(function()
        local sym = Resolve(p.mangled, p.fb)
        if not sym or IsNull(sym) then
            LogWarn(TAG .. ": " .. p.name .. " unresolved — skipped")
            return
        end
        local addr = Offset(sym, p.insn_off)
        local cur  = ReadU32(addr)
        if p.expect and cur ~= p.expect and cur ~= p.word then
            LogWarn(TAG .. ": " .. p.name .. " UNEXPECTED word 0x"
                .. string.format("%08X", cur or 0) .. " (expected 0x"
                .. string.format("%08X", p.expect) .. ") — refusing to patch")
            return
        end
        p.addr = addr
        p.orig = p.orig or cur
        WriteU32(addr, p.word)
        ok = true
        -- Expose to PCBridge's native-patch registry so it can be toggled live
        -- (per-patch bisection). Guarded: older modloader .so lacks the binding.
        if p.id and RegisterNativePatch then
            pcall(RegisterNativePatch, p.id, TAG .. ": " .. p.name, addr, p.orig, p.word, true)
        end
        Log(TAG .. ": PATCHED " .. p.name .. " @ " .. ToHex(addr)
            .. " (was 0x" .. string.format("%08X", p.orig) .. ")")
    end)
    return ok
end

local function restorePatch(p)
    if p.addr and p.orig then
        pcall(function() WriteU32(p.addr, p.orig) end)
        if p.id and RegisterNativePatch then
            pcall(RegisterNativePatch, p.id, TAG .. ": " .. p.name, p.addr, p.orig, p.word, false)
        end
        Log(TAG .. ": restored " .. p.name)
    end
end

local function applyCooldown()  return applyPatch(PATCHES.cooldown)  end
local function restoreCooldown()       restorePatch(PATCHES.cooldown) end

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

-- ═══════════════════════════════════════════════════════════════════════
-- APPLY ON LOAD
-- ═══════════════════════════════════════════════════════════════════════
if state.enabled  then applyCooldown() end
if state.autoFire then applyAutoFire() end

-- ═══════════════════════════════════════════════════════════════════════
-- COMMANDS
-- ═══════════════════════════════════════════════════════════════════════
RegisterCommand("rapidfire", function()
    state.enabled = not state.enabled
    if state.enabled then applyCooldown() else restoreCooldown() end
    ModConfig.Save("Rapidfire", state)
    Log(TAG .. ": Rapid Fire " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, "Rapid Fire " .. (state.enabled and "ON" or "OFF"))
end)

RegisterCommand("autofire", function()
    state.autoFire = not state.autoFire
    if state.autoFire then applyAutoFire() else restoreAutoFire() end
    ModConfig.Save("Rapidfire", state)
    Log(TAG .. ": Auto-Fire " .. (state.autoFire and "ON" or "OFF"))
    Notify(TAG, "Auto-Fire " .. (state.autoFire and "ON (hold trigger)" or "OFF"))
end)

-- ═══════════════════════════════════════════════════════════════════════
-- DEBUG MENU
-- ═══════════════════════════════════════════════════════════════════════
if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("Rapidfire", "Rapid Fire (0 cooldown)",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then applyCooldown() else restoreCooldown() end
            ModConfig.Save("Rapidfire", state)
        end)

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
