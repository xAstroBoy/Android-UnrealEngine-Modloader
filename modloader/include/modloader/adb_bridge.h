#pragma once
// modloader/include/modloader/adb_bridge.h
// TCP socket server on 127.0.0.1:19420 — ADB command bridge
// No root required. JSON protocol.

#include <string>
#include <functional>
#include <vector>

namespace adb_bridge {

constexpr int ADB_BRIDGE_PORT = 19420;

// Command handler type: takes args string, returns response string
using CommandHandler = std::function<std::string(const std::string&)>;

// Command wrapper type: ENHANCE an existing command. Receives the args plus a
// `call_original` thunk that runs the stock command; the wrapper may call it,
// inspect/modify its result, run instead of it, or run extra work around it.
using CommandWrapper =
    std::function<std::string(const std::string& args,
                              const std::function<std::string()>& call_original)>;

// Start the TCP server on a background thread
bool start();

// Stop the server
void stop();

// Check if the server is running
bool is_running();

// True while a bridge command is actively executing on the game thread.
// Used by Lua bindings to reject crash-prone bulk scans from live bridge calls.
bool is_game_thread_command_active();

// Register a custom command handler (from Lua mods via RegisterCommand)
void register_command(const std::string& name, CommandHandler handler);

// Remove a custom command (mod unload). Safe if the name is unknown.
void unregister_command(const std::string& name);

// Register/remove a WRAPPER that enhances an existing command (built-in or
// custom). The wrapper runs on the caller's thread and is handed a
// call_original thunk — see CommandWrapper. One wrapper per command name.
void register_command_wrapper(const std::string& name, CommandWrapper wrapper);
void unregister_command_wrapper(const std::string& name);

// Get names of all registered custom commands
std::vector<std::string> get_registered_commands();

} // namespace adb_bridge
