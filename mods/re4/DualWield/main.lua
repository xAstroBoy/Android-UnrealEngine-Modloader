-- mods/DualWield/main.lua v8.0
-- =====================================================================
-- Dual Wield — hold a gun in BOTH hands.
--
-- v8.0 — ALL-NATIVE rewrite (fixes the crash/hang from v6-7).
--   The old version mixed byte-patches with (a) per-call Lua PostHooks on
--   IsPresentOnBody / IsPropGrabbable — HOT functions polled during weapon
--   interaction, so the Lua callback fired constantly and could stall the
--   game thread into an ANR/kill — and (b) reflection Set()/Call() of the
--   VR4GamePlayerSettings STRUCT (SetGamePlayerSettings / pawn:Set), a
--   fragile struct-marshalling path. Neither is needed: every dual-wield
--   gate is a single native check we can flip with a byte-patch. So v8 is
--   PURE byte-patch — no runtime Lua, no reflection — which is both safer
--   and faster. Verified against libUE4.so (UE4.27) in IDA:
--
--   [1] AVR4GamePlayerGun::PrimaryGripGrabbed+0x30
--         ldrb w8,[x0,#0x30]   (EnableDualWielding byte) → mov w8,#1
--       → grabbing a gun never force-holsters the other. Also makes the
--         EnableDualWielding check pass everywhere, so we DON'T need to
--         write the setting.
--   [2] AVR4GamePlayerPropHolster::HolsterGripGrabAttempted+0x13C
--         ldr w8,[x8,#0x334]   (per-hand "occupied" flag) → mov w8,#0
--       → the holster stops refusing a 2nd gun while a hand is full.
--   [3] AVR4GamePlayerPropHolster::execIsPropGrabbable+0x10
--         ldrb w8,[x0,#0x3F6]  (grabbable member byte) → mov w8,#1
--       → holster props always report grabbable (ProcessEvent path only —
--         the FFrame advance above it is preserved).
--   [4] AVR4GamePlayerProp::execIsPresentOnBody+0x2C
--         and w8,w0,#1  (result of the virtual) → mov w8,#1
--       → IsPresentOnBody returns true on the ProcessEvent path only, so a
--         duplicate can be pulled from the holster. The hot C++ virtual is
--         left untouched (patching the impl would force ALL props present).
-- =====================================================================
local TAG = "DualWield"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = { enabled = true }

local saved = ModConfig.Load("DualWield")
if saved and saved.enabled ~= nil then state.enabled = saved.enabled end

local ARM64_MOV_W8_1 = 0x52800028   -- mov w8, #1
local ARM64_MOV_W8_0 = 0x52800008   -- mov w8, #0

-- All four gates, each a single verified instruction. insn_off is the byte
-- offset of the instruction to overwrite from the function start.
local DW_PATCHES = {
    { name = "PrimaryGripGrabbed (no auto-holster)",
      mangled = "_ZN17AVR4GamePlayerGun18PrimaryGripGrabbedEP18AVR4GamePlayerHand",
      fb = 0x062DF8DC, insn_off = 0x30, word = ARM64_MOV_W8_1 },
    { name = "HolsterGripGrabAttempted (allow 2nd gun)",
      mangled = "_ZN25AVR4GamePlayerPropHolster24HolsterGripGrabAttemptedEP18UVR4GamePlayerGripP18AVR4GamePlayerHandR31EVR4GamePlayerGripTryGrabResult",
      fb = 0x0631287C, insn_off = 0x13C, word = ARM64_MOV_W8_0 },
    { name = "IsPropGrabbable exec (holster grabbable)",
      mangled = "_ZN25AVR4GamePlayerPropHolster19execIsPropGrabbableEP7UObjectR6FFramePv",
      fb = 0x064915DC, insn_off = 0x10, word = ARM64_MOV_W8_1 },
    { name = "IsPresentOnBody exec (present on body)",
      mangled = "_ZN18AVR4GamePlayerProp19execIsPresentOnBodyEP7UObjectR6FFramePv",
      fb = 0x0648F9D4, insn_off = 0x2C, word = ARM64_MOV_W8_1 },
    -- [5] UVR4GamePlayerGrip::IsExternallyAllowed+0x24
    --       ldrsw x8,[x0,#0x2F0]  (grab-vote allower count) → mov w8,#0
    --     → the per-grip "external allower" vote is skipped (count forced 0 =
    --       "allowed"). THIS is the gate that actually blocked pulling a 2nd
    --       gun from a holster while already holding one — verified live: with
    --       it, holding a 2-handed + a 1-handed gun works. IsFreeToGrab calls
    --       this inside the hand's grip-selection, so the holster grab-icon
    --       inflates for the 2nd gun even with a weapon in hand.
    { name = "IsExternallyAllowed (grab-vote bypass, enables 2nd-gun grab)",
      mangled = "_ZNK18UVR4GamePlayerGrip19IsExternallyAllowedE11EHandedness",
      fb = 0x062CE5D8, insn_off = 0x24, word = ARM64_MOV_W8_0 },
}

local patchesApplied = false

local function applyDualWieldPatch()
    for _, p in ipairs(DW_PATCHES) do
        pcall(function()
            local sym = Resolve(p.mangled, p.fb)
            if not sym or IsNull(sym) then Log(TAG .. ": [WARN] " .. p.name .. " not resolved"); return end
            p.addr = Offset(sym, p.insn_off)
            if not p.orig then p.orig = ReadU32(p.addr) end
            WriteU32(p.addr, p.word)
            Log(TAG .. ": PATCHED " .. p.name .. " @ " .. ToHex(p.addr))
        end)
    end
    patchesApplied = true
end

local function restoreDualWieldPatch()
    for _, p in ipairs(DW_PATCHES) do
        if p.addr and p.orig then pcall(function() WriteU32(p.addr, p.orig) end) end
    end
    patchesApplied = false
    Log(TAG .. ": dual-wield patches restored")
end

if state.enabled then applyDualWieldPatch() end

-- =====================================================================
-- COMMANDS
-- =====================================================================

RegisterCommand("dualwield", function()
    state.enabled = not state.enabled
    if state.enabled then applyDualWieldPatch() else restoreDualWieldPatch() end
    ModConfig.Save("DualWield", state)
    Log(TAG .. ": " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "Dual Wield ON" or "Dual Wield OFF")
    return state.enabled and "ON" or "OFF"
end)

RegisterCommand("dualwield_status", function()
    local info = TAG .. ": enabled=" .. tostring(state.enabled)
        .. " patchesApplied=" .. tostring(patchesApplied)
    for _, p in ipairs(DW_PATCHES) do
        info = info .. "\n  " .. p.name .. ": " .. (p.addr and ("@" .. ToHex(p.addr)) or "unresolved")
    end
    pcall(function()
        local guns = FindAllOf("VR4GamePlayerGun")
        if guns then info = info .. "\n  live guns=" .. #guns end
    end)
    Log(info)
    return info
end)

-- =====================================================================
-- DEBUG MENU
-- =====================================================================
if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("DualWield", "Dual Wield (Two Guns)",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then applyDualWieldPatch() else restoreDualWieldPatch() end
            ModConfig.Save("DualWield", state)
        end)
end

Log(TAG .. ": v8.0 loaded — 4 native byte-patches (no runtime Lua, no reflection)"
    .. " | applied=" .. tostring(patchesApplied))
