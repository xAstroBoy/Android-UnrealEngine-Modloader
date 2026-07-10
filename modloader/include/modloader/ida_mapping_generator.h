#pragma once
// modloader/include/modloader/ida_mapping_generator.h
// IDA / Ghidra / x64dbg mapping generator — Dumper-7 style.
//
// Walks the live UE4 reflection graph and, for every native UFunction, reads
// its EXEC native-function pointer (UFunction::Func), converts it to a module
// RVA (addr - libUE4.so base), and emits scripts that rename those addresses
// in a disassembler when the same libUE4.so is loaded there.
//
// Outputs (under <data>/IDAMapping/):
//   UnrealFunctions.py   — IDAPython: renames + comments every native UFunction
//   UnrealGlobals.py     — IDAPython: renames resolved engine globals/exports
//   UnrealMappings.json  — machine-readable {rva, name, full_name, flags, ...}
//   UnrealSymbols.map    — "<name> 0x<rva>" (Ghidra ImportSymbolsScript / generic)
//
// RVAs are relative to the engine module base. The IDAPython scripts add
// idaapi.get_imagebase() at run time so they work regardless of IDA's rebase.

namespace ida_map
{
    // Generate all IDA mapping files from the current reflection cache.
    // Returns the number of files written (0 on failure).
    // Requires reflection::walk_all() to have populated the cache and
    // symbols::lib_base() to be non-zero.
    int generate();

    // Number of function addresses renamed in the last generate() run.
    int function_count();

    // Number of global/export symbols emitted in the last generate() run.
    int global_count();

} // namespace ida_map
