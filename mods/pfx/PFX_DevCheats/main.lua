-- ============================================================================
-- PFX_DevCheats — drive the game's OWN developer cheats (PFXCheatManager)
-- ============================================================================
-- The devs left a full UPFXCheatManager with unlock/max cheats. Shipping builds
-- don't create a cheat-manager instance (EnableCheats is a no-op), so we construct
-- one the correct way via EnableCheatsAsync — which now works because the modloader's
-- UE5 object construction was fixed (StaticConstructObject_Internal params-struct ABI +
-- correct resolver). A REAL instance (outer = PlayerController) has full game/player
-- context AND is GUObjectArray-resident, so param-cheats (o:Call) run on it.
--
-- Falls back to the class CDO (also now callable, via the CDO guard relaxation) if a
-- real instance can't be made yet.
-- ============================================================================
local TAG = "PFX_DevCheats"
Log(TAG .. ": loading — real cheat-manager construction + game-thread dispatch")

local function find_pc()
  for _, cn in ipairs({ "PFXVRPlayerController", "PFXPlayerController", "BP_PlayerController_C", "PlayerController" }) do
    local o = FindFirstOf(cn); if o and o.IsValid and o:IsValid() then return o end
  end
end

-- Ensure a real cheat manager exists (construct once), return the best callable target.
local _enabled = false
local function get_cm()
  local cm = FindFirstOf("BP_CheatManager_C")
  if cm and cm.IsValid and cm:IsValid() then return cm, true end
  if not _enabled then
    local pc = find_pc()
    if pc then pcall(function() EnableCheatsAsync(pc) end); _enabled = true end
  end
  cm = FindFirstOf("BP_CheatManager_C")
  if cm and cm.IsValid and cm:IsValid() then return cm, true end
  -- fallback: class default object (callable via CDO guard relaxation)
  local cdo = GetCDO("PFXCheatManager")
  if cdo and cdo.IsValid and cdo:IsValid() then return cdo, false end
  return nil, false
end

-- Fire a PFXCheatManager cheat by name. Parameterless -> CallAsync (game thread);
-- with args -> o:Call (marshals params + game thread + crash-guarded).
local function cheat(name, ...)
  local cm = get_cm()
  if not cm then Log(TAG .. ": no cheat manager"); return false end
  local args = { ... }
  local ok = false
  if #args > 0 then
    pcall(function() ok = cm:Call(name, table.unpack(args)) end)
  else
    pcall(function() ok = CallAsync(cm, name) end)
  end
  Log(TAG .. ": fired " .. name .. " -> " .. tostring(ok))
  return ok
end
_G.PFXCheat = cheat

-- SAFE parameterless cheats (run from any state)
local SAFE = {
  unlock_trophies = "PFXDebug_TableAwardUnlockAll",
  unlock_tables   = "PFXDebug_UserInventory_UnLockAllTables",
}
-- CONTEXT-SENSITIVE (championship/mastery must be loaded — championship menu)
local CTX = {
  max_championship  = "PFXDebug_Championship_MaxAll",
  max_champ_mastery = "PFXDebug_Championship_MasteryMaxAll",
  max_table_mastery = "PFXDebug_TableMasteryMaxAll",
  max_table_perks   = "PFXDebug_TablePerkMaxAll",
}
for cmd, fn in pairs(SAFE) do
  pcall(function() RegisterCommand(cmd, function() cheat(fn); return TAG .. ": " .. fn end) end)
end
for cmd, fn in pairs(CTX) do
  pcall(function() RegisterCommand(cmd, function() cheat(fn); return TAG .. ": " .. fn .. " (championship menu only!)" end) end)
end

-- Unlock all collectibles in a named bundle (e.g. the hub Trophy Wall). Param cheat.
pcall(function() RegisterCommand("unlock_bundle", function(bundle)
  if not bundle or bundle == "" then return TAG .. ": usage: unlock_bundle <BundleName>" end
  cheat("PFXDebug_Collectibles_UnlockAllEntriesInBundle", bundle)
  return TAG .. ": unlocked bundle " .. bundle
end) end)

-- Arbitrary cheat by name + optional args: cheat_run <Name> [arg]
pcall(function() RegisterCommand("cheat_run", function(name, a1)
  if not name or name == "" then return TAG .. ": usage: cheat_run <PFXDebug_Name> [arg]" end
  if a1 and a1 ~= "" then cheat(name, a1) else cheat(name) end
  return TAG .. ": fired " .. name
end) end)

-- Unlock trophies + all tables (safe set) in one go.
pcall(function() RegisterCommand("unlock_all", function()
  for _, fn in pairs(SAFE) do cheat(fn) end
  return TAG .. ": fired safe unlock cheats (trophies + tables)"
end) end)

Log(TAG .. ": ready — construct real cheat mgr; cmds: unlock_trophies, unlock_tables, unlock_bundle <b>, unlock_all, cheat_run <n> [arg]")
