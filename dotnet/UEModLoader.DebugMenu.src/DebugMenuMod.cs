// C# debug-menu overhaul, v8 — BRIDGE-DRIVEN, using the game's native pages.
//
// MAIN gets one injected "MODS" entry (takeover). Selecting it renders the native
// menu_bridge's page tree into ONE game page byte (BRIDGE_BYTE): the game gives us
// a real [Back] widget + native scroll/highlight/auto-fit; we just fill the rows
// and route confirms. Lua mods populate the tree through DebugMenuAPI's shim
// (AddMenuEntry / MenuNavigate / MenuItem). A submenu item's Lua callback runs on
// the game-thread tick and may navigate; we poll TakeNav and follow it, so dynamic
// nested sub-pages (Randomizer / EnemySpawner) work. Back walks the bridge parent.
using System;
using System.Collections.Generic;
using UEModLoader;
using UEModLoader.Game;

namespace UEModLoader.DebugMenuMod
{
    [MelonInfo(typeof(DebugMenuMod), "DebugMenuPlus", "8.0.0", "astro")]
    public sealed unsafe class DebugMenuMod : UnrealMod
    {
        const string DM_PATH = "/Game/Blueprints/Debug/DebugMenu/DebugMenu.DebugMenu_C";
        const byte MAIN = 1;
        const byte BRIDGE_BYTE = 99;     // game page we render every bridge page into

        static DebugMenuMod _inst;
        bool _installed;

        readonly Queue<Action> _pending = new Queue<Action>();
        bool _takenOver, _rebuilding;
        int _modsRowIndex = -1;          // index of OUR appended row on MAIN (-1 = not injected)
        long _nextHealCheck, _confirmGuardUntil;

        const string MODS_ROW = "MODS";   // our injected row; also the self-heal sentinel

        // ── bridge nav state ──
        int _bridgePage = -1;                                  // page currently rendered (-1 = not in bridge)
        readonly List<int> _navStack = new List<int>();        // bridge page ids, for Back
        struct Row { public bool Builtin; public int Id; public bool Interactive; }
        readonly List<Row> _rows = new List<Row>();            // widget row (after [Back]) → action
        int _pollNavIn;                                        // frames until we poll TakeNav after an invoke

        static readonly string[] BUILTIN = { "Clear Debug Draws", "Flash Test Sphere (2s)" };

        public override void OnInitializeMelon()
        {
            _inst = this;
            RegisterCommands();
            TryInstallHooks();
            LogMsg("DebugMenuPlus v8 ready — bridge-driven MODS tab (native pages). Lua mods via AddMenuEntry.");
        }

        // ── ProcessEvent hooks ────────────────────────────────────────────────
        static string BndEvt(int n) =>
            "VR4PlayerController_BP_C:BndEvt__DebugInput_K2Node_ComponentBoundEvent_"
            + n + "_DebugKeyMulticastDelegate__DelegateSignature";

        static readonly int[] SCROLL_IDS = { 0, 1, 2, 4, 5, 6, 7, 11, 13 };
        static readonly int[] CONFIRM_IDS = { 3, 8, 10 };
        const int BACK_ID = 9;

        void TryInstallHooks()
        {
            if (_installed) return;
            ulong ok = Hooks.OnUFunctionPost(DM_PATH + ":OpenDebugMenu", (self, parms) => OnOpenPost());
            if (ok == 0) return;
            foreach (int id in SCROLL_IDS)
                Hooks.OnUFunctionPost(BndEvt(id), (self, parms) => OnNavPost());
            foreach (int id in CONFIRM_IDS)
                Hooks.OnUFunctionPre(BndEvt(id), (self, parms) => OnConfirmPre());
            Hooks.OnUFunctionPre(BndEvt(BACK_ID), (self, parms) => OnBackPre());
            _installed = true;
            LogMsg("PE hooks installed — OpenDebugMenu + Scroll/Confirm/Back.");
        }

        static long Now => Environment.TickCount64;

        static bool MenuReady(DebugMenu_C dm)
        {
            try
            {
                if (dm == null || !dm.IsValid) return false;
                var pw = dm.GetObject("ParentWidget");
                if (pw == null || !pw.IsValid) return false;
                var vbl = pw.GetObject("DebugVBoxList");
                return vbl != null && vbl.IsValid;
            }
            catch { return false; }
        }

        void OnOpenPost()
        {
            _takenOver = false; _bridgePage = -1;
            _nextHealCheck = 0;   // heal on the very next frame, then keep healing
        }

        void OnNavPost()
        {
            var dm = DM.Get();
            if (!MenuReady(dm)) return;
            byte page = DM.ActiveMenu(dm);
            if (page == MAIN)
            {
                if (!_takenOver && DM.WidgetCount(dm) > 0) InjectModsRow(dm);
                _bridgePage = -1;
            }
        }

        bool OnConfirmPre()
        {
            var dm = DM.Get();
            if (!MenuReady(dm)) return false;
            if (Now < _confirmGuardUntil) return true;
            byte page = DM.ActiveMenu(dm);
            int ci = DM.CurrentIndex(dm);

            if (page == MAIN && _takenOver)
            {
                // Claim ONLY our appended row. Every stock row is a real game widget
                // now, so returning false lets the game's own DoAction run it —
                // nothing is faked or intercepted.
                if (ci == _modsRowIndex && _modsRowIndex >= 0) { EnterBridge(); return true; }
                return false;
            }
            if (page == BRIDGE_BYTE)
            {
                if (ci <= 0) { BackBridge(); return true; }     // [Back] widget
                int ri = ci - 1;
                if (ri >= 0 && ri < _rows.Count)
                {
                    var row = _rows[ri];
                    if (row.Builtin) { DoBuiltin(row.Id); AfterAction(); return true; }
                    if (row.Interactive) { LuaMenuBridge.Invoke(row.Id); AfterAction(); return true; }
                }
                return true;                                    // header / out of range → consume
            }
            return false;
        }

        bool OnBackPre()
        {
            var dm = DM.Get();
            if (!MenuReady(dm)) return false;
            if (DM.ActiveMenu(dm) == BRIDGE_BYTE) { BackBridge(); return true; }
            return false;
        }

        void AfterAction() { _pollNavIn = 3; _confirmGuardUntil = Now + 300; }

        // ── MAIN: APPEND one "MODS" row, leave the stock menu completely alone ────
        // This works WITH the game's menu instead of replacing it. We do NOT clear
        // the widget list and we do NOT clone the stock rows into fake options —
        // that was the old behaviour and it was wrong: cloned rows are dead
        // look-alikes whose actions we then had to fake by index, and the rebuild
        // fight made the menu vanish entirely. Now the game's own widgets stay
        // untouched and keep their native behaviour; we just add one row on the end
        // and only claim clicks on that exact row.
        // Returns the index our row landed at (-1 on failure).
        int InjectModsRow(DebugMenu_C dm)
        {
            if (_rebuilding) return _modsRowIndex;
            _rebuilding = true;
            try
            {
                int n = DM.WidgetCount(dm);
                int longest = MODS_ROW.Length;
                for (int i = 0; i < n; i++)
                {
                    string nm = DM.WidgetName(dm, i);
                    if (string.IsNullOrEmpty(nm)) continue;
                    if (nm.Length > longest) longest = nm.Length;
                    if (string.Equals(nm, MODS_ROW, StringComparison.Ordinal))
                    {
                        // Already present (BP kept it) — just remember where it is.
                        _modsRowIndex = i; _takenOver = true; return i;
                    }
                }
                DM.CreateOption(dm, MODS_ROW);          // appended at the end
                _modsRowIndex = n;                       // its index == old count
                int total = n + 1;
                AutoFit(dm, total, longest);             // grow the panel to fit the extra row
                SetListView(dm, Math.Min(total, ROWS_MAX));
                _takenOver = true;
                return _modsRowIndex;
            }
            catch { return -1; }
            finally { _rebuilding = false; }
        }

        // ── Bridge navigation (all deferred — never re-enter PE from a hook) ───
        void EnterBridge()
        {
            _confirmGuardUntil = Now + 400;
            _pending.Enqueue(() => { _navStack.Clear(); _navStack.Add(LuaMenuBridge.Root); RenderBridgePage(LuaMenuBridge.Root); });
        }

        void BackBridge()
        {
            _confirmGuardUntil = Now + 400;
            _pending.Enqueue(() =>
            {
                if (_navStack.Count <= 1) { ExitToMain(); return; }
                _navStack.RemoveAt(_navStack.Count - 1);              // pop current
                int parent = _navStack[_navStack.Count - 1];
                if (parent == LuaMenuBridge.Root) RenderBridgePage(parent);
                else { LuaMenuBridge.Repopulate(parent); _pollNavIn = 3; }   // dynamic → refresh via poll
            });
        }

        void ExitToMain()
        {
            var dm = DM.Get(); if (!MenuReady(dm)) return;
            try { dm.NewMenu(MAIN, false); } catch { }
            _bridgePage = -1; _takenOver = false; _modsRowIndex = -1;
            _nextHealCheck = 0;   // re-append our row as soon as the game rebuilds MAIN
            // (this is also what fixed "Back sometimes lands on an empty page")
        }

        void RenderBridgePage(int page)
        {
            var dm = DM.Get(); if (!MenuReady(dm)) return;
            _rebuilding = true;
            try
            {
                try { dm.NewMenu(BRIDGE_BYTE, false); } catch { }    // fresh page: game adds [Back] at index 0
                DM.SetActiveMenu(dm, BRIDGE_BYTE);
                _rows.Clear();
                int longest = 4;
                if (page == LuaMenuBridge.Root)
                    for (int i = 0; i < BUILTIN.Length; i++) { DM.CreateOption(dm, BUILTIN[i]); _rows.Add(new Row { Builtin = true, Id = i, Interactive = true }); longest = Math.Max(longest, BUILTIN[i].Length); }
                int n = LuaMenuBridge.Count(page);
                for (int i = 0; i < n; i++)
                {
                    if (!LuaMenuBridge.GetItem(page, i, out var it)) continue;
                    string label = it.Toggle ? (it.Label + "   [" + (it.State ? it.On : it.Off) + "]") : it.Label;
                    DM.CreateOption(dm, label);
                    _rows.Add(new Row { Builtin = false, Id = it.Id, Interactive = it.Interactive });
                    longest = Math.Max(longest, label.Length);
                }
                int total = _rows.Count + 1;                         // + [Back]
                AutoFit(dm, total, longest);                         // grow panel to fit
                SetListView(dm, Math.Min(total, ROWS_MAX));          // window (scroll past ROWS_MAX)
                DM.SetCurrentIndex(dm, _rows.Count > 0 ? 1 : 0);     // first item, not [Back]
                _bridgePage = page;
            }
            finally { _rebuilding = false; }
            try { dm.UpdateOptionHighlight(); } catch { }
        }

        void DoBuiltin(int idx)
        {
            try
            {
                if (idx == 0) DebugMenu.Clear();
                else if (idx == 1) DebugMenu.Sphere(0, 0, 100, 200, 0, 1, 0, 1, 16, 3, 2f);
            }
            catch { }
        }

        static void SetListView(DebugMenu_C dm, int maxVisible)
        {
            try
            {
                var pw = dm.GetObject("ParentWidget"); if (pw == null) return;
                var vbl = pw.GetObject("DebugVBoxList"); if (vbl == null) return;
                vbl.Set<int>("MaxVisible", maxVisible);
                vbl.Set<int>("FirstVisible", 0);
                vbl.Call("UpdateListView");
            }
            catch { }
        }

        // AUTO-FIT the 3D menu panel to the page: DrawSize.Y grows with the row
        // count (up to a window, then the list scrolls) and DrawSize.X grows with
        // the longest label, so nothing is buried. Widget.SetDrawSize resizes the
        // render target + the world quad. rowCount includes [Back].
        const int ROW_H = 52, ROWS_MAX = 20, PAD_H = 110;
        static void AutoFit(DebugMenu_C dm, int rowCount, int longestLabel)
        {
            try
            {
                var w = dm.GetObject("Widget"); if (w == null || !w.IsValid) return;
                int rows = Math.Min(Math.Max(rowCount, 4), ROWS_MAX);
                int height = Math.Clamp(PAD_H + rows * ROW_H, 360, 1200);
                int width = Math.Clamp(160 + longestLabel * 13, 500, 1400);
                var buf = new byte[8];
                BitConverter.GetBytes(width).CopyTo(buf, 0);
                BitConverter.GetBytes(height).CopyTo(buf, 4);
                try { w.CallRaw("SetDrawSize", buf); } catch { }
            }
            catch { }
        }

        // ── Per-frame: hook retry, nav queue, deferred takeover, nav-poll ──────
        public override void OnUpdate()
        {
            if (!_installed) TryInstallHooks();
            while (_pending.Count > 0) { var a = _pending.Dequeue(); try { a(); } catch { } }

            // ── MAIN self-heal (this is what the old Lua menu did, and why it worked) ──
            // The DebugMenu Blueprint rebuilds/clears DebugVBoxList via latent actions
            // AFTER OpenDebugMenu returns — and again on NewMenu/Back. A one-shot
            // injection gets wiped by that rebuild and never returns, which is exactly
            // the "menu never comes out" symptom. The Lua menu survived it by
            // re-injecting on a 200/500/1000/2000ms ladder; we do the same, but
            // state-driven: if our row is no longer sitting at the index we put it,
            // append it again. We never clear or rebuild the game's rows — whatever
            // the BP built stays, and we just re-add ours on the end.
            // Throttled to 200ms, so it costs one name fetch per check (no per-frame
            // allocation — that caused the GC lag before).
            if (Now >= _nextHealCheck)
            {
                _nextHealCheck = Now + 200;
                var dm = DM.Get();
                if (dm != null && MenuReady(dm) && DM.ActiveMenu(dm) == MAIN && DM.WidgetCount(dm) > 0)
                {
                    bool ours = _modsRowIndex >= 0 && _modsRowIndex < DM.WidgetCount(dm)
                                && string.Equals(DM.WidgetName(dm, _modsRowIndex), MODS_ROW, StringComparison.Ordinal);
                    if (!ours) { _takenOver = false; _modsRowIndex = -1; InjectModsRow(dm); }
                }
            }

            if (_pollNavIn > 0 && --_pollNavIn == 0)
            {
                int nav = LuaMenuBridge.TakeNav();
                if (nav != 0)
                {
                    if (_navStack.Count == 0 || _navStack[_navStack.Count - 1] != nav) _navStack.Add(nav);
                    RenderBridgePage(nav);
                }
                else if (_bridgePage >= 0)
                {
                    // no navigation → a toggle/action fired; refresh current page's labels
                    if (_bridgePage == LuaMenuBridge.Root) RenderBridgePage(_bridgePage);
                    else { LuaMenuBridge.Repopulate(_bridgePage); _pollNavIn = 3; }
                }
            }
        }

        void RegisterCommands()
        {
            Commands.Register("csmenu_status", _ =>
            {
                var dm = DM.Get();
                if (dm == null) return "DebugMenu_C: not found";
                return $"installed={_installed} taken={_takenOver} bridgePage={_bridgePage} rows={_rows.Count} stack={_navStack.Count} menu={DM.ActiveMenu(dm)} idx={DM.CurrentIndex(dm)} luaVer={LuaMenuBridge.Version}";
            });
        }

        public override void OnDeinitializeMelon() { _installed = false; }
    }
}
