// Menu framework for the C# debug-menu takeover.
//   Menu   — the page registry (Dictionary<byte,Page>), root + auto-id'd sub-pages.
//   Page   — a title + a List<Button>.
//   Button — Button (action) / Toggle (on-off) / Sub (opens a nested page), each
//            with an RGBA colour.
// Plus the live DebugMenu_C accessor, FString marshaling for CreateActiveOption
// (the generated proxy can't pass an inline FString), per-row colouring, and a
// key=value config store so toggle state persists across sessions.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UEModLoader;
using UEModLoader.Game;

namespace UEModLoader.DebugMenuMod
{
    public enum ButtonKind { Button, Toggle, Sub }

    /// <summary>An RGBA colour (UE FLinearColor order).</summary>
    public struct RGBA
    {
        public float R, G, B, A;
        public RGBA(float r, float g, float b, float a = 1f) { R = r; G = g; B = b; A = a; }
        public static readonly RGBA White = new RGBA(1, 1, 1, 1);
        public static readonly RGBA Red = new RGBA(1f, 0.28f, 0.28f, 1);
        public static readonly RGBA Green = new RGBA(0.4f, 1f, 0.45f, 1);
        public static readonly RGBA Yellow = new RGBA(1f, 0.88f, 0.3f, 1);
        public static readonly RGBA Cyan = new RGBA(0.4f, 0.9f, 1f, 1);
        public static readonly RGBA Orange = new RGBA(1f, 0.6f, 0.2f, 1);
        public static readonly RGBA Gray = new RGBA(0.62f, 0.62f, 0.62f, 1);
    }

    /// <summary>One row: a Button, a Toggle, or a Sub (opens a nested Page).
    /// Every colour + on/off string is overridable per button.</summary>
    public sealed class Button
    {
        public string Label;
        public ButtonKind Kind;

        // Colours. Selected/hover always wins; a toggle otherwise shows On/Off colour.
        public RGBA Color = RGBA.White;    // Button / Sub base colour
        public RGBA OnColor = RGBA.Green;  // Toggle when ON
        public RGBA OffColor = RGBA.Red;   // Toggle when OFF
        public RGBA HoverColor = RGBA.Yellow;

        // Toggle value strings (shown after the label).
        public string OnText = "ON";
        public string OffText = "OFF";

        public Func<bool> Get;        // Toggle: live state
        public Action<bool> Set;      // Toggle: apply
        public Action OnClick;        // Button: action
        public Page Sub;              // Sub: the nested page it opens

        public bool State() { try { return Get != null && Get(); } catch { return false; } }

        /// <summary>Row colour for the current state / selection.</summary>
        public RGBA RowColor(bool selected)
        {
            if (selected) return HoverColor;
            return Kind == ButtonKind.Toggle ? (State() ? OnColor : OffColor) : Color;
        }

        public string Display()
        {
            switch (Kind)
            {
                case ButtonKind.Toggle: return Label + "   " + (State() ? OnText : OffText);
                case ButtonKind.Sub: return Label + "   >>";
                default: return Label;
            }
        }

        // ── fluent per-button customisation ──────────────────────────────────
        public Button Colored(RGBA c) { Color = c; return this; }
        public Button Hover(RGBA c) { HoverColor = c; return this; }
        public Button States(RGBA on, RGBA off) { OnColor = on; OffColor = off; return this; }
        public Button Strings(string on, string off) { OnText = on; OffText = off; return this; }
    }

    /// <summary>A page = title + ordered buttons.</summary>
    public sealed class Page
    {
        public readonly byte Id;
        public string Title;
        public RGBA TitleColor = RGBA.Cyan;
        public readonly List<Button> Buttons = new List<Button>();

        internal Page(byte id, string title) { Id = id; Title = title; }

        public Button Add(string label, Action onClick, RGBA? color = null)
        { var b = new Button { Label = label, Kind = ButtonKind.Button, OnClick = onClick, Color = color ?? RGBA.White }; Buttons.Add(b); return b; }

        public Button Toggle(string label, Func<bool> get, Action<bool> set, RGBA? color = null)
        { var b = new Button { Label = label, Kind = ButtonKind.Toggle, Get = get, Set = set, Color = color ?? RGBA.Green }; Buttons.Add(b); return b; }

        // Adds a Sub button that opens `sub` (create it via Menu.NewPage).
        public Button Link(string label, Page sub, RGBA? color = null)
        { var b = new Button { Label = label, Kind = ButtonKind.Sub, Sub = sub, Color = color ?? RGBA.Yellow }; Buttons.Add(b); return b; }
    }

    /// <summary>The page registry: root at a fixed id, sub-pages auto-id'd from 101.</summary>
    public sealed class Menu
    {
        public readonly Dictionary<byte, Page> Pages = new Dictionary<byte, Page>();
        public readonly Page Root;
        private byte _next;

        public Menu(byte rootId, string rootTitle, byte firstSubId = 101)
        {
            Root = new Page(rootId, rootTitle);
            Pages[rootId] = Root;
            _next = firstSubId;
        }

        /// <summary>Create + register a new (sub-)page.</summary>
        public Page NewPage(string title)
        {
            byte id = _next++;
            var p = new Page(id, title);
            Pages[id] = p;
            return p;
        }

        /// <summary>Create a sub-page AND wire a Sub button on `parent` to it.</summary>
        public Page SubMenu(Page parent, string label, string title, RGBA? color = null)
        {
            var sub = NewPage(title);
            parent.Link(label, sub, color);
            return sub;
        }

        public bool Has(byte id) => Pages.ContainsKey(id);
        public Page Get(byte id) => Pages.TryGetValue(id, out var p) ? p : null;
    }

    /// <summary>Shared runtime utilities: the live actor, widgets, FString + colour.</summary>
    public static class DM
    {
        // Cached: FindAllOf allocates a 64KB array + scans every UObject — doing that
        // per frame caused a CoreCLR GC deadlock that froze the game thread. Re-scan
        // at most ~1×/sec; the DebugMenu_C actor persists for the level.
        static IntPtr _cache; static long _cacheAt;
        public static DebugMenu_C Get()
        {
            long now = Environment.TickCount64;
            if (_cache != IntPtr.Zero && now - _cacheAt < 1000) return new DebugMenu_C(_cache);
            _cacheAt = now; _cache = IntPtr.Zero;
            var all = DebugMenu_C.All();
            for (int i = 0; i < all.Length; i++)
            {
                var o = all[i];
                if (o == null || !o.IsValid) continue;
                if (o.Name.StartsWith("Default__", StringComparison.Ordinal)) continue;
                _cache = o.Pointer;
                return o;
            }
            return null;
        }

        public static byte ActiveMenu(DebugMenu_C dm) { try { return dm.Get<byte>("ActiveMenu"); } catch { return 0; } }
        public static void SetActiveMenu(DebugMenu_C dm, byte v) { try { dm.Set<byte>("ActiveMenu", v); } catch { } }
        public static int CurrentIndex(DebugMenu_C dm) { try { return dm.Get<int>("CurrentIndex"); } catch { return -1; } }
        public static void SetCurrentIndex(DebugMenu_C dm, int v) { try { dm.Set<int>("CurrentIndex", v); } catch { } }

        public static int WidgetCount(DebugMenu_C dm)
        {
            try
            {
                int off = dm.OffsetOf("ActiveOptionsWidgets");
                if (off < 0) return 0;
                return Memory.Read<int>(dm.Pointer + off + 8);   // TArray Num @ +8
            }
            catch { return 0; }
        }

        public static IntPtr WidgetPtr(DebugMenu_C dm, int index)
        {
            try
            {
                int off = dm.OffsetOf("ActiveOptionsWidgets");
                if (off < 0) return IntPtr.Zero;
                IntPtr data = Memory.Read<IntPtr>(dm.Pointer + off);
                int num = Memory.Read<int>(dm.Pointer + off + 8);
                if (index < 0 || index >= num || data == IntPtr.Zero) return IntPtr.Zero;
                return Memory.Read<IntPtr>(data + index * IntPtr.Size);
            }
            catch { return IntPtr.Zero; }
        }

        public static string WidgetName(DebugMenu_C dm, int index)
        {
            IntPtr w = WidgetPtr(dm, index);
            return w == IntPtr.Zero ? null : new UObject(w).GetString("OptionName");
        }

        // Force a TArray's Num to 0 (abandons old elements; UE GC reclaims). Used to
        // truly empty the option lists — the stock ClearWidgets removes the UMG
        // children but leaves ActiveOptionsWidgets/ActiveDebugOptions populated.
        public static void SetArrayNum(DebugMenu_C dm, string prop, int num)
        {
            try { int off = dm.OffsetOf(prop); if (off >= 0) Memory.Write<int>(dm.Pointer + off + 8, num); }
            catch { }
        }

        public static void ClearWidgetsFully(DebugMenu_C dm)
        {
            try { dm.ClearWidgets(); } catch { }        // removes ParentVBox children
            SetArrayNum(dm, "ActiveOptionsWidgets", 0);  // + reset the tracking arrays
            SetArrayNum(dm, "ActiveDebugOptions", 0);
            SetArrayNum(dm, "ActiveOptionList", 0);
        }

        // FString param for CreateActiveOption (proxy mis-marshals it → build inline).
        public static void CreateOption(DebugMenu_C dm, string text)
        {
            text ??= "";
            int n = text.Length + 1;
            IntPtr data = Memory.Alloc(n * 2);
            for (int i = 0; i < text.Length; i++) Memory.Write<short>(data + i * 2, (short)text[i]);
            Memory.Write<short>(data + text.Length * 2, 0);
            var buf = new byte[16];
            BitConverter.GetBytes(data.ToInt64()).CopyTo(buf, 0);
            BitConverter.GetBytes(n).CopyTo(buf, 8);
            BitConverter.GetBytes(n).CopyTo(buf, 12);
            try { dm.CallRaw("CreateActiveOption", buf); } finally { Memory.Free(data); }
        }

        // Colour a row's label. UTextBlock.ColorAndOpacity is an FSlateColor
        // { FLinearColor SpecifiedColor @0x0; uint8 ColorUseRule @0x10 }. Writing
        // the PROPERTY alone doesn't repaint — the Slate widget caches its colour,
        // so we ALSO call UTextBlock::SetColorAndOpacity(FSlateColor), which pushes
        // the value into the live Slate text and forces a repaint. That's why the
        // earlier property-only version showed no colours.
        public static void SetRowColor(DebugMenu_C dm, int index, RGBA c)
        {
            try
            {
                IntPtr w = WidgetPtr(dm, index);
                if (w == IntPtr.Zero) return;
                var widget = new UObject(w);
                var text = widget.GetObject("OptionNameText");
                if (text == null || !text.IsValid) return;
                int off = text.OffsetOf("ColorAndOpacity");
                if (off < 0) return;
                IntPtr p = text.Pointer + off;
                Memory.Write(p + 0, c.R); Memory.Write(p + 4, c.G);
                Memory.Write(p + 8, c.B); Memory.Write(p + 12, c.A);
                Memory.Write<byte>(p + 16, 0);   // ColorUseRule = UseColor_Specified
                // NOTE: no SetColorAndOpacity CallRaw — that native call crashed Mono
                // (libcoreclr fault 0x10) under menu churn. The property write below
                // takes effect when the widget's Setup() re-runs (which the game does
                // on highlight); toggle STATE is always visible via the row text too.
            }
            catch { }
        }

        // Assign/update a row's label live (writes the OptionName FString in place +
        // re-runs the widget's Setup so the text re-renders).
        public static void SetOptionName(DebugMenu_C dm, int index, string text)
        {
            try
            {
                IntPtr w = WidgetPtr(dm, index);
                if (w == IntPtr.Zero) return;
                var widget = new UObject(w);
                int off = widget.OffsetOf("OptionName");
                if (off < 0) return;
                text ??= "";
                int n = text.Length + 1;
                IntPtr data = Memory.Alloc(n * 2);
                for (int i = 0; i < text.Length; i++) Memory.Write<short>(data + i * 2, (short)text[i]);
                Memory.Write<short>(data + text.Length * 2, 0);
                IntPtr p = widget.Pointer + off;
                Memory.Write(p + 0, data.ToInt64());
                Memory.Write(p + 8, n);
                Memory.Write(p + 12, n);
                try { widget.Call("Setup"); } catch { }
            }
            catch { }
        }

        // NOTE: setting the FText title is intentionally a no-op. Doing it via
        // Lua.Eval DEADLOCKED the game — exec_string takes s_exec_mutex, and this
        // runs on the game thread from inside the ProcessEvent/Lua drain, which
        // already holds that mutex → re-entrant lock hang. Never call Lua from a
        // C# menu hook. (A native FText setter could re-enable titles later.)
        public static void SetTitle(string title) { /* no-op — see comment */ }
    }

    public static class Config
    {
        private static readonly Dictionary<string, string> s_kv = new Dictionary<string, string>();
        private static string s_path;

        public static void Load(string dataDir)
        {
            try
            {
                s_path = Path.Combine(dataDir ?? ".", "csharp_debugmenu.cfg");
                if (!File.Exists(s_path)) return;
                foreach (var line in File.ReadAllLines(s_path))
                {
                    int eq = line.IndexOf('=');
                    if (eq <= 0) continue;
                    s_kv[line.Substring(0, eq).Trim()] = line.Substring(eq + 1).Trim();
                }
            }
            catch { }
        }

        public static void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(s_path)) return;
                var sb = new StringBuilder();
                foreach (var kv in s_kv) sb.Append(kv.Key).Append('=').Append(kv.Value).Append('\n');
                File.WriteAllText(s_path, sb.ToString());
            }
            catch { }
        }

        public static bool GetBool(string key, bool dflt = false)
            => s_kv.TryGetValue(key, out var v) ? v == "1" : dflt;
        public static void SetBool(string key, bool val) { s_kv[key] = val ? "1" : "0"; Save(); }
    }
}
