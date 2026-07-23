-- ============================================================================
-- PFX_OperatorMenu v1 — Williams ROM coin-door / operator-menu / debug access
-- ============================================================================
-- The emulated Williams machines in PFX VR are full PinMAME cores and the
-- native machine classes ("WPCROM" registrar sub_4A23700, "PinMAME" registrar
-- sub_4A17AEC) expose the REAL cabinet inputs the game itself never uses:
--
--   • CoinDoorSwitches  — the dedicated coin-door switch column:
--       WPC:  sub_4A252A8(machine,&{i32 sw,u8 on}) -> bit 1<<(sw-1) @ m+25181
--             sw 1..4 = coin chutes,  5 = Service ESCAPE,  6 = Service DOWN(-),
--             7 = Service UP(+),      8 = Service ENTER / BEGIN TEST
--       S11:  sub_4A199A4(machine,&{i32 sw,u8 on}) -> core setter sub_49C1BF0
--   • Switches (matrix)  — WPC sub_4A2524C (the NoTilt-filtered setter),
--                          S11 sub_4A19900. Used here for probing (op_matrix).
--   • ToggleDebugDisplay — WPC sub_4A2531C (flips m+303296),
--                          S11 sub_4A199CC (flips m+1640)
--   • ShowDebugText/ClearDebugText (S11) — 128-char UTF-16 overlay @ m+10352
--   • PlaySound (WPC)    — sub_4A25310(machine,&u16): raw sound-board command
--   • YUPCheatManager.ToggleROMDebug — flips GLOBAL byte @ base+0x743D7F0
--
-- Pressing Service ENTER (coin-door sw 8) on a WPC table enters the ROM's OWN
-- operator/service menu on the DMD (tests, adjustments, audits — the real
-- thing). ESCAPE exits, +/- navigate, ENTER selects.
--
-- Machine objects are captured PURE-C++ (RegisterNativeCapture) from the hot
-- switch setters — NEVER a Lua callback there (shared-lua_State race, see
-- PFX_ScoreControl header). install_at() chains registrants, so coexisting
-- with PFX_NoTilt's ArgFilter on the same WPC setter is safe (one Dobby hook).
-- ============================================================================
local TAG = "PFX_OperatorMenu"
Log(TAG .. ": loading v1")

_G._OPM_GEN = (_G._OPM_GEN or 0) + 1
local MY_GEN = _G._OPM_GEN

-- ── Signatures (unique, IDA-verified) + current-build RVA fallback ──────────
local SIG = {
  wpc_swset     = { "E8 CC 8C 52 29 00 40 B9 C8 CC AC 72 0C 00 80 12 2D 10 40 39 28 7D 28 9B", 0x4A2524C },
  wpc_coindoor  = { "A8 4B 8C 52 29 00 40 B9 2C 10 40 39 2B 00 80 52 0A 68 68 38 29 05 00 51", 0x4A252A8 },
  wpc_dbgtoggle = { "08 18 94 52 88 00 A0 72 09 68 68 38 29 01 00 52 09 68 28 38 C0 03 5F D6", 0x4A2531C },
  wpc_playsound = { "00 C0 03 91 21 00 40 79 DD B4 FF 17", 0x4A25310 },
  s11_swset     = { "FD 7B BE A9 F4 4F 01 A9 FD 03 00 91 F4 03 01 AA F3 03 00 AA 00 78 40 F9 21 00 40 B9 8B A0 FE 97", 0x4A19900 },
  s11_coindoor  = { "28 00 40 B9 00 78 40 F9 22 10 40 39 E1 03 08 2A 8F A0 FE 17 28 00 40 B9", 0x4A199A4 },
  s11_dbgtoggle = { "08 A0 59 39 08 01 00 52 08 A0 19 39 C0 03 5F D6", 0x4A199CC },
  s11_dbgtext   = { "FD 7B BE A9 F3 0B 00 F9 FD 03 00 91 28 00 40 F9 F3 03 00 AA 68 01 00 B4 89 0E 85 52", 0x4A19B70 },
  s11_dbgclear  = { "1F 70 28 B9 C0 03 5F D6 09 78 40 F9 28 00 80 52", 0x4A19BC4 },
}
local RVA_ROMDBG = 0x743D7F0     -- global ROM-debug flag byte (data; gated draw)
local WPC_COINBYTE = 25181       -- WPC machine coin-door switch byte (release-all)

-- ── base / unharden / heap / resolve (PFXCore optional) ─────────────────────
local function base()
  if _G.PFXCore then return _G.PFXCore.base() end
  local b = YUP.GetLibBase(); return (type(b) == "number") and b or PtrToInt(b)
end
local function unharden()
  if _G.PFXCore then _G.PFXCore.unharden()
  else pcall(function() CallNativeBySymbol("prctl", "iuuuuu", 4, 1, 0, 0, 0) end) end
end
-- Game native heap floor. Was 0x7000000000, but the heap's base VARIES per launch
-- (ASLR + memory pressure): this session it landed at 0x6F.. (verified S/machine at
-- 0x6f21e04000-0x6f27215000), which a 0x70 floor wrongly rejected → nothing captured.
-- 0x60 covers the observed 0x6F–0x7F game heap; the vtable check (machine_ok) is the
-- real validator, so a looser sanity floor only ever costs a cheap rejected read.
local HEAP_LO, HEAP_HI = 0x6000000000, 0x8000000000
local function heap(p) return p and p > HEAP_LO and p < HEAP_HI end
local function resolve(name)
  local s = SIG[name]
  if _G.PFXCore and _G.PFXCore.resolve then return _G.PFXCore.resolve(name, s[1], s[2]) end
  return base() + s[2]
end

-- ── State ────────────────────────────────────────────────────────────────────
_G._OPM = _G._OPM or { wpc = 0, s11 = 0, cap = 0, buf = 0, presses = 0 }
local ST = _G._OPM

-- capture slots (8B each) + 4 rotating 16B arg slots + 272B text block
local function alloc_bufs()
  if ST.cap ~= 0 and ST.buf ~= 0 then return true end
  local ok = pcall(function()
    if ST.cap == 0 then
      local p = CallNativeBySymbol("malloc", "pp", 16)
      ST.cap  = (type(p) == "number") and p or PtrToInt(p)
      ST.capr = ST.cap & 0x00FFFFFFFFFFFFFF
      MemWriteU64(ST.capr, 0); MemWriteU64(ST.capr + 8, 0)
    end
    if ST.buf == 0 then
      local p = CallNativeBySymbol("malloc", "pp", 512)
      ST.buf  = (type(p) == "number") and p or PtrToInt(p)
      ST.bufr = ST.buf & 0x00FFFFFFFFFFFFFF
    end
  end)
  return ok and ST.cap ~= 0 and ST.buf ~= 0
end

local function install()
  -- Gate on MY_GEN, not a bare bool: ST persists in _G across a hot-reload, so a
  -- plain `if ST.hooked` would skip re-registration after a reload — leaving the
  -- OLD capture closure (old heap range / freed slot) live and the reload a no-op.
  -- Keying on the reload generation forces one clean re-arm per (re)load.
  if ST.hooked == MY_GEN then return end
  if not alloc_bufs() then Log(TAG .. ": buffer alloc FAILED — disabled"); return end
  local function cap(addr, name, slot)
    local ok = false
    pcall(function()
      ok = RegisterNativeCapture(IntToPtr(addr), name, 0, IntToPtr(slot), HEAP_LO, HEAP_HI)
    end)
    return ok ~= false
  end
  cap(resolve("wpc_swset"), "opm_wpc", ST.capr)      -- x0 = WPC machine
  cap(resolve("s11_swset"), "opm_s11", ST.capr + 8)  -- x0 = PinMAME machine
  ST.hooked = MY_GEN
  Log(TAG .. ": capture hooks armed (WPC + S11 switch setters, pure C++)")
end

-- A machine ptr is trusted only if its first field reads as a live pointer —
-- either into the module image (a C++ vtable) OR into the game heap (an owned
-- sub-object). A freed/reused chunk's first qword is ~never a valid pointer, so
-- this still rejects stale slots across table switches, but it won't false-reject
-- a machine whose layout doesn't start with a module vtable (CallNative is
-- crash-guarded regardless, so erring permissive is safe).
local function machine_ok(m)
  if not heap(m) then return false end
  local first = 0
  local ok = pcall(function() first = MemReadU64(m) end)
  if not ok then return false end
  local b = base()
  local inmod = first > b and first < b + 0x8000000
  return inmod or heap(first)
end
local function refresh()
  if ST.capr then
    pcall(function()
      local w = MemReadU64(ST.capr);     if heap(w) then ST.wpc = w end
      local s = MemReadU64(ST.capr + 8); if heap(s) then ST.s11 = s end
    end)
  end
end
-- returns machine, "WPC"|"S11" — WPC preferred when both look alive (the live
-- table repopulates its slot on every switch event; the stale one fails the
-- vtable check the moment its chunk is reused)
local function machine()
  refresh()
  if machine_ok(ST.wpc) then return ST.wpc, "WPC" end
  if machine_ok(ST.s11) then return ST.s11, "S11" end
  return nil, "none (play/flip on a Williams table first)"
end

-- ── switch press/release ─────────────────────────────────────────────────────
-- arg slot layout: {i32 switchNum @0, u8 on @4}; 4 rotating slots @ buf+0..63
local function argslot()
  ST.presses = (ST.presses + 1) % 4
  return ST.buf + 16 * ST.presses, ST.bufr + 16 * ST.presses
end
-- ── WPC operator-menu control (direct memory PIN — beats the per-frame sync) ──
-- CRACKED from the TAF ROM's own switch-name table (anchored by sw14=PLUMB BOB
-- TILT, which NoTilt confirms): the emulated WPC ROM gates its service menu on
-- the "COIN DOOR CLOSED" switch = **sw21** = matrix byte machine+25186 bit0. The
-- service BUTTONS are the cabinet byte machine+25181: coins bits0-3, ESCAPE bit4,
-- DOWN bit5, UP bit6, ENTER bit7. The game re-syncs these every frame, so a
-- one-shot write is stomped — we PIN the door open every frame while operator
-- mode is on, and TAP a button by pinning its bit ~180ms. Entering the menu
-- HALTS play (authentic WPC behaviour) — use it in attract / between games.
local COIN_BYTE = 25181
local DOOR_BYTE = 25186          -- sw21 lives here (WPC col 2 = m+25185+1)
local DOOR_BIT  = 0x01           -- sw21 bit0 = COIN DOOR CLOSED
-- door-open polarity: sw21 reads 0 while the ROM shows "door closed", so the
-- OPEN state is the opposite (SET). Flip if a build proves inverted.
local DOOR_OPEN_SET = true
local BTN = { enter = 0x80, up = 0x40, down = 0x20, escape = 0x10, coin = 0x01 }

local function wpc_live() return machine_ok(ST.wpc) end
local function door_write(open)
  if not wpc_live() then return end
  pcall(function()
    local v = MemReadU64(ST.wpc + DOOR_BYTE) & 0xFF
    local want = (open == DOOR_OPEN_SET) and (v | DOOR_BIT) or (v & (~DOOR_BIT & 0xFF))
    MemWriteU8(ST.wpc + DOOR_BYTE, want)
  end)
end

-- Persistent "operator mode": hold the coin door OPEN every frame so the ROM's
-- service buttons work. One gen-guarded loop; toggling off releases the door.
local function set_door(on)
  ST.door_on = on and true or false
  if ST.door_on then unharden() end
  if ST.door_on and not ST.door_loop then
    ST.door_loop = true
    LoopAsync(1, function()
      if _G._OPM_GEN ~= MY_GEN or not ST.door_on then
        door_write(false)                    -- release (door "closed") on exit
        ST.door_loop = false
        return true
      end
      door_write(true)                        -- pin door OPEN
      return false
    end)
  end
  return ST.door_on
end

-- Tap a cabinet service button (~180ms), auto-holding the door open first.
local function tap(name)
  if not wpc_live() then return false, "no WPC machine (play a Williams table)" end
  local bit = BTN[name]; if not bit then return false, "unknown button " .. tostring(name) end
  unharden()
  set_door(true)                              -- ensure the door is held open
  local held = 0
  LoopAsync(1, function()
    held = held + 1
    if not wpc_live() then return true end
    pcall(function()
      local v = MemReadU64(ST.wpc + COIN_BYTE) & 0xFF
      -- one clean press: assert ~90ms, then release + hold released a few frames
      -- so the ROM sees a single edge (a longer hold auto-repeats and over-steps).
      if held <= 9 then v = v | bit else v = v & (~bit & 0xFF) end
      MemWriteU8(ST.wpc + COIN_BYTE, v)
    end)
    return held > 16
  end)
  return true, name .. " tapped (door held open)"
end

-- panic: release the door AND all cabinet buttons
local function release_all()
  if not wpc_live() then return false, "no WPC machine" end
  set_door(false)
  pcall(function() MemWriteU8(ST.wpc + COIN_BYTE, 0) end)
  return true, "coin door released + buttons cleared"
end

-- ── debug displays ───────────────────────────────────────────────────────────
local function toggle_debug()
  local m, cls = machine()
  if not m then return false, cls end
  unharden()
  local fn = (cls == "WPC") and "wpc_dbgtoggle" or "s11_dbgtoggle"
  local ok = pcall(function() CallNative(IntToPtr(resolve(fn)), "vp", IntToPtr(m)) end)
  return ok, cls .. " debug display toggled"
end
local function toggle_romdbg()
  unharden()
  local a = base() + RVA_ROMDBG
  local v = 0
  pcall(function() v = MemReadU64(a) & 0xFF end)
  pcall(function() MemWriteU8(a, (v ~ 1) & 1) end)
  return true, "global ROM-debug flag -> " .. tostring((v ~ 1) & 1)
end
-- S11 overlay text (128 UTF-16 chars max). GLUcs2 param = {u16* @0, u32 len @8}
local function debug_text(txt)
  local m, cls = machine()
  if not m then return false, cls end
  if cls ~= "S11" then return false, "ShowDebugText exists on S11 machines only" end
  txt = tostring(txt or ""):sub(1, 127)
  unharden()
  if #txt == 0 then                                      -- clear: (machine) only
    local ok = pcall(function()
      CallNative(IntToPtr(resolve("s11_dbgclear")), "vp", IntToPtr(m))
    end)
    return ok, "overlay cleared"
  end
  local strp, strr = ST.buf + 64, ST.bufr + 64           -- utf16 buffer (256B)
  for i = 1, #txt do
    MemWriteU8(strr + (i - 1) * 2, txt:byte(i)); MemWriteU8(strr + (i - 1) * 2 + 1, 0)
  end
  MemWriteU8(strr + #txt * 2, 0); MemWriteU8(strr + #txt * 2 + 1, 0)  -- u16 NUL
  local prm, prmr = ST.buf + 336, ST.bufr + 336          -- GLUcs2 {u16* @0, u32 len @8}
  MemWriteU64(prmr, strp); MemWriteU64(prmr + 8, #txt)
  local ok = pcall(function()
    CallNative(IntToPtr(resolve("s11_dbgtext")), "vpp", IntToPtr(m), IntToPtr(prm))
  end)
  return ok, "overlay: " .. txt
end
-- WPC raw sound-board command (per-ROM ids; probe with op_sound <n>)
local function play_sound(idx)
  local m, cls = machine()
  if not m then return false, cls end
  if cls ~= "WPC" then return false, "PlaySound exists on WPC machines only" end
  unharden()
  local a, ar = argslot()
  MemWriteU64(ar, idx & 0xFFFF)
  local ok = pcall(function()
    CallNative(IntToPtr(resolve("wpc_playsound")), "vpp", IntToPtr(m), IntToPtr(a))
  end)
  return ok, string.format("%s sound cmd 0x%X", cls, idx & 0xFFFF)
end

unharden()
install()
LoopAsync(1500, function()
  if _G._OPM_GEN ~= MY_GEN then return true end
  unharden(); install(); refresh()
  return false
end)

-- ── Public API (menu / other mods) ──────────────────────────────────────────
_G.PFX_Operator = {
  -- Operator mode: hold the coin door OPEN so the ROM's service buttons work.
  -- Toggling ON then tapping ENTER opens the real WPC operator menu (halts play).
  door        = set_door,                    -- set_door(true/false)
  door_toggle = function() return set_door(not ST.door_on) end,
  door_on     = function() return ST.door_on == true end,
  -- WPC service buttons — tap (door auto-held open)
  enter  = function() return tap("enter")  end,   -- ENTER / BEGIN TEST
  up     = function() return tap("up")     end,   -- + / navigate up
  down   = function() return tap("down")   end,   -- - / navigate down
  escape = function() return tap("escape") end,   -- ESCAPE / back / exit
  coin   = function() return tap("coin")   end,   -- insert a coin
  tap          = tap,
  release_all  = release_all,
  toggle_debug = toggle_debug,               -- per-machine emulator debug display
  toggle_romdbg= toggle_romdbg,              -- global YUP ROM-debug flag
  debug_text   = debug_text,                 -- S11 DMD overlay text ("" clears)
  play_sound   = play_sound,                 -- WPC sound-board command
  mode   = function() local _, c = machine(); return c end,
  ready  = function() local m = machine(); return m ~= nil end,
}

-- ── Bridge commands ─────────────────────────────────────────────────────────
local API = _G.PFX_Operator
local function r(okmsg) return TAG .. ": " .. tostring(select(2, okmsg())) end
pcall(function() RegisterCommand("op_status", function()
  refresh()
  return string.format("%s: mode=%s wpc=0x%X s11=0x%X wpc_ok=%s s11_ok=%s",
    TAG, API.mode(), ST.wpc or 0, ST.s11 or 0,
    tostring(machine_ok(ST.wpc)), tostring(machine_ok(ST.s11)))
end) end)
pcall(function() RegisterCommand("op_door",   function() return TAG..": coin door "..(set_door(not ST.door_on) and "OPEN (held)" or "closed") end) end)
pcall(function() RegisterCommand("op_enter",  function() return r(API.enter)  end) end)
pcall(function() RegisterCommand("op_up",     function() return r(API.up)     end) end)
pcall(function() RegisterCommand("op_down",   function() return r(API.down)   end) end)
pcall(function() RegisterCommand("op_esc",    function() return r(API.escape) end) end)
pcall(function() RegisterCommand("op_coin",   function() return r(API.coin)   end) end)
-- probe helper: flip the door-open polarity if a build proves inverted
pcall(function() RegisterCommand("op_release",function() return r(API.release_all) end) end)
pcall(function() RegisterCommand("op_dbg",    function() return r(API.toggle_debug) end) end)
pcall(function() RegisterCommand("op_romdbg", function() return r(API.toggle_romdbg) end) end)
pcall(function() RegisterCommand("op_text",   function(a) return TAG..": "..tostring(select(2, debug_text(a or ""))) end) end)
pcall(function() RegisterCommand("op_sound",  function(a) return TAG..": "..tostring(select(2, play_sound(tonumber(a) or 1))) end) end)

Log(TAG .. ": v2 ready — WPC operator menu via sw21 (COIN DOOR CLOSED). op_door (toggle hold-open), op_enter/up/down/esc/coin, op_release, op_dbg. Open from attract/game-over (opening it halts play, authentic WPC).")
