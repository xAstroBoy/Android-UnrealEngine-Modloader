// UEModLoader.Api / Harmony.cs
// A HarmonyX-shaped patching surface, but the target is NATIVE Unreal — there is
// no managed game IL to patch — so Prefix/Postfix map to native/UFunction hooks
// and Transpiler maps to a native/Kismet REWRITE (arm64 assemble or Blueprint
// bytecode). Same ergonomics as MelonLoader's HarmonyInstance: PatchAll scans
// [HarmonyPatch] classes on init; UnpatchAll (auto on deinit) detaches them.

using System;
using System.Reflection;
using System.Collections.Generic;

namespace UEModLoader
{
    /// <summary>Marks a class as a patch. Target it EITHER by string
    /// ("cModel::getPartsPtr" native symbol, or "BP_Pawn_C:Jump" UFunction path)
    /// OR HarmonyX-style with a generated proxy type + method name:
    /// [HarmonyPatch(typeof(BP_Pawn_C), "Jump")] — the proxy carries a
    /// <c>UeClassName</c> const the attribute resolves via reflection.</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class HarmonyPatchAttribute : Attribute
    {
        public string Target { get; private set; }
        public Type DeclaringType { get; }
        public string MethodName { get; }

        public HarmonyPatchAttribute(string target) { Target = target; }

        public HarmonyPatchAttribute(Type declaringType, string methodName)
        {
            DeclaringType = declaringType;
            MethodName = methodName;
            Target = ResolveTarget(declaringType, methodName);
        }

        // typeof(Proxy) -> "UeClassName:Method" using the proxy's UeClassName const.
        internal static string ResolveTarget(Type t, string method)
        {
            try
            {
                var f = t.GetField("UeClassName",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                string cls = f?.GetValue(null) as string ?? t.Name;
                return cls + ":" + method;
            }
            catch { return t.Name + ":" + method; }
        }
    }

    [AttributeUsage(AttributeTargets.Method)] public sealed class HarmonyPrefixAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Method)] public sealed class HarmonyPostfixAttribute : Attribute { }
    /// <summary>Transpiler == native/Kismet rewrite. The method receives the
    /// resolved target (IntPtr address or a <see cref="Blueprint"/>) and rewrites
    /// it with <see cref="Patch"/>/<see cref="Blueprint"/>.</summary>
    [AttributeUsage(AttributeTargets.Method)] public sealed class HarmonyTranspilerAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Class)]  public sealed class HarmonyDontPatchAllAttribute : Attribute { }

    /// <summary>Per-mod patch instance. Mirrors MelonMod.HarmonyInstance.</summary>
    public sealed class Harmony
    {
        public string Id { get; }
        private readonly List<ulong> _hookIds = new List<ulong>();

        public Harmony(string id) { Id = id; }

        /// <summary>Scan an assembly for [HarmonyPatch] classes and apply them —
        /// the equivalent of HarmonyInstance.PatchAll(assembly).</summary>
        public void PatchAll(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                var pa = (HarmonyPatchAttribute)Attribute.GetCustomAttribute(type, typeof(HarmonyPatchAttribute));
                if (pa == null) continue;
                if (Attribute.IsDefined(type, typeof(HarmonyDontPatchAllAttribute))) continue;
                ApplyPatchClass(type, pa.Target);
            }
        }

        private void ApplyPatchClass(Type type, string target)
        {
            const BindingFlags F = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            HookCallback pre = FindCb(type, typeof(HarmonyPrefixAttribute), F);
            HookCallback post = FindCb(type, typeof(HarmonyPostfixAttribute), F);
            if (pre != null || post != null)
            {
                ulong id = Hooks.Install(target, pre, post, Id);
                if (id != 0) _hookIds.Add(id);
                Log.Info("Harmony", $"{Id}: patched {target} (pre={pre != null}, post={post != null})");
            }
            // Transpiler = native/Kismet rewrite. Invoke it with the resolved target.
            var tr = FindMethod(type, typeof(HarmonyTranspilerAttribute), F);
            if (tr != null)
            {
                object arg = ResolveTranspilerArg(tr, target);
                try { tr.Invoke(null, arg == null ? null : new[] { arg }); }
                catch (Exception e) { Log.Error("Harmony", $"{Id}: transpiler {target}: {e.Message}"); }
            }
        }

        private static HookCallback FindCb(Type t, Type attr, BindingFlags f)
        {
            var m = FindMethod(t, attr, f);
            if (m == null) return null;
            try { return (HookCallback)Delegate.CreateDelegate(typeof(HookCallback), m, false); }
            catch { Log.Warn("Harmony", $"{t.Name}.{m.Name}: must be (NativeContext)"); return null; }
        }

        private static MethodInfo FindMethod(Type t, Type attr, BindingFlags f)
        {
            foreach (var m in t.GetMethods(f))
                if (Attribute.IsDefined(m, attr)) return m;
            return null;
        }

        // Transpiler methods take either (IntPtr addr) or (Blueprint bp).
        private static object ResolveTranspilerArg(MethodInfo m, string target)
        {
            var ps = m.GetParameters();
            if (ps.Length == 0) return null;
            if (ps[0].ParameterType == typeof(Blueprint))
                return Blueprint.Find(target);
            return Memory.ResolveSymbol(target); // IntPtr address of the native fn
        }

        /// <summary>Manually patch a native symbol / UFunction path.</summary>
        public ulong Patch(string target, HookCallback prefix, HookCallback postfix = null)
        {
            ulong id = Hooks.Install(target, prefix, postfix, Id);
            if (id != 0) _hookIds.Add(id);
            return id;
        }

        /// <summary>Detach every patch this instance installed (auto on deinit).</summary>
        public void UnpatchAll()
        {
            foreach (var id in _hookIds) Hooks.Remove(id);
            _hookIds.Clear();
            // Byte/asm patches revert host-side by owner on mod unload.
        }
    }
}
