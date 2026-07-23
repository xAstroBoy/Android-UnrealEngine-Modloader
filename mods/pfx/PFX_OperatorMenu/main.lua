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
  ST.bind_on = false
  pcall(function() MemWriteU8(ST.wpc + COIN_BYTE, 0) end)
  return true, "coin door released + buttons cleared"
end

-- ── Quest controller binding ─────────────────────────────────────────────────
-- Drive the WPC service buttons with the PHYSICAL Touch controllers so the
-- operator menu is navigable in-headset (no bridge). The service buttons are the
-- cabinet byte's high nibble (ENTER=b7, UP=b6, DOWN=b5, ESCAPE=b4) and are the
-- SAME on every WPC game, so this is table-agnostic. Mapping (right hand):
--   A = ENTER / Begin Test   B = ESCAPE / back   R-stick ↑ = + (up)   ↓ = − (down)
-- We MIRROR the held state each frame: holding a button holds the switch, so the
-- ROM sees the ~24-frame hold Begin Test needs, and +/- auto-repeat while held.
-- Raw OVRPlugin poll from the game thread (same technique as PFX_FingerMode's grip
-- reader — CALLED not hooked). ONE gen-guarded loop; never stacks (no lag).
local OVR = { base = 0, buf = 0, rbuf = 0, ok = false }
local PTR_MASK = 0x00FFFFFFFFFFFFFF
local OVR_GS6  = 0x176C40          -- ovrp_GetControllerState6 in libOVRPlugin.so
-- ovrControllerState6: Buttons@+4(u32), IndexTrigger[0/1]@+16/+20, HandTrigger[1]@+28,
-- Thumbstick[1]@+40(x)/+44(y).
local OVR_BTN      = 4
local OVR_RSTICK_Y = 44        -- Thumbstick[1].y (right stick vertical)
local BTN_A      = 0x00000001  -- right A            → ESCAPE (B is the game's PAUSE button, avoid it)
local BTN_RTHUMB = 0x00000004  -- right stick CLICK  → ENTER
local BTN_X      = 0x00000100  -- left X button      → START button (WPC "help page" in service menus)
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
  f:close(); OVR.base = b or 0; return OVR.base
end
local function ovr_setup()
  if OVR.ok then return true end
  if ovr_base() == 0 then return false end
  if OVR.buf == 0 then
    local p; pcall(function() p = CallNativeBySymbol("malloc", "pp", 512) end)
    if p then OVR.buf = (type(p) == "number") and p or PtrToInt(p) end
  end
  if not OVR.buf or OVR.buf == 0 then return false end
  OVR.rbuf = OVR.buf & PTR_MASK
  OVR.ok = true
  return true
end
local function ovr_poll()
  if not ovr_setup() then return nil end
  pcall(function() CallNative(IntToPtr(OVR.base + OVR_GS6), "iup", 0x03, IntToPtr(OVR.buf)) end)
  local btn = MemReadU64(OVR.rbuf + OVR_BTN) & 0xFFFFFFFF   -- Buttons u32 (low 32 of the qword @+4)
  local sy  = MemReadFloat(OVR.rbuf + OVR_RSTICK_Y)         -- right thumbstick Y
  return btn, sy
end

-- ── Auto-detect the coin-door switch from the ROM (works on ANY WPC game) ────
-- Finds "COIN DOOR CLOSED" in the emulated ROM, locates its slot in the switch-
-- name pointer table, and derives the emulator switch byte+bit. Polarity is
-- auto-sensed: the game drives the door "closed" every frame, so OPEN = the
-- opposite value. One-time, cached in ST.cd = {byte,bit,openval} (or false).
-- (TAF=sw21=m+25186 b0 set-open; this '92 game=sw22=m+25186 b1 clear-open — both
--  fall straight out of this, no per-table constants.)
-- Core: resolve a NAMED switch's matrix {byte,bit,sw} from the emulated ROM's own
-- switch-name pointer table (idx: [0]hdr [1]INVALID [2..9]=D1-D8 [10]=sw11 …).
-- Table-agnostic — the same routine drives the coin door AND the start button.
-- (Validated offline on the CFTBL dump: START BUTTON→sw13, SLAM TILT→sw21,
--  COIN DOOR CLOSED→sw22, ALWAYS CLOSED→sw24 — all matched the live matrix.)
local function find_named_switch(tgt)
  if not wpc_live() then return nil end
  local ok, res = pcall(function()
    local rb = MemReadU64(ST.wpc + 248 + 24880) & 0x00FFFFFFFFFFFFFF
    if rb < 0x6000000000 then return nil end
    local hp = {}; for i=1,#tgt do hp[#hp+1]=string.format("%02x",tgt:byte(i)) end; hp=table.concat(hp)
    local soff; local prev=""; local pos=0; local SIZE=0x80000; local keep=(#tgt-1)*2
    while pos<SIZE do
      local n=math.min(0x1000,SIZE-pos); local h=MemReadBytes(rb+pos,n); if not h then break end
      local hy=prev..h; local base=pos-(#prev//2); local a=hy:find(hp,1)
      if a and (a-1)%2==0 then soff=base+(a-1)//2; break end
      prev=(#hy>=keep) and hy:sub(#hy-keep+1) or hy; pos=pos+n
    end
    if not soff then return nil end
    local guest = 0x4000 + (soff & 0x3FFF); local bank = soff >> 14
    local bh={}; for c=0,0x3000,0x1000 do local h=MemReadBytes(rb+(bank<<14)+c,0x1000); bh[#bh+1]=h or "" end
    bh=table.concat(bh)
    local function w16(bytepos) return (tonumber(bh:sub(bytepos*2+1,bytepos*2+2),16)<<8)|tonumber(bh:sub(bytepos*2+3,bytepos*2+4),16) end
    local pstr=string.format("%04x",guest); local cand; local s=1
    while true do
      local a=bh:find(pstr,s); if not a then break end
      if (a-1)%2==0 then
        local bp=(a-1)//2; local good=0
        for _,d in ipairs({-4,-2,2,4}) do local q=bp+d; if q>=0 and q*2+4<=#bh then local w=w16(q); if w>=0x4000 and w<=0x7FFF then good=good+1 end end end
        if good>=3 then cand=bp; break end
      end
      s=a+1
    end
    if not cand then return nil end
    local start=cand
    while start-2>=0 and w16(start-2)>=0x4000 and w16(start-2)<=0x7FFF do start=start-2 end
    local idx=(cand-start)//2
    local linear=idx-9
    if linear<1 then return nil end
    local col=(linear-1)//8+1; local row=(linear-1)%8+1
    return { byte=25184+col, bit=(1<<(row-1)), sw=col*10+row }
  end)
  return (ok and res) or nil
end

-- Coin door: name-table lookup + polarity auto-sense (the game drives it "closed"
-- every frame, so OPEN = the opposite value). Cached in ST.cd={byte,bit,openval,sw}.
local function detect_coindoor()
  if ST.cd ~= nil then return ST.cd or nil end
  local res = find_named_switch("COIN DOOR CLOSED")
  if res then
    local cur = MemReadU8(ST.wpc + res.byte) & res.bit    -- game-driven (closed) value
    res.openval = (cur ~= 0) and 0 or res.bit             -- OPEN = the opposite
    ST.cd = res
    Log(TAG..string.format(": coin door = sw%d (m+%d bit0x%02X, open=%s)", res.sw, res.byte, res.bit, res.openval==0 and "clear" or "set"))
    return res
  end
  ST.cd = false
  Log(TAG..": coin-door auto-detect failed")
  return nil
end

-- START BUTTON (matrix switch, momentary N.O. — closed = pressed). In the WPC
-- service menus, pressing START shows the HELP page for the current item.
-- Cached in ST.start = {byte,bit,sw} (or false if not found).
local function detect_start()
  if ST.start ~= nil then return ST.start or nil end
  local res = find_named_switch("START BUTTON")
  if res then
    ST.start = res
    Log(TAG..string.format(": start button = sw%d (m+%d bit0x%02X)", res.sw, res.byte, res.bit))
    return res
  end
  ST.start = false
  Log(TAG..": start-button auto-detect failed")
  return nil
end
-- pin the auto-detected coin door OPEN (one write; used by the bind loop each frame)
local function door_hold_open()
  local cd = detect_coindoor(); if not cd then return end
  pcall(function()
    local v = MemReadU8(ST.wpc + cd.byte)
    v = (cd.openval ~= 0) and (v | cd.bit) or (v & (~cd.bit & 0xFF))
    MemWriteU8(ST.wpc + cd.byte, v)
  end)
end

-- Tap the START button (matrix switch) once → brings up the WPC HELP page for the
-- current service item. Bridge/API helper; the left-stick binding does this live.
-- Preserves the rest of the column (START shares its byte with other switches).
local function tap_start()
  if not wpc_live() then return false, "no WPC machine (play a Williams table)" end
  local st = detect_start(); if not st then return false, "start button not found in ROM" end
  unharden()
  local held = 0
  LoopAsync(1, function()
    held = held + 1
    if not wpc_live() then return true end
    pcall(function()
      local v = MemReadU8(ST.wpc + st.byte)
      if held <= 9 then v = v | st.bit else v = v & (~st.bit & 0xFF) end
      MemWriteU8(ST.wpc + st.byte, v)
    end)
    return held > 16
  end)
  return true, string.format("START (sw%d) tapped — help page", st.sw)
end

-- Persistent controller-binding mode. While on, each frame maps the Touch buttons
-- to the service-button bits of the cabinet byte (preserving the coin bits).
local function bind_controls(on)
  ST.bind_on = on and true or false
  if ST.bind_on then unharden(); ovr_setup(); detect_coindoor(); detect_start() end
  if ST.bind_on and not ST.bind_loop then
    ST.bind_loop = true
    LoopAsync(1, function()
      if _G._OPM_GEN ~= MY_GEN or not ST.bind_on then
        if wpc_live() then pcall(function()
          MemWriteU8(ST.wpc + COIN_BYTE, MemReadU8(ST.wpc + COIN_BYTE) & 0x0F)  -- drop service bits
          local st = ST.start                                                    -- release START button
          if type(st)=="table" then MemWriteU8(ST.wpc + st.byte, MemReadU8(ST.wpc + st.byte) & (~st.bit & 0xFF)) end
        end) end
        ST.bind_loop = false
        return true
      end
      if not wpc_live() then return false end
      door_hold_open()          -- hold the auto-detected coin door OPEN every frame
      local btn, sy = ovr_poll()
      if btn then
        local bits = 0
        if (btn & BTN_RTHUMB) ~= 0 then bits = bits | BTN.enter  end   -- R-stick CLICK → ENTER / Begin Test
        if (btn & BTN_A)      ~= 0 then bits = bits | BTN.escape end   -- A → ESCAPE / back
        if sy and sy >  0.55 then bits = bits | BTN.up   end           -- R-stick ↑ → + (up)
        if sy and sy < -0.55 then bits = bits | BTN.down end           -- R-stick ↓ → − (down)
        pcall(function()
          local v = MemReadU8(ST.wpc + COIN_BYTE) & 0x0F          -- keep coin bits, set service bits
          MemWriteU8(ST.wpc + COIN_BYTE, v | bits)
        end)
        -- X button (left hand) → START button (matrix switch) → WPC help page. Mirror
        -- the held state onto the START bit, preserving the rest of its column.
        local st = detect_start()
        if st then pcall(function()
          local mv = MemReadU8(ST.wpc + st.byte)
          if (btn & BTN_X) ~= 0 then mv = mv | st.bit else mv = mv & (~st.bit & 0xFF) end
          MemWriteU8(ST.wpc + st.byte, mv)
        end) end
      end
      return false
    end)
  end
  return ST.bind_on
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

-- ── Runtime 6809 ROM AOB-patcher (merged from the old PFX_WPCRomPatch) ───────
-- Patches the emulated WPC ROM IMAGE directly rather than racing the per-frame
-- switch re-sync. romBase = *(machine+248+24880) (512KB); a patch at rom-file
-- offset X writes romBase+X. Signatures are AOB (survive ROM revisions); the scan
-- runs in the HEX domain because MemReadBytes returns hex (see find_named_switch).
local ROM_SIZE = 0x80000
ST.rom_applied = ST.rom_applied or {}
local function rombase()
  if not wpc_live() then return 0 end
  local rb = 0; pcall(function() rb = MemReadU64(ST.wpc + 248 + 24880) end)
  if not heap(rb) then return 0 end
  return rb & 0x00FFFFFFFFFFFFFF
end
local function parse_aob(str)
  local pat, plen = {}, 0
  for tok in str:gmatch("%S+") do
    plen = plen + 1
    if tok == "??" or tok == "?" then pat[#pat+1] = "%x%x"
    else pat[#pat+1] = string.format("%02x", tonumber(tok, 16)) end
  end
  return { plen = plen, lpat = table.concat(pat) }
end
local function rom_scan(p)
  local rb = rombase(); if rb == 0 then return {} end
  local lpat, plen = p.lpat, p.plen
  local hits, CH = {}, 0x1000
  local keep = (plen - 1) * 2                 -- even hex chars = whole-byte overlap
  local prevhex, pos = "", 0
  while pos < ROM_SIZE do
    local n = math.min(CH, ROM_SIZE - pos)
    local h = nil; pcall(function() h = MemReadBytes(rb + pos, n) end)
    if not h then break end
    local hy = prevhex .. h
    local basebyte = pos - (#prevhex // 2)
    local s = 1
    while true do
      local a = hy:find(lpat, s); if not a then break end
      if (a - 1) % 2 == 0 then hits[#hits+1] = basebyte + (a - 1) // 2 end
      s = a + 1
    end
    prevhex = (#hy >= keep) and hy:sub(#hy - keep + 1) or hy
    pos = pos + n
  end
  return hits
end
local function rom_apply(patch)
  if ST.rom_applied[patch.name] then return true, patch.name .. ": already applied" end
  local rb = rombase(); if rb == 0 then return false, "no WPC ROM detected yet" end
  unharden()
  local hits = rom_scan(parse_aob(patch.aob))
  if #hits == 0 then return false, patch.name .. ": signature NOT FOUND" end
  if patch.verify_unique ~= false and #hits ~= 1 then
    return false, string.format("%s: signature matched %d times (want 1) — refusing", patch.name, #hits)
  end
  local off = hits[1]
  local already = true                        -- idempotent: re-detect/reload won't double-apply
  for _, e in ipairs(patch.edits) do
    local cur = 0; pcall(function() cur = MemReadU8(rb + off + e.rel) end)
    if cur == e.to then
    elseif (not e.from) or cur == e.from then already = false
    else return false, string.format("%s: byte@+%d is 0x%02X, expected 0x%02X — NOT patching", patch.name, e.rel, cur, e.from) end
  end
  for _, e in ipairs(patch.edits) do pcall(function() MemWriteU8(rb + off + e.rel, e.to) end) end
  ST.rom_applied[patch.name] = { off = off, at = rb + off }
  return true, string.format("%s: %s at rom 0x%05X", patch.name, already and "already patched" or "patched", off)
end
-- Patch catalog. slam_tilt: force BCS->BRA (bank 0x13 $69D6: BD 6E AE / 25 23 /
-- BD 87 33) so "SLAM TILT SWITCH IS STUCK CLOSED" (msg 0x6E) never blocks boot.
-- OFF by default — apply explicitly (API.apply_slam / bridge wpc_patch_slam).
local ROM_PATCHES = {
  slam_tilt = { name = "slam_tilt_skip", aob = "BD 6E AE ?? 23 BD 87 33", edits = { { rel = 3, from = 0x25, to = 0x20 } } },
}

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
  start       = tap_start,                        -- press START → WPC help page
  press_start = tap_start,
  -- 6809 ROM image AOB-patcher (merged from PFX_WPCRomPatch)
  rombase     = rombase,
  rom_scan    = function(aob) return rom_scan(parse_aob(aob)) end,
  rom_apply   = rom_apply,
  rom_patches = ROM_PATCHES,
  apply_slam  = function() return rom_apply(ROM_PATCHES.slam_tilt) end,
  tap          = tap,
  -- OPERATOR MODE: auto-opens the coin door + binds the Touch controllers so the
  -- ROM's operator menu is accessible & navigable in-headset. Controls:
  --   right stick ↑/↓ = +/−   |   stick CLICK = ENTER   |   A = ESCAPE
  operator_mode        = bind_controls,                       -- operator_mode(true/false)
  operator_toggle      = function() return bind_controls(not ST.bind_on) end,
  operator_on          = function() return ST.bind_on == true end,
  bind                 = bind_controls,                       -- (aliases, back-compat)
  bind_toggle          = function() return bind_controls(not ST.bind_on) end,
  bind_on              = function() return ST.bind_on == true end,
  coindoor             = detect_coindoor,                     -- returns {byte,bit,openval,sw}
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
pcall(function() RegisterCommand("op_start",  function() return r(API.start)  end) end)
-- 6809 ROM AOB-patcher (merged PFX_WPCRomPatch)
pcall(function() RegisterCommand("wpc_rom", function()
  local rb = rombase()
  if rb == 0 then return TAG..": no WPC machine yet (play a Williams table)" end
  local hdr = ""; pcall(function() local b = MemReadBytes(rb + 2, 40); if b then hdr = b end end)
  return string.format("%s: romBase=0x%X hdr='%s'", TAG, rb, (hdr:gsub("[^%g ]", ".")))
end) end)
pcall(function() RegisterCommand("wpc_scan", function(a)
  if not a or a == "" then return TAG..": usage wpc_scan <hex aob, ?? wildcard>" end
  local hits = rom_scan(parse_aob(a)); local t = {}
  for i = 1, math.min(#hits, 12) do
    local o = hits[i]; local bank = (o < 0x78000) and (o >> 14) or -1
    local guest = (o >= 0x78000) and (0x8000 + (o - 0x78000)) or (0x4000 + (o & 0x3FFF))
    t[#t+1] = string.format("0x%05X(%s $%04X)", o, bank<0 and "FIX" or string.format("b%02X", bank), guest)
  end
  return string.format("%s: %d hit(s): %s", TAG, #hits, table.concat(t, " "))
end) end)
pcall(function() RegisterCommand("wpc_patch_slam", function() return TAG..": "..tostring(select(2, rom_apply(ROM_PATCHES.slam_tilt))) end) end)
pcall(function() RegisterCommand("wpc_applied", function()
  local t = {}; for k, v in pairs(ST.rom_applied) do t[#t+1] = string.format("%s@0x%X", k, v.at or 0) end
  return TAG..": applied = " .. (#t > 0 and table.concat(t, ", ") or "(none)")
end) end)
-- probe helper: flip the door-open polarity if a build proves inverted
pcall(function() RegisterCommand("op_release",function() return r(API.release_all) end) end)
pcall(function() RegisterCommand("op_bind",   function() return TAG..": Operator Mode "..(bind_controls(not ST.bind_on) and "ON (door auto-open; R-stick=+/-, click=ENTER, A=ESC, X=START/help)" or "off") end) end)
pcall(function() RegisterCommand("op_operator",function() return TAG..": Operator Mode "..(bind_controls(not ST.bind_on) and "ON (door auto-open; R-stick=+/-, click=ENTER, A=ESC, X=START/help)" or "off") end) end)
pcall(function() RegisterCommand("op_dbg",    function() return r(API.toggle_debug) end) end)
pcall(function() RegisterCommand("op_romdbg", function() return r(API.toggle_romdbg) end) end)
pcall(function() RegisterCommand("op_text",   function(a) return TAG..": "..tostring(select(2, debug_text(a or ""))) end) end)
pcall(function() RegisterCommand("op_sound",  function(a) return TAG..": "..tostring(select(2, play_sound(tonumber(a) or 1))) end) end)

Log(TAG .. ": v4 ready — WPC operator menu (auto-detect coin door + START button) + merged 6809 ROM AOB-patcher. op_door, op_enter/up/down/esc/coin, op_start (help page), op_release, op_dbg; wpc_rom/wpc_scan/wpc_patch_slam/wpc_applied. Operator mode: R-stick nav / click=ENTER / A=ESC / X=START(help). Open from attract/game-over (opening it halts play, authentic WPC).")
