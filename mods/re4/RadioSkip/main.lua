-- mods/RadioSkip/main.lua v6.3
-- ═══════════════════════════════════════════════════════════════════════
-- Radio Auto-Skip — when a VR4Communicator spawns, immediately call
-- Open() then Abort() so it closes itself without player interaction.
-- No blocking — lets the game flow naturally, just auto-dismisses.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "RadioSkip"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = {
    enabled = true,
}

local saved = ModConfig.Load("RadioSkip")
if saved then
    if saved.enabled ~= nil then state.enabled = saved.enabled end
end

-- ═══════════════════════════════════════════════════════════════════════
-- SKIP RADIO — completion-safe (no softlock)
-- ═══════════════════════════════════════════════════════════════════════
-- The radio opener OpeSetOpenTerm() spawns AVR4Communicator, calls SetData
-- (the ring), and then BLOCKS in a wait-loop until the call's audio finishes;
-- only then does the calling scenario continue. So we must NOT just delete the
-- opener (`ret`) — that would skip the audio-finished completion the scenario
-- waits on and can softlock. Instead we let each call complete the game's own
-- way, instantly:
--   1. Set the game's REAL skip flag. v6.x wrote 0x0A5AA430 which does nothing —
--      OpeSetOpenTerm actually reads *(*(0x0A5AA440) + threadIdx). Setting that
--      is the DEV-shipped skip path (designed to be safe).
--   2. For any communicator that still spawns, immediately call the game's own
--      Abort() + Cleanup() (the "end this call properly" methods that fire the
--      completion delegates), so the dialogue is MARKED COMPLETED and the
--      scenario proceeds — no ring, no softlock.

local sym_OpeSetOpenTerm = Resolve("_Z14OpeSetOpenTerm8OpeMdtNojffffb", 0x061B4754)

-- Set the game's own per-thread communicator-skip flag (correct pointer).
local function setGameSkipFlag()
    local base = GetLibBase()
    if not base then return false end
    local ok = false
    pcall(function()
        local p = ReadPtr(Offset(base, 0x0A5AA440))
        if p and not IsNull(p) then
            WriteU8(p, 1); WriteU8(Offset(p, 1), 1)
            V("game skip flag set @ " .. ToHex(p))
            ok = true
        end
    end)
    return ok
end

-- Keep the flag set until the pointer is live (it persists once set).
local flagSet = false
for _, d in ipairs({0, 500, 1500, 4000, 8000}) do
    ExecuteWithDelay(d, function()
        if state.enabled and not flagSet then flagSet = setGameSkipFlag() end
    end)
end

-- Native post-hook on the communicator's Open(): the moment a call opens, end
-- it the game's own way so its completion fires (Abort + Cleanup). This runs
-- BEFORE the player could interact, so there's effectively no ring to answer.
local sym_Abort   = Resolve("VR4Communicator_Abort",   0x0627EB6C)
local sym_Cleanup = Resolve("VR4Communicator_Cleanup", 0x0627DEE4)

-- ═══════════════════════════════════════════════════════════════════════
-- UE4SS SPAWN TRACKING — Auto Open() → Abort() on every new instance
-- ═══════════════════════════════════════════════════════════════════════

local commCount = 0

-- De-dupe: each communicator must be completed AT MOST ONCE. Calling the
-- completion path twice on the same instance re-enters the game's teardown and
-- crashes — see the Cleanup() note below.
local handled = {}
local function commKey(o)
    local ok, s = pcall(function() return tostring(o) end)
    return ok and s or nil
end

-- Complete a communicator the game's own way, exactly once.
--   Open()  — start the call (so Abort has something to end)
--   Abort() — end it, firing the completion delegates → dialogue MARKED DONE
-- We deliberately DO NOT call Cleanup(). AVR4Communicator::Cleanup() is NOT
-- idempotent: it frees its entry buffer (this+0x750) and nulls the pointer but
-- leaves the element count (this+0x758) non-zero, so a SECOND call — ours plus
-- the game's own destroy-time Cleanup() — runs the entry loop over a NULL buffer
-- and dereferences 0x8 → SIGSEGV (AVR4Communicator::Cleanup+108). Let the game
-- destroy + clean up the communicator itself, once. (Before the game-thread
-- queue was fixed these callbacks never actually ran, which is why this latent
-- double-free only started crashing now.)
local function completeOnce(o)
    if not o or not o:IsValid() then return end
    local k = commKey(o)
    if k then
        if handled[k] then return end
        handled[k] = true
    end
    pcall(function() o:Open() end)
    pcall(function() o:Abort() end)
end

NotifyOnNewObject("VR4Communicator", function(obj)
    V("NotifyOnNewObject VR4Communicator fired, obj=%s", tostring(obj))
    if not state.enabled then return end
    if not obj or not obj:IsValid() then return end
    commCount = commCount + 1
    Log(TAG .. ": VR4Communicator spawned #" .. commCount .. " — instant complete (Abort, no Cleanup)")
    completeOnce(obj)
end)
Log(TAG .. ": NotifyOnNewObject — VR4Communicator (auto Open→Abort, once)")

-- ═══════════════════════════════════════════════════════════════════════
-- UE4SS HOOK — Fallback: if Open() is called on an existing instance
-- that NotifyOnNewObject missed, auto-abort it here too
-- ═══════════════════════════════════════════════════════════════════════

RegisterHook("/Script/Game.VR4Communicator:Open", function(Context, Parms)
    V("VR4Communicator:Open hook fired")
    if not state.enabled then return end
    local self = Context:get()
    if not self or not self:IsValid() then return end
    -- completeOnce() de-dupes with the spawn path and never calls Cleanup().
    Log(TAG .. ": VR4Communicator:Open fired — auto Abort (once, no Cleanup)")
    completeOnce(self)
end)
Log(TAG .. ": RegisterHook — VR4Communicator:Open (auto Abort fallback, once)")

-- NOTE: the previous v6.x native RegisterNativeHook on VR4Communicator_Open that
-- also called Abort()+Cleanup() has been REMOVED. It was a third redundant path
-- that (a) double-called the non-idempotent Cleanup() → the +0x8 SIGSEGV, and
-- (b) fired a Lua callback from a native hook, which is crash-prone. The skip
-- flag + the two dedup'd completeOnce() paths above are sufficient.

-- ═══════════════════════════════════════════════════════════════════════
-- CLEANUP IDEMPOTENCY GUARD — the definitive fix for the double-free SIGSEGV
-- ═══════════════════════════════════════════════════════════════════════
-- Not calling Cleanup() ourselves is necessary but NOT sufficient. Completing
-- each call early (Open→Abort) makes the game tear the communicator down via a
-- latent DestroyActor, and AActor::Destroyed() calls Cleanup(). Abort()'s own
-- path can already have freed the entry array (this+0x750 → null) while leaving
-- the element count (this+0x758) non-zero, so that Cleanup() walks a NULL array
-- and dereferences null+0x8 → SIGSEGV at AVR4Communicator::Cleanup+108. It fired
-- ~13.5k times, and each SIGSEGV made Android dump a full register trace — that
-- crash-dump firehose was the frame-rate "lag".
--
-- This guard makes Cleanup() idempotent: a C++-side pre-hook that, if the array
-- is already null but the count is stale, zeroes the count so the entry loop
-- skips instead of dereferencing null. Cold hook (only on communicator teardown),
-- verified 0 crashes. Always on — it's a defensive fix for a game bug that our
-- early-abort exposes, so it must protect even mid-toggle.
do
    local ARR_OFF, COUNT_OFF = 0x750, 0x758
    local guardOK = RegisterNativeHook("_ZN16AVR4Communicator7CleanupEv", function(this)
        if IsNull(this) then return end
        if IsNull(ReadPtr(Offset(this, ARR_OFF))) and ReadU32(Offset(this, COUNT_OFF)) ~= 0 then
            WriteU32(Offset(this, COUNT_OFF), 0)   -- array freed, count stale -> loop would null-deref; zero it
        end
    end, nil, "p")
    Log(TAG .. ": Cleanup idempotency guard installed=" .. tostring(guardOK)
        .. " (kills the double-free SIGSEGV storm = the lag)")
end

-- ═══════════════════════════════════════════════════════════════════════
-- COMMANDS
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("radioskip", function()
    V("radioskip command — toggling from %s", tostring(state.enabled))
    state.enabled = not state.enabled
    if state.enabled then setGameSkipFlag() end
    ModConfig.Save("RadioSkip", state)
    Log(TAG .. ": " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "Radio skip ON" or "Radio skip OFF")
end)

RegisterCommand("radioskip_status", function()
    local info = TAG .. ": enabled=" .. tostring(state.enabled)
        .. " commDismissed=" .. commCount
    local comms = FindAllOf("VR4Communicator")
    if comms then
        info = info .. " | Alive: " .. #comms
    else
        info = info .. " | Alive: 0"
    end
    Log(info)
end)

if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("RadioSkip", "Radio Skip (entirely)",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then setGameSkipFlag() end
            ModConfig.Save("RadioSkip", state)
        end)
end

Log(TAG .. ": v9.0 loaded — game skip flag (0xA5AA440 ptr)"
    .. " + instant Open→Abort ONCE per comm + Cleanup idempotency guard"
    .. " (the double-free SIGSEGV fix, integrated here since our early-abort"
    .. " exposes it — was the CommunicatorFix mod)"
    .. " | opeSym=" .. tostring(sym_OpeSetOpenTerm ~= nil))
Notify(TAG, "Radio skip active")
