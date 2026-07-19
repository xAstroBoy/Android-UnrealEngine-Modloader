// modloader/menu_bridge.h
// Cross-runtime debug-menu registry with PAGES. Lua mods build a menu tree via
// the shim in DebugMenuAPI (which calls the sol-typed builders declared in
// lua_bindings.cpp); the C# DebugMenuPlus renders it through the ueml_menu_*
// exports. Navigation + dynamic "populate on entry" are modelled here so the C#
// side never has to call Lua directly (that would re-enter the Lua lock).
//
// Model: every item is a button or a toggle on some PAGE. Page 0 is the root
// (MODS). An item's callback runs deferred on the game-thread Lua tick; if that
// callback navigates (Lua NavigateTo), a new page is built and a pending-nav
// signal is raised that C# polls. "label-only" items (cb == nil) are headers.
#pragma once
#include <string>

namespace menu_bridge
{
    // Called on the game-thread Lua tick (process_event_hook) — runs queued item
    // callbacks and any queued page re-populate. Safe place to run Lua.
    void tick();

    // ── C# facing (wrapped by ueml_menu_* exports) ───────────────────────────
    int  version();                       // bumps on any structure change
    int  root_page();                     // always 0
    // "title\x1fparent" for a page. false if the page id is unknown.
    bool page_pack(int page, char *out, int cap);
    int  page_item_count(int page);
    int  page_item_id(int page, int index);
    // "label\x1ftype\x1fstate\x1finteractive" (type=button|toggle, state=0/1,
    // interactive=0 for header labels). false if the item id is unknown.
    bool item_pack(int id, char *out, int cap);
    bool item_state(int id);
    void invoke(int id);                  // queue the item's callback for tick()
    // If the last invoked callback navigated, returns the new page id ONCE and
    // clears it; else 0. C# polls this after invoking.
    int  take_pending_nav();
    // Re-run a page's populate (Back / refresh). Queues it; the page is rebuilt
    // and raised as pending-nav so C# re-renders it. No-op for static pages.
    void repopulate(int page);
    void set_state(int id, bool s);       // Lua mods sync a toggle's cached state
}
