-- mods/BossFixes/main.lua v2.2
-- ═══════════════════════════════════════════════════════════════════════
-- UE4SS-enhanced Boss Death Fix — ensures spawned bosses die properly
-- when HP=0 instead of standing frozen.
--
-- v2.1 — IsNull() for null pointer checks (lightuserdata != 0 in Lua)
--   C++ safe-call guard protects native hooks from dangling pointers
--   FindFirstOf("VR4Bio4PlayerPawn") for player context
--   ForEachUObject for boss instance discovery
--   NotifyOnNewObject for boss spawn detection
--   Native hooks on cEmWrap::setHp for death trigger
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "BossFixes"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local function isDefaultObject(obj)
    if not obj then return false end
    local ok, name = pcall(function() return obj:GetName() end)
    return ok and type(name) == "string" and name:sub(1, 9) == "Default__"
end

local function findFirstNonDefault(className)
    local first = nil
    pcall(function() first = FindFirstOf(className) end)
    if first and first:IsValid() and not isDefaultObject(first) then
        return first
    end
    local all = nil
    pcall(function() all = FindAllOf(className) end)
    if all then
        for _, obj in ipairs(all) do
            if obj and obj:IsValid() and not isDefaultObject(obj) then
                return obj
            end
        end
    end
    return nil
end

-- ── Boss type IDs ───────────────────────────────────────────────────────
local BOSS_IDS = {
    [9]  = "Tyrant",       [43] = "El Gigante",
    [44] = "Novistador Boss", [47] = "Salamander",
    [49] = "Saddler After", [50] = "U3 (It)",
    [51] = "Novistador Boss Event", [53] = "Mendez",
    [55] = "Verdugo (No2)", [56] = "Verdugo After",
    [57] = "Krauser",       [63] = "Saddler (Ada)",
}

-- ── cEm struct offsets ──────────────────────────────────────────────────
local OFF_WRAP_CEM   = 0x00
local OFF_WRAP_VALID = 0x0B
local OFF_MAIN_STATE = 0x114
local OFF_EM_TYPE    = 0x119
local OFF_HP         = 0x3F0

-- ── Function addresses ─────────────────────────────────────────────────
local sym_EmSetDie    = Resolve("EmSetDie",    0x05EEA2AC)
local sym_EmSetDieCnt = Resolve("EmSetDieCnt", 0x05EEA310)

-- ── Statistics ──────────────────────────────────────────────────────────
local bossKills = {}

-- ═══════════════════════════════════════════════════════════════════════
-- REMOVED — the cEmWrap::setHp Lua hook  (was: force boss death at HP 0)
-- ═══════════════════════════════════════════════════════════════════════
--
-- DO NOT PUT THIS BACK. It caused both of the bugs it looked like it fixed.
--
-- 1) THE LAG. cEmWrap::setHp runs per-enemy, many times per frame, from inside
--    cEmMgr::move. Hanging a LUA callback off it means every one of those calls
--    crosses native -> sol2 -> lua_State, no matter how early the callback
--    returns. Profiling the game thread with ~24 enemies put 12/12 samples in
--    libm fmod with the return address at 0x5d90924 — the BLR of the enemy's
--    virtual move(), i.e. the frame that called setHp. libUE4 imports NO fmodf
--    at all and reaches fmod only from ICU/timecode; libmodloader is what
--    imports fmod, because that is Lua's `%`. The time was ours, not the game's.
--    Rule (learned twice now): never hang a Lua callback on a hot function —
--    use a pure-C++ hook in re4_native_hooks.cpp if one is genuinely needed.
--
-- 2) THE MISSING DEATH ANIMATION. EmSetDie/EmSetDieCnt only flag the enemy dead
--    in room-save data and bump a counter — they never run the death STATE, so
--    the body vanished instead of playing its death anim. The engine's own path
--    is LifeDownSet2: when HP reaches 0 it fires ArmSendEmEvent(em, 10), which
--    is what actually plays the animation.
--
-- Both existed only to work around bosses that could never reach 0 HP. That is
-- now fixed at the source: LifeDownSet2 takes a "keep alive" flag in a4 bit 0
-- that clamps HP to a floor of 1 (proved with a hardware watchpoint on U3's HP).
-- install_lifedown_keepalive_fix() in re4_native_hooks.cpp clears that bit for
-- the ids registered via SetEmKillable, so damage lands, HP reaches 0, and the
-- engine plays the death animation by itself. Nothing to force from Lua.

Log(TAG .. ": boss death is handled by the engine (LifeDownSet2 keep-alive fix) — no setHp hook")

-- ═══════════════════════════════════════════════════════════════════════
-- DIFFICULTY-SCALED BOSS HP ON SPAWN
-- ═══════════════════════════════════════════════════════════════════════
--
-- WHY: a boss spawned outside its own scenario comes up with HP = 1. Its init
-- writes the real value (verified in em32/U3's init: `mov w8,#0x1f4; strh w8,
-- [x19,#0x3f0]` = 500), but the spawn path re-applies the room-authored /
-- difficulty-scaled HP afterwards, and out of context that lookup yields 1.
-- A 1-HP boss reads as "invincible" because the engine floors it there and the
-- scripted SCE kill that would finish it only exists in its home level.
--
-- HP lives at cEm+0x3F0 as an int16 — confirmed from cEmWrap::setHp, which does
--     if (wrap[11]==1 && (cem=*(cEm**)wrap) && (cem->flags & 0x201)==1)
--         *(int16*)(cem + 1008) = hp;
-- so writing there directly is exactly what the engine's own setter does.
--
-- Values are the enemy's own base HP where known, scaled by difficulty. Tune
-- BOSS_BASE_HP freely — anything above 1 makes the boss damageable.
local OFF_HP_CEM = 0x3F0

local BOSS_BASE_HP = {
    [9]  = 800,   -- Tyrant
    [43] = 1200,  -- El Gigante
    [44] = 600,   -- Novistador Boss
    [47] = 700,   -- Salamander
    [49] = 900,   -- Saddler After
    [50] = 500,   -- U3 (It)          — 500 read straight out of its init
    [51] = 600,   -- Novistador Boss Event
    [53] = 800,   -- Mendez
    [55] = 700,   -- Verdugo (No2)
    [56] = 700,   -- Verdugo After
    [57] = 900,   -- Krauser
    [63] = 1000,  -- Saddler (Ada)
}

-- UBio4Utils::GetGameDifficulty — 0=easy 1=normal 2=hard (higher = tougher)
local sym_GetDifficulty = Resolve("_ZN10UBio4Utils17GetGameDifficultyEv", 0x06218B30)
local DIFF_MULT = { [0] = 0.6, [1] = 1.0, [2] = 1.6 }

local function currentDifficulty()
    if not sym_GetDifficulty then return 1 end
    local ok, d = pcall(function() return CallNative(sym_GetDifficulty, "i") end)
    if ok and type(d) == "number" and DIFF_MULT[d] then return d end
    return 1
end

-- idx -> cEm: the pool is a flat array, so cEm = poolBase + stride*idx.
-- (EmMgr layout read out of cEmMgr::move: +0x08 poolBase, +0x10 count, +0x14 stride)
local EMMGR_RVA = 0xA3C28D8
local function cemFromIndex(idx)
    local ok, cem = pcall(function()
        local mgr = ReadPointer(Offset(GetLibBase(), EMMGR_RVA))
        if IsNull(mgr) then return nil end
        local base   = ReadPointer(Offset(mgr, 0x08))
        local count  = ReadU32(Offset(mgr, 0x10))
        local stride = ReadU32(Offset(mgr, 0x14))
        if IsNull(base) or not count or not stride then return nil end
        if idx < 0 or idx >= count then return nil end
        return Offset(base, stride * idx)
    end)
    if ok then return cem end
    return nil
end

pcall(function()
    RegisterNativeHook("EmListSetAlive",
        function(idx, alive)
            if VERBOSE then
                V("Native pre EmListSetAlive idx=%s alive=%s", tostring(idx), tostring(alive))
            end
            -- Spawn edge only. Everything below runs once per spawn, never per frame.
            if alive ~= 0 then
                local cem = cemFromIndex(idx)
                if cem and not IsNull(cem) then
                    local em_type = ReadU8(Offset(cem, OFF_EM_TYPE))
                    local base    = BOSS_BASE_HP[em_type]
                    if base then
                        local hp = ReadU16(Offset(cem, OFF_HP_CEM))
                        -- Only repair a boss the spawn path left at 1 (or 0). If it
                        -- already has real HP, the game set it correctly — leave it.
                        if hp == nil or hp <= 1 then
                            local d      = currentDifficulty()
                            local scaled = math.floor(base * (DIFF_MULT[d] or 1.0))
                            if scaled < 2 then scaled = 2 end
                            pcall(function() WriteU16(Offset(cem, OFF_HP_CEM), scaled) end)
                            Log(TAG .. ": " .. (BOSS_IDS[em_type] or ("type " .. em_type))
                                .. " spawned with HP=" .. tostring(hp) .. " → set " .. scaled
                                .. " (base " .. base .. " x difficulty " .. d .. ")")
                        end
                    end
                end
            else
                Log(TAG .. ": EmListSetAlive idx=" .. idx .. " → DEAD")
            end
            return idx, alive
        end, nil)
end)

-- ═══════════════════════════════════════════════════════════════════════
-- COMMANDS — UE4SS enhanced status
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("bossfixes_status", function()
    V("bossfixes_status command fired")
    local info = TAG .. ": Boss kills:"
    local total = 0
    for name, count in pairs(bossKills) do
        info = info .. " " .. name .. "=" .. count
        total = total + count
    end
    if total == 0 then info = info .. " none" end
    info = info .. " (total=" .. total .. ")"

    -- Check player health via UE4SS
    local pawn = findFirstNonDefault("VR4Bio4PlayerPawn")
    V("FindFirstOf(VR4Bio4PlayerPawn) = %s", tostring(pawn))
    if pawn and pawn:IsValid() then
        pcall(function()
            local hp = pawn:GetPlayerCurrentHealth()
            if hp then info = info .. " | Leon HP=" .. tostring(hp) end
        end)
    end
    Log(info)
end)

Log(TAG .. ": v2.1 loaded — boss death fix for " .. 12 .. " types + UE4SS status")
