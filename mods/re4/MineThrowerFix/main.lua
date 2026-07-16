-- mods/re4/MineThrowerFix/main.lua v2.0
-- ═══════════════════════════════════════════════════════════════════════
-- Mine Thrower — fire continuously without the slow reload.
--
-- The Mine Thrower ("grenade launcher") is AVR4GamePlayerMineThrower, a subclass
-- with NO fire/reload overrides, so it inherits the base gun path AND the ROM
-- weapon object cObjMine. Every OTHER weapon has an ...::InstantReload; the Mine
-- Thrower does not, so after each shot cObjMine::moveReload() plays a full
-- *animated* reload (motionSet + sound + wait for the animation) before you can
-- fire again. GetAmmoCheatState=2 already makes the AMMO infinite, but the
-- animation pause is what makes it feel like "reload after every shot."
--
-- Fix (verified in IDA + confirmed live: Mine Thrower fired ~18x in a row):
--   moveReload is a per-frame state machine (this+1067 = "reload in progress").
--   - 1st call (this+1067==0): let the ORIGINAL run so the next mine is properly
--     re-chambered (skipping this entirely — a full block — left the weapon
--     stuck after one shot).
--   - 2nd call (this+1067==1): do the ammo refill (cItemMgr::reload) and mark the
--     reload DONE, then block the rest of the animation. So the reload completes
--     in ~2 frames instead of the full animation = continuous fire.
--
-- v2.0 — the hook moved into the MODLOADER, in pure C++.
--   v1 called that logic from a LUA CALLBACK and its header claimed "Cold hook
--   (only runs during a Mine Thrower reload). 0 crashes under stress." Both
--   halves were wrong. IDA says moveReload is a VTABLE slot:
--       9d46a40 -> cObjMine::moveFire
--       9d46a48 -> cObjMine::moveDown
--       9d46a50 -> cObjMine::moveReload   <- this
--       9d46a58 -> cObjWep::moveDrop
--   so it is dispatched from cObjWep::move, on the game thread, every frame the
--   weapon is reloading — and since this mod's entire purpose is to reload
--   constantly, it runs constantly. That callback raced the shared lua_State and
--   the corruption surfaced nowhere near here: a jump to pc=0x24cc, SIGSEGV in
--   FMallocBinned2 during GC, a fault inside atan2f. Exactly the same class as
--   the ScoreControl / DualFire / Tyrant / NoVignette hot-hook crashes, and
--   exactly as invisible.
--
--   Behaviour is unchanged — the same four memory ops and one call now run as C
--   with no lua_State involved. Rule, earned repeatedly: NEVER put a Lua callback
--   on a hot native function, and a move()/vtable slot is ALWAYS hot.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "MineThrowerFix"

local MoveReload = Resolve("_ZN8cObjMine10moveReloadEv", 0x5FB0A20)
local Reload0    = Resolve("_ZN8cItemMgr6reloadEv", 0x5F62790)   -- cItemMgr::reload() (current weapon)
local ItemMgr    = Offset(GetLibBase(), 0xA561810)

local RELOAD_IN_PROGRESS = 1067   -- cObjMine flag: reload started
local RELOAD_SUBFLAG     = 1066

local state = { enabled = true }
local saved = ModConfig.Load("MineThrowerFix")
if saved and saved.enabled ~= nil then state.enabled = saved.enabled end

local hookOK = false
if InstallMineThrowerFastReload then
  local ok, res = pcall(InstallMineThrowerFastReload, MoveReload, ItemMgr, Reload0,
                        RELOAD_IN_PROGRESS, RELOAD_SUBFLAG)
  hookOK = ok and res or false
  -- Say WHY on failure. A bare pcall once hid a type error in DualFire and the
  -- mod cheerfully reported "loaded" with the hook silently absent.
  if not ok then
    LogWarn(TAG .. ": InstallMineThrowerFastReload ERRORED: " .. tostring(res)
      .. " | moveReload=" .. tostring(MoveReload) .. " itemMgr=" .. tostring(ItemMgr)
      .. " reload=" .. tostring(Reload0))
  elseif not res then
    LogWarn(TAG .. ": InstallMineThrowerFastReload returned false — see the [MINETHR] log line")
  end
  if hookOK and SetMineThrowerEnabled then pcall(SetMineThrowerEnabled, state.enabled) end
else
  LogWarn(TAG .. ": InstallMineThrowerFastReload missing — rebuild/redeploy the modloader. "
    .. "Refusing to Lua-hook cObjMine::moveReload (a vtable slot off cObjWep::move — "
    .. "that is what corrupted the heap and crashed the game).")
end

local function setEnabled(v)
  state.enabled = v
  if SetMineThrowerEnabled then pcall(SetMineThrowerEnabled, v) end
  ModConfig.Save("MineThrowerFix", state)
end

RegisterCommand("minethrower", function()
  setEnabled(not state.enabled)
  Notify(TAG, state.enabled and "Mine Thrower fast reload ON" or "OFF")
  return state.enabled and "ON" or "OFF"
end)

RegisterCommand("minethrower_status", function()
  return TAG .. " v2 (native fast reload) enabled=" .. tostring(state.enabled)
    .. " nativeHook=" .. tostring(hookOK)
end)

if SharedAPI and SharedAPI.DebugMenu then
  SharedAPI.DebugMenu.RegisterToggle("MineThrowerFix", "Mine Thrower Fast Reload",
    function() return state.enabled end,
    function(v) setEnabled(v) end)
end

Log(TAG .. ": v2.0 loaded — fast reload runs in PURE C++ (no Lua on cObjMine::moveReload) | nativeHook="
  .. tostring(hookOK) .. " enabled=" .. tostring(state.enabled))
