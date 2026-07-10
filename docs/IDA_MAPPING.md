# IDA / Ghidra Function Mapping (Dumper-7 style)

The modloader can dump a **function-rename mapping** for `libUE4.so` straight from
the live reflection graph — the same idea as
[Dumper-7](https://github.com/Encryqed/Dumper-7)'s IDA mapping. Every **native**
`UFunction`'s exec pointer (`UFunction::Func`) is resolved at runtime, converted to
a module RVA, and written out as scripts that rename those addresses in your
disassembler when you load the *same* `libUE4.so`.

## What you get

Written to `<data>/IDAMapping/` on the device
(e.g. `/sdcard/UnrealModloader/<pkg>/IDAMapping/`):

| File | Purpose |
|---|---|
| `UnrealFunctions.py` | **IDAPython** — renames + comments every native `UFunction` exec thunk |
| `UnrealGlobals.py` | **IDAPython** — renames resolved engine exports/globals (ProcessEvent, GUObjectArray, GNames, GWorld, GEngine, StaticFindObject, …) |
| `UnrealSymbols.map` | `"<name> 0x<rva> <f|l>"` — feed to **Ghidra**'s `ImportSymbolsScript.py`, or any generic tool |
| `UnrealMappings.json` | Machine-readable: `{rva, name, full_name, ue_path, flags, kind}` per entry |

Names are emitted as `exec_<Class>_<Function>` (valid IDA identifiers) with a
repeatable comment carrying the full `Class::Function` / UE path and the function
flags.

### What is (and isn't) renamed

- **Included:** functions with the `FUNC_Native` flag — these have a real, unique
  exec-thunk address inside `libUE4.so`.
- **Excluded:** pure Blueprint functions — they all share `UObject::ProcessInternal`
  (the bytecode VM entry), so renaming any single address to one function name would
  be wrong. Colliding addresses are de-duplicated automatically.
- Addresses outside the engine module's mapped range are dropped (so out-of-module
  natives never get a bogus RVA).

RVAs are relative to the engine module base. The IDAPython scripts add
`idaapi.get_imagebase()` at run time, so they work no matter where IDA rebases the
library.

## Generating it

The mapping is produced automatically as part of a normal SDK dump (it's step 5 of
`sdk_gen::generate()`), so any full dump now also emits `IDAMapping/`.

To generate on demand over the ADB bridge:

```bash
# via the bridge console / deploy tool
python tools/deploy.py console
> dump_ida
```

or send the raw bridge command `{"cmd":"dump_ida"}` to port 19420. It re-walks
`GUObjectArray` (to pick up newly loaded classes) and regenerates the files. The
response reports the function/global counts and the output path.

Then pull the folder:

```bash
adb pull /sdcard/UnrealModloader/<pkg>/IDAMapping ./IDAMapping
```

## Using it in IDA

1. Open the game's `libUE4.so` in IDA and let auto-analysis finish.
2. `File ▸ Script file…` → pick `UnrealFunctions.py`. It renames every native
   `UFunction` exec thunk and adds a comment with the UE path + flags.
3. Optionally run `UnrealGlobals.py` too.

The console prints e.g. `UnrealFunctions: 21873 renamed, 12 skipped (of 21885)`.
Skips are usually addresses IDA hasn't defined as code yet — run auto-analysis
first, or re-run the script.

## Using it in Ghidra

`Window ▸ Script Manager ▸ ImportSymbolsScript.py`, then choose `UnrealSymbols.map`.
Format is `name address [f|l]` (RVAs — set the script's base to the image base).

## Notes

- The exec thunk is UE's auto-generated `execFoo` wrapper (the `DEFINE_FUNCTION`
  glue), not the hand-written implementation — same thing Dumper-7 renames. It's the
  address ProcessEvent dispatches to, and the ideal hook/xref anchor.
- Best results come from dumping **after** the game is fully in-level, so blueprint
  and streamed classes are present in `GUObjectArray`.
