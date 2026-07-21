-- mods/3DCutscenesFix/main.lua v13.0
-- ═══════════════════════════════════════════════════════════════════════
-- 3D Cutscenes — render cutscenes in the real 3D world (follow the cutscene
-- camera) instead of the forced 2D "theatre box".
--
-- FULL REWRITE (v13) after reversing the cutscene pipeline in libUE4.so v2.3:
--
--   During a cutscene the game swaps the active pawn to AVR4CutscenePlayerPawn.
--   Every tick, AVR4CutscenePlayerPawn::PostBio4Tick does:
--       screenOn = (pG[0x71] & 4)==0 && (pG[0x50A5] & 4)==0   -- 2D-screen flag
--       cam      = GetCameraTransform()   -- WORLD-space cutscene camera (pG+148)
--       UpdateCamera(cam, fov, screenOn)  -- forwards to a Blueprint event
--   and AVR4CutscenePlayerPawn::StreamLoadTheatreBox streams in a SEPARATE
--   level instance (the theatre room) via ULevelStreamingDynamic.
--
--   The game ALREADY renders some cutscenes fully 3D — those are exactly the
--   ones where `screenOn` is false. So the fix is to make EVERY cutscene take
--   that same path:
--     1. Force screenOn = false on every UpdateCamera call  → 3D camera path.
--     2. Block StreamLoadTheatreBox                          → stay in the 3D world.
--
--   Both are on the game thread (cutscene-only), so there is no render-thread
--   Lua hazard. StreamLoadTheatreBox is byte-patched (no per-call Lua at all).
--
-- Toggles (persisted): forceScreenOff, blockTheatreBox, anchorToCamera.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "3DCutscenesFix"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = {
    enabled         = true,
    -- THE WORKING 3D APPROACH (v17 — user-verified on device):
    --   Forcing the VR view to a POSITION inside the scene DOES render 3D — the
    --   theatre box is viewable, not an unlit void. The old anchor put you at the
    --   WIDE CINEMATIC CAMERA (feels wrong / far). The fix is anchorToCharacter:
    --   place the view at LEON's world position each frame (keeping the cine yaw so
    --   you face the action), so you ride along with him. Position comes from the
    --   player pawn (VR4Bio4PlayerPawn:K2_GetActorLocation). We reuse the proven
    --   SetAnchorInternal path by overwriting the cutscene camera's translation
    --   (cam+0x10) with Leon's pos + offset just before the anchor call.
    -- Tunables (live commands): cutscene_up/down (eye height), cutscene_back/fwd
    --   (pull toward/away from the wide cam along the Leon→cam axis).
    forceScreenOff    = true,   -- cutscene_screen : screenOn=0, kill the flat screen (needed)
    blockTheatreBox   = false,  -- cutscene_theatre: keep OFF (additive box = world stays)
    anchorToCamera    = false,  -- cutscene_anchor : wide cine-cam anchor (charFwd=0 == this)
    anchorToCharacter = true,   -- cutscene_follow : ride the cine cam + push toward the subject
    -- IMPORTANT: the cutscene actors live in the THEATRE-BOX space (where the cine
    -- camera is), NOT where Leon's gameplay pawn stands — the main world is
    -- suspended (dark) during a cutscene, so anchoring to the gameplay pawn = BLACK.
    -- So we start at the cine-camera position (proven to render 3D) and move along
    -- the camera's OWN forward vector toward whatever it is framing (Leon). charFwd=0
    -- is exactly the wide cam; increase it to approach the character.
    charFwd           = 0.0,    -- move toward the subject along the cine forward axis
    charUp            = 0.0,    -- world Z nudge (raise/lower the eye)
    autoQTE           = true,   -- auto-pass quick-time events
}

local saved = ModConfig.Load("3DCutscenesFix")
if saved then
    for k, v in pairs(saved) do if state[k] ~= nil then state[k] = v end end
end

local ARM64_MOVZ_X0_0 = 0xD2800000   -- mov x0, #0
local ARM64_RET       = 0xD65F03C0   -- ret

-- ── Resolve the cutscene functions (names resolve; offsets are current) ──
local sym_UpdateCamera    = Resolve("_ZN22AVR4CutscenePlayerPawn12UpdateCameraERK10FTransformfb", 0x06443E64)
local sym_TheatreBox      = Resolve("_ZN22AVR4CutscenePlayerPawn20StreamLoadTheatreBoxEv",        0x0628FDF0)
local sym_SetAnchor       = Resolve("_ZN14AVR4PlayerPawn17SetAnchorInternalERK10FTransform",      0x0639A598)

-- ═══════════════════════════════════════════════════════════════════════
-- 1. BLOCK THE THEATRE BOX — byte-patch StreamLoadTheatreBox to `mov x0,#0; ret`
--    so the 2D theatre room never streams in. No Lua on the hot path.
-- ═══════════════════════════════════════════════════════════════════════
local theatreOrig0, theatreOrig4 = nil, nil

local function applyTheatreBlock()
    if not sym_TheatreBox or IsNull(sym_TheatreBox) then
        Log(TAG .. ": [WARN] StreamLoadTheatreBox not resolved")
        return
    end
    pcall(function() theatreOrig0 = ReadU32(sym_TheatreBox); theatreOrig4 = ReadU32(Offset(sym_TheatreBox, 4)) end)
    pcall(function()
        WriteU32(sym_TheatreBox, ARM64_MOVZ_X0_0)
        WriteU32(Offset(sym_TheatreBox, 4), ARM64_RET)
    end)
    Log(TAG .. ": PATCHED StreamLoadTheatreBox → skip (no 2D theatre room) @ " .. ToHex(sym_TheatreBox))
end

local function restoreTheatreBlock()
    if sym_TheatreBox and theatreOrig0 and theatreOrig4 then
        pcall(function()
            WriteU32(sym_TheatreBox, theatreOrig0)
            WriteU32(Offset(sym_TheatreBox, 4), theatreOrig4)
        end)
        Log(TAG .. ": StreamLoadTheatreBox restored")
    end
end

if state.enabled and state.blockTheatreBox then applyTheatreBlock() end

-- ── Leon's world position (for anchorToCharacter) ───────────────────────
-- Cache the player pawn; re-find lazily if it goes invalid. One reflection
-- read per cutscene frame (cutscene-only, not gameplay-hot). pcall-guarded so a
-- bad read never faults the game thread.
local cachedLeon = nil
local function getLeonPos()
    if not cachedLeon or not cachedLeon:IsValid() then
        cachedLeon = nil
        pcall(function()
            local p = FindFirstOf("VR4Bio4PlayerPawn")
            if p and p:IsValid() then cachedLeon = p end
        end)
    end
    if not cachedLeon then return nil end
    local loc
    local ok = pcall(function() loc = cachedLeon:K2_GetActorLocation() end)
    if ok and loc then return loc.X, loc.Y, loc.Z end
    return nil
end

-- ═══════════════════════════════════════════════════════════════════════
-- 2. THE 3D FIX — UpdateCamera(this=x0, const FTransform* cam=x1, float fov=d0,
--    char screenOn=x2). UpdateCamera forwards to a Blueprint event that does the
--    per-frame camera work (and, when screenOn, draws the flat "CutsceneBoxScreen").
--    The flashing had TWO causes, addressed on the two hook edges:
--      • PRE-hook: force screenOn=0 → the Blueprint never draws the flat screen
--        that was overlaying/flickering in the 3D view.
--      • POST-hook: SetAnchorInternal(this, cam) runs AFTER the Blueprint's own
--        camera work, so OUR anchor is the last write to the pawn transform every
--        frame. As a pre-hook it ran BEFORE the BP, which overrode it on some
--        frames → the view oscillated between the cutscene camera (3D) and the
--        theatre pose → flashing. Post = it always wins = stable 3D.
--    Both edges are cutscene-only + game thread → safe.
-- ═══════════════════════════════════════════════════════════════════════
local camHookInstalled = false
if sym_UpdateCamera and not IsNull(sym_UpdateCamera) then
    pcall(function()
        RegisterNativeHookAt(sym_UpdateCamera, "CutsceneUpdateCamera",
            -- PRE: force the flat theatre screen off (before the BP draws it).
            function(self_ptr, cam_ptr, fov, screenOn)
                if state.enabled and state.forceScreenOff then
                    return self_ptr, cam_ptr, fov, 0
                end
                return self_ptr, cam_ptr, fov, screenOn
            end,
            -- POST: place the VR view AFTER the BP ran so ours is the last write.
            --   anchorToCharacter → overwrite the cutscene-camera translation
            --     (cam+0x10) with LEON's world pos (+ up / back offsets along the
            --     Leon→cam axis), then SetAnchorInternal → you ride Leon, facing the
            --     cine yaw. This is the fix (was: sitting at the wide movie camera).
            --   anchorToCamera → legacy: anchor straight to the cine camera.
            function(retval, self_ptr, cam_ptr, fov, screenOn)
                if not (state.enabled and sym_SetAnchor and cam_ptr and cam_ptr ~= 0) then
                    return retval
                end
                if state.anchorToCharacter then
                    pcall(function()
                        -- cine-cam FTransform: FQuat @ +0x00 (x,y,z,w), Translation @ +0x10
                        local qx = ReadF32(Offset(cam_ptr, 0x00))
                        local qy = ReadF32(Offset(cam_ptr, 0x04))
                        local qz = ReadF32(Offset(cam_ptr, 0x08))
                        local qw = ReadF32(Offset(cam_ptr, 0x0C))
                        local cx = ReadF32(Offset(cam_ptr, 0x10))
                        local cy = ReadF32(Offset(cam_ptr, 0x14))
                        local cz = ReadF32(Offset(cam_ptr, 0x18))
                        -- forward = quat * (1,0,0)  (UE X-forward). Move toward the framed subject.
                        local fx = 1.0 - 2.0*(qy*qy + qz*qz)
                        local fy = 2.0*(qx*qy + qw*qz)
                        local fz = 2.0*(qx*qz - qw*qy)
                        WriteF32(Offset(cam_ptr, 0x10), cx + fx * state.charFwd)
                        WriteF32(Offset(cam_ptr, 0x14), cy + fy * state.charFwd)
                        WriteF32(Offset(cam_ptr, 0x18), cz + fz * state.charFwd + state.charUp)
                        CallNative(sym_SetAnchor, "vpp", self_ptr, cam_ptr)
                    end)
                elseif state.anchorToCamera then
                    pcall(function() CallNative(sym_SetAnchor, "vpp", self_ptr, cam_ptr) end)
                end
                return retval
            end,
            "ppfi")
        camHookInstalled = true
        Log(TAG .. ": Hooked UpdateCamera (PRE screenOff + POST anchor) @ " .. ToHex(sym_UpdateCamera))
    end)
else
    Log(TAG .. ": [WARN] UpdateCamera not resolved")
end

-- ═══════════════════════════════════════════════════════════════════════
-- 3. AUTO QTE — quick-time events must auto-pass (you can't see/react to the
--    button prompt while watching the cutscene in 3D).
--    AVR4InteractionManager::SetCurrentCommandQTEId(qteId) fires when a QTE
--    starts; AVR4InteractionManager::SucceedQTE(qteId) broadcasts the success
--    event (event 15) that completes it. We succeed on start + a couple short
--    retries so we land inside the input window.
-- ═══════════════════════════════════════════════════════════════════════
local sym_SetQTEId   = Resolve("_ZN22AVR4InteractionManager22SetCurrentCommandQTEIdE6EQTEId", 0x0632CFA8)
local sym_SucceedQTE = Resolve("_ZN22AVR4InteractionManager10SucceedQTEE6EQTEId",             0x0632F874)
local qteHookInstalled = false

local function succeedQTE(id)
    if sym_SucceedQTE and id and id ~= 0 then
        pcall(function() CallNative(sym_SucceedQTE, "vi", id) end)
    end
end

if sym_SetQTEId and not IsNull(sym_SetQTEId) and sym_SucceedQTE and not IsNull(sym_SucceedQTE) then
    pcall(function()
        RegisterNativeHookAt(sym_SetQTEId, "SetCurrentCommandQTEId", nil,
            function(retval, self_ptr, qteId)
                -- post-hook: self_ptr = x0, qteId = x1
                if state.enabled and state.autoQTE and qteId and qteId ~= 0 then
                    V("auto-QTE: SucceedQTE(%s)", tostring(qteId))
                    local id = qteId
                    succeedQTE(id)                                           -- immediately
                    ExecuteWithDelay(80,  function() succeedQTE(id) end)     -- + retries so we
                    ExecuteWithDelay(250, function() succeedQTE(id) end)     -- hit the input window
                end
                return retval
            end)
        qteHookInstalled = true
        Log(TAG .. ": Hooked SetCurrentCommandQTEId → auto SucceedQTE @ " .. ToHex(sym_SetQTEId))
    end)
else
    Log(TAG .. ": [WARN] QTE symbols not resolved (auto-QTE disabled)")
end

-- ═══════════════════════════════════════════════════════════════════════
-- COMMANDS
-- ═══════════════════════════════════════════════════════════════════════

local function save() ModConfig.Save("3DCutscenesFix", state) end

RegisterCommand("cutscene", function()
    state.enabled = not state.enabled
    if state.enabled then
        if state.blockTheatreBox then applyTheatreBlock() end
    else
        restoreTheatreBlock()
    end
    save()
    Log(TAG .. ": " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "3D Cutscenes ON" or "3D Cutscenes OFF")
end)

RegisterCommand("cutscene_theatre", function()
    state.blockTheatreBox = not state.blockTheatreBox
    if state.enabled and state.blockTheatreBox then applyTheatreBlock() else restoreTheatreBlock() end
    save()
    Log(TAG .. ": blockTheatreBox=" .. tostring(state.blockTheatreBox))
    Notify(TAG, "Theatre box " .. (state.blockTheatreBox and "BLOCKED" or "allowed"))
end)

RegisterCommand("cutscene_screen", function()
    state.forceScreenOff = not state.forceScreenOff
    save()
    Log(TAG .. ": forceScreenOff=" .. tostring(state.forceScreenOff))
    Notify(TAG, "Force 3D screen " .. (state.forceScreenOff and "ON" or "OFF"))
end)

RegisterCommand("cutscene_anchor", function()
    state.anchorToCamera = not state.anchorToCamera
    save()
    Log(TAG .. ": anchorToCamera=" .. tostring(state.anchorToCamera))
    Notify(TAG, "Camera anchor " .. (state.anchorToCamera and "ON" or "OFF"))
end)

RegisterCommand("cutscene_follow", function()
    state.anchorToCharacter = not state.anchorToCharacter
    if state.anchorToCharacter then state.anchorToCamera = false end
    save()
    Log(TAG .. ": anchorToCharacter=" .. tostring(state.anchorToCharacter))
    Notify(TAG, "Follow Leon " .. (state.anchorToCharacter and "ON" or "OFF"))
end)

-- Live position tuning (step size chosen for RE4 world units; adjust as needed).
local STEP = 25.0
RegisterCommand("cutscene_up",   function() state.charUp = state.charUp + STEP; save(); Notify(TAG, "eye height "..math.floor(state.charUp)) end)
RegisterCommand("cutscene_down", function() state.charUp = state.charUp - STEP; save(); Notify(TAG, "eye height "..math.floor(state.charUp)) end)
RegisterCommand("cutscene_fwd",  function() state.charFwd = state.charFwd + STEP; save(); Notify(TAG, "toward subject "..math.floor(state.charFwd)) end)
RegisterCommand("cutscene_back", function() state.charFwd = state.charFwd - STEP; save(); Notify(TAG, "toward subject "..math.floor(state.charFwd)) end)

RegisterCommand("cutscene_qte", function()
    state.autoQTE = not state.autoQTE
    save()
    Log(TAG .. ": autoQTE=" .. tostring(state.autoQTE))
    Notify(TAG, "Auto QTE " .. (state.autoQTE and "ON" or "OFF"))
end)

RegisterCommand("cutscene_status", function()
    Log(TAG .. ": enabled=" .. tostring(state.enabled)
        .. " forceScreenOff=" .. tostring(state.forceScreenOff)
        .. " blockTheatreBox=" .. tostring(state.blockTheatreBox)
        .. " anchorToCamera=" .. tostring(state.anchorToCamera)
        .. " | camHook=" .. tostring(camHookInstalled)
        .. " theatreSym=" .. tostring(sym_TheatreBox ~= nil))
end)

-- ═══════════════════════════════════════════════════════════════════════
-- DEBUG MENU
-- ═══════════════════════════════════════════════════════════════════════
if SharedAPI and SharedAPI.DebugMenu then
    local api = SharedAPI.DebugMenu
    api.RegisterToggle("3DCutscenesFix", "3D Cutscenes",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then (state.blockTheatreBox and applyTheatreBlock or function() end)() else restoreTheatreBlock() end
            save()
        end)
    api.RegisterToggle("3DCutscenesFix_Theatre", "  ↳ Block Theatre Box",
        function() return state.blockTheatreBox end,
        function(v) state.blockTheatreBox = v; if state.enabled and v then applyTheatreBlock() else restoreTheatreBlock() end; save() end)
    api.RegisterToggle("3DCutscenesFix_Anchor", "  ↳ Anchor To Camera (wide/legacy)",
        function() return state.anchorToCamera end,
        function(v) state.anchorToCamera = v; if v then state.anchorToCharacter = false end; save() end)
    api.RegisterToggle("3DCutscenesFix_Follow", "  ↳ Follow Leon (3D)",
        function() return state.anchorToCharacter end,
        function(v) state.anchorToCharacter = v; if v then state.anchorToCamera = false end; save() end)
    -- Optional stepper buttons for live tuning if the menu API supports them.
    if api.RegisterButton then
        api.RegisterButton("3DCutscenesFix_Up",   "    · eye height +",      function() state.charUp = state.charUp + 25; save() end)
        api.RegisterButton("3DCutscenesFix_Down", "    · eye height -",      function() state.charUp = state.charUp - 25; save() end)
        api.RegisterButton("3DCutscenesFix_Fwd",  "    · toward subject +",  function() state.charFwd = state.charFwd + 25; save() end)
        api.RegisterButton("3DCutscenesFix_Back", "    · toward subject -",  function() state.charFwd = state.charFwd - 25; save() end)
    end
end

-- NOTE: anchorToCharacter here moves along the cine-cam FORWARD axis only (stays
-- in the valid theatre-box render space near the working camera — small, safe).
-- Do NOT anchor to the gameplay pawn's world position: that is far outside the
-- box in the suspended main world, and effects there crash MTXConcat/EspCommonTrans
-- (tombstone_02). The accurate target is cutscene-Leon's ACTOR position IN the box
-- (TODO: enumerate cutscene AVR4Models live and pick Leon).
Log(TAG .. ": v18.0 loaded — 3D via cine-cam + forward push toward subject (safe, in-box);"
    .. " gameplay-pawn teleport REMOVED (it crashed effects) | follow=" .. tostring(state.anchorToCharacter)
    .. " fwd=" .. tostring(state.charFwd) .. " up=" .. tostring(state.charUp)
    .. " screenOff=" .. tostring(state.forceScreenOff)
    .. " anchorCam=" .. tostring(state.anchorToCamera)
    .. " camHook=" .. tostring(camHookInstalled)
    .. " qte=" .. tostring(qteHookInstalled)
    .. " | tune: cutscene_fwd/back, cutscene_up/down, cutscene_follow")
