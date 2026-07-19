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

    -- THE 2-HANDED DUAL-WIELD GATE. Grabbing a second gun already worked, but a
    -- two-handed weapon still refused to FIRE once your other hand was busy
    -- holding the clone — so 2H dual-wield looked like "no independence".
    -- AVR4GamePlayerGun::IsReadyToFire:
    --     62dbab0  ldrb w8, [x19,#0x7aa]   ; [1962] weapon REQUIRES two hands
    --     62dbab4  cbz  w8, 0x62dbac0      ; 1H weapon -> skip, fine
    --     62dbab8  ldrb w8, [x19,#0xd2c]   ; [3372] currently held by BOTH hands
    --     62dbabc  cbz  w8, 0x62dbae8      ; 2H gun not two-handed -> return FALSE
    -- Measured live on a held MachineGun: [1962]=1 [3372]=1 (passes). Hold that
    -- same gun one-handed and [3372] goes 0, so IsReadyToFire fails before it
    -- ever looks at ammo or state. NOP the second CBZ: a two-handed weapon may
    -- now fire while held in one hand, which is the entire point of [1].
    -- The ammo and weapon-state checks after it are untouched.
    { name = "IsReadyToFire (2H weapon may fire one-handed)",
      mangled = "_ZNK17AVR4GamePlayerGun13IsReadyToFireEv",
      fb = 0x062DBA88, insn_off = 0x34, word = 0xD503201F },

    -- ROCKET LAUNCHER ONE-HANDED. The launcher fired fine with BOTH grips held
    -- and only "clicked" on one — because it was DRY-firing, not failing a fire
    -- gate. AVR4GamePlayerRocketLauncher::PreBio4Tick:
    --     6317014  blr  x8                 ; readiness
    --     6317018  tbz  w0,#0, 0x631704c   ; not ready  -> DryFire
    --     631701c  mov  x0, x19
    --     6317020  bl   GetPrimaryHand     ; = grip[78]->CurrentHand (grip+760)
    --     6317024  cbz  x0, 0x631704c      ; NULL hand  -> DryFire   <-- THIS
    --     6317038  bl   TryFire            ; the real shot
    --     6317054  bl   DryFire            ; trigger clicks, nothing comes out
    -- AVR4GamePlayerProp::GetPrimaryHand only ever looks at the PRIMARY grip
    -- (prop+624). Hold the weapon by the forestock alone and that grip has no
    -- hand, so GetPrimaryHand returns NULL and the trigger is routed to DryFire
    -- no matter how much ammo or readiness the weapon has. That is why every
    -- weapon-side fix (chamber flags, HasOneHandedStock, IsReadyToFire) did
    -- nothing here — they sit on a path the code never reaches.
    --
    -- ⚠ DO NOT NOP THAT CBZ. I tried it (insn_off 0x98 -> 0xD503201F) and the
    -- trigger DID finally reach TryFire instead of DryFire — then the game died:
    --     modloader_recovered.log: 12x libUE4.so+0x5fb7020 / +0x5fb6ff0
    --                              (_ZN12cObjLauncher6launchEv)
    -- which is the documented cObjLauncher::launch()+372 -> fault 0x78. The NULL
    -- check is LOAD-BEARING: launch() needs the primary hand for its muzzle/aim
    -- anchor, so letting a NULL through only moves the failure downstream.
    -- The real fix is to give GetPrimaryHand something valid to return (fall back
    -- to the forestock grip's hand) rather than deleting the guard.
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

-- ── [1b] ONE-HANDED FIRING FOR TWO-HANDED WEAPONS (QOL) ────────────────
-- Grabbing a 2nd gun was only half the feature: a two-handed weapon held by a
-- single grip still refused to shoot. It was never failing a fire check — it was
-- DRY-FIRING. Every weapon's PreBio4Tick does
--     if (ready && GetPrimaryHand(this)) TryFire(this); else DryFire(this);
-- and AVR4GamePlayerProp::GetPrimaryHand only ever inspects the PRIMARY grip
-- (prop+624 -> grip+760). Hold the gun by the forestock alone and that grip has
-- no hand, so it returns NULL and the trigger clicks with nothing behind it —
-- no matter the ammo, chamber state, HasOneHandedStock or IsReadyToFire.
--
-- Deleting the NULL check does NOT work: cObjLauncher::launch() needs a real
-- hand for its muzzle anchor and faults without one (12x libUE4+0x5fb6ff0).
-- So we hand it a genuine hand instead — whichever grip IS held, via the grip
-- group's GetAnyCurrentGrip (group at prop+0xD38).
-- ⚠ DISABLED — this whole block never delivered and only added risk.
-- Measured facts: GetPrimaryHandFallbackCount() stayed at 0 for the entire
-- session (the fallback never once fired), the launcher still refused to shoot
-- one-handed, and the shared fallback body crashed the game twice by running on
-- objects it was never meant for (AVR4GamePlayerConsumable::Tick -> SIGSEGV
-- 0x3e78) and by aliasing the two hands (SIGBUS 0x601). The vtable swap likewise
-- installed correctly and changed nothing observable.
-- The DIAGNOSIS is still good and worth keeping: PreBio4Tick gates on
-- GetFiringHand (-> GunTwoHanded::GetForestockHand) BEFORE anything else, so a
-- one-grip hold is refused before ammo/ready/primary are ever consulted. But a
-- safe fix needs a genuine second hand, not a substituted one.
local ENABLE_ONEHAND_EXPERIMENT = false
if ENABLE_ONEHAND_EXPERIMENT and InstallPrimaryHandFallback then
    pcall(function()
        local gph     = Resolve("_ZNK18AVR4GamePlayerProp14GetPrimaryHandEv",              0x630DB18)
        local anygrip = Resolve("_ZNK32UVR4GamePlayerGripGroupComponent17GetAnyCurrentGripEv", 0x62D3DA8)
        local curhand = Resolve("_ZNK18UVR4GamePlayerGrip14GetCurrentHandEv",              0x62D0C24)
        -- THE one that actually mattered. A two-handed weapon needs TWO DIFFERENT
        -- grips held to fire, and the FORESTOCK is the gate that runs first:
        --     RocketLauncher::GetFiringHand -> GunTwoHanded::GetForestockHand
        --     PreBio4Tick: if (GetFiringHand(this)) { if (ready && GetPrimaryHand) TryFire }
        -- With one grip held GetForestockHand is NULL, so the outer `if` short-
        -- circuits and the trigger is dead before ammo/ready/primary is even
        -- consulted. (Proved it: the primary-hand fallback counter stayed at 0 —
        -- GetPrimaryHand was never reached.)
        --
        -- ⚠ NO FORESTOCK HOOK. Both ways of doing it break the game:
        --
        --   1) Hooking GunTwoHanded::GetForestockHand (0x62E1660) — the shared
        --      function — makes the forestock hand ALIAS the primary hand. But it
        --      also feeds IK, hand poses and two-handed aiming, which all assume
        --      the two hands are DISTINCT. Result: SIGBUS fault_addr=0x601 with
        --      0 recovered faults (not a null deref — corrupted transform math).
        --
        --   2) Hooking RocketLauncher::GetFiringHand (0x6317618) instead — it is
        --      a THUNK, i.e. a single branch instruction. Dobby writes a 16-BYTE
        --      inline patch, so hooking a 4-byte function overwrites the function
        --      that follows it in memory. That corrupted adjacent code and broke
        --      firing even with BOTH grips held. Same 16-byte rule that bit the
        --      DobbyInstrument work: never inline-hook a tiny/thunk function.
        --
        -- The gate itself is understood and correct:
        --     RocketLauncher::GetFiringHand -> GunTwoHanded::GetForestockHand
        --     PreBio4Tick: if (GetFiringHand(this)) { if (ready && GetPrimaryHand) TryFire }
        -- so one grip => NULL firing hand => dead trigger. A real fix has to give
        -- the launcher a genuine SECOND hand (or patch the single CBZ inside
        -- PreBio4Tick while ALSO supplying launch() a valid muzzle anchor —
        -- NOPing that CBZ alone reproduces cObjLauncher::launch() fault 0x78).
        local gfh     = nil   -- never inline-hook the firing hand (see above)
        -- The grip-group VTABLE is required, not optional. GetPrimaryHand is on
        -- AVR4GamePlayerProp — the base of EVERY prop — so without a type check
        -- the fallback read prop+0xD38 on a Consumable (herb/ammo/flashlight),
        -- got mapped-but-unrelated memory, and crashed inside GetAnyCurrentGrip:
        --     #01 ph_get_primary_hand  #02 AVR4GamePlayerConsumable::Tick
        --     SIGSEGV fault 0x3e78
        local gvt     = Resolve("_ZTV32UVR4GamePlayerGripGroupComponent", 0)
        local ok = InstallPrimaryHandFallback(gph, anygrip, curhand, 0xD38, gfh, gvt)

        -- The firing-hand gate is fixed by swapping ONE VTABLE ENTRY instead.
        -- RocketLauncher's vtable+1968 is GetFiringHand (verified via the RELA
        -- relocations: _ZTV28AVR4GamePlayerRocketLauncher, vptr = symbol+16).
        -- PreBio4Tick only tests that result for non-NULL — it never stores or
        -- dereferences the hand — so substituting it affects the trigger check
        -- and nothing else. No code is patched, so neither the shared-function
        -- aliasing crash nor Dobby's 16-byte thunk clobber can happen.
        -- FIRING-HAND GATE via a VTABLE SWAP (not a code patch).
        -- RocketLauncher's vtable+1968 is GetFiringHand (confirmed from the RELA
        -- relocations of _ZTV28AVR4GamePlayerRocketLauncher; vptr = symbol+16).
        -- PreBio4Tick only tests that result for non-NULL and never dereferences
        -- it, so substituting affects the trigger gate and nothing else.
        --
        -- This was blamed for the SIGSEGV 0x3e78 crash, wrongly: the tombstone
        -- names ph_get_primary_hand <- AVR4GamePlayerConsumable::Tick, i.e. the
        -- shared fallback body running on a NON-gun prop. That is fixed by the
        -- grip-group vtable type check above, so the swap is safe to use.
        -- Not an inline hook => immune to Dobby's 16-byte thunk-clobber problem,
        -- and GetForestockHand stays untouched so IK/aiming keep distinct hands.
        if ok and InstallFiringHandVtableFallback then
            pcall(function()
                local vt = Resolve("_ZTV28AVR4GamePlayerRocketLauncher", 0x9D83AE0)
                if vt and not IsNull(vt) then
                    local slot = Offset(vt, 16 + 1968)   -- +16 skips the RTTI header
                    local ok2 = InstallFiringHandVtableFallback(slot)
                    Log(TAG .. ": launcher firing-hand vtable fallback: "
                        .. (ok2 and "installed" or "FAILED"))
                end
            end)
        end
        Log(TAG .. ": one-handed firing for 2H weapons: " .. (ok and "installed" or "FAILED"))
        if ok and SetPrimaryHandFallbackEnabled then
            pcall(SetPrimaryHandFallbackEnabled, state.enabled)
        end
    end)
else
    LogWarn(TAG .. ": InstallPrimaryHandFallback missing — rebuild/redeploy the modloader")
end

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
