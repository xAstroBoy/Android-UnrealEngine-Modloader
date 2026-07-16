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
