-- harmony.lua — HarmonyX-style patching for LUA mods, over the modloader's
-- native primitives. Gives Lua the same ergonomics the C# Harmony gives .NET
-- mods: Prefix/Postfix hooks on native symbols or UFunctions, and a
-- "transpiler" that rewrites native code (arm64 assemble) or Blueprint bytecode.
--
-- Usage (in a Lua mod):
--   local Harmony = dofile(ModDir() .. "/harmony.lua")   -- or require it
--   local h = Harmony.new("MyMod")
--   -- Prefix on a native function (return "BLOCK" from pre to skip original):
--   h:Patch("cModel::getPartsPtr", function(ctx) --[[ inspect/modify ]] end)
--   -- Prefix/Postfix on a UFunction path:
--   h:Patch("BP_VR_Pawn_C:Jump", function(self,fn,parms) end, nil)
--   -- Transpiler: rewrite native code (branch over a bad call):
--   h:Transpile(site, "mov x2, xzr\nb 0x5e4a36c")
--   -- Auto-cleanup on unload is handled by the modloader (patches are tracked).

local Harmony = {}
Harmony.__index = Harmony

function Harmony.new(id)
    return setmetatable({ id = id or "lua", ids = {} }, Harmony)
end

-- Patch a target. A "Class:Function" string is a UFunction (ProcessEvent) hook;
-- anything else (e.g. "cModel::getPartsPtr", a symbol) is a native hook.
-- pre/post are callbacks; a native pre may return "BLOCK" to skip the original.
function Harmony:Patch(target, pre, post)
    local is_ufunction = target:find(":") ~= nil and target:find("::") == nil
    if is_ufunction then
        if pre and RegisterPreHook then
            local id = RegisterPreHook(target, pre)
            table.insert(self.ids, id)
        end
        if post and RegisterPostHook then
            local id = RegisterPostHook(target, post)
            table.insert(self.ids, id)
        end
        return true
    else
        -- Native symbol hook (pre/post get a register-context table).
        return RegisterNativeHook(target, pre, post)
    end
end

-- Convenience: prefix-only / postfix-only.
function Harmony:Prefix(target, fn)  return self:Patch(target, fn, nil) end
function Harmony:Postfix(target, fn) return self:Patch(target, nil, fn) end

-- Transpiler == native/Kismet rewrite. Pass AArch64 assembly text to splice at
-- `addr` (PC-relative branches resolve), reversible + i-cache-correct.
function Harmony:Transpile(addr, asm_text)
    local ok, err = PatchAsm(addr, asm_text)
    if not ok then LogError(("Harmony[%s]: transpile @0x%x failed: %s"):format(self.id, addr, err or "?")) end
    return ok
end

-- Redirect a call/branch target.
function Harmony:Redirect(addr, target) return PatchBranch(addr, target) end

-- NOP out N instructions.
function Harmony:Nop(addr, count) return PatchNop(addr, count or 1) end

-- Best-effort teardown (the modloader also auto-reverts a mod's patches/hooks
-- on unload, so this is optional).
function Harmony:UnpatchAll()
    for _, id in ipairs(self.ids) do
        if UnregisterHook then pcall(UnregisterHook, id) end
    end
    self.ids = {}
end

return Harmony
