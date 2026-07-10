-- ============================================================================
-- PFX_NoTilt v1 — Tilt is allowed, but it never STOPS the table (no ball loss)
-- ============================================================================
-- The pinball TILT-OUT (nudge too hard -> ball dies / flippers cut) is driven by
-- the native YUP table rules, which read TiltSensitivity off the table info. We
-- can't hook the native rule cleanly, but we CAN starve it: drive TiltSensitivity
-- to ~0 on every table so the tilt meter never reaches the ball-loss threshold.
-- You can still nudge; it just won't tilt you out.
--
-- Semantics are dialable at runtime: notilt_set <val>. Default 0. If 0 turns out
-- to be the WRONG direction (tilts instantly), try a large value instead.
-- NudgeStrength is left alone so nudging still feels/works normally.
-- ============================================================================
local TAG = "PFX_NoTilt"
Log(TAG .. ": Loading v2 — no tilt-out (cached re-pin, no 2s scan spike)...")

-- Reload generation: older LoopAsync callbacks compare this and self-terminate, so
-- hot-reloading never leaves the previous (spiky) loop running alongside the new one.
_G._NOTILT_GEN = (_G._NOTILT_GEN or 0) + 1
local MY_GEN = _G._NOTILT_GEN

local TILT_VAL   = 0.0     -- TiltSensitivity to force on every table
local APPLY_MS   = 2000    -- cheap re-pin cadence (uses CACHED handles, no scan)
local RESCAN_MS  = 60000   -- full FindAllOf rescan cadence (expensive ~130ms scan)
-- Only PFXVRTableInfo exists on PFX; "YUPTableInfo" matched 0 objects but each
-- FindAllOf still scans the WHOLE GUObjectArray (~130ms on PFX) — dropping it and
-- caching the found handles is what kills the every-2s spike.
local INFO_CLASSES = { "PFXVRTableInfo" }

local applied_count = 0
local cache = {}          -- cached table-info template handles (avoids re-scanning)

local function live(o)
  if not o then return false end
  local ok, v = pcall(function() return o:IsValid() end)
  if not ok or not v then return false end
  local ok2, n = pcall(function() return o:GetName() end)
  return ok2 and n and not n:match("^Default__") and not n:match("^REINST_")
end

-- EXPENSIVE: full GUObjectArray scan (~130ms). Refreshes the cache of table-info
-- templates. Called rarely (startup + RESCAN_MS) to catch DLC tables streamed in.
local function rescan()
  cache = {}
  for _, cn in ipairs(INFO_CLASSES) do
    for _, ti in ipairs(FindAllOf(cn) or {}) do
      if live(ti) then cache[#cache+1] = ti end
    end
  end
  return #cache
end

-- CHEAP: re-force TiltSensitivity on the already-known template handles. No array
-- scan — just Set() on each cached object (validated live). The templates persist,
-- so pinning them keeps every subsequently-loaded table's tilt-out starved.
local function apply_cached()
  local n = 0
  for _, ti in ipairs(cache) do
    if live(ti) then
      if pcall(function() ti:Set("TiltSensitivity", TILT_VAL) end) then n = n + 1 end
    end
  end
  applied_count = n
  return n
end

-- Full apply: rescan then pin (used at startup and by bridge commands).
local function apply_all()
  rescan()
  return apply_cached()
end

-- Two loops: a cheap frequent re-pin over cached handles, and a rare full rescan.
local loop_on = false
local function start_loop()
  if loop_on then return end
  loop_on = true
  LoopAsync(APPLY_MS, function()        -- cheap: cached re-pin, no scan
    if _G._NOTILT_GEN ~= MY_GEN then return true end
    pcall(apply_cached)
    return false
  end)
  LoopAsync(RESCAN_MS, function()        -- rare: refresh cache (one ~130ms scan/min)
    if _G._NOTILT_GEN ~= MY_GEN then return true end
    pcall(apply_all)
    return false
  end)
end

-- ── Bridge commands ─────────────────────────────────────────────────────────
pcall(function() RegisterCommand("notilt_set", function(v)
  v = tonumber(v)
  if v == nil then return TAG .. ": TiltSensitivity currently forced to " .. tostring(TILT_VAL) end
  TILT_VAL = v
  local n = apply_all()
  return string.format("%s: TiltSensitivity forced to %s on %d tables", TAG, tostring(TILT_VAL), n)
end) end)

pcall(function() RegisterCommand("notilt_status", function()
  local sample = {}
  for _, ti in ipairs(cache) do
    if live(ti) and #sample < 4 then
      local ts = "?"; pcall(function() ts = tostring(ti:Get("TiltSensitivity")) end)
      sample[#sample+1] = ts
    end
  end
  return string.format("%s: forcing TiltSensitivity=%s | applied=%d | live sample: %s",
    TAG, tostring(TILT_VAL), applied_count, table.concat(sample, ", "))
end) end)

_G.PFX_NoTilt = {
  apply   = apply_all,
  set_val = function(v) TILT_VAL = v; return apply_all() end,
  status  = function() return applied_count, TILT_VAL end,
}

-- ── Activation ──────────────────────────────────────────────────────────────
ExecuteWithDelay(4000, function()
  local n = apply_all()
  start_loop()
  Log(TAG .. string.format(": applied TiltSensitivity=%s to %d tables; re-applying every %dms", tostring(TILT_VAL), n, APPLY_MS))
end)

Log(TAG .. ": v1 loaded — bridge: notilt_set <val>, notilt_status")
