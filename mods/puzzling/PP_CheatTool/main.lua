-- PP_CheatTool — enable Puzzling Places' built-in dev "cheat tool" (BP_Cheattool_C)
-- in every puzzle, spawned wired/clickable, and let the game's OWN toolbox manage it
-- (so it shows in a puzzle and hides on the main menu — no manual visibility polling,
-- which is what crashed the game before via use-after-free on transitioning actors).
--
-- Mechanism: the puzzle toolbox (ToolBoxNative) spawns its tools once at puzzle load,
-- gated per-tool by boolean flags. The cheat tool additionally requires
-- MasterManager.shouldSpawnCheatIfSinglePlayer (that's the real "cheats activated"
-- flag the hidden in-menu activator sets). We set those flags in a PRE-hook, right
-- before the native tool-spawn runs, so the cheat tool spawns as a normal, registered
-- tool (ref_CheatTool) — fully wired and lifecycle-managed by the game.
--
-- SAFETY: the only thing we do is set boolean properties inside a hook that fires at a
-- safe time (tool spawn, objects being created not destroyed). No polling, no method
-- calls on actors that might be mid-destruction — that avoids the earlier crash.

local TAG = "PP_CheatTool"

-- Guard: this session may also arm the hooks live via the bridge; don't double-register.
if _G._PP_CHEATTOOL_ARMED then
  Log(TAG .. ": already armed this session — skipping")
  return
end
_G._PP_CHEATTOOL_ARMED = true

-- Every per-tool spawn flag the toolbox checks. Setting them all true unlocks the
-- normally-hidden dev/QA tools (Cheat, GridFactory, RoomInfo, Mute) alongside the
-- normal ones (SeeThrough, Styler, Home, Replay).
local TOOL_FLAGS = {
  "SpawnSeethrough", "spawnGridFactory", "SpawnStylerTool", "SpawnMuteButtons",
  "ShouldSpawnCheattool", "bShouldSpawnRoomInfoButton", "SpawnHomeButton", "SpawnReplayTool",
}

local function enable_cheat_gate(self)
  pcall(function()
    -- the "cheats activated" gate lives on the master manager(s)
    for _, cn in ipairs({ "MasterManagerBP_C", "QuestMasterManager", "MasterManager" }) do
      for _, m in ipairs(FindAllOf(cn) or {}) do
        m:Set("shouldSpawnCheatIfSinglePlayer", true)
      end
    end
    -- flip every tool flag on the toolbox that's about to spawn its tools, so the
    -- full tool set (including the hidden ones) spawns wired + game-managed.
    if self and self.Set then
      for _, f in ipairs(TOOL_FLAGS) do
        pcall(function() self:Set(f, true) end)
      end
      local cls = FindClass("BP_Cheattool_C")
      if cls then self:Set("cheatToolType", cls) end
    end
  end)
end

-- Both are the toolbox's tool-spawn entry points across code paths; whichever fires
-- first at puzzle load sets the gate before the cheat tool would be skipped.
RegisterPreHook("ToolBoxNative:SpawnToolsInBluePrint", function(self) enable_cheat_gate(self) end)
RegisterPreHook("ToolBoxNative:OnPuzzleLoadingFinished", function(self) enable_cheat_gate(self) end)

Log(TAG .. ": armed — the built-in cheat tool now spawns (wired) in every puzzle and is "
  .. "shown/hidden by the game's own toolbox (menu-safe, no polling).")
