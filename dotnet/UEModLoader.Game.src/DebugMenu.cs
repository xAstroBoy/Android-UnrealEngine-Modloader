// Hand-written (NOT generated — survives proxy regeneration, which only rewrites Generated/).
// A friendly façade over RE4's OWN native debug tools:
//   * DebugManager::DrawDebug*  — the shipped native draw UFunctions (addresses live
//     in the generated DebugManager proxy), so everything renders exactly like the
//     game's built-in debug overlay.
//   * DebugMenu_C               — the on-screen debug SCREEN actor (toggles + nav state).
//
// Vectors / colors / strings are passed to those UFunctions as pointers to native
// structs; we stage them in scratch native memory and free immediately after the call
// (DrawDebug* copies its inputs synchronously while building the draw element).
using System;
using UEModLoader;        // Memory, Native, Log

namespace UEModLoader.Game
{
    /// <summary>High-level access to RE4's native debug drawing + debug screen.</summary>
    public static class DebugMenu
    {
        // ── live singletons (null until the level/actor exists) ───────────────
        public static DebugManager_BP_C Manager   => DebugManager_BP_C.FirstOf();
        public static DebugManager      Native_   => DebugManager.FirstOf();
        public static DebugMenu_C       Screen    => DebugMenu_C.FirstOf();
        public static bool              Available => DebugManager.FirstOf() != null;

        // ── scratch native struct builders ────────────────────────────────────
        static IntPtr Vec(float x, float y, float z)
        {
            IntPtr p = Memory.Alloc(12);
            Memory.Write(p + 0, x); Memory.Write(p + 4, y); Memory.Write(p + 8, z);
            return p;
        }

        static IntPtr Col(float r, float g, float b, float a)
        {
            IntPtr p = Memory.Alloc(16);
            Memory.Write(p + 0, r); Memory.Write(p + 4, g);
            Memory.Write(p + 8, b); Memory.Write(p + 12, a);
            return p;
        }

        // FTransform (UE4 float, SIMD-aligned): Rotation FQuat @0x00, Translation @0x10, Scale3D @0x20 — 48 bytes.
        static IntPtr Xform(float x, float y, float z)
        {
            IntPtr p = Memory.Alloc(48);
            Memory.Write(p + 0x00, 0f); Memory.Write(p + 0x04, 0f);
            Memory.Write(p + 0x08, 0f); Memory.Write(p + 0x0C, 1f);   // identity quat
            Memory.Write(p + 0x10, x);  Memory.Write(p + 0x14, y); Memory.Write(p + 0x18, z);
            Memory.Write(p + 0x20, 1f); Memory.Write(p + 0x24, 1f); Memory.Write(p + 0x28, 1f); // unit scale
            return p;
        }

        // FString = TArray<TCHAR>{ TCHAR* Data; int32 Num; int32 Max } — TCHAR is UTF-16 here.
        static IntPtr Str(string s)
        {
            s ??= "";
            int n = s.Length + 1;
            IntPtr data = Memory.Alloc(n * 2);
            for (int i = 0; i < s.Length; i++) Memory.Write<short>(data + i * 2, (short)s[i]);
            Memory.Write<short>(data + s.Length * 2, 0);
            IntPtr hdr = Memory.Alloc(16);
            Memory.Write(hdr + 0, data.ToInt64());
            Memory.Write(hdr + 8, n);
            Memory.Write(hdr + 12, n);
            return hdr;
        }

        static void FreeStr(IntPtr hdr)
        {
            if (hdr == IntPtr.Zero) return;
            IntPtr data = (IntPtr)Memory.Read<long>(hdr);
            Memory.Free(data);
            Memory.Free(hdr);
        }

        // ── on-screen text ────────────────────────────────────────────────────
        /// <summary>HUD text. lifeTime 0 = one frame; pass >0 seconds for a persistent line.</summary>
        public static void ScreenText(string text,
                                      EDebugScreenPosition pos = EDebugScreenPosition.TopLeft,
                                      float scale = 1f, float lifeTime = 0f,
                                      float r = 1, float g = 1, float b = 1, float a = 1,
                                      bool stick = false)
        {
            var m = Native_; if (m == null) return;
            IntPtr s = Str(text), c = Col(r, g, b, a), bg = Col(0, 0, 0, 0);
            m.DrawDebugScreenText(s, pos, c, bg, scale, lifeTime, default, stick, null);
            FreeStr(s); Memory.Free(c); Memory.Free(bg);
        }

        // ── world-space text ──────────────────────────────────────────────────
        public static void WorldText(string text, float x, float y, float z,
                                     float r = 1, float g = 1, float b = 1, float a = 1,
                                     float lifeTime = 0f, bool facePlayer = true, bool stick = false)
        {
            var m = Native_; if (m == null) return;
            IntPtr s = Str(text), t = Xform(x, y, z), c = Col(r, g, b, a);
            m.DrawDebugWorldText(s, t, c, facePlayer, false, lifeTime, default, stick, null);
            FreeStr(s); Memory.Free(t); Memory.Free(c);
        }

        // ── primitives ────────────────────────────────────────────────────────
        public static void Sphere(float x, float y, float z, float radius,
                                  float r = 1, float g = 0, float b = 0, float a = 1,
                                  int segments = 12, float thickness = 1f, float lifeTime = 0f, bool stick = false)
        {
            var m = Native_; if (m == null) return;
            IntPtr ctr = Vec(x, y, z), col = Col(r, g, b, a);
            m.DrawDebugSphere(ctr, radius, col, segments, thickness, lifeTime, default, stick, null);
            Memory.Free(ctr); Memory.Free(col);
        }

        public static void Line(float x1, float y1, float z1, float x2, float y2, float z2,
                                float r = 0, float g = 1, float b = 0, float a = 1,
                                float thickness = 1f, float lifeTime = 0f, bool stick = false)
        {
            var m = Native_; if (m == null) return;
            IntPtr s = Vec(x1, y1, z1), e = Vec(x2, y2, z2), c = Col(r, g, b, a);
            m.DrawDebugLine(s, e, c, thickness, lifeTime, default, stick, null);
            Memory.Free(s); Memory.Free(e); Memory.Free(c);
        }

        public static void Arrow(float x1, float y1, float z1, float x2, float y2, float z2,
                                 float headWidth = 10f,
                                 float r = 1, float g = 1, float b = 0, float a = 1,
                                 float thickness = 1f, float lifeTime = 0f, bool stick = false)
        {
            var m = Native_; if (m == null) return;
            IntPtr s = Vec(x1, y1, z1), e = Vec(x2, y2, z2), c = Col(r, g, b, a);
            m.DrawDebugArrow(s, e, headWidth, c, thickness, lifeTime, default, stick, null);
            Memory.Free(s); Memory.Free(e); Memory.Free(c);
        }

        /// <summary>Remove all debug elements this API drew (or leave args to clear everything).</summary>
        public static void Clear()
        {
            var m = Native_; if (m == null) return;
            m.ClearDebugElements(default, null);
        }

        // ── debug SCREEN state (the DebugMenu_C actor) ────────────────────────
        public static bool ShowAllItems { get => Screen?.ShowAllItems ?? false; set { var s = Screen; if (s != null) s.ShowAllItems = value; } }
        public static bool Fog          { get => Screen?.FogIsEnabled ?? false; set { var s = Screen; if (s != null) s.FogIsEnabled = value; } }
        public static bool LevelSelect  { get => Screen?.LevelSelectActive ?? false; set { var s = Screen; if (s != null) s.LevelSelectActive = value; } }
        public static int  CurrentIndex { get => Screen?.CurrentIndex ?? 0; set { var s = Screen; if (s != null) s.CurrentIndex = value; } }
        public static byte ActiveMenu   { get => Screen?.ActiveMenu ?? (byte)0; set { var s = Screen; if (s != null) s.ActiveMenu = value; } }

        /// <summary>True once the debug screen actor exists in the level.</summary>
        public static bool ScreenReady => DebugMenu_C.FirstOf() != null;
    }
}
