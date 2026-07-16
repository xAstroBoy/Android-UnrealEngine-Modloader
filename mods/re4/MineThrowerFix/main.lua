-- mods/re4/MineThrowerFix/main.lua
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
-- Fix (verified in IDA + confirmed live: Mine Thrower fired ~18× in a row):
--   moveReload is a per-frame state machine (this+1067 = "reload in progress").
--   - 1st call (this+1067==0): let the ORIGINAL run so the next mine is properly
--     re-chambered (skipping this entirely — a full block — left the weapon
--     stuck after one shot).
--   - 2nd call (this+1067==1): do the ammo refill (cItemMgr::reload) and mark the
--     reload DONE, then block the rest of the animation. So the reload completes
--     in ~2 frames instead of the full animation = continuous fire.
--   Cold hook (only runs during a Mine Thrower reload). 0 crashes under stress.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "MineThrowerFix"

local Reload0 = Resolve("_ZN8cItemMgr6reloadEv", 0x5F62790)   -- cItemMgr::reload() (current weapon)
local ItemMgr = Offset(GetLibBase(), 0xA561810)

local RELOAD_IN_PROGRESS = 1067   -- cObjMine flag: reload started
local RELOAD_SUBFLAG     = 1066

local hookOK = RegisterNativeHook("_ZN8cObjMine10moveReloadEv", function(this)
  if IsNull(this) then return end
  if ReadU8(Offset(this, RELOAD_IN_PROGRESS)) == 1 then
    -- reload already started (1st frame did the re-chamber) -> finish it NOW
    pcall(function() CallNative(Reload0, "ip", ItemMgr) end)       -- instant ammo refill
    pcall(function()
      WriteU8(Offset(this, RELOAD_IN_PROGRESS), 0)
      WriteU8(Offset(this, RELOAD_SUBFLAG), 0)
    end)
    return true                                                   -- skip the remaining animation
  end
  -- 1st frame: let the original set up the next-mine re-chamber + start the reload
end, nil, "p")

RegisterCommand("minethrower_status", function()
  return TAG .. ": moveReload fast-complete hook=" .. tostring(hookOK)
end)

Log(TAG .. ": loaded — Mine Thrower reload cut to ~2 frames (continuous fire) | hook=" .. tostring(hookOK))
