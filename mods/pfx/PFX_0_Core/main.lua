-- ============================================================================
-- PFX_0_Core — central runtime for PFX mods (name sorts first so it loads first)
-- ============================================================================
-- Two jobs:
--   1. ANTI-TAMPER UNBIND. The game hardens its own process to non-dumpable
--      (PR_SET_DUMPABLE=0), which makes /proc/self/mem root-owned and unreadable
--      by our own uid — so EVERY MemRead*/MemWrite* silently returns 0 and every
--      memory mod dies. We flip it back to dumpable at load AND on a loop, so it
--      survives the game re-hardening after a table load / update.
--   2. CENTRAL YUP ACCESS. Owns the game offsets + the physics-ball chain (S ->
--      holder array -> ball_struct) and exposes them as _G.PFXCore, so other mods
--      read live instances through ONE place. On a game update, fix the offsets
--      HERE and every mod follows — no per-mod adapting.
-- ============================================================================
local TAG = "PFX_0_Core"
Log(TAG .. ": loading — anti-tamper unbind + shared YUP access")

-- ── 1. Anti-tamper: keep the process DUMPABLE ───────────────────────────────
local PR_SET_DUMPABLE = 4
local function unharden()
  -- prctl(PR_SET_DUMPABLE, 1) — reopens /proc/self/mem to our own uid.
  pcall(function() CallNativeBySymbol("prctl", "iuuuuu", PR_SET_DUMPABLE, 1, 0, 0, 0) end)
end
unharden()
LoopAsync(1500, function() unharden(); return false end)   -- survive re-hardening

-- ── Base + heap check ────────────────────────────────────────────────────────
local function base()
  local b = YUP.GetLibBase()
  return (type(b) == "number") and b or PtrToInt(b)
end
local function heap(p) return p and p > 0x7000000000 and p < 0x8000000000 end

-- ── 2. YUP offsets — THE single place to update on a game update ─────────────
-- (verified for the current build; the game APK bump grew the board struct +0x20)
local OFF = {
  GETBALL    = 0x48A3798,  -- GetBall(S, idx) = *(*(S+ARR) + 8*idx)  (hook x0 = S)
  VTABLE_S   = 0x6cba7c8,  -- S's vtable (validates a captured S)
  ARR        = 0x5E0,      -- S+ARR   = ball holder array
  COUNT      = 0x5E8,      -- S+COUNT = ball holder count (int)
  BALLSIM    = 0x4998F84,  -- ball-sim fn; its x0 = manager M, with *(M+8)==S
  HOLDER_BS  = 0xA8,       -- holder+HOLDER_BS  = ball_struct
  HOLDER_ACT = 0x90,       -- holder+HOLDER_ACT : 1 = simulating
  HOLDER_SKIP= 0x4A,       -- holder+HOLDER_SKIP: !=0 = held in a kicker/lock
  POS        = 0x0,        -- ball_struct+POS = x,y,z floats (table-local m)
  VEL        = 0x38,       -- ball_struct+VEL = vx,vy,vz floats
  RADIUS     = 0xB0,       -- ball_struct+RADIUS (default 0.0135)
  M_STASH    = 0x248,      -- manager+M_STASH : stash bitmask (held/gated balls)
}

-- ── S (board) + M (manager) capture via native hooks ─────────────────────────
local function install()
  if _G._CORE_SHOOK then return end
  local ok = false
  pcall(function()
    ok = RegisterNativeHookAt(IntToPtr(base() + OFF.GETBALL), "core_getS",
      function(x0) _G._CORE_S = PtrToInt(x0) end, nil)
  end)
  pcall(function()
    RegisterNativeHookAt(IntToPtr(base() + OFF.BALLSIM), "core_getM",
      function(x0)
        local m = PtrToInt(x0)
        if MemReadU64(m + 8) == (_G._CORE_S or 0) then _G._CORE_M = m end
      end, nil)
  end)
  _G._CORE_SHOOK = ok
  Log(TAG .. ": S/M capture hooks = " .. tostring(ok))
end

local function valid_S(s)
  if not s or s == 0 then return false end
  local vp = 0; pcall(function() vp = MemReadU64(s) end)
  return vp == base() + OFF.VTABLE_S
end
local function get_S() local s = _G._CORE_S or 0; if valid_S(s) then return s end return 0 end
local function get_M() return _G._CORE_M or 0 end

-- iterate the real in-array balls: fn(index, ball_struct, holder)
local function each_ball(fn)
  local s = get_S(); if s == 0 then return end
  local arr = MemReadU64(s + OFF.ARR); if not heap(arr) then return end
  local n = MemReadU64(s + OFF.COUNT) & 0xFFFFFFFF; if n > 8 then n = 8 end
  for i = 0, n - 1 do
    local h = MemReadU64(arr + i * 8)
    if heap(h) then
      local bs = MemReadU64(h + OFF.HOLDER_BS)
      if heap(bs) then fn(i, bs, h) end
    end
  end
end

local function ball_pos(bs) return MemReadFloat(bs + OFF.POS), MemReadFloat(bs + OFF.POS + 4), MemReadFloat(bs + OFF.POS + 8) end
local function ball_radius(bs) return MemReadFloat(bs + OFF.RADIUS) end
local function set_ball_radius(bs, r) pcall(function() MemWriteFloat(bs + OFF.RADIUS, r) end) end
-- simulating AND not held in a kicker/lock
local function ball_active(h)
  return (MemReadU64(h + OFF.HOLDER_ACT) & 0xFFFFFFFF) == 1
     and (MemReadU64(h + OFF.HOLDER_SKIP) & 0xFF) == 0
end
-- validated stash bitmask (nil when untrustworthy → caller falls back)
local function stash_mask()
  local M, s = get_M(), get_S()
  if M == 0 or s == 0 or MemReadU64(M + 8) ~= s then return nil end
  local cnt = MemReadU64(s + OFF.COUNT) & 0xFFFFFFFF
  if cnt == 0 or cnt > 8 then return nil end
  local mask = MemReadU64(M + OFF.M_STASH) & 0xFFFFFFFF
  if (mask >> cnt) ~= 0 then return nil end
  return mask
end

install()

_G.PFXCore = {
  base = base, heap = heap, OFF = OFF, unharden = unharden,
  get_S = get_S, get_M = get_M, each_ball = each_ball,
  ball_pos = ball_pos, ball_radius = ball_radius, set_ball_radius = set_ball_radius,
  ball_active = ball_active, stash_mask = stash_mask,
}

pcall(function() RegisterCommand("core_status", function()
  local s, m = get_S(), get_M()
  return string.format("%s: dumpable-fix on | S=0x%X M=0x%X (elf@base=%08X)",
    TAG, s, m, MemReadU64(base()) & 0xFFFFFFFF)
end) end)

Log(TAG .. ": ready — _G.PFXCore exposed; /proc/self/mem unblocked")
