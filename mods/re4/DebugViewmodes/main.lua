-- mods/DebugViewmodes/main.lua v1.4
-- ═══════════════════════════════════════════════════════════════════════
-- Debug Viewmodes — enables debug viewmodes via ARM64 byte-patch.
-- GameInstance config moved to Patches mod.
--
-- v1.4 CRASH FIX: AllowDebugViewmodes() is called EVERY FRAME on the render
--   thread by FSceneView::EndFinalPostprocessSettings. The old Lua-callback
--   native hook therefore ran the Lua interpreter on the render thread, which
--   corrupts the game-thread lua_State (crash seen while dumping blueprints:
--   SIGSEGV in luaV_execute). Replaced with a byte-patch — no Lua on the
--   render thread. See the AllowDebugViewmodes section below.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "DebugViewmodes"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = { enabled = true }

local saved = ModConfig.Load("DebugViewmodes")
if saved then
    if saved.enabled ~= nil then state.enabled = saved.enabled end
end

-- ═══════════════════════════════════════════════════════════════════════
-- AllowDebugViewmodes — ARM64 BYTE PATCH (was: crashing Lua-callback hooks)
-- ═══════════════════════════════════════════════════════════════════════
-- CRASH FIX (v1.4). v1.2/v1.3 used RegisterNativeHook with a LUA CALLBACK on
-- AllowDebugViewmodes(). Verified from a live tombstone + IDA:
--   FSceneView::EndFinalPostprocessSettings() calls AllowDebugViewmodes()
--   EVERY FRAME on the render path (it returns a per-thread CVar:
--   `return *(qword_A7D6F18 + 4*(gettid()!=GGameThreadId)) == 1`).
-- So the Lua callback ran luaV_execute on the RENDER thread. When another
-- thread ran Lua too (e.g. a bridge blueprint dump), both hit the shared
-- lua_State and corrupted it → SIGSEGV in luaV_execute (fault addr was an
-- ASCII string read as a pointer). This is the "never Lua-hook a hot fn" trap.
--
-- Fix: patch the function bodies to `mov w0,#1 ; ret` (return true
-- unconditionally). No hook, no per-frame Lua, no cross-thread race — the same
-- mechanism Rapidfire uses. Both overloads (no-arg + EShaderPlatform) read the
-- same CVar and ignore their args, so the identical patch works for both.

local ARM64_MOV_W0_1 = 0x52800020   -- mov w0, #1
local ARM64_RET      = 0xD65F03C0   -- ret

local patched = {}   -- { {addr, o0, o4, name}, ... } for toggle-restore

local function patchReturnTrue(mangled, fallback, friendly)
    local addr
    pcall(function() addr = Resolve(mangled, fallback) end)
    if not addr or IsNull(addr) then
        Log(TAG .. ": [WARN] " .. friendly .. " not resolved — skipped")
        return
    end
    local o0, o4
    pcall(function() o0 = ReadU32(addr); o4 = ReadU32(Offset(addr, 4)) end)
    local ok = pcall(function()
        WriteU32(addr, ARM64_MOV_W0_1)
        WriteU32(Offset(addr, 4), ARM64_RET)
    end)
    if ok then
        patched[#patched + 1] = { addr = addr, o0 = o0, o4 = o4, name = friendly }
        Log(TAG .. ": PATCHED " .. friendly .. " -> return true @ " .. ToHex(addr))
    else
        Log(TAG .. ": [WARN] patch write failed for " .. friendly)
    end
end

local function applyPatches()
    -- _Z19AllowDebugViewmodesv @ 0x06FFB258 is the one EndFinalPostprocessSettings
    -- calls every frame (the crash site). Patch both overloads.
    patchReturnTrue("_Z19AllowDebugViewmodesv",              0x06FFB258, "AllowDebugViewmodes()")
    patchReturnTrue("_Z19AllowDebugViewmodes15EShaderPlatform", 0x06FFB2B4, "AllowDebugViewmodes(EShaderPlatform)")
end

local function restorePatches()
    for _, p in ipairs(patched) do
        if p.o0 and p.o4 then
            pcall(function()
                WriteU32(p.addr, p.o0)
                WriteU32(Offset(p.addr, 4), p.o4)
            end)
        end
    end
    patched = {}
end

if state.enabled then applyPatches() end
Log(TAG .. ": AllowDebugViewmodes byte-patch (no Lua on render thread)")

-- ═══════════════════════════════════════════════════════════════════════
-- CVAR DEBUG FLAGS — REMOVED (v1.3)
-- ═══════════════════════════════════════════════════════════════════════
-- v1.2 wrote WriteU32(base+0x0ABD6F18, 1) + the next word. Verified against
-- libUE4.so: that address is in .bss immediately next to FSandboxFileModule's
-- AutoDestroySingleton pointer — it is NOT a debug CVar. Writing there poked an
-- unrelated global (potential file-I/O corruption). The AllowDebugViewmodes
-- native hooks above are the real mechanism and resolve correctly, so the blind
-- write was removed.

-- GameInstance setup has been moved to Patches mod

-- ═══════════════════════════════════════════════════════════════════════
-- COMMAND
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("debugview", function()
    V("debugview command — toggling from %s", tostring(state.enabled))
    state.enabled = not state.enabled
    ModConfig.Save("DebugViewmodes", state)
    if state.enabled then applyPatches() else restorePatches() end
    Log(TAG .. ": " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "ON" or "OFF")
end)

-- ═══════════════════════════════════════════════════════════════════════
-- DEBUG MENU
-- ═══════════════════════════════════════════════════════════════════════

if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("DebugViewmodes", "Debug Viewmodes",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then applyPatches() else restorePatches() end
            ModConfig.Save("DebugViewmodes", state)
        end)
end

Log(TAG .. ": v1.4 loaded — AllowDebugViewmodes BYTE-PATCH (fixes render-thread luaV_execute crash during blueprint dumps)")
