-- ============================================================================
-- PFX_NoTilt v3 — UNLIMITED table nudge/shake, the table NEVER goes TILT
-- ============================================================================
-- v1/v2 forced PFXVRTableInfo.TiltSensitivity=0 — which the tilt engine never
-- reads, so it did nothing. This version drives the REAL native tilt manager.
--
-- Reverse-engineered from libUnreal.so (YUP table-script VM). The tilt manager is
-- a 168-byte object (vtable @ RVA 0x6CBB118) with the game's own tilt primitives:
--     disableTiltCounting  ->  mgr.byte[0x4A] = 0     (stop counting nudges)
--     enableTiltCounting   ->  mgr.byte[0x4A] = 1
--     resetTiltCounter     ->  mgr.qword[0x50] = 0    (the "danger" counter)
--     isTiltReached()      ->  return limit(0x58) >= 1 && counter(0x50) >= limit
--     ball-start re-arm     ->  counter=0, 0x4A=1, 0x48=1  (sub_4908AD0, vtable[20])
--
-- So "3 dangers then TILT" = counter climbs on hard nudges; when counter>=limit
-- the table tilts out. We do EXACTLY what a table script does to suppress tilt
-- (disableTiltCounting + resetTiltCounter) — continuously — so it can never fire.
-- These are the game's own operations => zero glitch risk, no code patching.
--
-- We capture the live tilt-mgr by hooking its init (per table) + re-arm (per ball),
-- both of which pass the mgr in x0; validated against its vtable.
-- ============================================================================
local TAG = "PFX_NoTilt"
Log(TAG .. ": loading v3 — real native tilt-manager suppression")

-- Reload generation: old LoopAsync callbacks self-terminate on hot-reload.
_G._NOTILT_GEN = (_G._NOTILT_GEN or 0) + 1
local MY_GEN = _G._NOTILT_GEN

-- ── Offsets (libUnreal.so RVAs; idb imagebase=0 so runtime = base + RVA) ─────
local RVA_INIT    = 0x4908090   -- tilt-mgr init  (vtable[8]);  x0=mgr, per table
local RVA_REARM   = 0x4908AD0   -- tilt-mgr re-arm(vtable[20]); x0=mgr, per ball
local RVA_CHECK   = 0x49089F8   -- tilt-mgr isTiltReached (vtable[17]); x0=mgr, during play
local RVA_VTABLE  = 0x6CBB118   -- tilt-mgr vtable (validates a captured mgr)
local OFF_ENAQ    = 0x48        -- qword: +48 enabled, +49 latch, +4A counting...
local MASK_CLR_4A = 0xFFFFFFFFFF00FFFF  -- clears only the +0x4A byte (counting)
local OFF_COUNTER = 0x50        -- qword: the tilt/"danger" counter
local OFF_LIMIT   = 0x58        -- qword: tilt limit (counter>=limit => tilt)

-- ── WPC/Williams ROM plumb-bob tilt ─────────────────────────────────────────
-- The tilt-mgr above is the HOST tilt (Zen tables). On real Williams/Bally ROM
-- tables the DANGER/TILT is the emulated machine's mechanical plumb-bob SWITCH,
-- which the host tilt-mgr can't touch. sub_4A2524C is the native switch-setter
-- into the emulator: a2+0 = WPC switch number (int), a2+4 = on/off (byte). We keep
-- the plumb-bob — WPC-standard switch #14 — OPEN, so the ROM never counts a tilt
-- warning. Race-proof (the counter lives in guest RAM and the ROM increments+checks
-- it faster than any Lua pin; this stops it at the source). Verified live: switch
-- #14 fired exactly once per DANGER, 3 -> TILT.
local RVA_SWSET = 0x4A2524C
local SIG_SWSET = "11 F5 F7 D0 31 32 0C 91 20 02 1F D6 0C 00 80 12 2D 10 40 39 28 7D 28 9B 0A FD 7F D3"
local TILT_SW   = 14

local ENABLED = true            -- default ON: tilt suppressed (unlimited nudge)

-- ── base + unharden (prefer PFX_0_Core; fall back if it isn't loaded) ────────
local function base()
  if _G.PFXCore then return _G.PFXCore.base() end
  local b = YUP.GetLibBase(); return (type(b) == "number") and b or PtrToInt(b)
end
local function unharden()
  if _G.PFXCore then _G.PFXCore.unharden()
  else pcall(function() CallNativeBySymbol("prctl", "iuuuuu", 4, 1, 0, 0, 0) end) end
end

local function valid_mgr(m)
  if not m or m == 0 then return false end
  local vp = 0; local ok = pcall(function() vp = MemReadU64(m) end)
  return ok and vp == base() + RVA_VTABLE
end

-- ── Capture the live tilt manager (x0 of init / re-arm) ─────────────────────
-- Per-hook registry so hot-reloads only add hooks that aren't already installed.
_G._NOTILT_HOOKS = _G._NOTILT_HOOKS or {}
local function hook_once(rva, name, fn)
  if _G._NOTILT_HOOKS[name] then return end
  local ok = false
  pcall(function() ok = RegisterNativeHookAt(IntToPtr(base() + rva), name, fn, nil) end)
  if ok ~= false then _G._NOTILT_HOOKS[name] = true end
  return ok
end

-- One shared byte the NATIVE arg-filter reads each call: 1 = suppress the plumb-bob,
-- 0 = let it through. Lets /notilt_on|off toggle the C++ filter live without
-- reinstalling. malloc'd, tag stripped (TBI-safe for both the C++ read and our write).
local function ensure_enable_byte()
  if _G._NOTILT_EN then return _G._NOTILT_EN end
  local p; pcall(function() p = CallNativeBySymbol("malloc", "pp", 8) end)
  if not p then return 0 end
  local buf = (type(p) == "number") and p or PtrToInt(p)
  local en  = buf & 0x00FFFFFFFFFFFFFF
  pcall(function() MemWriteU8(en, ENABLED and 1 or 0) end)
  _G._NOTILT_EN = en
  return en
end

local function install()
  local function cap(x0)
    pcall(function()
      local m = PtrToInt(x0)
      if valid_mgr(m) then _G._TILTMGR = m end
    end)
  end
  -- isTiltReached fires during active play => captures the mgr instantly even if
  -- we loaded mid-table; it also gates suppression right at the decision point.
  local function cap_check(x0)
    pcall(function()
      local m = PtrToInt(x0)
      if valid_mgr(m) then
        _G._TILTMGR = m
        -- pin at the exact moment the game asks "is it tilted?" — counter/limit 0
        if ENABLED then
          if MemReadU64(m + OFF_COUNTER) ~= 0 then MemWriteU64(m + OFF_COUNTER, 0) end
          if MemReadU64(m + OFF_LIMIT) ~= 0 then MemWriteU64(m + OFF_LIMIT, 0) end
        end
      end
    end)
  end
  hook_once(RVA_REARM, "notilt_rearm", cap)
  hook_once(RVA_INIT,  "notilt_init",  cap)
  hook_once(RVA_CHECK, "notilt_check", cap_check)

  -- WPC/Williams ROM plumb-bob: PURE-C++ arg-filter on the native switch-setter.
  -- On each call: if switch number (a2+0) == TILT_SW, zero the on/off byte (a2+4)
  -- so switch #14 never closes -> the ROM never registers a tilt. This is a HOT,
  -- often-NESTED function; it only became crash-safe after the modloader's hook
  -- guard was made re-entrant (native_hooks dispatch_full save/restore). Use the
  -- RVA directly (the switch-setter is a normal function; the earlier "sig" was a
  -- Dobby trampoline captured while hooked, so don't trust it). Gated by the enable
  -- byte for /notilt_on|off.
  if not _G._NOTILT_HOOKS["notilt_swset"] and rawget(_G, "RegisterNativeArgFilter") then
    local en = ensure_enable_byte()
    local ok = false
    pcall(function()
      ok = RegisterNativeArgFilter(IntToPtr(base() + RVA_SWSET), "notilt_swset", 1, 0, TILT_SW, 4, 1, IntToPtr(en))
    end)
    if ok then _G._NOTILT_HOOKS["notilt_swset"] = true end
    Log(TAG .. ": WPC plumb-bob(#14) native filter = " .. tostring(ok))
  end
  Log(TAG .. ": tilt-mgr capture hooks: rearm/init/check")
end

-- ── The suppression: mirror disableTiltCounting + resetTiltCounter each tick ─
local function suppress()
  -- keep the native WPC plumb-bob filter's enable byte in sync with ENABLED
  if _G._NOTILT_EN then pcall(function() MemWriteU8(_G._NOTILT_EN, ENABLED and 1 or 0) end) end
  local m = _G._TILTMGR
  if not (ENABLED and valid_mgr(m)) then return end
  pcall(function()
    -- disableTiltCounting: clear only the +0x4A counting-enabled byte
    local q = MemReadU64(m + OFF_ENAQ)
    local q2 = q & MASK_CLR_4A
    if q2 ~= q then MemWriteU64(m + OFF_ENAQ, q2) end
    -- resetTiltCounter: keep the danger counter pinned at 0
    if MemReadU64(m + OFF_COUNTER) ~= 0 then MemWriteU64(m + OFF_COUNTER, 0) end
    -- belt & suspenders: limit 0 => isTiltReached() is always false
    if MemReadU64(m + OFF_LIMIT) ~= 0 then MemWriteU64(m + OFF_LIMIT, 0) end
  end)
end

unharden()
install()
LoopAsync(120, function()
  if _G._NOTILT_GEN ~= MY_GEN then return true end   -- superseded by a reload
  unharden(); suppress()
  return false
end)

-- ── Bridge commands ─────────────────────────────────────────────────────────
pcall(function() RegisterCommand("notilt_off", function()
  ENABLED = true; return TAG .. ": TILT SUPPRESSED — nudge/shake all you want"
end) end)
pcall(function() RegisterCommand("notilt_on", function()
  ENABLED = false; return TAG .. ": tilt RESTORED to game default"
end) end)
pcall(function() RegisterCommand("notilt_status", function()
  local m = _G._TILTMGR or 0
  local ok = valid_mgr(m)
  local cnt, lim, en = -1, -1, -1
  if ok then pcall(function()
    cnt = MemReadU64(m + OFF_COUNTER); lim = MemReadU64(m + OFF_LIMIT)
    en  = (MemReadU64(m + OFF_ENAQ) >> 16) & 0xFF
  end) end
  return string.format("%s: suppress=%s mgr=0x%X valid=%s | counter=%d limit=%d counting=%d",
    TAG, tostring(ENABLED), m, tostring(ok), cnt, lim, en)
end) end)

_G.PFX_NoTilt = {
  set_enabled = function(v) ENABLED = v and true or false end,
  mgr = function() return _G._TILTMGR or 0 end,
}

Log(TAG .. ": v3 ready — capturing native tilt-mgr; nudge freely, no tilt-out")
