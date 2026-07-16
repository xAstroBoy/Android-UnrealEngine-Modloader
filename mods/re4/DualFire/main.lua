-- mods/re4/DualFire/main.lua v5.0
-- ═══════════════════════════════════════════════════════════════════════
-- SIMULTANEOUS dual-fire.
--
-- RE4 has ONE global "armed weapon" (pG). AVR4GamePlayerGun::TryFire only
-- fires the gun if it IS the armed weapon at that moment. When you hold two
-- guns and pull both triggers, the engine's own arming (and the old v4 which
-- hooked UpdateBio4Wep in edge-mode) kept swapping which gun was armed, so the
-- other gun's TryFire saw "not armed" and only ONE fired. Verified from a live
-- Fired-trace: with the old approach only the first gun spawned shots.
--
-- v5.0 — arm THIS gun inside its OWN TryFire, right before the fire-check runs.
-- So TryFire(gunA) -> arm A -> A fires; TryFire(gunB) -> arm B -> B fires; both
-- fire the same frame (interleaved = simultaneous). Live Fired-trace confirmed:
-- wno15 x29 + clone wno12 x25, interleaved "12 15 12 12 15 12 15 15 12 ...".
-- Idempotent for single-gun use (arms the one held gun = normal behaviour).
-- Cold-ish hook (only on trigger pulls); verified 0 crashes under fire stress.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "DualFire"

local A = {}
local function R(n, m, fb) A[n] = Resolve(m, fb) end
R("ArmSearchWeaponNo", "_ZN8cItemMgr17ArmSearchWeaponNoEh", 0x5F60264)
R("Arm",              "_ZN8cItemMgr3armEP5cItem",           0x5F561C8)
local ItemMgr = Offset(GetLibBase(), 0xA561810)
local WNO_OFF = 3360

local state = { enabled = true }
local saved = ModConfig.Load("DualFire")
if saved and saved.enabled ~= nil then state.enabled = saved.enabled end

-- Arm the gun being TryFire'd so it is "the armed weapon" for its own fire-check.
-- Fresh lookup each call (no cache) so a dropped/re-picked weapon can't leave a
-- stale cItem pointer to arm.
local function onTryFire(g)
  if not state.enabled then return end
  if IsNull(g) then return end
  local wno = ReadU8(Offset(g, WNO_OFF))
  if wno == 0 then return end
  local item = CallNative(A.ArmSearchWeaponNo, "ppi", ItemMgr, wno)
  if item and not IsNull(item) then CallNative(A.Arm, "ipp", ItemMgr, item) end
end

local hookOK = RegisterNativeHook("_ZN17AVR4GamePlayerGun7TryFireEv", onTryFire, nil, "p")

RegisterCommand("dualfire", function()
  state.enabled = not state.enabled
  ModConfig.Save("DualFire", state)
  Notify(TAG, state.enabled and "Simultaneous dual-fire ON" or "OFF")
  return state.enabled and "ON" or "OFF"
end)
RegisterCommand("dualfire_status", function()
  return TAG .. " v5 (simultaneous TryFire-arm) enabled=" .. tostring(state.enabled) .. " hook=" .. tostring(hookOK)
end)

if SharedAPI and SharedAPI.DebugMenu then
  SharedAPI.DebugMenu.RegisterToggle("DualFire", "Simultaneous Dual-Fire",
    function() return state.enabled end,
    function(v) state.enabled = v; ModConfig.Save("DualFire", state) end)
end

Log(TAG .. ": v5.0 loaded — simultaneous dual-fire via per-gun TryFire arming | hook=" .. tostring(hookOK) .. " enabled=" .. tostring(state.enabled))
