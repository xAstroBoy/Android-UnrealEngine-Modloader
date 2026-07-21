-- mods/re4/CutsceneUIToCamera/main.lua v1.0
-- ═══════════════════════════════════════════════════════════════════════
-- RIP THE CUTSCENE UI OUT OF THE THEATRE BOX — captions, command prompts and
-- QTE buttons render on the normal floating UI (which follows YOU) instead of
-- being painted on the theatre screen.
--
-- WHY THIS IS CHEAP (IDA, 2026-07-21): the game ALREADY has both renderers.
-- AVR4InteractionManager::DisplayCommandPrompt [0x632D034] and
-- ::OnShowSceneMessage [0x632E0CC] both do exactly this:
--
--     if (GetActivePlayerPawnType() == 3)                 // cutscene pawn
--         AVR4CutsceneManager::ShowCommandOnInstance(..)  // -> THEATRE SCREEN
--         AVR4CutsceneManager::SetMessageOnInstance(..)
--     else
--         AVR4FloaterUI::SetInteractionCommand(..)        // -> FLOATING UI (follows you)
--         AVR4FloaterUI::SetThoughtPrompt(..)
--
-- The ONLY thing sending them to the theatre is that `== 3` test. So we do not
-- need the theatre box at all, and we do not need to teleport it: flip the two
-- branches to unconditional and the UI always takes the FloaterUI path.
--
--   0x632D064:  B.NE loc_632D088  ->  B loc_632D088   (0x14000009)  command/QTE buttons
--   0x632E160:  B.NE loc_632E17C  ->  B loc_632E17C   (0x14000007)  captions / messages
--
-- ARM64 unconditional branch = 0x14000000 | (byte_offset / 4).
--   0x632D088 - 0x632D064 = 0x24 -> imm26 = 9
--   0x632E17C - 0x632E160 = 0x1C -> imm26 = 7
--
-- Pairs with blockTheatreBox=true + re4.cutscene_force_models_visible (3D
-- cutscenes): the box is gone, but you keep subtitles, button prompts and QTEs.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "CutsceneUIToCamera"

local state = { enabled = true }
local saved = ModConfig.Load("CutsceneUIToCamera")
if saved and saved.enabled ~= nil then state.enabled = saved.enabled end
local function save() pcall(ModConfig.Save, "CutsceneUIToCamera", state) end

local PATCHES = {
    { name = "DisplayCommandPrompt (buttons/QTE -> FloaterUI)",
      mangled = "_ZN22AVR4InteractionManager20DisplayCommandPromptERK5FText17EVR4CommandButton14EVR4PromptSize",
      fb = 0x0632D034, delta = 0x30, word = 0x14000009 },
    { name = "OnShowSceneMessage (captions -> FloaterUI)",
      mangled = "_ZN22AVR4InteractionManager18OnShowSceneMessageERK5FText",
      fb = 0x0632E0CC, delta = 0x94, word = 0x14000007 },
}

local applied = false

local function apply()
    local n = 0
    for _, p in ipairs(PATCHES) do
        pcall(function()
            local fn = Resolve(p.mangled, p.fb)
            if not fn or IsNull(fn) then
                Log(TAG .. ": [WARN] " .. p.name .. " not resolved")
                return
            end
            p.addr = Offset(fn, p.delta)
            if not p.orig then p.orig = ReadU32(p.addr) end
            WriteU32(p.addr, p.word)
            n = n + 1
            Log(TAG .. string.format(": PATCHED %s @%s  %08X -> %08X",
                p.name, ToHex(p.addr), p.orig, p.word))
        end)
    end
    applied = n > 0
    return n
end

local function restore()
    for _, p in ipairs(PATCHES) do
        if p.addr and p.orig then pcall(function() WriteU32(p.addr, p.orig) end) end
    end
    applied = false
    Log(TAG .. ": restored — cutscene UI goes back to the theatre screen")
end

if state.enabled then apply() end

RegisterCommand("cutsceneui", function()
    state.enabled = not state.enabled
    if state.enabled then apply() else restore() end
    save()
    Notify(TAG, "Cutscene UI on camera " .. (state.enabled and "ON" or "OFF"))
    return tostring(state.enabled)
end)

RegisterCommand("cutsceneui_status", function()
    local s = TAG .. ": enabled=" .. tostring(state.enabled) .. " applied=" .. tostring(applied)
    for _, p in ipairs(PATCHES) do
        s = s .. "\n  " .. p.name .. ": " ..
            (p.addr and (ToHex(p.addr) .. " now=" .. string.format("%08X", ReadU32(p.addr))
                         .. " orig=" .. string.format("%08X", p.orig or 0)) or "unresolved")
    end
    return s
end)

if SharedAPI and SharedAPI.DebugMenu then
    pcall(function()
        SharedAPI.DebugMenu.RegisterToggle("CutsceneUIToCamera", "Cutscene UI on camera (not theatre)",
            function() return state.enabled end,
            function(v) state.enabled = v; if v then apply() else restore() end; save() end)
    end)
end

Log(TAG .. ": v1.0 loaded — captions/buttons/QTE routed to AVR4FloaterUI"
    .. " | applied=" .. tostring(applied) .. " | cmd: cutsceneui, cutsceneui_status")
