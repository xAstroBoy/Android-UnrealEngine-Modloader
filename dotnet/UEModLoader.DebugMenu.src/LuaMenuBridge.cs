// P/Invoke layer for the native menu_bridge page tree (ueml_menu_* exports).
// The C# DebugMenuPlus renders whatever pages/items the Lua mods built and, on a
// click, calls Invoke → then polls TakeNav to follow any navigation the Lua
// callback triggered. All strings are packed with \x1f separators into a caller
// buffer (no marshalled allocations, no free needed).
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace UEModLoader.DebugMenuMod
{
    static class LuaMenuBridge
    {
        [DllImport("libmodloader")] static extern int  ueml_menu_version();
        [DllImport("libmodloader")] static extern int  ueml_menu_root();
        [DllImport("libmodloader")] static extern int  ueml_menu_page_pack(int page, byte[] buf, int cap);
        [DllImport("libmodloader")] static extern int  ueml_menu_page_count(int page);
        [DllImport("libmodloader")] static extern int  ueml_menu_page_item(int page, int index);
        [DllImport("libmodloader")] static extern int  ueml_menu_item_pack(int id, byte[] buf, int cap);
        [DllImport("libmodloader")] static extern int  ueml_menu_state(int id);
        [DllImport("libmodloader")] static extern void ueml_menu_invoke(int id);
        [DllImport("libmodloader")] static extern int  ueml_menu_take_nav();
        [DllImport("libmodloader")] static extern void ueml_menu_repopulate(int page);

        public struct Item { public int Id; public string Label; public bool Toggle; public bool State; public bool Interactive; public string On, Off; }

        [ThreadStatic] static byte[] _buf;
        static byte[] Buf => _buf ??= new byte[1024];

        public static int Version { get { try { return ueml_menu_version(); } catch { return 0; } } }
        public static int Root { get { try { return ueml_menu_root(); } catch { return 0; } } }
        public static void Invoke(int id) { try { ueml_menu_invoke(id); } catch { } }
        public static int TakeNav() { try { return ueml_menu_take_nav(); } catch { return 0; } }
        public static void Repopulate(int page) { try { ueml_menu_repopulate(page); } catch { } }
        public static bool State(int id) { try { return ueml_menu_state(id) != 0; } catch { return false; } }

        // Returns (title, parent) for a page; parent < 0 means root/none.
        public static bool GetPage(int page, out string title, out int parent)
        {
            title = ""; parent = -1;
            try
            {
                if (ueml_menu_page_pack(page, Buf, Buf.Length) == 0) return false;
                var f = Decode(Buf);
                if (f.Length < 2) return false;
                title = f[0]; int.TryParse(f[1], out parent);
                return true;
            }
            catch { return false; }
        }

        public static int Count(int page) { try { return ueml_menu_page_count(page); } catch { return 0; } }

        public static bool GetItem(int page, int index, out Item item)
        {
            item = default;
            try
            {
                int id = ueml_menu_page_item(page, index);
                if (id == 0) return false;
                if (ueml_menu_item_pack(id, Buf, Buf.Length) == 0) return false;
                var f = Decode(Buf);                       // label,type,state,interactive,on,off
                if (f.Length < 6) return false;
                item.Id = id;
                item.Label = f[0];
                item.Toggle = f[1] == "toggle";
                item.State = f[2] == "1";
                item.Interactive = f[3] == "1";
                item.On = f[4]; item.Off = f[5];
                return true;
            }
            catch { return false; }
        }

        static string[] Decode(byte[] b)
        {
            int z = Array.IndexOf(b, (byte)0); if (z < 0) z = b.Length;
            return Encoding.UTF8.GetString(b, 0, z).Split('\x1f');
        }
    }
}
