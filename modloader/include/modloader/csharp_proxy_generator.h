#pragma once
// modloader/include/modloader/csharp_proxy_generator.h
// Emits faithful C# proxy classes from the live UE reflection graph — the
// UEModLoader.Game side of the single UEModLoader.dll. Every UClass becomes a
// real System.Type deriving from its real parent, with fields at their real
// offsets, functions with matching parameter names/types, enums, structs, and
// the traced NATIVE function addresses — so a C# mod codes against BP_Enemy_C /
// ACharacter as real classes (typeof-able, reflectable) and can drop to the
// IntPtr / reflection walk / Memory at any point.

#include <string>

namespace csharp_gen
{
    // Generate all proxies into <out_dir> (one .cs per package). Returns a short
    // summary string. Default out_dir = data_dir/dotnet/Generated.
    std::string generate(const std::string &out_dir = "");
}
