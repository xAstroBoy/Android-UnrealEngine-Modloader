-- mods/HeadBlocker/main.lua v2.0
-- ═══════════════════════════════════════════════════════════════════════
-- Head Blocker Off — stop the screen fading to black when your head is in
-- geometry.
--
-- v2.0 — FULL REWRITE. v1 destroyed AVR4HeadBlocker actors via
-- NotifyOnNewObject + K2_DestroyActor and never actually worked. Two reasons,
-- both visible in AVR4GamePlayerPawn::UpdateHeadInWallDetection [0x62F7F20]:
--
--   1. THE FADE HAS TWO SOURCES, and killing actors only removes one:
--        GetHeadInWallPenetrationDepth(this, ...)     <- GEOMETRY penetration
--        v6 = InverseLerpClamped(...)
--        for (iter over AVR4HeadBlocker)              <- the blocker ACTORS
--            GetFadeAlpha(blocker, headLoc, ...)
--            if (v6 < alpha) v6 = alpha               <- takes the MAX
--        ...
--        AVR4FadeManager::SetFade(...)                <- the black screen
--      So with every blocker actor destroyed, putting your head in a wall STILL
--      faded you out through the geometry path. The mod could work perfectly
--      and you would see no difference — which is exactly what happened.
--   2. NotifyOnNewObject only fires for NEWLY spawned actors, so any blocker
--      that already existed when the mod loaded (or on re-entering a level) was
--      never touched. It also fought K2_DestroyActor on a native actor and fell
--      back to SetActorHiddenInGame — which does nothing, because a blocker is
--      a math volume, not a mesh.
--
-- v2 neutralises BOTH sources at the root. Each is a leaf float getter, so stub
-- it to `return 0.0f` — 2 instructions, no runtime Lua, no actor hunting, no
-- spawn races, and it covers blockers that already exist:
--
--   [1] AVR4GamePlayerPawn::GetHeadInWallPenetrationDepth [0x62FEE60] -> 0.0
--       The geometry path. Depth 0 => InverseLerpClamped => no fade.
--   [2] AVR4HeadBlocker::GetFadeAlpha [0x632AFBC] -> 0.0
--       The per-blocker vote. The loop takes the MAX, so 0 from every blocker
--       leaves the running alpha untouched.
--
-- Deliberately NOT touched: the BODY/boat-area fade and the scope fade are
-- computed in the same function from different sources (FVR4GamePlayerBoatArea,
-- GetSceneCaptureComponent). Blocking UpdateHeadInWallDetection wholesale would
-- kill those too — and worse, could freeze the fade at whatever value it held,
-- leaving you permanently black. Stubbing the two head getters cannot do that:
-- the function still runs and still drives the fade back down to 0.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "HeadBlocker"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = { enabled = true }
local saved = ModConfig.Load("HeadBlocker")
if saved and saved.enabled ~= nil then state.enabled = saved.enabled end

-- return 0.0f  →  fmov s0, wzr ; ret
local ARM64_FMOV_S0_WZR = 0x1E2703E0
local ARM64_RET         = 0xD65F03C0

local PATCHES = {
    { name = "GetHeadInWallPenetrationDepth (geometry fade)",
      mangled = "_ZN18AVR4GamePlayerPawn29GetHeadInWallPenetrationDepthERK7FVectorS2_",
      fb = 0x062FEE60 },
    { name = "AVR4HeadBlocker::GetFadeAlpha (blocker actors)",
      mangled = "_ZNK15AVR4HeadBlocker12GetFadeAlphaERK7FVectorRK12FMinMaxFloat",
      fb = 0x0632AFBC },
}

local applied = false

local function apply()
    local ok_count = 0
    for _, p in ipairs(PATCHES) do
        pcall(function()
            local sym = Resolve(p.mangled, p.fb)
            if not sym or IsNull(sym) then
                LogWarn(TAG .. ": [WARN] " .. p.name .. " not resolved — that fade source stays live")
                return
            end
            p.addr = sym
            -- Save the original two words ONCE so the toggle can restore them.
            if not p.orig1 then
                p.orig1 = ReadU32(sym)
                p.orig2 = ReadU32(Offset(sym, 4))
            end
            WriteU32(sym, ARM64_FMOV_S0_WZR)
            WriteU32(Offset(sym, 4), ARM64_RET)
            ok_count = ok_count + 1
            Log(TAG .. ": PATCHED " .. p.name .. " → return 0.0 @ " .. ToHex(sym))
        end)
    end
    applied = ok_count > 0
    return ok_count
end

local function restore()
    for _, p in ipairs(PATCHES) do
        if p.addr and p.orig1 then
            pcall(function()
                WriteU32(p.addr, p.orig1)
                WriteU32(Offset(p.addr, 4), p.orig2)
            end)
        end
    end
    applied = false
    Log(TAG .. ": restored — head-in-wall fade is back")
end

if state.enabled then apply() end

-- ═══════════════════════════════════════════════════════════════════════
-- COMMANDS
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("headblocker", function()
    state.enabled = not state.enabled
    if state.enabled then apply() else restore() end
    ModConfig.Save("HeadBlocker", state)
    local s = state.enabled and "OFF (no fade)" or "ON (stock fade)"
    Log(TAG .. ": head blocker " .. s)
    Notify(TAG, "Head blocker " .. s)
    return s
end)

RegisterCommand("headblocker_status", function()
    local info = TAG .. ": enabled=" .. tostring(state.enabled) .. " applied=" .. tostring(applied)
    for _, p in ipairs(PATCHES) do
        info = info .. "\n  " .. p.name .. ": " .. (p.addr and ("@" .. ToHex(p.addr)) or "unresolved")
    end
    Log(info)
    return info
end)

-- ═══════════════════════════════════════════════════════════════════════
-- DEBUG MENU
-- ═══════════════════════════════════════════════════════════════════════
if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("HeadBlocker", "Head Blocker Off",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then apply() else restore() end
            ModConfig.Save("HeadBlocker", state)
        end)
end

Log(TAG .. ": v2.0 loaded — both fade sources stubbed (geometry + blocker actors)"
    .. " | applied=" .. tostring(applied))
