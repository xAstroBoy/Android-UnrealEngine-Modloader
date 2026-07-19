-- mods/re4/CharacterGear/main.lua v1.0
-- =====================================================================
-- CHARACTER GEAR — give Leon the torch, give Ashley the arsenal.
--
-- Neither of these is a hack: both characters already have the machinery,
-- they're just not wired to each other. What a character can CARRY is
-- decided by holster data on the pawn, and the game exposes a runtime
-- setter for it:
--
--     AVR4GamePlayerPawn::OverrideHolsterData(const FHolsterData& standing,
--                                             const FHolsterData& seated,
--                                             EPropSlot slot)      @0x62FD2CC
--
-- It is a BlueprintCallable UFunction (execOverrideHolsterData @0x648744C),
-- so we call it through reflection — no byte patching, no native hooks.
--
-- FROM THE BLUEPRINT DUMPS (RE4/Decompiled Blueprints):
--   VR4Bio4PlayerPawn_BP  (Leon)
--       StandingHolsterData = PropHolster_Gun1_C
--       SeatedHolsterData   = PropHolster_Gun1_Seated_C
--   VR4Bio4PlayerPawn_Ashley_BP
--       StandingHolsterData = PropHolster_Flashlight_C          <- the torch
--       SeatedHolsterData   = PropHolster_Flashlight_Seated_C
--       ...attached to socket_gun1_l / socket_gun1_r — THE SAME SOCKETS
--       Leon uses for his gun. That is why this works at all: the mount
--       point is identical, only the holster class differs.
--
--   Leon's own BP already calls OverrideHolsterData at runtime for his
--   Wild-West variants (slots 0x1 and 0x4), so calling it ourselves is
--   exactly how the game does it — not a new code path.
--
-- Leon also ALREADY has a flashlight prop of his own
-- (VR4GamePlayer_Flashlight_BP, plus a FlashlightTutorial); he simply has
-- no holster slot to draw it from. Ashley's lantern (VR4AshleyLantern_BP)
-- is a separate, throwable prop with a single PrimaryGrip.
-- =====================================================================
local TAG = "CharacterGear"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = {
    leonTorch     = true,   -- give Leon a flashlight/torch holster slot
    ashleyWeapons = true,   -- give Ashley gun holsters
}
local saved = ModConfig.Load("CharacterGear")
if saved then
    if saved.leonTorch     ~= nil then state.leonTorch     = saved.leonTorch     end
    if saved.ashleyWeapons ~= nil then state.ashleyWeapons = saved.ashleyWeapons end
end
local function save()
    pcall(ModConfig.Save, "CharacterGear", state)
end

-- ── Asset paths straight out of the decompiled Blueprints ─────────────
local P = {
    holsterGun1        = "/Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Gun1.PropHolster_Gun1_C",
    holsterGun1Seated  = "/Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Gun1_Seated.PropHolster_Gun1_Seated_C",
    holsterFlash       = "/Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Flashlight.PropHolster_Flashlight_C",
    holsterFlashSeated = "/Game/Blueprints/Player/Game/Props/Holsters/PropHolster_Flashlight_Seated.PropHolster_Flashlight_Seated_C",
}

-- EPropSlot — from the SDK enum dump. NOT arbitrary indices:
--     Gun1=0  Gun2=1  Grenade=2  Knife=3  Ammo1=4  Ammo2=5
--     Consumable=6  Flashlight=7  ScriptedGun=8  ScriptedAmmo=9
-- v1.0 used slot 2 and produced no visible holster — because 2 is GRENADE,
-- so it replaced Leon's grenade holster with a flashlight one instead of
-- adding a torch. There is a DEDICATED Flashlight slot (7); use it.
-- (Leon's BP overrides slots 1 and 4 for his Wild-West gun/ammo variants,
-- which is why those two are already spoken for.)
local SLOT = {
    Gun1       = 0,
    Gun2       = 1,
    Flashlight = 7,
}

-- ── Pawn lookup ───────────────────────────────────────────────────────
-- Ashley and Leon are DIFFERENT pawn classes, not one pawn with a flag, so
-- whichever exists tells us who we're currently playing.
local function findPawn()
    local leon   = FindFirstOf("VR4Bio4PlayerPawn")
    local ashley = FindFirstOf("VR4Bio4PlayerPawn_Ashley_BP_C")
    if ashley and not IsNull(ashley) then return ashley, "ashley" end
    if leon   and not IsNull(leon)   then return leon,   "leon"   end
    return nil, nil
end

local function loadClass(path)
    local ok, cls = pcall(function() return StaticFindObject and StaticFindObject(path) or nil end)
    if ok and cls and not IsNull(cls) then return cls end
    ok, cls = pcall(function() return FindObject and FindObject(path) or nil end)
    if ok and cls and not IsNull(cls) then return cls end
    ok, cls = pcall(function() return LoadAsset and LoadAsset(path) or nil end)
    if ok and cls and not IsNull(cls) then return cls end
    return nil
end

-- Call the pawn's own OverrideHolsterData UFunction with a holster pair.
-- Struct params are passed as plain tables; the reflection layer marshals
-- them into FHolsterData (HolsterClass + the two attach-bone FNames).
local function applyHolster(pawn, standingPath, seatedPath, slot, label)
    local cs = loadClass(standingPath)
    local cq = loadClass(seatedPath)
    if not cs then LogWarn(TAG .. ": could not load " .. standingPath); return false end
    local ok, err = pcall(function()
        pawn:Call("OverrideHolsterData", {
            StandingHolsterData = {
                HolsterClass          = cs,
                LeftHandedAttachBone  = "socket_gun1_l",
                RightHandedAttachBone = "socket_gun1_r",
            },
            SeatedHolsterData = {
                HolsterClass          = cq or cs,
                LeftHandedAttachBone  = "socket_gun1_seated_l",
                RightHandedAttachBone = "socket_gun1_seated_r",
            },
            Slot = slot,
        })
    end)
    if ok then
        Log(TAG .. ": " .. label .. " -> holster applied on slot " .. slot)
        return true
    end
    LogWarn(TAG .. ": " .. label .. " FAILED: " .. tostring(err))
    return false
end

local function apply()
    local pawn, who = findPawn()
    if not pawn then return "no player pawn — be in gameplay" end

    if who == "ashley" and state.ashleyWeapons then
        -- Ashley ships with only a Flashlight holster. Give her Leon's gun
        -- holsters on the real gun slots so the full arsenal is drawable.
        applyHolster(pawn, P.holsterGun1, P.holsterGun1Seated, SLOT.Gun1,
                     "Ashley: gun holster (Gun1)")
        applyHolster(pawn, P.holsterGun1, P.holsterGun1Seated, SLOT.Gun2,
                     "Ashley: gun holster (Gun2)")
        return "Ashley: gun holsters applied on Gun1+Gun2 — draw from the hip"
    end

    if who == "leon" and state.leonTorch then
        -- Leon has a flashlight PROP (VR4GamePlayer_Flashlight_BP) but no
        -- holster to draw it from. Put Ashley's Flashlight holster on the
        -- DEDICATED Flashlight slot (7) — not a spare index.
        applyHolster(pawn, P.holsterFlash, P.holsterFlashSeated, SLOT.Flashlight,
                     "Leon: flashlight/torch holster")
        return "Leon: torch holster applied on the Flashlight slot"
    end

    return "nothing to do for " .. tostring(who)
end

-- ── Commands + menu ───────────────────────────────────────────────────
RegisterCommand("chargear", function()
    local msg = apply()
    Log(TAG .. ": " .. msg)
    return msg
end)

RegisterCommand("chargear_status", function()
    local _, who = findPawn()
    return TAG .. ": pawn=" .. tostring(who)
        .. " leonTorch=" .. tostring(state.leonTorch)
        .. " ashleyWeapons=" .. tostring(state.ashleyWeapons)
end)

if SharedAPI and SharedAPI.DebugMenu then
    pcall(function()
        SharedAPI.DebugMenu.AddToggle(TAG, "Leon: torch slot", function() return state.leonTorch end,
            function(v) state.leonTorch = v; save(); apply() end)
        SharedAPI.DebugMenu.AddToggle(TAG, "Ashley: full arsenal", function() return state.ashleyWeapons end,
            function(v) state.ashleyWeapons = v; save(); apply() end)
        SharedAPI.DebugMenu.AddAction(TAG, "Apply gear now", function() apply() end)
    end)
end

-- Apply on level load: the pawn is respawned per level, so holster overrides
-- do not survive a transition and must be re-applied.
if LoopAsync then
    local lastPawn = nil
    LoopAsync(2000, function()
        local pawn = findPawn()
        if pawn and pawn ~= lastPawn then
            lastPawn = pawn
            pcall(apply)
        end
        return false
    end)
end

Log(TAG .. ": v1.0 loaded — Leon torch=" .. tostring(state.leonTorch)
    .. " Ashley arsenal=" .. tostring(state.ashleyWeapons)
    .. " | via AVR4GamePlayerPawn::OverrideHolsterData (the game's own API)"
    .. " | cmds: chargear, chargear_status")
