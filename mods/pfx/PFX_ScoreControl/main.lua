-- ============================================================================
-- PFX_ScoreControl v3 — add/subtract score on ANY table
--   Zen  +  Williams SYSTEM-11 (Elvira…)  +  Williams WPC (Addams, TZ, …)
-- ============================================================================
-- Addresses are resolved by AOB SIGNATURE (PFXCore.resolve) with a hardcoded-RVA
-- fallback, so a game update that only shifts code doesn't break the mod.
--
-- THREE score engines, auto-detected per table (tried in order, fall through):
--
--  • WPC Williams (Addams Family, Twilight Zone, …): the game exposes a native
--    "WPCScoreboard" class whose addScore (sub_4A2DA90, Px::s64) is the ROM-backed
--    score-add — the WPC twin of the Zen sub_497F7C4. It delegates into the
--    emulated ROM machine, so the AUTHENTIC ROM score changes and the table DMD
--    AND the central HUD update together (both derive from the ROM). Raw writes to
--    the ScoreBoard/A0 mirrors do NOT move the HUD — it only refreshes on real ROM
--    events, which is exactly what addScore raises. We capture the machine object
--    (sub_4A05C08's X0 == WPCScoreboard+248), then call sub_4A2DA90(wpcSB, &points).
--    ONE game-native call = every WPC table, no per-table address hunting, no pin.
--    Read total = A0+B0 (obj+27656 / +27720). Found by tracing the WPCScoreboard
--    script registrar (sub_4A2D06C) in IDA.
--
--  • ZEN tables (Godzilla, Kong, Tomb Raider, Peanuts, Wrath, …): the native
--    ScoreBoard is the live score. We add through the game's OWN add path —
--    wrapper sub_4941980 (sets X8 itself) -> sub_497F7C4: total (XOR-obfuscated
--    s64 @ sb+0x58) += points, fires events, updates DMD. ScoreBoard captured by
--    hooking the core add (its X0). See [[pfx-score-add-path]].
--
--  • WILLIAMS SYSTEM-11 ROM (Elvira, …): visible score = emulated ROM dot-matrix,
--    BCD in the emulator's memBANK guest RAM. sub_49BE5D0 reads it; layout from
--    the display-manager (rm, captured via ROM refresh sub_4A1F604):
--      base=*(rm+152) nBytes=*(rm+1740) stride=*(rm+1741) rows=*(rm+10344)
--    memModel captured from the ROM reader (its X0). [[modloader-memtools]]
-- ============================================================================
local TAG = "PFX_ScoreControl"
Log(TAG .. ": loading v3 — WPC + Zen + System-11, AOB-resolved")

_G._SCTL_GEN = (_G._SCTL_GEN or 0) + 1
local MY_GEN = _G._SCTL_GEN

-- ── Signatures (unique, verified) + current-build RVA fallback ──────────────
local SIG = {
  add_core    = { "11 04 FA F0 31 C2 3E 91 20 02 1F D6 FD A3 00 91 FB 1F 00 F9 FA 67 04 A9 F8 5F 05 A9 F6 57 06 A9", 0x497F7C4 },
  add_wrap    = { "FF 03 01 D1 FD 7B 02 A9 FD 83 00 91 F3 1B 00 F9 53 D0 3B D5 68 16 40 F9 A8 83 1F F8 E8 23 00 91 00 D4", 0x4941980 },
  rom_read    = { "31 02 FA B0 31 32 0C 91 20 02 1F D6 F6 57 02 A9 F4 4F 03 A9 5F 04 00 71 6B 04 00 54 F3 03 02 2A", 0x49BE5D0 },
  rom_refresh = { "31 FF F9 90 31 D2 06 91 20 02 1F D6 F4 4F 02 A9 01 E8 40 BD 14 04 40 F9 20 38 20 1E 08 20 20 1E", 0x4A1F604 },
  -- WPC: sub_4A05C08(machine,player) = *(m+8p+27720)+*(m+8p+27656); its X0 = machine obj
  -- (= WPCScoreboard+248). Hooked only to capture that object per table.
  wpc_read    = { "B1 A6 F6 D0 31 82 09 91 20 02 1F D6 00 01 09 8B C0 03 5F D6 FD 7B BA A9", 0x4A05C08 },
  -- WPC: WPCScoreboard::addScore(this, &s64 points) — the game's OWN Williams score-add.
  -- Delegates into the emulated ROM machine, so the authentic ROM score moves and BOTH
  -- the table dot-matrix AND the central HUD update together. this = capturedV6 - 248.
  wpc_addscore= { "71 A5 F6 D0 31 E2 0E 91 20 02 1F D6 E3 03 1F 2A 00 95 48 F9 08 00 40 F9 04 01 40 F9", 0x4A2DA90 },
}
local RVA_XORKEY = 0x74476A0     -- data global (kept as RVA; not code-scannable)

-- ── Offsets ─────────────────────────────────────────────────────────────────
local A1_SB    = 0x5A8           -- add_wrap reads ScoreBoard at fakeA1+0x5A8
local SB_TOTAL = 0x58            -- ScoreBoard XOR-obfuscated total
-- System-11 ROM display manager (rm) fields:
local RM_BASE  = 152             -- guest base address of score digits
local RM_NDIG  = 1740            -- BCD byte count
local RM_STRIDE= 1741            -- per-row stride
local RM_ROWS  = 10344           -- number of score rows (players)
-- System-11 ROM memModel fields:
local MM_SHIFT = 656
local MM_BANKS = 640
local BANK_BUF = 0x20
-- WPC machine-object fields:
local WPC_A0     = 27656         -- extracted total, player 0 (read via sub_4A05C08 = A0+B0)
local WPC_B_OFF  = 64            -- B0 = A0 + 64  (v6+27720)
local WPC_SB_OFF = 248           -- WPCScoreboard = capturedV6 - 248 (sub_4A05C08 arg = SB+248)

-- ── base / unharden / heap ──────────────────────────────────────────────────
local function base()
  if _G.PFXCore then return _G.PFXCore.base() end
  local b = YUP.GetLibBase(); return (type(b) == "number") and b or PtrToInt(b)
end
local function unharden()
  if _G.PFXCore then _G.PFXCore.unharden()
  else pcall(function() CallNativeBySymbol("prctl", "iuuuuu", 4, 1, 0, 0, 0) end) end
end
-- Game heap floor was 0x7000000000, but the heap base VARIES per launch (ASLR +
-- memory pressure): some sessions it lands at 0x6F.. (verified this device), which
-- a 0x70 floor wrongly rejects → nothing captured (mode wrongly falls back to ZEN).
-- 0x60 covers the observed 0x6F–0x7F game heap; downstream structure checks validate.
local HEAP_LO = 0x6000000000
local function heap(p) return p and p > HEAP_LO and p < 0x8000000000 end
local function resolve(name)
  local s = SIG[name]
  if _G.PFXCore and _G.PFXCore.resolve then return _G.PFXCore.resolve(name, s[1], s[2]) end
  return base() + s[2]
end

-- ── State ────────────────────────────────────────────────────────────────────
_G._SCTL = _G._SCTL or { sb = 0, rm = 0, mm = 0, buf = 0, hits = 0, romhits = 0, wpc = 0 }
local ST = _G._SCTL

-- ── Capture hooks: sb (Zen), rm/mm (System-11), wpc (WPC machine) ────────────
-- CRITICAL: these hook HOT functions. rom_read / rom_refresh fire THOUSANDS of
-- times/sec on the ROM EMULATION thread (every hub cabinet runs its table ROM to
-- drive the live DMD preview). A Lua-callback hook there (the old RegisterNativeHookAt)
-- runs the SHARED lua_State off the game thread — racing the game thread's Lua and
-- corrupting a live closure → the intermittent "garbage-Proto" luaV_execute crash
-- (tick_game_thread, tiny fault addr) that plagued boot AND gameplay all along.
-- FIX: capture the object pointers with PURE-C++ RegisterNativeCapture into malloc'd
-- slots (no Lua on the emulation thread, no syscall, never derefs the ptr), then read
-- them back safely ON THE GAME THREAD with MemReadU64 via refresh_captures().
local function alloc_slots()
  if ST.cap and ST.cap ~= 0 then return true end
  local p; pcall(function() p = CallNativeBySymbol("malloc", "pp", 64) end)
  if not p then return false end
  ST.cap  = (type(p) == "number") and p or PtrToInt(p)
  ST.capr = ST.cap & 0x00FFFFFFFFFFFFFF                    -- tag-stripped, for MemRead/Write
  for i = 0, 3 do pcall(function() MemWriteU64(ST.capr + i * 8, 0) end) end
  ST.slot = { sb = ST.capr, rm = ST.capr + 8, mm = ST.capr + 16, wpc = ST.capr + 24 }
  return true
end
local function refresh_captures()
  if not ST.slot then return end
  local s, r, m, w = 0, 0, 0, 0
  pcall(function() s = MemReadU64(ST.slot.sb)  end)
  pcall(function() r = MemReadU64(ST.slot.rm)  end)
  pcall(function() m = MemReadU64(ST.slot.mm)  end)
  pcall(function() w = MemReadU64(ST.slot.wpc) end)
  if heap(s) then ST.sb  = s end
  if heap(r) then ST.rm  = r end
  if heap(m) then ST.mm  = m end
  if heap(w) then ST.wpc = w end
end
local function install()
  -- Gate on MY_GEN, not a bare bool: ST persists in _G across a hot-reload, so a
  -- plain `if ST.hooked` skips re-registration after a reload, leaving the OLD
  -- capture closures (old heap range / freed slots) live. Re-arm once per (re)load.
  if ST.hooked == MY_GEN then return end
  if not alloc_slots() then Log(TAG .. ": capture-slot alloc FAILED — score control disabled"); return end
  local function cap(rva_addr, name, slot)
    local ok = false
    pcall(function()
      -- capture x0 (the object ptr) into `slot` when it's a heap ptr [HEAP_LO,0x80..)
      ok = RegisterNativeCapture(IntToPtr(rva_addr), name, 0, IntToPtr(slot), HEAP_LO, 0x8000000000)
    end)
    return ok ~= false
  end
  cap(resolve("add_core"),    "sctl_sb",  ST.slot.sb)
  cap(resolve("rom_refresh"), "sctl_rm",  ST.slot.rm)
  cap(resolve("rom_read"),    "sctl_mm",  ST.slot.mm)
  cap(resolve("wpc_read"),    "sctl_wpc", ST.slot.wpc)
  ST.hooked = MY_GEN
  Log(TAG .. ": capture hooks armed (PURE-C++, no Lua on ROM thread) — Zen sb + S11 rm/mm + WPC")
end

-- ── shared BCD helpers (packed, MSB first; nibble 0xF = blank -> 0) ──────────
local function bcd_read(addr, nb)
  local v = 0
  for i = 0, nb - 1 do
    local b = MemReadU64(addr + i) & 0xFF
    local hi = (b >> 4); if hi == 0xF then hi = 0 end
    local lo = (b & 0xF); if lo == 0xF then lo = 0 end
    v = v * 100 + hi * 10 + lo
  end
  return v
end
local function bcd_write(addr, value, nb)
  local v = value
  for i = nb - 1, 0, -1 do
    local lo = v % 10; v = math.floor(v / 10)
    local hi = v % 10; v = math.floor(v / 10)
    MemWriteU8(addr + i, (hi << 4) | lo)
  end
end
local function ndigits(n) local d = 1; local x = math.floor(n); while x >= 10 do x = math.floor(x/10); d = d + 1 end; return d end

-- ── shared malloc scratch (Zen fake-a1 buffer + WPC points buffer) ──────────
local function ensure_buf()
  if ST.buf ~= 0 then return true end
  local p; pcall(function() p = CallNativeBySymbol("malloc", "pp", 2048) end)
  if not p then return false end
  ST.buf = (type(p) == "number") and p or PtrToInt(p)
  ST.bufr = ST.buf & 0x00FFFFFFFFFFFFFF
  return ST.buf ~= 0
end

-- ── WPC Williams engine — the game's OWN WPCScoreboard::addScore ─────────────
-- Capture stores V6 = WPCScoreboard+248 (sub_4A05C08's arg). We add through
-- sub_4A2DA90(wpcSB, &s64 points), which delegates into the emulated ROM machine:
-- the authentic ROM score changes, so the table DMD AND the central HUD move as
-- ONE (both derive from it — verified A0+B0 == displayed total). No per-table
-- address hunting, no pinning: a single game-native call, works on every WPC table.
local function is_wpc() return heap(ST.wpc) end
local function wpc_sb()
  if not heap(ST.wpc) then return 0 end
  local sb = ST.wpc - WPC_SB_OFF
  if MemReadU64(sb + 8) < HEAP_LO then return 0 end        -- *(sb+8) = S must be a heap ptr
  return sb
end
local function wpc_total()
  if not heap(ST.wpc) then return nil end
  return MemReadU64(ST.wpc + WPC_A0) + MemReadU64(ST.wpc + WPC_A0 + WPC_B_OFF)
end
local function wpc_add(amount)
  local sb = wpc_sb()
  if sb == 0 then return false, "no WPC scoreboard yet — score once" end
  if not ensure_buf() then return false, "buf alloc failed" end
  unharden()
  local before = wpc_total() or 0
  MemWriteU64(ST.bufr, amount)                          -- s64 points at buf+0
  local ok = pcall(function()
    CallNative(IntToPtr(resolve("wpc_addscore")), "vpp", IntToPtr(sb), IntToPtr(ST.buf))
  end)
  local after = wpc_total() or before
  return ok, string.format("WPC %s%d | %d -> %d", amount >= 0 and "+" or "", amount, before, after)
end

-- ── ZEN engine ──────────────────────────────────────────────────────────────
local function zen_total()
  if not heap(ST.sb) then return nil end
  local key = MemReadU64(base() + RVA_XORKEY)
  return (MemReadU64(ST.sb + SB_TOTAL) ~ key)
end
local function zen_add(amount)
  if not heap(ST.sb) then return false, "no ScoreBoard yet — score once" end
  if not ensure_buf() then return false, "buf alloc failed" end
  unharden()
  local arg = amount
  if arg >  2147483647 then arg =  2147483647 end
  if arg < -2147483648 then arg = -2147483648 end
  local before = zen_total() or 0
  MemWriteU64(ST.bufr + A1_SB, ST.sb)                       -- fake a1
  local ok = pcall(function()
    CallNative(IntToPtr(resolve("add_wrap")), "vpiii", IntToPtr(ST.buf), arg, 0, 0)
  end)
  local after = zen_total() or before
  return ok, string.format("ZEN %s%d | %d -> %d", amount >= 0 and "+" or "", amount, before, after)
end

-- ── WILLIAMS SYSTEM-11 ROM engine (BCD in memBANK guest RAM) ─────────────────
local function is_rom()
  return heap(ST.rm) and heap(ST.mm)
end
local function rom_cfg()
  local rm, mm = ST.rm, ST.mm
  local gb    = MemReadU64(rm + RM_BASE)   & 0xFFFFFFFF
  local nb    = MemReadU64(rm + RM_NDIG)   & 0xFF
  local stride= MemReadU64(rm + RM_STRIDE) & 0xFF
  local rows  = MemReadU64(rm + RM_ROWS)   & 0xFF
  local shift = MemReadU64(mm + MM_SHIFT)  & 0xFF
  local banks = MemReadU64(mm + MM_BANKS)
  if nb == 0 or nb > 8 or rows == 0 or rows > 8 or not heap(banks) then return nil end
  return { gb = gb, nb = nb, stride = stride, rows = rows, shift = shift, banks = banks }
end
local function rom_bufaddr(c, ga)
  local bankObj = MemReadU64(c.banks + 8 * (ga >> c.shift))
  if not heap(bankObj) then return 0 end
  local buf = MemReadU64(bankObj + BANK_BUF)
  return heap(buf) and (buf + ga) or 0
end
local function rom_score()
  local c = rom_cfg(); if not c then return nil end
  local a = rom_bufaddr(c, c.gb); if a == 0 then return nil end
  return bcd_read(a, c.nb)
end
local function rom_add(amount)
  local c = rom_cfg(); if not c then return false, "no ROM display cfg yet" end
  unharden()
  local first = rom_bufaddr(c, c.gb); if first == 0 then return false, "no guest buffer" end
  local cur = bcd_read(first, c.nb)
  local cap = 1
  for _ = 1, c.nb * 2 do cap = cap * 10 end
  local nv = cur + amount
  if nv < 0 then nv = 0 end
  if nv >= cap then nv = cap - 1 end
  for r = 0, c.rows - 1 do
    local a = rom_bufaddr(c, c.gb + r * c.stride)
    if a ~= 0 then bcd_write(a, nv, c.nb) end
  end
  return true, string.format("S11 %s%d | %d -> %d (%d row/s, %d digits)",
    amount >= 0 and "+" or "", amount, cur, nv, c.rows, c.nb * 2)
end

-- ── Public add (auto-routes: WPC -> System-11 -> Zen, falling through) ───────
-- forward declaration: add() (below) calls total() in its subtract-clamp path, but
-- total() is defined further down. Without this local, that call hit the nil GLOBAL
-- `total` and every "-" score tap errored ("attempt to call a nil value"). "+" never
-- calls total(), which is why only minus failed.
local total
local function add(amount)
  refresh_captures()                       -- pull latest object ptrs from the C++ capture slots
  amount = math.floor(tonumber(amount) or 0)
  if amount == 0 then return false, "amount is 0" end
  -- Clamp subtraction so the score never goes below 0: a negative running total
  -- renders as garbage on the ROM reel/DMD (and is meaningless everywhere). We
  -- read the live total and cap the subtraction at exactly -total (-> lands on 0).
  if amount < 0 then
    local cur = total() or 0
    if cur <= 0 then return false, "already at 0" end
    if amount < -cur then amount = -cur end
  end
  if is_wpc() then local ok, m = wpc_add(amount); if ok then return ok, m end end
  if is_rom() then local ok, m = rom_add(amount); if ok then return ok, m end end
  return zen_add(amount)
end
total = function()
  refresh_captures()
  if is_wpc() then local t = wpc_total(); if t and t > 0 then return t end end
  if is_rom() then local t = rom_score(); if t then return t end end
  return zen_total()
end
-- Set the score to an exact value by adding the delta through the same game-native
-- path (works everywhere add() does). set(0) = reset. Negative deltas rely on the
-- engine honouring subtraction (Zen: yes; WPC: the ROM add path; S11: BCD clamps>=0).
local function set(value)
  value = math.floor(tonumber(value) or 0)
  local cur = total() or 0
  if value == cur then return true, "already "..cur end
  return add(value - cur)
end
local function mode()
  if is_wpc() then return "WPC" elseif is_rom() then return "S11" else return "ZEN" end
end

unharden()
install()
LoopAsync(1500, function()
  if _G._SCTL_GEN ~= MY_GEN then return true end
  unharden(); install(); refresh_captures()
  return false
end)

-- ── Public API (menu / other mods) ──────────────────────────────────────────
_G.PFX_ScoreControl = {
  add        = add,
  set        = set,
  total      = total,
  mode       = mode,
  ready      = function() return is_wpc() or is_rom() or heap(ST.sb) end,
  is_rom     = function() return is_wpc() or is_rom() end,
}

-- ── Bridge commands ─────────────────────────────────────────────────────────
local function cmd(n) return TAG .. ": " .. tostring(select(2, add(n))) end
pcall(function() RegisterCommand("sc_status", function()
  return string.format("%s: mode=%s ready=%s sb=0x%X rm=0x%X mm=0x%X wpc=0x%X total=%s",
    TAG, mode(), tostring(_G.PFX_ScoreControl.ready()),
    ST.sb or 0, ST.rm or 0, ST.mm or 0, ST.wpc or 0, tostring(total()))
end) end)
pcall(function() RegisterCommand("sc_add",  function(a) return cmd(tonumber(a) or 0) end) end)
pcall(function() RegisterCommand("sc_set",  function(a) return TAG..": "..tostring(select(2, set(tonumber(a) or 0))) end) end)
pcall(function() RegisterCommand("sc_zero", function() return TAG..": "..tostring(select(2, set(0))) end) end)
pcall(function() RegisterCommand("sc_p1m",  function() return cmd(1000000) end) end)
pcall(function() RegisterCommand("sc_m1m",  function() return cmd(-1000000) end) end)
pcall(function() RegisterCommand("sc_p10m", function() return cmd(10000000) end) end)
pcall(function() RegisterCommand("sc_m10m", function() return cmd(-10000000) end) end)
pcall(function() RegisterCommand("sc_p100m",function() return cmd(100000000) end) end)
pcall(function() RegisterCommand("sc_m100m",function() return cmd(-100000000) end) end)
pcall(function() RegisterCommand("sc_p1b",  function() return cmd(1000000000) end) end)
pcall(function() RegisterCommand("sc_m1b",  function() return cmd(-1000000000) end) end)

Log(TAG .. ": v3 ready — auto WPC/S11/Zen; bridge sc_status, sc_add <n>, sc_p1m..sc_m1b")
