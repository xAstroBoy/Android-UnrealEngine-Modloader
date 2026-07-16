-- mods/NoVignette/main.lua v4.0
-- ═══════════════════════════════════════════════════════════════════════
-- UE4SS-style Vignette Disabler — multi-layer approach:
--   1. RegisterPreHook to BLOCK SetVignetteActive
--   2. RegisterPostHook to override IsVignetteActive/IsAnyVignetteActive
--   3. NotifyOnNewObject to zero vignette properties on spawn
--   4. Native hooks for stripped C++ vignette functions (best-effort)
--
-- v4.0: Restored native hooks (modloader now has DobbyHook crash guard).
--   If any hook fails to install (stripped symbol → symbol not found,
--   or bad address → DobbyHook SIGSEGV caught by modloader), the mod
--   continues loading with UE4SS reflection hooks providing full coverage.
--
-- v3.1: Removed native hooks (SIGSEGV crashes before crash guard)
-- v3.0: Full UE4SS API with native hooks
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "NoVignette"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = {
    vignetteOff = true,
}

local saved = ModConfig.Load("NoVignette")
if saved then
    if saved.vignetteOff ~= nil then state.vignetteOff = saved.vignetteOff end
end

-- ═══════════════════════════════════════════════════════════════════════
-- UE4SS PRE-HOOK — BLOCK SetVignetteActive entirely
-- ═══════════════════════════════════════════════════════════════════════

RegisterPreHook("/Script/Game.VR4Vignette:SetVignetteActive", function(self, func, parms)
    if not state.vignetteOff then return end
    V("PreHook BLOCK SetVignetteActive")
    return "BLOCK"
end)
Log(TAG .. ": RegisterPreHook — VR4Vignette:SetVignetteActive → BLOCK")

-- ═══════════════════════════════════════════════════════════════════════
-- UE4SS POST-HOOKS — Override vignette state queries
-- ═══════════════════════════════════════════════════════════════════════

RegisterPostHook("/Script/Game.VR4Vignette:IsVignetteActive", function(self, func, parms)
    if not state.vignetteOff then return end
    V("PostHook IsVignetteActive -> false")
    local p = CastParms(parms, "VR4Vignette:IsVignetteActive")
    if p then p:SetReturnValue(false) end
end)

RegisterPostHook("/Script/Game.VR4Vignette:IsAnyVignetteActive", function(self, func, parms)
    if not state.vignetteOff then return end
    V("PostHook IsAnyVignetteActive -> false")
    local p = CastParms(parms, "VR4Vignette:IsAnyVignetteActive")
    if p then p:SetReturnValue(false) end
end)

Log(TAG .. ": RegisterPostHook — IsVignetteActive, IsAnyVignetteActive → false")

-- ═══════════════════════════════════════════════════════════════════════
-- UE4SS VIGNETTE SPAWN TRACKING — Nullify on creation
-- ═══════════════════════════════════════════════════════════════════════

local vignetteCount = 0

NotifyOnNewObject("VR4Vignette", function(obj)
    V("NotifyOnNewObject VR4Vignette fired, obj=%s", tostring(obj))
    if not state.vignetteOff then return end
    if not obj or not obj:IsValid() then return end
    vignetteCount = vignetteCount + 1

    -- Zero out vignette properties via UE4SS reflection
    pcall(function() obj.VignetteScale = 0.0 end)
    pcall(function() obj.PawnTimeScale = 1.0 end)
    pcall(function() obj.ColorSaturation = 1.0 end)

    Log(TAG .. ": VR4Vignette spawned #" .. vignetteCount .. " — properties zeroed")
end)
Log(TAG .. ": NotifyOnNewObject — VR4Vignette (zero on spawn)")

-- ═══════════════════════════════════════════════════════════════════════
-- NATIVE HOOKS — Best-effort C++ hooks on stripped vignette functions
-- These are game-specific symbols that may not be in the export table.
-- If symbol resolution fails → modloader logs warning, no crash.
-- If DobbyHook() crashes on bad address → modloader sigsetjmp guard
-- catches it, logs error, hook not installed, mod keeps loading.
-- The UE4SS reflection hooks above provide full vignette disabling
-- regardless of whether these native hooks succeed.
-- ═══════════════════════════════════════════════════════════════════════

-- ── BYTE PATCHES, not Lua hooks ─────────────────────────────────────────
--
-- These three used to be RegisterNativeHook Lua callbacks. IsVignetteActive and
-- IsAnyVignetteActive are polled EVERY FRAME by the render/HUD path, so those
-- callbacks ran Lua on the game thread every frame and raced the shared
-- lua_State against the mod loop and bridge thread. The corruption never showed
-- up here — it surfaced as SIGSEGV in FMallocBinned2 during GC, SIGBUS with
-- pc=lr=0x1, and a fault inside atan2f (identical corrupt registers x2=1
-- x3=0xaaa across those tombstones), all blaming innocent engine code. Same
-- class as the ScoreControl / DualFire / Tyrant hot-hook crashes.
--
-- A hook was never needed: the decision is STATIC. "Vignette off" is always the
-- same answer, so decide it ONCE by rewriting the function, and the game runs at
-- full speed with no callback, no lua_State, and nothing to race. This is the
-- same thing HeadBlocker does.
--   IsVignetteActive / IsAnyVignetteActive : MOV W0,#0 ; RET   -> always false
--   SetVignetteActive                      : RET               -> do nothing
-- Originals are saved so the toggle can restore them exactly.
local ARM64_MOV_W0_0 = 0x52800000   -- MOV W0, #0
local ARM64_RET      = 0xD65F03C0   -- RET

local NATIVE_PATCHES = {
    { sym = "SetVignetteActive",   insn = { ARM64_RET },                   note = "do nothing" },
    { sym = "IsVignetteActive",    insn = { ARM64_MOV_W0_0, ARM64_RET },   note = "always false" },
    { sym = "IsAnyVignetteActive", insn = { ARM64_MOV_W0_0, ARM64_RET },   note = "always false" },
}

local nativeHookCount = 0
local applied = false

local function applyNativePatches(on)
    if on == applied then return end
    for _, p in ipairs(NATIVE_PATCHES) do
        if p.addr then
            pcall(function()
                if on then
                    for i, w in ipairs(p.insn) do WriteU32(Offset(p.addr, (i - 1) * 4), w) end
                else
                    for i, w in ipairs(p.orig) do WriteU32(Offset(p.addr, (i - 1) * 4), w) end
                end
            end)
        end
    end
    applied = on
    Log(TAG .. ": native vignette patches " .. (on and "APPLIED" or "REVERTED"))
end

for _, p in ipairs(NATIVE_PATCHES) do
    local okr = pcall(function() p.addr = Resolve(p.sym) end)
    if okr and p.addr and not IsNull(p.addr) then
        p.orig = {}
        pcall(function()
            for i = 1, #p.insn do p.orig[i] = ReadU32(Offset(p.addr, (i - 1) * 4)) end
        end)
        if #p.orig == #p.insn then
            nativeHookCount = nativeHookCount + 1
            Log(TAG .. ": byte-patch target " .. p.sym .. " @ " .. ToHex(p.addr) .. " (" .. p.note .. ")")
        else
            p.addr = nil
            Log(TAG .. ": " .. p.sym .. " — couldn't read original bytes, skipped")
        end
    else
        p.addr = nil
        Log(TAG .. ": " .. p.sym .. " skipped (symbol not found)")
    end
end

applyNativePatches(state.vignetteOff and true or false)

-- NOTE: v4.0 also tried to hook "ActivateVignette", "UpdateVignette" and
-- "ApplyVignetteEffect". Verified against the full libUE4.so .dynsym: none of
-- those functions exist on AVR4Vignette (or anywhere). The real per-frame
-- driver is AVR4Vignette::Tick(float), but blocking SetVignetteActive above
-- (native + the UFunction PreHook) already prevents the vignette from ever
-- activating, so those dead registrations were removed. The 3 native hooks
-- kept above (SetVignetteActive / IsVignetteActive / IsAnyVignetteActive) all
-- resolve to real AVR4Vignette methods.

Log(TAG .. ": " .. nativeHookCount .. "/3 native hooks installed (UE4SS hooks always active)")

-- ═══════════════════════════════════════════════════════════════════════
-- COMMANDS
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("vignette", function()
    state.vignetteOff = not state.vignetteOff
    applyNativePatches(state.vignetteOff and true or false)
    V("toggle: vignetteOff=%s", tostring(state.vignetteOff))
    ModConfig.Save("NoVignette", state)
    Log(TAG .. ": Vignette " .. (state.vignetteOff and "DISABLED" or "ENABLED"))
    Notify(TAG, "Vignette " .. (state.vignetteOff and "OFF" or "ON"))
end)

RegisterCommand("vignette_status", function()
    local info = TAG .. ": vignetteOff=" .. tostring(state.vignetteOff)
        .. " vignetteSpawns=" .. vignetteCount
    -- Inspect live vignette instances via UE4SS
    local vigs = FindAllOf("VR4Vignette")
    if vigs then
        info = info .. " | Active instances: " .. #vigs
        for i, v in ipairs(vigs) do
            if v and v:IsValid() then
                pcall(function()
                    local scale = v.VignetteScale
                    local sat = v.ColorSaturation
                    if scale then info = info .. " [scale=" .. tostring(scale) .. " sat=" .. tostring(sat) .. "]" end
                end)
            end
        end
    end
    Log(info)
end)

if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("VignetteOff", "Vignette Off",
        function() return state.vignetteOff end,
        function(v)
            state.vignetteOff = v
            applyNativePatches(v and true or false)
            ModConfig.Save("NoVignette", state)
        end)
end

Log(TAG .. ": v4.1 loaded — UE4SS hooks + 3 real native hooks (dead Activate/Update/Apply removed)")
