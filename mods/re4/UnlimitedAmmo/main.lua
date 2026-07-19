-- mods/re4/UnlimitedAmmo/main.lua v7.0
-- ═══════════════════════════════════════════════════════════════════════
-- Unlimited Ammo — PURE NATIVE byte-patches. NO per-frame Lua hooks.
--
-- v6 — dropped all per-frame Lua hooks (that was the lag) and byte-patched
--   the ammo-count fns to `mov w0,#999; ret`.
-- v7 — THE GRENADE/ROCKET LAUNCHER FIX. Launcher-type weapons OVERRIDE the
--   base ammo fns and gate reload on their OWN loaded-round byte, so the base
--   patch never touched them. Two additions:
--     (a) GetAmmoCheatState() -> 2  = the game's OWN infinite-ammo cheat.
--         AVR4GamePlayerRocketLauncher::Fired only empties the chamber
--         (this+4328 = 0 -> forces reload) when the cheat state != 2. Forcing
--         it to 2 means the chamber is never emptied = fires forever, no reload.
--         This is the native, intended path — covers every Fired() that checks it.
--     (b) the subclass GetCurrentAmmo overrides (RocketLauncher/Bow/HarpoonGun)
--         -> 999 so their reload-checks also pass.
--   All verified in IDA (libUE4.so). Zero per-frame overhead. Fully toggleable.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "UnlimitedAmmo"
local state = { enabled = true }
local saved = ModConfig.Load("UnlimitedAmmo")
if saved and saved.enabled ~= nil then state.enabled = saved.enabled end

local RET = 0xD65F03C0                        -- ret
local function mov_w0(imm) return 0x52800000 | ((imm & 0xFFFF) << 5) end  -- movz w0,#imm

-- Each: patch the function prologue to `mov w0,#val ; ret`.
--   val 999 = "plenty of ammo / loaded" for count + reload checks.
--   val 2   = GetAmmoCheatState "infinite ammo" mode (Fired() skips depletion).
local AMMO_FNS = {
  -- base ammo-count fns (handguns/rifles/shotguns/etc.)
  { name="GetCurrentAmmo",       mangled="_ZNK17AVR4GamePlayerGun14GetCurrentAmmoEb", fb=0x62E016C, val=999 },
  { name="bulletNumCurrent",     mangled="_ZN8cItemMgr16bulletNumCurrentEv",          fb=0x5F63D2C, val=999 },
  { name="bulletNum_ITEM_ID",    mangled="_ZN8cItemMgr9bulletNumE7ITEM_ID",           fb=0x5F63C60, val=999 },
  { name="bulletNum_cItem",      mangled="_ZN8cItemMgr9bulletNumEP5cItem",            fb=0x5F63F24, val=999 },
  { name="bulletNumTotal",       mangled="_ZN8cItemMgr14bulletNumTotalE7ITEM_ID",     fb=0x5F6393C, val=999 },
  { name="cObjWep_bulletNum",    mangled="_ZN7cObjWep9bulletNumEv",                   fb=0x5FC0EE0, val=999 },
  -- subclass GetCurrentAmmo overrides (launcher/bow/harpoon reload-checks)
  { name="RocketLauncher_ammo",  mangled="_ZNK28AVR4GamePlayerRocketLauncher14GetCurrentAmmoEb", fb=0x6317534, val=999 },
  { name="Bow_ammo",             mangled="_ZNK17AVR4GamePlayerBow14GetCurrentAmmoEb",            fb=0x62C5E44, val=999 },
  { name="HarpoonGun_ammo",      mangled="_ZNK24AVR4GamePlayerHarpoonGun14GetCurrentAmmoEb",     fb=0x62EC3CC, val=999 },
  -- the game's native infinite-ammo cheat: launcher Fired() won't empty the chamber
  { name="GetAmmoCheatState",    mangled="_ZN17FVR4DebugSettings17GetAmmoCheatStateEv",          fb=0x629B784, val=2   },
}

-- Raw instruction patches (not simple return-value overrides).
local RAW_PATCHES = {
  -- base Gun::PreBio4Tick @0x62D9A68: the "firmly-held" gate (B.NE) skips the
  -- native magazine top-up (InfiniteAmmoUpdate) when a weapon is held one-handed,
  -- so one-handed weapons drain and force a reload. NOP it so the top-up (already
  -- gated on GetAmmoCheatState==2 just after) runs regardless of grip.
  { name="PreBio4Tick_gripGate", rva = 0x62D9A68, from = 0x54000321, to = 0xD503201F },

  -- ── THE CHICAGO-TYPEWRITER FIX (this is a GAME bug, not a mod bug) ──────
  -- Weapons whose magazine capacity is the sentinel 0x8000 ("infinite") break
  -- the moment ANY infinite-ammo path is active — including the game's OWN
  -- built-in ammo cheat, with no mods loaded at all.
  --
  -- WeaponId2ChargeNum (0x5F555E4) ends with:
  --     5f557ac  lsl  w8, w0, #1       ; 2 * capacity
  --     5f557b0  cmp  w0, #0x8000      ; the "infinite" sentinel
  --     5f557b4  mov  w9, #-0x8000     ; 0xFFFF8000 == -32768
  --     5f557b8  csel w0, w9, w8, eq   ; sentinel -> -32768, else 2*capacity
  -- and cItemMgr::bulletNum's cheat branch then does
  --     if ((uint16)cur >= (uint16)cap) return cur; else return cap;
  -- The compare is uint16 but the RETURN is the raw value, so the sentinel
  -- escapes as -32768. Every caller that treats the count as signed sees
  -- massively negative ammo and the weapon reads as broken/empty.
  --
  -- Affected item ids (capacity table word_4320104 contains 0x8000):
  --     52, 83  [106,20,25,30,35,40,50,0x8000]  <- Chicago Typewriter class, max upgrade
  --     55      [26,3,4,5,6,8,10,0x8000]        <- Handcannon class, max upgrade
  --     40, 65  [70,0x8000,0x8000,...]          <- NOT special-cased anywhere: broken at ANY level
  -- (bulletNum special-cases only 52/55/83 — ids 40 and 65 fall to `default`.)
  --
  -- ⚠ DO NOT PATCH THE 0x8000 SENTINEL OUT OF WeaponId2ChargeNum.
  -- I tried exactly that (`mov w9,#-0x8000` -> `mov w9,#999`) to stop the
  -- negative count leaking out of cItemMgr::bulletNum, and it made the affected
  -- weapons UNFIREABLE. 0x8000 is not just a capacity value, it is a CONTRACT:
  --     cItemMgr::trigger:
  --         if (itemId != 109 && (uint16)WeaponId2ChargeNum(id,lvl) != 0x8000) {
  --             ...entire ammo-consumption block...
  --         }
  --         return 1;
  -- i.e. the sentinel is what makes trigger() SKIP consumption for an infinite
  -- weapon. Rewrite it and those weapons fall into the consumption path instead,
  -- which with GetAmmoCheatState()==2 takes `return 0` without consuming — the
  -- infinite behaviour is gone. cItemMgr::use/combine/reloadable/reload and
  -- armReloadNumBullets test the same sentinel. Any fix has to preserve it and
  -- clamp only where the value is RETURNED as a count.

  -- ── MACHINE GUN "CAN'T SHOOT" FIX (Chicago Typewriter / SMG class) ───────
  -- Ammo was never the blocker here. Measured live on a held
  -- VR4GamePlayer_Wep12_BP_C (a MachineGun subclass):
  --     [4380] chamber/bolt flag = 0   <-- the ONLY failing gate
  --     [1962] grip = 1, [3372] override = 1   -> (!grip || override) = true  OK
  --     vtable+1976 = GetCurrentAmmo (patched to 999)                         OK
  -- Writing 1 to [4380] does NOT stick: the tick re-clears it every frame, so
  -- the bolt-ready state never latches and the weapon can never fire.
  --
  -- AVR4GamePlayerMachineGun::IsReadyToFire is just:
  --     62f1c24  mov  w8, #0x111c        ; 4380
  --     62f1c28  ldrb w8, [x0, x8]
  --     62f1c2c  cbz  w8, 0x62f1c34      ; chamber empty -> return 0
  --     62f1c30  b    AVR4GamePlayerGun::IsReadyToFire
  --     62f1c34  mov  w0, wzr / ret
  -- NOP the CBZ so it always tail-calls the base check, which already passes.
  -- This only removes the SMG's extra bolt gate; the base ammo/grip/state
  -- checks still apply, so nothing else is loosened.
  { name="MachineGun_chamberGate", rva = 0x62F1C2C, from = 0x34000048, to = 0xD503201F },
}

local function apply()
  local n = 0
  for _, f in ipairs(AMMO_FNS) do
    pcall(function()
      local a = Resolve(f.mangled, f.fb)
      if not a or IsNull(a) then Log(TAG .. ": [WARN] " .. f.name .. " unresolved"); return end
      f.addr = a
      if not f.o0 then f.o0 = ReadU32(a); f.o1 = ReadU32(Offset(a, 4)) end
      WriteU32(a, mov_w0(f.val)); WriteU32(Offset(a, 4), RET)
      n = n + 1
    end)
  end
  for _, p in ipairs(RAW_PATCHES) do
    pcall(function()
      local a = Offset(GetLibBase(), p.rva)
      if ReadU32(a) == p.from then WriteU32(a, p.to); n = n + 1 end
    end)
  end
  Log(TAG .. ": ON — " .. n .. " patches (ammo->999, cheat=2, one-handed top-up), native, no Lua hooks")
end

local function restore()
  for _, f in ipairs(AMMO_FNS) do
    if f.addr and f.o0 then pcall(function() WriteU32(f.addr, f.o0); WriteU32(Offset(f.addr, 4), f.o1) end) end
  end
  for _, p in ipairs(RAW_PATCHES) do
    pcall(function()
      local a = Offset(GetLibBase(), p.rva)
      if ReadU32(a) == p.to then WriteU32(a, p.from) end
    end)
  end
  Log(TAG .. ": OFF — ammo fns + raw patches restored")
end

if state.enabled then apply() end

RegisterCommand("unlimitedammo", function()
  state.enabled = not state.enabled
  if state.enabled then apply() else restore() end
  ModConfig.Save("UnlimitedAmmo", state)
  Notify(TAG, state.enabled and "Unlimited Ammo ON" or "Unlimited Ammo OFF")
  return state.enabled and "ON" or "OFF"
end)

RegisterCommand("unlimitedammo_status", function()
  local s = TAG .. ": enabled=" .. tostring(state.enabled)
  for _, f in ipairs(AMMO_FNS) do
    s = s .. "\n  " .. f.name .. " (=" .. f.val .. "): " .. (f.addr and ("@" .. ToHex(f.addr)) or "unresolved")
  end
  return s
end)

if SharedAPI and SharedAPI.DebugMenu then
  SharedAPI.DebugMenu.RegisterToggle("UnlimitedAmmo", "Unlimited Ammo",
    function() return state.enabled end,
    function(v) state.enabled = v; if v then apply() else restore() end; ModConfig.Save("UnlimitedAmmo", state) end)
end

Log(TAG .. ": v7.0 loaded — native byte-patch (incl. grenade/rocket launcher via GetAmmoCheatState=2) | enabled=" .. tostring(state.enabled))
