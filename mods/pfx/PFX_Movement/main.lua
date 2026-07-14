-- ============================================================================
-- PFX_Movement — faster smooth locomotion, faster turning, no comfort tunnel
-- ============================================================================
-- Reverse-engineered from libUnreal.so + live reflection:
--   • Locomotion speed  = BP_VR_Pawn_C.SmoothMoveSpeed  (double UPROPERTY @3128)
--                         game default 200.0
--   • Turn speed        = PFX settings "Settings.Movement.SmoothMovement.RotationSpeed"
--                         stored as a float in the master settings buffer:
--                            A = *(PFXPlayerSettingsManager + 0x40);  RotationSpeed = A+76
--                         game default 50.0
--   • Comfort tunnel    = "Settings.Movement.SmoothMovement.TunnelingIntensity" = A+72
--                         (0 => vignette never closes).  The pawn renders it via
--                         CurrentTunnelWidth (double @3312); with intensity 0 it stays wide.
--
-- The settings buffer / pawn are re-resolved every tick because the pawn respawns
-- per table and the options menu can rewrite the settings buffer. All writes are to
-- the game's OWN value fields (no code patching) => zero glitch risk.
-- ============================================================================
local TAG = "PFX_Movement"
Log(TAG .. ": loading — fast locomotion + fast turn + no tunnel")

_G._MOVE_GEN = (_G._MOVE_GEN or 0) + 1
local MY_GEN = _G._MOVE_GEN

-- ── Tunables (defaults; change live with the bridge commands below) ──────────
local CFG = _G._MOVE_CFG or {
  SPEED    = 400.0,   -- SmoothMoveSpeed (game default 200) — 2x
  ROT      = 150.0,   -- RotationSpeed   (game default 50)  — 3x
  TUNNEL   = true,    -- true => force TunnelingIntensity 0 (no comfort vignette)
  ENABLED  = true,
}
_G._MOVE_CFG = CFG

-- settings-buffer offsets (movement section)
local OFF_TUNNEL = 72   -- float  TunnelingIntensity
local OFF_ROT    = 76   -- float  RotationSpeed

local function unharden()
  if _G.PFXCore then _G.PFXCore.unharden()
  else pcall(function() CallNativeBySymbol("prctl", "iuuuuu", 4, 1, 0, 0, 0) end) end
end

-- resolve the master settings buffer (A) from the settings manager
local function settings_buf()
  local o = FindFirstOf("PFXPlayerSettingsManager")
  if not (o and o.IsValid and o:IsValid()) then return 0 end
  local A = MemReadU64(PtrToInt(o:GetAddress()) + 64)
  if A < 0x1000000000 or A > 0x80000000000 then return 0 end
  return A
end

local function pawn()
  local p = FindFirstOf("BP_VR_Pawn_C")
  if p and p.IsValid and p:IsValid() then return p end
  return nil
end

-- ── Apply the three settings (idempotent; only writes when different) ────────
local function apply()
  if not CFG.ENABLED then return end
  pcall(function()
    local p = pawn()
    if p then
      local cur = p:Get("SmoothMoveSpeed")
      if cur and math.abs(cur - CFG.SPEED) > 0.01 then p:Set("SmoothMoveSpeed", CFG.SPEED) end
    end
    local A = settings_buf()
    if A ~= 0 then
      if math.abs((MemReadFloat(A + OFF_ROT) or 0) - CFG.ROT) > 0.01 then
        MemWriteFloat(A + OFF_ROT, CFG.ROT)
      end
      if CFG.TUNNEL and (MemReadFloat(A + OFF_TUNNEL) or 0) ~= 0.0 then
        MemWriteFloat(A + OFF_TUNNEL, 0.0)
      end
    end
  end)
end

unharden()
apply()
LoopAsync(500, function()
  if _G._MOVE_GEN ~= MY_GEN then return true end   -- superseded by a reload
  unharden(); apply()
  return false
end)

-- ── Bridge commands ─────────────────────────────────────────────────────────
pcall(function() RegisterCommand("move_speed", function(a)
  local v = tonumber(a); if v then CFG.SPEED = v; apply() end
  return TAG .. ": SmoothMoveSpeed = " .. tostring(CFG.SPEED) .. "  (default 200)"
end) end)
pcall(function() RegisterCommand("move_rot", function(a)
  local v = tonumber(a); if v then CFG.ROT = v; apply() end
  return TAG .. ": RotationSpeed = " .. tostring(CFG.ROT) .. "  (default 50)"
end) end)
pcall(function() RegisterCommand("move_tunnel", function(a)
  if a and (a == "0" or a == "off" or a == "false") then CFG.TUNNEL = false
  elseif a and (a == "1" or a == "on" or a == "true") then CFG.TUNNEL = true end
  apply()
  return TAG .. ": force-no-tunnel = " .. tostring(CFG.TUNNEL)
end) end)
pcall(function() RegisterCommand("move_on", function() CFG.ENABLED = true; apply()
  return TAG .. ": ENABLED" end) end)
pcall(function() RegisterCommand("move_off", function() CFG.ENABLED = false
  return TAG .. ": DISABLED (values left as-is until relaunch)" end) end)
pcall(function() RegisterCommand("move_status", function()
  local p = pawn(); local A = settings_buf()
  local spd = p and tostring(p:Get("SmoothMoveSpeed")) or "no-pawn"
  local rot = (A ~= 0) and string.format("%.1f", MemReadFloat(A + OFF_ROT)) or "?"
  local tun = (A ~= 0) and string.format("%.1f", MemReadFloat(A + OFF_TUNNEL)) or "?"
  return string.format("%s: enabled=%s | SmoothMoveSpeed=%s RotationSpeed=%s Tunnel=%s (want spd=%.0f rot=%.0f noTunnel=%s)",
    TAG, tostring(CFG.ENABLED), spd, rot, tun, CFG.SPEED, CFG.ROT, tostring(CFG.TUNNEL))
end) end)

_G.PFX_Movement = {
  set_speed = function(v) CFG.SPEED = v; apply() end,
  set_rot   = function(v) CFG.ROT = v; apply() end,
  set_tunnel_off = function(b) CFG.TUNNEL = b and true or false; apply() end,
}

Log(TAG .. ": ready — speed=" .. CFG.SPEED .. " rot=" .. CFG.ROT .. " noTunnel=" .. tostring(CFG.TUNNEL))
