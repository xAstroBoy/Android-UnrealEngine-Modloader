-- mods/NoFlashBlind/main.lua v1.0
-- ═══════════════════════════════════════════════════════════════════════
-- NO FLASH BLIND — removes the full-screen white-out ("flashbang") the
-- player gets when Krauser (EM39) throws his flash grenade.
-- Enemy stun from the PLAYER's own flash grenades is untouched.
--
-- CONFIRMED MECHANISM (libUE4.so, verified byte-exact, 4 independent passes)
--   Krauser sets a global   Em39_Flash_Flag @0xA5503D4 = 1  (+ Em39_Flash_Count
--   = 50 frames) from his two throw routines (0x5E884FC, 0x5E91938), right
--   after cEmWep::setFlashThrow @0x5EDFEF4, then vanishes and repositions.
--   The flag is read by exactly ONE render-side site: EspCommonTrans(cEsp*)
--   @0x5F14E7C. When flag!=0 AND esp EST-id==0x2F AND subtype==6 AND it is
--   the effect's first frame, it OVERRIDES the sprite's authored values:
--       +0xA0 = 0xFFFFFFFF        (opaque white)
--       +0xA4 = {255,255,255,255} (255x colour scale — overbright)
--       +0x8C = {800.0, 800.0}    (scale, on a 448x480 screen-space quad)
--   i.e. Krauser's ordinary flash sprite is one-shot inflated into a
--   screen-filling, 255x-overbright white billboard. THAT is the blind.
--   Nothing gates input, camera or audio on it — the player was only ever
--   blinded visually, never disabled.
--
-- THE CUT — one 4-byte poke, no hook:
--   0x5F14EEC   49 02 00 34   cbz w9, #0x5F14F34     (flag==0 -> skip)
--            -> 12 00 00 14   b       #0x5F14F34     (ALWAYS skip)
--   It branches to the exact join the flag==0 path already falls through to
--   every single frame Krauser isn't flashing — a state the engine is proven
--   to handle. Three other branches in the same block (0x5F14EF4, 0x5F14F00,
--   0x5F14F10) already jump to that identical target, so no register can be
--   use-before-def at the join. The skipped block contains ONLY three stores
--   through x27 (already dereferenced at 0x5F14EBC) plus a BL to
--   FixedFrame::operator==(int) @0x5F4081C, which is provably PURE (88 bytes
--   of ldr/fcmp/cset/ret — zero stores, zero calls). No check is NOP'd, so no
--   NULL can be relocated into a later deref. Scanned all of .text: ZERO
--   branches target the interior of the skipped range — it cannot be bypassed.
--
-- WHY NOT A HOOK ON EspCommonTrans:
--   1. It is HOT — per-effect, per-frame, 13 call sites (Esp0a/0b/0e/47_Trans).
--      A Lua callback here is forbidden outright.
--   2. Its prologue is  stp d15, d14, [sp, #-0xa0]!  — an FP store with SP
--      pre-index writeback. DobbyInstrument on it WOULD SMASH THE STACK.
--   A static byte poke is the only permitted instrument at this address.
--
-- WHY NOT PIN THE FLAG TO 0:
--   Krauser re-sets it on every throw, so a pin needs CONTINUOUS enforcement
--   (per-frame poll or a hook on hot EM39 AI) — exactly what is forbidden.
--   It would also strand Em39_Flash_Count at 50 forever, since its countdown
--   in sub_5E885DC is gated on flag==1. Needless state corruption.
--
-- RED HERRINGS — do NOT "fix" this mod by reaching for these:
--   • AVR4Bio4PlayerPawn::SetStunned @0x625FDBC — EPlayerStunType is
--     {None,SoftHit,MediumHit,HardHit,OnFire,Count}. There is NO flash/blind
--     member. That is the melee/fire hit-reaction system (17 callers, all
--     melee/fire). Storage is pawn+0x147C (float timer) / +0x1480 (u8 type).
--   • FVR4GamePlayerSettings::IsMotionBlindingEnabled @0x6319D8C — a 16-byte
--     VR comfort-setting getter (ldrb [x0,#0x48]; cmp #1; cset). Unrelated.
--   • UMercenariesStatsLibrary::OnPlayerBlindedByFlashGrenade @0x6364BC4 —
--     increments a u16 scoreboard field at +0x11E. A WITNESS, not a cause.
--     (Useful as a detector only — see VERBOSE block below.)
--   • EspSetWaterFlashBomb @0x5F192A0 — water-splash cosmetic, and it has
--     ZERO callers. Dead code.
--   • Filter00SetAlpha/SetType/SetAddSpread @0x5F3B6D4+ — driven ONLY by
--     cLightMgr::setEnv/setBlur (room ambient + blur). NoRecoil already
--     ret's Filter00SetAddSpread and the blind still happened — empirical
--     disproof of the whole Filter00 theory.
--   • FadeSet @0x5F39930 — the generic room/scenario fade, 746 callers, none
--     inside EM39. Patching it would break level transitions.
--
-- CHANGELOG
--   v1.0  Initial. Single branch flip at EspCommonTrans+0x70. Guarded by an
--         original-word check so a game update that shifts the block makes the
--         mod no-op instead of corrupting an unrelated instruction.
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "NoFlashBlind"
local VERBOSE = false
local function V(...) if VERBOSE then Log(TAG .. " [V] " .. string.format(...)) end end

local state = { enabled = true }

local saved = ModConfig.Load("NoFlashBlind")
if saved then
    if saved.enabled ~= nil then state.enabled = saved.enabled end
end

-- ═══════════════════════════════════════════════════════════════════════
-- BYTE PATCHES
-- ═══════════════════════════════════════════════════════════════════════

-- Anchor symbol: the patch site is MID-function, so Resolve() must anchor on
-- the function symbol and we Offset() into it. VA == file offset in this .so
-- (all four PT_LOAD have p_offset == p_vaddr), so the RVA fallback is exact.
local ESPCOMMONTRANS_SYM  = "_Z14EspCommonTransP4cEsp"
local ESPCOMMONTRANS_RVA  = 0x05F14E7C          -- size 6724
local WHITEOUT_OFF        = 0x70                -- -> 0x5F14EEC

local ORIG_CBZ  = 0x34000249   -- cbz w9, #0x5F14F34
local PATCH_B   = 0x14000012   -- b       #0x5F14F34   (+0x48)

local patchAddr = nil          -- resolved lightuserdata
local patchOrig = nil          -- original word, saved on first apply
local applied   = false

-- ToHex() is the POINTER formatter — it takes userdata and throws
--   "expected userdata, received number"
-- if handed a plain Lua number. Instruction words are numbers, so they need
-- their own formatter. (This is what broke the first load of this mod.)
local function hexword(n)
    return string.format("0x%08X", n or 0)
end

local function resolveSite()
    if patchAddr then return patchAddr end
    local ok, base = pcall(Resolve, ESPCOMMONTRANS_SYM, ESPCOMMONTRANS_RVA)
    if not ok or not base or IsNull(base) then
        LogWarn(TAG .. ": EspCommonTrans not resolved — mod disabled (no patch applied)")
        return nil
    end
    local addr = Offset(base, WHITEOUT_OFF)
    local ok2, word = pcall(ReadU32, addr)
    if not ok2 or not word then
        LogWarn(TAG .. ": could not read patch site @ " .. ToHex(addr) .. " — mod disabled")
        return nil
    end
    if word ~= ORIG_CBZ and word ~= PATCH_B then
        LogWarn(TAG .. ": UNEXPECTED word at EspCommonTrans+0x70 (" .. hexword(word) ..
                ", expected " .. hexword(ORIG_CBZ) .. ") — binary changed, refusing to patch")
        return nil
    end
    patchAddr = addr
    patchOrig = patchOrig or ORIG_CBZ
    V("site resolved @ %s (word %s)", ToHex(addr), hexword(word))
    return patchAddr
end

local function applyBlindPatch()
    local addr = resolveSite()
    if not addr then return false end
    local ok = pcall(WriteU32, addr, PATCH_B)
    if not ok then LogWarn(TAG .. ": WriteU32 failed @ " .. ToHex(addr)); return false end
    applied = true
    Log(TAG .. ": PATCHED EspCommonTrans+0x70 cbz->b @ " .. ToHex(addr) .. " (Em39 white-out skipped)")
    return true
end

local function restoreBlindPatch()
    if not patchAddr or not patchOrig then return end
    local ok = pcall(WriteU32, patchAddr, patchOrig)
    if ok then
        applied = false
        Log(TAG .. ": RESTORED EspCommonTrans+0x70 @ " .. ToHex(patchAddr))
    else
        LogWarn(TAG .. ": restore failed @ " .. ToHex(patchAddr))
    end
end

if state.enabled then applyBlindPatch() end

-- ═══════════════════════════════════════════════════════════════════════
-- DETECTOR (VERBOSE only) — confirms a blind event actually fired.
-- OnPlayerBlindedByFlashGrenade is a 24-byte stat bump reached ONLY from its
-- Blueprint exec thunk (0x64E1AB0) — once per blind, never per frame, so a
-- Lua callback is safe here. Mercenaries-mode only; silent in the campaign.
-- ═══════════════════════════════════════════════════════════════════════
if VERBOSE then
    pcall(function()
        local sym = Resolve("_ZN24UMercenariesStatsLibrary29OnPlayerBlindedByFlashGrenadeEv", 0x06364BC4)
        if sym and not IsNull(sym) then
            RegisterNativeHookAt(sym, "NoFlashBlind_Detector",
                function() V("blind event fired (stat counter)") end, nil)
        else
            LogWarn(TAG .. ": detector symbol not resolved (harmless)")
        end
    end)
end

-- ═══════════════════════════════════════════════════════════════════════
-- COMMAND
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("noflashblind", function()
    state.enabled = not state.enabled
    V("toggle: enabled=%s", tostring(state.enabled))
    if state.enabled then applyBlindPatch() else restoreBlindPatch() end
    ModConfig.Save("NoFlashBlind", state)
    Log(TAG .. ": " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "ON" or "OFF")
end)

-- ═══════════════════════════════════════════════════════════════════════
-- DEBUG MENU
-- ═══════════════════════════════════════════════════════════════════════

if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("NoFlashBlind", "No Flash Blind",
        function() return state.enabled end,
        function(v)
            state.enabled = v
            if v then applyBlindPatch() else restoreBlindPatch() end
            ModConfig.Save("NoFlashBlind", state)
        end)
end

Log(TAG .. ": v1.0 loaded — " .. (applied and "Krauser flash white-out REMOVED" or "inactive")
    .. " (enemy stun + Krauser AI untouched)")
