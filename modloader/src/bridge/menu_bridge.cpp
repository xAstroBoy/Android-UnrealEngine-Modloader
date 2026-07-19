// modloader/src/bridge/menu_bridge.cpp  — page-tree debug-menu registry.
// See menu_bridge.h. Lua mods build the tree via the sol builders (declared in
// lua_bindings.cpp): root_add for flat root items, navigate to open a dynamic
// sub-page, item_add for items inside a populate(). C# renders it via ueml_menu_*.
#include "modloader/menu_bridge.h"
#include "modloader/logger.h"

#define SOL_ALL_SAFETIES_ON 1   // MUST match lua_engine.h or sol::function mangles differently
#include <sol/sol.hpp>

#include <vector>
#include <unordered_map>
#include <mutex>
#include <atomic>
#include <string>
#include <cstdio>

namespace menu_bridge
{
    namespace
    {
        struct Item
        {
            int id = 0;
            int page = 0;
            std::string mod, label, on_text = "ON", off_text = "OFF";
            bool is_toggle = false;
            bool interactive = true;   // false = header label (no callback)
            std::atomic<bool> state{false};
            sol::function cb;          // toggle: fn(bool); button: fn()
        };
        struct Page
        {
            int id = 0;
            std::string title;
            int parent = -1;
            bool has_populate = false;
            sol::function populate;
            std::vector<int> item_ids;
        };

        std::recursive_mutex s_mutex;
        std::unordered_map<int, Item *> s_items;   // leaked for process life (sol refs)
        std::unordered_map<int, Page *> s_pages;
        std::atomic<int> s_next_item{1};
        std::atomic<int> s_next_page{1};   // 0 = root, reserved
        std::atomic<int> s_version{0};

        int s_build_page = -1;             // page a running populate() adds to
        int s_current_page = 0;            // page of the item whose cb is running (parent for navigate)
        int s_pending_nav = 0;             // page C# should navigate to (0 = none)
        std::vector<int> s_invoke_q;       // item ids to run
        std::vector<int> s_repop_q;        // pages to re-populate

        Page *ensure_root_locked()
        {
            auto it = s_pages.find(0);
            if (it != s_pages.end()) return it->second;
            Page *p = new Page();
            p->id = 0; p->title = "MODS"; p->parent = -1;
            s_pages[0] = p;
            return p;
        }
        Item *item_locked(int id) { auto it = s_items.find(id); return it == s_items.end() ? nullptr : it->second; }
        Page *page_locked(int id) { auto it = s_pages.find(id); return it == s_pages.end() ? nullptr : it->second; }

        // Run a page's populate() with the build target set, so item_add lands on it.
        void run_populate_locked(Page *pg)
        {
            if (!pg || !pg->has_populate || !pg->populate.valid()) return;
            pg->item_ids.clear();
            int prev = s_build_page;
            s_build_page = pg->id;
            try { auto r = pg->populate(); (void)r; }
            catch (const std::exception &e) { logger::log_error("MENUBR", "populate(page %d): %s", pg->id, e.what()); }
            catch (...) { logger::log_error("MENUBR", "populate(page %d): unknown", pg->id); }
            s_build_page = prev;
            s_version.fetch_add(1);
        }
    }

    // ── Lua-facing builders (declared in lua_bindings.cpp) ────────────────────
    int root_add(const std::string &mod, const std::string &label, const std::string &type,
                 sol::function cb, bool initial, const std::string &on, const std::string &off)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        Page *root = ensure_root_locked();
        // de-dup by (mod,label) so a hot-reload replaces rather than stacks
        for (size_t i = 0; i < root->item_ids.size(); ++i)
        {
            Item *e = item_locked(root->item_ids[i]);
            if (e && e->mod == mod && e->label == label) { root->item_ids.erase(root->item_ids.begin() + i); break; }
        }
        Item *e = new Item();
        e->id = s_next_item.fetch_add(1);
        e->page = 0; e->mod = mod.empty() ? "Mods" : mod; e->label = label;
        e->is_toggle = (type == "toggle");
        e->interactive = true;
        e->on_text = on.empty() ? "ON" : on; e->off_text = off.empty() ? "OFF" : off;
        e->cb = std::move(cb);
        e->state.store(initial);
        s_items[e->id] = e;
        root->item_ids.push_back(e->id);
        s_version.fetch_add(1);
        return e->id;
    }

    // Open a NEW dynamic sub-page: store populate, run it now to fill items, and
    // raise it as the pending navigation target. Returns the new page id.
    int navigate(const std::string &name, int parent, sol::function populate)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        Page *pg = new Page();
        pg->id = s_next_page.fetch_add(1);
        pg->title = name.empty() ? "Mods" : name;
        pg->parent = (parent >= 0) ? parent : s_current_page;   // parent = page we navigated FROM
        pg->has_populate = populate.valid();
        pg->populate = std::move(populate);
        s_pages[pg->id] = pg;
        run_populate_locked(pg);
        s_pending_nav = pg->id;
        return pg->id;
    }

    // Add an item to the page currently being populated. cb may be a no-op sol
    // (nil) → a non-interactive header label.
    int item_add(const std::string &label, sol::function cb)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        if (s_build_page < 0) return 0;
        Page *pg = page_locked(s_build_page);
        if (!pg) return 0;
        Item *e = new Item();
        e->id = s_next_item.fetch_add(1);
        e->page = pg->id; e->label = label;
        e->is_toggle = false;
        e->interactive = cb.valid();
        e->cb = std::move(cb);
        s_items[e->id] = e;
        pg->item_ids.push_back(e->id);
        return e->id;
    }

    void set_state(int id, bool st)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        if (Item *e = item_locked(id)) e->state.store(st);
    }

    // ── C# facing ────────────────────────────────────────────────────────────
    int version() { return s_version.load(); }
    int root_page() { return 0; }

    bool page_pack(int page, char *out, int cap)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        Page *pg = page_locked(page);
        if (!pg || !out || cap <= 0) return false;
        int n = snprintf(out, cap, "%s\x1f%d", pg->title.c_str(), pg->parent);
        return n > 0 && n < cap;
    }
    int page_item_count(int page)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        Page *pg = page_locked(page);
        return pg ? (int)pg->item_ids.size() : 0;
    }
    int page_item_id(int page, int index)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        Page *pg = page_locked(page);
        if (!pg || index < 0 || index >= (int)pg->item_ids.size()) return 0;
        return pg->item_ids[index];
    }
    bool item_pack(int id, char *out, int cap)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        Item *e = item_locked(id);
        if (!e || !out || cap <= 0) return false;
        int n = snprintf(out, cap, "%s\x1f%s\x1f%d\x1f%d\x1f%s\x1f%s",
                         e->label.c_str(), e->is_toggle ? "toggle" : "button",
                         e->state.load() ? 1 : 0, e->interactive ? 1 : 0,
                         e->on_text.c_str(), e->off_text.c_str());
        return n > 0 && n < cap;
    }
    bool item_state(int id)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        Item *e = item_locked(id);
        return e && e->state.load();
    }
    void invoke(int id)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        s_invoke_q.push_back(id);
    }
    int take_pending_nav()
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        int p = s_pending_nav; s_pending_nav = 0; return p;
    }
    void repopulate(int page)
    {
        std::lock_guard<std::recursive_mutex> lk(s_mutex);
        s_repop_q.push_back(page);
    }

    void tick()
    {
        std::vector<int> invokes, repops;
        {
            std::lock_guard<std::recursive_mutex> lk(s_mutex);
            if (s_invoke_q.empty() && s_repop_q.empty()) return;
            invokes.swap(s_invoke_q);
            repops.swap(s_repop_q);
        }
        // Item callbacks (a cb may call navigate → sets s_pending_nav)
        for (int id : invokes)
        {
            sol::function cb; bool is_toggle = false, newstate = false;
            {
                std::lock_guard<std::recursive_mutex> lk(s_mutex);
                Item *e = item_locked(id);
                if (!e || !e->interactive) continue;
                cb = e->cb; is_toggle = e->is_toggle;
                s_current_page = e->page;   // so navigate() from this cb parents to the right page
                if (is_toggle) { newstate = !e->state.load(); e->state.store(newstate); }
            }
            if (!cb.valid()) continue;
            try { if (is_toggle) { auto r = cb(newstate); (void)r; } else { auto r = cb(); (void)r; } }
            catch (const std::exception &e) { logger::log_error("MENUBR", "cb(id %d): %s", id, e.what()); }
            catch (...) { logger::log_error("MENUBR", "cb(id %d): unknown", id); }
        }
        // Page re-populations (Back / refresh) — rebuild then raise as pending-nav
        for (int page : repops)
        {
            std::lock_guard<std::recursive_mutex> lk(s_mutex);
            Page *pg = page_locked(page);
            if (!pg) continue;
            run_populate_locked(pg);
            s_pending_nav = page;
        }
    }
}

// ── C# P/Invoke exports (DllImport "libmodloader") ───────────────────────────
#define MB_EXPORT extern "C" __attribute__((visibility("default")))
MB_EXPORT int  ueml_menu_version()              { return menu_bridge::version(); }
MB_EXPORT int  ueml_menu_root()                 { return menu_bridge::root_page(); }
MB_EXPORT int  ueml_menu_page_pack(int p, char *o, int c) { return menu_bridge::page_pack(p, o, c) ? 1 : 0; }
MB_EXPORT int  ueml_menu_page_count(int p)      { return menu_bridge::page_item_count(p); }
MB_EXPORT int  ueml_menu_page_item(int p, int i){ return menu_bridge::page_item_id(p, i); }
MB_EXPORT int  ueml_menu_item_pack(int id, char *o, int c) { return menu_bridge::item_pack(id, o, c) ? 1 : 0; }
MB_EXPORT int  ueml_menu_state(int id)          { return menu_bridge::item_state(id) ? 1 : 0; }
MB_EXPORT void ueml_menu_invoke(int id)         { menu_bridge::invoke(id); }
MB_EXPORT int  ueml_menu_take_nav()             { return menu_bridge::take_pending_nav(); }
MB_EXPORT void ueml_menu_repopulate(int p)      { menu_bridge::repopulate(p); }
