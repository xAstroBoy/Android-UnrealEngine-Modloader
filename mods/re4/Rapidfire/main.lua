-- mods/Rapidfire/main.lua v19.0
-- ═══════════════════════════════════════════════════════════════════════
-- Rapid Fire — ZERO fire-rate cooldown (every trigger PULL fires instantly).
-- NOT auto-fire: holding the trigger does nothing extra; you can just pull as
-- fast as you physically can and every pull fires with no rate limit.
--
-- v19.0 — THE real fix (verified live in-game), replacing all the v17/v18
--   patches (IsReadyToFire / UpdateFireTimer / IsFullyAutomatic) which did
--   NOTHING: AVR4GamePlayerGun::TryFire reads the fire-rate cooldown timer
--   DIRECTLY, so patching the helper predicates never touched the real gate.
--
--   Verified in IDA (libUE4.so): AVR4GamePlayerGun::TryFire (0x062DC490) begins:
--       LDR  S0, [X0,#0xC58]     ; S0 = fire-rate timer (this+3160)
--       FCMP S0, #0.0
--       B.HI loc_62DC6F0         ; @0x062DC4C0 — timer>0 → bail (the cooldown)
--   NOP that B.HI (+0x30 into TryFire) → the cooldown branch is never taken →
--   the gun fires on every TryFire. TryFire is EDGE-triggered (UpdateTrigger
--   only raises the fire delegate when the trigger STATE changes), so this is
--   0-cooldown-per-pull, not full-auto. One base TryFire serves every gun
--   (handgun, rifle, shotgun, magnum, TMP, mine-thrower…) so this single patch
--   covers all weapons.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "Rapidfire"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = { enabled = true }
local saved = ModConfig.Load("Rapidfire")
if saved and saved.enabled ~= nil then state.enabled = saved.enabled end

local ARM64_NOP = 0xD503201F

-- TryFire's cooldown branch: B.HI loc_62DC6F0 at TryFire+0x30.
local PATCH = {
    name    = "TryFire cooldown branch (0 cooldown, all guns)",
    mangled = "_ZN17AVR4GamePlayerGun7TryFireEv",
    fb      = 0x062DC490,
    insn_off = 0x30,
    word    = ARM64_NOP,
}

local function apply()
    pcall(function()
        local sym = Resolve(PATCH.mangled, PATCH.fb)
        if not sym or IsNull(sym) then Log(TAG .. ": [WARN] TryFire not resolved"); return end
        PATCH.addr = Offset(sym, PATCH.insn_off)
        if not PATCH.orig then PATCH.orig = ReadU32(PATCH.addr) end
        WriteU32(PATCH.addr, PATCH.word)
        Log(TAG .. ": PATCHED " .. PATCH.name .. " @ " .. ToHex(PATCH.addr)
            .. " (was " .. string.format("%08X", PATCH.orig or 0) .. " → NOP)")
    end)
end

local function restore()
    if PATCH.addr and PATCH.orig then pcall(function() WriteU32(PATCH.addr, PATCH.orig) end) end
    Log(TAG .. ": cooldown restored")
end

if state.enabled then apply() end

RegisterCommand("rapidfire", function()
    state.enabled = not state.enabled
    if state.enabled then apply() else restore() end
    ModConfig.Save("Rapidfire", state)
    Log(TAG .. ": " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "Rapid Fire ON (0 cooldown)" or "Rapid Fire OFF")
    return state.enabled and "ON" or "OFF"
end)

RegisterCommand("rapidfire_status", function()
    local info = TAG .. ": enabled=" .. tostring(state.enabled)
        .. " patch=" .. (PATCH.addr and ("@" .. ToHex(PATCH.addr)) or "unresolved")
    Log(info); return info
end)

if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("Rapidfire", "Rapid Fire (0 cooldown)",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then apply() else restore() end
            ModConfig.Save("Rapidfire", state)
        end)
end

Log(TAG .. ": v19.0 loaded — TryFire cooldown NOP (0 cooldown, all guns, no auto-fire)"
    .. " | applied=" .. tostring(PATCH.addr ~= nil))
