-- PFX_FingerMode v5.3 — control the REAL physics balls with your hand.
--                       (pose-independent + HOLD-GRIP to activate)
--
-- The ball is native YUP (no UE physics body); its position lives in a ball_struct.
-- Moving the UE actor only moves the skin. We write the ball_struct directly so the
-- ACTUAL ball moves, collides (bumpers/walls/ramps) and trips animations.
--
-- Chain (offsets from IDA, runtime = GetLibBase()+IDA):
--   S = x0 of GetBall (sub_48A4710), captured via native hook.
--   S+0x5E0 = ball array ; array[i] = holder ; *(holder+0xA8) = ball_struct.
--   ball_struct: pos @ +0/+4/+8 (table-local m); vel @ +0x38/+0x3C/+0x40. Parked = (-1,-1,-1).
--
-- Reads/writes use MemReadU64/MemReadFloat/MemWriteFloat (/proc/self/mem): direct
-- deref SIGSEGVs on the physics-arena pages (that bug hid the ball all along).
--
-- POSE-INDEPENDENCE: the game re-anchors the table (cabinet) to wherever you walk,
-- so absolute world coords don't work. Each frame we find the table cabinet, build
-- its local frame from its fwd/right/up vectors, project the hand into that frame,
-- then map cabinet-local -> struct with a fixed, exact transform (fit err 0.00cm).
--
-- v5.3: HOLD GRIP to control (grip is unbound in-game -> no side effects; trigger
-- is the flipper so we don't touch it). Grip is read straight from Enhanced Input's
-- ActionInstanceData as the pure analog squeeze IA_Hand_Grasp_Right/Left (no grab-
-- state latching): value(double) = <Grasp action key in the map buffer> + 56.
-- Release grip -> balls resume normal physics instantly. Whichever hand grips is the
-- one that steers. ALL active balls follow (multiball); velocity-steer so they COLLIDE.

local TAG = "PFX_FingerMode"
Log(TAG .. ": Loading v7.9 (offsets re-anchored for game APK update)...")

-- Reload generation: a hot-reload bumps this; older LoopAsync callbacks compare it
-- and self-terminate, so re-loading this file never stacks a second follow loop.
_G._FM_GEN = (_G._FM_GEN or 0) + 1
local MY_GEN = _G._FM_GEN

-- ── Native offsets ──────────────────────────────────────────────────────────
local OFF_GETBALL  = 0x48A3798   -- game update (APK bump): was 0x48A4710
local OFF_VTABLE_S = 0x6cba7c8   -- was 0x6cb6788
local ARR_OFF    = 0x5E0         -- board struct grew +0x20; was 0x5C0
local HOLDER_BS  = 0xA8
local HOLDER_ACT = 0x90   -- holder+0x90: in-play flag (1 = active/simulating, 0 = trough/locked)

-- Enhanced Input: UEnhancedPlayerInput::ActionInstanceData TMap @ +1432; each live
-- entry stores the UInputAction* key, and the action's current value is a double at
-- key+56. Grip = IA_GrabRight / IA_GrabLeft.
local OFF_ACTION_MAP = 1432
local OFF_ACTION_VAL = 56
local GRIP_ON = 0.5       -- grip value threshold to count as "held"

-- ── Cabinet-local <-> struct transform (pose-independent; scale 100 + ~4deg tilt)
-- invM maps (cabinet_local - T_local) -> struct.  struct[j] = sum_i d[i]*invM[i][j]
local T_local = { 0.0, 0.53174, 87.77147 }
local invM = {
  { 0.01000000,  0.00000019, -0.00000017 },
  { 0.00000000,  0.00064602,  0.00997567 },
  { 0.00000000,  0.00998911, -0.00069810 },
}
-- playfield clamps (struct space) — free across the WHOLE table (full width, full
-- length, and lift up to ~15cm) but NOT off-table: steering the ball metres past
-- the edge wedges it in a wall/corner. These are table bounds + generous margin.
local CLAMP = { x = {-0.28, 0.28}, y = {-0.06, 0.15}, z = {-0.72, 0.68} }

-- ── Tuning ──────────────────────────────────────────────────────────────────
local STEER_GAIN = 22.0   -- how hard balls chase the hand (1/s)
local STEER_VMAX = 4.0    -- max speed (m/s) — cap prevents tunnelling
local SPREAD     = 0.03   -- m: fan multiball out so they don't stack on one point
-- IN-PLAY detection: holder+0x90==1 is too loose (staged/locked balls read 1 too, all
-- flags identical). The ONLY reliable signal is motion: an in-play ball MOVES; staged/
-- trough/locked balls sit at speed ~0. We grab a ball once it exceeds this speed, then
-- keep it for the whole grip (so it doesn't drop when we slow it at your hand).
local MOVE_THRESH = 0.10  -- m/s; staged balls measured ~0.01, in-play ~0.3+

-- ── Active (in-play) detection — the ball_struct LOCK-ASSIGNMENT fields ───────
-- The holder flag bytes (0x48/0x49/0x4A/0x50) are table/state-fragile and the sim's
-- lock bitmask is empty at table-start, so none of them isolate the ONE controllable
-- ball from balls sitting in a multiball lock. The reliable signal lives on the
-- ball_struct itself (verified live: 1 in-play + 2 table-locked balls):
--   ball_struct+0xE2 (byte) == 1  ONLY for the controllable in-play ball; 0 when locked.
--   ball_struct+0xE4 (byte) == 0  for in-play; == a non-zero LOCK-SLOT ID when locked.
--   (0xE0 stays 1 for all, so it can't discriminate; 0xE2 is the clean boolean.)
-- These are lock-assignment fields (set when a ball is locked/released, stable per
-- lock-state — not per-frame like velocity), so a launched ball keeps 0xE2==1 and a
-- ball that gets locked flips to 0. holder+0x4A==0 (not in a kicker) is kept as a cheap
-- extra gate. No get_M / lock-array walk needed → 3 reads, fast at 90 Hz.
-- Heap floor was 0x7000000000, but the game heap base VARIES per launch (ASLR +
-- memory pressure). This session it landed at 0x6F.. (verified: S/ball structs in
-- 0x6f21e04000-0x6f27215000), which a 0x70 floor wrongly rejected → the ball-scan
-- found 0 in-play balls (active_balls=0, "can't grab"). 0x60 covers 0x6F–0x7F.
local FM_HEAP_LO = 0x6000000000
local function fm_mapped(p) return p > FM_HEAP_LO and p < 0x8000000000 end
local function ball_active(h)
  local bs = MemReadU64(h + HOLDER_BS)                                    -- 0xA8 -> ball_struct
  if not fm_mapped(bs) then return false end
  -- ball_struct+0xE2 == 1 marks THE current ball in play (verified live: it was the
  -- shooter-lane ball at rest, then followed the ball as it launched & rolled; the 2
  -- table-locked balls stay 0). 0xE4 is NOT a lock flag (the rolling ball also had
  -- 0xE4=239) so we do NOT gate on it. holder+0x4A==0 keeps a kicker/scoop ball out.
  if (MemReadU8(bs + 0xE2) & 0xFF) == 0 then return false end             -- not the in-play ball
  if (MemReadU8(h  + 0x4A) & 0xFF) ~= 0 then return false end             -- held in a kicker/scoop
  return true
end

-- ── State ───────────────────────────────────────────────────────────────────
local enabled     = false   -- armed: loop runs and watches grip
local grabbing    = false   -- derived each frame: is grip actually held right now
local hand_side   = "MC_Right"
local loop_active = false
local idle_tick   = 0       -- idle-throttle counter for the steering loop (see start_loop)
local cab_cache   = nil
local cab_S       = 0       -- the S (physics container) the cached cabinet belongs to
local force       = false   -- bridge test override (ignore grip)
local force_side  = "right"
local grab_h0     = nil     -- hand WORLD pos captured at grip-start (relative anchor)
local grab_b0     = {}      -- [ball index] = {sx,sy,sz} struct pos at grip-start
local grab_lock   = nil     -- holder ptr of the ONE ball we're steering (multiball-safe)
local grabbed     = {}      -- [ball_struct ptr] = true: balls we've locked onto this grip
local grab_S0     = nil     -- locked ball's struct pos at grab (relative-steer anchor)
local grab_L0     = nil     -- hand cabinet-local pos at grab (relative-steer anchor)
local cal_corr    = { 0, 0, 0 }  -- per-table struct-space correction (auto-calibrated)
local cal_cab     = nil     -- cabinet the correction was calibrated for
local cal_cool    = 0       -- frames before we may retry a failed calibration
local prev_hand   = nil     -- last good hand world pos (reject tracking-glitch jumps)
local HAND_JUMP   = 40.0    -- cm/frame: >this = a tracking glitch (hand can't teleport)

local function clamp(v,lo,hi) if v<lo then return lo elseif v>hi then return hi else return v end end
local function heap(p) return p and p > FM_HEAP_LO and p < 0x8000000000 end
local function finite(v) return v == v and v < 1e6 and v > -1e6 end
local function live(o) if not o then return false end local ok,v=pcall(function() return o:IsValid() end) return ok and v end

-- ── S capture (hook GetBall; x0 = S) + M capture (hook ball-sim; x0 = manager) ──
-- M = the ball manager (verified live: *(M+8)==S). Its per-frame bitmask M+0x248
-- (248) flags balls held by a gate/kicker/holder (a "stash"); the sim SKIPS those,
-- so an in-play ball has its M+0x248 bit == 0. This is the game's OWN determination
-- (from IDA sub_49995EC), far more reliable than velocity/holder flags.
local OFF_BALLSIM = 0x4998F84   -- sub_4998F84(this=M, ...) — ball state update (was 0x49995EC)
local OFF_M_STASH = 0x248       -- M+0x248: u32 bitmask of stashed (skipped) balls
local function install_capture()
  if _G._FM_SHOOK then return end
  -- PFX_0_Core (loads first) already hooks GetBall + ball-sim at these exact
  -- addresses. Registering our OWN hooks at the same addresses just clashes — only
  -- one fires, so _FM_S/_FM_M stay 0 and finger mode goes dead. When Core is present,
  -- skip our hooks and read S/M/stash straight from it (get_S/stash_mask below).
  if _G.PFXCore then
    _G._FM_SHOOK = true
    Log(TAG .. ": using PFX_0_Core S/M capture (no duplicate GetBall hook)")
    return
  end
  local base = YUP.GetLibBase()
  local ok = false
  pcall(function()
    ok = RegisterNativeHookAt(IntToPtr(base + OFF_GETBALL), "fm_getS",
      function(x0) _G._FM_S = PtrToInt(x0) end, nil)
  end)
  pcall(function()
    RegisterNativeHookAt(IntToPtr(base + OFF_BALLSIM), "fm_getM",
      -- sub_49995EC runs for several `this` pointers; the real ball manager has BOTH
      -- *(this+8)==S AND a clean stash bitmask at +0x248 (no bits past the ball count).
      -- Validating both here pins _FM_M to the correct manager instead of whatever
      -- object fired last.
      function(x0)
        local m = PtrToInt(x0)
        local s = _G._FM_S or 0
        if s == 0 or MemReadU64(m + 8) ~= s then return end
        local cnt = MemReadU64(s + 0x5E8) & 0xFFFFFFFF
        if cnt == 0 or cnt > 8 then return end
        local mask = MemReadU64(m + 0x248) & 0xFFFFFFFF
        if (mask >> cnt) == 0 then _G._FM_M = m end
      end, nil)
  end)
  _G._FM_SHOOK = ok
  Log(TAG .. ": GetBall capture hook = " .. tostring(ok))
end

local OFF_BALLCOUNT = 0x5E8   -- *(int*)(S+0x5E8) = number of ball holders (was 0x5C8)

-- The manager's live STASH bitmask (M+0x248): bit i set ⇒ ball i is held by a gate/
-- kicker/holder (not in play). Returns the mask ONLY when it's demonstrably valid —
-- M must be the manager for the current S, and the mask must have NO bits beyond the
-- ball count (a valid mask fits in `count` bits; a stale/reused field has high bits).
-- Returns nil when we can't trust it, so the caller falls back to a motion gate.
local function stash_mask(s)
  -- Prefer Core's validated stash bitmask (its ball-sim hook is the one that fires).
  if _G.PFXCore then local m = _G.PFXCore.stash_mask(); if m ~= nil then return m end end
  local M = _G._FM_M or 0
  if M == 0 or not s or s == 0 then return nil end
  if MemReadU64(M + 8) ~= s then return nil end
  local count = MemReadU64(s + OFF_BALLCOUNT) & 0xFFFFFFFF
  if count == 0 or count > 8 then return nil end
  local mask = MemReadU64(M + OFF_M_STASH) & 0xFFFFFFFF
  if (mask >> count) ~= 0 then return nil end   -- bits past the ball count ⇒ garbage
  return mask
end

local function valid_S(s)
  if not s or s == 0 then return false end
  local vp = 0
  pcall(function() vp = MemReadU64(s) end)
  return vp == YUP.GetLibBase() + OFF_VTABLE_S
end

local function get_S()
  -- Prefer Core's capture (its GetBall hook is the one that fires when both mods run).
  if _G.PFXCore then local s = _G.PFXCore.get_S(); if s and s ~= 0 then return s end end
  local cand = _G._FM_S or 0
  if valid_S(cand) then return cand end
  return 0
end

-- ── Grip via Enhanced Input ──────────────────────────────────────────────────
local EPI = { addr = 0, gr = 0, gl = 0, pr = -1, pl = -1 }

local function rd_double(a)
  return (string.unpack("<d", string.pack("<i8", MemReadU64(a))))
end

local function epi_init()
  local ep = FindFirstOf("EnhancedPlayerInput")
  if not live(ep) then EPI.addr = 0; return false end
  EPI.addr = PtrToInt(ep:GetAddress())
  EPI.gr, EPI.gl, EPI.pr, EPI.pl = 0, 0, -1, -1
  -- pure analog grip squeeze (no grab-state latching); fall back to Grab action.
  for _, x in ipairs(FindAllOf("InputAction") or {}) do
    local n = x:GetFullName() or ""
    if n:find("IA_Hand_Grasp_Right", 1, true) then EPI.gr = PtrToInt(x:GetAddress()) end
    if n:find("IA_Hand_Grasp_Left",  1, true) then EPI.gl = PtrToInt(x:GetAddress()) end
  end
  if EPI.gr == 0 then for _, x in ipairs(FindAllOf("InputAction") or {}) do
    local n = x:GetFullName() or ""
    if n:find("IA_GrabRight", 1, true) then EPI.gr = PtrToInt(x:GetAddress()) end
    if n:find("IA_GrabLeft",  1, true) then EPI.gl = PtrToInt(x:GetAddress()) end
  end end
  local ok = EPI.addr ~= 0 and EPI.gr ~= 0
  Log(TAG .. ": EnhancedInput " .. (ok and "bound (grip reader ready)" or "not ready"))
  return ok
end

-- current value (double) of action `ia`; caches its buffer slot, rescans if moved.
local function action_val(ia, cachefield)
  if EPI.addr == 0 or ia == 0 then return 0 end
  local buf = MemReadU64(EPI.addr + OFF_ACTION_MAP)
  if not heap(buf) then return 0 end
  local pos = EPI[cachefield]
  if pos and pos >= 0 and MemReadU64(pos) == ia then
    return rd_double(pos + OFF_ACTION_VAL)
  end
  for i = 0, 1400 do
    local a = buf + i*8
    if MemReadU64(a) == ia then
      EPI[cachefield] = a
      return rd_double(a + OFF_ACTION_VAL)
    end
  end
  EPI[cachefield] = -1
  return 0
end

-- ── RAW grip via OVRPlugin (hardware, context-independent) ───────────────────
-- We CALL ovrp_GetControllerState6 ourselves from the game thread (via CallNative)
-- rather than hooking it — hooking fires on the OVR input thread and is unsafe.
-- The state struct carries HandTrigger[2] (analog grip squeeze) = true hardware
-- grip, with no Enhanced Input mapping-context gating; works in every game state.
-- buf = tagged malloc ptr (passed to GS6 so the MTE/pointer tag matches);
-- rbuf = tag-stripped copy for /proc/self/mem preads (pread uses the value as a
-- literal file offset, so the TBI top-byte tag must be cleared or it reads garbage).
local OVR = { base = 0, buf = 0, rbuf = 0, ok = false, mask = 0x03, r = 0.0, l = 0.0 }
local PTR_MASK = 0x00FFFFFFFFFFFFFF
local OVR_GS6  = 0x176C40  -- ovrp_GetControllerState6 offset in libOVRPlugin.so
local OVR_HT_R = 28        -- HandTrigger[1] (right)   \ stable across struct
local OVR_HT_L = 24        -- HandTrigger[0] (left)    / versions v2..v6

local function ovr_base()
  if OVR.base ~= 0 then return OVR.base end
  local f = io.open("/proc/self/maps", "r"); if not f then return 0 end
  local b = nil
  for line in f:lines() do
    if line:find("libOVRPlugin.so", 1, true) then
      local a = line:match("^(%x+)-")
      if a then local v = tonumber(a, 16); if v and (not b or v < b) then b = v end end
    end
  end
  f:close()
  OVR.base = b or 0
  return OVR.base
end

local function ovr_setup()
  if OVR.ok then return true end
  if ovr_base() == 0 then return false end
  if OVR.buf == 0 then
    local p; pcall(function() p = CallNativeBySymbol("malloc", "pp", 512) end)
    if p then OVR.buf = (type(p) == "number") and p or PtrToInt(p) end
  end
  if not OVR.buf or OVR.buf == 0 then return false end
  OVR.rbuf = OVR.buf & PTR_MASK   -- tag-stripped copy for /proc/self/mem reads
  OVR.ok = true
  Log(TAG .. string.format(": OVR poll ready base=0x%X buf=0x%X", OVR.base, OVR.buf))
  return true
end

-- poll the controller state on THIS (game) thread; safe, no hook
local function ovr_poll()
  if not ovr_setup() then return false end
  -- GS6 gets the TAGGED pointer (write); reads use the tag-stripped rbuf.
  pcall(function() CallNative(IntToPtr(OVR.base + OVR_GS6), "iup", OVR.mask, IntToPtr(OVR.buf)) end)
  OVR.r = MemReadFloat(OVR.rbuf + OVR_HT_R)
  OVR.l = MemReadFloat(OVR.rbuf + OVR_HT_L)
  return true
end

-- returns "right" / "left" / nil depending on which grip is held.
-- Primary: raw OVRPlugin HandTrigger. Fallback: Enhanced Input action value.
local _grip_retry = 0
local function grip_state()
  -- raw hardware grip (preferred)
  if ovr_poll() then
    local r, l = OVR.r or 0, OVR.l or 0
    if finite(r) and r > GRIP_ON then return "right" end
    if finite(l) and l > GRIP_ON then return "left" end
    return nil
  end
  -- fallback: Enhanced Input (self-healing address resolution)
  if EPI.addr == 0 or EPI.gr == 0 then epi_init() end
  if EPI.addr == 0 or EPI.gr == 0 then return nil end
  local vr = action_val(EPI.gr, "pr")
  local vl = (EPI.gl ~= 0) and action_val(EPI.gl, "pl") or 0
  if not (finite(vr) and finite(vl)) then EPI.addr = 0; return nil end
  if EPI.pr == -1 then
    _grip_retry = _grip_retry + 1
    if _grip_retry >= 30 then _grip_retry = 0; epi_init() end
  else
    _grip_retry = 0
  end
  if vr > GRIP_ON then return "right" elseif vl > GRIP_ON then return "left" end
  return nil
end

-- ── Cabinet (table) — the actor the balls are attached to; it re-anchors as you
-- move, so we resolve it generically via a ball's attach-parent chain. ────────
-- CRITICAL: the cache is tied to the physics container S. On a table SWITCH the old
-- cabinet actor lingers as "valid" for a while, so a plain live() check kept using
-- the PREVIOUS table's cabinet (at a far world origin) — the hand then localized
-- against the wrong origin and the ball was flung to a corner. S changes per table,
-- so re-find the cabinet whenever S changes.
local function get_cabinet()
  local curS = get_S()
  if live(cab_cache) and cab_S == curS and curS ~= 0 then return cab_cache end
  cab_cache = nil
  local balls = FindAllOf("ball_C") or {}
  for _, b in ipairs(balls) do
    if live(b) and b:GetName() ~= "ball_1" then
      local root; pcall(function() root = b:Call("K2_GetRootComponent") end)
      local par = root; local depth = 0
      while par and depth < 10 do
        local nxt; pcall(function() nxt = par:Call("GetAttachParent") end)
        if not nxt then break end
        local own; pcall(function() own = nxt:Call("GetOwner") end)
        if live(own) then
          local n = own:GetName() or ""
          if n:find("Cabinet") then cab_cache = own; cab_S = curS; return own end
        end
        par = nxt; depth = depth + 1
      end
    end
  end
  return nil
end

-- project a world location into the cabinet's local frame (handles walk+rotate)
local function localize(cab, w)
  local fwd, rgt, up, loc
  pcall(function()
    fwd = cab:Call("GetActorForwardVector"); rgt = cab:Call("GetActorRightVector")
    up  = cab:Call("GetActorUpVector");      loc = cab:Call("K2_GetActorLocation")
  end)
  if not (fwd and rgt and up and loc) then return nil end
  local rx, ry, rz = w.X - loc.X, w.Y - loc.Y, w.Z - loc.Z
  return rx*fwd.X + ry*fwd.Y + rz*fwd.Z,
         rx*rgt.X + ry*rgt.Y + rz*rgt.Z,
         rx*up.X  + ry*up.Y  + rz*up.Z
end

-- ── Ball helpers ────────────────────────────────────────────────────────────
local function ball_pos(bs) return MemReadFloat(bs), MemReadFloat(bs+4), MemReadFloat(bs+8) end

local function each_ball(s, fn)
  local arr = MemReadU64(s + ARR_OFF)
  if not heap(arr) then return end
  for i = 0, 7 do
    local h = MemReadU64(arr + i*8)
    if heap(h) then
      local bs = MemReadU64(h + HOLDER_BS)
      if heap(bs) then fn(i, bs, h) end
    end
  end
end

local function is_parked(x, y) return math.abs(x+1) < 0.02 and math.abs(y+1) < 0.02 end

local function ball_speed(bs)
  local vx, vy, vz = MemReadFloat(bs+0x38), MemReadFloat(bs+0x3C), MemReadFloat(bs+0x40)
  if not (finite(vx) and finite(vy) and finite(vz)) then return 0 end
  return math.sqrt(vx*vx + vy*vy + vz*vz)
end

local function get_mc()
  local pawn = FindFirstOf("BP_VR_Pawn_C") or FindFirstOf("BP_Pawn_Base_C")
  return pawn and pawn:Get(hand_side)
end

local function hand_loc()
  local mc = get_mc()
  if not live(mc) then return nil end
  local p; pcall(function() p = mc:Call("K2_GetComponentLocation") end)
  return p
end

-- hand location + orientation (world right/up vectors of the controller). Used to
-- ROTATE the held multiball cluster in 3D: the formation is laid out along the
-- hand's right/up axes, so twisting your wrist spins the balls around your hand.
local function hand_pose()
  local mc = get_mc()
  if not live(mc) then return nil end
  local p, r, u
  pcall(function()
    p = mc:Call("K2_GetComponentLocation")
    r = mc:Call("GetRightVector")
    u = mc:Call("GetUpVector")
  end)
  return p, r, u
end

-- Convert a WORLD direction to a unit direction in struct space (cabinet basis then
-- invM linear part, renormalised). Lets us lay the ball formation out in the hand's
-- own frame regardless of table pose.
local function struct_dir(cf, cr, cu, d)
  if not d then return nil end
  local l1 = d.X*cf.X + d.Y*cf.Y + d.Z*cf.Z
  local l2 = d.X*cr.X + d.Y*cr.Y + d.Z*cr.Z
  local l3 = d.X*cu.X + d.Y*cu.Y + d.Z*cu.Z
  local sx = l1*invM[1][1] + l2*invM[2][1] + l3*invM[3][1]
  local sy = l1*invM[1][2] + l2*invM[2][2] + l3*invM[3][2]
  local sz = l1*invM[1][3] + l2*invM[2][3] + l3*invM[3][3]
  local m = math.sqrt(sx*sx + sy*sy + sz*sz)
  if m < 1e-9 then return nil end
  return sx/m, sy/m, sz/m
end

-- hand world -> cabinet-local -> struct. ABSOLUTE map: the ball goes exactly where
-- your hand is (in table space), so it COMES TO your hand and tracks it 1:1. No
-- clamping and no out-of-bounds release — the ball freely follows the hand anywhere.
local function hand_to_struct(cab, h)
  local lx, ly, lz = localize(cab, h)
  if not lx then return nil end
  local dx, dy, dz = lx - T_local[1], ly - T_local[2], lz - T_local[3]
  local sx = dx*invM[1][1] + dy*invM[2][1] + dz*invM[3][1]
  local sy = dx*invM[1][2] + dy*invM[2][2] + dz*invM[3][2]
  local sz = dx*invM[1][3] + dy*invM[2][3] + dz*invM[3][3]
  if not (finite(sx) and finite(sy) and finite(sz)) then return nil end
  return sx, sy, sz
end

-- Full 3D chase: every in-play ball chases the hand in X/Y/Z (comes up to your hand).
local function steer_ball(bs, tx, ty, tz)
  local cx, cy, cz = ball_pos(bs)
  if not (finite(cx) and finite(cy) and finite(cz)) then return end
  local vx = (tx - cx) * STEER_GAIN
  local vy = (ty - cy) * STEER_GAIN
  local vz = (tz - cz) * STEER_GAIN
  local sp = math.sqrt(vx*vx + vy*vy + vz*vz)
  if sp > STEER_VMAX then local k = STEER_VMAX / sp; vx = vx*k; vy = vy*k; vz = vz*k end
  MemWriteFloat(bs+0x38, vx); MemWriteFloat(bs+0x3C, vy); MemWriteFloat(bs+0x40, vz)
end

-- ── Per-table AUTO-CALIBRATION ────────────────────────────────────────────────
-- The fixed transform (T_local/invM) is exact only on the table it was fit on; on
-- other tables it maps the hand off-playfield (ball jams in a corner). We fix that
-- WITHOUT recalibrating by hand: a live ball gives us ground truth. Each ball's REAL
-- world position, pushed through hand_to_struct, PREDICTS a struct pos; the ball's
-- ACTUAL struct pos is known. Their difference is the per-table correction we add to
-- the hand target. One calibration per table (cached); recomputed on table change.
local function calibrate(cab, s)
  -- predicted struct for each ball skin actor (its world pos through the transform)
  local preds = {}
  for _, b in ipairs(FindAllOf("ball_C") or {}) do
    if live(b) then
      local wp; pcall(function() wp = b:Call("K2_GetActorLocation") end)
      if wp then
        local px, py, pz = hand_to_struct(cab, wp)
        if px then preds[#preds+1] = { px, py, pz } end
      end
    end
  end
  if #preds == 0 then return false end
  -- pair each in-play ball to its nearest predicted point; average the residual
  local cx, cy, cz, n = 0, 0, 0, 0
  each_ball(s, function(i, bs, h)
    if ball_active(h) then
      local sx, sy, sz = ball_pos(bs)
      if not is_parked(sx, sy) then
        local bd, bp = 1e18, nil
        for _, p in ipairs(preds) do
          local dx, dy, dz = sx-p[1], sy-p[2], sz-p[3]
          local d = dx*dx + dy*dy + dz*dz
          if d < bd then bd = d; bp = p end
        end
        if bp and bd < 0.09 then   -- within ~30cm → a real pairing (not noise)
          cx = cx + (sx-bp[1]); cy = cy + (sy-bp[2]); cz = cz + (sz-bp[3]); n = n + 1
        end
      end
    end
  end)
  if n == 0 then return false end
  cal_corr = { cx/n, cy/n, cz/n }
  cal_cab  = cab
  _G._FM_CAL = { cal_corr[1], cal_corr[2], cal_corr[3], n }   -- diag
  _G._FM_CALRUN = (_G._FM_CALRUN or 0) + 1
  return true
end

-- ── Follow loop: while grip is held, steer the nearest ball toward the hand ─────
local function start_loop()
  if loop_active then return end
  loop_active = true
  LoopAsync(11, function()   -- ~90 Hz while steering; throttled to ~30 Hz when idle
    if _G._FM_GEN ~= MY_GEN then return true end   -- superseded by a newer reload -> die
    if not enabled then loop_active = false; grabbing = false; grab_h0 = nil; return true end

    -- ── IDLE THROTTLE ────────────────────────────────────────────────────────
    -- This body used to run at the full 90 Hz ALL THE TIME: the not-gripping path
    -- returns false (= keep looping), so every tick still paid get_S() + an
    -- OVRPlugin grip poll + Lua dispatch on the GAME THREAD even with both hands
    -- empty. That is ~90 wasted passes/sec for the entire session, which is pure
    -- frame-time for the 99% of play where nobody is grabbing a ball.
    -- While actually steering we keep the full rate (it is a physics chase and
    -- needs it). Idle, a third of that is plenty: worst-case grab detection is
    -- delayed ~22ms, which is imperceptible, and idle cost drops by ~66%.
    if not grabbing then
      idle_tick = (idle_tick or 0) + 1
      if idle_tick % 3 ~= 0 then return false end
    else
      idle_tick = 0
    end

    local s = get_S(); if s == 0 then grabbing = false; grab_h0 = nil; return false end

    -- activation gate: hold grip (or bridge force). Whichever hand grips steers.
    local side = grip_state()
    if not side and force then side = force_side end
    if not side then grabbing = false; grab_lock = nil; grab_S0 = nil; grab_L0 = nil; grabbed = {}; prev_hand = nil; return false end
    hand_side = (side == "left") and "MC_Left" or "MC_Right"

    local cab = get_cabinet(); if not cab then grabbing = false; grab_lock = nil; return false end
    local hl, hr, hu = hand_pose(); if not hl then grabbing = false; grab_lock = nil; return false end

    -- Reject controller TRACKING GLITCHES: the hand can't physically jump >40cm in one
    -- 11ms frame (that's 36 m/s). When the read teleports (e.g. tracking loss returned a
    -- pose ~9m away), reuse the last good position so the ball isn't flung to a corner.
    if prev_hand then
      local dx, dy, dz = hl.X - prev_hand[1], hl.Y - prev_hand[2], hl.Z - prev_hand[3]
      if dx*dx + dy*dy + dz*dz > HAND_JUMP*HAND_JUMP then
        hl = { X = prev_hand[1], Y = prev_hand[2], Z = prev_hand[3] }
      else
        prev_hand = { hl.X, hl.Y, hl.Z }
      end
    else
      prev_hand = { hl.X, hl.Y, hl.Z }
    end

    -- Auto-calibrate this table's correction once (from a live ball). Table change ->
    -- drop the stale correction. Retry cooldown avoids hammering FindAllOf when no
    -- ball is in play yet (a failed attempt = no active ball to calibrate from).
    if cal_cab ~= cab then cal_corr = { 0, 0, 0 }; cal_cab = nil end
    if cal_cool > 0 then cal_cool = cal_cool - 1 end
    if not cal_cab and cal_cool == 0 then
      local hasball = false   -- cheap precheck (memory only) before the ~130ms FindAllOf
      each_ball(s, function(i, bs, h)
        if ball_active(h) then local x, y = ball_pos(bs); if not is_parked(x, y) then hasball = true end end
      end)
      if hasball and not calibrate(cab, s) then cal_cool = 90 end
    end

    -- ABSOLUTE: map the hand into table space (+ per-table correction); the controlled
    -- ball CHASES that point via velocity steering (comes toward your hand, collides).
    local rtx, rty, rtz = hand_to_struct(cab, hl)
    if not rtx then grabbing = false; return false end
    local tx, ty, tz = rtx + cal_corr[1], rty + cal_corr[2], rtz + cal_corr[3]
    _G._FM_DIAG = { rtx, rty, rtz, tx, ty, tz, cal_corr[1], cal_corr[2], cal_corr[3] }
    -- record the worst (farthest) target + the hand world pos that produced it
    do
      local mag = math.max(math.abs(tx), math.abs(tz), math.abs(ty))
      local w = _G._FM_WORST
      if not w or mag > w[1] then
        _G._FM_WORST = { mag, tx, ty, tz, hl.X, hl.Y, hl.Z }
      end
    end

    -- Build the ball formation's axes from the HAND's orientation (in struct space):
    -- twisting your wrist rotates rx/ux, so the multiball cluster rotates in 3D with
    -- your hand. Falls back to struct X/Z if orientation isn't available.
    local cf, cr, cu
    pcall(function()
      cf = cab:Call("GetActorForwardVector"); cr = cab:Call("GetActorRightVector"); cu = cab:Call("GetActorUpVector")
    end)
    local rx, ry, rz, ux, uy, uz
    if cf and cr and cu then
      rx, ry, rz = struct_dir(cf, cr, cu, hr)
      ux, uy, uz = struct_dir(cf, cr, cu, hu)
    end
    if not (rx and ux) then rx, ry, rz = 1, 0, 0; ux, uy, uz = 0, 0, 1 end

    grabbing = true
    -- Three-signal grab, robust against table-locked balls:
    --  1. GATE  ball_active(h) — the game's own in-play test. A locked/held/staged ball
    --           (holder+0x4A!=0, or in a lock/stash) fails this; we release it (clear the
    --           latch) and NEVER steer it. This is what stops us ripping locked balls.
    --  2. ACQUIRE  only a MOVING in-play ball (speed>MOVE_THRESH) is grabbed. A resting
    --           ball sitting in a trough/lock (even if momentarily 0x4A==0) is NOT moving,
    --           so we don't yank it out. The one you're PLAYING rolls -> it's grabbed.
    --  3. HOLD  once grabbed, the latch keeps steering it while it stays in-play, so
    --           holding it still at your hand (speed -> 0) doesn't drop it. The latch is
    --           cleared on grip release, on drain (parked), and when it leaves in-play (1).
    local n = 0
    each_ball(s, function(i, bs, h)
      if not ball_active(h) then grabbed[bs] = nil; return end   -- not in play -> release, don't touch
      local x, y = ball_pos(bs)
      if is_parked(x, y) then grabbed[bs] = nil; return end       -- drained -> release
      if grabbed[bs] or ball_speed(bs) > MOVE_THRESH then
        grabbed[bs] = true
        local a = (n % 3 - 1) * SPREAD
        local b = (math.floor(n / 3) - 1) * SPREAD
        steer_ball(bs, tx + a*rx + b*ux, ty + a*ry + b*uy, tz + a*rz + b*uz)
        n = n + 1
      end
    end)
    return false
  end)
  Log(TAG .. ": follow loop started (hold grip to control)")
end

-- ── Background PRE-WARM ───────────────────────────────────────────────────────
-- The first grip used to FREEZE the game ~¼s: get_cabinet() and calibrate() each do
-- a FindAllOf("ball_C") (~130ms) + reflection the very first time per table, and both
-- ran lazily inside the grip path. This low-rate (3 Hz) loop does that heavy resolve
-- PROACTIVELY once a ball is in play — before you grip — so the results are cached and
-- the grip path is instant. The unavoidable FindAllOf hitch now lands at ball-launch
-- (masked by the ball flying out) instead of the moment you try to steer. Cheap when
-- already cached (a live()/S compare), so it costs nothing on subsequent ticks.
local prewarm_active = false
local function start_prewarm()
  if prewarm_active then return end
  prewarm_active = true
  LoopAsync(333, function()
    if _G._FM_GEN ~= MY_GEN then return true end        -- superseded by a reload
    if not enabled then prewarm_active = false; return true end
    local s = get_S(); if s == 0 then return false end
    local cab = get_cabinet(); if not cab then return false end   -- FindAllOf; cached after 1st
    if cal_cool > 0 then cal_cool = cal_cool - 1 end
    if cal_cab ~= cab and cal_cool == 0 then
      local hasball = false                             -- cheap memory precheck (no FindAllOf)
      each_ball(s, function(i, bs, h)
        if ball_active(h) then local x, y = ball_pos(bs); if not is_parked(x, y) then hasball = true end end
      end)
      if hasball and not calibrate(cab, s) then cal_cool = 90 end
    end
    return false
  end)
end

-- ── Arm / disarm ─────────────────────────────────────────────────────────────
local function arm()
  enabled = true
  install_capture()
  ovr_setup()
  epi_init()
  start_loop()
  start_prewarm()   -- resolve cabinet + calibrate off the grip path (no first-grip freeze)
end

local function disarm()
  enabled = false
  grabbing = false
  force = false
  grab_lock = nil
  grab_S0 = nil
  grab_L0 = nil
  grabbed = {}
end

-- ── Bridge commands ─────────────────────────────────────────────────────────
pcall(function() RegisterCommand("finger_on", function()
  arm()
  return TAG .. ": ARMED — HOLD GRIP (either hand) to control all active balls. Release to stop."
end) end)

pcall(function() RegisterCommand("finger_off", function()
  disarm()
  return TAG .. ": OFF"
end) end)

-- ── Unstuck: teleport every in-play ball to the centre of the playfield, raised a
-- little with zero velocity so it drops back into play. The ball can wedge in a wall
-- or corner (esp. in finger mode); this frees it. Struct axes (table-local metres):
-- x=+0 width, y=+4 height, z=+8 length; vel x/y/z at +0x38/+0x3C/+0x40. Centre (0,*,0)
-- is always on the playfield on every table, so it's a safe generic drop point.
local function unstuck()
  local s = get_S(); if s == 0 then return 0 end
  local n = 0
  each_ball(s, function(i, bs, h)
    if ball_active(h) then
      local x, y = ball_pos(bs)
      if not is_parked(x, y) then
        MemWriteFloat(bs + 0,    0.0)    -- x: centre width
        MemWriteFloat(bs + 4,    0.13)   -- y: raised above the surface so it drops in
        MemWriteFloat(bs + 8,    0.0)    -- z: centre length
        MemWriteFloat(bs + 0x38, 0.0)    -- zero velocity (let physics take over)
        MemWriteFloat(bs + 0x3C, 0.0)
        MemWriteFloat(bs + 0x40, 0.0)
        n = n + 1
      end
    end
  end)
  return n
end
pcall(function() RegisterCommand("finger_unstuck", function()
  local s = get_S(); if s == 0 then return TAG .. ": no table/ball in play" end
  local n = unstuck()
  return TAG .. ": unstuck " .. n .. " ball(s) — dropped at centre of playfield"
end) end)

-- force-grab for testing without gripping (right/left)
pcall(function() RegisterCommand("finger_grab", function(side)
  arm(); force = true; force_side = (side == "left") and "left" or "right"
  return "force grabbing (" .. force_side .. ")"
end) end)

pcall(function() RegisterCommand("finger_release", function()
  force = false; return "force released (grip still active if armed)"
end) end)

pcall(function() RegisterCommand("finger_status", function()
  local s = get_S(); local cab = get_cabinet(); local n = 0
  if s ~= 0 then each_ball(s, function(_, bs) local x,y = ball_pos(bs); if not is_parked(x,y) then n = n+1 end end) end
  local g = grip_state() or "none"
  return string.format("armed=%s grip=%s grabbing=%s S=0x%X cabinet=%s active_balls=%d gain=%.0f vmax=%.1f",
    tostring(enabled), g, tostring(grabbing), s, cab and cab:GetName() or "none", n, STEER_GAIN, STEER_VMAX)
end) end)

pcall(function() RegisterCommand("finger_grip", function()
  ovr_poll()
  return string.format("OVR grip R=%.3f L=%.3f (ok=%s base=0x%X buf=0x%X mask=0x%X) | state=%s",
    OVR.r or -1, OVR.l or -1, tostring(OVR.ok), OVR.base or 0, OVR.buf or 0, OVR.mask, tostring(grip_state()))
end) end)

pcall(function() RegisterCommand("finger_ovrmask", function(m)
  m = tonumber(m); if m then OVR.mask = m end
  ovr_poll()
  return string.format("mask=0x%X -> R=%.3f L=%.3f connected=0x%X",
    OVR.mask, OVR.r or -1, OVR.l or -1, MemReadU64(OVR.buf) & 0xFFFFFFFF)
end) end)

pcall(function() RegisterCommand("finger_dump", function()
  local s = get_S(); if s == 0 then return "no S (roll a ball first)" end
  local out = {}
  each_ball(s, function(i, bs)
    local x, y, z = ball_pos(bs)
    out[#out+1] = string.format("idx%d bs=0x%X (%.3f,%.3f,%.3f)%s", i, bs, x, y, z, is_parked(x,y) and " [parked]" or "")
  end)
  return table.concat(out, "\n")
end) end)

pcall(function() RegisterCommand("finger_tune", function(gain, vmax)
  gain = tonumber(gain); vmax = tonumber(vmax)
  if gain then STEER_GAIN = gain end
  if vmax then STEER_VMAX = vmax end
  return string.format("gain=%.1f vmax=%.1f", STEER_GAIN, STEER_VMAX)
end) end)

-- ── Hooks: reset caches on table restart ─────────────────────────────────────
local function setup_hooks()
  pcall(function() RegisterHook("GFO_PlayTable_C:OnTableRestart__DelegateSignature",
    function() grabbing = false; cab_cache = nil; EPI.addr = 0 end) end)
  Log(TAG .. ": hooks installed")
end

_G.PFX_FingerMode = {
  enable  = arm,
  disable = disarm,
  -- toggle() flips armed state and RETURNS the new state (bool). PFX_ModMenu's
  -- "Finger Mode" entry calls api.toggle(); without this it silently no-op'd and
  -- the menu switch could never be flipped back. Bidirectional + idempotent.
  toggle  = function()
    if enabled then disarm() else arm() end
    return enabled
  end,
  is_enabled = function() return enabled end,
  is_grabbed = function() return grabbing end,
  unstuck = unstuck,
  grip = grip_state,
  set_local_xform = function(tl, im)
    for i = 1, 3 do T_local[i] = tl[i] end
    for r = 1, 3 do for c = 1, 3 do invM[r][c] = im[(r-1)*3 + c] end end
    return "local xform updated"
  end,
  set_clamp = function(c)
    if c.x then CLAMP.x = c.x end; if c.y then CLAMP.y = c.y end; if c.z then CLAMP.z = c.z end
    return "clamp updated"
  end,
  tune = function(g, v) if g then STEER_GAIN = g end if v then STEER_VMAX = v end end,
  get_S = get_S,
}

install_capture()
ovr_setup()
epi_init()
setup_hooks()
arm()   -- auto-arm: grip-hold works immediately on load, no manual enable needed
Log(TAG .. ": v6.2 loaded + ARMED — HOLD GRIP, free x/y, in-play balls only. bridge: finger_on/off, finger_status, finger_grip, finger_ovrmask, finger_dump, finger_tune")
