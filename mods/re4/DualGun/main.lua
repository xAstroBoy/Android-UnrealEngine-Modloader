-- mods/re4/DualGun/main.lua v1.0
-- ═══════════════════════════════════════════════════════════════════════
-- DUAL GUN — spawn a grabbable, fire-wired DUPLICATE of a held gun so you can
-- dual-wield ANY weapon (1-handed OR 2-handed slot).
--
-- How it works (all the game's own machinery, verified in IDA):
--   1. AssignProp(cls, TEMP_SLOT) spawns a fresh prop of the same class as the
--      source gun, borrowing the source's holster so it has somewhere to live.
--   2. RegisterAdditionalProp({gun, holsterA, holsterB}) is the game's own way
--      to add an EXTRA gun that is fire-wired (AVR4GamePlayerPawn::GetHeldGuns
--      enumerates the additional-props array) AND holster-attached — the exact
--      path AVR4ShootingRange::SetActiveWeaponProp uses.
--   3. SetWeaponNo(clone, differentId) UNBINDS it: RE4 arms ONE weapon per
--      weapon-id, so a clone with the SAME id shares the original's armed weapon
--      (only one fires). A DIFFERENT id makes it independently armable.
--
-- Pair with DualFire (arms whichever trigger was just pulled) for true
-- simultaneous dual fire. This mod only creates the clone; DualFire drives it.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "DualGun"
local function L(...) Log(TAG .. ": " .. string.format(...)) end

local A = {}
local function R(n, m, fb) A[n] = Resolve(m, fb) end
R("AssignProp",        "_ZN18AVR4GamePlayerPawn10AssignPropE11TSubclassOfI18AVR4GamePlayerPropE9EPropSlot30EGamePlayerPropAssignedContext", 0x62FC290)
R("SetWeaponNo",       "_ZN17AVR4GamePlayerGun11SetWeaponNoEh", 0x62DFA90)
R("RegAddProp",        "_ZN18AVR4GamePlayerPawn22RegisterAdditionalPropERK19FAdditionalPropData", 0x62FCCAC)
R("Malloc",            "_ZN7FMemory6MallocEyj", 0x6674178)
R("Free",              "_ZN7FMemory4FreeEPv", 0x6674258)
R("ArmSearchWeaponNo", "_ZN8cItemMgr17ArmSearchWeaponNoEh", 0x5F60264)
local ItemMgr = Offset(GetLibBase(), 0xA561810)

-- pawn field offsets (verified working)
local SLOTS_BASE, HOLA_BASE, HOLB_BASE = 3752, 3848, 3928   -- 8 bytes/slot
local ADDL_ARR, ADDL_COUNT = 3832, 3840                     -- FAdditionalPropData[] (24 bytes each)
local TEMP_SLOT = 8                                         -- EPropSlot::ScriptedGun = throwaway spawn slot
local WNO_OFF, CLS_OFF, PAWN_OFF = 3360, 16, 960            -- gun+3360=weapon-id, +16=UClass, +960=pawn

local function A2(o) if not o then return nil end local ok, p = pcall(function() return o:GetAddress() end) if ok and p then return p end return o end

local function findPawn()
  local guns = FindAllOf("VR4GamePlayerGun") or {}
  for _, g in ipairs(guns) do
    local o = ReadPtr(Offset(A2(g), PAWN_OFF))
    if not IsNull(o) then return o end
  end
  return nil
end

-- choose a weapon-id NOT already used by a held gun / additional prop, so the
-- clone can't double-bind to an existing armed weapon (= only one would fire).
local function pickDistinctWeapon(pawn, srcW)
  local used = { [srcW] = true }
  for i = 0, 9 do
    local g = ReadPtr(Offset(pawn, SLOTS_BASE + 8 * i))
    if not IsNull(g) then used[ReadU8(Offset(g, WNO_OFF))] = true end
  end
  local n = ReadU32(Offset(pawn, ADDL_COUNT)); local arr = ReadPtr(Offset(pawn, ADDL_ARR))
  if n > 0 and not IsNull(arr) then
    for i = 0, math.min(n, 16) - 1 do
      local g = ReadPtr(Offset(arr, 24 * i))
      if not IsNull(g) then used[ReadU8(Offset(g, WNO_OFF))] = true end
    end
  end
  for w = 1, 60 do
    if not used[w] then
      local it = CallNative(A.ArmSearchWeaponNo, "ppi", ItemMgr, w)
      if not IsNull(it) then return w end
    end
  end
  return nil
end

local function cloneSlot(slot)
  local pawn = findPawn()
  if not pawn then return "no pawn - be in gameplay" end
  local src = ReadPtr(Offset(pawn, SLOTS_BASE + 8 * slot))
  if IsNull(src) then return "slot " .. slot .. " EMPTY - draw that weapon first (0=1H, 1=2H)" end
  local cls  = ReadPtr(Offset(src, CLS_OFF))
  local W    = ReadU8(Offset(src, WNO_OFF))
  local holA = ReadPtr(Offset(pawn, HOLA_BASE + 8 * slot))
  local holB = ReadPtr(Offset(pawn, HOLB_BASE + 8 * slot))
  -- borrow the source holster on the throwaway slot so the spawn has an anchor
  WritePtr(Offset(pawn, HOLA_BASE + 8 * TEMP_SLOT), holA)
  WritePtr(Offset(pawn, HOLB_BASE + 8 * TEMP_SLOT), holB)
  local gun = CallNative(A.AssignProp, "pppii", pawn, cls, TEMP_SLOT, 0)
  if IsNull(gun) then return "AssignProp -> NULL (spawn failed)" end
  gun = A2(gun)
  -- clear the throwaway slot: the clone lives as an ADDITIONAL prop, not a slot
  WriteU64(Offset(pawn, SLOTS_BASE + 8 * TEMP_SLOT), 0)
  WriteU64(Offset(pawn, HOLA_BASE + 8 * TEMP_SLOT), 0)
  WriteU64(Offset(pawn, HOLB_BASE + 8 * TEMP_SLOT), 0)
  -- register as an additional prop = fire-wired + holster-attached (game's own path)
  local buf = CallNative(A.Malloc, "pii", 24, 8)
  WritePtr(buf, gun); WritePtr(Offset(buf, 8), holA); WritePtr(Offset(buf, 16), holB)
  CallNative(A.RegAddProp, "ppp", pawn, buf)
  pcall(function() CallNative(A.Free, "vp", buf) end)
  -- unbind: distinct weapon-id so it fires independently of the original
  local newW = pickDistinctWeapon(pawn, W)
  if newW then CallNative(A.SetWeaponNo, "ipi", gun, newW) end
  local msg = (slot == 1 and "2H" or "1H") .. " clone ready (src id=" .. W ..
              " -> clone id=" .. ReadU8(Offset(gun, WNO_OFF)) ..
              ", addl=" .. ReadU32(Offset(pawn, ADDL_COUNT)) .. "). Draw it from the holster & fire."
  L("%s", msg)
  pcall(function() Notify(TAG, msg) end)
  return msg
end

RegisterCommand("dualgun", function(arg)
  local slot = tonumber(arg and arg:gsub("%s", "")) or 0
  if slot ~= 0 and slot ~= 1 then return "usage: dualgun 0 (1-handed slot) | dualgun 1 (2-handed slot)" end
  return cloneSlot(slot)
end)

if SharedAPI and SharedAPI.DebugMenu then
  SharedAPI.DebugMenu.RegisterAction("DualGun", "Clone 1H gun (dual-wield)", function() cloneSlot(0) end)
  SharedAPI.DebugMenu.RegisterAction("DualGun", "Clone 2H gun (dual-wield)", function() cloneSlot(1) end)
end

L("v1.0 loaded — clone a held gun for dual-wield via 'dualgun 0|1' or the debug menu (fire-wired, distinct weapon-id). Pair with DualFire.")
