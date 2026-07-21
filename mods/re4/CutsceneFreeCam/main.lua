-- mods/re4/CutsceneFreeCam/main.lua v1.0
-- ═══════════════════════════════════════════════════════════════════════
-- FREE CAMERA DURING CUTSCENES — walk around the scene while it plays.
--
-- WHY THIS EXISTS (measured 2026-07-21, not guessed):
--   A cutscene suspends the world. Three separate layers had to be peeled:
--     1. cPlayer::move never runs        -> re4.drive_player_in_cutscene (native)
--     2. models are hidden               -> re4.cutscene_force_models_visible (native)
--     3. INPUT IS NEVER SAMPLED          -> this mod
--   Layer 3 is the one that killed every "unlock the player" attempt: the whole
--   RE4 pad block (0xA562B40..0xA562BB8 — buttons AND axes) stays 0x00000000 for
--   the entire scene. 7 samples over 10s at depth=2, all zero. So unmasking input
--   (KeyStop) is meaningless — there is no data to unmask, and cPlayer::move
--   faithfully ticks on a permanently-zero stick.
--
--   Also: scenes that script Leon put him in state 5 (vs 0 when untouched), so we
--   do NOT fight for his body — the scene keeps its performance. Instead we move
--   the VIEW: a free spectator camera. That is what the user actually wants.
--
-- HOW:
--   Input comes straight from the headset, bypassing the dead RE4 pad entirely:
--   ovrp_GetControllerState6 in libOVRPlugin.so (+0x176C40), CALLED (never hooked
--   — it runs on the OVR input thread) from the game thread. Struct layout:
--     +0 ConnectedControllers, +4 Buttons, +8 Touches, +12 NearTouches,
--     +16 IndexTrigger[2], +24 HandTrigger[2], +32 Thumbstick[0] (L x,y),
--     +40 Thumbstick[1] (R x,y)
--
--   Movement reuses the PROVEN anchor path from 3DCutscenesFix: on the
--   UpdateCamera POST edge, overwrite the cine-camera FTransform's translation
--   (cam+0x10) with our free-cam position, then SetAnchorInternal(pawn, cam).
--   Post-edge so ours is the last write to the pawn transform each frame.
--
--   Left stick = move in the camera's own forward/right basis. Right stick Y =
--   rise/fall. Position accumulates from wherever the cine camera started, and
--   resets each time a new scene begins.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "CutsceneFreeCam"

local state = {
    enabled = true,
    speed   = 300.0,   -- world units per second
    vspeed  = 200.0,
    dead    = 0.15,    -- stick deadzone
}
local saved = ModConfig.Load("CutsceneFreeCam")
if saved then for k, v in pairs(saved) do if state[k] ~= nil then state[k] = v end end end
local function save() pcall(ModConfig.Save, "CutsceneFreeCam", state) end

-- ── symbols ────────────────────────────────────────────────────────────
local sym_UpdateCamera = Resolve("_ZN22AVR4CutscenePlayerPawn12UpdateCameraERK10FTransformfb", 0x06443E64)
local sym_SetAnchor    = Resolve("_ZN14AVR4PlayerPawn17SetAnchorInternalERK10FTransform",      0x0639A598)

-- ── libOVRPlugin base (parse /proc/self/maps) ──────────────────────────
local OVRP_GETSTATE6 = 0x176C40
local ovrp_fn, ovrp_buf = nil, nil

local function initOVR()
    local ok = pcall(function()
        local maps = ReadTextFile("/proc/self/maps")
        if not maps then return end
        local base = nil
        for line in maps:gmatch("[^\r\n]+") do
            if line:find("libOVRPlugin.so", 1, true) then
                local a = line:match("^(%x+)%-")
                if a then
                    local v = tonumber(a, 16)
                    if v and (not base or v < base) then base = v end
                end
            end
        end
        if not base then Log(TAG .. ": [WARN] libOVRPlugin.so not found in maps"); return end
        ovrp_fn  = IntToPtr(base + OVRP_GETSTATE6)
        ovrp_buf = CallNativeBySymbol("malloc", "pp", 512)
        Log(TAG .. string.format(": OVRPlugin base=0x%X  GetControllerState6=%s", base, ToHex(ovrp_fn)))
    end)
    if not ok then Log(TAG .. ": [WARN] OVR init failed") end
    return ovrp_fn ~= nil and ovrp_buf ~= nil
end

-- Returns lx, ly, rx, ry  (each -1..1), or nil if unavailable.
local function readSticks()
    if not (ovrp_fn and ovrp_buf) then return nil end
    local lx, ly, rx, ry
    local ok = pcall(function()
        CallNative(ovrp_fn, "iup", 0x03, ovrp_buf)   -- mask 0x03 = both touch controllers
        lx = ReadF32(Offset(ovrp_buf, 32))
        ly = ReadF32(Offset(ovrp_buf, 36))
        rx = ReadF32(Offset(ovrp_buf, 40))
        ry = ReadF32(Offset(ovrp_buf, 44))
    end)
    if not ok then return nil end
    return lx, ly, rx, ry
end

-- ── free-cam OFFSET from the cine camera ───────────────────────────────
-- v1.1 FLASHING FIX. v1.0 tracked an ABSOLUTE position and called
-- SetAnchorInternal on EVERY frame — 13001 frames with moves=0, i.e. it fought
-- the Blueprint's own camera write every single frame while contributing
-- nothing. Two poses written per frame = the view oscillates = the exact
-- flashing documented in 3DCutscenesFix. It also parked the view at a stale
-- absolute position (113,153,515) that had nothing to do with the scene.
--
-- v1.1 stores an OFFSET instead, and does NOTHING until you actually move:
--   offset == 0  -> return immediately, never touch the transform
--                   => the cutscene camera behaves exactly like vanilla
--   offset != 0  -> anchor to (cine camera + offset)
-- So idle is bit-identical to no mod at all, and the anchor only exists while
-- you are steering. Offset auto-clears when a scene ends.
local off = { x = 0, y = 0, z = 0 }
local lastT = nil
local frames, moves, anchors = 0, 0, 0

local function dz(v)
    if not v then return 0 end
    if v > state.dead then return (v - state.dead) / (1 - state.dead) end
    if v < -state.dead then return (v + state.dead) / (1 - state.dead) end
    return 0
end

if not initOVR() then
    Log(TAG .. ": [WARN] no OVR input — free cam will not move")
end

local hookOK = false
if sym_UpdateCamera and not IsNull(sym_UpdateCamera) and sym_SetAnchor and not IsNull(sym_SetAnchor) then
    pcall(function()
        RegisterNativeHookAt(sym_UpdateCamera, "CutsceneFreeCam", nil,
            function(retval, self_ptr, cam_ptr, fov, screenOn)
                if not (state.enabled and cam_ptr and PtrToInt(cam_ptr) ~= 0) then return retval end
                pcall(function()
                    frames = frames + 1

                    -- dt
                    local now = GetTimeSeconds and GetTimeSeconds() or nil
                    local dt = 1.0 / 72.0
                    if now and lastT then
                        local d = now - lastT
                        if d > 0 and d < 0.5 then dt = d end
                    end
                    lastT = now

                    -- Accumulate the offset from stick input.
                    local lx, ly, rx, ry = readSticks()
                    if lx then
                        local mx, my = dz(lx), dz(ly)
                        local vy     = dz(ry)
                        if mx ~= 0 or my ~= 0 or vy ~= 0 then
                            -- camera basis from the quat (UE: X fwd, Y right, Z up)
                            local qx = ReadF32(Offset(cam_ptr, 0x00))
                            local qy = ReadF32(Offset(cam_ptr, 0x04))
                            local qz = ReadF32(Offset(cam_ptr, 0x08))
                            local qw = ReadF32(Offset(cam_ptr, 0x0C))
                            local fx = 1.0 - 2.0*(qy*qy + qz*qz)
                            local fy = 2.0*(qx*qy + qw*qz)
                            local fz = 2.0*(qx*qz - qw*qy)
                            local rxv = 2.0*(qx*qy - qw*qz)
                            local ryv = 1.0 - 2.0*(qx*qx + qz*qz)
                            local rzv = 2.0*(qy*qz + qw*qx)
                            local s = state.speed * dt
                            off.x = off.x + (fx*my + rxv*mx) * s
                            off.y = off.y + (fy*my + ryv*mx) * s
                            off.z = off.z + (fz*my + rzv*mx) * s + vy * state.vspeed * dt
                            moves = moves + 1
                        end
                    end

                    -- THE FLASHING FIX: if you have not moved, do NOT touch the
                    -- transform. No competing write => no oscillation => vanilla
                    -- cutscene camera. Only steer once there is a real offset.
                    if (off.x*off.x + off.y*off.y + off.z*off.z) < 0.01 then return end

                    local cx = ReadF32(Offset(cam_ptr, 0x10))
                    local cy = ReadF32(Offset(cam_ptr, 0x14))
                    local cz = ReadF32(Offset(cam_ptr, 0x18))
                    WriteF32(Offset(cam_ptr, 0x10), cx + off.x)
                    WriteF32(Offset(cam_ptr, 0x14), cy + off.y)
                    WriteF32(Offset(cam_ptr, 0x18), cz + off.z)
                    CallNative(sym_SetAnchor, "vpp", self_ptr, cam_ptr)
                    anchors = anchors + 1
                end)
                return retval
            end,
            "ppfi")
        hookOK = true
    end)
end

RegisterCommand("freecam", function()
    state.enabled = not state.enabled
    off.x, off.y, off.z = 0, 0, 0
    save()
    Notify(TAG, "Cutscene free cam " .. (state.enabled and "ON" or "OFF"))
    return tostring(state.enabled)
end)

RegisterCommand("freecam_reset", function()
    off.x, off.y, off.z = 0, 0, 0
    return "free cam offset cleared - camera returns to the scene's own framing"
end)

RegisterCommand("freecam_speed", function()
    state.speed = (state.speed >= 1200) and 150.0 or (state.speed * 2)
    save()
    Notify(TAG, "speed " .. math.floor(state.speed))
    return tostring(state.speed)
end)

RegisterCommand("freecam_status", function()
    local lx, ly, rx, ry = readSticks()
    return TAG .. ": enabled=" .. tostring(state.enabled)
        .. " hook=" .. tostring(hookOK)
        .. " ovr=" .. tostring(ovrp_fn ~= nil)
        .. " frames=" .. tostring(frames) .. " moves=" .. tostring(moves)
        .. " speed=" .. tostring(state.speed)
        .. " stick=" .. (lx and string.format("L(%.2f,%.2f) R(%.2f,%.2f)", lx, ly, rx, ry) or "nil")
        .. " anchors=" .. tostring(anchors)
        .. " off=" .. string.format("%.0f,%.0f,%.0f", off.x, off.y, off.z)
end)

if SharedAPI and SharedAPI.DebugMenu then
    pcall(function()
        SharedAPI.DebugMenu.RegisterToggle("CutsceneFreeCam", "Cutscene free camera",
            function() return state.enabled end,
            function(v) state.enabled = v; off.x, off.y, off.z = 0, 0, 0; save() end)
    end)
end

Log(TAG .. ": v1.0 loaded — free spectator cam during cutscenes"
    .. " | hook=" .. tostring(hookOK)
    .. " ovr=" .. tostring(ovrp_fn ~= nil)
    .. " | cmds: freecam, freecam_speed, freecam_reset, freecam_status")
