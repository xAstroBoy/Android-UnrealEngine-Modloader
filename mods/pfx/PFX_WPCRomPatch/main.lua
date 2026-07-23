-- ============================================================================
-- PFX_WPCRomPatch v1 — runtime 6809 ROM patcher for the emulated WPC cores
-- ============================================================================
-- Instead of racing the game's per-frame switch re-sync (which stomps live
-- switch injection and can trigger slam-tilt/reset — see [[pfx-operator-menu]]),
-- this mod patches the emulated WPC ROM *image* directly, once, the moment a
-- WPC machine is detected. Deterministic, no per-frame anything, no race.
--
-- ROM layout (reversed from the emulator I/O read handler sub_4A03438):
--   • CPU state a2 = machine + 248
--   • guest ROM native base = *(a2 + 24880)              (romBase, 512 KB)
--   • fixed OS page  guest 0x8000-0xFFFF = romBase + 0x78000 + (g-0x8000)
--   • banked ROM     guest 0x4000-0x7FFF = romBase + (bank<<14) + (g-0x4000)
-- So a patch at rom-file offset X writes romBase + X.
--
-- Patches are found by AOB SIGNATURE (not fixed offsets) so they survive ROM
-- revisions, and each is verified to match EXACTLY ONCE before it's applied.
-- Disassembled with a from-scratch 6809 disassembler (scratchpad/dis6809.py);
-- IDA 9.3 has no 6809 module. See [[pfx-operator-menu]] for the full reverse.
-- ============================================================================
local TAG = "PFX_WPCRomPatch"
Log(TAG .. ": loading v1")

_G._WRP_GEN = (_G._WRP_GEN or 0) + 1
local MY_GEN = _G._WRP_GEN

local ROM_OFF_BASE = 24880        -- *(machine+248+24880) = guest ROM native base
local ROM_SIZE     = 0x80000      -- 512 KB
local A2_OFF       = 248

-- ── heap / base helpers (mirror the other PFX mods) ─────────────────────────
local HEAP_LO, HEAP_HI = 0x6000000000, 0x8000000000
local function heap(p) return p and p > HEAP_LO and p < HEAP_HI end
local function unharden()
  if _G.PFXCore then _G.PFXCore.unharden()
  else pcall(function() CallNativeBySymbol("prctl", "iuuuuu", 4, 1, 0, 0, 0) end) end
end

_G._WRP = _G._WRP or { rombase = 0, applied = {} }
local ST = _G._WRP

-- Reuse PFX_OperatorMenu's captured WPC machine if present (it hooks the switch
-- setters pure-C++); else we have no machine and just idle until it appears.
local function wpc_machine()
  if _G._OPM and heap(_G._OPM.wpc) then
    -- validate: first qword must look like a live pointer (vtable or heap)
    local ok, first = pcall(function() return MemReadU64(_G._OPM.wpc) end)
    if ok and first and (heap(first) or first > 0x1000) then return _G._OPM.wpc end
  end
  return nil
end

local function rombase()
  local m = wpc_machine()
  if not m then return 0 end
  local rb = 0
  pcall(function() rb = MemReadU64(m + A2_OFF + ROM_OFF_BASE) end)
  if not heap(rb) then return 0 end
  ST.rombase = rb & 0x00FFFFFFFFFFFFFF
  return ST.rombase
end

-- ── AOB scanning over the ROM image ─────────────────────────────────────────
-- CRITICAL: MemReadBytes on this modloader returns a HEX-ENCODED string (2 chars
-- per byte, lowercase), NOT raw bytes — so we scan in the hex domain. And it caps
-- around 0x1000 bytes/read, so chunk at 0x1000. `??` = wildcard byte (%x%x).
-- parse_aob -> {plen, lpat} where lpat is a Lua pattern over the hex text.
local function parse_aob(str)
  local pat, plen = {}, 0
  for tok in str:gmatch("%S+") do
    plen = plen + 1
    if tok == "??" or tok == "?" then pat[#pat+1] = "%x%x"
    else pat[#pat+1] = string.format("%02x", tonumber(tok, 16)) end
  end
  return { plen = plen, lpat = table.concat(pat) }
end
-- Returns rom-file offsets where the pattern matches. Overlap MUST be a whole
-- number of bytes (even hex chars) or the byte-alignment parity flips and real
-- matches at odd hex offsets are wrongly rejected.
local function scan(p)
  local rb = rombase(); if rb == 0 then return {} end
  local lpat, plen = p.lpat, p.plen
  local hits = {}
  local CH = 0x1000
  local keep = (plen - 1) * 2          -- even # of hex chars = (plen-1) whole bytes
  local prevhex, pos = "", 0
  while pos < ROM_SIZE do
    local n = math.min(CH, ROM_SIZE - pos)
    local h = nil
    pcall(function() h = MemReadBytes(rb + pos, n) end)
    if not h then break end
    local hy = prevhex .. h
    local basebyte = pos - (#prevhex // 2)
    local s = 1
    while true do
      local a = hy:find(lpat, s)
      if not a then break end
      if (a - 1) % 2 == 0 then hits[#hits+1] = basebyte + (a - 1) // 2 end
      s = a + 1
    end
    prevhex = (#hy >= keep) and hy:sub(#hy - keep + 1) or hy
    pos = pos + n
  end
  return hits
end

-- ── patch application ───────────────────────────────────────────────────────
-- A patch = { name, aob (string), verify_unique=true, edits={ {rel, from, to}, } }
--   rel  = byte offset within the matched signature
--   from = expected current byte (safety check), to = new byte
local function apply(patch)
  if ST.applied[patch.name] then return true, patch.name .. ": already applied" end
  local rb = rombase(); if rb == 0 then return false, "no WPC ROM detected yet" end
  unharden()
  local pat = parse_aob(patch.aob)
  local hits = scan(pat)
  if #hits == 0 then return false, patch.name .. ": signature NOT FOUND" end
  if patch.verify_unique ~= false and #hits ~= 1 then
    return false, string.format("%s: signature matched %d times (want 1) — refusing", patch.name, #hits)
  end
  local off = hits[1]
  -- verify: each byte must be either the expected 'from' (patch it) or already 'to'
  -- (idempotent — a hot-reload or re-detect won't double-apply or falsely refuse).
  local already = true
  for _, e in ipairs(patch.edits) do
    local cur = 0
    pcall(function() cur = MemReadU8(rb + off + e.rel) end)
    if cur == e.to then
      -- this byte already patched
    elseif (not e.from) or cur == e.from then
      already = false
    else
      return false, string.format("%s: byte@+%d is 0x%02X, expected 0x%02X — NOT patching",
        patch.name, e.rel, cur, e.from)
    end
  end
  for _, e in ipairs(patch.edits) do
    pcall(function() MemWriteU8(rb + off + e.rel, e.to) end)
  end
  ST.applied[patch.name] = { off = off, at = rb + off }
  return true, string.format("%s: %s at rom 0x%05X (romBase+0x%05X)",
    patch.name, already and "already patched" or "patched", off, off)
end

-- ── the patch catalog ───────────────────────────────────────────────────────
-- (1) SLAM-TILT-STUCK diagnostic skip. Bank 0x13 $69D6:
--       BD 6E AE   JSR $6EAE      ; stuck-switch check -> carry
--       25 23      BCS $69FE      ; carry => skip the "SLAM TILT STUCK" display
--       BD 87 33   JSR $8733
--     Force the conditional skip to UNCONDITIONAL (25->20 : BCS->BRA) so the
--     "SLAM TILT SWITCH IS STUCK CLOSED" (msg idx 0x6E via $85E3) never blocks.
--     8-byte sig incl. the following JSR $8733 for uniqueness.
local PATCHES = {
  slam_tilt = {
    name = "slam_tilt_skip",
    aob  = "BD 6E AE ?? 23 BD 87 33",                  -- ?? = the patch byte (matches fresh or patched)
    edits = { { rel = 3, from = 0x25, to = 0x20 } },   -- BCS $69FE -> BRA $69FE
  },
  -- (2) coin-door interlock — PENDING: located live via watchpoint (the static
  --     trail through the OS message system dead-ends). Slot reserved.
}

-- ── driver: apply enabled patches once the ROM appears ──────────────────────
local ENABLED = { }   -- set patch keys true to auto-apply; default OFF until verified live
local function try_apply_all()
  local rb = rombase(); if rb == 0 then return end
  for key, on in pairs(ENABLED) do
    if on and PATCHES[key] and not ST.applied[PATCHES[key].name] then
      local ok, msg = apply(PATCHES[key])
      Log(TAG .. ": " .. tostring(msg))
    end
  end
end

unharden()
LoopAsync(1000, function()
  if _G._WRP_GEN ~= MY_GEN then return true end
  try_apply_all()
  return false
end)

-- ── public API + bridge ─────────────────────────────────────────────────────
_G.PFX_WpcRom = {
  rombase   = rombase,
  scan      = function(aob) return scan(parse_aob(aob)) end,
  apply     = apply,
  patches   = PATCHES,
  apply_slam = function() return apply(PATCHES.slam_tilt) end,
}

local function romstr()
  local rb = rombase()
  if rb == 0 then return TAG .. ": no WPC machine yet (play a Williams table)" end
  -- read the ASCII copyright header as a liveness proof
  local hdr = ""
  pcall(function() local b = MemReadBytes(rb + 2, 40); if b then hdr = b end end)
  hdr = hdr:gsub("[^%g ]", ".")
  return string.format("%s: romBase=0x%X  hdr='%s'", TAG, rb, hdr)
end

pcall(function() RegisterCommand("wpc_rom", function() return romstr() end) end)
pcall(function() RegisterCommand("wpc_scan", function(a)
  if not a or a == "" then return TAG .. ": usage wpc_scan <hex aob, ?? wildcard>" end
  local hits = scan(parse_aob(a))
  local t = {}
  for i = 1, math.min(#hits, 12) do
    local o = hits[i]
    local bank = (o < 0x78000) and (o >> 14) or -1
    local guest = (o >= 0x78000) and (0x8000 + (o - 0x78000)) or (0x4000 + (o & 0x3FFF))
    t[#t+1] = string.format("0x%05X(%s $%04X)", o, bank<0 and "FIX" or string.format("b%02X",bank), guest)
  end
  return string.format("%s: %d hit(s): %s", TAG, #hits, table.concat(t, " "))
end) end)
pcall(function() RegisterCommand("wpc_patch_slam", function()
  return TAG .. ": " .. tostring(select(2, apply(PATCHES.slam_tilt)))
end) end)
pcall(function() RegisterCommand("wpc_applied", function()
  local t = {}
  for k, v in pairs(ST.applied) do t[#t+1] = string.format("%s@0x%X", k, v.at or 0) end
  return TAG .. ": applied = " .. (#t > 0 and table.concat(t, ", ") or "(none)")
end) end)

Log(TAG .. ": v1 ready — runtime WPC ROM AOB-patcher. Cmds: wpc_rom (status), "
  .. "wpc_scan <aob>, wpc_patch_slam, wpc_applied. Patches OFF by default until live-verified.")
