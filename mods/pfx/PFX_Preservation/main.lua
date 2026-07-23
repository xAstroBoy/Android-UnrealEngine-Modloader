-- ============================================================================
-- PFX_Preservation v2 — Table Ownership Bypass + Presence-Aware Downloads
-- ============================================================================
-- PRESERVATION PROJECT: Forces the game to think ALL tables are owned and
-- bypasses entitlement checks. v2 DETECTS what content actually exists on this
-- device (OBB-embedded chunks + loose pakchunk files) instead of assuming the
-- OBB has everything:
--   * content on disk    -> loads straight from disk, downloads stay OFF
--   * content missing    -> the game is allowed to REALLY download it
--     (bShouldAcquireMissingChunksOnLoad flips on, real download states are
--      never disturbed by the state pin, and a finished download is detected
--      by its pak file appearing)
--
-- This mod works by:
-- 1. Setting bDebugUnlockAllTables = true on PFXStoreManager
-- 2. Hooking IsTableOwned/IsBundleOwned to always return true
-- 3. Hooking IsPlayDisabled to always return false
-- 4. Marking all tables IncludedInBaseGame so they load straight from disk
-- 5. Presence-aware download fix (see DOWNLOAD FIX v2 below)
-- ============================================================================
local TAG = "PFX_Preservation"
Log(TAG .. ": Loading v2 — Table Preservation & Presence-Aware Downloads...")

-- Reload generation: older LoopAsync callbacks self-terminate on hot-reload.
_G._PRES_GEN = (_G._PRES_GEN or 0) + 1
local MY_GEN = _G._PRES_GEN

-- ============================================================================
-- HELPERS
-- ============================================================================
local function is_live(obj)
    if not obj then return false end
    local ok, v = pcall(function() return obj:IsValid() end)
    if not ok or not v then return false end
    local ok2, n = pcall(function() return obj:GetName() end)
    return ok2 and n and not n:match("^Default__") and not n:match("^REINST_")
end

-- ============================================================================
-- STATE
-- ============================================================================
local bypass_active     = false   -- ownership bypass hooks installed
local download_active   = false   -- auto-download enabled
local tables_found      = {}      -- discovered table info objects
local chunks_found      = {}      -- discovered pakchunker mappings
local hook_ids          = {}      -- registered hook IDs for cleanup

-- Cached subsystems
local cache = {}

local function get_store_manager()
    if is_live(cache.sm) then return cache.sm end
    pcall(function() cache.sm = FindFirstOf("BP_StoreManager_C") end)
    if not is_live(cache.sm) then
        pcall(function() cache.sm = FindFirstOf("PFXStoreManager") end)
    end
    return cache.sm
end

local function get_package_manager()
    if is_live(cache.pm) then return cache.pm end
    pcall(function() cache.pm = FindFirstOf("BP_PackageManager_C") end)
    if not is_live(cache.pm) then
        pcall(function() cache.pm = FindFirstOf("PFXPackageManager") end)
    end
    return cache.pm
end

local function get_asset_manager()
    if is_live(cache.am) then return cache.am end
    pcall(function() cache.am = FindFirstOf("PFXAssetManager") end)
    if not is_live(cache.am) then
        pcall(function() cache.am = FindFirstOf("YUPAssetManager") end)
    end
    if not is_live(cache.am) then
        pcall(function() cache.am = FindFirstOf("AssetManager") end)
    end
    return cache.am
end

local function get_game_subsystem()
    if is_live(cache.gs) then return cache.gs end
    pcall(function() cache.gs = FindFirstOf("BP_GameSubsystem_C") end)
    if not is_live(cache.gs) then
        pcall(function() cache.gs = FindFirstOf("PFXGameSubsystem") end)
    end
    return cache.gs
end

local function get_table_preload_manager()
    if is_live(cache.tpm) then return cache.tpm end
    pcall(function() cache.tpm = FindFirstOf("BP_PFXTablePreloadManager_C") end)
    if not is_live(cache.tpm) then
        pcall(function() cache.tpm = FindFirstOf("PFXTablePreloadManager") end)
    end
    return cache.tpm
end

local function get_game_instance()
    if is_live(cache.gi) then return cache.gi end
    pcall(function() cache.gi = FindFirstOf("BP_PFXGameInstance_C") end)
    if not is_live(cache.gi) then
        pcall(function() cache.gi = FindFirstOf("PFXGameInstance") end)
    end
    return cache.gi
end

-- ============================================================================
-- 1. DEBUG FLAG — bDebugUnlockAllTables (direct write, no hook needed)
-- ============================================================================
local function set_debug_unlock(val)
    local sm = get_store_manager()
    if not sm then
        Log(TAG .. ": WARN — no StoreManager found, retrying in 5s")
        ExecuteWithDelay(5000, function() set_debug_unlock(val) end)
        return false
    end
    pcall(function() sm:Set("bDebugUnlockAllTables", val) end)
    Log(TAG .. ": bDebugUnlockAllTables = " .. tostring(val))
    return true
end

-- ============================================================================
-- 2. ASSET MANAGER — bShouldAcquireMissingChunksOnLoad
-- ============================================================================
local function set_auto_acquire_chunks(val)
    local am = get_asset_manager()
    if not am then
        Log(TAG .. ": WARN — no AssetManager found")
        return false
    end
    pcall(function() am:Set("bShouldAcquireMissingChunksOnLoad", val) end)
    Log(TAG .. ": bShouldAcquireMissingChunksOnLoad = " .. tostring(val))
    return true
end

-- ============================================================================
-- 3. OWNERSHIP BYPASS — Native hooks (Dobby, intercepts ALL callers)
-- ============================================================================
local function install_ownership_hooks()
    if bypass_active then
        Log(TAG .. ": Hooks already installed")
        return true
    end

    local count = 0

    -- Use RegisterNativeHook for native-level interception (no ProcessEvent needed)
    -- These hooks fire on EVERY call to the function, including from C++ code

    -- IsTableOwned → always return true
    pcall(function()
        local ok = RegisterNativeHook("PFXStoreManager::IsTableOwned", nil,
            function(retval, self, tableInfo)
                Log(TAG .. ": [NATIVE] IsTableOwned → forced true")
                return true  -- override return to true
            end, "pp>p")
        if ok then count = count + 1; Log(TAG .. ": Native hook: IsTableOwned → true") end
    end)

    -- IsBundleOwned → always return true
    pcall(function()
        local ok = RegisterNativeHook("PFXStoreManager::IsBundleOwned", nil,
            function(retval, self, bundleID)
                Log(TAG .. ": [NATIVE] IsBundleOwned → forced true")
                return true
            end, "pp>p")
        if ok then count = count + 1; Log(TAG .. ": Native hook: IsBundleOwned → true") end
    end)

    bypass_active = true
    Log(TAG .. ": Ownership bypass native hooks installed (" .. count .. " hooks)")
    return true
end

-- ============================================================================
-- 4. ENUMERATE ALL TABLES
-- ============================================================================
local function enumerate_tables()
    tables_found = {}

    -- Method 1: Via GameSubsystem → TableInfoHolder
    -- DISABLED: gs:Call("GetTableInfoHolder") crashes via ProcessEvent before sub-objects
    -- are loaded (T<40s), and the siglongjmp crash-recovery corrupts UE5 GC state,
    -- causing fatal recursive SIGSEGV ~10s later. Method 2 is reliable and sufficient.

    -- Method 2: FindAllOf PFXVRTableInfo
    if #tables_found == 0 then
        pcall(function()
            local infos = FindAllOf("PFXVRTableInfo")
            if infos then
                for i, info in ipairs(infos) do
                    if is_live(info) then
                        -- Use GetName() (UObject FName, no ProcessEvent) instead of
                        -- GetTableName() (ProcessEvent, crashes before sub-objects loaded,
                        -- corrupts UE5 GC state via siglongjmp recovery)
                        local name = info:GetName() or "?"
                        local pitId = 0
                        pcall(function() pitId = info:Get("PitID") end)
                        local included = false
                        pcall(function() included = info:Get("IncludedInBaseGame") end)
                        tables_found[#tables_found + 1] = {
                            index = i - 1,
                            name = tostring(name),
                            pitId = pitId,
                            included = included,
                            disabled = false,
                            info = info,
                        }
                    end
                end
            end
        end)
    end

    Log(TAG .. ": Found " .. #tables_found .. " tables")
    return tables_found
end

-- ============================================================================
-- 5. ENUMERATE PAK CHUNK MAPPINGS
-- ============================================================================
local function enumerate_chunks()
    chunks_found = {}

    pcall(function()
        local chunkers = FindAllOf("PFXPakChunkerTable")
        if not chunkers then return end
        for _, c in ipairs(chunkers) do
            if is_live(c) then
                local entry = { name = c:GetName(), chunks = {} }

                -- Read chunk ID map
                pcall(function()
                    local map = c:Get("PrimaryAssetLabelAndChunkIdMap")
                    if map then
                        entry.chunkMap = tostring(map)
                    end
                end)

                -- Read table info ref (use GetName() not GetTableName() to avoid ProcessEvent crash)
                pcall(function()
                    local ti = c:Get("TableInfoCache")
                    if is_live(ti) then
                        entry.tableName = ti:GetName()
                        entry.pitId = ti:Get("PitID")
                    end
                end)

                chunks_found[#chunks_found + 1] = entry
            end
        end
    end)

    Log(TAG .. ": Found " .. #chunks_found .. " PakChunkerTable entries")
    return chunks_found
end

-- ============================================================================
-- 6. CHECK STORE BUNDLES
-- ============================================================================
local function enumerate_bundles()
    local bundles = {}
    local sm = get_store_manager()
    if not sm then return bundles end

    pcall(function()
        local available = sm:Call("GetAvailableBundles", false, {})
        if available then
            Log(TAG .. ": GetAvailableBundles returned: " .. tostring(available))
        end
    end)

    -- Check store data
    pcall(function()
        local sd = sm:Get("StoreData")
        if is_live(sd) then
            Log(TAG .. ": StoreData found: " .. sd:GetName())
            local bdl = sd:Get("Bundles")
            if bdl then
                Log(TAG .. ": Bundles map: " .. tostring(bdl))
            end
        end
    end)

    return bundles
end

-- ============================================================================
-- 7. FORCE MARK ALL TABLES AS INCLUDED IN BASE GAME
-- ============================================================================
local function force_all_tables_included()
    if #tables_found == 0 then enumerate_tables() end

    local count = 0
    for _, t in ipairs(tables_found) do
        if t.info and is_live(t.info) then
            pcall(function()
                t.info:Set("IncludedInBaseGame", true)
                count = count + 1
            end)
            -- Also disable play restriction
            pcall(function()
                t.info:Set("DisablePlayInPressBuild", false)
            end)
        end
    end
    Log(TAG .. ": Forced " .. count .. " tables as IncludedInBaseGame")
    return count
end

-- ============================================================================
-- 8. TRIGGER DOWNLOAD FOR ALL MISSING CHUNKS
-- ============================================================================
local function force_download_all()
    -- Enable auto-acquire first
    set_auto_acquire_chunks(true)

    -- Set debug unlock
    set_debug_unlock(true)

    -- Mark all as base game
    force_all_tables_included()

    -- Try to trigger preload for all tables
    local tpm = get_table_preload_manager()
    if tpm then
        pcall(function()
            -- Set high preload count to force loading all
            tpm:Set("PreLoadedRecentTableCount", 999)
            tpm:Set("PreLoadFavouriteTable", true)
            Log(TAG .. ": PreLoadedRecentTableCount set to 999")
        end)
    end

    -- Try to load each table to trigger chunk downloads
    local gi = get_game_instance()
    local triggered = 0
    for _, t in ipairs(tables_found) do
        if t.info and is_live(t.info) then
            pcall(function()
                -- Check if owned (should always be true now)
                local sm = get_store_manager()
                if sm then
                    local owned = sm:Call("IsTableOwned", t.info)
                    Log(TAG .. ": Table " .. t.name .. " owned=" .. tostring(owned))
                end
                triggered = triggered + 1
            end)
        end
    end

    Log(TAG .. ": Triggered ownership check for " .. triggered .. " tables")
    download_active = true
    return triggered
end

-- ============================================================================
-- 9. FULL ACTIVATION — ONE COMMAND
-- ============================================================================

-- ============================================================================
-- DOWNLOAD FIX v2 (presence-aware) — the table/package manager marks tables
-- Remote(2) ("needs download") when entitlement says "not owned", even when the
-- content IS on disk, so selecting one softlocks on a fetch. v1 blind-flipped
-- EVERY descriptor in Remote..Mounting(2..5) to Mounted(6) — which also yanked
-- GENUINELY-missing tables out of their real download and fake-mounted absent
-- paks: broken table, and the download never happened. v2 knows what content is
-- actually on this device:
--
--   base tables — chunk pak embedded in the OBBs (scan their central dirs)
--   DLC tables  — loose <obb>/pakchunk<2000+PitID>-Android_ASTC.pak
--   (chunkId = 2000 + PitID verified live: all 31 loose paks + all 11 OBB
--    chunks on the dev Quest map 1:1 onto the 42 PitIDs)
--
-- Descriptor identity is unknown (16-byte {descriptor,package} pairs, state
-- byte at desc+73, nothing readable ties a desc to a table), so every rule
-- must be safe while blind:
--   * only Remote(2) descs are ever flipped — NEVER Downloading/Downloaded/
--     Mounting(3/4/5): a real download in progress is never disturbed
--   * nothing missing on disk  -> flip Remote immediately (v1 softlock fix)
--   * something missing        -> bShouldAcquireMissingChunksOnLoad=true so
--     the game ACTUALLY downloads it; a Remote desc is only flipped once it
--     has sat still for DLPIN_STUCK_TICKS with no download running anywhere —
--     a genuinely-missing table leaves Remote by itself once acquisition
--     starts, a bogus-Remote never does, so flipping only the stuck ones
--     rescues the softlock without eating anyone's download
--   * a finished download appears as the loose pak -> presence cache refresh,
--     acquire drops back to false when nothing is missing anymore
--
-- Offsets from IDA of libUnreal.so (RVAs relative to YUP.GetLibBase()):
--   0x76AE910 = table/package manager global (NULL until a load is in flight)
--   mgr+96  = descriptor array (16-byte {descriptor, package} pairs)
--   mgr+104 = descriptor count
--   desc+73 = EPFXPackageState byte (Invalid=0 Validating=1 Remote=2
--             Downloading=3 Downloaded=4 Mounting=5 Mounted=6 Attached=7)
-- ============================================================================
local MGR_RVA    = 0x76AE910
local DESC_ARR   = 96
local DESC_CNT   = 104
local STATE_OFF  = 73
local dlpin_on   = false
_G._DLPIN_TOTAL  = 0

local OBB_DIR = "/sdcard/Android/obb/com.zenstudios.PFXVRQuest/"
local DLPIN_STUCK_TICKS = 3      -- 2s loop -> ~6s grace before flipping a stuck Remote
local base_chunks = nil          -- set: chunkId -> true (embedded in the OBBs)
local presence    = {}           -- pit -> true/false (cached content-on-disk)
local remote_seen = {}           -- desc addr -> consecutive ticks seen in Remote

local function scan_obb_chunks()
    if base_chunks then return base_chunks end
    base_chunks = {}
    local names = { "main.com.zenstudios.PFXVRQuest.obb" }
    for i = 1, 9 do names[#names + 1] = "overflow" .. i .. ".com.zenstudios.PFXVRQuest.obb" end
    for _, n in ipairs(names) do
        local f = io.open(OBB_DIR .. n, "rb")
        if f then
            local sz = f:seek("end")
            local rd = math.min(sz, 3 * 1024 * 1024)
            f:seek("end", -rd)
            local tail = f:read(rd) or ""
            f:close()
            for id in tail:gmatch("pakchunk(%d+)%-Android_ASTC") do
                base_chunks[tonumber(id)] = true
            end
        end
    end
    local cnt = 0; for _ in pairs(base_chunks) do cnt = cnt + 1 end
    Log(TAG .. ": OBB scan — " .. cnt .. " embedded chunk(s)")
    return base_chunks
end

local function pak_on_disk(pit)
    local f = io.open(OBB_DIR .. "pakchunk" .. (2000 + pit) .. "-Android_ASTC.pak", "rb")
    if f then f:close(); return true end
    return false
end

-- pit -> is this table's content actually on the device?
local function content_present(pit, refresh)
    if not refresh and presence[pit] ~= nil then return presence[pit] end
    local ok = scan_obb_chunks()[2000 + pit] == true or pak_on_disk(pit)
    presence[pit] = ok
    return ok
end

local function missing_tables(refresh)
    if #tables_found == 0 then enumerate_tables() end
    local miss = {}
    for _, t in ipairs(tables_found) do
        local pit = tonumber(t.pitId) or -1
        if pit >= 0 and not content_present(pit, refresh) then miss[#miss + 1] = t end
    end
    return miss
end

-- acquire follows reality: content missing -> let the game download it;
-- everything present -> downloads off (never re-fetch what the OBB has)
local function sync_acquire()
    local miss = missing_tables(true)
    set_auto_acquire_chunks(#miss > 0)
    if #miss > 0 then
        Log(TAG .. ": " .. #miss .. " table(s) missing content — real downloads ENABLED")
    end
    return miss
end

local function pin_download_states()
    local base = YUP.GetLibBase(); if not base or base == 0 then return 0 end
    local mgr = MemReadU64(base + MGR_RVA)
    if not (mgr and mgr > 0x1000 and mgr < 0x8000000000) then return 0 end
    local n = MemReadU64(mgr + DESC_CNT) & 0xFFFFFFFF
    local a = MemReadU64(mgr + DESC_ARR)
    -- validate: bogus count/ptr (wrong build/offset) -> safe no-op, never corrupt
    if not (a and a > 0x1000 and a < 0x8000000000 and n > 0 and n < 256) then return 0 end

    -- pass 1: collect states; any desc in 3/4/5 = a real download/mount running
    local descs, states, downloading = {}, {}, false
    for i = 0, n - 1 do
        local desc = MemReadU64(a + i * 16)
        if desc and desc > 0x1000 and desc < 0x8000000000 then
            local st = MemReadU64(desc + STATE_OFF) & 0xFF
            descs[#descs + 1] = desc
            states[desc] = st
            if st >= 3 and st <= 5 then downloading = true end
        end
    end

    local have_missing = #missing_tables(false) > 0
    local flipped = 0
    local seen_now = {}
    for _, desc in ipairs(descs) do
        if states[desc] == 2 then                               -- Remote only
            local ticks = (remote_seen[desc] or 0) + 1
            seen_now[desc] = ticks
            -- flip immediately when nothing is missing; while content is
            -- missing, flip only a STUCK Remote with no download running
            -- (the game would have moved a downloadable desc to 3 by now)
            if (not have_missing) or (ticks >= DLPIN_STUCK_TICKS and not downloading) then
                local w = MemReadU64(desc + STATE_OFF)
                MemWriteU64(desc + STATE_OFF, (w & ~0xFF) | 6)  -- -> Mounted
                flipped = flipped + 1
                seen_now[desc] = nil
            end
        end
    end
    remote_seen = seen_now
    _G._DLPIN_TOTAL = _G._DLPIN_TOTAL + flipped
    return flipped
end

local function install_download_pin()
    if dlpin_on then return end
    dlpin_on = true
    pcall(pin_download_states)                    -- immediate first pass
    local tick = 0
    LoopAsync(2000, function()                    -- slow + cheap: states don't revert
        if _G._PRES_GEN ~= MY_GEN then return true end
        tick = tick + 1
        pcall(pin_download_states)
        -- ~10s: re-check the disk so a finished download flips its table to
        -- "present", drops acquire back off, and tells the player
        if tick % 5 == 0 then
            pcall(function()
                local before = #missing_tables(false)
                if before > 0 then
                    local after = #sync_acquire()
                    if after < before then
                        Notify(TAG, "Table content downloaded (" .. (before - after) .. ")")
                    end
                end
            end)
        end
        return false
    end)
    Log(TAG .. ": download fix v2 active (presence-aware; real downloads untouched)")
end

pcall(function() RegisterCommand("pres_dl_status", function()
    local base = YUP.GetLibBase(); local mgr = base and MemReadU64(base + MGR_RVA) or 0
    local n = (mgr and mgr > 0x1000) and (MemReadU64(mgr + DESC_CNT) & 0xFFFFFFFF) or 0
    local miss = missing_tables(true)
    local names = {}
    for _, t in ipairs(miss) do names[#names + 1] = t.name .. "(pit " .. tostring(t.pitId) .. ")" end
    return TAG .. ": flipped=" .. tostring(_G._DLPIN_TOTAL) .. " descriptors=" .. tostring(n)
        .. " missing=" .. #miss .. (#miss > 0 and (" [" .. table.concat(names, ", ") .. "]") or "")
end) end)

pcall(function() RegisterCommand("pres_dl_missing", function()
    local miss = missing_tables(true)
    if #miss == 0 then return TAG .. ": all table content present on disk" end
    local lines = { TAG .. ": " .. #miss .. " table(s) missing content:" }
    for _, t in ipairs(miss) do
        lines[#lines + 1] = string.format("  [%d] pit=%s chunk=%s %s",
            t.index, tostring(t.pitId), tostring(2000 + (tonumber(t.pitId) or 0)), t.name)
    end
    lines[#lines + 1] = "select one in-game to download it (acquire auto-enables)"
    return table.concat(lines, "\n")
end) end)

pcall(function() RegisterCommand("pres_fetch", function(idx)
    idx = tonumber(idx) or 0
    if idx < 0 or idx >= #tables_found then return TAG .. ": invalid index" end
    local t = tables_found[idx + 1]
    local pit = tonumber(t.pitId) or -1
    if content_present(pit, true) then return TAG .. ": " .. t.name .. " content already on disk" end
    set_auto_acquire_chunks(true)
    local ok = pcall(function()
        local lib = StaticFindObject("/Script/PinballFX_VR.PFXUIFunctionLibrary")
        if lib then lib:Call("RequestTable", pit) end
    end)
    return TAG .. ": acquire ON + RequestTable(" .. pit .. ") sent (ok=" .. tostring(ok)
        .. ") — select the table in-game if nothing starts"
end) end)

local function activate_preservation()
    Log(TAG .. ": === ACTIVATING PRESERVATION MODE (unlock + presence-aware downloads) ===")

    -- Step 1: Debug unlock flag
    set_debug_unlock(true)

    -- Step 2: Install ownership hooks
    install_ownership_hooks()

    -- Step 2b: native download fix v2 (presence-aware Remote->Mounted)
    install_download_pin()

    -- Step 3: Enumerate tables
    enumerate_tables()

    -- Step 4: Force all tables as base game (load straight from the OBB)
    force_all_tables_included()

    -- Step 5: Enumerate chunks
    enumerate_chunks()

    -- Step 6: acquire follows the disk — content missing somewhere means the
    -- game is ALLOWED to really download; all present means downloads stay off
    local miss = sync_acquire()

    Log(TAG .. ": === PRESERVATION MODE ACTIVE ===")
    Log(TAG .. ":   " .. #tables_found .. " tables found (" .. #miss .. " missing content on disk)")
    Log(TAG .. ":   " .. #chunks_found .. " chunk mappings found")
    Log(TAG .. ":   bDebugUnlockAllTables = true")
    Log(TAG .. ":   bShouldAcquireMissingChunksOnLoad = " .. tostring(#miss > 0)
        .. (#miss > 0 and " (missing tables WILL download for real)" or " (everything on disk, no downloads)"))
    Log(TAG .. ":   All tables marked IncludedInBaseGame")
    Log(TAG .. ":   Ownership hooks active")

    return true
end

-- ============================================================================
-- BRIDGE COMMANDS
-- ============================================================================

-- Main activation
pcall(function() RegisterCommand("pres_activate", function()
    activate_preservation()
    return TAG .. ": FULL PRESERVATION MODE ACTIVE — " .. #tables_found .. " tables, " .. #chunks_found .. " chunks"
end) end)

-- Individual controls
pcall(function() RegisterCommand("pres_unlock", function()
    set_debug_unlock(true)
    return TAG .. ": bDebugUnlockAllTables = true"
end) end)

pcall(function() RegisterCommand("pres_lock", function()
    set_debug_unlock(false)
    return TAG .. ": bDebugUnlockAllTables = false"
end) end)

pcall(function() RegisterCommand("pres_chunks_on", function()
    set_auto_acquire_chunks(true)
    return TAG .. ": bShouldAcquireMissingChunksOnLoad = true"
end) end)

pcall(function() RegisterCommand("pres_hooks", function()
    install_ownership_hooks()
    return TAG .. ": Ownership hooks installed"
end) end)

-- Enumeration
pcall(function() RegisterCommand("pres_tables", function()
    enumerate_tables()
    local lines = { TAG .. ": " .. #tables_found .. " tables:" }
    for _, t in ipairs(tables_found) do
        local flags = ""
        if t.included then flags = flags .. " [BASE]" end
        if t.disabled then flags = flags .. " [DISABLED]" end
        lines[#lines + 1] = string.format("  [%d] PIT=%d %s%s", t.index, t.pitId, t.name, flags)
    end
    return table.concat(lines, "\n")
end) end)

pcall(function() RegisterCommand("pres_chunks", function()
    enumerate_chunks()
    local lines = { TAG .. ": " .. #chunks_found .. " chunk mappings:" }
    for _, c in ipairs(chunks_found) do
        local tbl = c.tableName or "?"
        lines[#lines + 1] = string.format("  %s → %s (PIT=%s)", c.name, tbl, tostring(c.pitId or "?"))
    end
    return table.concat(lines, "\n")
end) end)

pcall(function() RegisterCommand("pres_bundles", function()
    enumerate_bundles()
    return TAG .. ": Bundle enumeration complete (check log)"
end) end)

pcall(function() RegisterCommand("pres_force_base", function()
    local count = force_all_tables_included()
    return TAG .. ": Forced " .. count .. " tables as IncludedInBaseGame"
end) end)

pcall(function() RegisterCommand("pres_download_all", function()
    local count = force_download_all()
    return TAG .. ": Download triggered for " .. count .. " tables"
end) end)

-- Status
pcall(function() RegisterCommand("pres_status", function()
    local parts = {}
    parts[#parts + 1] = "bypass=" .. tostring(bypass_active)
    parts[#parts + 1] = "download=" .. tostring(download_active)
    parts[#parts + 1] = "tables=" .. #tables_found
    parts[#parts + 1] = "chunks=" .. #chunks_found

    local sm = get_store_manager()
    if sm then
        local dbg = false
        pcall(function() dbg = sm:Get("bDebugUnlockAllTables") end)
        parts[#parts + 1] = "debugUnlock=" .. tostring(dbg)
    end

    local am = get_asset_manager()
    if am then
        local acq = false
        pcall(function() acq = am:Get("bShouldAcquireMissingChunksOnLoad") end)
        parts[#parts + 1] = "autoAcquire=" .. tostring(acq)
    end

    return TAG .. ": " .. table.concat(parts, " | ")
end) end)

-- Check individual table ownership
pcall(function() RegisterCommand("pres_check_owned", function(idx)
    idx = tonumber(idx) or 0
    if idx < 0 or idx >= #tables_found then return TAG .. ": invalid index" end
    local t = tables_found[idx + 1]
    if not t or not t.info then return TAG .. ": no table at index " .. idx end

    local sm = get_store_manager()
    if not sm then return TAG .. ": no StoreManager" end

    local owned = false
    pcall(function() owned = sm:Call("IsTableOwned", t.info) end)

    local included = false
    pcall(function() included = t.info:Get("IncludedInBaseGame") end)

    local disabled = false
    pcall(function() disabled = t.info:Call("IsPlayDisabled") end)

    return string.format("%s: [%d] %s — owned=%s included=%s disabled=%s",
        TAG, idx, t.name, tostring(owned), tostring(included), tostring(disabled))
end) end)

-- Dump full table info for one table
pcall(function() RegisterCommand("pres_table_info", function(idx)
    idx = tonumber(idx) or 0
    if idx < 0 or idx >= #tables_found then return TAG .. ": invalid index" end
    local t = tables_found[idx + 1]
    if not t or not t.info then return TAG .. ": no table at index " .. idx end

    local info = t.info
    local lines = { string.format("%s: Table [%d] %s", TAG, idx, t.name) }

    local props = {"PitID", "AssetName", "AppVersion", "Version", "GFXVersion",
                   "IncludedInBaseGame", "DisablePlayInPressBuild", "NudgeStrength",
                   "TiltSensitivity", "TrialScoreLimit", "TrialTimeLimit", "ProModeAvailable",
                   "DataVersion", "ForceNewPhysics"}
    for _, p in ipairs(props) do
        local val = "?"
        pcall(function() val = tostring(info:Get(p)) end)
        lines[#lines + 1] = "  " .. p .. " = " .. val
    end
    return table.concat(lines, "\n")
end) end)

-- Force specific table as owned
pcall(function() RegisterCommand("pres_own_table", function(idx)
    idx = tonumber(idx) or 0
    if idx < 0 or idx >= #tables_found then return TAG .. ": invalid index" end
    local t = tables_found[idx + 1]
    if not t or not t.info then return TAG .. ": no table at index " .. idx end
    pcall(function() t.info:Set("IncludedInBaseGame", true) end)
    pcall(function() t.info:Set("DisablePlayInPressBuild", false) end)
    return TAG .. ": Forced table [" .. idx .. "] " .. t.name .. " as owned"
end) end)

-- ============================================================================
-- GLOBAL API
-- ============================================================================
_G.PFX_Preservation = {
    activate              = activate_preservation,
    set_debug_unlock      = set_debug_unlock,
    set_auto_acquire      = set_auto_acquire_chunks,
    install_hooks         = install_ownership_hooks,
    enumerate_tables      = enumerate_tables,
    enumerate_chunks      = enumerate_chunks,
    force_all_included    = force_all_tables_included,
    force_download_all    = force_download_all,
    get_tables            = function() return tables_found end,
    get_chunks            = function() return chunks_found end,
    is_active             = function() return bypass_active end,
    content_present       = content_present,
    missing_tables        = missing_tables,
    sync_acquire          = sync_acquire,
}

-- ============================================================================
-- AUTO-ACTIVATION
-- ============================================================================
-- Delay to let subsystems initialize
pcall(function()
    ExecuteWithDelay(3000, function()
        Log(TAG .. ": Auto-activating preservation mode...")
        activate_preservation()
    end)
end)

Log(TAG .. ": v2 loaded — preservation, ownership bypass, presence-aware downloads")
Log(TAG .. ": Bridge commands:")
Log(TAG .. ":   pres_activate     — Full activation (all steps)")
Log(TAG .. ":   pres_unlock       — Set bDebugUnlockAllTables")
Log(TAG .. ":   pres_hooks        — Install ownership hooks")
Log(TAG .. ":   pres_tables       — Enumerate all tables")
Log(TAG .. ":   pres_chunks       — Enumerate pak chunk mappings")
Log(TAG .. ":   pres_force_base   — Force all tables as IncludedInBaseGame")
Log(TAG .. ":   pres_download_all — Force download all missing chunks")
Log(TAG .. ":   pres_dl_missing   — List tables whose content is NOT on disk")
Log(TAG .. ":   pres_dl_status    — Download-fix stats + missing summary")
Log(TAG .. ":   pres_fetch <idx>  — Enable acquire + request one missing table")
Log(TAG .. ":   pres_status       — Show current state")
Log(TAG .. ":   pres_check_owned <idx> — Check ownership for table")
Log(TAG .. ":   pres_table_info <idx>  — Dump table properties")
Log(TAG .. ":   pres_own_table <idx>   — Force single table owned")

-- Auto-activate after game is ready (retries every 10s via LoopAsync)
local pres_auto_activated = false
ExecuteWithDelay(10000, function()
    if pres_auto_activated then return end
    Log(TAG .. ": AUTO: attempting preservation activation...")
    local ok = pcall(activate_preservation)
    if ok and #tables_found > 0 then
        pres_auto_activated = true
        Log(TAG .. ": AUTO: preservation activated")
        Notify(TAG, "Tables unlocked — " .. #tables_found .. " found")
    else
        Log(TAG .. ": AUTO: activation deferred (game not ready, retrying in 10s)")
        ExecuteWithDelay(10000, function()
            if not pres_auto_activated then
                pcall(activate_preservation)
                if #tables_found > 0 then pres_auto_activated = true end
            end
        end)
    end
end)
