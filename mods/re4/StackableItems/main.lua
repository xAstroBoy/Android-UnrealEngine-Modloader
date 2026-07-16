-- mods/re4/StackableItems/main.lua v4.0
-- ═══════════════════════════════════════════════════════════════════════
-- Stackable items — NATIVE single-instruction patch. NO per-call hook.
--
-- v4.0 — THE LAG FIX. v3 hooked cItemMgr::itemInfo (the item-DB lookup) with a
-- PRE + POST Lua callback to override each item's maxCapacity field. itemInfo is
-- a HOT function (HUD/inventory query it constantly), so that per-call Lua
-- dispatch ×2 was the frame-rate killer the player traced to this mod.
--
-- v4 drops the hook entirely and patches the ONE place the cap is actually READ
-- and enforced. In cItemMgr::combine, a stacked item's count is clamped to its
-- maxCapacity:
--     0x5F61BB0  LDRH W8,[SP,#4]   ; W8 = itemInfo.maxCapacity
--                SUBS W9,W8,W10     ; space = max - current
--                ... STRH W8,[X21,#2]  ; clamp count to max
-- Overwriting that load with `MOV W8,#<max>` makes the clamp use <max> for every
-- non-weapon stack (ammo/health) with ZERO per-frame cost. Verified live: the
-- original bytes are 0x79400BE8 (LDRH W8,[SP,#4]).
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "StackableItems"

local RVA  = 0x5F61BB0        -- cItemMgr::combine: the maxCapacity load / clamp
local ORIG = 0x79400BE8       -- LDRH W8,[SP,#4]
local function movw8(imm) return 0x52800000 | ((imm & 0xFFFF) << 5) | 8 end   -- MOVZ W8,#imm

local state = { enabled = true, maxStack = 999 }
local saved = ModConfig.Load("StackableItems")
if saved then
  if saved.enabled ~= nil then state.enabled = saved.enabled end
  if saved.maxStack then state.maxStack = saved.maxStack end
end

local function apply()
  pcall(function() WriteU32(Offset(GetLibBase(), RVA), movw8(state.maxStack)) end)
  Log(TAG .. ": ON — combine stack-cap clamp -> " .. state.maxStack .. " (native, no hook, no lag)")
end
local function restore()
  pcall(function() WriteU32(Offset(GetLibBase(), RVA), ORIG) end)
  Log(TAG .. ": OFF — stack cap restored")
end

if state.enabled then apply() end

RegisterCommand("stackable", function()
  state.enabled = not state.enabled
  if state.enabled then apply() else restore() end
  ModConfig.Save("StackableItems", state)
  Notify(TAG, state.enabled and "Stackable ON" or "Stackable OFF")
  return state.enabled and "ON" or "OFF"
end)

RegisterCommand("stackable_max", function(args)
  local n = tonumber(args)
  if n and n >= 1 and n <= 65535 then
    state.maxStack = n
    if state.enabled then apply() end
    ModConfig.Save("StackableItems", state)
    return "max stack = " .. n
  end
  return "usage: stackable_max <1-65535> (current " .. state.maxStack .. ")"
end)

if SharedAPI and SharedAPI.DebugMenu then
  SharedAPI.DebugMenu.RegisterToggle("StackableItems", "Stackable Items",
    function() return state.enabled end,
    function(v) state.enabled = v; if v then apply() else restore() end; ModConfig.Save("StackableItems", state) end)
end

Log(TAG .. ": v4.0 loaded — NATIVE combine stack-cap patch (no itemInfo hook, no lag) | max=" .. state.maxStack)
