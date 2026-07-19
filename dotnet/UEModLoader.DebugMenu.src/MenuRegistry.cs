// Registry that lets OTHER mods contribute entries into the MODS tab without
// touching DebugMenuMod. C# mods call MenuRegistry.RegisterButton/RegisterToggle
// directly; Lua mods reach the same list through the native bridge
// (ueml_menu_register* exports -> DebugMenuBridge). Entries are grouped by mod
// name into a sub-page each, so every mod gets its own section under MODS.
using System;
using System.Collections.Generic;

namespace UEModLoader.DebugMenuMod
{
    public static class MenuRegistry
    {
        public sealed class Entry
        {
            public string Mod = "Mods";
            public string Label = "?";
            public ButtonKind Kind = ButtonKind.Button;
            public Action OnClick;
            public Func<bool> Get;
            public Action<bool> Set;
            public string OnText = "ON", OffText = "OFF";
            public RGBA Color = RGBA.White;
        }

        static readonly List<Entry> s_entries = new List<Entry>();
        static int _version;                 // bumps whenever the set changes
        public static int Version { get { lock (s_entries) return _version; } }

        public static void Register(Entry e)
        {
            if (e == null) return;
            lock (s_entries) { s_entries.Add(e); _version++; }
        }

        public static void RegisterButton(string mod, string label, Action onClick, RGBA? color = null)
            => Register(new Entry { Mod = mod, Label = label, Kind = ButtonKind.Button, OnClick = onClick, Color = color ?? RGBA.White });

        public static void RegisterToggle(string mod, string label, Func<bool> get, Action<bool> set, string on = "ON", string off = "OFF")
            => Register(new Entry { Mod = mod, Label = label, Kind = ButtonKind.Toggle, Get = get, Set = set, OnText = on, OffText = off });

        // Build a sub-page per contributing mod under the MODS page. Called each
        // time the menu structure is (re)built so late registrations are picked up.
        internal static void AttachTo(Menu menu, Page modsPage)
        {
            lock (s_entries)
            {
                if (s_entries.Count == 0) return;
                var order = new List<string>();
                var byMod = new Dictionary<string, List<Entry>>();
                foreach (var e in s_entries)
                {
                    string m = string.IsNullOrEmpty(e.Mod) ? "Mods" : e.Mod;
                    if (!byMod.TryGetValue(m, out var l)) { l = new List<Entry>(); byMod[m] = l; order.Add(m); }
                    l.Add(e);
                }
                foreach (var m in order)
                {
                    var page = menu.SubMenu(modsPage, m, m.ToUpperInvariant(), RGBA.Cyan);
                    foreach (var e in byMod[m])
                    {
                        if (e.Kind == ButtonKind.Toggle)
                            page.Toggle(e.Label, e.Get, e.Set, e.Color).Strings(e.OnText, e.OffText);
                        else
                            page.Add(e.Label, e.OnClick, e.Color);
                    }
                }
            }
        }
    }
}
