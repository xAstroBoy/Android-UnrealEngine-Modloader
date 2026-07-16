-- mods/Patches/main.lua v9.0
-- ═══════════════════════════════════════════════════════════════════════
-- GameInstance Config — Debug mode + quick start on init
--
-- v9.0 — REWRITE after IDA verification of libUE4.so (nothing stripped).
--   The v8.x hook was DEAD for two reasons, both confirmed in the binary:
--     1. WRONG MODULE PATH. ReceiveInit is a BlueprintImplementableEvent on
--        the ENGINE class UGameInstance (symbol
--        Z_Construct_UFunction_UGameInstance_ReceiveInit), so its UObject
--        path is "/Script/Engine.GameInstance", NOT "/Script/Game.GameInstance".
--        The old path never bound → the hook never fired.
--     2. WRONG CALL ABI. UVR4Utils::SetDebugMode(int)/SetQuickStart(int) are
--        STATIC UFunctionLibrary functions: they take the int in W0 and
--        ignore `this` (disasm: `mov w1,w0` then X0 is overwritten with a
--        CVar-name pointer). The old call `CallNative(sym,"vpi",obj,1)` put
--        the GameInstance pointer in W0 (garbage debugMode) and the 1 in W1
--        (ignored). Correct call is `CallNative(sym,"vi",1)`.
--
--   New approach: apply config from a NATIVE post-hook on
--   UVR4GameInstance::Init (fires once, early, reliably) plus delayed
--   retries as a belt-and-suspenders. SetDebugMode/SetQuickStart are global
--   CVar setters, safe to call any time; the GameInstance properties are set
--   best-effort via reflection (they are Blueprint vars, so pcall-guarded).
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "Patches"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local function isDefaultObject(obj)
    if not obj then return false end
    local ok, name = pcall(function() return obj:GetName() end)
    return ok and type(name) == "string" and name:sub(1, 9) == "Default__"
end

local function findFirstNonDefault(className)
    local first = nil
    pcall(function() first = FindFirstOf(className) end)
    if first and first:IsValid() and not isDefaultObject(first) then return first end
    local all = nil
    pcall(function() all = FindAllOf(className) end)
    if all then
        for _, obj in ipairs(all) do
            if obj and obj:IsValid() and not isDefaultObject(obj) then return obj end
        end
    end
    return nil
end

local state = {
    enabled    = true,
    debugMode  = true,    -- SetDebugMode(1) — enables the debug menu (double-tap Y)
    quickStart = true,    -- SetQuickStart(1) — skips the intro straight into gameplay.
                          -- ON by default (that's the whole point). Turn OFF with
                          -- `patches_quickstart` if you want the intro to play.
}

local saved = ModConfig.Load("Patches")
if saved then
    if saved.enabled    ~= nil then state.enabled    = saved.enabled    end
    if saved.debugMode  ~= nil then state.debugMode  = saved.debugMode  end
    if saved.quickStart ~= nil then state.quickStart = saved.quickStart end
end

-- ── Resolve the static UVR4Utils CVar setters (names resolve; offsets are
--    verified-current fallbacks). SetDebugMode/SetQuickStart take (int) in W0.
local sym_SetDebugMode  = Resolve("SetDebugMode",  0x063DF4F4)
local sym_SetQuickStart = Resolve("SetQuickStart", 0x063DF654)

local applied = false

local function applyConfig(reason)
    if not state.enabled then return end
    -- Global CVar setters — correct ABI is (void)(int) with the value in W0.
    if sym_SetDebugMode then
        pcall(function() CallNative(sym_SetDebugMode, "vi", state.debugMode and 1 or 0) end)
    end
    if sym_SetQuickStart and state.quickStart then
        pcall(function() CallNative(sym_SetQuickStart, "vi", 1) end)
    end
    -- Best-effort GameInstance properties (Blueprint vars — may be absent).
    local gi = findFirstNonDefault("VR4GameInstance")
    if gi then
        pcall(function() gi:Set("NewWeaponWheel", true) end)
        pcall(function() gi:Set("ShouldLoadTheatreBox", false) end)
    end
    if not applied then
        applied = true
        Log(TAG .. ": GameInstance configured — debug on, quick start, theatre box OFF ("
            .. tostring(reason) .. ")")
    else
        V("applyConfig re-applied (%s)", tostring(reason))
    end
end

-- ═══════════════════════════════════════════════════════════════════════
-- PRIMARY TRIGGER — native post-hook on UVR4GameInstance::Init
-- Confirmed in IDA: UVR4GameInstance::Init(this) runs once at startup and
-- calls UGameInstance::Init(this). Cold function (not per-frame), so a Lua
-- callback here is safe. This is the reliable replacement for the dead
-- ReceiveInit ProcessEvent hook.
-- ═══════════════════════════════════════════════════════════════════════
local sym_GIInit = Resolve("_ZN16UVR4GameInstance4InitEv", 0x062BB3E0)
if sym_GIInit then
    pcall(function()
        RegisterNativeHookAt(sym_GIInit, "VR4GameInstance_Init", nil,
            function(retval)
                pcall(function() applyConfig("Init post-hook") end)
                return retval
            end)
        Log(TAG .. ": Native post-hook — UVR4GameInstance::Init @ " .. ToHex(sym_GIInit))
    end)
else
    Log(TAG .. ": [WARN] UVR4GameInstance::Init not resolved — relying on delayed retries")
end

-- ═══════════════════════════════════════════════════════════════════════
-- BELT-AND-SUSPENDERS — delayed retries in case the game/menu is already
-- past Init when the mod loads (CVar setters are safe to call any time).
-- ═══════════════════════════════════════════════════════════════════════
for _, d in ipairs({0, 500, 1500, 4000}) do
    ExecuteWithDelay(d, function() pcall(function() applyConfig("delay " .. d .. "ms") end) end)
end

-- ═══════════════════════════════════════════════════════════════════════
-- COMMANDS
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("patches", function()
    V("patches command — toggling enabled from %s", tostring(state.enabled))
    state.enabled = not state.enabled
    ModConfig.Save("Patches", state)
    if state.enabled then applied = false; applyConfig("command toggle") end
    Log(TAG .. ": " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "ON" or "OFF")
end)

RegisterCommand("patches_quickstart", function()
    state.quickStart = not state.quickStart
    ModConfig.Save("Patches", state)
    applied = false; applyConfig("quickstart toggle")
    Log(TAG .. ": quickStart=" .. tostring(state.quickStart))
    Notify(TAG, "Quick start " .. (state.quickStart and "ON (skips intro)" or "OFF (intro plays)"))
end)

-- ═══════════════════════════════════════════════════════════════════════
-- DEBUG MENU
-- ═══════════════════════════════════════════════════════════════════════

if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("Patches", "GameInstance Config",
        function() return state.enabled end,
        function(v) state.enabled = v; ModConfig.Save("Patches", state) end)
end

Log(TAG .. ": v9.1 loaded — native Init hook + correct ABI"
    .. " | debugMode=" .. tostring(state.debugMode) .. " (debug menu on)"
    .. " quickStart=" .. tostring(state.quickStart) .. " (intro plays unless enabled)"
    .. " | initHook=" .. tostring(sym_GIInit ~= nil))
