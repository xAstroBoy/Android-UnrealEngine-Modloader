-- mods/re4/DualFire/main.lua v6.0
-- ═══════════════════════════════════════════════════════════════════════
-- SIMULTANEOUS dual-fire.
--
-- RE4 has ONE global "armed weapon" (pG). AVR4GamePlayerGun::TryFire only fires
-- the gun if it IS the armed weapon at that moment. Hold two guns, pull both
-- triggers, and the engine's own arming keeps swapping which one is armed, so
-- the other gun's TryFire sees "not armed" and only ONE fires.
--
-- The fix is unchanged: arm THIS gun inside its OWN TryFire, right before the
-- fire-check. TryFire(A) -> arm A -> A fires; TryFire(B) -> arm B -> B fires;
-- both fire the same frame (interleaved = simultaneous). It mirrors the game's
-- own code at the tail of TryFire (ArmSearchWeaponNo(&ItemMgr, gun[3360]) ->
-- cItemMgr::arm), which is why it's safe to do there.
--
-- v6.0 — the arming moved into the MODLOADER, in pure C++ (InstallDualFireArm).
--   v5 did it from a LUA CALLBACK on TryFire, and that was the bug. TryFire is
--   HOT: it runs on the game thread on every trigger pull, once per gun when
--   dual-wielding, and continuously with rapid-fire. A Lua callback there races
--   the shared lua_State against the mod loop and the bridge thread, corrupting
--   Lua's heap structures. The damage surfaced far from the cause and blamed
--   innocent engine code:
--     * SIGSEGV in FMallocBinned2::FreeExternal <- TProperty<FString>::
--       DestroyValueInternal <- IncrementalPurgeGarbage  (heap free-list eaten)
--     * SIGBUS with pc=lr=0x1 — a RET into a smashed return address
--   v5's header claimed "cold-ish hook, verified 0 crashes under fire stress".
--   It isn't cold, and it does crash — it just crashes SECONDS LATER, somewhere
--   else, which is exactly why it read as safe.
--
--   Nothing about the behaviour changes; the identical work (read gun+3360,
--   ArmSearchWeaponNo, arm) now runs as C with no lua_State involved. Lua only
--   resolves the addresses once at load and toggles an atomic.
--   Rule, from the ScoreControl crash and now this one: NEVER put a Lua callback
--   on a hot native function.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "DualFire"

local A = {}
local function R(n, m, fb) A[n] = Resolve(m, fb) end
R("TryFire",          "_ZN17AVR4GamePlayerGun7TryFireEv",   0x62DC490)
R("ArmSearchWeaponNo", "_ZN8cItemMgr17ArmSearchWeaponNoEh", 0x5F60264)
R("Arm",              "_ZN8cItemMgr3armEP5cItem",           0x5F561C8)
local ItemMgr = Offset(GetLibBase(), 0xA561810)
local WNO_OFF = 3360

local state = { enabled = true }
local saved = ModConfig.Load("DualFire")
if saved and saved.enabled ~= nil then state.enabled = saved.enabled end

-- The whole trigger path is native. If the binding is missing the modloader is
-- stale — do NOT fall back to a Lua hook on TryFire, that is the crash.
local hookOK = false
if InstallDualFireArm then
  local ok, res = pcall(InstallDualFireArm, A.TryFire, ItemMgr, A.ArmSearchWeaponNo, A.Arm, WNO_OFF)
  hookOK = ok and res or false
  -- Say WHY on failure. A bare pcall hid a type error here once and the mod
  -- happily reported "loaded" with the hook silently absent (nativeHook=false).
  if not ok then
    LogWarn(TAG .. ": InstallDualFireArm ERRORED: " .. tostring(res)
      .. " | tryFire=" .. tostring(A.TryFire) .. " itemMgr=" .. tostring(ItemMgr)
      .. " armSearch=" .. tostring(A.ArmSearchWeaponNo) .. " arm=" .. tostring(A.Arm))
  elseif not res then
    LogWarn(TAG .. ": InstallDualFireArm returned false — see the [DUALFIRE] log line for which address was bad")
  end
  if hookOK and SetDualFireEnabled then pcall(SetDualFireEnabled, state.enabled) end
else
  LogWarn(TAG .. ": InstallDualFireArm missing — rebuild/redeploy the modloader. "
    .. "Refusing to Lua-hook TryFire (that is what corrupted the heap and crashed the game).")
end

local function setEnabled(v)
  state.enabled = v
  if SetDualFireEnabled then pcall(SetDualFireEnabled, v) end
  ModConfig.Save("DualFire", state)
end

RegisterCommand("dualfire", function()
  setEnabled(not state.enabled)
  Notify(TAG, state.enabled and "Simultaneous dual-fire ON" or "OFF")
  return state.enabled and "ON" or "OFF"
end)
RegisterCommand("dualfire_status", function()
  return TAG .. " v6 (native TryFire-arm) enabled=" .. tostring(state.enabled)
    .. " nativeHook=" .. tostring(hookOK)
end)

if SharedAPI and SharedAPI.DebugMenu then
  SharedAPI.DebugMenu.RegisterToggle("DualFire", "Simultaneous Dual-Fire",
    function() return state.enabled end,
    function(v) setEnabled(v) end)
end

Log(TAG .. ": v6.0 loaded — dual-fire arming runs in PURE C++ (no Lua on the hot TryFire path) | nativeHook="
  .. tostring(hookOK) .. " enabled=" .. tostring(state.enabled))
