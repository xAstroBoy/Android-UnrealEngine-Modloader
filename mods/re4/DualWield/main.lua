-- mods/re4/DualWield/main.lua v9.0
-- =====================================================================
-- DUAL WIELD — one mod, three clearly-labelled parts.
--
-- v9.0 — MERGED DualWield + DualFire + DualGun into this single mod.
--   Three mods for one feature was genuinely confusing: you had to install all
--   three in the right combination, and nothing told you which part was a fair
--   "this limit shouldn't exist" fix and which part was a straight cheat. Now
--   it's one mod and each part says what it is:
--
--     [1] Two-Handed Grab   (QOL)  — hold a gun in BOTH hands. Removes an
--                                    artificial limit; the PSVR2 remake just
--                                    lets you do this. You still need two real
--                                    guns and real ammo.
--     [2] Simultaneous Fire (QOL)  — both HELD guns actually fire. The engine
--                                    arms ONE weapon globally, so without this
--                                    your second gun silently does nothing.
--                                    That's not extra power — it's the thing
--                                    you already did working.
--     [3] Clone Held Gun    (CHEAT)— duplicates the gun in your hand for free.
--                                    THIS is the cheese: a second weapon out of
--                                    nothing. It's an ACTION you trigger, not a
--                                    switch, so it can never fire by accident
--                                    just because dual-wield is on.
--
--   "I want the artificial limit gone but not free guns" = leave [1] and [2]
--   on, never touch [3]. That's the entire reason for the split.
--
-- [1] TWO-HANDED GRAB — PURE BYTE-PATCH (no runtime Lua, no reflection).
--   v8 learned this the hard way: the old Lua PostHooks on IsPresentOnBody /
--   IsPropGrabbable are HOT — polled during weapon interaction — and stalled
--   the game thread into an ANR. Every gate is a single native check, so flip
--   it once. Verified in IDA:
--     PrimaryGripGrabbed+0x30        ldrb w8,[x0,#0x30]   -> mov w8,#1
--     HolsterGripGrabAttempted+0x13C ldr  w8,[x8,#0x334]  -> mov w8,#0
--     execIsPropGrabbable+0x10       ldrb w8,[x0,#0x3F6]  -> mov w8,#1
--     execIsPresentOnBody+0x2C       and  w8,w0,#1        -> mov w8,#1
--     IsExternallyAllowed+0x24       ldrsw x8,[x0,#0x2F0] -> mov w8,#0
--
-- [2] SIMULTANEOUS FIRE — PURE C++ in the modloader (InstallDualFireArm).
--   MUST NOT be a Lua hook: TryFire runs on the game thread on every trigger
--   pull, per gun, non-stop under rapid-fire, and a Lua callback there races
--   the shared lua_State. It corrupted the heap and crashed far away —
--   FMallocBinned2 in GC, pc=lr=0x1, a fault inside atan2f. The native version
--   also only arms when the gun ISN'T already armed, exactly like the engine
--   (CMP armed_wno, gun[0xD20] / B.NE): re-arming on every poll resets weapon
--   state, which is what stopped the MINIGUN from firing.
--
-- [3] CLONE HELD GUN — the game's own machinery, on demand only.
--   AssignProp(cls, TEMP_SLOT) spawns a real prop of the source gun's class;
--   RegisterAdditionalProp wires it for firing + holstering (it COPIES the
--   24-byte struct — verified in IDA — so freeing the temp buffer is safe);
--   SetWeaponNo(clone, distinctId) unbinds it so it arms independently instead
--   of sharing the original's armed weapon.
--
--   BE CLEAR ABOUT WHAT THE CLONE IS. RE4 arms ONE cItem per weapon-no —
--   cItemMgr::ArmSearchWeaponNo scans your INVENTORY for the item whose
--   WeaponId2WeaponNo == wno. So a weapon-no IS a specific weapon you own, and
--   two guns sharing an id means only ONE ever fires (confirmed live). The clone
--   therefore MUST be armed as a different weapon from your inventory — that is
--   an engine limit, not something a hook can fix.
--   What WAS a bug: taking the first free id, which handed a cloned pistol the
--   ROCKET LAUNCHER — so it fired explosives and then crashed:
--       cObjLauncher::launch()+372 -> fault 0x78   (rocket[264] model == NULL)
--   Launchers are now excluded, asked the way the game asks it (GetGunProp +
--   AVR4GamePlayerRocketLauncher::GetPrivateStaticClass), not by guessing at
--   WeaponId2WeaponType — that field is only 0/1/2, a variant TIER, and 34 of 45
--   weapons share type 0.
-- =====================================================================
local TAG = "DualWield"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = {
    enabled  = true,    -- [1] QOL: two-handed grab
    dualFire = true,    -- [2] QOL: both held guns fire
    -- [3] is an ACTION — there is no state to leave switched on.
}

local saved = ModConfig.Load("DualWield")
if saved then
    if saved.enabled  ~= nil then state.enabled  = saved.enabled  end
    if saved.dualFire ~= nil then state.dualFire = saved.dualFire end
end
-- Inherit the old separate mod's setting so merging doesn't silently reset it.
local savedFire = ModConfig.Load("DualFire")
if savedFire and savedFire.enabled ~= nil and (not saved or saved.dualFire == nil) then
    state.dualFire = savedFire.enabled
end

local ARM64_MOV_W8_1 = 0x52800028   -- mov w8, #1
local ARM64_MOV_W8_0 = 0x52800008   -- mov w8, #0

local ItemMgr = Offset(GetLibBase(), 0xA561810)
local WNO_OFF = 3360

-- ═══════════════════════════════════════════════════════════════════════
-- [1] TWO-HANDED GRAB (QOL) — byte patches
-- ═══════════════════════════════════════════════════════════════════════
local DW_PATCHES = {
    { name = "PrimaryGripGrabbed (no auto-holster)",
      mangled = "_ZN17AVR4GamePlayerGun18PrimaryGripGrabbedEP18AVR4GamePlayerHand",
      fb = 0x062DF8DC, insn_off = 0x30, word = ARM64_MOV_W8_1 },
    { name = "HolsterGripGrabAttempted (allow 2nd gun)",
      mangled = "_ZN25AVR4GamePlayerPropHolster24HolsterGripGrabAttemptedEP18UVR4GamePlayerGripP18AVR4GamePlayerHandR31EVR4GamePlayerGripTryGrabResult",
      fb = 0x0631287C, insn_off = 0x13C, word = ARM64_MOV_W8_0 },
    { name = "IsPropGrabbable exec (holster grabbable)",
      mangled = "_ZN25AVR4GamePlayerPropHolster19execIsPropGrabbableEP7UObjectR6FFramePv",
      fb = 0x064915DC, insn_off = 0x10, word = ARM64_MOV_W8_1 },
    { name = "IsPresentOnBody exec (present on body)",
      mangled = "_ZN18AVR4GamePlayerProp19execIsPresentOnBodyEP7UObjectR6FFramePv",
      fb = 0x0648F9D4, insn_off = 0x2C, word = ARM64_MOV_W8_1 },
    -- THE gate that actually blocked pulling a 2nd gun from a holster while
    -- already holding one — verified live.
    { name = "IsExternallyAllowed (grab-vote bypass, enables 2nd-gun grab)",
      mangled = "_ZNK18UVR4GamePlayerGrip19IsExternallyAllowedE11EHandedness",
      fb = 0x062CE5D8, insn_off = 0x24, word = ARM64_MOV_W8_0 },
}

local patchesApplied = false

local function applyDualWieldPatch()
    if patchesApplied then return end
    for _, p in ipairs(DW_PATCHES) do
        pcall(function()
            if not p.addr then
                local base = Resolve(p.mangled, p.fb)
                if base and not IsNull(base) then p.addr = Offset(base, p.insn_off) end
            end
            if p.addr then
                if not p.orig then p.orig = ReadU32(p.addr) end
                WriteU32(p.addr, p.word)
                Log(TAG .. ": PATCHED " .. p.name .. " @ " .. ToHex(p.addr))
            end
        end)
    end
    patchesApplied = true
end

local function restoreDualWieldPatch()
    if not patchesApplied then return end
    for _, p in ipairs(DW_PATCHES) do
        if p.addr and p.orig then pcall(function() WriteU32(p.addr, p.orig) end) end
    end
    patchesApplied = false
    Log(TAG .. ": patches reverted")
end

if state.enabled then applyDualWieldPatch() end

-- ═══════════════════════════════════════════════════════════════════════
-- [2] SIMULTANEOUS FIRE (QOL) — native; never a Lua hook on TryFire
-- ═══════════════════════════════════════════════════════════════════════
local F = {}
local function R(n, m, fb) F[n] = Resolve(m, fb) end
R("TryFire",           "_ZN17AVR4GamePlayerGun7TryFireEv",  0x62DC490)
R("ArmSearchWeaponNo", "_ZN8cItemMgr17ArmSearchWeaponNoEh", 0x5F60264)
R("Arm",               "_ZN8cItemMgr3armEP5cItem",          0x5F561C8)
-- &pG + the GLOBAL armed weapon-no offset, straight out of TryFire:
--   LDR X8,[X24] / MOV W9,#0x504C / LDRB W8,[X8,X9] / CMP W8, gun[0xD20]
local pG        = Offset(GetLibBase(), 0x0A456E48)
local ARMED_OFF = 0x504C

local fireHookOK = false
if InstallDualFireArm then
    local ok, res = pcall(InstallDualFireArm, F.TryFire, ItemMgr, F.ArmSearchWeaponNo, F.Arm,
                          WNO_OFF, pG, ARMED_OFF)
    fireHookOK = ok and res or false
    if not ok then
        LogWarn(TAG .. ": InstallDualFireArm ERRORED: " .. tostring(res))
    elseif not res then
        LogWarn(TAG .. ": InstallDualFireArm returned false — see the [DUALFIRE] log line")
    end
    if fireHookOK and SetDualFireEnabled then pcall(SetDualFireEnabled, state.dualFire) end
else
    LogWarn(TAG .. ": InstallDualFireArm missing — rebuild/redeploy the modloader. "
        .. "Refusing to Lua-hook TryFire (that is what corrupted the heap and crashed the game).")
end

-- ═══════════════════════════════════════════════════════════════════════
-- [3] CLONE HELD GUN (CHEAT) — explicit action, never automatic
-- ═══════════════════════════════════════════════════════════════════════
local G = {}
local function RG(n, m, fb) G[n] = Resolve(m, fb) end
RG("AssignProp",        "_ZN18AVR4GamePlayerPawn10AssignPropE11TSubclassOfI18AVR4GamePlayerPropE9EPropSlot30EGamePlayerPropAssignedContext", 0x62FC290)
RG("SetWeaponNo",       "_ZN17AVR4GamePlayerGun11SetWeaponNoEh", 0x62DFA90)
RG("RegAddProp",        "_ZN18AVR4GamePlayerPawn22RegisterAdditionalPropERK19FAdditionalPropData", 0x62FCCAC)
RG("Malloc",            "_ZN7FMemory6MallocEyj", 0x6674178)
RG("Free",              "_ZN7FMemory4FreeEPv", 0x6674258)
RG("ArmSearchWeaponNo", "_ZN8cItemMgr17ArmSearchWeaponNoEh", 0x5F60264)

-- Pawn offsets, verified in IDA against AssignProp: slots are 3752 + 8*slot and
-- AssignProp caps the slot at 9 (max 3824), while mAdditionalProps starts at
-- 3832 — so TEMP_SLOT=8 (3816) cannot collide with the array.
local SLOTS_BASE, HOLA_BASE, HOLB_BASE = 3752, 3848, 3928
local ADDL_ARR, ADDL_COUNT = 3832, 3840
local TEMP_SLOT = 8
local CLS_OFF, PAWN_OFF = 16, 960

local function A2(o) if not o then return nil end local ok, p = pcall(function() return o:GetAddress() end) if ok and p then return p end return o end

local function findPawn()
  local guns = FindAllOf("VR4GamePlayerGun") or {}
  for _, g in ipairs(guns) do
    local o = ReadPtr(Offset(A2(g), PAWN_OFF))
    if not IsNull(o) then return o end
  end
  return nil
end

-- ── THE CLONE'S WEAPON-ID: an engine limit, not a bug we can code away ──
--
-- RE4 arms ONE cItem per weapon-no. Verified in cItemMgr::ArmSearchWeaponNo: it
-- scans the player's INVENTORY for an item where WeaponId2WeaponNo(itemId) == wno.
-- A weapon-no IS a specific weapon you own. There is no "same gun, second
-- instance" for the engine to arm — so:
--     same id      -> correct bullets, but only ONE gun fires   (confirmed live)
--     different id -> both fire, but the clone IS that other weapon
-- The clone is necessarily ANOTHER WEAPON FROM YOUR INVENTORY. That is the whole
-- truth of this cheat, and no amount of hooking changes it.
--
-- What WAS a real bug: picking the first free id 1..60. That handed a cloned
-- pistol the ROCKET LAUNCHER's id, so it fired explosives — and crashed:
--     cObjLauncher::launch()+372 -> fault 0x78   (rocket[264] model == NULL)
-- Wrong bullets and that tombstone were one thing.
--
-- So: pick a weapon of the SAME TYPE as the source (handgun -> handgun) using the
-- game's own WeaponId2WeaponType, and never a launcher/explosive. A cloned Red9
-- may come out as a Blacktail — same class, sane bullets, no explosives, no
-- crash. If no same-type weapon is free we say so instead of silently handing you
-- a grenade launcher.
RG("GetGunProp", "_ZN17AVR4GamePlayerGun10GetGunPropEh", 0x62E0668)
RG("RocketLauncherClass", "_ZN28AVR4GamePlayerRocketLauncher21GetPrivateStaticClassEv", 0x6494D28)

-- Is this weapon-no a rocket launcher? Asked the way the GAME asks it — launch()
-- itself does exactly this:
--     GunProp = AVR4GamePlayerGun::GetGunProp(armed_wno, a2);
--     PrivateStaticClass = AVR4GamePlayerRocketLauncher::GetPrivateStaticClass(GunProp);
-- (Not via WeaponId2WeaponType: that field is only ever 0/1/2 — a variant TIER,
-- with 34 of 45 weapons sharing type 0 — so it says nothing about the class.)
--
-- A clone armed as a launcher fires rockets through a cObjLauncher that was never
-- set up, which is both the EXPLOSIVES you saw and this crash:
--     cObjLauncher::launch()+372 -> fault 0x78   (rocket[264] model == NULL)
local function isRocketLauncher(wno)
  local ok, res = pcall(function()
    local prop = CallNative(G.GetGunProp, "ppi", wno, 0)
    if IsNull(prop) then return false end
    local cls = ReadPtr(Offset(A2(prop), CLS_OFF))
    local rl  = CallNative(G.RocketLauncherClass, "p")
    if IsNull(cls) or IsNull(rl) then return false end
    return ToHex(cls) == ToHex(rl)   -- no ptr-compare binding; ToHex is exact
  end)
  if not ok then return true end   -- can't tell => assume it is, and skip it
  return res
end

-- Pick an id that (a) no held gun / additional prop is using, (b) the player
-- actually owns (ArmSearchWeaponNo finds it in the inventory), and (c) is NOT a
-- rocket launcher.
--
-- Why a DIFFERENT id at all: RE4 arms ONE cItem per weapon-no, so two guns
-- sharing an id means only one ever fires — that is an engine limit, confirmed
-- live. The clone is therefore necessarily another weapon you own. What was
-- broken before was taking the FIRST free id, which handed a cloned pistol the
-- rocket launcher.
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
      local it = CallNative(G.ArmSearchWeaponNo, "ppi", ItemMgr, w)
      if not IsNull(it) and not isRocketLauncher(w) then return w end
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
  local gun = CallNative(G.AssignProp, "pppii", pawn, cls, TEMP_SLOT, 0)
  if IsNull(gun) then return "AssignProp -> NULL (spawn failed)" end
  gun = A2(gun)
  -- clear the throwaway slot: the clone lives as an ADDITIONAL prop, not a slot
  WriteU64(Offset(pawn, SLOTS_BASE + 8 * TEMP_SLOT), 0)
  WriteU64(Offset(pawn, HOLA_BASE + 8 * TEMP_SLOT), 0)
  WriteU64(Offset(pawn, HOLB_BASE + 8 * TEMP_SLOT), 0)
  -- RegisterAdditionalProp COPIES all 24 bytes into its TArray (verified), so
  -- freeing the temp right after is safe.
  local buf = CallNative(G.Malloc, "pii", 24, 8)
  WritePtr(buf, gun); WritePtr(Offset(buf, 8), holA); WritePtr(Offset(buf, 16), holB)
  CallNative(G.RegAddProp, "ppp", pawn, buf)
  pcall(function() CallNative(G.Free, "vp", buf) end)
  -- The clone needs its OWN weapon-id or the engine only ever arms one of the two
  -- (one cItem per weapon-no — see the note above). Same TYPE as the source,
  -- never explosive.
  local newW = pickDistinctWeapon(pawn, W)
  local note
  if newW then
    CallNative(G.SetWeaponNo, "ipi", gun, newW)
    note = "armed as weapon id=" .. newW .. " (never a launcher). RE4 arms ONE weapon per id, "
           .. "so the clone MUST be a different weapon you own — that is an engine limit, not a bug."
  else
    -- Nothing safe and free: keep the source id. Only one will fire, but it fires
    -- the RIGHT bullets and cannot reach the launcher crash.
    note = "no safe free weapon id — kept id=" .. W .. ", so only ONE of the two will fire "
           .. "(carry another non-launcher weapon and re-clone)."
  end
  local warn = ""
  if not fireHookOK then
    warn = " | WARNING: Simultaneous Fire is not active, so only ONE of the two will fire."
  end
  local msg = (slot == 1 and "2H" or "1H") .. " clone ready — " .. note ..
              " | addl=" .. ReadU32(Offset(pawn, ADDL_COUNT)) .. ". Draw it from the holster & fire." .. warn
  Log(TAG .. ": " .. msg)
  pcall(function() Notify(TAG, msg) end)
  return msg
end

-- ═══════════════════════════════════════════════════════════════════════
-- CONTROLS — old command names kept so notes/muscle memory still work
-- ═══════════════════════════════════════════════════════════════════════
local function save() ModConfig.Save("DualWield", state) end

RegisterCommand("dualwield", function()
    state.enabled = not state.enabled
    if state.enabled then applyDualWieldPatch() else restoreDualWieldPatch() end
    save()
    Notify(TAG, state.enabled and "Two-handed grab ON" or "Two-handed grab OFF")
    return state.enabled and "ON" or "OFF"
end)

RegisterCommand("dualfire", function()
    state.dualFire = not state.dualFire
    if SetDualFireEnabled then pcall(SetDualFireEnabled, state.dualFire) end
    save()
    Notify(TAG, state.dualFire and "Simultaneous fire ON" or "Simultaneous fire OFF")
    return state.dualFire and "ON" or "OFF"
end)

RegisterCommand("dualgun", function(arg)
    local slot = tonumber(arg and arg:gsub("%s", "")) or 0
    if slot ~= 0 and slot ~= 1 then return "usage: dualgun 0 (1-handed slot) | dualgun 1 (2-handed slot)" end
    return cloneSlot(slot)
end)

RegisterCommand("dualwield_status", function()
    local info = TAG .. " v9 | [QOL] two-handed grab=" .. tostring(state.enabled)
        .. " (patched=" .. tostring(patchesApplied) .. ")"
        .. " | [QOL] simultaneous fire=" .. tostring(state.dualFire)
        .. " (native=" .. tostring(fireHookOK) .. ")"
        .. " | [CHEAT] clone = on-demand action only"
    for _, p in ipairs(DW_PATCHES) do
        info = info .. "\n  " .. p.name .. ": " .. (p.addr and ("@" .. ToHex(p.addr)) or "unresolved")
    end
    Log(info)
    return info
end)

-- ═══════════════════════════════════════════════════════════════════════
-- DEBUG MENU — the label tells you what each part costs you
-- ═══════════════════════════════════════════════════════════════════════
if SharedAPI and SharedAPI.DebugMenu then
    local api = SharedAPI.DebugMenu
    api.RegisterToggle("DualWield", "[QOL] Two-Handed Grab (hold 2 guns)",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then applyDualWieldPatch() else restoreDualWieldPatch() end
            save()
        end)
    api.RegisterToggle("DualWield", "[QOL] Simultaneous Fire (both guns shoot)",
        function() return state.dualFire end,
        function(v)
            state.dualFire = v
            if SetDualFireEnabled then pcall(SetDualFireEnabled, v) end
            save()
        end)
    -- Actions, not toggles: a free gun should never appear just because a
    -- switch got left on — you have to ask for it, every time.
    api.RegisterAction("DualWield", "[CHEAT] Clone held 1H gun (free weapon)", function() cloneSlot(0) end)
    api.RegisterAction("DualWield", "[CHEAT] Clone held 2H gun (free weapon)", function() cloneSlot(1) end)
end

Log(TAG .. ": v9.0 loaded — DualFire + DualGun merged in. [QOL] grab=" .. tostring(state.enabled)
    .. " fire=" .. tostring(state.dualFire) .. " (native=" .. tostring(fireHookOK)
    .. ") | [CHEAT] clone = on-demand action, never automatic")
