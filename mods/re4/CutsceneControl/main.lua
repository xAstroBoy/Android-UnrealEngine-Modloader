-- mods/re4/CutsceneControl/main.lua v6.0
-- ═══════════════════════════════════════════════════════════════════════
-- KEEP CHARACTER CONTROL DURING A CUTSCENE.
--
-- v6 changes the whole approach. v5 drove re4.keep_pawn_in_cutscene, which
-- blocked PossessPlayerPawn(3) so the controller kept YOUR pawn. That is a dead
-- end, and IDA says why: GetActivePlayerPawnType @0x6390b6c has 30+ callers —
-- CameraMove, MotionMoveCore, AVR4ParticleManager::DeterminePlayMode,
-- UVR4ActionCameraComponent, InteractionManager, TimeDilationModifier. The pawn
-- type IS the VR layer's global "we are in a cutscene" switch. Block type 3 and
-- the engine's SCE event still runs (NPCs animate, script plays) while the whole
-- VR presentation layer never enters cutscene mode => frozen body, empty scene.
--
-- v6 leaves the pawn swap ALONE (cutscene presents normally: camera, NPCs,
-- particles) and instead undoes only the input freeze, per frame, and only when
-- the scene is not using Leon:
--
--   SceEventStart @0x6190A30 calls KeyStop(0xF12000EFCF1000), which masks the pad
--   and sets pG+0x198 |= 0x80000000 for the whole scene. It also stashes Leon's
--   pre-scene state:  dword_A5A3F38 = *(pPL+276)  — the exact index cPlayer::move
--   dispatches through Pl_func_tbl. So the scene tells us who owns him:
--       *(pPL+276) == saved  -> scene did NOT take him over -> give input back
--       *(pPL+276) != saved  -> scene IS animating him      -> hands off
--
-- So a scripted cutscene still moves Leon normally; a "useless" overview scene
-- hands you the stick.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "CutsceneControl"
local PATCH     = "re4.cutscene_unfreeze_input"   -- v6: the one that actually helps
local DEAD_END  = "re4.keep_pawn_in_cutscene"     -- v5: force OFF, it empties the scene

local state = { enabled = false }
local saved = ModConfig.Load("CutsceneControl")
if saved and saved.enabled ~= nil then state.enabled = saved.enabled end
local function save() pcall(ModConfig.Save, "CutsceneControl", state) end

local function apply()
    if not SetNativePatch then
        Log(TAG .. ": [WARN] SetNativePatch binding missing (old .so?) — rebuild/redeploy the modloader")
        return false
    end
    -- ⚠ v6 used to force DEAD_END (keep_pawn_in_cutscene) OFF here every load.
    -- That is now WRONG and actively fights the shipped defaults: as of
    -- 2026-07-21 the verified working set has keep_pawn ON (together with
    -- unlock_gameloop + objmgr_move_guard + force_vr_control), which is what
    -- gives you movement AND 3D scenes. Silently flipping it off here made the
    -- modloader's own default unreachable. Leave it alone — the Cutscenes page
    -- (CutsceneMenu mod) is the single place that owns these toggles now.
    local ok = SetNativePatch(PATCH, state.enabled)
    Log(TAG .. ": SetNativePatch(" .. PATCH .. ", " .. tostring(state.enabled) .. ") -> " .. tostring(ok)
        .. " | " .. DEAD_END .. " left as-is (see apply() note)")
    return ok
end

apply()   -- sync the native patches to the saved state on load

RegisterCommand("cutscenectrl", function()
    state.enabled = not state.enabled
    save(); apply()
    Notify(TAG, "Walk during unscripted cutscenes " .. (state.enabled and "ON" or "OFF"))
end)

RegisterCommand("cutscenectrl_status", function()
    return TAG .. ": enabled=" .. tostring(state.enabled) .. " (native patch " .. PATCH .. ")"
end)

if SharedAPI and SharedAPI.DebugMenu then
    pcall(function()
        SharedAPI.DebugMenu.RegisterToggle("CutsceneControl", "Walk during cutscenes that aren't using Leon",
            function() return state.enabled end,
            function(v) state.enabled = v; save(); apply() end)
    end)
end

Log(TAG .. ": v6.0 loaded — toggles native patch " .. PATCH
    .. " (per-frame input unfreeze when the scene isn't animating Leon). enabled="
    .. tostring(state.enabled) .. " | cmd: cutscenectrl")
