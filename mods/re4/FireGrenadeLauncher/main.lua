-- mods/re4/FireGrenadeLauncher/main.lua v1.0
-- ═══════════════════════════════════════════════════════════════════════
-- Mine Thrower → FIRE GRENADE LAUNCHER 🔥
--
-- Swaps the Mine Thrower's dart (cEmMine, spawned by SetMine) for the game's
-- own FIRE GRENADE projectile (cObjGreFire — the incendiary), launched from
-- the muzzle with the dart's aim vector. The grenade is a cSubWep: it has real
-- gravity/bounce physics (cSubWep::addSpeed), it NEVER homes, it arcs, falls
-- to the ground and goes up in flames. Muzzle flash / fire sound / reload
-- cycle are untouched (they live in cObjMine::moveFire, not in SetMine).
--
-- MECHANISM (all verified in IDA, libUE4.so v2.3):
--   cObjMine::moveFire → cObjMine::setBullet → SetMine(m1,m2,pos,vel,homing).
--   SetMine allocates a cEmMine from the EM pool. We pre-hook SetMine and,
--   when fire mode is on, "BLOCK" it (returns NULL — setBullet null-checks and
--   skips its VR4ModelInit; verified safe) and instead build the projectile
--   exactly the way AVR4GamePlayerGrenade::ThrowGrenade @0x62ca618 does:
--     1. scan ObjMgr (base=+8, count=+0x10, stride=+0x14) top-down for a slot
--        whose flags u16 @+8 have (f & 0x601)==0        [ThrowGrenade's loop]
--     2. vtbl+0x20 = cObjMgr::memClear(mgr,obj,stride)  → call symbol directly
--     3. vtbl+0x38 = cObjMgr::construct(mgr,obj,41)     → 41 = cObjGreFire
--        (ThrowGrenade's own pairing: type 41 + subtype byte obj[281]=1;
--         type 26/sub 0 = hand grenade, 42/2 = GreLight, 58/3-5 = the eggs)
--     4. append obj to the live list at ObjMgr+0x20 (walk +16 chain)
--     5. obj[281]=1, then cSubWep::ArmInitSubWep(obj, posVec, angVec, fuse)
--        — it picks the correct Bio4 grenade model itself, does the wall-clip
--        pushback and sets pos/ang/fuse. On failure it destroys obj itself.
--     6. velocity Vec3 → obj+1056 (same slot ThrowGrenade's SetThrownVelocity
--        writes), from SetMine's vel arg (optionally scaled — "lob" mode)
--     7. VR model: cModel::VR4ModelInit(obj, cls) — default cls =
--        GetBio4WeaponActor(0x16) = PL_LEON_WEP_22_C, the real fire grenade
--        body. See the note at discoverModelClass (and why v1.1 wrongly
--        blamed this class for the fuse bug's floor-drop).
--
-- WHY SetMine AND NOT setBullet: setBullet computes the muzzle transform +
-- aim assist; SetMine receives the finished pos+vel — we reuse them. But
-- SetMine is ALSO the crossbow-bolt spawner (cObjBow/cObjAdaBow::setAllow,
-- AVR4GamePlayerBow::Fired) and scripted mines pass homing>=2 — so the swap
-- is gated by an in-setBullet flag (pre/post hook pair on setBullet) and
-- only fires for homing<2. Bolts and scripted mines stay stock.
--
-- NO-STALK DARTS (for when fire mode is OFF): with the exclusive upgrade the
-- dart homes, and forcing SetMine's homing arg to 0 is NOT enough — SetMine
-- re-derives it: subtype = (level>2 && arg==0) ? 1 : arg, where level =
-- byte(pG+0x504F). So the setBullet pre-hook clamps that byte to 2 for the
-- duration of the call (post-hook restores it) → a5 computes 0, the re-derive
-- fails, subtype 0 from birth: straight full-speed dart, no target acquire,
-- no half-speed penalty. The byte is the per-shot weapon context, only read
-- inside this window.
--
-- HOOK SAFETY: SetMine/setBullet run at TRIGGER-PULL frequency on the game
-- thread (one-shot state in moveFire, this+1067) — this is a COLD hook, not
-- a per-frame vtable slot like the ones that corrupted the lua_State
-- (see MineThrowerFix v2 header). Lua callbacks here are safe.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "FireGrenadeLauncher"

-- ── resolves (names first — fallback RVAs are from THIS binary, v2.3) ────
local SetMineFn      = Resolve("_Z7SetMinemmP3VecS0_h",                  0x5ECC8D0)
local SetBulletFn    = Resolve("_ZN8cObjMine9setBulletEv",               0x5FB0624)
local ArmInitSubWep  = Resolve("_ZN7cSubWep13ArmInitSubWepER3VecS1_f",   0x5FBB2D8)
local ObjConstruct   = Resolve("_ZN7cObjMgr9constructEP4cObjj",          0x5F89C74)
local ObjMemClear    = Resolve("_ZN7cObjMgr8memClearEPvj",               0x5F89F7C)
local ObjDestroy     = Resolve("_ZN7cObjMgr7destroyEP4cObj",             0x5F89DA4)
local VR4ModelInit   = Resolve("_ZN6cModel12VR4ModelInitEP6UClass",      0x5F835A8)
local GetWepModelCls  = Resolve("_ZN17UVR4DataSingleton16GetWepModelClassEj", 0x6290B1C)
local GetBalModelCls  = Resolve("_ZN17UVR4DataSingleton22GetBallisticModelClassE10EBallistic", 0x6291820)
local GetBio4WepActor = Resolve("_ZN14UVR4PlayerData18GetBio4WeaponActorEh", 0x6392598)
local FixedFrameSet   = Resolve("_ZN10FixedFrameaSEi", 0x5F40734)
local ObjMgrG        = Resolve("ObjMgr", 0xA579000)   -- cObjMgr global instance
local pGG            = Resolve("pG",     0xA456E48)   -- player-globals ptr
local pPLG           = Resolve("pPL",    0xA54AB40)   -- cPlayer* global
local MuzzlePosG     = Offset(GetLibBase(), 0xA57D9FC) -- setBullet's muzzle-pos scratch globals
local EmArrG         = Offset(GetLibBase(), 0xA54AB70) -- cEmMgr pool: base ptr
local EmCntG         = Offset(GetLibBase(), 0xA54AB78) -- cEmMgr pool: u32 count / u32 stride
local EmListG        = Offset(GetLibBase(), 0xA54AB88) -- cEmMgr LIVE list head (next @em+16)
local GUObjChunks    = Offset(GetLibBase(), 0xA785E18) -- GUObjectArray chunk table

-- ── UNTRACKED heap writes ────────────────────────────────────────────────
-- WriteU8/U16/U32/U64/WritePtr all record the original bytes in mod_tracker
-- so unload can "restore" them. For HEAP addresses that is a time bomb: pool
-- objects die / the pool reallocs, and the restore pass on reload walks into
-- unmapped memory → SIGSEGV in release_mod/__clear_cache (tombstone_12 —
-- this exact mod's reload killed the game). Heap writes must go through the
-- untracked /proc/self/mem primitives instead. (WriteF32 is also untracked.)
local function wU64(addr, v) MemWriteU64(PtrToInt(addr), v) end
local function wU8(addr, v)
  local a = PtrToInt(addr)
  MemWriteU64(a, (MemReadU64(a) & ~0xFF) | (v & 0xFF))
end

-- struct offsets (IDA, v2.3)
local OBJ_FLAGS   = 8       -- u16 cObj flags; free slot = (f & 0x601)==0
local OBJ_NEXT    = 16      -- intrusive list next ptr
local OBJ_SUBTYPE = 281     -- u8: 1 = GreFire (fire grenade)
local OBJ_VEL     = 1056    -- Vec3f velocity (SetThrownVelocity's target)
local GREFIRE_TYPE = 41     -- cObjMgr::construct id → cObjGreFire
local PG_WEP_LEVEL = 0x504F -- u8 level byte ("stru_5040.st_value+7" in IDA)

local state = {
  enabled  = true,   -- fire grenades instead of darts
  power    = 0.55,   -- muzzle-speed scale, ALWAYS applied. The dart flies at
                     -- 1500 units — a real grenade throw peaks ~600, so full
                     -- power sails into the sky faster than gravity (20/frame)
                     -- can bring it back. 0.55 = user-tuned launcher punch.
  lob      = true,   -- "fall on ground": scale muzzle speed down → real arc
  lobScale = 0.45,   -- velocity multiplier in lob mode
  muzzleFwd = 400,   -- mm to push the spawn FORWARD along the aim. The fire
                     -- bone sits at the receiver, not the barrel tip — darts
                     -- hid that by crossing 0.5m in one frame; a slow grenade
                     -- visibly pops out of the gun's body without this.
  noStalk  = true,   -- dart mode: suppress exclusive-upgrade homing
  tracer   = true,   -- GRENADE homing ("tracer"): seek the aim-lock target /
                     -- best enemy in the aim cone, like the exclusive darts
  tracerTurn = 0.28, -- steering strength per 40ms tick (0..1)
  fuse     = 6.0,    -- grenade fuse seconds (fallback — GreFire pops on impact;
                     -- long enough that lobbed arcs land before it expires)
  lobUp    = 0.35,   -- lob mode: upward boost as fraction of muzzle speed
  modelSel = "g22",  -- visual: "g<no>" = GetBio4WeaponActor(weaponNo) grenade
                     -- prop (g22 = PL_LEON_WEP_22_C, THE fire grenade body),
                     -- "w<i>" = wep-model table (w9 dynamite),
                     -- "b<i>" = ballistic table (b0-b2 are tiny tracers — NOT
                     -- grenades, learned the hard way)
  cfgv     = 4,      -- config version (migrates stale saved defaults)
  probe    = true,   -- log flight telemetry for the first few shots
}
local saved = ModConfig.Load(TAG)
if saved then
  for k, v in pairs(saved) do if state[k] ~= nil then state[k] = v end end
  if (saved.cfgv or 1) < 3 then
    state.modelSel = "g22"     -- v1 shipped w9, v2 shipped b1 — both wrong
    state.cfgv = 3
  end
  if state.cfgv < 4 then
    if state.fuse == 4.0 then state.fuse = 6.0 end  -- old default expired midair
    state.cfgv = 4
  end
end

-- ── VR model class (lazy) ────────────────────────────────────────────────
-- g22 = UVR4PlayerData::GetBio4WeaponActor(0x16) = PL_LEON_WEP_22_C — the
-- actual fire grenade body (what AssignGrenadeToSlot spawns for the held
-- one). NOTE: v1.1 blacklisted this class as "physics prop free-falls" —
-- that diagnosis was WRONG: the observed floor-drop was the fuse-0 bug
-- (moveNormal's frame-1 explode calls scrAdjust, which projects the entity
-- to the floor before the blast). With the fuse fixed the prop rides the
-- flying Bio4 entity like any VR4Model. Fallbacks if it ever misbehaves:
-- w9 = WeaponDynamite_BP_C (passive enemy-throw model), b3 = mine dart.
-- b0-b2 (BAL01-03) are TINY BULLET TRACERS, not grenade bodies.
local modelCls, modelClsName = nil, nil
local probeShots = 5     -- flight telemetry for this many spawns (fgren_probe re-arms)

local function resolveModelSel(sel)
  local kind, idx = tostring(sel):match("^([wbg])(%d+)$")
  if not kind then return nil, nil end
  local fn = (kind == "w" and GetWepModelCls) or (kind == "b" and GetBalModelCls)
             or GetBio4WepActor
  local cls = CallNative(fn, "pi", tonumber(idx))
  if not cls or PtrToInt(cls) == 0 then return nil, nil end
  local o = UObjectFromPtr(cls)
  return cls, (o and o:GetName() or "?")
end

-- Resolve EVERY spawn — never cache the UClass*. Room transitions GC the
-- soft-loaded class; a cached pointer dangles and SpawnActor silently fails
-- → invisible grenades until reload. The game itself re-resolves per shot
-- (setBullet calls GetBallisticModelClass on every fire), so this is cheap.
local function discoverModelClass()
  local cls, nm = resolveModelSel(state.modelSel)
  if not cls and state.modelSel ~= "w9" then
    cls, nm = resolveModelSel("w9")
    if cls then LogWarn(TAG .. ": model '" .. tostring(state.modelSel) .. "' unavailable — using w9") end
  end
  modelCls, modelClsName = cls, nm
end

-- ── TRACER (grenade homing, like the exclusive-upgrade darts) ────────────
-- The dart's homing (SetMine subtype 1): target = the player's aim-lock em,
-- `*(*(*(pPL+2448)+56)+1096)`, steered in cEmMine's move. cSubWep has no
-- homing code, so we steer OUR grenades: remember a target per spawn and a
-- 40ms game-thread loop rotates vel@+1056 toward it (WriteF32 = untracked).
-- Cold path: only runs while grenades are airborne, a handful at most.
local homingList = {}
local homingLoop = nil

-- FAITHFUL port of the dart's VR acquisition (sub_5ECCE94, flag=1 — what
-- SetMine calls when the legacy lock is empty). Per em:
--   (flags&0x201)==1  alive AND NOT DORMANT (v1's loose check chased dormant
--                     far-away ems = "grenades fly into the void")
--   flags bit1 set, HP s16@0x3F0 >= 1, id in [0x10,0x4F],
--   id-bitmask exclusion, not (IsGanado && subtype==6),
--   dot(launchDir, toEm) > -0.7, LINE OF SIGHT clear (SAT ray), best dot wins.
local EXCL_MASK = 0x680047D201000000
local SatHitCheck = Resolve("_ZN7cSatMgr8hitCheckERK3VecS2_PS0_S3_jj", 0x5D62494)
local IsGanadoFn  = Resolve("_Z8IsGanadoi", 0x5D90640)
local EatMgrG     = Resolve("EatMgr", 0xA540518)

local function emUsable(em)
  if not em or PtrToInt(em) == 0 then return false end
  local fl = ReadU16(Offset(em, 8))
  if (fl & 0x201) ~= 1 or (fl & 2) == 0 then return false end
  local hp = ReadU16(Offset(em, 0x3F0))
  if hp == 0 or hp > 0x7FFF then return false end       -- s16 <= 0 = dead
  local id = ReadU8(Offset(em, 0x118))
  if id < 0x10 or id > 0x4F then return false end
  if id <= 0x3E and ((EXCL_MASK >> id) & 1) == 1 then return false end
  if CallNative(IsGanadoFn, "ii", id) ~= 0 and ReadU8(Offset(em, 0x119)) == 6 then
    return false
  end
  return true
end

local function losClear(fx, fy, fz, em)
  -- reuse the muzzle scratch global's tail as a Vec buffer? NO — use the
  -- grenade's own probe: SAT ray from (fx,fy,fz) held in MuzzlePosG (safe
  -- per-shot scratch) to the em position. hitCheck(this,from,to,0,0,0,0x404000)==0
  WriteF32(MuzzlePosG, fx); WriteF32(Offset(MuzzlePosG, 4), fy); WriteF32(Offset(MuzzlePosG, 8), fz)
  local pp = CallNative(Offset(GetLibBase(), 0x5F81AFC), "ppi", em, 0)  -- getPartsPtr(em,0)
  if not pp or PtrToInt(pp) == 0 then return false end
  return CallNative(SatHitCheck, "ipppppuu", EatMgrG, MuzzlePosG, Offset(pp, 0x80),
    IntToPtr(0), IntToPtr(0), 0, 0x404000) == 0
end

local function acquireTarget(mx, my, mz, dx, dy, dz)
  -- Walk the LIVE em list (head @EmMgr+0x20, next @em+16) instead of the
  -- 1400-slot pool array the C code scans: from Lua every field read is a
  -- guarded syscall, and full-pool scans per shot = "lag lag lag". The live
  -- list holds only the ~dozens of active ems; same filters, same result.
  local best, bestDot = nil, -0.7
  local node = ReadPtr(EmListG)
  local hops = 0
  while node and PtrToInt(node) ~= 0 and hops < 300 do
    if emUsable(node) then
      local ex = ReadF32(Offset(node, 164)) - mx
      local ey = ReadF32(Offset(node, 168)) - my
      local ez = ReadF32(Offset(node, 172)) - mz
      local d = math.sqrt(ex * ex + ey * ey + ez * ez)
      if d > 1 then
        local dot = (ex * dx + ey * dy + ez * dz) / d
        if dot > bestDot and losClear(mx, my, mz, node) then
          best, bestDot = node, dot
        end
      end
    end
    node = ReadPtr(Offset(node, 16))
    hops = hops + 1
  end
  return best
end

local function tracerTick()
  for i = #homingList, 1, -1 do
    local e = homingList[i]
    local dead = (ReadU16(Offset(e.obj, 8)) & 0x601) == 0
      or ReadU8(Offset(e.obj, 280)) ~= GREFIRE_TYPE
      or ReadU8(Offset(e.obj, 281)) ~= 1
    if dead then
      table.remove(homingList, i)
    else
      local gx = ReadF32(Offset(e.obj, 164))
      local gy = ReadF32(Offset(e.obj, 168))
      local gz = ReadF32(Offset(e.obj, 172))
      if not emUsable(e.tgt) then
        -- original dart behavior: no/dead target → re-acquire mid-flight
        -- along the current heading (throttled to every ~240ms)
        e.tgt = nil
        e.cool = (e.cool or 0) - 1
        if e.cool <= 0 then
          e.cool = 6
          local cvx = ReadF32(Offset(e.obj, OBJ_VEL))
          local cvy = ReadF32(Offset(e.obj, OBJ_VEL + 4))
          local cvz = ReadF32(Offset(e.obj, OBJ_VEL + 8))
          local cm = math.sqrt(cvx * cvx + cvy * cvy + cvz * cvz)
          if cm > 10 then
            e.tgt = acquireTarget(gx, gy, gz, cvx / cm, cvy / cm, cvz / cm)
          end
        end
      end
      if emUsable(e.tgt) then
        local tx = ReadF32(Offset(e.tgt, 164)) - gx
        local ty = ReadF32(Offset(e.tgt, 168)) + 800 - gy   -- chest, not feet
        local tz = ReadF32(Offset(e.tgt, 172)) - gz
        local td = math.sqrt(tx * tx + ty * ty + tz * tz)
        if td > 1 then
          local vx = ReadF32(Offset(e.obj, OBJ_VEL))
          local vy = ReadF32(Offset(e.obj, OBJ_VEL + 4))
          local vz = ReadF32(Offset(e.obj, OBJ_VEL + 8))
          local sp = math.sqrt(vx * vx + vy * vy + vz * vz)
          if sp > 10 then
            local k = state.tracerTurn
            vx = vx + (tx / td * sp - vx) * k
            vy = vy + (ty / td * sp - vy) * k
            vz = vz + (tz / td * sp - vz) * k
            -- renormalize so steering never bleeds speed
            local m = math.sqrt(vx * vx + vy * vy + vz * vz)
            if m > 1 then
              local r = sp / m
              WriteF32(Offset(e.obj, OBJ_VEL), vx * r)
              WriteF32(Offset(e.obj, OBJ_VEL + 4), vy * r)
              WriteF32(Offset(e.obj, OBJ_VEL + 8), vz * r)
            end
          end
        end
      end
    end
  end
  if #homingList == 0 and homingLoop then
    CancelDelayedAction(homingLoop); homingLoop = nil
  end
end

local function trackGrenade(obj, mx, my, mz, dx, dy, dz)
  -- track even with no target yet — the tick re-acquires mid-flight, exactly
  -- like the dart's per-move acquisition. cool staggered per grenade so a
  -- shared target's death doesn't make every shell rescan in the same tick.
  local n = #homingList + 1
  homingList[n] = { obj = obj, tgt = acquireTarget(mx, my, mz, dx, dy, dz), cool = n % 6 }
  if not homingLoop and LoopAsync then
    homingLoop = LoopAsync(40, function() pcall(tracerTick) end)
  end
end

-- ── the spawn (mirrors ThrowGrenade @0x62ca618, IDA-verified) ────────────
-- Returns true when the grenade is live; false = pool full / construct
-- failed. Either way the caller BLOCKS the dart (dry shot on failure).
local function spawnFireGrenade(pos, vel)
  local arr    = ReadPtr(Offset(ObjMgrG, 8))
  local cnt    = ReadU32(Offset(ObjMgrG, 0x10))
  local stride = ReadU32(Offset(ObjMgrG, 0x14))
  if not arr or PtrToInt(arr) == 0 or cnt == 0 or stride == 0 then return false end

  local obj = nil
  for i = cnt - 1, 0, -1 do                      -- top-down, like ThrowGrenade
    local o = Offset(arr, i * stride)
    if (ReadU16(Offset(o, OBJ_FLAGS)) & 0x601) == 0 then obj = o; break end
  end
  if not obj then
    -- Pool exhausted: evict OUR OLDEST live grenade (type 41, lowest
    -- construct-id @+272) and take its slot — every trigger pull yields a
    -- grenade, the launcher just self-limits how many are in flight.
    local best, bestId = nil, nil
    for i = cnt - 1, 0, -1 do
      local o = Offset(arr, i * stride)
      if (ReadU16(Offset(o, OBJ_FLAGS)) & 0x601) ~= 0
         and ReadU8(Offset(o, 280)) == GREFIRE_TYPE then
        local id = ReadU32(Offset(o, 272))
        if not bestId or id < bestId then best, bestId = o, id end
      end
    end
    if not best then return false end            -- pool full of OTHER objects (≈never)
    -- DETONATE it (vtable+0x68 = explode), don't silently vanish it midair —
    -- "launcher at capacity" reads as the oldest shell cooking off.
    local vt = ReadPtr(best)
    if vt and PtrToInt(vt) ~= 0 then
      local expl = ReadPtr(Offset(vt, 0x68))
      if expl and PtrToInt(expl) ~= 0 then pcall(CallNative, expl, "vp", best) end
    end
    CallNative(ObjDestroy, "vpp", ObjMgrG, best) -- unlinks + frees, game's own path
    obj = best
  end

  CallNative(ObjMemClear, "vppu", ObjMgrG, obj, stride)
  if CallNative(ObjConstruct, "ippu", ObjMgrG, obj, GREFIRE_TYPE) == 0 then
    return false
  end

  -- link into the live list @ObjMgr+0x20 (construct does NOT link).
  -- Walk is CAPPED: a corrupted/cyclic list must become a log line, not a
  -- frozen game thread.
  local head = ReadPtr(Offset(ObjMgrG, 0x20))
  if not head or PtrToInt(head) == 0 then
    wU64(Offset(obj, OBJ_NEXT), 0)
    wU64(Offset(ObjMgrG, 0x20), PtrToInt(obj))
  else
    local node, hops = head, 0
    while true do
      if PtrToInt(node) == PtrToInt(obj) then break end   -- already linked
      local nxt = ReadPtr(Offset(node, OBJ_NEXT))
      if not nxt or PtrToInt(nxt) == 0 then
        wU64(Offset(node, OBJ_NEXT), PtrToInt(obj))
        wU64(Offset(obj, OBJ_NEXT), 0)
        break
      end
      node = nxt
      hops = hops + 1
      if hops > 4096 then
        LogWarn(TAG .. ": obj list walk exceeded 4096 hops — list corrupt? skipping link")
        break
      end
    end
  end

  wU8(Offset(obj, OBJ_SUBTYPE), 1)               -- GreFire subtype (type 41's pair)

  -- velocity FIRST (we are about to scribble over the vel buffer)
  local vx = ReadF32(vel)
  local vy = ReadF32(Offset(vel, 4))
  local vz = ReadF32(Offset(vel, 8))
  local rawm = math.sqrt(vx * vx + vy * vy + vz * vz)
  local rdx, rdy, rdz = 0, 0, 1
  if rawm > 1 then rdx, rdy, rdz = vx / rawm, vy / rawm, vz / rawm end

  -- push the spawn to the barrel mouth: pos += aimDir * muzzleFwd. Only when
  -- pos is setBullet's muzzle scratch GLOBAL (the VR GunProp branch) — the
  -- other branches pass a pointer into the player model, which we must not
  -- write. ArmInitSubWep's wall-clip check still pulls it back indoors.
  if state.muzzleFwd ~= 0 and PtrToInt(pos) == PtrToInt(MuzzlePosG) then
    local m = math.sqrt(vx * vx + vy * vy + vz * vz)
    if m > 1 then
      local s = state.muzzleFwd / m
      WriteF32(pos, ReadF32(pos) + vx * s)
      WriteF32(Offset(pos, 4), ReadF32(Offset(pos, 4)) + vy * s)
      WriteF32(Offset(pos, 8), ReadF32(Offset(pos, 8)) + vz * s)
    end
  end
  -- Launcher power: the dart's muzzle vector is a FLAT 1500-unit ray (speed
  -- table (-1500,0,0) in gun space); grenade gravity is 20/frame, tuned for
  -- ~600-unit throws. Scale down first or it leaves the map.
  -- TRACER MODE EXCEPTION: homing steers the shot, so keep the thrower's
  -- NATURAL full velocity (like the real homing darts) — no power, no lob.
  if not state.tracer then
    vx, vy, vz = vx * state.power, vy * state.power, vz * state.power
    local speed = math.sqrt(vx * vx + vy * vy + vz * vz)
    -- Lob mode: damp further AND add an upward arc — a mortar toss that drops.
    if state.lob then
      local up = speed * state.lobUp
      vx, vy, vz = vx * state.lobScale, vy * state.lobScale + up, vz * state.lobScale
    end
  end

  -- orientation from the aim vector (mirrors SetMine's atan2 pair). The vel
  -- buffer is setBullet stack it never re-reads after a BLOCKed SetMine —
  -- reuse it as the angle Vec instead of allocating.
  local horiz = math.sqrt(vx * vx + vz * vz)
  WriteF32(vel, -math.atan(vy, horiz))
  WriteF32(Offset(vel, 4), math.atan(vx, vz))
  WriteF32(Offset(vel, 8), 0)

  if CallNative(ArmInitSubWep, "ipppf", obj, pos, vel, state.fuse) == 0 then
    -- ArmInitSubWep already destroyed obj. The vel buffer is trashed, so the
    -- original MUST NOT run — report success ("dry" shot, flash+sound only).
    LogWarn(TAG .. ": ArmInitSubWep failed (grenade model not loadable here?) — dry shot")
    return true
  end
  -- ★ CallNative DROPS 'f' args on int-returning calls (dispatch passes only
  -- x-regs) — ArmInitSubWep's fuse arrived as garbage ≈ 0, and moveNormal
  -- treats fuse==0 as EXPLODE NOW → every grenade detonated at the muzzle,
  -- torching the player. Set the FixedFrame @+1076 directly instead:
  -- FixedFrame::operator=(int) takes the frame count in W1 — no floats.
  CallNative(FixedFrameSet, "vpi", Offset(obj, 1076), math.floor(state.fuse * 30))

  WriteF32(Offset(obj, OBJ_VEL),     vx)
  WriteF32(Offset(obj, OBJ_VEL + 4), vy)
  WriteF32(Offset(obj, OBJ_VEL + 8), vz)

  if state.tracer then
    pcall(trackGrenade, obj,
      ReadF32(pos), ReadF32(Offset(pos, 4)), ReadF32(Offset(pos, 8)),
      rdx, rdy, rdz)
  end

  discoverModelClass()                           -- per-spawn, never cached
  if modelCls and PtrToInt(modelCls) ~= 0 then
    CallNative(VR4ModelInit, "vpp", obj, modelCls)
    -- VR4ModelInit copies the actor's default-visibility byte (actor+0x221)
    -- into the entity draw flag @+0x3E2. The held-grenade prop BP defaults
    -- HIDDEN (revealed by the assign flow) → invisible projectile. Force it.
    wU8(Offset(obj, 0x3E2), 1)
    -- belt & braces: unhide the actor itself (BP-side hide flags). O(1) actor
    -- lookup via the FWeakObjectPtr VR4ModelInit stores at obj+980: chunked
    -- GUObjectArray = *(chunks + 8*(idx>>16)) + 24*(idx&0xFFFF), item[0]=UObject*.
    if state.modelSel:sub(1, 1) == "g" and ReadU8(Offset(obj, 988)) == 1 then
      pcall(function()
        local widx = ReadU32(Offset(obj, 980))
        local chunks = ReadPtr(GUObjChunks)
        if not chunks or PtrToInt(chunks) == 0 then return end
        local chunk = ReadPtr(Offset(chunks, 8 * (widx >> 16)))
        if chunk and PtrToInt(chunk) ~= 0 then
          local aptr = ReadPtr(Offset(chunk, 24 * (widx & 0xFFFF)))
          local act = (aptr and PtrToInt(aptr) ~= 0) and UObjectFromPtr(aptr) or nil
          if act then
            pcall(function() act:Call("SetActorHiddenInGame", false) end)
            if state.probe and probeShots > 0 then
              local root = act:Get("RootComponent")
              local rl = root and root:Get("RelativeLocation")
              Log(TAG .. ": actor=" .. tostring(act:GetName())
                .. " hidden=" .. tostring(act:Get("bHidden"))
                .. " rootRel=" .. (rl and (tostring(rl.X) .. "," .. tostring(rl.Y) .. "," .. tostring(rl.Z)) or "?"))
            end
          end
        end
      end)
    end
  end

  -- ── flight telemetry (first few shots only) ────────────────────────────
  -- Samples the entity every 150ms for ~1s: position, live velocity, flags
  -- (0x601 set = slot recycled/dead), subtype, gravity @+1068, fuse @+1076.
  if state.probe and probeShots > 0 and LoopAsync then
    probeShots = probeShots - 1
    Log(string.format("%s: SPAWN obj=%X in=(%.0f,%.0f,%.0f)|%.0f out=(%.0f,%.0f,%.0f) grav=%.2f pos=(%.0f,%.0f,%.0f)",
      TAG, PtrToInt(obj), ReadF32(pos), ReadF32(Offset(pos,4)), ReadF32(Offset(pos,8)), speed,
      vx, vy, vz, ReadF32(Offset(obj, 1068)),
      ReadF32(Offset(obj, 164)), ReadF32(Offset(obj, 168)), ReadF32(Offset(obj, 172))))
    -- LoopAsync IGNORES the callback's return value — loops only stop via
    -- CancelDelayedAction(handle) (or mod unload). v1.1 leaked 3 loops/shot.
    local n = 0
    local h
    h = LoopAsync(150, function()
      n = n + 1
      local fl = ReadU16(Offset(obj, OBJ_FLAGS))
      local sub = ReadU8(Offset(obj, OBJ_SUBTYPE))
      Log(string.format("%s: t=%dms flags=%04X sub=%d pos=(%.0f,%.0f,%.0f) vel=(%.1f,%.1f,%.1f) fuse=%.1f",
        TAG, n * 150, fl, sub,
        ReadF32(Offset(obj, 164)), ReadF32(Offset(obj, 168)), ReadF32(Offset(obj, 172)),
        ReadF32(Offset(obj, OBJ_VEL)), ReadF32(Offset(obj, OBJ_VEL + 4)), ReadF32(Offset(obj, OBJ_VEL + 8)),
        ReadF32(Offset(obj, 1080))))   -- FixedFrame VALUE lives at +1080 (+1076 is the deadline)
      if (n >= 8 or sub ~= 1) and h then CancelDelayedAction(h) end
    end)
  end
  return true
end

-- ── hooks ────────────────────────────────────────────────────────────────
-- setBullet pre/post: (a) scope the SetMine swap to the Mine Thrower only
-- (SetMine also serves crossbow bolts), (b) no-stalk level-byte clamp.
local inMineFire   = false
local levelPatched = -1   -- original level byte to restore, or -1

local function pgLevelAddr()
  local pg = ReadPtr(pGG)
  if not pg or PtrToInt(pg) == 0 then return nil end
  return Offset(pg, PG_WEP_LEVEL)
end

local okA = RegisterNativeHookAt(SetBulletFn, TAG .. "_setBullet",
  function(this)
    inMineFire = true
    if state.noStalk and not state.enabled then
      local a = pgLevelAddr()
      if a then
        local lv = ReadU8(a)
        if lv > 2 then levelPatched = lv; wU8(a, 2) end
      end
    end
    return nil
  end,
  function(this, ret)
    if levelPatched >= 0 then
      local a = pgLevelAddr()
      if a then wU8(a, levelPatched) end
      levelPatched = -1
    end
    inMineFire = false
    return nil
  end,
  "p")

local okB = RegisterNativeHookAt(SetMineFn, TAG .. "_SetMine",
  function(m1, m2, pos, vel, homing)
    if not inMineFire then return nil end        -- crossbow bolt → untouched
    if homing >= 2 then return nil end           -- scripted/planted → untouched
    if not state.enabled then return nil end     -- dart mode (no-stalk handled above)
    local ok, live = pcall(spawnFireGrenade, pos, vel)
    -- On ANY failure: dry shot, never the dart. Falling back to the dart let
    -- "the original bullet slip thru" whenever the pool was momentarily full
    -- (rapid-fire bursts + ground-fire objects eat slots) — worse than a
    -- visible misfire click.
    if not ok then
      LogWarn(TAG .. ": spawn errored: " .. tostring(live) .. " — dry shot")
    elseif not live then
      LogWarn(TAG .. ": no free obj slot (pool full) — dry shot")
    end
    return "BLOCK"                               -- SetMine → NULL, setBullet skips
  end,
  nil,
  "ppppi")

if not (okA and okB) then
  LogWarn(TAG .. ": hook install failed (setBullet=" .. tostring(okA)
    .. " SetMine=" .. tostring(okB) .. ") — mod inactive")
end

-- ── commands + menu ──────────────────────────────────────────────────────
local function save() ModConfig.Save(TAG, state) end

RegisterCommand("fgren", function()
  state.enabled = not state.enabled; save()
  Notify(TAG, state.enabled and "Mine Thrower shoots FIRE GRENADES 🔥" or "Mine Thrower back to darts")
  return state.enabled and "ON" or "OFF"
end)

RegisterCommand("fgren_lob", function()
  state.lob = not state.lob; save()
  Notify(TAG, state.lob and "Lob arc ON (falls to ground)" or "Full-speed launch")
  return state.lob and "ON" or "OFF"
end)

RegisterCommand("fgren_nostalk", function()
  state.noStalk = not state.noStalk; save()
  Notify(TAG, state.noStalk and "Darts: homing OFF" or "Darts: stock homing")
  return state.noStalk and "ON" or "OFF"
end)

RegisterCommand("fgren_models", function()
  local lines = {}
  for i = 0, 31 do
    local _, nm = resolveModelSel("w" .. i)
    if nm then lines[#lines + 1] = "w" .. i .. "=" .. nm end
  end
  for i = 0, 17 do
    local _, nm = resolveModelSel("b" .. i)
    if nm then lines[#lines + 1] = "b" .. i .. "=" .. nm end
  end
  local out = table.concat(lines, "  ")
  Log(TAG .. ": projectile model classes: " .. out)
  return out
end)

RegisterCommand("fgren_model", function(args)
  local sel = tostring(args or ""):match("^%s*([wbg]%d+)%s*$")
  if not sel then return "usage: fgren_model g<no>|w<i>|b<i>  (g22=fire grenade body, w9=dynamite)" end
  state.modelSel = sel; save()
  modelCls, modelClsName = nil, nil              -- re-resolve on next shot
  return "projectile model = " .. sel .. " (applies on next shot)"
end)

RegisterCommand("fgren_tracer", function(args)
  local n = tonumber(args)
  if n then
    if n < 0.02 or n > 1.0 then return "usage: fgren_tracer [0.02-1.0]  (turn rate; no arg = toggle)" end
    state.tracerTurn = n; save()
    return "tracer turn rate = " .. n
  end
  state.tracer = not state.tracer; save()
  if not state.tracer then homingList = {} end
  Notify(TAG, state.tracer and "Grenade tracer ON — they seek enemies 🎯" or "Tracer OFF — ballistic")
  return state.tracer and "ON" or "OFF"
end)

RegisterCommand("fgren_muzzle", function(args)
  local n = tonumber(args)
  if not n or n < 0 or n > 1500 then
    return "usage: fgren_muzzle <0-1500>  (mm forward from the fire bone; current " .. state.muzzleFwd .. ")"
  end
  state.muzzleFwd = n; save()
  return "muzzle forward offset = " .. n .. "mm"
end)

RegisterCommand("fgren_power", function(args)
  local p = tonumber(args)
  if not p or p < 0.05 or p > 1.5 then
    return "usage: fgren_power <0.05-1.5>  (current " .. state.power .. "; 0.4≈hard throw, 1.0=dart speed)"
  end
  state.power = p; save()
  return "launch power = " .. p
end)

RegisterCommand("fgren_probe", function()
  probeShots = 5
  return "probe re-armed for the next 5 shots — fire, then read the log"
end)

RegisterCommand("fgren_status", function()
  return TAG .. " enabled=" .. tostring(state.enabled) .. " power=" .. state.power
    .. " lob=" .. tostring(state.lob) .. " (x" .. state.lobScale .. " up+" .. state.lobUp
    .. ") tracer=" .. tostring(state.tracer) .. " (k" .. state.tracerTurn
    .. " live=" .. #homingList .. ") noStalk=" .. tostring(state.noStalk)
    .. " fuse=" .. state.fuse .. " model=" .. tostring(state.modelSel)
    .. " (" .. tostring(modelClsName or "?") .. ") hooks=" .. tostring(okA and okB)
end)

if SharedAPI and SharedAPI.DebugMenu then
  SharedAPI.DebugMenu.RegisterToggle(TAG, "MineThrower: Fire Grenades",
    function() return state.enabled end,
    function(v) state.enabled = v; save() end)
  SharedAPI.DebugMenu.RegisterToggle(TAG .. "_lob", "Fire Grenades: Lob Arc",
    function() return state.lob end,
    function(v) state.lob = v; save() end)
  SharedAPI.DebugMenu.RegisterToggle(TAG .. "_ns", "MineThrower: No-Homing Darts",
    function() return state.noStalk end,
    function(v) state.noStalk = v; save() end)
  SharedAPI.DebugMenu.RegisterToggle(TAG .. "_tr", "Fire Grenades: Tracer (seek)",
    function() return state.tracer end,
    function(v) state.tracer = v; save(); if not v then homingList = {} end end)
end

Log(TAG .. ": v1.0 loaded — fire grenades=" .. tostring(state.enabled)
  .. " lob=" .. tostring(state.lob) .. " noStalk=" .. tostring(state.noStalk)
  .. " hooks=" .. tostring(okA and okB))
