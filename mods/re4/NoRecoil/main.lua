-- mods/NoRecoil/main.lua v2.1
-- ═══════════════════════════════════════════════════════════════════════
-- No Recoil / No Spread — eliminates weapon recoil and bullet spread.
--
-- v2.1: Removed native IsRecoiling hook — log showed repeated SIGSEGV
--   safe-call recovery in that hook's original path during gameplay.
--   Keep UpdateRecoil/GetShotSpreadMM/Filter00SetAddSpread only.
--
-- v2.0: Restored native hooks (modloader now has DobbyHook crash guard).
--   If any hook fails to install (stripped symbol, bad address), the
--   modloader catches the crash via sigsetjmp and continues loading.
--
-- v1.1: REMOVED native hooks due to SIGSEGV (pre-crash-guard era)
-- v1.0: Original with native hooks
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "NoRecoil"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = { enabled = true }

local saved = ModConfig.Load("NoRecoil")
if saved then
    if saved.enabled ~= nil then state.enabled = saved.enabled end
end

-- ═══════════════════════════════════════════════════════════════════════
-- NATIVE HOOKS — Dobby hooks on C++ recoil/spread functions
-- These are stripped game-specific symbols. If symbol resolution fails,
-- the modloader logs a warning and skips. If DobbyHook() crashes on a
-- bad address, the modloader's sigsetjmp crash guard catches it and
-- returns 0 (hook not installed). Either way, mod keeps loading.
-- ═══════════════════════════════════════════════════════════════════════

-- ═══════════════════════════════════════════════════════════════════════
-- BYTE PATCHES (v3.0) — replace the Lua-callback hooks
-- ═══════════════════════════════════════════════════════════════════════
-- v2.x used RegisterNativeHook with Lua callbacks on UpdateRecoil /
-- GetShotSpreadMM — both are PER-FRAME during firing. A Lua callback on a hot
-- function is (a) unreliable ("didn't work on all weapons") and (b) the exact
-- luaV_execute cross-thread crash risk. Verified in IDA that UpdateRecoil and
-- GetShotSpreadMM exist ONLY on the base AVR4GamePlayerGun (no per-weapon
-- overrides), so patching the base covers EVERY weapon. Pure byte-patches: no
-- Lua on the hot path, works for all guns.
local ARM64_RET       = 0xD65F03C0   -- ret
local ARM64_FMOV_S0_0 = 0x1E2703E0   -- fmov s0, wzr  (return 0.0f)
local patchCount = 0

-- {mangled, fallbackOffset, name, {word0[, word1]}}
local RECOIL_PATCHES = {
    {"_ZN17AVR4GamePlayerGun12UpdateRecoilEf",       0x062D9EB0, "UpdateRecoil → ret (no recoil)",        {ARM64_RET}},
    {"_ZNK17AVR4GamePlayerGun15GetShotSpreadMMEv",   0x062DD8DC, "GetShotSpreadMM → 0.0 (no spread)",     {ARM64_FMOV_S0_0, ARM64_RET}},
    {"_Z20Filter00SetAddSpreadhihhhhhfffj",          0x05F3B724, "Filter00SetAddSpread → ret",            {ARM64_RET}},
}
local recoilOrig = {}

local function applyRecoilPatches()
    for _, p in ipairs(RECOIL_PATCHES) do
        pcall(function()
            local addr = Resolve(p[1], p[2])
            if not addr or IsNull(addr) then Log(TAG .. ": [WARN] " .. p[3] .. " not resolved"); return end
            local words = p[4]
            recoilOrig[p[1]] = recoilOrig[p[1]] or { ReadU32(addr), ReadU32(Offset(addr, 4)) }
            for i, w in ipairs(words) do WriteU32(Offset(addr, (i - 1) * 4), w) end
            patchCount = patchCount + 1
            p.addr = addr
            Log(TAG .. ": PATCHED " .. p[3] .. " @ " .. ToHex(addr))
        end)
    end
end

local function restoreRecoilPatches()
    for _, p in ipairs(RECOIL_PATCHES) do
        local o = recoilOrig[p[1]]
        if p.addr and o then pcall(function() WriteU32(p.addr, o[1]); WriteU32(Offset(p.addr, 4), o[2]) end) end
    end
end

if state.enabled then applyRecoilPatches() end
Log(TAG .. ": " .. patchCount .. "/3 byte patches applied")

-- ═══════════════════════════════════════════════════════════════════════
-- COMMAND
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("norecoil", function()
    state.enabled = not state.enabled
    V("toggle: enabled=%s", tostring(state.enabled))
    if state.enabled then applyRecoilPatches() else restoreRecoilPatches() end
    ModConfig.Save("NoRecoil", state)
    Log(TAG .. ": " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "ON" or "OFF")
end)

-- ═══════════════════════════════════════════════════════════════════════
-- DEBUG MENU
-- ═══════════════════════════════════════════════════════════════════════

if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("NoRecoil", "No Recoil",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then applyRecoilPatches() else restoreRecoilPatches() end
            ModConfig.Save("NoRecoil", state)
        end)
end

Log(TAG .. ": v3.0 loaded — byte-patches (UpdateRecoil/GetShotSpreadMM/Filter00SetAddSpread), all weapons")
