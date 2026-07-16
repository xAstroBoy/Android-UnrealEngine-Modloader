-- mods/NoRecharge/main.lua v3.0
-- ═══════════════════════════════════════════════════════════════════════
-- UE4SS-style Instant Reload — hooks reload state UFunctions via
-- RegisterPostHook. Uses FindFirstOf for ammo/gun inspection.
--
-- v3.0 — Full UE4SS API:
--   RegisterPostHook on VR4GamePlayerAmmo/Arrow reload UFunctions
--   FindFirstOf("VR4GamePlayerAmmo") for reload state inspection
--   Native hooks on BeginReload → InstantReload redirect
-- ═══════════════════════════════════════════════════════════════════════
local TAG = "NoRecharge"
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

local state = {
    enabled = true,
}

local saved = ModConfig.Load("NoRecharge")
if saved then
    if saved.enabled ~= nil then state.enabled = saved.enabled end
end

-- ═══════════════════════════════════════════════════════════════════════
-- UE4SS POST-HOOKS — Override reload state returns
-- ═══════════════════════════════════════════════════════════════════════

-- VR4GamePlayerAmmo::IsReloadInProgress → false (skip reload animation)
RegisterPostHook("/Script/Game.VR4GamePlayerAmmo:IsReloadInProgress", function(self, func, parms)
    if not state.enabled then return end
    V("PostHook VR4GamePlayerAmmo:IsReloadInProgress -> false")
    local p = CastParms(parms, "VR4GamePlayerAmmo:IsReloadInProgress")
    if p then p:SetReturnValue(false) end
end)

-- VR4GamePlayerAmmo::IsReloadLingering → false
RegisterPostHook("/Script/Game.VR4GamePlayerAmmo:IsReloadLingering", function(self, func, parms)
    if not state.enabled then return end
    V("PostHook VR4GamePlayerAmmo:IsReloadLingering -> false")
    local p = CastParms(parms, "VR4GamePlayerAmmo:IsReloadLingering")
    if p then p:SetReturnValue(false) end
end)

-- VR4GamePlayerArrow (bow) overrides
RegisterPostHook("/Script/Game.VR4GamePlayerArrow:IsReloadInProgress", function(self, func, parms)
    if not state.enabled then return end
    V("PostHook VR4GamePlayerArrow:IsReloadInProgress -> false")
    local p = CastParms(parms, "VR4GamePlayerArrow:IsReloadInProgress")
    if p then p:SetReturnValue(false) end
end)

RegisterPostHook("/Script/Game.VR4GamePlayerArrow:IsReloadLingering", function(self, func, parms)
    if not state.enabled then return end
    V("PostHook VR4GamePlayerArrow:IsReloadLingering -> false")
    local p = CastParms(parms, "VR4GamePlayerArrow:IsReloadLingering")
    if p then p:SetReturnValue(false) end
end)

Log(TAG .. ": 4 UE4SS RegisterPostHook on VR4GamePlayerAmmo/Arrow reload UFunctions")

-- ═══════════════════════════════════════════════════════════════════════
-- NATIVE HOOKS — BeginReload → InstantReload redirect
-- ═══════════════════════════════════════════════════════════════════════

local sym_InstantReload = Resolve("InstantReload", 0x062DCA7C)

-- ═══════════════════════════════════════════════════════════════════════
-- RIFLE / MINE-THROWER AUTO-BOLT — kill the manual "recharge each shot"
-- ═══════════════════════════════════════════════════════════════════════
-- Verified in IDA v2.3: AVR4GamePlayerRifle::IsAutoBoltAllowed() only returns
-- true when the game setting FVR4GamePlayerSettings::Get()[0x3D] (ReloadStyle)
-- == 1. With the default (manual) style, bolt-action weapons — including the
-- Mine Thrower / "grenade launcher" (a Rifle subclass) — force you to cycle the
-- bolt after EVERY shot (the "recharge each shot" the ammo/reload hooks can't
-- touch). We patch the setting compare (IsAutoBoltAllowed+0x60,
-- `ldrb w8,[x0,#0x3d]` → `mov w8,#1`) so auto-bolt is always ALLOWED for capable
-- weapons — without changing the shared setting byte.
pcall(function()
    local sym = Resolve("_ZNK19AVR4GamePlayerRifle17IsAutoBoltAllowedEv", 0x0631632C)
    if sym and not IsNull(sym) then
        WriteU32(Offset(sym, 0x60), 0x52800028)   -- mov w8, #1  (settings compare always == 1)
        Log(TAG .. ": PATCHED IsAutoBoltAllowed → auto-bolt on (no manual recharge) @ " .. ToHex(Offset(sym, 0x60)))
    else
        Log(TAG .. ": [WARN] IsAutoBoltAllowed not resolved")
    end
end)

-- ═══════════════════════════════════════════════════════════════════════
-- CHAMBER NEVER EMPTIES — the REAL per-shot "reload each shot" fix
-- ═══════════════════════════════════════════════════════════════════════
-- Verified in IDA: a gun's loaded-round count is the virtual getter
-- AVR4GamePlayerGun::GetCurrentAmmo (vtable[247], RVA 0x62E016C). Single-shot
-- weapons like the MINE THROWER have chamber capacity 1, so one shot makes it
-- read 0 → AVR4GamePlayerRifle::PreBio4Tick latches chamber-empty and calls
-- BeginReload = the per-shot reload (NOT the auto-bolt; the ammo/reload hooks
-- above never covered it). The game's own infinite path returns 999 when the
-- weapon item charge == 0x8000, but the Mine Thrower isn't flagged and the game
-- ignores it there — so we patch the getter into a `return 999` leaf stub:
--   0x62E016C +0x0  STP X20,X19,[SP,#-0x20]!  → MOV W0,#0x3E7 (0x52807CE0)
--   0x62E016C +0x4  STP X29,X30,[SP,#0x10]    → RET            (0xD65F03C0)
-- Chamber never empties → IsReadyToFire/AmmoAvailable always true → no
-- BeginReload, no per-shot recharge. NOTE: GetCurrentAmmo is the shared Gun
-- getter, so this gives ALL firearms a permanently-loaded chamber (global
-- no-reload). There is no static per-weapon variant (would need a runtime hook).
pcall(function()
    local sym = Resolve("_ZN17AVR4GamePlayerGun13GetCurrentAmmoEc", 0x062E016C)
    if sym and not IsNull(sym) then
        WriteU32(sym, 0x52807CE0)              -- MOV W0, #0x3E7 (999)
        WriteU32(Offset(sym, 4), 0xD65F03C0)   -- RET
        Log(TAG .. ": PATCHED GetCurrentAmmo → 999 (chamber never empties, no per-shot reload) @ " .. ToHex(sym))
    else
        Log(TAG .. ": [WARN] GetCurrentAmmo not resolved")
    end
end)

-- MINE THROWER chamber-lock: Rifle::IsReadyToFire returns false while the
-- spent-chamber flag (field4552 @ this+0x11C8) is set after a shot — THAT is
-- what stops it firing again ("1 round per chamber"), not the ammo count. Flip
-- the CBZ at IsReadyToFire+0x8 (0x34000068) into an unconditional B (0x14000003)
-- so it ignores the chamber-spent state and always falls through to the base
-- ammo check (satisfied by the GetCurrentAmmo→999 stub above). Affects all Rifles.
pcall(function()
    local sym = Resolve("_ZNK19AVR4GamePlayerRifle13IsReadyToFireEv", 0x063160A4)
    if sym and not IsNull(sym) then
        WriteU32(Offset(sym, 0x8), 0x14000003)   -- CBZ W8 -> B (ignore chamber-spent gate)
        Log(TAG .. ": PATCHED Rifle::IsReadyToFire → ignore chamber lock (fire every pull) @ " .. ToHex(Offset(sym, 0x8)))
    else
        Log(TAG .. ": [WARN] Rifle::IsReadyToFire not resolved")
    end
end)

pcall(function()
    RegisterNativeHook("cObjWep_reloadable", nil,
        function(retval)
            if not state.enabled then return retval end
            V("Native cObjWep_reloadable -> 1")
            return 1
        end)
    Log(TAG .. ": Native hook — cObjWep_reloadable → true")
end)

if sym_InstantReload then
    pcall(function()
        RegisterNativeHook("BeginReload",
            function(self_ptr)
                if not state.enabled then return self_ptr end
                V("Native BeginReload -> InstantReload redirect, self=%s", tostring(self_ptr))
                CallNative(sym_InstantReload, "vp", self_ptr)
                return self_ptr
            end, nil)
        Log(TAG .. ": Native hook — BeginReload → InstantReload redirect")
    end)
end

-- ═══════════════════════════════════════════════════════════════════════
-- COMMANDS — UE4SS ammo/gun inspection
-- ═══════════════════════════════════════════════════════════════════════

RegisterCommand("norecharge", function()
    state.enabled = not state.enabled
    V("toggle: enabled=%s", tostring(state.enabled))
    ModConfig.Save("NoRecharge", state)
    Log(TAG .. ": " .. (state.enabled and "ON" or "OFF"))
    Notify(TAG, state.enabled and "ON" or "OFF")
end)

RegisterCommand("reload_status", function()
    local info = TAG .. ": enabled=" .. tostring(state.enabled)
    -- Find active ammo component
    local ammo = findFirstNonDefault("VR4GamePlayerAmmo")
    if ammo and ammo:IsValid() then
        pcall(function()
            local dur = ammo.ReloadDuration
            if dur then info = info .. " | ReloadDuration=" .. tostring(dur) end
        end)
        pcall(function()
            local gun = ammo.OwningGun
            if gun and gun:IsValid() then
                info = info .. " | OwningGun=valid"
                local useMag = gun.UsesMagazines
                if useMag ~= nil then info = info .. " UsesMagazines=" .. tostring(useMag) end
            end
        end)
    end
    Log(info)
end)

if SharedAPI and SharedAPI.DebugMenu then
    SharedAPI.DebugMenu.RegisterToggle("NoRecharge", "Instant Reload",
        function() return state.enabled end,
        function(v) state.enabled = v; ModConfig.Save("NoRecharge", state) end)
end

Log(TAG .. ": v3.0 loaded — UE4SS PostHook reload overrides + native InstantReload redirect + ammo inspection")
