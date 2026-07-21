// src/main.rs
// PCBridge — desktop control panel for the UE ModLoader on-device bridge.
// Toggle individual Lua/DLL mods on/off (fully — hooks & code patches restored
// via the modloader's mod_tracker), flip every mod at once, and watch a live,
// auto-saving logcat/modloader stream.
#![cfg_attr(not(debug_assertions), windows_subsystem = "windows")]

mod adb;
mod app;
mod bridge;
mod worker;

// Window/taskbar icon, decoded at startup from the PNG baked into the binary.
// (The Explorer .exe icon is embedded separately via build.rs; this is the
// live titlebar / taskbar / Alt-Tab icon while the app runs.)
fn load_icon() -> egui::IconData {
    let bytes = include_bytes!("../assets/pcbridge.png");
    match image::load_from_memory(bytes) {
        Ok(img) => {
            let rgba = img.to_rgba8();
            let (w, h) = rgba.dimensions();
            egui::IconData { rgba: rgba.into_raw(), width: w, height: h }
        }
        // Never block launch on a bad asset — fall back to an empty icon.
        Err(_) => egui::IconData { rgba: Vec::new(), width: 0, height: 0 },
    }
}

fn main() -> eframe::Result<()> {
    let options = eframe::NativeOptions {
        viewport: egui::ViewportBuilder::default()
            .with_inner_size([980.0, 720.0])
            .with_min_inner_size([720.0, 480.0])
            .with_icon(load_icon())
            .with_title("PCBridge — UE ModLoader Control"),
        ..Default::default()
    };

    eframe::run_native(
        "PCBridge",
        options,
        Box::new(|cc| Ok(Box::new(app::PcBridgeApp::new(cc)))),
    )
}
