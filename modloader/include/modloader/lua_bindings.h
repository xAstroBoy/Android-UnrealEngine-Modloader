#pragma once
// modloader/include/modloader/lua_bindings.h
// Registers all global Lua functions: FindClass, RegisterHook, CallNative, etc.

namespace sol { class state; }

namespace lua_bindings {

// Register all global functions and types into the Lua state
void register_all(sol::state& lua);

// Register the memory toolkit (scan/inspect/watch/aob) — implemented in lua_memtools.cpp
void register_memtools(sol::state& lua);

} // namespace lua_bindings
