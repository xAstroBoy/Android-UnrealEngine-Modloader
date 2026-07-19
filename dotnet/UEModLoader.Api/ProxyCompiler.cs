// UEModLoader.Api / ProxyCompiler.cs
// On-DEVICE compilation of the generated game proxies. The native generator
// (csharp_proxy_generator.cpp, via GenerateCSharpProxies) emits Generated/*.cs
// from the live reflection graph; this then compiles them — using Roslyn running
// on the device's own CoreCLR — into UEModLoader.Game.dll, referencing the .NET
// 8 shared framework already on the device plus UEModLoader.dll (this API). So
// the MODLOADER produces the finished, typed proxy assembly; no PC build step.
//
// Output is a SEPARATE UEModLoader.Game.dll (not this running assembly, which is
// loaded/locked) that a modder references alongside UEModLoader.dll.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace UEModLoader
{
    public static class ProxyCompiler
    {
        /// <summary>Compile every .cs under <paramref name="srcDir"/> into
        /// <paramref name="outDll"/>, referencing the .NET runtime under
        /// <paramref name="runtimeSharedDir"/> and this API assembly. Returns a
        /// status/error summary string.</summary>
        public static string Compile(string srcDir, string runtimeSharedDir, string outDll)
        {
            try
            {
                if (!Directory.Exists(srcDir))
                    return $"no generated sources at {srcDir}";

                var trees = new List<SyntaxTree>();
                int files = 0;
                foreach (var cs in Directory.EnumerateFiles(srcDir, "*.cs", SearchOption.AllDirectories))
                {
                    trees.Add(CSharpSyntaxTree.ParseText(File.ReadAllText(cs), path: cs));
                    files++;
                }
                if (files == 0) return $"no .cs files in {srcDir}";

                // References: ONLY the core assemblies the proxies actually use
                // (IntPtr/primitives/arrays/string + the API types). Referencing
                // the whole shared framework makes Roslyn load metadata for dozens
                // of dlls → ~1GB and freezes a mobile device. The generated
                // proxies need only CoreLib/Runtime/netstandard + UEModLoader.dll.
                var refs = new List<MetadataReference>();
                string[] core = { "System.Private.CoreLib.dll", "System.Runtime.dll",
                                  "netstandard.dll", "System.Collections.dll",
                                  "System.Linq.dll", "System.Runtime.InteropServices.dll" };
                foreach (var name in core)
                {
                    string p = Path.Combine(runtimeSharedDir, name);
                    if (File.Exists(p)) { try { refs.Add(MetadataReference.CreateFromFile(p)); } catch { } }
                }
                // The API assembly (UnrealMod, UObject, ParamBuffer, ...).
                string apiPath = typeof(ProxyCompiler).Assembly.Location;
                if (!string.IsNullOrEmpty(apiPath) && File.Exists(apiPath))
                    refs.Add(MetadataReference.CreateFromFile(apiPath));

                // Debug optimization + no concurrent build: far cheaper than a
                // Release optimize pass, and single-threaded keeps a CPU core free
                // for the game thread (the compile runs on a low-priority thread).
                var options = new CSharpCompilationOptions(
                    OutputKind.DynamicallyLinkedLibrary,
                    optimizationLevel: OptimizationLevel.Debug,
                    allowUnsafe: true,
                    concurrentBuild: false,
                    deterministic: false);

                var comp = CSharpCompilation.Create(
                    "UEModLoader.Game", trees, refs, options);

                // Emit with no PDB (no debug stream) to cut work + memory.
                using var fs = new FileStream(outDll, FileMode.Create, FileAccess.Write);
                EmitResult result = comp.Emit(fs);
                if (!result.Success)
                {
                    var errs = result.Diagnostics
                        .Where(d => d.Severity == DiagnosticSeverity.Error)
                        .Take(10)
                        .Select(d => d.ToString());
                    return $"compile FAILED ({files} files): " + string.Join(" | ", errs);
                }
                return $"compiled {files} files -> {outDll} ({new FileInfo(outDll).Length} bytes)";
            }
            catch (Exception e)
            {
                return "compile exception: " + e;
            }
        }
    }
}
