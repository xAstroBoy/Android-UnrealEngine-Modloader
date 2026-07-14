-- ============================================================================
-- PFX_CollectionRandomizer v34 — Hub Slot Scramble + Per-Table Cosmetics
-- ============================================================================
-- v27 CHANGES from v26:
--   * FIX: robust slot assignment validation. If ChangeSlotEntry is a no-op,
--     fallback writes m_slotEntry directly, then runs notify/setup calls.
--   * FIX: strict pre-clear only runs when slot had a previous live entry.
--     This preserves empty-slot fill reliability for gadget/statue.
--
-- v26 CHANGES from v25:
--   * FIX: strict replace now rolls back previous slot entry if placement fails,
--     preventing gadget/statue slots from staying empty on failed swaps.
--   * TWEAK: init randomization starts sooner once slot count threshold is met.
--
-- v25 CHANGES from v24:
--   * FIX: entry uniqueness now keys by `GetEntryID()` gameplay tag first
--     (fallback: object name/id), preventing heavy over-dedup on Gadget/Statue.
--   * FIX: Gadget + Statue now enforce uniqueness per owner station (shelf)
--     before wrap, eliminating same-shelf dupes when pool size allows.
--
-- v24 CHANGES from v23:
--   * NEW: Gadget + Statue now enforce strict unique rotation through full pools
--     before reuse; wrap resets used picks and continues cycling.
--   * NEW: Gadget + Statue now force clear/reset old slot visuals before placing
--     the new randomized entry (replace even when slot already occupied).
--
local TAG = "PFX_Randomizer"
local VERBOSE = true
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end
Log(TAG .. ": Loading v49...")

-- Reload generation: older LoopAsync/ExecuteWithDelay callbacks compare this and
-- self-terminate, so a reload never stacks duplicate loops.
_G._RAND_GEN = (_G._RAND_GEN or 0) + 1
local MY_GEN = _G._RAND_GEN

-- SAFE ONLY AT THE HUB. When the user enters a table, the hub slots / entries /
-- cabinets we operate on are torn down; reflecting on / Blueprint-calling those stale
-- objects crashes the Lua VM (the v43/v44 crash-loop). PFXCore.get_S() is non-zero
-- once a table's physics container is live, so we use it to STOP all randomizer
-- activity the instant a table is entered — the mod goes inert during play.
local function hub_active()
  if _G.PFXCore and _G.PFXCore.get_S then
    local s = 0
    pcall(function() s = _G.PFXCore.get_S() end)
    if type(s) == "number" and s ~= 0 then return false end
  end
  return true
end

-- ============================================================================
-- CATEGORY CONSTANTS
-- ============================================================================
local CATEGORY_NAMES = {
    [1]  = "Arm",
    [2]  = "SkinTone",
    [3]  = "Poster",
    [4]  = "Statue",
    [5]  = "Gadget",
    [6]  = "Floor",
    [7]  = "Wall",
    [8]  = "Music",
    [9]  = "FlipperArm",
    [10] = "BallSkin",
    [11] = "BallTrail",
    [12] = "Trophy",
    [13] = "Cabinet",
    [14] = "HubInterior",
    [15] = "Door",
}

-- Categories to NEVER scramble in hub slots
local SKIP_CATEGORIES = {
    [0]  = true,  -- Invalid / unknown
    [12] = true,  -- Trophy (handled by MaxAll holo→physical swap)
    [13] = true,  -- Cabinet (table-specific dioramas)
}

-- Categories requiring strict uniqueness rotation and hard replacement
local STRICT_UNIQUE_CATEGORIES = {
    [4] = true,   -- Statue
    [5] = true,   -- Gadget
}

local STRICT_REPLACE_CATEGORIES = {
    [4] = true,   -- Statue
    [5] = true,   -- Gadget
}

-- Entries are blacklisted if their NORMALIZED (lowercased, punctuation/space-stripped)
-- localized name, object name, OR gameplay tag contains one of these tokens. Keep the
-- tokens normalized too (no spaces/punctuation) so "Silver Ball", "X-Arcade",
-- "Arcade2TV-XR" all match regardless of how the game spells them.
local ENTRY_NAME_BLACKLIST = {
    "arcade2tv",   -- "Arcade2TV-XR" poster
    "silverball",  -- "Silver Ball" statue
    "xarcade",     -- X-Arcade / XArcade promo cosmetics
}

-- strip everything that isn't a letter or digit, lowercase
local function norm_name(s)
    if type(s) ~= "string" then return "" end
    return (s:lower():gsub("[^%a%d]", ""))
end

local function is_blacklisted_entry(entry)
    if not entry then return false end
    local loc = ""; pcall(function() loc = tostring(entry:Call("GetLocalizedName")) end)
    local nm  = ""; pcall(function() nm  = entry:GetName() end)
    local tag = ""
    pcall(function()
        local t = entry:Call("GetEntryID")
        if t then
            local tn = nil
            pcall(function() tn = t.TagName end)
            if tn then tag = tostring(tn) end
        end
    end)
    local hay = norm_name(loc) .. "|" .. norm_name(nm) .. "|" .. norm_name(tag)
    for _, bl in ipairs(ENTRY_NAME_BLACKLIST) do
        if hay:find(bl, 1, true) then return true end
    end
    return false
end

local function name_of(obj)
    if not obj then return "" end
    local n = nil
    pcall(function() n = obj:GetName() end)
    return type(n) == "string" and n or ""
end

local function entry_id(obj)
    if not obj then return "" end
    local ok, s = pcall(function() return tostring(obj) end)
    return (ok and type(s) == "string") and s or ""
end

local function entry_tag_key(obj)
    if not obj then return "" end

    local tagStr = ""
    pcall(function()
        local tag = obj:Call("GetEntryID")
        if tag then
            local tn = nil
            pcall(function() tn = tag.TagName end)
            if tn then tagStr = tostring(tn) end
            if tagStr == "" then
                local okTag, asStr = pcall(function() return tostring(tag) end)
                if okTag and type(asStr) == "string" then tagStr = asStr end
            end
        end
    end)

    if tagStr == "" or tagStr == "nil" then return "" end
    return "tag::" .. tagStr
end

local function entry_key(obj)
    if not obj then return "" end
    local t = entry_tag_key(obj)
    if t ~= "" then return t end
    local n = name_of(obj)
    if n ~= "" then return n end
    return entry_id(obj)
end

local function shuffle(arr)
    if not arr or #arr <= 1 then return arr end
    for i = #arr, 2, -1 do
        local j = math.random(i)
        arr[i], arr[j] = arr[j], arr[i]
    end
    return arr
end

local function dedupe_by_key(items, keyFn)
    local out = {}
    local seen = {}
    if not items then return out end
    for _, item in ipairs(items) do
        local key = keyFn(item)
        if key and key ~= "" and not seen[key] then
            seen[key] = true
            out[#out + 1] = item
        end
    end
    return out
end

local function make_cycle_state(items, keyFn)
    local unique = dedupe_by_key(items, keyFn)
    local state = {
        unique = unique,
        keyFn = keyFn,
        remaining = {},  -- items not yet picked this round
        usedKeys = {},   -- keys picked this round (for dupe detection)
    }
    -- Fill remaining with shuffled copy
    for i, item in ipairs(unique) do state.remaining[i] = item end
    if #state.remaining > 1 then shuffle(state.remaining) end
    return state
end

local function refill_cycle(state)
    state.remaining = {}
    state.usedKeys = {}
    for i, item in ipairs(state.unique or {}) do state.remaining[i] = item end
    if #state.remaining > 1 then shuffle(state.remaining) end
end

local function take_from_cycle(state, avoidKey)
    if not state or not state.unique or #state.unique == 0 then return nil end

    -- If remaining is empty, refill (start new cycle — grab ALL items again)
    if #state.remaining == 0 then
        refill_cycle(state)
    end

    -- Find first item in remaining whose key != avoidKey
    -- usedKeys is NOT checked here — once we refill, every item is fair game
    -- The only constraint is: don't give the slot its own current entry back
    for i = 1, #state.remaining do
        local candidate = state.remaining[i]
        local key = state.keyFn(candidate)
        if key and key ~= "" and key ~= (avoidKey or "") then
            -- Remove from remaining (swap with last for O(1) remove)
            state.remaining[i] = state.remaining[#state.remaining]
            state.remaining[#state.remaining] = nil
            state.usedKeys[key] = true
            return candidate
        end
    end

    -- All remaining match avoidKey — refill and try once more (new shuffle order)
    refill_cycle(state)
    for i = 1, #state.remaining do
        local candidate = state.remaining[i]
        local key = state.keyFn(candidate)
        if key and key ~= "" then
            state.remaining[i] = state.remaining[#state.remaining]
            state.remaining[#state.remaining] = nil
            state.usedKeys[key] = true
            return candidate
        end
    end

    -- Absolute fallback: return first unique entry
    return state.unique[1]
end

-- ============================================================================
-- UTILITY
-- ============================================================================
local function is_live(obj)
    if not obj then return false end
    local ok, valid = pcall(function() return obj:IsValid() end)
    if not ok or not valid then return false end
    local ok2, name = pcall(function() return obj:GetName() end)
    if not ok2 or not name then return false end
    return not name:match("^Default__") and not name:match("^REINST_") and not name:match("^SKEL_")
end

local function find_live(...)
    for _, cls in ipairs({...}) do
        local all = nil
        pcall(function() all = FindAllOf(cls) end)
        if all then
            for _, obj in ipairs(all) do
                if is_live(obj) then return obj end
            end
        end
    end
    return nil
end

-- Reverse map: class-name suffix -> category ID
local CLASS_TO_CATID = {
    Arm         = 1,
    SkinTone    = 2,
    Poster      = 3,
    Statue      = 4,
    Gadget      = 5,
    Floor       = 6,
    Wall        = 7,
    Music       = 8,
    FlipperArm  = 9,
    BallSkin    = 10,
    BallTrail   = 11,
    Trophie     = 12,
    Cabinet     = 13,
    HubInterior = 14,
    Door        = 15,
}

local function get_category_id(entry)
    if not entry then return nil end
    -- Primary: derive from class name (PFXCollectibleEntry_Gadget -> 5)
    local className = nil
    pcall(function() className = entry:GetClassName() end)
    if className then
        local suffix = className:match("PFXCollectibleEntry_(%w+)")
        if suffix and CLASS_TO_CATID[suffix] then
            return CLASS_TO_CATID[suffix]
        end
    end
    -- Fallback: entry object name (PFXCollectibleEntry_Gadget_7 -> Gadget)
    local objName = nil
    pcall(function() objName = entry:GetName() end)
    if objName then
        local suffix = objName:match("PFXCollectibleEntry_(%a+)")
        if suffix and CLASS_TO_CATID[suffix] then
            return CLASS_TO_CATID[suffix]
        end
    end
    return nil
end

-- ============================================================================
-- ENTRY POOL — ALL live non-CDO entries grouped by category
-- ============================================================================
local ENTRY_CLASSES = {
    "PFXCollectibleEntry_Arm",
    "PFXCollectibleEntry_BallSkin",
    "PFXCollectibleEntry_BallTrail",
    "PFXCollectibleEntry_Door",
    "PFXCollectibleEntry_Floor",
    "PFXCollectibleEntry_FlipperArm",
    "PFXCollectibleEntry_Gadget",
    "PFXCollectibleEntry_HubInterior",
    "PFXCollectibleEntry_Music",
    "PFXCollectibleEntry_Poster",
    "PFXCollectibleEntry_SkinTone",
    "PFXCollectibleEntry_Statue",
    "PFXCollectibleEntry_Trophie",
    "PFXCollectibleEntry_Wall",
}

local entryPool = {}   -- catID -> { entry UObject, ... }
local poolReady = false
local _poolByIP = nil  -- catID -> ipkey -> { entries }  (lazy; rebuilt from entryPool)
local _cyclesByIP = {} -- catID -> ipkey -> no-repeat cycle state

-- Pre-filtered pools for table cosmetics grouped by IP
-- ALL ball/trail/flipper entries are IP-locked (zero global)
-- Tags: Collectibles.IP.<IP>.<TableHint>.<ItemName>
local ballByIP = {}    -- IP -> { {entry=, mesh=}, ... }
local trailByIP = {}   -- IP -> { {entry=, trail=}, ... }
local flipperByIP = {} -- IP -> { entry, ... }
local tableHintToIP = {}  -- lowercase table hint -> IP (e.g. "doom" -> "Bethesda")
-- Per-table pools (each table has ~3 entries per cosmetic type)
local ballByHint = {}    -- hint -> { {entry=, mesh=}, ... }
local trailByHint = {}   -- hint -> { {entry=, trail=}, ... }
local flipperByHint = {} -- hint -> { entry, ... }
-- Legacy totals for logging
local ballPoolValid = {}
local trailPoolValid = {}
local flipperPoolAll = {}
local pendingFlipperOverrides = {}

local stats = {
    hook_ok = 0, hook_skip = 0, hook_err = 0,
    sweep_ok = 0, sweep_skip = 0, sweep_err = 0,
    table_ball = 0, table_trail = 0, table_flipper = 0, table_fail = 0,
    pool_size = 0, sweeps = 0,
    empty_filled = 0,
}

local function extract_ip_from_tag(tagStr)
    -- Tag format: Collectibles.IP.<IP>.<TableHint>.<ItemName>
    if not tagStr or tagStr == "" then return nil, nil end
    local parts = {}
    for p in tagStr:gmatch("[^.]+") do parts[#parts + 1] = p end
    if #parts >= 4 and parts[2] == "IP" then
        return parts[3], parts[4]  -- IP, tableHint
    end
    return nil, nil
end

local function build_entry_pool()
    entryPool = {}
    ballByIP = {}
    trailByIP = {}
    flipperByIP = {}
    tableHintToIP = {}
    ballByHint = {}
    trailByHint = {}
    flipperByHint = {}
    ballPoolValid = {}
    trailPoolValid = {}
    flipperPoolAll = {}
    local total = 0
    local seenPoolByCat = {}
    local seenBall = {}
    local seenTrail = {}
    local seenFlipper = {}

    for _, cls in ipairs(ENTRY_CLASSES) do
        pcall(function()
            local entries = FindAllOf(cls)
            if entries then
                for _, entry in ipairs(entries) do
                    if is_live(entry) and not is_blacklisted_entry(entry) then
                        pcall(function()
                            local catID = get_category_id(entry)
                            local key = entry_key(entry)

                            -- Extract tag for IP classification
                            local tagStr = ""
                            pcall(function()
                                local tag = entry:Call("GetEntryID")
                                if tag then
                                    local tn = nil
                                    pcall(function() tn = tag.TagName end)
                                    if tn then tagStr = tostring(tn) end
                                end
                            end)
                            local ip, hint = extract_ip_from_tag(tagStr)

                            if catID and not SKIP_CATEGORIES[catID] then
                                if not entryPool[catID] then entryPool[catID] = {} end
                                if not seenPoolByCat[catID] then seenPoolByCat[catID] = {} end
                                if key ~= "" and not seenPoolByCat[catID][key] then
                                    seenPoolByCat[catID][key] = true
                                    entryPool[catID][#entryPool[catID] + 1] = entry
                                    total = total + 1
                                end
                            end

                            -- Build IP-grouped table cosmetics pools
                            if ip and hint then
                                tableHintToIP[hint:lower()] = ip
                            end

                            if catID == 10 then  -- BallSkin
                                local mesh = nil
                                pcall(function() mesh = entry:Get("ballskin") end)
                                if mesh and key ~= "" and not seenBall[key] then
                                    seenBall[key] = true
                                    local item = { entry = entry, mesh = mesh }
                                    ballPoolValid[#ballPoolValid + 1] = item
                                    if ip then
                                        if not ballByIP[ip] then ballByIP[ip] = {} end
                                        ballByIP[ip][#ballByIP[ip] + 1] = item
                                    end
                                    if hint then
                                        local hk = hint:lower()
                                        if not ballByHint[hk] then ballByHint[hk] = {} end
                                        ballByHint[hk][#ballByHint[hk] + 1] = item
                                    end
                                end
                            elseif catID == 11 then  -- BallTrail
                                local trail = nil
                                pcall(function() trail = entry:Get("BallTrail") end)
                                if trail and key ~= "" and not seenTrail[key] then
                                    seenTrail[key] = true
                                    local item = { entry = entry, trail = trail }
                                    trailPoolValid[#trailPoolValid + 1] = item
                                    if ip then
                                        if not trailByIP[ip] then trailByIP[ip] = {} end
                                        trailByIP[ip][#trailByIP[ip] + 1] = item
                                    end
                                    if hint then
                                        local hk = hint:lower()
                                        if not trailByHint[hk] then trailByHint[hk] = {} end
                                        trailByHint[hk][#trailByHint[hk] + 1] = item
                                    end
                                end
                            elseif catID == 9 then  -- FlipperArm
                                if key ~= "" and not seenFlipper[key] then
                                    seenFlipper[key] = true
                                    flipperPoolAll[#flipperPoolAll + 1] = entry
                                    if ip then
                                        if not flipperByIP[ip] then flipperByIP[ip] = {} end
                                        flipperByIP[ip][#flipperByIP[ip] + 1] = entry
                                    end
                                    if hint then
                                        local hk = hint:lower()
                                        if not flipperByHint[hk] then flipperByHint[hk] = {} end
                                        flipperByHint[hk][#flipperByHint[hk] + 1] = entry
                                    end
                                end
                            end
                        end)
                    end
                end
            end
        end)
    end

    poolReady = total > 0
    _poolByIP = nil; _cyclesByIP = {}   -- invalidate IP pools; rebuilt lazily from the new entryPool
    stats.pool_size = total

    for catID, items in pairs(entryPool) do
        Log(TAG .. ":   " .. (CATEGORY_NAMES[catID] or ("Cat" .. catID))
            .. ": " .. #items .. " entries")
    end
    -- Log IP pool sizes
    local ipList = {}
    for ip, items in pairs(flipperByIP) do
        ipList[#ipList + 1] = ip .. "=" .. #items
    end
    table.sort(ipList)
    Log(TAG .. ": Pool: " .. total .. " entries | BallValid=" .. #ballPoolValid
        .. " TrailValid=" .. #trailPoolValid .. " Flipper=" .. #flipperPoolAll)
    Log(TAG .. ": FlipperByIP: " .. table.concat(ipList, ", "))
    -- Log per-hint pool sizes for ball/trail/flipper
    local hintBallList, hintTrailList, hintFlipperList = {}, {}, {}
    for h, p in pairs(ballByHint) do hintBallList[#hintBallList+1] = h.."="..#p end
    for h, p in pairs(trailByHint) do hintTrailList[#hintTrailList+1] = h.."="..#p end
    for h, p in pairs(flipperByHint) do hintFlipperList[#hintFlipperList+1] = h.."="..#p end
    table.sort(hintBallList); table.sort(hintTrailList); table.sort(hintFlipperList)
    Log(TAG .. ": BallByHint(" .. #hintBallList .. "): " .. table.concat(hintBallList, ", "))
    Log(TAG .. ": TrailByHint(" .. #hintTrailList .. "): " .. table.concat(hintTrailList, ", "))
    Log(TAG .. ": FlipperByHint(" .. #hintFlipperList .. "): " .. table.concat(hintFlipperList, ", "))
    Log(TAG .. ": TableHints: " .. (function()
        local out = {}
        for h, ip in pairs(tableHintToIP) do out[#out+1] = h .. "->" .. ip end
        table.sort(out)
        return table.concat(out, ", ")
    end)())
    -- Log per-category pool sizes
    local catSizes = {}
    for catID, items in pairs(entryPool) do
        catSizes[#catSizes+1] = (CATEGORY_NAMES[catID] or ("Cat"..catID)) .. "=" .. #items
    end
    table.sort(catSizes)
    Log(TAG .. ": PoolByCat: " .. table.concat(catSizes, ", "))
    return poolReady
end

-- ============================================================================
-- COUNT REGISTERED SLOTS
-- ============================================================================
local function collect_live_slots()
    local out = {}
    local seen = {}
    pcall(function()
        local all = FindAllOf("PFXCollectibleSlotComponent")
        if not all then return end
        for _, slot in ipairs(all) do
            if is_live(slot) then
                -- Use entry_id for filled slots, object name for empty ones
                local key = entry_id(slot)
                if key == "" then
                    key = "__empty__" .. name_of(slot)
                end
                if key ~= "" and not seen[key] then
                    seen[key] = true
                    out[#out + 1] = slot
                end
            end
        end
    end)
    return out
end

local function count_registered_slots()
    local slots = collect_live_slots()
    return #slots, slots
end

local function count_empty_registered_slots(slots)
    if not slots then return 0 end
    local empties = 0
    for _, slot in ipairs(slots) do
        pcall(function()
            if not is_live(slot) then return end
            local entry = nil
            pcall(function() entry = slot:Get("m_slotEntry") end)
            if not entry or not is_live(entry) then
                empties = empties + 1
            end
        end)
    end
    return empties
end

-- ============================================================================
-- REFLECTION HELPERS — cached function checks
-- ============================================================================
local _fn_cache = {} -- key: ClassName::Function -> bool

local function has_function(obj, fn)
    if not obj or not fn then return false end
    local className = nil
    pcall(function() className = obj:GetClass():GetName() end)
    if not className then return false end

    local key = className .. "::" .. fn
    if _fn_cache[key] ~= nil then
        return _fn_cache[key]
    end

    local ok, exists = pcall(function()
        local rc = RebuildClass(className)
        if not rc then return false end
        local funcs = rc:Functions()
        return funcs and funcs[fn] ~= nil
    end)

    _fn_cache[key] = (ok and exists) and true or false
    return _fn_cache[key]
end

-- ============================================================================
-- SWAP SLOT — Bridge-verified flow (v37):
--   1. RemovePreviousCollectible(true) — destroys old actor instantly
--   2. Set("m_slotEntry", newEntry) — update entry reference
--   3. SetupWithCollectibleEntry(newEntry) — async loads actor class, spawns, attaches
-- All three calls are on AC_CollectibleSlot_C (subclass of PFXCollectibleSlotComponent).
-- The spawn is ASYNC — actor appears after soft class finishes loading (~1-3s).
-- ============================================================================
local function is_floor_wall_slot(slot)
    local cn = nil
    pcall(function() cn = slot:GetClass():GetName() end)
    return cn == "AC_CollectibleSlot_FloorAndWall_C"
end

local function is_hub_slot(slot)
    local cn = nil
    pcall(function() cn = slot:GetClass():GetName() end)
    return cn == "AC_CollectibleSlot_Hub_C"
end

-- Cached reference to the single BP_Customization_Machine_C actor (floor/wall texture handler)
local cachedMachine = nil
local function get_machine()
    if cachedMachine and is_live(cachedMachine) then return cachedMachine end
    pcall(function() cachedMachine = FindFirstOf("BP_Customization_Machine_C") end)
    return cachedMachine
end

-- Cached reference to the room actor (BP_VR_Room_C) that holds floor/wall materials
local cachedRoom = nil
local function get_room()
    if cachedRoom and is_live(cachedRoom) then return cachedRoom end
    local machine = get_machine()
    if machine then
        pcall(function() cachedRoom = machine:Get("RoomRef") end)
    end
    return cachedRoom
end

local function swap_slot_entry(slot, newEntry)
    if not slot or not newEntry then return false end
    if not is_live(slot) or not is_live(newEntry) then return false end

    local previousEntry = nil
    pcall(function() previousEntry = slot:Get("m_slotEntry") end)

    -- ── PERSISTENT EQUIP (the game's OWN save path) ─────────────────────────────
    -- ChangeSlotEntry(newEntry, saveToProfile=true) is what the game calls when YOU
    -- equip something (BP_VR_Pawn uses it with `true` for wall/floor). When it accepts
    -- the entry it spawns the actor AND writes {slotKey -> entry} into the profile store
    -- (sub_4F1A5A0 on qword_76B4910), so on the next hub load RestoreSlotEntryFromProfile
    -- restores OUR pick — the randomization PERSISTS (no re-apply needed). It VALIDATES
    -- first and no-ops if the entry's category/IP doesn't fit the slot or the slot has no
    -- station yet; we detect that (m_slotEntry didn't change to newEntry) and fall through
    -- to the runtime-only path below, so this never regresses the current visual apply.
    -- Floor/Wall slots persist via ChangeSlotEntry too, but it does NOT drive the texture
    -- or the customization-machine PREVIEW, so we must still run ApplyFloorStyle +
    -- SetPreview below (skipping them left the wall/floor menu BLANK). So only early-return
    -- on a took for NON floor/wall slots (where ChangeSlotEntry also spawns the actor).
    local persistedFW = false
    if newEntry ~= previousEntry then
        local took = false
        pcall(function() slot:Call("ChangeSlotEntry", newEntry, true) end)
        pcall(function() took = (slot:Get("m_slotEntry") == newEntry) end)
        if took then
            stats.persisted = (stats.persisted or 0) + 1
            if not is_floor_wall_slot(slot) then return true end
            persistedFW = true
        end
    end

    if is_floor_wall_slot(slot) then
        -- FloorAndWall slots are texture-based (no spawned actor). ChangeSlotEntry above
        -- already set+saved the entry (persistedFW); here we drive the TEXTURE + the
        -- customization-machine PREVIEW so the menu shows the pick (not blank).
        if not persistedFW then
            local wrote = pcall(function() slot:Set("m_slotEntry", newEntry) end)
            if not wrote then return false end
        end
        -- Apply to ALL rooms (there are multiple BP_VR_Room_C instances)
        local cat = nil
        pcall(function() cat = slot:Get("SlotCategory") end)
        local rooms = nil
        pcall(function() rooms = FindAllOf("BP_VR_Room_C") end)
        if rooms then
            for _, room in ipairs(rooms) do
                if cat == 6 then
                    pcall(function() room:Call("ApplyFloorStyle", newEntry) end)
                elseif cat == 7 then
                    pcall(function() room:Call("ApplyWallStyle", newEntry) end)
                end
            end
        end
        -- Also update the customization machine's preview display
        local machine = get_machine()
        if machine then
            if cat == 6 then
                pcall(function() machine:Call("SetPreview_Floor", newEntry) end)
            elseif cat == 7 then
                pcall(function() machine:Call("SetPreview_Wall", newEntry) end)
            end
        end
        return true
    end

    if is_hub_slot(slot) then
        -- Hub interior uses level streaming. Set entry then ApplyNewInterior.
        local wrote = pcall(function() slot:Set("m_slotEntry", newEntry) end)
        if not wrote then return false end
        pcall(function() slot:Call("ApplyNewInterior") end)
        return true
    end

    -- Actor-based slots: full 3-step flow
    -- Step 1: Set entry first (SetupWithCollectibleEntry handles old actor internally)
    local wrote = pcall(function() slot:Set("m_slotEntry", newEntry) end)
    if not wrote then
        -- Restore on failure
        if previousEntry and is_live(previousEntry) then
            pcall(function() slot:Set("m_slotEntry", previousEntry) end)
        end
        return false
    end

    -- Step 2: Full setup — handles removing old actor, async loads new actor class, spawns
    pcall(function() slot:Call("SetupWithCollectibleEntry", newEntry) end)

    return true
end

local function infer_slot_category(slot)
    if not slot then return nil end

    -- FloorAndWall slots have an explicit SlotCategory property (6=Floor, 7=Wall)
    if is_floor_wall_slot(slot) then
        local slotCat = nil
        pcall(function() slotCat = slot:Get("SlotCategory") end)
        if type(slotCat) == "number" and slotCat > 0 then return slotCat end
    end

    -- Hub slot is always category 14
    if is_hub_slot(slot) then return 14 end

    local probes = {}

    local slotName = nil
    pcall(function() slotName = slot:Get("m_slotName") end)
    if type(slotName) == "string" and slotName ~= "" then
        probes[#probes + 1] = slotName:lower()
    end

    local slotObjName = name_of(slot)
    if slotObjName ~= "" then probes[#probes + 1] = slotObjName:lower() end

    local slotClassName = nil
    pcall(function() slotClassName = slot:GetClass():GetName() end)
    if type(slotClassName) == "string" and slotClassName ~= "" then
        probes[#probes + 1] = slotClassName:lower()
    end

    local outer = nil
    pcall(function() outer = slot:GetOuter() end)
    if outer then
        local outerObjName = name_of(outer)
        if outerObjName ~= "" then probes[#probes + 1] = outerObjName:lower() end
        local outerClassName = nil
        pcall(function() outerClassName = outer:GetClass():GetName() end)
        if type(outerClassName) == "string" and outerClassName ~= "" then
            probes[#probes + 1] = outerClassName:lower()
        end
    end

    local orderedKeywords = {
        { "hubinterior", 14 },
        { "hub_interior", 14 },
        { "interior", 14 },
        { "gadget", 5 },
        { "statue", 4 },
        { "poster", 3 },
        { "music", 8 },
        { "flipper", 9 },
        { "balltrail", 11 },
        { "trail", 11 },
        { "ballskin", 10 },
        { "ball", 10 },
        { "floor", 6 },
        { "wall", 7 },
        { "arm", 1 },
        { "door", 15 },
        { "cabinet", 13 },
        { "trophy", 12 },
    }

    for _, s in ipairs(probes) do
        for _, k in ipairs(orderedKeywords) do
            if s:find(k[1], 1, true) then
                return k[2]
            end
        end
    end

    return nil
end

-- ============================================================================
-- SCRAMBLE HUB SLOTS — batched with delays to avoid engine stale-ref crashes
-- v28: Execute swaps in small batches (BATCH_SIZE per tick) with delay between
-- batches, giving the engine time to process component updates.
-- ============================================================================
local SCRAMBLE_BATCH_SIZE = 8   -- swaps per batch
local SCRAMBLE_BATCH_DELAY = 200 -- ms between batches

-- Remove the game's slot IP/category restriction so ANY collectible can be equipped into
-- ANY slot AND saved to profile (RestoreSlotEntryFromProfile then restores our pick =
-- persists). Patches PFXCollectibleSlotComponent::ChangeSlotEntry (sub_4F1B00C): right
-- after its station-null check at libUnreal+0x4F1B054, branch straight to the accept+save
-- path at +0x4F1B134, skipping the category + IP validation.
--   original @+0x4F1B054: LDR W8,[X23,#0x310]  = 0xB94312E8
--   patched:              B  0x4F1B134         = 0x14000038   (rel +0xE0)
-- Written via /proc/self/mem (bypasses the RO code page). Re-applied per game session
-- (the .so is fresh on restart). VERIFIED live: a cross-IP entry then persists.
-- Also patches out the SINGLE-INSTANCE DUPLICATE EVICTION in the profile-save function
-- sub_4F1A5A0: at libUnreal+0x4F1A7EC it reads the collectible's single-instance flag
-- (LDRB W9,[X26,#0x91]) and `CBZ W9, loc_4F1AA1C` skips building the evict-list only when
-- the flag is 0. We force that branch UNCONDITIONAL (B loc_4F1AA1C = 0x1400008C, was
-- 0x34001189) so the evict-list is NEVER built -> the same collectible can sit in multiple
-- slots without the game clearing the others. VERIFIED live: dup kept in both slots.
local function patch_slot_ip_restriction()
    if _G._RAND_IP_PATCHED then return true end
    local base = (_G.PFXCore and _G.PFXCore.base and _G.PFXCore.base()) or 0
    if not (type(base) == "number" and base > 0x1000) then return false end
    pcall(function() if _G.PFXCore.unharden then _G.PFXCore.unharden() end end)
    -- idempotent single-dword patch; only writes if the bytes match the expected original
    local function patch1(off, orig, new, label)
        local addr = base + off
        local cur = 0; pcall(function() cur = MemReadU32(addr) end)
        if cur == new then return true end
        if cur ~= orig then
            Log(TAG .. string.format(": %s patch SKIPPED — unexpected 0x%08X @+0x%X (game updated?)", label, cur, off))
            return false
        end
        pcall(function() MemWriteU32(addr, new) end)
        local now = 0; pcall(function() now = MemReadU32(addr) end)
        return now == new
    end
    -- (1) IP/category restriction in ChangeSlotEntry -> branch to the accept+save path
    local ok1 = patch1(0x4F1B054, 0xB94312E8, 0x14000038, "IP-restriction")
    -- (2) single-instance duplicate eviction in the save fn -> skip building the evict-list
    local ok2 = patch1(0x4F1A7EC, 0x34001189, 0x1400008C, "dup-eviction")
    if ok1 then
        _G._RAND_IP_PATCHED = true
        Log(TAG .. string.format(": PATCHED — any collectible persists in any slot; duplicates allowed (evict-patch=%s)", tostring(ok2)))
        return true
    end
    return false
end

-- IP KEY of an entry. With the restriction patched out (patch_slot_ip_restriction), IP no
-- longer matters, so ALL entries collapse to one pool per category ("*") = full cross-IP
-- randomization. If the patch ever fails (game update), we fall back to the real IP key
-- (tag minus the trailing item segment) so same-IP swaps still take.
local function entry_ipkey(entry)
    if _G._RAND_IP_PATCHED then return "*" end
    local t = ""
    pcall(function()
        local id = entry:Call("GetEntryID")
        if id then local tn; pcall(function() tn = id.TagName end); if tn then t = tostring(tn) end end
    end)
    if t == "" then return "?" end
    return (t:gsub("%.[^%.]*$", ""))
end

-- Pick a random entry sharing `ipkey` from category `cID`, cycled WITHOUT repeats (a
-- collectible is single-instance: reusing it evicts it from its other slot -> new empty).
-- Lazily indexes entryPool by IP on first use; invalidated when the pool rebuilds. Shared
-- by scramble_all_slots + maintenance_pass so they never fight over the same entry.
local function pick_same_ip(cID, ipkey, excludeKey)
    if not _poolByIP then
        _poolByIP = {}
        for c2, pool in pairs(entryPool) do
            local m = {}
            for _, e in ipairs(pool) do
                local ip = entry_ipkey(e)
                if not m[ip] then m[ip] = {} end
                m[ip][#m[ip] + 1] = e
            end
            _poolByIP[c2] = m
        end
        _cyclesByIP = {}
    end
    local m = _poolByIP[cID]
    local cands = m and m[ipkey]
    if not cands or #cands == 0 then return nil end
    if not _cyclesByIP[cID] then _cyclesByIP[cID] = {} end
    local c = _cyclesByIP[cID][ipkey]
    if not c then c = make_cycle_state(cands, entry_key); _cyclesByIP[cID][ipkey] = c end
    return take_from_cycle(c, excludeKey) or cands[math.random(#cands)]
end

local function scramble_all_slots(incremental)
    if not poolReady then pcall(build_entry_pool) end
    if not poolReady then
        Log(TAG .. ": Scramble skipped — pool not ready")
        return 0
    end
    pcall(patch_slot_ip_restriction)   -- remove IP/category limit BEFORE we pick (collapses pools to cross-IP)

    local slotCount, liveSlots = count_registered_slots()
    if slotCount == 0 or not liveSlots then
        Log(TAG .. ": Scramble skipped — RegisteredSlots empty (" .. slotCount .. ")")
        return 0
    end

    -- Per-slot SEEN tracking. `incremental` (the auto-loop, as new stations stream in)
    -- skips slots already randomized this session so it ONLY touches newly-loaded slots —
    -- posters/statues/walls/floors get randomized when you reach their station, spread,
    -- without re-randomizing (or re-lagging) the ones already done. A full manual/init
    -- run passes incremental=false, which resets SEEN and re-randomizes everything.
    if not incremental then _G._RAND_SLOT_SEEN = {} end
    _G._RAND_SLOT_SEEN = _G._RAND_SLOT_SEEN or {}
    local SEEN = _G._RAND_SLOT_SEEN
    local function seen_key(s) local n = nil; pcall(function() n = s:GetName() end); return n end

    -- Build work list: {slot, picked_entry} pairs
    local workList = {}

    -- Group slots by category, track empty slots separately
    local slotsByCategory = {}
    local emptySlots = {}
    for _, slot in ipairs(liveSlots) do
        pcall(function()
            if not is_live(slot) then return end
            local sk = seen_key(slot)
            if incremental and sk and SEEN[sk] then return end   -- already randomized this session
            local entry = nil
            pcall(function() entry = slot:Get("m_slotEntry") end)
            if not entry or not is_live(entry) then
                emptySlots[#emptySlots + 1] = slot   -- marked SEEN only if actually filled below
                return
            end
            local catID = get_category_id(entry)
            if not catID or SKIP_CATEGORIES[catID] then return end
            if sk then SEEN[sk] = true end

            local stationKey = ""
            pcall(function()
                local ownerStation = slot:Get("m_ownerStationComponent")
                if ownerStation and is_live(ownerStation) then
                    stationKey = entry_id(ownerStation)
                end
            end)
            if stationKey == "" then
                pcall(function()
                    local outer = slot:GetOuter()
                    if outer and is_live(outer) then stationKey = entry_id(outer) end
                end)
            end
            if stationKey == "" then stationKey = "__global__" end

            if not slotsByCategory[catID] then slotsByCategory[catID] = {} end
            slotsByCategory[catID][#slotsByCategory[catID] + 1] = {
                slot = slot,
                currentKey = entry_key(entry),
                stationKey = stationKey,
                ipkey = entry_ipkey(entry),   -- slot's IP: replacements MUST share it
            }
        end)
    end

    local totalSkip = 0

    -- Slots are IP-RESTRICTED (a "Collectibles.IP.General" slot rejects a "...PacificRim"
    -- entry — the game's ChangeSlotEntry no-ops), so replacements MUST share the slot's IP
    -- key; pick_same_ip (module-level) cycles each (category,IP) pool without repeats.
    -- Filled slots: swap to a random SAME-IP, same-category entry.
    for catID, slotList in pairs(slotsByCategory) do
        if not entryPool[catID] or #entryPool[catID] == 0 then
            totalSkip = totalSkip + #slotList
        else
            local shuffledSlots = {}
            for i, si in ipairs(slotList) do shuffledSlots[i] = si end
            shuffle(shuffledSlots)
            for _, slotInfo in ipairs(shuffledSlots) do
                local picked = pick_same_ip(catID, slotInfo.ipkey, slotInfo.currentKey)
                if picked then
                    workList[#workList + 1] = { slot = slotInfo.slot, entry = picked }
                else
                    totalSkip = totalSkip + 1
                end
            end
        end
    end

    -- Fill empty slots: an empty slot has no entry to reveal its IP, so we take the IP
    -- (and, when infer_slot_category can't tell, the category) from a sibling slot on the
    -- SAME station/shelf, then fill via the persistent same-IP path. Slots we can't
    -- categorize/IP are LEFT ALONE (v43: forcing a wrong entry onto a pedestal is exactly
    -- what caused "empty gadget slots when not supposed to").
    if #emptySlots > 0 then
        local byStation = {}
        for catID, slotList in pairs(slotsByCategory) do
            for _, si in ipairs(slotList) do
                if si.stationKey and si.stationKey ~= "" then
                    if not byStation[si.stationKey] then byStation[si.stationKey] = {} end
                    local b = byStation[si.stationKey]
                    b[#b + 1] = { cat = catID, ipkey = si.ipkey }
                end
            end
        end
        local filledEmpty, stillEmpty = 0, 0
        for _, emptySlot in ipairs(emptySlots) do
            pcall(function()
                local stationKey = nil
                pcall(function() local os = emptySlot:Get("m_ownerStationComponent"); if os and is_live(os) then stationKey = entry_id(os) end end)
                if not stationKey then pcall(function() local o = emptySlot:GetOuter(); if o and is_live(o) then stationKey = entry_id(o) end end) end
                local cat = infer_slot_category(emptySlot)
                local sibs = stationKey and byStation[stationKey]
                local ipkey, sibCat = nil, nil
                if sibs then
                    for _, sb in ipairs(sibs) do
                        sibCat = sibCat or sb.cat
                        ipkey = ipkey or sb.ipkey                 -- shelf-mates share the station IP
                        if cat and sb.cat == cat then ipkey = sb.ipkey end
                    end
                end
                cat = cat or sibCat
                if cat and not SKIP_CATEGORIES[cat] and ipkey then
                    local picked = pick_same_ip(cat, ipkey, nil)
                    if picked then
                        workList[#workList + 1] = { slot = emptySlot, entry = picked, isEmpty = true }
                        local esk = seen_key(emptySlot); if esk then SEEN[esk] = true end
                        filledEmpty = filledEmpty + 1
                        return
                    end
                end
                stillEmpty = stillEmpty + 1
            end)
        end
        Log(TAG .. string.format(": Empty slots: %d total, %d fill (same-IP), %d left (uncat/no-IP)",
            #emptySlots, filledEmpty, stillEmpty))
    end

    -- Execute work list in staggered batches
    local totalWork = #workList
    local numBatches = math.ceil(totalWork / SCRAMBLE_BATCH_SIZE)
    stats.sweeps = stats.sweeps + 1
    local sweepNum = stats.sweeps

    Log(TAG .. ": Scramble #" .. sweepNum .. ": " .. totalWork .. " swaps queued in "
        .. numBatches .. " batches (" .. SCRAMBLE_BATCH_SIZE .. "/batch, "
        .. SCRAMBLE_BATCH_DELAY .. "ms apart), " .. totalSkip .. " skip, "
        .. #emptySlots .. " empty")

    for batch = 1, numBatches do
        local startIdx = (batch - 1) * SCRAMBLE_BATCH_SIZE + 1
        local endIdx = math.min(batch * SCRAMBLE_BATCH_SIZE, totalWork)
        local delay = (batch - 1) * SCRAMBLE_BATCH_DELAY

        ExecuteWithDelay(delay, function()
            local batchOk, batchErr, batchEmpty = 0, 0, 0
            for i = startIdx, endIdx do
                local work = workList[i]
                if work and is_live(work.slot) and is_live(work.entry) then
                    if swap_slot_entry(work.slot, work.entry) then
                        batchOk = batchOk + 1
                        if work.isEmpty then batchEmpty = batchEmpty + 1 end
                    else
                        batchErr = batchErr + 1
                    end
                else
                    batchErr = batchErr + 1
                end
            end
            stats.sweep_ok = stats.sweep_ok + batchOk
            stats.sweep_err = stats.sweep_err + batchErr
            stats.empty_filled = stats.empty_filled + batchEmpty

            if batch == numBatches then
                Log(TAG .. ": Scramble #" .. sweepNum .. " complete: ok="
                    .. stats.sweep_ok .. " err=" .. stats.sweep_err
                    .. " empty=" .. stats.empty_filled)
            end
        end)
    end

    return totalWork
end

-- ============================================================================
-- SCRAMBLE ONE SLOT (for RestoreSlotEntryFromProfile post-hook)
-- ============================================================================
local function scramble_one_slot(slot, source)
    if not poolReady then return false end
    if not is_live(slot) then return false end

    local currentEntry = nil
    pcall(function() currentEntry = slot:Get("m_slotEntry") end)

    local catID = nil
    local currentKey = nil
    if currentEntry and is_live(currentEntry) then
        catID = get_category_id(currentEntry)
        currentKey = entry_key(currentEntry)
    else
        catID = infer_slot_category(slot)
    end

    if not catID or SKIP_CATEGORIES[catID] then
        stats[source .. "_skip"] = (stats[source .. "_skip"] or 0) + 1
        return false
    end

    local pool = entryPool[catID]
    if not pool or #pool == 0 then
        stats[source .. "_skip"] = (stats[source .. "_skip"] or 0) + 1
        return false
    end

    if not hook_used_by_category then hook_used_by_category = {} end
    if not hook_used_by_category[catID] then
        hook_used_by_category[catID] = make_cycle_state(pool, entry_key)
    end

    local newEntry = take_from_cycle(hook_used_by_category[catID], currentKey)

    if not newEntry then
        stats[source .. "_skip"] = (stats[source .. "_skip"] or 0) + 1
        return false
    end

    -- 3-step swap: data + notify + visual
    if swap_slot_entry(slot, newEntry) then
        stats[source .. "_ok"] = (stats[source .. "_ok"] or 0) + 1
        return true
    else
        stats[source .. "_err"] = (stats[source .. "_err"] or 0) + 1
        return false
    end
end

-- ============================================================================
-- HOOK: RestoreSlotEntryFromProfile → scramble after each restore
-- ============================================================================
local hookRegistered = false
local hook_used_by_category = {}
local hookCallCount = 0       -- RestoreSlotEntryFromProfile fire count = load activity

-- v44 CRASH FIX: the post-hook NO LONGER scrambles during the restore. Swapping
-- entries / calling Blueprint setup (SetupWithCollectibleEntry) WHILE the hub is
-- still streaming — on half-constructed, still-loading UObjects, inside the
-- modloader's deferred-Lua queue — corrupted the Lua VM (tick_game_thread ->
-- luaV_execute SIGSEGV, a crash-loop at hub load). We now ONLY COUNT restores; the
-- init gate below waits until they STOP (data fully loaded + settled) and then does
-- every swap once, gently, on stable objects.
pcall(function()
    RegisterHook("/Script/PFXCollectibles.PFXCollectibleSlotComponent:RestoreSlotEntryFromProfile",
        function(self) end,   -- pre-hook: nothing
        function(self)        -- post-hook: only tally load activity (no reflection, no swap)
            hookCallCount = hookCallCount + 1
        end
    )
    hookRegistered = true
    Log(TAG .. ": Hook: RestoreSlotEntryFromProfile counter ENABLED (v44 — no in-load scramble)")
end)
if not hookRegistered then
    Log(TAG .. ": Hook: RestoreSlotEntryFromProfile FAILED to register")
end

-- v46: gate the ENTIRE randomizer on the game's OWN readiness signal. The boot
-- flow (BP_GameflowStart_C, in LVL_VR_Main) fires, in order: OnSettingsLoaded ->
-- OnProfileLoaded -> OnUserLoggedIn -> OnTablesDataLoaded. OnTablesDataLoaded is the
-- definitive "player initialized, tables and all loaded" event. We touch NOTHING
-- until it fires — running before it meant operating on half-initialized objects,
-- which corrupted the Lua VM (the crash-loop). After it fires we STILL wait for the
-- hub slots to settle, then scramble once.
local tablesReady = false
pcall(function()
    RegisterHook("/Game/Blueprints/BP_GameflowStart.BP_GameflowStart_C:OnTablesDataLoaded",
        function(self) end,
        function(self)
            tablesReady = true
            Log(TAG .. ": SIGNAL — OnTablesDataLoaded fired (player + tables initialized)")
        end
    )
    Log(TAG .. ": Hook: BP_GameflowStart.OnTablesDataLoaded gate ENABLED")
end)

-- ============================================================================
-- PER-TABLE COSMETICS — Ball + Trail + Flippers (IP-MATCHED)
-- ============================================================================
-- v28 Fix: ALL ball/trail/flipper entries are IP-locked (table-specific).
-- Each table only gets cosmetics from its own IP group.
-- Table→IP mapping is built from entry tags + bundle name matching.
-- ============================================================================

-- Some tables' entry-tag hint names are ABBREVIATIONS that don't literal-substring
-- match their bundle name (the game shortens them). Without these, exactly 3 tables
-- resolve hint=nil and get NO ball/trail/flipper cosmetic:
--   adamsf     (tag) vs 156_AddamsFamily_Bundle
--   bsg        (tag) vs 170_BattlestarGalactica_Bundle
--   croftmanor (tag) vs 192_TombRaider_Manor_Bundle
-- Each alias below is unique to its one bundle, so there's no cross-match risk.
local HINT_ALIASES = {
    adamsf     = { "addams" },
    bsg        = { "battlestar", "galactica" },
    croftmanor = { "manor" },
}

-- Resolve a table hint from ANY identifying string (bundle key, cabinet name,
-- Table Info name/IP) by normalized substring match against known hints + aliases.
local function resolve_table_hint(bundleKey)
    if not bundleKey or bundleKey == "" then return nil end
    local bk = norm_name(bundleKey)
    for hint, _ in pairs(tableHintToIP) do
        if bk:find(hint, 1, true) then
            return hint
        end
        local aliases = HINT_ALIASES[hint]
        if aliases then
            for _, a in ipairs(aliases) do
                if bk:find(a, 1, true) then return hint end
            end
        end
    end
    return nil
end

local function resolve_table_ip(bundleKey)
    local hint = resolve_table_hint(bundleKey)
    return hint and tableHintToIP[hint] or nil
end

-- v43 REWRITE: apply per-table ball/trail/flipper cosmetics by calling each
-- cabinet's OWN BP_CabinetBase_C::SetupFromCollectibleEntry(entry) — the exact
-- path the game uses when you equip a cosmetic. This is the ONLY correct route:
--   * it uses the cabinet's real Table Info->PITId (NOT the bundle-prefix number),
--   * it does the UObject->TSoftObjectPtr conversion the SetTableXxxOverride
--     natives require (BallSkin/BallTrail are hard ObjectProperties on the entry,
--     but the override params are TSoftObjectPtr — passing the hard ptr straight
--     in mis-marshalled the ProcessEvent buffer => out-of-bounds => crash + no
--     visible skin). The entry's CATEGORY selects ball(10)/trail(11)/flipper(9).
-- Apply ONE cabinet's random ball/trail/flipper RIGHT NOW (no batching). Idempotent via
-- the per-PitID _RAND_*_DONE trackers. Driven per-cabinet from the AllLoadingFinished hook
-- so the cosmetic's soft-asset load happens DURING that cabinet's own load (masked) instead
-- of a bulk burst after all cabinets stream in (the "customization fires in bulk" lag).
local function apply_one_cabinet(cab)
    if not poolReady or not is_live(cab) then return 0 end
    if #ballPoolValid == 0 and #trailPoolValid == 0 and #flipperPoolAll == 0 then return 0 end
    _G._RAND_FLIP_DONE  = _G._RAND_FLIP_DONE  or {}
    _G._RAND_BALL_DONE  = _G._RAND_BALL_DONE  or {}
    _G._RAND_TRAIL_DONE = _G._RAND_TRAIL_DONE or {}
    local applied = 0
    pcall(function()
        local ti = nil
        pcall(function() ti = cab:Call("GetTableInfo") end)
        if not (ti and is_live(ti)) then pcall(function() ti = cab:Get("Table Info") end) end
        if not (ti and is_live(ti)) then pcall(function() ti = cab:Get("TableInfo") end) end
        if not (ti and is_live(ti)) then return end
        local pit = nil; pcall(function() pit = ti:Get("PitID") end)
        if type(pit) ~= "number" then return end
        local tname = ""; pcall(function() tname = tostring(ti:Get("Name")) end)
        local hint = resolve_table_hint(tname) or resolve_table_hint(name_of(cab))
        if not hint then return end
        local tip = tableHintToIP[hint]
        local function apply(entry)
            if entry and is_live(entry) then
                if pcall(function() cab:Call("SetupFromCollectibleEntry", entry) end) then applied = applied + 1 end
            end
        end
        if not _G._RAND_BALL_DONE[pit] then
            local bp = ballByHint[hint]; if not (bp and #bp > 0) and tip then bp = ballByIP[tip] end; if not (bp and #bp > 0) then bp = ballPoolValid end
            if bp and #bp > 0 then local pk = bp[math.random(#bp)]; if pk and pk.entry then _G._RAND_BALL_DONE[pit] = true; apply(pk.entry) end end
        end
        if not _G._RAND_TRAIL_DONE[pit] then
            local tp = trailByHint[hint]; if not (tp and #tp > 0) and tip then tp = trailByIP[tip] end; if not (tp and #tp > 0) then tp = trailPoolValid end
            if tp and #tp > 0 then local pk = tp[math.random(#tp)]; if pk and pk.entry then _G._RAND_TRAIL_DONE[pit] = true; apply(pk.entry) end end
        end
        if not _G._RAND_FLIP_DONE[pit] then
            local fp = flipperByHint[hint]
            if fp and #fp > 0 then local pk = fp[math.random(#fp)]; if pk then _G._RAND_FLIP_DONE[pit] = true; apply(pk) end end
        end
    end)
    return applied
end

-- Per-cabinet event hook: apply THIS cabinet's cosmetic as it finishes loading (targeted,
-- spread across cabinets' natural load times — no bulk spike). A tiny delay lets the
-- cabinet's own SetupFromCollectibleEntry (its default cosmetic) run first.
pcall(function()
    RegisterHook("/Game/Blueprints/BP_CabinetBase.BP_CabinetBase_C:AllLoadingFinished",
        function(self) end,
        function(self)
            if _G._RAND_GEN ~= MY_GEN then return end
            local cab = self
            ExecuteWithDelay(60, function()
                if _G._RAND_GEN == MY_GEN and poolReady then pcall(function() apply_one_cabinet(cab) end) end
            end)
        end)
    Log(TAG .. ": Hook: BP_CabinetBase.AllLoadingFinished — per-cabinet cosmetics (no bulk spike)")
end)

local function scramble_table_cosmetics()
    if not poolReady then pcall(build_entry_pool) end   -- build on demand (e.g. manual/API call before auto-init)
    if not poolReady then
        Log(TAG .. ": Table cosmetics skipped — pool not ready")
        return 0
    end
    if #ballPoolValid == 0 and #trailPoolValid == 0 and #flipperPoolAll == 0 then
        Log(TAG .. ": Table cosmetics skipped — no ball/trail/flipper entries loaded")
        return 0
    end

    local cabinets = nil
    pcall(function() cabinets = FindAllOf("BP_CabinetBase_C") end)
    if not cabinets or #cabinets == 0 then
        Log(TAG .. ": Table cosmetics skipped — no BP_CabinetBase_C cabinets present")
        return 0
    end

    -- FALLBACK / manual pass: apply ONE cabinet per staggered tick (never a bulk burst)
    -- for cabinets that were already loaded before the AllLoadingFinished hook could fire
    -- (mod reload, or /randomize). apply_one_cabinet is idempotent (per-PitID _RAND_*_DONE),
    -- so cabinets the hook already handled cost almost nothing here.
    local seen, list = {}, {}
    for _, cab in ipairs(cabinets) do
        if is_live(cab) then
            local id = entry_id(cab)
            if id == "" or not seen[id] then
                if id ~= "" then seen[id] = true end
                list[#list + 1] = cab
            end
        end
    end
    local DELAY = 120   -- ms between cabinets — spread the (rare) fallback work out
    for i, cab in ipairs(list) do
        ExecuteWithDelay((i - 1) * DELAY, function()
            if _G._RAND_GEN == MY_GEN and is_live(cab) then pcall(function() apply_one_cabinet(cab) end) end
        end)
    end
    Log(TAG .. string.format(": Table cosmetics: %d cabinets scheduled 1/%dms (per-cabinet, hook-driven primary)", #list, DELAY))
    return #list
end

-- v43: flippers are now applied through cabinet:SetupFromCollectibleEntry inside
-- scramble_table_cosmetics (the same path the game uses to equip an arm skin), so
-- this deferred applier is a no-op kept only so existing callers stay valid.
local function apply_pending_flipper_overrides()
    pendingFlipperOverrides = {}
end

-- ============================================================================
-- DESTROY XARCADE PROMO — repeating to catch late-streamed sublevel actors
-- BP_XArcadePromo_C lives in LVL_Arcade_80s_Rooms_OPTI_DLC1 (streamed)
-- Also hides door logo material and disables lights/shadows
-- ============================================================================
local XARCADE_CLASSES = {"BP_XArcadePromo_C"}
local xarcadeTotalDestroyed = 0

local function destroy_xarcade_actors()
    local destroyed = 0
    for _, cls in ipairs(XARCADE_CLASSES) do
        pcall(function()
            local actors = FindAllOf(cls)
            if actors then
                for _, a in ipairs(actors) do
                    if is_live(a) then
                        -- Disable shadow casting + lights on all components
                        pcall(function()
                            local allComps = a:Call("K2_GetComponentsByClass", FindClass("ActorComponent"))
                            if allComps then
                                for _, comp in ipairs(allComps) do
                                    pcall(function() comp:Set("bVisible", false) end)
                                    pcall(function() comp:Set("CastShadow", false) end)
                                    pcall(function() comp:Set("bCastDynamicShadow", false) end)
                                    pcall(function() comp:Set("bCastStaticShadow", false) end)
                                    pcall(function() comp:Set("bAffectsWorld", false) end)
                                    pcall(function() comp:Set("Intensity", 0) end)
                                end
                            end
                        end)
                        local apath = "?"
                        pcall(function() apath = a:GetPathName() end)
                        Log(TAG .. ": [XArcade promo] DESTROYING: " .. apath)
                        pcall(function() a:Call("SetActorHiddenInGame", true) end)
                        pcall(function() a:Call("SetActorEnableCollision", false) end)
                        pcall(function() a:Set("bActorEnableCollision", false) end)
                        -- Move it far underground to hide any remnant shadows
                        pcall(function() a:Call("K2_SetActorLocation", {X=0, Y=0, Z=-50000}, false, false) end)
                        pcall(function() a:Call("K2_DestroyActor") end)
                        destroyed = destroyed + 1
                    end
                end
            end
        end)
    end
    if destroyed > 0 then
        xarcadeTotalDestroyed = xarcadeTotalDestroyed + destroyed
        Log(TAG .. ": Destroyed " .. destroyed .. " XArcade promo actor(s) (total=" .. xarcadeTotalDestroyed .. ")")
    end

    -- Find and destroy the XArcade door arch sign StaticMeshActor.
    -- StaticMeshActors are few (~hundreds) so checking their root SMC materials is safe.
    -- We only call GetMaterial on the root StaticMeshComponent, not arbitrary components.
    pcall(function()
        local smas = FindAllOf("StaticMeshActor")
        if not smas then return end
        for _, sma in ipairs(smas) do
            pcall(function()
                if not is_live(sma) then return end
                local smc = nil
                pcall(function() smc = sma:Get("StaticMeshComponent") end)
                if not smc then return end
                -- Only check actors that have a loaded mesh
                local mesh = nil
                pcall(function() mesh = smc:Get("StaticMesh") end)
                if not mesh then return end
                local numMats = 0
                pcall(function() numMats = smc:Call("GetNumMaterials") end)
                if numMats == 0 then return end
                for mi = 0, numMats - 1 do
                    pcall(function()
                        local mat = nil
                        pcall(function() mat = smc:Call("GetMaterial", mi) end)
                        if mat then
                            local mn = ""
                            pcall(function() mn = mat:GetName() end)
                            if mn:lower():find("xarcade") then
                                local apath = "?"
                                local mpath = "?"
                                pcall(function() apath = sma:GetPathName() end)
                                pcall(function() mpath = mat:GetPathName() end)
                                Log(TAG .. ": [XArcade sign] ACTOR=" .. apath)
                                Log(TAG .. ": [XArcade sign] MAT[" .. mi .. "]=" .. mpath)
                                pcall(function() sma:Call("SetActorHiddenInGame", true) end)
                                pcall(function() sma:Call("SetActorEnableCollision", false) end)
                                pcall(function() sma:Call("K2_DestroyActor") end)
                                Log(TAG .. ": [XArcade sign] DESTROYED")
                            end
                        end
                    end)
                end
            end)
        end
    end)

    return destroyed
end

-- Repeating timer: keep checking for late-streamed XArcade actors for 90s after init
local xarcadeCheckCount = 0
local MAX_XARCADE_CHECKS = 15  -- 15 checks * 6s = 90s

-- ============================================================================
-- INIT: Poll every 3s until slots stabilize (v34: wait for FULL hub load)
-- Hub has ~206 slots. We require 150+ AND 3 consecutive stable polls so all
-- RestoreSlotEntryFromProfile calls finish before we scramble.
-- ============================================================================
-- v44: WAIT FOR FULL HUB LOAD before touching anything. Require slot count,
-- restore-hook fire count (RestoreSlotEntryFromProfile), AND entry-pool size to ALL
-- stop changing for STABLE_POLLS consecutive 3s polls — i.e. the hub finished
-- streaming its slots + entries and the game finished restoring the profile. Only
-- then (plus a settle margin) do we scramble, each stage on its own delayed tick.
-- Doing this mid-load, on half-constructed objects, crashed the Lua VM.
local MAX_POLLS = 120           -- 6-min ceiling at 3s/poll
-- The hub STREAMS its slots by area, so the count varies (57 in the gadget area,
-- ~164 with the full customization view). 150 was far too high — it blocked forever
-- in smaller areas. Fire once there are enough slots to be meaningfully loaded AND
-- they've stopped changing; the bounded finalize + the /randomize command cover the
-- rest as the user moves around.
local MIN_SLOTS = 20
local STABLE_POLLS = 4          -- slots+restores+pool all unchanged this many polls
local initDone = false
local pollCount = 0
local prevSlots, prevRestores, prevPool = -1, -1, -1
local stableStreak = 0

LoopAsync(3000, function()
    if _G._RAND_GEN ~= MY_GEN then return true end   -- superseded by a reload
    pollCount = pollCount + 1
    if initDone then return true end
    if pollCount > MAX_POLLS then
        Log(TAG .. ": GAVE UP waiting for a stable hub after " .. MAX_POLLS .. " polls")
        return true
    end

    -- PRIMARY GATE: the game's own readiness signal. Do NOTHING until the boot flow
    -- reports the player + tables are initialized. Fall back to slot-stability only if
    -- the signal never arrives (hook missed) after ~90s, so we never hang forever.
    if not tablesReady and pollCount < 30 then
        if pollCount % 4 == 0 then
            Log(TAG .. ": waiting for OnTablesDataLoaded (player/tables init)... poll " .. pollCount)
        end
        return false
    end

    local slotCount = count_registered_slots()
    if slotCount < MIN_SLOTS then
        stableStreak = 0
        Log(TAG .. ": Poll #" .. pollCount .. " — slots " .. slotCount .. "/" .. MIN_SLOTS .. " (hub loading)")
        return false
    end

    -- LIGHT entry-load probe: raw FindAllOf COUNTS only, NO per-entry reflection.
    -- CRITICAL: build_entry_pool() reflects on every entry (GetEntryID/GetClassName/
    -- Get("ballskin")) and that SIGSEGVs (uncatchable, pcall can't stop it) on the
    -- half-constructed entries that are still STREAMING in — this was the boot crash.
    -- So we must NOT build the pool while entries are still loading; here we only count
    -- them (cheap, no deref of their fields) to detect when streaming has stopped, and
    -- build the pool ONCE below, after the counts have held steady.
    local function raw_n(cls) local a = FindAllOf(cls); return a and #a or 0 end
    local poolTotal = raw_n("PFXCollectibleEntry_BallSkin")
                    + raw_n("PFXCollectibleEntry_BallTrail")
                    + raw_n("PFXCollectibleEntry_FlipperArm")
                    + raw_n("PFXCollectibleEntry_Gadget")
                    + raw_n("PFXCollectibleEntry_Statue")
                    + raw_n("PFXCollectibleEntry_Poster")
    if poolTotal == 0 then
        stableStreak = 0
        Log(TAG .. ": Poll #" .. pollCount .. " — slots=" .. slotCount .. " but no entries yet, waiting")
        return false
    end

    -- Ready only when slots, restore-count, and pool size have ALL held steady.
    if slotCount == prevSlots and hookCallCount == prevRestores and poolTotal == prevPool then
        stableStreak = stableStreak + 1
    else
        stableStreak = 0
    end
    prevSlots, prevRestores, prevPool = slotCount, hookCallCount, poolTotal

    if stableStreak < STABLE_POLLS then
        Log(TAG .. string.format(": Poll #%d — settling (slots=%d restores=%d pool=%d) stable %d/%d",
            pollCount, slotCount, hookCallCount, poolTotal, stableStreak, STABLE_POLLS))
        return false
    end

    initDone = true
    -- Entry counts have held steady for STABLE_POLLS (~12s) => streaming has finished,
    -- so it's now SAFE to reflect on the entries. Build the pool exactly ONCE here.
    pcall(build_entry_pool)
    Log(TAG .. string.format(": READY — fully loaded (slots=%d rawEntries=%d restores=%d | Ball=%d Trail=%d Flip=%d). Scrambling staggered...",
        slotCount, poolTotal, hookCallCount, #ballPoolValid, #trailPoolValid, #flipperPoolAll))

    -- Work AFTER an extra settle margin, each stage on its own delayed tick so no two
    -- heavy passes share a frame. Nothing here ran during the load storm, and each is
    -- gated on hub_active() so nothing runs if a table was entered in the meantime.
    ExecuteWithDelay(1500, function() if _G._RAND_GEN==MY_GEN and hub_active() then pcall(scramble_all_slots) end end)
    ExecuteWithDelay(5000, function() if _G._RAND_GEN==MY_GEN and hub_active() then pcall(scramble_table_cosmetics) end end)
    ExecuteWithDelay(8000, function() if _G._RAND_GEN==MY_GEN and hub_active() then pcall(destroy_xarcade_actors) end end)

    -- Repeating XArcade destroy timer (catches late-streamed sublevel actors)
    LoopAsync(6000, function()
        if _G._RAND_GEN ~= MY_GEN then return true end
        if not hub_active() then return true end
        xarcadeCheckCount = xarcadeCheckCount + 1
        if xarcadeCheckCount > MAX_XARCADE_CHECKS then return true end
        pcall(destroy_xarcade_actors)
        return false
    end)

    return true
end)

-- ============================================================================
-- POST-INIT MAINTENANCE (v43) — the previous version was a NO-OP, so late-loaded
-- and never-restored (unowned) empty slots were left empty forever and blacklisted
-- entries the game restored into slots were never removed. This pass, run on a
-- bounded adaptive timer, (a) fills any empty slot whose category we can infer and
-- (b) replaces any blacklisted entry sitting in a live slot. Capped per pass to
-- avoid a spawn spike; stops once two consecutive passes are clean.
-- ============================================================================
local maint_cycles = {}
local MAINT_PER_PASS = 12   -- cap swaps per pass (spreads async actor spawns)

local function maintenance_pass()
    if not poolReady then return 0, 0 end
    pcall(patch_slot_ip_restriction)   -- ensure any-entry-any-slot before we equip
    local _, liveSlots = count_registered_slots()
    if not liveSlots then return 0, 0 end
    local filled, cleaned = 0, 0
    for _, slot in ipairs(liveSlots) do
        if (filled + cleaned) >= MAINT_PER_PASS then break end
        pcall(function()
            if not is_live(slot) then return end
            local entry = nil
            pcall(function() entry = slot:Get("m_slotEntry") end)
            local elive = entry and is_live(entry)

            if elive and is_blacklisted_entry(entry) then
                -- (b) blacklisted entry sitting in a slot -> replace with a clean pick
                local catID = get_category_id(entry) or infer_slot_category(slot)
                if catID and not SKIP_CATEGORIES[catID] then
                    local pick = pick_same_ip(catID, entry_ipkey(entry), entry_key(entry))
                    if pick and swap_slot_entry(slot, pick) then cleaned = cleaned + 1 end
                end
            elseif not elive then
                -- (a) empty slot -> fill if we can infer its category. IP key is "*" once
                -- the restriction is patched out; otherwise borrow a sibling slot's IP.
                local catID = infer_slot_category(slot)
                if catID and not SKIP_CATEGORIES[catID] then
                    local ipkey = _G._RAND_IP_PATCHED and "*" or nil
                    if not ipkey then
                        local sk; pcall(function() local os = slot:Get("m_ownerStationComponent"); if os and is_live(os) then sk = entry_id(os) end end)
                        if sk then
                            for _, s2 in ipairs(liveSlots) do
                                if is_live(s2) and s2 ~= slot then
                                    local e2; pcall(function() e2 = s2:Get("m_slotEntry") end)
                                    if e2 and is_live(e2) then
                                        local sk2; pcall(function() local o2 = s2:Get("m_ownerStationComponent"); if o2 and is_live(o2) then sk2 = entry_id(o2) end end)
                                        if sk2 == sk then ipkey = entry_ipkey(e2); break end
                                    end
                                end
                            end
                        end
                    end
                    if ipkey then
                        local pick = pick_same_ip(catID, ipkey, nil)
                        if pick and swap_slot_entry(slot, pick) then filled = filled + 1 end
                    end
                end
            end
        end)
    end
    return filled, cleaned
end

-- v48 AUTO-APPLY — the playable cabinets AND hub slots STREAM by proximity (24
-- cabinets loaded in one spot, 0 in another), so a one-shot pass misses whatever
-- isn't loaded yet. This loop keeps applying cosmetics + filling/cleaning slots as
-- content streams in, doing the HEAVY work only when the loaded cabinet/slot count
-- CHANGES (cheap otherwise). It PAUSES (touches nothing) while a table is being
-- played and resumes at the hub — that pause is what keeps it from crashing on the
-- stale objects a table-load tears down. Bounded to ~5 min so it isn't a permanent
-- VR hitch; /randomize re-triggers it any time.
local lastCab, lastSlots, lastEntryRaw = -1, -1, -1
local autoWarmup = 3         -- ~21s after init so the one-shot scrambles finish first
-- Counts HUB passes only (it returns early when in a table), so this is ~30 min of
-- actual hub time spread across the whole session — enough to cover every table's
-- cabinet as you pass it, incl. BSG / Tomb Raider Manor. /randomize re-arms it.
local autoRun, AUTO_MAX = 0, 220
local function live_cabinet_count()
    local nc = 0
    for _, c in ipairs(FindAllOf("BP_CabinetBase_C") or {}) do
        local ok, v = pcall(function() return c:IsValid() end)
        if ok and v then nc = nc + 1 end
    end
    return nc
end
LoopAsync(8000, function()
    if _G._RAND_GEN ~= MY_GEN then return true end   -- superseded by a reload
    if not initDone then return false end
    if not hub_active() then return false end        -- in a table: pause, resume at hub
    if autoWarmup > 0 then autoWarmup = autoWarmup - 1; return false end
    autoRun = autoRun + 1
    if autoRun > AUTO_MAX then
        Log(TAG .. ": auto-apply window ended — inert (use /randomize to re-run)")
        return true
    end
    -- change detection + streaming guard. build_entry_pool reflects on collectible
    -- entries (GetEntryID/GetClassName/Get) and takes an UNCATCHABLE SIGSEGV on
    -- half-streamed ones. So we ONLY rebuild the pool when the raw entry count has
    -- held steady across two ticks (i.e. streaming has settled). Raw counts are
    -- FindAllOf-#-only — no reflection — so they're safe to read every tick.
    local function raw_n(cls) local a = FindAllOf(cls); return a and #a or 0 end
    local er = raw_n("PFXCollectibleEntry_BallSkin") + raw_n("PFXCollectibleEntry_BallTrail")
             + raw_n("PFXCollectibleEntry_FlipperArm") + raw_n("PFXCollectibleEntry_Gadget")
             + raw_n("PFXCollectibleEntry_Statue") + raw_n("PFXCollectibleEntry_Poster")
    local entriesStable = (er == lastEntryRaw)
    lastEntryRaw = er
    local nc = live_cabinet_count()
    local ns = count_registered_slots()
    if nc == lastCab and ns == lastSlots then return false end   -- nothing new streamed in
    if not entriesStable then return false end                   -- entries mid-stream: wait a tick
    lastCab, lastSlots = nc, ns
    pcall(build_entry_pool)
    -- Randomize slots at stations that just streamed in (incremental: skips ones already
    -- done, so posters/statues/walls/floors get randomized when you reach them — no bulk).
    local newSwaps = 0
    pcall(function() newSwaps = scramble_all_slots(true) end)
    local filled, cleaned = 0, 0
    pcall(function() filled, cleaned = maintenance_pass() end)
    stats.empty_filled = stats.empty_filled + filled
    local queued = 0
    pcall(function() queued = scramble_table_cosmetics() end)
    Log(TAG .. string.format(": auto-apply (cab=%d slots=%d) newSlots=%d filled=%d blacklist=%d cosmetics=%d",
        nc, ns, newSwaps, filled, cleaned, queued))
    return false
end)

-- ============================================================================
-- BRIDGE COMMANDS
-- ============================================================================
pcall(function()
    RegisterCommand("randomize", function()
        V("randomize command fired")
        if not poolReady then pcall(build_entry_pool) end
        pcall(scramble_all_slots)
        pcall(scramble_table_cosmetics)
        pcall(apply_pending_flipper_overrides)
        return TAG .. " v34: sweep #" .. stats.sweeps
            .. " ok=" .. stats.sweep_ok
            .. " empty=" .. stats.empty_filled
            .. " ball=" .. stats.table_ball
            .. " trail=" .. stats.table_trail
            .. " flipper=" .. stats.table_flipper
    end)
end)

pcall(function()
    RegisterCommand("randomize_status", function()
        V("randomize_status command fired")
        local slotCount = count_registered_slots()
        local msg = TAG .. " v34: pool=" .. stats.pool_size
            .. " slots=" .. slotCount
            .. " hook=" .. tostring(hookRegistered)
            .. " polls=" .. pollCount .. "/" .. MAX_POLLS
            .. " done=" .. tostring(initDone)
            .. "\nhook: ok=" .. stats.hook_ok
            .. " skip=" .. stats.hook_skip
            .. " err=" .. stats.hook_err
            .. "\nsweep: ok=" .. stats.sweep_ok
            .. " skip=" .. stats.sweep_skip
            .. " err=" .. stats.sweep_err
            .. " empty=" .. stats.empty_filled
            .. " (#" .. stats.sweeps .. ")"
            .. "\ntable: ball=" .. stats.table_ball
            .. " trail=" .. stats.table_trail
            .. " flipper=" .. stats.table_flipper
            .. " fail=" .. stats.table_fail
            .. "\npools: ballValid=" .. #ballPoolValid
            .. " trailValid=" .. #trailPoolValid
            .. " flipper=" .. #flipperPoolAll .. "\n"
        for catID, items in pairs(entryPool) do
            msg = msg .. "  " .. (CATEGORY_NAMES[catID] or ("Cat" .. catID))
                .. ": " .. #items .. "\n"
        end
        return msg
    end)
end)

pcall(function()
    RegisterCommand("randomize_rebuild", function()
        pcall(build_entry_pool)
        return TAG .. ": Pool rebuilt — " .. stats.pool_size .. " entries"
            .. " ballValid=" .. #ballPoolValid
            .. " trailValid=" .. #trailPoolValid
            .. " flipper=" .. #flipperPoolAll
    end)
end)

pcall(function()
    RegisterCommand("randomize_tables", function()
        local count = scramble_table_cosmetics()
        -- Apply flipper overrides immediately (bridge is called when game is loaded)
        pcall(apply_pending_flipper_overrides)
        return TAG .. ": Re-randomized tables — ball=" .. stats.table_ball
            .. " trail=" .. stats.table_trail
            .. " flipper=" .. stats.table_flipper
            .. " fail=" .. stats.table_fail
    end)
end)

Log(TAG .. ": v46 loaded — hook=" .. tostring(hookRegistered)
    .. " | v46: gate the WHOLE mod on the game's own BP_GameflowStart.OnTablesDataLoaded event"
    .. " (player + tables initialized) before ANY work — never touches half-initialized objects."
    .. " Keeps v45 hub_active/get_S table-entry guard + bounded inert finalize + generation guard,"
    .. " v44 slot-settle gate, cabinet SetupFromCollectibleEntry cosmetics, gadget fill, blacklist")

-- ============================================================================
-- GLOBAL EXPORTS — callable by other mods (e.g. PFX_ModMenu)
-- ============================================================================
local function scramble_by_catid(catID)
    if not poolReady then pcall(build_entry_pool) end
    if not poolReady then return 0 end
    local _, liveSlots = count_registered_slots()
    if not liveSlots or #liveSlots == 0 then return 0 end
    local done = 0
    for _, slot in ipairs(liveSlots) do
        pcall(function()
            if not is_live(slot) then return end
            local entry = nil
            pcall(function() entry = slot:Get("m_slotEntry") end)
            local cid = (entry and is_live(entry)) and get_category_id(entry) or infer_slot_category(slot)
            if cid == catID then
                if scramble_one_slot(slot, "manual") then done = done + 1 end
            end
        end)
    end
    return done
end

PFX_Rand = nil  -- will be set below
_G.PFX_Rand = {
    scramble_all    = scramble_all_slots,
    scramble_tables = scramble_table_cosmetics,
    scramble_cat    = scramble_by_catid,
    -- category IDs
    CAT_POSTER   = 3,
    CAT_STATUE   = 4,
    CAT_GADGET   = 5,
    CAT_FLOOR    = 6,
    CAT_WALL     = 7,
    CAT_HUB      = 14,
}
Log(TAG .. ": PFX_Rand global exported")
