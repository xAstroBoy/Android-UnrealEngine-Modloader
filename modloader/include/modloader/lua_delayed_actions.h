// modloader/include/modloader/lua_delayed_actions.h
// UE4SS-compatible delayed action system
// ExecuteWithDelay, LoopAsync, ExecuteInGameThread variants,
// frame-based variants, CancelDelayedAction, IsDelayedActionValid

#pragma once

#include <sol/sol.hpp>
#include <cstdint>
#include <string>

namespace lua_delayed {

// Initialize the system — called from lua_engine::init()
void init();

// Tick function — must be called every ProcessEvent (game thread)
void tick_game_thread();

// Register all delayed action functions into the Lua state
void register_all(sol::state& lua);

// Cancel a specific delayed action by handle
void cancel(uint64_t handle);

// Cancel every delayed action registered by a mod (LoopAsync loops etc.).
// Owner is derived from the registering environment's MOD_NAME.
// Returns the number of actions cancelled.
int cancel_all_for_mod(const std::string& mod);

// Check if a delayed action handle is still valid/running
bool is_valid(uint64_t handle);

} // namespace lua_delayed
