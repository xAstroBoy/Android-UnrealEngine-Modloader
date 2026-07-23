-- mods/re4/CutsceneMenu/main.lua v1.0
-- ═══════════════════════════════════════════════════════════════════════
-- CUTSCENES sub-page for the in-game debug menu.
--
-- Every cutscene behaviour lives in the modloader's native patch registry
-- (re4.cutscene_*, re4.force_vr_control, re4.keep_pawn_in_cutscene, ...). Until
-- now the ONLY way to flip them was over the PC bridge, which means you cannot
-- change anything with the headset on. This puts all of them on one page.
--
-- State is read LIVE from the registry via GetNativePatch, not cached — so the
-- page always shows what the modloader is actually doing, including the compiled
-- defaults and anything the bridge changed behind our back.
--
-- ⚠ The defaults below are the WORKING SET, verified live 2026-07-21:
--     unlock_gameloop + objmgr_move_guard + force_vr_control + keep_pawn  = walk
--     normal_move_state = OFF  (it dispatches Pl_func_move_tbl[0], the STAND-IDLE
--                               handler -> pins you in place. Do not default it on.)
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "CutsceneMenu"

-- id, label, one-line help shown in the log when toggled
local ITEMS = {
    { "re4.cutscene_unlock_gameloop",      "Unlock game loop",     "THE blocker: lets gameMainLoop run during a scene" },
    { "re4.objmgr_move_guard",             "ObjMgr null guard",    "REQUIRED by unlock: stops the PC=0 crash in cObjMgr::move" },
    { "re4.force_vr_control",              "Force VR control",     "movement gate: ArmVrHasControl forced true in scenes" },
    { "re4.keep_pawn_in_cutscene",         "Keep my pawn",         "block the hand-off to the theatre pawn (stays 3D)" },
    { "re4.cutscene_force_models_visible", "Force models visible", "make suspended scene actors render" },
    { "re4.cutscene_no_fade",              "No black fade",        "kill the fade into/out of scenes" },
    { "re4.cutscene_unfreeze_input",       "Unfreeze input",       "KeyStop masks nothing during a scene" },
    { "re4.cutscene_hide_dupes",           "Hide duplicate Leon",  "WARNING: hides YOUR Leon - char vanishes in door-kick scenes" },
    { "re4.cutscene_normal_move_state",    "Force normal state",   "WARNING: PINS YOU (stand-idle handler). Off unless testing." },
    { "re4.cutscene_smart_move_state",     "Collision try v2",     "restore Leon's SAVED pre-scene state so his collided move path runs" },
    { "re4.cutscene_ride_along",           "Ride-along camera",    "anchor the rig behind Leon each frame" },
    { "re4.drive_player_in_cutscene",      "Drive player",         "call cPlayer::move from the cutscene pawn tick" },
    { "re4.drive_entities_in_cutscene",    "Drive NPCs",           "tick every scene entity so NPCs animate" },
    { "re4.cutscene_fire_edge",            "Fix dry fire",         "rebuild the trigger edge so guns fire in scenes" },
    { "re4.cutscene_verbose",              "Verbose logging",      "log every cutscene patch hit (noisy)" },
}

local function get(id)
    if not GetNativePatch then return nil end
    local ok, v = pcall(GetNativePatch, id)
    if ok then return v end
    return nil
end

local function label_for(item)
    local v = get(item[1])
    local mark
    if v == nil then mark = "n/a"          -- not registered in this build
    elseif v      then mark = "ON"
    else               mark = "OFF" end
    return string.format("%-22s [%s]", item[2], mark)
end

local function toggle(item)
    local cur = get(item[1])
    if cur == nil then
        Notify(TAG, item[2] .. ": not available in this build")
        return
    end
    local want = not cur
    local ok = SetNativePatch(item[1], want)
    Log(string.format("%s: %s -> %s (%s) ok=%s", TAG, item[1], tostring(want), item[3], tostring(ok)))
    Notify(TAG, item[2] .. ": " .. (want and "ON" or "OFF"))
end

-- ── register the sub-page ───────────────────────────────────────────────
-- Guarded: DebugMenuAPI loads after us, so we retry — but registering twice
-- would put "Cutscenes" on the Mods page twice. Latch on first success.
local registered = false
local function register()
    if registered then return true end
    local api = SharedAPI and SharedAPI.DebugMenu
    if not api or not api.RegisterSubMenu then
        Log(TAG .. ": [WARN] SharedAPI.DebugMenu.RegisterSubMenu missing - is DebugMenuAPI loaded?")
        return false
    end
    -- ⚠ onEnter must call NavigateTo. RegisterSubMenu only puts an entry on the
    -- root Mods page whose callback is onEnter; it does NOT open a page by itself.
    -- api.AddItem is only valid INSIDE a populate() running under NavigateTo, so
    -- calling AddItem straight from onEnter silently does nothing and the entry
    -- looks dead ("is not entering"). populate() re-runs on every render/Refresh,
    -- which is what makes the [ON]/[OFF] labels update after a toggle.
    local function populate()
        for _, item in ipairs(ITEMS) do
            api.AddItem(label_for(item), function()
                toggle(item)
                if api.Refresh then pcall(api.Refresh) end   -- redraw so [ON]/[OFF] updates
            end)
        end
        -- one-tap restore of the verified-good configuration
        api.AddItem("-- Restore working set --", function()
            local WANT = {
                ["re4.cutscene_unlock_gameloop"]      = true,
                ["re4.objmgr_move_guard"]             = true,
                ["re4.force_vr_control"]              = true,
                ["re4.keep_pawn_in_cutscene"]         = true,
                ["re4.cutscene_force_models_visible"] = true,
                ["re4.cutscene_no_fade"]              = true,
                ["re4.cutscene_unfreeze_input"]       = true,
                ["re4.cutscene_hide_dupes"]           = false,
                ["re4.cutscene_normal_move_state"]    = false,
                ["re4.cutscene_ride_along"]           = false,
                ["re4.drive_player_in_cutscene"]      = false,
                ["re4.drive_entities_in_cutscene"]    = false,
                ["re4.cutscene_verbose"]              = false,
            }
            for id, v in pairs(WANT) do pcall(SetNativePatch, id, v) end
            Notify(TAG, "Working set restored")
            if api.Refresh then pcall(api.Refresh) end
        end)
    end

    api.RegisterSubMenu(TAG, "Cutscenes", function()
        api.NavigateTo({ name = "Cutscenes", populate = populate })
    end)
    registered = true
    Log(TAG .. ": registered Cutscenes sub-page (" .. #ITEMS .. " toggles)")
    return true
end

if not register() then
    -- DebugMenuAPI may load after us; retry once on the next tick.
    if LoopAsync then
        local tries = 0
        LoopAsync(1000, function()
            tries = tries + 1
            if register() or tries > 15 then return true end
            return false
        end)
    end
end

-- bridge fallback so the page is reachable from PC too
RegisterBridgeCommand("cutscene_menu", function()
    local out = { "cutscene toggles:" }
    for _, item in ipairs(ITEMS) do
        out[#out + 1] = "  " .. label_for(item) .. "  " .. item[1]
    end
    return table.concat(out, "\n")
end)
